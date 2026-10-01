

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public class Sales_Stmts
{
    ErrorLogs er = new ErrorLogs();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    private string _COMPANY_LICENSE;
    private string _JOBTYPE;
    private string _FROMDATE;
    private string _TODATE;
    private string _BRANCH;
    private string _USER_ID;
    private string _Working_Period;
    private string _Ename;
    private string _flag;
    private string _Select_Item;

    public string COMPANY_LICENSE { get { return _COMPANY_LICENSE; } set { _COMPANY_LICENSE = value; } }
    public string JOBTYPE { get { return _JOBTYPE; } set { _JOBTYPE = value; } }
    public string FROMDATE { get { return _FROMDATE; } set { _FROMDATE = value; } }
    public string TODATE { get { return _TODATE; } set { _TODATE = value; } }
    public string BRANCH { get { return _BRANCH; } set { _BRANCH = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string Working_Period { get { return _Working_Period; } set { _Working_Period = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string Select_Item { get { return _Select_Item; } set { _Select_Item = value; } }
    public int result = 0;
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------

    private string _Job_Type;
    private string _Search_Cat;
    private string _Branch;
    private string _File_status;
    private string _from_date;
    private string _to_date;
    private string _DB_Name;
    private string _QStart;
    private string _QEnd;
    private string _Month;

    private string _Start_month;
    private string _End_month;
    private string _Working_period;
    
    public string Job_Type { get { return _Job_Type; } set { _Job_Type = value; } }
    public string Search_Cat { get { return _Search_Cat; } set { _Search_Cat = value; } }
    public string Branch { get { return _Branch; } set { _Branch = value; } }
    public string File_status { get { return _File_status; } set { _File_status = value; } }
    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string to_date { get { return _to_date; } set { _to_date = value; } }
    public string DB_Name { get { return _DB_Name; } set { _DB_Name = value; } }
    public string QStart { get { return _QStart; } set { _QStart = value; } }
    public string QEnd { get { return _QEnd; } set { _QEnd = value; } }
    public string Month { get { return _Month; } set { _Month = value; } }
    public string Start_month { get { return _Start_month; } set { _Start_month = value; } }
    public string End_month { get { return _End_month; } set { _End_month = value; } }
    public string Working_period { get { return _Working_period; } set { _Working_period = value; } }

//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public DataTable RetrieveAll_Job_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);
            param[1] = new SqlParameter("@JOBTYPE", JOBTYPE);
            if (!string.IsNullOrEmpty(FROMDATE))
            param[2] = new SqlParameter("@FROMDATE", DateTime.Parse(Convert.ToString(FROMDATE), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            else
            {
                param[2] = new SqlParameter("@FROMDATE", FROMDATE);
            }
            if (!string.IsNullOrEmpty(TODATE))
            param[3] = new SqlParameter("@TODATE", DateTime.Parse(Convert.ToString(TODATE), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            else
            {
                param[3] = new SqlParameter("@TODATE", TODATE);
            }
            param[4] = new SqlParameter("@BRANCH",BRANCH);
            param[5] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@Working_Period", Working_Period);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;


            if (Ename == "Sales_Statement_Import")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["server"].ToString(), CommandType.StoredProcedure, "SALES_STATEMENT_SEARCH_SELECT_NEW", param);
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
            else
            {
                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SALES_STATEMENT_SEARCH_SELECT_NEW", param);
                string err = param[8].Value.ToString();
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
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds.Tables[0];
    }


    public DataSet Sales_Report_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Flag", flag);
            param[1] = new SqlParameter("@Select_Item", Select_Item);
            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SALES_REPORT_SEARCH", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet All_DB_Backup_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Flag", flag);
            param[1] = new SqlParameter("@Select_Item", Select_Item);

            param[3] = new SqlParameter("@Working_Period", Working_Period);

            param[2] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[2].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ALL_DB_BACKUP_SEARCH", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet Sales_Report_Master_Search()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            if (from_date != string.Empty && from_date != null)
            {
                arr = from_date.Split('/');
                from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (to_date != string.Empty && to_date != null)
            {
                arr2 = to_date.Split('/');
                to_date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }


            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Job_Type", Job_Type);
            param[1] = new SqlParameter("@Search_Cat", Search_Cat);
            param[2] = new SqlParameter("@Branch", Branch);
            param[3] = new SqlParameter("@File_status", File_status);
            param[4] = new SqlParameter("@from_date", from_date);

            param[5] = new SqlParameter("@to_date", to_date);
            param[6] = new SqlParameter("@DB_Name", DB_Name);
            param[7] = new SqlParameter("@QStart", QStart);
            param[8] = new SqlParameter("@QEnd", QEnd);
            param[9] = new SqlParameter("@Month", Month);
            param[10] = new SqlParameter("@Start_month", Start_month);
            param[11] = new SqlParameter("@End_month", End_month);
            param[12] = new SqlParameter("@Working_period", Working_period);

            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;

           // ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["Client_Server"], CommandType.StoredProcedure, "SALES_REPORT_MASTER_SEARCH", param);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["Client_Server"].ToString(), CommandType.StoredProcedure, "SALES_REPORT_MASTER_SEARCH", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

}