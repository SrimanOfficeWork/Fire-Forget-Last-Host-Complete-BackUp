using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using Microsoft.ApplicationBlocks.Data;
using Microsoft.Reporting.WebForms;
using System.Text.RegularExpressions;
using Outlook = Microsoft.Office.Interop.Outlook;
using BussinessObject;

public partial class FlatFile_Export_FlatFile_Generation_SingleWindow : ThemeClass
{
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, val, errorFolder_json;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();

    DataSet ds = new DataSet();
    DataSet dss = new DataSet();

    public int currentrow = 0, Selected_Row = 0, Cell_Row = 0, ColumnIndex = 0;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, IS_Imgbtn, sealtype_txt = "";
    public string SELECT_TYPE, SELECT_BRANCH;
    public string JOB_LOCK, JOB_RELEASE, JOB_USER;
    CheckList CHKLIST = new CheckList();
    Export_FlatFile_Generation FlatFile = new Export_FlatFile_Generation();

    Export_General_New Export = new Export_General_New();

    //Customer c = new Customer();
    Date_Time dt = new Date_Time();
    AppSession aps = new AppSession();
    // eroyalmaster erm = new eroyalmaster();
    adminmaster erm = new adminmaster();
    eroyalmaster Imp_Exp = new eroyalmaster();

    EXP_Validation EV = new EXP_Validation();
    IMP_Validation IV = new IMP_Validation();
    UserBO ObjUBO = new UserBO();

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    public string errorFolder = "", logline = "", logFileName = "", targetPath = "";
    public string folderName = "/Submission";
    ErrorLogs er = new ErrorLogs();
    public string createfilename = "";
    public char ch = Convert.ToChar(29);
    StreamWriter sw;
    //TextWriter sw;
    //Html32TextWriter sw;
    public string Amendment_Type = "";
    public string Amendment_No = "";
    public string Amendment_Date = "";
    public string SRNO = "";
    public int is_Annexure_Mode = 0;
    public string CHA_NO = "", ICEGATE_ID = "", SUPDOC_ICEGATE_ID = "";
    public string ICEGATE_EMAIL_ID = "", ICEGATE_EMAIL_PWD = "";
    public string EMail_ID = "";
    public string SB_NO = "";
    public string SB_DATE = "", Outlook_From_mail_Address = "";
    public string COMPANY_ID = "";


    #region General_Details

    public string JOBID;
    public string JOBNO;
    public string DDMMYY_JOBDATE, GetDate_ddmmyy;
    public string JOBDATE;
    public string TRANSPORT_MODE;
    public string CUSTOMS_HOUSE;
    public string SB_TYPE;
    public string EXPORTER_NAME;
    public string BRANCH_NO;
    public string IEC_NO;
    public string ADDRESS1;
    public string ADDRESS2;
    public string ADDRESS3;
    public string ADDRESS4;
    public string ADDRESS5;
    public string TYPE_OF_EXPORTER;
    public string PORT_OF_LOADING;
    public string IMP_EXP_TYPE;

    
    public string ADCODE;
    public string BANK_ACCOUNT;
    public string DRAWBACK_ACCOUNT;
    public string CONSIGNEE_NAME;
    public string CONSIGNEE_ADD1;
    public string CONSIGNEE_ADD2;
    public string CONSIGNEE_ADD3;
    public string CONSIGNEE_ADD4;
    public string CONSIGNEE_ADD5;
    public string COUNTRY_DISCHARGE;
    public string PORT_DISCHARGE;
    public string COUNTRY_FINAL_DEST;
    public string PORT_FINAL_DEST;
    public string STATE_OF_EXPORT;
    public string NFEI;
    public string NFEI_TYPE;
    public string RBI_WAIVER_NO;
    public string RBI_WAIVER_DATE;
    public string MARKS_NO;
    public string EPZ_CODE = "";
    public string EXPORTER_CLASS = "";

    public string GROSS_WEIGHT;
    public string UNIT_CODE;
    public string NET_WEIGHT;
    public string NATURE_OF_CARGO;
    public string MARKS_NOS;
    public string TOTAL_PACKAGES;
    public string LOOSE_PACKETS;
    public string NO_CONTAINERS;
    public string ANNEX_AIR_MAWB_NO;
    public string ANNEX_AIR_HAWB_NO;
    public string ROTATION_DATE;
    public string ROTATION_NO;
    public string ANNEX_SEA_FAC_STUFFED;
    public string ANNEX_SEA_SAMPLE_ACCOM;
    public string ANNEX_SEA_SEAL_TYPE;
    public string PMV_VALUE;
    public string JOB_STATUS;

    public string GSTN_TYPE;
    public string GSTN_ID;

    #endregion

    #region Packing List

    public string ANNEX_SEA_PACK_FROM;
    public string ANNEX_SEA_PACK_TO;
    public string ANNEX_SEA_PACK_PACKAGETYPE;
    public string ANNEX_SEA_PACK_FROMDESC;
    public string ANNEX_SEA_PACK_TODESC;


    #endregion

    #region Container

    public string ANNEX_SEA_CON_ID;
    //public string ANNEX_SEA_CON_JOBNO;
    public string ANNEX_SEA_CON_CONTAINERNO;
    public string ANNEX_SEA_CON_SIZE;
    public string ANNEX_SEA_CON_TYPE;
    public string ANNEX_SEA_CON_EXCISE_SEALNO;
    public string ANNEX_SEA_CON_SEAL_DATE;

    public string ANNEX_SEA_CON_SEALTYPE_INDICATOR;
    public string ANNEX_SEA_CON_SEAL_DEVICEID;
    public string ANNEX_SEA_CON_DOC_TYPE;
    public string ANNEX_SEA_CON_DOC_NUMBER;

    #endregion

    #region Invoice_Details

    public string INVOICE_ID;
    //public string JOBNO;
    //public string JOBDATE;
    public string INVOICE_SLNO;
    public string INVOICE_NO;
    public string INVOICE_DATE;
    public string PAYMENT_METHOD;
    public string PERIOD_PAYMENT;
    public string INVOICE_VALUE;
    public string INVOICE_CURRENCY;
    public string EXCHANGE_RATE;
    public string CONTRACT_NO;
    public string TERMS;
    public string BUYER;
    public string BUYER_NAME;
    public string BUYER_ADDRESS;
    public string BUYER_ADDRESS1;
    public string BUYER_ADDRESS2;
    public string BUYER_ADDRESS3;
    public string BUYER_ADDRESS4;
    public string COMMISSION_RATE;
    public string COMMISSION_CHARGES;
    public string COMMISSION_CURRENCY;
    public string FOB_RATE;
    public string FOB_CHARGES;
    public string FOB_CURRENCY;
    public string PACKMISC_RATE;
    public string PACKMISC_CHARGES;
    public string PACKMISC_CURRENCY;
    public string OTHER_DEDUCTION_RATE;
    public string OTHER_DEDUCTION_CHARGES;
    public string OTHER_DEDUCTION_CURRENCY;
    public string FREIGHT_RATE;
    public string FREIGHT_CHARGES;
    public string FREIGHT_CURRENCY;
    public string INSURANCE_RATE;
    public string INSURANCE_CHARGES;
    public string INSURANCE_CURRENCY;
    public string WHEATHER_UNIT_PRICE;


    public string NON_STD_EFFECT_DT_EXP;
    public string NON_STD_BANKNAME;
    public string NON_STD_CERTIFICATE_NO;
    public string NON_STD_CERTIFICATE_DATE;

    public string TERMS_PLACE;
    public string THIRDPARTY_NAME;
    public string THIRDPARTY_ADD1;
    public string THIRDPARTY_ADD2;
    public string THIRDPARTY_CITY;
    public string T_PARTY_COUNTRY_SUB_DIV;
    public string T_PARTY_COUNTRY_CODE;
    public string T_PARTY_PIN;
    public string AUTHORIZED_ECONOMIC_OPERATOR_CODE;
    public string A_E_O_COUNTRY;
    public string AUTHORIZED_ECONOMIC_OPERATOR;


    //******** Exchange Rate ********//

    public string Standard_Currency = "Y";
    public string Currency_Name;
    public string EXCHANGE_UNIT;
    public string Effective_Date = "";

    #endregion

    #region Item_Details

    public string ITEM_ID;
    //public string JOBNO;
    //public string INVOICE_SLNO;
    //public string INVOICE_NO;
    public string ITEM_SLNO;
    public string ITEM_DESCRIPTION1;
    public string ITEM_DESCRIPTION2;
    public string ITEM_DESCRIPTION3;
    public string RITCNO;
    public string ITEM_QTY;
    public string ITEM_QTY_CODE;
    public string ITEM_UNIT_PRICE;
    public string ITEM_PER;
    public string ITEM_AMOUNT;
    public string ITEM_PMVVALUE, PMV_PER_UNIT, PMV_METHOD;
    public string ITEM_SCHEME_CODE;
    public string ITEM_ACCESSORIES_DESC;
    public string ITEM_AR4_NO;
    public string ITEM_AR4_DATE;
    public string ITEM_COMMISSION_RATE;
    public string ITEM_DIVISION;
    public string ITEM_RANGE;
    public string ITEM_REMARKS;
    public string ITEM_IECCODE;
    public string ITEM_EXPORTER_NAME;
    public string ITEM_EXPORTER_NAME_THIRD;
    public string BR_SLNO;
    public string ITEM_ADDRESS1;
    public string ITEM_ADDRESS2;
    public string ITEM_ADDRESS3;
    public string ITEM_ADDRESS4;
    public string ITEM_ADDRESS5;
    public string ITEM_STR_CODE;
    public string REWARD_POINTS;


    public string MANUFACTURER_PRODUCER;
    public string M_P_GROWER_CODE;
    public string M_P_GROWER_ADD1;
    public string M_P_GROWER_ADD2;
    public string M_P_GROWER_CITY;
    public string M_P_GROWER_COUNTRY_SUBDIV;
    public string M_P_GROWER_PIN;
    public string M_P_GROWER_COUNTRY;
    public string SOURCE_STATE;
    public string TRANSIT_COUNTRY;
    public string ACCESSORY_STATUS;
    public string HAWB_NO;
    public string TOTAL_PKGS;
    public string ENDUSE_ITEM;
    public string IGST_PAYMENT;
    public string TAXABLE_VALUE;
    public string IGST_AMT;
    public string RODTEP;
 

    #endregion

    #region Drawback_Details

    public string DRAWBACK_ID;
    //public string JOBNO;
    //public string INVOICE_SLNO;
    //public string ITEM_SLNO;
    public string SCHEME_CODE;
    public string DRAWBACK_SLNO;
    public string DRAWBACK_QTY;
    public string DRAWBACK_UNIT;
    public string DRAWBACK_NOOFUNITS;
    public string DRAWBACK_RATE;
    public string DRAWBACK_CAPS;
    public string DRAWBACK_DESC;

    #endregion

    #region Job Work

    public string JOBBING_ID;
    //JOBNO
    //INVOICE_SLNO
    //ITEM_SLNO
    //SCHEME_CODE
    public string NOTIFICATION_NO;
    public string BE_NO;
    public string BE_DATE;
    public string BE_INV_SLNO;
    public string BE_INV_NO;
    public string BE_ITEM_NO;
    public string BE_PORT_CODE;
    public string QTY;
    public string UNIT;

    #endregion

    #region License Details

    public string LICENSE_ID;
    //public string SCHEME_CODE;
    public string SCHEME;
    public string LICENSE_R_SL_NO;
    public string LICENSE_NO;
    public string LICENSE_DATE;

    public string LICENSE_IMP_EXP_ID;
    public string LICENSE_E_SL_NO;
    public string LICENSE_EXP_QTY;
    public string LICENSE_EXP_UNIT;
    public string LICENSE_IMP_ITEM_SL_NO;
    public string LICENSE_IMP_DESC;
    public string LICENSE_IMP_QTY;
    public string LICENSE_IMP_UNIT;
    public string LICENSE_IMP_TYPE;

    #endregion

    #region ANNEXURE C1 DETAILS

    public string ANNEX_ID;
    //public string ANNEX_JOBNO;
    public string ANNEX_EXPORTERNAME;
    public string ANNEX_IECCODE;
    public string ANNEX_BR_SLNO;
    public string ANNEX_EXAM_DATE;
    public string ANNEX_EXAM_OFFICER;
    public string ANNEX_EXAM_DESIGN;
    public string ANNEX_SUPER_NAME;
    public string ANNEX_SUPER_DESIGN;
    public string ANNEX_COMMISSION_RATE;
    public string ANNEX_DIVISION;
    public string ANNEX_RANGE;
    public string ANNEX_VERIFIED_EXAM_OFFICER;
    public string ANNEX_SAMPLE_DRAWN;
    public string ANNEX_SEAL_NO;

    #endregion

    #region Cess Details

    public string CESS_ID;
    public string CESS_SLNO;
    public string CESS_VALUE;
    public string CESS_UNIT;
    public string CESS_FLAG;
    public string CESS_RATE;
    public string CESS_ITEM_QTY;
    public string CESS_ITEM_QTY_CODE;
    public string CESS_TARIFF_VALUE;
    public string CESS_TARIFF_UNIT;

    #endregion

    #region Single_Window Public_Attributes

    public string INFO_TYPE;
    public string INFO_QUALIFIER;
    public string INFO_CODE;
    public string INFO_TEXT;
    public string INFO_MSR;
    public string INFO_UQC;

    public string INFO_SERIAL_NO;
    public string CONSTITUENT_SERIAL_NO;
    public string PRODUCTION_SERIAL_NO;
    public string CONTROL_SERIAL_NO;
    public string STMT_SERIAL_NO;
    public string SUP_DOC_SERIAL_NO;

    public string CONSTITUENT_SRNO;
    public string CONSTITUENT_ELEMENT_NAME;

    public string CONSTITUENT_ELEMENT_CODE;
    public string CONSTITUENT_PERCENTAGE;
    public string CONSTITUENT_YIELD_PERCENTAGE;
    public string ACTIVE_INGREDIENT;
    public string PRODUCTION_BATCH_IDENTIFIER;
    public string PRODUCTION_BATCH_QUANTITY;
    public string UNIT_QTY_CODE;
    public string DATE_OF_MANUFACTURING;
    public string DATE_OF_EXPIRY;
    public string BEST_BEFORE;
    public string CONTROL_TYPE_CODE;
    public string CONTROL_LOCATION;    
    public string CONTROL_START_DATE;
    public string CONTROL_END_DATE;
    public string CONTROL_RESULT_CODE;
    public string CONTROL_RESULT_TEXT;

    public string STMT_DECLARATION_TYPE;
    public string STMT_DECLARATION_NUMBER;
    public string STMT_DECLARATION_DATE;
    public string STMT_TYPE;
    public string STMT_CODE;
    public string STMT_TEXT;
       
    public string UNIQUE_DOC_NUMBER;
    public string DOC_TYPE_CODE;
    public string DOC_ISSUING_PARTY_CODE;
    public string DOC_ISSUING_PARTY_NAME_ADD1;
    public string DOC_ISSUING_PARTY_NAME_ADD2;
    public string DOC_ISSUING_PARTY_CITY;
    public string DOC_ISSUING_PARTY_PIN;
    public string DOC_REF_NUMBER;
    public string PLACE_OF_ISSUE;
    public string DOC_ISSUE_DATE;
    public string DOC_EXPIRY_DATE;
    public string BENEFICIARY_PARTY_CODE;
    public string BENEFICIARY_PARTY_ADDRESS1;
    public string BENEFICIARY_PARTY_ADDRESS2;
    public string BENEFICIARY_PARTY_CITY;
    public string BENEFICIARY_PARTY_PIN;
    public string FILE_TYPE;
    public string DOC_ISSUING_PARTY_NAME;
    public string BENEFICIARY_PARTY_NAME;
      
    #endregion       

    #region ReExport Attributes

    public string SLNO;
    public string BE_SITE;
    public string BE_INVOICE_NO;
    public string BE_INVOICE_ITEM_NO;
    public string MANUAL_BE_Y_N;
    public string BE_QTY_UTILISED;
    public string BE_ITEM_DESC;
    public string BE_QTY;
    public string BE_UQC;
    public string BE_ASS_VALUE;
    public string BE_DUTY_PAID;
    public string BE_DUTY_PAYMENT_DATE;
    public string BE_OTH_IDENTIFIABLE_PARAMETER;
    public string BE_ASS_VALUE_CLAIM;
    public string BE_ITEM_USED_Y_N;
    public string COMMISIONER_PERMISSION_Y_N;
    public string INPUT_CREDIT_Y_N;
    public string PERSONAL_USED_Y_N;
    public string MODVAT_AVAILED_Y_N;
    public string MODVAT_REPAID_Y_N;
 
    #endregion




    // ============================================================================
    // New DSC - Signing (added). Everything in this region is additive: it does not
    // modify Json_generation, btnJson_Click, ImagebtnJsonfile_Click, or
    // JSON_IEC_GATE_UPLOAD below, all of which continue to work exactly as before,
    // whether triggered by this new section or the existing "Select a Json" flow.
    // ============================================================================

    private const string Dsc_DefaultAgentBaseUrl = "http://127.0.0.1:9095";
    private const string Dsc_DefaultInstallUrl = "https://dscapp.eroyalimpex.co.in/Icegate.Agent.UI.application";
    // Must exactly match Api:JwtSecret in Icegate.Agent's own appsettings.json -- these
    // two are kept in sync manually, same as in SignFiles.aspx, which mints tokens the
    // same way for the same Agent.
    private const string Dsc_DefaultJwtSecret = "E0g6ya670OG-BEf26gt-vz3XHpUQnfsTCRMmDO6mP6QO48c2C-FHWEl8t31nZcmJ";
    private const string Dsc_DefaultJwtIssuer = "eroyalimpex-erp";
    private const string Dsc_DefaultJwtAudience = "icegate-agent";
    private const int Dsc_DefaultJwtValidityMinutes = 15;

    protected string Dsc_AgentBaseUrl;
    protected string Dsc_InstallUrl;
    protected string Dsc_BearerToken;

    /// <summary>
    /// Mints the short-lived bearer token the new "New DSC - Signing" section's
    /// JavaScript sends to the local Agent. Reads the same Web.config appSettings keys
    /// SignFiles.aspx already uses (IcegateAgentBaseUrl, IcegateJwtSecret, etc.), so a
    /// single Web.config change (if ever needed) applies to both pages consistently --
    /// falls back to the same hardcoded defaults if those keys aren't present.
    /// </summary>
    private void Dsc_InitializeSigning()
    {
        Dsc_AgentBaseUrl = ConfigurationManager.AppSettings["IcegateAgentBaseUrl"];
        if (string.IsNullOrEmpty(Dsc_AgentBaseUrl))
        {
            Dsc_AgentBaseUrl = Dsc_DefaultAgentBaseUrl;
        }

        Dsc_InstallUrl = ConfigurationManager.AppSettings["IcegateInstallUrl"];
        if (string.IsNullOrEmpty(Dsc_InstallUrl))
        {
            Dsc_InstallUrl = Dsc_DefaultInstallUrl;
        }

        string secret = ConfigurationManager.AppSettings["IcegateJwtSecret"];
        if (string.IsNullOrEmpty(secret))
        {
            secret = Dsc_DefaultJwtSecret;
        }

        string issuer = ConfigurationManager.AppSettings["IcegateJwtIssuer"];
        if (string.IsNullOrEmpty(issuer))
        {
            issuer = Dsc_DefaultJwtIssuer;
        }

        string audience = ConfigurationManager.AppSettings["IcegateJwtAudience"];
        if (string.IsNullOrEmpty(audience))
        {
            audience = Dsc_DefaultJwtAudience;
        }

        int validityMinutes = Dsc_DefaultJwtValidityMinutes;
        string validityRaw = ConfigurationManager.AppSettings["IcegateJwtValidityMinutes"];
        int parsedValidity;
        if (!string.IsNullOrEmpty(validityRaw) && int.TryParse(validityRaw, out parsedValidity) && parsedValidity > 0)
        {
            validityMinutes = parsedValidity;
        }

        Dsc_BearerToken = Dsc_GenerateJwt(secret, issuer, audience, TimeSpan.FromMinutes(validityMinutes));
    }

    // Hand-rolled HS256 JWT -- same algorithm already independently verified via a
    // Python round-trip when this was first built for SignFiles.aspx (base64url
    // header/payload, HMACSHA256 signature over "header.payload"). No new NuGet
    // dependency introduced for this one page.
    private static string Dsc_GenerateJwt(string secret, string issuer, string audience, TimeSpan validFor)
    {
        string header = "{\"alg\":\"HS256\",\"typ\":\"JWT\"}";

        long exp = Dsc_ToUnixTimeSeconds(DateTime.UtcNow.Add(validFor));
        string payload = string.Format(
            "{{\"iss\":\"{0}\",\"aud\":\"{1}\",\"exp\":{2}}}",
            Dsc_EscapeJsonString(issuer), Dsc_EscapeJsonString(audience), exp);

        string headerEncoded = Dsc_Base64UrlEncode(Encoding.UTF8.GetBytes(header));
        string payloadEncoded = Dsc_Base64UrlEncode(Encoding.UTF8.GetBytes(payload));
        string signingInput = headerEncoded + "." + payloadEncoded;

        byte[] signatureBytes;
        using (System.Security.Cryptography.HMACSHA256 hmac = new System.Security.Cryptography.HMACSHA256(Encoding.UTF8.GetBytes(secret)))
        {
            signatureBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(signingInput));
        }
        string signatureEncoded = Dsc_Base64UrlEncode(signatureBytes);

