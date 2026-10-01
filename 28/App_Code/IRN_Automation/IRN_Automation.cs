using System;
using System.Web;
using System.Data;
using BussinessObject;
using System.Data.SqlClient;


public class IRN_Automation
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    public DataSet IRN_Automation_Job_Client_Load(Global_variables objUserBL)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[16];

            param[2] = new SqlParameter("@JobNo_PS", objUserBL.A1);


            param[10] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[11] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[12] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[13] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[14] = new SqlParameter("@MFLAG", objUserBL.A4);
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_EXP_IRN_AUTOMATION", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet IRN_Automation_Insert_Update(Global_variables objUserBL)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[16];

            param[1] = new SqlParameter("@JobNo_PS", objUserBL.A1);
            param[2] = new SqlParameter("@JobNo", objUserBL.A2);
            param[3] = new SqlParameter("@Client_name", objUserBL.A3);
            param[4] = new SqlParameter("@xmlString", objUserBL.A5);
            param[5] = new SqlParameter("@ICEGATE_USER_NAME", objUserBL.A6);
            param[6] = new SqlParameter("@ICEGATE_PWD", objUserBL.A7);

            param[9] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[10] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[11] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[12] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[13] = new SqlParameter("@USER_ID", Connection.Current_User());

            param[14] = new SqlParameter("@MFLAG", objUserBL.A15);
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_EXP_IRN_AUTOMATION_INS_UPD_DEL", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Icegate_Login_Settting_Insert_Update(Global_variables objUserBL)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());
            param[2] = new SqlParameter("@USER_NAME", Connection.Current_User());
            param[3] = new SqlParameter("@ICEGATE_USER_NAME", objUserBL.A3);
            param[4] = new SqlParameter("@ICEGATE_PWD", objUserBL.A4);
            param[5] = new SqlParameter("@ICEGATE_SETTING_ID", objUserBL.A5);
            param[6] = new SqlParameter("@API_KEY", objUserBL.A6);

            param[12] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[13] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[14] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[15] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[16] = new SqlParameter("@MFLAG", objUserBL.A19);
            param[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[17].Direction = ParameterDirection.Output;
            param[18] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;
            param[19] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[19].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ICEGATE_LOGIN_SETTING_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[18].Value.ToString());
            UPDATE_ID = Convert.ToInt32(param[19].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);

        }
        return ds;
    }
    public DataSet IRN_Automation_Insert_Update_BG(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[1] = new SqlParameter("@JobNo_PS", objUserBL.A1);
            param[2] = new SqlParameter("@JobNo", objUserBL.A2);
            param[3] = new SqlParameter("@Client_name", objUserBL.A3);
            param[4] = new SqlParameter("@xmlString", objUserBL.A5);
            param[5] = new SqlParameter("@ICEGATE_USER_NAME", objUserBL.A6);
            param[6] = new SqlParameter("@ICEGATE_PWD", objUserBL.A7);
            param[7] = new SqlParameter("@Icegateerror", objUserBL.A9);
            param[8] = new SqlParameter("@JobType", objUserBL.A10);
            param[9] = new SqlParameter("@guidid", objUserBL.A11);
            param[10] = new SqlParameter("@Mail_type", objUserBL.A12);
            param[11] = new SqlParameter("@Mailid", objUserBL.A13);
            param[12] = new SqlParameter("@Mob_no", objUserBL.A14);
            param[13] = new SqlParameter("@MFLAG", objUserBL.A15);
            param[14] = new SqlParameter("@job_cat", objUserBL.A16);
            param[15] = new SqlParameter("@Mail_pass", objUserBL.A17);
            param[16] = new SqlParameter("@Mail_host", objUserBL.A18);
            param[17] = new SqlParameter("@Mail_port", objUserBL.A19);
            param[18] = new SqlParameter("@Mail_ssl", objUserBL.A20);
            param[19] = new SqlParameter("@MailTenentid", objUserBL.A21);
            param[20] = new SqlParameter("@MailClientid", objUserBL.A22);
            param[21] = new SqlParameter("@MailScreenid", objUserBL.A23);

            param[22] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[23] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[24] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[25] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[26] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[27] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[27].Direction = ParameterDirection.Output;
           

            ds = Connection.Get_Dataset("IMP_EXP_IRN_AUTOMATION_INS_UPD_DEL_BG", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Retrieve_Icegate_Login_setting_Details(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@ICEGATE_SETTING_ID", objUserBL.A1);
            param[1] = new SqlParameter("@USER_NAME", Connection.Current_User());
            param[2] = new SqlParameter("@ICEGATE_USER_NAME", objUserBL.A2);
           
          
            param[6] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[8] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[9] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[10] = new SqlParameter("@MFLAG", objUserBL.A14);
            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;
            param[13] = new SqlParameter("@startRowIndex", objUserBL.A5);
            param[14] = new SqlParameter("@maximumRows", objUserBL.A6);
            param[15] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ICEGATE_LOGIN_SETTING_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[15].Value.ToString());
          

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
   
    public DataSet IRN_Automation_Dashboard(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[1] = new SqlParameter("@JobNo", objUserBL.A1);
            param[2] = new SqlParameter("@JobType", objUserBL.A2);
            param[3] = new SqlParameter("@Jobstatus", objUserBL.A3);
            param[4] = new SqlParameter("@from_date", objUserBL.A4);
            param[5] = new SqlParameter("@To_date", objUserBL.A5);
            param[6] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[8] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[9] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[10] = new SqlParameter("@MFLAG", objUserBL.A10);
            param[11] = new SqlParameter("@startRowIndex", objUserBL.A11);
            param[12] = new SqlParameter("@maximumRows", objUserBL.A12);
            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@JOBNO_MULTI", objUserBL.A6);

            ds = Connection.Get_Dataset("IMP_EXP_IRN_AUTOMATION_DASHBOARD", param);
            result = Convert.ToInt32(param[14].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}