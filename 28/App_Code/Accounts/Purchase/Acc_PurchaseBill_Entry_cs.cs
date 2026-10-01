using System;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;

public class Acc_PurchaseBill_Entry_cs
{
    DataSet ds = new DataSet();
    //1.SEARCH PAGE SEARCH BUTTON FUNCTION
    public DataSet Purchase_Entry_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

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

            // Search Criteria
            param[1] = new SqlParameter("@VOUCHER_FROM_DATE", objUserBL.A1);
            param[2] = new SqlParameter("@VOUCHER_TO_DATE", objUserBL.A2);
            param[3] = new SqlParameter("@ORGANISATION", objUserBL.A3);
            param[4] = new SqlParameter("@TRANS_NO", objUserBL.A4);
            param[5] = new SqlParameter("@LOCATION", objUserBL.A5);
            param[6] = new SqlParameter("@VENDOR_INV_NO", objUserBL.A6);
            param[7] = new SqlParameter("@NARRATION", objUserBL.A7);
            param[8] = new SqlParameter("@STATUS", objUserBL.A8);
            param[9] = new SqlParameter("@DISPUTE_STATUS", objUserBL.A9);
            param[10] = new SqlParameter("@MONTH", objUserBL.A10);

            // Flag
            param[11] = new SqlParameter("@Flag", objUserBL.A11);

            // Common Parameters
            param[18] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;          
            
            ds = Connection.Get_Dataset("ACC_GST_PURCHASE_LOAD_SEARCH_GRID_DATA", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    //comes from row select , PC NO GENERATION
    //1. asmx/Accounts_Auto_Search.cs 1 functions
    //2.CHARGETYPE LOAD CHARGENAMES
    //3.
    public DataSet PC_Header_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[2] = new SqlParameter("@PC_ID", objUserBL.A1);
            param[3] = new SqlParameter("@C_Ch_Id", objUserBL.A2);

            param[4] = new SqlParameter("@PC_P", objUserBL.A3);
            param[5] = new SqlParameter("@PC_NO", objUserBL.A4);
            param[6] = new SqlParameter("@PC_S", objUserBL.A5);

            param[7] = new SqlParameter("@JOB_ID", objUserBL.A6);
            param[8] = new SqlParameter("@PC_JOB_AMT", objUserBL.A7);
            param[9] = new SqlParameter("@Party_Name", objUserBL.A8);
            param[10] = new SqlParameter("@Party_Name_Type", objUserBL.A9);
            param[11] = new SqlParameter("@JOBNO", objUserBL.A10);

            param[16] = new SqlParameter("@flag", objUserBL.A40); //Flag passed here
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_PC_HEADER_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    //2.entry page save section
    public DataSet PC_Header_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[60];
            param[2] = new SqlParameter("@PC_ID", objUserBL.A1);

            param[3] = new SqlParameter("@PC_P", objUserBL.A3);
            param[4] = new SqlParameter("@PC_NO", objUserBL.A4);
            param[5] = new SqlParameter("@PC_S", objUserBL.A5);
            param[6] = new SqlParameter("@PC_DATE", Connection.DATE_FORMAT(objUserBL.A6 == string.Empty ? "01/01/1900" : objUserBL.A6));
            param[7] = new SqlParameter("@POSTING_DATE", Connection.DATE_FORMAT(objUserBL.A7 == string.Empty ? "01/01/1900" : objUserBL.A7));
            param[8] = new SqlParameter("@PC_ORGANISATION", objUserBL.A8);
            param[9] = new SqlParameter("@PC_DUE_DATE", Connection.DATE_FORMAT(objUserBL.A9 == string.Empty ? "01/01/1900" : objUserBL.A9));
            param[10] = new SqlParameter("@PC_CUR", objUserBL.A10);

            param[11] = new SqlParameter("@VENDOR_INVOICE_NO", objUserBL.A11);
            param[12] = new SqlParameter("@VENDOR_INVOICE_DATE", Connection.DATE_FORMAT(objUserBL.A12 == string.Empty ? "01/01/1900" : objUserBL.A12));
            param[13] = new SqlParameter("@PC_NARRATION", objUserBL.A13);

            param[14] = new SqlParameter("@PC_OR_BR_SLNO", objUserBL.A14);

            param[41] = new SqlParameter("@TAX_AMOUNT", objUserBL.A41);
            param[42] = new SqlParameter("@GRAND_TOTAL", objUserBL.A42);
            param[43] = new SqlParameter("@TDS_SECTION", objUserBL.A43);
            param[44] = new SqlParameter("@TDS_PERCENT", objUserBL.A44);
            param[45] = new SqlParameter("@TDS_AMOUNT", objUserBL.A45);
            param[46] = new SqlParameter("@ROUND_OFF_FLAG", objUserBL.A46);
            param[47] = new SqlParameter("@GROSS_PAYABLE", objUserBL.A47);
            param[48] = new SqlParameter("@ADVANCE_AMOUNT", objUserBL.A48);
            param[49] = new SqlParameter("@NET_PAYABLE", objUserBL.A49);
            param[50] = new SqlParameter("@ROUNDOFF_AMT", objUserBL.A50);

            param[34] = new SqlParameter("@EINVOICE_REFNO", objUserBL.A34);

            param[35] = new SqlParameter("@flag", objUserBL.A100);

            param[36] = new SqlParameter("@USER_NAME", Connection.Current_User());
            param[37] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());            
            param[39] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;           

