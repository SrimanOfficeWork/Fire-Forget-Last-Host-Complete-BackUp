using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;

public class Exp_DTA
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    public string Xml_A;

    public DataSet DTA_Data_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@JOBID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[7] = new SqlParameter("@INVOICE_SLNO", objUserBL.A3);
            param[8] = new SqlParameter("@ITEM_SLNO", objUserBL.A4);

            param[3] = new SqlParameter("@Flag", objUserBL.A10);
            param[4] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
       
            ds = Connection.Get_Dataset("EXPORT_DTA_SEZ_DETAILS_SELECT", param);
            result = Convert.ToInt32(param[6].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Export_DTA_GENERAL_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];
            param[1] = new SqlParameter("@JOBID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
           
            //if (objUserBL.A3 == "" || objUserBL.A4 == null)
            //{
            //    objUserBL.A3 = "01/01/1900";
            //}
            //param[3] = new SqlParameter("@JOBDATE", Connection.DATE_FORMAT(objUserBL.A3));
            //param[36] = new SqlParameter("@JOBNO_PS", Connection.DATE_FORMAT(objUserBL.A31));

            param[3] = new SqlParameter("@SEZ_UNIT_CODE", objUserBL.A3);
            param[4] = new SqlParameter("@SEZ_UNIT_NAME", objUserBL.A4);
            param[5] = new SqlParameter("@SEZ_UNIT_ADDRESS", objUserBL.A5);
            param[6] = new SqlParameter("@SEZ_UNIT_CITY", objUserBL.A6);
            param[7] = new SqlParameter("@SEZ_UNIT_STATE", objUserBL.A7);
            param[8] = new SqlParameter("@SEZ_UNIT_PINCODE", objUserBL.A8);
            param[9] = new SqlParameter("@SEZ_UNIT_IEC", objUserBL.A9);
            param[10] = new SqlParameter("@SEZ_UNIT_GSTIN", objUserBL.A10);
          
            param[11] = new SqlParameter("@DTA_UNIT_GSTIN", objUserBL.A11);
            param[12] = new SqlParameter("@DTA_UNIT_PAN", objUserBL.A12);
            param[13] = new SqlParameter("@DTA_UNIT_NAME", objUserBL.A13);
            param[14] = new SqlParameter("@DTA_UNIT_ADDRESS", objUserBL.A14);
            param[15] = new SqlParameter("@DTA_UNIT_CITY", objUserBL.A15);
            param[16] = new SqlParameter("@DTA_UNIT_STATE", objUserBL.A16);
            param[17] = new SqlParameter("@DTA_UNIT_PINCODE", objUserBL.A17);
            param[18] = new SqlParameter("@DTA_UNIT_IEC_CODE", objUserBL.A18);
            param[19] = new SqlParameter("@DTA_UNIT_TYPE", objUserBL.A19);

            param[20] = new SqlParameter("@IGST_DECLARATION", objUserBL.A20);
            param[21] = new SqlParameter("@LUT_NUMBER", objUserBL.A21);
            param[22] = new SqlParameter("@LUT_DATE", Connection.DATE_FORMAT(objUserBL.A22));

            param[23] = new SqlParameter("@ARE_YN", objUserBL.A23);
            param[24] = new SqlParameter("@ARE_NUMBER", objUserBL.A24);
            param[25] = new SqlParameter("@ARE_DATE", Connection.DATE_FORMAT(objUserBL.A25));
            param[26] = new SqlParameter("@ARE_RANGE", objUserBL.A26);
            param[27] = new SqlParameter("@ARE_DIVISION", objUserBL.A27);
            param[28] = new SqlParameter("@ARE_ADDRESS", objUserBL.A28);
            param[29] = new SqlParameter("@ARE_COMMISSIONERATE", objUserBL.A29);
            param[30] = new SqlParameter("@ARE_DUTY_AMOUNT", objUserBL.A30);
            param[31] = new SqlParameter("@CENVAT_YN", objUserBL.A31);
            param[32] = new SqlParameter("@CENTRAL_EXCISE_41", objUserBL.A32);
            param[33] = new SqlParameter("@CENTRAL_EXCISE_43", objUserBL.A33);
            param[34] = new SqlParameter("@ADDL_REMARKS", objUserBL.A34);

            param[35] = new SqlParameter("@USERID", Connection.Current_User());
            param[36] = new SqlParameter("@Flag", objUserBL.A35);
            param[37] = new SqlParameter("@BRANCHCODE", Connection.Current_Branch());
            param[38] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[39] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[39].Direction = ParameterDirection.Output;
            param[40] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[40].Direction = ParameterDirection.Output;
            param[41] = new SqlParameter("@UpdateID", SqlDbType.Int, 1);
            param[41].Direction = ParameterDirection.Output;
       
            ds = Connection.Get_Dataset("EXPORT_DTA_SEZ_GENERAL_INS_UPD", param);

            result = Convert.ToInt32(param[40].Value.ToString());

            if (objUserBL.A35 == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[41].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Export_DTA_ITEMS_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[40];
            param[1] = new SqlParameter("@ITEM_ID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[3] = new SqlParameter("@INVOICE_SLNO", objUserBL.A3);
            param[4] = new SqlParameter("@ITEM_SLNO", objUserBL.A4);
            param[5] = new SqlParameter("@REBATE_CLAIMED_AMOUNT", objUserBL.A5);
            param[6] = new SqlParameter("@ITEM_TYPE", objUserBL.A6);
            param[7] = new SqlParameter("@IGST_NOTN_NO", objUserBL.A7);
            param[8] = new SqlParameter("@IGST_NOTN_SLNO", objUserBL.A8);
            //param[9] = new SqlParameter("@GST_EXEMPT_YN", objUserBL.A9);
            param[10] = new SqlParameter("@COMPENSATION_CESS_NOTN", objUserBL.A10);
            param[11] = new SqlParameter("@COMPENSATION_CESS_NOTN_SLNO", objUserBL.A11);
            param[12] = new SqlParameter("@CESS_RATE", objUserBL.A12);
            param[13] = new SqlParameter("@CESS_AMOUNT", objUserBL.A13);
            param[14] = new SqlParameter("@JOBNO_PS", objUserBL.A14);
           
            param[38] = new SqlParameter("@USERID", Connection.Current_User());
            param[34] = new SqlParameter("@Flag", objUserBL.A20);
            param[35] = new SqlParameter("@BRANCHCODE", Connection.Current_Branch());
            param[37] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[21].Direction = ParameterDirection.Output;
            param[22] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[22].Direction = ParameterDirection.Output;
            param[23] = new SqlParameter("@UpdateID", SqlDbType.Int, 1);
            param[23].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("EXPORT_DTA_SEZ_ITEMS_INS_UPD", param);

            result = Convert.ToInt32(param[22].Value.ToString());

            if (objUserBL.A20 == "S")
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

    public DataSet Export_DTA_INVOICE_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[40];
            param[1] = new SqlParameter("@DTA_INV_ID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[3] = new SqlParameter("@INVOICE_SLNO", objUserBL.A3);
            param[4] = new SqlParameter("@INVOICE_VALUE", objUserBL.A4);
            param[5] = new SqlParameter("@INVOICE_VALUE_INR", objUserBL.A5);
            param[6] = new SqlParameter("@NATURE_OF_SUPPLY", objUserBL.A6);
            param[7] = new SqlParameter("@NATURE_OF_TRANSACTION", objUserBL.A7);
            param[8] = new SqlParameter("@TOT_IGST_AMOUNT", objUserBL.A8);
            param[9] = new SqlParameter("@TOT_CESS_AMOUNT", objUserBL.A9);
            param[10] = new SqlParameter("@DUTY_AMT_AS_PER_ARE", objUserBL.A10);
            param[12] = new SqlParameter("@JOBNO_PS", objUserBL.A12);

            param[15] = new SqlParameter("@USERID", Connection.Current_User());
            param[16] = new SqlParameter("@Flag", objUserBL.A16);
            param[17] = new SqlParameter("@BRANCHCODE", Connection.Current_Branch());
            param[18] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            param[20] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;
            param[21] = new SqlParameter("@UpdateID", SqlDbType.Int, 1);
            param[21].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("EXPORT_DTA_SEZ_INVOICE_INS_UPD", param);

            result = Convert.ToInt32(param[20].Value.ToString());

            if (objUserBL.A16 == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[21].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}