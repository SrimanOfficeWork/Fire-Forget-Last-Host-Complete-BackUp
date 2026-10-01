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
//using System.Windows.Forms;
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
//using Microsoft.Office.Interop.Word;
//using Microsoft.Office.Core;
//using Microsoft.Office.Interop;
using System.Drawing.Design;


public partial class Report_Certificate_Of_Origin_Reportviewer : System.Web.UI.Page
{
    Export_CheckList CHKLIST = new Export_CheckList();
    Date_Time dt = new Date_Time();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    public string currentuser, ddlJobNo, SB_NO,Print_Type;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH, COMPANY_IDD;
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

    List<Report_Certificate_Of_Origin_Reportviewer> Rpt_Certificate_Of_Origin = new List<Report_Certificate_Of_Origin_Reportviewer>();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
        COMPANY_IDD = Session["COMPANY_ID"].ToString();

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

                    Print_Type = Request.QueryString["type"].ToString();
                    Session["Print_Type"] = Print_Type;

                    if (Print_Type == "1")
                    {
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/CertOfOrigin_Andhra.rdlc");
                    }
                    else if (Print_Type == "2")
                    {
                        if (COMPANY_IDD == "229")
                        {
                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/CertOfOrigin_Madras_TradeWings.rdlc");
                        }
                        else
                        {
                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/CertOfOrigin_Madras.rdlc");
                        }
                    }
                    else if (Print_Type == "3")
                    {
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/CertOfOrigin_SouthernIndia.rdlc");
                    }
                    else if (Print_Type == "4")
                    {
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/CertOfOrigin_TamilNadu.rdlc");
                    }

                    ReportViewer1.LocalReport.DataSources.Clear();
                    //Certificate_Of_Origin();                  

                    Get_Certificate_Of_Origin();
                    ReportDataSource dataSource1 = new ReportDataSource("Certificate_Of_Origin", Rpt_Certificate_Of_Origin);
                    ReportViewer1.LocalReport.DataSources.Add(dataSource1);

                    string pkgs = ds.Tables[0].Rows[0]["NO_KIND_OF_PACKAGES"].ToString() + Environment.NewLine + Environment.NewLine + ds.Tables[0].Rows[0]["DESCRIPTION_GOODS"].ToString();

                    ReportParameter param_Pkgs = new ReportParameter("No_Of_pkgs", pkgs);

                    if (Print_Type == "2" || Print_Type == "4")
                    {
                        ReportParameter[] p = { param_Pkgs };
                        ReportViewer1.LocalReport.SetParameters(p);
                    }

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

