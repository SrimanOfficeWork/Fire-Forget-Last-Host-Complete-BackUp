using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using GeneraReport;
using Microsoft.Reporting.WebForms;
using System.Reflection;

public partial class Admin_Sales_Statement_IFrame : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataSet server = new DataSet();
    DataTable dt = new DataTable();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string Select_Database;
    Sales_Stmts sales = new Sales_Stmts();
    AppSession aps = new AppSession();
   
    string CustomerID, JobType, FromDate, ToDate, Branch, Client;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        //currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        //comp_ConnectionStr = Session["currentcomp_db"].ToString();

        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        if (!IsPostBack)
        {
            //if (!string.IsNullOrEmpty(Session["server"].ToString()))
            //{
            //    server = (DataSet)Session["server"];
            //}

            if (!string.IsNullOrEmpty(Request["CustomerID"]))
            {
                CustomerID = Request["CustomerID"].ToString();
            }


            if (!string.IsNullOrEmpty(Request["JobType"]))
            {
                JobType = Request["JobType"].ToString();
            }

          
            if (!string.IsNullOrEmpty(Request["FromDate"]))
            {
                FromDate = Request["FromDate"].ToString();
            }


            if (!string.IsNullOrEmpty(Request["ToDate"]))
            {
                ToDate = Request["ToDate"].ToString();
            }
            if (!string.IsNullOrEmpty(Request["Branch"]))
            {
                Branch = Request["Branch"].ToString();
            }
            if (!string.IsNullOrEmpty(Request["Client"]))
            {
                Client = Request["Client"].ToString();
            }

            string dsName = "";

            if (Client != "")
            {
               
                dsName = "Sales_Statement";
            }
            else
            {
                dsName ="Sales_Statement";

            }


            if (!string.IsNullOrEmpty(CustomerID) || !string.IsNullOrEmpty(JobType) || !string.IsNullOrEmpty(FromDate) || !string.IsNullOrEmpty(ToDate) || !string.IsNullOrEmpty(Branch))
            {
                if(JobType == "Both")
                    sales.Ename = "Sales_Statement_Import";
                else if (JobType == "Import")
                    sales.Ename = "Sales_Statement_Import";
                else if (JobType == "Export")
                    sales.Ename = "Sales_Statement_Export";

            }
            else
            {

                if (JobType == "Both")
                    sales.Ename = "Sales_Statement_Import";
                else if (JobType == "Import")
                    sales.Ename = "Sales_Statement_Import";
                else if (JobType == "Export")
                    sales.Ename = "Sales_Statement_Export";
            }

            sales.COMPANY_LICENSE = CustomerID;
            sales.JOBTYPE = JobType;

            sales.FROMDATE = FromDate;
            sales.TODATE = ToDate;
            sales.BRANCH = Branch;

            sales.Working_Period = Working_Period;

            dt = sales.RetrieveAll_Job_Details();
            if (dt.Rows.Count > 0)
            {
                ReportGenerator gen = new ReportGenerator(dt, dsName);
                ReportDataSource ds = new ReportDataSource(dsName, dt);
                ReportViewer1.Reset();
                ReportViewer1.LocalReport.DataSources.Add(ds);
                ReportViewer1.LocalReport.DisplayName = dsName;
                ReportViewer1.LocalReport.LoadReportDefinition(gen.GeneraReport());
            }
            else
            {
                //lblerror.InnerText = "No Record Found.";
            }
        }
    }

    protected void ReportViewer1_PreRender(object sender, EventArgs e)
    {
        DisableUnwantedExportFormats(ReportViewer1.LocalReport);
    }


    public static void DisableUnwantedExportFormats(LocalReport rvServer)
    {
        foreach (RenderingExtension extension in rvServer.ListRenderingExtensions())
        {
            if (extension.Name == "WORD")
            {
                ReflectivelySetVisibilityFalse(extension);
            }
        }
    }

    public static void ReflectivelySetVisibilityFalse(RenderingExtension extension)
    {
        FieldInfo info = extension.GetType().GetField("m_isVisible", BindingFlags.NonPublic | BindingFlags.Instance);

        if (info != null)
        {
            info.SetValue(extension, false);
        }
    }
}