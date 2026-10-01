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
    Statement stmts = new Statement();
    string JobNo, Exporter, Consignee, FromDate, ToDate, JobDate, Transport_mode, InvoiceNo;
    public string SELECT_TYPE, SELECT_BRANCH;

    protected void Page_Load(object sender, EventArgs e)
    {
         aps.checkSession();
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

                if (!string.IsNullOrEmpty(Request["JobNo"]))
                {
                    JobNo = Request["JobNo"].ToString();
                }
                else
                {
                    //JobNo = "";
                }

                if (!string.IsNullOrEmpty(Request["Exporter"]))
                {
                    Exporter = Request["Exporter"].ToString();
                }
                else
                {
                    //Exporter = "";
                }
                if (!string.IsNullOrEmpty(Request["Consignee"]))
                {
                    Consignee = Request["Consignee"].ToString();
                }
                else
                {
                    //Consignee = "";
                }
                if (!string.IsNullOrEmpty(Request["InvoiceNo"]))
                {
                    InvoiceNo = Request["InvoiceNo"].ToString();
                }
                else
                {
                    //Consignee = "";
                }
                                
                if (!string.IsNullOrEmpty(Request["FromDate"]))
                {
                    FromDate = Request["FromDate"].ToString();
                }
                //else
                //{
                //    FromDate = "";
                //}
                
                if (!string.IsNullOrEmpty(Request["ToDate"]))
                {
                    ToDate = Request["ToDate"].ToString();
                }
                if (!string.IsNullOrEmpty(Request["JobDate"]))
                {
                    JobDate = Request["JobDate"].ToString();
                }
                if (!string.IsNullOrEmpty(Request["Trans_mode"]))
                {
                    Transport_mode = Request["Trans_mode"].ToString();
                }
                //else
                //{
                //    ToDate = "";
                //}


                string dsName = "ExportJobStatement";// ddlJobNo.SelectedValue;
              
                //#region SQL
              
                //SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM dbo." + dsName, con);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.Fill(dt);
                //#endregion
                if (!string.IsNullOrEmpty(JobNo) || !string.IsNullOrEmpty(Exporter) || !string.IsNullOrEmpty(Consignee) || !string.IsNullOrEmpty(InvoiceNo) || !string.IsNullOrEmpty(FromDate) || !string.IsNullOrEmpty(ToDate) || !string.IsNullOrEmpty(JobDate) || !string.IsNullOrEmpty(Transport_mode))
                {
                    stmts.Ename = "ALL_Search_Wise";
                }
                else
                {
                    stmts.Ename = "select_All_JobNo";
                }
                stmts.JOBNO = JobNo;
                stmts.EXPORTER_NAME = Exporter;
                stmts.CONSIGNEE_NAME = Consignee;
                stmts.INVOICE_NO = InvoiceNo;
                stmts.FROMDATE = FromDate;
                stmts.TODATE = ToDate;
                stmts.Jobdate = JobDate;
                stmts.Transport_mode = Transport_mode;
                
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
                else
                    lblerror.InnerText = "No Record Found.";
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