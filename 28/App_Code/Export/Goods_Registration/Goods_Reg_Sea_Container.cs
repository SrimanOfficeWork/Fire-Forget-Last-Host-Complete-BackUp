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
/// Summary description for Goods_Reg_Sea_Container
/// </summary>
public class Goods_Reg_Sea_Container
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

    private string _GOODS_SEA_CON_ID;
    private string _GOODS_SEA_CON_JOBNO;
    private string _GOODS_SEA_CON_CONTAINERNO;
    private string _GOODS_SEA_CON_SIZE;
    private string _GOODS_SEA_CON_TYPE;
    private string _GOODS_SEA_CON_EXCISE_SEALNO;
    private string _GOODS_SEA_CON_SEAL_DATE;

    private string _GOODS_SEA_CON_SEALTYPE_INDICATOR;
	private string _GOODS_SEA_CON_SEAL_DEVICEID;
	private string _GOODS_SEA_CON_DOC_TYPE;
    private string _GOODS_SEA_CON_DOC_NUMBER;

    private string _GOODS_SEA_CON_EQMT_TYPE;
    private string _GOODS_SEA_CON_EQMT_QTY;
    private string _GOODS_SEA_CON_EQMT_QTY_CODE;
   
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

    #endregion

    # region Public Attributes

    public string GOODS_SEA_CON_ID { get { return _GOODS_SEA_CON_ID; } set { _GOODS_SEA_CON_ID = value; } }
    public string GOODS_SEA_CON_JOBNO { get { return _GOODS_SEA_CON_JOBNO; } set { _GOODS_SEA_CON_JOBNO = value; } }
    public string GOODS_SEA_CON_CONTAINERNO { get { return _GOODS_SEA_CON_CONTAINERNO; } set { _GOODS_SEA_CON_CONTAINERNO = value; } }
    public string GOODS_SEA_CON_SIZE { get { return _GOODS_SEA_CON_SIZE; } set { _GOODS_SEA_CON_SIZE = value; } }
    public string GOODS_SEA_CON_TYPE { get { return _GOODS_SEA_CON_TYPE; } set { _GOODS_SEA_CON_TYPE = value; } }
    public string GOODS_SEA_CON_EXCISE_SEALNO { get { return _GOODS_SEA_CON_EXCISE_SEALNO; } set { _GOODS_SEA_CON_EXCISE_SEALNO = value; } }
    public string GOODS_SEA_CON_SEAL_DATE { get { return _GOODS_SEA_CON_SEAL_DATE; } set { _GOODS_SEA_CON_SEAL_DATE = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }

    public string GOODS_SEA_CON_SEALTYPE_INDICATOR { get { return _GOODS_SEA_CON_SEALTYPE_INDICATOR; } set { _GOODS_SEA_CON_SEALTYPE_INDICATOR = value; } }
    public string GOODS_SEA_CON_SEAL_DEVICEID { get { return _GOODS_SEA_CON_SEAL_DEVICEID; } set { _GOODS_SEA_CON_SEAL_DEVICEID = value; } }
    public string GOODS_SEA_CON_DOC_TYPE { get { return _GOODS_SEA_CON_DOC_TYPE; } set { _GOODS_SEA_CON_DOC_TYPE = value; } }
    public string GOODS_SEA_CON_DOC_NUMBER { get { return _GOODS_SEA_CON_DOC_NUMBER; } set { _GOODS_SEA_CON_DOC_NUMBER = value; } }

    public string GOODS_SEA_CON_EQMT_TYPE { get { return _GOODS_SEA_CON_EQMT_TYPE; } set { _GOODS_SEA_CON_EQMT_TYPE = value; } }
    public string GOODS_SEA_CON_EQMT_QTY { get { return _GOODS_SEA_CON_EQMT_QTY; } set { _GOODS_SEA_CON_EQMT_QTY = value; } }
    public string GOODS_SEA_CON_EQMT_QTY_CODE { get { return _GOODS_SEA_CON_EQMT_QTY_CODE; } set { _GOODS_SEA_CON_EQMT_QTY_CODE = value; } }

    
    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    #endregion

    public DataSet Goods_Reg_Sea_Container_details_insertupdate()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@GOODS_SEA_CON_ID", GOODS_SEA_CON_ID);
            param[1] = new SqlParameter("@GOODS_SEA_CON_JOBNO", GOODS_SEA_CON_JOBNO);
            param[2] = new SqlParameter("@GOODS_SEA_CON_CONTAINERNO", GOODS_SEA_CON_CONTAINERNO);
            param[3] = new SqlParameter("@GOODS_SEA_CON_SIZE", GOODS_SEA_CON_SIZE);
            param[4] = new SqlParameter("@GOODS_SEA_CON_TYPE", GOODS_SEA_CON_TYPE);
            param[5] = new SqlParameter("@GOODS_SEA_CON_EXCISE_SEALNO", GOODS_SEA_CON_EXCISE_SEALNO);
            param[6] = new SqlParameter("@GOODS_SEA_CON_SEAL_DATE", DateTime.Parse(GOODS_SEA_CON_SEAL_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[7] = new SqlParameter("@USER_ID", USER_ID);
            param[8] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[9] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[15] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[16] = new SqlParameter("@GOODS_SEA_CON_SEALTYPE_INDICATOR", GOODS_SEA_CON_SEALTYPE_INDICATOR);
            param[17] = new SqlParameter("@GOODS_SEA_CON_SEAL_DEVICEID", GOODS_SEA_CON_SEAL_DEVICEID);
            param[18] = new SqlParameter("@GOODS_SEA_CON_DOC_TYPE", GOODS_SEA_CON_DOC_TYPE);
            param[19] = new SqlParameter("@GOODS_SEA_CON_DOC_NUMBER", GOODS_SEA_CON_DOC_NUMBER);


            param[20] = new SqlParameter("@GOODS_SEA_CON_EQMT_TYPE", GOODS_SEA_CON_EQMT_TYPE);
            param[21] = new SqlParameter("@GOODS_SEA_CON_EQMT_QTY", GOODS_SEA_CON_EQMT_QTY);
            param[22] = new SqlParameter("@GOODS_SEA_CON_EQMT_QTY_CODE", GOODS_SEA_CON_EQMT_QTY_CODE);

            param[10] = new SqlParameter("@YEAR", YEAR);
            param[11] = new SqlParameter("@Mflag", flag);
            param[12] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;
            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_SEA_CONTAINER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[12].Value.ToString());
            string err = param[13].Value.ToString();
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[14].Value.ToString());

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

    public DataSet RetrieveAll_Annexure_C_Sea_Container_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@GOODS_SEA_CON_ID", GOODS_SEA_CON_ID);
            param[1] = new SqlParameter("@GOODS_SEA_CON_JOBNO", GOODS_SEA_CON_JOBNO);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_SEA_CONTAINER_DETAILS", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select")
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_SEA_CONTAINER_DETAILS", param);
                string err = param[5].Value.ToString();
                //result = Convert.ToInt32(param[11].Value.ToString());

                //string err = param[8].Value.ToString();
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