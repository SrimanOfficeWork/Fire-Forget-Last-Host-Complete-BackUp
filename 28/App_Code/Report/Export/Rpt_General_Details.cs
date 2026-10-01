using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for Rpt_General_Details
/// </summary>
public class Rpt_General_Details
{
    
    Date_Time dt = new Date_Time();
    DataSet ds = new DataSet();

    public string ddlJobNo;

    public string select_branch = "", select_type = ""; 
   

    #region Private_Attributes
   
    private string _Today_dt;
     
    private string _JOBNO;
    private string _JOBDATE;
    private string _TRANSPORT_MODE;
    private string _CUSTOMS_HOUSE;
    private string _SB_TYPE;
    private string _EXPORTER_NAME;
    private string _BRANCH_NO;
    private string _IEC_NO;
    private string _ADDRESS1;
    private string _ADDRESS2;
    private string _ADDRESS3;
    private string _ADDRESS4;
    private string _ADDRESS5;
    private string _ADCODE;
    private string _BANK_ACCOUNT;
    private string _DRAWBACK_ACCOUNT;
    private string _CONSIGNEE_NAME;
    private string _CONSIGNEE_ADD1;
    private string _CONSIGNEE_ADD2;
    private string _CONSIGNEE_ADD3;
    private string _CONSIGNEE_ADD4;
    private string _CONSIGNEE_ADD5;
    private string _COUNTRY_DISCHARGE;
    private string _PORT_DISCHARGE;
    private string _COUNTRY_FINAL_DEST;
    private string _PORT_FINAL_DEST;
    private string _STATE_OF_EXPORT;
    private string _NFEI;
    private string _NFEI_TYPE;
    private string _RBI_WAIVER_NO;
    private string _RBI_WAIVER_DATE;
    private string _MARKS_NO;

   
    private string _NATURE_OF_CARGO;
    private string _MARKS_NOS;
    private string _TOTAL_PACKAGES;
    private string _LOOSE_PACKETS;
    private string _NO_CONTAINERS;
    private string _GROSS_WEIGHT;
    private string _NET_WEIGHT;
    private string _ANNEX_AIR_MAWB_NO;
    private string _ANNEX_AIR_HAWB_NO;
    private string _ANNEX_AIR_GR_UNIT_CODE;
    private string _FOB_VALUE;
    private string _DRAWBACK_VALUE;
    
    private string _Working_Period;
    
    #endregion

    #region Public_Attributes

