using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;
using ClosedXML.Excel;
public class Cha_Accounts
{
    DataSet ds = new DataSet();
    public int result = 0, UPDATE_ID = 0;
    private string _flag;
    public string flag { get { return _flag; } set { _flag = value; } }

    public DataSet Bill_To_Party_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[45];
            param[1] = new SqlParameter("@BILL_ID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[3] = new SqlParameter("@BILL_PARTY_NAME", objUserBL.A3);
            param[4] = new SqlParameter("@BRANCH_NO", objUserBL.A4);
            param[5] = new SqlParameter("@ADDRESS_I", objUserBL.A5);
            param[6] = new SqlParameter("@ADDRESS_II", objUserBL.A6);
            param[7] = new SqlParameter("@ADDRESS_III", objUserBL.A7);
            param[8] = new SqlParameter("@STATENAME", objUserBL.A8);
            param[9] = new SqlParameter("@PINCODE", objUserBL.A9);
            param[10] = new SqlParameter("@GSTN_ID", objUserBL.A10);
            param[11] = new SqlParameter("@JOBNO_PS", objUserBL.A11);

            param[12] = new SqlParameter("@JOBTYPE", objUserBL.A12);
            param[13] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A13);
            param[14] = new SqlParameter("@ROYAL_OTHER", objUserBL.A14);
            param[15] = new SqlParameter("@MODE", objUserBL.A15);
            param[16] = new SqlParameter("@PARTY_TYPE", objUserBL.A16);

            param[34] = new SqlParameter("@flag", objUserBL.A41);
            param[35] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[36] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[37] = new SqlParameter("@JOB_LICENSE", Connection.Company_License());
            param[38] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[39] = new SqlParameter("@user_id", Connection.Current_User());

            param[43] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[43].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_BILL_TO_CHA_PARTY_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
 
