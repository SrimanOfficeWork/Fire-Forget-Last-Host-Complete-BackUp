using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Globalization;
using BussinessObject;
public partial class SB_BE_Tracking_Auto_Captcha : ThemeClass
{
    public string Grid_id;
    DataSet ds = new DataSet();
    AppSession aps = new AppSession();
    SB_BE_Status_Tracking ST = new SB_BE_Status_Tracking();
    Global_variables ObjUBO = new Global_variables();
    public string SELECT_BRANCH, TYPE, Jobno, SB_BE_NO = "", SB_BE_DATE = "", JOBDATE = "", LOCATION = "", COMPANY_ID = "", currentuser, currentbranch;
    private static Dictionary<string, ProgressData> progressStore = new Dictionary<string, ProgressData>();
    private static Dictionary<string, DateTime> heartbeats = new Dictionary<string, DateTime>();
    private static HashSet<string> cancelled = new HashSet<string>();
    private static readonly TimeSpan ExpirationTime = TimeSpan.FromMinutes(30);
    private static ConcurrentDictionary<string, string> finalMessageStore = new ConcurrentDictionary<string, string>();
    private static Dictionary<string, DataTable> gridStore = new Dictionary<string, DataTable>();
    int index = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        SELECT_BRANCH = Connection.Get_Company_Type();
        currentuser = Session["currentuser"].ToString();
        COMPANY_ID = Connection.COMPANYID();
        currentbranch = Session["currentbranch"].ToString();

        if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
        {
            Jobno = Request.QueryString["JOBID"].ToString();
        }
        else
        {
            Jobno = Connection.IMP_Jobno();
        }
        if (Request.QueryString["BE_NO"] != "" && Request.QueryString["BE_NO"] != null)
        {
            SB_BE_NO = Request.QueryString["BE_NO"].ToString();
        }
        if (Request.QueryString["BE_DATE"] != "" && Request.QueryString["BE_DATE"] != null)
        {
            SB_BE_DATE = Server.UrlDecode(Request.QueryString["BE_DATE"].ToString());
            //SB_BE_DATE = Request.QueryString["BE_DATE"].ToString();
        }
        if (Request.QueryString["JOBDATE"] != "" && Request.QueryString["JOBDATE"] != null)
        {
            JOBDATE = Server.UrlDecode(Request.QueryString["JOBDATE"].ToString());

        }
        if (Request.QueryString["STATUS"] != "" && Request.QueryString["STATUS"] != null)
        {
            TYPE = Request.QueryString["STATUS"].ToString();
            //TYPE = "SB";
        }
        if (Request.QueryString["LOCATION"] != "" && Request.QueryString["LOCATION"] != null)
        {
            LOCATION = Request.QueryString["LOCATION"].ToString();
        }

        if (TYPE == "SB")
        {
            tag_Sbstatus.Style["display"] = "Block";
            lblSB_BE_no.Text = "SB No";
            lblSB_BE_dt.Text = "SB Date";
        }
        else if (TYPE == "BE")
        {
            tag_BEstatus.Style["display"] = "Block";
            lblSB_BE_no.Text = "BE No";
            lblSB_BE_dt.Text = "BE Date";
        }
        if (!IsPostBack)
        {
            Edit_GeneralDetails();
        }

        txt_Jobno.Text = Jobno;
        txtSB_BE_No.Text = SB_BE_NO;

