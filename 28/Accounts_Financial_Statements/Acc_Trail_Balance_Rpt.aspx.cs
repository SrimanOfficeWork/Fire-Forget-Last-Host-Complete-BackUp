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

public partial class Acc_Trail_Balance_Rpt : ThemeClass
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
            ds1 = AG.Acc_Trail_Balance_Rpt(ObjUBO);
            ReportViewer1.Reset();
            LocalReport localReport = ReportViewer1.LocalReport;


            localReport.ReportPath = @"Accounts_Financial_Statements/Acc_Trail_Balance_Report.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds1.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportDataSource datasource3 = new ReportDataSource("DataSet3", ds1.Tables[2]);
            ReportViewer1.LocalReport.DataSources.Add(datasource3);
            ReportDataSource datasource4 = new ReportDataSource("DataSet4", ds1.Tables[3]);
            ReportViewer1.LocalReport.DataSources.Add(datasource4);
            ReportDataSource datasource5 = new ReportDataSource("DataSet5", ds1.Tables[4]);
            ReportViewer1.LocalReport.DataSources.Add(datasource5);
            ReportDataSource datasource6 = new ReportDataSource("DataSet6", ds1.Tables[5]);
            ReportViewer1.LocalReport.DataSources.Add(datasource6);

            
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
        Response.AddHeader("content-disposition", "attachment;filename=" + "Trail Balance Report" + ".xls");
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
        Response.AddHeader("content-disposition", "attachment;filename=" + "Trail Balance Report" + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }


}