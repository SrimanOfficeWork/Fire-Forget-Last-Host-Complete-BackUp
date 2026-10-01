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
/// Summary description for Rpt_Goods_Reg_Invoice
/// </summary>
public class Rpt_Goods_Reg_Invoice
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
    public int result, UPDATE_ID = 0;

    # region Private Attributes

    private string _GOODS_PACK_ID;
    private string _GOODS_PACK_JOBNO;
    private string _TERMS;
    private string _WHEATHER_UNIT_PRICE;
    private string _INVOICE_SLNO;
    private string _INVOICE_NO;
    private string _INVOICE_DATE;
    private string _FREIGHT_CHARGES;
    private string _INSURANCE_CHARGES;
    private string _INSURANCE_CURRENCY, _FREIGHT_CURRENCY;
    private string _INSURANCE_RATE;
  
    private string _max_packages;

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

    public string GOODS_PACK_ID { get { return _GOODS_PACK_ID; } set { _GOODS_PACK_ID = value; } }
    public string GOODS_PACK_JOBNO { get { return _GOODS_PACK_JOBNO; } set { _GOODS_PACK_JOBNO = value; } }
    public string TERMS { get { return _TERMS; } set { _TERMS = value; } }
    public string WHEATHER_UNIT_PRICE { get { return _WHEATHER_UNIT_PRICE; } set { _WHEATHER_UNIT_PRICE = value; } }
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
    public string FREIGHT_CHARGES { get { return _FREIGHT_CHARGES; } set { _FREIGHT_CHARGES = value; } }
    public string FREIGHT_CURRENCY { get { return _FREIGHT_CURRENCY; } set { _FREIGHT_CURRENCY = value; } }
    public string INSURANCE_CHARGES { get { return _INSURANCE_CHARGES; } set { _INSURANCE_CHARGES = value; } }
    public string INSURANCE_CURRENCY { get { return _INSURANCE_CURRENCY; } set { _INSURANCE_CURRENCY = value; } }
    public string INSURANCE_RATE { get { return _INSURANCE_RATE; } set { _INSURANCE_RATE = value; } }
   
    public string max_packages { get { return _max_packages; } set { _max_packages = value; } }
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

    public List<Rpt_Goods_Reg_Invoice> Export_Goods_Reg_Invoice(DataTable dt)
    {

        List<Rpt_Goods_Reg_Invoice> list = new List<Rpt_Goods_Reg_Invoice>();
        list.Clear();
        int i = 0;
        while (dt.Rows.Count > i)
        {

            DataRow row = dt.Rows[i];



            TERMS = row["TERMS"].ToString();
            WHEATHER_UNIT_PRICE = row["WHEATHER_UNIT_PRICE"].ToString();
            INVOICE_SLNO = row["INVOICE_SLNO"].ToString();
            INVOICE_NO = row["INVOICE_NO"].ToString();
            INVOICE_DATE = row["INVOICE_DATE"].ToString();
            FREIGHT_CHARGES = row["FREIGHT_CHARGES"].ToString();
            FREIGHT_CURRENCY = row["FREIGHT_CURRENCY"].ToString();
            INSURANCE_CHARGES = row["INSURANCE_CHARGES"].ToString();
            INSURANCE_CURRENCY = row["INSURANCE_CURRENCY"].ToString();
            INSURANCE_RATE = row["INSURANCE_RATE"].ToString();
            if (INVOICE_DATE == "01/01/1900" || INVOICE_DATE == "01-01-1900")
            {
                INVOICE_DATE = "";
            }
            else
            {
                INVOICE_DATE = INVOICE_DATE;
            }

            i++;



            list.Add(new Rpt_Goods_Reg_Invoice()
            {


                TERMS = TERMS,
                WHEATHER_UNIT_PRICE = WHEATHER_UNIT_PRICE,
                INVOICE_SLNO = INVOICE_SLNO + "     INVOICE NUMBER:" + INVOICE_NO,

                INVOICE_DATE = INVOICE_DATE,
                FREIGHT_CHARGES = FREIGHT_CHARGES,
                FREIGHT_CURRENCY = FREIGHT_CURRENCY,
                INSURANCE_CHARGES = INSURANCE_CHARGES,
                INSURANCE_CURRENCY = INSURANCE_CURRENCY,
                INSURANCE_RATE = INSURANCE_RATE



            });
        }
        
        return list;
    }
}