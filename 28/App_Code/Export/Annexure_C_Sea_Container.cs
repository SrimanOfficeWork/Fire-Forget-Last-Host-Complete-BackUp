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
/// Summary description for Annexure_C_Sea_Container
/// </summary>
public class Annexure_C_Sea_Container
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

    private string _ANNEX_SEA_CON_ID;
    private string _ANNEX_SEA_CON_JOBNO;
    private string _ANNEX_SEA_CON_CONTAINERNO;
    private string _ANNEX_SEA_CON_SIZE;
    private string _ANNEX_SEA_CON_TYPE;
    private string _ANNEX_SEA_CON_EXCISE_SEALNO;
    private string _ANNEX_SEA_CON_SEAL_DATE;

    private string _ANNEX_SEA_CON_SEALTYPE_INDICATOR;
    private string _ANNEX_SEA_CON_SEAL_DEVICEID;
    private string _ANNEX_SEA_CON_DOC_TYPE;
    private string _ANNEX_SEA_CON_DOC_NUMBER;
    private string _JOBNO_PS;


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
    private string _xmlData;

    #endregion

    # region Public Attributes

    public string ANNEX_SEA_CON_ID { get { return _ANNEX_SEA_CON_ID; } set { _ANNEX_SEA_CON_ID = value; } }
    public string ANNEX_SEA_CON_JOBNO { get { return _ANNEX_SEA_CON_JOBNO; } set { _ANNEX_SEA_CON_JOBNO = value; } }
    public string ANNEX_SEA_CON_CONTAINERNO { get { return _ANNEX_SEA_CON_CONTAINERNO; } set { _ANNEX_SEA_CON_CONTAINERNO = value; } }
    public string ANNEX_SEA_CON_SIZE { get { return _ANNEX_SEA_CON_SIZE; } set { _ANNEX_SEA_CON_SIZE = value; } }
    public string ANNEX_SEA_CON_TYPE { get { return _ANNEX_SEA_CON_TYPE; } set { _ANNEX_SEA_CON_TYPE = value; } }
    public string ANNEX_SEA_CON_EXCISE_SEALNO { get { return _ANNEX_SEA_CON_EXCISE_SEALNO; } set { _ANNEX_SEA_CON_EXCISE_SEALNO = value; } }
    public string ANNEX_SEA_CON_SEAL_DATE { get { return _ANNEX_SEA_CON_SEAL_DATE; } set { _ANNEX_SEA_CON_SEAL_DATE = value; } }
        
    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }


    public string ANNEX_SEA_CON_SEALTYPE_INDICATOR { get { return _ANNEX_SEA_CON_SEALTYPE_INDICATOR; } set { _ANNEX_SEA_CON_SEALTYPE_INDICATOR = value; } }
    public string ANNEX_SEA_CON_SEAL_DEVICEID { get { return _ANNEX_SEA_CON_SEAL_DEVICEID; } set { _ANNEX_SEA_CON_SEAL_DEVICEID = value; } }
    public string ANNEX_SEA_CON_DOC_TYPE { get { return _ANNEX_SEA_CON_DOC_TYPE; } set { _ANNEX_SEA_CON_DOC_TYPE = value; } }
    public string ANNEX_SEA_CON_DOC_NUMBER { get { return _ANNEX_SEA_CON_DOC_NUMBER; } set { _ANNEX_SEA_CON_DOC_NUMBER = value; } }

    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public string JOBNO_PS { get { return _JOBNO_PS; } set { _JOBNO_PS = value; } }
    public string xmlData { get { return _xmlData; } set { _xmlData = value; } } 
    #endregion

    public DataSet Annexure_C_Sea_Con_details_insertupdate()
    {
        try
        {

            
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@ANNEX_SEA_CON_ID", ANNEX_SEA_CON_ID);
            param[1] = new SqlParameter("@ANNEX_SEA_CON_JOBNO", ANNEX_SEA_CON_JOBNO);
            param[2] = new SqlParameter("@ANNEX_SEA_CON_CONTAINERNO", ANNEX_SEA_CON_CONTAINERNO);
            param[3] = new SqlParameter("@ANNEX_SEA_CON_SIZE", ANNEX_SEA_CON_SIZE);
            param[4] = new SqlParameter("@ANNEX_SEA_CON_TYPE", ANNEX_SEA_CON_TYPE);
            param[5] = new SqlParameter("@ANNEX_SEA_CON_EXCISE_SEALNO", ANNEX_SEA_CON_EXCISE_SEALNO);
            param[6] = new SqlParameter("@ANNEX_SEA_CON_SEAL_DATE", DateTime.Parse(ANNEX_SEA_CON_SEAL_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[24] = new SqlParameter("@ANNEX_SEA_CON_SEALTYPE_INDICATOR", ANNEX_SEA_CON_SEALTYPE_INDICATOR);
            param[25] = new SqlParameter("@ANNEX_SEA_CON_SEAL_DEVICEID", ANNEX_SEA_CON_SEAL_DEVICEID);
            param[26] = new SqlParameter("@ANNEX_SEA_CON_DOC_TYPE", ANNEX_SEA_CON_DOC_TYPE);
            param[27] = new SqlParameter("@ANNEX_SEA_CON_DOC_NUMBER", ANNEX_SEA_CON_DOC_NUMBER);
            param[28] = new SqlParameter("@JOBNO_PS", JOBNO_PS);
         
            param[15] = new SqlParameter("@USER_ID", USER_ID);
            param[16] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[17] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[23] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[18] = new SqlParameter("@YEAR", YEAR);
            param[19] = new SqlParameter("@Mflag", flag);
            param[20] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;
            param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[21].Direction = ParameterDirection.Output;
            param[22] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[22].Direction = ParameterDirection.Output;
            ds=SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ANNEXURE_C_SEA_CONTAINER_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[20].Value.ToString());
            string err = param[21].Value.ToString();
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[22].Value.ToString());
            
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

            param[0] = new SqlParameter("@ANNEX_SEA_CON_ID", ANNEX_SEA_CON_ID);

            param[1] = new SqlParameter("@ANNEX_SEA_CON_JOBNO", ANNEX_SEA_CON_JOBNO);

            param[2] = new SqlParameter("@name", Ename);

            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;


            if (Ename == "delete" || Ename=="Delete_All_Containers")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds=SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ANNEXURE_C_SEA_CONTAINER_DETAILS", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select" || Ename == "Select_MAX_Container_ID")
            {

                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ANNEXURE_C_SEA_CONTAINER_DETAILS", param);
                string err = param[5].Value.ToString();
                
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

    public DataSet SqlBulk_Upload_Product()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@xmlString_A", xmlData);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Sp_bulk_Upload_EXPORT_ANNEXURE_C_SEA_CONTAINER", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}