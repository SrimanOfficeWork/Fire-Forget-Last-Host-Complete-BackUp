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




public partial class Import_Customs_Declaration_Rpt_viewer : System.Web.UI.Page
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


    List<Import_Customs_Declaration_Rpt_viewer> Import_DutyCalculator1 = new List<Import_Customs_Declaration_Rpt_viewer>();

    //List<NForm> NForm = new List<NForm>();
    List<NForm> Load_NForm_Details = new List<NForm>();

    IMP_Dec_I_II customs = new IMP_Dec_I_II();

   
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
            //Page_loaItem_Details();
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
            if (ddlJob_No.SelectedItem.Text != "Select")
            {
                customs.Jobno = ddlJob_No.SelectedItem.Text;
                customs.BRANCHCODE = currentbranch;
                customs.BRANCH_COMMON = SELECT_BRANCH;
                customs.Type = "Customs_Declaration";

                ds = customs.Get_CustomsDeclarationIII();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);
                    ReportViewer1.LocalReport.DataSources.Clear();

                    string IGM_FLIGHT_VESSELDATE = ds.Tables[0].Rows[0]["IGM_FLIGHT_VESSELDATE"].ToString();
                    string IGM_FLIGHTNO_VESSELNO = ds.Tables[0].Rows[0]["IGM_FLIGHTNO_VESSELNO"].ToString();
                    string IGM_NO = ds.Tables[0].Rows[0]["IGM_NO"].ToString();
                    string IGM_DATE = ds.Tables[0].Rows[0]["IGM_DATE"].ToString();
                    string IGM_MAWB_MBL = ds.Tables[0].Rows[0]["IGM_MAWB_MBL"].ToString();
                    string INVOICE_NO = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                    string ASSESSABLE_VALUE = ds.Tables[0].Rows[0]["ASSESSABLE_VALUE"].ToString();
                    string DUTY_VALUE = ds.Tables[0].Rows[0]["DUTY_VALUE"].ToString();
                    string IGM_NOOFPACKAGE = ds.Tables[0].Rows[0]["IGM_NOOFPACKAGE"].ToString();
                    string IGM_NETWEIGHT = ds.Tables[0].Rows[0]["IGM_GROSSWEIGHT"].ToString();
                    string ITEM_DESCRIPTION = ds.Tables[0].Rows[0]["ITEM_DESCRIPTION"].ToString();
                    

                    ReportParameter p1 = new ReportParameter("IGM_FLIGHTNO_VESSELNO", IGM_FLIGHTNO_VESSELNO);
                    ReportParameter p2 = new ReportParameter("IGM_FLIGHT_VESSELDATE", IGM_FLIGHT_VESSELDATE);
                    ReportParameter p3 = new ReportParameter("IGM_NO", IGM_NO);
                    ReportParameter p4 = new ReportParameter("IGM_DATE", IGM_DATE);
                    ReportParameter p5 = new ReportParameter("IGM_MAWB_MBL", IGM_MAWB_MBL);
                    ReportParameter p6 = new ReportParameter("INVOICE_NO", INVOICE_NO);
                    ReportParameter p7 = new ReportParameter("ASSESSABLE_VALUE", ASSESSABLE_VALUE);
                    ReportParameter p8 = new ReportParameter("DUTY_VALUE", DUTY_VALUE);
                    ReportParameter p9 = new ReportParameter("IGM_NOOFPACKAGE", IGM_NOOFPACKAGE);
                    ReportParameter p10 = new ReportParameter("IGM_NETWEIGHT", IGM_NETWEIGHT);
                    ReportParameter p11 = new ReportParameter("ITEM_DESCRIPTION", ITEM_DESCRIPTION);
                    ReportParameter CHA_NO = new ReportParameter("CHA_NO", HttpContext.Current.Session["CHA_NO"].ToString());

                    ReportParameter[] p = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, CHA_NO };
                    ReportViewer1.LocalReport.SetParameters(p);

                  //  --------------------------------------To Print------------------------------------------------------------------------------------//
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

                btn_print.Visible = true;
                btnSend.Visible = true;
            }
             else
            {
                btn_print.Visible = false;
                btnSend.Visible = false;
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




