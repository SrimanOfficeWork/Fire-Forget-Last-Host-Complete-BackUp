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
    DataTable dt = new DataTable();
    AppSession aps = new AppSession();
    User_Wise_Job_Report UR = new User_Wise_Job_Report();

    protected void Page_Load(object sender, EventArgs e)
    {
           aps.checkSession();

            if (!IsPostBack)
            {
                string ReportName = string.Empty;

                if (!string.IsNullOrEmpty(Request["User"]))
                {
                    ReportName = Request["JobType"].ToString()+"_"+ Request["User"].ToString();
                }
                else
                {
                    ReportName = Request["JobType"].ToString() + "_" + "All";
                }

                UR.IMP_EXP = Request["JobType"].ToString();
                UR.Branch = Request["Branch"].ToString();
                UR.Username = Request["User"].ToString();
                UR.Flag = "";
                UR.From_date = Request["FromDate"].ToString();
                UR.To_date = Request["ToDate"].ToString();
                UR.Job_Sort = Request["Jobsort"].ToString();
                
                ds = UR.Select_Master_Search();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                }

                if (dt.Rows.Count > 0)
                {
                    ReportGenerator gen = new ReportGenerator(dt, ReportName);
                    ReportDataSource dss = new ReportDataSource(ReportName, dt);
                    ReportViewer1.Reset();
                    ReportViewer1.LocalReport.DataSources.Add(dss);
                    ReportViewer1.LocalReport.DisplayName = ReportName;
                    ReportViewer1.LocalReport.LoadReportDefinition(gen.GeneraReport());
                }
                else
                {
                    ltmsg.Text = "NO RECORD FOUND";
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