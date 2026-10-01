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



public partial class Transaction_Default2 : System.Web.UI.Page
{
    #region Private_Attributes
    private string _BE_NO;
    private string _BE_NO_DATE;
    private string _JOB_NO;
    private string _Today_dt;
    //private string _IGM_TRANSPORTMODE;
    //General Details
    private string _Importer_Name;

    private string _TRANSPORT_MODE;
   
    private string _CUSTOMS_HOUSE;
    
    private string _SECTION46;
    private string _FIRSTCHECK;
    private string _GREEN_CHANNEL;
    private string _KACHHA_BE;
    private string _SECTION48;
    private string _HIGH_SEA_SALE_NAME;
    private string _HIGH_SEA_IEC;
    private string _HIGH_SEA_BRANCH_SL_NO;
    private string _HSS_ADD1;
    private string _HSS_ADD2;
    private string _HSS_ADD3;
    private string _HSS_ADD4;
    private string _HSS_ADD5;
    private string _SUPPLIER_COUNTRY_NAME;
    private string _SUPPLIER_COUNTRY_PINCODE;
    private string _SVB_ASSESABLE_STATUS;
    private string _SVB_DUTY_STATUS;
    //IGM
   
   
    // Invoice Details
    //private string _INVOICE_SLNO;
    private string _INVOICE_NO;
   

    //ITEM DETAILS
    //private string _ITEM_SLNO;

    //private string _SCHEME_CODE;

    #endregion
    #region Public_Attributes
  
    //public string SCHEME_NOTN_ = "";
    public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }
    public string BE_NO_DATE { get { return _BE_NO_DATE; } set { _BE_NO_DATE = value; } }
    public string JOB_NO { get { return _BE_NO; } set { _JOB_NO = value; } }
    public string Today_dt { get { return _BE_NO; } set { _Today_dt = value; } }
    public string Importer_Name { get { return _Importer_Name; } set { _Importer_Name = value; } }
    //public string IGM_TRANSPORTMODE { get { return _IGM_TRANSPORTMODE; } set { _IGM_TRANSPORTMODE = value; } }

    //General Details

    public string SECTION46 { get { return _SECTION46; } set { _SECTION46 = value; } }
    public string FIRSTCHECK { get { return _FIRSTCHECK; } set { _FIRSTCHECK = value; } }
    public string GREEN_CHANNEL { get { return _GREEN_CHANNEL; } set { _GREEN_CHANNEL = value; } }
    public string KACHHA_BE { get { return _KACHHA_BE; } set { _KACHHA_BE = value; } }
    public string SECTION48 { get { return _SECTION48; } set { _SECTION48 = value; } }
   
    //public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
         
    #endregion


    public string working_period;
    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();
        CheckList chklist = new CheckList();

    private string _Workingperiod, _INVOICE_ID;
   
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
 

    public string errorFolder = "";
    Job_Histroy jh = new Job_Histroy();
    DataSet job_his = new DataSet();

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
    public string REPORT_TYPE;
    
    CheckList CHKLIST = new CheckList();
    //Customer c = new Customer();
    Date_Time dt = new Date_Time();
    private string _MIS_CHARGES_;
    public string MIS_CHARGES_ { get { return _MIS_CHARGES_; } set { _MIS_CHARGES_ = value; } }
 
    DataTable dtt = new DataTable();
    public double Ass_Value_ttl;
    GridView gv = new GridView();
    //List<Transaction_Default2> Load_Invoice_Details = new List<Transaction_Default2>();

    List<INVOICE_DETAILS> Load_Invoice_Details = new List<INVOICE_DETAILS>();
    List<Transaction_Default2> Load_Item_Details = new List<Transaction_Default2>();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        //currentcomp_name = Session["currentcomp_name"].ToString();
        //comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        if (Request.QueryString["Value"] == "" || Request.QueryString["Value"] == null)
        {

        }
        else
        {
            REPORT_TYPE = Request.QueryString["Value"].ToString();

            if (REPORT_TYPE == "DGFT_Manufacturer")
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/NIPPON/DGFT_Manufacturing_Report.rdlc");
            }
            else
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/NIPPON/DGFT_Trading_Report.rdlc");
            }
        }

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
            
            jobno_load();
           
            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {

            }
            else
            {
                ddlJob_No.SelectedValue = Request.QueryString["jobno"].ToString();

                Page_loaItem_Details();
            }
        }

    }
   
   
    public void Page_loaItem_Details()
    {
        try
        {
            //if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            //{

            //}
            if (ddlJob_No.SelectedValue == "" || ddlJob_No.SelectedValue == null)
            {

            }
            else
            {
                //ddlJobNo = Request.QueryString["jobno"].ToString();
                //Session["JobNo"] = ddlJobNo;
                Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
            
                chklist.JOBNo = ddlJob_No.SelectedItem.Text;
                //chklist.Ename = "select_jobno_CheckList";
                chklist.Ename = "Checklist";

                chklist.Workingperiod = SELECT_BRANCH;
                ds = chklist.RetrieveAll_General_Details();

                if (REPORT_TYPE == "DGFT_Manufacturer")
                {
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/NIPPON/DGFT_Manufacturing_Report.rdlc");
                }
                else
                {
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/NIPPON/DGFT_Trading_Report.rdlc");
                }
                      
                List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);

                ReportViewer1.LocalReport.DataSources.Clear();

                if (ds.Tables[9].Rows.Count > 0)
                {
                    BE_NO = ds.Tables[9].Rows[0]["BE_NO"].ToString();
                    BE_NO_DATE = ds.Tables[9].Rows[0]["BE_DATE"].ToString().Replace("01/01/1900","");

                }
                else
                {
                    BE_NO = "";
                    BE_NO_DATE = "";
                }

                ReportParameter param1 = new ReportParameter("BE_NO", BE_NO);
                ReportParameter param2 = new ReportParameter("BE_NO_DATE", BE_NO_DATE);
                ReportParameter[] p = { param1, param2 };
                ReportViewer1.LocalReport.SetParameters(p);
               
                //ReportViewer1.LocalReport.DisplayName = "Imp Checklist "+ddlJob_No.SelectedItem.Text;

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
       
            }      
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }

   
    // ---------------------------------------------------Jono dropdown work--------------------

    private void jobno_load()
    {
        CheckList chklist = new CheckList();
        Working_Period = Session["WorkingPeriod"].ToString();

        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = SELECT_BRANCH;

        ddlJob_No.DataSource = chklist.RetrieveAll_General_Details();
        ddlJob_No.DataValueField = "JOBNO";
        ddlJob_No.DataTextField = "JOBNO";
        ddlJob_No.DataBind();
        ddlJob_No.Items.Remove("0");
        ddlJob_No.Items.Insert(0, "Select");
    }

    protected void ddlJob_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJob_No.SelectedItem.Text != "Select")
        {
            Page_loaItem_Details();
            // remove
            //ReportViewer1.LocalReport.DataSources.Clear();
            //Response.Redirect("../Report/Import_ReportViewer.aspx?jobno=" + ddlJob_No.SelectedItem.Text + "");
            //Response.Redirect("../Report/DGFT_Manufacturing_ReportViewer.aspx?jobno=" + ddlJob_No.SelectedItem.Text + "");

        }
    }
}