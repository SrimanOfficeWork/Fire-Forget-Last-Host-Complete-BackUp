using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;

public class PaymentEntry_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet Payment_Entry_Search(Global_variables objUserBL)
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
            param[1] = new SqlParameter("@PAYMENT_NO", objUserBL.A4);
            param[2] = new SqlParameter("@VENDOR_NAME", objUserBL.A3);
            param[3] = new SqlParameter("@from_date", objUserBL.A1);
            param[4] = new SqlParameter("@to_date", objUserBL.A2);
            param[5] = new SqlParameter("@Flag", objUserBL.A5);
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_PAYMENT_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Payment_Entry_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@P_ID", objUserBL.A1); //VOUCHER_ID
            param[2] = new SqlParameter("@PAYMENT_NO", objUserBL.A2);//VOUCHER_NO
            param[3] = new SqlParameter("@VENDOR_NAME", objUserBL.A3);//VENDOR_NAME
            param[4] = new SqlParameter("@VENDOR_BR", objUserBL.A4);//BR_CODE_LOCATION
            param[5] = new SqlParameter("@FROM_BANKNAME", objUserBL.A5);//BankName
            param[6] = new SqlParameter("@FROM_BANK_ACC_NO", objUserBL.A6);//ACCOUNT_NUMBER
            param[7] = new SqlParameter("@IMP_EXP", objUserBL.A7);
            param[8] = new SqlParameter("@JOBNO", objUserBL.A8);
            param[9] = new SqlParameter("@CHARGE_VALUE", objUserBL.A9);
            param[10] = new SqlParameter("@VENDOR_BILLNO", objUserBL.A10);

            param[17] = new SqlParameter("@Flag", objUserBL.A15); //Flag
            param[18] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_PAYMENT_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Payment_Entry_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[60];
            param[2] = new SqlParameter("@P_ID", objUserBL.A1);
            param[3] = new SqlParameter("@PAYMENT_NO", objUserBL.A2);
            param[4] = new SqlParameter("@PAYMENT_DATE", Connection.DATE_FORMAT(objUserBL.A3));
            param[5] = new SqlParameter("@PAYMENT_TYPE", objUserBL.A4);
            param[6] = new SqlParameter("@VENDOR_NAME", objUserBL.A5);
            param[7] = new SqlParameter("@VENDOR_BRANCH", objUserBL.A6);
            param[8] = new SqlParameter("@BANK_FROM", objUserBL.A7);
            param[9] = new SqlParameter("@BANK_FROM_ACC_NO", objUserBL.A8);
            param[10] = new SqlParameter("@BANK_FROM_ACC_IFSC_CODE", objUserBL.A9);
            param[11] = new SqlParameter("@PAYMENT_MODE", objUserBL.A10);
            param[12] = new SqlParameter("@PAYMENT_AMOUNT", objUserBL.A11);
            param[13] = new SqlParameter("@CHEQUE_REF_NO", objUserBL.A12);
            param[14] = new SqlParameter("@BANK_TO", objUserBL.A13);
            param[15] = new SqlParameter("@BANK_TO_ACC_NO", objUserBL.A14);
            param[16] = new SqlParameter("@BANK_TO_ACC_IFSC_CODE", objUserBL.A15);
            param[17] = new SqlParameter("@REMARKS", objUserBL.A16);

            param[20] = new SqlParameter("@C_ID", objUserBL.A20);
            param[21] = new SqlParameter("@SLNO", objUserBL.A21);
            param[22] = new SqlParameter("@IMP_EXP", objUserBL.A22);
            param[23] = new SqlParameter("@JOBNO", objUserBL.A23);
            param[24] = new SqlParameter("@JOB_DATE", Connection.DATE_FORMAT(objUserBL.A24));
            param[25] = new SqlParameter("@CUSTOMER_NAME", objUserBL.A25);
            param[26] = new SqlParameter("@PAYABLE_AMT", objUserBL.A26);
            param[27] = new SqlParameter("@WRITE_OFF_AMT", objUserBL.A27);
            param[28] = new SqlParameter("@JOB_REMARKS", objUserBL.A28);

            param[29] = new SqlParameter("@R_O_TYPE", objUserBL.A29);
            param[30] = new SqlParameter("@JOB_LICENSE", objUserBL.A30);
            param[31] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A31);
            param[32] = new SqlParameter("@JOBNO_PS", objUserBL.A32);
            param[33] = new SqlParameter("@CHARGE_VALUE", objUserBL.A33);
            param[34] = new SqlParameter("@BILL_TYPE", objUserBL.A34);
            param[35] = new SqlParameter("@VENDOR_BILL_NO", objUserBL.A35);
            

            param[52] = new SqlParameter("@Flag", objUserBL.A60);
            param[53] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[54] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[55] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[56] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());

            param[57] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[57].Direction = ParameterDirection.Output;

            param[58] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[58].Direction = ParameterDirection.Output;

            param[59] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[59].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_PAYMENT_INS_UPD", param);
            result = Convert.ToInt32(param[57].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}