using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using System.Web.UI.i
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;

public partial class Transaction_Invoice_Details : ThemeClass
{
    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    Date_Time rep = new Date_Time();
    Transaction Transact = new Transaction();
    eroyalmaster erm = new eroyalmaster();
    adminmaster adm = new adminmaster();

    SqlConnection con;
    SqlCommand cmd;
    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    DataTable dt = new DataTable();
    DataSet ds_license = new DataSet();
    DataSet ds_scheme = new DataSet();

    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();
    DataSet ds3 = new DataSet();
    DataSet ds4 = new DataSet();

    public int i;
    public string AUTO_ID, chk;
    public double freight_value, inv_value, Insurance_value;
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string PRODUCT_IMPORT_ID = "";
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    string SP_QUERY;
    string datestring;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string DEFAULT_DATE;

    public string LoginDate, IMPORT_JOBNO, Total_Freight, Total_Insurance, _slno = "0";
    public string a1 = "", a2 = "", a3 = "", a4 = "", a5 = "", a6 = "", INV_DATE = "", sno = "", PURCHASE_DATE = "", CONTRACT_DATE = "", LC_DATE = "", SVB_DATE = "";
    public string flag = "", inv_no = "", singlemultiple = "", TERMS = "", inv_slno = "", CURRENCY_CODE = "", FREIGHT_EXRATE = "", INSURANCE_EXRATE = "", MISC_EXRATE = "";
    double cal, cal1, invoicevalue;
    string LoadingOn, Ass_Status, Duty_Status;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    public decimal item_amt;
    public string scheme;
    public int licen_slno = 0;

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    public string errorFolder = "", logline = "", logFileName = "";
    public string folderName = "/Submission";
    
    public string createfilename = "";


    User_Creation user_Create = new User_Creation();
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (!Page.IsPostBack)
        //Response.AppendHeader("Refresh", ((Session.Timeout * 60) + 5).ToString() + "; Url=Default.aspx");

        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        DEFAULT_DATE = Session["DEFAULT_DATE"].ToString();

        Screen_Id = 7;
        Page_Rights(Screen_Id);
        TextCopy();
        //txtExRate.Text = hdn_Invoice_Currency_Exrate.Value;

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/"+"Import_Excel");

        if (Session["IMPORT_JOBNO"] != null || Session["IMPORT_JOBDATE"] != null)
        {

            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();

            if (!this.IsPostBack)
            {
                if (DEFAULT_DATE == "Yes")
                {
                    txtDate.Text = rep.Today_Date();

                }
            }
        }
        else
        {
            //Response.Write("<script>window.open('General.aspx','_parent');</script>");
            Response.Write("<script>window.parent.document.getElementById('General').click();</script>");


        }
        //auto search

        //txtInvoiceCurrency.Attributes.Add("onkeyup", "javascript:Call_Excahnge_Rate('" + txtInvoiceCurrency.ClientID + "', '" + txtExRate.ClientID + "')");
        //txtInvoiceCurrency.Attributes.Add("onkeyup", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txtInvoiceCurrency.ClientID + "', '" + txtExRate.ClientID + "')");
        txtInvoiceCurrency.Attributes.Add("onblur", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txtInvoiceCurrency.ClientID + "', '" + txtExRate.ClientID + "')");
       
