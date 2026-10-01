using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;

public partial class Report_Import_Duty_Intimation_Rpt_Viewer : System.Web.UI.Page
{

    CheckList CHKLIST = new CheckList();
    DataSet ds = new DataSet();
    
    public string currentuser, ddlJobNo, SB_NO;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    AppSession aps = new AppSession();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
            // commented for areawise implementation on 05-mar-2020
        /*
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
          * */
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
                {

                }
                else
                {
                    ddlJobNo = Request.QueryString["jobno"].ToString();
                    Session["JobNo"] = ddlJobNo;
                    ReportViewer1.LocalReport.DataSources.Clear();
                  
                    CHKLIST.JOBNo = ddlJobNo;
                    CHKLIST.Ename = "select_duty_intimation_Rpt";

                    CHKLIST.Workingperiod = SELECT_BRANCH;
                    ds = CHKLIST.RetrieveAll_General_Details();

                    List<ReportParameter> paramList = new List<ReportParameter>();
                    this.ReportViewer1.LocalReport.SetParameters(paramList);
                    ReportViewer1.LocalReport.DataSources.Clear();

                    ReportDataSource dataSource1 = new ReportDataSource("Duty_Intimation", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Add(dataSource1);

                    string TR6_Challan = ds.Tables[0].Rows[0]["TR6_CHALLAN_NO"].ToString();
                    string EDD = ds.Tables[0].Rows[0]["EDD"].ToString();

                    ReportParameter TR6_Challan1 = new ReportParameter("TR6_Challan", TR6_Challan);
                    ReportParameter EDD1 = new ReportParameter("EDD", EDD);

                    ReportParameter[] p = { TR6_Challan1, EDD1 };
                    ReportViewer1.LocalReport.SetParameters(p);


                    //--------------------------------------To Print------------------------------------------------------------------------------------//
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = string.Empty;
                    string encoding = string.Empty;
                    string extension = string.Empty;
                    string fileName = "a";
                    byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                    Session.Remove("report");
                    Session["report"] = bytes;
                    //--------------------------------------To Print------------------------------------------------------------------------------------//

                }
            }
            catch (Exception ex)
            {
                ErrorLogs er = new ErrorLogs();

                er.makeLog
                    (ex.Message);
            }
        }
    }
}