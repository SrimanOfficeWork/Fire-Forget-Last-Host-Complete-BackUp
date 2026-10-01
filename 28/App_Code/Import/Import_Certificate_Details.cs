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
/// Summary description for Import_Certificate_Details
/// </summary>
public class Import_Certificate_Details
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
    public string err;

    # region Common Attributes

    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _JOBNO;

    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    #endregion


    #region Private Attributes

    private string _CERTIFICATEID;
    private string _CERTIFICATE_NO;
    private string _CERTIFICATE_DATE;
    private string _CERTIFICATE_TYPE;
    private string _Ename;

    #endregion

    #region Public Attributes

    public string CERTIFICATEID { get { return _CERTIFICATEID; } set { _CERTIFICATEID = value; } }

    public string CERTIFICATE_NO { get { return _CERTIFICATE_NO; } set { _CERTIFICATE_NO = value; } }
    public string CERTIFICATE_DATE { get { return _CERTIFICATE_DATE; } set { _CERTIFICATE_DATE = value; } }
    public string CERTIFICATE_TYPE { get { return _CERTIFICATE_TYPE; } set { _CERTIFICATE_TYPE = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }

    #endregion

    #region Insert & Update 

    public DataSet CERTIFICATE_Details_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);

            param[11] = new SqlParameter("@CERTIFICATEID", CERTIFICATEID);

            param[1] = new SqlParameter("@CERTIFICATE_NO", CERTIFICATE_NO);

            param[2] = new SqlParameter("@CERTIFICATE_DATE", DateTime.Parse(CERTIFICATE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[10] = new SqlParameter("@CERTIFICATE_TYPE", CERTIFICATE_TYPE);

            param[3] = new SqlParameter("@USER_ID", USER_ID);
            param[4] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[5] = new SqlParameter("@YEAR", YEAR);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[7] = new SqlParameter("@Mflag", flag);
            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CERTIFICATE_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[8].Value.ToString());

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

    #region Retrieve Record

    public DataSet RetrieveAll_Certificate_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JOBNO", JOBNO);

            param[1] = new SqlParameter("@CERTIFICATE_NO", CERTIFICATE_NO);

            param[2] = new SqlParameter("@name", Ename);

            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;


            //param[6] = new SqlParameter("@Mflag", flag);

            if (Ename == "select_con")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CERTIFICATE_DETAILS_SELECT", param);
                string err = param[5].Value.ToString();

            }
            else if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CERTIFICATE_DETAILS_SELECT", param);
                //string err = param[5].Value.ToString();
                //string status = param[4].Value.ToString();
                result = Convert.ToInt32(param[4].Value.ToString());
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

    #endregion
}