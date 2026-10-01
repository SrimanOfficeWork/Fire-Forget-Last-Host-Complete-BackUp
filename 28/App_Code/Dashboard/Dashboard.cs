using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

public class Dashboard
{
    DataSet ds = new DataSet();
    private string _Flag;
    public string Flag { get { return _Flag; } set { _Flag = value; } }

    // Set whenever DASHBOARD_JOB_REPORT()/DASHBOARD_JOB_REPORT_MODEWISE() below catches an
    // exception, so callers (the Home page's diagnostic banner) can show the actual SQL/connection
    // error inline instead of only pointing at ErrorLogs' log file - which, on a fresh deployment
    // where <site root>\logs\ doesn't exist yet, was silently failing to write at all (see the
    // Directory.CreateDirectory fix in ErrorLogs.makeLog()), losing the real error with no trace.
    public string LastError { get; private set; }

    public DataSet DASHBOARD_JOB_REPORT()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[1] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[2] = new SqlParameter("@Flag", Flag);
            param[3] = new SqlParameter("@UserCreation_ID", HttpContext.Current.Session["USER_CREATION_ID"].ToString());

            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            //ds = Connection.Get_Dataset("DASHBOARD_JOB_REPORT_SELECT", param);//hide on 17-08-2026
            ds = Connection.Get_Dataset("DASHBOARD_JOB_REPORT_SELECT_USERWISE_IEC_BASED_SEARCH", param);
        }
        catch (Exception ex)
        {
            LastError = ex.Message;
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet DASHBOARD_JOB_REPORT_MODEWISE(string mode = "", string type = "BOTH")
    {
        DataSet dsMode = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[1] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[2] = new SqlParameter("@MODE", mode ?? "");
            param[3] = new SqlParameter("@TYPE", type ?? "BOTH");
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@UserCreation_ID", HttpContext.Current.Session["USER_CREATION_ID"].ToString());

            //dsMode = Connection.Get_Dataset("DASHBOARD_JOB_REPORT_MODEWISE_SELECT_NEW_02", param);
            dsMode = Connection.Get_Dataset("DASHBOARD_JOB_REPORT_MODEWISE_SELECT_USERWISE_IEC_BASED_SEARCH", param);
        }
        catch (Exception ex)
        {
            LastError = ex.Message;
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return dsMode;
    }

    // Backing data for the "NAK Status" card on the Home dashboard (see
    // E_royal_Impex_Home.aspx's importExtraCard row and its drill-down panel) - Import jobs
    // with a pending .nak mail and no matching .ack yet, per dbo.IMPORT_NAK_ACK_PENDING_SEARCH.
    // mode is the same Sea/Air/Land value as DASHBOARD_JOB_REPORT_MODEWISE's @MODE ("" = all
    // modes). One row per pending JOB_NO (the SP itself collapses multiple .nak mails for the
    // same job down to one row - see its own PendingNAK/RN=1 logic).
    public DataSet IMPORT_NAK_ACK_PENDING_SEARCH(string mode = "")
    {
        DataSet dsNak = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[1] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[2] = new SqlParameter("@MODE", mode ?? "");
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            dsNak = Connection.Get_Dataset("IMPORT_NAK_ACK_PENDING_SEARCH", param);
        }
        catch (Exception ex)
        {
            LastError = ex.Message;
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return dsNak;
    }

    // Just the count (for the card's own number) - the drill-down panel (opened by clicking
    // the card) calls IMPORT_NAK_ACK_PENDING_SEARCH directly for the actual JOB_NO/File_Remarks
    // rows instead, see E_royal_Impex_Home.aspx.cs's GetNakStatusPendingJobs().
    public int IMPORT_NAK_ACK_PENDING_COUNT(string mode = "")
    {
        DataSet dsNak = IMPORT_NAK_ACK_PENDING_SEARCH(mode);
        return dsNak.Tables.Count > 0 ? dsNak.Tables[0].Rows.Count : 0;
    }

    // Backing data for the "Query Reply" card on the Home dashboard (see
    // E_royal_Impex_Home.aspx's importExtraCard row) - same shape as IMPORT_NAK_ACK_PENDING_
    // SEARCH above, per dbo.IMPORT_QUERY_PENDING_SEARCH. Card only shows the count (no
    // drill-down), so this is only ever consumed via IMPORT_QUERY_PENDING_COUNT() below.
    public DataSet IMPORT_QUERY_PENDING_SEARCH(string mode = "")
    {
        DataSet dsQuery = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[1] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[2] = new SqlParameter("@MODE", mode ?? "");
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            dsQuery = Connection.Get_Dataset("IMPORT_QUERY_PENDING_SEARCH", param);
        }
        catch (Exception ex)
        {
            LastError = ex.Message;
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return dsQuery;
    }

    // Just the count (for the card's own number) - see IMPORT_NAK_ACK_PENDING_COUNT() above.
    public int IMPORT_QUERY_PENDING_COUNT(string mode = "")
    {
        DataSet dsQuery = IMPORT_QUERY_PENDING_SEARCH(mode);
        return dsQuery.Tables.Count > 0 ? dsQuery.Tables[0].Rows.Count : 0;
    }

    // Backing data for the "IGM Regularised" card on the Home dashboard (see
    // E_royal_Impex_Home.aspx's importExtraCard row) - same shape as IMPORT_NAK_ACK_PENDING_
    // SEARCH above, per dbo.IMPORT_REGULARISED_PENDING_SEARCH. Card only shows the count (no
    // drill-down), so this is only ever consumed via IMPORT_REGULARISED_PENDING_COUNT() below.
    public DataSet IMPORT_REGULARISED_PENDING_SEARCH(string mode = "")
    {
        DataSet dsReg = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[1] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[2] = new SqlParameter("@MODE", mode ?? "");
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            dsReg = Connection.Get_Dataset("IMPORT_REGULARISED_PENDING_SEARCH", param);
        }
        catch (Exception ex)
        {
            LastError = ex.Message;
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return dsReg;
    }

    // Just the count (for the card's own number) - see IMPORT_NAK_ACK_PENDING_COUNT() above.
    public int IMPORT_REGULARISED_PENDING_COUNT(string mode = "")
    {
        DataSet dsReg = IMPORT_REGULARISED_PENDING_SEARCH(mode);
        return dsReg.Tables.Count > 0 ? dsReg.Tables[0].Rows.Count : 0;
    }

}