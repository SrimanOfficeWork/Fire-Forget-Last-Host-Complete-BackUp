using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class Cash_Payment_Entry_cs
{
    DataSet ds = new DataSet();

    public DataSet Cash_Payment_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[2] = new SqlParameter("@CP_ID", objUserBL.A1);  
            param[3] = new SqlParameter("@C_Ch_Id", objUserBL.A2);

            param[4] = new SqlParameter("@CP_P", objUserBL.A3);
            param[5] = new SqlParameter("@CP_NO", objUserBL.A4);
            param[6] = new SqlParameter("@CP_S", objUserBL.A5);
            param[7] = new SqlParameter("@JOB_ID", objUserBL.A6);
            param[8] = new SqlParameter("@CP_JOB_AMT", objUserBL.A7);
            param[9] = new SqlParameter("@CHARGE_NAME", objUserBL.A8);

            param[16] = new SqlParameter("@flag", objUserBL.A40); //Flag
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_CASH_PAYMENT_ENTRY_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Cash_Payment_Search(Global_variables objUserBL)
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

            SqlParameter[] param = new SqlParameter[15];
            param[2] = new SqlParameter("@from_date", objUserBL.A1);
            param[3] = new SqlParameter("@to_date", objUserBL.A2);
            param[1] = new SqlParameter("@CP_NO", objUserBL.A3);
            
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Flag", objUserBL.A40);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_CASH_PAYMENT_ENTRY_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Cash_Payment_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[43];
            param[3] = new SqlParameter("@CP_ID", objUserBL.A1);  
            param[4] = new SqlParameter("@R_O", objUserBL.A2);
            param[5] = new SqlParameter("@CP_P", objUserBL.A3);
            param[6] = new SqlParameter("@CP_NO", objUserBL.A4);
            param[7] = new SqlParameter("@CP_S", objUserBL.A5);
            if (objUserBL.A6 == null)
            {
                objUserBL.A6 = string.Empty;
            }
            param[8] = new SqlParameter("@CP_DATE", Connection.DATE_FORMAT(objUserBL.A6 == string.Empty ? "01/01/1900" : objUserBL.A6));
            if (objUserBL.A7 == null)
            {
                objUserBL.A7 = string.Empty;
            }
            param[10] = new SqlParameter("@POSTING_DATE", Connection.DATE_FORMAT(objUserBL.A7 == string.Empty ? "01/01/1900" : objUserBL.A7));

            param[11] = new SqlParameter("@CASH_AC", objUserBL.A8);
            param[12] = new SqlParameter("@PAYEE_NAME", objUserBL.A9);
            param[13] = new SqlParameter("@PAYEE_TYPE", objUserBL.A10);
            param[14] = new SqlParameter("@CP_AMT", objUserBL.A11);
            param[15] = new SqlParameter("@CP_CUR", objUserBL.A12);
            param[16] = new SqlParameter("@CP_CUR_VALUE", objUserBL.A13);
            param[17] = new SqlParameter("@CP_REF_NO", objUserBL.A14);
            if (objUserBL.A15 == null)
            {
                objUserBL.A15 = string.Empty;
            }
            param[18] = new SqlParameter("@CP_REF_DATE", Connection.DATE_FORMAT(objUserBL.A15 == string.Empty ? "01/01/1900" : objUserBL.A15));
            param[19] = new SqlParameter("@CP_NARRATION", objUserBL.A16);
            param[20] = new SqlParameter("@BANK_NAME", objUserBL.A17);
            param[21] = new SqlParameter("@ACC_NO", objUserBL.A18);

            param[33] = new SqlParameter("@JOB_LICENSE", objUserBL.A21);
            param[34] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A22);

            param[35] = new SqlParameter("@flag", objUserBL.A40);
            param[36] = new SqlParameter("@User_Name", Connection.Current_User());
            param[37] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[38] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[39] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_CASH_PAYMENT_ENTRY_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Cash_Payment_Head_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[43];
            param[3] = new SqlParameter("@CH_ID", objUserBL.A51);
            param[4] = new SqlParameter("@R_O", objUserBL.A52);
            param[5] = new SqlParameter("@CP_ID", objUserBL.A53);
            param[6] = new SqlParameter("@CP_P", objUserBL.A54);
            param[7] = new SqlParameter("@CP_NO", objUserBL.A55);
            param[8] = new SqlParameter("@CP_S", objUserBL.A56);
            param[9] = new SqlParameter("@SLNO", objUserBL.A57);
            param[10] = new SqlParameter("@IMP_EXP", objUserBL.A58);
            param[11] = new SqlParameter("@CHARGE_NAME", objUserBL.A59);
            param[12] = new SqlParameter("@TAX_NONTAX", objUserBL.A60);
            param[13] = new SqlParameter("@AMOUNT", objUserBL.A61);
            param[14] = new SqlParameter("@CR_DR", objUserBL.A62);
            param[15] = new SqlParameter("@AREA_NAME", objUserBL.A63);
            param[16] = new SqlParameter("@GROUP_ID", objUserBL.A64);
            param[17] = new SqlParameter("@AVAIL_TAX_CR", objUserBL.A65);
            param[18] = new SqlParameter("@CGST_RATE", objUserBL.A66);
            param[19] = new SqlParameter("@CGST_AMT", objUserBL.A67);
            param[20] = new SqlParameter("@SGST_RATE", objUserBL.A68);
            param[21] = new SqlParameter("@SGST_AMT", objUserBL.A69);
            param[22] = new SqlParameter("@IGST_RATE", objUserBL.A70);
            param[23] = new SqlParameter("@IGST_AMT", objUserBL.A71);
            param[24] = new SqlParameter("@CESS_RATE", objUserBL.A72);
            param[25] = new SqlParameter("@CESS_AMT", objUserBL.A73);
            param[26] = new SqlParameter("@NARRATION", objUserBL.A74);


            param[33] = new SqlParameter("@JOB_LICENSE", objUserBL.A98);
            param[34] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A99);
            param[35] = new SqlParameter("@flag", objUserBL.A100);
            param[36] = new SqlParameter("@User_Name", Connection.Current_User());
            param[37] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[38] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[39] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_CASH_PAYMENT_CH_ENTRY_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Cash_Payment_Job_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[43];
            param[2] = new SqlParameter("@J_ID", objUserBL.A101);
            param[3] = new SqlParameter("@CP_ID", objUserBL.A102);
            param[4] = new SqlParameter("@CH_ID", objUserBL.A103);

            param[5] = new SqlParameter("@R_O", objUserBL.A104);
            param[6] = new SqlParameter("@CP_P", objUserBL.A105);
            param[7] = new SqlParameter("@CP_NO", objUserBL.A106);
            param[8] = new SqlParameter("@CP_S", objUserBL.A107);
            param[9] = new SqlParameter("@IMP_EXP", objUserBL.A108);
            param[10] = new SqlParameter("@CHARGE_NAME", objUserBL.A109);
            param[11] = new SqlParameter("@JOBNO", objUserBL.A110);
            param[12] = new SqlParameter("@JOBNO_PS", objUserBL.A111);
            param[13] = new SqlParameter("@J_AMOUNT", objUserBL.A112);
            param[14] = new SqlParameter("@GROUP_ID", objUserBL.A113);

            param[33] = new SqlParameter("@JOB_LICENSE", objUserBL.A138);
            param[34] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A139);
            param[35] = new SqlParameter("@flag", objUserBL.A140);
            param[36] = new SqlParameter("@User_Name", Connection.Current_User());
            param[37] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[38] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[39] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_CASH_PAYMENT_CH_JOB_ENTRY_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Cash_Excel_Upload_Ins_Select(Global_variables objUserBL, string xmlString)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[43];
            param[1] = new SqlParameter("@CP_P", objUserBL.A1);
            param[2] = new SqlParameter("@CP_NO", objUserBL.A2);
            param[3] = new SqlParameter("@CP_S", objUserBL.A3);
            param[4] = new SqlParameter("@CHARGE_NAME", objUserBL.A4);

            param[34] = new SqlParameter("@xmlString", xmlString);
            param[35] = new SqlParameter("@flag", objUserBL.A43);
            param[36] = new SqlParameter("@User_Id", Connection.Current_User());
            param[37] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[38] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[39] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_CASH_EXCEL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

}