using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Web.Services;
using System.Data.OleDb;
using System.Collections;
using System.Data;
using BussinessObject;
using System.Globalization;


public partial class Export_SAHI_ExcelUpload : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    DataSet data = new DataSet();
    UserBO objUBO = new UserBO();
    eroyalmaster erm = new eroyalmaster();
    Annexure_C_Sea ANNEX_C_Sea = new Annexure_C_Sea();
    Annexure_C_Air ANNEX_C_Air = new Annexure_C_Air();
    Annexure ANNEX = new Annexure();

    DataSet dss = new DataSet();
    DataSet ds_IEC = new DataSet();
    DataTable dt_gen = new DataTable();  
    DataTable dt_PKG = new DataTable();
    DataTable dt_AR4 = new DataTable();
    DataTable dt_blk_Lic = new DataTable();
    DataTable dt_blk_Imp_Exp_lic = new DataTable();
    DataTable dt_inv_item = new DataTable();

    Jobwise_xl_Upload xl = new Jobwise_xl_Upload();
    AdminMasterDetails admin = new AdminMasterDetails();
    public int MAX_ID = 0;
    public int i;

    int sl = 0;
    int sl_E = 0;

    int ii = 0;
    int D_E = 0;

    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    
    public string SELECT_TYPE, SELECT_BRANCH;
    public string EXPORT_JOBNO,EXPORT_JOBDATE; 

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    public string errorFolder = "", logline = "", logFileName = "", Is_Additional_INV = "", MAX_INVOICE_SLNO = "";
    public string folderName = "/Submission";
    public string COMPANY_IDD, comp_ConnectionStr;
    string statecode = "";

    public string scheme;
    string[] scheme_name = new string[2];

    public int License_id_Max = 0;
    public int License_id_IMP_EXP_Max = 0;

    public string[] lic_no;
    public int licno_Count = 0;
    public decimal item_amt;
    int Sheetcount = 0;

    DataSet ds_TPD = new DataSet();
    DataSet ds_draw = new DataSet();
    DataSet ds_license = new DataSet();

    Auto_Search Auto = new Auto_Search();
    //Export_Licence License = new Export_Licence();
   
    Export_XL_Upload EXU = new Export_XL_Upload();

    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt = new DataTable();
    DataSet ds_JOBNO = new DataSet();

    public string GENERAL_EXPORT_JOBNO = "",JOBID = "", JOBNO = "", JOBDATE = "", TRANSPORT_MODE = "", CUSTOMS_HOUSE = "", CUSTOMS_HOUSE_NAME = "", SB_TYPE = "", EXPORTER_NAME = "", BRANCH_NO = "",
                  IEC_NO = "", ADDRESS1 = "", ADDRESS2 = "", ADDRESS3 = "", ADDRESS4 = "", ADDRESS5 = "", ADCODE = "", BANK_ACCOUNT = "", DRAWBACK_ACCOUNT = "",
                  CONSIGNEE_NAME = "", CONSIGNEE_ADD1 = "", CONSIGNEE_ADD2 = "", CONSIGNEE_ADD3 = "", CONSIGNEE_ADD4 = "", CONSIGNEE_ADD5 = "", COUNTRY_DISCHARGE = "", PORT_DISCHARGE = "",
                  COUNTRY_FINAL_DEST = "", PORT_FINAL_DEST = "", STATE_OF_EXPORT = "", NFEI = "", NFEI_TYPE = "", RBI_WAIVER_NO = "", RBI_WAIVER_DATE = "", MARKS_NO = "",
                  USERID = "", LoginDate = "", LoginSTATUS = "", BRANCHCODE = "", WORKINGPERIOD = "", FILE_REF_NO = "", JOB_STATUS = "", JOB_RELEASE = "", JOB_FILED_STATUS = "",
                  MODIFIEDBY = "", MODIFIEDON = "", TYPE_OF_EXPORTER = "", JOB_PREFIX = "", JOB_SUFFIX = "", JOBNO_PS = "", CONSIGNEE_BRANCHSLNO = "", Current_JOBID;

    public string ANNEX_SEA_PACK_ID = "",
        ANNEX_SEA_PACK_JOBNO = "", ANNEX_SEA_PACK_GROUP = "", ANNEX_SEA_PACK_FROM = "", ANNEX_SEA_PACK_TO = "", ANNEX_SEA_PACK_PACKAGETYPE = "",
                  DATE_TIME = "", STATUS = "", YEAR = "", ANNEX_SEA_PACK_FROMDESC = "", ANNEX_SEA_PACK_TODESC = "";

    public string ANNEX_SEA_CON_ID = "",
    ANNEX_SEA_CON_JOBNO = "", ANNEX_SEA_CON_CONTAINERNO = "", ANNEX_SEA_CON_SIZE = "", ANNEX_SEA_CON_TYPE = "", ANNEX_SEA_CON_EXCISE_SEALNO = "",
                  ANNEX_SEA_CON_SEAL_DATE = "", ANNEX_SEA_CON_SEALTYPE_INDICATOR = "", ANNEX_SEA_CON_SEAL_DEVICEID = "", ANNEX_SEA_CON_DOC_TYPE = "", ANNEX_SEA_CON_DOC_NUMBER = "";

    public string INVOICE_ID = "", INVOICE_SLNO = "", INVOICE_NO = "", INVOICE_DATE = "", PAYMENT_METHOD = "", PERIOD_PAYMENT = "", INVOICE_VALUE = "", INVOICE_CURRENCY = "", EXCHANGE_RATE = "",
                  CONTRACT_NO = "", TERMS = "", BUYER = "", BUYER_NAME = "", BUYER_ADDRESS = "", BUYER_ADDRESS1 = "", BUYER_ADDRESS2 = "", BUYER_ADDRESS3 = "", BUYER_ADDRESS4 = "", COMMISSION_RATE = "",
                  COMMISSION_CHARGES = "", COMMISSION_CURRENCY = "", FOB_RATE = "", FOB_CHARGES = "", FOB_CURRENCY = "", PACKMISC_RATE = "", PACKMISC_CHARGES = "", PACKMISC_CURRENCY = "",
                  OTHER_DEDUCTION_RATE = "", OTHER_DEDUCTION_CHARGES = "", OTHER_DEDUCTION_CURRENCY = "", FREIGHT_RATE = "", FREIGHT_CHARGES = "", FREIGHT_CURRENCY = "", FREIGHT_EXRATE = "",
                  INSURANCE_RATE = "", INSURANCE_CHARGES = "", INSURANCE_CURRENCY = "", INSURANCE_EXRATE = "", WHEATHER_UNIT_PRICE = "", WORKING_PERIOD = "",
                  NON_STD_EFFECT_DT_EXP = "", NON_STD_BANKNAME = "", NON_STD_CERTIFICATE_NO = "", NON_STD_CERTIFICATE_DATE = "", TERMS_PLACE = "",
                  THIRDPARTY_NAME = "", THIRDPARTY_ADD1 = "", THIRDPARTY_ADD2 = "", THIRDPARTY_CITY = "", T_PARTY_COUNTRY_SUB_DIV = "", T_PARTY_COUNTRY_CODE = "",
                  T_PARTY_PIN = "", AUTHORIZED_ECONOMIC_OPERATOR_CODE = "", A_E_O_COUNTRY = "", AUTHORIZED_ECONOMIC_OPERATOR = "";

    public string ITEM_ID = "", ITEM_SLNO = "", ITEM_DESCRIPTION = "", RITCNO = "", ITEM_QTY = "", ITEM_QTY_CODE = "", ITEM_UNIT_PRICE = "", ITEM_PER = "", ITEM_AMOUNT = "",
                  ITEM_PMVVALUE = "", ITEM_SCHEME_CODE = "", ITEM_ACCESSORIES_DESC = "", ITEM_AR4_NO = "", ITEM_AR4_DATE = "", ITEM_COMMISSION_RATE = "", ITEM_DIVISION = "", ITEM_RANGE = "", ITEM_REMARKS = "",
                  ITEM_IECCODE = "", ITEM_EXPORTER_NAME = "", BR_SLNO = "", ITEM_STR_CODE = "", REWARD_POINTS = "", PMV_VALUE = "",
                  FOB_VALUE = "", DRAWBACK_VALUE = "", CESS_YN = "", STR_RATE = "", STR_AMOUNT = "", MANUFACTURER_PRODUCER = "", M_P_GROWER_CODE = "", M_P_GROWER_ADD1 = "",
                  M_P_GROWER_ADD2 = "", M_P_GROWER_CITY = "", M_P_GROWER_COUNTRY_SUBDIV = "", M_P_GROWER_PIN = "", M_P_GROWER_COUNTRY = "", SOURCE_STATE = "",
                  TRANSIT_COUNTRY = "", ACCESSORY_STATUS = "", HAWB_NO = "", TOTAL_PKGS = "", ENDUSE_ITEM = "", IGST_PAYMENT = "", TAXABLE_VALUE = "", IGST_AMT = "", GSTN_TYPE = "", GSTN_ID = "", RODTEP = "";

    public string  SCHEME_CODE = "", DRAWBACK_SLNO = "", DRAWBACK_QTY = "", DRAWBACK_UNIT = "", DRAWBACK_NOOFUNITS = "", DRAWBACK_RATE = "", DRAWBACK_CAPS = "", DRAWBACK_DESC = "", STATE_LEVEL_ADV_RATE = "", STATE_LEVEL_ADV_AMT = "";

    public string AR4_JOBNO="",AR4_NO="",AR4_DATE="",AR4_COMMISSION_RATE="",AR4_DIVISION="",AR4_RANGE="",AR4_REMARKS="",AR4_INVOICE_NO="",AR4_INVOICE_SLNO="",AR4_RUN_ID="",AR4_ITEM_NO="";

    public string  SCHEME = "",  LICENSE_NO = "", LICENSE_DATE = "",LICENSE_REG_SLNO="",LICENSE_E_SL_NO="",LICENSE_EXP_QTY="",LICENSE_EXP_UNIT="",LICENSE_IMP_ITEM_SL_NO="",LICENSE_IMP_DESC="",LICENSE_IMP_QTY="",LICENSE_IMP_UNIT="",LICENSE_IMP_TYPE="",
                    LICENSE_REG_DATE="",LICENSE_REG_TYPE="",LICENSE_ITEM_SL_NO="",LICENSE_ITEM_DESCRIPTION="",LICENSE_QTY="",LICENSE_UNIT="",LICENSE_TYPE="";

    public int LICENSE_ID, LICENSE_IMP_EXP_ID, LICENSE_R_SL_NO, DRAWBACK_ID, AR4_ID, SW_INFO_ID;

    string SW_INFO_TYPE_ID = "", INFO_TYPE = "", INFO_QUALIFIER = "", INFO_CODE = "", INFO_TEXT = "", INFO_MSR = "", INFO_UQC = "", DEPARTMENT = "", I_U_TYPE = "";

    string SW_CONTROL_ID = "", CONTROL_TYPE_CODE = "", CONTROL_LOCATION = "", CONTROL_START_DATE = "", CONTROL_END_DATE = "", CONTROL_RESULT_CODE = "", CONTROL_RESULT_TEXT = "";

    string SW_ID = "", STMT_DECLARATION_TYPE = "", STMT_DECLARATION_NUMBER = "", STMT_DECLARATION_DATE = "", STMT_TYPE = "", STMT_CODE = "", STMT_TEXT = "", SR_NO = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        //TRANSPORT_MODE = Session["Transport_Mode_Port"].ToString();
        
        SB_TYPE = Session["EXPORT_SBTYPE"].ToString();
        COMPANY_IDD = Session["COMPANY_ID"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();

        hdfTransport_mode.Value = Session["Transport_Mode_Port"].ToString();

        //if (Session["EXPORT_JOBNO"] != null)
        //{
        //    EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
        //    EXPORT_JOBDATE = Session["EXPORT_JOBDATE"].ToString();
        //}

        Date_Time date = new Date_Time();
        JOBDATE = date.Today_Date();

        if(!String.IsNullOrEmpty(Request.QueryString["IsAdditionalInv"]))
        {
            Is_Additional_INV = "YES";
        }



        if (Session["Jobno_Excel"] != null || Session["Jobno_Excel"] != null)
        {
            GENERAL_EXPORT_JOBNO = Session["Jobno_Excel"].ToString();
        }

        // commented for areawise implementation on 05-mar-2020
        /*

        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
          * */


        SELECT_BRANCH = Connection.Get_Company_Type();
        Get_MaxJobno();

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Export_Excel");
        if (!Page.IsPostBack)
        {          
        }
       
        //Call_Data_Table();
    }

    public void Get_MaxJobno()
    {
        if (GENERAL_EXPORT_JOBNO != "")
        {
            if (Is_Additional_INV == "")
            {
                //EXU.JOBNO = GENERAL_EXPORT_JOBNO;
                //EXU.Xml_D = "";
                //EXU.Branch_Code = SELECT_BRANCH;
                //EXU.Ename = "CHECK_JOBNo_Avail";
                //ds_JOBNO = EXU.Select_Exp_INV();

                //if (ds_JOBNO.Tables[0].Rows.Count > 0)
                //{
                //    EXPORT_JOBNO = ds_JOBNO.Tables[0].Rows[0][0].ToString();
                //    //Excel_Upload_load(MAX_INVOICE_SLNO, Is_Additional_INV);
                //}
                //else
                //{
                    EXU.JOBNO = "";
                    EXU.Xml_D = "";
                    EXU.Branch_Code = SELECT_BRANCH;
                    EXU.Ename = "Get_MaxJobno";
                    ds_JOBNO = EXU.Select_Exp_INV();

                    if (ds_JOBNO.Tables[0].Rows.Count > 0)
                    {
                        EXPORT_JOBNO = ds_JOBNO.Tables[0].Rows[0][0].ToString();
                        Session["EXPORT_JOBNO"] = EXPORT_JOBNO;
                        //Excel_Upload_load(MAX_INVOICE_SLNO, Is_Additional_INV);
                    }
                //}
            }
            else
            {
                EXPORT_JOBNO = GENERAL_EXPORT_JOBNO;
            }
        }
        else
        {
            if (Is_Additional_INV == "")
            {
                EXU.JOBNO = "";
                EXU.Xml_D = "";
                EXU.Branch_Code = SELECT_BRANCH;
                EXU.Ename = "Get_MaxJobno";
                ds_JOBNO = EXU.Select_Exp_INV();

                if (ds_JOBNO.Tables[0].Rows.Count > 0)
                {
                    EXPORT_JOBNO = ds_JOBNO.Tables[0].Rows[0][0].ToString();
                    //Excel_Upload_load(MAX_INVOICE_SLNO, Is_Additional_INV);
                }
            }
            else
            {
                if (Session["Jobno_Excel"] != null || Session["Jobno_Excel"] != null)
                {
                    EXPORT_JOBNO = Session["Jobno_Excel"].ToString();
                }
            }
        }
    }
    
   
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SAHI - Export Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SAHI - Export Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void gv_Item_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }

    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }

    protected void gv_Gen_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }

    protected void gv_Gen_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    
   protected void btn_upload_Click(object sender, EventArgs e)
   {
       try
       {
           if (File.Exists(errorFolder + logFileName))
           {
               DirectoryInfo dir = new DirectoryInfo(errorFolder);
               foreach (FileInfo fi in dir.GetFiles())
               {
                   fi.Delete();
               }
               Get_ExcelFile();
           }
           else
           {
               DirectoryInfo dir = new DirectoryInfo(errorFolder);
               dir.Create();
               foreach (FileInfo fi in dir.GetFiles())
               {
                   fi.Delete();
               }

               Get_ExcelFile();
           }
       }
       catch (Exception ex)
       {
           ErrorLogs er = new ErrorLogs();
           er.makeLog(ex.Message);
       }
   }


   protected void btnupload_Click(object sender, EventArgs e)
   {
       if (txtStateExport.Text != "")
       {
           if (txtCountryOrigin.Text != "")
           {
               if (txtPortShipment.Text != "")
               {
                   if (gv_Item_Details.Rows.Count > 0)
                   {
                       DataSet d = new DataSet();
                       EXU.JOBNO = EXPORT_JOBNO;
                       //EXU.Ename = "Excel_Aval";
                       EXU.Ename = "CHECK_JOBNo_Avail";
                       EXU.Branch_Code = SELECT_BRANCH;
                       d = EXU.Select_Exp_INV();

                       if (d.Tables[0].Rows.Count > 0)
                       {
                           if (Is_Additional_INV == "YES")
                           {
                               MP_U.Show();
                           }
                           else
                           {
                               MP_U_job.Show();
                           }
                       }
                       else
                       {
                           Excel_Upload_load("","");
                       }
                   }
                   else
                   {
                       Alert_msg("Upload Ur Excel file.");
                   }
               }
               else
               {
                   Alert_msg("Select Port Name");
               }
           }
           else
           {
               Alert_msg("Select Country Name");
           }
       }
       else
       {
           Alert_msg("Select State of Export");
           txtStateExport.Focus();
       }
       
   }

   protected void btnyes_Click(object sender, EventArgs e)
   {
       DataSet ds = new DataSet();

       //objUBO.IEC_NO = EXPORT_JOBNO;
       //objUBO.BRANCH_NO = "";
       //objUBO.Ename = "get_MAX_Invoice_SlNo";
       //objUBO.WORKING_PERIOD = SELECT_BRANCH;
       //ds = xl.Bind_Export_General_IEC_No(objUBO);

       //objUBO.JOBNO = EXPORT_JOBNO;
       //objUBO.Ename = "get_MAX_Invoice_SlNo";
       //objUBO.Xml_D = "";

       EXU.JOBNO = EXPORT_JOBNO;
       EXU.Xml_D = "";
       EXU.Branch_Code = SELECT_BRANCH;
       EXU.Ename = "get_MAX_Invoice_SlNo";
       ds = EXU.Select_Exp_INV();

       Is_Additional_INV = "YES";

       if (ds.Tables[0].Rows.Count > 0)
       {
           MAX_INVOICE_SLNO =  ds.Tables[0].Rows[0][0].ToString();
           Excel_Upload_load(MAX_INVOICE_SLNO, Is_Additional_INV);
       }


       /*
       objUBO.IEC_NO = EXPORT_JOBNO;
       objUBO.BRANCH_NO = "";
       objUBO.Ename = "Delete_Excel";
       objUBO.WORKING_PERIOD = SELECT_BRANCH;
       ds = xl.Bind_Export_General_IEC_No(objUBO);
       i = xl.result;

       if (i == 1)
       {
           Alert_msg("Job Deleted Successfully");
           MP_U.Hide();
       }
       else
       {
           Alert_msg("Error File");
       }
       */
   }

   public void Bind_General_Details(DataTable General_data)
   {
       if (Is_Additional_INV != "YES")
       {

           #region dt_gen
           dt_gen.Columns.Add("JOBID");
           dt_gen.Columns.Add("JOBNO");
           dt_gen.Columns.Add("JOBDATE");
           dt_gen.Columns.Add("TRANSPORT_MODE");
           dt_gen.Columns.Add("CUSTOMS_HOUSE");
           dt_gen.Columns.Add("CUSTOMS_HOUSE_NAME");
           dt_gen.Columns.Add("SB_TYPE");
           dt_gen.Columns.Add("EXPORTER_NAME");
           dt_gen.Columns.Add("BRANCH_NO");
           dt_gen.Columns.Add("IEC_NO");
           dt_gen.Columns.Add("ADDRESS1");
           dt_gen.Columns.Add("ADDRESS2");
           dt_gen.Columns.Add("ADDRESS3");
           dt_gen.Columns.Add("ADDRESS4");
           dt_gen.Columns.Add("ADDRESS5");
           dt_gen.Columns.Add("ADCODE");
           dt_gen.Columns.Add("BANK_ACCOUNT ");
           dt_gen.Columns.Add("DRAWBACK_ACCOUNT");
           dt_gen.Columns.Add("CONSIGNEE_NAME");
           dt_gen.Columns.Add("CONSIGNEE_ADD1");
           dt_gen.Columns.Add("CONSIGNEE_ADD2");
           dt_gen.Columns.Add("CONSIGNEE_ADD3");
           dt_gen.Columns.Add("CONSIGNEE_ADD4");
           dt_gen.Columns.Add("CONSIGNEE_ADD5");
           dt_gen.Columns.Add("COUNTRY_DISCHARGE");
           dt_gen.Columns.Add("PORT_DISCHARGE");
           dt_gen.Columns.Add("COUNTRY_FINAL_DEST");
           dt_gen.Columns.Add("PORT_FINAL_DEST");
           dt_gen.Columns.Add("STATE_OF_EXPORT");
           dt_gen.Columns.Add("NFEI");
           dt_gen.Columns.Add("NFEI_TYPE");
           dt_gen.Columns.Add("RBI_WAIVER_NO");
           dt_gen.Columns.Add("RBI_WAIVER_DATE");
           dt_gen.Columns.Add("MARKS_NO");
           dt_gen.Columns.Add("USERID");
           dt_gen.Columns.Add("LoginDate");
           dt_gen.Columns.Add("LoginSTATUS");
           dt_gen.Columns.Add("BRANCHCODE");
           dt_gen.Columns.Add("WORKINGPERIOD");
           dt_gen.Columns.Add("FILE_REF_NO");
           dt_gen.Columns.Add("JOB_STATUS");
           dt_gen.Columns.Add("JOB_RELEASE");
           dt_gen.Columns.Add("JOB_FILED_STATUS");
           dt_gen.Columns.Add("MODIFIEDBY");
           dt_gen.Columns.Add("MODIFIEDON");
           dt_gen.Columns.Add("TYPE_OF_EXPORTER");
           dt_gen.Columns.Add("JOB_PREFIX");
           dt_gen.Columns.Add("JOB_SUFFIX");
           dt_gen.Columns.Add("JOBNO_PS");
           dt_gen.Columns.Add("CONSIGNEE_BRANCHSLNO");
           dt_gen.Columns.Add("GSTN_TYPE");
           dt_gen.Columns.Add("GSTN_ID");

           dt_gen.Columns.Add("PARTY_REF_NO");
           dt_gen.Columns.Add("CARTING_POINT");
           dt_gen.Columns.Add("IFSC_CODE");
           dt_gen.Columns.Add("GROUP_ID");
           dt_gen.Columns.Add("FRT_JOBNO");
           dt_gen.Columns.Add("FRT_GROUPID");
           dt_gen.Columns.Add("FRT_BRANCHCODE");
           dt_gen.Columns.Add("AMENDMENT_TYPE");
           dt_gen.Columns.Add("AMENDMENT_STATUS");
           dt_gen.Columns.Add("PORT_OF_LOADING");

           #endregion dt_gen

           int xx, yy;
           ViewState["General_data"] = General_data;


           FILE_REF_NO = "";
           CUSTOMS_HOUSE = General_data.Rows[0][17].ToString().Trim();
           IEC_NO = General_data.Rows[0][0].ToString().Trim();
           BRANCH_NO = General_data.Rows[0][1].ToString().Trim() == string.Empty ? "0" : General_data.Rows[0][1].ToString().Trim();
           EXPORTER_NAME = General_data.Rows[0][3].ToString().Trim();

           xx = Check_Avail_IEC_Master(IEC_NO, BRANCH_NO, "Check_Avail_IEC_details");

           if (xx == 1)
           {
               if (ADDRESS1 == "")
               {
                   if (IEC_NO != "" && BRANCH_NO != "")
                   {
                       ds_IEC = Get_Importer_HSS_Details(IEC_NO, BRANCH_NO);

                       if (ds_IEC.Tables[0].Rows.Count > 0)
                       {
                           EXPORTER_NAME = ds_IEC.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString().Trim();
                           ADDRESS1 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString().Trim();
                           ADDRESS2 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString().Trim();
                           ADDRESS3 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString().Trim();
                           ADDRESS4 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString().Trim();
                           ADDRESS5 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString().Trim();

                       }
                   }
               }
               else
               {
                   EXPORTER_NAME = General_data.Rows[0][3].ToString().Trim();
                   ADDRESS1 = General_data.Rows[0][4].ToString().Trim();
                   ADDRESS2 = General_data.Rows[0][5].ToString().Trim();
                   ADDRESS3 = General_data.Rows[0][6].ToString().Trim();
                   ADDRESS4 = General_data.Rows[0][7].ToString().Trim();
                   ADDRESS5 = General_data.Rows[0][8].ToString().Trim();
               }
           }
           else
           {
               erm.IMP_EXP_ID = "";
               erm.IMP_EXP_NAME = General_data.Rows[0][3].ToString().Trim();
               erm.IMP_EXP_IECNO = IEC_NO.Trim();
               erm.IMP_EXP_BRSLNO = BRANCH_NO.Trim();

               if (General_data.Rows[0][12].ToString() == "G")
               {
                   erm.IMP_EXP_TYPE = "GOVERNMENT";
               }
               else
               {
                   erm.IMP_EXP_TYPE = "OTHERS";
               }
               erm.IMP_EXP_ADD1 = General_data.Rows[0][4].ToString().Trim();
               erm.IMP_EXP_ADD2 = General_data.Rows[0][5].ToString().Trim();
               erm.IMP_EXP_ADD3 = General_data.Rows[0][6].ToString().Trim();
               erm.IMP_EXP_ADD4 = General_data.Rows[0][7].ToString().Trim();
               erm.IMP_EXP_PIN_CODE = General_data.Rows[0][8].ToString().Trim();
               erm.IMP_EXP_CONTACT_PERSON = "";
               erm.IMP_EXP_PHONE = "";

               erm.IMP_EXP_FAX = "";
               erm.IMP_EXP_EMAIL = "";
               erm.IMP_EXP_BINNO = "";
               erm.IMP_EXP_REMARKS = "";
               erm.IMP_EXP_DRAWBACK_AC_NO = "";
               erm.IMP_EXP_PAN_NO = "";

               erm.STANDARD_TYPE = null;
               erm.TIN_NO = "";

              
               //erm.STATE_CODE = AdminManipulation.Get_Statename(General_data.Rows[0][22].ToString());

               if (General_data.Rows[0][22].ToString().Length == 1)
               {
                   statecode = "0" + General_data.Rows[0][22].ToString().Trim();
               }
               else
               {
                   statecode = General_data.Rows[0][22].ToString().Trim();
               }
               erm.STATE_CODE = AdminManipulation.Get_Statename(statecode);

               if (General_data.Rows[0][7].ToString().Trim() == "")
               {
                   erm.IMP_EXP_ADD4 = erm.STATE_CODE;
               }

               erm.USER_ID = currentuser;
               erm.BRANCH_CODE = currentbranch;
               erm.flag = "S";
               erm.YEAR = "";
               erm.EWorking_Period = Working_Period;
               erm.EXP_STR_YN = "";

               TYPE_OF_EXPORTER = General_data.Rows[0][10].ToString().Trim();            

               if (TYPE_OF_EXPORTER == "M")
               {
                   erm.TYPE_OF_EXPORTER = "F";
               }
               else
               {
                   erm.TYPE_OF_EXPORTER = "R";
               }
               erm.MARKS_NO = General_data.Rows[0][23].ToString().Trim();

               erm.COMMERCIAL_DETAILS_STATUS = "N";
               erm.COMMERCIAL_TAX_STATENAME = "";
               erm.COMMERCIAL_TAX_STATECODE = "";
               erm.COMMERCIAL_TAX_TYPE = "";
               erm.COMMERCIAL_TAX_REGISTRATION_NO = "";

               if (General_data.Rows[0][115].ToString() != "")
               {
                   erm.GSTN_TYPE = General_data.Rows[0][115].ToString().Substring(0, 3).Trim();
               }
               else
               {
                   erm.GSTN_TYPE = "";
               }
               erm.GSTN_ID = General_data.Rows[0][116].ToString().Trim();

               i = erm.Imp_Exp_Master_Insert_update_STD();
           }

           /* hide on 28-08-2024
           EXPORTER_NAME = General_data.Rows[0][3].ToString().Trim();
           ADDRESS1 = General_data.Rows[0][4].ToString().Trim();
           ADDRESS2 = General_data.Rows[0][5].ToString().Trim();
           ADDRESS3 = General_data.Rows[0][6].ToString().Trim();
           ADDRESS4 = General_data.Rows[0][7].ToString().Trim();
           ADDRESS5 = General_data.Rows[0][8].ToString().Trim();
           */

           TYPE_OF_EXPORTER = General_data.Rows[0][10].ToString().Trim();

           if (TYPE_OF_EXPORTER == "M")
           {
               TYPE_OF_EXPORTER = "F";
           }
           else
           {
               TYPE_OF_EXPORTER = "R";
           }

           if (General_data.Rows[0][18].ToString() == General_data.Rows[0][20].ToString())
           {
               COUNTRY_DISCHARGE = AdminManipulation.Get_Countryname(General_data.Rows[0][18].ToString());
               COUNTRY_FINAL_DEST = COUNTRY_DISCHARGE;
           }
           else
           {
               COUNTRY_DISCHARGE = AdminManipulation.Get_Countryname(General_data.Rows[0][18].ToString());
               COUNTRY_FINAL_DEST = AdminManipulation.Get_Countryname(General_data.Rows[0][20].ToString());
           }

           if (General_data.Rows[0][19].ToString() == General_data.Rows[0][21].ToString())
           {
               PORT_DISCHARGE = AdminManipulation.Get_Portname(General_data.Rows[0][19].ToString());
               PORT_FINAL_DEST = PORT_DISCHARGE;
           }
           else
           {
               PORT_DISCHARGE = AdminManipulation.Get_Portname(General_data.Rows[0][19].ToString());
               PORT_FINAL_DEST = AdminManipulation.Get_Portname(General_data.Rows[0][21].ToString());
           }

           if (General_data.Rows[0][22].ToString().Contains('-'))
           {
               string[] aa = General_data.Rows[0][22].ToString().Split('-');
               STATE_OF_EXPORT = aa[1].Trim();
               txtStateExport.Text = STATE_OF_EXPORT;
           }
           else
           {
               if (General_data.Rows[0][22].ToString().Length == 1)
               {
                   statecode = "0" + General_data.Rows[0][22].ToString().Trim();
               }
               else
               {
                   statecode = General_data.Rows[0][22].ToString().Trim();
               }
               STATE_OF_EXPORT = AdminManipulation.Get_Statename(statecode);
               txtStateExport.Text = STATE_OF_EXPORT;
           }

           if (COUNTRY_DISCHARGE != "")
           {
               txtCountryOrigin.Text = COUNTRY_DISCHARGE.Trim();
           }
           else
           {
               COUNTRY_DISCHARGE = txtCountryOrigin.Text.Trim();
           }

           if (COUNTRY_FINAL_DEST != "")
           {

           }
           else
           {
               COUNTRY_FINAL_DEST = COUNTRY_DISCHARGE.Trim();
           }

           if (PORT_DISCHARGE != "")
           {
               txtPortShipment.Text = PORT_DISCHARGE.Trim();
           }
           else
           {
               PORT_DISCHARGE = txtPortShipment.Text.Trim();
           }

           if (PORT_FINAL_DEST != "")
           {

           }
           else
           {
               PORT_FINAL_DEST = PORT_DISCHARGE.Trim();
           }

           MARKS_NO = General_data.Rows[0][23].ToString().Trim();
           ADCODE = General_data.Rows[0][2].ToString().Trim();
           CONSIGNEE_NAME = General_data.Rows[0][11].ToString().Trim();
           CONSIGNEE_BRANCHSLNO = "";
           CONSIGNEE_ADD1 = General_data.Rows[0][12].ToString().Trim();

           ds_IEC.Clear();
           yy = Check_Avail_IEC_Master(CONSIGNEE_NAME, CONSIGNEE_BRANCHSLNO, "Check_Avail_CONSIGNEE_details");

           if (yy == 1)
           {
               if (CONSIGNEE_ADD1 == "")
               {
                   //ds_IEC = Get_Importer_HSS_Details(IEC_NO, BRANCH_NO);
                   if (ds_IEC.Tables[0].Rows.Count > 0)
                   {
                       EXPORTER_NAME = ds_IEC.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString().Trim();
                       CONSIGNEE_ADD1 = ds_IEC.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString().Trim();
                       CONSIGNEE_ADD2 = ds_IEC.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString().Trim();
                       CONSIGNEE_ADD3 = ds_IEC.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString().Trim();
                       CONSIGNEE_ADD4 = ds_IEC.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString().Trim();
                       CONSIGNEE_ADD5 = ds_IEC.Tables[0].Rows[0]["CONSIGNEE_COUNTRY_NAME"].ToString().Trim();
                   }
               }
               else
               {
                   CONSIGNEE_ADD1 = General_data.Rows[0][12].ToString().Trim();
                   CONSIGNEE_ADD2 = General_data.Rows[0][13].ToString().Trim();
                   CONSIGNEE_ADD3 = General_data.Rows[0][14].ToString().Trim();
                   CONSIGNEE_ADD4 = General_data.Rows[0][15].ToString().Trim();
                   CONSIGNEE_ADD5 = General_data.Rows[0][16].ToString().Trim();
               }
           }
           else
           {
               erm.CONSIGNEE_ID = "";
               erm.CONSIGNEE_NAME = General_data.Rows[0][11].ToString().Trim();
               erm.CONSIGNEE_ADD1 = General_data.Rows[0][12].ToString().Trim();
               erm.CONSIGNEE_ADD2 = General_data.Rows[0][13].ToString().Trim();
               erm.CONSIGNEE_ADD3 = General_data.Rows[0][14].ToString().Trim();
               erm.CONSIGNEE_ADD4 = General_data.Rows[0][15].ToString().Trim();
               erm.CONSIGNEE_COUNTRY_CODE = "";
               erm.CONSIGNEE_COUNTRY_NAME = General_data.Rows[0][16].ToString().Trim();
               erm.CONSIGNEE_PIN_CODE = "";
               erm.CONSIGNEE_REMARKS = "";
               erm.CONSIGNEE_BRANCHSLNO = "";

               erm.USER_ID = currentuser;
               erm.BRANCH_CODE = currentbranch;
               erm.flag = "S";
               erm.YEAR = "";
               erm.EWorking_Period = Working_Period;

               i = erm.Consignee_Master_Insert_update();
           }

           /* hide on 28-08-2024
           CONSIGNEE_ADD1 = General_data.Rows[0][12].ToString().Trim();
           CONSIGNEE_ADD2 = General_data.Rows[0][13].ToString().Trim();
           CONSIGNEE_ADD3 = General_data.Rows[0][14].ToString().Trim();
           CONSIGNEE_ADD4 = General_data.Rows[0][15].ToString().Trim();
           CONSIGNEE_ADD5 = General_data.Rows[0][16].ToString().Trim();
           */

           NFEI = General_data.Rows[0][25].ToString();

           if (NFEI == "" || NFEI == "N")
           {
               NFEI = "No";
               NFEI_TYPE = "";
               RBI_WAIVER_NO = "";
               RBI_WAIVER_DATE = General_data.Rows[0][28].ToString() == string.Empty ? "01/01/1900" : General_data.Rows[0][28].ToString().Trim();
           }
           else
           {
               NFEI = "Yes";
               NFEI_TYPE = General_data.Rows[0][26].ToString().Trim();
               RBI_WAIVER_NO = General_data.Rows[0][27].ToString().Trim();
               RBI_WAIVER_DATE = General_data.Rows[0][28].ToString() == string.Empty ? "01/01/1900" : General_data.Rows[0][28].ToString().Trim();
           }
           if (General_data.Rows[0][115].ToString() != "")
           {
               GSTN_TYPE = General_data.Rows[0][115].ToString().Substring(0, 3).Trim();
           }
           else
           {
               GSTN_TYPE = "";
           }
           GSTN_ID = General_data.Rows[0][116].ToString().Trim();

           JOBID = Convert.ToString(Get_general_MAXID("Gen_MAX_ID"));
           
           SB_TYPE = "Free Duty";
           JOB_RELEASE = "No";
           JOB_FILED_STATUS = "Created";
           TRANSPORT_MODE = AdminManipulation.Get_Transport_Mode(CUSTOMS_HOUSE);

           Get_MaxJobno();
           JobNo_Prefix_Sufix();

           dt_gen.Rows.Add(JOBID, EXPORT_JOBNO, JOBDATE, TRANSPORT_MODE, CUSTOMS_HOUSE, CUSTOMS_HOUSE_NAME, SB_TYPE, EXPORTER_NAME, BRANCH_NO, IEC_NO, ADDRESS1, ADDRESS2, ADDRESS3, ADDRESS4, ADDRESS5,
                           ADCODE, BANK_ACCOUNT, DRAWBACK_ACCOUNT, CONSIGNEE_NAME, CONSIGNEE_ADD1, CONSIGNEE_ADD2, CONSIGNEE_ADD3, CONSIGNEE_ADD4, CONSIGNEE_ADD5, COUNTRY_DISCHARGE,
                           PORT_DISCHARGE, COUNTRY_FINAL_DEST, PORT_FINAL_DEST, STATE_OF_EXPORT, NFEI, NFEI_TYPE, RBI_WAIVER_NO, RBI_WAIVER_DATE, MARKS_NO, currentuser, LoginDate,
                           "N", currentbranch, Working_Period, FILE_REF_NO, JOB_STATUS, JOB_RELEASE, JOB_FILED_STATUS, currentuser, LoginDate, TYPE_OF_EXPORTER, JOB_PREFIX, JOB_SUFFIX, JOBNO_PS, CONSIGNEE_BRANCHSLNO,
                           GSTN_TYPE, GSTN_ID, "", "", "", "0", "0", "0", "", "", "", "");

           if (dt_gen.Rows.Count > 0)
           {
               admin.SqlBulk_Upload_Product("EXPORT_GENERAL_DETAILS", dt_gen, comp_ConnectionStr);
           }

           if (General_data.Rows[0][36].ToString() != "")
           {
               Annexure_Air_Sea_Insert(General_data);
           }
       }

           Bind_InvoiceUpload_SAHI(General_data);

   }

   public void Annexure_Air_Sea_Insert(DataTable General_data)
   {
       if (TRANSPORT_MODE == "Sea" || TRANSPORT_MODE == "Land")
       {
           ANNEX_C_Sea.ANNEX_SEA_JOBNO = EXPORT_JOBNO;
           // ANNEX_C_Sea.ANNEX_SEA_FAC_STUFFED = txtFactory_Stuffed.Text;
           //ANNEX_C_Sea.ANNEX_SEA_SAMPLE_ACCOM = txtSample_Accompanied.Text;
           ANNEX_C_Sea.ANNEX_SEA_FAC_STUFFED = General_data.Rows[0][30].ToString().Trim();
           ANNEX_C_Sea.ANNEX_SEA_SAMPLE_ACCOM = "N";

           ANNEX_C_Sea.ANNEX_SEA_NATURE_OF_CARGO = General_data.Rows[0][36].ToString().Trim();
           ANNEX_C_Sea.ANNEX_SEA_MARKS_NOS = General_data.Rows[0][23].ToString().Trim();
           ANNEX_C_Sea.ANNEX_SEA_TOTAL_PACKAGES = General_data.Rows[0][31].ToString().Trim();
           ANNEX_C_Sea.ANNEX_SEA_LOOSE_PACKETS = General_data.Rows[0][32].ToString().Trim();
           ANNEX_C_Sea.ANNEX_SEA_NO_CONTAINERS = "";
           ANNEX_C_Sea.ANNEX_SEA_GROSS_WEIGHT = General_data.Rows[0][33].ToString().Trim();
           ANNEX_C_Sea.ANNEX_SEA_NET_WEIGHT = General_data.Rows[0][34].ToString().Trim();
           ANNEX_C_Sea.ANNEX_SEA_UNIT_MEASUREMENT = General_data.Rows[0][35].ToString().Trim();
           ANNEX_C_Sea.ANNEX_SEA_ROTATION_NO = "";
           ANNEX_C_Sea.ANNEX_SEA_ROTATION_DATE = "01/01/1900";
           ANNEX_C_Sea.ANNEX_SEA_FOB_VALUE = "";

           ANNEX_C_Sea.USER_ID = currentuser;
           ANNEX_C_Sea.flag = "S";
           ANNEX_C_Sea.BRANCH_CODE = currentbranch;
           ANNEX_C_Sea.WORKING_PERIOD = Working_Period;
           ANNEX_C_Sea.BRANCH_COMMON = SELECT_BRANCH;
           ANNEX_C_Sea.ANNEX_SEA_SEAL_TYPE = "";
           i = ANNEX_C_Sea.Annexure_C_Sea_details_insertupdate();
       }
       else if (TRANSPORT_MODE == "Air")
       {
           ANNEX_C_Air.ANNEX_AIR_JOBNO = EXPORT_JOBNO;
           ANNEX_C_Air.ANNEX_AIR_SEALNO = "N";
           ANNEX_C_Air.ANNEX_AIR_SEAL_AGENCY = "N";

           ANNEX_C_Air.ANNEX_AIR_NATURE_OF_CARGO = General_data.Rows[0][36].ToString().Trim();
           ANNEX_C_Air.ANNEX_AIR_MARKS_NOS = General_data.Rows[0][23].ToString().Trim();
           ANNEX_C_Air.ANNEX_AIR_TOTAL_PACKAGES = General_data.Rows[0][31].ToString().Trim();
           ANNEX_C_Air.ANNEX_AIR_UNIT_CODE = "PKG";
           ANNEX_C_Air.ANNEX_AIR_FREIGHT_AMT = "";
           ANNEX_C_Air.ANNEX_AIR_INSURANCE_AMT = "";
           ANNEX_C_Air.ANNEX_AIR_GROSS_WEIGHT = General_data.Rows[0][33].ToString().Trim();
           ANNEX_C_Air.ANNEX_AIR_GR_UNIT_CODE = General_data.Rows[0][35].ToString().Trim();
           ANNEX_C_Air.ANNEX_AIR_NET_WEIGHT = General_data.Rows[0][34].ToString().Trim();
           ANNEX_C_Air.ANNEX_AIR_MAWB_NO = "";
           ANNEX_C_Air.ANNEX_AIR_HAWB_NO = "";
           ANNEX_C_Air.ANNEX_AIR_TOTAL_PACKAGES_MAWB = "";
           ANNEX_C_Air.ANNEX_AIR_ROTATION_NO = "";
        
           ANNEX_C_Air.ANNEX_AIR_ROTATION_DATE = "01/01/1900";
           ANNEX_C_Air.ANNEX_AIR_FOB_VALUE = "";

           ANNEX_C_Air.USER_ID = currentuser;
           ANNEX_C_Air.flag = "S";
           ANNEX_C_Air.BRANCH_CODE = currentbranch;
           ANNEX_C_Air.WORKING_PERIOD = Working_Period;
           ANNEX_C_Air.BRANCH_COMMON = SELECT_BRANCH;

           i = ANNEX_C_Air.Annexure_C_Air_details_insertupdate();
       }
       else
       {
       }
   }

   public void Bind_InvoiceUpload_SAHI(DataTable Inv_data)
   {
       GET_LICENSE_ID();
       string RODTEp = "";
       

       if (Is_Additional_INV != "YES")
       {
           ds = (DataSet)ViewState["ds_Excel_upload"];
       }
       else
       {
           DataTable dttt = (DataTable)ViewState["ds_Excel_upload"];
           ds.Tables.Add(dttt);
       }

      
       ds.Tables[0].Rows.Add();
       int SW_slno_cnt = 1;

       if (ds.Tables[0].Rows.Count > 0)
       {
           DataView view = new DataView(ds.Tables[0]);
           DataTable distinctValues = view.ToTable(true, "INVSLNO", "INVOICENO");

           DataTable filteredRows = distinctValues.Rows.Cast<DataRow>()
            .Where(row => !row.ItemArray.All(field => field is System.DBNull)).CopyToDataTable();

           #region Table_Headers

           dsXML.Tables.Add("InvoiceDetails");

           // dsXML.Tables[0].Columns.Add("JOBDATE", typeof(DateTime));
           dsXML.Tables[0].Columns.Add("JOBDATE");
           dsXML.Tables[0].Columns.Add("INVOICE_SLNO");
           dsXML.Tables[0].Columns.Add("INVOICE_NO");
           dsXML.Tables[0].Columns.Add("INVOICE_DATE");
           dsXML.Tables[0].Columns.Add("PAYMENT_METHOD");
           dsXML.Tables[0].Columns.Add("PERIOD_PAYMENT");
           dsXML.Tables[0].Columns.Add("INVOICE_VALUE");
           dsXML.Tables[0].Columns.Add("INVOICE_CURRENCY");
           dsXML.Tables[0].Columns.Add("EXCHANGE_RATE");
           dsXML.Tables[0].Columns.Add("CONTRACT_NO");
           dsXML.Tables[0].Columns.Add("TERMS");

           dsXML.Tables[0].Columns.Add("COMMISSION_RATE");
           dsXML.Tables[0].Columns.Add("COMMISSION_CHARGES");
           dsXML.Tables[0].Columns.Add("COMMISSION_CURRENCY");

           dsXML.Tables[0].Columns.Add("FOB_RATE");
           dsXML.Tables[0].Columns.Add("FOB_CHARGES");
           dsXML.Tables[0].Columns.Add("FOB_CURRENCY");

           dsXML.Tables[0].Columns.Add("PACKMISC_RATE");
           dsXML.Tables[0].Columns.Add("PACKMISC_CHARGES");
           dsXML.Tables[0].Columns.Add("PACKMISC_CURRENCY");

           dsXML.Tables[0].Columns.Add("OTHER_DEDUCTION_RATE");
           dsXML.Tables[0].Columns.Add("OTHER_DEDUCTION_CHARGES");
           dsXML.Tables[0].Columns.Add("OTHER_DEDUCTION_CURRENCY");

           dsXML.Tables[0].Columns.Add("FREIGHT_RATE");
           dsXML.Tables[0].Columns.Add("FREIGHT_CHARGES");
           dsXML.Tables[0].Columns.Add("FREIGHT_CURRENCY");
           dsXML.Tables[0].Columns.Add("FREIGHT_EXRATE");

           dsXML.Tables[0].Columns.Add("INSURANCE_RATE");
           dsXML.Tables[0].Columns.Add("INSURANCE_CHARGES");
           dsXML.Tables[0].Columns.Add("INSURANCE_CURRENCY");
           dsXML.Tables[0].Columns.Add("INSURANCE_EXRATE");
           dsXML.Tables[0].Columns.Add("WHEATHER_UNIT_PRICE");

           dsXML.Tables[0].Columns.Add("BUYER");
           dsXML.Tables[0].Columns.Add("BUYER_NAME");
           dsXML.Tables[0].Columns.Add("BUYER_ADDRESS");
           dsXML.Tables[0].Columns.Add("BUYER_ADDRESS1");
           dsXML.Tables[0].Columns.Add("BUYER_ADDRESS2");
           dsXML.Tables[0].Columns.Add("BUYER_ADDRESS3");
           dsXML.Tables[0].Columns.Add("BUYER_ADDRESS4");

           //--------------------Item Details--------------------------//
           dsXML.Tables.Add("ItemDetails");
           dsXML.Tables[1].Columns.Add("INVOICE_SLNO");
           dsXML.Tables[1].Columns.Add("INVOICE_NO");
           dsXML.Tables[1].Columns.Add("ITEM_SLNO");
           dsXML.Tables[1].Columns.Add("ITEM_DESCRIPTION");
           dsXML.Tables[1].Columns.Add("RITCNO");
           dsXML.Tables[1].Columns.Add("ITEM_QTY");
           dsXML.Tables[1].Columns.Add("ITEM_QTY_CODE");
           dsXML.Tables[1].Columns.Add("ITEM_UNIT_PRICE");
           dsXML.Tables[1].Columns.Add("ITEM_PER");
           dsXML.Tables[1].Columns.Add("ITEM_AMOUNT", typeof(double));
           dsXML.Tables[1].Columns.Add("ITEM_PMVVALUE");
           dsXML.Tables[1].Columns.Add("ITEM_SCHEME_CODE");
           dsXML.Tables[1].Columns.Add("ITEM_ACCESSORIES_DESC");
           dsXML.Tables[1].Columns.Add("ITEM_IECCODE");
           dsXML.Tables[1].Columns.Add("BR_SLNO");
           dsXML.Tables[1].Columns.Add("ITEM_EXPORTER_NAME");
           dsXML.Tables[1].Columns.Add("ADDRESS1");
           dsXML.Tables[1].Columns.Add("ADDRESS2");
           dsXML.Tables[1].Columns.Add("ADDRESS3");
           dsXML.Tables[1].Columns.Add("ADDRESS4");
           dsXML.Tables[1].Columns.Add("ADDRESS5");
           dsXML.Tables[1].Columns.Add("ITEM_STR_CODE");
           dsXML.Tables[1].Columns.Add("REWARD_POINTS");

           dsXML.Tables[1].Columns.Add("MANUFACTURER_PRODUCER");
           dsXML.Tables[1].Columns.Add("M_P_GROWER_CODE");
           dsXML.Tables[1].Columns.Add("M_P_GROWER_ADD1");
           dsXML.Tables[1].Columns.Add("M_P_GROWER_ADD2");
           dsXML.Tables[1].Columns.Add("M_P_GROWER_CITY");
           dsXML.Tables[1].Columns.Add("M_P_GROWER_COUNTRY_SUBDIV");
           dsXML.Tables[1].Columns.Add("M_P_GROWER_PIN");
           dsXML.Tables[1].Columns.Add("M_P_GROWER_COUNTRY");
           dsXML.Tables[1].Columns.Add("SOURCE_STATE");

           dsXML.Tables[1].Columns.Add("TRANSIT_COUNTRY");
           dsXML.Tables[1].Columns.Add("ACCESSORY_STATUS");
           dsXML.Tables[1].Columns.Add("HAWB_NO");
           dsXML.Tables[1].Columns.Add("TOTAL_PKGS");
           dsXML.Tables[1].Columns.Add("ENDUSE_ITEM");
           dsXML.Tables[1].Columns.Add("IGST_PAYMENT");
           dsXML.Tables[1].Columns.Add("TAXABLE_VALUE");
           dsXML.Tables[1].Columns.Add("IGST_AMT");


           dsXML.Tables[1].Columns.Add("GSTN_TYPE");
           dsXML.Tables[1].Columns.Add("GSTN_ID");
           dsXML.Tables[1].Columns.Add("RODTEP");

           //--------------------Drawback Details--------------------------//
           dsXML.Tables.Add("Drawback_Details");

           dsXML.Tables[2].Columns.Add("INVOICE_SLNO");
           dsXML.Tables[2].Columns.Add("ITEM_SLNO");
           dsXML.Tables[2].Columns.Add("SCHEME_CODE");
           dsXML.Tables[2].Columns.Add("DRAWBACK_SLNO");
           dsXML.Tables[2].Columns.Add("DRAWBACK_QTY");
           dsXML.Tables[2].Columns.Add("DRAWBACK_UNIT");
           dsXML.Tables[2].Columns.Add("DRAWBACK_NOOFUNITS");
           dsXML.Tables[2].Columns.Add("DRAWBACK_RATE");

           dsXML.Tables[2].Columns.Add("DRAWBACK_CAPS");
           dsXML.Tables[2].Columns.Add("DRAWBACK_DESC");
           dsXML.Tables[2].Columns.Add("STATE_LEVEL_ADV_RATE");
           dsXML.Tables[2].Columns.Add("STATE_LEVEL_ADV_AMT");
           dsXML.Tables[2].Columns.Add("CENTRAL_LEVEL_ADV_RATE");
           dsXML.Tables[2].Columns.Add("CENTRAL_LEVEL_ADV_AMT");
           //--------------------License Details--------------------------//
           dsXML.Tables.Add("License_Details");

           dsXML.Tables[3].Columns.Add("LICENSE_ID");
           dsXML.Tables[3].Columns.Add("INV_SL_NO");
           dsXML.Tables[3].Columns.Add("ITEM_SL_NO");
           dsXML.Tables[3].Columns.Add("SCHEME_CODE");
           dsXML.Tables[3].Columns.Add("SCHEME");

           dsXML.Tables[3].Columns.Add("LICENSE_EXP_QTY");
           dsXML.Tables[3].Columns.Add("LICENSE_EXP_UNIT");

           dsXML.Tables[3].Columns.Add("LICENSE_IMP_EXP_ID");
           dsXML.Tables[3].Columns.Add("LICENSE_E_SL_NO");

           dsXML.Tables[3].Columns.Add("LICENSE_NO");
           dsXML.Tables[3].Columns.Add("LICENSE_DATE");

           dsXML.Tables[3].Columns.Add("LICENSE_R_SL_NO");
           dsXML.Tables[3].Columns.Add("LICENSE_REG_DATE", typeof(DateTime));
           dsXML.Tables[3].Columns.Add("LICENSE_REG_TYPE");
           dsXML.Tables[3].Columns.Add("LICENSE_ITEM_SL_NO");
           dsXML.Tables[3].Columns.Add("LICENSE_ITEM_DESCRIPTION");
           dsXML.Tables[3].Columns.Add("LICENSE_QTY");
           dsXML.Tables[3].Columns.Add("LICENSE_UNIT");
           dsXML.Tables[3].Columns.Add("LICENSE_TYPE");


           dsXML.Tables.Add("EXP_SW_STMT");

           ////dsXML.Tables[4].Columns.Add("SW_ID");
           ////dsXML.Tables[4].Columns.Add("JOBNO");
           dsXML.Tables[4].Columns.Add("INVOICE_SLNO");
           dsXML.Tables[4].Columns.Add("ITEM_SLNO");
           dsXML.Tables[4].Columns.Add("SLNO");
           dsXML.Tables[4].Columns.Add("STMT_TYPE");
           dsXML.Tables[4].Columns.Add("STMT_CODE");
           dsXML.Tables[4].Columns.Add("STMT_TEXT");


           dsXML.Tables.Add("EXP_SW_INFO_TYPE");

           //dsXML.Tables[5].Columns.Add("SW_INFO_TYPE_ID");
           //dsXML.Tables[5].Columns.Add("JOBNO");
           dsXML.Tables[5].Columns.Add("INVOICE_SLNO");
           dsXML.Tables[5].Columns.Add("ITEM_SLNO");
           dsXML.Tables[5].Columns.Add("SLNO");
           dsXML.Tables[5].Columns.Add("INFO_TYPE");
           dsXML.Tables[5].Columns.Add("INFO_QUALIFIER");
           dsXML.Tables[5].Columns.Add("INFO_CODE");
           dsXML.Tables[5].Columns.Add("INFO_TEXT");
           dsXML.Tables[5].Columns.Add("INFO_MSR");
           dsXML.Tables[5].Columns.Add("INFO_UQC");
          



           #region dt_AR4
           dt_AR4.Columns.Add("AR4_ID");
           dt_AR4.Columns.Add("AR4_JOBNO");
           dt_AR4.Columns.Add("AR4_NO");
           dt_AR4.Columns.Add("AR4_DATE");
           dt_AR4.Columns.Add("AR4_COMMISSION_RATE");
           dt_AR4.Columns.Add("AR4_DIVISION");
           dt_AR4.Columns.Add("AR4_RANGE");
           dt_AR4.Columns.Add("AR4_REMARKS");
           dt_AR4.Columns.Add("USER_ID");
           dt_AR4.Columns.Add("DATE_TIME");
           dt_AR4.Columns.Add("STATUS");
           dt_AR4.Columns.Add("BRANCH_CODE");
           dt_AR4.Columns.Add("YEAR");
           dt_AR4.Columns.Add("WORKING_PERIOD");
           dt_AR4.Columns.Add("AR4_INVOICE_NO");
           dt_AR4.Columns.Add("AR4_INVOICE_SLNO");
           dt_AR4.Columns.Add("AR4_RUN_ID");
           dt_AR4.Columns.Add("AR4_ITEM_NO");
           dt_AR4.Columns.Add("MODIFIEDBY");
           dt_AR4.Columns.Add("MODIFIEDON");
           #endregion dt_AR4


           #endregion Table_Headers
           //-------------------------------------------------------------//

           for (int a = 0; a < filteredRows.Rows.Count; a++)
           {
               //var query = from r in ds.Tables[0].AsEnumerable()
               //            where (r.Field<string>("INVOICENO") == filteredRows.Rows[a]["INVOICENO"].ToString())
               //                                                        select r;

               string INVSLNO = Convert.ToString(filteredRows.Rows[a]["INVSLNO"].ToString());

               //int INVSLNO = Convert.ToInt32(filteredRows.Rows[a]["INVSLNO"].ToString());

               //var query = from r in ds.Tables[0].AsEnumerable()
               //            where (r.Field<string>("INVSLNO") == filteredRows.Rows[a]["INVSLNO"].ToString())
               //            select r;

               DataTable dtCloned = ds.Tables[0].Clone();
               dtCloned.Columns[37].DataType = typeof(string);
               foreach (DataRow row in ds.Tables[0].Rows)
               {
                   dtCloned.ImportRow(row);
               }

               var query = from r in dtCloned.AsEnumerable()
                           where (r.Field<string>("INVSLNO") == INVSLNO)
                           select r;

               dt_inv_item.Clear();
               int b = 0, c = 0, d = 0, e = 0, f = 0, h = 0;
          
               if (query.Count() > 0)
               {
                   dt_inv_item = query.CopyToDataTable();
                   
               }

               dt_inv_item.Rows.Add();
               DataRow dr = dsXML.Tables[0].NewRow();

               dr["JOBDATE"] = Convert.ToDateTime(Convert.ToDateTime(JOBDATE).ToShortDateString()).ToString(@"MM/dd/yyyy").Trim();

               //dr["JOBDATE"] = JOBDATE;
               dr["INVOICE_SLNO"] = dt_inv_item.Rows[0][37].ToString().Trim();
               dr["INVOICE_NO"] = dt_inv_item.Rows[0][38].ToString().Trim();

               //string inv_date = Convert.ToDateTime(dt_inv_item.Rows[0][39].ToString().Trim()).ToShortDateString();// getting error hide on 16/11/2018
               //string inv_date1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dt_inv_item.Rows[0][39].ToString().Trim()));
               //DateTime ddd = new DateTime();
               //ddd = Convert.ToDateTime(inv_date1).ToString(@"MM/dd/yyyy");
               //dr["INVOICE_DATE"] = Convert.ToDateTime(inv_date).ToString(@"MM/dd/yyyy");
               //dr["INVOICE_DATE"] = Convert.ToDateTime(Convert.ToDateTime(inv_date1).ToString(@"MM/dd/yyyy"));
               ////dr["INVOICE_DATE"] = Connection.Date(dt_inv_item.Rows[0][39].ToString().Trim());
               //string invdt = Convert.ToDateTime(Convert.ToDateTime(dt_inv_item.Rows[0][39].ToString().Trim()).ToShortDateString()).ToString(@"MM/dd/yyyy");
               //dr["INVOICE_DATE"] = Convert.ToDateTime(Convert.ToDateTime(dt_inv_item.Rows[0][39].ToString().Trim()).ToShortDateString()).ToString(@"MM/dd/yyyy");
               ////string invdt = Convert.ToString(Convert.ToDateTime(Convert.ToDateTime(dt_inv_item.Rows[0][39].ToString().Trim()).ToShortDateString()).ToString(@"MM/dd/yyyy"));
               //dr["INVOICE_DATE"] = invdt;

               //string dateFormat = "MM/dd/yyyy";  // change this value based on your format
               //DateTime FromDate;
               //if (!DateTime.TryParseExact(dt_inv_item.Rows[0][39].ToString().Trim(), dateFormat,  CultureInfo.CurrentCulture, DateTimeStyles.None, out FromDate))
               //{
               //    // show the error message to the UI for invalid From Date
               //    return;
               //}
               ////dr["INVOICE_DATE"] = DateTime.Parse(txtVADate.Text.Trim()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

               //string dts = DateTime.Parse(JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

               //string dts = Convert.ToString(DateTime.Parse(dt_inv_item.Rows[0][39].ToString().Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)).Substring(0, 10);
               //dr["INVOICE_DATE"] = Connection.Date(dts);

               dr["INVOICE_DATE"] = Convert_DateFormate(dt_inv_item.Rows[0][39].ToString().Trim());

               dr["PAYMENT_METHOD"] = dt_inv_item.Rows[0][42].ToString().Trim();
               dr["PERIOD_PAYMENT"] = dt_inv_item.Rows[0][44].ToString().Trim();
               dr["INVOICE_CURRENCY"] = dt_inv_item.Rows[0][40].ToString().Trim();
               dr["EXCHANGE_RATE"] = dt_inv_item.Rows[0][41].ToString().Trim();
               dr["CONTRACT_NO"] = dt_inv_item.Rows[0][43].ToString().Trim();

               if (dt_inv_item.Rows[0][45].ToString() == "NA" || dt_inv_item.Rows[0][45].ToString() == "")
               {
                   if (dt_inv_item.Rows[0][52].ToString() == "" && dt_inv_item.Rows[0][54].ToString() == "")
                   {
                       dr["TERMS"] = "FOB";
                   }
               }
               else
               {
                   dr["TERMS"] = dt_inv_item.Rows[0][45].ToString().Trim();
               }



               dr["BUYER"] = dt_inv_item.Rows[0][46].ToString().Trim();
               if (dt_inv_item.Rows[0][46].ToString() == "Y" || dt_inv_item.Rows[0][46].ToString() == "")
               {
                   dr["BUYER_NAME"] = "SAME AS CONSIGNEE";
                   dr["BUYER_ADDRESS"] = "";
                   dr["BUYER_ADDRESS1"] = "";
                   dr["BUYER_ADDRESS2"] = "";
                   dr["BUYER_ADDRESS3"] = "";
                   dr["BUYER_ADDRESS4"] = "";
                   dr["BUYER"] = "Y";
               }
               else
               {
                   dr["BUYER_NAME"] = dt_inv_item.Rows[0][47].ToString().Trim();
                   dr["BUYER"] = "N";
                   dr["BUYER_ADDRESS"] = dt_inv_item.Rows[0][48].ToString().Trim();
                   dr["BUYER_ADDRESS1"] = dt_inv_item.Rows[0][49].ToString().Trim();
                   dr["BUYER_ADDRESS2"] = dt_inv_item.Rows[0][50].ToString().Trim();
                   dr["BUYER_ADDRESS3"] = dt_inv_item.Rows[0][51].ToString().Trim();
                   dr["BUYER_ADDRESS4"] = "";
               }


               dr["COMMISSION_RATE"] = dt_inv_item.Rows[0][56].ToString().Trim();
               dr["COMMISSION_CHARGES"] = dt_inv_item.Rows[0][57].ToString().Trim();
               dr["COMMISSION_CURRENCY"] = dt_inv_item.Rows[0][40].ToString().Trim();

               dr["FOB_RATE"] = dt_inv_item.Rows[0][58].ToString().Trim();
               dr["FOB_CHARGES"] = dt_inv_item.Rows[0][59].ToString().Trim();
               dr["FOB_CURRENCY"] = dt_inv_item.Rows[0][40].ToString().Trim();

               dr["PACKMISC_RATE"] = dt_inv_item.Rows[0][60].ToString().Trim();
               dr["PACKMISC_CHARGES"] = dt_inv_item.Rows[0][61].ToString().Trim();
               dr["PACKMISC_CURRENCY"] = dt_inv_item.Rows[0][40].ToString().Trim();

               dr["OTHER_DEDUCTION_RATE"] = dt_inv_item.Rows[0][62].ToString().Trim();
               dr["OTHER_DEDUCTION_CHARGES"] = dt_inv_item.Rows[0][63].ToString().Trim();
               dr["OTHER_DEDUCTION_CURRENCY"] = dt_inv_item.Rows[0][40].ToString().Trim();

               dr["FREIGHT_RATE"] = "0.00";
               dr["FREIGHT_CHARGES"] = dt_inv_item.Rows[0][52].ToString().Trim();
               dr["FREIGHT_CURRENCY"] = dt_inv_item.Rows[0][53].ToString().Trim();

               string inv_cur = dr["INVOICE_CURRENCY"].ToString().Trim();
               string fri_cur = dr["FREIGHT_CURRENCY"].ToString().Trim();


               if (dr["FREIGHT_CURRENCY"] != "")
               {
                   if (inv_cur == fri_cur)
                   {
                       dr["FREIGHT_EXRATE"] = dr["EXCHANGE_RATE"];
                   }
                   else
                   {
                       dr["FREIGHT_EXRATE"] = "1";
                   }
               }
               else
               {
                   dr["FREIGHT_EXRATE"] = "";
               }

               dr["INSURANCE_RATE"] = "0.00";
               dr["INSURANCE_CHARGES"] = dt_inv_item.Rows[0][54].ToString().Trim();
               dr["INSURANCE_CURRENCY"] = dt_inv_item.Rows[0][55].ToString().Trim();

               string ins_cur = dr["INSURANCE_CURRENCY"].ToString().Trim();

               if (dr["INSURANCE_CURRENCY"] != "")
               {
                   if (inv_cur == ins_cur)
                   {
                       dr["INSURANCE_EXRATE"] = dr["EXCHANGE_RATE"];
                   }
                   else
                   {
                       dr["INSURANCE_EXRATE"] = "1";
                   }
               }
               else
               {
                   dr["INSURANCE_EXRATE"] = "";
               }

               dr["WHEATHER_UNIT_PRICE"] = "N";


               //--------------------Item Details--------------------------//


               while (dt_inv_item.Rows[b][37] != System.DBNull.Value)
               {
                   DataRow dr1 = dsXML.Tables[1].NewRow();

                   dr1["INVOICE_SLNO"] = dt_inv_item.Rows[b][37].ToString().Trim();
                   dr1["INVOICE_NO"] = dt_inv_item.Rows[b][38].ToString().Trim();
                   dr1["ITEM_SLNO"] = dt_inv_item.Rows[b][64].ToString().Trim();
                   if (dt_inv_item.Rows[b][66].ToString().Length > 120)
                   {
                       dr1["ITEM_DESCRIPTION"] = dt_inv_item.Rows[b][66].ToString().Substring(0, 120);
                   }
                   else
                   {
                       dr1["ITEM_DESCRIPTION"] = dt_inv_item.Rows[b][66].ToString().Trim();
                   }
                   dr1["RITCNO"] = dt_inv_item.Rows[b][65].ToString().Trim();
                   dr1["ITEM_QTY"] = dt_inv_item.Rows[b][67].ToString().Trim();
                   dr1["ITEM_QTY_CODE"] = dt_inv_item.Rows[b][70].ToString().Trim();
                   dr1["ITEM_UNIT_PRICE"] = dt_inv_item.Rows[b][68].ToString().Trim();
                   dr1["ITEM_PER"] = "1";
                   dr1["ITEM_ACCESSORIES_DESC"] = dt_inv_item.Rows[b][72].ToString();

                   if (dt_inv_item.Rows[b][67] != System.DBNull.Value && dt_inv_item.Rows[b][68] != System.DBNull.Value)
                   {
                       item_amt = Convert.ToDecimal(dt_inv_item.Rows[b][67]) * Convert.ToDecimal(dt_inv_item.Rows[b][68]);
                   }
                   else
                   {
                       item_amt = 0;
                   }

                   dr1["ITEM_AMOUNT"] = item_amt;
                   dr1["ITEM_PMVVALUE"] = "";

                   scheme = dt_inv_item.Rows[b][71].ToString();
                   if (scheme.Length == 1)
                   {
                       scheme = "0" + scheme;
                   }

                   if (scheme.Contains('-'))
                   {
                       string[] sp = scheme.Split('-');
                       scheme = sp[0];
                   }

                   Open_Schemecode();

                   dr1["ITEM_SCHEME_CODE"] = scheme;

                   dr1["ITEM_IECCODE"] = dt_inv_item.Rows[b][87].ToString();
                   dr1["BR_SLNO"] = dt_inv_item.Rows[b][88].ToString();

                   dr1["ITEM_EXPORTER_NAME"] = "";
                   dr1["ADDRESS1"] = "";
                   dr1["ADDRESS2"] = "";
                   dr1["ADDRESS3"] = "";
                   dr1["ADDRESS4"] = "";
                   dr1["ADDRESS5"] = "";

                   dr1["ITEM_STR_CODE"] = dt_inv_item.Rows[b][85].ToString();
                   dr1["REWARD_POINTS"] = (dt_inv_item.Rows[b][83].ToString()).Trim() == "Y" ? "Y" : "N";

                   //-----------------29-june-2017-------------
                   dr1["ENDUSE_ITEM"] = dt_inv_item.Rows[b][107].ToString();
                   dr1["IGST_PAYMENT"] = dt_inv_item.Rows[b][108].ToString();
                   dr1["TAXABLE_VALUE"] = dt_inv_item.Rows[b][109].ToString();
                   dr1["IGST_AMT"] = dt_inv_item.Rows[b][110].ToString();

                   dr1["MANUFACTURER_PRODUCER"] = "";
                   dr1["M_P_GROWER_CODE"] = "";
                   dr1["M_P_GROWER_ADD1"] = "";
                   dr1["M_P_GROWER_ADD2"] = "";
                   dr1["M_P_GROWER_CITY"] = "";
                   dr1["M_P_GROWER_COUNTRY_SUBDIV"] = "";
                   dr1["M_P_GROWER_PIN"] = "";
                   dr1["M_P_GROWER_COUNTRY"] = "";
                   dr1["SOURCE_STATE"] = "";
                   dr1["TRANSIT_COUNTRY"] = "";
                   dr1["ACCESSORY_STATUS"] = "";
                   dr1["HAWB_NO"] = "";
                   dr1["TOTAL_PKGS"] = "";

                   dr1["GSTN_TYPE"] = "";
                   dr1["GSTN_ID"] = "";
                   //dr1["RODTEP"] = dt_inv_item.Rows[b][123].ToString();
                   dr1["RODTEP"] = "N";


                   if (Session["COMPANY_ID"].ToString() == "442" || Session["COMPANY_ID"].ToString() == "438" || Session["COMPANY_ID"].ToString() == "436" || Session["COMPANY_ID"].ToString() == "443" || Session["COMPANY_ID"].ToString() == "435" || Session["COMPANY_ID"].ToString() == "434" || Session["COMPANY_ID"].ToString() == "402" || Session["COMPANY_ID"].ToString() == "459" || Session["COMPANY_ID"].ToString() == "444" || Session["COMPANY_ID"].ToString() == "457" || Session["COMPANY_ID"].ToString() == "477" || Session["COMPANY_ID"].ToString() == "478" || Session["COMPANY_ID"].ToString() == "479" || Session["COMPANY_ID"].ToString() == "488" || Session["COMPANY_ID"].ToString() == "10")
                   {
                       dr1["ITEM_PMVVALUE"] = dt_inv_item.Rows[b][45].ToString();
                   }

                   dsXML.Tables[1].Rows.Add(dr1);

                   //--------------------Drawback Details--------------------------//
                   string[] arr = { "19", "41", "43", "44", "47", "48", "49", "71", "73", "74", "79", "60", "61", "62", "63", "64", "65" };
                   string scheme_draw = dt_inv_item.Rows[b][71].ToString().Trim();
                   if (scheme_draw.Contains('-'))
                   {
                       string[] sp = scheme_draw.Split('-');
                       scheme_draw = sp[0];
                   }

                   string Draw_value = Array.Find(arr, element => element.StartsWith(scheme_draw, StringComparison.Ordinal));

                   if (dt_inv_item.Rows.Count > c)
                   {
                       if (scheme != "")
                       {
                           if (scheme_draw == Draw_value)
                           {
                               DataRow dr2 = dsXML.Tables[2].NewRow();

                               dr2["INVOICE_SLNO"] = dt_inv_item.Rows[c][37].ToString();

                               dr2["ITEM_SLNO"] = dt_inv_item.Rows[c][64].ToString();
                               dr2["SCHEME_CODE"] = scheme;

                               if (dt_inv_item.Rows[c][74].ToString() != "")
                               {
                                   dr2["DRAWBACK_QTY"] = dt_inv_item.Rows[c][74].ToString();
                               }
                               else
                               {
                                   dr2["DRAWBACK_QTY"] = dt_inv_item.Rows[c][67].ToString();
                               }

                               if (dt_inv_item.Rows[c][75].ToString() != "")
                               {
                                   dr2["DRAWBACK_UNIT"] = dt_inv_item.Rows[c][75].ToString();
                               }
                               else
                               {
                                   dr2["DRAWBACK_UNIT"] = dt_inv_item.Rows[c][70].ToString();
                               }

                               dr2["DRAWBACK_SLNO"] = dt_inv_item.Rows[c][73].ToString();

                               string dbk_slno = dt_inv_item.Rows[c][73].ToString();

                               if (dbk_slno != "")
                               {
                                   Auto.Ename = "DRAWBACK_MASTER_ALL";
                                   Auto.Enamesearch = dbk_slno;
                                   Auto.Notn_No_Search = scheme_draw;
                                   ds_draw = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                                   if (ds_draw.Tables[0].Rows.Count > 0)
                                   {
                                       dr2["DRAWBACK_NOOFUNITS"] = ds_draw.Tables[0].Rows[0]["DRAWBACK_NOOFUNITS"].ToString();
                                       dr2["DRAWBACK_RATE"] = ds_draw.Tables[0].Rows[0]["DRAWBACK_RATE"].ToString();
                                       dr2["DRAWBACK_CAPS"] = ds_draw.Tables[0].Rows[0]["DRAWBACK_VALUE_CAP"].ToString();
                                       dr2["DRAWBACK_DESC"] = ds_draw.Tables[0].Rows[0]["DRAWBACK_DESCRIPTION"].ToString().Replace("'", "");
                                   }
                                   if (scheme_draw == "60" || scheme_draw == "61" || scheme_draw == "62" || scheme_draw == "63" || scheme_draw == "64" || scheme_draw == "65")
                                   {
                                       if (ds_draw.Tables[1].Rows.Count > 0)
                                       {
                                           dr2["STATE_LEVEL_ADV_RATE"] = ds_draw.Tables[1].Rows[0]["ROSL_RATE"].ToString();
                                           dr2["STATE_LEVEL_ADV_AMT"] = ds_draw.Tables[1].Rows[0]["ROSL_AMT"].ToString();

                                           if (ds_draw.Tables[1].Rows.Count == 2)
                                           {
                                               dr2["CENTRAL_LEVEL_ADV_RATE"] = ds_draw.Tables[1].Rows[1]["ROSL_RATE"].ToString();
                                               dr2["CENTRAL_LEVEL_ADV_AMT"] = ds_draw.Tables[1].Rows[1]["ROSL_AMT"].ToString();
                                           }
                                       }
                                   }
                               }
                               else
                               {
                                   dr2["DRAWBACK_SLNO"] = dt_inv_item.Rows[c][19].ToString();
                                   dr2["DRAWBACK_NOOFUNITS"] = "";

                                   dr2["DRAWBACK_RATE"] = "";
                                   dr2["DRAWBACK_CAPS"] = "";
                                   dr2["DRAWBACK_DESC"] = "";
                                   dr2["STATE_LEVEL_ADV_RATE"] = "";
                                   dr2["STATE_LEVEL_ADV_AMT"] = "";
                                   dr2["CENTRAL_LEVEL_ADV_RATE"] = "";
                                   dr2["CENTRAL_LEVEL_ADV_AMT"] = "";
                               }

                               dsXML.Tables[2].Rows.Add(dr2);
                           }
                       }
                       c++;
                   }
                   //--------------------End Drawback Details--------------------------//

                   //--------------------License Details--------------------------//
                   #region LICENSE_DETAILS

                   string[] arr_License = { "01", "02", "03", "04", "05", "08", "09", "11", "12", "17", "41", "43", "44", "48", "50", "52", "53", "54", "55", "59", "61", "64", "65", "71", "73", "74", "79", "80" };
                   string scheme_License = dt_inv_item.Rows[b][71].ToString().Trim();
                   if (scheme_License.Contains('-'))
                   {
                       string[] sp = scheme_License.Split('-');
                       scheme_License = sp[0];
                   }

                   string lic_value = Array.Find(arr_License, element => element.StartsWith(scheme_License, StringComparison.Ordinal));


                   if (scheme != "" || scheme != "00-FREE SHIPPING BILL")
                   {
                       if (scheme_License == lic_value)
                       {
                           string license_no = dt_inv_item.Rows[d][76].ToString();
                           sl = 1;
                           sl_E = 1;
                           licno_Count = licno_Count + 1;

                           if (license_no != "")
                           {
                               DataRow dr3 = dsXML.Tables[3].NewRow();
                               dr3["LICENSE_ID"] = License_id_Max;
                               dr3["INV_SL_NO"] = dt_inv_item.Rows[d][37].ToString();
                               dr3["ITEM_SL_NO"] = dt_inv_item.Rows[d][64].ToString();

                               dr3["SCHEME_CODE"] = scheme;

                               if (scheme == "DEEC")
                               {
                                   dr3["LICENSE_R_SL_NO"] = sl;
                                   sl = sl + 1;
                               }
                               else
                               {
                                   dr3["LICENSE_R_SL_NO"] = sl_E;
                                   sl_E = sl_E + 1;
                               }

                               dr3["LICENSE_EXP_QTY"] = dt_inv_item.Rows[d][67].ToString();
                               dr3["LICENSE_EXP_UNIT"] = dt_inv_item.Rows[d][70].ToString();
                               dr3["LICENSE_NO"] = license_no;

                               dr3["LICENSE_IMP_EXP_ID"] = License_id_IMP_EXP_Max;
                               dr3["LICENSE_E_SL_NO"] = dt_inv_item.Rows[d][78].ToString();
                               dr3["LICENSE_ID"] = License_id_Max + 1;
                               string License_date = Convert.ToDateTime(dt_inv_item.Rows[d][77].ToString()).ToShortDateString();
                               string License_date1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(License_date));

                               dr3["LICENSE_DATE"] = Convert.ToDateTime(License_date).ToString(@"MM/dd/yyyy");
                               //dr3["LICENSE_REG_DATE"] = dt_inv_item.Rows[d]["LICENSE_REG_DATE"].ToString();
                               //dr3["LICENSE_REG_TYPE"] = dt_inv_item.Rows[d]["LICENSE_REG_TYPE"].ToString();
                               dr3["LICENSE_ITEM_SL_NO"] = dt_inv_item.Rows[d][79].ToString();
                               dr3["LICENSE_ITEM_DESCRIPTION"] = "";

                               dr3["LICENSE_QTY"] = dt_inv_item.Rows[d][80].ToString();
                               dr3["LICENSE_UNIT"] = dt_inv_item.Rows[d][81].ToString();
                               dr3["LICENSE_TYPE"] = dt_inv_item.Rows[d][82].ToString();


                               dr3["SCHEME"] = scheme_name[D_E];
                               License_id_IMP_EXP_Max = License_id_IMP_EXP_Max + 1;

                               dsXML.Tables[3].Rows.Add(dr3.ItemArray);
                           }
                           d++;
                           License_id_Max = License_id_Max + 1;

                       }
                   }
                   #endregion LICENSE_DETAILS

                   //--------------------AR4 Details--------------------------//
                   #region AR4_Details

                   if (dt_inv_item.Rows[f][89].ToString() != "")
                   {
                       AR4_NO = dt_inv_item.Rows[e][89].ToString();
                       if (AR4_NO != "")
                       {
                           AR4_ID = Get_general_MAXID("AR4_MAX_ID");

                           dt_AR4.Rows.Add(AR4_ID + b, EXPORT_JOBNO, AR4_NO,
                                                           dt_inv_item.Rows[f][90].ToString(),//AR4_DATE
                                                           dt_inv_item.Rows[f][91].ToString(),//AR4_COMMISSION_RATE
                                                           dt_inv_item.Rows[f][92].ToString(),//AR4_DIVISION
                                                           dt_inv_item.Rows[f][93].ToString(),//AR4_RANGE
                                                           "",//AR4_REMARKS
                                                           currentuser, LoginDate, "N", currentbranch, "", Working_Period,
                                                           dt_inv_item.Rows[f][38].ToString(), dt_inv_item.Rows[f][37].ToString(), f + 1, dt_inv_item.Rows[f][64].ToString(), currentuser, LoginDate);
                       }
                   }
                   #endregion AR4_Details


                   //********************* EXPORT DRAWBACK DECLATION STATEMENT **********************
                   #region DBK_DECLARATION
                   if (dt_inv_item.Rows.Count > e)
                   {
                       if (scheme != "")
                       {
                           if (scheme_draw == Draw_value)
                           {

                               if (dt_inv_item.Rows[e][111].ToString() != "")
                               {
                                   DataRow dr4 = dsXML.Tables[4].NewRow();
                                   //dr4["JOBNO"] = EXPORT_JOBNO;
                                   dr4["INVOICE_SLNO"] = dt_inv_item.Rows[e][37].ToString();
                                   dr4["ITEM_SLNO"] = dt_inv_item.Rows[e][64].ToString();
                                   dr4["SLNO"] = 1;
                                   dr4["STMT_TYPE"] = dt_inv_item.Rows[e][111].ToString();
                                   dr4["STMT_CODE"] = dt_inv_item.Rows[e][112].ToString();
                                   dr4["STMT_TEXT"] = "";

                                   dsXML.Tables[4].Rows.Add(dr4);
                               }

                               if (dt_inv_item.Rows[e][113].ToString() != "")
                               {
                                   DataRow dr4 = dsXML.Tables[4].NewRow();
                                   //dr4["JOBNO"] = EXPORT_JOBNO;
                                   dr4["INVOICE_SLNO"] = dt_inv_item.Rows[e][37].ToString();
                                   dr4["ITEM_SLNO"] = dt_inv_item.Rows[e][64].ToString();
                                   dr4["SLNO"] = 2;
                                   dr4["STMT_TYPE"] = dt_inv_item.Rows[e][113].ToString();
                                   dr4["STMT_CODE"] = dt_inv_item.Rows[e][114].ToString();
                                   dr4["STMT_TEXT"] = "";

                                   dsXML.Tables[4].Rows.Add(dr4);
                               }
                           }
                       }
                   }
                   #endregion DBK_DECLARATION


                   //********************** EXPORT SW INFO TYPE*****START*********************************

                   #region EXP_SW_INFO_TYPE

                   //-------------------------SW - INFO MSR & UQC ----------------------------
                   DataRow dr5 = dsXML.Tables[5].NewRow();
                   /*
                   dr5["INVOICE_SLNO"] = dt_inv_item.Rows[b][37].ToString();
                   dr5["ITEM_SLNO"] = dt_inv_item.Rows[b][64].ToString();
                   dr5["SLNO"] = SW_slno_cnt++;
                   dr5["INFO_TYPE"] = "CHR";
                   dr5["INFO_QUALIFIER"] = "SQC";
                   dr5["INFO_CODE"] = "";
                   dr5["INFO_TEXT"] = "";
                   dr5["INFO_MSR"] = dt_inv_item.Rows[b][117].ToString();
                   dr5["INFO_UQC"] = dt_inv_item.Rows[b][118].ToString().ToUpper();
                   dsXML.Tables[5].Rows.Add(dr5);
                   

                   //-------------------------SW - STATE OF ORIGIN ----------------------------
                   dr5 = dsXML.Tables[5].NewRow();
                   string code = "", districtcode = "";
                  

                   if (dt_inv_item.Rows[b][119].ToString().Trim().Contains("-"))
                   {
                       string[] ccc = dt_inv_item.Rows[b][119].ToString().Trim().Split('-');
                       code = ccc[0];
                   }
                   else
                   {
                       code = dt_inv_item.Rows[b][119].ToString().Trim();
                   }

                   if (code.Length == 1)
                   {
                       code = "0" + code;
                   }
                  
                   statecode = AdminManipulation.Get_Statename(code);

                  
                   dr5["INVOICE_SLNO"] = dt_inv_item.Rows[b][37].ToString();
                   dr5["ITEM_SLNO"] = dt_inv_item.Rows[b][64].ToString();
                   dr5["SLNO"] = SW_slno_cnt++;
                   dr5["INFO_TYPE"] = "ORC";
                   dr5["INFO_QUALIFIER"] = "STO";
                   dr5["INFO_CODE"] = code + "-" + statecode;// dt_inv_item.Rows[b][119].ToString();
                   dr5["INFO_TEXT"] = "";
                   dr5["INFO_MSR"] = "";
                   dr5["INFO_UQC"] = "";
                   dsXML.Tables[5].Rows.Add(dr5);


                   //-------------------------SW - DISTRICT OF ORIGIN ----------------------------
                   dr5 = dsXML.Tables[5].NewRow();
                   string dist_code = "";
                   if (dt_inv_item.Rows[b][120].ToString().Trim().Contains("-"))
                   {
                       string[] ccc = dt_inv_item.Rows[b][120].ToString().Trim().Split('-');
                       dist_code = ccc[0];
                   }
                   else
                   {
                       dist_code = dt_inv_item.Rows[b][120].ToString().Trim();
                   }

                   if (code.Length == 1)
                   {
                       dist_code = "0" + dist_code;
                   }

                   districtcode = AdminManipulation.Get_DistrictName(dist_code, code);

                   dr5["INVOICE_SLNO"] = dt_inv_item.Rows[b][37].ToString();
                   dr5["ITEM_SLNO"] = dt_inv_item.Rows[b][64].ToString();
                   dr5["SLNO"] = SW_slno_cnt++;
                   dr5["INFO_TYPE"] = "ORC";
                   dr5["INFO_QUALIFIER"] = "DOO";
                   dr5["INFO_CODE"] = districtcode;// dt_inv_item.Rows[d][120].ToString();
                   dr5["INFO_TEXT"] = "";
                   dr5["INFO_MSR"] = "";
                   dr5["INFO_UQC"] = "";
                   dsXML.Tables[5].Rows.Add(dr5);

                   //-------------------------SW - UNDER FTA/PTA ----------------------------
                   dr5 = dsXML.Tables[5].NewRow();                
                   dr5["INVOICE_SLNO"] = dt_inv_item.Rows[b][37].ToString();
                   dr5["ITEM_SLNO"] = dt_inv_item.Rows[b][64].ToString();
                   dr5["SLNO"] = SW_slno_cnt++;
                   dr5["INFO_TYPE"] = "ORC";
                   dr5["INFO_QUALIFIER"] = "EPT";
                   dr5["INFO_CODE"] = dt_inv_item.Rows[b][121].ToString() == "" ? "NCPTI-Preferential Trade Benefit not claimed at Importing Country" : dt_inv_item.Rows[b][121].ToString();
                   dr5["INFO_TEXT"] = "";
                   dr5["INFO_MSR"] = "";
                   dr5["INFO_UQC"] = "";
                   dsXML.Tables[5].Rows.Add(dr5);

                   //-------------------------SW - GST-CESS AMT ----------------------------
                   dr5 = dsXML.Tables[5].NewRow();
                   dr5["INVOICE_SLNO"] = dt_inv_item.Rows[b][37].ToString();
                   dr5["ITEM_SLNO"] = dt_inv_item.Rows[b][64].ToString();
                   dr5["SLNO"] = SW_slno_cnt++;
                   dr5["INFO_TYPE"] = "DTY";
                   dr5["INFO_QUALIFIER"] = "GCESS";
                   dr5["INFO_CODE"] = "";
                   dr5["INFO_TEXT"] = "";
                   dr5["INFO_MSR"] = dt_inv_item.Rows[b][122].ToString() == "" ? "0" : dt_inv_item.Rows[b][122].ToString();
                   dr5["INFO_UQC"] = "INR";
                   dsXML.Tables[5].Rows.Add(dr5);


                   //-------------------------SW - RODTEP ----------------------------
                   dr5 = dsXML.Tables[5].NewRow();
                   dr5["INVOICE_SLNO"] = dt_inv_item.Rows[b][37].ToString();
                   dr5["ITEM_SLNO"] = dt_inv_item.Rows[b][64].ToString();
                   dr5["SLNO"] = SW_slno_cnt++;
                   dr5["INFO_TYPE"] = "DTY";
                   dr5["INFO_QUALIFIER"] = "RDT";
                   
                   if (dt_inv_item.Rows[b][123].ToString() == "N")
                   {
                       RODTEp = "RODTEPN";
                   }
                   else
                   {
                       RODTEp = "RODTEPY";
                   }

                   dr5["INFO_CODE"] = RODTEp;
                   dr5["INFO_TEXT"] = "";

                   dr5["INFO_MSR"] = dt_inv_item.Rows[b][117].ToString();
                   dr5["INFO_UQC"] = dt_inv_item.Rows[b][118].ToString().ToUpper();
                   dsXML.Tables[5].Rows.Add(dr5);
                   */
                   #endregion EXP_SW_INFO_TYPE

                   //********************** EXPORT SW INFO TYPE***** END *********************************



                   f++;
                   e++;
                   b++;
               }// while to for Item


               //DataTable table;
               dt = dsXML.Tables["ItemDetails"];

               //---------------------------------------

               string dd = dt_inv_item.Rows[0][38].ToString();
               var Values = from row in dsXML.Tables["ItemDetails"].AsEnumerable()
                            group row by new { id = row.Field<string>("INVOICE_NO") } into g
                            select new
                            {
                                name_1 = g.Key.id,
                                name_2 = g.Sum(r => r.Field<double>("ITEM_AMOUNT"))
                            };


               foreach (var drval in Values)
               {
                   if (drval.name_1 == dd)
                       dr["INVOICE_VALUE"] = drval.name_2;
               }

               dsXML.Tables[0].Rows.Add(dr);

               //a++;
           }//while to for
       }

       dt = dsXML.Tables["InvoiceDetails"];

       EXU.JOBNO = EXPORT_JOBNO;
       EXU.USER_ID = currentuser;
       EXU.Branch_Code = currentbranch;
       EXU.WORKING_PERIOD = Working_Period;

       EXU.Bulk_Item_Excel_Upload_SHAHI(RemoveDuplicateRows(dt, "INVOICE_NO"), dsXML.Tables[1], dsXML.Tables[2], dsXML.Tables[3], dsXML.Tables[4], dsXML.Tables[5], "BULK_ITEM_UPLOAD");
       int i = EXU.result;

       if (dt_AR4.Rows.Count > 0)
       {
           admin.SqlBulk_Upload_Product("EXPORT_AR4_TBL", dt_AR4, comp_ConnectionStr);
       }

       if (Inv_data.Rows[0][94].ToString() != "")
       {
           Bind_ANNEXURE_C1_DETAILS(Inv_data);
       }

       if (EXU.result == 1)
       {
           Alert_msg("Excel Uploaded Successfully.");
       }
       else
       {
           Alert_msg("Excel Upload occured some problem");
       }
   }

   public void Bind_Bulk_LICENSE_DETAILS(DataTable blk_lic_Data)
   {
       #region dt_blk_Lic
       dt_blk_Lic.Columns.Add("LICENSE_ID", typeof(int));
       dt_blk_Lic.Columns.Add("JOB_NO");
       dt_blk_Lic.Columns.Add("INV_SL_NO");
       dt_blk_Lic.Columns.Add("ITEM_SL_NO");
       dt_blk_Lic.Columns.Add("SCHEME_CODE");
       dt_blk_Lic.Columns.Add("SCHEME");
       dt_blk_Lic.Columns.Add("LICENSE_R_SL_NO");
       dt_blk_Lic.Columns.Add("LICENSE_NO");
       dt_blk_Lic.Columns.Add("LICENSE_DATE");
       dt_blk_Lic.Columns.Add("USER_ID");
       dt_blk_Lic.Columns.Add("DATE_TIME");
       dt_blk_Lic.Columns.Add("STATUS");
       dt_blk_Lic.Columns.Add("BRANCH_CODE");
       dt_blk_Lic.Columns.Add("YEAR");
       dt_blk_Lic.Columns.Add("WORKING_PERIOD");
       dt_blk_Lic.Columns.Add("MODIFIEDBY");
       dt_blk_Lic.Columns.Add("MODIFIEDON");
       #endregion dt_blk_Lic

       #region dt_blk_Imp_Exp_lic
       dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_IMP_EXP_ID", typeof(int));
       dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_ID", typeof(int));
       dt_blk_Imp_Exp_lic.Columns.Add("JOB_NO");
       dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_REG_SLNO");
       dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_NO");
       dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_E_SL_NO");
       dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_EXP_QTY");
       dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_EXP_UNIT");
       dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_IMP_ITEM_SL_NO");
       dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_IMP_DESC");
       dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_IMP_QTY");
       dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_IMP_UNIT");
       dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_IMP_TYPE");
       dt_blk_Imp_Exp_lic.Columns.Add("USER_ID");
       dt_blk_Imp_Exp_lic.Columns.Add("DATE_TIME");
       dt_blk_Imp_Exp_lic.Columns.Add("STATUS");
       dt_blk_Imp_Exp_lic.Columns.Add("BRANCH_CODE");
       dt_blk_Imp_Exp_lic.Columns.Add("YEAR");
       dt_blk_Imp_Exp_lic.Columns.Add("WORKING_PERIOD");
       dt_blk_Imp_Exp_lic.Columns.Add("INV_SL_NO");
       dt_blk_Imp_Exp_lic.Columns.Add("ITEM_SL_NO");
       dt_blk_Imp_Exp_lic.Columns.Add("SCHEME");
       dt_blk_Imp_Exp_lic.Columns.Add("MODIFIEDBY");
       dt_blk_Imp_Exp_lic.Columns.Add("MODIFIEDON");
       #endregion dt_blk_Imp_Exp_lic


       //******************** Remove Empty Rows from Datatable  ********************************
       blk_lic_Data = blk_lic_Data.Rows.Cast<DataRow>()
            .Where(row => !row.ItemArray.All(field => field is System.DBNull))
            .CopyToDataTable();
       //***************************************************************************************
       blk_lic_Data.Rows.Add();
       int a = 0, b = 0, c = 1;
      
       LICENSE_ID = Get_general_MAXID("LICENSE_MAX_ID");
       License_id_Max = LICENSE_ID;
       LICENSE_IMP_EXP_ID = Get_general_MAXID("LICENSE_IMP_EXP_MAX_ID");
       License_id_IMP_EXP_Max=LICENSE_IMP_EXP_ID;

       while (blk_lic_Data.Rows[a][0] != System.DBNull.Value)
       {

           var query = from r in dsXML.Tables[1].AsEnumerable()
                       where (r.Field<string>("INVOICE_SLNO") == blk_lic_Data.Rows[a][0].ToString() && r.Field<string>("ITEM_SLNO") == blk_lic_Data.Rows[a][1].ToString())
                       select r;

           if (query.Count() > 0)
           {
               dt_inv_item = query.CopyToDataTable();
           }

           LICENSE_ID = License_id_Max;
           JOBNO = EXPORT_JOBNO;
           INVOICE_SLNO = blk_lic_Data.Rows[a][0].ToString();
           ITEM_SLNO = blk_lic_Data.Rows[a][1].ToString().TrimEnd();
           SCHEME_CODE = dt_inv_item.Rows[0]["ITEM_SCHEME_CODE"].ToString();

           //SCHEME = blk_lic_Data.Rows[a][3].ToString();

           if (SCHEME_CODE.Contains('-'))
           {
               string[] sp = SCHEME_CODE.Split('-');
               scheme = sp[0];
           }

           Open_Schemecode();

           SCHEME = scheme_name[0];

           LICENSE_R_SL_NO = c;
           LICENSE_NO = blk_lic_Data.Rows[a][2].ToString();
           LICENSE_DATE = blk_lic_Data.Rows[a][3].ToString();
          
           dt_blk_Lic.Rows.Add(LICENSE_ID, EXPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, SCHEME_CODE, SCHEME, LICENSE_R_SL_NO, LICENSE_NO, LICENSE_DATE, currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate);

           while (blk_lic_Data.Rows[b][0] != System.DBNull.Value)
           {
          
               string LicenseNo, IMP_Exp_LicenseNo, InvslNo, Imp_exp_Invslno, ItemslNo, Imp_exp_Itemslno;
               LicenseNo = blk_lic_Data.Rows[a][2].ToString();
               IMP_Exp_LicenseNo = blk_lic_Data.Rows[b][2].ToString();

               InvslNo = blk_lic_Data.Rows[a][0].ToString();
               Imp_exp_Invslno = blk_lic_Data.Rows[b][0].ToString();

               ItemslNo = blk_lic_Data.Rows[a][1].ToString().TrimEnd();
               Imp_exp_Itemslno = blk_lic_Data.Rows[b][1].ToString().TrimEnd();

               if (LicenseNo == IMP_Exp_LicenseNo && InvslNo == Imp_exp_Invslno && ItemslNo == Imp_exp_Itemslno)
               {
                   LICENSE_IMP_EXP_ID = License_id_IMP_EXP_Max;
                   LICENSE_ID = License_id_Max;
                   JOBNO = EXPORT_JOBNO;
                   LICENSE_REG_SLNO = Convert.ToString(c);
                   LICENSE_NO = blk_lic_Data.Rows[b][2].ToString();
                   LICENSE_E_SL_NO = blk_lic_Data.Rows[b][5].ToString();

                   LICENSE_EXP_QTY = dt_inv_item.Rows[0]["ITEM_QTY"].ToString();
                   LICENSE_EXP_UNIT = dt_inv_item.Rows[0]["ITEM_QTY_CODE"].ToString();
                   LICENSE_IMP_ITEM_SL_NO = blk_lic_Data.Rows[b][5].ToString();
                   LICENSE_IMP_DESC = "";
                   LICENSE_IMP_QTY = blk_lic_Data.Rows[b][6].ToString();
                   LICENSE_IMP_UNIT = blk_lic_Data.Rows[b][7].ToString();
                   LICENSE_IMP_TYPE = blk_lic_Data.Rows[b][8].ToString();

                   dt_blk_Imp_Exp_lic.Rows.Add(LICENSE_IMP_EXP_ID+i, LICENSE_ID, EXPORT_JOBNO, LICENSE_R_SL_NO, LICENSE_NO, LICENSE_E_SL_NO, LICENSE_EXP_QTY, LICENSE_EXP_UNIT, LICENSE_IMP_ITEM_SL_NO,
                                    LICENSE_ITEM_DESCRIPTION, LICENSE_IMP_QTY, LICENSE_IMP_UNIT, LICENSE_IMP_TYPE, currentuser, LoginDate, "N", currentbranch, "", Working_Period, INVOICE_SLNO, ITEM_SLNO, SCHEME, currentuser, LoginDate);


                   b++;
                   License_id_IMP_EXP_Max++;              
               }
               else
               {
                   break;
               }
           }

           //a++;
           a = b;
           License_id_Max++;
       }

       if (dt_blk_Lic.Rows.Count > 0)
       {
           admin.SqlBulk_Upload_Product("EXPORT_LICENSE_DETAILS", dt_blk_Lic, comp_ConnectionStr);
       }
       if (dt_blk_Imp_Exp_lic.Rows.Count > 0)
       {
           admin.SqlBulk_Upload_Product("EXPORT_LICENSE_IMP_EXP_DETAILS", dt_blk_Imp_Exp_lic, comp_ConnectionStr);
       }

   }

   public void Bind_Annex_PACKAGE_DETAILS(DataTable PKG_data)
   {
       #region dt_PKG
       dt_PKG.Columns.Add("ANNEX_SEA_PACK_ID");
       dt_PKG.Columns.Add("ANNEX_SEA_PACK_JOBNO");
       dt_PKG.Columns.Add("ANNEX_SEA_PACK_GROUP");
       dt_PKG.Columns.Add("ANNEX_SEA_PACK_FROM");
       dt_PKG.Columns.Add("ANNEX_SEA_PACK_TO");
       dt_PKG.Columns.Add("ANNEX_SEA_PACK_PACKAGETYPE");
       dt_PKG.Columns.Add("USER_ID");
       dt_PKG.Columns.Add("DATE_TIME");
       dt_PKG.Columns.Add("STATUS");
       dt_PKG.Columns.Add("BRANCH_CODE");
       dt_PKG.Columns.Add("YEAR");
       dt_PKG.Columns.Add("WORKING_PERIOD");
       dt_PKG.Columns.Add("ANNEX_SEA_PACK_FROMDESC");
       dt_PKG.Columns.Add("ANNEX_SEA_PACK_TODESC");
       dt_PKG.Columns.Add("MODIFIEDBY");
       dt_PKG.Columns.Add("MODIFIEDON");
       #endregion dt_PKG

       ANNEX_SEA_PACK_ID = Convert.ToString(Get_general_MAXID("ANNEX_PKGS_ID"));

       //******************** Remove Empty Rows from Datatable  *************************************************

       PKG_data = PKG_data.Rows.Cast<DataRow>()
            .Where(row => !row.ItemArray.All(field => field is System.DBNull))
            .CopyToDataTable();
       //*********************************************************************************************************

       for (int i = 0; i <= PKG_data.Rows.Count - 1; i++)
       {
           int pkg_id = Convert.ToInt32(ANNEX_SEA_PACK_ID) + i;
           dt_PKG.Rows.Add(pkg_id, EXPORT_JOBNO, PKG_data.Rows[i][0].ToString(), //ANNEX_SEA_PACK_GROUP
                                                  PKG_data.Rows[i][1].ToString(), //ANNEX_SEA_PACK_FROM
                                                  PKG_data.Rows[i][2].ToString(), //ANNEX_SEA_PACK_TO
                                                  PKG_data.Rows[i][3].ToString(),//ANNEX_SEA_PACK_PACKAGETYPE
                                                  currentuser, LoginDate, "N", currentbranch, "", Working_Period,
                                                  "", //ANNEX_SEA_PACK_FROMDESC
                                                  "", //ANNEX_SEA_PACK_TODESC
                                                  currentuser, LoginDate);
       }
       if (dt_PKG.Rows.Count > 0)
       {
           admin.SqlBulk_Upload_Product("EXPORT_ANNEXURE_C_SEA_PACKAGE", dt_PKG, comp_ConnectionStr);
       }
   }

   public void Bind_ANNEXURE_C1_DETAILS(DataTable Annex_Data)
   {
       int xx;
       if (Annex_Data.Rows.Count > 0)
       {
           ANNEX.ANNEX_JOBNO = EXPORT_JOBNO;
           //ANNEX.ANNEX_EXPORTERNAME = Annex_Data.Rows[0][94].ToString().Trim();
           ANNEX.ANNEX_IECCODE = Annex_Data.Rows[0][94].ToString().Trim();
           ANNEX.ANNEX_BR_SLNO = Annex_Data.Rows[0][95].ToString().Trim();

           xx = Check_Avail_IEC_Master(Annex_Data.Rows[0][94].ToString(), Annex_Data.Rows[0][95].ToString(), "Check_Avail_IEC_details");

           if (xx == 1)
           {
               ds_IEC = Get_Importer_HSS_Details(Annex_Data.Rows[0][94].ToString(), Annex_Data.Rows[0][95].ToString());

               ANNEX.ANNEX_EXPORTERNAME = ds_IEC.Tables[0].Rows[0][1].ToString();
               ANNEX.ANNEX_ADDRESS1 = ds_IEC.Tables[0].Rows[0][5].ToString();
               ANNEX.ANNEX_ADDRESS2 = ds_IEC.Tables[0].Rows[0][6].ToString();
               ANNEX.ANNEX_ADDRESS3 = ds_IEC.Tables[0].Rows[0][7].ToString();
               ANNEX.ANNEX_ADDRESS4 = ds_IEC.Tables[0].Rows[0][8].ToString();
           }
           else
           { 
               //code for Insert AnnexC1details
           }

           ANNEX.ANNEX_EXAM_DATE = Annex_Data.Rows[0][96].ToString();
           ANNEX.ANNEX_EXAM_OFFICER = Annex_Data.Rows[0][97].ToString();
           ANNEX.ANNEX_EXAM_DESIGN = Annex_Data.Rows[0][98].ToString();
           ANNEX.ANNEX_SUPER_NAME = Annex_Data.Rows[0][99].ToString();
           ANNEX.ANNEX_SUPER_DESIGN = Annex_Data.Rows[0][100].ToString();
           ANNEX.ANNEX_COMMISSION_RATE = Annex_Data.Rows[0][101].ToString();
           ANNEX.ANNEX_DIVISION = Annex_Data.Rows[0][102].ToString();
           ANNEX.ANNEX_RANGE = Annex_Data.Rows[0][104].ToString();
 
           ANNEX.ANNEX_VERIFIED_EXAM_OFFICER = Annex_Data.Rows[0][106].ToString().ToUpper() == "Y" ? "Y" : "N";


           ANNEX.ANNEX_SAMPLE_DRAWN = Annex_Data.Rows[0][103].ToString().ToUpper() == "Y" ? "Y" : "N";
           if (Annex_Data.Rows[0][105].ToString() == "")
           {
               ANNEX.ANNEX_SEAL_NO = "N";
           }
           else
           {
               ANNEX.ANNEX_SEAL_NO = Annex_Data.Rows[0][105].ToString();
           }

           ANNEX.USER_ID = currentuser;

           ANNEX.flag = "S";
           ANNEX.BRANCH_CODE = currentbranch;
           ANNEX.WORKING_PERIOD = Working_Period;
           ANNEX.BRANCH_COMMON = SELECT_BRANCH;

           i = ANNEX.Annexure_details_insertupdate();
       }
   }

  
   public DataSet Get_Importer_HSS_Details(string IEC_No, string BranchSlNo)
   {

       objUBO.IEC_NO = IEC_No;
       objUBO.BRANCH_NO = BranchSlNo;
       objUBO.Ename = "Select_IEC_details";
       objUBO.WORKING_PERIOD = SELECT_BRANCH;
       ds_IEC = xl.Bind_Export_General_IEC_No(objUBO);

       return ds_IEC;
   }

   public int Get_general_MAXID(string Flag)
   {
       objUBO.IEC_NO = "";
       objUBO.BRANCH_NO = "";
       objUBO.Ename = Flag;
       objUBO.WORKING_PERIOD = SELECT_BRANCH;
       ds_IEC = xl.Bind_Export_General_IEC_No(objUBO);
       if (ds_IEC.Tables[0].Rows.Count > 0)
       {
           MAX_ID = Convert.ToInt32(ds_IEC.Tables[0].Rows[0]["MAXID"].ToString());
       }

       return MAX_ID;
   }

   public int Check_Avail_IEC_Master(string IEC_No, string BranchSlNo, string Flag)
   {
       objUBO.IEC_NO = IEC_No;
       objUBO.BRANCH_NO = BranchSlNo;
       objUBO.Ename = Flag;
       objUBO.WORKING_PERIOD = SELECT_BRANCH;
       ds_IEC = xl.Bind_Export_General_IEC_No(objUBO);
       int xx = xl.result;

       return xx;
   }

   public void JobNo_Prefix_Sufix()
   {
       Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();
       DataSet dats = new DataSet();
       JPS.Branch = SELECT_BRANCH;
       JPS.Ename = "Exp_gen_select";
       JPS.Tr_mode = TRANSPORT_MODE;
       dats = JPS.Job_prefix_Suffix_Select();
      
       if (Session["COMPANY_LICENSE"] != null)
       {
           if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247")
           {
               if (dats.Tables[0].Rows.Count > 0)
               {
                   if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                   {
                       JOBNO_PS = EXPORT_JOBNO + "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                       JOB_PREFIX = string.Empty;
                       JOB_SUFFIX = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();

                   }
                   else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                   {
                       JOBNO_PS = ((dats.Tables[0].Rows[0][0].ToString() + EXPORT_JOBNO).TrimEnd()).TrimStart();
                       JOB_PREFIX = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                       JOB_SUFFIX = string.Empty;
                   }
                   else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                   {
                       JOBNO_PS = ((dats.Tables[0].Rows[0][0].ToString() + EXPORT_JOBNO + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                       JOB_PREFIX = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                       JOB_SUFFIX = ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                   }
                   else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                   {
                       JOBNO_PS = EXPORT_JOBNO;
                       JOB_PREFIX = string.Empty;
                       JOB_SUFFIX = string.Empty;
                   }
               }
               else
               {
                   JOBNO_PS = EXPORT_JOBNO;
                   JOB_PREFIX = string.Empty;
                   JOB_SUFFIX = string.Empty;
               }
           }
           else
           {
               if (dats.Tables[0].Rows.Count > 0)
               {
                   if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                   {
                       JOBNO_PS = EXPORT_JOBNO + "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                       JOB_PREFIX = string.Empty;
                       JOB_SUFFIX = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                   }
                   else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                   {
                       JOBNO_PS = ((dats.Tables[0].Rows[0][0].ToString() + "/" + EXPORT_JOBNO).TrimEnd()).TrimStart();
                       JOB_PREFIX = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                       JOB_SUFFIX = string.Empty;
                   }
                   else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                   {
                       JOBNO_PS = ((dats.Tables[0].Rows[0][0].ToString() + "/" + EXPORT_JOBNO + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                       JOB_PREFIX = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                       JOB_SUFFIX = ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                   }
                   else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                   {
                       JOBNO_PS = EXPORT_JOBNO;
                       JOB_PREFIX = string.Empty;
                       JOB_SUFFIX = string.Empty;
                   }
               }
               else
               {
                   JOBNO_PS = EXPORT_JOBNO;
                   JOB_PREFIX = string.Empty;
                   JOB_SUFFIX = string.Empty;
               }
           }
       }
   }

   public DataTable Filter_EmptyRows(DataTable dtn)
   {
       int xxx = 0;
       int ij = 0;

       DataTable dttableNew = dtn.Clone();

       foreach (DataRow drtableOld in dtn.Rows)
       {
           if (dtn.Rows[ij][0].ToString() != "")
           {
               dttableNew.ImportRow(drtableOld);
               ij = ij + 1;
           }
       }

       xxx = dttableNew.Rows.Count;
       return dttableNew;
   }

  

   public void Get_ExcelFile()
   {
       DataSet ds = new DataSet();

       string connString = "";
       string filename = "";
       string path = "";
      
       string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();

        filename = fileuploadExcel.FileName;
        path = errorFolder + "\\" + fileuploadExcel.FileName;

     
       string picExtension;
       string fileName2;


       if (!File.Exists(path))
       {
           File.Delete(path);
       }

       if (fileuploadExcel.HasFile)
       {
           //picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
           //fileName2 = fileuploadExcel.FileName;

           picExtension = fnGetPictureExtn(filename);
           fileName2 = filename;
           addtoGallery1(fileName2, errorFolder, "NORMAL");
       }


       //Connection String to Excel Workbook
       if (strFileType.Trim() == ".xls")
       {

           // ---------------------version------------
           string[] arr2 = new string[] { };
           DataSet dds = new DataSet();
           dds = (DataSet)Session["COMPANY_DETAILS_DS"];

           if (dds.Tables[2].Rows[0][1].ToString() != string.Empty && dds.Tables[2].Rows[0][1].ToString() != null)
           {
               arr2 = dds.Tables[2].Rows[0][1].ToString().Split(';');

               if (arr2[0] == "Server=182.76.213.91")
               {
                   connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
               }
               else
               {
                   connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
               }
           }
           // ---------------------version------------
           //connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";

       }
       else if (strFileType.Trim() == ".xlsx")
       {
           connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
       }

       foreach (var sheetName in GetExcelSheetNames(connString))
       {
           using (OleDbConnection con = new OleDbConnection(connString))
           {
               var dataTable = new DataTable();
               //string query = string.Format("SELECT * FROM [{0}]", sheetName + "$");
               //string query = string.Format("SELECT * FROM [{0}]", sheetName);
               string query = "";
               if (sheetName == "INVOICE$" || sheetName == "LICENSE$" || sheetName == "PACKAGE$" || sheetName == "'Page 1$'")
               {
                   if (sheetName == "INVOICE$" || sheetName == "'Page 1$'")
                   {
                       query = string.Format("SELECT * FROM [{0}] where LEN(INVSLNO)<> 0", sheetName);
                   }
                   else if (sheetName == "LICENSE$")
                   {
                       query = string.Format("SELECT * FROM [{0}] where LEN(LICENSENO)<> 0", sheetName);
                   }
                   else if (sheetName == "PACKAGE$")
                   {
                       query = string.Format("SELECT * FROM [{0}] where LEN(GROUP)<> 0", sheetName);
                   }

                   if (con.State == ConnectionState.Closed)
                       con.Open();
                   OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                   adapter.Fill(dataTable);
                   data.Tables.Add(dataTable);
                   adapter.Dispose();
                   con.Close();
                   con.Dispose();
                   Sheetcount = Sheetcount + 1;
               }
               
           }
       }

     
       ViewState["Sheetcount"] = Sheetcount;
       ViewState["data"] = data;
      
       DataTable dt_main = new DataTable();
       DataRow dr1;
       dt_main.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
       dt_main.Columns.Add(new System.Data.DataColumn("EXPORTER_NAME", typeof(String)));
       dt_main.Columns.Add(new System.Data.DataColumn("CONSIGNEE_NAME", typeof(String)));
       dt_main.Columns.Add(new System.Data.DataColumn("COUNTRY_DISCHARGE", typeof(String)));
       dt_main.Columns.Add(new System.Data.DataColumn("PORT_DISCHARGE", typeof(String)));
       dt_main.Columns.Add(new System.Data.DataColumn("COUNTRY_FINAL_DEST", typeof(String)));
       dt_main.Columns.Add(new System.Data.DataColumn("PORT_FINAL_DEST", typeof(String)));

       dr1 = dt_main.NewRow();

       dr1[0] = EXPORT_JOBNO;
       dr1[1] = data.Tables[0].Rows[0][3].ToString();
       dr1[2] = data.Tables[0].Rows[0][11].ToString();
       dr1[3] = data.Tables[0].Rows[0][18].ToString();
       dr1[4] = data.Tables[0].Rows[0][19].ToString();
       dr1[5] = data.Tables[0].Rows[0][20].ToString();
       dr1[6] = data.Tables[0].Rows[0][21].ToString();

       dt_main.Rows.Add(dr1);

        DataSet dsData1 = new DataSet();
           DataSet ds_grid1 = new DataSet();
           dsData1.Tables.Add(dt_main);
          
           if (dsData1.Tables[0].Rows.Count > 0)
           {
               if (Is_Additional_INV == "")
               {
                   gv_Gen_Details.DataSource = dsData1.Tables[0];
                   gv_Gen_Details.DataBind();
                  
               }
           }

           
           if (data.Tables[0].Rows[0][22].ToString().Contains('-'))
           {
               string[] aa = data.Tables[0].Rows[0][22].ToString().Split('-');
               STATE_OF_EXPORT = aa[1].Trim();
               txtStateExport.Text = STATE_OF_EXPORT;
           }
           else
           {
               if (data.Tables[0].Rows[0][22].ToString().Length == 1)
               {
                   statecode = "0" + data.Tables[0].Rows[0][22].ToString();
               }
               else
               {
                   statecode = data.Tables[0].Rows[0][22].ToString();
               }
               STATE_OF_EXPORT = AdminManipulation.Get_Statename(statecode);
               txtStateExport.Text = STATE_OF_EXPORT;
           }

       txtCountryOrigin.Text = AdminManipulation.Get_Countryname(data.Tables[0].Rows[0][18].ToString());
       txtPortShipment.Text = AdminManipulation.Get_Portname(data.Tables[0].Rows[0][19].ToString());     

       DataTable filteredRows = data.Tables[0].Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull)).CopyToDataTable();
       DataSet dss = new DataSet();
       dss.Tables.Add(filteredRows);
       if (dss.Tables[0].Rows.Count > 0)
       {
           ViewState["ds_Excel_upload"] = dss;
       }

       /*
       if (Sheetcount > 1)
       {
           DataTable filtered_LICENSE = data.Tables[1].Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull)).CopyToDataTable();
           DataSet dss1 = new DataSet();
           dss1.Tables.Add(filtered_LICENSE);
           if (dss1.Tables[0].Rows.Count > 0)
           {
               ViewState["ds_Excel_LICENSE"] = dss1;
           }
       }

       if (Sheetcount > 2)
       {
           DataTable filtere_PACK = data.Tables[2].Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull)).CopyToDataTable();
           DataSet dss2 = new DataSet();
           dss2.Tables.Add(filtere_PACK);
           if (dss2.Tables[0].Rows.Count > 0)
           {
               ViewState["ds_Excel_PACK"] = dss2;
           }
       }
       */

       DataSet dt_inv_chk = new DataSet();
       string Chk_Avail_InvoiceNo = "";

       if (dss.Tables[0].Rows.Count > 0)
       {
           DataTable dt_gen = new DataTable();
           DataRow dr;
           dt_gen.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
           dt_gen.Columns.Add(new System.Data.DataColumn("INVOICE_SLNO", typeof(String)));
           dt_gen.Columns.Add(new System.Data.DataColumn("INVOICE_NO", typeof(String)));
           dt_gen.Columns.Add(new System.Data.DataColumn("ITEM_AMOUNT", typeof(double)));
           dt_gen.Columns.Add(new System.Data.DataColumn("INVOICE_CURRENCY", typeof(String)));
           dt_gen.Columns.Add(new System.Data.DataColumn("EXCHANGE_RATE", typeof(String)));
           dt_gen.Columns.Add(new System.Data.DataColumn("TERMS", typeof(String)));

           for (int s = 0; s < dss.Tables[0].Rows.Count; s++)
           {
               EXU.JOBNO = EXPORT_JOBNO;
               EXU.Xml_D = dss.Tables[0].Rows[s][38].ToString();
               EXU.Branch_Code = SELECT_BRANCH;
               EXU.Ename = "CHECK_InvoiceNo_Avail";
               dt_inv_chk = EXU.Select_Exp_INV();

               if (dt_inv_chk.Tables[0].Rows.Count > 0)
               {
                   Chk_Avail_InvoiceNo = dt_inv_chk.Tables[0].Rows[0][0].ToString();
                  
               }

               if (Chk_Avail_InvoiceNo == "")
               {
                   dr = dt_gen.NewRow();
                   dr[0] = EXPORT_JOBNO;
                   dr[1] = dss.Tables[0].Rows[s][37].ToString();
                   if (dss.Tables[0].Rows[s][37].ToString() != "")
                   {
                       //dr[2] = dss.Tables[0].Rows[0][38].ToString();
                       dr[2] = dss.Tables[0].Rows[s][38].ToString();
                       dr[4] = dss.Tables[0].Rows[0][40].ToString();
                       dr[5] = dss.Tables[0].Rows[0][41].ToString();
                       dr[6] = dss.Tables[0].Rows[0][45].ToString();

                       if (dss.Tables[0].Rows[s][67] != System.DBNull.Value && dss.Tables[0].Rows[s][68] != System.DBNull.Value)
                       {
                           dr[3] = Convert.ToString(Convert.ToDecimal(dss.Tables[0].Rows[s][67]) * Convert.ToDecimal(dss.Tables[0].Rows[s][68]));
                       }
                       else
                       {
                           dr[3] = 0;
                       }

                       dt_gen.Rows.Add(dr);
                   }
               }
               else
               {
                   string msg=" Inv no : "+ dss.Tables[0].Rows[s][38].ToString() + "  -  Already Exists";
                   hdinvno.Value = msg;
                   Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Avail_InvoiceNo_Alert_Msg()", true);          
               }
           }
           DataSet dsData = new DataSet();
           DataSet ds_grid = new DataSet();
           dsData.Tables.Add(dt_gen);
           String xmlData = ConvertDataTableToXML(dsData.Tables[0]);

           ViewState["dt_gen"] = dt_gen;
           
           objUBO.JOBNO = EXPORT_JOBNO;
           objUBO.Ename = "Excel_Select";
           objUBO.Xml_D = xmlData;
           ds_grid = xl.Select_Exp_INV(objUBO);
           if (ds_grid.Tables[0].Rows.Count > 0)
           {
               gv_Item_Details.DataSource = ds_grid.Tables[0];
               gv_Item_Details.DataBind();
           }
           else
           {
               DataTable ddt = new DataTable();
               gv_Item_Details.DataSource = ddt;
               gv_Item_Details.DataBind();
           }
       }
   }

   static string[] GetExcelSheetNames(string connectionString)
   {
       OleDbConnection con = null;
       con = new OleDbConnection(connectionString);
       con.Open();

       //DataTable dt_sheetNames = new DataTable();
       //dt_sheetNames.Columns.Add("SHEETNAMES");
       //dt_sheetNames.Rows.Add("INVOICE");
       //dt_sheetNames.Rows.Add("LICENSE");
       //dt_sheetNames.Rows.Add("PACKAGE");

       DataTable dt_sheetNames = new DataTable();
       dt_sheetNames = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
   
       String[] excelSheetNames = new String[dt_sheetNames.Rows.Count];
       int ki = 0;

       foreach (DataRow row in dt_sheetNames.Rows)
       {
           excelSheetNames[ki] = row["TABLE_NAME"].ToString();
           ki++;
       }

       return excelSheetNames;
   }

   public void Excel_Upload_load(string MAX_INVOICE_SLNO, string Is_Additional_INV)
   {

       DataTable dt_final = new DataTable();
     
       int xxx = 0;

       //************************* GENERAL DETAILS ***********************************
       //ds_GENERAL = (DataTable)ViewState["data"];
       DataSet data_all = new DataSet();
       data_all = (DataSet)ViewState["data"];
       DataTable dtCloned = new DataTable();

       if (Is_Additional_INV == "YES")
       {
           DataView dv = new DataView(data_all.Tables[0]);
           ////DataTable dt_New = dv.ToTable(true, "INVSLNO", "INVOICENO", "ITEMNO");
           //DataTable dt_New = dv.ToTable(true, "INVSLNO");
           DataTable dt_New = dv.ToTable(true, "INVSLNO", "INVOICENO");
           int Invoice_Slno = 0;
           Invoice_Slno = Convert.ToInt32(MAX_INVOICE_SLNO);


           data_all.Tables[0].Columns.Add("Status");
           dtCloned = data_all.Tables[0].Clone();
           dtCloned.Columns[37].DataType = typeof(string);
           foreach (DataRow row in data_all.Tables[0].Rows)
           {
               dtCloned.ImportRow(row);
           }

           for (int l = 0; l <= dt_New.Rows.Count - 1; l++)
           {

               Invoice_Slno = Invoice_Slno + 1;

               //IEnumerable<DataRow> rowsc = data_all.Tables[0].Rows.Cast<DataRow>().Where(r => r["INVSLNO"].ToString().Contains(Convert.ToString(dt_New.Rows[l][0].ToString())));
               //rowsc.ToList().ForEach(r => r.SetField("INVSLNO", Convert.ToString(Invoice_Slno)));

               //IEnumerable<DataRow> rowsc1 = data_all.Tables[0].Rows.Cast<DataRow>().Where(r => r["INVSLNO"].ToString().Contains(Convert.ToString(dt_New.Rows[l][0].ToString())));
               //rowsc1.ToList().ForEach(r => r.SetField("Status", "S" + l));

               var rowsToUpdate =
                dtCloned.AsEnumerable().Where(r => r.Field<string>("INVSLNO") == dt_New.Rows[l][0].ToString());
               foreach (var row in rowsToUpdate)
               {
                   if (row["Status"].ToString() == string.Empty)
                   {
                       row.SetField("Status", "S" + l);
                   }

               }

               //IEnumerable<DataRow> rowsc1 = data_all.Tables[0].Rows.Cast<DataRow>().Where(r => r["INVSLNO"].ToString() == Convert.ToString(dt_New.Rows[l][0].ToString()));
               //rowsc1.ToList().ForEach(r => r.SetField("Status", "S" + l));

               //IEnumerable<DataRow> rowsc = data_all.Tables[0].Rows.Cast<DataRow>().Where(r => r["Status"].ToString().Contains("S" + Convert.ToString(dt_New.Rows[l][0].ToString())));
               //rowsc.ToList().ForEach(r => r.SetField("INVSLNO", Convert.ToString(Invoice_Slno)));

               //IEnumerable<DataRow> rowsc = dtCloned.Rows.Cast<DataRow>().Where(r => r["Status"].ToString().Contains("S" + l));
               //rowsc.ToList().ForEach(r => r.SetField("INVSLNO", Convert.ToString(Invoice_Slno)));

               var rowsToUpdate1 =
              dtCloned.AsEnumerable().Where(r => r.Field<string>("Status") == "S" + l);

               foreach (var row in rowsToUpdate1)
               {
                   if (row["Status"].ToString() == "S" + l && row["INVSLNO"].ToString() == Convert.ToString(dt_New.Rows[l][0].ToString()))
                   {
                       row.SetField("INVSLNO", Convert.ToString(Invoice_Slno));
                   }

               }

               if (Convert.ToInt32(ViewState["Sheetcount"].ToString()) > 1)
               {
                   IEnumerable<DataRow> rowsc2 = data_all.Tables[1].Rows.Cast<DataRow>().Where(r => r["INVOICE SL"].ToString().Contains(Convert.ToString(dt_New.Rows[l][0].ToString())));
                   rowsc2.ToList().ForEach(r => r.SetField("INVOICE SL", Convert.ToString(Invoice_Slno)));
               }

               //ViewState["ds_Excel_upload"] = data_all;

               //data_all.Tables.Add(dtCloned);
               ViewState["ds_Excel_upload"] = dtCloned;
           }
       }
       else
       {
           dtCloned = data_all.Tables[0];
       }

    
           //dt_final = Filter_EmptyRows(data_all.Tables[0]);
           dt_final = Filter_EmptyRows(dtCloned);
           xxx = dt_final.Rows.Count;
           if (xxx > 0)
           {
               if (dt_final.Rows.Count > 0)
               {
                   Bind_General_Details(dt_final);
               }
           }
           else
           {
               ViewState["ds_GENERAL"] = dt_gen;
           }
           dt_final.Clear();
       

       //MULTIPLE LICENSE DETAILS
       if (Convert.ToInt32(ViewState["Sheetcount"].ToString()) > 1)
       {
           if (licno_Count > 0)
           {
               dt_final = Filter_EmptyRows(data_all.Tables[1]);
               xxx = dt_final.Rows.Count;
               if (xxx > 0)
               {
                   if (dt_final.Rows.Count > 0)
                   {
                       //IEnumerable<DataRow> rowsc2 = data_all.Tables[1].Rows.Cast<DataRow>().Where(r => r["INVSLNO"].ToString().Contains(Convert.ToString(dt_New.Rows[0][l].ToString())));
                       //rowsc2.ToList().ForEach(r => r.SetField("INVSLNO", Convert.ToString(Invoice_Slno)));
                       Bind_Bulk_LICENSE_DETAILS(dt_final);
                   }
               }
               dt_final.Clear();
           }
       }

       //PACKAGE DETAILS
       if (Convert.ToInt32(ViewState["Sheetcount"].ToString()) > 2)
       {
           dt_final = Filter_EmptyRows(data_all.Tables[2]);
           xxx = dt_final.Rows.Count;
           if (xxx > 0)
           {
               if (dt_final.Rows.Count > 0)
               {
                   Bind_Annex_PACKAGE_DETAILS(dt_final);
               }
           }
       }
      
       dt_gen.Clear();
       dt_gen.Dispose();
       GC.Collect();

       Session["JOBIDexcel"] = Get_JOBID();

       Alert_msg("Excel Uploaded Successfully...");
   }

   public string Get_JOBID()
   {
       DataSet d = new DataSet();
       objUBO.IEC_NO = EXPORT_JOBNO;
       objUBO.BRANCH_NO = "";
       objUBO.Ename = "Get_JOBID";
       objUBO.WORKING_PERIOD = SELECT_BRANCH;
       d = xl.Bind_Export_General_IEC_No(objUBO);
       if (d.Tables[0].Rows.Count > 0)
       {
           Current_JOBID = d.Tables[0].Rows[0]["JOBID"].ToString();
       }
       return Current_JOBID;
   }

   public void Open_Schemecode()
   {
       if (scheme == "00")
       {
           scheme = "00-FREE SHIPPING BILL";
       }
       else if (scheme == "")
       {
           scheme = "00-FREE SHIPPING BILL";

       }
       else if (scheme == "01")
       {
           scheme = "01-ADVANCE LICENSE ACT. USER COND";
           scheme_name[0] = "DEEC";
       }
       else if (scheme == "02")
       {
           scheme = "02-ADVANCE LICENSE INTERM SUPPLIES";
           scheme_name[0] = "DEEC";
       }
       else if (scheme == "03")
       {
           scheme = "03-ADVANCE LICENSE";
           scheme_name[0] = "DEEC";
       }
       else if (scheme == "04")
       {
           scheme = "04-ADVANCE RELEASE ORDER";
           scheme_name[0] = "DEEC";
       }
       else if (scheme == "05")
       {
           scheme = "05-ADVANCE RELEASE DEEMED EXPORT";
           scheme_name[0] = "DEEC";
       }
       else if (scheme == "08")
       {
           scheme = "08-REPLENISHMENT LICENSE";
           scheme_name[0] = "DEEC";
       }
       else if (scheme == "09")
       {
           scheme = "09-DIAMOND IMPREST LICENSE";
           scheme_name[0] = "DEEC";
       }
       else if (scheme == "11")
       {
           scheme = "11-CONCESSIONAL DUTY EPCG";
           scheme_name[0] = "DEEC";
       }
       else if (scheme == "12")
       {
           scheme = "12-ZERO DUTY EPCG SCHEME";
           scheme_name[0] = "DEEC";
       }
       else if (scheme == "17")
       {
           scheme = "17-ADVANCE LICENSE  ANNUAL REQ.";
           scheme_name[0] = "DEEC";
       }
       else if (scheme == "19")
       {
           scheme = "19-DRAWBACK (DBK)";
       }
       else if (scheme == "20")
       {
           scheme = "20-JOBBING (JBG)";
       }
       else if (scheme == "21")
       {
           scheme = "21-EOU/EPZ/SEZ/EHTP/STP";
       }

       else if (scheme == "24-VKUY")
       {
           scheme = "24-VKUY";
       }
       else if (scheme == "25-DFIA")
       {
           scheme = "25-DFIA";
       }
       else if (scheme == "26")
       {
           scheme = "26-DFIA";
       }
       else if (scheme == "27")
       {
           scheme = "27-FMS";
       }
       else if (scheme == "28")
       {
           scheme = "28-FPS";
       }
       else if (scheme == "41")
       {
           scheme = "41-DRAWBACK AND ADVANCE LICENSE";
           scheme_name[0] = "DEEC";
       }

       else if (scheme == "43")
       {
           scheme = "43-DRAWBACK AND ZERO DUTY EPCG";
           scheme_name[0] = "EPCG";
       }
       else if (scheme == "44")
       {
           scheme = "44-DRAWBACK AND CONCESS. EPCG";
           scheme_name[0] = "EPCG";
       }
       else if (scheme == "47")
       {
           scheme = "47-DRAWBACK AND JOBBING";
       }
       else if (scheme == "48")
       {
           scheme = "48-DRAWBACK AND DIAMOND IMP LICENSE";
           scheme_name[0] = "DEEC";
       }
       else if (scheme == "49")
       {
           scheme = "49-DRAWBACK AND EOU/EPZ/SEZ";
       }
       else if (scheme == "50")
       {
           scheme = "50-EPCG AND ADVANCE LICENSE";
           scheme_name[0] = "EPCG";
           scheme_name[1] = "DEEC";
       }
       else if (scheme == "52")
       {
           scheme = "52-EPCG AND JOBBING";
           scheme_name[0] = "EPCG";
       }
       else if (scheme == "53")
       {
           scheme = "53-EPCG AND DIAMOND IMPREST LICENSE";
           scheme_name[0] = "EPCG";
           scheme_name[1] = "DEEC";
       }
       else if (scheme == "54")
       {
           scheme = "54-EPCG AND REPLENISHMENT LICENSE";
           scheme_name[0] = "EPCG";
           scheme_name[1] = "DEEC";
       }
       else if (scheme == "55")
       {
           scheme = "55-EPCG AND POST EXPORT DEPB";
           scheme_name[0] = "EPCG";
       }
       else if (scheme == "59")
       {
           scheme = "59-EPCG, DFIA";
           scheme_name[0] = "EPCG";
       }

       else if (scheme == "60")
       {
           scheme = "60-DRAWBACK AND ROSL";
       }
       else if (scheme == "61")
       {
           scheme = "61-EPCG, DRAWBACK AND ROSL";
       }
       else if (scheme == "62")
       {
           scheme = "62-DRAWBACK AND SPL AA";
       }
       else if (scheme == "63")
       {
           scheme = "63-EPCG,DRAWBACK AND SPL AA";
       }  
       else if (scheme == "64")
       {
           scheme = "64-DRAWBACK, SPL AA ( 4.04A) AND ROSL";
           scheme_name[0] = "DEEC";
       }
       else if (scheme == "65")
       {
           scheme = "65-EPCG, DRAWBACK, SPL AA(4.04A) AND ROSL";
       }

       else if (scheme == "71")
       {
           scheme = "71-EPCG, DRAWBACK AND DEEC";
           scheme_name[0] = "EPCG";
           scheme_name[1] = "DEEC";
       }
       else if (scheme == "73")
       {
           scheme = "73-EPCG, DRAWBACK AND JOBBING";
           scheme_name[0] = "EPCG";
       }
       else if (scheme == "74")
       {
           scheme = "74-EPCG, DRAWBACK AND DIMOND IMPREST";
           scheme_name[0] = "EPCG";
           scheme_name[1] = "DEEC";
       }
       else if (scheme == "79")
       {
           scheme = "79-EPCG, DRAWBACK AND DFIA";
           scheme_name[0] = "EPCG";
           scheme_name[1] = "DFIA";
       }
       else if (scheme == "99")
       {
           scheme = "99-NFEI";
       }
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
 
   public string fnGetPictureExtn(string pictureName)
   {
       try
       {
           if (pictureName.ToUpper().EndsWith(".JPG"))
               return ".JPG";
           else if (pictureName.ToUpper().EndsWith(".JPEG"))
               return ".JPEG";
           else if (pictureName.ToUpper().EndsWith(".GIF"))
               return ".GIF";
           else if (pictureName.ToUpper().EndsWith(".DOC"))
               return ".DOC";
           else if (pictureName.ToUpper().EndsWith(".XLS"))
               return ".XLS";
           else if (pictureName.ToUpper().EndsWith(".PDF"))
               return ".PDF";
           else if (pictureName.ToUpper().EndsWith(".PNG"))
               return ".PNG";
           else if (pictureName.ToUpper().EndsWith(".CDR"))
               return ".CDR";
           else if (pictureName.ToUpper().EndsWith(".PSD"))
               return ".PSD";
           else if (pictureName.ToUpper().EndsWith(".TXT"))
               return ".TXT";
           else if (pictureName.ToUpper().EndsWith(".XLSX"))
               return ".XLSX";
           else
           {
           }
       }
       catch
       {
       }
       finally
       {
       }
       return "";
   }

   public void addtoGallery1(string picName, string folderName, string Excel_Name)
   {
       string strFolderPath;
       string strImagePath;
       try
       {
           strFolderPath = Path.Combine(Request.PhysicalApplicationPath, folderName);
           strImagePath = Path.Combine(strFolderPath, picName);

           if (Excel_Name == "INDEV")
           {
               //fileuploadExcel1.SaveAs(strImagePath);
           }
           else
           {
               fileuploadExcel.SaveAs(strImagePath);
           }

       }
       catch
       {
       }
       finally
       {
       }
   }

   public void GET_LICENSE_ID()
   {
       DataSet ds = new DataSet();
       Export_Licence Export_license = new Export_Licence();
       Export_license.LICENSE_NO = "0";
       Export_license.Ename = "GET_EXPORT_LICENSE_ID_MAX";
       ds = Export_license.Export_License_Master_Select();
       License_id_Max = Convert.ToInt32(ds.Tables[0].Rows[0]["LICENSE_ID"].ToString());
       License_id_IMP_EXP_Max = Convert.ToInt32(ds.Tables[1].Rows[0]["LICENSE_IMP_EXP_ID"].ToString());
   }

   public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
   {
       Hashtable hTable = new Hashtable();
       ArrayList duplicateList = new ArrayList();
       foreach (DataRow dtRow in dTable.Rows)
       {
           if (hTable.Contains(dtRow[colName]))
               duplicateList.Add(dtRow);
           else
               hTable.Add(dtRow[colName], string.Empty);
       }
       foreach (DataRow dtRow in duplicateList)
           dTable.Rows.Remove(dtRow);
       return dTable;
   }

   public string Convert_DateFormate(string result)
   {

       string[] date = result.Split('/');
       string aa = date[0];
       string bb = date[1];
       string cc = date[2];

       if (bb.Count() == 3)
       {
           if (bb == "Jan")
           {
               bb = "01";
           }
           else if (bb == "Feb")
           {
               bb = "02";
           }
           else if (bb == "Mar")
           {
               bb = "03";
           }
           else if (bb == "Apr")
           {
               bb = "04";
           }
           else if (bb == "May")
           {
               bb = "05";
           }
           else if (bb == "Jun")
           {
               bb = "06";
           }
           else if (bb == "Jul")
           {
               bb = "07";
           }
           else if (bb == "Aug")
           {
               bb = "08";
           }
           else if (bb == "Sep")
           {
               bb = "09";
           }
           else if (bb == "Oct")
           {
               bb = "10";
           }
           else if (bb == "Nov")
           {
               bb = "11";
           }
           else if (bb == "Dec")
           {
               bb = "12";
           }
       }

       result = bb + "/" + aa + "/" + cc;

       return result;
   }


   protected void btnNewJobyes_Click(object sender, EventArgs e)
   {
       DataSet ds_newjob = new DataSet();

       //objUBO.IEC_NO = EXPORT_JOBNO;
       //objUBO.BRANCH_NO = "";
       //objUBO.Ename = "get_MAX_Invoice_SlNo";
       //objUBO.WORKING_PERIOD = SELECT_BRANCH;
       //ds = xl.Bind_Export_General_IEC_No(objUBO);

       EXU.JOBNO = "";
       EXU.Xml_D = "";
       EXU.Branch_Code = SELECT_BRANCH;
       EXU.Ename = "Get_MaxJobno";
       ds_newjob = EXU.Select_Exp_INV();

       if (ds_newjob.Tables[0].Rows.Count > 0)
       {
           EXPORT_JOBNO = ds_newjob.Tables[0].Rows[0][0].ToString();
           //Excel_Upload_load(MAX_INVOICE_SLNO, Is_Additional_INV);
           Excel_Upload_load("", "");
       }

   }

   protected void btnNo_Click(object sender, EventArgs e)
   {
       DataSet ds = new DataSet();

       MP_U_job.Show();

       //objUBO.IEC_NO = EXPORT_JOBNO;
       //objUBO.BRANCH_NO = "";
       //objUBO.Ename = "get_MAX_Invoice_SlNo";
       //objUBO.WORKING_PERIOD = SELECT_BRANCH;
       //ds = xl.Bind_Export_General_IEC_No(objUBO);

       //objUBO.JOBNO = EXPORT_JOBNO;
       //objUBO.Ename = "get_MAX_Invoice_SlNo";
       //objUBO.Xml_D = "";

       //EXU.JOBNO = EXPORT_JOBNO;
       //EXU.Xml_D = "";
       //EXU.Branch_Code = SELECT_BRANCH;
       //EXU.Ename = "get_MAX_Invoice_SlNo";
       //ds = EXU.Select_Exp_INV();

       //Is_Additional_INV = "YES";

       //if (ds.Tables[0].Rows.Count > 0)
       //{
       //    MAX_INVOICE_SLNO = ds.Tables[0].Rows[0][0].ToString();
       //    Excel_Upload_load(MAX_INVOICE_SLNO, Is_Additional_INV);
       //}


       /*
       objUBO.IEC_NO = EXPORT_JOBNO;
       objUBO.BRANCH_NO = "";
       objUBO.Ename = "Delete_Excel";
       objUBO.WORKING_PERIOD = SELECT_BRANCH;
       ds = xl.Bind_Export_General_IEC_No(objUBO);
       i = xl.result;

       if (i == 1)
       {
           Alert_msg("Job Deleted Successfully");
           MP_U.Hide();
       }
       else
       {
           Alert_msg("Error File");
       }
       */
   }

}