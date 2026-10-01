using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.ComponentModel;
using System.Drawing.Printing;
//using System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
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
using AjaxControlToolkit;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;


public partial class Export_GSP_Front_Rpt_viewer : System.Web.UI.Page
{
    

    #region Private_Attributes
    private string _BE_NO;
    private string _BE_NO_DATE;
    private string _JOB_NO;
    private string _Today_dt;
   
    private string _Importer_Name;

    private string _TRANSPORT_MODE;
   
    private string _CUSTOMS_HOUSE;
    
  
    //private string _INVOICE_SLNO;
    private string _INVOICE_NO;
   

    #endregion
    #region Public_Attributes
  
    public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }
    public string BE_NO_DATE { get { return _BE_NO_DATE; } set { _BE_NO_DATE = value; } }
    public string JOB_NO { get { return _BE_NO; } set { _JOB_NO = value; } }
    public string Today_dt { get { return _BE_NO; } set { _Today_dt = value; } }
    public string Importer_Name { get { return _Importer_Name; } set { _Importer_Name = value; } }
    
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
         
    #endregion
    //---------------------ITEM ATTRIBUTES-----------------//
    #region ITEM ATTRIBUTES
    #region Private_Attributes
    private string _INVOICE_SLNO;
    private string _INVOICE_DATE;
    private string  _INVOICE_NO_ITEM, _Invoice_No, _Invoice_Details;

    private string _INVOICE_VALUE, _Invoice_value, _INVOICE_EXRATE;
   
    //item Details
    
    private string _ITEM_SLNO;
    private string _ITEM_DESCRIPTION;
    private string _ITEM_QTY;
    private string _ITEM_QTY_CODE;
    private string _ITEM_UNIT_PRICE;
    private string  _Total_Invoice, _SupplierCountry_Name_Pincode;
   
    #endregion
    #region Public_Attributes
    
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_NO_ITEM { get { return _INVOICE_NO_ITEM; } set { _INVOICE_NO_ITEM = value; } }
    public string Invoice_No { get { return _Invoice_No; } set { _Invoice_No = value; } }
    public string Invoice_Details { get { return _Invoice_Details; } set { _Invoice_Details = value; } }

    public string INVOICE_VALUE { get { return _INVOICE_VALUE; } set { _INVOICE_VALUE = value; } }
    public string Invoice_value { get { return _Invoice_value; } set { _Invoice_value = value; } }


    //ITEM DETAILS

    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string ITEM_DESCRIPTION { get { return _ITEM_DESCRIPTION; } set { _ITEM_DESCRIPTION = value; } }
    public string ITEM_QTY { get { return _ITEM_QTY; } set { _ITEM_QTY = value; } }
    public string ITEM_QTY_CODE { get { return _ITEM_QTY_CODE; } set { _ITEM_QTY_CODE = value; } }
    public string ITEM_UNIT_PRICE { get { return _ITEM_UNIT_PRICE; } set { _ITEM_UNIT_PRICE = value; } }
   
  
  
    #endregion
