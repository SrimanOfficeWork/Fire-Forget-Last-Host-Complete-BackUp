using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;


/// <summary>
/// Summary description for General
/// </summary>
public class General_Details
{
    public string TICK_MARK = ((char)0x221A).ToString();
    private string _IMPORTER_TYPE;
    private string _IMPORTER_TYPE_PRIVATE;
    private string _IMPORTER_TYPE_GOVT;
    private string _HOME_CONSUMPTION;
    private string _WAREHOUSE;
    private string _EXBOND;
    private string _NORMAL;
    private string _PRIOR;
    private string _ADVANCE;
    public string IMPORTER_TYPE { get { return _IMPORTER_TYPE; } set { _IMPORTER_TYPE = value; } }
    public string IMPORTER_TYPE_PRIVATE { get { return _IMPORTER_TYPE_PRIVATE; } set { _IMPORTER_TYPE_PRIVATE = value; } }
    public string IMPORTER_TYPE_GOVT { get { return _IMPORTER_TYPE_GOVT; } set { _IMPORTER_TYPE_GOVT = value; } }

    public string HOME_CONSUMPTION { get { return _HOME_CONSUMPTION; } set { _HOME_CONSUMPTION = value; } }
    public string WAREHOUSE { get { return _WAREHOUSE; } set { _WAREHOUSE = value; } }
    public string EXBOND { get { return _EXBOND; } set { _EXBOND = value; } }
    public string NORMAL { get { return _NORMAL; } set { _NORMAL = value; } }
    public string PRIOR { get { return _PRIOR; } set { _PRIOR = value; } }
    public string ADVANCE { get { return _ADVANCE; } set { _ADVANCE = value; } }
    #region Private_Attributes
    private string _BE_NO, _IMP_EXP_TYPE;
    private string _JOB_NO;
    private string _Today_dt;
    private string _IGM_TRANSPORTMODE;
    //General Details
    private string _Importer_Name;

    private string _Add1;
    private string _Add2;
    private string _Add3;
    private string _City;
    private string _Pincode;
    private string _IEC_NO;
    private string _Branch_Slno;
    private string _PORT_ORIGIN;
    private string _PORT_SHIPMENT;
    private string _Country_Origin;
    private string _Country_Shipment;
    private string _MBL_MAWB_NO;
    private string _HBL_HAWB_NO;
    private string _MAWB_HAWB_date;
    private string _NO_OF_PACKAGE;
    private string _GROSS_WEIGHT;
    private string _MARKS_NOS;
    private string _TRANSPORT_MODE;
    private string _JOBDATE;
    private string _BE_TYPE, _BE_TYPE_New;
    private string _WAREHOUSE_CODE;
    private string _CUSTOMS_HOUSE;
    private string _FILING_STATUS;
    private string _SECTION46;
    private string _FIRSTCHECK;
    private string _FIRSTCHECK_DESC;
    private string _GREEN_CHANNEL;
    private string _KACHHA_BE;
    private string _SECTION48;
    private string _SECTION48_DESC;
    private string _HIGH_SEA_SALE_NAME, _HIGH_SEA_SALE_YN;
    private string _HIGH_SEA_IEC;
    private string _HIGH_SEA_BRANCH_SL_NO;
    private string _HSS_ADD1;
    private string _HSS_ADD2;
    private string _HSS_ADD3;
    private string _HSS_ADD4;
    private string _HSS_ADD5;
    private string _BE_NO_DATE;
    private string _SVB_STATUS;
    private string _FILE_REF_NO;
    private string _IMP_EXP_PAN_NO;
    private string _PROVISIONAL;

    
    private string _ADCODE;
    private string _UCR_NO;
    private string _UCR_TYPE;
    private string _PAYMENT_METHOD_CODE;
    private string _PRECEDING_LEVEL;
    private string _PARTY_REF_NO;
    private string _COMMERCIAL_TAX_REGISTRATION_NO;
    private string _USERID;


    #endregion

