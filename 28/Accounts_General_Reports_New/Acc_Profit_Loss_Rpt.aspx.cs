using System;
//using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using System.Data;
using BussinessObject;

public partial class Acc_Profit_Loss_Rpt : ThemeClass
{
    AppSession aps = new AppSession();

    Acc_General_Reports AG = new Acc_General_Reports();
    Global_variables ObjUBO = new Global_variables();

    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {
            Load_Rpt_Data();
           
        }

    }

    private void Load_Rpt_Data()
    {
        try
        {
            DataSet ds = new DataSet();

            ObjUBO.A1 = "Grid_Data";

            ds = AG.Acc_GST_Profit_Loss_Select(ObjUBO);

            ReportViewer1.Reset();
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_General_Reports_New/Acc_Profit_Loss_Rpt.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);
            ReportViewer1.LocalReport.DisplayName = "Profit And Loss Report";
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

        Session.Remove("report_inv_Excel");
        Session.Remove("report_Pdf");
        Session["report_inv_Excel"] = bytes_2;
        Session["report_Pdf"] = bytes;
        //--------------------------------------To Print------------------------------------------------------------------------------------//
        ReportViewer1.Visible = true;
    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {
        byte[] bytes = (byte[])Session["report_inv_Excel"];
        Response.ClearHeaders();
        Response.Clear();

        Response.ContentType = "application/xls";
        Response.AddHeader("content-disposition", "attachment;filename=" +  "_Acc_Profit_Loss_Rpt" + ".xls");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }
    protected void btnRdlc_Click(object sender, EventArgs e)
    {

        byte[] bytes = (byte[])Session["report_Pdf"];
        Response.ClearHeaders();
        Response.Clear();

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=" + "_Acc_Profit_Loss_Rpt" + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }



    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }



}