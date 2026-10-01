using System;
using System.IO;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;

using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;
using System.Collections.Generic;
using System.Data.SqlClient;


public partial class ManualBE_ReportViewer : System.Web.UI.Page
{

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string working_period;
    public string Company_ID;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;

    ErrorLogs er = new ErrorLogs();
    AppSession aps = new AppSession();
    DataSet ds = new DataSet();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
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
            Page_loaItem_Details();
           
        }
    }


    public void Page_loaItem_Details()
    {

        ds.Clear();
        try
        {
            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {

            }
            else
            {

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                Import_ManualBE_LC BE = new Import_ManualBE_LC();
                BE.Jobno = Request.QueryString["jobno"].ToString();
                //BE.M_BRANCHCODE = null;
                BE.M_BRANCHCODE = SELECT_BRANCH;
                BE.Working_Period = " ";
                ds = BE.Manual_BE_rpt();

                ReportDataSource datasource = new ReportDataSource("Manual_BE", ds.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);

                ReportDataSource datasource2 = new ReportDataSource("Manual_BE_2", ds.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);

                ReportViewer1.LocalReport.DisplayName = "ManualBE";

                //--------------------------------------To Print------------------------------------------------------------------------------------//
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

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




