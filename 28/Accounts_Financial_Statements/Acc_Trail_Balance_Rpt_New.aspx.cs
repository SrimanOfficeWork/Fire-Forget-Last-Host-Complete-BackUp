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

public partial class Accounts_Financial_Statements_Acc_Trail_Balance_Rpt_New : ThemeClass
{
    AppSession aps = new AppSession();

    Acc_Gen_Reports AG = new Acc_Gen_Reports();
    Global_variables ObjUBO = new Global_variables();
    DataSet ds = new DataSet();
    string[] arr_Month = new string[] { };
    public string CompanyName, WorkingPeriod;

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
            ds1 = AG.Acc_Trail_Balance_Rpt_New(ObjUBO);
            ReportViewer1.Reset();
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Financial_Statements/Acc_Trial_Balance_Report_New.rdlc";
            CompanyName = ds1.Tables[0].Rows[0]["COMPANY_NAME"].ToString();
            WorkingPeriod = Connection.WorkingPeriod();
            localReport.DataSources.Add(new ReportDataSource("DataSet2", ds1.Tables[1]));
            localReport.DataSources.Add(new ReportDataSource("DataSet3", ds1.Tables[2]));
            ReportParameter[] p ={new ReportParameter("CompanyName", CompanyName),
                                  new ReportParameter("WorkingPeriod", WorkingPeriod)};
            localReport.SetParameters(p);
            localReport.DisplayName = "Trial_Balance_Rpt";
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