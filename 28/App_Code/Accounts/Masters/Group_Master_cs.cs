using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class Group_Master_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet Group_Master_Select(Billing_UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@GROUP_ID", objUserBL.ID);
            param[1] = new SqlParameter("@Flag", objUserBL.Flag);
            param[2] = new SqlParameter("@GROUP_NAME", objUserBL.GROUP_NAME);
            param[3] = new SqlParameter("@startRowIndex", objUserBL.Party_Ref);
            param[4] = new SqlParameter("@maximumRows", objUserBL.REMARKS);
            param[5] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Ledger", objUserBL.LEDGER);
            param[7] = new SqlParameter("@Sub_Group", objUserBL.SUB_GROUP);            
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_GROUP_MASTER_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[9].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Group_INS_UPD(Billing_UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[50];
            param[0] = new SqlParameter("@ID", objUserBL.ID);
            param[1] = new SqlParameter("@GROUP", objUserBL.GROUP_NAME);
            param[2] = new SqlParameter("@SUB_GROUP", objUserBL.SUB_GROUP);
            param[3] = new SqlParameter("@LEDGER", objUserBL.LEDGER);
            param[4] = new SqlParameter("@REPORTING", objUserBL.REPORTING);
            param[5] = new SqlParameter("@OPENING_BALANCE", objUserBL.OPENING_BALANCE);
            param[6] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[7] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[8] = new SqlParameter("@USERID", Connection.Current_User());
            param[9] = new SqlParameter("@flag", objUserBL.Flag);
            param[10] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;

            ds=Connection.Get_Dataset("ACC_GST_GROUP_MASTER_DETAILS_INS_UPD", param);
            result = Convert.ToInt32(param[10].Value.ToString());

            if (objUserBL.Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[12].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}