using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Text;
using System.Linq;

public class DO_Entry
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet DO_ENTRY_SELECT(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", objUserBL.A1);
            param[1] = new SqlParameter("@DO_ID", objUserBL.A2);
            param[2] = new SqlParameter("@Cus_Name", objUserBL.A3);
            param[3] = new SqlParameter("@Flag", objUserBL.A4);
            param[4] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@Company_ID", Connection.COMPANYID());
           // param[6] = new SqlParameter("@Trans_Mode", objUserBL.A5);
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("DO_ENTRY_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet CFS_ENTRY_SELECT(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", objUserBL.A1);
            param[1] = new SqlParameter("@CFS_ID", objUserBL.A2);
            param[2] = new SqlParameter("@Cus_Name", objUserBL.A3);
            param[3] = new SqlParameter("@Flag", objUserBL.A4);
            param[4] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@Company_ID", Connection.COMPANYID());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("CFS_ENTRY_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet AAI_ENTRY_SELECT(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", objUserBL.A1);
            param[1] = new SqlParameter("@AAI_ID", objUserBL.A2);
            param[2] = new SqlParameter("@Cus_Name", objUserBL.A3);
            param[3] = new SqlParameter("@Flag", objUserBL.A4);
            param[4] = new SqlParameter("@BRANCH_COMMON", Connection.Current_Branch());
            param[5] = new SqlParameter("@Company_ID", Connection.COMPANYID());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("AAI_ENTRY_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet XLUpload(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@xmlString", objUserBL.A1);
            param[2] = new SqlParameter("@Flag", objUserBL.A2);
            param[3] = new SqlParameter("@User_Id", Connection.Current_User());
            param[4] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Company_ID", Connection.COMPANYID());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("IMP_DSR_XL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void DO_INS_UPD(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[150];

            param[0] = new SqlParameter("@DO_ID", objUserBL.A1);
            param[1] = new SqlParameter("@CUSTOMER_NAME", objUserBL.A2);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A3);
            param[3] = new SqlParameter("@MANUAL_JOBNO", objUserBL.A4);
            param[4] = new SqlParameter("@MBL_NO", objUserBL.A5);
            param[5] = new SqlParameter("@HBL_NO", objUserBL.A6);
            param[6] = new SqlParameter("@NO_OF_PKG", objUserBL.A7);
            param[7] = new SqlParameter("@LCL_FCL_AIR", objUserBL.A8);
            param[8] = new SqlParameter("@TWENTY_FEET_CNT", objUserBL.A9);
            param[9] = new SqlParameter("@FORTY_FEET_CNT", objUserBL.A10);
            //param[10] = new SqlParameter("@BRANCH_SL_NO", objUserBL.A11);
            param[11] = new SqlParameter("@GROSS_WGT", objUserBL.A11);
            param[12] = new SqlParameter("@NET_WGT", objUserBL.A12);
            param[13] = new SqlParameter("@Tax_Invoice_No", objUserBL.A13);
            param[14] = new SqlParameter("@Line_Charge", objUserBL.A14);
            param[15] = new SqlParameter("@Consol_charges", objUserBL.A15);
            param[16] = new SqlParameter("@Port_Storage_Amt", objUserBL.A16);
            param[17] = new SqlParameter("@Detention_Amt", objUserBL.A17);
            param[18] = new SqlParameter("@Damage_Charges", objUserBL.A18);
            param[19] = new SqlParameter("@UTR_No", objUserBL.A19);
            //param[20] = new SqlParameter("@UTR_Date", Connection.DATE_FORMAT(objUserBL.A20));
            param[20] = new SqlParameter("@UTR_Date", objUserBL.A20);
            param[21] = new SqlParameter("@UTR_Amt", objUserBL.A21);
            param[22] = new SqlParameter("@Holding_chq_No", objUserBL.A22);
            //param[23] = new SqlParameter("@Holding_Chq_date", Connection.DATE_FORMAT(objUserBL.A23));
            param[23] = new SqlParameter("@Holding_Chq_date", objUserBL.A23);
            param[24] = new SqlParameter("@Remarks", objUserBL.A24);

            // param[35] = new SqlParameter("@Consignee_name", objUserBL.A27);
            param[36] = new SqlParameter("@Late_do_fee", objUserBL.A28);
            param[38] = new SqlParameter("@Port_do_Revalidition", objUserBL.A29);
            param[39] = new SqlParameter("@Detention_do_Revalidition", objUserBL.A30);
            param[40] = new SqlParameter("@Holding_Amt", objUserBL.A31);
            param[41] = new SqlParameter("@Liner_name", objUserBL.A32);
            param[42] = new SqlParameter("@Consol_Name", objUserBL.A33);
            param[43] = new SqlParameter("@Holding_chq_return_date", objUserBL.A34);
            param[44] = new SqlParameter("@DO_Free_days", objUserBL.A36);
            param[45] = new SqlParameter("@Tax_Invoice_Date", objUserBL.A37);
            param[46] = new SqlParameter("@Tax_Invoice_Amount", objUserBL.A38);
            param[47] = new SqlParameter("@Holding_Received_Date", objUserBL.A39);

            param[48] = new SqlParameter("@Do_Applied_date", objUserBL.A40);
            param[49] = new SqlParameter("@Do_Received_date", objUserBL.A41);
            param[50] = new SqlParameter("@ETA", objUserBL.A50);

            param[25] = new SqlParameter("@Flag", objUserBL.A25);
            param[26] = new SqlParameter("@REF_ID", objUserBL.A26);
            param[27] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[28] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[29] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[30] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[31] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[31].Direction = ParameterDirection.Output;
            param[33] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[33].Direction = ParameterDirection.Output;
            param[34] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[34].Direction = ParameterDirection.Output;
            param[35] = new SqlParameter("@Consignee_name", objUserBL.A27);
            //param[37] = new SqlParameter("@Entry_Type", objUserBL.A35);
            Connection.Get_Dataset("DO_INS_UPD", param);

            result = Convert.ToInt32(param[31].Value.ToString());
            //string i;
            //i = param[33].Value.ToString();

            if (objUserBL.A25 == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[34].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void CFS_INS_UPD(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[60];

            param[0] = new SqlParameter("@CFS_ID", objUserBL.A1);
            param[26] = new SqlParameter("@REF_ID", objUserBL.A26);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A3);
            param[3] = new SqlParameter("@MANUAL_JOBNO", objUserBL.A4);
            param[1] = new SqlParameter("@CUSTOMER_NAME", objUserBL.A2);
            param[35] = new SqlParameter("@Consignee_name", objUserBL.A27);
            
           //param[4] = new SqlParameter("@JOBDATE", Connection.DATE_FORMAT(objUserBL.A5));
            param[5] = new SqlParameter("@FILE_REF_NO", objUserBL.A6);
            //param[6] = new SqlParameter("@NO_OF_PKG", objUserBL.A7);
            param[7] = new SqlParameter("@LCL", objUserBL.A8);
            param[8] = new SqlParameter("@FCL", objUserBL.A9);
            param[9] = new SqlParameter("@TWENTY_FEET_CNT", objUserBL.A10);
            param[10] = new SqlParameter("@FORTY_FEET_CNT", objUserBL.A11);
            param[11] = new SqlParameter("@GROSS_WGT", objUserBL.A12);
            param[12] = new SqlParameter("@BB", objUserBL.A13);
            param[13] = new SqlParameter("@CFS_NAME", objUserBL.A14);
            param[14] = new SqlParameter("@TAX_INVOICE_NO", objUserBL.A15);
            param[15] = new SqlParameter("@TAX_INVOICE_DATE", objUserBL.A16);
            param[16] = new SqlParameter("@TAX_INVOICE_AMOUNT", objUserBL.A17);
            param[17] = new SqlParameter("@STORAGE", objUserBL.A18);
            param[18] = new SqlParameter("@OOC_DATE", objUserBL.A19);
            param[19] = new SqlParameter("@CLEARANCE_DATE", objUserBL.A20);
            param[20] = new SqlParameter("@CBM", objUserBL.A21);
            param[21] = new SqlParameter("@CLEARANCE_STAFF_NAME", objUserBL.A22);
            param[22] = new SqlParameter("@TRANSPORTER_NAME", objUserBL.A28);
            param[23] = new SqlParameter("@VEHICLE_TYPE", objUserBL.A23);
            param[24] = new SqlParameter("@VEHICLE_NO", objUserBL.A24);
            param[25] = new SqlParameter("@Flag", objUserBL.A25);
           
            param[27] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[28] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[29] = new SqlParameter("@BRANCH_COMMON", Connection.Current_Branch());
            param[30] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[31] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[31].Direction = ParameterDirection.Output;
            param[33] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[33].Direction = ParameterDirection.Output;
            param[34] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[34].Direction = ParameterDirection.Output;

            param[36] = new SqlParameter("@ENTRY_TYPE", objUserBL.A29);
            param[37] = new SqlParameter("@CONTAINER_NO", objUserBL.A30);
            param[38] = new SqlParameter("@CFS_PORT_IN_DATE", objUserBL.A31);
            param[39] = new SqlParameter("@CFS_PORT_IN_TIME", objUserBL.A32);
            param[40] = new SqlParameter("@CFS_PORT_OUT_DATE", objUserBL.A33);
            param[41] = new SqlParameter("@CFS_PORT_OUT_TIME", objUserBL.A34);
            param[42] = new SqlParameter("@FACTORY_IN_DATE", objUserBL.A35);
            param[43] = new SqlParameter("@FACTORY_IN_TIME", objUserBL.A36);
            param[44] = new SqlParameter("@FACTORY_OUT_DATE", objUserBL.A37);
            param[45] = new SqlParameter("@FACTORY_OUT_TIME", objUserBL.A38);
            param[46] = new SqlParameter("@PACKAGES", objUserBL.A39);
            Connection.Get_Dataset("CFS_INS_UPD", param);
            result = Convert.ToInt32(param[31].Value.ToString());
            //string i;
            //i = param[33].Value.ToString();

            if (objUserBL.A25 == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[34].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void AAI_INS_UPD(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@AAI_ID", objUserBL.A1);
            param[1] = new SqlParameter("@CUSTOMER_NAME", objUserBL.A2);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A3);
            param[3] = new SqlParameter("@MANUAL_JOBNO", objUserBL.A4);
            //param[4] = new SqlParameter("@JOBDATE", Connection.DATE_FORMAT(objUserBL.A5));
            param[5] = new SqlParameter("@FILE_REF_NO", objUserBL.A6);
            param[6] = new SqlParameter("@NO_OF_PKG", objUserBL.A7);
            //param[7] = new SqlParameter("@LCL_FCL_AIR", objUserBL.A8);
            //param[8] = new SqlParameter("@TWENTY_FEET_CNT", objUserBL.A9);
            //param[9] = new SqlParameter("@FORTY_FEET_CNT", objUserBL.A10);
            //param[10] = new SqlParameter("@BRANCH_SL_NO", objUserBL.A11);
            param[11] = new SqlParameter("@GROSS_WGT", objUserBL.A11);
            param[12] = new SqlParameter("@CHARGABLE_WEIGHT", objUserBL.A12);
            param[13] = new SqlParameter("@AAI_TAX_INVOICE_NO", objUserBL.A13);
            param[14] = new SqlParameter("@AAI_TAX_INVOICE_DATE", objUserBL.A29);
            param[15] = new SqlParameter("@AAI_CHARGES", objUserBL.A14);
            param[16] = new SqlParameter("@DEMMURAGES_CHARGES", objUserBL.A15);
            param[17] = new SqlParameter("@AAI_CBM", objUserBL.A16);
            param[18] = new SqlParameter("@AAI_OOC_DATE", objUserBL.A17);
            param[19] = new SqlParameter("@AAI_CLEARANCE_DATE", objUserBL.A18);
            param[20] = new SqlParameter("@AAI_CLEARANCE_STAFF_NAME", objUserBL.A19);
            param[21] = new SqlParameter("@AAI_TRANSPORTER_NAME", objUserBL.A20);
            param[22] = new SqlParameter("@AAI_VEHICLE_TYPE", objUserBL.A21);
            param[23] = new SqlParameter("@AAI_VEHICLE_NO", objUserBL.A22);
            //param[23] = new SqlParameter("@Holding_Chq_date", Connection.DATE_FORMAT(objUserBL.A23));
            //param[24] = new SqlParameter("@Remarks", objUserBL.A24);
            param[25] = new SqlParameter("@Flag", objUserBL.A25);
            param[26] = new SqlParameter("@REF_ID", objUserBL.A26);
            param[27] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[28] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[29] = new SqlParameter("@BRANCH_COMMON", Connection.Current_Branch());
            param[30] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[31] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[31].Direction = ParameterDirection.Output;
            param[33] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[33].Direction = ParameterDirection.Output;
            param[34] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[34].Direction = ParameterDirection.Output;
           // param[35] = new SqlParameter("@Consignee_name", objUserBL.A27);
            param[36] = new SqlParameter("@ENTRY_TYPE", objUserBL.A28);
            Connection.Get_Dataset("AAI_INS_UPD", param);
            result = Convert.ToInt32(param[31].Value.ToString());
            //string i;
            //i = param[33].Value.ToString();

            if (objUserBL.A25 == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[34].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public DataSet DO_IMPORT_JOB_SEARCH(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Cus_name", objUserBL.A1);
            param[2] = new SqlParameter("@from_date", Connection.Search_Date(objUserBL.A2));
            param[3] = new SqlParameter("@to_date", Connection.Search_Date(objUserBL.A3));
            param[4] = new SqlParameter("@Jobno", objUserBL.A4);
            param[5] = new SqlParameter("@Comp_ID", Connection.COMPANYID());
            param[6] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            param[7] = new SqlParameter("@Flag", objUserBL.A5);
            param[8] = new SqlParameter("@Trans_Mode",objUserBL.A6);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("DO_IMPORT_JOB_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet CFS_IMPORT_JOB_SEARCH(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Cus_name", objUserBL.A1);
            param[2] = new SqlParameter("@from_date", Connection.Search_Date(objUserBL.A2));
            param[3] = new SqlParameter("@to_date", Connection.Search_Date(objUserBL.A3));
            param[4] = new SqlParameter("@Jobno", objUserBL.A4);

            param[5] = new SqlParameter("@Comp_ID", Connection.COMPANYID());
            param[6] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            param[7] = new SqlParameter("@Flag", objUserBL.A5);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("CFS_IMPORT_JOB_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet AAI_IMPORT_JOB_SEARCH(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Cus_name", objUserBL.A1);
            param[2] = new SqlParameter("@from_date", Connection.Search_Date(objUserBL.A2));
            param[3] = new SqlParameter("@to_date", Connection.Search_Date(objUserBL.A3));
            param[4] = new SqlParameter("@Jobno", objUserBL.A4);

            param[5] = new SqlParameter("@Comp_ID", Connection.COMPANYID());
            param[6] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            param[7] = new SqlParameter("@Flag", objUserBL.A5);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("AAI_IMPORT_JOB_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Open_DO_Data(string Imp_name_, string ddl_Jobno_, string Fromdate_, string Todate_, string Month_, string ddl_Mode_Type_)
    {
        Global_variables objUserBL = new Global_variables();
        HttpResponse Response = HttpContext.Current.Response;

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            objUserBL.A2 = Fromdate_;
            objUserBL.A3 = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                objUserBL.A2 = arr_Month[0];
                objUserBL.A3 = arr_Month[1];
            }
            else
            {
                objUserBL.A2 = Fromdate_;
                objUserBL.A3 = Todate_;
            }
        }
        objUserBL.A1 = Imp_name_;
        objUserBL.A4 = ddl_Jobno_;
        objUserBL.A6 = ddl_Mode_Type_;
        objUserBL.A5 = "Grid_Search_Data";
        DataSet ds1 = DO_IMPORT_JOB_SEARCH(objUserBL);

        DataTable dt = new DataTable();       
        int count = ds1.Tables[0].Rows.Count;
        for (int j = 0; j < count; j++)     
        {
            if (ds1.Tables[0].Rows[0]["Liner_name"].ToString().Contains("~"))
            {
                string[] Consolname = ds1.Tables[0].Rows[0]["Consol_Name"].ToString().Split('~');
                string[] Consolcharges = ds1.Tables[0].Rows[0]["Consol_charges"].ToString().Split('~');
                string[] linename = ds1.Tables[0].Rows[0]["Liner_name"].ToString().Split('~');
                string[] linechg = ds1.Tables[0].Rows[0]["Line_Charge"].ToString().Split('~');
                string[] DOFreedays = ds1.Tables[0].Rows[0]["DO_Free_days"].ToString().Split('~');
                string[] PortStorageAmt = ds1.Tables[0].Rows[0]["Port_Storage_Amt"].ToString().Split('~');
                string[] PortDORevalid = ds1.Tables[0].Rows[0]["Port_do_Revalidition"].ToString().Split('~');
                string[] DetentionAmt = ds1.Tables[0].Rows[0]["Detention_Amt"].ToString().Split('~');
                string[] DetenDORevalid = ds1.Tables[0].Rows[0]["Detention_do_Revalidition"].ToString().Split('~');
                string[] DamageChges = ds1.Tables[0].Rows[0]["Damage_Charges"].ToString().Split('~');
                string[] LateDoFee = ds1.Tables[0].Rows[0]["Late_do_fee"].ToString().Split('~');
                string[] tax = ds1.Tables[0].Rows[0]["Tax_Invoice_No"].ToString().Split('~');
                string[] TaxInvoiceDate = ds1.Tables[0].Rows[0]["Tax_Invoice_Date"].ToString().Split('~');
                string[] TaxInvoiceAmount = ds1.Tables[0].Rows[0]["Tax_Invoice_Amount"].ToString().Split('~');
                string[] HoldingChqNo = ds1.Tables[0].Rows[0]["Holding_chq_No"].ToString().Split('~');
                string[] HoldingChqDate = ds1.Tables[0].Rows[0]["Holding_Chq_date"].ToString().Split('~');
                string[] HoldingAmt = ds1.Tables[0].Rows[0]["Holding_Amt"].ToString().Split('~');
                string[] UTR_NO = ds1.Tables[0].Rows[0]["UTR_No"].ToString().Split('~');
                string[] UTR_Date = ds1.Tables[0].Rows[0]["UTR_Date"].ToString().Split('~');
                string[] UTRAmount = ds1.Tables[0].Rows[0]["UTR_Amt"].ToString().Split('~');
                string[] Holdingreturndt = ds1.Tables[0].Rows[0]["Holding_chq_return_date"].ToString().Split('~');
                string[] HoldingReceivedDate = ds1.Tables[0].Rows[0]["Holding_Received_Date"].ToString().Split('~');
                string[] Do_Applied_date = ds1.Tables[0].Rows[0]["Do_Applied_date"].ToString().Split('~');
                string[] Do_Received_date = ds1.Tables[0].Rows[0]["Do_Received_date"].ToString().Split('~');
               
                for (int k = 0; k <= Consolname.Count() - 1; k++)
                {
                    
                    if (linename[k] != "")
                    {

                        if (k == 0)
                        {
                            ds1.Tables[0].Rows.Add(ds1.Tables[0].Rows[0]["REF_ID"].ToString(), ds1.Tables[0].Rows[0]["JOBNO"].ToString(), ds1.Tables[0].Rows[0]["MANUAL_JOBNO"].ToString(),
                            ds1.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString(), ds1.Tables[0].Rows[0]["Consignee_name"].ToString(), ds1.Tables[0].Rows[0]["MBL_NO"].ToString(), ds1.Tables[0].Rows[0]["HBL_NO"].ToString(),
                            ds1.Tables[0].Rows[0]["NO_OF_PKG"].ToString(), ds1.Tables[0].Rows[0]["LCL_FCL_AIR"].ToString(), ds1.Tables[0].Rows[0]["20"].ToString(), ds1.Tables[0].Rows[0]["40"].ToString(), ds1.Tables[0].Rows[j]["GROSS_WGT"].ToString(),
                            ds1.Tables[0].Rows[0]["NET_WGT"].ToString(), Consolname[k], Consolcharges[k], linename[k], linechg[k], DOFreedays[k], PortStorageAmt[k], PortDORevalid[k], DetentionAmt[k], DetenDORevalid[k],
                            DamageChges[k], LateDoFee[k], tax[k], TaxInvoiceDate[k], TaxInvoiceAmount[k], HoldingChqNo[k], HoldingChqDate[k], HoldingAmt[k], UTR_NO[k],
                            UTR_Date[k], UTRAmount[k], Holdingreturndt[k], HoldingReceivedDate[k], Do_Applied_date[k], Do_Received_date[k]);
                        }
                        else
                        {
                            ds1.Tables[0].Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "",                                                                  
                            Consolname[k], Consolcharges[k], linename[k], linechg[k], DOFreedays[k], PortStorageAmt[k], PortDORevalid[k], DetentionAmt[k], DetenDORevalid[k],
                            DamageChges[k], LateDoFee[k], tax[k], TaxInvoiceDate[k], TaxInvoiceAmount[k], HoldingChqNo[k], HoldingChqDate[k], HoldingAmt[k], UTR_NO[k],
                            UTR_Date[k], UTRAmount[k], Holdingreturndt[k], HoldingReceivedDate[k], Do_Applied_date[k], Do_Received_date[k]);
                        }              
                    }
                }
            }
            ds1.Tables[0].Rows.RemoveAt(0);
        }
       
        DateTime time = DateTime.Now;
       
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + "DO_DATA" + "_" + time.ToString("yyyyMMddHHmm") + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView gv = new GridView();
            gv.AllowPaging = false;
            gv.DataSource = ds1.Tables[0];
            gv.DataBind();

            if (gv.Rows.Count > 0)
            {
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                {
                    gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8");
                }
                gv.RenderControl(hw);
            }
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public void  Open_CFS_Data(string Imp_name_, string ddl_Jobno_, string Fromdate_, string Todate_, string Month_)
    {
        Global_variables objUserBL = new Global_variables();
        HttpResponse Response = HttpContext.Current.Response;

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            objUserBL.A2 = Fromdate_;
            objUserBL.A3 = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                objUserBL.A2 = arr_Month[0];
                objUserBL.A3 = arr_Month[1];
            }
            else
            {
                objUserBL.A2 = Fromdate_;
                objUserBL.A3 = Todate_;
            }
        }

        objUserBL.A1 = Imp_name_;
        objUserBL.A4 = ddl_Jobno_;
        objUserBL.A5 = "Grid_Search_Data";
        DataSet ds1 = CFS_IMPORT_JOB_SEARCH(objUserBL);

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();

        //dt2 = ds1.Tables[0];
        int count = ds1.Tables[0].Rows.Count;
        //DataTable dt2 = new DataTable();

        dt1 = ds1.Tables[0];
        //dt2 = ds1.Tables[2];

        //string MyString = "10001~";
        //char[] MyChar = { '~' };
        //string NewString = MyString.TrimEnd(MyChar);

        //if (ds1.Tables[0].Rows.Count == 1)
        //{

        //}
        GridView gv2 = new GridView();

        for (int j = 0; j < count; j++)
        //for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {

            if (ds1.Tables[0].Rows[0]["CFS_NAME"].ToString().Contains("~"))
            {

                string[] cfsname = ds1.Tables[0].Rows[0]["CFS_NAME"].ToString().Split('~');
                string[] taxinvno = ds1.Tables[0].Rows[0]["TAX_INVOICE_NO"].ToString().Split('~');
                string[] taxinvdat = ds1.Tables[0].Rows[0]["TAX_INVOICE_DATE"].ToString().Split('~');
                string[] taxinvamt = ds1.Tables[0].Rows[0]["TAX_INVOICE_AMOUNT"].ToString().Split('~');
                string[] strge = ds1.Tables[0].Rows[0]["STORAGE"].ToString().Split('~');
                string[] oocdt = ds1.Tables[0].Rows[0]["OOC_DATE"].ToString().Split('~');
                string[] clrdt = ds1.Tables[0].Rows[0]["CLEARANCE_DATE"].ToString().Split('~');
                string[] cbm = ds1.Tables[0].Rows[0]["CBM"].ToString().Split('~');
                string[] clearstaff = ds1.Tables[0].Rows[0]["CLEARANCE_STAFF_NAME"].ToString().Split('~');
                string[] transname = ds1.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString().Split('~');
                string[] vehtyp = ds1.Tables[0].Rows[0]["VEHICLE_TYPE"].ToString().Split('~');
                string[] vehno = ds1.Tables[0].Rows[0]["VEHICLE_NO"].ToString().Split('~');
                string[] conno = ds1.Tables[0].Rows[0]["CONTAINER_NO"].ToString().Split('~');
                string[] cfsportindate = ds1.Tables[0].Rows[0]["CFS_PORT_IN_DATE"].ToString().Split('~');
                string[] cfsportintime = ds1.Tables[0].Rows[0]["CFS_PORT_IN_TIME"].ToString().Split('~');
                string[] cfsportoutdate = ds1.Tables[0].Rows[0]["CFS_PORT_OUT_DATE"].ToString().Split('~');
                string[] cfsportouttime = ds1.Tables[0].Rows[0]["CFS_PORT_OUT_TIME"].ToString().Split('~');
                string[] factoryindate = ds1.Tables[0].Rows[0]["FACTORY_IN_DATE"].ToString().Split('~');
                string[] factoryintime = ds1.Tables[0].Rows[0]["FACTORY_IN_TIME"].ToString().Split('~');
                string[] factoryoutdate = ds1.Tables[0].Rows[0]["FACTORY_OUT_DATE"].ToString().Split('~');
                string[] factoryouttime = ds1.Tables[0].Rows[0]["FACTORY_OUT_TIME"].ToString().Split('~');
                string[] packages = ds1.Tables[0].Rows[0]["PACKAGES"].ToString().Split('~');

                for (int k = 0; k <= cfsname.Count() - 1; k++)
                {
                    if (cfsname[k] != "")
                    {


                        ds1.Tables[0].Rows.Add(ds1.Tables[0].Rows[0]["REF_ID"].ToString(), ds1.Tables[0].Rows[0]["JOBNO"].ToString(), ds1.Tables[0].Rows[0]["MANUAL_JOBNO"].ToString(),
                            ds1.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString(), ds1.Tables[0].Rows[0]["FILE_REF_NO"].ToString(), ds1.Tables[0].Rows[0]["20"].ToString(),
                            ds1.Tables[0].Rows[0]["40"].ToString(), ds1.Tables[0].Rows[0]["LCL"].ToString(), ds1.Tables[0].Rows[0]["FCL"].ToString(),
                            ds1.Tables[0].Rows[0]["GROSS_WGT"].ToString(), ds1.Tables[0].Rows[j]["BB"].ToString(), cfsname[k], taxinvno[k], taxinvdat[k],
                            taxinvamt[k], strge[k], oocdt[k], clrdt[k], cbm[k], clearstaff[k], transname[k], vehtyp[k], vehno[k], conno[k], cfsportindate[k],cfsportintime [k], cfsportoutdate[k],cfsportouttime[k],
                            factoryindate[k], factoryintime[k], factoryoutdate[k], factoryouttime[k], packages[k]);
                        



                    }

                }

            }

            ds1.Tables[0].Rows.RemoveAt(0);
        }
        //j++;
        // ds1.Tables[0].Rows.RemoveAt(0);
        //if (ds1.Tables[0].Rows.)
        dt = ds1.Tables[0];
        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";
        //string Filename1 = "";
        //string Filename2 = "";
        Filename = "CFS_DATA";
        //Filename1 = "CFS_DATA";
        //Filename2 = "AAI_DATA";
        string strrptNametime = Filename + "_" + s;
        //string strrptNametime1 = Filename1 + "_" + s;
        //string strrptNametime2 = Filename2 + "_" + s;
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView gv = new GridView();
            gv.AllowPaging = false;
            gv.DataSource = dt;
            gv.DataBind();

            if (gv.Rows.Count > 0)
            {
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                {
                    gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8");
                }
                gv.RenderControl(hw);
            }
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    public void Open_AAI_Data(string Imp_name_, string ddl_Jobno_, string Fromdate_, string Todate_, string Month_)
    {
        Global_variables objUserBL = new Global_variables();
        HttpResponse Response = HttpContext.Current.Response;

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            objUserBL.A2 = Fromdate_;
            objUserBL.A3 = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                objUserBL.A2 = arr_Month[0];
                objUserBL.A3 = arr_Month[1];
            }
            else
            {
                objUserBL.A2 = Fromdate_;
                objUserBL.A3 = Todate_;
            }
        }

        objUserBL.A1 = Imp_name_;
        objUserBL.A4 = ddl_Jobno_;
        objUserBL.A5 = "Grid_Search_Data";
        DataSet ds1 = AAI_IMPORT_JOB_SEARCH(objUserBL);

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();

        //dt2 = ds1.Tables[0];
        int count = ds1.Tables[0].Rows.Count;
        //DataTable dt2 = new DataTable();

        dt1 = ds1.Tables[0];
        //dt2 = ds1.Tables[2];

        //string MyString = "10001~";
        //char[] MyChar = { '~' };
        //string NewString = MyString.TrimEnd(MyChar);

        //if (ds1.Tables[0].Rows.Count == 1)
        //{

        //}
        GridView gv2 = new GridView();

        for (int j = 0; j < count; j++)
        //for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {

            if (ds1.Tables[0].Rows[0]["AAI_TAX_INVOICE_NO"].ToString().Contains("~"))
            {

                string[] aaitax = ds1.Tables[0].Rows[0]["AAI_TAX_INVOICE_NO"].ToString().Split('~');
                string[] aaitaxinv = ds1.Tables[0].Rows[0]["AAI_TAX_INVOICE_DATE"].ToString().Split('~');
                string[] aaicharges = ds1.Tables[0].Rows[0]["AAI_CHARGES"].ToString().Split('~');
                string[] demchg = ds1.Tables[0].Rows[0]["DEMMURAGES_CHARGES"].ToString().Split('~');
                string[] cbm = ds1.Tables[0].Rows[0]["AAI_CBM"].ToString().Split('~');
                string[] aaioocdate = ds1.Tables[0].Rows[0]["AAI_OOC_DATE"].ToString().Split('~');
                string[] clrdate = ds1.Tables[0].Rows[0]["AAI_CLEARANCE_DATE"].ToString().Split('~');
                string[] clrstaffname = ds1.Tables[0].Rows[0]["AAI_CLEARANCE_STAFF_NAME"].ToString().Split('~');
                string[] transname = ds1.Tables[0].Rows[0]["AAI_TRANSPORTER_NAME"].ToString().Split('~');
                string[] Vehtype = ds1.Tables[0].Rows[0]["AAI_VEHICLE_TYPE"].ToString().Split('~');
                string[] vehno = ds1.Tables[0].Rows[0]["AAI_VEHICLE_NO"].ToString().Split('~');
                
                //int count = 1;
                for (int k = 0; k <= aaitax.Count() - 1; k++)
                {
                    
                    if (aaitax[k] != "")
                    {
                        


                        ds1.Tables[0].Rows.Add(ds1.Tables[0].Rows[0]["REF_ID"].ToString(), ds1.Tables[0].Rows[0]["JOBNO"].ToString(), ds1.Tables[0].Rows[0]["MANUAL_JOBNO"].ToString(),
                            ds1.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString(), ds1.Tables[0].Rows[0]["FILE_REF_NO"].ToString(), ds1.Tables[0].Rows[0]["NO_OF_PKG"].ToString(), ds1.Tables[0].Rows[j]["GROSS_WGT"].ToString(),
                             ds1.Tables[0].Rows[0]["CHARGABLE_WEIGHT"].ToString(), aaitax[k], aaitaxinv[k], aaicharges[k], demchg[k], cbm[k], aaioocdate[k], clrdate[k], clrstaffname[k], transname[k],
                               Vehtype[k], vehno[k]);
                        



                    }

                }

            }

            ds1.Tables[0].Rows.RemoveAt(0);
        }
        //j++;
        // ds1.Tables[0].Rows.RemoveAt(0);
        //if (ds1.Tables[0].Rows.)
        dt = ds1.Tables[0];
        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";
        //string Filename1 = "";
        //string Filename2 = "";
        Filename = "AAI_DATA";
        //Filename1 = "CFS_DATA";
        //Filename2 = "AAI_DATA";
        string strrptNametime = Filename + "_" + s;
        //string strrptNametime1 = Filename1 + "_" + s;
        //string strrptNametime2 = Filename2 + "_" + s;
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView gv = new GridView();
            gv.AllowPaging = false;
            gv.DataSource = dt;
            gv.DataBind();

            if (gv.Rows.Count > 0)
            {
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                {
                    gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8");
                }
                gv.RenderControl(hw);
            }
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
}

       

