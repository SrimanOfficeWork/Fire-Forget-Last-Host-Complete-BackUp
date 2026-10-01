using System;
using System.Collections.Generic;
using System.Web;
using BussinessObject;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class Acc_BankReceipt_cashdeposit_Rpt : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Acc_BOReceiptEntry_cs BOR = new Acc_BOReceiptEntry_cs();

    string CompanyName = string.Empty, Company_Add = string.Empty, Logo = string.Empty, Company_Lic = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        if (!IsPostBack)
        {
            load_data();
        }
    }
   
    private void load_data()
    {
        try
        {
            DataSet dss = new DataSet();
            LocalReport localReport = ReportViewer1.LocalReport;
            Company_Lic = Connection.Company_License().ToLower();
            if (Company_Lic == "eri03267" || Company_Lic == "eri00010")
            {
                Logo = new Uri(Server.MapPath("~/images/Company_Logo/ACC_KPS_CO.png")).AbsoluteUri;
            }
            else
            {  
                Logo = new Uri(Server.MapPath("")).AbsoluteUri;
            }
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ObjUBO.A1 = Request.QueryString["BR_P"].ToString();
            ObjUBO.A2 = Request.QueryString["BR_NO"].ToString();
            ObjUBO.A3 = Request.QueryString["BR_S"].ToString();
            ObjUBO.A25 = "Load_Report";            
            dss = BOR.ACC_BankRceipts_Cashdeposit_RPT(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                localReport.ReportPath = @"Accounts_Bank_Report/Acc_BankReceipt_CashDeposit_Rpt.rdlc";

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource datasource = new ReportDataSource("DataSet1", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportDataSource datasource1 = new ReportDataSource("DataSet2", dss.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource1);
                ReportDataSource datasource2 = new ReportDataSource("DataSet3", dss.Tables[2]);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);

                ReportDataSource datasource3 = new ReportDataSource("DataSet4", dss.Tables[3]);
                ReportViewer1.LocalReport.DataSources.Add(datasource3);
            }
            ReportViewer1.LocalReport.DisplayName = "BankReceiptVoucher";
          
            ReportParameter p1 = new ReportParameter("Logo", Logo);

            ReportParameter[] p = { p1};
            ReportViewer1.LocalReport.SetParameters(p);
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
        Session.Remove("report");
        Session["report"] = bytes;
        //--------------------------------------To Print------------------------------------------------------------------------------------//
        ReportViewer1.Visible = true;
    }
    protected void btnpdf_Click(object sender, EventArgs e)
    {
        byte[] bytes = (byte[])Session["report"];
        Response.ClearHeaders();
        Response.Clear();

        Response.ContentType = "application/pdf";
        string File_name = "BankReceiptVoucher";
        Response.AddHeader("content-disposition", "attachment;filename=" + File_name + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }
}