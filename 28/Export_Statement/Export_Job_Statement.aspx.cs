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

public partial class Export_Statement_Export_Job_Statement : System.Web.UI.Page
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
    Statement stmts = new Statement();
    public string SELECT_TYPE, SELECT_BRANCH;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        //comp_ConnectionStr = Session["currentcomp_db"].ToString();

        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }


        if (!IsPostBack)
        {
            string dsName = "ExportJobStatement";// ddlJobNo.SelectedValue;

            //#region SQL

            //SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
            //SqlCommand cmd = new SqlCommand("SELECT * FROM dbo." + dsName, con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            //#endregion

            stmts.JOBNO = "0";
            stmts.Ename = "select_All_JobNo";
            stmts.Workingperiod = SELECT_BRANCH;
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