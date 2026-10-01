using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;

using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;
using System.Collections.Generic;
using System.Data.SqlClient;
using BussinessObject;

public partial class Report_Purchase_Entry : System.Web.UI.Page
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
            //if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            //{

            //}
            //else
            //{

                List<ReportParameter> paramList = new List<ReportParameter>();
                ReportParameter parameter = new ReportParameter();
                parameter.Name = "comname";
                parameter.Values.Add(currentcomp_name);
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                this.ReportViewer1.LocalReport.SetParameters(parameter);
                ReportViewer1.LocalReport.DataSources.Clear();
            Billing_UserBO objUserBL=new Billing_UserBO();

                GST_Imp_Invoice PE = new GST_Imp_Invoice();
                objUserBL.VOUCHER_NO = Request.QueryString["voucherno"].ToString();
                //BE.M_BRANCHCODE = null;
                objUserBL.ENAME = "SELETG";
                //objUserBL.Working_Period = " ";
                ds = PE.PurchaseEntry(objUserBL);

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);

                ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);

                ReportViewer1.LocalReport.DisplayName = "Purchase Entry";

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
            //}


        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }

}