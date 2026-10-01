
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Net;

public class User_Creation
{
    ErrorLogs er = new ErrorLogs();
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;

    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

    private string _startRowIndex, _maximumRows, _totalRows, _JOBNO, _USER_ID, _BRANCH_CODE, _YEAR, _WORKING_PERIOD, _BRANCH_COMMON, _Import, _Export
        , _Billing, _Acc, _Imp_Sez, _Exp_Sez, _IEC_NO, _BRANCH_NO, _IEC_NAME, _ID, _IMP_EXP_MASTER_yn, _SUPPLIER_MASTER_yn, _BUYER_MASTER_yn, _CONSIGNEE_MASTER_yn, _ADCODE_MASTER_yn, _THIRDPARTY_MASTER_yn;

    public string Import { get { return _Import; } set { _Import = value; } }
    public string Export { get { return _Export; } set { _Export = value; } }
    public string Billing { get { return _Billing; } set { _Billing = value; } }
    public string Acc { get { return _Acc; } set { _Acc = value; } }

    public string Imp_Sez { get { return _Imp_Sez; } set { _Imp_Sez = value; } }
    public string Exp_Sez { get { return _Exp_Sez; } set { _Exp_Sez = value; } }


    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    private string _SCREEN_ID, _PAGE_READ, _PAGE_WRITE, _PAGE_MODIFY, _PAGE_DELETE;
    public string SCREEN_ID { get { return _SCREEN_ID; } set { _SCREEN_ID = value; } }
    public string PAGE_READ { get { return _PAGE_READ; } set { _PAGE_READ = value; } }
    public string PAGE_WRITE { get { return _PAGE_WRITE; } set { _PAGE_WRITE = value; } }
    public string PAGE_MODIFY { get { return _PAGE_MODIFY; } set { _PAGE_MODIFY = value; } }
    public string PAGE_DELETE { get { return _PAGE_DELETE; } set { _PAGE_DELETE = value; } }
    public string IMP_EXP_MASTER_yn { get { return _IMP_EXP_MASTER_yn; } set { _IMP_EXP_MASTER_yn = value; } }
    public string SUPPLIER_MASTER_yn { get { return _SUPPLIER_MASTER_yn; } set { _SUPPLIER_MASTER_yn = value; } }
    public string BUYER_MASTER_yn { get { return _BUYER_MASTER_yn; } set { _BUYER_MASTER_yn = value; } }
    public string CONSIGNEE_MASTER_yn { get { return _CONSIGNEE_MASTER_yn; } set { _CONSIGNEE_MASTER_yn = value; } }
    public string ADCODE_MASTER_yn { get { return _ADCODE_MASTER_yn; } set { _ADCODE_MASTER_yn = value; } }
    public string THIRDPARTY_MASTER_yn { get { return _THIRDPARTY_MASTER_yn; } set { _THIRDPARTY_MASTER_yn = value; } }


    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }

    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }

    public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
    public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
    public string IEC_NAME { get { return _IEC_NAME; } set { _IEC_NAME = value; } }
    public string ID { get { return _ID; } set { _ID = value; } }


    public int Update_Id = 0, USER_COUNT = 0;

    #region User_Creation Private_Attributes
    private string _IMPORT_SUBMISSION, _IMPORT_STATEMENTS, _IMPORT_BE_ENTRY, _IMPORT_JOB_DUBLICATE, _EXPORT_SUBMIISSION, _EXPORT_JOB_DUBLICATE, _EXPORT_STATEMENTS
                  , _USER_CREATION_ID, _COMPANY_ID, _USER_BRANCHID, _TYPE, _COMPANY_LICENSE, _CLIENT_NAME, _NAME, _USER_NAME, _PWD, _EMAIL_ID, _MOBILE_NO, _EMPLOYEE_ID
                  , _USER_STATUS, _BRANCH, _CLIENT_MASTER, _SUPPLIER_MASTER, _CONSIGNEE_MASTER, _EXCHANGE_MASTER, _ADCODE_MASTER, _IMPORT_EXPORT_PRODUCT, _IMPORT_JOB
                  , _EXPORT_JOB, _SUBMISSION, _STATEMENTS, _ADMIN_ID, _DATE_TIME, _STATUS, _SUBSCRIBE, _WITHIN_NETWORK, _Ename, _flag
                  , _Access_Screen_Id,
                   _GENERAL_IMPORTER_NAME, _GENERAL_IEC_NO, _GENERAL_AD_CODE, _GENERAL_ADDRESS, _GENERAL_COUNTRY_ORIGIN,
                  _GENERAL_COUNTRY_SHIPMENT, _GENERAL_PORT_ORIGIN, _GENERAL_PORT_SHIPMENT, _GENERAL_STATE_CODE, _GENERAL_REGISTRATION_NO, _GENERAL_BRANCH_SL_NO, _GENERAL_STATE_NAME,
                   _IGM_NO, _IGM_DATE, _FLIGHT_VESSEL_DATE, _MAWB_BL_NO, _MAWB_MBL_DATE, _PACKAGES, _MARKS_NOS, _IGM_GROSS_WEIGHT, _IGM_PACKAGE_TYPE, _IGM_GROSS_WEIGHT_TYPE,
         _EXPORT_GENERAL_EXPORTER_NAME,
         _EXPORT_GENERAL_IEC_NO, _EXPORT_GENERAL_BRANCH_SL_NO, _EXPORT_GENERAL_ADDRESS, _EXPORT_GENERAL_PIN, _EXPORT_GENERAL_GSTN_ID, _EXPORT_GENERAL_GSTN_TYPE,
         _EXPORT_GENERAL_TYPE_OF_EXPORTER, _EXPORT_GENERAL_COUNTRY_DISCHARGE, _EXPORT_GENERAL_PORT_DISCHARGE, _EXPORT_GENERAL_COUNTRY_FINAL_DESTINATION,
         _EXPORT_GENERAL_PORT_FINAL_DESTINATION, _EXPORT_GENERAL_STATE_OF_EXPORT, _EXPORT_GENERAL_CONSIGNEE_NAME, _EXPORT_GENERAL_AD_CODE, _EXPORT_GENERAL_CONSIGNEE_ADDRESS, _EXPORT_GENERAL_CONSIGNEE_COUNTRY;



    private string
    _ACTION_USER_NAME,
    _ACTION_BRANCH,
    _GENERAL_JOB_EDIT,
    _GENERAL_CONSIGNEE_ADD_EDIT,
    _INVOICE_BUYER_ADD_EDIT,
    _ITEM_PMV_EDIT,
    _ITEM_TAXABLE_IGST_DECIMAL_POINT,
    _ITEM_DBK_AUTO_TAB_OPEN,
    _ITEM_DBK_POPUP_RI_OPEN,
    _CHKLIST_LICENSE_DESC,
    _CHKLIST_IGST_BASED_ON_FOB_VALUE,
    _ICEGATE_ID;

    private string _ITEM_ADDL_DUTY_IMPORTS, _CHKLIST_MANUF, _CHKLIST_SELLER, _FF_STMT_TEXT, _FF_FTA_EXBOND, _CHKLIST_GENERAL, _ITEM_DEFAULT_IGST_EXCMPN_NOTN, _GENERAL_DESC_SAME_AS_ITEM_DESC, _IGST_EXEMPTION_NOTN_AS_LICENSE_NOTN, _FF_ALLOW_WITHOUT_REBOND_NOTN,_GENERAL_USER_WISE_MILESTONE;


    public string ACTION_USER_NAME { get { return _ACTION_USER_NAME; } set { _ACTION_USER_NAME = value; } }
    public string ACTION_BRANCH { get { return _ACTION_BRANCH; } set { _ACTION_BRANCH = value; } }
    public string GENERAL_JOB_EDIT { get { return _GENERAL_JOB_EDIT; } set { _GENERAL_JOB_EDIT = value; } }
    public string GENERAL_CONSIGNEE_ADD_EDIT { get { return _GENERAL_CONSIGNEE_ADD_EDIT; } set { _GENERAL_CONSIGNEE_ADD_EDIT = value; } }
    public string INVOICE_BUYER_ADD_EDIT { get { return _INVOICE_BUYER_ADD_EDIT; } set { _INVOICE_BUYER_ADD_EDIT = value; } }
    public string ITEM_PMV_EDIT { get { return _ITEM_PMV_EDIT; } set { _ITEM_PMV_EDIT = value; } }
    public string ITEM_TAXABLE_IGST_DECIMAL_POINT { get { return _ITEM_TAXABLE_IGST_DECIMAL_POINT; } set { _ITEM_TAXABLE_IGST_DECIMAL_POINT = value; } }
    public string ITEM_DBK_AUTO_TAB_OPEN { get { return _ITEM_DBK_AUTO_TAB_OPEN; } set { _ITEM_DBK_AUTO_TAB_OPEN = value; } }
    public string ITEM_DBK_POPUP_RI_OPEN { get { return _ITEM_DBK_POPUP_RI_OPEN; } set { _ITEM_DBK_POPUP_RI_OPEN = value; } }
    public string CHKLIST_LICENSE_DESC { get { return _CHKLIST_LICENSE_DESC; } set { _CHKLIST_LICENSE_DESC = value; } }
    public string CHKLIST_IGST_BASED_ON_FOB_VALUE { get { return _CHKLIST_IGST_BASED_ON_FOB_VALUE; } set { _CHKLIST_IGST_BASED_ON_FOB_VALUE = value; } }

    public string ITEM_ADDL_DUTY_IMPORTS { get { return _ITEM_ADDL_DUTY_IMPORTS; } set { _ITEM_ADDL_DUTY_IMPORTS = value; } }
    public string CHKLIST_MANUF { get { return _CHKLIST_MANUF; } set { _CHKLIST_MANUF = value; } }
    public string CHKLIST_SELLER { get { return _CHKLIST_SELLER; } set { _CHKLIST_SELLER = value; } }
    public string FF_STMT_TEXT { get { return _FF_STMT_TEXT; } set { _FF_STMT_TEXT = value; } }
    public string FF_FTA_EXBOND { get { return _FF_FTA_EXBOND; } set { _FF_FTA_EXBOND = value; } }
    public string CHKLIST_GENERAL { get { return _CHKLIST_GENERAL; } set { _CHKLIST_GENERAL = value; } }
    public string ICEGATE_ID { get { return _ICEGATE_ID; } set { _ICEGATE_ID = value; } }
    public string ITEM_DEFAULT_IGST_EXCMPN_NOTN { get { return _ITEM_DEFAULT_IGST_EXCMPN_NOTN; } set { _ITEM_DEFAULT_IGST_EXCMPN_NOTN = value; } }
    //
    public string GENERAL_DESC_SAME_AS_ITEM_DESC { get { return _GENERAL_DESC_SAME_AS_ITEM_DESC; } set { _GENERAL_DESC_SAME_AS_ITEM_DESC = value; } }
    public string IGST_EXEMPTION_NOTN_AS_LICENSE_NOTN { get { return _IGST_EXEMPTION_NOTN_AS_LICENSE_NOTN; } set { _IGST_EXEMPTION_NOTN_AS_LICENSE_NOTN = value; } }

    public string FF_ALLOW_WITHOUT_REBOND_NOTN { get { return _FF_ALLOW_WITHOUT_REBOND_NOTN; } set { _FF_ALLOW_WITHOUT_REBOND_NOTN = value; } }

    public string GENERAL_USER_WISE_MILESTONE { get { return _GENERAL_USER_WISE_MILESTONE; } set { _GENERAL_USER_WISE_MILESTONE = value; } }
    //
    public string GENERAL_IMPORTER_NAME { get { return _GENERAL_IMPORTER_NAME; } set { _GENERAL_IMPORTER_NAME = value; } }
    public string GENERAL_IEC_NO { get { return _GENERAL_IEC_NO; } set { _GENERAL_IEC_NO = value; } }
    public string GENERAL_AD_CODE
    {
        get { return _GENERAL_AD_CODE; }
        set { _GENERAL_AD_CODE = value; }
    }

    public string GENERAL_ADDRESS
    {
        get { return _GENERAL_ADDRESS; }
        set { _GENERAL_ADDRESS = value; }
    }

    public string GENERAL_COUNTRY_ORIGIN
    {
        get { return _GENERAL_COUNTRY_ORIGIN; }
        set { _GENERAL_COUNTRY_ORIGIN = value; }
    }

    public string GENERAL_COUNTRY_SHIPMENT
    {
        get { return _GENERAL_COUNTRY_SHIPMENT; }
        set { _GENERAL_COUNTRY_SHIPMENT = value; }
    }

    public string GENERAL_PORT_ORIGIN
    {
        get { return _GENERAL_PORT_ORIGIN; }
        set { _GENERAL_PORT_ORIGIN = value; }
    }
    public string GENERAL_PORT_SHIPMENT
    {
        get { return _GENERAL_PORT_SHIPMENT; }
        set { _GENERAL_PORT_SHIPMENT = value; }
    }
    public string GENERAL_STATE_CODE
    {
        get { return _GENERAL_STATE_CODE; }
        set { _GENERAL_STATE_CODE = value; }
    }
    public string GENERAL_REGISTRATION_NO
    {
        get { return _GENERAL_REGISTRATION_NO; }
        set { _GENERAL_REGISTRATION_NO = value; }
    }

    public string GENERAL_BRANCH_SL_NO
    {
        get { return _GENERAL_BRANCH_SL_NO; }
        set { _GENERAL_BRANCH_SL_NO = value; }
    }

    public string GENERAL_STATE_NAME
    {
        get { return _GENERAL_STATE_NAME; }
        set { _GENERAL_STATE_NAME = value; }
    }

    public string IGM_NO
    {
        get { return _IGM_NO; }
        set { _IGM_NO = value; }
    }
    public string IGM_DATE
    {
        get { return _IGM_DATE; }
        set { _IGM_DATE = value; }
    }
    public string MAWB_BL_NO
    {
        get { return _MAWB_BL_NO; }
        set { _MAWB_BL_NO = value; }
    }

    public string FLIGHT_VESSEL_DATE
    {
        get { return _FLIGHT_VESSEL_DATE; }
        set { _FLIGHT_VESSEL_DATE = value; }
    }

    public string MAWB_MBL_DATE
    {
        get { return _MAWB_MBL_DATE; }
        set { _MAWB_MBL_DATE = value; }
    }
    public string PACKAGES
    {
        get { return _PACKAGES; }
        set { _PACKAGES = value; }
    }
    public string MARKS_NOS
    {
        get { return _MARKS_NOS; }
        set { _MARKS_NOS = value; }
    }

    public string IGM_GROSS_WEIGHT
    {
        get { return _IGM_GROSS_WEIGHT; }
        set { _IGM_GROSS_WEIGHT = value; }
    }
    public string IGM_PACKAGE_TYPE
    {
        get { return _IGM_PACKAGE_TYPE; }
        set { _IGM_PACKAGE_TYPE = value; }
    }

    public string IGM_GROSS_WEIGHT_TYPE
    {
        get { return _IGM_GROSS_WEIGHT_TYPE; }
        set { _IGM_GROSS_WEIGHT_TYPE = value; }
    }


    public string EXPORT_GENERAL_EXPORTER_NAME
    {
        get { return _EXPORT_GENERAL_EXPORTER_NAME; }
        set { _EXPORT_GENERAL_EXPORTER_NAME = value; }
    }


    public string EXPORT_GENERAL_IEC_NO
    {
        get { return _EXPORT_GENERAL_IEC_NO; }
        set { _EXPORT_GENERAL_IEC_NO = value; }
    }


    public string EXPORT_GENERAL_BRANCH_SL_NO
    {
        get { return _EXPORT_GENERAL_BRANCH_SL_NO; }
        set { _EXPORT_GENERAL_BRANCH_SL_NO = value; }
    }


    public string EXPORT_GENERAL_ADDRESS
    {
        get { return _EXPORT_GENERAL_ADDRESS; }
        set { _EXPORT_GENERAL_ADDRESS = value; }
    }

    public string EXPORT_GENERAL_PIN
    {
        get { return _EXPORT_GENERAL_PIN; }
        set { _EXPORT_GENERAL_PIN = value; }
    }


    public string EXPORT_GENERAL_GSTN_ID
    {
        get { return _EXPORT_GENERAL_GSTN_ID; }
        set { _EXPORT_GENERAL_GSTN_ID = value; }
    }


    public string EXPORT_GENERAL_GSTN_TYPE
    {
        get { return _EXPORT_GENERAL_GSTN_TYPE; }
        set { _EXPORT_GENERAL_GSTN_TYPE = value; }
    }


    public string EXPORT_GENERAL_TYPE_OF_EXPORTER
    {
        get { return _EXPORT_GENERAL_TYPE_OF_EXPORTER; }
        set { _EXPORT_GENERAL_TYPE_OF_EXPORTER = value; }
    }


    public string EXPORT_GENERAL_COUNTRY_DISCHARGE
    {
        get { return _EXPORT_GENERAL_COUNTRY_DISCHARGE; }
        set { _EXPORT_GENERAL_COUNTRY_DISCHARGE = value; }
    }


    public string EXPORT_GENERAL_PORT_DISCHARGE
    {
        get { return _EXPORT_GENERAL_PORT_DISCHARGE; }
        set { _EXPORT_GENERAL_PORT_DISCHARGE = value; }
    }


    public string EXPORT_GENERAL_COUNTRY_FINAL_DESTINATION
    {
        get { return _EXPORT_GENERAL_COUNTRY_FINAL_DESTINATION; }
        set { _EXPORT_GENERAL_COUNTRY_FINAL_DESTINATION = value; }
    }


    public string EXPORT_GENERAL_PORT_FINAL_DESTINATION
    {
        get { return _EXPORT_GENERAL_PORT_FINAL_DESTINATION; }
        set { _EXPORT_GENERAL_PORT_FINAL_DESTINATION = value; }
    }


    public string EXPORT_GENERAL_STATE_OF_EXPORT
    {
        get { return _EXPORT_GENERAL_STATE_OF_EXPORT; }
        set { _EXPORT_GENERAL_STATE_OF_EXPORT = value; }
    }


    public string EXPORT_GENERAL_CONSIGNEE_NAME
    {
        get { return _EXPORT_GENERAL_CONSIGNEE_NAME; }
        set { _EXPORT_GENERAL_CONSIGNEE_NAME = value; }
    }


    public string EXPORT_GENERAL_AD_CODE
    {
        get { return _EXPORT_GENERAL_AD_CODE; }
        set { _EXPORT_GENERAL_AD_CODE = value; }
    }


    public string EXPORT_GENERAL_CONSIGNEE_ADDRESS
    {
        get { return _EXPORT_GENERAL_CONSIGNEE_ADDRESS; }
        set { _EXPORT_GENERAL_CONSIGNEE_ADDRESS = value; }
    }


    public string EXPORT_GENERAL_CONSIGNEE_COUNTRY
    {
        get { return _EXPORT_GENERAL_CONSIGNEE_COUNTRY; }
        set { _EXPORT_GENERAL_CONSIGNEE_COUNTRY = value; }
    }




    #endregion

    #region User_Creation Public_Attributes


    public string USER_CREATION_ID { get { return _USER_CREATION_ID; } set { _USER_CREATION_ID = value; } }

    public string COMPANY_LICENSE { get { return _COMPANY_LICENSE; } set { _COMPANY_LICENSE = value; } }
    public string CLIENT_NAME { get { return _CLIENT_NAME; } set { _CLIENT_NAME = value; } }

    public string NAME { get { return _NAME; } set { _NAME = value; } }
    public string USER_NAME { get { return _USER_NAME; } set { _USER_NAME = value; } }
    public string PWD { get { return _PWD; } set { _PWD = value; } }

    public string EMAIL_ID { get { return _EMAIL_ID; } set { _EMAIL_ID = value; } }
    public string MOBILE_NO { get { return _MOBILE_NO; } set { _MOBILE_NO = value; } }
    public string EMPLOYEE_ID { get { return _EMPLOYEE_ID; } set { _EMPLOYEE_ID = value; } }
    public string USER_STATUS { get { return _USER_STATUS; } set { _USER_STATUS = value; } }
    public string BRANCH { get { return _BRANCH; } set { _BRANCH = value; } }
    public string CLIENT_MASTER { get { return _CLIENT_MASTER; } set { _CLIENT_MASTER = value; } }
    public string SUPPLIER_MASTER { get { return _SUPPLIER_MASTER; } set { _SUPPLIER_MASTER = value; } }
    public string CONSIGNEE_MASTER { get { return _CONSIGNEE_MASTER; } set { _CONSIGNEE_MASTER = value; } }

    public string EXCHANGE_MASTER { get { return _EXCHANGE_MASTER; } set { _EXCHANGE_MASTER = value; } }
    public string ADCODE_MASTER { get { return _ADCODE_MASTER; } set { _ADCODE_MASTER = value; } }

    public string IMPORT_EXPORT_PRODUCT { get { return _IMPORT_EXPORT_PRODUCT; } set { _IMPORT_EXPORT_PRODUCT = value; } }
    public string IMPORT_JOB { get { return _IMPORT_JOB; } set { _IMPORT_JOB = value; } }

    public string IMPORT_SUBMISSION { get { return _IMPORT_SUBMISSION; } set { _IMPORT_SUBMISSION = value; } }
    public string IMPORT_STATEMENTS { get { return _IMPORT_STATEMENTS; } set { _IMPORT_STATEMENTS = value; } }
    public string IMPORT_BE_ENTRY { get { return _IMPORT_BE_ENTRY; } set { _IMPORT_BE_ENTRY = value; } }
    public string IMPORT_JOB_DUBLICATE { get { return _IMPORT_JOB_DUBLICATE; } set { _IMPORT_JOB_DUBLICATE = value; } }

    public string EXPORT_JOB { get { return _EXPORT_JOB; } set { _EXPORT_JOB = value; } }
    public string EXPORT_SUBMIISSION { get { return _EXPORT_SUBMIISSION; } set { _EXPORT_SUBMIISSION = value; } }
    public string EXPORT_JOB_DUBLICATE { get { return _EXPORT_JOB_DUBLICATE; } set { _EXPORT_JOB_DUBLICATE = value; } }
    public string EXPORT_STATEMENTS { get { return _EXPORT_STATEMENTS; } set { _EXPORT_STATEMENTS = value; } }

    public string ADMIN_ID { get { return _ADMIN_ID; } set { _ADMIN_ID = value; } }
    public string SUBSCRIBE { get { return _SUBSCRIBE; } set { _SUBSCRIBE = value; } }

    public string WITHIN_NETWORK { get { return _WITHIN_NETWORK; } set { _WITHIN_NETWORK = value; } }

    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string COMPANY_ID { get { return _COMPANY_ID; } set { _COMPANY_ID = value; } }
    public string TYPE { get { return _TYPE; } set { _TYPE = value; } }
    public string USER_BRANCHID { get { return _USER_BRANCHID; } set { _USER_BRANCHID = value; } }

    public string Access_Screen_Id { get { return _Access_Screen_Id; } set { _Access_Screen_Id = value; } }

    public int result = 0;

    #endregion

    private string _JOB_TYPE, _USER_RIGHTS_ID;
    public string JOB_TYPE { get { return _JOB_TYPE; } set { _JOB_TYPE = value; } }
    public string USER_RIGHTS_ID { get { return _USER_RIGHTS_ID; } set { _USER_RIGHTS_ID = value; } }
    public string Error_msg;

    public void RetrieveAll_User_Screen_Rights_Details(int screen_id)
    {
        ds = (DataSet)HttpContext.Current.Session["USER_DETAILS_DS"];
        if (ds != null)
        {
            DataView view1 = ds.Tables[1].DefaultView;
            string COMPANY_ID, USER_CREATION_ID, BRANCH;
            COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
            USER_CREATION_ID = HttpContext.Current.Session["USER_CREATION_ID"].ToString();
            BRANCH = HttpContext.Current.Session["currentbranch"].ToString();


            view1.RowFilter = "BRANCH = '" + BRANCH + "' and " + "COMPANY_ID = " + COMPANY_ID + " and " + "USER_CREATION_ID = " + USER_CREATION_ID + " and " + "SCREEN_ID = " + screen_id + "";
            // and " + "BRANCH = " + BRANCH;
            DataTable table1 = view1.ToTable();
            DataSet dt_UserRights = new DataSet();
            dt_UserRights.Tables.Add(table1);
            if (dt_UserRights.Tables[0].Rows.Count > 0)
            {
                PAGE_READ = dt_UserRights.Tables[0].Rows[0]["PAGE_READ"].ToString();
                PAGE_WRITE = dt_UserRights.Tables[0].Rows[0]["PAGE_WRITE"].ToString();
                PAGE_MODIFY = dt_UserRights.Tables[0].Rows[0]["PAGE_MODIFY"].ToString();
                PAGE_DELETE = dt_UserRights.Tables[0].Rows[0]["PAGE_DELETE"].ToString();

            }
        }
    }


    public void RetrieveAll_User_Screen_Rights_Details_USERWISE_IEC_settings(int screen_id)
    {
        ds = (DataSet)HttpContext.Current.Session["USER_DETAILS_DS"];
        if (ds != null)
        {
            DataView view1 = ds.Tables[1].DefaultView;
            // DataSet dt_UserRights = new DataSet();

            string COMPANY_ID, USER_CREATION_ID, BRANCH;
            COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
            USER_CREATION_ID = HttpContext.Current.Session["USER_CREATION_ID"].ToString();
            BRANCH = HttpContext.Current.Session["currentbranch"].ToString();

            view1.RowFilter = "BRANCH = '" + BRANCH + "' and " + "COMPANY_ID = " + COMPANY_ID + " and " + "USER_CREATION_ID = " + USER_CREATION_ID + " and " + "SCREEN_ID = " + 1 + "";
            DataTable tbl_Imp_Exp_Mster = view1.ToTable();

            if (tbl_Imp_Exp_Mster.Rows.Count > 0)
            {
                IMP_EXP_MASTER_yn = tbl_Imp_Exp_Mster.Rows[0]["PAGE_READ"].ToString();
            }

            view1.RowFilter = "BRANCH = '" + BRANCH + "' and " + "COMPANY_ID = " + COMPANY_ID + " and " + "USER_CREATION_ID = " + USER_CREATION_ID + " and " + "SCREEN_ID = " + 2 + "";
            DataTable tbl_sup_Mster = view1.ToTable();

            if (tbl_sup_Mster.Rows.Count > 0)
            {
                SUPPLIER_MASTER_yn = tbl_sup_Mster.Rows[0]["PAGE_READ"].ToString();
            }

            view1.RowFilter = "BRANCH = '" + BRANCH + "' and " + "COMPANY_ID = " + COMPANY_ID + " and " + "USER_CREATION_ID = " + USER_CREATION_ID + " and " + "SCREEN_ID = " + 3 + "";
            DataTable tbl_Consignee_Mster = view1.ToTable();

            if (tbl_Consignee_Mster.Rows.Count > 0)
            {
                CONSIGNEE_MASTER_yn = tbl_Consignee_Mster.Rows[0]["PAGE_READ"].ToString();
            }

            view1.RowFilter = "BRANCH = '" + BRANCH + "' and " + "COMPANY_ID = " + COMPANY_ID + " and " + "USER_CREATION_ID = " + USER_CREATION_ID + " and " + "SCREEN_ID = " + 4 + "";
            DataTable tbl_Adcode_Mster = view1.ToTable();

            if (tbl_Adcode_Mster.Rows.Count > 0)
            {
                ADCODE_MASTER_yn = tbl_Adcode_Mster.Rows[0]["PAGE_READ"].ToString();
            }

            view1.RowFilter = "BRANCH = '" + BRANCH + "' and " + "COMPANY_ID = " + COMPANY_ID + " and " + "USER_CREATION_ID = " + USER_CREATION_ID + " and " + "SCREEN_ID = " + 36 + "";
            DataTable tbl_ThirdParty_Mster = view1.ToTable();

            if (tbl_ThirdParty_Mster.Rows.Count > 0)
            {
                THIRDPARTY_MASTER_yn = tbl_ThirdParty_Mster.Rows[0]["PAGE_READ"].ToString();
            }


            view1.RowFilter = "BRANCH = '" + BRANCH + "' and " + "COMPANY_ID = " + COMPANY_ID + " and " + "USER_CREATION_ID = " + USER_CREATION_ID + " and " + "SCREEN_ID = " + screen_id + "";
            // and " + "BRANCH = " + BRANCH;
            DataTable table1 = view1.ToTable();
            DataSet dt_UserRights = new DataSet();
            dt_UserRights.Tables.Add(table1);
            if (dt_UserRights.Tables[0].Rows.Count > 0)
            {
                PAGE_READ = dt_UserRights.Tables[0].Rows[0]["PAGE_READ"].ToString();
                PAGE_WRITE = dt_UserRights.Tables[0].Rows[0]["PAGE_WRITE"].ToString();
                PAGE_MODIFY = dt_UserRights.Tables[0].Rows[0]["PAGE_MODIFY"].ToString();
                PAGE_DELETE = dt_UserRights.Tables[0].Rows[0]["PAGE_DELETE"].ToString();

            }
        }
    }


    #region User_Screen
    public DataSet RetrieveAll_User_Screen_Details()
    {

        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@Mflag", flag);


            param[1] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[1].Direction = ParameterDirection.Output;
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;
            param[3] = new SqlParameter("@JOB_TYPE", JOB_TYPE);


            if (flag == "select_JobType")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "USER_SCREEN_SEARCH_SELECT", param);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);

            }


        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }
    #endregion
    #region User_Creation
    public DataSet User_Creation_Insert_update(string currentcomp_db)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@USER_CREATION_ID", USER_CREATION_ID);
            param[1] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[2] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);
            param[3] = new SqlParameter("@NAME", NAME);
            param[4] = new SqlParameter("@USER_NAME", USER_NAME);
            param[5] = new SqlParameter("@PWD", PWD);
            param[6] = new SqlParameter("@EMAIL_ID", EMAIL_ID);
            param[7] = new SqlParameter("@MOBILE_NO", MOBILE_NO);
            param[8] = new SqlParameter("@EMPLOYEE_ID", EMPLOYEE_ID);
            param[9] = new SqlParameter("@USER_STATUS", USER_STATUS);
            param[10] = new SqlParameter("@TYPE", TYPE);
            param[25] = new SqlParameter("@ADMIN_ID", ADMIN_ID);
            param[32] = new SqlParameter("@SUBSCRIBE", SUBSCRIBE);
            param[33] = new SqlParameter("@WITHIN_NETWORK", WITHIN_NETWORK);

            param[35] = new SqlParameter("@IMPORT", Import);
            param[36] = new SqlParameter("@EXPORT", Export);
            param[37] = new SqlParameter("@BILLING", Billing);
            param[38] = new SqlParameter("@ACCOUNTS", Acc);
            param[39] = new SqlParameter("@IMP_SEZ", Imp_Sez);
            param[40] = new SqlParameter("@EXP_SEZ", Exp_Sez);

            param[26] = new SqlParameter("@Mflag", flag);
            param[27] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[27].Direction = ParameterDirection.Output;
            param[28] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[28].Direction = ParameterDirection.Output;
            param[29] = new SqlParameter("@Update_Id", SqlDbType.NVarChar, 1000);
            param[29].Direction = ParameterDirection.Output;

            param[30] = new SqlParameter("@NO_OF_USERS", HttpContext.Current.Session["NO_OF_USERS"].ToString());
            param[31] = new SqlParameter("@User_Count", SqlDbType.NVarChar, 1000);
            param[31].Direction = ParameterDirection.Output;
            if (flag == "select_SYSADMIN")
            {
                ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "SP_USER_CREATION_INSERT_UPDATE", param);
                string err = param[28].Value.ToString();

            }
            else
            {
                SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "SP_USER_CREATION_INSERT_UPDATE", param);
            }
            USER_COUNT = Convert.ToInt32(param[31].Value.ToString());

            if (flag == "S")
            {
                result = Convert.ToInt32(param[27].Value.ToString());

                Update_Id = Convert.ToInt32(param[29].Value.ToString());
                if (Update_Id != 0)
                {
                    HttpContext.Current.Session.Remove("USER_CREATION_ID");
                    HttpContext.Current.Session["USER_CREATION_ID"] = Update_Id;
                }
            }
            else
                result = Convert.ToInt32(param[27].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_User_Details()
    {

        try
        {


            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@USER_CREATION_ID", USER_CREATION_ID);

            param[1] = new SqlParameter("@COMPANY_ID", COMPANY_ID);

            //param[2] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);

            param[3] = new SqlParameter("@NAME", NAME);

            param[12] = new SqlParameter("@USER_NAME", USER_NAME);

            param[13] = new SqlParameter("@EMPLOYEE_ID", EMPLOYEE_ID);

            param[4] = new SqlParameter("@MOBILE_NO", MOBILE_NO);

            param[5] = new SqlParameter("@ename", Ename);

            param[6] = new SqlParameter("@TYPE", TYPE);


            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);

            param[10] = new SqlParameter("@maximumRows", maximumRows);

            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            string a = HttpContext.Current.Session["currentcomp_db"].ToString();
            if (Ename == "delete" || Ename == "Change_Theme")
            {

                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_USER_CREATION_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());


            }
            else if (Ename == "select_con")
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_USER_CREATION_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[11].Value.ToString());

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
                //string err = param[8].Value.ToString();
            }
            else if (Ename == "select_Id")
            {

                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_USER_CREATION_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[7].Value.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
                //string err = param[8].Value.ToString();
            }
            else if (Ename == "select_SYSADMIN")
            {

                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_USER_CREATION_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[7].Value.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
                //string err = param[8].Value.ToString();
            }


        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }
    public DataSet RetrieveAll_AdminUser_Details(string currentcomp_db)
    {

        try
        {


            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@USER_CREATION_ID", USER_CREATION_ID);

            param[1] = new SqlParameter("@COMPANY_ID", COMPANY_ID);

            //param[2] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);

            param[3] = new SqlParameter("@NAME", NAME);

            param[12] = new SqlParameter("@USER_NAME", USER_NAME);

            param[13] = new SqlParameter("@EMPLOYEE_ID", EMPLOYEE_ID);

            param[4] = new SqlParameter("@MOBILE_NO", MOBILE_NO);

            param[5] = new SqlParameter("@ename", Ename);

            param[6] = new SqlParameter("@TYPE", TYPE);


            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);

            param[10] = new SqlParameter("@maximumRows", maximumRows);

            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            string a = HttpContext.Current.Session["currentcomp_db"].ToString();
            if (Ename == "delete" || Ename == "Change_Theme")
            {

                SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "SP_USER_CREATION_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());


            }
            else if (Ename == "select_con")
            {

                ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "SP_USER_CREATION_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[11].Value.ToString());

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
                //string err = param[8].Value.ToString();
            }
            else if (Ename == "select_Id")
            {

                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "SP_USER_CREATION_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[7].Value.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
                //string err = param[8].Value.ToString();
            }
            else if (Ename == "select_SYSADMIN")
            {

                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "SP_USER_CREATION_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[7].Value.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);
                //string err = param[8].Value.ToString();
            }


        }
        catch (Exception ex)
        {
            if (Ename == "select_SYSADMIN")
            {
                if (ex.Message == "Could not find stored procedure 'SP_USER_CREATION_SEARCH_SELECT'" || ex.Message.Contains("The login failed"))
                {
                    Error_msg = "Y";
                }
            }
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }
    #endregion
    #region User_Branch

    public DataSet User_Branch_Insert_update(string currentcomp_db)
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@USER_CREATION_ID", USER_CREATION_ID);
            param[1] = new SqlParameter("@COMPANY_ID", COMPANY_ID);

            param[2] = new SqlParameter("@BRANCH", BRANCH);

            param[3] = new SqlParameter("@USER_BRANCHID", USER_BRANCHID);


            param[4] = new SqlParameter("@Mflag", flag);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@Update_Id", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;


            ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "SP_USER_BRANCH_INSERT_UPDATE", param);
            string err = param[6].Value.ToString();

            if (flag == "S")
            {
                result = Convert.ToInt32(param[5].Value.ToString());

                Update_Id = Convert.ToInt32(param[7].Value.ToString());
            }
            else
                result = Convert.ToInt32(param[5].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Branch_Details(string currentcomp_db)
    {

        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@USER_CREATION_ID", USER_CREATION_ID);
            param[1] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[2] = new SqlParameter("@BRANCH", BRANCH);
            param[3] = new SqlParameter("@USER_BRANCHID", USER_BRANCHID);
            param[4] = new SqlParameter("@Mflag", flag);
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@Update_Id", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            if (flag == "Select_Permission_Branch_Details" || flag == "Select_Branch_Details")
            {

                ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "SP_USER_BRANCH_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[5].Value.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);
                }
                else
                    ds.Tables.Add(dt);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    #endregion

    public DataSet User_Rights_Insert_update(string currentcomp_db)
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@USER_CREATION_ID", USER_CREATION_ID);
            param[1] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[2] = new SqlParameter("@USER_RIGHTS_ID", USER_RIGHTS_ID);
            param[3] = new SqlParameter("@BRANCH", BRANCH);

            param[4] = new SqlParameter("@SCREEN_ID", SCREEN_ID);
            param[5] = new SqlParameter("@PAGE_READ", PAGE_READ);
            param[6] = new SqlParameter("@PAGE_WRITE", PAGE_WRITE);
            param[7] = new SqlParameter("@PAGE_MODIFY", PAGE_MODIFY);
            param[8] = new SqlParameter("@PAGE_DELETE", PAGE_DELETE);
            param[9] = new SqlParameter("@Mflag", flag);

            param[10] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@Update_Id", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;


            param[13] = new SqlParameter("@Access_Screen_Id", Access_Screen_Id);

            ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "USER_RIGHTS_INSERT_UPDATE", param);
            string err = param[11].Value.ToString();

            if (flag == "S")
            {
                result = Convert.ToInt32(param[10].Value.ToString());

                Update_Id = Convert.ToInt32(param[12].Value.ToString());
            }
            else
                result = Convert.ToInt32(param[10].Value.ToString());

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return ds;

    }

    public DataSet RetrieveAll_User_Rights_Details(string currentcomp_db)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[18];
            param[0] = new SqlParameter("@USER_CREATION_ID", USER_CREATION_ID);
            param[1] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[2] = new SqlParameter("@USER_RIGHTS_ID", USER_RIGHTS_ID);
            param[3] = new SqlParameter("@BRANCH", BRANCH);
            param[4] = new SqlParameter("@SCREEN_ID", SCREEN_ID);
            param[5] = new SqlParameter("@PAGE_READ", PAGE_READ);
            param[6] = new SqlParameter("@PAGE_WRITE", PAGE_WRITE);
            param[7] = new SqlParameter("@PAGE_MODIFY", PAGE_MODIFY);
            param[8] = new SqlParameter("@PAGE_DELETE", PAGE_DELETE);
            param[9] = new SqlParameter("@Mflag", flag);

            param[10] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@Update_Id", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;


            param[13] = new SqlParameter("@Access_Screen_Id", Access_Screen_Id);


            if (flag == "Select_BranchWise_Rights_Details")
            {

                ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "USER_RIGHTS_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[10].Value.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                        ds.Tables.Add(dt);

                }
                else
                    ds.Tables.Add(dt);

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Import_Job_Initialization_Insert_update(string currentcomp_db)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@USER_ID", USER_ID);
            param[2] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[3] = new SqlParameter("@YEAR", YEAR);
            param[4] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[8] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[5] = new SqlParameter("@Mflag", flag);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "IMPORT_JOB_INITIALIZATION_INSERT_UPDATE", param);
            string err = param[7].Value.ToString();

            if (flag == "S")
            {
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
                result = Convert.ToInt32(param[6].Value.ToString());

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }


        return ds;

    }

    public DataSet Export_Job_Initialization_Insert_update(string currentcomp_db)
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@USER_ID", USER_ID);
            param[2] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[3] = new SqlParameter("@YEAR", YEAR);
            param[4] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[8] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[5] = new SqlParameter("@Mflag", flag);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "EXPORT_JOB_INITIALIZATION_INSERT_UPDATE", param);
            string err = param[7].Value.ToString();

            if (flag == "S")
            {
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
                result = Convert.ToInt32(param[6].Value.ToString());

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet User_Exp_Settings_Insert_update(string currentcomp_db)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@USER_CREATION_ID", USER_CREATION_ID);
            param[1] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[2] = new SqlParameter("@ACTION_BRANCH", ACTION_BRANCH);
            param[3] = new SqlParameter("@GENERAL_JOB_EDIT", GENERAL_JOB_EDIT);
            param[4] = new SqlParameter("@GENERAL_CONSIGNEE_ADD_EDIT", GENERAL_CONSIGNEE_ADD_EDIT);
            param[5] = new SqlParameter("@INVOICE_BUYER_ADD_EDIT", INVOICE_BUYER_ADD_EDIT);
            param[6] = new SqlParameter("@ITEM_PMV_EDIT", ITEM_PMV_EDIT);
            param[7] = new SqlParameter("@ITEM_TAXABLE_IGST_DECIMAL_POINT", ITEM_TAXABLE_IGST_DECIMAL_POINT);
            param[8] = new SqlParameter("@ITEM_DBK_AUTO_TAB_OPEN", ITEM_DBK_AUTO_TAB_OPEN);
            param[9] = new SqlParameter("@ITEM_DBK_POPUP_RI_OPEN", ITEM_DBK_POPUP_RI_OPEN);
            param[10] = new SqlParameter("@CHKLIST_LICENSE_DESC", CHKLIST_LICENSE_DESC);
            param[11] = new SqlParameter("@CHKLIST_IGST_BASED_ON_FOB_VALUE", CHKLIST_IGST_BASED_ON_FOB_VALUE);

            param[16] = new SqlParameter("@USER_ID", USER_ID);
            param[12] = new SqlParameter("@Mflag", flag);
            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@Update_Id", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "SP_USER_EXP_ACTION_SETTINGS_INSERT_UPDATE", param);
            if (flag == "S")
            {
                result = Convert.ToInt32(param[13].Value.ToString());
                Update_Id = Convert.ToInt32(param[15].Value.ToString());
            }
            else
                result = Convert.ToInt32(param[13].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return ds;
    }

    public DataSet RetrieveAll_User_Exp_Settings(string currentcomp_db)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@USER_CREATION_ID", HttpContext.Current.Session["USER_CREATION_ID"].ToString());
            param[1] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());
            param[2] = new SqlParameter("@ACTION_BRANCH", ACTION_BRANCH);
            param[3] = new SqlParameter("@USER_NAME", Connection.Current_User());
            param[4] = new SqlParameter("@Mflag", flag);
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;


            ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "SP_USER_EXP_SETTINGS_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[5].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);
            }
            else
                ds.Tables.Add(dt);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_User_ICEGATE_ID_Settings(string currentcomp_db)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@USER_CREATION_ID", USER_CREATION_ID);
            param[1] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());
            param[2] = new SqlParameter("@ACTION_BRANCH", ACTION_BRANCH);
            param[3] = new SqlParameter("@USER_NAME", Connection.Current_User());
            param[4] = new SqlParameter("@ICEGATE_ID", ICEGATE_ID);
            param[5] = new SqlParameter("@Mflag", flag);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;


            ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "SP_USER_ICEGATE_ID_SETTINGS_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[6].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt.Clone());
            }
            else
                ds.Tables.Add(dt.Clone());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet User_Imp_Settings_Insert_update(string currentcomp_db)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@USER_CREATION_ID", USER_CREATION_ID);
            param[1] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[2] = new SqlParameter("@ACTION_BRANCH", ACTION_BRANCH);
            param[3] = new SqlParameter("@GENERAL_JOB_EDIT", GENERAL_JOB_EDIT);
            param[4] = new SqlParameter("@ITEM_ADDL_DUTY_IMPORTS", ITEM_ADDL_DUTY_IMPORTS);
            param[5] = new SqlParameter("@CHKLIST_MANUF", CHKLIST_MANUF);
            param[6] = new SqlParameter("@CHKLIST_SELLER", CHKLIST_SELLER);
            param[7] = new SqlParameter("@FF_STMT_TEXT", FF_STMT_TEXT);
            param[8] = new SqlParameter("@FF_FTA_EXBOND", FF_FTA_EXBOND);
            param[9] = new SqlParameter("@CHKLIST_GENERAL", CHKLIST_GENERAL);
            param[10] = new SqlParameter("@ITEM_DEFAULT_IGST_EXCMPN_NOTN", ITEM_DEFAULT_IGST_EXCMPN_NOTN);
            param[11] = new SqlParameter("@GENERAL_DESC_SAME_AS_ITEM_DESC", GENERAL_DESC_SAME_AS_ITEM_DESC);
            param[17] = new SqlParameter("@IGST_EXEMPTION_NOTN_AS_LICENSE_NOTN", IGST_EXEMPTION_NOTN_AS_LICENSE_NOTN);
            param[18] = new SqlParameter("@FF_ALLOW_WITHOUT_REBOND_NOTN", FF_ALLOW_WITHOUT_REBOND_NOTN);
            param[19] = new SqlParameter("@GENERAL_USER_WISE_MILESTONE", GENERAL_USER_WISE_MILESTONE);
            param[16] = new SqlParameter("@USER_ID", USER_ID);
            param[12] = new SqlParameter("@Mflag", flag);
            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@Update_Id", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "SP_USER_IMP_ACTION_SETTINGS_INSERT_UPDATE", param);
            if (flag == "S")
            {
                result = Convert.ToInt32(param[13].Value.ToString());
                Update_Id = Convert.ToInt32(param[15].Value.ToString());
            }
            else
                result = Convert.ToInt32(param[13].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return ds;
    }

    public DataSet RetrieveAll_User_Imp_Settings(string currentcomp_db)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@USER_CREATION_ID", HttpContext.Current.Session["USER_CREATION_ID"].ToString());
            param[1] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());
            param[2] = new SqlParameter("@ACTION_BRANCH", ACTION_BRANCH);
            param[3] = new SqlParameter("@USER_NAME", Connection.Current_User());
            param[4] = new SqlParameter("@Mflag", flag);
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;


            ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "SP_USER_IMP_SETTINGS_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[5].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);
            }
            else
                ds.Tables.Add(dt);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet Imp_Col_Edit_Insert_update(string currentcomp_db)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[31];

            param[0] = new SqlParameter("@USER_CREATION_ID", Convert.ToInt64(USER_CREATION_ID));
            param[1] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[2] = new SqlParameter("@ACTION_BRANCH", ACTION_BRANCH);
            param[3] = new SqlParameter("@GENERAL_IMPORTER_NAME", GENERAL_IMPORTER_NAME);
            param[4] = new SqlParameter("@GENERAL_IEC_NO", GENERAL_IEC_NO);
            param[5] = new SqlParameter("@GENERAL_AD_CODE", GENERAL_AD_CODE);
            param[6] = new SqlParameter("@GENERAL_ADDRESS", GENERAL_ADDRESS);
            param[7] = new SqlParameter("@GENERAL_COUNTRY_ORIGIN", GENERAL_COUNTRY_ORIGIN);
            param[8] = new SqlParameter("@GENERAL_COUNTRY_SHIPMENT", GENERAL_COUNTRY_SHIPMENT);
            param[9] = new SqlParameter("@GENERAL_PORT_ORIGIN", GENERAL_PORT_ORIGIN);
            param[10] = new SqlParameter("@GENERAL_PORT_SHIPMENT", GENERAL_PORT_SHIPMENT);
            param[11] = new SqlParameter("@GENERAL_STATE_CODE", GENERAL_STATE_CODE);
            param[12] = new SqlParameter("@GENERAL_REGISTRATION_NO", GENERAL_REGISTRATION_NO);
            param[13] = new SqlParameter("@GENERAL_BRANCH_SL_NO", GENERAL_BRANCH_SL_NO);
            param[14] = new SqlParameter("@GENERAL_STATE_NAME", GENERAL_STATE_NAME);
            param[15] = new SqlParameter("@IGM_NO", IGM_NO);
            param[16] = new SqlParameter("@IGM_DATE", IGM_DATE);
            param[17] = new SqlParameter("@FLIGHT_VESSEL_DATE", FLIGHT_VESSEL_DATE);
            param[18] = new SqlParameter("@MAWB_BL_NO", MAWB_BL_NO);
            param[19] = new SqlParameter("@MAWB_MBL_DATE", MAWB_MBL_DATE);
            param[20] = new SqlParameter("@PACKAGES", PACKAGES);
            param[21] = new SqlParameter("@MARKS_NOS", MARKS_NOS);
            param[22] = new SqlParameter("@IGM_GROSS_WEIGHT", IGM_GROSS_WEIGHT);
            param[23] = new SqlParameter("@IGM_PACKAGE_TYPE", IGM_PACKAGE_TYPE);
            param[24] = new SqlParameter("@IGM_GROSS_WEIGHT_TYPE", IGM_GROSS_WEIGHT_TYPE);
            param[25] = new SqlParameter("@USER_ID", USER_ID);
            param[26] = new SqlParameter("@Mflag", flag);
            param[27] = new SqlParameter("@MStatus", SqlDbType.Int);
            param[27].Direction = ParameterDirection.Output;
            param[28] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[28].Direction = ParameterDirection.Output;
            param[29] = new SqlParameter("@Update_Id", SqlDbType.BigInt);
            param[29].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("SP_IMP_COL_MANDATORY_SETTINGS_INSERT_UPDATE", param);


            if (flag == "S" || flag == "S_IGM")
            {
                result = Convert.ToInt32(param[27].Value.ToString());
                Update_Id = Convert.ToInt32(param[29].Value.ToString());
            }
            else
            {
                result = Convert.ToInt32(param[27].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }



    public DataSet Exp_Col_Edit_Insert_update(string currentcomp_db)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@USER_CREATION_ID", Convert.ToInt64(USER_CREATION_ID));
            param[1] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[2] = new SqlParameter("@ACTION_BRANCH", ACTION_BRANCH);

            param[3] = new SqlParameter("@EXPORT_GENERAL_EXPORTER_NAME", EXPORT_GENERAL_EXPORTER_NAME);
            param[4] = new SqlParameter("@EXPORT_GENERAL_IEC_NO", EXPORT_GENERAL_IEC_NO);
            param[5] = new SqlParameter("@EXPORT_GENERAL_BRANCH_SL_NO", EXPORT_GENERAL_BRANCH_SL_NO);
            param[6] = new SqlParameter("@EXPORT_GENERAL_ADDRESS", EXPORT_GENERAL_ADDRESS);
            param[7] = new SqlParameter("@EXPORT_GENERAL_PIN", EXPORT_GENERAL_PIN);
            param[8] = new SqlParameter("@EXPORT_GENERAL_GSTN_ID", EXPORT_GENERAL_GSTN_ID);
            param[9] = new SqlParameter("@EXPORT_GENERAL_GSTN_TYPE", EXPORT_GENERAL_GSTN_TYPE);
            param[10] = new SqlParameter("@EXPORT_GENERAL_TYPE_OF_EXPORTER", EXPORT_GENERAL_TYPE_OF_EXPORTER);
            param[11] = new SqlParameter("@EXPORT_GENERAL_COUNTRY_DISCHARGE", EXPORT_GENERAL_COUNTRY_DISCHARGE);
            param[12] = new SqlParameter("@EXPORT_GENERAL_PORT_DISCHARGE", EXPORT_GENERAL_PORT_DISCHARGE);
            param[13] = new SqlParameter("@EXPORT_GENERAL_COUNTRY_FINAL_DESTINATION", EXPORT_GENERAL_COUNTRY_FINAL_DESTINATION);
            param[14] = new SqlParameter("@EXPORT_GENERAL_PORT_FINAL_DESTINATION", EXPORT_GENERAL_PORT_FINAL_DESTINATION);
            param[15] = new SqlParameter("@EXPORT_GENERAL_STATE_OF_EXPORT", EXPORT_GENERAL_STATE_OF_EXPORT);
            param[16] = new SqlParameter("@EXPORT_GENERAL_CONSIGNEE_NAME", EXPORT_GENERAL_CONSIGNEE_NAME);
            param[17] = new SqlParameter("@EXPORT_GENERAL_AD_CODE", EXPORT_GENERAL_AD_CODE);
            param[18] = new SqlParameter("@EXPORT_GENERAL_CONSIGNEE_ADDRESS", EXPORT_GENERAL_CONSIGNEE_ADDRESS);
            param[19] = new SqlParameter("@EXPORT_GENERAL_CONSIGNEE_COUNTRY", EXPORT_GENERAL_CONSIGNEE_COUNTRY);

            param[20] = new SqlParameter("@USER_ID", USER_ID);
            param[21] = new SqlParameter("@Mflag", flag);

            param[22] = new SqlParameter("@MStatus", SqlDbType.Int);
            param[22].Direction = ParameterDirection.Output;

            param[23] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[23].Direction = ParameterDirection.Output;

            param[24] = new SqlParameter("@Update_Id", SqlDbType.BigInt);
            param[24].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(
                     currentcomp_db,
                     CommandType.StoredProcedure,
                     "SP_EXP_COL_MANDATORY_SETTINGS_INSERT_UPDATE",
                     param);

            if (flag == "S_EXP")
            {
                result = Convert.ToInt32(param[22].Value.ToString());
                Update_Id = Convert.ToInt32(param[24].Value.ToString());
            }
            else
            {
                result = Convert.ToInt32(param[22].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public DataSet RetrieveAll_User_IEC_Access_Settings(string currentcomp_db)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@USER_CREATION_ID", USER_CREATION_ID);
            param[2] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[3] = new SqlParameter("@TYPE", TYPE);
            param[4] = new SqlParameter("@ACTION_BRANCH", ACTION_BRANCH);
            param[5] = new SqlParameter("@USER_NAME", Connection.Current_User());
            param[6] = new SqlParameter("@Mflag", flag);

            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;


            ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "SP_USER_IEC_ACCESS_SETTINGS_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[7].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);
            }
            else
                ds.Tables.Add(dt);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet User_Imp_IEC_Access_Settings_Insert_update(string currentcomp_db)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@USER_CREATION_ID", USER_CREATION_ID);
            param[2] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[3] = new SqlParameter("@ACTION_BRANCH", ACTION_BRANCH);
            param[4] = new SqlParameter("@IEC_NO", IEC_NO);
            param[5] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
            param[6] = new SqlParameter("@IEC_NAME", IEC_NAME);
            param[7] = new SqlParameter("@TYPE", TYPE);

            param[16] = new SqlParameter("@USER_ID", USER_ID);
            param[12] = new SqlParameter("@Mflag", flag);
            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@Update_Id", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(currentcomp_db, CommandType.StoredProcedure, "SP_USER_IMP_EXP_IEC_ACCESS_INSERT_UPDATE", param);
            if (flag == "S")
            {
                result = Convert.ToInt32(param[13].Value.ToString());
                Update_Id = Convert.ToInt32(param[15].Value.ToString());
            }
            else
                result = Convert.ToInt32(param[13].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return ds;
    }





}