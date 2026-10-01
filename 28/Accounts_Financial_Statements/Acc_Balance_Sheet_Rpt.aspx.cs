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

public partial class Acc_Balance_Sheet_Rpt : ThemeClass
{
    AppSession aps = new AppSession();

    Acc_Gen_Reports AG = new Acc_Gen_Reports();
    Global_variables ObjUBO = new Global_variables();
    DataSet ds = new DataSet();
    string[] arr_Month = new string[] { };

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
            DataSet ds1 = new DataSet();

            ObjUBO.A16 = "Report";
            ds1 = AG.Acc_Balance_Sheet_Rpt(ObjUBO);
            ReportViewer1.Reset();
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Financial_Statements/Acc_Balance_Sheet_Report.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds1.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);
            ReportDataSource datasource3 = new ReportDataSource("DataSet3", ds1.Tables[2]);
            ReportViewer1.LocalReport.DataSources.Add(datasource3);
            ReportDataSource datasource4 = new ReportDataSource("DataSet4", ds1.Tables[3]);
            ReportViewer1.LocalReport.DataSources.Add(datasource4);
            ReportDataSource datasource5 = new ReportDataSource("DataSet5", ds1.Tables[4]);
            ReportViewer1.LocalReport.DataSources.Add(datasource5);
            ReportDataSource datasource6 = new ReportDataSource("DataSet6", ds1.Tables[5]);
            ReportViewer1.LocalReport.DataSources.Add(datasource6);
            ReportDataSource datasource7 = new ReportDataSource("DataSet7", ds1.Tables[6]);
            ReportViewer1.LocalReport.DataSources.Add(datasource7);
            ReportDataSource datasource8 = new ReportDataSource("DataSet8", ds1.Tables[7]);
            ReportViewer1.LocalReport.DataSources.Add(datasource8);
            ReportDataSource datasource9 = new ReportDataSource("DataSet9", ds1.Tables[8]);
            ReportViewer1.LocalReport.DataSources.Add(datasource9);
            ReportDataSource datasource10 = new ReportDataSource("DataSet10", ds1.Tables[9]);
            ReportViewer1.LocalReport.DataSources.Add(datasource10);
            ReportDataSource datasource11 = new ReportDataSource("DataSet11", ds1.Tables[10]);
            ReportViewer1.LocalReport.DataSources.Add(datasource11);
            ReportDataSource datasource12 = new ReportDataSource("DataSet12", ds1.Tables[11]);
            ReportViewer1.LocalReport.DataSources.Add(datasource12);
            ReportDataSource datasource13 = new ReportDataSource("DataSet13", ds1.Tables[12]);
            ReportViewer1.LocalReport.DataSources.Add(datasource13);
            ReportDataSource datasource14 = new ReportDataSource("DataSet14", ds1.Tables[13]);
            ReportViewer1.LocalReport.DataSources.Add(datasource14);
            ReportDataSource datasource15 = new ReportDataSource("DataSet15", ds1.Tables[14]);
            ReportViewer1.LocalReport.DataSources.Add(datasource15);
            ReportDataSource datasource16 = new ReportDataSource("DataSet16", ds1.Tables[15]);
            ReportViewer1.LocalReport.DataSources.Add(datasource16);
            ReportDataSource datasource17 = new ReportDataSource("DataSet17", ds1.Tables[16]);
            ReportViewer1.LocalReport.DataSources.Add(datasource17);
            ReportDataSource datasource18 = new ReportDataSource("DataSet18", ds1.Tables[17]);
            ReportViewer1.LocalReport.DataSources.Add(datasource18);
            ReportDataSource datasource19 = new ReportDataSource("DataSet19", ds1.Tables[18]);
            ReportViewer1.LocalReport.DataSources.Add(datasource19);
            ReportDataSource datasource20 = new ReportDataSource("DataSet20", ds1.Tables[19]);
            ReportViewer1.LocalReport.DataSources.Add(datasource20);

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

        byte[] bytes = (byte[])Session["rpt_Excel"];
        Response.ClearHeaders();
        Response.Clear();

        Response.ContentType = "application/xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + "Balance Sheet Report" + ".xls");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }


    protected void btnRdlc_Click(object sender, EventArgs e)
    {

        byte[] bytes = (byte[])Session["rpt_Pdf"];
        Response.ClearHeaders();
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=" + "Balance Sheet Report" + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }


}