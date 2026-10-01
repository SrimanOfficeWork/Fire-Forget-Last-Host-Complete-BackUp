
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

/// <summary>
/// Summary description for adminmaster
/// </summary>
public class adminmaster
{
   
    public DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    public string result1;
    public int UPDATE_ID = 0;

    private string _databasename;
    private string _path;
    private string _filename;

    private string _startRowIndex;

    private string _maximumRows;
    private string _totalRows;
    
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    DataSet dtuser = new DataSet();
    ErrorLogs er = new ErrorLogs();
    private string _Ecategoryid;
    private string _Ecategoryno;
    private string _Ename;
    private string _Ecategoryname;

    private string _Ecessid;
    private string _Ecess_slno;
    private string _Ecess_notnno;

    private string _Eceth_id;
    private string _Eceth_code;
    private string _Eceth_description;
   

    private string _Ecountry_id;
    private string _Ecountry_code;
    private string _Ecountry_name;

    private string _Ecth_id;
    private string _Ecth_code;
    private string _Ecth_description;

    private string _Ecustom_id;
    private string _Ecustom_code;
    private string _Ecustom_name;
    

    private string _Edepb_id;
    private string _Edepb_group_code;
    private string _Edepb_item_code;

    private string _Edrawback_id;
    private string _Edrawback_slno;
    private string _Edrawback_description;

    private string _Elocation_id;
    private string _Elocation_code;
    private string _Elocation_name;

    private string _ENotification_Excise_id;
    private string _ENotification_Excise_notn;
    private string _ENotification_Excise_notn_slno;

    private string _ENotification_Customs_id;
    private string _ENotification_Customs_code;
    private string _ENotification_Customs_name, _ENotification_Customs_Type;

    private string _EPackage_id;
    private string _EPackage_code;
    private string _EPackage_name;

    private string _EAirline_id;
    private string _EAirline_code;
    private string _EAirline_name;

    private string _EPort_id;
    private string _EPort_code_air;
    private string _EPort_code_sea;
    private string _EPort_name;

    private string _ERSP_id;
    private string _ERSP_cthno;
    private string _ERSP_description;
    private string _ERSP_Notn;
    private string _ERSP_Notn_SlNo;


    private string _EState_id;
    private string _EState_code;
    private string _EState_name;
    private string _EDistrict_name;

    private string _EUnit_id;
    private string _EUnit_code;
    private string _EUnit_name;

    private string _Eexchange_id;
    private string _Eexchange_effect_dt_from;
    private string _Eexchange_effect_dt_to;
    private string _Eexchange_nont_no;
    private string _Eexchange_notn_date;

    //RODTEP
    private string _E_RODTEP_ID;
    private string _E_RODTEP_TARIFF;

    private string _ERODTEP_id;
    private string _ERODTEP_TARIFF;
    private string _ERODTEP_DESC;
    private string _ERODTEP_Headerno;

    public string Qf_xml;
    public string Priority_Type;

    //---------EXCHANGEMASTER--------  


    private string _EXCHANGE_ID;
    private string _EXCHANGE_EFFECT_DT_FROM;
    private string _EXCHANGE_EFFECT_DT_TO;
    private string _EXCHANGE_NONT_NO;
    private string _EXCHANGE_NOTN_DATE;
    private string _EXCHANGE_CUR_CODE;
    private string _EXCHANGE_NAME;
    private string _EXCHANGE_PER_UNIT;
    private string _EXCHANGE_RATE_IMPORT;
    private string _EXCHANGE_RATE_EXPORT;
    private string _EXCHANGE_S_OR_N;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _EWorking_Period;

    //---------EXCHANGEMASTER-------- 

    private string _permission;
    private string _name;
    private string _companyname;
    private string _Ecategoryremarks;
    private string _flag;


    private string _SCHEME_NOTN;
    private string _SCHEME_IMPORT_CODE;
    private string _PRODUCT_CETH;
    private string _STR_ID,_STR_SRNO;
    private string _Invoice_Currency;

    public string Name;


    //---------ANTIDUMPING_MASTER--------------

    private string _ADD_NOTN;
    private string _ADD_SLNO;
    private string _ADD_CTH;
    private string _ADD_SUP_SLNO;

    #region Anti_Dumping Master

    private string _Antidumpting_id;
    private string _Antidumpting_Notn;
    private string _Antidumpting_desc;


    private string _Antidumpting_SLNO;
    private string _Antidumpting_CTH;
    private string _Antidumpting_SUPSLNO;

    #endregion




    //NOTIFICATION FTA MASTER

    private string _FTA_NOTN;
    private string _FTA_NOTN_SLNO;
    private string _FTA_COUNTRY;
    private string _FTA_REMARKS;
    private string _ID;
    public string FTA_NOTN { get { return _FTA_NOTN; } set { _FTA_NOTN = value; } }
    public string FTA_NOTN_SLNO { get { return _FTA_NOTN_SLNO; } set { _FTA_NOTN_SLNO = value; } }
    public string FTA_COUNTRY { get { return _FTA_COUNTRY; } set { _FTA_COUNTRY = value; } }
    public string FTA_REMARKS { get { return _FTA_REMARKS; } set { _FTA_REMARKS = value; } }
    public string ID { get { return _ID; } set { _ID = value; } }

    
    #region AIDC

    private string _AIDC_ID, _AIDC_RITC_NO, _AIDC_NOTN_NO, _AIDC_NOTN_SLNO, _AIDC_NOTN_RATE, _AIDC_DESCRIPTION, _AIDC_FLAG;
    public string AIDC_ID { get { return _AIDC_ID; } set { _AIDC_ID = value; } }
    public string AIDC_RITC_NO { get { return _AIDC_RITC_NO; } set { _AIDC_RITC_NO = value; } }
    public string AIDC_NOTN_NO { get { return _AIDC_NOTN_NO; } set { _AIDC_NOTN_NO = value; } }
    public string AIDC_NOTN_SLNO { get { return _AIDC_NOTN_SLNO; } set { _AIDC_NOTN_SLNO = value; } }
    public string AIDC_NOTN_RATE { get { return _AIDC_NOTN_RATE; } set { _AIDC_NOTN_RATE = value; } }
    public string AIDC_DESCRIPTION { get { return _AIDC_DESCRIPTION; } set { _AIDC_DESCRIPTION = value; } }
    public string AIDC_FLAG { get { return _AIDC_FLAG; } set { _AIDC_FLAG = value; } }

    #endregion AIDC

    #region error_code_master
    private string _MESG_ID, _ERR_CD, _ERR_DESC, _ERROR, _MODULE_IDMESG_TYP, _F6;
    public string MESG_ID { get { return _MESG_ID; } set { _MESG_ID = value; } }
    public string ERR_CD { get { return _ERR_CD; } set { _ERR_CD = value; } }
    public string ERR_DESC { get { return _ERR_DESC; } set { _ERR_DESC = value; } }
    public string ERROR { get { return _ERROR; } set { _ERROR = value; } }
    public string MODULE_IDMESG_TYP { get { return _MODULE_IDMESG_TYP; } set { _MODULE_IDMESG_TYP = value; } }
    public string F6 { get { return _F6; } set { _F6 = value; } }

    #endregion error_code_master

    private string _SW_id;
    private string _SW_FromCTH;
    private string _SW_AgencyCode;
    private string _CTH_STATUS;


    private string _CH_id;
    private string _CH_Code;
    private string _CH_Name;
    private string _CH_Area;

    private string _EWarehouse_id;
    private string _EWarehouse_code;
    private string _EWarehouse_address;
    private string _EWarehouse_name;

    // ROSL
    private string _EROSL_id;
    private string _EROSL_slno;
    private string _EROSL_description;
    private string _EROSL_Headerno;
    //ROSL


    //NOTIFICATION_UPDATION_MASTER
    private string _ENOTIFICATIONF_ID;
    private string _ENOTIFICATION_NUMBER;
    private string _ENOTIFICATION_DATEOFISSUE;
    private string _ENOTIFICATION_EFFECTIVEDATE;
    private string _ENOTIFICATION_DESCRIPTION;
    private string _EFILE_ATTACHMENT;
    private string _Efromdate;
    private string _Etodate;

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    public string ENOTIFICATIONF_ID { get { return _ENOTIFICATIONF_ID; } set { _ENOTIFICATIONF_ID = value; } }

    public string ENOTIFICATION_NUMBER { get { return _ENOTIFICATION_NUMBER; } set { _ENOTIFICATION_NUMBER = value; } }
    public string ENOTIFICATION_DATEOFISSUE { get { return _ENOTIFICATION_DATEOFISSUE; } set { _ENOTIFICATION_DATEOFISSUE = value; } }

    public string ENOTIFICATION_EFFECTIVEDATE { get { return _ENOTIFICATION_EFFECTIVEDATE; } set { _ENOTIFICATION_EFFECTIVEDATE = value; } }
    public string ENOTIFICATION_DESCRIPTION { get { return _ENOTIFICATION_DESCRIPTION; } set { _ENOTIFICATION_DESCRIPTION = value; } }
    public string EFILE_ATTACHMENT { get { return _EFILE_ATTACHMENT; } set { _EFILE_ATTACHMENT = value; } }

    public string Efromdate { get { return _Efromdate; } set { _Efromdate = value; } }
    public string Etodate { get { return _Etodate; } set { _Etodate = value; } }

    //NOTIFICATION_IGST_LEVY1_CTH_MASTER


    private string _ENOTIFICATION_IGST_LEVY_ID;
    private string _ENOTIFICATION_LEVY_NOTN;
    private string _ENOTIFICATION_LEVY_NOTN_SL;
    private string _ENOTIFICATION_CUSTOMS_CTH;


    public string ENOTIFICATION_IGST_LEVY_ID { get { return _ENOTIFICATION_IGST_LEVY_ID; } set { _ENOTIFICATION_IGST_LEVY_ID = value; } }
    public string ENOTIFICATION_LEVY_NOTN { get { return _ENOTIFICATION_LEVY_NOTN; } set { _ENOTIFICATION_LEVY_NOTN = value; } }
    public string ENOTIFICATION_LEVY_NOTN_SL { get { return _ENOTIFICATION_LEVY_NOTN_SL; } set { _ENOTIFICATION_LEVY_NOTN_SL = value; } }
    public string ENOTIFICATION_CUSTOMS_CTH { get { return _ENOTIFICATION_CUSTOMS_CTH; } set { _ENOTIFICATION_CUSTOMS_CTH = value; } }


    //NOTIFICATION_IGST_LEVY2_CTH_MASTER


    private string _ENOTIFICATION_IGST_LEVY_CESS_ID;
    private string _ENOTIFICATION_LEVY_CESS_NOTN;
    private string _ENOTIFICATION_LEVY_CESS_NOTN_SL;
    private string _ENOTIFICATION_CUSTOMS_CESS_CTH;


    public string ENOTIFICATION_IGST_LEVY_CESS_ID { get { return _ENOTIFICATION_IGST_LEVY_CESS_ID; } set { _ENOTIFICATION_IGST_LEVY_CESS_ID = value; } }
    public string ENOTIFICATION_LEVY_CESS_NOTN { get { return _ENOTIFICATION_LEVY_CESS_NOTN; } set { _ENOTIFICATION_LEVY_CESS_NOTN = value; } }
    public string ENOTIFICATION_LEVY_CESS_NOTN_SL { get { return _ENOTIFICATION_LEVY_CESS_NOTN_SL; } set { _ENOTIFICATION_LEVY_CESS_NOTN_SL = value; } }
    public string ENOTIFICATION_CUSTOMS_CESS_CTH { get { return _ENOTIFICATION_CUSTOMS_CESS_CTH; } set { _ENOTIFICATION_CUSTOMS_CESS_CTH = value; } }

