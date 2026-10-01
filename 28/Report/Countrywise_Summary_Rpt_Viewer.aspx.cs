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
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Linq;

public partial class Report_Countrywise_Summary_Rpt_Viewer : System.Web.UI.Page
{


    public string working_period;
    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();

    private string _Workingperiod;
    public string cc;
    public string str1;

    DataSet License_ds = new DataSet();
    Double DEBIT_AMT = 0.0;

    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;


    Date_Time dt = new Date_Time();

    string Jobtype;
        
    Country_Summary summary = new Country_Summary();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

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
            //jobno_load();

            Load_Country();

            Get_Details();

            btn_print.Visible = false;
            btnSend.Visible = false;

        }
    }

    private void Load_Country()
    {
       
        Working_Period = Session["WorkingPeriod"].ToString();

        summary.Jobno = "0";
        summary.Type = "select_country";
        summary.BRANCH_COMMON = SELECT_BRANCH;

        ddlCountry_Name.DataSource = summary.Countrywise_Summary();
        ddlCountry_Name.DataValueField = "COUNTRY_NAME";
        ddlCountry_Name.DataTextField = "COUNTRY_NAME";
        ddlCountry_Name.DataBind();
        ddlCountry_Name.Items.Remove("0");
        ddlCountry_Name.Items.Insert(0, "Select");
    }

    private void Get_Details()
    {
        DataSet ds = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        localReport.ReportPath = @"Report\Chart_Testing.rdlc";

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();

        summary.Jobno = "0";
        summary.BRANCH_COMMON = SELECT_BRANCH;
        summary.Type = "IMP";
        ds = summary.Countrywise_Summary();

        ReportDataSource datasource = new ReportDataSource("Countrywise_Summary", ds.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);

        ReportViewer1.LocalReport.DisplayName = "Country Wise Summary";

        ReportViewer1.LocalReport.Refresh();


        //--------------------------------------To Print------------------------------------------------------------------------------------//
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;

        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        Session.Remove("report");
        Session["report"] = bytes;
    }




    //--------------------------------------


}