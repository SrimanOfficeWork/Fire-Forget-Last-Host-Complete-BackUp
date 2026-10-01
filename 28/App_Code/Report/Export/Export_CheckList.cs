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
using System.IO;


using Microsoft.ApplicationBlocks.Data;


using System.Drawing;

/// <summary>
/// Summary description for CheckList
/// </summary>
public class Export_CheckList
{
    #region public string

    public DataSet ds = new DataSet();

    public int result, Is_STR, Is_Annexure;
    private bool result1;
    private string _JOBNO;
    private string _Ename;
    private string _Workingperiod;
    private string _TRANSPORT_MODE, _CUSTOM_HOUSE;

    
    public string JOBNo
    {
        get { return _JOBNO; }
        set { _JOBNO = value; }
    }
    public string Ename
    {
        get { return _Ename; }
        set { _Ename = value; }
    }
    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }
    public string TRANSPORT_MODE
    {
        get { return _TRANSPORT_MODE; }
        set { _TRANSPORT_MODE = value; }
    }
    public string CUSTOM_HOUSE
    {
        get { return _CUSTOM_HOUSE; }
        set { _CUSTOM_HOUSE = value; }
    }
    //System.Data.DataTable dtuser = new System.Data.DataTable();
    #endregion

    public DataSet RetrieveAll_General_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);


            param[1] = new SqlParameter("@name", Ename);

            param[2] = new SqlParameter("@Working_Period", Workingperiod);


            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@STR_Status", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;


            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[7] = new SqlParameter("@CUSTOM_HOUSE", CUSTOM_HOUSE);

            param[8] = new SqlParameter("@Annexure_Status", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;


            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_CHECKLIST_SEARCH", param);
            result = Convert.ToInt32(param[3].Value.ToString());

            if (Ename == "Checklist")
            {
                Is_STR = Convert.ToInt32(param[4].Value.ToString());
                Is_Annexure = Convert.ToInt32(param[8].Value.ToString());
            }
            string err = param[5].Value.ToString();


        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_General_Details(string Connstr)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Working_Period", Workingperiod);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@STR_Status", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;


            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[7] = new SqlParameter("@CUSTOM_HOUSE", CUSTOM_HOUSE);

            param[8] = new SqlParameter("@Annexure_Status", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;



            ds = SqlHelper.ExecuteDataset(Connstr, CommandType.StoredProcedure, "SP_EXPORT_CHECKLIST_SEARCH", param);
            result = Convert.ToInt32(param[3].Value.ToString());
            if (Ename == "Checklist")
            {
                Is_STR = Convert.ToInt32(param[4].Value.ToString());
                Is_Annexure = Convert.ToInt32(param[8].Value.ToString());
            }
            string err = param[5].Value.ToString();


        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }


    public DataSet RetrieveAll_General_DetailsNew()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);


            param[1] = new SqlParameter("@name", Ename);

            param[2] = new SqlParameter("@Working_Period", Workingperiod);


            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@STR_Status", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;


            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[7] = new SqlParameter("@CUSTOM_HOUSE", CUSTOM_HOUSE);




            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_CHECKLIST_SEARCH_HTMLVIEW", param);
            result = Convert.ToInt32(param[3].Value.ToString());

            if (Ename == "Checklist")
            {
                Is_STR = Convert.ToInt32(param[4].Value.ToString());
            }
            string err = param[5].Value.ToString();


        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_General_DetailsNew(string Connstr)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Working_Period", Workingperiod);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@STR_Status", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;


            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[7] = new SqlParameter("@CUSTOM_HOUSE", CUSTOM_HOUSE);




            ds = SqlHelper.ExecuteDataset(Connstr, CommandType.StoredProcedure, "SP_EXPORT_CHECKLIST_SEARCH_HTMLVIEW", param);
            result = Convert.ToInt32(param[3].Value.ToString());
            Is_STR = Convert.ToInt32(param[4].Value.ToString());
            string err = param[5].Value.ToString();


        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }


    public DataSet RetrieveAll_Import_Annexure_Report()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);


            param[1] = new SqlParameter("@name", Ename);

            param[2] = new SqlParameter("@Working_Period", Workingperiod);


            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@STR_Status", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;


            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[7] = new SqlParameter("@CUSTOM_HOUSE", CUSTOM_HOUSE);

            param[8] = new SqlParameter("@Annexure_Status", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_ANNEXURE_REPORT_SEARCH", param);
            result = Convert.ToInt32(param[3].Value.ToString());

            if (Ename == "Checklist")
            {
                Is_STR = Convert.ToInt32(param[4].Value.ToString());
                Is_Annexure = Convert.ToInt32(param[8].Value.ToString());
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

    public DataSet RetrieveAll_Export_XML_Details()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[1] = new SqlParameter("@Jobno", JOBNo);
            param[2] = new SqlParameter("@BRANCH_COMMON", Workingperiod);
            param[3] = new SqlParameter("@Company_Lic", Connection.COMPANYID());
            param[4] = new SqlParameter("@Flag", Ename);

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_CHECKLIST_XMLVIEW", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Get_Exp_Tally_Data_GropA()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[1] = new SqlParameter("@Ename", Ename);
            param[2] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            ds = Connection.Get_Dataset("EXPORT_TALLY_DATA_GROUP_A", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}