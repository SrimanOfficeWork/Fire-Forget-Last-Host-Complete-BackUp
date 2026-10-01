using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Collections;

public partial class Export_Invoice_Details : ThemeClass
{
    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    DataTable dt = new DataTable();
    AppSession aps = new AppSession();
    Export_Invoice Invoice = new Export_Invoice();
    Export_Licence License = new Export_Licence();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();
    Auto_Search Auto = new Auto_Search();
    DataSet ds_draw = new DataSet();
    DataSet ds_license = new DataSet();
    DataSet ds_product = new DataSet();
    DataSet ds_inv = new DataSet();
    DataSet ds_indev = new DataSet();
    DataSet ds_TPD = new DataSet();
    Date_Time rep = new Date_Time();
    string button_click = "";
    Export_General_New Export = new Export_General_New();
    string[] scheme_name = new string[2];

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string AUTO_ID;

    public int License_id_Max = 0;
    public int License_id_IMP_EXP_Max = 0;
    int ii = 0;
    int D_E = 0;
    public string[] lic_no;
    public int licno_Count;

    int sl = 0;
    int sl_E = 0;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH, DEFAULT_DATE;
    public string EXPORT_JOBNO, EXPORT_JOBDATE, sno;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    public decimal item_amt;
    public string scheme;
    public string COMPANY_IDD;

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    public string errorFolder = "", logline = "", logFileName = "", Audit_YN = "";
    public string folderName = "/Submission";

    public string createfilename = "";
    User_Creation user_Create = new User_Creation();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        try
        {
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            currentcomp_name = Session["currentcomp_name"].ToString();
            comp_ConnectionStr = Session["currentcomp_db"].ToString();
            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();
            COMPANY_IDD = Session["COMPANY_ID"].ToString();
            DEFAULT_DATE = Session["DEFAULT_DATE"].ToString();
            SELECT_BRANCH = Connection.Get_Company_Type();
            hdn_Branch.Value = SELECT_BRANCH;
            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Export_Excel");

            //----------------Remove the Session from ItemCopy ------------
            Session.Remove("EXP_ITEM_COPY_YN");
            Session["EXP_ITEM_COPY_YN"] = "No";
            //-------------------------------------------------------------    

            if (Connection.Audit_Logs(COMPANY_IDD) == "Y")
            {
                Audit_YN = "Y";
            }

            if (Session["EXPORT_JOBNO"] != null)
            {
                EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
                EXPORT_JOBDATE = Session["EXPORT_JOBDATE"].ToString();
                hdn_Jobno.Value = EXPORT_JOBNO;

                if (!IsPostBack)
                {
                    //----------------SETTING SCREEN PERMISSION---------------//
                    Screen_Id = 12;
                    Page_Rights(Screen_Id);
                    //----------------SETTING SCREEN PERMISSION---------------//

                    hdn_CompanyID.Value = COMPANY_IDD;
                    Get_ConsigneeName_SessionValue();

                    txtInvoiceNo.Focus();
                    Gridbind_INVOICE();
                    invoice_item_Count();
                                        
                    // start added by jayanthi on 19-Mar-22
                    if (ViewState["INVOICE_ID"] == "" || ViewState["INVOICE_ID"] == null)
                    {
                        if (Session["IsCHA_Mapped"] != null)
                        {
                            if (Session["FRT_EXP_JOBNO_CHA"] != null && Session["IsCHA_Mapped"].ToString() == "Y")
                            {
                                INV_Load_From_FRT();
                            }
                        }
                    }
                    // end  added by jayanthi on 19-Mar-22



                    if (Connection.Get_User_Exp_Settings_Job_Edit("INVOICE_BUYER_ADD_EDIT") == "E")
                    {
                        txtAddress.Attributes.Remove("readonly");
                        txtAddress1.Attributes.Remove("readonly");
                        txtAddress2.Attributes.Remove("readonly");
                        txtAddress3.Attributes.Remove("readonly");
                        txtAddress4.Attributes.Remove("readonly");
                        hdn_buyer_edit.Value = "E";
                    }

                    /* // Hided by pandiyan on 27-05-2025 due to clients asked to remove the condition sugg by rajalakshmi
                    if (Connection.COMPANYID() == "1593")//Jay chemical
                    {
                        txt_Authrzd_Economic_Code.Text = "INAAACJ7628J3F222";
                        txt_Authrzd_Economic_Country.Text = "IN";
                        txt_Authrzd_Economic_Role.Text = "T3";
                    }
                    */
                    if (Connection.COMPANYID() == "1559")//Top pearl
                    {
                        txt_Authrzd_Economic_Code.Text = "INAAECT0806C1F213";
                        txt_Authrzd_Economic_Country.Text = "IN";
                        txt_Authrzd_Economic_Role.Text = "T1";
                    }

                    if (Connection.COMPANYID() == "862")//Wollow Tree Global
                    {
                        if (Session["EXPORTER_NAME"] != null)
                        {
                            if (Session["EXPORTER_NAME"].ToString() == "SUNDARAM INDUSTRIES PRIVATE LIMITED")
                            {
                                txt_Authrzd_Economic_Code.Text = "INAAJFC7174Q0F246";
                                txt_Authrzd_Economic_Country.Text = "IN";
                                txt_Authrzd_Economic_Role.Text = "LO";
                            }
                        }
                    }
                }

                if (user_Create.THIRDPARTY_MASTER_yn == "False")
                {
                    dv_Thirdpartyname_popup.Visible = false;
                }

                if (user_Create.BUYER_MASTER_yn == "False")
                {
                    dv_mas_buyer_popup.Visible = false;
                    txtBuyerName.Enabled = false;
                    btn_BuyerMasedit.Visible = false;
                }
            }
            else
            {
                Response.Write("<script>window.parent.document.getElementById('General').click();</script>");
            }

            if (Session["EXPORT_SBTYPE"].ToString() == "SEZ")
            {
                DTA_Invoice.Visible = true;
            }

            //auto search

            //txtInvoiceCurrency.Attributes.Add("onkeyup", "javascript:Call_Excahnge_Rate('" + txtInvoiceCurrency.ClientID + "', '" + txtExRate.ClientID + "')");
            //txtInvoiceCurrency.Attributes.Add("onkeyup", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txtInvoiceCurrency.ClientID + "', '" + txtExchangeRate.ClientID + "')");
            txtInvoiceCurrency.Attributes.Add("onblur", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txtInvoiceCurrency.ClientID + "', '" + txtExchangeRate.ClientID + "')");
            //txtExchangeRate.Attributes.Add("onkeyup", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txtExchangeRate.ClientID + "', '" + hdn_Invoice_Currency_Exrate.ClientID + "')");
            //txtExchangeRate.Attributes.Add("onblur", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txtExchangeRate.ClientID + "', '" + hdn_Invoice_Currency_Exrate.ClientID + "')");

            txtFreight_Currency.Attributes.Add("onkeyup", "javascript:Call_Freight_Excahnge_Rate('" + txtFreight_Currency.ClientID + "', '" + hdn_Freight_Exrate.ClientID + "')");
            txtFreight_Currency.Attributes.Add("onblur", "javascript:Call_Freight_Excahnge_Rate('" + txtFreight_Currency.ClientID + "', '" + hdn_Freight_Exrate.ClientID + "')");

            txtInsurance_Currency.Attributes.Add("onkeyup", "javascript:Call_Insurance_Excahnge_Rate('" + txtInsurance_Currency.ClientID + "', '" + hdn_Insurance_Exrate.ClientID + "')");
            txtInsurance_Currency.Attributes.Add("onblur", "javascript:Call_Insurance_Excahnge_Rate('" + txtInsurance_Currency.ClientID + "', '" + hdn_Insurance_Exrate.ClientID + "')");

            txtBuyerName.Attributes.Add("onblur", "javascript:CallServerside_Consignee('" + txtBuyerName.ClientID + "', '" + txtAddress.ClientID + "')");
            txt_ThirdPartyName.Attributes.Add("onblur", "javascript:CallServerside_GetThirdParty('" + txt_ThirdPartyName.ClientID + "', '" + txtAddress.ClientID + "')");

            //txtInvoiceNo.Attributes.Add("onfocusout", "javascript:CallServerside_Get_DuplicateInvoice_No('" + txtInvoiceNo.ClientID + "', '" + EXPORT_JOBNO + "')");
            txtInvoiceNo.Attributes.Add("onblur", "javascript:CallServerside_Get_DuplicateInvoice_No('" + txtInvoiceNo.ClientID + "', '" + EXPORT_JOBNO + "')");

            //auto search
            if (!IsPostBack)
            {
                CalendarExtender1.EndDate = DateTime.Today; // Added by pandiyan on 17-05-2025 sugg by niyas for controlling the future dates

                if (COMPANY_IDD == "3416" || COMPANY_IDD == "1")
                {
                    pnl_ContractDate.Visible = true;
                    pnl_notifyName.Visible = true;
                    pnl_notifyAdd1.Visible = true;
                    pnl_notifyAdd2.Visible = true;
                    pnl_notifyAdd3.Visible = true;
                    pnl_notifyCountry.Visible = true;
                }

                if (COMPANY_IDD == "196" || COMPANY_IDD == "4" || COMPANY_IDD == "5")
                {
                    btn_Indev_Excel.Visible = true;
                }

                if (COMPANY_IDD == "4" || COMPANY_IDD == "10" || COMPANY_IDD == "589" || COMPANY_IDD == "1103" || COMPANY_IDD == "1572")
                {
                    btn_Shahi_Upload_AddInv.Visible = true;
                }

                if (COMPANY_IDD == "1029" || COMPANY_IDD == "4" || COMPANY_IDD == "10")
                {
                    lbl_DocRecd_Date.Visible = true;
                    txt_DocRecd_Date.Visible = true;
                }
                else
                {
                    lbl_DocRecd_Date.Visible = false;
                    txt_DocRecd_Date.Visible = false;
                }


                if (Directory.Exists(errorFolder) == false)
                {
                    Directory.CreateDirectory(errorFolder);
                }

                txtPackMisc_Rate.Attributes.Add("readonly", "readonly");

                txtCommission_Currency.Attributes.Add("readonly", "readonly");

                txtFOBDisc_Currency.Attributes.Add("readonly", "readonly");
                txtPackMisc_Currency.Attributes.Add("readonly", "readonly");
                txtOtherDeductions_Currency.Attributes.Add("readonly", "readonly");

                hdn_INVOICE_SLNO.Value = "";

                hdn_grid_edit.Value = "0";
                //--------------- dont delete-------------------------------------//
            }

            if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
            {
                JOB_LOCK = Session["JOB_LOCK"].ToString();

                if (Convert.ToInt32(JOB_LOCK) == 1)
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnNew.Enabled = false;
                    btnSave.Enabled = false;
                    btnSave_New.Enabled = false;
                    //btnMoveup.Enabled = false;
                    btngenexcel.Enabled = false;

                    btnNew.ToolTip = "This Job is Locked by Admin";
                    btnSave.ToolTip = "This Job is Locked by Admin";
                    btnUpdate.ToolTip = "This Job is Locked by Admin";
                    btnDelete.ToolTip = "This Job is Locked by Admin";
                    btnSave_New.ToolTip = "This Job is Locked by Admin";
                    //btnMoveup.ToolTip = "This Job is Locked by Admin";
                    btngenexcel.ToolTip = "This Job is Locked by Admin";
                }
            }

