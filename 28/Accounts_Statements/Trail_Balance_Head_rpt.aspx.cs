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
        ObjUBO.Flag = Request["Rpt_type"].ToString();
        
        string CompanyName = HttpContext.Current.Session["Client_Name"].ToString();

        //if (Request["Rpt_type"].ToString() == "Overall")
        //{
        //    ObjUBO.Sp_Name = "TRIAL_BALANCE";
        //    ds1 = BI.Trial_Balance_Head_Rpt(ObjUBO);
        //    LocalReport localReport = ReportViewer1.LocalReport;
        //    localReport.ReportPath = @"Accounts_Statements/Trail_Balance.rdlc";

        //    ReportViewer1.LocalReport.EnableExternalImages = true;

        //    List<ReportParameter> paramList = new List<ReportParameter>();

        //    // Setting default values for parameters
        //    string fromDate = Request["From_date"].ToString();
        //    string toDate = Request["todate"].ToString();
        //    string service = Request["todate"].ToString();

        //    // Adding parameters
        //    paramList.Add(new ReportParameter("From_date", fromDate));
        //    paramList.Add(new ReportParameter("Todate", toDate));
        //    paramList.Add(new ReportParameter("Service", service));

        //    this.ReportViewer1.LocalReport.SetParameters(paramList);
        //    ReportViewer1.LocalReport.DataSources.Clear();

        //    ReportDataSource datasource = new ReportDataSource("trail_balance", ds1.Tables[0]);
        //    ReportViewer1.LocalReport.DataSources.Add(datasource);

        //    ReportViewer1.LocalReport.DisplayName = "trail_balance";

        //    Report_Print();
        //}



        if (Request["Rpt_type"].ToString() == "Overall")
        {
            ObjUBO.Sp_Name = "OVERALL";
            ds1 = AS.Trial_Balance_Overall(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Statements/Trail_Balance_Overall.rdlc";
            //localReport.ReportPath = @"Accounts_Statements/Trail_Balance.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            // Setting default values for parameters
            string fromDate = Request["From_date"].ToString();
            string toDate = Request["todate"].ToString();
            string service = Request["todate"].ToString();

            // Adding parameters
            paramList.Add(new ReportParameter("From_date", fromDate));
            paramList.Add(new ReportParameter("Todate", toDate));
            paramList.Add(new ReportParameter("Service", service));

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("Trial_Balance_Overall", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Trial_Balance_Overall";

            //ReportDataSource datasource = new ReportDataSource("trial_balance_001", ds1.Tables[0]);
            //ReportViewer1.LocalReport.DataSources.Add(datasource);

            //ReportViewer1.LocalReport.DisplayName = "trail_balance";

            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Capital_Account")
        {
            ObjUBO.Sp_Name = "CAPITAL_ACCOUNT";
            ds1 = AS.Trial_Balance_Overall(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Statements/Trail_Balance.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            // Setting default values for parameters
            string fromDate = Request["From_date"].ToString();
            string toDate = Request["todate"].ToString();
            string service = Request["todate"].ToString();

            // Adding parameters
            paramList.Add(new ReportParameter("From_date", fromDate));
            paramList.Add(new ReportParameter("Todate", toDate));
            paramList.Add(new ReportParameter("Service", service));

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("trial_balance_001", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "trail_balance";

            Report_Print();
        }

        else if (Request["Rpt_type"].ToString() == "Loans_Liability")
        {
            ObjUBO.Sp_Name = "LOAN_LIABILITIES";
            ds1 = AS.Trial_Balance_Overall(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Statements/Trail_Balance.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            // Setting default values for parameters
            string fromDate = Request["From_date"].ToString();
            string toDate = Request["todate"].ToString();
            string service = Request["todate"].ToString();

            // Adding parameters
            paramList.Add(new ReportParameter("From_date", fromDate));
            paramList.Add(new ReportParameter("Todate", toDate));
            paramList.Add(new ReportParameter("Service", service));

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("trial_balance_001", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "trail_balance";

            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Current_Liability")
        {
            ObjUBO.Sp_Name = "CURRENT_LIABILITIES";
            ds1 = AS.Trial_Balance_Overall(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Statements/Current_Liability.rdlc";
            //localReport.ReportPath = @"Accounts_Statements/Trail_Balance.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            // Setting default values for parameters
            string fromDate = Request["From_date"].ToString();
            string toDate = Request["todate"].ToString();
            string service = Request["todate"].ToString();

            // Adding parameters
            paramList.Add(new ReportParameter("From_date", fromDate));
            paramList.Add(new ReportParameter("Todate", toDate));
            paramList.Add(new ReportParameter("Service", service));

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("Current_Liability", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Current_Liability";

            //ReportDataSource datasource = new ReportDataSource("trial_balance_001", ds1.Tables[0]);
            //ReportViewer1.LocalReport.DataSources.Add(datasource);

            //ReportViewer1.LocalReport.DisplayName = "trial_balance";

            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Fixed_Assets")
        {
            ObjUBO.Sp_Name = "FIXED_ASSETS";
            ds1 = AS.Trial_Balance_Overall(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Statements/Trail_Balance.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            // Setting default values for parameters
            string fromDate = Request["From_date"].ToString();
            string toDate = Request["todate"].ToString();
            string service = Request["todate"].ToString();

            // Adding parameters
            paramList.Add(new ReportParameter("From_date", fromDate));
            paramList.Add(new ReportParameter("Todate", toDate));
            paramList.Add(new ReportParameter("Service", service));

            //paramList.Add(new ReportParameter("CAPITAL_NAME", fromDate));
            //paramList.Add(new ReportParameter("PAN_NO", toDate));
            //paramList.Add(new ReportParameter("ADDRESS_1", service));
            //paramList.Add(new ReportParameter("ADDRESS_2", fromDate));
            //paramList.Add(new ReportParameter("DISTRICT", toDate));
            //paramList.Add(new ReportParameter("STATE_CODE", service));

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("trial_balance_001", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "trail_balance";

            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Current_Assets")
        {
            ObjUBO.Sp_Name = "CURRENT_ASSETS";
            ds1 = AS.Trial_Balance_Overall(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Statements/Current_Assets.rdlc";
            //localReport.ReportPath = @"Accounts_Statements/Trail_Balance.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            // Setting default values for parameters
            string fromDate = Request["From_date"].ToString();
            string toDate = Request["todate"].ToString();
            string service = Request["todate"].ToString();

            // Adding parameters
            paramList.Add(new ReportParameter("From_date", fromDate));
            paramList.Add(new ReportParameter("Todate", toDate));
            paramList.Add(new ReportParameter("Service", service));

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("Current_Assets", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Current_Assets";

            //ReportDataSource datasource = new ReportDataSource("trial_balance_001", ds1.Tables[0]);
            //ReportViewer1.LocalReport.DataSources.Add(datasource);

            //ReportViewer1.LocalReport.DisplayName = "trail_balance";

            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Sales_Accounts")
        {
            ObjUBO.Sp_Name = "SALES_ACCOUNTS";
            ds1 = AS.Trial_Balance_Overall(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Statements/Sales_Accounts.rdlc";
            //localReport.ReportPath = @"Accounts_Statements/Trail_Balance.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            // Setting default values for parameters
            string fromDate = Request["From_date"].ToString();
            string toDate = Request["todate"].ToString();
            string service = Request["todate"].ToString();

            // Adding parameters
            paramList.Add(new ReportParameter("From_date", fromDate));
            paramList.Add(new ReportParameter("Todate", toDate));
            paramList.Add(new ReportParameter("Service", service));

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("Sales_Accounts", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Sales_Accounts";

            //ReportDataSource datasource = new ReportDataSource("trial_balance_001", ds1.Tables[0]);
            //ReportViewer1.LocalReport.DataSources.Add(datasource);

            //ReportViewer1.LocalReport.DisplayName = "trail_balance";

            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Purchase_Accounts")
        {
            ObjUBO.Sp_Name = "PURCHASE_ACCOUNTS";
            ds1 = AS.Trial_Balance_Overall(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Statements/Purchase_Accounts.rdlc";
            //localReport.ReportPath = @"Accounts_Statements/Trail_Balance.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            // Setting default values for parameters
            string fromDate = Request["From_date"].ToString();
            string toDate = Request["todate"].ToString();
            string service = Request["todate"].ToString();

            // Adding parameters
            paramList.Add(new ReportParameter("From_date", fromDate));
            paramList.Add(new ReportParameter("Todate", toDate));
            paramList.Add(new ReportParameter("Service", service));

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("Purchase_Accounts", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Purchase_Accounts";

            //ReportDataSource datasource = new ReportDataSource("trial_balance_001", ds1.Tables[0]);
            //ReportViewer1.LocalReport.DataSources.Add(datasource);

            //ReportViewer1.LocalReport.DisplayName = "trail_balance";

            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Direct_Expenses")
        {
            ObjUBO.Sp_Name = "DIRECT_EXPENSES";
            ds1 = AS.Trial_Balance_Overall(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Statements/Direct_Expenses.rdlc";
            //localReport.ReportPath = @"Accounts_Statements/Trail_Balance.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            // Setting default values for parameters
            string fromDate = Request["From_date"].ToString();
            string toDate = Request["todate"].ToString();
            string service = Request["todate"].ToString();

            // Adding parameters
            paramList.Add(new ReportParameter("From_date", fromDate));
            paramList.Add(new ReportParameter("Todate", toDate));
            paramList.Add(new ReportParameter("Service", service));

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("Direct_Expenses", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Direct_Expenses";

            //ReportDataSource datasource = new ReportDataSource("trial_balance_001", ds1.Tables[0]);
            //ReportViewer1.LocalReport.DataSources.Add(datasource);

            //ReportViewer1.LocalReport.DisplayName = "trail_balance";

            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Indirect_Incomes")
        {
            ObjUBO.Sp_Name = "INDIRECT_INCOMES";
            ds1 = AS.Trial_Balance_Overall(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Statements/Indirect_Incomes.rdlc";
            //localReport.ReportPath = @"Accounts_Statements/Trail_Balance.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            // Setting default values for parameters
            string fromDate = Request["From_date"].ToString();
            string toDate = Request["todate"].ToString();
            string service = Request["todate"].ToString();

            // Adding parameters
            paramList.Add(new ReportParameter("From_date", fromDate));
            paramList.Add(new ReportParameter("Todate", toDate));
            paramList.Add(new ReportParameter("Service", service));

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("Indirect_Incomes", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Indirect_Incomes";

            //ReportDataSource datasource = new ReportDataSource("trial_balance_001", ds1.Tables[0]);
            //ReportViewer1.LocalReport.DataSources.Add(datasource);

            //ReportViewer1.LocalReport.DisplayName = "trail_balance";

            Report_Print();
        }
        else if (Request["Rpt_type"].ToString() == "Indirect_Expenses")
        {
            ObjUBO.Sp_Name = "INDIRECT_EXPENSES";
            ds1 = AS.Trial_Balance_Overall(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Statements/Indirect_Expenses.rdlc";
            //localReport.ReportPath = @"Accounts_Statements/Trail_Balance.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            // Setting default values for parameters
            string fromDate = Request["from_date"].ToString();
            string toDate = Request["todate"].ToString();
            string service = Request["todate"].ToString();

            // Adding parameters
            paramList.Add(new ReportParameter("From_date", fromDate));
            paramList.Add(new ReportParameter("Todate", toDate));
            paramList.Add(new ReportParameter("Service", service));

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("Indirect_Expenses", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Indirect_Expenses";

            //ReportDataSource datasource = new ReportDataSource("trial_balance_001", ds1.Tables[0]);
            //ReportViewer1.LocalReport.DataSources.Add(datasource);

            //ReportViewer1.LocalReport.DisplayName = "trail_balance";

            Report_Print();
        }


        else if (Request["Rpt_type"].ToString() == "Balance_Sheet")
        {
            ObjUBO.Sp_Name = "INDIRECT_EXPENSES";
            ds1 = AS.Trial_Balance_Head_Rpt(ObjUBO);
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = @"Accounts_Statements/Balance_Sheet.rdlc";
            //localReport.ReportPath = @"Accounts_Statements/Indirect_Expenses.rdlc";

            ReportViewer1.LocalReport.EnableExternalImages = true;

            List<ReportParameter> paramList = new List<ReportParameter>();

            // Setting default values for parameters
            string fromDate = Request["From_date"].ToString();
            string toDate = Request["todate"].ToString();
            string service = Request["todate"].ToString();

            // Adding parameters
            paramList.Add(new ReportParameter("From_date", fromDate));
            paramList.Add(new ReportParameter("Todate", toDate));
            paramList.Add(new ReportParameter("Service", service));

            this.ReportViewer1.LocalReport.SetParameters(paramList);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource datasource = new ReportDataSource("Indirect_Expenses", ds1.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.DisplayName = "Indirect_Expenses";

            //ReportDataSource datasource = new ReportDataSource("trial_balance_001", ds1.Tables[0]);
            //ReportViewer1.LocalReport.DataSources.Add(datasource);

            //ReportViewer1.LocalReport.DisplayName = "trail_balance";

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