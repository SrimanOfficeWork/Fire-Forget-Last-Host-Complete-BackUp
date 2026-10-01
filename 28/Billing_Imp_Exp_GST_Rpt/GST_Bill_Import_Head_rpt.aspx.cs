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

    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();
    string GSTR1_OFFLINE = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
      
        if (!IsPostBack)
        {
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
        DataSet ds2 = new DataSet();
        ObjUBO.Imp_Name = Request["Imp_Name"].ToString().Replace('_', '&'); 
        ObjUBO.CHARGE_NAME = Request["Charge_Name"].ToString();
        ObjUBO.from_date = Request["From_date"].ToString();
        ObjUBO.todate = Request["todate"].ToString();
        ObjUBO.Tax_Mode = Request["Tax_type"].ToString();
        ObjUBO.Branch_No_Loc = Request["Location"].ToString();
        ObjUBO.Flag = Request["Rpt_type"].ToString();
        ObjUBO.TYPE = Request["Category"].ToString();

        if (Request["Rpt_type"].ToString() == "Service_Heads")
        {
            ObjUBO.Sp_Name = "GST_BILL_JOB_HEAD_RPT";
            ds1 = BI.BILL_IMPORT_JOB_INV_Head_Rpt(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;

            localReport.ReportPath = @"Billing_Imp_Exp_GST_Rpt/GST_Imp_Invoice_Head_Rpt.rdlc";
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

            ReportParameter[] p = { p1, p2, p3, };
            ReportViewer1.LocalReport.SetParameters(p);
            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Ledger_Heads_Tax")
        {

            ObjUBO.Sp_Name = "GST_BILL_LEDGER_HEADS_TAX_RPT";
            ds1 = BI.BILL_IMPORT_JOB_INV_Head_Rpt(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Billing_Imp_Exp_GST_Rpt/GST_Bill_Ledger_Heads_Tax_Rpt.rdlc";
            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Ledger Heads Tax Report";

            ReportParameter p1 = new ReportParameter("Service", Request["Charge_Name"].ToString() == "" ? "All Charges" : Request["Charge_Name"].ToString());
            ReportParameter p2 = new ReportParameter("From_date", Request["From_date"].ToString());
            ReportParameter p3 = new ReportParameter("Todate", Request["todate"].ToString());

            ReportParameter[] p = { p1, p2, p3, };
            ReportViewer1.LocalReport.SetParameters(p);
            Report_Print();
        }

        else if (Request["Rpt_type"].ToString() == "Statement")
        {
            ObjUBO.Sp_Name = "GST_BILL_JOB_STATEMENT_RPT";
            ds1 = BI.BILL_IMPORT_JOB_INV_Head_Rpt(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Billing_Imp_Exp_GST_Rpt/GST_Imp_Exp_Invoice_Statement_Rpt.rdlc"; 

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Statement of Invoices";

            ReportParameter p1 = new ReportParameter("Service", Request["Imp_Name"].ToString());
            ReportParameter p2 = new ReportParameter("From_date", Request["From_date"].ToString());
            ReportParameter p3 = new ReportParameter("Todate", Request["todate"].ToString());
            ReportParameter p4 = new ReportParameter("Tax_NonTax", Request["Tax_type"].ToString() == "" ? "All" : Request["Tax_type"].ToString());

            ReportParameter[] p = { p1, p2, p3, p4 };
            ReportViewer1.LocalReport.SetParameters(p);
            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Service")
        {
            ObjUBO.Sp_Name = "GST_BILL_JOB_SERVICE_RPT";
            ds1 = BI.BILL_IMPORT_JOB_INV_Head_Rpt(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Billing_Imp_Exp_GST_Rpt/GST_Imp_Invoice_Service_Rpt.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Services";

            ReportParameter p1 = new ReportParameter("Service", Request["Imp_Name"].ToString());
            ReportParameter p2 = new ReportParameter("From_date", Request["From_date"].ToString());
            ReportParameter p3 = new ReportParameter("Todate", Request["todate"].ToString());
            ReportParameter p4 = new ReportParameter("Tax_NonTax", Request["Tax_type"].ToString() == "" ? "All" : Request["Tax_type"].ToString());

            ReportParameter[] p = { p1, p2, p3, p4 };
            ReportViewer1.LocalReport.SetParameters(p);
            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Monthly")
        {
            ObjUBO.Sp_Name = "GST_BILL_JOB_MONTHLY_RPT";
            ds1 = BI.BILL_IMPORT_JOB_INV_Head_Rpt(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Billing_Imp_Exp_GST_Rpt/GST_Monthly_Rpt.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Monthly";

            ReportParameter p1 = new ReportParameter("Service", Request["Imp_Name"].ToString() == "" ? "All" : Request["Imp_Name"].ToString());
            ReportParameter p2 = new ReportParameter("From_date", Request["From_date"].ToString());
            ReportParameter p3 = new ReportParameter("Todate", Request["todate"].ToString());
            ReportParameter p4 = new ReportParameter("Tax_NonTax", Request["Tax_type"].ToString() == "" ? "All" : Request["Tax_type"].ToString());

            ReportParameter[] p = { p1, p2, p3, p4 };
            ReportViewer1.LocalReport.SetParameters(p);
            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "GSTR1")
        {
            ObjUBO.Sp_Name = "GST_BILL_GSTR1_RPT";
            ds1 = BI.BILL_IMPORT_JOB_INV_Head_Rpt(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Billing_Imp_Exp_GST_Rpt/GST_BILL_GSTR1_RPT.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "GSTR1_RPT";

            ReportParameter p1 = new ReportParameter("Service", Request["Imp_Name"].ToString() == "" ? "All" : Request["Imp_Name"].ToString());
            ReportParameter p2 = new ReportParameter("From_date", Request["From_date"].ToString());
            ReportParameter p3 = new ReportParameter("Todate", Request["todate"].ToString());
            ReportParameter p4 = new ReportParameter("Tax_NonTax", Request["Tax_type"].ToString() == "" ? "All" : Request["Tax_type"].ToString());
            ReportParameter p5 = new ReportParameter("E_Comm", Connection.COMPANYID() == "2" ? "" : "NIL");

            ReportParameter[] p = { p1, p2, p3, p4, p5 };
            ReportViewer1.LocalReport.SetParameters(p);
            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "GSTR1 Offline")
        {
            ObjUBO.Sp_Name = "GST_BILL_GSTR1_OFFLINE_RPT";
            ds1 = BI.BILL_IMPORT_JOB_INV_Head_Rpt(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Billing_Imp_Exp_GST_Rpt/GST_BILL_GSTR1_OFFLINE_RPT.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportDataSource datasource1 = new ReportDataSource("DataSet2", ds1.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);


            ReportViewer1.LocalReport.DisplayName = "GSTR1_RPT";

            ReportParameter p1 = new ReportParameter("Service", Request["Imp_Name"].ToString() == "" ? "All" : Request["Imp_Name"].ToString());
            ReportParameter p2 = new ReportParameter("From_date", Request["From_date"].ToString());
            ReportParameter p3 = new ReportParameter("Todate", Request["todate"].ToString());
            ReportParameter p4 = new ReportParameter("Tax_NonTax", Request["Tax_type"].ToString() == "" ? "All" : Request["Tax_type"].ToString());
            ReportParameter p5 = new ReportParameter("E_Comm", Connection.COMPANYID() == "2" ? "" : "NIL");

            ReportParameter[] p = { p1, p2, p3, p4, p5 };
            ReportViewer1.LocalReport.SetParameters(p);
            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "GSTR1 Summary")
        {
            
        }
        else if (Request["Rpt_type"].ToString() == "GSTR2A Summary")
        {
            
        }
        else if (Request["Rpt_type"].ToString() == "GSTR3B Summary")
        {
            
        }


        //else if (Request["Rpt_type"].ToString() == "GSTR1")
        //{
        //    ObjUBO.Sp_Name = "ACCOUNTS_SETTINGS_SP";
        //    ds2 = BI.ACCOUNTS_SETTINGS(ObjUBO);
        //    GSTR1_OFFLINE = ds2.Tables[0].Rows[0]["GSTR1_OFFLINE"].ToString();

        //    if (GSTR1_OFFLINE == "YES")
        //    {

        //        ObjUBO.Sp_Name = "GST_BILL_GSTR1_OFFLINE_RPT";
        //        ds1 = BI.BILL_IMPORT_JOB_INV_Head_Rpt(ObjUBO);
        //        LocalReport localReport = ReportViewer1.LocalReport;
        //        localReport.ReportPath = @"Billing_Imp_Exp_GST_Rpt/GST_BILL_GSTR1_OFFLINE_RPT.rdlc";

        //        ReportViewer1.LocalReport.EnableExternalImages = true;

        //        List<ReportParameter> paramList = new List<ReportParameter>();
        //        this.ReportViewer1.LocalReport.SetParameters(paramList);
        //        ReportViewer1.LocalReport.DataSources.Clear();

        //        ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
        //        ReportViewer1.LocalReport.DataSources.Add(datasource);
        //        ReportDataSource datasource1 = new ReportDataSource("DataSet2", ds1.Tables[1]);
        //        ReportViewer1.LocalReport.DataSources.Add(datasource1);


        //        ReportViewer1.LocalReport.DisplayName = "GSTR1_RPT";

        //        ReportParameter p1 = new ReportParameter("Service", Request["Imp_Name"].ToString() == "" ? "All" : Request["Imp_Name"].ToString());
        //        ReportParameter p2 = new ReportParameter("From_date", Request["From_date"].ToString());
        //        ReportParameter p3 = new ReportParameter("Todate", Request["todate"].ToString());
        //        ReportParameter p4 = new ReportParameter("Tax_NonTax", Request["Tax_type"].ToString() == "" ? "All" : Request["Tax_type"].ToString());
        //        ReportParameter p5 = new ReportParameter("E_Comm", Connection.COMPANYID() == "2" ? "" : "NIL");

        //        ReportParameter[] p = { p1, p2, p3, p4, p5 };
        //        ReportViewer1.LocalReport.SetParameters(p);
        //        Report_Print();
        //    }
        //    else
        //    {
        //        ObjUBO.Sp_Name = "GST_BILL_GSTR1_RPT";
        //        ds1 = BI.BILL_IMPORT_JOB_INV_Head_Rpt(ObjUBO);
        //        LocalReport localReport = ReportViewer1.LocalReport;
        //        localReport.ReportPath = @"Billing_Imp_Exp_GST_Rpt/GST_BILL_GSTR1_RPT.rdlc";

        //        ReportViewer1.LocalReport.EnableExternalImages = true;

        //        List<ReportParameter> paramList = new List<ReportParameter>();
        //        this.ReportViewer1.LocalReport.SetParameters(paramList);
        //        ReportViewer1.LocalReport.DataSources.Clear();

        //        ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
        //        ReportViewer1.LocalReport.DataSources.Add(datasource);

        //        ReportViewer1.LocalReport.DisplayName = "GSTR1_RPT";

        //        ReportParameter p1 = new ReportParameter("Service", Request["Imp_Name"].ToString() == "" ? "All" : Request["Imp_Name"].ToString());
        //        ReportParameter p2 = new ReportParameter("From_date", Request["From_date"].ToString());
        //        ReportParameter p3 = new ReportParameter("Todate", Request["todate"].ToString());
        //        ReportParameter p4 = new ReportParameter("Tax_NonTax", Request["Tax_type"].ToString() == "" ? "All" : Request["Tax_type"].ToString());
        //        ReportParameter p5 = new ReportParameter("E_Comm", Connection.COMPANYID() == "2" ? "" : "NIL");

        //        ReportParameter[] p = { p1, p2, p3, p4, p5 };
        //        ReportViewer1.LocalReport.SetParameters(p);
        //        Report_Print();
        //    }
        //}
        else if (Request["Rpt_type"].ToString() == "Container")
        {
            ObjUBO.Sp_Name = "GST_BILL_JOB_CONTAINER_RPT";
            ds1 = BI.BILL_IMPORT_JOB_INV_Head_Rpt(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Billing_Imp_Exp_GST_Rpt/GST_Container_Rpt.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();
            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "CONTAINER_RPT";

            ReportParameter p1 = new ReportParameter("Service", Request["Imp_Name"].ToString() == "" ? "All" : Request["Imp_Name"].ToString());
            ReportParameter p2 = new ReportParameter("From_date", Request["From_date"].ToString());
            ReportParameter p3 = new ReportParameter("Todate", Request["todate"].ToString());
            ReportParameter p4 = new ReportParameter("Tax_NonTax", Request["Tax_type"].ToString() == "" ? "All" : Request["Tax_type"].ToString());

            ReportParameter[] p = { p1, p2, p3, p4 };
            ReportViewer1.LocalReport.SetParameters(p);
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