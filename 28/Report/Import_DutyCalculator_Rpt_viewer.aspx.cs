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




public partial class Import_DutyCalculator : System.Web.UI.Page
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

    public string _invoices, str_InvoiceValueINR1, str_txtFreight1, str_txtInsurance1, str_txtMISC1, str_txtLandingCharges1, str_txtAssesableValue1;
    public string str_txtBasicDutyPercentage1, str_txtCVDDutyPercentage1, str_txtCessPercentage1, str_txtCustoms_CessPercentage1, str_txtAdditional_DutyPercentage1;
    public string str_txtBasicDuty1, str_txtCVDDuty1, str_txtCess1, str_txtCustoms_Cess1, str_txtAdditional_Duty1, str_txtTotal_Duty1;
    public string invoices { get { return _invoices; } set { _invoices = value; } }


   
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
   

   

    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate,testaddress;
    public string SELECT_TYPE, SELECT_BRANCH;
    
    CheckList CHKLIST = new CheckList();
    //Customer c = new Customer();
    Date_Time dt = new Date_Time();
    
    DataTable dtt = new DataTable();


    List<Import_DutyCalculator> Import_DutyCalculator1 = new List<Import_DutyCalculator>();

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
        invoices = HttpContext.Current.Session["str_txtInvoiceValFC"].ToString();
        str_InvoiceValueINR1 = HttpContext.Current.Session["str_InvoiceValueINR"].ToString();
        str_txtFreight1 = HttpContext.Current.Session["str_txtFreight"].ToString();
        str_txtInsurance1 = HttpContext.Current.Session["str_txtInsurance"].ToString();
        str_txtMISC1 = HttpContext.Current.Session["str_txtMISC"].ToString();
        str_txtLandingCharges1 = HttpContext.Current.Session["str_txtLandingCharges"].ToString();
        str_txtAssesableValue1 = HttpContext.Current.Session["str_txtAssesableValue"].ToString();
        str_txtBasicDuty1 = HttpContext.Current.Session["str_txtBasicDuty"].ToString();
        str_txtBasicDutyPercentage1 = HttpContext.Current.Session["str_txtBasicDutyPercentage"].ToString();
        str_txtCVDDuty1 = HttpContext.Current.Session["str_txtCVDDuty"].ToString();
        str_txtCVDDutyPercentage1 = HttpContext.Current.Session["str_txtCVDDutyPercentage"].ToString();

         str_txtCess1 = HttpContext.Current.Session["str_txtCess"].ToString();
         str_txtCessPercentage1 = HttpContext.Current.Session["str_txtCessPercentage"].ToString();

         str_txtCustoms_Cess1 = HttpContext.Current.Session["str_txtCustoms_Cess"].ToString();
         str_txtCustoms_CessPercentage1 = HttpContext.Current.Session["str_txtCustoms_CessPercentage"].ToString();

         str_txtAdditional_Duty1 = HttpContext.Current.Session["str_txtAdditional_Duty"].ToString();
         str_txtAdditional_DutyPercentage1 = HttpContext.Current.Session["str_txtAdditional_DutyPercentage"].ToString();

         str_txtTotal_Duty1 = HttpContext.Current.Session["str_txtTotal_Duty"].ToString();

        //invoices = HttpContext.Current.Session["test"].ToString();

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
                List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);

                ReportViewer1.LocalReport.DataSources.Clear();

                //string invoiceFC = invoices;

                string query = Request.QueryString["txtInvoiceValFC"];

                string invoiceFC = invoices;

                ReportParameter param = new ReportParameter("Title", Session["currentcomp_name"].ToString());

                ReportParameter invoiceFC1 = new ReportParameter("InvoiceFc", invoiceFC);
                ReportParameter str_InvoiceValueINR = new ReportParameter("Invoice_INR", str_InvoiceValueINR1);
                ReportParameter str_txtFreight = new ReportParameter("Freight_INR", str_txtFreight1);
                ReportParameter str_txtInsurance = new ReportParameter("Insurance_INR", str_txtInsurance1);
                ReportParameter str_txtMISC = new ReportParameter("MISC_INR", str_txtMISC1);
                ReportParameter str_txtLandingCharges = new ReportParameter("Landing_Charges", str_txtLandingCharges1);
                ReportParameter str_txtAssesableValue = new ReportParameter("Assebl_Value", str_txtAssesableValue1);
                ReportParameter str_txtBasicDuty = new ReportParameter("Basic_Duty", str_txtBasicDuty1);
                ReportParameter str_txtBasicDutyPercentage = new ReportParameter("str_txtBasicDutyPercentage1", str_txtBasicDutyPercentage1);
                ReportParameter str_txtCVDDuty = new ReportParameter("CVD_Duty", str_txtCVDDuty1);
                ReportParameter str_txtCVDDutyPercentage = new ReportParameter("str_txtCVDDutyPercentage", str_txtCVDDutyPercentage1);
                ReportParameter str_txtCess = new ReportParameter("Cess_Value", str_txtCess1);
                ReportParameter str_txtCessPercentage = new ReportParameter("str_txtCessPercentage", str_txtCessPercentage1);
                ReportParameter str_txtCustoms_Cess = new ReportParameter("Custom_Cess", str_txtCustoms_Cess1);
                ReportParameter str_txtCustoms_CessPercentage = new ReportParameter("str_txtCustoms_CessPercentage", str_txtCustoms_CessPercentage1);

                ReportParameter str_txtAdditional_Duty = new ReportParameter("Additional_Duty", str_txtAdditional_Duty1);
                ReportParameter str_txtAdditional_DutyPercentage = new ReportParameter("str_txtAdditional_DutyPercentage", str_txtAdditional_DutyPercentage1);

                ReportParameter str_txtTotal_Duty = new ReportParameter("Total_Duty", str_txtTotal_Duty1);

                ReportParameter[] p = { invoiceFC1, str_InvoiceValueINR, str_txtFreight, str_txtInsurance, str_txtMISC, str_txtLandingCharges
                                          , str_txtAssesableValue,str_txtBasicDuty,str_txtCVDDuty,str_txtCess,str_txtCustoms_Cess,str_txtAdditional_Duty,
                                          str_txtBasicDutyPercentage ,str_txtTotal_Duty,str_txtCVDDutyPercentage,str_txtCessPercentage
                                          ,str_txtCustoms_CessPercentage,str_txtAdditional_DutyPercentage};

                ReportViewer1.LocalReport.SetParameters(p);


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
       
      
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }


}




