using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;



/// <summary>
/// Summary description for Job_Histroy
/// </summary>
public class Job_Histroy
{
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet dtuser = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    public string JOB_ID { get; set; }

    public string JOB_TYPE { get; set; }

    public string COMPANY_ID { get; set; }

    public string UPLOAD_DATE { get; set; }

    public string JOBNO { get; set; }

    public string JOBDATE { get; set; }

    public string DESCRIPTION { get; set; }

    public string ATTACHMENT_FILE { get; set; }
    public string WEB_PATHURL { get; set; }
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

    #region Retrieve
    public DataSet IMP_EXP_JOB_HISTROY_INSERT_UPDATE()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@JOB_ID", JOB_ID);
            param[1] = new SqlParameter("@JOB_TYPE", JOB_TYPE);

            param[2] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            if (UPLOAD_DATE == "" || UPLOAD_DATE == null)
            {
                UPLOAD_DATE = "01/01/1900";
            }
            //param[3] = new SqlParameter("@UPLOAD_DATE", UPLOAD_DATE);// DateTime.Parse(UPLOAD_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[3] = new SqlParameter("@UPLOAD_DATE", DateTime.Parse(UPLOAD_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[4] = new SqlParameter("@JOBNO", JOBNO);

            //if (JOBDATE == "" || JOBDATE == null)
            //{
            //    JOBDATE = "01/01/1900";
            //}

            if (JOBDATE == "" || JOBDATE == null)
            {
                JOBDATE = "01/01/1900";
            }

            param[5] = new SqlParameter("@JOBDATE", DateTime.Parse(JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[6] = new SqlParameter("@DESCRIPTION", DESCRIPTION);
            param[7] = new SqlParameter("@ATTACHMENT_FILE", ATTACHMENT_FILE);
            param[8] = new SqlParameter("@USER_ID", USER_ID);
            param[9] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[10] = new SqlParameter("@YEAR", YEAR);
            param[11] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[14] = new SqlParameter("@Mflag", FLAG);

            param[15] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[12] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@WEB_PATHURL", WEB_PATHURL);



            if (FLAG == "S" || FLAG == "U" || FLAG == "Delete" || FLAG == "Delete_Upload_File" || FLAG == "Upload_File" || FLAG == "File_Exists" || FLAG == "Upload_File_Ryal")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_EXP_JOB_HISTROY_INSERT_UPDATE", param);
                string result1 = param[13].Value.ToString();
                result = Convert.ToInt32(param[12].Value.ToString());

                // dss = SqlHelper.ExecuteDataset(Login, CommandType.StoredProcedure, "DSC_LOGIN_CHECK", param);
            }
            else if (FLAG == "select" || FLAG == "QueryReply_Insert" || FLAG == "Amendment_Insert" || FLAG =="GR_Insert")
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_EXP_JOB_HISTROY_INSERT_UPDATE", param);

            }

            else if (FLAG == "DSCFile_Upload")
            {
                param[10] = new SqlParameter("@YEAR", "DSC");
                param[14] = new SqlParameter("@Mflag", "Upload_File");
                ds = SqlHelper.ExecuteDataset(YEAR, CommandType.StoredProcedure, "IMP_EXP_JOB_HISTROY_INSERT_UPDATE", param);
                string result1 = param[13].Value.ToString();
                result = Convert.ToInt32(param[12].Value.ToString());

            }


            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return ds;

    }

    public DataSet RetrieveAll_Groups_DSC()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Company_id", COMPANY_ID);
            param[1] = new SqlParameter("@Company_license", "");
            param[2] = new SqlParameter("@IMP_EXP", YEAR);
            param[3] = new SqlParameter("@Mflag", FLAG);
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(YEAR, CommandType.StoredProcedure, "ALL_COMPANY_DETAILS_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
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
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet Job_History_Details()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Job", JOBNO);
            param[1] = new SqlParameter("@Branch", BRANCH_CODE);
            param[2] = new SqlParameter("@IMP_EXP", JOB_TYPE);
            param[3] = new SqlParameter("@Mflag", FLAG);
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("JOB_HISTORY_DETAILS_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
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

            er.makeLog(ex.Message);
        }


        return ds;

    }

    public DataSet EINVOCIE_IRN_INSERT_UPDATE_CR()
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

            ds = SqlHelper.ExecuteDataset(YEAR, CommandType.StoredProcedure, "GST_E_INVOICE_IRN_INSERT_UPDATE_CREDIT_NOTE", param);
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return ds;

    }
    #endregion
}