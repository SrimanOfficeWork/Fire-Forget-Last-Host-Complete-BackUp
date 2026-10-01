using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;


public class Export_Unified_Job
{
    DataSet ds = new DataSet();
    public int result;
    public long New_JOBID;

    private string _CURRENT_JOBNO, _BRANCH_CODE, _WORKING_PERIOD, _USER_ID, _DBS_Name,
                   _Company_License, _Current_Branch, _JOB_PREFIX, _JOB_SUFFIX, _Current_Working_Period, _Ename;

    private bool _Inc_General, _Inc_AnnexureC, _Inc_Invoices, _Inc_Items, _Inc_AnnexureC1, _Inc_License, _Inc_SupDoc;

    private DataTable _JobNoList; // columns: JOBNO (string), SeqNo (int) - order = selection order, SeqNo 1 = first job

    public string CURRENT_JOBNO { get { return _CURRENT_JOBNO; } set { _CURRENT_JOBNO = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string DBS_Name { get { return _DBS_Name; } set { _DBS_Name = value; } }
    public string Company_License { get { return _Company_License; } set { _Company_License = value; } }
    public string Current_Branch { get { return _Current_Branch; } set { _Current_Branch = value; } }
    public string JOB_PREFIX { get { return _JOB_PREFIX; } set { _JOB_PREFIX = value; } }
    public string JOB_SUFFIX { get { return _JOB_SUFFIX; } set { _JOB_SUFFIX = value; } }
    public string Current_Working_Period { get { return _Current_Working_Period; } set { _Current_Working_Period = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public bool Inc_General { get { return _Inc_General; } set { _Inc_General = value; } }
    public bool Inc_AnnexureC { get { return _Inc_AnnexureC; } set { _Inc_AnnexureC = value; } }
    public bool Inc_Invoices { get { return _Inc_Invoices; } set { _Inc_Invoices = value; } }
    public bool Inc_Items { get { return _Inc_Items; } set { _Inc_Items = value; } }
    public bool Inc_AnnexureC1 { get { return _Inc_AnnexureC1; } set { _Inc_AnnexureC1 = value; } }
    public bool Inc_License { get { return _Inc_License; } set { _Inc_License = value; } }
    public bool Inc_SupDoc { get { return _Inc_SupDoc; } set { _Inc_SupDoc = value; } }

    public DataTable JobNoList { get { return _JobNoList; } set { _JobNoList = value; } }

 
    public static DataTable BuildJobNoListTable(List<string> jobNosInSelectionOrder)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("JOBNO", typeof(string));
        dt.Columns.Add("SeqNo", typeof(int));

        int seq = 1;
        foreach (string jobno in jobNosInSelectionOrder)
        {
            if (string.IsNullOrEmpty(jobno)) continue;
            DataRow r = dt.NewRow();
            r["JOBNO"] = jobno;
            r["SeqNo"] = seq++;
            dt.Rows.Add(r);
        }
        return dt;
    }

   
    public int Generate_Unified_Job()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@JobNoList", SqlDbType.Structured);
            param[0].TypeName = "dbo.udt_JobNoList";
            param[0].Value = JobNoList;

            param[1] = new SqlParameter("@CURRENT_JOBNO", CURRENT_JOBNO);
            param[2] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
            param[3] = new SqlParameter("@Working_Period", BRANCH_CODE);
            param[4] = new SqlParameter("@USERID", USER_ID);
            param[5] = new SqlParameter("@DB_Name", DBS_Name);
            param[6] = new SqlParameter("@Company_license", Company_License);
            param[7] = new SqlParameter("@Current_Branch", Current_Branch);
            param[8] = new SqlParameter("@Job_Prefix", JOB_PREFIX);
            param[9] = new SqlParameter("@Job_Suffix", JOB_SUFFIX);
            param[10] = new SqlParameter("@Current_Working_Period", Current_Working_Period);

            param[11] = new SqlParameter("@Inc_General", Inc_General);
            param[12] = new SqlParameter("@Inc_AnnexureC", Inc_AnnexureC);
            param[13] = new SqlParameter("@Inc_Invoices", Inc_Invoices);
            param[14] = new SqlParameter("@Inc_Items", Inc_Items);
            param[15] = new SqlParameter("@Inc_AnnexureC1", Inc_AnnexureC1);
            param[16] = new SqlParameter("@Inc_License", Inc_License);
            param[17] = new SqlParameter("@Inc_SupDoc", Inc_SupDoc);

            param[18] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;

            param[20] = new SqlParameter("@New_JOBID", SqlDbType.BigInt);
            param[20].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("SP_GENERATE_UNIFIED_EXPORT_JOB", param);

            result = Convert.ToInt32(param[18].Value.ToString());

            if (param[20].Value != null && param[20].Value != DBNull.Value)
                New_JOBID = Convert.ToInt64(param[20].Value);

           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

   
    public DataSet RetrieveAll_UnifiedJob_Preview()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@JobNoList", SqlDbType.Structured);
            param[0].TypeName = "dbo.udt_JobNoList";
            param[0].Value = JobNoList;

            param[1] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);

            ds = SqlHelper.ExecuteDataset(
                    HttpContext.Current.Session["currentcomp_db"].ToString(),
                    CommandType.StoredProcedure,
                    "SP_UNIFIED_JOB_PREVIEW", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    
    public DataTable RetrieveAll_JobNo_ForSelection(string exporterName, string trMode, string branchCode, string fiscalWorkingPeriod)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@JOBID", "");
            param[1] = new SqlParameter("@JOBNO", "");
            param[2] = new SqlParameter("@EXPORTER_NAME", exporterName);
            param[3] = new SqlParameter("@TRANSPORT_MODE", trMode);
            param[4] = new SqlParameter("@CUSTOMS_HOUSE", "");
            param[5] = new SqlParameter("@name", "select_jobno_list");
            param[6] = new SqlParameter("@Working_Period", branchCode);          
            param[12] = new SqlParameter("@SEARCH_CAT", "");
            param[13] = new SqlParameter("@SEARCH_ITEM", fiscalWorkingPeriod ?? ""); 
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", 0);
            param[10] = new SqlParameter("@maximumRows", 5000);
            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            DataSet dset = Connection.Get_Dataset("SP_EXPORT_GENERAL_DETAILS_SEARCH_SELECT", param);
            if (dset != null && dset.Tables.Count > 0)
                dt = dset.Tables[0];
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("RetrieveAll_JobNo_ForSelection ERROR: " + ex.ToString());
            Connection.Error_Msg(ex.Message);
        }
        return dt;
    }
}