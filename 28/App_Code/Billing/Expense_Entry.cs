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
/// Summary description for Expense_Entry
/// </summary>
public class Expense_Entry
{

    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    SqlCommand cmd;
    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    public int UPDATE_ID = 0;

    #region public string    

    public int result;
    private bool result1;
    private string _JOBNO;
    private string _Ename;
    private string _Workingperiod;
    private string _TRANSPORT_MODE, _CUSTOM_HOUSE;
    private string _TYPE;
    private string _COMPANY_ID;


    #region Insert,update Private Attributes

    private string _EXPENSE_ID;

    private string _BRANCH;
    private string _EXP_NO;
    private string _EXP_DATE;

    private string _EXP_NAME;
    private string _CASH_MODE;
    private string _CASH_AMT;
    private string _RECEIVABLE_PERSON;
    private string _AMT_TRANSFER_TO;
    private string _FILES;
    private string _REMARKS;
    private string _CREATED_BY;
    private string _MODIFIED_BY;

    private string _CREATED_ON;
    private string _MODIFIED_ON;
    //private string _STATUS;
    private string _BRANCH_CODE;
    private string _flag;    
    private string _YEAR;
    private string _WORKING_PERIOD;
   

    #endregion


    #region Insert,update Public Attributes


    public string EXPENSE_ID { get { return _EXPENSE_ID; } set { _EXPENSE_ID = value; } }

    public string BRANCH { get { return _BRANCH; } set { _BRANCH = value; } }
    public string EXP_NO { get { return _EXP_NO; } set { _EXP_NO = value; } }
    public string EXP_DATE { get { return _EXP_DATE; } set { _EXP_DATE = value; } }
    public string EXP_NAME { get { return _EXP_NAME; } set { _EXP_NAME = value; } }

    public string CASH_MODE { get { return _CASH_MODE; } set { _CASH_MODE = value; } }
    public string CASH_AMT { get { return _CASH_AMT; } set { _CASH_AMT = value; } }
    public string RECEIVABLE_PERSON { get { return _RECEIVABLE_PERSON; } set { _RECEIVABLE_PERSON = value; } }
    public string AMT_TRANSFER_TO { get { return _AMT_TRANSFER_TO; } set { _AMT_TRANSFER_TO = value; } }
    public string FILES { get { return _FILES; } set { _FILES = value; } }

    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }
    public string CREATED_BY { get { return _CREATED_BY; } set { _CREATED_BY = value; } }
    public string MODIFIED_BY { get { return _MODIFIED_BY; } set { _MODIFIED_BY = value; } }   
    public string CREATED_ON { get { return _CREATED_ON; } set { _CREATED_ON = value; } }
    public string MODIFIED_ON { get { return _MODIFIED_ON; } set { _MODIFIED_ON = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }

    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
       

    #endregion


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
    public string TYPE
    {
        get { return _TYPE; }
        set { _TYPE = value; }
    }

    public string COMPANY_ID
    {
        get { return _COMPANY_ID; }
        set { _COMPANY_ID = value; }
    }

    #endregion

    public DataSet RetrieveAll_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);


            param[1] = new SqlParameter("@name", Ename);

            param[6] = new SqlParameter("@TYPE", TYPE);

            param[7] = new SqlParameter("@COMPANY_ID", COMPANY_ID);

            param[2] = new SqlParameter("@Working_Period", Workingperiod);


            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;


            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;



            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BL_EXPENSE_JOB_SEARCH", param);

            result = Convert.ToInt32(param[3].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet Expense_Entry_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@JOBNO", JOBNo);

            param[1] = new SqlParameter("@EXPENSE_ID", EXPENSE_ID);

            param[2] = new SqlParameter("@TYPE", TYPE);

            param[12] = new SqlParameter("@BRANCH", BRANCH);

            param[3] = new SqlParameter("@EXP_NO", EXP_NO);

            param[4] = new SqlParameter("@EXP_DATE", DateTime.Parse(EXP_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[5] = new SqlParameter("@EXP_NAME", EXP_NAME);

            param[6] = new SqlParameter("@CASH_MODE", CASH_MODE);

            param[7] = new SqlParameter("@CASH_AMT", CASH_AMT);

            param[8] = new SqlParameter("@RECEIVABLE_PERSON", RECEIVABLE_PERSON);


            param[9] = new SqlParameter("@AMT_TRANSFER_TO", AMT_TRANSFER_TO);

            param[10] = new SqlParameter("@FILES", FILES);

            param[11] = new SqlParameter("@REMARKS", REMARKS);
                       

            param[13] = new SqlParameter("@CREATED_BY", CREATED_BY);
            param[14] = new SqlParameter("@MODIFIED_BY", MODIFIED_BY);
            param[15] = new SqlParameter("@CREATED_ON", CREATED_ON);
            param[16] = new SqlParameter("@MODIFIED_ON", MODIFIED_ON);

            param[17] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[18] = new SqlParameter("@YEAR", YEAR);
            param[19] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[20] = new SqlParameter("@Mflag", flag);

           // param[13] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

           
            param[21] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[21].Direction = ParameterDirection.Output;
            param[22] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[22].Direction = ParameterDirection.Output;
            param[23] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[23].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BL_EXPENSE_ENTRY_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[21].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[23].Value.ToString());
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

    public DataSet RetrieveAll_Expense_Entry_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[1] = new SqlParameter("@TYPE", TYPE);

            param[6] = new SqlParameter("@BRANCH", BRANCH);
            param[7] = new SqlParameter("@EXPENSE_ID", EXPENSE_ID);

            param[8] = new SqlParameter("@EXP_NO", EXP_NO);

            param[9] = new SqlParameter("@FILE_NAME", FILES);
      
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            //param[6] = new SqlParameter("@Mflag", flag);

            if (Ename == "select_con" || Ename == "Bind_file_Names" || Ename == "Delete_File_Only")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BL_EXPENSE_SELECT", param);
                string err = param[5].Value.ToString();
                result = Convert.ToInt32(param[4].Value.ToString());

            }
            else if (Ename == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BL_EXPENSE_SELECT", param);
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
}