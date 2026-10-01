using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;

public class DebitNote_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    
    public DataSet DebitNote_Entry_Search(Global_variables objUserBL)
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
            param[1] = new SqlParameter("@from_date", objUserBL.A1);
            param[2] = new SqlParameter("@to_date", objUserBL.A2);
            param[3] = new SqlParameter("@DEBITNOTE_NO", objUserBL.A3);
            param[4] = new SqlParameter("@VENDOR_NAME", objUserBL.A4);

            param[5] = new SqlParameter("@Flag", objUserBL.A10);
            param[13] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_DEBITNOTE_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet DebitNote_Entry_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
           
            param[1] = new SqlParameter("@D_ID", objUserBL.A1); 
            param[2] = new SqlParameter("@DEBITNOTE_NO", objUserBL.A2);
            param[3] = new SqlParameter("@VENDOR_NAME", objUserBL.A3); 
            param[4] = new SqlParameter("@VENDOR_BR_NO", objUserBL.A4);
            param[5] = new SqlParameter("@BILL_TYPE", objUserBL.A5); 
            param[6] = new SqlParameter("@DEBIT_CREDIT_AMT", objUserBL.A6);
            param[7] = new SqlParameter("@CGST_AMOUNT", objUserBL.A7);
            param[8] = new SqlParameter("@SGST_AMOUNT", objUserBL.A8); 
            param[9] = new SqlParameter("@IGST_AMOUNT", objUserBL.A9);
            param[10] = new SqlParameter("@TDS_AMOUNT", objUserBL.A10);
            param[11] = new SqlParameter("@PURCHASE_NO", objUserBL.A11);

            param[12] = new SqlParameter("@JOB_TYPE", objUserBL.A12);
            param[13] = new SqlParameter("@JOB_LICENSE", objUserBL.A13);
            param[14] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A14);
            param[15] = new SqlParameter("@JOBNO", objUserBL.A15);
            param[16] = new SqlParameter("@DC_ID", objUserBL.A16);

            param[17] = new SqlParameter("@Flag", objUserBL.A19);
            param[18] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_DEBITNOTE_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet DebitNote_Entry_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];
            param[2] = new SqlParameter("@D_ID", objUserBL.A1); 
            param[3] = new SqlParameter("@BILL_TYPE", objUserBL.A2);
            param[4] = new SqlParameter("@DEBITNOTE_NO", objUserBL.A3);
            param[5] = new SqlParameter("@DEBITNOTE_DATE", Connection.DATE_FORMAT(objUserBL.A4));

            param[6] = new SqlParameter("@VENDOR_NAME", objUserBL.A5);
            param[7] = new SqlParameter("@VENDOR_BRANCH", objUserBL.A6);
            param[8] = new SqlParameter("@VENDOR_STATE", objUserBL.A7); 
            param[9] = new SqlParameter("@GSTN_NO", objUserBL.A8); 
            param[10] = new SqlParameter("@GSTN_TYPE", objUserBL.A9);
            param[11] = new SqlParameter("@COUNTRY_CODE", objUserBL.A10); 
            param[12] = new SqlParameter("@VENDOR_BILL_NO", objUserBL.A11); 
            param[14] = new SqlParameter("@VENDOR_BILL_DATE", Connection.DATE_FORMAT(objUserBL.A12)); 
            param[15] = new SqlParameter("@BILL_AMOUNT", objUserBL.A13); 
            param[16] = new SqlParameter("@BILL_CUR", objUserBL.A14); 
            param[17] = new SqlParameter("@EX_RATE", objUserBL.A15); 
            param[18] = new SqlParameter("@AMT_IN_INR", objUserBL.A16);
            param[19] = new SqlParameter("@REMARKS", objUserBL.A17); 

            param[20] = new SqlParameter("@DEBIT_CREDIT", objUserBL.A18); 
            param[21] = new SqlParameter("@SLNO", objUserBL.A19); 
            param[23] = new SqlParameter("@C_ID", objUserBL.A20); 
            param[24] = new SqlParameter("@IMP_EXP", objUserBL.A21); 
            param[25] = new SqlParameter("@JOBNO", objUserBL.A22); 
            param[26] = new SqlParameter("@JOB_DATE", Connection.DATE_FORMAT(objUserBL.A23)); 
            param[27] = new SqlParameter("@CUS_NAME", objUserBL.A24); 
            param[28] = new SqlParameter("@CHARGE_NAME", objUserBL.A25); 
            param[29] = new SqlParameter("@TAX_RATE", objUserBL.A26); 
            param[30] = new SqlParameter("@DEBIT_CREDIT_AMT", objUserBL.A27); 
            param[31] = new SqlParameter("@TDS_RATE", objUserBL.A28); 
            param[32] = new SqlParameter("@CGST_AMOUNT", objUserBL.A29); 
            param[33] = new SqlParameter("@SGST_AMOUNT", objUserBL.A30); 
            param[34] = new SqlParameter("@IGST_AMOUNT", objUserBL.A31); 
            param[35] = new SqlParameter("@TDS_AMOUNT", objUserBL.A32); 

            param[36] = new SqlParameter("@R_O_TYPE", objUserBL.A33);
            param[37] = new SqlParameter("@JOB_LICENSE", objUserBL.A34);
            param[38] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A35);
            param[39] = new SqlParameter("@JOBNO_PS", objUserBL.A36);
            param[40] = new SqlParameter("@PURCHASE_NO", objUserBL.A37);
            param[41] = new SqlParameter("@UNDER_NAME", objUserBL.A38);

            param[42] = new SqlParameter("@Flag", objUserBL.A49); //Flag
            param[43] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[44] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[45] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[46] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());

            param[47] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[47].Direction = ParameterDirection.Output;

            param[48] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[48].Direction = ParameterDirection.Output;

            param[49] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[49].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_DEBITNOTE_INS_UPD", param);
            result = Convert.ToInt32(param[47].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
   

}