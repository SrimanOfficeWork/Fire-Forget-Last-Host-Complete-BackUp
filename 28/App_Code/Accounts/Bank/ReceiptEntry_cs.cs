using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;
using ClosedXML.Excel;

public class ReceiptEntry_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    private string _xmlString;
    # region ClearFunction
    public void ResetFields(ControlCollection pageControls)
    {
        foreach (Control contl in pageControls)
        {
            string strCntName = (contl.GetType()).Name;
            switch (strCntName)
            {
                case "TextBox":
                    TextBox tbSource = (TextBox)contl;
                    tbSource.Text = "";
                    break;
                //case "RadioButtonList":
                //    RadioButtonList rblSource = (RadioButtonList)contl;
                //    rblSource.SelectedIndex = -1;
                //    break;
                case "DropDownList":
                    DropDownList ddlSource = (DropDownList)contl;
                    ddlSource.SelectedIndex = -1;

                    break;

                case "CheckBox":
                    CheckBox chkSource = (CheckBox)contl;
                    chkSource.Checked = false;
                    break;

            }

            ResetFields(contl.Controls);
        }
    }

    public void ResetFields_without_dropdown(ControlCollection pageControls)
    {
        foreach (Control contl in pageControls)
        {
            string strCntName = (contl.GetType()).Name;
            switch (strCntName)
            {
                case "TextBox":
                    TextBox tbSource = (TextBox)contl;
                    tbSource.Text = "";
                    break;

                //case "DropDownList":
                //    DropDownList ddlSource = (DropDownList)contl;
                //    ddlSource.SelectedIndex = -1;

                //    break;

                case "CheckBox":
                    CheckBox chkSource = (CheckBox)contl;
                    chkSource.Checked = false;
                    break;

            }

            ResetFields(contl.Controls);
        }
    }


    # endregion
    public string xmlString { get { return _xmlString; } set { _xmlString = value; } }
    public DataSet BR_Receipt_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[2] = new SqlParameter("@BR_ID", objUserBL.A1);
            param[3] = new SqlParameter("@BR_Ch_Id", objUserBL.A2);

            param[4] = new SqlParameter("@BR_P", objUserBL.A3);
            param[5] = new SqlParameter("@BR_NO", objUserBL.A4);
            param[6] = new SqlParameter("@BR_S", objUserBL.A5);
            param[7] = new SqlParameter("@JOB_ID", objUserBL.A6);
            param[8] = new SqlParameter("@BR_JOB_AMT", objUserBL.A7);
            param[9] = new SqlParameter("@ORGANAIZATION_NAME", objUserBL.A8);

            param[16] = new SqlParameter("@flag", objUserBL.A40); //Flag
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_BR_RECEIPT_ENTRY_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Acc_Gst_Recipit_Grid_Search(Global_variables objUserBL)
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
            param[3] = new SqlParameter("@RECIPIT_NO", objUserBL.A3);
            param[4] = new SqlParameter("@PARTY_NAME", objUserBL.A5);

            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Flag", objUserBL.A40);
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;


            if (objUserBL.A4 == "Receipt_Debtors")
            {
                ds = Connection.Get_Dataset("ACC_GST_RECIPIT_ENTRY_GRID_SEARCH", param);
            }
            else if (objUserBL.A4 == "Other_Receipts")
            {
                ds = Connection.Get_Dataset("ACC_GST_RECIPIT_ENTRY_OTHER_GRID_SEARCH", param);
            }
            else
            {
                ds = Connection.Get_Dataset("ACC_GST_RECIPIT_ENTRY_CASH_GRID_SEARCH", param);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Acc_Gst_Recipit_Bill_details_Search(Global_variables objUserBL)
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
            param[3] = new SqlParameter("@Branch", objUserBL.A3);
            param[4] = new SqlParameter("@PARTY_NAME", objUserBL.A4);
            param[5] = new SqlParameter("@BILL_NO", objUserBL.A5);

            param[11] = new SqlParameter("@Company_Id", Connection.COMPANYID());
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Flag", objUserBL.A40);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_BR_RECEIPT_CREDITOR_BILL_DETAILS_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    //ACC_GST_BR_RECEIPT_ENTRY
    public DataSet ACC_GST_BR_RECEIPT_ENTRY_INS_UPD(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[54];
            param[1] = new SqlParameter("@BR_ID", objUserBL.A1);
            param[2] = new SqlParameter("@R_O", objUserBL.A2);
            param[3] = new SqlParameter("@BR_P", objUserBL.A3);
            param[4] = new SqlParameter("@BR_NO", objUserBL.A4);
            param[5] = new SqlParameter("@BR_S", objUserBL.A5);
            param[6] = new SqlParameter("@BR_DATE", Connection.DATE_FORMAT(objUserBL.A6));
            param[7] = new SqlParameter("@POSTING_DATE", Connection.DATE_FORMAT(objUserBL.A7));
            param[8] = new SqlParameter("@BANK_NAME", objUserBL.A8);
            param[9] = new SqlParameter("@ISSUSER_BANK_NAME", objUserBL.A9);
            param[10] = new SqlParameter("@ISSUSER_BANK_NO", objUserBL.A10);
            param[11] = new SqlParameter("@ORGANAIZATION_NAME", objUserBL.A11);
            param[12] = new SqlParameter("@ORGANAIZATION_BR", objUserBL.A12);
            param[13] = new SqlParameter("@FUND_TYPE", objUserBL.A13);
            param[14] = new SqlParameter("@FUND_ID", objUserBL.A14);
            param[15] = new SqlParameter("@FUND_DATE", Connection.DATE_FORMAT(objUserBL.A15));
            param[16] = new SqlParameter("@FUND_CUR", objUserBL.A16);
            param[17] = new SqlParameter("@FUND_EX_RATE", objUserBL.A17);
            param[18] = new SqlParameter("@FUND_CUR_AMT", objUserBL.A18);
            param[19] = new SqlParameter("@FUND_INR_AMT", objUserBL.A19);
            param[20] = new SqlParameter("@FUND_ADJUSTMENT_FOR", objUserBL.A20);
            param[21] = new SqlParameter("@TDS_DEDUCTED", objUserBL.A21);
            param[22] = new SqlParameter("@TDS_AMT", objUserBL.A22);
            param[23] = new SqlParameter("@NARRATION", objUserBL.A23);
            param[24] = new SqlParameter("@JOB_LICENSE", objUserBL.A24);
            param[25] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A25);
            param[26] = new SqlParameter("@TDS_SECTION", objUserBL.A26);
            param[27] = new SqlParameter("@TDS_RATE", objUserBL.A27);
            param[28] = new SqlParameter("@AC_NO", objUserBL.A28);
            param[29] = new SqlParameter("@xmlString", xmlString);
            param[30] = new SqlParameter("@Issuer_Bank_info_No", objUserBL.A29);
            param[31] = new SqlParameter("@CREDIT_TO_BANK", objUserBL.A30);

            param[32] = new SqlParameter("@TDS_DEDUCTED_INR_II", objUserBL.A31);

            param[33] = new SqlParameter("@ORGIN_BANK_CHARGE_TDS_I", objUserBL.A32);
            param[34] = new SqlParameter("@ORGIN_BANK_CHARGE_TDS_II", objUserBL.A33);

            param[35] = new SqlParameter("@REC_FROM_ORG_I", objUserBL.A34);
            param[36] = new SqlParameter("@REC_FROM_ORG_II", objUserBL.A35);
            param[37] = new SqlParameter("@BANK_CHARGE_I", objUserBL.A36);
            param[38] = new SqlParameter("@BANK_CHARGE_II", objUserBL.A37);
            param[39] = new SqlParameter("@DEBIT_TO_BANK_I", objUserBL.A38);
            param[40] = new SqlParameter("@DEBIT_TO_BANK_II", objUserBL.A39);
            param[41] = new SqlParameter("@GL_CODE", objUserBL.A40);


            param[48] = new SqlParameter("@flag", objUserBL.A53);
            param[49] = new SqlParameter("@User_Name", Connection.Current_User());
            param[50] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[51] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[52] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[53] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[53].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_BR_RECEIPT_ENTRY_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Open_Receipt_Tally_Data(string ReceiptNo_, string Party_Name_, string PaymentType_, string Fromdate_, string Todate_, string Month_)
    {
        Global_variables ObjUBO = new Global_variables();
        DataTable dt = new DataTable();
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
        SqlParameter[] param = new SqlParameter[15];
        param[1] = new SqlParameter("@from_date", Common_CS.Get_Arrange_Date(ObjUBO.A1));
        param[2] = new SqlParameter("@to_date", Common_CS.Get_Arrange_Date(ObjUBO.A2));
        param[3] = new SqlParameter("@RECIPIT_NO", ReceiptNo_);
        param[4] = new SqlParameter("@PARTY_NAME", Party_Name_);

        param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
        param[13] = new SqlParameter("@Flag", PaymentType_);

        param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[14].Direction = ParameterDirection.Output;

        if (PaymentType_ == "Receipt_Debtors")
        {
            ds = Connection.Get_Dataset("ACC_RECEIPT_ENTRY_TALLY_DATA", param);
        }
        else if (PaymentType_ == "Cash_Deposit")
        {
            ds = Connection.Get_Dataset("ACC_GST_RECIPIT_ENTRY_CASH_DEPOSIT_TALLY_DATA", param);
        }
        else
        {
            ds = Connection.Get_Dataset("ACC_GST_BANK_RECIPIT_OTHER_ENTRY_TALLY_DATA", param);
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
        }
        string strrptNametime = "RECEIPT_TALLY_DATA" + "_" + Common_CS.Get_Timestamp();
        HttpResponse Response = HttpContext.Current.Response;
        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(ds.Tables[0], strrptNametime);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xlsx");

            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
        }
    }



    //report params
    public DataSet ACC_BankPayments_ReceiptsEntry_RPT(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@BR_P", objUserBL.A1);
            param[1] = new SqlParameter("@BR_NO", objUserBL.A2);
            param[2] = new SqlParameter("@BR_S", objUserBL.A3);

            param[4] = new SqlParameter("@MFLAG", objUserBL.A25);
            param[3] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, -1);
            param[5].Direction = ParameterDirection.Output;

            foreach (SqlParameter p in param)
            {
                if (p != null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        p.ParameterName + " = " +
                        (p.Value == null || p.Value == DBNull.Value ? "NULL" : p.Value.ToString()));
                }
            }
            ds = Connection.Get_Dataset("ACC_BANKPAYMENTS_RECEIPTENTRY_RPT", param);     //ACC_BANKPAYMENTS_CASHWITHDRAWAL_RPT
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

}