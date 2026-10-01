using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

public class Billing_E_Invoice_CS
{

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    
    public string JOB_ID { get; set; }
    public string JOB_TYPE { get; set; }
    public string COMPANY_ID { get; set; }
    public string UPLOAD_DATE { get; set; }
    public string JOBNO { get; set; }
    public string JOBDATE { get; set; }
    public string DESCRIPTION { get; set; }
    public string ATTACHMENT_FILE { get; set; }
    public string USER_ID { get; set; }
    public string DATE_TIME { get; set; }
    public string STATUS { get; set; }
    public string BRANCH_CODE { get; set; }
    public string YEAR { get; set; }
    public string WORKING_PERIOD { get; set; }
    public string FLAG { get; set; }
    public string BRANCH_COMMON { get; set; }
    public int result { get; set; }
    public string INV_No { get; set; }
    public string IRN_No { get; set; }
    public string ACK_No { get; set; }
    public string ACK_Dt { get; set; }
    public string SignedQRCodeImage { get; set; }
    public string SignedQRCode { get; set; }
    public string QRCode_ImgPath { get; set; }
    public string InvFile_Path { get; set; }
    public string QRCode_PhysicalPath { get; set; }
    public string InvFile_PhysicalPath { get; set; }

	public Billing_E_Invoice_CS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet EINVOCIE_IRN_INSERT_UPDATE()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@ENV_ID", JOB_ID);
            param[1] = new SqlParameter("@JOB_TYPE", JOB_TYPE);
            param[2] = new SqlParameter("@InvoiceNo", INV_No);
            param[3] = new SqlParameter("@IRN_No", IRN_No);
            param[4] = new SqlParameter("@AckNo", ACK_No);
            if (ACK_Dt == "" || ACK_Dt == null)
            {
                ACK_Dt = "01/01/1900";
            }

            param[5] = new SqlParameter("@AckDt", DateTime.Parse(ACK_Dt, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[6] = new SqlParameter("@SignedQRCodeImage", SignedQRCodeImage);
            param[7] = new SqlParameter("@SignedQRCode", SignedQRCode);
            param[8] = new SqlParameter("@InvStatus", STATUS);
            param[9] = new SqlParameter("@QRCode_ImgPath", QRCode_ImgPath);
            param[10] = new SqlParameter("@InvFile_Path", InvFile_Path);
            param[11] = new SqlParameter("@BranchName", BRANCH_CODE);
            param[12] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[13] = new SqlParameter("@SourceFile", DESCRIPTION);
            param[14] = new SqlParameter("@QRCode_PhysicalPath", QRCode_PhysicalPath);
            param[15] = new SqlParameter("@InvFile_PhysicalPath", InvFile_PhysicalPath);
            param[16] = new SqlParameter("@Mflag", FLAG);

            ds = SqlHelper.ExecuteDataset(YEAR, CommandType.StoredProcedure, "GST_E_INVOICE_IRN_INSERT_UPDATE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }


        return ds;

    }
    public DataSet RetrieveBranch_DSC(string servername)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Company_id", COMPANY_ID);
            param[1] = new SqlParameter("@Company_license", DESCRIPTION);
            param[2] = new SqlParameter("@IMP_EXP", JOB_TYPE);
            param[3] = new SqlParameter("@Mflag", FLAG);
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(servername, CommandType.StoredProcedure, "ALL_COMPANY_DETAILS_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Company_Details(string COMPANY_LICENSE, string WORKING_PERIOD)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);
            param[2] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[3] = new SqlParameter("@name", "Company_details");

            param[4] = new SqlParameter("@Tr_mode", "");
            param[5] = new SqlParameter("@Customs_House", "");
            param[6] = new SqlParameter("@Port_Destination", "");
            param[7] = new SqlParameter("@Port_Of_Discharge", "");

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;


            ds = SqlHelper.ExecuteDataset(Connection.Get_DSC_Con_String(COMPANY_LICENSE), CommandType.StoredProcedure, "E_LOGIX_ADMIN_DETAILS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}