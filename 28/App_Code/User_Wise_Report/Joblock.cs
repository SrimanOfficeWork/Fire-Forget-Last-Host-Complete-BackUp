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
using System.IO;

public class Joblock
{
    DataSet ds = new DataSet();
    public int result = 0;

    public string ErrorMsg;
    private string _Jobtype;
    private string _Select_Branch;
    private string _UserName;
    private string _Needjob;

    private string _Commorn_or_Branchwise;
    private string _Select_or_Update;

    private string _JOBNO;
    private string _CURRENT_USER;


    private string _Invoice_No;

    private string _Released_By;

    private string _Working_Period; 


    public string JOBNO
    {
        get { return _JOBNO; }
        set { _JOBNO = value; }
    }

    public string CURRENT_USER
    {
        get { return _CURRENT_USER; }
        set { _CURRENT_USER = value; }
    }

    public string Jobtype
    {
        get {return _Jobtype;  }
        set {  _Jobtype = value ; }
    }

    public string Select_Branch
    {
        get { return _Select_Branch; }
        set { _Select_Branch = value; }
    }
    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }
    public string Needjob
    {
        get { return _Needjob; }
        set { _Needjob = value; }
    }
    public string Commorn_or_Branchwise
    {
        get { return _Commorn_or_Branchwise; }
        set { _Commorn_or_Branchwise = value; }
    }

    public string Select_or_Update
    {
        get { return _Select_or_Update; }
        set { _Select_or_Update = value; }
    }

    public string Invoice_No
    {
        get { return _Invoice_No; }
        set { _Invoice_No = value; }
    }

    public string Released_By
    {
        get { return _Released_By; }
        set { _Released_By = value; }
    }

    public string Working_Period
    {
        get { return _Working_Period; }
        set { _Working_Period = value; }
    }


    public DataSet Joblock_data()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobtype",Jobtype );
            param[1] = new SqlParameter("@Branch",Select_Branch );
            param[2] = new SqlParameter("@User_id",UserName );

            param[3] = new SqlParameter("@NeedJob",Needjob );
            param[4] = new SqlParameter("@Branch_Type", Commorn_or_Branchwise);
            param[5] = new SqlParameter("@Select_or_Update", Select_or_Update);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Joblock", param);
            result = Convert.ToInt32(param[6].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet Job_Release_data()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobtype", Jobtype);
            param[1] = new SqlParameter("@JOBNO", JOBNO);

            param[6] = new SqlParameter("@CURRENT_USER", CURRENT_USER);

            param[2] = new SqlParameter("@BRANCH_COMMON", Commorn_or_Branchwise);
            param[3] = new SqlParameter("@Select_or_Update", Select_or_Update);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "JOB_RELEASE", param);
            result = Convert.ToInt32(param[4].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }


    public DataSet User_Job_Rel()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobtype", Jobtype);
            param[1] = new SqlParameter("@Branch", Select_Branch);
            param[2] = new SqlParameter("@User_Name", UserName);

            param[3] = new SqlParameter("@Common_or_Branch", Commorn_or_Branchwise);
            param[4] = new SqlParameter("@Select_or_Update", Select_or_Update);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "USER_JOB_RELEASE", param);
            result = Convert.ToInt32(param[5].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public DataSet Invoice_Job_Rel()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Jobtype", Jobtype);
            param[1] = new SqlParameter("@Branch", Select_Branch);
            param[2] = new SqlParameter("@User_Name", UserName);
            param[3] = new SqlParameter("@Common_or_Branch", Commorn_or_Branchwise);
            param[4] = new SqlParameter("@Select_or_Update", Select_or_Update);
            param[5] = new SqlParameter("@Invoice_No", Invoice_No ?? "");
            param[6] = new SqlParameter("@Released_By", Released_By ?? "");
            param[9] = new SqlParameter("@Working_Period", Working_Period);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(
                    HttpContext.Current.Session["currentcomp_db"].ToString(),
                    CommandType.StoredProcedure, "USER_INVOICE_JOB_RELEASE", param);

            result = (param[7].Value == DBNull.Value) ? 0 : Convert.ToInt32(param[7].Value);
            ErrorMsg = (param[8].Value == DBNull.Value) ? "" : param[8].Value.ToString();

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }




}