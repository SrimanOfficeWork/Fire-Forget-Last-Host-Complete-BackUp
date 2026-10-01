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



public partial class Import_Declaration : System.Web.UI.Page
{


    //---------------------ITEM ATTRIBUTES-----------------//
    
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

    IMP_Dec_I_II DEC = new IMP_Dec_I_II();
 
   
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
            jobno_load();

            btn_print.Visible = false;
            btnSend.Visible = false;
               
        }
    }

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
        try
        {
            
            if (Request.QueryString["DL"] == "" || Request.QueryString["DL"] == null)
            {

            }
            else
            {
                if (ddlJob_No.SelectedItem.Text != "Select")
                {

                    Jobtype = Request.QueryString["DL"].ToString();
                    if (Jobtype == "I")
                    {
                        Decl_I();
                    }
                    else if (Jobtype == "II")
                    {
                        Decl_II();
                    }
                    else if (Jobtype == "III")
                    {
                        Decl_III();
                    }
                    btn_print.Visible = true;
                    btnSend.Visible = true;
                    ReportViewer1.Visible = true;
                }
                else
                {
                    btn_print.Visible = false;
                    btnSend.Visible = false;
                    
                    ReportViewer1.Visible = false;
                }
            }

        }

        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }

    }
    private void Decl_I()
    {
        DataSet ds = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        localReport.ReportPath = @"Report\Import_Declaration_1.rdlc";

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();

        DEC.Jobno = ddlJob_No.SelectedItem.Text;
        DEC.BRANCH_COMMON = SELECT_BRANCH;
        DEC.Type = "IMP";
        ds = DEC.Dec_getdata_I();

        ReportDataSource datasource = new ReportDataSource("IMP_DECLARATION_I", ds.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);

        ReportViewer1.LocalReport.DisplayName = "DeclarationI";


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
    private void Decl_II()
    {
        DataSet ds = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        localReport.ReportPath = @"Report\Import_Declaration_2.rdlc";

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();

        DEC.Jobno = ddlJob_No.SelectedItem.Text;
        DEC.BRANCH_COMMON = SELECT_BRANCH;
        DEC.Type = "IMP";
        ds = DEC.Dec_getdata();

        ReportDataSource datasource = new ReportDataSource("Declaration", ds.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);

        ReportViewer1.LocalReport.DisplayName = "DeclarationII";
       
        //--------------------------------------To Print------------------------------------------------------------------------------------//
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;

        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        Session.Remove("report");
        Session["report"] = bytes;
        //--------------------------------------To Print
    }

    private void Decl_III()
    {
        int i=0;
        
        DataSet ds = new DataSet();
        LocalReport localReport = ReportViewer1.LocalReport;
        localReport.ReportPath = @"Report\Import_Declaration_3.rdlc";

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();

        DEC.Jobno = ddlJob_No.SelectedItem.Text;
        DEC.BRANCH_COMMON = SELECT_BRANCH;
        DEC.Type = "IMP_Declaration_3";
        ds = DEC.Dec_getdata_I();

        ReportParameter Importer_name = new ReportParameter("Importer", ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString()+"....");
        ReportParameter InvoiceDate = new ReportParameter("Inv_Date", ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString()+"....");
        DataTable dt = ds.Tables[0];
        DataRow row = dt.Rows[i];


        //********************************************
        int dss = ds.Tables[0].Rows.Count;

        ArrayList arrayList = new ArrayList();

        for (i = 0; i <= dss - 1; i++)
        {
            arrayList.Add(ds.Tables[0].Rows[i]["INVOICE_NO"].ToString());

        }

        string str = string.Empty;
        foreach (string strName in arrayList)
        {

            str += strName + ",";

            str1 = str.TrimEnd(',');
        }

        cc = str1;

        //********************************************


        string xx = "";

        ReportParameter Invoice_no = new ReportParameter("Invoice_no", cc);


        ReportDataSource datasource = new ReportDataSource("DeclarationIII_DataSet1", ds.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(datasource);


        ReportParameter[] p = { Importer_name, Invoice_no, InvoiceDate };
        ReportViewer1.LocalReport.SetParameters(p);

        ReportViewer1.LocalReport.DisplayName = "DeclarationIII";

        //--------------------------------------To Print------------------------------------------------------------------------------------//
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;

        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        Session.Remove("report");
        Session["report"] = bytes;
        //--------------------------------------To Print
    }


   

}