using System;
using System.Collections.Generic;
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

public partial class Acc_Sales_outstanding_Rpt : ThemeClass
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
           if (ddl_Rpt_type.SelectedValue != "")
            {
                DataSet dss = new DataSet();
                ObjUBO.A6 = Radio_Imp_Exp.SelectedValue;
                ObjUBO.A4 = "PARTY_NAME_JOB";
                dss = AG.Acc_sales_outstanding_Rpt(ObjUBO);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    ddlpartyname.DataSource = dss.Tables[0];
                    ddlpartyname.DataTextField = "CUS_NAME";
                    ddlpartyname.DataValueField = "CUS_NAME";
                    ddlpartyname.DataBind();

                }
                if (dss.Tables[0].Rows.Count > 0)
                {
                    ddljobno.DataSource = dss.Tables[1];
                    ddljobno.DataTextField = "JOBNO";
                    ddljobno.DataValueField = "JOBNO_PS";
                    ddljobno.DataBind();
                }
                ddlpartyname.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlpartyname.SelectedIndex = 0;
                ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddljobno.SelectedIndex = 0;
            }
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
            ObjUBO.A7 = ddljobno.SelectedValue;
            ObjUBO.A6 = Radio_Imp_Exp.SelectedValue;
            ObjUBO.A5 = ddlpartyname.SelectedValue;
            ObjUBO.A3 = Report_Type;
            ObjUBO.A4 = "Report";
            ds1 = AG.Acc_sales_outstanding_Rpt(ObjUBO);
            ReportViewer1.Reset();
            LocalReport localReport = ReportViewer1.LocalReport;
            if (Report_Type == "Party_Name")
            {

                localReport.ReportPath = @"Accounts_Sales_Rpt/Acc_Sales_outstanding_Party_Rpt.rdlc";
            }
            else if (Report_Type == "Jobno")
            {
                localReport.ReportPath = @"Accounts_Sales_Rpt/Acc_Sales_outstanding_Job_Rpt.rdlc";
            }
            
            ReportViewer1.LocalReport.EnableExternalImages = true;

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds1.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);

            ReportViewer1.LocalReport.DisplayName = "Sales Outstanding Report";
            Report_Print();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "report_type()", true);
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
            Response.AddHeader("content-disposition", "attachment;filename=" + "Sales_Outstanding_Report_based_on_" + ddl_Rpt_type.SelectedValue + ".xls");
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
            Response.AddHeader("content-disposition", "attachment;filename=" + "Sales_Outstanding_Report_based_on_" + ddl_Rpt_type.SelectedValue + ".pdf");
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
             if (rep_typ == "Ledger Name") 
             {
               Hide_Party.Style["display"] = "block";
               Hide_Jobno.Style["display"] = "none";
              }
            else if (rep_typ == "Jobno")
            {
                Hide_Party.Style["display"] = "none";
                Hide_Jobno.Style["display"] = "block";
            }
            else 
            {
                Hide_Party.Style["display"] = "block";
                Hide_Jobno.Style["display"] = "none";
            }
             load_Cus_name();
             ReportViewer1.Reset();
    }
    protected void Radio_Imp_Exp_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_Rpt_type_SelectedIndexChanged(sender,e);
    }
}