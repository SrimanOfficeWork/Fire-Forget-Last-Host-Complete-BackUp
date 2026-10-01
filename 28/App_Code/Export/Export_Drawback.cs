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
/// Summary description for Export_Drawback
/// </summary>
public class Export_Drawback
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

    private string _DRAWBACK_ID, _RITC_NO, _ITEM_DESCRIPTION;
    private string _JOBNO;
    private string _INVOICE_SLNO;
    private string _ITEM_SLNO;
    private string _SCHEME_CODE;
    private string _DRAWBACK_SLNO;
    private string _DRAWBACK_QTY;
    private string _DRAWBACK_UNIT;
    private string _DRAWBACK_NOOFUNITS;
    private string _DRAWBACK_RATE;
    private string _DRAWBACK_CAPS;
    private string _DRAWBACK_DESC;
    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON;
    private string _STATE_LEVEL_ADV_RATE;
    private string _STATE_LEVEL_ADV_AMT;
    private string _CENTRAL_LEVEL_ADV_RATE;
    private string _CENTRAL_LEVEL_ADV_AMT;
    private string _Ename;
    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;
    private decimal _ITEM_VALUE;
    private string _AMENDMENT_TYPE;
    private string _AMENDMENT_STATUS;
    private string _JOBNO_PS;

    
    #endregion

    # region Public Attributes

    public string DRAWBACK_ID { get { return _DRAWBACK_ID; } set { _DRAWBACK_ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string SCHEME_CODE { get { return _SCHEME_CODE; } set { _SCHEME_CODE = value; } }
    public string RITC_NO { get { return _RITC_NO; } set { _RITC_NO = value; } }
    public string ITEM_DESCRIPTION { get { return _ITEM_DESCRIPTION; } set { _ITEM_DESCRIPTION = value; } }
    public string DRAWBACK_SLNO { get { return _DRAWBACK_SLNO; } set { _DRAWBACK_SLNO = value; } }
    public string DRAWBACK_QTY { get { return _DRAWBACK_QTY; } set { _DRAWBACK_QTY = value; } }
    public string DRAWBACK_UNIT { get { return _DRAWBACK_UNIT; } set { _DRAWBACK_UNIT = value; } }
    public string DRAWBACK_NOOFUNITS { get { return _DRAWBACK_NOOFUNITS; } set { _DRAWBACK_NOOFUNITS = value; } }
    public string DRAWBACK_RATE { get { return _DRAWBACK_RATE; } set { _DRAWBACK_RATE = value; } }
    public string DRAWBACK_CAPS { get { return _DRAWBACK_CAPS; } set { _DRAWBACK_CAPS = value; } }
    public string DRAWBACK_DESC { get { return _DRAWBACK_DESC; } set { _DRAWBACK_DESC = value; } }
    public string STATE_LEVEL_ADV_RATE { get { return _STATE_LEVEL_ADV_RATE; } set { _STATE_LEVEL_ADV_RATE = value; } }
    public string STATE_LEVEL_ADV_AMT { get { return _STATE_LEVEL_ADV_AMT; } set { _STATE_LEVEL_ADV_AMT = value; } }
    public string CENTRAL_LEVEL_ADV_RATE { get { return _CENTRAL_LEVEL_ADV_RATE; } set { _CENTRAL_LEVEL_ADV_RATE = value; } }
    public string CENTRAL_LEVEL_ADV_AMT { get { return _CENTRAL_LEVEL_ADV_AMT; } set { _CENTRAL_LEVEL_ADV_AMT = value; } }
    public string AMENDMENT_TYPE { get { return _AMENDMENT_TYPE; } set { _AMENDMENT_TYPE = value; } }
    public string AMENDMENT_STATUS { get { return _AMENDMENT_STATUS; } set { _AMENDMENT_STATUS = value; } }
    public string JOBNO_PS { get { return _JOBNO_PS; } set { _JOBNO_PS = value; } }
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

    public int Export_Drawback_Insert_Update()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@DRAWBACK_ID", DRAWBACK_ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[4] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);
            param[5] = new SqlParameter("@DRAWBACK_SLNO", DRAWBACK_SLNO);
            param[6] = new SqlParameter("@DRAWBACK_QTY", DRAWBACK_QTY);
            param[7] = new SqlParameter("@DRAWBACK_UNIT", DRAWBACK_UNIT);
            param[11] = new SqlParameter("@DRAWBACK_NOOFUNITS", DRAWBACK_NOOFUNITS);
            param[8] = new SqlParameter("@DRAWBACK_RATE", DRAWBACK_RATE);
            param[9] = new SqlParameter("@DRAWBACK_CAPS", DRAWBACK_CAPS);
            param[10] = new SqlParameter("@DRAWBACK_DESC", DRAWBACK_DESC);
            param[13] = new SqlParameter("@USER_ID", USER_ID);
            param[14] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[15] = new SqlParameter("@YEAR", YEAR);
            param[16] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[20] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[17] = new SqlParameter("@Mflag", flag);

            param[21] = new SqlParameter("@STATE_LEVEL_ADV_RATE", STATE_LEVEL_ADV_RATE);
            param[22] = new SqlParameter("@STATE_LEVEL_ADV_AMT", STATE_LEVEL_ADV_AMT);
            param[23] = new SqlParameter("@CENTRAL_LEVEL_ADV_RATE", CENTRAL_LEVEL_ADV_RATE);
            param[24] = new SqlParameter("@CENTRAL_LEVEL_ADV_AMT", CENTRAL_LEVEL_ADV_AMT);
            param[25] = new SqlParameter("@AMENDMENT_TYPE", AMENDMENT_TYPE);
            param[26] = new SqlParameter("@AMENDMENT_STATUS", AMENDMENT_STATUS);
            param[27] = new SqlParameter("@JOBNO_PS", JOBNO_PS);

            param[18] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_DRAWBACK_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[18].Value.ToString());
            string err = param[19].Value.ToString();

        }
        catch (Exception ex)
        {

            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return result;
    }

    #endregion


    public DataSet Export_Drawback_Slno_Auto_Bind_Insert_Update()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[3] = new SqlParameter("@ITEM_DESCRIPTION", DRAWBACK_SLNO);
            param[4] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);
            param[5] = new SqlParameter("@RITC_NO", RITC_NO);
            param[6] = new SqlParameter("@WORKING_PERIOD", BRANCH_CODE);
            param[7] = new SqlParameter("@name", Ename);
            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            if (Ename == "Dbk_auto_Insert_Update")
            {
                SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_DRAWBACK_DETAILS", param);
                result = Convert.ToInt32(param[9].Value.ToString());
            }

            else if (Ename == "Dbk_auto_bind")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_DRAWBACK_DETAILS", param);
                result = Convert.ToInt32(param[9].Value.ToString());

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
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }



    public DataSet RetrieveAll_Drawback_Details()
    {
        DataTable dt = new DataTable();

        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[4] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);
            param[9] = new SqlParameter("@RITC_NO", RITC_NO);
            param[10] = new SqlParameter("@ITEM_DESCRIPTION", ITEM_DESCRIPTION);

            param[5] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;


            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_DRAWBACK_DETAILS", param);
                result = Convert.ToInt32(param[7].Value.ToString());
            }
            else if (Ename == "select" || Ename == "select_DBK_srno" || Ename == "Check_RITC_Desc_ProductExportMaster" || Ename == "Check_DBK_Avail")
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_DRAWBACK_DETAILS", param);
                result = Convert.ToInt32(param[7].Value.ToString());
                string err = param[8].Value.ToString();

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