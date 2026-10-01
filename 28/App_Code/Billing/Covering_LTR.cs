using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Web;
using BussinessObject;


public class Covering_LTR
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    private string _flag;
    public string flag { get { return _flag; } set { _flag = value; } }

    public int result = 0, UPDATE_ID = 0;
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    public void Covering_LTR_INS_UPD(Billing_UserBO objUserBL)
    {
        try
        {
            DataSet dw = new DataSet();

            SqlParameter[] param = new SqlParameter[35];

            param[1] = new SqlParameter("@ID", objUserBL.SW_ID);
            param[2] = new SqlParameter("@COVERING_NO", objUserBL.COVERING_NO);
            param[3] = new SqlParameter("@DISPATCH_DATE", DateTime.Parse(objUserBL.DISPATCH_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[4] = new SqlParameter("@FROM_DATE", DateTime.Parse(objUserBL.From_date, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[5] = new SqlParameter("@TO_DATE", DateTime.Parse(objUserBL.Todate, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[6] = new SqlParameter("@ADD1", objUserBL.ADD1);
            param[7] = new SqlParameter("@ADD2", objUserBL.ADD2);
            param[8] = new SqlParameter("@ADD3", objUserBL.ADD3);
            param[9] = new SqlParameter("@ADD4", objUserBL.ADD4);
            param[10] = new SqlParameter("@SUBJECT", objUserBL.SUBJECT);
            param[11] = new SqlParameter("@BILL_INVOICE_NO", objUserBL.BILL_INVOICE_NO);
            param[12] = new SqlParameter("@BILL_INVOICE_DATE", objUserBL.BILL_INVOICE_DATE);
            param[13] = new SqlParameter("@BILL_REMARKS", objUserBL.BILL_REMARKS);
            param[14] = new SqlParameter("@TOTAL", objUserBL.TOTAL);
            param[23] = new SqlParameter("@TYPE", objUserBL.TYPE);
            param[24] = new SqlParameter("@PARTY_NAME", objUserBL.IMPORTER_NAME);

            param[25] = new SqlParameter("@SCFS_BILL_NO", objUserBL.SCFS_BILL_NO);
            param[26] = new SqlParameter("@ATTACHMENT", objUserBL.ATTACHMENT);
            param[27] = new SqlParameter("@SCFS_AMOUNT", objUserBL.SCFS_AMOUNT);
            param[28] = new SqlParameter("@CFS_BILLNO", objUserBL.CFS_BILLNO);
            param[29] = new SqlParameter("@PARTY_REF_NO", objUserBL.Party_Ref);
            param[30] = new SqlParameter("@PRINT_TYPE", objUserBL.BILL_TYPE);
            param[31] = new SqlParameter("@COVERING_PS", objUserBL.COVERING_PS);
            param[32] = new SqlParameter("@BILL_CFS_CHARGE", objUserBL.CFS_CHARGE);

            param[15] = new SqlParameter("@USER_ID", objUserBL.USER_ID);
            param[16] = new SqlParameter("@BRANCH_CODE", objUserBL.BRANCH_CODE);
            param[17] = new SqlParameter("@BRANCH_COMMON", objUserBL.BRANCH_COMMON);
            param[18] = new SqlParameter("@WORKING_PERIOD", objUserBL.WORKING_PERIOD);

            param[19] = new SqlParameter("@Mflag", objUserBL.flag);
            param[20] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;

            param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[21].Direction = ParameterDirection.Output;

            param[22] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[22].Direction = ParameterDirection.Output;

            dw = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GST_BILL_COVERING_LETTER_DETAILS_INS_UPD", param);
            result = Convert.ToInt32(param[20].Value.ToString());

            if (objUserBL.flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[22].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public DataSet RetrieveAll_CoveringLetter_Details(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@ID", objUserBL.SW_ID);
            param[1] = new SqlParameter("@COVERING_NO", objUserBL.COVERING_NO);
            param[2] = new SqlParameter("@TYPE", objUserBL.TYPE);
            param[3] = new SqlParameter("@BRANCH", objUserBL.BRANCH_COMMON);

            param[4] = new SqlParameter("@name", objUserBL.flag);
            param[5] = new SqlParameter("@WORKING_PERIOD", objUserBL.WORKING_PERIOD);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            if (objUserBL.flag == "select_con" || objUserBL.flag == "Bind_COVERING_LETTER_DETAILS" || objUserBL.flag == "SELECT_MAXID" || objUserBL.flag == "SELECT_PartyName_Details"  || objUserBL.flag == "SELECT_Container_Charge_details")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GST_BILL_COVERING_LETTER_SELECT", param);
                string err = param[7].Value.ToString();
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else if (objUserBL.flag == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GST_BILL_COVERING_LETTER_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
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
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Bill_Invoice_Details(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@PARTY_NAME", objUserBL.IMPORTER_NAME);
            param[2] = new SqlParameter("@TYPE", objUserBL.TYPE);
            //param[3] = new SqlParameter("@from_date", objUserBL.From_date);
            //param[4] = new SqlParameter("@to_date", objUserBL.Todate);

            //param[3] = new SqlParameter("@from_date", DateTime.Parse(objUserBL.From_date, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            //param[4] = new SqlParameter("@to_date", DateTime.Parse(objUserBL.Todate, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            if (objUserBL.From_date != string.Empty && objUserBL.From_date != null)
            {
                arr = objUserBL.From_date.Split('/');
                objUserBL.From_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.Todate != string.Empty && objUserBL.Todate != null)
            {
                arr2 = objUserBL.Todate.Split('/');
                objUserBL.Todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            param[3] = new SqlParameter("@from_date", objUserBL.From_date);
            param[4] = new SqlParameter("@to_date", objUserBL.Todate);

            param[5] = new SqlParameter("@BRANCH", objUserBL.BRANCH_CODE);
            param[6] = new SqlParameter("@name", objUserBL.flag);
            param[7] = new SqlParameter("@Working_Period", objUserBL.WORKING_PERIOD);

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            if (objUserBL.flag == "Select_All_NormalSearch" || objUserBL.flag == "Select_COVERING_LETTER_GENERAL_SEARCH" )
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GST_BILLING_COVERING_LETTER_NORMAL_SEARCH", param);
                string err = param[9].Value.ToString();
                result = Convert.ToInt32(param[8].Value.ToString());
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
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_COVERING_LETTER_GENERAL_SEARCH(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@PARTY_NAME", objUserBL.IMPORTER_NAME);
            param[2] = new SqlParameter("@TYPE", objUserBL.TYPE);
            //param[3] = new SqlParameter("@from_date", objUserBL.From_date);
            //param[4] = new SqlParameter("@to_date", objUserBL.Todate);

            //param[3] = new SqlParameter("@from_date", DateTime.Parse(objUserBL.From_date, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            //param[4] = new SqlParameter("@to_date", DateTime.Parse(objUserBL.Todate, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            if (objUserBL.From_date != string.Empty && objUserBL.From_date != null)
            {
                arr = objUserBL.From_date.Split('/');
                objUserBL.From_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.Todate != string.Empty && objUserBL.Todate != null)
            {
                arr2 = objUserBL.Todate.Split('/');
                objUserBL.Todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            param[3] = new SqlParameter("@from_date", objUserBL.From_date);
            param[4] = new SqlParameter("@to_date", objUserBL.Todate);
            param[10] = new SqlParameter("@printTYPE", objUserBL.BILL_TYPE);
            param[11] = new SqlParameter("@JOBNO", objUserBL.FILE_REF_NO);
            param[12] = new SqlParameter("@COVERING_NO", objUserBL.COVERING_NO);

            param[5] = new SqlParameter("@BRANCH", objUserBL.BRANCH_CODE);
            param[6] = new SqlParameter("@name", objUserBL.flag);
            param[7] = new SqlParameter("@Working_Period", objUserBL.WORKING_PERIOD);

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            if (objUserBL.flag == "Select_COVERING_LETTER_GENERAL_SEARCH")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GST_BILLING_COVERING_LETTER_GENERAL_SEARCH", param);
                string err = param[9].Value.ToString();
                result = Convert.ToInt32(param[8].Value.ToString());
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
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }



    public void Covering_LTR_INS_UPD_Pegasus(Billing_UserBO objUserBL)
    {
        try
        {
            DataSet dw = new DataSet();

            SqlParameter[] param = new SqlParameter[35];

            param[1] = new SqlParameter("@ID", objUserBL.SW_ID);
            param[2] = new SqlParameter("@COVERING_NO", objUserBL.COVERING_NO);
            param[3] = new SqlParameter("@DISPATCH_DATE", DateTime.Parse(objUserBL.DISPATCH_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[4] = new SqlParameter("@BILL_YOUR_REF_NO", objUserBL.BILL_INVOICE_NO);
            param[5] = new SqlParameter("@TYPE", objUserBL.TYPE);
            param[6] = new SqlParameter("@PARTY_NAME", objUserBL.IMPORTER_NAME);
            param[7] = new SqlParameter("@COVERING_PS", objUserBL.COVERING_PS);
            param[8] = new SqlParameter("@ADD1", objUserBL.ADD1);
            param[9] = new SqlParameter("@ADD2", objUserBL.ADD2);
            param[10] = new SqlParameter("@ADD3", objUserBL.ADD3);
            param[11] = new SqlParameter("@ADD4", objUserBL.ADD4);
            param[12] = new SqlParameter("@SUBJECT", objUserBL.SUBJECT);
            param[13] = new SqlParameter("@ATTACHMENT", objUserBL.ATTACHMENT);
            param[14] = new SqlParameter("@REF_NO", objUserBL.Party_Ref);
            param[23] = new SqlParameter("@ENTERED_BY", objUserBL.REMARKS);

            param[15] = new SqlParameter("@USER_ID", objUserBL.USER_ID);

            param[16] = new SqlParameter("@BRANCH_CODE", objUserBL.BRANCH_CODE);
            param[17] = new SqlParameter("@BRANCH_COMMON", objUserBL.BRANCH_COMMON);
            param[18] = new SqlParameter("@WORKING_PERIOD", objUserBL.WORKING_PERIOD);

            param[19] = new SqlParameter("@Mflag", objUserBL.flag);
            param[20] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;

            param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[21].Direction = ParameterDirection.Output;

            param[22] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[22].Direction = ParameterDirection.Output;

            dw = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GST_BILL_COVERING_LETTER_INS_UPD_PEGASUS", param);
            result = Convert.ToInt32(param[20].Value.ToString());

            if (objUserBL.flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[22].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public DataSet RetrieveAll_CoveringLetter_Details_Pegasus(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@ID", objUserBL.SW_ID);
            param[1] = new SqlParameter("@COVERING_NO", objUserBL.COVERING_NO);
            param[2] = new SqlParameter("@TYPE", objUserBL.TYPE);
            param[3] = new SqlParameter("@BRANCH", objUserBL.BRANCH_COMMON);

            param[4] = new SqlParameter("@name", objUserBL.flag);
            param[5] = new SqlParameter("@WORKING_PERIOD", objUserBL.WORKING_PERIOD);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            if (objUserBL.flag == "select_con" || objUserBL.flag == "Bind_COVERING_LETTER_DETAILS" || objUserBL.flag == "SELECT_MAXID" || objUserBL.flag == "SELECT_PartyName_Details" || objUserBL.flag == "SELECT_Container_Charge_details")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GST_BILL_COVERING_LETTER_SELECT_PEGASUS", param);
                string err = param[7].Value.ToString();
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else if (objUserBL.flag == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GST_BILL_COVERING_LETTER_SELECT_PEGASUS", param);
                result = Convert.ToInt32(param[6].Value.ToString());
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
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_COVERING_LETTER_NORMAL_SEARCH_Pegasus(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@PARTY_NAME", objUserBL.IMPORTER_NAME);
            param[2] = new SqlParameter("@TYPE", objUserBL.TYPE);
            //param[3] = new SqlParameter("@from_date", objUserBL.From_date);
            //param[4] = new SqlParameter("@to_date", objUserBL.Todate);

            //param[3] = new SqlParameter("@from_date", DateTime.Parse(objUserBL.From_date, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            //param[4] = new SqlParameter("@to_date", DateTime.Parse(objUserBL.Todate, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            if (objUserBL.From_date != string.Empty && objUserBL.From_date != null)
            {
                arr = objUserBL.From_date.Split('/');
                objUserBL.From_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.Todate != string.Empty && objUserBL.Todate != null)
            {
                arr2 = objUserBL.Todate.Split('/');
                objUserBL.Todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            param[3] = new SqlParameter("@from_date", objUserBL.From_date);
            param[4] = new SqlParameter("@to_date", objUserBL.Todate);

            param[10] = new SqlParameter("@COVERING_NO", objUserBL.COVERING_NO);
            param[11] = new SqlParameter("@BILL_YOUR_REF_NO", objUserBL.Bill_No);

            param[5] = new SqlParameter("@BRANCH", objUserBL.BRANCH_CODE);
            param[6] = new SqlParameter("@name", objUserBL.flag);
            param[7] = new SqlParameter("@Working_Period", objUserBL.WORKING_PERIOD);

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            if (objUserBL.flag == "Select_COVERING_LETTER_NORMAL_SEARCH")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GST_BILLING_COVERING_LETTER_NORMAL_SEARCH_PEGASUS", param);
                string err = param[9].Value.ToString();
                result = Convert.ToInt32(param[8].Value.ToString());
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
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }




    public void Covering_LTR_INS_UPD_Vaishnavi(Billing_UserBO objUserBL)
    {
        try
        {
            DataSet dw = new DataSet();

            SqlParameter[] param = new SqlParameter[50];

            param[1] = new SqlParameter("@ID", objUserBL.ID);
            param[2] = new SqlParameter("@TYPE", objUserBL.TYPE);
            param[3] = new SqlParameter("@BILL_NO", objUserBL.BILL_INV_NO);
            param[4] = new SqlParameter("@COVERING_REF_NO", objUserBL.REFNO);
            param[5] = new SqlParameter("@COVERING_REF_DATE", DateTime.Parse(objUserBL.DISPATCH_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[6] = new SqlParameter("@BILL_DATE", DateTime.Parse(objUserBL.BILL_INVOICE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[7] = new SqlParameter("@BILL_AMOUNT", objUserBL.BILL_REMARKS);
            param[8] = new SqlParameter("@CLIENT_NAME", objUserBL.SHIPPER_NAME);
            param[9] = new SqlParameter("@ADD1", objUserBL.ADD1);
            param[10] = new SqlParameter("@ADD2", objUserBL.ADD2);
            param[11] = new SqlParameter("@ADD3", objUserBL.ADD3);
            param[12] = new SqlParameter("@ADD4", objUserBL.ADD4);
            param[13] = new SqlParameter("@INVOICE", objUserBL.INVOICE);
            param[14] = new SqlParameter("@PACKINGLIST", objUserBL.PACKINGLIST);
            param[15] = new SqlParameter("@BILL_OF_ENTRY", objUserBL.BILL_OF_ENTRY);
            param[16] = new SqlParameter("@SHIPPING_BILL", objUserBL.SHIPPING_BILL);
            param[17] = new SqlParameter("@BILL_OF_LADING", objUserBL.BILL_OF_LADING);
            param[18] = new SqlParameter("@STPI_IMPORT", objUserBL.STPI_IMPORT);
            param[19] = new SqlParameter("@PROCUREMENT_CERT", objUserBL.PROCUREMENT_CERT);
            param[20] = new SqlParameter("@CERTIFICATE_OF_ORIGIN", objUserBL.CERTIFICATE_OF_ORIGIN);
            param[21] = new SqlParameter("@DUTY_PAID", objUserBL.DUTY_PAID);
            param[22] = new SqlParameter("@DO_RECEIPT", objUserBL.DO_RECEIPT);
            param[23] = new SqlParameter("@EDI_COUPON_RECEIPT", objUserBL.EDI_COUPON_RECEIPT);
            param[24] = new SqlParameter("@CFS_RECEIPT", objUserBL.CFS_RECEIPT);
            param[25] = new SqlParameter("@IAAI_RECEIPTNO", objUserBL.IAAI_RECEIPTNO);
            param[26] = new SqlParameter("@ESCORT_CONVEYANCE", objUserBL.ESCORT_CONVEYANCE);
            param[27] = new SqlParameter("@TRANSPORT_BILL_NO", objUserBL.TRANSPORT_BILL_NO);
            param[28] = new SqlParameter("@VEHICLE_PASS", objUserBL.VEHICLE_PASS);
            param[29] = new SqlParameter("@INSURANCE_CERTNO", objUserBL.INSURANCE_CERTNO);
            param[30] = new SqlParameter("@CE_CERTIFICATE_NO", objUserBL.CE_CERTIFICATE_NO);
            param[31] = new SqlParameter("@ANYOTHER_DOC", objUserBL.ANYOTHER_DOC);
            param[40] = new SqlParameter("@SUBJECT", objUserBL.SUBJECT);

            param[32] = new SqlParameter("@USER_ID", objUserBL.USER_ID);

            param[33] = new SqlParameter("@BRANCH_CODE", objUserBL.BRANCH_CODE);
            param[34] = new SqlParameter("@BRANCH_COMMON", objUserBL.BRANCH_COMMON);
            param[35] = new SqlParameter("@WORKING_PERIOD", objUserBL.WORKING_PERIOD);

            param[36] = new SqlParameter("@Mflag", objUserBL.flag);
            param[37] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[37].Direction = ParameterDirection.Output;

            param[38] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[38].Direction = ParameterDirection.Output;

            param[39] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[39].Direction = ParameterDirection.Output;

            dw = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GST_BILL_COVERING_LETTER_INS_UPD_VAISHNAVI", param);
            result = Convert.ToInt32(param[37].Value.ToString());

            if (objUserBL.flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[39].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public DataSet RetrieveAll_CoveringLetter_Details_Vaishnavi(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@ID", objUserBL.ID);
            param[1] = new SqlParameter("@COVERING_NO", objUserBL.COVERING_NO);
            param[2] = new SqlParameter("@TYPE", objUserBL.TYPE);
            param[3] = new SqlParameter("@BRANCH", objUserBL.BRANCH_COMMON);

            param[4] = new SqlParameter("@name", objUserBL.flag);
            param[5] = new SqlParameter("@WORKING_PERIOD", objUserBL.WORKING_PERIOD);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            if (objUserBL.flag == "select_con" || objUserBL.flag == "Bind_COVERING_LETTER_DETAILS" || objUserBL.flag == "SELECT_MAXID" || objUserBL.flag == "SELECT_PartyName_Details" || objUserBL.flag == "SELECT_BILL_NO" || objUserBL.flag=="Bind_COVERING_LETTER_DETAILS")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GST_BILL_COVERING_LETTER_SELECT_VAISHNAVI", param);
                string err = param[7].Value.ToString();
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else if (objUserBL.flag == "delete")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GST_BILL_COVERING_LETTER_SELECT_VAISHNAVI", param);
                result = Convert.ToInt32(param[6].Value.ToString());
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
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_COVERING_LETTER_NORMAL_SEARCH_Vaishnavi(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@PARTY_NAME", objUserBL.IMPORTER_NAME);
            param[2] = new SqlParameter("@TYPE", objUserBL.TYPE);
            //param[3] = new SqlParameter("@from_date", objUserBL.From_date);
            //param[4] = new SqlParameter("@to_date", objUserBL.Todate);

            //param[3] = new SqlParameter("@from_date", DateTime.Parse(objUserBL.From_date, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            //param[4] = new SqlParameter("@to_date", DateTime.Parse(objUserBL.Todate, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            if (objUserBL.From_date != string.Empty && objUserBL.From_date != null)
            {
                arr = objUserBL.From_date.Split('/');
                objUserBL.From_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.Todate != string.Empty && objUserBL.Todate != null)
            {
                arr2 = objUserBL.Todate.Split('/');
                objUserBL.Todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            param[3] = new SqlParameter("@from_date", objUserBL.From_date);
            param[4] = new SqlParameter("@to_date", objUserBL.Todate);

            param[5] = new SqlParameter("@BRANCH", objUserBL.BRANCH_CODE);
            param[6] = new SqlParameter("@name", objUserBL.flag);
            param[7] = new SqlParameter("@Working_Period", objUserBL.WORKING_PERIOD);

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            if (objUserBL.flag == "Select_COVERING_LETTER_NORMAL_SEARCH")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GST_BILLING_COVERING_LETTER_NORMAL_SEARCH_VAISHNAVI", param);
                string err = param[9].Value.ToString();
                result = Convert.ToInt32(param[8].Value.ToString());
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
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

}