using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class GST_Expense_Charge_Master
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet GST_Expense_Charge_Master_Select(Billing_UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CHARGE_ID", objUserBL.ID);
            param[1] = new SqlParameter("@Flag", objUserBL.Flag);
            param[2] = new SqlParameter("@CHARGE_NAME", objUserBL.CHARGE_NAME);
            param[3] = new SqlParameter("@startRowIndex", objUserBL.Party_Ref);
            param[4] = new SqlParameter("@maximumRows", objUserBL.REMARKS);
            param[5] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_EXPENSE_CHARGE_MASTER_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void GST_Expense_Charge_INS_UPD(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];
            param[0] = new SqlParameter("@ID", objUserBL.ID);
            param[1] = new SqlParameter("@CHARGE_NAME", objUserBL.CHARGE_NAME);
            param[2] = new SqlParameter("@CH_DESCRIPTION", objUserBL.CH_DESCRIPTION);
            param[3] = new SqlParameter("@TAX_MODE", objUserBL.Tax_Mode);
            param[4] = new SqlParameter("@HSN_CODE", objUserBL.HSN_CODE);
            param[5] = new SqlParameter("@SA_CODE", objUserBL.SA_CODE);
            param[6] = new SqlParameter("@CGST_RATE", objUserBL.CGST_RATE);
            param[7] = new SqlParameter("@SGST_RATE", objUserBL.SGST_RATE);
            param[8] = new SqlParameter("@IGST_RATE", objUserBL.IGST_RATE);
            param[9] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);
            param[10] = new SqlParameter("@ALLOW_QUOTATION", objUserBL.ALLOW_QUOTATION);
            param[11] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[12] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@USERID", Connection.Current_User());
            param[14] = new SqlParameter("@flag", objUserBL.Flag);
            param[15] = new SqlParameter("@GROUP_NAME", objUserBL.GROUP_NAME);
            param[16] = new SqlParameter("@NATURE_OF_TRANS", objUserBL.CONSIGNEE_ADDRESS);
            param[17] = new SqlParameter("@DEBIT_AMT", objUserBL.ADVANCE_AMT);
            param[18] = new SqlParameter("@CREDIT_AMT", objUserBL.EXPENSE_AMT);

            param[20] = new SqlParameter("@TDS_SECTION", objUserBL.TDS_SECTION );
            param[21] = new SqlParameter("@TDS_RATE", objUserBL.TDS_RATE);
            param[22] = new SqlParameter("@ACTIVE", objUserBL.ACTIVE );
            param[23] = new SqlParameter("@NARRATION", objUserBL.NARRATION);

            param[24] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[24].Direction = ParameterDirection.Output;

            param[25] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[25].Direction = ParameterDirection.Output;

            param[26] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[26].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("GST_EXPENSE_CHARGE_MASTER_INS_UPD", param);
            result = Convert.ToInt32(param[24].Value.ToString());

            if (objUserBL.Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[26].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


}