using System;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;

using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;

public class GST_Bill_Consolidate
{
    DataSet ds = new DataSet();
    public int result = 0, UPDATE_ID = 0;

    public DataSet GST_Bill_Consolidate_Select(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Customer_Name", objUserBL.Imp_Name);
            param[2] = new SqlParameter("@REF_NAME", objUserBL.CHARGE_NAME);
            param[3] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);
            param[4] = new SqlParameter("@Flag", objUserBL.Flag);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[8] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("GST_BILL_CONSOLIDATE_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Invoice_Job_Rpt_data(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
           
            param[1] = new SqlParameter("@BILL_INV_NO", objUserBL.BILL_INV_NO);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Combine_Invoice_Job_Rpt_data(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Bill_ID", objUserBL.ID);
            param[1] = new SqlParameter("@Bill_Inv_No", objUserBL.BILL_INV_NO);
            param[2] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Imp_Exp_Invoice_INS_UPD(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[45];

            param[0] = new SqlParameter("@ID", objUserBL.ID);
            param[1] = new SqlParameter("@IMP_EXP", objUserBL.TYPE);
            param[2] = new SqlParameter("@LOCAL_OTHER", objUserBL.TYPE_OF_INVOICE);

            param[4] = new SqlParameter("@CUSTOMER_NAME", objUserBL.SHIPPER_ADDRESS);
            param[5] = new SqlParameter("@BRANCH_DETAILS", objUserBL.Branch_No_Loc);
            param[7] = new SqlParameter("@BILL_INV_NO", objUserBL.BILL_INV_NO);
            if (objUserBL.BILL_INV_DATE == null)
            {
                objUserBL.BILL_INV_DATE = string.Empty;
            }
            param[9] = new SqlParameter("@BILL_INV_DATE", Connection.DATE_FORMAT(objUserBL.BILL_INV_DATE == string.Empty ? "01/01/1900" : objUserBL.BILL_INV_DATE));

            param[10] = new SqlParameter("@CHA_JOBNO", objUserBL.CH_DESCRIPTION);
            param[11] = new SqlParameter("@FILE_REF_NO", objUserBL.FILE_REF_NO);
            param[12] = new SqlParameter("@MANUAL_JOBNO", objUserBL.YOUR_REF);
            param[13] = new SqlParameter("@CHA_JOB_DETAILS", objUserBL.DESTINATION);
            param[14] = new SqlParameter("@TO_CUSTOMER_NAME", objUserBL.NOTIFY_PARTY_1);
            param[15] = new SqlParameter("@CUSTOMER_ADDRESS", objUserBL.NOTIFY_PARTY_1_ADDRESS);
            param[16] = new SqlParameter("@REMARKS", objUserBL.REMARKS);
            param[17] = new SqlParameter("@NON_TAXABLE_AMT", objUserBL.NON_TAXABLE_AMT);
            param[20] = new SqlParameter("@TAXABLE_AMT", objUserBL.TAXABLE_AMT);
            param[21] = new SqlParameter("@TOTAL_TAX_AMT", objUserBL.TOTAL_TAX_AMT);
            param[22] = new SqlParameter("@TOTAL_AMT_TAX", objUserBL.TOTAL_AMT_TAX);

            param[25] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[26] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[27] = new SqlParameter("@USERID", Connection.Current_User());

            param[30] = new SqlParameter("@STATE_NAME", objUserBL.State_Name);
            param[31] = new SqlParameter("@GSTN_ID", objUserBL.GSTN_ID);


            param[32] = new SqlParameter("@xmlString", objUserBL.Xml_D);
            param[33] = new SqlParameter("@flag", objUserBL.Flag);

            param[35] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[35].Direction = ParameterDirection.Output;

            param[36] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[36].Direction = ParameterDirection.Output;

            param[37] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[37].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("GST_BILL_IMP_EXP_JOB_CONSOLIDATED_INS_UPD", param);
            result = Convert.ToInt32(param[35].Value.ToString());

            if (objUserBL.Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[37].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void GST_BILL_CONSOLIDATE_DML(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[100];

            param[1] = new SqlParameter("@C_ID",objUserBL.ID);
            param[2] = new SqlParameter("@Customer_Name", objUserBL.Imp_Name);

            param[3] = new SqlParameter("@R_ID", objUserBL.Party_Ref);
            param[4] = new SqlParameter("@REF_NAME", objUserBL.SHIPMENT_TYPE);

            param[5] = new SqlParameter("@BILL_INV_NO", objUserBL.BILL_INV_NO);
            if (objUserBL.BILL_INV_DATE == null)
            {
                objUserBL.BILL_INV_DATE = string.Empty;
            }
            param[6] = new SqlParameter("@BILL_INV_DATE", Connection.DATE_FORMAT(objUserBL.BILL_INV_DATE == string.Empty ? "01/01/1900" : objUserBL.BILL_INV_DATE));
            param[7] = new SqlParameter("@Values", objUserBL.CHARGE_NAME);
            param[8] = new SqlParameter("@Flag", objUserBL.Flag);
            param[9] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);

            param[10] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[11] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[12] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[13] = new SqlParameter("@Branch_Code", Connection.Get_Company_Type());
            param[14] = new SqlParameter("@Userid", Connection.Current_User());

            param[20] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;

            param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[21].Direction = ParameterDirection.Output;

            param[22] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[22].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_CONSOLIDATE_DML", param);
            result = Convert.ToInt32(param[20].Value.ToString());

            if (objUserBL.Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[22].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
   
    public DataSet GST_BILL_CONSOLIDATE_SEARCH(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[20];

            param[1] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);
            param[2] = new SqlParameter("@Customer_Name", objUserBL.Imp_Name);

            param[3] = new SqlParameter("@from_date", objUserBL.from_date);
            param[4] = new SqlParameter("@to_date", objUserBL.todate);

            param[5] = new SqlParameter("@REF_NAME", objUserBL.SHIPMENT_TYPE);
            param[6] = new SqlParameter("@BILL_INV_NO", objUserBL.BILL_INV_NO);

            param[10] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[11] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_CONSOLIDATE_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet IMP_EXP_Month(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@StartDate", objUserBL.from_date);
            param[1] = new SqlParameter("@EndDate", objUserBL.todate);
            param[2] = new SqlParameter("@Flag", objUserBL.Flag);
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("BILL_IMP_EXP_MONTHS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet BILL_IMPORT_JOB_INV_SEARCH(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Shipper_name", objUserBL.Imp_Name);
            param[2] = new SqlParameter("@from_date", objUserBL.from_date);
            param[3] = new SqlParameter("@to_date", objUserBL.todate);
            param[4] = new SqlParameter("@Search_Cat", objUserBL.CHARGE_NAME);
            param[5] = new SqlParameter("@Search_Item", objUserBL.CONSIGNEE_NAME);
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@COMPANYID", Connection.COMPANYID());
            param[10] = new SqlParameter("@Flag", objUserBL.Flag);

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_IMP_EXP_JOB_CONSOLIDATED_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public void Open_GST_IMP_Tally_Data_COMBINED(string ddlSearch_Cat_, string txtsearch_, string Imp_name_, string Fromdate_, string Todate_, string Month_, string _Type)
    {
        Billing_UserBO objUserBL = new Billing_UserBO();
        HttpResponse Response = HttpContext.Current.Response;
        string Filename = "";

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            objUserBL.from_date = Fromdate_;
            objUserBL.todate = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                objUserBL.from_date = arr_Month[0];
                objUserBL.todate = arr_Month[1];
            }
            else
            {
                objUserBL.from_date = Fromdate_;
                objUserBL.todate = Todate_;
            }
        }

        if (ddlSearch_Cat_ == "0" || txtsearch_ == "")
        {
            objUserBL.CHARGE_NAME = "";
            objUserBL.CONSIGNEE_NAME = "";
        }
        else
        {
            objUserBL.CHARGE_NAME = ddlSearch_Cat_;
            objUserBL.CONSIGNEE_NAME = txtsearch_;
        }

        objUserBL.Imp_Name = Imp_name_;

        if (_Type == "T")
        {
            objUserBL.Flag = "Tally_Data";
            Filename = "IMPORT_TALLY_DATA";
        }
        else
        {
            objUserBL.Flag = "Grid_Search";
            Filename = "IMPORT_Grid_Data";
        }

        DataSet dss = BILL_IMPORT_JOB_INV_SEARCH(objUserBL);
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
}
