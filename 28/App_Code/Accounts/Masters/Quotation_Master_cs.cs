using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;

public class Quotation_Master_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet Quotation_Master_Select(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Client_Name", objUserBL.Imp_Name);
            param[2] = new SqlParameter("@MODE", objUserBL.MODE);
            param[3] = new SqlParameter("@Branch_No", objUserBL.DESTINATION);
            param[4] = new SqlParameter("@Flag", objUserBL.Flag);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Ref_ID", objUserBL.Ref_ID);
            param[7] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);
            param[8] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_QUOTATION_MASTER_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Quo_Ins_Upd(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[43];
            param[3] = new SqlParameter("@Q_ID", objUserBL.ID);
            param[4] = new SqlParameter("@Imp_Exp", objUserBL.TYPE);
            param[5] = new SqlParameter("@Tr_Mode", objUserBL.MODE);
            param[6] = new SqlParameter("@Party_Name", objUserBL.CustomerName);
            param[7] = new SqlParameter("@Branch_No", objUserBL.Branch_No);
            param[8] = new SqlParameter("@Shipment_Type", objUserBL.SHIPMENT_TYPE);

            param[17] = new SqlParameter("@flag", objUserBL.Flag);
            param[18] = new SqlParameter("@User_Name", Connection.Current_User());
            param[19] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[20] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[21] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[22] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[22].Direction = ParameterDirection.Output;
            param[23] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[23].Direction = ParameterDirection.Output;
            param[24] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[24].Direction = ParameterDirection.Output;
            
            ds = Connection.Get_Dataset("ACC_GST_QUOTATION_MASTER_PARTY_INS_UPD", param);
            result = Convert.ToInt32(param[24].Value.ToString());

            if (objUserBL.Flag == "Save")
            {
                UPDATE_ID = Convert.ToInt32(param[23].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Quo_Cha_Ins_Upd(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[81];
            param[1] = new SqlParameter("@Q_Id", objUserBL.Q_Id);
            param[2] = new SqlParameter("@IMP_EXP", objUserBL.Imp_Exp);
            param[3] = new SqlParameter("@Party_ID", objUserBL.Party_ID);
            param[4] = new SqlParameter("@TR_MODE", objUserBL.MODE);

            param[5] = new SqlParameter("@QC_Id", objUserBL.QC_Id);
            param[6] = new SqlParameter("@ORDER_BY", objUserBL.Order_by);
            param[7] = new SqlParameter("@CH_ID", objUserBL.Charge_Id);
            param[8] = new SqlParameter("@TAX_NONTAX", objUserBL.TAX_NONTAX);

            param[10] = new SqlParameter("@LCL_AMT", objUserBL.LCL_AMT);
            param[11] = new SqlParameter("@LCL_BASED_ON", objUserBL.LCL_BASED_ON);
            param[12] = new SqlParameter("@LCL_PER_VALUE", objUserBL.LCL_P);
            param[13] = new SqlParameter("@LCL_MIN_AMT", objUserBL.LCL_MIN_AMT);
            param[14] = new SqlParameter("@LCL_MAX_AMT", objUserBL.LCL_MAX_AMT);

            param[15] = new SqlParameter("@FCL_20_FT_AMT", objUserBL.FCL_20_FT_AMT);
            param[16] = new SqlParameter("@FCL_20_BASED_ON", objUserBL.FCL_20_FT_BASED_ON);
            param[17] = new SqlParameter("@FCL_20_PER_VALUE", objUserBL.FCL_20_P);
            param[18] = new SqlParameter("@FCL_20_MIN_AMT", objUserBL.FCL_20_MIN_AMT);
            param[19] = new SqlParameter("@FCL_20_MAX_AMT", objUserBL.FCL_20_MAX_AMT);

            param[20] = new SqlParameter("@FCL_40_FT_AMT", objUserBL.FCL_40_FT_AMT);
            param[21] = new SqlParameter("@FCL_40_BASED_ON", objUserBL.FCL_40_FT_BASED_ON);
            param[22] = new SqlParameter("@FCL_40_PER_VALUE", objUserBL.FCL_40_P);
            param[23] = new SqlParameter("@FCL_40_MIN_AMT", objUserBL.FCL_40_MIN_AMT);
            param[24] = new SqlParameter("@FCL_40_MAX_AMT", objUserBL.FCL_40_MAX_AMT);

            param[25] = new SqlParameter("@BOND_EX_BOND_BULK_AMT", objUserBL.BOND_AMT);
            param[26] = new SqlParameter("@BOND_EX_BOND_BULK_BASED_ON", objUserBL.BOND_BASED_ON);
            param[27] = new SqlParameter("@BOND_EX_BOND_BULK_PER_VALUE", objUserBL.BOND_P);
            param[28] = new SqlParameter("@BOND_EX_BOND_BULK_MIN_AMT", objUserBL.BOND_MIN_AMT);
            param[29] = new SqlParameter("@BOND_EX_BOND_BULK_MAX_AMT", objUserBL.BOND_MAX_AMT);

            param[30] = new SqlParameter("@AIR_AMT", objUserBL.AIR_AMT);
            param[31] = new SqlParameter("@AIR_BASED_ON", objUserBL.AIR_BASED_ON);
            param[32] = new SqlParameter("@AIR_PER_VALUE", objUserBL.AIR_P);
            param[33] = new SqlParameter("@AIR_BOND_EX_BOND_BULK", objUserBL.BOND_EX_BOND_BULK);
            param[34] = new SqlParameter("@AIR_MIN_AMT", objUserBL.AIR_MIN_AMT);
            param[35] = new SqlParameter("@AIR_MAX_AMT", objUserBL.AIR_MAX_AMT);
            
            param[73] = new SqlParameter("@flag", objUserBL.Flag);
            param[74] = new SqlParameter("@User_Name", Connection.Current_User());
            param[75] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[76] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[77] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[78] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[78].Direction = ParameterDirection.Output;
            param[79] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[79].Direction = ParameterDirection.Output;
            param[80] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[80].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_QUOTATION_MASTER_PARTY_CHARGE_INS_UPD", param);
            result = Convert.ToInt32(param[80].Value.ToString());

            if (objUserBL.Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[79].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Quo_Tr_Cha_Ins_Upd(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[31];
            param[1] = new SqlParameter("@Q_Id", objUserBL.Q_Id);
            param[2] = new SqlParameter("@IMP_EXP", objUserBL.Imp_Exp);
            param[3] = new SqlParameter("@Party_ID", objUserBL.Party_ID);
            param[4] = new SqlParameter("@TR_MODE", objUserBL.MODE);
            param[5] = new SqlParameter("@TR_ID", objUserBL.QC_Id);
            param[6] = new SqlParameter("@ORDER_BY", objUserBL.Order_by);
            param[7] = new SqlParameter("@CHARGE_NAME", objUserBL.Charge_Id);
            param[8] = new SqlParameter("@TAX_NONTAX", objUserBL.TAX_NONTAX);

            param[9] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.LCL_BASED_ON);
            param[10] = new SqlParameter("@TON_KG", objUserBL.AIR_BASED_ON);

            param[11] = new SqlParameter("@FROM", objUserBL.LCL_AMT);
            param[12] = new SqlParameter("@TO", objUserBL.FCL_20_FT_AMT);
            param[13] = new SqlParameter("@TR_AMT", objUserBL.FCL_40_FT_AMT);
            
            param[23] = new SqlParameter("@flag", objUserBL.Flag);
            param[24] = new SqlParameter("@User_Name", Connection.Current_User());
            param[25] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[26] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[27] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[28] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[28].Direction = ParameterDirection.Output;
            param[29] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[29].Direction = ParameterDirection.Output;
            param[30] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[30].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_QUOTATION_MASTER_TR_CHARGE_INS_UPD", param);
            result = Convert.ToInt32(param[30].Value.ToString());

            if (objUserBL.Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[29].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    

    public DataSet Quo_Master_Search(Billing_UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[1] = new SqlParameter("@Party_name", objUserBL.Imp_Name);
            param[2] = new SqlParameter("@Tr_Mode", objUserBL.MODE);
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_QUOTATION_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Quotation_INS_UPD(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];
            param[0] = new SqlParameter("@ID", objUserBL.ID);
            param[1] = new SqlParameter("@CLIENT_NAME", objUserBL.Imp_Name);
            param[2] = new SqlParameter("@MODE", objUserBL.MODE);
            param[3] = new SqlParameter("@xmlString",objUserBL.Xml_D);
            param[4] = new SqlParameter("@Branch_No",objUserBL.DESTINATION);
            param[5] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@User_Id", Connection.Current_User());
            param[8] = new SqlParameter("@flag", objUserBL.Flag);
            param[9] = new SqlParameter("@Ref_ID", objUserBL.Ref_ID);
            param[10] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);

            param[11] = new SqlParameter("@To_CLIENT_NAME", objUserBL.SHIPPER_NAME);
            param[12] = new SqlParameter("@To_Branch_No", objUserBL.BRANCHSLNO);

            param[14] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_QUOTATION_MASTER_INS_UPD", param);
            result = Convert.ToInt32(param[14].Value.ToString());

            if (objUserBL.Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[16].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet BILL_Quotation_Master_Search(Billing_UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Client_name", objUserBL.Imp_Name);
            param[2] = new SqlParameter("@Mode", objUserBL.MODE);
            param[3] = new SqlParameter("@from_date", objUserBL.from_date);
            param[4] = new SqlParameter("@to_date", objUserBL.todate);
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_QUOTATION_MASTER_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}