        txtSB_BE_Dt.Text = SB_BE_DATE;
        txtloc.Text = LOCATION;

    }

    [Serializable]
    public class GridRow
    {

        public string Headings { get; set; }
        public string Values { get; set; }
        public string Headings1 { get; set; }
        public string Values1 { get; set; }
        public string Headings2 { get; set; }
        public string Values2 { get; set; }
        public string Jobno { get; set; }
        public string User { get; set; }

        internal TextBox FindControl(string p)
        {
            throw new NotImplementedException();
        }
    }

    public void Edit_GeneralDetails()
    {
        if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
        {
            DataTable gridtable_retrive = new DataTable();
            ObjUBO.A1 = Jobno;
            //ObjUBO.A1 = "123456";

            ObjUBO.A52 = "SELECT_CON";
            if (TYPE == "BE")
            {
                ds = ST.BE_Status_tracking_Ins_up(ObjUBO);
            }
            else if (TYPE == "SB")
            {
                ds = ST.SB_Status_tracking_Ins_up(ObjUBO);
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable retriveTable = ds.Tables[0];
                DataTable vertical = null;
                int index = 0;
                gridtable_retrive = AppendToVerticalTab(ref retriveTable, ref vertical, ref index);
                gvdetails.DataSource = gridtable_retrive;
                gvdetails.DataBind();
            }
        }
    }

    [WebMethod(EnableSession = true)]
    public static string TrackBE_SB(string gridJson, string TYPE, string BE_SB_NO, string BE_SB_DATE, string LOCATION, string Jobno, string COMPANY_ID, string currentbranch, string currentuser)
    {
        DataTable verticalTable = null;
        string localKey = Jobno;
        bool driverIsClosed = false;
        string BE_SB_No = BE_SB_NO;
        DateTime date = DateTime.ParseExact(BE_SB_DATE.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        string formattedDate = date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
        string BE_SB_Date = formattedDate;
        int index = 0;
        string Location = LOCATION;
        string localCompanyId = COMPANY_ID;
        string localBranch = currentbranch;
        string localUser = currentuser;
        string localFinalMessage = "Tracking Status, please wait...";
        string rootPath = HttpContext.Current.Server.MapPath("~/Submission/");
        string fullPath = Path.Combine(rootPath, "BE_SB_STATUS", localCompanyId, localBranch, localUser, localKey);

        if (!Directory.Exists(fullPath))
        {
            Directory.CreateDirectory(fullPath);
        }
        string logDirectory = HttpContext.Current.Server.MapPath("~/logs");
        string logFile = Path.Combine(logDirectory, "Errorlog_BE_SB_" + localKey + ".log");

        Page currentPage = HttpContext.Current.Handler as Page;

        Thread backgroundThread = new Thread(() =>
        {
            SetProgress(localKey, 0, "Tracking Status, please wait...(10%)");
            string txt_icegate_No = "", txt_icegate_date = "", onclick = "", Grid_id = "", table_id = "";
            IWebDriver Driver = null;
            WebDriverWait Wait = null;
            try
            {
                SetProgress(localKey, 0, "Tracking Status, please wait...(15%)");
                string driverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin", "Debug");
                //var service = FirefoxDriverService.CreateDefaultService(driverPath);
                var service = ChromeDriverService.CreateDefaultService(driverPath);
                service.HideCommandPromptWindow = true;
                var options = new ChromeOptions();
                //var options = new FirefoxOptions();
                //options.AddArgument("--start-maximized");// hidden for invisible
                options.AcceptInsecureCertificates = true;
                options.AddArgument("--headless");//included for hiding
                options.AddArgument("--window-size=1920,1080");//included for hiding
                //Driver = new FirefoxDriver(service, options);
                Driver = new ChromeDriver(service, options);
                Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
                SetProgress(localKey, 0, "Tracking Status, please wait...(17%)");
                if (TYPE == "SB")
                {
                    Driver.Navigate().GoToUrl("https://enquiry.icegate.gov.in/enquiryatices/sbTrack");
                    txt_icegate_No = "sbNO";
                    txt_icegate_date = "sbDATE";
                    onclick = "sbDetails();";
                }
                else if (TYPE == "BE")
                {
                    Driver.Navigate().GoToUrl("https://enquiry.icegate.gov.in/enquiryatices/beTrackIces");
                    txt_icegate_No = "beNO";
                    txt_icegate_date = "beDATE";
                    onclick = "beDetails();";
                }
                Wait.Until(d => d.FindElement(By.Id(txt_icegate_No)).Displayed);
                SetProgress(localKey, 0, "Tracking Status, please wait...(20%)");
                IWebElement locationDropdown = Driver.FindElement(By.Id("location"));
                SelectElement select = new SelectElement(locationDropdown);
                bool found = false;
                foreach (IWebElement option in select.Options)
                {
                    if (option.GetAttribute("value").Contains(Location))
                    {
                        select.SelectByValue(option.GetAttribute("value"));
                        found = true;
                        break;
                    }
                }

                Driver.FindElement(By.Id(txt_icegate_No)).SendKeys(BE_SB_No);

                SetProgress(localKey, 0, "Tracking Status, please wait...(25%)");
                ((IJavaScriptExecutor)Driver).ExecuteScript("document.getElementById('" + txt_icegate_date + "').value = '" + BE_SB_Date + "';");
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                SetProgress(localKey, 0, "Tracking Status, please wait...(30%)");
                bool captchaOk = Captcha_Extraction(ref Driver, ref Wait, ref fullPath, ref TYPE, ref localKey, ref BE_SB_Date, ref txt_icegate_date, maxAttempts: 3);
                if (!captchaOk)
                {


                    localFinalMessage = "Captcha solving failed.";

                }
                else if (Driver.PageSource.Contains("No Data Found for mentioned Bill Of Entry number,Bill Of Entry Date and Location. Please enter valid data"))
                {
                    localFinalMessage = "No Data Found for mentioned Bill Of Entry number,Bill Of Entry Date and Location. Please enter valid data";
                }

                else
                {
                    SetProgress(localKey, 0, "Tracking Status, please wait...(60%)");
                    verticalTable = Icegate_grid_fetch(ref Driver, ref Wait, ref fullPath, ref onclick, ref TYPE, ref localKey, ref Grid_id, ref index);
                    localFinalMessage = "Process Completed";
                    if (!verticalTable.Columns.Contains("Jobno"))
                        verticalTable.Columns.Add("Jobno", typeof(string));
                    if (!verticalTable.Columns.Contains("User"))
                        verticalTable.Columns.Add("User", typeof(string));


                    foreach (DataRow row in verticalTable.Rows)
                    {
                        row["Jobno"] = localKey;
                        row["User"] = currentuser;
                    }
                    gridStore[localKey] = verticalTable;
                    SetProgress(localKey, 0, "Tracking Status, please wait...(90%)");

                }
                finalMessageStore[localKey] = localFinalMessage;

            }
            catch (Exception ex)
            {
                try { File.AppendAllText(logFile, DateTime.Now + " - GenerateIRN error: " + ex.ToString() + Environment.NewLine); }
                catch { }
                localFinalMessage = "Error: " + ex.Message;
            }
            finally
            {
                if (Driver != null)
                {
                    try
                    {
                        Driver.Quit();
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText(logFile, DateTime.Now + " - Driver quit error: " + ex + Environment.NewLine);
                    }
                    finally
                    {
                        Driver = null;
                    }
                }

                SetProgress(localKey, 100, localFinalMessage == "Tracking Status, please wait...(100%)" ? "Process Completed..." : localFinalMessage);
            }

        });

        backgroundThread.IsBackground = true;
        backgroundThread.Start();
        return localFinalMessage;
    }
    private static bool Captcha_Extraction_old(ref IWebDriver driver, ref WebDriverWait wait, ref string fullPath, ref string type, ref string jobno, ref string BE_SB_Date, ref string txt_icegate_date, int maxAttempts = 5)
    {
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                // 1. Locate captcha image
                IWebElement captchaImg = wait.Until(d => d.FindElement(By.Id("capimg")));

                // 2. Capture screenshot
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                using (MemoryStream ms = new MemoryStream(screenshot.AsByteArray))
                using (Bitmap fullImage = new Bitmap(ms))
                {
                    Point location = captchaImg.Location;
                    Size size = captchaImg.Size;

                    Rectangle cropArea = new Rectangle(location.X, location.Y, size.Width, size.Height);
                    using (Bitmap captchaOnly = fullImage.Clone(cropArea, fullImage.PixelFormat))
                    using (MemoryStream captchaMs = new MemoryStream())
                    {
                        captchaOnly.Save(captchaMs, ImageFormat.Jpeg);

                        byte[] captchaBytes = captchaMs.ToArray();
                        string base64Captcha = Convert.ToBase64String(captchaBytes);

                        SetProgress(jobno, 0, "Tracking Status, please wait...(40%)");

                        // 3. Prepare and send POST request
                        string url = "https://dev-doit.pmdgtech.com/read-captcha";
                        string postData = "{\"TransType\":\"" + type + "\",\"TransNo\":\"" + jobno + "\",\"Captcha\":\"" + base64Captcha + "\"}";

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        request.Method = "POST";
                        request.ContentType = "application/json";
                        request.Accept = "application/json";

                        using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                        {
                            sw.Write(postData);
                            sw.Flush();
                        }

                        string responseString = null;
                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        {
                            responseString = sr.ReadToEnd();
                        }
                        SetProgress(jobno, 0, "Tracking Status, please wait...(50%)");
                        // 4. Deserialize response
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        CaptchaResponse result = null;

                        try
                        {
                            result = js.Deserialize<CaptchaResponse>(responseString);
                        }
                        catch
                        {
                            try
                            {
                                Dictionary<string, object> dict = js.DeserializeObject(responseString) as Dictionary<string, object>;
                                if (dict != null && dict.ContainsKey("Responses"))
                                {
                                    object[] arr = dict["Responses"] as object[];
                                    if (arr != null)
                                    {
                                        result = new CaptchaResponse { Responses = arr.Select(o => o.ToString()).ToList() };
                                    }
                                }
                            }
                            catch { }
                        }

                        SetProgress(jobno, 0, "Tracking Status, please wait...(60%)");

                        if (result != null && result.Responses != null)
                        {
                            string captchaText = result.Responses.FirstOrDefault();
                            if (!string.IsNullOrEmpty(captchaText))
                            {
                                // 5. Fill and submit form
                                IWebElement captchaBox = driver.FindElement(By.Id("captchaResp"));
                                captchaBox.Clear();
                                captchaBox.SendKeys(captchaText);

                                ((IJavaScriptExecutor)driver).ExecuteScript(
                                    "document.getElementById('" + txt_icegate_date + "').value = '" + BE_SB_Date + "';"
                                );

                                driver.FindElement(By.Id("SubB")).Click();

                                SetProgress(jobno, 0, "Tracking Status, please wait...(80%)");
                                Thread.Sleep(1000);

                                if (!IsCaptchaInvalid(driver))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                // Silent retry
            }
        }

        return false;
    }

    private static bool IsCaptchaInvalid_old(IWebDriver driver)
    {
        try
        {
            // check page for known error message or element - adjust as necessary
            return driver.PageSource.Contains("Invalid Code! Please try again!") || driver.PageSource.Contains("Invalid Captcha");
        }
        catch
        {
            return true;
        }
    }



    private static bool Captcha_Extraction(ref IWebDriver driver, ref WebDriverWait wait, ref string fullPath, ref string type, ref string jobno, ref string BE_SB_Date, ref string txt_icegate_date,
       int maxAttempts = 3)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Random rnd = new Random();

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                // 1. Locate captcha image
                IWebElement captchaImg = wait.Until(d => d.FindElement(By.Id("capimg")));

                // 2. Capture captcha only (fallback: crop from screenshot if direct not available)
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                using (var ms = new MemoryStream(screenshot.AsByteArray))
                using (var fullImage = new Bitmap(ms))
                {
                    Point location = captchaImg.Location;
                    Size size = captchaImg.Size;

                    Rectangle cropArea = new Rectangle(location.X, location.Y, size.Width, size.Height);
                    using (Bitmap captchaOnly = fullImage.Clone(cropArea, fullImage.PixelFormat))
                    using (MemoryStream captchaMs = new MemoryStream())
                    {
                        captchaOnly.Save(captchaMs, ImageFormat.Jpeg);
                        string base64Captcha = Convert.ToBase64String(captchaMs.ToArray());

                        SetProgress(jobno, 0, "Tracking Status, please wait...(40%)");

                        // 3. Prepare and send POST request
                        string url = "https://dev-doit.pmdgtech.com/read-captcha";
                        string postData = js.Serialize(new
                        {
                            TransType = type,
                            TransNo = jobno,
                            Captcha = base64Captcha
                        });


                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        request.Method = "POST";
                        request.ContentType = "application/json";
                        request.Accept = "application/json";
                        request.KeepAlive = true;
                        request.Timeout = 10000; // 10 seconds

                        using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                        {
                            sw.Write(postData);
                            sw.Flush();
                        }

                        string responseString;
                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        {
                            responseString = sr.ReadToEnd();
                        }

                        SetProgress(jobno, 0, "Tracking Status, please wait...(50%)");

                        // 4. Deserialize response
                        CaptchaResponse result = null;
                        try
                        {
                            result = js.Deserialize<CaptchaResponse>(responseString);
                        }
                        catch
                        {
                            try
                            {
                                Dictionary<string, object> dict = js.DeserializeObject(responseString) as Dictionary<string, object>;
                                if (dict != null && dict.ContainsKey("Responses"))
                                {
                                    object[] arr = dict["Responses"] as object[];
                                    if (arr != null)
                                    {
                                        result = new CaptchaResponse
                                        {
                                            Responses = arr.Select(o => o.ToString()).ToList()
                                        };
                                    }
                                }
                            }
                            catch { }
                        }

                        SetProgress(jobno, 0, "Tracking Status, please wait...(60%)");

                        if (result != null && result.Responses != null)
                        {
                            string captchaText = result.Responses.FirstOrDefault();
                            if (!string.IsNullOrEmpty(captchaText))
                            {
                                // 5. Fill and submit form
                                IWebElement captchaBox = driver.FindElement(By.Id("captchaResp"));
                                captchaBox.Clear();
                                captchaBox.SendKeys(captchaText);

                                ((IJavaScriptExecutor)driver).ExecuteScript(
                                    "document.getElementById('" + txt_icegate_date + "').value = '" + BE_SB_Date + "';"
                                );

                                driver.FindElement(By.Id("SubB")).Click();

                                SetProgress(jobno, 0, "Tracking Status, please wait...(80%)");

                                try
                                {
                                    // Use WebDriverWait instead of Thread.Sleep
                                    new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                                        .Until(d => !IsCaptchaInvalid(d));
                                }
                                catch { }

                                if (!IsCaptchaInvalid(driver))
                                {
                                    return true;
                                }

                                // Refresh captcha before next attempt if available
                                try
                                {
                                    driver.FindElement(By.Id("refreshCaptcha")).Click();
                                    Thread.Sleep(500);
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                SetProgress(jobno, 0, "Captcha attempt " + attempt + " failed: " + ex.Message);
            }

            // Small random delay between retries to avoid server suspicion
            Thread.Sleep(rnd.Next(1000, 3000));
        }

        return false;
    }

    private static bool IsCaptchaInvalid(IWebDriver driver)
    {
        try
        {
            // Prefer checking elements over full PageSource scan
            return driver.PageSource.Contains("Invalid Code! Please try again!") ||
                   driver.PageSource.Contains("Invalid Captcha");
        }
        catch
        {
            return true;
        }
    }

    private static void ClickAndWait(IWebDriver driver, WebDriverWait wait, string xpath, string gridId)
    {
        // Wait until element is present, displayed, and enabled
        IWebElement clickableElement = wait.Until(d =>
        {
            try
            {
                var element = d.FindElement(By.XPath(xpath));
                if (element != null && element.Displayed && element.Enabled)
                    return element;
                return null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        });

        // Click once it's ready
        clickableElement.Click();

        // Wait until the grid/table appears
        wait.Until(d =>
        {
            try
            {
                var grid = d.FindElement(By.Id(gridId));
                return (grid != null && grid.Displayed) ? grid : null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        });
    }
    private static DataTable Icegate_grid_fetch(ref IWebDriver driver, ref WebDriverWait wait, ref string fullPath, ref string onclick, ref string TYPE, ref string localKey, ref string Grid_id, ref int index)
    {
        DataTable verticalTable = null;

        try
        {
            if (TYPE == "SB")
            {
                driver.FindElement(By.XPath("//a[@onclick='sbDetails();']")).Click();
                Thread.Sleep(500);
                Grid_id = "sbICES_Details";
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(85%)");
                driver.FindElement(By.XPath("//a[@onclick='showItemWiseRewardDetails();']")).Click();
                Thread.Sleep(500);
                Grid_id = "itemWiseRewardTdId";
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(86%)");
                driver.FindElement(By.XPath("//a[@onclick='currentStatus();']")).Click();
                Thread.Sleep(500);
                Grid_id = "sbICES_CurrStus";
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(87%)");
                driver.FindElement(By.XPath("//a[@onclick='egmStatus();']")).Click();
                Thread.Sleep(500);
                Grid_id = "sbICES_EgmStus";
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(88%)");
                driver.FindElement(By.XPath("//a[@onclick='dbkQueryDetail();']")).Click();
                Thread.Sleep(500);
                Grid_id = "sbICES_DBKqurydtls";
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(89%)");
                driver.FindElement(By.XPath("//a[@onclick='roslStatusDetail();']")).Click();
                Thread.Sleep(500);
                Grid_id = "roslStautsId";
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                driver.FindElement(By.XPath("//a[@onclick='sbDutyDetails();']")).Click();
                Thread.Sleep(500);
                Grid_id = "sbICESDuty";
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
            }
            else // BE
            {
                driver.FindElement(By.XPath("//a[@onclick='beDetails();']")).Click();
                Thread.Sleep(500);
                Grid_id = "beICES_Details";
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(85%)");
                driver.FindElement(By.XPath("//a[@onclick='currentStatus();']")).Click();
                Thread.Sleep(500);
                Grid_id = "beICES_CurrStus";
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(87%)");
                driver.FindElement(By.XPath("//a[@onclick='dutyDetails();']")).Click();
                Thread.Sleep(500);
                Grid_id = "beICES_Duty";
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(88%)");
                driver.FindElement(By.XPath("//a[@onclick='otherAgencyDt();']")).Click();
                Thread.Sleep(500);
                Grid_id = "beIces_gov";
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(89%)");
            }
        }
        catch (Exception ex)
        {
            try { File.AppendAllText(Path.Combine(Path.GetTempPath(), "icegate_error.log"), ex.ToString() + Environment.NewLine); }
            catch { }
        }

        return verticalTable;
    }
    private static DataTable Icegate_grid_fetch_new(ref IWebDriver driver, ref WebDriverWait wait, ref string fullPath, ref string onclick, ref string TYPE, ref string localKey, ref string Grid_id, ref int index)
    {
        DataTable verticalTable = null;

        try
        {
            if (TYPE == "SB")
            {
                Grid_id = "sbICES_Details";
                ClickAndWait(driver, wait, "//a[@onclick='sbDetails();']", "sbICES_Details");
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(85%)");
                Thread.Sleep(500);
                Grid_id = "itemWiseRewardTdId";
                ClickAndWait(driver, wait, "//a[@onclick='showItemWiseRewardDetails();']", "itemWiseRewardTdId");
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(86%)");
                Thread.Sleep(500);
                Grid_id = "sbICES_CurrStus";
                ClickAndWait(driver, wait, "//a[@onclick='currentStatus();']", "sbICES_CurrStus");
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(87%)");
                Thread.Sleep(500);

                Grid_id = "sbICES_EgmStus";
                ClickAndWait(driver, wait, "//a[@onclick='egmStatus();']", "sbICES_EgmStus");
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(88%)");
                Thread.Sleep(500);
                Grid_id = "sbICES_DBKqurydtls";
                ClickAndWait(driver, wait, "//a[@onclick='dbkQueryDetail();']", "sbICES_DBKqurydtls");
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(89%)");
                Thread.Sleep(500);
                Grid_id = "roslStautsId";
                ClickAndWait(driver, wait, "//a[@onclick='roslStatusDetail();']", "roslStautsId");
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                Thread.Sleep(500);
                Grid_id = "sbICESDuty";
                ClickAndWait(driver, wait, "//a[@onclick='sbDutyDetails();']", "sbICESDuty");
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
            }
            else // BE
            {
                Grid_id = "beICES_Details";
                ClickAndWait(driver, wait, "//a[@onclick='beDetails();']", "beICES_Details");
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);

                SetProgress(localKey, 0, "Tracking Status, please wait...(85%)");
                Thread.Sleep(500);
                Grid_id = "beICES_CurrStus";
                ClickAndWait(driver, wait, "//a[@onclick='currentStatus();']", "beICES_CurrStus");
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(87%)");

                Thread.Sleep(500);
                Grid_id = "beICES_Duty";
                ClickAndWait(driver, wait, "//a[@onclick='dutyDetails();']", "beICES_Duty");
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(88%)");
                Thread.Sleep(500);
                Grid_id = "beIces_gov";
                ClickAndWait(driver, wait, "//a[@onclick='otherAgencyDt();']", "beIces_gov");
                verticalTable = ExtractSBDetailsTable(ref driver, ref Grid_id, ref verticalTable, ref localKey, ref index);
                SetProgress(localKey, 0, "Tracking Status, please wait...(89%)");
            }
        }
        catch (Exception ex)
        {
            try { File.AppendAllText(Path.Combine(Path.GetTempPath(), "icegate_error.log"), ex.ToString() + Environment.NewLine); }
            catch { }
        }

        return verticalTable;
    }
    private static DataTable ExtractSBDetailsTable(ref IWebDriver driver, ref string table_id, ref DataTable verticalTable, ref string localKey, ref int index)
    {
        try
        {

            if (verticalTable == null)
            {
                verticalTable = new DataTable();
            }

            IWebElement mainTable = driver.FindElement(By.XPath("//div[@id='" + table_id + "']//table"));
            var allRows = mainTable.FindElements(By.XPath(".//tr"));

            List<string> headers = new List<string>();
            List<string> rowValues = new List<string>();

            foreach (var row in allRows)
            {
                var ths = row.FindElements(By.TagName("th"));
                if (ths.Count > 0)
                {
                    foreach (var th in ths)
                    {
                        string col = th.Text.Trim();
                        if (!string.IsNullOrEmpty(col))
                            headers.Add(col);
                    }
                }

                var tds = row.FindElements(By.TagName("td"));
                if (tds.Count > 0)
                {
                    foreach (var td in tds)
                    {
                        rowValues.Add(td.Text.Trim());
                    }
                }
            }

            DataTable newTable = new DataTable();

            foreach (var h in headers)
            {
                string uniqueColName = GetUniqueColumnName(verticalTable, h);
                newTable.Columns.Add(uniqueColName);
            }

            if (rowValues.Count > 0)
            {
                DataRow dr = newTable.NewRow();
                for (int i = 0; i < rowValues.Count && i < newTable.Columns.Count; i++)
                {
                    dr[i] = rowValues[i];
                }
                newTable.Rows.Add(dr);
            }

            verticalTable = AppendSideBySide(verticalTable, newTable);
        }
        catch
        {
            // Log or ignore exception safely
        }

        return verticalTable;
    }

    private static DataTable AppendSideBySide(DataTable mainTable, DataTable newTable)
    {
        if (mainTable == null || mainTable.Columns.Count == 0)
        {
            return newTable.Copy();
        }

        // Clone the existing table structure
        DataTable mergedTable = mainTable.Clone();

        // Add columns from new table
        foreach (DataColumn col in newTable.Columns)
        {
            string colName = GetUniqueColumnName(mergedTable, col.ColumnName);
            mergedTable.Columns.Add(colName);
        }

        // Ensure we have a single row to merge; create one if needed
        DataRow mergedRow = mergedTable.NewRow();

        // Copy existing values
        if (mainTable.Rows.Count > 0)
        {
            for (int i = 0; i < mainTable.Columns.Count; i++)
            {
                mergedRow[i] = mainTable.Rows[0][i];
            }
        }

        // Copy new values
        if (newTable.Rows.Count > 0)
        {
            int offset = mainTable.Columns.Count;
            for (int i = 0; i < newTable.Columns.Count; i++)
            {
                mergedRow[offset + i] = newTable.Rows[0][i];
            }
        }

        mergedTable.Rows.Add(mergedRow);
        return mergedTable;
    }
    private static string GetUniqueColumnName(DataTable table, string baseName)
    {
        string name = baseName;
        int counter = 1;

        while (table.Columns.Contains(name))
        {
            name = baseName + "_" + counter++;
        }

        return name;
    }
    [WebMethod(EnableSession = true)]
    public static string GetBE_SBStatus(string Jobno)
    {
        string status = BE_SB_GridStore.Status.ContainsKey(Jobno) ? BE_SB_GridStore.Status[Jobno] : "NotFound";
        DataTable result = BE_SB_GridStore.Results.ContainsKey(Jobno) ? BE_SB_GridStore.Results[Jobno] : null;

        var responseObj = new
        {
            Status = status,
            Data = result
        };

        JavaScriptSerializer serializer = new JavaScriptSerializer();
        serializer.MaxJsonLength = Int32.MaxValue;
        return serializer.Serialize(responseObj);
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Enabled = true;
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";


        }
    }
    [WebMethod(EnableSession = true)]
    public static object GetAutomationProgress(string key)
    {
        lock (progressStore)
        {
            if (progressStore.ContainsKey(key))
            {
                return progressStore[key];
            }
            else
            {
                return new { Percent = 100, Message = "Connection Lost..." };
            }
        }
    }
    private static void SetProgress(string key, int percent, string message)
    {
        lock (progressStore)
        {
            progressStore[key] = new ProgressData { Percent = percent, Message = message };
        }
    }


    private class ProgressData
    {
        public int Percent { get; set; }
        public string Message { get; set; }
    }

    public static class BE_SB_GridStore
    {
        public static ConcurrentDictionary<string, string> Status = new ConcurrentDictionary<string, string>();
        public static ConcurrentDictionary<string, DataTable> Results = new ConcurrentDictionary<string, DataTable>();
    }
    public class CaptchaResponse
    {
        public List<string> Responses { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string TransNo { get; set; }
        public string TransType { get; set; }
    }
    public void Alert_msg(string msg)
    {

        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg.Replace("<br>", "\\n") + "');", true);

    }

    protected void btnBindGrid_Click(object sender, EventArgs e)
    {
        DataSet dss = new DataSet();
        DataTable GlobalGridTable;

        if (gridStore.TryGetValue(txt_Jobno.Text, out GlobalGridTable))
        {
            if (GlobalGridTable != null && GlobalGridTable.Rows.Count > 0)
            {
                string jobNo = GlobalGridTable.Rows[0]["Jobno"].ToString();
                string user = GlobalGridTable.Rows[0]["User"].ToString();

                if (jobNo == txt_Jobno.Text && user == currentuser)
                {

                    DataSet dsGrid = new DataSet();
                    dsGrid.Tables.Add(GlobalGridTable.Copy());
                    dss = insert_update("S", dsGrid);

                    gvdetails.DataSource = dss;
                    gvdetails.DataBind();

                    ViewState["stored_table"] = GlobalGridTable;

                    lock (progressStore)
                    {
                        if (progressStore.ContainsKey(jobNo))
                            progressStore.Remove(jobNo);
                    }

                    DataTable removedTable;
                    gridStore.TryGetValue(jobNo, out removedTable); // or TryRemove if ConcurrentDictionary

                   
                   

                    string baseFolderPath = HttpContext.Current.Server.MapPath("~/Submission/BE_SB_STATUS/" + COMPANY_ID + "/" + currentbranch);
                    string userFolderPath = Path.Combine(baseFolderPath, currentuser);
                    string jobFolderPath = Path.Combine(userFolderPath, txt_Jobno.Text);

                    if (Directory.Exists(jobFolderPath))
                    {
                        Directory.Delete(jobFolderPath, true);
                    }


                }
            }
        }
        string msg;
        finalMessageStore.TryGetValue(txt_Jobno.Text, out msg);
        if (msg == "No Data Found for mentioned Bill Of Entry number,Bill Of Entry Date and Location. Please enter valid data")
        {
            Alert_msg("No Data Found for mentioned Bill Of Entry number,Bill Of Entry Date and Location. Please enter valid data");
        }
        else
        {
            Alert_msg("Process Completed");
        }
    }



    private string GetSafeValue(DataRow row, string columnName)
    {
        if (row == null || row.Table == null || !row.Table.Columns.Contains(columnName))
            return string.Empty;

        var value = row[columnName];
        return value == DBNull.Value ? string.Empty : value.ToString().Trim();
    }

    private void MapRowToUBO(DataRow row, object target, Dictionary<string, string> columnMappings)
    {
        var type = target.GetType();

        foreach (var mapping in columnMappings)
        {
            var property = type.GetProperty(mapping.Key);
            if (property != null && property.CanWrite)
            {
                var safeValue = GetSafeValue(row, mapping.Value);
                property.SetValue(target, safeValue, null);
            }
        }
    }
    public DataSet insert_update(string Flag, DataSet dsGrid)
    {
        DataTable gridtable = new DataTable();
        ObjUBO.A1 = txt_Jobno.Text;
        ObjUBO.A2 = txt_Jobno.Text;
        ObjUBO.A3 = txtloc.Text;
        ObjUBO.A4 = txtSB_BE_No.Text;
        ObjUBO.A5 = txtSB_BE_Dt.Text;



        if (TYPE == "BE")
        {


            var columnMappings = new Dictionary<string, string>
{
    { "A6", "IEC" },
    { "A7", "TOT VAL" },
    { "A8", "TYP" },
    { "A9", "CHA Number" },
    { "A10", "FIRST CHECK" },
    { "A11", "PRIOR BE" },
    { "A12", "SEC48" },
    { "A13", "APPRAISING GROUP" },
    { "A14", "TOTAL ASSESSABLE VALUE" },
    { "A15", "TOTAL PACKAGE" },
    { "A16", "GROSS WEIGHT (Kg)" },
    { "A17", "TOTAL DUTY (INR)" },
    { "A18", "FINE PENALTY (INR)" },
    { "A19", "WBE No." },
    { "A20", "APPRAISEMENT" },
    { "A21", "CURRENT QUEUE" },
    { "A22", "NO OF QUERY RAISED" },
    { "A23", "NO OF QUERY REPLIED" },
    { "A24", "REPLY DATE" },
    { "A25", "REPLY STATUS" },
    { "A26", "APPR DATE" },
    { "A27", "ASSESS DATE" },
    { "A28", "PAYMENT DATE" },
    { "A29", "EXAM DATE" },
    { "A30", "OOC DATE" },
    { "A31", "CHALLAN No." },
    { "A32", "DUTY AMOUNT (INR)" },
    { "A33", "FINE AMOUNT (INR)" },
    { "A34", "INTEREST AMOUNT (INR)" },
    { "A35", "PENAL AMOUNT (INR)" },
    { "A36", "DUTY PAID (INR)" },
    { "A37", "MODE OF PAYMENT"}};
            ObjUBO.A38 = JOBDATE;
            ObjUBO.A52 = Flag;

            if (dsGrid.Tables.Count > 0 && dsGrid.Tables[0].Rows.Count > 0)
            {
                var row = dsGrid.Tables[0].Rows[0];
                MapRowToUBO(row, ObjUBO, columnMappings);
            }


            ds = ST.BE_Status_tracking_Ins_up(ObjUBO);



        }
        else if (TYPE == "SB")
        {




            var columnMappings = new Dictionary<string, string>
{
    { "A6", "IEC" },
    { "A7", "CHA No." },
    { "A8", "TYP" },
    { "A9", "Total Package" },
    { "A10", "Gross Weight (Kg)" },
    { "A11", "FOB(INR)" },
    { "A12", "Total Cess (INR)" },
    { "A13", "Drawback" },
    { "A14", "STR" },
    { "A15", "Total (DBK+STR)" },
    { "A16", "CIN NO." },
    { "A17", "CIN DT." },
    { "A18", "Invoice Number" },
    { "A19", "Item Number" },
      {"A20","Reward Flag" },
            {"A21" ,"Current Que" },
            {"A22" ,"LEO Date" },
            {"A23","EP Copy Print Status" },
            {"A24","DBK Scroll No" },
            {"A25","Scroll Date" },
            {"A26","EGM Integration Status" },
            {"A27","EGM No." },
            {"A28","EGM Date" },
            {"A29","Container No." },
            {"A30","Seal No." },
            {"A31","Error Message" },
            {"A32","Query No." },
            {"A33","Query Date" },
            {"A34","Query Text" },
            {"A35","Pending With" },
            {"A36","Officer Name" },
            {"A37","Reply Date" },
            {"A38","ROSL Availed" },

            {"A39","Amount(INR)" },
            {"A40","Scroll Number" },
            {"A41","Scroll Date_1" },
            {"A42","CHALLAN No." },
            {"A43","DUTY AMOUNT (INR)" },
            {"A44","CESS AMOUNT(INR)" },
            {"A45","TOTAL DUTY (INR)" },
            {"A46","DUTY PAID (INR)" },
            {"A47","MODE OF PAYMENT" }};
            ObjUBO.A48 = JOBDATE;
            ObjUBO.A52 = Flag;

            if (dsGrid.Tables.Count > 0 && dsGrid.Tables[0].Rows.Count > 0)
            {
                var row = dsGrid.Tables[0].Rows[0];
                MapRowToUBO(row, ObjUBO, columnMappings);
            }

            ds = ST.SB_Status_tracking_Ins_up(ObjUBO);

        }
        // Convert to vertical table
        DataTable originalTable = ds.Tables[0];
        DataTable verticalTab = null;
        int index = 0;
        gridtable = AppendToVerticalTab(ref originalTable, ref verticalTab, ref index);

        DataSet result = new DataSet();
        result.Tables.Add(gridtable.Copy());
        return result;
    }

    public DataSet insert_update_old(string Flag, DataSet dsGrid)
    {
        DataTable gridtable = new DataTable();
        ObjUBO.A1 = txt_Jobno.Text;
        ObjUBO.A2 = txt_Jobno.Text;
        ObjUBO.A3 = txtloc.Text;
        ObjUBO.A4 = txtSB_BE_No.Text;
        ObjUBO.A5 = txtSB_BE_Dt.Text;



        if (TYPE == "BE")
        {
            ObjUBO.A6 = dsGrid.Tables[0].Rows[0]["IEC"].ToString();
            ObjUBO.A7 = dsGrid.Tables[0].Rows[0]["TOT VAL"].ToString();
            ObjUBO.A8 = dsGrid.Tables[0].Rows[0]["TYP"].ToString();
            ObjUBO.A9 = dsGrid.Tables[0].Rows[0]["CHA Number"].ToString();
            ObjUBO.A10 = dsGrid.Tables[0].Rows[0]["FIRST CHECK"].ToString();
            ObjUBO.A11 = dsGrid.Tables[0].Rows[0]["PRIOR BE"].ToString();
            ObjUBO.A12 = dsGrid.Tables[0].Rows[0]["SEC48"].ToString();
            ObjUBO.A13 = dsGrid.Tables[0].Rows[0]["APPRAISING GROUP"].ToString();
            ObjUBO.A14 = dsGrid.Tables[0].Rows[0]["TOTAL ASSESSABLE VALUE"].ToString();
            ObjUBO.A15 = dsGrid.Tables[0].Rows[0]["TOTAL PACKAGE"].ToString();
            ObjUBO.A16 = dsGrid.Tables[0].Rows[0]["GROSS WEIGHT (Kg)"].ToString();
            ObjUBO.A17 = dsGrid.Tables[0].Rows[0]["TOTAL DUTY (INR)"].ToString();
            ObjUBO.A18 = dsGrid.Tables[0].Rows[0]["FINE PENALTY (INR)"].ToString();
            ObjUBO.A19 = dsGrid.Tables[0].Rows[0]["WBE No."].ToString();
            ObjUBO.A20 = dsGrid.Tables[0].Rows[0]["APPRAISEMENT"].ToString();
            ObjUBO.A21 = dsGrid.Tables[0].Rows[0]["CURRENT QUEUE"].ToString();
            ObjUBO.A22 = dsGrid.Tables[0].Rows[0]["NO OF QUERY RAISED"].ToString();
            ObjUBO.A23 = dsGrid.Tables[0].Rows[0]["NO OF QUERY REPLIED"].ToString();
            ObjUBO.A24 = dsGrid.Tables[0].Rows[0]["REPLY DATE"].ToString();
            ObjUBO.A25 = dsGrid.Tables[0].Rows[0]["REPLY STATUS"].ToString();
            ObjUBO.A26 = dsGrid.Tables[0].Rows[0]["APPR DATE"].ToString();
            ObjUBO.A27 = dsGrid.Tables[0].Rows[0]["ASSESS DATE"].ToString();
            ObjUBO.A28 = dsGrid.Tables[0].Rows[0]["PAYMENT DATE"].ToString();
            ObjUBO.A29 = dsGrid.Tables[0].Rows[0]["EXAM DATE"].ToString();
            ObjUBO.A30 = dsGrid.Tables[0].Rows[0]["OOC DATE"].ToString();
            ObjUBO.A31 = dsGrid.Tables[0].Rows[0]["CHALLAN No."].ToString();
            ObjUBO.A32 = dsGrid.Tables[0].Rows[0]["DUTY AMOUNT (INR)"].ToString();
            ObjUBO.A33 = dsGrid.Tables[0].Rows[0]["FINE AMOUNT (INR)"].ToString();
            ObjUBO.A34 = dsGrid.Tables[0].Rows[0]["INTEREST AMOUNT (INR)"].ToString();
            ObjUBO.A35 = dsGrid.Tables[0].Rows[0]["PENAL AMOUNT (INR)"].ToString();
            ObjUBO.A36 = dsGrid.Tables[0].Rows[0]["DUTY PAID (INR)"].ToString();
            ObjUBO.A37 = dsGrid.Tables[0].Rows[0]["MODE OF PAYMENT"].ToString();
            ObjUBO.A38 = JOBDATE;
            ObjUBO.A52 = Flag;
            ds = ST.BE_Status_tracking_Ins_up(ObjUBO);



        }
        else if (TYPE == "SB")
        {
            ObjUBO.A6 = dsGrid.Tables[0].Rows[0]["IEC"].ToString();
            ObjUBO.A7 = dsGrid.Tables[0].Rows[0]["CHA No."].ToString();
            ObjUBO.A8 = dsGrid.Tables[0].Rows[0]["Port of Discharge"].ToString();
            ObjUBO.A9 = dsGrid.Tables[0].Rows[0]["Total Package"].ToString();
            ObjUBO.A10 = dsGrid.Tables[0].Rows[0]["Gross Weight (Kg)"].ToString();
            ObjUBO.A11 = dsGrid.Tables[0].Rows[0]["FOB(INR)"].ToString();
            ObjUBO.A12 = dsGrid.Tables[0].Rows[0]["Total Cess (INR)"].ToString();
            ObjUBO.A13 = dsGrid.Tables[0].Rows[0]["Drawback"].ToString();
            ObjUBO.A14 = dsGrid.Tables[0].Rows[0]["STR"].ToString();
            ObjUBO.A15 = dsGrid.Tables[0].Rows[0]["Total (DBK+STR)"].ToString();
            ObjUBO.A16 = dsGrid.Tables[0].Rows[0]["CIN NO."].ToString();
            ObjUBO.A17 = dsGrid.Tables[0].Rows[0]["CIN DT."].ToString();
            ObjUBO.A18 = dsGrid.Tables[0].Rows[0]["Invoice Number"].ToString();
            ObjUBO.A19 = dsGrid.Tables[0].Rows[0]["Item Number"].ToString();
            ObjUBO.A20 = dsGrid.Tables[0].Rows[0]["Reward Flag"].ToString();
            ObjUBO.A21 = dsGrid.Tables[0].Rows[0]["Current Que"].ToString();
            ObjUBO.A22 = dsGrid.Tables[0].Rows[0]["LEO Date"].ToString();
            ObjUBO.A23 = dsGrid.Tables[0].Rows[0]["EP Copy Print Status"].ToString();
            ObjUBO.A24 = dsGrid.Tables[0].Rows[0]["DBK Scroll No"].ToString();
            ObjUBO.A25 = dsGrid.Tables[0].Rows[0]["Scroll Date"].ToString();
            ObjUBO.A26 = dsGrid.Tables[0].Rows[0]["EGM Integration Status"].ToString();
            ObjUBO.A27 = dsGrid.Tables[0].Rows[0]["EGM No."].ToString();
            ObjUBO.A28 = dsGrid.Tables[0].Rows[0]["EGM Date"].ToString();
            ObjUBO.A29 = dsGrid.Tables[0].Rows[0]["Container No."].ToString();
            ObjUBO.A30 = dsGrid.Tables[0].Rows[0]["Seal No."].ToString();
            ObjUBO.A31 = dsGrid.Tables[0].Rows[0]["Error Message"].ToString();
            ObjUBO.A32 = dsGrid.Tables[0].Rows[0]["Query No."].ToString();
            ObjUBO.A33 = dsGrid.Tables[0].Rows[0]["Query Date"].ToString();
            ObjUBO.A34 = dsGrid.Tables[0].Rows[0]["Query Text"].ToString();
            ObjUBO.A35 = dsGrid.Tables[0].Rows[0]["Pending With"].ToString();
            ObjUBO.A36 = dsGrid.Tables[0].Rows[0]["Officer Name"].ToString();
            ObjUBO.A37 = dsGrid.Tables[0].Rows[0]["Reply Date"].ToString();
            ObjUBO.A38 = dsGrid.Tables[0].Rows[0]["ROSL Availed"].ToString();

            ObjUBO.A39 = dsGrid.Tables[0].Rows[0]["Amount(INR)"].ToString();
            ObjUBO.A40 = dsGrid.Tables[0].Rows[0]["Scroll Number"].ToString();
            ObjUBO.A41 = dsGrid.Tables[0].Rows[0]["Scroll Date_1"].ToString();
            ObjUBO.A42 = dsGrid.Tables[0].Rows[0]["CHALLAN No."].ToString();
            ObjUBO.A43 = dsGrid.Tables[0].Rows[0]["DUTY AMOUNT (INR)"].ToString();
            ObjUBO.A44 = dsGrid.Tables[0].Rows[0]["CESS AMOUNT(INR)"].ToString();
            ObjUBO.A45 = dsGrid.Tables[0].Rows[0]["TOTAL DUTY (INR)"].ToString();
            ObjUBO.A46 = dsGrid.Tables[0].Rows[0]["DUTY PAID (INR)"].ToString();
            ObjUBO.A47 = dsGrid.Tables[0].Rows[0]["MODE OF PAYMENT"].ToString();
            ObjUBO.A48 = JOBDATE;
            ObjUBO.A52 = Flag;
            ds = ST.SB_Status_tracking_Ins_up(ObjUBO);

        }
        // Convert to vertical table
        DataTable originalTable = ds.Tables[0];
        DataTable verticalTab = null;
        int index = 0;
        gridtable = AppendToVerticalTab(ref originalTable, ref verticalTab, ref index);

        DataSet result = new DataSet();
        result.Tables.Add(gridtable.Copy());
        return result;
    }


    private DataTable AppendToVerticalTab(ref DataTable originalTable, ref DataTable verticalTab, ref int index)
    {
        if (verticalTab == null)
        {
            verticalTab = new DataTable();
            verticalTab.Columns.Add("Headings");
            verticalTab.Columns.Add("Values");
            verticalTab.Columns.Add("Headings1");
            verticalTab.Columns.Add("Values1");
            verticalTab.Columns.Add("Headings2");
            verticalTab.Columns.Add("Values2");
        }

        if (originalTable != null && originalTable.Columns.Count > 0 && originalTable.Rows.Count > 0)
        {
            DataRow dataRow = originalTable.Rows[0];


            foreach (DataColumn col in originalTable.Columns)
            {
                int setIndex = index / 20;
                int rowIndex = index % 20;

                while (verticalTab.Rows.Count <= rowIndex)
                {
                    verticalTab.Rows.Add(verticalTab.NewRow());
                }

                switch (setIndex)
                {
                    case 0:
                        verticalTab.Rows[rowIndex]["Headings"] = col.ColumnName;
                        verticalTab.Rows[rowIndex]["Values"] = dataRow[col];
                        break;
                    case 1:
                        verticalTab.Rows[rowIndex]["Headings1"] = col.ColumnName;
                        verticalTab.Rows[rowIndex]["Values1"] = dataRow[col];
                        break;
                    case 2:
                        verticalTab.Rows[rowIndex]["Headings2"] = col.ColumnName;
                        verticalTab.Rows[rowIndex]["Values2"] = dataRow[col];
                        break;
                    default:
                        // ignore extra columns beyond 3 sets
                        break;
                }

                index++;
            }
        }
        return verticalTab;
    }
}