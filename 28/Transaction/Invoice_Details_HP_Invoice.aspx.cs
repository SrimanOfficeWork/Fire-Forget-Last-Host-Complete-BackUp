using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Transaction_Invoice_Details : ThemeClass
{
    AppSession aps = new AppSession();
    Date_Time rep = new Date_Time();
    Transaction Transact = new Transaction();
    eroyalmaster erm = new eroyalmaster();
    adminmaster adm = new adminmaster();
    ErrorLogs er = new ErrorLogs();
    User_Creation user_Create = new User_Creation();

    DataSet ds = new DataSet();
    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    DataSet ds_scheme = new DataSet();
    DataSet ds_product = new DataSet();

    DataTable dt = new DataTable();

    public int i, Screen_Id;
    public string currentuser, currentbranch, Working_Period, DEFAULT_DATE, SELECT_BRANCH, COMPANY_IDD
        , errorFolder = "", IMPORT_JOBNO, flag = "", inv_no = "", inv_slno = "", TERMS = "", JOB_LOCK
        , JOB_RELEASE, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, INV_DATE = "", SVB_DATE = ""
        , LoadingOn, Ass_Status, Duty_Status, PURCHASE_DATE = "", CONTRACT_DATE = "", LC_DATE = ""
        , SHIP_DATE = "", Revenue_LoadOn, a1 = "", a2 = "", a3 = "", a4 = "", a5 = "", a6 = ""
        , sno = "", singlemultiple = "", _slno = "0", MISC_EXRATE = "", CURRENCY_CODE = "", Inv_Avail = "", Audit_YN = "";

    double cal, cal1, invoicevalue, MasUpdateedit = 0;
    string ddl_NatureTrans1 = string.Empty;
    string ddl_NaturePayment1 = string.Empty;
    string ddl_valuationmethod1 = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            currentuser = Connection.Current_User();
            currentbranch = Connection.Current_Branch();
            Working_Period = Connection.WorkingPeriod();
            COMPANY_IDD = Connection.COMPANYID();
            hdnCompany_ID.Value = COMPANY_IDD;

            DEFAULT_DATE = Session["DEFAULT_DATE"].ToString();
            SELECT_BRANCH = Connection.Get_Company_Type();

            Screen_Id = 7;
            Page_Rights(Screen_Id);
            TextCopy();

            if (user_Create.SUPPLIER_MASTER_yn == "False")
            {
                dv_brokername_popup.Visible = false;
                dv_sellername_popup.Visible = false;
                dv_suppliername_popup.Visible = false;
                dv_SVBRelation_popup.Visible = false;
                btn_Masedit.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;

            }

            if (user_Create.THIRDPARTY_MASTER_yn == "False")
            {
                dv_Thirdpartyname_popup.Visible = false;
            }

            //------------------------ Direct Ex-Bond Invslno textbox show hide code here - start --------------------------

            if (!string.IsNullOrEmpty(Session["BE_TYPE"] as string))
            {
                hdn_BEType.Value = Session["BE_TYPE"].ToString();

                if (Session["BE_TYPE"].ToString() == "Ex-Bond" || Session["BE_TYPE"].ToString() == "SEZ DTA-T")
                {
                    if (!String.IsNullOrEmpty(Session["EXBOND_DIRECT_EXBONDING"] as string))
                    {
                        hdn_Direct_Exbond_YN.Value = Session["EXBOND_DIRECT_EXBONDING"].ToString();
                        if (hdn_Direct_Exbond_YN.Value == "Y")
                        {
                            tag_label_transaction_popup_gen.Visible = true;
                            editbu.Style.Add("display", "none");
                        }
                    }
                    else
                    {
                        tag_label_transaction_popup_gen.Visible = false;
                        editbu.Style.Add("display", "block");
                    }
                }
                else
                {
                    tag_label_transaction_popup_gen.Visible = false;
                    editbu.Style.Add("display", "block");
                }
            }

            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Import_Excel");

            if (Session["IMPORT_JOBNO"] != null || Session["IMPORT_JOBDATE"] != null)
            {
                IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
                hdn_Customhouse_chk.Value = "Yes";
                hdn_Jobno.Value = IMPORT_JOBNO;
                hdn_Branch.Value = SELECT_BRANCH;
                if (!this.IsPostBack)
                {
                    invoice_item_Count();
                    if (DEFAULT_DATE == "Yes")
                    {
                        txtDate.Text = rep.Today_Date();
                    }
                }
            }
            else
            {
                Response.Write("<script>window.parent.document.getElementById('General').click();</script>");
            }

            if (COMPANY_IDD == "10" || Connection.COMPANYID() == "1" || COMPANY_IDD == "2145")
            {
                DateTime opentime = DateTime.Now;
                DateTime closingtime = opentime.AddMinutes(15);

                DataSet ds_User_st = new DataSet();
                ds_User_st = Common_CS.Get_Job_User_Lock_Status(IMPORT_JOBNO, currentuser, Convert.ToString(opentime), Convert.ToString(closingtime), "Insert_User_History", "Import");
            }

            if (Connection.Audit_Logs(COMPANY_IDD) == "Y")
            {
                Audit_YN = "Y";
            }

            if (COMPANY_IDD == "4" || COMPANY_IDD == "196")
            {
                btn_Indev_Nissan.Visible = true;
            }
            else
            {
                btn_Indev_Nissan.Visible = false;
            }



            if (COMPANY_IDD == "5" || COMPANY_IDD == "203")
            {
                Btn_Nippon_ExcelUpload.Visible = true;
            }
            else
            {
                Btn_Nippon_ExcelUpload.Visible = false;
            }

            if (COMPANY_IDD == "10" || COMPANY_IDD == "309")
            {
                btn_svb_update.Visible = true;
            }
            else
            {
                btn_svb_update.Visible = false;
            }

            if (COMPANY_IDD == "10" || COMPANY_IDD == "1" || COMPANY_IDD == "4" || COMPANY_IDD == "152")
            {
                btn_Update_Product_Master_152.Visible = true;
            }

            btn_XBE_Split.Visible = false;
            if (COMPANY_IDD == "10" || COMPANY_IDD == "1" || COMPANY_IDD == "2145")//Capricorn
            {
                if (Session["BE_TYPE"].ToString() == "Ex-Bond")
                {
                    btn_XBE_Split.Visible = true;
                }
            }
            if (COMPANY_IDD == "10" || COMPANY_IDD == "1" || COMPANY_IDD == "830" || COMPANY_IDD == "2268") //Commission textbox enabled sugg.by Bala (Akila Client)
            {
                txt_Brokerage.Enabled = true;
                txt_Brokerage_Rate.Enabled = true;
            }

            if (COMPANY_IDD == "1701" || COMPANY_IDD == "3316")
            {
                txt_Whether_Relater_Y_N.Text = "N";
            }


            //if (COMPANY_IDD == "10" || COMPANY_IDD == "1" || COMPANY_IDD == "4" || COMPANY_IDD == "293" || COMPANY_IDD == "341")
            //{
            //    btn_Multiple.Visible = true;
            //}
            //else
            //{
            //    btn_Multiple.Visible = false;
            //}

            if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01029" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00010")
            {
                txt_DocRecd_Date.Visible = true;
                lbl_DocRecd_Date.Visible = true;
            }
            else
            {
                txt_DocRecd_Date.Visible = false;
                lbl_DocRecd_Date.Visible = false;
            }
            //auto search


            txtInvoiceCurrency.Attributes.Add("onblur", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txtInvoiceCurrency.ClientID + "', '" + txtExRate.ClientID + "')");
            txtMiscellaneous_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Exch_Rate.ClientID + "')");
            txtAgency_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtAgency_Currency.ClientID + "', '" + txtAgency_Exch_Rate.ClientID + "')");
            txtDiscount_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtDiscount_Currency.ClientID + "', '" + txtDiscount_Exch_Rate.ClientID + "')");
            txtLoading_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtLoading_Currency.ClientID + "', '" + txtLoading_ExchRate.ClientID + "')");
            txtFreight_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtFreight_Currency.ClientID + "', '" + txtFreight_Exch_Rate.ClientID + "')");
            txtInsurance_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtInsurance_Currency.ClientID + "', '" + txtInsurance_Exch_Rate.ClientID + "')");
            txtHighSeaSale_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtHighSeaSale_Currency.ClientID + "', '" + txtHighSeaSale_Exch_Rate.ClientID + "')");
            txt_INV_MISC_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txt_INV_MISC_Currency.ClientID + "', '" + txt_INV_MISC_Exch_Rate.ClientID + "')");
            //auto search

            //Supplier
            txtSupplierName.Attributes.Add("onblur", "javascript:Call_Supplier('" + txtSupplierName.ClientID + "', '" + txtSupplierAddress.ClientID + "')");
            txtSupplier_Branch_Slno.Attributes.Add("onblur", "javascript:Call_Supplier('" + txtSupplierName.ClientID + "', '" + txtSupplierAddress.ClientID + "')");
            txtSupplier_Branch_Slno.Attributes.Add("focus", "javascript:Call_Supplier('" + txtSupplierName.ClientID + "', '" + txtSupplierAddress.ClientID + "')");
            txtSupplier_Branch_Slno.Attributes.Add("onkeyup", "javascript:Call_Supplier('" + txtSupplierName.ClientID + "', '" + txtSupplierAddress.ClientID + "')");
            txtSupplier_Branch_Slno.Attributes.Add("keydown", "javascript:Call_Supplier('" + txtSupplierName.ClientID + "', '" + txtSupplierAddress.ClientID + "')");
            txtSupplier_Branch_Slno.Attributes.Add("change", "javascript:Call_Supplier('" + txtSupplierName.ClientID + "', '" + txtSupplierAddress.ClientID + "')");

            //seller
            txtSellerName.Attributes.Add("onblur", "javascript:Call_Seller('" + txtSellerName.ClientID + "', '" + txtSellerAddress.ClientID + "')");

            //broker
            txtBrokerName.Attributes.Add("onblur", "javascript:Call_Broker('" + txtBrokerName.ClientID + "', '" + txtBrokerAddress.ClientID + "')");

            //txtFreight_Currency.Attributes.Add("onblur", "javascript:Call_Freight_Currency('" + txtFreight_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtFreight_Charges.ClientID + "', '" + txtFreight_Exch_Rate.ClientID + "')");//HIDE BY CHITHRA ON 11-12-2018- FOR FRT CALC WITH MISC
            //txtFreight_Currency.Attributes.Add("onblur", "javascript:Call_Freight_Currency('" + txtFreight_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtFreight_Charges.ClientID + "', '" + txtFreight_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" +txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "')");
            //txtInsurance_Currency.Attributes.Add("onblur", "javascript:Call_Insurance_Currency('" + txtInsurance_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtInsurance_Charges.ClientID + "', '" + txtInsurance_Exch_Rate.ClientID + "')");
            //txtInsurance_Currency.Attributes.Add("onblur", "javascript:Call_Insurance_Currency('" + txtInsurance_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtInsurance_Charges.ClientID + "', '" + txtInsurance_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "')");
            txt_ThirdPartyName.Attributes.Add("onblur", "javascript:CallServerside_GetThirdParty('" + txt_ThirdPartyName.ClientID + "', '" + txt_ThirdParty_Add1.ClientID + "')");

            //txtInsurance_Rate.Attributes.Add("onkeyup", "javascript:Call_Insurance_Currency('" + txtInsurance_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtInsurance_Charges.ClientID + "', '" + txtInsurance_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "')");
            //txtFreight_Rate.Attributes.Add("onkeyup", "javascript:Call_Freight_Currency('" + txtFreight_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtFreight_Charges.ClientID + "', '" + txtFreight_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "')");

            //Need settings here
            if (Connection.COMPANYID() == "293" || Connection.COMPANYID() == "480" || Connection.COMPANYID() == "1011" || Connection.COMPANYID() == "1019" || Connection.COMPANYID() == "1057" || Connection.COMPANYID() == "1180")// Invoice No availed Jobno List
            {
                txtInvoiceNo.Attributes.Add("onblur", "javascript:CallServerside_Get_DuplicateInvoice_No('" + txtInvoiceNo.ClientID + "', '" + IMPORT_JOBNO + "')");
            }

            string fff = txtFreight_Exch_Rate.Text;

            //txtFreight_Currency.Attributes.Add("onblur", "javascript:Call_Freight_Currency('" + txtFreight_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtFreight_Charges.ClientID + "', '" + txtFreight_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "' , '" + EXRATE + "')");
            //txtInsurance_Currency.Attributes.Add("onblur", "javascript:Call_Insurance_Currency('" + txtInsurance_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtInsurance_Charges.ClientID + "', '" + txtInsurance_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "' , '" + EXRATE + "')");

            //txtInsurance_Rate.Attributes.Add("onkeyup", "javascript:Call_Insurance_Currency('" + txtInsurance_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtInsurance_Charges.ClientID + "', '" + txtInsurance_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "' , '" + RATE + "')");
            //txtFreight_Rate.Attributes.Add("onkeyup", "javascript:Call_Freight_Currency('" + txtFreight_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtFreight_Charges.ClientID + "', '" + txtFreight_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "' , '" + RATE + "')");

            //hide by chithra on 07-01-2019 for Agility INV_MISC_SPLIT Calc
            //txtFreight_Currency.Attributes.Add("onblur", "javascript:Call_Freight_Currency('" + txtFreight_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtFreight_Charges.ClientID + "', '" + txtFreight_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "' , '" + EXRATE + "' , '" + txtExRate.ClientID + "')");
            //txtInsurance_Currency.Attributes.Add("onblur", "javascript:Call_Insurance_Currency('" + txtInsurance_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtInsurance_Charges.ClientID + "', '" + txtInsurance_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "' , '" + EXRATE + "' , '" + txtExRate.ClientID + "')");

            //*************** 04-07-2020 --this below details hide by Chithra - instead of this implemntd in page script.
            //txtFreight_Currency.Attributes.Add("onblur", "javascript:Call_Freight_Currency('" + txtFreight_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtFreight_Charges.ClientID + "', '" + txtFreight_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "' , '" + EXRATE + "' , '" + txtExRate.ClientID  +"', '" + txt_INV_MISC_Charges.ClientID + "', '" + chk_active_Inv_Misc.ClientID + "')");
            //txtInsurance_Currency.Attributes.Add("onblur", "javascript:Call_Insurance_Currency('" + txtInsurance_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtInsurance_Charges.ClientID + "', '" + txtInsurance_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "' , '" + EXRATE + "' , '" + txtExRate.ClientID + "', '" + txt_INV_MISC_Charges.ClientID + "', '" + chk_active_Inv_Misc.ClientID + "')");
            //*************** 04-07-2020

            //hide bu chithra on 07-01-2019 for Agility INV_MISC_SPLIT Calc
            //txtInsurance_Rate.Attributes.Add("onkeyup", "javascript:Call_Insurance_Currency('" + txtInsurance_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtInsurance_Charges.ClientID + "', '" + txtInsurance_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "' , '" + RATE + "' , '" + txtExRate.ClientID + "')");
            //txtFreight_Rate.Attributes.Add("onkeyup", "javascript:Call_Freight_Currency('" + txtFreight_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtFreight_Charges.ClientID + "', '" + txtFreight_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "' , '" + RATE + "' , '" + txtExRate.ClientID + "')");

            //*************** 04-07-2020--this below details hide by Chithra - instead of this implemntd in page script.
            //txtFreight_Rate.Attributes.Add("onkeyup", "javascript:Call_Freight_Currency('" + txtFreight_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtFreight_Charges.ClientID + "', '" + txtFreight_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "' , '" + RATE + "' , '" + txtExRate.ClientID + "', '" + txt_INV_MISC_Charges.ClientID + "', '" + chk_active_Inv_Misc.ClientID + "')");
            //txtInsurance_Rate.Attributes.Add("onkeyup", "javascript:Call_Insurance_Currency('" + txtInsurance_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtInsurance_Charges.ClientID + "', '" + txtInsurance_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "' , '" + RATE + "' , '" + txtExRate.ClientID + "', '" + txt_INV_MISC_Charges.ClientID + "', '" + chk_active_Inv_Misc.ClientID + "')");

            //txtInsurance_Exch_Rate.Attributes.Add("onkeyup", "javascript:Call_Insurance_Currency('" + txtInsurance_Currency.ClientID + "','" + txtInvoiceCurrency.ClientID + "','" + txtInvoiceValue.ClientID + "','" + txtInsurance_Charges.ClientID + "', '" + txtInsurance_Exch_Rate.ClientID + "','" + txtMiscellaneous_Currency.ClientID + "', '" + txtMiscellaneous_Charges.ClientID + "' , '" + ddlTerms.ClientID + "' , '" + txt_Handling_Charges.ClientID + "' , '" + txt_Loading_Charges.ClientID + "' , '" + txt_UnLoading_Charges.ClientID + "' , '" + RATE + "' , '" + txtExRate.ClientID + "', '" + txt_INV_MISC_Charges.ClientID + "', '" + chk_active_Inv_Misc.ClientID + "')");
            //*************** 04-07-2020


            if (!IsPostBack)
            {
                CalendarExtender1.EndDate = DateTime.Today;
                HD_Imp_Name.Value = Convert.ToString(Session["IMPORTER_NAME"]);
                hdn_Br_Slno.Value = Convert.ToString(Session["BRANCH_NO"]);
                hdn_IEC_No.Value = Convert.ToString(Session["ICENO"]);

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
                //txtInsurance_Rate.Text = "1.1250";//hide on 07-11-2025 by Chithra

                //if (hdn_Cilent_InsuranceRate.Value != "")
                //{
                //    txtInsurance_Rate.Text = hdn_Cilent_InsuranceRate.Value;
                //}
                //else
                //{
                //    txtInsurance_Rate.Text = "1.1250";
                //}

                txtFreight_Charges.Text = "";
                txtInsurance_Charges.Text = "";
                txtInvoiceNo.Focus();
                ddlterms();

                ddlLoading_On();
                ddlAssesableStatus();
                ddlDutyStatus();
                ddlRevenueDeposit();
                ddlNatureOfTrans_List();
                ddlValuationMethod_List();
                ddlNatureOfPayment_list();


                if (Session["BE_TYPE"].ToString() == "SEZ DTA-M")
                {
                    ddlTerms.SelectedValue = "CIF";
                    //txtInvoiceCurrency.Text = "INR";//03-07-2024
                    //txtExRate.Text = "1";//03-07-2024
                }


                if (Connection.COMPANYID() == "1532")//SMS Clearing
                {
                    ddlNatureOfTrans.Items.Remove("O Others");
                    ddlNatureOfTrans.Items.Insert(0, "O Others");

                    ddlNatureOfPayment.Items.Remove("OTH Others"); // Modified by shanthini on 09/06/2026
                    ddlNatureOfPayment.Items.Insert(0, "OTH Others");

                    //btngenexcel.Visible = false;
                }
                else if (Connection.COMPANYID() == "1701" || COMPANY_IDD == "3316")//DIAMOND CARGO 
                {
                    ddlNatureOfTrans.Items.Remove("O Others");
                    ddlNatureOfTrans.Items.Insert(0, "O Others");
                }
                else if (Connection.COMPANYID() == "1535")//AMBER Logistics
                {
                    ddlNatureOfTrans.Items.Remove("C Consignment");
                    ddlNatureOfTrans.Items.Insert(0, "C Consignment");
                }

                gridbind(inv_no, flag, TERMS, inv_slno);
                hdn_INVOICE_SLNO.Value = "";
                Session["_SLNO"] = null;




                // start added by jayanthi on 19-Mar-22
                if (ViewState["INVOICE_ID"] == "" || ViewState["INVOICE_ID"] == null)
                {
                    if (Session["IsCHA_Mapped"] != null)
                    {
                        if (Session["FRT_IMP_JOBNO_CHA"] != null && Session["IsCHA_Mapped"].ToString() == "Y")
                        {
                            INV_Load_From_FRT();
                        }
                    }
                }
                // end  added by jayanthi on 19-Mar-22

            }

            if (ViewState["INVOICE_ID"] != "" && ViewState["INVOICE_ID"] != null)
            {
                btnSave.Visible = false;
                btn_save_new.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                //btnSave.Text = "Add";

            }
            else
            {
                btnSave.Visible = true;
                btn_save_new.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

                //Default Insurance Rate - from Client Master
                if (hdn_LoadStatus.Value == "")//btn click Save,Update
                {
                    string client_settings = Get_ClientMaster_Insurance_details(HD_Imp_Name.Value, hdn_Br_Slno.Value, hdn_IEC_No.Value);
                    string[] str_sp = client_settings.Split('~');

                    hdn_Cilent_InsuranceRate.Value = str_sp[0];
                    ddlNatureOfTrans.SelectedValue = str_sp[1];
                    ddlNatureOfPayment.SelectedValue = str_sp[2];
                    ddlValuationMethod.SelectedValue = str_sp[3];

                }

                if (hdn_Cilent_InsuranceRate.Value != "")
                {
                    txtInsurance_Rate.Text = hdn_Cilent_InsuranceRate.Value;
                }
                else
                {
                    txtInsurance_Rate.Text = "1.1250";
                }

            }
            if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
            {
                JOB_LOCK = Session["JOB_LOCK"].ToString();

                if (Convert.ToInt32(JOB_LOCK) == 1)
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnNew.Enabled = false;
                    btngenexcel.Enabled = false;
                    btnSave.Enabled = false;
                    btn_save_new.Enabled = false;

                    btnNew.ToolTip = "This Job is Locked by Admin";
                    btnSave.ToolTip = "This Job is Locked by Admin";
                    btn_save_new.ToolTip = "This Job is Locked by Admin";
                    btnUpdate.ToolTip = "This Job is Locked by Admin";
                    btnDelete.ToolTip = "This Job is Locked by Admin";

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
                            btn_save_new.Enabled = false;
                            btngenexcel.Enabled = false;

                            MP_U.Show();

                            lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                            btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnDelete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnNew.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnSave.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btn_save_new.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btngenexcel.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                        }
                    }
                }
            }

            CHK_True_False();

            Misc_Hss();

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void INV_Load_From_FRT()
    {
        try
        {

            string trmode = Session["TRANSPORT_MODE"].ToString();
            DataSet ds = new DataSet();
            Transact.SEARCH_CAT = ""; Transact.SEARCH_ITEM = Session["FRT_IMP_JOBNO_CHA"].ToString();
            Transact.WORKING_PERIOD = currentbranch; Transact.TRANSPORT_MODE = trmode;

            if (trmode == "Air")
            {
                Transact.flag = "Import-Air-JobNo";
            }
            else if (trmode == "Sea")
            {
                Transact.flag = "Import-Sea-JobNo";
            }
            else if (trmode == "Land")
            {
                Transact.flag = "Import-Other-Jobno";
            }

            ds = Transact.FREIGHT_IMP_EXP_Job_Load();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtInvoiceNo.Text = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                    txtDate.Text = ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
                    txtInvoiceValue.Text = ds.Tables[0].Rows[0]["INVOICEVALUE"].ToString();
                    txtInvoiceCurrency.Text = ds.Tables[0].Rows[0]["INVOICECURRENCY"].ToString();
                    txtSVB_RefNo.Text = ds.Tables[0].Rows[0]["SVB_REFNO"].ToString();
                    txtSVBDate.Text = ds.Tables[0].Rows[0]["SVBREF_DATE"].ToString();

                    txtSupplierName.Text = ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString();
                    txtSupplierAddress.Text = ds.Tables[0].Rows[0]["SUP_ADDRESS1"].ToString();
                    txtSupplierAddress1.Text = ds.Tables[0].Rows[0]["SUP_ADDRESS2"].ToString();
                    txtSupplierAddress2.Text = ds.Tables[0].Rows[0]["SUP_ADDRESS3"].ToString();
                    txtSuppliercountry_pincode.Text = ds.Tables[0].Rows[0]["SUP_COUNTRYPIN"].ToString();
                    txtSupplierCountryName.Text = ds.Tables[0].Rows[0]["SUP_COUNTRYNAME"].ToString();
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
            //user_Create.RetrieveAll_User_Screen_Rights_Details(i);
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
                btn_save_new.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnNew.ToolTip = "You don't have permission to access";
                btnSave.ToolTip = "You don't have permission to access";
                btn_save_new.ToolTip = "You don't have permission to access";
                btnUpdate.ToolTip = "You don't have permission to access";
                btnDelete.ToolTip = "You don't have permission to access";
                hdn_Grid_Disable.Value = "1";

            }
            else
            {
                //---------------SAVE BUTTON------------------//
                if (PAGE_WRITE == "True")
                {
                    btnSave.Enabled = true;
                    btn_save_new.Enabled = true;
                    btnNew.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                    btn_save_new.Enabled = false;
                    btnSave.ToolTip = "You don't have permission to access";
                    btn_save_new.ToolTip = "You don't have permission to access";
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
            if (hdn_Grid_Disable.Value == "1")
                gv_Invoice.ToolTip = "You don't have permission to access";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    public void ddlterms_clear()
    {
        try
        {
            ddlTerms.Items.Clear();
            ddlTerms.Items.Add("FOB");
            ddlTerms.Items.Add("CI");
            ddlTerms.Items.Add("CF");
            ddlTerms.Items.Add("CIF");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }


    public void ddlterms()
    {
        try
        {
            ddlTerms.Items.Add("FOB");
            ddlTerms.Items.Add("CI");
            ddlTerms.Items.Add("CF");
            ddlTerms.Items.Add("CIF");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void ddlLoading_On()
    {
        try
        {
            ddlLoadingOn.Items.Add("");
            ddlLoadingOn.Items.Add("Assessable");
            ddlLoadingOn.Items.Add("Duty");
            ddlLoadingOn.Items.Add("Both");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void ddlLoading_OnEdit()
    {
        try
        {
            ddlLoadingOn.Items.Add("Assessable");
            ddlLoadingOn.Items.Add("Duty");
            ddlLoadingOn.Items.Add("Both");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void ddlRevenueDeposit_Clear()
    {
        try
        {
            ddlRevenueDeposit_On.Items.Clear();
            ddlRevenueDeposit_On.Items.Add("");

            ddlRevenueDeposit_On.Items.Add("Assessable");
            ddlRevenueDeposit_On.Items.Add("Duty");
            ddlRevenueDeposit_On.Items.Add("Both");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

    }

    public void ddlRevenueDeposit()
    {
        try
        {
            ddlRevenueDeposit_On.Items.Add("");

            ddlRevenueDeposit_On.Items.Add("Assessable");
            ddlRevenueDeposit_On.Items.Add("Duty");
            ddlRevenueDeposit_On.Items.Add("Both");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

    }

    public void ddlRevenueDeposit_Edit()
    {
        try
        {
            ddlRevenueDeposit_On.Items.Add("Assessable");
            ddlRevenueDeposit_On.Items.Add("Duty");
            ddlRevenueDeposit_On.Items.Add("Both");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

    }

    public void ddlAssesableStatus()
    {
        try
        {
            ddlAssesable_Status.Items.Add("");

            ddlAssesable_Status.Items.Add("Provisional");
            ddlAssesable_Status.Items.Add("Final");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

    }
    public void ddlAssesableStatusEdit()
    {
        try
        {

            ddlAssesable_Status.Items.Add("Provisional");
            ddlAssesable_Status.Items.Add("Final");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }


    public void ddlDutyStatus()
    {
        try
        {
            ddlDuty_Status.Items.Add("");

            ddlDuty_Status.Items.Add("Provisional");
            ddlDuty_Status.Items.Add("Final");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    public void ddlDutyStatusEdit()
    {
        try
        {

            ddlDuty_Status.Items.Add("Provisional");
            ddlDuty_Status.Items.Add("Final");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }


    public void ddlNatureOfTrans_List()
    {
        try
        {
            ddlNatureOfTrans.Items.Add("S Sale");
            ddlNatureOfTrans.Items.Add("F Free Of Cost");
            ddlNatureOfTrans.Items.Add("C Consignment");
            ddlNatureOfTrans.Items.Add("G Gift");
            ddlNatureOfTrans.Items.Add("H Hire");
            ddlNatureOfTrans.Items.Add("M Sample");
            ddlNatureOfTrans.Items.Add("O Others");
            ddlNatureOfTrans.Items.Add("P Replacement");
            ddlNatureOfTrans.Items.Add("R Rent");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void ddlNatureOfPayment_list()
    {
        try
        {
            ddlNatureOfPayment.Items.Add("OTH Others");
            ddlNatureOfPayment.Items.Add("DP Document Presentation");
            ddlNatureOfPayment.Items.Add("FC Free Of Charge");
            ddlNatureOfPayment.Items.Add("LC Letter Of Credit");
            ddlNatureOfPayment.Items.Add("SD Site Draft");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void ddlValuationMethod_List()
    {
        try
        {
            ddlValuationMethod.Items.Add("Rule 4 - Transaction Value");
            ddlValuationMethod.Items.Add("Rule 5 - Identical Goods");
            ddlValuationMethod.Items.Add("Rule 6 - Similar Goods");
            ddlValuationMethod.Items.Add("Rule 7 - Deductive Value");
            /* 
            ddlValuationMethod.Items.Add("Rule 7A - Computed Value");
            ddlValuationMethod.Items.Add("Rule 8 - Residual Method");
            ddlValuationMethod.Items.Add("Rule 9 - SVB Related Goods");
             * */

            ddlValuationMethod.Items.Add("Rule 8 - Computed Value");
            ddlValuationMethod.Items.Add("Rule 9 - Residual Method");
            ddlValuationMethod.Items.Add("Rule 10 - Cost and Services");
            ddlValuationMethod.Items.Add("Rule 11 - Declaration by Importer");
            ddlValuationMethod.Items.Add("Rule 12 - Rejection of Declared Value");

            ddlValuationMethod.Items.Add("OTHERS - Others");
            ddlValuationMethod.Items.Add("Rule 3-Determination Method of Valuation");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public DataSet insert_update(string a1, string a2, string a3, string a4, string a5, string a6, string chkmis)
    {
        try
        {
            if (a5 == "")
                a5 = "0";
            if (a6 == "")
                a6 = "0";

            if ((Session["BE_TYPE"].ToString() == "Ex-Bond" || Session["BE_TYPE"].ToString() == "SEZ DTA-T") && hdn_Direct_Exbond_YN.Value == "Y")
            {
                a4 = txt_InvoiceSlno.Text;
            }

            Transact.INV_SLNO = a4;

            Transact.INVOICE_ID = a1;
            Transact.JOBNO = IMPORT_JOBNO; //session jobno
            //Transact.INVOICE_NO = txtInvoiceNo.Text.ToUpper();
            Transact.INVOICE_NO = txtInvoiceNo.Text.Trim().ToUpper();
            Transact.INVOICE_DATE = INV_DATE;
            Transact.TERMS = ddlTerms.SelectedValue.ToString();
            Transact.INVOICE_CURRENCY = txtInvoiceCurrency.Text.ToUpper();
            Transact.INVOICE_EXRATE = txtExRate.Text;
            Transact.INVOICE_VALUE = txtInvoiceValue.Text;
            Transact.SUPPLIER_NAME = txtSupplierName.Text;
            Transact.SUPPLIER_BRANCH_SLNO = txtSupplier_Branch_Slno.Text;


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

            /* hide by Chithra on 20-Dec-2018 - for FRT & INS value wrongly moving in Flatfile..
           //Transact.MIS_FREIGHT_CHARGES = a5;
           //Transact.MIS_FREIGHT_RATE = txtFreight_Rate.Text;
           //Transact.MIS_FREIGHT_CURRENCY = txtFreight_Currency.Text.ToUpper();
           //Transact.MIS_FREIGHT_EXRATE = txtFreight_Exch_Rate.Text;
           //Transact.MIS_INSURANCE_CHARGES = a6;
           //Transact.MIS_INSURANCE_RATE = txtInsurance_Rate.Text;
           //Transact.MIS_INSURANCE_CURRENCY = txtInsurance_Currency.Text.ToUpper();
           //Transact.MIS_INSURANCE_EXRATE = txtInsurance_Exch_Rate.Text;
           */

            if (ddlTerms.SelectedValue.ToString() == "FOB")
            {
                Transact.MIS_FREIGHT_CHARGES = a5;
                Transact.MIS_INSURANCE_CHARGES = a6;

                Transact.MIS_FREIGHT_RATE = txtFreight_Rate.Text;
                Transact.MIS_FREIGHT_CURRENCY = txtFreight_Currency.Text.ToUpper();
                Transact.MIS_FREIGHT_EXRATE = txtFreight_Exch_Rate.Text;


                if (txtInsurance_Rate.Text != "")
                {
                    if (txtInsurance_Rate.Text.Substring(0, 1) == ".")
                    {
                        txtInsurance_Rate.Text = "0" + txtInsurance_Rate.Text;
                    }
                }

                Transact.MIS_INSURANCE_RATE = txtInsurance_Rate.Text;
                Transact.MIS_INSURANCE_CURRENCY = txtInsurance_Currency.Text.ToUpper();
                Transact.MIS_INSURANCE_EXRATE = txtInsurance_Exch_Rate.Text;

                txtFreight_Currency.Enabled = true;
                txtFreight_Exch_Rate.Enabled = true;
                txtFreight_Rate.Enabled = true;

                txtInsurance_Currency.Enabled = true;
                txtInsurance_Exch_Rate.Enabled = true;
                txtInsurance_Rate.Enabled = true;
            }
            else if (ddlTerms.SelectedValue.ToString() == "CF")
            {
                Transact.MIS_FREIGHT_CHARGES = "0";
                Transact.MIS_INSURANCE_CHARGES = a6;

                Transact.MIS_FREIGHT_RATE = "";
                Transact.MIS_FREIGHT_CURRENCY = "";
                Transact.MIS_FREIGHT_EXRATE = "";

                if (txtInsurance_Rate.Text != "")
                {
                    if (txtInsurance_Rate.Text.Substring(0, 1) == ".")
                    {
                        txtInsurance_Rate.Text = "0" + txtInsurance_Rate.Text;
                    }
                }


                Transact.MIS_INSURANCE_RATE = txtInsurance_Rate.Text;
                Transact.MIS_INSURANCE_CURRENCY = txtInsurance_Currency.Text.ToUpper();
                Transact.MIS_INSURANCE_EXRATE = txtInsurance_Exch_Rate.Text;
            }
            else if (ddlTerms.SelectedValue.ToString() == "CI")
            {
                Transact.MIS_FREIGHT_CHARGES = a5;
                Transact.MIS_INSURANCE_CHARGES = "0";

                Transact.MIS_FREIGHT_RATE = txtFreight_Rate.Text;
                Transact.MIS_FREIGHT_CURRENCY = txtFreight_Currency.Text.ToUpper();
                Transact.MIS_FREIGHT_EXRATE = txtFreight_Exch_Rate.Text;

                Transact.MIS_INSURANCE_RATE = "";
                Transact.MIS_INSURANCE_CURRENCY = "";
                Transact.MIS_INSURANCE_EXRATE = "";
            }
            else
            {
                Transact.MIS_FREIGHT_CHARGES = "0";
                Transact.MIS_INSURANCE_CHARGES = "0";

                Transact.MIS_FREIGHT_RATE = "";
                Transact.MIS_FREIGHT_CURRENCY = "";
                Transact.MIS_FREIGHT_EXRATE = "";

                Transact.MIS_INSURANCE_RATE = "";
                Transact.MIS_INSURANCE_CURRENCY = "";
                Transact.MIS_INSURANCE_EXRATE = "";

                txtFreight_Currency.Enabled = false;
                txtFreight_Exch_Rate.Enabled = false;
                txtFreight_Rate.Enabled = false;

                txtInsurance_Currency.Enabled = false;
                txtInsurance_Exch_Rate.Enabled = false;
                txtInsurance_Rate.Enabled = false;
            }



            Transact.MIS_HIGHSEASALE_CHARGES = txtHighSeaSale_Charges.Text;
            Transact.MIS_HIGHSEASALE_EXRATE = txtHighSeaSale_Exch_Rate.Text;
            Transact.MIS_HIGHSEASALE_RATE = txtHighSeaSale_Rate.Text;
            Transact.MIS_HIGHSEASALE_CURRENCY = txtHighSeaSale_Currency.Text.ToUpper();

            Transact.MIS_SINGLE_OR_MULITIPLE = chkmis;

            string chksvb;
            if (chkSVB_Relation.Checked == true)
            {
                chksvb = "Y";

                Transact.SVB_RELATION = chksvb;
                Transact.SVB_REF_DATE = SVB_DATE;
                Transact.SVB_REF_NO = txtSVB_RefNo.Text;
                Transact.SVB_CUSTOM_HOUSE = txtCustomsHouse.Text.ToUpper();
                hdn_Customhouse_chk.Value = Set_Customs_House_Validation(txtCustomsHouse.Text);


                if (hdn_MultiBond_Select.Value == "Yes")
                {
                    txtAssesable_Rate.Text = hdn_Assesable_Rate.Value;
                    ddlAssesable_Status.SelectedValue = hdn_Assesable_Status.Value;
                    txtDuty_Rate.Text = hdn_Duty_Rate.Value;
                    ddlDuty_Status.SelectedValue = hdn_Duty_Status.Value;
                }

                if (ddlLoadingOn.SelectedValue == "Assessable")
                {
                    LoadingOn = "A";
                    Transact.SVB_ASSESABLE_RATE = txtAssesable_Rate.Text;
                    Transact.SVB_DUTY_RATE = "";
                }
                else if (ddlLoadingOn.SelectedValue == "Duty")
                {
                    LoadingOn = "D";
                    Transact.SVB_ASSESABLE_RATE = "";
                    Transact.SVB_DUTY_RATE = txtDuty_Rate.Text;
                }
                else if (ddlLoadingOn.SelectedValue == "Both")
                {
                    LoadingOn = "B";
                    Transact.SVB_ASSESABLE_RATE = txtAssesable_Rate.Text;
                    Transact.SVB_DUTY_RATE = txtDuty_Rate.Text;
                }

                Transact.SVB_LOADING_ON = LoadingOn;
                //Transact.SVB_ASSESABLE_RATE = txtAssesable_Rate.Text;
                //Transact.SVB_DUTY_RATE = txtDuty_Rate.Text;

                if (ddlAssesable_Status.SelectedValue == "Provisional")
                {
                    Ass_Status = "P";
                }
                else if (ddlAssesable_Status.SelectedValue == "Final")
                {
                    Ass_Status = "F";
                }

                //Transact.SVB_ASSESABLE_STATUS = Ass_Status;

                if (ddlDuty_Status.SelectedValue == "Provisional")
                {
                    Duty_Status = "P";
                }
                else if (ddlDuty_Status.SelectedValue == "Final")
                {
                    Duty_Status = "F";
                }

                //Transact.SVB_DUTY_STATUS = Duty_Status;


                if (ddlLoadingOn.SelectedValue == "Assessable")
                {
                    Transact.SVB_ASSESABLE_STATUS = Ass_Status;
                    Transact.SVB_DUTY_STATUS = "";
                }
                else if (ddlLoadingOn.SelectedValue == "Duty")
                {
                    Transact.SVB_ASSESABLE_STATUS = "";
                    Transact.SVB_DUTY_STATUS = Duty_Status;
                }
                else if (ddlLoadingOn.SelectedValue == "Both")
                {
                    Transact.SVB_ASSESABLE_STATUS = Ass_Status;
                    Transact.SVB_DUTY_STATUS = Duty_Status;
                }



                txtSVB_RefNo.Enabled = true;
                txtSVBDate.Enabled = true;
                txtCustomsHouse.Enabled = true;
                txtAssesable_Rate.Enabled = true;
                txtDuty_Rate.Enabled = true;
                ddlAssesable_Status.Enabled = true;
                ddlDuty_Status.Enabled = true;
                ddlLoadingOn.Enabled = true;
            }
            else
            {
                chksvb = "N";
                Transact.SVB_RELATION = chksvb;
                Transact.SVB_REF_DATE = SVB_DATE;
                Transact.SVB_REF_NO = "";
                Transact.SVB_CUSTOM_HOUSE = "";
                Transact.SVB_ASSESABLE_RATE = "";
                Transact.SVB_DUTY_RATE = "";
                Transact.SVB_ASSESABLE_STATUS = "";
                Transact.SVB_DUTY_STATUS = "";

                txtSVB_RefNo.Enabled = false;
                txtSVBDate.Enabled = false;
                txtCustomsHouse.Enabled = false;
                txtAssesable_Rate.Enabled = false;
                txtDuty_Rate.Enabled = false;
                ddlAssesable_Status.Enabled = false;
                ddlDuty_Status.Enabled = false;
                ddlLoadingOn.Enabled = false;

                ddlLoadingOn.Items.Clear();
                ddlLoading_On();
                ddlAssesable_Status.Items.Clear();
                ddlAssesableStatus();
                ddlDuty_Status.Items.Clear();
                ddlDutyStatus();
            }


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

            Transact.SAP_DELIEVERY_ID = txtSAP_Delievery_ID.Text;
            Transact.SHIP_DATE = SHIP_DATE;
            Transact.INVOICE_LEVEL = txtInvoice_Level.Text;
            Transact.COUNTRY_OF_DEPARTURE = txtCountry_Departure.Text;
            Transact.BRANCH_COMMON = SELECT_BRANCH;
            Transact.REVENUEDEPOSIT_RATE = txtRevenue_Deposit.Text;

            if (ddlRevenueDeposit_On.SelectedValue == "Assessable")
            {
                Revenue_LoadOn = "A";
            }
            else if (ddlRevenueDeposit_On.SelectedValue == "Duty")
            {
                Revenue_LoadOn = "D";
            }
            else if (ddlRevenueDeposit_On.SelectedValue == "Both")
            {
                Revenue_LoadOn = "B";
            }
            else
            {
                Revenue_LoadOn = "";
            }

            Transact.REVENUEDEPOSIT_ON = Revenue_LoadOn;

            Transact.MI_FREIGHT = ViewState["CHKF_F"].ToString();
            Transact.MI_INSURANCE = ViewState["CHKI_I"].ToString();

            string Chk_Misc_ = string.Empty, CHKHSS_ = string.Empty, Misc_total_amt = string.Empty, Hss_total_amt = string.Empty;

            if (chkMisc.Checked == true)
            {

                for (int k = 0; k < Chk_Misc.Items.Count; k++)
                {
                    if (Chk_Misc.Items[k].Selected)
                        Chk_Misc_ += Chk_Misc.Items[k].Value;
                }
                for (int M = 0; M < CHKHSS.Items.Count; M++)
                {
                    if (CHKHSS.Items[M].Selected)
                        CHKHSS_ += CHKHSS.Items[M].Value;
                }

                if (Chk_Misc_ != string.Empty)
                {
                    Chk_Misc_ = "Amt";
                }
                else
                {
                    Chk_Misc_ = "";
                    txtMisc_Total_Charge.Text = string.Empty;
                }

                if (CHKHSS_ != string.Empty)
                {
                    CHKHSS_ = "Amt";
                }
                else
                {
                    CHKHSS_ = "";
                    txtHss_Total_Charge.Text = string.Empty;
                }
            }
            else
            {
                //Chk_Misc_ = "";
                //CHKHSS_ = "";

                Chk_Misc_ = ViewState["CHK_MISC"].ToString();
                CHKHSS_ = ViewState["CHK_HSS"].ToString();

                txtMisc_Total_Charge.Text = string.Empty;
                txtHss_Total_Charge.Text = string.Empty;
            }
            Transact.MULTIPLE_MISC_AMT = txtMisc_Total_Charge.Text;
            Transact.MULTIPLE_HSS_AMT = txtHss_Total_Charge.Text;
            Transact.MI_MISC = Chk_Misc_;
            Transact.MI_HSS = CHKHSS_;

            Transact.TERMS_PLACE = txt_TermsPlace.Text;
            Transact.THIRDPARTY_NAME = txt_ThirdPartyName.Text;
            Transact.THIRDPARTY_ADD1 = txt_ThirdParty_Add1.Text;
            Transact.THIRDPARTY_ADD2 = txt_ThirdParty_Add2.Text;
            Transact.THIRDPARTY_CITY = txt_ThirdParty_City.Text;
            Transact.T_PARTY_COUNTRY_SUB_DIV = txt_Country_Division.Text;
            Transact.T_PARTY_COUNTRY_CODE = txt_CountryCode.Text;
            Transact.T_PARTY_PIN = txt_ThirdParty_Pin.Text;
            Transact.AUTHORIZED_ECONOMIC_OPERATOR_CODE = txt_Authrzd_Economic_Code.Text;
            Transact.A_E_O_COUNTRY = txt_Authrzd_Economic_Country.Text;
            Transact.AUTHORIZED_ECONOMIC_OPERATOR = txt_Authrzd_Economic_Role.Text;
            Transact.WHETHER_BUYER_SELLER_RELATED = txt_Whether_Relater_Y_N.Text.ToUpper();
            string hdn_Total_Other_Charge = "";

            if (ddlTerms.SelectedValue.ToString() == "CI" || ddlTerms.SelectedValue.ToString() == "FOB" || ddlTerms.SelectedValue.ToString() == "CIF" || ddlTerms.SelectedValue.ToString() == "CF")
            {
                Transact.A_AMOUNT = txt_Brokerage.Text;
                Transact.B_AMOUNT = txt_Cost_Container.Text;
                Transact.C_AMOUNT = txt_Cost_Packaging.Text;
                Transact.D_AMOUNT = txt_Handling_Charges.Text;
                Transact.E_AMOUNT = txt_Goods_Services.Text;
                Transact.F_AMOUNT = txt_Documentation.Text;
                Transact.G_AMOUNT = txt_Country_Origin.Text;
                Transact.H_AMOUNT = txt_Royalties_lic_fees.Text;
                Transact.I_AMOUNT = txt_Value_of_Proceeds.Text;
                Transact.J_AMOUNT = txt_Warrenty_Services.Text;
                Transact.K_AMOUNT = txt_Other_Cost_Payment.Text;
                Transact.L_AMOUNT = txt_Other_Charges_Payments.Text;
                Transact.M_AMOUNT = txt_Loading_Charges.Text;
                Transact.N_AMOUNT = txt_UnLoading_Charges.Text;
                hdn_Total_Other_Charge = hdn_Total_Other_Charges.Value;
            }
            else
            {
                Transact.A_AMOUNT = "";
                Transact.B_AMOUNT = "";
                Transact.C_AMOUNT = "";
                Transact.D_AMOUNT = "";
                Transact.E_AMOUNT = "";
                Transact.F_AMOUNT = "";
                Transact.G_AMOUNT = "";
                Transact.H_AMOUNT = "";
                Transact.I_AMOUNT = "";
                Transact.J_AMOUNT = "";
                Transact.K_AMOUNT = "";
                Transact.L_AMOUNT = "";
                Transact.M_AMOUNT = "";
                Transact.N_AMOUNT = "";

                txt_Handling_Charges.Text = "";
                txt_Loading_Charges.Text = "";
                txt_UnLoading_Charges.Text = "";

                hdn_Total_Other_Charge = "0";
            }


            if (hdn_Total_Other_Charge == "0")
            {
                Transact.TOTAL_OTHER_AMOUNT = "";
                txt_Total_Amount.Text = "";
            }
            else
            {
                Transact.TOTAL_OTHER_AMOUNT = hdn_Total_Other_Charge;
                txt_Total_Amount.Text = hdn_Total_Other_Charge;
            }
            Transact.REGISTRATION_DATE = txt_DocRecd_Date.Text;

            //--------------------- INV_MISC_SPLIT new-----------------------------

            Transact.INV_MISC_T_F = chk_active_Inv_Misc.Checked == true ? "T" : "F";

            if (Transact.INV_MISC_T_F == "T")
            {
                Transact.INV_MISC_CURRENCY = txt_INV_MISC_Currency.Text;
                Transact.INV_MISC_EXRATE = txt_INV_MISC_Exch_Rate.Text;
                Transact.INV_MISC_ADD_FRT_INS_YN = chk_add_INV_MISC.Checked == true ? "Y" : "N";
                Transact.INV_MISC_CHARGES = txt_INV_MISC_Charges.Text;
                //Transact.INV_MISC_TOTAL_CHARGES = txt_INV_MISC_Total_Charge.Text;
                Transact.INV_MISC_TOTAL_CHARGES = hdn_INV_MISC_Total_Charge.Value;
                txt_INV_MISC_Total_Charge.Text = hdn_INV_MISC_Total_Charge.Value;
                hdn_chk_active_Inv_Misc.Value = "T";

                txt_INV_MISC_Currency.Enabled = true;
                txt_INV_MISC_Exch_Rate.Enabled = true;
                chk_add_INV_MISC.Enabled = true;
                txt_INV_MISC_Charges.Enabled = true;
                //txt_INV_MISC_Total_Charge.Enabled = true;//hide on 28-08-2020 by  Chithra

            }
            else
            {
                Transact.INV_MISC_CURRENCY = "";
                Transact.INV_MISC_EXRATE = "";
                Transact.INV_MISC_ADD_FRT_INS_YN = "N";
                Transact.INV_MISC_CHARGES = "";
                Transact.INV_MISC_TOTAL_CHARGES = "";


                txt_INV_MISC_Currency.Enabled = false;
                txt_INV_MISC_Exch_Rate.Enabled = false;
                chk_add_INV_MISC.Enabled = false;
                txt_INV_MISC_Charges.Enabled = false;
                txt_INV_MISC_Total_Charge.Enabled = false;
                hdn_chk_active_Inv_Misc.Value = "F";
            }
            //--------------------- INV_MISC_SPLIT new-----------------------------


            Transact.AMENDMENT_TYPE = ddl_AmendmentType.SelectedValue;
            Transact.AMENDMENT_STATUS = "";
            Transact.JOBNO_PS = Session["JOBNO_PS"].ToString();

            dtuser = Transact.Invoice_Details_insertupdate();
            i = Transact.result;

            
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
        return dtuser;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Inv_Avail = Check_Inv_Slno_Avail("Check_Inv_Slno_Avail_Save", "");

            if (Inv_Avail != "Exists")
            {

                if (chkMisc.Checked == true)
                {
                }
                else
                {
                    txtFreight_Rate.Text = hdn_Freight_Rate.Value;
                    txtInsurance_Rate.Text = hdn_Insurance_Rate.Value;

                    txtMiscellaneous_Rate.Enabled = true;
                    txtMiscellaneous_Charges.Enabled = true;

                    txtHighSeaSale_Rate.Enabled = true;
                    txtHighSeaSale_Charges.Enabled = true;
                }

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

                        Elogix_Service();
                        txtInvoiceNo.Focus();
                        hdn_button_click.Value = "";

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>document.getElementById('IMD').click();</script>", false);
                        Alert_msg("Invoice Saved Successfully", "btnSave");

                    }
                    else if (i == 2)
                    {
                        Terms_Change_Updating_MultiInvoice();
                        txtInvoiceNo.Focus();
                        Alert_msg("Invoice No Already Exist", "btnSave");
                    }
                    else if (i == 3)
                    {
                        Terms_Change_Updating_MultiInvoice();
                        txtInvoiceNo.Focus();
                        Alert_msg("Invoice No Already Exist", "btnSave");
                    }

                    else if (i == 0)
                    {
                        Terms_Change_Updating_MultiInvoice();
                        txtInvoiceNo.Focus();
                        Alert_msg("Record Not Saved", "btnSave");
                    }

                    Get_ProductValue();

                    if (gv_Invoice.Rows.Count > 0)
                    {

                        gv_Invoice.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                        GridViewRow saverow = gv_Invoice.Rows[gv_Invoice.Rows.Count - 1];
                        saverow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                        saverow.Font.Bold = true;
                        HDsaveid.Value = "1";
                    }
                }
                catch (Exception ex)
                {
                    er.makeLog(ex.Message);
                }

                CHK_True_False();

                if (hdn_BOND_NO.Value != "" && hdn_BOND_LOCATION.Value != "" && hdn_BOND_TYPE.Value != "")
                {
                    BOND_insert_update(IMPORT_JOBNO, "", "S", "");
                }
            }
            else
            {
                Alert_msg("Invoice Sl.No Already Exist!", "btnSave");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
        
    }

    private void Misc_Hss()
    {
        try
        {
            if (chkMisc.Checked == true)
            {
                DivMISC.Style.Add("display", "block");
                DivHSS.Style.Add("display", "block");
            }
            else
            {
                DivMISC.Style.Add("display", "none");
                DivHSS.Style.Add("display", "none");
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
            string Inv_Selected = gv_Invoice.DataKeys[gv_Invoice.SelectedIndex].Values["INVOICE_SLNO"].ToString();
            ddlInv_SL_No.SelectedValue = Inv_Selected;

            ViewState["Newbtn"] = 1;
            gv_Invoice.SelectedRowStyle.Font.Bold = true;
            gv_Invoice.SelectedRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
            ViewState["new_id"] = 1;
            ViewState["update_chk"] = +1;
            ViewState["Move_up_down_chk"] = 2;

            GridViewRow firstRow = gv_Invoice.Rows[0];
            if (ViewState["id"].ToString() == "1")
            {
                int ID;
                ID = gv_Invoice.SelectedIndex;
                if (ID == 0)
                {
                    GridViewRow Lastrow = gv_Invoice.Rows[gv_Invoice.Rows.Count - 1];
                    Lastrow.BackColor = System.Drawing.Color.White;
                    Lastrow.Font.Bold = false;
                    firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                }
                else
                {
                    firstRow.BackColor = System.Drawing.Color.White;
                    firstRow.Font.Bold = false;
                    //23-06-2015
                    if (this.gv_Invoice.SelectedIndex == gv_Invoice.Rows.Count - 1)
                    {
                        GridViewRow Lastrow = gv_Invoice.Rows[gv_Invoice.Rows.Count - 1];
                        Lastrow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                        Lastrow.Font.Bold = true;
                    }
                    else
                    {
                        GridViewRow Lastrow = gv_Invoice.Rows[gv_Invoice.Rows.Count - 1];
                        Lastrow.BackColor = System.Drawing.Color.White;
                        Lastrow.Font.Bold = false;
                    }
                }
                ViewState["id"] = "0";
            }
            else
            {
                int ID;
                ID = gv_Invoice.SelectedIndex;

                if (ID == 0)
                {

                    GridViewRow Lastrow = gv_Invoice.Rows[gv_Invoice.Rows.Count - 1];
                    Lastrow.BackColor = System.Drawing.Color.White;
                    Lastrow.Font.Bold = false;

                    firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                    firstRow.Font.Bold = true;
                }
                else
                {
                    firstRow.BackColor = System.Drawing.Color.White;
                    firstRow.Font.Bold = false;

                    //23-06-2015
                    if (this.gv_Invoice.SelectedIndex == gv_Invoice.Rows.Count - 1)
                    {
                        GridViewRow Lastrow = gv_Invoice.Rows[gv_Invoice.Rows.Count - 1];
                        Lastrow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                        Lastrow.Font.Bold = true;
                    }
                    else
                    {
                        GridViewRow Lastrow = gv_Invoice.Rows[gv_Invoice.Rows.Count - 1];
                        Lastrow.BackColor = System.Drawing.Color.White;
                        Lastrow.Font.Bold = false;
                    }
                }
            }

            ViewState["INVOICE_ID"] = Convert.ToString(this.gv_Invoice.SelectedDataKey.Value);

            if (ViewState["INVOICE_ID"] != "" && ViewState["INVOICE_ID"] != null)
            {
                hdn_grid_edit.Value = "1";
                hdn_button_click.Value = "1";

                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;

                hdn_update_Invoice_id.Value = ViewState["INVOICE_ID"].ToString();

                Label s_itemType = gv_Invoice.SelectedRow.FindControl("lblFullName") as Label;
                Session["_SLNO"] = s_itemType.Text;
                hdn_INVOICE_SLNO.Value = s_itemType.Text;
                sno = gv_Invoice.SelectedRow.Cells[2].Text;
                txt_InvoiceSlno.Text = sno;
                Session["INV_SLNO"] = sno;
                txtInvoiceNo.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[3].Text);
                txtDate.Text = gv_Invoice.SelectedRow.Cells[4].Text.Replace("01/01/1900", "");

                string terms = gv_Invoice.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                ddlterms_clear();
                ddlTerms.Items.Remove(terms);
                ddlTerms.Items.Insert(0, terms);
                hdn_load_Terms.Value = terms;
                txtInvoiceValue.Text = gv_Invoice.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

                txtInvoiceCurrency.Text = gv_Invoice.SelectedRow.Cells[7].Text.ToUpper().Replace("&nbsp;", "");
                hdn_chk_Invalid_Cur.Value = GetExchange_Rate_Invoice_Cur(txtInvoiceCurrency.Text);

                string chk = gv_Invoice.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
                hdn_Invoice_mode_singlr_or_multi.Value = chk;
                txtSupplierName.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[9].Text);
                txtSupplier_Branch_Slno.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[129].Text);
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
                hdn_chk_curr.Value = GetExchange_Rate(txtMiscellaneous_Currency.Text);

                txtMiscellaneous_Exch_Rate.Text = gv_Invoice.SelectedRow.Cells[33].Text.Replace("&nbsp;", "");
                txtAgency_Charges.Text = gv_Invoice.SelectedRow.Cells[34].Text.Replace("&nbsp;", "");
                txtAgency_Rate.Text = gv_Invoice.SelectedRow.Cells[35].Text.Replace("&nbsp;", "");
                txtAgency_Currency.Text = gv_Invoice.SelectedRow.Cells[36].Text.Replace("&nbsp;", "");
                txtAgency_Exch_Rate.Text = gv_Invoice.SelectedRow.Cells[37].Text.Replace("&nbsp;", "");
                txtDiscount_Charges.Text = gv_Invoice.SelectedRow.Cells[38].Text.Replace("&nbsp;", "");
                txtDiscount_Rate.Text = gv_Invoice.SelectedRow.Cells[39].Text.Replace("&nbsp;", "");

                txtDiscount_Currency.Text = gv_Invoice.SelectedRow.Cells[40].Text.Replace("&nbsp;", "");
                hdn_Invalid_Disc_Cur.Value = GetExchange_Rate(txtDiscount_Currency.Text);

                txtDiscount_Exch_Rate.Text = gv_Invoice.SelectedRow.Cells[41].Text.Replace("&nbsp;", "");
                txtDiscount_Reason.Text = gv_Invoice.SelectedRow.Cells[42].Text.Replace("&nbsp;", "");
                txtLoading_Charges.Text = gv_Invoice.SelectedRow.Cells[43].Text.Replace("&nbsp;", "");
                txtLoading_Rate.Text = gv_Invoice.SelectedRow.Cells[44].Text.Replace("&nbsp;", "");
                txtLoading_Currency.Text = gv_Invoice.SelectedRow.Cells[45].Text.Replace("&nbsp;", "");
                txtLoading_ExchRate.Text = gv_Invoice.SelectedRow.Cells[46].Text.Replace("&nbsp;", "");
                txtFreight_Charges.Text = gv_Invoice.SelectedRow.Cells[47].Text.Replace("&nbsp;", "");
                txtFreight_Rate.Text = gv_Invoice.SelectedRow.Cells[48].Text.Replace("&nbsp;", "");

                txtFreight_Currency.Text = gv_Invoice.SelectedRow.Cells[49].Text.Replace("&nbsp;", "");
                hdn_Invalid_FRT_Cur.Value = GetExchange_Rate(txtFreight_Currency.Text);

                txtFreight_Exch_Rate.Text = gv_Invoice.SelectedRow.Cells[50].Text.Replace("&nbsp;", "");
                txtInsurance_Charges.Text = gv_Invoice.SelectedRow.Cells[51].Text.Replace("&nbsp;", "");
                txtInsurance_Rate.Text = gv_Invoice.SelectedRow.Cells[52].Text.Replace("&nbsp;", "");

                txtInsurance_Currency.Text = gv_Invoice.SelectedRow.Cells[53].Text.Replace("&nbsp;", "");
                hdn_Invalid_INS_Cur.Value = GetExchange_Rate(txtInsurance_Currency.Text);

                txtInsurance_Exch_Rate.Text = gv_Invoice.SelectedRow.Cells[54].Text.Replace("&nbsp;", "");
                txtHighSeaSale_Charges.Text = gv_Invoice.SelectedRow.Cells[55].Text.Replace("&nbsp;", "");
                txtHighSeaSale_Rate.Text = gv_Invoice.SelectedRow.Cells[56].Text.Replace("&nbsp;", "");

                txtHighSeaSale_Currency.Text = gv_Invoice.SelectedRow.Cells[57].Text.Replace("&nbsp;", "");
                hdn_Invalid_Hss_Cur.Value = GetExchange_Rate(txtHighSeaSale_Currency.Text);

                txtHighSeaSale_Exch_Rate.Text = gv_Invoice.SelectedRow.Cells[58].Text.Replace("&nbsp;", "");
                txtExRate.Text = gv_Invoice.SelectedRow.Cells[78].Text.Replace("&nbsp;", "");

                if (chk == "M")
                {
                    chkMisc.Checked = true;
                    chkMisc.Enabled = true;

                    txtMisc_Total_Charge.Text = hdn_TOTAL_MULTIPLE_MISC_AMT.Value;
                    txtHss_Total_Charge.Text = hdn_TOTAL_MULTIPLE_HSS_AMT.Value;

                    if (gv_Invoice.SelectedRow.Cells[91].Text.Replace("&nbsp;", "") != null && gv_Invoice.SelectedRow.Cells[91].Text.Replace("&nbsp;", "") != string.Empty)
                    {
                        CHKF.SelectedValue = gv_Invoice.SelectedRow.Cells[91].Text.Replace("&nbsp;", "");
                        CHKI.SelectedValue = gv_Invoice.SelectedRow.Cells[92].Text.Replace("&nbsp;", "");
                        DivFreight.Style.Add("display", "block");
                        DivInsurance.Style.Add("display", "block");
                    }
                    else
                    {
                        DivFreight.Style.Add("display", "none");
                        DivInsurance.Style.Add("display", "none");
                    }

                    if (gv_Invoice.SelectedRow.Cells[93].Text.Replace("&nbsp;", "") != null && gv_Invoice.SelectedRow.Cells[93].Text.Replace("&nbsp;", "") != string.Empty)
                    {
                        Chk_Misc.SelectedValue = gv_Invoice.SelectedRow.Cells[93].Text.Replace("&nbsp;", "");
                        Div_MISC_txt.Style.Add("display", "block");

                        txtMiscellaneous_Rate.Enabled = false;
                        txtMiscellaneous_Charges.Enabled = false;
                    }
                    else
                    {
                        txtMiscellaneous_Rate.Enabled = true;
                        txtMiscellaneous_Charges.Enabled = true;
                        Chk_Misc.SelectedIndex = -1;
                        Div_MISC_txt.Style.Add("display", "none");
                    }
                    if (gv_Invoice.SelectedRow.Cells[94].Text.Replace("&nbsp;", "") != null && gv_Invoice.SelectedRow.Cells[94].Text.Replace("&nbsp;", "") != string.Empty)
                    {
                        CHKHSS.SelectedValue = gv_Invoice.SelectedRow.Cells[94].Text.Replace("&nbsp;", "");
                        Div_Hss_txt.Style.Add("display", "block");

                        txtHighSeaSale_Rate.Enabled = false;
                        txtHighSeaSale_Charges.Enabled = false;
                    }
                    else
                    {
                        txtHighSeaSale_Rate.Enabled = true;
                        txtHighSeaSale_Charges.Enabled = true;
                        CHKHSS.SelectedIndex = -1;
                        Div_Hss_txt.Style.Add("display", "none");
                    }

                    if (Int32.Parse(s_itemType.Text) == 1)
                    {
                        CHKF.Enabled = true;
                        CHKI.Enabled = true;

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

                        CHKF.Enabled = false;
                        CHKI.Enabled = false;

                        tag_Totalfrieght.Visible = true;
                        tag_TotalInsurance.Visible = true;
                        // ------------------Sriram Start---------------------------------------------------------------

                        txtFreight_Currency.Enabled = false;
                        txtFreight_Exch_Rate.Enabled = false;
                        txtInsurance_Currency.Enabled = false;
                        txtInsurance_Exch_Rate.Enabled = false;
                        // ------------------Sriram End---------------------------------------------------------------

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


                    if (chkMisc.Checked == false)
                    {
                        txtFreight_Rate.Text = "0.00";
                        txtInsurance_Rate.Text = "0.00";
                    }

                    if (Int32.Parse(s_itemType.Text) == 1)
                    {
                        if (ddlTerms.SelectedItem.Text == "FOB")
                        {
                            txtFreight_Exch_Rate.Enabled = true;
                            txtFreight_Currency.Enabled = true;

                            txtInsurance_Exch_Rate.Enabled = true;
                            txtInsurance_Currency.Enabled = true;
                        }
                        else if (ddlTerms.SelectedItem.Text == "CI")
                        {
                            txtFreight_Exch_Rate.Enabled = true;
                            txtFreight_Currency.Enabled = true;
                        }
                        else if (ddlTerms.SelectedItem.Text == "CF")
                        {
                            txtInsurance_Exch_Rate.Enabled = true;
                            txtInsurance_Currency.Enabled = true;
                        }

                    }

                    if (gv_Invoice.SelectedIndex == 0)
                    {
                        Chk_Misc.Enabled = true;
                        CHKHSS.Enabled = true;
                        txtMisc_Total_Charge.Enabled = true;
                        txtHss_Total_Charge.Enabled = true;
                    }
                    else
                    {
                        Chk_Misc.Enabled = false;
                        CHKHSS.Enabled = false;
                        txtMisc_Total_Charge.Enabled = false;
                        txtHss_Total_Charge.Enabled = false;
                    }

                }
                else
                {
                    pnl_Multi_Invoice.Enabled = true;

                    if (gv_Invoice.SelectedIndex == 0)
                    {
                        chkMisc.Enabled = true;
                        chkMisc.Checked = false;
                    }
                    else
                    {
                        chkMisc.Enabled = false;
                        chkMisc.Checked = false;
                    }
                    DivFreight.Style.Add("display", "none");
                    DivInsurance.Style.Add("display", "none");

                    Div_MISC_txt.Style.Add("display", "none");
                    Div_Hss_txt.Style.Add("display", "none");

                    DivMISC.Style.Add("display", "none");
                    DivHSS.Style.Add("display", "none");

                    Chk_Misc.SelectedIndex = 0;
                    CHKHSS.SelectedIndex = 0;

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
                    if (ddlTerms.SelectedItem.Text == "FOB")
                    {
                        txtFreight_Exch_Rate.Enabled = true;
                        txtFreight_Currency.Enabled = true;

                        txtInsurance_Exch_Rate.Enabled = true;
                        txtInsurance_Currency.Enabled = true;
                    }
                    else if (ddlTerms.SelectedItem.Text == "CI")
                    {
                        txtFreight_Exch_Rate.Enabled = true;
                        txtFreight_Currency.Enabled = true;
                    }
                    else if (ddlTerms.SelectedItem.Text == "CF")
                    {
                        txtInsurance_Exch_Rate.Enabled = true;
                        txtInsurance_Currency.Enabled = true;
                    }
                }

                string chksvb = gv_Invoice.SelectedRow.Cells[59].Text.Replace("&nbsp;", "");
                if (chksvb == "Y")
                {
                    chkSVB_Relation.Checked = true;
                    txtSVB_RefNo.Enabled = true;
                    txtSVBDate.Enabled = true;
                    txtCustomsHouse.Enabled = true;

                    ddlLoadingOn.Enabled = true;

                    txtSVB_RefNo.Text = gv_Invoice.SelectedRow.Cells[60].Text.Replace("&nbsp;", "");
                    string SVB_CustomHouse = gv_Invoice.SelectedRow.Cells[61].Text.Replace("&nbsp;", "");
                    txtCustomsHouse.Text = SVB_CustomHouse;
                    hdn_Customhouse_chk.Value = Set_Customs_House_Validation(txtCustomsHouse.Text);

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

                        txtAssesable_Rate.Enabled = true;
                        ddlAssesable_Status.Enabled = true;
                        txtDuty_Rate.Enabled = true;
                        ddlDuty_Status.Enabled = true;
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
                }
                else
                {
                    chkSVB_Relation.Checked = false;
                    txtSVB_RefNo.Text = "";
                    txtCustomsHouse.Text = "";
                    txtAssesable_Rate.Text = "";
                    txtDuty_Rate.Text = "";
                    ddlAssesable_Status.Text = "";
                    ddlDuty_Status.Text = "";
                    ddlLoadingOn.Text = "";
                    txtSVBDate.Text = "";

                    txtSVB_RefNo.Enabled = false;
                    txtSVBDate.Enabled = false;
                    txtCustomsHouse.Enabled = false;
                    txtAssesable_Rate.Enabled = false;
                    txtDuty_Rate.Enabled = false;
                    ddlAssesable_Status.Enabled = false;
                    ddlDuty_Status.Enabled = false;
                    ddlLoadingOn.Enabled = false;


                }


                txtPurchaseOrderNo.Text = gv_Invoice.SelectedRow.Cells[67].Text.Replace("&nbsp;", "");
                txtPurchaseDate.Text = gv_Invoice.SelectedRow.Cells[68].Text.Replace("01/01/1900", "");
                txtContractNo.Text = gv_Invoice.SelectedRow.Cells[69].Text.Replace("&nbsp;", "");
                txtContractDate.Text = gv_Invoice.SelectedRow.Cells[70].Text.Replace("01/01/1900", "");
                txtLCNo.Text = gv_Invoice.SelectedRow.Cells[71].Text.Replace("&nbsp;", "");
                txtLCDate.Text = gv_Invoice.SelectedRow.Cells[72].Text.Replace("01/01/1900", "");

                ddlNatureOfTrans.Items.Clear();
                ddlNatureOfTrans_List();
                ddlNatureOfTrans.Items.Remove(gv_Invoice.SelectedRow.Cells[73].Text.Replace("&nbsp;", "").Replace("&#160; ", ""));
                ddlNatureOfTrans.Items.Insert(0, gv_Invoice.SelectedRow.Cells[73].Text.Replace("&nbsp;", "").Replace("&#160;", ""));

                ddlNatureOfPayment.Items.Clear();
                ddlNatureOfPayment_list();
                ddlNatureOfPayment.Items.Remove(gv_Invoice.SelectedRow.Cells[74].Text.Replace("&nbsp;", "").Replace("&#160; ", ""));
                ddlNatureOfPayment.Items.Insert(0, gv_Invoice.SelectedRow.Cells[74].Text.Replace("&nbsp;", "").Replace("&#160; ", ""));

                txtConditions.Text = rep.Replace(gv_Invoice.SelectedRow.Cells[75].Text);

                ddlValuationMethod.Items.Clear();
                ddlValuationMethod_List();
                ddlValuationMethod.Items.Remove(gv_Invoice.SelectedRow.Cells[76].Text.Replace("&nbsp;", "").Replace("&#160; ", ""));
                ddlValuationMethod.Items.Insert(0, gv_Invoice.SelectedRow.Cells[76].Text.Replace("&nbsp;", "").Replace("&#160; ", ""));

                txtSVBDate.Text = gv_Invoice.SelectedRow.Cells[77].Text.Replace("01/01/1900", "");

                hdn_non_std_effect_dt.Value = gv_Invoice.SelectedRow.Cells[80].Text.Replace("&nbsp;", "");
                hdn_non_std_bankname.Value = gv_Invoice.SelectedRow.Cells[81].Text.Replace("&nbsp;", "");
                hdn_non_std_cert_no.Value = gv_Invoice.SelectedRow.Cells[82].Text.Replace("&nbsp;", "");
                hdn_non_std_cert_dt.Value = gv_Invoice.SelectedRow.Cells[83].Text.Replace("&nbsp;", "");

                txtSAP_Delievery_ID.Text = gv_Invoice.SelectedRow.Cells[84].Text.Replace("&nbsp;", "");
                txtShip_Date.Text = gv_Invoice.SelectedRow.Cells[85].Text.Replace("01/01/1900", "");
                txtInvoice_Level.Text = gv_Invoice.SelectedRow.Cells[86].Text.Replace("&nbsp;", "");
                txtCountry_Departure.Text = gv_Invoice.SelectedRow.Cells[87].Text.Replace("&nbsp;", "");

                //SINGLE WINDOW OPERATION LOADING       

                txt_TermsPlace.Text = gv_Invoice.SelectedRow.Cells[95].Text.Replace("&nbsp;", "");
                txt_ThirdPartyName.Text = gv_Invoice.SelectedRow.Cells[96].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                txt_ThirdParty_Add1.Text = gv_Invoice.SelectedRow.Cells[97].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                txt_ThirdParty_Add2.Text = gv_Invoice.SelectedRow.Cells[98].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                txt_ThirdParty_City.Text = gv_Invoice.SelectedRow.Cells[99].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                txt_Country_Division.Text = gv_Invoice.SelectedRow.Cells[100].Text.Replace("&nbsp;", "");
                txt_CountryCode.Text = gv_Invoice.SelectedRow.Cells[101].Text.Replace("&nbsp;", "");
                txt_ThirdParty_Pin.Text = gv_Invoice.SelectedRow.Cells[102].Text.Replace("&nbsp;", "");
                txt_Authrzd_Economic_Code.Text = gv_Invoice.SelectedRow.Cells[103].Text.Replace("&nbsp;", "");
                txt_Authrzd_Economic_Country.Text = gv_Invoice.SelectedRow.Cells[104].Text.Replace("&nbsp;", "");
                txt_Authrzd_Economic_Role.Text = gv_Invoice.SelectedRow.Cells[105].Text.Replace("&nbsp;", "");
                txt_Whether_Relater_Y_N.Text = gv_Invoice.SelectedRow.Cells[106].Text.Replace("&nbsp;", "");

                if (txt_Whether_Relater_Y_N.Text == string.Empty)
                {
                    if (COMPANY_IDD == "1701" || COMPANY_IDD == "3316")
                    {
                        txt_Whether_Relater_Y_N.Text = "N";
                    }
                }


                txt_Brokerage.Text = gv_Invoice.SelectedRow.Cells[107].Text.Replace("&nbsp;", "");
                txt_Cost_Container.Text = gv_Invoice.SelectedRow.Cells[108].Text.Replace("&nbsp;", "");
                txt_Cost_Packaging.Text = gv_Invoice.SelectedRow.Cells[109].Text.Replace("&nbsp;", "");
                txt_Handling_Charges.Text = gv_Invoice.SelectedRow.Cells[110].Text.Replace("&nbsp;", "");
                txt_Goods_Services.Text = gv_Invoice.SelectedRow.Cells[111].Text.Replace("&nbsp;", "");
                txt_Documentation.Text = gv_Invoice.SelectedRow.Cells[112].Text.Replace("&nbsp;", "");
                txt_Country_Origin.Text = gv_Invoice.SelectedRow.Cells[113].Text.Replace("&nbsp;", "");
                txt_Royalties_lic_fees.Text = gv_Invoice.SelectedRow.Cells[114].Text.Replace("&nbsp;", "");
                txt_Value_of_Proceeds.Text = gv_Invoice.SelectedRow.Cells[115].Text.Replace("&nbsp;", "");
                txt_Warrenty_Services.Text = gv_Invoice.SelectedRow.Cells[116].Text.Replace("&nbsp;", "");
                txt_Other_Cost_Payment.Text = gv_Invoice.SelectedRow.Cells[117].Text.Replace("&nbsp;", "");
                txt_Other_Charges_Payments.Text = gv_Invoice.SelectedRow.Cells[118].Text.Replace("&nbsp;", "");
                txt_Loading_Charges.Text = gv_Invoice.SelectedRow.Cells[119].Text.Replace("&nbsp;", "");
                txt_UnLoading_Charges.Text = gv_Invoice.SelectedRow.Cells[120].Text.Replace("&nbsp;", "");
                txt_Total_Amount.Text = gv_Invoice.SelectedRow.Cells[121].Text.Replace("&nbsp;", "");
                txt_DocRecd_Date.Text = gv_Invoice.SelectedRow.Cells[122].Text.Replace("&nbsp;", "");

                //END

                txtRevenue_Deposit.Text = gv_Invoice.SelectedRow.Cells[89].Text.Replace("&nbsp;", "");
                Revenue_LoadOn = gv_Invoice.SelectedRow.Cells[90].Text.Replace("&nbsp;", "");
                string Revenue_on = "";
                if (Revenue_LoadOn == "A")
                {
                    Revenue_on = "Assessable";


                }
                else if (Revenue_LoadOn == "D")
                {
                    Revenue_on = "Duty";

                }
                else if (Revenue_LoadOn == "B")
                {
                    Revenue_on = "Both";
                }
                else
                {
                    Revenue_on = "";
                }

                ddlRevenueDeposit_On.Items.Clear();
                ddlRevenueDeposit();
                ddlRevenueDeposit_On.Items.Remove(Revenue_on);
                ddlRevenueDeposit_On.Items.Insert(0, Revenue_on);

                txt_INV_MISC_Currency.Text = gv_Invoice.SelectedRow.Cells[124].Text.Replace("&nbsp;", "");
                txt_INV_MISC_Exch_Rate.Text = gv_Invoice.SelectedRow.Cells[125].Text.Replace("&nbsp;", "");
                txt_INV_MISC_Charges.Text = gv_Invoice.SelectedRow.Cells[126].Text.Replace("&nbsp;", "");
                txt_INV_MISC_Total_Charge.Text = gv_Invoice.SelectedRow.Cells[127].Text.Replace("&nbsp;", "");
                hdn_INV_MISC_Total_Charge.Value = gv_Invoice.SelectedRow.Cells[127].Text.Replace("&nbsp;", "");

                if (!string.IsNullOrEmpty(Session["BE_No"].ToString()))
                {
                    div_AmendmentType.Visible = true;
                    ddl_AmendmentType.SelectedValue = gv_Invoice.SelectedRow.Cells[130].Text.Replace("&nbsp;", "");
                }


                if (gv_Invoice.SelectedRow.Cells[123].Text.Replace("&nbsp;", "") == "T")
                {
                    chk_active_Inv_Misc.Checked = true;
                    txt_INV_MISC_Currency.Enabled = true;
                    txt_INV_MISC_Exch_Rate.Enabled = true;
                    txt_INV_MISC_Charges.Enabled = true;
                    //txt_INV_MISC_Total_Charge.Enabled = true;//hide on 28-08-2020 by  Chithra
                    hdn_chk_active_Inv_Misc.Value = "T";
                }
                else
                {
                    chk_active_Inv_Misc.Checked = false;
                    txt_INV_MISC_Currency.Enabled = false;
                    txt_INV_MISC_Exch_Rate.Enabled = false;
                    txt_INV_MISC_Charges.Enabled = false;
                    txt_INV_MISC_Total_Charge.Enabled = false;
                    hdn_chk_active_Inv_Misc.Value = "F";
                }

                if (gv_Invoice.SelectedRow.Cells[128].Text.Replace("&nbsp;", "") == "Y")
                {
                    chk_add_INV_MISC.Checked = true;
                }
                else
                {
                    chk_add_INV_MISC.Checked = false;
                }


                lblInvoiceNo.Text = txtInvoiceNo.Text;
                lblInvoiceDate.Text = txtDate.Text;
                lblInvoiceCurrency.Text = txtInvoiceCurrency.Text;
                lblInvoiceTerms.Text = ddlTerms.SelectedValue;
                lblInvoiceValue.Text = txtInvoiceValue.Text;

                Get_ProductValue();
                Terms_clear_Total_freight_Insurance();
                hdn_button_click.Value = "";
                if (gv_Invoice.Rows.Count > 0)
                {
                    if (gv_Invoice.Rows.Count == 1)
                    {
                        hdn_grid_count.Value = "1";
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

                if (Audit_YN == "Y")
                {
                    DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"]);
                }
            }
            else
            {
                hdn_grid_edit.Value = "0";
                hdn_button_click.Value = "";

                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btn_save_new.Visible = true;
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>document.getElementById('IMD').click();</script>", false);

            CHK_True_False();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            //
        }
    }

    public void Grid_count_one()
    {
        try
        {
            if (hdn_Invoice_mode_singlr_or_multi.Value == "M")
            {
                if (ddlTerms.SelectedValue == "FOB")
                {
                    if (ViewState["CHKF_F"].ToString() == "Amt")
                    {
                        txtFreight_Rate.Enabled = false;
                        txtFreight_Charges.Enabled = true;

                        tag_Totalfrieght.Style.Add("display", "block");
                    }
                    else if (ViewState["CHKF_F"].ToString() == "Rate")
                    {
                        txtFreight_Rate.Enabled = true;
                        txtFreight_Charges.Enabled = false;

                        tag_Totalfrieght.Style.Add("display", "none");
                    }

                    if (ViewState["CHKI_I"].ToString() == "Amt")
                    {
                        txtInsurance_Rate.Enabled = false;
                        txtInsurance_Charges.Enabled = true;

                        tag_TotalInsurance.Style.Add("display", "block");
                    }
                    else if (ViewState["CHKI_I"].ToString() == "Rate")
                    {
                        txtInsurance_Rate.Enabled = true;
                        txtInsurance_Charges.Enabled = false;

                        tag_TotalInsurance.Style.Add("display", "none");
                    }


                    int S_ID;
                    S_ID = gv_Invoice.SelectedIndex;

                    if (S_ID == 0 || S_ID == -1)
                    {
                        txtTotal_Frieght.Enabled = true;
                        txtTotal_Insurance.Enabled = true;
                    }
                    else
                    {
                        txtFreight_Charges.Enabled = false;
                        txtInsurance_Charges.Enabled = false;
                    }
                }
                else if (ddlTerms.SelectedValue == "CI")
                {
                    if (ViewState["CHKF_F"].ToString() == "Amt")
                    {
                        txtFreight_Rate.Enabled = false;
                        txtFreight_Charges.Enabled = true;
                        tag_Totalfrieght.Style.Add("display", "block");
                    }
                    else if (ViewState["CHKF_F"].ToString() == "Rate")
                    {
                        txtFreight_Rate.Enabled = true;
                        txtFreight_Charges.Enabled = false;
                        tag_Totalfrieght.Style.Add("display", "none");
                    }

                    txtInsurance_Rate.Enabled = false;
                    txtInsurance_Charges.Enabled = false;
                    tag_TotalInsurance.Style.Add("display", "none");


                    int S_ID;
                    S_ID = gv_Invoice.SelectedIndex;

                    if (S_ID == 0 || S_ID == -1)
                    {

                        txtTotal_Frieght.Enabled = true;

                    }
                    else
                    {
                        txtFreight_Charges.Enabled = false;
                        txtInsurance_Charges.Enabled = false;
                    }


                }
                else if (ddlTerms.SelectedValue == "CF")
                {
                    txtFreight_Rate.Enabled = false;
                    txtFreight_Charges.Enabled = false;
                    tag_Totalfrieght.Style.Add("display", "none");


                    if (ViewState["CHKI_I"].ToString() == "Amt")
                    {
                        txtInsurance_Rate.Enabled = false;
                        txtInsurance_Charges.Enabled = true;

                        tag_TotalInsurance.Style.Add("display", "block");
                    }
                    else if (ViewState["CHKI_I"].ToString() == "Rate")
                    {
                        txtInsurance_Rate.Enabled = true;
                        txtInsurance_Charges.Enabled = false;

                        tag_TotalInsurance.Style.Add("display", "none");
                    }

                    int S_ID;
                    S_ID = gv_Invoice.SelectedIndex;
                    if (S_ID == 0 || S_ID == -1)
                    {

                        txtTotal_Insurance.Enabled = true;
                    }
                    else
                    {
                        txtFreight_Charges.Enabled = false;
                        txtInsurance_Charges.Enabled = false;
                    }
                }
                else if (ddlTerms.SelectedValue == "CIF")
                {
                    txtFreight_Rate.Enabled = false;
                    txtFreight_Charges.Enabled = false;
                    txtInsurance_Rate.Enabled = false;
                    txtInsurance_Charges.Enabled = false;

                    tag_Totalfrieght.Style.Add("display", "none");
                    tag_TotalInsurance.Style.Add("display", "none");
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
                    txtInsurance_Exch_Rate.Enabled = true;
                    txtInsurance_Currency.Enabled = true;
                    txtInsurance_Rate.Enabled = true;
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            //
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {

            hdn_INVOICE_SLNO.Value = "";
            hdn_grid_edit.Value = "0";

            ViewState["btNew"] = 1;

            gv_Invoice.RowStyle.BackColor = System.Drawing.Color.White;
            gv_Invoice.RowStyle.Font.Bold = false;

            //hide on 12-05-2026 by Chithra for last updated value should continue for next invoices..
            //ddlNatureOfTrans.Items.Clear();
            //ddlNatureOfPayment.Items.Clear();
            //ddlValuationMethod.Items.Clear();

            //ddlNatureOfTrans_List();
            //ddlValuationMethod_List();
            //ddlNatureOfPayment_list();

            //Newly added for retain the previous values
            ddl_NatureTrans1 = ddlNatureOfTrans.SelectedValue;
            ddl_NaturePayment1 = ddlNatureOfPayment.SelectedValue;
            ddl_valuationmethod1 = ddlValuationMethod.SelectedValue;

            if (Connection.COMPANYID() == "1532")//SMS Clearing
            {
                ddlNatureOfTrans.Items.Remove("O Others");
                ddlNatureOfTrans.Items.Insert(0, "O Others");

                ddlNatureOfPayment.Items.Remove("DP Document Presentation");
                ddlNatureOfPayment.Items.Insert(0, "DP Document Presentation");

                btngenexcel.Visible = false;
            }
            else if (Connection.COMPANYID() == "1701" || COMPANY_IDD == "3316")//DIAMOND CARGO
            {
                ddlNatureOfTrans.Items.Remove("O Others");
                ddlNatureOfTrans.Items.Insert(0, "O Others");
            }
            else if (Connection.COMPANYID() == "1535")//AMBER Logistics
            {
                ddlNatureOfTrans.Items.Remove("C Consignment");
                ddlNatureOfTrans.Items.Insert(0, "C Consignment");
            }

            if (gv_Invoice.Rows.Count > 0)
            {
                if (gv_Invoice.Rows[0].Cells[8].Text.Replace("&nbsp;", "") == "S")
                {
                    //------------SINGLE INVOICE---------//
                    chkMisc.Checked = false;

                    btn_New_Invoice();
                    chkMisc.Enabled = false;


                    if (Session["BE_TYPE"].ToString() != "SEZ DTA-M")
                    {
                        ddlterms_clear();
                    }

                    ddlRevenueDeposit_Clear();

                    ddlTerms.Enabled = true;
                    chkMisc.Checked = false;
                    txtFreight_Exch_Rate.Enabled = true;
                    txtFreight_Currency.Enabled = true;
                    txtFreight_Rate.Enabled = true;

                    txtInsurance_Exch_Rate.Enabled = true;
                    txtInsurance_Currency.Enabled = true;
                    txtInsurance_Rate.Enabled = true;
                    pnl_Multi_Invoice.Enabled = true;

                    if (chkMisc.Checked == false)
                    {
                        DivFreight.Style.Add("display", "none");
                        DivInsurance.Style.Add("display", "none");

                        Div_MISC_txt.Style.Add("display", "none");
                        Div_Hss_txt.Style.Add("display", "none");

                        DivMISC.Style.Add("display", "none");
                        DivHSS.Style.Add("display", "none");

                        Chk_Misc.SelectedIndex = -1;
                        CHKHSS.SelectedIndex = -1;
                    }
                }
                else
                {

                    btn_New_Invoice();
                    chkMisc.Enabled = false;
                    ddlTerms.Enabled = false;
                    chkMisc.Checked = true;

                    CHKF.Enabled = false;
                    CHKI.Enabled = false;

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

                        CHKF.SelectedValue = ViewState["CHKF_F"].ToString();
                        CHKI.SelectedValue = ViewState["CHKI_I"].ToString();

                        if (ddlTerms.SelectedItem.Text == "FOB")
                        {
                            pnl_Multi_Invoice.Enabled = true;

                            if (ViewState["CHKF_F"] != null && ViewState["CHKF_F"] != string.Empty && ViewState["CHKI_I"] != null && ViewState["CHKI_I"] != string.Empty)
                            {
                                if (gv_Invoice.Rows.Count > 0)
                                {
                                    if (ViewState["CHKF_F"].ToString() == "Amt")
                                    {
                                        txtFreight_Charges.Enabled = false;
                                        txtFreight_Rate.Enabled = false;
                                    }
                                    if (ViewState["CHKF_F"].ToString() == "Rate")
                                    {
                                        txtFreight_Rate.Enabled = true;
                                        txtFreight_Charges.Enabled = false;
                                    }
                                    //----------------------------------------------------------------------------
                                    if (ViewState["CHKI_I"].ToString() == "Amt")
                                    {
                                        txtInsurance_Charges.Enabled = false;
                                        txtInsurance_Rate.Enabled = false;
                                    }

                                    if (ViewState["CHKI_I"] == "Rate")
                                    {
                                        txtInsurance_Rate.Enabled = true;
                                        txtInsurance_Charges.Enabled = false;
                                    }

                                    txtTotal_Frieght.Enabled = false;
                                    txtTotal_Insurance.Enabled = false;
                                }
                                else
                                {
                                    if (ViewState["CHKF_F"].ToString() == "Amt")
                                    {
                                        txtFreight_Rate.Enabled = false;
                                        txtFreight_Charges.Enabled = true;
                                    }
                                    if (ViewState["CHKF_F"].ToString() == "Rate")
                                    {
                                        txtFreight_Rate.Enabled = true;
                                        txtFreight_Charges.Enabled = false;
                                    }
                                    //----------------------------------------------------------------------------
                                    if (ViewState["CHKI_I"].ToString() == "Amt")
                                    {
                                        txtInsurance_Charges.Enabled = true;
                                        txtInsurance_Rate.Enabled = false;
                                    }

                                    if (ViewState["CHKI_I"] == "Rate")
                                    {
                                        txtInsurance_Rate.Enabled = true;
                                        txtInsurance_Charges.Enabled = false;
                                    }

                                    txtTotal_Frieght.Enabled = true;
                                    txtTotal_Insurance.Enabled = true;
                                }
                            }

                            txtFreight_Currency.Enabled = false;
                            txtFreight_Exch_Rate.Enabled = false;
                            txtInsurance_Currency.Enabled = false;
                            txtInsurance_Exch_Rate.Enabled = false;
                        }
                        else if (ddlTerms.SelectedItem.Text == "CF")
                        {
                            pnl_Multi_Invoice.Enabled = true;

                            txtFreight_Currency.Enabled = false;
                            txtFreight_Exch_Rate.Enabled = false;
                            txtInsurance_Currency.Enabled = false;
                            txtInsurance_Exch_Rate.Enabled = false;

                            if (ViewState["CHKF_F"] != null && ViewState["CHKF_F"] != string.Empty && ViewState["CHKI_I"] != null && ViewState["CHKI_I"] != string.Empty)
                            {
                                if (gv_Invoice.Rows.Count > 0)
                                {

                                    //----------------------------------------------------------------------------
                                    if (ViewState["CHKI_I"].ToString() == "Amt")
                                    {
                                        txtInsurance_Charges.Enabled = false;
                                        txtInsurance_Rate.Enabled = false;
                                    }

                                    if (ViewState["CHKI_I"] == "Rate")
                                    {
                                        txtInsurance_Rate.Enabled = true;
                                        txtInsurance_Charges.Enabled = false;
                                    }
                                    txtTotal_Insurance.Enabled = false;
                                }
                                else
                                {
                                    //----------------------------------------------------------------------------
                                    if (ViewState["CHKI_I"].ToString() == "Amt")
                                    {
                                        txtInsurance_Charges.Enabled = true;
                                        txtInsurance_Rate.Enabled = false;
                                    }

                                    if (ViewState["CHKI_I"] == "Rate")
                                    {
                                        txtInsurance_Rate.Enabled = true;
                                        txtInsurance_Charges.Enabled = false;
                                    }
                                    txtTotal_Insurance.Enabled = true;
                                }
                            }
                        }
                        else if (ddlTerms.SelectedItem.Text == "CI")
                        {
                            pnl_Multi_Invoice.Enabled = true;

                            txtFreight_Currency.Enabled = false;
                            txtFreight_Exch_Rate.Enabled = false;
                            txtInsurance_Currency.Enabled = false;
                            txtInsurance_Exch_Rate.Enabled = false;

                            if (ViewState["CHKF_F"] != null && ViewState["CHKF_F"] != string.Empty && ViewState["CHKI_I"] != null && ViewState["CHKI_I"] != string.Empty)
                            {
                                txtInsurance_Charges.Enabled = false;
                                txtInsurance_Rate.Enabled = false;

                                if (gv_Invoice.Rows.Count > 0)
                                {
                                    if (ViewState["CHKF_F"].ToString() == "Amt")
                                    {
                                        txtFreight_Charges.Enabled = false;
                                        txtFreight_Rate.Enabled = false;
                                    }
                                    if (ViewState["CHKF_F"].ToString() == "Rate")
                                    {
                                        txtFreight_Rate.Enabled = true;
                                        txtFreight_Charges.Enabled = false;
                                    }
                                    //----------------------------------------------------------------------------
                                    txtTotal_Frieght.Enabled = false;
                                }
                                else
                                {
                                    if (ViewState["CHKF_F"].ToString() == "Amt")
                                    {
                                        txtFreight_Rate.Enabled = false;
                                        txtFreight_Charges.Enabled = true;
                                    }
                                    if (ViewState["CHKF_F"].ToString() == "Rate")
                                    {
                                        txtFreight_Rate.Enabled = true;
                                        txtFreight_Charges.Enabled = false;
                                    }
                                    //----------------------------------------------------------------------------
                                    txtTotal_Frieght.Enabled = true;
                                }
                            }
                        }
                        else if (ddlTerms.SelectedItem.Text == "CIF")
                        {
                            pnl_Multi_Invoice.Enabled = false;
                        }
                        if (gv_Invoice.Rows.Count == 0)
                        {
                            Chk_Misc.Enabled = true;
                            CHKHSS.Enabled = true;
                            txtMisc_Total_Charge.Enabled = true;
                            txtHss_Total_Charge.Enabled = true;
                        }
                        else
                        {
                            Chk_Misc.Enabled = false;
                            CHKHSS.Enabled = false;
                            txtMisc_Total_Charge.Enabled = false;
                            txtHss_Total_Charge.Enabled = false;
                        }

                    }
                    else
                    {
                        txtFreight_Rate.Text = "20.0000";

                        if (hdn_Cilent_InsuranceRate.Value != "")
                        {
                            txtInsurance_Rate.Text = hdn_Cilent_InsuranceRate.Value;
                        }
                        else
                        {
                            txtInsurance_Rate.Text = "1.1250";
                        }
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
            CHK_True_False();

            //if (Session["BE_TYPE"].ToString() == "Ex-Bond" && hdn_Direct_Exbond_YN.Value == "Y")
            //{
            Bind_InvSl_No_MAX();
            //}
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            //
        }
    }
    public void Supplier_SVB_details_Bind()
    {
        try
        {
            //------------Supplier bind------------//

            txt_InvoiceSlno.Text = gv_Invoice.Rows[0].Cells[2].Text.ToUpper().Replace("&nbsp;", "");
            txtDate.Text = gv_Invoice.Rows[0].Cells[4].Text.ToUpper().Replace("&nbsp;", "");
            txtInvoiceCurrency.Text = gv_Invoice.Rows[0].Cells[7].Text.ToUpper().Replace("&nbsp;", "");
            txtExRate.Text = gv_Invoice.Rows[0].Cells[78].Text.Replace("&nbsp;", "");
            txtSupplierName.Text = rep.Replace(gv_Invoice.Rows[0].Cells[9].Text);
            txtSupplier_Branch_Slno.Text = rep.Replace(gv_Invoice.Rows[0].Cells[129].Text);

            txtSupplierAddress.Text = rep.Replace(gv_Invoice.Rows[0].Cells[10].Text);
            txtSupplierAddress1.Text = rep.Replace(gv_Invoice.Rows[0].Cells[11].Text);
            txtSupplierAddress2.Text = rep.Replace(gv_Invoice.Rows[0].Cells[12].Text);
            txtSupplierCountryName.Text = rep.Replace(gv_Invoice.Rows[0].Cells[13].Text);
            hfdsupplier_countrycode.Value = rep.Replace(gv_Invoice.Rows[0].Cells[14].Text);
            txtSuppliercountry_pincode.Text = rep.Replace(gv_Invoice.Rows[0].Cells[15].Text);

            txtSellerName.Text = rep.Replace(gv_Invoice.Rows[0].Cells[16].Text);
            txtSellerAddress.Text = rep.Replace(gv_Invoice.Rows[0].Cells[17].Text);
            txtSellerAddress1.Text = rep.Replace(gv_Invoice.Rows[0].Cells[18].Text);
            txtSellerAddress2.Text = rep.Replace(gv_Invoice.Rows[0].Cells[19].Text);
            txtSellerCountryName.Text = rep.Replace(gv_Invoice.Rows[0].Cells[20].Text);
            hfdseller_countrycode.Value = rep.Replace(gv_Invoice.Rows[0].Cells[21].Text);
            txtSellercountry_pincode.Text = rep.Replace(gv_Invoice.Rows[0].Cells[22].Text);

            txtBrokerName.Text = rep.Replace(gv_Invoice.Rows[0].Cells[23].Text);
            txtBrokerAddress.Text = rep.Replace(gv_Invoice.Rows[0].Cells[24].Text);
            txtBrokerAddress1.Text = rep.Replace(gv_Invoice.Rows[0].Cells[25].Text);
            txtBrokerAddress2.Text = rep.Replace(gv_Invoice.Rows[0].Cells[26].Text);
            txtBrokerCountryName.Text = rep.Replace(gv_Invoice.Rows[0].Cells[27].Text);
            hfdbroker_countrycode.Value = rep.Replace(gv_Invoice.Rows[0].Cells[28].Text);
            txtbrokercountry_pincode.Text = rep.Replace(gv_Invoice.Rows[0].Cells[29].Text);
            //------------Supplier bind------------//

            //---------SVB bind-----

            string chksvb = gv_Invoice.Rows[0].Cells[59].Text.Replace("&nbsp;", "");
            if (chksvb == "Y")
            {
                chkSVB_Relation.Checked = true;
                txtSVB_RefNo.Enabled = true;
                txtSVBDate.Enabled = true;
                txtCustomsHouse.Enabled = true;

                ddlLoadingOn.Enabled = true;
            }
            else
            {
                chkSVB_Relation.Checked = false;

            }

            txtSVB_RefNo.Text = gv_Invoice.Rows[0].Cells[60].Text.Replace("&nbsp;", "");
            txtSVBDate.Text = gv_Invoice.Rows[0].Cells[77].Text.Replace("01/01/1900", "");

            string SVB_CustomHouse = gv_Invoice.Rows[0].Cells[61].Text.Replace("&nbsp;", "");
            txtCustomsHouse.Text = SVB_CustomHouse;
            hdn_Customhouse_chk.Value = Set_Customs_House_Validation(txtCustomsHouse.Text);

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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            //
        }
    }

    public void SINGLE_WINDOW_OPERATION_Details()
    {
        try
        {
            txt_TermsPlace.Text = gv_Invoice.Rows[0].Cells[95].Text.Replace("&nbsp;", "");
            txt_ThirdPartyName.Text = gv_Invoice.Rows[0].Cells[96].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
            txt_ThirdParty_Add1.Text = gv_Invoice.Rows[0].Cells[97].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
            txt_ThirdParty_Add2.Text = gv_Invoice.Rows[0].Cells[98].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
            txt_ThirdParty_City.Text = gv_Invoice.Rows[0].Cells[99].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
            txt_Country_Division.Text = gv_Invoice.Rows[0].Cells[100].Text.Replace("&nbsp;", "");
            txt_CountryCode.Text = gv_Invoice.Rows[0].Cells[101].Text.Replace("&nbsp;", "");
            txt_ThirdParty_Pin.Text = gv_Invoice.Rows[0].Cells[102].Text.Replace("&nbsp;", "");
            txt_Authrzd_Economic_Code.Text = gv_Invoice.Rows[0].Cells[103].Text.Replace("&nbsp;", "");
            txt_Authrzd_Economic_Country.Text = gv_Invoice.Rows[0].Cells[104].Text.Replace("&nbsp;", "");
            txt_Authrzd_Economic_Role.Text = gv_Invoice.Rows[0].Cells[105].Text.Replace("&nbsp;", "");
            txt_Whether_Relater_Y_N.Text = gv_Invoice.Rows[0].Cells[106].Text.Replace("&nbsp;", "");
            if (txt_Whether_Relater_Y_N.Text == string.Empty)
            {
                if (COMPANY_IDD == "1701" || COMPANY_IDD == "3316")
                {
                    txt_Whether_Relater_Y_N.Text = "N";
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            //
        }

    }

    public void INVOICE_OTHER_CHARGES_DETAILS()
    {
        try
        {
            txt_Brokerage.Text = gv_Invoice.Rows[0].Cells[107].Text.Replace("&nbsp;", "");
            txt_Cost_Container.Text = gv_Invoice.Rows[0].Cells[108].Text.Replace("&nbsp;", "");
            txt_Cost_Packaging.Text = gv_Invoice.Rows[0].Cells[109].Text.Replace("&nbsp;", "");
            txt_Handling_Charges.Text = gv_Invoice.Rows[0].Cells[110].Text.Replace("&nbsp;", "");
            txt_Goods_Services.Text = gv_Invoice.Rows[0].Cells[111].Text.Replace("&nbsp;", "");
            txt_Documentation.Text = gv_Invoice.Rows[0].Cells[112].Text.Replace("&nbsp;", "");
            txt_Country_Origin.Text = gv_Invoice.Rows[0].Cells[113].Text.Replace("&nbsp;", "");
            txt_Royalties_lic_fees.Text = gv_Invoice.Rows[0].Cells[114].Text.Replace("&nbsp;", "");
            txt_Value_of_Proceeds.Text = gv_Invoice.Rows[0].Cells[115].Text.Replace("&nbsp;", "");
            txt_Warrenty_Services.Text = gv_Invoice.Rows[0].Cells[116].Text.Replace("&nbsp;", "");
            txt_Other_Cost_Payment.Text = gv_Invoice.Rows[0].Cells[117].Text.Replace("&nbsp;", "");
            txt_Other_Charges_Payments.Text = gv_Invoice.Rows[0].Cells[118].Text.Replace("&nbsp;", "");
            txt_Loading_Charges.Text = gv_Invoice.Rows[0].Cells[119].Text.Replace("&nbsp;", "");
            txt_UnLoading_Charges.Text = gv_Invoice.Rows[0].Cells[120].Text.Replace("&nbsp;", "");
            txt_Total_Amount.Text = gv_Invoice.Rows[0].Cells[121].Text.Replace("&nbsp;", "");
            txt_DocRecd_Date.Text = gv_Invoice.Rows[0].Cells[122].Text.Replace("&nbsp;", "");

            //if (gv_Invoice.Rows[0].Cells[123].Text.Replace("&nbsp;", "") == "T")
            //{
            //    chk_active_Inv_Misc.Checked = true;
            //    hdn_chk_active_Inv_Misc.Value = "T";
            //    lbl_INV_MISC_Total_Charge_Currency.Text = txtMiscellaneous_Currency.Text;
            //}

            //txt_INV_MISC_Currency.Text = gv_Invoice.Rows[0].Cells[124].Text.Replace("&nbsp;", "");
            //txt_INV_MISC_Exch_Rate.Text = gv_Invoice.Rows[0].Cells[125].Text.Replace("&nbsp;", "");
            //txt_INV_MISC_Charges.Text = gv_Invoice.Rows[0].Cells[126].Text.Replace("&nbsp;", "");
            //txt_INV_MISC_Total_Charge.Text = gv_Invoice.Rows[0].Cells[127].Text.Replace("&nbsp;", "");


            //if (gv_Invoice.Rows[0].Cells[128].Text.Replace("&nbsp;", "") == "Y")
            //{
            //    chk_add_INV_MISC.Checked = true;
            //}
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            //
        }
    }

    public void Terms_clear_Total_freight_Insurance()
    {
        try
        {
            if (hdn_Invoice_mode_singlr_or_multi.Value == "M")
            {
                if (ddlTerms.SelectedValue == "FOB")
                {

                    txtFreight_Rate.Enabled = false;
                    txtInsurance_Rate.Enabled = false;

                    if (ViewState["CHKF_F"] != null && ViewState["CHKF_F"] != string.Empty && ViewState["CHKI_I"] != null && ViewState["CHKI_I"] != string.Empty)
                    {
                        if (ViewState["CHKF_F"].ToString() == "Rate")
                        {
                            tag_Totalfrieght.Style.Add("display", "none");
                        }
                        else if (ViewState["CHKF_F"].ToString() == "Amt")
                        {
                            tag_Totalfrieght.Style.Add("display", "block");
                        }
                        //----------------------------------------------------------------------------------
                        if (ViewState["CHKI_I"].ToString() == "Rate")
                        {
                            tag_TotalInsurance.Style.Add("display", "none");
                        }
                        else if (ViewState["CHKI_I"].ToString() == "Amt")
                        {
                            tag_TotalInsurance.Style.Add("display", "block");
                        }

                        if (ViewState["CHKF_F"].ToString() == "Amt" && ViewState["CHKI_I"].ToString() == "Rate")
                        {
                            pnl_Multi_Invoice.Enabled = true;
                        }
                        if (ViewState["CHKF_F"].ToString() == "Rate" && ViewState["CHKI_I"].ToString() == "Amt")
                        {
                            pnl_Multi_Invoice.Enabled = true;
                        }
                        if (ViewState["CHKF_F"].ToString() == "Rate" && ViewState["CHKI_I"].ToString() == "Rate")
                        {
                            pnl_Multi_Invoice.Enabled = true;
                        }
                    }
                }
                else if (ddlTerms.SelectedValue == "CI")
                {
                    txtFreight_Rate.Enabled = false;
                    tag_Totalfrieght.Style.Add("display", "block");
                    tag_TotalInsurance.Style.Add("display", "none");
                    pnl_Multi_Invoice.Enabled = true;
                }
                else if (ddlTerms.SelectedValue == "CF")
                {
                    txtInsurance_Rate.Enabled = false;
                    tag_Totalfrieght.Style.Add("display", "none");
                    tag_TotalInsurance.Style.Add("display", "block");

                    pnl_Multi_Invoice.Enabled = true;
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            //
        }
    }
    public void Terms_clear_Invoice_Updation()
    {
        try
        {
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            //
        }
    }
    public void btn_New_Invoice()
    {
        try
        {

            Terms_Change_Updating_MultiInvoice();
            Transact.ResetFields(Page.Controls);
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
            btn_save_new.Visible = true;
            ViewState["INVOICE_ID"] = null;

            ddlNatureOfTrans.SelectedValue = ddl_NatureTrans1;
            ddlNatureOfPayment.SelectedValue = ddl_NaturePayment1;
            ddlValuationMethod.SelectedValue = ddl_valuationmethod1;

            //btnnew1.Visible = true;
            //btn_Masedit.Visible = false;

            get_Textboxvalue();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            //
        }
    }


    private void Single_Inv()
    {
        try
        {
            if (ddlTerms.SelectedValue == "FOB")
            {
                txtFreight_Exch_Rate.Enabled = true;
                txtFreight_Currency.Enabled = true;

                txtInsurance_Exch_Rate.Enabled = true;
                txtInsurance_Currency.Enabled = true;
            }
            else if (ddlTerms.SelectedValue == "CI")
            {
                txtFreight_Exch_Rate.Enabled = true;
                txtFreight_Currency.Enabled = true;

                txtInsurance_Exch_Rate.Enabled = false;
                txtInsurance_Currency.Enabled = false;

            }
            else if (ddlTerms.SelectedValue == "CF")
            {
                txtFreight_Exch_Rate.Enabled = false;
                txtFreight_Currency.Enabled = false;

                txtInsurance_Exch_Rate.Enabled = true;
                txtInsurance_Currency.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            //
        }

    }


    public void Terms_Change_Updating_MultiInvoice()
    {
        try
        {
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

                if (gv_Invoice.Rows.Count > 0)
                {
                    if (chkMisc.Checked == true)
                    {
                        txtFreight_Exch_Rate.Enabled = false;
                        txtFreight_Currency.Enabled = false;


                        txtInsurance_Exch_Rate.Enabled = false;
                        txtInsurance_Currency.Enabled = false;

                        txtTotal_Frieght.Enabled = false;
                        txtTotal_Insurance.Enabled = false;
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (chkMisc.Checked == true)
                    {
                        txtFreight_Exch_Rate.Enabled = true;
                        txtFreight_Currency.Enabled = true;

                        txtInsurance_Exch_Rate.Enabled = true;
                        txtInsurance_Currency.Enabled = true;

                        txtTotal_Frieght.Enabled = true;
                        txtTotal_Insurance.Enabled = true;
                    }
                }

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

                if (gv_Invoice.Rows.Count > 0)
                {
                    if (chkMisc.Checked == true)
                    {
                        txtFreight_Exch_Rate.Enabled = false;
                        txtFreight_Currency.Enabled = false;

                        txtInsurance_Exch_Rate.Enabled = false;
                        txtInsurance_Currency.Enabled = false;

                        txtTotal_Frieght.Enabled = false;
                    }
                }
                else
                {
                    if (chkMisc.Checked == true)
                    {
                        txtFreight_Exch_Rate.Enabled = true;
                        txtFreight_Currency.Enabled = true;

                        txtInsurance_Exch_Rate.Enabled = false;
                        txtInsurance_Currency.Enabled = false;

                        txtTotal_Frieght.Enabled = true;
                    }
                }

                cal1 = invoicevalue * (1.125 / 100);

                hdn_FOB_Freight_Rate.Value = txtFreight_Rate.Text;
                hdn_FOB_Freight_Charge.Value = txtFreight_Charges.Text;
                hdn_FOB_Freight_Currency.Value = txtFreight_Currency.Text;
                hdn_FOB_Freight_ExRate.Value = txtFreight_Exch_Rate.Text;

                //hdn_FOB_Insurance_Rate.Value = "1.1250";
                if (hdn_Cilent_InsuranceRate.Value != "")
                {
                    hdn_FOB_Insurance_Rate.Value = hdn_Cilent_InsuranceRate.Value;
                }
                else
                {
                    hdn_FOB_Insurance_Rate.Value = "1.1250";
                }
                hdn_FOB_Insurance_Charge.Value = Convert.ToString(cal1);
                hdn_FOB_Insurance_Currency.Value = txtInvoiceCurrency.Text;
                hdn_FOB_Insurance_ExRate.Value = txtExRate.Text;

                hdn_CI_Freight_Rate.Value = txtFreight_Rate.Text;
                hdn_CI_Freight_Charge.Value = txtFreight_Charges.Text;
                hdn_CI_Freight_Currency.Value = txtFreight_Currency.Text;
                hdn_CI_Freight_ExRate.Value = txtFreight_Exch_Rate.Text;


                //hdn_CF_Insurance_Rate.Value = "1.1250";//hide on 07-11-2025 by Chithra 
                if (hdn_Cilent_InsuranceRate.Value != "")
                {
                    hdn_CF_Insurance_Rate.Value = hdn_Cilent_InsuranceRate.Value;
                }
                else
                {
                    hdn_CF_Insurance_Rate.Value = "1.1250";
                }
                hdn_CF_Insurance_Charge.Value = Convert.ToString(cal1);
                hdn_CF_Insurance_Currency.Value = txtInvoiceCurrency.Text;
                hdn_CF_Insurance_ExRate.Value = txtExRate.Text;

                txtFreight_Rate.Enabled = true;
                txtInsurance_Rate.Enabled = false;

                txtInsurance_Exch_Rate.Text = null;
                txtInsurance_Currency.Text = null;
                txtInsurance_Rate.Text = null;
                txtInsurance_Charges.Text = null;
            }
            else if (ddlTerms.SelectedValue == "CF")
            {
                if (gv_Invoice.Rows.Count > 0)
                {
                    if (chkMisc.Checked == true)
                    {
                        txtFreight_Exch_Rate.Enabled = false;
                        txtFreight_Currency.Enabled = false;
                        txtInsurance_Exch_Rate.Enabled = false;
                        txtInsurance_Currency.Enabled = false;
                        txtTotal_Insurance.Enabled = false;
                    }
                }
                else
                {
                    if (chkMisc.Checked == true)
                    {
                        txtFreight_Exch_Rate.Enabled = false;
                        txtFreight_Currency.Enabled = false;
                        txtInsurance_Exch_Rate.Enabled = true;
                        txtInsurance_Currency.Enabled = true;
                        txtTotal_Insurance.Enabled = true;
                    }
                }

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
                txtFreight_Rate.Enabled = false;
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
                //hdn_CF_Insurance_Rate.Value = "1.1250";//hide on 07-11-2025 by Chithra 
                if (hdn_Cilent_InsuranceRate.Value != "")
                {
                    hdn_CF_Insurance_Rate.Value = hdn_Cilent_InsuranceRate.Value;
                }
                else
                {
                    hdn_CF_Insurance_Rate.Value = "1.1250";
                }
                hdn_CF_Insurance_Charge.Value = Convert.ToString(cal1);
                hdn_CF_Insurance_Currency.Value = txtInvoiceCurrency.Text;
                hdn_CF_Insurance_ExRate.Value = txtExRate.Text;


                hdn_FOB_Freight_Rate.Value = "20.0000";
                hdn_FOB_Freight_Charge.Value = Convert.ToString(cal);
                hdn_FOB_Freight_Currency.Value = txtInvoiceCurrency.Text;
                hdn_FOB_Freight_ExRate.Value = txtExRate.Text;

                //hdn_FOB_Insurance_Rate.Value = "1.1250";//hide on 07-11-2025 by Chithra 
                if (hdn_Cilent_InsuranceRate.Value != "")
                {
                    hdn_FOB_Insurance_Rate.Value = hdn_Cilent_InsuranceRate.Value;
                }
                else
                {
                    hdn_FOB_Insurance_Rate.Value = "1.1250";
                }
                hdn_FOB_Insurance_Charge.Value = Convert.ToString(cal1);
                hdn_FOB_Insurance_Currency.Value = txtInvoiceCurrency.Text;
                hdn_FOB_Insurance_ExRate.Value = txtExRate.Text;

                //-----------------freight----------------//

                txtFreight_Exch_Rate.Enabled = false;
                txtFreight_Currency.Enabled = false;
                txtFreight_Rate.Enabled = false;
                txtInsurance_Exch_Rate.Enabled = false;
                txtInsurance_Currency.Enabled = false;
                txtInsurance_Rate.Enabled = false;


                txtFreight_Exch_Rate.Text = null;
                txtFreight_Currency.Text = null;
                txtFreight_Rate.Text = null;
                txtFreight_Charges.Text = null;
                //-----------------insurance----------------//



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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            //
        }

    }


    public void Get_ProductValue()
    {
        try
        {
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = "0";
            Transact.ITEM_SLNO = "0";
            Transact.ITEM_ID = "0";

            Transact.INVOICE_NO = lblInvoiceNo.Text;
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "product_value";
            ds_product = Transact.RetrieveAll_Item_Details();
            if (Transact.TOTAL_ITEM_VALUE != "")
            {

                lblProductValue.Text = Transact.TOTAL_ITEM_VALUE;

                if (ds_product.Tables[1].Rows.Count > 0)
                {
                    lblTotal_No_Of_Invoices.Text = ds_product.Tables[1].Rows[0]["TOTAL_NO_OF_INVOICE"].ToString();
                }
            }
            else
            {
                lblProductValue.Text = "";

                if (ds_product.Tables[1].Rows.Count > 0)
                {
                    lblTotal_No_Of_Invoices.Text = ds_product.Tables[1].Rows[0]["TOTAL_NO_OF_INVOICE"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            //
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
                    if (Convert.ToInt32(ViewState["Newbtn"]) == 0)
                    {
                        e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                        e.Row.Font.Bold = true;
                        ViewState["id"] = "1";
                    }
                    if (ViewState["Newbtn"] == "Delete")
                    {
                        e.Row.BackColor = System.Drawing.Color.White;
                    }
                }

                if (hdn_Grid_Disable.Value == "1")
                {
                    e.Row.Enabled = false;
                }
                else
                {
                    e.Row.Enabled = true;

                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
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



                if (Convert.ToInt32(ViewState["btNew"]) == 1)
                {
                    if (e.Row.RowIndex == 0)
                    {
                        e.Row.BackColor = System.Drawing.Color.White;
                        e.Row.Font.Bold = false;
                    }
                    gv_Invoice.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                    gv_Invoice.SelectedRowStyle.Font.Bold = false;
                }
            }
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
    protected void gv_Invoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gv_Invoice.PageIndex = e.NewPageIndex;
            gridbind(inv_no, flag, TERMS, inv_slno);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

    }
    public void gridbind(string inv_no, string flag, string TERMS, string inv_slno)
    {
        try
        {
            hdn_INVOICE_SLNO.Value = "";

            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_NO = inv_no;
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.flag = flag;
            Transact.TERMS = TERMS;
            Transact.INVOICE_SLNO = inv_slno;
            dss = Transact.RetrieveAll_Invoice_Details();

            ddlInv_SL_No.DataSource = dss;
            ddlInv_SL_No.DataTextField = "INVOICE_SLNO";
            ddlInv_SL_No.DataValueField = "INVOICE_SLNO";
            ddlInv_SL_No.DataBind();

            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    //btnnew1.Visible = false;
                    //btn_Masedit.Visible = true;

                    gv_Invoice.DataSource = dss;
                    gv_Invoice.DataBind();
                    hdn_Total_Freight_Value.Value = Convert.ToString(Transact.ALL_FREIGHT_TOTAL);
                    hdn_Total_Insurance_Value.Value = Convert.ToString(Transact.ALL_INSURANCE_TOTAL);

                    flag = dss.Tables[0].Rows[0]["TERMS"].ToString();
                    singlemultiple = dss.Tables[0].Rows[0]["MIS_SINGLE_OR_MULITIPLE"].ToString();
                    if (singlemultiple == "M")
                    {
                        hdn_TOTAL_MULTIPLE_MISC_AMT.Value = Convert.ToString(Transact.TOTAL_MULTIPLE_MISC_AMT);
                        hdn_TOTAL_MULTIPLE_HSS_AMT.Value = Convert.ToString(Transact.TOTAL_MULTIPLE_HSS_AMT);


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

                        txt_Brokerage.Text = dss.Tables[0].Rows[0]["A_AMOUNT"].ToString();
                        txt_Cost_Container.Text = dss.Tables[0].Rows[0]["B_AMOUNT"].ToString();
                        txt_Cost_Packaging.Text = dss.Tables[0].Rows[0]["C_AMOUNT"].ToString();
                        txt_Handling_Charges.Text = dss.Tables[0].Rows[0]["D_AMOUNT"].ToString();
                        txt_Goods_Services.Text = dss.Tables[0].Rows[0]["E_AMOUNT"].ToString();
                        txt_Documentation.Text = dss.Tables[0].Rows[0]["F_AMOUNT"].ToString();
                        txt_Country_Origin.Text = dss.Tables[0].Rows[0]["G_AMOUNT"].ToString();
                        txt_Royalties_lic_fees.Text = dss.Tables[0].Rows[0]["H_AMOUNT"].ToString();
                        txt_Value_of_Proceeds.Text = dss.Tables[0].Rows[0]["I_AMOUNT"].ToString();
                        txt_Warrenty_Services.Text = dss.Tables[0].Rows[0]["J_AMOUNT"].ToString();
                        txt_Other_Cost_Payment.Text = dss.Tables[0].Rows[0]["K_AMOUNT"].ToString();
                        txt_Other_Charges_Payments.Text = dss.Tables[0].Rows[0]["L_AMOUNT"].ToString();
                        txt_Loading_Charges.Text = dss.Tables[0].Rows[0]["M_AMOUNT"].ToString();
                        txt_UnLoading_Charges.Text = dss.Tables[0].Rows[0]["N_AMOUNT"].ToString();
                        txt_Total_Amount.Text = dss.Tables[0].Rows[0]["TOTAL_OTHER_AMOUNT"].ToString();
                        txt_DocRecd_Date.Text = dss.Tables[0].Rows[0]["DOC_RECD_DATE"].ToString();


                        //--------------- INVOICE MISC - NEW FIELDS---------START---------
                        txt_INV_MISC_Currency.Text = dss.Tables[0].Rows[0]["INV_MISC_CURRENCY"].ToString();
                        txt_INV_MISC_Exch_Rate.Text = dss.Tables[0].Rows[0]["INV_MISC_EXRATE"].ToString();
                        txt_INV_MISC_Charges.Text = dss.Tables[0].Rows[0]["INV_MISC_CHARGES"].ToString();
                        txt_INV_MISC_Total_Charge.Text = dss.Tables[0].Rows[0]["INV_MISC_TOTAL_CHARGES"].ToString();
                        hdn_INV_MISC_Total_Charge.Value = dss.Tables[0].Rows[0]["INV_MISC_TOTAL_CHARGES"].ToString();


                        if (dss.Tables[0].Rows[0]["INV_MISC_T_F"].ToString() == "T")
                        {
                            chk_active_Inv_Misc.Checked = true;
                            hdn_chk_active_Inv_Misc.Value = "T";
                            lbl_INV_MISC_Total_Charge_Currency.Text = txtMiscellaneous_Currency.Text;
                        }
                        else
                        {
                            chk_active_Inv_Misc.Checked = false;
                            hdn_chk_active_Inv_Misc.Value = "F";
                        }

                        if (dss.Tables[0].Rows[0]["INV_MISC_ADD_FRT_INS_YN"].ToString() == "Y")
                        {
                            chk_add_INV_MISC.Checked = true;
                        }
                        else
                        {
                            chk_add_INV_MISC.Checked = false;
                        }

                        //SINGLE WINDOW OPERATION

                        chkMisc.Checked = true;
                        chkMisc.Enabled = false;
                        //-------------Sriram-------Start-----------------------------------------------------

                        DivFreight.Style.Add("display", "block");
                        DivInsurance.Style.Add("display", "block");

                        ViewState["CHKI_I"] = dss.Tables[0].Rows[0]["MI_INSURANCE"].ToString();
                        ViewState["CHKF_F"] = dss.Tables[0].Rows[0]["MI_FREIGHT"].ToString();

                        if (dss.Tables[0].Rows[0]["MI_FREIGHT"].ToString() != "")
                        {
                            CHKF.SelectedValue = dss.Tables[0].Rows[0]["MI_FREIGHT"].ToString();
                        }

                        if (dss.Tables[0].Rows[0]["MI_INSURANCE"].ToString() != string.Empty)
                        {
                            CHKI.SelectedValue = dss.Tables[0].Rows[0]["MI_INSURANCE"].ToString();
                        }

                        if (dss.Tables[0].Rows[0]["MI_MISC"].ToString() != null && dss.Tables[0].Rows[0]["MI_MISC"].ToString() != string.Empty)
                        {
                            Chk_Misc.SelectedValue = dss.Tables[0].Rows[0]["MI_MISC"].ToString();

                            Div_MISC_txt.Style.Add("display", "block");
                            txtMiscellaneous_Rate.Enabled = false;
                            txtMiscellaneous_Charges.Enabled = false;

                            txtMisc_Total_Charge.Text = Convert.ToString(Transact.TOTAL_MULTIPLE_MISC_AMT);
                        }
                        else
                        {
                            Div_MISC_txt.Style.Add("display", "none");
                            txtMiscellaneous_Rate.Enabled = true;
                            txtMiscellaneous_Charges.Enabled = true;
                        }

                        if (dss.Tables[0].Rows[0]["MI_HSS"].ToString() != null && dss.Tables[0].Rows[0]["MI_HSS"].ToString() != string.Empty)
                        {
                            CHKHSS.SelectedValue = dss.Tables[0].Rows[0]["MI_HSS"].ToString();
                            Div_Hss_txt.Style.Add("display", "block");

                            txtHighSeaSale_Rate.Enabled = false;
                            txtHighSeaSale_Charges.Enabled = false;
                            txtHss_Total_Charge.Text = Convert.ToString(Transact.TOTAL_MULTIPLE_HSS_AMT);
                        }
                        else
                        {
                            Div_Hss_txt.Style.Add("display", "none");
                            txtHighSeaSale_Rate.Enabled = true;
                            txtHighSeaSale_Charges.Enabled = true;
                        }

                        //-------------Sriram-------End-----------------------------------------------------

                        txtFreight_Charges.Enabled = false;
                        txtInsurance_Charges.Enabled = false;

                        //ddlTerms.Enabled = false;
                        ddlTerms.Items.Clear();
                        ddlTerms.Items.Add(flag);

                        pnl_Multi_Invoice.Enabled = false;
                        Terms_Change_Updating_MultiInvoice();
                    }
                    else
                    {
                        ViewState["CHKI_I"] = string.Empty;
                        ViewState["CHKF_F"] = string.Empty;
                        ViewState["CHK_HSS"] = string.Empty;
                        ViewState["CHK_MISC"] = string.Empty;

                        chkMisc.Enabled = false;
                        txtFreight_Charges.Enabled = false;
                        txtInsurance_Charges.Enabled = false;
                        pnl_Multi_Invoice.Enabled = true;
                        Terms_Change_Updating_MultiInvoice();

                    }
                    Supplier_SVB_details_Bind();
                    SINGLE_WINDOW_OPERATION_Details();
                    INVOICE_OTHER_CHARGES_DETAILS();

                    // ----Audit Modified Data -----------------------------------
                    if (Audit_YN == "Y")
                    {
                        Tbl_Filed_Modified_History(dss.Tables[1]);
                    }
                }
                else
                {
                    if (Session["BE_TYPE"].ToString() != "SEZ DTA-M")
                    {
                        ddlterms_clear();
                    }
                    gv_Invoice.DataSource = dt;//add empty row

                    gv_Invoice.DataBind();
                    pnl_Multi_Invoice.Enabled = true;
                    Terms_Change_Updating_MultiInvoice();

                    //btnnew1.Visible = true;
                    //btn_Masedit.Visible = false;

                    DivFreight.Style.Add("display", "none");
                    DivInsurance.Style.Add("display", "none");

                    ViewState["CHKI_I"] = string.Empty;
                    ViewState["CHKF_F"] = string.Empty;
                    ViewState["CHK_HSS"] = string.Empty;
                    ViewState["CHK_MISC"] = string.Empty;

                }
            }
            else
            {
                if (Session["BE_TYPE"].ToString() != "SEZ DTA-M")
                {
                    ddlterms_clear();
                }
                gv_Invoice.DataSource = dt;//add empty row

                gv_Invoice.DataBind();
                pnl_Multi_Invoice.Enabled = true;
                Terms_Change_Updating_MultiInvoice();

            }

            if (gv_Invoice.Rows.Count > 0)
            {
                ViewState["INVOICE_ID"] = gv_Invoice.Rows[0].Cells[88].Text.Replace("&nbsp;", "");
                if (!IsPostBack)
                {
                    INVOICE_Edit_UpdateDetails();
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
                hdn_grid_edit.Value = "1";
                hdn_button_click.Value = "1";

                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btn_save_new.Visible = false;
                hdn_update_Invoice_id.Value = ViewState["INVOICE_ID"].ToString();

                Label s_itemType = gv_Invoice.Rows[0].FindControl("lblFullName") as Label;
                Session["_SLNO"] = s_itemType.Text;
                hdn_INVOICE_SLNO.Value = s_itemType.Text;
                sno = gv_Invoice.Rows[0].Cells[2].Text;

                Session["INV_SLNO"] = sno;
                txtInvoiceNo.Text = rep.Replace(gv_Invoice.Rows[0].Cells[3].Text);
                txtDate.Text = gv_Invoice.Rows[0].Cells[4].Text.Replace("01/01/1900", "");

                string terms = gv_Invoice.Rows[0].Cells[5].Text.Replace("&nbsp;", "");
                ddlterms_clear();
                ddlTerms.Items.Remove(terms);
                ddlTerms.Items.Insert(0, terms);
                txtInvoiceValue.Text = gv_Invoice.Rows[0].Cells[6].Text.Replace("&nbsp;", "");

                txtInvoiceCurrency.Text = gv_Invoice.Rows[0].Cells[7].Text.ToUpper().Replace("&nbsp;", "");
                hdn_chk_Invalid_Cur.Value = GetExchange_Rate_Invoice_Cur(txtInvoiceCurrency.Text);

                string chk = gv_Invoice.Rows[0].Cells[8].Text.Replace("&nbsp;", "");
                hdn_Invoice_mode_singlr_or_multi.Value = chk;

                txtSupplierName.Text = rep.Replace(gv_Invoice.Rows[0].Cells[9].Text);
                txtSupplier_Branch_Slno.Text = rep.Replace(gv_Invoice.Rows[0].Cells[129].Text);
                txtSupplierAddress.Text = rep.Replace(gv_Invoice.Rows[0].Cells[10].Text);
                txtSupplierAddress1.Text = rep.Replace(gv_Invoice.Rows[0].Cells[11].Text);
                txtSupplierAddress2.Text = rep.Replace(gv_Invoice.Rows[0].Cells[12].Text);
                txtSupplierCountryName.Text = rep.Replace(gv_Invoice.Rows[0].Cells[13].Text);
                hfdsupplier_countrycode.Value = gv_Invoice.Rows[0].Cells[14].Text.Replace("&nbsp;", "");
                txtSuppliercountry_pincode.Text = gv_Invoice.Rows[0].Cells[15].Text.Replace("&nbsp;", "");

                txtSellerName.Text = rep.Replace(gv_Invoice.Rows[0].Cells[16].Text);
                txtSellerAddress.Text = rep.Replace(gv_Invoice.Rows[0].Cells[17].Text);
                txtSellerAddress1.Text = rep.Replace(gv_Invoice.Rows[0].Cells[18].Text);
                txtSellerAddress2.Text = rep.Replace(gv_Invoice.Rows[0].Cells[19].Text);
                txtSellerCountryName.Text = rep.Replace(gv_Invoice.Rows[0].Cells[20].Text);
                hfdseller_countrycode.Value = gv_Invoice.Rows[0].Cells[21].Text.Replace("&nbsp;", "");
                txtSellercountry_pincode.Text = gv_Invoice.Rows[0].Cells[22].Text.Replace("&nbsp;", "");
                txtBrokerName.Text = rep.Replace(gv_Invoice.Rows[0].Cells[23].Text);
                txtBrokerAddress.Text = rep.Replace(gv_Invoice.Rows[0].Cells[24].Text);
                txtBrokerAddress1.Text = rep.Replace(gv_Invoice.Rows[0].Cells[25].Text);
                txtBrokerAddress2.Text = rep.Replace(gv_Invoice.Rows[0].Cells[26].Text);
                txtBrokerCountryName.Text = rep.Replace(gv_Invoice.Rows[0].Cells[27].Text);
                hfdbroker_countrycode.Value = gv_Invoice.Rows[0].Cells[28].Text.Replace("&nbsp;", "");
                txtbrokercountry_pincode.Text = gv_Invoice.Rows[0].Cells[29].Text.Replace("&nbsp;", "");
                txtMiscellaneous_Charges.Text = gv_Invoice.Rows[0].Cells[30].Text.Replace("&nbsp;", "");
                txtMiscellaneous_Rate.Text = gv_Invoice.Rows[0].Cells[31].Text.Replace("&nbsp;", "");
                txtMiscellaneous_Currency.Text = gv_Invoice.Rows[0].Cells[32].Text.Replace("&nbsp;", "");
                hdn_chk_curr.Value = GetExchange_Rate(txtMiscellaneous_Currency.Text);

                txtMiscellaneous_Exch_Rate.Text = gv_Invoice.Rows[0].Cells[33].Text.Replace("&nbsp;", "");
                txtAgency_Charges.Text = gv_Invoice.Rows[0].Cells[34].Text.Replace("&nbsp;", "");
                txtAgency_Rate.Text = gv_Invoice.Rows[0].Cells[35].Text.Replace("&nbsp;", "");
                txtAgency_Currency.Text = gv_Invoice.Rows[0].Cells[36].Text.Replace("&nbsp;", "");
                txtAgency_Exch_Rate.Text = gv_Invoice.Rows[0].Cells[37].Text.Replace("&nbsp;", "");
                txtDiscount_Charges.Text = gv_Invoice.Rows[0].Cells[38].Text.Replace("&nbsp;", "");
                txtDiscount_Rate.Text = gv_Invoice.Rows[0].Cells[39].Text.Replace("&nbsp;", "");
                txtDiscount_Currency.Text = gv_Invoice.Rows[0].Cells[40].Text.Replace("&nbsp;", "");
                hdn_Invalid_Disc_Cur.Value = GetExchange_Rate(txtDiscount_Currency.Text);

                txtDiscount_Exch_Rate.Text = gv_Invoice.Rows[0].Cells[41].Text.Replace("&nbsp;", "");
                txtDiscount_Reason.Text = gv_Invoice.Rows[0].Cells[42].Text.Replace("&nbsp;", "");
                txtLoading_Charges.Text = gv_Invoice.Rows[0].Cells[43].Text.Replace("&nbsp;", "");
                txtLoading_Rate.Text = gv_Invoice.Rows[0].Cells[44].Text.Replace("&nbsp;", "");
                txtLoading_Currency.Text = gv_Invoice.Rows[0].Cells[45].Text.Replace("&nbsp;", "");
                txtLoading_ExchRate.Text = gv_Invoice.Rows[0].Cells[46].Text.Replace("&nbsp;", "");
                txtFreight_Charges.Text = gv_Invoice.Rows[0].Cells[47].Text.Replace("&nbsp;", "");
                txtFreight_Rate.Text = gv_Invoice.Rows[0].Cells[48].Text.Replace("&nbsp;", "");

                txtFreight_Currency.Text = gv_Invoice.Rows[0].Cells[49].Text.Replace("&nbsp;", "");
                hdn_Invalid_FRT_Cur.Value = GetExchange_Rate(txtFreight_Currency.Text);

                txtFreight_Exch_Rate.Text = gv_Invoice.Rows[0].Cells[50].Text.Replace("&nbsp;", "");
                txtInsurance_Charges.Text = gv_Invoice.Rows[0].Cells[51].Text.Replace("&nbsp;", "");
                txtInsurance_Rate.Text = gv_Invoice.Rows[0].Cells[52].Text.Replace("&nbsp;", "");

                txtInsurance_Currency.Text = gv_Invoice.Rows[0].Cells[53].Text.Replace("&nbsp;", "");
                hdn_Invalid_INS_Cur.Value = GetExchange_Rate(txtInsurance_Currency.Text);

                txtInsurance_Exch_Rate.Text = gv_Invoice.Rows[0].Cells[54].Text.Replace("&nbsp;", "");
                txtHighSeaSale_Charges.Text = gv_Invoice.Rows[0].Cells[55].Text.Replace("&nbsp;", "");
                txtHighSeaSale_Rate.Text = gv_Invoice.Rows[0].Cells[56].Text.Replace("&nbsp;", "");

                txtHighSeaSale_Currency.Text = gv_Invoice.Rows[0].Cells[57].Text.Replace("&nbsp;", "");
                hdn_Invalid_Hss_Cur.Value = GetExchange_Rate(txtHighSeaSale_Currency.Text);

                txtHighSeaSale_Exch_Rate.Text = gv_Invoice.Rows[0].Cells[58].Text.Replace("&nbsp;", "");
                txtExRate.Text = gv_Invoice.Rows[0].Cells[78].Text.Replace("&nbsp;", "");

                if (chk == "M")
                {
                    chkMisc.Checked = true;
                    chkMisc.Enabled = true;
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

                    if (chkMisc.Checked == false)
                    {
                        txtFreight_Rate.Text = "0.00";
                        txtInsurance_Rate.Text = "0.00";
                    }

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

                    Single_Inv();

                }
                string chksvb = gv_Invoice.Rows[0].Cells[59].Text.Replace("&nbsp;", "");
                if (chksvb == "Y")
                {
                    chkSVB_Relation.Checked = true;
                    txtSVB_RefNo.Enabled = true;
                    txtSVBDate.Enabled = true;
                    txtCustomsHouse.Enabled = true;

                    ddlLoadingOn.Enabled = true;

                    txtSVB_RefNo.Text = gv_Invoice.Rows[0].Cells[60].Text.Replace("&nbsp;", "");
                    string SVB_CustomHouse = gv_Invoice.Rows[0].Cells[61].Text.Replace("&nbsp;", "");
                    txtCustomsHouse.Text = SVB_CustomHouse;
                    hdn_Customhouse_chk.Value = Set_Customs_House_Validation(txtCustomsHouse.Text);

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

                        txtAssesable_Rate.Enabled = true;
                        ddlAssesable_Status.Enabled = true;
                        txtDuty_Rate.Enabled = true;
                        ddlDuty_Status.Enabled = true;
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
                }
                else
                {
                    chkSVB_Relation.Checked = false;
                    txtSVB_RefNo.Text = "";
                    txtCustomsHouse.Text = "";
                    txtAssesable_Rate.Text = "";
                    txtDuty_Rate.Text = "";
                    ddlAssesable_Status.Text = "";
                    ddlDuty_Status.Text = "";
                    ddlLoadingOn.Text = "";
                    txtSVBDate.Text = "";

                    txtSVB_RefNo.Enabled = false;
                    txtSVBDate.Enabled = false;
                    txtCustomsHouse.Enabled = false;
                    txtAssesable_Rate.Enabled = false;
                    txtDuty_Rate.Enabled = false;
                    ddlAssesable_Status.Enabled = false;
                    ddlDuty_Status.Enabled = false;
                    ddlLoadingOn.Enabled = false;
                }

                txtPurchaseOrderNo.Text = gv_Invoice.Rows[0].Cells[67].Text.Replace("&nbsp;", "");
                txtPurchaseDate.Text = gv_Invoice.Rows[0].Cells[68].Text.Replace("01/01/1900", "");
                txtContractNo.Text = gv_Invoice.Rows[0].Cells[69].Text.Replace("&nbsp;", "");
                txtContractDate.Text = gv_Invoice.Rows[0].Cells[70].Text.Replace("01/01/1900", "");
                txtLCNo.Text = gv_Invoice.Rows[0].Cells[71].Text.Replace("&nbsp;", "");
                txtLCDate.Text = gv_Invoice.Rows[0].Cells[72].Text.Replace("01/01/1900", "");

                ddlNatureOfTrans.Items.Clear();
                ddlNatureOfTrans_List();
                ddlNatureOfTrans.Items.Remove(gv_Invoice.Rows[0].Cells[73].Text.Replace("&nbsp;", "").Replace("&#160;", ""));
                ddlNatureOfTrans.Items.Insert(0, gv_Invoice.Rows[0].Cells[73].Text.Replace("&nbsp;", "").Replace("&#160;", ""));

                ddlNatureOfPayment.Items.Clear();
                ddlNatureOfPayment_list();
                ddlNatureOfPayment.Items.Remove(gv_Invoice.Rows[0].Cells[74].Text.Replace("&nbsp;", "").Replace("&#160; ", ""));
                ddlNatureOfPayment.Items.Insert(0, gv_Invoice.Rows[0].Cells[74].Text.Replace("&nbsp;", "").Replace("&#160; ", ""));


                txtConditions.Text = rep.Replace(gv_Invoice.Rows[0].Cells[75].Text);

                ddlValuationMethod.Items.Clear();
                ddlValuationMethod_List();
                ddlValuationMethod.Items.Remove(gv_Invoice.Rows[0].Cells[76].Text.Replace("&nbsp;", "").Replace("&#160; ", ""));
                ddlValuationMethod.Items.Insert(0, gv_Invoice.Rows[0].Cells[76].Text.Replace("&nbsp;", "").Replace("&#160; ", ""));

                txtSVBDate.Text = gv_Invoice.Rows[0].Cells[77].Text.Replace("01/01/1900", "");

                hdn_non_std_effect_dt.Value = gv_Invoice.Rows[0].Cells[80].Text.Replace("&nbsp;", "");
                hdn_non_std_bankname.Value = gv_Invoice.Rows[0].Cells[81].Text.Replace("&nbsp;", "");
                hdn_non_std_cert_no.Value = gv_Invoice.Rows[0].Cells[82].Text.Replace("&nbsp;", "");
                hdn_non_std_cert_dt.Value = gv_Invoice.Rows[0].Cells[83].Text.Replace("&nbsp;", "");

                txtSAP_Delievery_ID.Text = gv_Invoice.Rows[0].Cells[84].Text.Replace("&nbsp;", "");
                txtShip_Date.Text = gv_Invoice.Rows[0].Cells[85].Text.Replace("01/01/1900", "");
                txtInvoice_Level.Text = gv_Invoice.Rows[0].Cells[86].Text.Replace("&nbsp;", "");
                txtCountry_Departure.Text = gv_Invoice.Rows[0].Cells[87].Text.Replace("&nbsp;", "");

                txtRevenue_Deposit.Text = gv_Invoice.Rows[0].Cells[89].Text.Replace("&nbsp;", "");
                Revenue_LoadOn = gv_Invoice.Rows[0].Cells[90].Text.Replace("&nbsp;", "");
                string Revenue_on = "";
                if (Revenue_LoadOn == "A")
                {
                    Revenue_on = "Assessable";
                }
                else if (Revenue_LoadOn == "D")
                {
                    Revenue_on = "Duty";

                }
                else if (Revenue_LoadOn == "B")
                {
                    Revenue_on = "Both";
                }

                ddlRevenueDeposit_On.Items.Clear();
                ddlRevenueDeposit();
                ddlRevenueDeposit_On.Items.Remove(Revenue_on);
                ddlRevenueDeposit_On.Items.Insert(0, Revenue_on);



                if (gv_Invoice.Rows[0].Cells[123].Text.Replace("&nbsp;", "") == "T")
                {
                    chk_active_Inv_Misc.Checked = true;
                    hdn_chk_active_Inv_Misc.Value = "T";
                    // lbl_INV_MISC_Total_Charge_Currency.Text = txtMiscellaneous_Currency.Text;
                }

                txt_INV_MISC_Currency.Text = gv_Invoice.Rows[0].Cells[124].Text.Replace("&nbsp;", "");
                txt_INV_MISC_Exch_Rate.Text = gv_Invoice.Rows[0].Cells[125].Text.Replace("&nbsp;", "");
                txt_INV_MISC_Charges.Text = gv_Invoice.Rows[0].Cells[126].Text.Replace("&nbsp;", "");
                txt_INV_MISC_Total_Charge.Text = gv_Invoice.Rows[0].Cells[127].Text.Replace("&nbsp;", "");
                hdn_INV_MISC_Total_Charge.Value = gv_Invoice.Rows[0].Cells[127].Text.Replace("&nbsp;", "");


                if (!string.IsNullOrEmpty(Session["BE_No"].ToString()))
                {
                    div_AmendmentType.Visible = true;
                    ddl_AmendmentType.SelectedValue = rep.Replace(gv_Invoice.Rows[0].Cells[130].Text);
                }

                if (gv_Invoice.Rows[0].Cells[128].Text.Replace("&nbsp;", "") == "Y")
                {
                    chk_add_INV_MISC.Checked = true;
                }


                lblInvoiceNo.Text = txtInvoiceNo.Text;
                lblInvoiceDate.Text = txtDate.Text;
                lblInvoiceCurrency.Text = txtInvoiceCurrency.Text;
                lblInvoiceTerms.Text = ddlTerms.SelectedValue;
                lblInvoiceValue.Text = txtInvoiceValue.Text;

                Get_ProductValue();
                Terms_clear_Total_freight_Insurance();
                hdn_button_click.Value = "";
                if (gv_Invoice.Rows.Count > 0)
                {
                    if (gv_Invoice.Rows.Count == 1)
                    {
                        hdn_grid_count.Value = "1";
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

                if (Audit_YN == "Y")
                {
                    DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"]);
                }
            }
            else
            {
                hdn_grid_edit.Value = "0";
                hdn_button_click.Value = "";

                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btn_save_new.Visible = true;


            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>document.getElementById('IMD').click();</script>", false);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void insert_or_update()
    {
        try
        {
            string chkmis = "";
            if (chkMisc.Checked == true)
            {
                chkmis = "M";

                string CHKF_F = string.Empty;
                string CHKI_I = string.Empty;

                foreach (ListItem oItem in CHKF.Items)
                {
                    if (oItem.Selected)
                    {
                        CHKF_F = oItem.Value;
                    }
                }
                foreach (ListItem oItem in CHKI.Items)
                {
                    if (oItem.Selected)
                    {
                        CHKI_I = oItem.Value;
                    }
                }

                ViewState["CHKF_F"] = CHKF_F;
                ViewState["CHKI_I"] = CHKI_I;
            }
            else if (hdn_Invoice_mode_singlr_or_multi.Value == "T")//its for after Multisplit Convert-Invoice not update on single click Agility-0n 10-11-2020
            {
                chkmis = "T";

                string CHKF_F = string.Empty;
                string CHKI_I = string.Empty;
                string CHK_HSS = string.Empty;
                string CHK_MISC = string.Empty;

                CHKF_F = ViewState["CHKF_F"].ToString();
                CHKI_I = ViewState["CHKI_I"].ToString();
                CHK_HSS = ViewState["CHK_HSS"].ToString();
                CHK_MISC = ViewState["CHK_MISC"].ToString();

            }
            else
            {
                chkmis = "S";
                ViewState["CHKF_F"] = string.Empty;
                ViewState["CHKI_I"] = string.Empty;
                ViewState["CHK_HSS"] = string.Empty;
                ViewState["CHK_MISC"] = string.Empty;
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

            if (txtShip_Date.Text == "")
            {
                SHIP_DATE = "01/01/1900";
            }
            else
            {
                SHIP_DATE = txtShip_Date.Text;
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
                gv_Invoice.DataSource = insert_update(a1, a2, a3, a4, a5, a6, chkmis);
                gv_Invoice.DataBind();

                hdn_TOTAL_MULTIPLE_MISC_AMT.Value = Convert.ToString(Transact.TOTAL_MULTIPLE_MISC_AMT);
                hdn_TOTAL_MULTIPLE_HSS_AMT.Value = Convert.ToString(Transact.TOTAL_MULTIPLE_HSS_AMT);

                if (Transact.result != 2)
                {
                    if (ddlTerms.SelectedValue == "FOB")
                    {

                        if (ViewState["CHKF_F"].ToString() == "Amt")
                        {
                            txtFreight_Rate.Enabled = false;
                            txtFreight_Charges.Enabled = false;
                        }
                        else if (ViewState["CHKF_F"].ToString() == "Rate")
                        {
                            txtFreight_Rate.Enabled = true;
                            txtFreight_Charges.Enabled = false;
                        }

                        if (ViewState["CHKI_I"].ToString() == "Amt")
                        {
                            txtInsurance_Rate.Enabled = false;
                            txtInsurance_Charges.Enabled = false;
                        }
                        else if (ViewState["CHKI_I"].ToString() == "Rate")
                        {
                            txtInsurance_Rate.Enabled = true;
                            txtInsurance_Charges.Enabled = false;
                        }

                        hdn_Total_Freight_Value.Value = Convert.ToString(Transact.ALL_FREIGHT_TOTAL);
                        hdn_Total_Insurance_Value.Value = Convert.ToString(Transact.ALL_INSURANCE_TOTAL);

                    }
                    else if (ddlTerms.SelectedValue == "CI")
                    {

                        if (ViewState["CHKF_F"].ToString() == "Amt")
                        {
                            txtFreight_Rate.Enabled = false;
                            txtFreight_Charges.Enabled = false;
                        }
                        else if (ViewState["CHKF_F"].ToString() == "Rate")
                        {
                            txtFreight_Rate.Enabled = true;
                            txtFreight_Charges.Enabled = false;
                        }

                        txtInsurance_Rate.Enabled = false;
                        txtInsurance_Charges.Enabled = false;

                        hdn_Total_Freight_Value.Value = Convert.ToString(Transact.ALL_FREIGHT_TOTAL);

                    }
                    else if (ddlTerms.SelectedValue == "CF")
                    {
                        txtFreight_Rate.Enabled = false;
                        txtFreight_Charges.Enabled = false;

                        if (ViewState["CHKI_I"].ToString() == "Amt")
                        {
                            txtInsurance_Rate.Enabled = false;
                            txtInsurance_Charges.Enabled = false;
                        }
                        else if (ViewState["CHKI_I"].ToString() == "Rate")
                        {
                            txtInsurance_Rate.Enabled = true;
                            txtInsurance_Charges.Enabled = false;
                        }
                        hdn_Total_Insurance_Value.Value = Convert.ToString(Transact.ALL_INSURANCE_TOTAL);
                    }

                }
                Chk_Misc.Enabled = false;
                CHKHSS.Enabled = false;


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

            if (i == 1)
            {
                Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), txt_InvoiceSlno.Text, "", "Invoice", flag, "Insert");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void BOND_insert_update(string IMPORT_JOBNO, string BOND_ID, string flag, string year)//
    {
        try
        {

            Transact.BONDID = BOND_ID;
            Transact.JOBNO = IMPORT_JOBNO;//call session value from general details
            Transact.BOND_NO = hdn_BOND_NO.Value;
            Transact.BOND_TYPE = hdn_BOND_TYPE.Value;
            Transact.BOND_LOCATION = hdn_BOND_LOCATION.Value;

            Transact.USER_ID = currentuser;
            Transact.flag = flag;
            Transact.BRANCH_CODE = currentbranch;
            Transact.YEAR = year;
            Transact.WORKING_PERIOD = Working_Period;
            Transact.BRANCH_COMMON = SELECT_BRANCH;

            dss = Transact.BOND_Details_insertupdate();
            i = Transact.result;
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
            Inv_Avail = Check_Inv_Slno_Avail("Check_Inv_Slno_Avail_Update", ViewState["INVOICE_ID"].ToString());

            if (Inv_Avail != "Exists")
            {
                ViewState["btNew"] = 2;
                //if (ddlTerms.SelectedItem.Text != "CI" || txt_Handling_Charges.Text != "" && txt_Loading_Charges.Text != "" && txt_UnLoading_Charges.Text != "")
                //{
                //    double Handling_Charges = Convert.ToDouble(txt_Handling_Charges.Text == string.Empty ? 0 : Convert.ToDouble(txt_Handling_Charges.Text));
                //    double Loading_Charges = Convert.ToDouble(txt_Loading_Charges.Text == string.Empty ? 0 : Convert.ToDouble(txt_Loading_Charges.Text));
                //    double UnLoading_Charges = Convert.ToDouble(txt_UnLoading_Charges.Text == string.Empty ? 0 : Convert.ToDouble(txt_UnLoading_Charges.Text));

                //    if (ddlTerms.SelectedItem.Text != "CI" || Handling_Charges > 0 && Loading_Charges > 0 && UnLoading_Charges > 0)
                //    {
                try
                {
                    a1 = ViewState["INVOICE_ID"].ToString();
                    a2 = "U";
                    a3 = "";
                    a4 = Session["INV_SLNO"].ToString();

                    if (Session["_SLNO"] != null || Convert.ToInt32(Session["_SLNO"]) > 0)
                    {
                        _slno = Session["_SLNO"].ToString();
                    }
                    else
                    {
                        _slno = "1";
                    }

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

                                Div_MISC_txt.Style.Add("display", "none");

                                Div_Hss_txt.Style.Add("display", "none");
                                txtMiscellaneous_Rate.Enabled = true;
                                txtMiscellaneous_Charges.Enabled = true;

                                txtHighSeaSale_Rate.Enabled = true;
                                txtHighSeaSale_Charges.Enabled = true;
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
                                a5 = txtFreight_Charges.Text;
                                a6 = txtInsurance_Charges.Text;

                                Terms_clear_Total_freight_Insurance();
                                //--------------UPDATE AND CONVERT SINGLE TO MULTIPLE INVOICE----------//
                            }
                        }

                    }

                    insert_or_update();
                    if (i == 1)
                    {
                        if (Session["_SLNO"] != null || Convert.ToInt32(Session["_SLNO"]) > 0)
                        {
                            _slno = Session["_SLNO"].ToString();
                        }
                        else
                        {
                            _slno = "1";
                        }
                        Invoice_Updation1(_slno);

                        txtInvoiceNo.Focus();
                        hdn_button_click.Value = "";

                        Elogix_Service();

                        // -----------------Audit Modified Data ----------------------
                        if (Audit_YN == "Y")
                        {
                            Audit_Modified_DataTableComparer();
                        }
                        //------------------------------------------------------------

                        Alert_msg("Invoice Updated Successfully", "btnSave");

                    }
                    else if (i == 2)
                    {
                        Terms_Change_Updating_MultiInvoice();
                        txtInvoiceNo.Focus();
                        Alert_msg("Invoice No Already Exist!", "btnSave");


                    }
                    else if (i == 4)
                    {
                        Terms_Change_Updating_MultiInvoice();
                        txtInvoiceNo.Focus();
                        Alert_msg("Do you Want to Modify Multiple to Single Invoice? Remove All Invoices Except First Invoice No.", "btnSave");
                    }
                    else
                    {
                        txtInvoiceNo.Focus();
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
                CHK_True_False();

                if (chkMisc.Checked == true)
                {
                    if (Chk_Misc.SelectedValue != string.Empty)
                    {
                        Div_MISC_txt.Style.Add("display", "block");
                    }
                    else
                    {
                        Div_MISC_txt.Style.Add("display", "none");
                        txtMiscellaneous_Rate.Enabled = true;
                        txtMiscellaneous_Charges.Enabled = true;
                    }
                    if (CHKHSS.SelectedValue != string.Empty)
                    {
                        Div_Hss_txt.Style.Add("display", "block");
                    }
                    else
                    {
                        Div_Hss_txt.Style.Add("display", "none");
                        txtHighSeaSale_Rate.Enabled = true;
                        txtHighSeaSale_Charges.Enabled = true;
                    }

                }

                if (hdn_BOND_NO.Value != "" && hdn_BOND_LOCATION.Value != "" && hdn_BOND_TYPE.Value != "")
                {
                    BOND_insert_update(IMPORT_JOBNO, "", "S", "");
                }
                //    }
                //    else
                //    {
                //        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "CI_Check_notbe_ZERO_Alert_Msg()", true);
                //    }
                //}
                //else
                //{
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "CI_Handling_Alert_Msg()", true);
                //}
            }
            else
            {
                Alert_msg("Invoice Sl.No Already Exist!", "btnSave");
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>document.getElementById('IMD').click();</script>", false);

            if (Session["INV_SLNO"] != null)
            {
                string flag = "Delete";
                gridbind(txtInvoiceNo.Text, flag, ddlTerms.SelectedValue.ToString(), Session["INV_SLNO"].ToString());
                i = Transact.result;


                if (i == 1)
                {
                    Elogix_Service();

                    btnNew_Click(sender, e);
                    hdn_INVOICE_SLNO.Value = "";
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btn_save_new.Visible = true;
                    ddlterms_clear();
                    get_Textboxvalue();

                    Alert_msg("Invoice Deleted", "btnSave");
                    Get_ProductValue();

                    Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), txt_InvoiceSlno.Text, "", "Invoice", "D", "Insert");

                }
                else
                {
                    Terms_Change_Updating_MultiInvoice();
                    Alert_msg("Invoice Not Deleted", "btnSave");

                }
            }
            CHK_True_False();

            if (gv_Invoice.Rows.Count > 0)
            {

            }
            else
            {
                DivMISC.Style.Add("display", "none");
                DivHSS.Style.Add("display", "none");
                Div_MISC_txt.Style.Add("display", "none");
                Div_Hss_txt.Style.Add("display", "none");

                Chk_Misc.SelectedIndex = -1;
                CHKHSS.SelectedIndex = -1;

                txtMisc_Total_Charge.Text = string.Empty;
                txtHss_Total_Charge.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    public void GET_CURCODE_EXCH_RATE(string Currency_Code)
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void GET_INVOICE_CURCODE_EXCH_RATE()
    {
        try
        {
            if (txtInvoiceValue.Text != "")
            {
                invoicevalue = Convert.ToDouble(txtInvoiceValue.Text);
                erm.Invoice_Currency = txtInvoiceCurrency.Text;
                erm.Ename = "IMPORT_INVOICE_EX_RATE";
                erm.EWorking_Period = Working_Period;
                dss = erm.RetrieveAll_Exchange_master_INV_Currency();
                if (dss.Tables[0].Rows.Count > 0)
                {

                    hdn_currency.Value = dss.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    protected void txtFreight_Currency_TextChanged(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    public void Freight_Currency_Textchanged()
    {
        try
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
                    cal = ((invoicevalue * 20 / 100) * Invoice_Currency_Exrate);
                    double EXRATE = Convert.ToDouble(MISC_EXRATE);
                    cal1 = Math.Round(cal / EXRATE, 2);

                    if (txtFreight_Charges.Text != "")
                    {
                    }
                    else
                    {
                        txtFreight_Charges.Text = Convert.ToString(cal1);
                    }
                }
            }
            else
            {

                if (txtFreight_Exch_Rate.Text != "" && txtInvoiceCurrency.Text != "" && txtFreight_Exch_Rate.Text != "")
                {
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
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void TextCopy()
    {
        try
        {
            lblInvoiceNo.Text = txtInvoiceNo.Text;
            lblInvoiceDate.Text = txtDate.Text;
            lblInvoiceCurrency.Text = txtInvoiceCurrency.Text.ToUpper();
            lblInvoiceTerms.Text = ddlTerms.SelectedValue.ToString();
            lblInvoiceValue.Text = txtInvoiceValue.Text;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    public void get_Textboxvalue()
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

    }
    public void Terms_Change_SingleInvoice()
    {
        try
        {
            if (ddlTerms.SelectedValue == "FOB")
            {
                txtFreight_Exch_Rate.Enabled = true;
                txtFreight_Currency.Enabled = true;
                txtFreight_Rate.Enabled = true;
                txtInsurance_Exch_Rate.Enabled = true;
                txtInsurance_Currency.Enabled = true;
                txtInsurance_Rate.Enabled = true;
            }
            else if (ddlTerms.SelectedValue == "CI")
            {
                txtFreight_Exch_Rate.Enabled = true;
                txtFreight_Currency.Enabled = true;

                txtInsurance_Exch_Rate.Enabled = false;
                txtInsurance_Currency.Enabled = false;
                txtInsurance_Rate.Enabled = false;
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

                txtInsurance_Exch_Rate.Enabled = true;
                txtInsurance_Currency.Enabled = true;
                txtInsurance_Rate.Enabled = true;
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
                txtInsurance_Exch_Rate.Enabled = false;
                txtInsurance_Currency.Enabled = false;
                txtInsurance_Rate.Enabled = false;
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    public void Invoice_Updation(string sno)
    {
        try
        {
            if (chkMisc.Checked == true)
            {

                chkMisc.Checked = true;
                chkMisc.Enabled = true;
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
                get_Textboxvalue();
                Terms_Change_Updating_MultiInvoice();
                pnl_Multi_Invoice.Enabled = true;
                tag_Totalfrieght.Style.Add("display", "none");
                tag_TotalInsurance.Style.Add("display", "none");
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    public void Invoice_Updation1(string sno)
    {
        try
        {
            if (chkMisc.Checked == true)
            {
                DivFreight.Style.Add("display", "block");
                DivInsurance.Style.Add("display", "block");

                chkMisc.Checked = true;
                chkMisc.Enabled = true;
                if (Int32.Parse(sno) == 1)
                {
                    chkMisc.Enabled = true;
                    ddlTerms.Enabled = true;

                    Chk_Misc.Enabled = true;
                    CHKHSS.Enabled = true;

                    txtTotal_Frieght.Enabled = true;
                    txtTotal_Insurance.Enabled = true;

                    if (ViewState["CHKF_F"] != null && ViewState["CHKF_F"] != string.Empty && ViewState["CHKI_I"] != null && ViewState["CHKI_I"] != string.Empty)
                    {
                        if (ViewState["CHKF_F"].ToString() == "Amt")
                        {
                            tag_Totalfrieght.Style.Add("display", "block");
                        }
                        else if (ViewState["CHKF_F"].ToString() == "Rate")
                        {
                            tag_Totalfrieght.Style.Add("display", "none");
                        }
                        if (ViewState["CHKI_I"].ToString() == "Amt")
                        {
                            tag_TotalInsurance.Style.Add("display", "block");
                        }
                        else if (ViewState["CHKI_I"].ToString() == "Rate")
                        {
                            tag_TotalInsurance.Style.Add("display", "none");
                        }
                    }

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

                    txtTotal_Frieght.Enabled = false;
                    txtTotal_Insurance.Enabled = false;
                    txtFreight_Charges.Enabled = false;
                    txtInsurance_Charges.Enabled = false;
                    pnl_Multi_Invoice.Enabled = false;
                    txtTotal_Frieght.Text = hdn_Total_Freight_Value.Value;
                    txtTotal_Insurance.Text = hdn_Total_Insurance_Value.Value;


                }
                get_Textboxvalue();
                Terms_Change_Updating_MultiInvoice();

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
                tag_Totalfrieght.Visible = false;
                tag_TotalInsurance.Visible = false;

                DivFreight.Style.Add("display", "none");
                DivInsurance.Style.Add("display", "none");

                txtTotal_Frieght.Text = hdn_Total_Freight_Value.Value;
                txtTotal_Insurance.Text = hdn_Total_Insurance_Value.Value;

                txtTotal_Frieght.Enabled = false;
                txtTotal_Insurance.Enabled = false;

                txtFreight_Charges.Visible = true;
                txtInsurance_Charges.Visible = true;
                txtFreight_Charges.Enabled = false;
                txtInsurance_Charges.Enabled = false;

                get_Textboxvalue();
                Terms_Change_Updating_MultiInvoice();
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
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
    [System.Web.Services.WebMethod]
    public static string GetExchange_Rate_Invoice_Cur(string custid)
    {
        try
        {
            if (custid.Length == 3)
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Ename = "EXCHANGE_MASTER_RATE_IMPORTWISE";
                Auto.Enamesearch = custid;
                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString() + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " ";
                }
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
    public static string GetExchange_Rate(string custid)
    {
        try
        {
            if (custid.Length == 3)
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Ename = "EXCHANGE_MASTER_RATE_IMPORTWISE";
                Auto.Enamesearch = custid;
                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString() + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " ";

                }
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
    public static string GetSupplier(string custid, string Imp_Name, string Supplier_Brslno)
    {
        string COMPANY_IDD = Connection.COMPANYID();
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        DataSet ds_2 = new DataSet();

        string txt_supplier_name = string.Empty, ALL_Item = string.Empty, Connect = string.Empty, txtSVB_RefNo = string.Empty, SVB_CustomHouse = string.Empty, LoadingOn = string.Empty
            , txtAssesable_Rate = string.Empty, txtDuty_Rate = string.Empty, Ass_Status = string.Empty, Duty_Status = string.Empty, svb_date = string.Empty, Buyer_Seller_Relation = string.Empty;


        txt_supplier_name = custid.Replace("'", "''");
        Auto.Ename = "SUPPLIER_MASTER_BR_SLNO_SEARCH";
        Auto.Enamesearch = custid;
        Auto.NSearch = Supplier_Brslno;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string SUP_NAME = ds.Tables[0].Rows[0]["SUP_NAME"].ToString();
            string SUP_BRANCH_SLNO = ds.Tables[0].Rows[0]["SUP_BRANCH_SLNO"].ToString();
            string SUP_ADD1 = ds.Tables[0].Rows[0]["SUP_ADD1"].ToString();
            string SUP_ADD2 = ds.Tables[0].Rows[0]["SUP_ADD2"].ToString();
            string SUP_ADD3 = ds.Tables[0].Rows[0]["SUP_ADD3"].ToString();
            string SUP_COUNTRY_NAME = ds.Tables[0].Rows[0]["SUP_COUNTRY_NAME"].ToString();
            string SUP_COUNTRY_CODE = ds.Tables[0].Rows[0]["SUP_COUNTRY_CODE"].ToString();
            string SUP_PIN_CODE = ds.Tables[0].Rows[0]["SUP_PIN_CODE"].ToString();
            Connect = SUP_NAME + "~~" + SUP_BRANCH_SLNO + "~~" + SUP_ADD1 + "~~" + SUP_ADD2 + "~~" + SUP_ADD3 + "~~" + SUP_COUNTRY_NAME + "~~" + SUP_COUNTRY_CODE + "~~" + SUP_PIN_CODE;
        }
        else
        {
            Connect = "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "";
        }
        //if (Imp_Name != null && Imp_Name != "" && (COMPANY_IDD == "1" || COMPANY_IDD == "1532"))
        //{
        //    Connect += "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "";
        //}

        if (Imp_Name != null && Imp_Name != "")
        {

            Svb_Relation SVR = new Svb_Relation();
            SVR.SVB_ID_N = "";
            SVR.flag = "Select_all";
            ds_2 = SVR.SVB_Select();
            string importer_name = Imp_Name;

            DataView view1 = ds_2.Tables[0].DefaultView;
            view1.RowFilter = "IMP_NAME = '" + importer_name + "'  and " + "SUPPLIER_NAME = '" + txt_supplier_name + "'";

            DataTable table1 = view1.ToTable();
            DataSet dss1 = new DataSet();
            dss1.Tables.Add(table1);

            bool Is_Avail = false;
            DataSet dss2 = new DataSet();
            DataTable dt_SVB = new DataTable();

            if (dss1.Tables[0].Rows.Count > 0)
            {
                if (dss1.Tables[0].Rows.Count == 1)
                {
                    Is_Avail = true;
                    dt_SVB = dss1.Tables[0];
                }
            }

            if (Is_Avail == false)
            {
                if (dss1.Tables[0].Rows.Count == 0)
                {
                    string SVB_APPLICABLE_ALL_SUPP = "Y";
                    DataView view2 = ds_2.Tables[0].DefaultView;
                    view2.RowFilter = "IMP_NAME = '" + importer_name + "'  and " + "SVB_APPLICABLE_ALL_SUPP = '" + SVB_APPLICABLE_ALL_SUPP + "'";

                    DataTable table2 = view2.ToTable();

                    dss2.Tables.Add(table2);

                    if (dss2.Tables[0].Rows.Count > 0)
                    {
                        if (dss2.Tables[0].Rows.Count == 1)
                        {
                            Is_Avail = true;
                            dt_SVB = dss2.Tables[0];
                        }
                    }
                }
            }

            if (Is_Avail == true)
            {
                string chksvb = dt_SVB.Rows[0]["SVB_RELATION"].ToString();

                txtSVB_RefNo = dt_SVB.Rows[0]["SVB_REF_NO"].ToString();
                SVB_CustomHouse = dt_SVB.Rows[0]["SVB_CUSTOM_HOUSE"].ToString();
                LoadingOn = dt_SVB.Rows[0]["SVB_LOADING_ON"].ToString();
                Buyer_Seller_Relation = dt_SVB.Rows[0]["RELATION"].ToString();

                svb_date = dt_SVB.Rows[0]["SVB_REF_DATE"].ToString();

                string load_on = "";
                if (LoadingOn == "A")
                {
                    load_on = "Assessable";
                }
                else if (LoadingOn == "D")
                {
                    load_on = "Duty";
                }
                else if (LoadingOn == "B")
                {
                    load_on = "Both";
                }

                txtAssesable_Rate = dt_SVB.Rows[0]["SVB_ASSESABLE_RATE"].ToString();
                txtDuty_Rate = dt_SVB.Rows[0]["SVB_DUTY_RATE"].ToString();

                Ass_Status = dt_SVB.Rows[0]["SVB_ASSESABLE_STATUS"].ToString();
                string assesable = "";
                if (Ass_Status == "P")
                {
                    assesable = "Provisional";
                }
                else if (Ass_Status == "F")
                {
                    assesable = "Final";
                }

                Duty_Status = dt_SVB.Rows[0]["SVB_DUTY_STATUS"].ToString();

                string duty_status = "";
                if (Duty_Status == "P")
                {
                    duty_status = "Provisional";

                }
                else if (Duty_Status == "F")
                {
                    duty_status = "Final";
                }
                string BOND_NO = "", BOND_LOCATION = "", BOND_TYPE = "";
                if (assesable == "Provisional" || duty_status == "Provisional")
                {
                    BOND_NO = dt_SVB.Rows[0]["BOND_NO"].ToString();
                    BOND_LOCATION = dt_SVB.Rows[0]["BOND_LOCATION"].ToString();
                    BOND_TYPE = dt_SVB.Rows[0]["BOND_TYPE"].ToString();
                }
                Connect += "~~" + chksvb + "~~" + txtSVB_RefNo + "~~" + SVB_CustomHouse + "~~" + load_on + "~~" + txtAssesable_Rate + "~~" + txtDuty_Rate + "~~" + assesable + "~~" + duty_status + "~~" + svb_date + "~~" + BOND_NO + "~~" + BOND_LOCATION + "~~" + BOND_TYPE + "~~" + Buyer_Seller_Relation;
            }



            if (Is_Avail == false)
            {
                Connect += "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "";
            }


            /*
            if (dss1.Tables[0].Rows.Count > 0)
            {
                if (dss1.Tables[0].Rows.Count == 1)
                {
                    string chksvb = dss1.Tables[0].Rows[0]["SVB_RELATION"].ToString();

                    txtSVB_RefNo = dss1.Tables[0].Rows[0]["SVB_REF_NO"].ToString();
                    SVB_CustomHouse = dss1.Tables[0].Rows[0]["SVB_CUSTOM_HOUSE"].ToString();
                    LoadingOn = dss1.Tables[0].Rows[0]["SVB_LOADING_ON"].ToString();
                    Buyer_Seller_Relation = dss1.Tables[0].Rows[0]["RELATION"].ToString();

                    svb_date = dss1.Tables[0].Rows[0]["SVB_REF_DATE"].ToString();

                    string load_on = "";
                    if (LoadingOn == "A")
                    {
                        load_on = "Assessable";
                    }
                    else if (LoadingOn == "D")
                    {
                        load_on = "Duty";
                    }
                    else if (LoadingOn == "B")
                    {
                        load_on = "Both";
                    }

                    txtAssesable_Rate = dss1.Tables[0].Rows[0]["SVB_ASSESABLE_RATE"].ToString();
                    txtDuty_Rate = dss1.Tables[0].Rows[0]["SVB_DUTY_RATE"].ToString();

                    Ass_Status = dss1.Tables[0].Rows[0]["SVB_ASSESABLE_STATUS"].ToString();
                    string assesable = "";
                    if (Ass_Status == "P")
                    {
                        assesable = "Provisional";
                    }
                    else if (Ass_Status == "F")
                    {
                        assesable = "Final";
                    }

                    Duty_Status = dss1.Tables[0].Rows[0]["SVB_DUTY_STATUS"].ToString();

                    string duty_status = "";
                    if (Duty_Status == "P")
                    {
                        duty_status = "Provisional";

                    }
                    else if (Duty_Status == "F")
                    {
                        duty_status = "Final";
                    }
                    string BOND_NO = "", BOND_LOCATION = "", BOND_TYPE = "";
                    if (assesable == "Provisional" || duty_status == "Provisional")
                    {
                        BOND_NO = dss1.Tables[0].Rows[0]["BOND_NO"].ToString();
                        BOND_LOCATION = dss1.Tables[0].Rows[0]["BOND_LOCATION"].ToString();
                        BOND_TYPE = dss1.Tables[0].Rows[0]["BOND_TYPE"].ToString();
                    }
                    Connect += "~~" + chksvb + "~~" + txtSVB_RefNo + "~~" + SVB_CustomHouse + "~~" + load_on + "~~" + txtAssesable_Rate + "~~" + txtDuty_Rate + "~~" + assesable + "~~" + duty_status + "~~" + svb_date + "~~" + BOND_NO + "~~" + BOND_LOCATION + "~~" + BOND_TYPE + "~~" + Buyer_Seller_Relation;
                }
                else
                {
                    Connect += "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "";
                }
            }
            else
            {
                Connect += "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "" + "~~" + "";
            }

            */
        }
        return Connect;
    }
    //----------------------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------------------

    [System.Web.Services.WebMethod]
    public static string GetSeller(string custid)
    {
        try
        {

            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
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
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string GetBroker(string custid)
    {
        try
        {

            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
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

           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;

    }



    [System.Web.Services.WebMethod]
    public static string GetFreight_Currency_value(string txtFreight_Currency, string txtInvoiceCurrency, string txtInvoiceValue, string freight_charge, string txtFreight_Exch_Rate, string Freight_rate, string txtMiscellaneous_Charges, string txtMiscellaneous_Currency, string Terms, string Handling_Charges, string Loading_Charges, string UnLoading_Charges, string Type, string Inv_Exrate, string txt_INV_MISC_Charges, string chk_active_Inv_Misc, string txt_INV_MISC_Currency, string txtMiscellaneous_Exch_Rate)
    {
        try
        {
            string Working_Period = "", MISC_EXRATE = "", CURRENCY_CODE = "", hdn_currency = "", txtFreight_Charges = "", Miscellaneous_exrate = "0", IsValidCurr = "";
            double cal = 0, cal1 = 0;
            Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
            double MISC = 0;
            adminmaster erm = new adminmaster();
            //string Freight_rate = "20";
            DataSet dss = new DataSet();
            erm.Invoice_Currency = txtFreight_Currency;
            erm.Ename = "IMPORT_INVOICE_EX_RATE";
            erm.EWorking_Period = Working_Period;
            dss = erm.RetrieveAll_Exchange_master_INV_Currency();
            if (dss.Tables[0].Rows.Count > 0)
            {
                MISC_EXRATE = dss.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
                CURRENCY_CODE = dss.Tables[0].Rows[0]["EXCHANGE_CUR_CODE"].ToString();
                IsValidCurr = "Yes";
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
                    IsValidCurr = "Yes";
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

            if (txtMiscellaneous_Currency != "")
            {
                erm.Invoice_Currency = txtMiscellaneous_Currency;
                erm.Ename = "IMPORT_INVOICE_EX_RATE";
                erm.EWorking_Period = Working_Period;
                dss = erm.RetrieveAll_Exchange_master_INV_Currency();
                if (dss.Tables[0].Rows.Count > 0)
                {
                    Miscellaneous_exrate = dss.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
                }
                else
                {
                    dss.Clear();
                    Auto_Search Auto = new Auto_Search();
                    Auto.Ename = "NON_STD_CUR_RATE_IMPORTWISE";
                    Auto.Enamesearch = txtInvoiceCurrency;
                    dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        Miscellaneous_exrate = dss.Tables[0].Rows[0]["NON_STD_RATE_IMPORT"].ToString();
                    }
                }
            }

            string INVMISC = "";
            if (Freight_rate != "" && Freight_rate != "." && Freight_rate != "0" && Freight_rate != "0.00")
            {
                if (txtFreight_Currency.ToUpper() == CURRENCY_CODE)
                {
                    if (hdn_currency != "")
                    {
                        //double Invoice_Currency_Exrate = Convert.ToDouble(hdn_currency);

                        double Invoice_Currency_Exrate = 0;
                        Invoice_Currency_Exrate = Convert.ToDouble(Inv_Exrate);

                        //if (Connection.COMPANYID() == "293" || Connection.COMPANYID() == "1051" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "4")
                        //{
                        if (txtInvoiceCurrency.ToUpper() == "JPY" || txtInvoiceCurrency.ToUpper() == "KRW")
                        {
                            Invoice_Currency_Exrate = Convert.ToDouble(Invoice_Currency_Exrate) / 100;
                        }

                        if (txtInvoiceCurrency.ToUpper() == "INR")
                        {
                            invoicevalue = invoicevalue;
                        }
                        else
                        {
                            invoicevalue = invoicevalue * Convert.ToDouble(Invoice_Currency_Exrate);
                        }

                        if (txtMiscellaneous_Currency.ToUpper() != txtInvoiceCurrency.ToUpper())
                        {
                            if (txtMiscellaneous_Currency.ToUpper() == "INR")
                            {
                                MISC = Convert.ToDouble(txtMiscellaneous_Charges == string.Empty ? "0" : txtMiscellaneous_Charges);
                            }
                            else
                            {
                                //MISC = Convert.ToDouble(txtMiscellaneous_Charges == string.Empty ? "0" : txtMiscellaneous_Charges) * Invoice_Currency_Exrate;
                                //MISC = Convert.ToDouble(txtMiscellaneous_Charges == string.Empty ? "0" : txtMiscellaneous_Charges) * Convert.ToDouble(Miscellaneous_exrate);

                                if (txtMiscellaneous_Currency == txt_INV_MISC_Currency)
                                {
                                    MISC = (Convert.ToDouble(txtMiscellaneous_Charges == string.Empty ? "0" : txtMiscellaneous_Charges) + Convert.ToDouble(txt_INV_MISC_Charges == string.Empty ? "0" : txt_INV_MISC_Charges)) * Convert.ToDouble(txtMiscellaneous_Exch_Rate);
                                }
                                else
                                {
                                    double misc_calc1 = ((Convert.ToDouble(txt_INV_MISC_Charges == string.Empty ? "0" : txt_INV_MISC_Charges) * Invoice_Currency_Exrate) / Convert.ToDouble(txtMiscellaneous_Exch_Rate));

                                    misc_calc1 = Convert.ToDouble(txtMiscellaneous_Charges == string.Empty ? "0" : txtMiscellaneous_Charges) + misc_calc1;
                                    MISC = misc_calc1 * Convert.ToDouble(txtMiscellaneous_Exch_Rate);
                                }
                            }
                        }
                        else
                        {
                            //MISC = Convert.ToDouble(txtMiscellaneous_Charges == string.Empty ? "0" : txtMiscellaneous_Charges) * Invoice_Currency_Exrate;
                            MISC = (Convert.ToDouble(txtMiscellaneous_Charges == string.Empty ? "0" : txtMiscellaneous_Charges) + Convert.ToDouble(txt_INV_MISC_Charges == string.Empty ? "0" : txt_INV_MISC_Charges)) * Invoice_Currency_Exrate;
                        }

                        double INVOICE_MISC_VAL = 0.00;

                        //if (chk_active_Inv_Misc != "T")
                        //{
                        //    INVOICE_MISC_VAL = invoicevalue + MISC;
                        //}
                        //else
                        //{
                        //    if (txt_INV_MISC_Charges != "")
                        //    {
                        //        INVOICE_MISC_VAL = invoicevalue + (Convert.ToDouble(txt_INV_MISC_Charges == string.Empty ? "0" : txt_INV_MISC_Charges) * Invoice_Currency_Exrate);
                        //    }
                        //}

                        INVOICE_MISC_VAL = invoicevalue + MISC;

                        if (Terms == "CI")
                        {
                            if (Handling_Charges != "" || Loading_Charges != "" || UnLoading_Charges != "")
                            {
                                double Other_MISC = (Convert.ToDouble(Handling_Charges == string.Empty ? "0" : Handling_Charges) + Convert.ToDouble(Loading_Charges == string.Empty ? "0" : Loading_Charges) + Convert.ToDouble(UnLoading_Charges == string.Empty ? "0" : UnLoading_Charges)) * Invoice_Currency_Exrate;
                                INVMISC = Convert.ToString(INVOICE_MISC_VAL + Other_MISC);
                            }
                        }
                        else
                        {
                            INVMISC = Convert.ToString(INVOICE_MISC_VAL);
                        }

                        //double INVOICE_VALUE_INR = ((Convert.ToDouble(INVMISC) * Convert.ToDouble(Freight_rate == string.Empty ? "0.00" : Freight_rate) / 100) * Invoice_Currency_Exrate);

                        double INVOICE_VALUE_INR = 0.00;
                        if (Freight_rate != ".")
                        {
                            INVOICE_VALUE_INR = ((Convert.ToDouble(INVMISC) * Convert.ToDouble(Freight_rate == string.Empty ? "0.00" : Freight_rate) / 100));
                        }
                        if (txtFreight_Currency.ToUpper() == "INR")
                        {
                            /*
                            double Calc1 = ((Convert.ToDouble(INVMISC) * Convert.ToDouble(Freight_rate == string.Empty ? "0.00" : Freight_rate) / 100) * Invoice_Currency_Exrate);
                            txtFreight_Charges = Convert.ToString(Math.Round(Convert.ToDouble(Calc1), 2));
                             */
                            txtFreight_Charges = Convert.ToString(Math.Round(Convert.ToDouble(INVOICE_VALUE_INR), 2));
                        }
                        else
                        {
                            if (Freight_rate != ".")
                            {
                                if (txtFreight_Currency.ToUpper() == "JPY" || txtFreight_Currency.ToUpper() == "KRW")
                                {
                                    /*
                                    double Calc1 = ((Convert.ToDouble(INVMISC) * Convert.ToDouble(Freight_rate == string.Empty ? "0.00" : Freight_rate) / 100) * Invoice_Currency_Exrate);
                                    //Calc1 = (Calc1 / (Convert.ToDouble(MISC_EXRATE) / 100));
                                    Calc1 = (Calc1 / (Convert.ToDouble(txtFreight_Exch_Rate) / 100));
                                    txtFreight_Charges = Convert.ToString(Math.Round(Convert.ToDouble(Calc1), 2));
                                     */
                                    if (Type == "EX_RATE")
                                    {
                                        double Calc1 = (INVOICE_VALUE_INR / (Convert.ToDouble(MISC_EXRATE) / 100));
                                        txtFreight_Charges = Convert.ToString(Math.Round(Convert.ToDouble(Calc1), 2));
                                    }
                                    else
                                    {
                                        double Calc1 = (INVOICE_VALUE_INR / (Convert.ToDouble(txtFreight_Exch_Rate) / 100));
                                        txtFreight_Charges = Convert.ToString(Math.Round(Convert.ToDouble(Calc1), 2));
                                    }
                                }
                                else
                                {
                                    /*
                                    double Calc1 = ((Convert.ToDouble(INVMISC) * Convert.ToDouble(Freight_rate == string.Empty ? "0.00" : Freight_rate) / 100));
                                    txtFreight_Charges = Convert.ToString(Math.Round(Convert.ToDouble(Calc1), 2));
                                     */
                                    if (Type == "EX_RATE")
                                    {
                                        double Calc1 = INVOICE_VALUE_INR / (Convert.ToDouble(MISC_EXRATE));
                                        txtFreight_Charges = Convert.ToString(Math.Round(Convert.ToDouble(Calc1), 2));
                                    }
                                    else
                                    {
                                        double Calc1 = INVOICE_VALUE_INR / (Convert.ToDouble(txtFreight_Exch_Rate));
                                        txtFreight_Charges = Convert.ToString(Math.Round(Convert.ToDouble(Calc1), 2));
                                    }
                                }
                            }
                        }
                        //}

                        /* hide by chithra on 09-01-2019 sugg by bala sir - for FRT & INS add with MISC value - OLD CONDITION
                        else
                        {
                            //if (txtInvoiceCurrency.Text == "INR" && txtFreight_Currency.Text == "USD")
                            //{
                            //cal = ((invoicevalue * 20 / 100) * Invoice_Currency_Exrate);
                            cal = ((invoicevalue * 20 / 100) * Invoice_Currency_Exrate);
                            double EXRATE = Convert.ToDouble(MISC_EXRATE);
                            string rate = Convert.ToString(EXRATE);
                            rate.Substring(0, 1);
                            if (rate != "0")
                                cal1 = Math.Round(cal / EXRATE, 2);

                            //txtFreight_Charges = Convert.ToString(cal1);

                            if (Convert.ToDecimal(freight_charge == "" ? "0" : freight_charge) <= 0)
                            {
                                txtFreight_Charges = Convert.ToString(cal1);
                            }

                            else if (Convert.ToDecimal(freight_charge == "" ? "0" : freight_charge) > 0)
                            {
                                txtFreight_Charges = Convert.ToString(cal1);
                            }
                        }
                    */
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

                        //txtFreight_Charges = Convert.ToString(cal);

                        if (Convert.ToDecimal(freight_charge == "" ? "0" : freight_charge) <= 0)
                        {
                            txtFreight_Charges = Convert.ToString(cal1);
                        }

                        //if (Convert.ToDecimal(freight_charge) <= 0)
                        //{
                        //    txtFreight_Charges = Convert.ToString(cal1);
                        //}

                        MISC_EXRATE = txtFreight_Exch_Rate;
                        //txtDiscount_Exch_Rate.Text = txtFreight_Exch_Rate.Text;
                        //txtFreight_Exch_Rate.Text = txtFreight_Exch_Rate.Text;
                        //txtInsurance_Exch_Rate.Text = txtFreight_Exch_Rate.Text;
                    }
                }
            }

            txtFreight_Currency = txtFreight_Charges + "~~" + hdn_currency + "~~" + MISC_EXRATE + "~~" + Type + "~~" + IsValidCurr;

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.ToString());
        }
        return txtFreight_Currency;
    }

    [System.Web.Services.WebMethod]
    public static string GetInsurance_Currency_value(string txtInsurance_Currency, string txtInvoiceCurrency, string txtInvoiceValue, string insurance_charge, string txtInsurance_Exch_Rate, string Insurance_rate, string txtMiscellaneous_Charges, string txtMiscellaneous_Currency, string Terms, string Handling_Charges, string Loading_Charges, string UnLoading_Charges, string Type, string Inv_Exrate, string txt_INV_MISC_Charges, string chk_active_Inv_Misc, string txt_INV_MISC_Currency, string txtMiscellaneous_Exch_Rate)
    {
        try
        {
            string Working_Period = "", MISC_EXRATE = "", CURRENCY_CODE = "", hdn_currency = "", txtInsurance_Charges = "", Miscellaneous_exrate = "0", IsValidCurr = "";
            double cal = 0, cal1 = 0, MISC = 0;

            Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
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
                IsValidCurr = "Yes";

            }
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
                    IsValidCurr = "Yes";
                }

            }
            double invoicevalue = 0;
            if (txtInvoiceValue != "")
            {
                invoicevalue = Convert.ToDouble(txtInvoiceValue);
                erm.Invoice_Currency = txtInvoiceCurrency;
                erm.Ename = "IMPORT_INVOICE_EX_RATE";
                erm.EWorking_Period = Working_Period;
                dss = erm.RetrieveAll_Exchange_master_INV_Currency();
                if (dss.Tables[0].Rows.Count > 0)
                {
                    hdn_currency = dss.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
                }
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
            }

            if (txtMiscellaneous_Currency != "")
            {
                erm.Invoice_Currency = txtMiscellaneous_Currency;
                erm.Ename = "IMPORT_INVOICE_EX_RATE";
                erm.EWorking_Period = Working_Period;
                dss = erm.RetrieveAll_Exchange_master_INV_Currency();
                if (dss.Tables[0].Rows.Count > 0)
                {
                    Miscellaneous_exrate = dss.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
                }
                else
                {
                    dss.Clear();
                    Auto_Search Auto = new Auto_Search();
                    Auto.Ename = "NON_STD_CUR_RATE_IMPORTWISE";
                    Auto.Enamesearch = txtInvoiceCurrency;
                    dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        Miscellaneous_exrate = dss.Tables[0].Rows[0]["NON_STD_RATE_IMPORT"].ToString();
                    }
                }
            }

            string INVMISC = "";

            if (Insurance_rate != "" && Insurance_rate != "." && Insurance_rate != "0" && Insurance_rate != "0.00")
            {
                if (txtInsurance_Currency.ToUpper() == CURRENCY_CODE)
                {
                    if (hdn_currency != "")
                    {
                        double Invoice_Currency_Exrate = 0;
                        Invoice_Currency_Exrate = Convert.ToDouble(Inv_Exrate);


                        //if (Connection.COMPANYID() == "293" || Connection.COMPANYID() == "1051" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "4")
                        //{

                        if (txtInvoiceCurrency.ToUpper() == "JPY" || txtInvoiceCurrency.ToUpper() == "KRW")
                        {
                            Invoice_Currency_Exrate = Convert.ToDouble(Invoice_Currency_Exrate) / 100;
                        }

                        if (txtInvoiceCurrency.ToUpper() == "INR")
                        {
                            invoicevalue = invoicevalue;
                        }
                        else
                        {

                            invoicevalue = invoicevalue * Convert.ToDouble(Invoice_Currency_Exrate);
                        }


                        if (txtMiscellaneous_Currency.ToUpper() != txtInvoiceCurrency.ToUpper())
                        {
                            if (txtMiscellaneous_Currency.ToUpper() == "INR")
                            {
                                MISC = Convert.ToDouble(txtMiscellaneous_Charges == string.Empty ? "0" : txtMiscellaneous_Charges);
                            }
                            else
                            {
                                //MISC = Convert.ToDouble(txtMiscellaneous_Charges == string.Empty ? "0" : txtMiscellaneous_Charges) * Invoice_Currency_Exrate;

                                //this line hide by Chithra on 01-02-2020 for INV_MISC SPLIT Calc - agility
                                //MISC = Convert.ToDouble(txtMiscellaneous_Charges == string.Empty ? "0" : txtMiscellaneous_Charges) * Convert.ToDouble(Miscellaneous_exrate);

                                if (txtMiscellaneous_Currency == txt_INV_MISC_Currency)
                                {
                                    MISC = (Convert.ToDouble(txtMiscellaneous_Charges == string.Empty ? "0" : txtMiscellaneous_Charges) + Convert.ToDouble(txt_INV_MISC_Charges == string.Empty ? "0" : txt_INV_MISC_Charges)) * Convert.ToDouble(txtMiscellaneous_Exch_Rate);
                                }
                                else
                                {
                                    double misc_calc1 = ((Convert.ToDouble(txt_INV_MISC_Charges == string.Empty ? "0" : txt_INV_MISC_Charges) * Invoice_Currency_Exrate) / Convert.ToDouble(txtMiscellaneous_Exch_Rate));

                                    misc_calc1 = Convert.ToDouble(txtMiscellaneous_Charges == string.Empty ? "0" : txtMiscellaneous_Charges) + misc_calc1;
                                    MISC = misc_calc1 * Convert.ToDouble(txtMiscellaneous_Exch_Rate);
                                }
                            }
                        }
                        else
                        {
                            //MISC = Convert.ToDouble(txtMiscellaneous_Charges == string.Empty ? "0" : txtMiscellaneous_Charges) * Invoice_Currency_Exrate;
                            MISC = (Convert.ToDouble(txtMiscellaneous_Charges == string.Empty ? "0" : txtMiscellaneous_Charges) + Convert.ToDouble(txt_INV_MISC_Charges == string.Empty ? "0" : txt_INV_MISC_Charges)) * Invoice_Currency_Exrate;
                        }

                        double INVOICE_MISC_VAL = 0.00;
                        //INVOICE_MISC_VAL = invoicevalue + (Convert.ToDouble(txt_INV_MISC_Charges == string.Empty ? "0" : txt_INV_MISC_Charges) * Invoice_Currency_Exrate);

                        //if (chk_active_Inv_Misc != "T")
                        //{
                        //    INVOICE_MISC_VAL = invoicevalue + MISC;
                        //}
                        //else
                        //{
                        //    if (txt_INV_MISC_Charges != "")
                        //    {
                        //        INVOICE_MISC_VAL = invoicevalue + (Convert.ToDouble(txt_INV_MISC_Charges == string.Empty ? "0" : txt_INV_MISC_Charges) * Invoice_Currency_Exrate);
                        //    }
                        //}

                        INVOICE_MISC_VAL = invoicevalue + MISC;

                        if (Terms == "CI")
                        {
                            if (Handling_Charges != "" || Loading_Charges != "" || UnLoading_Charges != "")
                            {
                                double Other_MISC = (Convert.ToDouble(Handling_Charges == string.Empty ? "0" : Handling_Charges) + Convert.ToDouble(Loading_Charges == string.Empty ? "0" : Loading_Charges) + Convert.ToDouble(UnLoading_Charges == string.Empty ? "0" : UnLoading_Charges)) * Invoice_Currency_Exrate;
                                INVMISC = Convert.ToString(INVOICE_MISC_VAL + Other_MISC);
                            }
                        }
                        else
                        {
                            INVMISC = Convert.ToString(INVOICE_MISC_VAL);
                        }

                        //double INVOICE_VALUE_INR = ((Convert.ToDouble(INVMISC) * Convert.ToDouble(Insurance_rate == string.Empty ? "0.00" : Insurance_rate) / 100) * Invoice_Currency_Exrate);
                        double INVOICE_VALUE_INR = 0.00;
                        if (Insurance_rate != ".")
                        {
                            INVOICE_VALUE_INR = ((Convert.ToDouble(INVMISC) * Convert.ToDouble(Insurance_rate == string.Empty ? "0.00" : Insurance_rate) / 100));
                        }

                        if (txtInsurance_Currency.ToUpper() == "INR")
                        {
                            if (Insurance_rate != ".")
                            {
                                /*
                                double Calc1 = ((Convert.ToDouble(INVMISC) * Convert.ToDouble(Insurance_rate == string.Empty ? "0.00" : Insurance_rate) / 100) * Invoice_Currency_Exrate);
                                txtInsurance_Charges = Convert.ToString(Math.Round(Convert.ToDouble(Calc1), 2));
                                 */
                                txtInsurance_Charges = Convert.ToString(Math.Round(Convert.ToDouble(INVOICE_VALUE_INR), 2));
                            }
                        }
                        else
                        {
                            if (Insurance_rate != ".")
                            {
                                if (txtInsurance_Currency.ToUpper() == "JPY" || txtInsurance_Currency.ToUpper() == "KRW")
                                {
                                    /*
                                    double Calc1 = ((Convert.ToDouble(INVMISC) * Convert.ToDouble(Insurance_rate == string.Empty ? "0.00" : Insurance_rate) / 100) * Invoice_Currency_Exrate);
                                    //Calc1 = Calc1 / (Convert.ToDouble(MISC_EXRATE) / 100);
                                    Calc1 = Calc1 / (Convert.ToDouble(txtInsurance_Exch_Rate) / 100);
                                    txtInsurance_Charges = Convert.ToString(Math.Round(Convert.ToDouble(Calc1), 2));
                                     */
                                    if (Type == "EX_RATE")
                                    {
                                        //double Calc1 = INVOICE_VALUE_INR / (Convert.ToDouble(MISC_EXRATE) / 100);--01/02/2020
                                        double Calc1 = INVOICE_VALUE_INR * (Convert.ToDouble(MISC_EXRATE) / 100);
                                        txtInsurance_Charges = Convert.ToString(Math.Round(Convert.ToDouble(Calc1), 2));
                                    }
                                    else
                                    {
                                        //double Calc1 = INVOICE_VALUE_INR / (Convert.ToDouble(txtInsurance_Exch_Rate) / 100);--01/02/2020
                                        double Calc1 = INVOICE_VALUE_INR * (Convert.ToDouble(txtInsurance_Exch_Rate) / 100);
                                        txtInsurance_Charges = Convert.ToString(Math.Round(Convert.ToDouble(Calc1), 2));
                                    }
                                }
                                else
                                {
                                    /*
                                    double Calc1 = ((Convert.ToDouble(INVMISC) * Convert.ToDouble(Insurance_rate == string.Empty ? "0.00" : Insurance_rate) / 100));
                                    txtInsurance_Charges = Convert.ToString(Math.Round(Convert.ToDouble(Calc1), 2));
                                    */
                                    if (Type == "EX_RATE")
                                    {
                                        //if (MISC_EXRATE != "")
                                        //{
                                        double Calc1 = INVOICE_VALUE_INR / (Convert.ToDouble(MISC_EXRATE));
                                        txtInsurance_Charges = Convert.ToString(Math.Round(Convert.ToDouble(Calc1), 2));
                                        //}
                                    }
                                    else
                                    {
                                        double Calc1 = INVOICE_VALUE_INR / (Convert.ToDouble(txtInsurance_Exch_Rate));
                                        txtInsurance_Charges = Convert.ToString(Math.Round(Convert.ToDouble(Calc1), 2));
                                    }
                                }
                            }
                        }
                        //}
                        /* hide by chithra on 01-09-2017 sugg by Bala sir for FRT & INS add with Misc value - OLD CONDITION
                        else
                        {
                            cal = ((invoicevalue * Convert.ToDouble(Insurance_rate) / 100) * Invoice_Currency_Exrate);
                            double EXRATE = Convert.ToDouble(MISC_EXRATE = MISC_EXRATE == "" ? "0" : MISC_EXRATE);
                            string rate = Convert.ToString(EXRATE);
                            rate.Substring(0, 1);
                            if (rate != "0")
                                cal1 = Math.Round(cal / EXRATE, 2);
                            if (Convert.ToDecimal(insurance_charge == "" ? "0" : insurance_charge) <= 0)
                            {
                                txtInsurance_Charges = Convert.ToString(cal1);
                            }
                            else if (Convert.ToDecimal(insurance_charge == "" ? "0" : insurance_charge) > 0)
                            {
                                txtInsurance_Charges = Convert.ToString(cal1);
                            }
                        }
                        */
                    }
                }
                else
                {

                    if (txtInsurance_Exch_Rate != "" && txtInvoiceCurrency != "")
                    {
                        double invoicevalue1 = Convert.ToDouble(txtInvoiceValue);
                        double Invoice_Currency_Exrate = Convert.ToDouble(txtInsurance_Exch_Rate);
                        cal = invoicevalue * 20 / 100;
                        if (Convert.ToDecimal(insurance_charge == "" ? "0" : insurance_charge) <= 0)
                        {
                            txtInsurance_Charges = Convert.ToString(cal1);
                        }
                        MISC_EXRATE = txtInsurance_Exch_Rate;
                    }
                }
            }
            txtInsurance_Currency = txtInsurance_Charges + "~~" + hdn_currency + "~~" + MISC_EXRATE + "~~" + Type + "~~" + IsValidCurr;

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.ToString());
        }
        return txtInsurance_Currency;
    }


    [System.Web.Services.WebMethod]
    public static string Get_Imp_ThirdParty(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "IMP_THIRDPARTY_MASTER_SEARCH";
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
                string Related_YN = ds.Tables[0].Rows[0]["BUYER_RELATED_Y_N"].ToString();

                custid = ThirdParty_Name + "~~" + Address1 + "~~" + Address2 + "~~" + City + "~~" + SubDivision + "~~" + CountryCode + "~~" + Pin + "~~" + TermsPlace + "~~" + AEO_CODE + "~~" + AEO_COUNTRY + "~~" + AEO_ROLE + "~~" + Related_YN;
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    public string Get_Scheme_Code(string scheme)
    {
        try
        {
            adm.SCHEME_IMPORT_CODE = scheme;
            adm.SCHEME_NOTN = "0";
            adm.name = "SCHEME_IMPORT_CODE";

            ds_scheme = adm.RetrieveAll_Scheme_Import();
            if (ds_scheme.Tables[2].Rows.Count > 0)
            {
                scheme = ds_scheme.Tables[2].Rows[0]["SCHEME_CODE"].ToString();
            }

           
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
        return scheme;
    }

    private void CHK_True_False()
    {
        try
        {
            if (chkMisc.Checked == true)
            {
                Div_open_close();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

    }

    private void Div_open_close()
    {
        try
        {
            if (ddlTerms.SelectedItem.Text == "FOB")
            {
                DivFreight.Style.Add("display", "block");
                DivInsurance.Style.Add("display", "block");
            }
            else if (ddlTerms.SelectedItem.Text == "CF")
            {
                DivFreight.Style.Add("display", "none");
                DivInsurance.Style.Add("display", "block");
            }
            if (ddlTerms.SelectedItem.Text == "CI")
            {
                DivFreight.Style.Add("display", "block");
                DivInsurance.Style.Add("display", "none");
            }
            if (ddlTerms.SelectedItem.Text == "CIF")
            {
                DivFreight.Style.Add("display", "none");
                DivInsurance.Style.Add("display", "none");
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
                //---------------------this line hide by Chithra on 21-11-2019 for Direct Exbond inv slno Bind-----------------------------
                //this.gv_Invoice.SelectedIndex = Convert.ToInt32(ddlInv_SL_No.SelectedValue.ToString()) - 1; // here index getting minus from invslno
                //-------------------------------------------------------------------------------------------------------------------------

                this.gv_Invoice.SelectedIndex = Convert.ToInt32(ddlInv_SL_No.SelectedIndex);
                gv_Invoice_SelectedIndexChanged(this.gv_Invoice, new EventArgs());
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void btn_svb_update_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtSVB_RefNo.Text != "")
            {
                btn_svb_update.Visible = true;

                Transact.JOBNO = IMPORT_JOBNO;
                Transact.INVOICE_NO = "";
                Transact.TERMS = "";
                Transact.INVOICE_SLNO = Session["INV_SLNO"].ToString();
                Transact.WORKING_PERIOD = SELECT_BRANCH;
                Transact.flag = "Update_SVB_All_Invoices";

                ds = Transact.RetrieveAll_Invoice_Details();
                int ii = Transact.result;

                if (ii == 1)
                {
                    Alert_msg("SVB Updated to All Invoices");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "svb_update_Msg()", true);
                }
            }
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
            ES.E_logic_Update(Session["IMPORT_JOBNO"].ToString(), "I", "U");
            */
            Connection.e_lOGIX("I", "U");
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
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.flag = "Item_Count";
            dc = Transact.RetrieveAll_Invoice_Details();

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

    public void Bind_InvSl_No_MAX()
    {
        try
        {
            DataSet ds_inv = new DataSet();
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.flag = "Get_InvoiceSlno_MAX";
            ds_inv = Transact.RetrieveAll_Invoice_Details();

            if (ds_inv.Tables[0].Rows.Count > 0)
            {
                txt_InvoiceSlno.Text = ds_inv.Tables[0].Rows[0]["MAX_INV_SLNO"].ToString();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public string Check_Inv_Slno_Avail(string flag, string ID)
    {
        try
        {
            DataSet ds_avail = new DataSet();
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = txt_InvoiceSlno.Text;
            Transact.INVOICE_NO = ID;

            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.flag = flag;
            ds_avail = Transact.RetrieveAll_Invoice_Details();

            if (ds_avail.Tables[0].Rows.Count > 0)
            {
                Inv_Avail = ds_avail.Tables[0].Rows[0]["Avail_Result"].ToString();
            }

            if (ds_avail.Tables[1].Rows.Count > 0)
            {
                hdn_Invoice_mode_singlr_or_multi.Value = ds_avail.Tables[1].Rows[0]["MIS_SINGLE_OR_MULITIPLE"].ToString();
                if (hdn_Invoice_mode_singlr_or_multi.Value == "T")
                {
                    ViewState["CHKF_F"] = ds_avail.Tables[1].Rows[0]["MI_FREIGHT"].ToString();
                    ViewState["CHKI_I"] = ds_avail.Tables[1].Rows[0]["MI_INSURANCE"].ToString();
                    ViewState["CHK_HSS"] = ds_avail.Tables[1].Rows[0]["MI_HSS"].ToString();
                    ViewState["CHK_MISC"] = ds_avail.Tables[1].Rows[0]["MI_MISC"].ToString();
                }
            }
           
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
        return Inv_Avail;
    }

    protected void btn_Update_Supplier_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlInv_SL_No.SelectedValue != "" && txtSupplierName.Text != "")
            {
                DataSet ds_inv = new DataSet();
                int result = 0;
                Transact.JOBNO = IMPORT_JOBNO;
                Transact.INVOICE_NO = txtSupplierName.Text;
                Transact.INVOICE_SLNO = ddlInv_SL_No.SelectedValue;
                Transact.WORKING_PERIOD = SELECT_BRANCH;
                Transact.flag = "Update_Manufacturer_from_Supplier";
                ds_inv = Transact.RetrieveAll_Invoice_Details();
                result = Transact.result;
                if (result == 1)
                {
                    Alert_msg("Manufacturer - Updated Successfully..");
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
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
                Auto.Ename = "IMPORT_DUPLICATE_INVOICENO";
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

    [System.Web.Services.WebMethod]
    public static string Set_Customs_House_Validation(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();

            Auto.Enamesearch = custid;
            Auto.Ename = "CUSTOM_HOUSE_MASTER";
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = "Yes";
            }
            else
            {
                custid = "No";
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }



    private string Get_ClientMaster_Insurance_details(string IMP_NAME, string BR_SLNO, string IEC_NO)
    {
        eroyalmaster erm = new eroyalmaster();
        DataSet dtt_clnt = new DataSet();
        string Ins_Rate = "1.1250";
        string Nature_Trans = "S Sale";
        string Nature_Payment = "OTH Others";
        string Valuation_Method = "Rule 4 - Transaction Value";

        try
        {
            erm.Eimp_exp_id = "";
            erm.Eimp_exp_name = IMP_NAME;
            erm.Eimp_exp_iecno = IEC_NO;
            erm.Eimp_exp_brslno = BR_SLNO;
            erm.Ename = "Get_Client_InsuraceRate";
            erm.EWorking_Period = Working_Period;

            dtt_clnt = erm.RetrieveAll_Imp_exp_master_STD_TYPE();

            if (dtt_clnt.Tables[0].Rows.Count > 0)
            {
                Ins_Rate = dtt_clnt.Tables[0].Rows[0]["CLIENT_INSURANCE_RATE"].ToString();
                Nature_Trans = dtt_clnt.Tables[0].Rows[0]["NATURE_OF_TRANS"].ToString();
                Nature_Payment = dtt_clnt.Tables[0].Rows[0]["NATURE_OF_PAYMENT"].ToString();
                Valuation_Method = dtt_clnt.Tables[0].Rows[0]["VALUATION_METHOD"].ToString();

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
        return Ins_Rate + "~" + Nature_Trans + "~" + Nature_Payment + "~" + Valuation_Method;
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

    
    private void Tbl_Filed_Modified_History(DataTable dt_Curr_tbl_struct)
    {
        try
        {
            ViewState["dt_Prev_Table"] = dt_Curr_tbl_struct;
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
            Dt_Change.GetMismatchedRowsFast(dt_Prev, dt_modified, "INVOICE_SLNO", "Invoice", IMPORT_JOBNO, _slno, "", currentuser, currentbranch);
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
            dr["JOBNO"] = IMPORT_JOBNO;
            dr["INVOICE_SLNO"] = ddlInv_SL_No.SelectedValue;// _slno;
            dr["ITEM_SLNO"] = "";
            dr["INVOICE_NO"] = txtInvoiceNo.Text;
            dr["INVOICE_DATE"] = txtDate.Text;
            dr["TERMS"] = ddlTerms.SelectedItem.Text;
            dr["INVOICE_CURRENCY"] = txtInvoiceCurrency.Text;
            dr["INVOICE_EXRATE"] = txtExRate.Text;
            dr["INVOICE_VALUE"] = txtInvoiceValue.Text;

            // ===== SUPPLIER =====
            dr["SUPPLIER_NAME"] = txtSupplierName.Text;
            dr["SUPPLIER_ADDRESS"] = txtSupplierAddress.Text;
            dr["SUPPLIER_ADDRESS1"] = txtSupplierAddress1.Text;
            dr["SUPPLIER_ADDRESS2"] = txtSupplierAddress2.Text;
            dr["SUPPLIER_COUNTRY_NAME"] = txtSupplierCountryName.Text;
            dr["SUPPLIER_COUNTRY_PINCODE"] = txtSuppliercountry_pincode.Text;
            dr["SUPPLIER_BRANCH_SLNO"] = txtSupplier_Branch_Slno.Text;

            // ===== SELLER =====
            dr["SELLER_NAME"] = txtSellerName.Text;
            dr["SELLER_ADDRESS"] = txtSellerAddress.Text;
            dr["SELLER_ADDRESS1"] = txtSellerAddress1.Text;
            dr["SELLER_ADDRESS2"] = txtSellerAddress2.Text;
            dr["SELLER_COUNTRY_NAME"] = txtSellerCountryName.Text;
            dr["SELLERCOUNTRY_PINCODE"] = txtSellercountry_pincode.Text;

            // ===== BROKER =====
            dr["BROKER_NAME"] = txtBrokerName.Text;
            dr["BROKER_ADDRESS"] = txtBrokerAddress.Text;
            dr["BROKER_ADDRESS1"] = txtBrokerAddress1.Text;
            dr["BROKER_ADDRESS2"] = txtBrokerAddress2.Text;
            dr["BROKER_COUNTRY_NAME"] = txtBrokerCountryName.Text;
            dr["BROKER_COUNTRY_PINCODE"] = txtbrokercountry_pincode.Text;

            // ===== MIS =====
            dr["MIS_CURRENCY"] = txtMiscellaneous_Currency.Text;
            dr["MIS_EXRATE"] = txtMiscellaneous_Exch_Rate.Text;
            dr["MIS_RATE"] = txtMiscellaneous_Rate.Text;
            dr["MIS_CHARGES"] = txtMiscellaneous_Charges.Text;

            // ===== INV MISC =====
            dr["INV_MISC_CURRENCY"] = txt_INV_MISC_Currency.Text;
            dr["INV_MISC_EXRATE"] = txt_INV_MISC_Exch_Rate.Text;
            dr["INV_MISC_CHARGES"] = txt_INV_MISC_Charges.Text;
            dr["INV_MISC_TOTAL_CHARGES"] = txt_INV_MISC_Total_Charge.Text;

            // ===== AGENCY =====
            dr["MIS_AGENCY_CHARGES"] = txtAgency_Charges.Text;
            dr["MIS_AGENCY_RATE"] = txtAgency_Rate.Text == "0.00" ? string.Empty : txtAgency_Rate.Text;
            dr["MIS_AGENCY_CURRENCY"] = txtAgency_Currency.Text;
            dr["MIS_AGENCY_EXRATE"] = txtAgency_Exch_Rate.Text;

            // ===== DISCOUNT =====
            dr["MIS_DISCOUNT_CHARGES"] = txtDiscount_Charges.Text;
            dr["MIS_DISCOUNT_RATE"] = txtDiscount_Rate.Text;
            dr["MIS_DISCOUNT_CURRENCY"] = txtDiscount_Currency.Text;
            dr["MIS_DISCOUNT_EXRATE"] = txtDiscount_Exch_Rate.Text;
            dr["MIS_DISCOUNT_REASON"] = "";

            // ===== LOADING =====
            dr["MIS_LOADING_CURRENCY"] = txtLoading_Currency.Text;
            dr["MIS_LOADING_EXRATE"] = txtLoading_ExchRate.Text == "0.00" ? string.Empty : txtLoading_ExchRate.Text;
            dr["MIS_LOADING_RATE"] = txtLoading_Rate.Text == "0.00" ? string.Empty : txtLoading_Rate.Text;
            dr["MIS_LOADING_CHARGES"] = txtLoading_Charges.Text;

            // ===== FREIGHT =====
            dr["MIS_FREIGHT_CURRENCY"] = txtFreight_Currency.Text;
            dr["MIS_FREIGHT_EXRATE"] = txtFreight_Exch_Rate.Text;
            dr["MIS_FREIGHT_RATE"] = txtFreight_Rate.Text;
            dr["MIS_FREIGHT_CHARGES"] = txtFreight_Charges.Text;

            // ===== INSURANCE =====
            dr["MIS_INSURANCE_CHARGES"] = txtInsurance_Charges.Text;
            dr["MIS_INSURANCE_RATE"] = txtInsurance_Rate.Text;
            dr["MIS_INSURANCE_CURRENCY"] = txtInsurance_Currency.Text;
            dr["MIS_INSURANCE_EXRATE"] = txtInsurance_Exch_Rate.Text;

            // ===== HIGH SEA SALE =====
            dr["MIS_HIGHSEASALE_CURRENCY"] = txtHighSeaSale_Currency.Text;
            dr["MIS_HIGHSEASALE_EXRATE"] = txtHighSeaSale_Exch_Rate.Text;
            dr["MIS_HIGHSEASALE_RATE"] = txtHighSeaSale_Rate.Text == "0.00" ? string.Empty : txtHighSeaSale_Rate.Text;
            dr["MIS_HIGHSEASALE_CHARGES"] = txtHighSeaSale_Charges.Text;

            // ===== SVB =====
            dr["SVB_REF_NO"] = txtSVB_RefNo.Text;
            dr["SVB_REF_DATE"] = txtSVBDate.Text;
            dr["SVB_CUSTOM_HOUSE"] = txtCustomsHouse.Text;
            dr["SVB_LOADING_ON"] = ddlLoadingOn.SelectedValue;
            dr["SVB_ASSESABLE_RATE"] = txtAssesable_Rate.Text;
            dr["SVB_ASSESABLE_STATUS"] = ddlAssesable_Status.SelectedValue;
            dr["SVB_DUTY_RATE"] = txtDuty_Rate.Text;
            dr["SVB_DUTY_STATUS"] = ddlDuty_Status.SelectedValue;

            // ===== OTHER DETAILS =====
            dr["OTHER_PURCHASE_ORDER"] = txtPurchaseOrderNo.Text;
            dr["OTHER_PURCHASE_ORDER_DATE"] = txtPurchaseDate.Text;
            dr["OTHER_CONTRACT_NO"] = txtContractNo.Text;
            dr["OTHER_CONTRACT_DATE"] = txtContractDate.Text;
            dr["OTHER_LOC_NO"] = txtLCNo.Text;
            dr["OTHER_LOC_DATE"] = txtLCDate.Text;
            dr["OTHER_NATURE_OF_TRANSACTION"] = ddlNatureOfTrans.SelectedItem.Text;
            dr["OTHER_TERMS_OF_PAYMENT"] = ddlNatureOfPayment.SelectedItem.Text;
            dr["OTHER_CONDITIONS"] = txtConditions.Text;
            dr["OTHER_VALUATION_METHOD"] = ddlValuationMethod.SelectedItem.Text;

            // ===== SHIPMENT =====
            dr["SAP_DELIEVERY_ID"] = txtSAP_Delievery_ID.Text;
            dr["SHIP_DATE"] = txtShip_Date.Text;
            dr["INVOICE_LEVEL"] = txtInvoice_Level.Text;
            dr["COUNTRY_OF_DEPARTURE"] = txtCountry_Departure.Text;
            dr["DOC_RECD_DATE"] = txt_DocRecd_Date.Text;

            // ===== THIRD PARTY =====
            dr["THIRDPARTY_NAME"] = txt_ThirdPartyName.Text;
            dr["THIRDPARTY_ADD1"] = txt_ThirdParty_Add1.Text;
            dr["THIRDPARTY_ADD2"] = txt_ThirdParty_Add2.Text;
            dr["THIRDPARTY_CITY"] = txt_ThirdParty_City.Text;
            dr["T_PARTY_COUNTRY_SUB_DIV"] = txt_Country_Division.Text;
            dr["T_PARTY_COUNTRY_CODE"] = txt_CountryCode.Text;
            dr["T_PARTY_PIN"] = txt_ThirdParty_Pin.Text;

            // ===== AEO =====
            dr["TERMS_PLACE"] = txt_TermsPlace.Text;
            dr["AUTHORIZED_ECONOMIC_OPERATOR_CODE"] = txt_Authrzd_Economic_Code.Text;
            dr["A_E_O_COUNTRY"] = txt_Authrzd_Economic_Country.Text;
            dr["AUTHORIZED_ECONOMIC_OPERATOR"] = txt_Authrzd_Economic_Role.Text;
            dr["WHETHER_BUYER_SELLER_RELATED"] = txt_Whether_Relater_Y_N.Text;

            // ===== AMOUNTS =====
            dr["D_AMOUNT"] = txt_Handling_Charges.Text;
            dr["M_AMOUNT"] = txt_Loading_Charges.Text;
            dr["N_AMOUNT"] = txt_UnLoading_Charges.Text;

            // ===== REVENUE =====
            dr["REVENUEDEPOSIT_RATE"] = txtRevenue_Deposit.Text;
            dr["REVENUEDEPOSIT_ON"] = ddlRevenueDeposit_On.SelectedItem.Text;

            // ===== ADD ROW =====
            dt_mapping.Rows.Add(dr);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }
 

}
    
