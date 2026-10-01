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
/// Summary description for Goods_Reg_AR4
/// </summary>
public class Rpt_Goods_Reg_AR4
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

    private string _ITEM_AR4_ID, _ITEM_AR4_JOBNO, _ITEM_AR4_NO, _ITEM_AR4_DATE, _ITEM_COMMISSION_RATE, _ITEM_DIVISION, _ITEM_RANGE, _ITEM_REMARKS, _INVOICE_SLNO,_ITEM_SLNO;
    private string _GOODS_AR4_ID;
    private string _GOODS_AR4_JOBNO;
    private string _GOODS_AR4_NO;
    private string _GOODS_AR4_DATE;
    private string _GOODS_AR4_COMMISSION_RATE;
    private string _GOODS_AR4_DIVISION;
    private string _GOODS_AR4_RANGE;
    private string _GOODS_AR4_REMARKS;
   
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

    public string GOODS_AR4_ID { get { return _GOODS_AR4_ID; } set { _GOODS_AR4_ID = value; } }
    public string GOODS_AR4_JOBNO { get { return _GOODS_AR4_JOBNO; } set { _GOODS_AR4_JOBNO = value; } }
    public string GOODS_AR4_NO { get { return _GOODS_AR4_NO; } set { _GOODS_AR4_NO = value; } }
    public string GOODS_AR4_DATE { get { return _GOODS_AR4_DATE; } set { _GOODS_AR4_DATE = value; } }
    public string GOODS_AR4_COMMISSION_RATE { get { return _GOODS_AR4_COMMISSION_RATE; } set { _GOODS_AR4_COMMISSION_RATE = value; } }

    public string GOODS_AR4_DIVISION { get { return _GOODS_AR4_DIVISION; } set { _GOODS_AR4_DIVISION = value; } }
    public string GOODS_AR4_RANGE { get { return _GOODS_AR4_RANGE; } set { _GOODS_AR4_RANGE = value; } }
    public string GOODS_AR4_REMARKS { get { return _GOODS_AR4_REMARKS; } set { _GOODS_AR4_REMARKS = value; } }


    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string ITEM_AR4_ID { get { return _ITEM_AR4_ID; } set { _ITEM_AR4_ID = value; } }
    public string ITEM_AR4_JOBNO { get { return _ITEM_AR4_JOBNO; } set { _ITEM_AR4_JOBNO = value; } }
    public string ITEM_AR4_NO { get { return _ITEM_AR4_NO; } set { _ITEM_AR4_NO = value; } }
    public string ITEM_AR4_DATE { get { return _ITEM_AR4_DATE; } set { _ITEM_AR4_DATE = value; } }
    public string ITEM_COMMISSION_RATE { get { return _ITEM_COMMISSION_RATE; } set { _ITEM_COMMISSION_RATE = value; } }
    public string ITEM_DIVISION { get { return _ITEM_DIVISION; } set { _ITEM_DIVISION = value; } }
    public string ITEM_RANGE { get { return _ITEM_RANGE; } set { _ITEM_RANGE = value; } }
    public string ITEM_REMARKS { get { return _ITEM_REMARKS; } set { _ITEM_REMARKS = value; } }

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

    public List<Rpt_Goods_Reg_AR4> Export_Goods_Reg_AR4old(DataTable dt)
    {

        List<Rpt_Goods_Reg_AR4> list = new List<Rpt_Goods_Reg_AR4>();
        list.Clear();

         if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];

            GOODS_AR4_JOBNO = row["GOODS_AR4_JOBNO"].ToString();
            GOODS_AR4_NO = row["GOODS_AR4_NO"].ToString();
            GOODS_AR4_DATE = row["GOODS_AR4_DATE"].ToString();
            GOODS_AR4_COMMISSION_RATE = row["GOODS_AR4_COMMISSION_RATE"].ToString();
            GOODS_AR4_DIVISION = row["GOODS_AR4_DIVISION"].ToString();

            GOODS_AR4_RANGE = row["GOODS_AR4_RANGE"].ToString();
            GOODS_AR4_REMARKS = row["GOODS_AR4_REMARKS"].ToString();
          

        }
          
            list.Add(new Rpt_Goods_Reg_AR4()
            {
                 GOODS_AR4_JOBNO = GOODS_AR4_JOBNO,
            GOODS_AR4_NO = GOODS_AR4_NO,
            GOODS_AR4_DATE = GOODS_AR4_DATE,
            GOODS_AR4_COMMISSION_RATE = GOODS_AR4_COMMISSION_RATE,
            GOODS_AR4_DIVISION = GOODS_AR4_DIVISION,

            GOODS_AR4_RANGE = GOODS_AR4_RANGE,
            GOODS_AR4_REMARKS = GOODS_AR4_REMARKS
          

            });

        
        return list;
    }
    public List<Rpt_Goods_Reg_AR4> Export_Goods_Reg_AR4(DataTable dt)
    {

        List<Rpt_Goods_Reg_AR4> list = new List<Rpt_Goods_Reg_AR4>();
        list.Clear();

        //if (dt.Rows.Count > 0)
       // {
        int a = 0;

        while (dt.Rows.Count > a)
        {
            DataRow row = dt.Rows[a];
            INVOICE_SLNO = "1";
            //ITEM_SLNO = "1";
            ITEM_SLNO = row["AR4_ITEM_NO"].ToString();

            //ITEM_SLNO = row["AR4_ID"].ToString();
            GOODS_AR4_JOBNO = row["AR4_JOBNO"].ToString();
            GOODS_AR4_NO = row["AR4_NO"].ToString();
            GOODS_AR4_DATE = row["AR4_DATE"].ToString();
            GOODS_AR4_COMMISSION_RATE = row["AR4_COMMISSION_RATE"].ToString();
            GOODS_AR4_DIVISION = row["AR4_DIVISION"].ToString();

            GOODS_AR4_RANGE = row["AR4_RANGE"].ToString();
            GOODS_AR4_REMARKS = row["AR4_REMARKS"].ToString();
            a++;


            list.Add(new Rpt_Goods_Reg_AR4()
            {
                INVOICE_SLNO = INVOICE_SLNO,
                ITEM_SLNO = ITEM_SLNO,
                GOODS_AR4_JOBNO = GOODS_AR4_JOBNO,
                GOODS_AR4_NO = GOODS_AR4_NO,
                GOODS_AR4_DATE = GOODS_AR4_DATE,
                GOODS_AR4_COMMISSION_RATE = GOODS_AR4_COMMISSION_RATE,
                GOODS_AR4_DIVISION = GOODS_AR4_DIVISION,

                GOODS_AR4_RANGE = GOODS_AR4_RANGE,
                GOODS_AR4_REMARKS = GOODS_AR4_REMARKS


            });

        }
        return list;
    }
    public List<Rpt_Goods_Reg_AR4> Export_AR4(DataTable dt)
    {

        List<Rpt_Goods_Reg_AR4> list = new List<Rpt_Goods_Reg_AR4>();
        list.Clear();

        //if (dt.Rows.Count > 0)
        // {
        int a = 0;
        int b = 0;
       
        while (dt.Rows.Count > a)
        {
            DataRow row = dt.Rows[a];

           // INVOICE_SLNO = "1";
            INVOICE_SLNO = row["AR4_INVOICE_SLNO"].ToString();

            //if (INVOICE_SLNO == ITEM_SLNO)
            //{
            //    ITEM_SLNO = Convert.ToString(b + 1);
            //}
            //else
            //{
            //    ITEM_SLNO = Convert.ToString(b);
            //}

            ITEM_SLNO = row["AR4_ITEM_NO"].ToString();

            //ITEM_SLNO = row["AR4_RUN_ID"].ToString();

            ITEM_AR4_JOBNO = row["AR4_JOBNO"].ToString();
            ITEM_AR4_NO = row["AR4_NO"].ToString();
            ITEM_AR4_DATE = row["AR4_DATE"].ToString();
            ITEM_COMMISSION_RATE = row["AR4_COMMISSION_RATE"].ToString();
            ITEM_DIVISION = row["AR4_DIVISION"].ToString();

            ITEM_RANGE = row["AR4_RANGE"].ToString();
            ITEM_REMARKS = row["AR4_REMARKS"].ToString();
            a++;

            list.Add(new Rpt_Goods_Reg_AR4()
            {

                INVOICE_SLNO = INVOICE_SLNO,
                ITEM_SLNO = ITEM_SLNO,
                ITEM_AR4_JOBNO = ITEM_AR4_JOBNO,
                ITEM_AR4_NO = ITEM_AR4_NO,
                ITEM_AR4_DATE = ITEM_AR4_DATE,
                ITEM_COMMISSION_RATE = ITEM_COMMISSION_RATE,
                ITEM_DIVISION = ITEM_DIVISION,

                ITEM_RANGE = ITEM_RANGE,
                ITEM_REMARKS = ITEM_REMARKS


            });
        }

        return list;
    }
}