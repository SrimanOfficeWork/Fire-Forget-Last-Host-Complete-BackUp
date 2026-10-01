using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;
using ClosedXML.Excel;
public class Purchase_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet Purchase_Entry_Search(Global_variables objUserBL)
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
            param[3] = new SqlParameter("@VOUCHER_NO", objUserBL.A3);
            param[4] = new SqlParameter("@VENDOR_NAME", objUserBL.A4);

            param[5] = new SqlParameter("@Flag", objUserBL.A10);
            param[13] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_PURCHASE_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Purchase_Entry_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@V_ID", objUserBL.A1); //VOUCHER_ID
            param[2] = new SqlParameter("@VOUCHER_NO", objUserBL.A2); //VOUCHER_NO
            param[3] = new SqlParameter("@VENDOR_NAME", objUserBL.A3); //VENDOR_NAME
            param[4] = new SqlParameter("@VENDOR_BR_NO", objUserBL.A4); //BR_CODE_LOCATION
            param[5] = new SqlParameter("@BILL_TYPE", objUserBL.A5); //BILL_TYPE
            param[6] = new SqlParameter("@DEBIT_CREDIT_AMT", objUserBL.A6); //TAXABLE_AMT
            param[7] = new SqlParameter("@CGST_AMOUNT", objUserBL.A7);//CGST_AMOUNT
            param[8] = new SqlParameter("@SGST_AMOUNT", objUserBL.A8); //SGST_AMOUNT
            param[9] = new SqlParameter("@IGST_AMOUNT", objUserBL.A9);//IGST_AMOUNT
            param[10] = new SqlParameter("@TDS_AMOUNT", objUserBL.A10); //MIN_AMT
            param[11] = new SqlParameter("@CAHRGE_NAME", objUserBL.A11); //MIN_AMT
            param[12] = new SqlParameter("@TAX_MODE", objUserBL.A12); //MIN_AMT
            
            param[16] = new SqlParameter("@Selected_Group_Id", objUserBL.A18); //MIN_AMT
            param[17] = new SqlParameter("@Flag", objUserBL.A19);
            param[18] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_PURCHASE_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Purchase_Entry_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[70];

            param[2] = new SqlParameter("@V_ID", objUserBL.A1); //ID
            param[3] = new SqlParameter("@BILL_TYPE", objUserBL.A2); //BILL_TYPE
            param[4] = new SqlParameter("@VOUCHER_NO", objUserBL.A3); //VOUCHER_NO
            param[5] = new SqlParameter("@VOUCHER_DATE", Connection.DATE_FORMAT(objUserBL.A4)); //VOUCHER_DATE
            param[6] = new SqlParameter("@VENDOR_NAME", objUserBL.A5); //VENDOR_NAME
            param[7] = new SqlParameter("@VENDOR_BRANCH", objUserBL.A6); //VENDOR_BRANCH
            param[8] = new SqlParameter("@VENDOR_STATE", objUserBL.A7); //VENDOR_STATE
            param[9] = new SqlParameter("@GSTN_NO", objUserBL.A8); //GSTN
            param[10] = new SqlParameter("@GSTN_TYPE", objUserBL.A9);//GSTN_TYPE
            param[11] = new SqlParameter("@COUNTRY_CODE", objUserBL.A10); //COUNTRY
            param[12] = new SqlParameter("@VENDOR_BILL_NO", objUserBL.A11); //VENDOR_BILL
            param[14] = new SqlParameter("@VENDOR_BILL_DATE", Connection.DATE_FORMAT(objUserBL.A12)); //BILL_DATE
            param[15] = new SqlParameter("@BILL_AMOUNT", objUserBL.A13); //BILL_AMOUNT
            param[16] = new SqlParameter("@BILL_CUR", objUserBL.A14); //CURRENCY
            param[17] = new SqlParameter("@EX_RATE", objUserBL.A15); //EX_RATE
            param[18] = new SqlParameter("@AMT_IN_INR", objUserBL.A16); //AMT_IN_INR
            param[19] = new SqlParameter("@REMARKS", objUserBL.A17); //REMARKS

            param[20] = new SqlParameter("@DEBIT_CREDIT", objUserBL.A18); //CR_DR
            param[21] = new SqlParameter("@SLNO", objUserBL.A19); //Ref_ID
            param[23] = new SqlParameter("@C_ID", objUserBL.A20); //Charge_Id
            param[24] = new SqlParameter("@IMP_EXP", objUserBL.A21); //Imp_Exp
            param[25] = new SqlParameter("@JOBNO", objUserBL.A22); //JOBNO
            param[26] = new SqlParameter("@JOB_DATE", Connection.DATE_FORMAT(objUserBL.A23)); //JOBDATE
            param[27] = new SqlParameter("@CUS_NAME", objUserBL.A24); //CustomerName
            param[28] = new SqlParameter("@CHARGE_NAME", objUserBL.A25); //charge_name
            param[29] = new SqlParameter("@TAX_RATE", objUserBL.A26); //IGST_RATE
            param[30] = new SqlParameter("@DEBIT_CREDIT_AMT", objUserBL.A27); //TAXABLE_AMT
            param[31] = new SqlParameter("@TDS_RATE", objUserBL.A28); //TDS_RATE
            param[32] = new SqlParameter("@CGST_AMOUNT", objUserBL.A29); //CGST_AMOUNT
            param[33] = new SqlParameter("@SGST_AMOUNT", objUserBL.A30); //SGST_AMOUNT
            param[34] = new SqlParameter("@IGST_AMOUNT", objUserBL.A31); //IGST_AMOUNT
            param[35] = new SqlParameter("@TDS_AMOUNT", objUserBL.A32); //MIN_AMT

            param[36] = new SqlParameter("@R_O_TYPE", objUserBL.A33);
            param[37] = new SqlParameter("@JOB_LICENSE", objUserBL.A34);
            param[38] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A35);
            param[39] = new SqlParameter("@JOBNO_PS", objUserBL.A36);
            param[40] = new SqlParameter("@UNDER_NAME", objUserBL.A37);

            param[41] = new SqlParameter("@S_GROUP_NAME", objUserBL.A38);
            param[42] = new SqlParameter("@S_GROUP_ID", objUserBL.A39);
            param[43] = new SqlParameter("@REG_SEZ", objUserBL.A40);
            param[44] = new SqlParameter("@TDS_DEDUCTION", objUserBL.A41);
            param[45] = new SqlParameter("@POSTING_DATE", Connection.DATE_FORMAT(objUserBL.A42)); //POSTING_DATE

            param[46] = new SqlParameter("@PB_NO_F", objUserBL.A43);
            param[47] = new SqlParameter("@PB_NO_L", objUserBL.A44);

            param[62] = new SqlParameter("@Flag", objUserBL.A49); //Flag
            param[63] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[64] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[65] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[66] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());

            param[67] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[67].Direction = ParameterDirection.Output;

            param[68] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[68].Direction = ParameterDirection.Output;

            param[69] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[69].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_PURCHASE_INS_UPD", param);
            result = Convert.ToInt32(param[47].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Open_Purchase_Tally_Data(string txtVenBillno_, string Vendor_name_, string Fromdate_, string Todate_, string Month_)
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
        //--------------------------------------------------------------------------------------------
        SqlParameter[] param = new SqlParameter[15];
        param[1] = new SqlParameter("@from_date", Common_CS.Get_Arrange_Date(ObjUBO.A1));
        param[2] = new SqlParameter("@to_date", Common_CS.Get_Arrange_Date(ObjUBO.A2));
        param[3] = new SqlParameter("@Vendor_name", Vendor_name_);
        param[4] = new SqlParameter("@Search_Item", txtVenBillno_);

        param[11] = new SqlParameter("@Flag", "Load_Purchase_Tally_Data");
        param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
        param[13] = new SqlParameter("@Company_Lic", Connection.Company_License());
        param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[14].Direction = ParameterDirection.Output;

        ds = Connection.Get_Dataset("ACC_GST_PURCHASE_TALLY_DATA", param);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
        }

        string strrptNametime = "PURCHASE_TALLY_DATA" + "_" + Common_CS.Get_Timestamp();
        HttpResponse Response = HttpContext.Current.Response;
        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(ds.Tables[0], "PURCHASE_TALLYDATA" + "_" + Common_CS.Get_Timestamp());

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
}