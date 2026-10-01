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

public partial class Export_INV_Gen_Excel : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    DataSet data = new DataSet();
    UserBO objUBO = new UserBO();
    eroyalmaster erm = new eroyalmaster();
    Annexure_C_Sea ANNEX_C_Sea = new Annexure_C_Sea();
    Annexure_C_Air ANNEX_C_Air = new Annexure_C_Air();
    Annexure ANNEX = new Annexure();

    DataSet ds_scheme = new DataSet();
    DataSet dss = new DataSet();
    DataSet ds_IEC = new DataSet();

    DataTable dt_gen = new DataTable();
    DataTable dt_cont = new DataTable();
    DataTable dt_PKG = new DataTable();
    DataTable dt_Inv = new DataTable();
    DataTable dt_Item = new DataTable();
    DataTable dt_Lic = new DataTable();
    DataTable dt_Imp_Exp_lic = new DataTable();
    DataTable dt_Dbk = new DataTable();
    DataTable dt_AR4 = new DataTable();
    DataTable dt_blk_Lic = new DataTable();
    DataTable dt_blk_Imp_Exp_lic = new DataTable();
    DataTable dt_SW_INFO = new DataTable();
    DataTable dt_SW_CTRL = new DataTable();
    DataTable dt_SW_STMT = new DataTable();

    Jobwise_xl_Upload xl = new Jobwise_xl_Upload();
    AdminMasterDetails admin = new AdminMasterDetails();
    public int MAX_ID = 0;
    public int i;
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    
    public string SELECT_TYPE, SELECT_BRANCH;
    public string EXPORT_JOBNO,EXPORT_JOBDATE; 

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    public string errorFolder = "", logline = "", logFileName = "";
    public string folderName = "/Submission";
    public string COMPANY_IDD, comp_ConnectionStr;

    public string scheme;
    string[] scheme_name = new string[2];   

    public int License_id_Max = 0;
    public int License_id_IMP_EXP_Max = 0;

    public string[] lic_no;
    public int licno_Count;
    public decimal item_amt;


    DataSet ds_TPD = new DataSet();
    DataSet ds_draw = new DataSet();
    DataSet ds_license = new DataSet();

    Auto_Search Auto = new Auto_Search();
    Export_Licence License = new Export_Licence();
   
    Export_XL_Upload EXU = new Export_XL_Upload();

    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt = new DataTable();

    public string JOBID = "", JOBNO = "", JOBDATE = "", TRANSPORT_MODE = "", CUSTOMS_HOUSE = "", CUSTOMS_HOUSE_NAME = "", SB_TYPE = "", EXPORTER_NAME = "", BRANCH_NO = "",
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
                  TRANSIT_COUNTRY = "", ACCESSORY_STATUS = "", HAWB_NO = "", TOTAL_PKGS = "", ENDUSE_ITEM = "", IGST_PAYMENT = "", TAXABLE_VALUE = "", IGST_AMT = "", GSTN_TYPE = "", GSTN_ID = "";

    public string  SCHEME_CODE = "", DRAWBACK_SLNO = "", DRAWBACK_QTY = "", DRAWBACK_UNIT = "", DRAWBACK_NOOFUNITS = "", DRAWBACK_RATE = "", DRAWBACK_CAPS = "", DRAWBACK_DESC = "", STATE_LEVEL_ADV_RATE = "", STATE_LEVEL_ADV_AMT = "";

    public string AR4_JOBNO="",AR4_NO="",AR4_DATE="",AR4_COMMISSION_RATE="",AR4_DIVISION="",AR4_RANGE="",AR4_REMARKS="",AR4_INVOICE_NO="",AR4_INVOICE_SLNO="",AR4_RUN_ID="",AR4_ITEM_NO="";

    public string  SCHEME = "",  LICENSE_NO = "", LICENSE_DATE = "",LICENSE_REG_SLNO="",LICENSE_E_SL_NO="",LICENSE_EXP_QTY="",LICENSE_EXP_UNIT="",LICENSE_IMP_ITEM_SL_NO="",LICENSE_IMP_DESC="",LICENSE_IMP_QTY="",LICENSE_IMP_UNIT="",LICENSE_IMP_TYPE="",
                    LICENSE_REG_DATE="",LICENSE_REG_TYPE="",LICENSE_ITEM_SL_NO="",LICENSE_ITEM_DESCRIPTION="",LICENSE_QTY="",LICENSE_UNIT="",LICENSE_TYPE="";

    public int LICENSE_ID, LICENSE_IMP_EXP_ID, LICENSE_R_SL_NO, DRAWBACK_ID, AR4_ID;

    string SW_INFO_TYPE_ID = "", INFO_TYPE = "", INFO_QUALIFIER = "", INFO_CODE = "", INFO_TEXT = "", INFO_MSR = "", INFO_UQC = "", DEPARTMENT = "", I_U_TYPE = "";

    string SW_CONTROL_ID = "", CONTROL_TYPE_CODE = "", CONTROL_LOCATION = "", CONTROL_START_DATE = "", CONTROL_END_DATE = "", CONTROL_RESULT_CODE = "", CONTROL_RESULT_TEXT = "";

    string SW_ID = "", STMT_DECLARATION_TYPE = "", STMT_DECLARATION_NUMBER = "", STMT_DECLARATION_DATE = "", STMT_TYPE = "", STMT_CODE = "", STMT_TEXT = "",SR_NO="";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        TRANSPORT_MODE = Session["Transport_Mode_Port"].ToString();
        SB_TYPE = Session["EXPORT_SBTYPE"].ToString();
        COMPANY_IDD = Session["COMPANY_ID"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();

        hdfTransport_mode.Value = Session["Transport_Mode_Port"].ToString();

        //if (Session["EXPORT_JOBNO"] != null)
        //{
        //    EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
        //    EXPORT_JOBDATE = Session["EXPORT_JOBDATE"].ToString();
        //}

        if (Session["Jobno_Excel"] != null || Session["Jobno_Excel"] != null)
        {
            EXPORT_JOBNO = Session["Jobno_Excel"].ToString();
        }

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
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Export_Excel");
        if (!Page.IsPostBack)
        {          
        }
       
        //Call_Data_Table();
    }
    
   
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
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
                       EXU.Ename = "Excel_Aval";
                       EXU.Branch_Code = SELECT_BRANCH;
                       d = EXU.Select_Exp_INV();

                       if (d.Tables[0].Rows.Count > 0)
                       {
                           MP_U.Show();
                       }
                       else
                       {
                           Excel_Upload_load();
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
           Alert_msg("Not Deleted ur Old Job");
       }

   }

   public void Bind_General_Details(DataTable General_data)
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


       #endregion dt_gen

       //if (General_data.Rows[0][19].ToString() == "")
       //{
           int xx, yy;
           ViewState["General_data"] = General_data;

           JOBDATE = General_data.Rows[0][0].ToString();
           FILE_REF_NO = General_data.Rows[0][1].ToString();
           CUSTOMS_HOUSE = General_data.Rows[0][2].ToString();
           IEC_NO = General_data.Rows[0][3].ToString();
           BRANCH_NO = General_data.Rows[0][4].ToString() == string.Empty ? "0" : General_data.Rows[0][4].ToString();
           EXPORTER_NAME = General_data.Rows[0][5].ToString();

           xx = Check_Avail_IEC_Master(IEC_NO, BRANCH_NO, "Check_Avail_IEC_details");

           if (xx == 1)
           {
               //if (currentuser != "AURIONPRO")
               //{
                   if (ADDRESS1 == "")
                   {
                       if (IEC_NO != "" && BRANCH_NO != "")
                       {
                           ds_IEC = Get_Importer_HSS_Details(IEC_NO, BRANCH_NO);

                           if (ds_IEC.Tables[0].Rows.Count > 0)
                           {
                               EXPORTER_NAME = ds_IEC.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                               ADDRESS1 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                               ADDRESS2 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                               ADDRESS3 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                               ADDRESS4 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                               ADDRESS5 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                              
                           }
                       }
                   //}
               }
               else
               {
                   EXPORTER_NAME = General_data.Rows[0][5].ToString();
                   ADDRESS1 = General_data.Rows[0][7].ToString();
                   ADDRESS2 = General_data.Rows[0][8].ToString();
                   ADDRESS3 = General_data.Rows[0][9].ToString();
                   ADDRESS4 = General_data.Rows[0][10].ToString();
                   ADDRESS5 = General_data.Rows[0][11].ToString();
               }
           }
           else
           {
               erm.IMP_EXP_ID = "";
               erm.IMP_EXP_NAME = General_data.Rows[0][5].ToString();
               erm.IMP_EXP_IECNO = IEC_NO;
               erm.IMP_EXP_BRSLNO = BRANCH_NO;
               if (General_data.Rows[0][12].ToString() == "GOVERNMENT")
               {
                   erm.IMP_EXP_TYPE = "G";
               }
               else
               {
                   erm.IMP_EXP_TYPE = "P";
               }
               erm.IMP_EXP_ADD1 = General_data.Rows[0][7].ToString();
               erm.IMP_EXP_ADD2 = General_data.Rows[0][8].ToString();
               erm.IMP_EXP_ADD3 = General_data.Rows[0][9].ToString();
               erm.IMP_EXP_ADD4 = General_data.Rows[0][10].ToString();
               erm.IMP_EXP_PIN_CODE = General_data.Rows[0][11].ToString();
               erm.IMP_EXP_CONTACT_PERSON = "";
               erm.IMP_EXP_PHONE = "";

               erm.IMP_EXP_FAX = "";
               erm.IMP_EXP_EMAIL = "";
               erm.IMP_EXP_BINNO = "";
               erm.IMP_EXP_REMARKS = "";
               erm.IMP_EXP_DRAWBACK_AC_NO = "";
               erm.IMP_EXP_PAN_NO = "";

               //STANDARD_TYPE = ViewState["STANDARD_TYPE"].ToString();

               //if (STANDARD_TYPE == "Non_STD")
               //{
               //    erm.STANDARD_TYPE = STANDARD_TYPE;
               //}
               //else
               //{
               erm.STANDARD_TYPE = null;
               //}

               erm.TIN_NO = "";
               erm.STATE_CODE = General_data.Rows[0][17].ToString();

               erm.USER_ID = currentuser;
               erm.BRANCH_CODE = currentbranch;
               erm.flag = "S";
               erm.YEAR = "";
               erm.EWorking_Period = Working_Period;
               erm.EXP_STR_YN = "";
               //string Type_Of_Exporter = "";

               //if (ddlType_Exp.SelectedItem.Text == "Manufacturer - ( F )")
               //{
               //Type_Of_Exporter = "F";
               //}
               //else
               //{
               //    Type_Of_Exporter = "R";
               //}
               erm.TYPE_OF_EXPORTER = "F";
               erm.MARKS_NO = General_data.Rows[0][18].ToString();

               erm.COMMERCIAL_DETAILS_STATUS = "N";
               erm.COMMERCIAL_TAX_STATENAME = "";
               erm.COMMERCIAL_TAX_STATECODE = "";
               erm.COMMERCIAL_TAX_TYPE = "";
               erm.COMMERCIAL_TAX_REGISTRATION_NO = "";
               

               i = erm.Imp_Exp_Master_Insert_update_STD();

               EXPORTER_NAME = General_data.Rows[0][5].ToString();
               ADDRESS1 = General_data.Rows[0][7].ToString();
               ADDRESS2 = General_data.Rows[0][8].ToString();
               ADDRESS3 = General_data.Rows[0][9].ToString();
               ADDRESS4 = General_data.Rows[0][10].ToString();
               ADDRESS5 = General_data.Rows[0][11].ToString();
           }

           if (currentuser != "AURIONPRO")
           {
               EXPORTER_NAME = General_data.Rows[0][5].ToString();
               ADDRESS1 = General_data.Rows[0][7].ToString();
               ADDRESS2 = General_data.Rows[0][8].ToString();
               ADDRESS3 = General_data.Rows[0][9].ToString();
               ADDRESS4 = General_data.Rows[0][10].ToString();
               ADDRESS5 = General_data.Rows[0][11].ToString();
           }

        
           TYPE_OF_EXPORTER = General_data.Rows[0][12].ToString();

           if (TYPE_OF_EXPORTER == "Manufacturer -(F)")
           {
               TYPE_OF_EXPORTER = "F";
           }
           else
           {
               TYPE_OF_EXPORTER = "R";
           }


           COUNTRY_DISCHARGE = General_data.Rows[0][13].ToString();
           PORT_DISCHARGE = General_data.Rows[0][14].ToString();
           COUNTRY_FINAL_DEST = General_data.Rows[0][15].ToString();
           PORT_FINAL_DEST = General_data.Rows[0][16].ToString();
          

           if (General_data.Rows[0][17].ToString().Contains('-'))
           {
               string[] aa = General_data.Rows[0][17].ToString().Split('-');
               STATE_OF_EXPORT = aa[1].Trim();
               txtStateExport.Text = STATE_OF_EXPORT;
           }
           else
           {
               STATE_OF_EXPORT = General_data.Rows[0][17].ToString();
               txtStateExport.Text = STATE_OF_EXPORT;
           }

           if (COUNTRY_DISCHARGE != "")
           {
               txtCountryOrigin.Text = COUNTRY_DISCHARGE;
           }
           else
           {
               COUNTRY_DISCHARGE = txtCountryOrigin.Text;
           }

           if (COUNTRY_FINAL_DEST != "")
           {

           }
           else
           {
               COUNTRY_FINAL_DEST = COUNTRY_DISCHARGE;
           }

           if (PORT_DISCHARGE != "")
           {
               txtPortShipment.Text = PORT_DISCHARGE;
           }
           else
           {
               PORT_DISCHARGE = txtPortShipment.Text;
           }

           if (PORT_FINAL_DEST != "")
           {

           }
           else
           {
               PORT_FINAL_DEST = PORT_DISCHARGE;
           }

           //if (STATE_OF_EXPORT != "")
           //{
           //    txtStateExport.Text = STATE_OF_EXPORT;
           //}
           //else
           //{
           //    STATE_OF_EXPORT = txtCountryOrigin.Text;
           //}

           MARKS_NO = General_data.Rows[0][18].ToString();
           ADCODE = General_data.Rows[0][19].ToString();
           CONSIGNEE_NAME = General_data.Rows[0][20].ToString();
           CONSIGNEE_BRANCHSLNO = General_data.Rows[0][21].ToString();
           CONSIGNEE_ADD1 = General_data.Rows[0][22].ToString();

           ds_IEC.Clear();
           yy = Check_Avail_IEC_Master(CONSIGNEE_NAME, CONSIGNEE_BRANCHSLNO, "Check_Avail_CONSIGNEE_details");

           if (yy == 1)
           {
               if (CONSIGNEE_ADD1 == "")
               {
                   //ds_IEC = Get_Importer_HSS_Details(IEC_NO, BRANCH_NO);
                   if (ds_IEC.Tables[0].Rows.Count > 0)
                   {
                       EXPORTER_NAME = ds_IEC.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                       CONSIGNEE_ADD1 = ds_IEC.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                       CONSIGNEE_ADD2 = ds_IEC.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                       CONSIGNEE_ADD3 = ds_IEC.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                       CONSIGNEE_ADD4 = ds_IEC.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();
                       CONSIGNEE_ADD5 = ds_IEC.Tables[0].Rows[0]["CONSIGNEE_COUNTRY_NAME"].ToString();
                   }
               }
               else
               {
                   CONSIGNEE_ADD1 = General_data.Rows[0][22].ToString();
                   CONSIGNEE_ADD2 = General_data.Rows[0][23].ToString();
                   CONSIGNEE_ADD3 = General_data.Rows[0][24].ToString();
                   CONSIGNEE_ADD4 = General_data.Rows[0][25].ToString();
                   CONSIGNEE_ADD5 = General_data.Rows[0][26].ToString();
               }
           }
           else
           {
               erm.CONSIGNEE_ID = "";
               erm.CONSIGNEE_NAME = General_data.Rows[0][20].ToString();
               erm.CONSIGNEE_ADD1 = General_data.Rows[0][22].ToString();
               erm.CONSIGNEE_ADD2 = General_data.Rows[0][23].ToString();
               erm.CONSIGNEE_ADD3 = General_data.Rows[0][24].ToString();
               erm.CONSIGNEE_ADD4 = General_data.Rows[0][25].ToString();
               erm.CONSIGNEE_COUNTRY_CODE = "";
               erm.CONSIGNEE_COUNTRY_NAME = General_data.Rows[0][26].ToString();
               erm.CONSIGNEE_PIN_CODE = "";
               erm.CONSIGNEE_REMARKS = "";


               erm.CONSIGNEE_BRANCHSLNO = General_data.Rows[0][21].ToString();

               erm.USER_ID = currentuser;
               erm.BRANCH_CODE = currentbranch;
               erm.flag = "S";
               erm.YEAR = "";
               erm.EWorking_Period = Working_Period;

               i = erm.Consignee_Master_Insert_update();

               CONSIGNEE_ADD1 = General_data.Rows[0][22].ToString();
               CONSIGNEE_ADD2 = General_data.Rows[0][23].ToString();
               CONSIGNEE_ADD3 = General_data.Rows[0][24].ToString();
               CONSIGNEE_ADD4 = General_data.Rows[0][25].ToString();
               CONSIGNEE_ADD5 = General_data.Rows[0][26].ToString();
           }

           if (currentuser != "AURIONPRO")
           {
               CONSIGNEE_ADD1 = General_data.Rows[0][22].ToString();
               CONSIGNEE_ADD2 = General_data.Rows[0][23].ToString();
               CONSIGNEE_ADD3 = General_data.Rows[0][24].ToString();
               CONSIGNEE_ADD4 = General_data.Rows[0][25].ToString();
               CONSIGNEE_ADD5 = General_data.Rows[0][26].ToString();
           }

           NFEI = General_data.Rows[0][27].ToString();

           if (NFEI == "" || NFEI == "No")
           {
               NFEI = "No";
               NFEI_TYPE = "";
               RBI_WAIVER_NO = "";
               RBI_WAIVER_DATE = General_data.Rows[0][30].ToString() == string.Empty ? "01/01/1900" : General_data.Rows[0][30].ToString();
           }
           else
           {
               NFEI = "Yes";
               NFEI_TYPE = General_data.Rows[0][28].ToString();
               RBI_WAIVER_NO = General_data.Rows[0][29].ToString();
               RBI_WAIVER_DATE = General_data.Rows[0][30].ToString() == string.Empty ? "01/01/1900" : General_data.Rows[0][30].ToString();
           }
           if (General_data.Rows[0][40].ToString() != "")
           {
               GSTN_TYPE = General_data.Rows[0][40].ToString().Substring(0, 3);
           }
           else
           {
               GSTN_TYPE = "";
           }
           GSTN_ID = General_data.Rows[0][41].ToString();

           JOBID = Convert.ToString(Get_general_MAXID("Gen_MAX_ID"));
           JobNo_Prefix_Sufix();
           SB_TYPE = "Free Duty";
           JOB_RELEASE = "No";
           JOB_FILED_STATUS = "Created";

           dt_gen.Rows.Add(JOBID, EXPORT_JOBNO, JOBDATE, TRANSPORT_MODE, CUSTOMS_HOUSE, CUSTOMS_HOUSE_NAME, SB_TYPE, EXPORTER_NAME, BRANCH_NO, IEC_NO, ADDRESS1, ADDRESS2, ADDRESS3, ADDRESS4, ADDRESS5,
                           ADCODE, BANK_ACCOUNT, DRAWBACK_ACCOUNT, CONSIGNEE_NAME, CONSIGNEE_ADD1, CONSIGNEE_ADD2, CONSIGNEE_ADD3, CONSIGNEE_ADD4, CONSIGNEE_ADD5, COUNTRY_DISCHARGE,
                           PORT_DISCHARGE, COUNTRY_FINAL_DEST, PORT_FINAL_DEST, STATE_OF_EXPORT, NFEI, NFEI_TYPE, RBI_WAIVER_NO, RBI_WAIVER_DATE, MARKS_NO, currentuser, LoginDate,
                           "N", currentbranch, Working_Period, FILE_REF_NO, JOB_STATUS, JOB_RELEASE, JOB_FILED_STATUS, currentuser, LoginDate, TYPE_OF_EXPORTER, JOB_PREFIX, JOB_SUFFIX, JOBNO_PS, CONSIGNEE_BRANCHSLNO, GSTN_TYPE,GSTN_ID);

           //ViewState["ds_GENERAL"] = dt_gen;
           //ds_GENERAL.Tables.Add(dt_gen);
           if (dt_gen.Rows.Count > 0)
           {
               admin.SqlBulk_Upload_Product("EXPORT_GENERAL_DETAILS", dt_gen, comp_ConnectionStr);
           }

           if (General_data.Rows[0][31].ToString() != "")
           {
               Annexure_Air_Sea_Insert(General_data);
           }
                  
       //}
       //Alert_msg("ADCode Mandatory");
   }

   public void Annexure_Air_Sea_Insert(DataTable General_data)
   {
       if (TRANSPORT_MODE == "Sea")
       {
           ANNEX_C_Sea.ANNEX_SEA_JOBNO = EXPORT_JOBNO;
           // ANNEX_C_Sea.ANNEX_SEA_FAC_STUFFED = txtFactory_Stuffed.Text;
           //ANNEX_C_Sea.ANNEX_SEA_SAMPLE_ACCOM = txtSample_Accompanied.Text;
           ANNEX_C_Sea.ANNEX_SEA_FAC_STUFFED = "N";
           ANNEX_C_Sea.ANNEX_SEA_SAMPLE_ACCOM = "N";
           string Nature_Cargo = "";
           if (General_data.Rows[0][31].ToString() == "C Containerized")
           {
               Nature_Cargo = "C";
           }
           if (General_data.Rows[0][31].ToString() == "P Packaged")
           {
               Nature_Cargo = "P";
           }
           if (General_data.Rows[0][31].ToString() == "CP Containerized")
           {
               Nature_Cargo = "CP";
           }
           if (General_data.Rows[0][31].ToString() == "LB Liquid and Bulk")
           {
               Nature_Cargo = "LB";
           }
           if (General_data.Rows[0][31].ToString() == "DB Dry Bulk")
           {
               Nature_Cargo = "DB";
           }

           ANNEX_C_Sea.ANNEX_SEA_NATURE_OF_CARGO = Nature_Cargo;
           ANNEX_C_Sea.ANNEX_SEA_MARKS_NOS = General_data.Rows[0][33].ToString();
           ANNEX_C_Sea.ANNEX_SEA_TOTAL_PACKAGES = General_data.Rows[0][32].ToString();
           ANNEX_C_Sea.ANNEX_SEA_LOOSE_PACKETS = General_data.Rows[0][38].ToString();
           ANNEX_C_Sea.ANNEX_SEA_NO_CONTAINERS = General_data.Rows[0][37].ToString();
           ANNEX_C_Sea.ANNEX_SEA_GROSS_WEIGHT = General_data.Rows[0][34].ToString();
           ANNEX_C_Sea.ANNEX_SEA_NET_WEIGHT = General_data.Rows[0][35].ToString();
           ANNEX_C_Sea.ANNEX_SEA_UNIT_MEASUREMENT = General_data.Rows[0][36].ToString();
           ANNEX_C_Sea.ANNEX_SEA_ROTATION_NO = "";
           //string dt = "";
           //if (txtRotationDate.Text != "")
           //{
           //    dt = txtRotationDate.Text;
           //}
           //else
           //{
           //    dt = "01/01/1900";
           //}
           ANNEX_C_Sea.ANNEX_SEA_ROTATION_DATE = "01/01/1900";

           ANNEX_C_Sea.ANNEX_SEA_FOB_VALUE = "";

           ANNEX_C_Sea.USER_ID = currentuser;
           ANNEX_C_Sea.flag = "S";
           ANNEX_C_Sea.BRANCH_CODE = currentbranch;
           ANNEX_C_Sea.WORKING_PERIOD = Working_Period;
           ANNEX_C_Sea.BRANCH_COMMON = SELECT_BRANCH;
           ANNEX_C_Sea.ANNEX_SEA_SEAL_TYPE = General_data.Rows[0][39].ToString();
           i = ANNEX_C_Sea.Annexure_C_Sea_details_insertupdate();
       }
       else if (TRANSPORT_MODE == "Air")
       {
           ANNEX_C_Air.ANNEX_AIR_JOBNO = EXPORT_JOBNO;
           ANNEX_C_Air.ANNEX_AIR_SEALNO = "N";
           ANNEX_C_Air.ANNEX_AIR_SEAL_AGENCY = "N";

           ANNEX_C_Air.ANNEX_AIR_NATURE_OF_CARGO = "P";
           ANNEX_C_Air.ANNEX_AIR_MARKS_NOS = General_data.Rows[0][33].ToString();
           ANNEX_C_Air.ANNEX_AIR_TOTAL_PACKAGES = General_data.Rows[0][32].ToString();
           ANNEX_C_Air.ANNEX_AIR_UNIT_CODE = "";
           ANNEX_C_Air.ANNEX_AIR_FREIGHT_AMT = "";
           ANNEX_C_Air.ANNEX_AIR_INSURANCE_AMT = "";
           ANNEX_C_Air.ANNEX_AIR_GROSS_WEIGHT = General_data.Rows[0][34].ToString();
           ANNEX_C_Air.ANNEX_AIR_GR_UNIT_CODE = General_data.Rows[0][36].ToString();
           ANNEX_C_Air.ANNEX_AIR_NET_WEIGHT = General_data.Rows[0][35].ToString();
           ANNEX_C_Air.ANNEX_AIR_MAWB_NO = "";
           ANNEX_C_Air.ANNEX_AIR_HAWB_NO = "";
           ANNEX_C_Air.ANNEX_AIR_TOTAL_PACKAGES_MAWB = "";
           ANNEX_C_Air.ANNEX_AIR_ROTATION_NO = "";
           //string dt = "";
           //if (txtRotationDate.Text != "")
           //{
           //    dt = txtRotationDate.Text;
           //}
           //else
           //{
           //    dt = "01/01/1900";

           //}
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

       //******************** Remove Empty Rows from Datatable  ********************************

       PKG_data = PKG_data.Rows.Cast<DataRow>()
            .Where(row => !row.ItemArray.All(field => field is System.DBNull))
            .CopyToDataTable();

        //*********************************************************************************************************

       for (int i = 0; i <= PKG_data.Rows.Count - 1; i++)
       {
           /*
           ANNEX_SEA_PACK_GROUP = PKG_data.Rows[i][0].ToString();
           ANNEX_SEA_PACK_FROM = PKG_data.Rows[i][1].ToString();
           ANNEX_SEA_PACK_TO = PKG_data.Rows[i][2].ToString();
           ANNEX_SEA_PACK_PACKAGETYPE = PKG_data.Rows[i][3].ToString();
           ANNEX_SEA_PACK_FROMDESC = PKG_data.Rows[i][4].ToString();
           ANNEX_SEA_PACK_TODESC = PKG_data.Rows[i][5].ToString();

           int pkg_id = Convert.ToInt32(ANNEX_SEA_PACK_ID) + i;

           dt_PKG.Rows.Add(pkg_id, EXPORT_JOBNO, ANNEX_SEA_PACK_GROUP, ANNEX_SEA_PACK_FROM, ANNEX_SEA_PACK_TO, ANNEX_SEA_PACK_PACKAGETYPE, currentuser, LoginDate,
                            "N", currentbranch, "", Working_Period, ANNEX_SEA_PACK_FROMDESC, ANNEX_SEA_PACK_TODESC, currentuser, LoginDate);
            */
           int pkg_id = Convert.ToInt32(ANNEX_SEA_PACK_ID) + i;
           dt_PKG.Rows.Add(pkg_id, EXPORT_JOBNO, PKG_data.Rows[i][0].ToString(), //ANNEX_SEA_PACK_GROUP
                                                  PKG_data.Rows[i][1].ToString(), //ANNEX_SEA_PACK_FROM
                                                  PKG_data.Rows[i][2].ToString(), //ANNEX_SEA_PACK_TO
                                                  PKG_data.Rows[i][3].ToString(),//ANNEX_SEA_PACK_PACKAGETYPE
                                                  currentuser, LoginDate, "N", currentbranch, "", Working_Period,
                                                  PKG_data.Rows[i][4].ToString(), //ANNEX_SEA_PACK_FROMDESC
                                                  PKG_data.Rows[i][5].ToString(), //ANNEX_SEA_PACK_TODESC
                                                  currentuser, LoginDate);
                                        
       }

       //ViewState["ds_PACKAGE"] = dt_PKG;
       if (dt_PKG.Rows.Count > 0)
       {
           admin.SqlBulk_Upload_Product("EXPORT_ANNEXURE_C_SEA_PACKAGE", dt_PKG, comp_ConnectionStr);
       }
   }

   public void Bind_SEA_CONTAINER_DETAILS(DataTable Container_data)
   {
       if (TRANSPORT_MODE == "Sea")
       {
           #region dt_cont
           dt_cont.Columns.Add("ANNEX_SEA_CON_ID", typeof(int));
           dt_cont.Columns.Add("ANNEX_SEA_CON_JOBNO");
           dt_cont.Columns.Add("ANNEX_SEA_CON_CONTAINERNO");
           dt_cont.Columns.Add("ANNEX_SEA_CON_SIZE");
           dt_cont.Columns.Add("ANNEX_SEA_CON_TYPE");
           dt_cont.Columns.Add("ANNEX_SEA_CON_EXCISE_SEALNO");
           dt_cont.Columns.Add("ANNEX_SEA_CON_SEAL_DATE");
           dt_cont.Columns.Add("USER_ID");
           dt_cont.Columns.Add("DATE_TIME");
           dt_cont.Columns.Add("STATUS");
           dt_cont.Columns.Add("BRANCH_CODE");
           dt_cont.Columns.Add("YEAR");
           dt_cont.Columns.Add("WORKING_PERIOD");
           dt_cont.Columns.Add("MODIFIEDBY");
           dt_cont.Columns.Add("MODIFIEDON");
           dt_cont.Columns.Add("ANNEX_SEA_CON_SEALTYPE_INDICATOR");
           dt_cont.Columns.Add("ANNEX_SEA_CON_SEAL_DEVICEID");
           dt_cont.Columns.Add("ANNEX_SEA_CON_DOC_TYPE");
           dt_cont.Columns.Add("ANNEX_SEA_CON_DOC_NUMBER");
           #endregion dt_cont

           ANNEX_SEA_CON_ID = Convert.ToString(Get_general_MAXID("CONTAINER_MAX_ID"));

           //******************** Remove Empty Rows from Datatable  ********************************

           Container_data = Container_data.Rows.Cast<DataRow>()
                .Where(row => !row.ItemArray.All(field => field is System.DBNull))
                .CopyToDataTable();

           //*********************************************************************************************************

           for (int i = 0; i <= Container_data.Rows.Count - 1; i++)
           {
               /*
               ANNEX_SEA_CON_CONTAINERNO = Container_data.Rows[i][0].ToString();
               ANNEX_SEA_CON_SIZE = Container_data.Rows[i][1].ToString();
               ANNEX_SEA_CON_TYPE = Container_data.Rows[i][2].ToString();
               ANNEX_SEA_CON_EXCISE_SEALNO = Container_data.Rows[i][3].ToString();
               ANNEX_SEA_CON_SEAL_DATE = Container_data.Rows[i][4].ToString() == string.Empty ? "01/01/1900" : Container_data.Rows[i][4].ToString();
               ANNEX_SEA_CON_SEALTYPE_INDICATOR = Container_data.Rows[i][5].ToString();
               ANNEX_SEA_CON_SEAL_DEVICEID = Container_data.Rows[i][6].ToString();
               ANNEX_SEA_CON_DOC_TYPE = Container_data.Rows[i][7].ToString();
               ANNEX_SEA_CON_DOC_NUMBER = Container_data.Rows[i][8].ToString();


               int cont_id = Convert.ToInt32(ANNEX_SEA_CON_ID) + i;

               dt_cont.Rows.Add(cont_id, EXPORT_JOBNO, ANNEX_SEA_CON_CONTAINERNO, ANNEX_SEA_CON_SIZE, ANNEX_SEA_CON_TYPE, ANNEX_SEA_CON_EXCISE_SEALNO, ANNEX_SEA_CON_SEAL_DATE,
                            currentbranch, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate, ANNEX_SEA_CON_SEALTYPE_INDICATOR, ANNEX_SEA_CON_SEAL_DEVICEID, ANNEX_SEA_CON_DOC_TYPE, ANNEX_SEA_CON_DOC_NUMBER);
                * */
               int cont_id = Convert.ToInt32(ANNEX_SEA_CON_ID) + i;
               dt_cont.Rows.Add(cont_id, EXPORT_JOBNO, Container_data.Rows[i][0].ToString(),//ANNEX_SEA_CON_CONTAINERNO
                                                      Container_data.Rows[i][1].ToString(),//ANNEX_SEA_CON_TYPE
                                                      Container_data.Rows[i][2].ToString(),//ANNEX_SEA_CON_EXCISE_SEALNO
                                                      Container_data.Rows[i][3].ToString(),//ANNEX_SEA_CON_SEAL_DATE
                                                      Container_data.Rows[i][4].ToString() == string.Empty ? "01/01/1900" : Container_data.Rows[i][4].ToString(),//ANNEX_SEA_CON_CONTAINERNO
                                                      currentbranch, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate,
                                                      Container_data.Rows[i][5].ToString(),//ANNEX_SEA_CON_SEALTYPE_INDICATOR
                                                      Container_data.Rows[i][6].ToString(),//ANNEX_SEA_CON_SEAL_DEVICEID
                                                      Container_data.Rows[i][7].ToString(),//ANNEX_SEA_CON_DOC_TYPE
                                                      Container_data.Rows[i][8].ToString());//ANNEX_SEA_CON_DOC_NUMBER
           }
       }
        //ViewState["ds_CONTAINER"] = dt_cont;
        if (dt_cont.Rows.Count > 0)
        {
            admin.SqlBulk_Upload_Product("EXPORT_ANNEXURE_C_SEA_CONTAINER", dt_cont, comp_ConnectionStr);
        }
   }

   public void Bind_Invoice_Details(DataTable Inv_data)
   {
       #region dt_Inv
       dt_Inv.Columns.Add("INVOICE_ID");
       dt_Inv.Columns.Add("JOBNO");
       dt_Inv.Columns.Add("JOBDATE");
       dt_Inv.Columns.Add("INVOICE_SLNO");
       dt_Inv.Columns.Add("INVOICE_NO");
       dt_Inv.Columns.Add("INVOICE_DATE");
       dt_Inv.Columns.Add("PAYMENT_METHOD");
       dt_Inv.Columns.Add("PERIOD_PAYMENT");
       dt_Inv.Columns.Add("INVOICE_VALUE");
       dt_Inv.Columns.Add("INVOICE_CURRENCY");
       dt_Inv.Columns.Add("EXCHANGE_RATE");
       dt_Inv.Columns.Add("CONTRACT_NO");
       dt_Inv.Columns.Add("TERMS");
       dt_Inv.Columns.Add("BUYER");
       dt_Inv.Columns.Add("BUYER_NAME");
       dt_Inv.Columns.Add("BUYER_ADDRESS");
       dt_Inv.Columns.Add("BUYER_ADDRESS1");
       dt_Inv.Columns.Add("BUYER_ADDRESS2");
       dt_Inv.Columns.Add("BUYER_ADDRESS3");
       dt_Inv.Columns.Add("BUYER_ADDRESS4");
       dt_Inv.Columns.Add("COMMISSION_RATE");
       dt_Inv.Columns.Add("COMMISSION_CHARGES");
       dt_Inv.Columns.Add("COMMISSION_CURRENCY");
       dt_Inv.Columns.Add("FOB_RATE");
       dt_Inv.Columns.Add("FOB_CHARGES");
       dt_Inv.Columns.Add("FOB_CURRENCY");
       dt_Inv.Columns.Add("PACKMISC_RATE");
       dt_Inv.Columns.Add("PACKMISC_CHARGES");
       dt_Inv.Columns.Add("PACKMISC_CURRENCY");
       dt_Inv.Columns.Add("OTHER_DEDUCTION_RATE");
       dt_Inv.Columns.Add("OTHER_DEDUCTION_CHARGES");
       dt_Inv.Columns.Add("OTHER_DEDUCTION_CURRENCY");
       dt_Inv.Columns.Add("FREIGHT_RATE");
       dt_Inv.Columns.Add("FREIGHT_CHARGES");
       dt_Inv.Columns.Add("FREIGHT_CURRENCY");
       dt_Inv.Columns.Add("FREIGHT_EXRATE");
       dt_Inv.Columns.Add("INSURANCE_RATE");
       dt_Inv.Columns.Add("INSURANCE_CHARGES");
       dt_Inv.Columns.Add("INSURANCE_CURRENCY");
       dt_Inv.Columns.Add("INSURANCE_EXRATE");
       dt_Inv.Columns.Add("WHEATHER_UNIT_PRICE");
       dt_Inv.Columns.Add("USER_ID");
       dt_Inv.Columns.Add("DATE_TIME");
       dt_Inv.Columns.Add("STATUS");
       dt_Inv.Columns.Add("BRANCH_CODE");
       dt_Inv.Columns.Add("YEAR");
       dt_Inv.Columns.Add("WORKING_PERIOD");
       dt_Inv.Columns.Add("NON_STD_EFFECT_DT_EXP");
       dt_Inv.Columns.Add("NON_STD_BANKNAME");
       dt_Inv.Columns.Add("NON_STD_CERTIFICATE_NO");
       dt_Inv.Columns.Add("NON_STD_CERTIFICATE_DATE");
       dt_Inv.Columns.Add("MODIFIEDBY");
       dt_Inv.Columns.Add("MODIFIEDON");
       dt_Inv.Columns.Add("TERMS_PLACE");
       dt_Inv.Columns.Add("THIRDPARTY_NAME");
       dt_Inv.Columns.Add("THIRDPARTY_ADD1");
       dt_Inv.Columns.Add("THIRDPARTY_ADD2");
       dt_Inv.Columns.Add("THIRDPARTY_CITY");
       dt_Inv.Columns.Add("T_PARTY_COUNTRY_SUB_DIV");
       dt_Inv.Columns.Add("T_PARTY_COUNTRY_CODE");
       dt_Inv.Columns.Add("T_PARTY_PIN");
       dt_Inv.Columns.Add("AUTHORIZED_ECONOMIC_OPERATOR_CODE");
       dt_Inv.Columns.Add("A_E_O_COUNTRY");
       dt_Inv.Columns.Add("AUTHORIZED_ECONOMIC_OPERATOR");
       #endregion dt_Inv

       int zz;
       int j;

        INVOICE_ID = Convert.ToString(Get_general_MAXID("INVOICE_MAX_ID"));

        //******************** Remove Empty Rows from Datatable  ********************************

        Inv_data = Inv_data.Rows.Cast<DataRow>()
             .Where(row => !row.ItemArray.All(field => field is System.DBNull))
             .CopyToDataTable();

        //*********************************************************************************************************

        for (int i = 0; i <= Inv_data.Rows.Count - 1; i++)
        {
            INVOICE_SLNO = Inv_data.Rows[i][0].ToString();
            INVOICE_NO = Inv_data.Rows[i][1].ToString();
            INVOICE_DATE = Inv_data.Rows[i][2].ToString();
            INVOICE_VALUE = Inv_data.Rows[i][3].ToString();
            INVOICE_CURRENCY = Inv_data.Rows[i][4].ToString();
            EXCHANGE_RATE = Inv_data.Rows[i][5].ToString();
            
            if (Inv_data.Rows[i][6].ToString() == "")
            {
                PAYMENT_METHOD = "NA";
            }
            else
            {
                PAYMENT_METHOD = Inv_data.Rows[i][6].ToString();
            }

            TERMS = Inv_data.Rows[i][7].ToString();
            BUYER = Inv_data.Rows[i][8].ToString();

            if (BUYER == "Y" || BUYER == "")
            {
                BUYER_NAME = "SAME AS CONSIGNEE";
            }
            else
            {
                BUYER_NAME = Inv_data.Rows[i][9].ToString();
            }

            ds_IEC.Clear();
           zz= Check_Avail_IEC_Master(BUYER_NAME, "", "Check_Avail_BUYER_details");

           if (zz == 1)
           {
               if (BUYER_NAME != "")
               {
                   if (ds_IEC.Tables[0].Rows.Count > 0)
                   {
                       BUYER_NAME = ds_IEC.Tables[0].Rows[0]["BUYER_NAME"].ToString();
                       BUYER_ADDRESS = ds_IEC.Tables[0].Rows[0]["BUYER_ADD1"].ToString();
                       BUYER_ADDRESS1 = ds_IEC.Tables[0].Rows[0]["BUYER_ADD2"].ToString();
                       BUYER_ADDRESS2 = ds_IEC.Tables[0].Rows[0]["BUYER_ADD3"].ToString();
                       BUYER_ADDRESS3 = ds_IEC.Tables[0].Rows[0]["BUYER_COUNTRY_NAME"].ToString();
                       BUYER_ADDRESS4 = ds_IEC.Tables[0].Rows[0]["BUYER_PIN_CODE"].ToString();
                   }
                   else
                   {
                       BUYER_ADDRESS = Inv_data.Rows[i][10].ToString();
                       BUYER_ADDRESS1 = Inv_data.Rows[i][11].ToString();
                       BUYER_ADDRESS2 = Inv_data.Rows[i][12].ToString();
                       BUYER_ADDRESS3 = Inv_data.Rows[i][13].ToString();
                       BUYER_ADDRESS4 = Inv_data.Rows[i][14].ToString();
                   }
               }
               else
               {
                   BUYER = "N";
                   BUYER_NAME = "SAME AS CONSIGNEE";
               }
           }
           else
           {
               if (BUYER_NAME != "")
               {
                   erm.BUYER_ID = "";
                   erm.BUYER_NAME = Inv_data.Rows[i][9].ToString();
                   erm.BUYER_ADD1 = Inv_data.Rows[i][10].ToString();
                   erm.BUYER_ADD2 = Inv_data.Rows[i][11].ToString();
                   erm.BUYER_ADD3 = Inv_data.Rows[i][12].ToString();

                   erm.BUYER_COUNTRY_CODE = "";
                   erm.BUYER_COUNTRY_NAME = Inv_data.Rows[i][13].ToString();
                   erm.BUYER_PIN_CODE = Inv_data.Rows[i][14].ToString();
                   erm.BUYER_REMARKS = "";

                   erm.USER_ID = currentuser;
                   erm.BRANCH_CODE = currentbranch;
                   erm.flag = "S";
                   erm.YEAR = "";
                   erm.EWorking_Period = Working_Period;

                   j = erm.Buyer_Master_Insert_update();
               }
           }
           
            PERIOD_PAYMENT = Inv_data.Rows[i][15].ToString();
            CONTRACT_NO = Inv_data.Rows[i][16].ToString();
       
            FREIGHT_CHARGES = Inv_data.Rows[i][17].ToString();
            FREIGHT_CURRENCY = Inv_data.Rows[i][18].ToString();
            INSURANCE_CHARGES = Inv_data.Rows[i][19].ToString();
            INSURANCE_CURRENCY = Inv_data.Rows[i][20].ToString();
            WHEATHER_UNIT_PRICE = Inv_data.Rows[i][21].ToString();
            COMMISSION_CHARGES = Inv_data.Rows[i][22].ToString();
            COMMISSION_CURRENCY = Inv_data.Rows[i][23].ToString();
            FOB_CHARGES = Inv_data.Rows[i][24].ToString();
            FOB_CURRENCY = Inv_data.Rows[i][25].ToString();
            PACKMISC_CHARGES = Inv_data.Rows[i][26].ToString();
            PACKMISC_CURRENCY = Inv_data.Rows[i][27].ToString();
            OTHER_DEDUCTION_CHARGES = Inv_data.Rows[i][28].ToString();
            OTHER_DEDUCTION_CURRENCY = Inv_data.Rows[i][29].ToString();

            if (TERMS == "FOB")
            {
                FREIGHT_CURRENCY = "";
                INSURANCE_CURRENCY = "";           
            }
            else if (TERMS == "CIF")
            {
                if (FREIGHT_CURRENCY == "")
                {
                    FREIGHT_CURRENCY = INVOICE_CURRENCY;
                }
                if (INSURANCE_CURRENCY == "")
                {
                    INSURANCE_CURRENCY = INVOICE_CURRENCY;
                }
            }
            else if (TERMS == "CI")
            {
                FREIGHT_CURRENCY = "";
                if (INSURANCE_CURRENCY == "")
                {
                    INSURANCE_CURRENCY = INVOICE_CURRENCY;
                }
            }
            else if (TERMS == "CF")
            {
                INSURANCE_CURRENCY = "";
                if (FREIGHT_CURRENCY == "")
                {
                    FREIGHT_CURRENCY = INVOICE_CURRENCY;
                }
            }

            if (COMMISSION_CURRENCY == "")
            {
                COMMISSION_CURRENCY = INVOICE_CURRENCY;
            }
            if (FOB_CURRENCY == "")
            {
                FOB_CURRENCY = INVOICE_CURRENCY;
            }
            if (PACKMISC_CURRENCY == "")
            {
                PACKMISC_CURRENCY = INVOICE_CURRENCY;
            }
            if (OTHER_DEDUCTION_CURRENCY == "")
            {
                OTHER_DEDUCTION_CURRENCY = INVOICE_CURRENCY;
            }

            //FREIGHT_RATE=Inv_data.Rows[i][0].ToString();
            INSURANCE_RATE = Inv_data.Rows[i][30].ToString();
            COMMISSION_RATE = Inv_data.Rows[i][31].ToString();
            FOB_RATE = Inv_data.Rows[i][32].ToString();
            PACKMISC_RATE = Inv_data.Rows[i][33].ToString();
            OTHER_DEDUCTION_RATE = Inv_data.Rows[i][34].ToString();

            FREIGHT_EXRATE = Inv_data.Rows[i][5].ToString();
            INSURANCE_EXRATE = Inv_data.Rows[i][5].ToString();

            NON_STD_EFFECT_DT_EXP = "01/01/1900";
            //NON_STD_BANKNAME=Inv_data.Rows[i][0].ToString();
            //NON_STD_CERTIFICATE_NO=Inv_data.Rows[i][0].ToString();
            NON_STD_CERTIFICATE_DATE = "01/01/1900";
            //MODIFIEDBY=Inv_data.Rows[i][0].ToString();
            //MODIFIEDON = Inv_data.Rows[i][0].ToString();

            TERMS_PLACE = Inv_data.Rows[i][35].ToString();
            THIRDPARTY_NAME = Inv_data.Rows[i][36].ToString();
            THIRDPARTY_ADD1 = Inv_data.Rows[i][37].ToString();
            THIRDPARTY_ADD2 = Inv_data.Rows[i][38].ToString();
            THIRDPARTY_CITY = Inv_data.Rows[i][39].ToString();
            T_PARTY_COUNTRY_SUB_DIV = Inv_data.Rows[i][40].ToString();
            T_PARTY_COUNTRY_CODE = Inv_data.Rows[i][41].ToString();
            T_PARTY_PIN = Inv_data.Rows[i][42].ToString();
            AUTHORIZED_ECONOMIC_OPERATOR_CODE = Inv_data.Rows[i][43].ToString();
            A_E_O_COUNTRY = Inv_data.Rows[i][44].ToString();
            AUTHORIZED_ECONOMIC_OPERATOR = Inv_data.Rows[i][45].ToString();
           

            dt_Inv.Rows.Add(Convert.ToInt32(INVOICE_ID)+i, EXPORT_JOBNO, JOBDATE, INVOICE_SLNO, INVOICE_NO, INVOICE_DATE, PAYMENT_METHOD, PERIOD_PAYMENT, INVOICE_VALUE, INVOICE_CURRENCY, EXCHANGE_RATE, CONTRACT_NO,
                            TERMS, BUYER, BUYER_NAME, BUYER_ADDRESS, BUYER_ADDRESS1, BUYER_ADDRESS2, BUYER_ADDRESS3, BUYER_ADDRESS4, COMMISSION_RATE, COMMISSION_CHARGES, COMMISSION_CURRENCY,
                            FOB_RATE, FOB_CHARGES, FOB_CURRENCY, PACKMISC_RATE, PACKMISC_CHARGES, PACKMISC_CURRENCY, OTHER_DEDUCTION_RATE, OTHER_DEDUCTION_CHARGES, OTHER_DEDUCTION_CURRENCY,
                            FREIGHT_RATE, FREIGHT_CHARGES, FREIGHT_CURRENCY, FREIGHT_EXRATE, INSURANCE_RATE, INSURANCE_CHARGES, INSURANCE_CURRENCY, INSURANCE_EXRATE, WHEATHER_UNIT_PRICE,
                            currentuser, LoginDate, "N", currentbranch, "", Working_Period, NON_STD_EFFECT_DT_EXP, NON_STD_BANKNAME, NON_STD_CERTIFICATE_NO, NON_STD_CERTIFICATE_DATE, currentuser, LoginDate,
                            TERMS_PLACE, THIRDPARTY_NAME, THIRDPARTY_ADD1, THIRDPARTY_ADD2, THIRDPARTY_CITY, T_PARTY_COUNTRY_SUB_DIV, T_PARTY_COUNTRY_CODE, T_PARTY_PIN,
                            AUTHORIZED_ECONOMIC_OPERATOR_CODE, A_E_O_COUNTRY, AUTHORIZED_ECONOMIC_OPERATOR);

        }

        //ViewState["ds_INVOICE"] = dt_Inv;
        if (dt_Inv.Rows.Count > 0)
        {
            admin.SqlBulk_Upload_Product("EXPORT_INVOICE_DETAILS", dt_Inv, comp_ConnectionStr);
        }
   }

   public void Bind_Item_Details(DataTable Item_Data)
   {
       #region dt_Item
       dt_Item.Columns.Add("ITEM_ID");
       dt_Item.Columns.Add("JOBNO");
       dt_Item.Columns.Add("INVOICE_SLNO");
       dt_Item.Columns.Add("INVOICE_NO");
       dt_Item.Columns.Add("ITEM_SLNO");
       dt_Item.Columns.Add("ITEM_DESCRIPTION");
       dt_Item.Columns.Add("RITCNO");
       dt_Item.Columns.Add("ITEM_QTY");
       dt_Item.Columns.Add("ITEM_QTY_CODE");
       dt_Item.Columns.Add("ITEM_UNIT_PRICE");
       dt_Item.Columns.Add("ITEM_PER");
       dt_Item.Columns.Add("ITEM_AMOUNT");
       dt_Item.Columns.Add("ITEM_PMVVALUE");
       dt_Item.Columns.Add("ITEM_SCHEME_CODE");
       dt_Item.Columns.Add("ITEM_ACCESSORIES_DESC");
       dt_Item.Columns.Add("ITEM_AR4_NO");
       dt_Item.Columns.Add("ITEM_AR4_DATE");
       dt_Item.Columns.Add("ITEM_COMMISSION_RATE");
       dt_Item.Columns.Add("ITEM_DIVISION");
       dt_Item.Columns.Add("ITEM_RANGE");
       dt_Item.Columns.Add("ITEM_REMARKS");
       dt_Item.Columns.Add("ITEM_IECCODE");
       dt_Item.Columns.Add("ITEM_EXPORTER_NAME");
       dt_Item.Columns.Add("BR_SLNO");
       dt_Item.Columns.Add("ADDRESS1");
       dt_Item.Columns.Add("ADDRESS2");
       dt_Item.Columns.Add("ADDRESS3");
       dt_Item.Columns.Add("ADDRESS4");
       dt_Item.Columns.Add("ADDRESS5");
       dt_Item.Columns.Add("ITEM_STR_CODE");
       dt_Item.Columns.Add("REWARD_POINTS");
       dt_Item.Columns.Add("USER_ID");
       dt_Item.Columns.Add("DATE_TIME");
       dt_Item.Columns.Add("STATUS");
       dt_Item.Columns.Add("BRANCH_CODE");
       dt_Item.Columns.Add("YEAR");
       dt_Item.Columns.Add("WORKING_PERIOD");
       dt_Item.Columns.Add("PMV_VALUE");
       dt_Item.Columns.Add("FOB_VALUE");
       dt_Item.Columns.Add("DRAWBACK_VALUE");
       dt_Item.Columns.Add("CESS_YN");
       dt_Item.Columns.Add("MODIFIEDBY");
       dt_Item.Columns.Add("MODIFIEDON");
       dt_Item.Columns.Add("STR_RATE");
       dt_Item.Columns.Add("STR_AMOUNT");
       dt_Item.Columns.Add("MANUFACTURER_PRODUCER");
       dt_Item.Columns.Add("M_P_GROWER_CODE");
       dt_Item.Columns.Add("M_P_GROWER_ADD1");
       dt_Item.Columns.Add("M_P_GROWER_ADD2");
       dt_Item.Columns.Add("M_P_GROWER_CITY");
       dt_Item.Columns.Add("M_P_GROWER_COUNTRY_SUBDIV");
       dt_Item.Columns.Add("M_P_GROWER_PIN");
       dt_Item.Columns.Add("M_P_GROWER_COUNTRY");
       dt_Item.Columns.Add("SOURCE_STATE");
       dt_Item.Columns.Add("TRANSIT_COUNTRY");
       dt_Item.Columns.Add("ACCESSORY_STATUS");
       dt_Item.Columns.Add("HAWB_NO");
       dt_Item.Columns.Add("TOTAL_PKGS");
       dt_Item.Columns.Add("ENDUSE_ITEM");
       dt_Item.Columns.Add("IGST_PAYMENT");
       dt_Item.Columns.Add("TAXABLE_VALUE");
       dt_Item.Columns.Add("IGST_AMT");
       dt_Item.Columns.Add("GSTN_TYPE");
       dt_Item.Columns.Add("GSTN_ID");

       #endregion dt_Item

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

       #region dt_Dbk
       dt_Dbk.Columns.Add("DRAWBACK_ID");
       dt_Dbk.Columns.Add("JOBNO");
       dt_Dbk.Columns.Add("INVOICE_SLNO");
       dt_Dbk.Columns.Add("ITEM_SLNO");
       dt_Dbk.Columns.Add("SCHEME_CODE");
       dt_Dbk.Columns.Add("DRAWBACK_SLNO");
       dt_Dbk.Columns.Add("DRAWBACK_QTY");
       dt_Dbk.Columns.Add("DRAWBACK_UNIT");
       dt_Dbk.Columns.Add("DRAWBACK_NOOFUNITS");
       dt_Dbk.Columns.Add("DRAWBACK_RATE");
       dt_Dbk.Columns.Add("DRAWBACK_CAPS");
       dt_Dbk.Columns.Add("DRAWBACK_DESC");
       dt_Dbk.Columns.Add("USER_ID");
       dt_Dbk.Columns.Add("DATE_TIME");
       dt_Dbk.Columns.Add("STATUS");
       dt_Dbk.Columns.Add("BRANCH_CODE");
       dt_Dbk.Columns.Add("YEAR");
       dt_Dbk.Columns.Add("WORKING_PERIOD");
       dt_Dbk.Columns.Add("MODIFIEDBY");
       dt_Dbk.Columns.Add("MODIFIEDON");
       dt_Dbk.Columns.Add("STATE_LEVEL_ADV_RATE");
       dt_Dbk.Columns.Add("STATE_LEVEL_ADV_AMT");
       #endregion dt_Dbk

       #region dt_Lic
       /*
      
       dt_Lic.Columns.Add("LICENSE_ID", typeof(int));
       dt_Lic.Columns.Add("JOB_NO");
       dt_Lic.Columns.Add("INV_SL_NO");
       dt_Lic.Columns.Add("ITEM_SL_NO");
       dt_Lic.Columns.Add("SCHEME_CODE");
       dt_Lic.Columns.Add("SCHEME");
       dt_Lic.Columns.Add("LICENSE_R_SL_NO");
       dt_Lic.Columns.Add("LICENSE_NO");
       dt_Lic.Columns.Add("LICENSE_DATE");
       dt_Lic.Columns.Add("USER_ID");
       dt_Lic.Columns.Add("DATE_TIME");
       dt_Lic.Columns.Add("STATUS");
       dt_Lic.Columns.Add("BRANCH_CODE");
       dt_Lic.Columns.Add("YEAR");
       dt_Lic.Columns.Add("WORKING_PERIOD");
       dt_Lic.Columns.Add("MODIFIEDBY");
       dt_Lic.Columns.Add("MODIFIEDON");
       #endregion dt_Lic

       #region dt_Imp_Exp_lic
       dt_Imp_Exp_lic.Columns.Add("LICENSE_IMP_EXP_ID", typeof(int));
       dt_Imp_Exp_lic.Columns.Add("LICENSE_ID", typeof(int));
       dt_Imp_Exp_lic.Columns.Add("JOB_NO");
       dt_Imp_Exp_lic.Columns.Add("LICENSE_REG_SLNO");
       dt_Imp_Exp_lic.Columns.Add("LICENSE_NO");
       dt_Imp_Exp_lic.Columns.Add("LICENSE_E_SL_NO");
       dt_Imp_Exp_lic.Columns.Add("LICENSE_EXP_QTY");
       dt_Imp_Exp_lic.Columns.Add("LICENSE_EXP_UNIT");
       dt_Imp_Exp_lic.Columns.Add("LICENSE_IMP_ITEM_SL_NO");
       dt_Imp_Exp_lic.Columns.Add("LICENSE_IMP_DESC");
       dt_Imp_Exp_lic.Columns.Add("LICENSE_IMP_QTY");
       dt_Imp_Exp_lic.Columns.Add("LICENSE_IMP_UNIT");
       dt_Imp_Exp_lic.Columns.Add("LICENSE_IMP_TYPE");
       dt_Imp_Exp_lic.Columns.Add("USER_ID");
       dt_Imp_Exp_lic.Columns.Add("DATE_TIME");
       dt_Imp_Exp_lic.Columns.Add("STATUS");
       dt_Imp_Exp_lic.Columns.Add("BRANCH_CODE");
       dt_Imp_Exp_lic.Columns.Add("YEAR");
       dt_Imp_Exp_lic.Columns.Add("WORKING_PERIOD");
       dt_Imp_Exp_lic.Columns.Add("INV_SL_NO");
       dt_Imp_Exp_lic.Columns.Add("ITEM_SL_NO");
       dt_Imp_Exp_lic.Columns.Add("SCHEME");
       dt_Imp_Exp_lic.Columns.Add("MODIFIEDBY");
       dt_Imp_Exp_lic.Columns.Add("MODIFIEDON");
       
        * 
        */
       #endregion dt_Imp_Exp_lic

       ITEM_ID = Convert.ToString(Get_general_MAXID("INVOICE_MAX_ID"));

        //******************** Remove Empty Rows from Datatable  ********************************
        Item_Data = Item_Data.Rows.Cast<DataRow>()
             .Where(row => !row.ItemArray.All(field => field is System.DBNull))
             .CopyToDataTable();
        //*****************************************************************************************
      
        //while (ds.Tables[0].Rows[b][0] != System.DBNull.Value)
            //{
        for (int b = 0; b <= Item_Data.Rows.Count - 1; b++)
        {
            DataTable dt_Inv = (DataTable)ViewState["dt_gen"];

            var query =
                         from r in dt_Inv.AsEnumerable()
                         where r.Field<string>("INVOICE_SLNO").Equals(Item_Data.Rows[b][0].ToString())
                         select r.Field<string>("INVOICE_NO");
            var name1 = query.FirstOrDefault();

            INVOICE_SLNO = Item_Data.Rows[b][0].ToString();
            INVOICE_NO = name1;
            ITEM_SLNO = Item_Data.Rows[b][1].ToString();
            ITEM_DESCRIPTION = Item_Data.Rows[b][2].ToString();
            RITCNO = Item_Data.Rows[b][3].ToString();
            ITEM_QTY = Item_Data.Rows[b][4].ToString();
            ITEM_QTY_CODE = Item_Data.Rows[b][5].ToString();
            ITEM_UNIT_PRICE = Item_Data.Rows[b][6].ToString();
            ITEM_PER = "1";

            if (Item_Data.Rows[b][4] != System.DBNull.Value && Item_Data.Rows[b][6] != System.DBNull.Value)
            {
                item_amt = Convert.ToDecimal(Item_Data.Rows[b][4]) * Convert.ToDecimal(Item_Data.Rows[b][6]);
            }
            else
            {
                item_amt = 0;
            }

            //ITEM_AMOUNT = item_amt;
            ITEM_AMOUNT = Convert.ToString(item_amt);
            ITEM_PMVVALUE = "0.00";

            var q1 =
                       from r in dt_Inv.AsEnumerable()
                       where r.Field<string>("INVOICE_SLNO").Equals(Item_Data.Rows[b][0].ToString())
                       select r.Field<string>("EXCHANGE_RATE");
            var exrate = q1.FirstOrDefault();

            if (exrate != "")
            {
                //double pmv = (((Convert.ToDouble(lblInvoiceValue) * 110) / 100) * (Convert.ToDouble(hdn_Invoice_Exrate))) / Convert.ToDouble(txtItemQty);
                decimal pmv = ((((Convert.ToDecimal(ITEM_QTY) * Convert.ToDecimal(ITEM_UNIT_PRICE) * Convert.ToDecimal(exrate)) * 110) / 100));

                ITEM_PMVVALUE = Convert.ToString(Math.Round(pmv, 2));
            }

            scheme = Item_Data.Rows[b][7].ToString();

            if (scheme.Contains('-'))
            {
                string[] sp = scheme.Split('-');
                scheme = sp[0];
            }

            Open_Schemecode();

            ITEM_SCHEME_CODE = scheme;

            ITEM_STR_CODE = Item_Data.Rows[b][8].ToString();
            REWARD_POINTS = (Item_Data.Rows[b][9].ToString()).Trim() == "" ? "N" : "Y";

            ENDUSE_ITEM = Item_Data.Rows[b][10].ToString();
            IGST_PAYMENT = Item_Data.Rows[b][11].ToString();
            TAXABLE_VALUE = Item_Data.Rows[b][12].ToString();
            IGST_AMT = Item_Data.Rows[b][13].ToString();

            CESS_YN = Item_Data.Rows[b][14].ToString();
            /**************************************************** */
            string CESS_SRNO = Item_Data.Rows[b][15].ToString();

            ITEM_AR4_NO = "";
            ITEM_AR4_DATE = "01/01/1900";
            ITEM_COMMISSION_RATE = "";
            ITEM_DIVISION = "";
            ITEM_RANGE = "";
            ITEM_REMARKS = "";

         

            if (Item_Data.Rows[b][25].ToString() != "" && Item_Data.Rows[b][26].ToString() != "")
            {
                ds_IEC = Get_Importer_HSS_Details(Item_Data.Rows[b][25].ToString(), Item_Data.Rows[b][26].ToString());

                if (ds_IEC.Tables[0].Rows.Count > 0)
                {
                    ITEM_IECCODE = Item_Data.Rows[b][25].ToString();
                    BR_SLNO = Item_Data.Rows[b][26].ToString();
                    ITEM_EXPORTER_NAME = ds_IEC.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                    ADDRESS1 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                    ADDRESS2 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                    ADDRESS3 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                    ADDRESS4 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                    ADDRESS5 = ds_IEC.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                }
                else
                {
                    ITEM_IECCODE = Item_Data.Rows[b][25].ToString();
                    BR_SLNO = Item_Data.Rows[b][26].ToString();
                    ITEM_EXPORTER_NAME = Item_Data.Rows[b][27].ToString();
                    ADDRESS1 = Item_Data.Rows[b][28].ToString();
                    ADDRESS2 = Item_Data.Rows[b][29].ToString();
                    ADDRESS3 = Item_Data.Rows[b][30].ToString();
                    ADDRESS4 = Item_Data.Rows[b][31].ToString();
                    ADDRESS5 = Item_Data.Rows[b][32].ToString();
                    if (Item_Data.Rows[b][33].ToString().Contains('-'))
                    {
                        GSTN_TYPE = Item_Data.Rows[b][33].ToString().Substring(0, 3);
                    }
                    GSTN_ID = Item_Data.Rows[b][34].ToString();

                }
            }
            else
            {
                ITEM_IECCODE = "";
                BR_SLNO = "";
                ITEM_EXPORTER_NAME = "";
                ADDRESS1 = "";
                ADDRESS2 = "";
                ADDRESS3 = "";
                ADDRESS4 = "";
                ADDRESS5 = "";
            }


            MANUFACTURER_PRODUCER = Item_Data.Rows[b][35].ToString();
            M_P_GROWER_CODE = Item_Data.Rows[b][36].ToString();
            M_P_GROWER_ADD1 = Item_Data.Rows[b][37].ToString();
            M_P_GROWER_ADD2 = Item_Data.Rows[b][38].ToString();
            M_P_GROWER_CITY = Item_Data.Rows[b][39].ToString();
            M_P_GROWER_COUNTRY_SUBDIV = Item_Data.Rows[b][40].ToString();
            M_P_GROWER_PIN = Item_Data.Rows[b][41].ToString();
            M_P_GROWER_COUNTRY = Item_Data.Rows[b][42].ToString();
            if (Item_Data.Rows[b][43].ToString().Contains('-'))
            {
                SOURCE_STATE = Item_Data.Rows[b][43].ToString().Substring(0,2);
            }
            TRANSIT_COUNTRY = Item_Data.Rows[b][44].ToString();
            ACCESSORY_STATUS = Item_Data.Rows[b][45].ToString();

            HAWB_NO = Item_Data.Rows[b][46].ToString();
            TOTAL_PKGS = Item_Data.Rows[b][47].ToString();

            dt_Item.Rows.Add(ITEM_ID+b, EXPORT_JOBNO, INVOICE_SLNO, INVOICE_NO, ITEM_SLNO, ITEM_DESCRIPTION, RITCNO, ITEM_QTY, ITEM_QTY_CODE, ITEM_UNIT_PRICE, ITEM_PER, ITEM_AMOUNT,
                            ITEM_PMVVALUE, ITEM_SCHEME_CODE, ITEM_ACCESSORIES_DESC, ITEM_AR4_NO, ITEM_AR4_DATE, ITEM_COMMISSION_RATE, ITEM_DIVISION, ITEM_RANGE, ITEM_REMARKS,
                            ITEM_IECCODE, ITEM_EXPORTER_NAME, BR_SLNO, ADDRESS1, ADDRESS2, ADDRESS3, ADDRESS4, ADDRESS5, ITEM_STR_CODE, REWARD_POINTS, currentuser, LoginDate, "N",
                            currentbranch, "", Working_Period, PMV_VALUE, FOB_VALUE, DRAWBACK_VALUE, CESS_YN, currentuser, LoginDate, STR_RATE, STR_AMOUNT,MANUFACTURER_PRODUCER,
                            M_P_GROWER_CODE,M_P_GROWER_ADD1,M_P_GROWER_ADD2,M_P_GROWER_CITY,M_P_GROWER_COUNTRY_SUBDIV,M_P_GROWER_PIN,M_P_GROWER_COUNTRY,SOURCE_STATE,TRANSIT_COUNTRY,
                            ACCESSORY_STATUS, HAWB_NO, TOTAL_PKGS, ENDUSE_ITEM, IGST_PAYMENT, TAXABLE_VALUE, IGST_AMT, GSTN_TYPE, GSTN_ID);

            //if (dt_Item.Rows.Count > 0)
            //{
            //    admin.SqlBulk_Upload_Product("EXPORT_ITEM_DETAILS", dt_Item, comp_ConnectionStr);
            //}

            //--------------------AR4 Details--------------------------//
            #region EXPORT_AR4_TBL
            AR4_NO = Item_Data.Rows[b][16].ToString();
            if (AR4_NO != "")
            {
                    AR4_ID = Get_general_MAXID("AR4_MAX_ID");
                /*
                    AR4_DATE = Item_Data.Rows[b][17].ToString();
                    AR4_COMMISSION_RATE = Item_Data.Rows[b][18].ToString();
                    AR4_DIVISION = Item_Data.Rows[b][19].ToString();
                    AR4_RANGE = Item_Data.Rows[b][20].ToString();
                    AR4_REMARKS = Item_Data.Rows[b][21].ToString();

                    dt_AR4.Rows.Add(AR4_ID+b, EXPORT_JOBNO, AR4_NO, AR4_DATE, AR4_COMMISSION_RATE, AR4_DIVISION, AR4_RANGE, AR4_REMARKS, currentuser, LoginDate, "N", currentbranch, "", Working_Period, INVOICE_NO, INVOICE_SLNO, b+1, ITEM_SLNO, currentuser, LoginDate);
                    if (dt_AR4.Rows.Count > 0)
                    {
                        admin.SqlBulk_Upload_Product("EXPORT_AR4_TBL", dt_AR4, comp_ConnectionStr);
                    }
                 * */

                    dt_AR4.Rows.Add(AR4_ID + b, EXPORT_JOBNO, AR4_NO,
                                                    Item_Data.Rows[b][17].ToString(),//AR4_DATE
                                                    Item_Data.Rows[b][18].ToString(),//AR4_COMMISSION_RATE
                                                    Item_Data.Rows[b][19].ToString(),//AR4_DIVISION
                                                    Item_Data.Rows[b][20].ToString(),//AR4_RANGE
                                                    Item_Data.Rows[b][21].ToString(),//AR4_REMARKS
                                                    currentuser, LoginDate, "N", currentbranch, "", Working_Period, 
                                                    INVOICE_NO, INVOICE_SLNO, b + 1, ITEM_SLNO, currentuser, LoginDate);
                   
                if (dt_AR4.Rows.Count > 0)
                    {
                        admin.SqlBulk_Upload_Product("EXPORT_AR4_TBL", dt_AR4, comp_ConnectionStr);
                    }

            }
            #endregion EXPORT_AR4_TBL

            //--------------------Drawback Details--------------------------//
            #region EXPORT_DRAWBACK_DETAILS
            string[] arr = { "19", "41", "43", "44", "47", "48", "49", "71", "73", "74", "79", "60", "61", "62", "63", "64", "65" };
            string scheme_draw = Item_Data.Rows[b][7].ToString().Trim();
            if (scheme_draw.Contains('-'))
            {
                string[] sp = scheme_draw.Split('-');
                scheme_draw = sp[0];
            }

            string Draw_value = Array.Find(arr, element => element.StartsWith(scheme_draw, StringComparison.Ordinal));

            DRAWBACK_SLNO = Item_Data.Rows[b][22].ToString().Trim();
            if (DRAWBACK_SLNO != "")
            {
                 if (scheme != "")
                {
                    if (scheme_draw == Draw_value)
                    {
                        
                        if (Item_Data.Rows[b][23].ToString() != "")
                        {
                            DRAWBACK_QTY = Item_Data.Rows[b][23].ToString();
                        }
                        else
                        {
                            DRAWBACK_QTY = Item_Data.Rows[b][4].ToString();
                        }

                        if (Item_Data.Rows[b][24].ToString() != "")
                        {
                            DRAWBACK_UNIT = Item_Data.Rows[b][24].ToString();
                        }
                        else
                        {
                            DRAWBACK_UNIT = Item_Data.Rows[b][5].ToString();
                        }
                        SCHEME_CODE = scheme;

                        if (DRAWBACK_SLNO != "")
                        {
                            Auto.Ename = "DRAWBACK_MASTER_ALL";
                            Auto.Enamesearch = DRAWBACK_SLNO;
                            Auto.Notn_No_Search = scheme_draw;
                            ds_draw = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                            if (ds_draw.Tables[0].Rows.Count > 0)
                            {
                                DRAWBACK_NOOFUNITS = ds_draw.Tables[0].Rows[0]["DRAWBACK_NOOFUNITS"].ToString();
                                DRAWBACK_RATE = ds_draw.Tables[0].Rows[0]["DRAWBACK_RATE"].ToString();
                                DRAWBACK_CAPS = ds_draw.Tables[0].Rows[0]["DRAWBACK_VALUE_CAP"].ToString();
                                DRAWBACK_DESC = ds_draw.Tables[0].Rows[0]["DRAWBACK_DESCRIPTION"].ToString();
                            }
                            if (scheme_draw == "60" || scheme_draw == "61" || scheme_draw == "62" || scheme_draw == "63" || scheme_draw == "64" || scheme_draw == "65")
                            {
                                if (ds_draw.Tables[1].Rows.Count > 0)
                                {
                                    STATE_LEVEL_ADV_RATE = ds_draw.Tables[1].Rows[0]["ROSL_RATE"].ToString();
                                    STATE_LEVEL_ADV_AMT = ds_draw.Tables[1].Rows[0]["ROSL_AMT"].ToString();
                                }
                            }
                        }
                        else
                        {
                            DRAWBACK_SLNO = Item_Data.Rows[b][18].ToString().Trim();
                            DRAWBACK_NOOFUNITS = "";

                            DRAWBACK_RATE = "";
                            DRAWBACK_CAPS = "";
                            DRAWBACK_DESC = "";
                            STATE_LEVEL_ADV_RATE = "";
                            STATE_LEVEL_ADV_AMT = "";
                        }
                    }
                     DRAWBACK_ID = Get_general_MAXID("DRAWBACK_MAX_ID");
                     dt_Dbk.Rows.Add(DRAWBACK_ID+b, EXPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, SCHEME_CODE, DRAWBACK_SLNO, DRAWBACK_QTY, DRAWBACK_UNIT, DRAWBACK_NOOFUNITS, DRAWBACK_RATE, DRAWBACK_CAPS, DRAWBACK_DESC,
                                     currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate, STATE_LEVEL_ADV_RATE, STATE_LEVEL_ADV_AMT);
                     if (dt_Dbk.Rows.Count > 0)
                     {
                         admin.SqlBulk_Upload_Product("EXPORT_DRAWBACK_DETAILS", dt_Dbk, comp_ConnectionStr);
                     }
                }
            }
            #endregion EXPORT_DRAWBACK_DETAILS

            //--------------------License Details--------------------------//
            #region LICENSE_DETAILS
            /* ---------- HIDDEN BY CHITHRA 09-09-2017 *****************

            
            if (scheme != "" || scheme != "00-FREE SHIPPING BILL")
            {
                string license_no = Item_Data.Rows[b][21].ToString();
                sl = 1;
                sl_E = 1;
                string License_date="";
                if (license_no != "")
                {                 
                    LICENSE_ID = Get_general_MAXID("LICENSE_MAX_ID");   
                    LICENSE_IMP_EXP_ID = Get_general_MAXID("LICENSE_IMP_EXP_MAX_ID");

                    License_id_Max = LICENSE_ID;
                    License_id_IMP_EXP_Max = LICENSE_IMP_EXP_ID;

                    if (license_no.Contains(','))
                    {
                        lic_no = license_no.Split(',');
                        licno_Count = lic_no.Count();
                    }
                    else
                    {
                        license_no = license_no + ',';
                        lic_no = license_no.Split(',');
                        licno_Count = 1;
                    }

                    for (int z = 0; z <= licno_Count - 1; z++)
                    {
                        license_no = lic_no[z].Trim();

                        D_E = 0;
                        ii = 0;

                        LICENSE_ID = License_id_Max;

                        SCHEME_CODE = scheme;
                        LICENSE_EXP_QTY = Item_Data.Rows[b][4].ToString();
                        LICENSE_EXP_UNIT = Item_Data.Rows[b][5].ToString();
                        LICENSE_NO = license_no;

                        License.Ename = "select_con";
                        License.LICENSE_NO = license_no;

                        ds_license = License.Export_License_Master_Select();
                        if (ds_license.Tables[0].Rows.Count > 0)
                        {
                            if (ds_license.Tables[0].Rows[0]["LICENSE_REG_TYPE"].ToString() == "DEEC")
                            {
                                LICENSE_R_SL_NO = sl;
                                sl = sl + 1;
                            }
                            else
                            {
                                LICENSE_R_SL_NO = sl_E;
                                sl_E = sl_E + 1;
                            }

                            for (int k = 0; k <= ds_license.Tables[0].Rows.Count; k++)
                            {

                                DataView view1 = ds_license.Tables[0].DefaultView;
                                view1.RowFilter = "LICENSE_REG_TYPE = '" + scheme_name[D_E] + "'";
                                DataSet dt_UserRights = new DataSet();
                                dt_UserRights.Tables.Add(view1.ToTable());

                                int x = dt_UserRights.Tables[0].Rows.Count;

                                if (x == 1)
                                {
                                    x = 0;
                                }
                                else
                                {
                                    x = dt_UserRights.Tables[0].Rows.Count - 1;
                                }
                                if (x >= ii)
                                {

                                    LICENSE_IMP_EXP_ID = License_id_IMP_EXP_Max;
                                    LICENSE_E_SL_NO = "1";
                                    LICENSE_ID = License_id_Max + 1;
                                    License_date = Convert.ToDateTime(dt_UserRights.Tables[0].Rows[ii]["LICENSE_DATE"].ToString()).ToShortDateString();
                                    string License_date1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(License_date));

                                    LICENSE_DATE = Convert.ToDateTime(License_date).ToString(@"MM/dd/yyyy");
                                    LICENSE_REG_DATE = dt_UserRights.Tables[0].Rows[ii]["LICENSE_REG_DATE"].ToString();
                                    LICENSE_REG_TYPE = dt_UserRights.Tables[0].Rows[ii]["LICENSE_REG_TYPE"].ToString();
                                    LICENSE_ITEM_SL_NO = dt_UserRights.Tables[0].Rows[ii]["LICENSE_ITEM_SL_NO"].ToString();
                                    LICENSE_ITEM_DESCRIPTION = dt_UserRights.Tables[0].Rows[ii]["LICENSE_ITEM_DESCRIPTION"].ToString();

                                    LICENSE_QTY = dt_UserRights.Tables[0].Rows[ii]["LICENSE_QTY"].ToString();
                                    LICENSE_UNIT = dt_UserRights.Tables[0].Rows[ii]["LICENSE_UNIT"].ToString();
                                    LICENSE_TYPE = dt_UserRights.Tables[0].Rows[ii]["LICENSE_TYPE"].ToString();

                                    SCHEME = scheme_name[D_E];
                                    License_id_IMP_EXP_Max = License_id_IMP_EXP_Max + 1;

                                    //dsXML.Tables[3].Rows.Add(dr3.ItemArray);

                                    dt_Imp_Exp_lic.Rows.Add(LICENSE_IMP_EXP_ID, LICENSE_ID, EXPORT_JOBNO, LICENSE_R_SL_NO, LICENSE_NO, LICENSE_E_SL_NO, LICENSE_EXP_QTY, LICENSE_EXP_UNIT, LICENSE_ITEM_SL_NO, LICENSE_ITEM_DESCRIPTION,
                                                            LICENSE_QTY, LICENSE_UNIT, LICENSE_TYPE, currentuser, LoginDate, "N", currentbranch, "", Working_Period, INVOICE_SLNO, ITEM_SLNO, SCHEME, currentuser, LoginDate);

                                    ii++;
                                }
                                else
                                {
                                    D_E = 1;
                                    ii = 0;
                                }
                            }
                            dt_Lic.Rows.Add(LICENSE_ID, EXPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, SCHEME_CODE, SCHEME, LICENSE_R_SL_NO, LICENSE_NO, License_date, currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate);
                        }
                        else
                        {

                        }
                        //if (dt_Lic.Rows.Count > 0)
                        //{
                        //    admin.SqlBulk_Upload_Product("EXPORT_LICENSE_DETAILS", dt_Lic, comp_ConnectionStr);
                        //}
                        //if (dt_Imp_Exp_lic.Rows.Count > 0)
                        //{
                        //    admin.SqlBulk_Upload_Product("EXPORT_LICENSE_IMP_EXP_DETAILS", dt_Imp_Exp_lic, comp_ConnectionStr);
                        //}
                        //dt_Lic.Clear();
                        //dt_Imp_Exp_lic.Clear();

                    }
                }
                //d++;
                License_id_Max = License_id_Max + 1;
            }
             */
#endregion LICENSE_DETAILS





            //string dd = dss1.Tables[0].Rows[a][1].ToString();
            //var Values = from row in dsXML.Tables["ItemDetails"].AsEnumerable()
            //             group row by new { id = row.Field<string>("INVOICE_NO") } into g
            //             select new
            //             {
            //                 name_1 = g.Key.id,
            //                 name_2 = g.Sum(r => r.Field<double>("ITEM_AMOUNT"))
            //             };


            //foreach (var drval in Values)
            //{
            //    if (drval.name_1 == dd)
            //        dr["INVOICE_VALUE"] = drval.name_2;
            //}

        }

        if (dt_Item.Rows.Count > 0)
        {
            admin.SqlBulk_Upload_Product("EXPORT_ITEM_DETAILS", dt_Item, comp_ConnectionStr);
        }

        //ViewState["ds_LICNESE"] = dt_Lic;
        //ViewState["ds_IMP_EXP_LICNESE"] = dt_Imp_Exp_lic;  
        //ViewState["ds_AR4"] = dt_AR4;  
        //ViewState["ds_ITEM"] = dt_Item;
        //ViewState["ds_DRAWBACK"] = dt_Dbk;

        //admin.SqlBulk_Upload_Product("EXPORT_ITEM_DETAILS", dt_Item, comp_ConnectionStr);
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
           LICENSE_ID = License_id_Max;
           JOBNO = EXPORT_JOBNO;
           INVOICE_SLNO = blk_lic_Data.Rows[a][0].ToString();
           ITEM_SLNO = blk_lic_Data.Rows[a][1].ToString().TrimEnd();
           SCHEME_CODE = blk_lic_Data.Rows[a][2].ToString();

           //SCHEME = blk_lic_Data.Rows[a][3].ToString();

           if (SCHEME_CODE.Contains('-'))
           {
               string[] sp = SCHEME_CODE.Split('-');
               scheme = sp[0];
           }

           Open_Schemecode();

           SCHEME = scheme_name[0];

           LICENSE_R_SL_NO = c;
           LICENSE_NO = blk_lic_Data.Rows[a][3].ToString();
           LICENSE_DATE = blk_lic_Data.Rows[a][4].ToString();
          
           dt_blk_Lic.Rows.Add(LICENSE_ID, EXPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, SCHEME_CODE, SCHEME, LICENSE_R_SL_NO, LICENSE_NO, LICENSE_DATE, currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate);

           while (blk_lic_Data.Rows[b][0] != System.DBNull.Value)
           {
          
               string LicenseNo, IMP_Exp_LicenseNo, InvslNo, Imp_exp_Invslno, ItemslNo, Imp_exp_Itemslno;
               LicenseNo = blk_lic_Data.Rows[a][3].ToString();
               IMP_Exp_LicenseNo = blk_lic_Data.Rows[b][3].ToString();

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
                   LICENSE_NO = blk_lic_Data.Rows[b][3].ToString();
                   LICENSE_E_SL_NO = blk_lic_Data.Rows[b][5].ToString();

                   LICENSE_EXP_QTY = blk_lic_Data.Rows[b][6].ToString();
                   LICENSE_EXP_UNIT = blk_lic_Data.Rows[b][7].ToString();
                   LICENSE_IMP_ITEM_SL_NO = blk_lic_Data.Rows[b][8].ToString();
                   LICENSE_IMP_DESC = blk_lic_Data.Rows[b][9].ToString();
                   LICENSE_IMP_QTY = blk_lic_Data.Rows[b][10].ToString();
                   LICENSE_IMP_UNIT = blk_lic_Data.Rows[b][11].ToString();
                   //dr1["LICENSE_IMP_TYPE"] = ds.Tables[0].Rows[b][13].ToString();
                   if (blk_lic_Data.Rows[b][12].ToString() == "Imported")
                   {
                       LICENSE_IMP_TYPE = "M";
                   }
                   else
                   {
                        LICENSE_IMP_TYPE = "N";
                   }

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

       //ViewState["ds_blk_LICNESE"] = dt_blk_Lic;
       //ViewState["ds_blk_IMP_EXP_LICNESE"] = dt_blk_Imp_Exp_lic;

   }

   public void Bind_ANNEXURE_C1_DETAILS(DataTable Annex_Data)
   {
       int xx;
       if (Annex_Data.Rows.Count > 0)
       {
           ANNEX.ANNEX_JOBNO = EXPORT_JOBNO;
           ANNEX.ANNEX_EXPORTERNAME = Annex_Data.Rows[0][0].ToString();
           ANNEX.ANNEX_IECCODE = Annex_Data.Rows[0][1].ToString();
           ANNEX.ANNEX_BR_SLNO = Annex_Data.Rows[0][2].ToString();

           xx = Check_Avail_IEC_Master(Annex_Data.Rows[0][1].ToString(), Annex_Data.Rows[0][2].ToString(), "Check_Avail_IEC_details");

           if (xx == 1)
           {
               ds_IEC = Get_Importer_HSS_Details(Annex_Data.Rows[0][1].ToString(), Annex_Data.Rows[0][2].ToString());

               ANNEX.ANNEX_ADDRESS1 = ds_IEC.Tables[0].Rows[0][5].ToString();
               ANNEX.ANNEX_ADDRESS2 = ds_IEC.Tables[0].Rows[0][6].ToString();
               ANNEX.ANNEX_ADDRESS3 = ds_IEC.Tables[0].Rows[0][7].ToString();
               ANNEX.ANNEX_ADDRESS4 = ds_IEC.Tables[0].Rows[0][8].ToString();
           }
           else
           {
               erm.IMP_EXP_ID = "";
               erm.IMP_EXP_NAME = Annex_Data.Rows[0][0].ToString();
               erm.IMP_EXP_IECNO = Annex_Data.Rows[0][1].ToString();
               erm.IMP_EXP_BRSLNO = Annex_Data.Rows[0][2].ToString();

               if (Annex_Data.Rows[0][12].ToString() == "GOVERNMENT")
               {
                   erm.IMP_EXP_TYPE = "G";
               }
               else
               {
                   erm.IMP_EXP_TYPE = "P";
               }
               erm.IMP_EXP_ADD1 ="";
               erm.IMP_EXP_ADD2 = "";
               erm.IMP_EXP_ADD3 = "";
               erm.IMP_EXP_ADD4 = "";
               erm.IMP_EXP_PIN_CODE = "";
               erm.IMP_EXP_CONTACT_PERSON = "";
               erm.IMP_EXP_PHONE = "";

               erm.IMP_EXP_FAX = "";
               erm.IMP_EXP_EMAIL = "";
               erm.IMP_EXP_BINNO = "";
               erm.IMP_EXP_REMARKS = "";
               erm.IMP_EXP_DRAWBACK_AC_NO = "";
               erm.IMP_EXP_PAN_NO = "";

               //STANDARD_TYPE = ViewState["STANDARD_TYPE"].ToString();

               //if (STANDARD_TYPE == "Non_STD")
               //{
               //    erm.STANDARD_TYPE = STANDARD_TYPE;
               //}
               //else
               //{
               erm.STANDARD_TYPE = null;
               //}

               erm.TIN_NO = "";
               erm.STATE_CODE = "";

               erm.USER_ID = currentuser;
               erm.BRANCH_CODE = currentbranch;
               erm.flag = "S";
               erm.YEAR = "";
               erm.EWorking_Period = Working_Period;
               erm.EXP_STR_YN = "";
               //string Type_Of_Exporter = "";

               //if (ddlType_Exp.SelectedItem.Text == "Manufacturer - ( F )")
               //{
               //Type_Of_Exporter = "F";
               //}
               //else
               //{
               //    Type_Of_Exporter = "R";
               //}
               erm.TYPE_OF_EXPORTER = "F";
               erm.MARKS_NO = "";

               erm.COMMERCIAL_DETAILS_STATUS = "N";
               erm.COMMERCIAL_TAX_STATENAME = "";
               erm.COMMERCIAL_TAX_STATECODE = "";
               erm.COMMERCIAL_TAX_TYPE = "";
               erm.COMMERCIAL_TAX_REGISTRATION_NO = "";

               i = erm.Imp_Exp_Master_Insert_update_STD();
           }


           // Export.TRANSPORT_MODE = ddlTransportMode.SelectedValue.ToString();
           //ANNEX.ANNEX_ADDRESS1 = Annex_Data.Rows[0][0].ToString();
           //ANNEX.ANNEX_ADDRESS2 = Annex_Data.Rows[0][0].ToString();
           //ANNEX.ANNEX_ADDRESS3 = Annex_Data.Rows[0][0].ToString();
           //ANNEX.ANNEX_ADDRESS4 = Annex_Data.Rows[0][0].ToString();
           ANNEX.ANNEX_EXAM_DATE = Annex_Data.Rows[0][3].ToString();
           ANNEX.ANNEX_EXAM_OFFICER = Annex_Data.Rows[0][4].ToString();
           ANNEX.ANNEX_EXAM_DESIGN = Annex_Data.Rows[0][5].ToString();
           ANNEX.ANNEX_SUPER_NAME = Annex_Data.Rows[0][6].ToString();
           ANNEX.ANNEX_SUPER_DESIGN = Annex_Data.Rows[0][7].ToString();
           ANNEX.ANNEX_COMMISSION_RATE = Annex_Data.Rows[0][8].ToString();
           ANNEX.ANNEX_DIVISION = Annex_Data.Rows[0][9].ToString();
           ANNEX.ANNEX_RANGE = Annex_Data.Rows[0][10].ToString();
           //string VERIFY_EXAM_OFF;

           //if (chkVerifiedOfficer.Checked == true)
           //{
           //    VERIFY_EXAM_OFF = "Y";
           //}
           //else
           //{
           //    VERIFY_EXAM_OFF = "N";
           //}

           if (Annex_Data.Rows[0][11].ToString() == "")
           {
               ANNEX.ANNEX_VERIFIED_EXAM_OFFICER = "N";
           }
           else
           {
               ANNEX.ANNEX_VERIFIED_EXAM_OFFICER = Annex_Data.Rows[0][11].ToString();
           }

           //string SAMPLE_DRAWN;

           //if (chkSampleDrawn.Checked == true)
           //{
           //    SAMPLE_DRAWN = "Y";
           //}
           //else
           //{
           //    SAMPLE_DRAWN = "N";
           //}

           ANNEX.ANNEX_SAMPLE_DRAWN = Annex_Data.Rows[0][12].ToString();
           if (Annex_Data.Rows[0][12].ToString() == "")
           {
               ANNEX.ANNEX_SEAL_NO = "N";
           }
           else
           {
               ANNEX.ANNEX_SEAL_NO = Annex_Data.Rows[0][13].ToString();
           }

           ANNEX.USER_ID = currentuser;

           ANNEX.flag = "S";
           ANNEX.BRANCH_CODE = currentbranch;
           ANNEX.WORKING_PERIOD = Working_Period;
           ANNEX.BRANCH_COMMON = SELECT_BRANCH;

           i = ANNEX.Annexure_details_insertupdate();
       }
   }

   public void Bind_SINGLE_WINDOW_Details(DataTable SW_Data)
   {
       #region dt_SW_INFO
       dt_SW_INFO.Columns.Add("SW_INFO_TYPE_ID");
       dt_SW_INFO.Columns.Add("JOBNO");
       dt_SW_INFO.Columns.Add("INVOICE_SLNO");
       dt_SW_INFO.Columns.Add("ITEM_SLNO");
       dt_SW_INFO.Columns.Add("SLNO");
       dt_SW_INFO.Columns.Add("INFO_TYPE");
       dt_SW_INFO.Columns.Add("INFO_QUALIFIER");
       dt_SW_INFO.Columns.Add("INFO_CODE");
       dt_SW_INFO.Columns.Add("INFO_TEXT");
       dt_SW_INFO.Columns.Add("INFO_MSR");
       dt_SW_INFO.Columns.Add("INFO_UQC");
       dt_SW_INFO.Columns.Add("USER_ID");
       dt_SW_INFO.Columns.Add("DATE_TIME");
       dt_SW_INFO.Columns.Add("STATUS");
       dt_SW_INFO.Columns.Add("BRANCH_CODE");
       dt_SW_INFO.Columns.Add("YEAR");
       dt_SW_INFO.Columns.Add("WORKING_PERIOD");
       dt_SW_INFO.Columns.Add("MODIFIEDBY");
       dt_SW_INFO.Columns.Add("MODIFIEDON");
       dt_SW_INFO.Columns.Add("DEPARTMENT");
       dt_SW_INFO.Columns.Add("I_U_TYPE");
       #endregion dt_SW_INFO

       #region dt_SW_CTRL
       dt_SW_CTRL.Columns.Add("SW_CONTROL_ID");
       dt_SW_CTRL.Columns.Add("JOBNO");
       dt_SW_CTRL.Columns.Add("INVOICE_SLNO");
       dt_SW_CTRL.Columns.Add("ITEM_SLNO");
       dt_SW_CTRL.Columns.Add("CONTROL_TYPE_CODE");
       dt_SW_CTRL.Columns.Add("CONTROL_LOCATION");
       dt_SW_CTRL.Columns.Add("CONTROL_START_DATE");
       dt_SW_CTRL.Columns.Add("CONTROL_END_DATE");
       dt_SW_CTRL.Columns.Add("CONTROL_RESULT_CODE");
       dt_SW_CTRL.Columns.Add("CONTROL_RESULT_TEXT");
       dt_SW_CTRL.Columns.Add("USER_ID");
       dt_SW_CTRL.Columns.Add("DATE_TIME");
       dt_SW_CTRL.Columns.Add("STATUS");
       dt_SW_CTRL.Columns.Add("BRANCH_CODE");
       dt_SW_CTRL.Columns.Add("YEAR");
       dt_SW_CTRL.Columns.Add("WORKING_PERIOD");
       dt_SW_CTRL.Columns.Add("MODIFIEDBY");
       dt_SW_CTRL.Columns.Add("MODIFIEDON");
       #endregion dt_SW_CTRL

       #region dt_SW_STMT
       dt_SW_STMT.Columns.Add("SW_ID");
       dt_SW_STMT.Columns.Add("JOBNO");
       dt_SW_STMT.Columns.Add("INVOICE_SLNO");
       dt_SW_STMT.Columns.Add("ITEM_SLNO");
       dt_SW_STMT.Columns.Add("SLNO");
       dt_SW_STMT.Columns.Add("STMT_TYPE");
       dt_SW_STMT.Columns.Add("STMT_CODE");
       dt_SW_STMT.Columns.Add("STMT_TEXT");
       dt_SW_STMT.Columns.Add("BRANCH_CODE");
       dt_SW_STMT.Columns.Add("WORKING_PERIOD");
       dt_SW_STMT.Columns.Add("CREATEDON");
       dt_SW_STMT.Columns.Add("CREATEDBY");
       dt_SW_STMT.Columns.Add("MODIFIEDBY");
       dt_SW_STMT.Columns.Add("MODIFIEDON");
       #endregion dt_SW_STMT

       //******************** Remove Empty Rows from Datatable  ********************************

       SW_Data = SW_Data.Rows.Cast<DataRow>()
            .Where(row => !row.ItemArray.All(field => field is System.DBNull))
            .CopyToDataTable();

       //****************************************************************************************

       for (int i = 0; i <= SW_Data.Rows.Count - 1; i++)
       {
           SW_INFO_TYPE_ID = Convert.ToString(i);

           INVOICE_SLNO = SW_Data.Rows[i][0].ToString();
           ITEM_SLNO = SW_Data.Rows[i][1].ToString();
           DEPARTMENT = SW_Data.Rows[i][3].ToString();
           if (SW_Data.Rows[i][4].ToString() != "")
           {
               INFO_TYPE = SW_Data.Rows[i][4].ToString().Substring(0, 3);
           }
           else
           {
               INFO_TYPE = "";
           }
           if (SW_Data.Rows[i][5].ToString() != "")
           {
               INFO_QUALIFIER = SW_Data.Rows[i][5].ToString().Substring(0, 3);
           }
           else
           {
               INFO_QUALIFIER = "";
           }

           if (SW_Data.Rows[i][6].ToString() != "")
           {
               INFO_CODE = SW_Data.Rows[i][6].ToString().Substring(0, 3);
           }
           else
           {
               INFO_CODE = "";
           }
           INFO_TEXT = SW_Data.Rows[i][7].ToString();
           INFO_MSR = SW_Data.Rows[i][8].ToString();
           INFO_UQC = SW_Data.Rows[i][9].ToString();

           I_U_TYPE = "N";

           if (INFO_TYPE != "")
           {
               MAX_ID = Get_general_MAXID("SINGLEWINDOW_INFO_MAX_ID");

               dt_SW_INFO.Rows.Add(MAX_ID + i, EXPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO,SR_NO, INFO_TYPE, INFO_QUALIFIER, INFO_CODE, INFO_TEXT, INFO_MSR, INFO_UQC,
                                    currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate, DEPARTMENT, I_U_TYPE);
           }

           if (i == 0)
           {
               MAX_ID = Get_general_MAXID("SINGLEWINDOW_CTRL_MAX_ID");

               if (SW_Data.Rows[i][10].ToString() != "")
               {
                   CONTROL_TYPE_CODE = SW_Data.Rows[i][10].ToString();
                   CONTROL_LOCATION = SW_Data.Rows[i][11].ToString();
                   CONTROL_START_DATE = SW_Data.Rows[i][12].ToString();
                   CONTROL_END_DATE = SW_Data.Rows[i][13].ToString();
                   CONTROL_RESULT_CODE = SW_Data.Rows[i][14].ToString();
                   CONTROL_RESULT_TEXT = SW_Data.Rows[i][15].ToString();

                   dt_SW_CTRL.Rows.Add(MAX_ID + i, EXPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, CONTROL_TYPE_CODE, CONTROL_LOCATION, CONTROL_START_DATE, CONTROL_END_DATE, CONTROL_RESULT_CODE, CONTROL_RESULT_TEXT,
                                    currentuser, LoginDate, "N", currentbranch, "", Working_Period, currentuser, LoginDate);
               }
           }

           STMT_TYPE = SW_Data.Rows[i][16].ToString();
           SR_NO = SW_Data.Rows[i][17].ToString();
           STMT_CODE = SW_Data.Rows[i][18].ToString();


           if (STMT_TYPE != "" && STMT_CODE != "")
           {
               if (STMT_CODE.Contains('-'))
               {
                   string[] sp0 = STMT_CODE.Split('-');
                   STMT_CODE = sp0[0];
                   STMT_TEXT = sp0[1];
               }

               //STMT_TEXT = SW_Data.Rows[i][11].ToString();
               MAX_ID = Get_general_MAXID("SINGLEWINDOW_STMT_MAX_ID");
               dt_SW_STMT.Rows.Add(MAX_ID + i, EXPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO,SR_NO, STMT_TYPE, STMT_CODE, STMT_TEXT,
                                    currentbranch, Working_Period, LoginDate, currentuser, currentuser, LoginDate);
           }
       }

       if (dt_SW_INFO.Rows.Count > 0)
       {
           admin.SqlBulk_Upload_Product("EXP_SW_INFO_TYPE", dt_SW_INFO, comp_ConnectionStr);
       }
       if (dt_SW_CTRL.Rows.Count > 0)
       {
           admin.SqlBulk_Upload_Product("EXP_SW_CONTROL", dt_SW_CTRL, comp_ConnectionStr);
       }
       if (dt_SW_STMT.Rows.Count > 0)
       {
           admin.SqlBulk_Upload_Product("EXP_SW_STMT", dt_SW_STMT, comp_ConnectionStr);
       }

       //if (dt_SW_INFO.Rows.Count > 0)
       //{
       //    ViewState["dt_SW_INFO"] = dt_SW_INFO;
       //}
       //else
       //{
       //    ViewState["dt_SW_INFO"] = dt_SW_INFO;
       //}

       //if (dt_SW_CTRL.Rows.Count > 0)
       //{
       //    ViewState["dt_SW_CTRL"] = dt_SW_CTRL;
       //}
       //else
       //{
       //    ViewState["dt_SW_CTRL"] = dt_SW_CTRL;
       //}

       //if (dt_SW_STMT.Rows.Count > 0)
       //{
       //    ViewState["dt_SW_STMT"] = dt_SW_STMT;
       //}
       //else
       //{
       //    ViewState["dt_SW_STMT"] = dt_SW_STMT;
       //}

       //ds_SW_CTRL = SW_Data;
       //ViewState["dt_SW_CTRL"] = ds_SW_CTRL;
       //return ds_SW_CTRL;
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
       string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
       string path = errorFolder + "\\" + fileuploadExcel.FileName;
       string picExtension;
       string fileName2;

       if (fileuploadExcel.HasFile)
       {
           picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
           fileName2 = fileuploadExcel.FileName;
           addtoGallery1(fileName2, errorFolder, "NORMAL");
       }

       //Connection String to Excel Workbook
       if (strFileType.Trim() == ".xls")
       {
           connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
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
               string query = string.Format("SELECT * FROM [{0}]", sheetName + "$");
               if (con.State == ConnectionState.Closed)
                   con.Open();
               OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
               adapter.Fill(dataTable);
               data.Tables.Add(dataTable);
               //adapter.Dispose();
               //con.Close();
               //con.Dispose();
           }
       }

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
       dr1[1] = data.Tables[0].Rows[0][5].ToString();
       dr1[2] = data.Tables[0].Rows[0][20].ToString();
       dr1[3] = data.Tables[0].Rows[0][13].ToString();
       dr1[4] = data.Tables[0].Rows[0][14].ToString();
       dr1[5] = data.Tables[0].Rows[0][15].ToString();
       dr1[6] = data.Tables[0].Rows[0][16].ToString();

       dt_main.Rows.Add(dr1);

        DataSet dsData1 = new DataSet();
           DataSet ds_grid1 = new DataSet();
           dsData1.Tables.Add(dt_main);
          
           if (dsData1.Tables[0].Rows.Count > 0)
           {
               gv_Gen_Details.DataSource = dsData1.Tables[0];
               gv_Gen_Details.DataBind();
           }

           if (data.Tables[0].Rows[0][17].ToString().Contains('-'))
           {
               string[] aa = data.Tables[0].Rows[0][17].ToString().Split('-');
               STATE_OF_EXPORT = aa[1].Trim();
               txtStateExport.Text = STATE_OF_EXPORT;
           }
           else
           {
               STATE_OF_EXPORT = data.Tables[0].Rows[0][17].ToString();
               txtStateExport.Text = STATE_OF_EXPORT;
           }

       txtCountryOrigin.Text = data.Tables[0].Rows[0][13].ToString();
       txtPortShipment.Text = data.Tables[0].Rows[0][14].ToString();
       
       DataTable dtt = new DataTable();
       dtt = data.Tables[4];

       DataTable filteredRows = dtt.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull)).CopyToDataTable();
       DataSet dss = new DataSet();
       dss.Tables.Add(filteredRows);
       if (dss.Tables[0].Rows.Count > 0)
       {
           ViewState["ds_Excel_upload"] = dss;
       }

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
               dr = dt_gen.NewRow();
               dr[0] = EXPORT_JOBNO;
               dr[1] = dss.Tables[0].Rows[s][0].ToString();
               if (dss.Tables[0].Rows[s][0].ToString() != "")
               {
                   if (data.Tables[3].Rows.Count > 0)
                   {
                       //string name = (from r in dt_Inv.AsEnumerable()
                       //               where r.Field<string>("INVOICE_SLNO") == dss.Tables[0].Rows[s][0].ToString()
                       //               select r.Field<string>("INVOICE_NO")).First<string>();

                       //var query =
                       //             from r in dt_Inv.AsEnumerable()
                       //             where r.Field<string>("INVOICE_SLNO").Equals(dss.Tables[0].Rows[s][0].ToString())
                       //             select r.Field<string>("INVOICE_NO");
                       //var name1 = query.FirstOrDefault();

                       /*
                       var result = from d in dt_Inv.AsEnumerable()
                                    where d.Field<string>("INVOICE_SLNO") == dss.Tables[0].Rows[s][0].ToString()
                                    select new
                                    {
                                        InvoiceNo = d.Field<string>("INVOICE_NO"),
                                        Invoice_Currency = d.Field<string>("INVOICE_CURRENCY"),
                                        ExRate = d.Field<string>("EXCHANGE_RATE"),
                                        Terms = d.Field<string>("TERMS")
                                    };
                        
                         var a = result.FirstOrDefault();

                       dr[2] = a.InvoiceNo;
                       dr[4] = a.Invoice_Currency;
                       dr[5] = a.ExRate;
                       dr[6] = a.Terms;*/
                      
                       var LoginDetails = from myRow in data.Tables[3].AsEnumerable()
                                          where myRow.Field<string>(0) == dss.Tables[0].Rows[s][0].ToString()
                                          select myRow;

                       DataTable ddr = LoginDetails.CopyToDataTable();

                       if (ddr.Rows.Count > 0)
                       {
                           dr[2] = ddr.Rows[0][1].ToString();
                           dr[4] = ddr.Rows[0][4].ToString();
                           dr[5] = ddr.Rows[0][5].ToString();
                           dr[6] = ddr.Rows[0][7].ToString();
                       }
                   }

                   if (dss.Tables[0].Rows[s][4] != System.DBNull.Value && dss.Tables[0].Rows[s][6] != System.DBNull.Value)
                   {
                       dr[3] = Convert.ToString(Convert.ToDecimal(dss.Tables[0].Rows[s][4]) * Convert.ToDecimal(dss.Tables[0].Rows[s][6]));
                   }
                   else
                   {
                       dr[3] = 0;
                   }

                   dt_gen.Rows.Add(dr);
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

       DataTable dt_sheetNames = new DataTable();
       dt_sheetNames.Columns.Add("SHEETNAMES");
       dt_sheetNames.Rows.Add("GENERAL");
       dt_sheetNames.Rows.Add("PACKAGE");
       dt_sheetNames.Rows.Add("Sea_Container");
       dt_sheetNames.Rows.Add("INVOICE");
       dt_sheetNames.Rows.Add("ITEM");
       dt_sheetNames.Rows.Add("Bulk_LICENSE");
       dt_sheetNames.Rows.Add("Annex_C1_Details");
       dt_sheetNames.Rows.Add("Bulk_Single Window");

       String[] excelSheetNames = new String[dt_sheetNames.Rows.Count];
       int ki = 0;

       foreach (DataRow row in dt_sheetNames.Rows)
       {
           excelSheetNames[ki] = row["SHEETNAMES"].ToString();
           ki++;
       }

       return excelSheetNames;
   }
  
   public void Excel_Upload_load()
   {

       DataTable dt_final = new DataTable();
       int xxx = 0;

       //************************* GENERAL DETAILS ***********************************
       //ds_GENERAL = (DataTable)ViewState["data"];
       DataSet data_all = new DataSet();
       data_all = (DataSet)ViewState["data"];

       dt_final = Filter_EmptyRows(data_all.Tables[0]);
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
       dt_gen.Clear();
       dt_gen.Dispose();
       GC.Collect();

       //************************* Annex_PACKAGE_DETAILS ***********************************
       dt_final = Filter_EmptyRows(data_all.Tables[1]);
       xxx = dt_final.Rows.Count;
       if (xxx > 0)
       {
           if (dt_final.Rows.Count > 0)
           {
               Bind_Annex_PACKAGE_DETAILS(dt_final);
           }
       }
       else
       {
           ViewState["ds_PACKAGE"] = dt_PKG;
       }
       dt_PKG.Clear();
       dt_PKG.Dispose();
       GC.Collect();

       //************************* CONTAINER_DETAILS ***********************************
       dt_final = Filter_EmptyRows(data_all.Tables[2]);
       xxx = dt_final.Rows.Count;
       if (xxx > 0)
       {
           if (dt_final.Rows.Count > 0)
           {
               Bind_SEA_CONTAINER_DETAILS(dt_final);
           }
       }
       else
       {
           ViewState["ds_CONTAINER"] = dt_cont;
       }
       dt_cont.Clear();
       dt_cont.Dispose();
       GC.Collect();

       //************************* INVOICE_DETAILS ***********************************
       dt_final = Filter_EmptyRows(data_all.Tables[3]);
       xxx = dt_final.Rows.Count;
       if (xxx > 0)
       {
           if (dt_final.Rows.Count > 0)
           {
               Bind_Invoice_Details(dt_final);
           }
       }
       else
       {
           ViewState["ds_INVOICE"] = dt_Inv;
       }
       dt_Inv.Clear();
       dt_Inv.Dispose();
       GC.Collect();

       //************************* ITEM_DETAILS ***********************************
       dt_final = Filter_EmptyRows(data_all.Tables[4]);
       xxx = dt_final.Rows.Count;
       if (xxx > 0)
       {
           if (dt_final.Rows.Count > 0)
           {
               Bind_Item_Details(dt_final);
           }
       }
       else
       {
           ViewState["ds_ITEM"] = dt_Item;
       }
       dt_Item.Clear();
       dt_Item.Dispose();
       GC.Collect();

       //************************* Bulk_LICENSE_DETAILS ***********************************
       dt_final = Filter_EmptyRows(data_all.Tables[5]);
       xxx = dt_final.Rows.Count;
       if (xxx > 0)
       {
           if (dt_final.Rows.Count > 0)
           {
               Bind_Bulk_LICENSE_DETAILS(dt_final);
           }
       }
       else
       {
           ViewState["ds_blk_LICNESE"] = dt_blk_Lic;
           ViewState["ds_blk_IMP_EXP_LICNESE"] = dt_blk_Imp_Exp_lic;

       }
       dt_blk_Lic.Clear();
       dt_blk_Lic.Dispose();
       GC.Collect();

       dt_blk_Imp_Exp_lic.Clear();
       dt_blk_Imp_Exp_lic.Dispose();
       GC.Collect();

       //************************* Bulk_LICENSE_DETAILS ***********************************
       dt_final = Filter_EmptyRows(data_all.Tables[6]);
       xxx = dt_final.Rows.Count;
       if (xxx > 0)
       {
           if (dt_final.Rows.Count > 0)
           {
               ViewState["Annex_C1_Details"] = dt_final;
           }
       }
       else
       {
           ViewState["Annex_C1_Details"] = dt;
       }
       dt.Clear();
       dt.Dispose();
       GC.Collect();

       //************************* SINGLE WINDOW DETAILS ***********************************
       dt_final = Filter_EmptyRows(data_all.Tables[7]);
       xxx = dt_final.Rows.Count;
       if (xxx > 0)
       {
           if (dt_final.Rows.Count > 0)
           {
               Bind_SINGLE_WINDOW_Details(dt_final);
           }
       }
       else
       {
           ViewState["dt_SW_INFO"] = dt_SW_INFO;
           ViewState["dt_SW_CTRL"] = dt_SW_CTRL;
           ViewState["dt_SW_STMT"] = dt_SW_STMT;

       }
       dt_SW_INFO.Clear();
       dt_SW_INFO.Dispose();
       GC.Collect();

       dt_SW_CTRL.Clear();
       dt_SW_CTRL.Dispose();
       GC.Collect();

       dt_SW_STMT.Clear();
       dt_SW_STMT.Dispose();
       GC.Collect();

       //******************************************************************************

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

   public void Bind_Third_Party_Details(string IECCODE, string BR_SL_NO)
   {
       Client_Master client = new Client_Master();

       client.Eimp_exp_id = "";
       client.Eimp_exp_iecno = IECCODE;
       client.Eimp_exp_brslno = BR_SL_NO;
       client.Eimp_exp_name = "";
       client.Ename = "GET_THIRD_PARTY_DETAILS";

       ds_TPD = client.RetrieveAll_Imp_exp_master();
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
}