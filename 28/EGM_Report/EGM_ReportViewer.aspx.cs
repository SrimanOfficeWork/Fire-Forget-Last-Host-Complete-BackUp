using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;

using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
//using Microsoft.Reporting.WinForms;
using System.Web.UI.WebControls.WebParts;
//using ReportViewerLib;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;

public partial class Report_Export_Export_ReportViewer : System.Web.UI.Page
{

    EGM EGM = new EGM();
    DataSet ds = new DataSet();
    public string  ddlJobNo, jobno_ps;
    public string LoginDate, customhouse,transportmode;
    public string branch, Report_Type;

    AppSession aps = new AppSession();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        if (!IsPostBack)
        {
            try
            {
               
                if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null && Request.QueryString["branch"] == "" || Request.QueryString["branch"] == null && Request.QueryString["Report_Type"] == "" || Request.QueryString["Report_Type"] == null)
                {

                }
                else
                {
                    if (Request.QueryString["jobno_ps"] == "" || Request.QueryString["jobno_ps"] == null)
                    {
                        jobno_ps=" ";
                    }
                    else
                    {
                        jobno_ps = Request.QueryString["jobno_ps"].ToString();
                    }
                  
                    ddlJobNo = Request.QueryString["jobno"].ToString();
                    branch = Request.QueryString["branch"].ToString();
                    Report_Type = Request.QueryString["Report_Type"].ToString();

                    List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);
                    ReportViewer1.LocalReport.DataSources.Clear();

                    EGM.JOBNO = ddlJobNo;
                    EGM.Ename = "Select_EGM_checklist";
                    EGM.WORKINGPERIOD = Connection.Get_Company_Type();
                    if (Report_Type == "Consolidate")
                    {
                        ds = EGM.EGM_CONSOLIDATE_Select_All();
                    }
                    else
                    {
                        ds = EGM.EGM_Select_All();
                    }

                    EGM_Details();
                    EGM_Container_Details();

                    ReportParameter param = new ReportParameter("Title", Session["currentcomp_name"].ToString());
                   
                    ReportParameter[] p = { param };
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

    public void EGM_Details()
    {
        ReportDataSource dataSource1 = new ReportDataSource("DataSet1", ds.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);
    }

    public void EGM_Container_Details()
    {
        ReportDataSource dataSource = new ReportDataSource("DataSet2", ds.Tables[1]);
        ReportViewer1.LocalReport.DataSources.Add(dataSource);
    }   
}