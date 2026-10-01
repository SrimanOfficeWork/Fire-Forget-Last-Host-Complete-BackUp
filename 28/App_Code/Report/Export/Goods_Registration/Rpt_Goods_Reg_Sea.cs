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
/// Summary description for Goods_Reg_Sea
/// </summary>
public class Rpt_Goods_Reg_Sea
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    public int result;

    # region Private Attributes


    private string _GOODS_SEA_ID;
    private string _GOODS_SEA_JOBNO;
    private string _GOODS_SEA_SB_NO;
    private string _GOODS_SEA_SB_DATE;
    private string _GOODS_SEA_SEAL_TYPE;
    private string _GOODS_SEA_NATURE_OF_CARGO;
    private string _GOODS_SEA_MARKS_NOS;
    private string _GOODS_SEA_TOTAL_PACKAGES;
    private string _GOODS_SEA_LOOSE_PACKETS;
    private string _GOODS_SEA_NO_CONTAINERS;
    private string _GOODS_SEA_GROSS_WEIGHT;
    private string _GOODS_SEA_NET_WEIGHT;
    private string _GOODS_SEA_UNIT_MEASUREMENT;
    private string _GOODS_SEA_ROTATION_NO;
    private string _GOODS_SEA_ROTATION_DATE;

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


    public string GOODS_SEA_ID { get { return _GOODS_SEA_ID; } set { _GOODS_SEA_ID = value; } }
    public string GOODS_SEA_JOBNO { get { return _GOODS_SEA_JOBNO; } set { _GOODS_SEA_JOBNO = value; } }
    public string GOODS_SEA_SB_NO { get { return _GOODS_SEA_SB_NO; } set { _GOODS_SEA_SB_NO = value; } }
    public string GOODS_SEA_SB_DATE { get { return _GOODS_SEA_SB_DATE; } set { _GOODS_SEA_SB_DATE = value; } }
    public string GOODS_SEA_SEAL_TYPE { get { return _GOODS_SEA_SEAL_TYPE; } set { _GOODS_SEA_SEAL_TYPE = value; } }
    public string GOODS_SEA_NATURE_OF_CARGO { get { return _GOODS_SEA_NATURE_OF_CARGO; } set { _GOODS_SEA_NATURE_OF_CARGO = value; } }
    public string GOODS_SEA_MARKS_NOS { get { return _GOODS_SEA_MARKS_NOS; } set { _GOODS_SEA_MARKS_NOS = value; } }
    public string GOODS_SEA_TOTAL_PACKAGES { get { return _GOODS_SEA_TOTAL_PACKAGES; } set { _GOODS_SEA_TOTAL_PACKAGES = value; } }
    public string GOODS_SEA_LOOSE_PACKETS { get { return _GOODS_SEA_LOOSE_PACKETS; } set { _GOODS_SEA_LOOSE_PACKETS = value; } }
    public string GOODS_SEA_NO_CONTAINERS { get { return _GOODS_SEA_NO_CONTAINERS; } set { _GOODS_SEA_NO_CONTAINERS = value; } }
    public string GOODS_SEA_GROSS_WEIGHT { get { return _GOODS_SEA_GROSS_WEIGHT; } set { _GOODS_SEA_GROSS_WEIGHT = value; } }
    public string GOODS_SEA_NET_WEIGHT { get { return _GOODS_SEA_NET_WEIGHT; } set { _GOODS_SEA_NET_WEIGHT = value; } }
    public string GOODS_SEA_UNIT_MEASUREMENT { get { return _GOODS_SEA_UNIT_MEASUREMENT; } set { _GOODS_SEA_UNIT_MEASUREMENT = value; } }
    public string GOODS_SEA_ROTATION_NO { get { return _GOODS_SEA_ROTATION_NO; } set { _GOODS_SEA_ROTATION_NO = value; } }
    public string GOODS_SEA_ROTATION_DATE { get { return _GOODS_SEA_ROTATION_DATE; } set { _GOODS_SEA_ROTATION_DATE = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }


    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    #endregion

    public List<Rpt_Goods_Reg_Sea> Export_Goods_Reg_Sea(DataTable dt)
    {

        List<Rpt_Goods_Reg_Sea> list = new List<Rpt_Goods_Reg_Sea>();
        list.Clear();

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow row = ds.Tables[0].Rows[0];




            GOODS_SEA_SB_NO = row["GOODS_SEA_SB_NO"].ToString();
            GOODS_SEA_SB_DATE = row["GOODS_SEA_SB_DATE"].ToString();
            GOODS_SEA_SEAL_TYPE = row["GOODS_SEA_SEAL_TYPE"].ToString();
            GOODS_SEA_NATURE_OF_CARGO = row["GOODS_SEA_NATURE_OF_CARGO"].ToString();
            GOODS_SEA_MARKS_NOS = row["GOODS_SEA_MARKS_NOS"].ToString();
            GOODS_SEA_TOTAL_PACKAGES = row["GOODS_SEA_TOTAL_PACKAGES"].ToString();
            GOODS_SEA_LOOSE_PACKETS = row["GOODS_SEA_LOOSE_PACKETS"].ToString();
            GOODS_SEA_NO_CONTAINERS = row["GOODS_SEA_NO_CONTAINERS"].ToString();
            GOODS_SEA_GROSS_WEIGHT = row["GOODS_SEA_GROSS_WEIGHT"].ToString();
            GOODS_SEA_NET_WEIGHT = row["GOODS_SEA_NET_WEIGHT"].ToString();
            GOODS_SEA_UNIT_MEASUREMENT = row["GOODS_SEA_UNIT_MEASUREMENT"].ToString();
            GOODS_SEA_ROTATION_NO = row["GOODS_SEA_ROTATION_NO"].ToString();
            GOODS_SEA_ROTATION_DATE = row["GOODS_SEA_ROTATION_DATE"].ToString();




        }

        list.Add(new Rpt_Goods_Reg_Sea()
        {


            GOODS_SEA_SB_NO = GOODS_SEA_SB_NO,
            GOODS_SEA_SB_DATE = GOODS_SEA_SB_DATE,
            GOODS_SEA_SEAL_TYPE = GOODS_SEA_SEAL_TYPE,
            GOODS_SEA_NATURE_OF_CARGO = GOODS_SEA_NATURE_OF_CARGO,
            GOODS_SEA_MARKS_NOS = GOODS_SEA_MARKS_NOS,
            GOODS_SEA_TOTAL_PACKAGES = GOODS_SEA_TOTAL_PACKAGES,
            GOODS_SEA_LOOSE_PACKETS = GOODS_SEA_LOOSE_PACKETS,
            GOODS_SEA_NO_CONTAINERS = GOODS_SEA_NO_CONTAINERS,
            GOODS_SEA_GROSS_WEIGHT = GOODS_SEA_GROSS_WEIGHT,
            GOODS_SEA_NET_WEIGHT = GOODS_SEA_NET_WEIGHT,
            GOODS_SEA_UNIT_MEASUREMENT = GOODS_SEA_UNIT_MEASUREMENT,
            GOODS_SEA_ROTATION_NO = GOODS_SEA_ROTATION_NO,
            GOODS_SEA_ROTATION_DATE = GOODS_SEA_ROTATION_DATE




        });


        return list;
    }
}