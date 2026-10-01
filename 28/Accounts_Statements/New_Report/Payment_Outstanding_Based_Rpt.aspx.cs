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

        ObjUBO.Expense_Job_Number = Request["Job_Number"].ToString();
        
        
        string CompanyName = HttpContext.Current.Session["Client_Name"].ToString();

        ObjUBO.Sp_Name = "ACC_GST_PAYMENT_OUTSTANDING_REPORT";
        ds1 = AS.Payment_Outstanding_Rpt(ObjUBO);
        LocalReport localReport = ReportViewer1.LocalReport;
        localReport.ReportPath = @"Accounts_Statements/New_Report/Payment_Outstanding.rdlc";

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

        ReportDataSource datasource = new ReportDataSource("Payment_Outstanding", ds1.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);

        ReportViewer1.LocalReport.DisplayName = "Payment_Outstanding";

        Report_Print();
        
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