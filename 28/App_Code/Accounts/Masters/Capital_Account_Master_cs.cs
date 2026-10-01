using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class Capital_Account_Master_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    Global_variables ObjUBO = new Global_variables();

    public DataSet Capital_Account_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[2] = new SqlParameter("@C_ID", objUserBL.A1);
            param[3] = new SqlParameter("@LEDGER", objUserBL.A2);
            param[4] = new SqlParameter("@UNDER", objUserBL.A3);

            param[16] = new SqlParameter("@Flag", objUserBL.A15);
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@Wrk_period", Connection.WorkingPeriod());
            param[19] = new SqlParameter("@Company_Lic", Connection.Company_License());

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_CAPITAL_ACCOUNT_MASTER_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Capital_Search(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[3] = new SqlParameter("@LEDGER", objUserBL.A3);
            param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[8] = new SqlParameter("@Flag", objUserBL.A7);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_CAPITAL_ACCOUNT_MASTER_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Capital_Account_Ins_Upd(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[71];
            param[1] = new SqlParameter("@C_ID", objUserBL.A1);
            param[2] = new SqlParameter("@LEDGER", objUserBL.A2);
            param[3] = new SqlParameter("@UNDER", objUserBL.A3);
            param[4] = new SqlParameter("@ADDRESS_1", objUserBL.A4);
            param[5] = new SqlParameter("@ADDRESS_2", objUserBL.A5);
            param[6] = new SqlParameter("@DISTRICT", objUserBL.A6);
            param[7] = new SqlParameter("@STATE_CODE", objUserBL.A7);
            param[8] = new SqlParameter("@PIN_CODE", objUserBL.A8);
            param[9] = new SqlParameter("@PAN_NO", objUserBL.A9);
            param[10] = new SqlParameter("@GST_NO", objUserBL.A10);
            param[11] = new SqlParameter("@OPENING_BALANCE", objUserBL.A11);

            param[12] = new SqlParameter("@Flag", objUserBL.A24);
            param[25] = new SqlParameter("@Company_Lic", Connection.Company_License());
            param[26] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[27] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[28] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[29] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[30] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[30].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_CAPITAL_ACCOUNT_MASTER_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }
}