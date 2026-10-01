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


public partial class GST_Bill_Import_Job_rpt : System.Web.UI.Page
{
    AppSession aps = new AppSession();

    Account_Statement AS = new Account_Statement();
    Billing_UserBO ObjUBO = new Billing_UserBO();
    string GSTR1_OFFLINE = string.Empty;
    string Company_Lic = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
      
        if (!IsPostBack)
        {
            Company_Lic = Connection.Company_License().ToLower();
            if (Session["Click_Y_N"].ToString() == "Y")
            {
                Load_Grid();
            }
            else
            {
                Session["Click_Y_N"] = "N";
            }
        }
    }
    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();
        
        ObjUBO.from_date = Request["From_date"].ToString();
        ObjUBO.todate = Request["todate"].ToString();
        ObjUBO.Expense_Imp_Exp = Request["Imp_Exp_Name"].ToString();
        ObjUBO.Expense_Party_Name = Session["Expense_Party_Name"].ToString();

        if (Request["Rpt_type"].ToString() == "Ledger_Wise")
        {
            ObjUBO.Expense_Ledger_Name = Session["Expense_Ledger_Name"].ToString();
        }

        ObjUBO.Expense_Job_Number = Request["Job_Number"].ToString();
        ObjUBO.Flag = Request["Rpt_type"].ToString();
        
        string CompanyName = HttpContext.Current.Session["Client_Name"].ToString();


        if (Request["Rpt_type"].ToString() == "Vendor_Wise")
        {
            ObjUBO.Sp_Name = "ACC_GST_PURCHASE_REPORT";
            ds1 = AS.Purchase_Vendor_Rpt(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Statements/New_Report/Purchase_Vendor.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            // Setting default values for parameters
            string fromDate = Request["From_date"].ToString();
            string toDate = Request["todate"].ToString();
            //string service = Request["todate"].ToString();

            // Adding parameters
            paramList.Add(new ReportParameter("From_date", fromDate));
            paramList.Add(new ReportParameter("Todate", toDate));
            //paramList.Add(new ReportParameter("Service", service));

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("Purchase_Vendor", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Purchase_Vendor";

            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Ledger_Wise")
        {
            ObjUBO.Sp_Name = "ACC_GST_PURCHASE_REPORT";
            ds1 = AS.Purchase_Ledger_Rpt(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Statements/New_Report/Purchase_Ledger.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            // Setting default values for parameters
            string fromDate = Request["From_date"].ToString();
            string toDate = Request["todate"].ToString();
            //string service = Request["todate"].ToString();

            // Adding parameters
            paramList.Add(new ReportParameter("From_date", fromDate));
            paramList.Add(new ReportParameter("Todate", toDate));
            //paramList.Add(new ReportParameter("Service", service));

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("Purchase_Ledger", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Purchase_Ledger";

            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Job_Wise")
        {
            ObjUBO.Sp_Name = "ACC_GST_PURCHASE_REPORT";
            ds1 = AS.Purchase_Job_Rpt(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Statements/New_Report/Purchase_Job.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            // Setting default values for parameters
            string fromDate = Request["From_date"].ToString();
            string toDate = Request["todate"].ToString();
            //string service = Request["todate"].ToString();

            // Adding parameters
            paramList.Add(new ReportParameter("From_date", fromDate));
            paramList.Add(new ReportParameter("Todate", toDate));
            //paramList.Add(new ReportParameter("Service", service));

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("Purchase_Job", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Purchase_Job";

            Report_Print();
        }
        
        else
        {
            Session.Remove("report_Excel");
        }
        Session["Click_Y_N"] = "";
    }

    private void Report_Print()
    {
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty, encoding = string.Empty, extension = string.Empty;

        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        byte[] bytes_2 = ReportViewer1.LocalReport.Render("Excel", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

        Session.Remove("report");
        Session.Remove("report_Excel");
        Session["report_Excel"] = bytes_2;
           //--------------------------------------To Print------------------------------------------------------------------------------------//
        ReportViewer1.Visible = true; 
    }

    protected void btnexcel_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["Click_Y_N"].ToString() != "N")
        {
            byte[] bytes = (byte[])Session["report_Excel"];
            Response.ClearHeaders();
            Response.Clear();

            Response.ContentType = "application/xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + Request["Rpt_type"].ToString() + ".xls");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
        }
    }
}