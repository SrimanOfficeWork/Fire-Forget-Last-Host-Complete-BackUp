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
/// Summary description for Export_Cess_Details
/// </summary>
public class Export_Cess_Details
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
    public int result, Update_id;

    # region Private Attributes

    private string _CESS_ID;
    private string _INVOICE_SLNO;
    private string _ITEM_SLNO;
    private string _CESS_JOBNO;
    private string _CESS_SLNO;
    private string _CESS_VALUE;
    private string _CESS_UNIT;
    private string _CESS_FLAG;
    private string _CESS_RATE;
    private string _CESS_ITEM_QTY;
    private string _CESS_ITEM_QTY_CODE;
    private string _CESS_TARIFF_VALUE;
    private string _CESS_TARIFF_UNIT;
    private string _RITC_NO;

    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON;

    private string _Ename;

    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;

     private string _DUTY_SLNO;
     private string _DUTY_RATE;
     private string _DUTY_AMOUNT;
     private string _DUTY_UNIT;
     private string _DUTY_QTY;

     public int UPDATE_ID = 0;
    #endregion

    # region Public Attributes
    public string CESS_ID { get { return _CESS_ID; } set { _CESS_ID = value; } }
    public string CESS_JOBNO { get { return _CESS_JOBNO; } set { _CESS_JOBNO = value; } }

    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string CESS_SLNO { get { return _CESS_SLNO; } set { _CESS_SLNO = value; } }
    public string CESS_VALUE { get { return _CESS_VALUE; } set { _CESS_VALUE = value; } }
    public string CESS_UNIT { get { return _CESS_UNIT; } set { _CESS_UNIT = value; } }

    public string CESS_FLAG { get { return _CESS_FLAG; } set { _CESS_FLAG = value; } }
    public string CESS_RATE { get { return _CESS_RATE; } set { _CESS_RATE = value; } }
    public string CESS_ITEM_QTY { get { return _CESS_ITEM_QTY; } set { _CESS_ITEM_QTY = value; } }
    public string CESS_ITEM_QTY_CODE { get { return _CESS_ITEM_QTY_CODE; } set { _CESS_ITEM_QTY_CODE = value; } }
    public string CESS_TARIFF_VALUE { get { return _CESS_TARIFF_VALUE; } set { _CESS_TARIFF_VALUE = value; } }
    public string CESS_TARIFF_UNIT { get { return _CESS_TARIFF_UNIT; } set { _CESS_TARIFF_UNIT = value; } }
    public string RITC_NO { get { return _RITC_NO; } set { _RITC_NO = value; } }

    
    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }

    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }


    
    public string DUTY_SLNO { get { return _DUTY_SLNO; } set { _DUTY_SLNO = value; } }
    public string DUTY_RATE { get { return _DUTY_RATE; } set { _DUTY_RATE = value; } }
    public string DUTY_AMOUNT { get { return _DUTY_AMOUNT; } set { _DUTY_AMOUNT = value; } }
    public string DUTY_UNIT { get { return _DUTY_UNIT; } set { _DUTY_UNIT = value; } }

    public string DUTY_QTY { get { return _DUTY_QTY; } set { _DUTY_QTY = value; } }
    

    #endregion

    #region Insert & Update

    public DataSet Export_Cess_details_insertupdate()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[70];

            param[1] = new SqlParameter("@CESS_ID", CESS_ID);
            param[2] = new SqlParameter("@JOBNO", CESS_JOBNO);
            param[3] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[4] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[5] = new SqlParameter("@CESS_SLNO", CESS_SLNO);
            param[6] = new SqlParameter("@CESS_VALUE", CESS_VALUE);
            param[7] = new SqlParameter("@CESS_UNIT", CESS_UNIT);
            param[8] = new SqlParameter("@CESS_FLAG", CESS_FLAG);
            param[9] = new SqlParameter("@CESS_RATE", CESS_RATE);
            param[10] = new SqlParameter("@CESS_ITEM_QTY", CESS_ITEM_QTY);
            param[11] = new SqlParameter("@CESS_ITEM_QTY_CODE", CESS_ITEM_QTY_CODE);
            param[12] = new SqlParameter("@CESS_TARIFF_VALUE", CESS_TARIFF_VALUE);
            param[13] = new SqlParameter("@CESS_TARIFF_UNIT", CESS_TARIFF_UNIT);
            param[14] = new SqlParameter("@USER_ID", USER_ID);
            param[15] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[16] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[17] = new SqlParameter("@DATE_TIME", "01/01/2012");
            param[18] = new SqlParameter("@STATUS", "ss");
            param[19] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[24] = new SqlParameter("@YEAR", YEAR);
            param[25] = new SqlParameter("@Mflag", flag);
            param[26] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[26].Direction = ParameterDirection.Output;

            param[27] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[27].Direction = ParameterDirection.Output;

            param[28] = new SqlParameter("@Update_id", SqlDbType.Int, 1);
            param[28].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_CESS_DETAILS_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[26].Value.ToString());

            UPDATE_ID = Convert.ToInt32(param[28].Value.ToString());

            string err = param[26].Value.ToString();
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

    #endregion


    public DataSet RetrieveAll_Cess_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];

            param[8] = new SqlParameter("@CESS_ID", CESS_ID);
            param[0] = new SqlParameter("@JOBNO", CESS_JOBNO);

            param[1] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);

            param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);

            //param[9] = new SqlParameter("@RITC_NO", RITC_NO);

            param[3] = new SqlParameter("@name", Ename);
            param[4] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;      

            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_CESS_DETAILS", param);

                result = Convert.ToInt32(param[5].Value.ToString());
            }
            else if (Ename == "select")
            {               
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_CESS_DETAILS", param);

                string err = param[6].Value.ToString();
                //result = Convert.ToInt32(param[11].Value.ToString());
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
}