    private string _Eceth_remarks;
     public string Eceth_remarks { get { return _Eceth_remarks; } set { _Eceth_remarks = value; } }

     //------ SVB  Relation---------------
     private string _ESvbid;
     private string _ESvb_relation;
     private string _ESvbcustom_house;
     private string _EImpName;
     private string _ESupName;
     private string _EAssesableRate;

     public string ESvbid { get { return _ESvbid; } set { _ESvbid = value; } }
     public string ESvb_relation { get { return _ESvb_relation; } set { _ESvb_relation = value; } }
     public string ESvbcustom_house { get { return _ESvbcustom_house; } set { _ESvbcustom_house = value; } }
     public string EImpName { get { return _EImpName; } set { _EImpName = value; } }
     public string ESupName { get { return _ESupName; } set { _ESupName = value; } }
     public string EAssesableRate { get { return _EAssesableRate; } set { _EAssesableRate = value; } }

     //SCHEME_IMPORT

     private string _SCHEME_IMPORT_ID;
     private string _SCHEME_IMPORT_NAME;
     private string _SCHEME_NOTN_SLNO;
     private string _SCHEME_RATE;
     private string _SCHEME_NOTN_DATE;

     public string SCHEME_IMPORT_ID { get { return _SCHEME_IMPORT_ID; } set { _SCHEME_IMPORT_ID = value; } }
     public string SCHEME_IMPORT_NAME { get { return _SCHEME_IMPORT_NAME; } set { _SCHEME_IMPORT_NAME = value; } }
     public string SCHEME_NOTN_SLNO { get { return _SCHEME_NOTN_SLNO; } set { _SCHEME_NOTN_SLNO = value; } }
     public string SCHEME_RATE { get { return _SCHEME_RATE; } set { _SCHEME_RATE = value; } }
     public string SCHEME_NOTN_DATE { get { return _SCHEME_NOTN_DATE; } set { _SCHEME_NOTN_DATE = value; } }

     public string Xml_A;
     public int status;
     public string Update_Priority;




     //-----added for fromdate and todate search select// by pandiyan
     private string _fdate;
     private string _tdate;
     public string fdate { get { return _fdate; } set { _fdate = value; } }
     public string tdate { get { return _tdate; } set { _tdate = value; } }




     private string _INVOICE_NO;
     private string _JOB_TYPE;


     public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
     public string JOB_TYPE { get { return _JOB_TYPE; } set { _JOB_TYPE = value; } }





    #region Attributes
    public string Invoice_Currency { get { return _Invoice_Currency; } set { _Invoice_Currency = value; } }

