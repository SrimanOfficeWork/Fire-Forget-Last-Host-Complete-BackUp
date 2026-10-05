using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BussinessObject;
using System.Data.SqlClient;


public class AI_Queue
{
    DataSet ds = new DataSet();
    public int result = 0;

    // ── INSERT ───────────────────────────────────────────────────────
    public DataSet Queue_Insert(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[1] = new SqlParameter("@JOB_NO", objUserBL.A1);
            param[2] = new SqlParameter("@FILE_NAME", objUserBL.A2);
            param[3] = new SqlParameter("@VENDOR_TYPE", objUserBL.A3);
            param[4] = new SqlParameter("@PROCESS_ID", objUserBL.A4);
            param[5] = new SqlParameter("@IMPORTER_NAME", objUserBL.A5);
            param[6] = new SqlParameter("@SL_NO", objUserBL.A16);
            param[7] = new SqlParameter("@PDF_CLIENT_NAME", objUserBL.A17);
            param[8] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());
            param[9] = new SqlParameter("@JOB_TYPE", objUserBL.A10 ?? "IMP"); // A10 = JOB_TYPE
            param[10] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[11] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[12] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[13] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[14] = new SqlParameter("@MFLAG", "INSERT");
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("PDF_AI_QUEUE_INSERT_UPDATE_SELECT", param);
        }
        catch (Exception ex) { Connection.Error_Msg(ex.Message); }
        return ds;
    }

    // ── UPDATE STATUS ────────────────────────────────────────────────
    public DataSet Queue_Update_Status(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@PROCESS_ID", objUserBL.A4);
            param[2] = new SqlParameter("@STATUS", objUserBL.A6);
            param[3] = new SqlParameter("@JSON_RESPONSE", objUserBL.A7 ?? "");
            param[10] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[11] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[12] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[13] = new SqlParameter("@MFLAG", "UPDATE_STATUS");
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("PDF_AI_QUEUE_INSERT_UPDATE_SELECT", param);
        }
        catch (Exception ex) { Connection.Error_Msg(ex.Message); }
        return ds;
    }

    // ── GRID DATA ────────────────────────────────────────────────────
    // A1=JOB_NO, A3=VENDOR_TYPE, A6=STATUS, A8=FROM_DATE,
    // A9=TO_DATE, A10=JOB_TYPE, A11=pageIndex, A12=pageSize
    public DataSet Queue_Grid_Data(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[1] = new SqlParameter("@JOB_NO", objUserBL.A1 ?? "");
            param[2] = new SqlParameter("@VENDOR_TYPE", objUserBL.A3 ?? "");
            param[3] = new SqlParameter("@STATUS", objUserBL.A6 ?? "");
            param[4] = new SqlParameter("@FROM_DATE", objUserBL.A8 ?? "");
            param[5] = new SqlParameter("@TO_DATE", objUserBL.A9 ?? "");
            param[6] = new SqlParameter("@JOB_TYPE", objUserBL.A10 ?? ""); // '' = both
            param[10] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[11] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[12] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[13] = new SqlParameter("@MFLAG", "GRID_DATA");
            param[14] = new SqlParameter("@startRowIndex", objUserBL.A11 ?? "1");
            param[15] = new SqlParameter("@maximumRows", objUserBL.A12 ?? "10");
            param[16] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;
            param[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[17].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("PDF_AI_QUEUE_INSERT_UPDATE_SELECT", param);
            result = Convert.ToInt32(param[16].Value.ToString());
        }
        catch (Exception ex) { Connection.Error_Msg(ex.Message); }
        return ds;
    }

    // ── COUNT ONLY ───────────────────────────────────────────────────
    // status = '' → total, 'IN PROGRESS', 'READY', 'FAILED'
    // jobType = '' → both, 'IMP', 'EXP'
    public int Queue_Count_Only(string status, string jobType = "")
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@STATUS", status ?? "");
            param[2] = new SqlParameter("@JOB_TYPE", jobType ?? "");
            param[10] = new SqlParameter("@MFLAG", "COUNT_ONLY");
            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;
            Connection.Get_Dataset("PDF_AI_QUEUE_INSERT_UPDATE_SELECT", param);
            return Convert.ToInt32(param[11].Value.ToString());
        }
        catch { return 0; }
    }

    // ── DELETE SINGLE ────────────────────────────────────────────────
    public DataSet Queue_Delete(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@QUEUE_ID", Convert.ToInt32(objUserBL.A13 ?? "0"));
            param[10] = new SqlParameter("@MFLAG", "DELETE");
            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("PDF_AI_QUEUE_INSERT_UPDATE_SELECT", param);
        }
        catch (Exception ex) { Connection.Error_Msg(ex.Message); }
        return ds;
    }

    // ── DELETE MULTIPLE ──────────────────────────────────────────────
    public DataSet Queue_Delete_Multiple(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@JOB_NO", objUserBL.A1); // comma-separated IDs
            param[10] = new SqlParameter("@MFLAG", "DELETE_MULTIPLE");
            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("PDF_AI_QUEUE_INSERT_UPDATE_SELECT", param);
        }
        catch (Exception ex) { Connection.Error_Msg(ex.Message); }
        return ds;
    }

    // ── GET BY PROCESS ID ────────────────────────────────────────────
    public DataSet Queue_Get_By_ProcessId(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@PROCESS_ID", objUserBL.A4);
            param[10] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[11] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[12] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[13] = new SqlParameter("@MFLAG", "GET_BY_PROCESS_ID");
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("PDF_AI_QUEUE_INSERT_UPDATE_SELECT", param);
        }
        catch (Exception ex) { Connection.Error_Msg(ex.Message); }
        return ds;
    }


    public DataSet Job_No_Update(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@PROCESS_ID", objUserBL.A2);
            param[2] = new SqlParameter("@JOB_NO", objUserBL.A1);
            param[13] = new SqlParameter("@MFLAG", "UPDATE_JOBNO");
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("PDF_AI_QUEUE_INSERT_UPDATE_SELECT", param);
        }
        catch (Exception ex) { Connection.Error_Msg(ex.Message); }
        return ds;
    }


    

}