    public void Certificate_Of_Origin()
    {
        //Get_Certificate_Of_Origin(ds);
        ReportDataSource dataSource1 = new ReportDataSource("Certificate_Of_Origin", Rpt_Certificate_Of_Origin);
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);
    }

    public void Get_Certificate_Of_Origin()
    {
        try
        {
            Export_CheckList CHKLIST = new Export_CheckList();
            CHKLIST.JOBNo = ddlJobNo;
            CHKLIST.Ename = "select_certificate_of_origin";

            CHKLIST.TRANSPORT_MODE = "0";
            CHKLIST.CUSTOM_HOUSE = "0";
            CHKLIST.Workingperiod = SELECT_BRANCH;           
            ds = CHKLIST.RetrieveAll_General_Details();

            int i = CHKLIST.result;
         
            if (i == 2)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //JOBNO = ddlJobNo;
                    //FILE_REF_NO = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                    //TO_ORDER = ds.Tables[0].Rows[0]["TO_ORDER"].ToString();
                    EXPORTER_NAME = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                    //BRANCH_NO = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                    //IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
                    ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                    ADDRESS2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                    ADDRESS3 = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                    ADDRESS4 = ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
                    //ADDRESS5 = ds.Tables[0].Rows[0]["ADDRESS5"].ToString();

                    //EXPORTER_NAME = EXPORTER_NAME + ADDRESS1 + ADDRESS2 + ADDRESS3 + ADDRESS4 + ADDRESS5;

                    CONSIGNEE_NAME = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                    CONSIGNEE_ADD1 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                    CONSIGNEE_ADD2 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                    CONSIGNEE_ADD3 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                    CONSIGNEE_ADD4 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString() + "" + ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString();
                    //CONSIGNEE_ADD5 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString();

                    //CONSIGNEE_NAME = CONSIGNEE_NAME + CONSIGNEE_ADD1 + CONSIGNEE_ADD2 + CONSIGNEE_ADD3 + CONSIGNEE_ADD4 + CONSIGNEE_ADD5;

                    //NOTIFY_NAME = ds.Tables[0].Rows[0]["NOTIFY_NAME"].ToString();
                    //NOTIFY_ADD1 = ds.Tables[0].Rows[0]["NOTIFY_ADD1"].ToString();
                    //NOTIFY_ADD2 = ds.Tables[0].Rows[0]["NOTIFY_ADD2"].ToString();
                    //NOTIFY_ADD3 = ds.Tables[0].Rows[0]["NOTIFY_ADD3"].ToString();
                    //NOTIFY_ADD4 = ds.Tables[0].Rows[0]["NOTIFY_ADD4"].ToString();
                    //NOTIFY_ADD5 = ds.Tables[0].Rows[0]["NOTIFY_ADD5"].ToString();

                    //PRE_CARRIAGE_BY = ds.Tables[0].Rows[0]["PRE_CARRIAGE_BY"].ToString();
                    //PLACE_OF_RECEIPT = ds.Tables[0].Rows[0]["PLACE_OF_RECEIPT"].ToString();
                    //VESSEL_FLIGHT_NO = ds.Tables[0].Rows[0]["VESSEL_FLIGHT_NO"].ToString();
                    //PORT_OF_LOADING = ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString();
                    //PORT_OF_DISCHARGE = ds.Tables[0].Rows[0]["PORT_OF_DISCHARGE"].ToString();
                    //FINAL_DEST = ds.Tables[0].Rows[0]["FINAL_DEST"].ToString();

                    //MARK_NOS_CONTAINER_NO = ds.Tables[0].Rows[0]["MARK_NOS_CONTAINER_NO"].ToString();
                    //NO_KIND_OF_PACKAGES = ds.Tables[0].Rows[0]["NO_KIND_OF_PACKAGES"].ToString();
                    //DESCRIPTION_GOODS = ds.Tables[0].Rows[0]["DESCRIPTION_GOODS"].ToString();
                    //ORIGIN_CRITERIA = ds.Tables[0].Rows[0]["ORIGIN_CRITERIA"].ToString();
                    GROSS_WEIGHT = ds.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString();                    

                    //string[] s1 = GROSS_WEIGHT.Split(new string[] { " " }, StringSplitOptions.None);
                    //TOTAL_GROSS_WEIGHT = s1[0].ToString();
                   
                    MEASUREMENT = ds.Tables[0].Rows[0]["MEASUREMENT"].ToString();
                    GROSS_WEIGHT = GROSS_WEIGHT + " " + MEASUREMENT;
                    //NO_DATE_OF_INVOICE = ds.Tables[0].Rows[0]["NO_DATE_OF_INVOICE"].ToString();
                    //IMPORTING_COUNTRY = ds.Tables[0].Rows[0]["IMPORTING_COUNTRY"].ToString();
                    //REMARKS = ds.Tables[0].Rows[0]["REMARKS"].ToString();

                    //AUTHORISED_SIGNATORY = ds.Tables[0].Rows[0]["AUTHORISED_SIGNATORY"].ToString();
                    //SIGNATURE_DATE = ds.Tables[0].Rows[0]["SIGNATURE_DATE"].ToString();

                    Rpt_Certificate_Of_Origin.Add(new Report_Certificate_Of_Origin_Reportviewer()
                    {
                        JOBNO = ddlJobNo,
                        //Today_dt = dt.Today_Date(),
                        FILE_REF_NO = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString(),

                        TO_ORDER = ds.Tables[0].Rows[0]["TO_ORDER"].ToString(),
                        EXPORTER_NAME = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString().Replace("amp;", ""),
                        //BRANCH_NO = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString(),
                        //IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString(),
                        ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString().Replace("amp;", ""),
                        ADDRESS2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString().Replace("amp;", ""),
                        ADDRESS3 = ds.Tables[0].Rows[0]["ADDRESS3"].ToString().Replace("amp;", ""),
                        ADDRESS4 = ds.Tables[0].Rows[0]["ADDRESS4"].ToString().Replace("amp;", "") +" "+ ds.Tables[0].Rows[0]["ADDRESS5"].ToString().Replace("amp;", ""),
                        //ADDRESS5 = ds.Tables[0].Rows[0]["ADDRESS5"].ToString(),
                        //EXPORTER_NAME=EXPORTER_NAME,


                        CONSIGNEE_NAME = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString().Replace("amp;", ""),
                        CONSIGNEE_ADD1 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString().Replace("amp;", ""),
                        CONSIGNEE_ADD2 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString().Replace("amp;", ""),
                        CONSIGNEE_ADD3 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString().Replace("amp;", ""),
                        CONSIGNEE_ADD4 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString().Replace("amp;", "")+" "+ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString().Replace("amp;", ""),
                        //CONSIGNEE_ADD5 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString(),

                        //CONSIGNEE_NAME=CONSIGNEE_NAME,

                        NOTIFY_NAME = ds.Tables[0].Rows[0]["NOTIFY_NAME"].ToString().Replace("amp;", ""),
                        NOTIFY_ADD1 = ds.Tables[0].Rows[0]["NOTIFY_ADD1"].ToString().Replace("amp;", ""),
                        NOTIFY_ADD2 = ds.Tables[0].Rows[0]["NOTIFY_ADD2"].ToString().Replace("amp;", ""),
                        NOTIFY_ADD3 = ds.Tables[0].Rows[0]["NOTIFY_ADD3"].ToString().Replace("amp;", ""),
                        NOTIFY_ADD4 = ds.Tables[0].Rows[0]["NOTIFY_ADD4"].ToString().Replace("amp;", ""),
                        NOTIFY_ADD5 = ds.Tables[0].Rows[0]["NOTIFY_ADD5"].ToString(),

                        PRE_CARRIAGE_BY = ds.Tables[0].Rows[0]["PRE_CARRIAGE_BY"].ToString().Replace("amp;", ""),
                        PLACE_OF_RECEIPT = ds.Tables[0].Rows[0]["PLACE_OF_RECEIPT"].ToString().Replace("amp;", ""),
                        VESSEL_FLIGHT_NO = ds.Tables[0].Rows[0]["VESSEL_FLIGHT_NO"].ToString().Replace("amp;", ""),
                        PORT_OF_LOADING = ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString().Replace("amp;", ""),
                        PORT_OF_DISCHARGE = ds.Tables[0].Rows[0]["PORT_OF_DISCHARGE"].ToString().Replace("amp;", ""),

                        FINAL_DEST = ds.Tables[0].Rows[0]["FINAL_DEST"].ToString(),
                        MARK_NOS_CONTAINER_NO = ds.Tables[0].Rows[0]["MARK_NOS_CONTAINER_NO"].ToString(),
                        NO_KIND_OF_PACKAGES = ds.Tables[0].Rows[0]["NO_KIND_OF_PACKAGES"].ToString(),
                        DESCRIPTION_GOODS = ds.Tables[0].Rows[0]["DESCRIPTION_GOODS"].ToString(),
                        ORIGIN_CRITERIA = ds.Tables[0].Rows[0]["ORIGIN_CRITERIA"].ToString(),
                        GROSS_WEIGHT =GROSS_WEIGHT,
                        //MEASUREMENT = ds.Tables[0].Rows[0]["MEASUREMENT"].ToString(),
                        NO_DATE_OF_INVOICE = ds.Tables[0].Rows[0]["NO_DATE_OF_INVOICE"].ToString(),
                        IMPORTING_COUNTRY = ds.Tables[0].Rows[0]["IMPORTING_COUNTRY"].ToString(),

                        REMARKS = ds.Tables[0].Rows[0]["REMARKS"].ToString(),
                        AUTHORISED_SIGNATORY = ds.Tables[0].Rows[0]["AUTHORISED_SIGNATORY"].ToString(),
                        SIGNATURE_DATE = ds.Tables[0].Rows[0]["SIGNATURE_DATE"].ToString(),

                    });
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

    #region OPEN WORD DOCUMENT***********************************

    protected void btn_Word_Click(object sender, EventArgs e)
    {
        //    //CreateDocument();
        //    //test_word();
        //    open_doc();
    }

    //private void open_doc()
    //{
    //    Microsoft.Office.Interop.Word.Application msword = new Microsoft.Office.Interop.Word.Application();

    //    Create_New_Word_Document();
    //}

    //public void Create_New_Word_Document()
    //{
    //    Export_CheckList CHKLIST = new Export_CheckList();
    //    CHKLIST.JOBNo = Request.QueryString["jobno"].ToString();
    //    CHKLIST.Ename = "select_certificate_of_origin";

    //    CHKLIST.TRANSPORT_MODE = "0";
    //    CHKLIST.CUSTOM_HOUSE = "0";
    //    CHKLIST.Workingperiod = SELECT_BRANCH;
    //    ds = CHKLIST.RetrieveAll_General_Details();

    //    Microsoft.Office.Interop.Word.Application msword = new Microsoft.Office.Interop.Word.Application();
    //    Microsoft.Office.Interop.Word.Document doc1;
    //    object endofdoc = "\\endofdoc";
    //    msword.Visible = true;

    //    object objMiss = System.Reflection.Missing.Value;

    //    //doc1 = msword.Documents.Add(ref objMiss, ref objMiss, ref objMiss, ref objMiss);

    //    Document wrdDoc = msword.Documents.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    //    wrdDoc.Paragraphs.SpaceAfter = 0.1f;

    //    //wrdDoc.PageSetup.LeftMargin = 1f;

    //    Microsoft.Office.Interop.Word.Paragraph para1;
    //    Microsoft.Office.Interop.Word.Table tbl1;
    //    Microsoft.Office.Interop.Word.TextFrame tf;
    //    Microsoft.Office.Interop.Word.Shape shape;
    //    Microsoft.Office.Interop.Word.Shape shape1;
    //    Microsoft.Office.Interop.Word.Section section;
    //    Microsoft.Office.Interop.Word.TextInput txt_imput;
    //    // add paragraph with document


    //    shape = wrdDoc.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 20, 20, 300, 80);
    //    shape1 = wrdDoc.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 20, 114, 300, 80);
    //    Microsoft.Office.Interop.Word.Shape shape_PRE_CARRIAGE_BY = wrdDoc.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 20, 230, 150, 20);
    //    Microsoft.Office.Interop.Word.Shape shape_PLACE_OF_RECEIPT = wrdDoc.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 220, 230, 150, 20);
    //    Microsoft.Office.Interop.Word.Shape shape_VESSEL_FLIGHT_NO = wrdDoc.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 20, 260, 150, 20);
    //    Microsoft.Office.Interop.Word.Shape shape_PORT_OF_LOADING = wrdDoc.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 220, 260, 150, 20);
    //    Microsoft.Office.Interop.Word.Shape shape_PORT_DISCHARGE = wrdDoc.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 20, 290, 150, 20);
    //    Microsoft.Office.Interop.Word.Shape shape_FINAL_DEST = wrdDoc.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 220, 290, 150, 20);

    //    Microsoft.Office.Interop.Word.Shape shape_MARKS_NOS = wrdDoc.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 20, 340, 160, 195);
    //    Microsoft.Office.Interop.Word.Shape shape_NO_OF_PKGS = wrdDoc.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 182, 340, 220, 170);
    //    Microsoft.Office.Interop.Word.Shape shape_DESC_GOODS = wrdDoc.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 182, 370, 220, 170);
    //    Microsoft.Office.Interop.Word.Shape shape_GROSS_WEIGHT = wrdDoc.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 404, 340, 100, 150);
    //    //Microsoft.Office.Interop.Word.Shape shape_ORIGIN_CRITERIA = wrdDoc.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 290, 340, 150, 20);
    //    Microsoft.Office.Interop.Word.Shape shape_NO_OF_INVOICE = wrdDoc.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 506, 340, 100, 150);


    //    //shape1 = wrdDoc.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 20, 20, 200, 80); //left,top,width,height;
    //    wrdDoc.ActiveWindow.Caption = "Certificate Of Orgin" + " - " + ds.Tables[0].Rows[0]["JOBNO"].ToString();

    //    //shape1 = wrdDoc.Shapes.AddTextEffect(Microsoft.Office.Core.MsoPresetTextEffect.msoTextEffect8, ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString(), "Arial", (float)60, MsoTriState.msoTrue, MsoTriState.msoFalse, 0, 0, ref objMiss);
    //    Document document = new Document();

    //    shape1.Line.Style = Microsoft.Office.Core.MsoLineStyle.msoLineThickBetweenThin;

    //    //shape1.TextFrame.TextRange.Paragraphs.LineSpacing = 8f;
    //    shape1.TextFrame.TextRange.Paragraphs.SpaceAfter = 0.2F;
    //    //shape1.TextFrame.TextRange.Borders.OutsideColor = Microsoft.Office.Interop.Word.Border.Equals
    //    //shape1.TextFrame.TextRange.Borders.OutsideColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdRed;
    //    //shape1.TextFrame.TextRange.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDashDot;//Outline Dotted Lines
    //    //shape1.TextFrame.TextRange.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;//INline Dotted Lines
    //    //shape1.TextFrame.TextRange.Borders.Enable = 0;

    //   // shape1.TextFrame.TextRange.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorDarkRed;//Font Color Set

    //    //shape1.Anchor.Borders.Enable = 0;

    //    //shape1.TextFrame.TextRange.Borders.c = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;
    //    //shape1.Line.BackColor.RGB = 5454;

    //    object Borderstyle = "None";
    //    //shape1.TextFrame.TextRange.set_Style(System.Windows.Forms.BorderStyle.None);

    //    Microsoft.Office.Interop.Word.Table ttbl;

    //    shape1.TextFrame.TextRange.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString() + " " + ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString();

    //    shape1.Line.Visible = MsoTriState.msoFalse;

    //    Microsoft.Office.Interop.Word.Shape logowatermark = null;

    //    //Microsoft.Office.Interop.Word.Paragraph para11 = doc1.Content.Paragraphs.Add(ref missing);
    //    Microsoft.Office.Interop.Word.Paragraph para11 = wrdDoc.Content.Paragraphs.Add(ref objMiss);

    //    //*************** Shape Start*************************
    //    shape.TextFrame.TextRange.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["ADDRESS1"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["ADDRESS2"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["ADDRESS3"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
    //    shape.TextFrame.TextRange.Paragraphs.SpaceAfter = 0.2F;
    //    shape.Line.Visible = MsoTriState.msoFalse;
    //    //*************** Shape End *************************

    //    //*************** Shape PORT_DISCHARGE*************************
    //    shape_PRE_CARRIAGE_BY.TextFrame.TextRange.Text = ds.Tables[0].Rows[0]["PRE_CARRIAGE_BY"].ToString();
    //    shape_PLACE_OF_RECEIPT.TextFrame.TextRange.Text = ds.Tables[0].Rows[0]["PLACE_OF_RECEIPT"].ToString();
    //    shape_VESSEL_FLIGHT_NO.TextFrame.TextRange.Text = ds.Tables[0].Rows[0]["VESSEL_FLIGHT_NO"].ToString();
    //    shape_PORT_OF_LOADING.TextFrame.TextRange.Text = ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString();
    //    shape_PORT_DISCHARGE.TextFrame.TextRange.Text = ds.Tables[0].Rows[0]["PORT_OF_DISCHARGE"].ToString();
    //    shape_FINAL_DEST.TextFrame.TextRange.Text = ds.Tables[0].Rows[0]["FINAL_DEST"].ToString();

    //    shape_MARKS_NOS.TextFrame.TextRange.Text = ds.Tables[0].Rows[0]["MARK_NOS_CONTAINER_NO"].ToString();
    //    shape_NO_OF_PKGS.TextFrame.TextRange.Text = ds.Tables[0].Rows[0]["NO_KIND_OF_PACKAGES"].ToString();
    //    shape_DESC_GOODS.TextFrame.TextRange.Text = ds.Tables[0].Rows[0]["DESCRIPTION_GOODS"].ToString();
    //    shape_NO_OF_INVOICE.TextFrame.TextRange.Text = ds.Tables[0].Rows[0]["NO_DATE_OF_INVOICE"].ToString();
    //    shape_GROSS_WEIGHT.TextFrame.TextRange.Text = ds.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString();

    //    shape_PRE_CARRIAGE_BY.Line.Visible = MsoTriState.msoFalse;
    //    shape_PLACE_OF_RECEIPT.Line.Visible = MsoTriState.msoFalse;
    //    shape_VESSEL_FLIGHT_NO.Line.Visible = MsoTriState.msoFalse;
    //    shape_PORT_OF_LOADING.Line.Visible = MsoTriState.msoFalse;
    //    shape_PORT_DISCHARGE.Line.Visible = MsoTriState.msoFalse;
    //    shape_FINAL_DEST.Line.Visible = MsoTriState.msoFalse;
    //    shape_MARKS_NOS.Line.Visible = MsoTriState.msoFalse;
    //    shape_NO_OF_PKGS.Line.Visible = MsoTriState.msoFalse;
    //    shape_DESC_GOODS.Line.Visible = MsoTriState.msoFalse;
    //    shape_NO_OF_INVOICE.Line.Visible = MsoTriState.msoFalse;
    //    shape_GROSS_WEIGHT.Line.Visible = MsoTriState.msoFalse;

    //    //*************** Shape PORT_DISCHARGE End *************************

    //    //     logowatermark = wrdDoc.Selection.HeaderFooter.Shapes.AddTextEffect(

    //    //para1.Range.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString()+Environment.NewLine+ds.Tables[0].Rows[0]["ADDRESS1"].ToString().Replace("amp;", "")+Environment.NewLine+ds.Tables[0].Rows[0]["ADDRESS2"].ToString().Replace("amp;", "")+Environment.NewLine+ds.Tables[0].Rows[0]["ADDRESS3"].ToString().Replace("amp;", "")+Environment.NewLine+ds.Tables[0].Rows[0]["ADDRESS4"].ToString().Replace("amp;", "");

    //    ////set font style of paragraph

    //    //para1.Range.Font.Bold = 1;

    //    ////tbl1 = doc1.Tables.Add(para1.Range, 1, 1, ref objMiss, ref objMiss);

    //    //// set space after write format of paragraph

    //    //para1.Format.SpaceAfter=1;

    //    // selection range of after insert paragraph

    //    //para1.Range.InsertParagraphAfter();

    //    //object missing = System.Reflection.Missing.Value;

    //    //Create a new document
    //    //Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);


    //    //foreach (Microsoft.Office.Interop.Word.Section section in doc1.Sections)
    //    //{
    //    //    //Get the header range and add the header details.
    //    //    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
    //    //    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
    //    //    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
    //    //    headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
    //    //    headerRange.Font.Size = 10;
    //    //    headerRange.Text = "Header text goes here";
    //    //}

    //    //Add the footers into the document
    //    //foreach (Microsoft.Office.Interop.Word.Section wordSection in doc1.Sections)
    //    //{
    //    //    //Get the footer range and add the footer details.
    //    //    Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
    //    //    footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkRed;
    //    //    footerRange.Font.Size = 10;
    //    //    footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
    //    //    footerRange.Text = "Footer text goes here";
    //    //}

    //}
  

    #endregion OPEN WORD DOCUMENT***********************************

}