using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using ClosedXML.Excel;
public class Payment_Request
{
    DataSet ds = new DataSet();
    public int result = 0, UPDATE_ID = 0;
    DataTable dt = new DataTable();
    public DataSet Payment_Request_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[26];

            param[1] = new SqlParameter("@BP_R_ID", objUserBL.A1);
            param[2] = new SqlParameter("@BP_R_P", objUserBL.A2);
            param[3] = new SqlParameter("@BP_R_NO", objUserBL.A3);
            param[4] = new SqlParameter("@BP_R_S", objUserBL.A4);
            param[5] = new SqlParameter("@Pay_To_Type", objUserBL.A5);
            param[6] = new SqlParameter("@Pay_To_Cus_Name", objUserBL.A6);
            param[7] = new SqlParameter("@Job_Other_Exp", objUserBL.A7);

            param[8] = new SqlParameter("@Imp_Exp", objUserBL.A8);
            param[9] = new SqlParameter("@Job_No", objUserBL.A9);
            param[10] = new SqlParameter("@JobNo_Ps", objUserBL.A10);
            param[11] = new SqlParameter("@Request_To", objUserBL.A11);
            param[12] = new SqlParameter("@JOB_LICENSE", objUserBL.A12);
            param[13] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A13);

            param[14] = new SqlParameter("@flag", objUserBL.A50);

            param[22] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[23] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[24] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[25] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[25].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_PAYMENT_REQUEST_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void Open_Payment_Request(string ddlSearch_Cat_, string txtsearch_, string Imp_name_, string Fromdate_, string Todate_, string Month_, string _Type, string IMP_EXP_)
    {
        Global_variables ObjUBO = new Global_variables();

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            ObjUBO.A1 = Fromdate_;
            ObjUBO.A2 = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                ObjUBO.A1 = arr_Month[0];
                ObjUBO.A2 = arr_Month[1];
            }
            else
            {
                ObjUBO.A1 = Fromdate_;
                ObjUBO.A2 = Todate_;
            }
        }
        //--------------------------------------------------------------------------------------------
        SqlParameter[] param = new SqlParameter[15];
        param[1] = new SqlParameter("@from_date", Common_CS.Get_Arrange_Date(ObjUBO.A1));
        param[2] = new SqlParameter("@to_date", Common_CS.Get_Arrange_Date(ObjUBO.A2));
        param[3] = new SqlParameter("@Cus_name", Imp_name_);

        if (ddlSearch_Cat_ == "0" || txtsearch_ == "")
        {
            param[4] = new SqlParameter("@Search_Cat", "");
            param[5] = new SqlParameter("@Search_Item", "");
        }
        else
        {
            param[4] = new SqlParameter("@Search_Cat", ddlSearch_Cat_);
            param[5] = new SqlParameter("@Search_Item", txtsearch_);
        }
        param[6] = new SqlParameter("@Imp_Exp", IMP_EXP_);
        param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
        param[9] = new SqlParameter("@Flag", "Load_Excel");
        param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[10].Direction = ParameterDirection.Output;

        ds = Connection.Get_Dataset("ACC_GST_BILL_PAYMENT_REQUEST_SEARCH", param);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
        }

        string strrptNametime = "Payment_Req" + "_" + Common_CS.Get_Timestamp();
        HttpResponse response = HttpContext.Current.Response;
        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(ds.Tables[0], strrptNametime);

            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xlsx");
            response.Cache.SetCacheability(HttpCacheability.NoCache);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                wb.SaveAs(memoryStream);
                memoryStream.Position = 0;
                memoryStream.CopyTo(response.OutputStream);
                response.Flush();
                response.End();             
            }
        }
    }

    public DataSet Payment_Request_Search(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@from_date", objUserBL.A1);
            param[2] = new SqlParameter("@to_date", objUserBL.A2);
            param[3] = new SqlParameter("@Cus_name", objUserBL.A3);
            param[4] = new SqlParameter("@Search_Cat", objUserBL.A4);
            param[5] = new SqlParameter("@Search_Item", objUserBL.A5);
            param[6] = new SqlParameter("@Imp_Exp", objUserBL.A6);
            param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[8] = new SqlParameter("@Flag", objUserBL.A7);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_BILL_PAYMENT_REQUEST_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Approval_Request_Search(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@from_date", objUserBL.A1);
            param[2] = new SqlParameter("@to_date", objUserBL.A2);
            param[3] = new SqlParameter("@REQUEST_TO", objUserBL.A3);
            param[4] = new SqlParameter("@PAY_ACTIVE", objUserBL.A4);
            param[5] = new SqlParameter("@Search_Item", objUserBL.A5);
            param[6] = new SqlParameter("@BRANCH", objUserBL.A6);
            param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[8] = new SqlParameter("@Flag", objUserBL.A7);
            param[9] = new SqlParameter("@IMP_EXP", objUserBL.A8);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_BILL_APPROVAL_REQUEST_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Payment_Request_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[36];
            param[1] = new SqlParameter("@BP_R_ID", objUserBL.A1);
            param[2] = new SqlParameter("@BP_R_P", objUserBL.A2);
            param[3] = new SqlParameter("@BP_R_NO", objUserBL.A3);
            param[4] = new SqlParameter("@BP_R_S", objUserBL.A4);
            param[5] = new SqlParameter("@REF_DATE", Connection.DATE_FORMAT(objUserBL.A5));
            param[6] = new SqlParameter("@PAY_TO_TYPE", objUserBL.A6);
            param[7] = new SqlParameter("@PAY_TO_CUS_NAME", objUserBL.A7);
            param[8] = new SqlParameter("@AGAINST", objUserBL.A8);
            param[9] = new SqlParameter("@JOB_NON_JOB_EXPENSE", objUserBL.A9);
            param[10] = new SqlParameter("@IMP_EXP", objUserBL.A10);
            param[11] = new SqlParameter("@JOB_NO", objUserBL.A11);
            param[12] = new SqlParameter("@JOBNO_PS", objUserBL.A12);
            param[13] = new SqlParameter("@REQUEST_TO", objUserBL.A13);
            param[14] = new SqlParameter("@MODE_OF_PAYMENT", objUserBL.A14);
            param[15] = new SqlParameter("@MARK_AS_URGENT", objUserBL.A15);
            param[16] = new SqlParameter("@AMOUNT", objUserBL.A16);
            param[17] = new SqlParameter("@NARRATION", objUserBL.A17);

            param[25] = new SqlParameter("@xmlstring_Gen", objUserBL.A29);
            param[28] = new SqlParameter("@JOB_LICENSE", objUserBL.A30);
            param[29] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A31);
            param[30] = new SqlParameter("@flag", objUserBL.A32);

            param[31] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[32] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[33] = new SqlParameter("@User_Name", Connection.Current_User());
            param[34] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());

            param[35] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[35].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_PAYMENT_REQUEST_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Approval_Request_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[36];
            param[1] = new SqlParameter("@REFERENCE_NO", objUserBL.A1);
            param[4] = new SqlParameter("@CHARGE_ID", objUserBL.A2);
            param[5] = new SqlParameter("@PAY_REMARKS", objUserBL.A3);
            param[6] = new SqlParameter("@PAY_ACTIVE", objUserBL.A4);
            param[7] = new SqlParameter("@IMP_EXP", objUserBL.A5);
            param[8] = new SqlParameter("@user_id", Connection.Current_User());

            param[30] = new SqlParameter("@flag", objUserBL.A32);
            param[28] = new SqlParameter("@JOB_LICENSE", objUserBL.A30);
            param[29] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A31);
            param[31] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[32] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[34] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[35] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[35].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_APPROVAL_REQUEST_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet Payment_Request_Charge_Details_Ins_Upd(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[40];
            param[0] = new SqlParameter("@BP_R_ID", objUserBL.A1);
            param[1] = new SqlParameter("@BP_R_P", objUserBL.A2);
            param[2] = new SqlParameter("@BP_R_NO", objUserBL.A3);
            param[3] = new SqlParameter("@BP_R_S", objUserBL.A4);
            param[4] = new SqlParameter("@LOB", objUserBL.A5);
            param[5] = new SqlParameter("@JOBNO", objUserBL.A6);
            param[6] = new SqlParameter("@CHARGE_ID", objUserBL.A7);
            param[7] = new SqlParameter("@CHARGE_NAME", objUserBL.A8);
            param[8] = new SqlParameter("@CUR", objUserBL.A9);
            param[9] = new SqlParameter("@ESTIMATED", objUserBL.A10);
            param[10] = new SqlParameter("@PAY_AMOUNT", objUserBL.A11);
            param[11] = new SqlParameter("@PAY_AMOUNT_HC", objUserBL.A12);
            param[12] = new SqlParameter("@COST_CENTER", objUserBL.A13);
            param[13] = new SqlParameter("@PAYABLE_TO", objUserBL.A14);
            param[14] = new SqlParameter("@REMARKS", objUserBL.A15);
            param[15] = new SqlParameter("@JOBNO_PS", objUserBL.A21);
            param[16] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[17] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[18] = new SqlParameter("@user_id", Connection.Current_User());
            param[19] = new SqlParameter("@flag", objUserBL.A20);

            param[32] = new SqlParameter("@Mstatus", SqlDbType.Int);
            param[32].Direction = ParameterDirection.Output;
            param[33] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[34] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, -1);
            param[34].Direction = ParameterDirection.Output;
            param[35] = new SqlParameter("@Update_Id", SqlDbType.BigInt);
            param[35].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_PAYMENT_REQUEST_CHARGE_DETAILS_INS_UPD", param);
            result = Convert.ToInt32(param[32].Value.ToString());
            UPDATE_ID = Convert.ToInt32(param[35].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet Payment_Request_Charge_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[26];

            param[1] = new SqlParameter("@BP_R_ID", objUserBL.A1);
            param[2] = new SqlParameter("@BP_R_P", objUserBL.A2);
            param[3] = new SqlParameter("@BP_R_NO", objUserBL.A3);
            param[4] = new SqlParameter("@BP_R_S", objUserBL.A4);
            param[5] = new SqlParameter("@Pay_To_Type", objUserBL.A5);
            param[6] = new SqlParameter("@Pay_To_Cus_Name", objUserBL.A6);
            param[7] = new SqlParameter("@Job_Other_Exp", objUserBL.A7);

            param[8] = new SqlParameter("@LOB", objUserBL.A8);
            param[9] = new SqlParameter("@Job_No", objUserBL.A9);
            param[10] = new SqlParameter("@JobNo_Ps", objUserBL.A10);
            param[11] = new SqlParameter("@Request_To", objUserBL.A11);
            param[12] = new SqlParameter("@JOB_LICENSE", objUserBL.A12);
            param[13] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A13);
            param[14] = new SqlParameter("@flag", objUserBL.A50);
            param[15] = new SqlParameter("@CHARGE_ID", objUserBL.A15);

            param[22] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[23] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[24] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[25] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[25].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_PAYMENT_REQUEST_CHARGE_DETAILS_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }



    public DataSet Payment_Request_RpT(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[26];

            param[1] = new SqlParameter("@REFERENCE_NO", objUserBL.A1);
            param[2] = new SqlParameter("@Imp_Exp", objUserBL.A2);
            param[3] = new SqlParameter("@Job_No", objUserBL.A3);
            param[4] = new SqlParameter("@JobNo_Ps", objUserBL.A4);
            param[5] = new SqlParameter("@JOB_LICENSE", objUserBL.A12);
            param[6] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A13);
            param[7] = new SqlParameter("@flag", objUserBL.A50);

            param[22] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[23] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[24] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[25] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[25].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_PAYMENT_REQUEST_RPT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet Payment_Request_Excel_Upload_Ins_Select(Global_variables objUserBL, string xmlString)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[43];
            param[1] = new SqlParameter("@BP_R_P", objUserBL.A1);
            param[2] = new SqlParameter("@BP_R_NO", objUserBL.A2);
            param[3] = new SqlParameter("@BP_R_S", objUserBL.A3);
            param[4] = new SqlParameter("@BP_R_ID", objUserBL.A4);
            param[5] = new SqlParameter("@Pay_To_Type", objUserBL.A6);
            param[6] = new SqlParameter("@Pay_To_Cus_Name", objUserBL.A7);

            param[34] = new SqlParameter("@xmlString", xmlString);
            param[35] = new SqlParameter("@flag", objUserBL.A20);
            param[36] = new SqlParameter("@User_Id", Connection.Current_User());
            param[37] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[38] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[39] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_PAYMENT_REQUEST_EXCEL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Shipment_Details_Search(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@from_date", objUserBL.A1);
            param[2] = new SqlParameter("@to_date", objUserBL.A2);
            param[3] = new SqlParameter("@JobNo", objUserBL.A3);

            param[5] = new SqlParameter("@Search_Item", objUserBL.A5);
            param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[8] = new SqlParameter("@Flag", objUserBL.A7);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_BILL_SHIPMENT_REQUEST_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}