        return signingInput + "." + signatureEncoded;
    }

    private static string Dsc_Base64UrlEncode(byte[] input)
    {
        string base64 = Convert.ToBase64String(input);
        return base64.Replace('+', '-').Replace('/', '_').TrimEnd('=');
    }

    private static string Dsc_EscapeJsonString(string s)
    {
        return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }

    private static long Dsc_ToUnixTimeSeconds(DateTime utcDateTime)
    {
        return (long)(utcDateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
    }

    /// <summary>
    /// Serves the unsigned JSON's raw content for the new section's JavaScript to fetch
    /// and hand to the local Agent for signing. Uses the exact same folder/filename
    /// logic Json_generation() already uses (see btnJson_Click above) -- reads whatever
    /// "Generate Json" most recently produced for this job, rather than duplicating or
    /// guessing at that logic separately. Exits via Response.End() when the query
    /// parameter is present; a normal page request (parameter absent) falls through
    /// untouched.
    /// </summary>
    private void Dsc_HandleUnsignedJsonRequest()
    {
        if (Request.QueryString["DscGetUnsignedJson"] != "1")
        {
            return;
        }

        try
        {
            string jobNo = Request.QueryString["Jobno"];
            if (string.IsNullOrEmpty(jobNo))
            {
                Response.StatusCode = 400;
                Response.Write("Job number is required.");
                Response.End();
                return;
            }

            string jsonFolder = Server.MapPath("~/Submission/" + COMPANY_ID + "/" + currentbranch + "/" + currentuser + "/json/");
            string fileName = "BE" + jobNo + DateTime.Now.Year.ToString() + ".json";
            string fullPath = Path.Combine(jsonFolder, fileName);

            if (!File.Exists(fullPath))
            {
                Response.StatusCode = 404;
                Response.Write("Unsigned JSON not found. Please click 'Generate Json' first.");
                Response.End();
                return;
            }

            Response.ContentType = "application/json";
            Response.Write(File.ReadAllText(fullPath));
            Response.End();
        }
        catch (System.Threading.ThreadAbortException)
        {
            // Expected: Response.End() above triggers this internally; ASP.NET handles it
            // as part of that call's normal contract, not a real error to report.
            throw;
        }
        catch (Exception ex)
        {
            Response.StatusCode = 500;
            Response.Write("Error: " + ex.Message);
            Response.End();
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            aps.checkSession();
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();
            ddlJobNo.Focus();
            hdn_source.Value = "";
            // commented for areawise implementation on 05-mar-2020

            SELECT_BRANCH = Connection.Get_Company_Type();
            hd_branch.Value = SELECT_BRANCH;
            hdn_CompanyID.Value = Session["COMPANY_ID"].ToString();

            if (Connection.Exp_Multiple_CHA_IcegateID_enable(COMPANY_ID) == "Y")
            {
                if (!string.IsNullOrEmpty(Session["Multiple_ICE_ID"] as string))
                {
                    txt_icegate_Id.Text = Session["Multiple_ICE_ID"].ToString();
                }
            }

            Dsc_HandleUnsignedJsonRequest();

            Dsc_InitializeSigning();

            hdn_ICEGATE_ID_List.Value = Connection.Get_User_ICEGATE_ID_DropdownList("Load_EXP_ICEGATE_ID_dropdown");

            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/");


            /*
            if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "747")
            {
                if (Connection.Get_Company_Type() != "")
                {
                    targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "EXP_Job_history/");
                }
                else
                {
                    targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "EXP_Job_history/");
                }
            }
            */

            string SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
            if (SELECT_TYPE == "Branchwise Job")
                targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "EXP_Job_history/");
            else if (SELECT_TYPE == "Areawise Job")
                targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["GroupName"].ToString() + "/" + "EXP_Job_history/");

            else
            {
                targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "EXP_Job_history/");
            }

            
            COMPANY_ID = Session["COMPANY_ID"].ToString();
            //CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();//--02-11-2021
            CHA_NO = Connection.Get_EXP_CHA_NO();


            ICEGATE_EMAIL_ID = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
            ICEGATE_EMAIL_PWD = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();

            hdlock_or_Not.Value = "False";

            if (!IsPostBack)
            {
                if (Connection.Company_License().ToLower() == "eri00001" || Connection.Company_License().ToLower() == "eri00010")
                {
                    btn_Auto_Spl_Char.Visible = false;
                }

                if (Directory.Exists(errorFolder) == false)
                {
                    Directory.CreateDirectory(errorFolder);
                }
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 13;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                if (!string.IsNullOrEmpty(Request["Combine_jobs"]))
                {
                    Session["Exp_Combine_Jobs"] = Request["Combine_jobs"].ToString();
                }
                else
                {
                    Session["Exp_Combine_Jobs"] = "";
                }


                ddlJobNo.Attributes.Add("onchange", "javascript:CallServerside_Importer('" + ddlJobNo.ClientID + "', '" + txtCustomHouse.ClientID + "')");
                if (!string.IsNullOrEmpty(Request["jobno"]))
                {
                    if (!string.IsNullOrEmpty(Request["SUB"]))
                    {
                        FlatFile.JOBNo = "";
                        FlatFile.Ename = "select_jobno";
                        FlatFile.Workingperiod = SELECT_BRANCH;
                        ddlJobNo.DataSource = FlatFile.Retrieve_Export_All_Details();
                        ddlJobNo.DataValueField = "JOBNO";
                        ddlJobNo.DataTextField = "JOBNO_PS";
                        ddlJobNo.DataBind();
                        ddlJobNo.Items.Remove("0");
                        ddlJobNo.Items.Insert(0, "Select");

                        ddlJobNo.SelectedValue = Request["jobno"].ToString();
                        btnSearch_Click(sender, e);
                    }
                    else
                    {
                        /*hide for Dashboard changes - sidebar & innerbox_Main_Top_User controls removed on 24-08-2026*/
                        //System.Web.UI.HtmlControls.HtmlGenericControl currdiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("sidebar");
                        //currdiv.Style.Add("display", "none");

                        //System.Web.UI.HtmlControls.HtmlGenericControl currdiv1 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("innerbox_Main_Top_User");
                        //currdiv1.Style.Add("display", "none");

                        System.Web.UI.HtmlControls.HtmlGenericControl currdiv2 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("maincontent");
                        currdiv2.Style.Add("margin", "-16px 2px 0 0");
                        currdiv2.Style.Add("padding", "2px 0 0");

                        ddlJobNo.Items.Clear();
                        ddlJobNo.Items.Insert(0, new ListItem(Request["jobnops"].ToString().TrimEnd(), Request["jobno"].ToString().TrimEnd()));
                        ddlJobNo.SelectedIndex = 0;

                        hdn_Jobno.Value = Request["jobno"].ToString().TrimEnd();
                    }
                }
                else
                {
                    FlatFile.JOBNo = "";
                    FlatFile.TRANSPORT_MODE = "";
                    FlatFile.Ename = "select_jobno";
                    FlatFile.Workingperiod = SELECT_BRANCH;
                    ddlJobNo.DataSource = FlatFile.Retrieve_Export_All_Details();
                    ddlJobNo.DataValueField = "JOBNO";
                    ddlJobNo.DataTextField = "JOBNO_PS";
                    ddlJobNo.DataBind();
                    ddlJobNo.Items.Remove("0");
                    ddlJobNo.Items.Insert(0, "Select");
                }
                txtCustomHouse.Attributes.Add("readonly", "readonly");
                txtExporterName.Attributes.Add("readonly", "readonly");
                txtScheme.Attributes.Add("readonly", "readonly");
                txtConsignee.Attributes.Add("readonly", "readonly");
                txtNoofItems.Attributes.Add("readonly", "readonly");
                txtNoofInvoices.Attributes.Add("readonly", "readonly");

                string theme = (Session["Theme"] != null && Session["Theme"].ToString() != "")
                ? Session["Theme"].ToString().ToLower()
               : "orange";

                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "setTheme",
                "var PAGE_THEME = '" + theme + "';",
                  true);

                Check_Duplicate_Invoice_OnLoad();


                string jobNo = ddlJobNo.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(jobNo))
                {
                    LoadExistingDummyJobNo(jobNo);
                }



            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Joblock()
    {
        try
        {
            SB_Details();
            DataSet ds2 = new DataSet();
            Export.JOBID = "";
            //Export.JOBNO = ddlJobNo.SelectedItem.Text;
            Export.JOBNO = ddlJobNo.SelectedValue.ToString();
            Export.EXPORTER_NAME = "";
            Export.TRANSPORT_MODE = "";
            Export.CUSTOMS_HOUSE = "";
            Export.Ename = "select_Id_Submission";
            Export.WORKING_PERIOD = SELECT_BRANCH;
            ds2 = Export.RetrieveAll_General_Details();

            JOB_LOCK = ds2.Tables[0].Rows[0]["JOB_STATUS"].ToString();
            JOB_RELEASE = ds2.Tables[0].Rows[0]["JOB_RELEASE"].ToString();
            JOB_USER = ds2.Tables[0].Rows[0]["USERID"].ToString();

            Session.Remove("JOB_LOCK");
            Session.Remove("JOB_RELEASE");
            Session.Remove("JOB_USER");

            Session["JOB_LOCK"] = JOB_LOCK;
            Session["JOB_RELEASE"] = JOB_RELEASE;
            Session["JOB_USER"] = JOB_USER;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    private void Flat_File_Generation()
    {
        //imgbtn.Visible = true; ----- 07-Oct-2016

        imgbtnFlatFile.Enabled = true;
       // btnSubmission.Enabled = true;
        btnsend_Queue.Enabled = true;

        hdlock_or_Not.Value = "True";

        try
        {
            IS_Imgbtn = "";
            //SB_Details();
            imgbtnFlatFile.Visible = false;
            //btnSubmission.Visible = false;
            btnsend_Queue.Visible = false;

            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                Flat_File("","");
                imgbtnFlatFile.Visible = true;
               // btnSubmission.Visible = true;
                btnsend_Queue.Visible = true;
                //btn_Outlookmail_Submission.Visible = true;
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                Flat_File("", "");
                imgbtnFlatFile.Visible = true;
                //btnSubmission.Visible = true;
                btnsend_Queue.Visible = true;
                //btn_Outlookmail_Submission.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void Page_Rights(int i)
    {
        try
        {
            user_Create.RetrieveAll_User_Screen_Rights_Details(i);
            PAGE_WRITE = user_Create.PAGE_WRITE;
            PAGE_READ = user_Create.PAGE_READ;
            PAGE_MODIFY = user_Create.PAGE_MODIFY;
            PAGE_DELETE = user_Create.PAGE_DELETE;

            //---------------READ ONLY------------------//

            if (PAGE_READ == "False")
            {
                btnSearch.Enabled = false;
                //btnSubmission.Enabled = false;
                btnsend_Queue.Enabled = false;
                imgbtnFlatFile.Enabled = false;
                // btn_Outlookmail_Submission.Enabled = false;

                btnSearch.ToolTip = "You don't have permission to access";
                //btnSubmission.ToolTip = "You don't have permission to access";
                btnsend_Queue.ToolTip = "You don't have permission to access";
                imgbtnFlatFile.ToolTip = "You don't have permission to access";
            }
            else
            {
                btnSearch.Enabled = true;
                //btnSubmission.Enabled = true;
                btnsend_Queue.Enabled = true;
                imgbtnFlatFile.Enabled = true;
                // btn_Outlookmail_Submission.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Export_CheckList CHKLIST = new Export_CheckList();
            CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
            CHKLIST.Ename = "select_jobno_CheckList";

            CHKLIST.Workingperiod = SELECT_BRANCH;
            DataSet ds = new DataSet();
            ds = CHKLIST.RetrieveAll_General_Details();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomHouse.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                txtExporterName.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                txtConsignee.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtScheme.Text = ds.Tables[1].Rows[0]["ITEM_SCHEME_CODE"].ToString();
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        txtNoofInvoices.Text = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() + " INVOICE";

                    }
                    else
                    {
                        txtNoofInvoices.Text = "";
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        txtNoofItems.Text = ds.Tables[3].Rows[0]["ITEM_SLNO"].ToString() + " ITEMS";

                    }
                    else
                    {
                        txtNoofItems.Text = "";
                    }
                }
                else
                {
                    txtScheme.Text = "";
                    txtNoofItems.Text = "";
                    txtNoofInvoices.Text = "";
                }

            }
            else
            {
                txtCustomHouse.Text = "";
                txtExporterName.Text = "";
                txtScheme.Text = "";
                txtConsignee.Text = "";
                txtNoofItems.Text = "";
                txtNoofInvoices.Text = "";

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }
    public void SB_Details()
    {
        try
        {
            if (!string.IsNullOrEmpty(Request["Combine_jobs"]))
            {
                FlatFile.JOBNo = Request["Combine_jobs"].ToString();
                FlatFile.TRANSPORT_MODE = "";
                FlatFile.Ename = "Exp_Combine_FlatFile";
                FlatFile.Workingperiod = SELECT_BRANCH;
                ds = FlatFile.Retrieve_Export_All_Details();
                is_Annexure_Mode = FlatFile.result;

                Session.Remove("ds");
                Session["ds"] = ds;
            }
            else
            {
                FlatFile.JOBNo = ddlJobNo.SelectedValue.ToString();
                FlatFile.TRANSPORT_MODE = "";
                FlatFile.Ename = "FlatFile";
                FlatFile.Workingperiod = SELECT_BRANCH;
                ds = FlatFile.Retrieve_Export_All_Details();
                is_Annexure_Mode = FlatFile.result;

                Session["ds"] = ds;
            }

			if (COMPANY_ID == "1307" || COMPANY_ID == "1713" || COMPANY_ID == "2099" || COMPANY_ID == "2145" || COMPANY_ID == "2318" || COMPANY_ID == "2394" || COMPANY_ID == "2478" || COMPANY_ID == "3122" || COMPANY_ID == "3194" || COMPANY_ID == "3384" || COMPANY_ID == "3387" || COMPANY_ID == "4047" || COMPANY_ID == "4082")            
            {
                if (ds.Tables[0].Rows[0]["CHA_NO"].ToString() != "")
                {
                    CHA_NO = ds.Tables[0].Rows[0]["CHA_NO"].ToString();
                    txt_icegate_Id.Text = ds.Tables[0].Rows[0]["ICE_ID"].ToString();
                }
            }


            if (is_Annexure_Mode == 1)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //JOBNO = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                    //--------------------------------------------------LOADING SB NO & SB DATE FROM SB ENTRY TABLE-------------------------//
                    string SB_dt = ds.Tables[0].Rows[0]["SB_DATE"].ToString();
                    if (SB_dt == "01/01/1900")
                    {
                        SB_dt = "";
                    }
                    SB_NO = ds.Tables[0].Rows[0]["SB_NO"].ToString();
                    SB_DATE = SB_dt;
                    //--------------------------------------------------LOADING SB NO & SB DATE FROM SB ENTRY TABLE-------------------------//

                    JOBDATE = ds.Tables[0].Rows[0]["JOBDATE"].ToString().Replace("19000101", "");
                    DDMMYY_JOBDATE = ds.Tables[0].Rows[0]["JOBDT_DDMMYY"].ToString().Replace("010100", "");
                    TRANSPORT_MODE = dt.Trim(ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString());
                    CUSTOMS_HOUSE = dt.Trim(ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString());
                    SB_TYPE = dt.Trim(ds.Tables[0].Rows[0]["SB_TYPE"].ToString());

                    //EXPORTER_NAME = dt.Trim_Single_Quote(ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString());
                    EXPORTER_NAME = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();

                    BRANCH_NO = dt.Trim(ds.Tables[0].Rows[0]["BRANCH_NO"].ToString());
                    IEC_NO = dt.Trim(ds.Tables[0].Rows[0]["IEC_NO"].ToString());
                    ADDRESS1 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS1"].ToString());
                    ADDRESS2 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS2"].ToString());
                    ADDRESS3 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS3"].ToString());
                    ADDRESS4 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS4"].ToString());
                    ADDRESS5 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS5"].ToString());

                    TYPE_OF_EXPORTER = dt.Trim(ds.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString());

                    ADCODE = dt.Trim(ds.Tables[0].Rows[0]["ADCODE"].ToString());

                    if (ADCODE != "")
                    {
                        if (dt.Trim(ds.Tables[0].Rows[0]["SB_TYPE"].ToString()) == "SEZ")
                        {
                            if (dt.Trim(ds.Tables[0].Rows[0]["ADCODE"].ToString()) != "NFEI")
                            {
                                ADCODE = ADCODE.Substring(0, 7);
                            }
                        }
                        else
                        {
                            ADCODE = ADCODE.Substring(0, 7);
                        }
                    }

                    BANK_ACCOUNT = dt.Trim(ds.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString());
                    DRAWBACK_ACCOUNT = dt.Trim(ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString());
                    //CONSIGNEE_NAME = dt.Trim_Single_Quote(ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString());



                    CONSIGNEE_NAME = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                    CONSIGNEE_ADD1 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString());
                    CONSIGNEE_ADD2 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString());
                    CONSIGNEE_ADD3 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString());
                    CONSIGNEE_ADD4 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString());


                    if (Connection.COMPANYID() != "148") // Condition added by pandiyan suggest by bala & praveen on 19-08-2026
                    {

                        string Consignee_All = CONSIGNEE_ADD1 + CONSIGNEE_ADD2 + CONSIGNEE_ADD3 + CONSIGNEE_ADD4; // Split into chunks of 35 characters 
                        string[] consigneeParts = new string[4];
                        for (int i = 0; i < consigneeParts.Length && Consignee_All.Length > 0; i++)
                        {
                            int length = Math.Min(35, Consignee_All.Length);
                            consigneeParts[i] = Consignee_All.Substring(0, length);
                            Consignee_All = Consignee_All.Remove(0, length);
                        } // Assign to variables 
                        CONSIGNEE_ADD1 = consigneeParts[0];
                        CONSIGNEE_ADD2 = consigneeParts[1];
                        CONSIGNEE_ADD3 = consigneeParts[2];
                        CONSIGNEE_ADD4 = consigneeParts[3];

                    }

                    //GREEN_CHANNEL_DESC = ds.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString();

                    CONSIGNEE_ADD5 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString());

                    //KACHHA_BE_DESC = ds.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString();

                    COUNTRY_DISCHARGE = dt.Trim(ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString());

                    //SECTION48_DESC= ds.Tables[0].Rows[0]["SECTION48_DESC"].ToString();

                    PORT_DISCHARGE = dt.Trim(ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString());

                    COUNTRY_FINAL_DEST = dt.Trim(ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString());
                    PORT_FINAL_DEST = dt.Trim(ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString());
                    STATE_OF_EXPORT = dt.Trim(ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString());
                    NFEI = dt.Trim(ds.Tables[0].Rows[0]["NFEI"].ToString());
                    NFEI_TYPE = dt.Trim(dt.Split("-", ds.Tables[0].Rows[0]["NFEI_TYPE"].ToString()));
                    RBI_WAIVER_NO = dt.Trim(ds.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString());
                    RBI_WAIVER_DATE = dt.Trim(ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString().Replace("19000101", ""));

                    MARKS_NO = dt.Trim(ds.Tables[0].Rows[0]["MARKS_NO"].ToString().Replace("\r\n", " "));

                    JOB_STATUS = ds.Tables[0].Rows[0]["JOB_STATUS"].ToString();
                    Session.Remove("JOB_LOCK");
                    Session["JOB_LOCK"] = JOB_STATUS;

                    GROSS_WEIGHT = dt.Trim(ds.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString());
                    UNIT_CODE = dt.Trim(ds.Tables[0].Rows[0]["UNIT_CODE"].ToString());
                    NET_WEIGHT = dt.Trim(ds.Tables[0].Rows[0]["NET_WEIGHT"].ToString());
                    NATURE_OF_CARGO = dt.Trim(ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString());
                    MARKS_NOS = dt.Trim(ds.Tables[0].Rows[0]["MARKS_NOS"].ToString());
                    TOTAL_PACKAGES = dt.Trim(ds.Tables[0].Rows[0]["TOTAL_PACKAGES"].ToString());
                    ROTATION_NO = dt.Trim(ds.Tables[0].Rows[0]["ROTATION_NO"].ToString());
                    ROTATION_DATE = dt.Trim(ds.Tables[0].Rows[0]["ROTATION_DATE"].ToString().Replace("19000101", ""));

                    GSTN_TYPE = dt.Trim(ds.Tables[0].Rows[0]["GSTN_TYPE"].ToString());
                    GSTN_ID = dt.Trim(ds.Tables[0].Rows[0]["GSTN_ID"].ToString());
                    PORT_OF_LOADING = dt.Trim(ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString());
                    IMP_EXP_TYPE = dt.Trim(ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString());


                    if (TRANSPORT_MODE == "Sea")
                    {
                        LOOSE_PACKETS = dt.Trim(ds.Tables[0].Rows[0]["LOOSE_PACKETS"].ToString());
                        NO_CONTAINERS = dt.Trim(ds.Tables[0].Rows[0]["NO_CONTAINERS"].ToString());

                        ANNEX_SEA_FAC_STUFFED = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_SEA_FAC_STUFFED"].ToString());
                        ANNEX_SEA_SAMPLE_ACCOM = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_SEA_SAMPLE_ACCOM"].ToString());
                        ANNEX_SEA_SEAL_TYPE = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString());

                        if (ANNEX_SEA_SEAL_TYPE == "Agency")
                        {
                            ANNEX_SEA_SEAL_TYPE = "A";
                        }
                        else if (ANNEX_SEA_SEAL_TYPE == "Self")
                        {
                            ANNEX_SEA_SEAL_TYPE = "S";
                        }
                        else if (ANNEX_SEA_SEAL_TYPE == "Warehouse")
                        {
                            ANNEX_SEA_SEAL_TYPE = "W";
                        }

                        if (NO_CONTAINERS == "")
                        {
                            NO_CONTAINERS = "0";
                        }

                    }
                    else if (TRANSPORT_MODE == "Land")
                    {
                        LOOSE_PACKETS = dt.Trim(ds.Tables[0].Rows[0]["LOOSE_PACKETS"].ToString());
                        NO_CONTAINERS = dt.Trim(ds.Tables[0].Rows[0]["NO_CONTAINERS"].ToString());

                        ANNEX_SEA_FAC_STUFFED = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_SEA_FAC_STUFFED"].ToString());
                        ANNEX_SEA_SAMPLE_ACCOM = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_SEA_SAMPLE_ACCOM"].ToString());
                        ANNEX_SEA_SEAL_TYPE = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString());

                        if (ANNEX_SEA_SEAL_TYPE == "Agency")
                        {
                            ANNEX_SEA_SEAL_TYPE = "A";
                        }
                        else if (ANNEX_SEA_SEAL_TYPE == "Self")
                        {
                            ANNEX_SEA_SEAL_TYPE = "S";
                        }
                        else if (ANNEX_SEA_SEAL_TYPE == "Warehouse")
                        {
                            ANNEX_SEA_SEAL_TYPE = "W";
                        }
                        if (NO_CONTAINERS == "")
                        {
                            NO_CONTAINERS = "0";
                        }

                    }
                    else
                    {
                        LOOSE_PACKETS = "";
                        NO_CONTAINERS = "";
                        ANNEX_SEA_FAC_STUFFED = "";
                        ANNEX_SEA_SAMPLE_ACCOM = "";
                        ANNEX_SEA_SEAL_TYPE = "";

                    }


                    if (TRANSPORT_MODE == "Air")
                    {
                        ANNEX_AIR_MAWB_NO = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString());
                        ANNEX_AIR_HAWB_NO = dt.Trim(ds.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString());
                    }
                    else
                    {
                        ANNEX_AIR_MAWB_NO = "";
                        ANNEX_AIR_HAWB_NO = "";
                    }
                    Get_Admin_Master_Codes();
                }
            }

            else if (is_Annexure_Mode == 2)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //JOBNO = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                    //--------------------------------------------------LOADING SB NO & SB DATE FROM SB ENTRY TABLE-------------------------//
                    string SB_dt = ds.Tables[0].Rows[0]["SB_DATE"].ToString();
                    if (SB_dt == "01/01/1900" || SB_dt == "19000101")
                    {
                        SB_dt = "";
                    }
                    SB_NO = ds.Tables[0].Rows[0]["SB_NO"].ToString();
                    SB_DATE = SB_dt;
                    //--------------------------------------------------LOADING SB NO & SB DATE FROM SB ENTRY TABLE-------------------------//
                    JOBDATE = dt.Trim(ds.Tables[0].Rows[0]["JOBDATE"].ToString().Replace("19000101", ""));
                    DDMMYY_JOBDATE = dt.Trim(ds.Tables[0].Rows[0]["JOBDT_DDMMYY"].ToString().Replace("010100", ""));

                    TRANSPORT_MODE = dt.Trim(ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString());

                    CUSTOMS_HOUSE = dt.Trim(ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString());

                    SB_TYPE = dt.Trim(ds.Tables[0].Rows[0]["SB_TYPE"].ToString());

                    //EXPORTER_NAME = dt.Trim(ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString());
                    EXPORTER_NAME = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();

                    BRANCH_NO = dt.Trim(ds.Tables[0].Rows[0]["BRANCH_NO"].ToString());
                    IEC_NO = dt.Trim(ds.Tables[0].Rows[0]["IEC_NO"].ToString());
                    ADDRESS1 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS1"].ToString());
                    ADDRESS2 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS2"].ToString());
                    ADDRESS3 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS3"].ToString());
                    ADDRESS4 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS4"].ToString());
                    ADDRESS5 = dt.Trim(ds.Tables[0].Rows[0]["ADDRESS5"].ToString());

                    TYPE_OF_EXPORTER = dt.Trim(ds.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString());

                    ADCODE = dt.Trim(ds.Tables[0].Rows[0]["ADCODE"].ToString());
                    if (ADCODE != "")
                    {
                        if (dt.Trim(ds.Tables[0].Rows[0]["SB_TYPE"].ToString()) == "SEZ")
                        {
                            if (dt.Trim(ds.Tables[0].Rows[0]["ADCODE"].ToString()) != "NFEI")
                            {
                                ADCODE = ADCODE.Substring(0, 7);
                            }
                        }
                        else
                        {
                            ADCODE = ADCODE.Substring(0, 7);
                        }
                    }

                    BANK_ACCOUNT = dt.Trim(ds.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString());
                    DRAWBACK_ACCOUNT = dt.Trim(ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString());
                    //CONSIGNEE_NAME = dt.Trim_Single_Quote(ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString());
                    CONSIGNEE_NAME = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();

                    CONSIGNEE_ADD1 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString());

                    CONSIGNEE_ADD2 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString());

                    //SECTION46_DESC = ds.Tables[0].Rows[0]["SECTION46_DESC"].ToString();

                    CONSIGNEE_ADD3 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString());

                    //FIRSTCHECK_DESC = ds.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString();

                    CONSIGNEE_ADD4 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString());

                    //GREEN_CHANNEL_DESC = ds.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString();

                    string Consignee_All = CONSIGNEE_ADD1 + CONSIGNEE_ADD2 + CONSIGNEE_ADD3 + CONSIGNEE_ADD4; // Split into chunks of 35 characters 
                    string[] consigneeParts = new string[4];
                    for (int i = 0; i < consigneeParts.Length && Consignee_All.Length > 0; i++)
                    {
                        int length = Math.Min(35, Consignee_All.Length);
                        consigneeParts[i] = Consignee_All.Substring(0, length);
                        Consignee_All = Consignee_All.Remove(0, length);
                    } // Assign to variables 
                    CONSIGNEE_ADD1 = consigneeParts[0];
                    CONSIGNEE_ADD2 = consigneeParts[1];
                    CONSIGNEE_ADD3 = consigneeParts[2];
                    CONSIGNEE_ADD4 = consigneeParts[3];

                    CONSIGNEE_ADD5 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString());

                    //KACHHA_BE_DESC = ds.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString();

                    COUNTRY_DISCHARGE = dt.Trim(ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString());

                    //SECTION48_DESC= ds.Tables[0].Rows[0]["SECTION48_DESC"].ToString();

                    PORT_DISCHARGE = dt.Trim(ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString());

                    COUNTRY_FINAL_DEST = dt.Trim(ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString());
                    PORT_FINAL_DEST = dt.Trim(ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString());
                    STATE_OF_EXPORT = dt.Trim(ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString());
                    NFEI = dt.Trim(ds.Tables[0].Rows[0]["NFEI"].ToString());
                    NFEI_TYPE = dt.Trim(dt.Split("-", ds.Tables[0].Rows[0]["NFEI_TYPE"].ToString()));

                    RBI_WAIVER_NO = dt.Trim(ds.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString());
                    RBI_WAIVER_DATE = dt.Trim(ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString().Replace("19000101", ""));
                    MARKS_NO = dt.Trim(ds.Tables[0].Rows[0]["MARKS_NO"].ToString().Replace("\r\n", " "));

                    GSTN_TYPE = dt.Trim(ds.Tables[0].Rows[0]["GSTN_TYPE"].ToString());
                    GSTN_ID = dt.Trim(ds.Tables[0].Rows[0]["GSTN_ID"].ToString());
                    PORT_OF_LOADING = dt.Trim(ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString());

                    JOB_STATUS = ds.Tables[0].Rows[0]["JOB_STATUS"].ToString();
                    Session.Remove("JOB_LOCK");
                    Session["JOB_LOCK"] = JOB_STATUS;

                    GROSS_WEIGHT = "";
                    UNIT_CODE = "";
                    NET_WEIGHT = "";
                    NATURE_OF_CARGO = "";
                    MARKS_NOS = "";
                    TOTAL_PACKAGES = "";
                    ROTATION_NO = "";
                    ROTATION_DATE = "";
                    LOOSE_PACKETS = "";
                    NO_CONTAINERS = "";
                    ANNEX_SEA_FAC_STUFFED = "";
                    ANNEX_SEA_SAMPLE_ACCOM = "";
                    ANNEX_AIR_MAWB_NO = "";
                    ANNEX_AIR_HAWB_NO = "";
                    Get_Admin_Master_Codes();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        

    }
    public void Get_Admin_Master_Codes()
    {
        try
        {
            if (NATURE_OF_CARGO != "")
            {
                sealtype_txt = "";
            }

            if (!string.IsNullOrEmpty(IMP_EXP_TYPE))
            {
                if (IMP_EXP_TYPE == "GOVERNMENT" || IMP_EXP_TYPE == "GOVERNMENT DEPARTMENTS")
                {
                    EXPORTER_CLASS = "G";
                }
                else if (IMP_EXP_TYPE == "GOVERNMENT UNDERTAKINGS")
                {
                    EXPORTER_CLASS = "U";
                }
                else if (IMP_EXP_TYPE == "OTHERS")
                {
                    EXPORTER_CLASS = "O";
                }
                else if (IMP_EXP_TYPE == "PRIVATE")
                {
                    EXPORTER_CLASS = "P";
                }
                else if (IMP_EXP_TYPE == "HAND CARRIAGE")
                {
                    EXPORTER_CLASS = "H";
                }
                else
                {
                    EXPORTER_CLASS = IMP_EXP_TYPE;
                }
            }
            else
            {
                Imp_Exp.Eimp_exp_id = "";
                Imp_Exp.Eimp_exp_name = EXPORTER_NAME;
                Imp_Exp.Eimp_exp_iecno = IEC_NO;
                Imp_Exp.Eimp_exp_brslno = BRANCH_NO;
                Imp_Exp.Ename = "Export_FlatFile_select_Type";
                Imp_Exp.EWorking_Period = "";

                Imp_Exp.startRowIndex = "0";
                Imp_Exp.maximumRows = "0";
                DataSet dsImp_Exp = new DataSet();

                dsImp_Exp = Imp_Exp.RetrieveAll_Imp_exp_master();
                if (dsImp_Exp.Tables[0].Rows.Count > 0)
                {
                    EXPORTER_CLASS = dsImp_Exp.Tables[0].Rows[0]["TYPE"].ToString();
                    if (EXPORTER_CLASS == "O" || EXPORTER_CLASS == "")
                    {
                        EXPORTER_CLASS = "P";
                    }
                    else if (EXPORTER_CLASS == "G")
                    {
                        EXPORTER_CLASS = "G";
                    }
                    else if (EXPORTER_CLASS == "H")
                    {
                        EXPORTER_CLASS = "H";
                    }
                }
            }

            Date_Time split = new Date_Time();
            FlatFile.Ename = "IMPORT_SELECT";

            dss = FlatFile.Search_Admin_Master();
            DataView view1 = dss.Tables[0].DefaultView;
            view1.RowFilter = "STATE_NAME = '" + split.Split("-", STATE_OF_EXPORT) + "'";
            //DataTable table1 = view1.ToTable();
            DataSet dt_UserRights = new DataSet();
            dt_UserRights.Tables.Add(view1.ToTable());
            if (dt_UserRights.Tables[0].Rows.Count > 0)
            {
                STATE_OF_EXPORT = dt.Trim(dt_UserRights.Tables[0].Rows[0]["STATE_CODE"].ToString());
            }
            //CONSIGNEE COUNTRY CODE
            view1 = dss.Tables[1].DefaultView;
            view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", CONSIGNEE_ADD5) + "'";
            DataSet dt_2 = new DataSet();
            dt_2.Tables.Add(view1.ToTable());
            if (dt_2.Tables[0].Rows.Count > 0)
            {
                CONSIGNEE_ADD5 = dt.Trim(dt_2.Tables[0].Rows[0]["COUNTRY_CODE"].ToString());
            }

            view1 = dss.Tables[1].DefaultView;
            view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", COUNTRY_DISCHARGE) + "'";
            DataSet dt_1 = new DataSet();
            dt_1.Tables.Add(view1.ToTable());
            if (dt_1.Tables[0].Rows.Count > 0)
            {
                COUNTRY_DISCHARGE = dt.Trim(dt_1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString());
            }
            view1 = dss.Tables[1].DefaultView;

            view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", COUNTRY_FINAL_DEST) + "'";

            DataSet ds1 = new DataSet();
            ds1.Tables.Add(view1.ToTable());
            if (ds1.Tables[0].Rows.Count > 0)
            {
                COUNTRY_FINAL_DEST = dt.Trim(ds1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString());
            }
            if (PORT_DISCHARGE.Contains("-"))
            {
                PORT_DISCHARGE = split.Split_main("-", PORT_DISCHARGE);
            }
            if (PORT_FINAL_DEST.Contains("-"))
            {
                PORT_FINAL_DEST = split.Split_main("-", PORT_FINAL_DEST);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {

            if (COMPANY_ID == "1" || COMPANY_ID == "10")
            {
                if (!Check_Export_Invoice_Lock())
                    return;

            }

            Export_Default_Entry.Post_Data(ddlJobNo.SelectedValue.ToString(), "RODTEP");

            if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "1572")
            {
                Export_Default_Entry.CLIENT_BASED_DBK_DEFAULT_ENTRY(ddlJobNo.SelectedValue.ToString(), "DBK_Decl");
            }

            if (Rdhelp.SelectedValue.ToString() == "No")
            {
                Flatfile_gen();
                gv_Details.DataSource = null;
                gv_Details.DataBind();
                lbltablename.Text = string.Empty;
            }
            else
            {
                DataSet ds_A = new DataSet();

                EV.Jobno = ddlJobNo.SelectedValue.ToString();
                EV.Flag = "EXP_Flat_File_DETAILS";
                EV.Branch_Type = SELECT_BRANCH;
                ds_A = EV.EXP_Data_Select();

                if (ds_A.Tables[0].Rows.Count > 0)
                {
                    gv_Details.DataSource = ds_A.Tables[0];
                    gv_Details.DataBind();
                    gv_Details.Attributes.Add("Width", "100%");

                    lbltablename.Text = "* Check Ur Error Page Details";
                    laod_Flat_File_Show();
                }
                else
                {
                    if (General_Details() == 1)
                    {
                        if (EXPORT_ANNEXURE_C_AIR() == 1)
                        {
                            if (EXPORT_ANNEXURE_C_SEA() == 1)
                            {
                                if (EXPORT_ANNEXURE_C_SEA_Container() == 1)
                                {

                                    if (Invoice_Details() == 1)
                                    {
                                        if (Invoice_Cur_Ex_Rate_Details() == 1)
                                        {
                                            if (Invoice_No() == 1)
                                            {

                                                if (AR4() == 1)
                                                {
                                                    if (Invoice_Item() == 1)
                                                    {
                                                        if (Item_Details() == 1)
                                                        {
                                                            if (Item_Special_Charaters() == 1)
                                                            {
                                                                if (Item_Cess_Details() == 1)
                                                                {
                                                                    if (Item_Lic() == 1)
                                                                    {
                                                                        if (Item_Annuxure_C1_Details() == 1)
                                                                        {
                                                                            if (Item_Dup_Check() == 1)
                                                                            {
                                                                                if (Item_Mandatory_Check() == 1)
                                                                                {
                                                                                    Flatfile_gen();
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }
    private int General_Details()
    {
        int G = 1;
        DataSet ds_1 = new DataSet();
        try
        {
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "EXP_GENERAL_DETAILS";
            EV.Branch_Type = SELECT_BRANCH;
            ds_1 = EV.EXP_Data_Select();

            if (ds_1.Tables[0].Rows.Count > 0)
            {
                DataSet ds_2 = new DataSet();
                String xmlData = ConvertDataTableToXML(ds_1.Tables[0]);
                EV.Xml_D = xmlData;
                ds_2 = EV.EXP_Admin_Select();

                if (ds_2.Tables[0].Rows.Count > 0)//G
                {
                    gv_Details.DataSource = ds_2.Tables[0];
                    gv_Details.DataBind();
                    gv_Details.Attributes.Add("Width", "200%");

                    lbltablename.Text = "* Check Ur General Details page";
                    laod_Flat_File_Show();
                    G = 0;
                }

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return G;
    }
    private int EXPORT_ANNEXURE_C_AIR()
    {
        int EAA = 1;
        DataSet ds_5 = new DataSet();
        try
        {
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "EXPORT_ANNEXURE_C_Air";
            EV.Branch_Type = SELECT_BRANCH;
            EV.Xml_D = "";
            ds_5 = EV.EXP_Data_Select();

            if (ds_5.Tables[0].Rows.Count > 0)//IN
            {
                gv_Details.DataSource = ds_5.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur Annexure Air Details";
                laod_Flat_File_Show();
                EAA = 0;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        return EAA;
    }
    private int EXPORT_ANNEXURE_C_SEA()
    {
        int EAS = 1;
        DataSet ds_5 = new DataSet();
        try
        {
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "EXPORT_ANNEXURE_C_Sea";
            EV.Branch_Type = SELECT_BRANCH;
            EV.Xml_D = "";
            ds_5 = EV.EXP_Data_Select();

            if (ds_5.Tables[0].Rows.Count > 0)//IN
            {
                gv_Details.DataSource = ds_5.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur Annexure Sea Details";
                laod_Flat_File_Show();
                EAS = 0;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        return EAS;
    }
    private int EXPORT_ANNEXURE_C_SEA_Container()
    {
        int EAS = 1;
        try
        {
            if (Connection.COMPANYID() == "293")
            {
                DataSet ds_5 = new DataSet();
                EV.Jobno = ddlJobNo.SelectedValue.ToString();
                EV.Flag = "EXPORT_ANNEXURE_C_Sea_Container";
                EV.Branch_Type = SELECT_BRANCH;
                EV.Xml_D = "";
                ds_5 = EV.EXP_Data_Select();

                if (ds_5.Tables[0].Rows.Count > 0)//IN
                {
                    gv_Details.DataSource = ds_5.Tables[0];
                    gv_Details.DataBind();
                    gv_Details.Attributes.Add("Width", "100%");

                    lbltablename.Text = "* Check Ur Annexure Sea Container Details";
                    EAS = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        return EAS;
    }
    private int Invoice_Details()
    {
        int INV = 1;
        DataSet ds_4 = new DataSet();
        try
        {
            EV.Flag = "EXP_EXCHANGE_RATE";
            ds_4 = EV.EXP_Admin_Select();

            if (ds_4.Tables[0].Rows.Count > 0)//AE
            {
                DataSet ds_5 = new DataSet();
                EV.Jobno = ddlJobNo.SelectedValue.ToString();
                EV.Flag = "EXP_INVOICE_DETAILS";
                EV.Branch_Type = SELECT_BRANCH;
                String xmlData_I = ConvertDataTableToXML(ds_4.Tables[0]);
                EV.Xml_D = xmlData_I;
                ds_5 = EV.EXP_Data_Select();

                if (ds_5.Tables[0].Rows.Count > 0)//IN
                {
                    gv_Details.DataSource = ds_5.Tables[0];
                    gv_Details.DataBind();
                    gv_Details.Attributes.Add("Width", "100%");

                    lbltablename.Text = "* Check Ur Invoice Details page";
                    laod_Flat_File_Show();
                    INV = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
        return INV;
    }
    private int Invoice_Cur_Ex_Rate_Details()
    {
        int INV = 1;
        DataSet ds_4E = new DataSet();
        try
        {
            EV.Flag = "EXP_EXCHANGE_RATE";
            ds_4E = EV.EXP_Admin_Select();

            if (ds_4E.Tables[0].Rows.Count > 0)//AE
            {
                DataSet ds_5E = new DataSet();
                EV.Jobno = ddlJobNo.SelectedValue.ToString();
                EV.Flag = "EXP_INVOICE_CUR_EXCHANGE_RATE";
                EV.Branch_Type = SELECT_BRANCH;
                String xmlData_I = ConvertDataTableToXML(ds_4E.Tables[0]);
                EV.Xml_D = xmlData_I;
                ds_5E = EV.EXP_Data_Select();

                if (ds_5E.Tables[0].Rows.Count > 0)//IN
                {
                    gv_Details.DataSource = ds_5E.Tables[0];
                    gv_Details.DataBind();
                    gv_Details.Attributes.Add("Width", "100%");

                    lbltablename.Text = "* Check Ur Invoice page Ex. Rate";
                    laod_Flat_File_Show();
                    INV = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
        return INV;
    }


    private int Invoice_No()
    {
        int INV = 1;
        DataSet ds_15 = new DataSet();
        try
        {
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "EXP_Invoice_No";
            EV.Branch_Type = SELECT_BRANCH;
            ds_15 = EV.EXP_Data_Select();
            if (ds_15.Tables[0].Rows.Count > 0)//IN
            {
                gv_Details.DataSource = ds_15.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur Invoice Details page";
                INV = 0;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
        return INV;
    }
    private int AR4()
    {
        int AR4 = 1;
        DataSet ds_5 = new DataSet();
        try
        {
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "EXP_AR4_DETAILS";
            EV.Branch_Type = SELECT_BRANCH;
            EV.Xml_D = "";
            ds_5 = EV.EXP_Data_Select();

            if (ds_5.Tables[0].Rows.Count > 0)//IN
            {
                gv_Details.DataSource = ds_5.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur AR4 Details page";
                laod_Flat_File_Show();
                AR4 = 0;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        return AR4;
    }
    private int Invoice_Item()
    {
        int Inv_Item = 1;
        DataSet ds_5 = new DataSet();
        try
        {
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "EXP_Invoice_Item";
            EV.Branch_Type = SELECT_BRANCH;
            EV.Xml_D = "";
            ds_5 = EV.EXP_Data_Select();

            if (ds_5.Tables[0].Rows.Count > 0)//IN
            {
                gv_Details.DataSource = ds_5.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur Invoice Details Entry page";
                laod_Flat_File_Show();
                Inv_Item = 0;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        return Inv_Item;
    }
    private int Item_Details()
    {
        int Item = 1;
        DataSet ds_6 = new DataSet();
        try
        {
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "EXP_ITEM_DETAILS_ADMIN";
            EV.Branch_Type = SELECT_BRANCH;
            ds_6 = EV.EXP_Data_Select();
            if (ds_6.Tables[0].Rows.Count > 0)
            {
                DataSet ds_7 = new DataSet();
                String xmlData_Item = ConvertDataTableToXML(ds_6.Tables[0]);
                EV.Xml_D = xmlData_Item;
                EV.Flag = "EXP_Items_Details";
                ds_7 = EV.EXP_Admin_Select();
                if (ds_7.Tables[0].Rows.Count > 0)
                {
                    gv_Details.DataSource = ds_7.Tables[0];
                    gv_Details.DataBind();
                    gv_Details.Attributes.Add("Width", "100%");

                    lbltablename.Text = "* Check Ur Item Details Page";
                    laod_Flat_File_Show();
                    Item = 0;
                }
            }
            else
            {
                Item = 0;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        return Item;
    }
    private int Item_Special_Charaters()
    {
        int CR = 1;
        DataSet ds_12 = new DataSet();
        try
        {
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "Item_Special_Character";
            EV.Branch_Type = SELECT_BRANCH;
            ds_12 = EV.EXP_Data_Select();
            if (ds_12.Tables[0].Rows.Count > 0)
            {
                gv_Details.DataSource = ds_12.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");
                lbltablename.Text = "* Check Ur Item Description Special Character";
                laod_Flat_File_Show();
                CR = 0;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
        return CR;
    }
    private int Item_Cess_Details()
    {
        int Item = 1;
        DataSet ds_6 = new DataSet();
        try
        {
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "EXP_ITEM_CESS_DETAILS";
            EV.Branch_Type = SELECT_BRANCH;
            ds_6 = EV.EXP_Data_Select();
            if (ds_6.Tables[0].Rows.Count > 0)
            {
                gv_Details.DataSource = ds_6.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur Item CESS Details Page";
                laod_Flat_File_Show();
                Item = 0;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       

        return Item;
    }
    private int Item_Lic()
    {
        int I_Lic = 1;
        DataSet ds_5 = new DataSet();
        try
        {
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "EXP_ITEM_LIC_DETAILS";
            EV.Branch_Type = SELECT_BRANCH;
            EV.Xml_D = "";
            ds_5 = EV.EXP_Data_Select();

            if (ds_5.Tables[0].Rows.Count > 0)//IN
            {
                gv_Details.DataSource = ds_5.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur Item License Details Page";
                laod_Flat_File_Show();
                I_Lic = 0;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        return I_Lic;
    }
    private int Item_Annuxure_C1_Details()
    {
        int Annuxure_C1_chk = 1;
        DataSet ds_5 = new DataSet();
        try
        {
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "EXP_ITEM_Annuxure_C1_Details";
            EV.Branch_Type = SELECT_BRANCH;
            EV.Xml_D = "";
            ds_5 = EV.EXP_Data_Select();

            if (ds_5.Tables[0].Rows.Count > 0)//IN
            {
                gv_Details.DataSource = ds_5.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur Annuxure C1 Details Page";
                laod_Flat_File_Show();
                Annuxure_C1_chk = 0;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
        return Annuxure_C1_chk;
    }
    private int Item_Dup_Check()
    {
        int Annuxure_C1_dup_chk = 1;
        DataSet ds_5 = new DataSet();
        try
        {
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "EXP_ITEM_Lic_Dup_Check";
            EV.Branch_Type = SELECT_BRANCH;
            EV.Xml_D = "";
            ds_5 = EV.EXP_Data_Select();

            if (ds_5.Tables[0].Rows.Count > 0)//IN
            {
                gv_Details.DataSource = ds_5.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur License Duplicate Check";
                laod_Flat_File_Show();
                Annuxure_C1_dup_chk = 0;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
        return Annuxure_C1_dup_chk;
    }

    private int Item_Mandatory_Check()
    {
        int Annuxure_C1_dup_chk = 1;
        DataSet ds_5 = new DataSet();
        try
        {
            EV.Jobno = ddlJobNo.SelectedValue.ToString();
            EV.Flag = "EXP_Item_Mandatory_Check";
            EV.Branch_Type = SELECT_BRANCH;
            EV.Xml_D = "";
            ds_5 = EV.EXP_Data_Select();

            if (ds_5.Tables[0].Rows.Count > 0)//IN
            {
                gv_Details.DataSource = ds_5.Tables[0];
                gv_Details.DataBind();
                gv_Details.Attributes.Add("Width", "100%");

                lbltablename.Text = "* Check Ur License Mandatory";
                laod_Flat_File_Show();
                Annuxure_C1_dup_chk = 0;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        return Annuxure_C1_dup_chk;
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
    private void laod_Flat_File_Show()
    {
        try
        {
            imgbtnFlatFile.Visible = false;
            btnsend_Queue.Visible = false;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }


    private void Flatfile_gen()
    {
        try
        {
            if (ddlJobNo.SelectedItem.Text != "Select")
            {
                if (hdn_Check_PMV.Value == "Yes")
                {
                    Joblock();
                    if (Session["USER_JOB_LOCK"].ToString() == "Yes")//Company lock chk
                    {
                        Admin_lock();
                    }
                    else if (Session["USER_JOB_LOCK"].ToString() == "No" || Session["USER_JOB_LOCK"] == null || Session["USER_JOB_LOCK"] == "")
                    {
                        Only_admin_lock_Chk();
                    }
                }
                else
                {
                    Alert_msg("First you generate Checklist");
                }
            }
            else
            {
                Alert_msg("Select the Job Number.");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        

    }
    private void Only_admin_lock_Chk()
    {
        try
        {
            if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
            {
                JOB_LOCK = Session["JOB_LOCK"].ToString();
                if (Convert.ToInt32(JOB_LOCK) == 1)
                {
                    btnSearch.Enabled = false;
                    imgbtnFlatFile.Enabled = false;
                    btnsend_Queue.Enabled = false;
                    Alert_msg("This Job is Locked by Admin");
                }
                else
                {
                    Flat_File_Generation();
                }
            }
            else
            {
                Flat_File_Generation();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        

    }
    private void Admin_lock()
    {
        try
        {
            if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
            {
                JOB_LOCK = Session["JOB_LOCK"].ToString();
                if (Convert.ToInt32(JOB_LOCK) == 1)
                {
                    btnSearch.Enabled = false;
                    imgbtnFlatFile.Enabled = false;
                    btnsend_Queue.Enabled = false;
                    Alert_msg("This Job is Locked by Admin");
                }
                else
                {
                    User_lock_Chk();
                }

            }
            else
            {
                User_lock_Chk();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       

    }
    private void User_lock_Chk()
    {
        try
        {
            if (Session["JOB_RELEASE"] != null && Session["JOB_RELEASE"] != "")
            {
                if (Session["JOB_USER"] != null && Session["JOB_USER"] != "")
                {
                    if (currentuser.ToUpper() != Session["JOB_USER"].ToString().ToUpper())
                    {
                        JOB_RELEASE = Session["JOB_RELEASE"].ToString();

                        if (JOB_RELEASE == "No")
                        {
                            MP_U.Show();
                            lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            imgbtnFlatFile.Enabled = false;
                            btnsend_Queue.Enabled = false;
                        }
                        else
                        {
                            Flat_File_Generation();
                        }
                    }
                    else
                    {
                        Flat_File_Generation();
                    }
                }
                else
                {
                    Flat_File_Generation();
                }
            }
            else
            {
                Flat_File_Generation();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    protected void imgbtnFlatFile_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            IS_Imgbtn = "1";
            imgbtnFlatFile.Visible = false;
            btnsend_Queue.Visible = false;
            string[] filePaths = Directory.GetFiles(errorFolder);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnSubmission_Click(object sender, EventArgs e)
    {
        try
        {
            btnSearch_Click(sender, e);
            if (hdlock_or_Not.Value == "True" && ddlJobNo.SelectedItem.Text != "Select")
            {
                SB_Details();
                string[] filePaths = Directory.GetFiles(errorFolder);
                string file = filePaths[0];

                mail(file);

                imgbtnFlatFile.Visible = true;
                //btnSubmission.Visible = true;
                btnsend_Queue.Visible = true;
                //btn_Outlookmail_Submission.Visible = true;
            }
            else
            {
                //imgbtn.Visible = false; -- 07-Oct-2016
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       

    }

    public void k(string file)
    {
        try
        {
            // Creates a new Outlook Application Instance
            Outlook.Application objOutlook = new Outlook.Application();
            // Creating a new Outlook Message from the Outlook Application Instance
            Outlook.MailItem mic = (Outlook.MailItem)(objOutlook.CreateItem(Outlook.OlItemType.olMailItem));
            mic.To = EMail_ID;
            mic.SaveAs(file, Outlook.OlSaveAsType.olMSG);
            mic.Display(true);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    public void d()
    {
        try
        {
            Outlook.Application outlookApp = new Outlook.Application();
            Outlook._MailItem mailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.To = EMail_ID;

            // body, bcc etc...

            mailItem.Display(true);


        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       

    }
    public void DisplayOutlook(string file, string from_email_id)
    {
        try
        {
            Outlook.Application objApp = new Outlook.Application();
            Outlook.MailItem mail = null;
            mail = (Outlook.MailItem)objApp.CreateItem(Outlook.OlItemType.olMailItem);
            //The CreateItem method returns an object which has to be typecast to MailItem 
            //before using it.
            mail.Attachments.Add((object)file, Outlook.OlAttachmentType.olEmbeddeditem, 1, (object)"Attachment");
            //The parameters are explained below
            mail.To = CUSTOMS_HOUSE + "@icegate.gov.in";

            mail.Subject = "SB";

            mail.Display(true);

            //mail.CC="con@def.com";//All the mail lists have to be separated by the ';'
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    public string DisplayAccountInformation()
    {
        try
        {
            Outlook.Application application = new Outlook.Application();

            //Outlook.ApplicationClass application = new Outlook.ApplicationClass();


            // The Namespace Object (Session) has a collection of accounts.
            Outlook.Accounts accounts = application.Session.Accounts;

            // Concatenate a message with information about all accounts.
            StringBuilder builder = new StringBuilder();

            // Loop over all accounts and print detail account information.
            // All properties of the Account object are read-only.
            foreach (Outlook.Account account in accounts)
            {

                // The DisplayName property represents the friendly name of the account.
                builder.AppendFormat("DisplayName: {0}\n", account.DisplayName);

                // The UserName property provides an account-based context to determine identity.
                builder.AppendFormat("UserName: {0}\n", account.UserName);

                // The SmtpAddress property provides the SMTP address for the account.
                builder.AppendFormat("SmtpAddress: {0}\n", account.SmtpAddress);

                Outlook_From_mail_Address = account.SmtpAddress;

                // The AccountType property indicates the type of the account.
                builder.Append("AccountType: ");
                switch (account.AccountType)
                {

                    case Outlook.OlAccountType.olExchange:
                        builder.AppendLine("Exchange");
                        break;

                    case Outlook.OlAccountType.olHttp:
                        builder.AppendLine("Http");
                        break;

                    case Outlook.OlAccountType.olImap:
                        builder.AppendLine("Imap");
                        break;

                    case Outlook.OlAccountType.olOtherAccount:
                        builder.AppendLine("Other");
                        break;

                    case Outlook.OlAccountType.olPop3:
                        builder.AppendLine("Pop3");
                        break;
                }

                builder.AppendLine();
            }

            // Display the account information.
            //System.Windows.Forms.MessageBox.Show(builder.ToString());
            if (Outlook_From_mail_Address != "")
            {
                SB_Details();
                string[] filePaths = Directory.GetFiles(errorFolder);
                string file = filePaths[0];

                Outlook.Application objApp = new Outlook.Application();
                Outlook.MailItem mail = null;
                mail = (Outlook.MailItem)objApp.CreateItem(Outlook.OlItemType.olMailItem);
                //The CreateItem method returns an object which has to be typecast to MailItem 
                //before using it.
                mail.Attachments.Add((object)file, Outlook.OlAttachmentType.olEmbeddeditem, 1, (object)"Attachment");
                //The parameters are explained below
                //mail.To = CUSTOMS_HOUSE + "@icegate.gov.in";
                mail.To = "sathish34@gmail.com";
                mail.Subject = "SB";
                mail.Display(true);
            }
            else
            {
                //Alert_msg("CV not forwarded. An instance of Ms Outlook needs to be running to send email, Mail error");
                Alert_msg("not opened. An instance of Ms Outlook needs to be running to send email, Mail error");
            }
        }//end of try block
        catch (Exception ex)
        {
        }//end of catch
        return Outlook_From_mail_Address;
    }

    //method to send email to outlook
    //public void sendEMailThroughOUTLOOK(string file)
    //{
    //    try
    //    {
    //        // Create the Outlook application.
    //        Outlook.Application oApp = new Outlook.Application();
    //        // Create a new mail item.
    //        Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
    //        // Set HTMLBody. 
    //        //add the body of the email
    //        oMsg.HTMLBody = "SB";
    //        //Add an attachment.
    //        String sDisplayName = "MyAttachment";
    //        int iPosition = (int)oMsg.Body.Length + 1;
    //        int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
    //        //now attached the file
    //        Outlook.Attachment oAttach = oMsg.Attachments.Add(file, iAttachType, iPosition, sDisplayName);
    //        //Subject line
    //        oMsg.Subject = "SB";
    //        // Add a recipient.
    //        Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
    //        // Change the recipient in the next line if necessary.
    //        //Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(CUSTOMS_HOUSE + "@icegate.gov.in");
    //        Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add("sathish34@gmail.com");
    //        //oMsg.BCC = "sathishkumar8789@gmail.com";

    //        oRecip.Resolve();
    //        // Send.
    //        oMsg.Send();
    //        // Clean up.
    //        oRecip = null;
    //        oRecips = null;
    //        oMsg = null;
    //        oApp = null;
    //    }//end of try block
    //    catch (Exception ex)
    //    {
    //    }//end of catch
    //}//end of Email Method


    protected void btn_Outlookmail_Submission_Click(object sender, EventArgs e)
    {
        try
        {
            btnSearch_Click(sender, e);

            if (hdlock_or_Not.Value == "True" && ddlJobNo.SelectedItem.Text != "Select")
            {
                imgbtnFlatFile.Visible = true;
                //btnSubmission.Visible = true;
                btnsend_Queue.Visible = true;
                // btn_Outlookmail_Submission.Visible = true;
                //btn_Outlookmail_Submission.Enabled = true;
                DisplayAccountInformation();
            }
            else
            {
                //imgbtn.Visible = false; ---07-Oct_2016
            }

            //SB_Details();
            //string[] filePaths = Directory.GetFiles(errorFolder);
            //string file = filePaths[0];
            //sendEMailThroughOUTLOOK(file);

            //string filename = Session["createflename"].ToString();
            //d();
            //k(file);
            //Process[] p = Process.GetProcessesByName("Outlook");
            //if (Process.GetProcessesByName("Outlook.exe").Length > 0)
            //{
            //    SB_Details();
            //    string[] filePaths = Directory.GetFiles(errorFolder);
            //    string file = filePaths[0];
            //    DisplayOutlook(file);
            //}
            //else
            //{

            //    Alert_msg("CV not forwarded. An instance of Ms Outlook needs to be running to send email, Mail error");
            //}


            //if(DisplayAccountInformation()!="")
            //{
            //    SB_Details();
            //    string[] filePaths = Directory.GetFiles(errorFolder);
            //    string file = filePaths[0];
            //    DisplayOutlook(file, Outlook_From_mail_Address);
            //}
            //else
            //{
            //    //Alert_msg("CV not forwarded. An instance of Ms Outlook needs to be running to send email, Mail error");
            //    Alert_msg("not opened. An instance of Ms Outlook needs to be running to send email, Mail error");
            //}

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

   //public void Flat_File()
    public void Flat_File(string Type, string path)
    {
        try
        {
            DateTime date = System.DateTime.Now;
            string datestringg = string.Format("{0:yyyyMMdd}", date);

            DateTime tt = System.DateTime.Now;

            string time = string.Format("{0:hhmm}", tt);
            GetDate_ddmmyy = Convert.ToDateTime(date).ToString("ddMMyy").ToString();
            string yy = Convert.ToDateTime(date).ToString("yyyy").ToString();

            logFileName = ddlJobNo.SelectedValue.ToString() + yy + ".sb";
            createfilename = logFileName;
            Session["createflename"] = logFileName;

            //Added By Benjamin 02092026

            JOBNO = ddlJobNo.SelectedValue.ToString();

            if (chkDummyFlatFile.Checked)
            {
                try
                {
             

                    JOBNO = GetAndSaveDummyJobNo(JOBNO, "F");

                    // saves to table AND returns final dummy job no
                    txtDummyJobNo.Text = JOBNO;            // keep textbox in sync with what actually got saved
                }
                catch (InvalidOperationException ex)
                {
                    ShowMessage(ex.Message, false);
                    return;   // stop — don't generate the flat file if max dummy attempts reached
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("DummyFlatFile Save Error: " + ex.ToString());
                    ShowMessage("Could not save Dummy Job No. Please try again.", false);
                    return;
                }
            }










            // sw = new StreamWriter(errorFolder + logFileName, true);
            if (Type == "SQ")
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(path + logFileName);
                try
                {
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    Connection.Error_Msg(ex.Message);
                }
                sw = new StreamWriter(path + logFileName, true);

            }
            else
            {
                sw = new StreamWriter(errorFolder + logFileName, true);
            }




            //----------------------- Kiran Group --------------------------
            if (Connection.COMPANYID() == "1636")
            {
                if (txt_icegate_Id.Text == "RKLPLCHA" || txt_icegate_Id.Text == "RKLPLCHAJM" || txt_icegate_Id.Text == "RKLPLCHAUM" || txt_icegate_Id.Text == "RKLPLCHARK")
                {
                    CHA_NO = "AADCR4880PCH001";
                }
                else if (txt_icegate_Id.Text == "RKRLCHA")
                {
                    if (CUSTOMS_HOUSE == "INMUN1")
                    {
                        CHA_NO = "AACFK1870ECH002";
                    }
                    else
                    {
                        CHA_NO = "AACFK1870ECH001";
                    }
                }
                else if (txt_icegate_Id.Text == "KRSACHA")
                {
                    CHA_NO = "AAGFK4878CCH001";
                }
            }


            ICEGATE_ID = txt_icegate_Id.Text.ToUpper();

            if (ds.Tables[21].Rows.Count > 0)
            {
                if (ds.Tables[21].Rows[0]["SEZ_ICEGATE_ID"].ToString() != "")
                {
                    ICEGATE_ID = ds.Tables[21].Rows[0]["SEZ_ICEGATE_ID"].ToString();
                }

                if (ds.Tables[21].Rows[0]["SEZ_PAN_NO"].ToString() != "")
                {
                    CHA_NO = ds.Tables[21].Rows[0]["SEZ_PAN_NO"].ToString();
                }
            }

            if (Connection.COMPANYID() == "2650" && (Connection.Current_User_Upper() == "CAPIMPORT" || Connection.Current_User_Upper() == "CAPEXPORT" || Connection.Current_User_Upper() == "SRIVALLIMPORT" || Connection.Current_User_Upper() == "SRIVALLIEXPORT" || Connection.Current_User_Upper() == "SUNIMPEX"))
            {
                CHA_NO = Connection.Get_EXP_CHA_NO();
            }
            else if (Connection.COMPANYID() == "2659" && Connection.Current_User_Upper() == "MILINDCIRCLE")
            {
                CHA_NO = Connection.Get_EXP_CHA_NO();
            }

            // sw=new Html32TextWriter(

            //FileInfo file = new FileInfo(errorFolder + logFileName);
            //sw = file.CreateText();

            sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + ch + "CACHE01" + ch + JOBNO + DDMMYY_JOBDATE + ch + datestringg + ch + time);

            sw.WriteLine("<TABLE>SB");


            ADDRESS1 = ADDRESS1.Length == 1 ? ADDRESS1 : ADDRESS1.TrimEnd('.');
            ADDRESS2 = ADDRESS2.Length == 1 ? ADDRESS2 : ADDRESS2.TrimEnd('.');
            ADDRESS3 = ADDRESS3.Length == 1 ? ADDRESS3 : ADDRESS3.TrimEnd('.');
            ADDRESS4 = ADDRESS4.Length == 1 ? ADDRESS4 : ADDRESS4.TrimEnd('.');
            ADDRESS5 = ADDRESS5.Length == 1 ? ADDRESS5 : ADDRESS5.TrimEnd('.');
            //CONSIGNEE_ADD1 = CONSIGNEE_ADD1.Length == 1 ? CONSIGNEE_ADD1 : CONSIGNEE_ADD1.TrimEnd('.');
            CONSIGNEE_ADD1 = string.IsNullOrEmpty(CONSIGNEE_ADD1) ? CONSIGNEE_ADD1 : (CONSIGNEE_ADD1.Length == 1 ? CONSIGNEE_ADD1 : CONSIGNEE_ADD1.TrimEnd('.'));
            CONSIGNEE_ADD2 = string.IsNullOrEmpty(CONSIGNEE_ADD2) ? CONSIGNEE_ADD2 : (CONSIGNEE_ADD2.Length == 1 ? CONSIGNEE_ADD2 : CONSIGNEE_ADD2.TrimEnd('.'));
            CONSIGNEE_ADD3 = string.IsNullOrEmpty(CONSIGNEE_ADD3) ? CONSIGNEE_ADD3 : (CONSIGNEE_ADD3.Length == 1 ? CONSIGNEE_ADD3 : CONSIGNEE_ADD3.TrimEnd('.'));
            CONSIGNEE_ADD4 = string.IsNullOrEmpty(CONSIGNEE_ADD4) ? CONSIGNEE_ADD4 : (CONSIGNEE_ADD4.Length == 1 ? CONSIGNEE_ADD4 : CONSIGNEE_ADD4.TrimEnd('.'));
            CONSIGNEE_ADD5 = string.IsNullOrEmpty(CONSIGNEE_ADD5) ? CONSIGNEE_ADD5 : (CONSIGNEE_ADD5.Length == 1 ? CONSIGNEE_ADD5 : CONSIGNEE_ADD5.TrimEnd('.'));
            MARKS_NO = MARKS_NO.Length == 1 ? MARKS_NO : MARKS_NO.TrimEnd('.');


            //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + CHA_NO + ch + IEC_NO + ch + BRANCH_NO + ch + EXPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + "F" + ch + EXPORTER_CLASS + ch + STATE_OF_EXPORT + ch + ADCODE + ch + EPZ_CODE + ch + CONSIGNEE_NAME + ch + CONSIGNEE_ADD1 + ch + CONSIGNEE_ADD2 + ch + CONSIGNEE_ADD3 + ch + CONSIGNEE_ADD4 + ch + CONSIGNEE_ADD5 + ch + NFEI_TYPE + ch + RBI_WAIVER_NO + ch + RBI_WAIVER_DATE + ch + CUSTOMS_HOUSE + ch + PORT_DISCHARGE + ch + COUNTRY_FINAL_DEST + ch + COUNTRY_DISCHARGE + ch + PORT_FINAL_DEST + ch + ANNEX_SEA_SEAL_TYPE + ch + NATURE_OF_CARGO + ch + GROSS_WEIGHT + ch + NET_WEIGHT + ch + UNIT_CODE + ch + TOTAL_PACKAGES + ch + MARKS_NO + ch + LOOSE_PACKETS + ch + NO_CONTAINERS + ch + ANNEX_AIR_MAWB_NO + ch + ANNEX_AIR_HAWB_NO + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

            //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + CHA_NO + ch + IEC_NO + ch + BRANCH_NO + ch + EXPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + TYPE_OF_EXPORTER + ch + EXPORTER_CLASS + ch + STATE_OF_EXPORT + ch + ADCODE + ch + EPZ_CODE + ch + CONSIGNEE_NAME + ch + CONSIGNEE_ADD1 + ch + CONSIGNEE_ADD2 + ch + CONSIGNEE_ADD3 + ch + CONSIGNEE_ADD4 + ch + CONSIGNEE_ADD5 + ch + NFEI_TYPE + ch + RBI_WAIVER_NO + ch + RBI_WAIVER_DATE + ch + CUSTOMS_HOUSE + ch + PORT_DISCHARGE + ch + COUNTRY_FINAL_DEST + ch + COUNTRY_DISCHARGE + ch + PORT_FINAL_DEST + ch + ANNEX_SEA_SEAL_TYPE + ch + NATURE_OF_CARGO + ch + GROSS_WEIGHT + ch + NET_WEIGHT + ch + UNIT_CODE + ch + TOTAL_PACKAGES + ch + MARKS_NO + ch + LOOSE_PACKETS + ch + NO_CONTAINERS + ch + ANNEX_AIR_MAWB_NO + ch + ANNEX_AIR_HAWB_NO + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

            //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + CHA_NO + ch + IEC_NO + ch + BRANCH_NO + ch + EXPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + TYPE_OF_EXPORTER + ch + EXPORTER_CLASS + ch + STATE_OF_EXPORT + ch + ADCODE + ch + EPZ_CODE + ch + CONSIGNEE_NAME + ch + CONSIGNEE_ADD1 + ch + CONSIGNEE_ADD2 + ch + CONSIGNEE_ADD3 + ch + CONSIGNEE_ADD4 + ch + CONSIGNEE_ADD5 + ch + NFEI_TYPE + ch + RBI_WAIVER_NO + ch + RBI_WAIVER_DATE + ch + CUSTOMS_HOUSE + ch + PORT_DISCHARGE + ch + COUNTRY_FINAL_DEST + ch + COUNTRY_DISCHARGE + ch + PORT_FINAL_DEST + ch + ANNEX_SEA_SEAL_TYPE + ch + NATURE_OF_CARGO + ch + GROSS_WEIGHT + ch + NET_WEIGHT + ch + UNIT_CODE + ch + TOTAL_PACKAGES + ch + MARKS_NO + ch + LOOSE_PACKETS + ch + NO_CONTAINERS + ch + ANNEX_AIR_MAWB_NO + ch + ANNEX_AIR_HAWB_NO + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + GSTN_TYPE + ch + GSTN_ID );

             /* hide on 27-08-2026 - Port of Destination & port discharge - place mismatched issue- sugg.by Bala sir. as per Icegate format changed
            if (SB_TYPE == "SEZ")
            {
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + CHA_NO + ch + IEC_NO + ch + BRANCH_NO + ch + EXPORTER_NAME.TrimEnd('.') + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + TYPE_OF_EXPORTER + ch + EXPORTER_CLASS + ch + STATE_OF_EXPORT + ch + ADCODE + ch + EPZ_CODE + ch + CONSIGNEE_NAME.TrimEnd('.') + ch + CONSIGNEE_ADD1 + ch + CONSIGNEE_ADD2 + ch + CONSIGNEE_ADD3 + ch + CONSIGNEE_ADD4 + ch + CONSIGNEE_ADD5 + ch + NFEI_TYPE + ch + RBI_WAIVER_NO + ch + RBI_WAIVER_DATE + ch + PORT_OF_LOADING + ch + PORT_DISCHARGE + ch + COUNTRY_DISCHARGE + ch + COUNTRY_FINAL_DEST + ch + PORT_FINAL_DEST + ch + ANNEX_SEA_SEAL_TYPE + ch + NATURE_OF_CARGO + ch + GROSS_WEIGHT + ch + NET_WEIGHT + ch + UNIT_CODE + ch + TOTAL_PACKAGES + ch + MARKS_NO + ch + LOOSE_PACKETS + ch + NO_CONTAINERS + ch + ANNEX_AIR_MAWB_NO + ch + ANNEX_AIR_HAWB_NO + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + GSTN_TYPE + ch + GSTN_ID); // COUNTRY_FINAL_DEST and COUNTRY_DISCHARGE interchanged on 17-Mar-2021 With Bala and Sathish
            }
            else
            {
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + CHA_NO + ch + IEC_NO + ch + BRANCH_NO + ch + EXPORTER_NAME.TrimEnd('.') + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + TYPE_OF_EXPORTER + ch + EXPORTER_CLASS + ch + STATE_OF_EXPORT + ch + ADCODE + ch + EPZ_CODE + ch + CONSIGNEE_NAME.TrimEnd('.') + ch + CONSIGNEE_ADD1 + ch + CONSIGNEE_ADD2 + ch + CONSIGNEE_ADD3 + ch + CONSIGNEE_ADD4 + ch + CONSIGNEE_ADD5 + ch + NFEI_TYPE + ch + RBI_WAIVER_NO + ch + RBI_WAIVER_DATE + ch + CUSTOMS_HOUSE + ch + PORT_DISCHARGE + ch + COUNTRY_DISCHARGE + ch + COUNTRY_FINAL_DEST + ch + PORT_FINAL_DEST + ch + ANNEX_SEA_SEAL_TYPE + ch + NATURE_OF_CARGO + ch + GROSS_WEIGHT + ch + NET_WEIGHT + ch + UNIT_CODE + ch + TOTAL_PACKAGES + ch + MARKS_NO + ch + LOOSE_PACKETS + ch + NO_CONTAINERS + ch + ANNEX_AIR_MAWB_NO + ch + ANNEX_AIR_HAWB_NO + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + GSTN_TYPE + ch + GSTN_ID); // COUNTRY_FINAL_DEST and COUNTRY_DISCHARGE interchanged on 17-Mar-2021 With Bala and Sathish
            }
            */

            if (SB_TYPE == "SEZ")
            {
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + CHA_NO + ch + IEC_NO + ch + BRANCH_NO + ch + EXPORTER_NAME.TrimEnd('.') + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + TYPE_OF_EXPORTER + ch + EXPORTER_CLASS + ch + STATE_OF_EXPORT + ch + ADCODE + ch + EPZ_CODE + ch + CONSIGNEE_NAME.TrimEnd('.') + ch + CONSIGNEE_ADD1 + ch + CONSIGNEE_ADD2 + ch + CONSIGNEE_ADD3 + ch + CONSIGNEE_ADD4 + ch + CONSIGNEE_ADD5 + ch + NFEI_TYPE + ch + RBI_WAIVER_NO + ch + RBI_WAIVER_DATE + ch + PORT_OF_LOADING + ch + PORT_FINAL_DEST + ch + COUNTRY_DISCHARGE + ch + COUNTRY_FINAL_DEST + ch + PORT_DISCHARGE + ch + ANNEX_SEA_SEAL_TYPE + ch + NATURE_OF_CARGO + ch + GROSS_WEIGHT + ch + NET_WEIGHT + ch + UNIT_CODE + ch + TOTAL_PACKAGES + ch + MARKS_NO + ch + LOOSE_PACKETS + ch + NO_CONTAINERS + ch + ANNEX_AIR_MAWB_NO + ch + ANNEX_AIR_HAWB_NO + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + GSTN_TYPE + ch + GSTN_ID); // COUNTRY_FINAL_DEST and COUNTRY_DISCHARGE interchanged on 17-Mar-2021 With Bala and Sathish
            }
            else
            {
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + CHA_NO + ch + IEC_NO + ch + BRANCH_NO + ch + EXPORTER_NAME.TrimEnd('.') + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + TYPE_OF_EXPORTER + ch + EXPORTER_CLASS + ch + STATE_OF_EXPORT + ch + ADCODE + ch + EPZ_CODE + ch + CONSIGNEE_NAME.TrimEnd('.') + ch + CONSIGNEE_ADD1 + ch + CONSIGNEE_ADD2 + ch + CONSIGNEE_ADD3 + ch + CONSIGNEE_ADD4 + ch + CONSIGNEE_ADD5 + ch + NFEI_TYPE + ch + RBI_WAIVER_NO + ch + RBI_WAIVER_DATE + ch + CUSTOMS_HOUSE + ch + PORT_FINAL_DEST + ch + COUNTRY_DISCHARGE + ch + COUNTRY_FINAL_DEST + ch + PORT_DISCHARGE + ch + ANNEX_SEA_SEAL_TYPE + ch + NATURE_OF_CARGO + ch + GROSS_WEIGHT + ch + NET_WEIGHT + ch + UNIT_CODE + ch + TOTAL_PACKAGES + ch + MARKS_NO + ch + LOOSE_PACKETS + ch + NO_CONTAINERS + ch + ANNEX_AIR_MAWB_NO + ch + ANNEX_AIR_HAWB_NO + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + GSTN_TYPE + ch + GSTN_ID); // COUNTRY_FINAL_DEST and COUNTRY_DISCHARGE interchanged on 17-Mar-2021 With Bala and Sathish
            }

            int i = 0;
            if (ds.Tables[1].Rows.Count > 0)
            {
                sw.WriteLine("<TABLE>INVOICE");
                while (ds.Tables[1].Rows.Count > i)
                {
                    INVOICE_SLNO = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_SLNO"].ToString());
                    INVOICE_NO = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_NO"].ToString());
                    INVOICE_DATE = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_DATE"].ToString().Replace("19000101", ""));
                    PAYMENT_METHOD = dt.Trim(ds.Tables[1].Rows[i]["PAYMENT_METHOD"].ToString());
                    PERIOD_PAYMENT = dt.Trim(ds.Tables[1].Rows[i]["PERIOD_PAYMENT"].ToString());
                    INVOICE_VALUE = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_VALUE"].ToString());
                    INVOICE_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["INVOICE_CURRENCY"].ToString());
                    EXCHANGE_RATE = dt.Trim(ds.Tables[1].Rows[i]["EXCHANGE_RATE"].ToString());
                    CONTRACT_NO = dt.Trim(ds.Tables[1].Rows[i]["CONTRACT_NO"].ToString());
                    TERMS = dt.Trim(ds.Tables[1].Rows[i]["TERMS"].ToString());
                    BUYER = dt.Trim(ds.Tables[1].Rows[i]["BUYER"].ToString());

                    BUYER_NAME = dt.Trim(ds.Tables[1].Rows[i]["BUYER_NAME"].ToString().Replace("amp);", ""));
                    BUYER_ADDRESS = dt.Trim(ds.Tables[1].Rows[i]["BUYER_ADDRESS"].ToString().Replace("amp);", ""));
                    BUYER_ADDRESS1 = dt.Trim(ds.Tables[1].Rows[i]["BUYER_ADDRESS1"].ToString().Replace("amp);", ""));
                    BUYER_ADDRESS2 = dt.Trim(ds.Tables[1].Rows[i]["BUYER_ADDRESS2"].ToString().Replace("amp);", ""));
                    BUYER_ADDRESS3 = dt.Trim(ds.Tables[1].Rows[i]["BUYER_ADDRESS3"].ToString().Replace("amp);", ""));
                    BUYER_ADDRESS4 = dt.Trim(ds.Tables[1].Rows[i]["BUYER_ADDRESS4"].ToString());
                    COMMISSION_RATE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["COMMISSION_RATE"].ToString()));
                    COMMISSION_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["COMMISSION_CHARGES"].ToString()));
                    COMMISSION_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["COMMISSION_CURRENCY"].ToString());
                    FOB_RATE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["FOB_RATE"].ToString()));

                    FOB_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["FOB_CHARGES"].ToString()));
                    FOB_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["FOB_CURRENCY"].ToString());
                    PACKMISC_RATE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["PACKMISC_RATE"].ToString()));
                    PACKMISC_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["PACKMISC_CHARGES"].ToString()));
                    PACKMISC_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["PACKMISC_CURRENCY"].ToString());
                    OTHER_DEDUCTION_RATE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["OTHER_DEDUCTION_RATE"].ToString()));
                    OTHER_DEDUCTION_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["OTHER_DEDUCTION_CHARGES"].ToString()));
                    OTHER_DEDUCTION_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["OTHER_DEDUCTION_CURRENCY"].ToString());
                    FREIGHT_RATE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["FREIGHT_RATE"].ToString()));
                    FREIGHT_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["FREIGHT_CHARGES"].ToString()));
                    FREIGHT_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["FREIGHT_CURRENCY"].ToString());
                    INSURANCE_RATE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["INSURANCE_RATE"].ToString()));
                    INSURANCE_CHARGES = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["INSURANCE_CHARGES"].ToString()));
                    INSURANCE_CURRENCY = dt.Trim(ds.Tables[1].Rows[i]["INSURANCE_CURRENCY"].ToString());
                    WHEATHER_UNIT_PRICE = dt.Trim(ds.Tables[1].Rows[i]["WHEATHER_UNIT_PRICE"].ToString());

                    THIRDPARTY_NAME = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["THIRDPARTY_NAME"].ToString()));
                    THIRDPARTY_ADD1 = dt.Trim(ds.Tables[1].Rows[i]["THIRDPARTY_ADD1"].ToString());
                    THIRDPARTY_ADD2 = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["THIRDPARTY_ADD2"].ToString()));
                    THIRDPARTY_CITY = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["THIRDPARTY_CITY"].ToString()));
                    T_PARTY_COUNTRY_SUB_DIV = dt.Trim(ds.Tables[1].Rows[i]["T_PARTY_COUNTRY_SUB_DIV"].ToString());
                    T_PARTY_COUNTRY_CODE = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["T_PARTY_COUNTRY_CODE"].ToString()));
                    T_PARTY_PIN = dt.Get_Nullval(dt.Trim(ds.Tables[1].Rows[i]["T_PARTY_PIN"].ToString()));
                    AUTHORIZED_ECONOMIC_OPERATOR_CODE = dt.Trim(ds.Tables[1].Rows[i]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString());
                    A_E_O_COUNTRY = dt.Trim(ds.Tables[1].Rows[i]["A_E_O_COUNTRY"].ToString());
                    AUTHORIZED_ECONOMIC_OPERATOR = dt.Trim(ds.Tables[1].Rows[i]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString());
                    TERMS_PLACE = dt.Trim(ds.Tables[1].Rows[i]["TERMS_PLACE"].ToString());

                    string Buyer_All = BUYER_ADDRESS + BUYER_ADDRESS1 + BUYER_ADDRESS2 + BUYER_ADDRESS3 + BUYER_ADDRESS4; // Split into chunks of 35 characters 
                    string[] BuyerParts = new string[5];
                    for (int k = 0; k < BuyerParts.Length && Buyer_All.Length > 0; k++)
                    {
                        int length = Math.Min(35, Buyer_All.Length);
                        BuyerParts[k] = Buyer_All.Substring(0, length);
                        Buyer_All = Buyer_All.Remove(0, length);
                    } // Assign to variables 
                    BUYER_ADDRESS = BuyerParts[0];
                    BUYER_ADDRESS1 = BuyerParts[1];
                    BUYER_ADDRESS2 = BuyerParts[2];
                    BUYER_ADDRESS3 = BuyerParts[3];
                    BUYER_ADDRESS4 = BuyerParts[4];

                    //if (BUYER_NAME == "SAME AS CONSIGNEE" && BUYER_ADDRESS == "")
                    if (BUYER_NAME == "SAME AS CONSIGNEE" && string.IsNullOrEmpty(BUYER_ADDRESS))
                    {
                        BUYER_ADDRESS = "`";
                    }

                    if (COMMISSION_RATE != "0.00" & COMMISSION_RATE != "0.0" && COMMISSION_RATE != "0" && COMMISSION_RATE != "")
                    {
                        COMMISSION_CHARGES = "";
                        //COMMISSION_CURRENCY = "";
                    }

                    if (FOB_RATE != "0.00" & FOB_RATE != "0.0" && FOB_RATE != "0" && FOB_RATE != "")
                    {
                        FOB_CHARGES = "";
                        //FOB_CURRENCY = "";
                    }

                    //if (PACKMISC_RATE != "0.00" & PACKMISC_RATE != "0.0" && PACKMISC_RATE != "0" && PACKMISC_RATE != "")
                    //{
                    //    PACKMISC_CHARGES = "";
                    //    //PACKMISC_CURRENCY = "";
                    //}

                    if (OTHER_DEDUCTION_RATE != "0.00" & OTHER_DEDUCTION_RATE != "0.0" && OTHER_DEDUCTION_RATE != "0" && OTHER_DEDUCTION_RATE != "")
                    {
                        OTHER_DEDUCTION_CHARGES = "";
                        //OTHER_DEDUCTION_CURRENCY = "";
                    }

                    //if (INSURANCE_RATE != "0.00" & INSURANCE_RATE != "0.0" && INSURANCE_RATE != "0" && INSURANCE_RATE != "")
                    //{
                    //    INSURANCE_CHARGES = "";
                    //    //INSURANCE_CURRENCY = "";
                    //}


                    CONTRACT_NO = CONTRACT_NO.Length == 1 ? CONTRACT_NO : CONTRACT_NO.TrimEnd('.');
                    BUYER_ADDRESS = string.IsNullOrEmpty(BUYER_ADDRESS) ? BUYER_ADDRESS : (BUYER_ADDRESS.Length == 1 ? BUYER_ADDRESS : BUYER_ADDRESS.TrimEnd('.'));
                    BUYER_ADDRESS1 = string.IsNullOrEmpty(BUYER_ADDRESS1) ? BUYER_ADDRESS1 : (BUYER_ADDRESS1.Length == 1 ? BUYER_ADDRESS1 : BUYER_ADDRESS1.TrimEnd('.'));
                    BUYER_ADDRESS2 = string.IsNullOrEmpty(BUYER_ADDRESS2) ? BUYER_ADDRESS2 : (BUYER_ADDRESS2.Length == 1 ? BUYER_ADDRESS2 : BUYER_ADDRESS2.TrimEnd('.'));
                    BUYER_ADDRESS3 = string.IsNullOrEmpty(BUYER_ADDRESS3) ? BUYER_ADDRESS3 : (BUYER_ADDRESS3.Length == 1 ? BUYER_ADDRESS3 : BUYER_ADDRESS3.TrimEnd('.'));
                    BUYER_ADDRESS4 = string.IsNullOrEmpty(BUYER_ADDRESS4) ? BUYER_ADDRESS4 : (BUYER_ADDRESS4.Length == 1 ? BUYER_ADDRESS4 : BUYER_ADDRESS4.TrimEnd('.'));
                    THIRDPARTY_NAME = THIRDPARTY_NAME.Length == 1 ? THIRDPARTY_NAME : THIRDPARTY_NAME.TrimEnd('.');
                    THIRDPARTY_ADD1 = THIRDPARTY_ADD1.Length == 1 ? THIRDPARTY_ADD1 : THIRDPARTY_ADD1.TrimEnd('.');
                    THIRDPARTY_ADD2 = THIRDPARTY_ADD2.Length == 1 ? THIRDPARTY_ADD2 : THIRDPARTY_ADD2.TrimEnd('.');
                    THIRDPARTY_CITY = THIRDPARTY_CITY.Length == 1 ? THIRDPARTY_CITY : THIRDPARTY_CITY.TrimEnd('.');
                    T_PARTY_COUNTRY_SUB_DIV = T_PARTY_COUNTRY_SUB_DIV.Length == 1 ? T_PARTY_COUNTRY_SUB_DIV : T_PARTY_COUNTRY_SUB_DIV.TrimEnd('.');
                    T_PARTY_COUNTRY_CODE = T_PARTY_COUNTRY_CODE.Length == 1 ? T_PARTY_COUNTRY_CODE : T_PARTY_COUNTRY_CODE.TrimEnd('.');
                    T_PARTY_PIN = T_PARTY_PIN.Length == 1 ? T_PARTY_PIN : T_PARTY_PIN.TrimEnd('.');
                    AUTHORIZED_ECONOMIC_OPERATOR_CODE = AUTHORIZED_ECONOMIC_OPERATOR_CODE.Length == 1 ? AUTHORIZED_ECONOMIC_OPERATOR_CODE : AUTHORIZED_ECONOMIC_OPERATOR_CODE.TrimEnd('.');
                    A_E_O_COUNTRY = A_E_O_COUNTRY.Length == 1 ? A_E_O_COUNTRY : A_E_O_COUNTRY.TrimEnd('.');
                    AUTHORIZED_ECONOMIC_OPERATOR = AUTHORIZED_ECONOMIC_OPERATOR.Length == 1 ? AUTHORIZED_ECONOMIC_OPERATOR : AUTHORIZED_ECONOMIC_OPERATOR.TrimEnd('.');
                    TERMS_PLACE = TERMS_PLACE.Length == 1 ? TERMS_PLACE : TERMS_PLACE.TrimEnd('.');


                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + INVOICE_NO + ch + INVOICE_DATE + ch + INVOICE_CURRENCY + ch + TERMS + ch + BUYER_NAME + ch + BUYER_ADDRESS + ch + BUYER_ADDRESS1 + ch + BUYER_ADDRESS2 + ch + BUYER_ADDRESS3 + ch + FREIGHT_CURRENCY + ch + FREIGHT_CHARGES + ch + INSURANCE_RATE + ch + INSURANCE_CURRENCY + ch + INSURANCE_CHARGES + ch + COMMISSION_RATE + ch + COMMISSION_CURRENCY + ch + COMMISSION_CHARGES + ch + FOB_RATE + ch + FOB_CURRENCY.ToUpper() + ch + FOB_CHARGES + ch + OTHER_DEDUCTION_RATE + ch + OTHER_DEDUCTION_CURRENCY + ch + OTHER_DEDUCTION_CHARGES + ch + WHEATHER_UNIT_PRICE + ch + PACKMISC_CHARGES + ch + CONTRACT_NO + ch + PAYMENT_METHOD + ch + PERIOD_PAYMENT + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + THIRDPARTY_NAME + ch + THIRDPARTY_ADD1 + ch + THIRDPARTY_ADD2 + ch + THIRDPARTY_CITY + ch + T_PARTY_COUNTRY_SUB_DIV + ch + T_PARTY_COUNTRY_CODE + ch + T_PARTY_PIN + ch + AUTHORIZED_ECONOMIC_OPERATOR_CODE + ch + A_E_O_COUNTRY + ch + AUTHORIZED_ECONOMIC_OPERATOR + ch + TERMS_PLACE);
                    i++;
                }
            }

            //int f = 0;
            //if (INVOICE_CURRENCY != "")
            //{
            //    sw.WriteLine("<TABLE>EXCHANGE");
            //    while (ds.Tables[9].Rows.Count > f)
            //    {

            //        INVOICE_CURRENCY = dt.Trim(ds.Tables[9].Rows[f]["INVOICE_CURRENCY"].ToString());
            //        EXCHANGE_RATE = "";

            //        if (INVOICE_CURRENCY != "")

            //            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_CURRENCY + ch + Currency_Name + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + EXCHANGE_RATE + ch + Effective_Date + ch + Standard_Currency + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
            //        f++;

            //    }
            //}


            int f = 0;
            if (INVOICE_CURRENCY != "")
            {
                sw.WriteLine("<TABLE>EXCHANGE");
                //while (ds.Tables[9].Rows.Count > f)
                //{

                //    INVOICE_CURRENCY = dt.Trim(ds.Tables[9].Rows[f]["INVOICE_CURRENCY"].ToString());
                //    EXCHANGE_RATE = "";

                //    if (INVOICE_CURRENCY != "")

                //        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_CURRENCY + ch + Currency_Name + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + EXCHANGE_RATE + ch + Effective_Date + ch + Standard_Currency + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
                //    f++;

                //}


                if (ds.Tables[9].Rows.Count > 0)
                {
                    while (ds.Tables[9].Rows.Count > f)
                    {
                        INVOICE_CURRENCY = dt.Trim(ds.Tables[9].Rows[f]["INVOICE_CURRENCY"].ToString());
                        //INVOICE_EXRATE = dt.Trim(ds.Tables[10].Rows[gg]["EX_RATE"].ToString());
                        string EXRATE = "";

                        //---------------For Non Standard Currency on 01Sep2015----------------//
                        Standard_Currency = "";
                        DataView view1 = dss.Tables[3].DefaultView;
                        view1.RowFilter = "EXCHANGE_CUR_CODE = '" + INVOICE_CURRENCY + "'";
                        DataSet dt_1 = new DataSet();
                        dt_1.Tables.Add(view1.ToTable());
                        if (dt_1.Tables[0].Rows.Count > 0)
                        {
                            EXCHANGE_RATE = dt_1.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();
                            Standard_Currency = "Y";
                            NON_STD_EFFECT_DT_EXP = "";
                            NON_STD_BANKNAME = "";
                            NON_STD_CERTIFICATE_NO = "";
                            NON_STD_CERTIFICATE_DATE = "";
                        }
                        else
                        {
                            DataView view2 = ds.Tables[1].DefaultView;

                            view2.RowFilter = "INVOICE_CURRENCY = '" + INVOICE_CURRENCY + "'";
                            DataSet dt_2 = new DataSet();
                            dt_2.Tables.Add(view2.ToTable());

                            if (dt_2.Tables[0].Rows.Count > 0)
                            {
                                NON_STD_EFFECT_DT_EXP = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_EFFECT_DT_EXP"].ToString().Replace("19000101", ""));
                                NON_STD_BANKNAME = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_BANKNAME"].ToString());
                                if (NON_STD_BANKNAME.Length > 20)
                                {
                                    NON_STD_BANKNAME = NON_STD_BANKNAME.Substring(0, 20);
                                }
                                NON_STD_CERTIFICATE_NO = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString());
                                NON_STD_CERTIFICATE_DATE = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString().Replace("19000101", ""));
                                EXCHANGE_RATE = dt.Trim(dt_2.Tables[0].Rows[0]["EXCHANGE_RATE"].ToString());
                                Standard_Currency = "N";

                                NON_STD_CERTIFICATE_NO = NON_STD_CERTIFICATE_NO.Length == 1 ? NON_STD_CERTIFICATE_NO : NON_STD_CERTIFICATE_NO.TrimEnd('.');
                                NON_STD_BANKNAME = NON_STD_BANKNAME.Length == 1 ? NON_STD_BANKNAME : NON_STD_BANKNAME.TrimEnd('.');
                            }
                        }

                        //---------------For Non Standard Currency on 01Sep2015----------------//

                        if (INVOICE_CURRENCY != "")

                            //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_CURRENCY + ch + Currency_Name + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + EXCHANGE_RATE + ch + Effective_Date + ch + Standard_Currency + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_CURRENCY + ch + NON_STD_BANKNAME + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + EXCHANGE_RATE + ch + NON_STD_EFFECT_DT_EXP + ch + Standard_Currency + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
                        f++;
                    }
                }


            }


            int j = 0;
            if (ds.Tables[2].Rows.Count > 0)
            {
                sw.WriteLine("<TABLE>ITEM");
                while (ds.Tables[2].Rows.Count > j)
                {
                    INVOICE_SLNO = dt.Trim(ds.Tables[2].Rows[j]["INVOICE_SLNO"].ToString());
                    INVOICE_NO = dt.Trim(ds.Tables[2].Rows[j]["INVOICE_NO"].ToString());
                    ITEM_SLNO = dt.Trim(ds.Tables[2].Rows[j]["ITEM_SLNO"].ToString());
                    ITEM_DESCRIPTION1 = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DESCRIPTION1"].ToString().Replace(System.Environment.NewLine, " ").Replace("\n", ""));
                    ITEM_DESCRIPTION2 = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DESCRIPTION2"].ToString().Replace(System.Environment.NewLine, " ").Replace("\n", ""));
                    ITEM_DESCRIPTION3 = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DESCRIPTION3"].ToString().Replace(System.Environment.NewLine, " ").Replace("\n", ""));
                    RITCNO = dt.Trim(ds.Tables[2].Rows[j]["RITCNO"].ToString());
                    ITEM_QTY = dt.Trim(ds.Tables[2].Rows[j]["ITEM_QTY"].ToString());
                    ITEM_QTY_CODE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_QTY_CODE"].ToString());
                    ITEM_UNIT_PRICE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_UNIT_PRICE"].ToString());
                    ITEM_PER = dt.Trim(ds.Tables[2].Rows[j]["ITEM_PER"].ToString());
                    ITEM_AMOUNT = dt.Trim(ds.Tables[2].Rows[j]["ITEM_AMOUNT"].ToString());
                    ITEM_PMVVALUE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_PMVVALUE"].ToString());
                    PMV_PER_UNIT = dt.Trim(ds.Tables[2].Rows[j]["PMV_PER_UNIT"].ToString());
                    PMV_METHOD = dt.Trim(ds.Tables[2].Rows[j]["PMV_METHOD"].ToString());

                    ITEM_SCHEME_CODE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_SCHEME_CODE"].ToString());
                    ITEM_ACCESSORIES_DESC = dt.Trim(ds.Tables[2].Rows[j]["ITEM_ACCESSORIES_DESC"].ToString().Replace(System.Environment.NewLine, " ").Replace("\n", ""));
                    ITEM_AR4_NO = dt.Trim(ds.Tables[2].Rows[j]["ITEM_AR4_NO"].ToString());
                    ITEM_AR4_DATE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_AR4_DATE"].ToString().Replace("19000101", ""));
                    ITEM_COMMISSION_RATE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_COMMISSION_RATE"].ToString());
                    ITEM_DIVISION = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DIVISION"].ToString());
                    ITEM_RANGE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_RANGE"].ToString());
                    ITEM_REMARKS = dt.Trim(ds.Tables[2].Rows[j]["ITEM_REMARKS"].ToString());
                    ITEM_IECCODE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_IECCODE"].ToString());
                    ITEM_EXPORTER_NAME = dt.Trim(ds.Tables[2].Rows[j]["ITEM_EXPORTER_NAME"].ToString());

                    BR_SLNO = dt.Trim(ds.Tables[2].Rows[j]["BR_SLNO"].ToString());
                    ITEM_ADDRESS1 = dt.Trim(ds.Tables[2].Rows[j]["ADDRESS1"].ToString());
                    ITEM_ADDRESS2 = dt.Trim(ds.Tables[2].Rows[j]["ADDRESS2"].ToString());
                    ITEM_ADDRESS3 = dt.Trim(ds.Tables[2].Rows[j]["ADDRESS3"].ToString());
                    ITEM_ADDRESS4 = dt.Trim(ds.Tables[2].Rows[j]["ADDRESS4"].ToString());
                    ITEM_ADDRESS5 = dt.Trim(ds.Tables[2].Rows[j]["ADDRESS5"].ToString());
                    ITEM_STR_CODE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_STR_CODE"].ToString());
                    REWARD_POINTS = dt.Trim(ds.Tables[2].Rows[j]["REWARD_POINTS"].ToString());


                    MANUFACTURER_PRODUCER = dt.Trim(ds.Tables[2].Rows[j]["MANUFACTURER_PRODUCER"].ToString());
                    M_P_GROWER_CODE = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_CODE"].ToString());
                    M_P_GROWER_ADD1 = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_ADD1"].ToString());
                    M_P_GROWER_ADD2 = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_ADD2"].ToString());
                    M_P_GROWER_CITY = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_CITY"].ToString());
                    M_P_GROWER_COUNTRY_SUBDIV = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_COUNTRY_SUBDIV"].ToString());
                    M_P_GROWER_PIN = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_PIN"].ToString());
                    M_P_GROWER_COUNTRY = dt.Trim(ds.Tables[2].Rows[j]["M_P_GROWER_COUNTRY"].ToString());
                    SOURCE_STATE = dt.Trim(ds.Tables[2].Rows[j]["SOURCE_STATE"].ToString());
                    TRANSIT_COUNTRY = dt.Trim(ds.Tables[2].Rows[j]["TRANSIT_COUNTRY"].ToString());
                    ACCESSORY_STATUS = dt.Trim(ds.Tables[2].Rows[j]["ACCESSORY_STATUS"].ToString());
                    HAWB_NO = dt.Trim(ds.Tables[2].Rows[j]["HAWB_NO"].ToString());
                    TOTAL_PKGS = dt.Trim(ds.Tables[2].Rows[j]["TOTAL_PKGS"].ToString());
                    ENDUSE_ITEM = dt.Trim(ds.Tables[2].Rows[j]["ENDUSE_ITEM"].ToString());
                    IGST_PAYMENT = dt.Trim(ds.Tables[2].Rows[j]["IGST_PAYMENT"].ToString());
                    TAXABLE_VALUE = dt.Trim(ds.Tables[2].Rows[j]["TAXABLE_VALUE"].ToString());
                    IGST_AMT = dt.Trim(ds.Tables[2].Rows[j]["IGST_AMT"].ToString());
                    RODTEP = dt.Trim(ds.Tables[2].Rows[j]["RODTEP"].ToString());



                    string val = dt.Trim(ds.Tables[2].Rows[j]["PMV_VALUE"].ToString());

                    if (Session["COMPANY_ID"].ToString() == "116")
                    {
                        if (currentbranch == "ACC, Kolkata" || currentbranch == "CusHouse, Kolkata" || currentbranch == "ICD,Petrapole")
                        {
                            val = dt.Trim(ds.Tables[2].Rows[j]["ITEM_PMVVALUE"].ToString());
                        }
                    }
                    //-------------Implemented on 16Mar2018 For elogix Clients and eroyal Clients----------------//
                    else if (Session["COMPANY_ID"].ToString() == "233" || Session["COMPANY_ID"].ToString() == "442" || Session["COMPANY_ID"].ToString() == "438" || Session["COMPANY_ID"].ToString() == "436" || Session["COMPANY_ID"].ToString() == "443" || Session["COMPANY_ID"].ToString() == "435" || Session["COMPANY_ID"].ToString() == "434" || Session["COMPANY_ID"].ToString() == "402" || Session["COMPANY_ID"].ToString() == "459" || Session["COMPANY_ID"].ToString() == "444" || Session["COMPANY_ID"].ToString() == "457" || Session["COMPANY_ID"].ToString() == "470" || Session["COMPANY_ID"].ToString() == "477" || Session["COMPANY_ID"].ToString() == "478" || Session["COMPANY_ID"].ToString() == "479" || Session["COMPANY_ID"].ToString() == "488" || Session["COMPANY_ID"].ToString() == "492" || Session["COMPANY_ID"].ToString() == "525" || Session["COMPANY_ID"].ToString() == "538" || Session["COMPANY_ID"].ToString() == "539" || Session["COMPANY_ID"].ToString() == "571")
                    {
                        val = dt.Trim(ds.Tables[2].Rows[j]["ITEM_PMVVALUE"].ToString());
                    }
                    //-------------Implemented on 16Mar2018 For elogix Clients and eroyal Clients----------------//



                    if (val == "")
                    {
                        val = "0.00";
                    }

                    if (val.Trim() != "" && Convert.ToDouble(val) != 0.00 && Convert.ToDouble(val) != 0)
                    {
                        //PMV_VALUE = Convert.ToString(Convert.ToDouble(val) / Convert.ToDouble(ITEM_QTY));
                        PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(val) / Convert.ToDouble(ITEM_QTY), 2).ToString("0.00"));


                        //this line hide by Chithra on 20-01-2020 for ITEM_PER calc wrong - do not (* Multiply) -should be (/- divide) 
                        //PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(PMV_VALUE) * Convert.ToDouble(ITEM_PER), 2).ToString("0.00"));

                        //this line hide by Chithra on 19-06-2020 for DBK value not come in Final Copy sugg.by Bala sir..
                        // PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(PMV_VALUE) / Convert.ToDouble(ITEM_PER), 2).ToString("0.00"));

                        //Again this line enabled on 05-08-2020 for DBK Rate Not Update in Icegate issue-Sugg.by Subbu sir..
                        PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(PMV_VALUE) * Convert.ToDouble(ITEM_PER), 2).ToString("0.00"));

                        if (Convert.ToDouble(PMV_VALUE) == 0.00 || Convert.ToDouble(PMV_VALUE) == 0)
                            PMV_VALUE = "0.01";

                        //PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(val), 1)/ Convert.ToDouble(ITEM_QTY).ToString("0.00"));
                        //string fob = Convert.ToString(Math.Round(val), 1).ToString("0.00"));

                    }
                    else
                    {
                        if (Convert.ToDouble(val) == 0.00 || Convert.ToDouble(val) == 0)
                            PMV_VALUE = "0.01";
                        else
                            PMV_VALUE = "0";
                    }


                    if (Session["COMPANY_ID"].ToString() == "116")
                    {
                        if (currentbranch == "ACC, Kolkata" || currentbranch == "CusHouse, Kolkata" || currentbranch == "ICD,Petrapole")
                        {
                            if (Convert.ToDouble(PMV_VALUE) == 0.01 || Convert.ToDouble(PMV_VALUE) == 0)
                                PMV_VALUE = "0.00";
                        }
                    }
                    //-------------Implemented on 16Mar2018 For elogix Clients  and eroyal Clients EXCEPTT FrightLog(ERI00525)----------------//
                    else if (Session["COMPANY_ID"].ToString() == "233" || Session["COMPANY_ID"].ToString() == "442" || Session["COMPANY_ID"].ToString() == "438" || Session["COMPANY_ID"].ToString() == "436" || Session["COMPANY_ID"].ToString() == "443" || Session["COMPANY_ID"].ToString() == "435" || Session["COMPANY_ID"].ToString() == "434" || Session["COMPANY_ID"].ToString() == "402" || Session["COMPANY_ID"].ToString() == "459" || Session["COMPANY_ID"].ToString() == "444" || Session["COMPANY_ID"].ToString() == "457" || Session["COMPANY_ID"].ToString() == "477" || Session["COMPANY_ID"].ToString() == "478" || Session["COMPANY_ID"].ToString() == "479" || Session["COMPANY_ID"].ToString() == "488" || Session["COMPANY_ID"].ToString() == "492" || Session["COMPANY_ID"].ToString() == "538" || Session["COMPANY_ID"].ToString() == "571")
                    {
                        if (Convert.ToDouble(PMV_VALUE) == 0.01 || Convert.ToDouble(PMV_VALUE) == 0)
                            PMV_VALUE = "0.00";
                    }
                    //-------------Implemented on 16Mar2018 For elogix Clients and eroyal Clients----------------//


                    //this condition implmtd for Agility on 24-07-2020 sugg by Bala sir..
                    if (PMV_METHOD == "Unit" || PMV_METHOD == "PerUnit")
                    {
                        PMV_VALUE = PMV_PER_UNIT;
                    }

                    //Check IS_JOBBING
                    DataView view1 = ds.Tables[5].DefaultView;

                    view1.RowFilter = "INVOICE_SLNO = " + INVOICE_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;

                    //DataTable table1 = view1.ToTable();
                    DataSet dt_UserRights = new DataSet();
                    dt_UserRights.Tables.Add(view1.ToTable());

                    NOTIFICATION_NO = "";
                    if (dt_UserRights.Tables[0].Rows.Count > 0)
                    {
                        NOTIFICATION_NO = dt.Trim(dt_UserRights.Tables[0].Rows[0]["NOTIFICATION_NO"].ToString());
                    }


                    //Check IS_JOBBING

                    //Check IS_ThirdPaty or Rewardpoints

                    string IS_ThirdParty = "", Is_Reward = "";
                    if (ITEM_EXPORTER_NAME != "")
                    {
                        IS_ThirdParty = "Y";
                        ITEM_EXPORTER_NAME_THIRD = ITEM_EXPORTER_NAME;
                    }
                    else
                        IS_ThirdParty = "N";

                    //if (REWARD_POINTS != "")
                    //{
                    //    Is_Reward = "Y";
                    //}
                    //else
                    //    Is_Reward = "N";
                    //Check IS_ThirdPaty or Rewardpoints

                    //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_SCHEME_CODE + ch + RITCNO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + ITEM_DESCRIPTION3 + ch + ITEM_QTY_CODE + ch + ITEM_QTY + ch + ITEM_UNIT_PRICE + ch + ITEM_QTY_CODE + ch + ITEM_PER + ch + PMV_VALUE + ch + NOTIFICATION_NO + ch + IS_ThirdParty + ch + REWARD_POINTS + ch + ch + ch);

                    /* hide on 02-02-2023 by Chithra for Export not numbering issue
                    if (MANUFACTURER_PRODUCER != "" || M_P_GROWER_CODE != "" || M_P_GROWER_ADD1 != "")
                    {
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_SCHEME_CODE + ch + RITCNO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + ITEM_DESCRIPTION3 + ch + ITEM_QTY_CODE + ch + ITEM_QTY + ch + ITEM_UNIT_PRICE + ch + ITEM_QTY_CODE + ch + ITEM_PER + ch + PMV_VALUE + ch + NOTIFICATION_NO + ch + IS_ThirdParty + ch + REWARD_POINTS + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + MANUFACTURER_PRODUCER + ch + M_P_GROWER_CODE + ch + M_P_GROWER_ADD1 + ch + M_P_GROWER_COUNTRY_SUBDIV + ch + M_P_GROWER_PIN + ch + M_P_GROWER_COUNTRY + ch + SOURCE_STATE + ch + TRANSIT_COUNTRY + ch + ACCESSORY_STATUS + ch + ENDUSE_ITEM + ch + HAWB_NO + ch + TOTAL_PKGS + ch + IGST_PAYMENT + ch + TAXABLE_VALUE + ch + IGST_AMT);
                    }
                    else
                    {
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_SCHEME_CODE + ch + RITCNO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + ITEM_DESCRIPTION3 + ch + ITEM_QTY_CODE + ch + ITEM_QTY + ch + ITEM_UNIT_PRICE + ch + ITEM_QTY_CODE + ch + ITEM_PER + ch + PMV_VALUE + ch + NOTIFICATION_NO + ch + IS_ThirdParty + ch + REWARD_POINTS + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + MANUFACTURER_PRODUCER + ch + M_P_GROWER_CODE + ch + M_P_GROWER_ADD1 + ch + M_P_GROWER_ADD2 + ch + M_P_GROWER_CITY + ch + M_P_GROWER_COUNTRY_SUBDIV + ch + M_P_GROWER_PIN + ch + M_P_GROWER_COUNTRY + ch + SOURCE_STATE + ch + TRANSIT_COUNTRY + ch + ACCESSORY_STATUS + ch + ENDUSE_ITEM + ch + HAWB_NO + ch + TOTAL_PKGS + ch + IGST_PAYMENT + ch + TAXABLE_VALUE + ch + IGST_AMT);
                    }
                    */



                    ITEM_DESCRIPTION1 = ITEM_DESCRIPTION1.Length == 1 ? ITEM_DESCRIPTION1 : ITEM_DESCRIPTION1.TrimEnd('.');
                    ITEM_DESCRIPTION2 = ITEM_DESCRIPTION2.Length == 1 ? ITEM_DESCRIPTION2 : ITEM_DESCRIPTION2.TrimEnd('.');
                    ITEM_DESCRIPTION3 = ITEM_DESCRIPTION3.Length == 1 ? ITEM_DESCRIPTION3 : ITEM_DESCRIPTION3.TrimEnd('.');
                    ITEM_ACCESSORIES_DESC = ITEM_ACCESSORIES_DESC.Length == 1 ? ITEM_ACCESSORIES_DESC : ITEM_ACCESSORIES_DESC.TrimEnd('.');
                    ITEM_EXPORTER_NAME = ITEM_EXPORTER_NAME.Length == 1 ? ITEM_EXPORTER_NAME : ITEM_EXPORTER_NAME.TrimEnd('.');
                    ADDRESS1 = ADDRESS1.Length == 1 ? ADDRESS1 : ADDRESS1.TrimEnd('.');
                    ADDRESS2 = ADDRESS2.Length == 1 ? ADDRESS2 : ADDRESS2.TrimEnd('.');
                    ADDRESS3 = ADDRESS3.Length == 1 ? ADDRESS3 : ADDRESS3.TrimEnd('.');
                    ADDRESS4 = ADDRESS4.Length == 1 ? ADDRESS4 : ADDRESS4.TrimEnd('.');
                    ADDRESS5 = ADDRESS5.Length == 1 ? ADDRESS5 : ADDRESS5.TrimEnd('.');
                    MANUFACTURER_PRODUCER = MANUFACTURER_PRODUCER.Length == 1 ? MANUFACTURER_PRODUCER : MANUFACTURER_PRODUCER.TrimEnd('.');
                    M_P_GROWER_CODE = M_P_GROWER_CODE.Length == 1 ? M_P_GROWER_CODE : M_P_GROWER_CODE.TrimEnd('.');
                    M_P_GROWER_ADD1 = M_P_GROWER_ADD1.Length == 1 ? M_P_GROWER_ADD1 : M_P_GROWER_ADD1.TrimEnd('.');
                    M_P_GROWER_ADD2 = M_P_GROWER_ADD2.Length == 1 ? M_P_GROWER_ADD2 : M_P_GROWER_ADD2.TrimEnd('.');
                    M_P_GROWER_CITY = M_P_GROWER_CITY.Length == 1 ? M_P_GROWER_CITY : M_P_GROWER_CITY.TrimEnd('.');
                    M_P_GROWER_COUNTRY_SUBDIV = M_P_GROWER_COUNTRY_SUBDIV.Length == 1 ? M_P_GROWER_COUNTRY_SUBDIV : M_P_GROWER_COUNTRY_SUBDIV.TrimEnd('.');
                    M_P_GROWER_PIN = M_P_GROWER_PIN.Length == 1 ? M_P_GROWER_PIN : M_P_GROWER_PIN.TrimEnd('.');
                    M_P_GROWER_COUNTRY = M_P_GROWER_COUNTRY.Length == 1 ? M_P_GROWER_COUNTRY : M_P_GROWER_COUNTRY.TrimEnd('.');
                    HAWB_NO = HAWB_NO.Length == 1 ? HAWB_NO : HAWB_NO.TrimEnd('.');
                    ITEM_EXPORTER_NAME_THIRD = ITEM_EXPORTER_NAME.Length == 1 ? ITEM_EXPORTER_NAME : ITEM_EXPORTER_NAME.TrimEnd('.');


                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_SCHEME_CODE + ch + RITCNO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + ITEM_DESCRIPTION3 + ch + ITEM_QTY_CODE + ch + ITEM_QTY + ch + ITEM_UNIT_PRICE + ch + ITEM_QTY_CODE + ch + ITEM_PER + ch + PMV_VALUE + ch + NOTIFICATION_NO + ch + IS_ThirdParty + ch + REWARD_POINTS + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + MANUFACTURER_PRODUCER + ch + M_P_GROWER_CODE + ch + M_P_GROWER_ADD1 + ch + M_P_GROWER_ADD2 + ch + M_P_GROWER_CITY + ch + M_P_GROWER_COUNTRY_SUBDIV + ch + M_P_GROWER_PIN + ch + M_P_GROWER_COUNTRY + ch + SOURCE_STATE + ch + TRANSIT_COUNTRY + ch + ACCESSORY_STATUS + ch + ENDUSE_ITEM + ch + HAWB_NO + ch + TOTAL_PKGS + ch + IGST_PAYMENT + ch + TAXABLE_VALUE + ch + IGST_AMT);

                    j++;
                }
            }

            //-------------------------

            int ac = 0;

            DataView view_accessdesc = ds.Tables[2].DefaultView;

            view_accessdesc.RowFilter = "ITEM_ACCESSORIES_DESC <> ''";
            DataSet ds_accessdesc = new DataSet();
            ds_accessdesc.Tables.Add(view_accessdesc.ToTable());

            if (ds_accessdesc.Tables[0].Rows.Count > 0)
            {
                ITEM_ACCESSORIES_DESC = dt.Trim(ds_accessdesc.Tables[0].Rows[0]["ITEM_ACCESSORIES_DESC"].ToString());

            }

            //if (ds.Tables[13].Rows.Count > 0)
            //{
            if (ITEM_ACCESSORIES_DESC != "")
            {
                sw.WriteLine("<TABLE>ITEMACCESS");
                while (ds_accessdesc.Tables[0].Rows.Count > ac)
                {
                    INVOICE_SLNO = dt.Trim(ds_accessdesc.Tables[0].Rows[ac]["INVOICE_SLNO"].ToString());
                    INVOICE_NO = dt.Trim(ds_accessdesc.Tables[0].Rows[ac]["INVOICE_NO"].ToString());
                    ITEM_SLNO = dt.Trim(ds_accessdesc.Tables[0].Rows[ac]["ITEM_SLNO"].ToString());

                    ITEM_ACCESSORIES_DESC = dt.Trim(ds_accessdesc.Tables[0].Rows[ac]["ITEM_ACCESSORIES_DESC"].ToString());

                    if (ITEM_ACCESSORIES_DESC != "")
                    {
                        //    sw.WriteLine("<TABLE>ITEMACCESS");
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_ACCESSORIES_DESC);
                    }
                    ac++;
                }
            }
            //}


            //-------------------------


            int K = 0;

            DataView view_third = ds.Tables[2].DefaultView;

            //view_third.RowFilter = "ITEM_EXPORTER_NAME = '" + ITEM_EXPORTER_NAME_THIRD + "'";
            view_third.RowFilter = "ITEM_EXPORTER_NAME <> ''";
            DataSet dS_third = new DataSet();
            dS_third.Tables.Add(view_third.ToTable());

            if (dS_third.Tables[0].Rows.Count > 0)
            {
                ITEM_EXPORTER_NAME = dt.Trim(dS_third.Tables[0].Rows[0]["ITEM_EXPORTER_NAME"].ToString());

            }

            if (ITEM_EXPORTER_NAME != "")
            {
                string G_Id = string.Empty;
                sw.WriteLine("<TABLE>THIRDPARTY");
                while (dS_third.Tables[0].Rows.Count > K)
                {
                    INVOICE_SLNO = dt.Trim(dS_third.Tables[0].Rows[K]["INVOICE_SLNO"].ToString());
                    INVOICE_NO = dt.Trim(dS_third.Tables[0].Rows[K]["INVOICE_NO"].ToString());
                    ITEM_SLNO = dt.Trim(dS_third.Tables[0].Rows[K]["ITEM_SLNO"].ToString());

                    ITEM_IECCODE = dt.Trim(dS_third.Tables[0].Rows[K]["ITEM_IECCODE"].ToString());
                    ITEM_EXPORTER_NAME = dt.Trim(dS_third.Tables[0].Rows[K]["ITEM_EXPORTER_NAME"].ToString());

                    BR_SLNO = dt.Trim(dS_third.Tables[0].Rows[K]["BR_SLNO"].ToString());
                    ITEM_ADDRESS1 = dt.Trim(dS_third.Tables[0].Rows[K]["ADDRESS1"].ToString());
                    ITEM_ADDRESS2 = dt.Trim(dS_third.Tables[0].Rows[K]["ADDRESS2"].ToString());
                    ITEM_ADDRESS3 = dt.Trim(dS_third.Tables[0].Rows[K]["ADDRESS3"].ToString());
                    ITEM_ADDRESS4 = dt.Trim(dS_third.Tables[0].Rows[K]["ADDRESS4"].ToString());
                    ITEM_ADDRESS5 = dt.Trim(dS_third.Tables[0].Rows[K]["ADDRESS5"].ToString());
                    ITEM_STR_CODE = dt.Trim(dS_third.Tables[0].Rows[K]["ITEM_STR_CODE"].ToString());
                    REWARD_POINTS = dt.Trim(dS_third.Tables[0].Rows[K]["REWARD_POINTS"].ToString());

                    GSTN_TYPE = dt.Trim(dS_third.Tables[0].Rows[K]["GSTN_TYPE"].ToString());
                    //GSTN_ID = dt.Trim(dS_third.Tables[0].Rows[K]["GSTN_ID"].ToString());
                    G_Id = dt.Trim(dS_third.Tables[0].Rows[K]["GSTN_ID"].ToString());

                    ITEM_EXPORTER_NAME = ITEM_EXPORTER_NAME.Length == 1 ? ITEM_EXPORTER_NAME : ITEM_EXPORTER_NAME.TrimEnd('.');
                    ITEM_ADDRESS1 = ITEM_ADDRESS1.Length == 1 ? ITEM_ADDRESS1 : ITEM_ADDRESS1.TrimEnd('.');
                    ITEM_ADDRESS2 = ITEM_ADDRESS2.Length == 1 ? ITEM_ADDRESS2 : ITEM_ADDRESS2.TrimEnd('.');
                    ITEM_ADDRESS3 = ITEM_ADDRESS3.Length == 1 ? ITEM_ADDRESS3 : ITEM_ADDRESS3.TrimEnd('.');
                    ITEM_ADDRESS4 = ITEM_ADDRESS4.Length == 1 ? ITEM_ADDRESS4 : ITEM_ADDRESS4.TrimEnd('.');
                    ITEM_ADDRESS5 = ITEM_ADDRESS5.Length == 1 ? ITEM_ADDRESS5 : ITEM_ADDRESS5.TrimEnd('.');


                    //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_IECCODE + ch + BR_SLNO + ch + ITEM_EXPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS5 + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);                
                    //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_IECCODE + ch + BR_SLNO + ch + ITEM_EXPORTER_NAME + ch + ITEM_ADDRESS1 + ch + ITEM_ADDRESS2 + ch + ITEM_ADDRESS3 + ch + ITEM_ADDRESS5 + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + GSTN_TYPE + ch + GSTN_ID);
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_IECCODE + ch + BR_SLNO + ch + ITEM_EXPORTER_NAME + ch + ITEM_ADDRESS1 + ch + ITEM_ADDRESS2 + ch + ITEM_ADDRESS3 + ch + ITEM_ADDRESS5 + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + GSTN_TYPE + ch + G_Id);

                    K++;
                }
            }

            //-----------------------------------Cess Details--------------------------------------//

            int CC = 0;
            if (ds.Tables[12].Rows.Count > 0)
            {
                sw.WriteLine("<TABLE>CESS");
                while (ds.Tables[12].Rows.Count > CC)
                {
                    INVOICE_SLNO = dt.Trim(ds.Tables[12].Rows[CC]["INVOICE_SLNO"].ToString());
                    ITEM_SLNO = dt.Trim(ds.Tables[12].Rows[CC]["ITEM_SLNO"].ToString());

                    CESS_ID = dt.Trim(ds.Tables[12].Rows[CC]["CESS_ID"].ToString());
                    CESS_SLNO = dt.Trim(ds.Tables[12].Rows[CC]["CESS_SLNO"].ToString());
                    CESS_VALUE = dt.Trim(ds.Tables[12].Rows[CC]["CESS_VALUE"].ToString());
                    CESS_UNIT = dt.Trim(ds.Tables[12].Rows[CC]["CESS_UNIT"].ToString());

                    CESS_FLAG = dt.Trim(ds.Tables[12].Rows[CC]["CESS_FLAG"].ToString());
                    CESS_RATE = dt.Trim(ds.Tables[12].Rows[CC]["CESS_RATE"].ToString());
                    CESS_ITEM_QTY = dt.Trim(ds.Tables[12].Rows[CC]["CESS_ITEM_QTY"].ToString());
                    CESS_ITEM_QTY_CODE = dt.Trim(ds.Tables[12].Rows[CC]["CESS_ITEM_QTY_CODE"].ToString());
                    CESS_TARIFF_VALUE = dt.Trim(ds.Tables[12].Rows[CC]["CESS_TARIFF_VALUE"].ToString());
                    CESS_TARIFF_UNIT = dt.Trim(ds.Tables[12].Rows[CC]["CESS_TARIFF_UNIT"].ToString());

                    CESS_ID = "";

                    if (CESS_ITEM_QTY == "")
                    {
                        CESS_ITEM_QTY = "0";
                    }

                    CESS_SLNO = CESS_SLNO.Length == 1 ? CESS_SLNO : CESS_SLNO.TrimEnd('.');
                    CESS_VALUE = CESS_VALUE.Length == 1 ? CESS_VALUE : CESS_VALUE.TrimEnd('.');
                    CESS_UNIT = CESS_UNIT.Length == 1 ? CESS_UNIT : CESS_UNIT.TrimEnd('.');
                    CESS_FLAG = CESS_FLAG.Length == 1 ? CESS_FLAG : CESS_FLAG.TrimEnd('.');
                    CESS_RATE = CESS_RATE.Length == 1 ? CESS_RATE : CESS_RATE.TrimEnd('.');
                    CESS_ITEM_QTY = CESS_ITEM_QTY.Length == 1 ? CESS_ITEM_QTY : CESS_ITEM_QTY.TrimEnd('.');
                    CESS_TARIFF_VALUE = CESS_TARIFF_VALUE.Length == 1 ? CESS_TARIFF_VALUE : CESS_TARIFF_VALUE.TrimEnd('.');


                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CESS_ID + ch + CESS_SLNO + ch + CESS_ITEM_QTY + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

                    CC++;
                }
            }

            //-----------------------------------Cess Details--------------------------------------//



            int dbk = 0;
            if (ds.Tables[3].Rows.Count > 0)
            {
                sw.WriteLine("<TABLE>DBK");
                while (ds.Tables[3].Rows.Count > dbk)
                {
                    //JOBNO = ds.Tables[0].Rows[0]["JOBNO"].ToString();

                    INVOICE_SLNO = dt.Trim(ds.Tables[3].Rows[dbk]["INVOICE_SLNO"].ToString());

                    ITEM_SLNO = dt.Trim(ds.Tables[3].Rows[dbk]["ITEM_SLNO"].ToString());

                    //SCHEME_CODE = ds.Tables[3].Rows[0]["SCHEME_CODE"].ToString();

                    DRAWBACK_SLNO = dt.Trim(ds.Tables[3].Rows[dbk]["DRAWBACK_SLNO"].ToString());

                    DRAWBACK_QTY = dt.Trim(ds.Tables[3].Rows[dbk]["DRAWBACK_QTY"].ToString());

                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + DRAWBACK_SLNO + ch + DRAWBACK_QTY + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
                    dbk++;
                }
            }


            int mm = 0;

            if (ds.Tables[11].Rows.Count > 0)
            {
                sw.WriteLine("<TABLE>LICENCE");
                while (ds.Tables[11].Rows.Count > mm)
                {
                    INVOICE_SLNO = dt.Trim(ds.Tables[11].Rows[mm]["INV_SL_NO"].ToString());
                    ITEM_SLNO = dt.Trim(ds.Tables[11].Rows[mm]["ITEM_SL_NO"].ToString());
                    LICENSE_NO = dt.Trim(ds.Tables[11].Rows[mm]["LICENSE_NO"].ToString());
                    LICENSE_ID = dt.Trim(ds.Tables[11].Rows[mm]["LICENSE_ID"].ToString());

                    DataSet dss = new DataSet();
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        DataView view = ds.Tables[4].DefaultView;
                        //view.RowFilter = "LICENSE_NO" + " = '" +LICENSE_NO+ "'";
                        view.RowFilter = "LICENSE_NO = '" + LICENSE_NO + "' and " + "LICENSE_ID = " + LICENSE_ID;
                        DataTable table = view.ToTable();
                        dss.Tables.Add(table);

                        int m = 0;
                        while (dss.Tables[0].Rows.Count > m)
                        {
                            //---------------Modified on 4th Oct 2014-------------------//

                            //SCHEME_CODE = dt.Trim(dss.Tables[0].Rows[m]["SCHEME_CODE"].ToString());
                            //SCHEME = dt.Trim(dss.Tables[0].Rows[m]["SCHEME"].ToString());
                            //LICENSE_R_SL_NO = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_R_SL_NO"].ToString());
                            //LICENSE_NO = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_NO"].ToString());
                            LICENSE_DATE = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_DATE"].ToString().Replace("19000101", ""));
                            LICENSE_E_SL_NO = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_E_SL_NO"].ToString());
                            LICENSE_EXP_QTY = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_EXP_QTY"].ToString());
                            LICENSE_EXP_UNIT = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_EXP_UNIT"].ToString());
                            LICENSE_IMP_ITEM_SL_NO = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_IMP_ITEM_SL_NO"].ToString());
                            LICENSE_IMP_DESC = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_IMP_DESC"].ToString());
                            LICENSE_IMP_QTY = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_IMP_QTY"].ToString());
                            LICENSE_IMP_UNIT = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_IMP_UNIT"].ToString());
                            LICENSE_IMP_TYPE = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_IMP_TYPE"].ToString());
                            LICENSE_IMP_DESC = LICENSE_IMP_DESC.Length == 1 ? LICENSE_IMP_DESC : LICENSE_IMP_DESC.TrimEnd('.');

                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SRNO + ch + LICENSE_NO + ch + LICENSE_DATE + ch + LICENSE_E_SL_NO + ch + LICENSE_IMP_ITEM_SL_NO + ch + LICENSE_IMP_QTY + ch + LICENSE_EXP_QTY + ch + LICENSE_IMP_TYPE + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

                            m++;
                        }
                    }
                    mm++;
                }
            }

            int n = 0;
            if (ds.Tables[5].Rows.Count > 0)
            {
                sw.WriteLine("<TABLE>JOBWORK");
                while (ds.Tables[5].Rows.Count > n)
                {
                    INVOICE_SLNO = dt.Trim(ds.Tables[5].Rows[n]["INVOICE_SLNO"].ToString());
                    ITEM_SLNO = dt.Trim(ds.Tables[5].Rows[n]["ITEM_SLNO"].ToString());
                    SCHEME_CODE = dt.Trim(ds.Tables[5].Rows[n]["SCHEME_CODE"].ToString());
                    NOTIFICATION_NO = dt.Trim(ds.Tables[5].Rows[n]["NOTIFICATION_NO"].ToString());
                    BE_NO = dt.Trim(ds.Tables[5].Rows[n]["BE_NO"].ToString());
                    BE_DATE = dt.Trim(ds.Tables[5].Rows[n]["BE_DATE"].ToString().Replace("19000101", ""));
                    BE_INV_SLNO = dt.Trim(ds.Tables[5].Rows[n]["BE_INV_SLNO"].ToString());

                    BE_INV_NO = dt.Trim(ds.Tables[5].Rows[n]["BE_INV_NO"].ToString());
                    BE_ITEM_NO = dt.Trim(ds.Tables[5].Rows[n]["BE_ITEM_NO"].ToString());
                    BE_PORT_CODE = dt.Trim(ds.Tables[5].Rows[n]["BE_PORT_CODE"].ToString());
                    QTY = dt.Trim(ds.Tables[5].Rows[n]["QTY"].ToString());
                    UNIT = dt.Trim(ds.Tables[5].Rows[n]["UNIT"].ToString());

                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SRNO + ch + BE_NO + ch + BE_DATE + ch + BE_INV_SLNO + ch + BE_INV_NO + ch + BE_ITEM_NO + ch + BE_PORT_CODE + ch + QTY + ch + UNIT + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
                    n++;
                }
            }
            //--------------------------------------------------job based AR4 details---------------------------------------//
            int a = 0;
            if (ds.Tables[10].Rows.Count > 0)
            {
                sw.WriteLine("<TABLE>AR4");
                while (ds.Tables[10].Rows.Count > a)
                {
                    //INVOICE_SLNO = "1";//set default as Invoice No 1

                    INVOICE_SLNO = dt.Trim(ds.Tables[10].Rows[a]["AR4_INVOICE_SLNO"].ToString());

                    ITEM_SLNO = dt.Trim(ds.Tables[10].Rows[a]["AR4_ITEM_NO"].ToString());

                    //ITEM_SLNO = dt.Trim(ds.Tables[10].Rows[a]["AR4_RUN_ID"].ToString());
                    //ITEM_SLNO = Convert.ToString(a + 1);
                    // ITEM_SLNO = dt.Trim(ds.Tables[10].Rows[a]["AR4_ID"].ToString());

                    ITEM_AR4_NO = dt.Trim(ds.Tables[10].Rows[a]["AR4_NO"].ToString());
                    ITEM_AR4_DATE = dt.Trim(ds.Tables[10].Rows[a]["AR4_DATE"].ToString().Replace("19000101", ""));
                    ITEM_COMMISSION_RATE = dt.Trim(ds.Tables[10].Rows[a]["AR4_COMMISSION_RATE"].ToString());
                    ITEM_DIVISION = dt.Trim(ds.Tables[10].Rows[a]["AR4_DIVISION"].ToString());
                    ITEM_RANGE = dt.Trim(ds.Tables[10].Rows[a]["AR4_RANGE"].ToString());
                    ITEM_REMARKS = dt.Trim(ds.Tables[10].Rows[a]["AR4_REMARKS"].ToString());

                    if (ITEM_REMARKS == "")
                    {
                        ITEM_REMARKS = "NIL";
                    }

                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_AR4_NO + ch + ITEM_AR4_DATE + ch + ITEM_COMMISSION_RATE + ch + ITEM_DIVISION + ch + ITEM_RANGE + ch + ITEM_REMARKS);

                    a++;
                }
            }
            //--------------------------------------------------job based AR4 details---------------------------------------//
            int b = 0;
            if (ds.Tables[6].Rows.Count > 0)
            {
                sw.WriteLine("<TABLE>PACKINGLIST");
                while (ds.Tables[6].Rows.Count > b)
                {
                    ANNEX_SEA_PACK_FROM = dt.Trim(ds.Tables[6].Rows[b]["ANNEX_SEA_PACK_FROM"].ToString());

                    ANNEX_SEA_PACK_TO = dt.Trim(ds.Tables[6].Rows[b]["ANNEX_SEA_PACK_TO"].ToString());

                    ANNEX_SEA_PACK_PACKAGETYPE = dt.Trim(ds.Tables[6].Rows[b]["ANNEX_SEA_PACK_PACKAGETYPE"].ToString());

                    ANNEX_SEA_PACK_FROMDESC = dt.Trim(ds.Tables[6].Rows[b]["ANNEX_SEA_PACK_FROMDESC"].ToString());
                    ANNEX_SEA_PACK_TODESC = dt.Trim(ds.Tables[6].Rows[b]["ANNEX_SEA_PACK_TODESC"].ToString());

                    if (COMPANY_ID == "146" || COMPANY_ID == "158" || COMPANY_ID == "7" || COMPANY_ID == "137" || COMPANY_ID == "164" || COMPANY_ID == "165" || COMPANY_ID == "891" || COMPANY_ID == "1107")
                    {
                        ANNEX_SEA_PACK_FROM = ANNEX_SEA_PACK_FROMDESC;
                        ANNEX_SEA_PACK_TO = ANNEX_SEA_PACK_TODESC;
                    }

                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + ANNEX_SEA_PACK_FROM + ch + ANNEX_SEA_PACK_TO + ch + ANNEX_SEA_PACK_PACKAGETYPE);

                    b++;
                }
            }

            if (ROTATION_NO != "")
            {
                sw.WriteLine("<TABLE>ROTATION");
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + ROTATION_DATE + ch + ROTATION_NO);
            }

            if (ds.Tables[7].Rows.Count > 0)
            {
                ANNEX_EXPORTERNAME = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_EXPORTERNAME"].ToString());

                ANNEX_IECCODE = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_IECCODE"].ToString());

                ANNEX_BR_SLNO = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_BR_SLNO"].ToString());

                ANNEX_EXAM_DATE = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_EXAM_DATE"].ToString().Replace("19000101", ""));

                ANNEX_EXAM_OFFICER = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_EXAM_OFFICER"].ToString());

                ANNEX_EXAM_DESIGN = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_EXAM_DESIGN"].ToString());
                ANNEX_SUPER_NAME = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_SUPER_NAME"].ToString());
                ANNEX_SUPER_DESIGN = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_SUPER_DESIGN"].ToString());

                ANNEX_COMMISSION_RATE = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_COMMISSION_RATE"].ToString());
                ANNEX_DIVISION = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_DIVISION"].ToString());
                ANNEX_RANGE = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_RANGE"].ToString());

                ANNEX_VERIFIED_EXAM_OFFICER = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_VERIFIED_EXAM_OFFICER"].ToString());
                ANNEX_SAMPLE_DRAWN = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_SAMPLE_DRAWN"].ToString());
                ANNEX_SEAL_NO = dt.Trim(ds.Tables[7].Rows[0]["ANNEX_SEAL_NO"].ToString());



                ANNEX_EXPORTERNAME = ANNEX_EXPORTERNAME.Length == 1 ? ANNEX_EXPORTERNAME : ANNEX_EXPORTERNAME.TrimEnd('.');
                ANNEX_EXAM_OFFICER = ANNEX_EXAM_OFFICER.Length == 1 ? ANNEX_EXAM_OFFICER : ANNEX_EXAM_OFFICER.TrimEnd('.');
                ANNEX_EXAM_DESIGN = ANNEX_EXAM_DESIGN.Length == 1 ? ANNEX_EXAM_DESIGN : ANNEX_EXAM_DESIGN.TrimEnd('.');
                ANNEX_SUPER_NAME = ANNEX_SUPER_NAME.Length == 1 ? ANNEX_SUPER_NAME : ANNEX_SUPER_NAME.TrimEnd('.');
                ANNEX_SUPER_DESIGN = ANNEX_SUPER_DESIGN.Length == 1 ? ANNEX_SUPER_DESIGN : ANNEX_SUPER_DESIGN.TrimEnd('.');
                ANNEX_COMMISSION_RATE = ANNEX_COMMISSION_RATE.Length == 1 ? ANNEX_COMMISSION_RATE : ANNEX_COMMISSION_RATE.TrimEnd('.');
                ANNEX_DIVISION = ANNEX_DIVISION.Length == 1 ? ANNEX_DIVISION : ANNEX_DIVISION.TrimEnd('.');
                ANNEX_RANGE = ANNEX_RANGE.Length == 1 ? ANNEX_RANGE : ANNEX_RANGE.TrimEnd('.');
                ANNEX_VERIFIED_EXAM_OFFICER = ANNEX_VERIFIED_EXAM_OFFICER.Length == 1 ? ANNEX_VERIFIED_EXAM_OFFICER : ANNEX_VERIFIED_EXAM_OFFICER.TrimEnd('.');
                ANNEX_SEAL_NO = ANNEX_SEAL_NO.Length == 1 ? ANNEX_SEAL_NO : ANNEX_SEAL_NO.TrimEnd('.');


                sw.WriteLine("<TABLE>EOU");
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + ANNEX_IECCODE + ch + ANNEX_BR_SLNO + ch + ANNEX_EXAM_DATE + ch + ANNEX_EXAM_OFFICER + ch + ANNEX_EXAM_DESIGN + ch + ANNEX_SUPER_NAME + ch + ANNEX_SUPER_DESIGN + ch + ANNEX_COMMISSION_RATE + ch + ANNEX_DIVISION + ch + ANNEX_RANGE + ch + ANNEX_SEAL_NO + ch + ANNEX_VERIFIED_EXAM_OFFICER + ch + ANNEX_SAMPLE_DRAWN + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
            }

            int c = 0;
            if (ds.Tables[8].Rows.Count > 0)
            {
                sw.WriteLine("<TABLE>CONTAINER");
                while (ds.Tables[8].Rows.Count > c)
                {
                    ANNEX_SEA_CON_CONTAINERNO = dt.Trim(ds.Tables[8].Rows[c]["ANNEX_SEA_CON_CONTAINERNO"].ToString());

                    ANNEX_SEA_CON_SIZE = dt.Trim(ds.Tables[8].Rows[c]["ANNEX_SEA_CON_SIZE"].ToString());

                    ANNEX_SEA_CON_TYPE = dt.Trim(ds.Tables[8].Rows[c]["ANNEX_SEA_CON_TYPE"].ToString());

                    ANNEX_SEA_CON_EXCISE_SEALNO = dt.Trim(ds.Tables[8].Rows[c]["ANNEX_SEA_CON_EXCISE_SEALNO"].ToString());

                    ANNEX_SEA_CON_SEAL_DATE = dt.Trim(ds.Tables[8].Rows[c]["ANNEX_SEA_CON_SEAL_DATE"].ToString().Replace("19000101", ""));

                    ANNEX_SEA_CON_SEALTYPE_INDICATOR = dt.Trim(ds.Tables[8].Rows[c]["ANNEX_SEA_CON_SEALTYPE_INDICATOR"].ToString());
                    ANNEX_SEA_CON_SEAL_DEVICEID = dt.Trim(ds.Tables[8].Rows[c]["ANNEX_SEA_CON_SEAL_DEVICEID"].ToString());
                    ANNEX_SEA_CON_DOC_TYPE = dt.Trim(ds.Tables[8].Rows[c]["ANNEX_SEA_CON_DOC_TYPE"].ToString());
                    ANNEX_SEA_CON_DOC_NUMBER = dt.Trim(ds.Tables[8].Rows[c]["ANNEX_SEA_CON_DOC_NUMBER"].ToString());

                    //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + ANNEX_SEA_CON_CONTAINERNO + ch + ANNEX_SEA_CON_SIZE + ch + ANNEX_SEA_CON_EXCISE_SEALNO + ch + ANNEX_SEA_CON_SEAL_DATE);
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + ANNEX_SEA_CON_CONTAINERNO + ch + ANNEX_SEA_CON_SIZE + ch + ANNEX_SEA_CON_EXCISE_SEALNO + ch + ANNEX_SEA_CON_SEAL_DATE + ch + ANNEX_SEA_CON_SEALTYPE_INDICATOR + ch + ANNEX_SEA_CON_SEAL_DEVICEID + ch + ANNEX_SEA_CON_DOC_TYPE + ch + ANNEX_SEA_CON_DOC_NUMBER);

                    c++;
                }
            }

            int d = 0;
            DataView str_view = ds.Tables[2].DefaultView;
            str_view.RowFilter = "NOT ITEM_STR_CODE = '' ";
            DataTable str_table = str_view.ToTable();

            if (str_table.Rows.Count > 0)
            {
                sw.WriteLine("<TABLE>STR");
                while (str_table.Rows.Count > d)
                {
                    INVOICE_SLNO = dt.Trim(str_table.Rows[d]["INVOICE_SLNO"].ToString());

                    ITEM_SLNO = dt.Trim(str_table.Rows[d]["ITEM_SLNO"].ToString());

                    ITEM_STR_CODE = dt.Trim(str_table.Rows[d]["ITEM_STR_CODE"].ToString());

                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SRNO + ch + ITEM_STR_CODE + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

                    d++;
                }
            }

            //------------------------------For Single Window Implementaion on 19Jun2017---------------------------//
            DataView sw_type = ds.Tables[14].DefaultView;

            sw_type = ds.Tables[14].DefaultView;
            //sw_type.RowFilter = "INFO_TYPE = '" + COUNTRY_OF_ORIGIN + "'";
            sw_type.RowFilter = "Isnull(INFO_TYPE,'') <> ''";

            DataSet ds_type = new DataSet();
            ds_type.Tables.Add(sw_type.ToTable());
            DataTable dtRodtep = ds.Tables[22];

            if (ds_type.Tables[0].Rows.Count > 0)
            {
                int sws_type = 0;
                int sws_SLNO = 1;

                sw.WriteLine("<TABLE>SW_INFO_TYPE");
                while (ds_type.Tables[0].Rows.Count > sws_type)
                {
                    INFO_TYPE = "";
                    INVOICE_SLNO = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INVOICE_SLNO"].ToString());
                    ITEM_SLNO = dt.Trim(ds_type.Tables[0].Rows[sws_type]["ITEM_SLNO"].ToString());

                    INFO_TYPE = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_TYPE"].ToString());
                    INFO_QUALIFIER = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_QUALIFIER"].ToString());

                    if (ds_type.Tables[0].Rows[sws_type]["INFO_CODE"].ToString().Contains("-"))
                    {
                        string[] code = ds_type.Tables[0].Rows[sws_type]["INFO_CODE"].ToString().Split('-');

                        INFO_CODE = dt.Trim(code[0]).ToUpper();
                    }
                    else
                    {
                        INFO_CODE = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_CODE"].ToString()).ToUpper();
                    }
                    INFO_TEXT = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_TEXT"].ToString());

                    // INFO_MSR & INFO_UQC - Table22 first, fallback Table14 Added  by pandiyan on 25-05-2026 due to qty taken from Rodtep table
                    if (INFO_CODE == "RODTEPY" && INFO_QUALIFIER == "RDT")
                    {
                        DataRow[] rodtepRows = dtRodtep.Select(
                            "INVOICE_SLNO = '" + INVOICE_SLNO + "' AND ITEM_SLNO = '" + ITEM_SLNO + "'"
                        );

                        if (rodtepRows.Length > 0)
                        {
                            INFO_MSR = dt.Trim(rodtepRows[0]["ITEM_QTY"].ToString());
                            INFO_UQC = dt.Trim(rodtepRows[0]["ITEM_QTY_CODE"].ToString()).ToUpper();
                        }
                        else
                        {
                            INFO_MSR = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_MSR"].ToString());
                            INFO_UQC = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_UQC"].ToString()).ToUpper();
                        }
                    }
                    else
                    {
                        INFO_MSR = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_MSR"].ToString());
                        INFO_UQC = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_UQC"].ToString()).ToUpper();
                    }

                    if (sws_SLNO > 9999)
                    {
                        sws_SLNO = 1;
                    }

                    //INFO_SERIAL_NO = dt.Trim(ds_type.Tables[0].Rows[sws_type]["SLNO"].ToString());
                    INFO_SERIAL_NO = Convert.ToString(sws_SLNO);



                    //if (INFO_TYPE != "")
                    //{
                    //    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_SERIAL_NO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                    //}

                    //if (RODTEP == "Y")
                    //{
                    //    if (INFO_QUALIFIER == "RDT")
                    //    {
                    //        if (INFO_CODE == "RODTEPY")
                    //        {
                    //            INFO_TEXT = "Claimed";
                    //        }
                    //        else
                    //        {
                    //            INFO_TEXT = "Not Claimed";
                    //        }
                    //    }
                    //}

                    if (RODTEP == "Y")
                    {
                        if (INFO_CODE == "RODTEPY")
                        {
                            INFO_TEXT = "CLAIMED";
                        }
                        else if (INFO_CODE == "RODTEPN")
                        {
                            INFO_TEXT = "NOT CLAIMED";
                        }
                    }
                    else
                    {
                        if (INFO_CODE == "RODTEPN")
                        {
                            INFO_TEXT = "NOT CLAIMED";
                        }
                        else if (INFO_CODE == "RODTEPY")
                        {
                            INFO_TEXT = "CLAIMED";
                        }
                    }

                    INFO_TEXT = INFO_TEXT.Length == 1 ? INFO_TEXT : INFO_TEXT.TrimEnd('.');

                    if (INFO_TYPE != "")
                    {
                        if (INFO_QUALIFIER == "EPT" && SB_TYPE == "SEZ" && NFEI == "Yes" && NFEI_TYPE == "09")
                        {
                        }
                        else if (INFO_QUALIFIER != "GCESS")
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_SERIAL_NO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                            sws_SLNO++;
                        }
                        //else if (INFO_QUALIFIER == "GCESS" && (INFO_MSR != "" && INFO_MSR != "0"))
                        else if (INFO_QUALIFIER == "GCESS" && (INFO_MSR != ""))
                        {
                            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_SERIAL_NO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
                            sws_SLNO++;
                        }
                    }

                    sws_type++;

                }
            }

            DataView sw_const = ds.Tables[15].DefaultView;
            sw_const = ds.Tables[15].DefaultView;
            //sw_type.RowFilter = "INFO_TYPE = '" + COUNTRY_OF_ORIGIN + "'";
            sw_const.RowFilter = "Isnull(CONSTITUENT_SRNO,'') <> ''";

            DataSet ds_const = new DataSet();
            ds_const.Tables.Add(sw_const.ToTable());

            if (ds_const.Tables[0].Rows.Count > 0)
            {
                int sws_const = 0;
                sw.WriteLine("<TABLE>SW_CONST");
                while (ds_const.Tables[0].Rows.Count > sws_const)
                {
                    CONSTITUENT_SRNO = "";

                    INVOICE_SLNO = dt.Trim(ds_const.Tables[0].Rows[sws_const]["INVOICE_SLNO"].ToString());
                    ITEM_SLNO = dt.Trim(ds_const.Tables[0].Rows[sws_const]["ITEM_SLNO"].ToString());

                    CONSTITUENT_SRNO = dt.Trim(ds_const.Tables[0].Rows[sws_const]["CONSTITUENT_SRNO"].ToString());
                    CONSTITUENT_ELEMENT_NAME = dt.Trim(ds_const.Tables[0].Rows[sws_const]["CONSTITUENT_ELEMENT_NAME"].ToString());
                    CONSTITUENT_ELEMENT_CODE = dt.Trim(ds_const.Tables[0].Rows[sws_const]["CONSTITUENT_ELEMENT_CODE"].ToString());

                    CONSTITUENT_PERCENTAGE = dt.Trim(ds_const.Tables[0].Rows[sws_const]["CONSTITUENT_PERCENTAGE"].ToString());
                    CONSTITUENT_YIELD_PERCENTAGE = dt.Trim(ds_const.Tables[0].Rows[sws_const]["CONSTITUENT_YIELD_PERCENTAGE"].ToString());
                    ACTIVE_INGREDIENT = dt.Trim(ds_const.Tables[0].Rows[sws_const]["ACTIVE_INGREDIENT"].ToString());

                    CONSTITUENT_SERIAL_NO = dt.Trim(ds_const.Tables[0].Rows[sws_const]["SLNO"].ToString());

                    CONSTITUENT_ELEMENT_NAME = CONSTITUENT_ELEMENT_NAME.Length == 1 ? CONSTITUENT_ELEMENT_NAME : CONSTITUENT_ELEMENT_NAME.TrimEnd('.');
                    CONSTITUENT_ELEMENT_CODE = CONSTITUENT_ELEMENT_CODE.Length == 1 ? CONSTITUENT_ELEMENT_CODE : CONSTITUENT_ELEMENT_CODE.TrimEnd('.');


                    if (CONSTITUENT_SRNO != "")
                    {
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CONSTITUENT_SERIAL_NO + ch + CONSTITUENT_ELEMENT_NAME + ch + CONSTITUENT_ELEMENT_CODE + ch + CONSTITUENT_PERCENTAGE + ch + CONSTITUENT_YIELD_PERCENTAGE + ch + ACTIVE_INGREDIENT);
                    }
                    sws_const++;
                }
            }



            DataView sw_prod = ds.Tables[16].DefaultView;

            sw_prod = ds.Tables[16].DefaultView;
            //sw_type.RowFilter = "INFO_TYPE = '" + COUNTRY_OF_ORIGIN + "'";
            sw_prod.RowFilter = "Isnull(PRODUCTION_BATCH_IDENTIFIER,'') <> ''";

            DataSet ds_prod = new DataSet();
            ds_prod.Tables.Add(sw_prod.ToTable());

            if (ds_prod.Tables[0].Rows.Count > 0)
            {
                int sws_prod = 0;
                sw.WriteLine("<TABLE>SW_PROD");
                while (ds_prod.Tables[0].Rows.Count > sws_prod)
                {
                    PRODUCTION_BATCH_IDENTIFIER = "";
                    INVOICE_SLNO = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["INVOICE_SLNO"].ToString());
                    ITEM_SLNO = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["ITEM_SLNO"].ToString());
                    PRODUCTION_BATCH_IDENTIFIER = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["PRODUCTION_BATCH_IDENTIFIER"].ToString());

                    PRODUCTION_BATCH_QUANTITY = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["PRODUCTION_BATCH_QUANTITY"].ToString());
                    UNIT_QTY_CODE = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["UNIT_QTY_CODE"].ToString());
                    DATE_OF_MANUFACTURING = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["DATE_OF_MANUFACTURING"].ToString().Replace("19000101", ""));
                    DATE_OF_EXPIRY = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["DATE_OF_EXPIRY"].ToString().Replace("19000101", ""));
                    BEST_BEFORE = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["BEST_BEFORE"].ToString().Replace("19000101", ""));

                    PRODUCTION_SERIAL_NO = dt.Trim(ds_prod.Tables[0].Rows[sws_prod]["SLNO"].ToString());

                    if (PRODUCTION_BATCH_IDENTIFIER != "")
                    {

                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + PRODUCTION_SERIAL_NO + ch + PRODUCTION_BATCH_IDENTIFIER + ch + PRODUCTION_BATCH_QUANTITY + ch + UNIT_QTY_CODE + ch + DATE_OF_MANUFACTURING + ch + DATE_OF_EXPIRY + ch + BEST_BEFORE);
                    }
                    sws_prod++;
                }
            }



            DataView sw_ctrl = ds.Tables[17].DefaultView;

            sw_ctrl = ds.Tables[17].DefaultView;

            sw_ctrl.RowFilter = "Isnull(CONTROL_TYPE_CODE,'') <> '' or Isnull(CONTROL_RESULT_CODE,'') <> ''";

            DataSet ds_ctrl = new DataSet();
            ds_ctrl.Tables.Add(sw_ctrl.ToTable());

            if (ds_ctrl.Tables[0].Rows.Count > 0)
            {
                int sws_ctrl = 0;
                sw.WriteLine("<TABLE>SW_CTRL");
                while (ds_ctrl.Tables[0].Rows.Count > sws_ctrl)
                {
                    CONTROL_TYPE_CODE = "";
                    INVOICE_SLNO = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["INVOICE_SLNO"].ToString());
                    ITEM_SLNO = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["ITEM_SLNO"].ToString());

                    CONTROL_TYPE_CODE = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["CONTROL_TYPE_CODE"].ToString());
                    CONTROL_LOCATION = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["CONTROL_LOCATION"].ToString());
                    CONTROL_START_DATE = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["CONTROL_START_DATE"].ToString().Replace("19000101", ""));
                    CONTROL_END_DATE = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["CONTROL_END_DATE"].ToString().Replace("19000101", ""));

                    CONTROL_RESULT_CODE = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["CONTROL_RESULT_CODE"].ToString());
                    CONTROL_RESULT_TEXT = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["CONTROL_RESULT_TEXT"].ToString());

                    CONTROL_SERIAL_NO = dt.Trim(ds_ctrl.Tables[0].Rows[sws_ctrl]["SLNO"].ToString());

                    if (CONTROL_TYPE_CODE != "DUC")
                    {
                        INVOICE_SLNO = "0";
                        ITEM_SLNO = "0";
                    }

                    CONTROL_LOCATION = CONTROL_LOCATION.Length == 1 ? CONTROL_LOCATION : CONTROL_LOCATION.TrimEnd('.');
                    CONTROL_RESULT_TEXT = CONTROL_RESULT_TEXT.Length == 1 ? CONTROL_RESULT_TEXT : CONTROL_RESULT_TEXT.TrimEnd('.');


                    if (CONTROL_TYPE_CODE != "" || CONTROL_RESULT_CODE != "")
                    {
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CONTROL_SERIAL_NO + ch + CONTROL_TYPE_CODE + ch + CONTROL_LOCATION + ch + CONTROL_START_DATE + ch + CONTROL_END_DATE + ch + CONTROL_RESULT_CODE + ch + CONTROL_RESULT_TEXT);
                    }

                    sws_ctrl++;
                }
            }


            DataView sw_stmt = ds.Tables[18].DefaultView;

            sw_stmt = ds.Tables[18].DefaultView;
            //sw_type.RowFilter = "INFO_TYPE = '" + COUNTRY_OF_ORIGIN + "'";
            sw_stmt.RowFilter = "Isnull(STMT_TYPE,'') <> ''";

            DataSet ds_stmt = new DataSet();
            ds_stmt.Tables.Add(sw_stmt.ToTable());

            if (ds_stmt.Tables[0].Rows.Count > 0)
            {
                int sws_stmt = 0;
                sw.WriteLine("<TABLE>STATEMENT");
                while (ds_stmt.Tables[0].Rows.Count > sws_stmt)
                {
                    STMT_TYPE = "";
                    INVOICE_SLNO = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["INVOICE_SLNO"].ToString());
                    ITEM_SLNO = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["ITEM_SLNO"].ToString());

                    //STMT_DECLARATION_TYPE = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_DECLARATION_TYPE"].ToString());
                    //STMT_DECLARATION_NUMBER = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_DECLARATION_NUMBER"].ToString());
                    //STMT_DECLARATION_DATE = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_DECLARATION_DATE"].ToString().Replace("19000101", ""));

                    STMT_TYPE = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_TYPE"].ToString());
                    STMT_CODE = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_CODE"].ToString());
                    STMT_TEXT = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_TEXT"].ToString().Replace("\r\n", " "));

                    STMT_SERIAL_NO = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["SLNO"].ToString());

                    //STMT_TEXT = "";
                    STMT_DECLARATION_TYPE = "B";
                    STMT_TEXT = STMT_TEXT.Length == 1 ? STMT_TEXT : STMT_TEXT.TrimEnd('.');


                    if (STMT_TYPE != "")
                    {

                        //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + STMT_DECLARATION_TYPE + ch + STMT_DECLARATION_NUMBER + ch + STMT_DECLARATION_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + STMT_TYPE + ch + STMT_CODE + ch + STMT_TEXT);
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + STMT_SERIAL_NO + ch + STMT_TYPE + ch + STMT_CODE + ch + STMT_TEXT);
                    }

                    sws_stmt++;
                }
            }


            DataView sw_supp = ds.Tables[19].DefaultView;

            sw_supp = ds.Tables[19].DefaultView;
            //sw_type.RowFilter = "INFO_TYPE = '" + COUNTRY_OF_ORIGIN + "'";
            sw_supp.RowFilter = "Isnull(UNIQUE_DOC_NUMBER,'') <> ''";

            DataSet ds_supp = new DataSet();
            ds_supp.Tables.Add(sw_supp.ToTable());

            if (ds_supp.Tables[0].Rows.Count > 0)
            {
                int sws_supp = 0;
                //sw.WriteLine("<TABLE>SUPPORTING_DOCS");
                sw.WriteLine("<TABLE>Supportingdocs");
                int SERIAL_NO = 1;
                while (ds_supp.Tables[0].Rows.Count > sws_supp)
                {
                    UNIQUE_DOC_NUMBER = "";

                    /* -- hide by Chithra on 08-12-2022 for PADHAMJI KANJI - checked with Final Print . sugg.Bala sir
                    INVOICE_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["INVOICE_SLNO"].ToString());
                    ITEM_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["ITEM_SLNO"].ToString()); 
                    */


                    if (dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["SELECT_TYPE"].ToString()) == "JOB")
                    {
                        INVOICE_SLNO = "0";
                        ITEM_SLNO = "0";
                    }
                    else if (dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["SELECT_TYPE"].ToString()) == "INVOICE")
                    {
                        INVOICE_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["INVOICE_SLNO"].ToString());
                        ITEM_SLNO = "0";
                    }
                    else if (dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["SELECT_TYPE"].ToString()) == "ITEM")
                    {
                        INVOICE_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["INVOICE_SLNO"].ToString());
                        ITEM_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["ITEM_SLNO"].ToString());
                    }
                    else
                    {
                        INVOICE_SLNO = "0";
                        ITEM_SLNO = "0";
                    }



                    UNIQUE_DOC_NUMBER = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["UNIQUE_DOC_NUMBER"].ToString());
                    DOC_TYPE_CODE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_TYPE_CODE"].ToString());
                    DOC_ISSUING_PARTY_CODE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_CODE"].ToString());
                    DOC_ISSUING_PARTY_NAME_ADD1 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString());
                    DOC_ISSUING_PARTY_NAME_ADD2 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString());

                    DOC_ISSUING_PARTY_CITY = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_CITY"].ToString());
                    DOC_ISSUING_PARTY_PIN = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_PIN"].ToString());
                    DOC_REF_NUMBER = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_REF_NUMBER"].ToString());
                    PLACE_OF_ISSUE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["PLACE_OF_ISSUE"].ToString());
                    DOC_ISSUE_DATE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUE_DATE"].ToString().Replace("19000101", ""));
                    DOC_EXPIRY_DATE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_EXPIRY_DATE"].ToString().Replace("19000101", ""));
                    BENEFICIARY_PARTY_CODE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_CODE"].ToString());

                    BENEFICIARY_PARTY_ADDRESS1 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_ADDRESS1"].ToString());
                    BENEFICIARY_PARTY_ADDRESS2 = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_ADDRESS2"].ToString());
                    BENEFICIARY_PARTY_CITY = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_CITY"].ToString());
                    BENEFICIARY_PARTY_PIN = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_PIN"].ToString());
                    FILE_TYPE = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["FILE_TYPE"].ToString());

                    SUP_DOC_SERIAL_NO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["SLNO"].ToString());

                    DOC_ISSUING_PARTY_NAME = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["DOC_ISSUING_PARTY_NAME"].ToString());
                    BENEFICIARY_PARTY_NAME = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["BENEFICIARY_PARTY_NAME"].ToString());
                    SUPDOC_ICEGATE_ID = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["ICEGATE_ID"].ToString());



                    if (Connection.COMPANYID() == "1014")
                    {
                        SUPDOC_ICEGATE_ID = "";
                    }

                    if (SUPDOC_ICEGATE_ID == "")
                    {
                        SUPDOC_ICEGATE_ID = ICEGATE_ID;
                    }

                    UNIQUE_DOC_NUMBER = UNIQUE_DOC_NUMBER.Length == 1 ? UNIQUE_DOC_NUMBER : UNIQUE_DOC_NUMBER.TrimEnd('.');
                    DOC_ISSUING_PARTY_CODE = DOC_ISSUING_PARTY_CODE.Length == 1 ? DOC_ISSUING_PARTY_CODE : DOC_ISSUING_PARTY_CODE.TrimEnd('.');
                    DOC_ISSUING_PARTY_NAME = DOC_ISSUING_PARTY_NAME.Length == 1 ? DOC_ISSUING_PARTY_NAME : DOC_ISSUING_PARTY_NAME.TrimEnd('.');
                    DOC_ISSUING_PARTY_NAME_ADD1 = DOC_ISSUING_PARTY_NAME_ADD1.Length == 1 ? DOC_ISSUING_PARTY_NAME_ADD1 : DOC_ISSUING_PARTY_NAME_ADD1.TrimEnd('.');
                    DOC_ISSUING_PARTY_NAME_ADD2 = DOC_ISSUING_PARTY_NAME_ADD2.Length == 1 ? DOC_ISSUING_PARTY_NAME_ADD2 : DOC_ISSUING_PARTY_NAME_ADD2.TrimEnd('.');
                    DOC_ISSUING_PARTY_CITY = DOC_ISSUING_PARTY_CITY.Length == 1 ? DOC_ISSUING_PARTY_CITY : DOC_ISSUING_PARTY_CITY.TrimEnd('.');
                    DOC_ISSUING_PARTY_PIN = DOC_ISSUING_PARTY_PIN.Length == 1 ? DOC_ISSUING_PARTY_PIN : DOC_ISSUING_PARTY_PIN.TrimEnd('.');
                    DOC_REF_NUMBER = DOC_REF_NUMBER.Length == 1 ? DOC_REF_NUMBER : DOC_REF_NUMBER.TrimEnd('.');
                    PLACE_OF_ISSUE = PLACE_OF_ISSUE.Length == 1 ? PLACE_OF_ISSUE : PLACE_OF_ISSUE.TrimEnd('.');
                    BENEFICIARY_PARTY_CODE = BENEFICIARY_PARTY_CODE.Length == 1 ? BENEFICIARY_PARTY_CODE : BENEFICIARY_PARTY_CODE.TrimEnd('.');
                    BENEFICIARY_PARTY_NAME = BENEFICIARY_PARTY_NAME.Length == 1 ? BENEFICIARY_PARTY_NAME : BENEFICIARY_PARTY_NAME.TrimEnd('.');
                    BENEFICIARY_PARTY_ADDRESS1 = BENEFICIARY_PARTY_ADDRESS1.Length == 1 ? BENEFICIARY_PARTY_ADDRESS1 : BENEFICIARY_PARTY_ADDRESS1.TrimEnd('.');
                    BENEFICIARY_PARTY_ADDRESS2 = BENEFICIARY_PARTY_ADDRESS2.Length == 1 ? BENEFICIARY_PARTY_ADDRESS2 : BENEFICIARY_PARTY_ADDRESS2.TrimEnd('.');
                    BENEFICIARY_PARTY_CITY = BENEFICIARY_PARTY_CITY.Length == 1 ? BENEFICIARY_PARTY_CITY : BENEFICIARY_PARTY_CITY.TrimEnd('.');
                    BENEFICIARY_PARTY_PIN = BENEFICIARY_PARTY_PIN.Length == 1 ? BENEFICIARY_PARTY_PIN : BENEFICIARY_PARTY_PIN.TrimEnd('.');
                    SUPDOC_ICEGATE_ID = SUPDOC_ICEGATE_ID.Length == 1 ? SUPDOC_ICEGATE_ID : SUPDOC_ICEGATE_ID.TrimEnd('.');
                    FILE_TYPE = FILE_TYPE.Length == 1 ? FILE_TYPE : FILE_TYPE.TrimEnd('.');

                    if (UNIQUE_DOC_NUMBER != "")
                    {
                        if (ICEGATE_ID.Length > 15)
                        {
                            ICEGATE_ID = ICEGATE_ID.Substring(0, 15);
                        }
                        //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SUP_DOC_SERIAL_NO + ch + UNIQUE_DOC_NUMBER + ch + DOC_TYPE_CODE + ch + DOC_ISSUING_PARTY_CODE + ch + DOC_ISSUING_PARTY_NAME_ADD1 + ch + DOC_ISSUING_PARTY_NAME_ADD2 + ch + DOC_ISSUING_PARTY_CITY + ch + DOC_ISSUING_PARTY_PIN + ch + DOC_REF_NUMBER + ch + PLACE_OF_ISSUE + ch + DOC_ISSUE_DATE + ch + DOC_EXPIRY_DATE + ch + BENEFICIARY_PARTY_CODE + ch + BENEFICIARY_PARTY_ADDRESS1 + ch + BENEFICIARY_PARTY_ADDRESS2 + ch + BENEFICIARY_PARTY_CITY + ch + BENEFICIARY_PARTY_PIN + ch + FILE_TYPE);
                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SERIAL_NO + ch + UNIQUE_DOC_NUMBER + ch + DOC_TYPE_CODE + ch + DOC_ISSUING_PARTY_CODE + ch + DOC_ISSUING_PARTY_NAME_ADD1 + ch + DOC_ISSUING_PARTY_NAME_ADD2 + ch + DOC_ISSUING_PARTY_CITY + ch + DOC_ISSUING_PARTY_PIN + ch + DOC_REF_NUMBER + ch + PLACE_OF_ISSUE + ch + DOC_ISSUE_DATE + ch + DOC_EXPIRY_DATE + ch + BENEFICIARY_PARTY_CODE + ch + BENEFICIARY_PARTY_ADDRESS1 + ch + BENEFICIARY_PARTY_ADDRESS2 + ch + BENEFICIARY_PARTY_CITY + ch + BENEFICIARY_PARTY_PIN + ch + FILE_TYPE + ch + DOC_ISSUING_PARTY_NAME + ch + BENEFICIARY_PARTY_NAME + ch + SUPDOC_ICEGATE_ID);
                    }

                    sws_supp++;
                    SERIAL_NO++;
                }
            }

            //------------------------------For Single Window Implementaion on 19Jun2017---------------------------//

            //----------Start Re-Export------------------//

            int re = 0;
            if (ds.Tables[20].Rows.Count > 0)
            {
                sw.WriteLine("<TABLE>REEXPORT");
                while (ds.Tables[20].Rows.Count > re)
                {
                    INVOICE_SLNO = dt.Trim(ds.Tables[20].Rows[re]["INVOICE_SLNO"].ToString());
                    ITEM_SLNO = dt.Trim(ds.Tables[20].Rows[re]["ITEM_SLNO"].ToString());
                    SB_NO = dt.Trim(ds.Tables[20].Rows[re]["SB_NO"].ToString());
                    SB_DATE = dt.Trim(ds.Tables[20].Rows[re]["SB_DATE"].ToString().Replace("19000101", ""));
                    SLNO = dt.Trim(ds.Tables[20].Rows[re]["SLNO"].ToString());
                    BE_SITE = dt.Trim(ds.Tables[20].Rows[re]["BE_SITE"].ToString());
                    BE_NO = dt.Trim(ds.Tables[20].Rows[re]["BE_NO"].ToString());
                    BE_DATE = dt.Trim(ds.Tables[20].Rows[re]["BE_DATE"].ToString().Replace("19000101", ""));
                    BE_INVOICE_NO = dt.Trim(ds.Tables[20].Rows[re]["BE_INVOICE_NO"].ToString());
                    BE_INVOICE_ITEM_NO = dt.Trim(ds.Tables[20].Rows[re]["BE_INVOICE_ITEM_NO"].ToString());
                    MANUAL_BE_Y_N = dt.Trim(ds.Tables[20].Rows[re]["MANUAL_BE_Y_N"].ToString());
                    BE_QTY_UTILISED = dt.Trim(ds.Tables[20].Rows[re]["BE_QTY_UTILISED"].ToString());
                    BE_ITEM_DESC = dt.Trim(ds.Tables[20].Rows[re]["BE_ITEM_DESC"].ToString());
                    BE_QTY = dt.Trim(ds.Tables[20].Rows[re]["BE_QTY"].ToString());
                    BE_UQC = dt.Trim(ds.Tables[20].Rows[re]["BE_UQC"].ToString());
                    BE_ASS_VALUE = dt.Trim(ds.Tables[20].Rows[re]["BE_ASS_VALUE"].ToString());
                    BE_DUTY_PAID = dt.Trim(ds.Tables[20].Rows[re]["BE_DUTY_PAID"].ToString());
                    BE_DUTY_PAYMENT_DATE = dt.Trim(ds.Tables[20].Rows[re]["BE_DUTY_PAYMENT_DATE"].ToString().Replace("19000101", ""));

                    BE_OTH_IDENTIFIABLE_PARAMETER = dt.Trim(ds.Tables[20].Rows[re]["BE_OTH_IDENTIFIABLE_PARAMETER"].ToString());
                    BE_ASS_VALUE_CLAIM = dt.Trim(ds.Tables[20].Rows[re]["BE_ASS_VALUE_CLAIM"].ToString());
                    BE_ITEM_USED_Y_N = dt.Trim(ds.Tables[20].Rows[re]["BE_ITEM_USED_Y_N"].ToString());
                    COMMISIONER_PERMISSION_Y_N = dt.Trim(ds.Tables[20].Rows[re]["COMMISIONER_PERMISSION_Y_N"].ToString());
                    INPUT_CREDIT_Y_N = dt.Trim(ds.Tables[20].Rows[re]["INPUT_CREDIT_Y_N"].ToString());
                    PERSONAL_USED_Y_N = dt.Trim(ds.Tables[20].Rows[re]["PERSONAL_USED_Y_N"].ToString());
                    MODVAT_AVAILED_Y_N = dt.Trim(ds.Tables[20].Rows[re]["MODVAT_AVAILED_Y_N"].ToString());
                    MODVAT_REPAID_Y_N = dt.Trim(ds.Tables[20].Rows[re]["MODVAT_REPAID_Y_N"].ToString());

                    BE_ITEM_DESC = BE_ITEM_DESC.Length == 1 ? BE_ITEM_DESC : BE_ITEM_DESC.TrimEnd('.');
                    BE_UQC = BE_UQC.Length == 1 ? BE_UQC : BE_UQC.TrimEnd('.');
                    BE_OTH_IDENTIFIABLE_PARAMETER = BE_OTH_IDENTIFIABLE_PARAMETER.Length == 1 ? BE_OTH_IDENTIFIABLE_PARAMETER : BE_OTH_IDENTIFIABLE_PARAMETER.TrimEnd('.');


                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + JOBNO + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SLNO + ch + BE_SITE + ch + BE_NO + ch + BE_DATE + ch + BE_INVOICE_NO + ch + BE_INVOICE_ITEM_NO + ch + MANUAL_BE_Y_N + ch + BE_QTY_UTILISED + ch + BE_ITEM_DESC + ch + BE_QTY + ch + BE_UQC + ch + BE_ASS_VALUE + ch + BE_DUTY_PAID + ch + BE_DUTY_PAYMENT_DATE + ch + BE_OTH_IDENTIFIABLE_PARAMETER + ch + BE_ASS_VALUE_CLAIM + ch + BE_ITEM_USED_Y_N + ch + COMMISIONER_PERMISSION_Y_N + ch + INPUT_CREDIT_Y_N + ch + PERSONAL_USED_Y_N + ch + MODVAT_AVAILED_Y_N + ch + MODVAT_REPAID_Y_N);
                    re++;
                }
            }

            //----------End Re-Export------------------//


            sw.WriteLine("<END-SB>");
            TextBox txt = new TextBox();
            sw.WriteLine("TREC" + ch + JOBNO + DDMMYY_JOBDATE);

            sw.Flush();
            sw.Close();
            sw.Dispose();
            //sw = null;



            //Query Reply flatfile auto save to Job History folder also for Agility by Chitha
            if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "747")
            {
                DataSet ds_jb_hstry = new DataSet();

                if (File.Exists(errorFolder + logFileName))
                {
                    DirectoryInfo dir = new DirectoryInfo(errorFolder);

                    if (Directory.Exists(targetPath) == false)
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    string sourceFile = System.IO.Path.Combine(errorFolder, logFileName);
                    string destFile = System.IO.Path.Combine(targetPath, JOBNO + " ~~" + logFileName);

                    System.IO.File.Copy(sourceFile, destFile, true);


                    Job_Histroy jh = new Job_Histroy();

                    jh.JOB_ID = "";
                    jh.JOB_TYPE = "EXP";
                    jh.JOBNO = JOBNO;
                    jh.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
                    jh.DESCRIPTION = targetPath;
                    jh.ATTACHMENT_FILE = JOBNO + " ~~" + logFileName;
                    jh.FLAG = "Upload_File";
                    jh.USER_ID = currentuser;
                    jh.JOBDATE = "01/01/1900";

                    jh.BRANCH_CODE = currentbranch;
                    jh.YEAR = "";
                    jh.WORKING_PERIOD = Working_Period;
                    jh.BRANCH_COMMON = SELECT_BRANCH;
                    ds_jb_hstry = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();

                }
                else
                {
                    Console.WriteLine("Source path does not exist!");
                }
            }

            if (IS_Imgbtn == "1")
            {
                Response.Write(sw.ToString());
                Response.Flush();
                // Response.End();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            DSC_Flatfile_Sent_Check();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    public void mail(string filenm)
    {


        //if (ICEGATE_EMAIL_ID != "" && ICEGATE_EMAIL_PWD != "")
        //{
        EMail_ID = CUSTOMS_HOUSE + "@icegate.gov.in";

        //EMail_ID = "admin@royaltechsystems.co.in";

        //CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();
        //ICEGATE_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
        //ICEGATE_EMAIL_ID = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
        //ICEGATE_EMAIL_PWD = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();

        //ICEGATE_EMAIL_ID_NEW.Value = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
        //ICEGATE_EMAIL_PWD_NEW.Value = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();

        SmtpClient client = new SmtpClient();

        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //---------------------------------------------
        //client.EnableSsl = true;

        //client.Host = "smtp.gmail.com";

        //client.Port = 587;
        //----------------------------------

        //--------------Live Configuration-----------------//
        if (COMPANY_ID == "116")
        {
            client.Host = "smtp.gmail.com";//For Boxco Logistics Server
            client.Port = 25;
            client.EnableSsl = true;
        }
        else
        {
            client.Host = "smtp.mail.yahoo.com";//For ERoyal Server
            client.Port = 587;
            client.EnableSsl = true;
        }

        //--------------Live Configuration-----------------//


        //client.Host = "127.0.0.1";//For Royal Tech Server

        //client.Host = "11.0.0.3";//For Boxco Logistics Server

        //----------------------------------
        //client.Port = 25;
        //client.EnableSsl = false;
        //----------------------------------
        // setup Smtp authentication

        //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("sathishkumar8789@gmail.com", "skoushik");
        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ICEGATE_EMAIL_ID, ICEGATE_EMAIL_PWD);
        //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("orientalmaa@gmail.com", "oriental123");

        //client.UseDefaultCredentials = false;
        client.UseDefaultCredentials = true;

        client.Credentials = credentials;

        MailMessage msg = new MailMessage();

        //msg.From = new MailAddress("sathishkumar8789@gmail.com");
        //msg.From = new MailAddress("orientalmaa@gmail.com");
        msg.From = new MailAddress(ICEGATE_EMAIL_ID);

        //msg.To.Add(new MailAddress("admin@royaltechsystems.co.in"));
        //msg.To.Add(new MailAddress("balaji71187@gmail.com"));
        msg.To.Add(new MailAddress(EMail_ID));

        msg.CC.Add(new MailAddress(ICEGATE_EMAIL_ID));

        if (COMPANY_ID == "146")
        {
            msg.Bcc.Add(new MailAddress("edi@bwclogistics.com"));
        }
        else
        {

        }

        msg.Subject = ICEGATE_ID + "-" + ddlJobNo.SelectedValue.ToString() + "(" + "SB" + ")";
        //msg.Subject = "SB";

        msg.IsBodyHtml = true;

        //msg.Body = string.Format("<html><head></head><body><b>Flat File</b></body>");
        msg.Body = string.Format("<html><head></head><body><b></b></body>");

       msg.Attachments.Add(new System.Net.Mail.Attachment(filenm));

        try
        {

            client.Send(msg);

            if (msg.DeliveryNotificationOptions.ToString() == "Failure sending mail.")
            {
                Alert_msg("Failure sending mail!");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Failure sending mail!')</script>", false);
                msg.Dispose();

            }
            else
            {


                Alert_msg("Auto submitted");

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Auto submitted')</script>", false);
                msg.Dispose();
            }
            //lblMsg.Text = "Your message has been successfully sent.";
        }

        catch (Exception ex)
        {
            //lblMsg.ForeColor = Color.Red;

            string messege = "Error occured while sending your message." + ex.Message;
            //lblMsg.Text = "Error occured while sending your message." + ex.Message;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('" + messege + "')</script>", false);
            Alert_msg(messege);

            msg.Dispose();

        }
        // }
        // else
        //Alert_msg("IceGate Email-Id & Password cannot be Empty");


    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SUBMISSION', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg_json(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SUBMISSION', function (r) {{}}, 20000);}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SUBMISSION', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    [System.Web.Services.WebMethod]
    public static string Get_Import_Details(string custid)
    {
        string Working_Period = "", txtCustomHouse = "", txtExporterName = "", txtScheme = "", txtConsignee = "", txtNoofItems = "",
               txtNoofInvoices = "", Annexure_Mode = "", STR_Code = "", select_branch = "", Flatfile_Generate = "", txt_icegate_Id = "", SBType = "";


        try
        {
            Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
                // commented for areawise implementation on 05-mar-2020
        /*
            select_branch = HttpContext.Current.Session["currentbranch"].ToString();
            select_type_ = HttpContext.Current.Session["SELECT_TYPE"].ToString();

            if (select_type_ == "Branchwise Job")
            {
                select_branch = select_branch;
            }
            else
            {
                select_branch = "";
            }
              * */
            select_branch = Connection.Get_Company_Type();

            if (HttpContext.Current.Session["Exp_Combine_Jobs"] != "" && HttpContext.Current.Session["Exp_Combine_Jobs"] != null)
            {
                Export_CheckList CHKLIST = new Export_CheckList();
                CHKLIST.JOBNo = custid;
                CHKLIST.Ename = "select_Combine_jobno_Flatfile";
                CHKLIST.TRANSPORT_MODE = HttpContext.Current.Session["Exp_Combine_Jobs"].ToString();
                CHKLIST.Workingperiod = select_branch;

                DataSet ds = new DataSet();
                ds = CHKLIST.RetrieveAll_General_Details();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCustomHouse = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    txtExporterName = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                    txtConsignee = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();

                    txt_icegate_Id = Connection.Get_EXP_Icegate_Id(ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString());

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        txtScheme = ds.Tables[1].Rows[0]["ITEM_SCHEME_CODE"].ToString();
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            txtNoofInvoices = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() + " INVOICE";
                        }
                        else
                        {
                            txtNoofInvoices = "";
                        }

                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            txtNoofItems = ds.Tables[3].Rows[0]["ITEM_SLNO"].ToString() + " ITEMS";
                        }
                        else
                        {
                            txtNoofItems = "";
                        }
                    }
                    else
                    {
                        txtScheme = "";
                        txtNoofItems = "";
                        txtNoofInvoices = "";
                    }

                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        Flatfile_Generate = "No";
                    }
                    else
                    {
                        Flatfile_Generate = "Yes";
                    }

                    /*
                    Rpt_General_Details Export_General = new Rpt_General_Details();
                    Export_General.Retrieve_GetGeneral(custid);
                    Annexure_Mode = Convert.ToString(Export_General.is_Annexure_Mode);
                    STR_Code = Convert.ToString(Export_General.is_STR_Code);
                    */

                    EXP_combined EC = new EXP_combined();
                    EC.Jobno = HttpContext.Current.Session["Exp_Combine_Jobs"].ToString();
                    EC.Exp_name = HttpContext.Current.Session["EC_Exp_name"].ToString(); ;
                    EC.Branch = select_branch;
                    EC.Mode = HttpContext.Current.Session["EC_Tr_mode"].ToString();
                    EC.Flag = "Checklist";
                    ds = EC.New_item_load();
                    Annexure_Mode = EC.result.ToString();
                    STR_Code = EC.Is_STR.ToString();

                    HttpContext.Current.Session.Remove("EXPORT_CHECKLIST");
                    HttpContext.Current.Session["EXPORT_CHECKLIST"] = ds;
                }
                else
                {
                    txtCustomHouse = "";
                    txtExporterName = "";
                    txtScheme = "";
                    txtConsignee = "";
                    txtNoofItems = "";
                    txtNoofInvoices = "";
                    txt_icegate_Id="";
                    SBType = "";

                }
                //------------------------
            }
            else
            {

                Export_CheckList CHKLIST = new Export_CheckList();
                CHKLIST.JOBNo = custid;
                CHKLIST.Ename = "select_jobno_CheckList";

                CHKLIST.Workingperiod = select_branch;
                DataSet ds = new DataSet();
                ds = CHKLIST.RetrieveAll_General_Details();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCustomHouse = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    txtExporterName = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                    txtConsignee = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();


                    //txt_icegate_Id = Connection.Get_EXP_Icegate_Id(ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString());
                    txt_icegate_Id = Connection.Get_EXP_ICEGATE_ID_New();


                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        txtScheme = ds.Tables[1].Rows[0]["ITEM_SCHEME_CODE"].ToString();
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            txtNoofInvoices = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() + " INVOICE";
                        }
                        else
                        {
                            txtNoofInvoices = "";
                        }

                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            txtNoofItems = ds.Tables[3].Rows[0]["ITEM_SLNO"].ToString() + " ITEMS";
                        }
                        else
                        {
                            txtNoofItems = "";
                        }
                    }
                    else
                    {
                        txtScheme = "";
                        txtNoofItems = "";
                        txtNoofInvoices = "";
                    }

                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        if (ds.Tables[5].Rows[0]["SEZ_ICEGATE_ID"].ToString() != "")
                        {
                            txt_icegate_Id = ds.Tables[5].Rows[0]["SEZ_ICEGATE_ID"].ToString();
                        }
                    }

                    /* hide on 27-06-2024
                    Rpt_General_Details Export_General = new Rpt_General_Details();
                    Export_General.Retrieve_GetGeneral(custid);
                    Annexure_Mode = Convert.ToString(Export_General.is_Annexure_Mode);
                    STR_Code = Convert.ToString(Export_General.is_STR_Code);
                     * */

                }
                else
                {
                    txtCustomHouse = "";
                    txtExporterName = "";
                    txtScheme = "";
                    txtConsignee = "";
                    txtNoofItems = "";
                    txtNoofInvoices = "";
                    txt_icegate_Id = "";

                }

                if (ds.Tables[4].Rows.Count > 0)
                {
                    Flatfile_Generate = "No";
                }
                else
                {
                    Flatfile_Generate = "Yes";
                }

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        custid = txtCustomHouse + "~~" + txtExporterName + "~~" + txtScheme + "~~" + txtConsignee + "~~" + txtNoofItems + "~~" + txtNoofInvoices + "~~" + Annexure_Mode + "~~" + STR_Code + "~~" + Flatfile_Generate + "~~" + txt_icegate_Id;

        return custid;
    }

    /*  protected void btnShow_Click(object sender, EventArgs e)
     {
         MP_DSC.Show();
         txt_path.Text = txt_Download_path.Text;
       
     }
    [System.Web.Services.WebMethod]
     public static string Get_Path_details(string Folder_path, string branch_common)
     {
         //DSC_Insert_update
         string Branch = string.Empty;
         string userid = string.Empty;

         Branch = HttpContext.Current.Session["currentbranch"].ToString();
         userid = HttpContext.Current.Session["currentuser"].ToString();

         IMP_EXP_DSC IED = new IMP_EXP_DSC();
         IED.FILE_PATH = Folder_path;
         IED.IMP_EXP = "E";
         IED.BRANCH_CODE = Branch;
         IED.BRANCH_COMMON = branch_common;
         IED.USER_ID = userid;
         IED.FLAG = "S";
         IED.DSC_Insert_update();
         return "Save Successfully";
     }

    private void Load_Path()
    {
        IMP_EXP_DSC IED = new IMP_EXP_DSC();
        DataSet ds_d = new DataSet();
        IED.IMP_EXP = "E";
        IED.BRANCH_COMMON = SELECT_BRANCH;
        IED.USER_ID = currentuser;
        IED.FLAG = "";
        ds_d = IED.DSC_Insert_update();
        if (ds_d.Tables[0].Rows.Count > 0)
        {
            txt_Download_path.Text = ds_d.Tables[0].Rows[0]["FILE_PATH"].ToString();
        }

    } */
    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DataRowView drv = (DataRowView)e.Row.DataItem;

                for (int i = 0; i < drv.DataView.Table.Columns.Count; i++)
                {

                    if (e.Row.Cells[i].Text == "F")
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
                        e.Row.Cells[i].Font.Bold = true;

                    }

                }

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    protected void btnsend_Queue_Click(object sender, EventArgs e)
    {
        try
        {
            //DSC_FLATFILE_INSERT_UPDATE
            string SQ_Path = string.Empty;

            /*
            if (SELECT_BRANCH != string.Empty)
            {
                //SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "EXP" + "/" + Session["currentbranch"].ToString() + "/");
                SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "EXP" + "/"
                +
                Session["currentbranch"].ToString().Replace(", ", "_").Replace(",", "_").Replace("(", "_").Replace(")", "_").Replace(" ", "_").Replace("/", "_")
                + "/");
            }
            else
            {
                SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" +"EXP" + "/");
            }
            */


            string SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
            if (SELECT_TYPE == "Branchwise Job")
            {
                SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "EXP" + "/"
                +
                Session["currentbranch"].ToString().Replace(", ", "_").Replace(",", "_").Replace("(", "_").Replace(")", "_").Replace(" ", "_").Replace("/", "_")
                + "/");
            }
            else if (SELECT_TYPE == "Areawise Job")
            {
                SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "EXP" + "/"
                +
                Session["GroupName"].ToString().Replace(", ", "_").Replace(",", "_").Replace("(", "_").Replace(")", "_").Replace(" ", "_").Replace("/", "_")
                + "/");
            }

            else
            {
                SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "EXP" + "/");
            }

            if (Directory.Exists(SQ_Path) == false)
            {
                Directory.CreateDirectory(SQ_Path);
            }
            Flatfile_gen();
            Flat_File("SQ", SQ_Path);
            Json_generation("SQ", SQ_Path);

            DateTime date = System.DateTime.Now;
            string datestringg = string.Format("{0:yyyyMMdd}", date);
            DateTime tt = System.DateTime.Now;
            string time = string.Format("{0:hhmm}", tt);
            GetDate_ddmmyy = Convert.ToDateTime(date).ToString("ddMMyy").ToString();
            string yy = Convert.ToDateTime(date).ToString("yyyy").ToString();


            int i = 0;

            logFileName = ddlJobNo.SelectedValue.ToString() + yy + ".sb";
            ObjUBO.File_Type = "E";
            ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
            ObjUBO.ITEM_DESCRIPTION = SQ_Path + logFileName;
            ObjUBO.Select_Item = "";
            if (btnsend_Queue.Text == "Send_Queue")
            {
                ObjUBO.flag = "S";
            }
            else
            {
                ObjUBO.flag = "U";
            }

            string url = HttpContext.Current.Request.Url.AbsoluteUri;           
            url = url.Substring(0, url.IndexOf("FlatFile")) + SQ_Path.Substring(SQ_Path.IndexOf("FlatFile"), SQ_Path.Length - (SQ_Path.IndexOf("FlatFile"))) + logFileName;
            ObjUBO.ADDRESS1 = url.Replace(@"\", @"/"); 

            if (Connection.COMPANYID() == "747" || Connection.COMPANYID() == "2145")
            {
                //D:\ERoyalImpex_Final_New_New\Submission\747\CHENNAI-CHN\IMP_Job_history //17 ~~172020Signed
                path = ""; logFileName = "";
                path = Server.MapPath("~/Submission/" + Connection.COMPANYID() + "/" + Session["GroupName"].ToString() + "/EXP_Job_history" + "/");
                logFileName = ddlJobNo.SelectedValue.ToString() + " ~~" + ddlJobNo.SelectedValue.ToString() + yy + "Signed.sb";
                System.IO.FileInfo fi = new System.IO.FileInfo(path + logFileName);
                try
                {
                    if (fi.Exists == true)
                    {
                        fi.Delete();
                    }
                }
                catch (Exception ex)
                {
                    Connection.Error_Msg(ex.Message);
                }
            }

            i = IV.DSC_Flatfile_DML(ObjUBO);

            DSC_Flatfile_Sent_Check();

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void DSC_Flatfile_Sent_Check()
    {
        try
        {
            //DSC_FLATFILE_SELECT
            DataSet ds = new DataSet();

            ObjUBO.File_Type = "E";
            ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
            ObjUBO.flag = "Flatfile_Sent_Status";
            ds = IV.DSC_Flatfile_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnsend_Queue.Text = "Resend_Queue";
                lblsent_date.Text = "FlatFile Sent Queue Dt : " + ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                btnsend_Queue.Text = "Send_Queue";
                lblsent_date.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
     
    }
    protected void btn_Auto_Spl_Char_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlJobNo.SelectedValue.ToString() != string.Empty)
            {
                DataSet ds = new DataSet();
                EV.Jobno = ddlJobNo.SelectedValue.ToString();
                EV.Flag = "EXP_SPL_CHAR_Auto_Remove";
                EV.Branch_Type = SELECT_BRANCH;
                ds = EV.EXP_Data_Select();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    protected void btnJson_Click(object sender, EventArgs e)
    {
        try
        {
            Json_generation("", "");


        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ImagebtnJsonfile_Click(object sender, ImageClickEventArgs e) // Added by shanthini on 14-08-2026 
    {
        try
        {

            logFileName = "SB" + ddlJobNo.SelectedValue.ToString() + DateTime.Now.Year.ToString() + ".json";
            errorFolder_json = Server.MapPath("~/Submission/" + COMPANY_ID + "/" + currentbranch + "/" + currentuser + "/" + "json" + "/");

            string fullFilePath = Path.Combine(errorFolder_json, logFileName);

            if (File.Exists(fullFilePath))
            {

                ObjUBO.File_Type = "E";
                ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
                ObjUBO.ITEM_DESCRIPTION = fullFilePath;
                ObjUBO.Select_Item = "";
                ObjUBO.flag = "S";

                IV.DSC_Flatfile_DML(ObjUBO);

                DSC_Flatfile_Sent_Check();
            }
            else
            {
                Alert_msg("JSON file not found. Please generate it first.");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Json_generation(string type, string path)
    {
        try
        {
            Flatfile_Json_export FJ = new Flatfile_Json_export();
            logFileName = "SB" + ddlJobNo.SelectedValue.ToString() + DateTime.Now.Year.ToString() + ".json";
            if (type == "SQ")
            {
                errorFolder_json = path;
            }
            else
            {
                errorFolder_json = Server.MapPath("~/Submission/" + COMPANY_ID + "/" + currentbranch + "/" + currentuser + "/" + "json" + "/");

            }
            if (!Directory.Exists(errorFolder_json))
            {
                Directory.CreateDirectory(errorFolder_json);
            }

            string fullFilePath = Path.Combine(errorFolder_json, logFileName);
            if (File.Exists(fullFilePath))
            {
                try
                {
                    File.Delete(fullFilePath);
                }
                catch (Exception ex)
                {
                    Connection.Error_Msg(ex.Message);
                    return;
                }
            }


            //Added By Benjamin 02092026

            string realJobNo = ddlJobNo.SelectedValue.ToString();
            string jobNumberForJson = null;
            string sequenceForJson = null;

            if (chkDummyFlatFile.Checked)
            {
                try
                {
                    string dummyValue = GetAndSaveDummyJobNo(realJobNo, "J");   // TYPE = 'J'
                    txtDummyJobNo.Text = dummyValue;

                    jobNumberForJson = dummyValue;
                    sequenceForJson = dummyValue;
                }
                catch (InvalidOperationException ex)
                {
                    ShowMessage(ex.Message, false);
                    return;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("DummyJson Save Error: " + ex.ToString());
                    ShowMessage("Could not save Dummy Job No. Please try again.", false);
                    return;
                }
            }

            ICEGATE_ID = txt_icegate_Id.Text;
            FJ.JOBNo = ddlJobNo.SelectedValue.ToString();
            FJ.Ename = "Exp_json ";
            DataSet dss = new DataSet();

            //dss = FJ.Get_EXP_ChkList_All_New(ICEGATE_ID, logFileName, errorFolder_json);


            dss = FJ.Get_EXP_ChkList_All_New(ICEGATE_ID, logFileName, errorFolder_json,
                                      jobNumberForJson, sequenceForJson); 


            if (dss.Tables[0].Rows.Count > 0)
            {
                ImagebtnJsonfile.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    //public void JSON_IEC_GATE_UPLOAD(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        string fileName = fileuploadExcel.FileName;
    //        int fileSize = fileuploadExcel.PostedFile.ContentLength;
    //        string fileType = fileuploadExcel.PostedFile.ContentType;
    //        string baseFolderPath = Server.MapPath("~/Submission/" +
    //                                        HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" +
    //                                        HttpContext.Current.Session["currentbranch"].ToString() + "/" +
    //                                        HttpContext.Current.Session["currentuser"].ToString() + "/DOWNLOAD");

    //        if (!Directory.Exists(baseFolderPath))
    //        {
    //            Directory.CreateDirectory(baseFolderPath);
    //        }
    //        else
    //        {
    //            // If folder exists, delete all existing files inside
    //            string[] existingFiles = Directory.GetFiles(baseFolderPath);
    //            foreach (string file in existingFiles)
    //            {
    //                File.Delete(file);
    //            }
    //        }
    //        string savePath = Path.Combine(baseFolderPath, fileName);
    //        fileuploadExcel.SaveAs(savePath);

    //        string jsonContent = File.ReadAllText(savePath);
    //        Newtonsoft.Json.Linq.JObject jsonObj = Newtonsoft.Json.Linq.JObject.Parse(jsonContent);

    //        string senderID = "";
    //        if (jsonObj["headerField"] != null && jsonObj["headerField"]["senderID"] != null)
    //        {
    //            senderID = jsonObj["headerField"]["senderID"].ToString();
    //        }
    //        string icegateId = txt_icegate_Id.Text.ToUpper();

    //        if (!senderID.Trim().ToUpper().Equals(icegateId))
    //        {
    //            Alert_msg_json("JSON ID does not match ICEGATE ID.Please verify and try again.");
    //            return;
    //        }
    //        else if (string.IsNullOrEmpty(senderID))
    //        {
    //            Alert_msg("Invalid JSON: senderID not found in headerField.");
    //            return;
    //        }

    //        Transaction Transact = new Transaction();
    //        string url = "http://icegateapi.eroyalimpex.co.in/api/icegate/submit";
    //        string clientCode = Connection.Company_License();
    //        // string com_id = Session["COMPANY_ID"].ToString();
    //        // string icegateId = txt_icegate_Id.Text.ToUpper();

    //        Transact.icegateId = icegateId;
    //        Transact.Ename = "GET_ICEGATE_PASS";
    //        Transact.Current_Working_Period = Working_Period;
    //        Transact.BRANCH_CODE = currentbranch;

    //        DataSet ds = Transact.Retrieve_Api_key_GET_ICEGATE();

    //        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
    //        {
    //            Alert_msg("API KEY NOT FOUND");
    //            return;
    //        }

    //        string api_key = ds.Tables[0].Rows[0]["API_KEY"].ToString();
    //        string filePath = savePath;

    //        string response = IceGateApiClient.SubmitIcegateRequest(
    //          url,
    //           clientCode,
    //           api_key,
    //           filePath
    //       );

    //        if (!string.IsNullOrEmpty(response) && response.Contains("\"validationStatus\":\"SUCCESS\""))
    //        {
    //            Alert_msg("JSON Successfully Submitted to ICEGATE");
    //        }
    //        else
    //        {
    //            string errorMsg = "Submission Failed.";

    //            if (!string.IsNullOrEmpty(response))
    //            {
    //                try
    //                {
    //                    var json = Newtonsoft.Json.Linq.JObject.Parse(response.Replace("HTTP ERROR: ", ""));
    //                    var message = json["message"];
    //                    if (message != null)
    //                    {
    //                        string msg = (string)message;
    //                        if (msg.Contains("ICEGATE Auth Failed"))
    //                        {
    //                            errorMsg = "ICEGATE Auth Failed. Please generate a new API Key and update.";
    //                        }
    //                        else
    //                        {
    //                            errorMsg = msg;
    //                        }
    //                    }
    //                }
    //                catch
    //                {
    //                    errorMsg = "Submission Failed.";
    //                }
    //            }

    //            Alert_msg(errorMsg);
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        string errorMsg = ex.Message.Replace("'", "\\'");

    //        Alert_msg("Error: " + errorMsg);
    //    }
    //}

    public void JSON_IEC_GATE_UPLOAD(object sender, EventArgs e)
    {

        try
        {
            string fileName = fileuploadExcel.FileName;
            int fileSize = fileuploadExcel.PostedFile.ContentLength;
            string file_ = Path.GetFileNameWithoutExtension(fileName).Replace("Signed", "");
            string type = file_.Substring(0, 2);
            string jobno = file_.Substring(2);



            string fileType = fileuploadExcel.PostedFile.ContentType;
            string baseFolderPath = Server.MapPath("~/Submission/" +
                                            HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" +
                                            HttpContext.Current.Session["currentbranch"].ToString() + "/" +
                                            HttpContext.Current.Session["currentuser"].ToString() + "/DOWNLOAD");

            if (!Directory.Exists(baseFolderPath))
            {
                Directory.CreateDirectory(baseFolderPath);
            }
            else
            {
                // If folder exists, delete all existing files inside
                string[] existingFiles = Directory.GetFiles(baseFolderPath);
                foreach (string file in existingFiles)
                {
                    File.Delete(file);
                }
            }
            string savePath = Path.Combine(baseFolderPath, fileName);
            fileuploadExcel.SaveAs(savePath);

            string jsonContent = File.ReadAllText(savePath);
            Newtonsoft.Json.Linq.JObject jsonObj = Newtonsoft.Json.Linq.JObject.Parse(jsonContent);

            string senderID = "";
            if (jsonObj["headerField"] != null && jsonObj["headerField"]["senderID"] != null)
            {
                senderID = jsonObj["headerField"]["senderID"].ToString();
            }
            string icegateId = txt_icegate_Id.Text.ToUpper();

            if (!senderID.Trim().ToUpper().Equals(icegateId))
            {
                Alert_msg_json("JSON ID does not match ICEGATE ID.Please verify and try again.");
                return;
            }
            else if (string.IsNullOrEmpty(senderID))
            {
                Alert_msg("Invalid JSON: senderID not found in headerField.");
                return;
            }

            Transaction Transact = new Transaction();
            string url = "http://icegateapi.eroyalimpex.co.in/api/icegate/submit";
            string clientCode = Connection.Company_License();
            // string com_id = Session["COMPANY_ID"].ToString();
            // string icegateId = txt_icegate_Id.Text.ToUpper();

            Transact.icegateId = icegateId;
            Transact.Ename = "GET_ICEGATE_PASS";
            Transact.Current_Working_Period = Working_Period;
            Transact.BRANCH_CODE = currentbranch;

            DataSet ds = Transact.Retrieve_Api_key_GET_ICEGATE();

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                Alert_msg("API KEY NOT FOUND");
                return;
            }

            string api_key = ds.Tables[0].Rows[0]["API_KEY"].ToString();
            string filePath = savePath;

            string response = IceGateApiClient.SubmitIcegateRequest(
              url,
               clientCode,
               api_key,
               filePath
           );

            if (!string.IsNullOrEmpty(response) && response.Contains("\"validationStatus\":\"SUCCESS\""))
            {
                InsertFlatFile("Success", jobno, fileName, type, currentbranch, Working_Period, currentuser, "");
                Alert_msg("JSON Successfully Submitted to ICEGATE");
            }
            else
            {
                string errorMsg = "Submission Failed.";

                if (!string.IsNullOrEmpty(response))
                {
                    try
                    {
                        var json = Newtonsoft.Json.Linq.JObject.Parse(response.Replace("HTTP ERROR: ", ""));
                        var message = json["message"];
                        if (message != null)
                        {
                            string msg = (string)message;
                            if (msg.Contains("ICEGATE Auth Failed"))
                            {
                                errorMsg = "ICEGATE Auth Failed. Please generate a new API Key and update.";
                            }
                            else
                            {
                                errorMsg = msg;
                            }
                        }
                    }
                    catch
                    {
                        errorMsg = "Submission Failed.";
                    }
                }
                InsertFlatFile("Error", jobno, fileName, type, currentbranch, Working_Period, currentuser, errorMsg);
                Alert_msg(errorMsg);
            }
        }

        catch (Exception ex)
        {
            string errorMsg = ex.Message.Replace("'", "\\'");

            Alert_msg("Error: " + errorMsg);
        }
    }

    public void InsertFlatFile(string tableType, string jobNo, string fileName, string type, string branchCode, string workingPeriod, string createdBy, string errorMessage = null)
    {
        string tableName;
        string typeResult = type.Equals("BE", StringComparison.OrdinalIgnoreCase) ? "I" : "E";

        if (tableType.Equals("Success", StringComparison.OrdinalIgnoreCase))
        {
            tableName = "FlatFile_Success";
        }
        else if (tableType.Equals("Error", StringComparison.OrdinalIgnoreCase))
        {
            tableName = "FlatFile_Error";
        }
        else
        {
            throw new ArgumentException("Invalid table type. Use Success or Error.");
        }

        string query;

        if (tableType.Equals("Success", StringComparison.OrdinalIgnoreCase))
        {
            query = "INSERT INTO " + tableName + " (JOBNO, FILENAME, TYPE, BRANCH_CODE, WORKINGPERIOD, CREATEDON, CREATEDBY) VALUES (@JOBNO, @FILENAME, @TYPE, @BRANCH_CODE, @WORKINGPERIOD, GETDATE(), @CREATEDBY)";
        }
        else
        {
            query = "INSERT INTO " + tableName + " (JOBNO, FILENAME, TYPE, ERRORMESSAGE, BRANCH_CODE, WORKINGPERIOD, CREATEDON, CREATEDBY) VALUES (@JOBNO, @FILENAME, @TYPE, @ERRORMESSAGE, @BRANCH_CODE, @WORKINGPERIOD, GETDATE(), @CREATEDBY)";
        }

        using (SqlConnection con = new SqlConnection(Connection.GetConnection()))
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@JOBNO", jobNo ?? "");
            cmd.Parameters.AddWithValue("@FILENAME", fileName ?? "");
            cmd.Parameters.AddWithValue("@TYPE", typeResult ?? "");
            cmd.Parameters.AddWithValue("@BRANCH_CODE", branchCode ?? "");
            cmd.Parameters.AddWithValue("@WORKINGPERIOD", workingPeriod ?? "");
            cmd.Parameters.AddWithValue("@CREATEDBY", createdBy ?? "");

            if (tableType.Equals("Error", StringComparison.OrdinalIgnoreCase))
            {
                cmd.Parameters.AddWithValue("@ERRORMESSAGE", errorMessage ?? "");
            }

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }


    private void Check_Duplicate_Invoice_OnLoad()
    {
        try
        {
            if (ddlJobNo.SelectedValue == "Select" || ddlJobNo.SelectedValue == "")
                return;

            Export_CheckList CHKLIST = new Export_CheckList();
            CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
            CHKLIST.Ename = "Export_Duplicate_Invoice_Chk";
            CHKLIST.Workingperiod = SELECT_BRANCH;

            DataSet ds = new DataSet();
            ds = CHKLIST.RetrieveAll_General_Details();

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return;

            List<string> allJobs = new List<string>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                string existsIn = r["EXISTS_IN_JOBNO"].ToString().Trim();
                if (existsIn == "") continue;

                string[] jobArr = existsIn.Split(',');
                foreach (string jb in jobArr)
                {
                    string job = jb.Trim();
                    if (job != "" && !allJobs.Contains(job))
                        allJobs.Add(job);
                }
            }

            if (allJobs.Count == 0) return;

            string jobStr = "";
            foreach (string j in allJobs)
                jobStr += (jobStr == "" ? "" : ", ") + "'" + j + "'";

            string msg = "This Invoice Number Already Exists in Job No - " +
                         "<span style='color:red;font-weight:bold;'>" + jobStr + "</span>";

            Show_duplicate_Popup("Duplicate Invoice No", msg);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog("Check_Duplicate_Invoice_OnLoad (Export): " + ex.Message);
        }
    }


     private void Show_duplicate_Popup(string title, string htmlMsg)
     {
        string theme = (Session["Theme"] != null && Session["Theme"].ToString() != "")
                        ? Session["Theme"].ToString().ToLower()
                        : "orange";

        string gradTop, gradBot;
        switch (theme)
        {
            case "blue": gradTop = "#4a90e2"; gradBot = "#2b6cb0"; break;
            case "dblue": gradTop = "#2c3e60"; gradBot = "#16213a"; break;
            case "green": gradTop = "#43a047"; gradBot = "#2e7d32"; break;
            case "bluefancy": gradTop = "#5b86e5"; gradBot = "#36d1dc"; break;
            case "violetfancy": gradTop = "#8e2de2"; gradBot = "#4a00e0"; break;
            default: gradTop = "#f5a623"; gradBot = "#e08e0b"; break;
        }

        string t = (title ?? "").Replace("\\", "\\\\").Replace("'", "\\'");
        string m = (htmlMsg ?? "").Replace("\\", "\\\\").Replace("'", "\\'")
                                  .Replace("\r", "").Replace("\n", "");

        string js = @"
      (function () {
    var old = document.getElementById('cstm_pop_ovl');
    if (old) old.parentNode.removeChild(old);
    var gradTop = '" + gradTop + @"'; var gradBot = '" + gradBot + @"';
    var ovl = document.createElement('div');
    ovl.id = 'cstm_pop_ovl';
    ovl.style.cssText = 'position:fixed;top:0;left:0;width:100%;height:100%;background:rgba(0,0,0,.50);z-index:999998;display:flex;align-items:center;justify-content:center;';
    var box = document.createElement('div');
    box.style.cssText = 'width:460px;max-width:94vw;background:#fff;border-radius:8px;z-index:999999;box-shadow:0 8px 32px rgba(0,0,0,.40);font-family:Segoe UI,Tahoma,Arial,sans-serif;font-size:13px;color:#2d3436;display:flex;flex-direction:column;max-height:85vh;overflow:hidden;';
    box.innerHTML =
        '<div style=""background:linear-gradient(' + gradTop + ',' + gradBot + ');color:#fff;font-weight:700;font-size:14px;padding:10px 16px;flex-shrink:0;"">' + '" + t + @"' + '</div>' +
        '<div style=""padding:16px 18px;line-height:1.55;overflow:auto;flex:1;"">' + '" + m + @"' + '</div>' +
        '<div style=""padding:10px 14px;text-align:center;border-top:1px solid #eee;flex-shrink:0;"">' +
            '<button type=""button"" id=""cstm_pop_ok"" style=""min-width:88px;height:30px;background:linear-gradient(' + gradTop + ',' + gradBot + ');color:#fff;border:0;border-radius:5px;font-weight:600;cursor:pointer;"">OK</button></div>';
    ovl.appendChild(box);
    document.body.appendChild(ovl);
    document.getElementById('cstm_pop_ok').onclick = function () {
        var el = document.getElementById('cstm_pop_ovl');
        if (el) el.parentNode.removeChild(el);
    };
})();";

        ScriptManager.RegisterStartupScript(this, GetType(),
            "cstmPop_" + Guid.NewGuid().ToString("N"), js, true);
    }



     private bool Check_Export_Invoice_Lock()
     {
         CheckList chklist = new CheckList();
         chklist.JOBNo = ddlJobNo.SelectedValue.ToString().Trim();
         chklist.Ename = "Export_Check_Invoice_Generate_Lock";
         chklist.Workingperiod = SELECT_BRANCH;
         //chklist.currentuser = currentuser = Session["currentuser"].ToString();
         DataSet dsLock = new DataSet();
         dsLock = chklist.RetrieveAll_Invoice_Details();

         if (dsLock == null || dsLock.Tables.Count == 0 || dsLock.Tables[0].Rows.Count == 0)
         {
             return true;
         }

         System.Text.StringBuilder sb = new System.Text.StringBuilder();
         string lastInv = "";
         foreach (DataRow r in dsLock.Tables[0].Rows)
         {
             string inv = r["INVOICE_NO"].ToString();
             if (inv != lastInv)
             {
                 if (lastInv != "") sb.Append("<br/><br/>");
                 sb.Append("Invoice No <b>'" + inv + "'</b> is <b style='color:#c0392b;'>LOCKED</b>.<br/>");
                 sb.Append("This invoice is already used in Job No : <b>" + r["DUPLICATE_JOBNO"].ToString() + "'");
                 lastInv = inv;
             }
             else
             {
                 sb.Append(", '" + r["DUPLICATE_JOBNO"].ToString() + "'");
             }
         }
         sb.Append("</b>.");
         sb.Append("<br/><br/>Go to <b>Admin &raquo; Duplicate Invoice Lock &raquo; Release</b>.");

         Show_Popup("Duplicate Invoice No", sb.ToString());

         return false;
     }


     private void Show_Popup(string title, string htmlMsg)
     {
         string theme = (Session["Theme"] != null && Session["Theme"].ToString() != "")
                         ? Session["Theme"].ToString().ToLower()
                         : "orange";

         string gradTop, gradBot;

         switch (theme)
         {
             case "blue":
                 gradTop = "#4a90e2"; gradBot = "#2b6cb0";
                 break;
             case "dblue":
                 gradTop = "#2c3e60"; gradBot = "#16213a";
                 break;
             case "green":
                 gradTop = "#43a047"; gradBot = "#2e7d32";
                 break;
             case "bluefancy":
                 gradTop = "#5b86e5"; gradBot = "#36d1dc";
                 break;
             case "violetfancy":
                 gradTop = "#8e2de2"; gradBot = "#4a00e0";
                 break;
             case "orange":
             default:
                 gradTop = "#f5a623"; gradBot = "#e08e0b";
                 break;
         }

         string t = (title ?? "").Replace("\\", "\\\\").Replace("'", "\\'");
         string m = (htmlMsg ?? "").Replace("\\", "\\\\").Replace("'", "\\'")
                                   .Replace("\r", "").Replace("\n", "");

         string js = @"
(function () {
    var old = document.getElementById('cstm_pop_ovl');
    if (old) old.parentNode.removeChild(old);

    var gradTop = '" + gradTop + @"';
    var gradBot = '" + gradBot + @"';

    var ovl = document.createElement('div');
    ovl.id = 'cstm_pop_ovl';
    ovl.style.cssText = 'position:fixed;top:0;left:0;width:100%;height:100%;' +
        'background:rgba(0,0,0,.50);z-index:999998;' +
        'display:flex;align-items:center;justify-content:center;';

    var box = document.createElement('div');
    box.style.cssText = 'width:460px;max-width:94vw;' +
        'background:#fff;border-radius:8px;z-index:999999;' +
        'box-shadow:0 8px 32px rgba(0,0,0,.40);' +
        'font-family:Segoe UI,Tahoma,Arial,sans-serif;font-size:13px;color:#2d3436;' +
        'display:flex;flex-direction:column;max-height:85vh;overflow:hidden;';

    box.innerHTML =
        '<div style=""background:linear-gradient(' + gradTop + ',' + gradBot + ');color:#fff;' +
            'font-weight:700;font-size:14px;padding:10px 16px;flex-shrink:0;"">' + '" + t + @"' + '</div>' +
        '<div style=""padding:16px 18px;line-height:1.55;overflow:auto;flex:1;"">' + '" + m + @"' + '</div>' +
        '<div style=""padding:10px 14px;text-align:center;border-top:1px solid #eee;flex-shrink:0;"">' +
            '<button type=""button"" id=""cstm_pop_ok"" style=""min-width:88px;height:30px;' +
            'background:linear-gradient(' + gradTop + ',' + gradBot + ');color:#fff;border:0;' +
            'border-radius:5px;font-weight:600;cursor:pointer;"">OK</button></div>';

    ovl.appendChild(box);
    document.body.appendChild(ovl);

    document.getElementById('cstm_pop_ok').onclick = function () {
        var el = document.getElementById('cstm_pop_ovl');
        if (el) el.parentNode.removeChild(el);
    };
})();";

         ScriptManager.RegisterStartupScript(this, GetType(),
             "cstmPop_" + Guid.NewGuid().ToString("N"), js, true);
     }



    //Added By Benjamin 02092026

     protected void chkDummyFlatFile_CheckedChanged(object sender, EventArgs e)
     {
         hdn_Jobno.Value = Request["jobno"] != null ? Request["jobno"].ToString().TrimEnd() : string.Empty;
         string jobNo = hdn_Jobno.Value.Trim();

         if (string.IsNullOrEmpty(jobNo))
         {
             ShowMessage("Job No not found on this page.", false);
             chkDummyFlatFile.Checked = false;
             return;
         }

         if (chkDummyFlatFile.Checked)
         {
             try
             {
                 //txtDummyJobNo.Text = GetPreviewDummyJobNo(jobNo);

                 txtDummyJobNo.Text = GetPreviewDummyJobNo(jobNo, "F");   // Flatfile preview-க்கு "F"

                 ShowMessage("Review the Dummy Job No, then click Submit to save.", true);
             }
             catch (InvalidOperationException ex)
             {
                 ShowMessage(ex.Message, false);
                 chkDummyFlatFile.Checked = false;
             }
             catch (Exception ex)
             {
                 System.Diagnostics.Trace.WriteLine("DummyFlatFile Preview Error: " + ex.ToString());
                 ShowMessage("Could not generate preview. Please try again.", false);
                 chkDummyFlatFile.Checked = false;
             }
         }
         else
         {

             txtDummyJobNo.Text = string.Empty;
             ShowMessage(string.Empty, true);
         }
     }


     private string GetPreviewDummyJobNo(string jobNo, string type)
     {
         string impExp = "EXP";
         string branchCode = Connection.Current_Branch();

         int existingMaxCount = 0;
         using (SqlConnection conn = new SqlConnection(Connection.GetConnection()))
         using (SqlCommand cmd = new SqlCommand(@"
        SELECT ISNULL(MAX(d.CLICK_COUNT), 0)
        FROM IMP_EXP_DUMMY_DUPLICATE_JOB d
        WHERE d.JOBNO = @JobNo
          AND d.IMP_EXP = @ImpExp
          AND d.BRANCH_CODE IN (
                SELECT BRANCHCODE FROM TBL_GROUPMASTER
                WHERE GROUP_ID = (
                    CASE WHEN @BranchCode <> ''
                         THEN (SELECT GROUP_ID FROM TBL_GROUPMASTER WHERE BRANCHCODE = @BranchCode)
                         ELSE 1 END))", conn))
         {
             cmd.Parameters.AddWithValue("@JobNo", jobNo);
             cmd.Parameters.AddWithValue("@ImpExp", impExp);
             cmd.Parameters.AddWithValue("@BranchCode", branchCode);
             conn.Open();
             object result = cmd.ExecuteScalar();
             if (result != null && result != DBNull.Value)
                 existingMaxCount = Convert.ToInt32(result);
         }

         int previewCount = existingMaxCount + 1;
         return BuildDummyJobNo(jobNo, previewCount);
     }





     //private string BuildDummyJobNo(string jobNo, int clickCount)
     //{
     //    const int CounterDigits = 2;
     //    const int TotalLength = 7;
     //    const int JobFieldLength = TotalLength - CounterDigits;

     //    int maxCount = (int)Math.Pow(10, CounterDigits) - 1;
     //    if (clickCount > maxCount)
     //    {
     //        throw new InvalidOperationException(
     //            string.Format("Maximum dummy attempts ({0}) reached for Job No {1}.", maxCount, jobNo));
     //    }

     //    string jobPart = jobNo.Length >= JobFieldLength
     //        ? jobNo.Substring(0, JobFieldLength)
     //        : jobNo.PadLeft(JobFieldLength, '0');

     //    string counterPart = clickCount.ToString().PadLeft(CounterDigits, '0');   // "02"

     //    return jobPart + counterPart;      // "0549202"
     //}



     private string BuildDummyJobNo(string jobNo, int clickCount)
     {
         const int TotalLength = 7;

         int jobFieldLength = Math.Max(5, jobNo.Length);
         int counterDigits = TotalLength - jobFieldLength;
         if (counterDigits < 1) counterDigits = 1;

         int maxCount = (int)Math.Pow(10, counterDigits) - 1;
         if (clickCount > maxCount)
         {
             throw new InvalidOperationException(
                 string.Format("Maximum dummy attempts ({0}) reached for Job No {1}.", maxCount, jobNo));
         }

         string jobPart = jobNo.PadLeft(jobFieldLength, '0');
         string counterPart = clickCount.ToString().PadLeft(counterDigits, '0');

         return jobPart + counterPart;
     }










     private string GetAndSaveDummyJobNo(string realJobNo, string type)
     {
         if (string.IsNullOrEmpty(realJobNo))
             throw new InvalidOperationException("Job No not found. Please select a Job No before generating Dummy Job No.");

         string impExp = "EXP";
         string branchCode = Connection.Current_Branch();
         string userId = Connection.Current_User_Upper();
         string dummyJobNo;
         try
         {
             using (SqlConnection conn = new SqlConnection(Connection.GetConnection()))
             using (SqlCommand cmd = new SqlCommand("IMP_EXP_DUMMY_DUPLICATE_JOB_INS", conn))
             {
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@IMP_EXP", impExp);
                 cmd.Parameters.AddWithValue("@JOBNO", realJobNo);
                 cmd.Parameters.AddWithValue("@BRANCH_CODE", branchCode);
                 cmd.Parameters.AddWithValue("@User_ID", userId);
                 cmd.Parameters.AddWithValue("@TYPE", type);

                 SqlParameter outParam = new SqlParameter("@DummyJobNo", SqlDbType.NVarChar, 20);
                 outParam.Direction = ParameterDirection.Output;
                 cmd.Parameters.Add(outParam);

                 conn.Open();
                 cmd.ExecuteNonQuery();

                 dummyJobNo = outParam.Value != DBNull.Value ? outParam.Value.ToString() : null;
             }
         }
         catch (SqlException sqlEx)
         {
             throw new InvalidOperationException(sqlEx.Message);
         }

         if (string.IsNullOrEmpty(dummyJobNo))
             throw new InvalidOperationException("Could not generate Dummy Job No. Please try again.");

         return dummyJobNo;
     }

     private void LoadExistingDummyJobNo(string jobNo)
     {
         string impExp = "EXP";
         string branchCode = Connection.Current_Branch();

         string existingDummyJobNo = null;

         using (SqlConnection conn = new SqlConnection(Connection.GetConnection()))
         using (SqlCommand cmd = new SqlCommand(@"
        SELECT TOP 1 d.DUMMY_JOBNO
        FROM IMP_EXP_DUMMY_DUPLICATE_JOB d
        WHERE d.JOBNO = @JobNo
          AND d.IMP_EXP = @ImpExp
          AND d.BRANCH_CODE IN (
                SELECT BRANCHCODE FROM TBL_GROUPMASTER
                WHERE GROUP_ID = (
                    CASE WHEN @BranchCode <> ''
                         THEN (SELECT GROUP_ID FROM TBL_GROUPMASTER WHERE BRANCHCODE = @BranchCode)
                         ELSE 1 END))
        ORDER BY d.CLICK_COUNT DESC", conn))
         {
             cmd.Parameters.AddWithValue("@JobNo", jobNo);
             cmd.Parameters.AddWithValue("@ImpExp", impExp);
             cmd.Parameters.AddWithValue("@BranchCode", branchCode);

             conn.Open();
             object result = cmd.ExecuteScalar();
             existingDummyJobNo = (result != null && result != DBNull.Value) ? result.ToString() : null;
         }

         if (!string.IsNullOrEmpty(existingDummyJobNo))
         {
             chkDummyFlatFile.Checked = true;
             txtDummyJobNo.Text = existingDummyJobNo;
             ShowMessage("Existing Dummy Job No: " + existingDummyJobNo, true);
         }
         else
         {
             chkDummyFlatFile.Checked = false;
             //txtDummyJobNo.Text = string.Empty;
             txtDummyJobNo.Text = existingDummyJobNo ?? string.Empty;
         }
     }


     private void ShowMessage(string message, bool isSuccess)
     {
         lblDummyMsg.Text = message;
         lblDummyMsg.ForeColor = isSuccess ? System.Drawing.Color.Green : System.Drawing.Color.Red;
     }



}