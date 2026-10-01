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

public partial class Import_Statement_ReportViewer : System.Web.UI.Page
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
    Statements stmts = new Statements();
    string JobNo, Importer, Branch, FromDate, ToDate, JobDate, Transport_mode, ImporterName,From_To_Date;
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


                if (!string.IsNullOrEmpty(Request["Importer"]))
                {
                    Importer = Request["Importer"].ToString();
                }
                else
                {
                    //Importer = "";
                }

                if (!string.IsNullOrEmpty(Request["Trans_mode"]))
                {
                    Transport_mode = Request["Trans_mode"].ToString();
                }
                //else
                //{
                //    ToDate = "";
                //}
             
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
             
                if (!string.IsNullOrEmpty(Request["Branch"]))
                {
                    Branch = Request["Branch"].ToString();
                }
                else
                {
                    //Branch = "";
                }

                string dsName = "ImportJobStatement";// ddlJobNo.SelectedValue;
              
                //#region SQL
              
                //SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM dbo." + dsName, con);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.Fill(dt);
                //#endregion
                if ( !string.IsNullOrEmpty(Importer) || !string.IsNullOrEmpty(Transport_mode) || !string.IsNullOrEmpty(FromDate) || !string.IsNullOrEmpty(ToDate) || !string.IsNullOrEmpty(JobDate) || !string.IsNullOrEmpty(Branch))
                {
                    stmts.Ename = "Get_Import_Details";
                }
                else
                {
                    stmts.Ename = "select_All_JobNo";
                }
                stmts.JOBNO = JobNo;
                stmts.IMPORTER_NAME = Importer;
                stmts.BRANCH = Branch;
                stmts.FROMDATE = FromDate;
                stmts.TODATE = ToDate;
                stmts.Jobdate = JobDate;
                stmts.Transport_mode = Transport_mode;
                stmts.JOB_TYPE = "Import";

                
                stmts.Workingperiod = SELECT_BRANCH;

                ds = stmts.Retreive_All_Statement_II();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Importer != "All")
                    {
                         ImporterName = Importer;
                    }
                    else
                    {
                         ImporterName = "";
                    }

                    if (FromDate != "" || ToDate != "")
                    {
                        From_To_Date = " IMPORT REGISTER FROM   " + FromDate + "   to   " + ToDate;
                    }
                    else
                    {
                        From_To_Date = "";
                    }

                    //string ImporterName=ds.Tables[0].Rows[0]["Imp_Name"].ToString();
                    string CHA_NAME = HttpContext.Current.Session["CHA_NAME"].ToString();
                    string From_Date = ds.Tables[0].Rows[0]["Imp_Name"].ToString();
                    string To_Date = ds.Tables[0].Rows[0]["Imp_Name"].ToString();
                    

                    LocalReport localReport = ReportViewer1.LocalReport;
                    localReport.ReportPath = @"Import_Statement/IMPORT_STMT_II_Report.rdlc";

                    List<ReportParameter> paramList1 = new List<ReportParameter>();
                    this.ReportViewer1.LocalReport.SetParameters(paramList1);
                    ReportViewer1.LocalReport.DataSources.Clear();

                    List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);
                    ReportViewer1.LocalReport.DataSources.Clear();

                    ReportParameter rp1 = new ReportParameter("ImporterName", ImporterName);
                    ReportParameter rp2 = new ReportParameter("CHA_NAME", CHA_NAME);
                    ReportParameter rp3 = new ReportParameter("From_To_Date", From_To_Date);
                    
                    ReportDataSource dataSS = new ReportDataSource("IMPORT_STMT_II_DataSet1", stmts.Load_Statement_II(ds.Tables[0]));
                    ReportViewer1.LocalReport.DataSources.Add(dataSS);

                    ReportParameter[] p = { rp1, rp2,rp3 };
                    ReportViewer1.LocalReport.SetParameters(p);

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