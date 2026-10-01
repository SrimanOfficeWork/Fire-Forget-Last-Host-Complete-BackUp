using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;

public class GST_Billing_Paramount
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    Global_variables ObjUBO = new Global_variables();

    public DataSet Select_Inv(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[2] = new SqlParameter("@Bill_Invno", objUserBL.A1);
            param[3] = new SqlParameter("@Cus_Name", objUserBL.A2);
            param[4] = new SqlParameter("@Branch_No", objUserBL.A3);
            param[5] = new SqlParameter("@Jobno", objUserBL.A4);
            param[6] = new SqlParameter("@Trans_Mode", objUserBL.A5);
            param[7] = new SqlParameter("@From_Quotation", objUserBL.A6);
            param[8] = new SqlParameter("@Imp_Exp", objUserBL.A7);
            param[9] = new SqlParameter("@Mflag", objUserBL.A8);
           
            param[10] = new SqlParameter("@xmlstring_A", objUserBL.A9);
            param[11] = new SqlParameter("@xmlstring_B", objUserBL.A10);
            param[12] = new SqlParameter("@xmlstring_D", objUserBL.A11);

            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@Wrk_period", Connection.WorkingPeriod());
            param[19] = new SqlParameter("@Company_Lic", Connection.Company_License());
            
            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("GST_BILL_PARAMOUNT_INV_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Select_Imp_Exp_Data(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[2] = new SqlParameter("@Bill_Invno", objUserBL.A1);
            param[3] = new SqlParameter("@Cus_Name", objUserBL.A2);
            param[4] = new SqlParameter("@Branch_No", objUserBL.A3);
            param[5] = new SqlParameter("@Jobno", objUserBL.A4);
            param[6] = new SqlParameter("@Trans_Mode", objUserBL.A5);
            param[7] = new SqlParameter("@From_Quotation", objUserBL.A6);
            param[8] = new SqlParameter("@Imp_Exp", objUserBL.A7);
            param[9] = new SqlParameter("@Mflag", objUserBL.A8);

            param[10] = new SqlParameter("@xmlstring_A", objUserBL.A9);
            param[11] = new SqlParameter("@xmlstring_B", objUserBL.A10);
            param[12] = new SqlParameter("@xmlstring_D", objUserBL.A11);
            param[13] = new SqlParameter("@Local_Other", objUserBL.A12);

            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@Wrk_period", Connection.WorkingPeriod());
            param[19] = new SqlParameter("@Company_Lic", Connection.Company_License());

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset(objUserBL.A15, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Billing_Invoice_INS_UPD(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[71];
            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@IMP_EXP", objUserBL.A2);
            param[3] = new SqlParameter("@LOCAL_OTHER", objUserBL.A3);
            param[4] = new SqlParameter("@CUS_NAME", objUserBL.A4);
            param[5] = new SqlParameter("@CUS_BRANCH_NO", objUserBL.A5);

            param[6] = new SqlParameter("@FROM_QUOTATION", objUserBL.A6);
            param[7] = new SqlParameter("@JOBNO", objUserBL.A7);
            param[8] = new SqlParameter("@BILL_INV_NO", objUserBL.A8);

            if (objUserBL.A9 == null)
            {
                objUserBL.A9 = string.Empty;
            }
            param[9] = new SqlParameter("@BILL_INV_DATE", Connection.DATE_FORMAT(objUserBL.A9 == string.Empty ? "01/01/1900" : objUserBL.A9));
            param[10] = new SqlParameter("@PARTY_NAME", objUserBL.A10);
            param[11] = new SqlParameter("@AC_BEHALF", objUserBL.A11);
            param[12] = new SqlParameter("@STATE_NAME", objUserBL.A12);
            param[13] = new SqlParameter("@GSTN_ID", objUserBL.A13);
            param[14] = new SqlParameter("@PARTY_ADDRESS", objUserBL.A14);

            param[15] = new SqlParameter("@CUS_BRANCH_NO_LOC", objUserBL.A23);
            param[16] = new SqlParameter("@TAX_NON_TAX", objUserBL.A24);
            param[17] = new SqlParameter("@BANK_DETAILS", objUserBL.A25);

            param[18] = new SqlParameter("@MODE", objUserBL.A26);
            param[19] = new SqlParameter("@SHIP_TYPE", objUserBL.A27);

            param[27] = new SqlParameter("@NON_TAXABLE_AMT", objUserBL.A15);
            param[28] = new SqlParameter("@TAXABLE_AMT", objUserBL.A16);
            param[29] = new SqlParameter("@TOT_REVERSE_TAX_AMT", objUserBL.A17);
            param[30] = new SqlParameter("@TOTAL_TAX_AMT", objUserBL.A18);
            param[31] = new SqlParameter("@TOTAL_AMT_TAX", objUserBL.A19);
            param[32] = new SqlParameter("@GRAND_TOTAL", objUserBL.A20);
            param[33] = new SqlParameter("@ADVANCE_AMT", objUserBL.A21);
            param[34] = new SqlParameter("@EXPENSE_AMT", objUserBL.A22);

            param[35] = new SqlParameter("@JOB_STATUS", "");
            param[36] = new SqlParameter("@ACC_HEAD", objUserBL.A40);
            param[37] = new SqlParameter("@JOB_WORKINGPERIOD", "");
            param[38] = new SqlParameter("@xmlString_A", objUserBL.A35);
            param[39] = new SqlParameter("@xmlString_B", objUserBL.A36);
            param[40] = new SqlParameter("@xmlString", objUserBL.A37);
            param[41] = new SqlParameter("@xmlString_D", objUserBL.A38);
            param[42] = new SqlParameter("@flag", objUserBL.A39);
            param[43] = new SqlParameter("@PO_NO", objUserBL.A41);
            param[44] = new SqlParameter("@SHIPPER_NAME", objUserBL.A42);

            param[66] = new SqlParameter("@USER_NAME", Connection.Current_User());
            param[67] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[68] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[69] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            
            param[70] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[70].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_INVOICE_INS_UPD", param);
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

            ds = Connection.Get_Dataset("GST_BILL_INV_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void Open_GST_IMP_EXP_COMBINED_Tally_Data(string ddlSearch_Cat_, string txtsearch_, string Imp_name_, string Fromdate_, string Todate_, string Month_, string _Type,string IMP_EXP_)
    {

        String xmlData1 = string.Empty;
        String xmlData2 = string.Empty;
        Global_variables ObjUBO = new Global_variables();
        HttpResponse Response = HttpContext.Current.Response;
        string Filename = "";

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

        if (ddlSearch_Cat_ == "0" || txtsearch_ == "")
        {
            ObjUBO.A4 = "";
            ObjUBO.A5 = "";
        }
        else
        {
            ObjUBO.A4 = ddlSearch_Cat_;
            ObjUBO.A5 = txtsearch_;
        }
        ObjUBO.A3 = Imp_name_;
        ObjUBO.A6 = IMP_EXP_;

        if (_Type == "T")
        {
            ObjUBO.A7 = "Load_Tally_Data";
            Filename = "TALLY_DATA";
        }
        DataSet dss = new DataSet();

        DataSet dss1 = new DataSet();
        DataSet dss2 = new DataSet();

        if (Connection.Company_License().ToUpper() == "ERI00375")
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (ObjUBO.A1 != string.Empty && ObjUBO.A1 != null)
            {
                arr = ObjUBO.A1.Split('/');
                ObjUBO.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (ObjUBO.A2 != string.Empty && ObjUBO.A2 != null)
            {
                arr2 = ObjUBO.A2.Split('/');
                ObjUBO.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }
            
            dss1 = Tally_Data_Sub(ObjUBO, "CusHouse, Tuticorin", ObjUBO.A1, ObjUBO.A2);
            if (dss1.Tables[0].Rows.Count > 0)
            {
                xmlData1 = Common_CS.ConvertDataTableToXML(dss1.Tables[0]);
            }
            dss2 = Tally_Data_Sub(ObjUBO, "ICD, TUTICORIN", ObjUBO.A1, ObjUBO.A2);
            if (dss2.Tables[0].Rows.Count > 0)
            {
                xmlData2 = Common_CS.ConvertDataTableToXML(dss2.Tables[0]);
            }
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@xmlString_A", xmlData1);
            param[2] = new SqlParameter("@xmlString_B", xmlData2);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            dss = Connection.Get_Dataset("COMBINE_TALLY_DATA", param);
            
        }
        else if (Connection.Company_License().ToUpper() == "ERI00293")//common wise
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (ObjUBO.A1 != string.Empty && ObjUBO.A1 != null)
            {
                arr = ObjUBO.A1.Split('/');
                ObjUBO.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (ObjUBO.A2 != string.Empty && ObjUBO.A2 != null)
            {
                arr2 = ObjUBO.A2.Split('/');
                ObjUBO.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }
            dss = Tally_Data_Sub(ObjUBO, "", ObjUBO.A1, ObjUBO.A2);
        }
        else
        {
            dss = BILL_INV_SEARCH(ObjUBO);
        }
        DataTable dt = new DataTable();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss

        string strrptNametime = Filename + "_" + s;
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
    public DataSet Tally_Data_Sub(Global_variables objUserBL ,string Branch ,string From_date,string To_date)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@from_date", From_date);
            param[2] = new SqlParameter("@to_date", To_date);
            param[3] = new SqlParameter("@Cus_name", objUserBL.A3);
            param[4] = new SqlParameter("@Search_Cat", objUserBL.A4);
            param[5] = new SqlParameter("@Search_Item", objUserBL.A5);
            param[6] = new SqlParameter("@Imp_Exp", objUserBL.A6);
            param[7] = new SqlParameter("@Branch_Common", Branch);
            param[8] = new SqlParameter("@Flag", objUserBL.A7);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_INV_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Tally_Data_Join(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[1] = new SqlParameter("@xmlString_A", objUserBL.A35);
            param[2] = new SqlParameter("@xmlString_B", objUserBL.A36);
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("COMBINE_TALLY_DATA", param);
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
   public DataSet Billing_Data(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A3 != string.Empty && objUserBL.A3 != null)
            {
                arr = objUserBL.A3.Split('/');
                objUserBL.A3 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A4 != string.Empty && objUserBL.A4 != null)
            {
                arr2 = objUserBL.A4.Split('/');
                objUserBL.A4 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Imp_Exp", objUserBL.A1);
            param[2] = new SqlParameter("@Cus_Name", objUserBL.A2);
            param[3] = new SqlParameter("@from_date", objUserBL.A3);
            param[4] = new SqlParameter("@to_date", objUserBL.A4);

            param[5] = new SqlParameter("@Invno", objUserBL.A5);
            param[6] = new SqlParameter("@Jobno", objUserBL.A6);
            param[7] = new SqlParameter("@Charge_Name", objUserBL.A7);

            param[8] = new SqlParameter("@Flag", objUserBL.A8);
            param[13] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset(objUserBL.A10, param);
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}