        txtMiscellaneous_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Exch_Rate.ClientID + "')");
        txtAgency_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtAgency_Currency.ClientID + "', '" + txtAgency_Exch_Rate.ClientID + "')");
        txtDiscount_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtDiscount_Currency.ClientID + "', '" + txtDiscount_Exch_Rate.ClientID + "')");
        txtLoading_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtLoading_Currency.ClientID + "', '" + txtLoading_ExchRate.ClientID + "')");
        txtFreight_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtFreight_Currency.ClientID + "', '" + txtFreight_Exch_Rate.ClientID + "')");
        txtInsurance_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtInsurance_Currency.ClientID + "', '" + txtInsurance_Exch_Rate.ClientID + "')");
        txtHighSeaSale_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtHighSeaSale_Currency.ClientID + "', '" + txtHighSeaSale_Exch_Rate.ClientID + "')");
        //auto search


        //Supplier
        //txtSupplierName.Attributes.Add("onkeyup", "javascript:Call_Supplier('" + txtSupplierName.ClientID + "', '" + txtSupplierAddress.ClientID + "')");
        txtSupplierName.Attributes.Add("onblur", "javascript:Call_Supplier('" + txtSupplierName.ClientID + "', '" + txtSupplierAddress.ClientID + "')");
        //txtSupplierName.Attributes.Add("onkeydown", "javascript:Call_Supplier('" + txtSupplierName.ClientID + "', '" + txtSupplierAddress.ClientID + "')");

        //Supplier

        //seller
        //txtSellerName.Attributes.Add("onkeyup", "javascript:Call_Seller('" + txtSellerName.ClientID + "', '" + txtSellerAddress.ClientID + "')");
        txtSellerName.Attributes.Add("onblur", "javascript:Call_Seller('" + txtSellerName.ClientID + "', '" + txtSellerAddress.ClientID + "')");
        //txtSellerName.Attributes.Add("onkeydown", "javascript:Call_Seller('" + txtSellerName.ClientID + "', '" + txtSellerAddress.ClientID + "')");

        //seller

        //broker
        // txtBrokerName.Attributes.Add("onkeyup", "javascript:Call_Broker('" + txtBrokerName.ClientID + "', '" + txtBrokerAddress.ClientID + "')");
        txtBrokerName.Attributes.Add("onblur", "javascript:Call_Broker('" + txtBrokerName.ClientID + "', '" + txtBrokerAddress.ClientID + "')");
        // txtBrokerName.Attributes.Add("onkeydown", "javascript:Call_Broker('" + txtBrokerName.ClientID + "', '" + txtBrokerAddress.ClientID + "')");

        //broker
        txtFreight_Currency.Attributes.Add("onblur", "javascript:Call_Freight_Currency('" + txtFreight_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "', '" + txtFreight_Exch_Rate.ClientID + "')");
        txtInsurance_Currency.Attributes.Add("onblur", "javascript:Call_Insurance_Currency('" + txtInsurance_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "', '" + txtInsurance_Exch_Rate.ClientID + "')");

        ///auto search
        if (!IsPostBack)
        {
            if (Directory.Exists(errorFolder) == false)
            {
                Directory.CreateDirectory(errorFolder);
            } 

            hdfTransport_mode.Value = Session["TRANSPORT_MODE"].ToString();

            hdn_INVOICE_SLNO.Value = "";

            hdn_grid_edit.Value = "0";
            //--------------- dont delete-------------------------------------//
            //txtExRate.Attributes.Add("readonly", "readonly");
            //txtMiscellaneous_Exch_Rate.Attributes.Add("readonly", "readonly");
            //txtAgency_Exch_Rate.Attributes.Add("readonly", "readonly");
            //txtDiscount_Exch_Rate.Attributes.Add("readonly", "readonly");
            //txtLoading_ExchRate.Attributes.Add("readonly", "readonly");
            //txtFreight_Exch_Rate.Attributes.Add("readonly", "readonly");
            //txtInsurance_Exch_Rate.Attributes.Add("readonly", "readonly");

            //txtHighSeaSale_Exch_Rate.Attributes.Add("readonly", "readonly");
            //--------------- dont delete--------------------------------------//
            txtTotal_Frieght.Text = "";
            txtTotal_Insurance.Text = "";
            txtFreight_Rate.Text = "20.0000";
            txtInsurance_Rate.Text = "1.1250";
            txtFreight_Charges.Text = "";
            txtInsurance_Charges.Text = "";
            txtInvoiceNo.Focus();
            ddlterms();
            ddlLoading_On();
            ddlAssesableStatus();
            ddlDutyStatus();
            gridbind(inv_no, flag, TERMS, inv_slno);
            hdn_INVOICE_SLNO.Value = "";
            Session["_SLNO"] = null;
            // string h=  txtInsurance_Rate.Text;
            //if (dss.Tables[0].Rows.Count > 0)
            //{
            //    //flag = dss.Tables[0].Rows[0]["TERMS"].ToString();
            //singlemultiple = dss.Tables[0].Rows[0]["MIS_SINGLE_OR_MULITIPLE"].ToString();
            //if (singlemultiple == "M")
            //{
            //    chkMisc.Checked = true;
            //    chkMisc.Enabled = false;
            //    txtFreight_Charges.Text = Convert.ToString(Transact.ALL_FREIGHT_TOTAL);
            //    txtInsurance_Charges.Text = Convert.ToString(Transact.ALL_INSURANCE_TOTAL);
            //    txtFreight_Charges.Enabled = false;
            //    txtInsurance_Charges.Enabled = false;
            //}
            //else
            //{
            //    chkMisc.Enabled = true;
            //    txtFreight_Charges.Enabled = true;
            //    txtInsurance_Charges.Enabled = true;
            //}
            //ddlTerms.Enabled = false;
            //ddlTerms.Items.Clear();
            //ddlTerms.Items.Add(flag);
            //}
            //else
            //{
            //    ddlterms_clear();
            //}
            // this.imgbtnSupplier.Attributes.Add("onclick", "javascript://return OpenPopupSupplier()");
        }

        if (ViewState["INVOICE_ID"] != "" && ViewState["INVOICE_ID"] != null)
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            //btnSave.Text = "Add";

        }
        else
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;


        }

        //if (Session["Single_FI"] != null)
        //{
        //    btnSave.Enabled = false;
        //    btnUpdate.Visible = false;
        //    btnDelete.Visible = false;
        //}
        //else
        //{


        //}

        if (!IsPostBack)
        {
            //Get_ProductValue();
            //Load_ddlDropdown_Custom_house();
        }

  
    }
    public void Page_Rights(int i)
    {
        user_Create.RetrieveAll_User_Screen_Rights_Details(i);
        PAGE_WRITE = user_Create.PAGE_WRITE;
        PAGE_READ = user_Create.PAGE_READ;
        PAGE_MODIFY = user_Create.PAGE_MODIFY;
        PAGE_DELETE = user_Create.PAGE_DELETE;
        hdn_Grid_Disable.Value = "";

        //---------------READ ONLY------------------//

        if (PAGE_READ == "False")
        {
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            btnNew.ToolTip = "You don't have permission to access";
            btnSave.ToolTip = "You don't have permission to access";
            btnUpdate.ToolTip = "You don't have permission to access";
            btnDelete.ToolTip = "You don't have permission to access";
            hdn_Grid_Disable.Value = "1";
           
        }
        else
        {


            //}
            //btnNew.Enabled = true;
            //---------------SAVE BUTTON------------------//
            if (PAGE_WRITE == "True")
            {
                btnSave.Enabled = true;
                btnNew.Enabled = true;

            }
            else
            {
                btnSave.Enabled = false;
                btnSave.ToolTip = "You don't have permission to access";
                btnNew.Enabled = false;

            }
            //---------------UPDATE BUTTON------------------//

            if (PAGE_MODIFY == "True")
            {
                btnUpdate.Enabled = true;
                hdn_Grid_Disable.Value = "";


            }
            else
            {
                btnUpdate.Enabled = false;
                btnUpdate.ToolTip = "You don't have permission to access";
                hdn_Grid_Disable.Value = "1";


            }
            //---------------DELETE BUTTON------------------//

            if (PAGE_DELETE == "True")
            {
                btnDelete.Enabled = true;
                hdn_Grid_Disable.Value = "";


            }
            else
            {
                btnDelete.Enabled = false;
                btnDelete.ToolTip = "You don't have permission to access";
                hdn_Grid_Disable.Value = "1";


            }
        }
        if(hdn_Grid_Disable.Value=="1")
            gv_Invoice.ToolTip = "You don't have permission to access";
    }
    public void ddlterms_clear()
    {
        ddlTerms.Items.Clear();
        //ddlTerms.Items.Add("");

        ddlTerms.Items.Add("FOB");
        ddlTerms.Items.Add("CI");
        ddlTerms.Items.Add("CF");
        ddlTerms.Items.Add("CIF");
    }
    public void ddlterms()
    {

        //ddlTerms.Items.Add("");

        ddlTerms.Items.Add("FOB");
        ddlTerms.Items.Add("CI");
        ddlTerms.Items.Add("CF");
        ddlTerms.Items.Add("CIF");
    }

    public void ddlLoading_On()
    {
        ddlLoadingOn.Items.Add("");

        ddlLoadingOn.Items.Add("Assessable");
        ddlLoadingOn.Items.Add("Duty");
        ddlLoadingOn.Items.Add("Both");

    }

    public void ddlLoading_OnEdit()
    {

        ddlLoadingOn.Items.Add("Assessable");
        ddlLoadingOn.Items.Add("Duty");
        ddlLoadingOn.Items.Add("Both");

    }

    public void ddlAssesableStatus()
    {
        ddlAssesable_Status.Items.Add("");

        ddlAssesable_Status.Items.Add("Provisional");
        ddlAssesable_Status.Items.Add("Final");
    }
    public void ddlAssesableStatusEdit()
    {

        ddlAssesable_Status.Items.Add("Provisional");
        ddlAssesable_Status.Items.Add("Final");
    }


    public void ddlDutyStatus()
    {
        ddlDuty_Status.Items.Add("");

        ddlDuty_Status.Items.Add("Provisional");
        ddlDuty_Status.Items.Add("Final");
    }
    public void ddlDutyStatusEdit()
    {

        ddlDuty_Status.Items.Add("Provisional");
        ddlDuty_Status.Items.Add("Final");
    }

    public DataSet insert_update(string a1, string a2, string a3, string a4, string a5, string a6, string chkmis)
    {
        if (a5 == "")
            a5 = "0";
        if (a6 == "")
            a6 = "0";

        Transact.INV_SLNO = a4;

        Transact.INVOICE_ID = a1;
        Transact.JOBNO = IMPORT_JOBNO; //session jobno
        Transact.INVOICE_NO = txtInvoiceNo.Text.ToUpper();
        Transact.INVOICE_DATE = INV_DATE;
        Transact.TERMS = ddlTerms.SelectedValue.ToString();
        Transact.INVOICE_CURRENCY = txtInvoiceCurrency.Text.ToUpper();
        Transact.INVOICE_EXRATE = txtExRate.Text;
        Transact.INVOICE_VALUE = txtInvoiceValue.Text;
        Transact.SUPPLIER_NAME = txtSupplierName.Text;
        Transact.SUPPLIER_ADDRESS = txtSupplierAddress.Text;
        Transact.SUPPLIER_ADDRESS1 = txtSupplierAddress1.Text;
        Transact.SUPPLIER_ADDRESS2 = txtSupplierAddress2.Text;

        Transact.SUPPLIER_COUNTRY_NAME = txtSupplierCountryName.Text;
        Transact.SUPPLIER_COUNTRY_CODE = hfdsupplier_countrycode.Value;
        Transact.SUPPLIER_COUNTRY_PINCODE = txtSuppliercountry_pincode.Text;
        Transact.SELLER_NAME = txtSellerName.Text;
        Transact.SELLER_ADDRESS = txtSellerAddress.Text;
        Transact.SELLER_ADDRESS1 = txtSellerAddress1.Text;
        Transact.SELLER_ADDRESS2 = txtSellerAddress2.Text;

        Transact.SELLER_COUNTRY_NAME = txtSellerCountryName.Text;
        Transact.SELLER_COUNTRY_CODE = hfdseller_countrycode.Value;
        Transact.SELLERCOUNTRY_PINCODE = txtSellercountry_pincode.Text;
        Transact.BROKER_NAME = txtBrokerName.Text;
        Transact.BROKER_ADDRESS = txtBrokerAddress.Text;
        Transact.BROKER_ADDRESS1 = txtBrokerAddress1.Text;
        Transact.BROKER_ADDRESS2 = txtBrokerAddress2.Text;

        Transact.BROKER_COUNTRY_NAME = txtBrokerCountryName.Text;
        Transact.BROKER_COUNTRY_CODE = hfdbroker_countrycode.Value;
        Transact.BROKER_COUNTRY_PINCODE = txtbrokercountry_pincode.Text;
        Transact.MIS_CHARGES = txtMiscellaneous_Charges.Text;
        Transact.MIS_RATE = txtMiscellaneous_Rate.Text;
        Transact.MIS_CURRENCY = txtMiscellaneous_Currency.Text.ToUpper();
        Transact.MIS_EXRATE = txtMiscellaneous_Exch_Rate.Text;
        Transact.MIS_AGENCY_CHARGES = txtAgency_Charges.Text; ;
        Transact.MIS_AGENCY_RATE = txtAgency_Rate.Text;
        Transact.MIS_AGENCY_CURRENCY = txtAgency_Currency.Text.ToUpper();
        Transact.MIS_AGENCY_EXRATE = txtAgency_Exch_Rate.Text;
        Transact.MIS_DISCOUNT_CHARGES = txtDiscount_Charges.Text;
        Transact.MIS_DISCOUNT_RATE = txtDiscount_Rate.Text;
        Transact.MIS_DISCOUNT_CURRENCY = txtDiscount_Currency.Text.ToUpper();
        Transact.MIS_DISCOUNT_EXRATE = txtDiscount_Exch_Rate.Text;
        Transact.MIS_DISCOUNT_REASON = txtDiscount_Reason.Text;

        Transact.MIS_LOADING_CHARGES = txtLoading_Charges.Text;
        Transact.MIS_LOADING_EXRATE = txtLoading_ExchRate.Text;
        Transact.MIS_LOADING_RATE = txtLoading_Rate.Text;
        Transact.MIS_LOADING_CURRENCY = txtLoading_Currency.Text.ToUpper();

        // Transact.MIS_FREIGHT_CHARGES = txtFreight_Charges.Text;
        Transact.MIS_FREIGHT_CHARGES = a5;
        Transact.MIS_FREIGHT_RATE = txtFreight_Rate.Text;
        Transact.MIS_FREIGHT_CURRENCY = txtFreight_Currency.Text.ToUpper();
        Transact.MIS_FREIGHT_EXRATE = txtFreight_Exch_Rate.Text;
        //Transact.MIS_INSURANCE_CHARGES = txtInsurance_Charges.Text;
        Transact.MIS_INSURANCE_CHARGES = a6;
        Transact.MIS_INSURANCE_RATE = txtInsurance_Rate.Text;
        Transact.MIS_INSURANCE_CURRENCY = txtInsurance_Currency.Text.ToUpper();
        Transact.MIS_INSURANCE_EXRATE = txtInsurance_Exch_Rate.Text;


        Transact.MIS_HIGHSEASALE_CHARGES = txtHighSeaSale_Charges.Text;
        Transact.MIS_HIGHSEASALE_EXRATE = txtHighSeaSale_Exch_Rate.Text;
        Transact.MIS_HIGHSEASALE_RATE = txtHighSeaSale_Rate.Text;
        Transact.MIS_HIGHSEASALE_CURRENCY = txtHighSeaSale_Currency.Text.ToUpper();

        Transact.MIS_SINGLE_OR_MULITIPLE = chkmis;

        string chksvb;
        if (chkSVB_Relation.Checked == true)
        {
            chksvb = "Y";
        }
        else
        {
            chksvb = "N";
        }

        Transact.SVB_RELATION = chksvb;
        //Transact.SVB_RELATION = "";
        Transact.SVB_REF_DATE = SVB_DATE;
        Transact.SVB_REF_NO = txtSVB_RefNo.Text;
        Transact.SVB_CUSTOM_HOUSE = txtCustomsHouse.Text;

        if (ddlLoadingOn.SelectedValue == "Assessable")
        {
            LoadingOn = "A";
        }
        else if (ddlLoadingOn.SelectedValue == "Duty")
        {
            LoadingOn = "D";
        }
        else if (ddlLoadingOn.SelectedValue == "Both")
        {
            LoadingOn = "B";
        }

        //Transact.SVB_LOADING_ON = ddlLoadingOn.SelectedValue.ToString();

        Transact.SVB_LOADING_ON = LoadingOn;
        Transact.SVB_ASSESABLE_RATE = txtAssesable_Rate.Text;
        Transact.SVB_DUTY_RATE = txtDuty_Rate.Text;


        if (ddlAssesable_Status.SelectedValue == "Provisional")
        {
            Ass_Status = "P";
        }
        else if (ddlAssesable_Status.SelectedValue == "Final")
        {
            Ass_Status = "F";
        }

        Transact.SVB_ASSESABLE_STATUS = Ass_Status;

        if (ddlDuty_Status.SelectedValue == "Provisional")
        {
            Duty_Status = "P";
        }
        else if (ddlDuty_Status.SelectedValue == "Final")
        {
            Duty_Status = "F";
        }

        Transact.SVB_DUTY_STATUS = Duty_Status;
        Transact.OTHER_PURCHASE_ORDER = txtPurchaseOrderNo.Text;
        Transact.OTHER_PURCHASE_ORDER_DATE = PURCHASE_DATE;
        Transact.OTHER_CONTRACT_NO = txtContractNo.Text;
        Transact.OTHER_CONTRACT_DATE = CONTRACT_DATE;
        Transact.OTHER_LOC_NO = txtLCNo.Text;
        Transact.OTHER_LOC_DATE = LC_DATE;
        Transact.OTHER_NATURE_OF_TRANSACTION = ddlNatureOfTrans.SelectedValue.ToString();
        Transact.OTHER_TERMS_OF_PAYMENT = ddlNatureOfPayment.SelectedValue.ToString();
        Transact.OTHER_CONDITIONS = txtConditions.Text;
        Transact.OTHER_VALUATION_METHOD = ddlValuationMethod.SelectedValue.ToString();
        Transact.USER_ID = currentuser;
        Transact.BRANCH_CODE = currentbranch;
        Transact.flag = a2;
        Transact.YEAR = a3;
        Transact.WORKING_PERIOD = Working_Period;

        Transact.NON_STD_EFFECT_DT_IMP = hdn_non_std_effect_dt.Value.Trim();
        Transact.NON_STD_BANKNAME = hdn_non_std_bankname.Value;
        Transact.NON_STD_CERTIFICATE_NO = hdn_non_std_cert_no.Value;
        Transact.NON_STD_CERTIFICATE_DATE = hdn_non_std_cert_dt.Value.Trim();

        //i = Transact.Invoice_Details_insertupdate();
        dtuser = Transact.Invoice_Details_insertupdate();
        i = Transact.result;

        return dtuser;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {


        txtFreight_Rate.Text = hdn_Freight_Rate.Value;
        txtInsurance_Rate.Text = hdn_Insurance_Rate.Value;
        txtFreight_Currency.Text = hdn_FOB_Freight_Currency.Value;
        txtInsurance_Currency.Text = hdn_FOB_Insurance_Currency.Value;
        txtFreight_Exch_Rate.Text = hdn_FOB_Freight_ExRate.Value;
        txtInsurance_Exch_Rate.Text = hdn_FOB_Insurance_ExRate.Value;
        try
        {

            txtFreight_Charges.Text = hdn_freight_value.Value;
            txtInsurance_Charges.Text = hdn_insurance_value.Value;
            a1 = "";
            a2 = "S";
            a3 = "";
            a4 = "";
            a5 = txtFreight_Charges.Text;
            a6 = txtInsurance_Charges.Text;

            insert_or_update();
            if (i == 1)
            {

                hdn_Freight_Rate.Value = txtFreight_Rate.Text;
                hdn_Insurance_Rate.Value = txtInsurance_Rate.Text;
                btnNew_Click(sender, e);

                //txtFreight_Charges.Text = a5;
                //txtInsurance_Charges.Text = a6;
                //mo.ResetFields(Page.Controls);
                //TabContainer1.ActiveTabIndex = 0;

                txtInvoiceNo.Focus();
                hdn_button_click.Value = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>document.getElementById('IMD').click();</script>", false);

                Alert_msg("Invoice Saved Successfully", "btnSave");
                //if (chkMisc.Checked == true)
                //{

                //    chkMisc.Enabled = true;

                //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record  Saved')</script>", false);
                //    Alert_msg("IGM Saved Successfully", "btnSave");

                //}
                //else
                //{
                //    chkMisc.Enabled = true;
                //    //Session["Single_FI"] = null;
                //    // Session["Single_FI"] = "Single_FI";
                //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record  Saved')</script>", true);

                //    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript://Iframe_Product_Details('../Transaction/Item_Main_Details.aspx')", true);
                //    txtInvoiceNo.Focus();
                //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record  Saved')</script>", false);
                //    Alert_msg("IGM Saved Successfully", "btnSave");



                //}




            }
            else if (i == 2)
            {
                //TabContainer1.ActiveTabIndex = 0;
                Terms_Change_Updating_MultiInvoice();


                txtInvoiceNo.Focus();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('')</script>", false);
                Alert_msg("Invoice No Already Exist", "btnSave");


            }
            else if (i == 3)
            {
                Terms_Change_Updating_MultiInvoice();

                //TabContainer1.ActiveTabIndex = 0;
                txtInvoiceNo.Focus();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Saved, Single Freight (or) Insurance Already Exist for Job NO" + IMPORT_JOBNO + "')</script>", false);
                //Alert_msg("Single Freight (or) Insurance Already Exist for Job NO" + IMPORT_JOBNO+"", "btnSave");
                Alert_msg("Invoice No Already Exist", "btnSave");


            }


            else if (i == 0)
            {
                Terms_Change_Updating_MultiInvoice();

                //TabContainer1.ActiveTabIndex = 0;

                txtInvoiceNo.Focus();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                Alert_msg("Record Not Saved", "btnSave");


            }







        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>document.getElementById('IMD').click();</script>", false);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>dropdown_change();</script>", false);

    }

    protected void gv_Invoice_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["INVOICE_ID"] = Convert.ToString(this.gv_Invoice.SelectedDataKey.Value);

        if (ViewState["INVOICE_ID"] != "" && ViewState["INVOICE_ID"] != null)
        {
            hdn_grid_edit.Value = "1";
            hdn_button_click.Value = "1";

            //btnSave.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = false;

            //btnSave.Text = "Add";
            //btnSave.Enabled = true;
            hdn_update_Invoice_id.Value = ViewState["INVOICE_ID"].ToString();

            Label s_itemType = gv_Invoice.SelectedRow.FindControl("lblFullName") as Label;
            Session["_SLNO"] = s_itemType.Text;
            hdn_INVOICE_SLNO.Value = s_itemType.Text;
            sno = gv_Invoice.SelectedRow.Cells[2].Text;

            Session["INV_SLNO"] = sno;
            txtInvoiceNo.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[3].Text);
            txtDate.Text = gv_Invoice.SelectedRow.Cells[4].Text.Replace("01/01/1900", "");

            string terms = gv_Invoice.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            ddlterms_clear();
            ddlTerms.Items.Remove(terms);
            ddlTerms.Items.Insert(0, terms);
            txtInvoiceValue.Text = gv_Invoice.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            txtInvoiceCurrency.Text = gv_Invoice.SelectedRow.Cells[7].Text.ToUpper().Replace("&nbsp;", "");
            string chk = gv_Invoice.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            hdn_Invoice_mode_singlr_or_multi.Value = chk;
            txtSupplierName.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[9].Text);
            txtSupplierAddress.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[10].Text);

            txtSupplierAddress1.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[11].Text);

            txtSupplierAddress2.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[12].Text);
            txtSupplierCountryName.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[13].Text);
            hfdsupplier_countrycode.Value = gv_Invoice.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
            txtSuppliercountry_pincode.Text = gv_Invoice.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");
            txtSellerName.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[16].Text);
            txtSellerAddress.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[17].Text);
            txtSellerAddress1.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[18].Text);
            txtSellerAddress2.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[19].Text);
            txtSellerCountryName.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[20].Text);
            hfdseller_countrycode.Value = gv_Invoice.SelectedRow.Cells[21].Text.Replace("&nbsp;", "");
            txtSellercountry_pincode.Text = gv_Invoice.SelectedRow.Cells[22].Text.Replace("&nbsp;", "");
            txtBrokerName.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[23].Text);
            txtBrokerAddress.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[24].Text);
            txtBrokerAddress1.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[25].Text);
            txtBrokerAddress2.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[26].Text);
            txtBrokerCountryName.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[27].Text);
            hfdbroker_countrycode.Value = gv_Invoice.SelectedRow.Cells[28].Text.Replace("&nbsp;", "");
            txtbrokercountry_pincode.Text = gv_Invoice.SelectedRow.Cells[29].Text.Replace("&nbsp;", "");
            txtMiscellaneous_Charges.Text = gv_Invoice.SelectedRow.Cells[30].Text.Replace("&nbsp;", "");
            txtMiscellaneous_Rate.Text = gv_Invoice.SelectedRow.Cells[31].Text.Replace("&nbsp;", "");
            txtMiscellaneous_Currency.Text = gv_Invoice.SelectedRow.Cells[32].Text.Replace("&nbsp;", "");
            txtMiscellaneous_Exch_Rate.Text = gv_Invoice.SelectedRow.Cells[33].Text.Replace("&nbsp;", "");
            txtAgency_Charges.Text = gv_Invoice.SelectedRow.Cells[34].Text.Replace("&nbsp;", "");
            txtAgency_Rate.Text = gv_Invoice.SelectedRow.Cells[35].Text.Replace("&nbsp;", "");
            txtAgency_Currency.Text = gv_Invoice.SelectedRow.Cells[36].Text.Replace("&nbsp;", "");
            txtAgency_Exch_Rate.Text = gv_Invoice.SelectedRow.Cells[37].Text.Replace("&nbsp;", "");
            txtDiscount_Charges.Text = gv_Invoice.SelectedRow.Cells[38].Text.Replace("&nbsp;", "");
            txtDiscount_Rate.Text = gv_Invoice.SelectedRow.Cells[39].Text.Replace("&nbsp;", "");
            txtDiscount_Currency.Text = gv_Invoice.SelectedRow.Cells[40].Text.Replace("&nbsp;", "");
            txtDiscount_Exch_Rate.Text = gv_Invoice.SelectedRow.Cells[41].Text.Replace("&nbsp;", "");
            txtDiscount_Reason.Text = gv_Invoice.SelectedRow.Cells[42].Text.Replace("&nbsp;", "");
            txtLoading_Charges.Text = gv_Invoice.SelectedRow.Cells[43].Text.Replace("&nbsp;", "");
            txtLoading_Rate.Text = gv_Invoice.SelectedRow.Cells[44].Text.Replace("&nbsp;", "");
            txtLoading_Currency.Text = gv_Invoice.SelectedRow.Cells[45].Text.Replace("&nbsp;", "");
            txtLoading_ExchRate.Text = gv_Invoice.SelectedRow.Cells[46].Text.Replace("&nbsp;", "");
            txtFreight_Charges.Text = gv_Invoice.SelectedRow.Cells[47].Text.Replace("&nbsp;", "");

            txtFreight_Rate.Text = gv_Invoice.SelectedRow.Cells[48].Text.Replace("&nbsp;", "");
            txtFreight_Currency.Text = gv_Invoice.SelectedRow.Cells[49].Text.Replace("&nbsp;", "");
            txtFreight_Exch_Rate.Text = gv_Invoice.SelectedRow.Cells[50].Text.Replace("&nbsp;", "");
            txtInsurance_Charges.Text = gv_Invoice.SelectedRow.Cells[51].Text.Replace("&nbsp;", "");
            txtInsurance_Rate.Text = gv_Invoice.SelectedRow.Cells[52].Text.Replace("&nbsp;", "");
            txtInsurance_Currency.Text = gv_Invoice.SelectedRow.Cells[53].Text.Replace("&nbsp;", "");
            txtInsurance_Exch_Rate.Text = gv_Invoice.SelectedRow.Cells[54].Text.Replace("&nbsp;", "");
            txtHighSeaSale_Charges.Text = gv_Invoice.SelectedRow.Cells[55].Text.Replace("&nbsp;", "");
            txtHighSeaSale_Rate.Text = gv_Invoice.SelectedRow.Cells[56].Text.Replace("&nbsp;", "");
            txtHighSeaSale_Currency.Text = gv_Invoice.SelectedRow.Cells[57].Text.Replace("&nbsp;", "");
            txtHighSeaSale_Exch_Rate.Text = gv_Invoice.SelectedRow.Cells[58].Text.Replace("&nbsp;", "");
            txtExRate.Text = gv_Invoice.SelectedRow.Cells[78].Text.Replace("&nbsp;", "");

            

            if (chk == "M")
            {

                chkMisc.Checked = true;
                chkMisc.Enabled = true;
                //if (Int32.Parse(sno) == 1)
                if (Int32.Parse(s_itemType.Text) == 1)
                {


                    chkMisc.Enabled = true;
                    ddlTerms.Enabled = true;

                    txtTotal_Frieght.Enabled = true;
                    txtTotal_Insurance.Enabled = true;
                    tag_Totalfrieght.Style.Add("display", "block");
                    tag_TotalInsurance.Style.Add("display", "block");
                    txtFreight_Charges.Enabled = false;
                    txtInsurance_Charges.Enabled = false;
                    txtTotal_Frieght.Text = hdn_Total_Freight_Value.Value;
                    txtTotal_Insurance.Text = hdn_Total_Insurance_Value.Value;
                    tag_Totalfrieght.Visible = true;
                    tag_TotalInsurance.Visible = true;

                    pnl_Multi_Invoice.Enabled = true;

                }
                else
                {
                    chkMisc.Enabled = false;
                    ddlTerms.Enabled = false;
                    tag_Totalfrieght.Visible = true;
                    tag_TotalInsurance.Visible = true;
                    //tag_Totalfrieght.Style.Add("display", "none");
                    //tag_TotalInsurance.Style.Add("display", "none");

                    txtTotal_Frieght.Enabled = false;
                    txtTotal_Insurance.Enabled = false;
                    txtFreight_Charges.Enabled = false;
                    txtInsurance_Charges.Enabled = false;
                    pnl_Multi_Invoice.Enabled = false;
                    txtTotal_Frieght.Text = hdn_Total_Freight_Value.Value;
                    txtTotal_Insurance.Text = hdn_Total_Insurance_Value.Value;


                }
                //terms//
                get_Textboxvalue();
                Terms_Change_Updating_MultiInvoice();
                //terms//

                tag_Totalfrieght.Style.Add("display", "block");
                tag_TotalInsurance.Style.Add("display", "block");


                tag_Totalfrieght.Visible = true;
                tag_TotalInsurance.Visible = true;
                txtFreight_Rate.Text = "0.00";
                txtInsurance_Rate.Text = "0.00";
            }
            else
            {
                pnl_Multi_Invoice.Enabled = true;

                chkMisc.Enabled = true;
                chkMisc.Checked = false;
                tag_Totalfrieght.Style.Add("display", "none");
                tag_TotalInsurance.Style.Add("display", "none");


                txtTotal_Frieght.Enabled = false;
                txtTotal_Insurance.Enabled = false;
                txtFreight_Charges.Visible = true;
                txtInsurance_Charges.Visible = true;
                txtFreight_Charges.Enabled = false;
                txtInsurance_Charges.Enabled = false;
                txtTotal_Frieght.Text = hdn_Total_Freight_Value.Value;
                txtTotal_Insurance.Text = hdn_Total_Insurance_Value.Value;

                tag_Totalfrieght.Visible = false;
                tag_TotalInsurance.Visible = false;
                //terms//
                get_Textboxvalue();
                
                Terms_Change_Updating_MultiInvoice();
                //terms//

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Total_freight_Insurance_Display_none();</script>", true);
                //Response.Write("<script language='javascript'>Total_freight_Insurance_Display_none();</script>");

            }
            string chksvb = gv_Invoice.SelectedRow.Cells[59].Text.Replace("&nbsp;", "");
            if (chksvb == "Y")
            {
                chkSVB_Relation.Checked = true;
                txtSVB_RefNo.Enabled = true;
                txtSVBDate.Enabled = true;
                //ddlSVB_CustomHouse.Enabled = true;
                txtCustomsHouse.Enabled = true;

                ddlLoadingOn.Enabled = true;
                //txtAssesable_Rate.Enabled = true;
                //txtDuty_Rate.Enabled = true;
                //ddlAssesable_Status.Enabled = true;
                //ddlDuty_Status.Enabled = true;
            }
            else
            {
                chkSVB_Relation.Checked = false;

            }

            txtSVB_RefNo.Text = gv_Invoice.SelectedRow.Cells[60].Text.Replace("&nbsp;", "");
            string SVB_CustomHouse = gv_Invoice.SelectedRow.Cells[61].Text.Replace("&nbsp;", "");
            //Load_ddlDropdown_Custom_house();
            //ddlSVB_CustomHouse.Items.Remove(SVB_CustomHouse);
            //ddlSVB_CustomHouse.Items.Insert(0, SVB_CustomHouse);
            //ddlLoadingOn.Items.Clear();
            txtCustomsHouse.Text = SVB_CustomHouse;

            LoadingOn = gv_Invoice.SelectedRow.Cells[62].Text.Replace("&nbsp;", "");
            string load_on = "";
            if (LoadingOn == "A")
            {
                load_on = "Assessable";

                txtAssesable_Rate.Enabled = true;

                ddlAssesable_Status.Enabled = true;


            }
            else if (LoadingOn == "D")
            {
                load_on = "Duty";
                txtDuty_Rate.Enabled = true;
                ddlDuty_Status.Enabled = true;
            }
            else if (LoadingOn == "B")
            {
                load_on = "Both";
            }
            ddlLoadingOn.Items.Clear();
            ddlLoading_On();
            ddlLoadingOn.Items.Remove(load_on);
            ddlLoadingOn.Items.Insert(0, load_on);
            txtAssesable_Rate.Text = gv_Invoice.SelectedRow.Cells[63].Text.Replace("&nbsp;", "");
            txtDuty_Rate.Text = gv_Invoice.SelectedRow.Cells[64].Text.Replace("&nbsp;", "");

            ddlAssesable_Status.Items.Clear();
            Ass_Status = gv_Invoice.SelectedRow.Cells[65].Text.Replace("&nbsp;", "");
            string assesable = "";
            if (Ass_Status == "P")
            {
                assesable = "Provisional";
            }
            else if (Ass_Status == "F")
            {
                assesable = "Final";
            }


            ddlAssesableStatus();
            ddlAssesable_Status.Items.Remove(assesable);
            ddlAssesable_Status.Items.Insert(0, assesable);
            //ddlAssesable_Status.Items.Add(gv_Invoice.SelectedRow.Cells[64].Text.Replace("&nbsp;", ""));

            ddlDuty_Status.Items.Clear();
            Duty_Status = gv_Invoice.SelectedRow.Cells[66].Text.Replace("&nbsp;", "");
            string duty_status = "";
            if (Duty_Status == "P")
            {
                duty_status = "Provisional";

            }
            else if (Duty_Status == "F")
            {
                duty_status = "Final";


            }

            ddlDutyStatus();
            ddlDuty_Status.Items.Remove(duty_status);
            ddlDuty_Status.Items.Insert(0, duty_status);
            //ddlDuty_Status.Items.Add(gv_Invoice.SelectedRow.Cells[65].Text.Replace("&nbsp;", ""));
            txtPurchaseOrderNo.Text = gv_Invoice.SelectedRow.Cells[67].Text.Replace("&nbsp;", "");
            txtPurchaseDate.Text = gv_Invoice.SelectedRow.Cells[68].Text.Replace("01/01/1900", "");
            txtContractNo.Text = gv_Invoice.SelectedRow.Cells[69].Text.Replace("&nbsp;", "");
            txtContractDate.Text = gv_Invoice.SelectedRow.Cells[70].Text.Replace("01/01/1900", "");
            txtLCNo.Text = gv_Invoice.SelectedRow.Cells[71].Text.Replace("&nbsp;", "");
            txtLCDate.Text = gv_Invoice.SelectedRow.Cells[72].Text.Replace("01/01/1900", "");
            ddlNatureOfTrans.Items.Add(gv_Invoice.SelectedRow.Cells[73].Text.Replace("&nbsp;", ""));
            ddlNatureOfPayment.Items.Add(gv_Invoice.SelectedRow.Cells[74].Text.Replace("&nbsp;", ""));
            txtConditions.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[75].Text);
            ddlValuationMethod.Items.Add(gv_Invoice.SelectedRow.Cells[76].Text.Replace("&nbsp;", ""));
            txtSVBDate.Text = gv_Invoice.SelectedRow.Cells[77].Text.Replace("01/01/1900", "");
            //txtExRate.Text = gv_Invoice.SelectedRow.Cells[77].Text.Replace("&nbsp;", "");

            hdn_non_std_effect_dt.Value = gv_Invoice.SelectedRow.Cells[80].Text.Replace("&nbsp;", "");
            hdn_non_std_bankname.Value = gv_Invoice.SelectedRow.Cells[81].Text.Replace("&nbsp;", "");
            hdn_non_std_cert_no.Value = gv_Invoice.SelectedRow.Cells[82].Text.Replace("&nbsp;", "");
            hdn_non_std_cert_dt.Value = gv_Invoice.SelectedRow.Cells[83].Text.Replace("&nbsp;", "");


            lblInvoiceNo.Text = txtInvoiceNo.Text;
            lblInvoiceDate.Text = txtDate.Text;
            lblInvoiceCurrency.Text = txtInvoiceCurrency.Text;
            lblInvoiceTerms.Text = ddlTerms.SelectedValue;
            lblInvoiceValue.Text = txtInvoiceValue.Text;
            //lblProductValue.Text=

            Get_ProductValue();
            Terms_clear_Total_freight_Insurance();
            hdn_button_click.Value = "";
            if (gv_Invoice.Rows.Count > 0)
            {
                if (gv_Invoice.Rows.Count == 1)
                {
                    hdn_grid_count.Value = "1";
                    tag_Totalfrieght.Style.Add("display", "none");
                    tag_TotalInsurance.Style.Add("display", "none");
                    tag_Totalfrieght.Visible = false;
                    tag_TotalInsurance.Visible = false;
                    
                }
                else if (gv_Invoice.Rows.Count > 0)
                {
                    hdn_grid_count.Value = Convert.ToString(gv_Invoice.Rows.Count);

                }
                else
                    hdn_grid_count.Value = "0";
                Grid_count_one();
            }
            else
                hdn_grid_count.Value = "0";
        }
        else
        {
            hdn_grid_edit.Value = "0";
            hdn_button_click.Value = "";

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>document.getElementById('IMD').click();</script>", false);

    }

    public void Grid_count_one()
    {
        if (hdn_Invoice_mode_singlr_or_multi.Value == "M")
        {
            if (ddlTerms.SelectedValue == "FOB")
            {
                txtFreight_Rate.Enabled = false;
                txtFreight_Charges.Enabled = true;
                txtInsurance_Rate.Enabled = false;
                txtInsurance_Charges.Enabled = true;

            }
            else if (ddlTerms.SelectedValue == "CI")
            {
                txtFreight_Rate.Enabled = false;
                txtFreight_Charges.Enabled = true;
                txtInsurance_Rate.Enabled = false;
                txtInsurance_Charges.Enabled = false;
            }
            else if (ddlTerms.SelectedValue == "CF")
            {
                txtFreight_Rate.Enabled = false;
                txtFreight_Charges.Enabled = false;
                txtInsurance_Rate.Enabled = false;
                txtInsurance_Charges.Enabled = true;
            }
            else if (ddlTerms.SelectedValue == "CIF")
            {
                txtFreight_Rate.Enabled = false;
                txtFreight_Charges.Enabled = false;
                txtInsurance_Rate.Enabled = false;
                txtInsurance_Charges.Enabled = false;
            }
        }
        else if (hdn_Invoice_mode_singlr_or_multi.Value == "S")
        {
            if (ddlTerms.SelectedValue == "FOB")
            {
                txtFreight_Rate.Enabled = true;
                txtFreight_Charges.Enabled = false;
                txtInsurance_Rate.Enabled = true;
                txtInsurance_Charges.Enabled = false;
                if (txtFreight_Rate.Text != "0" && txtFreight_Rate.Text != "0.00" && txtFreight_Rate.Text != "")
                {

                    txtFreight_Rate.Enabled = true;
                    txtFreight_Charges.Enabled = false;
                }
                else
                {

                    txtFreight_Rate.Enabled = true;
                    txtFreight_Charges.Enabled = true;
                }
                if (txtInsurance_Rate.Text != "0" && txtInsurance_Rate.Text != "0.00" && txtInsurance_Rate.Text != "")
                {

                    txtInsurance_Rate.Enabled = true;
                    txtInsurance_Charges.Enabled = false;
                }
                else
                {
                    txtInsurance_Rate.Enabled = true;
                    txtInsurance_Charges.Enabled = true;
                }
            }
            else if (ddlTerms.SelectedValue == "CI")
            {
                txtFreight_Exch_Rate.Enabled = true;
                txtFreight_Currency.Enabled = true;

                txtInsurance_Exch_Rate.Enabled = false;
                txtInsurance_Currency.Enabled = false;
                txtInsurance_Rate.Enabled = false;
                //txtInsurance_Charges.Enabled = false;
                if (txtFreight_Rate.Text != "0" && txtFreight_Rate.Text != "0.00" && txtFreight_Rate.Text != "")
                {

                    txtFreight_Rate.Enabled = true;
                    txtFreight_Charges.Enabled = false;
                }
                else
                {

                    txtFreight_Rate.Enabled = true;
                    txtFreight_Charges.Enabled = true;
                }
                txtInsurance_Currency.Text = "";
                txtInsurance_Exch_Rate.Text = "";
                txtInsurance_Rate.Text = "";
                txtInsurance_Charges.Text = "";
            }
            else if (ddlTerms.SelectedValue == "CF")
            {
                txtFreight_Exch_Rate.Enabled = false;
                txtFreight_Currency.Enabled = false;
                txtFreight_Rate.Enabled = false;
                //txtFreight_Charges.Enabled = false;

                txtInsurance_Exch_Rate.Enabled = true;
                txtInsurance_Currency.Enabled = true;
                txtInsurance_Rate.Enabled = true;
                //txtInsurance_Charges.Enabled = true;
                if (txtInsurance_Rate.Text != "0" && txtInsurance_Rate.Text != "0.00" && txtInsurance_Rate.Text != "")
                {

                    txtInsurance_Rate.Enabled = true;
                    txtInsurance_Charges.Enabled = false;
                }
                else
                {

                    txtInsurance_Rate.Enabled = true;
                    txtInsurance_Charges.Enabled = true;
                }
                txtFreight_Exch_Rate.Text = "";
                txtFreight_Currency.Text = "";
                txtFreight_Rate.Text = "";
                txtFreight_Charges.Text = "";
            }
            else if (ddlTerms.SelectedValue == "CIF")
            {
                txtFreight_Rate.Enabled = false;
                txtFreight_Charges.Enabled = false;
                txtInsurance_Rate.Enabled = false;
                txtInsurance_Charges.Enabled = false;
            }
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {

        hdn_INVOICE_SLNO.Value = "";
        hdn_grid_edit.Value = "0";

        if (gv_Invoice.Rows.Count > 0)
        {

            if (gv_Invoice.Rows[0].Cells[8].Text.Replace("&nbsp;", "") == "S")
            {
                //------------SINGLE INVOICE---------//
                btn_New_Invoice();
                chkMisc.Enabled = false;
                ddlterms_clear();
                ddlTerms.Enabled = true;
                chkMisc.Checked = false;
                txtFreight_Exch_Rate.Enabled = true;
                txtFreight_Currency.Enabled = true;
                txtFreight_Rate.Enabled = true;

                txtInsurance_Exch_Rate.Enabled = true;
                txtInsurance_Currency.Enabled = true;
                txtInsurance_Rate.Enabled = true;
                pnl_Multi_Invoice.Enabled = true;
            }
            else
            {

                //------------MUITI INVOICE---------//

                btn_New_Invoice();
                chkMisc.Enabled = false;
                ddlTerms.Enabled = false;
                chkMisc.Checked = true;
                pnl_Multi_Invoice.Enabled = false;
                if (chkMisc.Checked == true)
                {
                    txtFreight_Rate.Text = hdn_Freight_Rate.Value;
                    txtInsurance_Rate.Text = hdn_Insurance_Rate.Value;
                    if (hdn_Freight_Rate.Value == "")
                        txtFreight_Rate.Text = "0.00";
                    if (hdn_Insurance_Rate.Value == "")
                        txtInsurance_Rate.Text = "0.00";

                    txtFreight_Charges.Text = "0.00";
                    txtInsurance_Charges.Text = "0.00";


                }
                else
                {
                    txtFreight_Rate.Text = "20.0000";
                    txtInsurance_Rate.Text = "1.1250";
                }
            }
            Supplier_SVB_details_Bind();
        }
        else
        {
            btn_New_Invoice();
            ddlTerms.Enabled = true;
            chkMisc.Checked = false;
            chkMisc.Enabled = true;
            txtFreight_Exch_Rate.Enabled = true;
            txtFreight_Currency.Enabled = true;
            txtFreight_Rate.Enabled = true;

            txtInsurance_Exch_Rate.Enabled = true;
            txtInsurance_Currency.Enabled = true;
            txtInsurance_Rate.Enabled = true;
            pnl_Multi_Invoice.Enabled = true;

        }
        //Get_ProductValue();
        //Load_ddlDropdown_Custom_house();

    }
    public void Supplier_SVB_details_Bind()
    {
        //------------Supplier bind------------//
        txtInvoiceCurrency.Text = gv_Invoice.Rows[0].Cells[7].Text.ToUpper().Replace("&nbsp;", "");
        txtExRate.Text = gv_Invoice.Rows[0].Cells[78].Text.Replace("&nbsp;", "");

        txtSupplierName.Text = gv_Invoice.Rows[0].Cells[9].Text.Replace("&nbsp;", "");
        txtSupplierAddress.Text = gv_Invoice.Rows[0].Cells[10].Text.Replace("&nbsp;", "");

        txtSupplierAddress1.Text = gv_Invoice.Rows[0].Cells[11].Text.Replace("&nbsp;", "");

        txtSupplierAddress2.Text = gv_Invoice.Rows[0].Cells[12].Text.Replace("&nbsp;", "");
        txtSupplierCountryName.Text = gv_Invoice.Rows[0].Cells[13].Text.Replace("&nbsp;", "");
        hfdsupplier_countrycode.Value = gv_Invoice.Rows[0].Cells[14].Text.Replace("&nbsp;", "");
        txtSuppliercountry_pincode.Text = gv_Invoice.Rows[0].Cells[15].Text.Replace("&nbsp;", "");
        txtSellerName.Text = gv_Invoice.Rows[0].Cells[16].Text.Replace("&nbsp;", "");
        txtSellerAddress.Text = gv_Invoice.Rows[0].Cells[17].Text.Replace("&nbsp;", "");
        txtSellerAddress1.Text = gv_Invoice.Rows[0].Cells[18].Text.Replace("&nbsp;", "");
        txtSellerAddress2.Text = gv_Invoice.Rows[0].Cells[19].Text.Replace("&nbsp;", "");
        txtSellerCountryName.Text = gv_Invoice.Rows[0].Cells[20].Text.Replace("&nbsp;", "");
        hfdseller_countrycode.Value = gv_Invoice.Rows[0].Cells[21].Text.Replace("&nbsp;", "");
        txtSellercountry_pincode.Text = gv_Invoice.Rows[0].Cells[22].Text.Replace("&nbsp;", "");
        txtBrokerName.Text = gv_Invoice.Rows[0].Cells[23].Text.Replace("&nbsp;", "");
        txtBrokerAddress.Text = gv_Invoice.Rows[0].Cells[24].Text.Replace("&nbsp;", "");
        txtBrokerAddress1.Text = gv_Invoice.Rows[0].Cells[25].Text.Replace("&nbsp;", "");
        txtBrokerAddress2.Text = gv_Invoice.Rows[0].Cells[26].Text.Replace("&nbsp;", "");
        txtBrokerCountryName.Text = gv_Invoice.Rows[0].Cells[27].Text.Replace("&nbsp;", "");
        hfdbroker_countrycode.Value = gv_Invoice.Rows[0].Cells[28].Text.Replace("&nbsp;", "");
        txtbrokercountry_pincode.Text = gv_Invoice.Rows[0].Cells[29].Text.Replace("&nbsp;", "");

        //------------Supplier bind------------//

        //---------SVB bind-----

        string chksvb = gv_Invoice.Rows[0].Cells[59].Text.Replace("&nbsp;", "");
        if (chksvb == "Y")
        {
            chkSVB_Relation.Checked = true;
            txtSVB_RefNo.Enabled = true;
            txtSVBDate.Enabled = true;
            //ddlSVB_CustomHouse.Enabled = true;
            txtCustomsHouse.Enabled =true;

            ddlLoadingOn.Enabled = true;
            //txtAssesable_Rate.Enabled = true;
            //txtDuty_Rate.Enabled = true;
            //ddlAssesable_Status.Enabled = true;
            //ddlDuty_Status.Enabled = true;
        }
        else
        {
            chkSVB_Relation.Checked = false;

        }

        txtSVB_RefNo.Text = gv_Invoice.Rows[0].Cells[60].Text.Replace("&nbsp;", "");
        txtSVBDate.Text = gv_Invoice.Rows[0].Cells[77].Text.Replace("01/01/1900", "");

        string SVB_CustomHouse = gv_Invoice.Rows[0].Cells[61].Text.Replace("&nbsp;", "");
        //Load_ddlDropdown_Custom_house();
        //ddlSVB_CustomHouse.Items.Remove(SVB_CustomHouse);
        //ddlSVB_CustomHouse.Items.Insert(0, SVB_CustomHouse);
        //ddlLoadingOn.Items.Clear();
        txtCustomsHouse.Text = SVB_CustomHouse;
        LoadingOn = gv_Invoice.Rows[0].Cells[62].Text.Replace("&nbsp;", "");
        string load_on = "";
        if (LoadingOn == "A")
        {
            load_on = "Assessable";

            txtAssesable_Rate.Enabled = true;

            ddlAssesable_Status.Enabled = true;


        }
        else if (LoadingOn == "D")
        {
            load_on = "Duty";
            txtDuty_Rate.Enabled = true;
            ddlDuty_Status.Enabled = true;
        }
        else if (LoadingOn == "B")
        {
            load_on = "Both";
        }
        ddlLoadingOn.Items.Clear();
        ddlLoading_On();
        ddlLoadingOn.Items.Remove(load_on);
        ddlLoadingOn.Items.Insert(0, load_on);
        txtAssesable_Rate.Text = gv_Invoice.Rows[0].Cells[63].Text.Replace("&nbsp;", "");
        txtDuty_Rate.Text = gv_Invoice.Rows[0].Cells[64].Text.Replace("&nbsp;", "");

        ddlAssesable_Status.Items.Clear();
        Ass_Status = gv_Invoice.Rows[0].Cells[65].Text.Replace("&nbsp;", "");
        string assesable = "";
        if (Ass_Status == "P")
        {
            assesable = "Provisional";
        }
        else if (Ass_Status == "F")
        {
            assesable = "Final";
        }


        ddlAssesableStatus();
        ddlAssesable_Status.Items.Remove(assesable);
        ddlAssesable_Status.Items.Insert(0, assesable);
        //ddlAssesable_Status.Items.Add(gv_Invoice.SelectedRow.Cells[64].Text.Replace("&nbsp;", ""));

        ddlDuty_Status.Items.Clear();
        Duty_Status = gv_Invoice.Rows[0].Cells[66].Text.Replace("&nbsp;", "");
        string duty_status = "";
        if (Duty_Status == "P")
        {
            duty_status = "Provisional";

        }
        else if (Duty_Status == "F")
        {
            duty_status = "Final";


        }

        ddlDutyStatus();
        ddlDuty_Status.Items.Remove(duty_status);
        ddlDuty_Status.Items.Insert(0, duty_status);
        //------------SVb bind------------//
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Call__Inv_Currency_Excahnge_Rate('" + txtInvoiceCurrency.ClientID + "', '" + txtExRate.ClientID + "')</script>", false);


    }
    public void Terms_clear_Total_freight_Insurance()
    {
        //hdn_Total_Freight_Value.Value = txtTotal_Frieght.Text;
        //hdn_Total_Insurance_Value.Value=txtTotal_Insurance.Text; 
        if (hdn_Invoice_mode_singlr_or_multi.Value == "M")
        {
            if (ddlTerms.SelectedValue == "FOB")
            {


                txtFreight_Rate.Enabled = false;
                txtInsurance_Rate.Enabled = false;
                tag_Totalfrieght.Style.Add("display", "block");
                tag_TotalInsurance.Style.Add("display", "block");
            }
            else if (ddlTerms.SelectedValue == "CI")
            {


                txtFreight_Rate.Enabled = false;
                tag_Totalfrieght.Style.Add("display", "block");
                tag_TotalInsurance.Style.Add("display", "none");
            }
            else if (ddlTerms.SelectedValue == "CF")
            {


                txtInsurance_Rate.Enabled = false;
                tag_Totalfrieght.Style.Add("display", "none");
                tag_TotalInsurance.Style.Add("display", "block");

            }
            else if (ddlTerms.SelectedValue == "CIF")
            {



            }
        }
        else if (hdn_Invoice_mode_singlr_or_multi.Value == "S")
        {
            if (ddlTerms.SelectedValue == "FOB")
            {


                txtFreight_Rate.Enabled = true;
                txtInsurance_Rate.Enabled = true;
                tag_Totalfrieght.Style.Add("display", "block");
                tag_TotalInsurance.Style.Add("display", "block");
            }
            else if (ddlTerms.SelectedValue == "CI")
            {


                txtFreight_Rate.Enabled = true;
                tag_Totalfrieght.Style.Add("display", "block");
                tag_TotalInsurance.Style.Add("display", "none");
            }
            else if (ddlTerms.SelectedValue == "CF")
            {


                txtInsurance_Rate.Enabled = true;
                tag_Totalfrieght.Style.Add("display", "none");
                tag_TotalInsurance.Style.Add("display", "block");

            }
            else if (ddlTerms.SelectedValue == "CIF")
            {



            }

        }
    }
    public void Terms_clear_Invoice_Updation()
    {
        //hdn_Total_Freight_Value.Value = txtTotal_Frieght.Text;
        //hdn_Total_Insurance_Value.Value=txtTotal_Insurance.Text; 
        if (hdn_Invoice_mode_singlr_or_multi.Value == "M")
        {
            if (ddlTerms.SelectedValue == "FOB")
            {


                txtFreight_Rate.Enabled = false;
                txtInsurance_Rate.Enabled = false;
                tag_Totalfrieght.Style.Add("display", "block");
                tag_TotalInsurance.Style.Add("display", "block");
            }
            else if (ddlTerms.SelectedValue == "CI")
            {


                txtFreight_Rate.Enabled = false;
                tag_Totalfrieght.Style.Add("display", "block");
                tag_TotalInsurance.Style.Add("display", "none");
            }
            else if (ddlTerms.SelectedValue == "CF")
            {


                txtInsurance_Rate.Enabled = false;
                tag_Totalfrieght.Style.Add("display", "none");
                tag_TotalInsurance.Style.Add("display", "block");

            }
            else if (ddlTerms.SelectedValue == "CIF")
            {



            }
        }
        else if (hdn_Invoice_mode_singlr_or_multi.Value == "S")
        {
            if (ddlTerms.SelectedValue == "FOB")
            {


                txtFreight_Rate.Enabled = true;
                txtInsurance_Rate.Enabled = true;
                tag_Totalfrieght.Style.Add("display", "block");
                tag_TotalInsurance.Style.Add("display", "block");
            }
            else if (ddlTerms.SelectedValue == "CI")
            {


                txtFreight_Rate.Enabled = true;
                tag_Totalfrieght.Style.Add("display", "block");
                tag_TotalInsurance.Style.Add("display", "none");
            }
            else if (ddlTerms.SelectedValue == "CF")
            {


                txtInsurance_Rate.Enabled = true;
                tag_Totalfrieght.Style.Add("display", "none");
                tag_TotalInsurance.Style.Add("display", "block");

            }
            else if (ddlTerms.SelectedValue == "CIF")
            {



            }

        }
    }
    public void btn_New_Invoice()
    {
        

        Terms_Change_Updating_MultiInvoice();
        Transact.ResetFields(Page.Controls);
        //txtFreight_Rate.Text = "20.0000";
        //txtInsurance_Rate.Text = "1.1250";
        //txtFreight_Charges.Text = "";
        //txtInsurance_Charges.Text = "";
        gridbind(inv_no, flag, TERMS, inv_slno);
        txtInvoiceNo.Focus();
        txtHighSeaSale_Currency.Text = "INR";
        txtHighSeaSale_Exch_Rate.Text = "1.00";
        txtHighSeaSale_Rate.Text = "0.00";




        tag_Totalfrieght.Style.Add("display", "none");
        tag_TotalInsurance.Style.Add("display", "none");
        txtTotal_Frieght.Enabled = false;
        txtTotal_Insurance.Enabled = false;
        txtFreight_Charges.Visible = true;
        txtInsurance_Charges.Visible = true;
        txtFreight_Charges.Enabled = false;
        txtInsurance_Charges.Enabled = false;
        txtTotal_Frieght.Text = txtTotal_Frieght.Text;
        txtTotal_Insurance.Text = txtTotal_Insurance.Text;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        ViewState["INVOICE_ID"] = null;

        get_Textboxvalue();
    }
    public void Terms_Change_Updating_MultiInvoice()
    {

        //////////----------------Terms Changing-----------------------------//////////////////
        double invoicevalue = 0.00;
        if (txtInvoiceValue.Text.Length > 0)
        {
            invoicevalue = Convert.ToDouble(txtInvoiceValue.Text);
        }
        else
        {
            invoicevalue = 0.00;
        }
        if (ddlTerms.SelectedValue == "FOB")
        {

            txtFreight_Exch_Rate.Enabled = true;
            txtFreight_Currency.Enabled = true;
            txtFreight_Rate.Enabled = true;

            txtInsurance_Exch_Rate.Enabled = true;
            txtInsurance_Currency.Enabled = true;
            txtInsurance_Rate.Enabled = true;
            hdn_FOB_Freight_Rate.Value = txtFreight_Rate.Text;
            hdn_FOB_Freight_Charge.Value = txtFreight_Charges.Text;
            hdn_FOB_Freight_Currency.Value = txtFreight_Currency.Text;
            hdn_FOB_Freight_ExRate.Value = txtFreight_Exch_Rate.Text;

            hdn_FOB_Insurance_Rate.Value = txtInsurance_Rate.Text;
            hdn_FOB_Insurance_Charge.Value = txtInsurance_Charges.Text;
            hdn_FOB_Insurance_Currency.Value = txtInsurance_Currency.Text;
            hdn_FOB_Insurance_ExRate.Value = txtInsurance_Exch_Rate.Text;

            hdn_CF_Insurance_Rate.Value = txtInsurance_Rate.Text;
            hdn_CF_Insurance_Charge.Value = txtInsurance_Charges.Text;
            hdn_CF_Insurance_Currency.Value = txtInsurance_Currency.Text;
            hdn_CF_Insurance_ExRate.Value = txtInsurance_Exch_Rate.Text;

            hdn_CI_Freight_Rate.Value = txtFreight_Rate.Text;
            hdn_CI_Freight_Charge.Value = txtFreight_Charges.Text;
            hdn_CI_Freight_Currency.Value = txtFreight_Currency.Text;
            hdn_CI_Freight_ExRate.Value = txtFreight_Exch_Rate.Text;

        }
        else if (ddlTerms.SelectedValue == "CI")
        {
            cal1 = invoicevalue * (1.125 / 100);

            hdn_FOB_Freight_Rate.Value = txtFreight_Rate.Text;
            hdn_FOB_Freight_Charge.Value = txtFreight_Charges.Text;
            hdn_FOB_Freight_Currency.Value = txtFreight_Currency.Text;
            hdn_FOB_Freight_ExRate.Value = txtFreight_Exch_Rate.Text;

            hdn_FOB_Insurance_Rate.Value = "1.1250";
            hdn_FOB_Insurance_Charge.Value = Convert.ToString(cal1);
            hdn_FOB_Insurance_Currency.Value = txtInvoiceCurrency.Text;
            hdn_FOB_Insurance_ExRate.Value = txtExRate.Text;

            hdn_CI_Freight_Rate.Value = txtFreight_Rate.Text;
            hdn_CI_Freight_Charge.Value = txtFreight_Charges.Text;
            hdn_CI_Freight_Currency.Value = txtFreight_Currency.Text;
            hdn_CI_Freight_ExRate.Value = txtFreight_Exch_Rate.Text;


            hdn_CF_Insurance_Rate.Value = "1.1250";
            hdn_CF_Insurance_Charge.Value = Convert.ToString(cal1);
            hdn_CF_Insurance_Currency.Value = txtInvoiceCurrency.Text;
            hdn_CF_Insurance_ExRate.Value = txtExRate.Text;


            txtFreight_Exch_Rate.Enabled = true;
            txtFreight_Currency.Enabled = true;
            txtFreight_Rate.Enabled = true;

            txtInsurance_Exch_Rate.Enabled = false;
            txtInsurance_Currency.Enabled = false;
            txtInsurance_Rate.Enabled = false;


            txtInsurance_Exch_Rate.Text = null;
            txtInsurance_Currency.Text = null;
            txtInsurance_Rate.Text = null;
            txtInsurance_Charges.Text = null;


        }
        else if (ddlTerms.SelectedValue == "CF")
        {
            cal = invoicevalue * 20 / 100;

            hdn_FOB_Freight_Rate.Value = "20.0000";
            hdn_FOB_Freight_Charge.Value = Convert.ToString(cal);
            hdn_FOB_Freight_Currency.Value = txtInvoiceCurrency.Text;
            hdn_FOB_Freight_ExRate.Value = txtExRate.Text;

            hdn_FOB_Insurance_Rate.Value = txtInsurance_Rate.Text;
            hdn_FOB_Insurance_Charge.Value = txtInsurance_Charges.Text;
            hdn_FOB_Insurance_Currency.Value = txtInsurance_Currency.Text;
            hdn_FOB_Insurance_ExRate.Value = txtInsurance_Exch_Rate.Text;

            hdn_CF_Insurance_Rate.Value = txtInsurance_Rate.Text;
            hdn_CF_Insurance_Charge.Value = txtInsurance_Charges.Text;
            hdn_CF_Insurance_Currency.Value = txtInsurance_Currency.Text;
            hdn_CF_Insurance_ExRate.Value = txtInsurance_Exch_Rate.Text;

            hdn_CI_Freight_Rate.Value = "20.0000";

            hdn_CI_Freight_Charge.Value = Convert.ToString(cal);
            hdn_CI_Freight_Currency.Value = txtInvoiceCurrency.Text;
            hdn_CI_Freight_ExRate.Value = txtExRate.Text;


            txtInsurance_Exch_Rate.Enabled = true;
            txtInsurance_Currency.Enabled = true;
            txtInsurance_Rate.Enabled = true;

            txtFreight_Exch_Rate.Enabled = false;
            txtFreight_Currency.Enabled = false;
            txtFreight_Rate.Enabled = false;



            txtFreight_Exch_Rate.Text = null;
            txtFreight_Currency.Text = null;
            txtFreight_Rate.Text = null;
            txtFreight_Charges.Text = null;

        }
        else if (ddlTerms.SelectedValue == "CIF")
        {

            hdn_CI_Freight_Rate.Value = "20.0000";
            cal = invoicevalue * 20 / 100;
            hdn_CI_Freight_Charge.Value = Convert.ToString(cal);
            hdn_CI_Freight_Currency.Value = txtInvoiceCurrency.Text;
            hdn_CI_Freight_ExRate.Value = txtExRate.Text;


            cal1 = invoicevalue * (1.125 / 100);
            hdn_CF_Insurance_Rate.Value = "1.1250";
            hdn_CF_Insurance_Charge.Value = Convert.ToString(cal1);
            hdn_CF_Insurance_Currency.Value = txtInvoiceCurrency.Text;
            hdn_CF_Insurance_ExRate.Value = txtExRate.Text;


            hdn_FOB_Freight_Rate.Value = "20.0000";
            hdn_FOB_Freight_Charge.Value = Convert.ToString(cal);
            hdn_FOB_Freight_Currency.Value = txtInvoiceCurrency.Text;
            hdn_FOB_Freight_ExRate.Value = txtExRate.Text;

            hdn_FOB_Insurance_Rate.Value = "1.1250";
            hdn_FOB_Insurance_Charge.Value = Convert.ToString(cal1);
            hdn_FOB_Insurance_Currency.Value = txtInvoiceCurrency.Text;
            hdn_FOB_Insurance_ExRate.Value = txtExRate.Text;

            //-----------------freight----------------//

            txtFreight_Exch_Rate.Enabled = false;
            txtFreight_Currency.Enabled = false;
            txtFreight_Rate.Enabled = false;
            //txtFreight_Charges.Enabled = false;


            //txtInsurance_Charges.Enabled = true;
            txtFreight_Exch_Rate.Text = null;
            txtFreight_Currency.Text = null;
            txtFreight_Rate.Text = null;
            txtFreight_Charges.Text = null;
            //-----------------insurance----------------//
            txtInsurance_Exch_Rate.Enabled = false;
            txtInsurance_Currency.Enabled = false;
            txtInsurance_Rate.Enabled = false;
            //txtInsurance_Charges.Enabled = false;

            txtInsurance_Exch_Rate.Text = null;
            txtInsurance_Currency.Text = null;
            txtInsurance_Rate.Text = null;
            txtInsurance_Charges.Text = null;


        }
        if (gv_Invoice.Rows.Count > 0)
        {
            if (gv_Invoice.Rows.Count == 1)
            {
                hdn_grid_count.Value = "1";
                tag_Totalfrieght.Style.Add("display", "none");
                tag_TotalInsurance.Style.Add("display", "none");
                tag_Totalfrieght.Visible = false;
                tag_TotalInsurance.Visible = false;

            }
            if (gv_Invoice.Rows.Count > 0)
            {
                hdn_grid_count.Value = Convert.ToString(gv_Invoice.Rows.Count);

            }
            else
                hdn_grid_count.Value = "0";
        }
        else
            hdn_grid_count.Value = "0";
        //////////----------------Terms Changing-----------------------------//////////////////

    }
    public void Get_ProductValue()
    {
        Transact.JOBNO = IMPORT_JOBNO;

        Transact.INVOICE_SLNO = "0";
        Transact.ITEM_SLNO = "0";
        Transact.ITEM_ID = "0";

      
        Transact.INVOICE_NO = lblInvoiceNo.Text;
        
        Transact.WORKING_PERIOD = Working_Period;
        //Transact.flag = "";

        Transact.Ename = "product_value";
        Transact.RetrieveAll_Item_Details();
        if (Transact.TOTAL_ITEM_VALUE != "")
        {

            lblProductValue.Text = Transact.TOTAL_ITEM_VALUE;


        }
        else
        {
            lblProductValue.Text = "";

        }
        


    }
    public void Load_ddlDropdown_Custom_house()
    {

        // Transact.WORKING_PERIOD = Working_Period;
        adminmaster adm = new adminmaster();
        Transact.Ename = "select_con";
        //ddlSVB_CustomHouse.DataSource = adm.RetrieveAll_SVB_CUSTOM_HOUSE_Details();
        //ddlSVB_CustomHouse.DataTextField = "CUSTOM_NAME";
        //ddlSVB_CustomHouse.DataValueField = "CUSTOM_NAME";
        
        //ddlSVB_CustomHouse.DataBind();
        string empty = "";
        //ddlSVB_CustomHouse.Items.Remove(empty);
        //ddlSVB_CustomHouse.Items.Insert(0, empty);
    }
    protected void gv_Invoice_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //  if Read Permiision given true for gridview enabled or Disabled----------//

            if (hdn_Grid_Disable.Value == "1")
            {

                e.Row.Enabled = false;

            }
            else
            {
                e.Row.Enabled = true;

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Invoice, "Select$" + e.Row.RowIndex.ToString()));


            }
            //  if Read Permiision given true for gridview enabled or Disabled----------//

            string MINDATE = "01/01/1900";
          
            if (e.Row.Cells[3].Text == MINDATE)
            {
                if (Convert.ToDateTime(e.Row.Cells[3].Text) <= Convert.ToDateTime(MINDATE))
                    e.Row.Cells[3].Text = string.Empty;
            }


        }

    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gv_Invoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Invoice.PageIndex = e.NewPageIndex;
        gridbind(inv_no, flag, TERMS, inv_slno);

    }
    public void gridbind1()
    {

        if (dtuser.Tables.Count > 0)
        {
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                gv_Invoice.DataSource = dtuser;

                gv_Invoice.DataBind();

            }
            else
            {
                gv_Invoice.DataSource = dt;//add empty row

                gv_Invoice.DataBind();


            }

        }
        else
        {
            gv_Invoice.DataSource = dt;//add empty row

            gv_Invoice.DataBind();


        }


    }
    public void gridbind(string inv_no, string flag, string TERMS, string inv_slno)
    {
        hdn_INVOICE_SLNO.Value = "";

        Transact.JOBNO = IMPORT_JOBNO;
        Transact.INVOICE_NO = inv_no;


        Transact.WORKING_PERIOD = Working_Period;
        Transact.flag = flag;
        Transact.TERMS = TERMS;
        Transact.INVOICE_SLNO = inv_slno;


        dss = Transact.RetrieveAll_Invoice_Details();

        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {

                gv_Invoice.DataSource = dss;
                gv_Invoice.DataBind();
                ////txtTotal_Frieght.Text = Convert.ToString(Transact.ALL_FREIGHT_TOTAL);
                ////txtTotal_Insurance.Text = Convert.ToString(Transact.ALL_INSURANCE_TOTAL);
                hdn_Total_Freight_Value.Value = Convert.ToString(Transact.ALL_FREIGHT_TOTAL);
                hdn_Total_Insurance_Value.Value = Convert.ToString(Transact.ALL_INSURANCE_TOTAL);

                flag = dss.Tables[0].Rows[0]["TERMS"].ToString();
                singlemultiple = dss.Tables[0].Rows[0]["MIS_SINGLE_OR_MULITIPLE"].ToString();
                if (singlemultiple == "M")
                {
                    txtMiscellaneous_Charges.Text = dss.Tables[0].Rows[0]["MIS_CHARGES"].ToString();
                    txtMiscellaneous_Rate.Text = dss.Tables[0].Rows[0]["MIS_RATE"].ToString();
                    txtMiscellaneous_Currency.Text = dss.Tables[0].Rows[0]["MIS_CURRENCY"].ToString();
                    txtMiscellaneous_Exch_Rate.Text = dss.Tables[0].Rows[0]["MIS_EXRATE"].ToString();
                    txtAgency_Charges.Text = dss.Tables[0].Rows[0]["MIS_AGENCY_CHARGES"].ToString();
                    txtAgency_Rate.Text = dss.Tables[0].Rows[0]["MIS_AGENCY_RATE"].ToString();
                    txtAgency_Currency.Text = dss.Tables[0].Rows[0]["MIS_AGENCY_CURRENCY"].ToString();
                    txtAgency_Exch_Rate.Text = dss.Tables[0].Rows[0]["MIS_AGENCY_EXRATE"].ToString();
                    txtDiscount_Charges.Text = dss.Tables[0].Rows[0]["MIS_DISCOUNT_CHARGES"].ToString();
                    txtDiscount_Rate.Text = dss.Tables[0].Rows[0]["MIS_DISCOUNT_RATE"].ToString();
                    txtDiscount_Currency.Text = dss.Tables[0].Rows[0]["MIS_DISCOUNT_CURRENCY"].ToString();
                    txtDiscount_Exch_Rate.Text = dss.Tables[0].Rows[0]["MIS_DISCOUNT_EXRATE"].ToString();
                    txtDiscount_Reason.Text = dss.Tables[0].Rows[0]["MIS_DISCOUNT_REASON"].ToString();
                    txtLoading_Charges.Text = dss.Tables[0].Rows[0]["MIS_LOADING_CHARGES"].ToString();
                    txtLoading_Rate.Text = dss.Tables[0].Rows[0]["MIS_LOADING_RATE"].ToString();
                    txtLoading_Currency.Text = dss.Tables[0].Rows[0]["MIS_LOADING_CURRENCY"].ToString();
                    txtLoading_ExchRate.Text = dss.Tables[0].Rows[0]["MIS_LOADING_EXRATE"].ToString();
                    txtFreight_Charges.Text = dss.Tables[0].Rows[0]["MIS_FREIGHT_CHARGES"].ToString();

                    txtFreight_Rate.Text = dss.Tables[0].Rows[0]["MIS_FREIGHT_RATE"].ToString();
                    txtFreight_Currency.Text = dss.Tables[0].Rows[0]["MIS_FREIGHT_CURRENCY"].ToString();
                    txtFreight_Exch_Rate.Text = dss.Tables[0].Rows[0]["MIS_FREIGHT_EXRATE"].ToString();
                    txtInsurance_Charges.Text = dss.Tables[0].Rows[0]["MIS_INSURANCE_CHARGES"].ToString();
                    txtInsurance_Rate.Text = dss.Tables[0].Rows[0]["MIS_INSURANCE_RATE"].ToString();
                    txtInsurance_Currency.Text = dss.Tables[0].Rows[0]["MIS_INSURANCE_CURRENCY"].ToString();
                    txtInsurance_Exch_Rate.Text = dss.Tables[0].Rows[0]["MIS_INSURANCE_EXRATE"].ToString();
                    txtHighSeaSale_Charges.Text = dss.Tables[0].Rows[0]["MIS_HIGHSEASALE_CHARGES"].ToString();
                    txtHighSeaSale_Rate.Text = dss.Tables[0].Rows[0]["MIS_HIGHSEASALE_RATE"].ToString();
                    txtHighSeaSale_Currency.Text = dss.Tables[0].Rows[0]["MIS_HIGHSEASALE_CURRENCY"].ToString();
                    txtHighSeaSale_Exch_Rate.Text = dss.Tables[0].Rows[0]["MIS_HIGHSEASALE_EXRATE"].ToString();
                    txtExRate.Text = dss.Tables[0].Rows[0]["INVOICE_EXRATE"].ToString();
                    chkMisc.Checked = true;
                    chkMisc.Enabled = false;
                    //txtFreight_Charges.Text = Convert.ToString(Transact.ALL_FREIGHT_TOTAL);
                    //txtInsurance_Charges.Text = Convert.ToString(Transact.ALL_INSURANCE_TOTAL);
                    txtFreight_Charges.Enabled = false;
                    txtInsurance_Charges.Enabled = false;
                    //ddlTerms.Enabled = false;
                    ddlTerms.Items.Clear();
                    ddlTerms.Items.Add(flag);
                    pnl_Multi_Invoice.Enabled = false;
                    Terms_Change_Updating_MultiInvoice();
                    txtFreight_Rate.Text = "0.00";
                    txtInsurance_Rate.Text = "0.00";
                }
                else
                {
                    chkMisc.Enabled = false;
                    txtFreight_Charges.Enabled = false;
                    txtInsurance_Charges.Enabled = false;
                    pnl_Multi_Invoice.Enabled = true;
                    Terms_Change_Updating_MultiInvoice();
                }
                //ddlTerms.Enabled = false;
                //ddlTerms.Items.Clear();
                //ddlTerms.Items.Add(flag);
                Supplier_SVB_details_Bind();

            }
            else
            {
                ddlterms_clear();
                gv_Invoice.DataSource = dt;//add empty row

                gv_Invoice.DataBind();
                pnl_Multi_Invoice.Enabled = true;
                Terms_Change_Updating_MultiInvoice();

            }



        }
        else
        {
            ddlterms_clear();
            gv_Invoice.DataSource = dt;//add empty row

            gv_Invoice.DataBind();
            pnl_Multi_Invoice.Enabled = true;
            Terms_Change_Updating_MultiInvoice();

        }



    }
    public void insert_or_update()
    {
        string chkmis = "";
        if (chkMisc.Checked == true)
        {
            chkmis = "M";
        }
        else
        {
            chkmis = "S";
        }


        if (txtDate.Text == "")
        {
            INV_DATE = "01/01/1900";
        }
        else
        {
            INV_DATE = txtDate.Text;
        }

        if (txtPurchaseDate.Text == "")
        {
            PURCHASE_DATE = "01/01/1900";
        }
        else
        {
            PURCHASE_DATE = txtPurchaseDate.Text;
        }
        if (txtContractDate.Text == "")
        {
            CONTRACT_DATE = "01/01/1900";
        }
        else
        {
            CONTRACT_DATE = txtContractDate.Text;
        }
        if (txtLCDate.Text == "")
        {
            LC_DATE = "01/01/1900";
        }
        else
        {
            LC_DATE = txtLCDate.Text;
        }

        if (txtSVBDate.Text == "")
        {
            SVB_DATE = "01/01/1900";
        }
        else
        {
            SVB_DATE = txtSVBDate.Text;
        }

        if (chkMisc.Checked == true)
        {

            // dtuser = insert_update(a1, a2, a3, a4, a5, a6, chkmis);
            gv_Invoice.DataSource = insert_update(a1, a2, a3, a4, a5, a6, chkmis);

            gv_Invoice.DataBind();
            if (Transact.result != 2)
            {
                if (ddlTerms.SelectedValue == "FOB")
                {
                    txtFreight_Charges.Enabled = false;
                    txtInsurance_Charges.Enabled = false;
                    txtFreight_Rate.Enabled = false;
                    txtInsurance_Rate.Enabled = false;
                    //chkMisc.Enabled = false;
                    //txtFreight_Charges.Text = Convert.ToString(Math.Round(Transact.ALL_FREIGHT_TOTAL));
                    //txtInsurance_Charges.Text = Convert.ToString(Math.Round(Transact.ALL_INSURANCE_TOTAL));
                    hdn_Total_Freight_Value.Value = Convert.ToString(Transact.ALL_FREIGHT_TOTAL);
                    hdn_Total_Insurance_Value.Value = Convert.ToString(Transact.ALL_INSURANCE_TOTAL);

                }
                else if (ddlTerms.SelectedValue == "CI")
                {
                    txtFreight_Charges.Enabled = true;
                    txtInsurance_Charges.Enabled = false;
                    txtFreight_Rate.Enabled = true;
                    txtInsurance_Rate.Enabled = false;
                    //txtFreight_Charges.Text = Convert.ToString(Math.Round(Transact.ALL_FREIGHT_TOTAL));
                    hdn_Total_Freight_Value.Value = Convert.ToString(Transact.ALL_FREIGHT_TOTAL);
                   
                }
                else if (ddlTerms.SelectedValue == "CF")
                {
                    txtFreight_Charges.Enabled = false;
                    txtInsurance_Charges.Enabled = true;
                    txtFreight_Rate.Enabled = false;
                    txtInsurance_Rate.Enabled = true;
                    //txtInsurance_Charges.Text = Convert.ToString(Math.Round(Transact.ALL_INSURANCE_TOTAL));
                    hdn_Total_Insurance_Value.Value = Convert.ToString(Transact.ALL_INSURANCE_TOTAL);


                }
                else
                {

                }

            }
            pnl_Multi_Invoice.Enabled = false;
        }
        else
        {

            gv_Invoice.DataSource = insert_update(a1, a2, a3, a4, a5, a6, chkmis);

            gv_Invoice.DataBind();
            get_Textboxvalue();
            pnl_Multi_Invoice.Enabled = true;

        }
        i = Transact.result;
        string ddlterms = ddlTerms.SelectedValue.ToString();
        ddlterms_clear();
        ddlTerms.Items.Remove(ddlterms);
        ddlTerms.Items.Insert(0, ddlterms);

        //gridbind1();


    }
   
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>document.getElementById('IMD').click();</script>", false);

        txtFreight_Rate.Text = hdn_Freight_Rate.Value;
        txtInsurance_Rate.Text = hdn_Insurance_Rate.Value;
        try
        {
            a1 = ViewState["INVOICE_ID"].ToString();
            a2 = "U";
            a3 = "";
            a4 = Session["INV_SLNO"].ToString();
            _slno = Session["_SLNO"].ToString();
            if (hdn_Invoice_mode_singlr_or_multi.Value != "")
            {
                if (hdn_Invoice_mode_singlr_or_multi.Value == "M")
                {

                    if (chkMisc.Checked == true)
                    {
                        //--------------UPDATE MULTIPLE TO MULTIPLE INVOICE----------//
                        chkMisc.Enabled = false;
                        a5 = txtTotal_Frieght.Text;
                        a6 = txtTotal_Insurance.Text;
                        Terms_clear_Total_freight_Insurance();
                        //--------------UPDATE MULTIPLE TO MULTIPLE INVOICE----------//
                    }

                    else
                    {

                        //--------------UPDATE AND CONVERT MULTIPLE TO SINGLE INVOICE----------//

                        chkMisc.Enabled = false;
                        txtFreight_Charges.Text = hdn_freight_value.Value;
                        txtInsurance_Charges.Text = hdn_insurance_value.Value;
                        a5 = txtFreight_Charges.Text;

                        a6 = txtInsurance_Charges.Text;
                        //--------------UPDATE AND CONVERT MULTIPLE TO SINGLE INVOICE----------//
                    }

                }
                else
                {
                    if (chkMisc.Checked == false)
                    {
                        //--------------UPDATE SINGLE TO SINGLE INVOICE----------//
                        chkMisc.Enabled = true;
                        txtFreight_Charges.Text = hdn_freight_value.Value;
                        txtInsurance_Charges.Text = hdn_insurance_value.Value;
                        a5 = txtFreight_Charges.Text;
                        a6 = txtInsurance_Charges.Text;
                        //--------------UPDATE SINGLE TO SINGLE INVOICE----------//
                    }

                    else
                    {

                        //--------------UPDATE AND CONVERT SINGLE TO MULTIPLE INVOICE----------//

                        chkMisc.Enabled = true;
                        txtFreight_Charges.Text = hdn_freight_value.Value;
                        txtInsurance_Charges.Text = hdn_insurance_value.Value;
                        //string f="",ins="";
                        //if (txtFreight_Charges.Text == "")
                        //{
                        //    f = "0.00";
                        //}
                        //else
                        //    f = txtFreight_Charges.Text;
                        //if (txtInsurance_Charges.Text == "")
                        //{
                        //    ins = "0.00";
                        //}
                        //else
                        //{
                        //    ins = txtInsurance_Charges.Text;
                        //}
                        a5 = txtFreight_Charges.Text;
                        a6 = txtInsurance_Charges.Text;

                        Terms_clear_Total_freight_Insurance();
                        //--------------UPDATE AND CONVERT SINGLE TO MULTIPLE INVOICE----------//
                    }
                }

            }
            //if (chkMisc.Checked == true)
            //{
            //    chkMisc.Enabled = false;
            //    a5 = txtTotal_Frieght.Text;
            //    a6 = txtTotal_Insurance.Text;
            //}
            //else
            //{
            //    chkMisc.Enabled = true;
            //    txtFreight_Charges.Text = hdn_freight_value.Value;
            //    txtInsurance_Charges.Text = hdn_insurance_value.Value;
            //    a5 = txtFreight_Charges.Text;
            //    a6 = txtInsurance_Charges.Text;

            //}

            insert_or_update();
            if (i == 1)
            {
                _slno = Session["_SLNO"].ToString();
                Invoice_Updation1(_slno);
                //Invoice_Updation(_slno);
                //mo.ResetFields(Page.Controls);
                //TabContainer1.ActiveTabIndex = 0;
                //txtFreight_Charges.Text = txtTotal_Frieght.Text;
                //txtInsurance_Charges.Text = txtTotal_Insurance.Text;
                txtInvoiceNo.Focus();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record  Saved')</script>", false);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>get_value();dropdown_change();</script>", false);
                hdn_button_click.Value = "";
                Alert_msg("Invoice Updated Successfully", "btnSave");


            }
            else if (i == 2)
            {

                //TabContainer1.ActiveTabIndex = 0;
                Terms_Change_Updating_MultiInvoice();

                txtInvoiceNo.Focus();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Saved, Invoice No Already Exist')</script>", false);
                Alert_msg("Invoice No Already Exist!", "btnSave");


            }
            else if (i == 4)
            {
                Terms_Change_Updating_MultiInvoice();

                //TabContainer1.ActiveTabIndex = 0;
                txtInvoiceNo.Focus();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Do you Want to Change Multiple to Single Invoice, Remove All Other Invoices Except First Invoice No.')</script>", false);
                Alert_msg("Do you Want to Modify Multiple to Single Invoice? Remove All Invoices Except First Invoice No.", "btnSave");


            }


            else
            {
                //TabContainer1.ActiveTabIndex = 0;

                txtInvoiceNo.Focus();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                Alert_msg("Not Updated", "btnSave");



            }
            if (i != 1)
            {
                if (hdn_Invoice_mode_singlr_or_multi.Value != "")
                {
                    if (hdn_Invoice_mode_singlr_or_multi.Value == "M")
                    {
                        if (Int32.Parse(_slno) == 1)
                        {
                            chkMisc.Checked = true;
                            chkMisc.Enabled = true;

                        }
                        else
                        {
                            chkMisc.Checked = true;
                            chkMisc.Enabled = false;

                        }
                    }
                    else
                        chkMisc.Checked = false;

                }
            }



        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>document.getElementById('IMD').click();</script>", false);

        if (Session["INV_SLNO"] != null)
        {
            string flag = "Delete";
            gridbind(txtInvoiceNo.Text, flag, ddlTerms.SelectedValue.ToString(), Session["INV_SLNO"].ToString());
            i = Transact.result;


            if (i == 1)
            {
                btnNew_Click(sender, e);
                hdn_INVOICE_SLNO.Value = "";
                //lblMsg.Text = " Record Deleted";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                ddlterms_clear();
                get_Textboxvalue();

                Alert_msg("Invoice Deleted", "btnSave");

            }
            else
            {
                Terms_Change_Updating_MultiInvoice();

                //lblMsg.Text = " Record Not Deleted";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);
                Alert_msg("Invoice Not Deleted", "btnSave");

            }


        }
    }
    public void Grid_Empty()
    {
        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                gv_Invoice.DataSource = dss;

                gv_Invoice.DataBind();
            }
            else
            {
                gv_Invoice.DataSource = dt;//add empty row

                gv_Invoice.DataBind();
            }

        }
        else
        {
            gv_Invoice.DataSource = dt;//add empty row

            gv_Invoice.DataBind();

        }
    }
    protected void txtInvoiceValue_TextChanged(object sender, EventArgs e)
    {
        if (txtInvoiceValue.Text != "")
        {
            txtFreight_Rate.Text = "20.0000";
            //double cal, cal1;
            double invoicevalue = Convert.ToDouble(txtInvoiceValue.Text);
            cal = invoicevalue * 20 / 100;

            txtFreight_Charges.Text = Convert.ToString(cal);

            txtInsurance_Rate.Text = "1.1250";

            cal1 = invoicevalue * (1.125 / 100);

            txtInsurance_Charges.Text = Convert.ToString(cal1);



            //txtFreight_Charges.Enabled = true;
            txtFreight_Currency.Enabled = true;
            txtFreight_Exch_Rate.Enabled = true;
            txtFreight_Rate.Enabled = true;

            //txtInsurance_Charges.Enabled = true;

            txtInsurance_Currency.Enabled = true;

            txtInsurance_Exch_Rate.Enabled = true;

            txtInsurance_Rate.Enabled = true;
            if (txtInvoiceCurrency.Text != "")
            {
                txtInvoiceCurrency_TextChanged(sender, e);
            }
        }

    }
    protected void txtFreight_Exch_Rate_TextChanged(object sender, EventArgs e)
    {
        if (txtFreight_Exch_Rate.Text != "" && txtFreight_Exch_Rate.Text != "0")
        {

            //double cal, cal1;
            //double exch_cal, exch_cal1;
            //double invoicevalue = Convert.ToDouble(txtInvoiceValue.Text);
            //cal = invoicevalue * 20 / 100;

            //double Freight_ExRate = Convert.ToDouble(txtFreight_Exch_Rate.Text);
            //exch_cal = Freight_ExRate * cal;

            //txtFreight_Charges.Text = Convert.ToString(exch_cal);

            ////txtInsurance_Rate.Text = "1.125";

            ////cal1 = invoicevalue * (1.125 / 100);

            ////txtInsurance_Charges.Text = Convert.ToString(cal1);

        }
        else
        {
        }
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Misc_tab();</script>", false);

    }
    protected void txtInsurance_Exch_Rate_TextChanged(object sender, EventArgs e)
    {
        //if (txtFreight_Exch_Rate.Text != "" && txtInsurance_Exch_Rate.Text!="")
        //{

        //    double exch_cal;
        //    double invoicevalue = Convert.ToDouble(txtInvoiceValue.Text);
        //    cal = invoicevalue * 20 / 100;

        //    double Insurance_ExRate = Convert.ToDouble(txtInsurance_Exch_Rate.Text);
        //    exch_cal = Insurance_ExRate * cal;

        //    txtInsurance_Charges.Text = Convert.ToString(exch_cal);



        //}
        //else
        //{
        //}
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Misc_tab();</script>", false);

    }
    public void GET_CURCODE_EXCH_RATE(string Currency_Code)
    {

        erm.Invoice_Currency = Currency_Code;
        erm.Ename = "IMPORT_INVOICE_EX_RATE";
        erm.EWorking_Period = Working_Period;
        dss = erm.RetrieveAll_Exchange_master_INV_Currency();
        if (dss.Tables[0].Rows.Count > 0)
        {
            MISC_EXRATE = dss.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

            CURRENCY_CODE = dss.Tables[0].Rows[0]["EXCHANGE_CUR_CODE"].ToString();
        }
    }
    //public void GET_INSURANCE_EXCH_RATE()
    //{

    //    erm.Invoice_Currency = txtInsurance_Currency.Text;
    //    erm.Ename = "IMPORT_INVOICE_EX_RATE";
    //    erm.EWorking_Period = Working_Period;
    //    dss = erm.RetrieveAll_Exchange_master_INV_Currency();
    //    if (dss.Tables[0].Rows.Count > 0)
    //    {
    //        INSURANCE_EXRATE = dss.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

    //        CURRENCY_CODE = dss.Tables[0].Rows[0]["EXCHANGE_CUR_CODE"].ToString();
    //    }
    //}
    public void GET_INVOICE_CURCODE_EXCH_RATE()
    {

        //double cal, cal1;
        if (txtInvoiceValue.Text != "")
        {
            invoicevalue = Convert.ToDouble(txtInvoiceValue.Text);
            erm.Invoice_Currency = txtInvoiceCurrency.Text;
            //erm.Invoice_Currency = "USD";
            erm.Ename = "IMPORT_INVOICE_EX_RATE";
            erm.EWorking_Period = Working_Period;
            dss = erm.RetrieveAll_Exchange_master_INV_Currency();
            if (dss.Tables[0].Rows.Count > 0)
            {

                hdn_currency.Value = dss.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

            }
        }
    }
    protected void txtFreight_Currency_TextChanged(object sender, EventArgs e)
    {


        if (hdn_button_click.Value != "1")
        {

            if (txtFreight_Currency.Text.Length > 0)
            {
                Freight_Currency_Textchanged();
            }

        }
        else

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>document.getElementById('IMD').click();</script>", false);



    }
    protected void txtInsurance_Currency_TextChanged(object sender, EventArgs e)
    {
        if (hdn_button_click.Value != "1")
        {


            if (txtInsurance_Currency.Text.Length > 0)
            {
                Insurance_Currency_Textchanged();
            }

        }
        else

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>document.getElementById('IMD').click();</script>", false);

    }
    public void Freight_Currency_Textchanged()
    {
        string Freight_Cur = txtFreight_Currency.Text.ToUpper();

        GET_CURCODE_EXCH_RATE(Freight_Cur);

        txtFreight_Exch_Rate.Text = MISC_EXRATE;
        GET_INVOICE_CURCODE_EXCH_RATE();
        if (txtFreight_Currency.Text.ToUpper() == CURRENCY_CODE)
        {

            if (hdn_currency.Value != "")
            {
                double Invoice_Currency_Exrate = Convert.ToDouble(hdn_currency.Value);

                //if (txtInvoiceCurrency.Text == "INR" && txtFreight_Currency.Text == "USD")
                //{
                //cal = ((invoicevalue * 20 / 100) * Invoice_Currency_Exrate);
                cal = ((invoicevalue * 20 / 100) * Invoice_Currency_Exrate);
                double EXRATE = Convert.ToDouble(MISC_EXRATE);
                cal1 = Math.Round(cal / EXRATE, 2);

                txtFreight_Charges.Text = Convert.ToString(cal1);
                //}


            }
        }
        else
        {

            if (txtFreight_Exch_Rate.Text != "" && txtInvoiceCurrency.Text != "" && txtFreight_Exch_Rate.Text != "")
            {
                //double cal, cal1;
                //double exch_cal, exch_cal1;
                double invoicevalue = Convert.ToDouble(txtInvoiceValue.Text);
                double Invoice_Currency_Exrate = Convert.ToDouble(txtFreight_Exch_Rate.Text);
                cal = invoicevalue * 20 / 100;

                txtFreight_Charges.Text = Convert.ToString(cal);
                txtDiscount_Exch_Rate.Text = txtFreight_Exch_Rate.Text;
                txtFreight_Exch_Rate.Text = txtFreight_Exch_Rate.Text;
                txtInsurance_Exch_Rate.Text = txtFreight_Exch_Rate.Text;
            }
        }
        txtFreight_Rate.Text = hdn_Freight_Rate.Value;
        txtInsurance_Rate.Text = hdn_Insurance_Rate.Value;
        get_Textboxvalue();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Misc_tab();dropdown_change()</script>", false);

        //Terms_Based_Textbox_Enabled();

    }
    public void Insurance_Currency_Textchanged()
    {
        string Insurance_Cur = txtInsurance_Currency.Text.ToUpper();
        GET_CURCODE_EXCH_RATE(Insurance_Cur);
        txtInsurance_Exch_Rate.Text = MISC_EXRATE;
        GET_INVOICE_CURCODE_EXCH_RATE();
        if (txtInsurance_Currency.Text.ToUpper() == CURRENCY_CODE)
        {


            if (hdn_currency.Value != "")
            {
                double Invoice_Currency_Exrate = Convert.ToDouble(hdn_currency.Value);

                //if (txtInvoiceCurrency.Text == "INR" && txtFreight_Currency.Text == "USD")
                //{
                //cal = ((invoicevalue * 20 / 100) * Invoice_Currency_Exrate);
                cal = ((invoicevalue * 1.125 / 100) * Invoice_Currency_Exrate);
                double EXRATE = Convert.ToDouble(MISC_EXRATE);
                cal1 = Math.Round(cal / EXRATE, 2);

                txtInsurance_Charges.Text = Convert.ToString(cal1);
                //}


            }
        }
        else
        {

            if (txtInsurance_Exch_Rate.Text != "" && txtInvoiceValue.Text != "")
            {
                double cal, cal1;
                double exch_cal, exch_cal1;
                double invoicevalue = Convert.ToDouble(txtInvoiceValue.Text);
                double Invoice_Currency_Exrate = Convert.ToDouble(txtInsurance_Exch_Rate.Text);
                cal = invoicevalue * 1.1250 / 100;

                txtInsurance_Charges.Text = Convert.ToString(cal);
                txtDiscount_Exch_Rate.Text = txtFreight_Exch_Rate.Text;
                txtFreight_Exch_Rate.Text = txtFreight_Exch_Rate.Text;
                txtInsurance_Exch_Rate.Text = txtFreight_Exch_Rate.Text;
            }
        }
        txtFreight_Rate.Text = hdn_Freight_Rate.Value;
        txtInsurance_Rate.Text = hdn_Insurance_Rate.Value;
        get_Textboxvalue();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Misc_tab();dropdown_change()</script>", false);

    }
    protected void txtInvoiceCurrency_TextChanged(object sender, EventArgs e)
    {
        //if (ddlTerms.SelectedValue != "")
        //{
        // eroyalmaster erm = new eroyalmaster();
        adminmaster erm = new adminmaster();
        erm.Invoice_Currency = txtInvoiceCurrency.Text;
        erm.Ename = "IMPORT_INVOICE_EX_RATE";
        erm.EWorking_Period = Working_Period;
        dss = erm.RetrieveAll_Exchange_master_INV_Currency();
        if (dss.Tables[0].Rows.Count > 0)
        {

            hdn_Invoice_Currency_Exrate.Value = dss.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
            txtExRate.Text = hdn_Invoice_Currency_Exrate.Value;
            txtDiscount_Exch_Rate.Text = hdn_Invoice_Currency_Exrate.Value;
            txtFreight_Exch_Rate.Text = hdn_Invoice_Currency_Exrate.Value;
            txtInsurance_Exch_Rate.Text = hdn_Invoice_Currency_Exrate.Value;
            txtMiscellaneous_Exch_Rate.Text = hdn_Invoice_Currency_Exrate.Value;
            txtAgency_Exch_Rate.Text = hdn_Invoice_Currency_Exrate.Value; ;

            txtDiscount_Currency.Text = txtInvoiceCurrency.Text;
            txtFreight_Currency.Text = txtInvoiceCurrency.Text;
            txtInsurance_Currency.Text = txtInvoiceCurrency.Text;
            txtMiscellaneous_Currency.Text = txtInvoiceCurrency.Text;
            txtAgency_Currency.Text = txtInvoiceCurrency.Text;

            txtFreight_Currency.Enabled = true;
            txtFreight_Exch_Rate.Enabled = true;
            txtFreight_Rate.Enabled = true;

            txtInsurance_Charges.Enabled = true;

            txtInsurance_Currency.Enabled = true;

            txtInsurance_Exch_Rate.Enabled = true;

            txtInsurance_Rate.Enabled = true;
        }
        else
        {
            hdn_Invoice_Currency_Exrate.Value = "";
            txtDiscount_Exch_Rate.Text = hdn_Invoice_Currency_Exrate.Value;
            txtFreight_Exch_Rate.Text = hdn_Invoice_Currency_Exrate.Value;
            txtInsurance_Exch_Rate.Text = hdn_Invoice_Currency_Exrate.Value;

            txtDiscount_Currency.Text = "";
            txtFreight_Currency.Text = "";
            txtInsurance_Currency.Text = "";
        }
        //int i = Convert.ToInt32(txtFreight_Rate.Text);
        if (txtFreight_Rate.Text == "0")
        {
            txtFreight_Charges.Enabled = true;

        }
        else
        {
            txtFreight_Charges.Enabled = false;

        }

        if (txtInsurance_Rate.Text == "0")
        {
            txtInsurance_Charges.Enabled = true;
        }
        else
        {
            txtInsurance_Charges.Enabled = false;
        }
        //}
        //else
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Terms Cannot be empty');</script>", false);

    }
    protected void txtFreight_Rate_TextChanged(object sender, EventArgs e)
    {
        double Fri_Rate = 0;
        string f = "";
        if (txtFreight_Rate.Text == "")
        {
            f = "0";
        }
        else
        {
            f = txtFreight_Rate.Text;

        }
        Fri_Rate = Convert.ToDouble(f);

        if (Fri_Rate <= 0)
        {
            txtFreight_Charges.Enabled = true;

        }
        else
        {
            txtFreight_Charges.Enabled = false;
        }

        if (txtFreight_Rate.Text != "" && txtInvoiceValue.Text != "")
        {

            double cal;
            double invoicevalue = Convert.ToDouble(txtInvoiceValue.Text);
            double i = Convert.ToDouble(f);

            if (i != 0)
            {
                //cal = invoicevalue * i / 100;

                //txtFreight_Charges.Text = Convert.ToString(cal);

                //txtInsurance_Rate.Text = "1.125";

                //cal1 = invoicevalue * (1.125 / 100);

                //txtInsurance_Charges.Text = Convert.ToString(cal1);

                //if (txtFreight_Exch_Rate.Text != "")
                //{
                //cal2=Convert.ToDouble(txtFreight_Exch_Rate.Text);
                //cal2 = invoicevalue * (i/100);
                //txtFreight_Charges.Text = Convert.ToString(cal2);
                if (txtFreight_Currency.Text == "INR" && hdn_currency.Value != "")
                {
                    double Invoice_Currency_Exrate = Convert.ToDouble(hdn_currency.Value);

                    cal = ((invoicevalue * i / 100) * Invoice_Currency_Exrate);
                    txtFreight_Charges.Text = Convert.ToString(cal);

                }
                else
                {
                    cal = invoicevalue * (i / 100);

                    txtFreight_Charges.Text = Convert.ToString(cal);
                }


                //}

                //txtFreight_Charges.Enabled = true;
                txtFreight_Currency.Enabled = true;
                txtFreight_Exch_Rate.Enabled = true;
                //txtFreight_Rate.Enabled = true;

                //txtInsurance_Charges.Enabled = true;

                txtInsurance_Currency.Enabled = true;

                txtInsurance_Exch_Rate.Enabled = true;

                //txtInsurance_Rate.Enabled = true;
            }
        }
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Misc_tab();</script>", false);

    }
    protected void txtInsurance_Rate_TextChanged(object sender, EventArgs e)
    {
        if (txtInsurance_Rate.Text == "0")
        {
            txtInsurance_Charges.Enabled = true;

        }
        else
        {
            txtInsurance_Charges.Enabled = false;
        }

        if (txtInsurance_Rate.Text != "" && txtInvoiceValue.Text != "")
        {

            double cal, cal1, cal2;
            double invoicevalue = Convert.ToDouble(txtInvoiceValue.Text);
            double i = Convert.ToDouble(txtInsurance_Rate.Text);

            if (i != 0)
            {
                //cal = invoicevalue * i / 100;

                //txtFreight_Charges.Text = Convert.ToString(cal);

                //txtInsurance_Rate.Text = "1.125";

                //cal1 = invoicevalue * (1.125 / 100);

                //txtInsurance_Charges.Text = Convert.ToString(cal1);

                //if (txtFreight_Exch_Rate.Text != "")
                //{
                //cal2=Convert.ToDouble(txtFreight_Exch_Rate.Text);
                //cal2 = invoicevalue * (i/100);
                //txtFreight_Charges.Text = Convert.ToString(cal2);
                if (txtInsurance_Currency.Text == "INR" && hdn_currency.Value != "")
                {
                    double Invoice_Currency_Exrate = Convert.ToDouble(hdn_currency.Value);

                    cal = ((invoicevalue * i / 100) * Invoice_Currency_Exrate);
                    txtInsurance_Charges.Text = Convert.ToString(cal);

                }
                else
                {
                    cal = invoicevalue * (i / 100);

                    txtInsurance_Charges.Text = Convert.ToString(cal);
                }


                //}

                //txtFreight_Charges.Enabled = true;
                txtFreight_Currency.Enabled = true;
                txtFreight_Exch_Rate.Enabled = true;
                //txtFreight_Rate.Enabled = true;

                //txtInsurance_Charges.Enabled = true;

                txtInsurance_Currency.Enabled = true;

                txtInsurance_Exch_Rate.Enabled = true;

                //txtInsurance_Rate.Enabled = true;
            }
        }
        // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Misc_tab();</script>", false);

    }
    public void TextCopy()
    {
        lblInvoiceNo.Text = txtInvoiceNo.Text;
        lblInvoiceDate.Text = txtDate.Text;
        lblInvoiceCurrency.Text = txtInvoiceCurrency.Text.ToUpper();
        lblInvoiceTerms.Text = ddlTerms.SelectedValue.ToString();
        lblInvoiceValue.Text = txtInvoiceValue.Text;
    }
    public void get_Textboxvalue()
    {
        hdn_FOB_Freight_Rate.Value = txtFreight_Rate.Text;
        hdn_FOB_Freight_Charge.Value = txtFreight_Charges.Text;
        hdn_FOB_Freight_Currency.Value = txtFreight_Currency.Text;
        hdn_FOB_Freight_ExRate.Value = txtFreight_Exch_Rate.Text;

        hdn_FOB_Insurance_Rate.Value = txtInsurance_Rate.Text;
        hdn_FOB_Insurance_Charge.Value = txtInsurance_Charges.Text;
        hdn_FOB_Insurance_Currency.Value = txtInsurance_Currency.Text;
        hdn_FOB_Insurance_ExRate.Value = txtInsurance_Exch_Rate.Text;

        hdn_CI_Freight_Rate.Value = txtFreight_Rate.Text;
        hdn_CI_Freight_Charge.Value = txtFreight_Charges.Text;
        hdn_CI_Freight_Currency.Value = txtFreight_Currency.Text;
        hdn_CI_Freight_ExRate.Value = txtFreight_Exch_Rate.Text;

        hdn_CI_Insurance_Rate.Value = txtInsurance_Rate.Text;
        hdn_CI_Insurance_Charge.Value = txtInsurance_Charges.Text;
        hdn_CI_Insurance_Currency.Value = txtInsurance_Currency.Text;
        hdn_CI_Insurance_ExRate.Value = txtInsurance_Exch_Rate.Text;

        hdn_CF_Freight_Rate.Value = txtFreight_Rate.Text;
        hdn_CF_Freight_Charge.Value = txtFreight_Charges.Text;
        hdn_CF_Freight_Currency.Value = txtFreight_Currency.Text;
        hdn_CF_Freight_ExRate.Value = txtFreight_Exch_Rate.Text;

        hdn_CF_Insurance_Rate.Value = txtInsurance_Rate.Text;
        hdn_CF_Insurance_Charge.Value = txtInsurance_Charges.Text;
        hdn_CF_Insurance_Currency.Value = txtInsurance_Currency.Text;
        hdn_CF_Insurance_ExRate.Value = txtInsurance_Exch_Rate.Text;

        hdn_CIF_Freight_Rate.Value = txtFreight_Rate.Text;
        hdn_CIF_Freight_Charge.Value = txtFreight_Charges.Text;
        hdn_CIF_Freight_Currency.Value = txtFreight_Currency.Text;
        hdn_CIF_Freight_ExRate.Value = txtFreight_Exch_Rate.Text;

        hdn_CIF_Insurance_Rate.Value = txtInsurance_Rate.Text;
        hdn_CIF_Insurance_Charge.Value = txtInsurance_Charges.Text;
        hdn_CIF_Insurance_Currency.Value = txtInsurance_Currency.Text;
        hdn_CIF_Insurance_ExRate.Value = txtInsurance_Exch_Rate.Text;

    }
    public void Terms_Change_SingleInvoice()
    {
       
        if (ddlTerms.SelectedValue == "FOB")
        {

            txtFreight_Exch_Rate.Enabled = true;
            txtFreight_Currency.Enabled = true;
            txtFreight_Rate.Enabled = true;
            //txtFreight_Charges.Enabled = true;

            txtInsurance_Exch_Rate.Enabled = true;
            txtInsurance_Currency.Enabled = true;
            txtInsurance_Rate.Enabled = true;
            //txtInsurance_Charges.Enabled = true;


        }
        else if (ddlTerms.SelectedValue == "CI")
        {



            txtFreight_Exch_Rate.Enabled = true;
            txtFreight_Currency.Enabled = true;

            txtInsurance_Exch_Rate.Enabled = false;
            txtInsurance_Currency.Enabled = false;
            txtInsurance_Rate.Enabled = false;
            //txtInsurance_Charges.Enabled = false;
            if (txtFreight_Rate.Text != "0" && txtFreight_Rate.Text != "0.00" && txtFreight_Rate.Text != "")
            {
                
                txtFreight_Rate.Enabled = true;
                txtFreight_Charges.Enabled = false;
            }
            else
            {
               
                txtFreight_Rate.Enabled = true;
                txtFreight_Charges.Enabled = true;
            }
            txtInsurance_Currency.Text = "";
            txtInsurance_Exch_Rate.Text = "";
            txtInsurance_Rate.Text = "";
            txtInsurance_Charges.Text = "";
        }
        else if (ddlTerms.SelectedValue == "CF")
        {

            txtFreight_Exch_Rate.Enabled = false;
            txtFreight_Currency.Enabled = false;
            txtFreight_Rate.Enabled = false;
            //txtFreight_Charges.Enabled = false;

            txtInsurance_Exch_Rate.Enabled = true;
            txtInsurance_Currency.Enabled = true;
            txtInsurance_Rate.Enabled = true;
            //txtInsurance_Charges.Enabled = true;
            if (txtInsurance_Rate.Text != "0" || txtInsurance_Rate.Text != "0.00" || txtInsurance_Rate.Text != "")
            {

                txtInsurance_Rate.Enabled = true;
                txtInsurance_Charges.Enabled = false;
            }
            else
            {

                txtInsurance_Rate.Enabled = true;
                txtInsurance_Charges.Enabled = true;
            }
            txtFreight_Exch_Rate.Text = "";
            txtFreight_Currency.Text = "";
            txtFreight_Rate.Text = "";
            txtFreight_Charges.Text = "";
        }
        else if (ddlTerms.SelectedValue == "CIF")
        {



            txtFreight_Exch_Rate.Enabled = false;
            txtFreight_Currency.Enabled = false;
            txtFreight_Rate.Enabled = false;
            //txtFreight_Charges.Enabled = false;

            txtInsurance_Exch_Rate.Enabled = false;
            txtInsurance_Currency.Enabled = false;
            txtInsurance_Rate.Enabled = false;
            //txtInsurance_Charges.Enabled = false;
            txtFreight_Currency.Text = "";
            txtFreight_Exch_Rate.Text = "";
            txtFreight_Rate.Text = "";
            txtFreight_Charges.Text = "";

            txtInsurance_Currency.Text = "";
            txtInsurance_Exch_Rate.Text = "";
            txtInsurance_Rate.Text = "";
            txtInsurance_Charges.Text = "";
        }
    }
    public void Invoice_Updation(string sno)
    {
        if (chkMisc.Checked == true)
        {

            chkMisc.Checked = true;
            chkMisc.Enabled = true;
            //if (gv_Invoice.Rows.Count == 1)
            if (Int32.Parse(sno) == 1)
            {
                chkMisc.Enabled = true;
                ddlTerms.Enabled = true;

                txtTotal_Frieght.Enabled = true;
                txtTotal_Insurance.Enabled = true;

                txtFreight_Charges.Enabled = false;
                txtInsurance_Charges.Enabled = false;
                txtTotal_Frieght.Text = txtTotal_Frieght.Text;
                txtTotal_Insurance.Text = txtTotal_Insurance.Text;
                hdn_update_Invoice_id.Value = ViewState["INVOICE_ID"].ToString();


                //terms//
                get_Textboxvalue();
                Terms_Change_Updating_MultiInvoice();
                //terms//
                pnl_Multi_Invoice.Enabled = true;
                tag_Totalfrieght.Style.Add("display", "block");
                tag_TotalInsurance.Style.Add("display", "block");
                Terms_clear_Total_freight_Insurance();

            }
            else
            {
                chkMisc.Enabled = false;
                ddlTerms.Enabled = false;


                txtTotal_Frieght.Enabled = false;
                txtTotal_Insurance.Enabled = false;

                txtFreight_Charges.Enabled = false;
                txtInsurance_Charges.Enabled = false;
                txtTotal_Frieght.Text = txtTotal_Frieght.Text;
                txtTotal_Insurance.Text = txtTotal_Insurance.Text;
                //terms//
                get_Textboxvalue();
                Terms_Change_Updating_MultiInvoice();
                //terms//
                pnl_Multi_Invoice.Enabled = false;
                tag_Totalfrieght.Style.Add("display", "none");
                tag_TotalInsurance.Style.Add("display", "none");
            }


            //tag_Totalfrieght.Style.Add("display", "block");
            //tag_TotalInsurance.Style.Add("display", "block");
            //tag_Totalfrieght.Visible = true;
            //tag_TotalInsurance.Visible = true;
        }
        else
        {
            chkMisc.Enabled = true;
            chkMisc.Checked = false;



            txtTotal_Frieght.Enabled = false;
            txtTotal_Insurance.Enabled = false;
            txtFreight_Charges.Visible = true;
            txtInsurance_Charges.Visible = true;
            txtFreight_Charges.Enabled = false;
            txtInsurance_Charges.Enabled = false;
            txtTotal_Frieght.Text = txtTotal_Frieght.Text;
            txtTotal_Insurance.Text = txtTotal_Insurance.Text;
            tag_Totalfrieght.Visible = false;
            tag_TotalInsurance.Visible = false;
            //terms//
            get_Textboxvalue();
            Terms_Change_Updating_MultiInvoice();
            //terms//
            pnl_Multi_Invoice.Enabled = true;

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Total_freight_Insurance_Display_none();</script>", true);
            //Response.Write("<script language='javascript'>Total_freight_Insurance_Display_none();</script>");
            tag_Totalfrieght.Style.Add("display", "none");
            tag_TotalInsurance.Style.Add("display", "none");
        }


    }
    public void Invoice_Updation1(string sno)
    {
        if (chkMisc.Checked == true)
        {

            chkMisc.Checked = true;
            chkMisc.Enabled = true;
            //if (Int32.Parse(sno) == 1)
            if (Int32.Parse(sno) == 1)
            {


                chkMisc.Enabled = true;
                ddlTerms.Enabled = true;

                txtTotal_Frieght.Enabled = true;
                txtTotal_Insurance.Enabled = true;
                tag_Totalfrieght.Style.Add("display", "block");
                tag_TotalInsurance.Style.Add("display", "block");
                txtFreight_Charges.Enabled = false;
                txtInsurance_Charges.Enabled = false;
                txtTotal_Frieght.Text = hdn_Total_Freight_Value.Value;
                txtTotal_Insurance.Text = hdn_Total_Insurance_Value.Value;
                tag_Totalfrieght.Visible = true;
                tag_TotalInsurance.Visible = true;

                pnl_Multi_Invoice.Enabled = true;


                txtFreight_Charges.Text = gv_Invoice.Rows[0].Cells[47].Text.Replace("&nbsp;", "");

                txtFreight_Rate.Text = gv_Invoice.Rows[0].Cells[48].Text.Replace("&nbsp;", "");

                txtInsurance_Charges.Text = gv_Invoice.Rows[0].Cells[51].Text.Replace("&nbsp;", "");
                txtInsurance_Rate.Text = gv_Invoice.Rows[0].Cells[52].Text.Replace("&nbsp;", "");
            }
            else
            {
                chkMisc.Enabled = false;
                ddlTerms.Enabled = false;
                tag_Totalfrieght.Visible = true;
                tag_TotalInsurance.Visible = true;
                //tag_Totalfrieght.Style.Add("display", "none");
                //tag_TotalInsurance.Style.Add("display", "none");

                txtTotal_Frieght.Enabled = false;
                txtTotal_Insurance.Enabled = false;
                txtFreight_Charges.Enabled = false;
                txtInsurance_Charges.Enabled = false;
                pnl_Multi_Invoice.Enabled = false;
                txtTotal_Frieght.Text = hdn_Total_Freight_Value.Value;
                txtTotal_Insurance.Text = hdn_Total_Insurance_Value.Value;


            }
            //terms//
            get_Textboxvalue();
            Terms_Change_Updating_MultiInvoice();
            //terms//

            tag_Totalfrieght.Style.Add("display", "block");
            tag_TotalInsurance.Style.Add("display", "block");


            tag_Totalfrieght.Visible = true;
            tag_TotalInsurance.Visible = true;
            txtFreight_Rate.Text = "0.00";
            txtInsurance_Rate.Text = "0.00";
        }
        else
        {
            pnl_Multi_Invoice.Enabled = true;

            chkMisc.Enabled = true;
            chkMisc.Checked = false;
            tag_Totalfrieght.Style.Add("display", "none");
            tag_TotalInsurance.Style.Add("display", "none");


            txtTotal_Frieght.Enabled = false;
            txtTotal_Insurance.Enabled = false;
            txtFreight_Charges.Visible = true;
            txtInsurance_Charges.Visible = true;
            txtFreight_Charges.Enabled = false;
            txtInsurance_Charges.Enabled = false;
            txtTotal_Frieght.Text = hdn_Total_Freight_Value.Value;
            txtTotal_Insurance.Text = hdn_Total_Insurance_Value.Value;

            tag_Totalfrieght.Visible = false;
            tag_TotalInsurance.Visible = false;
            //terms//
            get_Textboxvalue();
            Terms_Change_Updating_MultiInvoice();
            //terms//

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Total_freight_Insurance_Display_none();</script>", true);
            //Response.Write("<script language='javascript'>Total_freight_Insurance_Display_none();</script>");

        }
        if (gv_Invoice.Rows.Count > 0)
        {
            if (gv_Invoice.Rows.Count == 1)
            {
                hdn_grid_count.Value = "1";
                tag_Totalfrieght.Style.Add("display", "none");
                tag_TotalInsurance.Style.Add("display", "none");
                tag_Totalfrieght.Visible = false;
                tag_TotalInsurance.Visible = false;
                Grid_count_one();
            }
            else if (gv_Invoice.Rows.Count > 0)
            {
                hdn_grid_count.Value = Convert.ToString(gv_Invoice.Rows.Count);

            }
            else
                hdn_grid_count.Value = "0";
        }
        else
            hdn_grid_count.Value = "0";
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'INVOICE', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'INVOICE', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    ///auto search
    [System.Web.Services.WebMethod]
    public static string GetExchange_Rate(string custid)
    {
        if (custid.Length == 3)
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);
            Auto.Ename = "EXCHANGE_MASTER_RATE_IMPORTWISE";
            Auto.Enamesearch = custid;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                //custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString()+ "~~" +""+ "~~" +""+ "~~" +""+ "~~" +""+ "~~" +"";
                custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
            }
            //if not Ex-rate in admin exchange master get Ex-rate from NON STANDARD CURRENCY MASTER

            else
            {
                Auto.Ename = "NON_STD_CUR_RATE_IMPORTWISE";
                Auto.Enamesearch = custid;
                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {


                    string NON_STD_RATE_IMPORT = ds.Tables[0].Rows[0]["NON_STD_RATE_IMPORT"].ToString();
                    string NON_STD_EFFECT_DT_IMP = ds.Tables[0].Rows[0]["NON_STD_EFFECT_DT_IMP"].ToString();
                    string NON_STD_BANKNAME = ds.Tables[0].Rows[0]["NON_STD_BANKNAME"].ToString();
                    string NON_STD_CERTIFICATE_NO = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString();
                    string NON_STD_CERTIFICATE_DATE = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString();

                    custid = NON_STD_RATE_IMPORT + "~~" + NON_STD_EFFECT_DT_IMP + "~~" + NON_STD_BANKNAME + "~~" + NON_STD_CERTIFICATE_NO + "~~" + NON_STD_CERTIFICATE_DATE;
                }
                else
           
                custid = "";
            }
            //if not Ex-rate in admin exchange master get Ex-rate from NON STANDARD CURRENCY MASTER


        }
        else
        {
            custid = "";
        }
        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string GetSupplier(string custid)
    {

        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        // custid = Auto.Country_Master_FromClientSide_Calling(custid);
        Auto.Ename = "SUPPLIER_MASTER_SEARCH";
        Auto.Enamesearch = custid;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {


            string SUP_NAME = ds.Tables[0].Rows[0]["SUP_NAME"].ToString();
            string SUP_ADD1 = ds.Tables[0].Rows[0]["SUP_ADD1"].ToString();
            string SUP_ADD2 = ds.Tables[0].Rows[0]["SUP_ADD2"].ToString();
            string SUP_ADD3 = ds.Tables[0].Rows[0]["SUP_ADD3"].ToString();
            string SUP_COUNTRY_NAME = ds.Tables[0].Rows[0]["SUP_COUNTRY_NAME"].ToString();
            string SUP_COUNTRY_CODE = ds.Tables[0].Rows[0]["SUP_COUNTRY_CODE"].ToString();
            string SUP_PIN_CODE = ds.Tables[0].Rows[0]["SUP_PIN_CODE"].ToString();
            custid = SUP_NAME + "~~" + SUP_ADD1 + "~~" + SUP_ADD2 + "~~" + SUP_ADD3 + "~~" + SUP_COUNTRY_NAME + "~~" + SUP_COUNTRY_CODE + "~~" + SUP_PIN_CODE;
        }

        //if (Auto.Ename != "1")
        //{
        //custid = "";
        // }
        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string GetSeller(string custid)
    {

        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        // custid = Auto.Country_Master_FromClientSide_Calling(custid);
        Auto.Ename = "SUPPLIER_MASTER_SEARCH";
        Auto.Enamesearch = custid;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {


            string SUP_NAME = ds.Tables[0].Rows[0]["SUP_NAME"].ToString();
            string SUP_ADD1 = ds.Tables[0].Rows[0]["SUP_ADD1"].ToString();
            string SUP_ADD2 = ds.Tables[0].Rows[0]["SUP_ADD2"].ToString();
            string SUP_ADD3 = ds.Tables[0].Rows[0]["SUP_ADD3"].ToString();
            string SUP_COUNTRY_NAME = ds.Tables[0].Rows[0]["SUP_COUNTRY_NAME"].ToString();
            string SUP_COUNTRY_CODE = ds.Tables[0].Rows[0]["SUP_COUNTRY_CODE"].ToString();
            string SUP_PIN_CODE = ds.Tables[0].Rows[0]["SUP_PIN_CODE"].ToString();
            custid = SUP_NAME + "~~" + SUP_ADD1 + "~~" + SUP_ADD2 + "~~" + SUP_ADD3 + "~~" + SUP_COUNTRY_NAME + "~~" + SUP_COUNTRY_CODE + "~~" + SUP_PIN_CODE;
        }

        //if (Auto.Ename != "1")
        //{
        //custid = "";
        // }
        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string GetBroker(string custid)
    {

        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        // custid = Auto.Country_Master_FromClientSide_Calling(custid);
        Auto.Ename = "SUPPLIER_MASTER_SEARCH";
        Auto.Enamesearch = custid;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {


            string SUP_NAME = ds.Tables[0].Rows[0]["SUP_NAME"].ToString();
            string SUP_ADD1 = ds.Tables[0].Rows[0]["SUP_ADD1"].ToString();
            string SUP_ADD2 = ds.Tables[0].Rows[0]["SUP_ADD2"].ToString();
            string SUP_ADD3 = ds.Tables[0].Rows[0]["SUP_ADD3"].ToString();
            string SUP_COUNTRY_NAME = ds.Tables[0].Rows[0]["SUP_COUNTRY_NAME"].ToString();
            string SUP_COUNTRY_CODE = ds.Tables[0].Rows[0]["SUP_COUNTRY_CODE"].ToString();
            string SUP_PIN_CODE = ds.Tables[0].Rows[0]["SUP_PIN_CODE"].ToString();
            custid = SUP_NAME + "~~" + SUP_ADD1 + "~~" + SUP_ADD2 + "~~" + SUP_ADD3 + "~~" + SUP_COUNTRY_NAME + "~~" + SUP_COUNTRY_CODE + "~~" + SUP_PIN_CODE;
        }

        //if (Auto.Ename != "1")
        //{
        //custid = "";
        // }
        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string GetFreight_Currency_value(string txtFreight_Currency, string txtInvoiceCurrency, string txtInvoiceValue, string txtFreight_Exch_Rate)
    {
        string Working_Period = "", MISC_EXRATE = "", CURRENCY_CODE = "", hdn_currency = "", txtFreight_Charges = "";
        double cal = 0, cal1 = 0;
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();


        //eroyalmaster erm = new eroyalmaster();
        adminmaster erm = new adminmaster();

        DataSet dss = new DataSet();
        erm.Invoice_Currency = txtFreight_Currency;
        erm.Ename = "IMPORT_INVOICE_EX_RATE";
        erm.EWorking_Period = Working_Period;
        dss = erm.RetrieveAll_Exchange_master_INV_Currency();
        if (dss.Tables[0].Rows.Count > 0)
        {
            MISC_EXRATE = dss.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

            CURRENCY_CODE = dss.Tables[0].Rows[0]["EXCHANGE_CUR_CODE"].ToString();
        }
        //if not Ex-rate in admin exchange master get Ex-rate from NON STANDARD CURRENCY MASTER

        else
        {
            dss.Clear();
            Auto_Search Auto = new Auto_Search();
             Auto.Ename = "NON_STD_CUR_RATE_IMPORTWISE";
             Auto.Enamesearch = txtFreight_Currency; 
                dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (dss.Tables[0].Rows.Count > 0)
                {


                    MISC_EXRATE = dss.Tables[0].Rows[0]["NON_STD_RATE_IMPORT"].ToString();
                    CURRENCY_CODE = txtFreight_Currency;
                }
        }
        //if not Ex-rate in admin exchange master get Ex-rate from NON STANDARD CURRENCY MASTER

        //txtFreight_Exch_Rate.Text = MISC_EXRATE;
        double invoicevalue = 0;
        if (txtInvoiceValue != "")
        {
            invoicevalue = Convert.ToDouble(txtInvoiceValue);
            erm.Invoice_Currency = txtInvoiceCurrency;
            //erm.Invoice_Currency = "USD";
            erm.Ename = "IMPORT_INVOICE_EX_RATE";
            erm.EWorking_Period = Working_Period;
            dss = erm.RetrieveAll_Exchange_master_INV_Currency();
            if (dss.Tables[0].Rows.Count > 0)
            {

                hdn_currency = dss.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

            }
            //if not Ex-rate in admin exchange master get Ex-rate from NON STANDARD CURRENCY MASTER

            else
            {
                dss.Clear();
                Auto_Search Auto = new Auto_Search();
                Auto.Ename = "NON_STD_CUR_RATE_IMPORTWISE";
                Auto.Enamesearch = txtInvoiceCurrency;
                dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (dss.Tables[0].Rows.Count > 0)
                {
                    
                    hdn_currency = dss.Tables[0].Rows[0]["NON_STD_RATE_IMPORT"].ToString();
                    
                }
            }
            //if not Ex-rate in admin exchange master get Ex-rate from NON STANDARD CURRENCY MASTER

        }

        if (txtFreight_Currency.ToUpper() == CURRENCY_CODE)
        {
            if (hdn_currency != "")
            {
                double Invoice_Currency_Exrate = Convert.ToDouble(hdn_currency);

                //if (txtInvoiceCurrency.Text == "INR" && txtFreight_Currency.Text == "USD")
                //{
                //cal = ((invoicevalue * 20 / 100) * Invoice_Currency_Exrate);
                cal = ((invoicevalue * 20 / 100) * Invoice_Currency_Exrate);
                double EXRATE = Convert.ToDouble(MISC_EXRATE);
                string rate = Convert.ToString(EXRATE);
                rate.Substring(0, 1);
                if (rate != "0")
                    cal1 = Math.Round(cal / EXRATE, 2);

                txtFreight_Charges = Convert.ToString(cal1);
                //}


            }
        }
        else
        {

            if (txtFreight_Exch_Rate != "" && txtInvoiceCurrency != "")
            {
                //double cal, cal1;
                //double exch_cal, exch_cal1;
                double invoicevalue1 = Convert.ToDouble(txtInvoiceValue);
                double Invoice_Currency_Exrate = Convert.ToDouble(txtFreight_Exch_Rate);
                cal = invoicevalue * 20 / 100;

                txtFreight_Charges = Convert.ToString(cal);
                MISC_EXRATE = txtFreight_Exch_Rate;
                //txtDiscount_Exch_Rate.Text = txtFreight_Exch_Rate.Text;
                //txtFreight_Exch_Rate.Text = txtFreight_Exch_Rate.Text;
                //txtInsurance_Exch_Rate.Text = txtFreight_Exch_Rate.Text;
            }
        }
        txtFreight_Currency = txtFreight_Charges + "~~" + hdn_currency + "~~" + MISC_EXRATE;
        return txtFreight_Currency;
    }

    [System.Web.Services.WebMethod]
    public static string GetInsurance_Currency_value(string txtInsurance_Currency, string txtInvoiceCurrency, string txtInvoiceValue, string txtInsurance_Exch_Rate)
    {
        string Working_Period = "", MISC_EXRATE = "", CURRENCY_CODE = "", hdn_currency = "", txtInsurance_Charges = "";
        double cal = 0, cal1 = 0;
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();


        //eroyalmaster erm = new eroyalmaster();
        adminmaster erm = new adminmaster();

        DataSet dss = new DataSet();
        erm.Invoice_Currency = txtInsurance_Currency;
        erm.Ename = "IMPORT_INVOICE_EX_RATE";
        erm.EWorking_Period = Working_Period;
        dss = erm.RetrieveAll_Exchange_master_INV_Currency();
        if (dss.Tables[0].Rows.Count > 0)
        {
            MISC_EXRATE = dss.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

            CURRENCY_CODE = dss.Tables[0].Rows[0]["EXCHANGE_CUR_CODE"].ToString();
        }
        //if not Ex-rate in admin exchange master get Ex-rate from NON STANDARD CURRENCY MASTER

        else
        {
            dss.Clear();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = "NON_STD_CUR_RATE_IMPORTWISE";
            Auto.Enamesearch = txtInsurance_Currency;
            dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (dss.Tables[0].Rows.Count > 0)
            {


                MISC_EXRATE = dss.Tables[0].Rows[0]["NON_STD_RATE_IMPORT"].ToString();
                CURRENCY_CODE = txtInsurance_Currency;
            }
        }
        //if not Ex-rate in admin exchange master get Ex-rate from NON STANDARD CURRENCY MASTER

        //txtFreight_Exch_Rate.Text = MISC_EXRATE;
        double invoicevalue = 0;
        if (txtInvoiceValue != "")
        {
            invoicevalue = Convert.ToDouble(txtInvoiceValue);
            erm.Invoice_Currency = txtInvoiceCurrency;
            //erm.Invoice_Currency = "USD";
            erm.Ename = "IMPORT_INVOICE_EX_RATE";
            erm.EWorking_Period = Working_Period;
            dss = erm.RetrieveAll_Exchange_master_INV_Currency();
            if (dss.Tables[0].Rows.Count > 0)
            {

                hdn_currency = dss.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

            }
            //if not Ex-rate in admin exchange master get Ex-rate from NON STANDARD CURRENCY MASTER

            else
            {
                dss.Clear();
                Auto_Search Auto = new Auto_Search();
                Auto.Ename = "NON_STD_CUR_RATE_IMPORTWISE";
                Auto.Enamesearch = txtInvoiceCurrency;
                dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (dss.Tables[0].Rows.Count > 0)
                {

                    hdn_currency = dss.Tables[0].Rows[0]["NON_STD_RATE_IMPORT"].ToString();

                }
            }
            //if not Ex-rate in admin exchange master get Ex-rate from NON STANDARD CURRENCY MASTER

        }

        if (txtInsurance_Currency.ToUpper() == CURRENCY_CODE)
        {
            if (hdn_currency != "")
            {
                double Invoice_Currency_Exrate = Convert.ToDouble(hdn_currency);

                //if (txtInvoiceCurrency.Text == "INR" && txtFreight_Currency.Text == "USD")
                //{
                //cal = ((invoicevalue * 20 / 100) * Invoice_Currency_Exrate);
                cal = ((invoicevalue * 1.1250 / 100) * Invoice_Currency_Exrate);
                double EXRATE = Convert.ToDouble(MISC_EXRATE);
                string rate = Convert.ToString(EXRATE);
                rate.Substring(0, 1);
                if (rate != "0")
                    cal1 = Math.Round(cal / EXRATE, 2);

                txtInsurance_Charges = Convert.ToString(cal1);
                //}


            }
        }
        else
        {

            if (txtInsurance_Exch_Rate != "" && txtInvoiceCurrency != "")
            {
                //double cal, cal1;
                //double exch_cal, exch_cal1;
                double invoicevalue1 = Convert.ToDouble(txtInvoiceValue);
                double Invoice_Currency_Exrate = Convert.ToDouble(txtInsurance_Exch_Rate);
                cal = invoicevalue * 20 / 100;

                txtInsurance_Charges = Convert.ToString(cal);
                MISC_EXRATE = txtInsurance_Exch_Rate;
                //txtDiscount_Exch_Rate.Text = txtFreight_Exch_Rate.Text;
                //txtFreight_Exch_Rate.Text = txtFreight_Exch_Rate.Text;
                //txtInsurance_Exch_Rate.Text = txtFreight_Exch_Rate.Text;
            }
        }
        txtInsurance_Currency = txtInsurance_Charges + "~~" + hdn_currency + "~~" + MISC_EXRATE;
        return txtInsurance_Currency;
    }


    public void Get_ExcelFile()
    {
        string connString = "";
        string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        //string path = "C:\\Documents and Settings\\sathis\\Desktop\\" + fileuploadExcel.FileName;
        string path = errorFolder + "\\" + fileuploadExcel.FileName;
     


        //string connString = "";
        //string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        //string path = fileuploadExcel.PostedFile.FileName;


        string strGID;
        string picExtension;
        string fileName2;

        if (fileuploadExcel.HasFile)
        {
            //strGID = userid;
            picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
           // fileName2 = strGID + picExtension;
            fileName2 = fileuploadExcel.FileName;
            addtoGallery1(fileName2, errorFolder);
        }


       // fileuploadExcel.SaveAs(Server.MapPath(path));
      
        //Label1.Text = "File Has Been Uploaded";

        //Connection String to Excel Workbook
        if (strFileType.Trim() == ".xls")
        {
            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
        }
        else if (strFileType.Trim() == ".xlsx")
        {
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        }


        //----------------------------
        string query = "SELECT * FROM [Sheet1$]";

        //string query = "SELECT INVOICE_SLNO,INVOICE_NO, Format([INVOICE_DATE],'dd/mm/yyyy') as INVOICE_DATE,TERMS,INVOICE_CURRENCY,ITEM_SLNO,ITEM_QTY,ITEM_QTY_CODE,ITEM_UNIT_PRICE,ITEM_DESCRIPTION,MIS_FREIGHT_CHARGES,MIS_FREIGHT_CURRENCY,MIS_INSURANCE_CHARGES,MIS_INSURANCE_CURRENCY,MIS_CHARGES,MIS_CURRENCY,PRODUCT_CTH,PRODUCT_RITC,PRODUCT_BCD_NOTN,PRODUCT_BCD_SLNO,PRODUCT_EDU_CESS_NOTN,PRODUCT_EDU_CESS_NOTN_SL,PRODUCT_CETH,PRODUCT_CVD_NOTN,PRODUCT_CVD_SLNO,PRODUCT_MRP_SL_NO,PRODUCT_MRP_AMOUNT,PRODUCT_EDU_CESS_NOTN,PRODUCT_EDU_CESS_NOTN_SL,GENEARL_DESCRIPTION,MANUFACTURER,BRAND,MODEL,END_USE_OF_ITEM,COUNTRY_OF_ORIGIN,SCHEME_CODE,SCHEME_NOTN,SCHEME_NOTN_SLNO,LICENSE_NO,LICENSE_DATE,EXCEMPTION,LICENSE_SLNO,PORT_OF_LICENSE FROM [Sheet1$]";


        OleDbConnection conn = new OleDbConnection(connString);
        if (conn.State == ConnectionState.Closed)
            conn.Open();
        OleDbCommand cmd = new OleDbCommand(query, conn);

        OleDbDataAdapter da = new OleDbDataAdapter(cmd);

        da.Fill(ds);
        // Label1.Text =Convert.ToString(ds.Tables[0].Rows[0]);
        //Label2.Text= Convert.ToString(ds.Tables[0].Rows[1]);
        //grvExcelData.DataSource = ds.Tables[0];
        //grvExcelData.DataBind();
        da.Dispose();
        conn.Close();
        conn.Dispose();

        //------------------------------------
        //OleDbConnection conn = new OleDbConnection(connString);
        //if (conn.State == ConnectionState.Closed)
        //    conn.Open();
        ////Fill the dataset with information from the BV and REV worksheet.
        //var adapterbvandrev = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", conn);
        //var dsbvandrev = new DataSet();
        //adapterbvandrev.Fill(ds);
        ////int status = SaveStatus(dsbvandrev);
        ////if (status == 1)
        ////{
        ////    lblmessage.Text = "Data imported and saved successfully.";
        ////}
        ViewState["ds_Excel_upload"] = ds;

    }

    
    public void Delete_Excel_Invoice_Delete()
    {
        string flag = "Delete_Excel";

        string inv_no = "", terms = "", inv_slno = "";

        gridbind(inv_no, flag, terms, inv_slno);
    }
    protected void btn_Delete_All_Invoice_And_Upload_Click(object sender, EventArgs e)
    {
        Delete_Excel_Invoice_Delete();

        if (gv_Invoice.Rows.Count == 0)
        {
            mp1.Show();
        }
        else
            Alert_msg("Invoice not deleted");

    }

    protected void btnImport_Click(object sender, EventArgs e)
    {
        try
        {

            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Get_ExcelFile();
                                

            }

            else
            {

                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Get_ExcelFile();
                
            }

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>document.getElementById('IMD').click();</script>", false);
            if (gv_Invoice.Rows.Count > 0)
            {
                mp1.Show();
                mp_yesorno.Show();
            }
            else
            {
                Excel_Upload_load();
            }
            

        }
        catch (Exception ex)
        {
            //Maildb.StoreMailContents(ds, email);
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }
    public void Excel_Upload_load()
    {
        ds = (DataSet)ViewState["ds_Excel_upload"];
        int a = 0, b = 0, c = 0;
        if (ds.Tables[0].Rows.Count > a)
        {
            dsXML.Tables.Add("InvoiceDetails");
            dsXML.Tables[0].Columns.Add("INVOICE_ID");
            dsXML.Tables[0].Columns.Add("JOBNO");
            dsXML.Tables[0].Columns.Add("INVOICE_SLNO");

            dsXML.Tables[0].Columns.Add("INVOICE_NO");
            dsXML.Tables[0].Columns.Add("INVOICE_DATE", typeof(DateTime));
            dsXML.Tables[0].Columns.Add("TERMS");
            dsXML.Tables[0].Columns.Add("INVOICE_CURRENCY");
            dsXML.Tables[0].Columns.Add("INVOICE_EXRATE");
            dsXML.Tables[0].Columns.Add("INVOICE_VALUE");
            dsXML.Tables[0].Columns.Add("SUPPLIER_NAME");
            dsXML.Tables[0].Columns.Add("SUPPLIER_ADDRESS");
            dsXML.Tables[0].Columns.Add("SUPPLIER_ADDRESS1");
            dsXML.Tables[0].Columns.Add("SUPPLIER_ADDRESS2");
            dsXML.Tables[0].Columns.Add("SUPPLIER_COUNTRY_NAME");
            dsXML.Tables[0].Columns.Add("SUPPLIER_COUNTRY_CODE");
            dsXML.Tables[0].Columns.Add("SUPPLIER_COUNTRY_PINCODE");
            dsXML.Tables[0].Columns.Add("SELLER_NAME");
            dsXML.Tables[0].Columns.Add("SELLER_ADDRESS");
            dsXML.Tables[0].Columns.Add("SELLER_ADDRESS1");
            dsXML.Tables[0].Columns.Add("SELLER_ADDRESS2");
            dsXML.Tables[0].Columns.Add("SELLER_COUNTRY_NAME");
            dsXML.Tables[0].Columns.Add("SELLER_COUNTRY_CODE");
            dsXML.Tables[0].Columns.Add("SELLERCOUNTRY_PINCODE");
            dsXML.Tables[0].Columns.Add("BROKER_NAME");
            dsXML.Tables[0].Columns.Add("BROKER_ADDRESS");
            dsXML.Tables[0].Columns.Add("BROKER_ADDRESS1");
            dsXML.Tables[0].Columns.Add("BROKER_ADDRESS2");
            dsXML.Tables[0].Columns.Add("BROKER_COUNTRY_NAME");
            dsXML.Tables[0].Columns.Add("BROKER_COUNTRY_CODE");
            dsXML.Tables[0].Columns.Add("BROKER_COUNTRY_PINCODE");
            dsXML.Tables[0].Columns.Add("MIS_CHARGES");
            dsXML.Tables[0].Columns.Add("MIS_RATE");
            dsXML.Tables[0].Columns.Add("MIS_CURRENCY");
            dsXML.Tables[0].Columns.Add("MIS_EXRATE");
            dsXML.Tables[0].Columns.Add("MIS_AGENCY_CHARGES");
            dsXML.Tables[0].Columns.Add("MIS_AGENCY_RATE");
            dsXML.Tables[0].Columns.Add("MIS_AGENCY_CURRENCY");
            dsXML.Tables[0].Columns.Add("MIS_AGENCY_EXRATE");
            dsXML.Tables[0].Columns.Add("MIS_DISCOUNT_CHARGES");
            dsXML.Tables[0].Columns.Add("MIS_DISCOUNT_RATE");
            dsXML.Tables[0].Columns.Add("MIS_DISCOUNT_CURRENCY");
            dsXML.Tables[0].Columns.Add("MIS_DISCOUNT_EXRATE");
            dsXML.Tables[0].Columns.Add("MIS_DISCOUNT_REASON");
            dsXML.Tables[0].Columns.Add("MIS_LOADING_CHARGES");
            dsXML.Tables[0].Columns.Add("MIS_LOADING_RATE");
            dsXML.Tables[0].Columns.Add("MIS_LOADING_CURRENCY");
            dsXML.Tables[0].Columns.Add("MIS_LOADING_EXRATE");
            dsXML.Tables[0].Columns.Add("MIS_FREIGHT_CHARGES");
            dsXML.Tables[0].Columns.Add("MIS_FREIGHT_RATE");
            dsXML.Tables[0].Columns.Add("MIS_FREIGHT_CURRENCY");
            dsXML.Tables[0].Columns.Add("MIS_FREIGHT_EXRATE");
            dsXML.Tables[0].Columns.Add("MIS_INSURANCE_CHARGES");
            dsXML.Tables[0].Columns.Add("MIS_INSURANCE_RATE");
            dsXML.Tables[0].Columns.Add("MIS_INSURANCE_CURRENCY");
            dsXML.Tables[0].Columns.Add("MIS_INSURANCE_EXRATE");
            dsXML.Tables[0].Columns.Add("MIS_HIGHSEASALE_CHARGES");
            dsXML.Tables[0].Columns.Add("MIS_HIGHSEASALE_RATE");
            dsXML.Tables[0].Columns.Add("MIS_HIGHSEASALE_CURRENCY");
            dsXML.Tables[0].Columns.Add("MIS_HIGHSEASALE_EXRATE");
            dsXML.Tables[0].Columns.Add("MIS_SINGLE_OR_MULITIPLE");
            dsXML.Tables[0].Columns.Add("SVB_RELATION");
            dsXML.Tables[0].Columns.Add("SVB_REF_NO");
            dsXML.Tables[0].Columns.Add("SVB_REF_DATE", typeof(DateTime));
            dsXML.Tables[0].Columns.Add("SVB_CUSTOM_HOUSE");
            dsXML.Tables[0].Columns.Add("SVB_LOADING_ON");
            dsXML.Tables[0].Columns.Add("SVB_ASSESABLE_RATE");
            dsXML.Tables[0].Columns.Add("SVB_DUTY_RATE");
            dsXML.Tables[0].Columns.Add("SVB_ASSESABLE_STATUS");
            dsXML.Tables[0].Columns.Add("SVB_DUTY_STATUS");
            dsXML.Tables[0].Columns.Add("OTHER_PURCHASE_ORDER");
            dsXML.Tables[0].Columns.Add("OTHER_PURCHASE_ORDER_DATE");
            dsXML.Tables[0].Columns.Add("OTHER_CONTRACT_NO");
            dsXML.Tables[0].Columns.Add("OTHER_CONTRACT_DATE", typeof(DateTime));
            dsXML.Tables[0].Columns.Add("OTHER_LOC_NO");
            dsXML.Tables[0].Columns.Add("OTHER_LOC_DATE", typeof(DateTime));
            dsXML.Tables[0].Columns.Add("OTHER_NATURE_OF_TRANSACTION");
            dsXML.Tables[0].Columns.Add("OTHER_TERMS_OF_PAYMENT");
            dsXML.Tables[0].Columns.Add("OTHER_CONDITIONS");
            dsXML.Tables[0].Columns.Add("OTHER_VALUATION_METHOD");

            dsXML.Tables[0].Columns.Add("USER_ID");
            dsXML.Tables[0].Columns.Add("DATE_TIME");
            dsXML.Tables[0].Columns.Add("STATUS");
            dsXML.Tables[0].Columns.Add("BRANCH_CODE");
            dsXML.Tables[0].Columns.Add("YEAR");
            dsXML.Tables[0].Columns.Add("WORKING_PERIOD");

            //--------------------Item Details--------------------------//
            dsXML.Tables.Add("ItemDetails");
            dsXML.Tables[1].Columns.Add("ITEM_ID");
            dsXML.Tables[1].Columns.Add("JOBNO");
            dsXML.Tables[1].Columns.Add("INVOICE_SLNO");
            dsXML.Tables[1].Columns.Add("INVOICE_NO");
            dsXML.Tables[1].Columns.Add("ITEM_SLNO");
            dsXML.Tables[1].Columns.Add("ITEM_DESCRIPTION");
            dsXML.Tables[1].Columns.Add("ITEM_QTY");
            dsXML.Tables[1].Columns.Add("ITEM_QTY_CODE");
            dsXML.Tables[1].Columns.Add("ITEM_UNIT_PRICE");
            dsXML.Tables[1].Columns.Add("ITEM_UNIT_CODE");
            dsXML.Tables[1].Columns.Add("ITEM_TOTAL_AMOUNT", typeof(double));
            dsXML.Tables[1].Columns.Add("ITEM_AMOUNT_CODE");
            dsXML.Tables[1].Columns.Add("CTH_NO");
            dsXML.Tables[1].Columns.Add("SCHEME_CODE");
            dsXML.Tables[1].Columns.Add("SCHEME_NOTN");
            dsXML.Tables[1].Columns.Add("SCHEME_NOTN_SLNO");
            dsXML.Tables[1].Columns.Add("CTH_QTY1");
            dsXML.Tables[1].Columns.Add("CTH_QTY1_CODE");
            dsXML.Tables[1].Columns.Add("CTH_QTY2");
            dsXML.Tables[1].Columns.Add("CTH_QTY2_CODE");
            dsXML.Tables[1].Columns.Add("GENEARL_DESCRIPTION");
            dsXML.Tables[1].Columns.Add("MANUFACTURER");
            dsXML.Tables[1].Columns.Add("BRAND");
            dsXML.Tables[1].Columns.Add("MODEL");
            dsXML.Tables[1].Columns.Add("END_USE_OF_ITEM");
            dsXML.Tables[1].Columns.Add("COUNTRY_OF_ORIGIN");
            dsXML.Tables[1].Columns.Add("ACCESSORIES");
            dsXML.Tables[1].Columns.Add("PREVIOUS_BE_NO");
            dsXML.Tables[1].Columns.Add("PREVIOUS_BE_DATE", typeof(DateTime));
            dsXML.Tables[1].Columns.Add("UNIT_PRICE");
            dsXML.Tables[1].Columns.Add("UNIT_CODE");
            dsXML.Tables[1].Columns.Add("CUSTOMS_HOUSE");
            dsXML.Tables[1].Columns.Add("PRODUCT_RITC");
            dsXML.Tables[1].Columns.Add("PRODUCT_CTH");
            dsXML.Tables[1].Columns.Add("PRODUCT_BCD_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_BCD_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_BCD_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_BCD_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_BCD_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_BCD_SPL_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_DUTY_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_DUTY_NOTN_SL");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_DUTY_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_EDU_CESS_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_EDU_CESS_NOTN_SL");
            dsXML.Tables[1].Columns.Add("PRODUCT_EDU_CESS_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN_SL");
            dsXML.Tables[1].Columns.Add("PRODUCT_SEC_EDU_CESS_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_NCD_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_NCD_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_NCD_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_NCD_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_NCD_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_NCD_SPL_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_SL");
            dsXML.Tables[1].Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_SPL_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAPTA_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAPTA_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_SAPTA_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_TARIFF_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_TARIFF_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_TARIFF_QTY");
            dsXML.Tables[1].Columns.Add("PRODUCT_TARIFF_AMOUNT");
            dsXML.Tables[1].Columns.Add("PRODUCT_TARIFF_AMOUNT_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_CETH");
            dsXML.Tables[1].Columns.Add("PRODUCT_MRP_YN");
            dsXML.Tables[1].Columns.Add("PRODUCT_MRP_SL_NO");
            dsXML.Tables[1].Columns.Add("PRODUCT_MRP_AMOUNT");
            dsXML.Tables[1].Columns.Add("PRODUCT_MRP_ABT_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_SPL_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_EDU_CESS_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_CVD_SEC_EDU_CESS_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL5_SIA_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL5_SIA_NOTN_SL");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL5_SIA_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_SPL_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_TYPE");
            dsXML.Tables[1].Columns.Add("PRODUCT_CESS_NOTN");
            dsXML.Tables[1].Columns.Add("PRODUCT_CESS_SLNO");
            dsXML.Tables[1].Columns.Add("PRODUCT_CESS_RATE");
            dsXML.Tables[1].Columns.Add("PRODUCT_CESS_SPL");
            dsXML.Tables[1].Columns.Add("PRODUCT_CESS_UNIT");
            dsXML.Tables[1].Columns.Add("PRODUCT_CESS_TYPE");
            dsXML.Tables[1].Columns.Add("ANTI_DUMPING_NOTN");
            dsXML.Tables[1].Columns.Add("ANTI_DUMPING_NOTN_SLNO");
            dsXML.Tables[1].Columns.Add("CTH_SLNO");
            dsXML.Tables[1].Columns.Add("CTH_SUPPLIER_SLNO");
            dsXML.Tables[1].Columns.Add("CTH_QTY");
            dsXML.Tables[1].Columns.Add("RSP_DUTY_STATUS");
            dsXML.Tables[1].Columns.Add("RSP_SL_NO");
            dsXML.Tables[1].Columns.Add("RSP_DESC");
            dsXML.Tables[1].Columns.Add("RSP_QTY");
            dsXML.Tables[1].Columns.Add("RSP_AMOUNT");
            dsXML.Tables[1].Columns.Add("RSP_NOTN_NO");
            dsXML.Tables[1].Columns.Add("RSP_NOTN_SL_NO");
            dsXML.Tables[1].Columns.Add("RSP_ABT_RATE");
            dsXML.Tables[1].Columns.Add("WAREHOUSE_JOBNO");
            dsXML.Tables[1].Columns.Add("WAREHOUSE_INVOICE_SLNO");
            dsXML.Tables[1].Columns.Add("WAREHOUSE_ITEM_SLNO");
            dsXML.Tables[1].Columns.Add("ASSESSABLE_VALUE");
            dsXML.Tables[1].Columns.Add("DUTY_VALUE");
            dsXML.Tables[1].Columns.Add("CIF_VALUE");
            dsXML.Tables[1].Columns.Add("CVD_VALUE");


            dsXML.Tables[1].Columns.Add("USER_ID");
            dsXML.Tables[1].Columns.Add("DATE_TIME");
            dsXML.Tables[1].Columns.Add("STATUS");
            dsXML.Tables[1].Columns.Add("BRANCH_CODE");
            dsXML.Tables[1].Columns.Add("YEAR");
            dsXML.Tables[1].Columns.Add("WORKING_PERIOD");


            //--------------------License Details--------------------------//
            dsXML.Tables.Add("LicenseDetails");
            dsXML.Tables[2].Columns.Add("LICENSE_ID");
            dsXML.Tables[2].Columns.Add("JOBNO");
            dsXML.Tables[2].Columns.Add("INVOICE_SLNO");
            dsXML.Tables[2].Columns.Add("ITEM_SLNO");
            dsXML.Tables[2].Columns.Add("SCHEME_CODE");
            dsXML.Tables[2].Columns.Add("LICENSE_SLNO");
            dsXML.Tables[2].Columns.Add("REGISTRATION_NO");
            dsXML.Tables[2].Columns.Add("REGISTRATION_DATE", typeof(DateTime));
            dsXML.Tables[2].Columns.Add("EXCEMPTION");
            dsXML.Tables[2].Columns.Add("DEBIT_AMT");
            dsXML.Tables[2].Columns.Add("DEBIT_QTY");
            dsXML.Tables[2].Columns.Add("UNIT_QTY");
            dsXML.Tables[2].Columns.Add("LICENSE_ITEM_NO");
            dsXML.Tables[2].Columns.Add("PORT_OF_LICENSE");
            dsXML.Tables[2].Columns.Add("USER_ID");
            dsXML.Tables[2].Columns.Add("DATE_TIME");
            dsXML.Tables[2].Columns.Add("STATUS");
            dsXML.Tables[2].Columns.Add("BRANCH_CODE");
            dsXML.Tables[2].Columns.Add("YEAR");
            dsXML.Tables[2].Columns.Add("WORKING_PERIOD");

            //--------------------End License Details--------------------------//

            while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
            {
                //while (ds.Tables[0].Rows.Count > a)
                //{

                //if (ds.Tables[0].Rows[a][0] != "")
                //{
                //dr = ds.Tables[0].NewRow();
                DataRow dr = dsXML.Tables[0].NewRow();

                dr["INVOICE_ID"] = "";
                dr["JOBNO"] = IMPORT_JOBNO;
                // dr["JOBDATE"] = EXPORT_JOBDATE;
                //dr["JOBDATE"] = DateTime.Parse(EXPORT_JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                dr["INVOICE_SLNO"] = ds.Tables[0].Rows[a][0].ToString();

                dr["INVOICE_NO"] = ds.Tables[0].Rows[a][1].ToString();


                string inv_date = Convert.ToDateTime(ds.Tables[0].Rows[a][2].ToString()).ToShortDateString();

                string inv_date1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(inv_date));
             
                dr["INVOICE_DATE"] = DateTime.Parse(inv_date1, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                //dr["INVOICE_DATE"] = DateTime.ParseExact(inv_date, "dd/MM/yyyy", null);

             

                dr["TERMS"] = ds.Tables[0].Rows[a][3].ToString();
                dr["INVOICE_CURRENCY"] = ds.Tables[0].Rows[a][4].ToString();
                //dr["INVOICE_VALUE"] = "";

                if (dr["INVOICE_CURRENCY"] != "")
                {
                    adm.Invoice_Currency = dr["INVOICE_CURRENCY"].ToString(); ;

                    adm.Ename = "IMPORT_INVOICE_EX_RATE";
                    adm.EWorking_Period = Working_Period;



                    ds1 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        dr["INVOICE_EXRATE"] = ds1.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();


                    }

                }
                else
                {
                    dr["INVOICE_EXRATE"] = "";
                }

                dr["INVOICE_VALUE"] = "";

                dr["SUPPLIER_NAME"] = "";
                dr["SUPPLIER_ADDRESS"] = "";
                dr["SUPPLIER_ADDRESS1"] = "";
                dr["SUPPLIER_ADDRESS2"] = "";
                dr["SUPPLIER_COUNTRY_NAME"] = "";
                dr["SUPPLIER_COUNTRY_CODE"] = "";
                dr["SUPPLIER_COUNTRY_PINCODE"] = "";
                dr["SELLER_NAME"] = "";
                dr["SELLER_ADDRESS"] = "";
                dr["SELLER_ADDRESS1"] = "";
                dr["SELLER_ADDRESS2"] = "";
                dr["SELLER_COUNTRY_NAME"] = "";
                dr["SELLER_COUNTRY_CODE"] = "";
                dr["SELLERCOUNTRY_PINCODE"] = "";
                dr["BROKER_NAME"] = "";
                dr["BROKER_ADDRESS"] = "";
                dr["BROKER_ADDRESS1"] = "";
                dr["BROKER_ADDRESS2"] = "";
                dr["BROKER_COUNTRY_NAME"] = "";
                dr["BROKER_COUNTRY_CODE"] = "";
                dr["BROKER_COUNTRY_PINCODE"] = "";

                dr["MIS_CHARGES"] = ds.Tables[0].Rows[a][14].ToString();
                dr["MIS_RATE"] = "";
                dr["MIS_CURRENCY"] = ds.Tables[0].Rows[a][15].ToString();

                if (dr["INVOICE_CURRENCY"] == dr["MIS_CURRENCY"])
                {
                    dr["MIS_EXRATE"] = dr["INVOICE_EXRATE"];
                }
                else
                {

                    if (dr["MIS_CURRENCY"] != "")
                    {
                        adm.Invoice_Currency = dr["MIS_CURRENCY"].ToString(); ;

                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                        adm.EWorking_Period = Working_Period;

                        ds2 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            dr["MIS_EXRATE"] = ds2.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                        }

                    }
                    else
                    {
                        dr["MIS_CURRENCY"] = dr["INVOICE_CURRENCY"];
                        dr["MIS_EXRATE"] = dr["INVOICE_EXRATE"];
                    }
                }

                dr["MIS_AGENCY_CHARGES"] = "";
                dr["MIS_AGENCY_RATE"] = "";
                dr["MIS_AGENCY_CURRENCY"] = ds.Tables[0].Rows[a][4].ToString();
                dr["MIS_AGENCY_EXRATE"] = dr["INVOICE_EXRATE"];
                dr["MIS_DISCOUNT_CHARGES"] = "";
                dr["MIS_DISCOUNT_RATE"] = "";
                dr["MIS_DISCOUNT_CURRENCY"] = ds.Tables[0].Rows[a][4].ToString();
                dr["MIS_DISCOUNT_EXRATE"] = dr["INVOICE_EXRATE"];
                dr["MIS_DISCOUNT_REASON"] = "";
                dr["MIS_LOADING_CHARGES"] = "";
                dr["MIS_LOADING_RATE"] = "";
                dr["MIS_LOADING_CURRENCY"] = ds.Tables[0].Rows[a][4].ToString();
                dr["MIS_LOADING_EXRATE"] = dr["INVOICE_EXRATE"];


                //dr["MIS_FREIGHT_CHARGES"] = ds.Tables[0].Rows[a][10].ToString();
                //dr["MIS_FREIGHT_RATE"] = "";                    
                //dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                //if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                //{
                //    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                //}
                //else
                //{

                //    if (dr["MIS_FREIGHT_CURRENCY"] != "")
                //    {
                //        adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                //        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                //        adm.EWorking_Period = Working_Period;

                //        ds3 = adm.RetrieveAll_Exchange_master_INV_Currency();

                //        if (ds3.Tables[0].Rows.Count > 0)
                //        {
                //            dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                //        }

                //    }
                //    else
                //    {
                //        dr["MIS_FREIGHT_EXRATE"] = "";
                //    }
                //}


                //dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][12].ToString();
                //dr["MIS_INSURANCE_RATE"] = "";
                //dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                //if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                //{
                //    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                //}
                //else
                //{

                //    if (dr["MIS_INSURANCE_CURRENCY"] != "")
                //    {
                //        adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                //        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                //        adm.EWorking_Period = Working_Period;                           

                //        ds4 = adm.RetrieveAll_Exchange_master_INV_Currency();

                //        if (ds4.Tables[0].Rows.Count > 0)
                //        {
                //            dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                //        }

                //    }
                //    else
                //    {
                //        dr["MIS_INSURANCE_EXRATE"] = "";
                //    }
                //}

                //dr["MIS_INSURANCE_EXRATE"] = "";

                dr["MIS_HIGHSEASALE_CHARGES"] = "";
                dr["MIS_HIGHSEASALE_RATE"] = "";
                dr["MIS_HIGHSEASALE_CURRENCY"] = "INR";
                dr["MIS_HIGHSEASALE_EXRATE"] = "1.00";
                dr["MIS_SINGLE_OR_MULITIPLE"] = "S";
                dr["SVB_RELATION"] = "";
                dr["SVB_REF_NO"] = "";

                string SVB_REF_DATE = "01/01/1900";
                dr["SVB_REF_DATE"] = DateTime.Parse(SVB_REF_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


                dr["SVB_CUSTOM_HOUSE"] = "";
                dr["SVB_LOADING_ON"] = "";
                dr["SVB_ASSESABLE_RATE"] = "";
                dr["SVB_DUTY_RATE"] = "";
                dr["SVB_ASSESABLE_STATUS"] = "";
                dr["SVB_DUTY_STATUS"] = "";
                dr["OTHER_PURCHASE_ORDER"] = "";

                string PURCHASE_ORDER_DATE = "01/01/1900";

                dr["OTHER_PURCHASE_ORDER_DATE"] = DateTime.Parse(PURCHASE_ORDER_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                dr["OTHER_CONTRACT_NO"] = "";

                string CONTRACT_DATE = "01/01/1900";

                dr["OTHER_CONTRACT_DATE"] = DateTime.Parse(CONTRACT_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                dr["OTHER_LOC_NO"] = "";
                dr["OTHER_NATURE_OF_TRANSACTION"] = "";
                dr["OTHER_TERMS_OF_PAYMENT"] = "";
                dr["OTHER_CONDITIONS"] = "";
                dr["OTHER_VALUATION_METHOD"] = "";


                dr["USER_ID"] = currentuser;
                dr["DATE_TIME"] = "";
                dr["STATUS"] = "S";
                dr["BRANCH_CODE"] = currentbranch;
                dr["YEAR"] = "";
                dr["WORKING_PERIOD"] = Working_Period;


                //--------------------Item Details--------------------------//

                while (ds.Tables[0].Rows[b][0] != System.DBNull.Value)
                {
                    //while (ds.Tables[0].Rows.Count > b)
                    //{
                    DataRow dr1 = dsXML.Tables[1].NewRow();

                    dr1["ITEM_ID"] = "";
                    dr1["JOBNO"] = IMPORT_JOBNO;
                    dr1["INVOICE_SLNO"] = ds.Tables[0].Rows[b][0].ToString();
                    dr1["INVOICE_NO"] = ds.Tables[0].Rows[b][1].ToString();
                    dr1["ITEM_SLNO"] = ds.Tables[0].Rows[b][5].ToString();
                    dr1["ITEM_DESCRIPTION"] = ds.Tables[0].Rows[b][9].ToString();
                    dr1["ITEM_QTY"] = ds.Tables[0].Rows[b][6].ToString();
                    dr1["ITEM_QTY_CODE"] = ds.Tables[0].Rows[b][7].ToString();
                    dr1["ITEM_UNIT_PRICE"] = ds.Tables[0].Rows[b][8].ToString();
                    dr1["ITEM_UNIT_CODE"] = ds.Tables[0].Rows[b][4].ToString();

                    item_amt = Convert.ToDecimal(ds.Tables[0].Rows[b][6]) * Convert.ToDecimal(ds.Tables[0].Rows[b][8]);

                    // dr1["ITEM_AMOUNT"] = Convert.ToString(item_amt);
                    dr1["ITEM_TOTAL_AMOUNT"] = item_amt;
                    dr1["ITEM_AMOUNT_CODE"] = ds.Tables[0].Rows[b][4].ToString();
                    dr1["CTH_NO"] = ds.Tables[0].Rows[b][16].ToString();

                    scheme = ds.Tables[0].Rows[b][35].ToString();                   

                    if (scheme != "" && scheme != "00" && scheme != "0")
                    {
                        if (Convert.ToInt32(scheme) <= 9)
                        {
                            scheme = "0" + scheme;
                        }
                        scheme = Get_Scheme_Code(scheme);
                        dr1["SCHEME_CODE"] = scheme;
                        dr1["SCHEME_NOTN"] = ds.Tables[0].Rows[b][36].ToString();
                        dr1["SCHEME_NOTN_SLNO"] = ds.Tables[0].Rows[b][37].ToString();
                    }
                    else
                    {
                        dr1["SCHEME_CODE"] = "00 - DUTIABLE";
                        dr1["SCHEME_NOTN"] = "";
                        dr1["SCHEME_NOTN_SLNO"] = "";
                    }


                    dr1["CTH_QTY1"] = "";
                    dr1["CTH_QTY1_CODE"] = "";
                    dr1["CTH_QTY2"] = "";
                    dr1["CTH_QTY2_CODE"] = "";
                    dr1["GENEARL_DESCRIPTION"] = ds.Tables[0].Rows[b][29].ToString();
                    dr1["MANUFACTURER"] = ds.Tables[0].Rows[b][30].ToString();
                    dr1["BRAND"] = ds.Tables[0].Rows[b][31].ToString();
                    dr1["MODEL"] = ds.Tables[0].Rows[b][32].ToString();
                    dr1["END_USE_OF_ITEM"] = ds.Tables[0].Rows[b][33].ToString();
                    dr1["COUNTRY_OF_ORIGIN"] = ds.Tables[0].Rows[b][34].ToString();
                    dr1["ACCESSORIES"] = "";
                    dr1["PREVIOUS_BE_NO"] = "";

                    string BE_DATE = "01/01/1900";

                    dr1["PREVIOUS_BE_DATE"] = DateTime.Parse(BE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


                    dr1["UNIT_PRICE"] = "";
                    dr1["UNIT_CODE"] = "";
                    dr1["CUSTOMS_HOUSE"] = "";
                    dr1["PRODUCT_RITC"] = ds.Tables[0].Rows[b][17].ToString();

                    dr1["PRODUCT_CTH"] = ds.Tables[0].Rows[b][16].ToString();
                    dr1["PRODUCT_BCD_NOTN"] = ds.Tables[0].Rows[b][18].ToString();
                    dr1["PRODUCT_BCD_SLNO"] = ds.Tables[0].Rows[b][19].ToString();
                    dr1["PRODUCT_BCD_RATE"] = "";
                    dr1["PRODUCT_BCD_SPL"] = "";
                    dr1["PRODUCT_BCD_UNIT"] = "";
                    dr1["PRODUCT_BCD_SPL_TYPE"] = "";
                    dr1["PRODUCT_ADDL_DUTY_NOTN"] = "";
                    dr1["PRODUCT_ADDL_DUTY_NOTN_SL"] = "";
                    dr1["PRODUCT_ADDL_DUTY_RATE"] = "";
                    dr1["PRODUCT_EDU_CESS_NOTN"] = ds.Tables[0].Rows[b][20].ToString();
                    dr1["PRODUCT_EDU_CESS_NOTN_SL"] = ds.Tables[0].Rows[b][21].ToString();
                    dr1["PRODUCT_EDU_CESS_RATE"] = "";
                    dr1["PRODUCT_SEC_EDU_CESS_NOTN"] = "";
                    dr1["PRODUCT_SEC_EDU_CESS_NOTN_SL"] = "";
                    dr1["PRODUCT_SEC_EDU_CESS_RATE"] = "";
                    dr1["PRODUCT_NCD_NOTN"] = "";

                    dr1["PRODUCT_NCD_SLNO"] = "";
                    dr1["PRODUCT_NCD_RATE"] = "";
                    dr1["PRODUCT_NCD_SPL"] = "";
                    dr1["PRODUCT_NCD_UNIT"] = "";
                    dr1["PRODUCT_NCD_SPL_TYPE"] = "";
                    dr1["PRODUCT_AGGREGATE_DUTY_NOTN"] = "";
                    dr1["PRODUCT_AGGREGATE_DUTY_NOTN_SL"] = "";
                    dr1["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"] = "";
                    dr1["PRODUCT_SAFEGUARD_NOTN"] = "";
                    dr1["PRODUCT_SAFEGUARD_SLNO"] = "";
                    dr1["PRODUCT_SAFEGUARD_RATE"] = "";
                    dr1["PRODUCT_SAFEGUARD_SPL"] = "";
                    dr1["PRODUCT_SAFEGUARD_UNIT"] = "";
                    dr1["PRODUCT_SAFEGUARD_SPL_TYPE"] = "";
                    dr1["PRODUCT_SAPTA_NOTN"] = "";
                    dr1["PRODUCT_SAPTA_SLNO"] = "";
                    dr1["PRODUCT_SAPTA_RATE"] = "";

                    dr1["PRODUCT_TARIFF_NOTN"] = "";
                    dr1["PRODUCT_TARIFF_SLNO"] = "";
                    dr1["PRODUCT_TARIFF_QTY"] = "";
                    dr1["PRODUCT_TARIFF_AMOUNT"] = "";
                    dr1["PRODUCT_TARIFF_AMOUNT_UNIT"] = "";
                    dr1["PRODUCT_CETH"] = ds.Tables[0].Rows[b][22].ToString();

                    dr1["PRODUCT_MRP_SL_NO"] = ds.Tables[0].Rows[b][25].ToString();

                    if (dr1["PRODUCT_MRP_SL_NO"] != "")
                    {
                        dr1["PRODUCT_MRP_YN"] = "Y";
                        dr1["PRODUCT_MRP_AMOUNT"] = ds.Tables[0].Rows[b][26].ToString();
                        dr1["PRODUCT_MRP_ABT_RATE"] = "";
                    }
                    else
                    {
                        dr1["PRODUCT_MRP_YN"] = "N";
                        dr1["PRODUCT_MRP_AMOUNT"] = "";
                        dr1["PRODUCT_MRP_ABT_RATE"] = "";
                    }


                    dr1["PRODUCT_CVD_NOTN"] = ds.Tables[0].Rows[b][23].ToString();
                    dr1["PRODUCT_CVD_SLNO"] = ds.Tables[0].Rows[b][24].ToString();
                    dr1["PRODUCT_CVD_RATE"] = "";
                    dr1["PRODUCT_CVD_SPL"] = "";
                    dr1["PRODUCT_CVD_UNIT"] = "";
                    dr1["PRODUCT_CVD_SPL_TYPE"] = "";
                    dr1["PRODUCT_CVD_EDU_CESS_RATE"] = "";

                    dr1["PRODUCT_CVD_SEC_EDU_CESS_RATE"] = "";
                    dr1["PRODUCT_ADDL5_SIA_NOTN"] = "";
                    dr1["PRODUCT_ADDL5_SIA_NOTN_SL"] = "";
                    dr1["PRODUCT_ADDL5_SIA_RATE"] = "";
                    dr1["PRODUCT_ADDL_GSI_NOTN"] = "";
                    dr1["PRODUCT_ADDL_GSI_SLNO"] = "";
                    dr1["PRODUCT_ADDL_GSI_RATE"] = "";
                    dr1["PRODUCT_ADDL_GSI_SPL"] = "";
                    dr1["PRODUCT_ADDL_GSI_UNIT"] = "";
                    dr1["PRODUCT_ADDL_GSI_SPL_TYPE"] = "";
                    dr1["PRODUCT_ADDL_SHEII_NOTN"] = "";
                    dr1["PRODUCT_ADDL_SHEII_SLNO"] = "";
                    dr1["PRODUCT_ADDL_SHEII_RATE"] = "";
                    dr1["PRODUCT_ADDL_SHEII_SPL"] = "";
                    dr1["PRODUCT_ADDL_SHEII_UNIT"] = "";
                    dr1["PRODUCT_ADDL_SHEII_TYPE"] = "";
                    dr1["PRODUCT_ADDL_TTA_NOTN"] = "";

                    dr1["PRODUCT_ADDL_TTA_SLNO"] = "";
                    dr1["PRODUCT_ADDL_TTA_RATE"] = "";
                    dr1["PRODUCT_ADDL_TTA_SPL"] = "";
                    dr1["PRODUCT_ADDL_TTA_UNIT"] = "";
                    dr1["PRODUCT_ADDL_TTA_TYPE"] = "";
                    dr1["PRODUCT_ADDL_HEALTH_CESS_NOTN"] = "";
                    dr1["PRODUCT_ADDL_HEALTH_CESS_SLNO"] = "";
                    dr1["PRODUCT_ADDL_HEALTH_CESS_RATE"] = "";
                    dr1["PRODUCT_ADDL_HEALTH_CESS_SPL"] = "";
                    dr1["PRODUCT_ADDL_HEALTH_CESS_UNIT"] = "";
                    dr1["PRODUCT_ADDL_HEALTH_CESS_TYPE"] = "";
                    dr1["PRODUCT_CESS_NOTN"] = "";
                    dr1["PRODUCT_CESS_SLNO"] = "";

                    dr1["PRODUCT_CESS_RATE"] = "";
                    dr1["PRODUCT_CESS_SPL"] = "";
                    dr1["PRODUCT_CESS_UNIT"] = "";
                    dr1["PRODUCT_CESS_TYPE"] = "";

                    dr1["ANTI_DUMPING_NOTN"] = "";
                    dr1["ANTI_DUMPING_NOTN_SLNO"] = "";
                    dr1["CTH_SLNO"] = "";
                    dr1["CTH_SUPPLIER_SLNO"] = "";
                    dr1["CTH_QTY"] = "";
                    dr1["RSP_DUTY_STATUS"] = "";
                    dr1["RSP_SL_NO"] = "";
                    dr1["RSP_DESC"] = "";
                    dr1["RSP_QTY"] = "";
                    dr1["RSP_AMOUNT"] = "";
                    dr1["RSP_NOTN_NO"] = "";
                    dr1["RSP_NOTN_SL_NO"] = "";
                    dr1["RSP_ABT_RATE"] = "";
                    dr1["WAREHOUSE_JOBNO"] = "0";
                    dr1["WAREHOUSE_INVOICE_SLNO"] = "0";
                    dr1["WAREHOUSE_ITEM_SLNO"] = "0";
                    dr1["ASSESSABLE_VALUE"] = "";

                    dr1["DUTY_VALUE"] = "";
                    dr1["CIF_VALUE"] = "";
                    dr1["CVD_VALUE"] = "";

                    dr1["USER_ID"] = currentuser;
                    dr1["DATE_TIME"] = "";
                    dr1["STATUS"] = "N";
                    dr1["BRANCH_CODE"] = currentbranch;

                    dr1["YEAR"] = "";
                    dr1["WORKING_PERIOD"] = Working_Period;

                    dsXML.Tables[1].Rows.Add(dr1);


                    //--------------------License Details--------------------------//

                   

                        if (ds.Tables[0].Rows.Count > c)
                        {
                          
                            string regno = ds.Tables[0].Rows[c][38].ToString();

                            if (regno != "")
                            {
                                DataRow dr2 = dsXML.Tables[2].NewRow();

                                dr2["LICENSE_ID"] = "";
                                dr2["JOBNO"] = IMPORT_JOBNO;
                                dr2["INVOICE_SLNO"] = ds.Tables[0].Rows[c][0].ToString();

                                dr2["ITEM_SLNO"] = ds.Tables[0].Rows[c][5].ToString();
                                //dr2["SCHEME_CODE"] = ds.Tables[0].Rows[b][35].ToString();
                                dr2["SCHEME_CODE"] = scheme;
                                licen_slno = licen_slno + 1;
                                dr2["LICENSE_SLNO"] = licen_slno;
                                dr2["REGISTRATION_NO"] = ds.Tables[0].Rows[c][38].ToString();

                                string REGISTRATION_DATE = ds.Tables[0].Rows[c][39].ToString();

                                if (REGISTRATION_DATE != "")
                                {
                                    string reg_date = Convert.ToDateTime(ds.Tables[0].Rows[c][39].ToString()).ToShortDateString();
                                    string reg_date1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(reg_date));


                                    dr2["REGISTRATION_DATE"] = DateTime.Parse(reg_date1, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                }
                                else
                                {
                                    REGISTRATION_DATE = "01/01/1900";
                                }

                                dr2["EXCEMPTION"] = ds.Tables[0].Rows[c][40].ToString();

                                dr2["DEBIT_AMT"] = "";
                                dr2["DEBIT_QTY"] = ds.Tables[0].Rows[c][6].ToString();
                                dr2["UNIT_QTY"] = ds.Tables[0].Rows[c][7].ToString();
                                dr2["LICENSE_ITEM_NO"] = ds.Tables[0].Rows[c][41].ToString();
                                dr2["PORT_OF_LICENSE"] = ds.Tables[0].Rows[c][42].ToString();


                                dr2["USER_ID"] = currentuser;
                                dr2["DATE_TIME"] = "";
                                dr2["STATUS"] = "S";
                                dr2["BRANCH_CODE"] = currentbranch;
                                dr2["YEAR"] = "";
                                dr2["WORKING_PERIOD"] = Working_Period;

                                dsXML.Tables[2].Rows.Add(dr2);

                                //for (int i = 0; i < dsXML.Tables[2].Rows.Count; i++)
                                //{
                                //    for (int j = 0; j < dsXML.Tables[2].Columns.Count; j++)
                                //    {
                                //        if (string.IsNullOrEmpty(dsXML.Tables[2].Rows[i].ToString()))
                                //        {
                                //            // Write your Custom Code
                                //            //dt.Rows[i][j] = "N/A";
                                //            dsXML.Tables[2].Rows[i].Delete();
                                //        }
                                //    }
                                //}

                            }
                            c++;
                        }
               

                    //--------------------End License Details--------------------------//


                    b++;
                }


                dt = dsXML.Tables["ItemDetails"];


                //--------------------------

                //int sum = 0;
                //foreach (DataRow dritem in dt.Rows)
                //{
                //    sum += Convert.ToInt32(dritem["ITEM_TOTAL_AMOUNT"]);
                //}
                //dr["INVOICE_VALUE"] = sum.ToString();

                //-------------------------------
                string dd = ds.Tables[0].Rows[a][1].ToString();
                var Values = from row in dsXML.Tables["ItemDetails"].AsEnumerable()
                             //group row by row.Field<string>("INVOICE_NO") into g
                             //group row by dd into g
                             group row by new { id = row.Field<string>("INVOICE_NO") } into g
                             select new
                             {
                                 name_1 = g.Key.id,

                                 name_2 = g.Sum(r => r.Field<double>("ITEM_TOTAL_AMOUNT"))



                             };
              
                foreach (var drval in Values)
                {
                    if (drval.name_1 == dd)
                        dr["INVOICE_VALUE"] = drval.name_2;
                }


                //-----------------Invoice Terms Calculation----------------------------//

                dr["MIS_FREIGHT_CHARGES"] = ds.Tables[0].Rows[a][10].ToString();
                dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][12].ToString();

                if (dr["MIS_FREIGHT_CHARGES"] == "" || dr["MIS_INSURANCE_CHARGES"] == "")
                {
                    if (Convert.ToString(dr["TERMS"]) == "FOB")
                    {
                        if (dr["MIS_FREIGHT_CHARGES"] == "")
                        {

                            dr["MIS_FREIGHT_RATE"] = "20.0000";

                            double invoicevalue_Excel = Convert.ToDouble(dr["INVOICE_VALUE"]);
                            cal = invoicevalue_Excel * 20 / 100;

                            //dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(cal);

                            dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal), 2).ToString("0.00"));

                            dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                            if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                            {
                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                            else
                            {

                                if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                {
                                    adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                    adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                    adm.EWorking_Period = Working_Period;

                                    ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                    if (ds3.Tables[0].Rows.Count > 0)
                                    {
                                        dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                    }

                                }
                                else
                                {
                                    dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                            }

                        }
                        else
                        {
                            //dr["MIS_FREIGHT_CHARGES"] = ds.Tables[0].Rows[a][10].ToString();

                            dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][10]), 2).ToString("0.00"));

                            dr["MIS_FREIGHT_RATE"] = "";
                            dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                            if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                            {
                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                            else
                            {
                                if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                {
                                    adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                    adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                    adm.EWorking_Period = Working_Period;

                                    ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                    if (ds3.Tables[0].Rows.Count > 0)
                                    {
                                        dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                    }

                                }
                                else
                                {
                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                            }
                        }

                        if (dr["MIS_INSURANCE_CHARGES"] == "")
                        {

                            dr["MIS_INSURANCE_RATE"] = "1.1250";

                            double invoicevalue_Excel1 = Convert.ToDouble(dr["INVOICE_VALUE"]);
                            cal1 = invoicevalue_Excel1 * 1.125 / 100;

                            //dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(cal1);

                            dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal1), 2).ToString("0.00"));

                            dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                            if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                            {
                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                            else
                            {

                                if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                {
                                    adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                    adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                    adm.EWorking_Period = Working_Period;

                                    ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                    if (ds4.Tables[0].Rows.Count > 0)
                                    {
                                        dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                    }

                                }
                                else
                                {
                                    dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                            }
                        }
                        else
                        {

                            //dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][12].ToString();

                            dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][12]), 2).ToString("0.00"));

                            dr["MIS_INSURANCE_RATE"] = "";
                            dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                            if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                            {
                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                            else
                            {

                                if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                {
                                    adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                    adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                    adm.EWorking_Period = Working_Period;

                                    ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                    if (ds4.Tables[0].Rows.Count > 0)
                                    {
                                        dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                    }

                                }
                                else
                                {
                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                            }


                        }


                    }


                    else if (Convert.ToString(dr["TERMS"]) == "CI")
                    {
                        if (dr["MIS_FREIGHT_CHARGES"] == "")
                        {
                            dr["MIS_FREIGHT_RATE"] = "20.0000";

                            double invoicevalue_Excel = Convert.ToDouble(dr["INVOICE_VALUE"]);
                            cal = invoicevalue_Excel * 20 / 100;

                            //dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(cal);

                            dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal), 2).ToString("0.00"));

                            dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                            if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                            {
                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                            else
                            {

                                if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                {
                                    adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                    adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                    adm.EWorking_Period = Working_Period;

                                    ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                    if (ds3.Tables[0].Rows.Count > 0)
                                    {
                                        dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                    }

                                }
                                else
                                {
                                    dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                            }
                        }

                        else
                        {
                            //dr["MIS_FREIGHT_CHARGES"] = ds.Tables[0].Rows[a][10].ToString();

                            dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][10]), 2).ToString("0.00"));

                            dr["MIS_FREIGHT_RATE"] = "";
                            dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                            if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                            {
                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                            else
                            {
                                if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                {
                                    adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                    adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                    adm.EWorking_Period = Working_Period;

                                    ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                    if (ds3.Tables[0].Rows.Count > 0)
                                    {
                                        dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                    }

                                }
                                else
                                {
                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                            }
                        }

                    }
                    else if (Convert.ToString(dr["TERMS"]) == "CF")
                    {
                        if (dr["MIS_INSURANCE_CHARGES"] == "")
                        {
                            dr["MIS_INSURANCE_RATE"] = "1.1250";

                            double invoicevalue_Excel1 = Convert.ToDouble(dr["INVOICE_VALUE"]);
                            cal1 = invoicevalue_Excel1 * 1.125 / 100;

                            //dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(cal1);

                            dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal1), 2).ToString("0.00"));

                            dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                            if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                            {
                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                            else
                            {

                                if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                {
                                    adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                    adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                    adm.EWorking_Period = Working_Period;

                                    ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                    if (ds4.Tables[0].Rows.Count > 0)
                                    {
                                        dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                    }

                                }
                                else
                                {
                                    dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                            }
                        }

                        else
                        {

                            //dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][12].ToString();

                            dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][12]), 2).ToString("0.00"));


                            dr["MIS_INSURANCE_RATE"] = "";
                            dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                            if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                            {
                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                            else
                            {

                                if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                {
                                    adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                    adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                    adm.EWorking_Period = Working_Period;

                                    ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                    if (ds4.Tables[0].Rows.Count > 0)
                                    {
                                        dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                    }

                                }
                                else
                                {
                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                            }


                        }

                    }
                    else if (Convert.ToString(dr["TERMS"]) == "CIF")
                    {

                    }
                }
                else
                {


                    dr["MIS_FREIGHT_CHARGES"] = ds.Tables[0].Rows[a][10].ToString();
                    dr["MIS_FREIGHT_RATE"] = "";
                    dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                    if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                    {
                        dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                    }
                    else
                    {

                        if (dr["MIS_FREIGHT_CURRENCY"] != "")
                        {
                            adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                            adm.Ename = "IMPORT_INVOICE_EX_RATE";
                            adm.EWorking_Period = Working_Period;

                            ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                            if (ds3.Tables[0].Rows.Count > 0)
                            {
                                dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                            }

                        }
                        else
                        {
                            dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                        }
                    }


                    dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][12].ToString();
                    dr["MIS_INSURANCE_RATE"] = "";
                    dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                    if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                    {
                        dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                    }
                    else
                    {

                        if (dr["MIS_INSURANCE_CURRENCY"] != "")
                        {
                            adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                            adm.Ename = "IMPORT_INVOICE_EX_RATE";
                            adm.EWorking_Period = Working_Period;

                            ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                            if (ds4.Tables[0].Rows.Count > 0)
                            {
                                dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                            }

                        }
                        else
                        {
                            dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                        }
                    }


                }




                //---------------------------End------------------------------------//

                dsXML.Tables[0].Rows.Add(dr);
                a++;
                //}

            }

        }

        dt = dsXML.Tables["InvoiceDetails"];
        //RemoveDuplicateRows(dt, "INVOICE_NO");

       
        //mdb.COMPANY_ID = txt_Company_Id.Value;
        //mdb.CUSTOM_HOUSE_ID = txt_Customhouse_Id.Value;
        //Transact.Bulk_Item_Excel_Upload(dsXML, "BULK_ITEM_UPLOAD");
       
       // int i = Transact.result;
        //Transact.Bulk_Item_Excel_Upload1(dt, dsXML.Tables[1], dsXML.Tables[2], "BULK_ITEM_UPLOAD");
        Transact.Bulk_Item_Excel_Upload(RemoveDuplicateRows(dt, "INVOICE_NO"), dsXML.Tables[1], dsXML.Tables[2], "BULK_ITEM_UPLOAD");

        if (Transact.result == 1)
        {
            Response.Redirect(Request.RawUrl);          
            //gridbind(inv_no, flag, TERMS, inv_slno);
            //string prompt = "<script>$(document).ready(function(){{jAlert('Excel Upload Successfully Finished', 'INVOICE', function (r) {document.location.reload();});}});</script>";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            //Alert_msg("Excel Upload Successfully Finished");
        }
        else
        {
            Alert_msg("Excel Upload occured some problem");
        }
    }

    
   
    // This method is used to delete duplicate rows of table
    public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    {
        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();
        foreach (DataRow dtRow in dTable.Rows)
        {
            if (hTable.Contains(dtRow[colName]))
                duplicateList.Add(dtRow);
            else
                hTable.Add(dtRow[colName], string.Empty);
        }
        foreach (DataRow dtRow in duplicateList)
            dTable.Rows.Remove(dtRow);
        return dTable;
    }


    public void addtoGallery1(string picName, string folderName)
    {
        string strFolderPath;
        string strImagePath;
        try
        {
            strFolderPath = Path.Combine(Request.PhysicalApplicationPath, folderName);
            strImagePath = Path.Combine(strFolderPath, picName);
            fileuploadExcel.SaveAs(strImagePath);

        }
        catch
        {
        }
        finally
        {
        }
    }
    public string fnGetPictureExtn(string pictureName)
    {
        try
        {
            if (pictureName.ToUpper().EndsWith(".JPG"))
                return ".JPG";
            else if (pictureName.ToUpper().EndsWith(".JPEG"))
                return ".JPEG";
            else if (pictureName.ToUpper().EndsWith(".GIF"))
                return ".GIF";
            else if (pictureName.ToUpper().EndsWith(".DOC"))
                return ".DOC";
            else if (pictureName.ToUpper().EndsWith(".XLS"))
                return ".XLS";
            else if (pictureName.ToUpper().EndsWith(".PDF"))
                return ".PDF";
            else if (pictureName.ToUpper().EndsWith(".PNG"))
                return ".PNG";
            else if (pictureName.ToUpper().EndsWith(".CDR"))
                return ".CDR";
            else if (pictureName.ToUpper().EndsWith(".PSD"))
                return ".PSD";
            else if (pictureName.ToUpper().EndsWith(".TXT"))
                return ".TXT";
            else if (pictureName.ToUpper().EndsWith(".XLSX"))
                return ".XLSX";
            else
            {
            }
        }
        catch
        {
        }
        finally
        {
        }
        return "";
    }

    public string Get_Scheme_Code(string scheme)
    {
        //----------------------SCHEME IMPORT MASTER-------------------------------//

        adm.SCHEME_IMPORT_CODE = scheme;
        adm.SCHEME_NOTN = "0";
        adm.name = "SCHEME_IMPORT_CODE";

        //ddlSchemeCode.DataSource = 
        ds_scheme=adm.RetrieveAll_Scheme_Import();
        if (ds_scheme.Tables[2].Rows.Count > 0)
        {
            scheme = ds_scheme.Tables[2].Rows[0]["SCHEME_CODE"].ToString();
        }

        return scheme;
    }
}