            if (Session["USER_JOB_LOCK"].ToString() == "Yes")
            {
                if (currentuser.ToUpper() != Session["JOB_USER"].ToString().ToUpper())
                {

                    if (Session["JOB_RELEASE"] != null && Session["JOB_RELEASE"] != "")
                    {
                        JOB_RELEASE = Session["JOB_RELEASE"].ToString();

                        if (JOB_RELEASE == "No")
                        {

                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;
                            btnNew.Enabled = false;
                            btnSave.Enabled = false;
                            btnSave_New.Enabled = false;
                            //btnMoveup.Enabled = false;
                            btngenexcel.Enabled = false;


                            MP_U.Show();

                            lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                            btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnDelete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnNew.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnSave.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnSave_New.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            // btnMoveup.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btngenexcel.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void INV_Load_From_FRT()
    {
        try
        {
            string trmode = Session["TRANSPORT_MODE"].ToString();
            DataSet ds = new DataSet();
            Transact.SEARCH_CAT = ""; Transact.SEARCH_ITEM = Session["FRT_EXP_JOBNO_CHA"].ToString();
            Transact.WORKING_PERIOD = currentbranch; Transact.TRANSPORT_MODE = trmode;

            if (trmode == "Air")
            {
                Transact.flag = "Export-Air-JobNo";
            }
            else if (trmode == "Sea")
            {
                Transact.flag = "Export-Sea-JobNo";
            }
            else if (trmode == "Land")
            {
                Transact.flag = "Export-Other-Jobno";
            }

            ds = Transact.FREIGHT_IMP_EXP_Job_Load();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtInvoiceNo.Text = ds.Tables[0].Rows[0]["INVOICENO"].ToString();
                    txtInvoiceDate.Text = ds.Tables[0].Rows[0]["INVOICEDATE"].ToString();
                    txtInvoiceValue.Text = ds.Tables[0].Rows[0]["INVOICEVALUE"].ToString();
                    txtInvoiceCurrency.Text = ds.Tables[0].Rows[0]["CURRENCY"].ToString();


                    txt_ThirdPartyName.Text = ds.Tables[0].Rows[0]["THIRDPARTYNAME"].ToString();
                    //txtSupplierAddress.Text = ds.Tables[0].Rows[0]["SUP_ADDRESS1"].ToString();
                    //txtSupplierAddress1.Text = ds.Tables[0].Rows[0]["SUP_ADDRESS2"].ToString();
                    //txtSupplierAddress2.Text = ds.Tables[0].Rows[0]["SUP_ADDRESS3"].ToString();
                    //txtSuppliercountry_pincode.Text = ds.Tables[0].Rows[0]["SUP_COUNTRYPIN"].ToString();
                    //txtSupplierCountryName.Text = ds.Tables[0].Rows[0]["SUP_COUNTRYNAME"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void Page_Rights(int i)
    {
        try
        {
            // user_Create.RetrieveAll_User_Screen_Rights_Details(i);//hide on 02-09-2026
            user_Create.RetrieveAll_User_Screen_Rights_Details_USERWISE_IEC_settings(i);
            PAGE_WRITE = user_Create.PAGE_WRITE;
            PAGE_READ = user_Create.PAGE_READ;
            PAGE_MODIFY = user_Create.PAGE_MODIFY;
            PAGE_DELETE = user_Create.PAGE_DELETE;
            hdn_Grid_Disable.Value = "";

            //---------------READ ONLY------------------//

            if (PAGE_READ == "False")
            {
                btnSave.Enabled = false;
                btnSave_New.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnNew.ToolTip = "You don't have permission to access";
                btnSave.ToolTip = "You don't have permission to access";
                btnSave_New.ToolTip = "You don't have permission to access";
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
                    btnSave_New.Enabled = true;
                    btnNew.Enabled = true;

                }
                else
                {
                    btnSave.Enabled = false;
                    btnSave_New.Enabled = false;
                    btnSave.ToolTip = "You don't have permission to access";
                    btnSave_New.ToolTip = "You don't have permission to access";
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
                    //hdn_Grid_Disable.Value = "1";


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
                    //hdn_Grid_Disable.Value = "1";


                }
            }
            //if (hdn_Grid_Disable.Value == "1")
            //    gv_Invoice.ToolTip = "You don't have permission to access";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void Gridbind_INVOICE()
    {
        try
        {
            Invoice.JOBNO = EXPORT_JOBNO;
            Invoice.INVOICE_NO = "";
            Invoice.WORKING_PERIOD = SELECT_BRANCH;
            Invoice.TERMS = "";
            Invoice.INVOICE_SLNO = "";
            Invoice.flag = "SELECT";
            ds_inv = Invoice.RetrieveAll_Invoice_Details();

            gv_Invoice.DataSource = ds_inv;
            gv_Invoice.DataBind();

            ViewState["INVOICE_DETAILS"] = ds_inv;
            ddlInv_SL_No.DataSource = ds_inv;
            ddlInv_SL_No.DataTextField = "INVOICE_SLNO";
            ddlInv_SL_No.DataValueField = "INVOICE_SLNO";
            ddlInv_SL_No.DataBind();

            //// ----Audit Modified Data -----------------------------------
            //if (Audit_YN == "Y")
            //{
            //    Tbl_Filed_Modified_History(ds_inv.Tables[1]);
            //}

            if (Audit_YN == "Y" && ViewState["dt_Prev_Table"] == null)
            {
                Tbl_Filed_Modified_History(ds_inv.Tables[1]);
            }

            // ---------------------------------------
            

            if (gv_Invoice.Rows.Count > 0)
            {
                ViewState["INVOICE_ID"] = gv_Invoice.Rows[0].Cells[45].Text.Replace("&nbsp;", "");
                if (!IsPostBack)
                {
                    INVOICE_Edit_UpdateDetails();
                }
            }
            else
            {
                btnUpdate.Visible = false;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void Bind_Invoice_Sl_No_Dropdown()
    {
        try
        {
            Invoice.JOBNO = EXPORT_JOBNO;
            Invoice.INVOICE_NO = "";
            Invoice.WORKING_PERIOD = SELECT_BRANCH;
            Invoice.TERMS = "";

            Invoice.INVOICE_SLNO = "";

            Invoice.flag = "SELECT";
            ds_inv = Invoice.RetrieveAll_Invoice_Details();

            ddlInv_SL_No.DataSource = ds_inv;
            ddlInv_SL_No.DataTextField = "INVOICE_SLNO";
            ddlInv_SL_No.DataValueField = "INVOICE_SLNO";
            ddlInv_SL_No.DataBind();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void Get_ProductValue()
    {
        try
        {
            Export_Item Item = new Export_Item();

            Item.JOBNO = EXPORT_JOBNO;
            Item.INVOICE_SLNO = "0";
            Item.ITEM_SLNO = "0";
            Item.ITEM_ID = "0";
            Item.INVOICE_NO = lblInvoiceNo.Text.Replace("&amp;", "&");

            Item.WORKING_PERIOD = SELECT_BRANCH;
            Item.Ename = "product_value";
            ds_product = Item.RetrieveAll_Item_Details();

            if (Item.TOTAL_ITEM_VALUE != "")
            {

                lblProductValue.Text = Item.TOTAL_ITEM_VALUE;

                if (ds_product.Tables[1].Rows.Count > 0)
                {
                    lblTotal_No_Of_Invoices.Text = ds_product.Tables[1].Rows[0]["TOTAL_NO_OF_INVOICE"].ToString();
                }
                else
                {
                    lblTotal_No_Of_Invoices.Text = "";
                }
            }
            else
            {
                lblProductValue.Text = "";
                if (ds_product.Tables[1].Rows.Count > 0)
                {
                    lblTotal_No_Of_Invoices.Text = ds_product.Tables[1].Rows[0]["TOTAL_NO_OF_INVOICE"].ToString();
                }
                else
                {
                    lblTotal_No_Of_Invoices.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public int Export_Invoice_Insert_Update(string Flag, string INV_ID)
    {
        try
        {
            //Export.JOBID = jobid;
            Invoice.INVOICE_ID = INV_ID;

            Invoice.JOBNO = EXPORT_JOBNO;
            Invoice.JOBDATE = EXPORT_JOBDATE;
            if (Flag == "S")
                Invoice.INVOICE_SLNO = "0";
            else
            {
                if (Session["INV_SLNO"] != null && Session["INV_SLNO"] != "")
                    Invoice.INVOICE_SLNO = Session["INV_SLNO"].ToString();

            }
            Invoice.INVOICE_NO = txtInvoiceNo.Text.ToUpper();
            Invoice.INVOICE_DATE = txtInvoiceDate.Text;
            Invoice.PAYMENT_METHOD = ddlPaymentMethod.SelectedValue.ToString();
            Invoice.PERIOD_PAYMENT = txtPeriodOfPayment.Text;
            Invoice.INVOICE_VALUE = txtInvoiceValue.Text;
            Invoice.INVOICE_CURRENCY = txtInvoiceCurrency.Text.ToUpper();
            Invoice.EXCHANGE_RATE = txtExchangeRate.Text;
            Invoice.CONTRACT_NO = txtContractNo.Text;
            Invoice.TERMS = ddlTerms.SelectedValue.ToString();
            Invoice.BUYER = ddlBuyer.SelectedValue.ToString();
            Invoice.BUYER_NAME = txtBuyerName.Text;
            Invoice.BUYER_ADDRESS = txtAddress.Text;
            Invoice.BUYER_ADDRESS1 = txtAddress1.Text;
            Invoice.BUYER_ADDRESS2 = txtAddress2.Text;
            Invoice.BUYER_ADDRESS3 = txtAddress3.Text;
            Invoice.BUYER_ADDRESS4 = txtAddress4.Text;
            Invoice.COMMISSION_RATE = txtCommission_Rate.Text;
            Invoice.COMMISSION_CHARGES = txtCommission_Charges.Text;
            Invoice.COMMISSION_CURRENCY = txtCommission_Currency.Text.ToUpper();
            Invoice.FOB_RATE = txtFOBDisc_Rate.Text;
            Invoice.FOB_CHARGES = txtFOBDisc_Charges.Text;
            Invoice.FOB_CURRENCY = txtFOBDisc_Currency.Text.ToUpper();
            Invoice.PACKMISC_RATE = txtPackMisc_Rate.Text;
            Invoice.PACKMISC_CHARGES = txtPackMisc_Charges.Text;
            Invoice.PACKMISC_CURRENCY = txtPackMisc_Currency.Text.ToUpper();
            Invoice.OTHER_DEDUCTION_RATE = txtOtherDeductions_Rate.Text;
            Invoice.OTHER_DEDUCTION_CHARGES = txtOtherDeductions_Charges.Text;
            Invoice.OTHER_DEDUCTION_CURRENCY = txtOtherDeductions_Currency.Text.ToUpper();
            Invoice.FREIGHT_RATE = txtFreight_Rate.Text;
            Invoice.FREIGHT_CHARGES = txtFreight_Charges.Text;


            if (ddlTerms.SelectedValue.ToString() == "FOB")
            {
                txtFreight_Currency.Text = txtInvoiceCurrency.Text.ToUpper();
                txtInsurance_Currency.Text = txtInvoiceCurrency.Text.ToUpper();
            }

            Invoice.FREIGHT_CURRENCY = txtFreight_Currency.Text.ToUpper();
            if (txtFreight_Currency.Text.ToUpper() == txtInvoiceCurrency.Text.ToUpper())
            {
                Invoice.FREIGHT_EXRATE = txtExchangeRate.Text;
            }
            else
            {
                Invoice.FREIGHT_EXRATE = hdn_Freight_Exrate.Value;
            }

            Invoice.INSURANCE_RATE = txtInsurance_Rate.Text;
            Invoice.INSURANCE_CHARGES = txtInsurance_Charges.Text;
            Invoice.INSURANCE_CURRENCY = txtInsurance_Currency.Text.ToUpper();

            if (txtInsurance_Currency.Text.ToUpper() == txtInvoiceCurrency.Text.ToUpper())
            {
                Invoice.INSURANCE_EXRATE = txtExchangeRate.Text;
            }
            else
            {
                Invoice.INSURANCE_EXRATE = hdn_Insurance_Exrate.Value;
            }

            Invoice.WHEATHER_UNIT_PRICE = ddlWhether.SelectedValue.ToString();

            Invoice.USER_ID = currentuser;
            Invoice.flag = Flag;
            Invoice.BRANCH_CODE = currentbranch;
            Invoice.WORKING_PERIOD = Working_Period;

            Invoice.NON_STD_EFFECT_DT_EXP = hdn_non_std_effect_dt.Value;
            Invoice.NON_STD_BANKNAME = hdn_non_std_bankname.Value;
            Invoice.NON_STD_CERTIFICATE_NO = hdn_non_std_cert_no.Value;
            Invoice.NON_STD_CERTIFICATE_DATE = hdn_non_std_cert_dt.Value;
            Invoice.BRANCH_COMMON = SELECT_BRANCH;

            Invoice.TERMS_PLACE = txt_TermsPlace.Text;
            Invoice.THIRDPARTY_NAME = txt_ThirdPartyName.Text;
            Invoice.THIRDPARTY_ADD1 = txt_ThirdParty_Add1.Text;
            Invoice.THIRDPARTY_ADD2 = txt_ThirdParty_Add2.Text;
            Invoice.THIRDPARTY_CITY = txt_ThirdParty_City.Text;
            Invoice.T_PARTY_COUNTRY_SUB_DIV = txt_Country_Division.Text;
            Invoice.T_PARTY_COUNTRY_CODE = txt_CountryCode.Text;
            Invoice.T_PARTY_PIN = txt_ThirdParty_Pin.Text;
            Invoice.AUTHORIZED_ECONOMIC_OPERATOR_CODE = txt_Authrzd_Economic_Code.Text;
            Invoice.A_E_O_COUNTRY = txt_Authrzd_Economic_Country.Text;
            Invoice.AUTHORIZED_ECONOMIC_OPERATOR = txt_Authrzd_Economic_Role.Text;
            Invoice.DOC_RECD_DATE = txt_DocRecd_Date.Text;

            Invoice.AMENDMENT_TYPE = ddl_AmendmentType.SelectedValue;
            Invoice.AMENDMENT_STATUS = "";
            Invoice.JOBNO_PS = Session["JOBNO_PS"].ToString();

            Invoice.CONTRACT_DATE = txtContractDate.Text;

            Invoice.NOTIFY_NAME = txt_thirdPartyNotifyName.Text;
            Invoice.NOTIFY_ADDRESS_1 = txt_thirdpartyNotifyAddress1.Text;
            Invoice.NOTIFY_ADDRESS_2 = txt_thirdpartyNotifyAddress2.Text;
            Invoice.NOTIFY_ADDRESS_3 = txt_thirdpartyNotifyAddress3.Text;
            Invoice.NOTIFY_ADDRESS_COUNTRY = txt_thirdpartyNotifyCountry.Text;

            //gv_Invoice.DataSource = Invoice.Export_Invoice_Details_insertupdate();

            //gv_Invoice.DataBind();
            //i = Invoice.result;


            Invoice.Export_Invoice_Details_insertupdate();
            i = Invoice.result;

            if (i == 1)
            {
                object selectedInvoiceId = ViewState["INVOICE_ID"];  
                Gridbind_INVOICE();
                ViewState["INVOICE_ID"] = selectedInvoiceId;
            }


            Textbox_Enable_Disable(ddlTerms.SelectedValue.ToString());
            Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, Session["INV_SLNO"].ToString(), "", "Invoice", Flag, "Insert");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return i;

    }

    protected void btn_save_new_Click(object sender, EventArgs e)
    {
        try
        {
            btnSave_Click(sender, e);
            if (i == 1)
            {
                btnNew_Click(sender, e);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        txtExchangeRate.Text = hdn_Invoice_Currency_Exrate.Value;
        try
        {
            if (txtCommission_Currency.Text.Length == 3)
            {
                if (txtFOBDisc_Currency.Text.Length == 3)
                {
                    if (txtPackMisc_Currency.Text.Length == 3)
                    {
                        if (txtOtherDeductions_Currency.Text.Length == 3)
                        {
                            string F = "S";
                            string INV_ID = "0";
                            i = Export_Invoice_Insert_Update(F, INV_ID);
                            HiddenField1.Value = Convert.ToString(Invoice.UPDATE_ID);
                            ViewState["INVOICE_ID"] = Convert.ToString(Invoice.UPDATE_ID);

                            if (i == 1)
                            {

                                //-----------------------FOR USER RIGHTS--------------------------------//
                                user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);

                                PAGE_MODIFY = user_Create.PAGE_MODIFY;


                                //---------------SAVE ONLY------------------//

                                if (PAGE_MODIFY == "False")
                                {
                                    btnNew_Click(sender, e);

                                }
                                else
                                {
                                    btnUpdate.CssClass = "save";
                                    btnUpdate.Visible = true;
                                    btnSave.Visible = false;
                                    btnSave_New.Visible = false;

                                    //txtInvoiceNo.Focus();
                                }
                                //-----------------------FOR USER RIGHTS--------------------------------//

                                Get_ProductValue();

                                ViewState["UPDATED_ID"] = null;
                                Elogix_Service();
                                Alert_msg("Invoice Saved Successfully", "btnSave");


                                if (gv_Invoice.Rows.Count > 0)
                                {

                                    gv_Invoice.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                                    GridViewRow saverow = gv_Invoice.Rows[gv_Invoice.Rows.Count - 1];
                                    saverow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                                    saverow.Font.Bold = true;
                                }

                                if (gv_Invoice.Rows.Count != 1)
                                {
                                    GridViewRow firstrow = gv_Invoice.Rows[0];
                                    firstrow.BackColor = System.Drawing.Color.White;
                                    firstrow.Font.Bold = false;
                                }
                                Bind_Invoice_Sl_No_Dropdown();
                            }
                            else if (i == 2)
                            {
                                Alert_msg("Invoice No Already Exist!", "btnSave");
                            }
                            else
                            {
                                Alert_msg("Invoice Not Saved", "btnSave");
                            }

                        }
                        else
                        {
                            Alert_msg("Other Deductions Currency Should be 3 Characters", txtOtherDeductions_Currency.Text);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "check_Currency()", true);
                        }
                    }
                    else
                    {
                        Alert_msg("Pack & MISC Currency Should be 3 Characters", txtPackMisc_Currency.Text);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "check_Currency()", true);
                    }
                }
                else
                {
                    Alert_msg("FOB Disc Currency Should be 3 Characters", txtFOBDisc_Currency.Text);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "check_Currency()", true);
                }
            }
            else
            {
                Alert_msg("Commission Currency Should be 3 Characters", txtCommission_Currency.Text);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "check_Currency()", true);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void gv_Invoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gv_Invoice.PageIndex = e.NewPageIndex;
            Gridbind_INVOICE();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";

            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal_2";

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void gv_Invoice_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                {
                    if (HD_select.Value == "")
                    {
                        e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                        e.Row.Font.Bold = true;
                    }

                    if (Convert.ToInt32(ViewState["Select"]) != 1 && Convert.ToInt32(ViewState["Select"]) != 0)
                    {
                        e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                        e.Row.Font.Bold = true;
                        HD_select.Value = "1";
                    }
                }

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

                    gv_Invoice.SelectedRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                    e.Row.CssClass = "normal_2";

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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void INVOICE_Edit_UpdateDetails()
    {
        try
        {
            if (ViewState["INVOICE_ID"] != "" && ViewState["INVOICE_ID"] != null)
            {
                AR4_Details.Visible = true;
                hdn_grid_edit.Value = "1";

                btnUpdate.CssClass = "updates";
                btnSave.Visible = false;
                btnSave_New.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                //btnSave.Text = "Add";
                //btnSave.Enabled = true;


                HiddenField1.Value = ViewState["INVOICE_ID"].ToString();
                Label s_itemType = gv_Invoice.Rows[0].FindControl("lblFullName") as Label;
                Session["_SLNO"] = s_itemType.Text;
                hdn_INVOICE_SLNO.Value = s_itemType.Text;
                sno = gv_Invoice.Rows[0].Cells[2].Text;
                ViewState["INV_SLNO"] = gv_Invoice.Rows[0].Cells[2].Text;
                Session["INV_SLNO"] = hdn_inv_slno.Value = sno;

                txtInvoiceNo.Text = gv_Invoice.Rows[0].Cells[3].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                ViewState["Invoice_No"] = gv_Invoice.Rows[0].Cells[3].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                //Session["EXPORT_INV_NO"] = gv_Invoice.SelectedRow.Cells[3].Text.Replace("&nbsp;", ""); ;
                txtInvoiceDate.Text = gv_Invoice.Rows[0].Cells[4].Text.Replace("01/01/1900", "");
                txtInvoiceValue.Text = gv_Invoice.Rows[0].Cells[5].Text.Replace("&nbsp;", "");
                txtInvoiceCurrency.Text = gv_Invoice.Rows[0].Cells[6].Text.Replace("&nbsp;", "");
                txtExchangeRate.Text = gv_Invoice.Rows[0].Cells[7].Text.Replace("&nbsp;", "");
                txtContractNo.Text = gv_Invoice.Rows[0].Cells[8].Text.Replace("&nbsp;", "");

                txtContractDate.Text = gv_Invoice.Rows[0].Cells[59].Text.Replace("01/01/1900", "");

                string terms = gv_Invoice.Rows[0].Cells[9].Text.Replace("&nbsp;", "");
                if (terms == "FOB")
                {
                    txtFreight_Rate.Enabled = false;
                    txtFreight_Charges.Enabled = false;
                    txtFreight_Currency.Enabled = false;
                    txtInsurance_Rate.Enabled = false;
                    txtInsurance_Charges.Enabled = false;
                    txtInsurance_Currency.Enabled = false;

                }
                if (terms == "CIF")
                {
                    txtFreight_Rate.Enabled = (hdn_CompanyID.Value == "3267") ? true : false; //This line code added by Ayyappan.S on 25-03-2026
                    txtFreight_Charges.Enabled = true;
                    txtFreight_Currency.Enabled = true;
                    txtInsurance_Rate.Enabled = true;
                    txtInsurance_Charges.Enabled = true;
                    txtInsurance_Currency.Enabled = true;
                }
                if (terms == "CI")
                {
                    txtFreight_Rate.Enabled = false;
                    txtFreight_Charges.Enabled = false;
                    txtFreight_Currency.Enabled = false;
                    txtInsurance_Rate.Enabled = true;
                    txtInsurance_Charges.Enabled = true;
                    txtInsurance_Currency.Enabled = true;
                }
                if (terms == "CF")
                {
                    txtFreight_Rate.Enabled = (hdn_CompanyID.Value == "3267") ? true : false; //This line code added by Ayyappan.S on 25-03-2026
                    txtFreight_Charges.Enabled = true;
                    txtFreight_Currency.Enabled = true;
                    txtInsurance_Rate.Enabled = false;
                    txtInsurance_Charges.Enabled = false;
                    txtInsurance_Currency.Enabled = false;
                }

                ddlTerms.Items.Clear();
                ddlTerms.Items.Add("FOB");
                ddlTerms.Items.Add("CIF");
                ddlTerms.Items.Add("CI");
                ddlTerms.Items.Add("CF");
                ddlTerms.Items.Remove(terms);
                ddlTerms.Items.Insert(0, terms);

                string BUYER = gv_Invoice.Rows[0].Cells[10].Text.Replace("&nbsp;", "");
                ddlBuyer.Items.Clear();

                if (BUYER == "Y")
                {
                    ddlBuyer.Items.Add("Yes");
                    ddlBuyer.Items.Add("No");
                    txtBuyerName.Attributes.Add("readonly", "readonly");
                    href_Buyer_YN.Style.Add("display", "none");
                    //href_Buyer_YN_New.Attributes.Add("display", "none");
                    //btn_BuyerMasedit.Visible = false;

                    txtAddress.Text = "";
                    txtAddress1.Text = "";
                    txtAddress2.Text = "";
                    txtAddress3.Text = "";
                    txtAddress4.Text = "";

                }
                else
                {
                    ddlBuyer.Items.Add("No");
                    ddlBuyer.Items.Add("Yes");
                    txtBuyerName.Attributes.Remove("readonly");
                    href_Buyer_YN.Style.Add("display", "Block");
                    //href_Buyer_YN_New.Style.Add("display", "Block");
                }

                Date_Time rep = new Date_Time();

                txtBuyerName.Text = rep.Replace(gv_Invoice.Rows[0].Cells[11].Text);

                txtAddress.Text = rep.Replace(gv_Invoice.Rows[0].Cells[12].Text);
                txtAddress1.Text = rep.Replace(gv_Invoice.Rows[0].Cells[13].Text);
                txtAddress2.Text = rep.Replace(gv_Invoice.Rows[0].Cells[14].Text);
                txtAddress3.Text = rep.Replace(gv_Invoice.Rows[0].Cells[15].Text);
                txtAddress4.Text = rep.Replace(gv_Invoice.Rows[0].Cells[16].Text);

                txtCommission_Rate.Text = gv_Invoice.Rows[0].Cells[17].Text.Replace("&nbsp;", "");
                txtCommission_Charges.Text = gv_Invoice.Rows[0].Cells[18].Text.Replace("&nbsp;", "");
                txtCommission_Currency.Text = gv_Invoice.Rows[0].Cells[19].Text.Replace("&nbsp;", "");
                txtFOBDisc_Rate.Text = gv_Invoice.Rows[0].Cells[20].Text.Replace("&nbsp;", "");
                txtFOBDisc_Charges.Text = gv_Invoice.Rows[0].Cells[21].Text.Replace("&nbsp;", "");
                txtFOBDisc_Currency.Text = gv_Invoice.Rows[0].Cells[22].Text.Replace("&nbsp;", "");
                txtPackMisc_Rate.Text = gv_Invoice.Rows[0].Cells[23].Text.Replace("&nbsp;", "");
                txtPackMisc_Charges.Text = gv_Invoice.Rows[0].Cells[24].Text.Replace("&nbsp;", "");
                txtPackMisc_Currency.Text = gv_Invoice.Rows[0].Cells[25].Text.Replace("&nbsp;", "");
                txtOtherDeductions_Rate.Text = gv_Invoice.Rows[0].Cells[26].Text.Replace("&nbsp;", "");
                txtOtherDeductions_Charges.Text = gv_Invoice.Rows[0].Cells[27].Text.Replace("&nbsp;", "");
                txtOtherDeductions_Currency.Text = gv_Invoice.Rows[0].Cells[28].Text.Replace("&nbsp;", "");
                txtFreight_Rate.Text = gv_Invoice.Rows[0].Cells[29].Text.Replace("&nbsp;", "");
                txtFreight_Charges.Text = gv_Invoice.Rows[0].Cells[30].Text.Replace("&nbsp;", "");
                txtFreight_Currency.Text = gv_Invoice.Rows[0].Cells[31].Text.Replace("&nbsp;", "");
                txtInsurance_Rate.Text = gv_Invoice.Rows[0].Cells[32].Text.Replace("&nbsp;", "");
                txtInsurance_Charges.Text = gv_Invoice.Rows[0].Cells[33].Text.Replace("&nbsp;", "");
                txtInsurance_Currency.Text = gv_Invoice.Rows[0].Cells[34].Text.Replace("&nbsp;", "");

                string Whether = gv_Invoice.Rows[0].Cells[35].Text.Replace("&nbsp;", "");
                ddlWhether.Items.Clear();
                ddlWhether.Items.Add("F");
                ddlWhether.Items.Add("I");
                ddlWhether.Items.Add("B");
                ddlWhether.Items.Add("N");
                ddlWhether.Items.Remove(Whether);
                ddlWhether.Items.Insert(0, Whether);



                string Payment = gv_Invoice.Rows[0].Cells[36].Text.Replace("&nbsp;", "");
                ddlPaymentMethod.Items.Clear();
                ddlPaymentMethod.Items.Add("AP");
                ddlPaymentMethod.Items.Add("LC");
                ddlPaymentMethod.Items.Add("DP");
                ddlPaymentMethod.Items.Add("NA");
                ddlPaymentMethod.Items.Add("DA");
                ddlPaymentMethod.Items.Remove(Payment);
                ddlPaymentMethod.Items.Insert(0, Payment);



                txtPeriodOfPayment.Text = gv_Invoice.Rows[0].Cells[37].Text.Replace("&nbsp;", "");
                hdn_Freight_Exrate.Value = gv_Invoice.Rows[0].Cells[38].Text.Replace("&nbsp;", "");
                hdn_Insurance_Exrate.Value = gv_Invoice.Rows[0].Cells[39].Text.Replace("&nbsp;", "");


                hdn_non_std_effect_dt.Value = gv_Invoice.Rows[0].Cells[41].Text.Replace("&nbsp;", "");
                hdn_non_std_bankname.Value = gv_Invoice.Rows[0].Cells[42].Text.Replace("&nbsp;", "");
                hdn_non_std_cert_no.Value = gv_Invoice.Rows[0].Cells[43].Text.Replace("&nbsp;", "");
                hdn_non_std_cert_dt.Value = gv_Invoice.Rows[0].Cells[44].Text.Replace("&nbsp;", "");

                //SINGLE WINDOW OPERATION LOADING       

                txt_TermsPlace.Text = gv_Invoice.Rows[0].Cells[46].Text.Replace("&nbsp;", "");
                txt_ThirdPartyName.Text = gv_Invoice.Rows[0].Cells[47].Text.Replace("&nbsp;", "");
                txt_ThirdParty_Add1.Text = gv_Invoice.Rows[0].Cells[48].Text.Replace("&nbsp;", "");
                txt_ThirdParty_Add2.Text = gv_Invoice.Rows[0].Cells[49].Text.Replace("&nbsp;", "");
                txt_ThirdParty_City.Text = gv_Invoice.Rows[0].Cells[50].Text.Replace("&nbsp;", "");
                txt_Country_Division.Text = gv_Invoice.Rows[0].Cells[51].Text.Replace("&nbsp;", "");
                txt_CountryCode.Text = gv_Invoice.Rows[0].Cells[52].Text.Replace("&nbsp;", "");
                txt_ThirdParty_Pin.Text = gv_Invoice.Rows[0].Cells[53].Text.Replace("&nbsp;", "");
                txt_Authrzd_Economic_Code.Text = gv_Invoice.Rows[0].Cells[54].Text.Replace("&nbsp;", "");
                txt_Authrzd_Economic_Country.Text = gv_Invoice.Rows[0].Cells[55].Text.Replace("&nbsp;", "");
                txt_Authrzd_Economic_Role.Text = gv_Invoice.Rows[0].Cells[56].Text.Replace("&nbsp;", "");
                txt_DocRecd_Date.Text = gv_Invoice.Rows[0].Cells[57].Text.Replace("&nbsp;", "");


                txt_thirdPartyNotifyName.Text = gv_Invoice.Rows[0].Cells[60].Text.Replace("&nbsp;", "");
                txt_thirdpartyNotifyAddress1.Text = gv_Invoice.Rows[0].Cells[61].Text.Replace("&nbsp;", "");
                txt_thirdpartyNotifyAddress2.Text = gv_Invoice.Rows[0].Cells[62].Text.Replace("&nbsp;", "");
                txt_thirdpartyNotifyAddress3.Text = gv_Invoice.Rows[0].Cells[63].Text.Replace("&nbsp;", "");
                txt_thirdpartyNotifyCountry.Text = gv_Invoice.Rows[0].Cells[64].Text.Replace("&nbsp;", "");


                if (!string.IsNullOrEmpty(Session["SB_NO"].ToString()))
                {
                    div_AmendmentType.Visible = true;
                    ddl_AmendmentType.SelectedValue = gv_Invoice.Rows[0].Cells[58].Text.Replace("&nbsp;", "");
                }

                //END

                lblInvoiceNo.Text = txtInvoiceNo.Text;
                lblInvoiceDate.Text = txtInvoiceDate.Text;
                lblInvoiceCurrency.Text = txtInvoiceCurrency.Text.ToUpper();
                lblInvoiceTerms.Text = ddlTerms.SelectedValue;
                lblInvoiceValue.Text = txtInvoiceValue.Text;
                //lblProductValue.Text=

                Get_ProductValue();
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["INVOICE_ID"].ToString();
                //FOR UPDATED SUCCESSFULLY

                //------------------Audit Modified column History-------------------
                if (Audit_YN == "Y")
                {
                    DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"]);
                }

            }
            else
            {
                hdn_grid_edit.Value = "0";
                AR4_Details.Visible = false;

                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnSave_New.Visible = true;
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void gv_Invoice_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlInv_SL_No.SelectedValue = (gv_Invoice.SelectedIndex + 1).ToString();

            ViewState["Select"] = 1;
            ViewState["Newbtn"] = 1;
            HD_select.Value = "1";

            gv_Invoice.SelectedRowStyle.Font.Bold = true;
            gv_Invoice.SelectedRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
            ViewState["new_id"] = 1;

            GridViewRow firstRow = gv_Invoice.Rows[0];
            if (Convert.ToInt32(ViewState["id"]) == 1)
            {
                int ID;
                ID = gv_Invoice.SelectedIndex;
                if (ID == 0)
                {
                    firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                }
                else
                {
                    firstRow.BackColor = System.Drawing.Color.White;
                    firstRow.Font.Bold = false;
                }
                ViewState["id"] = "0";
            }
            else
            {
                int ID;
                ID = gv_Invoice.SelectedIndex;

                if (ID == 0)
                {
                    firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                    firstRow.Font.Bold = true;
                }
                else
                {
                    firstRow.BackColor = System.Drawing.Color.White;
                    firstRow.Font.Bold = false;
                }


            }
            int row_id;
            row_id = gv_Invoice.SelectedIndex;


            if (row_id != gv_Invoice.Rows.Count - 1)
            {
                GridViewRow Maxrow = gv_Invoice.Rows[gv_Invoice.Rows.Count - 1];
                Maxrow.BackColor = System.Drawing.Color.White;
                Maxrow.Font.Bold = false;

            }

            if (row_id == gv_Invoice.Rows.Count - 1)
            {
                GridViewRow Maxrow = gv_Invoice.Rows[gv_Invoice.Rows.Count - 1];
                Maxrow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                Maxrow.Font.Bold = true;
            }

            gv_Invoice.SelectedRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
            ViewState["INVOICE_ID"] = Convert.ToString(this.gv_Invoice.SelectedDataKey.Value);

            if (ViewState["INVOICE_ID"] != "" && ViewState["INVOICE_ID"] != null)
            {
                AR4_Details.Visible = true;
                hdn_grid_edit.Value = "1";

                btnUpdate.CssClass = "updates";
                btnSave.Visible = false;
                btnSave_New.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;

                HiddenField1.Value = ViewState["INVOICE_ID"].ToString();
                Label s_itemType = gv_Invoice.SelectedRow.FindControl("lblFullName") as Label;
                Session["_SLNO"] = s_itemType.Text;
                hdn_INVOICE_SLNO.Value = s_itemType.Text;
                sno = gv_Invoice.SelectedRow.Cells[2].Text;
                ViewState["INV_SLNO"] = gv_Invoice.SelectedRow.Cells[2].Text;
                Session["INV_SLNO"] = hdn_inv_slno.Value = sno;

                txtInvoiceNo.Text = gv_Invoice.SelectedRow.Cells[3].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                ViewState["Invoice_No"] = gv_Invoice.SelectedRow.Cells[3].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                //Session["EXPORT_INV_NO"] = gv_Invoice.SelectedRow.Cells[3].Text.Replace("&nbsp;", ""); ;
                txtInvoiceDate.Text = gv_Invoice.SelectedRow.Cells[4].Text.Replace("01/01/1900", "");
                txtInvoiceValue.Text = gv_Invoice.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                txtInvoiceCurrency.Text = gv_Invoice.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
                txtExchangeRate.Text = gv_Invoice.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
                txtContractNo.Text = gv_Invoice.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

                txtContractDate.Text = gv_Invoice.SelectedRow.Cells[59].Text.Replace("01/01/1900", "");

                string terms = gv_Invoice.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
                if (terms == "FOB")
                {
                    txtFreight_Rate.Enabled = false;
                    txtFreight_Charges.Enabled = false;
                    txtFreight_Currency.Enabled = false;
                    txtInsurance_Rate.Enabled = false;
                    txtInsurance_Charges.Enabled = false;
                    txtInsurance_Currency.Enabled = false;

                }
                if (terms == "CIF")
                {
                    txtFreight_Rate.Enabled = (hdn_CompanyID.Value == "3267") ? true : false; //This line code added by Ayyappan on 25-03-2026
                    txtFreight_Charges.Enabled = true;
                    txtFreight_Currency.Enabled = true;
                    txtInsurance_Rate.Enabled = true;
                    txtInsurance_Charges.Enabled = true;
                    txtInsurance_Currency.Enabled = true;
                }
                if (terms == "CI")
                {
                    txtFreight_Rate.Enabled = false; ;
                    txtFreight_Charges.Enabled = false;
                    txtFreight_Currency.Enabled = false;
                    txtInsurance_Rate.Enabled = true;
                    txtInsurance_Charges.Enabled = true;
                    txtInsurance_Currency.Enabled = true;
                }
                if (terms == "CF")
                {
                    txtFreight_Rate.Enabled = (hdn_CompanyID.Value == "3267") ? true : false;  //This line code added by Ayyappan on 25-03-2026
                    txtFreight_Charges.Enabled = true;
                    txtFreight_Currency.Enabled = true;
                    txtInsurance_Rate.Enabled = false;
                    txtInsurance_Charges.Enabled = false;
                    txtInsurance_Currency.Enabled = false;
                }

                ddlTerms.Items.Clear();
                ddlTerms.Items.Add("FOB");
                ddlTerms.Items.Add("CIF");
                ddlTerms.Items.Add("CI");
                ddlTerms.Items.Add("CF");
                ddlTerms.Items.Remove(terms);
                ddlTerms.Items.Insert(0, terms);

                string BUYER = gv_Invoice.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
                ddlBuyer.Items.Clear();
                if (BUYER == "Y")
                {
                    ddlBuyer.Items.Add("Yes");
                    ddlBuyer.Items.Add("No");
                    txtBuyerName.Attributes.Add("readonly", "readonly");
                    href_Buyer_YN.Style.Add("display", "none");
                    //href_Buyer_YN_New.Attributes.Add("display", "none");
                    // btn_BuyerMasedit.Visible = false;
                }
                else
                {
                    ddlBuyer.Items.Add("No");
                    ddlBuyer.Items.Add("Yes");
                    txtBuyerName.Attributes.Remove("readonly");
                    href_Buyer_YN.Style.Add("display", "Block");
                    //href_Buyer_YN_New.Style.Add("display", "Block");
                    //  btn_BuyerMasedit.Visible = true;
                }

                Date_Time rep = new Date_Time();
                txtBuyerName.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[11].Text);
                txtAddress.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[12].Text);
                txtAddress1.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[13].Text);
                txtAddress2.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[14].Text);
                txtAddress3.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[15].Text);
                txtAddress4.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[16].Text);
                txtCommission_Rate.Text = gv_Invoice.SelectedRow.Cells[17].Text.Replace("&nbsp;", "");
                txtCommission_Charges.Text = gv_Invoice.SelectedRow.Cells[18].Text.Replace("&nbsp;", "");
                txtCommission_Currency.Text = gv_Invoice.SelectedRow.Cells[19].Text.Replace("&nbsp;", "");
                txtFOBDisc_Rate.Text = gv_Invoice.SelectedRow.Cells[20].Text.Replace("&nbsp;", "");
                txtFOBDisc_Charges.Text = gv_Invoice.SelectedRow.Cells[21].Text.Replace("&nbsp;", "");
                txtFOBDisc_Currency.Text = gv_Invoice.SelectedRow.Cells[22].Text.Replace("&nbsp;", "");
                txtPackMisc_Rate.Text = gv_Invoice.SelectedRow.Cells[23].Text.Replace("&nbsp;", "");
                txtPackMisc_Charges.Text = gv_Invoice.SelectedRow.Cells[24].Text.Replace("&nbsp;", "");
                txtPackMisc_Currency.Text = gv_Invoice.SelectedRow.Cells[25].Text.Replace("&nbsp;", "");
                txtOtherDeductions_Rate.Text = gv_Invoice.SelectedRow.Cells[26].Text.Replace("&nbsp;", "");
                txtOtherDeductions_Charges.Text = gv_Invoice.SelectedRow.Cells[27].Text.Replace("&nbsp;", "");
                txtOtherDeductions_Currency.Text = gv_Invoice.SelectedRow.Cells[28].Text.Replace("&nbsp;", "");
                txtFreight_Rate.Text = gv_Invoice.SelectedRow.Cells[29].Text.Replace("&nbsp;", "");
                txtFreight_Charges.Text = gv_Invoice.SelectedRow.Cells[30].Text.Replace("&nbsp;", "");
                txtFreight_Currency.Text = gv_Invoice.SelectedRow.Cells[31].Text.Replace("&nbsp;", "");
                txtInsurance_Rate.Text = gv_Invoice.SelectedRow.Cells[32].Text.Replace("&nbsp;", "");
                txtInsurance_Charges.Text = gv_Invoice.SelectedRow.Cells[33].Text.Replace("&nbsp;", "");
                txtInsurance_Currency.Text = gv_Invoice.SelectedRow.Cells[34].Text.Replace("&nbsp;", "");

                string Whether = gv_Invoice.SelectedRow.Cells[35].Text.Replace("&nbsp;", "");
                ddlWhether.Items.Clear();
                ddlWhether.Items.Add("F");
                ddlWhether.Items.Add("I");
                ddlWhether.Items.Add("B");
                ddlWhether.Items.Add("N");
                ddlWhether.Items.Remove(Whether);
                ddlWhether.Items.Insert(0, Whether);



                string Payment = gv_Invoice.SelectedRow.Cells[36].Text.Replace("&nbsp;", "");
                ddlPaymentMethod.Items.Clear();
                ddlPaymentMethod.Items.Add("AP");
                ddlPaymentMethod.Items.Add("LC");
                ddlPaymentMethod.Items.Add("DP");
                ddlPaymentMethod.Items.Add("NA");
                ddlPaymentMethod.Items.Add("DA");
                ddlPaymentMethod.Items.Remove(Payment);
                ddlPaymentMethod.Items.Insert(0, Payment);



                txtPeriodOfPayment.Text = gv_Invoice.SelectedRow.Cells[37].Text.Replace("&nbsp;", "");
                hdn_Freight_Exrate.Value = gv_Invoice.SelectedRow.Cells[38].Text.Replace("&nbsp;", "");
                hdn_Insurance_Exrate.Value = gv_Invoice.SelectedRow.Cells[39].Text.Replace("&nbsp;", "");


                hdn_non_std_effect_dt.Value = gv_Invoice.SelectedRow.Cells[41].Text.Replace("&nbsp;", "");
                hdn_non_std_bankname.Value = gv_Invoice.SelectedRow.Cells[42].Text.Replace("&nbsp;", "");
                hdn_non_std_cert_no.Value = gv_Invoice.SelectedRow.Cells[43].Text.Replace("&nbsp;", "");
                hdn_non_std_cert_dt.Value = gv_Invoice.SelectedRow.Cells[44].Text.Replace("&nbsp;", "");

                //SINGLE WINDOW OPERATION LOADING       

                txt_TermsPlace.Text = gv_Invoice.SelectedRow.Cells[46].Text.Replace("&nbsp;", "");
                txt_ThirdPartyName.Text = gv_Invoice.SelectedRow.Cells[47].Text.Replace("&nbsp;", "");
                txt_ThirdParty_Add1.Text = gv_Invoice.SelectedRow.Cells[48].Text.Replace("&nbsp;", "");
                txt_ThirdParty_Add2.Text = gv_Invoice.SelectedRow.Cells[49].Text.Replace("&nbsp;", "");
                txt_ThirdParty_City.Text = gv_Invoice.SelectedRow.Cells[50].Text.Replace("&nbsp;", "");
                txt_Country_Division.Text = gv_Invoice.SelectedRow.Cells[51].Text.Replace("&nbsp;", "");
                txt_CountryCode.Text = gv_Invoice.SelectedRow.Cells[52].Text.Replace("&nbsp;", "");
                txt_ThirdParty_Pin.Text = gv_Invoice.SelectedRow.Cells[53].Text.Replace("&nbsp;", "");
                txt_Authrzd_Economic_Code.Text = gv_Invoice.SelectedRow.Cells[54].Text.Replace("&nbsp;", "");
                txt_Authrzd_Economic_Country.Text = gv_Invoice.SelectedRow.Cells[55].Text.Replace("&nbsp;", "");
                txt_Authrzd_Economic_Role.Text = gv_Invoice.SelectedRow.Cells[56].Text.Replace("&nbsp;", "");
                txt_DocRecd_Date.Text = gv_Invoice.SelectedRow.Cells[57].Text.Replace("&nbsp;", "");


                txt_thirdPartyNotifyName.Text = gv_Invoice.SelectedRow.Cells[60].Text.Replace("&nbsp;", "");
                txt_thirdpartyNotifyAddress1.Text = gv_Invoice.SelectedRow.Cells[61].Text.Replace("&nbsp;", "");
                txt_thirdpartyNotifyAddress2.Text = gv_Invoice.SelectedRow.Cells[62].Text.Replace("&nbsp;", "");
                txt_thirdpartyNotifyAddress3.Text = gv_Invoice.SelectedRow.Cells[63].Text.Replace("&nbsp;", "");
                txt_thirdpartyNotifyCountry.Text = gv_Invoice.SelectedRow.Cells[64].Text.Replace("&nbsp;", "");

                if (!string.IsNullOrEmpty(Session["SB_NO"].ToString()))
                {
                    div_AmendmentType.Visible = true;
                    ddl_AmendmentType.SelectedValue = gv_Invoice.SelectedRow.Cells[58].Text.Replace("&nbsp;", "");
                }

                //END

                lblInvoiceNo.Text = txtInvoiceNo.Text;
                lblInvoiceDate.Text = txtInvoiceDate.Text;
                lblInvoiceCurrency.Text = txtInvoiceCurrency.Text.ToUpper();
                lblInvoiceTerms.Text = ddlTerms.SelectedValue;
                lblInvoiceValue.Text = txtInvoiceValue.Text;
                //lblProductValue.Text=

                Get_ProductValue();
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["INVOICE_ID"].ToString();
                //FOR UPDATED SUCCESSFULLY

            }
            else
            {
                hdn_grid_edit.Value = "0";
                AR4_Details.Visible = false;

                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnSave_New.Visible = true;
            }

            if (Audit_YN == "Y")
            {
                DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"]);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCommission_Currency.Text.Length == 3)
            {
                if (txtFOBDisc_Currency.Text.Length == 3)
                {
                    if (txtPackMisc_Currency.Text.Length == 3)
                    {
                        if (txtOtherDeductions_Currency.Text.Length == 3)
                        {
                            Elogix_Service();
                            string F = "U";
                            string INV_ID = ViewState["INVOICE_ID"].ToString();                          

                            i = Export_Invoice_Insert_Update(F, INV_ID);
                            if (i == 1)
                            {
                                // ----Audit Modified Data -----------------------------------
                                if (Audit_YN == "Y")
                                {
                                    Audit_Modified_DataTableComparer();
                                }
                                //------------------------------------------------------------
                                //txtInvoiceNo.Focus();
                                if (ViewState["UPDATED_ID"] != null)
                                {
                                    Alert_msg("Invoice Updated Successfully", "btnUpdate");
                                }
                                else
                                {
                                    Alert_msg("Invoice Saved Successfully", "btnUpdate");

                                }
                            }
                            else if (i == 2)
                            {
                                Alert_msg("Invoice No Already Exist!", "btnUpdate");

                            }
                            else
                            {
                                Alert_msg("Invoice Not Updated", "btnUpdate");

                            }
                        }
                        else
                        {
                            Alert_msg("Other Deductions Currency Should be 3 Characters", txtOtherDeductions_Currency.Text);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "check_Currency()", true);
                        }
                    }
                    else
                    {
                        Alert_msg("Pack & MISC Currency Should be 3 Characters", txtPackMisc_Currency.Text);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "check_Currency()", true);
                    }
                }
                else
                {
                    Alert_msg("FOB Disc Currency Should be 3 Characters", txtFOBDisc_Currency.Text);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "check_Currency()", true);
                }
            }
            else
            {
                Alert_msg("Commission Currency Should be 3 Characters", txtCommission_Currency.Text);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "check_Currency()", true);
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            Invoice.JOBNO = EXPORT_JOBNO;

            Invoice.INVOICE_SLNO = ViewState["INV_SLNO"].ToString();
            Invoice.INVOICE_NO = ViewState["Invoice_No"].ToString().Replace("&amp;", "&");

            Invoice.WORKING_PERIOD = SELECT_BRANCH;
            Invoice.TERMS = "";

            Invoice.flag = "Delete";
            gv_Invoice.DataSource = Invoice.RetrieveAll_Invoice_Details();

            gv_Invoice.DataBind();
            int ii = 0;
            ii = Invoice.result;

            if (ii > 0)
            {
                Elogix_Service();
                btnNew_Click(sender, e);
                hdn_INVOICE_SLNO.Value = "";

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnSave_New.Visible = true;

                Alert_msg("Invoice Deleted", "btnSave");
                Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, Invoice.INVOICE_SLNO, "", "Invoice", "D", "Insert");
            }
            else
            {
                Alert_msg("Invoice Not Deleted", "btnSave");
            }
            Textbox_Enable_Disable(ddlTerms.SelectedValue.ToString());
            Get_ProductValue();
            Bind_Invoice_Sl_No_Dropdown();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void txtInvoiceCurrency_TextChanged(object sender, EventArgs e)
    {
        try
        {
            // eroyalmaster erm = new eroyalmaster();
            adminmaster erm = new adminmaster();
            erm.Invoice_Currency = txtInvoiceCurrency.Text;
            erm.Ename = "IMPORT_INVOICE_EX_RATE";
            erm.EWorking_Period = Working_Period;
            dss = erm.RetrieveAll_Exchange_master_INV_Currency();
            if (dss.Tables[0].Rows.Count > 0)
            {

                txtExchangeRate.Text = dss.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                txtFreight_Currency.Text = txtInvoiceCurrency.Text;
                txtInsurance_Currency.Text = txtInvoiceCurrency.Text;

                txtFreight_Currency.Enabled = true;

                txtFreight_Rate.Enabled = false;

                txtInsurance_Charges.Enabled = true;

                txtInsurance_Currency.Enabled = true;

                txtInsurance_Rate.Enabled = true;
            }
            else
            {
                txtFreight_Currency.Text = "";
                txtInsurance_Currency.Text = "";
            }
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
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void Textbox_Enable_Disable(string terms)
    {
        try
        {
            if (terms == "FOB")
            {
                txtFreight_Rate.Enabled = false;
                txtFreight_Charges.Enabled = false;
                txtFreight_Currency.Enabled = false;
                txtInsurance_Rate.Enabled = false;
                txtInsurance_Charges.Enabled = false;
                txtInsurance_Currency.Enabled = false;

            }
            if (terms == "CIF")
            {
                txtFreight_Rate.Enabled = (hdn_CompanyID.Value == "3267") ? true : false;//This line code added by Ayyappan on 25-03-2026
                txtFreight_Charges.Enabled = true;
                txtFreight_Currency.Enabled = true;
                txtInsurance_Rate.Enabled = true;
                txtInsurance_Charges.Enabled = true;
                txtInsurance_Currency.Enabled = true;
            }
            if (terms == "CI")
            {
                txtFreight_Rate.Enabled = false;
                txtFreight_Charges.Enabled = false;
                txtFreight_Currency.Enabled = false;
                txtInsurance_Rate.Enabled = true;
                txtInsurance_Charges.Enabled = true;
                txtInsurance_Currency.Enabled = true;
            }
            if (terms == "CF")
            {
                txtFreight_Rate.Enabled = (hdn_CompanyID.Value == "3267") ? true : false; //This line code added by Ayyappan on 25-03-2026
                txtFreight_Charges.Enabled = true;
                txtFreight_Currency.Enabled = true;
                txtInsurance_Rate.Enabled = false;
                txtInsurance_Charges.Enabled = false;
                txtInsurance_Currency.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }


    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            hdn_grid_edit.Value = "0";
            AR4_Details.Visible = false;
            //  btn_BuyerMasedit.Visible = false;
            Transact.ResetFields(Page.Controls);
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnSave_New.Visible = true;
            ViewState["INVOICE_ID"] = null;
            txtInvoiceNo.Focus();
            //Gridbind_INVOICE();
            Get_ConsigneeName_SessionValue();

            ViewState["Newbtn"] = 1;

            gv_Invoice.SelectedRowStyle.Font.Bold = true;
            gv_Invoice.SelectedRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");

            if (gv_Invoice.Rows.Count > 0)
            {
                GridViewRow firstRow = gv_Invoice.Rows[0];
                if (Convert.ToInt32(ViewState["id"]) == 1)
                {
                    int ID;
                    ID = gv_Invoice.SelectedIndex;
                    if (ID == 0)
                    {
                        firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                        // firstRow.Font.Bold = true;
                    }
                    else
                    {
                        firstRow.BackColor = System.Drawing.Color.White;
                        firstRow.Font.Bold = false;
                    }
                    ViewState["id"] = "0";
                }
                else
                {
                    int ID;
                    ID = gv_Invoice.SelectedIndex;

                    if (ID == 0)
                    {
                        firstRow.BackColor = System.Drawing.Color.White;
                        firstRow.Font.Bold = false;
                    }
                    else
                    {
                        firstRow.BackColor = System.Drawing.Color.White;
                        firstRow.Font.Bold = false;
                    }

                }

            }
            if (gv_Invoice.Rows.Count > 0)
            {

                gv_Invoice.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                GridViewRow saverow = gv_Invoice.Rows[gv_Invoice.Rows.Count - 1];
                saverow.BackColor = System.Drawing.Color.White;
                saverow.Font.Bold = false;

            }
            gv_Invoice.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    public void Get_ConsigneeName_SessionValue()
    {
        try
        {
            hdn_Consignee_Name.Value = Session["CONSIGNEE_NAME"].ToString();
            hdn_Consignee_Address1.Value = Session["CONSIGNEE_ADDRESS1"].ToString();
            hdn_Consignee_Address2.Value = Session["CONSIGNEE_ADDRESS2"].ToString();
            hdn_Consignee_Address3.Value = Session["CONSIGNEE_ADDRESS3"].ToString();
            hdn_Consignee_Address4.Value = Session["CONSIGNEE_ADDRESS4"].ToString();
            hdn_Consignee_Address5.Value = Session["CONSIGNEE_ADDRESS5"].ToString();

            if (ddlBuyer.SelectedValue == "Yes")
            {
                txtBuyerName.Text = "SAME AS CONSIGNEE";

                txtBuyerName.Attributes.Add("readonly", "readonly");
                txtAddress.Attributes.Add("readonly", "readonly");
                txtAddress1.Attributes.Add("readonly", "readonly");
                txtAddress2.Attributes.Add("readonly", "readonly");
                txtAddress3.Attributes.Add("readonly", "readonly");
                txtAddress4.Attributes.Add("readonly", "readonly");
                href_Buyer_YN.Style.Add("display", "none");
                //href_Buyer_YN_New.Style.Add("display", "none");
                // btn_BuyerMasedit.Visible = false;
            }
            else
            {
                txtBuyerName.Attributes.Remove("readonly");

                if (COMPANY_IDD == "5" || COMPANY_IDD == "10" || COMPANY_IDD == "542" || COMPANY_IDD == "747" || COMPANY_IDD == "880")
                {
                    txtAddress.Attributes.Remove("readonly");
                    txtAddress1.Attributes.Remove("readonly");
                    txtAddress2.Attributes.Remove("readonly");
                    txtAddress3.Attributes.Remove("readonly");
                    txtAddress4.Attributes.Remove("readonly");
                }

                href_Buyer_YN.Style.Add("display", "Block");
                //href_Buyer_YN_New.Style.Add("display", "Block");
                // btn_BuyerMasedit.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    ///auto search
    [System.Web.Services.WebMethod]
    public static string GetExchange_Rate_Invoice_Cur(string custid)
    {
        try
        {
            if (custid.Length == 3)
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                // custid = Auto.Country_Master_FromClientSide_Calling(custid);
                Auto.Ename = "EXCHANGE_MASTER_RATE_EXPORTWISE";
                Auto.Enamesearch = custid;
                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    //custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString() + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " ";
                    custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();

                }
                else
                {
                    Auto.Ename = "NON_STD_CUR_RATE_EXPORTWISE";
                    Auto.Enamesearch = custid;
                    ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        decimal NON_STD_RATE_EXPORT_DEC = 0; // Added by shanthini on 16-09-2026 sugg by bala sir & shaziya
                        decimal.TryParse(ds.Tables[0].Rows[0]["NON_STD_RATE_EXPORT"].ToString(), out NON_STD_RATE_EXPORT_DEC);
                        string NON_STD_RATE_EXPORT = NON_STD_RATE_EXPORT_DEC.ToString("0.####");
                        //string NON_STD_RATE_EXPORT = ds.Tables[0].Rows[0]["NON_STD_RATE_EXPORT"].ToString();
                        string NON_STD_EFFECT_DT_EXP = ds.Tables[0].Rows[0]["NON_STD_EFFECT_DT_EXP"].ToString();
                        string NON_STD_BANKNAME = ds.Tables[0].Rows[0]["NON_STD_BANKNAME"].ToString();
                        string NON_STD_CERTIFICATE_NO = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString();
                        string NON_STD_CERTIFICATE_DATE = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString();

                        custid = NON_STD_RATE_EXPORT + "~~" + NON_STD_EFFECT_DT_EXP + "~~" + NON_STD_BANKNAME + "~~" + NON_STD_CERTIFICATE_NO + "~~" + NON_STD_CERTIFICATE_DATE;
                    }
                    else

                        custid = "";
                }
            }
            else
            {
                custid = "";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }


    ///auto search
    [System.Web.Services.WebMethod]
    public static string GetExchange_Rate(string custid, string Inv_Curr, string Inv_Exrate)
    {
        try
        {
            if (custid.Length == 3)
            {
                if (custid == Inv_Curr)
                {
                    custid = Inv_Exrate;
                }
                else
                {
                    Auto_Search Auto = new Auto_Search();
                    DataSet ds = new DataSet();
                    // custid = Auto.Country_Master_FromClientSide_Calling(custid);
                    Auto.Ename = "EXCHANGE_MASTER_RATE_EXPORTWISE";
                    Auto.Enamesearch = custid;
                    ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString() + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " ";
                        custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();
                    }
                    else
                    {
                        Auto.Ename = "NON_STD_CUR_RATE_EXPORTWISE";
                        Auto.Enamesearch = custid;
                        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string NON_STD_RATE_EXPORT = ds.Tables[0].Rows[0]["NON_STD_RATE_EXPORT"].ToString();

                            /* hide by Chithra on 26-06-2018 - for FREIGHT EXRATE - Saved with '~' symbol
                            //string NON_STD_EFFECT_DT_EXP = ds.Tables[0].Rows[0]["NON_STD_EFFECT_DT_EXP"].ToString();
                            //string NON_STD_BANKNAME = ds.Tables[0].Rows[0]["NON_STD_BANKNAME"].ToString();
                            //string NON_STD_CERTIFICATE_NO = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString();
                            //string NON_STD_CERTIFICATE_DATE = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString();
                            //custid = NON_STD_RATE_EXPORT + "~~" + NON_STD_EFFECT_DT_EXP + "~~" + NON_STD_BANKNAME + "~~" + NON_STD_CERTIFICATE_NO + "~~" + NON_STD_CERTIFICATE_DATE;
                             */

                            custid = NON_STD_RATE_EXPORT;
                        }
                        else

                            custid = "";
                    }
                }
            }
            else
            {
                custid = "";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string Get_ConsigneeName(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);
            Auto.Ename = "CONSIGNEE_MASTER_SEARCH";
            Auto.Enamesearch = custid;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                string Address1 = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["CONSIGNEE_COUNTRY_NAME"].ToString();
                string CONSIGNEE_PIN_CODE = ds.Tables[0].Rows[0]["CONSIGNEE_PIN_CODE"].ToString();

                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + CONSIGNEE_PIN_CODE;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string Get_BuyerName(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);
            Auto.Ename = "BUYER_MASTER_SEARCH";
            Auto.Enamesearch = custid;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                string Address1 = ds.Tables[0].Rows[0]["BUYER_NAME"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["BUYER_ADD1"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["BUYER_ADD2"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["BUYER_ADD3"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["BUYER_COUNTRY_NAME"].ToString();
                string CONSIGNEE_PIN_CODE = ds.Tables[0].Rows[0]["BUYER_PIN_CODE"].ToString();

                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + CONSIGNEE_PIN_CODE;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }


        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Exp_ThirdParty(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);
            Auto.Ename = "EXP_THIRDPARTY_MASTER_SEARCH";
            Auto.Enamesearch = custid;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                string ThirdParty_Name = ds.Tables[0].Rows[0]["THIRDPARTY_NAME"].ToString();
                string Address1 = ds.Tables[0].Rows[0]["THIRDPARTY_ADD1"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["THIRDPARTY_ADD2"].ToString();
                string City = ds.Tables[0].Rows[0]["THIRDPARTY_CITY"].ToString();
                string SubDivision = ds.Tables[0].Rows[0]["THIRDPARTY_COUNTRY_SUBDIVISION"].ToString();
                string CountryCode = ds.Tables[0].Rows[0]["THIRDPARTY_COUNTRY_CODE"].ToString();
                string TermsPlace = ds.Tables[0].Rows[0]["TERMS_PLACE"].ToString();
                string AEO_CODE = ds.Tables[0].Rows[0]["AEO_CODE"].ToString();
                string AEO_COUNTRY = ds.Tables[0].Rows[0]["AEO_COUNTRY"].ToString();
                string AEO_ROLE = ds.Tables[0].Rows[0]["AEO_ROLE"].ToString();
                string Pin = ds.Tables[0].Rows[0]["THIRDPARTY_PIN"].ToString();

                custid = ThirdParty_Name + "~~" + Address1 + "~~" + Address2 + "~~" + City + "~~" + SubDivision + "~~" + CountryCode + "~~" + Pin + "~~" + TermsPlace + "~~" + AEO_CODE + "~~" + AEO_COUNTRY + "~~" + AEO_ROLE;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Duplicate_InvoiceNo(string custid, string Jobno)
    {
        string InvoiceNo = "";
        try
        {
            if (custid != "")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();

                // custid = Auto.Country_Master_FromClientSide_Calling(custid);
                Auto.Ename = "EXPORT_DUPLICATE_INVOICENO";
                Auto.Enamesearch = custid;
                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["INVOICE_NO"].ToString() != "")
                    {
                        if (ds.Tables[0].Rows[0]["INVOICE_NO"].ToString() != Jobno)
                        {
                            InvoiceNo = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString() + "~~";
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return InvoiceNo;
    }

    public void Get_ExcelFile_INDEV()
    {
        try
        {
            string connString = "";
            string strFileType = Path.GetExtension(fileuploadExcel1.FileName).ToLower();
            string path_indev = errorFolder + "\\" + fileuploadExcel1.FileName;

            string picExtension;
            string fileName2;

            if (fileuploadExcel1.HasFile)
            {
                picExtension = fnGetPictureExtn(fileuploadExcel1.FileName);
                // fileName2 = strGID + picExtension;
                fileName2 = fileuploadExcel1.FileName;
                addtoGallery1(fileName2, errorFolder, "INDEV");
            }


            //Connection String to Excel Workbook
            if (strFileType.Trim() == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path_indev + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path_indev + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            string query = "SELECT * FROM [Sheet1$]";
            OleDbConnection conn = new OleDbConnection(connString);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            da.Fill(ds_indev);

            da.Dispose();
            conn.Close();
            conn.Dispose();
            ViewState["ds_Excel_upload_INDEV"] = ds_indev;

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void Delete_Excel_Invoice_Delete()
    {
        try
        {
            Invoice.JOBNO = Session["EXPORT_JOBNO"].ToString();
            Invoice.INVOICE_NO = txtInvoiceNo.Text;
            Invoice.TERMS = "";
            //Invoice.INVOICE_SLNO=txt

            string flag = "Delete_Excel";

            Invoice.WORKING_PERIOD = SELECT_BRANCH;
            Invoice.TERMS = "";
            Invoice.flag = flag;
            gv_Invoice.DataSource = Invoice.RetrieveAll_Invoice_Details();
            gv_Invoice.DataBind();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void btn_Delete_All_Invoice_And_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            Delete_Excel_Invoice_Delete();

            if (gv_Invoice.Rows.Count == 0)
            {
                if (button_click == "EXCEL_UPLOAD")
                {
                    //mp1.Show();
                }
                else
                {
                    mp_Indev.Show();
                }
            }
            else
                Alert_msg("Invoice not deleted");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void btnImport_Indev_Click(object sender, EventArgs e)
    {
        button_click = "INDEV";
        try
        {
            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Get_ExcelFile_INDEV();

            }

            else
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                Get_ExcelFile_INDEV();

            }
            if (gv_Invoice.Rows.Count > 0)
            {
                mp_Indev.Show();
                mp_yesorno.Show();
            }
            else
            {
                Excel_Upload_INDEV_Format();
            }

            Get_ProductValue();

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public void Excel_Upload_INDEV_Format()
    {
        try
        {
            GET_LICENSE_ID();

            ds = (DataSet)ViewState["ds_Excel_upload_INDEV"];

            ds.Tables[0].Rows.Add();

            int a = 0, b = 0, c = 0, d = 0;
            if (ds.Tables[0].Rows.Count > a)
            {
                dsXML.Tables.Add("InvoiceDetails");
                dsXML.Tables[0].Columns.Add("INVOICE_ID");
                dsXML.Tables[0].Columns.Add("JOBNO");
                dsXML.Tables[0].Columns.Add("JOBDATE", typeof(DateTime));
                dsXML.Tables[0].Columns.Add("INVOICE_SLNO");
                dsXML.Tables[0].Columns.Add("INVOICE_NO");
                dsXML.Tables[0].Columns.Add("INVOICE_DATE");
                dsXML.Tables[0].Columns.Add("PAYMENT_METHOD");
                dsXML.Tables[0].Columns.Add("PERIOD_PAYMENT");
                dsXML.Tables[0].Columns.Add("INVOICE_VALUE");
                dsXML.Tables[0].Columns.Add("INVOICE_CURRENCY");
                dsXML.Tables[0].Columns.Add("EXCHANGE_RATE");
                dsXML.Tables[0].Columns.Add("CONTRACT_NO");
                dsXML.Tables[0].Columns.Add("TERMS");
                dsXML.Tables[0].Columns.Add("BUYER");
                dsXML.Tables[0].Columns.Add("BUYER_NAME");
                dsXML.Tables[0].Columns.Add("BUYER_ADDRESS");
                dsXML.Tables[0].Columns.Add("BUYER_ADDRESS1");
                dsXML.Tables[0].Columns.Add("BUYER_ADDRESS2");
                dsXML.Tables[0].Columns.Add("BUYER_ADDRESS3");
                dsXML.Tables[0].Columns.Add("BUYER_ADDRESS4");
                dsXML.Tables[0].Columns.Add("COMMISSION_RATE");
                dsXML.Tables[0].Columns.Add("COMMISSION_CHARGES");
                dsXML.Tables[0].Columns.Add("COMMISSION_CURRENCY");
                dsXML.Tables[0].Columns.Add("FOB_RATE");
                dsXML.Tables[0].Columns.Add("FOB_CHARGES");
                dsXML.Tables[0].Columns.Add("FOB_CURRENCY");
                dsXML.Tables[0].Columns.Add("PACKMISC_RATE");
                dsXML.Tables[0].Columns.Add("PACKMISC_CHARGES");
                dsXML.Tables[0].Columns.Add("PACKMISC_CURRENCY");
                dsXML.Tables[0].Columns.Add("OTHER_DEDUCTION_RATE");
                dsXML.Tables[0].Columns.Add("OTHER_DEDUCTION_CHARGES");
                dsXML.Tables[0].Columns.Add("OTHER_DEDUCTION_CURRENCY");
                dsXML.Tables[0].Columns.Add("FREIGHT_RATE");

                dsXML.Tables[0].Columns.Add("FREIGHT_CHARGES");
                dsXML.Tables[0].Columns.Add("FREIGHT_CURRENCY");
                dsXML.Tables[0].Columns.Add("FREIGHT_EXRATE");
                dsXML.Tables[0].Columns.Add("INSURANCE_RATE");
                dsXML.Tables[0].Columns.Add("INSURANCE_CHARGES");
                dsXML.Tables[0].Columns.Add("INSURANCE_CURRENCY");
                dsXML.Tables[0].Columns.Add("INSURANCE_EXRATE");
                dsXML.Tables[0].Columns.Add("WHEATHER_UNIT_PRICE");

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
                dsXML.Tables[1].Columns.Add("RITCNO");
                dsXML.Tables[1].Columns.Add("ITEM_QTY");
                dsXML.Tables[1].Columns.Add("ITEM_QTY_CODE");
                dsXML.Tables[1].Columns.Add("ITEM_UNIT_PRICE");
                dsXML.Tables[1].Columns.Add("ITEM_PER");
                dsXML.Tables[1].Columns.Add("ITEM_AMOUNT", typeof(double));
                dsXML.Tables[1].Columns.Add("ITEM_PMVVALUE");
                dsXML.Tables[1].Columns.Add("ITEM_SCHEME_CODE");
                dsXML.Tables[1].Columns.Add("ITEM_ACCESSORIES_DESC");
                dsXML.Tables[1].Columns.Add("ITEM_AR4_NO");
                dsXML.Tables[1].Columns.Add("ITEM_AR4_DATE", typeof(DateTime));
                dsXML.Tables[1].Columns.Add("ITEM_COMMISSION_RATE");
                dsXML.Tables[1].Columns.Add("ITEM_DIVISION");
                dsXML.Tables[1].Columns.Add("ITEM_RANGE");
                dsXML.Tables[1].Columns.Add("ITEM_REMARKS");
                dsXML.Tables[1].Columns.Add("ITEM_IECCODE");
                dsXML.Tables[1].Columns.Add("ITEM_EXPORTER_NAME");
                dsXML.Tables[1].Columns.Add("BR_SLNO");
                dsXML.Tables[1].Columns.Add("ADDRESS1");
                dsXML.Tables[1].Columns.Add("ADDRESS2");
                dsXML.Tables[1].Columns.Add("ADDRESS3");
                dsXML.Tables[1].Columns.Add("ADDRESS4");
                dsXML.Tables[1].Columns.Add("ADDRESS5");
                dsXML.Tables[1].Columns.Add("ITEM_STR_CODE");
                dsXML.Tables[1].Columns.Add("REWARD_POINTS");
                dsXML.Tables[1].Columns.Add("USER_ID");
                dsXML.Tables[1].Columns.Add("DATE_TIME");

                dsXML.Tables[1].Columns.Add("STATUS");
                dsXML.Tables[1].Columns.Add("BRANCH_CODE");
                dsXML.Tables[1].Columns.Add("YEAR");
                dsXML.Tables[1].Columns.Add("WORKING_PERIOD");


                //--------------------Drawback Details--------------------------//
                dsXML.Tables.Add("Drawback_Details");

                dsXML.Tables[2].Columns.Add("DRAWBACK_ID");
                dsXML.Tables[2].Columns.Add("JOBNO");
                dsXML.Tables[2].Columns.Add("INVOICE_SLNO");
                dsXML.Tables[2].Columns.Add("ITEM_SLNO");
                dsXML.Tables[2].Columns.Add("SCHEME_CODE");
                dsXML.Tables[2].Columns.Add("DRAWBACK_SLNO");
                dsXML.Tables[2].Columns.Add("DRAWBACK_QTY");
                dsXML.Tables[2].Columns.Add("DRAWBACK_UNIT");
                dsXML.Tables[2].Columns.Add("DRAWBACK_NOOFUNITS");
                dsXML.Tables[2].Columns.Add("DRAWBACK_RATE");

                dsXML.Tables[2].Columns.Add("DRAWBACK_CAPS");
                dsXML.Tables[2].Columns.Add("DRAWBACK_DESC");

                dsXML.Tables[2].Columns.Add("USER_ID");
                dsXML.Tables[2].Columns.Add("DATE_TIME");

                dsXML.Tables[2].Columns.Add("STATUS");
                dsXML.Tables[2].Columns.Add("BRANCH_CODE");
                dsXML.Tables[2].Columns.Add("YEAR");
                dsXML.Tables[2].Columns.Add("WORKING_PERIOD");


                //--------------------License Details--------------------------//
                dsXML.Tables.Add("License_Details");

                dsXML.Tables[3].Columns.Add("LICENSE_ID");

                dsXML.Tables[3].Columns.Add("JOBNO");
                dsXML.Tables[3].Columns.Add("INV_SL_NO");
                dsXML.Tables[3].Columns.Add("ITEM_SL_NO");
                dsXML.Tables[3].Columns.Add("SCHEME_CODE");
                dsXML.Tables[3].Columns.Add("SCHEME");

                dsXML.Tables[3].Columns.Add("LICENSE_EXP_QTY");
                dsXML.Tables[3].Columns.Add("LICENSE_EXP_UNIT");

                dsXML.Tables[3].Columns.Add("LICENSE_IMP_EXP_ID");
                dsXML.Tables[3].Columns.Add("LICENSE_E_SL_NO");

                dsXML.Tables[3].Columns.Add("LICENSE_NO");
                //dsXML.Tables[3].Columns.Add("LICENSE_DATE", typeof(DateTime));
                dsXML.Tables[3].Columns.Add("LICENSE_DATE");

                dsXML.Tables[3].Columns.Add("LICENSE_R_SL_NO");
                dsXML.Tables[3].Columns.Add("LICENSE_REG_DATE", typeof(DateTime));
                dsXML.Tables[3].Columns.Add("LICENSE_REG_TYPE");
                dsXML.Tables[3].Columns.Add("LICENSE_ITEM_SL_NO");
                dsXML.Tables[3].Columns.Add("LICENSE_ITEM_DESCRIPTION");
                dsXML.Tables[3].Columns.Add("LICENSE_QTY");
                dsXML.Tables[3].Columns.Add("LICENSE_UNIT");

                dsXML.Tables[3].Columns.Add("LICENSE_TYPE");

                dsXML.Tables[3].Columns.Add("USER_ID");
                dsXML.Tables[3].Columns.Add("DATE_TIME");

                dsXML.Tables[3].Columns.Add("STATUS");
                dsXML.Tables[3].Columns.Add("BRANCH_CODE");
                dsXML.Tables[3].Columns.Add("YEAR");
                dsXML.Tables[3].Columns.Add("WORKING_PERIOD");

                //-------------------------------------------------------------//

                while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                {

                    DataRow dr = dsXML.Tables[0].NewRow();

                    dr["INVOICE_ID"] = "";
                    dr["JOBNO"] = EXPORT_JOBNO;
                    // dr["JOBDATE"] = EXPORT_JOBDATE;
                    dr["JOBDATE"] = DateTime.Parse(EXPORT_JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    dr["INVOICE_SLNO"] = ds.Tables[0].Rows[a][0].ToString();
                    dr["INVOICE_NO"] = ds.Tables[0].Rows[a][1].ToString();

                    string inv_date = Convert.ToDateTime(ds.Tables[0].Rows[a][2].ToString()).ToShortDateString();
                    string inv_date1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(inv_date));

                    dr["INVOICE_DATE"] = Convert.ToDateTime(inv_date).ToString(@"MM/dd/yyyy");
                    dr["PAYMENT_METHOD"] = ds.Tables[0].Rows[a][5].ToString();
                    dr["PERIOD_PAYMENT"] = "";
                    dr["INVOICE_CURRENCY"] = ds.Tables[0].Rows[a][3].ToString();
                    dr["EXCHANGE_RATE"] = ds.Tables[0].Rows[a][4].ToString();
                    dr["CONTRACT_NO"] = "";
                    dr["TERMS"] = ds.Tables[0].Rows[a][6].ToString();
                    dr["BUYER"] = "Y";
                    dr["BUYER_NAME"] = "SAME AS CONSIGNEE";
                    dr["BUYER_ADDRESS"] = "";
                    dr["BUYER_ADDRESS1"] = "";
                    dr["BUYER_ADDRESS2"] = "";
                    dr["BUYER_ADDRESS3"] = "";
                    dr["BUYER_ADDRESS4"] = "";
                    dr["COMMISSION_RATE"] = "0.00";
                    dr["COMMISSION_CHARGES"] = "";
                    dr["COMMISSION_CURRENCY"] = ds.Tables[0].Rows[a][3].ToString();
                    dr["FOB_RATE"] = "0.00";
                    dr["FOB_CHARGES"] = "";
                    dr["FOB_CURRENCY"] = ds.Tables[0].Rows[a][3].ToString();
                    dr["PACKMISC_RATE"] = "0.00";
                    dr["PACKMISC_CHARGES"] = "";
                    dr["PACKMISC_CURRENCY"] = ds.Tables[0].Rows[a][3].ToString();
                    dr["OTHER_DEDUCTION_RATE"] = "0.00";
                    dr["OTHER_DEDUCTION_CHARGES"] = "";
                    dr["OTHER_DEDUCTION_CURRENCY"] = ds.Tables[0].Rows[a][3].ToString();
                    dr["FREIGHT_RATE"] = "0.00";
                    dr["FREIGHT_CHARGES"] = ds.Tables[0].Rows[a][7].ToString();
                    dr["FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][8].ToString();

                    string inv_cur = dr["INVOICE_CURRENCY"].ToString();
                    string fri_cur = dr["FREIGHT_CURRENCY"].ToString();

                    if (dr["FREIGHT_CURRENCY"] != "")
                    {
                        if (inv_cur == fri_cur)
                        {
                            dr["FREIGHT_EXRATE"] = dr["EXCHANGE_RATE"];
                        }
                        else
                        {
                            dr["FREIGHT_EXRATE"] = "1";
                        }

                    }
                    else
                    {
                        dr["FREIGHT_EXRATE"] = "";
                    }

                    dr["INSURANCE_RATE"] = "";
                    dr["INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][9].ToString();
                    dr["INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][10].ToString();

                    string ins_cur = dr["INSURANCE_CURRENCY"].ToString();

                    if (dr["INSURANCE_CURRENCY"] != "")
                    {
                        if (inv_cur == ins_cur)
                        {
                            dr["INSURANCE_EXRATE"] = dr["EXCHANGE_RATE"];
                        }
                        else
                        {
                            dr["INSURANCE_EXRATE"] = "1";
                        }
                    }
                    else
                    {
                        dr["INSURANCE_EXRATE"] = "";
                    }


                    dr["WHEATHER_UNIT_PRICE"] = "N";
                    dr["USER_ID"] = currentuser;
                    dr["DATE_TIME"] = "";
                    dr["STATUS"] = "S";
                    dr["BRANCH_CODE"] = currentbranch;
                    dr["YEAR"] = "";
                    dr["WORKING_PERIOD"] = Working_Period;


                    //--------------------Item Details--------------------------//



                    while (ds.Tables[0].Rows[b][0] != System.DBNull.Value)
                    {

                        DataRow dr1 = dsXML.Tables[1].NewRow();

                        //if (ds.Tables[0].Rows[b][0] != System.DBNull.Value)
                        //{
                        dr1["ITEM_ID"] = "";
                        dr1["JOBNO"] = EXPORT_JOBNO;
                        dr1["INVOICE_SLNO"] = ds.Tables[0].Rows[b][0].ToString();
                        dr1["INVOICE_NO"] = ds.Tables[0].Rows[b][1].ToString();
                        dr1["ITEM_SLNO"] = ds.Tables[0].Rows[b][13].ToString();
                        dr1["ITEM_DESCRIPTION"] = ds.Tables[0].Rows[b][14].ToString() + ds.Tables[0].Rows[b][15].ToString() + ds.Tables[0].Rows[b][16].ToString();
                        dr1["RITCNO"] = ds.Tables[0].Rows[b][12].ToString();
                        dr1["ITEM_QTY"] = ds.Tables[0].Rows[b][17].ToString();
                        dr1["ITEM_QTY_CODE"] = ds.Tables[0].Rows[b][19].ToString();
                        dr1["ITEM_UNIT_PRICE"] = ds.Tables[0].Rows[b][18].ToString();
                        dr1["ITEM_PER"] = "1";

                        if (ds.Tables[0].Rows[b][17] != System.DBNull.Value && ds.Tables[0].Rows[b][18] != System.DBNull.Value)
                        {

                            item_amt = Convert.ToDecimal(ds.Tables[0].Rows[b][17]) * Convert.ToDecimal(ds.Tables[0].Rows[b][18]);
                        }
                        else
                        {
                            item_amt = 0;
                        }

                        dr1["ITEM_AMOUNT"] = item_amt;
                        dr1["ITEM_PMVVALUE"] = "";

                        scheme = ds.Tables[0].Rows[b][11].ToString();

                        Open_Schemecode();

                        dr1["ITEM_SCHEME_CODE"] = scheme;

                        dr1["ITEM_ACCESSORIES_DESC"] = "";
                        dr1["ITEM_AR4_NO"] = "";

                        string Ar4_date = "01/01/1900";

                        dr1["ITEM_AR4_DATE"] = DateTime.Parse(Ar4_date, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                        dr1["ITEM_COMMISSION_RATE"] = "";
                        dr1["ITEM_DIVISION"] = "";
                        dr1["ITEM_RANGE"] = "";
                        dr1["ITEM_REMARKS"] = "";
                        dr1["ITEM_IECCODE"] = ds.Tables[0].Rows[b][27].ToString();

                        dr1["BR_SLNO"] = ds.Tables[0].Rows[b][28].ToString();

                        if (ds.Tables[0].Rows[b][27].ToString() != "" && ds.Tables[0].Rows[b][28].ToString() != "")
                        {
                            Bind_Third_Party_Details(ds.Tables[0].Rows[b][27].ToString(), ds.Tables[0].Rows[b][28].ToString());

                            dr1["ITEM_EXPORTER_NAME"] = ds_TPD.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                            dr1["BR_SLNO"] = ds_TPD.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                            dr1["ADDRESS1"] = ds_TPD.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                            dr1["ADDRESS2"] = ds_TPD.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                            dr1["ADDRESS3"] = ds_TPD.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                            dr1["ADDRESS4"] = ds_TPD.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                            dr1["ADDRESS5"] = ds_TPD.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                        }
                        else
                        {
                            dr1["ITEM_EXPORTER_NAME"] = "";
                            dr1["ADDRESS1"] = "";
                            dr1["ADDRESS2"] = "";
                            dr1["ADDRESS3"] = "";
                            dr1["ADDRESS4"] = "";
                            dr1["ADDRESS5"] = "";
                        }
                        dr1["ITEM_STR_CODE"] = ds.Tables[0].Rows[b][26].ToString();
                        dr1["REWARD_POINTS"] = ds.Tables[0].Rows[b][24].ToString();
                        dr1["USER_ID"] = currentuser;
                        dr1["DATE_TIME"] = "";
                        dr1["STATUS"] = "N";
                        dr1["BRANCH_CODE"] = currentbranch;

                        dr1["YEAR"] = "";
                        dr1["WORKING_PERIOD"] = Working_Period;

                        dsXML.Tables[1].Rows.Add(dr1);


                        //--------------------Drawback Details--------------------------//

                        string[] arr = { "19", "41", "43", "44", "47", "48", "49", "71", "73", "74", "79" };


                        string scheme_draw = ds.Tables[0].Rows[b][11].ToString().Trim();

                        string Draw_value = Array.Find(arr, element => element.StartsWith(scheme_draw, StringComparison.Ordinal));

                        if (ds.Tables[0].Rows.Count > c)
                        {
                            if (scheme != "")
                            {
                                if (scheme_draw == Draw_value)
                                {
                                    DataRow dr2 = dsXML.Tables[2].NewRow();

                                    dr2["DRAWBACK_ID"] = "";
                                    dr2["JOBNO"] = EXPORT_JOBNO;
                                    dr2["INVOICE_SLNO"] = ds.Tables[0].Rows[c][0].ToString();

                                    dr2["ITEM_SLNO"] = ds.Tables[0].Rows[c][13].ToString();
                                    dr2["SCHEME_CODE"] = scheme;
                                    dr2["INVOICE_SLNO"] = ds.Tables[0].Rows[c][0].ToString();

                                    if (ds.Tables[0].Rows[c][21].ToString() != "")
                                    {
                                        dr2["DRAWBACK_QTY"] = ds.Tables[0].Rows[c][21].ToString();
                                    }
                                    else
                                    {
                                        dr2["DRAWBACK_QTY"] = ds.Tables[0].Rows[c][17].ToString();
                                    }

                                    if (ds.Tables[0].Rows[c][20].ToString() != "")
                                    {
                                        dr2["DRAWBACK_UNIT"] = ds.Tables[0].Rows[c][22].ToString();
                                    }
                                    else
                                    {
                                        dr2["DRAWBACK_UNIT"] = ds.Tables[0].Rows[c][19].ToString();
                                    }

                                    //dr2["DRAWBACK_QTY"] = ds.Tables[0].Rows[c][15].ToString();
                                    //dr2["DRAWBACK_UNIT"] = ds.Tables[0].Rows[c][17].ToString();

                                    dr2["DRAWBACK_SLNO"] = ds.Tables[0].Rows[c][20].ToString();

                                    string dbk_slno = ds.Tables[0].Rows[c][20].ToString();

                                    if (dbk_slno != "")
                                    {
                                        Auto.Ename = "DRAWBACK_MASTER_ALL";
                                        Auto.Enamesearch = dbk_slno;

                                        ds_draw = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                                        if (ds_draw.Tables[0].Rows.Count > 0)
                                        {
                                            if (ds_draw.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString() != "")
                                            {
                                                dr2["DRAWBACK_UNIT"] = ds_draw.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString();
                                            }
                                            else
                                            {
                                                dr2["DRAWBACK_UNIT"] = ds.Tables[0].Rows[c][19].ToString();
                                            }


                                            dr2["DRAWBACK_NOOFUNITS"] = ds_draw.Tables[0].Rows[0]["DRAWBACK_NOOFUNITS"].ToString();
                                            //string Address3 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CETH"].ToString();
                                            dr2["DRAWBACK_RATE"] = ds_draw.Tables[0].Rows[0]["DRAWBACK_RATE"].ToString();
                                            dr2["DRAWBACK_CAPS"] = ds_draw.Tables[0].Rows[0]["DRAWBACK_VALUE_CAP"].ToString();
                                            dr2["DRAWBACK_DESC"] = ds_draw.Tables[0].Rows[0]["DRAWBACK_DESCRIPTION"].ToString();


                                            //custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6;
                                        }
                                    }
                                    else
                                    {
                                        dr2["DRAWBACK_SLNO"] = ds.Tables[0].Rows[c][20].ToString();
                                        dr2["DRAWBACK_NOOFUNITS"] = "";

                                        dr2["DRAWBACK_RATE"] = "";
                                        dr2["DRAWBACK_CAPS"] = "";
                                        dr2["DRAWBACK_DESC"] = "";
                                    }


                                    dr2["USER_ID"] = currentuser;
                                    dr2["DATE_TIME"] = "";
                                    dr2["STATUS"] = "S";
                                    dr2["BRANCH_CODE"] = currentbranch;
                                    dr2["YEAR"] = "";
                                    dr2["WORKING_PERIOD"] = Working_Period;

                                    dsXML.Tables[2].Rows.Add(dr2);
                                }
                            }
                            c++;
                        }
                        //--------------------End Drawback Details--------------------------//

                        //--------------------License Details--------------------------//

                        if (scheme != "" || scheme != "00-FREE SHIPPING BILL")
                        {
                            string license_no = ds.Tables[0].Rows[d][23].ToString();
                            sl = 1;
                            sl_E = 1;

                            if (license_no != "")
                            {

                                if (license_no.Contains(','))
                                {
                                    lic_no = license_no.Split(',');
                                    licno_Count = lic_no.Count();
                                }
                                else
                                {
                                    license_no = license_no + ',';
                                    lic_no = license_no.Split(',');
                                    licno_Count = 1;
                                }

                                for (int z = 0; z <= licno_Count - 1; z++)
                                {
                                    license_no = lic_no[z];

                                    D_E = 0;
                                    ii = 0;

                                    if (ds.Tables[0].Rows.Count > d)
                                    {
                                        DataRow dr3 = dsXML.Tables[3].NewRow();

                                        dr3["LICENSE_ID"] = License_id_Max;
                                        dr3["JOBNO"] = EXPORT_JOBNO;

                                        dr3["INV_SL_NO"] = ds.Tables[0].Rows[d][0].ToString();
                                        dr3["ITEM_SL_NO"] = ds.Tables[0].Rows[d][13].ToString();

                                        dr3["SCHEME_CODE"] = scheme;

                                        //dr3["LICENSE_R_SL_NO"] = sl + 1;

                                        dr3["LICENSE_EXP_QTY"] = ds.Tables[0].Rows[d][15].ToString();
                                        dr3["LICENSE_EXP_UNIT"] = ds.Tables[0].Rows[d][17].ToString();

                                        dr3["LICENSE_NO"] = license_no;


                                        License.Ename = "select_con";
                                        License.LICENSE_NO = license_no;

                                        ds_license = License.Export_License_Master_Select();

                                        if (ds_license.Tables[0].Rows.Count > 0)
                                        {
                                            if (ds_license.Tables[0].Rows[0]["LICENSE_REG_TYPE"].ToString() == "DEEC")
                                            {
                                                dr3["LICENSE_R_SL_NO"] = sl;
                                                sl = sl + 1;
                                            }
                                            else
                                            {
                                                dr3["LICENSE_R_SL_NO"] = sl_E;
                                                sl_E = sl_E + 1;
                                            }

                                            //for (int k = 0; k < scheme_name.Length; k++)
                                            //{

                                            for (int k = 0; k <= ds_license.Tables[0].Rows.Count; k++)
                                            {

                                                DataView view1 = ds_license.Tables[0].DefaultView;
                                                //view1.RowFilter = "LICENSE_REG_TYPE = '" + scheme_name[k] + "'";
                                                view1.RowFilter = "LICENSE_REG_TYPE = '" + scheme_name[D_E] + "'";

                                                //view1.RowFilter = "LICENSE_REG_TYPE = '" + ds_license.Tables[0].Rows[0]["LICENSE_REG_TYPE"].ToString() + "'";

                                                DataSet dt_UserRights = new DataSet();
                                                dt_UserRights.Tables.Add(view1.ToTable());

                                                int x = dt_UserRights.Tables[0].Rows.Count;

                                                if (x == 1)
                                                {
                                                    x = 0;
                                                }
                                                else
                                                {
                                                    x = dt_UserRights.Tables[0].Rows.Count - 1;
                                                }

                                                if (x >= ii)
                                                {

                                                    dr3["LICENSE_IMP_EXP_ID"] = License_id_IMP_EXP_Max;
                                                    dr3["LICENSE_E_SL_NO"] = "1";
                                                    dr3["LICENSE_ID"] = License_id_Max + 1;
                                                    //dr3["JOBNO"] = EXPORT_JOBNO;
                                                    //dr3["LICENSE_DATE"] = ds_license.Tables[0].Rows[k]["LICENSE_DATE"].ToString();

                                                    string License_date = Convert.ToDateTime(dt_UserRights.Tables[0].Rows[ii]["LICENSE_DATE"].ToString()).ToShortDateString();
                                                    string License_date1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(License_date));

                                                    dr3["LICENSE_DATE"] = Convert.ToDateTime(License_date).ToString(@"MM/dd/yyyy");

                                                    //dr3["LICENSE_R_SL_NO"] = ds_license.Tables[0].Rows[k]["LICENSE_R_SL_NO"].ToString();

                                                    dr3["LICENSE_REG_DATE"] = dt_UserRights.Tables[0].Rows[ii]["LICENSE_REG_DATE"].ToString();
                                                    dr3["LICENSE_REG_TYPE"] = dt_UserRights.Tables[0].Rows[ii]["LICENSE_REG_TYPE"].ToString();
                                                    dr3["LICENSE_ITEM_SL_NO"] = dt_UserRights.Tables[0].Rows[ii]["LICENSE_ITEM_SL_NO"].ToString();
                                                    dr3["LICENSE_ITEM_DESCRIPTION"] = dt_UserRights.Tables[0].Rows[ii]["LICENSE_ITEM_DESCRIPTION"].ToString();

                                                    dr3["LICENSE_QTY"] = dt_UserRights.Tables[0].Rows[ii]["LICENSE_QTY"].ToString();
                                                    dr3["LICENSE_UNIT"] = dt_UserRights.Tables[0].Rows[ii]["LICENSE_UNIT"].ToString();
                                                    dr3["LICENSE_TYPE"] = dt_UserRights.Tables[0].Rows[ii]["LICENSE_TYPE"].ToString();


                                                    dr3["SCHEME"] = scheme_name[D_E];
                                                    License_id_IMP_EXP_Max = License_id_IMP_EXP_Max + 1;

                                                    dr3["USER_ID"] = currentuser;
                                                    dr3["DATE_TIME"] = "";
                                                    dr3["STATUS"] = "S";
                                                    dr3["BRANCH_CODE"] = currentbranch;
                                                    dr3["YEAR"] = "";
                                                    dr3["WORKING_PERIOD"] = Working_Period;

                                                    //dsXML.Tables[3].Rows.Add(dr3);

                                                    dsXML.Tables[3].Rows.Add(dr3.ItemArray);

                                                    ii++;

                                                }
                                                else
                                                {
                                                    D_E = 1;
                                                    ii = 0;

                                                }

                                            }

                                        }
                                        else
                                        {

                                        }
                                    }
                                    License_id_Max = License_id_Max + 1;
                                }
                            }
                            d++;
                            //License_id_Max = License_id_Max + 1;

                        }
                        b++;
                    }



                    //DataTable table;
                    dt = dsXML.Tables["ItemDetails"];

                    //---------------------------------------
                    //int sum = 0;
                    //foreach (DataRow dritem in dt.Rows)
                    //{
                    //    sum += Convert.ToInt32(dritem["ITEM_AMOUNT"]);
                    //}

                    //dr["INVOICE_VALUE"] = sum.ToString();            
                    //---------------------------------------

                    string dd = ds.Tables[0].Rows[a][1].ToString();
                    var Values = from row in dsXML.Tables["ItemDetails"].AsEnumerable()
                                 //group row by row.Field<string>("INVOICE_NO") into g
                                 //group row by dd into g
                                 group row by new { id = row.Field<string>("INVOICE_NO") } into g
                                 select new
                                 {
                                     name_1 = g.Key.id,

                                     name_2 = g.Sum(r => r.Field<double>("ITEM_AMOUNT"))
                                 };

                    foreach (var drval in Values)
                    {
                        if (drval.name_1 == dd)
                            dr["INVOICE_VALUE"] = drval.name_2;
                    }

                    dsXML.Tables[0].Rows.Add(dr);
                    a++;
                    //}
                }
            }

            dt = dsXML.Tables["InvoiceDetails"];

            Invoice.Bulk_Item_Excel_Upload(RemoveDuplicateRows(dt, "INVOICE_NO"), dsXML.Tables[1], dsXML.Tables[2], dsXML.Tables[3], "BULK_ITEM_UPLOAD");

            int i = Invoice.result;

            if (Invoice.result == 1)
            {
                Response.Redirect(Request.RawUrl, false);
            }
            else
            {
                Alert_msg("Excel Upload occured some problem");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }


    // This method is used to delete duplicate rows of table
    public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    {
        try
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
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return dTable;
    }

    public void addtoGallery1(string picName, string folderName, string Excel_Name)
    {
        string strFolderPath;
        string strImagePath;
        try
        {
            strFolderPath = Path.Combine(Request.PhysicalApplicationPath, folderName);
            strImagePath = Path.Combine(strFolderPath, picName);

            if (Excel_Name == "INDEV")
            {
                fileuploadExcel1.SaveAs(strImagePath);
            }
            else
            {
                //fileuploadExcel.SaveAs(strImagePath);
            }

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

    public void Bind_Third_Party_Details(string IECCODE, string BR_SL_NO)
    {
        try
        {
            Client_Master client = new Client_Master();

            client.Eimp_exp_id = "";
            client.Eimp_exp_iecno = IECCODE;
            client.Eimp_exp_brslno = BR_SL_NO;
            client.Eimp_exp_name = "";
            client.Ename = "GET_THIRD_PARTY_DETAILS";

            ds_TPD = client.RetrieveAll_Imp_exp_master();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }


    }

    public void Get_Drawback_Master(string Drawback_Slno)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds_draw = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);
            Auto.Ename = "DRAWBACK_MASTER_ALL";
            Auto.Enamesearch = Drawback_Slno;

            ds_draw = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds_draw.Tables[0].Rows.Count > 0)
            {

                string Address1 = ds_draw.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString();
                string Address2 = ds_draw.Tables[0].Rows[0]["DRAWBACK_NOOFUNITS"].ToString();
                //string Address3 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CETH"].ToString();
                string Address4 = ds_draw.Tables[0].Rows[0]["DRAWBACK_RATE"].ToString();
                string Address5 = ds_draw.Tables[0].Rows[0]["DRAWBACK_VALUE_CAP"].ToString();
                string Address6 = ds_draw.Tables[0].Rows[0]["DRAWBACK_DESCRIPTION"].ToString();


                //custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }


    public void Open_Schemecode()
    {
        try
        {
            if (scheme == "00")
            {
                scheme = "00-FREE SHIPPING BILL";
            }
            else if (scheme == "")
            {
                scheme = "00-FREE SHIPPING BILL";
            }
            else if (scheme == "01")
            {
                scheme = "01-ADVANCE LICENSE ACT. USER COND";
                scheme_name[0] = "DEEC";
            }
            else if (scheme == "02")
            {
                scheme = "02-ADVANCE LICENSE INTERM SUPPLIES";
                scheme_name[0] = "DEEC";
            }
            else if (scheme == "03")
            {
                scheme = "03-ADVANCE LICENSE";
                scheme_name[0] = "DEEC";
            }
            else if (scheme == "04")
            {
                scheme = "04-ADVANCE RELEASE ORDER";
                scheme_name[0] = "DEEC";
            }
            else if (scheme == "05")
            {
                scheme = "05-ADVANCE RELEASE DEEMED EXPORT";
                scheme_name[0] = "DEEC";
            }
            else if (scheme == "08")
            {
                scheme = "08-REPLENISHMENT LICENSE";
                scheme_name[0] = "DEEC";
            }
            else if (scheme == "09")
            {
                scheme = "09-DIAMOND IMPREST LICENSE";
                scheme_name[0] = "DEEC";
            }
            else if (scheme == "11")
            {
                scheme = "11-CONCESSIONAL DUTY EPCG";
                scheme_name[0] = "DEEC";
            }
            else if (scheme == "12")
            {
                scheme = "12-ZERO DUTY EPCG SCHEME";
                scheme_name[0] = "DEEC";
            }
            else if (scheme == "17")
            {
                scheme = "17-ADVANCE LICENSE  ANNUAL REQ.";
                scheme_name[0] = "DEEC";
            }
            else if (scheme == "19")
            {
                scheme = "19-DRAWBACK (DBK)";
            }
            else if (scheme == "20")
            {
                scheme = "20-JOBBING (JBG)";
            }
            else if (scheme == "21")
            {
                scheme = "21-EOU/EPZ/SEZ/EHTP/STP";
            }

            else if (scheme == "24-VKUY")
            {
                scheme = "24-VKUY";
            }
            else if (scheme == "25-DFIA")
            {
                scheme = "25-DFIA";
            }
            else if (scheme == "26")
            {
                scheme = "26-DFIA";
            }
            else if (scheme == "27")
            {
                scheme = "27-FMS";
            }
            else if (scheme == "28")
            {
                scheme = "28-FPS";
            }
            else if (scheme == "41")
            {
                scheme = "41-DRAWBACK AND ADVANCE LICENSE";
                scheme_name[0] = "DEEC";
            }
            else if (scheme == "43")
            {
                scheme = "43-DRAWBACK AND ZERO DUTY EPCG";
                scheme_name[0] = "EPCG";
            }
            else if (scheme == "44")
            {
                scheme = "44-DRAWBACK AND CONCESS. EPCG";
                scheme_name[0] = "EPCG";
            }
            else if (scheme == "47")
            {
                scheme = "47-DRAWBACK AND JOBBING";
            }
            else if (scheme == "48")
            {
                scheme = "48-DRAWBACK AND DIAMOND IMP LICENSE";
                scheme_name[0] = "DEEC";
            }
            else if (scheme == "49")
            {
                scheme = "49-DRAWBACK AND EOU/EPZ/SEZ";
            }
            else if (scheme == "50")
            {
                scheme = "50-EPCG AND ADVANCE LICENSE";

                scheme_name[0] = "EPCG";
                scheme_name[1] = "DEEC";
            }
            else if (scheme == "52")
            {
                scheme = "52-EPCG AND JOBBING";

                scheme_name[0] = "EPCG";
            }
            else if (scheme == "53")
            {
                scheme = "53-EPCG AND DIAMOND IMPREST LICENSE";

                scheme_name[0] = "EPCG";
                scheme_name[1] = "DEEC";
            }
            else if (scheme == "54")
            {
                scheme = "54-EPCG AND REPLENISHMENT LICENSE";
                scheme_name[0] = "EPCG";
                scheme_name[1] = "DEEC";
            }
            else if (scheme == "55")
            {
                scheme = "55-EPCG AND POST EXPORT DEPB";
                scheme_name[0] = "EPCG";
            }
            else if (scheme == "59")
            {
                scheme = "59-EPCG, DFIA";
                scheme_name[0] = "EPCG";
            }
            else if (scheme == "71")
            {
                scheme = "71-EPCG, DRAWBACK AND DEEC";
                scheme_name[0] = "EPCG";
                scheme_name[1] = "DEEC";
            }
            else if (scheme == "73")
            {
                scheme = "73-EPCG, DRAWBACK AND JOBBING";
                scheme_name[0] = "EPCG";
            }
            else if (scheme == "74")
            {
                scheme = "74-EPCG, DRAWBACK AND DIMOND IMPREST";
                scheme_name[0] = "EPCG";
                scheme_name[1] = "DEEC";
            }
            else if (scheme == "79")
            {
                scheme = "79-EPCG, DRAWBACK AND DFIA";
                scheme_name[0] = "EPCG";
                scheme_name[1] = "DFIA";
            }
            else if (scheme == "99")
            {
                scheme = "99-NFEI";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void ddlInv_SL_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlInv_SL_No.SelectedItem.Text != string.Empty)
            {
                this.gv_Invoice.SelectedIndex = Convert.ToInt32(ddlInv_SL_No.SelectedValue.ToString()) - 1;
                gv_Invoice_SelectedIndexChanged(this.gv_Invoice, new EventArgs());
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void GET_LICENSE_ID()
    {
        try
        {
            Export_Licence Export_license = new Export_Licence();
            Export_license.LICENSE_NO = "0";
            Export_license.Ename = "GET_EXPORT_LICENSE_ID_MAX";
            ds = Export_license.Export_License_Master_Select();
            License_id_Max = Convert.ToInt32(ds.Tables[0].Rows[0]["LICENSE_ID"].ToString());
            License_id_IMP_EXP_Max = Convert.ToInt32(ds.Tables[1].Rows[0]["LICENSE_IMP_EXP_ID"].ToString());
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    private void Elogix_Service()
    {
        try
        {
            /*
      E_LOGIX ES = new E_LOGIX();
      ES.E_logic_Update(Session["EXPORT_JOBNO"].ToString(), "E", "U");
      */
            Connection.e_lOGIX("E", "U");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void invoice_item_Count()
    {
        try
        {
            DataSet dc = new DataSet();
            Invoice.JOBNO = EXPORT_JOBNO;
            Invoice.flag = "Item_Count";
            dc = Invoice.RetrieveAll_Invoice_Details();

            if (dc.Tables[0].Rows.Count > 0)
            {
                if (dc.Tables[0].Rows[0][0].ToString() != "0")
                {
                    btnInvoiceExcelDownload.Visible = true;
                }
                else
                {
                    btnInvoiceExcelDownload.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }


    }


    #region Export Audit Logs

    private void Tbl_Filed_Modified_History(DataTable dt_Curr_tbl_struct)
    {        
        try
        {
            ViewState["dt_Prev_Table"] = dt_Curr_tbl_struct.Copy();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Audit_Modified_DataTableComparer()
    {
        try
        {
            DataTable dt_Prev = (DataTable)ViewState["dt_Prev_Table"];
            DataTable dt_m2 = dt_Prev.Clone();
            DataTable dt_modified = DataTable_Mapping_Controls(dt_m2);
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast_EXP(dt_Prev, dt_modified, "INVOICE_SLNO", "Invoice", EXPORT_JOBNO, ddlInv_SL_No.SelectedValue, "", currentuser, currentbranch);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private DataTable DataTable_Mapping_Controls(DataTable dt_mapping)
    {
        try
        {
            if (dt_mapping.Rows.Count > 0)
            {
                dt_mapping.Rows.Clear();
            }
            DataRow dr = dt_mapping.NewRow();

            // ===== BASIC =====
            dr["JOBNO"] = EXPORT_JOBNO;

            dr["INVOICE_NO"] = txtInvoiceNo.Text;
            dr["INVOICE_DATE"] = txtInvoiceDate.Text;
            dr["PAYMENT_METHOD"] = ddlPaymentMethod.SelectedValue;
            dr["PERIOD_PAYMENT"] = txtPeriodOfPayment.Text;

            dr["INVOICE_VALUE"] = txtInvoiceValue.Text;
            dr["INVOICE_CURRENCY"] = txtInvoiceCurrency.Text;
            dr["EXCHANGE_RATE"] = txtExchangeRate.Text;

            dr["CONTRACT_NO"] = txtContractNo.Text;
            dr["CONTRACT_DATE"] = txtContractDate.Text;

            dr["TERMS"] = ddlTerms.SelectedValue;
            dr["BUYER"] = ddlBuyer.SelectedValue;

            dr["BUYER_NAME"] = txtBuyerName.Text;
            dr["BUYER_ADDRESS"] = txtAddress.Text;
            dr["BUYER_ADDRESS1"] = txtAddress1.Text;
            dr["BUYER_ADDRESS2"] = txtAddress2.Text;
            dr["BUYER_ADDRESS3"] = txtAddress3.Text;
            dr["BUYER_ADDRESS4"] = txtAddress4.Text;

            dr["COMMISSION_RATE"] = txtCommission_Rate.Text;
            dr["COMMISSION_CHARGES"] = txtCommission_Charges.Text;
            dr["COMMISSION_CURRENCY"] = txtCommission_Currency.Text;

            dr["FOB_RATE"] = txtFOBDisc_Rate.Text;
            dr["FOB_CHARGES"] = txtFOBDisc_Charges.Text;
            dr["FOB_CURRENCY"] = txtFOBDisc_Currency.Text;

            dr["PACKMISC_RATE"] = txtPackMisc_Rate.Text;
            dr["PACKMISC_CHARGES"] = txtPackMisc_Charges.Text;
            dr["PACKMISC_CURRENCY"] = txtPackMisc_Currency.Text;

            dr["OTHER_DEDUCTION_RATE"] = txtOtherDeductions_Rate.Text;
            dr["OTHER_DEDUCTION_CHARGES"] = txtOtherDeductions_Charges.Text;
            dr["OTHER_DEDUCTION_CURRENCY"] = txtOtherDeductions_Currency.Text;

            dr["FREIGHT_RATE"] = txtFreight_Rate.Text;
            dr["FREIGHT_CHARGES"] = txtFreight_Charges.Text;
            dr["FREIGHT_CURRENCY"] = txtFreight_Currency.Text;

            dr["INSURANCE_RATE"] = txtInsurance_Rate.Text;
            dr["INSURANCE_CHARGES"] = txtInsurance_Charges.Text;
            dr["INSURANCE_CURRENCY"] = txtInsurance_Currency.Text;

            dr["WHEATHER_UNIT_PRICE"] = ddlWhether.SelectedValue;

            dr["FREIGHT_EXRATE"] = ""; // Control not found in snippet
            dr["INSURANCE_EXRATE"] = ""; // Control not found in snippet

            dr["NON_STD_EFFECT_DT_EXP"] = ""; // Control not found
            dr["NON_STD_BANKNAME"] = ""; // Control not found
            dr["NON_STD_CERTIFICATE_NO"] = ""; // Control not found
            dr["NON_STD_CERTIFICATE_DATE"] = ""; // Control not found

            dr["TERMS_PLACE"] = txt_TermsPlace.Text;

            dr["THIRDPARTY_NAME"] = txt_ThirdPartyName.Text;
            dr["THIRDPARTY_ADD1"] = txt_ThirdParty_Add1.Text;
            dr["THIRDPARTY_ADD2"] = txt_ThirdParty_Add2.Text;
            dr["THIRDPARTY_CITY"] = txt_ThirdParty_City.Text;

            dr["T_PARTY_COUNTRY_SUB_DIV"] = txt_Country_Division.Text;
            dr["T_PARTY_COUNTRY_CODE"] = txt_CountryCode.Text;
            dr["T_PARTY_PIN"] = txt_ThirdParty_Pin.Text;

            dr["AUTHORIZED_ECONOMIC_OPERATOR_CODE"] = txt_Authrzd_Economic_Code.Text;
            dr["A_E_O_COUNTRY"] = txt_Authrzd_Economic_Country.Text;
            dr["AUTHORIZED_ECONOMIC_OPERATOR"] = txt_Authrzd_Economic_Role.Text;
            dr["DOC_RECD_DATE"] = txt_DocRecd_Date.Text;
            dr["AMENDMENT_TYPE"] = ddl_AmendmentType.SelectedValue;

            dr["NOTIFY_NAME"] = txt_thirdPartyNotifyName.Text;
            dr["NOTIFY_ADDRESS_1"] = txt_thirdpartyNotifyAddress1.Text;
            dr["NOTIFY_ADDRESS_2"] = txt_thirdpartyNotifyAddress2.Text;
            dr["NOTIFY_ADDRESS_3"] = txt_thirdpartyNotifyAddress3.Text;
            dr["NOTIFY_ADDRESS_COUNTRY"] = txt_thirdpartyNotifyCountry.Text;

            // ===== ADD ROW =====
            dt_mapping.Rows.Add(dr);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }

    #endregion

}