    #region Public_Attributes
    public double BASIC_DUTY, CVD, Customs_Edu_Cess, Customs_Higher_Edu_Cess, AddL_DUTY, TOTAL_DUTY = 0.0;
    public string SCHEME_NOTN_ = "";
    public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }
    public string BE_NO_DATE { get { return _BE_NO_DATE; } set { _BE_NO_DATE = value; } }

    public string JOB_NO { get { return _BE_NO; } set { _JOB_NO = value; } }
    public string Today_dt { get { return _BE_NO; } set { _Today_dt = value; } }
    public string Importer_Name { get { return _Importer_Name; } set { _Importer_Name = value; } }
    public string IGM_TRANSPORTMODE { get { return _IGM_TRANSPORTMODE; } set { _IGM_TRANSPORTMODE = value; } }

    //General Details

    public string Add1 { get { return _Add1; } set { _Add1 = value; } }
    public string Add2 { get { return _Add2; } set { _Add2 = value; } }
    public string Add3 { get { return _Add3; } set { _Add3 = value; } }
    public string City { get { return _City; } set { _City = value; } }
    public string Pincode { get { return _Pincode; } set { _Pincode = value; } }
    public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
    public string Branch_Slno { get { return _Branch_Slno; } set { _Branch_Slno = value; } }
    public string BRANCH_NO { get { return _Branch_Slno; } set { _Branch_Slno = value; } }
    public string PORT_ORIGIN { get { return _PORT_ORIGIN; } set { _PORT_ORIGIN = value; } }
    public string PORT_SHIPMENT { get { return _PORT_SHIPMENT; } set { _PORT_SHIPMENT = value; } }      

    public string Country_Origin { get { return _Country_Origin; } set { _Country_Origin = value; } }
    public string Country_Shipment { get { return _Country_Shipment; } set { _Country_Shipment = value; } }
    public string MBL_MAWB_NO { get { return _MBL_MAWB_NO; } set { _MBL_MAWB_NO = value; } }
    public string HBL_HAWB_NO { get { return _HBL_HAWB_NO; } set { _HBL_HAWB_NO = value; } }
    public string MAWB_HAWB_date { get { return _MAWB_HAWB_date; } set { _MAWB_HAWB_date = value; } }
    public string NO_OF_PACKAGE { get { return _NO_OF_PACKAGE; } set { _NO_OF_PACKAGE = value; } }
    public string GROSS_WEIGHT { get { return _GROSS_WEIGHT; } set { _GROSS_WEIGHT = value; } }
    public string MARKS_NOS { get { return _MARKS_NOS; } set { _MARKS_NOS = value; } }
    public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    public string JOBDATE { get { return _JOBDATE; } set { _JOBDATE = value; } }
    public string BE_TYPE { get { return _BE_TYPE; } set { _BE_TYPE = value; } }
    public string BE_TYPE_New { get { return _BE_TYPE_New; } set { _BE_TYPE_New = value; } }


    public string WAREHOUSE_CODE { get { return _WAREHOUSE_CODE; } set { _WAREHOUSE_CODE = value; } }
    
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
    public string FILING_STATUS { get { return _FILING_STATUS; } set { _FILING_STATUS = value; } }
    public string SECTION46 { get { return _SECTION46; } set { _SECTION46 = value; } }
    public string FIRSTCHECK { get { return _FIRSTCHECK; } set { _FIRSTCHECK = value; } }

    public string FIRSTCHECK_DESC { get { return _FIRSTCHECK_DESC; } set { _FIRSTCHECK_DESC = value; } }

    public string GREEN_CHANNEL { get { return _GREEN_CHANNEL; } set { _GREEN_CHANNEL = value; } }
    public string HIGH_SEA_SALE_YN { get { return _HIGH_SEA_SALE_YN; } set { _HIGH_SEA_SALE_YN = value; } }
    public string HIGH_SEA_SALE_NAME { get { return _HIGH_SEA_SALE_NAME; } set { _HIGH_SEA_SALE_NAME = value; } }
    public string HIGH_SEA_IEC { get { return _HIGH_SEA_IEC; } set { _HIGH_SEA_IEC = value; } }
    public string HIGH_SEA_BRANCH_SL_NO { get { return _HIGH_SEA_BRANCH_SL_NO; } set { _HIGH_SEA_BRANCH_SL_NO = value; } }
    public string HSS_ADD1 { get { return _HSS_ADD1; } set { _HSS_ADD1 = value; } }
    public string HSS_ADD2 { get { return _HSS_ADD2; } set { _HSS_ADD2 = value; } }
    public string HSS_ADD3 { get { return _HSS_ADD3; } set { _HSS_ADD3 = value; } }
    public string HSS_ADD4 { get { return _HSS_ADD4; } set { _HSS_ADD4 = value; } }
    public string HSS_ADD5 { get { return _HSS_ADD5; } set { _HSS_ADD5 = value; } }
    public string KACHHA_BE { get { return _KACHHA_BE; } set { _KACHHA_BE = value; } }
    public string SECTION48 { get { return _SECTION48; } set { _SECTION48 = value; } }
    public string SECTION48_DESC { get { return _SECTION48_DESC; } set { _SECTION48_DESC = value; } }
    public string PROVISIONAL { get { return _PROVISIONAL; } set { _PROVISIONAL = value; } }
    public string IMP_EXP_TYPE { get { return _IMP_EXP_TYPE; } set { _IMP_EXP_TYPE = value; } }
    public string SVB_STATUS { get { return _SVB_STATUS; } set { _SVB_STATUS = value; } }
    public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }
   
    public string IMP_EXP_PAN_NO { get { return _IMP_EXP_PAN_NO; } set { _IMP_EXP_PAN_NO = value; } }


    public string ADCODE { get { return _ADCODE; } set { _ADCODE = value; } }
    public string UCR_NO { get { return _UCR_NO; } set { _UCR_NO = value; } }
    public string UCR_TYPE { get { return _UCR_TYPE; } set { _UCR_TYPE = value; } }
    public string PAYMENT_METHOD_CODE { get { return _PAYMENT_METHOD_CODE; } set { _PAYMENT_METHOD_CODE = value; } }
    public string PRECEDING_LEVEL { get { return _PRECEDING_LEVEL; } set { _PRECEDING_LEVEL = value; } }

    public string PARTY_REF_NO { get { return _PARTY_REF_NO; } set { _PARTY_REF_NO = value; } }
    public string COMMERCIAL_TAX_REGISTRATION_NO { get { return _COMMERCIAL_TAX_REGISTRATION_NO; } set { _COMMERCIAL_TAX_REGISTRATION_NO = value; } }
    public string USERID { get { return _USERID; } set { _USERID = value; } }

    

    #endregion
    #region Private_Attributes

    //General Details

    private string _EXBOND_INBOND_BE_NO;
    private string _EXBOND_INBOND_BE_DATE;
    private string _EXBOND_BOND_NO;
    private string _EXBOND_BOND_DATE;
    private string _EXBOND_WAREHOUSE_CUSTOMS;
    private string _EXBOND_WAREHOUSE_CUSTOMS_CODE;
    private string _EXBOND_NOOFPACKAGE;
    private string _EXBOND_NOOFPACKAGE_UNITCODE;
    private string _EXBOND_GROSS_WEIGHT;
    private string _EXBOND_GROSS_WEIGHT_UNITCODE;
    private string _EXBOND_DIRECT_EXBONDING;

    #endregion

    #region Public_Attributes

    //General Details


    public string EXBOND_INBOND_BE_NO { get { return _EXBOND_INBOND_BE_NO; } set { _EXBOND_INBOND_BE_NO = value; } }
    public string EXBOND_INBOND_BE_DATE { get { return _EXBOND_INBOND_BE_DATE; } set { _EXBOND_INBOND_BE_DATE = value; } }
    public string EXBOND_BOND_NO { get { return _EXBOND_BOND_NO; } set { _EXBOND_BOND_NO = value; } }
    public string EXBOND_BOND_DATE { get { return _EXBOND_BOND_DATE; } set { _EXBOND_BOND_DATE = value; } }
    public string EXBOND_WAREHOUSE_CUSTOMS { get { return _EXBOND_WAREHOUSE_CUSTOMS; } set { _EXBOND_WAREHOUSE_CUSTOMS = value; } }
    public string EXBOND_WAREHOUSE_CUSTOMS_CODE { get { return _EXBOND_WAREHOUSE_CUSTOMS_CODE; } set { _EXBOND_WAREHOUSE_CUSTOMS_CODE = value; } }
    public string EXBOND_NOOFPACKAGE { get { return _EXBOND_NOOFPACKAGE; } set { _EXBOND_NOOFPACKAGE = value; } }
    public string EXBOND_NOOFPACKAGE_UNITCODE { get { return _EXBOND_NOOFPACKAGE_UNITCODE; } set { _EXBOND_NOOFPACKAGE_UNITCODE = value; } }
    public string EXBOND_GROSS_WEIGHT { get { return _EXBOND_GROSS_WEIGHT; } set { _EXBOND_GROSS_WEIGHT = value; } }
    public string EXBOND_GROSS_WEIGHT_UNITCODE { get { return _EXBOND_GROSS_WEIGHT_UNITCODE; } set { _EXBOND_GROSS_WEIGHT_UNITCODE = value; } }
    public string EXBOND_DIRECT_EXBONDING { get { return _EXBOND_DIRECT_EXBONDING; } set { _EXBOND_DIRECT_EXBONDING = value; } }

    #endregion

    public string SELECT_TYPE, SELECT_BRANCH;
    public string working_period;
    private string _Workingperiod, _INVOICE_ID;
    public string INVOICE_ID { get { return _INVOICE_ID; } set { _INVOICE_ID = value; } }
    public string MIS_CHARGES_Add;
    public string INVOICE_EXCHANGERATE;
    DataSet ds = new DataSet();
   
    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;

    CheckList CHKLIST = new CheckList();
    WareHouseReportDetails wh = new WareHouseReportDetails();

    //Customer c = new Customer();
    Date_Time dt = new Date_Time();

    public void Retrieve_GetGeneral(string ddlJobNo)
    {
       
        currentuser = HttpContext.Current.Session["currentuser"].ToString();
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        currentcomp_name = HttpContext.Current.Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();

            // commented for areawise implementation on 05-mar-2020
        /*

        SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

        if (HttpContext.Current.Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

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

         *   * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        CHKLIST.JOBNo = ddlJobNo;
        CHKLIST.Ename = "Checklist";
        CHKLIST.Workingperiod = SELECT_BRANCH;
        ds.Clear();
        ds = CHKLIST.RetrieveAll_Details();
        HttpContext.Current.Session["IMPORT_CHECKLIST"] = ds;
      
    }

    //----------------------ramkannu---------------------------------//
    public void Retrieve_GetGeneral_CusRes_Report(string ddlJobNo)
    {

        currentuser = HttpContext.Current.Session["currentuser"].ToString();
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        currentcomp_name = HttpContext.Current.Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();

        // commented for areawise implementation on 05-mar-2020
        /*
        SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

        if (HttpContext.Current.Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

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

        CHKLIST.JOBNo = ddlJobNo;
        CHKLIST.Ename = "CusRes_Report";
        CHKLIST.Workingperiod = SELECT_BRANCH;
        ds.Clear();
        ds = CHKLIST.CusRes_Report();
        //HttpContext.Current.Session["IMPORT_CHECKLIST"] = ds;
    }
    //--------------------------------------------------------------//
    //----------------------Chitra---------------------------------//
    public void Retrieve_GetGeneral_Firstpage(string ddlJobNo)
    {

        currentuser = HttpContext.Current.Session["currentuser"].ToString();
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        currentcomp_name = HttpContext.Current.Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
          // commented for areawise implementation on 05-mar-2020
        /*
        SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

        if (HttpContext.Current.Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

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
         *  * */
        SELECT_BRANCH = Connection.Get_Company_Type();

        CHKLIST.JOBNo = ddlJobNo;
        CHKLIST.Ename = "Exbond_JobWiseReport";
        CHKLIST.Workingperiod = SELECT_BRANCH;
        ds.Clear();
        ds = CHKLIST.RetrieveAll_Details();
        //HttpContext.Current.Session["IMPORT_CHECKLIST11"] = ds;

    }
    public void Retrieve_GetWareHouse_Report(string ddlJobNo)
    {

        currentuser = HttpContext.Current.Session["currentuser"].ToString();
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        currentcomp_name = HttpContext.Current.Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
          // commented for areawise implementation on 05-mar-2020
        /*

        SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

        if (HttpContext.Current.Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

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

        wh.JOBNO = ddlJobNo;
        wh.Ename = "Exbond_Report";
        ds.Clear();
        ds = wh.RetrieveAll_WareHouse_Details();
        HttpContext.Current.Session["IMPORT_CHECKLIST"] = ds;

    }

    public void Retrieve_GetWareHouse_General(string ddlJobNo)
    {

        currentuser = HttpContext.Current.Session["currentuser"].ToString();
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        currentcomp_name = HttpContext.Current.Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();

         // commented for areawise implementation on 05-mar-2020
        /*
        SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

        if (HttpContext.Current.Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

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

         *   * */
        SELECT_BRANCH = Connection.Get_Company_Type();

        wh.Working_Period = SELECT_BRANCH;
        wh.JOBNO = ddlJobNo;
        wh.Ename = "Exbond_Report";
        ds.Clear();
        ds = wh.RetrieveAll_WareHouse_Details();
        HttpContext.Current.Session["IMPORT_CHECKLIST"] = ds;

    }
    //----------------------Chitra---------------------------------//

    public void Retrieve_GetImport_Annexure(string ddlJobNo)
    {

        currentuser = HttpContext.Current.Session["currentuser"].ToString();
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        currentcomp_name = HttpContext.Current.Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
        
    // commented for areawise implementation on 05-mar-2020
        /*
        SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

        if (HttpContext.Current.Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

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
         *  * */
        SELECT_BRANCH = Connection.Get_Company_Type();

        CHKLIST.JOBNo = ddlJobNo;
        CHKLIST.Ename = "Import_Annexure";
        CHKLIST.Workingperiod = SELECT_BRANCH;
        ds.Clear();
        ds = CHKLIST.Retrieve_Import_Annexure_Report_Details();
        HttpContext.Current.Session["IMPORT_CHECKLIST"] = ds;

    }
    public List<General_Details> GetGeneral1(DataTable ds, string ddlJobNo)
    {

        List<General_Details> list = new List<General_Details>();

        Auto_Search auto = new Auto_Search();
        if (ds.Rows.Count > 0)
        {
            string custom = ds.Rows[0]["CUSTOMS_HOUSE"].ToString();
            string custom_name="";// = ds.Rows[0]["CUSTOMS_HOUSE_NAME"].ToString(); // Hided by pandiyan on 29/08/2025 due to customhouse name will get directly from master bcoz sometimes showing invalid name
            string custid = "", name = "", rows = "";
            if (custom != "")   // && custom_name == "")
            {
                custom_name = auto.Country_Master_FromClientSide_Calling(custid = custom, name = "CUSTOM_HOUSE_MASTER_CUSTOM_NAME", rows = "CUSTOMHOUSE_NAME");
            }
            custom = custom + ", " + custom_name;
            BE_TYPE = ds.Rows[0]["BE_TYPE"].ToString();
            WAREHOUSE_CODE = ds.Rows[0]["WAREHOUSE_CODE"].ToString();


            HttpContext.Current.Session["CHECKLIST_BE_TYPE"] = BE_TYPE;
            if (BE_TYPE == "Home" || BE_TYPE == "HOME")
            {
                BE_TYPE = BE_TYPE + " " + "Consumption";
            }
            else if (BE_TYPE == "Warehouse")
            {
                BE_TYPE = BE_TYPE + ", " + "W.Code :" + WAREHOUSE_CODE;

                //BE_TYPE = BE_TYPE + " " + "<b>" + "W.Code :" + "</b>" + WAREHOUSE_CODE;
                               
            }

            FILING_STATUS = ds.Rows[0]["FILING_STATUS"].ToString().Substring(0, 1);
            if (FILING_STATUS == "P")
            {
                FILING_STATUS = "Y";
            }


            IMP_EXP_TYPE = ds.Rows[0]["IMP_EXP_TYPE"].ToString();
            
            if (IMP_EXP_TYPE == "GOVERNMENT" || IMP_EXP_TYPE == "GOVERNMENT DEPARTMENTS")
            {
                IMP_EXP_TYPE = "G";
            }
            else if (IMP_EXP_TYPE == "GOVERNMENT UNDERTAKINGS")
            {
                IMP_EXP_TYPE = "U";
            }
            else if (IMP_EXP_TYPE == "OTHERS")
            {
                IMP_EXP_TYPE = "O";
            }
            else if (IMP_EXP_TYPE == "PRIVATE")
            {
                IMP_EXP_TYPE = "P";
            }
            else if (IMP_EXP_TYPE == "JOBBING")
            {
                IMP_EXP_TYPE = "J";
            }
            else if (IMP_EXP_TYPE == "REPAIR & RETURN")
            {
                IMP_EXP_TYPE = "R";
            }
            else if (IMP_EXP_TYPE == "EXHIBITION")
            {
                IMP_EXP_TYPE = "E";
            }
            else if (IMP_EXP_TYPE == "DESTRUCTION")
            {
                IMP_EXP_TYPE = "D";
            }
            else if (IMP_EXP_TYPE == "MOVEMENT OF GOODS" || IMP_EXP_TYPE == "VESSELS")
            {
                IMP_EXP_TYPE = "V";
            }
            else if (IMP_EXP_TYPE == "SAMPLE TESTING")
            {
                IMP_EXP_TYPE = "T";
            }
            else if (IMP_EXP_TYPE == "SHIP STORES")
            {
                IMP_EXP_TYPE = "S";
            }
            else if (IMP_EXP_TYPE == "NEW AIRCRAFT")
            {
                IMP_EXP_TYPE = "A";
            }
            else if (IMP_EXP_TYPE == "HAND CARRIAGE")
            {
                IMP_EXP_TYPE = "H";
            }
            else if (IMP_EXP_TYPE == "UNCLAIMED CARGO")
            {
                IMP_EXP_TYPE = "I";
            }
            else if (IMP_EXP_TYPE == "TRADING")
            {
                IMP_EXP_TYPE = "T";
            }
            else if (IMP_EXP_TYPE == "MANUFATURED GOODS")
            {
                IMP_EXP_TYPE = "M";
            }
            else if (IMP_EXP_TYPE == "CBW")
            {
                IMP_EXP_TYPE = "W";
            }
            else if (IMP_EXP_TYPE == "SEZ-T TO SEZ")
            {
                IMP_EXP_TYPE = "B";
            }
            else if (IMP_EXP_TYPE == "SEZ-M TO SEZ")
            {
                IMP_EXP_TYPE = "F";
            }
            else
            {
                IMP_EXP_TYPE = "P";
            }

            //if (BE_TYPE == "Warehouse")

               // BE_TYPE = BE_TYPE + " " + "Consumption";

           // string BE_dt = ds.Tables[0].Rows[0]["BE_DATE"].ToString();
            string BE_dt = "";
            if (BE_dt == "01/01/1900")
            {
                BE_dt = "";
            }

            //BE_NO = ds.Tables[0].Rows[0]["BE_NO"].ToString() + " " + BE_dt;
            BE_NO = "";

            IMP_EXP_PAN_NO = ds.Rows[0]["IMP_EXP_PAN_NO"].ToString();

            ADCODE = ds.Rows[0]["ADCODE"].ToString();
            //#HSS_ADCODE -- hide on 12-04_2025 sugg.by Bala sir - Implemented for common all
            //if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "2046" || Connection.COMPANYID() == "2059" || Connection.COMPANYID() == "2514")
            //{
                //if (ds.Rows[0]["HIGH_SEA_SALE"].ToString() == "Y")
                //{
                //    ADCODE = ds.Rows[0]["HSS_ADCODE"].ToString() + "(HSS)";
                //}
            //}

            //#HSS_ADCODE
            if (ds.Rows[0]["HIGH_SEA_SALE"].ToString() == "Y")
            {
                if (ds.Rows[0]["HSS_ADCODE"].ToString() != "")
                {
                    ADCODE = ds.Rows[0]["HSS_ADCODE"].ToString() + "(HSS)";
                }
            }

            USERID = ""; // Job created by Show in Checklist
            if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "2145" || Connection.COMPANYID() == "2478")// Capricorn
            {
                USERID = ds.Rows[0]["USERID"].ToString();
            }
            


            list.Add(new General_Details()
            {
                JOB_NO = ddlJobNo,
                Today_dt = dt.Today_Date(),
                JOBDATE = ds.Rows[0]["JOBDATE"].ToString(),
                BE_TYPE = BE_TYPE,
                CUSTOMS_HOUSE = custom,
                Importer_Name = ds.Rows[0]["IMPORTER_NAME"].ToString(),
                Add1 = ds.Rows[0]["ADDRESS1"].ToString(),
                Add2 = ds.Rows[0]["ADDRESS2"].ToString(),
                Add3 = ds.Rows[0]["ADDRESS3"].ToString(),
                City = ds.Rows[0]["ADDRESS4"].ToString(),
                Pincode = ds.Rows[0]["ADDRESS5"].ToString(),
                IEC_NO = ds.Rows[0]["IEC_NO"].ToString(),
                BRANCH_NO = ds.Rows[0]["BRANCH_NO"].ToString(),
                PORT_ORIGIN = dt.Split("-",ds.Rows[0]["PORT_ORIGIN"].ToString()),
                PORT_SHIPMENT = dt.Split("-", ds.Rows[0]["PORT_SHIPMENT"].ToString()),

                Country_Origin = dt.Split("-",ds.Rows[0]["COUNTRY_ORIGIN"].ToString()),
                Country_Shipment = dt.Split("-",ds.Rows[0]["COUNTRY_SHIPMENT"].ToString()),
                TRANSPORT_MODE = ds.Rows[0]["TRANSPORT_MODE"].ToString().Substring(0, 1),

                SECTION46 = ds.Rows[0]["SECTION46"].ToString(),
                FIRSTCHECK = ds.Rows[0]["FIRSTCHECK"].ToString(),
                FIRSTCHECK_DESC = ds.Rows[0]["FIRSTCHECK_DESC"].ToString(),

                GREEN_CHANNEL = ds.Rows[0]["GREEN_CHANNEL"].ToString(),
                KACHHA_BE = ds.Rows[0]["KACHHA_BE"].ToString(),
                SECTION48 = ds.Rows[0]["SECTION48"].ToString(),
                SECTION48_DESC = ds.Rows[0]["SECTION48_DESC"].ToString(),
                PROVISIONAL = ds.Rows[0]["PROVISIONAL"].ToString(),

                HIGH_SEA_SALE_NAME = ds.Rows[0]["HIGH_SEA_SALE_NAME"].ToString(),
                HIGH_SEA_IEC = ds.Rows[0]["HIGH_SEA_IEC"].ToString(),
                HIGH_SEA_BRANCH_SL_NO = ds.Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString(),
                HSS_ADD1 = ds.Rows[0]["HSS_ADD1"].ToString(),
                HSS_ADD2 = ds.Rows[0]["HSS_ADD2"].ToString(),
                HSS_ADD3 = ds.Rows[0]["HSS_ADD3"].ToString(),
                HSS_ADD4 = ds.Rows[0]["HSS_ADD4"].ToString(),
                HSS_ADD5 = ds.Rows[0]["HSS_ADD5"].ToString(),
                IMP_EXP_TYPE = IMP_EXP_TYPE + "        " + "Prior BE :" + FILING_STATUS,
                SVB_STATUS = ds.Rows[0]["SVB_ASSESABLE_STATUS"].ToString(),
                FILE_REF_NO = ds.Rows[0]["FILE_REF_NO"].ToString(),
                IMP_EXP_PAN_NO = IMP_EXP_PAN_NO,

                ADCODE = ADCODE,
                UCR_NO = ds.Rows[0]["UCR_NO"].ToString(),
                UCR_TYPE = ds.Rows[0]["UCR_TYPE"].ToString(),
                PAYMENT_METHOD_CODE = ds.Rows[0]["PAYMENT_METHOD_CODE"].ToString(),
                PARTY_REF_NO = ds.Rows[0]["PARTY_REF_NO"].ToString(),
                COMMERCIAL_TAX_REGISTRATION_NO = ds.Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString(),
                USERID = USERID,
                BE_TYPE_New = ds.Rows[0]["BE_TYPE_New"].ToString()

                //IMP_EXP_PAN_NO = ds.Tables[0].Rows[0]["IMP_EXP_PAN_NO"].ToString()

            });



        }
        return list;
    }
    public List<General_Details> GetGeneral(string ddlJobNo)
    {
        //Customer c = new Customer();

        currentuser = HttpContext.Current.Session["currentuser"].ToString();
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        currentcomp_name = HttpContext.Current.Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
        // commented for areawise implementation on 05-mar-2020
        /*
        SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

        if (HttpContext.Current.Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

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

        CHKLIST.JOBNo = ddlJobNo;
        CHKLIST.Ename = "Checklist";
        CHKLIST.Workingperiod = SELECT_BRANCH;
        ds.Clear();
        ds = CHKLIST.RetrieveAll_Details();
        HttpContext.Current.Cache["IMPORT_CHECKLIST"] = ds;
        List<General_Details> list = new List<General_Details>();
        Auto_Search auto = new Auto_Search();
        //list.Clear();

        //int i = 0;
        //foreach (DataRow dr in ds.Tables[0].Rows)

        if (ds.Tables[0].Rows.Count > 0)
        {
            string custom = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
            string custom_name = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString();
            string custid = "", name = "", rows = "";
            if (custom != "" && custom_name == "")
            {
                custom_name = auto.Country_Master_FromClientSide_Calling(custid = custom, name = "CUSTOM_HOUSE_MASTER_CUSTOM_NAME", rows = "CUSTOMHOUSE_NAME");
            }
            custom = custom + ", " + custom_name;
            list.Add(new General_Details()
            {
                JOB_NO = ddlJobNo,
                Today_dt = dt.Today_Date(),
                JOBDATE = ds.Tables[0].Rows[0]["JOBDATE"].ToString(),

                BE_TYPE = ds.Tables[0].Rows[0]["BE_TYPE"].ToString(),
                CUSTOMS_HOUSE = custom,
                Importer_Name = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString(),
                Add1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString(),
                Add2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString(),
                Add3 = ds.Tables[0].Rows[0]["ADDRESS3"].ToString(),
                City = ds.Tables[0].Rows[0]["ADDRESS4"].ToString(),
                Pincode = ds.Tables[0].Rows[0]["ADDRESS5"].ToString(),
                IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString(),
                BRANCH_NO = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString(),
                PORT_ORIGIN = ds.Tables[0].Rows[0]["PORT_ORIGIN"].ToString(),
                Country_Origin = ds.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString(),
                Country_Shipment = ds.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString(),
                TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString().Substring(0, 1),

                SECTION46 = ds.Tables[0].Rows[0]["SECTION46"].ToString(),
                FIRSTCHECK = ds.Tables[0].Rows[0]["FIRSTCHECK"].ToString(),
                GREEN_CHANNEL = ds.Tables[0].Rows[0]["GREEN_CHANNEL"].ToString(),
                KACHHA_BE = ds.Tables[0].Rows[0]["KACHHA_BE"].ToString(),
                SECTION48 = ds.Tables[0].Rows[0]["SECTION48"].ToString(),
                SECTION48_DESC = ds.Tables[0].Rows[0]["SECTION48_DESC"].ToString(),
                HIGH_SEA_SALE_NAME = ds.Tables[0].Rows[0]["HIGH_SEA_SALE_NAME"].ToString(),
                HIGH_SEA_IEC = ds.Tables[0].Rows[0]["HIGH_SEA_IEC"].ToString(),
                HIGH_SEA_BRANCH_SL_NO = ds.Tables[0].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString(),
                HSS_ADD1 = ds.Tables[0].Rows[0]["HSS_ADD1"].ToString(),
                HSS_ADD2 = ds.Tables[0].Rows[0]["HSS_ADD2"].ToString(),
                HSS_ADD3 = ds.Tables[0].Rows[0]["HSS_ADD3"].ToString(),
                HSS_ADD4 = ds.Tables[0].Rows[0]["HSS_ADD4"].ToString(),
                HSS_ADD5 = ds.Tables[0].Rows[0]["HSS_ADD5"].ToString(),
                IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString().Substring(0, 1) + "        " + "Prior BE :" + ds.Tables[0].Rows[0]["FILING_STATUS"].ToString().Substring(0, 1),
                FILE_REF_NO = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString(),
                IMP_EXP_PAN_NO = ds.Tables[0].Rows[0]["IMP_EXP_PAN_NO"].ToString()

            });
        }
        return list;
    }

    public List<General_Details> Import_Annexure_GetGeneral(DataSet ds, string ddlJobNo)
    {

        List<General_Details> list = new List<General_Details>();

        Auto_Search auto = new Auto_Search();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string custom = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
            string custom_name = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString();
            string custid = "", name = "", rows = "";
            if (custom != "" && custom_name == "")
            {
                custom_name = auto.Country_Master_FromClientSide_Calling(custid = custom, name = "CUSTOM_HOUSE_MASTER_CUSTOM_NAME", rows = "CUSTOMHOUSE_NAME");
            }
            custom = custom + ", " + custom_name;
            BE_TYPE = ds.Tables[0].Rows[0]["BE_TYPE"].ToString();
            HttpContext.Current.Session["CHECKLIST_BE_TYPE"] = BE_TYPE;
            if (BE_TYPE == "Home" || BE_TYPE == "HOME")

                BE_TYPE = BE_TYPE + " " + "Consumption";

            IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
            if (IMP_EXP_TYPE == "OTHERS")
            {
                IMPORTER_TYPE_PRIVATE = TICK_MARK;
                IMPORTER_TYPE_GOVT="";
            }
            else if (IMP_EXP_TYPE == "GOVERNMENT")
            {
                IMPORTER_TYPE_GOVT = TICK_MARK;
                IMPORTER_TYPE_PRIVATE = "";
            }
            else
            {
                IMPORTER_TYPE_PRIVATE = TICK_MARK;
                IMPORTER_TYPE_GOVT = "";
            }


            if (BE_TYPE == "Home Consumption")
            {
                HOME_CONSUMPTION = TICK_MARK;
                WAREHOUSE = "";
                EXBOND = "";
            }
            else if (BE_TYPE == "Warehouse")
            {
                  HOME_CONSUMPTION = "";
                  WAREHOUSE = TICK_MARK;
                EXBOND = "";
            }
            else if (BE_TYPE == "Ex-Bond")
            {
                  HOME_CONSUMPTION = "";
                WAREHOUSE = "";
                EXBOND = TICK_MARK;
            }

            FILING_STATUS = ds.Tables[0].Rows[0]["FILING_STATUS"].ToString();
            if(FILING_STATUS=="Normal")
            {
                NORMAL = TICK_MARK;
                ADVANCE = "";
                PRIOR = "";
            }
            else if(FILING_STATUS=="Advanced")
            {
                NORMAL = "";
                ADVANCE = TICK_MARK;
                PRIOR = "";
            }
            else if(FILING_STATUS=="Prior")
            {
                NORMAL = "";
                ADVANCE = "";
                PRIOR = TICK_MARK;
            }
            HSS_ADD2 = ds.Tables[0].Rows[0]["HSS_ADD2"].ToString();
                HSS_ADD3 = ds.Tables[0].Rows[0]["HSS_ADD3"].ToString();
                HSS_ADD4 = ds.Tables[0].Rows[0]["HSS_ADD4"].ToString();
                HSS_ADD5 = ds.Tables[0].Rows[0]["HSS_ADD5"].ToString();
                 if (HSS_ADD3 != "")
                    HSS_ADD3 = "," + HSS_ADD3;
                 else if (HSS_ADD2 == "")
                 {
                     HSS_ADD3 = HSS_ADD3;
                 }

                 if (HSS_ADD5 != "")
                     HSS_ADD5 = "," + HSS_ADD5;
                 else if (HSS_ADD4 == "")
                 {
                     HSS_ADD5 = HSS_ADD5;
                 }
                 HIGH_SEA_SALE_NAME = ds.Tables[0].Rows[0]["HIGH_SEA_SALE_NAME"].ToString();
                 if (HIGH_SEA_SALE_NAME != "")
                     HIGH_SEA_SALE_YN = "Yes";
                 else
                     HIGH_SEA_SALE_YN = "No";
             if((HIGH_SEA_BRANCH_SL_NO = ds.Tables[0].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString())=="0")
            {
                HIGH_SEA_BRANCH_SL_NO = "";
            }

            //if (BE_TYPE == "Warehouse")

            // BE_TYPE = BE_TYPE + " " + "Consumption";
            Exbond_Details Exbond = new Exbond_Details();
            Exbond.Get_Exbond_Details(ds.Tables[0]);
            list.Add(new General_Details()
            {
                JOB_NO = ddlJobNo,
                Today_dt = dt.Today_Date(),
                JOBDATE = ds.Tables[0].Rows[0]["JOBDATE"].ToString(),

                BE_TYPE = BE_TYPE,
                CUSTOMS_HOUSE = custom,
                Importer_Name = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString(),
                Add1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString(),
                Add2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString(),
                Add3 = ds.Tables[0].Rows[0]["ADDRESS3"].ToString(),
                City = ds.Tables[0].Rows[0]["ADDRESS4"].ToString(),
                Pincode = ds.Tables[0].Rows[0]["ADDRESS5"].ToString(),
                IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString(),
                BRANCH_NO = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString(),
                PORT_ORIGIN = dt.Split("-", ds.Tables[0].Rows[0]["PORT_ORIGIN"].ToString()),
                Country_Origin = dt.Split("-", ds.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString()),
                Country_Shipment = dt.Split("-", ds.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString()),
                TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString().Substring(0, 1),
                SECTION46 = ds.Tables[0].Rows[0]["SECTION46"].ToString(),
                FIRSTCHECK = ds.Tables[0].Rows[0]["FIRSTCHECK"].ToString(),
                GREEN_CHANNEL = ds.Tables[0].Rows[0]["GREEN_CHANNEL"].ToString(),
                KACHHA_BE = ds.Tables[0].Rows[0]["KACHHA_BE"].ToString(),
                SECTION48 = ds.Tables[0].Rows[0]["SECTION48"].ToString(),
                SECTION48_DESC = ds.Tables[0].Rows[0]["SECTION48_DESC"].ToString(),
                HIGH_SEA_SALE_NAME = ds.Tables[0].Rows[0]["HIGH_SEA_SALE_NAME"].ToString(),
                HIGH_SEA_IEC = ds.Tables[0].Rows[0]["HIGH_SEA_IEC"].ToString(),
                HIGH_SEA_BRANCH_SL_NO = HIGH_SEA_BRANCH_SL_NO,
                HIGH_SEA_SALE_YN=HIGH_SEA_SALE_YN,
                HSS_ADD1 = ds.Tables[0].Rows[0]["HSS_ADD1"].ToString(),
                HSS_ADD2 = HSS_ADD2,
                HSS_ADD3 = HSS_ADD3,
                HSS_ADD4 = HSS_ADD4,
                HSS_ADD5 = HSS_ADD5,
                //IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString().Substring(0, 1) + "        " + "Prior BE :" + ds.Tables[0].Rows[0]["FILING_STATUS"].ToString().Substring(0, 1),
                IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString(),
                EXBOND_INBOND_BE_NO = Exbond.EXBOND_INBOND_BE_NO,
                EXBOND_INBOND_BE_DATE = Exbond.EXBOND_INBOND_BE_DATE,
                EXBOND_BOND_NO = Exbond.EXBOND_BOND_NO,
                EXBOND_BOND_DATE = Exbond.EXBOND_BOND_DATE,
                EXBOND_WAREHOUSE_CUSTOMS = Exbond.EXBOND_WAREHOUSE_CUSTOMS,
                EXBOND_WAREHOUSE_CUSTOMS_CODE = Exbond.EXBOND_WAREHOUSE_CUSTOMS_CODE,
                EXBOND_NOOFPACKAGE = Exbond.EXBOND_NOOFPACKAGE,
                EXBOND_NOOFPACKAGE_UNITCODE = Exbond.EXBOND_NOOFPACKAGE_UNITCODE,
                EXBOND_GROSS_WEIGHT = Exbond.EXBOND_GROSS_WEIGHT,
                EXBOND_GROSS_WEIGHT_UNITCODE = Exbond.EXBOND_GROSS_WEIGHT_UNITCODE,
                IMPORTER_TYPE_PRIVATE = IMPORTER_TYPE_PRIVATE,
                IMPORTER_TYPE_GOVT = IMPORTER_TYPE_GOVT,

                HOME_CONSUMPTION = HOME_CONSUMPTION,
                WAREHOUSE = WAREHOUSE,
                EXBOND = EXBOND,
                NORMAL = NORMAL,
                PRIOR = PRIOR,
                ADVANCE = ADVANCE,
                ADCODE = ds.Tables[0].Rows[0]["ADCODE"].ToString(),
                //UCR_NO = ds.Tables[0].Rows[0]["UCR_NO"].ToString(),
                //UCR_TYPE = ds.Tables[0].Rows[0]["UCR_TYPE"].ToString(),
                PAYMENT_METHOD_CODE = ds.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString(),
                PRECEDING_LEVEL = ds.Tables[0].Rows[0]["PRECEDING_LEVEL"].ToString()

                
            });
        }
        return list;
    }
}