    public DataSet Billing_Party_Data_Search(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@BILL_ID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[3] = new SqlParameter("@BILL_PARTY_NAME", objUserBL.A3);
            param[4] = new SqlParameter("@BRANCH_NO", objUserBL.A4);
            param[5] = new SqlParameter("@JOB_TYPE", objUserBL.A5);
            param[6] = new SqlParameter("@Flag", objUserBL.A6);
            param[8] = new SqlParameter("@BRANCH_CODE", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_BILL_TO_CHA_PARTY_SEARCH_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet charge_Data_Search(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@CHARGE_ID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[3] = new SqlParameter("@CHARGE_NAME", objUserBL.A6);
            param[4] = new SqlParameter("@Tax_Type", objUserBL.A7);
            param[5] = new SqlParameter("@JOBTYPE", objUserBL.A8);
            param[6] = new SqlParameter("@INV_NO", objUserBL.A9);
            param[7] = new SqlParameter("@IMP_EXP", objUserBL.A10);
            param[8] = new SqlParameter("@GSTIN", objUserBL.A11);
            param[9] = new SqlParameter("@ROYAL_OTHER", objUserBL.A12);
            param[10] = new SqlParameter("@JOBNO_PS", objUserBL.A13);

            param[11] = new SqlParameter("@Flag", objUserBL.A15);
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_CHA_CHARGE_SEARCH_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet charge_Data_Search_new(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@CHARGE_ID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[3] = new SqlParameter("@CHARGE_NAME", objUserBL.A6);
            param[4] = new SqlParameter("@Tax_Type", objUserBL.A7);
            param[5] = new SqlParameter("@JOBTYPE", objUserBL.A8);
            param[6] = new SqlParameter("@INV_NO", objUserBL.A9);
            param[7] = new SqlParameter("@IMP_EXP", objUserBL.A10);
            param[8] = new SqlParameter("@GSTIN", objUserBL.A11);
            param[9] = new SqlParameter("@ROYAL_OTHER", objUserBL.A12);
            param[10] = new SqlParameter("@JOBNO_PS", objUserBL.A13);

            param[11] = new SqlParameter("@Flag", objUserBL.A15);
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_CHA_CHARGE_SEARCH_SELECT_NEW", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Convert_Inv_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[26];
            param[0] = new SqlParameter("@Bill_Inv_No", objUserBL.A101);
            param[1] = new SqlParameter("@Imp_Exp", objUserBL.A102);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A103);
            param[3] = new SqlParameter("@JOBNO_PS", objUserBL.A104);
            param[4] = new SqlParameter("@BANK_NAME", objUserBL.A105);
            param[5] = new SqlParameter("@BANK_AC_NO", objUserBL.A106);

            param[19] = new SqlParameter("@flag", objUserBL.A124);
            param[20] = new SqlParameter("@JOB_LICENSE", Connection.Company_License());
            param[21] = new SqlParameter("@JOB_WORKINGPERIOD", Connection.WorkingPeriod());
            param[22] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[22].Direction = ParameterDirection.Output;
            param[23] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[24] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[25] = new SqlParameter("@USER_ID", Connection.Current_User());
            if (objUserBL.A102 == "E")
            {

                ds = Connection.Get_Dataset("ACC_GST_CHA_CHARGE_INVOICE_INS_UPD", param);
            }
            else
            {
                ds = Connection.Get_Dataset("ACC_GST_CHA_CHARGE_INVOICE_INS_UPD_IMP", param);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet CHA_Quotation_Charge_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@CHARGE_ID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[3] = new SqlParameter("@JOBNO_PS", objUserBL.A3);
            param[4] = new SqlParameter("@CHARGE_NAME", objUserBL.A5);

            param[7] = new SqlParameter("@IMP_EXP", objUserBL.A10);
            param[8] = new SqlParameter("@flag", objUserBL.A40);
            param[9] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[10] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[11] = new SqlParameter("@user_id", Connection.Current_User());
            param[12] = new SqlParameter("@COMPANY_LIC", Connection.Company_License());
            param[13] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            if (objUserBL.A10 == "I")
            {
                ds = Connection.Get_Dataset("ACC_GST_IMP_CHA_QUOTATION_CHARGE_SELECT", param);
            }
            else if (objUserBL.A10 == "E")
            {
                ds = Connection.Get_Dataset("ACC_GST_EXP_CHA_QUOTATION_CHARGE_SELECT", param);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Other_Billing_Party_Data_Search(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@BILL_ID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[3] = new SqlParameter("@BILL_PARTY_NAME", objUserBL.A3);
            param[4] = new SqlParameter("@BRANCH_NO", objUserBL.A4);
            param[5] = new SqlParameter("@JOB_TYPE", objUserBL.A5);
            param[6] = new SqlParameter("@Flag", objUserBL.A6);
            param[7] = new SqlParameter("@ROYAL_OTHER", objUserBL.A7);
            param[8] = new SqlParameter("@JOBNO_PS", objUserBL.A8);

            param[12] = new SqlParameter("@BRANCH_CODE", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_BILL_TO_OTHER_PARTY_SEARCH_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Other_Billing_Party_Data_Grid_Search(Global_variables objUserBL)
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
            param[3] = new SqlParameter("@JOBNO_PS", objUserBL.A3);
            param[4] = new SqlParameter("@JOB_TYPE", objUserBL.A4);
            param[5] = new SqlParameter("@BILL_PARTY_NAME", objUserBL.A5);

            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Flag", objUserBL.A40);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_BILL_TO_OTHER_PARTY_GRID_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Other_Bill_To_Party_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[45];
            param[1] = new SqlParameter("@BILL_ID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[3] = new SqlParameter("@BILL_PARTY_NAME", objUserBL.A3);
            param[4] = new SqlParameter("@BRANCH_NO", objUserBL.A4);
            param[5] = new SqlParameter("@ADDRESS_I", objUserBL.A5);
            param[6] = new SqlParameter("@ADDRESS_II", objUserBL.A6);
            param[7] = new SqlParameter("@ADDRESS_III", objUserBL.A7);
            param[8] = new SqlParameter("@STATENAME", objUserBL.A8);
            param[9] = new SqlParameter("@PINCODE", objUserBL.A9);
            param[10] = new SqlParameter("@GSTN_ID", objUserBL.A10);
            param[11] = new SqlParameter("@JOBNO_PS", objUserBL.A11);
            param[12] = new SqlParameter("@JOBTYPE", objUserBL.A12);
            param[13] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A13);
            param[14] = new SqlParameter("@ROYAL_OTHER", objUserBL.A14);
            param[15] = new SqlParameter("@MODE", objUserBL.A15);

            param[34] = new SqlParameter("@flag", objUserBL.A41);
            param[35] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[36] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[37] = new SqlParameter("@JOB_LICENSE", Connection.Company_License());
            param[38] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[39] = new SqlParameter("@user_id", Connection.Current_User());

            param[43] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[43].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_BILL_TO_OTHER_PARTY_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet charge_Annexure_Search(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@JOBNO", objUserBL.A101);
            param[2] = new SqlParameter("@INV_NO", objUserBL.A103);
            param[3] = new SqlParameter("@IMP_EXP", objUserBL.A104);
            param[4] = new SqlParameter("@ROYAL_OTHER", objUserBL.A105);
            param[5] = new SqlParameter("@Branch_Code", Connection.Current_Branch());

            param[11] = new SqlParameter("@Flag", objUserBL.A116);
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_CHARGE_ANNEXURE_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Acc_Financial_Search(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[26];
            param[1] = new SqlParameter("@JOBNO", objUserBL.A1);
            param[2] = new SqlParameter("@JOBTYPE", objUserBL.A2);

            param[20] = new SqlParameter("@flag", objUserBL.A24);
            param[21] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A25);
            param[22] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[23] = new SqlParameter("@JOB_LICENSE", Connection.Company_License());
            param[24] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[25] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[25].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_FINANCIALS_SEARCH_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Open_Cost_Sheet(string JOBNO_PS, string JOBTYPE, string Flag)
    {
        HttpResponse Response = HttpContext.Current.Response;
        Global_variables ObjUBO = new Global_variables();
        DataTable dt = new DataTable();

        SqlParameter[] param = new SqlParameter[26];
        param[1] = new SqlParameter("@JOBNO_PS", JOBNO_PS);
        param[2] = new SqlParameter("@JOBTYPE", JOBTYPE);
        param[19] = new SqlParameter("@MFLAG", Flag);
        param[20] = new SqlParameter("@JOB_WORKINGPERIOD", Connection.WorkingPeriod());
        param[21] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
        param[22] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
        param[23] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
        param[24] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
        param[25] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[25].Direction = ParameterDirection.Output;

        ds = Connection.Get_Dataset("ACC_COST_SHEET_EXCEL", param);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
        }

        string strrptNametime = "Cost_Sheet_" + Common_CS.Get_Timestamp();
        using (XLWorkbook wb = new XLWorkbook())
        {
            var ws = wb.Worksheets.Add("Cost Sheet");
            int row = 1;

            if (ds.Tables[2].Rows.Count > 0)
            {
                string companyName = ds.Tables[2].Rows[0]["COMPANY_NAME"].ToString();
                string address = ds.Tables[2].Rows[0]["ADDRESS"].ToString();
                var companyRange = ws.Range(row, 1, row, 10);
                companyRange.Merge();
                ws.Cell(row, 1).Value = companyName + "\n" + address;
                companyRange.Style
                    .Font.SetBold()
                    .Font.SetFontSize(14)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    .Alignment.WrapText = true;
                ws.Row(row).Height = 40;
                row++;
            }
            ws.Cell(row, 1).Value = "COST SHEET";
            ws.Range(row, 1, row, 10).Merge().Style
                .Font.SetBold()
                .Font.SetFontSize(12)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
           
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow h = ds.Tables[0].Rows[0];
                ws.Range(row + 1, 1, row + 6, 10).Style.Fill.SetBackgroundColor(XLColor.LightBlue)
                   .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                ws.Cell(row + 1, 1).Value = "Job No:";
                ws.Cell(row + 1, 2).Value = h["JOBNO_PS"].ToString();

                ws.Cell(row + 1, 3).Value = "Date:";
                ws.Cell(row + 1, 4).Value = h["JOBDATE"].ToString();

                ws.Cell(row + 1, 5).Value = "Mode:";
                ws.Cell(row + 1, 6).Value = h["TRANSPORT_MODE"].ToString();
              
                ws.Cell(row + 3, 7).Value = "Customer Name:";
                ws.Cell(row + 3, 8).Value = h["Customer_Name"].ToString();

               
                ws.Cell(row + 2, 5).Value = "Customs House:";
                ws.Cell(row + 2, 6).Value = h["CUSTOMS_HOUSE"].ToString();

                ws.Cell(row + 3, 5).Value = "Port of Destination:";
                ws.Cell(row + 3, 6).Value = h["port of destination"].ToString();

                ws.Cell(row + 4, 5).Value = "Port of Loading:";
                ws.Cell(row + 4, 6).Value = h["port of loading"].ToString();
                if (JOBTYPE == "I")
                {
                    ws.Cell(row + 3, 1).Value = "BE No:";
                    ws.Cell(row + 3, 2).Value = h["BE_NO"].ToString();

                    ws.Cell(row + 3, 3).Value = "BE Date:";
                    ws.Cell(row + 3, 4).Value = h["BE_DATE"].ToString();

                    ws.Cell(row + 1, 7).Value = "Importer Name:";
                    ws.Cell(row + 1, 8).Value = h["IMPORTER_NAME"].ToString();

                    ws.Cell(row + 2, 1).Value = "Be Type:";
                    ws.Cell(row + 2, 2).Value = h["BE_TYPE"].ToString();

                    ws.Cell(row + 4, 7).Value = "Assbl value:";
                    ws.Cell(row + 4, 8).Value = h["Assbl value"].ToString();

                    ws.Cell(row + 5, 7).Value = "Duty:";
                    ws.Cell(row + 5, 8).Value = h["Duty"].ToString();

                    ws.Cell(row + 2, 7).Value = "Supplier:";
                    ws.Cell(row + 2, 8).Value = h["consignor"].ToString();
                }
                else
                {
                    ws.Cell(row + 3, 1).Value = "SB No:";
                    ws.Cell(row + 3, 2).Value = h["SB_NO"].ToString();

                    ws.Cell(row + 3, 3).Value = "SB Date:";
                    ws.Cell(row + 3, 4).Value = h["SB_DATE"].ToString();

                    ws.Cell(row + 1, 7).Value = "Exporter Name:";
                    ws.Cell(row + 1, 8).Value = h["EXPORTER_NAME"].ToString();

                    ws.Cell(row + 2, 1).Value = "SB Type:";
                    ws.Cell(row + 2, 2).Value = h["SB_TYPE"].ToString();

                    ws.Cell(row + 4, 7).Value = "FOB value:";
                    ws.Cell(row + 4, 8).Value = h["FOB value"].ToString();

                    ws.Cell(row + 5, 7).Value = "Draw back Value:";
                    ws.Cell(row + 5, 8).Value = h["Drawback"].ToString();

                    ws.Cell(row + 2, 7).Value = "Consignor:";
                    ws.Cell(row + 2, 8).Value = h["consignor"].ToString();

                }
                
                row += 7;
            }

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                int tableStartRow = row;
                ws.Cell(row, 1).Value = "Charge Head";
                ws.Cell(row, 2).Value = "Vendor Name";

                ws.Cell(row, 3).Value = "Expense";
                ws.Range(row, 3, row, 5).Merge();

                ws.Cell(row, 6).Value = "Income";
                ws.Range(row, 6, row, 8).Merge();

                ws.Cell(row, 9).Value = "Profit";
                ws.Range(row, 9, row, 10).Merge();

                var mainHeaderRange = ws.Range(row, 1, row, 10);
                mainHeaderRange.Style
                    .Font.SetBold()
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    .Fill.SetBackgroundColor(XLColor.LightGray)
                    .Border.SetOutsideBorder(XLBorderStyleValues.Thin)
                    .Border.SetInsideBorder(XLBorderStyleValues.Thin);

                row++;

                ws.Cell(row, 3).Value = "Estimate";
                ws.Cell(row, 4).Value = "Reference No.";
                ws.Cell(row, 5).Value = "Amount INR";
                ws.Cell(row, 6).Value = "Estimate";
                ws.Cell(row, 7).Value = "Reference No.";
                ws.Cell(row, 8).Value = "Amount INR";
                ws.Cell(row, 9).Value = "Provisional INR";
                ws.Cell(row, 10).Value = "Actual INR";

               
                ws.Range(row, 3, row, 5).Style
                    .Font.SetBold()
                    .Fill.SetBackgroundColor(XLColor.FromHtml("#9BC2E6")) // Blue
                    .Border.SetOutsideBorder(XLBorderStyleValues.Thin)
                    .Border.SetInsideBorder(XLBorderStyleValues.Thin);

                // Income header (Yellow)
                ws.Range(row, 6, row, 8).Style
                    .Font.SetBold()
                    .Fill.SetBackgroundColor(XLColor.FromHtml("#FFD966")) // Yellow
                    .Border.SetOutsideBorder(XLBorderStyleValues.Thin)
                    .Border.SetInsideBorder(XLBorderStyleValues.Thin);

                // Profit header (Green)
                ws.Range(row, 9, row, 10).Style
                    .Font.SetBold()
                    .Fill.SetBackgroundColor(XLColor.FromHtml("#A9D08E")) // Green
                    .Border.SetOutsideBorder(XLBorderStyleValues.Thin)
                    .Border.SetInsideBorder(XLBorderStyleValues.Thin);


                row++;

                int dataStartRow = row;

                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    ws.Cell(row, 1).Value = dr["CHARGE_HEAD"].ToString();
                    ws.Cell(row, 2).Value = dr["VENDOR_NAME"].ToString();
                    ws.Cell(row, 3).Value = dr["ESTIMATE"].ToString();
                    ws.Cell(row, 4).Value = dr["Bill Ref Number"].ToString();
                    ws.Cell(row, 5).Value = dr["Amount INR"].ToString();
                    ws.Cell(row, 6).Value = dr["ESTIMATE1"].ToString();
                    ws.Cell(row, 7).Value = dr["Bill Ref Number1"].ToString();
                    ws.Cell(row, 8).Value = dr["AMT_INR1"].ToString();
                    ws.Cell(row, 9).Value = dr["Provisional INR"].ToString();
                    ws.Cell(row, 10).Value = dr["Actual INR"].ToString();

                    ws.Range(row, 3, row, 5).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#9BC2E6")); // Expense blue
                    ws.Range(row, 6, row, 8).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#FFD966")); // Income yellow
                    ws.Range(row, 9, row, 10).Style.Fill.SetBackgroundColor(XLColor.FromHtml("#A9D08E")); // Profit green

                    if (dr["CHARGE_HEAD"].ToString().ToUpper() == "TOTAL")
                    {
                        ws.Range(row, 1, row, 10).Style
                            .Font.SetBold()
                            .Fill.SetBackgroundColor(XLColor.LightGray);
                    }

                    row++;
                }

                int dataEndRow = row - 1;
                var dataRange = ws.Range(dataStartRow, 1, dataEndRow, 10);
                dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            }

            ws.Columns().AdjustToContents();

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xlsx");

            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
    }
    public DataSet Charge_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[100];
            param[2] = new SqlParameter("@CHARGE_ID", objUserBL.A1);
            param[3] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[4] = new SqlParameter("@CHARGE_HEAD", objUserBL.A3);
            param[5] = new SqlParameter("@CURRENCY", objUserBL.A4);
            param[6] = new SqlParameter("@CURRENCY_VALUE", objUserBL.A5);
            param[7] = new SqlParameter("@BASIS", objUserBL.A6);
            param[8] = new SqlParameter("@QTY", objUserBL.A7);
            param[9] = new SqlParameter("@UNIT_PRICE", objUserBL.A8);
            param[10] = new SqlParameter("@AMOUNT_INR", objUserBL.A9);
            param[11] = new SqlParameter("@IGST_RATE", objUserBL.A10);
            param[12] = new SqlParameter("@IGST_AMOUNT", objUserBL.A11);
            param[13] = new SqlParameter("@TAX_TYPE", objUserBL.A12);
            param[14] = new SqlParameter("@CGST_RATE", objUserBL.A13);
            param[15] = new SqlParameter("@SGST_RATE", objUserBL.A14);
            param[16] = new SqlParameter("@CGST_AMT", objUserBL.A15);
            param[17] = new SqlParameter("@SGST_AMT", objUserBL.A16);
            param[18] = new SqlParameter("@CHK_CHRG", objUserBL.A17);
            param[19] = new SqlParameter("@DESCRIPTION", objUserBL.A18);
            param[20] = new SqlParameter("@ORDER_BY", objUserBL.A19);
            param[21] = new SqlParameter("@INV_NO", objUserBL.A20);
            param[22] = new SqlParameter("@JOBNO_PS", objUserBL.A21);
            param[23] = new SqlParameter("@ROYAL_OTHER", objUserBL.A22);

            param[24] = new SqlParameter("@CATEGORY", objUserBL.A23);
            param[25] = new SqlParameter("@NARRATION", objUserBL.A24);
            param[26] = new SqlParameter("@REV_RECEIVABLE_TYPE", objUserBL.A25);
            param[27] = new SqlParameter("@REV_RECEIVABLE_FROM", objUserBL.A26);
            param[28] = new SqlParameter("@COST_DESCRIPTION", objUserBL.A27);
            param[29] = new SqlParameter("@COST_QTY", objUserBL.A28);
            param[30] = new SqlParameter("@COST_UNIT_PRICE", objUserBL.A29);
            param[31] = new SqlParameter("@COST_CURRENCY", objUserBL.A30);
            param[32] = new SqlParameter("@COST_CURRENCY_VALUE", objUserBL.A31);
            param[33] = new SqlParameter("@COST_AMOUNT_INR", objUserBL.A32);
            param[34] = new SqlParameter("@COST_CGST_RATE", objUserBL.A33);
            param[35] = new SqlParameter("@COST_CGST_AMT", objUserBL.A34);
            param[36] = new SqlParameter("@COST_SGST_RATE", objUserBL.A35);
            param[37] = new SqlParameter("@COST_SGST_AMT", objUserBL.A36);
            param[38] = new SqlParameter("@COST_IGST_RATE", objUserBL.A37);
            param[39] = new SqlParameter("@COST_IGST_AMOUNT", objUserBL.A38);
            param[40] = new SqlParameter("@COST_PAYABLE_TYPE", objUserBL.A40);
            param[41] = new SqlParameter("@COST_PAYABLE_TO", objUserBL.A41);
            param[42] = new SqlParameter("@COST_EMPLOYEE", objUserBL.A42);

            param[63] = new SqlParameter("@flag", objUserBL.A70);
            param[64] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[65] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[66] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[67] = new SqlParameter("@user_id", Connection.Current_User());
            param[68] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[68].Direction = ParameterDirection.Output;
            param[69] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[69].Direction = ParameterDirection.Output;
            param[70] = new SqlParameter("@Update_Id", SqlDbType.NVarChar, 1000);
            param[70].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_CHA_CHARGE_INS_UPD", param);
            string rersult = param[68].Value.ToString();
            result = Convert.ToInt32(param[69].Value.ToString());
            UPDATE_ID = Convert.ToInt32(param[70].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Bill_To_Shipment_Search(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@SHIPMENT_NO", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[3] = new SqlParameter("@JOBNO_PS", objUserBL.A3);
            param[5] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.A5);
            param[6] = new SqlParameter("@SHIPMENT_PF", objUserBL.A6);
            param[7] = new SqlParameter("@SHIPMENT_SF", objUserBL.A7);
            param[8] = new SqlParameter("@flag", objUserBL.A8);
            param[9] = new SqlParameter("@BRANCH_CODE", Connection.Get_Company_Type());
            param[10] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_BILL_TO_SHIPMENT_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

}