    public string EWorking_Period { get { return _EWorking_Period; } set { _EWorking_Period = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }

    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
 
    public string Eexchange_id { get { return _Eexchange_id; } set { _Eexchange_id = value; } }
    public string Eexchange_effect_dt_from { get { return _Eexchange_effect_dt_from; } set { _Eexchange_effect_dt_from = value; } }
    public string Eexchange_effect_dt_to { get { return _Eexchange_effect_dt_to; } set { _Eexchange_effect_dt_to = value; } }
    public string Eexchange_nont_no { get { return _Eexchange_nont_no; } set { _Eexchange_nont_no = value; } }
    public string Eexchange_notn_date { get { return _Eexchange_notn_date; } set { _Eexchange_notn_date = value; } }

    public string ERODTEP_id
    {
        get { return _ERODTEP_id; }
        set { _ERODTEP_id = value; }
    }
    public string ERODTEP_TARIFF
    {
        get { return _ERODTEP_TARIFF; }
        set { _ERODTEP_TARIFF = value; }
    }


    public string ERODTEP_Headerno
    {
        get { return _ERODTEP_Headerno; }
        set { _ERODTEP_Headerno = value; }
    }

    public string ERODTEP_DESC
    {
        get { return _ERODTEP_DESC; }
        set { _ERODTEP_DESC = value; }
    }

    //---------EXCHANGEMASTER--------  


    public string EXCHANGE_ID { get { return _EXCHANGE_ID; } set { _EXCHANGE_ID = value; } }
    public string EXCHANGE_EFFECT_DT_FROM { get { return _EXCHANGE_EFFECT_DT_FROM; } set { _EXCHANGE_EFFECT_DT_FROM = value; } }
    public string EXCHANGE_EFFECT_DT_TO { get { return _EXCHANGE_EFFECT_DT_TO; } set { _EXCHANGE_EFFECT_DT_TO = value; } }
    public string EXCHANGE_NONT_NO { get { return _EXCHANGE_NONT_NO; } set { _EXCHANGE_NONT_NO = value; } }
    public string EXCHANGE_NOTN_DATE { get { return _EXCHANGE_NOTN_DATE; } set { _EXCHANGE_NOTN_DATE = value; } }
    public string EXCHANGE_CUR_CODE { get { return _EXCHANGE_CUR_CODE; } set { _EXCHANGE_CUR_CODE = value; } }
    public string EXCHANGE_NAME { get { return _EXCHANGE_NAME; } set { _EXCHANGE_NAME = value; } }
    public string EXCHANGE_PER_UNIT { get { return _EXCHANGE_PER_UNIT; } set { _EXCHANGE_PER_UNIT = value; } }
    public string EXCHANGE_RATE_IMPORT { get { return _EXCHANGE_RATE_IMPORT; } set { _EXCHANGE_RATE_IMPORT = value; } }
    public string EXCHANGE_RATE_EXPORT { get { return _EXCHANGE_RATE_EXPORT; } set { _EXCHANGE_RATE_EXPORT = value; } }
    public string EXCHANGE_S_OR_N { get { return _EXCHANGE_S_OR_N; } set { _EXCHANGE_S_OR_N = value; } }

    //---------EXCHANGEMASTER-------- 

    //--------ANTIDUMPING_MASTER----------

    public string ADD_NOTN { get { return _ADD_NOTN; } set { _ADD_NOTN = value; } }
    public string ADD_SLNO { get { return _ADD_SLNO; } set { _ADD_SLNO = value; } }
    public string ADD_CTH { get { return _ADD_CTH; } set { _ADD_CTH = value; } }
    public string ADD_SUP_SLNO { get { return _ADD_SUP_SLNO; } set { _ADD_SUP_SLNO = value; } }


    public string Antidumpting_id
    {
        get { return _Antidumpting_id; }
        set { _Antidumpting_id = value; }
    }
    public string Antidumpting_Notn
    {
        get { return _Antidumpting_Notn; }
        set { _Antidumpting_Notn = value; }
    }

    public string Antidumpting_desc
    {
        get { return _Antidumpting_desc; }
        set { _Antidumpting_desc = value; }

    }

    public string Antidumpting_SLNO
    {
        get { return _Antidumpting_SLNO; }
        set { _Antidumpting_SLNO = value; }

    }


    public string Antidumpting_CTH
    {
        get { return _Antidumpting_CTH; }
        set { _Antidumpting_CTH = value; }

    }

    public string Antidumpting_SUPSLNO
    {
        get { return _Antidumpting_SUPSLNO; }
        set { _Antidumpting_SUPSLNO = value; }

    }

    //-------------------------------------              

    public string SW_id
    {
        get { return _SW_id; }
        set { _SW_id = value; }
    }
    public string SW_FromCTH
    {
        get { return _SW_FromCTH; }
        set { _SW_FromCTH = value; }
    }

    public string SW_AgencyCode
    {
        get { return _SW_AgencyCode; }
        set { _SW_AgencyCode = value; }

    }

    public string CTH_STATUS
    {
        get { return _CTH_STATUS; }
        set { _CTH_STATUS = value; }

    }


    public string CH_id
    {
        get { return _CH_id; }
        set { _CH_id = value; }
    }
    public string CH_Code
    {
        get { return _CH_Code; }
        set { _CH_Code = value; }
    }

    public string CH_Name
    {
        get { return _CH_Name; }
        set { _CH_Name = value; }

    }


    public string CH_Area
    {
        get { return _CH_Area; }
        set { _CH_Area = value; }

    }


    // warehouse

    public string EWarehouse_id
    {
        get { return _EWarehouse_id; }
        set { _EWarehouse_id = value; }
    }
    public string EWarehouse_code
    {
        get { return _EWarehouse_code; }
        set { _EWarehouse_code = value; }
    }

    public string EWarehouse_name
    {
        get { return _EWarehouse_name; }
        set { _EWarehouse_name = value; }
    }


    public string EWarehouse_address
    {
        get { return _EWarehouse_address; }
        set { _EWarehouse_address = value; }
    }

    // warehouse

    // ROSL ATTRIBUTES

    public string EROSL_id
    {
        get { return _EROSL_id; }
        set { _EROSL_id = value; }
    }
    public string EROSL_slno
    {
        get { return _EROSL_slno; }
        set { _EROSL_slno = value; }
    }


    public string EROSL_Headerno
    {
        get { return _EROSL_Headerno; }
        set { _EROSL_Headerno = value; }
    }



    public string EROSL_description
    {
        get { return _EROSL_description; }
        set { _EROSL_description = value; }
    }

    //



    public string databasename
    {
        get { return _databasename; }
        set { _databasename = value; }
    }
    public string path
    {
        get { return _path; }
        set { _path = value; }
    }
    public string filename
    {
        get { return _filename; }
        set { _filename = value; }
    }

    public string SCHEME_NOTN
    {
        get { return _SCHEME_NOTN; }
        set { _SCHEME_NOTN=value; }
    }
    

    public string SCHEME_IMPORT_CODE
    {
        get { return _SCHEME_IMPORT_CODE; }
        set { _SCHEME_IMPORT_CODE = value; }
    }

    public string PRODUCT_CETH
    {
        get { return _PRODUCT_CETH; }
        set { _PRODUCT_CETH = value; }
    }

    

    public string Ecategoryid
    {
        get { return _Ecategoryid; }
        set { _Ecategoryid = value; }
    }

    public string Ecategoryno
    {
        get { return _Ecategoryno; }
        set { _Ecategoryno = value; }
    }
    public string Ecategoryremarks
    {
        get { return _Ecategoryremarks; }
        set { _Ecategoryremarks = value; }
    }   
    public string Ename
    {
        get { return _Ename; }
        set { _Ename = value; }
    }

    public string Ecategoryname
    {
        get { return _Ecategoryname; }
        set { _Ecategoryname = value; }
    }

    public string Ecessid
    {
        get { return _Ecessid; }
        set { _Ecessid = value; }
    }
    public string Ecess_slno
    {
        get { return _Ecess_slno; }
        set { _Ecess_slno = value; }
    }
    public string Ecess_notnno
    {
        get { return _Ecess_notnno; }
        set { _Ecess_notnno = value; }
    }

    public string Eceth_id
    {
        get { return _Eceth_id; }
        set { _Eceth_id = value; }
    }
    public string Eceth_code
    {
        get { return _Eceth_code; }
        set { _Eceth_code = value; }
    }
    public string Eceth_description
    {
        get { return _Eceth_description; }
        set { _Eceth_description = value; }
    }

    public string Ecountry_id
    {
        get { return _Ecountry_id; }
        set { _Ecountry_id = value; }
    }
    public string Ecountry_code
    {
        get { return _Ecountry_code; }
        set { _Ecountry_code = value; }
    }
    public string Ecountry_name
    {
        get { return _Ecountry_name; }
        set { _Ecountry_name = value; }
    }

    public string Ecth_id
    {
        get { return _Ecth_id; }
        set { _Ecth_id = value; }
    }
    public string Ecth_code
    {
        get { return _Ecth_code; }
        set { _Ecth_code = value; }
    }
    public string Ecth_description
    {
        get { return _Ecth_description; }
        set { _Ecth_description = value; }
    }

    public string Ecustom_id
    {
        get { return _Ecustom_id; }
        set { _Ecustom_id = value; }
    }
    public string Ecustom_code
    {
        get { return _Ecustom_code; }
        set { _Ecustom_code = value; }
    }
    public string Ecustom_name
    {
        get { return _Ecustom_name; }
        set { _Ecustom_name = value; }
    }

    public string Edepb_id
    {
        get { return _Edepb_id; }
        set { _Edepb_id = value; }
    }
    public string Edepb_group_code
    {
        get { return _Edepb_group_code; }
        set { _Edepb_group_code = value; }
    }
    public string Edepb_item_code
    {
        get { return _Edepb_item_code; }
        set { _Edepb_item_code = value; }
    }

    public string Edrawback_id
    {
        get { return _Edrawback_id; }
        set { _Edrawback_id = value; }
    }
    public string Edrawback_slno
    {
        get { return _Edrawback_slno; }
        set { _Edrawback_slno = value; }
    }
    public string Edrawback_description
    {
        get { return _Edrawback_description; }
        set { _Edrawback_description = value; }
    }

    public string Elocation_id
    {
        get { return _Elocation_id; }
        set { _Elocation_id = value; }
    }
    public string Elocation_code
    {
        get { return _Elocation_code; }
        set { _Elocation_code = value; }
    }
    public string Elocation_name
    {
        get { return _Elocation_name; }
        set { _Elocation_name = value; }
    }

    public string ENotification_Excise_id
    {
        get { return _ENotification_Excise_id; }
        set { _ENotification_Excise_id = value; }
    }
    public string ENotification_Excise_notn
    {
        get { return _ENotification_Excise_notn; }
        set { _ENotification_Excise_notn = value; }
    }
    public string ENotification_Excise_notn_slno
    {
        get { return _ENotification_Excise_notn_slno; }
        set { _ENotification_Excise_notn_slno = value; }
    }

    public string ENotification_Customs_id
    {
        get { return _ENotification_Customs_id; }
        set { _ENotification_Customs_id = value; }
    }
    public string ENotification_Customs_code
    {
        get { return _ENotification_Customs_code; }
        set { _ENotification_Customs_code = value; }
    }
    public string ENotification_Customs_name
    {
        get { return _ENotification_Customs_name; }
        set { _ENotification_Customs_name = value; }
    }
    public string ENotification_Customs_Type
    {
        get { return _ENotification_Customs_Type; }
        set { _ENotification_Customs_Type = value; }
    }

    public string EPackage_id
    {
        get { return _EPackage_id; }
        set { _EPackage_id = value; }
    }
    public string EPackage_code
    {
        get { return _EPackage_code; }
        set { _EPackage_code = value; }
    }
    public string EPackage_name
    {
        get { return _EPackage_name; }
        set { _EPackage_name = value; }
    }

    public string EAirline_id
    {
        get { return _EAirline_id; }
        set { _EAirline_id = value; }
    }
    public string EAirline_code
    {
        get { return _EAirline_code; }
        set { _EAirline_code = value; }
    }
    public string EAirline_name
    {
        get { return _EAirline_name; }
        set { _EAirline_name = value; }
    }



    public string EPort_id
    {
        get { return _EPort_id; }
        set { _EPort_id = value; }
    }
    public string EPort_code_air
    {
        get { return _EPort_code_air; }
        set { _EPort_code_air = value; }
    }
    public string EPort_code_sea
    {
        get { return _EPort_code_sea; }
        set { _EPort_code_sea = value; }
    }
    public string EPort_name
    {
        get { return _EPort_name; }
        set { _EPort_name = value; }
    }

    public string ERSP_id
    {
        get { return _ERSP_id; }
        set { _ERSP_id = value; }
    }
    public string ERSP_cthno
    {
        get { return _ERSP_cthno; }
        set { _ERSP_cthno = value; }
    }
    public string ERSP_description
    {
        get { return _ERSP_description; }
        set { _ERSP_description = value; }
    }
    public string ERSP_Notn
    {
        get { return _ERSP_Notn; }
        set { _ERSP_Notn = value; }
    }
    public string ERSP_Notn_SlNo
    {
        get { return _ERSP_Notn_SlNo; }
        set { _ERSP_Notn_SlNo = value; }
    }

    public string EState_id
    {
        get { return _EState_id; }
        set { _EState_id = value; }
    }
    public string EState_code
    {
        get { return _EState_code; }
        set { _EState_code = value; }
    }
    public string EState_name
    {
        get { return _EState_name; }
        set { _EState_name = value; }
    }
    public string EDistrict_name
    {
        get { return _EDistrict_name; }
        set { _EDistrict_name = value; }
    }

    public string EUnit_id
    {
        get { return _EUnit_id; }
        set { _EUnit_id = value; }
    }
    public string EUnit_code
    {
        get { return _EUnit_code; }
        set { _EUnit_code = value; }
    }
    public string EUnit_name
    {
        get { return _EUnit_name; }
        set { _EUnit_name = value; }
    }

    private string _BENEFICIARY_PARTY_NAME;
    private string _ISSUING_PARTY_NAME;
    private string _IMAGE_REF_NO;
    public string ISSUING_PARTY_NAME { get { return _ISSUING_PARTY_NAME; } set { _ISSUING_PARTY_NAME = value; } }
    public string BENEFICIARY_PARTY_NAME { get { return _BENEFICIARY_PARTY_NAME; } set { _BENEFICIARY_PARTY_NAME = value; } }
    public string IMAGE_REF_NO { get { return _IMAGE_REF_NO; } set { _IMAGE_REF_NO = value; } }

    private string permission
    {
        get { return _permission; }
        set { _permission = value; }
    }
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string STR_ID
    {
        get { return _STR_ID; }
        set { _STR_ID = value; }
    }
    public string STR_SRNO
    {
        get { return _STR_SRNO; }
        set { _STR_SRNO = value; }
    }
    private string companyname
    {
        get { return _companyname; }
        set { _companyname = value; }
    }

    public string E_RODTEP_ID
    {
        get { return _E_RODTEP_ID; }
        set { _E_RODTEP_ID = value; }
    }
    public string E_RODTEP_TARIFF
    {
        get { return _E_RODTEP_TARIFF; }
        set { _E_RODTEP_TARIFF = value; }
    }


    public int result = 0;
    public double  Total_Rows = 0;

    #endregion
    #region CETH_MASTER_PRIVATE_ATTRIBUTES
    private string _CETH_ID;
    private string _CETH_CODE;
    private string _CETH_DESCRIPTION;
    private string _CETH_RATE;
    private string _CETH_SPL_AMT;
    private string _CETH_SPL_UNIT;
    private string _CETH_HEALTH_CESS_H_RATE;
    private string _CETH_ADDITIONAL_CVD_S_RATE;
    private string _CETH_TTA_T_RATE;
    private string _CETH_SIA_I_RATE;
    private string _CETH_OTHER_X_RATE;
    private string _CETH_OTHER_X_REMARKS;
    #region CETH_MASTER_PUBLIC_ATTRIBUTES
    public string CETH_ID
    {
        get { return _CETH_ID; }
        set { _CETH_ID = value; }
    }
    public string CETH_CODE
    {
        get { return _CETH_CODE; }
        set { _CETH_ID = value; }
    }
    public string CETH_DESCRIPTION
    {
        get { return _CETH_DESCRIPTION; }
        set { _CETH_ID = value; }
    }
    public string CETH_RATE
    {
        get { return _CETH_RATE; }
        set { _CETH_ID = value; }
    }
    public string CETH_SPL_AMT
    {
        get { return _CETH_SPL_AMT; }
        set { _CETH_ID = value; }
    }
    public string CETH_SPL_UNIT
    {
        get { return _CETH_SPL_UNIT; }
        set { _CETH_ID = value; }
    }
    public string CETH_HEALTH_CESS_H_RATE
    {
        get { return _CETH_HEALTH_CESS_H_RATE; }
        set { _CETH_ID = value; }
    }
    public string CETH_ADDITIONAL_CVD_S_RATE
    {
        get { return _CETH_ADDITIONAL_CVD_S_RATE; }
        set { _CETH_ID = value; }
    }
    public string CETH_TTA_T_RATE
    {
        get { return _CETH_TTA_T_RATE; }
        set { _CETH_ID = value; }
    }
    public string CETH_SIA_I_RATE
    {
        get { return _CETH_SIA_I_RATE; }
        set { _CETH_ID = value; }
    }
    public string CETH_OTHER_X_RATE
    {
        get { return _CETH_OTHER_X_RATE; }
        set { _CETH_ID = value; }
    }
    public string CETH_OTHER_X_REMARKS
    {
        get { return _CETH_OTHER_X_REMARKS; }
        set { _CETH_ID = value; }
    }

    #endregion
    #endregion


    #region CESS_MASTER_ATTRIBUTES

    private string _CESS_ID;
    private string _CESS_SLNO;
    private string _CESS_NOTN_NO;
    private string _CESS_RITCNO;

    public string CESS_ID
    {
        get { return _CESS_ID; }
        set { _CESS_ID = value; }
    }
    public string CESS_SLNO
    {
        get { return _CESS_SLNO; }
        set { _CESS_SLNO = value; }
    }
    public string CESS_NOTN_NO
    {
        get { return _CESS_NOTN_NO; }
        set { _CESS_NOTN_NO = value; }
    }
    public string CESS_RITCNO
    {
        get { return _CESS_RITCNO; }
        set { _CESS_RITCNO = value; }
    }
    #endregion CESS_MASTER_ATTRIBUTES


    #region EXPORT_RITC_MASTER_ATTRIBUTES

    private string _ERITC_ID;
    private string _ERITC_CODE;
    private string _ERITC_DESCRIPTION;
   

    public string ERITC_ID
    {
        get { return _ERITC_ID; }
        set { _ERITC_ID = value; }
    }
    public string ERITC_CODE
    {
        get { return _ERITC_CODE; }
        set { _ERITC_CODE = value; }
    }
    public string ERITC_DESCRIPTION
    {
        get { return _ERITC_DESCRIPTION; }
        set { _ERITC_DESCRIPTION = value; }
    }

    #endregion EXPORT_RITC_MASTER_ATTRIBUTES
    
    #region ALL_NOTN_XML_CHECKLIST
    public string _xml_CTH, _xml_CETH, _xml_CUSTOMS_NOTN, _xml_IGST_LEVY, _xml_IGST_LEVY_EXCE, _xml_IGST_COMP_NOTN, _xml_IGST_COMP_EXEC, _xml_EXCISE_NOTN,
                  _xml_SCHEME_CODE_RATE, _xml_ANTI_DUMPING, _xml_Country, _xml_AIDC, _xml_SPL_AMT, C, _xml_SUPDOC_TYPE;

    public string xml_CTH { get { return _xml_CTH; } set { _xml_CTH = value; } }
    public string xml_CETH { get { return _xml_CETH; } set { _xml_CETH = value; } }
    public string xml_CUSTOMS_NOTN { get { return _xml_CUSTOMS_NOTN; } set { _xml_CUSTOMS_NOTN = value; } }
    public string xml_IGST_LEVY { get { return _xml_IGST_LEVY; } set { _xml_IGST_LEVY = value; } }
    public string xml_IGST_LEVY_EXCE { get { return _xml_IGST_LEVY_EXCE; } set { _xml_IGST_LEVY_EXCE = value; } }
    public string xml_IGST_COMP_NOTN { get { return _xml_IGST_COMP_NOTN; } set { _xml_IGST_COMP_NOTN = value; } }
    public string xml_IGST_COMP_EXEC { get { return _xml_IGST_COMP_EXEC; } set { _xml_IGST_COMP_EXEC = value; } }
    public string xml_EXCISE_NOTN { get { return _xml_EXCISE_NOTN; } set { _xml_EXCISE_NOTN = value; } }
    public string xml_SCHEME_CODE_RATE { get { return _xml_SCHEME_CODE_RATE; } set { _xml_SCHEME_CODE_RATE = value; } }
    public string xml_ANTI_DUMPING { get { return _xml_ANTI_DUMPING; } set { _xml_ANTI_DUMPING = value; } }
    public string xml_Country { get { return _xml_Country; } set { _xml_Country = value; } }
    public string xml_AIDC { get { return _xml_AIDC; } set { _xml_AIDC = value; } }
    public string xml_SPL_AMT { get { return _xml_SPL_AMT; } set { _xml_SPL_AMT = value; } }
    public string xml_SUPDOC_TYPE { get { return _xml_SUPDOC_TYPE; } set { _xml_SUPDOC_TYPE = value; } }



    
    #endregion ALL_NOTN_XML_CHECKLIST 

    #region Esanchit
    public string Esan_EmailID, Esan_Company, Esan_CustID, Esan_FileFormat, Esan_Trasaction, IRN_no, DRN_no;
    #endregion Esanchit

    #region dataset
    public DataSet RetrieveAll_Category_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CATEGORY_ID", Ecategoryid);
            param[1] = new SqlParameter("@CATEGORY_NO", Ecategoryno);

            param[2] = new SqlParameter("@CATEGORY_NAME", Ecategoryname);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);

