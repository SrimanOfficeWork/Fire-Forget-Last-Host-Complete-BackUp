using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class EXP_ReExport
{
   private string  _RE_EXPORT_ID,_SB_NO,_SB_DATE,_JOBNO,_INVOICE_SLNO,_ITEM_SLNO,_SLNO,_BE_SITE,_BE_NO,_BE_DATE,_BE_INVOICE_NO,_BE_INVOICE_ITEM_NO,_MANUAL_BE_Y_N,_BE_QTY_UTILISED,_BE_ITEM_DESC
                   ,_BE_QTY,_BE_UQC,_BE_ASS_VALUE,_BE_DUTY_PAID,_BE_DUTY_PAYMENT_DATE,_BE_OTH_IDENTIFIABLE_PARAMETER,_BE_ASS_VALUE_CLAIM,_BE_ITEM_USED_Y_N,_COMMISIONER_PERMISSION_Y_N
                   , _INPUT_CREDIT_Y_N, _PERSONAL_USED_Y_N, _MODVAT_AVAILED_Y_N, _MODVAT_REPAID_Y_N, _BRANCH_CODE, _WORKING_PERIOD, _USER_ID, _flag;

    public string RE_EXPORT_ID { get { return _RE_EXPORT_ID; } set { _RE_EXPORT_ID = value; } }
    public string SB_NO { get { return _SB_NO; } set { _SB_NO = value; } }
    public string SB_DATE { get { return _SB_DATE; } set { _SB_DATE = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string SLNO { get { return _SLNO; } set { _SLNO = value; } }
    public string BE_SITE { get { return _BE_SITE; } set { _BE_SITE = value; } }
    public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }
    public string BE_DATE { get { return _BE_DATE; } set { _BE_DATE = value; } }
    public string BE_INVOICE_NO { get { return _BE_INVOICE_NO; } set { _BE_INVOICE_NO = value; } }
    public string BE_INVOICE_ITEM_NO { get { return _BE_INVOICE_ITEM_NO; } set { _BE_INVOICE_ITEM_NO = value; } }
    public string MANUAL_BE_Y_N { get { return _MANUAL_BE_Y_N; } set { _MANUAL_BE_Y_N = value; } }
    public string BE_QTY_UTILISED { get { return _BE_QTY_UTILISED; } set { _BE_QTY_UTILISED = value; } }
    public string BE_ITEM_DESC { get { return _BE_ITEM_DESC; } set { _BE_ITEM_DESC = value; } }

    public string BE_QTY { get { return _BE_QTY; } set { _BE_QTY = value; } }
    public string BE_UQC { get { return _BE_UQC; } set { _BE_UQC = value; } }
    public string BE_ASS_VALUE { get { return _BE_ASS_VALUE; } set { _BE_ASS_VALUE = value; } }
    public string BE_DUTY_PAID { get { return _BE_DUTY_PAID; } set { _BE_DUTY_PAID = value; } }
    public string BE_DUTY_PAYMENT_DATE { get { return _BE_DUTY_PAYMENT_DATE; } set { _BE_DUTY_PAYMENT_DATE = value; } }
    public string BE_OTH_IDENTIFIABLE_PARAMETER { get { return _BE_OTH_IDENTIFIABLE_PARAMETER; } set { _BE_OTH_IDENTIFIABLE_PARAMETER = value; } }

    public string BE_ASS_VALUE_CLAIM { get { return _BE_ASS_VALUE_CLAIM; } set { _BE_ASS_VALUE_CLAIM = value; } }
    public string BE_ITEM_USED_Y_N { get { return _BE_ITEM_USED_Y_N; } set { _BE_ITEM_USED_Y_N = value; } }
    public string COMMISIONER_PERMISSION_Y_N { get { return _COMMISIONER_PERMISSION_Y_N; } set { _COMMISIONER_PERMISSION_Y_N = value; } }

    public string INPUT_CREDIT_Y_N { get { return _INPUT_CREDIT_Y_N; } set { _INPUT_CREDIT_Y_N = value; } }
    public string PERSONAL_USED_Y_N { get { return _PERSONAL_USED_Y_N; } set { _PERSONAL_USED_Y_N = value; } }
    public string MODVAT_AVAILED_Y_N { get { return _MODVAT_AVAILED_Y_N; } set { _MODVAT_AVAILED_Y_N = value; } }
    public string MODVAT_REPAID_Y_N { get { return _MODVAT_REPAID_Y_N; } set { _MODVAT_REPAID_Y_N = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }

    public int result, UPDATE_ID = 0;

    public DataSet Re_Export_Details_insertupdate()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[80];
            param[0] = new SqlParameter("@RE_EXPORT_ID", RE_EXPORT_ID);
            param[1] = new SqlParameter("@SB_NO", SB_NO);
            param[2] = new SqlParameter("@SB_DATE", Connection.DATE_FORMAT(SB_DATE == null ? "01/01/1900" : SB_DATE)); 
            param[3] = new SqlParameter("@JOBNO", JOBNO);
            
            param[4] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[5] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[6] = new SqlParameter("@SLNO", SLNO);
            param[7] = new SqlParameter("@BE_SITE", BE_SITE);
            param[8] = new SqlParameter("@BE_NO", BE_NO);
            param[9] = new SqlParameter("@BE_DATE", Connection.DATE_FORMAT(BE_DATE == null ? "01/01/1900" : BE_DATE));

            param[10] = new SqlParameter("@BE_INVOICE_NO", BE_INVOICE_NO);
            param[11] = new SqlParameter("@BE_INVOICE_ITEM_NO", BE_INVOICE_ITEM_NO);
            param[12] = new SqlParameter("@MANUAL_BE_Y_N", MANUAL_BE_Y_N);
            param[13] = new SqlParameter("@BE_QTY_UTILISED", BE_QTY_UTILISED);
            param[14] = new SqlParameter("@BE_ITEM_DESC", BE_ITEM_DESC);
            param[15] = new SqlParameter("@BE_QTY", BE_QTY);
            param[16] = new SqlParameter("@BE_UQC", BE_UQC);
            param[17] = new SqlParameter("@BE_ASS_VALUE", BE_ASS_VALUE);

            param[18] = new SqlParameter("@BE_DUTY_PAID", BE_DUTY_PAID);
            param[19] = new SqlParameter("@BE_DUTY_PAYMENT_DATE", Connection.DATE_FORMAT(BE_DUTY_PAYMENT_DATE == null ? "01/01/1900" : BE_DUTY_PAYMENT_DATE));
            param[20] = new SqlParameter("@BE_OTH_IDENTIFIABLE_PARAMETER", BE_OTH_IDENTIFIABLE_PARAMETER);

            param[22] = new SqlParameter("@BE_ASS_VALUE_CLAIM", BE_ASS_VALUE_CLAIM);
            param[23] = new SqlParameter("@BE_ITEM_USED_Y_N", BE_ITEM_USED_Y_N);
            param[24] = new SqlParameter("@COMMISIONER_PERMISSION_Y_N", COMMISIONER_PERMISSION_Y_N);
            param[25] = new SqlParameter("@INPUT_CREDIT_Y_N", INPUT_CREDIT_Y_N);
            param[26] = new SqlParameter("@PERSONAL_USED_Y_N", PERSONAL_USED_Y_N);
            param[27] = new SqlParameter("@MODVAT_AVAILED_Y_N", MODVAT_AVAILED_Y_N);
            param[28] = new SqlParameter("@MODVAT_REPAID_Y_N", MODVAT_REPAID_Y_N);

            param[29] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[30] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[31] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[32] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[33] = new SqlParameter("@Mflag", flag);

            param[34] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[34].Direction = ParameterDirection.Output;
            param[35] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[35].Direction = ParameterDirection.Output;
            param[36] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[36].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("RE_EXPORT_DETAILS_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[34].Value.ToString());

            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[36].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}