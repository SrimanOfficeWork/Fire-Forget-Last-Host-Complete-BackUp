using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;

/// <summary>
/// Summary description for OCR_Pdf_Port_Master
/// </summary>
public class OCR_Pdf_Port_Master
{
	
    public DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    public string result;
    Global_variables ObjUBO = new Global_variables();

    public DataSet OCR_PDF_PORT_MASTER(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@WORKING_PERIOD", objUserBL.A1);
            param[1] = new SqlParameter("@COMPANY_LICENSE", objUserBL.A2);
            param[2] = new SqlParameter("@FLAG", objUserBL.A3);
            param[3] = new SqlParameter("@PORT_NAME", objUserBL.A4);
            param[4] = new SqlParameter("@COUNTRY_NAME", objUserBL.A5);
            param[5] = new SqlParameter("@NAME_SEARCH", objUserBL.A6);
            param[6] = new SqlParameter("@COUNTRY_CODE", objUserBL.A7);

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "OCR_SP_PORT_MASTER_FETCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

}