            param[9] = new SqlParameter("@maximumRows", maximumRows);

            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CATEGORY_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CATEGORY_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[6].Value.ToString());
                //Total_Rows = Convert.ToInt32(param[10].Value.ToString());
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CATEGORY_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }

            else
            {
                //return SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CATEGORY_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CATEGORY_MASTER_SEARCH_SELECT", param);
                //Total_Rows = Convert.ToInt32(param[10].Value.ToString());
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
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


    public DataSet RetrieveAll_Cess_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CESS_ID", Ecessid);
            param[1] = new SqlParameter("@CESS_SLNO", Ecess_slno);

            param[2] = new SqlParameter("@CESS_NOTN_NO", Ecess_notnno);
            param[3] = new SqlParameter("@name", Ename);

            param[12] = new SqlParameter("@CESS_RITCNO", Ecess_notnno);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);

            param[9] = new SqlParameter("@maximumRows", maximumRows);

            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;


            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CESS_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CESS_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());

            }
            else if (Ename == "autoid")
            {
                //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CESS_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CESS_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }

            else
            {
                //return SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CESS_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CESS_MASTER_SEARCH_SELECT", param);
                //result = Convert.ToInt32(param[10].Value.ToString());
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());

            }
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

    //public DataSet RetrieveAll_Cess_master()
    //{
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        
    //        SqlParameter[] param = new SqlParameter[15];

    //        param[0] = new SqlParameter("@CESS_ID", Ecessid);
    //        param[1] = new SqlParameter("@CESS_SLNO", Ecess_slno);

    //        param[2] = new SqlParameter("@CESS_NOTN_NO", Ecess_notnno);
    //        param[3] = new SqlParameter("@name", Ename);


    //        param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

    //        param[6].Direction = ParameterDirection.Output;

    //        param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
    //        param[7].Direction = ParameterDirection.Output;
    //        param[8] = new SqlParameter("@startRowIndex", startRowIndex);

    //        param[9] = new SqlParameter("@maximumRows", maximumRows);

    //        param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
    //        param[10].Direction = ParameterDirection.Output;


    //        if (Ename == "delete")
    //        {
    //            //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CESS_MASTER", param);
    //            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CESS_MASTER_SEARCH_SELECT", param);

    //            result = Convert.ToInt32(param[6].Value.ToString());
    //            Total_Rows = Convert.ToDouble(param[10].Value.ToString());


    //        }
    //        else if (Ename == "autoid")
    //        {
    //            //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CESS_MASTER", param);
    //            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CESS_MASTER_SEARCH_SELECT", param);
               
    //            result = Convert.ToInt32(param[6].Value.ToString());



    //        }

    //        else
    //        {
    //           //return SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CESS_MASTER", param);
    //            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CESS_MASTER_SEARCH_SELECT", param);
    //            //result = Convert.ToInt32(param[10].Value.ToString());
    //            Total_Rows = Convert.ToDouble(param[10].Value.ToString());

              
    //        }
    //        if (ds.Tables.Count > 0)
    //        {
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //            }
    //            else
    //                ds.Tables.Add(dt);

    //        }
    //        else
    //            ds.Tables.Add(dt);
    //    }
    //    catch (Exception ex)
    //    {

    //        er.makeLog(ex.Message);
    //    }


    //    return ds;


    //}

    public DataSet RetrieveAll_CETH_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CETH_ID", Eceth_id);
            param[1] = new SqlParameter("@CETH_CODE", Eceth_code);

            param[2] = new SqlParameter("@CETH_DESCRIPTION", Eceth_description);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CETH_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CETH_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CETH_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CETH_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_Country_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@COUNTRY_ID", Ecountry_id);
            param[1] = new SqlParameter("@COUNTRY_CODE", Ecountry_code);

            param[2] = new SqlParameter("@COUNTRY_NAME", Ecountry_name);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_COUNTRY_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_COUNTRY_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_COUNTRY_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_COUNTRY_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
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


    public DataSet RetrieveAll_CTH_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CTH_ID", Ecth_id);
            param[1] = new SqlParameter("@CTH_CODE", Ecth_code);
            param[2] = new SqlParameter("@CTH_DESCRIPTION", Ecth_description);
            param[3] = new SqlParameter("@name", Ename);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CTH_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CTH_MASTER_SEARCH_SELECT", param);

                if (!String.IsNullOrEmpty(param[6].Value.ToString()))
                {
                    result = Convert.ToInt32(param[6].Value.ToString());
                }
                if (!String.IsNullOrEmpty(param[10].Value.ToString()))
                {
                    Total_Rows = Convert.ToDouble(param[10].Value.ToString());
                }
            }
            else if (Ename == "autoid")
            {
                //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CTH_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CTH_MASTER_SEARCH_SELECT", param);

                if (!String.IsNullOrEmpty(param[6].Value.ToString()))
                {
                    result = Convert.ToInt32(param[6].Value.ToString());
                }
            }
            else
            {
                //return SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CTH_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CTH_MASTER_SEARCH_SELECT", param);

                if (!String.IsNullOrEmpty(param[10].Value.ToString()))
                {
                    Total_Rows = Convert.ToDouble(param[10].Value.ToString());
                }
            }
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

    public DataSet RetrieveAll_EXPORT_RITC_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@RITC_CODE_ID", Ecth_id);
            param[1] = new SqlParameter("@RITC_CODE", Ecth_code);

            param[2] = new SqlParameter("@RITCCODE_ITEMDESC", Ecth_description);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "EXPORT_RITCCODE_MASTER_SEARCH_SELECT", param);

            Total_Rows = Convert.ToDouble(param[10].Value.ToString());

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

    public DataSet RetrieveAll_Custom_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CUSTOMS_ID", Ecustom_id);
            param[1] = new SqlParameter("@CUSTOMS_CODE", Ecustom_code);
            param[2] = new SqlParameter("@CUSTOMS_NAME", Ecustom_name);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CUSTOM_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CUSTOM_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CUSTOM_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CUSTOM_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_Customs_House()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CUSTOMHOUSE_CODE", Ecustom_code);
            param[1] = new SqlParameter("@CUSTOMHOUSE_NAME", Ecustom_name);
            param[2] = new SqlParameter("@CUSTOMHOUSE_CATEGORY", Ecategoryname);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
           
            //ds= SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CUSTOM_HOUSE", param);
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CUSTOM_HOUSE_SEARCH_SELECT", param);
          
            Total_Rows = Convert.ToDouble(param[10].Value.ToString());
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


    public DataSet RetrieveAll_Customs_House_Split()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CUSTOMHOUSE_CODE", Ecustom_code);
            param[1] = new SqlParameter("@CUSTOMHOUSE_NAME", Ecustom_name);
            param[2] = new SqlParameter("@CUSTOMHOUSE_CATEGORY", Ecategoryname);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            //ds= SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CUSTOM_HOUSE", param);
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CUSTOM_HOUSE", param);
            
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

    public DataSet RetrieveAll_Depb_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@DEPB_ID", Edepb_id);
            param[1] = new SqlParameter("@DEPB_GROUP_CODE", Edepb_group_code);

            param[2] = new SqlParameter("@DEPB_ITEM_CODE", Edepb_item_code);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DEPB_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DEPB_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DEPB_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DEPB_MASTER_SEARCH_SELECT", param);
               Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
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


    public DataSet Checklist_Drawback_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@DRAWBACK_ID", Edrawback_id);
            param[1] = new SqlParameter("@DRAWBACK_SLNO ", Edrawback_slno);
            param[2] = new SqlParameter("@DRAWBACK_DESCRIPTION", Edrawback_description);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            if (Ename == "select_checklist")
            {
                //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DRAWBACK_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DRAWBACK_MASTER", param);
                string err = param[7].Value.ToString();
                //string d = param[6].Value.ToString();
                result = Convert.ToInt32(param[6].Value.ToString());              
                
            }
         }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }
        return ds;
    }


    public DataSet RetrieveAll_Drawback_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@DRAWBACK_ID", Edrawback_id);
            param[1] = new SqlParameter("@DRAWBACK_SLNO ", Edrawback_slno);
            param[2] = new SqlParameter("@DRAWBACK_DESCRIPTION", Edrawback_description);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DRAWBACK_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DRAWBACK_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DRAWBACK_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }

            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DRAWBACK_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_Location_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@LOCATION_ID", Elocation_id);
            param[1] = new SqlParameter("@LOCATION_CODE ", Elocation_code);
            param[2] = new SqlParameter("@LOCATION_NAME", Elocation_name);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_LOCATION_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_LOCATION_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_LOCATION_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_LOCATION_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_Notification_Excise_master()
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[15];


            param[0] = new SqlParameter("@NOTIFICATION_EXCISE_ID", ENotification_Excise_id);
            param[1] = new SqlParameter("@NOTIFICATION_EXCISE_NOTN", ENotification_Excise_notn);
            param[2] = new SqlParameter("@NOTIFICATION_EXCISE_NOTN_SL", ENotification_Excise_notn_slno);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_EXCISE", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_EXCISE_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_EXCISE_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_EXCISE_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
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


    public DataSet RetrieveAll_Notification_Customs_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@NOTIFICATION_CUSTOMS_ID", ENotification_Customs_id);
            param[1] = new SqlParameter("@NOTIFICATION_CUSTOMS_NOTN", ENotification_Customs_code);
            param[2] = new SqlParameter("@NOTIFICATION_CUSTOMS_NOTN_SL", ENotification_Customs_name);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_CUSTOMS_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_CUSTOMS_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_CUSTOMS_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_Airline_Master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@AIRLINE_ID", EAirline_id);
            param[1] = new SqlParameter("@AIRLINE_CODE", EAirline_code);
            param[2] = new SqlParameter("@AIRLINE_NAME", EAirline_name);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
           
            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_AIRLINE_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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


    public DataSet RetrieveAll_Package_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@PACKAGE_ID", EPackage_id);
            param[1] = new SqlParameter("@PACKAGE_CODE", EPackage_code);
            param[2] = new SqlParameter("@PACKAGE_NAME", EPackage_name);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PACKAGE_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PACKAGE_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PACKAGE_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PACKAGE_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                // return SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PACKAGE_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PACKAGE_MASTER_SEARCH_SELECT", param);
                //result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_Port_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@PORT_ID", EPort_id);
            param[1] = new SqlParameter("@PORT_CODE", EPort_code_air);
            //param[8] = new SqlParameter("@PORT_CODE_SEA", EPort_code_sea);

            param[2] = new SqlParameter("@PORT_NAME", EPort_name);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PORT_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PORT_MASTERNEW_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PORT_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PORT_MASTERNEW_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                // return SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PORT_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PORT_MASTERNEW_SEARCH_SELECT", param);
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_Port_master_Country()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@PORT_ID", EPort_id);
            param[1] = new SqlParameter("@PORT_CODE", EPort_code_air);
            //param[8] = new SqlParameter("@PORT_CODE_SEA", EPort_code_sea);
            param[2] = new SqlParameter("@PORT_NAME", EPort_name);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PORT_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PORT_MASTERNEW_COUNTRY_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PORT_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PORT_MASTERNEW_COUNTRY_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                // return SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PORT_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PORT_MASTERNEW_COUNTRY_SEARCH_SELECT", param);
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_RSP_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@RSP_ID", ERSP_id);
            param[1] = new SqlParameter("@RSP_CTHNO", ERSP_cthno);
            param[2] = new SqlParameter("@RSP_DESCRIPTION", ERSP_description);
            param[11] = new SqlParameter("@RSP_NOTN", ERSP_Notn);
            param[12] = new SqlParameter("@RSP_NOTN_SLNO", ERSP_Notn_SlNo);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RSP_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RSP_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "RSP_CTH_NO_SEARCH")
            {
              ds=SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RSP_MASTER_SEARCH_SELECT", param);
              if (ds.Tables[0].Rows.Count > 0)
                  ERSP_id = ds.Tables[0].Rows[0]["RSP_RATE"].ToString();
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RSP_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RSP_MASTER_SEARCH_SELECT", param);         
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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

    
    public DataSet Get_AIDC_CESS_SELECT()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@AIDC_RITC_NO", AIDC_RITC_NO);
            param[2] = new SqlParameter("@AIDC_NOTN_NO", AIDC_NOTN_NO);
            param[3] = new SqlParameter("@AIDC_NOTN_SLNO", AIDC_NOTN_SLNO);
            param[4] = new SqlParameter("@AIDC_NOTN_RATE", AIDC_NOTN_RATE);
            param[5] = new SqlParameter("@name", Ename);
            
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "AIDC_CESS_SELECT", param);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    ds.Tables.Add(dt);
                }
            }
            else
            {
                ds.Tables.Add(dt);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return ds;
    }
    
    public DataSet RetrieveAll_RSP_master_PRODUCT_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[10];

            param[1] = new SqlParameter("@RSP_CTH_ALL", ERSP_cthno);
            param[5] = new SqlParameter("@RSP_NOTN", ERSP_Notn);
            param[6] = new SqlParameter("@RSP_NOTN_SLNO", ERSP_Notn_SlNo);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            if (Ename == "Get_RSP_ABTT_RATE_PRODUCT")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RSP_MASTER_SEARCH_SELECT_ACCESS_TO_SQL", param);
                result = Convert.ToInt32(param[3].Value.ToString());
            }
            else
            {
                //return SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RSP_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RSP_MASTER_SEARCH_SELECT_ACCESS_TO_SQL", param);
            }
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

    public DataSet RetrieveAll_State_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@STATE_ID", EState_id);
            param[1] = new SqlParameter("@STATE_CODE ", EState_code);
            param[2] = new SqlParameter("@STATE_NAME", EState_name);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_STATE_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_STATE_MASTER_SEARCH_SELECT", param);
               
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_STATE_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_STATE_MASTER_SEARCH_SELECT", param);
                string f = param[7].Value.ToString();
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_District_State_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@DISTRICT_ID", EState_id);
            param[1] = new SqlParameter("@STATE_CODE ", EState_code);
            param[2] = new SqlParameter("@STATE_NAME", EState_name);
            param[3] = new SqlParameter("@DISTRICT_NAME", EDistrict_name);
            param[4] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DISTRICT_DISTRICT_STATE_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DISTRICT_DISTRICT_STATE_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_DISTRICT_DISTRICT_STATE_MASTER_SEARCH_SELECT", param);
                string f = param[7].Value.ToString();
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_PTA_FTA_Agreement_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@ID", EState_id);
            param[1] = new SqlParameter("@AGREEMENT_CODE ", EState_code);
            param[2] = new SqlParameter("@AGREEMENT_NAME", EState_name);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PTA_FTA_AGREEMENT_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PTA_FTA_AGREEMENT_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PTA_FTA_AGREEMENT_MASTER_SEARCH_SELECT", param);
                string f = param[7].Value.ToString();
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_Unit_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@UNIT_ID", EUnit_id);
            param[1] = new SqlParameter("@UNIT_CODE ", EUnit_code);
            param[2] = new SqlParameter("@UNIT_NAME", EUnit_name);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_UNIT_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_UNIT_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_UNIT_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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



    public DataSet RetrieveAll_Unit_master_STD()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@UNIT_ID", EUnit_id);
            param[1] = new SqlParameter("@UNIT_CODE ", EUnit_code);
            param[2] = new SqlParameter("@UNIT_NAME", EUnit_name);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_UNIT_MASTER_STD_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_UNIT_MASTER_STD_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_UNIT_MASTER_STD_SEARCH_SELECT", param);
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_SUPPROTING_DOCS_Master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@DOC_ID", EUnit_id);
            param[1] = new SqlParameter("@DOC_CODE ", EUnit_code);
            param[2] = new SqlParameter("@DOC_NAME", EUnit_name);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SUPPORTING_DOCUMENTS_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SUPPORTING_DOCUMENTS_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SUPPORTING_DOCUMENTS_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_Export_RITC__Master()
    {
        DataSet ds = new DataSet();
        DataTable dtt = new DataTable();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@RITC_ID", ERITC_ID);
            param[1] = new SqlParameter("@RITC_CODE", ERITC_CODE);
            param[2] = new SqlParameter("@RITC_DESCRIPTION", ERITC_DESCRIPTION);
            param[3] = new SqlParameter("@name", Ename);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete" || Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXPORT_RITC_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXPORT_RITC_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXPORT_RITC_MASTER_SEARCH_SELECT", param);
                //Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dtt);
            }
            else
                ds.Tables.Add(dtt);
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }
        return ds;
    }

