using System;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;

public class Chart_Of_Accounts_cs
{
    DataSet ds = new DataSet();

    // 🔹 SEARCH / SELECT (TREE LOAD)
    public DataSet Chart_Accounts_Search(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[16];

            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@NAME", objUserBL.A2);
            param[3] = new SqlParameter("@GROUP_CODE", objUserBL.A3);
            param[4] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[5] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());

            param[12] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@FLAG", objUserBL.A6);
            param[14] = new SqlParameter("@USERID", Connection.Current_User());

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_CHART_OF_ACCOUNTS_SEARCH_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    // 🔹 INSERT / UPDATE / DELETE
    public DataSet Chart_Accounts_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@ID", objUserBL.A1);
            param[1] = new SqlParameter("@NAME", objUserBL.A2);
            param[2] = new SqlParameter("@GROUP_CODE", objUserBL.A3);   // ✅ FIX
            param[3] = new SqlParameter("@PARENT_ID", objUserBL.A4);    // ✅ FIX
            param[4] = new SqlParameter("@NODE_TYPE", objUserBL.A5);
            param[5] = new SqlParameter("@ALIAS", objUserBL.A6);
            param[6] = new SqlParameter("@ORDER_NO", objUserBL.A7);
            param[7] = new SqlParameter("@CONTROL_AC", objUserBL.A8);
            param[8] = new SqlParameter("@TRANSACTED_AT", objUserBL.A9);
            param[9] = new SqlParameter("@CHK_CURRENCY", objUserBL.A10);
            param[10] = new SqlParameter("@CURRENCY", objUserBL.A11);
            param[11] = new SqlParameter("@FLAG", objUserBL.A18);


            param[23] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[24] = new SqlParameter("@JOB_LICENSE", Connection.Company_License());
            param[25] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A20);
            param[26] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[27] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
          
            param[28] = new SqlParameter("@USERID", Connection.Current_User());

            param[29] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[29].Direction = ParameterDirection.Output;

            return Connection.Get_Dataset("ACC_GST_CHART_OF_ACCOUNTS_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
            return null;
        }
    }
}