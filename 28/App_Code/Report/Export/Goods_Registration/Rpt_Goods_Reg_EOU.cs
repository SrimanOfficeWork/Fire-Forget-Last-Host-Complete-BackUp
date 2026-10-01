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
/// Summary description for Goods_Reg_EOU
/// </summary>
public class Rpt_Goods_Reg_EOU
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

    private string _GOODS_EOU_ID;
    private string _GOODS_EOU_JOBNO;
    private string _GOODS_EOU_EXAM_DATE;
    private string _GOODS_EOU_EXAM_OFFICER;
    private string _GOODS_EOU_EXAM_DESIGN;
    private string _GOODS_EOU_SUPER_NAME;
    private string _GOODS_EOU_SUPER_DESIGN;
    private string _GOODS_EOU_COMMISSION_RATE;
    private string _GOODS_EOU_DIVISION;
    private string _GOODS_EOU_DRAWN;
    private string _GOODS_EOU_RANGE;
    private string _GOODS_EOU_SEAL_NO;
    private string _GOODS_EOU_DECLARED_VALUE_VERI;
  
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

    public string GOODS_EOU_ID { get { return _GOODS_EOU_ID; } set { _GOODS_EOU_ID = value; } }
    public string GOODS_EOU_JOBNO { get { return _GOODS_EOU_JOBNO; } set { _GOODS_EOU_JOBNO = value; } }
    public string GOODS_EOU_EXAM_DATE { get { return _GOODS_EOU_EXAM_DATE; } set { _GOODS_EOU_EXAM_DATE = value; } }
    public string GOODS_EOU_EXAM_OFFICER { get { return _GOODS_EOU_EXAM_OFFICER; } set { _GOODS_EOU_EXAM_OFFICER = value; } }
    public string GOODS_EOU_EXAM_DESIGN { get { return _GOODS_EOU_EXAM_DESIGN; } set { _GOODS_EOU_EXAM_DESIGN = value; } }
    public string GOODS_EOU_SUPER_NAME { get { return _GOODS_EOU_SUPER_NAME; } set { _GOODS_EOU_SUPER_NAME = value; } }
    public string GOODS_EOU_SUPER_DESIGN { get { return _GOODS_EOU_SUPER_DESIGN; } set { _GOODS_EOU_SUPER_DESIGN = value; } }
    public string GOODS_EOU_COMMISSION_RATE { get { return _GOODS_EOU_COMMISSION_RATE; } set { _GOODS_EOU_COMMISSION_RATE = value; } }
    public string GOODS_EOU_DIVISION { get { return _GOODS_EOU_DIVISION; } set { _GOODS_EOU_DIVISION = value; } }
    public string GOODS_EOU_DRAWN { get { return _GOODS_EOU_DRAWN; } set { _GOODS_EOU_DRAWN = value; } }
    public string GOODS_EOU_RANGE { get { return _GOODS_EOU_RANGE; } set { _GOODS_EOU_RANGE = value; } }
    public string GOODS_EOU_SEAL_NO { get { return _GOODS_EOU_SEAL_NO; } set { _GOODS_EOU_SEAL_NO = value; } }
    public string GOODS_EOU_DECLARED_VALUE_VERI { get { return _GOODS_EOU_DECLARED_VALUE_VERI; } set { _GOODS_EOU_DECLARED_VALUE_VERI = value; } }
  
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


    public List<Rpt_Goods_Reg_EOU> Export_Goods_Reg_EOU(DataTable dt)
    {

        List<Rpt_Goods_Reg_EOU> list = new List<Rpt_Goods_Reg_EOU>();
        list.Clear();

        if (dt.Rows.Count > 0)
        {
            DataRow row= dt.Rows[0];


            GOODS_EOU_EXAM_DATE = row["GOODS_EOU_EXAM_DATE"].ToString();
            GOODS_EOU_EXAM_OFFICER = row["GOODS_EOU_EXAM_OFFICER"].ToString();
            GOODS_EOU_EXAM_DESIGN = row["GOODS_EOU_EXAM_DESIGN"].ToString();
            GOODS_EOU_SUPER_NAME = row["GOODS_EOU_SUPER_NAME"].ToString();
            GOODS_EOU_SUPER_DESIGN = row["GOODS_EOU_SUPER_DESIGN"].ToString();
            GOODS_EOU_COMMISSION_RATE = row["GOODS_EOU_COMMISSION_RATE"].ToString();
            GOODS_EOU_DIVISION = row["GOODS_EOU_DIVISION"].ToString();
            GOODS_EOU_DRAWN = row["GOODS_EOU_DRAWN"].ToString();
            GOODS_EOU_RANGE = row["GOODS_EOU_RANGE"].ToString();
            GOODS_EOU_SEAL_NO = row["GOODS_EOU_SEAL_NO"].ToString();
            GOODS_EOU_DECLARED_VALUE_VERI = row["GOODS_EOU_DECLARED_VALUE_VERI"].ToString();
            if (GOODS_EOU_EXAM_DATE == "01/01/1900" || GOODS_EOU_EXAM_DATE == "01-01-1900")
            {
                GOODS_EOU_EXAM_DATE = "";
            }
            else
            {
                GOODS_EOU_EXAM_DATE = GOODS_EOU_EXAM_DATE;
            }
            

        }

        list.Add(new Rpt_Goods_Reg_EOU()
        {
            

            GOODS_EOU_EXAM_DATE=GOODS_EOU_EXAM_DATE,
            GOODS_EOU_EXAM_OFFICER=GOODS_EOU_EXAM_OFFICER,
            GOODS_EOU_EXAM_DESIGN=GOODS_EOU_EXAM_DESIGN,
            GOODS_EOU_SUPER_NAME=GOODS_EOU_SUPER_NAME,
            GOODS_EOU_SUPER_DESIGN=GOODS_EOU_SUPER_DESIGN,
            GOODS_EOU_COMMISSION_RATE=GOODS_EOU_COMMISSION_RATE,
            GOODS_EOU_DIVISION=GOODS_EOU_DIVISION,
            GOODS_EOU_DRAWN=GOODS_EOU_DRAWN,
            GOODS_EOU_RANGE=GOODS_EOU_RANGE,
            GOODS_EOU_SEAL_NO=GOODS_EOU_SEAL_NO,
            GOODS_EOU_DECLARED_VALUE_VERI=GOODS_EOU_DECLARED_VALUE_VERI



        });


        return list;
    }
}