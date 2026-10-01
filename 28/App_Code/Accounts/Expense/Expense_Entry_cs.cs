using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;
using ClosedXML.Excel;

public class Expense_Entry_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet Select_Expense(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[2] = new SqlParameter("@Exp_Id", objUserBL.A1);  //EXP_ID
            param[3] = new SqlParameter("@Ch_Id", objUserBL.A2); //ID
            param[4] = new SqlParameter("@Cus_name", objUserBL.A3); //CustomerName
            param[5] = new SqlParameter("@Refno", objUserBL.A4); //REFNO
            param[6] = new SqlParameter("@Voucher_no", objUserBL.A5); //VOUCHER_NO
            param[7] = new SqlParameter("@Imp_Exp", objUserBL.A6); //BILL_TYPE
            param[8] = new SqlParameter("@Tr_Mode", objUserBL.A7); //MODE
            param[9] = new SqlParameter("@Jobno", objUserBL.A8); //JOBNO
            param[10] = new SqlParameter("@Exp_Job_Amt", objUserBL.A9); //EXPENSE_AMT
            param[11] = new SqlParameter("@Jobno_Ps", objUserBL.A10);

            param[16] = new SqlParameter("@Mflag", objUserBL.A60); //Flag
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_EXPENSE_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Expense_Entry_Search(Global_variables objUserBL)
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
            param[2] = new SqlParameter("@from_date", objUserBL.A1);
            param[3] = new SqlParameter("@to_date", objUserBL.A2);
            param[1] = new SqlParameter("@Cus_name", objUserBL.A3);
            param[4] = new SqlParameter("@Refno", objUserBL.A4);
            param[5] = new SqlParameter("@Voucher_no", objUserBL.A5);
            param[6] = new SqlParameter("@Imp_Exp", objUserBL.A6);
            param[7] = new SqlParameter("@Jobno", objUserBL.A8);
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Flag", objUserBL.A60);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_EXPENSE_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Expense_Ch_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[43];
            param[2] = new SqlParameter("@EXP_ID", objUserBL.A1);  //EXP_ID
            param[3] = new SqlParameter("@CH_ID", objUserBL.A2);
            param[4] = new SqlParameter("@Job_Id", objUserBL.A3); //objUserBL.Ref_ID
            param[5] = new SqlParameter("@Imp_Exp", objUserBL.A4); //Type
            if (objUserBL.A59 == null)
            {
                objUserBL.A59 = string.Empty;
            }
            param[6] = new SqlParameter("@Exp_date", Connection.DATE_FORMAT(objUserBL.A59 == string.Empty ? "01/01/1900" : objUserBL.A59));

            param[7] = new SqlParameter("@Tr_Mode", objUserBL.A7);
            param[8] = new SqlParameter("@Customer_Name", objUserBL.A8);
            param[9] = new SqlParameter("@ExpVoucherNo", objUserBL.A9);

            if (objUserBL.A10 == null)
            {
                objUserBL.A10 = string.Empty;
            }
            param[10] = new SqlParameter("@Jobdate", Connection.DATE_FORMAT(objUserBL.A10 == string.Empty ? "01/01/1900" : objUserBL.A10));

            param[15] = new SqlParameter("@Ref_VoucherNo", objUserBL.A11); //Ref_VoucherNo
            param[16] = new SqlParameter("@Staff_Name", objUserBL.A12); //STAFF_NAME
            param[17] = new SqlParameter("@GivenBy", objUserBL.A13); //GivenBy
            param[18] = new SqlParameter("@Narration", objUserBL.A14); //NARRATION
            param[19] = new SqlParameter("@Exp_Amt", objUserBL.A15);
            param[20] = new SqlParameter("@Line_no", objUserBL.A16); //Line_no
            param[21] = new SqlParameter("@ExpForDetail", objUserBL.A17); //ExpForDetail
            param[22] = new SqlParameter("@TotSubExpAmt", objUserBL.A18); //TotSubExpAmt
            param[23] = new SqlParameter("@Jobno", objUserBL.A19);
            param[24] = new SqlParameter("@Jobno_PS", objUserBL.A20);  //JOB_INFO
            param[25] = new SqlParameter("@File_Ref_No", objUserBL.A21); //FILE_REF_NO
            param[26] = new SqlParameter("@R_O_TYPE", objUserBL.A22); //TYPE
            param[27] = new SqlParameter("@JOB_LICENSE", objUserBL.A23); //BASED_ON
            param[28] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A24); //JOB_WORKINGPERIOD

            param[29] = new SqlParameter("@Job_Exp_Amt", objUserBL.A25); //TotSubExpAmt

            param[34] = new SqlParameter("@xmlString", objUserBL.A59); //Xml_D
            param[35] = new SqlParameter("@flag", objUserBL.A60);
            param[36] = new SqlParameter("@User_Name", Connection.Current_User());
            param[37] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[38] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[39] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;
            param[41] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[41].Direction = ParameterDirection.Output;
            param[42] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[42].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_EXPENSE_INS_UPD", param);
            result = Convert.ToInt32(param[42].Value.ToString());

            if (objUserBL.A60 == "Save" || objUserBL.A60 == "SC" || objUserBL.A60 == "SJ")
            {
                UPDATE_ID = Convert.ToInt32(param[41].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Open_Expense_Tally_Data(string Voucher_RefNo_, string Cus_name_, string JobNO, string Fromdate_, string Todate_, string Month_)
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
        param[3] = new SqlParameter("@Voucher_Ref_No", Voucher_RefNo_);
        param[4] = new SqlParameter("@Cus_Name", Cus_name_);
        param[5] = new SqlParameter("@JobNo", JobNO);

        param[11] = new SqlParameter("@Flag", "Load_Expense_Tally_Data");
        param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
        param[13] = new SqlParameter("@Company_Lic", Connection.Company_License());
        param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[14].Direction = ParameterDirection.Output;

        ds = Connection.Get_Dataset("ACC_GST_EXPENSE_TALLY_DATA", param);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
        }

        string strrptNametime = "EXPENSE_TALLY_DATA" + "_" + Common_CS.Get_Timestamp();
    

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

    public DataSet Expense_Excel_Upload_Ins_Select(Global_variables objUserBL, string xmlString)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[43];
            param[1] = new SqlParameter("@VOUCHER_REFNO", objUserBL.A1);

            param[2] = new SqlParameter("@CHARGE_NAME", objUserBL.A4);

            param[34] = new SqlParameter("@xmlString", xmlString);
            param[35] = new SqlParameter("@flag", objUserBL.A43);
            param[36] = new SqlParameter("@User_Id", Connection.Current_User());
            param[37] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[38] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[39] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_EXPENSE_EXCEL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }



}