    public string Today_dt { get { return _Today_dt; } set { _Today_dt = value; } }

    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string JOBDATE { get { return _JOBDATE; } set { _JOBDATE = value; } }
    public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
    public string SB_TYPE { get { return _SB_TYPE; } set { _SB_TYPE = value; } }
    public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
    public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
    public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }
    public string ADCODE { get { return _ADCODE; } set { _ADCODE = value; } }
    public string BANK_ACCOUNT { get { return _BANK_ACCOUNT; } set { _BANK_ACCOUNT = value; } }
    public string DRAWBACK_ACCOUNT { get { return _DRAWBACK_ACCOUNT; } set { _DRAWBACK_ACCOUNT = value; } }
    public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
    public string CONSIGNEE_ADD1 { get { return _CONSIGNEE_ADD1; } set { _CONSIGNEE_ADD1 = value; } }
    public string CONSIGNEE_ADD2 { get { return _CONSIGNEE_ADD2; } set { _CONSIGNEE_ADD2 = value; } }
    public string CONSIGNEE_ADD3 { get { return _CONSIGNEE_ADD3; } set { _CONSIGNEE_ADD3 = value; } }
    public string CONSIGNEE_ADD4 { get { return _CONSIGNEE_ADD4; } set { _CONSIGNEE_ADD4 = value; } }
    public string CONSIGNEE_ADD5 { get { return _CONSIGNEE_ADD5; } set { _CONSIGNEE_ADD5 = value; } }
    public string COUNTRY_DISCHARGE { get { return _COUNTRY_DISCHARGE; } set { _COUNTRY_DISCHARGE = value; } }
    public string PORT_DISCHARGE { get { return _PORT_DISCHARGE; } set { _PORT_DISCHARGE = value; } }
    public string COUNTRY_FINAL_DEST { get { return _COUNTRY_FINAL_DEST; } set { _COUNTRY_FINAL_DEST = value; } }
    public string PORT_FINAL_DEST { get { return _PORT_FINAL_DEST; } set { _PORT_FINAL_DEST = value; } }
    public string STATE_OF_EXPORT { get { return _STATE_OF_EXPORT; } set { _STATE_OF_EXPORT = value; } }
    public string NFEI { get { return _NFEI; } set { _NFEI = value; } }
    public string NFEI_TYPE { get { return _NFEI_TYPE; } set { _NFEI_TYPE = value; } }
    public string RBI_WAIVER_NO { get { return _RBI_WAIVER_NO; } set { _RBI_WAIVER_NO = value; } }
    public string RBI_WAIVER_DATE { get { return _RBI_WAIVER_DATE; } set { _RBI_WAIVER_DATE = value; } }
    public string MARKS_NO { get { return _MARKS_NO; } set { _MARKS_NO = value; } }



    public string NATURE_OF_CARGO { get { return _NATURE_OF_CARGO; } set { _NATURE_OF_CARGO = value; } }
    public string MARKS_NOS { get { return _MARKS_NOS; } set { _MARKS_NOS = value; } }
    public string TOTAL_PACKAGES { get { return _TOTAL_PACKAGES; } set { _TOTAL_PACKAGES = value; } }
    public string LOOSE_PACKETS { get { return _LOOSE_PACKETS; } set { _LOOSE_PACKETS = value; } }
    public string NO_CONTAINERS { get { return _NO_CONTAINERS; } set { _NO_CONTAINERS = value; } }
    public string GROSS_WEIGHT { get { return _GROSS_WEIGHT; } set { _GROSS_WEIGHT = value; } }
    public string NET_WEIGHT { get { return _NET_WEIGHT; } set { _NET_WEIGHT = value; } }
    public string ANNEX_AIR_MAWB_NO { get { return _ANNEX_AIR_MAWB_NO; } set { _ANNEX_AIR_MAWB_NO = value; } }
    public string ANNEX_AIR_HAWB_NO { get { return _ANNEX_AIR_HAWB_NO; } set { _ANNEX_AIR_HAWB_NO = value; } }
    public string ANNEX_AIR_GR_UNIT_CODE { get { return _ANNEX_AIR_GR_UNIT_CODE; } set { _ANNEX_AIR_GR_UNIT_CODE = value; } }
    public string FOB_VALUE { get { return _FOB_VALUE; } set { _FOB_VALUE = value; } }
    public string DRAWBACK_VALUE { get { return _DRAWBACK_VALUE; } set { _DRAWBACK_VALUE = value; } }

    public string Working_Period
    {
        get { return _Working_Period; }
        set { _Working_Period = value; }
    }

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string LoginDate;

    #endregion
    public int is_Annexure_Mode = 0, is_STR_Code = 0;

    public void Retrieve_GetGeneral(string ddlJobNo)
    {
       
        Export_CheckList CHKLIST = new Export_CheckList();
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();

            // commented for areawise implementation on 05-mar-2020
        /*
        select_type = HttpContext.Current.Session["SELECT_TYPE"].ToString();

        if (select_type == "Branchwise Job")
        {
            select_branch = currentbranch;
        }
        else
        {
            select_branch = "";
        }
          * */
        select_branch = Connection.Get_Company_Type();

        CHKLIST.JOBNo = ddlJobNo;
        CHKLIST.Ename = "Checklist";
        CHKLIST.Workingperiod = select_branch;
        ds.Clear();
        ds = CHKLIST.RetrieveAll_General_Details();
        
        is_Annexure_Mode = CHKLIST.Is_Annexure;
        is_STR_Code = CHKLIST.Is_STR;

        HttpContext.Current.Session["EXPORT_CHECKLIST"] = ds;
        
    }
    public void Retrieve_GetExport_Annexure_Report(string ddlJobNo)
    {

        Export_CheckList CHKLIST = new Export_CheckList();
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        

    // commented for areawise implementation on 05-mar-2020
        /*
        select_type = HttpContext.Current.Session["SELECT_TYPE"].ToString();

        if (select_type == "Branchwise Job")
        {
            select_branch = currentbranch;
        }
        else
        {
            select_branch = "";
        }

        
  * */
        select_branch = Connection.Get_Company_Type();


        CHKLIST.JOBNo = ddlJobNo;
        CHKLIST.Ename = "Checklist";
        CHKLIST.Workingperiod = select_branch;
        ds.Clear();
        ds = CHKLIST.RetrieveAll_Import_Annexure_Report();
        //is_Annexure_Mode = CHKLIST.result;
        is_Annexure_Mode = CHKLIST.Is_Annexure;
        is_STR_Code = CHKLIST.Is_STR;

        HttpContext.Current.Session["EXPORT_CHECKLIST"] = ds;

    }
    public List<Rpt_General_Details> GetGeneral1(DataSet ds,int Annexue_Mode,int IS_STR)
    {


        is_Annexure_Mode = Annexue_Mode;
        is_STR_Code = IS_STR;
        List<Rpt_General_Details> list = new List<Rpt_General_Details>();
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
            TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
            if (is_Annexure_Mode == 1)
            {


                if (TRANSPORT_MODE == "Air")
                {
                    NATURE_OF_CARGO = ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString();

                    LOOSE_PACKETS = "";
                    NO_CONTAINERS = "";
                    ANNEX_AIR_MAWB_NO = ds.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString();
                    ANNEX_AIR_HAWB_NO = ds.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString();

                    if (NATURE_OF_CARGO == "P")
                    {
                        NATURE_OF_CARGO = "P Packaged";
                    }
                }
                else if (TRANSPORT_MODE == "Sea")
                {
                    NATURE_OF_CARGO = ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString();

                    LOOSE_PACKETS = ds.Tables[0].Rows[0]["LOOSE_PACKETS"].ToString();
                    NO_CONTAINERS = ds.Tables[0].Rows[0]["NO_CONTAINERS"].ToString();
                    ANNEX_AIR_MAWB_NO = "";
                    ANNEX_AIR_HAWB_NO = "";

                    if (NATURE_OF_CARGO == "C")
                    {
                        NATURE_OF_CARGO = "C Containerized";
                    }
                    else if (NATURE_OF_CARGO == "P")
                    {
                        NATURE_OF_CARGO = "P Packaged";
                    }
                    else if (NATURE_OF_CARGO == "CP")
                    {
                        NATURE_OF_CARGO = "CP Containerized";
                    }
                    else if (NATURE_OF_CARGO == "LB")
                    {
                        NATURE_OF_CARGO = "LB Liquid and Bulk";
                    }
                    else if (NATURE_OF_CARGO == "DB")
                    {
                        NATURE_OF_CARGO = "DB Dry Bulk";
                    }

                }
                TOTAL_PACKAGES = ds.Tables[0].Rows[0]["TOTAL_PACKAGES"].ToString();
                GROSS_WEIGHT = ds.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString();
                NET_WEIGHT = ds.Tables[0].Rows[0]["NET_WEIGHT"].ToString();
                MARKS_NOS = ds.Tables[0].Rows[0]["MARKS_NOS"].ToString();

            }
            else if (is_Annexure_Mode == 2)
            {
                if (TRANSPORT_MODE == "Air")
                {
                    NATURE_OF_CARGO = "";

                    LOOSE_PACKETS = "";
                    NO_CONTAINERS = "";
                    ANNEX_AIR_MAWB_NO = "";
                    ANNEX_AIR_HAWB_NO = "";

                }
                else if (TRANSPORT_MODE == "Sea")
                {
                    NATURE_OF_CARGO = "";

                    LOOSE_PACKETS = "";
                    NO_CONTAINERS = "";
                    ANNEX_AIR_MAWB_NO = "";
                    ANNEX_AIR_HAWB_NO = "";



                }
            }

            RBI_WAIVER_NO = ds.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString();
            RBI_WAIVER_DATE = ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString();
            if (RBI_WAIVER_DATE == "01/01/1900" || RBI_WAIVER_DATE == "01-01-1900")
            {
                RBI_WAIVER_DATE = "";
            }
            else
            {
                RBI_WAIVER_DATE = "/" + RBI_WAIVER_DATE;
            }
            //Calculate Total FOB And DRAWBACK Value
            Rpt_Item_Details ITEM = new Rpt_Item_Details();
            ITEM.Get_FOB_DRAWBACK_VALUE_Details(ddlJobNo, ds.Tables[1], ds.Tables[2], ds.Tables[5]);
            FOB_VALUE = Convert.ToString(ITEM.FOB_VALUE);
            DRAWBACK_VALUE = Convert.ToString(ITEM.DBK_VALUE);
            //Calculate Total FOB And DRAWBACK Value

            list.Add(new Rpt_General_Details()
            {
                JOBNO = ddlJobNo,
                Today_dt = dt.Today_Date(),
                JOBDATE = ds.Tables[0].Rows[0]["JOBDATE"].ToString(),

                TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString(),
                CUSTOMS_HOUSE = custom,
                SB_TYPE = ds.Tables[0].Rows[0]["SB_TYPE"].ToString(),
                EXPORTER_NAME = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString(),
                BRANCH_NO = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString(),
                IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString(),
                ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString(),
                ADDRESS2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString(),
                ADDRESS3 = ds.Tables[0].Rows[0]["ADDRESS3"].ToString(),
                ADDRESS4 = ds.Tables[0].Rows[0]["ADDRESS4"].ToString(),
                ADDRESS5 = ds.Tables[0].Rows[0]["ADDRESS5"].ToString(),
                ADCODE = ds.Tables[0].Rows[0]["ADCODE"].ToString(),
                BANK_ACCOUNT = ds.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString(),
                DRAWBACK_ACCOUNT = ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString(),
                CONSIGNEE_NAME = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString(),
                CONSIGNEE_ADD1 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString(),
                CONSIGNEE_ADD2 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString(),
                CONSIGNEE_ADD3 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString(),
                CONSIGNEE_ADD4 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString(),
                CONSIGNEE_ADD5 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString(),
                COUNTRY_DISCHARGE = ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString(),
                PORT_DISCHARGE = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString(),
                COUNTRY_FINAL_DEST = ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString(),
                PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString(),
                STATE_OF_EXPORT = ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString(),
                NFEI = ds.Tables[0].Rows[0]["NFEI"].ToString(),
                NFEI_TYPE = ds.Tables[0].Rows[0]["NFEI_TYPE"].ToString(),
                //RBI_WAIVER_NO = ds.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString(),

                RBI_WAIVER_DATE = RBI_WAIVER_NO + RBI_WAIVER_DATE,
                MARKS_NO = ds.Tables[0].Rows[0]["MARKS_NO"].ToString(),


                //NATURE_OF_CARGO = ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString(),
                NATURE_OF_CARGO = NATURE_OF_CARGO,
                MARKS_NOS = MARKS_NOS,
                TOTAL_PACKAGES = TOTAL_PACKAGES,
                LOOSE_PACKETS = LOOSE_PACKETS,
                NO_CONTAINERS = NO_CONTAINERS,

                GROSS_WEIGHT = GROSS_WEIGHT,
                NET_WEIGHT = NET_WEIGHT,
                ANNEX_AIR_MAWB_NO = ANNEX_AIR_MAWB_NO,
                ANNEX_AIR_HAWB_NO = ANNEX_AIR_HAWB_NO,
                FOB_VALUE = FOB_VALUE,
                DRAWBACK_VALUE = DRAWBACK_VALUE


            });



        }
        return list;
    }
    public List<Rpt_General_Details> GetGeneral(string ddlJobNo)
    {
        
        Export_CheckList CHKLIST = new Export_CheckList();
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();

         // commented for areawise implementation on 05-mar-2020
        /*
        select_type = HttpContext.Current.Session["SELECT_TYPE"].ToString();

        if (select_type == "Branchwise Job")
        {
            select_branch = currentbranch;
        }
        else
        {
            select_branch = "";
        }
         *  * */
        select_branch = Connection.Get_Company_Type();

        CHKLIST.JOBNo = ddlJobNo;
        CHKLIST.Ename = "Checklist";
        CHKLIST.Workingperiod = select_branch;
        ds.Clear();
        ds = CHKLIST.RetrieveAll_General_Details();
        is_Annexure_Mode = CHKLIST.result;
        is_STR_Code = CHKLIST.Is_STR;

        HttpContext.Current.Cache["EXPORT_CHECKLIST"] = ds;
        List<Rpt_General_Details> list = new List<Rpt_General_Details>();
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
            TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
            if (is_Annexure_Mode == 1)
            {


                if (TRANSPORT_MODE == "Air")
                {
                    NATURE_OF_CARGO = ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString();

                    LOOSE_PACKETS = "";
                    NO_CONTAINERS = "";
                    ANNEX_AIR_MAWB_NO = ds.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString();
                    ANNEX_AIR_HAWB_NO = ds.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString();

                    if (NATURE_OF_CARGO == "P")
                    {
                        NATURE_OF_CARGO = "P Packaged";
                    }
                }
                else if (TRANSPORT_MODE == "Sea")
                {
                    NATURE_OF_CARGO = ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString();

                    LOOSE_PACKETS = ds.Tables[0].Rows[0]["LOOSE_PACKETS"].ToString();
                    NO_CONTAINERS = ds.Tables[0].Rows[0]["NO_CONTAINERS"].ToString();
                    ANNEX_AIR_MAWB_NO = "";
                    ANNEX_AIR_HAWB_NO = "";

                    if (NATURE_OF_CARGO == "C")
                    {
                        NATURE_OF_CARGO = "C Containerized";
                    }
                    else if (NATURE_OF_CARGO == "P")
                    {
                        NATURE_OF_CARGO = "P Packaged";
                    }
                    else if (NATURE_OF_CARGO == "CP")
                    {
                        NATURE_OF_CARGO = "CP Containerized";
                    }
                    else if (NATURE_OF_CARGO == "LB")
                    {
                        NATURE_OF_CARGO = "LB Liquid and Bulk";
                    }
                    else if (NATURE_OF_CARGO == "DB")
                    {
                        NATURE_OF_CARGO = "DB Dry Bulk";
                    }

                }
                  TOTAL_PACKAGES = ds.Tables[0].Rows[0]["TOTAL_PACKAGES"].ToString();
                  GROSS_WEIGHT = ds.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString();
                  NET_WEIGHT = ds.Tables[0].Rows[0]["NET_WEIGHT"].ToString();
                  MARKS_NOS = ds.Tables[0].Rows[0]["MARKS_NOS"].ToString();
               
            }
            else if (is_Annexure_Mode == 2)
            {
                if (TRANSPORT_MODE == "Air")
                {
                    NATURE_OF_CARGO = "";

                    LOOSE_PACKETS = "";
                    NO_CONTAINERS = "";
                    ANNEX_AIR_MAWB_NO = "";
                    ANNEX_AIR_HAWB_NO = "";

                }
                else if (TRANSPORT_MODE == "Sea")
                {
                    NATURE_OF_CARGO = "";

                    LOOSE_PACKETS = "";
                    NO_CONTAINERS = "";
                    ANNEX_AIR_MAWB_NO = "";
                    ANNEX_AIR_HAWB_NO = "";

                   

                }
            }

            RBI_WAIVER_NO = ds.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString();
            RBI_WAIVER_DATE = ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString();
            if (RBI_WAIVER_DATE == "01/01/1900" || RBI_WAIVER_DATE == "01-01-1900")
            {
                RBI_WAIVER_DATE = "";
            }
            else
            {
                RBI_WAIVER_DATE = "/" + RBI_WAIVER_DATE;
            }
            //Calculate Total FOB And DRAWBACK Value
            Rpt_Item_Details ITEM = new Rpt_Item_Details();
            ITEM.Get_FOB_DRAWBACK_VALUE_Details(ddlJobNo, ds.Tables[1], ds.Tables[2], ds.Tables[5]);
            FOB_VALUE = Convert.ToString(ITEM.FOB_VALUE);
            DRAWBACK_VALUE = Convert.ToString(ITEM.DBK_VALUE);
            //Calculate Total FOB And DRAWBACK Value

            list.Add(new Rpt_General_Details()
            {
                JOBNO = ddlJobNo,
                Today_dt = dt.Today_Date(),
                JOBDATE = ds.Tables[0].Rows[0]["JOBDATE"].ToString(),

                TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString(),
                CUSTOMS_HOUSE =  custom,
                SB_TYPE = ds.Tables[0].Rows[0]["SB_TYPE"].ToString(),
                EXPORTER_NAME = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString(),
                BRANCH_NO = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString(),
                IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString(),
                ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString(),
                ADDRESS2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString(),
                ADDRESS3 = ds.Tables[0].Rows[0]["ADDRESS3"].ToString(),
                ADDRESS4 = ds.Tables[0].Rows[0]["ADDRESS4"].ToString(),
                ADDRESS5 = ds.Tables[0].Rows[0]["ADDRESS5"].ToString(),
                ADCODE = ds.Tables[0].Rows[0]["ADCODE"].ToString(),
                BANK_ACCOUNT = ds.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString(),
                DRAWBACK_ACCOUNT = ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString(),
                CONSIGNEE_NAME = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString(),
                CONSIGNEE_ADD1 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString(),
                CONSIGNEE_ADD2 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString(),
                CONSIGNEE_ADD3 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString(),
                CONSIGNEE_ADD4 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString(),
                CONSIGNEE_ADD5 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString(),
                COUNTRY_DISCHARGE = ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString(),
                PORT_DISCHARGE = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString(),
                COUNTRY_FINAL_DEST = ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString(),
                PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString(),
                STATE_OF_EXPORT = ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString(),
                NFEI = ds.Tables[0].Rows[0]["NFEI"].ToString(),
                NFEI_TYPE = ds.Tables[0].Rows[0]["NFEI_TYPE"].ToString(),
                //RBI_WAIVER_NO = ds.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString(),

                RBI_WAIVER_DATE = RBI_WAIVER_NO+RBI_WAIVER_DATE,
                MARKS_NO = ds.Tables[0].Rows[0]["MARKS_NO"].ToString(),


                //NATURE_OF_CARGO = ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString(),
                NATURE_OF_CARGO =NATURE_OF_CARGO,
                MARKS_NOS = MARKS_NOS,
                TOTAL_PACKAGES = TOTAL_PACKAGES,
                LOOSE_PACKETS = LOOSE_PACKETS,
                NO_CONTAINERS = NO_CONTAINERS,

                GROSS_WEIGHT = GROSS_WEIGHT,
                NET_WEIGHT = NET_WEIGHT,
                ANNEX_AIR_MAWB_NO = ANNEX_AIR_MAWB_NO,
                ANNEX_AIR_HAWB_NO = ANNEX_AIR_HAWB_NO,
                FOB_VALUE=FOB_VALUE,
                DRAWBACK_VALUE=DRAWBACK_VALUE


            });



        }
        return list;
    }

    public void Retrieve_GetGeneralNew(string ddlJobNo)
    {

        Export_CheckList CHKLIST = new Export_CheckList();
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        // commented for areawise implementation on 05-mar-2020
        /*

        select_type = HttpContext.Current.Session["SELECT_TYPE"].ToString();

        if (select_type == "Branchwise Job")
        {
            select_branch = currentbranch;
        }
        else
        {
            select_branch = "";
        }

         * */
        select_branch = Connection.Get_Company_Type();

        CHKLIST.JOBNo = ddlJobNo;
        CHKLIST.Ename = "Checklist";
        CHKLIST.Workingperiod = select_branch;
        ds.Clear();
        ds = CHKLIST.RetrieveAll_General_DetailsNew();
        is_Annexure_Mode = CHKLIST.result;
        is_STR_Code = CHKLIST.Is_STR;

        HttpContext.Current.Session["EXPORT_CHECKLIST"] = ds;

    }
    
}