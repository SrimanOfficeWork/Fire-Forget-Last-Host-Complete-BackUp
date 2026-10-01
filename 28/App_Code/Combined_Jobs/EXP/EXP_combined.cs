using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

public class EXP_combined
{

    public int result = 0, UPDATE_ID = 0;
    public int is_Annexure_Mode = 0, is_STR_Code = 0;
    DataSet ds = new DataSet();
    public int Is_STR;

     private string _ID;
     private string _EXPORTER_NAME;
     private string _JOBNO;
     private string _COMBINED_JOBS;
     private string _USER_ID;
     private string _BRANCH_CODE;

     public string ID { get { return _ID; } set { _ID = value; } }
     public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
     public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
     public string COMBINED_JOBS { get { return _COMBINED_JOBS; } set { _COMBINED_JOBS = value; } }
     public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
     public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }


    private string _Item_Id;
    private string _Exp_name;
    private string _Branch;
    private string _Flag;
    private string _Mode;

    private string _R_Id;
    private string _Jobno;

    private string _from_date;
    private string _todate;

    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string todate { get { return _todate; } set { _todate = value; } }

    public string Item_Id { get { return _Item_Id; } set { _Item_Id = value; } }
    public string Exp_name { get { return _Exp_name; } set { _Exp_name = value; } }
    public string Branch { get { return _Branch; } set { _Branch = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string Mode { get { return _Mode; } set { _Mode = value; } }

    public string R_Id { get { return _R_Id; } set { _R_Id = value; } }
    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }

    public DataSet Exp_Name()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@Item_Id", Item_Id);
            param[1] = new SqlParameter("@Exp_name", Exp_name);
            param[2] = new SqlParameter("@Branch", Branch);
            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@Mode", Mode);
            param[5] = new SqlParameter("@Jobno", Jobno);

            
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_JOB_COMBINED_SELECT", param);
            result = Convert.ToInt32(param[5].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet New_item_load()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@R_Id", R_Id);
            param[1] = new SqlParameter("@Jobno", Jobno);
            param[2] = new SqlParameter("@Exp_name", Exp_name);
            param[3] = new SqlParameter("@Branch", Branch);
            param[4] = new SqlParameter("@Flag", Flag);
            param[5] = new SqlParameter("@Mode", Mode);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@STR_Status", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_JOB_COMBINE_SELECT", param);
            result = Convert.ToInt32(param[6].Value.ToString());
            Is_STR = Convert.ToInt32(param[7].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public void EXPORT_COMBINE_JOB_INS_UPD()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[100];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
            param[2] = new SqlParameter("@JOBNO", JOBNO);
            param[3] = new SqlParameter("@Mode", Mode);

            param[4] = new SqlParameter("@COMBINED_JOBS", COMBINED_JOBS);
            param[5] = new SqlParameter("@USER_ID", USER_ID);
            param[6] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[7] = new SqlParameter("@Branch", Branch);
            param[8] = new SqlParameter("@flag", Flag);

            param[9] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_COMBINE_JOB_INS_UPD", param);
            result = Convert.ToInt32(param[9].Value.ToString());

            if (Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[11].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public DataSet EXPORT_COMBINE_JOB_SEARCH()
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
            if (todate != string.Empty && todate != null)
            {
                arr2 = todate.Split('/');
                todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Exporter_name", Exp_name);
            param[2] = new SqlParameter("@jobno", JOBNO);
            param[3] = new SqlParameter("@from_date", from_date);
            param[4] = new SqlParameter("@to_date", todate);
            param[6] = new SqlParameter("@Branch", Branch);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_COMBINED_CHECKLIST_SEARCH", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }


    
}