using System;
using System.Collections.Generic;
using System.Linq;
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


public partial class GST_Bill_Export_Job_rpt : System.Web.UI.Page
{
    AppSession aps = new AppSession();

    GST_Exp_Invoice BI = new GST_Exp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
      
        if (!IsPostBack)
        {
            Load_Grid();
        }
    }
    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();

        ObjUBO.Exp_Name = Request["Exp_Name"].ToString();
        ObjUBO.CHARGE_NAME = Request["Charge_Name"].ToString();
        ObjUBO.from_date = Request["From_date"].ToString();
        ObjUBO.todate = Request["todate"].ToString();

        ObjUBO.Tax_Mode = Request["Tax_type"].ToString();


        ObjUBO.Branch_No_Loc = Request["Location"].ToString();
        ObjUBO.Flag = Request["Rpt_type"].ToString();
        

        if (Request["Rpt_type"].ToString() == "Service_Heads")
        {
            ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_HEAD_RPT";
            ds1 = BI.BILL_EXPORT_JOB_INV_Head_Rpt(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;

            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Exp_Invoice_Head_Rpt.rdlc";
            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Service Heads Report";

            ReportParameter p1 = new ReportParameter("Service", Request["Charge_Name"].ToString() == "" ? "All Charges" : Request["Charge_Name"].ToString());
            ReportParameter p2 = new ReportParameter("From_date", Request["From_date"].ToString());
            ReportParameter p3 = new ReportParameter("Todate", Request["todate"].ToString());

            ReportParameter[] p = { p1, p2, p3};
            ReportViewer1.LocalReport.SetParameters(p);
        }
        else
        {
            ObjUBO.Sp_Name = "GST_BILL_EXPORT_JOB_STATEMENT_RPT";
            ds1 = BI.BILL_EXPORT_JOB_INV_Head_Rpt(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Billing_Exp_Rpt/GST_Exp_Invoice_Statement_Rpt.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Statement of Invoices";

            ReportParameter p1 = new ReportParameter("Service", Request["Exp_Name"].ToString());
            ReportParameter p2 = new ReportParameter("From_date", Request["From_date"].ToString());
            ReportParameter p3 = new ReportParameter("Todate", Request["todate"].ToString());
            ReportParameter p4 = new ReportParameter("Tax_NonTax", Request["Tax_type"].ToString() == "" ? "All" : Request["Tax_type"].ToString());

            ReportParameter[] p = { p1, p2, p3, p4 };
            ReportViewer1.LocalReport.SetParameters(p);
        }
       
         Report_Print();
    }


    private void Report_Print()
    {
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty, encoding = string.Empty, extension = string.Empty;

        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        byte[] bytes_2 = ReportViewer1.LocalReport.Render("Excel", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

        Session.Remove("report");
        Session["report_Excel"] = bytes_2;
           //--------------------------------------To Print------------------------------------------------------------------------------------//
           ReportViewer1.Visible = true; 
    }

    protected void btnexcel_Click(object sender, ImageClickEventArgs e)
    {
        byte[] bytes = (byte[])Session["report_Excel"];
        Response.ClearHeaders();
        Response.Clear();

        Response.ContentType = "application/xls";
        Response.AddHeader("content-disposition", "attachment;filename=ExportInvoice.xls");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.End();
    }
}