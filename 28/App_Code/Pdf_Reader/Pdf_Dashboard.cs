using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;


public class Pdf_Dashboard
{
    public DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    public string result;
    Global_variables ObjUBO = new Global_variables();

    public DataSet OCR_Dashboard_DATA_Fetch(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();

        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@WORKING_PERIOD", objUserBL.A1);
            param[1] = new SqlParameter("@COMPANY_LICENSE", objUserBL.A2);
            param[2] = new SqlParameter("@IMP_EXP_NAME", objUserBL.A3);
            param[3] = new SqlParameter("@FROM_DATE",string.IsNullOrWhiteSpace(objUserBL.A4)? (object)DBNull.Value: Convert.ToDateTime(objUserBL.A4));
            param[4] = new SqlParameter("@TO_DATE",string.IsNullOrWhiteSpace(objUserBL.A5)? (object)DBNull.Value: Convert.ToDateTime(objUserBL.A5));
            param[5] = new SqlParameter("@PDF_NAME", objUserBL.A6);
            param[6] = new SqlParameter("@Mflag", objUserBL.A7);

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "OCR_GET_COMBINED_DASHBOARD_DATA", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet OCR_Dashboard_Company_Details_List(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();

        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@WORKING_PERIOD", objUserBL.A1);
            param[1] = new SqlParameter("@COMPANY_LICENSE", objUserBL.A2);
            param[2] = new SqlParameter("@IMP_EXP_NAME", objUserBL.A3);
            param[3] = new SqlParameter("@FROM_DATE", string.IsNullOrWhiteSpace(objUserBL.A4) ? (object)DBNull.Value : Convert.ToDateTime(objUserBL.A4));
            param[4] = new SqlParameter("@TO_DATE", string.IsNullOrWhiteSpace(objUserBL.A5) ? (object)DBNull.Value : Convert.ToDateTime(objUserBL.A5));
            param[5] = new SqlParameter("@PDF_NAME", objUserBL.A6);
            param[6] = new SqlParameter("@Mflag", objUserBL.A7);

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "OCR_GET_COMBINED_DASHBOARD_DATA", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }
}