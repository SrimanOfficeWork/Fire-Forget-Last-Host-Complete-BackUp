using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
//using System.Diagnostics;
using System.Data.SqlClient;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using Microsoft.Reporting.WebForms;

public partial class Import_License_Report : System.Web.UI.Page
{
  
    AppSession aps = new AppSession();
    eroyalmaster erm = new eroyalmaster();

    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();

    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate,testaddress;
    public string SELECT_TYPE, SELECT_BRANCH;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();

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
            Page_loaItem_Details();
           
        }
    }
   
    public void Page_loaItem_Details()
    {
        try
        {
            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {
           
            }
            else
            {
                erm.LICENSE_NO = Request.QueryString["jobno"].ToString();
                erm.LICENSE_DATE = "";
                erm.PORT_OF_LICENSE = "";
                erm.EWorking_Period = SELECT_BRANCH;
                erm.Ename = "select_License_Details";
                ds1 = erm.RetrieveAll_IMPORT_LICENSE_DEBIT_AMT_REPORT();

               
                List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource dataSS = new ReportDataSource("License_Debit_Report", ds1.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(dataSS);

                ReportDataSource data = new ReportDataSource("License_Job_Debit", ds1.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(data);

                ReportParameter param=new ReportParameter("Name",ds1.Tables[2].Rows[0]["IMPORTER_NAME"].ToString());
                ReportParameter param1 = new ReportParameter("NotnNo", ds1.Tables[2].Rows[0]["SCHEME_NOTN"].ToString());

                ReportParameter param2 = new ReportParameter("CHA_NAME", HttpContext.Current.Session["CHA_NAME"].ToString());

                ReportParameter[] p = { param, param1, param2 };           
                ReportViewer1.LocalReport.SetParameters(p);


                ////--------------------------------------To Print------------------------------------------------------------------------------------//
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                string fileName = "a";
                byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Session.Remove("report");
                Session["report"] = bytes;
                ////--------------------------------------To Print------------------------------------------------------------------------------------//

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




