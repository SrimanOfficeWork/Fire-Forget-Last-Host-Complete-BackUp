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

public partial class Export_Invoice_rpt_viewer : System.Web.UI.Page
{
    Rpt_Invoice Rpt_inv = new Rpt_Invoice();
    Export_CheckList CHKLIST = new Export_CheckList();
    Date_Time dt = new Date_Time();
    DataSet ds = new DataSet();
    DataTable grid_dt = new DataTable();
    DataSet ds1 = new DataSet();
    public string currentuser, ddlJobNo, SB_NO;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();


    # region Private Attributes


    private string _CER_ORG_ID;
    private string _JOBNO;
    private string _FILE_REF_NO;
    private string _TO_ORDER;
    private string _EXPORTER_NAME;
    private string _BRANCH_NO;
    private string _IEC_NO;
    private string _ADDRESS1;
    private string _ADDRESS2;
    private string _ADDRESS3;
    private string _ADDRESS4;
    private string _ADDRESS5;

    private string _CONSIGNEE_NAME;
    private string _CONSIGNEE_ADD1;
    private string _CONSIGNEE_ADD2;
    private string _CONSIGNEE_ADD3;
    private string _CONSIGNEE_ADD4;
    private string _CONSIGNEE_ADD5;

    private string _NOTIFY_NAME;
    private string _NOTIFY_ADD1;
    private string _NOTIFY_ADD2;
    private string _NOTIFY_ADD3;
    private string _NOTIFY_ADD4;
    private string _NOTIFY_ADD5;

    private string _PRE_CARRIAGE_BY;
    private string _PLACE_OF_RECEIPT;
    private string _VESSEL_FLIGHT_NO;
    private string _PORT_OF_LOADING;
    private string _PORT_OF_DISCHARGE;
    private string _FINAL_DEST;
    private string _MARK_NOS_CONTAINER_NO;
    private string _NO_KIND_OF_PACKAGES;
    private string _DESCRIPTION_GOODS;
    private string _ORIGIN_CRITERIA;

    private string _GROSS_WEIGHT;

    private string _MEASUREMENT;
    private string _NO_DATE_OF_INVOICE;
    private string _IMPORTING_COUNTRY;
    private string _REMARKS;
    private string _AUTHORISED_SIGNATORY;
    private string _SIGNATURE_DATE;

    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;

    private string _Ename;

    private string _startRowIndex;

    private string _maximumRows;
    private string _totalRows;


    #endregion

    # region Public Attributes

    public string CER_ORG_ID { get { return _CER_ORG_ID; } set { _CER_ORG_ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }
    public string TO_ORDER { get { return _TO_ORDER; } set { _TO_ORDER = value; } }

    public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
    public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
    public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }

    public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
    public string CONSIGNEE_ADD1 { get { return _CONSIGNEE_ADD1; } set { _CONSIGNEE_ADD1 = value; } }
    public string CONSIGNEE_ADD2 { get { return _CONSIGNEE_ADD2; } set { _CONSIGNEE_ADD2 = value; } }
    public string CONSIGNEE_ADD3 { get { return _CONSIGNEE_ADD3; } set { _CONSIGNEE_ADD3 = value; } }
    public string CONSIGNEE_ADD4 { get { return _CONSIGNEE_ADD4; } set { _CONSIGNEE_ADD4 = value; } }
    public string CONSIGNEE_ADD5 { get { return _CONSIGNEE_ADD5; } set { _CONSIGNEE_ADD5 = value; } }

    public string NOTIFY_NAME { get { return _NOTIFY_NAME; } set { _NOTIFY_NAME = value; } }
    public string NOTIFY_ADD1 { get { return _NOTIFY_ADD1; } set { _NOTIFY_ADD1 = value; } }
    public string NOTIFY_ADD2 { get { return _NOTIFY_ADD2; } set { _NOTIFY_ADD2 = value; } }
    public string NOTIFY_ADD3 { get { return _NOTIFY_ADD3; } set { _NOTIFY_ADD3 = value; } }
    public string NOTIFY_ADD4 { get { return _NOTIFY_ADD4; } set { _NOTIFY_ADD4 = value; } }
    public string NOTIFY_ADD5 { get { return _NOTIFY_ADD5; } set { _NOTIFY_ADD5 = value; } }

