using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Text;


public class DSR_Automail_Scheduler
{
    DataSet ds = new DataSet();
    public DataSet Auto_Mail_Search(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@SCHEDULER_ID", objUserBL.A1);
            param[2] = new SqlParameter("@IMP_EXP_NAME", objUserBL.A2);
            param[3] = new SqlParameter("@LAST_SEND_DATE", objUserBL.A3);
            param[4] = new SqlParameter("@NEXT_SEND_DATE", objUserBL.A4);
            param[6] = new SqlParameter("@MAIL_STATUS", objUserBL.A6);
            param[7] = new SqlParameter("@SCHEDULE_NAME", objUserBL.A7);
            param[8] = new SqlParameter("@SCHEDULE", objUserBL.A8);

            param[12] = new SqlParameter("@MFLAG", objUserBL.A50);
            param[16] = new SqlParameter("@BRANCH_COMMON", Connection.Current_Branch());
            param[18] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[18].Direction = ParameterDirection.Output;

           ds = Connection.Get_Dataset("DSR_AUTO_MAIL_SCHEDULER_GRID_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
	public DataSet Auto_Mail_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@SCHEDULER_ID", objUserBL.A1);
            param[2] = new SqlParameter("@IMP_EXP_NAME", objUserBL.A2);
            param[3] = new SqlParameter("@LAST_SEND_DATE", objUserBL.A3);
            param[4] = new SqlParameter("@NEXT_SEND_DATE", objUserBL.A4);
            param[6] = new SqlParameter("@MAIL_STATUS", objUserBL.A6);
            param[7] = new SqlParameter("@SCHEDULE_NAME", objUserBL.A7);
            param[8] = new SqlParameter("@SCHEDULE", objUserBL.A8);

            param[12] = new SqlParameter("@MFLAG", objUserBL.A50);
            param[16] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[18].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("DSR_AUTO_MAIL_SCHEDULER_SEARCH_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
	}
    public DataSet Auto_Mail_Ins_Upd(Global_variables objUserBL)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[35];

                param[1] = new SqlParameter("@SCHEDULER_ID", objUserBL.A3);
                param[2] = new SqlParameter("@SCHEDULE_NAME", objUserBL.A4);
                param[3] = new SqlParameter("@NOTIFY_TO", objUserBL.A5);
                param[4] = new SqlParameter("@REPORT", objUserBL.A6);
                param[5] = new SqlParameter("@MAIL_SUBJECT", objUserBL.A7);
                param[6] = new SqlParameter("@MAIL_TO", objUserBL.A8);
                param[7] = new SqlParameter("@MAIL_CC", objUserBL.A9);
                param[8] = new SqlParameter("@MAIL_BCC", objUserBL.A10);
                param[9] = new SqlParameter("@MAIL_BODY", objUserBL.A11);
                param[10] = new SqlParameter("@SCHEDULE", objUserBL.A13);
                param[11] = new SqlParameter("@MAIL_STATUS", objUserBL.A16);
                param[12] = new SqlParameter("@LAST_SEND_DATE", objUserBL.A18); //
                param[13] = new SqlParameter("@NEXT_SEND_DATE", objUserBL.A19); //
                param[14] = new SqlParameter("@MAIL_SCHEDULED_DATE", objUserBL.A20);
                param[15] = new SqlParameter("@MAIL_FROM", objUserBL.A28);


                param[24] = new SqlParameter("@MFLAG", objUserBL.A50);
                param[25] = new SqlParameter("@Company_Lic", Connection.Company_License());
                param[26] = new SqlParameter("@USER_NAME", Connection.Current_User());
                param[27] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
                param[28] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
                param[29] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
                param[30] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                param[30].Direction = ParameterDirection.Output;
                ds = Connection.Get_Dataset("DSR_AUTO_MAIL_SCHEDULER_INS_UPD", param);
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
            return ds;
        }

}