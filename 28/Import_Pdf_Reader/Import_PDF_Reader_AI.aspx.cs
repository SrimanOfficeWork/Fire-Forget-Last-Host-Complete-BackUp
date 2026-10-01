using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using ClosedXML.Excel;
using iTextSharp.text.pdf;
using Microsoft.ApplicationBlocks.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class Import_PDF_Reader_AI : ThemeClass
{
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    UserBO objUBO = new UserBO();
    AdminMasterDetails admin = new AdminMasterDetails();
    Jobwise_xl_Upload xl = new Jobwise_xl_Upload();
    Import_PDF_Upload imp_pdf = new Import_PDF_Upload();
    Auto_Search Auto = new Auto_Search();
    ErrorLogs log = new ErrorLogs();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();
    eroyalmaster erm = new eroyalmaster();
    Global_variables QueueObj = new Global_variables();
    OCR_Pdf_Port_Master OPM = new OCR_Pdf_Port_Master();
    PDFReaderLog pdflog = new PDFReaderLog();

    DataTable Dt_gen = new DataTable();
    DataTable Dt_Invoice = new DataTable();
    DataTable Dt_Item = new DataTable();
    DataTable Dt_DBK = new DataTable();
    DataTable Dt_anx = new DataTable();
    DataTable dt_Temp_Inv = new DataTable();
    DataTable dt_Temp_IGM = new DataTable();
    DataTable dt_Temp_Con = new DataTable();

    DataSet ds_IEC = new DataSet();
    DataSet ds_draw = new DataSet();
    DataSet GetLocalAPIData = new DataSet();
    DataSet ds_API = new DataSet();
    DataSet ds_get_data = new DataSet();
    Page_Count_Details ds_Page = new Page_Count_Details();

    public String Xml_Inv;
    public string HSCodeJson = "[]";

    public int MAX_ID = 0;
    int i = 0;
    int rowIndex = 0;
    int result = 0;
    int INVOICE_SLNO = 0;
    decimal Sum_of_Quantity_Rate = 0;

    public string GENERAL_IMPORT_JOBNO = "";
    public string TRANSPORT_MODE = "";
    public string SELECT_TYPE = "";
    public string Current_JOB = "";
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string COMPANY_IDD, comp_ConnectionStr, LoginDate, SELECT_BRANCH, SB_TYPE, JOBNO;
    public string a1 = "", a2 = "", a3 = "", a4 = "", a5 = "", a6 = "";
    string PdfClientName = "";
    string Upload_Count = "";
    string Upload_Success_Count = "";
    string Upload_Error_Count;
    string Upload_page_Count = "";
    bool IsValid = true;
    bool IsValid_PortOO = true;
    bool IsValidInv = true;

    private SqlConnection con;
    public string COMPANY_LICENSE, COMPANY_ID;
    public string Imp_name = "", branch_slno = "", Imp_PdfClientName = "", pdf_count, vendor;

    private const string CACHE_COUNTRY_MASTER = "CachePdfImport_CountryMaster";
    private const string CACHE_SCHEME_CODE = "CachePdfImport_SchemeCode";


    private const string CACHE_SCHEME_NOTN_PREFIX = "CachePdfImport_SchemeNotn_";
    private const string CACHE_SCHEME_NOTN_SL_PREFIX = "CachePdfImport_SchemeNotnSl_";
    private const int CACHE_MINUTES = 60;

    private Dictionary<string, DataSet> _schemeNotnCache = new Dictionary<string, DataSet>(StringComparer.OrdinalIgnoreCase);
    private Dictionary<string, DataSet> _schemeNotnSlCache = new Dictionary<string, DataSet>(StringComparer.OrdinalIgnoreCase);

    private static readonly System.Web.Script.Serialization.JavaScriptSerializer _jss
        = new System.Web.Script.Serialization.JavaScriptSerializer();

    private DataSet ds_API_Ref = null;
    private DateTime extractionStartTime;

    private int CurrentPageIndex
    {
        get
        {
            object val = ViewState["CurrentPageIndex"];
            return val != null ? (int)val : 0;
        }
        set { ViewState["CurrentPageIndex"] = value; }
    }

    // ─── PAGE LOAD 
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        SELECT_BRANCH = Connection.Get_Company_Type();
        COMPANY_IDD = Session["COMPANY_ID"].ToString();
        COMPANY_LICENSE = Session["COMPANY_LICENSE"] != null? Session["COMPANY_LICENSE"].ToString() : "";
        COMPANY_ID = Session["COMPANY_ID"] != null ? Session["COMPANY_ID"].ToString() : "";
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        SELECT_TYPE = Session["SELECT_TYPE"].ToString();


        string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
        if (TRANS_MODE == "A") TRANSPORT_MODE = "Air";
        else if (TRANS_MODE == "S") TRANSPORT_MODE = "Sea";
        else if (TRANS_MODE == "L") TRANSPORT_MODE = "Land";

        hd_TransportMode.Value = TRANSPORT_MODE;
        Hdn_STANDARD_TYPE.Value = "STD";

        ddlTransportMode.Items.Remove(ddlTransportMode.Items.FindByValue(TRANSPORT_MODE));
        ddlTransportMode.Items.Insert(0, new ListItem(TRANSPORT_MODE, TRANSPORT_MODE));

        // ── Docker Vision queue: opened from the AI Extraction Queue screen with ?pid=... ─────────
        // Export_PDF_Reader_New_AI already reads pid/vendor/slno/Imp_exp_name this way for EROYAL;
        // this is the same idea for the DOCKER_VISION_QUEUE vendor, added here since Import never had it.
        string pid = Request.QueryString["Pid"];
        string dvVendor = Request.QueryString["vendor"];
        string dvBranchSlno = Request.QueryString["slno"];
        string dvImpExpName = Request.QueryString["Imp_exp_name"];
        string dvPdfMasterMode = Request.QueryString["PDF_Master_Mode"];

        if (!IsPostBack)
        {
            Bind_Clients();
            AUTO_JOBNO();
            WriteJobLog("UI Opened", "Import PDF Reader AI popup opened");

            if (!string.IsNullOrEmpty(pid) && dvVendor == DockerVisionQueueClient.VENDOR_TYPE)
            {
                LoadDockerVisionResultFromQueue(pid, dvBranchSlno, dvImpExpName, dvPdfMasterMode);
            }
        }

        con = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString());
        Call_Server_Side_Method();

        if (currentuser == "RTS" || currentuser == "s" || currentuser == "k"
            || currentuser == "Aji" || currentuser == "Kavi")
        {
            ExcelDwnl.Visible = true;
        }
    }

    // ─── BIND CLIENTS ─
    public void Bind_Clients()
    {
        imp_pdf.JOBNO = JOBNO;
        imp_pdf.flag = "Bind_Importer_List";
        imp_pdf.USER_ID = currentuser;
        imp_pdf.WORKINGPERIOD = Working_Period;
        imp_pdf.Branch_Code = currentbranch;

        DataSet ds_client = imp_pdf.Imp_PDF_Upload_New_XML(Dt_gen, Dt_Item, Dt_DBK, Dt_Invoice, Dt_anx);

        try
        {
            if (ds_client.Tables[0].Rows.Count > 0)
            {
                ddl_ImporterName.DataSource = ds_client.Tables[0];
                ddl_ImporterName.DataTextField = "IMPORTER_NAME";
                ddl_ImporterName.DataValueField = "IMPORTER_NAME";
                ddl_ImporterName.DataBind();
            }
        }
        catch { ddl_ImporterName.DataBind(); }

        scheme_NOTN();
        Get_SchemeCode();
        DropDownTerms_FilingStatus();
    }

    // ─── GET SCHEME CODE ─
    public void Get_SchemeCode()
    {
        DataSet ds_sh = GetCachedSchemeCode();
        Session["dss"] = ds_sh;

        ddlSchemeCode.DataSource = ds_sh;
        ddlSchemeCode.DataTextField = "SCHEME_CODE";
        ddlSchemeCode.DataValueField = "SCHEME_CODE";
        ddlSchemeCode.Items.Add("");
        ddlSchemeCode.DataBind();
        ddlSchemeCode.Items.Insert(0, new ListItem("", ""));
        ddlSchemeCode.Items.Insert(1, "00 - DUTIABLE");
    }

    private DataSet GetCachedSchemeCode()
    {
        DataSet ds = HttpRuntime.Cache[CACHE_SCHEME_CODE] as DataSet;
        if (ds == null)
        {
            adm.name = "SCHEME_IMPORT_CODE";
            ds = adm.RetrieveAll_Scheme_Import();
            HttpRuntime.Cache.Insert(CACHE_SCHEME_CODE, ds, null,
                DateTime.Now.AddMinutes(CACHE_MINUTES),
                System.Web.Caching.Cache.NoSlidingExpiration);
        }
        return ds;
    }

    // ── OPTIMIZED: Cached scheme NOTN lookup ─
    private DataSet GetCachedSchemeNotn(string schemeCode)
    {
        string key = CACHE_SCHEME_NOTN_PREFIX + schemeCode;

        // 1. Check per-request cache first (fastest)
        if (_schemeNotnCache.ContainsKey(schemeCode))
            return _schemeNotnCache[schemeCode];

        // 2. Check HttpRuntime cache
        DataSet ds = HttpRuntime.Cache[key] as DataSet;
        if (ds == null)
        {
            adm.SCHEME_IMPORT_CODE = schemeCode;
            adm.SCHEME_NOTN = "0";
            adm.name = "SCHEME_NOTN";
            ds = adm.RetrieveAll_Scheme_Import();
            HttpRuntime.Cache.Insert(key, ds, null,
                DateTime.Now.AddMinutes(CACHE_MINUTES),
                System.Web.Caching.Cache.NoSlidingExpiration);
        }

        _schemeNotnCache[schemeCode] = ds;
        return ds;
    }

    private DataSet GetCachedSchemeNotnSl(string schemeCode, string notn)
    {
        string cacheKey = schemeCode + "|" + notn;
        string httpKey = CACHE_SCHEME_NOTN_SL_PREFIX + cacheKey;

        if (_schemeNotnSlCache.ContainsKey(cacheKey))
            return _schemeNotnSlCache[cacheKey];

        DataSet ds = HttpRuntime.Cache[httpKey] as DataSet;
        if (ds == null)
        {
            adm.SCHEME_IMPORT_CODE = schemeCode;
            adm.SCHEME_NOTN = notn;
            adm.name = "SCHEME_NOTN_SLNO";
            ds = adm.RetrieveAll_Scheme_Import();
            HttpRuntime.Cache.Insert(httpKey, ds, null,
                DateTime.Now.AddMinutes(CACHE_MINUTES),
                System.Web.Caching.Cache.NoSlidingExpiration);
        }

        _schemeNotnSlCache[cacheKey] = ds;
        return ds;
    }

    public void Get_AdCode()
    {
        try
        {
            Auto_Search autoC = new Auto_Search();
            autoC.Ename = "Get_ADCODE";
            autoC.Enamesearch = ViewState["imp_name"].ToString();
            autoC.NSearch = ViewState["IEC"].ToString();

            DataSet ds = autoC.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlAdCode.DataSource = ds.Tables[0];
                ddlAdCode.DataTextField = "IMPORT_ADCODE";
                ddlAdCode.DataValueField = "IMPORT_ADCODE";
                ddlAdCode.DataBind();
            }
        }
        catch { }
    }

    public void DropDownTerms_FilingStatus()
    {
        ddlTerms.Items.Add("FOB");
        ddlTerms.Items.Add("CI");
        ddlTerms.Items.Add("CF");
        ddlTerms.Items.Add("CIF");

        ddlFilingStatus.Items.Clear();
        ddlFilingStatus.Items.Add("Normal");
        ddlFilingStatus.Items.Add("Prior");
        ddlFilingStatus.Items.Add("Advanced");
    }

    protected void gv_ItemPDF_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow
            && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow
            && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void gv_ItemPDF_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) return;

        DataTable GridViewMasterDataBind = ViewState["MasterDataChecking"] as DataTable;
        if (GridViewMasterDataBind != null)
        {
            TextBox txtItemDesc = e.Row.FindControl("txtItemDesc") as TextBox;
            if (txtItemDesc != null && rowIndex < GridViewMasterDataBind.Rows.Count)
            {
                if (txtItemDesc.Text == GridViewMasterDataBind.Rows[rowIndex]["ITEM_DESC"].ToString())
                {
                    txtItemDesc.BorderColor = System.Drawing.Color.Red;
                    txtItemDesc.BackColor = System.Drawing.Color.MediumTurquoise;
                    rowIndex++;
                }
            }
        }

        if (COMPANY_IDD == "1069" || COMPANY_IDD == "3352")
        {
            TextBox txtItemQty = e.Row.FindControl("txtItemQty") as TextBox;
            TextBox txtItemAmt = e.Row.FindControl("txtItemAmt") as TextBox;
            TextBox txtItemUnitPrice = e.Row.FindControl("txtItemUnitPrice") as TextBox;
            if (txtItemQty != null) txtItemQty.Enabled = true;
            if (txtItemAmt != null) txtItemAmt.Enabled = true;
            if (txtItemUnitPrice != null) txtItemUnitPrice.Enabled = true;
        }

        // ── Use cached Session scheme data instead of re-fetching ──
        DataSet ds_schemeCode = Session["dss"] as DataSet;
        DropDownList ddl_SchemeCode = e.Row.FindControl("ddl_SchemeCode") as DropDownList;
        DropDownList ddl_Scheme_NOTN = e.Row.FindControl("ddl_Scheme_NOTN") as DropDownList;
        DropDownList ddl_Scheme_NOTN_SL = e.Row.FindControl("ddl_Scheme_NOTN_SL") as DropDownList;

        if (ddl_SchemeCode != null && ds_schemeCode != null)
        {

            ddl_SchemeCode.DataSource = ds_schemeCode.Tables[0];
            ddl_SchemeCode.DataTextField = "SCHEME_CODE";
            ddl_SchemeCode.DataValueField = "SCHEME_CODE";
            ddl_SchemeCode.DataBind();
            ddl_SchemeCode.Items.Insert(0, "00 - DUTIABLE");

            string selectedSchemeCode = DataBinder.Eval(e.Row.DataItem, "SchemeCode").ToString();
            try { ddl_SchemeCode.SelectedValue = selectedSchemeCode; }
            catch { ddl_SchemeCode.SelectedIndex = 0; }

            string str = ddl_SchemeCode.SelectedValue;
            string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);
            string schemeCodePart = s1[0].Trim();

            ddl_Scheme_NOTN.Items.Clear();
            ddl_Scheme_NOTN_SL.Items.Clear();

            if (schemeCodePart != "00")
            {
                DataSet dsNotn = GetCachedSchemeNotn(schemeCodePart);
                ddl_Scheme_NOTN.DataSource = dsNotn;
                ddl_Scheme_NOTN.DataTextField = "SCHEME_NOTN";
                ddl_Scheme_NOTN.DataValueField = "SCHEME_NOTN";
                ddl_Scheme_NOTN.Items.Add(" ");
                ddl_Scheme_NOTN.DataBind();

                try
                {
                    string schemeNotnVal = DataBinder.Eval(e.Row.DataItem, "Scheme_NOTN").ToString();
                    if (!string.IsNullOrEmpty(schemeNotnVal.Trim()))
                        ddl_Scheme_NOTN.SelectedValue = schemeNotnVal;
                }
                catch { }
            }

            string selectedNotn = ddl_Scheme_NOTN.SelectedValue ?? "";

            DataSet dsNotnSl = GetCachedSchemeNotnSl(schemeCodePart, selectedNotn);
            ddl_Scheme_NOTN_SL.DataSource = dsNotnSl;
            ddl_Scheme_NOTN_SL.DataTextField = "SCHEME_NOTN_SLNO";
            ddl_Scheme_NOTN_SL.DataValueField = "SCHEME_NOTN_SLNO";
            ddl_Scheme_NOTN_SL.Items.Add(" ");
            ddl_Scheme_NOTN_SL.DataBind();

            try
            {
                string schemeNotnSlVal = DataBinder.Eval(e.Row.DataItem, "Scheme_NOTN_SL").ToString();
                if (!string.IsNullOrEmpty(schemeNotnSlVal.Trim()))
                    ddl_Scheme_NOTN_SL.SelectedValue = schemeNotnSlVal;
            }
            catch { }
        }

        // ── CTH data attributes (unchanged) ──
        TextBox txt_CTH_box = e.Row.FindControl("txt_CTH") as TextBox;
        if (txt_CTH_box != null)
        {
            string rowCthList = "[]";
            try
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                if (drv != null
                    && drv.Row.Table.Columns.Contains("CTH_List")
                    && drv["CTH_List"] != DBNull.Value
                    && !string.IsNullOrEmpty(drv["CTH_List"].ToString()))
                {
                    rowCthList = drv["CTH_List"].ToString();
                }
            }
            catch { rowCthList = "[]"; }

            txt_CTH_box.Attributes["data-cth-list"] = rowCthList;

            List<string> cthArr = null;
            try { cthArr = _jss.Deserialize<List<string>>(rowCthList); }
            catch { cthArr = new List<string>(); }

            int cthCount = cthArr != null ? cthArr.Count : 0;
            if (cthCount == 1) txt_CTH_box.Attributes["data-cth-mode"] = "single";
            else if (cthCount > 1) txt_CTH_box.Attributes["data-cth-mode"] = "multi";
            else txt_CTH_box.Attributes["data-cth-mode"] = "empty";
        }
    }

    // ─── ALERT HELPERS 
    public void Alert_msg(string msg)
    {
        msg = msg.Replace("'", "\\'").Replace("\r", " ").Replace("\n", " ");
        string prompt = "<script>$(document).ready(function(){{jAlert('"
            + msg + "', 'Import PDF Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        msg = msg.Replace("'", "\\'").Replace("\r", " ").Replace("\n", " ");
        string prompt = "<script>$(document).ready(function(){{jAlert('"
            + msg + "', 'Import PDF Upload', function (r) {document.getElementById('"
            + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg1(string msg)
    {
        var sb = new StringBuilder();
        sb.Append("<script>$(document).ready(function() {");
        sb.Append("$('#modalMessage').text('").Append(msg).Append("');");
        sb.Append("$('#myModal').modal('show');");
        sb.Append("setTimeout(function() { $('#myModal').modal('hide'); }, 5000);");
        sb.Append("});</script>");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", sb.ToString(), false);
    }

    public void Alert_And_Redirect(string msg)
    {
        msg = msg.Replace("'", "\\'");
        string script = "jAlert('" + msg
            + @"', 'Import PDF Upload', function (r) { if (r) { "
            + "parent.window.location.replace('../Transaction/General_Search.aspx'); } });";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertredirect", script, true);
    }

    // ── Docker Vision queue: alert then send the popup opener back to the Import queue screen ──────
    // Mirrors Export_PDF_Reader_New_AI.Alert_And_Redirect_Queue.
    public void Alert_And_Redirect_Queue_Import(string msg)
    {
        msg = msg.Replace("'", "\\'");
        string script = "jAlert('" + msg + "', 'PDF AI Queue', function(r) {" +
                        "  if(r) { parent.openAistatuscheck('IMP'); }" +
                        "});";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertqueue", script, true);
    }

    // ── Docker Vision queue: reload a queued job's stored result when opened with ?pid=... ─────────
    // Mirrors the EROYAL branch in Export_PDF_Reader_New_AI.Page_Load, adapted to how Import AI fills
    // its own grid (FillHeaderFields / FillInvoiceRows / FillIGMAndContainerRows / ProcessItemsBatch).
    private void LoadDockerVisionResultFromQueue(string pid, string branch_slno, string imp_name, string pdfMasterMode)
    {
        try
        {
            Global_variables QObj = new Global_variables();
            QObj.A4 = pid;
            DataSet ds_Ven_API = new AI_Queue().Queue_Get_By_ProcessId(QObj);
            if (ds_Ven_API == null || ds_Ven_API.Tables.Count == 0 || ds_Ven_API.Tables[0].Rows.Count == 0)
            {
                Alert_msg("Could not find this job in the queue. Please try again from the Queue screen.");
                return;
            }

            string storedJson = ds_Ven_API.Tables[0].Rows[0]["JSON_RESPONSE"].ToString();
            if (string.IsNullOrEmpty(storedJson))
            {
                Alert_msg("No result is stored yet for this job. Please check again shortly.");
                return;
            }

            // Confirmed against a real Docker Vision response (TIMKEN US sample, 2026-09-30): the stored
            // JSON is a single flat object with top-level Header / InvoiceDetails / ItemsDetails /
            // ItemsIGMContainerDetails arrays — the exact same shape UploadPdfExtraction/UploadPdfWithParameters
            // already deserialize for the synchronous Royal/Docker_Vision vendors, and the same shape
            // Get_AccessToken_Invoice's local-test reader expects. No custom conversion is needed here.
            try { ds_API = JsonConvert.DeserializeObject<DataSet>(storedJson); }
            catch (Exception) { ds_API = null; }

            if (ds_API == null
                || ds_API.Tables.Count < 3
                || ds_API.Tables[0].Rows.Count == 0
                || ds_API.Tables[1].Rows.Count == 0
                || ds_API.Tables[2].Rows.Count == 0)
            {
                Alert_msg("Could not read the stored Docker Vision result. Please re-upload.");
                return;
            }

            // Lock the importer dropdown to the one this job was queued under (same "slno--name" format
            // used everywhere else on this page), same idea as Export's Bind_Clients(exp_name, branch_slno).
            if (!string.IsNullOrEmpty(imp_name))
            {
                string exporter_key = branch_slno + "--" + imp_name;
                ddl_ImporterName.Items.Clear();
                ddl_ImporterName.Items.Add(new ListItem(exporter_key, exporter_key));
                ddl_ImporterName.SelectedIndex = 0;
                ViewState["branch_slno"] = branch_slno;
                ViewState["imp_name"] = imp_name;
            }

            var countryCache = BuildCountryCache();
            InitDataTables();

            string pdfClientName = Get_PdfClient_Name(imp_name, branch_slno);
            bool isEuropeanNumberFormat =
                imp_name == "Atlas Copco (India) Private limited" || imp_name == "SIEMENS LTD" || imp_name == "Royal Tech"
                || imp_name == "RELIANCE CONSUMER PRODUCTS LTD" || imp_name == "SIEMENS HEALTHCARE PRIVATE LIMITED"
                || pdfClientName == "GODREJ & BOYCE MFG. CO. LTD." || pdfClientName == "LIFETECH" || pdfClientName == "PPG"
                || pdfClientName == "ALFA LAVAL" || pdfClientName == "VEGA" || pdfClientName == "BOSCH ALFATEC" || pdfClientName == "MAHR";

            FillHeaderFields(ds_API, imp_name, branch_slno, countryCache);
            INVOICE_SLNO++;
            FillInvoiceRows(ds_API, 1, imp_name, pdfClientName, isEuropeanNumberFormat);
            FillIGMAndContainerRows(ds_API);
            ProcessItemsBatch(ds_API, 1, imp_name, pdfClientName, isEuropeanNumberFormat, pdfMasterMode, countryCache);

            ViewState["ItemDetails"] = Dt_Item;
            ViewState["GridViewData"] = Dt_Item;
            BindGridPaged(1);

            if (gv_ItemPDF.Rows.Count > 0) { Select_ItemRITC(); Get_AdCode(); }

            lbl_loading.Text = "<span style='color: green; font-weight: bold;'>✅ Loaded from queue. Review and click Upload.</span>";
            btnupload.Visible = true;
            btnDeleteSelected.Visible = true;

            WriteJobLog("Queue Result Loaded", "Vendor:DOCKER_VISION | ProcessId:" + pid);
        }
        catch (Exception ex)
        {
            LogException("Docker Vision Queue Load Failed", ex);
            Alert_msg("Error loading queued result: " + ex.Message);
        }
    }

    public void Call_Server_Side_Method()
    {
        txtImporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer_ChkBind('" + txtImporterName.ClientID + "')");
        txtCTH.Attributes.Add("onblur", "javascript:Call_CTH_Rate('" + txtCTH.ClientID + "', '" + txtBasicSLNO.ClientID + "')");
        txtBasicSLNO.Attributes.Add("onBlur", "javascript:CallServerside_Basic_Duty_Cth_Notn_Slno('" + txtBasicSLNO.ClientID + "', '" + txtBasicNotn.ClientID + "')");
        txtSW_Slno.Attributes.Add("onblur", "javascript:CallServerside_Social_Welfare_Notn_Slno('" + txtSW_Slno.ClientID + "', '" + txtSW_Noti.ClientID + "')");
        txtitemCountyof_orgin.Attributes.Add("onblur", "javascript:Call_CountryOrigin('" + txtitemCountyof_orgin.ClientID + "')");
        txtitemCountyof_orgin.Attributes.Add("onkeyup", "javascript:Call_CountryOrigin('" + txtitemCountyof_orgin.ClientID + "')");
        txtPortOfOrigin.Attributes.Add("onblur", "javascript:CallServerside_Port_of_orgin('" + txtPortOfOrigin.ClientID + "', '" + txtPortOfOrigin.ClientID + "')");
        txtPortOfOrigin.Attributes.Add("onfocus", "javascript:CallServerside_Port_of_orgin('" + txtPortOfOrigin.ClientID + "', '" + txtPortOfOrigin.ClientID + "')");
        txt_AIDC_CessSlno.Attributes.Add("onblur", "javascript:Call_AIDC_Master('" + txt_AIDC_CessSlno.ClientID + "', '" + txt_AIDC_CessNoti.ClientID + "')");
        txt_IGST_SlNo.Attributes.Add("onblur", "javascript:CallServerside_txt_IGST_LEVY_SLNO('" + txt_IGST_SlNo.ClientID + "', '" + txt_IGST_Noti.ClientID + "')");
    }

    // ─── BUTTON: PREVIEW ───────────
    protected void btnPrevData_Click(object sender, EventArgs e)
    {
        extractionStartTime = DateTime.Now;
        WriteJobLog("Button Click", "PREVIEW clicked | FileCount:" + Request.Files.Count);
        try
        {
            if (Request.Files.Count == 0)
            {
                Alert_msg("Please upload a PDF or Excel file before proceeding.");
                return;
            }

            bool hasValidFile = false;
            for (int fi = 0; fi < Request.Files.Count; fi++)
            {
                if (Request.Files[fi] != null && Request.Files[fi].ContentLength > 0)
                {
                    hasValidFile = true;
                    break;
                }
            }
            if (!hasValidFile)
            {
                Alert_msg("Please upload a PDF or Excel file before proceeding.");
                return;
            }

            int FileUploadLimit = GetFileUploadLimit();

            if (Request.Files.Count > 0 && Request.Files.Count <= FileUploadLimit)
            {
                string fileNames = string.Join(", ", Request.Files.AllKeys.Select(k => Request.Files[k].FileName));
                WriteJobLog("Preview Initiated", "File(s): " + fileNames);

                Get_Upload_File();
                lblmsg.Text = "";
            }
            else
            {
                Alert_msg(Request.Files.Count > FileUploadLimit
                    ? "Please Upload a File Minimum " + FileUploadLimit + "..!"
                    : "Please Upload File..!");
            }
        }
        catch (Exception ex)
        {
            log.makeLog("Message ==> " + ex.Message);
            LogException("Preview Failed", ex);
            lblmsg.Text = " Message ==> " + ex.Message
                + " InnerException ==> " + ex.InnerException
                + " StackTrace ==>" + ex.StackTrace;
        }
        Get_AdCode();
    }

    private int GetFileUploadLimit()
    {
        if (COMPANY_IDD == "576" || COMPANY_IDD == "584") return 10;
        if (COMPANY_IDD == "3306" || COMPANY_IDD == "293") return 30;
        if (COMPANY_IDD == "6002") return 40;
        return 5;
    }

    // ─── INIT DATA TABLES ─────────
    private void InitDataTables()
    {
        if (Dt_Item.Columns.Count > 0) return;

        dt_Temp_Inv.Columns.Add("INVOICE_SLNO");
        dt_Temp_Inv.Columns.Add("InvoiceNo");
        dt_Temp_Inv.Columns.Add("InvoiceDate");
        dt_Temp_Inv.Columns.Add("Currency");
        dt_Temp_Inv.Columns.Add("Terms");
        dt_Temp_Inv.Columns.Add("InvoiceValue");
        dt_Temp_Inv.Columns.Add("PurchaseOrderNo");
        dt_Temp_Inv.Columns.Add("PurchaseOrderDate");
        dt_Temp_Inv.Columns.Add("Insurance");
        dt_Temp_Inv.Columns.Add("Freight");
        dt_Temp_Inv.Columns.Add("MissCharge");
        dt_Temp_Inv.Columns.Add("SupplierAdd1");
        dt_Temp_Inv.Columns.Add("SupplierAdd2");
        dt_Temp_Inv.Columns.Add("SupplierAdd3");
        dt_Temp_Inv.Columns.Add("SupplierAdd4");

        Dt_Item.Columns.Add("InvoiceSlNo");
        Dt_Item.Columns.Add("ItemSlNo");
        Dt_Item.Columns.Add("ITEM_DESC");
        Dt_Item.Columns.Add("Quantity");
        Dt_Item.Columns.Add("Rate");
        Dt_Item.Columns.Add("Amount");
        Dt_Item.Columns.Add("QtyCode");
        Dt_Item.Columns.Add("HSCode");
        Dt_Item.Columns.Add("SchemeCode");
        Dt_Item.Columns.Add("Scheme_NOTN");
        Dt_Item.Columns.Add("Scheme_NOTN_SL");
        Dt_Item.Columns.Add("Basic_Noti");
        Dt_Item.Columns.Add("Basic_Slno");
        Dt_Item.Columns.Add("Basic_Rate");
        Dt_Item.Columns.Add("info_MSR");
        Dt_Item.Columns.Add("info_UQC");
        Dt_Item.Columns.Add("MANUFACTURER");
        Dt_Item.Columns.Add("END_USE_OF_ITEM");
        Dt_Item.Columns.Add("itemCountyof_orgin");
        Dt_Item.Columns.Add("SW_Noti");
        Dt_Item.Columns.Add("SW_Slno");
        Dt_Item.Columns.Add("SW_Rate");
        Dt_Item.Columns.Add("AIDC_CessNoti");
        Dt_Item.Columns.Add("AIDC_CessSlno");
        Dt_Item.Columns.Add("AIDC_CessRate");
        Dt_Item.Columns.Add("IGST_Noti");
        Dt_Item.Columns.Add("IGST_SlNo");
        Dt_Item.Columns.Add("IGST_Rate");
        Dt_Item.Columns.Add("PartNo");
        Dt_Item.Columns.Add("IGST_LEVY_COMPENSATION_CESS_NOTN");
        Dt_Item.Columns.Add("IGST_LEVY_COMPENSATION_CESS_SLNO");
        Dt_Item.Columns.Add("IGST_LEVY_COMPENSATION_CESS_RATE");
        //-------
        //================ Upload Required Columns ===================

        Dt_Item.Columns.Add("ITEM_UNIT_CODE");
        Dt_Item.Columns.Add("ITEM_AMOUNT_CODE");
        Dt_Item.Columns.Add("PREVIOUS_BE_DATE");
        Dt_Item.Columns.Add("FLAG");
        Dt_Item.Columns.Add("YEAR");
        Dt_Item.Columns.Add("USER_ID");
        Dt_Item.Columns.Add("BRANCH_CODE");
        Dt_Item.Columns.Add("WORKING_PERIOD");
        Dt_Item.Columns.Add("JOBNO");
        Dt_Item.Columns.Add("BRANCH_COMMON");

        Dt_Item.Columns.Add("GENERAL_DESCRIPTION");

        Dt_Item.Columns.Add("BRAND");
        Dt_Item.Columns.Add("MODEL");

        Dt_Item.Columns.Add("COUNTRY_OF_ORIGIN");

        Dt_Item.Columns.Add("PRODUCT_RITC");
        Dt_Item.Columns.Add("PRODUCT_CTH");
        Dt_Item.Columns.Add("PRODUCT_CETH");

        Dt_Item.Columns.Add("RSP_APPLICABLE");

        Dt_Item.Columns.Add("SVB_RELATION");
        Dt_Item.Columns.Add("SVB_REF_NO");
        Dt_Item.Columns.Add("SVB_REF_DATE");
        Dt_Item.Columns.Add("SVB_CUSTOM_HOUSE");
        Dt_Item.Columns.Add("SVB_LOADING_ON");
        Dt_Item.Columns.Add("SVB_ASSESABLE_RATE");
        Dt_Item.Columns.Add("SVB_DUTY_RATE");
        Dt_Item.Columns.Add("SVB_ASSESABLE_STATUS");
        Dt_Item.Columns.Add("SVB_DUTY_STATUS");

        Dt_Item.Columns.Add("IGST_LEVY_EXCEPTION_NOTN");
        Dt_Item.Columns.Add("IGST_LEVY_EXCEPTION_RATE");
        Dt_Item.Columns.Add("LEVY_EXCEMPTION_NOTN_TYPE");
        Dt_Item.Columns.Add("CTH_List", typeof(string));

        dt_Temp_IGM.Columns.Add("IGM_MAWB_MBL");
        dt_Temp_IGM.Columns.Add("IGM_MAWB_MBLDATE");
        dt_Temp_IGM.Columns.Add("IGM_HAWB_HBLNO");
        dt_Temp_IGM.Columns.Add("IGM_HAWB_HBLDATE");
        dt_Temp_IGM.Columns.Add("IGM_NOOFPACKAGE");
        dt_Temp_IGM.Columns.Add("IGM_GROSSWEIGHT");

        dt_Temp_Con.Columns.Add("CONTAINER_NO");
        dt_Temp_Con.Columns.Add("SEAL_NO");
        dt_Temp_Con.Columns.Add("TYPE");
    }

    // ─── FILL HEADER FIELDS ────────────
    private void FillHeaderFields(DataSet ds_API, string imp_name, string branch_slno,
        Dictionary<string, string> countryCache)
    {
        txtSupplier.Text = ds_API.Tables[1].Rows[0]["SupplierName"].ToString().Replace("Ä", "A");
        hd_Supplier.Value = txtSupplier.Text;

        txtCountryOfOrigin.Text = ds_API.Tables[0].Rows[0]["CountryOfOrigin"].ToString();
        txtPortOfOrigin.Text = ds_API.Tables[0].Rows[0]["PortOfOrigin"].ToString();
        if (!string.IsNullOrWhiteSpace(txtCountryOfOrigin.Text) || !string.IsNullOrWhiteSpace(txtPortOfOrigin.Text))
        {
            Get_COUNTRY_NAME_PORT_NAME(txtCountryOfOrigin.Text, txtPortOfOrigin.Text);
        }

        if (imp_name == "DONALDSON INDIA FILTER" || imp_name == "DONALDSON INDIA")
        {
            imp_name = "DONALDSON INDIA FILTER SYSTEMS PVT LTD";
            ViewState["imp_name"] = imp_name;
        }

        txtImporterName.Text = ds_API.Tables[0].Rows[0]["ImporterName"].ToString();
        hd_ImporterName.Value = ds_API.Tables[0].Rows[0]["ImporterName"].ToString();
        hd_ImporterAdd1.Value = ds_API.Tables[0].Rows[0]["ImporterAdd1"].ToString();
        hd_ImporterAdd2.Value = ds_API.Tables[0].Rows[0]["ImporterAdd2"].ToString();
        hd_ImporterAdd3.Value = ds_API.Tables[0].Rows[0]["ImporterAdd3"].ToString();
        hd_ImporterAdd4.Value = ds_API.Tables[0].Rows[0]["ImporterAdd4"].ToString();

        if (COMPANY_IDD != "293")
        {
            hd_Freight.Value = ds_API.Tables[0].Rows[0]["Freight"].ToString();
            hd_Insurance.Value = ds_API.Tables[0].Rows[0]["Insurance"].ToString();
            hd_MiscCharge.Value = ds_API.Tables[0].Rows[0]["MiscCharge"].ToString();
        }

        string IEC = ds_API.Tables[0].Rows[0]["IEC"].ToString();
        if (string.IsNullOrEmpty(IEC))
        {
            Auto_Search autoIEC = new Auto_Search();
            autoIEC.Ename = "Import_Details_Bind";
            autoIEC.Enamesearch = imp_name;
            autoIEC.NSearch = branch_slno;
            DataSet dsIEC = autoIEC.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (dsIEC.Tables[0].Rows.Count > 0)
                ViewState["IEC"] = dsIEC.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
        }
        else
        {
            ViewState["IEC"] = IEC;
        }
    }

    // ─── FILL INVOICE ROWS ──────
    private void FillInvoiceRows(DataSet ds_API, int fileCount, string imp_name,
        string PdfClientName, bool isEuropeanFmt)
    {
        for (int ak = 0; ak <= ds_API.Tables[1].Rows.Count - 1; ak++)
        {
            string InvoiceSlNo = (fileCount == 1)
                ? ds_API.Tables[1].Rows[ak]["InvoiceSlNo"].ToString()
                : INVOICE_SLNO.ToString();

            txtInvNo.Text = ds_API.Tables[1].Rows[ak]["InvoiceNo"].ToString();
            txtInvDate.Text = ds_API.Tables[1].Rows[ak]["InvoiceDate"].ToString();
            txtCurrency.Text = Get_Valid_Curr_Name(ds_API.Tables[1].Rows[ak]["Currency"].ToString());

            string TERMS1 = ds_API.Tables[1].Rows[ak]["Terms"].ToString();
            string MissCharge = GetSafeValue(ds_API.Tables[1], ak, "MiscCharge");
            string Insurance = GetSafeValue(ds_API.Tables[1], ak, "Insurance");
            string Freight = GetSafeValue(ds_API.Tables[1], ak, "Freight");

            try
            {
                ddlTerms.Text = TERMS1
                    .Replace("FCA", "FOB").Replace("CIP", "CIF")
                    .Replace("CPT", "CF").Replace("C. I. F", "CIF")
                    .Replace("CFR", "CF").Replace("DAP", "CIF");
            }
            catch { ddlTerms.Text = "FOB"; }

            string rawInvValue = ds_API.Tables[1].Rows[ak]["InvoiceValue"].ToString();
            if (rawInvValue != "" && rawInvValue != null)
            {
                txtInvValue.Text = isEuropeanFmt
                    ? rawInvValue.Replace(".", "").Replace(",", ".").Replace("'", "")
                    : rawInvValue.Replace(",", "").Replace("¥", "").Replace("'", "");
            }
            else
            {
                txtInvValue.Text = "0";
            }

            string PurchaseOrderNo = "";
            string PurchaseOrderDate = "";
            if (PdfClientName == "ALFA LAVAL")
            {
                PurchaseOrderNo = ds_API.Tables[1].Rows[ak]["PurchaseOrderNo"].ToString();
                PurchaseOrderDate = ds_API.Tables[1].Rows[ak]["PurchaseOrderDate"].ToString();
            }

            string SupAdd1 = ds_API.Tables[1].Rows[ak]["SupplierAdd1"].ToString();
            string SupAdd2 = ds_API.Tables[1].Rows[ak]["SupplierAdd2"].ToString();
            string SupAdd3 = ds_API.Tables[1].Rows[ak]["SupplierAdd3"] != DBNull.Value ? ds_API.Tables[1].Rows[ak]["SupplierAdd3"].ToString() : "";
            string SupAdd4 = ds_API.Tables[1].Rows[ak]["SupplierAdd4"] != DBNull.Value ? ds_API.Tables[1].Rows[ak]["SupplierAdd4"].ToString() : "";

            if (COMPANY_IDD == "293")
                dt_Temp_Inv.Rows.Add(InvoiceSlNo, txtInvNo.Text.Trim(),
                    txtInvDate.Text, txtCurrency.Text, ddlTerms.Text, txtInvValue.Text,
                    PurchaseOrderNo, PurchaseOrderDate, Insurance, Freight, MissCharge,
                    SupAdd1, SupAdd2, SupAdd3, SupAdd4);
            else
                dt_Temp_Inv.Rows.Add(InvoiceSlNo, txtInvNo.Text.Trim(),
                    txtInvDate.Text, txtCurrency.Text, ddlTerms.Text, txtInvValue.Text,
                    PurchaseOrderNo, PurchaseOrderDate, "", "", "",
                    SupAdd1, SupAdd2, SupAdd3, SupAdd4);

            ViewState["dt_Invoice"] = dt_Temp_Inv;
        }
    }

    // ─── FILL IGM AND CONTAINER ROWS ────
    private void FillIGMAndContainerRows(DataSet ds_API)
    {
        if (ds_API.Tables[3].Rows.Count == 0) return;
		
		string IGM_NOOFPACKAGE = "";
        string IGM_GROSSWEIGHT = "";

        /*string MBLNo = ds_API.Tables[3].Rows[0]["MBLNo"].ToString().Replace("-", "");
        string MBLDate = ds_API.Tables[3].Rows[0]["MBLDate"].ToString();
        if (MBLDate != "" && MBLDate != null)
            MBLDate = Get_Valid_Date_New(ds_API.Tables[3].Rows[0]["MBLDate"].ToString());

        string HBLNo = ds_API.Tables[3].Rows[0]["HBLNo"].ToString().Replace("-", "");
        string HBLDate = ds_API.Tables[3].Rows[0]["HBLDate"].ToString();
        if (HBLDate != "" && HBLDate != null)
            HBLDate = Get_Valid_Date_New(ds_API.Tables[3].Rows[0]["HBLDate"].ToString());

        string IGM_NOOFPACKAGE = ds_API.Tables[0].Rows[0]["TotalCarton"].ToString().Replace(",", "");
        string IGM_GROSSWEIGHT = ds_API.Tables[0].Rows[0]["TotalGrossWeight"].ToString().Replace(",", "");

        if (!string.IsNullOrEmpty(MBLNo + MBLDate + HBLNo + HBLDate + IGM_NOOFPACKAGE + IGM_GROSSWEIGHT))
        {
            dt_Temp_IGM.Rows.Add(MBLNo, MBLDate, HBLNo, HBLDate, IGM_NOOFPACKAGE, IGM_GROSSWEIGHT);
            ViewState["dt_IGMDetails"] = dt_Temp_IGM;
        }*/
		
		//new
		HashSet<string> distinctIGM = new HashSet<string>();
 
        for (int ka = 0; ka < ds_API.Tables[3].Rows.Count; ka++)
        {
            string MBLNo = ds_API.Tables[3].Rows[ka]["MBLNo"].ToString().Replace("-", "");
 
            string MBLDate = ds_API.Tables[3].Rows[ka]["MBLDate"].ToString();
            if (!string.IsNullOrEmpty(MBLDate))
                MBLDate = Get_Valid_Date_New(MBLDate);
 
            string HBLNo = ds_API.Tables[3].Rows[ka]["HBLNo"].ToString().Replace("-", "");
 
            string HBLDate = ds_API.Tables[3].Rows[ka]["HBLDate"].ToString();
            if (!string.IsNullOrEmpty(HBLDate))
                HBLDate = Get_Valid_Date_New(HBLDate);
 
            /*string IGM_NOOFPACKAGE = ds_API.Tables[0].Rows[0]["TotalCarton"].ToString().Replace(",", "");
            string IGM_GROSSWEIGHT = ds_API.Tables[0].Rows[0]["TotalGrossWeight"].ToString().Replace(",", "");*/

            if (COMPANY_IDD == "268")
            {
                IGM_NOOFPACKAGE = Convert.ToString(ds_API.Tables[3].Rows[ka]["TOTAL_PACKAGES"]).Replace(",", "");

                IGM_GROSSWEIGHT = Convert.ToString(ds_API.Tables[3].Rows[ka]["TOTAL_GROSS_WEIGHT"]).Replace(",", "");
            }
 
            // Create unique key for IGM
            string igmKey = MBLNo + "|" +MBLDate + "|" +HBLNo + "|" +HBLDate;
 
            // Add only distinct IGM
            if (!distinctIGM.Contains(igmKey))
            {
                distinctIGM.Add(igmKey);
 
                if (!string.IsNullOrEmpty(MBLNo + MBLDate + HBLNo + HBLDate +IGM_NOOFPACKAGE + IGM_GROSSWEIGHT))
                {
                    dt_Temp_IGM.Rows.Add(MBLNo,MBLDate,HBLNo,HBLDate,IGM_NOOFPACKAGE,IGM_GROSSWEIGHT);
                }
            }
        }
		
		ViewState["dt_IGMDetails"] = dt_Temp_IGM;

        for (int ka = 0; ka <= ds_API.Tables[3].Rows.Count - 1; ka++)
        {
            string Containerslno = ds_API.Tables[3].Rows[ka]["Containerslno"].ToString();
            string ContainerNo = ds_API.Tables[3].Rows[ka]["ContainerNo"].ToString().Replace("-", "");
            string ContainerSealNo = (COMPANY_IDD == "294")
                ? "NA"
                : ds_API.Tables[3].Rows[ka]["ContainerSealNo"].ToString().Replace("¡", "i");
            string ContainerSize = ds_API.Tables[3].Rows[ka]["ContainerSize"].ToString().Replace("'HQ", "HC");

            if (ContainerNo != "" && Containerslno != "" && ddlTransportMode.SelectedValue != "Air")
                dt_Temp_Con.Rows.Add(ContainerNo, ContainerSealNo, ContainerSize);

            ViewState["dt_ContainerDetails"] = dt_Temp_Con;
        }
    }

    // ─── APPLY CLIENT OVERRIDES ───────
    private void ApplyClientOverrides(
        ref string ItemDesc, ref string QTYCode, ref string Quantity,
        ref string Rate, ref string Amount, ref string PartNo,
        ref string MANUFACTURER, ref string PRODUCT_END_USE,
        ref string Condition_Desc, ref string HSCode, ref string ItemCountry,
        string ExtraItemDesc, string PONumber, string NetWeight,
        string imp_name, string PdfClientName, bool isEuropeanFmt,
        DataRow itemRowRef)
    {
        if (PdfClientName == "JAAZ")
        {
            ItemDesc = ItemDesc + " BRACKER RING TRAVELLERS (PARTS FOR TEXTILE MACHINERY) " + Quantity.Replace(",", "") + " PCS";
            QTYCode = "KGS";
            if (QTYCode == "KGS" && NetWeight != "" && NetWeight != null)
            {
                Quantity = NetWeight.Replace(",", "");
                decimal calcRate = Convert.ToDecimal(Amount.Replace(",", "")) / Convert.ToDecimal(Quantity);
                Rate = calcRate.ToString("N6").Replace(",", "");
            }
        }
        else if (PdfClientName == "MYUNGSUNG" || imp_name == "ANORA INSTRUMENTATION PRIVATE LIMITED")
        {
            ItemDesc = ItemDesc.Replace("DESC: ", "") + " " + PartNo;
            QTYCode = "NOS";
        }
        else if (PdfClientName == "SBM BANK")
        {
            ItemDesc = "FOREIGN CURRENCY (BANK NOTES AED " + ItemDesc + " X " + Quantity + ") (FC AMOUNT " + PONumber + ") (PAPER MONEY)";
        }
        else if (PdfClientName == "HAWORTH" || PdfClientName == "LG ELECTRONICS"
              || PdfClientName == "MERCEDES BENZ" || PdfClientName == "CARBOTEC")
        {
            ItemDesc = ExtraItemDesc + " " + ItemDesc;
            if (PdfClientName == "LG ELECTRONICS")
            {
                if (itemRowRef != null && itemRowRef.Table.Columns.Contains("ItemManufacture"))
                    MANUFACTURER = itemRowRef["ItemManufacture"].ToString().Replace("null", "");
            }
        }
        else if (PdfClientName == "LG" || PdfClientName == "BALLUFF"
              || PdfClientName == "INDIA" || PdfClientName == "SCHWING")
        {
            ItemDesc = ItemDesc + " " + ExtraItemDesc;
        }
        else if (PdfClientName == "BYD") { ItemDesc = ExtraItemDesc + " " + ItemDesc; }
        else if (PdfClientName == "GE") { ItemDesc = PONumber + " " + ItemDesc; }
        else if (PdfClientName == "HAIER") { ItemDesc = ItemDesc + " PART CODE:" + PONumber + " " + ExtraItemDesc; }
        else if (PdfClientName == "VEICHI" || PdfClientName == "BRAY") { ItemDesc = ItemDesc + " - " + ExtraItemDesc; }
        //else if (PdfClientName == "KOMATSU") { ItemDesc = PartNo + "-" + ItemDesc + "-" + PONumber; }
        else if (PdfClientName == "HP")
        {
            ItemDesc = "(P/N." + PartNo + ") " + ItemDesc;
            QTYCode = "NOS";
            PRODUCT_END_USE = "GNX200";
            txtCountryOfOrigin.Text = "CHINA";
        }        
        else if (COMPANY_IDD == "427")
        {
            ItemDesc = ItemDesc + " " + ExtraItemDesc + "-" + PartNo + " (FOR DOMESTIC USE)";
            if (itemRowRef != null) QTYCode = itemRowRef["ItemQTYCode"].ToString();
        }
        else if (PdfClientName == "BOSCH")
        {
            decimal calcRate = Convert.ToDecimal(Amount.Replace(",", "").Replace(" ", ""))
                             / Convert.ToDecimal(Quantity.Replace(",", "").Replace(" ", ""));
            Rate = calcRate.ToString("N6").Replace(",", "");
        }
        else if (PdfClientName == "RL")
        {
            ItemDesc = ItemDesc + "(" + ExtraItemDesc + ")(REST DETAILS AS PER INV & PL)";
            if (itemRowRef != null) QTYCode = itemRowRef["ItemQTYCode"].ToString();
        }
        else if (COMPANY_IDD == "829" || PdfClientName == "ZIMMER" || PdfClientName == "SCHWING"
              || PdfClientName == "TLD" || PdfClientName == "SRI" || PdfClientName == "Denso killar")
        {
            if (itemRowRef != null) QTYCode = itemRowRef["ItemQTYCode"].ToString();
        }
        else if (PdfClientName == "DENSO CORPORATION")
        {
            if (itemRowRef != null) QTYCode = itemRowRef["ItemQTYCode"].ToString();
        }
        else if (COMPANY_IDD == "3306")
        {
            ItemDesc = PartNo + " " + ItemDesc;
            if (itemRowRef != null) QTYCode = itemRowRef["ItemQTYCode"].ToString();
        }
        else if (PdfClientName == "JOHNSON")
        {
            if (itemRowRef != null) QTYCode = itemRowRef["ItemQTYCode"].ToString();
            ItemDesc = ItemDesc.ToUpper().Trim();
        }
        else if (PdfClientName == "NS")
        {
            ItemDesc = ItemDesc + "(PART NO: " + PartNo + ")(" + ExtraItemDesc + ")(ACTUAL USER)";
        }
        else if (PdfClientName == "CATERPILLAR")
        {
            QTYCode = "PCS";
            PRODUCT_END_USE = "GNX200";
            PartNo = PartNo.Replace("-", "");
        }
        else if (PdfClientName == "TT")
        {
            if (itemRowRef != null) QTYCode = itemRowRef["ItemQTYCode"].ToString();
            ItemDesc = "GALVANNEALED STEEL COILS" + PartNo + ItemDesc + " SIZE(" + ExtraItemDesc + ") - " + PONumber;
        }
        else if (PdfClientName == "BOSCH A BERGER" || PdfClientName == "BOSCH ALFATEC"
              || PdfClientName == "BOSCH AMISCO" || PdfClientName == "BOSCH BOSCH CORPORATION"
              || PdfClientName == "BOSCH BOSCH WUXI" || PdfClientName == "BOSCH BOSCH SUZHOU"
              || PdfClientName == "BOSCH ELECTRICAL DRIVES")
        {
            ItemDesc = PartNo + " " + ItemDesc;
            decimal calcRate = Convert.ToDecimal(Amount.Replace(",", "").Replace(" ", ""))
                             / Convert.ToDecimal(Quantity.Replace(",", "").Replace(" ", ""));
            Rate = calcRate.ToString("N6").Replace(",", "");
            if (string.IsNullOrEmpty(txtCountryOfOrigin.Text.Trim()))
                txtCountryOfOrigin.Text = ItemCountry;
        }
        else if (PdfClientName == "SHINDENGEN INDIA")
        {
            Condition_Desc = ItemDesc;
            ItemDesc = ItemDesc + " " + PartNo + " (" + PONumber + ") (" + ExtraItemDesc + ")";
            decimal calcRate = Convert.ToDecimal(Amount.Replace(",", "").Replace(" ", ""))
                             / Convert.ToDecimal(Quantity.Replace(",", "").Replace(" ", ""));
            Rate = calcRate.ToString("N6").Replace(",", "");
            if (itemRowRef != null) QTYCode = itemRowRef["ItemQTYCode"].ToString();
            if (string.IsNullOrEmpty(txtCountryOfOrigin.Text.Trim()))
                txtCountryOfOrigin.Text = ItemCountry;
        }
        else if (PdfClientName == "RELIANCE RETAIL LIMITED")
        {
            ItemDesc = ItemDesc + " (" + Quantity.Replace(",", "") + " " + QTYCode + ") (BIS NO.L-4100201251)";
            Quantity = NetWeight.Replace(",", "");
            decimal calcRate = Convert.ToDecimal(Amount.Replace(",", "").Replace(" ", ""))
                             / Convert.ToDecimal(Quantity.Replace(",", "").Replace(" ", ""));
            Rate = calcRate.ToString("N6").Replace(",", "");
            QTYCode = "KGS";
        }
        else if (PdfClientName == "KYUNGSHIN")
        {
            Condition_Desc = ItemDesc;
            if (itemRowRef != null) QTYCode = itemRowRef["ItemQTYCode"].ToString();
            ItemDesc = ItemDesc + "-" + PartNo + "-" + PONumber + "-" + ExtraItemDesc;
        }
        else if (PdfClientName == "ALCON Alcon Pharmaceuticals" || PdfClientName == "SCHAEFFLER")
        {
            if (itemRowRef != null) QTYCode = itemRowRef["ItemQTYCode"].ToString();
            ItemDesc = ItemDesc + " " + ExtraItemDesc;
            decimal calcRate = Convert.ToDecimal(Amount.Replace(",", "").Replace(" ", ""))
                             / Convert.ToDecimal(Quantity.Replace(",", "").Replace(" ", ""));
            Rate = calcRate.ToString("N6").Replace(",", "");
        }
        else if (PdfClientName == "JCB")
        {
            QTYCode = ds_API_Ref.Tables[1].Rows[0]["QtyCode"].ToString();
            ItemDesc = ExtraItemDesc + "-" + ItemDesc;
        }
        else if (COMPANY_IDD == "293") { PRODUCT_END_USE = "GNX200"; }
        else if (PdfClientName == "SCHWING COBRA")
        {
            if (itemRowRef != null) QTYCode = itemRowRef["ItemQTYCode"].ToString();
            ItemDesc = "SPARE PARTS OF GEAR BOX - " + ItemDesc + " - " + ExtraItemDesc;
        }
        else if (COMPANY_IDD == "1619")
        {
            ItemDesc = PONumber + " " + PartNo + " " + ItemDesc + " " + ExtraItemDesc;
        }
        else if (PdfClientName == "ONGC")
        {
            if (itemRowRef != null) QTYCode = itemRowRef["ItemQTYCode"].ToString();
        }

        if (PdfClientName == "VEGA") QTYCode = "NOS";
    }

    // ─── SET MASTER LOOKUP STRATEGY ───────
    private void SetMasterLookupStrategy(eroyalmaster erm,
        string MasterCon, string MasterDesc, string ItemDesc,
        string PartNo, string HSCode, string PONumber, string Condition_Desc, string ExtraItemDesc)
    {
        if (!string.IsNullOrEmpty(MasterCon))
        {
            string mc = MasterCon.ToUpper();
            if (mc == "P") { erm.Ename = "Get_Master_Data_PartNo"; erm.Eproduct_imp_description = PartNo; }
            else if (mc == "H") { erm.Ename = "Get_Master_Data_CTH"; erm.Eproduct_imp_cth = HSCode; }
            else if (mc == "D") { erm.Ename = "Get_Master_Data"; erm.Eproduct_imp_description = !string.IsNullOrEmpty(MasterDesc) ? MasterDesc : ItemDesc; }
        }
        else
        {
            if (COMPANY_IDD == "3299" || COMPANY_IDD == "3306" || COMPANY_IDD == "1069" || PdfClientName.ToUpper().Contains("DENSO"))
            { erm.Ename = "Get_Master_Data_PartNo"; erm.Eproduct_imp_description = PartNo; }
            else if (COMPANY_IDD == "1542" || COMPANY_IDD == "382" || PdfClientName == "YOUTAOHK")
            { erm.Ename = "Get_Master_Data_CTH"; erm.Eproduct_imp_cth = HSCode; }
            else if (COMPANY_IDD == "268")
            {
                erm.Ename = "Get_Master_Data_PartNo_VSM";
                erm.Eproduct_imp_description = PartNo;
                erm.Eproduct_imp_id = ExtraItemDesc;
                if (!string.IsNullOrEmpty(PartNo))
                {
                    string Con_PartNo = !string.IsNullOrEmpty(PONumber) ? PONumber.Substring(0, 1) : string.Empty;
                    erm.Eproduct_imp_cth = Con_PartNo;
                }
            }

            else if (COMPANY_IDD == "249")
            {
                erm.Ename = "Get_Master_BullsEye_Ritc";
                erm.Eproduct_imp_description = ItemDesc;  
            }


            else if (COMPANY_IDD == "293")
            { erm.Ename = "Get_Master_Data_PartNo_Para"; erm.Eproduct_imp_description = PartNo; }
            else
            {
                erm.Ename = "Get_Master_Data";
                erm.Eproduct_imp_description = (COMPANY_IDD == "3267" || COMPANY_IDD == "139" || COMPANY_IDD == "1542")
                    ? Condition_Desc : ItemDesc;
            }
        }
    }

    // ─── PROCESS ITEMS BATCH ───────────
    private void ProcessItemsBatch(DataSet ds_API, int fileCount, string imp_name,
        string PdfClientName, bool isEuropeanFmt, string PDF_Master_Mode,
        Dictionary<string, string> countryCache)
    {
        ds_API_Ref = ds_API;

        int totalItems = ds_API.Tables[2].Rows.Count;
        if (totalItems == 0) return;

        Auto_Search auto = new Auto_Search();

        var uniqueHSCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        for (int idx = 0; idx < totalItems; idx++)
        {
            string hs = CleanHSCode(ds_API.Tables[2].Rows[idx]["ItemHSCODE"].ToString());
            if (!string.IsNullOrEmpty(hs)) uniqueHSCodes.Add(hs);
        }

        var aidc_Cache = new Dictionary<string, DataRow>(StringComparer.OrdinalIgnoreCase);
        var igst_Cache = new Dictionary<string, DataRow>(StringComparer.OrdinalIgnoreCase);

        foreach (string hs in uniqueHSCodes)
        {
            try
            {
                adm.AIDC_RITC_NO = hs;
                adm.Ename = "ITEM_RITC";
                DataSet dsAIDC = adm.Get_AIDC_CESS_SELECT();
                if (dsAIDC.Tables[0].Rows.Count > 0) aidc_Cache[hs] = dsAIDC.Tables[0].Rows[0];

                auto.Ename = "Get_IGST_NOTN_SLNO_RITC_V2";
                auto.Enamesearch = hs;
                auto.Notn_No_Search = hs;
                DataSet dsIGST = auto.RetrieveAll_AUTOCOMPLETE_SEARCH_PART_II();
                if (dsIGST.Tables[1].Rows.Count > 0) igst_Cache[hs] = dsIGST.Tables[1].Rows[0];
            }
            catch { }
        }

        var bcdRateCache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var igstRateCache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var masterCache = new Dictionary<string, DataSet>(StringComparer.OrdinalIgnoreCase);
        var itemCountryCache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var uqcCache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        string defaultQtyCode = ds_API.Tables[1].Rows[0]["QtyCode"].ToString();

        Dt_Item.BeginLoadData();
        try
        {
            for (int idx = 0; idx < totalItems; idx++)
            {
                DataRow itemRow = ds_API.Tables[2].Rows[idx];

                string ItemInvoiceSlNo = (fileCount == 1) ? itemRow["InvoiceSlNo"].ToString() : INVOICE_SLNO.ToString();
                string ItemSlNo = itemRow["ItemSlNo"].ToString();
                string ItemDesc = itemRow["ItemDesc"].ToString();
                string ExtraItemDesc = itemRow["ExtraItemDesc"].ToString();
                string PartNo = itemRow["PartNo"].ToString();
                string PONumber = itemRow["PONumber"].ToString();
                string NetWeight = itemRow["ItemNETWEIGHT"].ToString().Replace(" ", "");
                string MasterDesc = GetSafeValue(ds_API.Tables[2], idx, "MasterDesc");
                string MasterCon = GetSafeValue(ds_API.Tables[2], idx, "MasterCon");
                string MANUFACTURER = txtSupplier.Text.ToUpper().Trim();
                string PRODUCT_END_USE = "";
                string Condition_Desc = "";

                string Quantity = itemRow["Quantity"].ToString().Replace(" ", "");
                string Rate = itemRow["Rate"].ToString().Replace(" ", "");
                string Amount = itemRow["Amount"].ToString().Replace(" ", "").Replace("'", "");
                string HSCode = CleanHSCode(itemRow["ItemHSCODE"].ToString());

                string QTYCode = defaultQtyCode;
                string itemQtyC = itemRow["ItemQTYCode"].ToString();
                if (!string.IsNullOrEmpty(itemQtyC.Trim())) QTYCode = itemQtyC;
                if (string.IsNullOrEmpty(QTYCode.Trim())) QTYCode = "NOS";

                string rawCountry = (itemRow["ItemCountry"] == DBNull.Value)
                    ? "" : itemRow["ItemCountry"].ToString().Replace("null", "").Trim();
                string ItemCountry = ResolveCountry(rawCountry, auto, itemCountryCache, countryCache);

                if (isEuropeanFmt)
                {
                    Quantity = SwapEuropeanDecimal(itemRow["Quantity"].ToString());
                    Rate = SwapEuropeanDecimal(itemRow["Rate"].ToString());
                    Amount = SwapEuropeanDecimal(itemRow["Amount"].ToString());
                }

                ApplyClientOverrides(ref ItemDesc, ref QTYCode, ref Quantity, ref Rate,
                    ref Amount, ref PartNo, ref MANUFACTURER, ref PRODUCT_END_USE,
                    ref Condition_Desc, ref HSCode, ref ItemCountry,
                    ExtraItemDesc, PONumber, NetWeight, imp_name, PdfClientName, isEuropeanFmt, itemRow);

                SetMasterLookupStrategy(erm, MasterCon, MasterDesc, ItemDesc, PartNo, HSCode, PONumber, Condition_Desc, ExtraItemDesc);
                erm.Eproduct_imp_ceth = imp_name;
                erm.EWorking_Period = Working_Period;

                string masterLookupKey = erm.Ename + "|" + (erm.Eproduct_imp_description ?? "") + "|" + (erm.Eproduct_imp_cth ?? "");
                if (!masterCache.ContainsKey(masterLookupKey))
                    masterCache[masterLookupKey] = erm.RetrieveAll_Import_PDF_Settings_MASTER();

                ds_get_data = masterCache[masterLookupKey];

                List<string> cthListFromDS = new List<string>();
                foreach (DataRow dr in ds_get_data.Tables[0].Rows)
                {
                    string ritc = dr["PRODUCT_RITC"].ToString().Trim();
                    if (!string.IsNullOrEmpty(ritc) && !cthListFromDS.Contains(ritc))
                        cthListFromDS.Add(ritc);
                }
                string CTH_List_Json = _jss.Serialize(cthListFromDS);

                string AIDC_CessNoti = "", AIDC_CessSlno = "", AIDC_CessRate = "", info_uqc = "";
                string IGST_Noti = "", IGST_SlNo = "", IGST_Rate = "";
                string IGST_LEVY_COMPENSATION_CESS_NOTN = "", IGST_LEVY_COMPENSATION_CESS_SLNO = "", IGST_LEVY_COMPENSATION_CESS_RATE = "";
                string Basic_Noti = "", Basic_Slno = "", Basic_Rate = "";
                string Info_Msr = "";
                string itemCountyof_orgin = ItemCountry;
                string SW_Noti = "", SW_Slno = "", SW_Rate = "", GENERAL_DESCRIPTION = "", BRANCH_COMMON = "", JOBNO = "", WORKING_PERIOD1 = "", BRANCH_CODE = "";
                string YEAR = "", FLAG = "", PREVIOUS_BE_DATE = "", ITEM_AMOUNT_CODE = "", ITEM_UNIT_CODE = "", USER_ID = "", RSP_APPLICABLE = "", PRODUCT_CETH = "";
                string PRODUCT_RITC = "", PRODUCT_CTH = "", COUNTRY_OF_ORIGIN = "", MODEL = "", BRAND = "", LEVY_EXCEMPTION_NOTN_TYPE = "", IGST_LEVY_EXCEPTION_RATE = "", IGST_LEVY_EXCEPTION_NOTN = "";
                string SVB_DUTY_STATUS = "", SVB_ASSESABLE_STATUS = "", SVB_DUTY_RATE = "", SVB_ASSESABLE_RATE = "", SVB_LOADING_ON = "", SVB_CUSTOM_HOUSE = "", SVB_REF_DATE = "", SVB_REF_NO = "", SVB_RELATION = "";

                //--------------

                ITEM_UNIT_CODE = txtCurrency.Text.ToUpper().Trim();
                ITEM_AMOUNT_CODE = txtCurrency.Text.ToUpper().Trim();
                PREVIOUS_BE_DATE = "01/01/1900";
                FLAG = "S";
                YEAR = "";
                USER_ID = currentuser;
                BRANCH_CODE = currentbranch;
                WORKING_PERIOD1 = Working_Period;
                JOBNO = Session["JOBNO"].ToString();
                BRANCH_COMMON = Connection.Get_Company_Type();
                GENERAL_DESCRIPTION = ItemDesc.Replace("СЕ", "CE").ToUpper();

                BRAND = "NA";
                MODEL = "NA";

                COUNTRY_OF_ORIGIN =
                    !string.IsNullOrEmpty(itemCountyof_orgin)
                        ? itemCountyof_orgin.Split('-')[0]
                        : "";

                PRODUCT_RITC = HSCode;
                PRODUCT_CTH = HSCode;
                PRODUCT_CETH = HSCode;

                RSP_APPLICABLE = "N";

                SVB_RELATION = "";
                SVB_REF_NO = "";
                SVB_REF_DATE = "";
                SVB_CUSTOM_HOUSE = "";
                SVB_LOADING_ON = "";
                SVB_ASSESABLE_RATE = "";
                SVB_DUTY_RATE = "";
                SVB_ASSESABLE_STATUS = "";
                SVB_DUTY_STATUS = "";

                IGST_LEVY_EXCEPTION_NOTN = "";
                IGST_LEVY_EXCEPTION_RATE = "";
                LEVY_EXCEMPTION_NOTN_TYPE = "";
                if (PdfClientName == "CATERPILLAR")
                {
                    SVB_RELATION = "false"; SVB_REF_NO = ""; SVB_REF_DATE = ""; SVB_CUSTOM_HOUSE = ""; SVB_LOADING_ON = "";
                    SVB_ASSESABLE_RATE = ""; SVB_DUTY_RATE = ""; SVB_ASSESABLE_STATUS = ""; SVB_DUTY_STATUS = "";
                }
                if (string.IsNullOrEmpty(HSCode))
                {
                    info_uqc = Get_Valid_Qty_Code(itemQtyC);
                }
                else if (!uqcCache.TryGetValue(HSCode, out info_uqc))
                {
                    try
                    {
                        Auto.Ename = "Get_CTH_Info_Uqc";
                        Auto.Enamesearch = HSCode;
                        Auto.Notn_No_Search = HSCode;
                        DataSet ds_MSR_UQC = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                        info_uqc = ds_MSR_UQC.Tables[0].Rows.Count > 0
                            ? ds_MSR_UQC.Tables[0].Rows[0][0].ToString()
                            : Get_Valid_Qty_Code(itemQtyC);
                    }
                    catch
                    {
                        info_uqc = Get_Valid_Qty_Code(itemQtyC);
                    }
                    uqcCache[HSCode] = info_uqc;
                }
                if (ds_get_data.Tables[0].Rows.Count > 0 && PDF_Master_Mode != "S")
                {
                    DataRow m = ds_get_data.Tables[0].Rows[0];
                    Basic_Noti = m["PRODUCT_BCD_NOTN"].ToString();
                    Basic_Slno = m["PRODUCT_BCD_SLNO"].ToString();
                    Basic_Rate = m["PRODUCT_BCD_RATE"].ToString();
                    itemCountyof_orgin = m["PRODUCT_COUNTRY_ORIGIN"].ToString();
                    SW_Noti = m["SOCIAL_WELFARE_NOTN"].ToString();
                    SW_Slno = m["SOCIAL_WELFARE_NOTN_SLNO"].ToString();
                    SW_Rate = m["SOCIAL_WELFARE_RATE"].ToString();
                    AIDC_CessNoti = m["AIDC_NOTN"].ToString();
                    AIDC_CessSlno = m["AIDC_NOTN_SLNO"].ToString();
                    AIDC_CessRate = m["AIDC_RATE"].ToString();
                    IGST_Noti = m["IGST_LEVY_NOTN"].ToString();
                    IGST_SlNo = m["IGST_LEVY_SLNO"].ToString();
                    IGST_Rate = m["IGST_LEVY_RATE"].ToString();
                    PartNo = m["PART_NO"].ToString();
                    IGST_LEVY_COMPENSATION_CESS_NOTN = m["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString();
                    IGST_LEVY_COMPENSATION_CESS_SLNO = m["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString();
                    IGST_LEVY_COMPENSATION_CESS_RATE = m["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString();
                    string Master_Description = m["PRODUCT_DESCRIPTION"].ToString();

      
                    if (cthListFromDS.Count == 1) HSCode = cthListFromDS[0];
                    //else if (cthListFromDS.Count > 1) HSCode = "";

                    //string Info_Uqc = Get_Valid_Qty_Code(QTYCode);
                    if (NetWeight != "" && NetWeight != null) Info_Msr = NetWeight.Replace(",", "");

                    if (string.IsNullOrEmpty(itemCountyof_orgin) || itemCountyof_orgin == string.Empty)
                        itemCountyof_orgin = ItemCountry;

                    if (COMPANY_IDD == "1069") ItemDesc = Master_Description.Trim();
                  
                    PRODUCT_END_USE = m["PRODUCT_END_USE"].ToString();

                    if (COMPANY_IDD == "2373")
                    {
                        PRODUCT_END_USE = "GNX200";
                    }

                    if (!string.IsNullOrEmpty(HSCode) && (string.IsNullOrEmpty(AIDC_CessRate) || string.IsNullOrEmpty(IGST_Rate)))
                    {
                        try
                        {
                            if (string.IsNullOrEmpty(AIDC_CessRate))
                            {
                                AIDC_CessRate = aidc_Cache.ContainsKey(HSCode)
                                    ? aidc_Cache[HSCode]["AIDC_NOTN_RATE"].ToString() : "0.00";
                            }

                            if (!string.IsNullOrEmpty(IGST_Noti) && !string.IsNullOrEmpty(IGST_SlNo))
                            {
                                string igstKey = IGST_Noti + "|" + IGST_SlNo;
                                if (!igstRateCache.ContainsKey(igstKey))
                                {
                                    Auto_Search autoIG = new Auto_Search();
                                    autoIG.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_SLNO_IGST_1E";
                                    autoIG.Enamesearch = IGST_SlNo;
                                    autoIG.Notn_No_Search = IGST_Noti;
                                    DataSet dsIG = autoIG.RetrieveAll_AUTOCOMPLETE_SEARCH();
                                    igstRateCache[igstKey] = dsIG.Tables[0].Rows.Count > 0
                                        ? dsIG.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString() : "";
                                }
                                IGST_Rate = igstRateCache[IGST_Noti + "|" + IGST_SlNo];

                                if (!string.IsNullOrEmpty(IGST_LEVY_COMPENSATION_CESS_NOTN)
                                    && !string.IsNullOrEmpty(IGST_LEVY_COMPENSATION_CESS_SLNO))
                                    IGST_LEVY_COMPENSATION_CESS_RATE = "0.00";
                            }

                            if (!string.IsNullOrEmpty(Basic_Slno) && !string.IsNullOrEmpty(Basic_Noti))
                            {
                                string bcdKey = Basic_Noti + "|" + Basic_Slno;
                                if (!bcdRateCache.ContainsKey(bcdKey))
                                {
                                    Auto_Search autoBN = new Auto_Search();
                                    autoBN.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_SLNO";
                                    autoBN.Enamesearch = Basic_Slno;
                                    autoBN.Notn_No_Search = Basic_Noti;
                                    DataSet dsBN = autoBN.RetrieveAll_AUTOCOMPLETE_SEARCH();
                                    bcdRateCache[bcdKey] = dsBN.Tables[0].Rows.Count > 0
                                        ? dsBN.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString() : "";
                                }
                                Basic_Rate = bcdRateCache[Basic_Noti + "|" + Basic_Slno];
                            }
                        }
                        catch { }
                    }

                    Dt_Item.Rows.Add(ItemInvoiceSlNo, ItemSlNo, ItemDesc.Trim(), Quantity.Replace(",", ""), Rate.Replace(",", ""), Amount.Replace(",", ""), Get_Valid_Qty_Code(QTYCode), HSCode, "00 - DUTIABLE", "", "",
                      Basic_Noti, Basic_Slno, Basic_Rate, Info_Msr, info_uqc, MANUFACTURER, PRODUCT_END_USE, itemCountyof_orgin, SW_Noti, SW_Slno, SW_Rate, AIDC_CessNoti, AIDC_CessSlno, AIDC_CessRate,
                      IGST_Noti, IGST_SlNo, IGST_Rate, PartNo, IGST_LEVY_COMPENSATION_CESS_NOTN, IGST_LEVY_COMPENSATION_CESS_SLNO, IGST_LEVY_COMPENSATION_CESS_RATE, ITEM_UNIT_CODE, ITEM_AMOUNT_CODE, PREVIOUS_BE_DATE,
                      FLAG, YEAR, USER_ID, BRANCH_CODE, WORKING_PERIOD1, JOBNO, BRANCH_COMMON, GENERAL_DESCRIPTION, BRAND, MODEL, COUNTRY_OF_ORIGIN, PRODUCT_RITC, PRODUCT_CTH, PRODUCT_CETH, RSP_APPLICABLE, SVB_RELATION, SVB_REF_NO,
                      SVB_REF_DATE, SVB_CUSTOM_HOUSE, SVB_LOADING_ON, SVB_ASSESABLE_RATE, SVB_DUTY_RATE, SVB_ASSESABLE_STATUS, SVB_DUTY_STATUS, IGST_LEVY_EXCEPTION_NOTN, IGST_LEVY_EXCEPTION_RATE, LEVY_EXCEMPTION_NOTN_TYPE, CTH_List_Json);
                }
                else
                {
                    //string Info_Uqc = Get_Valid_Qty_Code(QTYCode);
                    if (NetWeight != "" && NetWeight != null) Info_Msr = NetWeight.Replace(",", "");

                    if (HSCode != "" && HSCode != string.Empty)
                    {
                        if (aidc_Cache.ContainsKey(HSCode))
                        {
                            AIDC_CessNoti = aidc_Cache[HSCode]["AIDC_NOTN_NO"].ToString();
                            AIDC_CessSlno = aidc_Cache[HSCode]["AIDC_NOTN_SLNO"].ToString();
                            AIDC_CessRate = aidc_Cache[HSCode]["AIDC_NOTN_RATE"].ToString();
                        }
                        else
                        {
                            AIDC_CessNoti = "011/2021";
                            AIDC_CessSlno = "17";
                            AIDC_CessRate = "0.00";
                        }

                        if (igst_Cache.ContainsKey(HSCode))
                        {
                            IGST_Noti = igst_Cache[HSCode]["LEVY_1NOTIFICATION"].ToString();
                            IGST_SlNo = igst_Cache[HSCode]["LEVY_1NOTIFICATION_SLNO"].ToString();
                            IGST_Rate = igst_Cache[HSCode]["LEVY_1NOTIFICATION_RATE"].ToString();
                            if (IGST_Noti != "")
                            {
                                IGST_LEVY_COMPENSATION_CESS_NOTN = "001/2017";
                                IGST_LEVY_COMPENSATION_CESS_SLNO = "56";
                                IGST_LEVY_COMPENSATION_CESS_RATE = "0.00";
                            }
                        }
                    }

                    Dt_Item.Rows.Add(ItemInvoiceSlNo, ItemSlNo, ItemDesc, Quantity.Replace(",", ""), Rate.Replace(",", ""), Amount.Replace(",", ""), Get_Valid_Qty_Code(QTYCode), HSCode, "00 - DUTIABLE", "", "", "", "", "",
                        Info_Msr, info_uqc, MANUFACTURER, PRODUCT_END_USE, ItemCountry, "", "", "", AIDC_CessNoti, AIDC_CessSlno, AIDC_CessRate, IGST_Noti, IGST_SlNo, IGST_Rate, PartNo,
                        IGST_LEVY_COMPENSATION_CESS_NOTN, IGST_LEVY_COMPENSATION_CESS_SLNO, IGST_LEVY_COMPENSATION_CESS_RATE, ITEM_UNIT_CODE, ITEM_AMOUNT_CODE, PREVIOUS_BE_DATE,
                      FLAG, YEAR, USER_ID, BRANCH_CODE, WORKING_PERIOD1, JOBNO, BRANCH_COMMON, GENERAL_DESCRIPTION, BRAND, MODEL, COUNTRY_OF_ORIGIN, PRODUCT_RITC, PRODUCT_CTH, PRODUCT_CETH, RSP_APPLICABLE, SVB_RELATION, SVB_REF_NO,
                      SVB_REF_DATE, SVB_CUSTOM_HOUSE, SVB_LOADING_ON, SVB_ASSESABLE_RATE, SVB_DUTY_RATE, SVB_ASSESABLE_STATUS, SVB_DUTY_STATUS, IGST_LEVY_EXCEPTION_NOTN, IGST_LEVY_EXCEPTION_RATE, LEVY_EXCEMPTION_NOTN_TYPE, "[]");
                }
            }
        }
        finally { Dt_Item.EndLoadData(); }
    }
    // ─── GET UPLOAD FILE ────────
    public string Get_Upload_File()
    {
        string response = "";
        string PDF_Master_Mode = hdn_PDF_Master.Value;

        try
        {
            string savePath = Server.MapPath("~/Submission/ImportPDFReader/");
            if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);

            int fileCount = Request.Files.Count;
            ViewState["FileUploadCount"] = fileCount;

            Upload_Count = "1";
            Upload_page_Count = "1";
            Upload_Error_Count = "1";

            string imp_name = "", branch_slno = "", PdfClient_Name = "";
            if (ddl_ImporterName.SelectedValue.Contains("--"))
            {
                string[] sp = ddl_ImporterName.SelectedValue.Replace("--", "^").Split('^');
                branch_slno = sp[0];
                imp_name = sp[1];
                ViewState["branch_slno"] = branch_slno;
                ViewState["imp_name"] = imp_name;
                PdfClient_Name = Get_PdfClient_Name(imp_name, branch_slno);
                if (!string.IsNullOrWhiteSpace(PdfClient_Name))
                    ViewState["PdfClient_Name"] = PdfClient_Name;
            }

            var countryCache = BuildCountryCache();

            bool isEuropeanNumberFormat =
                imp_name == "Atlas Copco (India) Private limited" || imp_name == "SIEMENS LTD" || imp_name == "Royal Tech" || imp_name == "RELIANCE CONSUMER PRODUCTS LTD" || imp_name == "SIEMENS HEALTHCARE PRIVATE LIMITED" || PdfClient_Name == "GODREJ & BOYCE MFG. CO. LTD."
                || PdfClient_Name == "LIFETECH" || PdfClient_Name == "PPG" || PdfClient_Name == "ALFA LAVAL" || PdfClient_Name == "VEGA" || PdfClient_Name == "BOSCH ALFATEC" || PdfClient_Name == "MAHR";

            InitDataTables();

            for (int ai = 0; ai < fileCount; ai++)
            {
                HttpPostedFile uploadedFile = Request.Files[ai];
                if (uploadedFile == null || uploadedFile.ContentLength == 0) continue;

                string strFolderPath = Path.Combine(Request.PhysicalApplicationPath, savePath);
                string strImagePath = Path.Combine(strFolderPath, uploadedFile.FileName.ToString());
                uploadedFile.SaveAs(strImagePath);

                if (Path.GetExtension(strImagePath).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    PdfReader reader = null;
                    try
                    {
                        reader = new PdfReader(strImagePath);
                        hd_PageCount.Value = reader.NumberOfPages.ToString();
                    }
                    catch { }
                    finally { if (reader != null) reader.Close(); }
                }
               
                checkvendor();
                
                string API_Output = "";
                if (vendor == "Local")
                {
                    WriteJobLog("API Hitting", "Vendor:Local | File:" + uploadedFile.FileName);
                    var apiStart = DateTime.Now;
                    string fileBase = Path.GetFileNameWithoutExtension(uploadedFile.FileName);
                    ds_API = Get_AccessToken_Invoice(GetLocalAPIData,
                        Server.MapPath("~/Submission/ImportPDFReader/Local_Test/" + fileBase + ".txt"));
                    WriteJobLog("API Response Received", "Vendor:Local | File:" + uploadedFile.FileName
                        + " | TimeTaken:" + (DateTime.Now - apiStart).TotalSeconds.ToString("0.00") + "s");
                }
                else if (vendor == "Royal")
                {
                    WriteJobLog("API Hitting", "Vendor:Royal | File:" + uploadedFile.FileName);
                    var apiStart = DateTime.Now;
                    API_Output = UploadPdfExtraction(strImagePath, PdfClient_Name);
                    WriteJobLog("API Response Received", "Vendor:Royal | File:" + uploadedFile.FileName
                        + " | TimeTaken:" + (DateTime.Now - apiStart).TotalSeconds.ToString("0.00") + "s");
                    int pdfId = PageCount_log(PdfStatus.PREVIEW_INITIATED, hd_PageCount.Value);
                    ViewState["Pdf_Id"] = pdfId.ToString();
                    ds_API = JsonConvert.DeserializeObject<DataSet>(API_Output);
                }
                 else if (vendor == "Docker_Vision" || vendor == "" || vendor == null)
                {
                    string vendorName = string.IsNullOrEmpty(vendor) ? "Docker_Vision" : vendor;
                    WriteJobLog("API Hitting", "Vendor:" + vendorName + " | File:" + uploadedFile.FileName);
                    var apiStart = DateTime.Now;
                    API_Output = UploadPdfWithParameters(strImagePath);
                    WriteJobLog("API Response Received", "Vendor:" + vendorName + " | File:" + uploadedFile.FileName
                        + " | TimeTaken:" + (DateTime.Now - apiStart).TotalSeconds.ToString("0.00") + "s");
                    int pdfId = PageCount_log(PdfStatus.PREVIEW_INITIATED, hd_PageCount.Value);
                    ViewState["Pdf_Id"] = pdfId.ToString();
                    ds_API = JsonConvert.DeserializeObject<DataSet>(API_Output);
                }
                else if (vendor == DockerVisionQueueClient.VENDOR_TYPE)
                {
                    // Fire-and-forget queue path (distinct from the synchronous "Docker_Vision" branch above):
                    // submit and return immediately — the extraction result comes back later via the
                    // FireForget callback API and is picked up in Page_Load when the user reopens with ?pid=.
                    // Same multipart contract UploadPdfWithParameters already uses successfully (see
                    // DockerVisionQueueClient remarks) — only ProcessId/CallbackUrl are new.
                    WriteJobLog("API Hitting", "Vendor:DOCKER_VISION | File:" + uploadedFile.FileName);
                    var dvStart = DateTime.Now;

                    string processIdDV;
                    string dvError;
                    bool submitted = DockerVisionQueueClient.SubmitAndForget(
                        filePath: strImagePath,
                        fileName: uploadedFile.FileName,
                        companyId: Connection.Company_License(),
                        userId: Connection.Current_User(),
                        branchCode: Connection.Current_Branch(),
                        jobNo: txtjobPS.Text.Trim(),
                        jobType: "IMP",
                        workingPeriod: Working_Period,
                        pdfClientName: PdfClient_Name,
                        eriId: Connection.Company_License(),
                        processId: out processIdDV,
                        errorMessage: out dvError);

                    WriteJobLog("API Response Received", "Vendor:DOCKER_VISION | ProcessId:" + processIdDV
                        + " | Submitted:" + submitted
                        + " | TimeTaken:" + (DateTime.Now - dvStart).TotalSeconds.ToString("0.00") + "s");

                    if (submitted)
                    {
                        int pdfId = PageCount_log(PdfStatus.PREVIEW_INITIATED, hd_PageCount.Value);
                        ViewState["Pdf_Id"] = pdfId.ToString();

                        Global_variables QueueInsertObj = new Global_variables();
                        QueueInsertObj.A2 = uploadedFile.FileName;         // FILE_NAME
                        // "-<pdfId>" suffix: PDF_AI_QUEUE_INSERT_UPDATE_SELECT splits VENDOR_TYPE on the
                        // first '-' into VENDOR_TYPE + PDF_ID (same convention Export's Insert_Queue_Record
                        // uses for PMDG), so UPDATE_JOBNO can later link this row to PDF_AI_COUNT_DETAILS.
                        QueueInsertObj.A3 = DockerVisionQueueClient.VENDOR_TYPE + "-" + pdfId; // VENDOR_TYPE
                        QueueInsertObj.A4 = processIdDV;                   // PROCESS_ID
                        QueueInsertObj.A5 = imp_name;                      // IMPORTER_NAME
                        QueueInsertObj.A10 = "IMP";                        // JOB_TYPE
                        QueueInsertObj.A16 = branch_slno;                  // SL_NO
                        QueueInsertObj.A17 = PdfClient_Name;               // PDF_CLIENT_NAME
                        new AI_Queue().Queue_Insert(QueueInsertObj);

                        WriteJobLog("Job Queued", "Vendor:DOCKER_VISION | ProcessId:" + processIdDV);
                        Alert_And_Redirect_Queue_Import(
                            "Extraction is in progress. Your job has been queued. Click OK to view Queue Status.");
                    }
                    else
                    {
                        WriteJobLog("Preview Failed", "Vendor:DOCKER_VISION | " + dvError);
                        Alert_msg("Failed to submit job to Docker Vision. Please try again.");
                    }
                    return; // exit Get_Upload_File early — no queue row when the submit itself failed
                }


                if (ds_API.Tables[0].Rows.Count == 0
                    || ds_API.Tables[1].Rows.Count == 0
                    || ds_API.Tables[2].Rows.Count == 0) continue;

                FillHeaderFields(ds_API, imp_name, branch_slno, countryCache);
                INVOICE_SLNO++;
                FillInvoiceRows(ds_API, fileCount, imp_name, PdfClient_Name, isEuropeanNumberFormat);
                FillIGMAndContainerRows(ds_API);
                ProcessItemsBatch(ds_API, fileCount, imp_name, PdfClient_Name,
                    isEuropeanNumberFormat, PDF_Master_Mode, countryCache);

                ViewState["ItemDetails"] = Dt_Item;
                ViewState["GridViewData"] = Dt_Item;

                BindGridPaged(1);
                TimeSpan extractionDuration = DateTime.Now - extractionStartTime;
 
 
 
                lbl_LiveExtractionTimer.Text = string.Format("End Time- {0:mm\\:ss}", extractionDuration);

                lbl_loading.Text = "<span style='color: green; font-weight: bold;'>✅ File converted successfully... Click Upload.</span>";
                btnupload.Visible = true;
                btnDeleteSelected.Visible = true;

                if (gv_ItemPDF.Rows.Count > 0)
                {
                    hdn_missed_Desc.Value = "0";

                    var hsList = new List<string>();
                    if (ds_get_data != null && ds_get_data.Tables.Count > 0 && ds_get_data.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds_get_data.Tables[0].Rows)
                        {
                            string code = dr["PRODUCT_RITC"].ToString();
                            if (!string.IsNullOrEmpty(code)) hsList.Add(code);
                        }
                    }
                    HSCodeJson = _jss.Serialize(hsList);

                    DataTable dtListBox = Dt_Item.Rows.Count > 1000
                        ? Dt_Item.AsEnumerable().Take(1000).CopyToDataTable() : Dt_Item;

                    ListBox_ItemSlno.DataSource = dtListBox;
                    ListBox_ItemSlno.DataTextField = "ItemSlNo";
                    ListBox_ItemSlno.DataValueField = "ItemSlNo";
                    ListBox_ItemSlno.DataBind();
                }

                if (gv_ItemPDF.Rows.Count > 0) { Select_ItemRITC(); Get_AdCode(); }

                lblmsg.Text = "";

                if (gv_ItemPDF.HeaderRow != null)
                {
                    gv_ItemPDF.UseAccessibleHeader = true;
                    gv_ItemPDF.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                Upload_Count = "0";
                Upload_page_Count = "0";
                PageCount_log(PdfStatus.PREVIEW_SUCCESS, hd_PageCount.Value);
                WriteJobLog("Preview Success", "File:" + uploadedFile.FileName + " | Pages:" + GetPageCountForLog());
                Session["ImportPdfAI_PreviewSuccess"] = "1";
            }
        }
        catch (WebException webEx)
        {
            if (webEx.Response != null)
            {
                using (var er = (HttpWebResponse)webEx.Response)
                using (var rdr = new StreamReader(er.GetResponseStream()))
                    Console.WriteLine("WebException response: " + rdr.ReadToEnd());
            }
            Console.WriteLine("WebException: " + webEx.Message);
            LogException("Preview Failed", webEx);
        }
        catch (Exception ex)
        {
            PageCount_log(PdfStatus.PREVIEW_FAILED, hd_PageCount.Value);
            Upload_Error_Count = "0";
            Console.WriteLine("Error occurred: " + ex.Message);
            LogException("Preview Failed", ex);
        }

        return response;
    }

    // ─── BUILD COUNTRY CACHE ──────
    private Dictionary<string, string> BuildCountryCache()
    {
        var cached = HttpRuntime.Cache[CACHE_COUNTRY_MASTER] as Dictionary<string, string>;
        if (cached != null) return cached;

        var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        try
        {
            Auto_Search autoC = new Auto_Search();
            autoC.Ename = "COUNTRY_MASTER";
            autoC.Enamesearch = "";
            DataSet ds = autoC.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string fullName = row["COUNTRY_NAME"].ToString().Trim();
                    string[] parts = fullName.Split('-');
                    string nameKey = parts[0].Trim().ToUpperInvariant();
                    if (!dict.ContainsKey(nameKey)) dict[nameKey] = fullName;

                    if (parts.Length > 1)
                    {
                        string codeKey = parts[parts.Length - 1].Trim().ToUpperInvariant();
                        if (codeKey.Length == 2 && !dict.ContainsKey(codeKey))
                            dict[codeKey] = fullName;
                    }
                }
            }
        }
        catch { }

        HttpRuntime.Cache.Insert(CACHE_COUNTRY_MASTER, dict, null,
            DateTime.Now.AddMinutes(CACHE_MINUTES),
            System.Web.Caching.Cache.NoSlidingExpiration);

        return dict;
    }

    // ─── SMALL HELPERS ──────────────
    private string CleanHSCode(string raw)
    {
        string hs = raw.Replace(".", "").Replace("-", "").Replace(" ", "").Replace("null", "").Trim();
        return hs.Length > 8 ? hs.Substring(0, 8) : hs;
    }

    private string SwapEuropeanDecimal(string raw)
    {
        return raw.Replace(".", "").Replace(",", ".");
    }

    private string ResolveCountry(string raw, Auto_Search auto,
        Dictionary<string, string> itemCache, Dictionary<string, string> fullCache)
    {
        if (string.IsNullOrWhiteSpace(raw)) return raw;

        string cached;
        if (itemCache.TryGetValue(raw, out cached)) return cached;

        string resolved = raw;
        string key = raw.Trim().ToUpperInvariant();

        string fromFull;
        if (fullCache.TryGetValue(key, out fromFull))
        {
            resolved = fromFull.Contains('-') ? fromFull.Split('-')[0].Trim() : fromFull;
        }
        else
        {
            try
            {
                auto.Ename = (raw.Length == 2) ? "Get_CountryName" : "COUNTRY_MASTER";
                auto.Enamesearch = raw;
                DataSet ds = auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string full = ds.Tables[0].Rows[0]["COUNTRY_NAME"].ToString();
                    resolved = full.Contains('-') ? full.Split('-')[0].Trim() : full;
                }
            }
            catch { }
        }

        itemCache[raw] = resolved;
        return resolved;
    }

    // ─── GRID PAGING ──────────
    private void BindGridPaged(int pageIndex)
    {
        DataTable dt = ViewState["ItemDetails"] as DataTable;
        if (dt == null) return;

        gv_ItemPDF.AllowPaging = true;
        gv_ItemPDF.PageSize = 100;
        gv_ItemPDF.DataSource = dt;
        gv_ItemPDF.PageIndex = pageIndex - 1;
        gv_ItemPDF.DataBind();

        CurrentPageIndex = pageIndex - 1;
        UpdatePageControls();
    }

    protected void gv_ItemPDF_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGridPaged(e.NewPageIndex + 1);
    }

    protected void btnPrevPage_Click(object sender, EventArgs e)
    {
        SaveCurrentPageToDataTable(); // ← ADD THIS

        DataTable dt = ViewState["ItemDetails"] as DataTable;
        if (dt == null || dt.Rows.Count == 0) return;

        int current = CurrentPageIndex;
        if (current > 0)
            BindGridPaged(current);
    }
    protected void btnNextPage_Click(object sender, EventArgs e)
    {
        SaveCurrentPageToDataTable(); // ← ADD THIS
        bool isFiltered = ViewState["IsFiltered"] != null
                          && (bool)ViewState["IsFiltered"];

        DataTable dt = isFiltered
            ? ViewState["FilteredData"] as DataTable
            : ViewState["ItemDetails"] as DataTable;

        if (dt == null) return;
        int totalPages = (int)Math.Ceiling((double)dt.Rows.Count / 100.0);
        int current = CurrentPageIndex;

        if (current < totalPages - 1)
        {
            if (isFiltered) BindGridPaged_Filtered(current + 2);
            else BindGridPaged(current + 2);
        }
    }

    protected void btnFirstPage_Click(object sender, EventArgs e)
    {
        SaveCurrentPageToDataTable();
        BindGridPaged(1);
    }

    protected void btnLastPage_Click(object sender, EventArgs e)
    {
        SaveCurrentPageToDataTable();
        DataTable dt = ViewState["ItemDetails"] as DataTable;
        if (dt == null) return;
        int totalPages = (int)Math.Ceiling((double)dt.Rows.Count / 100.0);
        BindGridPaged(totalPages);
    }

    private void UpdatePageControls()
    {
        DataTable dt = ViewState["ItemDetails"] as DataTable;
        if (dt == null || dt.Rows.Count == 0)
        {
            lblPageInfo.Visible = false;
            btnFirstPage.Visible = false;
            btnPrevPage.Visible = false;
            btnNextPage.Visible = false;
            btnLastPage.Visible = false;
            return;
        }

        int totalPages = (int)Math.Ceiling((double)dt.Rows.Count / 100.0);
        int currentPage = CurrentPageIndex + 1;

        lblPageInfo.Text = "Page " + currentPage + " / " + totalPages + " (" + dt.Rows.Count + " rows)";
        lblPageInfo.Visible = true;
        btnFirstPage.Visible = true;
        btnPrevPage.Visible = true;
        btnNextPage.Visible = true;
        btnLastPage.Visible = true;

        btnFirstPage.Enabled = currentPage > 1;
        btnPrevPage.Enabled = currentPage > 1;
        btnNextPage.Enabled = currentPage < totalPages;
        btnLastPage.Enabled = currentPage < totalPages;
    }

    // ─── UPLOAD PDF WITH PARAMETERS ─────────────────────────────────────────
    public string UploadPdfWithParameters(string FilePath)
    {
        string result = "";
        string imp_name = ViewState["imp_name"].ToString().Trim();
        string PdfClient_Name = "";

        if (ViewState["PdfClient_Name"] != null && !string.IsNullOrWhiteSpace(ViewState["PdfClient_Name"].ToString()))
            PdfClient_Name = ViewState["PdfClient_Name"].ToString().Trim();

        if (!string.IsNullOrWhiteSpace(imp_name) && string.IsNullOrWhiteSpace(PdfClient_Name))
        {
            if (imp_name.Contains("~"))
            {
                PdfClientName = imp_name.Split(' ')[0] + " " + imp_name.Split('~')[1];
            }
            else
            {
                if (imp_name == "SIEMENS HEALTHCARE PRIVATE LIMITED" || imp_name == "CUMMINS INDIA LIMITED" || imp_name == "GODREJ AND BOYCE MFG CO LTD" || imp_name == "RELIANCE RETAIL LIMITED")
                {
                    PdfClientName = imp_name;
                }
                else if (imp_name == "EPIROC MINING INDIA PRIVATE LIMITED" || imp_name == "CUMMINS TECHNOLOGIES INDIA PVT LTD" || imp_name == "Atlas Copco (India) Private limited"
                       || imp_name == "SBM BANK (INDIA) LIMITED" || imp_name == "DONALDSON INDIA FILTER SYSTEMS PVT LTD" || imp_name == "SILVER SPARK APPAREL LTD."
                      || imp_name == "ALFA LAVAL INDIA PRIVATE LIMITED" || imp_name == "LG ELECTRONICS INDIA LTD." || imp_name == "SHINDENGEN INDIA PRIVATE LIMITEDS")
                {
                    PdfClientName = imp_name.Split(' ')[0] + " " + imp_name.Split(' ')[1];
                }
                else if (imp_name == "DELPHI-TVS TECHNOLOGIES LIMITED") { PdfClientName = "DELPHI TVS"; }
                else { PdfClientName = imp_name.Split(' ')[0]; }
            }
        }
        else { PdfClientName = PdfClient_Name; }

        ViewState["PdfClientName"] = PdfClientName;

        string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
        byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
        byte[] trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

        HttpWebRequest request;
        if (PdfClientName.Equals("Nordex", StringComparison.OrdinalIgnoreCase))
        {
            request = (HttpWebRequest)WebRequest.Create("http://www.ocrapiservice.royaltechsystems.co.in/api/invoice/royaltechocr");
            request.Headers.Add("ApiKey", "Royal");
        }
        else
        {
            request = (HttpWebRequest)WebRequest.Create("https://asia-south1-serene-essence-419307.cloudfunctions.net/royal-invoice");
            request.Headers.Add("ApiKey", "12345");
        }

        request.Method = "POST";
        request.ContentType = "multipart/form-data; boundary=" + boundary;
        request.KeepAlive = true;
        request.AllowWriteStreamBuffering = false;
        request.SendChunked = true;
        request.Timeout = 10 * 60 * 1000;
        request.ReadWriteTimeout = 10 * 60 * 1000;

        Stream requestStream = request.GetRequestStream();

        NameValueCollection formFields = new NameValueCollection
        {
            { "CompanyID", Connection.Company_License() },
            { "UserID", Connection.Current_User() },
            { "BranchCode", Connection.Current_Branch() },
            { "JobNo", txtjobPS.Text.Trim() },
            { "JobType", "IMP" },
            { "WorkingPeriod", Connection.WorkingPeriod() },
            { "PageCount", "0" },
            { "PdfCount", "0" },
            { "JobStatus", "N" },
            { "FileName", "1" },
            { "InvoiceStartTime", DateTime.Now.ToString() },
            { "PdfClientName", PdfClientName }
        };

        foreach (string key in formFields)
        {
            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            string fieldData = "Content-Disposition: form-data; name=\"" + key + "\"\r\n\r\n" + formFields[key];
            byte[] fieldBytes = Encoding.UTF8.GetBytes(fieldData);
            requestStream.Write(fieldBytes, 0, fieldBytes.Length);
        }

        requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
        string header = "Content-Disposition: form-data; name=\"File\"; filename=\""
            + Path.GetFileName(FilePath) + "\"\r\nContent-Type: application/pdf\r\n\r\n";
        byte[] headerBytes = Encoding.UTF8.GetBytes(header);
        requestStream.Write(headerBytes, 0, headerBytes.Length);

        using (var fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 131072))
        {
            byte[] buffer = new byte[131072];
            int bytesRead;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                requestStream.Write(buffer, 0, bytesRead);
        }

        requestStream.Write(trailer, 0, trailer.Length);
        requestStream.Close();

        using (WebResponse webResp = request.GetResponse())
        using (StreamReader reader = new StreamReader(webResp.GetResponseStream()))
        {
            result = reader.ReadToEnd();
        }
        return result;
    }

    // ─── BIND GRID VIEW DATA ───────
    public bool BindgridViewData()
    {
        if (ViewState["ItemDetails"] == null)
        {
            Dt_Item = new DataTable();
            ViewState["ItemDetails"] = Dt_Item;
            return IsValid;
        }

        Dt_Item = (DataTable)ViewState["ItemDetails"];

        if (Dt_Item.Rows.Count > 0)
        {
            foreach (GridViewRow row in gv_ItemPDF.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow) continue;

                TextBox txtInvSlNoCtrl = (TextBox)row.FindControl("txtInvSlNo");
                TextBox txtItemSlNoCtrl = (TextBox)row.FindControl("txtItemSlNo");
                if (txtInvSlNoCtrl == null || txtItemSlNoCtrl == null) continue;

                string invKey = txtInvSlNoCtrl.Text.Trim();
                string itemKey = txtItemSlNoCtrl.Text.Trim();

                DataRow[] matched = Dt_Item.Select(
                    "InvoiceSlNo='" + invKey + "' AND ItemSlNo='" + itemKey + "'");
                if (matched.Length == 0) continue;
                DataRow dr = matched[0];

                TextBox txtItemDesc = (TextBox)row.FindControl("txtItemDesc");
                TextBox txtQTYCode = (TextBox)row.FindControl("txtQTYCode");
                TextBox txtCTH = (TextBox)row.FindControl("txt_CTH");
                TextBox txtBasicNoti = (TextBox)row.FindControl("txtBasicNoti");
                TextBox txtBasicSlno = (TextBox)row.FindControl("txtBasicSlno");
                TextBox txt_Basic_Rate = (TextBox)row.FindControl("txt_Basic_Rate");
                TextBox txt_Manufacturer = (TextBox)row.FindControl("txt_Manufacturer");
                TextBox txtEndUseOfItems = (TextBox)row.FindControl("txtEndUseOfItems");
                TextBox txtitemCounty = (TextBox)row.FindControl("txtitemCountyoforgin");
                TextBox txtSW_Noti = (TextBox)row.FindControl("txt_SW_Noti");
                TextBox txtSW_Slno = (TextBox)row.FindControl("txt_SW_Slno");
                TextBox txtSW_Rate = (TextBox)row.FindControl("txtSW_Rate");
                TextBox txt_AIDCNoti = (TextBox)row.FindControl("txt_AIDCCessNoti");
                TextBox txt_AIDCSlno = (TextBox)row.FindControl("txt_AIDCCessSlno");
                TextBox txt_AIDCRate = (TextBox)row.FindControl("txt_AIDCCessRate");
                TextBox txt_IGSTNoti = (TextBox)row.FindControl("txt_IGSTNoti");
                TextBox txt_IGSTSlNo = (TextBox)row.FindControl("txt_IGSTSlNo");
                TextBox txt_IGSTRate = (TextBox)row.FindControl("txt_IGSTRate");
                TextBox txtItemQty = (TextBox)row.FindControl("txtItemQty");
                TextBox txtItemAmt = (TextBox)row.FindControl("txtItemAmt");
                TextBox txtItemUnitPrice = (TextBox)row.FindControl("txtItemUnitPrice");
                DropDownList ddl_Scheme = (DropDownList)row.FindControl("ddl_SchemeCode");
                DropDownList ddl_NOTN = (DropDownList)row.FindControl("ddl_Scheme_NOTN");
                DropDownList ddl_NOTN_SL = (DropDownList)row.FindControl("ddl_Scheme_NOTN_SL");

                if (txtItemDesc != null) dr["ITEM_DESC"] = txtItemDesc.Text;
                if (txtQTYCode != null) dr["QtyCode"] = txtQTYCode.Text;
                if (txtCTH != null) dr["HSCode"] = txtCTH.Text;
                if (txtBasicNoti != null) dr["Basic_Noti"] = txtBasicNoti.Text;
                if (txtBasicSlno != null) dr["Basic_Slno"] = txtBasicSlno.Text;
                if (txt_Basic_Rate != null) dr["Basic_Rate"] = txt_Basic_Rate.Text;
                if (txt_Manufacturer != null) dr["MANUFACTURER"] = txt_Manufacturer.Text;
                if (txtEndUseOfItems != null)
                {
                    string eu = txtEndUseOfItems.Text.Trim();
                    dr["END_USE_OF_ITEM"] = eu.Contains('-') ? eu.Split('-')[0] : eu;
                }
                if (txtitemCounty != null)
                {
                    string co = txtitemCounty.Text.Trim();
                    dr["itemCountyof_orgin"] = co.Contains('-') ? co.Split('-')[0] : co;
                }
                if (txtSW_Noti != null) dr["SW_Noti"] = txtSW_Noti.Text;
                if (txtSW_Slno != null) dr["SW_Slno"] = txtSW_Slno.Text;
                if (txtSW_Rate != null) dr["SW_Rate"] = txtSW_Rate.Text;
                if (txt_AIDCNoti != null) dr["AIDC_CessNoti"] = txt_AIDCNoti.Text;
                if (txt_AIDCSlno != null) dr["AIDC_CessSlno"] = txt_AIDCSlno.Text;
                if (txt_AIDCRate != null) dr["AIDC_CessRate"] = txt_AIDCRate.Text;
                if (txt_IGSTNoti != null) dr["IGST_Noti"] = txt_IGSTNoti.Text;
                if (txt_IGSTSlNo != null) dr["IGST_SlNo"] = txt_IGSTSlNo.Text;
                if (txt_IGSTRate != null) dr["IGST_Rate"] = txt_IGSTRate.Text;
                if (txtItemQty != null) dr["Quantity"] = txtItemQty.Text;
                if (txtItemUnitPrice != null) dr["Rate"] = txtItemUnitPrice.Text;
                if (txtItemAmt != null) dr["Amount"] = txtItemAmt.Text;
                if (ddl_Scheme != null) dr["SchemeCode"] = ddl_Scheme.SelectedValue;
                if (ddl_NOTN != null) dr["Scheme_NOTN"] = ddl_NOTN.SelectedValue;
                if (ddl_NOTN_SL != null) dr["Scheme_NOTN_SL"] = ddl_NOTN_SL.SelectedValue;
            }

            ViewState["ItemDetails"] = Dt_Item;

            // ── Validate ALL rows across ALL pages ─────
            for (int rowIdx = 0; rowIdx < Dt_Item.Rows.Count; rowIdx++)
            {
                DataRow dr = Dt_Item.Rows[rowIdx];

                string itemDesc = dr["ITEM_DESC"].ToString().Trim();
                string cth = dr["HSCode"].ToString().Trim();
                string qtyCode = dr["QtyCode"].ToString().Trim();
                string aidcNoti = dr["AIDC_CessNoti"].ToString().Trim();
                string aidcSlno = dr["AIDC_CessSlno"].ToString().Trim();
                string aidcRate = dr["AIDC_CessRate"].ToString().Trim();
                string igstNoti = dr["IGST_Noti"].ToString().Trim();
                string igstSlno = dr["IGST_SlNo"].ToString().Trim();
                string igstRate = dr["IGST_Rate"].ToString().Trim();
                string mfr = dr["MANUFACTURER"].ToString().Trim();
                string endUse = dr["END_USE_OF_ITEM"].ToString().Trim();
                string country = dr["itemCountyof_orgin"].ToString().Trim();
                string qty = dr["Quantity"].ToString().Trim();
                string rate = dr["Rate"].ToString().Trim();
                string amount = dr["Amount"].ToString().Trim();

                string missingField = "";
                if (itemDesc == "") missingField = "Item Desc";
                else if (cth == "" || cth.Length != 8) missingField = "CTH (must be 8 digits)";
                else if (aidcNoti == "") missingField = "AIDC Notn";
                else if (aidcSlno == "") missingField = "AIDC SlNo";
                else if (aidcRate == "") missingField = "AIDC Rate";
                else if (igstNoti == "" && COMPANY_IDD != "151") missingField = "IGST Notn";
                else if (igstSlno == "" && COMPANY_IDD != "151") missingField = "IGST Sl.No";
                else if (igstRate == "" && COMPANY_IDD != "151") missingField = "IGST Rate";
                else if (mfr == "") missingField = "Manufacturer";
                else if (endUse == "") missingField = "End Use";
                else if (country == "") missingField = "Item Country";
                else if (qtyCode == "" || qtyCode.Length != 3) missingField = "Item QTY Code (must be 3 chars)";
                else if (rate == "") missingField = "Unit Price";
                else if (amount == "") missingField = "Amount";
                else if (qty == "") missingField = "Quantity";

                if (missingField != "")
                {
                    IsValid = false;

                    int targetPage = (rowIdx / gv_ItemPDF.PageSize) + 1;
                    BindGridPaged(targetPage);

                    string invNo = dr["InvoiceSlNo"].ToString();
                    string itemNo = dr["ItemSlNo"].ToString();

                    Alert_msg("Row (Inv:" + invNo + " Item:" + itemNo
                        + ") — Please fill: " + missingField);

                    ScriptManager.RegisterStartupScript(this, this.GetType(),
    "highlightRow",
    "<script>setTimeout(function(){ highlightMissingRow('"
    + invNo + "','" + itemNo + "','" + missingField + "'); }, 3000);</script>",
    false);

                    return false;
                }
            }
        }
        else
        {
            Dt_Item = new DataTable();
            ViewState["ItemDetails"] = Dt_Item;
        }

        return IsValid;
    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
        WriteJobLog("Button Click", "UPLOAD clicked | JobNo:" + txtjobPS.Text.Trim());
        try
        {
            if (txtjobPS.Text != "" && txtjobPS.Text != string.Empty)
            {
                SaveCurrentPageToDataTable();
                bool valid = BindgridViewData();
                if (valid)
                {
                    i = insert_update("", "S");
                    if (i == 1)
                    {
                        // If this job was loaded from the AI Extraction Queue (?pid=...), link the queue
                        // row to the real job number now, mirroring Export_PDF_Reader_New_AI.btnupload_Click.
                        // Must happen before AUTO_JOBNO() resets txtjobPS.Text below.
                        string dvPid = Request.QueryString["Pid"];
                        if (!string.IsNullOrEmpty(dvPid))
                        {
                            Global_variables QObj = new Global_variables();
                            QObj.A1 = txtjobPS.Text.Trim();
                            QObj.A2 = dvPid;
                            new AI_Queue().Job_No_Update(QObj);
                        }

                        AUTO_JOBNO();
                        lbl_loading.Text = "<span style='color: green; font-weight: bold;'>✅ Job Created Successfully...</span>";

                        string jobId = Session["JOBIDexcel"] != null ? Session["JOBIDexcel"].ToString() : "";

                        string script = @"$(document).ready(function() {
                          showChecklistPopup();
                        setTimeout(function() {
            closePopup();
            try {
                window.parent.adcodewindow.close();
            } catch(e) {}
            
            if (window.parent && window.parent.General_Details_Update) {
                window.parent.General_Details_Update('" + jobId + @"');
            } else {
                window.parent.location.reload();
            }
            
        }, 7000);
    });";

                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "successPopup", script, true);
                        txtjobPS.Text = Current_JOB;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            PageCount_log(PdfStatus.UPLOAD_FAILED, hd_PageCount.Value);
            LogException("Job Failed", ex);
            Connection.Error_Msg(ex.Message);
        }
    }

    // ─── INSERT UPDATE ───────
    public int insert_update(string jobid, string flag)
    {
        PageCount_log(PdfStatus.UPLOAD_INITIATED, hd_PageCount.Value);
        AUTO_JOBNO();

        string ImporterNameBranch = ddl_ImporterName.SelectedItem.Text;
        int index = ImporterNameBranch.IndexOf("--");
        string Branch = ImporterNameBranch.Substring(0, index);
        string Importer = ImporterNameBranch.Substring(index + 2);
        string country_Name = txtCountryOfOrigin.Text;

        decimal Total_invoice_value = 0;
        decimal Total_Freight_value = 0;

        string imp_name = ViewState["imp_name"].ToString().Trim();
        if (imp_name.Contains("~")) imp_name = imp_name.Split('~')[0].Trim();
        Importer = imp_name;
		
		ViewState["imp_name"] = Importer;

        if (COMPANY_IDD != "10") PdfClientName = ViewState["PdfClientName"].ToString().Trim();
        if (country_Name.Contains("-"))
        {
            string[] country_Of_Origin = country_Name.Split('-');
            try
            {
                txtCountryOfOrigin.Text = country_Of_Origin[0];
            }
            catch (Exception ex)
            {
                txtCountryOfOrigin.Text = "";
            }
        }

        Transact.JOBID = jobid;
        Transact.JOBNO = Session["JOBNO"].ToString();
        Transact.JOBDATE = DateTime.Now.ToString("dd/MM/yyyy");
        Transact.IMPORTER_NAME = Importer;
        Transact.ADDRESS1 = hd_ImporterName.Value;
        Transact.ADDRESS2 = hd_ImporterAdd1.Value;
        Transact.ADDRESS3 = hd_ImporterAdd2.Value;
        Transact.ADDRESS4 = hd_ImporterAdd3.Value;
        Transact.ADDRESS5 = "";
        Transact.BE_TYPE = "Home";

        if (PdfClientName == "HP")
        {
            Transact.WAREHOUSE_CODE = "NPK6Z022";
            Transact.COUNTRY_SHIPMENT = "SINGAPORE";
            Transact.BE_TYPE = "SEZ FTA-Z";
        }
        else { Transact.COUNTRY_SHIPMENT = txtCountryOfOrigin.Text; }

        Transact.COUNTRY_ORIGIN = txtCountryOfOrigin.Text;
        Transact.PORT_ORIGIN = txtPortOfOrigin.Text;
        Transact.PORT_SHIPMENT = txtPortOfOrigin.Text;
        Transact.CUSTOMS_HOUSE = Session["CUSTOMHOUSE_CODE"].ToString();
        Transact.EXBOND_INBOND_BE_DATE = "01/01/1900";
        Transact.EXBOND_BOND_DATE = "01/01/1900";
        Transact.FILING_STATUS = ddlFilingStatus.SelectedValue;
        Transact.TRANSPORT_MODE = ddlTransportMode.SelectedValue;
        Transact.CUSTOMS_HOUSE_NAME = currentbranch;
        Transact.SECTION46 = "N"; Transact.FIRSTCHECK = "N";
        Transact.GREEN_CHANNEL = "N"; Transact.KACHHA_BE = "N";
        Transact.SECTION48 = "N"; Transact.HIGH_SEA_SALE = "N";
        Transact.USER_ID = currentuser;
        Transact.flag = flag;
        Transact.BRANCH_CODE = currentbranch;
        Transact.WORKING_PERIOD = Working_Period;
        Transact.JOBNO_PS = txtjobPS.Text.Trim();
        Transact.JOB_PREFIX = hdprefix.Value;
        Transact.JOB_SUFFIX = hdsuffix.Value;

        if (PdfClientName == "KYUNGSHIN") Transact.PAYMENT_METHOD_CODE = "D";
        else if (COMPANY_IDD == "1542") { Transact.PAYMENT_METHOD_CODE = "D"; Transact.CONTAINER_TYPE = "FCL"; }
        else Transact.PAYMENT_METHOD_CODE = "T";

        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Ename = "Import_Details_Bind";
        Auto.Enamesearch = Importer;
        Auto.NSearch = Branch;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

        if (ds.Tables[0].Rows.Count > 0)
        {
            Transact.IEC_NO = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
            Transact.BRANCH_NO = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
            Transact.COMMERCIAL_DETAILS_STATUS = ds.Tables[0].Rows[0]["M_COMMERCIAL_DETAILS_STATUS"].ToString();
            Transact.COMMERCIAL_TAX_STATENAME = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATENAME"].ToString();
            Transact.COMMERCIAL_TAX_STATECODE = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATECODE"].ToString();
            Transact.COMMERCIAL_TAX_TYPE = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_TYPE"].ToString();
            Transact.COMMERCIAL_TAX_REGISTRATION_NO = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
            Transact.IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();

            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_BRANCH_WISE";
            Auto.Enamesearch = Transact.BRANCH_NO;
            Auto.NSearch = Transact.IEC_NO;
            DataSet ds_Imp_Add = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds_Imp_Add.Tables[0].Rows.Count > 0)
            {
                Transact.ADDRESS1 = ds_Imp_Add.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                Transact.ADDRESS2 = ds_Imp_Add.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                Transact.ADDRESS3 = ds_Imp_Add.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                Transact.ADDRESS4 = ds_Imp_Add.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
            }
        }

        if (!string.IsNullOrWhiteSpace(ddlAdCode.SelectedValue)) Transact.ADCODE = ddlAdCode.SelectedValue.Trim();

        i = Transact.General_details_insertupdate();
        Current_JOB = Transact.UPDATE_ID.ToString();
        ds.Clear();
        GetJobId();

        DataTable dt_INVOICE = (DataTable)ViewState["dt_Invoice"];

        if (COMPANY_IDD == "293")
        {
            for (int In = 0; In < dt_INVOICE.Rows.Count; In++)
            {
                decimal amount = 0, freight = 0;
                decimal.TryParse(dt_INVOICE.Rows[In]["InvoiceValue"].ToString().Replace(",", ""), out amount);
                decimal.TryParse(dt_INVOICE.Rows[In]["Freight"].ToString().Replace(",", ""), out freight);
                Total_invoice_value += amount;
                Total_Freight_value += freight;
            }
            for (int Iv = 0; Iv < dt_INVOICE.Rows.Count; Iv++)
            {
                decimal amount = 0;
                decimal.TryParse(dt_INVOICE.Rows[Iv]["InvoiceValue"].ToString().Replace(",", ""), out amount);
                decimal Actual_value = Total_invoice_value > 0 ? (amount / Total_invoice_value) * Total_Freight_value : 0;
                dt_INVOICE.Rows[Iv]["Freight"] = Actual_value.ToString("0.00");
            }
        }

        var exchangeRateCache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        if (dt_INVOICE.Rows.Count == 1)
        {
            Transact.INVOICE_NO = txtInvNo.Text.Trim();
            Transact.INVOICE_DATE = txtInvDate.Text.Trim() != "" ? Get_Valid_Date(txtInvDate.Text.Trim().Replace(" ", "")) : "01/01/1900";
            Transact.TERMS = ddlTerms.SelectedItem.Text;
            Transact.INVOICE_CURRENCY = Get_Valid_Curr_Name(txtCurrency.Text.ToUpper().Trim());
            Transact.INVOICE_VALUE = txtInvValue.Text.Trim().Replace(",", "").Replace(" ", "");

            string Invoice_Freight = GetSafeValue(dt_INVOICE, 0, "Freight");
            string Invoice_Insurance = GetSafeValue(dt_INVOICE, 0, "Insurance");
            string Invoice_MissCharge = GetSafeValue(dt_INVOICE, 0, "MissCharge");

            if (COMPANY_IDD == "293") InvoiceCharges(ddlTerms.SelectedItem.Text, Invoice_Freight, Invoice_Insurance, Invoice_MissCharge);

            if (Importer == "ALFA LAVAL INDIA PRIVATE LIMITED")
            {
                Transact.OTHER_PURCHASE_ORDER = dt_INVOICE.Rows[0]["PurchaseOrderNo"].ToString().Trim();
                string Val_PO = dt_INVOICE.Rows[0]["PurchaseOrderDate"].ToString().Trim();
                Transact.OTHER_PURCHASE_ORDER_DATE = (!string.IsNullOrEmpty(Val_PO)) ? Get_Valid_Date(Val_PO) : "01/01/1900";
            }
            else { Transact.OTHER_PURCHASE_ORDER = ""; Transact.OTHER_PURCHASE_ORDER_DATE = "01/01/1900"; }

            InsertInvoiceDetails(exchangeRateCache);
        }
        else
        {
            for (int h = 0; h <= dt_INVOICE.Rows.Count - 1; h++)
            {
                Transact.INVOICE_NO = dt_INVOICE.Rows[h]["InvoiceNo"].ToString();
                Transact.INVOICE_DATE = Get_Valid_Date(dt_INVOICE.Rows[h]["InvoiceDate"].ToString().Trim());
                Transact.INVOICE_CURRENCY = Get_Valid_Curr_Name(dt_INVOICE.Rows[h]["Currency"].ToString().Trim());
                Transact.TERMS = dt_INVOICE.Rows[h]["Terms"].ToString().Trim();
                Transact.INVOICE_VALUE = dt_INVOICE.Rows[h]["InvoiceValue"].ToString().Trim().Replace(",", "");

                string Mult_Freight = GetSafeValue(dt_INVOICE, h, "Freight");
                string Mult_Insurance = GetSafeValue(dt_INVOICE, h, "Insurance");
                string Mult_MissCharge = GetSafeValue(dt_INVOICE, h, "MissCharge");

                if (Importer == "ALFA LAVAL INDIA PRIVATE LIMITED")
                {
                    Transact.OTHER_PURCHASE_ORDER = dt_INVOICE.Rows[h]["PurchaseOrderNo"].ToString().Trim();
                    string Val_PO = dt_INVOICE.Rows[h]["PurchaseOrderDate"].ToString().Trim();
                    Transact.OTHER_PURCHASE_ORDER_DATE = (!string.IsNullOrEmpty(Val_PO)) ? Get_Valid_Date(Val_PO) : "01/01/1900";
                }
                else { Transact.OTHER_PURCHASE_ORDER = ""; Transact.OTHER_PURCHASE_ORDER_DATE = "01/01/1900"; }

                if (COMPANY_IDD == "293") InvoiceCharges(dt_INVOICE.Rows[h]["Terms"].ToString().Trim(), Mult_Freight, Mult_Insurance, Mult_MissCharge);

                InsertInvoiceDetails(exchangeRateCache);
            }
        }

        i = Transact.result;

        DataTable dtItem = (DataTable)ViewState["ItemDetails"];
        string SELECT_BRANCH = Connection.Get_Company_Type();

        if (dtItem != null && dtItem.Rows.Count > 0 && COMPANY_IDD != "268" && COMPANY_IDD != "10")
        {
            var cthUqcCache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var uniqueCthCodes = dtItem.AsEnumerable()
                .Select(r => r["HSCode"].ToString().Trim())
                .Where(c => !string.IsNullOrEmpty(c))
                .Distinct(StringComparer.OrdinalIgnoreCase).ToList();

            foreach (string cthCode in uniqueCthCodes)
            {
                try
                {
                    Auto.Ename = "Get_CTH_Info_Uqc";
                    Auto.Enamesearch = cthCode;
                    Auto.Notn_No_Search = cthCode;
                    DataSet ds_MSR_UQC = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                    if (ds_MSR_UQC.Tables[0].Rows.Count > 0)
                        cthUqcCache[cthCode] = ds_MSR_UQC.Tables[0].Rows[0][0].ToString();
                }
                catch { }
            }

            for (int j = 0; j <= dtItem.Rows.Count - 1; j++)
            {
                Transact.INV_SLNO = dtItem.Rows[j]["InvoiceSlNo"].ToString();
                string ITEM_DESCRIPTION = dtItem.Rows[j]["ITEM_DESC"].ToString();
                Transact.ITEM_QTY = dtItem.Rows[j]["Quantity"].ToString().Replace(" ", "");
                Transact.ITEM_QTY_CODE = dtItem.Rows[j]["QtyCode"].ToString();
                Transact.ITEM_UNIT_PRICE = dtItem.Rows[j]["Rate"].ToString().Replace(",", "").Replace(" ", "");
                Transact.ITEM_UNIT_CODE = txtCurrency.Text.ToUpper().Trim();
                Transact.ITEM_TOTAL_AMOUNT = dtItem.Rows[j]["Amount"].ToString().Replace(",", "").Replace(" ", "");
                Transact.ITEM_AMOUNT_CODE = txtCurrency.Text.ToUpper().Trim();
                Transact.PREVIOUS_BE_DATE = "01/01/1900";
                Transact.flag = "S";
                Transact.YEAR = "";
                Transact.USER_ID = currentuser;
                Transact.BRANCH_CODE = currentbranch;
                Transact.WORKING_PERIOD = Working_Period;
                Transact.JOBNO = Session["JOBNO"].ToString();
                Transact.BRANCH_COMMON = SELECT_BRANCH;
                Transact.ITEM_DESCRIPTION = ITEM_DESCRIPTION.Replace("СЕ", "CE").ToUpper();
                Transact.GENEARL_DESCRIPTION = ITEM_DESCRIPTION.Replace("СЕ", "CE").ToUpper();
                Transact.CTH_NO = dtItem.Rows[j]["HSCode"].ToString();

                string cthKey = Transact.CTH_NO.Trim();
                if (!string.IsNullOrEmpty(cthKey) && cthUqcCache.ContainsKey(cthKey))
                {
                    Transact.Info_Uqc = cthUqcCache[cthKey];
                    string Chk_Qty_Code = Get_Valid_Qty_Code(Transact.ITEM_QTY_CODE);

                    if (Transact.Info_Uqc == "KGS" && Chk_Qty_Code == "KGS")
                    {
                        Transact.Info_Msr = Transact.ITEM_QTY.Replace(",", "");
                    }
                    else if (COMPANY_IDD == "244" && Transact.Info_Uqc == "KGS" && string.IsNullOrEmpty(dtItem.Rows[j]["info_MSR"].ToString()))
                    {
                        Transact.Info_Msr = "0.01";
                    }
                    else if ((Transact.Info_Uqc == "KGS"
                             || ((Chk_Qty_Code == "NOS" || Chk_Qty_Code == "PCS" || Chk_Qty_Code == "SET")
                                 && (Transact.Info_Uqc == "MTR" || Transact.Info_Uqc == "KGS"))))
                    {
                        string Chk_Info_Msr = dtItem.Rows[j]["info_MSR"].ToString();
                        if (!string.IsNullOrEmpty(Chk_Info_Msr))
                        {
                            if (PdfClientName == "TT" && Transact.Info_Uqc == "KGS" && Chk_Qty_Code == "MTR")
                            {
                                decimal Cal_Info_MSR = Convert.ToDecimal(Transact.ITEM_QTY) * 1000;
                                Transact.Info_Msr = Cal_Info_MSR.ToString("N2");
                            }
                            else { Transact.Info_Msr = Chk_Info_Msr; }
                        }
                        else { Transact.Info_Msr = ""; }
                    }
                    else { Transact.Info_Msr = Transact.ITEM_QTY.Replace(",", ""); }
                }
                else
                {
                    Transact.Info_Msr = dtItem.Rows[j]["info_MSR"].ToString();
                    Transact.Info_Uqc = dtItem.Rows[j]["info_UQC"].ToString();
                }

                Transact.MANUFACTURER = txtSupplier.Text.Trim();
                Transact.BRAND = "NA";
                Transact.MODEL = "NA";

                if (COMPANY_IDD == "584" || COMPANY_IDD == "576" || COMPANY_IDD == "458" || COMPANY_IDD == "3198")
                {
                    if (PdfClientName == "LG" || PdfClientName == "LG ELECTRONICS" || PdfClientName == "ALFA LAVAL")
                    {
                        if (PdfClientName == "LG ELECTRONICS") Transact.MANUFACTURER = dtItem.Rows[j]["MANUFACTURER"].ToString();
                        Transact.END_USE_OF_ITEM = "GNX200";
                    }
                    else { Transact.END_USE_OF_ITEM = "GNX100"; }
                }
                Transact.END_USE_OF_ITEM = dtItem.Rows[j]["END_USE_OF_ITEM"].ToString();

                string Item_COO = dtItem.Rows[j]["itemCountyof_orgin"].ToString();
                Transact.COUNTRY_OF_ORIGIN = (!string.IsNullOrEmpty(Item_COO)) ? Item_COO.Split('-')[0] : "";

                Transact.SCHEME_CODE = dtItem.Rows[j]["SchemeCode"].ToString();
                Transact.SCHEME_NOTN = dtItem.Rows[j]["Scheme_NOTN"].ToString();
                Transact.SCHEME_NOTN_SLNO = dtItem.Rows[j]["Scheme_NOTN_SL"].ToString();
                Transact.PRODUCT_RITC = dtItem.Rows[j]["HSCode"].ToString();
                Transact.PRODUCT_CTH = dtItem.Rows[j]["HSCode"].ToString();
                Transact.PRODUCT_BCD_NOTN = dtItem.Rows[j]["Basic_Noti"].ToString();
                Transact.PRODUCT_BCD_SLNO = dtItem.Rows[j]["Basic_Slno"].ToString();
                Transact.PRODUCT_BCD_RATE = dtItem.Rows[j]["Basic_Rate"].ToString();
                Transact.SOCIAL_WELFARE_NOTN = dtItem.Rows[j]["SW_Noti"].ToString();
                Transact.SOCIAL_WELFARE_NOTN_SLNO = dtItem.Rows[j]["SW_Slno"].ToString();
                Transact.SOCIAL_WELFARE_RATE = dtItem.Rows[j]["SW_Rate"].ToString();
                Transact.AIDC_NOTN = dtItem.Rows[j]["AIDC_CessNoti"].ToString();
                Transact.AIDC_NOTN_SLNO = dtItem.Rows[j]["AIDC_CessSlno"].ToString();
                Transact.AIDC_RATE = dtItem.Rows[j]["AIDC_CessRate"].ToString();
                Transact.PRODUCT_CETH = dtItem.Rows[j]["HSCode"].ToString();
                Transact.IGST_LEVY_NOTN = dtItem.Rows[j]["IGST_Noti"].ToString();
                Transact.IGST_LEVY_SLNO = dtItem.Rows[j]["IGST_SlNo"].ToString();
                Transact.IGST_LEVY_RATE = dtItem.Rows[j]["IGST_Rate"].ToString();
                Transact.RSP_APPLICABLE = "N";

                if (PdfClientName == "CATERPILLAR")
                {
                    Transact.SVB_RELATION = "false"; Transact.SVB_REF_NO = "";
                    Transact.SVB_REF_DATE = ""; Transact.SVB_CUSTOM_HOUSE = "";
                    Transact.SVB_LOADING_ON = ""; Transact.SVB_ASSESABLE_RATE = "";
                    Transact.SVB_DUTY_RATE = ""; Transact.SVB_ASSESABLE_STATUS = "";
                    Transact.SVB_DUTY_STATUS = "";
                }

                if (Transact.IGST_LEVY_NOTN != "")
                {
                    Transact.IGST_LEVY_COMPENSATION_CESS_NOTN = "001/2017";
                    Transact.IGST_LEVY_COMPENSATION_CESS_SLNO = "56";
                    Transact.IGST_LEVY_COMPENSATION_CESS_RATE = "0.00";
                }
                if (COMPANY_IDD == "511")
                {
                    Transact.IGST_LEVY_EXCEPTION_NOTN = "052/2003";
                    Transact.IGST_LEVY_EXCEPTION_RATE = "0.00";
                    Transact.LEVY_EXCEMPTION_NOTN_TYPE = "C";
                }

                DataSet dss = Transact.Item_Details_insertupdate();
            }
        }

        if (COMPANY_IDD == "268" || COMPANY_IDD == "10")
        {
            if (dtItem != null && dtItem.Rows.Count > 0)
            {
                var finalUqcCache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                foreach (DataRow dr in dtItem.Rows)
                {
                    string finalHSCode = dr["HSCode"].ToString().Trim();
                    string qtyCodeVal = dr["QtyCode"].ToString().Trim();

                    if (string.IsNullOrEmpty(finalHSCode)) continue;

                    string resolvedUqc;
                    if (!finalUqcCache.TryGetValue(finalHSCode, out resolvedUqc))
                    {
                        try
                        {
                            Auto.Ename = "Get_CTH_Info_Uqc";
                            Auto.Enamesearch = finalHSCode;
                            Auto.Notn_No_Search = finalHSCode;
                            DataSet ds_MSR_UQC = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                            resolvedUqc = ds_MSR_UQC.Tables[0].Rows.Count > 0
                                ? ds_MSR_UQC.Tables[0].Rows[0][0].ToString()
                                : Get_Valid_Qty_Code(qtyCodeVal);
                        }
                        catch
                        {
                            resolvedUqc = Get_Valid_Qty_Code(qtyCodeVal);
                        }
                        finalUqcCache[finalHSCode] = resolvedUqc;
                    }

                    dr["info_UQC"] = resolvedUqc;
                }

                ViewState["ItemDetails"] = dtItem;

                imp_pdf.BRANCH_COMMON = SELECT_BRANCH;
                imp_pdf.JOBNO_PS = txtjobPS.Text.Trim();
                imp_pdf.USER_ID = currentuser;
                imp_pdf.Branch_Code = currentbranch;
                imp_pdf.WORKINGPERIOD = Working_Period;
                imp_pdf.flag = "S";
                imp_pdf.JOBNO = Session["JOBNO"].ToString();
                DataSet imp_pdfs = imp_pdf.Ocr_Import_Xml_Converter(dtItem);
            }

        }

        if (ViewState["dt_IGMDetails"] != null)
        {
            DataTable dt_IGMDetails = (DataTable)ViewState["dt_IGMDetails"];
            if (dt_IGMDetails.Rows.Count > 0)
            {
                for (int aj = 0; aj <= dt_IGMDetails.Rows.Count - 1; aj++)
                {
                    Transact.IGM_MAWB_MBL = dt_IGMDetails.Rows[aj]["IGM_MAWB_MBL"].ToString().Replace(" ", "");
                    Transact.IGM_MAWB_MBLDATE = string.IsNullOrEmpty(dt_IGMDetails.Rows[aj]["IGM_MAWB_MBLDATE"].ToString()) ? "01/01/1900" : dt_IGMDetails.Rows[aj]["IGM_MAWB_MBLDATE"].ToString();
                    Transact.IGM_HAWB_HBLNO = dt_IGMDetails.Rows[aj]["IGM_HAWB_HBLNO"].ToString().Replace(" ", "");
                    Transact.IGM_HAWB_HBLDATE = string.IsNullOrEmpty(dt_IGMDetails.Rows[aj]["IGM_HAWB_HBLDATE"].ToString()) ? "01/01/1900" : dt_IGMDetails.Rows[aj]["IGM_HAWB_HBLDATE"].ToString();
                    object value = dt_IGMDetails.Rows[aj]["IGM_NOOFPACKAGE"];
                    Transact.IGM_NOOFPACKAGE = (value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString())) ? string.Empty : Convert.ToInt32(Convert.ToDecimal(value)).ToString();
                    Transact.IGM_GROSSWEIGHT = string.IsNullOrEmpty(dt_IGMDetails.Rows[aj]["IGM_GROSSWEIGHT"].ToString()) ? "0" : dt_IGMDetails.Rows[aj]["IGM_GROSSWEIGHT"].ToString();
                    Transact.IGM_JOBDATE = "01/01/1900";
                    Transact.IGM_FLIGHT_VESSELDATE = "01/01/1900";
                    Transact.IGM_DATE = "01/01/1900";
                    Transact.IGM_GATEWAY_IGM_DATE = "01/01/1900";
                    Transact.USER_ID = currentuser;
                    Transact.flag = flag;
                    Transact.BRANCH_CODE = currentbranch;
                    Transact.WORKING_PERIOD = Working_Period;
                    Transact.JOBNO_PS = Session["JOBNO"].ToString();
                    Transact.IGM_JOBNO = Session["JOBNO"].ToString();
                    Transact.IGM_TRANSPORTMODE = ddlTransportMode.SelectedValue;
                    Transact.IGM_PACKAGETYPE = "PKG";
                    Transact.IGM_TYPEOFWEIGHT = "KGS";

                    if (COMPANY_IDD == "294") Transact.IGM_MARKSNOS = "AS PER MBL";
                    if (COMPANY_IDD == "1542") { Transact.IGM_PACKAGETYPE = "PLT"; Transact.IGM_MARKSNOS = "AS PER INVOICE / " + txtInvNo.Text.Trim(); }
                    else if (COMPANY_IDD == "517") { Transact.IGM_MARKSNOS = "SEZ UNIT DTLS: IEC" + Transact.IEC_NO + " DHL SUPPLY CHAIN INDIA PRIVATE LIMITED NANDIAMBAKKAM PORT ROAD, MINJUR"; }

                    DataSet dss_IGM = Transact.IGM_Details_insertupdate();
                }
            }

            if (ViewState["dt_ContainerDetails"] != null)
            {
                DataTable dt_Con = (DataTable)ViewState["dt_ContainerDetails"];
                if (dt_Con.Rows.Count > 0)
                {
                    for (int kav = 0; kav <= dt_Con.Rows.Count - 1; kav++)
                    {
                        Transact.CONTAINER_NO = dt_Con.Rows[kav]["CONTAINER_NO"].ToString().Replace(" ", "");
                        Transact.SEAL_NO = dt_Con.Rows[kav]["SEAL_NO"].ToString();
                        Transact.TYPE = dt_Con.Rows[kav]["TYPE"].ToString();
                        Transact.CONTAINER_IGM_DATE = "01/01/1900";
                        Transact.USER_ID = currentuser;
                        Transact.flag = flag;
                        Transact.BRANCH_CODE = currentbranch;
                        Transact.WORKING_PERIOD = Working_Period;
                        Transact.JOBNO_PS = Session["JOBNO"].ToString();
                        Transact.IGM_JOBNO = Session["JOBNO"].ToString();
                        Transact.CONTAINER_IGM_SLNO = "1";
                        Transact.FCL_OR_LCL = "F";
                        Transact.TRUCK_NO = "NA";
                        DataSet dss_Con = Transact.CONTAINER_Details_insertupdate();
                    }
                }
            }
        }

        PageCount_log(PdfStatus.UPLOAD_SUCCESS, hd_PageCount.Value);
        WriteJobLog("Job Success", "JobNo:" + (Session["JOBNO"] != null ? Session["JOBNO"].ToString().Trim() : "") + " | Pages:" + GetPageCountForLog());
        Session["ImportPdfAI_PreviewSuccess"] = null;
        return i;
    }

    // ─── INSERT INVOICE DETAILS ────────
    public void InsertInvoiceDetails(Dictionary<string, string> exchangeRateCache = null)
    {
        if (exchangeRateCache == null)
            exchangeRateCache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        DataSet ds = new DataSet();
        string currencyKey = txtCurrency.Text.ToUpper().Trim();

        Transact.MIS_CURRENCY = currencyKey;
        Transact.MIS_AGENCY_CURRENCY = currencyKey;
        Transact.MIS_DISCOUNT_CURRENCY = currencyKey;
        Transact.MIS_FREIGHT_CURRENCY = currencyKey;
        Transact.MIS_INSURANCE_CURRENCY = currencyKey;

        string INVOICE_EXRATE;
        if (!exchangeRateCache.TryGetValue(currencyKey, out INVOICE_EXRATE))
        {
            Auto.Ename = "EXCHANGE_MASTER_RATE_IMPORTWISE";
            Auto.Enamesearch = currencyKey;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            INVOICE_EXRATE = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString() : "";
            exchangeRateCache[currencyKey] = INVOICE_EXRATE;
        }

        if (!string.IsNullOrEmpty(INVOICE_EXRATE))
        {
            Transact.INVOICE_EXRATE = INVOICE_EXRATE;
            Transact.MIS_EXRATE = INVOICE_EXRATE;
            Transact.MIS_AGENCY_EXRATE = INVOICE_EXRATE;
            Transact.MIS_DISCOUNT_EXRATE = INVOICE_EXRATE;
            Transact.MIS_FREIGHT_EXRATE = INVOICE_EXRATE;
            Transact.MIS_INSURANCE_EXRATE = INVOICE_EXRATE;

            if (COMPANY_IDD != "293")
            {
                string freight = string.IsNullOrEmpty(hd_Freight.Value) ? "" : hd_Freight.Value.Replace(",", "");
                string insurance = string.IsNullOrEmpty(hd_Insurance.Value) ? "" : hd_Insurance.Value.Replace(",", "");
                string missCharge = string.IsNullOrEmpty(hd_MiscCharge.Value) ? "" : hd_MiscCharge.Value.Replace(",", "");

                if ((Transact.TERMS == "FOB" || Transact.TERMS == "CI") && string.IsNullOrEmpty(freight))
                {
                    Transact.MIS_FREIGHT_RATE = "20.0000";
                    freight = CalculateAmount(Transact.MIS_FREIGHT_RATE, Transact.INVOICE_VALUE);
                }
                if ((Transact.TERMS == "FOB" || Transact.TERMS == "CF") && string.IsNullOrEmpty(insurance))
                {
                    string insurance_rate = Get_ClientMaster_Insurance_details();
                    if (string.IsNullOrEmpty(insurance_rate)) insurance_rate = "1.1250";
                    Transact.MIS_INSURANCE_RATE = insurance_rate;
                    insurance = CalculateAmount(insurance_rate, Transact.INVOICE_VALUE);
                }
                if (Transact.TERMS == "FOB" || Transact.TERMS == "CI") Transact.MIS_FREIGHT_CHARGES = freight;
                if (Transact.TERMS == "FOB" || Transact.TERMS == "CF") Transact.MIS_INSURANCE_CHARGES = insurance;
                Transact.MIS_CHARGES = missCharge;
            }
        }


        Transact.SUPPLIER_NAME = CleanSupplierField(txtSupplier.Text);

        Auto.Ename = "SUPPLIER_MASTER_SEARCH";
        Auto.Enamesearch = txtSupplier.Text.Trim();
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            Transact.SUPPLIER_ADDRESS = CleanSupplierField(ds.Tables[0].Rows[0]["SUP_ADD1"].ToString());
            Transact.SUPPLIER_ADDRESS1 = CleanSupplierField(ds.Tables[0].Rows[0]["SUP_ADD2"].ToString());
            Transact.SUPPLIER_ADDRESS2 = CleanSupplierField(ds.Tables[0].Rows[0]["SUP_ADD3"].ToString());
            Transact.SUPPLIER_COUNTRY_NAME = CleanSupplierField(ds.Tables[0].Rows[0]["SUP_COUNTRY_NAME"].ToString());
            Transact.SUPPLIER_COUNTRY_CODE = ds.Tables[0].Rows[0]["SUP_COUNTRY_CODE"].ToString();
        }
        else
        {
            DataTable dt_INVOICES = ViewState["dt_Invoice"] as DataTable;

            if (dt_INVOICES != null && dt_INVOICES.Rows.Count > 0)
            {
                Transact.SUPPLIER_ADDRESS = CleanSupplierField(dt_INVOICES.Rows[0]["SupplierAdd1"].ToString());
                Transact.SUPPLIER_ADDRESS1 = CleanSupplierField(dt_INVOICES.Rows[0]["SupplierAdd2"].ToString());
                Transact.SUPPLIER_ADDRESS2 = CleanSupplierField(dt_INVOICES.Rows[0]["SupplierAdd3"].ToString());
                Transact.SUPPLIER_COUNTRY_NAME = CleanSupplierField(dt_INVOICES.Rows[0]["SupplierAdd4"].ToString());
                Transact.SUPPLIER_COUNTRY_CODE = "";


            }
        }

        adminmaster Admin_mas = new adminmaster();
        string imp_name = ViewState["imp_name"].ToString().Trim();
        Admin_mas.EImpName = imp_name;
        Admin_mas.ESupName = txtSupplier.Text.Trim();
        Admin_mas.Ename = "GET_SVB_DETAILS";
        ds = Admin_mas.SVB_Relation_Master();

        if (ds.Tables[0].Rows.Count > 0)
        {
            Transact.SVB_RELATION = ds.Tables[0].Rows[0]["SVB_RELATION"].ToString();
            Transact.SVB_REF_NO = ds.Tables[0].Rows[0]["SVB_REF_NO"].ToString();
            Transact.SVB_REF_DATE = ds.Tables[0].Rows[0]["SVB_REF_DATE"].ToString();
            Transact.SVB_CUSTOM_HOUSE = ds.Tables[0].Rows[0]["SVB_CUSTOM_HOUSE"].ToString();
            Transact.SVB_LOADING_ON = ds.Tables[0].Rows[0]["SVB_LOADING_ON"].ToString();
            Transact.SVB_ASSESABLE_RATE = ds.Tables[0].Rows[0]["SVB_ASSESABLE_RATE"].ToString();
            Transact.SVB_DUTY_RATE = ds.Tables[0].Rows[0]["SVB_DUTY_RATE"].ToString();
            Transact.SVB_ASSESABLE_STATUS = ds.Tables[0].Rows[0]["SVB_ASSESABLE_STATUS"].ToString();
            Transact.SVB_DUTY_STATUS = ds.Tables[0].Rows[0]["SVB_DUTY_STATUS"].ToString();
        }

        Transact.OTHER_NATURE_OF_TRANSACTION = COMPANY_IDD == "517" ? "O Others" : "S Sale";
        Transact.OTHER_TERMS_OF_PAYMENT = "OTH Others";
        Transact.OTHER_VALUATION_METHOD = "Rule 4 - Transaction Value";
        Transact.OTHER_CONTRACT_DATE = "01/01/1900";
        Transact.OTHER_LOC_DATE = "01/01/1900";
        Transact.NON_STD_CERTIFICATE_DATE = "01/01/1900";
        Transact.SHIP_DATE = "01/01/1900";

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            var svb = ds.Tables[0].Rows[0]["SVB_REF_DATE"];
            Transact.SVB_REF_DATE = (svb == DBNull.Value || string.IsNullOrWhiteSpace(svb.ToString())) ? "01/01/1900" : svb.ToString();
        }
        else { Transact.SVB_REF_DATE = "01/01/1900"; }

        Transact.flag = "S";
        Transact.USER_ID = currentuser;
        Transact.BRANCH_CODE = currentbranch;
        Transact.BRANCH_COMMON = currentbranch;
        Transact.WORKING_PERIOD = Working_Period;

        if (PdfClientName == "CATERPILLAR") Transact.WHETHER_BUYER_SELLER_RELATED = "Y";

        Transact.Invoice_Details_insertupdate();
    }


    private string CleanSupplierField(string input)
    {
        if (string.IsNullOrEmpty(input))
            return "";

        string removedChars = "";
        string cleanedValue = "";

        foreach (char c in input)
        {
            if (c >= 32 && c <= 126)
            {
                cleanedValue += c;
            }
            else
            {
                if (!removedChars.Contains(c.ToString()))
                    removedChars += c;
            }
        }

        cleanedValue = cleanedValue.Trim().ToUpper();

        if (cleanedValue.Length > 35)
            cleanedValue = cleanedValue.Substring(0, 35);

        return cleanedValue;
    }

    // ─── GET JOB ID ───
    public DataSet GetJobId()
    {
        DataSet ds = new DataSet();
        try
        {
            Transact.JOBNO = Session["JOBNO"].ToString();
            Transact.Ename = "GetJobId";
            Transact.IMPORTER_NAME = "";
            Transact.TRANSPORT_MODE = "";
            Transact.CUSTOMS_HOUSE = "";
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            ds = Transact.RetrieveAll_General_Details();
            if (ds.Tables[0].Rows.Count > 0)
                Session["JOBIDexcel"] = ds.Tables[0].Rows[0]["JOBID"].ToString();
        }
        catch { Session["JOBIDexcel"] = ""; }
        return ds;
    }

    // ─── AUTO JOB NO ─────
    public void AUTO_JOBNO()
    {
        JOBNO = Convert.ToString(Retrieve_JobNO());
        Session["JOBNO"] = JOBNO;
        txtjobPS.Text = JOBNO;
        JobNo_Prefix_Sufix(JOBNO);
    }

    public void JobNo_Prefix_Sufix(string JOBNO)
    {
        Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();

        if (COMPANY_IDD == "293" || COMPANY_IDD == "10") { JPS.Branch = Connection.Current_Branch(); JPS.Ename = "Imp_Exp_gen_293_select"; JPS.BranchType = "I"; }
        else if (COMPANY_IDD == "2349") { JPS.Branch = Connection.Current_Branch(); JPS.Ename = "Imp_Exp_gen_2349_select"; JPS.BranchType = "I"; }
        else { JPS.Branch = SELECT_BRANCH; JPS.Ename = "Imp_gen_select"; JPS.BranchType = SELECT_TYPE; }

        JPS.Tr_mode = hd_TransportMode.Value;
        DataSet dats = JPS.Job_prefix_Suffix_Select_Areawise();

        string JobNo = txtjobPS.Text;
        if (!string.IsNullOrEmpty(JobNo))
        {
            int Jno = Convert.ToInt32(JobNo);
            if (Jno < 1000)
            {
                if (Jno > 100) JobNo = "00" + txtjobPS.Text;
                else if (Jno > 10) JobNo = "000" + txtjobPS.Text;
                else JobNo = "0000" + txtjobPS.Text;
            }
        }

        if (Session["COMPANY_LICENSE"] == null) return;
        string license = Session["COMPANY_LICENSE"].ToString().ToLower();

        if (dats.Tables[0].Rows.Count > 0)
        {
            string p = dats.Tables[0].Rows[0][0].ToString();
            string s = dats.Tables[0].Rows[0][1].ToString();
            bool hasP = p != string.Empty;
            bool hasS = s != string.Empty;

            if (license == "eri00247")
            {
                if (!hasP && hasS) { txtjobPS.Text = txtjobPS.Text + "/" + s.Trim(); hdprefix.Value = ""; hdsuffix.Value = s.Trim(); }
                else if (hasP && !hasS) { txtjobPS.Text = (p + txtjobPS.Text).Trim(); hdprefix.Value = p.Trim(); hdsuffix.Value = ""; }
                else if (hasP && hasS) { txtjobPS.Text = (p + txtjobPS.Text + "/" + s).Trim(); hdprefix.Value = p.Trim(); hdsuffix.Value = s.Trim(); }
                else { hdprefix.Value = ""; hdsuffix.Value = ""; }
            }
            else
            {
                bool isSpecialComp = Connection.COMPANYID() == "1163" || Connection.COMPANYID() == "1164"
                    || Connection.COMPANYID() == "1165" || Connection.COMPANYID() == "1166";

                if (!hasP && hasS) { txtjobPS.Text = txtjobPS.Text + "/" + s.Trim(); hdprefix.Value = ""; hdsuffix.Value = s.Trim(); }
                else if (hasP && !hasS) { txtjobPS.Text = isSpecialComp ? (p + "/" + JobNo).Trim() : (p + "/" + txtjobPS.Text).Trim(); hdprefix.Value = p.Trim(); hdsuffix.Value = ""; }
                else if (hasP && hasS) { txtjobPS.Text = isSpecialComp ? (p + "/" + JobNo + "/" + s).Trim() : (p + "/" + txtjobPS.Text + "/" + s).Trim(); hdprefix.Value = p.Trim(); hdsuffix.Value = s.Trim(); }
                else { hdprefix.Value = ""; hdsuffix.Value = ""; }
            }
        }
        else { hdprefix.Value = ""; hdsuffix.Value = ""; }

        Session["JOBNO_PS"] = txtjobPS.Text;
    }

    public int Get_general_MAXID(string Flag)
    {
        objUBO.IEC_NO = "";
        objUBO.BRANCH_NO = "";
        objUBO.Ename = Flag;
        objUBO.WORKING_PERIOD = Connection.Get_Company_Type();
        ds_IEC = xl.Bind_Export_General_IEC_No(objUBO);
        if (ds_IEC.Tables[0].Rows.Count > 0)
            MAX_ID = Convert.ToInt32(ds_IEC.Tables[0].Rows[0]["MAXID"].ToString());
        return MAX_ID;
    }

    protected void btn_Refresh_Click(object sender, ImageClickEventArgs e)
    {
        WriteJobLog("Button Click", "Refresh clicked");
        Page_Load(sender, e);
        txtInvNo.Text = ""; txtInvDate.Text = ""; txtCurrency.Text = "";
        txtCountryOfOrigin.Text = ""; txtPortOfOrigin.Text = "";
        gv_ItemPDF.DataSource = new DataTable();
        gv_ItemPDF.DataBind();
    }

    // ─── CURRENCY / QTY HELPERS ───
    private string Get_Valid_Curr_Name(string curr)
    {
        if (curr == "EURO" || curr == "Euro") return "EUR";
        if (curr == "US$" || curr == "US" || curr == "United States Dollar") return "USD";
        if (curr == "JP¥") return "JPY";
        if (curr == "£") return "GBP";
        return curr;
    }

    private string Get_Valid_Qty_Code(string curr)
    {
        if (string.IsNullOrEmpty(curr)) return curr;
        if (curr == "SETS" || curr.Contains("SET") || curr == "SET(S)") return "SET";
        if (curr == "PIECE(S)" || curr == "PCE" || curr == "PC" || curr == "pcs" || curr == "Pcs") return "PCS";
        if (curr.Contains("PC/PK") || curr.Contains("PCS/PK") || curr.Contains("PCS/PACK")) return "PAK";
        if (curr == "PACK(S)") return "PAC";
        if (curr == "MTRS." || curr == "MTRS" || curr == "MT" || curr == "M") return "MTR";
        if (curr == "EA") return "NOS";
        if (curr == "YRD") return "YDS";
        if (curr == "KG" || curr == "kg") return "KGS";
        if (curr == "PAIR") return "PRS";
        return curr;
    }

    // ─── DATE HELPERS ──────
    private string Get_Valid_Date(string Dt)
    {
        Dt = Dt.Replace(".", "/").Replace("-", "/").Replace(",", "/").Replace(" ", "/");
        string[] dd = Dt.Split('/');

        if (dd[0].Length == 3) { string em = dd[0]; dd[0] = dd[1]; dd[1] = em; }
        else if (dd[0].Length == 4) { string ey = dd[0]; dd[0] = dd[2]; dd[2] = ey; }

        if (dd[0].Length != 2) dd[0] = "0" + dd[0];
        if (dd[1].Length != 2)
        {
            dd[1] = dd[1].Replace("JAN", "1").Replace("FEB", "2").Replace("MAR", "3")
                          .Replace("Mar", "3").Replace("APR", "4").Replace("June", "6").Replace("JUNE", "6");
            dd[1] = "0" + dd[1];
        }
        if (dd[2].Length != 4) dd[2] = "20" + dd[2];
        return dd[0] + "/" + dd[1] + "/" + dd[2];
    }

    private string Get_Valid_Date_New(string Dt)
    {
        if (string.IsNullOrWhiteSpace(Dt)) return "Invalid Date";
        Dt = Dt.Trim();
        Dt = Regex.Replace(Dt, @"\b(\d+)(st|nd|rd|th)\b", "$1", RegexOptions.IgnoreCase);
        Dt = Dt.Replace(".", "/").Replace("-", "/").Replace(",", "/")
               .Replace("  ", " ").Replace("nd", "").Replace("st", "").Replace("rd", "").Replace("th", "");

        string[] formats = new[]
        {
            "MMM/dd/yyyy","dd/MMM/yyyy","MM/dd/yyyy","dd/MM/yyyy","yyyy/MM/dd","yyyyMMdd",
            "dd/MM/yy","dd/MMM/yy","MMM.d/yyyy","MMM.d,yyyy","dd-MMM-yy",
            "MMM dd yyyy","MMM dd, yyyy","dd MMM yyyy","dd MMM, yyyy",
            "dd.MM.yyyy","dd-MM-yyyy","yyyy-MM-dd","MMMM d yyyy","MMMM d, yyyy",
            "dd/MMM/yyyy","MMM.d.yyyy","d/MM/yyyy","d/M/yyyy","MMM d yyyy","MMM d, yyyy","MMM d,yyyy"
        };

        DateTime parsedDate;
        if (DateTime.TryParseExact(Dt, formats, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out parsedDate))
            return parsedDate.ToString("dd/MM/yyyy");
        if (DateTime.TryParse(Dt, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out parsedDate))
            return parsedDate.ToString("dd/MM/yyyy");
        return "Invalid Date";
    }

    // ─── BULK UPDATE ALL ───────
    protected void btn_bulk_Update_All_Click(object sender, EventArgs e)
    {
        WriteJobLog("Button Click", "Apply to All clicked");
        try
        {
            if (ListBox_INVSlno.SelectedItem == null || ListBox_ItemSlno.SelectedItem == null)
            {
                Alert_msg("Please Select Inv & Item...!");
                return;
            }
            SaveCurrentPageToDataTable();

            DataTable GridViewData = ViewState["ItemDetails"] as DataTable;
            if (GridViewData == null) { Alert_msg("No data available to update!"); return; }

            var selectedItems = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (ListItem item in ListBox_ItemSlno.Items)
            {
                if (item.Selected) selectedItems.Add(item.Text.Trim());
            }

            var updatedKeys = new List<string>();
            var changedFields = new List<string>();
            if (txtDescription.Text != "") changedFields.Add("ITEM_DESC");
            if (txt_QtyCode.Text != "") changedFields.Add("QtyCode");
            if (ddlSchemeCode.SelectedItem != null && ddlSchemeCode.SelectedItem.Text != "") changedFields.Add("SchemeCode");
            if (ddlScheme_NOTN.SelectedItem != null && ddlScheme_NOTN.SelectedItem.Text != "") changedFields.Add("Scheme_NOTN");
            if (ddlScheme_NOTN_SL.SelectedItem != null && ddlScheme_NOTN_SL.SelectedItem.Text != "") changedFields.Add("Scheme_NOTN_SL");
            if (txtCTH.Text != "") changedFields.Add("HSCode");
            if (txtBasicNotn.Text != "") changedFields.Add("Basic_Noti");
            if (txtBasicSLNO.Text != "") changedFields.Add("Basic_Slno");
            if (txtBasicRate.Text != "") changedFields.Add("Basic_Rate");
            if (txtManufacturer.Text != "") changedFields.Add("MANUFACTURER");
            if (txtEnduseItem.Text != "") changedFields.Add("END_USE_OF_ITEM");
            if (txtitemCountyof_orgin.Text != "") changedFields.Add("itemCountyof_orgin");
            if (txtSW_Noti.Text != "") changedFields.Add("SW_Noti");
            if (txtSW_Slno.Text != "") changedFields.Add("SW_Slno");
            if (txt_SW_Rate.Text != "") changedFields.Add("SW_Rate");
            if (txt_AIDC_CessNoti.Text != "") changedFields.Add("AIDC_CessNoti");
            if (txt_AIDC_CessSlno.Text != "") changedFields.Add("AIDC_CessSlno");
            if (txt_AIDC_CessRate.Text != "") changedFields.Add("AIDC_CessRate");
            if (txt_IGST_Noti.Text != "") changedFields.Add("IGST_Noti");
            if (txt_IGST_SlNo.Text != "") changedFields.Add("IGST_SlNo");
            if (txt_IGST_Rate.Text != "") changedFields.Add("IGST_Rate");

            foreach (DataRow dr in GridViewData.Rows)
            {
                string itemKey;
                if (ddl_Select_ItemRITC.SelectedValue == "1")
                    itemKey = dr["InvoiceSlNo"] + "~" + dr["HSCode"];
                else
                    itemKey = dr["InvoiceSlNo"] + "~" + dr["ItemSlNo"];
                bool shouldUpdate = selectedItems.Count == 0 || selectedItems.Contains(itemKey);
                if (!shouldUpdate) continue;

                updatedKeys.Add(dr["InvoiceSlNo"] + "~" + dr["ItemSlNo"]);

                if (txtDescription.Text != "") dr["ITEM_DESC"] = txtDescription.Text;
                if (txt_QtyCode.Text != "") dr["QtyCode"] = txt_QtyCode.Text;
                if (ddlSchemeCode.SelectedItem != null && ddlSchemeCode.SelectedItem.Text != "")
                    dr["SchemeCode"] = ddlSchemeCode.SelectedValue;
                if (ddlScheme_NOTN.SelectedItem != null && ddlScheme_NOTN.SelectedItem.Text != "")
                    dr["Scheme_NOTN"] = ddlScheme_NOTN.SelectedValue;
                if (ddlScheme_NOTN_SL.SelectedItem != null && ddlScheme_NOTN_SL.SelectedItem.Text != "")
                    dr["Scheme_NOTN_SL"] = ddlScheme_NOTN_SL.SelectedValue;
                if (txtCTH.Text != "") dr["HSCode"] = txtCTH.Text;
                if (txtBasicNotn.Text != "") dr["Basic_Noti"] = txtBasicNotn.Text;
                if (txtBasicSLNO.Text != "") dr["Basic_Slno"] = txtBasicSLNO.Text;
                if (txtBasicRate.Text != "") dr["Basic_Rate"] = txtBasicRate.Text;
                if (txtManufacturer.Text != "") dr["MANUFACTURER"] = txtManufacturer.Text;
                if (txtEnduseItem.Text != "") dr["END_USE_OF_ITEM"] = txtEnduseItem.Text;
                if (txtitemCountyof_orgin.Text != "") dr["itemCountyof_orgin"] = txtitemCountyof_orgin.Text;
                if (txtSW_Noti.Text != "") dr["SW_Noti"] = txtSW_Noti.Text;
                if (txtSW_Slno.Text != "") dr["SW_Slno"] = txtSW_Slno.Text;
                if (txt_SW_Rate.Text != "") dr["SW_Rate"] = txt_SW_Rate.Text;
                if (txt_AIDC_CessNoti.Text != "") dr["AIDC_CessNoti"] = txt_AIDC_CessNoti.Text;
                if (txt_AIDC_CessSlno.Text != "") dr["AIDC_CessSlno"] = txt_AIDC_CessSlno.Text;
                if (txt_AIDC_CessRate.Text != "") dr["AIDC_CessRate"] = txt_AIDC_CessRate.Text;
                if (txt_IGST_Noti.Text != "") dr["IGST_Noti"] = txt_IGST_Noti.Text;
                if (txt_IGST_SlNo.Text != "") dr["IGST_SlNo"] = txt_IGST_SlNo.Text;
                if (txt_IGST_Rate.Text != "") dr["IGST_Rate"] = txt_IGST_Rate.Text;
            }

            ViewState["ItemDetails"] = GridViewData;
            ViewState["GridViewData"] = GridViewData;

            BindGridPaged(CurrentPageIndex + 1);

            int updatedCount = selectedItems.Count > 0 ? selectedItems.Count : GridViewData.Rows.Count;

            WriteJobLog("Rows Updated (Apply to All)", "Count:" + updatedKeys.Count
                + " | Inv~Item:[" + string.Join(", ", updatedKeys) + "]"
                + " | Fields:[" + string.Join(", ", changedFields) + "]");

            Alert_msg("Apply to All completed — " + updatedCount + " rows updated across all pages.");
        }
        catch (Exception ex)
        {
            log.makeLog("Message ==> " + ex.Message);
            LogException("Bulk Update Failed", ex);
            lblmsg.Text = ex.Message;
        }
        finally
        {
            txtDescription.Text = ""; txt_QtyCode.Text = "";
            if (ddlSchemeCode != null) ddlSchemeCode.SelectedIndex = -1;
            if (ddlScheme_NOTN != null) ddlScheme_NOTN.SelectedIndex = -1;
            if (ddlScheme_NOTN_SL != null) ddlScheme_NOTN_SL.SelectedIndex = -1;
            txtCTH.Text = ""; txtBasicNotn.Text = ""; txtBasicSLNO.Text = ""; txtBasicRate.Text = "";
            txtManufacturer.Text = ""; txtEnduseItem.Text = ""; txtitemCountyof_orgin.Text = "";
            txtSW_Noti.Text = ""; txtSW_Slno.Text = ""; txt_SW_Rate.Text = "";
            txt_AIDC_CessNoti.Text = ""; txt_AIDC_CessSlno.Text = ""; txt_AIDC_CessRate.Text = "";
            txt_IGST_Noti.Text = ""; txt_IGST_SlNo.Text = ""; txt_IGST_Rate.Text = "";
        }
    }

    private void CopyIfNotEmpty(GridViewRow row, string controlId, string value)
    {
        if (string.IsNullOrEmpty(value)) return;
        TextBox tb = row.FindControl(controlId) as TextBox;
        if (tb != null) tb.Text = value;
    }

    private DataTable FilterDataTableBySerialNumbers(DataTable dt)
    {
        DataTable filteredTable = dt.Clone();
        foreach (DataRow row in dt.Rows)
        {
            foreach (ListItem item in ListBox_ItemSlno.Items)
            {
                if (!item.Selected) continue;
                try
                {
                    string[] Split_Inv_item = item.Text.Trim().Split('~');
                    if (Split_Inv_item.Length < 2) continue;

                    string selectedINV = Split_Inv_item[0].Trim();
                    string selectedItem = Split_Inv_item[1].Trim();
                    string rowINV = row["InvoiceSlNo"].ToString().Trim();
                    string rowItem;

                    if (ddl_Select_ItemRITC.SelectedValue == "0") rowItem = row["ItemSlNo"].ToString().Trim();
                    else if (ddl_Select_ItemRITC.SelectedValue == "1") rowItem = row["HSCode"].ToString().Trim();
                    else rowItem = row["ItemSlNo"].ToString().Trim();

                    if (selectedINV == rowINV && selectedItem == rowItem)
                    { filteredTable.ImportRow(row); break; }
                }
                catch { continue; }
            }
        }
        return filteredTable;
    }

    protected void ddl_Select_ItemRITC_SelectedIndexChanged(object sender, EventArgs e)
    {
        Select_ItemRITC();
    }

    public void Select_ItemRITC()
    {
        DataTable dt_GridViewData = ViewState["ItemDetails"] as DataTable;
        if (dt_GridViewData == null || dt_GridViewData.Rows.Count == 0) return;

        var distinctValues = dt_GridViewData.AsEnumerable()
            .Select(row => row["InvoiceSlNo"].ToString()).Distinct().ToList();
        DataTable distinctDt = dt_GridViewData.Clone();
        foreach (var value in distinctValues) distinctDt.Rows.Add(value);

        ListBox_INVSlno.DataSource = distinctDt;
        ListBox_INVSlno.DataTextField = "InvoiceSlNo";
        ListBox_INVSlno.DataValueField = "InvoiceSlNo";
        ListBox_INVSlno.DataBind();

        string mode = ddl_Select_ItemRITC.SelectedValue;
        ListBox_ItemSlno.Items.Clear();

        if (mode == "0")
        {
            ViewState["FilteredView"] = false;
            foreach (DataRow row in dt_GridViewData.Rows)
            {
                string text = row["InvoiceSlNo"] + "~" + row["ItemSlNo"];
                ListBox_ItemSlno.Items.Add(new ListItem(text, text));
            }
            BindGridPaged(1);
        }
        else if (mode == "1")
        {
            ViewState["FilteredView"] = false;
            var uniqueRows = dt_GridViewData.AsEnumerable()
                .GroupBy(row => new { Invoice = row["InvoiceSlNo"].ToString(), Ritc = row["HSCode"].ToString() })
                .Select(g => g.First()).CopyToDataTable();

            foreach (DataRow row in uniqueRows.Rows)
            {
                string text = row["InvoiceSlNo"] + "~" + row["HSCode"];
                ListBox_ItemSlno.Items.Add(new ListItem(text, text));
            }
            BindGridPaged(1);
        }
        else if (mode == "2")
        {
            var emptyCTHRows = dt_GridViewData.AsEnumerable()
                .Where(row => string.IsNullOrWhiteSpace(
                    row["HSCode"] == DBNull.Value ? "" : row["HSCode"].ToString()))
                .ToList();

            if (emptyCTHRows.Count > 0)
            {

                var distinctInvoices = emptyCTHRows
                    .Select(r => r["InvoiceSlNo"].ToString().Trim())
                    .Distinct()
                    .ToList();

                foreach (ListItem invItem in ListBox_INVSlno.Items)
                {
                    invItem.Selected = distinctInvoices.Contains(invItem.Value.Trim());
                }

                foreach (DataRow row in emptyCTHRows)
                {
                    string text = row["InvoiceSlNo"] + "~" + row["ItemSlNo"];
                    ListBox_ItemSlno.Items.Add(new ListItem(text, text) { Selected = true });
                }

                DataTable emptyCTHTable = emptyCTHRows.CopyToDataTable();

                ViewState["FilteredView"] = true;
                ViewState["FilteredItems"] = emptyCTHTable;
                ViewState["FilteredData"] = emptyCTHTable;
                ViewState["IsFiltered"] = true;
                BindGridPaged_Filtered(1);

                Alert_msg("<span style='font-weight:bold;'>⚠️ "+ emptyCTHRows.Count + " item(s) with empty CTH found. Please fill CTH and Apply Filter.</span>");

                if (gv_ItemPDF.HeaderRow != null)
                {
                    gv_ItemPDF.UseAccessibleHeader = true;
                    gv_ItemPDF.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            else
            {
                ViewState["FilteredView"] = false;
                Alert_msg(" No items with empty CTH found. All CTH values are filled.");
                BindGridPaged(CurrentPageIndex + 1);
            }
        }
    }

    // ─── LOCAL API TEST DATA ─────
    public DataSet Get_AccessToken_Invoice(DataSet GetLocalAPIData, string LocalFile)
    {
        string StoreData = File.ReadAllText(LocalFile);
        JObject jsonData = JObject.Parse(StoreData);
        DataSet ds = new DataSet();

        DataTable headerTable = JsonConvert.DeserializeObject<DataTable>(jsonData["Header"].ToString());
        headerTable.TableName = "Header"; ds.Tables.Add(headerTable);

        DataTable InvoiceDetails = JsonConvert.DeserializeObject<DataTable>(jsonData["InvoiceDetails"].ToString());
        InvoiceDetails.TableName = "InvoiceDetails"; ds.Tables.Add(InvoiceDetails);

        DataTable itemsTable = JsonConvert.DeserializeObject<DataTable>(jsonData["ItemsDetails"].ToString());
        itemsTable.TableName = "ItemsDetails"; ds.Tables.Add(itemsTable);

        DataTable ContainerTable = JsonConvert.DeserializeObject<DataTable>(jsonData["ItemsIGMContainerDetails"].ToString());
        ContainerTable.TableName = "ItemsIGMContainerDetails"; ds.Tables.Add(ContainerTable);

        return ds;
    }

    // ─── SCHEME DROPDOWNS ──────────
    protected void ddlSchemeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IsPostBack) return;
        scheme_NOTN();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>CTH_tab();</script>", false);
    }

    protected void ddlScheme_NOTN_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IsPostBack) return;
        ddlScheme_NOTN_SL.Enabled = true;
        scheme_notn_slno();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>CTH_tab();</script>", false);
    }

    public void scheme_NOTN()
    {
        string str = ddlSchemeCode.SelectedValue;
        string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);
        ddlScheme_NOTN.Items.Clear();
        ddlScheme_NOTN_SL.Items.Clear();

        if (s1[0].Trim() != "00")
        {
            adm.SCHEME_IMPORT_CODE = s1[0].Trim(); adm.SCHEME_NOTN = "0"; adm.name = "SCHEME_NOTN";
            ddlScheme_NOTN.DataSource = adm.RetrieveAll_Scheme_Import();
            ddlScheme_NOTN.DataTextField = "SCHEME_NOTN"; ddlScheme_NOTN.DataValueField = "SCHEME_NOTN";
            ddlScheme_NOTN.Items.Add(" "); ddlScheme_NOTN.DataBind();
            scheme_notn_slno();
        }
    }

    public void scheme_notn_slno()
    {
        string str = ddlSchemeCode.SelectedValue;
        string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);
        ddlScheme_NOTN_SL.Items.Clear();
        adm.SCHEME_IMPORT_CODE = s1[0].Trim(); adm.SCHEME_NOTN = ddlScheme_NOTN.SelectedValue; adm.name = "SCHEME_NOTN_SLNO";
        ddlScheme_NOTN_SL.DataSource = adm.RetrieveAll_Scheme_Import();
        ddlScheme_NOTN_SL.DataTextField = "SCHEME_NOTN_SLNO"; ddlScheme_NOTN_SL.DataValueField = "SCHEME_NOTN_SLNO";
        ddlScheme_NOTN_SL.Items.Add(" "); ddlScheme_NOTN_SL.DataBind();
    }

    protected void ddl_SchemeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl_SchemeCode = sender as DropDownList;
        GridViewRow row = (GridViewRow)ddl_SchemeCode.NamingContainer;
        DropDownList ddl_Scheme_NOTN = row.FindControl("ddl_Scheme_NOTN") as DropDownList;
        DropDownList ddl_Scheme_NOTN_SL = row.FindControl("ddl_Scheme_NOTN_SL") as DropDownList;

        string[] schemeParts = ddl_SchemeCode.SelectedValue.Split(new string[] { "-" }, StringSplitOptions.None);
        string schemeCodePart = schemeParts[0].Trim();
        ddl_Scheme_NOTN.Items.Clear(); ddl_Scheme_NOTN_SL.Items.Clear();

        if (schemeCodePart != "00")
        {
            DataSet dsNotn = GetCachedSchemeNotn(schemeCodePart);
            ddl_Scheme_NOTN.DataSource = dsNotn;
            ddl_Scheme_NOTN.DataTextField = "SCHEME_NOTN"; ddl_Scheme_NOTN.DataValueField = "SCHEME_NOTN";
            ddl_Scheme_NOTN.Items.Add(" "); ddl_Scheme_NOTN.DataBind();
        }

        string selectedNotn = ddl_Scheme_NOTN.SelectedValue ?? "";
        DataSet dsNotnSl = GetCachedSchemeNotnSl(schemeCodePart, selectedNotn);
        ddl_Scheme_NOTN_SL.DataSource = dsNotnSl;
        ddl_Scheme_NOTN_SL.DataTextField = "SCHEME_NOTN_SLNO"; ddl_Scheme_NOTN_SL.DataValueField = "SCHEME_NOTN_SLNO";
        ddl_Scheme_NOTN_SL.Items.Add(" "); ddl_Scheme_NOTN_SL.DataBind();
    }

    // ─── JOB NUMBER RETRIEVAL ──────
    public int Retrieve_JobNO()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];
            param[1] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[4] = new SqlParameter("@BRANCH_CODE", Connection.Get_Company_Type());
            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1) { Direction = ParameterDirection.Output };
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000) { Direction = ParameterDirection.Output };

            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(),
                CommandType.StoredProcedure, "GENERAL_DETAILS_SP_AUTOID", param);

            result = Convert.ToInt32(param[2].Value.ToString());
        }
        catch (Exception ex) { Connection.Error_Msg(ex.Message); }
        return result;
    }

    // ─── LISTBOX / FILTER EVENTS ───
    protected void ListBox_INVSlno_SelectedIndexChanged(object sender, EventArgs e)
    {
        Filter_INV_Item();
    }

    public void Filter_INV_Item()
    {
        DataTable dt_GridViewData = ViewState["ItemDetails"] as DataTable;
        if (dt_GridViewData == null || dt_GridViewData.Rows.Count == 0) return;
        if (ListBox_INVSlno.SelectedItem == null) return;

        List<int> selectedSerialNumbers = new List<int>();
        foreach (ListItem INV in ListBox_INVSlno.Items)
        {
            if (INV.Selected) { int val; if (int.TryParse(INV.Text, out val)) selectedSerialNumbers.Add(val); }
        }

        DataTable filteredTable = FilterDataTableBySerialNumbers_INV(dt_GridViewData, selectedSerialNumbers);
        ListBox_ItemSlno.Items.Clear();
        string mode = ddl_Select_ItemRITC.SelectedValue;

        if (mode == "0")
        {
            foreach (DataRow row in filteredTable.Rows)
            {
                string text = row["InvoiceSlNo"] + "~" + row["ItemSlNo"];
                ListBox_ItemSlno.Items.Add(new ListItem(text, text));
            }
        }
        else
        {
            var uniqueRows = filteredTable.AsEnumerable()
                .GroupBy(row => new { Invoice = row["InvoiceSlNo"].ToString(), Ritc = row["HSCode"].ToString() })
                .Select(g => g.First()).CopyToDataTable();

            foreach (DataRow row in uniqueRows.Rows)
            {
                string text = row["InvoiceSlNo"] + "~" + row["HSCode"];
                ListBox_ItemSlno.Items.Add(new ListItem(text, text));
            }
        }
    }

    private DataTable FilterDataTableBySerialNumbers_INV(DataTable dt, List<int> serialNumbers)
    {
        DataTable filteredTable = dt.Clone();
        foreach (DataRow row in dt.Rows)
        {
            int serialNo;
            if (int.TryParse(row["InvoiceSlNo"].ToString(), out serialNo) && serialNumbers.Contains(serialNo))
                filteredTable.ImportRow(row);
        }
        return filteredTable;
    }

    // ─── RADIO: SINGLE / MULTIPLE INVOICE ────
    protected void Rd_SInv_MInv_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Rd_SInv_MInv.SelectedValue == "M")
        {
            DataTable Dt_Temp_Invoice = ViewState["dt_Invoice"] as DataTable;
            gd_TEMP_INV.DataSource = Dt_Temp_Invoice; gd_TEMP_INV.DataBind();
            ViewState["dt_Invoice"] = Dt_Temp_Invoice;
            MP_INV_DETAILS.Show();
            txtInvNo.Enabled = false; txtInvDate.Enabled = false; ddlTerms.Enabled = false; txtCurrency.Enabled = false;
            btn_Inv_Save.Visible = true;
        }
        else
        {
            txtInvNo.Enabled = true; txtInvDate.Enabled = true; ddlTerms.Enabled = true; txtCurrency.Enabled = true;
            btn_Inv_Save.Visible = false;
        }
    }

    public bool INV_BindgridViewData()
    {
        if (ViewState["dt_Invoice"] != null)
        {
            DataTable dt_Current_Inv = (DataTable)ViewState["dt_Invoice"];
            if (gd_TEMP_INV.Rows.Count > 0)
            {
                foreach (GridViewRow row in gd_TEMP_INV.Rows)
                {
                    if (row.RowType != DataControlRowType.DataRow) continue;
                    TextBox txt_Temp_InvoiceNo = (TextBox)row.FindControl("txt_Temp_InvoiceNo");
                    TextBox txt_Temp_InvoiceDate = (TextBox)row.FindControl("txt_Temp_InvoiceDate");
                    TextBox txt_Temp_Currency = (TextBox)row.FindControl("txt_Temp_Currency");
                    TextBox txt_Temp_Terms = (TextBox)row.FindControl("txt_Temp_Terms");

                    if (txt_Temp_InvoiceNo.Text.Trim() != "" && txt_Temp_InvoiceDate.Text.Trim() != ""
                        && txt_Temp_Currency.Text.Trim() != "" && txt_Temp_Terms.Text.Trim() != "")
                    {
                        if (row.RowIndex < dt_Current_Inv.Rows.Count)
                        {
                            dt_Current_Inv.Rows[row.RowIndex]["InvoiceNo"] = txt_Temp_InvoiceNo.Text;
                            dt_Current_Inv.Rows[row.RowIndex]["InvoiceDate"] = txt_Temp_InvoiceDate.Text;
                            dt_Current_Inv.Rows[row.RowIndex]["Currency"] = txt_Temp_Currency.Text;
                            dt_Current_Inv.Rows[row.RowIndex]["Terms"] = txt_Temp_Terms.Text;
                        }
                    }
                    else { Alert_msg("Please Enter All Mandatory Fields..!"); IsValidInv = false; break; }
                }
                ViewState["dt_Invoice"] = dt_Current_Inv;
            }
            else { ViewState["dt_Invoice"] = dt_Current_Inv; }
        }
        else { ViewState["dt_Invoice"] = dt_Temp_Inv; }
        return IsValidInv;
    }

    protected void btn_Inv_Save_Click(object sender, EventArgs e) { INV_BindgridViewData(); }

    // ─── WEB METHODS ────────
    [System.Web.Services.WebMethod]
    public static string Get_Notn_Custom_Master_CTH_NOTN_SLNO(string Notn_no_sl, string Notn_no)
    {
        string Address1 = "";
        if (Notn_no != "" && Notn_no != "019/2006")
        {
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_SLNO";
            Auto.Enamesearch = Notn_no_sl; Auto.Notn_No_Search = Notn_no;
            DataSet ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0) Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
        }
        return Address1;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Custom_Master_CTH_NOTN_SLNO_with_Type(string Notn_no_sl, string Notn_no, string Notn_Type)
    {
        string Address1 = "", IsValidNotn = "";
        if (Notn_no != "" && Notn_no != "019/2006")
        {
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_SLNO_with_Type";
            Auto.Enamesearch = Notn_no_sl; Auto.Notn_No_Search = Notn_no; Auto.Notn_Type = Notn_Type;
            DataSet ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0) IsValidNotn = "Y";
            else { Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_SLNO"; ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH(); if (ds.Tables[0].Rows.Count > 0) IsValidNotn = "Y"; }
            if (IsValidNotn == "Y") Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
        }
        return Address1;
    }

    [System.Web.Services.WebMethod]
    public static string Get_AIDC_Master(string custid, string CTH_No, string AIDC_Notn)
    {
        adminmaster Admin_mas = new adminmaster();
        Admin_mas.AIDC_RITC_NO = CTH_No; Admin_mas.AIDC_NOTN_NO = AIDC_Notn;
        Admin_mas.AIDC_NOTN_SLNO = custid; Admin_mas.Ename = "ITEM_AIDC_NOTN_RATE";
        DataSet ds = Admin_mas.Get_AIDC_CESS_SELECT();
        return ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0]["AIDC_NOTN_RATE"].ToString() : "";
    }

    [System.Web.Services.WebMethod]
    public static string Get_AIDC_Notn(string custid)
    {
        adminmaster Admin_mas = new adminmaster();
        Admin_mas.AIDC_RITC_NO = custid; Admin_mas.Ename = "ITEM_RITC";
        DataSet ds = Admin_mas.Get_AIDC_CESS_SELECT();
        if (ds.Tables[0].Rows.Count > 0) return ds.Tables[0].Rows[0]["AIDC_NOTN_RATE"].ToString();
        return "0.00";
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_txt_IGST_LEVY_SLNO_1E(string Notn_no_sl, string Notn_no)
    {
        if (string.IsNullOrEmpty(Notn_no)) return "";
        Auto_Search Auto = new Auto_Search();
        Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_SLNO_IGST_1E";
        Auto.Enamesearch = Notn_no_sl; Auto.Notn_No_Search = Notn_no;
        DataSet ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        return ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString() : "";
    }

    public static string Ser_Port_of_orgin(string custid, string custid_2)
    {
        Auto_Search Auto = new Auto_Search();
        Auto.Enamesearch = custid;
        Auto.Notn_No_Search = custid_2 == "Air" ? "3" : "5";
        Auto.Ename = "IMP_EXP_Port_of_orgin_Chk";
        DataSet ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0) return "Yes";

        string flag2 = custid_2 == "Air" ? "PORT_MASTER_USER_WISE_LIST_AIR_general" : "PORT_MASTER_USER_WISE_LIST_SEA_LAND_general";
        Auto.Ename = flag2; Auto.NSearch = "";
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0) return "Yes";

        if (custid_2 == "Land")
        {
            Auto.Notn_No_Search = "6"; Auto.Ename = "IMP_EXP_Port_of_orgin_Chk";
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            return ds.Tables[0].Rows.Count > 0 ? "Yes" : "No";
        }
        return "No";
    }

    // ─── EXCEL DOWNLOAD ──────
    protected void ExcelDwnl_Click(object sender, ImageClickEventArgs e)
    {
        WriteJobLog("Button Click", "Excel Download clicked");
        using (SqlConnection exlCon = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString()))
        {
            exlCon.Open();
            SqlCommand Exlcmd = new SqlCommand(
                "SELECT PDF_JOB_NO AS 'JOB NO', PDF_EXP_IMP_NAME AS 'EXP IMP NAME',"
                + "PDF_MODE AS MODE, PDF_UPLOAD_COUNT AS 'UPLOAD COUNT',"
                + "PDF_SAVE_COUNT AS 'SAVE COUNT', PDF_REMARKS AS 'PAGE COUNT',"
                + "PDF_USER_ID AS 'USER', PDF_DATE_TIME AS 'DATE TIME',"
                + "PDF_BRANCH_CODE AS 'BRANCH CODE', PDF_WORKING_PERIOD AS 'WORKING PERIOD'"
                + " FROM PDF_AI_COUNT_DETAILS WHERE PDF_MODE = 'IMP'", exlCon);
            SqlDataAdapter Exlsda = new SqlDataAdapter(Exlcmd);
            DataSet ExlSds = new DataSet();
            Exlsda.Fill(ExlSds);
            exlCon.Close();

            if (ExlSds.Tables[0].Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(ExlSds.Tables[0], "AI_JOB_STATUS");
                    using (MemoryStream ms = new MemoryStream())
                    {
                        wb.SaveAs(ms); ms.Position = 0;
                        Response.Clear();
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=PDF_AI_CountDetails_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
                        Response.BinaryWrite(ms.ToArray());
                        Response.End();
                    }
                }
            }
            else { Alert_msg("No AI JOB Record...!"); }
        }
    }

    // ─── WEBMETHODS: AIDC / IGST ─────
    [System.Web.Services.WebMethod]
    public static object GetAIDCDetails(string ritcNo)
    {
        var adm = new adminmaster();
        adm.AIDC_RITC_NO = ritcNo; adm.Ename = "ITEM_RITC";
        var ds = adm.Get_AIDC_CESS_SELECT();
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            return new
            {
                AIDC_NOTN_NO = ds.Tables[0].Rows[0]["AIDC_NOTN_NO"].ToString(),
                AIDC_NOTN_SLNO = ds.Tables[0].Rows[0]["AIDC_NOTN_SLNO"].ToString(),
                AIDC_NOTN_RATE = ds.Tables[0].Rows[0]["AIDC_NOTN_RATE"].ToString()
            };
        return null;
    }

    [System.Web.Services.WebMethod]
    public static object GetIGSTDetails(string ritcNo)
    {
        Auto_Search Auto = new Auto_Search();
        Auto.Ename = "Get_IGST_NOTN_SLNO_RITC_V2"; Auto.Enamesearch = ritcNo; Auto.Notn_No_Search = ritcNo;
        var ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH_PART_II();
        if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            return new
            {
                LEVY_1NOTIFICATION = ds.Tables[1].Rows[0]["LEVY_1NOTIFICATION"].ToString(),
                LEVY_1NOTIFICATION_SLNO = ds.Tables[1].Rows[0]["LEVY_1NOTIFICATION_SLNO"].ToString(),
                LEVY_1NOTIFICATION_RATE = ds.Tables[1].Rows[0]["LEVY_1NOTIFICATION_RATE"].ToString()
            };
        return null;
    }

    // ─── LOG: CLOSE BUTTON (called via PageMethods since btnClose is client-side only, no postback) ──────
    // No live Page instance in a static WebMethod, so this calls the shared PDFReaderLog App_Code class
    // directly instead of the instance-level WriteJobLog (mirrors Export_PDF_Reader_New_AI.aspx.cs).
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static void LogCloseButtonClick()
    {
        new PDFReaderLog().WriteOcrJobLog(GetJobNoFromSession(), "Button Click", "Close clicked (popup closed)", "IMP");
    }

    // ─── LOG: BROWSER REFRESH after a successful Preview but before the job was saved ──────
    // Called from the client only when Performance Navigation Timing confirms this load was an actual reload.
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static void LogPageRefreshAfterPreview()
    {
        if (HttpContext.Current.Session["ImportPdfAI_PreviewSuccess"] == null) return;
        new PDFReaderLog().WriteOcrJobLog(GetJobNoFromSession(), "Page Refreshed",
            "User refreshed the page after Preview Success but before the job was saved - unsaved grid data was lost.", "IMP");
    }

    private static string GetJobNoFromSession()
    {
        return HttpContext.Current.Session["JOBNO"] != null ? HttpContext.Current.Session["JOBNO"].ToString().Trim() : "";
    }

    // ─── CLIENT / PDF NAME HELPER ──────btn
    public string Get_PdfClient_Name(string imp_name, string Branch_no)
    {
        erm.IMP_CLIENT_ID = "0"; erm.Ename = "FETCH_IMP_PDF_CLIENT_NAME";
        erm.IMP_CLIENT_IEC_NAME = imp_name; erm.IMP_CLIENT_BRANCH_SLNO = Branch_no;
        erm.EWorking_Period = Working_Period;
        DataSet ds_pdf = erm.RetrieveAll_IMP_Client_Master();
        return ds_pdf.Tables[0].Rows.Count > 0 ? ds_pdf.Tables[0].Rows[0]["IMP_PDF_CLIENT_NAME"].ToString() : "";
    }

    // ─── SHARED HELPERS ───────
    public string GetSafeValue(DataTable dt, int rowIndex, string columnName)
    {
        if (dt.Columns.Contains(columnName) && dt.Rows[rowIndex][columnName] != DBNull.Value)
            return dt.Rows[rowIndex][columnName].ToString();
        return string.Empty;
    }

    public string CalculateAmount(string value1, string value2)
    {
        decimal v1, v2;
        if (decimal.TryParse(value1, out v1) && decimal.TryParse(value2, out v2))
            return (v2 * v1 / 100).ToString("N2").Replace(",", "");
        return "0.00";
    }

    private bool Check_PageCount_Expiry()
    {
        try
        {
            if (COMPANY_IDD == "517") { Alert_And_Redirect("YOUR PAGE COUNT IS EXPIRED. PLEASE CONTACT ADMIN"); return false; }
            return true;
        }
        catch { return true; }
    }

    public int PageCount_log(string Status, string pagecounts)
    {
        try
        {
            int pdf_id = 0;
            if (ViewState["Pdf_Id"] != null) int.TryParse(ViewState["Pdf_Id"].ToString(), out pdf_id);

            string imp_Name = ViewState["imp_name"] != null ? ViewState["imp_name"].ToString().Trim() : "";

            ds_Page.PDF_JOB_NO = Session["JOBNO"] != null ? Session["JOBNO"].ToString().Trim() : "";
            ds_Page.PDF_ID = pdf_id.ToString();
            ds_Page.Ename = "";
            ds_Page.PDF_EXP_IMP_NAME = imp_Name;
            ds_Page.PDF_MODE = "IMP";
            ds_Page.PDF_USER_ID = currentuser;
            ds_Page.PDF_STATUS = Status;
			ds_Page.PDF_VENDOR = vendor;
            ds_Page.PDF_UPLOAD_COUNT = Upload_Count;
            ds_Page.PDF_BRANCH_CODE = currentbranch;
            ds_Page.PDF_WORKING_PERIOD = Working_Period;
            ds_Page.PAGE_COUNT = string.IsNullOrEmpty(pagecounts) ? "0" : pagecounts;
            ds_Page.PDF_SAVE_COUNT = (Status == PdfStatus.UPLOAD_SUCCESS) ? "1" : "0";
            ds_Page.PDF_SUCCESS_UPLOAD_COUNT = (Status == PdfStatus.PREVIEW_SUCCESS) ? Upload_page_Count : "0";
            ds_Page.PDF_ERROR_UPLOAD_COUNT = (Status == PdfStatus.PREVIEW_FAILED) ? Upload_Error_Count : "0";

            return ds_Page.OCR_PDF_COUNT_UPDATE_INSERT();
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); return 0; }
    }

    public static class PdfStatus
    {
        public const string PREVIEW_INITIATED = "PREVIEW INITIATED";
        public const string PREVIEW_SUCCESS = "PREVIEW SUCCESS";
        public const string PREVIEW_FAILED = "PREVIEW FAILED";
        public const string UPLOAD_INITIATED = "UPLOAD INITIATED";
        public const string UPLOAD_SUCCESS = "UPLOAD SUCCESS";
        public const string UPLOAD_FAILED = "UPLOAD FAILED";
    }

    // Page count is only ever computed for real PDFs (see the PdfReader block in Get_Upload_File).
    // Local-vendor testing uploads a .txt file, so hd_PageCount stays blank - show that plainly instead of an empty value.
    private string GetPageCountForLog()
    {
        return string.IsNullOrEmpty(hd_PageCount.Value) ? "Local No Cost" : hd_PageCount.Value;
    }

    // ─── FILE LOGGING (Preview Initiated / API Hitting / Job Success) ───
    // Delegates to the shared PDFReaderLog App_Code class (mode "IMP"), same as Export_PDF_Reader_New_AI.aspx.cs
    // and Transaction\General.aspx.cs's OCR_Delete_Jobs - keeps directory/purge/lock logic in one place.
    private void WriteJobLog(string stage, string message)
    {
        string jobNo = "";
        try { jobNo = HttpContext.Current.Session["JOBNO"] != null ? HttpContext.Current.Session["JOBNO"].ToString().Trim() : ""; } catch { }
        pdflog.WriteOcrJobLog(jobNo, stage, message, "IMP");
    }

    // Logs an exception, pulling out the real HTTP status (404, 500, etc.) when it came from a WebException.
    private void LogException(string stage, Exception ex)
    {
        string detail = ex.Message;
        WebException webEx = ex as WebException;
        if (webEx != null && webEx.Response != null)
        {
            HttpWebResponse httpResp = webEx.Response as HttpWebResponse;
            if (httpResp != null)
            {
                detail = "HTTP " + (int)httpResp.StatusCode + " " + httpResp.StatusCode + " - " + ex.Message;
            }
            else
            {
                detail = webEx.Status + " - " + ex.Message;
            }
        }
        WriteJobLog(stage, detail);
    }

    private void InvoiceCharges(string terms, string freight, string insurance, string missCharge)
    {
        Transact.MIS_INSURANCE_RATE = ""; Transact.MIS_FREIGHT_RATE = "";
        Transact.MIS_CHARGES = ""; Transact.MIS_FREIGHT_CHARGES = ""; Transact.MIS_INSURANCE_CHARGES = "";

        freight = string.IsNullOrEmpty(freight) ? "" : freight.Replace(",", "");
        insurance = string.IsNullOrEmpty(insurance) ? "" : insurance.Replace(",", "");
        missCharge = string.IsNullOrEmpty(missCharge) ? "" : missCharge.Replace(",", "");

        decimal freightValue = 0, insuranceValue = 0;
        decimal.TryParse(freight, out freightValue);
        decimal.TryParse(insurance, out insuranceValue);

        Transact.MIS_CHARGES = missCharge;

        if ((terms == "FOB" || terms == "CI") && freightValue <= 0)
        {
            Transact.MIS_FREIGHT_RATE = "20.0000";
            freight = CalculateAmount(Transact.MIS_FREIGHT_RATE, Transact.INVOICE_VALUE);
        }
        if ((terms == "FOB" || terms == "CF") && insuranceValue <= 0)
        {
            string insurance_rate = Get_ClientMaster_Insurance_details();
            if (string.IsNullOrEmpty(insurance_rate)) insurance_rate = "1.1250";
            Transact.MIS_INSURANCE_RATE = insurance_rate;
            insurance = CalculateAmount(insurance_rate, Transact.INVOICE_VALUE);
        }
        if (terms == "FOB" || terms == "CI") Transact.MIS_FREIGHT_CHARGES = freight;
        if (terms == "FOB" || terms == "CF") Transact.MIS_INSURANCE_CHARGES = insurance;
    }

    private string Get_ClientMaster_Insurance_details()
    {
        string Ins_Rate = "";
        string Imp_Name = ViewState["imp_name"].ToString();
        string Branch_Slno = ViewState["branch_slno"].ToString();
        try
        {
            erm.Eimp_exp_id = ""; erm.Eimp_exp_name = Imp_Name;
            erm.Eimp_exp_iecno = ""; erm.Eimp_exp_brslno = Branch_Slno;
            erm.Ename = "Get_Client_InsuraceRate"; erm.EWorking_Period = Working_Period;
            DataSet dtt_clnt = erm.RetrieveAll_Imp_exp_master_STD_TYPE();
            if (dtt_clnt != null && dtt_clnt.Tables[0].Rows.Count > 0)
                Ins_Rate = dtt_clnt.Tables[0].Rows[0]["CLIENT_INSURANCE_RATE"].ToString();
        }
        catch { }
        return Ins_Rate;
    }

    // ─── DELETE SELECTED ─────
    protected void btnDeleteSelected_Click(object sender, EventArgs e)
    {
        WriteJobLog("Button Click", "DELETE ROWS clicked");
        try
        {
            SaveCurrentPageToDataTable();
            DataTable dt_Current = ViewState["ItemDetails"] as DataTable;
            if (dt_Current == null || dt_Current.Rows.Count == 0)
            {
                Alert_msg("No data to delete!");
                return;
            }

            var keysToDelete = new List<string>();
            foreach (GridViewRow row in gv_ItemPDF.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow) continue;
                CheckBox chk = row.FindControl("chk_Delete") as CheckBox;
                if (chk == null || !chk.Checked) continue;

                TextBox txtInvSlNoCtrl = row.FindControl("txtInvSlNo") as TextBox;
                TextBox txtItemSlNoCtrl = row.FindControl("txtItemSlNo") as TextBox;
                if (txtInvSlNoCtrl == null || txtItemSlNoCtrl == null) continue;

                keysToDelete.Add(txtInvSlNoCtrl.Text.Trim() + "~" + txtItemSlNoCtrl.Text.Trim());
            }

            if (keysToDelete.Count == 0)
            {
                Alert_msg("Please select at least one row to delete!");
                return;
            }

            WriteJobLog("Rows Deleted", "Count:" + keysToDelete.Count
                + " | Inv~Item:[" + string.Join(", ", keysToDelete) + "]");

            var rowsToRemove = dt_Current.Rows.Cast<DataRow>()
                .Where(r => keysToDelete.Contains(
                    r["InvoiceSlNo"].ToString().Trim() + "~" + r["ItemSlNo"].ToString().Trim()))
                .ToList();

            foreach (DataRow dr in rowsToRemove)
                dt_Current.Rows.Remove(dr);

            dt_Current.AcceptChanges();

            foreach (var grp in dt_Current.AsEnumerable()
                .GroupBy(r => r["InvoiceSlNo"].ToString()).ToList())
            {
                int seq = 1;
                foreach (DataRow dr in grp) { dr["ItemSlNo"] = seq.ToString(); seq++; }
            }

            ViewState["ItemDetails"] = dt_Current;
            ViewState["GridViewData"] = dt_Current;

            int totalPages = (int)Math.Ceiling((double)dt_Current.Rows.Count / (double)gv_ItemPDF.PageSize);
            int targetPage = Math.Min(CurrentPageIndex + 1, Math.Max(totalPages, 1));
            BindGridPaged(targetPage);

            if (gv_ItemPDF.HeaderRow != null)
            {
                gv_ItemPDF.UseAccessibleHeader = true;
                gv_ItemPDF.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            Select_ItemRITC();

            lbl_loading.Text = "<span style='color:green;font-weight:bold;'>✅ "
                + keysToDelete.Count + " row(s) deleted. "
                + dt_Current.Rows.Count + " row(s) remaining.</span>";
        }
        catch (Exception ex)
        {
            log.makeLog("Message ==> " + ex.Message);
            LogException("Delete Selected Failed", ex);
            lblmsg.Text = "Delete Error: " + ex.Message;
        }
    }

    // ─── GET DATA TABLE FROM GRID VIEW ─────────
    private DataTable GetDataTableFromGridView()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("InvoiceSlNo"); dt.Columns.Add("ItemSlNo"); dt.Columns.Add("ITEM_DESC");
        dt.Columns.Add("Quantity"); dt.Columns.Add("Rate"); dt.Columns.Add("Amount");
        dt.Columns.Add("QtyCode"); dt.Columns.Add("HSCode"); dt.Columns.Add("SchemeCode");
        dt.Columns.Add("Basic_Noti"); dt.Columns.Add("Basic_Slno"); dt.Columns.Add("Basic_Rate");
        dt.Columns.Add("info_MSR"); dt.Columns.Add("info_UQC"); dt.Columns.Add("MANUFACTURER");
        dt.Columns.Add("END_USE_OF_ITEM"); dt.Columns.Add("itemCountyof_orgin");
        dt.Columns.Add("SW_Noti"); dt.Columns.Add("SW_Slno"); dt.Columns.Add("SW_Rate");
        dt.Columns.Add("AIDC_CessNoti"); dt.Columns.Add("AIDC_CessSlno"); dt.Columns.Add("AIDC_CessRate");
        dt.Columns.Add("IGST_Noti"); dt.Columns.Add("IGST_SlNo"); dt.Columns.Add("IGST_Rate");
        dt.Columns.Add("PartNo"); dt.Columns.Add("Scheme_NOTN"); dt.Columns.Add("Scheme_NOTN_SL");
        dt.Columns.Add("IGST_LEVY_COMPENSATION_CESS_NOTN");
        dt.Columns.Add("IGST_LEVY_COMPENSATION_CESS_SLNO");
        dt.Columns.Add("IGST_LEVY_COMPENSATION_CESS_RATE");

        DataTable dt_VS = ViewState["ItemDetails"] as DataTable;

        foreach (GridViewRow row in gv_ItemPDF.Rows)
        {
            if (row.RowType != DataControlRowType.DataRow) continue;

            string invSlNo = GetTxtValue(row, "txtInvSlNo");
            string itemSlNo = GetTxtValue(row, "txtItemSlNo");
            DataRow dr = dt.NewRow();

            dr["InvoiceSlNo"] = invSlNo; dr["ItemSlNo"] = itemSlNo;
            dr["ITEM_DESC"] = GetTxtValue(row, "txtItemDesc");
            dr["Quantity"] = GetTxtValue(row, "txtItemQty");
            dr["Rate"] = GetTxtValue(row, "txtItemUnitPrice");
            dr["Amount"] = GetTxtValue(row, "txtItemAmt");
            dr["QtyCode"] = GetTxtValue(row, "txtQTYCode");
            dr["HSCode"] = GetTxtValue(row, "txt_CTH");
            dr["SchemeCode"] = GetDDLValue(row, "ddl_SchemeCode");
            dr["Basic_Noti"] = GetTxtValue(row, "txtBasicNoti");
            dr["Basic_Slno"] = GetTxtValue(row, "txtBasicSlno");
            dr["Basic_Rate"] = GetTxtValue(row, "txt_Basic_Rate");
            dr["info_MSR"] = GetTxtValue(row, "txtinfoMSR");
            dr["info_UQC"] = GetTxtValue(row, "txtinfo_UQC");
            dr["MANUFACTURER"] = GetTxtValue(row, "txt_Manufacturer");
            dr["END_USE_OF_ITEM"] = GetTxtValue(row, "txtEndUseOfItems");
            dr["itemCountyof_orgin"] = GetTxtValue(row, "txtitemCountyoforgin");
            dr["SW_Noti"] = GetTxtValue(row, "txt_SW_Noti");
            dr["SW_Slno"] = GetTxtValue(row, "txt_SW_Slno");
            dr["SW_Rate"] = GetTxtValue(row, "txtSW_Rate");
            dr["AIDC_CessNoti"] = GetTxtValue(row, "txt_AIDCCessNoti");
            dr["AIDC_CessSlno"] = GetTxtValue(row, "txt_AIDCCessSlno");
            dr["AIDC_CessRate"] = GetTxtValue(row, "txt_AIDCCessRate");
            dr["IGST_Noti"] = GetTxtValue(row, "txt_IGSTNoti");
            dr["IGST_SlNo"] = GetTxtValue(row, "txt_IGSTSlNo");
            dr["IGST_Rate"] = GetTxtValue(row, "txt_IGSTRate");
            dr["PartNo"] = GetTxtValue(row, "txt_Part_No");

            if (dt_VS != null)
            {
                DataRow[] matched = dt_VS.Select("InvoiceSlNo='" + invSlNo + "' AND ItemSlNo='" + itemSlNo + "'");
                DataRow vs = matched.Length > 0 ? matched[0] : null;
                dr["Scheme_NOTN"] = GetVSValue(vs, "Scheme_NOTN");
                dr["Scheme_NOTN_SL"] = GetVSValue(vs, "Scheme_NOTN_SL");
                dr["IGST_LEVY_COMPENSATION_CESS_NOTN"] = GetVSValue(vs, "IGST_LEVY_COMPENSATION_CESS_NOTN");
                dr["IGST_LEVY_COMPENSATION_CESS_SLNO"] = GetVSValue(vs, "IGST_LEVY_COMPENSATION_CESS_SLNO");
                dr["IGST_LEVY_COMPENSATION_CESS_RATE"] = GetVSValue(vs, "IGST_LEVY_COMPENSATION_CESS_RATE");
            }
            else
            {
                dr["Scheme_NOTN"] = dr["Scheme_NOTN_SL"] =
                dr["IGST_LEVY_COMPENSATION_CESS_NOTN"] =
                dr["IGST_LEVY_COMPENSATION_CESS_SLNO"] =
                dr["IGST_LEVY_COMPENSATION_CESS_RATE"] = string.Empty;
            }

            dt.Rows.Add(dr);
        }
        return dt;
    }

    private string GetVSValue(DataRow dr, string columnName)
    {
        if (dr == null) return string.Empty;
        if (dr.Table.Columns.Contains(columnName) && dr[columnName] != DBNull.Value)
            return dr[columnName].ToString().Trim();
        return string.Empty;
    }

    private string GetTxtValue(GridViewRow row, string controlId)
    {
        TextBox tb = row.FindControl(controlId) as TextBox;
        return tb != null ? tb.Text.Trim() : string.Empty;
    }

    private string GetDDLValue(GridViewRow row, string controlId)
    {
        DropDownList ddl = row.FindControl(controlId) as DropDownList;
        return ddl != null ? ddl.SelectedValue : string.Empty;
    }

    // ─── APPLY FILTER BUTTON ───────
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        WriteJobLog("Button Click", "Apply Filter clicked");
        try
        {
            SaveCurrentPageToDataTable();
            DataTable GridViewData = ViewState["ItemDetails"] as DataTable;
            if (GridViewData == null || GridViewData.Rows.Count == 0)
            {
                Alert_msg("No data loaded. Please Preview a PDF first!");
                return;
            }

            if (ddl_Select_ItemRITC.SelectedValue == "2")
            {
                SaveVisibleGridEditsToMaster(GridViewData);
                ViewState["ItemDetails"] = GridViewData;
                ViewState["GridViewData"] = GridViewData;

                var empRows = GridViewData.AsEnumerable()
                    .Where(row => string.IsNullOrWhiteSpace(
                        row["HSCode"] == DBNull.Value ? "" : row["HSCode"].ToString()))
                    .ToList();

                if (empRows.Count > 0)
                {
                    ListBox_ItemSlno.Items.Clear();
                    ListBox_INVSlno.Items.Clear();

                    foreach (DataRow row in empRows.Select(r => r))
                    {
                        string invNo = row["InvoiceSlNo"].ToString();
                        string itemNo = row["ItemSlNo"].ToString();
                        string text = invNo + "~" + itemNo;

                        if (!ListBox_INVSlno.Items.Contains(new ListItem(invNo, invNo)))
                        { ListItem li = new ListItem(invNo, invNo) { Selected = true }; ListBox_INVSlno.Items.Add(li); }
                        else { ListBox_INVSlno.Items.FindByValue(invNo).Selected = true; }

                        ListBox_ItemSlno.Items.Add(new ListItem(text, text) { Selected = true });
                    }

                    gv_ItemPDF.AllowPaging = false;
                    gv_ItemPDF.DataSource = empRows.CopyToDataTable();
                    gv_ItemPDF.DataBind();

                    Alert_msg("<span style='font-weight:bold;'>Showing "
                        + empRows.Count + " item(s) with empty CTH. Total records: "
                        + GridViewData.Rows.Count + " (unchanged).</span>");
                }
                else
                {
                    Alert_msg("No items with Empty CTH found!");
                }
                return;
            }

            if (ListBox_INVSlno.SelectedItem == null || ListBox_ItemSlno.SelectedItem == null)
            {
                Alert_msg("Please Select Inv & Item...!");
                return;
            }

            SaveVisibleGridEditsToMaster(GridViewData);

            DataTable filteredTable = FilterDataTableBySerialNumbers(GridViewData);

            ViewState["ItemDetails"] = GridViewData;
            ViewState["GridViewData"] = GridViewData;

            if (filteredTable != null && filteredTable.Rows.Count > 0)
            {
                ViewState["ItemDetails"] = GridViewData;
                ViewState["FilteredData"] = filteredTable;
                ViewState["IsFiltered"] = true;
                BindGridPaged_Filtered(1);
            }
            else
            {
                BindGridPaged(CurrentPageIndex + 1);
            }
        }
        catch (Exception ex)
        {
            log.makeLog("Message ==> " + ex.Message);
            LogException("Load Item Failed", ex);
            lblmsg.Text = " Message ==> " + ex.Message + " InnerException ==> " + ex.InnerException + " StackTrace ==>" + ex.StackTrace;
        }
    }

    // ─── SAVE VISIBLE GRID EDITS TO MASTER ─────
    private void SaveVisibleGridEditsToMaster(DataTable masterDt)
    {
        foreach (GridViewRow row in gv_ItemPDF.Rows)
        {
            if (row.RowType != DataControlRowType.DataRow) continue;

            TextBox txtInvSlNo = row.FindControl("txtInvSlNo") as TextBox;
            TextBox txtItemSlNo = row.FindControl("txtItemSlNo") as TextBox;
            if (txtInvSlNo == null || txtItemSlNo == null) continue;

            string invKey = txtInvSlNo.Text.Trim();
            string itemKey = txtItemSlNo.Text.Trim();

            DataRow[] matched = masterDt.Select("InvoiceSlNo='" + invKey + "' AND ItemSlNo='" + itemKey + "'");
            if (matched.Length == 0) continue;
            DataRow dr = matched[0];

            dr["ITEM_DESC"] = GetTxtValue(row, "txtItemDesc");
            dr["QtyCode"] = GetTxtValue(row, "txtQTYCode");
            dr["HSCode"] = GetTxtValue(row, "txt_CTH");
            dr["Basic_Noti"] = GetTxtValue(row, "txtBasicNoti");
            dr["Basic_Slno"] = GetTxtValue(row, "txtBasicSlno");
            dr["Basic_Rate"] = GetTxtValue(row, "txt_Basic_Rate");
            dr["info_MSR"] = GetTxtValue(row, "txtinfoMSR");
            dr["info_UQC"] = GetTxtValue(row, "txtinfo_UQC");
            dr["itemCountyof_orgin"] = GetTxtValue(row, "txtitemCountyoforgin");
            dr["SW_Noti"] = GetTxtValue(row, "txt_SW_Noti");
            dr["SW_Slno"] = GetTxtValue(row, "txt_SW_Slno");
            dr["SW_Rate"] = GetTxtValue(row, "txtSW_Rate");
            dr["AIDC_CessNoti"] = GetTxtValue(row, "txt_AIDCCessNoti");
            dr["AIDC_CessSlno"] = GetTxtValue(row, "txt_AIDCCessSlno");
            dr["AIDC_CessRate"] = GetTxtValue(row, "txt_AIDCCessRate");
            dr["IGST_Noti"] = GetTxtValue(row, "txt_IGSTNoti");
            dr["IGST_SlNo"] = GetTxtValue(row, "txt_IGSTSlNo");
            dr["IGST_Rate"] = GetTxtValue(row, "txt_IGSTRate");
            dr["END_USE_OF_ITEM"] = GetTxtValue(row, "txtEndUseOfItems");
            dr["MANUFACTURER"] = GetTxtValue(row, "txt_Manufacturer");
            dr["SchemeCode"] = GetDDLValue(row, "ddl_SchemeCode");
            dr["Scheme_NOTN"] = GetDDLValue(row, "ddl_Scheme_NOTN");
            dr["Scheme_NOTN_SL"] = GetDDLValue(row, "ddl_Scheme_NOTN_SL");
        }
    }

    // ─── LOAD ITEM BUTTON ─────────
    protected void btnAll_Item_Click(object sender, EventArgs e)
    {
        WriteJobLog("Button Click", "Load Item clicked");
        try
        {
            SaveCurrentPageToDataTable();
            DataTable GridViewData = ViewState["ItemDetails"] as DataTable;
            if (GridViewData == null || GridViewData.Rows.Count == 0)
            {
                Alert_msg("No data available!");
                return;
            }

            SaveVisibleGridEditsToMaster(GridViewData);


            ViewState["IsFiltered"] = false;
            ViewState["FilteredData"] = null;

            ViewState["ItemDetails"] = GridViewData;
            ViewState["GridViewData"] = GridViewData;

            BindGridPaged(CurrentPageIndex + 1);

            Filter_INV_Item();
            Select_ItemRITC();
        }
        catch (Exception ex)
        {
            log.makeLog("Message ==> " + ex.Message);
            LogException("All Item Failed", ex);
            lblmsg.Text = " Message ==> " + ex.Message
                + " InnerException ==> " + ex.InnerException
                + " StackTrace ==>" + ex.StackTrace;
        }
    }
    private void BindGridPaged_Filtered(int pageIndex)
    {
        DataTable dt = ViewState["FilteredData"] as DataTable;
        if (dt == null) return;

        gv_ItemPDF.AllowPaging = true;
        gv_ItemPDF.PageSize = 100;
        gv_ItemPDF.DataSource = dt;
        gv_ItemPDF.PageIndex = pageIndex - 1;
        gv_ItemPDF.DataBind();

        CurrentPageIndex = pageIndex - 1;
        UpdatePageControls();

        Alert_msg("<span style='font-weight:bold;'>Showing " + dt.Rows.Count + " filtered rows (Page " + pageIndex + ")</span>");
    }
    public void Get_COUNTRY_NAME_PORT_NAME(string COUNTRY_OF_ORIGIN, string PORT_OF_ORIGIN)
    {
        DataSet ds_con = new DataSet();
        QueueObj.A1 = "";
        QueueObj.A2 = "";
        QueueObj.A3 = "VALIDATE_PORT_COUNTRY";
        QueueObj.A4 = PORT_OF_ORIGIN;
        QueueObj.A5 = COUNTRY_OF_ORIGIN;
        QueueObj.A6 = ddlTransportMode.SelectedValue.ToUpper(); // AIR/SEA
        QueueObj.A7 = "";
        ds_con = OPM.OCR_PDF_PORT_MASTER(QueueObj);

        if (ds_con != null && ds_con.Tables.Count > 0 && ds_con.Tables[0].Rows.Count > 0)
        {
            txtCountryOfOrigin.Text = ds_con.Tables[0].Rows[0]["COUNTRY_NAME"].ToString();
        }
        if (ds_con != null && ds_con.Tables.Count > 0 && ds_con.Tables[1].Rows.Count > 0 && !(ds_con.Tables[1].Rows.Count > 1))
        {
            txtPortOfOrigin.Text = ds_con.Tables[1].Rows[0]["PORT_NAME"].ToString();
        }
    }
    private void SaveCurrentPageToDataTable()
    {
        if (ViewState["ItemDetails"] == null) return;
        DataTable Dt_Item = (DataTable)ViewState["ItemDetails"];

        foreach (GridViewRow row in gv_ItemPDF.Rows)
        {
            if (row.RowType != DataControlRowType.DataRow) continue;

            TextBox txtInvSlNoCtrl = (TextBox)row.FindControl("txtInvSlNo");
            TextBox txtItemSlNoCtrl = (TextBox)row.FindControl("txtItemSlNo");
            if (txtInvSlNoCtrl == null || txtItemSlNoCtrl == null) continue;

            string invKey = txtInvSlNoCtrl.Text.Trim();
            string itemKey = txtItemSlNoCtrl.Text.Trim();

            DataRow[] matched = Dt_Item.Select(
                "InvoiceSlNo='" + invKey + "' AND ItemSlNo='" + itemKey + "'");
            if (matched.Length == 0) continue;
            DataRow dr = matched[0];

            TextBox txtItemDesc = (TextBox)row.FindControl("txtItemDesc");
            TextBox txtQTYCode = (TextBox)row.FindControl("txtQTYCode");
            TextBox txtCTH = (TextBox)row.FindControl("txt_CTH");
            TextBox txtBasicNoti = (TextBox)row.FindControl("txtBasicNoti");
            TextBox txtBasicSlno = (TextBox)row.FindControl("txtBasicSlno");
            TextBox txt_Basic_Rate = (TextBox)row.FindControl("txt_Basic_Rate");
            TextBox txt_Manufacturer = (TextBox)row.FindControl("txt_Manufacturer");
            TextBox txtEndUseOfItems = (TextBox)row.FindControl("txtEndUseOfItems");
            TextBox txtitemCounty = (TextBox)row.FindControl("txtitemCountyoforgin");
            TextBox txtSW_Noti = (TextBox)row.FindControl("txt_SW_Noti");
            TextBox txtSW_Slno = (TextBox)row.FindControl("txt_SW_Slno");
            TextBox txtSW_Rate = (TextBox)row.FindControl("txtSW_Rate");
            TextBox txt_AIDCNoti = (TextBox)row.FindControl("txt_AIDCCessNoti");
            TextBox txt_AIDCSlno = (TextBox)row.FindControl("txt_AIDCCessSlno");
            TextBox txt_AIDCRate = (TextBox)row.FindControl("txt_AIDCCessRate");
            TextBox txt_IGSTNoti = (TextBox)row.FindControl("txt_IGSTNoti");
            TextBox txt_IGSTSlNo = (TextBox)row.FindControl("txt_IGSTSlNo");
            TextBox txt_IGSTRate = (TextBox)row.FindControl("txt_IGSTRate");
            DropDownList ddl_Scheme = (DropDownList)row.FindControl("ddl_SchemeCode");
            DropDownList ddl_NOTN = (DropDownList)row.FindControl("ddl_Scheme_NOTN");
            DropDownList ddl_NOTN_SL = (DropDownList)row.FindControl("ddl_Scheme_NOTN_SL");

            if (txtItemDesc != null) dr["ITEM_DESC"] = txtItemDesc.Text;
            if (txtQTYCode != null) dr["QtyCode"] = txtQTYCode.Text;
            if (txtCTH != null) dr["HSCode"] = txtCTH.Text;
            if (txtBasicNoti != null) dr["Basic_Noti"] = txtBasicNoti.Text;
            if (txtBasicSlno != null) dr["Basic_Slno"] = txtBasicSlno.Text;
            if (txt_Basic_Rate != null) dr["Basic_Rate"] = txt_Basic_Rate.Text;
            if (txt_Manufacturer != null) dr["MANUFACTURER"] = txt_Manufacturer.Text;
            if (txtEndUseOfItems != null)
            {
                string eu = txtEndUseOfItems.Text.Trim();
                dr["END_USE_OF_ITEM"] = eu.Contains('-') ? eu.Split('-')[0] : eu;
            }
            if (txtitemCounty != null)
            {
                string co = txtitemCounty.Text.Trim();
                dr["itemCountyof_orgin"] = co.Contains('-') ? co.Split('-')[0] : co;
            }
            if (txtSW_Noti != null) dr["SW_Noti"] = txtSW_Noti.Text;
            if (txtSW_Slno != null) dr["SW_Slno"] = txtSW_Slno.Text;
            if (txtSW_Rate != null) dr["SW_Rate"] = txtSW_Rate.Text;
            if (txt_AIDCNoti != null) dr["AIDC_CessNoti"] = txt_AIDCNoti.Text;
            if (txt_AIDCSlno != null) dr["AIDC_CessSlno"] = txt_AIDCSlno.Text;
            if (txt_AIDCRate != null) dr["AIDC_CessRate"] = txt_AIDCRate.Text;
            if (txt_IGSTNoti != null) dr["IGST_Noti"] = txt_IGSTNoti.Text;
            if (txt_IGSTSlNo != null) dr["IGST_SlNo"] = txt_IGSTSlNo.Text;
            if (txt_IGSTRate != null) dr["IGST_Rate"] = txt_IGSTRate.Text;
            if (ddl_Scheme != null) dr["SchemeCode"] = ddl_Scheme.SelectedValue;
            if (ddl_NOTN != null) dr["Scheme_NOTN"] = ddl_NOTN.SelectedValue;
            if (ddl_NOTN_SL != null) dr["Scheme_NOTN_SL"] = ddl_NOTN_SL.SelectedValue;
        }

        ViewState["ItemDetails"] = Dt_Item; // persist back
    }

    private void checkvendor()
    {
        try
        {
            DataSet dss = new DataSet();
            Global_variables ObjUBO = new Global_variables();
            Admin_User_Creation_cs UC = new Admin_User_Creation_cs();

            ObjUBO.A1 = COMPANY_LICENSE;
            ObjUBO.A2 = COMPANY_ID;
            ObjUBO.A3 = "I";
            ObjUBO.A4 = currentuser;
            ObjUBO.A40 = "get_vendor_details";
            ObjUBO.A5 = SELECT_BRANCH;

            dss = UC.Admin_Premium_Services_Select(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                pdf_count = dss.Tables[0].Rows[0]["PDF_UPLOAD"].ToString();
                vendor = dss.Tables[0].Rows[0]["VENDOR"].ToString();
            }
            else
            {
                vendor = "Royal";
                pdf_count = "0";
            }
        }
        catch (Exception ex)
        {
            vendor = "Royal";
            log.makeLog("vendor Error: " + ex.Message);
        }
    }
    public string UploadPdfExtraction(string FilePath, string pdfClientName)
    {
        string result = "";

 
        PdfClientName = !string.IsNullOrWhiteSpace(pdfClientName)
                        ? pdfClientName.Trim() : "";

        ViewState["PdfClientName"] = PdfClientName;

        string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
        byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
        byte[] trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
            "http://www.ocrapiservice.royaltechsystems.co.in/api/invoice/royaltechocr");

        if (!string.IsNullOrWhiteSpace(PdfClientName))
        {
            request.Headers.Add("ApiKey", "Royal");
        }

        request.Method = "POST";
        request.ContentType = "multipart/form-data; boundary=" + boundary;
        request.KeepAlive = true;
        request.AllowWriteStreamBuffering = false;
        request.SendChunked = true;
        request.Timeout = 10 * 60 * 1000;
        request.ReadWriteTimeout = 10 * 60 * 1000;

        using (Stream requestStream = request.GetRequestStream())
        {
            NameValueCollection formFields = new NameValueCollection
        {
            { "CompanyID",        Connection.Company_License() },
            { "UserID",           Connection.Current_User()    },
            { "BranchCode",       Connection.Current_Branch()  },
            { "JobNo",            txtjobPS.Text.Trim()         },
            { "JobType",          "IMP"                        },
            { "WorkingPeriod",    Connection.WorkingPeriod()   },
            { "PageCount",        "0"                          },
            { "PdfCount",         "0"                          },
            { "JobStatus",        "N"                          },
            { "FileName",         "1"                          },
            { "InvoiceStartTime", DateTime.Now.ToString()      },
            { "PdfClientName",    PdfClientName                }
        };

            foreach (string key in formFields)
            {
                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                string fieldData = "Content-Disposition: form-data; name=\""
                                 + key + "\"\r\n\r\n" + formFields[key];
                byte[] fieldBytes = Encoding.UTF8.GetBytes(fieldData);
                requestStream.Write(fieldBytes, 0, fieldBytes.Length);
            }

            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            string fileHeader = "Content-Disposition: form-data; name=\"File\"; filename=\""
                + Path.GetFileName(FilePath)
                + "\"\r\nContent-Type: application/pdf\r\n\r\n";
            byte[] fileHeaderBytes = Encoding.UTF8.GetBytes(fileHeader);
            requestStream.Write(fileHeaderBytes, 0, fileHeaderBytes.Length);

            using (var fileStream = new FileStream(
                FilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 131072))
            {
                byte[] buffer = new byte[131072];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    requestStream.Write(buffer, 0, bytesRead);
            }

            requestStream.Write(trailer, 0, trailer.Length);
        }

        using (WebResponse webResp = request.GetResponse())
        using (StreamReader reader = new StreamReader(webResp.GetResponseStream()))
        {
            result = reader.ReadToEnd();
        }

        return result;
    }
}