    public string PRE_CARRIAGE_BY { get { return _PRE_CARRIAGE_BY; } set { _PRE_CARRIAGE_BY = value; } }
    public string PLACE_OF_RECEIPT { get { return _PLACE_OF_RECEIPT; } set { _PLACE_OF_RECEIPT = value; } }
    public string VESSEL_FLIGHT_NO { get { return _VESSEL_FLIGHT_NO; } set { _VESSEL_FLIGHT_NO = value; } }
    public string PORT_OF_LOADING { get { return _PORT_OF_LOADING; } set { _PORT_OF_LOADING = value; } }
    public string PORT_OF_DISCHARGE { get { return _PORT_OF_DISCHARGE; } set { _PORT_OF_DISCHARGE = value; } }
    public string FINAL_DEST { get { return _FINAL_DEST; } set { _FINAL_DEST = value; } }
    public string MARK_NOS_CONTAINER_NO { get { return _MARK_NOS_CONTAINER_NO; } set { _MARK_NOS_CONTAINER_NO = value; } }
    public string NO_KIND_OF_PACKAGES { get { return _NO_KIND_OF_PACKAGES; } set { _NO_KIND_OF_PACKAGES = value; } }
    public string DESCRIPTION_GOODS { get { return _DESCRIPTION_GOODS; } set { _DESCRIPTION_GOODS = value; } }
    public string ORIGIN_CRITERIA { get { return _ORIGIN_CRITERIA; } set { _ORIGIN_CRITERIA = value; } }
    public string GROSS_WEIGHT { get { return _GROSS_WEIGHT; } set { _GROSS_WEIGHT = value; } }

    public string MEASUREMENT { get { return _MEASUREMENT; } set { _MEASUREMENT = value; } }

    public string NO_DATE_OF_INVOICE { get { return _NO_DATE_OF_INVOICE; } set { _NO_DATE_OF_INVOICE = value; } }
    public string IMPORTING_COUNTRY { get { return _IMPORTING_COUNTRY; } set { _IMPORTING_COUNTRY = value; } }
    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }
    public string AUTHORISED_SIGNATORY { get { return _AUTHORISED_SIGNATORY; } set { _AUTHORISED_SIGNATORY = value; } }
    public string SIGNATURE_DATE { get { return _SIGNATURE_DATE; } set { _SIGNATURE_DATE = value; } }

  
    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }


    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    public string TOTAL_GROSS_WEIGHT;

    #endregion

    List<Export_Invoice_rpt_viewer> Rpt_Certificate_Of_Origin = new List<Export_Invoice_rpt_viewer>();

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

                    //currentuser = Session["currentuser"].ToString();
                    //currentbranch = Session["currentbranch"].ToString();
                    //currentcomp_name = Session["currentcomp_name"].ToString();
                    //comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
                    //Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
                    //LoginDate = HttpContext.Current.Session["LoginDate"].ToString();

                    //List<ReportParameter> paramList = new List<ReportParameter>();this.ReportViewer1.LocalReport.SetParameters(paramList);

                    ReportViewer1.LocalReport.DataSources.Clear();
                    //---------------------Dataset Value Calling From webservice EXPORT CHECKLIST PAGE------------------------------//
                    //ds = (DataSet)HttpContext.Current.Session["EXPORT_CHECKLIST"];
                   

                    //---------------------Dataset Value Calling From webservice EXPORT CHECKLIST PAGE------------------------------//

                    Load_Invoice();
                    Load_InvoiceGrid();
                 
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

    public void Load_Invoice()
    {
        Rpt_Invoice Rpt_inv = new Rpt_Invoice();
        Rpt_inv.JOBNO = Session["JobNo"].ToString();

        ReportDataSource dataSource1 = new ReportDataSource("LOAD_EXPORT_INVOICE", Rpt_inv.Load_Export_Invoice_Details());
      
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);
        
        //grid_dt = Rpt_inv.ds.Tables[1];
        ReportDataSource dataSource = new ReportDataSource("LOAD_EXPORT_INVOICE_GRID", Rpt_inv.Load_Export_Invoice_grid_Details(Rpt_inv.ds.Tables[1], Rpt_inv.FREIGHT));
        ReportViewer1.LocalReport.DataSources.Add(dataSource);

    }
    public void Load_InvoiceGrid1()
    {
        

        ReportDataSource dataSource1 = new ReportDataSource("LOAD_EXPORT_INVOICE_GRID", Rpt_inv.Load_Export_Invoice_Details());

        ReportViewer1.LocalReport.DataSources.Add(dataSource1);

    }

    public void Load_InvoiceGrid()
    {

        ReportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(ReportViewer1_SubreportProcessing);

    }

    protected void ReportViewer1_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {

        ReportDataSource dataSource = new ReportDataSource("LOAD_EXPORT_INVOICE_GRID", Rpt_inv.Load_Export_Invoice_grid_Details(grid_dt, Rpt_inv.FREIGHT));

        e.DataSources.Add(dataSource);
    }

}