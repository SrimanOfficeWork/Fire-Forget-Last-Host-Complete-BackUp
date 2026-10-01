using System;
using System.Web;
using System.Data;
using BussinessObject;
using System.Data.SqlClient;
using System.Collections.Generic;

public class SB_BE_Status_Tracking
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet BE_Status_tracking_Ins_up(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[70];

            param[1] = new SqlParameter("@JOBNO", objUserBL.A1);
            param[2] = new SqlParameter("@JobNo_PS", objUserBL.A2);
            param[3] = new SqlParameter("@LOCATION", objUserBL.A3);
            param[4] = new SqlParameter("@BILL_OF_ENTRY_NO", objUserBL.A4);
            param[5] = new SqlParameter("@BILL_OF_ENTRY_DATE", objUserBL.A5);
            param[6] = new SqlParameter("@IEC", objUserBL.A6);
            param[7] = new SqlParameter("@TOT_VAL", objUserBL.A7);
            param[8] = new SqlParameter("@TYP", objUserBL.A8);
            param[9] = new SqlParameter("@CHA_Number", objUserBL.A9);
            param[10] = new SqlParameter("@FIRST_CHECK", objUserBL.A10);
            param[11] = new SqlParameter("@PRIOR_BE", objUserBL.A11);
            param[12] = new SqlParameter("@SEC48", objUserBL.A12);
            param[13] = new SqlParameter("@APPRAISING_GROUP", objUserBL.A13);
            param[14] = new SqlParameter("@TOTAL_ASSESSABLE_VALUE", objUserBL.A14);
            param[15] = new SqlParameter("@TOTAL_PACKAGE", objUserBL.A15);
            param[16] = new SqlParameter("@GROSS_WEIGHT_Kg", objUserBL.A16);
            param[17] = new SqlParameter("@TOTAL_DUTY_INR", objUserBL.A17);
            param[18] = new SqlParameter("@FINE_PENALTY_INR", objUserBL.A18);
            param[19] = new SqlParameter("@WBE_No", objUserBL.A19);
            param[20] = new SqlParameter("@APPRAISEMENT", objUserBL.A20);
            param[21] = new SqlParameter("@CURRENT_QUEUE", objUserBL.A21);
            param[22] = new SqlParameter("@NO_OF_QUERY_RAISED", objUserBL.A22);
            param[23] = new SqlParameter("@NO_OF_QUERY_REPLIED", objUserBL.A23);
            param[24] = new SqlParameter("@REPLY_DATE", objUserBL.A24);
            param[25] = new SqlParameter("@REPLY_STATUS", objUserBL.A25);
            param[26] = new SqlParameter("@APPR_DATE", objUserBL.A26);
            param[27] = new SqlParameter("@ASSESS_DATE", objUserBL.A27);
            param[28] = new SqlParameter("@PAYMENT_DATE", objUserBL.A28);
            param[29] = new SqlParameter("@EXAM_DATE", objUserBL.A29);
            param[30] = new SqlParameter("@OOC_DATE", objUserBL.A30);
            param[31] = new SqlParameter("@CHALLAN_No", objUserBL.A31);
            param[32] = new SqlParameter("@DUTY_AMOUNT_INR", objUserBL.A32);
            param[33] = new SqlParameter("@FINE_AMOUNT_INR", objUserBL.A33);
            param[34] = new SqlParameter("@INTEREST_AMOUNT_INR", objUserBL.A34);
            param[35] = new SqlParameter("@PENAL_AMOUNT_INR", objUserBL.A35);
            param[36] = new SqlParameter("@DUTY_PAID_INR", objUserBL.A36);
            param[37] = new SqlParameter("@MODE_OF_PAYMENT", objUserBL.A37);
            param[38] = new SqlParameter("@USER_ID", Connection.Current_User());
            
            param[39] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[40] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[41] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[42] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[43] = new SqlParameter("@MFLAG", objUserBL.A52);
            param[44] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[44].Direction = ParameterDirection.Output;
            param[45] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[45].Direction = ParameterDirection.Output;
            param[46] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[46].Direction = ParameterDirection.Output;
            param[47] = new SqlParameter("@JOB_DATE", objUserBL.A38);

            ds = Connection.Get_Dataset("BE_STATUS_TRACKING_INS_UPD_DEL", param);
        }
            catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet SB_Status_tracking_Ins_up(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[70];

            param[1] = new SqlParameter("@JOBNO", objUserBL.A1);
            param[2] = new SqlParameter("@JobNo_PS", objUserBL.A2);
            param[3] = new SqlParameter("@LOCATION", objUserBL.A3);
            param[4] = new SqlParameter("@SHIPPING_BILL_NO", objUserBL.A4);
            param[5] = new SqlParameter("@SHIPPING_BILL_DATE", objUserBL.A5);
            param[6] = new SqlParameter("@IEC", objUserBL.A6);
            param[7] = new SqlParameter("@CHA_No", objUserBL.A7);
            param[8] = new SqlParameter("@Port_of_Discharge", objUserBL.A8);
            param[9] = new SqlParameter("@Total_Package", objUserBL.A9);
            param[10] = new SqlParameter("@Gross_Weight_Kg", objUserBL.A10);
            param[11] = new SqlParameter("@FOB_INR", objUserBL.A11);
            param[12] = new SqlParameter("@Total_Cess_INR", objUserBL.A12);
            param[13] = new SqlParameter("@Drawback", objUserBL.A13);
            param[14] = new SqlParameter("@STR", objUserBL.A14);
            param[15] = new SqlParameter("@Total_DBK_STR", objUserBL.A15);
            param[16] = new SqlParameter("@CIN_NO", objUserBL.A16);
            param[17] = new SqlParameter("@CIN_DT", objUserBL.A17);
            param[18] = new SqlParameter("@Invoice_Number", objUserBL.A18);
            param[19] = new SqlParameter("@Item_Number", objUserBL.A19);
            param[20] = new SqlParameter("@Reward_Flag_INV", objUserBL.A20);
            param[21] = new SqlParameter("@Current_Que", objUserBL.A21);
            param[22] = new SqlParameter("@LEO_Date", objUserBL.A22);
            param[23] = new SqlParameter("@EP_Copy_Print_Status", objUserBL.A23);
            param[24] = new SqlParameter("@DBK_Scroll_No", objUserBL.A24);
            param[25] = new SqlParameter("@Scroll_Date", objUserBL.A25);
            param[26] = new SqlParameter("@EGM_Integration_Status", objUserBL.A26);
            param[27] = new SqlParameter("@EGM_No", objUserBL.A27);
            param[28] = new SqlParameter("@EGM_Date", objUserBL.A28);
            param[29] = new SqlParameter("@Container_No", objUserBL.A29);
            param[30] = new SqlParameter("@Seal_No", objUserBL.A30);
            param[31] = new SqlParameter("@Error_Message", objUserBL.A31);
            param[32] = new SqlParameter("@Query_No", objUserBL.A32);
            param[33] = new SqlParameter("@Query_Date", objUserBL.A33);
            param[34] = new SqlParameter("@Query_Text", objUserBL.A34);
            param[35] = new SqlParameter("@Pending_With", objUserBL.A35);
            param[36] = new SqlParameter("@Officer_Name", objUserBL.A36);
            param[37] = new SqlParameter("@Reply_Date", objUserBL.A37);
            param[38] = new SqlParameter("@ROSL_Availed", objUserBL.A38);
            param[39] = new SqlParameter("@Amount_INR", objUserBL.A39);
            param[40] = new SqlParameter("@ROSL_Scroll_Number", objUserBL.A40);
            param[41] = new SqlParameter("@ROSL_Scroll_Date", objUserBL.A41);
            param[42] = new SqlParameter("@CHALLAN_No", objUserBL.A42);
            param[43] = new SqlParameter("@DUTY_AMOUNT_INR", objUserBL.A43);
            param[44] = new SqlParameter("@CESS_AMOUNT_INR", objUserBL.A44);
            param[45] = new SqlParameter("@TOTAL_DUTY_INR", objUserBL.A45);
            param[46] = new SqlParameter("@DUTY_PAID_INR", objUserBL.A46);
            param[47] = new SqlParameter("@MODE_OF_PAYMENT", objUserBL.A47);


            param[48] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[49] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[50] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[51] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[52] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[53] = new SqlParameter("@MFLAG", objUserBL.A52);
            param[54] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[54].Direction = ParameterDirection.Output;
            param[55] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[55].Direction = ParameterDirection.Output;
            param[56] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[56].Direction = ParameterDirection.Output;
            param[57] = new SqlParameter("@JOB_DATE", objUserBL.A48);

            ds = Connection.Get_Dataset("SB_STATUS_TRACKING_INS_UPD_DEL", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

   
}







