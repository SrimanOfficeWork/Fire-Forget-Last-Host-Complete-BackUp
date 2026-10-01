using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class Income_Charge_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    Global_variables ObjUBO = new Global_variables();

    public DataSet Charge_Master_Select(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CHARGE_ID", objUserBL.A1); //ID
            param[1] = new SqlParameter("@Flag", objUserBL.A2); //Flag
            param[2] = new SqlParameter("@CHARGE_NAME", objUserBL.A3); //CHARGE_NAME
            param[3] = new SqlParameter("@startRowIndex", objUserBL.A4); //Party_Ref
            param[4] = new SqlParameter("@maximumRows", objUserBL.A5); //REMARKS
            param[5] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_CHARGE_MASTER_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Charge_INS_UPD(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[31];
            param[1] = new SqlParameter("@ID", objUserBL.A1); //ID
            param[2] = new SqlParameter("@CHARGE_NAME", objUserBL.A2);//CHARGE_NAME
            param[3] = new SqlParameter("@CH_DESCRIPTION", objUserBL.A3);//CH_DESCRIPTION
            param[4] = new SqlParameter("@TAX_MODE", objUserBL.A4);//Tax_Mode
            param[5] = new SqlParameter("@HSN_CODE", objUserBL.A5);//HSN_CODE
            param[6] = new SqlParameter("@SA_CODE", objUserBL.A6);//SA_CODE
            param[7] = new SqlParameter("@CGST_RATE", objUserBL.A7);//CGST_RATE
            param[8] = new SqlParameter("@SGST_RATE", objUserBL.A8);//SGST_RATE
            param[9] = new SqlParameter("@IGST_RATE", objUserBL.A9);//IGST_RATE
            param[10] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.A10); //SHIPMENT_TYPE

            param[11] = new SqlParameter("@GROUP_NAME", objUserBL.A11);//SHIPPER_ADDRESS
            param[12] = new SqlParameter("@NATURE_OF_TRANS", objUserBL.A12);//CONSIGNEE_ADDRESS

            param[13] = new SqlParameter("@DEBIT_AMT", objUserBL.A13);//ADVANCE_AMT
            param[14] = new SqlParameter("@CREDIT_AMT", objUserBL.A14);//EXPENSE_AMT

            param[15] = new SqlParameter("@ALLOW_QUOTATION", objUserBL.A15);//ALLOW_QUOTATION
            
            param[24] = new SqlParameter("@flag", objUserBL.A25); //Flag
            param[25] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[26] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[27] = new SqlParameter("@USERID", Connection.Current_User());

            param[28] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[28].Direction = ParameterDirection.Output;

            param[29] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[29].Direction = ParameterDirection.Output;

            param[30] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[30].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("ACC_GST_CHARGE_DETAILS_INS_UPD", param);
            result = Convert.ToInt32(param[29].Value.ToString());

            if (objUserBL.A25 == "S")//Flag
            {
                UPDATE_ID = Convert.ToInt32(param[28].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public DataSet Charge_Ins_Upd_N(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[31];
            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@CHARGE_NAME", objUserBL.A2);
            param[3] = new SqlParameter("@HSN_SAC", objUserBL.A3);
            param[4] = new SqlParameter("@HSN_SAC_CODE", objUserBL.A4);
            param[5] = new SqlParameter("@CHARGE_CAT", objUserBL.A5);
            param[6] = new SqlParameter("@TAX_MODE", objUserBL.A6);
            param[7] = new SqlParameter("@I_LEG", objUserBL.A7);
            param[8] = new SqlParameter("@E_LEG", objUserBL.A8);
            param[9] = new SqlParameter("@G_LEG", objUserBL.A9);

            param[10] = new SqlParameter("@CGST_RATE", objUserBL.A10);
            param[11] = new SqlParameter("@SGST_RATE", objUserBL.A11);
            param[12] = new SqlParameter("@IGST_RATE", objUserBL.A12);
            param[13] = new SqlParameter("@ACTIVE", objUserBL.A13);
            param[14] = new SqlParameter("@flag", objUserBL.A25);

            param[25] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[26] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[27] = new SqlParameter("@USERID", Connection.Current_User());

            param[30] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[30].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_CHARGE_MASTER_DATA_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Charge_Data_Search(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[11];
           
            param[1] = new SqlParameter("@CHARGE_NAME", objUserBL.A1); 
            param[2] = new SqlParameter("@ACTIVE", objUserBL.A2); 
            param[3] = new SqlParameter("@APPLICABLE", objUserBL.A3);
            param[4] = new SqlParameter("@CHARGE_CAT", objUserBL.A4); 
            param[5] = new SqlParameter("@Flag", objUserBL.A5);
            param[6] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_CHARGE_MASTER_DATA_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Group_Type_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[11];
            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@GROUP_TYPE_CODE", objUserBL.A2);
            param[3] = new SqlParameter("@GROUP_TYPE_NAME", objUserBL.A3);
            param[4] = new SqlParameter("@REMARKS", objUserBL.A4);

            param[6] = new SqlParameter("@flag", objUserBL.A10);
            param[7] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[8] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@USERID", Connection.Current_User());

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_LEDGER_GROUP_TYPE_MASTER_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Group_Type_Search(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[11];

            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@GROUP_TYPE_NAME", objUserBL.A2);
            
            param[5] = new SqlParameter("@Flag", objUserBL.A5);
            param[6] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_LEDGER_GROUP_TYPE_MASTER_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Group_Cat_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[11];
            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@CATEGORY_CODE", objUserBL.A2);
            param[3] = new SqlParameter("@CATEGORY_NAME", objUserBL.A3);
            param[4] = new SqlParameter("@REMARKS", objUserBL.A4);

            param[6] = new SqlParameter("@flag", objUserBL.A10);
            param[7] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[8] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@USERID", Connection.Current_User());

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_LEDGER_GROUP_CATEGORY_MASTER_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Group_Cat_Search(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[11];

            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@CATEGORY_CODE", objUserBL.A2);

            param[5] = new SqlParameter("@Flag", objUserBL.A5);
            param[6] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_LEDGER_GROUP_CATEGORY_MASTER_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Group_List_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[11];
            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@GROUP_LIST_CODE", objUserBL.A2);
            param[3] = new SqlParameter("@GROUP_LIST_NAME", objUserBL.A3);
            param[4] = new SqlParameter("@REMARKS", objUserBL.A4);

            param[6] = new SqlParameter("@flag", objUserBL.A10);
            param[7] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[8] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@USERID", Connection.Current_User());

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_LEDGER_GROUPS_LIST_MASTER_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Group_List_Search(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[11];

            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@GROUP_LIST_CODE", objUserBL.A2);

            param[5] = new SqlParameter("@Flag", objUserBL.A5);
            param[6] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_LEDGER_GROUPS_LIST_MASTER_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Sub_Group_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[11];
            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@SUB_GROUP_CODE", objUserBL.A2);
            param[3] = new SqlParameter("@SUB_GROUP_NAME", objUserBL.A3);
            param[4] = new SqlParameter("@REMARKS", objUserBL.A4);

            param[6] = new SqlParameter("@flag", objUserBL.A10);
            param[7] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[8] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@USERID", Connection.Current_User());

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_LEDGER_SUB_GROUP_MASTER_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Sub_Group_Search(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[11];
            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@SUB_GROUP_CODE", objUserBL.A2);

            param[5] = new SqlParameter("@Flag", objUserBL.A5);
            param[6] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_LEDGER_SUB_GROUP_MASTER_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet COA_Master_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@CHARGE_NAME", objUserBL.A2);
            param[3] = new SqlParameter("@COA_TYPE", objUserBL.A3);
            param[4] = new SqlParameter("@COA_CAT", objUserBL.A4);
            param[5] = new SqlParameter("@COA_GROUP", objUserBL.A5);
            param[6] = new SqlParameter("@COA_SUB_GROUP", objUserBL.A6);
            param[7] = new SqlParameter("@CHARGE_DESC", objUserBL.A7);
            param[8] = new SqlParameter("@REMARKS", objUserBL.A8);
           

            param[16] = new SqlParameter("@flag", objUserBL.A20);
            param[17] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[18] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[19] = new SqlParameter("@USERID", Connection.Current_User());

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_COA_MASTER_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet COA_Master_Search(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[11];
            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@CHARGE_NAME", objUserBL.A2);
            param[3] = new SqlParameter("@COA_TYPE", objUserBL.A3);

            param[5] = new SqlParameter("@Flag", objUserBL.A5);
            param[6] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_COA_MASTER_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}