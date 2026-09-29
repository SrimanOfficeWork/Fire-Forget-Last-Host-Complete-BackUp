using Contracts;
using Microsoft.Data.SqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Data;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace IrnWorker
{
    public class RpaUploader
    {
        private readonly IConfiguration _cfg;
        private readonly ILogger<RpaUploader> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        // Selenium
        private readonly Uri _gridUri;
        private readonly string _browser;
        private readonly bool _headless;
        private readonly int _batchSize;
        private readonly int _timeoutSeconds;
        private readonly string _driverPath;
        private readonly string _chromePath;
        private readonly string _firefoxPath;
        private readonly string _seleniumManagerSourceExe;

        // App
        private readonly string _loginUrl;
        private readonly string _filePath;
        private readonly int _batchSizeDoc;
        private readonly int _mailTrackDelay;
        private readonly string _irnDbServiceUrl;
        private readonly string _connectionString;
        private readonly bool _useApiSave;

        private static readonly string[] ResultColumns =
        [
            "IRN_STATUS","Jobno","JobType","INV_SL","ITEM_SL","DOC_FILE_NAME",
            "DOC_TYPE","DOC_LEVEL","DRN","IRN","DOC_ISSUING_PARTY_NAME",
            "PLACE_OF_ISSUE","DOC_ISSUE_DATE","BENEFICIARY_PARTY_NAME","Guidid",
            "EXPORTER_ADDRESS1","EXPORTER_ADDRESS2","EXPORTER_ADDRESS3","EXPORTER_ADDRESS5",
            "CONSIGNEE_ADD1","CONSIGNEE_ADD2","CONSIGNEE_ADD3","CONSIGNEE_ADD5"
        ];

        public RpaUploader(IConfiguration cfg, ILogger<RpaUploader> logger, IHttpClientFactory httpClientFactory)
        {
            _cfg = cfg;
            _logger = logger;
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));

            _gridUri = new Uri(cfg.GetValue("Selenium:GridUrl", "http://localhost:4444")!);
            _browser = cfg.GetValue("Selenium:Browser", "Chrome")!;
            _headless = cfg.GetValue("Selenium:Headless", true);
            _batchSize = cfg.GetValue("Selenium:BatchSize", 5);
            _timeoutSeconds = cfg.GetValue("Selenium:TimeoutSeconds", 90);
            _driverPath = cfg.GetValue<string>("Driverpath")!;
            _chromePath = cfg.GetValue<string>("Chrome_Path")!;
            _firefoxPath = cfg.GetValue<string>("Firefox_Path")!;
            _seleniumManagerSourceExe = cfg.GetValue<string>("SeleniumManagerSourceExe")!;

            _loginUrl = cfg.GetValue("Icegate:Url", "https://foservices.icegate.gov.in/#/login")!;
            _filePath = cfg.GetValue<string>("FilePath", string.Empty)!;
            _batchSizeDoc = cfg.GetValue<int>("Batchsizedoc");
            _mailTrackDelay = cfg.GetValue<int>("mailtracktimedelay");
            _irnDbServiceUrl = cfg.GetValue<string>("IRN_DBService_url")!;
            _connectionString = cfg.GetConnectionString("DefaultConnection")!;
            _useApiSave = cfg.GetValue("UseApiSave", true); ;
        }

        // ─────────────────────────────────────────────────────────────
        // PUBLIC ENTRY POINT
        // ─────────────────────────────────────────────────────────────
        public async Task<List<FileUploadOutcome>> ProcessUploadAsync(UploadRequest request, CancellationToken token)
        {
            _logger.LogInformation(
                "RPA Started — TransId:{TransId} IP:{IP} Company:{Company} JobType:{JobType}  Branch:{Branch}  Period:{Period}  Files:{Files}",
                request.TransId, request.serverIP, request.CompanyId, request.JobType, request.BranchCode, request.Working_Period, request.Files?.Count());

            var outcomes = new List<FileUploadOutcome>();
            var resultsTable = BuildResultsTable(request.Files);

            // Disable Selenium Manager auto-download
            Environment.SetEnvironmentVariable("SE_DOWNLOAD_BROWSER", "false");
            Environment.SetEnvironmentVariable("SE_SKIP_DRIVER_DOWNLOAD", "true");
            Environment.SetEnvironmentVariable("SE_DISABLE_DRIVER_MANAGEMENT", "true");

            var driverOptions = BuildDriverOptions();
            _logger.LogInformation("TransId:{TransId} — Initiating driver", request.TransId);

            var driver = CreateDriverWithRetry(driverOptions, request.TransId);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            try
            {
                // ── Login + OTP ──────────────────────────────────────
                if (!await VerifyOtpWithRetryAsync(driver, request))
                {
                    request.Icegateerror = "OTP verification failed after retries";
                    throw new Exception(request.Icegateerror);
                }

                _logger.LogInformation("TransId:{TransId} — Logged in", request.TransId);
                wait.Until(ExpectedConditions.UrlContains("role-dashboard"));
                await Task.Delay(1000);

                // ── Navigate to eSANCHIT ─────────────────────────────
                await NavigateToESanchitAsync(driver, wait, request.TransId);

                // ── Upload in batches ────────────────────────────────
                string folderPath = Path.Combine(_filePath, request.CorrelationId);
                int total = request.Files.Count;

                for (int index = 0; index < total; index += _batchSizeDoc)
                {
                    token.ThrowIfCancellationRequested();
                    var batch = request.Files.Skip(index).Take(_batchSizeDoc).ToArray();
                    await ProcessBatchAsync(driver, wait, request, batch, folderPath, outcomes, resultsTable);
                }

                // ── Logout ───────────────────────────────────────────
                await WaitAndClickAsync(driver, By.Id("logout"));
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles.First());
                _logger.LogInformation("TransId:{TransId} — Logged out", request.TransId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("TransId:{TransId} — Exception: {Msg}", request.TransId, ex.Message);
                await HandleAutomationErrorAsync(driver, wait, request, ex);
                throw;
            }
            finally
            {
                try { driver.Quit(); } catch { }
                driver.Dispose();
                _logger.LogInformation("TransId:{TransId} — Driver disposed", request.TransId);

                try
                {
                    string xml = ConvertDataTableToXml(resultsTable);
                    if (_useApiSave)
                    {
                        _logger.LogInformation("TransId:{TransId} — Saving via API", request.TransId);
                        await PostJobPayloadAsync(request, xml);
                    }
                    else
                    {
                        _logger.LogInformation("TransId:{TransId} — Saving via SQL", request.TransId);
                        IRN_Automation_Server_Details(request, xml);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("TransId:{TransId} — Save failed: {Msg}", request.TransId, ex.Message);
                }

                DeleteCorrelationFolder(request);
            }

            return outcomes;
        }

        // ─────────────────────────────────────────────────────────────
        // DRIVER SETUP
        // ─────────────────────────────────────────────────────────────
        private DriverOptions BuildDriverOptions()
        {
            if (_browser.Equals("Chrome", StringComparison.OrdinalIgnoreCase))
            {
                var svc = ChromeDriverService.CreateDefaultService(_driverPath, "chromedriver.exe");
                svc.HideCommandPromptWindow = true;

                var opts = new ChromeOptions { BinaryLocation = _chromePath };
                if (_headless) opts.AddArgument("--headless");
                opts.AddArguments("--window-size=1920,1080", "--disable-gpu", "--disable-dev-shm-usage", "--no-sandbox");
                opts.AcceptInsecureCertificates = true;
                return opts;
            }

            if (_browser.Equals("Firefox", StringComparison.OrdinalIgnoreCase))
            {
                var svc = FirefoxDriverService.CreateDefaultService(_driverPath, "geckodriver.exe");
                svc.HideCommandPromptWindow = true;
                svc.FirefoxBinaryPath = _firefoxPath;

                var opts = new FirefoxOptions();
                if (_headless) opts.AddArgument("--headless");
                opts.AddArguments("--width=1920", "--height=1080");
                opts.AcceptInsecureCertificates = true;
                return opts;
            }

            throw new NotSupportedException($"Unsupported browser: {_browser}");
        }

        private IWebDriver CreateDriverWithRetry(DriverOptions options, string transId, int maxRetries = 3)
        {
            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    _logger.LogInformation("TransId:{TransId} — Driver attempt {Attempt}", transId, attempt);
                    return new RemoteWebDriver(_gridUri, options.ToCapabilities(), TimeSpan.FromSeconds(_timeoutSeconds));
                }
                catch (InvalidOperationException ex) when (ex.Message.Contains("Unable to obtain Selenium Manager Binary") && attempt < maxRetries)
                {
                    FixSeleniumManager(ex.Message);
                }
            }
            throw new InvalidOperationException("Driver creation failed after retries.");
        }

        private void FixSeleniumManager(string exceptionMessage)
        {
            var match = Regex.Match(exceptionMessage, @"[A-Z]:\\.*?selenium-manager\.exe", RegexOptions.IgnoreCase);
            if (!match.Success) { _logger.LogWarning("Cannot extract Selenium Manager path"); return; }

            string target = match.Value;
            string dir = Path.GetDirectoryName(target)!;

            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (!File.Exists(_seleniumManagerSourceExe))
                throw new FileNotFoundException("Source selenium-manager.exe missing", _seleniumManagerSourceExe);

            File.Copy(_seleniumManagerSourceExe, target, overwrite: true);
            _logger.LogInformation("Selenium Manager fixed at {Path}", target);
        }

        // ─────────────────────────────────────────────────────────────
        // LOGIN / OTP
        // ─────────────────────────────────────────────────────────────
        private async Task<bool> VerifyOtpWithRetryAsync(IWebDriver driver, UploadRequest request, int maxRetries = 2)
        {
            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                try
                {
                    driver.Navigate().GoToUrl(_loginUrl);
                    try { await WaitAndClickAsync(driver, By.Id("ym-auto-pop-up-close-button"), 5); } catch { }

                    string user = request.IcegateUser ?? _cfg.GetValue<string>("Icegate:Username")!;
                    string pass = request.IcegatePassword ?? _cfg.GetValue<string>("Icegate:Password")!;

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id("icegateId"))).SendKeys(user);
                    driver.FindElement(By.Id("password")).SendKeys(pass);
                    driver.FindElement(By.CssSelector("button.btn.login")).Click();
                    _logger.LogInformation("TransId:{TransId} — IcegateId:{user} Icegate_Pwsd:{TransId})", request.TransId, user, pass);
                    _logger.LogInformation("TransId:{TransId} — Login submitted (attempt {A})", request.TransId, attempt);
                    await Task.Delay(2000);
                    // ── Wait for either OTP page or login error ──────────────
                    bool navigatedToOtp = false;
                    try
                    {
                        new WebDriverWait(driver, TimeSpan.FromSeconds(15))
                            .Until(d => d.Url.Contains("otp-verification") || d.Url.Contains(_loginUrl.Split('#')[0]));

                        navigatedToOtp = driver.Url.Contains("otp-verification");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning("TransId:{TransId} — Timed out waiting for redirect", request.TransId);
                    }

                    // ── Login failed — still on login page ──────────────────
                    if (!navigatedToOtp)
                    {
                        TryCaptureLoginPageError(driver, request, wait);

                        if (attempt < maxRetries) { ResetBrowserToLogin(driver); await Task.Delay(3000); }
                        continue; // retry login
                    }

                    // ── Successfully on OTP page ─────────────────────────────
                    _logger.LogInformation("TransId:{TransId} — Navigated to OTP page", request.TransId);
                    await Task.Delay(_mailTrackDelay);

                    string otpJson = await PostOTPPayloadAsync(request);
                    var otpObj = JsonSerializer.Deserialize<OtpResponse>(otpJson);

                    if (string.IsNullOrEmpty(otpObj?.otp?.otp))
                        throw new Exception(otpObj?.otp?.error ?? "OTP not received");

                    string otp = otpObj.otp.otp;
                    var otpInputs = wait.Until(d => d.FindElements(By.CssSelector("input.otp-input")));

                    if (otpInputs.Count != otp.Length) throw new Exception("OTP input count mismatch");

                    for (int i = 0; i < otp.Length; i++) { otpInputs[i].Clear(); otpInputs[i].SendKeys(otp[i].ToString()); }

                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@class,'btn-submit')]"))).Click();
                    wait.Until(ExpectedConditions.UrlContains("role-dashboard"));

                    _logger.LogInformation("TransId:{TransId} — OTP verified", request.TransId);
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning("TransId:{TransId} — OTP attempt {A} failed: {Msg}", request.TransId, attempt, ex.Message);

                    // Only capture OTP page error if we're actually on OTP page
                    if (driver.Url.Contains("otp-verification"))
                    { 
                    TryCaptureOtpPageError(driver, request, wait);
                        
                    }

                    if (attempt < maxRetries) { ResetBrowserToLogin(driver); await Task.Delay(3000); }
                }
            }

            _logger.LogWarning("TransId:{TransId} — OTP verification failed after all retries", request.TransId);
            return false;
        }

        // ── Captures error on LOGIN page ────────────────────────────────────
        private void TryCaptureLoginPageError(IWebDriver driver, UploadRequest request, WebDriverWait wait)
        {
            try
            {
                // Try span error first
                var spans = driver.FindElements(By.CssSelector("span.text-error, div.text-error"));
                foreach (var el in spans)
                {
                    if (el.Displayed && !string.IsNullOrWhiteSpace(el.Text))
                    {
                        string text = el.Text.Trim();
                        _logger.LogInformation("TransId:{TransId} — Login page error: {Err}", request.TransId, text);
                        request.Icegateerror = "IRN Generation Process:\n" + text;
                        return;
                    }
                }

                // Try modal (password expired etc.)
                var modalEls = driver.FindElements(By.CssSelector("div.content.ng-star-inserted"));
                foreach (var el in modalEls)
                {
                    if (el.Displayed && el.Text.Contains("Password is Expired"))
                    {
                        _logger.LogInformation("TransId:{TransId} — ICEGATE password expired", request.TransId);
                        request.Icegateerror = "IRN Generation Process:\nYour Icegate Password is Expired. Change in our software and try again.\nPlease ignore if already done.";
                        return;
                    }
                }

                // The error in your screenshot — otpLimitExceed
                var errorEls = driver.FindElements(By.CssSelector("p.text-error, span.text-danger"));
                foreach (var el in errorEls)
                {
                    if (el.Displayed && !string.IsNullOrWhiteSpace(el.Text))
                    {
                        request.Icegateerror = "IRN Generation Process:\n" + el.Text.Trim();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("TransId:{TransId} — Could not capture login error: {Msg}", request.TransId, ex.Message);
            }
        }

        // ── Captures error on OTP page only ─────────────────────────────────
        private void TryCaptureOtpPageError(IWebDriver driver, UploadRequest request, WebDriverWait wait)
        {
            try
            {
                var els = driver.FindElements(By.XPath("//p[contains(@class,'text-error')]"));
                foreach (var el in els)
                {
                    if (el.Displayed && !string.IsNullOrWhiteSpace(el.Text))
                    {
                        string text = el.Text.Replace("Error:", "").Trim();
                        _logger.LogInformation("TransId:{TransId} — OTP error: {Err}", request.TransId, text);
                        request.Icegateerror = "IRN Generation Process:\n" + text;
                        return;
                    }
                }
            }
            catch { }
        }
      
        private void ResetBrowserToLogin(IWebDriver driver)
        {
            try
            {
                var handles = driver.WindowHandles.ToList();
                for (int i = handles.Count - 1; i > 0; i--)
                    try { driver.SwitchTo().Window(handles[i]); driver.Close(); } catch { }

                driver.SwitchTo().Window(handles[0]);
                driver.Navigate().GoToUrl("about:blank");
            }
            catch { }
        }

        // ─────────────────────────────────────────────────────────────
        // NAVIGATION
        // ─────────────────────────────────────────────────────────────
        private async Task NavigateToESanchitAsync(IWebDriver driver, WebDriverWait wait, string transId)
        {
            
            _logger.LogInformation("TransId: {TransId} -  Dashboard screen...", transId);
            var servicesHeader = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//mat-expansion-panel-header[.//h5[contains(text(), 'Services')]]")));

            await ScrollIntoViewAsync(driver, servicesHeader);
            await WaitUntilOverlayGoneAsync(driver);
            await SafeClickAsync(driver, By.XPath("//mat-expansion-panel-header[.//h5[contains(text(), 'Services')]]"));
            await Task.Delay(4000);

            var eSanchitDiv = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'eSANCHIT')]")));
            await ScrollIntoViewAsync(driver, eSanchitDiv);
            eSanchitDiv.FindElement(By.XPath(".//button[contains(@class, 'mat-icon-button')]")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='eSANCHIT']"))).Click();

            wait.Until(d => d.WindowHandles.Count > 1);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            wait.Until(ExpectedConditions.UrlContains("esanchit/home"));
            await Task.Delay(2000);

            _logger.LogInformation("TransId:{TransId} — eSANCHIT opened", transId);
        }

        // ─────────────────────────────────────────────────────────────
        // BATCH UPLOAD
        // ─────────────────────────────────────────────────────────────
        private async Task ProcessBatchAsync(
            IWebDriver driver, WebDriverWait wait, UploadRequest request,
            FileDescriptor[] batch, string folderPath,
            List<FileUploadOutcome> outcomes, DataTable resultsTable)
        {
            int total = request.Files.Count;
            _logger.LogInformation("TransId: {TransId} - Uploading to eSANCHIT total files: {totalFiles}",
                    request.TransId, total);
            // Open upload modal and attach files
            await WaitAndClickAsync(driver, By.Id("modal"));
            var fileInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("fileIn")));

            var paths = batch.Select(f => Path.Combine(folderPath, f.FileName));
            fileInput.SendKeys(string.Join("\n", paths));
            await WaitAndClickAsync(driver, By.Id("uploadSubmit"));

            await WaitForElementAsync(driver, "docTypeSelect_0", "upload screen", request.TransId);

            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("modal-content")));
            _logger.LogInformation("TransId:{TransId} — Modal gone, upload OK", request.TransId);

            // Set document types
            for (int i = 0; i < batch.Length; i++)
                SetDocumentType(driver, i, batch[i]);

            await WaitAndClickAsync(driver, By.Id("submitDocs"));
            await WaitAndClickAsync(driver, By.Id("submitDocsConfirm"));

            await WaitForIrnAsync(driver, request.TransId);
            CaptureMaxSizeMbError(driver, request);

            // Harvest IRN / DRN
            for (int j = 0; j < batch.Length; j++)
                HarvestIrnResult(driver, j, batch[j], outcomes, resultsTable);

            _logger.LogInformation(
                "TransId:{TransId} — Batch done, IRNs harvested ({Count} files)",
                request.TransId, batch.Length);
        }

        private async Task WaitForElementAsync(IWebDriver driver, string elementId, string label, string transId, int maxRetries = 3)
        {
            for (int retry = 0; retry < maxRetries; retry++)
            {
                await Task.Delay(500);
                var els = driver.FindElements(By.Id(elementId));
                if (els.Any() && els[0].Displayed)
                {
                    _logger.LogInformation("TransId:{TransId} — {Label} loaded after {R} refresh(es)", transId, label, retry);
                    return;
                }
                _logger.LogWarning("TransId:{TransId} — {Label} not found, refresh {R}/{Max}", transId, label, retry + 1, maxRetries);
                driver.Navigate().Refresh();
                await Task.Delay(2000);
            }
        }

        private async Task WaitForIrnAsync(IWebDriver driver, string transId, int maxRetries = 3)
        {
            for (int retry = 0; retry < maxRetries; retry++)
            {
                await Task.Delay(500);
                var els = driver.FindElements(By.Id("irn_0"));
                if (els.Any() && !string.IsNullOrEmpty(els[0].GetAttribute("value")))
                {
                    _logger.LogInformation("TransId:{TransId} — IRN loaded after {R} refresh(es)", transId, retry);
                    return;
                }
                _logger.LogWarning("TransId:{TransId} — IRN not ready, refresh {R}/{Max}", transId, retry + 1, maxRetries);
                driver.Navigate().Refresh();
                await Task.Delay(3000);
            }
        }

        private void SetDocumentType(IWebDriver driver, int index, FileDescriptor file)
        {
            string dropdownId = $"docTypeSelect_{index}";
            string fileNameId = $"fileName_{index}";

            if (!driver.FindElements(By.Id(fileNameId)).Any()) return;

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var dropdown = wait.Until(ExpectedConditions.ElementExists(By.Id(dropdownId)));
                try
                {
                    new SelectElement(dropdown).SelectByValue(file.DocumentType);
                }
                catch
                {
                    // JS fallback
                    string script = $@"
                        var dd = document.getElementById('{dropdownId}');
                        for (var j = 0; j < dd.options.length; j++) {{
                            if (dd.options[j].value.indexOf('{file.DocumentType}') === 0) {{
                                dd.value = dd.options[j].value;
                                dd.dispatchEvent(new Event('change', {{ bubbles: true }}));
                                break;
                            }}
                        }}";
                    try { ((IJavaScriptExecutor)driver).ExecuteScript(script); }
                    catch (WebDriverException ex)
                    { _logger.LogWarning("JS doc-type fallback failed for {File}: {Msg}", file.FileName, ex.Message); }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("SetDocumentType failed for index {I}: {Msg}", index, ex.Message);
            }
        }

        private void CaptureMaxSizeMbError(IWebDriver driver, UploadRequest request)
        {
            try
            {
                var el = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
                    .Until(d => d.FindElements(By.Id("maxSizeMb")).FirstOrDefault());

                string? html = el?.GetAttribute("innerHTML")?.Trim();
                if (!string.IsNullOrEmpty(html))
                {
                    string msg = "Document type is not accepted by ICEGATE.\n" + html.Replace("<br>", "\n");
                    _logger.LogInformation("TransId:{TransId} — {Msg}", request.TransId, msg);
                    request.Icegateerror = "IRN Generation Process:\n" + msg + "\n Please ignore this message if already done";
                }
            }
            catch { }
        }

        private void HarvestIrnResult(IWebDriver driver, int index, FileDescriptor file,
            List<FileUploadOutcome> outcomes, DataTable resultsTable)
        {
            string irnId = $"irn_{index}";
            string drnId = $"drn_{index}";

            if (!driver.FindElements(By.Id(irnId)).Any()) return;

            string irn = driver.FindElement(By.Id(irnId)).GetAttribute("value");
            string drn = driver.FindElement(By.Id(drnId)).GetAttribute("value");

            if (string.IsNullOrEmpty(irn)) return;

            outcomes.Add(new FileUploadOutcome
            {
                FileName = file.FileName,
                DocumentType = file.DocumentType,
                IRNNo = irn,
                DRNNo = drn,
                Doc_Type = file.Level,
                IRN_STATUS = "Success."
            });

            var rows = resultsTable.Select($"DOC_FILE_NAME = '{file.FileName.Replace("'", "''")}'");
            if (rows.Length > 0)
            {
                rows[0]["IRN"] = irn;
                rows[0]["DRN"] = drn;
                rows[0]["IRN_STATUS"] = "Success.";
            }
        }

        // ─────────────────────────────────────────────────────────────
        // ERROR HANDLING
        // ─────────────────────────────────────────────────────────────
        private async Task HandleAutomationErrorAsync(IWebDriver driver, WebDriverWait wait, UploadRequest request, Exception ex)
        {
            try
            {
                switch (driver.Url)
                {
                    case var u when u == "https://foservices.icegate.gov.in/#/login":
                        HandleLoginPageError(driver, wait, request);
                        break;

                    case var u when u == "https://foservices.icegate.gov.in/#/otp-verification":
                        try
                        {
                            var err = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("p.text-error")));
                            request.Icegateerror = err.Text;
                            _logger.LogInformation("TransId:{TransId} — OTP error: {Msg}", request.TransId, err.Text);
                        }
                        catch { _logger.LogWarning("TransId:{TransId} — OTP page error unreadable", request.TransId); }
                        break;

                    case var u when u == "https://www.icegate.gov.in/esanchit/uploadDocs":
                        try
                        {
                            var errEl = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("docs_error")));
                            request.Icegateerror = "IRN generation process error from ICEGATE:\n" + errEl.Text.Trim() + "\n Please ignore if already done";
                            _logger.LogInformation("TransId:{TransId} — Upload error: {Msg}", request.TransId, errEl.Text);
                        }
                        catch (WebDriverTimeoutException) { _logger.LogWarning("TransId:{TransId} — No docs_error element", request.TransId); }
                        break;

                    case var u when u == "https://www.icegate.gov.in/esanchit/submitDocs":
                        try
                        {
                            var divEl = driver.FindElement(By.Id("maxSizeMb"));
                            request.Icegateerror = "IRN Generation Process:\nDocument type not accepted by ICEGATE\n" + divEl.GetAttribute("innerHTML") + "\n Please ignore if already done";
                        }
                        catch { request.Icegateerror = "IRN Generation Process:\nAn error occurred in ICEGATE, please retry."; }
                        break;

                    default:
                        _logger.LogWarning("TransId:{TransId} — Network/site error: {Msg}", request.TransId, ex.Message);
                        request.Icegateerror = "IRN Generation Process:\nAn error occurred in ICEGATE, please retry.";
                        break;
                }
            }
            catch (Exception catchEx)
            {
                _logger.LogWarning("TransId:{TransId} — Error handler threw: {Msg}", request.TransId, catchEx.Message);
                request.Icegateerror = "IRN Generation Process:\nAn error occurred in ICEGATE, please retry.";
            }
        }

        private void HandleLoginPageError(IWebDriver driver, WebDriverWait wait, UploadRequest request)
        {
            try
            {
                var spans = driver.FindElements(By.CssSelector("span.text-error.d-block.pt-1.ng-star-inserted"));
                if (spans.Count > 0 && spans[0].Displayed)
                {
                    SetLoginError(request, spans[0].Text);
                    return;
                }

                // Second error: Invalid Credentials
                var divs = driver.FindElements(By.CssSelector("div.text-error.d-block.pt-1.break-text.ng-star-inserted"));
                if (divs.Count > 0 && divs[0].Displayed)
                {
                    SetLoginError(request, divs[0].Text);
                    return;
                }
            }
            catch
            {
                try
                {
                    var modal = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                        .Until(ExpectedConditions.ElementIsVisible(By.Id("modal-content")));
                    var text = driver.FindElement(By.CssSelector("div.content.ng-star-inserted"));
                    if (text.Text.Contains("Your Password is Expired."))
                    {
                        _logger.LogInformation("TransId:{TransId} — ICEGATE password expired", request.TransId);
                        request.Icegateerror = "IRN Generation Process:\nYour Icegate Password is Expired. Change in our software and try again.\nPlease ignore if already done.";
                    }
                }
                catch (Exception modalEx)
                {
                    _logger.LogWarning("TransId:{TransId} — Modal error: {Msg}", request.TransId, modalEx.Message);
                    request.Icegateerror = "IRN Generation Process:\nAn error occurred in ICEGATE, please retry.";
                }
            }
        }

        private void SetLoginError(UploadRequest request, string text)
        {
            _logger.LogInformation("TransId:{TransId} — Login error: {Err}", request.TransId, text);
            request.Icegateerror = "IRN Generation Process:\n" + text;
        }

        // ─────────────────────────────────────────────────────────────
        // SQL SAVE (local only — UseApiSave: false)
        // ─────────────────────────────────────────────────────────────
        public void IRN_Automation_Server_Details(UploadRequest data, string xmlData)
        {
            _logger.LogInformation("TransId:{TransId} — SQL save: fetching client connection", data.TransId);

            var ds = IRN_Automation_Insert_Update(
                "",                       // user
                "",                       // pass
                "",                       // jobNo
                "",                       // transId
                "",                       // clientName
                "",                       // branchCode
                "",                       // branchCommon
                data.Working_Period,      // workingPeriod
                data.CompanyId,           // companyLicense
                "",                       // userId
                "",                       // xmlData
                "Client_Con_string",      // mFlag
                _connectionString,        // connString
                "",                       // jobType
                data.Icegateerror ?? "",  // icegateError
                "",                       // mailType
                "",                       // mailId
                "",                       // mobNo
                "",                       // jobCat
                "",                       // mailPass
                "",                       // mailHost
                "",                       // mailPort
                "",                       // mailSsl
                "",                       // mailTenantId
                "",                       // mailClientId
                "");                      // mailScreenId

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                _logger.LogWarning("TransId:{TransId} — No client connection returned", data.TransId);
                return;
            }

            var row = ds.Tables[0].Rows[0];
            string clientConn = $"Server={row["SERVER_NAME"]};database={row["DATABASE_NAME"]};" +
                                $"uid={row["LOGIN_NAME"]};pwd={row["PWD"]};TrustServerCertificate=True;";

            _logger.LogInformation("TransId:{TransId} — Client connection resolved, saving IRN", data.TransId);
            IRN_Automation_Save(data, xmlData, clientConn);
        }

        private DataSet IRN_Automation_Save(UploadRequest data, string xmlData, string connString)
        {
            var ds = IRN_Automation_Insert_Update(
                data.IcegateUser, data.IcegatePassword,
                "", data.TransId, data.Client,
                data.BranchCode, data.BranchCode, data.Working_Period,
                data.CompanyId, data.User_id, xmlData, "S", connString,
                data.JobType ?? "", data.Icegateerror ?? "",
                data.MailType, data.Mailid, data.Mobno, data.JobType,
                data.password, data.Mailhost, data.Mailport, data.Mailssl,
                data.MailTenentid, data.MailClientid, data.MailScreenid);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                _logger.LogInformation("TransId:{TransId} — IRN saved via SQL", data.TransId);

            return ds;
        }

        // ─────────────────────────────────────────────────────────────
        // HTTP PAYLOADS
        // ─────────────────────────────────────────────────────────────
        public async Task PostJobPayloadAsync(UploadRequest data, string xmlData)
        {
            _logger.LogInformation(
                "BD Save — TransId:{TransId} - IP:{IP} Branch:{Branch} Period:{Period} JobType:{JobType} Company:{Company} Files:{Files} Error:{Err}",
                data.TransId, data.serverIP, data.BranchCode, data.Working_Period,
                data.JobType, data.CompanyId, data?.Files?.Count(), data.Icegateerror);

            var payload = new
            {
                user = data.IcegateUser,
                pass = data.IcegatePassword,
                jobNo_PS = data.JobNo,
                jobNo = "1234",
                client_Name = data.TransId,
                branch_Code = data.BranchCode,
                branch_Common = data.BranchCode,
                working_Period = data.Working_Period,
                company_License = data.CompanyId,
                user_Id = data.User_id,
                xmlData_A = xmlData,
                mFlag = "s",
                serverIP = data.serverIP,
                JobType = data.JobType,
                Icegateerror = data.Icegateerror,
                Mailid = data.Mailid,
                Mob_no = data.Mobno,
                job_cat = data.JobType,
                Mail_pass = data.password,
                Mail_host = data.Mailhost,
                Mail_port = data.Mailport,
                Mail_ssl = data.Mailssl,
                Mail_type = data.MailType,
                Mail_tenentid = data.MailTenentid,
                Mail_clientid = data.MailClientid,
                Mail_screenid = data.MailScreenid,
                TransId = data.TransId
            };

            string json = JsonSerializer.Serialize(payload);
            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(90);

            for (int attempt = 1; attempt <= 3; attempt++)
            {
                try
                {
                    using var content = new StringContent(json, Encoding.UTF8, "application/json");
                    using var response = await client.PostAsync(_irnDbServiceUrl, content);
                    string body = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogWarning("{JobNo} API {Status} on attempt {A}: {Body}", data.JobNo, response.StatusCode, attempt, body);
                        if (attempt == 3) throw new HttpRequestException($"API failed: {response.StatusCode} — {body}");
                    }
                    else
                    {
                        _logger.LogInformation("{JobNo} API success on attempt {A}: {Body}", data.JobNo, attempt, body);
                        return;
                    }
                }
                catch (TaskCanceledException ex) when (!ex.CancellationToken.IsCancellationRequested)
                { _logger.LogWarning("{JobNo} Timeout attempt {A}: {Msg}", data.JobNo, attempt, ex.Message); if (attempt == 3) throw; }
                catch (HttpRequestException ex)
                { _logger.LogWarning("{JobNo} HTTP error attempt {A}: {Msg}", data.JobNo, attempt, ex.Message); if (attempt == 3) throw; }
                catch (Exception ex)
                { _logger.LogError("{JobNo} Unexpected error attempt {A}: {Msg}", data.JobNo, attempt, ex.Message); if (attempt == 3) throw; }

                await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, attempt)));
            }
        }

        public async Task<string> PostOTPPayloadAsync(UploadRequest data)
        {
            bool useSsl = bool.TryParse(data.Mailssl, out bool s) && s;
            _logger.LogInformation(
               "RPA Started — TransId:{TransId} - serverType:{serverType} host:{host}  port:{port}  ssl:{ssl}  email:{email} password:{password}",
               data.TransId, data.MailType, data.Mailhost, data.Mailport, useSsl, data.Mailid, data.password);


            var payload = new
            {
                serverType = data.MailType,
                host = data.Mailhost,
                port = data.Mailport,
                useSsl,
                email = data.Mailid,
                password = data.password,
                subjectContains = "OTP",
                fromAddress = "no-reply@icegate.gov.in",
                tenantId = data.MailTenentid,
                clientId = data.MailClientid,
                clientSecret = data.MailScreenid
            };

            try
            {
                using var httpClient = new HttpClient();
                using var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                using var response = await httpClient.PostAsync("http://mailboxservices.royaltechsystems.co.in/api/OTP/read", content);
                string result = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("OTP API Response: {Result}", result);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("OTP API Error: {Msg}", ex.Message);
                return null!;
            }
        }

        // ─────────────────────────────────────────────────────────────
        // DATABASE (direct SQL — kept for backward compatibility)
        // ─────────────────────────────────────────────────────────────
        public DataSet IRN_Automation_Insert_Update(
            string user, string pass, string jobNo, string transId, string clientName,
            string branchCode, string branchCommon, string workingPeriod, string companyLicense,
            string userId, string xmlData, string mFlag, string connString, string jobType,
            string icegateError, string mailType, string mailId, string mobNo, string jobCat,
            string mailPass, string mailHost, string mailPort, string mailSsl,
            string mailTenantId, string mailClientId, string mailScreenId)
        {
            var ds = new DataSet();

            using var conn = new SqlConnection(connString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                using var cmd = new SqlCommand("IMP_EXP_IRN_AUTOMATION_INS_UPD_DEL_BG", conn, tran)
                { CommandType = CommandType.StoredProcedure };

                void Add(string name, object? val) => cmd.Parameters.AddWithValue(name, val ?? DBNull.Value);

                Add("@JOBNO", jobNo);
                Add("@JOBNO_PS", jobNo);
                Add("@Client_name", clientName);
                Add("@xmlString", xmlData);
                Add("@BRANCH_CODE", branchCode);
                Add("@Branch_Common", branchCommon);
                Add("@WORKING_PERIOD", workingPeriod);
                Add("@COMPANY_LICENSE", companyLicense);
                Add("@MFLAG", mFlag);
                Add("@USER_ID", "");
                Add("@ICEGATE_USER_NAME", user);
                Add("@ICEGATE_PWD", pass);
                Add("@Icegateerror", icegateError);
                Add("@JobType", jobType);
                Add("@guidid", transId);
                Add("@Mail_type", mailType);
                Add("@Mailid", mailId);
                Add("@Mob_no", mobNo);
                Add("@job_cat", jobCat);
                Add("@Mail_pass", mailPass);
                Add("@Mail_host", mailHost);
                Add("@Mail_port", mailPort);
                Add("@Mail_ssl", mailSsl);
                Add("@MailTenentid", mailTenantId);
                Add("@MailClientid", mailClientId);
                Add("@MailScreenid", mailScreenId);

                var errParam = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000)
                { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(errParam);

                new SqlDataAdapter(cmd).Fill(ds);

                if (errParam.Value is string errMsg && !string.IsNullOrEmpty(errMsg))
                    _logger.LogWarning("TransId:{TransId} SP error: {Err}", transId, errMsg);

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                _logger.LogError("TransId:{TransId} SP exception: {Err}", transId, ex.Message);
                throw;
            }

            return ds;
        }

        // ─────────────────────────────────────────────────────────────
        // SELENIUM HELPERS
        // ─────────────────────────────────────────────────────────────
        private async Task ScrollIntoViewAsync(IWebDriver driver, IWebElement element)
        {
            if (element == null) return;
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript(
                    "arguments[0].scrollIntoView({behavior:'smooth',block:'center'});", element);
                await Task.Delay(300);
            }
            catch (StaleElementReferenceException) { }
            catch (WebDriverException ex) when (ex.Message.Contains("Promise was collected")) { }
        }

        private async Task WaitUntilOverlayGoneAsync(IWebDriver driver, int timeoutSeconds = 10)
        {
            try
            {
                await Task.Delay(300);
                new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds))
                    .Until(ExpectedConditions.InvisibilityOfElementLocated(
                        By.CssSelector("div.overlay, div.cdk-overlay-backdrop, div[class*='overlay']")));
            }
            catch (WebDriverTimeoutException)
            { _logger.LogWarning("Overlay still present after {T}s — proceeding.", timeoutSeconds); }
        }

        private async Task SafeClickAsync(IWebDriver driver, By by, int timeoutSeconds = 10)
        {
            var element = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds))
                .Until(ExpectedConditions.ElementToBeClickable(by));

            await WaitUntilOverlayGoneAsync(driver);

            try { element.Click(); }
            catch (ElementClickInterceptedException)
            {
                _logger.LogWarning("Click intercepted — JS fallback for {Locator}", by);
                try { ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", driver.FindElement(by)); }
                catch (NoSuchElementException) { _logger.LogError("Element gone before JS click: {Locator}", by); }
            }
        }

        private async Task WaitAndClickAsync(IWebDriver driver, By by, int timeoutSeconds = 40)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds))
                .Until(ExpectedConditions.ElementToBeClickable(by))
                .Click();
            await Task.Delay(200);
        }

        // ─────────────────────────────────────────────────────────────
        // DATA HELPERS
        // ─────────────────────────────────────────────────────────────
        private DataTable BuildResultsTable(List<FileDescriptor> files)
        {
            var dt = new DataTable();
            foreach (var col in ResultColumns) dt.Columns.Add(col, typeof(string));

            foreach (var f in files)
            {
                var r = dt.NewRow();
                r["IRN_STATUS"] = f.IRN_STATUS ?? "";
                r["Jobno"] = f.Jobno ?? "";
                r["JobType"] = f.Jobtype ?? "";
                r["INV_SL"] = f.Inv_sl ?? "";
                r["ITEM_SL"] = f.itm_sl ?? "";
                r["DOC_FILE_NAME"] = f.FileName ?? "";
                r["DOC_TYPE"] = f.DocumentType ?? "";
                r["DOC_LEVEL"] = f.Level ?? "";
                r["DRN"] = "";
                r["IRN"] = "";
                r["DOC_ISSUING_PARTY_NAME"] = f.Iss_party ?? "";
                r["PLACE_OF_ISSUE"] = f.POI ?? "";
                r["DOC_ISSUE_DATE"] = f.DOI ?? "";
                r["BENEFICIARY_PARTY_NAME"] = f.Ben_party ?? "";
                r["Guidid"] = f.GuidId ?? "";
                r["EXPORTER_ADDRESS1"] = f.EXPORTER_ADDRESS1 ?? "";
                r["EXPORTER_ADDRESS2"] = f.EXPORTER_ADDRESS2 ?? "";
                r["EXPORTER_ADDRESS3"] = f.EXPORTER_ADDRESS3 ?? "";
                r["EXPORTER_ADDRESS5"] = f.EXPORTER_ADDRESS5 ?? "";
                r["CONSIGNEE_ADD1"] = f.CONSIGNEE_ADD1 ?? "";
                r["CONSIGNEE_ADD2"] = f.CONSIGNEE_ADD2 ?? "";
                r["CONSIGNEE_ADD3"] = f.CONSIGNEE_ADD3 ?? "";
                r["CONSIGNEE_ADD5"] = f.CONSIGNEE_ADD5 ?? "";
                dt.Rows.Add(r);
            }
            return dt;
        }

        private void DeleteCorrelationFolder(UploadRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.CorrelationId)) return;
            string folder = Path.Combine(_filePath, request.CorrelationId);
            if (Directory.Exists(folder))
            {
                Directory.Delete(folder, true);
                _logger.LogInformation("TransId:{TransId} — Deleted folder: {Folder}", request.TransId, folder);
            }
            else
            {
                _logger.LogInformation("TransId:{TransId} — Folder not found: {Folder}", request.TransId, folder);
            }
        }

        private static string ConvertDataTableToXml(DataTable dt)
        {
            var ds = new DataSet();
            ds.Merge(dt, true, MissingSchemaAction.AddWithKey);
            ds.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in ds.Tables[0].Columns)
                col.ColumnMapping = MappingType.Attribute;

            using var sw = new StringWriter();
            ds.WriteXml(sw, XmlWriteMode.WriteSchema);
            return sw.ToString();
        }
    }

    // ─────────────────────────────────────────────────────────────────
    // MODELS
    // ─────────────────────────────────────────────────────────────────
    public class OtpResponse { public OtpData? otp { get; set; } }
    public class OtpData
    {
        public bool success { get; set; }
        public string? otp { get; set; }
        public string? error { get; set; }
    }

    public static class SqlHelper
    {
        public static DataSet ExecuteDataset(string connectionString, CommandType commandType,
            string commandText, params SqlParameter[] commandParameters)
        {
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(commandText, conn) { CommandType = commandType };
            foreach (var p in commandParameters ?? []) if (p != null) cmd.Parameters.Add(p);
            using var da = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
