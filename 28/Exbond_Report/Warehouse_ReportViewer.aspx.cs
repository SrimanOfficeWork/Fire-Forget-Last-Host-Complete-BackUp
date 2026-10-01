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
using AjaxControlToolkit;



public partial class Transaction_Default2 : System.Web.UI.Page
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

    WareHouseReportDetails wh = new WareHouseReportDetails();
    public string ccc; string i, j, k, l, m, n, itemqty,kkk,jjj;
    int kk, jj;


    private string _Workingperiod, _INVOICE_ID, _REMAINING_QTY;
    public string INVOICE_ID { get { return _INVOICE_ID; } set { _INVOICE_ID = value; } }
    public string REMAINING_QTY { get { return _REMAINING_QTY; } set { _REMAINING_QTY = value; } }

   
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
   

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
    public string SELECT_TYPE, SELECT_BRANCH;

    CheckList CHKLIST = new CheckList();
    //Customer c = new Customer();
    Date_Time dt = new Date_Time();
    
    DataTable dtt = new DataTable();

    //List<INVOICE_DETAILS> Load_Invoice_Details = new List<INVOICE_DETAILS>();
    //List<Transaction_Default2> Load_Item_Details = new List<Transaction_Default2>();

    List<WareHouseReportDetails> Load_WareHouse_Inv_ItemDetails = new List<WareHouseReportDetails>();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentbranch = Session["currentbranch"].ToString();

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
                ddlJobNo = Request.QueryString["jobno"].ToString();
                Session["JobNo"] = ddlJobNo;
                currentuser = Session["currentuser"].ToString();
                //currentbranch = Session["currentbranch"].ToString();
                currentcomp_name = Session["currentcomp_name"].ToString();
                comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
                working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
                LoginDate = HttpContext.Current.Session["LoginDate"].ToString();

                List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                WareHouseReportDetails wh = new WareHouseReportDetails();
                wh.JOBNO = Request.QueryString["jobno"].ToString();
                wh.Ename = "Exbond_Report_BE_IMPORTER";

                wh.Working_Period = Connection.Get_Company_Type();
                DataSet ds = new DataSet();
                ds = wh.RetrieveAll_WareHouse_Details();

                //ds = (DataSet)HttpContext.Current.Session["IMPORT_CHECKLIST"];
                //GetGeneral();

                Load_WareHouse_Generall(ds.Tables[0]);
                Load_WareHouse_INV_ItemDetails(ds.Tables[1]);
                Load_WareHouse_INV_ItemDetailsAll(ds.Tables[2]);

                ReportParameter param = new ReportParameter("Title", Session["currentcomp_name"].ToString());

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

    public void Load_WareHouse_Generall(DataTable dt1)
    {
        ReportDataSource data_S = new ReportDataSource("Warehouse_General_DataSet", wh.Load_WareHouse_General(dt1));
        ReportViewer1.LocalReport.DataSources.Add(data_S);
    }

    public void Load_WareHouse_INV_ItemDetails(DataTable dt2)
    {
        ReportDataSource data_S = new ReportDataSource("Exbond_DataSet", wh.Load_WareHouse_Inv_ItemDetails(dt2));
        ReportViewer1.LocalReport.DataSources.Add(data_S);
    }

    public void Load_WareHouse_INV_ItemDetailsAll(DataTable dt3)
    {
        ReportDataSource data_S = new ReportDataSource("Warehouse_Items_DataSet", wh.Load_WareHouse_Inv_Item_ALLDetails(dt3));
        ReportViewer1.LocalReport.DataSources.Add(data_S);
    }

}




