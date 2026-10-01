using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;
using System.Data.SqlClient;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;

public partial class Acc_Purchase_Rpt : ThemeClass
{
    AppSession aps = new AppSession();

    Acc_Gen_Reports AG = new Acc_Gen_Reports();
    Global_variables ObjUBO = new Global_variables();

    string[] arr_Month = new string[] { };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_Month();
        }

    }
    public void Load_Month()
    {
        try
        {
        DataSet ds = new DataSet();
        ds.Clear();
        ds = Common_CS.Load_Month();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlmonth.DataSource = ds.Tables[0];
            ddlmonth.DataTextField = "TheMonth";
            ddlmonth.DataValueField = "TheMonth_No";
            ddlmonth.DataBind();

            ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
            ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        }
        }
    catch (Exception ex)
    {
        Connection.Error_Msg(ex.Message);
    }
    }
    public void load_Cus_name()
    {
        try
        {
            ddlvendor.Items.Clear();
            ddlvendorBill.Items.Clear();
            DataSet dss = new DataSet();
            ObjUBO.A4 = "VENDOR_NAME_CHARGE";
            dss = AG.Acc_Purchase_entry_Rpt(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlvendor.DataSource = dss.Tables[0];
                ddlvendor.DataTextField = "VENDOR_NAME";
                ddlvendor.DataValueField = "VENDOR_NAME";
                ddlvendor.DataBind();


                ddlvendorBill.DataSource = dss.Tables[1];
                ddlvendorBill.DataTextField = "VENDOR_BILL_NO";
                ddlvendorBill.DataValueField = "VENDOR_BILL_NO";
                ddlvendorBill.DataBind();
            }

            if (dss.Tables[1].Rows.Count > 0)
            {
                ddlchargename.DataSource = dss.Tables[2];
                ddlchargename.DataTextField = "CHARGE_NAME";
                ddlchargename.DataValueField = "CHARGE_NAME";
                ddlchargename.DataBind();


                ddljobno.DataSource = dss.Tables[3];
                ddljobno.DataTextField = "JOBNO";
                ddljobno.DataValueField = "JOBNO_PS";
                ddljobno.DataBind();
            }

            ddlvendor.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlvendor.SelectedIndex = 0;
            ddlvendorBill.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlvendorBill.SelectedIndex = 0;

            ddlchargename.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlchargename.SelectedIndex = 0;
            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_Rpt_type.SelectedValue.ToString() != string.Empty)
            {
                Load_Rpt_Data(ddl_Rpt_type.SelectedValue.ToString());
            }
            else
            {
                Alert_msg("Please select a value from the Based On ");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Load_Rpt_Data(string Report_Type)
    {
        try
        {
            DataSet ds1 = new DataSet();


            if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
            {
                ObjUBO.A1 = txtfromdate.Text;
                ObjUBO.A2 = txttodate.Text;
            }
            else
            {
                if (ddlmonth.SelectedItem.Text != string.Empty)
                {
                    arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                    ObjUBO.A1 = arr_Month[0];
                    ObjUBO.A2 = arr_Month[1];
                }
                else
                {
                    ObjUBO.A1 = txtfromdate.Text;
                    ObjUBO.A2 = txttodate.Text;
                }
            }


            ObjUBO.A5 = ddlvendor.SelectedValue;
            ObjUBO.A6 = ddlvendorBill.SelectedValue;
            ObjUBO.A7 = ddljobno.SelectedValue;
            ObjUBO.A8 = ddlchargename.SelectedValue;
            ObjUBO.A3 = Report_Type;
            ObjUBO.A4 = "Report";
            ds1 = AG.Acc_Purchase_entry_Rpt(ObjUBO);
            ReportViewer1.Reset();
            LocalReport localReport = ReportViewer1.LocalReport;

            if (Report_Type == "Vendor_Name")
            {

                localReport.ReportPath = @"Accounts_Purchase_Report/Acc_Purchase_Vendor_Rpt.rdlc";
            }
            else if (Report_Type == "Ledger_Name")
            {
                localReport.ReportPath = @"Accounts_Purchase_Report/Acc_Purchase_Ledger_Rpt.rdlc";
            }
            else if (Report_Type == "Jobno")
            {
                localReport.ReportPath = @"Accounts_Purchase_Report/Acc_Purchase_Jobno_Rpt.rdlc";
            }
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Purchase Report";
          

            Report_Print();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Report_Print()
    {
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty, encoding = string.Empty, extension = string.Empty;

        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        byte[] bytes_2 = ReportViewer1.LocalReport.Render("Excel", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

        Session.Remove("rpt_Excel");
        Session.Remove("rpt_Pdf");
        Session["rpt_Excel"] = bytes_2;
        Session["rpt_Pdf"] = bytes;
        //--------------------------------------To Print------------------------------------------------------------------------------------//
        ReportViewer1.Visible = true;
    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {
        if (ddl_Rpt_type.SelectedValue != "")
        {
            byte[] bytes = (byte[])Session["rpt_Excel"];
            Response.ClearHeaders();
            Response.Clear();

            Response.ContentType = "application/xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + "Purchase_Report_based_on_" + ddl_Rpt_type.SelectedValue + ".xls");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
        }
        else
        {
            Alert_msg("No Record Found");
        }
    }
    protected void btnRdlc_Click(object sender, EventArgs e)
    {
        if (ddl_Rpt_type.SelectedValue != "")
        {
        byte[] bytes = (byte[])Session["rpt_Pdf"];
        Response.ClearHeaders();
        Response.Clear();

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=" + "Purchase_Report_based_on_" + ddl_Rpt_type.SelectedValue + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
        }
        else
        {
            Alert_msg("No Record Found");
        }
    }



    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddl_Rpt_type_SelectedIndexChanged(object sender, EventArgs e)
    {

        string rep_typ =ddl_Rpt_type.SelectedValue;

        
             if (rep_typ == "Ledger_Name") {

               Hide_Ledger.Style["display"] = "block";
               Hide_Vendor.Style["display"] = "none";
               Hide_Jobno.Style["display"] = "none";

                }
   
            else if (rep_typ == "Jobno") {

                Hide_Ledger.Style["display"] = "none";
                Hide_Vendor.Style["display"] = "none";
                Hide_Jobno.Style["display"] = "block";
            }
            else 
            {
                Hide_Ledger.Style["display"] = "none";
                Hide_Vendor.Style["display"] = "block";
                Hide_Jobno.Style["display"] = "none";
            }

             load_Cus_name();
             ReportViewer1.Reset();
            


    }
}