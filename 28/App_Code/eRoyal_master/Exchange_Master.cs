using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Net;

/// <summary>
/// Summary description for Exchange_Master
/// </summary>
public class Exchange_Master
{
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet dtuser = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    SqlDataReader dr;
    SqlCommand cmd;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public int result = 0;

    #region private Attributes

    private string _EXCHANGE_ID;
    private string _EXCHANGE_EFFECT_DT_FROM;
    private string _EXCHANGE_EFFECT_DT_TO;
    private string _EXCHANGE_NONT_NO;
    private string _EXCHANGE_NOTN_DATE;
    private string _EXCHANGE_CUR_CODE;
    private string _EXCHANGE_NAME;
    private string _EXCHANGE_PER_UNIT;
    private string _EXCHANGE_RATE_IMPORT;
    private string _EXCHANGE_RATE_EXPORT;
    private string _EXCHANGE_S_OR_N;

    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _EWorking_Period;

    private string _Eexchange_id;
    private string _Eexchange_effect_dt_from;
    private string _Eexchange_effect_dt_to;
    private string _Eexchange_nont_no;
    private string _Eexchange_notn_date;

    private string _Ename;
   

    #endregion

    #region Public Attributes

    public string EXCHANGE_ID { get { return _EXCHANGE_ID; } set { _EXCHANGE_ID = value; } }
    public string EXCHANGE_EFFECT_DT_FROM { get { return _EXCHANGE_EFFECT_DT_FROM; } set { _EXCHANGE_EFFECT_DT_FROM = value; } }
    public string EXCHANGE_EFFECT_DT_TO { get { return _EXCHANGE_EFFECT_DT_TO; } set { _EXCHANGE_EFFECT_DT_TO = value; } }
    public string EXCHANGE_NONT_NO { get { return _EXCHANGE_NONT_NO; } set { _EXCHANGE_NONT_NO = value; } }
    public string EXCHANGE_NOTN_DATE { get { return _EXCHANGE_NOTN_DATE; } set { _EXCHANGE_NOTN_DATE = value; } }
    public string EXCHANGE_CUR_CODE { get { return _EXCHANGE_CUR_CODE; } set { _EXCHANGE_CUR_CODE = value; } }
    public string EXCHANGE_NAME { get { return _EXCHANGE_NAME; } set { _EXCHANGE_NAME = value; } }
    public string EXCHANGE_PER_UNIT { get { return _EXCHANGE_PER_UNIT; } set { _EXCHANGE_PER_UNIT = value; } }
    public string EXCHANGE_RATE_IMPORT { get { return _EXCHANGE_RATE_IMPORT; } set { _EXCHANGE_RATE_IMPORT = value; } }
    public string EXCHANGE_RATE_EXPORT { get { return _EXCHANGE_RATE_EXPORT; } set { _EXCHANGE_RATE_EXPORT = value; } }
    public string EXCHANGE_S_OR_N { get { return _EXCHANGE_S_OR_N; } set { _EXCHANGE_S_OR_N = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string EWorking_Period { get { return _EWorking_Period; } set { _EWorking_Period = value; } }

    #endregion

    #region Retrieve Attributes

    public string Eexchange_id { get { return _Eexchange_id; } set { _Eexchange_id = value; } }
    public string Eexchange_effect_dt_from { get { return _Eexchange_effect_dt_from; } set { _Eexchange_effect_dt_from = value; } }
    public string Eexchange_effect_dt_to { get { return _Eexchange_effect_dt_to; } set { _Eexchange_effect_dt_to = value; } }
    public string Eexchange_nont_no { get { return _Eexchange_nont_no; } set { _Eexchange_nont_no = value; } }
    public string Eexchange_notn_date { get { return _Eexchange_notn_date; } set { _Eexchange_notn_date = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
   

    #endregion

    #region Insert & Update

    public int Exchange_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@EXCHANGE_ID", EXCHANGE_ID);
            param[1] = new SqlParameter("@EXCHANGE_EFFECT_DT_FROM", EXCHANGE_EFFECT_DT_FROM);

            param[2] = new SqlParameter("@EXCHANGE_EFFECT_DT_TO", EXCHANGE_EFFECT_DT_TO);
            param[3] = new SqlParameter("@EXCHANGE_NONT_NO", EXCHANGE_NONT_NO);
            param[4] = new SqlParameter("@EXCHANGE_NOTN_DATE", EXCHANGE_NOTN_DATE);
            param[5] = new SqlParameter("@EXCHANGE_CUR_CODE", EXCHANGE_CUR_CODE);
            param[6] = new SqlParameter("@EXCHANGE_NAME", EXCHANGE_NAME);
            param[7] = new SqlParameter("@EXCHANGE_PER_UNIT", EXCHANGE_PER_UNIT);
            param[8] = new SqlParameter("@EXCHANGE_RATE_IMPORT", EXCHANGE_RATE_IMPORT);
            param[9] = new SqlParameter("@EXCHANGE_RATE_EXPORT", EXCHANGE_RATE_EXPORT);
            param[10] = new SqlParameter("@EXCHANGE_S_OR_N", EXCHANGE_S_OR_N);

            param[11] = new SqlParameter("@EXCHANGE_USER_ID", USER_ID);
            param[17] = new SqlParameter("@EXCHANGE_BRANCH_CODE", BRANCH_CODE);
            param[12] = new SqlParameter("@EXCHANGE_YEAR", YEAR);
            param[13] = new SqlParameter("@EXCHANGE_WORKING_PERIOD", EWorking_Period);
            param[14] = new SqlParameter("@Mflag", flag);



            param[15] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[15].Value.ToString());



        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return result;

    }

    #endregion

    #region Retrieve Record

    public DataSet RetrieveAll_Exchange_master()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@EXCHANGE_ID", Eexchange_id);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            //param[3] = new SqlParameter("@EXCHANGE_EFFECT_DT_FROM", fdt);
            //param[4] = new SqlParameter("@EXCHANGE_EFFECT_DT_TO", tdt);

            //param[3] = new SqlParameter("@EXCHANGE_EFFECT_DT_FROM",DateTime.ParseExact(Eexchange_effect_dt_from, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat));

            param[3] = new SqlParameter("@EXCHANGE_EFFECT_DT_FROM", Eexchange_effect_dt_from);
            // param[4] = new SqlParameter("@EXCHANGE_EFFECT_DT_TO", DateTime.ParseExact(Eexchange_effect_dt_to, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat));

            param[4] = new SqlParameter("@EXCHANGE_EFFECT_DT_TO", Eexchange_effect_dt_to);
            param[5] = new SqlParameter("@EXCHANGE_NONT_NO", Eexchange_nont_no);
            param[6] = new SqlParameter("@EXCHANGE_NOTN_DATE", Eexchange_notn_date);


            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);

            param[10] = new SqlParameter("@maximumRows", maximumRows);

            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[7].Value.ToString());


            }


            else
            {
                // ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXCHANGE_MASTER_SEARCH_SELECT", param);
                string s = param[8].Value.ToString();
                result = Convert.ToInt32(param[11].Value.ToString());


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

            er.makeLog(ex.Message);
        }


        return ds;


    }

    #endregion
}