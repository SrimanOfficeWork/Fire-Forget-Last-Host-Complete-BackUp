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
/// Summary description for Export_Jobbing
/// </summary>
public class Export_Jobbing
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
    public int result, UPDATE_ID=0;

    # region Private Attributes


    private string _JOBBING_ID;
    private string _JOBNO;
    private string _INVOICE_SLNO;
    private string _ITEM_SLNO;
    private string _SCHEME_CODE;
    private string _NOTIFICATION_NO;
    private string _BE_NO;
    private string _BE_DATE;
    private string _BE_INV_SLNO;
    private string _BE_INV_NO;
    private string _BE_ITEM_NO;
    private string _BE_PORT_CODE;
    private string _QTY;
    private string _UNIT;
   
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
    private decimal _ITEM_VALUE;


    #endregion


    # region Public Attributes

    public string JOBBING_ID { get { return _JOBBING_ID; } set { _JOBBING_ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
   
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string SCHEME_CODE { get { return _SCHEME_CODE; } set { _SCHEME_CODE = value; } }

    public string NOTIFICATION_NO { get { return _NOTIFICATION_NO; } set { _NOTIFICATION_NO = value; } }

    public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }

    public string BE_DATE { get { return _BE_DATE; } set { _BE_DATE = value; } }

    public string BE_INV_SLNO { get { return _BE_INV_SLNO; } set { _BE_INV_SLNO = value; } }

    public string BE_INV_NO { get { return _BE_INV_NO; } set { _BE_INV_NO = value; } }

    public string BE_ITEM_NO { get { return _BE_ITEM_NO; } set { _BE_ITEM_NO = value; } }

    public string BE_PORT_CODE { get { return _BE_PORT_CODE; } set { _BE_PORT_CODE = value; } }

    public string QTY { get { return _QTY; } set { _QTY = value; } }

    public string UNIT { get { return _UNIT; } set { _UNIT = value; } }

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

    public decimal ITEM_VALUE { get { return _ITEM_VALUE; } set { _ITEM_VALUE = value; } }

    #endregion

    #region Insert & Update

    public DataSet Export_Jobbing_Insert_Update()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@JOBBING_ID", JOBBING_ID);

            param[1] = new SqlParameter("@JOBNO", JOBNO);

            param[2] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);

            param[3] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);

            param[4] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);

            param[5] = new SqlParameter("@NOTIFICATION_NO", NOTIFICATION_NO);

            param[6] = new SqlParameter("@BE_NO", BE_NO);

            param[7] = new SqlParameter("@BE_DATE", DateTime.Parse(BE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[8] = new SqlParameter("@BE_INV_SLNO", BE_INV_SLNO);

            param[9] = new SqlParameter("@BE_INV_NO", BE_INV_NO);

            param[10] = new SqlParameter("@BE_ITEM_NO", BE_ITEM_NO);

            param[20] = new SqlParameter("@BE_PORT_CODE", BE_PORT_CODE);

            param[11] = new SqlParameter("@QTY", QTY);

            param[12] = new SqlParameter("@UNIT", UNIT);

            param[13] = new SqlParameter("@USER_ID", USER_ID);

            param[14] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);

            param[15] = new SqlParameter("@YEAR", YEAR);

            param[16] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[22] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[17] = new SqlParameter("@Mflag", flag);

            param[18] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[18].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            param[19].Direction = ParameterDirection.Output;
            param[21] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[21].Direction = ParameterDirection.Output;
            //SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_JOBBING_INSERT_UPDATE", param);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_JOBBING_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[18].Value.ToString());
            string err = param[19].Value.ToString();
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[21].Value.ToString());
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


    public DataSet RetrieveAll_Jobbing_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JOBNO", JOBNO);

            param[1] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);



            param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);

            param[3] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);

            param[8] = new SqlParameter("@JOBBING_ID", JOBBING_ID);

            param[4] = new SqlParameter("@name", Ename);

            param[5] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;


            //param[6] = new SqlParameter("@Mflag", flag);

            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_JOBBING_SELECT", param);
                string err = param[7].Value.ToString();

            }
            else if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_JOBBING_SELECT", param);
                //string err = param[5].Value.ToString();
                //string status = param[4].Value.ToString();
                result = Convert.ToInt32(param[6].Value.ToString());
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
}