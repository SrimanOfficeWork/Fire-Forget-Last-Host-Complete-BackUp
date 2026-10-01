using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Data;
using System.Data.SqlClient;
using GeneraReport;
using Microsoft.Reporting.WebForms;
using System.Reflection;

public partial class Import_Statement_Import_Job_RegisterNew : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataTable dt = new DataTable();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    AppSession aps = new AppSession();
    User_Wise_Report stmts = new User_Wise_Report();
    string JobNo,JobType, User, FromDate, ToDate, JobDate;


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

                if (!string.IsNullOrEmpty(Request["JobNo"]))
                {
                    JobNo = Request["JobNo"].ToString();
                }
                

                if (!string.IsNullOrEmpty(Request["JobType"]))
                {
                    JobType = Request["JobType"].ToString();
                }
               
                if (!string.IsNullOrEmpty(Request["User"]))
                {
                    User = Request["User"].ToString();
                }
                
                                
                if (!string.IsNullOrEmpty(Request["FromDate"]))
                {
                    FromDate = Request["FromDate"].ToString();
                }
                

                if (!string.IsNullOrEmpty(Request["ToDate"]))
                {
                    ToDate = Request["ToDate"].ToString();
                }
                if (!string.IsNullOrEmpty(Request["JobDate"]))
                {
                    JobDate = Request["JobDate"].ToString();
                }

                string dsName = "";

                if (User == "All")
                {
                    User = "";
                    dsName = "User_Statement";
                }
                else
                {
                    dsName = User + "_Statement";

                }
               
              
                if (!string.IsNullOrEmpty(JobNo) || !string.IsNullOrEmpty(User) || !string.IsNullOrEmpty(FromDate) || !string.IsNullOrEmpty(ToDate) || !string.IsNullOrEmpty(JobDate))
                {

                    if (JobType == "Import")
                        stmts.Ename = "IMPORT_search_User_Wise";
                    else if (JobType == "Export")
                        stmts.Ename = "EXPORT_search_User_Wise";
                    
                }
                else
                {
                   
                    if (JobType == "Import")
                        stmts.Ename = "IMPORT_search_All_User";
                    else if (JobType == "Export")
                        stmts.Ename = "EXPORT_search_All_User";
                }
                stmts.JOBNO = JobNo;
                stmts.USER = User;
                
                stmts.FROMDATE = FromDate;
                stmts.TODATE = ToDate;
                stmts.Jobdate = JobDate;
                
                stmts.Workingperiod = Working_Period;

                dt = stmts.RetrieveAll_Details();
                if (dt.Rows.Count > 0)
                {
                    ReportGenerator gen = new ReportGenerator(dt, dsName);
                    ReportDataSource ds = new ReportDataSource(dsName, dt);
                    ReportViewer1.Reset();
                    ReportViewer1.LocalReport.DataSources.Add(ds);
                    ReportViewer1.LocalReport.DisplayName = dsName;
                    ReportViewer1.LocalReport.LoadReportDefinition(gen.GeneraReport());
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