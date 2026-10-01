using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using iTextSharp.text.pdf;
using BussinessObject;
using System.Collections.Concurrent;
using SeleniumExtras.WaitHelpers;

public partial class IRN_Autiomation_General : ThemeClass
{
    AppSession aps = new AppSession();
    DataSet ds = new DataSet();
    IRN_Automation IA = new IRN_Automation();
    Global_variables ObjUBO = new Global_variables();
    adminmaster Admin_mas = new adminmaster();
    Manipulation mo = new Manipulation();
    public static string currentuser, currentbranch, Working_Period, COMPANY_ID, Jobno, upload_doc = "";

    private static ConcurrentDictionary<string, List<GridRow>> gridStore = new ConcurrentDictionary<string, List<GridRow>>();
    private static ConcurrentDictionary<string, string> finalMessageStore = new ConcurrentDictionary<string, string>();



    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        COMPANY_ID = Session["COMPANY_ID"].ToString();
        hdn_saved.Value = "N";
        if (gv_Details.Rows.Count > 0)
        {
            hdn_Grid.Value = "Y";
        }
        else
        {
            hdn_Grid.Value = "N";

        }

        
        if (!Page.IsPostBack)
        {
            Load_Icegate_id();
            if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
            {
                txt_Jobno.Text = Request.QueryString["JOBID"].ToString();
                txt_Jobno.Enabled = false;
            }
            if (Request.QueryString["party"] != "" && Request.QueryString["party"] != null)
            {
                txtclient.Text = Request.QueryString["party"].ToString();
                txtclient.Enabled = false;
            }

        }
        Session["childIRNgrid"] = "";
    }
    public void Load_Icegate_id()
    {
        try
        {


            ddlIcegateId.Items.Clear();
            ObjUBO.A14 = "Loading_Icegate_id";
            ds = IA.Retrieve_Icegate_Login_setting_Details(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlIcegateId.DataSource = ds.Tables[0];
                ddlIcegateId.DataTextField = "ICEGATE_USER_NAME";
                ddlIcegateId.DataValueField = "ICEGATE_PWD";
                ddlIcegateId.DataBind();
            }
            ddlIcegateId.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
            ddlIcegateId.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {

        if (ddlIcegateId.SelectedValue != "")
        {
            string baseFolderPath = HttpContext.Current.Server.MapPath("~/Submission/IRN_Doc_Uploads/" + COMPANY_ID + "/" + currentbranch);
            string targetFolderPath = Path.Combine(baseFolderPath, currentuser, txt_Jobno.Text);
            if (upload_doc == "")
            {
                if (Directory.Exists(targetFolderPath))
                {
                    Directory.Delete(targetFolderPath, true);
                }
            }

            string folderPath = HttpContext.Current.Server.MapPath("~/Submission/IRN_Doc_Uploads/" + COMPANY_ID + "/" + currentbranch + "/" + currentuser + "/" + txt_Jobno.Text + "/");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }


            DataTable dt = ViewState["CurrentTable"] as DataTable;


            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add("DOC_FILE_NAME", typeof(string));
                dt.Columns.Add("IRN", typeof(string));
                dt.Columns.Add("DOC_TYPE", typeof(string));
                dt.Columns.Add("DOC_LEVEL", typeof(string));
                dt.Columns.Add("Jobno", typeof(string));
                dt.Columns.Add("User", typeof(string));
            }
            else
            {

                for (int i = 0; i < gv_Details.Rows.Count && i < dt.Rows.Count; i++)
                {
                    DropDownList ddlDocType = (DropDownList)gv_Details.Rows[i].FindControl("ddlDocType");
                    DropDownList ddlLevel = (DropDownList)gv_Details.Rows[i].FindControl("ddlLevel");
                    TextBox txtIRN = (TextBox)gv_Details.Rows[i].FindControl("txtIRNno");
                    TextBox txtJobno = (TextBox)gv_Details.Rows[i].FindControl("txtJobno");
                    TextBox txtUser = (TextBox)gv_Details.Rows[i].FindControl("txtUser");
                    if (ddlDocType != null)
                        dt.Rows[i]["DOC_TYPE"] = ddlDocType.SelectedItem.Text;

                    if (ddlLevel != null)
                        dt.Rows[i]["DOC_LEVEL"] = ddlLevel.SelectedValue;

                    if (txtIRN != null)
                        dt.Rows[i]["IRN"] = txtIRN.Text.Trim();
                    if (txtJobno != null)
                        dt.Rows[i]["Jobno"] = txtJobno.Text.Trim();
                    if (txtUser != null)
                        dt.Rows[i]["User"] = txtUser.Text.Trim();
                }
            }
            bool allSigned = true;
            string unsignedFiles = "";
            string largeFiles = "";
            string invalidFiles = "";
            string duplicateFiles = "";
            int tot_count_doc = Request.Files.Count;

            for (int i = 0; i < Request.Files.Count; i++)
            {
                if (i >= 40)
                {
                    break;
                }
                HttpPostedFile uploadedFile = Request.Files[i];
                if (uploadedFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(uploadedFile.FileName);
                    string fileExtension = Path.GetExtension(fileName).ToLower();
                    string filePath = Path.Combine(folderPath, fileName);
                    bool existsInGrid = dt.AsEnumerable().Any(r => string.Equals(r.Field<string>("DOC_FILE_NAME"), fileName, StringComparison.OrdinalIgnoreCase));

                    bool existsInFolder = File.Exists(filePath);

                    if (existsInGrid || existsInFolder)
                    {
                        duplicateFiles += fileName + ", ";
                        continue;
                    }
                    if (fileExtension != ".pdf")
                    {
                        invalidFiles += fileName + ", ";
                        continue;
                    }
                    if (uploadedFile.ContentLength > 1048576)
                    {
                        largeFiles += fileName + ", ";
                        continue;
                    }

                    uploadedFile.SaveAs(filePath);
                    if (HasDigitalSignature(filePath))
                    {
                        bool exists = dt.AsEnumerable().Any(r => r.Field<string>("DOC_FILE_NAME") == fileName);
                        if (!exists)
                        {
                            DataRow row = dt.NewRow();
                            row["DOC_FILE_NAME"] = fileName;
                            row["IRN"] = "";
                            row["DOC_TYPE"] = "";
                            row["DOC_LEVEL"] = "";
                            row["Jobno"] = txt_Jobno.Text;
                            row["User"] = currentuser;
                            dt.Rows.Add(row);
                        }

                    }
                    else
                    {
                        allSigned = false;
                        unsignedFiles += fileName + ", ";
                    }
                }
            }
            if (!string.IsNullOrEmpty(unsignedFiles))
            {
                unsignedFiles = unsignedFiles.TrimEnd(new char[] { ',', ' ' });
                string[] unsignedFileNames = unsignedFiles.Split(new string[] { ", " }, StringSplitOptions.None);
                foreach (string unsignedFile in unsignedFileNames)
                {
                    string unsignedFilePath = Path.Combine(folderPath, unsignedFile);
                    if (File.Exists(unsignedFilePath))
                    {
                        File.Delete(unsignedFilePath);
                    }
                }
            }

            gv_Details.DataSource = dt;
            gv_Details.DataBind();
            upload_doc = "uploaded";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownList ddlDocType = (DropDownList)gv_Details.Rows[i].FindControl("ddlDocType");

                    DropDownList ddlLevel = (DropDownList)gv_Details.Rows[i].FindControl("ddlLevel");

                    ddlDocType.SelectedItem.Text = dt.Rows[i]["DOC_TYPE"].ToString();
                    ddlLevel.SelectedValue = dt.Rows[i]["DOC_LEVEL"].ToString();

                }
            }
            ViewState["CurrentTable"] = dt;


            if (dt.Rows.Count > 0)
            {
                btnGenIRN.Visible = true;
                hdn_Grid.Value = "Y";
            }
            if (!allSigned || !string.IsNullOrEmpty(largeFiles) || !string.IsNullOrEmpty(invalidFiles) || !string.IsNullOrEmpty(duplicateFiles) || tot_count_doc > 40)
            {
                string alertMessage = "";
                if (!allSigned)
                {
                    unsignedFiles = unsignedFiles.TrimEnd(new char[] { ',', ' ' });
                    alertMessage += "(*) " + unsignedFiles + " does not contain digital signature.\n";
                }
                if (!string.IsNullOrEmpty(largeFiles))
                {
                    largeFiles = largeFiles.TrimEnd(new char[] { ',', ' ' });
                    alertMessage += "(*) " + largeFiles + " are larger than 1 MB.\n";
                }
                if (!string.IsNullOrEmpty(invalidFiles))
                {
                    invalidFiles = invalidFiles.TrimEnd(new char[] { ',', ' ' });
                    alertMessage += "(*) " + invalidFiles + " are not PDF files.\n";
                }
                if (!string.IsNullOrEmpty(duplicateFiles))
                {
                    alertMessage += "(*) " + duplicateFiles.TrimEnd(',', ' ') + " already exist and were skipped.\n";
                }
                if (tot_count_doc > 40)
                {
                    alertMessage += "(*) Only 40 signed PDF documents are allowed. Remaining files were skipped.\\n";
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + alertMessage.Replace("\n", "\\n") + "');", true);
            }




            if (Directory.Exists(folderPath))
            {
                bool hasFiles = false;
                string[] files = Directory.GetFiles(folderPath);
                hasFiles = files.Length > 0;
                if (hasFiles)
                {
                    hdn_path_check.Value = "true";
                }
            }

        }
        else
        {
            Alert_msg("Select ICEGATE USER ID");

        }
    }
    [Serializable]
    public class GridRow
    {

        public string DOC_FILE_NAME { get; set; }
        public string IRN { get; set; }
        public string DOC_TYPE { get; set; }
        public string DOC_LEVEL { get; set; }
        public string Jobno { get; set; }
        public string User { get; set; }

        internal TextBox FindControl(string p)
        {
            throw new NotImplementedException();
        }
    }
    //[WebMethod(EnableSession = true)]
    //public static string GenerateIRN(string icegateIdText, string icegateIdValue, string Jobno, string gridJson, string COMPANY_ID, string currentbranch, string currentuser)
    //{
    //    retry_count = 0;
    //    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    //    GlobalGridDetails = serializer.Deserialize<List<GridRow>>(gridJson);

    //    icegateId = icegateIdText;
    //    icegatepass = icegateIdValue;

    //    string key = Jobno;
    //    finalMessage = "Generating IRN, please wait...";
    //    string rootPath = HttpContext.Current.Server.MapPath("~/Submission/IRN_Doc_Uploads/");
    //    string fullPath = Path.Combine(rootPath, COMPANY_ID, currentbranch, currentuser, Jobno);
    //    string logDirectory =HttpContext.Current.Server.MapPath("~/logs");
    //    string logFile = Path.Combine(logDirectory, "Errorlog_IRN_" + Jobno + ".log");
    //    HttpContext context = HttpContext.Current;
    //    Thread backgroundThread = new Thread(() =>
    //    {
    //        try
    //        {
    //            SetProgress(key, 0, "Generating IRN, please wait...");
    //            string driverPath = context.Server.MapPath("~/Bin/Debug");


    //            var service = FirefoxDriverService.CreateDefaultService(driverPath);
    //            service.HideCommandPromptWindow = true; // Hide CMD window


    //            var options = new FirefoxOptions
    //            {
    //                AcceptInsecureCertificates = true
    //            };
    //            //options.AddArgument("--start-maximized"); // Maximize (note: may not work in headless mode)
    //            options.AddArgument("--headless");        // Run browser in background
    //            options.AddArgument("--window-size=1920,1080"); // Define window size (needed in headless)

    //            using (service)
    //            using (driver = new FirefoxDriver(service, options))
    //            {

    //                driverIsClosed = false;
    //                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

    //                SetProgress(key, 0, "Logging into ICEGATE...");
    //                LoginToIcegate(logFile,key, (HttpContext.Current.Handler as Page));

    //                if (string.IsNullOrEmpty(Error_msg))
    //                {
    //                    NavigateToDashboard(logFile,fullPath, key, (HttpContext.Current.Handler as Page));
    //                }

    //                if (string.IsNullOrEmpty(Error_msg))
    //                {
    //                    SetProgress(key, 0, "Collecting Documents details...");
    //                    UploadDocuments(logFile,current_step, fullPath, key, (HttpContext.Current.Handler as Page), GlobalGridDetails);
    //                }


    //            }
    //        }
    //        catch (Exception ex)
    //        {

    //        }
    //        finally
    //        {
    //            try
    //            {
    //                if (!string.IsNullOrEmpty(alert_message) || !string.IsNullOrEmpty(alert_retry))
    //                {
    //                    finalMessage = alert_retry + " " + alert_message;
    //                    finalMessage_alert = finalMessage;
    //                    alert_retry = "";
    //                    alert_message = "";
    //                }
    //            }
    //            catch { }

    //            LogoutAndQuitDriver(logFile);
    //            SetProgress(key, 100, finalMessage == "Generating IRN, please wait..." ? "Process Completed..." : finalMessage);
    //        }
    //    });
    //    backgroundThread.IsBackground = true;
    //    backgroundThread.Start();


    //    return finalMessage;
    //}
    [WebMethod(EnableSession = true)]
    public static string GenerateIRN(string icegateIdText, string icegateIdValue, string Jobno, string gridJson, string COMPANY_ID, string currentbranch, string currentuser)
    {
        int retry_count = 0, close_button = 1;

        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        var localGridDetails = serializer.Deserialize<List<GridRow>>(gridJson) ?? new List<GridRow>();
        gridStore[Jobno] = localGridDetails;

        // Copy variables to thread-local (non-static) variables
        string localKey = Jobno;
        bool driverIsClosed = false;
        string icegateId = icegateIdText;
        string icegatepass = icegateIdValue;
        string localCompanyId = COMPANY_ID;
        string localBranch = currentbranch;
        string localUser = currentuser;
        string current_step = "";
        string localFinalMessage = "Generating IRN, please wait...";
        string Error_msg = "", alert_message = "", alert_retry = "", logout = "";
        string rootPath = HttpContext.Current.Server.MapPath("~/Submission/IRN_Doc_Uploads/");
        string fullPath = Path.Combine(rootPath, localCompanyId, localBranch, localUser, localKey);
        string logDirectory = HttpContext.Current.Server.MapPath("~/logs");
        string logFile = Path.Combine(logDirectory, "Errorlog_IRN_" + localKey + ".log");

        Page currentPage = HttpContext.Current.Handler as Page;

        Thread backgroundThread = new Thread(() =>
        {
            IWebDriver Driver = null;
            WebDriverWait Wait = null;
            try
            {
                SetProgress(localKey, 0, "Generating IRN, please wait...");
                string driverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin", "Debug");
                var service = FirefoxDriverService.CreateDefaultService(driverPath);
                service.HideCommandPromptWindow = true;

                var options = new FirefoxOptions();
                //options.AddArgument("--start-maximized");// hidden for invisible
                options.AcceptInsecureCertificates = true;
                options.AddArgument("--headless");//included for hiding
                options.AddArgument("--window-size=1920,1080");//included for hiding

                Driver = new FirefoxDriver(service, options);
                Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));

                LoginToIcegate(ref close_button, ref Error_msg, ref alert_message, icegateId, icegatepass, Wait, Driver, logFile, localKey, currentPage);
                if (string.IsNullOrEmpty(Error_msg))
                    NavigateToDashboard(ref driverIsClosed, ref retry_count, ref  close_button, ref  alert_message, ref alert_retry, ref logout, Wait, Driver, logFile, fullPath, localKey, currentPage);

                if (string.IsNullOrEmpty(Error_msg))
                {
                    SetProgress(localKey, 0, "Collecting Documents details...");

                    // retrieve from gridStore (fallback to captured one)
                    List<GridRow> gvDetailsToUse = null;
                    gridStore.TryGetValue(localKey, out gvDetailsToUse);
                    if (gvDetailsToUse == null) gvDetailsToUse = localGridDetails;


                    UploadDocuments(ref  driverIsClosed, ref retry_count, ref alert_retry, ref alert_message, ref logout, Wait, Driver, logFile, current_step, fullPath, localKey, currentPage);
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                try
                {
                    if (!string.IsNullOrEmpty(alert_message) || !string.IsNullOrEmpty(alert_retry))
                    {
                        localFinalMessage = alert_retry + " " + alert_message;
                        finalMessageStore[localKey] = localFinalMessage;
                        alert_retry = "";
                        alert_message = "";
                    }
                }
                catch { }
                LogoutAndQuitDriver(ref driverIsClosed, Wait, Driver, logFile);


                SetProgress(localKey, 100, localFinalMessage == "Generating IRN, please wait..." ? "Process Completed..." : localFinalMessage);
            }
        });

        backgroundThread.IsBackground = true;
        backgroundThread.Start();

        return localFinalMessage;
    }

    private static void LoginToIcegate(ref int close_button, ref string Error_msg, ref string alert_message, string icegateId, string icegatepass, WebDriverWait wait, IWebDriver driver, string logFile, string key, Page page)
    {

        try
        {

            driver.Navigate().GoToUrl("https://foservices.icegate.gov.in/#/login");

            Thread.Sleep(4000);
            try
            {
                var closeButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(d =>
                {
                    ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete");
                    try
                    {
                        var element = d.FindElement(By.Id("ym-auto-pop-up-close-button"));
                        if (element.Displayed && element.Enabled) return element;
                    }
                    catch { }
                    return null;
                });
                closeButton.Click();
            }
            catch (Exception ex)
            {
                close_button = 0;
                try
                {
                    IWebElement usernameField1 = wait.Until(d => d.FindElement(By.Id("icegateId")));
                    usernameField1.SendKeys(icegateId);

                    IWebElement passwordField2 = wait.Until(d => d.FindElement(By.Id("password")));
                    passwordField2.SendKeys(icegatepass);

                    IWebElement loginButton3 = driver.FindElement(By.CssSelector("button.btn.login"));
                    loginButton3.Click();
                    Thread.Sleep(2000);
                }
                catch (NoSuchElementException)
                {
                }
            }

            if (close_button == 1)
            {
                IWebElement usernameField = wait.Until(d => d.FindElement(By.Id("icegateId")));
                usernameField.SendKeys(icegateId);

                IWebElement passwordField = wait.Until(d => d.FindElement(By.Id("password")));
                passwordField.SendKeys(icegatepass);

                IWebElement loginButton = driver.FindElement(By.CssSelector("button.btn.login"));
                loginButton.Click();
                Thread.Sleep(2000);
                wait.Until(d => d.Url.Contains("role-dashboard"));


                SetProgress(key, 0, "Successfully Logged IN...");


            }


        }
        catch (Exception ex)
        {
            if (driver.Url == "https://foservices.icegate.gov.in/#/login")
            {
                var errorElements = driver.FindElements(By.CssSelector("div.text-error.d-block.pt-1.break-text.ng-star-inserted"));

                if (errorElements.Count > 0)
                {
                    var errorMessage = errorElements.FirstOrDefault(e => e.Displayed && e.Text.Contains("Invalid Credentials"));
                    var errorMessage1 = errorElements.FirstOrDefault(e => e.Displayed && e.Text.Contains("Service Unavailable"));

                    if (errorMessage != null)
                    {
                        Error_msg = "The credentials you entered are invalid.";
                        alert_message = "The credentials you entered are invalid. Check ICEGATE ID and PASSWORD.";
                        File.AppendAllText(logFile, "The credentials you entered are invalid. Check ICEGATE ID and PASSWORD." + ex.InnerException);
                        SetProgress(key, 0, "The credentials you entered are invalid. Check ICEGATE ID and PASSWORD");




                    }
                    else if (errorMessage1 != null)
                    {
                        Error_msg = "Service Unavailable. Please try again later";
                        alert_message = "Service Unavailable. Please try again later";
                        File.AppendAllText(logFile, "Service Unavailable. Please try again later" + ex.InnerException);
                        SetProgress(key, 0, "Service Unavailable. Please try again later");




                    }
                }

                else if (IsPasswordExpiredModalVisible(driver))
                {
                    alert_message = "Your Icegate Password is Expired.";
                    Error_msg = "Your Icegate Password is Expired.";
                    File.AppendAllText(logFile, "Your Icegate Password is Expired." + ex.InnerException);
                    SetProgress(key, 0, "Your Icegate Password is Expired.");

                }
                else
                {
                    Error_msg = "login failed";
                    SetProgress(key, 0, "Connection lost due to ICEGATE Response too slow.Try Again...");
                    File.AppendAllText(logFile, "Connection lost due to ICEGATE Response too slow.Try Again..." + ex.InnerException);
                    alert_message = "Connection lost due to ICEGATE Response too slow.Try Again...";
                }

            }

        }
    }
    private static bool IsPasswordExpiredModalVisible(IWebDriver driver)
    {
        try
        {
            WebDriverWait waitForModal = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement modalContent = waitForModal.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("modal-content")));

            if (modalContent != null && modalContent.Displayed)
            {
                IWebElement modalText = waitForModal.Until(d => d.FindElement(By.CssSelector("div.content.ng-star-inserted")));
                return modalText.Text.Contains("Your Password is Expired.");
            }
        }
        catch (WebDriverTimeoutException)
        {

        }
        catch (NoSuchElementException)
        {

        }

        return false;
    }
    public static void NavigateToDashboard(ref bool driverIsClosed, ref int retry_count, ref int close_button, ref string alert_message, ref string alert_retry, ref string logout, WebDriverWait wait, IWebDriver driver, string logFile, string fullPath, string key, Page page)
    {
        try
        {

           
            try
            {
                if (close_button == 0)
                {
                    Thread.Sleep(1000);
                    var closeButton = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(d =>
                    {
                        ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete");
                        try
                        {
                            var element = d.FindElement(By.Id("ym-auto-pop-up-close-button"));
                            if (element.Displayed && element.Enabled) return element;
                        }
                        catch { }
                        return null;
                    });
                    closeButton.Click();
                }
            }
            catch (Exception ex)
            {
            }
            Thread.Sleep(1000);
            SetProgress(key, 0, "Proceeding 'eSANCHIT' process...");
            IWebElement expansionHeader = wait.Until(d => d.FindElement(By.XPath("//mat-expansion-panel-header[.//h5[contains(text(), 'Services')]]")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center', inline: 'center'});", expansionHeader);
            Thread.Sleep(1000);

            expansionHeader.Click();
            Thread.Sleep(4000);

            IWebElement eSANCHITDiv = wait.Until(d =>
            {
                return d.FindElements(By.XPath("//div[contains(text(),'eSANCHIT')]")).FirstOrDefault();
            });
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", eSANCHITDiv);
            IWebElement chevronButton = eSANCHITDiv.FindElement(By.XPath(".//button[contains(@class, 'mat-icon-button')]"));
            chevronButton.Click();

            IWebElement eSANCHITLink = wait.Until(d => d.FindElement(By.XPath("//a[text()='eSANCHIT']")));
            eSANCHITLink.Click();

            //wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            //List<string> windowHandles = driver.WindowHandles.ToList();
            //driver.SwitchTo().Window(windowHandles[1]);

            //wait.Until(d => d.Url.Contains("esanchit/home"));
            wait.Until(d => d.WindowHandles.Count > 1);
            string newWindow = driver.WindowHandles.Last();
            driver.SwitchTo().Window(newWindow);

            new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                .Until(d => d.Url.Contains("esanchit/home"));
            Thread.Sleep(1000);

        }
        catch (Exception ex)
        {

            if (driver.PageSource.Contains("Service Unavailable"))
            {
                File.AppendAllText(logFile, "Dashboard screen Error: Service Unavailable occured process stepped to HandleRetry " + ex.InnerException);
                SetProgress(key, 0, "Service Unavailable occured in ICEGATE...");
                HandleRetry(ref driverIsClosed, ref retry_count, ref alert_message, ref alert_retry, ref logout, wait, driver, logFile, fullPath, "", key, null, null, null, page);

                return;
            }
            else
            {
                File.AppendAllText(logFile, "Dashboard screen Error:  Process stepped to logoutdleRetry " + ex.InnerException);
                LogoutAndQuitDriver(ref driverIsClosed, wait, driver, logFile);
            }

            File.AppendAllText(logFile, "Dashboard screen Error" + ex.InnerException);
        }
    }

    public static void UploadDocuments(ref bool driverIsClosed, ref int retry_count, ref string alert_retry, ref string alert_message, ref string logout, WebDriverWait wait, IWebDriver driver, string logFile, string current_step, string fullPath, string key, Page page, bool isFromRetry = false)
    {
        try
        {
            string doc_type_error, Docerrorline, Catch_error = "";
            if (driver.Url.Contains("https://www.icegate.gov.in/esanchit"))
            {
                List<GridRow> gv_Details;
                gridStore.TryGetValue(key, out gv_Details);
                if (gv_Details == null) gv_Details = new List<GridRow>();
                wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
                string filepath = fullPath;
                string folderPath = fullPath;
                if (driver.PageSource.Contains("Service Unavailable") || driver.PageSource.Contains("Invalid login attempt."))
                {
                    SetProgress(key, 0, "Service Unavailable occured in ICEGATE...");
                    HandleRetry(ref driverIsClosed, ref retry_count, ref alert_message, ref alert_retry, ref logout, wait, driver, logFile, fullPath, "", key, null, null, null, page);
                    return;
                }

                else if (!Directory.Exists(fullPath))
                {
                    if (!driver.PageSource.Contains("Service Unavailable") && !driver.PageSource.Contains("Invalid login attempt."))
                    {
                        LogoutAndQuitDriver(ref driverIsClosed, wait, driver, logFile);
                        return;
                    }
                }
                else if (retry_count > 9)
                {
                    SetProgress(key, 0, "'Service Unavailable' occured Retry count exceeds '10' so process stopped");
                    LogoutAndQuitDriver(ref driverIsClosed, wait, driver, logFile);
                    return;
                }
                try
                {
                    var irn1 = driver.FindElements(By.Id("irn_0"));
                    string irn_val = "";
                    if (irn1.Count > 0)
                    {
                        string irnValue = irn1[0].GetAttribute("value");
                        if (!string.IsNullOrEmpty(irnValue) && irnValue.Trim().Length > 0)
                        {
                            irn_val = "1";
                        }
                        else
                        {
                            irn_val = "0";
                        }
                    }
                    else
                    {
                        irn_val = "0";
                    }
                    var dropdown1 = driver.FindElements(By.Id("docTypeSelect_0"));
                    string ddl = "";
                    if (dropdown1.Count > 0)
                    {
                        bool hasSelectOption = dropdown1[0]
                            .FindElements(By.TagName("option"))
                            .Any(opt => opt.Text.Trim() == "--- Select ---");

                        if (hasSelectOption)
                        {
                            ddl = "Select";
                        }
                        else
                        {
                            ddl = "Not_Select";
                        }

                    }
                    else
                    {
                        ddl = "0";
                    }

                    if (irn_val == "1" && ddl == "Not_Select")
                    {
                        current_step = "Irn_Gridbind";
                    }
                    else if (irn_val == "0" && ddl == "Select")
                    {
                        current_step = "Doc_Type_select";
                    }
                    else if (irn_val == "0" && ddl == "Not_Select")
                    {
                        current_step = "Doc_Type_select";
                    }
                    else if (irn_val == "0" && ddl == "0")
                    {
                        current_step = "Doc_Upload_Batch";
                    }

                }
                catch (Exception ex)
                {

                }

                var pdfFiles = Directory.GetFiles(fullPath, "*.pdf", SearchOption.AllDirectories);

                int totalFiles = pdfFiles.Length;
                //int tot_doc_count=0;
                //if (tot_doc_count == 0)
                //{
                //    tot_doc_count = totalFiles;
                //}

                //if (tot_doc_count < totalFiles)
                //{
                //    tot_doc_count = totalFiles;
                //}

                SetProgress(key, 0, "Total Documents Count " + totalFiles + " ");
                int index = 0;
                int batchSize = 5;
                while (index < totalFiles)
                {
                    try
                    {
                        string[] batchFiles = pdfFiles.Skip(index).Take(batchSize).ToArray();
                        int batch_no = batchFiles.Length;
                        if (driver.PageSource.Contains("Service Unavailable") || driver.PageSource.Contains("Invalid login attempt."))
                        {
                            SetProgress(key, 0, "Service Unavailable occured in ICEGATE...");
                            HandleRetry(ref driverIsClosed, ref retry_count, ref alert_message, ref alert_retry, ref logout, wait, driver, logFile, fullPath, "", key, null, null, null, page);
                            return;
                        }
                        if (isFromRetry == true)
                        {

                            if (current_step == "Doc_Upload_Batch")
                            {
                                Thread.Sleep(1000);
                                Doc_Upload_Batch(ref driverIsClosed, ref retry_count, ref alert_message, ref alert_retry, ref logout, wait, driver, logFile, totalFiles, batchFiles, index, batchSize, key, folderPath, batch_no, page);
                                Thread.Sleep(1000);
                                Doc_Type_select(ref driverIsClosed, ref Catch_error, ref retry_count, ref alert_message, ref alert_retry, ref logout, wait, driver, logFile, key, folderPath, batch_no, page);
                                if (Catch_error == "Doc_Type_select")
                                {
                                    current_step = "";
                                    break;
                                }
                                try
                                {
                                    var divElement = driver.FindElements(By.Id("maxSizeMb")).FirstOrDefault();
                                    doc_type_error = divElement.GetAttribute("innerHTML") ?? "";

                                    if (!string.IsNullOrEmpty(doc_type_error))
                                    {
                                        Docerrorline = "Doc_Type_wrong";
                                        alert_message = "Document type is not accepted by ICEGATE <br> \n" + doc_type_error;
                                        current_step = "";
                                        break;
                                    }
                                }
                                catch
                                {
                                }
                                Thread.Sleep(1000);
                                Irn_Gridbind(ref Catch_error, ref logout, wait, driver, fullPath, key, folderPath, batch_no, page);

                                if (Catch_error == "Doc_Type_select" && logout == "screen_logout")
                                {
                                    current_step = "";
                                    break;
                                }
                                current_step = "";
                            }
                            else if (current_step == "Doc_Type_select")
                            {
                                Thread.Sleep(1000);
                                Doc_Type_select(ref driverIsClosed, ref Catch_error, ref retry_count, ref alert_message, ref alert_retry, ref logout, wait, driver, logFile, key, folderPath, batch_no, page);
                                if (Catch_error == "Doc_Type_select")
                                {
                                    current_step = "";
                                    break;
                                }
                                try
                                {
                                    var divElement = driver.FindElements(By.Id("maxSizeMb")).FirstOrDefault();
                                    doc_type_error = divElement.GetAttribute("innerHTML") ?? "";

                                    if (!string.IsNullOrEmpty(doc_type_error))
                                    {
                                        Docerrorline = "Doc_Type_wrong";
                                        alert_message = "Document type is not accepted by ICEGATE <br> \n" + doc_type_error;
                                        current_step = "";
                                        break;
                                    }
                                }
                                catch
                                {
                                }
                                Thread.Sleep(1000);
                                Irn_Gridbind(ref Catch_error, ref logout, wait, driver, fullPath, key, folderPath, batch_no, page);
                                if (Catch_error == "Doc_Type_select" && logout == "screen_logout")
                                {
                                    current_step = "";
                                    break;
                                }
                                current_step = "";
                            }
                            else if (current_step == "Irn_Gridbind")
                            {
                                Thread.Sleep(1000);
                                Irn_Gridbind(ref Catch_error, ref logout, wait, driver, fullPath, key, folderPath, batch_no, page);
                                if (Catch_error == "Doc_Type_select" && logout == "screen_logout")
                                {
                                    current_step = "";
                                    break;
                                }
                                current_step = "";
                            }
                            else
                            {
                                Thread.Sleep(1000);
                                Doc_Upload_Batch(ref driverIsClosed, ref retry_count, ref alert_message, ref alert_retry, ref logout, wait, driver, logFile, totalFiles, batchFiles, index, batchSize, key, folderPath, batch_no, page);
                                Thread.Sleep(1000);
                                Doc_Type_select(ref driverIsClosed, ref  Catch_error, ref retry_count, ref  alert_message, ref  alert_retry, ref  logout, wait, driver, logFile, key, folderPath, batch_no, page);
                                if (Catch_error == "Doc_Type_select")
                                {
                                    current_step = "";
                                    break;
                                }
                                try
                                {
                                    var divElement = driver.FindElements(By.Id("maxSizeMb")).FirstOrDefault();
                                    doc_type_error = divElement.GetAttribute("innerHTML") ?? "";

                                    if (!string.IsNullOrEmpty(doc_type_error))
                                    {
                                        Docerrorline = "Doc_Type_wrong";
                                        alert_message = "Document type is not accepted by ICEGATE <br> \n" + doc_type_error;
                                        current_step = "";
                                        break;
                                    }
                                }
                                catch
                                {
                                }
                                Thread.Sleep(1000);
                                Irn_Gridbind(ref Catch_error, ref  logout, wait, driver, fullPath, key, folderPath, batch_no, page);
                                if (Catch_error == "Doc_Type_select" && logout == "screen_logout")
                                {
                                    current_step = "";
                                    break;
                                }
                                current_step = "";
                            }

                        }
                        else
                        {
                            Thread.Sleep(1000);
                            Doc_Upload_Batch(ref driverIsClosed, ref  retry_count, ref  alert_message, ref  alert_retry, ref  logout, wait, driver, logFile, totalFiles, batchFiles, index, batchSize, key, folderPath, batch_no, page);
                            Thread.Sleep(1000);
                            Doc_Type_select(ref driverIsClosed, ref  Catch_error, ref  retry_count, ref alert_message, ref  alert_retry, ref  logout, wait, driver, logFile, key, folderPath, batch_no, page);
                            if (Catch_error == "Doc_Type_select")
                            {
                                current_step = "";
                                break;
                            }
                            try
                            {
                                var divElement = driver.FindElements(By.Id("maxSizeMb")).FirstOrDefault();
                                doc_type_error = divElement.GetAttribute("innerHTML") ?? "";

                                if (!string.IsNullOrEmpty(doc_type_error))
                                {
                                    Docerrorline = "Doc_Type_wrong";
                                    alert_message = "Document type is not accepted by ICEGATE <br> \n" + doc_type_error;
                                    current_step = "";
                                    break;
                                }
                            }
                            catch
                            {
                            }
                            Thread.Sleep(1000);
                            Irn_Gridbind(ref Catch_error, ref logout, wait, driver, fullPath, key, folderPath, batch_no, page);
                            if (Catch_error == "Doc_Type_select" && logout == "screen_logout")
                            {
                                current_step = "";
                                break;
                            }
                            current_step = "";
                        }
                        index += batchSize;


                        int uploadedCount = Math.Min(index, totalFiles);
                        int UploadProgressPercent = 50 + (int)((uploadedCount / (double)totalFiles) * 40);
                        string UploadProgressMessage = "Uploaded documents... " + uploadedCount + " of " + totalFiles + "";
                        SetProgress(key, 0, UploadProgressMessage);

                    }
                    catch (Exception)
                    {
                        if (logout == "screen_logout")
                        { break; }
                    }

                    current_step = "";
                }

                if (totalFiles == 0)
                {
                    SafeAction(ref driverIsClosed, ref retry_count, ref alert_message, ref alert_retry, ref logout, wait, driver, logFile, page, key, fullPath, "", () =>
                    {
                        var DoccloseButton = driver.FindElements(By.Id("close")).FirstOrDefault();
                        DoccloseButton.Click();
                    });
                }

                List<string> windowHandles = driver.WindowHandles.ToList();
                if (windowHandles.Count > 1)
                {
                    SafeAction(ref driverIsClosed, ref  retry_count, ref alert_message, ref  alert_retry, ref logout, wait, driver, logFile, page, key, fullPath, "", () =>
                    {
                        var logoutLink = wait.Until(d => d.FindElements(By.Id("logout")).FirstOrDefault());
                        logoutLink.Click();
                        driver.Close();
                        if (driver.WindowHandles.Count > 0)
                            driver.SwitchTo().Window(driver.WindowHandles[0]);
                    });

                    logout = "screen_logout";
                }
                else if (driver.Url.Contains("esanchit/home"))
                {
                    driver.Close();
                    if (driver.WindowHandles.Count > 0)
                        driver.SwitchTo().Window(driver.WindowHandles[0]);
                    logout = "screen_logout";
                }
            }
        }
        catch (RetryHandledException)
        {

            return;
        }
    }
    private static void Doc_Upload_Batch(ref bool driverIsClosed, ref int retry_count, ref string alert_message, ref string alert_retry, ref string logout, WebDriverWait wait, IWebDriver driver, string logFile, int totalFiles, string[] batchFiles, int index, int batchSize, string key, string folderPath, int batch_no, Page page)
    {

        bool localDriverIsClosed = driverIsClosed;
        int localretry_count = retry_count;
        string localalert_message = alert_message, localalert_retry = alert_retry, locallogout = logout;
        List<GridRow> gv_Details;
        gridStore.TryGetValue(key, out gv_Details);
        if (gv_Details == null) gv_Details = new List<GridRow>();
        int fileCount = driver.FindElements(By.XPath("//textarea[contains(@id, 'fileName_') and normalize-space(text()) != '']")).Count;

        var elementss = driver.FindElements(By.Id("irn_0"));

        Thread.Sleep(2000);

        SafeAction(ref localDriverIsClosed, ref localretry_count, ref  localalert_message, ref localalert_retry, ref  locallogout, wait, driver, logFile, page, key, folderPath, "Doc_Upload_Batch", () =>
        {
            try
            {
                var uploadButton = wait.Until(d => d.FindElements(By.Id("modal")).FirstOrDefault());
                uploadButton.Click();
            }
            catch
            {
                SetProgress(key, 0, "Service Unavailable occured in ICEGATE...");

                HandleRetry(ref localDriverIsClosed, ref localretry_count, ref localalert_message, ref localalert_retry, ref locallogout, wait, driver, logFile, folderPath, "Doc_Upload_Batch", key, null, null, null, page);
                return;
            }
        });
        Thread.Sleep(2000);
        SafeAction(ref localDriverIsClosed, ref localretry_count, ref  localalert_message, ref localalert_retry, ref  locallogout, wait, driver, logFile, page, key, folderPath, "Doc_Upload_Batch", () =>
        {
            try
            {
                var fileInput = wait.Until(d => d.FindElements(By.Id("fileIn")).FirstOrDefault());
                fileInput.SendKeys(string.Join("\n", batchFiles));
            }

            catch
            {
                SetProgress(key, 0, "Service Unavailable occured in ICEGATE...");
                HandleRetry(ref localDriverIsClosed, ref localretry_count, ref localalert_message, ref localalert_retry, ref locallogout, wait, driver, logFile, folderPath, "Doc_Upload_Batch", key, null, null, null, page);
                return;
            }
        });

        Thread.Sleep(1000);

        try
        {

            wait.Until(d =>
                    d.FindElements(By.XPath("//div[contains(@class, 'errorBlock') and (contains(., 'Max number of files allowed per DRN') or contains(., 'Found a duplicate file, name'))]")).Count > 0 ||
                    d.FindElements(By.Id("uploadSubmit")).Count > 0);


            bool isErrorPresent = driver.FindElements(By.XPath("//div[contains(@class, 'errorBlock')]")).Any(e =>
                       e.Displayed &&
                       (e.Text.Contains("Max number of files allowed per DRN") || e.Text.Contains("Found a duplicate file, name")));


            if (isErrorPresent)
            {
                SafeAction(ref driverIsClosed, ref retry_count, ref alert_message, ref alert_retry, ref logout, wait, driver, logFile, page, key, folderPath, "Doc_Upload_Batch", () =>
                {
                    try
                    {
                        SafeAction(ref localDriverIsClosed, ref localretry_count, ref  localalert_message, ref localalert_retry, ref  locallogout, wait, driver, logFile, page, key, folderPath, "Doc_Upload_Batch", () =>
                        {
                            var closeButton = driver.FindElements(By.Id("close")).FirstOrDefault();
                            closeButton.Click();
                        });
                    }

                    catch
                    {
                        SetProgress(key, 0, "Service Unavailable occured in ICEGATE...");
                        HandleRetry(ref localDriverIsClosed, ref localretry_count, ref localalert_message, ref localalert_retry, ref locallogout, wait, driver, logFile, folderPath, "Doc_Upload_Batch", key, null, null, null, page);
                        return;
                    }
                });
            }
            else
            {

                //SafeAction(page, key, folderPath, "Doc_Upload_Batch", () =>
                //{
                //    try
                //    {
                //        var submitButton = wait.Until(d => d.FindElements(By.Id("uploadSubmit")).FirstOrDefault());
                //        submitButton.Click();

                //    }

                //    catch
                //    {
                //        SetProgress(key, 0, "Service Unavailable occured in ICEGATE...");
                //        HandleRetry(folderPath, "Doc_Upload_Batch", key, null, null, null, page);
                //        return;
                //    }
                //});
                SafeAction(ref localDriverIsClosed, ref localretry_count, ref  localalert_message, ref localalert_retry, ref  locallogout, wait, driver, logFile, page, key, folderPath, "Doc_Upload_Batch", () =>
                {
                    try
                    {
                        var submitButton = wait.Until(d => d.FindElement(By.Id("uploadSubmit")));
                        submitButton.Click();

                        WebDriverWait shortWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                        shortWait.Until(d =>
                        {
                            try
                            {
                                var modal = d.FindElement(By.Id("myModal"));
                                return !modal.Displayed;
                            }
                            catch (NoSuchElementException)
                            {
                                return true;
                            }
                        });


                    }
                    catch (Exception ex)
                    {
                        HandleRetry(ref localDriverIsClosed, ref localretry_count, ref localalert_message, ref localalert_retry, ref locallogout, wait, driver, logFile, folderPath, "Doc_Upload_Batch", key, null, null, null, page);
                        return;
                    }
                });


                Thread.Sleep(2000);
                wait.Until(d =>
                       d.FindElements(By.XPath("//div[contains(@class, 'errorBlock') and (contains(., 'Max number of files allowed per DRN') or contains(., 'Found a duplicate file, name'))]")).Count > 0 ||
                       d.FindElements(By.Id("uploadSubmit")).Count > 0);


                bool isErrorPresents = driver.FindElements(By.XPath("//div[contains(@class, 'errorBlock')]")).Any(e =>
                         e.Displayed &&
                         (e.Text.Contains("Max number of files allowed per DRN") || e.Text.Contains("Found a duplicate file, name")));
                if (isErrorPresents)
                {
                    SafeAction(ref localDriverIsClosed, ref localretry_count, ref  localalert_message, ref localalert_retry, ref  locallogout, wait, driver, logFile, page, key, folderPath, "Doc_Upload_Batch", () =>
                    {
                        try
                        {
                            var closeButton = driver.FindElements(By.Id("close")).FirstOrDefault();
                            closeButton.Click();
                        }

                        catch
                        {
                            SetProgress(key, 0, "Service Unavailable occured in ICEGATE...");
                            HandleRetry(ref localDriverIsClosed, ref localretry_count, ref localalert_message, ref localalert_retry, ref locallogout, wait, driver, logFile, folderPath, "Doc_Upload_Batch", key, null, null, null, page);
                            return;
                        }
                    });
                }

            }
        }
        catch
        {
            SetProgress(key, 0, "Service Unavailable occured in ICEGATE...");
            HandleRetry(ref driverIsClosed, ref retry_count, ref alert_message, ref alert_retry, ref logout, wait, driver, logFile, folderPath, "Doc_Upload_Batch", key, null, null, null, page);
            return;
        }

    }
    private static void Doc_Type_select(ref bool driverIsClosed, ref string Catch_error, ref int retry_count, ref string alert_message, ref string alert_retry, ref string logout, WebDriverWait wait, IWebDriver driver, string logFile, string key, string folderPath, int batch_no, Page page)
    {
        bool localDriverIsClosed = driverIsClosed;
        int doct_type_count = 0;
        string fileName_ICEGATE, textareaValue, Doctype_Grid, fileName_Grid;
        try
        {
            List<GridRow> gv_Details;
            gridStore.TryGetValue(key, out gv_Details);
            if (gv_Details == null) gv_Details = new List<GridRow>();
            for (int i = 0; i < batch_no; i++)
            {
                doct_type_count = i + 1;
                try
                {

                    if (driver.FindElements(By.XPath("//*[contains(text(),'Service Unavailable')]")).Any() || driver.PageSource.Contains("Invalid login attempt."))
                    {
                        SetProgress(key, 0, "Service Unavailable occured in ICEGATE...");
                        HandleRetry(ref driverIsClosed, ref  retry_count, ref alert_message, ref alert_retry, ref logout, wait, driver, logFile, folderPath, "Doc_Type_select", key, null, null, null, page);
                        return;
                    }
                    if (gv_Details.Count > 0)
                    {

                        try
                        {

                            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
                            try
                            {
                                fileName_ICEGATE = "fileName_" + i.ToString();
                            }
                            catch
                            {
                                break;
                            }
                            var elements = driver.FindElements(By.Id(fileName_ICEGATE));
                            if (elements.Any())
                            {
                                IWebElement textarea = wait.Until(d => d.FindElement(By.Id(fileName_ICEGATE)));
                                textareaValue = textarea.GetAttribute("value");
                                var rowIndex = gv_Details.Select((row, idx) => new { Row = row, Index = idx }).FirstOrDefault(x => x.Row.DOC_FILE_NAME == textareaValue);

                                if (rowIndex != null)
                                {
                                    GridRow foundRow = gv_Details[rowIndex.Index];

                                    Doctype_Grid = foundRow.DOC_TYPE;
                                    fileName_Grid = foundRow.DOC_FILE_NAME;


                                    if (textareaValue == fileName_Grid)
                                    {
                                        //                                            dropdownId = "docTypeSelect_" + i.ToString();
                                        //                                            IWebElement dropdown = wait.Until(d => d.FindElement(By.Id(dropdownId)));
                                        //                                            script = string.Format(@" var dropdown = document.getElementById('{0}');dropdown.value = '{1}';var event = new Event('change');
                                        //                                            dropdown.dispatchEvent(event);", dropdownId, Doctype_Grid);
                                        //                                            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                                        //                                            jsExecutor.ExecuteScript(script);

                                        string dropdownId = "docTypeSelect_" + i.ToString();
                                        IWebElement dropdown = wait.Until(d => d.FindElement(By.Id(dropdownId)));
                                        string script = @"var dropdown = document.getElementById('" + dropdownId + @"');var options = dropdown.options;
                                            for (var i = 0; i < options.length; i++) {if (options[i].value.indexOf('" + Doctype_Grid + @"') === 0) {
                                            dropdown.value = options[i].value; var event = new Event('change', { bubbles: true });
                                            dropdown.dispatchEvent(event); break;} }";
                                        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                                        jsExecutor.ExecuteScript(script);
                                    }
                                }
                            }


                        }

                        catch
                        {
                            SetProgress(key, 0, "Service Unavailable occured in ICEGATE...");
                            HandleRetry(ref driverIsClosed, ref retry_count, ref alert_message, ref alert_retry, ref logout, wait, driver, logFile, folderPath, "Doc_Type_select", key, null, null, null, page);
                            return;
                        }



                    }





                }
                catch (Exception)
                {
                    if (logout == "screen_logout")
                    { break; }
                }
            }


            SafeAction(ref localDriverIsClosed, ref retry_count, ref alert_message, ref alert_retry, ref logout, wait, driver, logFile, page, key, folderPath, "Doc_Type_select", () =>
            {

                Thread.Sleep(500);
                try
                {
                    var submitDocButton = wait.Until(d => d.FindElement(By.Id("submitDocs")));
                    submitDocButton.Click();
                }

                catch (NoSuchElementException)
                {
                    LogoutAndQuitDriver(ref localDriverIsClosed, wait, driver, logFile);
                    return;
                }

                Thread.Sleep(100);
                WebDriverWait shortWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                shortWait.Until(d =>
                {
                    try
                    {
                        var modal = d.FindElement(By.Id("myModal"));
                        return !modal.Displayed;
                    }
                    catch (NoSuchElementException)
                    {
                        return true;
                    }
                });


            });
            Thread.Sleep(1000);
            SafeAction(ref localDriverIsClosed, ref retry_count, ref alert_message, ref alert_retry, ref logout, wait, driver, logFile, page, key, folderPath, "Doc_Type_select", () =>
            {

                Thread.Sleep(500);
                try
                {
                    var DocSubAccpButton = wait.Until(d => d.FindElement(By.Id("submitDocsConfirm")));
                    DocSubAccpButton.Click();
                }
                catch (NoSuchElementException)
                {
                    LogoutAndQuitDriver(ref localDriverIsClosed, wait, driver, logFile);
                    return;
                }



                WebDriverWait shortWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                shortWait.Until(d =>
                {
                    try
                    {
                        var modal = d.FindElement(By.Id("myModal"));
                        return !modal.Displayed;
                    }
                    catch (NoSuchElementException)
                    {
                        return true;
                    }
                });


            });
            Thread.Sleep(1000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[starts-with(text(), 'Your Document') and @id='model-content']")));

            //SafeAction(page, key, folderPath, "Irn_Gridbind", () =>
            //{
            //    errorline = "Doc_submit";
            //    Thread.Sleep(500);
            //    var submitDocButton = wait.Until(d => d.FindElements(By.Id("submitDocs")).FirstOrDefault());
            //    submitDocButton.Click();
            //});


            //SafeAction(page, key, folderPath, "Irn_Gridbind", () =>
            //{
            //    errorline = "Doc_submit_confirm";
            //    Thread.Sleep(500);
            //    var DocSubAccpButton = wait.Until(d => d.FindElements(By.Id("submitDocsConfirm")).FirstOrDefault());
            //    DocSubAccpButton.Click();

            //});
            Catch_error = "";
        }
        catch (Exception)
        {
            Catch_error = "Doc_Type_select";
        }
    }
    private static void Irn_Gridbind(ref string Catch_error, ref string logout, WebDriverWait wait, IWebDriver driver, string fullPath, string key, string folderPath, int batch_no, Page page)
    {
        try
        {
            string IRN_no, fileName_ICEGATE, textareaValue, IRN_ID, fileName_Grid, Doctype_Grid;
            List<GridRow> gv_Details;
            gridStore.TryGetValue(key, out gv_Details);
            if (gv_Details == null) gv_Details = new List<GridRow>();
            int irn_retreive_count = 4;
            for (int j = batch_no - 1; j >= 0; j--)
            {

                try
                {
                    bool isModalGone = wait.Until(d =>
                    {
                        var modals = d.FindElements(By.CssSelector("div.modal-content"));
                        return !modals.Any(e => e.Displayed);
                    });

                    wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

                    try
                    {

                        fileName_ICEGATE = "fileName_" + j.ToString();
                        IWebElement textarea = wait.Until(d => d.FindElement(By.Id(fileName_ICEGATE)));

                        textareaValue = textarea.GetAttribute("value");
                    }
                    catch
                    {
                        break;
                    }
                    IRN_ID = "irn_" + j.ToString();
                    var elementsforIRN = driver.FindElements(By.Id(IRN_ID));
                    if (elementsforIRN.Any())
                    {
                        IWebElement IRN_NO_ICEGATE = wait.Until(d => d.FindElement(By.Id(IRN_ID)));
                        IRN_no = IRN_NO_ICEGATE.GetAttribute("value");
                        var rowIndex = gv_Details.Select((row, idx) => new { Row = row, Index = idx }).FirstOrDefault(x => x.Row.DOC_FILE_NAME == textareaValue);


                        if (rowIndex != null)
                        {

                            GridRow foundRow = gv_Details[rowIndex.Index];
                            fileName_Grid = foundRow.DOC_FILE_NAME;
                            gv_Details[rowIndex.Index].IRN = IRN_no;
                            Doctype_Grid = foundRow.DOC_TYPE;



                            if (IRN_no != "")
                            {
                                folderPath = fullPath;
                                string filePath = Path.Combine(folderPath, textareaValue);
                                if (File.Exists(filePath))
                                {
                                    File.Delete(filePath);
                                }
                                gridStore[key] = gv_Details;

                            }

                        }

                    }
                }
                catch
                {
                    if (logout == "screen_logout")
                    { break; }
                }

            }

            if (irn_retreive_count == 0)
            {
                batch_no += batch_no;
                SetProgress(key, 0, "IRN For " + batch_no + " Documents generated and Binded in Grid");
            }
            Catch_error = "";
        }
        catch
        {
            Catch_error = "Doc_Type_select";


        }

    }


    private static void SafeAction(ref bool driverIsClosed, ref int retry_count, ref string alert_message, ref string alert_retry, ref string logout, WebDriverWait wait, IWebDriver driver, string logFile, Page page, string key, string folderPath, string Current_step, Action action, int retryCount = 3)
    {
        int attempts = 0;
        while (attempts <= retryCount)
        {
            try
            {
                if (driver.FindElements(By.XPath("//*[contains(text(),'Service Unavailable')]")).Any())
                    throw new Exception("Service Unavailable");

                action.Invoke();

                if (driver.FindElements(By.XPath("//*[contains(text(),'Service Unavailable')]")).Any())
                    throw new Exception("Service Unavailable");

                break;
            }
            catch (Exception ex)
            {
                if (driver.FindElements(By.XPath("//*[contains(text(),'Service Unavailable')]")).Any())
                {

                    HandleRetry(ref driverIsClosed, ref retry_count, ref alert_message, ref alert_retry, ref logout, wait, driver, logFile, folderPath, Current_step, key, null, null, null, page);
                    throw new RetryHandledException();
                }

                if (++attempts > retryCount)
                {

                    throw;
                }
            }
        }
    }
    private static void HandleRetry(ref bool driverIsClosed, ref int retry_count, ref string alert_message, ref string alert_retry, ref string logout, WebDriverWait wait, IWebDriver driver, string logFile, string filepath, string current_step, string key, object sender, EventArgs e, Exception ex, Page page)
    {
        try
        {
            if (!Directory.Exists(filepath) || Directory.GetFiles(filepath).Length == 0 || driver == null || driverIsClosed)
            {
                if (!driver.PageSource.Contains("Service Unavailable") && !driver.PageSource.Contains("Invalid login attempt."))
                {

                    LogoutAndQuitDriver(ref driverIsClosed, wait, driver, logFile);
                    return;
                }
                else
                {
                    LogoutAndQuitDriver(ref driverIsClosed, wait, driver, logFile);
                    return;
                }

            }

            int retryLimit = 5;
            int attempt = 0;

            while (attempt < retryLimit)
            {


                attempt++;
                retry_count++;

                try
                {
                    Thread.Sleep(3000);

                    SetProgress(key, 0, "Service Unavailable occurred. Retrying Attempt(" + retry_count + "). please wait, this might take longer than usual...");

                    List<string> windowHandles = driver.WindowHandles.ToList();
                    if (windowHandles.Count > 1)
                    {
                        driver.Close();
                        driver.SwitchTo().Window(windowHandles[0]);
                    }

                    Thread.Sleep(1000);
                    wait.Until(d => ((IJavaScriptExecutor)d)
                        .ExecuteScript("return document.readyState").Equals("complete"));

                    wait.Until(d => d.Url.Contains("role-dashboard"));

                    string parentWindow = driver.CurrentWindowHandle;
                    HashSet<string> oldWindows = new HashSet<string>(driver.WindowHandles);

                    Thread.Sleep(5000);

                    try
                    {
                        IWebElement eSANCHITLink = wait.Until(d => d.FindElement(By.XPath("//a[text()='eSANCHIT']")));
                        eSANCHITLink.Click();
                    }
                    catch
                    {
                        try
                        {
                            var closeButton = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(d =>
                            {
                                ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete");
                                try
                                {
                                    var element = d.FindElement(By.Id("ym-auto-pop-up-close-button"));
                                    if (element.Displayed && element.Enabled) return element;
                                }
                                catch { }
                                return null;
                            });
                            closeButton.Click();
                        }
                        catch
                        {
                        }
                    }
                    Thread.Sleep(2000);
                    wait.Until(d => d.WindowHandles.Count > oldWindows.Count);
                    string newWindow = driver.WindowHandles.Except(oldWindows).FirstOrDefault();

                    try
                    {
                        driver.SwitchTo().Window(newWindow);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("New window was already closed. Retrying...");
                        File.AppendAllText(logFile, "New window was already closed. Retrying..." + ex.InnerException);
                        continue;
                    }

                    Thread.Sleep(1500);
                    try
                    {
                        IAlert alert = driver.SwitchTo().Alert();
                        if (alert != null)
                        {
                            Console.WriteLine("Dismissing duplicate window alert...");
                            alert.Dismiss();
                            Thread.Sleep(1500);
                        }
                    }
                    catch (NoAlertPresentException) { }
                    try
                    {
                        wait.Until(d => ((IJavaScriptExecutor)d)
                            .ExecuteScript("return document.readyState").Equals("complete"));
                    }
                    catch (WebDriverException wex)
                    {
                        Console.WriteLine("Error loading new window: " + wex.Message);
                        continue;
                    }


                    if (!driver.PageSource.Contains("Service Unavailable") && !driver.PageSource.Contains("Invalid login attempt."))
                        break;

                    driver.Close();
                    driver.SwitchTo().Window(parentWindow);
                }
                catch (Exception retryEx)
                {
                    Console.WriteLine("Retry error: " + retryEx.Message);
                    continue;
                }
            }

            if (driver == null || driverIsClosed)
            {
                return;
            }

            if (driver.PageSource.Contains("Service Unavailable") || driver.PageSource.Contains("Invalid login attempt."))
            {
                alert_retry = "Upload failed after retry due to persistent 'Service Unavailable' issue.";
                SetProgress(key, 0, "Upload failed after retry due to persistent 'Service Unavailable' issue.");
                LogoutAndQuitDriver(ref driverIsClosed, wait, driver, logFile);
                return;
            }


            string currentUrl = driver.Url;

            if (currentUrl.Contains("esanchit/home"))
            {
                alert_retry = "Took longer than usual time to generate 'IRN' because 'Service Unavailable' error occurred in ICEGATE Site " + retry_count + " times while uploading documents.";

                UploadDocuments(ref driverIsClosed, ref retry_count, ref alert_retry, ref alert_message, ref logout, wait, driver, logFile, current_step, filepath, key, (HttpContext.Current.Handler as Page), true);
                throw new RetryHandledException();
            }

        }
        catch (RetryHandledException)
        {
            throw;
        }
        catch (Exception innerEx)
        {
            LogoutAndQuitDriver(ref driverIsClosed, wait, driver, logFile);
        }
    }

    private static void LogoutAndQuitDriver(ref bool driverIsClosed, WebDriverWait wait, IWebDriver driver, string logFile)
    {
        try
        {
            if (driver == null)
            {
                driverIsClosed = true;
                return;
            }

            string url = string.Empty;

            try
            {
                url = driver.Url;
            }
            catch (Exception)
            {

                driverIsClosed = true;
                return;
            }

            if (url.Contains("esanchit"))
            {
                List<string> windowHandles = driver.WindowHandles.ToList();
                if (windowHandles.Count > 1)
                {
                    driver.Close();
                    driver.SwitchTo().Window(windowHandles[0]);


                }
            }

            if (url.Contains("role-dashboard"))
            {
                try
                {
                    IWebElement dropdownIcon = wait.Until(d => d.FindElement(By.XPath("//mat-icon[text()='keyboard_arrow_down']")));
                    dropdownIcon.Click();

                    IWebElement logoutButton = wait.Until(d => d.FindElement(By.XPath("//button[contains(text(), 'Logout')]")));
                    logoutButton.Click();


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Logout UI element not found: " + ex.Message);
                    File.AppendAllText(logFile, "Logout UI element not found: " + ex.InnerException);
                }
            }


        }
        catch (Exception ex)
        {
            Console.WriteLine("Logout/Quit error: " + ex.Message);
            File.AppendAllText(logFile, "Logout/Quit error: " + ex.InnerException);

        }
        finally
        {
            try
            {
                driverIsClosed = true;
                if (driver != null)
                {
                    driver.Quit();
                    driver.Dispose();
                }

            }
            catch
            {
            }
        }
    }

    public class RetryHandledException : Exception
    {
        public RetryHandledException(string message = "Handled by retry logic.") : base(message) { }
    }
    public class DocumentTypeRejectedException : Exception
    {
        public DocumentTypeRejectedException(string message) : base(message) { }
    }

    protected void Generatebuttonhide()
    {
        bool allIRNsFilled = true;

        foreach (GridViewRow row in gv_Details.Rows)
        {
            TextBox txtIRNno = row.FindControl("txtIRNno") as TextBox;
            if (txtIRNno != null && string.IsNullOrWhiteSpace(txtIRNno.Text))
            {
                allIRNsFilled = false;
                break;
            }
        }

        btnGenIRN.Visible = !allIRNsFilled;
    }
    private string IRN_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;
        dtt.Columns.Add(new System.Data.DataColumn("DOC_FILE_NAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IRN", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DOC_TYPE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DOC_LEVEL", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Jobno", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("User", typeof(String)));
        int R = 1;
        foreach (GridViewRow row in gv_Details.Rows)
        {
            TextBox txtFileName = (TextBox)row.FindControl("txtFileName");
            TextBox txtIRNno = (TextBox)row.FindControl("txtIRNno");
            DropDownList ddlDocType = (DropDownList)row.FindControl("ddlDocType");
            DropDownList ddlLevel = (DropDownList)row.FindControl("ddlLevel");
            TextBox txtJobno = (TextBox)row.FindControl("txtJobno");
            TextBox txtUser = (TextBox)row.FindControl("txtUser");
            dr = dtt.NewRow();
            dr[0] = txtFileName.Text;
            dr[1] = txtIRNno.Text;
            if (ddlDocType.SelectedValue.Contains('-'))
            {
                string[] a = ddlDocType.SelectedValue.Split('-');
                string val = a[0];
                ddlDocType.SelectedValue = val;
            }
            dr[2] = ddlDocType.SelectedValue;
            dr[3] = ddlLevel.SelectedValue;
            dr[4] = txtJobno.Text;
            dr[5] = txtUser.Text;
            dtt.Rows.Add(dr);
            R = R + 1;
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }
    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }
    public static bool HasDigitalSignature(string pdfPath)
    {
        PdfReader reader = null;
        try
        {
            reader = new PdfReader(pdfPath);
            AcroFields af = reader.AcroFields;
            var names = af.GetSignatureNames();
            return names.Count > 0;
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
    }

    public int insert_update(string Flag, string xmlData_A)
    {
        ObjUBO.A2 = txt_Jobno.Text;
        ObjUBO.A3 = txtclient.Text;
        ObjUBO.A5 = xmlData_A;
        ObjUBO.A6 = ddlIcegateId.SelectedItem.Text;
        ObjUBO.A7 = ddlIcegateId.SelectedValue.ToString();
        ObjUBO.A15 = Flag;
        ds = IA.IRN_Automation_Insert_Update(ObjUBO);
        int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        return i;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int i = insert_update("S", IRN_details());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["childIRNgrid"] = ds.Tables[0];

                Alert_msg("Saved Successfully");
                string baseFolderPath = HttpContext.Current.Server.MapPath("~/Submission/IRN_Doc_Uploads/" + COMPANY_ID + "/" + currentbranch);
                string targetFolderPath = Path.Combine(baseFolderPath, currentuser, txt_Jobno.Text);

                if (Directory.Exists(targetFolderPath))
                {
                    Directory.Delete(targetFolderPath, true);
                }
                if (Directory.Exists(targetFolderPath))
                {
                    bool hasFiles = false;
                    string[] files = Directory.GetFiles(targetFolderPath);
                    hasFiles = files.Length > 0;
                    if (hasFiles)
                    {
                        hdn_path_check.Value = "true";
                    }
                    
                }
                else
                {
                    hdn_path_check.Value = "";
                }
                hdn_saved.Value = "Y";
                hdn_Grid.Value = "Y";
            }
            else
            {

                Alert_msg("Details Not Saved");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        gv_Details.DataSource = dt;
        gv_Details.DataBind();
        mo.ResetFields(Page.Controls);
        btnDelete.Visible = false;
        btnNew.Visible = false;
        btnSave.Visible = true;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string baseFolderPath = HttpContext.Current.Server.MapPath("~/Submission/IRN_Doc_Uploads/" + COMPANY_ID + "/" + currentbranch);
            string targetFolderPath = Path.Combine(baseFolderPath, currentuser, txt_Jobno.Text);

            if (Directory.Exists(targetFolderPath))
            {
                Directory.Delete(targetFolderPath, true);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.Footer)
            e.Row.CssClass = "Footer";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            load_DOC_CODE(e);
        }
    }
    private void load_DOC_CODE(GridViewRowEventArgs e)
    {
        Admin_mas.Ename = "select_SUP_DOCS_TYPE";
        ds = Admin_mas.RetrieveAll_SUPPROTING_DOCS_Master();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DropDownList ddlDocType = (e.Row.FindControl("ddlDocType") as DropDownList);
            ddlDocType.DataSource = ds.Tables[0];
            ddlDocType.DataTextField = "DOC_CODE";
            ddlDocType.DataValueField = "CODE";
            ddlDocType.DataBind();
            ddlDocType.Items.Insert(0, new ListItem(""));
        }
    }
    protected void gv_Details_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = (DataTable)ViewState["CurrentTable"];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DropDownList ddlDocType = (DropDownList)gv_Details.Rows[i].FindControl("ddlDocType");
            string ddlDoc = ddlDocType.SelectedItem.Text;
            DropDownList ddlLevel = (DropDownList)gv_Details.Rows[i].FindControl("ddlLevel");
            string ddlLev = ddlLevel.SelectedValue.ToString();
            dt.Rows[i]["DOC_TYPE"] = ddlDoc;
            dt.Rows[i]["DOC_LEVEL"] = ddlLev;
        }

        if (dt != null)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0 && rowIndex < dt.Rows.Count)
            {
                string fileName = dt.Rows[rowIndex]["DOC_FILE_NAME"].ToString();
                //string folderPath = Server.MapPath("~/Submission/IRN_Doc_Uploads/");
                string folderPath = HttpContext.Current.Server.MapPath("~/Submission/IRN_Doc_Uploads/" + COMPANY_ID + "/" + currentbranch + "/" + currentuser + "/" + Jobno + "/");
                string filePath = Path.Combine(folderPath, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                dt.Rows.RemoveAt(rowIndex);
                ViewState["CurrentTable"] = dt;
                gv_Details.DataSource = dt;
                gv_Details.DataBind();


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownList ddlDocType = (DropDownList)gv_Details.Rows[i].FindControl("ddlDocType");



                    DropDownList ddlLevel = (DropDownList)gv_Details.Rows[i].FindControl("ddlLevel");

                    ddlDocType.SelectedItem.Text = dt.Rows[i]["DOC_TYPE"].ToString();
                    ddlLevel.SelectedValue = dt.Rows[i]["DOC_LEVEL"].ToString();
                }
                ViewState["CurrentTable"] = dt;

            }
        }
    }

    public void Alert_msg(string msg)
    {
        //string cleanMsg = msg.Replace("<br>", "\\n").Replace("'", "\\'").Replace("\"", "\\\"").Replace("\n", "\\n");
        //string script = "<script type='text/javascript'>alert('" + cleanMsg + "');</script>";
        //ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", script, false);

        //if (msg == "Background process disconnected unexpectedly.")
        //{
        //    driver.Quit();
        //}
        if (msg == "")
        {
            msg = "Completed";
        }
        string cleanMsg = msg.Replace("<br>", "\\n").Replace("'", "\\'").Replace("\"", "\\\"").Replace("\n", "\\n");
        string script = "<script type='text/javascript'>alert('" + cleanMsg + "');</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", script, false);


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

    private static Dictionary<string, ProgressData> progressStore = new Dictionary<string, ProgressData>();

    private class ProgressData
    {
        public int Percent { get; set; }
        public string Message { get; set; }
    }
    [System.Web.Services.WebMethod]
    public static string Get_Doc_type_level(string DocType)
    {
        string Doc_Level = "";
        adminmaster Admin_mas = new adminmaster();
        DataSet ds = new DataSet();
        try
        {
            Admin_mas.EUnit_code = DocType;
            Admin_mas.Ename = "select_SUP_DOCS_TYPE";
            ds = Admin_mas.RetrieveAll_SUPPROTING_DOCS_Master();
            if (ds.Tables[1].Rows.Count > 0)
            {
                Doc_Level = ds.Tables[1].Rows[0]["DOC_LEVEL"].ToString();
            }
            return Doc_Level;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Doc_Level;
    }

    protected void btnRefreshGrid_Click(object sender, EventArgs e)
    {
        List<GridRow> GlobalGridDetails = null;
        gridStore.TryGetValue(txt_Jobno.Text, out GlobalGridDetails);
        if (GlobalGridDetails != null && GlobalGridDetails.Count > 0)
        {
            string jobNo = GlobalGridDetails[0].Jobno;
            string user = GlobalGridDetails[0].User;

            if (jobNo == txt_Jobno.Text && user == currentuser)
            {
                gv_Details.DataSource = GlobalGridDetails;
                gv_Details.DataBind();

                ViewState["stored_list"] = GlobalGridDetails;

                if (GlobalGridDetails != null && GlobalGridDetails.Count > 0)
                {
                    for (int i = 0; i < GlobalGridDetails.Count; i++)
                    {
                        DropDownList ddlDocType = (DropDownList)gv_Details.Rows[i].FindControl("ddlDocType");
                        if (ddlDocType != null)
                            ddlDocType.SelectedValue = GlobalGridDetails[i].DOC_TYPE;
                        if (ddlDocType.SelectedValue == "")
                        {
                            ddlDocType.SelectedItem.Text = GlobalGridDetails[i].DOC_TYPE;
                        }

                        DropDownList ddlLevel = (DropDownList)gv_Details.Rows[i].FindControl("ddlLevel");
                        if (ddlLevel != null)
                            ddlLevel.SelectedValue = GlobalGridDetails[i].DOC_LEVEL;
                    }
                }


                string jobno = txt_Jobno.Text;
                lock (progressStore)
                {
                    if (progressStore.ContainsKey(jobno))
                        progressStore.Remove(jobno);
                }
                List<GridRow> removedList;
                gridStore.TryRemove(jobno, out removedList);
                string msg;
                finalMessageStore.TryGetValue(jobno, out msg);
                Alert_msg(msg ?? "");


                string folderPath = HttpContext.Current.Server.MapPath("~/Submission/IRN_Doc_Uploads/" + COMPANY_ID + "/" + currentbranch + "/" + currentuser + "/" + txt_Jobno.Text + "/");

                if (Directory.Exists(folderPath))
                {
                    bool hasFiles = false;
                    string[] files = Directory.GetFiles(folderPath);
                    hasFiles = files.Length > 0;
                    if (hasFiles)
                    {
                        hdn_path_check.Value = "true";
                    }
                    else
                    {
                        hdn_path_check.Value = "";
                    }
                }
            }
        }
    }



}