#endregion

    #region INSERT_UPDATE
    public DataSet Category_master_insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CATEGORY_ID", Ecategoryid);
            param[1] = new SqlParameter("@CATEGORY_NO", Ecategoryno);
            param[2] = new SqlParameter("@CATEGORY_NAME", Ecategoryname);
            param[3] = new SqlParameter("@Mflag", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@CATEGORY_REMARKS", Ecategoryremarks);
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);
            param[10] = new SqlParameter("@maximumRows", maximumRows);
            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

                //return SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CATEGORY_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CATEGORY_MASTER_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                //Total_Rows = Convert.ToInt32(param[11].Value.ToString());
                Total_Rows = Convert.ToDouble(param[11].Value.ToString());

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

    public int Exchange_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@EXCHANGE_ID", EXCHANGE_ID);
            //param[1] = new SqlParameter("@EXCHANGE_EFFECT_DT_FROM", EXCHANGE_EFFECT_DT_FROM);
            //param[2] = new SqlParameter("@EXCHANGE_EFFECT_DT_TO", EXCHANGE_EFFECT_DT_TO);
            param[1] = new SqlParameter("@EXCHANGE_EFFECT_DT_FROM", DateTime.Parse(EXCHANGE_EFFECT_DT_FROM, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[2] = new SqlParameter("@EXCHANGE_EFFECT_DT_TO", DateTime.Parse(EXCHANGE_EFFECT_DT_TO, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[3] = new SqlParameter("@EXCHANGE_NONT_NO", EXCHANGE_NONT_NO);
            //param[4] = new SqlParameter("@EXCHANGE_NOTN_DATE", EXCHANGE_NOTN_DATE);
            param[4] = new SqlParameter("@EXCHANGE_NOTN_DATE", DateTime.Parse(EXCHANGE_NOTN_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[5] = new SqlParameter("@EXCHANGE_CUR_CODE", EXCHANGE_CUR_CODE);
            param[6] = new SqlParameter("@EXCHANGE_NAME", EXCHANGE_NAME);
            param[7] = new SqlParameter("@EXCHANGE_PER_UNIT", EXCHANGE_PER_UNIT);
            param[8] = new SqlParameter("@EXCHANGE_RATE_IMPORT", EXCHANGE_RATE_IMPORT);
            param[9] = new SqlParameter("@EXCHANGE_RATE_EXPORT", EXCHANGE_RATE_EXPORT);
            param[10] = new SqlParameter("@EXCHANGE_S_OR_N", EXCHANGE_S_OR_N);
            param[11] = new SqlParameter("@EXCHANGE_USER_ID", USER_ID);
            param[17] = new SqlParameter("@EXCHANGE_BRANCH_CODE", BRANCH_CODE);
            param[12] = new SqlParameter("@EXCHANGE_YEAR", YEAR);
            param[13] = new SqlParameter("@EXCHANGE_WORKING_PERIOD", EWorking_Period);
            param[14] = new SqlParameter("@Mflag", flag);

            param[15] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;
            param[18] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_INSERT_UPDATE", param);
            string ss = param[16].Value.ToString();
            result = Convert.ToInt32(param[15].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[18].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return result;

    }
    public DataSet cth_ceth_master_24_27_insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@ID", Eceth_id);
            param[1] = new SqlParameter("@CTH_CODE", Ecth_code);
            param[2] = new SqlParameter("@CETH_CODE", Eceth_code);
            param[4] = new SqlParameter("@REMARKS", Eceth_remarks);
            param[3] = new SqlParameter("@Mflag", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);
            param[10] = new SqlParameter("@maximumRows", maximumRows);
            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CTH_CETH_MASTER_24_27_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[6].Value.ToString());
            Total_Rows = Convert.ToDouble(param[11].Value.ToString());

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

#endregion


    public DataSet RetrieveAll_Exchange_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@EXCHANGE_ID", Eexchange_id);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@EXCHANGE_CUR_CODE", EXCHANGE_CUR_CODE);
            param[4] = new SqlParameter("@EXCHANGE_NAME", EXCHANGE_NAME);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);
            param[10] = new SqlParameter("@maximumRows", maximumRows);
            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else
            {
                // ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_SELECT", param);
                string s = param[8].Value.ToString();
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
            }
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }

        return ds;
    }

    public DataSet Supporting_Doc_Master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@DOC_ID", EUnit_id);
            param[1] = new SqlParameter("@DOC_CODE ", EUnit_code);
            param[2] = new SqlParameter("@DOC_NAME", EUnit_name);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@ISSUING_PARTY_NAME", ISSUING_PARTY_NAME);
            param[12] = new SqlParameter("@BENEFICIARY_PARTY_NAME", BENEFICIARY_PARTY_NAME);
            param[13] = new SqlParameter("@IMAGE_REF_NO", IMAGE_REF_NO);


            ds = Connection.Get_Dataset("SUPPORTING_DOCUMENTS_MASTER_SEARCH_SELECT", param);
            Total_Rows = Convert.ToInt32(param[10].Value.ToString());

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    ds.Tables.Add(dt);
                }
            }
            else
            {
                ds.Tables.Add(dt);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Sup_Doc_Master(string Sp_name)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (fdate != string.Empty && fdate != null)
            {
                arr = fdate.Split('/');
                fdate = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (tdate != string.Empty && tdate != null)
            {
                arr2 = tdate.Split('/');
                tdate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[18];
            param[1] = new SqlParameter("@IMAGE_REF_NO", IMAGE_REF_NO);
            param[2] = new SqlParameter("@DOC_CODE ", EUnit_code);
            param[3] = new SqlParameter("@PARTY_NAME", Ecustom_name);
            param[4] = new SqlParameter("@IMP_EXP", path);
            param[5] = new SqlParameter("@from_date", fdate);
            param[6] = new SqlParameter("@to_date", tdate);
            param[7] = new SqlParameter("@Flag", Ename);

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);
            param[12] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset(Sp_name, param);
            Total_Rows = Convert.ToInt32(param[10].Value.ToString());

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    ds.Tables.Add(dt);
                }
            }
            else
            {
                ds.Tables.Add(dt);
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Exchange_master_INV_Currency()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@Working_Period", EWorking_Period);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@INVOICE_CURRENCY", Invoice_Currency);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            if (Ename == "IMPORT_INVOICE_EX_RATE")
            {
                //ds= SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);
            }
            else if (Ename == "Ex_Rate")
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);
                string s = param[8].Value.ToString();
                //result = Convert.ToInt32(param[11].Value.ToString());
            }
            else if (Ename == "currency_converter")
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);

                string s = param[8].Value.ToString();
                //result = Convert.ToInt32(param[11].Value.ToString());
            }
            else
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY", param);
                string s = param[8].Value.ToString();
                //result = Convert.ToInt32(param[11].Value.ToString());
            }
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


    public DataSet RetrieveAll_Exchange_master_INV_Currency_ExcelUpload()
    {
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
       
        cmd.CommandTimeout = 0;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SP_EXCHANGE_MASTER_SEARCH_INVOICE_CURRENCY";
        cmd.Parameters.Add("@Working_Period", SqlDbType.VarChar, 300).Value = EWorking_Period;
        cmd.Parameters.Add("@name", SqlDbType.VarChar,300).Value = Ename;
        cmd.Parameters.Add("@INVOICE_CURRENCY", SqlDbType.VarChar, 100).Value = Invoice_Currency;
        cmd.Parameters.Add("@ErrorMsg", SqlDbType.VarChar,1000).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@Mstatus", SqlDbType.Int, 10).Direction = ParameterDirection.Output;
        cmd.Connection = con;

        try
        {
            con.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            //cmd.ExecuteNonQuery();
            //result = Convert.ToInt32(cmd.Parameters["@Mstatus"].Value.ToString());
            //lblMessage.Text = "Record inserted successfully. ID = " + id;

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return ds;

    }

    public DataSet RetrieveAll_Scheme_Import()
    {

        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@SCHEME_NOTN", SCHEME_NOTN);
            param[1] = new SqlParameter("@SCHEME_IMPORT_CODE", SCHEME_IMPORT_CODE);
            param[2] = new SqlParameter("@name", name);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            if (name == "SCHEME_IMPORT_CODE")
            {
                //return SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SCHEME_IMPORT", param);
                ds= SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SCHEME_IMPORT", param);
                string err = param[4].Value.ToString();
            }
            else if (name == "SCHEME_NOTN")
            {
                //return SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SCHEME_IMPORT", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SCHEME_IMPORT", param);
                //SCHEME_NOTN_SLNO = Convert.ToString(param[3].Value.ToString());
            }
            else if (name == "SCHEME_NOTN_SLNO")
            {
                //return SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SCHEME_IMPORT", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SCHEME_IMPORT", param);
                string err = param[4].Value.ToString();
            }
            else
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SCHEME_IMPORT", param);
                ds= SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SCHEME_IMPORT", param);
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

    public DataSet RetrieveAll_ANTIDUMPING_MASTER_Calc()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@ADD_NOTN", ADD_NOTN);
            param[1] = new SqlParameter("@ADD_SLNO", ADD_SLNO);
            param[5] = new SqlParameter("@ADD_CTH", ADD_CTH);
            param[6] = new SqlParameter("@ADD_SUP_SLNO", ADD_SUP_SLNO);

            param[2] = new SqlParameter("@name", name);


            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;



            if (name == "ANTIDUMPING_CALC")
            {
                //return SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SCHEME_IMPORT", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_ANTIDUMPING_MASTER", param);
                string err = param[4].Value.ToString();
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

    public DataSet RetrieveAll_Scheme_Export()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[10];


            //param[0] = new SqlParameter("@SCHEME_NOTN", SCHEME_NOTN);
            //param[1] = new SqlParameter("@SCHEME_IMPORT_CODE", SCHEME_IMPORT_CODE);
            param[2] = new SqlParameter("@name", name);


            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;



            if (name == "SCHEME_EXPORT_CODE")
            {
                //return SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SCHEME_IMPORT", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SCHEME_EXPORT", param);
                string err = param[4].Value.ToString();
            }
           
            else
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SCHEME_IMPORT", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SCHEME_EXPORT", param);

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

    public DataSet RetrieveAll_DB_master(string conn)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@databasename", databasename);
            param[1] = new SqlParameter("@path",path);
            param[2] = new SqlParameter("@filename", filename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con2"], CommandType.StoredProcedure, "sp_BackupDatabase", param);
             //SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_BackupDatabase", param);
            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "sp_BackupDatabase", param);
            string resultb = param[7].Value.ToString();
            result1 = param[6].Value.ToString();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return ds;
    }

    public DataSet RetrieveAll_CheckList_Scheme_Import()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@SCHEME_NOTN", SCHEME_NOTN);
            param[1] = new SqlParameter("@SCHEME_IMPORT_CODE", SCHEME_IMPORT_CODE);
            param[7] = new SqlParameter("@PRODUCT_CETH", PRODUCT_CETH);
            param[2] = new SqlParameter("@name", Name);
            param[5] = new SqlParameter("@SCHEME_NOTN_SLNO", SCHEME_NOTN_SLNO);
            param[6] = new SqlParameter("@SCHEME_IMPORT_NAME", SCHEME_IMPORT_NAME);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SCHEME_IMPORT_RATE_SEARCH", param);

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
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_CheckList_RSP_master1()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@RSP_ID", ERSP_id);
            param[1] = new SqlParameter("@RSP_CTHNO", ERSP_cthno);
            param[2] = new SqlParameter("@RSP_DESCRIPTION", ERSP_description);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RSP_MASTER", param);
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RSP_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RSP_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else if (Ename == "select_CTH_NO")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RSP_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RSP_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_STR_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@STR_ID", STR_ID);
            param[1] = new SqlParameter("@STR_SRNO ", STR_SRNO);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_STR_DETAILS_SEARCH_SELECT", param);
                string f = param[7].Value.ToString();
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "select_value")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_STR_DETAILS_SEARCH_SELECT", param);
                string f = param[7].Value.ToString();
            }
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

    public DataSet RetrieveAll_SVB_CUSTOM_HOUSE_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[4] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SVB_CUSTOMHOUSE_MASTER", param);
                string err = param[7].Value.ToString();
            }
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
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }




    public DataSet RetrieveAll_EXPORT_CESS_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CESS_ID", CESS_ID);
            param[1] = new SqlParameter("@CESS_SLNO", CESS_SLNO);
            param[2] = new SqlParameter("@CESS_NOTN_NO", CESS_NOTN_NO);
            param[12] = new SqlParameter("@CESS_RITCNO", CESS_RITCNO);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CESS_MASTER_SEARCH_SELECT", param);

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


    public DataSet RetrieveAll_END_USE_ITEM_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@ID", Ecth_id);
            param[1] = new SqlParameter("@END_USE_CODE", Ecth_code);
            param[2] = new SqlParameter("@END_USE_DESCRIPTION", Ecth_description);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_END_USE_ITEM_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_END_USE_ITEM_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_END_USE_ITEM_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
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

    public DataSet IMP_Single_Window()
    {
        DataSet dstype = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@STATEMENT_TYPE", SCHEME_NOTN);
            param[1] = new SqlParameter("@STATEMENT_CODE", SCHEME_IMPORT_CODE);
            param[2] = new SqlParameter("@name", name);

            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            dstype = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "IMPORT_SINGLE_WINDOW_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return dstype;
    }

    public DataSet RetrieveAll_Warehouse_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@WH_ID", EWarehouse_id);
            param[1] = new SqlParameter("@WAREHOUSE_CODE", EWarehouse_code);
            param[2] = new SqlParameter("@WAREHOUSE_NAME", EWarehouse_name);
            param[11] = new SqlParameter("@WAREHOUSE_ADDRESS", EWarehouse_address);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_WAREHOUSE_MASTERNEW_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid" || Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_WAREHOUSE_MASTERNEW_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_WAREHOUSE_MASTERNEW_SEARCH_SELECT", param);
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_ROSL_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@ROSL_ID", EROSL_id);
            param[1] = new SqlParameter("@ROSL_SLNO ", EROSL_slno);
            param[11] = new SqlParameter("@ROSL_HEADER_NO ", EROSL_Headerno);
            param[2] = new SqlParameter("@ROSL_DESCRIPTION", EROSL_description);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_ROSL_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_ROSL_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_ROSL_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_AntiDumpting_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@ADD_ID", Antidumpting_id);
            param[1] = new SqlParameter("@ADD_NOTN", Antidumpting_Notn);
            param[2] = new SqlParameter("@ADD_ITEM_DESC", Antidumpting_desc);

            param[11] = new SqlParameter("@ADD_SLNO", Antidumpting_SLNO);
            param[12] = new SqlParameter("@ADD_CTH", Antidumpting_CTH);
            param[13] = new SqlParameter("@ADD_SUP_SLNO", Antidumpting_SUPSLNO);

            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_ANTIDUMPTING_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_ANTIDUMPTING_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_ANTIDUMPTING_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_SingleWindow_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@ID", SW_id);
            param[1] = new SqlParameter("@FROM_CTH", SW_FromCTH);
            param[2] = new SqlParameter("@AGENCY_CD", SW_AgencyCode);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SW_CTH_CODE_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SW_CTH_CODE_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SW_CTH_CODE_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_CustomHouse_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@CUSTOMHOUSE_ID", CH_id);
            param[1] = new SqlParameter("@CUSTOMHOUSE_CODE", CH_Code);
            param[2] = new SqlParameter("@CUSTOMHOUSE_NAME", CH_Name);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11] = new SqlParameter("@AREA", CH_Area);

            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CUSTOMS_HOUSE_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CUSTOMS_HOUSE_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CUSTOMS_HOUSE_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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

    public DataSet RetrieveAll_NOTIFICATIONS_RATE_CHECKLIST()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            //param[0] = new SqlParameter("@xml_CTH", xml_CTH);
            //param[1] = new SqlParameter("@xml_CETH", xml_CETH);
            param[5] = new SqlParameter("@xml_CUSTOMS_NOTN", xml_CUSTOMS_NOTN);
            param[6] = new SqlParameter("@xml_IGST_LEVY", xml_IGST_LEVY);
            param[7] = new SqlParameter("@xml_IGST_LEVY_EXCE", xml_IGST_LEVY_EXCE);
            param[8] = new SqlParameter("@xml_IGST_COMP_NOTN", xml_IGST_COMP_NOTN);
            param[9] = new SqlParameter("@xml_IGST_COMP_EXEC", xml_IGST_COMP_EXEC);
            param[10] = new SqlParameter("@xml_EXCISE_NOTN", xml_EXCISE_NOTN);
            param[11] = new SqlParameter("@xml_SCHEMECODE", xml_SCHEME_CODE_RATE);
            param[12] = new SqlParameter("@xml_ANTI_DUMPING", xml_ANTI_DUMPING);
            //param[13] = new SqlParameter("@xml_Country", xml_Country);
            param[14] = new SqlParameter("@xml_AIDC", xml_AIDC);
            param[15] = new SqlParameter("@xml_SPL_AMT", xml_SPL_AMT);
            param[16] = new SqlParameter("@xml_CTH", xml_CTH);
            param[17] = new SqlParameter("@xml_CETH", xml_CETH);
            param[18] = new SqlParameter("@xml_SUPDOC_TYPE", xml_SUPDOC_TYPE);


            param[2] = new SqlParameter("@flag", name);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "GET_ALL_NOTIFICATIONS_RATE_CHECKLIST", param);

            string err = param[4].Value.ToString();
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Notification_Updation_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@NOTIFICATIONF_ID", ENOTIFICATIONF_ID);
            param[1] = new SqlParameter("@NOTIFICATION_NUMBER", ENOTIFICATION_NUMBER);

            param[2] = new SqlParameter("@NOTIFICATION_DATEOFISSUE", Connection.DATE_FORMAT(ENOTIFICATION_DATEOFISSUE == string.Empty ? "01/01/1900" : ENOTIFICATION_DATEOFISSUE));
            param[3] = new SqlParameter("@NOTIFICATION_EFFECTIVEDATE", Connection.DATE_FORMAT(ENOTIFICATION_EFFECTIVEDATE == string.Empty ? "01/01/1900" : ENOTIFICATION_EFFECTIVEDATE));
            param[4] = new SqlParameter("@NOTIFICATION_DESCRIPTION", ENOTIFICATION_DESCRIPTION);
            param[5] = new SqlParameter("@FILE_ATTACHMENT", EFILE_ATTACHMENT);
            param[6] = new SqlParameter("@name", Ename);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);
            param[10] = new SqlParameter("@maximumRows", maximumRows);
            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@fromdate", Connection.DATE_FORMAT(Efromdate == string.Empty ? "01/01/1900" : Efromdate));
            param[13] = new SqlParameter("@todate", Connection.DATE_FORMAT(Etodate == string.Empty ? "01/01/1900" : Etodate));
            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_UPDATION_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[7].Value.ToString());
                Total_Rows = Convert.ToInt32(param[11].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_UPDATION_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_UPDATION_SEARCH_SELECT", param);
                Total_Rows = Convert.ToInt32(param[11].Value.ToString());
            }
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

    public DataSet RetrieveAll_Notification_IGST_LEVY1_CTH_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];


            param[0] = new SqlParameter("@CTH_NO_AUTO", ENOTIFICATION_IGST_LEVY_ID);
            param[1] = new SqlParameter("@LEVY_1NOTIFICATION", ENOTIFICATION_LEVY_NOTN);

            param[2] = new SqlParameter("@LEVY_1NOTIFICATION_SLNO", ENOTIFICATION_LEVY_NOTN_SL);
            param[3] = new SqlParameter("@CTH_NO", ENOTIFICATION_CUSTOMS_CTH);
            param[4] = new SqlParameter("@name", Ename);
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@startRowIndex", startRowIndex);
            param[8] = new SqlParameter("@maximumRows", maximumRows);
            param[9] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_IGST_LEVY_CTH_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[9].Value.ToString());
                result = Convert.ToInt32(param[5].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_IGST_LEVY_CTH_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[5].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_IGST_LEVY_CTH_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[9].Value.ToString());
            }
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

    public DataSet RetrieveAll_Notification_IGST_LEVY2_CTH_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CTH_NO_AUTO", ENOTIFICATION_IGST_LEVY_CESS_ID);
            param[1] = new SqlParameter("@LEVY_2NOTIFICATION", ENOTIFICATION_LEVY_CESS_NOTN);
            param[2] = new SqlParameter("@LEVY_2NOTIFICATION_SLNO", ENOTIFICATION_LEVY_CESS_NOTN_SL);
            param[3] = new SqlParameter("@CTH_NO", ENOTIFICATION_CUSTOMS_CESS_CTH);
            param[4] = new SqlParameter("@name", Ename);
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@startRowIndex", startRowIndex);
            param[8] = new SqlParameter("@maximumRows", maximumRows);
            param[9] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_IGST_LEVY2_CESS_CTH_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[9].Value.ToString());
                result = Convert.ToInt32(param[5].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_IGST_LEVY2_CESS_CTH_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[5].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_NOTIFICATION_IGST_LEVY2_CESS_CTH_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[9].Value.ToString());
            }
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

    //CTH_CETH_MASTER_24_27
    public DataSet RetrieveAll_cth_ceth_master_24_27()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@ID", Eceth_id);
            param[1] = new SqlParameter("@CTH_CODE", Ecth_code);
            param[2] = new SqlParameter("@CETH_CODE", Eceth_code);
            param[3] = new SqlParameter("@REMARKS", Eceth_remarks);
            param[4] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CTH_CETH_MASTER_24_27_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CTH_CETH_MASTER_24_27_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CTH_CETH_MASTER_24_27_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
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

    public DataSet Fta_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@FTA_NOTN ", FTA_NOTN);
            param[1] = new SqlParameter("@FTA_NOTN_SLNO ", FTA_NOTN_SLNO);
            param[2] = new SqlParameter("@FTA_COUNTRY ", FTA_COUNTRY);
            param[3] = new SqlParameter("@REMARKS ", FTA_REMARKS);
            param[4] = new SqlParameter("@name", Ename);
            param[11] = new SqlParameter("@ID", ID);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            //if (Ename == "delete")
            //{
            //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PORT_MASTER", param);
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_FTA_MASTER_INSERT_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[6].Value.ToString());
            Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            //    }
            //    else if (Ename == "autoid" || Ename == "select_con")
            //    {
            //        //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PORT_MASTER", param);
            //        ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_WAREHOUSE_MASTERNEW_SEARCH_SELECT", param);
            //        result = Convert.ToInt32(param[6].Value.ToString());
            //    }

            //    else
            //    {
            //        // return SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_PORT_MASTER", param);
            //        ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_WAREHOUSE_MASTERNEW_SEARCH_SELECT", param);
            //        Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            //    }
            //    if (ds.Tables.Count > 0)
            //    {
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //        }
            //        else
            //            ds.Tables.Add(dt);
            //    }
            //    else
            //        ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet Aidc_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@AIDC_ID ", AIDC_ID);
            param[1] = new SqlParameter("@AIDC_RITC_NO ", AIDC_RITC_NO);
            param[2] = new SqlParameter("@AIDC_NOTN_NO ", AIDC_NOTN_NO);
            param[3] = new SqlParameter("@AIDC_NOTN_SLNO ", AIDC_NOTN_SLNO);
            param[4] = new SqlParameter("@AIDC_NOTN_RATE ", AIDC_NOTN_RATE);
            param[5] = new SqlParameter("@AIDC_DESCRIPTION ", AIDC_DESCRIPTION);
            param[6] = new SqlParameter("@AIDC_FLAG ", AIDC_FLAG);
            param[7] = new SqlParameter("@name", Ename);
            //param[11] = new SqlParameter("@ID", ID);
            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@startRowIndex", startRowIndex);
            param[11] = new SqlParameter("@maximumRows", maximumRows);
            param[12] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_AIDC_MASTER_INSERT_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[8].Value.ToString());
            Total_Rows = Convert.ToInt32(param[10].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet Get_AIDC_Master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@AIDC_ID", AIDC_ID);
            param[2] = new SqlParameter("@AIDC_RITC_NO", AIDC_RITC_NO);
            param[4] = new SqlParameter("@AIDC_NOTN_NO", AIDC_NOTN_NO);
            param[5] = new SqlParameter("@AIDC_NOTN_SLNO", AIDC_NOTN_SLNO);
            param[6] = new SqlParameter("@name", Ename);
            param[7] = new SqlParameter("@startRowIndex", startRowIndex);
            param[8] = new SqlParameter("@maximumRows", maximumRows);

            param[12] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;
            param[13] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "AIDC_MASTER_SEARCH", param);
            result = Convert.ToInt32(param[12].Value.ToString());

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Ename = "1";
                }
                else
                {
                    ds.Tables.Add(dt);
                }
            }
            else
            {
                ds.Tables.Add(dt);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet Error_Code_master()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@MESG_ID ", MESG_ID);
            param[1] = new SqlParameter("@ERR_CD ", ERR_CD);
            param[2] = new SqlParameter("@ERR_DESC ", ERR_DESC);
            param[3] = new SqlParameter("@ERROR ", ERROR);
            param[4] = new SqlParameter("@MODULE_IDMESG_TYP ", MODULE_IDMESG_TYP);
            param[5] = new SqlParameter("@F6 ", F6);
            //param[6] = new SqlParameter("@AIDC_FLAG ", AIDC_FLAG);
            param[7] = new SqlParameter("@name", Ename);
            //param[11] = new SqlParameter("@ID", ID);
            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@startRowIndex", startRowIndex);
            param[11] = new SqlParameter("@maximumRows", maximumRows);
            param[12] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_IMP_ERRORCODE_MASTER_INSERT_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[8].Value.ToString());
            Total_Rows = Convert.ToInt32(param[10].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Esanchit_Master(DataSet ds)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Mode", Ename);
            param[1] = new SqlParameter("@MessageDetails", ds.GetXml());
            param[2] = new SqlParameter("@Emailid ", Esan_EmailID);
            param[3] = new SqlParameter("@COMPANY_ID", Esan_Company);
            param[4] = new SqlParameter("@CUSTOM_HOUSE", Esan_CustID);
            param[5] = new SqlParameter("@FILE_FORMAT", Esan_FileFormat);
            param[6] = new SqlParameter("@WORKING_PERIOD", EWorking_Period);
            param[7] = new SqlParameter("@TRANSACTION", Esan_Trasaction);
            param[8] = new SqlParameter("@SELECT_BRANCH", BRANCH_CODE);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@startRowIndex", startRowIndex);
            param[11] = new SqlParameter("@maximumRows", maximumRows);
            param[12] = new SqlParameter("@IRN_no", IRN_no);
            param[13] = new SqlParameter("@DRN_no", DRN_no);
            param[14] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "ESANCHIT_MAIL_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "ESANCHIT_MAIL_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "ESANCHIT_MAIL_INSERT_UPDATE", param);
                Total_Rows = Convert.ToInt32(param[10].Value.ToString());
            }
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


    public DataSet Checklist_EXPORT_RODTEP_MASTER()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@RODTEP_ID", E_RODTEP_ID);
            param[1] = new SqlParameter("@RODTEP_TARIFF ", E_RODTEP_TARIFF);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            if (Ename == "select_checklist")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXPORT_RODTEP_MASTER", param);
                string err = param[4].Value.ToString();
                result = Convert.ToInt32(param[3].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public DataSet RetrieveAll_RODTEP_master()
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@RODTEP_ID ", ERODTEP_id);
            param[1] = new SqlParameter("@RODTEP_TARIFF ", ERODTEP_TARIFF);
            param[2] = new SqlParameter("@RODTEP_DESC", ERODTEP_DESC);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete_4RE" || Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RODTEP_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
            else if (Ename == "autoid_4RE" || Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RODTEP_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_RODTEP_MASTER_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
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


    public DataSet RetrieveAll_Import_Restricted_RITC_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            //param[0] = new SqlParameter("@ID", SW_id);
            param[1] = new SqlParameter("@CTH_NUMBER", SW_FromCTH);
            param[2] = new SqlParameter("@CTH_STATUS", CTH_STATUS);

            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;


            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_IMP_RESTRICTED_CTH_MASTER_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[6].Value.ToString());
            Total_Rows = Convert.ToInt32(param[10].Value.ToString());

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



    public DataSet SVB_Relation_Master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@SVB_ID", ESvbid);
            param[1] = new SqlParameter("@SVB_REF_NO ", ESvb_relation);
            param[2] = new SqlParameter("@SVB_CUSTOM_HOUSE", ESvbcustom_house);
            param[3] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@IMP_NAME", EImpName);
            param[12] = new SqlParameter("@SUPPLIER_NAME", ESupName);
            param[13] = new SqlParameter("@SVB_ASSESABLE_RATE", EAssesableRate);

            ds = Connection.Get_Dataset("SVB_MASTER_SEARCH_SELECT", param);
            Total_Rows = Convert.ToInt32(param[10].Value.ToString());

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    ds.Tables.Add(dt);
                }
            }
            else
            {
                ds.Tables.Add(dt);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Import_Scheme_master()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@SCHEME_IMPORT_ID", SCHEME_IMPORT_ID);
            param[1] = new SqlParameter("@SCHEME_IMPORT_CODE", SCHEME_IMPORT_CODE);
            param[2] = new SqlParameter("@SCHEME_IMPORT_NAME", SCHEME_IMPORT_NAME);
            param[3] = new SqlParameter("@SCHEME_NOTN", SCHEME_NOTN);
            param[4] = new SqlParameter("@SCHEME_NOTN_SLNO", SCHEME_NOTN_SLNO);
            param[5] = new SqlParameter("@name", Ename);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);
            param[9] = new SqlParameter("@maximumRows", maximumRows);
            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SCHEME_IMPORT_SEARCH_SELECT", param);

                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else if (Ename == "autoid")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SCHEME_IMPORT_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_SCHEME_IMPORT_SEARCH_SELECT", param);
                Total_Rows = Convert.ToDouble(param[10].Value.ToString());
            }
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

    public DataSet Checklist_EXPORT_RODTEP_MASTER_4RE()
    {
        DataSet ds = new DataSet();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@RODTEP_ID", E_RODTEP_ID);
            param[1] = new SqlParameter("@RODTEP_TARIFF ", E_RODTEP_TARIFF);

            param[2] = new SqlParameter("@name", Ename);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;

            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            if (Ename == "select_checklist")
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXPORT_RODTEP_MASTER_4RE", param);
                string err = param[4].Value.ToString();
                result = Convert.ToInt32(param[3].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public DataSet RetrieveAll_Export_Checklist_Admin_Master()
    {
        DataSet ds = new DataSet();
        DataTable dtt = new DataTable();
        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@RITC", ERITC_CODE);
            param[1] = new SqlParameter("@STR", STR_SRNO);
            param[2] = new SqlParameter("@DRAWBACK_SLNO", Edrawback_slno);
            param[3] = new SqlParameter("@name", Ename);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_EXPORT_CHECKLIST_ADMIN_RATES", param);
          
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dtt);
            }
            else
                ds.Tables.Add(dtt);
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }
        return ds;
    }
    
    public DataSet Export_RODEP_Master_Bulk_Insert()
    {
        DataSet ds = new DataSet();

        try
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@RODTEP_Masters", Xml_A);
            param[1] = new SqlParameter("@Priority_Type", Update_Priority);
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "EXPORT_RODTEP_MASTER_XL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }
    public DataSet BulkInsert_CETH_Record()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@CETH_Masters", Xml_A);
            param[1] = new SqlParameter("@Priority_Type", Update_Priority);
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3] = new SqlParameter("@USER_ID", USER_ID);
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "CETH_MASTER_XL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet BulkInsert_CTH_Record()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@CTH_Masters", Qf_xml);
            param[1] = new SqlParameter("@Priority_Type", Priority_Type);
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3] = new SqlParameter("@USER_ID", USER_ID);
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "CTH_MASTER_XL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }
   
    public DataSet Export_RODEP_4E_Master_Bulk_Insert()
    {
        DataSet ds = new DataSet();

        try
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@RODTEP_4E_Masters", Xml_A);
            param[1] = new SqlParameter("@Priority_Type", Update_Priority);
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "EXPORT_RODTEP_4E_MASTER_XL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }
    //public DataSet Notification_Customs_Record()
    //{
    //    try
    //    {
    //        SqlParameter[] param = new SqlParameter[5];
    //        param[0] = new SqlParameter("@CS_Notification_Table_Xml", Xml_A);
    //        param[1] = new SqlParameter("@Priority_Type", Update_Priority);
    //        param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
    //        ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "NOTIFICATION_CUSTOMS_XL_UPLOAD", param);
    //    }
    //    catch (Exception ex)
    //    {
    //        er.makeLog(ex.Message);
    //    }
    //    return ds;
    //}


    public DataSet Notification_Customs_Record()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]))
            {
                using (SqlCommand cmd = new SqlCommand("NOTIFICATION_CUSTOMS_XL_UPLOAD", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600; // ⏰ 10 minutes timeout

                    cmd.Parameters.AddWithValue("@CS_Notification_Table_Xml", Xml_A);
                    cmd.Parameters.AddWithValue("@Priority_Type", Update_Priority);
                    // cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
                    cmd.Parameters.Add("@ErrorMsg", SqlDbType.NVarChar, 1000).Direction = ParameterDirection.Output;

                    con.Open();  // 🔸 open manually
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        ds = new DataSet();
                        da.Fill(ds);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }


    //public DataSet Notification_Excise_Record()
    //{
    //    try
    //    {
    //        SqlParameter[] param = new SqlParameter[5];
    //        param[0] = new SqlParameter("@CS_Notification_Table_Xml", Xml_A);
    //        param[1] = new SqlParameter("@Priority_Type", Update_Priority);
    //        param[2] = new SqlParameter("@USER_ID", USER_ID);
    //        param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
    //        ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "NOTIFICATION_EXCISE_XL_UPLOAD", param);
    //    }
    //    catch (Exception ex)
    //    {
    //        er.makeLog(ex.Message);
    //    }
    //    return ds;
    //}

    public DataSet Notification_Excise_Record()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]))
            {
                using (SqlCommand cmd = new SqlCommand("NOTIFICATION_EXCISE_XL_UPLOAD", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600; // ⏰ 10 minutes timeout

                    cmd.Parameters.AddWithValue("@CS_Notification_Table_Xml", Xml_A);
                    cmd.Parameters.AddWithValue("@Priority_Type", Update_Priority);
                    cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
                    cmd.Parameters.Add("@ErrorMsg", SqlDbType.NVarChar, 1000).Direction = ParameterDirection.Output;

                    con.Open();  // 🔸 open manually
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        ds = new DataSet();
                        da.Fill(ds);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet BulkInsert_DRAWBACK_Record()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@DRAWBACK_Table_Xml", Xml_A);
            param[1] = new SqlParameter("@Priority_Type", Update_Priority);
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "DRAWBACK_MASTER_XL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public DataSet ROSL_Master_Record()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ROSL_Table_Xml", Xml_A);
            param[1] = new SqlParameter("@Priority_Type", Update_Priority);
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "EXPORT_ROSL_XL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public DataSet Export_RITC_Master_Bulk_Insert()
    {
        DataSet ds = new DataSet();

        try
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@RITC_Masters", Xml_A);
            param[1] = new SqlParameter("@Priority_Type", Update_Priority);
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "EXPORT_RITC_MASTER_XL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet Import_AIDC_Master_Bulk_Insert()
    {
        DataSet ds = new DataSet();

        try
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@AIDC_Masters", Xml_A);
            param[1] = new SqlParameter("@Priority_Type", Update_Priority);
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "IMPORT_AIDC_MASTER_XL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet IGST_LEVY1_CTH_Bulk_Insert()
    {
        DataSet ds = new DataSet();

        try
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@GST_LEVY1_Masters", Xml_A);
            param[1] = new SqlParameter("@Priority_Type", Update_Priority);
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "IGST_LEVY1_CTH_XL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet IGST_LEVY2_CTH_Bulk_Insert()
    {
        DataSet ds = new DataSet();

        try
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@GST_LEVY2_Masters", Xml_A);
            param[1] = new SqlParameter("@Priority_Type", Update_Priority);
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "IGST_LEVY2_CTH_XL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet Scheme_Import_Insert_Update()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]))
            {
                using (SqlCommand cmd = new SqlCommand("IMPORT_SCHEME_XL_UPLOAD", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600; 

                    cmd.Parameters.AddWithValue("@Import_scheme_Table_Xml", Xml_A);
                    cmd.Parameters.AddWithValue("@Priority_Type", Update_Priority);
                    cmd.Parameters.Add("@ErrorMsg", SqlDbType.NVarChar, 1000).Direction = ParameterDirection.Output;

                    con.Open(); 
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        ds = new DataSet();
                        da.Fill(ds);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet BulkInsert_Sup_Doc_Record()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Sup_Doc_Masters", Xml_A);
            param[1] = new SqlParameter("@Priority_Type", Update_Priority);
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3] = new SqlParameter("@USER_ID", USER_ID);
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SUPPORTING_DOC_XL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }



    public DataSet RetrieveAll_Invoice_Search()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[8];

            param[0] = new SqlParameter("@name", Ename);
            param[1] = new SqlParameter("@Name_Search", INVOICE_NO);
            param[2] = new SqlParameter("@JobType", JOB_TYPE);

            param[3] = new SqlParameter("@startRowIndex", startRowIndex);
            param[4] = new SqlParameter("@maximumRows", maximumRows);

            param[5] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(
                    HttpContext.Current.Session["currentcomp_db"].ToString(),
                    CommandType.StoredProcedure,
                    "INVOICE_NO_SEARCH_SELECT",
                    param);

            result = Convert.ToInt32(param[5].Value.ToString());
            Total_Rows = Convert.ToInt32(param[5].Value.ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public DataSet RetrieveAll_RITC_Based_FTA_SAPTA()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@CTH", Ecth_code);
            param[1] = new SqlParameter("@Country", Ecountry_name);
            param[5] = new SqlParameter("@Notn", ENOTIFICATION_NUMBER);

            param[2] = new SqlParameter("@flag", name);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "IMP_RITC_BASED_FTA_SAPTA_DUTY_CALC", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }



}