            ds = Connection.Get_Dataset("ACC_PURCHASE_HEADER_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet PC_Entry_Head_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[43];
            param[2] = new SqlParameter("@JV_P", objUserBL.A5);
            param[3] = new SqlParameter("@JV_NO", objUserBL.A6);
            param[4] = new SqlParameter("@JV_S", objUserBL.A7);

            param[5] = new SqlParameter("@IMP_EXP", objUserBL.A51);
            param[6] = new SqlParameter("@CHARGE_NAME", objUserBL.A52);
            param[7] = new SqlParameter("@AMOUNT", objUserBL.A53);
            param[8] = new SqlParameter("@DR_CR", objUserBL.A54);
            param[09] = new SqlParameter("@LINKED_GL", objUserBL.A55);
            param[10] = new SqlParameter("@COST_CENTER", objUserBL.A56);
            param[11] = new SqlParameter("@BRANCH", objUserBL.A57);
            param[12] = new SqlParameter("@TAX_NONTAX", objUserBL.A58);
            param[13] = new SqlParameter("@TAX_AMT_PERCENT", objUserBL.A59);
            param[14] = new SqlParameter("@NARRATION", objUserBL.A60);
            param[35] = new SqlParameter("@flag", objUserBL.A100);
            param[36] = new SqlParameter("@User_Name", Connection.Current_User());
            param[39] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;

            param[41] = new SqlParameter("@XmlData", objUserBL.A101);

            ds = Connection.Get_Dataset("ACC_JOURNAL_LINE_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet PC_Line_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[42];

            param[1] = new SqlParameter("@PCL_ID", objUserBL.A1);

            param[5] = new SqlParameter("@PC_P", objUserBL.A5);
            param[6] = new SqlParameter("@PC_NO", objUserBL.A6);
            param[7] = new SqlParameter("@PC_S", objUserBL.A7);

            param[10] = new SqlParameter("@IMP_EXP", objUserBL.A10);
            param[11] = new SqlParameter("@CHARGE_NAME", objUserBL.A11);
            param[12] = new SqlParameter("@AMOUNT", objUserBL.A12);
            param[13] = new SqlParameter("@DR_CR", objUserBL.A13);
            param[14] = new SqlParameter("@LINKED_GL", objUserBL.A14);
            param[15] = new SqlParameter("@COST_CENTER", objUserBL.A15);
            param[16] = new SqlParameter("@ACC_BRANCH", objUserBL.A16);
            param[19] = new SqlParameter("@NARRATION", objUserBL.A19);

            // GST fields
            param[20] = new SqlParameter("@TAX_TYPE", objUserBL.A20);
            param[21] = new SqlParameter("@HSN_SAC_TYPE", objUserBL.A21);
            param[22] = new SqlParameter("@HSN_SAC_CODE", objUserBL.A22);

            param[23] = new SqlParameter("@CGST_RATE", objUserBL.A23);
            param[24] = new SqlParameter("@CGST_AMT", objUserBL.A24);

            param[25] = new SqlParameter("@SGST_RATE", objUserBL.A25);
            param[26] = new SqlParameter("@SGST_AMT", objUserBL.A26);

            param[27] = new SqlParameter("@IGST_RATE", objUserBL.A27);
            param[28] = new SqlParameter("@IGST_AMT", objUserBL.A28);

            param[29] = new SqlParameter("@CESS_RATE", objUserBL.A29);
            param[30] = new SqlParameter("@CESS_AMT", objUserBL.A30);

            param[31] = new SqlParameter("@AVAIL_TAX_CREDIT", objUserBL.A31);
            param[32] = new SqlParameter("@AVAIL_TAX_CREDIT_RATE", objUserBL.A32);

            // Grid XML + flag
            param[33] = new SqlParameter("@xmlString_Gen", objUserBL.A49);
            param[34] = new SqlParameter("@flag", objUserBL.A50);

            // Audit fields
            param[35] = new SqlParameter("@CREATEDBY", Connection.Current_User());
            param[36] = new SqlParameter("@MODIFIEDBY", Connection.Current_User());

            param[37] = new SqlParameter("@User_Name", Connection.Current_User());
            param[38] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[39] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());

            param[40] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[41] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[41].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_PURCHASE_LINE_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    //Comes from entry page to Details page section load
    public DataSet PC_DetailsPage_GetData(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[2] = new SqlParameter("@PC_ID", objUserBL.A1);
            param[3] = new SqlParameter("@C_Ch_Id", objUserBL.A2);

            param[4] = new SqlParameter("@PC_P", objUserBL.A3);
            param[5] = new SqlParameter("@PC_NO", objUserBL.A4);
            param[6] = new SqlParameter("@PC_S", objUserBL.A5);

            param[7] = new SqlParameter("@JOB_ID", objUserBL.A6);
            param[8] = new SqlParameter("@PC_JOB_AMT", objUserBL.A7);
            param[9] = new SqlParameter("@Party_Name", objUserBL.A8);
            param[10] = new SqlParameter("@Party_Name_Type", objUserBL.A9);
            param[11] = new SqlParameter("@JOBNO", objUserBL.A10);

            param[16] = new SqlParameter("@flag", objUserBL.A40); //Flag passed here
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_PC_HEADER_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    // Added by Tamil
    public DataSet ACC_GST_PURCHASE_RPT(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[25];


            param[0] = new SqlParameter("@PC_P", objUserBL.A1);
            param[1] = new SqlParameter("@PC_NO", objUserBL.A2);
            param[2] = new SqlParameter("@PC_S", objUserBL.A3);

            param[4] = new SqlParameter("@MFLAG", objUserBL.A25);
            param[3] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, -1);
            param[5].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_PURCHASE_RPT", param);
           
           }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }
}