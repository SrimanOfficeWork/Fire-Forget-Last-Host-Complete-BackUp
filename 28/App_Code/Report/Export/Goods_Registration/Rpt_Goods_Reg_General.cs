using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data; 

/// <summary>
/// Summary description for Goods_Reg_Air
/// </summary>
public class Rpt_Goods_Reg_General
{
    
    Date_Time dt = new Date_Time();
  
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    
    ErrorLogs er = new ErrorLogs();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    public int result;

    # region Private Attributes
    private string _GOODS_LOOSE_PACKETS, _GOODS_ROTATION_NO, _GOODS_ROTATION_DATE, _GOODS_NO_OF_CONTAINERS;
    private string _GOODS_ID;
    private string _GOODS_JOBNO,_GOODS_CUSTOM_HOUSE;
    private string _GOODS_SB_NO;
    private string _GOODS_SB_DATE;
    private string _GOODS_SEAL_TYPE;
    private string _GOODS_NATURE_OF_CARGO;
    private string _GOODS_GROSS_WEIGHT;
    private string _GOODS_NET_WEIGHT;
    private string _GOODS_UNIT_MESUR;
    private string _GOODS_TOTAL_PACKAGES;
    private string _GOODS_MARKS_NOS;
    private string _GOODS_MAWB_NO;
    private string _GOODS_MAWB_DATE;
    private string _GOODS_HAWB_NO;
    private string _GOODS_HAWB_DATE;
    private string _GOODS_TRANSHIPPER_CODE;
    private string _GOODS_GATEWAY_PORT;
    private string _GOODS_WAREHOUSECODE;
  
    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;

    private string _Ename;

    private string _startRowIndex;

    private string _maximumRows;
    private string _totalRows;

    #endregion
    
    # region Public Attributes

