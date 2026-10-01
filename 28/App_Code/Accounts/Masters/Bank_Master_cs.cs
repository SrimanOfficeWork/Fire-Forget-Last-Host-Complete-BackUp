using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class Bank_Master_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet Bank_Master_Select(Billing_UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@BANK_ID", objUserBL.ID);
            param[1] = new SqlParameter("@Flag", objUserBL.Flag);
            param[2] = new SqlParameter("@BANK_NAME", objUserBL.NAME);
            param[3] = new SqlParameter("@startRowIndex", objUserBL.Party_Ref);
            param[4] = new SqlParameter("@maximumRows", objUserBL.REMARKS);
            param[5] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Sub_Group", objUserBL.SUB_GROUP);
            param[7] = new SqlParameter("@Group", objUserBL.GROUP_NAME);
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_BANK_MASTER_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[9].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Bank_INS_UPD(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@ID", objUserBL.ID);
            param[1] = new SqlParameter("@NAME", objUserBL.NAME);
            param[2] = new SqlParameter("@OPENING_BALANCE", objUserBL.OPENING_BALANCE);
            param[3] = new SqlParameter("@GROUP", objUserBL.GROUP_NAME);
            param[4] = new SqlParameter("@SUB_GROUP", objUserBL.SUB_GROUP);            
            param[5] = new SqlParameter("@REPORTING", objUserBL.REPORTING);
            param[6] = new SqlParameter("@ACCOUNT_HOLDER_NAME", objUserBL.ACCOUNT_HOLDER_NAME);
            param[7] = new SqlParameter("@ACCOUNT_NUMBER", objUserBL.ACCOUNT_NUMBER);
            param[8] = new SqlParameter("@IFSCODE", objUserBL.IFSCODE);
            param[9] = new SqlParameter("@BANK_NAME", objUserBL.BankName);
            param[10] = new SqlParameter("@BRANCH", objUserBL.BankBranch);
            param[11] = new SqlParameter("@GST_NUMBER", objUserBL.GST_NUMBER);
            param[12] = new SqlParameter("@ADDRESS1", objUserBL.BR_ADDRESS1);
            param[13] = new SqlParameter("@ADDRESS2", objUserBL.BR_ADDRESS2);
            param[14] = new SqlParameter("@DISTRICT", objUserBL.DISTRICT);
            param[15] = new SqlParameter("@STATE", objUserBL.State_Name);
            param[16] = new SqlParameter("@PINCODE", objUserBL.PINCODE);
            param[17] = new SqlParameter("@SET_CHEQUE_BOOKS", objUserBL.SET_CHEQUE_BOOKS);
            param[18] = new SqlParameter("@ENABLE_CHEQUE_PRINTING", objUserBL.ENABLE_CHEQUE_PRINTING);
            param[19] = new SqlParameter("@ENABLE_AUTO_RECONCILATION", objUserBL.ENABLE_AUTO_RECONCILATION);
            param[20] = new SqlParameter("@ENABLE_E_PAYMENTS", objUserBL.ENABLE_E_PAYMENTS);
            param[21] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[22] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[23] = new SqlParameter("@USERID", Connection.Current_User());
            param[24] = new SqlParameter("@flag", objUserBL.Flag);
            param[25] = new SqlParameter("@G_L_NAME",objUserBL.A1);
            param[26] = new SqlParameter("@GL_CODE", objUserBL.A2);


            param[27] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[27].Direction = ParameterDirection.Output;

            param[28] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[28].Direction = ParameterDirection.Output;

            param[29] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[29].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("ACC_GST_BANK_MASTER_DETAILS_INS_UPD", param);
            result = Convert.ToInt32(param[27].Value.ToString());

            if (objUserBL.Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[27].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
}