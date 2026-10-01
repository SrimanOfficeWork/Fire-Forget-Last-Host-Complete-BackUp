using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;

public class Accounts_GST_Sales_Rpt_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    Global_variables ObjUBO = new Global_variables();

    //public DataSet Select_Inv(Global_variables objUserBL)
    //{
    //    try
    //    {
    //        SqlParameter[] param = new SqlParameter[21];
    //        param[2] = new SqlParameter("@Bill_Invno", objUserBL.A1);
    //        param[3] = new SqlParameter("@Cus_Name", objUserBL.A2);
    //        param[4] = new SqlParameter("@Branch_No", objUserBL.A3);
    //        param[5] = new SqlParameter("@Jobno", objUserBL.A4);
    //        param[6] = new SqlParameter("@Trans_Mode", objUserBL.A5);
    //        param[7] = new SqlParameter("@From_Quotation", objUserBL.A6);
    //        param[8] = new SqlParameter("@Imp_Exp", objUserBL.A7);
    //        param[9] = new SqlParameter("@Mflag", objUserBL.A8);

    //        param[10] = new SqlParameter("@xmlstring_A", objUserBL.A9);
    //        param[11] = new SqlParameter("@xmlstring_B", objUserBL.A10);
    //        param[12] = new SqlParameter("@xmlstring_D", objUserBL.A11);

    //        param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
    //        param[18] = new SqlParameter("@Wrk_period", Connection.WorkingPeriod());
    //        param[19] = new SqlParameter("@Company_Lic", Connection.Company_License());

    //        param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
    //        param[20].Direction = ParameterDirection.Output;
    //        ds = Connection.Get_Dataset("GST_BILL_SALES_INV_SELECT", param);
    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }
    //    return ds;
    //}
    //public DataSet BILL_INV_SEARCH(Global_variables objUserBL)
    //{
    //    try
    //    {
    //        string[] arr = new string[] { };
    //        string[] arr2 = new string[] { };

    //        if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
    //        {
    //            arr = objUserBL.A1.Split('/');
    //            objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
    //        }
    //        if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
    //        {
    //            arr2 = objUserBL.A2.Split('/');
    //            objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
    //        }

    //        SqlParameter[] param = new SqlParameter[15];
    //        param[1] = new SqlParameter("@from_date", objUserBL.A1);
    //        param[2] = new SqlParameter("@to_date", objUserBL.A2);
    //        param[3] = new SqlParameter("@Cus_name", objUserBL.A3);
    //        param[4] = new SqlParameter("@Search_Cat", objUserBL.A4);
    //        param[5] = new SqlParameter("@Search_Item", objUserBL.A5);
    //        param[6] = new SqlParameter("@Imp_Exp", objUserBL.A6);
    //        param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
    //        param[8] = new SqlParameter("@Flag", objUserBL.A7);

    //        param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
    //        param[9].Direction = ParameterDirection.Output;

    //        ds = Connection.Get_Dataset("GST_BILL_INV_SEARCH", param);
    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }
    //    return ds;
    //}
    //public DataSet Billing_Invoice_INS_UPD(Global_variables objUserBL)
    //{
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        SqlParameter[] param = new SqlParameter[71];
    //        param[1] = new SqlParameter("@ID", objUserBL.A1);
    //        param[2] = new SqlParameter("@IMP_EXP", objUserBL.A2);
    //        param[3] = new SqlParameter("@LOCAL_OTHER", objUserBL.A3);
    //        param[4] = new SqlParameter("@CUS_NAME", objUserBL.A4);
    //        param[5] = new SqlParameter("@CUS_BRANCH_NO", objUserBL.A5);

    //        param[6] = new SqlParameter("@FROM_QUOTATION", objUserBL.A6);
    //        param[7] = new SqlParameter("@JOBNO", objUserBL.A7);
    //        param[8] = new SqlParameter("@BILL_INV_NO", objUserBL.A8);

    //        if (objUserBL.A9 == null)
    //        {
    //            objUserBL.A9 = string.Empty;
    //        }
    //        param[9] = new SqlParameter("@BILL_INV_DATE", Connection.DATE_FORMAT(objUserBL.A9 == string.Empty ? "01/01/1900" : objUserBL.A9));
    //        param[10] = new SqlParameter("@PARTY_NAME", objUserBL.A10);
    //        param[11] = new SqlParameter("@AC_BEHALF", objUserBL.A11);
    //        param[12] = new SqlParameter("@STATE_NAME", objUserBL.A12);
    //        param[13] = new SqlParameter("@GSTN_ID", objUserBL.A13);
    //        param[14] = new SqlParameter("@PARTY_ADDRESS", objUserBL.A14);

    //        param[15] = new SqlParameter("@CUS_BRANCH_NO_LOC", objUserBL.A23);
    //        param[16] = new SqlParameter("@TAX_NON_TAX", objUserBL.A24);
    //        param[17] = new SqlParameter("@BANK_DETAILS", objUserBL.A25);

    //        param[18] = new SqlParameter("@MODE", objUserBL.A26);
    //        param[19] = new SqlParameter("@SHIP_TYPE", objUserBL.A27);

    //        param[27] = new SqlParameter("@NON_TAXABLE_AMT", objUserBL.A15);
    //        param[28] = new SqlParameter("@TAXABLE_AMT", objUserBL.A16);
    //        param[29] = new SqlParameter("@TOT_REVERSE_TAX_AMT", objUserBL.A17);
    //        param[30] = new SqlParameter("@TOTAL_TAX_AMT", objUserBL.A18);
    //        param[31] = new SqlParameter("@TOTAL_AMT_TAX", objUserBL.A19);
    //        param[32] = new SqlParameter("@GRAND_TOTAL", objUserBL.A20);
    //        param[33] = new SqlParameter("@ADVANCE_AMT", objUserBL.A21);
    //        param[34] = new SqlParameter("@EXPENSE_AMT", objUserBL.A22);

    //        param[35] = new SqlParameter("@JOB_STATUS", "");
    //        param[36] = new SqlParameter("@ACC_HEAD", objUserBL.A40);
    //        param[37] = new SqlParameter("@JOB_WORKINGPERIOD", "");
    //        param[38] = new SqlParameter("@xmlString_A", objUserBL.A35);
    //        param[39] = new SqlParameter("@xmlString_B", objUserBL.A36);
    //        param[40] = new SqlParameter("@xmlString", objUserBL.A37);
    //        param[41] = new SqlParameter("@xmlString_D", objUserBL.A38);
    //        param[42] = new SqlParameter("@flag", objUserBL.A39);
    //        param[43] = new SqlParameter("@PO_NO", objUserBL.A41);
    //        param[44] = new SqlParameter("@SHIPPER_NAME", objUserBL.A42);

    //        param[66] = new SqlParameter("@USER_NAME", Connection.Current_User());
    //        param[67] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
    //        param[68] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
    //        param[69] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

    //        param[70] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
    //        param[70].Direction = ParameterDirection.Output;

    //        ds = Connection.Get_Dataset("GST_BILL_INVOICE_INS_UPD", param);
    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }

    //    return ds;
    //}
    //public DataSet Select_IMP_INV(Billing_UserBO objUserBL)
    //{
    //    try
    //    {
    //        SqlParameter[] param = new SqlParameter[25];
    //        param[0] = new SqlParameter("@Branch_No", objUserBL.Branch_No);
    //        param[1] = new SqlParameter("@Trans_Mode", objUserBL.MODE);
    //        param[2] = new SqlParameter("@Imp_Name", objUserBL.Imp_Name);
    //        param[3] = new SqlParameter("@Jobno", objUserBL.JOBNO);
    //        param[4] = new SqlParameter("@Mflag", objUserBL.Flag);
    //        param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
    //        param[6] = new SqlParameter("@Bill_invno", objUserBL.BILL_INV_NO);
    //        param[7] = new SqlParameter("@FROM_QUOTATION", objUserBL.FROM_QUOTATION);
    //        param[9] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
    //        param[10] = new SqlParameter("@J_ASS_VALUE", objUserBL.Ass_Value);
    //        param[11] = new SqlParameter("@J_CIF_VALUE", objUserBL.CIF_VALUE);
    //        param[12] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);

    //        param[13] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.JOB_WORKINGPERIOD);
    //        param[14] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);

    //        param[15] = new SqlParameter("@DEFAULT_CUR", objUserBL.DEFAULT_CUR);
    //        param[16] = new SqlParameter("@EX_RATE", objUserBL.EX_RATE);

    //        param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
    //        param[24].Direction = ParameterDirection.Output;
    //        ds = Connection.Get_Dataset("GST_BILL_IMPORT_INV_SELECT", param);
    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }
    //    return ds;
    //}
    //public DataSet Select_Imp_Exp_Data(Global_variables objUserBL)
    //{
    //    try
    //    {
    //        SqlParameter[] param = new SqlParameter[21];
    //        param[2] = new SqlParameter("@Bill_Invno", objUserBL.A1);
    //        param[3] = new SqlParameter("@Cus_Name", objUserBL.A2);
    //        param[4] = new SqlParameter("@Branch_No", objUserBL.A3);
    //        param[5] = new SqlParameter("@Jobno", objUserBL.A4);
    //        param[6] = new SqlParameter("@Trans_Mode", objUserBL.A5);
    //        param[7] = new SqlParameter("@From_Quotation", objUserBL.A6);
    //        param[8] = new SqlParameter("@Imp_Exp", objUserBL.A7);
    //        param[9] = new SqlParameter("@Mflag", objUserBL.A8);

    //        param[10] = new SqlParameter("@xmlstring_A", objUserBL.A9);
    //        param[11] = new SqlParameter("@xmlstring_B", objUserBL.A10);
    //        param[12] = new SqlParameter("@xmlstring_D", objUserBL.A11);
    //        param[13] = new SqlParameter("@Local_Other", objUserBL.A12);

    //        param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
    //        param[18] = new SqlParameter("@Wrk_period", Connection.WorkingPeriod());
    //        param[19] = new SqlParameter("@Company_Lic", Connection.Company_License());

    //        param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
    //        param[20].Direction = ParameterDirection.Output;
    //        ds = Connection.Get_Dataset(objUserBL.A15, param);
    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }
    //    return ds;
    //}
    
    //// Added for Accounts Report

    public DataSet MULTI_BILL_INV_SEARCH(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@from_date", objUserBL.A1);
            param[2] = new SqlParameter("@to_date", objUserBL.A2);
            param[3] = new SqlParameter("@Cus_name", objUserBL.A3);
            param[4] = new SqlParameter("@Search_Cat", objUserBL.A4); //Spl Condition Label Name 
            param[5] = new SqlParameter("@Search_Item", objUserBL.A5);//Spl Condition Content
            param[6] = new SqlParameter("@Imp_Exp", objUserBL.A6);
            param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[8] = new SqlParameter("@Flag", objUserBL.A7);
            //Additional Conditions Start from A11
            param[11] = new SqlParameter("@Customer_Branch", objUserBL.A11);
            param[12] = new SqlParameter("@Tax_Type", objUserBL.A12);
            param[13] = new SqlParameter("@Rpt_Type_Sub_Name", objUserBL.A13);


            param[14] = new SqlParameter("@UNAPPROVAL_APPROVED", objUserBL.A14);
            param[15] = new SqlParameter("@EXTRA1", objUserBL.A15);
            param[16] = new SqlParameter("@EXTRA2", objUserBL.A16);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            //ds = Connection.Get_Dataset("GST_BILL_INV_SEARCH", param);
            ds = Connection.Get_Dataset("ACC_SALES_RPT", param);
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

}