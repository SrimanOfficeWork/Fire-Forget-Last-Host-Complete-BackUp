using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;
using Microsoft.ApplicationBlocks.Data;

public class Acc_Charge_Master_New_cs
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    public int result, UPDATE_ID = 0; 
    public double Total_Rows = 0;

  
    public DataSet Charge_Master_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[41];
            param[2] = new SqlParameter("@CHRG_ID", objUserBL.A1);
            param[3] = new SqlParameter("@CHARGE_CODE", objUserBL.A2);
            param[4] = new SqlParameter("@CHARGE_NAME", objUserBL.A3);
            param[5] = new SqlParameter("@APPLICABLE_FOR", objUserBL.A4);
            param[6] = new SqlParameter("@CHARGE_CATEGORY", objUserBL.A5);
            param[7] = new SqlParameter("@CHARGE_TYPE", objUserBL.A6);
            param[8] = new SqlParameter("@IATA_CODE", objUserBL.A7);
            param[9] = new SqlParameter("@SERVICE_TAX_APPLICABLE", objUserBL.A8);
            param[10] = new SqlParameter("@SERVICE_TAX_CATEGORY", objUserBL.A9);
            param[11] = new SqlParameter("@VAT_APPLICABLE", objUserBL.A10);
            param[12] = new SqlParameter("@VAT_CATEGORY", objUserBL.A11);
            param[13] = new SqlParameter("@GST_APPLICABLE", objUserBL.A12);
            param[14] = new SqlParameter("@GST_SAC_HSN", objUserBL.A13);
            param[15] = new SqlParameter("@GST_HSN_SAC_CODE", objUserBL.A14); 
            param[16] = new SqlParameter("@GST_CATEGORY", objUserBL.A15);
            param[17] = new SqlParameter("@GST_SUB_CATEGORY", objUserBL.A16);
            param[18] = new SqlParameter("@GST_TAXABLE", objUserBL.A17);
            param[19] = new SqlParameter("@GST_OVERRIDE", objUserBL.A18);
            param[20] = new SqlParameter("@VLE_INCOME", objUserBL.A19);
            param[21] = new SqlParameter("@VLE_EXPENSE", objUserBL.A20);
            param[22] = new SqlParameter("@VLE_COST_CENTER", objUserBL.A21);
            param[23] = new SqlParameter("@CCI_INCOME", objUserBL.A22);
            param[24] = new SqlParameter("@CCI_EXPENSE", objUserBL.A23);
            param[25] = new SqlParameter("@CCI_COST_CENTER", objUserBL.A24);
            param[26] = new SqlParameter("@CCE_INCOME", objUserBL.A25);
            param[27] = new SqlParameter("@CCE_EXPENSE", objUserBL.A26);
            param[28] = new SqlParameter("@CCE_COST_CENTER", objUserBL.A27);
            param[29] = new SqlParameter("@TRN_INCOME", objUserBL.A28);
            param[30] = new SqlParameter("@TRN_EXPENSE", objUserBL.A29);
            param[31] = new SqlParameter("@TRN_COST_CENTER", objUserBL.A30);
            param[32] = new SqlParameter("@GEN_INCOME", objUserBL.A31);
            param[33] = new SqlParameter("@GEN_EXPENSE", objUserBL.A32);
            param[34] = new SqlParameter("@GEN_COST_CENTER", objUserBL.A33);
            param[35] = new SqlParameter("@Flag", objUserBL.A34);
            param[36] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[37] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[38] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[39] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_MAS_CHARGE_NEW_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Charge_Master_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@CHRG_ID", objUserBL.A1);
            param[2] = new SqlParameter("@Name_Search", objUserBL.A2);

            param[7] = new SqlParameter("@Flag", objUserBL.A9);
            param[8] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_MAS_CHARGE_NEW_INFO_SEL", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Charge_Master_Search(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Name", objUserBL.A1);
            param[2] = new SqlParameter("@ChargeType", objUserBL.A2);
            param[3] = new SqlParameter("@Active", objUserBL.A3);
            param[4] = new SqlParameter("@ApplicableFor", objUserBL.A4);
            param[5] = new SqlParameter("@ChargeCategory", objUserBL.A5);
            param[7] = new SqlParameter("@Flag", objUserBL.A10);
            param[8] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_MAS_CHARGE_NEW_INFO_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Admin_HSN_SAC_Select(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@Name_Search", objUserBL.A1);
            param[2] = new SqlParameter("@name", objUserBL.A2);
            param[3] = new SqlParameter("@Notn_No_Search", objUserBL.A3);
            param[4] = new SqlParameter("@Notn_Type", objUserBL.A4);

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_AUTOCOMPLETE_SEARCH_MASTER_PART_II", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Admin_HSN_SAC_GL_Ledger_Grid(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[11];
            param[1] = new SqlParameter("@HSN_SAC_ID", objUserBL.A1); 
            param[2] = new SqlParameter("@CODE", objUserBL.A2); 
            param[3] = new SqlParameter("@DESCRIPTION", objUserBL.A3); 
            param[4] = new SqlParameter("@startRowIndex", objUserBL.A4); 
            param[5] = new SqlParameter("@maximumRows", objUserBL.A5); 
            param[6] = new SqlParameter("@name", objUserBL.A10); 

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ACC_HSN_SAC_MASTER_SEARCH_SELECT", param);
            Total_Rows = Convert.ToInt32(param[9].Value.ToString());

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                ds.Tables.Add(dt);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet GL_Ledger_Grid(Global_variables objUserBL)  
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[16];
            param[1] = new SqlParameter("@LEDGER_ID", objUserBL.A1); 
            param[2] = new SqlParameter("@CODE", objUserBL.A2); 
            param[3] = new SqlParameter("@LEDGER_NAME", objUserBL.A3); 
            param[4] = new SqlParameter("@LEDGER_TYPE", objUserBL.A4); 
            param[5] = new SqlParameter("@startRowIndex", objUserBL.A5);
            param[6] = new SqlParameter("@maximumRows", objUserBL.A6);

            param[12] = new SqlParameter("@name", objUserBL.A10); 

            param[13] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;

            param[14] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GL_LEDGER_SEARCH_SELECT", param);
            Total_Rows = Convert.ToInt32(param[13].Value.ToString()); 

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                ds.Tables.Add(dt);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet Customer_vendor_GL(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@NAME", objUserBL.A1);
            param[1] = new SqlParameter("@CODE", objUserBL.A2);
            param[2] = new SqlParameter("@LEDGER_TYPE", objUserBL.A3);
            param[3] = new SqlParameter("@startRowIndex", objUserBL.A4);
            param[4] = new SqlParameter("@maximumRows", objUserBL.A5);

            param[5] = new SqlParameter("@Mstatus", SqlDbType.Int);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@totalRows", SqlDbType.Int);
            param[7].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_CUSTOMER_VENDOR_GL_SEARCH_SELECT", param);
            Total_Rows = Convert.ToInt32(param[7].Value);
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                ds.Tables.Add(dt);
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

}