    public string GOODS_ID { get { return _GOODS_ID; } set { _GOODS_ID = value; } }
    public string GOODS_JOBNO { get { return _GOODS_JOBNO; } set { _GOODS_JOBNO = value; } }
    public string GOODS_SB_NO { get { return _GOODS_SB_NO; } set { _GOODS_SB_NO = value; } }
    public string GOODS_CUSTOM_HOUSE { get { return _GOODS_CUSTOM_HOUSE; } set { _GOODS_CUSTOM_HOUSE = value; } }
    public string GOODS_SB_DATE { get { return _GOODS_SB_DATE; } set { _GOODS_SB_DATE = value; } }
    public string GOODS_SEAL_TYPE { get { return _GOODS_SEAL_TYPE; } set { _GOODS_SEAL_TYPE = value; } }
    public string GOODS_NATURE_OF_CARGO { get { return _GOODS_NATURE_OF_CARGO; } set { _GOODS_NATURE_OF_CARGO = value; } }
    public string GOODS_GROSS_WEIGHT { get { return _GOODS_GROSS_WEIGHT; } set { _GOODS_GROSS_WEIGHT = value; } }
    public string GOODS_NET_WEIGHT { get { return _GOODS_NET_WEIGHT; } set { _GOODS_NET_WEIGHT = value; } }
    public string GOODS_UNIT_MESUR { get { return _GOODS_UNIT_MESUR; } set { _GOODS_UNIT_MESUR = value; } }
    public string GOODS_TOTAL_PACKAGES { get { return _GOODS_TOTAL_PACKAGES; } set { _GOODS_TOTAL_PACKAGES = value; } }
    public string GOODS_MARKS_NOS { get { return _GOODS_MARKS_NOS; } set { _GOODS_MARKS_NOS = value; } }
    public string GOODS_MAWB_NO { get { return _GOODS_MAWB_NO; } set { _GOODS_MAWB_NO = value; } }
    public string GOODS_MAWB_DATE { get { return _GOODS_MAWB_DATE; } set { _GOODS_MAWB_DATE = value; } }
    public string GOODS_HAWB_NO { get { return _GOODS_HAWB_NO; } set { _GOODS_HAWB_NO = value; } }
    public string GOODS_HAWB_DATE { get { return _GOODS_HAWB_DATE; } set { _GOODS_HAWB_DATE = value; } }
    public string GOODS_LOOSE_PACKETS { get { return _GOODS_LOOSE_PACKETS; } set { _GOODS_LOOSE_PACKETS = value; } }
    public string GOODS_ROTATION_NO { get { return _GOODS_ROTATION_NO; } set { _GOODS_ROTATION_NO = value; } }
    public string GOODS_ROTATION_DATE { get { return _GOODS_ROTATION_DATE; } set { _GOODS_ROTATION_DATE = value; } }
    public string GOODS_NO_OF_CONTAINERS { get { return _GOODS_NO_OF_CONTAINERS; } set { _GOODS_NO_OF_CONTAINERS = value; } }
    public string GOODS_TRANSHIPPER_CODE { get { return _GOODS_TRANSHIPPER_CODE; } set { _GOODS_TRANSHIPPER_CODE = value; } }
    public string GOODS_GATEWAY_PORT { get { return _GOODS_GATEWAY_PORT; } set { _GOODS_GATEWAY_PORT = value; } }
    public string GOODS_WAREHOUSECODE { get { return _GOODS_WAREHOUSECODE; } set { _GOODS_WAREHOUSECODE = value; } }

    
    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }


    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public string Working_Period
    {
        get { return _WORKING_PERIOD; }
        set { _WORKING_PERIOD = value; }
    }

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string LoginDate;
    #endregion
    public void Retrieve_Export_Goods_Reg_General(string ddlJobNo, string customhouse, string transportmode,string select_branch)
    {
       
        Export_CheckList CHKLIST = new Export_CheckList();
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();

        CHKLIST.JOBNo = ddlJobNo;
        CHKLIST.Ename = "Export_Goods_Registration_Checklist";
        CHKLIST.Workingperiod = select_branch;
        CHKLIST.CUSTOM_HOUSE = customhouse;
        CHKLIST.TRANSPORT_MODE = transportmode;
        ds.Clear();
        HttpContext.Current.Session["EXPORT_GOODS_REG_CHECKLIST"] = ds = CHKLIST.RetrieveAll_General_Details();
        
    }
    public List<Rpt_Goods_Reg_General> Export_Goods_Reg_General(DataTable dt, string customhouse, string transportmode)
    {
        
        List<Rpt_Goods_Reg_General> list = new List<Rpt_Goods_Reg_General>();
      
        list.Clear();


        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];

            GOODS_CUSTOM_HOUSE = customhouse;
            GOODS_SB_NO = row["GOODS_SB_NO"].ToString();
            GOODS_SB_DATE = row["GOODS_SB_DATE"].ToString();
            if (GOODS_SB_DATE == "01/01/1900" || GOODS_SB_DATE == "01-01-1900")
            {
                GOODS_SB_NO = GOODS_SB_NO;

            }
            else
            {
                if (GOODS_SB_NO != "")
                    GOODS_SB_NO = GOODS_SB_NO + " " + GOODS_SB_DATE;
                else
                    GOODS_SB_NO = GOODS_SB_DATE;

            }
            GOODS_SEAL_TYPE = row["GOODS_SEAL_TYPE"].ToString();
            if (GOODS_SEAL_TYPE == "Agency")
            {
                GOODS_SEAL_TYPE = "A";
            }
            else if (GOODS_SEAL_TYPE == "self")
            {
                GOODS_SEAL_TYPE = "S";
            }
            else if (GOODS_SEAL_TYPE == "WareHouse")
            {
                GOODS_SEAL_TYPE = "W";
            }

            GOODS_NATURE_OF_CARGO = row["GOODS_NATURE_OF_CARGO"].ToString();

            GOODS_GROSS_WEIGHT = row["GOODS_GROSS_WEIGHT"].ToString();
            GOODS_NET_WEIGHT = row["GOODS_NET_WEIGHT"].ToString();
            GOODS_UNIT_MESUR = row["GOODS_UNIT_MESUR"].ToString();
            GOODS_TOTAL_PACKAGES = row["GOODS_TOTAL_PACKAGES"].ToString();
            GOODS_MARKS_NOS = row["GOODS_MARKS_NOS"].ToString();
            if (transportmode == "Air")
            {
                //GOODS_MAWB_NO = row["GOODS_MAWB_NO"].ToString();
                //GOODS_MAWB_DATE = row["GOODS_MAWB_DATE"].ToString();
                //if (GOODS_MAWB_DATE == "01/01/1900" || GOODS_MAWB_DATE == "01-01-1900")
                //{
                //    GOODS_MAWB_DATE = "";
                //}
                //else
                //{
                //    GOODS_MAWB_DATE = GOODS_MAWB_DATE;
                //}
                //GOODS_HAWB_NO = row["GOODS_HAWB_NO"].ToString();
                //GOODS_HAWB_DATE = row["GOODS_HAWB_DATE"].ToString();
                //if (GOODS_HAWB_DATE == "01/01/1900" || GOODS_HAWB_DATE == "01-01-1900")
                //{
                //    GOODS_HAWB_DATE = "";
                //}
                //else
                //{
                //    GOODS_HAWB_DATE = GOODS_HAWB_DATE;
                //}
            }
            else
            {
                GOODS_LOOSE_PACKETS = row["GOODS_LOOSE_PACKETS"].ToString();
                GOODS_ROTATION_NO = row["GOODS_ROTATION_NO"].ToString();
                GOODS_ROTATION_DATE = row["GOODS_ROTATION_DATE"].ToString();
                GOODS_NO_OF_CONTAINERS = row["GOODS_NO_OF_CONTAINERS"].ToString();
                if (GOODS_ROTATION_DATE == "01/01/1900" || GOODS_ROTATION_DATE == "01-01-1900")
                {
                    GOODS_ROTATION_NO = GOODS_ROTATION_NO;

                }
                else
                {
                    if (GOODS_ROTATION_NO != "")
                        GOODS_ROTATION_NO = GOODS_ROTATION_NO + " " + GOODS_ROTATION_DATE;
                    else
                        GOODS_ROTATION_NO = GOODS_ROTATION_DATE;

                }
            }

            GOODS_MAWB_NO = row["GOODS_MAWB_NO"].ToString();
            GOODS_MAWB_DATE = row["GOODS_MAWB_DATE"].ToString();
            if (GOODS_MAWB_DATE == "01/01/1900" || GOODS_MAWB_DATE == "01-01-1900")
            {
                GOODS_MAWB_DATE = "";
            }
            else
            {
                GOODS_MAWB_DATE = GOODS_MAWB_DATE;
            }
            GOODS_HAWB_NO = row["GOODS_HAWB_NO"].ToString();
            GOODS_HAWB_DATE = row["GOODS_HAWB_DATE"].ToString();
            if (GOODS_HAWB_DATE == "01/01/1900" || GOODS_HAWB_DATE == "01-01-1900")
            {
                GOODS_HAWB_DATE = "";
            }
            else
            {
                GOODS_HAWB_DATE = GOODS_HAWB_DATE;
            }

            GOODS_TRANSHIPPER_CODE = row["GOODS_TRANSHIPPER_CODE"].ToString();
            GOODS_GATEWAY_PORT = row["GOODS_GATEWAY_PORT"].ToString();
            GOODS_WAREHOUSECODE = row["GOODS_WAREHOUSECODE"].ToString();

        }
        else
            GOODS_CUSTOM_HOUSE = "";


        list.Add(new Rpt_Goods_Reg_General()
        {
            GOODS_CUSTOM_HOUSE = GOODS_CUSTOM_HOUSE,

            GOODS_SB_NO = GOODS_SB_NO + " Seal Type :" + GOODS_SEAL_TYPE,


            GOODS_NATURE_OF_CARGO = GOODS_NATURE_OF_CARGO,
            GOODS_GROSS_WEIGHT = GOODS_GROSS_WEIGHT,
            GOODS_NET_WEIGHT = GOODS_NET_WEIGHT,
            GOODS_UNIT_MESUR = GOODS_UNIT_MESUR,
            GOODS_TOTAL_PACKAGES = GOODS_TOTAL_PACKAGES,
            GOODS_MARKS_NOS = GOODS_MARKS_NOS,
            GOODS_MAWB_NO = GOODS_MAWB_NO,
            GOODS_MAWB_DATE = GOODS_MAWB_DATE,
            GOODS_HAWB_NO = GOODS_HAWB_NO,
            GOODS_HAWB_DATE = GOODS_HAWB_DATE,
            GOODS_LOOSE_PACKETS = GOODS_LOOSE_PACKETS,

            GOODS_ROTATION_NO = GOODS_ROTATION_NO,

            GOODS_NO_OF_CONTAINERS = GOODS_NO_OF_CONTAINERS,

            GOODS_TRANSHIPPER_CODE = GOODS_TRANSHIPPER_CODE,
            GOODS_GATEWAY_PORT = GOODS_GATEWAY_PORT,
            GOODS_WAREHOUSECODE = GOODS_WAREHOUSECODE


        });
        return list;
    }
    public List<Rpt_Goods_Reg_General> Export_Goods_Reg_General1(string ddlJobNo,string customhouse,string transportmode)
    {
        //Customer c = new Customer();

        Export_CheckList CHKLIST = new Export_CheckList();
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();

        CHKLIST.JOBNo = ddlJobNo;
        CHKLIST.Ename = "Export_Goods_Registration_Checklist";
        CHKLIST.Workingperiod = Working_Period;
        CHKLIST.CUSTOM_HOUSE = customhouse;
        CHKLIST.TRANSPORT_MODE = transportmode;
        ds.Clear();
        HttpContext.Current.Cache["EXPORT_GOODS_REG_CHECKLIST"]= ds = CHKLIST.RetrieveAll_General_Details();
       

       // HttpContext.Current.Cache["EXPORT_GOODS_REG_CHECKLIST"] = ds;
        List<Rpt_Goods_Reg_General> list = new List<Rpt_Goods_Reg_General>();
        Auto_Search auto = new Auto_Search();

        list.Clear();


        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow row = ds.Tables[0].Rows[0];

            GOODS_CUSTOM_HOUSE = customhouse;
            GOODS_SB_NO = row["GOODS_SB_NO"].ToString();
            GOODS_SB_DATE = row["GOODS_SB_DATE"].ToString();
            if (GOODS_SB_DATE == "01/01/1900" || GOODS_SB_DATE == "01-01-1900")
            {
                GOODS_SB_NO = GOODS_SB_NO;

            }
            else
            {
                if (GOODS_SB_NO != "")
                    GOODS_SB_NO = GOODS_SB_NO + " " + GOODS_SB_DATE;
                else
                    GOODS_SB_NO = GOODS_SB_DATE;

            }
            GOODS_SEAL_TYPE = row["GOODS_SEAL_TYPE"].ToString();
            if (GOODS_SEAL_TYPE == "Agency")
            {
                GOODS_SEAL_TYPE = "A";
            }
            else if (GOODS_SEAL_TYPE == "self")
            {
                GOODS_SEAL_TYPE = "S";
            }
            else if (GOODS_SEAL_TYPE == "WareHouse")
            {
                GOODS_SEAL_TYPE = "W";
            }

            GOODS_NATURE_OF_CARGO = row["GOODS_NATURE_OF_CARGO"].ToString();

            GOODS_GROSS_WEIGHT = row["GOODS_GROSS_WEIGHT"].ToString();
            GOODS_NET_WEIGHT = row["GOODS_NET_WEIGHT"].ToString();
            GOODS_UNIT_MESUR = row["GOODS_UNIT_MESUR"].ToString();
            GOODS_TOTAL_PACKAGES = row["GOODS_TOTAL_PACKAGES"].ToString();
            GOODS_MARKS_NOS = row["GOODS_MARKS_NOS"].ToString();
            if (transportmode == "Air")
            {
                GOODS_MAWB_NO = row["GOODS_MAWB_NO"].ToString();
                GOODS_MAWB_DATE = row["GOODS_MAWB_DATE"].ToString();
                if (GOODS_MAWB_DATE == "01/01/1900" || GOODS_MAWB_DATE == "01-01-1900")
                {
                    GOODS_MAWB_DATE = "";
                }
                else
                {
                    GOODS_MAWB_DATE = GOODS_MAWB_DATE;
                }
                GOODS_HAWB_NO = row["GOODS_HAWB_NO"].ToString();
                GOODS_HAWB_DATE = row["GOODS_HAWB_DATE"].ToString();
                if (GOODS_HAWB_DATE == "01/01/1900" || GOODS_HAWB_DATE == "01-01-1900")
                {
                    GOODS_HAWB_DATE = "";
                }
                else
                {
                    GOODS_HAWB_DATE = GOODS_HAWB_DATE;
                }
            }
            else
            {
                GOODS_LOOSE_PACKETS = row["GOODS_LOOSE_PACKETS"].ToString();
                GOODS_ROTATION_NO = row["GOODS_ROTATION_NO"].ToString();
                GOODS_ROTATION_DATE = row["GOODS_ROTATION_DATE"].ToString();
                GOODS_NO_OF_CONTAINERS = row["GOODS_NO_OF_CONTAINERS"].ToString();
                if (GOODS_ROTATION_DATE == "01/01/1900" || GOODS_ROTATION_DATE == "01-01-1900")
                {
                    GOODS_ROTATION_NO = GOODS_ROTATION_NO;

                }
                else
                {
                    if (GOODS_ROTATION_NO != "")
                        GOODS_ROTATION_NO = GOODS_ROTATION_NO + " " + GOODS_ROTATION_DATE;
                    else
                        GOODS_ROTATION_NO = GOODS_ROTATION_DATE;

                }
            }
        }
        else
            GOODS_CUSTOM_HOUSE = "";
        list.Add(new Rpt_Goods_Reg_General()
            {
                GOODS_CUSTOM_HOUSE=GOODS_CUSTOM_HOUSE,
                
                GOODS_SB_NO=GOODS_SB_NO+"  Seal Type :"+GOODS_SEAL_TYPE,
                
                
                GOODS_NATURE_OF_CARGO=GOODS_NATURE_OF_CARGO,
                GOODS_GROSS_WEIGHT=GOODS_GROSS_WEIGHT,
                GOODS_NET_WEIGHT=GOODS_NET_WEIGHT,
                GOODS_UNIT_MESUR=GOODS_UNIT_MESUR,
                GOODS_TOTAL_PACKAGES=GOODS_TOTAL_PACKAGES,
                GOODS_MARKS_NOS=GOODS_MARKS_NOS,
                GOODS_MAWB_NO=GOODS_MAWB_NO,
                GOODS_MAWB_DATE=GOODS_MAWB_DATE,
                GOODS_HAWB_NO=GOODS_HAWB_NO,
                GOODS_HAWB_DATE = GOODS_HAWB_DATE,
                GOODS_LOOSE_PACKETS = GOODS_LOOSE_PACKETS,
                
                GOODS_ROTATION_NO = GOODS_ROTATION_NO,
                
                GOODS_NO_OF_CONTAINERS = GOODS_NO_OF_CONTAINERS


            });
       return list;
    }
}