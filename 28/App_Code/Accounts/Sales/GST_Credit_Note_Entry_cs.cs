using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;
using ClosedXML.Excel;    

public class GST_Credit_Note_Entry_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    Global_variables ObjUBO = new Global_variables();
    public DataSet Db_Connection(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@ID", objUserBL.A289); //A1
            param[2] = new SqlParameter("@Customer_Name", objUserBL.A290); //A2
            param[3] = new SqlParameter("@Branch_Common", objUserBL.A291); //A3
            param[4] = new SqlParameter("@Company_Lic", objUserBL.A292); //A4
            param[5] = new SqlParameter("@Company_Id", objUserBL.A293); //A5
            param[6] = new SqlParameter("@Type", objUserBL.A294); //A6


            param[8] = new SqlParameter("@Server_Name", objUserBL.A295);//A8
            param[9] = new SqlParameter("@Login_Name", objUserBL.A296);//A9
            param[10] = new SqlParameter("@Login_Pwd", objUserBL.A297); //A10
            param[11] = new SqlParameter("@From_Databse", objUserBL.A298);//A11

            param[12] = new SqlParameter("@WorkingPeriod", objUserBL.A299); //A12
            param[7] = new SqlParameter("@Flag", objUserBL.A300);//A7

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "AUTO_INSTAL_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Select_Inv(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[41];

            param[2] = new SqlParameter("@R_O_TYPE", objUserBL.A1);
            param[3] = new SqlParameter("@JOB_LICENSE", objUserBL.A2);
            param[4] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A3);
            param[5] = new SqlParameter("@Bill_Invno", objUserBL.A4);
            param[6] = new SqlParameter("@Cus_Name", objUserBL.A5);
            param[7] = new SqlParameter("@Branch_No", objUserBL.A6);
            param[8] = new SqlParameter("@Imp_Exp", objUserBL.A7);
            param[9] = new SqlParameter("@xml_Jobnos", objUserBL.A8);
            param[10] = new SqlParameter("@xml_R_Jobno", objUserBL.A9);
            param[11] = new SqlParameter("@Trans_Mode", objUserBL.A10);
            param[12] = new SqlParameter("@From_Quotation", objUserBL.A11);
            param[13] = new SqlParameter("@Bill_Id", objUserBL.A12);
            param[14] = new SqlParameter("@Charge_Name", objUserBL.A13);
            param[15] = new SqlParameter("@Tax_Nontax", objUserBL.A14);
            param[16] = new SqlParameter("@Local_Other", objUserBL.A15);
            param[17] = new SqlParameter("@UNAPPROVAL_APPROVED", objUserBL.A16);

            param[21] = new SqlParameter("@xmlstring_A", objUserBL.A37);
            param[22] = new SqlParameter("@xmlstring_B", objUserBL.A38);
            param[23] = new SqlParameter("@xmlstring_D", objUserBL.A39);
            param[24] = new SqlParameter("@flag", objUserBL.A40);
            param[25] = new SqlParameter("@xmlstring_Gen", objUserBL.A41);
            param[26] = new SqlParameter("@xmlstring_IGM", objUserBL.A42);
            param[27] = new SqlParameter("@xmlstring_Inv", objUserBL.A43);
            param[28] = new SqlParameter("@xmlstring_Item", objUserBL.A44);
            param[29] = new SqlParameter("@xmlstring_BE_SB", objUserBL.A45);

            param[35] = new SqlParameter("@User_Name", Connection.Current_User());
            param[36] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[37] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[38] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[39] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_BILL_CREDIT_NOTE_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Select_Inv(Global_variables objUserBL, string constr)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[41];

            param[2] = new SqlParameter("@R_O_TYPE", objUserBL.A1);
            param[3] = new SqlParameter("@JOB_LICENSE", objUserBL.A2);
            param[4] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A3);
            param[5] = new SqlParameter("@Bill_Invno", objUserBL.A4);
            param[6] = new SqlParameter("@Cus_Name", objUserBL.A5);
            param[7] = new SqlParameter("@Branch_No", objUserBL.A6);
            param[8] = new SqlParameter("@Imp_Exp", objUserBL.A7);
            param[9] = new SqlParameter("@xml_Jobnos", objUserBL.A8);
            param[10] = new SqlParameter("@xml_R_Jobno", objUserBL.A9);
            param[11] = new SqlParameter("@Trans_Mode", objUserBL.A10);
            param[12] = new SqlParameter("@From_Quotation", objUserBL.A11);
            param[13] = new SqlParameter("@Bill_Id", objUserBL.A12);
            param[14] = new SqlParameter("@Charge_Name", objUserBL.A13);
            param[15] = new SqlParameter("@Tax_Nontax", objUserBL.A14);
            param[16] = new SqlParameter("@Local_Other", objUserBL.A15);
            param[17] = new SqlParameter("@UNAPPROVAL_APPROVED", objUserBL.A16);

            param[21] = new SqlParameter("@xmlstring_A", objUserBL.A37);
            param[22] = new SqlParameter("@xmlstring_B", objUserBL.A38);
            param[23] = new SqlParameter("@xmlstring_D", objUserBL.A39);
            param[24] = new SqlParameter("@flag", objUserBL.A40);
            param[25] = new SqlParameter("@xmlstring_Gen", objUserBL.A41);
            param[26] = new SqlParameter("@xmlstring_IGM", objUserBL.A42);
            param[27] = new SqlParameter("@xmlstring_Inv", objUserBL.A43);
            param[28] = new SqlParameter("@xmlstring_Item", objUserBL.A44);
            param[29] = new SqlParameter("@xmlstring_BE_SB", objUserBL.A45);

            param[35] = new SqlParameter("@User_Name", Connection.Current_User());
            param[36] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[37] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[38] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[39] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(constr, CommandType.StoredProcedure, "ACC_GST_BILL_CREDIT_NOTE_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet BILL_INV_SEARCH(Global_variables objUserBL)
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

            ds = Connection.Get_Dataset("ACC_GST_BILL_INV_CREDIT_NOTE_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Billing_Invoice_INS_UPD(Global_variables objUserBL)
    {
        DataSet ds_s = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[81];
            param[1] = new SqlParameter("@ID", objUserBL.A1); //A1
            param[2] = new SqlParameter("@R_O_TYPE", objUserBL.A2);
            param[3] = new SqlParameter("@IMP_EXP", objUserBL.A3);//A2
            param[4] = new SqlParameter("@LOCAL_OTHER", objUserBL.A4);//A3
            param[5] = new SqlParameter("@JOB_COMPANY_LIC", objUserBL.A5);
            param[6] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A6);
            param[7] = new SqlParameter("@CUS_NAME", objUserBL.A7); //A4
            param[8] = new SqlParameter("@CUS_BRANCH_NO", objUserBL.A8);//A5
            param[9] = new SqlParameter("@MODE", objUserBL.A9); //A26
            param[10] = new SqlParameter("@SHIP_TYPE", objUserBL.A10);//A27
            param[11] = new SqlParameter("@FROM_QUOTATION", objUserBL.A11);//A6

            param[14] = new SqlParameter("@BILL_INV_NO", objUserBL.A14);//A8
            if (objUserBL.A15 == null)
            {
                objUserBL.A15 = string.Empty;
            }
            param[15] = new SqlParameter("@BILL_INV_DATE", Connection.DATE_FORMAT(objUserBL.A15 == string.Empty ? "01/01/1900" : objUserBL.A15)); //A9
            param[16] = new SqlParameter("@PARTY_NAME", objUserBL.A16);//A10
            param[17] = new SqlParameter("@AC_BEHALF", objUserBL.A17);//A11
            param[18] = new SqlParameter("@SHIPPER_NAME", objUserBL.A18);//A42
            param[19] = new SqlParameter("@STATE_NAME", objUserBL.A19);//A12
            param[20] = new SqlParameter("@GSTN_ID", objUserBL.A20);//A13
            param[21] = new SqlParameter("@PARTY_ADDRESS", objUserBL.A21);//A14
            param[22] = new SqlParameter("@PO_NO", objUserBL.A22);//A41
            param[23] = new SqlParameter("@ACC_HEAD", objUserBL.A23);//A40
            param[24] = new SqlParameter("@REMARKS", objUserBL.A24);//A44
            param[25] = new SqlParameter("@HSS_CODE", objUserBL.A25);//A46
            param[26] = new SqlParameter("@PARMA_CODE", objUserBL.A26);//A47
            param[27] = new SqlParameter("@WORK_ID", objUserBL.A27);//A48
            param[28] = new SqlParameter("@GRAND_TOTAL", objUserBL.A28);//A20
            param[29] = new SqlParameter("@ADVANCE_AMT", objUserBL.A29);//A21
            param[30] = new SqlParameter("@EXPENSE_AMT", objUserBL.A30);//A22
            param[31] = new SqlParameter("@TOTAL_TAX_AMT", objUserBL.A31);//A22
            param[32] = new SqlParameter("@BANK_DETAILS", objUserBL.A32);//A25
            param[33] = new SqlParameter("@UNAPPROVAL_APPROVED", objUserBL.A33);//A43
            param[34] = new SqlParameter("@TAX_NON_TAX", objUserBL.A34);
            param[35] = new SqlParameter("@CUS_BRANCH_NO_LOC", objUserBL.A35); //A23
            param[36] = new SqlParameter("@JOB_TYPE", objUserBL.A36); //A23
            param[37] = new SqlParameter("@NON_TAX_AMT", objUserBL.A37);//A19
            param[38] = new SqlParameter("@TAX_AMT", objUserBL.A38);//A18
            param[39] = new SqlParameter("@JOB_STATUS", objUserBL.A39);
            param[40] = new SqlParameter("@CR_BILL_INV_NO", objUserBL.A40); //A23
            if (objUserBL.A41 == null)
            {
                objUserBL.A41 = string.Empty;
            }
            param[41] = new SqlParameter("@CR_BILL_INV_DATE", Connection.DATE_FORMAT(objUserBL.A41 == string.Empty ? "01/01/1900" : objUserBL.A41)); //A9

            param[67] = new SqlParameter("@xmlString_Job", objUserBL.A73);//A35
            param[68] = new SqlParameter("@xmlString_Gen", objUserBL.A74);//A35
            param[69] = new SqlParameter("@xmlString_IGM", objUserBL.A75);//A35
            param[70] = new SqlParameter("@xmlString_Inv", objUserBL.A76);//A36
            param[71] = new SqlParameter("@xmlString_Item", objUserBL.A77);//A37
            param[72] = new SqlParameter("@xmlString_BE_SB", objUserBL.A78);//A38
            param[73] = new SqlParameter("@xmlString_Charge", objUserBL.A79);//A38
            param[74] = new SqlParameter("@flag", objUserBL.A80);//A39

            param[75] = new SqlParameter("@Company_Lic", Connection.Company_License());
            param[76] = new SqlParameter("@USER_NAME", Connection.Current_User());
            param[77] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[78] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[79] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[80] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[80].Direction = ParameterDirection.Output;
            
            ds_s = Connection.Get_Dataset("ACC_GST_BILL_INVOICE_CREDIT_NOTE_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds_s;
    }
    public DataSet Select_Imp_Exp_Data(Global_variables objUserBL, string constr)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[51];

            param[2] = new SqlParameter("@R_O_TYPE", objUserBL.A1);
            param[3] = new SqlParameter("@JOB_LICENSE", objUserBL.A2);
            param[4] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A3);

            param[5] = new SqlParameter("@Bill_Invno", objUserBL.A4);
            param[6] = new SqlParameter("@Bill_Id", objUserBL.A5);
            param[7] = new SqlParameter("@Imp_Exp", objUserBL.A6);
            param[8] = new SqlParameter("@Cus_Name", objUserBL.A7);
            param[9] = new SqlParameter("@Branch_No", objUserBL.A8);
            param[10] = new SqlParameter("@Local_Other", objUserBL.A9);
            param[11] = new SqlParameter("@From_Quotation", objUserBL.A10);
            param[12] = new SqlParameter("@xml_Jobnos", objUserBL.A11);
            param[13] = new SqlParameter("@Ship_Type_1", objUserBL.A12);
            param[14] = new SqlParameter("@Ship_Type_2", objUserBL.A13);


            param[42] = new SqlParameter("@xmlstring_A", objUserBL.A47);
            param[43] = new SqlParameter("@xmlstring_B", objUserBL.A48);
            param[44] = new SqlParameter("@xmlstring_D", objUserBL.A49);

            param[46] = new SqlParameter("@flag", objUserBL.A50);
            param[47] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[48] = new SqlParameter("@Company_Lic", Connection.Company_License());

            param[50] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[50].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(constr, CommandType.StoredProcedure, objUserBL.A46, param);
        }
        catch (Exception ex)
        { 
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Invoice_Job_Rpt_data(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Bill_Inv_No", objUserBL.A3);
            param[1] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset(objUserBL.A9, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public void open_Credit_Tally_Data(string ddlSearch_Cat, string txtsearch, string Imp_name, string Fromdate_, string Todate_, string Month_, string Ip_Ep,
        string flag)
    {
        HttpResponse Response = HttpContext.Current.Response;
        Global_variables ObjUBO = new Global_variables();
        DataTable dt = new DataTable();


        string[] arr = new string[] { };
        string[] arr2 = new string[] { };

        if (Fromdate_ != string.Empty && Fromdate_ != null)
        {
            arr = Fromdate_.Split('/');
            Fromdate_ = arr[1] + '/' + arr[0] + '/' + arr[2];
        }
        if (Todate_ != string.Empty && Todate_ != null)
        {
            arr2 = Todate_.Split('/');
            Todate_ = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
        }


        //--------------------------------------------------------------------------------------------
        SqlParameter[] param = new SqlParameter[15];
        param[1] = new SqlParameter("@from_date", Fromdate_);
        param[2] = new SqlParameter("@to_date", Todate_);
        param[3] = new SqlParameter("@Cus_name", Imp_name);
        param[4] = new SqlParameter("@Search_Cat", ddlSearch_Cat);
        param[5] = new SqlParameter("@Search_Item", txtsearch);
        param[6] = new SqlParameter("@Imp_Exp", Ip_Ep);
        param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
        param[8] = new SqlParameter("@flag", flag);
        param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[9].Direction = ParameterDirection.Output;

        ds = Connection.Get_Dataset("ACC_GST_BILL_INV_CREDIT_NOTE_TALLY_DATA", param);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
        }

        string strrptNametime = "CREDIT_TALLY_DATA" + "_" + Common_CS.Get_Timestamp();
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

}