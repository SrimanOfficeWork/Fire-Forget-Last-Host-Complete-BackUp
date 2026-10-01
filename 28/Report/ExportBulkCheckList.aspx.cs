using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;
using System.Globalization;
using System.IO;
 

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Ionic.Zip;


public partial class Export_General_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Export_General_Grid_Search Exp = new Export_General_Grid_Search();
    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();
    StreamWriter sw;
    User_Creation user_Create = new User_Creation();
    DataSet ds = new DataSet();
    DataSet dss = new DataSet();

    CheckList CHKLIST = new CheckList();
    Export_FlatFile_Generation FlatFile = new Export_FlatFile_Generation();
    Export_General_New Export = new Export_General_New();  
    Date_Time dt = new Date_Time();
    
    adminmaster erm = new adminmaster();
    eroyalmaster Imp_Exp = new eroyalmaster();
    EXP_Validation EV = new EXP_Validation();
    IMP_Validation IV = new IMP_Validation();
    int currentPageNumber1 = 0;

    public string ICEGATE_ID,ICEGATE_EMAIL_ID, ICEGATE_EMAIL_PWD, errorFolder = "";
    public char ch = Convert.ToChar(29);
    public int is_Annexure_Mode = 0;
    public string SELECT_TYPE, SELECT_BRANCH, currentuser, currentbranch, currentcomp_name, comp_ConnectionStr, Working_Period, LoginDate, SB_NO, SB_DATE, sealtype_txt, CHA_NO;
    public string Amendment_Type = "";
    public string Amendment_No = "";
    public string Amendment_Date = "";
    public string SRNO = "";     
    public string EMail_ID = "";    
    public string  Outlook_From_mail_Address = "";
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

    #region Invoice_Details

    public string INVOICE_ID;     
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
    public string ITEM_PMVVALUE;
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
    #region Packing List

    public string ANNEX_SEA_PACK_FROM;
    public string ANNEX_SEA_PACK_TO;
    public string ANNEX_SEA_PACK_PACKAGETYPE;
    public string ANNEX_SEA_PACK_FROMDESC;
    public string ANNEX_SEA_PACK_TODESC;


    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        
    // commented for areawise implementation on 05-mar-2020
        /*
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                //hd_branch.Value = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
                //hd_branch.Value = currentbranch;
            }
        }
        else
        {
            SELECT_BRANCH = "";
            //hd_branch.Value = currentbranch;
        }

         *   * */
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!IsPostBack)
        {
            Load_Exporter();
        }
    }
    private void Load_Exporter()
    {
        DataSet ds = new DataSet();

        Exp.flag = "Select-AllExporter";
        ds = Exp.EXP_General_Search_Bulk(); 
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlExporter.DataSource = ds.Tables[0];
            ddlExporter.DataTextField = "exporter_name";
            ddlExporter.DataValueField = "exporter_name";
            ddlExporter.DataBind();
            ddlExporter.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "--Select--"));
            ddlExporter.SelectedIndex = 0;
        }

         
    } 
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            gridbind(1);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        } 
    }

    public void gridbind(int currentPageNumber1)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        gvdetails.DataSource = dt;
        gvdetails.DataBind();

        Exp.flag = "Select-ExportJobs";
        Exp.SEARCH_CAT = "";
        Exp.SEARCH_ITEM = "";
        Exp.EXPORTER_NAME = ddlExporter.SelectedValue.ToString();
        Exp.TRANSPORT_MODE = "";
        Exp.CUSTOMS_HOUSE = "";
        Exp.Selected_Index = "1";
        Exp.maximumRows = txt_count.Text;
        Exp.startRowIndex = Convert.ToString(currentPageNumber1);
        Exp.FromDt = txtfromdate.Text.Substring(3, 2) + '/' + txtfromdate.Text.Substring(0, 2) + '/' + txtfromdate.Text.Substring(6, 4);
        Exp.ToDt = txttodate.Text.Substring(3, 2) + '/' + txttodate.Text.Substring(0, 2) + '/' + txttodate.Text.Substring(6, 4);

        ds = Exp.EXP_General_Search_Bulk();
        dt = ds.Tables[0];

        if (dt.Rows.Count > 0)
        {
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }
        //currentPageNumber1 = Convert.ToInt32(1);
        Grid_Total(currentPageNumber1, Exp.result);
        ddlSelectPageno.SelectedValue = Convert.ToString(currentPageNumber1); 

    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtfromdate.Text = "";
        txttodate.Text = "";
        ddlExporter.SelectedIndex = 0;
        DataTable dt = new DataTable();
        gvdetails.DataSource = dt;
        gvdetails.DataBind();        

    }


    protected void btnBulkFlatfile_Click(object sender, EventArgs e)
    {
      
       errorFolder = Server.MapPath("~/Submission/" + Connection.COMPANYID().ToString() + "/" + Connection.Current_Branch() + "/" + Connection.Current_User() + "/EXP_BulkFlatFile/");  

       if (Directory.Exists(errorFolder) == false)
        {
            Directory.CreateDirectory(errorFolder);
        }
        else
        {
            foreach (FileInfo fileInformation in new DirectoryInfo(errorFolder).GetFiles())  // delete all the files inside  
            {
                File.Delete(fileInformation.FullName);
            }
        }
        
        foreach (GridViewRow row in gvdetails.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                SB_Details(row.Cells[1].Text.Trim());
                Flat_File("", "", row.Cells[1].Text.Trim());
            }
        }

        var list = Directory.GetFiles(errorFolder);
        if (list.Length > 0)
        {
          
            errorFolder = Server.MapPath("~/Submission/" + Connection.COMPANYID().ToString() + "/" + Connection.Current_Branch() + "/" + Connection.Current_User());
            string SourceFolderPath = System.IO.Path.Combine(errorFolder, "EXP_BulkFlatFile");
            string nameFolder = "BulkFlatFile";
            Response.Clear();
            Response.ContentType = "application/zip";
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", nameFolder + ".zip"));

            bool recurseDirectories = true;
            using (ZipFile zip = new ZipFile())
            {
                zip.AddSelectedFiles("*", SourceFolderPath, string.Empty, recurseDirectories);
                zip.Save(Response.OutputStream);
            }
            Response.End();
        }
                
    }


    public void SB_Details(string gridjobno)
    {
        string jobno = gridjobno;
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
            FlatFile.JOBNo = jobno;
            FlatFile.TRANSPORT_MODE = "";
            FlatFile.Ename = "FlatFile";
            FlatFile.Workingperiod = SELECT_BRANCH;
            ds = FlatFile.Retrieve_Export_All_Details();
            is_Annexure_Mode = FlatFile.result;

            Session["ds"] = ds;
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

                EXPORTER_NAME = dt.Trim(ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString());
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
                    ADCODE = ADCODE.Substring(0, 7);
                }

                BANK_ACCOUNT = dt.Trim(ds.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString());
                DRAWBACK_ACCOUNT = dt.Trim(ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString());
                CONSIGNEE_NAME = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString());

                CONSIGNEE_ADD1 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString());

                CONSIGNEE_ADD2 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString());

                //SECTION46_DESC = ds.Tables[0].Rows[0]["SECTION46_DESC"].ToString();

                CONSIGNEE_ADD3 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString());

                //FIRSTCHECK_DESC = ds.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString();

                CONSIGNEE_ADD4 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString());

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

                EXPORTER_NAME = dt.Trim(ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString());
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
                    ADCODE = ADCODE.Substring(0, 7);
                }

                BANK_ACCOUNT = dt.Trim(ds.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString());
                DRAWBACK_ACCOUNT = dt.Trim(ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString());
                CONSIGNEE_NAME = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString());

                CONSIGNEE_ADD1 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString());

                CONSIGNEE_ADD2 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString());

                //SECTION46_DESC = ds.Tables[0].Rows[0]["SECTION46_DESC"].ToString();

                CONSIGNEE_ADD3 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString());

                //FIRSTCHECK_DESC = ds.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString();

                CONSIGNEE_ADD4 = dt.Trim(ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString());

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

                GSTN_TYPE = dt.Trim(ds.Tables[0].Rows[0]["GSTN_TYPE"].ToString());
                GSTN_ID = dt.Trim(ds.Tables[0].Rows[0]["GSTN_ID"].ToString());

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

    public void Get_Admin_Master_Codes()
    {

        //Seal Type
        if (NATURE_OF_CARGO != "")
        {
            sealtype_txt = "";
        }
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

    public void Flat_File(string Type, string path, string gridjobno)
    {

        string jobno = gridjobno;
        string logFileName , createfilename = "";

        CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();
        ICEGATE_EMAIL_ID = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
        ICEGATE_EMAIL_PWD = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();

        DateTime date = System.DateTime.Now;
        string datestringg = string.Format("{0:yyyyMMdd}", date);

        DateTime tt = System.DateTime.Now;

        string time = string.Format("{0:hhmm}", tt);
        GetDate_ddmmyy = Convert.ToDateTime(date).ToString("ddMMyy").ToString();
        string yy = Convert.ToDateTime(date).ToString("yyyy").ToString();

        logFileName = jobno + yy + ".sb";
        createfilename = logFileName;
        Session["createflename"] = logFileName;
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

        //ICEGATE_ID = txt_icegate_Id.Text;
        ICEGATE_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
 
        sw.WriteLine("HREC" + ch + "ZZ" + ch + ICEGATE_ID + ch + "ZZ" + ch + CUSTOMS_HOUSE + ch + "ICES1_5" + ch + "P" + ch + ch + "CACHE01" + ch + jobno + DDMMYY_JOBDATE + ch + datestringg + ch + time);

        sw.WriteLine("<TABLE>SB");

   
        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + CHA_NO + ch + IEC_NO + ch + BRANCH_NO + ch + EXPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS4 + ch + ADDRESS5 + ch + TYPE_OF_EXPORTER + ch + EXPORTER_CLASS + ch + STATE_OF_EXPORT + ch + ADCODE + ch + EPZ_CODE + ch + CONSIGNEE_NAME + ch + CONSIGNEE_ADD1 + ch + CONSIGNEE_ADD2 + ch + CONSIGNEE_ADD3 + ch + CONSIGNEE_ADD4 + ch + CONSIGNEE_ADD5 + ch + NFEI_TYPE + ch + RBI_WAIVER_NO + ch + RBI_WAIVER_DATE + ch + CUSTOMS_HOUSE + ch + PORT_DISCHARGE + ch + COUNTRY_FINAL_DEST + ch + COUNTRY_DISCHARGE + ch + PORT_FINAL_DEST + ch + ANNEX_SEA_SEAL_TYPE + ch + NATURE_OF_CARGO + ch + GROSS_WEIGHT + ch + NET_WEIGHT + ch + UNIT_CODE + ch + TOTAL_PACKAGES + ch + MARKS_NO + ch + LOOSE_PACKETS + ch + NO_CONTAINERS + ch + ANNEX_AIR_MAWB_NO + ch + ANNEX_AIR_HAWB_NO + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + GSTN_TYPE + ch + GSTN_ID);

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

                if (BUYER_NAME == "SAME AS CONSIGNEE")
                {
                    BUYER_ADDRESS = "`";
                }
                //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + INVOICE_NO + ch + INVOICE_DATE + ch + INVOICE_CURRENCY + ch + TERMS + ch + BUYER_NAME + ch + BUYER_ADDRESS + ch + BUYER_ADDRESS1 + ch + BUYER_ADDRESS2 + ch + BUYER_ADDRESS3 + ch + FREIGHT_CURRENCY + ch + FREIGHT_CHARGES + ch + INSURANCE_RATE + ch + INSURANCE_CURRENCY + ch + INSURANCE_CHARGES + ch + COMMISSION_RATE + ch + COMMISSION_CURRENCY + ch + COMMISSION_CHARGES + ch + FOB_RATE + ch + FOB_CURRENCY.ToUpper() + ch + FOB_CHARGES + ch + OTHER_DEDUCTION_RATE + ch + OTHER_DEDUCTION_CURRENCY + ch + OTHER_DEDUCTION_CHARGES + ch + WHEATHER_UNIT_PRICE + ch + PACKMISC_CHARGES + ch + CONTRACT_NO + ch + PAYMENT_METHOD + ch + PERIOD_PAYMENT + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + INVOICE_NO + ch + INVOICE_DATE + ch + INVOICE_CURRENCY + ch + TERMS + ch + BUYER_NAME + ch + BUYER_ADDRESS + ch + BUYER_ADDRESS1 + ch + BUYER_ADDRESS2 + ch + BUYER_ADDRESS3 + ch + FREIGHT_CURRENCY + ch + FREIGHT_CHARGES + ch + INSURANCE_RATE + ch + INSURANCE_CURRENCY + ch + INSURANCE_CHARGES + ch + COMMISSION_RATE + ch + COMMISSION_CURRENCY + ch + COMMISSION_CHARGES + ch + FOB_RATE + ch + FOB_CURRENCY.ToUpper() + ch + FOB_CHARGES + ch + OTHER_DEDUCTION_RATE + ch + OTHER_DEDUCTION_CURRENCY + ch + OTHER_DEDUCTION_CHARGES + ch + WHEATHER_UNIT_PRICE + ch + PACKMISC_CHARGES + ch + CONTRACT_NO + ch + PAYMENT_METHOD + ch + PERIOD_PAYMENT + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + THIRDPARTY_NAME + ch + THIRDPARTY_ADD1 + ch + THIRDPARTY_ADD2 + ch + THIRDPARTY_CITY + ch + T_PARTY_COUNTRY_SUB_DIV + ch + T_PARTY_COUNTRY_CODE + ch + T_PARTY_PIN + ch + AUTHORIZED_ECONOMIC_OPERATOR_CODE + ch + A_E_O_COUNTRY + ch + AUTHORIZED_ECONOMIC_OPERATOR + ch + TERMS_PLACE);
                i++;
            }
        }

        

        int f = 0;
        if (INVOICE_CURRENCY != "")
        {
            sw.WriteLine("<TABLE>EXCHANGE");
            

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
                            NON_STD_CERTIFICATE_NO = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString());
                            NON_STD_CERTIFICATE_DATE = dt.Trim(dt_2.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString().Replace("19000101", ""));
                            EXCHANGE_RATE = dt.Trim(dt_2.Tables[0].Rows[0]["EXCHANGE_RATE"].ToString());
                            Standard_Currency = "N";
                        }


                    }


                    //---------------For Non Standard Currency on 01Sep2015----------------//

                    if (INVOICE_CURRENCY != "")

                        //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_CURRENCY + ch + Currency_Name + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + EXCHANGE_RATE + ch + Effective_Date + ch + Standard_Currency + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_CURRENCY + ch + NON_STD_BANKNAME + ch + dt.Get_Exchange_PerUnit(INVOICE_CURRENCY) + ch + EXCHANGE_RATE + ch + NON_STD_EFFECT_DT_EXP + ch + Standard_Currency + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);



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
                ITEM_DESCRIPTION1 = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DESCRIPTION1"].ToString());
                ITEM_DESCRIPTION2 = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DESCRIPTION2"].ToString());
                ITEM_DESCRIPTION3 = dt.Trim(ds.Tables[2].Rows[j]["ITEM_DESCRIPTION3"].ToString());
                RITCNO = dt.Trim(ds.Tables[2].Rows[j]["RITCNO"].ToString());
                ITEM_QTY = dt.Trim(ds.Tables[2].Rows[j]["ITEM_QTY"].ToString());
                ITEM_QTY_CODE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_QTY_CODE"].ToString());
                ITEM_UNIT_PRICE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_UNIT_PRICE"].ToString());
                ITEM_PER = dt.Trim(ds.Tables[2].Rows[j]["ITEM_PER"].ToString());
                ITEM_AMOUNT = dt.Trim(ds.Tables[2].Rows[j]["ITEM_AMOUNT"].ToString());
                ITEM_PMVVALUE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_PMVVALUE"].ToString());

                ITEM_SCHEME_CODE = dt.Trim(ds.Tables[2].Rows[j]["ITEM_SCHEME_CODE"].ToString());
                ITEM_ACCESSORIES_DESC = dt.Trim(ds.Tables[2].Rows[j]["ITEM_ACCESSORIES_DESC"].ToString());
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

                string val = dt.Trim(ds.Tables[2].Rows[j]["PMV_VALUE"].ToString());

                if (Session["COMPANY_ID"].ToString() == "116")
                {
                    if (currentbranch == "ACC, Kolkata" || currentbranch == "CusHouse, Kolkata" || currentbranch == "ICD,Petrapole")
                    {
                        val = dt.Trim(ds.Tables[2].Rows[j]["ITEM_PMVVALUE"].ToString());
                    }
                }
                //-------------Implemented on 16Mar2018 For elogix Clients and eroyal Clients----------------//
                else if (Session["COMPANY_ID"].ToString() == "442" || Session["COMPANY_ID"].ToString() == "438" || Session["COMPANY_ID"].ToString() == "436" || Session["COMPANY_ID"].ToString() == "443" || Session["COMPANY_ID"].ToString() == "435" || Session["COMPANY_ID"].ToString() == "434" || Session["COMPANY_ID"].ToString() == "402" || Session["COMPANY_ID"].ToString() == "459" || Session["COMPANY_ID"].ToString() == "444" || Session["COMPANY_ID"].ToString() == "457" || Session["COMPANY_ID"].ToString() == "477" || Session["COMPANY_ID"].ToString() == "478" || Session["COMPANY_ID"].ToString() == "479" || Session["COMPANY_ID"].ToString() == "488" || Session["COMPANY_ID"].ToString() == "492" || Session["COMPANY_ID"].ToString() == "525")
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
                //-------------Implemented on 16Mar2018 For elogix Clients and eroyal Clients----------------//
                else if (Session["COMPANY_ID"].ToString() == "442" || Session["COMPANY_ID"].ToString() == "438" || Session["COMPANY_ID"].ToString() == "436" || Session["COMPANY_ID"].ToString() == "443" || Session["COMPANY_ID"].ToString() == "435" || Session["COMPANY_ID"].ToString() == "434" || Session["COMPANY_ID"].ToString() == "402" || Session["COMPANY_ID"].ToString() == "459" || Session["COMPANY_ID"].ToString() == "444" || Session["COMPANY_ID"].ToString() == "457" || Session["COMPANY_ID"].ToString() == "477" || Session["COMPANY_ID"].ToString() == "478" || Session["COMPANY_ID"].ToString() == "479" || Session["COMPANY_ID"].ToString() == "488" || Session["COMPANY_ID"].ToString() == "492" || Session["COMPANY_ID"].ToString() == "525")
                {
                    if (Convert.ToDouble(PMV_VALUE) == 0.01 || Convert.ToDouble(PMV_VALUE) == 0)
                        PMV_VALUE = "0.00";
                }
                //-------------Implemented on 16Mar2018 For elogix Clients and eroyal Clients----------------//

                //Check IS_JOBBING
                DataView view1 = ds.Tables[5].DefaultView;

                view1.RowFilter = "INVOICE_SLNO = " + INVOICE_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;

                //DataTable table1 = view1.ToTable();
                DataSet dt_UserRights = new DataSet();
                dt_UserRights.Tables.Add(view1.ToTable());
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

                //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_SCHEME_CODE + ch + RITCNO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + ITEM_DESCRIPTION3 + ch + ITEM_QTY_CODE + ch + ITEM_QTY + ch + ITEM_UNIT_PRICE + ch + ITEM_QTY_CODE + ch + ITEM_PER + ch + PMV_VALUE + ch + NOTIFICATION_NO + ch + IS_ThirdParty + ch + REWARD_POINTS + ch + ch + ch);
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_SCHEME_CODE + ch + RITCNO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + ITEM_DESCRIPTION3 + ch + ITEM_QTY_CODE + ch + ITEM_QTY + ch + ITEM_UNIT_PRICE + ch + ITEM_QTY_CODE + ch + ITEM_PER + ch + PMV_VALUE + ch + NOTIFICATION_NO + ch + IS_ThirdParty + ch + REWARD_POINTS + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + MANUFACTURER_PRODUCER + ch + M_P_GROWER_CODE + ch + M_P_GROWER_ADD1 + ch + M_P_GROWER_ADD2 + ch + M_P_GROWER_CITY + ch + M_P_GROWER_COUNTRY_SUBDIV + ch + M_P_GROWER_PIN + ch + M_P_GROWER_COUNTRY + ch + SOURCE_STATE + ch + TRANSIT_COUNTRY + ch + ACCESSORY_STATUS + ch + ENDUSE_ITEM + ch + HAWB_NO + ch + TOTAL_PKGS + ch + IGST_PAYMENT + ch + TAXABLE_VALUE + ch + IGST_AMT);
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
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_ACCESSORIES_DESC);
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

                //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_IECCODE + ch + BR_SLNO + ch + ITEM_EXPORTER_NAME + ch + ADDRESS1 + ch + ADDRESS2 + ch + ADDRESS3 + ch + ADDRESS5 + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);                
                //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_IECCODE + ch + BR_SLNO + ch + ITEM_EXPORTER_NAME + ch + ITEM_ADDRESS1 + ch + ITEM_ADDRESS2 + ch + ITEM_ADDRESS3 + ch + ITEM_ADDRESS5 + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + GSTN_TYPE + ch + GSTN_ID);
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_IECCODE + ch + BR_SLNO + ch + ITEM_EXPORTER_NAME + ch + ITEM_ADDRESS1 + ch + ITEM_ADDRESS2 + ch + ITEM_ADDRESS3 + ch + ITEM_ADDRESS5 + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + GSTN_TYPE + ch + G_Id);

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

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CESS_ID + ch + CESS_SLNO + ch + CESS_ITEM_QTY + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

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

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + DRAWBACK_SLNO + ch + DRAWBACK_QTY + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
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

                //if (ds.Tables[4].Rows.Count > 0)
                //{
                //sw.WriteLine("<TABLE>LICENCE");

                //-------------------------------------

                //j = 0;


                DataSet dss = new DataSet();
                if (ds.Tables[4].Rows.Count > 0)
                {
                    DataView view = ds.Tables[4].DefaultView;
                    //view.RowFilter = "LICENSE_NO" + " = '" +LICENSE_NO+ "'";
                    view.RowFilter = "LICENSE_NO = '" + LICENSE_NO + "' and " + "LICENSE_ID = " + LICENSE_ID;


                    DataTable table = view.ToTable();

                    dss.Tables.Add(table);


                    //if (dss.Tables[0].Rows.Count > 0)
                    //{
                    int m = 0;
                    while (dss.Tables[0].Rows.Count > m)
                    {
                        //---------------Modified on 4th Oct 2014-------------------//

                        SCHEME_CODE = dt.Trim(dss.Tables[0].Rows[m]["SCHEME_CODE"].ToString());
                        SCHEME = dt.Trim(dss.Tables[0].Rows[m]["SCHEME"].ToString());
                        LICENSE_R_SL_NO = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_R_SL_NO"].ToString());
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

                        //----------------------------------//

                        //----------------------------------

                        //SCHEME_CODE = dt.Trim(dss.Tables[0].Rows[0]["SCHEME_CODE"].ToString());
                        //SCHEME = dt.Trim(dss.Tables[0].Rows[0]["SCHEME"].ToString());
                        //LICENSE_R_SL_NO = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_R_SL_NO"].ToString());
                        ////LICENSE_NO = dt.Trim(dss.Tables[0].Rows[m]["LICENSE_NO"].ToString());
                        //LICENSE_DATE = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_DATE"].ToString().Replace("19000101", ""));

                        //LICENSE_E_SL_NO = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_E_SL_NO"].ToString());
                        //LICENSE_EXP_QTY = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_EXP_QTY"].ToString());
                        //LICENSE_EXP_UNIT = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_EXP_UNIT"].ToString());
                        //LICENSE_IMP_ITEM_SL_NO = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_IMP_ITEM_SL_NO"].ToString());
                        //LICENSE_IMP_DESC = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_IMP_DESC"].ToString());

                        //LICENSE_IMP_QTY = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_IMP_QTY"].ToString());
                        //LICENSE_IMP_UNIT = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_IMP_UNIT"].ToString());
                        //LICENSE_IMP_TYPE = dt.Trim(dss.Tables[0].Rows[0]["LICENSE_IMP_TYPE"].ToString());

                        //----------------------------------

                        sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SRNO + ch + LICENSE_NO + ch + LICENSE_DATE + ch + LICENSE_E_SL_NO + ch + LICENSE_IMP_ITEM_SL_NO + ch + LICENSE_IMP_QTY + ch + LICENSE_EXP_QTY + ch + LICENSE_IMP_TYPE + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);


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

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SRNO + ch + BE_NO + ch + BE_DATE + ch + BE_INV_SLNO + ch + BE_INV_NO + ch + BE_ITEM_NO + ch + BE_PORT_CODE + ch + QTY + ch + UNIT + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
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

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_AR4_NO + ch + ITEM_AR4_DATE + ch + ITEM_COMMISSION_RATE + ch + ITEM_DIVISION + ch + ITEM_RANGE + ch + ITEM_REMARKS);

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

                if (COMPANY_ID == "146" || COMPANY_ID == "158" || COMPANY_ID == "7" || COMPANY_ID == "137" || COMPANY_ID == "164" || COMPANY_ID == "165")
                {
                    ANNEX_SEA_PACK_FROM = ANNEX_SEA_PACK_FROMDESC;
                    ANNEX_SEA_PACK_TO = ANNEX_SEA_PACK_TODESC;
                }

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + ANNEX_SEA_PACK_FROM + ch + ANNEX_SEA_PACK_TO + ch + ANNEX_SEA_PACK_PACKAGETYPE);

                b++;
            }
        }

        if (ROTATION_NO != "")
        {
            sw.WriteLine("<TABLE>ROTATION");
            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + ROTATION_DATE + ch + ROTATION_NO);
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

            sw.WriteLine("<TABLE>EOU");
            sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + ANNEX_IECCODE + ch + ANNEX_BR_SLNO + ch + ANNEX_EXAM_DATE + ch + ANNEX_EXAM_OFFICER + ch + ANNEX_EXAM_DESIGN + ch + ANNEX_SUPER_NAME + ch + ANNEX_SUPER_DESIGN + ch + ANNEX_COMMISSION_RATE + ch + ANNEX_DIVISION + ch + ANNEX_RANGE + ch + ANNEX_SEAL_NO + ch + ANNEX_VERIFIED_EXAM_OFFICER + ch + ANNEX_SAMPLE_DRAWN + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);
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

                //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + ANNEX_SEA_CON_CONTAINERNO + ch + ANNEX_SEA_CON_SIZE + ch + ANNEX_SEA_CON_EXCISE_SEALNO + ch + ANNEX_SEA_CON_SEAL_DATE);
                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + ANNEX_SEA_CON_CONTAINERNO + ch + ANNEX_SEA_CON_SIZE + ch + ANNEX_SEA_CON_EXCISE_SEALNO + ch + ANNEX_SEA_CON_SEAL_DATE + ch + ANNEX_SEA_CON_SEALTYPE_INDICATOR + ch + ANNEX_SEA_CON_SEAL_DEVICEID + ch + ANNEX_SEA_CON_DOC_TYPE + ch + ANNEX_SEA_CON_DOC_NUMBER);

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

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SRNO + ch + ITEM_STR_CODE + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date);

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

        if (ds_type.Tables[0].Rows.Count > 0)
        {
            int sws_type = 0;
            sw.WriteLine("<TABLE>SW_INFO_TYPE");
            while (ds_type.Tables[0].Rows.Count > sws_type)
            {
                INFO_TYPE = "";
                INVOICE_SLNO = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds_type.Tables[0].Rows[sws_type]["ITEM_SLNO"].ToString());

                INFO_TYPE = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_TYPE"].ToString());
                INFO_QUALIFIER = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_QUALIFIER"].ToString());
                INFO_CODE = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_CODE"].ToString());
                INFO_TEXT = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_TEXT"].ToString());

                INFO_MSR = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_MSR"].ToString());
                INFO_UQC = dt.Trim(ds_type.Tables[0].Rows[sws_type]["INFO_UQC"].ToString());

                INFO_SERIAL_NO = dt.Trim(ds_type.Tables[0].Rows[sws_type]["SLNO"].ToString());


                if (INFO_TYPE != "")
                {
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + INFO_SERIAL_NO + ch + INFO_TYPE + ch + INFO_QUALIFIER + ch + INFO_CODE + ch + INFO_TEXT + ch + INFO_MSR + ch + INFO_UQC);
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


                if (CONSTITUENT_SRNO != "")
                {
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CONSTITUENT_SERIAL_NO + ch + CONSTITUENT_ELEMENT_NAME + ch + CONSTITUENT_ELEMENT_CODE + ch + CONSTITUENT_PERCENTAGE + ch + CONSTITUENT_YIELD_PERCENTAGE + ch + ACTIVE_INGREDIENT);
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

                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + PRODUCTION_SERIAL_NO + ch + PRODUCTION_BATCH_IDENTIFIER + ch + PRODUCTION_BATCH_QUANTITY + ch + UNIT_QTY_CODE + ch + DATE_OF_MANUFACTURING + ch + DATE_OF_EXPIRY + ch + BEST_BEFORE);
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

                INVOICE_SLNO = "0";
                ITEM_SLNO = "0";



                if (CONTROL_TYPE_CODE != "" || CONTROL_RESULT_CODE != "")
                {
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + CONTROL_SERIAL_NO + ch + CONTROL_TYPE_CODE + ch + CONTROL_LOCATION + ch + CONTROL_START_DATE + ch + CONTROL_END_DATE + ch + CONTROL_RESULT_CODE + ch + CONTROL_RESULT_TEXT);
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
                STMT_TEXT = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["STMT_TEXT"].ToString());

                STMT_SERIAL_NO = dt.Trim(ds_stmt.Tables[0].Rows[sws_stmt]["SLNO"].ToString());

                //STMT_TEXT = "";
                STMT_DECLARATION_TYPE = "B";


                if (STMT_TYPE != "")
                {

                    //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + STMT_DECLARATION_TYPE + ch + STMT_DECLARATION_NUMBER + ch + STMT_DECLARATION_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + STMT_TYPE + ch + STMT_CODE + ch + STMT_TEXT);
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + STMT_SERIAL_NO + ch + STMT_TYPE + ch + STMT_CODE + ch + STMT_TEXT);
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

                INVOICE_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["INVOICE_SLNO"].ToString());
                ITEM_SLNO = dt.Trim(ds_supp.Tables[0].Rows[sws_supp]["ITEM_SLNO"].ToString());

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

                if (UNIQUE_DOC_NUMBER != "")
                {
                    if (ICEGATE_ID.Length > 15)
                    {
                        ICEGATE_ID = ICEGATE_ID.Substring(0, 15);
                    }
                    //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SUP_DOC_SERIAL_NO + ch + UNIQUE_DOC_NUMBER + ch + DOC_TYPE_CODE + ch + DOC_ISSUING_PARTY_CODE + ch + DOC_ISSUING_PARTY_NAME_ADD1 + ch + DOC_ISSUING_PARTY_NAME_ADD2 + ch + DOC_ISSUING_PARTY_CITY + ch + DOC_ISSUING_PARTY_PIN + ch + DOC_REF_NUMBER + ch + PLACE_OF_ISSUE + ch + DOC_ISSUE_DATE + ch + DOC_EXPIRY_DATE + ch + BENEFICIARY_PARTY_CODE + ch + BENEFICIARY_PARTY_ADDRESS1 + ch + BENEFICIARY_PARTY_ADDRESS2 + ch + BENEFICIARY_PARTY_CITY + ch + BENEFICIARY_PARTY_PIN + ch + FILE_TYPE);
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SERIAL_NO + ch + UNIQUE_DOC_NUMBER + ch + DOC_TYPE_CODE + ch + DOC_ISSUING_PARTY_CODE + ch + DOC_ISSUING_PARTY_NAME_ADD1 + ch + DOC_ISSUING_PARTY_NAME_ADD2 + ch + DOC_ISSUING_PARTY_CITY + ch + DOC_ISSUING_PARTY_PIN + ch + DOC_REF_NUMBER + ch + PLACE_OF_ISSUE + ch + DOC_ISSUE_DATE + ch + DOC_EXPIRY_DATE + ch + BENEFICIARY_PARTY_CODE + ch + BENEFICIARY_PARTY_ADDRESS1 + ch + BENEFICIARY_PARTY_ADDRESS2 + ch + BENEFICIARY_PARTY_CITY + ch + BENEFICIARY_PARTY_PIN + ch + FILE_TYPE + ch + DOC_ISSUING_PARTY_NAME + ch + BENEFICIARY_PARTY_NAME + ch + ICEGATE_ID);
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

                sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + jobno + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + SLNO + ch + BE_SITE + ch + BE_NO + ch + BE_DATE + ch + BE_INVOICE_NO + ch + BE_INVOICE_ITEM_NO + ch + MANUAL_BE_Y_N + ch + BE_QTY_UTILISED + ch + BE_ITEM_DESC + ch + BE_QTY + ch + BE_UQC + ch + BE_ASS_VALUE + ch + BE_DUTY_PAID + ch + BE_DUTY_PAYMENT_DATE + ch + BE_OTH_IDENTIFIABLE_PARAMETER + ch + BE_ASS_VALUE_CLAIM + ch + BE_ITEM_USED_Y_N + ch + COMMISIONER_PERMISSION_Y_N + ch + INPUT_CREDIT_Y_N + ch + PERSONAL_USED_Y_N + ch + MODVAT_AVAILED_Y_N + ch + MODVAT_REPAID_Y_N);
                re++;
            }
        }

        //----------End Re-Export------------------//


        sw.WriteLine("<END-SB>");
        TextBox txt = new TextBox();
        sw.WriteLine("TREC" + ch + jobno + DDMMYY_JOBDATE);

        sw.Flush();
        sw.Close();
        sw.Dispose();
        

        //if (IS_Imgbtn == "1")
        //{
        //    Response.Write(sw.ToString());
        //    Response.Flush();             
        //    HttpContext.Current.ApplicationInstance.CompleteRequest();
        //}
        //DSC_Flatfile_Sent_Check();
    }

  
    protected void btnBulkCheckListZip_Click(object sender, EventArgs e) // protected void btnsavenext_Click(object sender, EventArgs e)
    {
        getjobno();
        btnBulkCheckListZip.Attributes.Add("onclick", "checklistZip()");
    }

    private void getjobno()
    {
        hdrowindex.Value = "";
        string jobnos = "";
        foreach (GridViewRow row in gvdetails.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                jobnos = jobnos + row.Cells[1].Text.Trim() + ",";  //rownum                

            }

        }
        jobnos = jobnos.ToString().Trim(',');
        hdrowindex.Value = jobnos;
    }
   
  
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }

 

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }


    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSelectPageno.SelectedValue != "")
        {
            string val = "1";
            if (ddlSelectPageno.SelectedValue == "1")
            {
                //val = "100000000";
                gridbind(Int32.Parse(val));

            }
            else
            {
                //gridbind(Math.Abs((Int32.Parse(ddlSelectPageno.SelectedValue.ToString()) * gvdetails.PageSize) - Int32.Parse(lblTotalPages.Text)));
                gridbind(Int32.Parse(ddlSelectPageno.SelectedValue));
            }
        }
    }

    public void Grid_Total(int currentPageNumber1, double totalRows)
    {
        int ii = CalculateTotalPages(totalRows);
   
        if (ViewState["selected_change"] == "1")
        {
        }
        else
            Add_Pageno(ii);
    }

    public void Add_Pageno(int p)
    {
        if (p != 0)
        {
            ddlSelectPageno.Items.Clear();
            for (int i = 1; i <= p; i++)
            {
                ddlSelectPageno.Items.Add(Convert.ToString(i));
            }
        }
    }

    private int CalculateTotalPages(double totalRows)
    {
        //int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);
        int pagecount = Convert.ToInt32(txt_count.Text);
        int totalPages = (int)Math.Ceiling(totalRows / pagecount);

        return totalPages;
    }
    

}