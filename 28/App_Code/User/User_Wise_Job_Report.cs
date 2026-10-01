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

public class User_Wise_Job_Report
{
    private string _IMP_EXP;
    private string _Branch;
    private string _Flag;

    private string _Username;
    private string _From_date;
    private string _To_date;
    private string _Job_Sort;

    public string IMP_EXP { get { return _IMP_EXP; } set { _IMP_EXP = value; } }
    public string Branch { get { return _Branch; } set { _Branch = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }

    public string Username { get { return _Username; } set { _Username = value; } }
    public string From_date { get { return _From_date; } set { _From_date = value; } }
    public string To_date { get { return _To_date; } set { _To_date = value; } }
    public string Job_Sort { get { return _Job_Sort; } set { _Job_Sort = value; } }
    
    
    public int result = 0, UPDATE_ID = 0;
    DataSet ds = new DataSet();

    public DataSet Select_User()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Type", IMP_EXP);
            param[1] = new SqlParameter("@Branch", Branch);
            param[2] = new SqlParameter("@Flag", Flag);

            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_EXPORT_USERWISE_JOB_REPORT_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet Select_Master_Search()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            if (From_date != string.Empty && From_date != null)
            {
                arr = From_date.Split('/');
                From_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (To_date != string.Empty && To_date != null)
            {
                arr2 = To_date.Split('/');
                To_date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }


            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Type", IMP_EXP);
            param[1] = new SqlParameter("@Branch", Branch);
            param[2] = new SqlParameter("@Username",Username);
            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@From_date", From_date);
            param[5] = new SqlParameter("@To_date", To_date);
            param[6] = new SqlParameter("@Job_Sort", Job_Sort);
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

           //-- this SP Hide for Capricorn Multiple Branch & Username select with Areawise Concept
           // ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_EXP_USERWISE_REPORT_MASTER_SEARCH", param);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_EXP_USERWISE_REPORT_MASTER_SEARCH_NEW", param);

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
}