#endregion
    public string working_period;

    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();
    NForm Nform = new NForm();
    GSP_Details GSP = new GSP_Details();
    EXP_BL_Generation BL_GEN = new EXP_BL_Generation();

    WareHouseReportDetails wh = new WareHouseReportDetails();
    public string ccc; string i, j, k, l, m, n, itemqty,kkk,jjj;
    int kk, jj;
    public string Exporter_nname, ConsignName, Means_Transport, Exporter_For, port_Discharge, Vesselname, Entered_By, Depature_Date;

    private string _Workingperiod, _INVOICE_ID, _REMAINING_QTY;
    public string INVOICE_ID { get { return _INVOICE_ID; } set { _INVOICE_ID = value; } }
    public string REMAINING_QTY { get { return _REMAINING_QTY; } set { _REMAINING_QTY = value; } }
   
    DataSet ds = new DataSet();
    DataSet dss = new DataSet();
   
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
    public string LoginDate,testaddress;
    public string SELECT_TYPE, SELECT_BRANCH,Print_type,Page_Name,COMPANY_IDD;
    public string SPEC4, SPEC5;

    Export_CheckList CHKLIST = new Export_CheckList();
    //Customer c = new Customer();
    Date_Time dt = new Date_Time();
    
    DataTable dtt = new DataTable();

    List<Export_GSP_Front_Rpt_viewer> Load_WareHouse_Inv_ItemDetails = new List<Export_GSP_Front_Rpt_viewer>();

    //List<NForm> NForm = new List<NForm>();
    List<NForm> Load_NForm_Details = new List<NForm>();

   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
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
                ddlJobNo = Request.QueryString["jobno"].ToString();
                Session["JobNo"] = ddlJobNo;

                Print_type = Request.QueryString["type"].ToString();

                if (Print_type == "SecondPage")
                {
                    Page_Name = Request.QueryString["Page_Name"].ToString();
                }

                //if (Print_type == "1")
                //{
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_AIFTA_Report.rdlc");
                //}

                if (Print_type == "1")
                {

                    if (COMPANY_IDD == "525")
                    {

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_AIFTA_FREIGHTLOG_Report.rdlc");

                    }

                    else
                    {

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_AIFTA_Report.rdlc");

                    }

                }

                //if (Print_type == "2")
                //{
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_IAJ_Report.rdlc");
                //}


                if (Print_type == "2")
                {

                     if (COMPANY_IDD == "525")
                     {

                     ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_IAJ_FREIGHTLOG_Report.rdlc");

                     }

                     else

                     {

                         ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_IAJ_Report.rdlc");

                     }

                }

                //if (Print_type == "3")
                //{
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_GSP_Report.rdlc");
                //}

                if (Print_type == "3")
                {

                    
                     if (COMPANY_IDD == "525")
                     {

                     ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_GSP_FREIGHTLOG_Report.rdlc");
                     }

                     else

                     {
                         ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_GSP_Report.rdlc");

                     }

                }

                if (Print_type == "4")
                {
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_SAARC_Report.rdlc");
                }

                if (Print_type == "5")
                {
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_GLOBAL_Report.rdlc");
                }

                if (Print_type == "6")
                {
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_IMCECA_Report.rdlc");
                }

                if (Print_type == "7")
                {
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_APTA_Report.rdlc");
                }

                if (Print_type == "8")
                {
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_ISFTA_Report.rdlc");
                }

                if (Print_type == "9")
                {
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_RCCI_Report.rdlc");
                }

               

                //if (Print_type == "SecondPage" && Page_Name == "3")
                //{
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_GSP_SecondPage_Report.rdlc");
                //}

                

                if (Print_type == "SecondPage" && Page_Name == "3")
                {

                    if (COMPANY_IDD == "525")
                    {

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_GSP_FREIGHTLOG_SecondPage_Report.rdlc");
                    }

                    else
                    {

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_GSP_SecondPage_Report.rdlc");
                    }
                }


                if (Print_type == "SecondPage" && Page_Name == "4")
                {
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_SAARC_SecondPage_Report.rdlc");
                }


                if (Print_type == "SecondPage" && Page_Name == "5")
                {
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_GLOBAL_SecondPage_Report.rdlc");
                }


                if (Print_type == "SecondPage" && Page_Name == "6")
                {
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_IMCECA_SecondPage_Report.rdlc");
                }


                if (Print_type == "SecondPage" && Page_Name == "7")
                {
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_APTA_SecondPage_Report.rdlc");
                }

                if (Print_type == "SecondPage" && Page_Name == "8")
                {
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_ISFTA_SecondPage_Report.rdlc");
                }

                if (Print_type == "SecondPage" && Page_Name == "9")
                {
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_ISFTA_SecondPage_Report.rdlc");
                }

                //if (Print_type == "SecondPage" && Page_Name == "1")
                //{
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_AIFTA_SecondPage_Report.rdlc");
                //}



                if (Print_type == "SecondPage" && Page_Name == "1")
                {

                    if (COMPANY_IDD == "525")
                    {

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_AIFTA_FREIGHTLOG_SecondPage_Report.rdlc");
                    }

                    else
                    {

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_AIFTA_SecondPage_Report.rdlc");

                    }

                }


                //if (Print_type == "SecondPage" && Page_Name == "2")
                //{
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_IAJ_SecondPage_Report.rdlc");
                //}

                if (Print_type == "SecondPage" && Page_Name == "2")

                {

                    if (COMPANY_IDD == "525")
                    {

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_IAJ_FREIGHTLOG_SecondPage_Report.rdlc");
                    }

                    else
                    {
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Export_GSP_Front_Details_IAJ_SecondPage_Report.rdlc");
                    }
                }

                ReportViewer1.LocalReport.DataSources.Clear();
              
                List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);

                ReportViewer1.LocalReport.DataSources.Clear();

                CHKLIST.JOBNo = ddlJobNo;
                CHKLIST.Ename = "GSP_Front_details_Report";

                CHKLIST.Workingperiod = SELECT_BRANCH;

                ds.Clear();
                ds = CHKLIST.RetrieveAll_General_Details();
            
                HttpContext.Current.Session["IMPORT_CHECKLIST"] = ds;

                //Load_GSP_Front_Details();

                //if (Print_type == "3")
                //{
                    Item_Details();
                //}

                Exporter_For = ds.Tables[0].Rows[0]["EXPORTER_NAME_NAME"].ToString();
                Exporter_nname = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                ConsignName = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                Means_Transport = ds.Tables[0].Rows[0]["TRANSPORT_ROUTE"].ToString();
                port_Discharge = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
                Vesselname = ds.Tables[0].Rows[0]["VESSEL_AIRCRAFT_NAME"].ToString();
                Entered_By = ds.Tables[0].Rows[0]["ENTERED_BY"].ToString();
                Depature_Date = ds.Tables[0].Rows[0]["DEPATURE_DATE"].ToString();

                SPEC4 = ds.Tables[0].Rows[0]["SPE4"].ToString();
                SPEC5 = ds.Tables[0].Rows[0]["SPE5"].ToString();


                ReportDataSource dataSS = new ReportDataSource("Export_GSP_Front_DataSet1", ds.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(dataSS);

                ReportParameter param = new ReportParameter("Title", Session["currentcomp_name"].ToString());

                //string ppp = Session["currentcomp_name"].ToString();

                ReportParameter country_name1 = new ReportParameter("country_name", ds.Tables[0].Rows[0]["EXPORTER_COUNTRY"].ToString());
                ReportParameter Exporter_For1 = new ReportParameter("Exporter_For", Exporter_For);
                ReportParameter Exporter_Name1 = new ReportParameter("Exporter_nname", Exporter_nname);
                ReportParameter ConsignName1 = new ReportParameter("ConsignName", ConsignName);
                ReportParameter Means_Transport1 = new ReportParameter("Means_Transport", Means_Transport);
                ReportParameter port_Discharge1 = new ReportParameter("port_Discharge", port_Discharge);
                ReportParameter Vesselname1 = new ReportParameter("Vesselname", Vesselname);
                ReportParameter EnterdBY = new ReportParameter("Entered_By", Entered_By);
                ReportParameter DepatureDate = new ReportParameter("Depature_Date", Depature_Date);


                ReportParameter Imp_country_name1 = new ReportParameter("Imp_country_name", ds.Tables[0].Rows[0]["IMPORTER_COUNTRY"].ToString());
                ReportParameter Place_Date1 = new ReportParameter("Place_Date", ds.Tables[0].Rows[0]["PLACE_DATE"].ToString());
                //ReportParameter param33 = new ReportParameter("add4", ds.Tables[1].Rows[0]["ADDRESS3"].ToString());

                //if (Print_type == "1" || Print_type == "2" || Print_type == "3" || Print_type == "4")
                if (Print_type == "3")
                {
                    ReportParameter[] p = { param, country_name1, Imp_country_name1, Place_Date1, Exporter_Name1, ConsignName1, Means_Transport1, Exporter_For1 };
                    ReportViewer1.LocalReport.SetParameters(p);
                }

                if (Print_type == "4")
                {
                    ReportParameter[] p = { param, country_name1, Imp_country_name1, Place_Date1, Exporter_Name1, ConsignName1, Means_Transport1, Exporter_For1 };
                    ReportViewer1.LocalReport.SetParameters(p);
                }

                if (Print_type == "5")
                {
                    ReportParameter[] p = { param, country_name1, Imp_country_name1, Place_Date1, Exporter_Name1, ConsignName1, Means_Transport1, Exporter_For1 };
                    ReportViewer1.LocalReport.SetParameters(p);
                }
                if (Print_type == "6")
                {

                    ReportParameter[] p = { Exporter_Name1, ConsignName1, Imp_country_name1, Place_Date1, port_Discharge1, Vesselname1, Means_Transport1, DepatureDate };
                    ReportViewer1.LocalReport.SetParameters(p);
                }

                if (Print_type == "7")
                {
                    ReportParameter[] p = { param, country_name1, Imp_country_name1, Place_Date1, Exporter_Name1, ConsignName1, Means_Transport1, Exporter_For1 };
                    ReportViewer1.LocalReport.SetParameters(p);
                }

                if (Print_type == "8")
                {
                    ReportParameter[] p = { param, country_name1, Imp_country_name1, Place_Date1, Exporter_Name1, ConsignName1, Means_Transport1, Exporter_For1 };
                    ReportViewer1.LocalReport.SetParameters(p);
                }

                if (Print_type == "9")
                {
                    ReportParameter[] p = { param, country_name1, Imp_country_name1, Place_Date1, Exporter_Name1, ConsignName1, Means_Transport1, Exporter_For1 };
                    ReportViewer1.LocalReport.SetParameters(p);
                }

                //if (Print_type == "5")
                //{
                //    ReportParameter[] p = { param, country_name1, Imp_country_name1, Place_Date1, Exporter_Name1, ConsignName1, Means_Transport1, Exporter_For1 };
                //    ReportViewer1.LocalReport.SetParameters(p);
                //}

                if (Print_type == "1" )
                {

                    ReportParameter[] p = { Exporter_Name1, ConsignName1, Imp_country_name1, Place_Date1, port_Discharge1, Vesselname1, Means_Transport1, DepatureDate };
                    ReportViewer1.LocalReport.SetParameters(p);
                }
                if (Print_type == "2")
                {
                    ReportParameter[] p = { Exporter_For1, Exporter_Name1, ConsignName1, Place_Date1, Means_Transport1, EnterdBY };
                    ReportViewer1.LocalReport.SetParameters(p);
                }
                if ((Print_type == "SecondPage" && Page_Name == "2") || (Print_type == "SecondPage" && Page_Name == "1") || (Print_type == "SecondPage" && Page_Name == "3"))
                {
                    if (Print_type == "SecondPage" && Page_Name == "3")
                    {
                        ReportParameter SPE4 = new ReportParameter("SPEC4", SPEC4 + "," + SPEC5);
                        //ReportParameter SPE5 = new ReportParameter("SPEC5", SPEC5);

                        ReportParameter[] p1 = { SPE4 };
                        ReportViewer1.LocalReport.SetParameters(p1);
                    }
                    else
                    {
                        ReportParameter SPE4 = new ReportParameter("SPEC4", SPEC4);
                        ReportParameter SPE5 = new ReportParameter("SPEC5", SPEC5);
                    
                        ReportParameter[] p1 = {  SPE4, SPE5 };
                        ReportViewer1.LocalReport.SetParameters(p1);
                    }
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

    //public void Load_GSP_Front_Details()
    //{
    //    ReportDataSource dataSS = new ReportDataSource("Export_GSP_Front_DataSet1", GSP.Load_GSP_Details(ds.Tables[0]));
    //    ReportViewer1.LocalReport.DataSources.Add(dataSS);
    //}

    public void Item_Details()
    {
        //BL_GEN.JOBNO = ddlJobNo;
        //BL_GEN.BRANCHCODE = SELECT_BRANCH;
        //BL_GEN.REPORT_TYPE = "";
        //BL_GEN.Ename = "Annexure_Split_GoodsDesc_Marks";
        //dss = BL_GEN.BL_Container_Select_All();

        GSP.JOBNO = Request.QueryString["jobno"].ToString();
        GSP.BRANCH_CODE = SELECT_BRANCH;
        GSP.WORKING_PERIOD = working_period;
        GSP.Ename = "Annexure_Split_GoodsDesc_Marks";

        dss = GSP.RetrieveAll_GSP_Details();                    

        ReportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(ReportViewer1_SubreportProcessing);
    }

    protected void ReportViewer1_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        //ReportDataSource dataSource = new ReportDataSource("GSP_FRONT_DETAILS_SUB_DataSet", dss.Tables[0]);
        //e.DataSources.Add(dataSource);

        ReportDataSource dataSource = new ReportDataSource("EXPORT_GSP_RPT_DataSet1", dss.Tables[0]);
        e.DataSources.Add(dataSource);

    }
}




