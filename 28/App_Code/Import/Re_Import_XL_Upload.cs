using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class Re_Import_XL_Upload
{
    public int result, UPDATE_ID = 0;
    DataSet Re_ds = new DataSet();

    public DataSet Re_Import_XL(Transaction RE_IMP_XL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];
            param[0] = new SqlParameter("@RE_IMPORT_ID", RE_IMP_XL.RE_IMPORT_ID);
            param[25] = new SqlParameter("@RE_IMPORT_SLNO", RE_IMP_XL.RE_IMPORT_SLNO);
            param[1] = new SqlParameter("@JOBNO", RE_IMP_XL.JOBNO);
            param[20] = new SqlParameter("@ITEM_SLNO", RE_IMP_XL.ITEM_SLNO);
            param[21] = new SqlParameter("@INVOICE_SLNO", RE_IMP_XL.INVOICE_SLNO);
            param[22] = new SqlParameter("@INVOICE_NO", RE_IMP_XL.INVOICE_NO);
            param[2] = new SqlParameter("@SB_NO", RE_IMP_XL.SB_NO);
            param[3] = new SqlParameter("@SB_DATE", Connection.DATE_FORMAT(RE_IMP_XL.SB_DATE == null ? "01/01/1900" : RE_IMP_XL.SB_DATE));
            param[4] = new SqlParameter("@PORT_EXPORT", RE_IMP_XL.PORT_EXPORT);
            param[5] = new SqlParameter("@SB_INVOICE_NO", RE_IMP_XL.SB_INVOICE_NO);
            param[6] = new SqlParameter("@SB_INVOICE__ITEM_NO", RE_IMP_XL.SB_INVOICE__ITEM_NO);
            param[7] = new SqlParameter("@NOTN_NO", RE_IMP_XL.NOTN_NO);
            param[8] = new SqlParameter("@NOTN_SLNO", RE_IMP_XL.NOTN_SLNO);
            param[9] = new SqlParameter("@EXPORT_FREIGHT", RE_IMP_XL.EXPORT_FREIGHT);
            param[10] = new SqlParameter("@EXPORT_INSURANCE", RE_IMP_XL.EXPORT_INSURANCE);
            param[11] = new SqlParameter("@CUSTOMS_DUTY", RE_IMP_XL.CUSTOMS_DUTY);
            param[12] = new SqlParameter("@USER_ID", RE_IMP_XL.USER_ID);
            param[13] = new SqlParameter("@BRANCH_CODE", RE_IMP_XL.BRANCH_CODE);
            param[14] = new SqlParameter("@EXCISE_DUTY", RE_IMP_XL.EXCISE_DUTY);
            param[15] = new SqlParameter("@YEAR", RE_IMP_XL.YEAR);
            param[16] = new SqlParameter("@WORKING_PERIOD", RE_IMP_XL.WORKING_PERIOD);
            param[24] = new SqlParameter("@BRANCH_COMMON", RE_IMP_XL.BRANCH_COMMON);
            param[17] = new SqlParameter("@Mflag", RE_IMP_XL.flag);
            param[18] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            param[23] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[23].Direction = ParameterDirection.Output;
            if (RE_IMP_XL.flag == "autoid" || (RE_IMP_XL.flag == "Check_Avail") || (RE_IMP_XL.flag == "Excel_Avail") || (RE_IMP_XL.flag == "Delete_Excel" || RE_IMP_XL.flag == "Data_Check"))
            {
                Re_ds = Connection.Get_Dataset("SP_RE_IMPORT_XL_UPLOAD", param);

                if (!String.IsNullOrEmpty(param[18].Value.ToString()))
                {
                    result = Convert.ToInt32(param[18].Value.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return Re_ds;
    }
}