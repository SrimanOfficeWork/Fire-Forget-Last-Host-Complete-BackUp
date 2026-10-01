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
/// Summary description for Export_Item_Details
/// </summary>
public class Export_Item
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
    public int result, UPDATE_ID = 0, UPDATE_ITEMSLNO = 0, Gridview_Rowcount;
    public string TOTAL_ITEM_VALUE = "";

    # region Private Attributes


    private string _ITEM_ID;
    private string _JOBNO;
    private string _INVOICE_SLNO;
    private string _INVOICE_NO;
    private string _ITEM_SLNO;
    private string _ITEM_DESCRIPTION;
    private string _RITCNO;
    private string _ITEM_QTY;
    private string _ITEM_QTY_CODE;
    private string _ITEM_UNIT_PRICE;
    private string _ITEM_PER;
    private string _ITEM_AMOUNT;
    private string _ITEM_PMVVALUE;
    private string _ITEM_TOTAL_PMVVALUE;
    private string _ITEM_SCHEME_CODE;
    private string _ITEM_ACCESSORIES;
    private string _ITEM_ACCESSORIES_DESC;
    private string _ITEM_AR4;
    private string _ITEM_AR4_NO;
    private string _ITEM_AR4_DATE;
    private string _ITEM_COMMISSION_RATE;
    private string _ITEM_DIVISION;
    private string _ITEM_RANGE;
    private string _ITEM_REMARKS;
    private string _ITEM_CESS;
    private string _ITEM_THIRDPARTY;
    private string _ITEM_IECCODE;
    private string _ITEM_EXPORTER_NAME;
    private string _BR_SLNO;
    private string _ADDRESS1;
    private string _ADDRESS2;
    private string _ADDRESS3;
    private string _ADDRESS4;
    private string _ADDRESS5;
    private string _STR_DETAILS;
    private string _ITEM_STR_CODE;
    private string _REWARD_POINTS;
    private string _PMV_VALUE;
    private string _FOB_VALUE;
    private string _DRAWBACK_VALUE;
    private string _STR_RATE;
    private string _STR_AMOUNT;
    private string _TAXABLE_VALUE;
    private string _IGST_AMT;
    private string _RODTEP_VALUE;

    
    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON;
    private string _CESS_YN;

    private string _Ename;

    private string _startRowIndex;

    private string _maximumRows;
    private string _totalRows;
    private decimal _ITEM_VALUE;
    //private string _XML_String;


    #endregion

    # region Public Attributes

    public string ITEM_ID { get { return _ITEM_ID; } set { _ITEM_ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string ITEM_DESCRIPTION { get { return _ITEM_DESCRIPTION; } set { _ITEM_DESCRIPTION = value; } }
    public string RITCNO { get { return _RITCNO; } set { _RITCNO = value; } }
    public string ITEM_QTY { get { return _ITEM_QTY; } set { _ITEM_QTY = value; } }
    public string ITEM_QTY_CODE { get { return _ITEM_QTY_CODE; } set { _ITEM_QTY_CODE = value; } }
    public string ITEM_UNIT_PRICE { get { return _ITEM_UNIT_PRICE; } set { _ITEM_UNIT_PRICE = value; } }
    public string ITEM_PER { get { return _ITEM_PER; } set { _ITEM_PER = value; } }
    public string ITEM_AMOUNT { get { return _ITEM_AMOUNT; } set { _ITEM_AMOUNT = value; } }

    public string ITEM_PMVVALUE { get { return _ITEM_PMVVALUE; } set { _ITEM_PMVVALUE = value; } }
    public string ITEM_TOTAL_PMVVALUE { get { return _ITEM_TOTAL_PMVVALUE; } set { _ITEM_TOTAL_PMVVALUE = value; } }
    public string ITEM_SCHEME_CODE { get { return _ITEM_SCHEME_CODE; } set { _ITEM_SCHEME_CODE = value; } }
    public string ITEM_ACCESSORIES { get { return _ITEM_ACCESSORIES; } set { _ITEM_ACCESSORIES = value; } }
    public string ITEM_ACCESSORIES_DESC { get { return _ITEM_ACCESSORIES_DESC; } set { _ITEM_ACCESSORIES_DESC = value; } }
    public string ITEM_AR4 { get { return _ITEM_AR4; } set { _ITEM_AR4 = value; } }
    public string ITEM_AR4_NO { get { return _ITEM_AR4_NO; } set { _ITEM_AR4_NO = value; } }
    public string ITEM_AR4_DATE { get { return _ITEM_AR4_DATE; } set { _ITEM_AR4_DATE = value; } }
    public string ITEM_COMMISSION_RATE { get { return _ITEM_COMMISSION_RATE; } set { _ITEM_COMMISSION_RATE = value; } }
    public string ITEM_DIVISION { get { return _ITEM_DIVISION; } set { _ITEM_DIVISION = value; } }
    public string ITEM_RANGE { get { return _ITEM_RANGE; } set { _ITEM_RANGE = value; } }
    public string ITEM_REMARKS { get { return _ITEM_REMARKS; } set { _ITEM_REMARKS = value; } }
    public string ITEM_CESS { get { return _ITEM_CESS; } set { _ITEM_CESS = value; } }
    public string ITEM_THIRDPARTY { get { return _ITEM_THIRDPARTY; } set { _ITEM_THIRDPARTY = value; } }
    public string ITEM_IECCODE { get { return _ITEM_IECCODE; } set { _ITEM_IECCODE = value; } }
    public string ITEM_EXPORTER_NAME { get { return _ITEM_EXPORTER_NAME; } set { _ITEM_EXPORTER_NAME = value; } }
    
    public string BR_SLNO { get { return _BR_SLNO; } set { _BR_SLNO = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }
    public string STR_DETAILS { get { return _STR_DETAILS; } set { _STR_DETAILS = value; } }
    
    public string ITEM_STR_CODE { get { return _ITEM_STR_CODE; } set { _ITEM_STR_CODE = value; } }
    public string REWARD_POINTS { get { return _REWARD_POINTS; } set { _REWARD_POINTS = value; } }
    public string PMV_VALUE { get { return _PMV_VALUE; } set { _PMV_VALUE = value; } }
    public string FOB_VALUE { get { return _FOB_VALUE; } set { _FOB_VALUE = value; } }
    public string DRAWBACK_VALUE { get { return _DRAWBACK_VALUE; } set { _DRAWBACK_VALUE = value; } }
    public string TAXABLE_VALUE { get { return _TAXABLE_VALUE; } set { _TAXABLE_VALUE = value; } }
    public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }
    public string RODTEP_VALUE { get { return _RODTEP_VALUE; } set { _RODTEP_VALUE = value; } }


    public string STR_RATE { get { return _STR_RATE; } set { _STR_RATE = value; } }
    public string STR_AMOUNT { get { return _STR_AMOUNT; } set { _STR_AMOUNT = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }

    public string CESS_YN { get { return _CESS_YN; } set { _CESS_YN = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    public decimal ITEM_VALUE { get { return _ITEM_VALUE; } set { _ITEM_VALUE = value; } }
    //public string XML_String { get { return _XML_String; } set { _XML_String = value; } }

    #endregion


    #region Insert & Update

    public DataSet Export_Item_Details_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@ITEM_ID", ITEM_ID);

            param[1] = new SqlParameter("@JOBNO", JOBNO);

            param[2] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);

            param[3] = new SqlParameter("@INVOICE_NO", INVOICE_NO);

            param[4] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);

            param[5] = new SqlParameter("@ITEM_DESCRIPTION", ITEM_DESCRIPTION);

            param[6] = new SqlParameter("@RITCNO", RITCNO);

            param[7] = new SqlParameter("@ITEM_QTY", ITEM_QTY);

            param[8] = new SqlParameter("@ITEM_QTY_CODE", ITEM_QTY_CODE);

            param[9] = new SqlParameter("@ITEM_UNIT_PRICE", ITEM_UNIT_PRICE);

            param[10] = new SqlParameter("@ITEM_PER", ITEM_PER);

            param[42] = new SqlParameter("@ITEM_AMOUNT", ITEM_AMOUNT);

            param[11] = new SqlParameter("@ITEM_PMVVALUE", ITEM_PMVVALUE);

            //param[12] = new SqlParameter("@ITEM_TOTAL_PMVVALUE", ITEM_TOTAL_PMVVALUE);

            param[13] = new SqlParameter("@ITEM_SCHEME_CODE", ITEM_SCHEME_CODE);

            //param[14] = new SqlParameter("@ITEM_ACCESSORIES", ITEM_ACCESSORIES);

            param[15] = new SqlParameter("@ITEM_ACCESSORIES_DESC", ITEM_ACCESSORIES_DESC);

            //param[16] = new SqlParameter("@ITEM_AR4", ITEM_AR4);

            param[17] = new SqlParameter("@ITEM_AR4_NO", ITEM_AR4_NO);

            param[18] = new SqlParameter("@ITEM_AR4_DATE", DateTime.Parse(ITEM_AR4_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[19] = new SqlParameter("@ITEM_COMMISSION_RATE", ITEM_COMMISSION_RATE);

            param[20] = new SqlParameter("@ITEM_DIVISION", ITEM_DIVISION);

            param[21] = new SqlParameter("@ITEM_RANGE", ITEM_RANGE);

            param[22] = new SqlParameter("@ITEM_REMARKS", ITEM_REMARKS);

            //param[23] = new SqlParameter("@ITEM_CESS", ITEM_CESS);

            //param[24] = new SqlParameter("@ITEM_THIRDPARTY", ITEM_THIRDPARTY);

            param[25] = new SqlParameter("@ITEM_IECCODE", ITEM_IECCODE);

            param[43] = new SqlParameter("@ITEM_EXPORTER_NAME", ITEM_EXPORTER_NAME);

            param[26] = new SqlParameter("@BR_SLNO", BR_SLNO);

            param[27] = new SqlParameter("@ADDRESS1", ADDRESS1);

            param[28] = new SqlParameter("@ADDRESS2", ADDRESS2);

            param[29] = new SqlParameter("@ADDRESS3", ADDRESS3);

            param[30] = new SqlParameter("@ADDRESS4", ADDRESS4);

            param[31] = new SqlParameter("@ADDRESS5", ADDRESS5);

            //param[32] = new SqlParameter("@STR_DETAILS", STR_DETAILS);

            param[33] = new SqlParameter("@ITEM_STR_CODE", ITEM_STR_CODE);

            param[34] = new SqlParameter("@REWARD_POINTS", REWARD_POINTS);

            param[35] = new SqlParameter("@USER_ID", USER_ID);

            param[36] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);

            param[37] = new SqlParameter("@YEAR", YEAR);

            param[38] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[47] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[48] = new SqlParameter("@CESS_YN", CESS_YN);

            param[39] = new SqlParameter("@Mflag", flag);

            param[40] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[40].Direction = ParameterDirection.Output;

            param[41] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            param[41].Direction = ParameterDirection.Output;
            param[44] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[44].Direction = ParameterDirection.Output;
            param[45] = new SqlParameter("@UPDATE_ITEMSLNO", SqlDbType.Int, 1);
            param[45].Direction = ParameterDirection.Output;
            param[46] = new SqlParameter("@TOTAL_PRODUCT_VALUE", SqlDbType.Money);
            param[46].Direction = ParameterDirection.Output;
            ds=SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_ITEM_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[40].Value.ToString());
            
            TOTAL_ITEM_VALUE = param[46].Value.ToString();
            if (TOTAL_ITEM_VALUE != "")
                TOTAL_ITEM_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(TOTAL_ITEM_VALUE), 2).ToString("0.00"));
            string err = param[41].Value.ToString();

            
            if (flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[44].Value.ToString());
                UPDATE_ITEMSLNO = Convert.ToInt32(param[45].Value.ToString());
            }
            else if (flag == "U")
                //UPDATE_ITEMSLNO = Convert.ToInt32(ITEM_SLNO);
                UPDATE_ITEMSLNO = Convert.ToInt32(param[45].Value.ToString());

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Gridview_Rowcount = ds.Tables[0].Rows.Count;

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

    public DataSet Export_Item_PMV_FOB_VLAUE_UPDATE()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@ITEM_ID", ITEM_ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@INV_SLNO", INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[4] = new SqlParameter("@PMV_VALUE", PMV_VALUE);
            param[5] = new SqlParameter("@FOB_VALUE", FOB_VALUE);
            param[6] = new SqlParameter("@DRAWBACK_VALUE", DRAWBACK_VALUE);
            param[7] = new SqlParameter("@STR_RATE", STR_RATE);
            param[8] = new SqlParameter("@STR_AMOUNT", STR_AMOUNT);
            param[9] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[10] = new SqlParameter("@ITEM_PMVVALUE", ITEM_PMVVALUE);
            param[11] = new SqlParameter("@TAXABLE_VALUE", TAXABLE_VALUE);
            param[12] = new SqlParameter("@IGST_AMT", IGST_AMT);
            param[17] = new SqlParameter("@RODTEP_VALUE", RODTEP_VALUE);  
       
            param[13] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[14] = new SqlParameter("@Mflag", flag);
            param[15] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_ITEM_PMV_FOB_VALUE_UPDATE", param);

            result = Convert.ToInt32(param[15].Value.ToString());
           

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


    public DataSet RetrieveAll_Item_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JOBNO", JOBNO);

            param[7] = new SqlParameter("@ITEM_ID", ITEM_ID);

            param[1] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);

            param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);

            param[3] = new SqlParameter("@name", Ename);

            param[4] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@INVOICE_NO", INVOICE_NO);
            param[9] = new SqlParameter("@TOTAL_PRODUCT_VALUE", SqlDbType.Money);
            param[9].Direction = ParameterDirection.Output;
            //param[6] = new SqlParameter("@Mflag", flag);

            if (Ename == "select_con" || Ename == "Item_Move" || Ename == "Item_MoveUp" || Ename == "Item_MoveDown")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_ITEM_DETAILS_SELECT", param);
                
            }
            else if (Ename == "product_value")
            {
                ds=SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_ITEM_DETAILS_SELECT", param);
                
            }
            else if (Ename == "select_Invoice_No")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_ITEM_DETAILS_SELECT", param);
                
            }
            else if (Ename == "select_Item_SLNo" || Ename == "Item_Sl_No_Select" || Ename == "Select_BindAll_ItemDetails")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_ITEM_DETAILS_SELECT", param);
                
            }
            else if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_ITEM_DETAILS_SELECT", param);
                
                result = Convert.ToInt32(param[5].Value.ToString());
                
            }
            string err = param[6].Value.ToString();
               
           
            TOTAL_ITEM_VALUE = param[9].Value.ToString();
            if (TOTAL_ITEM_VALUE != "")
                TOTAL_ITEM_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(TOTAL_ITEM_VALUE), 2).ToString("0.00"));

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Gridview_Rowcount = ds.Tables[0].Rows.Count;
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


    public double RetrieveAll_Item_Calc()
    {
        double f = 0;
        try
        {

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);

            param[7] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);

            param[1] = new SqlParameter("@QTY", ITEM_QTY);

            // param[2] = new SqlParameter("@UNITPRICE",ITEM_UNIT_PRICE);

            param[3] = new SqlParameter("@Mflag", Ename);

            param[4] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Money);
            param[5].Direction = ParameterDirection.Output;
            // param[5].Precision = ParameterDirection.Output;
            // param[5].Scale = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ITEM_VALUE", ITEM_VALUE);
            param[9] = new SqlParameter("@flag", flag);
            param[10] = new SqlParameter("@ITEM_ID", ITEM_ID);


            //param[6] = new SqlParameter("@Mflag", flag);

            if (Ename == "QTY")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_ITEM_DETAILS_INSERT_UPDATE_CALC", param);
                string err = param[6].Value.ToString();
                
                f = Convert.ToDouble(param[5].Value);

            }
            else if (Ename == "UNITPRICE")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_ITEM_DETAILS_INSERT_UPDATE_CALC", param);
                string err = param[6].Value.ToString();
                f = Convert.ToDouble(param[5].Value);

                // f = param[5].Value.ToString();

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return f;
    }


    public DataSet Export_Item_PMV_FOB_VLAUE_UPDATE_Bulk_New(string XML_String, string BRANCH_CODE, string flag)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@xmlString", XML_String);
            param[1] = new SqlParameter("@Branch_Code", BRANCH_CODE);
            param[2] = new SqlParameter("@flag", flag);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_ITEM_PMV_FOB_VALUE_UPDATE_New", param);

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

}