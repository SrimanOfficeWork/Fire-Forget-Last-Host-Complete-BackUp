using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;
using System.IO;
using System.Text;
using System.Xml;
using System.Linq;
using System.Threading;

public partial class Transaction_Item_Details : ThemeClass
{
    Date_Time Rep = new Date_Time();
    Product_Import_Master product = new Product_Import_Master();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();
    AppSession aps = new AppSession();
    Manipulation mo = new Manipulation();
    User_Creation user_Create = new User_Creation();
    ErrorLogs er = new ErrorLogs();

    DataTable dt = new DataTable();

    DataSet ds = new DataSet();
    DataSet dss = new DataSet();
    DataSet dss1 = new DataSet();
    DataSet dt_Item_all = new DataSet();

    public int Screen_Id, i;

    public string a1, a2, a3, a4, a5, a6, a7, IMPORT_JOBNO, REIMPORT_ID, FLAG, YEAR, SB_Date, Previous_Be_Date
    , ITEM_ID = "", ITEM_SLNO = "", INVOICE_SLNO = "", INVOICE_NO = "", COUNTRY_OF_ORIGIN, Schemecode = "", EXBOND_DIRECT_EXBONDING = "", Item_Avail = "", Audit_YN = "";

    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, Is_NewItem = "", SELECT_BRANCH, JOB_LOCK, JOB_RELEASE, COMPANY_IDD, currentuser;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            SELECT_BRANCH = Connection.Get_Company_Type();
            currentuser = Connection.Current_User();
            COMPANY_IDD = Connection.COMPANYID();
            hdn_Company_IDD.Value = COMPANY_IDD;


            txtItem_UnitPriceCode.Text = txtItem_AmountCode.Text;
            txtDescription.Focus();
            Call_Server_Side_Method();

            //value rest problem when use ajax cascadedropdown// 

            Session.Remove("ddlSchemeCode");
            Session.Remove("ddlScheme_NOTN");
            Session.Remove("ddlScheme_NOTN_SL");
            //value rest problem when use ajax cascadedropdown// 

            txtCountryOrigin.Attributes.Add("onblur", "javascript:Call_CountryOrigin('" + txtCountryOrigin.ClientID + "')");
            txtCountryOrigin.Attributes.Add("onkeyup", "javascript:Call_CountryOrigin('" + txtCountryOrigin.ClientID + "')");


            txt_manu_Transit_Country.Attributes.Add("onblur", "javascript:Call_Transit_CountryCode('" + txt_manu_Transit_Country.ClientID + "')");
            txt_manu_Transit_Country.Attributes.Add("onkeyup", "javascript:Call_Transit_CountryCode('" + txt_manu_Transit_Country.ClientID + "')");

            txt_Manu_Source_Country.Attributes.Add("onblur", "javascript:Call_Source_CountryCode('" + txt_Manu_Source_Country.ClientID + "')");
            txt_Manu_Source_Country.Attributes.Add("onkeyup", "javascript:Call_Source_CountryCode('" + txt_Manu_Source_Country.ClientID + "')");

            txt_Manufacturer_Country.Attributes.Add("onblur", "javascript:Call_Manu_CountryCode('" + txt_Manufacturer_Country.ClientID + "')");
            txt_Manufacturer_Country.Attributes.Add("onkeyup", "javascript:Call_Manu_CountryCode('" + txt_Manufacturer_Country.ClientID + "')");
            if (!Page.IsPostBack)
            {
                if (Session["BQ_Item_slno"] != null)
                {
                    Session.Remove("BQ_Item_slno");
                }
            }

            // Added by Pandiyan on 13-08-2025 for Enduse of item from client master (requested by Niyas & Bala)
            //if (Session["IMPORT_JOBNO"] != null && (COMPANY_IDD == "480" || COMPANY_IDD == "1011" || COMPANY_IDD == "1019" || COMPANY_IDD == "1176" || COMPANY_IDD == "3037"))
            //{
                if (string.IsNullOrEmpty(txtEndUse.Text))
                {
                    IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
                    Transact.JOBNO = IMPORT_JOBNO;
                    Transact.WORKING_PERIOD = SELECT_BRANCH;
                    Transact.Ename = "select_Item_Enduse";

                    dss = Transact.RetrieveAll_Item_Details();

                    if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                    {
                        txtEndUse.Text = Convert.ToString(dss.Tables[0].Rows[0][0]);
                    }
                    else
                    {
                        txtEndUse.Text = "";
                    }
                }
            //}
            //End

            if (Session["IMPORT_JOBNO"] != null)
            {
                IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
                hdn_Jobno.Value = IMPORT_JOBNO;
                Session.Remove("Invoice_SLNO");
                Session.Remove("ITEM_SLNO");
                Session.Remove("Invoice_NO");
                hdn_Exbond_Val.Value = Session["BE_TYPE"].ToString();

                if (hdn_Exbond_Val.Value == "Ex-Bond" || hdn_Exbond_Val.Value == "SEZ DTA-T")
                {
                    if (!String.IsNullOrEmpty(Session["EXBOND_DIRECT_EXBONDING"] as string))
                    {
                        hdn_Direct_Exbond_YN.Value = Session["EXBOND_DIRECT_EXBONDING"].ToString();

                        if (hdn_Direct_Exbond_YN.Value == "Y")
                        {
                            lbl_Item_Slno_Dis.Visible = false;
                            txt_ItemSlno.Visible = true;
                            editbu.Style.Add("display", "none");
                            txt_ItemSlno.Focus();
                        }
                        else
                        {
                            lbl_Item_Slno_Dis.Visible = true;
                            txt_ItemSlno.Visible = false;
                            editbu.Style.Add("display", "block");
                        }
                    }
                    else
                    {
                        lbl_Item_Slno_Dis.Visible = true;
                        txt_ItemSlno.Visible = false;
                        editbu.Style.Add("display", "block");
                    }
                }
                else
                {
                    lbl_Item_Slno_Dis.Visible = true;
                    txt_ItemSlno.Visible = false;
                    editbu.Style.Add("display", "block");
                }

                if (!IsPostBack)
                {
                    COUNTRY_OF_ORIGIN = Convert.ToString(Session["COUNTRY_OF_ORIGIN"]);
                    txtCountryOrigin.Text = COUNTRY_OF_ORIGIN;
                    hdn_chk_country.Value = Check_CountryName(txtCountryOrigin.Text, "COUNTRY_OF_ORIGIN");
                    //hdn_chk_Transit_country.Value = Check_CountryName(txt_manu_Transit_Country.Text,"TRANSIT_COUNTRY");
                    //hdn_chk_Source_country.Value = Check_CountryName(txt_Manu_Source_Country.Text, "SOURCE_COUNTRY");
                    //hdn_chk_Manu_country.Value = Check_CountryName(txt_Manufacturer_Country.Text, "M_P_GROWER_COUNTRY");

                    hdfTransport_mode.Value = "";
                    txt_Social_Welfare_Rate.Text = "10.00";
                }

                hdn_chk_Transit_country.Value = Check_CountryName(txt_manu_Transit_Country.Text, "TRANSIT_COUNTRY");
                hdn_chk_Source_country.Value = Check_CountryName(txt_Manu_Source_Country.Text, "SOURCE_COUNTRY");
                hdn_chk_Manu_country.Value = Check_CountryName(txt_Manufacturer_Country.Text, "M_P_GROWER_COUNTRY");
                hdn_txtEndUse.Value = Check_EndUseCode(txtEndUse.Text);
                btnupdateProduct.Visible = true;
            }
            else
            {
                Response.Write("<script>window.parent.document.getElementById('General').click();</script>");
            }

            /*
            if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "116" || Connection.COMPANYID() == "233" || Connection.COMPANYID() == "280" || Connection.COMPANYID() == "744" || Connection.COMPANYID() == "751" || Connection.COMPANYID() == "846" || Connection.COMPANYID() == "921" || Connection.COMPANYID() == "1120" || Connection.COMPANYID() == "1142" || Connection.COMPANYID() == "1644" || Connection.COMPANYID() == "1658" || Connection.COMPANYID() == "2038")
            {
                tag_transac_lft_Trans_item_Cth12.Visible = true;//Additional Duty for HPCl Client
                tag_transac_lft_Trans_item_Cth_ExcAidc.Visible = true;
            }
            else
            {
                tag_transac_lft_Trans_item_Cth12.Visible = false;
                tag_transac_lft_Trans_item_Cth_ExcAidc.Visible = false;
            }
             * */

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

            if (Connection.Get_User_Imp_Settings_Job_Edit("ITEM_ADDL_DUTY_IMPORTS") == "E")
            {
                tag_transac_lft_Trans_item_Cth12.Visible = true;//Additional Duty for HPCl Client
                tag_transac_lft_Trans_item_Cth_ExcAidc.Visible = true;
            }


            hdn_GeneralDescSame.Value = Connection.Get_User_Imp_Settings_Job_Edit("GENERAL_DESC_SAME_AS_ITEM_DESC");



            if (Connection.COMPANYID() == "125")
            {
                Fairmax_125.Visible = true;
            }
            if (!IsPostBack)
            {
                //ddlSchemeCode.Attributes.Add("onchange", "javascript:change();");

              

                Load_RSP_Applicability();

                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 7;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                txtItem_AmountCode.Attributes.Add("readonly", "readonly");
                txtItem_UnitPriceCode.Attributes.Add("readonly", "readonly");

                txtRSP_Slno.Text = "1";
                btnSave.Visible = true;
                btn_save_new.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnupdateProduct.Visible = true;

                ///----------------- PRODUCT WINDOW OPEN --------------------------//

                if (!string.IsNullOrEmpty(Request["INVOICE_SLNO_ID"]))
                {

                    string INV_SLNO = Request["INVOICE_SLNO_ID"].ToString();
                    //Dropdown_bind_Product(INV_SLNO);// hide on 29-03-2025
                    //Bind_ItemSl_No();// hide on 29-03-2025

                    Bind_Invoice_Item_Select_New("Frm_INV_Load", INV_SLNO);
                    ddlInvoice_SlNo.SelectedIndex = -1;

                    hdinvslno.Value = INV_SLNO.ToString();
                }
                else
                {
                    //Dropdown_bind();// hide on 29-03-2025
                    //Bind_ItemSl_No();// hide on 29-03-2025
                    Bind_Invoice_Item_Select_New("PageLoad", ""); //need to check
                    hdinvslno.Value = "";
                }
                ///----------------- PRODUCT WINDOW OPEN --------------------------//
                if (Transact.result == 1)
                {
                    //Invoice_Details_Bind();// hide on 29-03-2025
                    open_item.Style.Add("display", "block");
                    Is_Inv.Style.Add("display", "none");
                    Get_SchemeCode();
                    //string item_slno = "0", item_id = "0", flag = "select_con";
                    string item_slno = "0", item_id = "0", flag = "select_con_GridBind_New";

                    //Gridbind_ItemDetails(ddlInvoice_SlNo.SelectedValue.ToString(), item_slno, item_id, flag);
                    if (ddl_ItemSlno.SelectedValue != "")
                    {
                        Gridbind_ItemDetails(ddlInvoice_SlNo.SelectedValue.ToString(), ddl_ItemSlno.SelectedItem.Text, item_id, flag);
                    }
                    else
                    {
                        Gridbind_ItemDetails(ddlInvoice_SlNo.SelectedValue.ToString(), item_id, item_id, flag);
                    }

                    //Get_ProductValue();// hide on 29-03-2025
                }
                else
                {
                    Is_Inv.Style.Add("display", "block");
                    open_item.Style.Add("display", "none");
                }
                hdn_companyID.Value = COMPANY_IDD;

                if (COMPANY_IDD == "1" || COMPANY_IDD == "4" || COMPANY_IDD == "5" || COMPANY_IDD == "152")
                {
                    btnUpdate_Fairmacs.Visible = true;
                }
                else
                {
                    btnUpdate_Fairmacs.Visible = false;
                }

                if (COMPANY_IDD == "247")
                {
                    if (txtEndUse.Text == "")
                    {
                        txtEndUse.Text = "GNX200";
                        txt_Accessory_status.Text = "0";
                    }
                }

               
            }

            txtRSP_Notn_Slno.Attributes.Add("onblur", "javascript:Call_RSP_Abtt_Rate_NotnSlNo('" + txtRSP_Notn_Slno.ClientID + "', '" + txtMRP_ABT_RATE.ClientID + "')");

            txtTariff_NOTN.Attributes.Add("onblur", "javascript:Call_CTH_Tariff_NOTN('" + txtTariff_NOTN.ClientID + "', '" + txtTariff_SL.ClientID + "')");
            txtTariff_SL.Attributes.Add("onblur", "javascript:Call_CTH_Tariff_NOTN('" + txtTariff_SL.ClientID + "', '" + txtTariff_NOTN.ClientID + "')");
            txt_IGST_LEVY_EXCEPTION_NOTN.Attributes.Add("onblur", "javascript:Call_IGST_Levy_Notn_Type('" + txt_IGST_LEVY_EXCEPTION_NOTN.ClientID + "', '" + txt_IGST_LEVY_EXCEPTION_SLNO.ClientID + "')");
            //Added by pandiyan on 02/06/2025 
            txt_IGST_LEVY_EXCEPTION_CC_NOTN.Attributes.Add("onblur", "javascript:Call_IGST_Levy_Ex_Cc_Notn_Type('" + txt_IGST_LEVY_EXCEPTION_CC_NOTN.ClientID + "', '" + txt_IGST_LEVY_EXCEPTION_CC_SLNO.ClientID + "')");

            txt_AIDC_NOTN.Attributes.Add("onblur", "javascript:Call_AIDC_Notnno('" + txt_AIDC_NOTN.ClientID + "')");
            txt_AIDC_NOTN_SLNO.Attributes.Add("onblur", "javascript:Call_AIDC_NotnSlNo('" + txt_AIDC_NOTN_SLNO.ClientID + "')");


            #region SPL Type

            ddlBasicSPLTYPE.Items.Clear();
            ddlBasicSPLTYPE.Items.Add("Plus");
            ddlBasicSPLTYPE.Items.Add("Minus");
            ddlBasicSPLTYPE.Items.Add("Lower");
            ddlBasicSPLTYPE.Items.Add("Higher");

            ddlNCD_SPL_TYPE.Items.Clear();
            ddlNCD_SPL_TYPE.Items.Add("Plus");
            ddlNCD_SPL_TYPE.Items.Add("Minus");
            ddlNCD_SPL_TYPE.Items.Add("Lower");
            ddlNCD_SPL_TYPE.Items.Add("Higher");

            ddlSafeguard_SPL_TYPE.Items.Clear();
            ddlSafeguard_SPL_TYPE.Items.Add("Plus");
            ddlSafeguard_SPL_TYPE.Items.Add("Minus");
            ddlNCD_SPL_TYPE.Items.Add("Lower");
            ddlSafeguard_SPL_TYPE.Items.Add("Higher");

            ddlCVD_SPL_TYPE.Items.Clear();
            ddlCVD_SPL_TYPE.Items.Add("Plus");
            ddlCVD_SPL_TYPE.Items.Add("Minus");
            ddlCVD_SPL_TYPE.Items.Add("Lower");
            ddlCVD_SPL_TYPE.Items.Add("Higher");

            ddl_Addl_GSI_SPL_TYPE.Items.Clear();
            ddl_Addl_GSI_SPL_TYPE.Items.Add("Plus");
            ddl_Addl_GSI_SPL_TYPE.Items.Add("Minus");
            ddl_Addl_GSI_SPL_TYPE.Items.Add("Lower");
            ddl_Addl_GSI_SPL_TYPE.Items.Add("Higher");

            ddl_Addl_SHE11_Type.Items.Clear();
            ddl_Addl_SHE11_Type.Items.Add("Plus");
            ddl_Addl_SHE11_Type.Items.Add("Minus");
            ddl_Addl_SHE11_Type.Items.Add("Lower");
            ddl_Addl_SHE11_Type.Items.Add("Higher");


            ddl_Addl_TTA_Type.Items.Clear();
            ddl_Addl_TTA_Type.Items.Add("Plus");
            ddl_Addl_TTA_Type.Items.Add("Minus");
            ddl_Addl_TTA_Type.Items.Add("Lower");
            ddl_Addl_TTA_Type.Items.Add("Higher");

            ddl_Addl_Health_CESS_Type.Items.Clear();
            ddl_Addl_Health_CESS_Type.Items.Add("Plus");
            ddl_Addl_Health_CESS_Type.Items.Add("Minus");
            ddl_Addl_Health_CESS_Type.Items.Add("Lower");
            ddl_Addl_Health_CESS_Type.Items.Add("Higher");

            ddl_CESS_Type.Items.Clear();
            ddl_CESS_Type.Items.Add("Plus");
            ddl_CESS_Type.Items.Add("Minus");
            ddl_CESS_Type.Items.Add("Lower");
            ddl_CESS_Type.Items.Add("Higher");

            ddlOther_Duty_Type.Items.Clear();
            ddlOther_Duty_Type.Items.Add("Plus");
            ddlOther_Duty_Type.Items.Add("Minus");
            ddlOther_Duty_Type.Items.Add("Lower");
            ddlOther_Duty_Type.Items.Add("Higher");


            # endregion

            ViewState["Delete_ID"] = null;

            if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
            {
                JOB_LOCK = Session["JOB_LOCK"].ToString();

                if (Convert.ToInt32(JOB_LOCK) == 1)
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnNew.Enabled = false;
                    btnSave.Enabled = false;
                    btn_save_new.Enabled = false;
                    btnUp.Enabled = false;
                    btnDown.Enabled = false;
                    btnMoveup.Enabled = false;



                    btnNew.ToolTip = "This Job is Locked by Admin";
                    btnSave.ToolTip = "This Job is Locked by Admin";
                    btn_save_new.ToolTip = "This Job is Locked by Admin";
                    btnUpdate.ToolTip = "This Job is Locked by Admin";
                    btnDelete.ToolTip = "This Job is Locked by Admin";
                    btnUp.ToolTip = "This Job is Locked by Admin";
                    btnDown.ToolTip = "This Job is Locked by Admin";
                    btnMoveup.ToolTip = "This Job is Locked by Admin";
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
                            btnUp.Enabled = false;
                            btnDown.Enabled = false;
                            btnMoveup.Enabled = false;
                            //btnupdateProduct.Enabled = false;

                            MP_JOB.Show();

                            lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                            btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnDelete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnNew.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnSave.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btn_save_new.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnMoveup.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                            btnUp.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnDown.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnupdateProduct.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Bind_Invoice_Item_Select_New(string CallMode, string INV_SLNO)
    {
        try
        {
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_NO = CallMode;
            Transact.INVOICE_SLNO = INV_SLNO;
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "select_Inv_ItemDetails_New";
            dss = Transact.RetrieveAll_Item_Details();

            if (CallMode != "ddl_Change")
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    ddlInvoice_SlNo.DataSource = dss.Tables[0];
                    ddlInvoice_SlNo.DataTextField = "INVOICE_SLNO";
                    ddlInvoice_SlNo.DataValueField = "INVOICE_SLNO";
                    ddlInvoice_SlNo.Items.Add("");
                    ddlInvoice_SlNo.DataBind();
                }
            }

            if (CallMode == "Frm_INV_Load")
            {
                ddlInvoice_SlNo.Items.Remove(INV_SLNO);
                ddlInvoice_SlNo.Items.Insert(0, INV_SLNO);
            }


            if (dss.Tables[3].Rows.Count > 0)
            {
                ddl_ItemSlno.DataSource = dss.Tables[3];
                ddl_ItemSlno.DataTextField = "ITEM_SLNO";
                ddl_ItemSlno.DataValueField = "ITEM_SLNO_ID";
                ddl_ItemSlno.Items.Add("");
                ddl_ItemSlno.DataBind();
            }


            if (dss.Tables[2].Rows.Count > 0)
            {
                txtItem_AmountCode.Text = dss.Tables[1].Rows[0]["INVOICE_CURRENCY"].ToString();

                if (dss.Tables[1].Rows.Count > 0)
                {
                    if (hdn_Manufacture_Name.Value == "")
                    {
                        string Manufacturer = dss.Tables[2].Rows[0]["MANUFAC_NAME_FROM_SUP"].ToString();

                        if (Manufacturer == "Yes")
                        {
                            txtManufacturer.Text = dss.Tables[1].Rows[0]["SUPPLIER_NAME"].ToString();
                        }
                        else
                        {
                            txtManufacturer.Text = "N.A";
                        }
                    }
                    else
                    {
                        txtManufacturer.Text = hdn_Manufacture_Name.Value;
                    }
                }
                else
                {
                    if (hdn_Manufacture_Name.Value == "")
                    {
                        txtManufacturer.Text = dss.Tables[1].Rows[0]["SUPPLIER_NAME"].ToString();
                    }
                }

                txtItem_UnitPriceCode.Text = txtItem_AmountCode.Text;
                hdn_Invoice_No.Value = dss.Tables[1].Rows[0]["INVOICE_NO"].ToString();
                hdn_Invoice_Value.Value = dss.Tables[1].Rows[0]["INVOICE_VALUE"].ToString();
                lblInvoiceNo.Text = hdn_Invoice_No.Value;
                lblInvoiceValue.Text = hdn_Invoice_Value.Value;
            }
            else
                Response.Write("<script>window.parent.document.getElementById('INVOICE').click();</script>");


            if (dss.Tables[5].Rows.Count > 0)
            {
                lblProductValue.Text = dss.Tables[5].Rows[0]["TOTAL_PRODUCT_VALUE"].ToString();
            }
            else
            {
                lblProductValue.Text = "";

            }

            if (dss.Tables[6].Rows.Count > 0)
            {
                lblTotal_No_Of_Items.Text = dss.Tables[6].Rows[0]["TOTAL_NO_OF_ITEMS"].ToString();
            }
            else
            {
                lblTotal_No_Of_Items.Text = "";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void load_item_product_master(string Product)
    {
        try
        {
            txt_AIDC_NOTN.Text = "";
            txt_AIDC_NOTN_SLNO.Text = "";
            txt_AIDC_RATE.Text = "";
            txt_ADD_ExRate.Text = "";

            txt_Exc_AIDC_NOTN.Text = "";
            txt_Exc_AIDC_NOTN_SLNO.Text = "";
            txt_Exc_AIDC_RATE.Text = "";



            string[] s1 = Product.Split(new string[] { "~~" }, StringSplitOptions.None);
            txtDescription.Text = s1[94].ToString();
            txtGeneralDesc.Text = s1[0].ToString();
            txtCTHNO.Text = s1[1].ToString();
            txtCTH_No.Text = s1[3].ToString();//ritc
            txtCETH_No.Text = s1[2].ToString();
            txtRITCNO.Text = s1[3].ToString();

            txtManufacturer.Text = s1[4].ToString();
            txtBrand.Text = s1[5].ToString();
            txtModel.Text = s1[6].ToString();
            txtAccessories.Text = s1[7].ToString();
            txtEndUse.Text = s1[8].ToString();
            txtCountryOrigin.Text = s1[9].ToString();

            txtBasicNotn.Text = s1[10].ToString();
            txtBasicSLNO.Text = s1[11].ToString();
            txtBasicRate.Text = s1[12].ToString();
            txtBasicSPL.Text = s1[13].ToString();

            txtBasicUnit.Text = s1[14].ToString();
            string ddlBasicSPL = s1[15].ToString();
            ddlBasicSPLTYPE.Items.Remove(ddlBasicSPL);

            ddlBasicSPLTYPE.Items.Insert(0, ddlBasicSPL);

            txtAddlDuty_NOTN.Text = s1[16].ToString();
            txtAddlDuty_NOTN_SL.Text = s1[17].ToString();
            txtEdu_Cess_NOTN.Text = s1[18].ToString();
            txtEdu_Cess_NOTN_SL.Text = s1[19].ToString();
            txtEdu_Cess_Rate.Text = s1[20].ToString();
            txtSec_Edu_Cess_NOTN.Text = s1[21].ToString();
            txtSec_Edu_Cess_NOTN_SL.Text = s1[22].ToString();
            txtSec_Edu_Cess_Rate.Text = s1[23].ToString();

            txtNCD_NOTN.Text = s1[24].ToString();
            txtNCD_SLNO.Text = s1[25].ToString();
            txtNCD_RATE.Text = s1[26].ToString();
            txtNCD_SPL.Text = s1[27].ToString();
            txtNCD_UNIT.Text = s1[28].ToString();

            string ddlNCD_SPL = s1[29].ToString();
            ddlNCD_SPL_TYPE.Items.Remove(ddlNCD_SPL);

            ddlNCD_SPL_TYPE.Items.Insert(0, ddlNCD_SPL);
            txtAggregate_NOTN.Text = s1[30].ToString();
            txtAggregate_NOTN_SL.Text = s1[31].ToString();
            txtAggregate_RATE.Text = s1[32].ToString();
            txtSafeguard_NOTN.Text = s1[33].ToString();
            txtSafeguard_SL.Text = s1[34].ToString();
            txtSafeguard_RATE.Text = s1[35].ToString();
            txtSafeguard_SPL.Text = s1[36].ToString();
            txtSafeguard_UNIT.Text = s1[37].ToString();

            string ddlSafeguard_SPL = s1[38].ToString();
            ddlSafeguard_SPL_TYPE.Items.Remove(ddlSafeguard_SPL);

            ddlSafeguard_SPL_TYPE.Items.Insert(0, ddlSafeguard_SPL);

            string chk = s1[39].ToString();
            if (chk == "Y")
            {
                chkMRP_Duty.Checked = true;
                txtMRP_SL_NO.Enabled = true;
                txtMRP_AMOUNT.Enabled = true;
                txtMRP_ABT_RATE.Enabled = true;
                txtRSP_Notn_No.Enabled = true;
                txtRSP_Notn_Slno.Enabled = true;
                ddl_RSP_Applicable.Enabled = true;

                if (s1[94].ToString() == null || s1[94].ToString() == string.Empty)
                {
                    ddl_RSP_Applicable.SelectedValue = "N";
                }
                else
                {
                    ddl_RSP_Applicable.SelectedValue = s1[94].ToString();
                }
            }
            else
            {
                chkMRP_Duty.Checked = false;
                txtMRP_SL_NO.Enabled = false;
                txtMRP_AMOUNT.Enabled = false;
                txtMRP_ABT_RATE.Enabled = false;
                txtRSP_Notn_No.Enabled = false;
                txtRSP_Notn_Slno.Enabled = false;
                ddl_RSP_Applicable.Enabled = false;
            }
            //chkMRP_Duty=   PRODUCT_MRP_YN

            txtMRP_SL_NO.Text = s1[40].ToString();
            txtMRP_AMOUNT.Text = s1[41].ToString();
            txtMRP_ABT_RATE.Text = s1[42].ToString();

            txt_CVD_NOTN.Text = s1[43].ToString();
            txt_CVD_SLNO.Text = s1[44].ToString();
            txt_CVD_RATE.Text = s1[45].ToString();
            txt_CVD_SPL.Text = s1[46].ToString();
            txt_CVD_UNIT.Text = s1[47].ToString();

            string ddlCVD_SPL = s1[48].ToString();
            ddlCVD_SPL_TYPE.Items.Remove(ddlCVD_SPL);

            ddlCVD_SPL_TYPE.Items.Insert(0, ddlCVD_SPL);

            txt_CVD_Education_CESS_Rate.Text = s1[49].ToString();
            txt_CVD_Sec_Edu_CESS_Rate.Text = s1[50].ToString();
            txt_Addl5_SIA_NOTN.Text = s1[51].ToString();
            txt_Addl5_SIA_NOTN_SL.Text = s1[52].ToString();
            txt_Addl5_SIA_RATE.Text = s1[53].ToString();

            txt_Addl_GSI_NOTN.Text = s1[54].ToString();
            txt_Addl_GSI_SL.Text = s1[55].ToString();
            txt_Addl_GSI_RATE.Text = s1[56].ToString();
            txt_Addl_GSI_SPL.Text = s1[57].ToString();
            txt_Addl_GSI_UNIT.Text = s1[58].ToString();

            string ddl_Addl_GSI_SPL = s1[59].ToString();
            ddl_Addl_GSI_SPL_TYPE.Items.Remove(ddl_Addl_GSI_SPL);

            ddl_Addl_GSI_SPL_TYPE.Items.Insert(0, ddl_Addl_GSI_SPL);
            txt_Addl_SHE11_NOTN.Text = s1[60].ToString();
            txt_Addl_SHE11_SLNO.Text = s1[61].ToString();
            txt_Addl_SHE11_RATE.Text = s1[62].ToString();
            txt_Addl_SHE11_SPL.Text = s1[63].ToString();
            txt_Addl_SHE11_UNIT.Text = s1[64].ToString();

            string ddl_Addl_SHE11 = s1[65].ToString();
            ddl_Addl_SHE11_Type.Items.Remove(ddl_Addl_SHE11);

            ddl_Addl_SHE11_Type.Items.Insert(0, ddl_Addl_SHE11);
            txt_Addl_TTA_NOTN.Text = s1[66].ToString();
            txt_Addl_TTA_SLNO.Text = s1[67].ToString();
            txt_Addl_TTA_RATE.Text = s1[68].ToString();
            txt_Addl_TTA_SPL.Text = s1[69].ToString();
            txt_Addl_TTA_UNIT.Text = s1[70].ToString();

            string ddl_Addl_TTA = s1[71].ToString();
            ddl_Addl_TTA_Type.Items.Remove(ddl_Addl_TTA);

            ddl_Addl_TTA_Type.Items.Insert(0, ddl_Addl_TTA);

            txt_Addl_Health_CESS_NOTN.Text = s1[72].ToString();
            txt_Addl_Health_CESS_SLNO.Text = s1[73].ToString();
            txt_Addl_Health_CESS_RATE.Text = s1[74].ToString();
            txt_Addl_Health_CESS_SPL.Text = s1[75].ToString();
            txt_Addl_Health_CESS_UNIT.Text = s1[76].ToString();

            string ddl_Addl_Health_CESS = s1[77].ToString();
            ddl_Addl_Health_CESS_Type.Items.Remove(ddl_Addl_Health_CESS);

            ddl_Addl_Health_CESS_Type.Items.Insert(0, ddl_Addl_Health_CESS);

            txt_CESS_NOTN.Text = s1[78].ToString();
            txt_CESS_SLNO.Text = s1[79].ToString();
            txt_CESS_RATE.Text = s1[80].ToString();
            txt_CESS_SPL.Text = s1[81].ToString();
            txt_CESS_UNIT.Text = s1[82].ToString();

            string ddl_CESS = s1[83].ToString();
            ddl_CESS_Type.Items.Remove(ddl_CESS);

            ddl_CESS_Type.Items.Insert(0, ddl_CESS);
            txtSAPTA_NOTN.Text = s1[84].ToString();
            txtSAPTA_NOTN_SL.Text = s1[85].ToString();
            txtSAPTA_RATE.Text = s1[86].ToString();
            txtTariff_NOTN.Text = s1[87].ToString();
            txtTariff_SL.Text = s1[88].ToString();
            txtTariff_Qty.Text = s1[89].ToString();
            txtTariff_Amount.Text = s1[90].ToString();
            txtTariff_Amount_unitCode.Text = s1[91].ToString();
            txtRSP_Notn_No.Text = s1[92].ToString();
            txtRSP_Notn_Slno.Text = s1[93].ToString();

            txt_Cus_not_exe_Cen_flag.Text = s1[95].ToString();
            txt_Manufacturer_producer.Text = s1[96].ToString();
            txt_Manu_produ_grower_code.Text = s1[97].ToString();
            txt_Manufacturer_Add1.Text = s1[98].ToString();
            txt_Manufacturer_Add2.Text = s1[99].ToString();
            txt_Manufacturer_City.Text = s1[100].ToString();
            txt_Manu_Country_Subdiv.Text = s1[101].ToString();
            txt_Manufacturer_pincode.Text = s1[102].ToString();
            txt_Manufacturer_Country.Text = s1[103].ToString();
            txt_Manu_Source_Country.Text = s1[104].ToString();
            txt_manu_Transit_Country.Text = s1[105].ToString();
            txt_Accessory_status.Text = s1[106].ToString();
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
                gv_ItemDetails.ToolTip = "You don't have permission to access";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Item_Move_UpDown_Enable()
    {
        try
        {
            GridViewRow FirstRow = gv_ItemDetails.Rows[0];
            Button btnUp = (Button)FirstRow.FindControl("btnUp");
            btnUp.Enabled = false;
            GridViewRow LastRow = gv_ItemDetails.Rows[gv_ItemDetails.Rows.Count - 1];
            Button btnDown = (Button)LastRow.FindControl("btnDown");
            btnDown.Enabled = false;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Get_SchemeCode()
    {
        try
        {
            //----------------------SCHEME IMPORT MASTER-------------------------------//
            adm.SCHEME_IMPORT_CODE = "0";
            adm.SCHEME_NOTN = "0";
            adm.name = "SCHEME_IMPORT_CODE";

            //ddlSchemeCode.DataSource = 
            adm.RetrieveAll_Scheme_Import();
            ddlSchemeCode.DataSource = adm.ds.Tables[0];
            ddlSchemeCode.DataTextField = "SCHEME_CODE";
            ddlSchemeCode.DataValueField = "SCHEME_CODE";
            ddlSchemeCode.Items.Add("");
            ddlSchemeCode.DataBind();
            ddlSchemeCode.Items.Insert(0, "00 - DUTIABLE");

            //ddlSchemeCode.Items.Insert(1, "PI-Project Imports");
            //ddlSchemeCode.Items.Insert(1, "RD-RoDTEP Scheme");
            //ddlSchemeCode.Items.Insert(1, "RS-ROSL Scheme");

            //----------------------ANTI_DUMPING MASTER-------------------------------//
            /* hide on 08-05-2021 by Chithra Sugg.by Bala sir
            ddlAntiDumping_Notn.DataSource = adm.ds.Tables[1];
            ddlAntiDumping_Notn.DataTextField = "ADD_NOTN";
            ddlAntiDumping_Notn.DataValueField = "ADD_NOTN";
            ddlAntiDumping_Notn.Items.Add("");
            ddlAntiDumping_Notn.DataBind();
            ddlAntiDumping_Notn.Items.Insert(0, "");
             * */
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
            DataSet ds_product = new DataSet();
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedValue.ToString();
            Transact.ITEM_SLNO = "0";
            Transact.ITEM_ID = "0";
            //Transact.INVOICE_NO = lblInvoiceNo.Text.Replace("amp;","");
            Transact.INVOICE_NO = lblInvoiceNo.Text;
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "product_value";

            ds_product = Transact.RetrieveAll_Item_Details();

            if (Transact.TOTAL_ITEM_VALUE != "")
            {
                lblProductValue.Text = Transact.TOTAL_ITEM_VALUE;
                if (ds_product.Tables[0].Rows.Count > 0)
                {
                    lblTotal_No_Of_Items.Text = ds_product.Tables[0].Rows[0]["TOTAL_NO_OF_ITEMS"].ToString();
                }
            }
            else
            {
                lblProductValue.Text = "";
                lblTotal_No_Of_Items.Text = "";
            }
            ds_product.Dispose();
            GC.Collect();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }


    public decimal Check_Sum_Higher_Value_SaveUpdate(string Itemslno)
    {
        decimal sum_val = 0.0m;
        DataSet ds_highval = new DataSet();
        try
        {
          

            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedValue.ToString();
            Transact.ITEM_SLNO = Itemslno;
            Transact.ITEM_ID = "0";
            //Transact.INVOICE_NO = lblInvoiceNo.Text.Replace("amp;","");
            Transact.INVOICE_NO = lblInvoiceNo.Text;
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "Check_Higher_than_Value_Sum";

            ds_highval = Transact.RetrieveAll_Item_Details();

            if (ds_highval.Tables[0].Rows.Count > 0)
            {
                if (ds_highval.Tables[0].Rows[0]["prod_value"].ToString() != "")
                {
                    sum_val = Convert.ToDecimal(ds_highval.Tables[0].Rows[0]["prod_value"].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

        return sum_val;
    }


    public void Gridbind_ItemDetails(string invoice_slno, string item_slno, string item_id, string flag)
    {
        try
        {
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = invoice_slno;
            Transact.ITEM_SLNO = item_slno;
            Transact.ITEM_ID = item_id;
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = flag;
            dt_Item_all = Transact.RetrieveAll_Item_Details();
            //ViewState["dt_Item_all"] = dt_Item_all;

            if (dt_Item_all.Tables[0].Rows.Count == 0)
            {
                hdn_Grid_Count.Value = "";
                lbl_Item_Slno.Text = "1";
                lbl_Item_Slno_Dis.Text = "1" + ".";
                hdn_Grid_Count.Value = "1";
            }
            else
            {
                hdn_Manufacture_Name.Value = dt_Item_all.Tables[0].Rows[0]["MANUFACTURER"].ToString();
                hdn_Grid_Count.Value = "1";

                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    Tbl_Filed_Modified_History(dt_Item_all.Tables[1]);
                }
            }
            Grid_Empty();
            i = Transact.result;
            hdn_Grid_RowCount.Value = Convert.ToString(Transact.Gridview_Rowcount);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Item_Avail = Check_Item_Slno_Avail("Check_Item_Slno_Avail_Save", "");

            if (Item_Avail != "Exists")
            {
                hdn_FTA_Transit_chk.Value = CHK_FTA_Transit_Country(txtCountryOrigin.Text, txtBasicNotn.Text, txtSAPTA_NOTN.Text);

                if (hdn_FTA_Transit_chk.Value == "Yes")
                {
                    ViewState["Newbtn"] = "btnsave";
                    hdn_Item_Edit.Value = "";
                    string chk;
                    if (chkMRP_Duty.Checked == true)
                    {
                        chk = "Y";
                        txtMRP_SL_NO.Enabled = true;
                        txtMRP_AMOUNT.Enabled = true;
                        txtMRP_ABT_RATE.Enabled = true;
                        ddl_RSP_Applicable.Enabled = true;
                    }
                    else
                    {
                        chk = "N";
                        txtMRP_SL_NO.Enabled = false;
                        txtMRP_AMOUNT.Enabled = false;
                        txtMRP_ABT_RATE.Enabled = false;
                        ddl_RSP_Applicable.Enabled = false;
                    }
                    if (txtPrevious_Be_Date.Text == "")
                    {
                        Previous_Be_Date = "01/01/1900";
                    }
                    else
                    {
                        Previous_Be_Date = txtPrevious_Be_Date.Text;
                    }
                    a1 = "0"; a3 = chk; a4 = "S"; a5 = ""; a6 = Previous_Be_Date; a7 = "0";

                    //------------------------ this code for Direct exbond edit Item slno by Chitha on 19-11-2019------------------------------------------
                    if ((hdn_Exbond_Val.Value == "Ex-Bond" || hdn_Exbond_Val.Value == "SEZ DTA-T") && hdn_Direct_Exbond_YN.Value == "Y")
                    {
                        if (txt_ItemSlno.Text != "")
                        {
                            a7 = txt_ItemSlno.Text;
                        }
                    }
                    //----------------------------------------------------------------------------------------------------------------------
                    a2 = ddlInvoice_SlNo.SelectedValue.ToString();

                    //decimal sum = 0.0m, Totsum = 0.0m, Tally_amt = 0.4m;
                    decimal sum = 0.0m, Totsum = 0.0m, Tally_amt = 2.0m;

                    if (COMPANY_IDD == "1124")
                    {
                        Tally_amt = 50000.0m;
                    }

                    if ((hdn_Exbond_Val.Value == "Ex-Bond" || hdn_Exbond_Val.Value == "SEZ DTA-T") && hdn_Direct_Exbond_YN.Value == "Y")
                    {
                        sum = Check_Sum_Higher_Value_SaveUpdate(txt_ItemSlno.Text);
                    }
                    else
                    {
                        sum = Check_Sum_Higher_Value_SaveUpdate(lbl_Item_Slno.Text);
                    }

                    /* hide by Chithra on 18-05-2018 
                    //for (int M = 0; M < gv_ItemDetails.Rows.Count; M++)
                    //{
                    //    sum += Convert.ToDecimal(gv_ItemDetails.Rows[M].Cells[7].Text);
                    //}
                    */


                    Totsum = sum + Convert.ToDecimal(txtItem_Amount.Text);
                    decimal de = Convert.ToDecimal(lblInvoiceValue.Text);
                    txtitem_amt.Text = Totsum.ToString("0.00");
                    txtbal.Text = (Convert.ToDecimal(lblInvoiceValue.Text) - Totsum).ToString("0.00");
                    ltInv_amt.Text = de.ToString("00.00");
                    decimal bl = Convert.ToDecimal(txtbal.Text);



                    //STARCOM - higher than Invoice Value should save - don't show the alert msg - done by Chithra on 28-11-2022
                    if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "555" || Connection.COMPANYID() == "859" || Connection.COMPANYID() == "867" || Connection.COMPANYID() == "2188" || Connection.COMPANYID() == "2787" || Connection.COMPANYID() == "3431" || Connection.COMPANYID() == "4046" || Connection.COMPANYID() == "4070")
                    {
                        Totsum = Convert.ToDecimal(lblInvoiceValue.Text);
                    }

                    if (Totsum <= (Convert.ToDecimal(lblInvoiceValue.Text) + Tally_amt))
                    {
                        Item_Details_insert_update(a1, a2, a3, a4, a5, a6, a7);
                        HiddenField1.Value = Convert.ToString(Transact.UPDATE_ID);
                        ViewState["ITEM_SLNO"] = Convert.ToString(Transact.UPDATE_ITEMSLNO);
                        string inv_no = Transact.UPDATE_INVOICE_NO;
                        if (i == 1 || i == 3)
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
                                btn_save_new.Visible = false;
                                btnSave.Focus();

                                hdn_Item_Edit.Value = "U";
                                hdn_ITEM_AOUNT.Value = txtItem_Amount.Text;
                                Session.Remove("Invoice_SLNO");
                                Session.Remove("ITEM_SLNO");
                                Session.Remove("Invoice_NO");
                                Session.Remove("SCHEME_CODE");

                                Session["Invoice_NO"] = inv_no;
                                Session["Invoice_SLNO"] = a2;
                                Session["ITEM_SLNO"] = ViewState["ITEM_SLNO"].ToString();
                                //Session["Invoice_NO"] = ViewState["Invoice_NO"].ToString();
                                Session["DEBITQTY"] = txtItemQty.Text;
                                Session["UNITQTY"] = txtQtyCode.Text;
                                Session["SCHEME_CODE"] = ddlSchemeCode.SelectedValue.ToString();

                                RE_IMPORT.Visible = true;

                                //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//
                                SCHEME_BASED_VISIBLE_LICENSE(ddlSchemeCode.SelectedValue.ToString());
                                //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//

                                if (Connection.COMPANYID() == "1532")
                                {
                                    Get_Item_to_ProductMaster();
                                }

                            }
                            ViewState["UPDATED_ID"] = null;
                            if (i == 3)
                            {
                                string prompt = "<script>$(document).ready(function(){{jAlert('Higher Than Invoice Value', 'ITEM', function (r) {var i = r + 'ok';if (i == 'trueok'){jAlert('Item Saved Successfully', 'ITEM', function (r) {document.getElementById('btnSave').focus()});;} else {}});}});</script>";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                            }
                            else
                            {
                                if (bl <= Tally_amt)
                                {
                                    Alert_msg("Item Saved Successfully", "btnSave");

                                    if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "592")// For Insoorya log
                                    {
                                        Schemecode = ddlSchemeCode.SelectedValue.ToString().Substring(0, 2);
                                        if (Schemecode != "00" && Schemecode != "08" && Schemecode != "09" && Schemecode != "20" && Schemecode != "21")
                                        {
                                            ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "License();", true);
                                        }
                                    }
                                }
                                else
                                {
                                    if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00457") //----Capital Shipping on 24Apr2018
                                    {
                                        Alert_msg("Item Saved Successfully", "btnSave");
                                        //btnNew_Click(sender, e);
                                        //MPEU.Show();
                                    }
                                    else
                                    {
                                        if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "592")// For Insoorya log
                                        {
                                            Schemecode = ddlSchemeCode.SelectedValue.ToString().Substring(0, 2);
                                            if (Schemecode != "00" && Schemecode != "08" && Schemecode != "09" && Schemecode != "20" && Schemecode != "21")
                                            {
                                                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "License();", true);
                                            }
                                            else
                                            {
                                                MPEU.Show();
                                            }
                                        }
                                        else
                                        {
                                            MPEU.Show();
                                        }
                                    }
                                }
                            }
                            //-----------------------FOR USER RIGHTS--------------------------------//
                        }
                        else if (i == 2)
                        {
                            Alert_msg("Invoice No Already Exist!", "btnSave");
                        }

                        else
                        {
                            Alert_msg("Product Not Saved", "btnSave");
                        }
                        Get_ProductValue();

                        if (gv_ItemDetails.Rows.Count > 0)
                        {
                            gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                            GridViewRow saverow = gv_ItemDetails.Rows[gv_ItemDetails.Rows.Count - 1];
                            saverow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                            saverow.Font.Bold = true;
                            HDsaveid.Value = "1";
                        }
                    }
                    else
                    {
                        MP_U.Show();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>OtherDuty_tab_FTA();</script>", false);
                }
            }
            else
            {
                Alert_msg("Item Sl.No Already Exist!", "btnSave");
                txt_ItemSlno.Focus();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private string SIMS(string Ritc)
    {
        string str = string.Empty;
        DataSet dss = new DataSet();
        adminmaster Am = new adminmaster();
        try
        {
           
            Am.SCHEME_IMPORT_CODE = Ritc;
            Am.SCHEME_NOTN = Session["IMP_Job_CUSTOMHOUSE_CODE"].ToString();
            Am.name = "Select_SIMS_Department";
            dss = Am.IMP_Single_Window();
            if (dss.Tables[0].Rows.Count > 0)
            {
                str = dss.Tables[0].Rows[0][0].ToString();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
        return str;
    }

    public void Item_Details_insert_update(string a1, string a2, string a3, string a4, string a5, string a6, string a7)
    {
        try
        {
            Transact.ITEM_ID = a1;
            Transact.JOBNO = IMPORT_JOBNO; //session jobno
            Transact.INV_SLNO = a2;
            Transact.ITEM_SLNO = a7;

            Transact.ITEM_DESCRIPTION = RegExReplace(txtDescription.Text);
            Transact.ITEM_QTY = txtItemQty.Text.Trim();
            Transact.ITEM_QTY_CODE = txtQtyCode.Text;
            Transact.ITEM_UNIT_PRICE = txtItem_UnitPrice.Text.Trim();
            Transact.ITEM_UNIT_CODE = txtItem_UnitPriceCode.Text;

            Transact.ITEM_TOTAL_AMOUNT = txtItem_Amount.Text.Trim();
            Transact.ITEM_AMOUNT_CODE = txtItem_AmountCode.Text;
            Transact.CTH_NO = txtCTH_No.Text.Trim();
            Transact.FOC_ITEM = ddlFocItem.SelectedValue;// Added by pandiyan on 14-09-2026
            Transact.SCHEME_CODE = ddlSchemeCode.SelectedValue.ToString();
            Transact.SCHEME_NOTN = ddlScheme_NOTN.SelectedValue.ToString();
            Transact.SCHEME_NOTN_SLNO = ddlScheme_NOTN_SL.SelectedValue.ToString();
            Transact.CTH_QTY1 = txtCTH_Qty1.Text.Trim();
            Transact.CTH_QTY2 = txtCTH_Qty2.Text;
            Transact.CTH_QTY1_CODE = txtCTH_Qty1_Code.Text;
            Transact.CTH_QTY2_CODE = txtCTH_Qty2_Code.Text;

            Transact.GENEARL_DESCRIPTION = RegExReplace(txtGeneralDesc.Text);
            Transact.MANUFACTURER = txtManufacturer.Text;

            Transact.BRAND = txtBrand.Text;
            Transact.MODEL = txtModel.Text;
            Transact.END_USE_OF_ITEM = txtEndUse.Text.ToUpper();
            Transact.COUNTRY_OF_ORIGIN = txtCountryOrigin.Text;
            Session["ITEM_COUNTRY_OF_ORIGIN"] = txtCountryOrigin.Text;
            Transact.ACCESSORIES = txtAccessories.Text;
            Transact.PREVIOUS_BE_NO = txtPrevious_Be_No.Text;
            Transact.PREVIOUS_BE_DATE = a6;

            Transact.UNIT_PRICE = txtUnitValue.Text.Trim();
            Transact.UNIT_CODE = txtunitcode.Text;
            Transact.ITEM_CUSTOMS_HOUSE = txtCustomsHouse.Text.ToUpper();
            Transact.PRODUCT_RITC = txtRITCNO.Text;
            Transact.PRODUCT_CTH = txtCTHNO.Text;
            Transact.PRODUCT_BCD_NOTN = txtBasicNotn.Text.Trim();
            Transact.PRODUCT_BCD_SLNO = txtBasicSLNO.Text.Trim();
            Transact.PRODUCT_BCD_RATE = txtBasicRate.Text.Trim();
            Transact.PRODUCT_BCD_SPL = txtBasicSPL.Text.Trim();
            Transact.PRODUCT_BCD_UNIT = txtBasicUnit.Text;
            Transact.PRODUCT_BCD_SPL_TYPE = ddlBasicSPLTYPE.SelectedValue.ToString();
            Transact.PRODUCT_ADDL_DUTY_NOTN = txtAddlDuty_NOTN.Text.Trim();
            Transact.PRODUCT_ADDL_DUTY_NOTN_SL = txtAddlDuty_NOTN_SL.Text.Trim();
            Transact.PRODUCT_ADDL_DUTY_RATE = txtAddlDuty_Rate.Text;
            Transact.PRODUCT_EDU_CESS_NOTN = txtEdu_Cess_NOTN.Text.Trim();
            Transact.PRODUCT_EDU_CESS_NOTN_SL = txtEdu_Cess_NOTN_SL.Text.Trim();
            Transact.PRODUCT_EDU_CESS_RATE = txtEdu_Cess_Rate.Text;

            if (txtEdu_Cess_NOTN.Text == "069/2004")
            {
                txtSec_Edu_Cess_NOTN.Text = "028/2007";
                txtSec_Edu_Cess_Rate.Text = "0.00";
            }
            else
            {
                txtSec_Edu_Cess_NOTN.Text = "";
                txtSec_Edu_Cess_Rate.Text = "";
            }


            Transact.PRODUCT_SEC_EDU_CESS_NOTN = txtSec_Edu_Cess_NOTN.Text;
            Transact.PRODUCT_SEC_EDU_CESS_NOTN_SL = txtSec_Edu_Cess_NOTN_SL.Text;
            Transact.PRODUCT_SEC_EDU_CESS_RATE = txtSec_Edu_Cess_Rate.Text;
            Transact.PRODUCT_NCD_NOTN = txtNCD_NOTN.Text.Trim();

            // Transact.MIS_FREIGHT_CHARGES = txtFreight_Charges.Text;
            Transact.PRODUCT_NCD_SLNO = txtNCD_SLNO.Text.Trim();
            Transact.PRODUCT_NCD_RATE = txtNCD_RATE.Text;
            Transact.PRODUCT_NCD_SPL = txtNCD_SPL.Text;
            Transact.PRODUCT_NCD_UNIT = txtNCD_UNIT.Text;
            //Transact.MIS_INSURANCE_CHARGES = txtInsurance_Charges.Text;
            Transact.PRODUCT_NCD_SPL_TYPE = ddlNCD_SPL_TYPE.SelectedValue.ToString();
            Transact.PRODUCT_AGGREGATE_DUTY_NOTN = txtAggregate_NOTN.Text.Trim();
            Transact.PRODUCT_AGGREGATE_DUTY_NOTN_SL = txtAggregate_NOTN_SL.Text.Trim();
            Transact.PRODUCT_AGGREGATE_DUTY_NOTN_RATE = txtAggregate_RATE.Text;


            Transact.PRODUCT_SAFEGUARD_NOTN = txtSafeguard_NOTN.Text.Trim();
            Transact.PRODUCT_SAFEGUARD_SLNO = txtSafeguard_SL.Text.Trim();
            Transact.PRODUCT_SAFEGUARD_RATE = txtSafeguard_RATE.Text.Trim();
            Transact.PRODUCT_SAFEGUARD_SPL = txtSafeguard_SPL.Text.Trim();

            Transact.PRODUCT_SAFEGUARD_UNIT = txtSafeguard_UNIT.Text;
            Transact.PRODUCT_SAFEGUARD_SPL_TYPE = ddlSafeguard_SPL_TYPE.SelectedValue.ToString();

            Transact.PRODUCT_SAPTA_NOTN = txtSAPTA_NOTN.Text.Trim();
            Transact.PRODUCT_SAPTA_SLNO = txtSAPTA_NOTN_SL.Text.Trim();
            Transact.PRODUCT_SAPTA_RATE = txtSAPTA_RATE.Text.Trim();
            Transact.PRODUCT_TARIFF_NOTN = txtTariff_NOTN.Text;

            Transact.PRODUCT_TARIFF_SLNO = txtTariff_SL.Text;
            Transact.PRODUCT_TARIFF_QTY = txtTariff_Qty.Text.Trim();
            Transact.PRODUCT_TARIFF_AMOUNT = txtTariff_Amount.Text.Trim();
            Transact.PRODUCT_TARIFF_AMOUNT_UNIT = txtTariff_Amount_unitCode.Text;


            Transact.PRODUCT_CETH = txtCETH_No.Text.Trim();
            Transact.PRODUCT_MRP_YN = a3;
            Transact.PRODUCT_MRP_SL_NO = txtMRP_SL_NO.Text;
            Transact.PRODUCT_MRP_AMOUNT = txtMRP_AMOUNT.Text.Trim();
            Transact.PRODUCT_MRP_ABT_RATE = txtMRP_ABT_RATE.Text.Trim();
            Transact.PRODUCT_CVD_NOTN = txt_CVD_NOTN.Text.Trim();
            Transact.PRODUCT_CVD_SLNO = txt_CVD_SLNO.Text.Trim();
            Transact.PRODUCT_CVD_RATE = txt_CVD_RATE.Text.Trim();
            Transact.PRODUCT_CVD_SPL = txt_CVD_SPL.Text.Trim();
            Transact.PRODUCT_CVD_UNIT = txt_CVD_UNIT.Text;
            Transact.PRODUCT_CVD_SPL_TYPE = ddlCVD_SPL_TYPE.SelectedValue.ToString();
            Transact.PRODUCT_CVD_EDU_CESS_RATE = txt_CVD_Education_CESS_Rate.Text.Trim();
            Transact.PRODUCT_CVD_SEC_EDU_CESS_RATE = txt_CVD_Sec_Edu_CESS_Rate.Text;
            Transact.PRODUCT_ADDL5_SIA_NOTN = txt_Addl5_SIA_NOTN.Text.Trim();
            Transact.PRODUCT_ADDL5_SIA_NOTN_SL = txt_Addl5_SIA_NOTN_SL.Text.Trim();
            Transact.PRODUCT_ADDL5_SIA_RATE = txt_Addl5_SIA_RATE.Text.Trim();
            Transact.PRODUCT_ADDL_GSI_NOTN = txt_Addl_GSI_NOTN.Text.Trim();
            Transact.PRODUCT_ADDL_GSI_SLNO = txt_Addl_GSI_SL.Text.Trim();
            Transact.PRODUCT_ADDL_GSI_RATE = txt_Addl_GSI_RATE.Text.Trim();
            Transact.PRODUCT_ADDL_GSI_SPL = txt_Addl_GSI_SPL.Text;
            Transact.PRODUCT_ADDL_GSI_UNIT = txt_Addl_GSI_UNIT.Text;
            Transact.PRODUCT_ADDL_GSI_SPL_TYPE = ddl_Addl_GSI_SPL_TYPE.SelectedValue.ToString();
            Transact.PRODUCT_ADDL_SHEII_NOTN = txt_Addl_SHE11_NOTN.Text.Trim();
            Transact.PRODUCT_ADDL_SHEII_SLNO = txt_Addl_SHE11_SLNO.Text.Trim();
            Transact.PRODUCT_ADDL_SHEII_RATE = txt_Addl_SHE11_RATE.Text.Trim();
            Transact.PRODUCT_ADDL_SHEII_SPL = txt_Addl_SHE11_SPL.Text.Trim();
            Transact.PRODUCT_ADDL_SHEII_UNIT = txt_Addl_SHE11_UNIT.Text;
            Transact.PRODUCT_ADDL_SHEII_TYPE = ddl_Addl_SHE11_Type.SelectedValue.ToString();
            Transact.PRODUCT_ADDL_TTA_NOTN = txt_Addl_TTA_NOTN.Text.Trim();
            Transact.PRODUCT_ADDL_TTA_SLNO = txt_Addl_TTA_SLNO.Text.Trim();
            Transact.PRODUCT_ADDL_TTA_RATE = txt_Addl_TTA_RATE.Text.Trim();
            Transact.PRODUCT_ADDL_TTA_SPL = txt_Addl_TTA_SPL.Text.Trim();
            Transact.PRODUCT_ADDL_TTA_UNIT = txt_Addl_TTA_UNIT.Text;
            Transact.PRODUCT_ADDL_TTA_TYPE = ddl_Addl_TTA_Type.SelectedValue.ToString();
            Transact.PRODUCT_ADDL_HEALTH_CESS_NOTN = txt_Addl_Health_CESS_NOTN.Text.Trim();
            Transact.PRODUCT_ADDL_HEALTH_CESS_SLNO = txt_Addl_Health_CESS_SLNO.Text.Trim();
            Transact.PRODUCT_ADDL_HEALTH_CESS_RATE = txt_Addl_Health_CESS_RATE.Text.Trim();
            Transact.PRODUCT_ADDL_HEALTH_CESS_SPL = txt_Addl_Health_CESS_SPL.Text.Trim();
            Transact.PRODUCT_ADDL_HEALTH_CESS_UNIT = txt_Addl_Health_CESS_UNIT.Text;
            Transact.PRODUCT_ADDL_HEALTH_CESS_TYPE = ddl_Addl_Health_CESS_Type.SelectedValue.ToString();
            Transact.PRODUCT_CESS_NOTN = txt_CESS_NOTN.Text.Trim();
            Transact.PRODUCT_CESS_SLNO = txt_CESS_SLNO.Text.Trim();
            Transact.PRODUCT_CESS_RATE = txt_CESS_RATE.Text.Trim();
            Transact.PRODUCT_CESS_SPL = txt_CESS_SPL.Text.Trim();
            Transact.PRODUCT_CESS_UNIT = txt_CESS_UNIT.Text;
            Transact.PRODUCT_CESS_TYPE = ddl_CESS_Type.SelectedValue.ToString();

            //if (ddlAntiDumping_Notn.SelectedValue.ToString() != "")//08-05-2021
            if (txt_AntiDumping_Notn.Text != "")
            {
                //Transact.ANTI_DUMPING_NOTN = ddlAntiDumping_Notn.SelectedValue.ToString();//08-05-2021
                //Transact.ANTI_DUMPING_NOTN_SLNO = ddlAntiDumping_Notn_SL.SelectedItem.Text;
                Transact.ANTI_DUMPING_NOTN = txt_AntiDumping_Notn.Text.Trim();
                Transact.ANTI_DUMPING_NOTN_SLNO = txt_AntiDumping_Notn_SL.Text.Trim();
                //Transact.ANTI_DUMPING_NOTN_SLNO = hdn_ADD_SLNO.Value;
                Transact.CTH_SLNO = txtCTH_SL_No.Text.Trim();
                Transact.CTH_SUPPLIER_SLNO = txtCTH_Supplier_SL.Text.Trim();
            }
            else
            {
                Transact.ANTI_DUMPING_NOTN = "";
                Transact.ANTI_DUMPING_NOTN_SLNO = "";
                Transact.CTH_SLNO = "";
                Transact.CTH_SUPPLIER_SLNO = "";
            }

            Transact.CTH_QTY = txtCTH_Qty.Text.Trim();
            Transact.RSP_DUTY_STATUS = ddlRSP_Duty_yn.SelectedValue.ToString();
            Transact.RSP_NOTN_NO = txtRSP_Notn_No.Text;
            Transact.RSP_NOTN_SL_NO = txtRSP_Notn_Slno.Text;


            Transact.WAREHOUSE_JOBNO = "0";
            Transact.WAREHOUSE_INVOICE_SLNO = "0";
            Transact.WAREHOUSE_ITEM_SLNO = "0";

            Transact.USER_ID = currentuser;
            Transact.BRANCH_CODE = Connection.Current_Branch();
            Transact.flag = a4;
            Transact.YEAR = a5;
            Transact.WORKING_PERIOD = Connection.WorkingPeriod();

            Transact.BRANCH_COMMON = SELECT_BRANCH;

            //---------------------13_july_2014-----------

            Transact.CETH_CVD_EDU_CESS_SL = txt_CVD_Education_CESS_SL.Text;
            Transact.CETH_CVD_EDU_CESS_RATE = txtCVD_Edu_Cess_Rate.Text;
            Transact.CETH_CVD_SEC_EDU_CESS_SL = txtCETH_Sec_Edu_Cess_NOTN_SL.Text;
            Transact.CETH_CVD_SEC_EDU_CESS_RATE = txtCETH_Sec_Edu_Cess_Rate.Text;


            //---------------------13_july_2014-----------

            //---------------------01_June_2015-----------
            Transact.PRODUCT_OTHER_DUTY_NOTN = txtOther_Duty_Notn.Text.Trim();
            Transact.PRODUCT_OTHER_DUTY_SLNO = txtOther_Duty_SLNO.Text.Trim();
            Transact.PRODUCT_OTHER_DUTY_RATE = txtOther_Duty_RATE.Text.Trim();
            Transact.PRODUCT_OTHER_DUTY_SPL = txtOther_Duty_SPL.Text.Trim();
            Transact.PRODUCT_OTHER_DUTY_UNIT = txtOther_Duty_UNIT.Text;
            Transact.PRODUCT_OTHER_DUTY_TYPE = ddlOther_Duty_Type.SelectedValue.ToString();
            //---------------------01_June_2015-----------

            //----Budget 2016------ Start------


            if (chkMRP_Duty.Checked == true)
            {
                Transact.RSP_APPLICABLE = ddl_RSP_Applicable.SelectedValue.ToString();
            }
            else
            {
                Transact.RSP_APPLICABLE = "N";
            }

            Transact.CENTRAL_EXCISE_FALG = txt_Cus_not_exe_Cen_flag.Text;
            Transact.MANUFACTURER_PRODUCER = txt_Manufacturer_producer.Text;
            Transact.M_P_GROWER_CODE = txt_Manu_produ_grower_code.Text;
            Transact.M_P_GROWER_ADD1 = txt_Manufacturer_Add1.Text;
            Transact.M_P_GROWER_ADD2 = txt_Manufacturer_Add2.Text;
            Transact.M_P_GROWER_CITY = txt_Manufacturer_City.Text;
            Transact.M_P_GROWER_COUNTRY_SUBDIV = txt_Manu_Country_Subdiv.Text;
            Transact.M_P_GROWER_PIN = txt_Manufacturer_pincode.Text;
            Transact.M_P_GROWER_COUNTRY = txt_Manufacturer_Country.Text.ToUpper();
            Transact.SOURCE_COUNTRY = txt_Manu_Source_Country.Text.ToUpper();
            Transact.TRANSIT_COUNTRY = txt_manu_Transit_Country.Text.ToUpper();
            Transact.ACCESSORY_STATUS = txt_Accessory_status.Text;

            Transact.INFRA_CESS_NOTN = txtinfra_cess_Notn.Text.Trim();
            Transact.INFRA_CESS_NOTN_SL = txtinfra_cess_Notn_SLNO.Text.Trim();
            Transact.INFRA_CESS_NOTN_RATE = txtinfra_cess_Notn_RATE.Text.Trim();


            //----Budget 2016------ End------

            if (chkSVB_Relation.Checked == true)
            {
                Transact.SVB_RELATION = "true";
                Transact.SVB_REF_NO = txtSVB_RefNo.Text;
                Transact.SVB_REF_DATE = txtSVBDate.Text;
                Transact.SVB_CUSTOM_HOUSE = txtCustomsHouse_2.Text.ToUpper();
                Transact.SVB_LOADING_ON = ddlLoadingOn.SelectedItem.Text;
                Transact.SVB_ASSESABLE_RATE = txtAssesable_Rate.Text;
                Transact.SVB_DUTY_RATE = txtDuty_Rate.Text;
                Transact.SVB_ASSESABLE_STATUS = ddlAssesable_Status.SelectedValue.ToString();
                Transact.SVB_DUTY_STATUS = ddlDuty_Status.SelectedValue.ToString();

                txtSVB_RefNo.Enabled = true;
                txtSVBDate.Enabled = true;
                ddlLoadingOn.Enabled = true;


                if (ddlLoadingOn.SelectedItem.Text == "Assessable")
                {
                    txtAssesable_Rate.Enabled = true;
                    ddlAssesable_Status.Enabled = true;
                }
                else if (ddlLoadingOn.SelectedItem.Text == "Duty")
                {
                    txtDuty_Rate.Enabled = true;
                    ddlDuty_Status.Enabled = true;
                }
                else if (ddlLoadingOn.SelectedItem.Text == "Both")
                {
                    txtAssesable_Rate.Enabled = true;
                    ddlAssesable_Status.Enabled = true;
                    txtDuty_Rate.Enabled = true;
                    ddlDuty_Status.Enabled = true;
                }
            }
            else
            {
                Transact.SVB_RELATION = "false";
                Transact.SVB_REF_NO = string.Empty;
                Transact.SVB_REF_DATE = string.Empty;
                Transact.SVB_CUSTOM_HOUSE = string.Empty;
                Transact.SVB_LOADING_ON = string.Empty;
                Transact.SVB_ASSESABLE_RATE = string.Empty;
                Transact.SVB_DUTY_RATE = string.Empty;
                Transact.SVB_ASSESABLE_STATUS = string.Empty;
                Transact.SVB_DUTY_STATUS = string.Empty;
            }

            Transact.IGST_LEVY_NOTN = txt_IGST_LEVY_NOTN.Text.Trim();
            Transact.IGST_LEVY_SLNO = txt_IGST_LEVY_SLNO.Text.Trim();
            Transact.IGST_LEVY_RATE = txt_IGST_LEVY_RATE.Text;
            Transact.IGST_LEVY_SPL = txt_IGST_LEVY_SPL_Amt.Text;
            Transact.IGST_LEVY_UNIT = txt_IGST_LEVY_UNIT.Text;
            Transact.IGST_LEVY_SPL_TYPE = ddl_IGST_LEVY_SPL_TYPE.SelectedValue.ToString();
            Transact.IGST_LEVY_EXCEPTION_NOTN = txt_IGST_LEVY_EXCEPTION_NOTN.Text.Trim();
            Transact.IGST_LEVY_EXCEPTION_SLNO = txt_IGST_LEVY_EXCEPTION_SLNO.Text.Trim();
            Transact.IGST_LEVY_EXCEPTION_RATE = txt_IGST_LEVY_EXCEPTION_RATE.Text;
            Transact.IGST_LEVY_COMPENSATION_CESS_NOTN = txt_IGST_LEVY_COMPENSATION_CESS_NOTN.Text.Trim();
            Transact.IGST_LEVY_COMPENSATION_CESS_SLNO = txt_IGST_LEVY_COMPENSATION_CESS_SLNO.Text.Trim();
            Transact.IGST_LEVY_COMPENSATION_CESS_RATE = txt_IGST_LEVY_COMPENSATION_CESS_RATE.Text;
            Transact.IGST_LEVY_COMPENSATION_CESS_SPL = txt_IGST_LEVY_COMPENSATION_CESS_SPL.Text;
            Transact.IGST_LEVY_COMPENSATION_CESS_UNIT = txt_IGST_LEVY_COMPENSATION_CESS_UNIT.Text;
            Transact.IGST_LEVY_COMPENSATION_CESS_SPL_TYPE = ddl_IGST_LEVY_COMPENSATION_CESS_SPL_TYPE.SelectedValue.ToString();
            Transact.IGST_LEVY_EXCEPTION_CC_NOTN = txt_IGST_LEVY_EXCEPTION_CC_NOTN.Text.Trim();
            Transact.IGST_LEVY_EXCEPTION_CC_SLNO = txt_IGST_LEVY_EXCEPTION_CC_SLNO.Text.Trim();
            Transact.IGST_LEVY_EXCEPTION_CC_RATE = txt_IGST_LEVY_EXCEPTION_CC_RATE.Text;

            Transact.LEVY_EXCEMPTION_NOTN_TYPE = ddl_LEVY_EXCEMPTION_NOTN_TYPE.SelectedValue;
            Transact.LEVY_EXCEPTION_CC_NOTN_TYPE = ddl_LEVY_EXCEPTION_CC_NOTN_TYPE.SelectedValue;

            Transact.SOCIAL_WELFARE_NOTN = txt_Social_Welfare_NOTN.Text.Trim();
            Transact.SOCIAL_WELFARE_NOTN_SLNO = txt_Social_Welfare_NOTN_SL.Text.Trim();
            Transact.SOCIAL_WELFARE_RATE = txt_Social_Welfare_Rate.Text.Trim();

            Transact.Info_Msr = txt_Info_Msr.Text.Trim();
            //Transact.Info_Uqc = txt_Info_Uqc.Text;//textBox enabled=false
            Transact.Info_Uqc = hdn_Info_UQC.Value;
            txt_Info_Uqc.Text = hdn_Info_UQC.Value;

            Transact.SIMS = SIMS(txtCTH_No.Text);

            Transact.AMENDMENT_TYPE = ddl_AmendmentType.SelectedValue;
            Transact.AMENDMENT_STATUS = "";

            Transact.AIDC_NOTN = txt_AIDC_NOTN.Text.Trim();
            Transact.AIDC_NOTN_SLNO = txt_AIDC_NOTN_SLNO.Text.Trim();
            Transact.AIDC_RATE = txt_AIDC_RATE.Text.Trim();
            Transact.ADD_EX_RATE = txt_ADD_ExRate.Text.Trim();


            Transact.EXC_AIDC_NOTN = txt_Exc_AIDC_NOTN.Text.Trim();
            Transact.EXC_AIDC_NOTN_SLNO = txt_Exc_AIDC_NOTN_SLNO.Text.Trim();
            Transact.EXC_AIDC_RATE = txt_Exc_AIDC_RATE.Text.Trim();
            Transact.JOBNO_PS = Session["JOBNO_PS"].ToString();
            Transact.PART_NO = txtpartno.Text;
            Session["Part_No"] = txtpartno.Text;
            dss = Transact.Item_Details_insertupdate();


            Grid_Save_Update_Empty();
            //Item_Move_UpDown_Enable();
            i = Transact.result;
            lblProductValue.Text = Transact.TOTAL_ITEM_VALUE;
            if (i == 1 || i == 3)
            {

                if (a4 == "S")
                {
                    a7 = Convert.ToString(Transact.UPDATE_ITEMSLNO);
                }
                Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), a2, a7, "Item", a4, "Insert");
            }
            if (a4 == "S")
            {
                hdn_Grid_RowCount.Value = Convert.ToString(Transact.Gridview_Rowcount);

                /* LC 17-05-2018
                lbl_Item_Slno.Text = Convert.ToString(Transact.Gridview_Rowcount + 1);

                if (Session["COMPANY_LICENSE"].ToString().ToLower() != "eri00457") //----Capital Shipping on 24Apr2018
                {
                    lbl_Item_Slno_Dis.Text = Convert.ToString(Transact.Gridview_Rowcount + 1) + ".";
                }
                 * */
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

    }

    //public void Edit_FirstItem_UpdateDetails(string ITEMID, string INVOICE_SLNO, string ITEM_SLNO)
    public void Edit_FirstItem_UpdateDetails(string ITEMID)
    {
        try
        {
            if (ViewState["ITEMID"] != "" && ViewState["ITEMID"] != null)
            {
                HiddenField1.Value = ViewState["ITEMID"].ToString();

                //string value = (gv_ItemDetails.Rows[0].FindControl("lblitemslno") as Label).Text;
                //ViewState["RUN_ITEM_SL_NO"] = (gv_ItemDetails.Rows[0].FindControl("lblitemslno") as Label).Text;

                if (ITEM_SLNO == "0")
                {
                    ITEM_SLNO = "1";
                }

                Transact.JOBNO = IMPORT_JOBNO;
                Transact.INVOICE_SLNO = INVOICE_SLNO;
                Transact.ITEM_SLNO = ITEM_SLNO;
                Transact.ITEM_ID = HiddenField1.Value;
                Transact.WORKING_PERIOD = SELECT_BRANCH;

                Transact.Ename = "select_con_ItemSlNo";
                DataSet dt_Item = Transact.RetrieveAll_Item_Details();

                if (dt_Item.Tables[0].Rows.Count > 0)
                {
                    txt_AIDC_NOTN.Text = dt_Item.Tables[0].Rows[0]["AIDC_NOTN"].ToString();
                    txt_AIDC_NOTN_SLNO.Text = dt_Item.Tables[0].Rows[0]["AIDC_NOTN_SLNO"].ToString();
                    txt_AIDC_RATE.Text = dt_Item.Tables[0].Rows[0]["AIDC_RATE"].ToString();
                    txt_ADD_ExRate.Text = dt_Item.Tables[0].Rows[0]["ADD_EX_RATE"].ToString();

                    txt_Exc_AIDC_NOTN.Text = dt_Item.Tables[0].Rows[0]["EXC_AIDC_NOTN"].ToString();
                    txt_Exc_AIDC_NOTN_SLNO.Text = dt_Item.Tables[0].Rows[0]["EXC_AIDC_NOTN_SLNO"].ToString();
                    txt_Exc_AIDC_RATE.Text = dt_Item.Tables[0].Rows[0]["EXC_AIDC_RATE"].ToString();


                    txtItemQty.Text = dt_Item.Tables[0].Rows[0]["ITEM_QTY"].ToString();
                    txtItem_UnitPrice.Text = dt_Item.Tables[0].Rows[0]["ITEM_UNIT_PRICE"].ToString();  //gv_ItemDetails.Rows[0].Cells[6].Text.Replace("&nbsp;", "");
                    hdn_UnitPrice.Value = txtItem_UnitPrice.Text;

                    txtItem_UnitPriceCode.Text = dt_Item.Tables[0].Rows[0]["ITEM_UNIT_CODE"].ToString();  //gv_ItemDetails.Rows[0].Cells[9].Text.Replace("&nbsp;", "");

                    txtItem_Amount.Text = dt_Item.Tables[0].Rows[0]["ITEM_TOTAL_AMOUNT"].ToString();  // gv_ItemDetails.Rows[0].Cells[7].Text.Replace("&nbsp;", "");
                    hdn_ITEM_AOUNT.Value = txtItem_Amount.Text;

                    txtCTH_No.Text = dt_Item.Tables[0].Rows[0]["CTH_NO"].ToString();  //gv_ItemDetails.Rows[0].Cells[8].Text.Replace("&nbsp;", "");

                    txtQtyCode.Text = dt_Item.Tables[0].Rows[0]["ITEM_QTY_CODE"].ToString();  // gv_ItemDetails.Rows[0].Cells[5].Text.Replace("&nbsp;", "");

                    txtItem_AmountCode.Text = dt_Item.Tables[0].Rows[0]["ITEM_AMOUNT_CODE"].ToString();  //  gv_ItemDetails.Rows[0].Cells[10].Text.Replace("&nbsp;", "");

                    if (dt_Item.Tables[0].Columns.Contains("FOC_ITEM") && dt_Item.Tables[0].Rows[0]["FOC_ITEM"].ToString().Trim().ToUpper() == "Y")
                    {
                        ddlFocItem.SelectedValue = "Y";
                    }
                    else
                    {
                        ddlFocItem.SelectedValue = "N";
                    }


                    string schemecode = dt_Item.Tables[0].Rows[0]["SCHEME_CODE"].ToString();  // gv_ItemDetails.Rows[0].Cells[138].Text.Replace("&nbsp;", "");
                    //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//
                    Session["SCHEME_CODE"] = schemecode;
                    //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//

                    ddlSchemeCode.Items.Remove(schemecode);
                    ddlSchemeCode.Items.Insert(0, schemecode);
                    ddlSchemeCode.SelectedIndex = -1;

                    scheme_NOTN();

                    //string notn = dt_Item.Tables[0].Rows[0]["SCHEME_NOTN"].ToString();  //  gv_ItemDetails.Rows[0].Cells[12].Text.Replace("&nbsp;", "");
                    ddlScheme_NOTN.Items.Remove(dt_Item.Tables[0].Rows[0]["SCHEME_NOTN"].ToString());
                    ddlScheme_NOTN.Items.Insert(0, dt_Item.Tables[0].Rows[0]["SCHEME_NOTN"].ToString());
                    ddlScheme_NOTN.SelectedIndex = -1;

                    //string notn_sl = dt_Item.Tables[0].Rows[0]["SCHEME_NOTN_SLNO"].ToString();  // gv_ItemDetails.Rows[0].Cells[13].Text.Replace("&nbsp;", "");
                    ddlScheme_NOTN_SL.Items.Remove(dt_Item.Tables[0].Rows[0]["SCHEME_NOTN_SLNO"].ToString());
                    ddlScheme_NOTN_SL.Items.Insert(0, dt_Item.Tables[0].Rows[0]["SCHEME_NOTN_SLNO"].ToString());
                    ddlScheme_NOTN_SL.SelectedIndex = -1;
                    //value rest problem when use ajax cascadedropdown// 
                    Session.Remove("ddlSchemeCode");
                    Session.Remove("ddlScheme_NOTN");
                    Session.Remove("ddlScheme_NOTN_SL");
                    Session["ddlSchemeCode"] = schemecode;
                    Session["ddlScheme_NOTN"] = dt_Item.Tables[0].Rows[0]["SCHEME_NOTN"].ToString();
                    Session["ddlScheme_NOTN_SL"] = dt_Item.Tables[0].Rows[0]["SCHEME_NOTN_SLNO"].ToString();

                    //value rest problem when use ajax cascadedropdown// 
                    hdn_chk_country.Value = Check_CountryName(dt_Item.Tables[0].Rows[0]["COUNTRY_OF_ORIGIN"].ToString(), "COUNTRY_OF_ORIGIN");


                    txtCTH_Qty1.Text = dt_Item.Tables[0].Rows[0]["CTH_QTY1"].ToString();  // gv_ItemDetails.Rows[0].Cells[14].Text.Replace("&nbsp;", "");
                    txtCTH_Qty2.Text = dt_Item.Tables[0].Rows[0]["CTH_QTY2"].ToString();  //gv_ItemDetails.Rows[0].Cells[15].Text.Replace("&nbsp;", "");
                    txtGeneralDesc.Text = dt_Item.Tables[0].Rows[0]["GENEARL_DESCRIPTION"].ToString();  // Rep.Replace(gv_ItemDetails.Rows[0].Cells[16].Text).Replace("&nbsp;", "").Replace("&gt;", ">").Replace("&lt;", "<").Replace("&amp;", "&");
                    txtManufacturer.Text = dt_Item.Tables[0].Rows[0]["MANUFACTURER"].ToString();  // Rep.Replace(gv_ItemDetails.Rows[0].Cells[17].Text);
                    txtBrand.Text = dt_Item.Tables[0].Rows[0]["BRAND"].ToString();  // Rep.Replace(gv_ItemDetails.Rows[0].Cells[18].Text);
                    txtModel.Text = dt_Item.Tables[0].Rows[0]["MODEL"].ToString();  // Rep.Replace(gv_ItemDetails.Rows[0].Cells[19].Text);
                    txtEndUse.Text = dt_Item.Tables[0].Rows[0]["END_USE_OF_ITEM"].ToString();  // Rep.Replace(gv_ItemDetails.Rows[0].Cells[20].Text);
                    hdn_txtEndUse.Value = Check_EndUseCode(txtEndUse.Text);
                    txtCountryOrigin.Text = dt_Item.Tables[0].Rows[0]["COUNTRY_OF_ORIGIN"].ToString();  // gv_ItemDetails.Rows[0].Cells[21].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                    Session["ITEM_COUNTRY_OF_ORIGIN"] = txtCountryOrigin.Text;
                    txtAccessories.Text = dt_Item.Tables[0].Rows[0]["ACCESSORIES"].ToString();  // Rep.Replace(gv_ItemDetails.Rows[0].Cells[22].Text);

                    txtPrevious_Be_No.Text = dt_Item.Tables[0].Rows[0]["PREVIOUS_BE_NO"].ToString();  //  gv_ItemDetails.Rows[0].Cells[23].Text.Replace("&nbsp;", "");
                    txtPrevious_Be_Date.Text = dt_Item.Tables[0].Rows[0]["PREVIOUS_BE_DATE"].ToString().Replace("01/01/1900", "");  // gv_ItemDetails.Rows[0].Cells[24].Text.Replace("01/01/1900", "");

                    txtUnitValue.Text = dt_Item.Tables[0].Rows[0]["UNIT_PRICE"].ToString();  // gv_ItemDetails.Rows[0].Cells[25].Text.Replace("&nbsp;", "");
                    txtunitcode.Text = dt_Item.Tables[0].Rows[0]["UNIT_CODE"].ToString();  // gv_ItemDetails.Rows[0].Cells[26].Text.Replace("&nbsp;", "");
                    txtCustomsHouse.Text = dt_Item.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();  // gv_ItemDetails.Rows[0].Cells[27].Text.Replace("&nbsp;", "");
                    txtRITCNO.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_RITC"].ToString();  // gv_ItemDetails.Rows[0].Cells[28].Text.Replace("&nbsp;", "");
                    txtCTHNO.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_CTH"].ToString();  // gv_ItemDetails.Rows[0].Cells[29].Text.Replace("&nbsp;", "");
                    txtBasicNotn.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_BCD_NOTN"].ToString();  // gv_ItemDetails.Rows[0].Cells[30].Text.Replace("&nbsp;", "");
                    txtBasicSLNO.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_BCD_SLNO"].ToString();  // gv_ItemDetails.Rows[0].Cells[31].Text.Replace("&nbsp;", "");

                    txtBasicRate.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_BCD_RATE"].ToString();  // gv_ItemDetails.Rows[0].Cells[32].Text.Replace("&nbsp;", "");
                    txtBasicSPL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_BCD_SPL"].ToString();  // gv_ItemDetails.Rows[0].Cells[33].Text.Replace("&nbsp;", "");
                    txtBasicUnit.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_BCD_UNIT"].ToString();  // gv_ItemDetails.Rows[0].Cells[34].Text.Replace("&nbsp;", "");

                    //string basic_spl_type = dt_Item.Tables[0].Rows[0]["PRODUCT_BCD_SPL_TYPE"].ToString();  // gv_ItemDetails.Rows[0].Cells[35].Text.Replace("&nbsp;", "");
                    ddlBasicSPLTYPE.Items.Remove(dt_Item.Tables[0].Rows[0]["PRODUCT_BCD_SPL_TYPE"].ToString());
                    ddlBasicSPLTYPE.Items.Insert(0, dt_Item.Tables[0].Rows[0]["PRODUCT_BCD_SPL_TYPE"].ToString());
                    ddlBasicSPLTYPE.SelectedIndex = -1;

                    txtAddlDuty_NOTN.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_NOTN"].ToString();  // gv_ItemDetails.Rows[0].Cells[36].Text.Replace("&nbsp;", "");
                    txtAddlDuty_NOTN_SL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString();  // gv_ItemDetails.Rows[0].Cells[37].Text.Replace("&nbsp;", "");
                    txtEdu_Cess_NOTN.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_EDU_CESS_NOTN"].ToString();  // gv_ItemDetails.Rows[0].Cells[38].Text.Replace("&nbsp;", "");
                    txtEdu_Cess_NOTN_SL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_EDU_CESS_NOTN_SL"].ToString();  // gv_ItemDetails.Rows[0].Cells[39].Text.Replace("&nbsp;", "");
                    txtEdu_Cess_Rate.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_EDU_CESS_RATE"].ToString();  // gv_ItemDetails.Rows[0].Cells[40].Text.Replace("&nbsp;", "");
                    txtSec_Edu_Cess_NOTN.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString();  // gv_ItemDetails.Rows[0].Cells[41].Text.Replace("&nbsp;", "");
                    txtSec_Edu_Cess_NOTN_SL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString();  // gv_ItemDetails.Rows[0].Cells[42].Text.Replace("&nbsp;", "");
                    txtSec_Edu_Cess_Rate.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_RATE"].ToString();  // gv_ItemDetails.Rows[0].Cells[43].Text.Replace("&nbsp;", "");
                    txtNCD_NOTN.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_NCD_NOTN"].ToString();  // gv_ItemDetails.Rows[0].Cells[44].Text.Replace("&nbsp;", "");
                    txtNCD_SLNO.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_NCD_SLNO"].ToString();  // gv_ItemDetails.Rows[0].Cells[45].Text.Replace("&nbsp;", "");
                    txtNCD_RATE.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_NCD_RATE"].ToString();  // gv_ItemDetails.Rows[0].Cells[46].Text.Replace("&nbsp;", "");
                    txtNCD_SPL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_NCD_SPL"].ToString();  //  gv_ItemDetails.Rows[0].Cells[47].Text.Replace("&nbsp;", "");


                    txtNCD_UNIT.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_NCD_UNIT"].ToString(); // gv_ItemDetails.Rows[0].Cells[48].Text.Replace("&nbsp;", "");

                    //string NCD_spl_type = dt_Item.Tables[0].Rows[0]["PRODUCT_NCD_SPL_TYPE"].ToString(); //gv_ItemDetails.Rows[0].Cells[49].Text.Replace("&nbsp;", "");
                    ddlNCD_SPL_TYPE.Items.Remove(dt_Item.Tables[0].Rows[0]["PRODUCT_NCD_SPL_TYPE"].ToString());
                    ddlNCD_SPL_TYPE.Items.Insert(0, dt_Item.Tables[0].Rows[0]["PRODUCT_NCD_SPL_TYPE"].ToString());
                    ddlNCD_SPL_TYPE.SelectedIndex = -1;

                    txtAggregate_NOTN.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[50].Text.Replace("&nbsp;", "");
                    txtAggregate_NOTN_SL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString(); //gv_ItemDetails.Rows[0].Cells[51].Text.Replace("&nbsp;", "");
                    txtAggregate_RATE.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString(); // gv_ItemDetails.Rows[0].Cells[52].Text.Replace("&nbsp;", "");
                    txtSafeguard_NOTN.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[53].Text.Replace("&nbsp;", "");
                    txtSafeguard_SL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SLNO"].ToString(); //gv_ItemDetails.Rows[0].Cells[54].Text.Replace("&nbsp;", "");
                    txtSafeguard_RATE.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[55].Text.Replace("&nbsp;", "");
                    txtSafeguard_SPL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SPL"].ToString(); //gv_ItemDetails.Rows[0].Cells[56].Text.Replace("&nbsp;", "");

                    txtSafeguard_UNIT.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_UNIT"].ToString(); //gv_ItemDetails.Rows[0].Cells[57].Text.Replace("&nbsp;", "");

                    //string Safeguard = dt_Item.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString(); //gv_ItemDetails.Rows[0].Cells[58].Text.Replace("&nbsp;", "");
                    ddlSafeguard_SPL_TYPE.Items.Remove(dt_Item.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString());
                    ddlSafeguard_SPL_TYPE.Items.Insert(0, dt_Item.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString());
                    ddlSafeguard_SPL_TYPE.SelectedIndex = -1;

                    txtCETH_No.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_CETH"].ToString(); //gv_ItemDetails.Rows[0].Cells[59].Text.Replace("&nbsp;", "");
                    string mrp_duty = dt_Item.Tables[0].Rows[0]["PRODUCT_MRP_YN"].ToString(); //gv_ItemDetails.Rows[0].Cells[60].Text.Replace("&nbsp;", "");

                    if (mrp_duty == "Y")
                    {
                        chkMRP_Duty.Checked = true;
                        txtMRP_SL_NO.Enabled = true;
                        txtMRP_AMOUNT.Enabled = true;
                        txtMRP_ABT_RATE.Enabled = true;
                        txtRSP_Notn_No.Enabled = true;
                        txtRSP_Notn_Slno.Enabled = true;
                        ddl_RSP_Applicable.Enabled = true;
                    }
                    else
                    {
                        chkMRP_Duty.Checked = false;
                        txtMRP_SL_NO.Enabled = false;
                        txtMRP_AMOUNT.Enabled = false;
                        txtMRP_ABT_RATE.Enabled = false;
                        txtRSP_Notn_No.Enabled = false;
                        txtRSP_Notn_Slno.Enabled = false;
                        ddl_RSP_Applicable.Enabled = false;
                    }
                    txtMRP_SL_NO.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_MRP_SL_NO"].ToString(); //gv_ItemDetails.Rows[0].Cells[61].Text.Replace("&nbsp;", "");
                    txtMRP_AMOUNT.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_MRP_AMOUNT"].ToString(); // gv_ItemDetails.Rows[0].Cells[62].Text.Replace("&nbsp;", "");
                    txtMRP_ABT_RATE.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_MRP_ABT_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[63].Text.Replace("&nbsp;", "");
                    txt_CVD_NOTN.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_CVD_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[64].Text.Replace("&nbsp;", "");
                    txt_CVD_SLNO.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_CVD_SLNO"].ToString(); //gv_ItemDetails.Rows[0].Cells[65].Text.Replace("&nbsp;", "");
                    txt_CVD_RATE.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_CVD_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[66].Text.Replace("&nbsp;", "");
                    txt_CVD_SPL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_CVD_SPL"].ToString(); //gv_ItemDetails.Rows[0].Cells[67].Text.Replace("&nbsp;", "");
                    txt_CVD_UNIT.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_CVD_UNIT"].ToString(); // gv_ItemDetails.Rows[0].Cells[68].Text.Replace("&nbsp;", "");

                    //string CVD_type = dt_Item.Tables[0].Rows[0]["PRODUCT_CVD_SPL_TYPE"].ToString(); //gv_ItemDetails.Rows[0].Cells[69].Text.Replace("&nbsp;", "");
                    ddlCVD_SPL_TYPE.Items.Remove(dt_Item.Tables[0].Rows[0]["PRODUCT_CVD_SPL_TYPE"].ToString());
                    ddlCVD_SPL_TYPE.Items.Insert(0, dt_Item.Tables[0].Rows[0]["PRODUCT_CVD_SPL_TYPE"].ToString());
                    ddlCVD_SPL_TYPE.SelectedIndex = -1;

                    txt_CVD_Education_CESS_Rate.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_CVD_EDU_CESS_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[70].Text.Replace("&nbsp;", "");
                    txt_CVD_Sec_Edu_CESS_Rate.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_CVD_SEC_EDU_CESS_RATE"].ToString(); // gv_ItemDetails.Rows[0].Cells[71].Text.Replace("&nbsp;", "");
                    txt_Addl5_SIA_NOTN.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[72].Text.Replace("&nbsp;", "");
                    txt_Addl5_SIA_NOTN_SL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_NOTN_SL"].ToString(); //gv_ItemDetails.Rows[0].Cells[73].Text.Replace("&nbsp;", "");
                    txt_Addl5_SIA_RATE.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[74].Text.Replace("&nbsp;", "");
                    txt_Addl_GSI_NOTN.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_NOTN"].ToString(); // gv_ItemDetails.Rows[0].Cells[75].Text.Replace("&nbsp;", "");


                    txt_Addl_GSI_SL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SLNO"].ToString(); // gv_ItemDetails.Rows[0].Cells[76].Text.Replace("&nbsp;", "");
                    txt_Addl_GSI_RATE.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_RATE"].ToString(); // gv_ItemDetails.Rows[0].Cells[77].Text.Replace("&nbsp;", "");
                    txt_Addl_GSI_SPL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SPL"].ToString(); //gv_ItemDetails.Rows[0].Cells[78].Text.Replace("&nbsp;", "");
                    txt_Addl_GSI_UNIT.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_UNIT"].ToString(); //gv_ItemDetails.Rows[0].Cells[79].Text.Replace("&nbsp;", "");

                    //string GSI_Type = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString(); //gv_ItemDetails.Rows[0].Cells[80].Text.Replace("&nbsp;", "");
                    ddl_Addl_GSI_SPL_TYPE.Items.Remove(dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString());
                    ddl_Addl_GSI_SPL_TYPE.Items.Insert(0, dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString());
                    ddl_Addl_GSI_SPL_TYPE.SelectedIndex = -1;


                    txt_Addl_SHE11_NOTN.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[81].Text.Replace("&nbsp;", "");
                    txt_Addl_SHE11_SLNO.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_SLNO"].ToString(); //gv_ItemDetails.Rows[0].Cells[82].Text.Replace("&nbsp;", "");
                    txt_Addl_SHE11_RATE.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[83].Text.Replace("&nbsp;", "");
                    txt_Addl_SHE11_SPL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_SPL"].ToString(); //gv_ItemDetails.Rows[0].Cells[84].Text.Replace("&nbsp;", "");
                    txt_Addl_SHE11_UNIT.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_UNIT"].ToString(); //gv_ItemDetails.Rows[0].Cells[85].Text.Replace("&nbsp;", "");

                    //string Shell_type = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_TYPE"].ToString(); //gv_ItemDetails.Rows[0].Cells[86].Text.Replace("&nbsp;", "");
                    ddl_Addl_SHE11_Type.Items.Remove(dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_TYPE"].ToString());
                    ddl_Addl_SHE11_Type.Items.Insert(0, dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_TYPE"].ToString());
                    ddl_Addl_SHE11_Type.SelectedIndex = -1;


                    txt_Addl_TTA_NOTN.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[87].Text.Replace("&nbsp;", "");
                    txt_Addl_TTA_SLNO.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_SLNO"].ToString(); //gv_ItemDetails.Rows[0].Cells[88].Text.Replace("&nbsp;", "");
                    txt_Addl_TTA_RATE.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[89].Text.Replace("&nbsp;", "");
                    txt_Addl_TTA_SPL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_SPL"].ToString(); //gv_ItemDetails.Rows[0].Cells[90].Text.Replace("&nbsp;", "");
                    txt_Addl_TTA_UNIT.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_UNIT"].ToString(); //gv_ItemDetails.Rows[0].Cells[91].Text.Replace("&nbsp;", "");

                    //string TTA_type = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_TYPE"].ToString(); //gv_ItemDetails.Rows[0].Cells[92].Text.Replace("&nbsp;", "");
                    ddl_Addl_TTA_Type.Items.Remove(dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_TYPE"].ToString());
                    ddl_Addl_TTA_Type.Items.Insert(0, dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_TYPE"].ToString());
                    ddl_Addl_TTA_Type.SelectedIndex = -1;


                    txt_Addl_Health_CESS_NOTN.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[93].Text.Replace("&nbsp;", "");
                    txt_Addl_Health_CESS_SLNO.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString(); //gv_ItemDetails.Rows[0].Cells[94].Text.Replace("&nbsp;", "");
                    txt_Addl_Health_CESS_RATE.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[95].Text.Replace("&nbsp;", "");
                    txt_Addl_Health_CESS_SPL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_SPL"].ToString(); //gv_ItemDetails.Rows[0].Cells[96].Text.Replace("&nbsp;", "");
                    txt_Addl_Health_CESS_UNIT.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_UNIT"].ToString(); //gv_ItemDetails.Rows[0].Cells[97].Text.Replace("&nbsp;", "");

                    //string health_Cess_type = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString(); // gv_ItemDetails.Rows[0].Cells[98].Text.Replace("&nbsp;", "");
                    ddl_Addl_Health_CESS_Type.Items.Remove(dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString());
                    ddl_Addl_Health_CESS_Type.Items.Insert(0, dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString());
                    ddl_Addl_Health_CESS_Type.SelectedIndex = -1;

                    txt_CESS_NOTN.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_CESS_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[99].Text.Replace("&nbsp;", "");
                    txt_CESS_SLNO.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_CESS_SLNO"].ToString(); //gv_ItemDetails.Rows[0].Cells[100].Text.Replace("&nbsp;", "");
                    txt_CESS_RATE.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_CESS_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[101].Text.Replace("&nbsp;", "");
                    txt_CESS_SPL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_CESS_SPL"].ToString(); //gv_ItemDetails.Rows[0].Cells[102].Text.Replace("&nbsp;", "");
                    txt_CESS_UNIT.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_CESS_UNIT"].ToString(); // gv_ItemDetails.Rows[0].Cells[103].Text.Replace("&nbsp;", "");

                    //string cess_type = dt_Item.Tables[0].Rows[0]["PRODUCT_CESS_TYPE"].ToString(); //gv_ItemDetails.Rows[0].Cells[104].Text.Replace("&nbsp;", "");
                    ddl_CESS_Type.Items.Remove(dt_Item.Tables[0].Rows[0]["PRODUCT_CESS_TYPE"].ToString());
                    ddl_CESS_Type.Items.Insert(0, dt_Item.Tables[0].Rows[0]["PRODUCT_CESS_TYPE"].ToString());
                    ddl_CESS_Type.SelectedIndex = -1;

                    //string Anti_Notn, Anti_Slno;

                    //Anti_Notn = dt_Item.Tables[0].Rows[0]["ANTI_DUMPING_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[105].Text.Replace("&nbsp;", "");
                    /* hide on 08-05-2021 by Chithra Sugg.by Bala sir
                    ddlAntiDumping_Notn.Items.Remove(dt_Item.Tables[0].Rows[0]["ANTI_DUMPING_NOTN"].ToString());
                    ddlAntiDumping_Notn.Items.Insert(0, dt_Item.Tables[0].Rows[0]["ANTI_DUMPING_NOTN"].ToString());
                    ddlAntiDumping_Notn.SelectedIndex = -1;
                    */

                    txt_AntiDumping_Notn.Text = dt_Item.Tables[0].Rows[0]["ANTI_DUMPING_NOTN"].ToString();//08-05-2021
                    Get_AntiDumping_Slno(dt_Item.Tables[0].Rows[0]["ANTI_DUMPING_NOTN"].ToString());

                    //Anti_Slno = dt_Item.Tables[0].Rows[0]["ANTI_DUMPING_NOTN_SLNO"].ToString(); //gv_ItemDetails.Rows[0].Cells[106].Text.Replace("&nbsp;", "");
                    /* hide on 08-05-2021 by Chithra Sugg.by Bala sir
                    ddlAntiDumping_Notn_SL.Items.Remove(dt_Item.Tables[0].Rows[0]["ANTI_DUMPING_NOTN_SLNO"].ToString());
                    ddlAntiDumping_Notn_SL.Items.Insert(0, dt_Item.Tables[0].Rows[0]["ANTI_DUMPING_NOTN_SLNO"].ToString());
                    ddlAntiDumping_Notn_SL.SelectedIndex = -1;
                     * */

                    txt_AntiDumping_Notn_SL.Text = dt_Item.Tables[0].Rows[0]["ANTI_DUMPING_NOTN_SLNO"].ToString();//08-05-2021
                    hdn_ADD_SLNO.Value = dt_Item.Tables[0].Rows[0]["ANTI_DUMPING_NOTN_SLNO"].ToString();

                    txtCTH_SL_No.Text = dt_Item.Tables[0].Rows[0]["CTH_SLNO"].ToString(); //gv_ItemDetails.Rows[0].Cells[107].Text.Replace("&nbsp;", "");
                    txtCTH_Supplier_SL.Text = dt_Item.Tables[0].Rows[0]["CTH_SUPPLIER_SLNO"].ToString(); //gv_ItemDetails.Rows[0].Cells[108].Text.Replace("&nbsp;", "");
                    txtCTH_Qty.Text = dt_Item.Tables[0].Rows[0]["CTH_QTY"].ToString(); // gv_ItemDetails.Rows[0].Cells[109].Text.Replace("&nbsp;", "");

                    txtRSP_Notn_No.Text = dt_Item.Tables[0].Rows[0]["RSP_NOTN_NO"].ToString(); //gv_ItemDetails.Rows[0].Cells[118].Text.Replace("&nbsp;", "");
                    txtRSP_Notn_Slno.Text = dt_Item.Tables[0].Rows[0]["RSP_NOTN_SL_NO"].ToString(); //gv_ItemDetails.Rows[0].Cells[119].Text.Replace("&nbsp;", "");

                    //RSP DETAILS 

                    string RSP_DUTY_YN = dt_Item.Tables[0].Rows[0]["RSP_DUTY_STATUS"].ToString(); //gv_ItemDetails.Rows[0].Cells[113].Text.Replace("&nbsp;", "");
                    ddlRSP_Duty_yn.Items.Remove(RSP_DUTY_YN);
                    ddlRSP_Duty_yn.Items.Insert(0, RSP_DUTY_YN);
                    ddlRSP_Duty_yn.SelectedIndex = -1;

                    //RSP DETAILS 
                    txtCTH_Qty1_Code.Text = dt_Item.Tables[0].Rows[0]["CTH_QTY1_CODE"].ToString(); //gv_ItemDetails.Rows[0].Cells[121].Text.Replace("&nbsp;", "");
                    txtCTH_Qty2_Code.Text = dt_Item.Tables[0].Rows[0]["CTH_QTY2_CODE"].ToString(); //gv_ItemDetails.Rows[0].Cells[122].Text.Replace("&nbsp;", "");
                    txtAddlDuty_Rate.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[123].Text.Replace("&nbsp;", "");

                    txtSAPTA_NOTN.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_SAPTA_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[124].Text.Replace("&nbsp;", "");
                    txtSAPTA_NOTN_SL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_SAPTA_SLNO"].ToString(); //gv_ItemDetails.Rows[0].Cells[125].Text.Replace("&nbsp;", "");
                    txtSAPTA_RATE.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_SAPTA_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[126].Text.Replace("&nbsp;", "");
                    txtTariff_NOTN.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_TARIFF_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[127].Text.Replace("&nbsp;", "");
                    txtTariff_SL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_TARIFF_SLNO"].ToString(); // gv_ItemDetails.Rows[0].Cells[128].Text.Replace("&nbsp;", "");
                    txtTariff_Qty.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_TARIFF_QTY"].ToString(); //gv_ItemDetails.Rows[0].Cells[129].Text.Replace("&nbsp;", "");
                    txtTariff_Amount.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_TARIFF_AMOUNT"].ToString(); // gv_ItemDetails.Rows[0].Cells[130].Text.Replace("&nbsp;", "");
                    txtTariff_Amount_unitCode.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_TARIFF_AMOUNT_UNIT"].ToString(); // gv_ItemDetails.Rows[0].Cells[131].Text.Replace("&nbsp;", "");

                    txtDescription.Text = dt_Item.Tables[0].Rows[0]["ITEM_DESCRIPTION"].ToString(); //Rep.Replace(gv_ItemDetails.Rows[0].Cells[132].Text).Replace("&nbsp;", "").Replace("&gt;", ">").Replace("&lt;", "<").Replace("&amp;", "&");
                    txt_CVD_Education_CESS_SL.Text = dt_Item.Tables[0].Rows[0]["CETH_CVD_EDU_CESS_SL"].ToString(); //gv_ItemDetails.Rows[0].Cells[139].Text.Replace("&nbsp;", "");
                    txtCVD_Edu_Cess_Rate.Text = dt_Item.Tables[0].Rows[0]["CETH_CVD_EDU_CESS_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[140].Text.Replace("&nbsp;", "");
                    txtCETH_Sec_Edu_Cess_NOTN_SL.Text = dt_Item.Tables[0].Rows[0]["CETH_CVD_SEC_EDU_CESS_SL"].ToString(); //gv_ItemDetails.Rows[0].Cells[141].Text.Replace("&nbsp;", "");
                    txtCETH_Sec_Edu_Cess_Rate.Text = dt_Item.Tables[0].Rows[0]["CETH_CVD_SEC_EDU_CESS_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[142].Text.Replace("&nbsp;", "");


                    //------------01June2015-----------------//
                    txtOther_Duty_Notn.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[143].Text.Replace("&nbsp;", "");
                    txtOther_Duty_SLNO.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_SLNO"].ToString(); //gv_ItemDetails.Rows[0].Cells[144].Text.Replace("&nbsp;", "");

                    txtOther_Duty_RATE.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[145].Text.Replace("&nbsp;", "");
                    txtOther_Duty_SPL.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_SPL"].ToString(); //gv_ItemDetails.Rows[0].Cells[146].Text.Replace("&nbsp;", "");
                    txtOther_Duty_UNIT.Text = dt_Item.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_UNIT"].ToString(); //gv_ItemDetails.Rows[0].Cells[147].Text.Replace("&nbsp;", "");

                    //ddl_CESS_Type.Items.Clear();
                    //string other_duty_type = dt_Item.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_TYPE"].ToString(); //gv_ItemDetails.Rows[0].Cells[148].Text.Replace("&nbsp;", "");
                    ddlOther_Duty_Type.Items.Remove(dt_Item.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_TYPE"].ToString());
                    ddlOther_Duty_Type.Items.Insert(0, dt_Item.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_TYPE"].ToString());
                    ddlOther_Duty_Type.SelectedIndex = -1;

                    if (dt_Item.Tables[0].Rows[0]["RSP_APPLICABLE"].ToString() == null || dt_Item.Tables[0].Rows[0]["RSP_APPLICABLE"].ToString() == string.Empty)
                    {
                        ddl_RSP_Applicable.SelectedValue = "N";
                    }
                    else
                    {
                        ddl_RSP_Applicable.SelectedValue = dt_Item.Tables[0].Rows[0]["RSP_APPLICABLE"].ToString();
                    }

                    txt_Cus_not_exe_Cen_flag.Text = dt_Item.Tables[0].Rows[0]["CENTRAL_EXCISE_FLAG"].ToString(); //gv_ItemDetails.Rows[0].Cells[159].Text.Replace("&nbsp;", "");
                    txt_Manufacturer_producer.Text = dt_Item.Tables[0].Rows[0]["MANUFACTURER_PRODUCER"].ToString(); // gv_ItemDetails.Rows[0].Cells[160].Text.Replace("&nbsp;", "");
                    txt_Manu_produ_grower_code.Text = dt_Item.Tables[0].Rows[0]["M_P_GROWER_CODE"].ToString(); //gv_ItemDetails.Rows[0].Cells[161].Text.Replace("&nbsp;", "");
                    txt_Manufacturer_Add1.Text = dt_Item.Tables[0].Rows[0]["M_P_GROWER_ADD1"].ToString(); // gv_ItemDetails.Rows[0].Cells[162].Text.Replace("&nbsp;", "");
                    txt_Manufacturer_Add2.Text = dt_Item.Tables[0].Rows[0]["M_P_GROWER_ADD2"].ToString(); //gv_ItemDetails.Rows[0].Cells[163].Text.Replace("&nbsp;", "");
                    txt_Manufacturer_City.Text = dt_Item.Tables[0].Rows[0]["M_P_GROWER_CITY"].ToString(); //gv_ItemDetails.Rows[0].Cells[164].Text.Replace("&nbsp;", "");
                    txt_Manu_Country_Subdiv.Text = dt_Item.Tables[0].Rows[0]["M_P_GROWER_COUNTRY_SUBDIV"].ToString(); //gv_ItemDetails.Rows[0].Cells[165].Text.Replace("&nbsp;", "");
                    txt_Manufacturer_pincode.Text = dt_Item.Tables[0].Rows[0]["M_P_GROWER_PIN"].ToString(); //gv_ItemDetails.Rows[0].Cells[166].Text.Replace("&nbsp;", "");
                    txt_Manufacturer_Country.Text = dt_Item.Tables[0].Rows[0]["M_P_GROWER_COUNTRY"].ToString(); //gv_ItemDetails.Rows[0].Cells[167].Text.Replace("&nbsp;", "");
                    txt_Manu_Source_Country.Text = dt_Item.Tables[0].Rows[0]["SOURCE_COUNTRY"].ToString(); //gv_ItemDetails.Rows[0].Cells[168].Text.Replace("&nbsp;", "");
                    txt_manu_Transit_Country.Text = dt_Item.Tables[0].Rows[0]["TRANSIT_COUNTRY"].ToString(); //gv_ItemDetails.Rows[0].Cells[169].Text.Replace("&nbsp;", "");
                    txt_Accessory_status.Text = dt_Item.Tables[0].Rows[0]["ACCESSORY_STATUS"].ToString(); //gv_ItemDetails.Rows[0].Cells[170].Text.Replace("&nbsp;", "");

                    hdn_chk_Transit_country.Value = Check_CountryName(dt_Item.Tables[0].Rows[0]["TRANSIT_COUNTRY"].ToString(), "TRANSIT_COUNTRY");
                    hdn_chk_Source_country.Value = Check_CountryName(dt_Item.Tables[0].Rows[0]["SOURCE_COUNTRY"].ToString(), "SOURCE_COUNTRY");
                    hdn_chk_Manu_country.Value = Check_CountryName(dt_Item.Tables[0].Rows[0]["M_P_GROWER_COUNTRY"].ToString(), "M_P_GROWER_COUNTRY");


                    txtinfra_cess_Notn.Text = dt_Item.Tables[0].Rows[0]["INFRA_CESS_NOTN"].ToString(); // gv_ItemDetails.Rows[0].Cells[171].Text.Replace("&nbsp;", "");
                    txtinfra_cess_Notn_SLNO.Text = dt_Item.Tables[0].Rows[0]["INFRA_CESS_NOTN_SL"].ToString(); // gv_ItemDetails.Rows[0].Cells[172].Text.Replace("&nbsp;", "");
                    txtinfra_cess_Notn_RATE.Text = dt_Item.Tables[0].Rows[0]["INFRA_CESS_NOTN_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[173].Text.Replace("&nbsp;", "");

                    txt_IGST_LEVY_NOTN.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[174].Text.Replace("&nbsp;", "");
                    txt_IGST_LEVY_SLNO.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_SLNO"].ToString(); //gv_ItemDetails.Rows[0].Cells[175].Text.Replace("&nbsp;", "");
                    txt_IGST_LEVY_RATE.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[176].Text.Replace("&nbsp;", "");
                    txt_IGST_LEVY_SPL_Amt.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_SPL"].ToString(); //gv_ItemDetails.Rows[0].Cells[177].Text.Replace("&nbsp;", "");
                    txt_IGST_LEVY_UNIT.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_UNIT"].ToString(); //gv_ItemDetails.Rows[0].Cells[178].Text.Replace("&nbsp;", "");
                    ddl_IGST_LEVY_SPL_TYPE.SelectedValue = dt_Item.Tables[0].Rows[0]["IGST_LEVY_SPL_TYPE"].ToString(); //gv_ItemDetails.Rows[0].Cells[179].Text.Replace("&nbsp;", "");
                    txt_IGST_LEVY_EXCEPTION_NOTN.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[180].Text.Replace("&nbsp;", "");
                    txt_IGST_LEVY_EXCEPTION_SLNO.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_SLNO"].ToString(); //gv_ItemDetails.Rows[0].Cells[181].Text.Replace("&nbsp;", "");
                    txt_IGST_LEVY_EXCEPTION_RATE.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[182].Text.Replace("&nbsp;", "");
                    txt_IGST_LEVY_COMPENSATION_CESS_NOTN.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[183].Text.Replace("&nbsp;", "");
                    txt_IGST_LEVY_COMPENSATION_CESS_SLNO.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString(); // gv_ItemDetails.Rows[0].Cells[184].Text.Replace("&nbsp;", "");
                    txt_IGST_LEVY_COMPENSATION_CESS_RATE.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[185].Text.Replace("&nbsp;", "");
                    txt_IGST_LEVY_COMPENSATION_CESS_SPL.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_SPL"].ToString(); //gv_ItemDetails.Rows[0].Cells[186].Text.Replace("&nbsp;", "");
                    txt_IGST_LEVY_COMPENSATION_CESS_UNIT.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_UNIT"].ToString(); //gv_ItemDetails.Rows[0].Cells[187].Text.Replace("&nbsp;", "");
                    ddl_IGST_LEVY_COMPENSATION_CESS_SPL_TYPE.SelectedValue = dt_Item.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_SPL_TYPE"].ToString(); //gv_ItemDetails.Rows[0].Cells[188].Text.Replace("&nbsp;", "");
                    txt_IGST_LEVY_EXCEPTION_CC_NOTN.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_CC_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[189].Text.Replace("&nbsp;", "");
                    txt_IGST_LEVY_EXCEPTION_CC_SLNO.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_CC_SLNO"].ToString(); //gv_ItemDetails.Rows[0].Cells[190].Text.Replace("&nbsp;", "");
                    txt_IGST_LEVY_EXCEPTION_CC_RATE.Text = dt_Item.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_CC_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[191].Text.Replace("&nbsp;", "");

                    ddl_LEVY_EXCEMPTION_NOTN_TYPE.SelectedValue = dt_Item.Tables[0].Rows[0]["LEVY_EXCEMPTION_NOTN_TYPE"].ToString(); // gv_ItemDetails.Rows[0].Cells[192].Text.Replace("&nbsp;", "");
                    ddl_LEVY_EXCEPTION_CC_NOTN_TYPE.SelectedValue = dt_Item.Tables[0].Rows[0]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString(); // gv_ItemDetails.Rows[0].Cells[193].Text.Replace("&nbsp;", "");

                    txt_Social_Welfare_NOTN.Text = dt_Item.Tables[0].Rows[0]["SOCIAL_WELFARE_NOTN"].ToString(); //gv_ItemDetails.Rows[0].Cells[194].Text.Replace("&nbsp;", "");
                    txt_Social_Welfare_NOTN_SL.Text = dt_Item.Tables[0].Rows[0]["SOCIAL_WELFARE_NOTN_SLNO"].ToString(); // gv_ItemDetails.Rows[0].Cells[195].Text.Replace("&nbsp;", "");
                    txt_Social_Welfare_Rate.Text = dt_Item.Tables[0].Rows[0]["SOCIAL_WELFARE_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[196].Text.Replace("&nbsp;", "");
                    txtpartno.Text = dt_Item.Tables[0].Rows[0]["PART_NO"].ToString();//Added by pandiyan 13-05-2025
                    if (txt_Social_Welfare_NOTN.Text == "")
                    {
                        txt_Social_Welfare_Rate.Text = "10.00";
                    }

                    if (!string.IsNullOrEmpty(Session["BE_No"].ToString()))
                    {
                        div_AmendmentType.Visible = true;
                        ddl_AmendmentType.SelectedValue = dt_Item.Tables[0].Rows[0]["AMENDMENT_TYPE"].ToString();
                    }

                    //if (gv_ItemDetails.Rows[0].Cells[149].Text.Replace("&nbsp;", "").ToLower() == "true")
                    //{
                    if (dt_Item.Tables[0].Rows[0]["SVB_RELATION"].ToString().Replace("&nbsp;", "").ToLower() == "true")
                    {
                        chkSVB_Relation.Checked = true;
                        txtSVB_RefNo.Text = dt_Item.Tables[0].Rows[0]["SVB_REF_NO"].ToString(); //gv_ItemDetails.Rows[0].Cells[150].Text.Replace("&nbsp;", "");
                        txtSVBDate.Text = dt_Item.Tables[0].Rows[0]["SVB_REF_DATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[151].Text.Replace("&nbsp;", "");
                        txtCustomsHouse_2.Text = dt_Item.Tables[0].Rows[0]["SVB_CUSTOM_HOUSE"].ToString(); //gv_ItemDetails.Rows[0].Cells[152].Text.Replace("&nbsp;", "");

                        //string ddlLoadingOn1 = dt_Item.Tables[0].Rows[0]["SVB_LOADING_ON"].ToString(); //gv_ItemDetails.Rows[0].Cells[153].Text.Replace("&nbsp;", "");
                        ddlLoadingOn.Items.Remove(dt_Item.Tables[0].Rows[0]["SVB_LOADING_ON"].ToString());
                        ddlLoadingOn.Items.Insert(0, dt_Item.Tables[0].Rows[0]["SVB_LOADING_ON"].ToString());
                        txtAssesable_Rate.Text = dt_Item.Tables[0].Rows[0]["SVB_ASSESABLE_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[154].Text.Replace("&nbsp;", "");
                        txtDuty_Rate.Text = dt_Item.Tables[0].Rows[0]["SVB_DUTY_RATE"].ToString(); //gv_ItemDetails.Rows[0].Cells[155].Text.Replace("&nbsp;", "");
                        ddlAssesable_Status.SelectedValue = dt_Item.Tables[0].Rows[0]["SVB_ASSESABLE_STATUS"].ToString(); //gv_ItemDetails.Rows[0].Cells[156].Text.Replace("&nbsp;", "");
                        ddlDuty_Status.SelectedValue = dt_Item.Tables[0].Rows[0]["SVB_DUTY_STATUS"].ToString(); //gv_ItemDetails.Rows[0].Cells[157].Text.Replace("&nbsp;", "");
                        txtSVB_RefNo.Enabled = true;
                        txtSVBDate.Enabled = true;
                        ddlLoadingOn.Enabled = true;
                        //if (gv_ItemDetails.Rows[0].Cells[153].Text.Replace("&nbsp;", "") == "Assessable")
                        //{
                        if (dt_Item.Tables[0].Rows[0]["SVB_LOADING_ON"].ToString() == "Assessable")
                        {
                            txtAssesable_Rate.Enabled = true;
                            ddlAssesable_Status.Enabled = true;
                        }
                        //else if (gv_ItemDetails.Rows[0].Cells[153].Text.Replace("&nbsp;", "") == "Duty")
                        //{
                        else if (dt_Item.Tables[0].Rows[0]["SVB_LOADING_ON"].ToString() == "Duty")
                        {
                            txtDuty_Rate.Enabled = true;
                            ddlDuty_Status.Enabled = true;
                        }
                        //else if (gv_ItemDetails.Rows[0].Cells[153].Text.Replace("&nbsp;", "") == "Both")
                        //{
                        else if (dt_Item.Tables[0].Rows[0]["SVB_LOADING_ON"].ToString() == "Both")
                        {
                            txtAssesable_Rate.Enabled = true;
                            ddlAssesable_Status.Enabled = true;
                            txtDuty_Rate.Enabled = true;
                            ddlDuty_Status.Enabled = true;
                        }
                    }
                    else
                    {
                        chkSVB_Relation.Checked = false;
                        txtSVB_RefNo.Text = string.Empty;
                        txtSVBDate.Text = string.Empty;
                        txtCustomsHouse_2.Text = string.Empty;
                        ddlLoadingOn.SelectedValue = string.Empty;
                        txtAssesable_Rate.Text = string.Empty;
                        ddlAssesable_Status.SelectedValue = string.Empty;
                        txtDuty_Rate.Text = string.Empty;
                        ddlDuty_Status.SelectedValue = string.Empty;
                    }

                    //ddlOther_Duty_Type.Items.Remove(other_duty_type);
                    //ddlOther_Duty_Type.Items.Insert(0, other_duty_type);
                    //ddlOther_Duty_Type.SelectedIndex = -1;

                    //------------01June2015-----------------//
                    ViewState["Invoice_SLNO"] = dt_Item.Tables[0].Rows[0]["INVOICE_SLNO"].ToString(); // gv_ItemDetails.Rows[0].Cells[110].Text.Replace("&nbsp;", "");
                    ViewState["ITEM_SLNO"] = dt_Item.Tables[0].Rows[0]["ITEM_SLNO"].ToString(); //gv_ItemDetails.Rows[0].Cells[111].Text.Replace("&nbsp;", "");
                    ViewState["Invoice_NO"] = dt_Item.Tables[0].Rows[0]["INVOICE_NO"].ToString(); //gv_ItemDetails.Rows[0].Cells[112].Text.Replace("&nbsp;", "");
                    //-----------Calculation For Item Value------------------//

                    ViewState["RUN_ITEM_SL_NO"] = dt_Item.Tables[0].Rows[0]["ITEM_SLNO"].ToString();

                    if ((hdn_Exbond_Val.Value == "Ex-Bond" || hdn_Exbond_Val.Value == "SEZ DTA-T") && hdn_Direct_Exbond_YN.Value == "Y")
                    {
                        lbl_Item_Slno_Dis.Visible = false;
                        txt_ItemSlno.Visible = true;
                        txt_ItemSlno.Text = dt_Item.Tables[0].Rows[0]["ITEM_SLNO"].ToString();
                        lbl_Item_Slno.Text = dt_Item.Tables[0].Rows[0]["ITEM_SLNO"].ToString();
                    }
                    else
                    {
                        lbl_Item_Slno_Dis.Visible = true;
                        txt_ItemSlno.Visible = false;
                        lbl_Item_Slno_Dis.Text = dt_Item.Tables[0].Rows[0]["ITEM_SLNO"].ToString() + ".";
                        lbl_Item_Slno.Text = dt_Item.Tables[0].Rows[0]["ITEM_SLNO"].ToString();
                    }

                    hdn_Item_Edit.Value = "U";
                    hdn_ITEM_AOUNT.Value = txtItem_Amount.Text;
                    //
                    Session.Remove("Invoice_SLNO");
                    Session.Remove("ITEM_SLNO");
                    Session.Remove("Invoice_NO");

                    Session["Invoice_SLNO"] = ViewState["Invoice_SLNO"].ToString();
                    Session["ITEM_SLNO"] = ViewState["ITEM_SLNO"].ToString();
                    Session["Invoice_NO"] = ViewState["Invoice_NO"].ToString();
                    Session["DEBITQTY"] = txtItemQty.Text;
                    Session["UNITQTY"] = txtQtyCode.Text;
                    lblInvoiceNo.Text = ViewState["Invoice_NO"].ToString();
                    //Get_InvoiceValue();
                    btnUpdate.CssClass = "updates";

                    btnSave.Visible = false;
                    btn_save_new.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    //FOR UPDATED SUCCESSFULLY
                    ViewState["UPDATED_ID"] = null;
                    ViewState["UPDATED_ID"] = ViewState["ITEMID"].ToString();
                    //FOR UPDATED SUCCESSFULLY
                    RE_IMPORT.Visible = true;
                    //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//
                    SCHEME_BASED_VISIBLE_LICENSE(schemecode);
                    //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//

                    gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                }
                else
                {

                }
                if (dt_Item.Tables[1].Rows.Count > 0)
                {
                    txt_Info_Msr.Text = dt_Item.Tables[1].Rows[0]["INFO_MSR"].ToString();
                    txt_Info_Uqc.Text = dt_Item.Tables[1].Rows[0]["INFO_UQC"].ToString();
                    hdn_Info_UQC.Value = txt_Info_Uqc.Text;
                }
                else
                {
                    txt_Info_Msr.Text = string.Empty;
                    txt_Info_Uqc.Text = string.Empty;
                }

                string ccr = Copy_CCR(txtCTH_No.Text);
                if (ccr != "")
                {
                    string[] parts = ccr.Split(new string[] { "~~" }, StringSplitOptions.None);

                    txt_CCR.Text = parts[0];
                    lbl_IGST_Default.Text = parts[1];
                }
                else
                {
                    txt_CCR.Text = "";
                    lbl_IGST_Default.Text = "";
                }

                if (Audit_YN == "Y")
                {
                    DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"], "Y");
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void gv_ItemDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddl_ItemSlno.SelectedValue = Convert.ToString(this.gv_ItemDetails.SelectedDataKey.Values[1]) + "_" + (gv_ItemDetails.SelectedIndex + 1).ToString();

            gv_ItemDetails.SelectedRowStyle.Font.Bold = true;
            ViewState["new_id"] = 1;
            ViewState["update_chk"] = +1;
            ViewState["Move_up_down_chk"] = 2;

            GridViewRow firstRow = gv_ItemDetails.Rows[0];
            if (Convert.ToString(ViewState["id"]) == "1")
            {
                int ID;
                ID = gv_ItemDetails.SelectedIndex;
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
                ID = gv_ItemDetails.SelectedIndex;

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

            ViewState["Delete_ID"] = gv_ItemDetails.SelectedIndex;
            ViewState["ITEMID"] = Convert.ToString(this.gv_ItemDetails.SelectedDataKey.Value);
            ViewState["ITEM_SLNO"] = Convert.ToString(this.gv_ItemDetails.SelectedDataKey.Values[1]);

            if (ViewState["ITEMID"] != "" && ViewState["ITEMID"] != null)
            {
                Edit_FirstItem_UpdateDetails(ViewState["ITEMID"].ToString());
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    public void SCHEME_BASED_VISIBLE_LICENSE(string schemecode)
    {
        try
        {
            if (schemecode.Contains("DUTIABLE") || schemecode.Contains("JBG") || schemecode.Contains("REP") || schemecode.Contains("DIL") || schemecode.Contains("EOU"))
                LICENCE.Visible = false;
            else

                LICENCE.Visible = true;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Get_InvoiceValue()
    {
        try
        {
            Transact.JOBNO = IMPORT_JOBNO;
            //Transact.INVOICE_NO = Session["Invoice_NO"].ToString().Replace("amp;","");
            Transact.INVOICE_NO = Session["Invoice_NO"].ToString();
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.flag = "INVOICE_VALUE";
            Transact.TERMS = "";
            Transact.INVOICE_SLNO = "";
            dss = Transact.RetrieveAll_Invoice_Details();
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    lblInvoiceValue.Text = dss.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    lblInvoiceValue.Text = "";
                }
            }
            else
            {
                lblInvoiceValue.Text = "";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void gv_ItemDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            var row = e.Row;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                {
                    if (ViewState["Newbtn"] == null)
                    {
                        e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                        e.Row.Font.Bold = true;
                        //  e.Row.Font.Bold = true;
                        ViewState["id"] = "1";
                    }
                    if (ViewState["Newbtn"] == "Delete")
                    {
                        e.Row.BackColor = System.Drawing.Color.White;
                        //e.Row.Font.Bold = false;
                    }

                }



                var des2 = row.Cells[2].Text.Replace("&nbsp;", "");//ITEM_ID
                var des3 = row.Cells[3].Text.Replace("&nbsp;", "");//ItemSlNo
                var des4 = row.Cells[4].Text.Replace("&nbsp;", "");
                var des5 = row.Cells[5].Text.Replace("&nbsp;", "");
                var des6 = row.Cells[6].Text.Replace("&nbsp;", "");
                var des7 = row.Cells[7].Text.Replace("&nbsp;", "");
                var des8 = row.Cells[8].Text.Replace("&nbsp;", "");
                var des9 = row.Cells[9].Text.Replace("&nbsp;", "");
                var des10 = row.Cells[10].Text.Replace("&nbsp;", "");

                row.Cells[2].ToolTip = des2;
                row.Cells[4].ToolTip = des4;
                row.Cells[5].ToolTip = des5;
                row.Cells[7].ToolTip = des7;
                row.Cells[6].ToolTip = des6;
                row.Cells[8].ToolTip = des8;
                row.Cells[9].ToolTip = des9;
                row.Cells[10].ToolTip = des10;

                if (hdn_Exbond_Val.Value != "Ex-Bond" && hdn_Direct_Exbond_YN.Value != "Y")//19-10-2024
                {
                    gv_ItemDetails.HeaderRow.Cells[3].Attributes["class"] = "hideGridColumn";
                    row.Cells[3].CssClass = "hideGridColumn";
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
                    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_ItemDetails, "Select$" + e.Row.RowIndex.ToString()));
                    gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                    e.Row.CssClass = "normal_2";
                }
                //  if Read Permiision given true for gridview enabled or Disabled----------//

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void gv_ItemDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gv_ItemDetails.PageIndex = e.NewPageIndex;
            string item_slno = "0", item_id = "0", flag = "select_con";
            Gridbind_ItemDetails(ddlInvoice_SlNo.SelectedValue.ToString(), item_slno, item_id, flag);
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
            Item_Avail = Check_Item_Slno_Avail("Check_Item_Slno_Avail_Update", ViewState["ITEMID"].ToString());

            if (Item_Avail != "Exists")
            {
                hdn_FTA_Transit_chk.Value = CHK_FTA_Transit_Country(txtCountryOrigin.Text, txtBasicNotn.Text, txtSAPTA_NOTN.Text);

                if (hdn_FTA_Transit_chk.Value == "Yes")
                {
                    string chk;
                    if (chkMRP_Duty.Checked == true)
                    {
                        chk = "Y";
                        txtMRP_SL_NO.Enabled = true;
                        txtMRP_AMOUNT.Enabled = true;
                        txtMRP_ABT_RATE.Enabled = true;
                        ddl_RSP_Applicable.Enabled = true;
                    }
                    else
                    {
                        chk = "N";
                        txtMRP_SL_NO.Enabled = false;
                        txtMRP_AMOUNT.Enabled = false;
                        txtMRP_ABT_RATE.Enabled = false;
                        ddl_RSP_Applicable.Enabled = false;
                    }
                    if (txtPrevious_Be_Date.Text == "")
                    {
                        Previous_Be_Date = "01/01/1900";
                    }
                    else
                    {
                        Previous_Be_Date = txtPrevious_Be_Date.Text;
                    }
                    a3 = chk; a4 = "U"; a5 = ""; a6 = Previous_Be_Date;
                    a1 = HiddenField1.Value;
                    a2 = ddlInvoice_SlNo.SelectedValue.ToString();
                    //a7 = ViewState["ITEM_SLNO"].ToString();

                    if ((hdn_Exbond_Val.Value == "Ex-Bond" || hdn_Exbond_Val.Value == "SEZ DTA-T") && hdn_Direct_Exbond_YN.Value == "")
                    {
                        a7 = lbl_Item_Slno.Text;
                    }
                    //else if (hdn_Exbond_Val.Value == "Ex-Bond" && hdn_Direct_Exbond_YN.Value == "Y")
                    //{
                    //    a7 = txt_ItemSlno.Text;
                    //}
                    else
                    {
                        a7 = ViewState["ITEM_SLNO"].ToString();
                    }

                    decimal sum = 0.0m, Totsum = 0.0m, Tally_amt = 2.0m;
                    int Update_id = 0;

                    if (COMPANY_IDD == "1124")
                    {
                        Tally_amt = 50000.0m;
                    }

                    Update_id = Convert.ToInt32(a7) - 1;

                    sum = Check_Sum_Higher_Value_SaveUpdate(a7);

                    /* hide by Chithra on 18-05-2018 
                   //for (int M = 0; M < gv_ItemDetails.Rows.Count; M++)
                   //{
                   //    if (M != Update_id)
                   //    {
                   //        sum += Convert.ToDecimal(gv_ItemDetails.Rows[M].Cells[7].Text);
                   //    }
                   //}
                   */

                    if ((hdn_Exbond_Val.Value == "Ex-Bond" || hdn_Exbond_Val.Value == "SEZ DTA-T") && hdn_Direct_Exbond_YN.Value == "")
                    {
                        txtItem_Amount.Text = hdn_ITEM_AOUNT.Value;
                        txtItem_UnitPrice.Text = hdn_UnitPrice.Value;
                    }

                    Totsum = sum + Convert.ToDecimal(txtItem_Amount.Text);


                    //STARCOM - higher than Invoice Value should save - don't show the alert msg - done by Chithra on 28-11-2022
                    if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "555" || Connection.COMPANYID() == "859" || Connection.COMPANYID() == "867" || Connection.COMPANYID() == "2188" || Connection.COMPANYID() == "2787" || Connection.COMPANYID() == "3431" || Connection.COMPANYID() == "4046" || Connection.COMPANYID() == "4070")
                    {
                        Totsum = Convert.ToDecimal(lblInvoiceValue.Text);
                    }

                    if (Totsum <= (Convert.ToDecimal(lblInvoiceValue.Text) + Tally_amt))
                    {
                        if ((hdn_Exbond_Val.Value == "Ex-Bond" || hdn_Exbond_Val.Value == "SEZ DTA-T") && hdn_Direct_Exbond_YN.Value == "Y")
                        {
                            a7 = txt_ItemSlno.Text;
                        }

                        Item_Details_insert_update(a1, a2, a3, a4, a5, a6, a7);
                        string inv_no = Transact.UPDATE_INVOICE_NO;
                        if (i == 1 || i == 3)
                        {
                            //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//
                            SCHEME_BASED_VISIBLE_LICENSE(ddlSchemeCode.SelectedValue.ToString());
                            //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//

                            if (ViewState["UPDATED_ID"] != null)
                            {
                                if (i == 3)
                                {
                                    string prompt = "<script>$(document).ready(function(){{jAlert('Higher Than Invoice Value', 'PRODUCT', function (r) {var i = r + 'ok';if (i == 'trueok'){jAlert('Product Updated Successfully', 'PRODUCT', function (r) {document.getElementById('btnUpdate').focus()});;} else {}});}});</script>";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                                }
                                else
                                    Alert_msg("Product Updated Successfully", "btnUpdate");
                            }
                            else
                            {
                                if (i == 3)
                                {
                                    string prompt = "<script>$(document).ready(function(){{jAlert('Higher Than Invoice Value', 'PRODUCT', function (r) {var i = r + 'ok';if (i == 'trueok'){jAlert('Product Saved Successfully', 'PRODUCT', function (r) {document.getElementById('btnUpdate').focus()});;} else {}});}});</script>";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

                                }
                                else
                                    Alert_msg("Product Saved Successfully", "btnUpdate");

                            }
                            Session.Remove("Invoice_SLNO");
                            Session.Remove("ITEM_SLNO");
                            Session.Remove("Invoice_NO");
                            Session.Remove("SCHEME_CODE");

                            Session["Invoice_NO"] = inv_no;
                            Session["Invoice_SLNO"] = a2;
                            Session["ITEM_SLNO"] = ViewState["ITEM_SLNO"].ToString();
                            Session["DEBITQTY"] = txtItemQty.Text;
                            Session["UNITQTY"] = txtQtyCode.Text;
                            Session["SCHEME_CODE"] = ddlSchemeCode.SelectedValue.ToString();


                            // ----Audit Modified Data -----------------------------------
                            if (Audit_YN == "Y")
                            {
                                Audit_Modified_DataTableComparer();
                            }
                            //------------------------------------------------------------
                        }
                        else if (i == 2)
                        {
                            Alert_msg("Invoice No Already Exist!", "btnUpdate");
                        }
                        else
                        {
                            Alert_msg("Product Not Updated", "btnUpdate");
                        }

                        Get_ProductValue();

                        if (Convert.ToInt32(ViewState["update_chk"]) == 0)
                        {
                            GridViewRow firstRow = gv_ItemDetails.Rows[0];
                            firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                            firstRow.Font.Bold = true;
                            gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                        }
                    }
                    else
                    {
                        MP_U.Show();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>OtherDuty_tab_FTA();</script>", false);
                }
            }
            else
            {
                Alert_msg("Item Sl.No Already Exist!", "btnSave");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Newbtn"] = "Delete";
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = ViewState["Invoice_SLNO"].ToString();
            Transact.INVOICE_NO = lblInvoiceNo.Text;
            Transact.ITEM_SLNO = ViewState["ITEM_SLNO"].ToString();
            Transact.ITEM_ID = ViewState["ITEMID"].ToString();
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "delete";
            gv_ItemDetails.DataSource = Transact.RetrieveAll_Item_Details();
            gv_ItemDetails.DataBind();
            lblProductValue.Text = Transact.TOTAL_ITEM_VALUE;
            int ii = 0;
            ii = Transact.result;

            if (ii > 0)
            {
                Session.Remove("Invoice_SLNO");
                Session.Remove("ITEM_SLNO");
                Session.Remove("Invoice_NO");
                btnNew_Click(sender, e);
                hdn_Item_Edit.Value = "";
                hdn_ITEM_AOUNT.Value = "";
                btnSave.Visible = true;
                btn_save_new.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                Alert_msg("Product Deleted");

                Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), ViewState["Invoice_SLNO"].ToString(), ViewState["ITEM_SLNO"].ToString(), "Item", "D", "Insert");
            }
            else
            {
                Alert_msg("Product Not Deleted");
            }

            Get_ProductValue();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void gv_ItemDetails_RowCreated(object sender, GridViewRowEventArgs e)
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

    public void Grid_Empty()
    {
        try
        {
            if (dt_Item_all.Tables.Count > 0)
            {
                if (dt_Item_all.Tables[0].Rows.Count > 0)
                {
                    gv_ItemDetails.DataSource = dt_Item_all;

                    gv_ItemDetails.DataBind();
                    //Item_Move_UpDown_Enable();

                    if (gv_ItemDetails.Rows.Count > 0)
                    {
                        ViewState["ITEMID"] = gv_ItemDetails.Rows[0].Cells[2].Text.Replace("&nbsp;", "");
                        Edit_FirstItem_UpdateDetails(ViewState["ITEMID"].ToString());

                        //if (ddl_ItemSlno.SelectedValue != "")
                        //{
                        //    Edit_FirstItem_UpdateDetails(ViewState["ITEMID"].ToString(), ddlInvoice_SlNo.SelectedValue.ToString(), ddl_ItemSlno.SelectedItem.Text);
                        //}
                        //else
                        //{
                        //    Edit_FirstItem_UpdateDetails(ViewState["ITEMID"].ToString(), ddlInvoice_SlNo.SelectedValue.ToString(), "0");
                        //}
                    }
                }
                else
                {
                    gv_ItemDetails.DataSource = dt;//add empty row
                    gv_ItemDetails.DataBind();
                    btn_New();
                }
            }
            else
            {

                gv_ItemDetails.DataSource = dt;//add empty row
                gv_ItemDetails.DataBind();
            }

            dt_Item_all.Dispose();
            GC.Collect();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Grid_Save_Update_Empty()
    {
        try
        {
            // dss (returned by the Insert/Update stored proc call) only reflects the row
            // just written, not the full item list - re-fetch all items for this invoice
            // via a fresh Transaction instance (so we don't clobber Transact's output
            // parameters - result/TOTAL_ITEM_VALUE/UPDATE_ITEMSLNO/Gridview_Rowcount -
            // that the caller reads right after this method returns).
            Transaction TransactGridRefresh = new Transaction();
            TransactGridRefresh.JOBNO = IMPORT_JOBNO;
            TransactGridRefresh.INVOICE_SLNO = ddlInvoice_SlNo.SelectedValue.ToString();
            TransactGridRefresh.ITEM_SLNO = "0";
            TransactGridRefresh.ITEM_ID = "0";
            TransactGridRefresh.WORKING_PERIOD = SELECT_BRANCH;
            TransactGridRefresh.Ename = "select_con_GridBind_New";
            DataSet dssAllItems = TransactGridRefresh.RetrieveAll_Item_Details();

            if (dssAllItems.Tables.Count > 0 && dssAllItems.Tables[0].Rows.Count > 0)
            {
                gv_ItemDetails.DataSource = dssAllItems;
                gv_ItemDetails.DataBind();
                //Item_Move_UpDown_Enable();
            }
            else
            {
                gv_ItemDetails.DataSource = dt;//add empty row
                gv_ItemDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }

    protected void ddlInvoice_SlNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //string item_slno = "0", item_id = "0", flag = "select_Invoice_No";
            hdn_Manufacture_Name.Value = "";

            string item_slno = "0", item_id = "0", flag = "select_con_GridBind_New";
            if (ddl_ItemSlno.SelectedValue != "")
            {
                Gridbind_ItemDetails(ddlInvoice_SlNo.SelectedValue.ToString(), ddl_ItemSlno.SelectedItem.Text, item_id, flag);
            }
            else
            {
                Gridbind_ItemDetails(ddlInvoice_SlNo.SelectedValue.ToString(), item_id, item_id, flag);
            }

            //Invoice_Details_Bind();//29-03-2025
            //Get_ProductValue();//29-03-2025

            Bind_Invoice_Item_Select_New("ddl_Change", ddlInvoice_SlNo.SelectedValue.ToString());

            grid_row_color_change2();
            ViewState["update_chk"] = 0;
            Bind_ItemSl_No();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    void grid_row_color_change2()
    {
        try
        {
            if (gv_ItemDetails.Rows.Count > 0)
            {
                GridViewRow firstRow = gv_ItemDetails.Rows[0];
                firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                firstRow.Font.Bold = true;

                gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                gv_ItemDetails.SelectedRowStyle.Font.Bold = false;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    private void grid_row_color_change()
    {
        try
        {
            if (gv_ItemDetails.Rows.Count > 0)
            {
                gv_ItemDetails.SelectedRowStyle.Font.Bold = true;

                if (ViewState["Newbtn"] == "btnNew" || gv_ItemDetails.Rows.Count == 1)
                {
                    GridViewRow firstRow = gv_ItemDetails.Rows[0];
                    firstRow.BackColor = System.Drawing.Color.White;
                    firstRow.Font.Bold = false;

                    if (Convert.ToInt32(ViewState["btnsave"]) == 1)
                    {
                        GridViewRow FR = gv_ItemDetails.Rows[0];
                        FR.BackColor = System.Drawing.Color.White;

                        GridViewRow saverow = gv_ItemDetails.Rows[gv_ItemDetails.Rows.Count - 1];
                        saverow.BackColor = System.Drawing.Color.White;
                        ViewState["btnsave"] = "0";
                    }
                }
                if (ViewState["Newbtn"] == "btnsave")
                {
                    gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                    GridViewRow firstRow = gv_ItemDetails.Rows[gv_ItemDetails.Rows.Count - 1];
                    firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                }
                if (ViewState["Newbtn"] != "btnNew" && gv_ItemDetails.Rows.Count != 1 && ViewState["Newbtn"] != "btnsave")
                {
                    GridViewRow firstRow = gv_ItemDetails.Rows[0];
                    firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                    gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void scheme_NOTN()
    {
        try
        {
            string str = ddlSchemeCode.SelectedValue.ToString();
            string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);

            ddlScheme_NOTN.Items.Clear();
            ddlScheme_NOTN_SL.Items.Clear();

            if (s1[0].Trim().ToString() != "00")
            {
                adm.SCHEME_IMPORT_CODE = s1[0].ToString();
                adm.SCHEME_NOTN = "0";
                adm.name = "SCHEME_NOTN";
                ddlScheme_NOTN.DataSource = adm.RetrieveAll_Scheme_Import();
                ddlScheme_NOTN.DataTextField = "SCHEME_NOTN";
                ddlScheme_NOTN.DataValueField = "SCHEME_NOTN";
                ddlScheme_NOTN.Items.Add(" ");
                ddlScheme_NOTN.DataBind();
                //--7-2r
                scheme_notn_slno();

            }
            else
            {
                ddlScheme_NOTN.Items.Clear();
                ddlScheme_NOTN_SL.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void scheme_notn_slno()
    {
        try
        {
            string str = ddlSchemeCode.SelectedValue;
            string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);
            ddlScheme_NOTN_SL.Items.Clear();

            adm.SCHEME_IMPORT_CODE = s1[0].ToString();
            adm.SCHEME_NOTN = ddlScheme_NOTN.SelectedValue;
            adm.name = "SCHEME_NOTN_SLNO";
            ddlScheme_NOTN_SL.DataSource = adm.RetrieveAll_Scheme_Import();
            ddlScheme_NOTN_SL.DataTextField = "SCHEME_NOTN_SLNO";
            ddlScheme_NOTN_SL.DataValueField = "SCHEME_NOTN_SLNO";
            ddlScheme_NOTN_SL.Items.Add(" ");
            ddlScheme_NOTN_SL.DataBind();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void ddlSchemeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
            {
                scheme_NOTN();
                CTH_NOTN_Same_As_IGST_NOTN();
                //hide on 25-06-2026 by George Bush for Grid hiding issue
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>CTH_tab();</script>", false);
                ScriptManager.RegisterStartupScript(this,this.GetType(),"SwitchTab","setTimeout(function(){ CTH_tab(); }, 150);",true);                 
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    protected void ddlScheme_NOTN_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
            {
                ddlScheme_NOTN_SL.Enabled = true;
                scheme_notn_slno();
                CTH_NOTN_Same_As_IGST_NOTN();
                //hide on 25-06-2026 by George Bush for Grid hiding issue
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>CTH_tab();</script>", false);
                ScriptManager.RegisterStartupScript(this,this.GetType(),"SwitchTab","setTimeout(function(){ CTH_tab(); }, 150);",true);                 
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    /*
    protected void txtItem_UnitPrice_TextChanged(object sender, EventArgs e)
    {
        string f = "";
            if (txtItemQty.Text != "")
            {
                if (txtItem_UnitPrice.Text != "")
                {
                    if (hdn_Item_Edit.Value != "")
                    {

                        if (hdn_ITEM_AOUNT.Value == "")
                            f = "0";
                        else
                            f = hdn_ITEM_AOUNT.Value;

                        ITEM_UNITPRICE_CALC(f);
                    }
                    else
                    {
                        if (txtItem_Amount.Text == "")
                            f = "0";
                        else
                            f = txtItem_Amount.Text;

                        ITEM_UNITPRICE_CALC(f);

                    }
                }
                else
                {
                    Alert_msg("Enter UnitPrice", "txtItem_UnitPrice");
                }
            }

            else
            {
                Alert_msg("Enter Qty", "txtItemQty");

            }
            txtItem_UnitPrice.Focus();
    }
    */

    /*
    protected void txtItemQty_TextChanged(object sender, EventArgs e)
    {
        if (txtItemQty.Text != "")
        {
            decimal f;
            if (hdn_Item_Edit.Value != "")
            {
                if (hdn_ITEM_AOUNT.Value == "")
                    f = 0;
                else
                    f = Convert.ToDecimal(hdn_ITEM_AOUNT.Value);

                ITEM_QTY_CALC(f);
            }
            else
            {
                if (txtItem_Amount.Text == "")
                    f = 0;
                else
                {
                    f = Convert.ToDecimal(txtItem_Amount.Text);
                }
                ViewState["ITEMID"] = "0";
                ITEM_QTY_CALC(f);
            }
        }
        else
        {
            Alert_msg("Enter Qty");
        }
        txtItemQty.Focus();
    }
    */

    public void ITEM_QTY_CALC(decimal TOTAL)
    {
        try
        {

            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedValue.ToString();
            Transact.QTY = txtItemQty.Text;
            Transact.ITEM_VALUE = TOTAL;
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "QTY";
            Transact.Flag = hdn_Item_Edit.Value;

            Transact.ITEM_ID = HiddenField1.Value;
            txtItem_UnitPrice.Text = Convert.ToString(Transact.RetrieveAll_());
            double amt = Convert.ToDouble(txtItemQty.Text) * Convert.ToDouble(txtItem_UnitPrice.Text);
            txtItem_Amount.Text = Convert.ToString(Math.Round(amt, 2));
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void ITEM_UNITPRICE_CALC(string TOTAL)
    {
        try
        {
            decimal amt = Convert.ToDecimal(txtItemQty.Text) * Convert.ToDecimal(txtItem_UnitPrice.Text);
            txtItem_Amount.Text = Convert.ToString(amt);
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedValue.ToString();
            Transact.QTY = txtItemQty.Text;
            Transact.ITEM_VALUE = amt;
            Transact.Flag = hdn_Item_Edit.Value;
            Transact.ITEM_ID = HiddenField1.Value;
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "UNITPRICE";
            decimal i = Convert.ToInt32(Transact.RetrieveAll_());
            if (i == 2)
            {
                if (gv_ItemDetails.Rows.Count != 0)
                    Alert_msg("Higher than invoice value");

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void btn_New()
    {
        try
        {
            ViewState["Newbtn"] = "btnNew";
            grid_row_color_change();


            string Item_Desc = txtDescription.Text,
            Item_Amount_Unitcode = txtItem_AmountCode.Text,
            Item_UnitPriceCode = txtItem_UnitPriceCode.Text,
            RITCNO = txtCTH_No.Text,

            countryorigin = txtCountryOrigin.Text,
            Unitqty = txtQtyCode.Text,
            schemecode = ddlSchemeCode.SelectedValue.ToString(),
            scheme_notn = ddlScheme_NOTN.SelectedValue.ToString(),
            scheme_notn_slno = ddlScheme_NOTN_SL.SelectedValue.ToString(),
            invoice_slno = ddlInvoice_SlNo.SelectedItem.ToString(),
            manufacture = txtManufacturer.Text,
            invoice_no = ddlInvoice_SlNo.SelectedValue.ToString(),

               //--------------Notification-------------------------//

            BasicNotn = txtBasicNotn.Text,
            BasicSLNO = txtBasicSLNO.Text,
            BasicRate = txtBasicRate.Text,
            BasicSPL = txtBasicSPL.Text,
            BasicUnit = txtBasicUnit.Text,

            AddlDuty_NOTN = txtAddlDuty_NOTN.Text,
            AddlDuty_NOTN_SL = txtAddlDuty_NOTN_SL.Text,
            AddlDuty_Rate = txtAddlDuty_Rate.Text,

            Edu_Cess_NOTN = txtEdu_Cess_NOTN.Text,
            Edu_Cess_NOTN_SL = txtEdu_Cess_NOTN_SL.Text,
            Edu_Cess_Rate = txtEdu_Cess_Rate.Text,

            Sec_Edu_Cess_NOTN = txtSec_Edu_Cess_NOTN.Text,
            Sec_Edu_Cess_NOTN_SL = txtSec_Edu_Cess_NOTN_SL.Text,
            Sec_Edu_Cess_Rate = txtSec_Edu_Cess_Rate.Text,

            CVD_NOTN = txt_CVD_NOTN.Text,
            CVD_SLNO = txt_CVD_SLNO.Text,
            CVD_RATE = txt_CVD_RATE.Text,
            CVD_SPL = txt_CVD_SPL.Text,
            CVD_UNIT = txt_CVD_UNIT.Text,
            EndUse = txtEndUse.Text,
            Brand = txtBrand.Text,
            Model = txtModel.Text,

            IGST_LEVY_NOTN = txt_IGST_LEVY_NOTN.Text,
            IGST_LEVY_SLNO = txt_IGST_LEVY_SLNO.Text,
            IGST_LEVY_RATE = txt_IGST_LEVY_RATE.Text,
            IGST_LEVY_SPL_Amt = txt_IGST_LEVY_SPL_Amt.Text,
            IGST_LEVY_UNIT = txt_IGST_LEVY_UNIT.Text,

            IGST_LEVY_EXCEPTION_NOTN = txt_IGST_LEVY_EXCEPTION_NOTN.Text,
            IGST_LEVY_EXCEPTION_SLNO = txt_IGST_LEVY_EXCEPTION_SLNO.Text,
            IGST_LEVY_EXCEPTION_RATE = txt_IGST_LEVY_EXCEPTION_RATE.Text,
            IGST_LEVY_EXCEMPTION_NOTN_TYPE = ddl_LEVY_EXCEMPTION_NOTN_TYPE.SelectedValue,

            IGST_LEVY_COMPENSATION_CESS_NOTN = txt_IGST_LEVY_COMPENSATION_CESS_NOTN.Text,
            IGST_LEVY_COMPENSATION_CESS_SLNO = txt_IGST_LEVY_COMPENSATION_CESS_SLNO.Text,
            IGST_LEVY_COMPENSATION_CESS_RATE = txt_IGST_LEVY_COMPENSATION_CESS_RATE.Text,
            IGST_LEVY_COMPENSATION_CESS_SPL = txt_IGST_LEVY_COMPENSATION_CESS_SPL.Text,
            IGST_LEVY_COMPENSATION_CESS_UNIT = txt_IGST_LEVY_COMPENSATION_CESS_UNIT.Text,

            IGST_LEVY_EXCEPTION_CC_NOTN = txt_IGST_LEVY_EXCEPTION_CC_NOTN.Text,
            IGST_LEVY_EXCEPTION_CC_SLNO = txt_IGST_LEVY_EXCEPTION_CC_SLNO.Text,
            IGST_LEVY_EXCEPTION_CC_RATE = txt_IGST_LEVY_EXCEPTION_CC_RATE.Text,

            SAPTA_NOTN = txtSAPTA_NOTN.Text,
            SAPTA_NOTN_SL = txtSAPTA_NOTN_SL.Text,
            SAPTA_RATE = txtSAPTA_RATE.Text,

            AIDC_NOTN = txt_AIDC_NOTN.Text,
            AIDC_NOTN_SLNO = txt_AIDC_NOTN_SLNO.Text,
            AIDC_RATE = txt_AIDC_RATE.Text,
            ADD_EX_RATE = txt_ADD_ExRate.Text,

            EXC_AIDC_NOTN = txt_Exc_AIDC_NOTN.Text,
            EXC_AIDC_NOTN_SLNO = txt_Exc_AIDC_NOTN_SLNO.Text,
            EXC_AIDC_RATE = txt_Exc_AIDC_RATE.Text,


           //ANTI_DUMP_NOTN = ddlAntiDumping_Notn.SelectedItem.Text,//08-05-2021
           ANTI_DUMP_NOTN = txt_AntiDumping_Notn.Text,
                //ANTI_DUMP_NOTN_SLNO = ddlAntiDumping_Notn_SL.SelectedItem.Text,
           CTH_SL_No = txtCTH_SL_No.Text,
           CTH_Supplier_SL = txtCTH_Supplier_SL.Text,

           SOCIAL_WELFARE_NOTN = txt_Social_Welfare_NOTN.Text,
           SOCIAL_WELFARE_NOTN_SL = txt_Social_Welfare_NOTN_SL.Text,
           SOCIAL_WELFARE_RATE = txt_Social_Welfare_Rate.Text,

           INFRA_CESS = txtinfra_cess_Notn.Text,
           INFRA_CESS_SLNO = txtinfra_cess_Notn_SLNO.Text,
           INFRA_CESS_RATE = txtinfra_cess_Notn_RATE.Text,
           INFRA_CESS_SPL = txtinfra_cess_SPL.Text,
           INFRA_CESS_SPL_UNIT = txtinfra_cess_SPL_UNIT.Text,

           Cus_not_exe_Cen_flag = txt_Cus_not_exe_Cen_flag.Text,
           Manufacturer_Add1 = txt_Manufacturer_Add1.Text,
           Manufacturer_Add2 = txt_Manufacturer_Add2.Text,
           Manufacturer_City = txt_Manufacturer_City.Text,
           Manu_Country_Subdiv = txt_Manu_Country_Subdiv.Text,
           Manufacturer_pincode = txt_Manufacturer_pincode.Text,
           Manufacturer_Country = txt_Manufacturer_Country.Text,
           Manu_Source_Country = txt_Manu_Source_Country.Text,
           manu_Transit_Country = txt_manu_Transit_Country.Text,
           Accessory_status = txt_Accessory_status.Text,
           HealthCessNotn = txt_Addl_Health_CESS_NOTN.Text,
           HealthCessNotn_slno = txt_Addl_Health_CESS_SLNO.Text,
           HealthCess_Rate = txt_Addl_Health_CESS_RATE.Text;

            string ANTI_DUMP_NOTN_SLNO = "";
            /* hide on 08-05-2021 by Chithra Sugg.by Bala sir      
            if (ddlAntiDumping_Notn.SelectedItem.Text != "")
            {
                ANTI_DUMP_NOTN_SLNO = ddlAntiDumping_Notn_SL.SelectedItem.Text;
            }
            */

            ANTI_DUMP_NOTN_SLNO = txt_AntiDumping_Notn_SL.Text;//08-05-2021

            //-----------End Notification-------------------------//


            //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//
            SCHEME_BASED_VISIBLE_LICENSE(schemecode);
            //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//

            Transact.ResetFields(Page.Controls);

            txt_AIDC_NOTN.Text = AIDC_NOTN;
            txt_AIDC_NOTN_SLNO.Text = AIDC_NOTN_SLNO;
            txt_AIDC_RATE.Text = AIDC_RATE;
            txt_ADD_ExRate.Text = ADD_EX_RATE;

            txt_Exc_AIDC_NOTN.Text = EXC_AIDC_NOTN;
            txt_Exc_AIDC_NOTN_SLNO.Text = EXC_AIDC_NOTN_SLNO;
            txt_Exc_AIDC_RATE.Text = EXC_AIDC_RATE;

            if (COMPANY_IDD != "2145")
            {
                txtDescription.Text = Item_Desc;
            }

            txtCTH_No.Text = RITCNO;
            txtQtyCode.Text = Unitqty;
            txtItem_UnitPriceCode.Text = Item_UnitPriceCode;

            txtItem_AmountCode.Text = Item_Amount_Unitcode;
            txtCTHNO.Text = RITCNO;
            txtRITCNO.Text = RITCNO;
            txtCETH_No.Text = RITCNO;

            txtCountryOrigin.Text = countryorigin;

            //--------------Notification-------------------------//

            txtBasicNotn.Text = BasicNotn;
            txtBasicSLNO.Text = BasicSLNO;
            txtBasicRate.Text = BasicRate;
            txtBasicSPL.Text = BasicSPL;
            txtBasicUnit.Text = BasicUnit;

            txtAddlDuty_NOTN.Text = AddlDuty_NOTN;
            txtAddlDuty_NOTN_SL.Text = AddlDuty_NOTN_SL;
            txtAddlDuty_Rate.Text = AddlDuty_Rate;

            txtEdu_Cess_NOTN.Text = Edu_Cess_NOTN;
            txtEdu_Cess_NOTN_SL.Text = Edu_Cess_NOTN_SL;
            txtEdu_Cess_Rate.Text = Edu_Cess_Rate;

            txtSec_Edu_Cess_NOTN.Text = Sec_Edu_Cess_NOTN;
            txtSec_Edu_Cess_NOTN_SL.Text = Sec_Edu_Cess_NOTN_SL;
            txtSec_Edu_Cess_Rate.Text = Sec_Edu_Cess_Rate;

            txt_CVD_NOTN.Text = CVD_NOTN;
            txt_CVD_SLNO.Text = CVD_SLNO;
            txt_CVD_RATE.Text = CVD_RATE;
            txt_CVD_SPL.Text = CVD_SPL;
            txt_CVD_UNIT.Text = CVD_UNIT;


            txt_IGST_LEVY_NOTN.Text = IGST_LEVY_NOTN;
            txt_IGST_LEVY_SLNO.Text = IGST_LEVY_SLNO;
            txt_IGST_LEVY_RATE.Text = IGST_LEVY_RATE;
            txt_IGST_LEVY_SPL_Amt.Text = IGST_LEVY_SPL_Amt;
            txt_IGST_LEVY_UNIT.Text = IGST_LEVY_UNIT;

            txt_IGST_LEVY_EXCEPTION_NOTN.Text = IGST_LEVY_EXCEPTION_NOTN;
            txt_IGST_LEVY_EXCEPTION_SLNO.Text = IGST_LEVY_EXCEPTION_SLNO;
            txt_IGST_LEVY_EXCEPTION_RATE.Text = IGST_LEVY_EXCEPTION_RATE;
            ddl_LEVY_EXCEMPTION_NOTN_TYPE.SelectedValue = IGST_LEVY_EXCEMPTION_NOTN_TYPE;

            txt_IGST_LEVY_COMPENSATION_CESS_NOTN.Text = IGST_LEVY_COMPENSATION_CESS_NOTN;
            txt_IGST_LEVY_COMPENSATION_CESS_SLNO.Text = IGST_LEVY_COMPENSATION_CESS_SLNO;
            txt_IGST_LEVY_COMPENSATION_CESS_RATE.Text = IGST_LEVY_COMPENSATION_CESS_RATE;
            txt_IGST_LEVY_COMPENSATION_CESS_SPL.Text = IGST_LEVY_COMPENSATION_CESS_SPL;
            txt_IGST_LEVY_COMPENSATION_CESS_UNIT.Text = IGST_LEVY_COMPENSATION_CESS_UNIT;

            txt_IGST_LEVY_EXCEPTION_CC_NOTN.Text = IGST_LEVY_EXCEPTION_CC_NOTN;
            txt_IGST_LEVY_EXCEPTION_CC_SLNO.Text = IGST_LEVY_EXCEPTION_CC_SLNO;
            txt_IGST_LEVY_EXCEPTION_CC_RATE.Text = IGST_LEVY_EXCEPTION_CC_RATE;

            txtSAPTA_NOTN.Text = SAPTA_NOTN;
            txtSAPTA_NOTN_SL.Text = SAPTA_NOTN_SL;
            txtSAPTA_RATE.Text = SAPTA_RATE;

            //ddlAntiDumping_Notn.SelectedItem.Text = ANTI_DUMP_NOTN;
            //ddlAntiDumping_Notn_SL.SelectedItem.Text = ANTI_DUMP_NOTN_SLNO;


            txt_AntiDumping_Notn.Text = ANTI_DUMP_NOTN;
            txt_AntiDumping_Notn_SL.Text = ANTI_DUMP_NOTN_SLNO;
            txtCTH_SL_No.Text = CTH_SL_No;
            txtCTH_Supplier_SL.Text = CTH_Supplier_SL;

            txt_Social_Welfare_NOTN.Text = SOCIAL_WELFARE_NOTN;
            txt_Social_Welfare_NOTN_SL.Text = SOCIAL_WELFARE_NOTN_SL;
            txt_Social_Welfare_Rate.Text = SOCIAL_WELFARE_RATE;

            txtinfra_cess_Notn.Text = INFRA_CESS;
            txtinfra_cess_Notn_SLNO.Text = INFRA_CESS_SLNO;
            txtinfra_cess_Notn_RATE.Text = INFRA_CESS_RATE;
            txtinfra_cess_SPL.Text = INFRA_CESS_SPL;
            txtinfra_cess_SPL_UNIT.Text = INFRA_CESS_SPL_UNIT;



            txt_Cus_not_exe_Cen_flag.Text = Cus_not_exe_Cen_flag;
            txt_Manufacturer_Add1.Text = Manufacturer_Add1;
            txt_Manufacturer_Add2.Text = Manufacturer_Add2;
            txt_Manufacturer_City.Text = Manufacturer_City;
            txt_Manu_Country_Subdiv.Text = Manu_Country_Subdiv;
            txt_Manufacturer_pincode.Text = Manufacturer_pincode;
            txt_Manufacturer_Country.Text = Manufacturer_Country;
            txt_Manu_Source_Country.Text = Manu_Source_Country;
            txt_manu_Transit_Country.Text = manu_Transit_Country;
            txt_Accessory_status.Text = Accessory_status;
            txt_Addl_Health_CESS_NOTN.Text = HealthCessNotn;
            txt_Addl_Health_CESS_SLNO.Text = HealthCessNotn_slno;
            txt_Addl_Health_CESS_RATE.Text = HealthCess_Rate;


            //-----------End Notification-------------------------//

            ddlSchemeCode.Items.Remove(schemecode);
            ddlSchemeCode.Items.Insert(0, schemecode);
            ddlSchemeCode.SelectedIndex = -1;

            ddlScheme_NOTN.Items.Remove(scheme_notn);
            ddlScheme_NOTN.Items.Insert(0, scheme_notn);
            ddlScheme_NOTN.SelectedIndex = -1;

            ddlScheme_NOTN_SL.Items.Remove(scheme_notn_slno);
            ddlScheme_NOTN_SL.Items.Insert(0, scheme_notn_slno);
            ddlScheme_NOTN_SL.SelectedIndex = -1;

            ddlInvoice_SlNo.Items.Remove(ddlInvoice_SlNo.Items.FindByText(invoice_slno));

            ddlInvoice_SlNo.Items.Insert(0, new ListItem(invoice_slno, invoice_no));
            ddlInvoice_SlNo.SelectedIndex = -1;

            /* hide on 08-05-2021 by Chithra Sugg.by Bala sir
            if (ANTI_DUMP_NOTN_SLNO != "")
            {
                ddlAntiDumping_Notn_SL.SelectedItem.Text = ANTI_DUMP_NOTN_SLNO;
            }
            */

            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btn_save_new.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_Update_Item.Value = "";
            //Invoice_Details_Bind();
            txtManufacturer.Text = manufacture;
            //txtBrand.Text = "N.A";
            //txtModel.Text = "N.A";
            txtEndUse.Text = EndUse;
            txtBrand.Text = Brand;
            txtModel.Text = Model;
            //if (COMPANY_IDD == "247")
            //{
            //    txtEndUse.Text = EndUse;
            //    txt_Accessory_status.Text = "0";
            //}
            //else
            //{
            //    txtEndUse.Text = string.Empty;
            //}

            txt_CVD_Education_CESS_Rate.Text = "013/2012";
            txt_CVD_Education_CESS_SL.Text = "1";
            txtCVD_Edu_Cess_Rate.Text = "0.00";

            txtRSP_Slno.Text = "1";
            Session.Remove("Invoice_SLNO");
            Session.Remove("ITEM_SLNO");
            Session.Remove("Invoice_NO");

            Session["Invoice_SLNO"] = ddlInvoice_SlNo.SelectedValue.ToString();

            Session.Remove("DEBITQTY");
            Session.Remove("UNITQTY");
            RE_IMPORT.Visible = false;
            LICENCE.Visible = false;
            hdn_Item_Edit.Value = "";

            if (string.IsNullOrWhiteSpace(Is_NewItem))//check when selected ddl invoice no
            {
                if (gv_ItemDetails.Rows.Count > 0)
                {
                    lbl_Item_Slno.Text = Convert.ToString(Convert.ToInt32(gv_ItemDetails.Rows.Count + 1));
                    //lbl_Item_Slno_Dis.Text = Convert.ToString(Convert.ToInt32(gv_ItemDetails.Rows.Count + 1)) + ".";
                    lbl_Item_Slno_Dis.Text = lbl_Item_Slno.Text + ".";
                }
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
            btn_New();
            Bind_ItemSl_No();
            Bind_ItemSl_No_MAX();
            gv_ItemDetails.SelectedRowStyle.Font.Bold = false;

            if (Convert.ToInt32(ViewState["new_id"]) != 0)
            {
                gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                ViewState["new_id"] = 0;
            }
            if (HDsaveid.Value == "1")
            {
                gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                GridViewRow saverow = gv_ItemDetails.Rows[gv_ItemDetails.Rows.Count - 1];
                saverow.BackColor = System.Drawing.Color.White;
                saverow.Font.Bold = false;
                HDsaveid.Value = "0";
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Item_Moving(string mobileId, string previousId, string mobilePriority, string flag)
    {
        try
        {
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedValue.ToString();
            Transact.INVOICE_NO = mobileId;
            Transact.ITEM_SLNO = mobilePriority;
            Transact.ITEM_ID = previousId;//Previousid
            Transact.WORKING_PERIOD = SELECT_BRANCH;

            Transact.Ename = flag;
            dss = Transact.RetrieveAll_Item_Details();
            if (dss.Tables[0].Rows.Count == 0)
            {
                hdn_Grid_Count.Value = "";
            }
            else
            {

                hdn_Grid_Count.Value = "1";
                dt_Item_all = dss;
            }
            Grid_Empty();
            i = Transact.result;

            hdn_Grid_RowCount.Value = Convert.ToString(Transact.Gridview_Rowcount);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void gv_ItemDetails_RowDataCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            btnNew_Click(sender, e);
            int index = 0;
            GridViewRow gvrow;
            GridViewRow previousRow;
            if (e.CommandName == "Up")
            {
                index = Convert.ToInt32(e.CommandArgument);
                gvrow = gv_ItemDetails.Rows[index];
                previousRow = gv_ItemDetails.Rows[index - 1];
                string mobilePriority = gvrow.Cells[111].Text;//ITEM_SLNO
                string mobileId = gvrow.Cells[133].Text;//ITEM_ID
                string previousId = previousRow.Cells[111].Text;//ITEM_SLNO
                Item_Moving(mobileId, previousId, mobilePriority, "Item_Move");
            }
            if (e.CommandName == "Down")
            {
                index = Convert.ToInt32(e.CommandArgument);
                gvrow = gv_ItemDetails.Rows[index];
                previousRow = gv_ItemDetails.Rows[index + 1];
                string mobilePriority = gvrow.Cells[111].Text;//ITEM_SLNO
                string mobileId = gvrow.Cells[133].Text;//ITEM_ID
                string previousId = previousRow.Cells[111].Text;//ITEM_SLNO
                Item_Moving(mobileId, previousId, mobilePriority, "Item_Move");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'PRODUCT', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'PRODUCT', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Call_Server_Side_Method()
    {
        try
        {
            /* hide on 08-05-2021 by Chithra Sugg.by Bala sir
            ddlAntiDumping_Notn_SL.Attributes.Add("onchange", "javascript:CallServerside_AntiDumping('" + ddlAntiDumping_Notn.ClientID + "', '" + ddlAntiDumping_Notn_SL.ClientID + "')");
            ddlAntiDumping_Notn_SL.Attributes.Add("onblur", "javascript:CallServerside_AntiDumping('" + ddlAntiDumping_Notn.ClientID + "', '" + ddlAntiDumping_Notn_SL.ClientID + "')");
            */

            txt_AntiDumping_Notn_SL.Attributes.Add("onchange", "javascript:CallServerside_AntiDumping('" + txt_AntiDumping_Notn.ClientID + "', '" + txt_AntiDumping_Notn_SL.ClientID + "')");
            txt_AntiDumping_Notn_SL.Attributes.Add("onblur", "javascript:CallServerside_AntiDumping('" + txt_AntiDumping_Notn.ClientID + "', '" + txt_AntiDumping_Notn_SL.ClientID + "')");

            /* hide  by Chithra on 22-12-2021 sugg.By Bala sir for Paramount
            txtCTH_SL_No.Attributes.Add("onblur", "javascript:CallServerside_AntiDumping_CTH_SLNO('" + txt_AntiDumping_Notn.ClientID + "', '" + txt_AntiDumping_Notn_SL.ClientID + "', '" + txtCTH_SL_No.ClientID + "')");
            */
            // txtCTH_No.Attributes.Add("onblur", "javascript:CallServerside_RSPDetails('" + txtCTH_No.ClientID + "', '" + txtCTH_No.ClientID + "')");
            //txtDescription.Attributes.Add("onblur", "javascript:CallServerside_RITC('" + txtDescription.ClientID + "', '" + txtCTH_No.ClientID + "')");



            if (COMPANY_IDD != "4")
            {

                //txtItemQty.Attributes.Add("onkeyup", "javascript:extractNumber(this,6,false);Clear_Dot(this);CallServerside_GetItemQty('" + txtItemQty.ClientID + "', '" + txtItem_UnitPrice.ClientID + "')");

                /*
                if (COMPANY_IDD == "1051")
                {
                    txtItem_Amount.Attributes.Add("onblur", "javascript:extractNumber(this,6,false);Clear_Dot(this);CallServerside_GetItem_amount('" + txtItem_UnitPrice.ClientID + "', '" + txtItem_Amount.ClientID + "')");
                }
                else
                {
                    txtItem_Amount.Attributes.Add("onkeyup", "javascript:extractNumber(this,6,false);Clear_Dot(this);CallServerside_GetItem_amount('" + txtItem_UnitPrice.ClientID + "', '" + txtItem_Amount.ClientID + "')");
                }
                */
            }

            // txtItem_UnitPrice.Attributes.Add("onkeyup", "javascript:extractNumber(this,6,false);Clear_Dot(this);CallServerside_GetItem_UnitPrice('" + txtItem_UnitPrice.ClientID + "', '" + txtItem_Amount.ClientID + "')");

            ///------------------------------------------------auto search-----------------------------------------------------------------
            //RITC NO for ABT RATE

            txtCTH_No.Attributes.Add("onblur onchange", "javascript:Call_SW_Agency_CTH_CODE('" + txtCTH_No.ClientID + "')");

            txtCTH_No.Attributes.Add("onblur onfocus", "javascript:Call_Rsp_Rate('" + txtCTH_No.ClientID + "', '" + txtRSP_Abt_Rate.ClientID + "');javascript:Call_CTH_Rate('" + txtCTH_No.ClientID + "', '" + txtRSP_Abt_Rate.ClientID + "');javascript:Call_CETH_Rate('" + txtCETH_No.ClientID + "', '" + txtRSP_Abt_Rate.ClientID + "');javascript:Call_SW_Agency_CTH_CODE('" + txtCTH_No.ClientID + "')");


            txtCTHNO.Attributes.Add("onblur onfocus", "javascript:Call_CTH_Rate('" + txtCTHNO.ClientID + "', '" + txtRSP_Abt_Rate.ClientID + "')");
            //txtCETH_No.Attributes.Add("onblur onfocus", "javascript:Call_CETH_Rate('" + txtCETH_No.ClientID + "', '" + txtRSP_Abt_Rate.ClientID + "')");

            txtCETH_No.Attributes.Add("onblur onfocus", "javascript:Call_Rsp_Rate_New('" + txtCETH_No.ClientID + "', '" + txtRSP_Abt_Rate.ClientID + "');javascript:Call_CTH_Rate('" + txtCTH_No.ClientID + "', '" + txtRSP_Abt_Rate.ClientID + "');javascript:Call_CETH_Rate('" + txtCETH_No.ClientID + "', '" + txtRSP_Abt_Rate.ClientID + "')");



            //txtCTH_No.Attributes.Add("onblur onchange", "javascript:Call_GST_CTH_CODE('" + txtCTH_No.ClientID + "')");


            txtCTH_No.Attributes.Add("onblur onchange", "javascript:Call_GST_CTH_CODE('" + txtCTH_No.ClientID + "')");


            //txtCTH_No.Attributes.Add("onblur onchange", "javascript:Call_AIDC_Master('" + txtCTH_No.ClientID + "')");// hide on 15-04-2021 by Chithra

            txtCTH_No.Attributes.Add("onblur onfocusout", "javascript:Call_CTH_Rate_SplAmount('" + txtCTH_No.ClientID + "')");
            btnUpdate.Attributes.Add("onblur click", "javascript:Call_CTH_Rate_SplAmount('" + txtCTH_No.ClientID + "')");

            //RITC NO for ABT RATE
            //////------------------------------------------------CTH-----------------------------------------------------------------  
            //--------------------------------------------------NOTN-----------------------------------------------------------------------------------------------------

            ////BASIC_DUTY_CTH
            //txtBasicNotn.Attributes.Add("onblur", "javascript:CallServerside_Basic_Duty_Cth_Notn_No('" + txtBasicNotn.ClientID + "', '" + txtBasicSLNO.ClientID + "')");
            ////BASIC_DUTY_CTH

            ////ADD_DUTY_CTH
            //txtAddlDuty_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Cth_Notn('" + txtAddlDuty_NOTN.ClientID + "', '" + txtAddlDuty_NOTN_SL.ClientID + "')");
            ////ADD_DUTY_CTH

            ////Edu_Cess_Cth
            //txtEdu_Cess_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Edu_Cess_Cth_Notn('" + txtEdu_Cess_NOTN.ClientID + "', '" + txtEdu_Cess_NOTN_SL.ClientID + "')");
            ////Edu_Cess_Cth

            ////Sec_Higher_Edu_Cth
            //txtSec_Edu_Cess_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Sec_Higher_Edu_Cth_Notn('" + txtSec_Edu_Cess_NOTN.ClientID + "', '" + txtSec_Edu_Cess_NOTN_SL.ClientID + "')");
            ////Sec_Higher_Edu_Cth

            ////NCD_Cth
            //txtNCD_NOTN.Attributes.Add("onblur", "javascript:CallServerside_NCD_Cth_Notn('" + txtNCD_NOTN.ClientID + "', '" + txtNCD_SLNO.ClientID + "')");
            ////NCD_Cth

            ////Aggregate_Duty_Cth
            //txtAggregate_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Aggregate_Duty_Cth_Notn('" + txtAggregate_NOTN.ClientID + "', '" + txtAggregate_NOTN_SL.ClientID + "')");
            ////Aggregate_Duty_Cth

            ////SafeGuard_Duty_Cth
            //txtSafeguard_NOTN.Attributes.Add("onblur", "javascript:CallServerside_SafeGuard_Duty_Cth_Notn('" + txtSafeguard_NOTN.ClientID + "', '" + txtSafeguard_SL.ClientID + "')");
            ////SAPTA_NOTN_Cth
            ////SafeGuard_Duty_Cth
            //txtSAPTA_NOTN.Attributes.Add("onblur", "javascript:CallServerside_SAPTA_NOTN_Cth_Notn('" + txtSAPTA_NOTN.ClientID + "', '" + txtSAPTA_NOTN_SL.ClientID + "')");
            ////SAPTA_NOTN_Cth

            //--------------------------------------------------NOTN-----------------------------------------------------------------------------------------------------
            //--------------------------------------------------NOTNSL---------------------------------------------------------------------------------------------------
            //BASIC_DUTY_CTH
            txtBasicSLNO.Attributes.Add("onBlur", "javascript:CallServerside_Basic_Duty_Cth_Notn_Slno('" + txtBasicSLNO.ClientID + "', '" + txtBasicNotn.ClientID + "')");

            //BASIC_DUTY_CTH

            //ADD_DUTY_CTH
            txtAddlDuty_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Cth_Notn_Slno('" + txtAddlDuty_NOTN_SL.ClientID + "', '" + txtAddlDuty_NOTN.ClientID + "')");
            //ADD_DUTY_CTH

            //Edu_Cess_Cth
            txtEdu_Cess_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Edu_Cess_Cth_Notn_Slno('" + txtEdu_Cess_NOTN_SL.ClientID + "', '" + txtEdu_Cess_NOTN.ClientID + "')");
            //Edu_Cess_Cth

            //Social_Welfare_Cth
            txt_Social_Welfare_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Social_Welfare_Notn_Slno('" + txt_Social_Welfare_NOTN_SL.ClientID + "', '" + txt_Social_Welfare_NOTN.ClientID + "')");
            //Social_Welfare_Cth

            //CETH_Edu_Cess_Cth-----S
            txt_CVD_Education_CESS_SL.Attributes.Add("onblur", "javascript:CallServerside_CETH_Edu_Cess_Cth_Notn_Slno('" + txt_CVD_Education_CESS_SL.ClientID + "', '" + txt_CVD_Education_CESS_Rate.ClientID + "')");
            //CETH_Edu_Cess_Cth-----E

            //CETH_Sec_Higher_Edu_Cth-----S
            txtCETH_Sec_Edu_Cess_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_CETH_Sec_Higher_Edu_Cth_Notn_Slno('" + txtCETH_Sec_Edu_Cess_NOTN_SL.ClientID + "', '" + txt_CVD_Sec_Edu_CESS_Rate.ClientID + "')");
            //CETH_Sec_Higher_Edu_Cth-----E


            //Sec_Higher_Edu_Cth
            txtSec_Edu_Cess_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Sec_Higher_Edu_Cth_Notn_Slno('" + txtSec_Edu_Cess_NOTN_SL.ClientID + "', '" + txtSec_Edu_Cess_NOTN.ClientID + "')");
            //Sec_Higher_Edu_Cth

            //NCD_Cth
            txtNCD_SLNO.Attributes.Add("onblur", "javascript:CallServerside_NCD_Cth_Notn_Slno('" + txtNCD_SLNO.ClientID + "', '" + txtNCD_NOTN.ClientID + "')");
            //NCD_Cth

            //Aggregate_Duty_Cth
            txtAggregate_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Aggregate_Duty_Cth_Notn_Slno('" + txtAggregate_NOTN_SL.ClientID + "', '" + txtAggregate_NOTN.ClientID + "')");
            //Aggregate_Duty_Cth

            //SafeGuard_Duty_Cth
            txtSafeguard_SL.Attributes.Add("onblur", "javascript:CallServerside_SafeGuard_Duty_Cth_Notn_Slno('" + txtSafeguard_SL.ClientID + "', '" + txtSafeguard_NOTN.ClientID + "')");
            //SafeGuard_Duty_Cth
            txtSAPTA_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_SAPTA_NOTN_Cth_Notn_Slno('" + txtSAPTA_NOTN_SL.ClientID + "', '" + txtSAPTA_NOTN.ClientID + "')");
            //SAPTA_NOTN_Cth
            //--------------------------------------------------NOTNSL---------------------------------------------------------------------------------------------------

            ///------------------------------------------------CTH---------------------------------------------------------------------
            ///
            //////------------------------------------------------CETH-----------------------------------------------------------------
            //--------------------------------------------------NOTN---------------------------------------------------------------------------------------------------
            ////CVD_CETH
            //txt_CVD_NOTN.Attributes.Add("onblur", "javascript:CallServerside_CVD_Duty_Ceth_Notn_No('" + txt_CVD_NOTN.ClientID + "', '" + txt_CVD_SLNO.ClientID + "')");
            ////CVD_CETH

            ////Addl_CETH
            //txt_Addl5_SIA_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Ceth_Notn_No('" + txt_Addl5_SIA_NOTN.ClientID + "', '" + txt_Addl5_SIA_NOTN_SL.ClientID + "')");
            ////Addl_CETH

            ////Addl_GSI_CETH
            //txt_Addl_GSI_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Excise_GSI_Ceth_Notn_No('" + txt_Addl_GSI_NOTN.ClientID + "', '" + txt_Addl_GSI_SL.ClientID + "')");
            ////Addl_GSI_CETH

            ////Addl_SHE11_NOTN
            //txt_Addl_SHE11_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Spl_Excise_Duty_Ceth_Notn_No('" + txt_Addl_SHE11_NOTN.ClientID + "', '" + txt_Addl_SHE11_SLNO.ClientID + "')");
            ////Addl_SHE11_NOTN

            ////Addl_TTA_SLNO
            //txt_Addl_TTA_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Excise_TTA_Ceth_Notn_No('" + txt_Addl_TTA_NOTN.ClientID + "', '" + txt_Addl_TTA_SLNO.ClientID + "')");
            ////Addl_TTA_SLNO

            ////Addl_Health_CESS_SLNO
            //txt_Addl_Health_CESS_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Health_Cess_Ceth_Notn_No('" + txt_Addl_Health_CESS_NOTN.ClientID + "', '" + txt_Addl_Health_CESS_SLNO.ClientID + "')");
            ////Addl_Health_CESS_SLNO

            ////CESS_SLNO
            //txt_CESS_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Cess_Notn_Ceth_Notn_No('" + txt_CESS_NOTN.ClientID + "', '" + txt_CESS_SLNO.ClientID + "')");
            ////CESS_SLNO
            //--------------------------------------------------NOTN---------------------------------------------------------------------------------------------------
            //--------------------------------------------------NOTNSL---------------------------------------------------------------------------------------------------

            //CVD_CETH
            txt_CVD_SLNO.Attributes.Add("onblur", "javascript:CallServerside_CVD_Duty_Ceth_Notn_SlNo('" + txt_CVD_SLNO.ClientID + "', '" + txt_CVD_NOTN.ClientID + "')");
            //CVD_CETH

            //Addl_CETH
            txt_Addl5_SIA_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Ceth_Notn_SlNo('" + txt_Addl5_SIA_NOTN_SL.ClientID + "', '" + txt_Addl5_SIA_NOTN.ClientID + "')");
            //Addl_CETH

            //Addl_GSI_CETH
            txt_Addl_GSI_SL.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Excise_GSI_Ceth_Notn_SlNo('" + txt_Addl_GSI_SL.ClientID + "', '" + txt_Addl_GSI_NOTN.ClientID + "')");
            //Addl_GSI_CETH

            //Addl_SHE11_NOTN
            txt_Addl_SHE11_SLNO.Attributes.Add("onblur", "javascript:CallServerside_Spl_Excise_Duty_Ceth_Notn_SlNo('" + txt_Addl_SHE11_SLNO.ClientID + "', '" + txt_Addl_SHE11_NOTN.ClientID + "')");
            //Addl_SHE11_NOTN

            //Addl_TTA_SLNO
            txt_Addl_TTA_SLNO.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Excise_TTA_Ceth_Notn_SlNo('" + txt_Addl_TTA_SLNO.ClientID + "', '" + txt_Addl_TTA_NOTN.ClientID + "')");
            //Addl_TTA_SLNO

            //Addl_Health_CESS_SLNO
            txt_Addl_Health_CESS_SLNO.Attributes.Add("onblur", "javascript:CallServerside_Health_Cess_Ceth_Notn_SlNo('" + txt_Addl_Health_CESS_SLNO.ClientID + "', '" + txt_Addl_Health_CESS_NOTN.ClientID + "')");
            //Addl_Health_CESS_SLNO

            //CESS_SLNO
            txt_CESS_SLNO.Attributes.Add("onblur", "javascript:CallServerside_Cess_Notn_Ceth_Notn_SlNo('" + txt_CESS_SLNO.ClientID + "', '" + txt_CESS_NOTN.ClientID + "')");
            //CESS_SLNO

            //infra_cess
            txtinfra_cess_Notn_SLNO.Attributes.Add("onblur", "javascript:CallServerside_infra_cess_Notn_SLNO('" + txtinfra_cess_Notn_SLNO.ClientID + "', '" + txtinfra_cess_Notn.ClientID + "')");
            //infra_cess

            //txtRSP_Notn_No.Attributes.Add("onblur", "javascript:CallServerside_RSP_Notn_SLNO_Rate('" + txtCETH_No.Text + "', '" + txtRSP_Notn_No.Text + "')");

            //--------------------------------------------------NOTNSL---------------------------------------------------------------------------------------------------
            ///------------------------------------------------CETH-----------------------------------------------------------------

            //IGST
            txt_IGST_LEVY_SLNO.Attributes.Add("onblur", "javascript:CallServerside_txt_IGST_LEVY_SLNO('" + txt_IGST_LEVY_SLNO.ClientID + "', '" + txt_IGST_LEVY_NOTN.ClientID + "')");
            txt_IGST_LEVY_EXCEPTION_SLNO.Attributes.Add("onblur", "javascript:CallServerside_txt_IGST_LEVY_EXCEPTION_SLNO('" + txt_IGST_LEVY_EXCEPTION_SLNO.ClientID + "', '" + txt_IGST_LEVY_EXCEPTION_NOTN.ClientID + "')");
            txt_IGST_LEVY_COMPENSATION_CESS_SLNO.Attributes.Add("onblur", "javascript:CallServerside_txt_IGST_LEVY_COMPENSATION_CESS_SLNO('" + txt_IGST_LEVY_COMPENSATION_CESS_SLNO.ClientID + "', '" + txt_IGST_LEVY_COMPENSATION_CESS_NOTN.ClientID + "')");
            txt_IGST_LEVY_EXCEPTION_CC_SLNO.Attributes.Add("onblur", "javascript:CallServerside_txt_IGST_LEVY_EXCEPTION_CC_SLNO('" + txt_IGST_LEVY_EXCEPTION_CC_SLNO.ClientID + "', '" + txt_IGST_LEVY_EXCEPTION_CC_NOTN.ClientID + "')");

            txtCTH_No.Attributes.Add("onblur", "javascript:Call_IGST_CTH_CODE('" + txtCTH_No.ClientID + "')");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    //-------------------------------------------------------
    //----------------IGST 01-June-2017---S-------------

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_txt_IGST_LEVY_SLNO_1E(string Notn_no_sl, string Notn_no)
    {
        try
        {
            string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", Address8 = "", Address9 = "";
            if (Notn_no != "")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_SLNO_IGST_1E";
                Auto.Enamesearch = Notn_no_sl;
                Auto.Notn_No_Search = Notn_no;

                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                    Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                    Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();
                }
            }
            Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Notn_no_sl;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_txt_IGST_LEVY_SLNO_1L(string Notn_no_sl, string Notn_no)
    {
        try
        {
            string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", Address8 = "", Address9 = "";

            if (Notn_no != "")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_SLNO_IGST_1L";
                Auto.Enamesearch = Notn_no_sl;
                Auto.Notn_No_Search = Notn_no;

                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                    Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                    Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();

                }
            }
            Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Notn_no_sl;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_txt_IGST_LEVY_SLNO_2E(string Notn_no_sl, string Notn_no)
    {
        try
        {
            string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", Address8 = "", Address9 = "";

            if (Notn_no != "")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_SLNO_IGST_2E";
                Auto.Enamesearch = Notn_no_sl;
                Auto.Notn_No_Search = Notn_no;

                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                    Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                    Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();
                }
            }
            Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Notn_no_sl;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_txt_IGST_LEVY_SLNO_2L(string Notn_no_sl, string Notn_no)
    {
        try
        {
            string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", Address8 = "", Address9 = "";

            if (Notn_no != "")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_SLNO_IGST_2L";
                Auto.Enamesearch = Notn_no_sl;
                Auto.Notn_No_Search = Notn_no;

                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                    Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                    Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();

                }
            }
            Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;
          
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Notn_no_sl;
    }

    //------------------------------------------------------------------------------------------

    [System.Web.Services.WebMethod]
    public static string Get_RSP_Notn_SlNo_Rate1(string custid)
    {
        string values = "";
        try
        {
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Enamesearch = custid;
            Auto.Ename = "RSP_MASTER_Get_Notn_Slno";
            Auto.Notn_No_Search = custid;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
           
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    string vv = ds.Tables[0].Rows[i]["RSP_NOTN"].ToString();
                    values += vv + ",";
                }
            }
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return values;
    }

    [System.Web.Services.WebMethod]
    public static string Get_RITC(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "IMP_ITEM_DESC_SEARCH";
            Auto.Enamesearch = custid;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string CTH_NO = ds.Tables[0].Rows[0]["CTH_NO"].ToString();
                custid = CTH_NO;
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
    public static string Get_RSPDetails(string custid)
    {
        try
        {
            DataSet ds = new DataSet();
            adminmaster adm = new adminmaster();
            adm.ERSP_cthno = custid;
            adm.startRowIndex = "0";
            adm.maximumRows = "0";
            adm.Ename = "RSP_CTH_NO_SEARCH";
            adm.RetrieveAll_RSP_master();
            string Address1 = adm.ERSP_id;
            custid = Address1;
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_AntiDumping(string custid, string Notn_Slno)
    {
        try
        {
            DataSet ds = new DataSet();
            adminmaster adm = new adminmaster();
            adm.SCHEME_IMPORT_CODE = custid;
            adm.SCHEME_NOTN = Notn_Slno;
            adm.name = "ANTIDUMP_NOTNSLNO_SEARCH";
            ds = adm.RetrieveAll_Scheme_Import();

            if (ds.Tables[0].Rows.Count == 1)
            {
                string Address1 = ds.Tables[0].Rows[0]["ADD_CTH"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["ADD_SUP_SLNO"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["ADD_ANTI_AMTS"].ToString();
                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Notn_Slno;
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_AntiDumping_CTH_SLno(string custid, string Notn_Slno, string CTH_SLno)
    {
        try
        {
            DataSet ds = new DataSet();
            adminmaster adm = new adminmaster();
            adm.SCHEME_IMPORT_CODE = custid + "~" + Notn_Slno;
            adm.SCHEME_NOTN = CTH_SLno;
            adm.name = "ANTIDUMP_CTH_SLNO_SEARCH";
            ds = adm.RetrieveAll_Scheme_Import();

            if (ds.Tables[0].Rows.Count == 1)
            {
                string Address1 = ds.Tables[0].Rows[0]["ADD_CTH"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["ADD_SUP_SLNO"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["ADD_ANTI_AMTS"].ToString();
                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Notn_Slno;
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Custom_Master_CTH_NOTN_NO(string Notn_no, string Notn_no_sl)
    {
        try
        {
            string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "";

            if (Notn_no != "" && Notn_no != "019/2006")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_NO";
                Auto.Enamesearch = Notn_no_sl;
                Auto.Notn_No_Search = Notn_no;

                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN"].ToString();
                    Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN_SL"].ToString();
                    Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                    Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString();
                    Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString();
                    if (Address5 == "-1")
                        Address5 = "";
                }
            }
            Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6;
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Notn_no_sl;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Custom_Master_CTH_NOTN_SLNO(string Notn_no_sl, string Notn_no)
    {
        try
        {
            string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "";
            if (Notn_no != "" && Notn_no != "019/2006")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_SLNO";
                Auto.Enamesearch = Notn_no_sl;
                Auto.Notn_No_Search = Notn_no;
                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN"].ToString();
                    Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN_SL"].ToString();
                    Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                    Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString();
                    Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString();
                    if (Address5 == "-1")
                        Address5 = "";
                }
            }
            Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6;
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Notn_no_sl;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Custom_Master_CTH_NOTN_SLNO_with_Type(string Notn_no_sl, string Notn_no, string Notn_Type)//search with Type
    {
        try
        {
            string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", IsValidNotn = "";
            if (Notn_no != "" && Notn_no != "019/2006")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_SLNO_with_Type";//1st check with "SWS" Type
                Auto.Enamesearch = Notn_no_sl;
                Auto.Notn_No_Search = Notn_no;
                Auto.Notn_Type = Notn_Type;

                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    IsValidNotn = "Y";
                }
                else
                {
                    Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_SLNO";//2nd check with "C"
                    ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IsValidNotn = "Y";
                    }
                }

                if (IsValidNotn == "Y")
                {
                    Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN"].ToString();
                    Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN_SL"].ToString();
                    Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                    Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString();
                    Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString();
                    if (Address5 == "-1")
                        Address5 = "";
                }
            }
            Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6;
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Notn_no_sl;
    }


    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_CETH_NOTN_NO(string Notn_no, string Notn_no_sl)
    {
        try
        {
            string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", Address8 = "", Address9 = "";

            if (Notn_no != "")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_NO";
                Auto.Enamesearch = Notn_no_sl;
                Auto.Notn_No_Search = Notn_no;

                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN"].ToString();
                    Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN_SL"].ToString();
                    Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                    Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                    if (Address5 == "-1")
                        Address5 = "";
                    Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();
                    Address7 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_RATE"].ToString();
                    Address8 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_SPL"].ToString();
                    Address9 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_UNIT"].ToString();

                }
            }
            Notn_no = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;

            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Notn_no;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_CETH_NOTN_SLNO(string Notn_no_sl, string Notn_no)
    {
        try
        {
            string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", Address8 = "", Address9 = "";

            if (Notn_no != "")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_SLNO";
                Auto.Enamesearch = Notn_no_sl;
                Auto.Notn_No_Search = Notn_no;

                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN"].ToString();
                    Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN_SL"].ToString();
                    Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                    Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                    if (Address5 == "-1")
                        Address5 = "";
                    Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();
                    Address7 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_RATE"].ToString();
                    Address8 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_SPL"].ToString();
                    Address9 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_UNIT"].ToString();

                }
            }
            Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;

            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Notn_no_sl;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Custom_Master(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL";
            Auto.Enamesearch = custid;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN_SL"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString();
                string Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString();
                custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6;
            }
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "NOTIFICATIONC_EXCISE_MASTER_ALL";
            Auto.Enamesearch = custid;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN_SL"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                string Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();
                string Address7 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_RATE"].ToString();
                string Address8 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_SPL"].ToString();
                string Address9 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_UNIT"].ToString();

                custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;
            }
          
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_RSP_Rate(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            string name = "RSP_MASTER";
            string rows = "RSP_RATE";
            custid = Auto.Country_Master_FromClientSide_Calling(custid, name, rows);
            if (Auto.Ename != "1")
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

    //[System.Web.Services.WebMethod]
    //public static string Get_SW_CTH_CODE_MASTER(string custid)
    //{
    //    try
    //    {
    //        Auto_Search Auto = new Auto_Search();
    //        string name = "SW_CTH_CODE_MASTER_SELECT";
    //        string rows = "AGENCY_CODE";
    //        custid = Auto.SingleWindow_CTH_Code_FromClientSide_Calling(custid, name, rows);
    //        if (Auto.Ename != "1")
    //        {
    //            custid = "";
    //        }
           
    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }
    //    return custid;
    //}
    [System.Web.Services.WebMethod]
    public static string Get_SW_CTH_CODE_MASTER(string custid)
    {
        string result = "";
        try
        {
            
            Auto_Search Auto = new Auto_Search();
            string name = "SW_CTH_CODE_MASTER_SELECT";
            string rows = "AGENCY_CODE";
            result = Auto.SingleWindow_CTH_Code_FromClientSide_Calling(custid, name, rows);
            if (Auto.Ename != "1")
            {
                result = "";
            }

            // Added by shanthini on 18-09-2026
            eroyalmaster Emas = new eroyalmaster();
            Emas.SW_FROM_CTH = custid;
            Emas.Ename = "select_by_cth";
            DataSet ds_userwise = Emas.RetrieveAll_SingleWindow_UserWise_master();

            if (ds_userwise != null && ds_userwise.Tables.Count > 0 && ds_userwise.Tables[0].Rows.Count > 0
                && ds_userwise.Tables[0].Columns.Contains("AGENCY_CODE"))
            {
                foreach (DataRow dr in ds_userwise.Tables[0].Rows)
                {
                    string agencyCode = dr["AGENCY_CODE"].ToString().Trim();
                    if (agencyCode != "" && !result.Contains(agencyCode))
                    {
                        result += agencyCode + "  ";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    [System.Web.Services.WebMethod]
    public static string Get_CTH_Rate(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            string name = "CTH_MASTER_RATE";
            string rows = "CTH_RATE";
            custid = Auto.Country_Master_FromClientSide_Calling(custid, name, rows);
            //custid = Auto.SingleWindow_CTH_Code_FromClientSide_Calling_SplAmt(custid, name, rows);
            if (Auto.Ename != "1")
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
    public static string Get_CTH_Rate_SlpAmt(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            string name = "CTH_MASTER_RATE_SplAmount_Unit";
            string rows = "CTH_SPL_AMT";
            //custid = Auto.Country_Master_FromClientSide_Calling(custid, name, rows);
            custid = Auto.SingleWindow_CTH_Code_FromClientSide_Calling_SplAmt(custid, name, rows);
            if (Auto.Ename != "1")
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
    public static string Get_CETH_Rate(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            string name = "CETH_MASTER_RATE";
            //string rows = "CETH_ADDITIONAL_CVD_S_RATE";
            string rows = "CETH_RATE";
            custid = Auto.Country_Master_FromClientSide_Calling(custid, name, rows);
            if (Auto.Ename != "1")
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
    public static string Get_Inv_Item_Tot_Val(string ddlInv_SL_No)
    {
        string Output = string.Empty;
        try
        {
           
            DataSet ds = new DataSet();
            IMP_Item_Move Item = new IMP_Item_Move();
            UserBO ObjUBO = new UserBO();

            ObjUBO.INVOICE_SLNO = ddlInv_SL_No;
            ObjUBO.flag = "IMP_Inv_Item_Tot_Val";
            ds = Item.Get_Inv_Item_Tot_Val(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Output = ds.Tables[0].Rows[0][0].ToString() + "~~" + ds.Tables[0].Rows[0][1].ToString();
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Output;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Item_Qty(string txtItemQty, string hdn_Item_Edit, string txtItem_Amount, string hdn_ITEM_AOUNT, string ddlInvoice_SlNo, string HiddenField1, string txtItem_UnitPrice)
    {
        try
        {
            //----------------------------------------------
            Transaction Transact = new Transaction();
            decimal unit_s = 0;
            if (txtItemQty != "" && txtItemQty != ".")
            {
                decimal TOTAL;
                if (hdn_Item_Edit != "")
                {
                    if (hdn_ITEM_AOUNT == "")
                    {
                        TOTAL = 0;
                    }
                    else
                    {
                        TOTAL = Convert.ToDecimal(hdn_ITEM_AOUNT);
                    }
                }
                else
                {
                    if (txtItem_Amount == "")
                    {
                        TOTAL = 0;
                    }
                    else
                    {
                        TOTAL = Convert.ToDecimal(txtItem_Amount);
                    }
                }

                Transact.JOBNO = Connection.IMP_Jobno();
                Transact.INVOICE_SLNO = ddlInvoice_SlNo;

                Transact.QTY = txtItemQty;
                Transact.ITEM_VALUE = TOTAL;
                Transact.WORKING_PERIOD = Connection.Get_Company_Type();
                Transact.Ename = "QTY";
                Transact.Flag = hdn_Item_Edit;
                Transact.ITEM_ID = HiddenField1;
                unit_s = Convert.ToDecimal(Transact.RetrieveAll_());
                txtItem_UnitPrice = Convert.ToString(Math.Round(unit_s, 6));

                decimal amt = Convert.ToDecimal(txtItemQty) * Convert.ToDecimal(txtItem_UnitPrice);
                txtItem_Amount = Convert.ToString(Math.Round(amt, 2));
            }
            else
            {
                txtItemQty = "";
            }

            //----------------------------------------------
            txtItem_Amount = txtItem_Amount + "~~" + txtItem_UnitPrice + "~~" + txtItemQty;
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return txtItem_Amount;
    }

    /*
    [System.Web.Services.WebMethod]
    public static string Get_Item_UnitPrice(string txtItem_UnitPrice, string hdn_Item_Edit, string txtItem_Amount, string hdn_ITEM_AOUNT, string ddlInvoice_SlNo, string HiddenField1, string txtItemQty)
    {
        Transaction Transact = new Transaction();

        string f = "";
        decimal i = 0;

        //-------------------------------------------------------------------------------
        if (txtItemQty != "" && txtItemQty != ".")
        {
            if (txtItem_UnitPrice != "" && txtItem_UnitPrice != ".")
            {
                //---#--------------
                if (hdn_Item_Edit != "")
                {
                    if (hdn_ITEM_AOUNT == "")
                    {
                        f = "0";
                    }
                    else
                    {
                        f = hdn_ITEM_AOUNT;
                    }
                }
                else
                {
                    if (txtItem_Amount == "")
                    {
                        f = "0";
                    }
                    else
                    {
                        f = txtItem_Amount;
                    }
                }


                decimal amt = Convert.ToDecimal(txtItemQty) * Convert.ToDecimal(txtItem_UnitPrice);
                txtItem_Amount = Convert.ToString(Math.Round(amt, 6));

                Transact.JOBNO = Connection.IMP_Jobno();
                Transact.INVOICE_SLNO = ddlInvoice_SlNo;
                Transact.QTY = txtItemQty;
                Transact.ITEM_VALUE = amt;
                Transact.Flag = hdn_Item_Edit;
                Transact.ITEM_ID = HiddenField1;
                Transact.WORKING_PERIOD = Connection.Get_Company_Type();
                Transact.Ename = "UNITPRICE";
                i = Convert.ToInt32(Transact.RetrieveAll_());
                //---#--------------
            }
        }
        //-------------------------------------------------------------------------------
        txtItem_Amount = txtItem_UnitPrice + "~~" + txtItem_Amount + "~~" + txtItemQty + "~~" + i;
        return txtItem_Amount;
    }
   */
    /*
    [System.Web.Services.WebMethod]
    public static string Get_Item_amount(string txtItem_UnitPrice, string hdn_Item_Edit, string txtItem_Amount, string hdn_ITEM_AOUNT, string ddlInvoice_SlNo, string HiddenField1, string txtItemQty)
    {
        Transaction Transact = new Transaction();
        string f = "";
        decimal i = 0;
        if (txtItemQty != "" && txtItem_Amount != "" && txtItemQty != "." && txtItem_Amount != ".")
        {
            if (txtItem_UnitPrice != "" && txtItem_UnitPrice != ".")
            {
                //---#-----------
                if (hdn_Item_Edit != "")
                {
                    if (hdn_ITEM_AOUNT == "")
                    {
                        f = "0";
                    }
                    else
                    {
                        f = hdn_ITEM_AOUNT;
                    }
                }
                else
                {
                    if (txtItem_Amount == "")
                    {
                        f = "0";
                    }
                    else
                    {
                        f = txtItem_Amount;
                    }
                }

                decimal amt = Convert.ToDecimal(txtItem_Amount) / Convert.ToDecimal(txtItemQty);
                txtItem_UnitPrice = Convert.ToString(Math.Round(amt, 6));
                Transact.JOBNO = Connection.IMP_Jobno();
                Transact.INVOICE_SLNO = ddlInvoice_SlNo;
                Transact.QTY = txtItemQty;
                Transact.ITEM_VALUE = amt;
                Transact.Flag = hdn_Item_Edit;
                Transact.ITEM_ID = HiddenField1;
                Transact.WORKING_PERIOD = Connection.Get_Company_Type();
                Transact.Ename = "UNITPRICE";
                i = Convert.ToInt32(Transact.RetrieveAll_());
                //---#-----------
            }
        }
        txtItem_Amount = txtItem_UnitPrice + "~~" + txtItem_Amount + "~~" + txtItemQty + "~~" + i;
        return txtItem_Amount;
    }
    */

    public class Scheme_Details
    {
        public string scheme_Notn { get; set; }
        public string scheme_Notn_Slno { get; set; }
    }

    [System.Web.Services.WebMethod]
    public static Scheme_Details[] Get_Scheme1(string ddlSchemeCode)
    {
        string str = ddlSchemeCode;
        string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);
        List<Scheme_Details> list = new List<Scheme_Details>();
        try
        {
           

            if (s1[0].Trim().ToString() != "00")
            {
                DataSet ds = new DataSet();
                adminmaster adm = new adminmaster();
                adm.SCHEME_IMPORT_CODE = s1[0].ToString();
                adm.SCHEME_NOTN = "0";
                adm.name = "SCHEME_NOTN";
                ds = adm.RetrieveAll_Scheme_Import();
                list.Clear();

                foreach (DataRow dtrow in ds.Tables[0].Rows)
                {
                    Scheme_Details country = new Scheme_Details();
                    country.scheme_Notn = dtrow["SCHEME_NOTN"].ToString();
                    list.Add(country);
                }
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return list.ToArray();
    }

    [System.Web.Services.WebMethod]
    public static Scheme_Details[] Get_Scheme2(string ddlSchemeCode, string ddlScheme_NOTN)
    {
        string str = ddlSchemeCode;
        string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);
        List<Scheme_Details> list = new List<Scheme_Details>();
        try
        {
            if (s1[0].Trim().ToString() != "00")
            {
                DataSet ds = new DataSet();
                adminmaster adm = new adminmaster();

                adm.SCHEME_IMPORT_CODE = s1[0].ToString();
                adm.SCHEME_NOTN = ddlScheme_NOTN;
                adm.name = "SCHEME_NOTN_SLNO";
                ds = adm.RetrieveAll_Scheme_Import();
                list.Clear();
                foreach (DataRow dtrow in ds.Tables[0].Rows)
                {
                    Scheme_Details country = new Scheme_Details();
                    country.scheme_Notn_Slno = dtrow["SCHEME_NOTN_SLNO"].ToString();
                    list.Add(country);
                }
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return list.ToArray();

    }

    protected void btnDown_Click(object sender, EventArgs e)
    {
        try
        {
            string mobilePriority = ViewState["ITEM_SLNO"].ToString();//ITEM_SLNO
            string mobileId = ViewState["ITEMID"].ToString();//ITEM_ID
            string previous = ViewState["ITEM_SLNO"].ToString();//ITEM_SLNO
            int run_item_sl_no = Convert.ToInt32(ViewState["RUN_ITEM_SL_NO"].ToString());
            int row = Convert.ToInt32(gv_ItemDetails.Rows.Count.ToString());

            if (row > run_item_sl_no)
            {
                if (previous != "")
                {
                    int pre = Convert.ToInt32(previous) + 1;
                    string previousId = Convert.ToString(pre);
                    Item_Moving(mobileId, previousId, mobilePriority, "Item_Move");
                    rowcolor_change_3();
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

    }

    protected void btnUp_Click(object sender, EventArgs e)
    {
        try
        {
            string mobilePriority = ViewState["ITEM_SLNO"].ToString();//ITEM_SLNO
            string mobileId = ViewState["ITEMID"].ToString();//ITEM_ID
            string previous = ViewState["ITEM_SLNO"].ToString();//ITEM_SLNO
            if (previous != "" && previous != "1")
            {
                int pre = Convert.ToInt32(previous) - 1;
                string previousId = Convert.ToString(pre);
                Item_Moving(mobileId, previousId, mobilePriority, "Item_Move");
                rowcolor_change_3();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    private void rowcolor_change_3()
    {
        try
        {
            if (gv_ItemDetails.Rows.Count > 0)
            {
                if (Convert.ToInt32(ViewState["Move_up_down_chk"]) != 0)
                {
                    gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                    gv_ItemDetails.SelectedRowStyle.Font.Bold = false;

                    GridViewRow firstRow = gv_ItemDetails.Rows[0];
                    firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                    firstRow.Font.Bold = true;
                    ViewState["update_chk"] = 0;
                }
                else
                {
                    GridViewRow firstRow = gv_ItemDetails.Rows[0];
                    firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                    firstRow.Font.Bold = true;
                    ViewState["update_chk"] = 0;
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void btnupdateProduct_Click(object sender, EventArgs e)
    {
        try
        {
            Get_Item_to_ProductMaster();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    public void Get_Item_to_ProductMaster()
    {
        try
        {
            product.JOBNO = IMPORT_JOBNO;
            product.PRODUCT_RITC = txtCTHNO.Text;
            product.PRODUCT_DESCRIPTION = txtDescription.Text;
            product.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
            product.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text;
            product.Ename = "GET_ITEM_TO_PRODUCT";
            ds = product.Retrive_Items_to_ProductMaster();

            if (Connection.COMPANYID() != "1532")
            {
                if (product.result == 1)
                {
                    Alert_msg("Updated Successfully");
                }
                else
                {
                    Alert_msg("Item Already Exists");

                }
            }

        }
        catch (SqlException ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        try
        {
            btnNew_Click(sender, e);
            MPEU.Hide();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    private string RegExReplace(string s)
    {
        try
        {
            String inputString = s;
            s = s.Replace(System.Environment.NewLine, string.Empty);
           
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
        return s;
    }

    public void Bind_ItemSl_No()
    {
        try
        {
            if (ddlInvoice_SlNo.SelectedValue != "")
            {
                Transact.JOBNO = IMPORT_JOBNO;
                Transact.WORKING_PERIOD = SELECT_BRANCH;
                Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
                Transact.Ename = "Item_Sl_No_Select";
                dss = Transact.RetrieveAll_Item_Details();
                ddl_ItemSlno.DataSource = dss.Tables[0];
                ddl_ItemSlno.DataTextField = "ITEM_SLNO";
                ddl_ItemSlno.DataValueField = "ITEM_SLNO_ID";
                ddl_ItemSlno.Items.Add("");
                ddl_ItemSlno.DataBind();


            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Bind_ItemSl_No_MAX()
    {
        try
        {
            if (ddlInvoice_SlNo.SelectedValue != "")
            {
                Transact.JOBNO = IMPORT_JOBNO;
                Transact.WORKING_PERIOD = SELECT_BRANCH;
                Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
                Transact.Ename = "Get_ItemSlno_MAX";
                dss = Transact.RetrieveAll_Item_Details();

                if (dss.Tables[0].Rows.Count > 0)
                {
                    lbl_Item_Slno.Text = dss.Tables[0].Rows[0]["MAX_ITEM_SLNO"].ToString();
                    txt_ItemSlno.Text = dss.Tables[0].Rows[0]["MAX_ITEM_SLNO"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public string Check_Item_Slno_Avail(string flag, string ID)
    {
        try
        {
            DataSet ds_avail = new DataSet();
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedValue.ToString();
            Transact.ITEM_SLNO = txt_ItemSlno.Text;
            Transact.ITEM_ID = ID;

            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = flag;
            ds_avail = Transact.RetrieveAll_Item_Details();

            if (ds_avail.Tables[0].Rows.Count > 0)
            {
                Item_Avail = ds_avail.Tables[0].Rows[0]["Avail_Result"].ToString();
            }
            
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
        return Item_Avail;
    }

    protected void ddl_ItemSlno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_ItemSlno.SelectedItem.Text != string.Empty)
            {
                string[] arr = new string[] { };
                arr = ddl_ItemSlno.SelectedValue.Split('_');
                INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
                ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text;
                this.gv_ItemDetails.SelectedIndex = Convert.ToInt32(arr[1]) - 1;
                gv_ItemDetails_SelectedIndexChanged(this.gv_ItemDetails, new EventArgs());
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

    }

    public void Update_CountryOfOrigin()
    {
        try
        {
            DataSet ds_product = new DataSet();
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedValue.ToString();
            Transact.ITEM_SLNO = "0";
            Transact.ITEM_ID = "0";
            Transact.INVOICE_NO = txtCountryOrigin.Text;
            Transact.WORKING_PERIOD = SELECT_BRANCH;

            Transact.Ename = "Update_CountryOfOrigin";
            ds_product = Transact.RetrieveAll_Item_Details();

            ds_product.Dispose();
            GC.Collect();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void btnUpdate_Fairmacs_Click(object sender, EventArgs e)
    {
        try
        {
            Update_CountryOfOrigin();
            Alert_msg("Product Updated Successfully", "");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    private void Load_RSP_Applicability()
    {
        try
        {
            ddl_RSP_Applicable.Items.Add(new ListItem("S", "S"));
            ddl_RSP_Applicable.Items.Add(new ListItem("N", "N"));
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    [System.Web.Services.WebMethod]
    public static string Get_Abtt_Rate_from_RSP_MASTER(string custid, string CETH_No, string RSP_Notn)
    {
        try
        {
            adminmaster Admin_mas = new adminmaster();
            DataSet ds = new DataSet();
            Admin_mas.ERSP_id = "0";
            Admin_mas.ERSP_cthno = CETH_No == "" ? string.Empty : CETH_No;
            Admin_mas.ERSP_Notn = RSP_Notn == "" ? "0" : RSP_Notn;
            Admin_mas.ERSP_Notn_SlNo = custid == "" ? "0" : custid;

            Admin_mas.Ename = "Get_ABTT_Rate_CETH_Notn_Slno";
            ds = Admin_mas.RetrieveAll_RSP_master();
            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = ds.Tables[0].Rows[0]["RSP_RATE"].ToString();
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
    public static string Get_AIDC_Master(string custid, string CTH_No, string AIDC_Notn)
    {
        try
        {
            adminmaster Admin_mas = new adminmaster();
            DataSet ds = new DataSet();
            Admin_mas.AIDC_RITC_NO = CTH_No;
            Admin_mas.AIDC_NOTN_NO = AIDC_Notn;
            Admin_mas.AIDC_NOTN_SLNO = custid;

            Admin_mas.Ename = "ITEM_AIDC_NOTN_RATE";
            ds = Admin_mas.Get_AIDC_CESS_SELECT();
            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = ds.Tables[0].Rows[0]["AIDC_NOTN_RATE"].ToString();
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
    public static string Get_AIDC_Notn(string custid, string country)
    {
        try
        {
            string AIDC_NOTN = string.Empty, AIDC_NOTN_SLNO = string.Empty, AIDC_RATE = string.Empty;

            adminmaster Admin_mas = new adminmaster();
            DataSet ds = new DataSet();
            Admin_mas.AIDC_RITC_NO = custid;
            Admin_mas.AIDC_NOTN_RATE = country;
            Admin_mas.Ename = "ITEM_RITC";
            ds = Admin_mas.Get_AIDC_CESS_SELECT();
            int z = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["AIDC_NOTN_NO"].ToString() != "022/2022")
                {
                    if (country == "SWITZERLAND" && ds.Tables[0].Rows[0]["AIDC_NOTN_NO"].ToString() == "041/2025")
                    {
                        z = 1;
                    }
                    else if (country == "NORWAY" && (ds.Tables[0].Rows[0]["AIDC_NOTN_NO"].ToString() == "042/2025" || ds.Tables[0].Rows[0]["AIDC_NOTN_NO"].ToString() == "043/2025"))
                    {
                        z = 1;
                    }
                    else if (country == "UNITED KINGDOM" && ds.Tables[0].Rows[0]["AIDC_NOTN_NO"].ToString() == "029/2026")
                    {
                        z = 1;
                    }
                }
            }

            if (z == 1)
            {
                AIDC_NOTN = ds.Tables[0].Rows[0]["AIDC_NOTN_NO"].ToString();
                AIDC_NOTN_SLNO = ds.Tables[0].Rows[0]["AIDC_NOTN_SLNO"].ToString();
                AIDC_RATE = ds.Tables[0].Rows[0]["AIDC_NOTN_RATE"].ToString();
                custid = AIDC_NOTN + "~~" + AIDC_NOTN_SLNO + "~~" + AIDC_RATE;
            }
            else
            {
                // Check if CTH starts with "94"
                if (custid.StartsWith("94"))
                {
                    AIDC_NOTN = "011/2021";
                    AIDC_NOTN_SLNO = "16D";
                    //AIDC_RATE = "0.00";
                    custid = AIDC_NOTN + "~~" + AIDC_NOTN_SLNO;
                }
                else
                {
                    AIDC_NOTN = "011/2021";
                    AIDC_NOTN_SLNO = "17";
                    AIDC_RATE = "0.00";
                    custid = AIDC_NOTN + "~~" + AIDC_NOTN_SLNO + "~~" + AIDC_RATE;
                }
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_CTH_Tariff_NOTN(string txtTariff_NOTN, string txtTariff_SL)
    {
        try
        {
            DataSet ds = new DataSet();
            adminmaster Admin_mas = new adminmaster();
            Admin_mas.ERSP_id = "0";
            Admin_mas.ERSP_Notn = txtTariff_NOTN == "" ? "0" : txtTariff_NOTN;
            Admin_mas.ERSP_Notn_SlNo = txtTariff_SL == "" ? "0" : txtTariff_SL;
            Admin_mas.Ename = "Get_CTH_Tariff_NOTN";
            ds = Admin_mas.RetrieveAll_RSP_master();

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTariff_NOTN = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString() == null ? "" : ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString();
                txtTariff_SL = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString() == null ? "" : ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString();
            }
            else
            {
                txtTariff_NOTN = "";
                txtTariff_SL = "";
            }
            txtTariff_NOTN = txtTariff_NOTN + "~~" + txtTariff_SL;
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return txtTariff_NOTN;
    }

    //-----------------------------------------------------------------


    [System.Web.Services.WebMethod]
    public static string Get_GST_CTH_CODE(string custid, string country)
    {
        try
        {
            string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", AIDC_result = "", Address8 = "", Address9 = ""
                , Levy1E_Notn = "", Levy1E_Notn_Slno = "", Levy1E_Rate = "", Restricted_CTH = "", Default_IGST_CCR = "";
            if (custid != "")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                //Auto.Ename = "Get_IGST_NOTN_SLNO_RITC";
                Auto.Ename = "Get_IGST_NOTN_SLNO_RITC_V2";// hide on 20-09-2025 for IGST New Implemetation 
                Auto.Enamesearch = custid;
                Auto.Notn_No_Search = custid;
                //ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH_PART_II();// hide on 20-09-2025 for IGST New Implemetation 

                if (ds.Tables[0].Rows.Count > 0)//default Flag entry enabled for all sugg.by Subbu sir
                {
                    Address1 = ds.Tables[0].Rows[0]["LEVY_1NOTIFICATION"].ToString();
                    Address2 = ds.Tables[0].Rows[0]["LEVY_1NOTIFICATION_SLNO"].ToString();
                    Address4 = ds.Tables[0].Rows[0]["LEVY_1NOTIFICATION_RATE"].ToString();
                }
                else
                {
                    if (ds.Tables[1].Rows.Count == 1)
                    {
                        Address1 = ds.Tables[1].Rows[0]["LEVY_1NOTIFICATION"].ToString();
                        Address2 = ds.Tables[1].Rows[0]["LEVY_1NOTIFICATION_SLNO"].ToString();
                        Address4 = ds.Tables[1].Rows[0]["LEVY_1NOTIFICATION_RATE"].ToString();
                    }
                    else
                    {
                        Address1 = "";
                        Address2 = "";
                        Address4 = "";
                    }
                }


                if (ds.Tables[2].Rows.Count == 1)
                {
                    Address5 = ds.Tables[2].Rows[0]["LEVY_2NOTIFICATION"].ToString();
                    Address6 = ds.Tables[2].Rows[0]["LEVY_2NOTIFICATION_SLNO"].ToString();
                    Address7 = ds.Tables[2].Rows[0]["LEVY_2NOTIFICATION_RATE"].ToString();
                }
                else
                {
                    if (ds.Tables[2].Rows.Count == 0)
                    {
                        Address5 = "001/2017";
                        Address6 = "56";
                        Address7 = "0.00";
                    }

                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    Restricted_CTH = ds.Tables[3].Rows[0]["CTH_STATUS"].ToString();
                }

                if (ds.Tables[4].Rows.Count == 1)
                {
                    if (Connection.Get_User_Imp_Settings_Job_Edit("ITEM_DEFAULT_IGST_EXCMPN_NOTN") == "E")
                    {
                        Levy1E_Notn = ds.Tables[4].Rows[0]["LEVY_2NOTIFICATION"].ToString();
                        Levy1E_Notn_Slno = ds.Tables[4].Rows[0]["LEVY_2NOTIFICATION_SLNO"].ToString();
                        Levy1E_Rate = ds.Tables[4].Rows[0]["LEVY_2NOTIFICATION_RATE"].ToString();
                    }
                }
                else
                {
                    Levy1E_Notn = "";
                    Levy1E_Notn_Slno = "";
                    Levy1E_Rate = "";
                }
            }

            AIDC_result = Get_AIDC_Notn(custid, country);
            Default_IGST_CCR = Copy_CCR(custid);

            custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9 + "~~" + AIDC_result + "~~" + Levy1E_Notn + "~~" + Levy1E_Notn_Slno + "~~" + Levy1E_Rate + "~~" + Default_IGST_CCR + "~~" + Restricted_CTH;

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }


    [System.Web.Services.WebMethod]
    public static string Get_IGST_NOTN_TYPE(string txt_IGST_NOTN)
    {
        try
        {
            DataSet ds = new DataSet();
            adminmaster Admin_mas = new adminmaster();
            Auto_Search Auto = new Auto_Search();

            Auto.Ename = "GET_IGST_LEVY_NOTN_TYPE";
            Auto.Enamesearch = txt_IGST_NOTN;
            Auto.Notn_No_Search = "";

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_IGST_NOTN = ds.Tables[0].Rows[0]["NOTIFICATION_TYPE"].ToString() == null ? "" : ds.Tables[0].Rows[0]["NOTIFICATION_TYPE"].ToString();
            }
            else
            {
                txt_IGST_NOTN = "";
            }

            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return txt_IGST_NOTN;
    }

    //------------------Added by pandiyan on 02/06/2025-----------------------------------------------

    [System.Web.Services.WebMethod]
    public static string Get_IGST_LEVY_EXCEPTION_CC_TYPE(string txt_IGST_LEVY_EXCEPTION_CC_NOTN)
    {
        try
        {
            DataSet ds = new DataSet();
            adminmaster Admin_mas = new adminmaster();
            Auto_Search Auto = new Auto_Search();

            Auto.Ename = "GET_IGST_LEVY_EXCEPTION_CC_TYPE";
            Auto.Enamesearch = txt_IGST_LEVY_EXCEPTION_CC_NOTN;
            Auto.Notn_No_Search = "";

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH_PART_II();

            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_IGST_LEVY_EXCEPTION_CC_NOTN = ds.Tables[0].Rows[0]["NOTIFICATION_TYPE"].ToString() == null ? "" : ds.Tables[0].Rows[0]["NOTIFICATION_TYPE"].ToString();
            }
            else
            {
                txt_IGST_LEVY_EXCEPTION_CC_NOTN = "";
            }

            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return txt_IGST_LEVY_EXCEPTION_CC_NOTN;
    }

    //------------------15-feb-2019-----------------------------------------------

    [System.Web.Services.WebMethod]
    public static string Get_CTH_Info_Uqc(string Info_Uqc)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "Get_CTH_Info_Uqc";
            Auto.Enamesearch = Info_Uqc;
            Auto.Notn_No_Search = Info_Uqc;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds.Tables[0].Rows.Count > 0)
            {
                Info_Uqc = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                Info_Uqc = "";
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Info_Uqc;
    }

    /*---hide on 12-08-2020 by Chithra for Page refreshing issue
    protected void ddlAntiDumping_Notn_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Get_AntiDumping_Slno(ddlAntiDumping_Notn.SelectedItem.Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>AntiDumping_tab();</script>", false);
        }
    }
     */


    private DataSet Get_AntiDumping_Slno(string Anti_Notn)
    {
        try
        {
            adminmaster adm = new adminmaster();
            adm.SCHEME_IMPORT_CODE = Anti_Notn;
            adm.SCHEME_NOTN = "";
            adm.name = "ANTIDUMP_NOTNSLNO";
            ds = adm.RetrieveAll_Scheme_Import();

            /* hide on 08-05-2021 by Chithra Sugg.by Bala sir
            ddlAntiDumping_Notn_SL.DataSource = ds.Tables[0];
            ddlAntiDumping_Notn_SL.DataTextField = "ADD_SLNO";
            ddlAntiDumping_Notn_SL.DataValueField = "ADD_SLNO";
            ddlAntiDumping_Notn_SL.DataBind();
             * */

            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    [System.Web.Services.WebMethod]
    public static string Check_CountryName(string CountryName, string Filedname)
    {
        try
        {
            if (CountryName != "")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();

                Auto.Enamesearch = CountryName;
                if (Filedname == "COUNTRY_OF_ORIGIN")
                {
                    Auto.Ename = "IMP_EXP_Country_of_orgin_Chk";
                }
                else
                {
                    Auto.Ename = "Get_CountryName";
                }

                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    CountryName = "Yes";
                }
                else
                {
                    CountryName = "No";
                }
            }
          
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return CountryName;
    }

    [System.Web.Services.WebMethod]
    public static string Get_SupplierDetails()
    {
        DataSet ds_supp = new DataSet();
        Transaction Transact = new Transaction();
        string result = "";
        
        try
        {
            
            Transact.JOBNO = HttpContext.Current.Session["IMPORT_JOBNO"].ToString();
            Transact.INVOICE_SLNO = HttpContext.Current.Session["INVOICE_SLNO"].ToString();
            Transact.ITEM_SLNO = "0";
            Transact.ITEM_ID = "0";
            Transact.INVOICE_NO = "";
            Transact.WORKING_PERIOD = Connection.Get_Company_Type();

            Transact.Ename = "Get_SupplierName";
            ds_supp = Transact.RetrieveAll_Item_Details();

            if (ds_supp.Tables[0].Rows.Count > 0)
            {
                result = ds_supp.Tables[0].Rows[0]["SUPPLIER_ADDRESS"].ToString() + "~~" + ds_supp.Tables[0].Rows[0]["SUPPLIER_ADDRESS1"].ToString() + "~~" + ds_supp.Tables[0].Rows[0]["SUPPLIER_ADDRESS2"].ToString() + "~~" + ds_supp.Tables[0].Rows[0]["SUPPLIER_COUNTRY_NAME"].ToString() + "~~" + ds_supp.Tables[0].Rows[0]["SUPPLIER_COUNTRY_PINCODE"].ToString();
            }

            ds_supp.Dispose();
            GC.Collect();

            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    [System.Web.Services.WebMethod]
    public static string Get_AntiDumping_NOTN_Slno(string Anti_Notn)
    {
        string slno = "";
        DataSet ds = new DataSet();
        adminmaster adm = new adminmaster();
        try
        {
           
            adm.SCHEME_IMPORT_CODE = Anti_Notn;
            adm.SCHEME_NOTN = "";
            adm.name = "ANTIDUMP_NOTNSLNO";
            ds = adm.RetrieveAll_Scheme_Import();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    slno += dr[0].ToString() + ",";
                }
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return slno;
    }
    public string CHK_FTA_Transit_Country(string CountryOrigin, string BasicNotn, string SAPTA_NOTN)
    {
        adminmaster Admin_mas = new adminmaster();
        DataSet ds = new DataSet();
        string FTA_Transit = "";
        
        try
        {
           
            Admin_mas.ID = "";
            Admin_mas.FTA_NOTN = BasicNotn;
            Admin_mas.FTA_NOTN_SLNO = SAPTA_NOTN;
            Admin_mas.FTA_COUNTRY = CountryOrigin;
            Admin_mas.Ename = "get_FTA_Avail_Count";
            Admin_mas.maximumRows = "";

            ds = Admin_mas.Fta_master();

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (txt_manu_Transit_Country.Text != "")
                {
                    hdn_FTA_Transit_chk.Value = "Yes";
                    FTA_Transit = "Yes";
                }
                else
                {
                    hdn_FTA_Transit_chk.Value = "No";
                    FTA_Transit = "No";
                }
            }
            else
            {
                hdn_FTA_Transit_chk.Value = "Yes";
                FTA_Transit = "Yes";
            }
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return FTA_Transit;
    }

    [System.Web.Services.WebMethod]
    public static string Check_EndUseCode(string EndUseCode)
    {
        try
        {

            if (EndUseCode != "")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Enamesearch = EndUseCode;
                Auto.Ename = "EndUesCode_Chk";
                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    EndUseCode = "Yes";
                }
                else
                {
                    EndUseCode = "No";
                }
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
         return EndUseCode;
    }


    [System.Web.Services.WebMethod]
    private static string Copy_CCR(string CTH_NO)
    {
        string IGST_CCR = "";
        try
        {

            //string RITC = txtCTH_No.Text;
            string RITC = CTH_NO;
            string Chapter = RITC.Substring(0, 2);

            //string OpenPath = Server.MapPath("~/Submission/Icegate_HTML_TXT_Files/" + Chapter + "/" + RITC + ".txt");
            string OpenPath = HttpContext.Current.Server.MapPath("~/Submission/Icegate_HTML_TXT_Files/" + Chapter + "/" + RITC + ".txt");


            if (File.Exists(OpenPath) == true)
            {
                string contents = File.ReadAllText(OpenPath);
                string[] Lines = contents.Split('\n');
                string[] parts1 = contents.Split(new string[] { "Compulsory compliance Requirements (CCRs)" }, StringSplitOptions.None);
                string[] parts2 = parts1[1].Split(new string[] { "ccr_apr" }, StringSplitOptions.None);

                string CCR = "";
                if (parts2[1].Contains("*"))
                {
                    string[] parts3 = parts2[1].Split(new string[] { "</span>" }, StringSplitOptions.None);
                    CCR = parts3[0].Replace(">", "");
                }


                //---------------------Default IGST Notn---------------------
                string IgstNotn = "", IgstNotn_Slno = "";
                string delimiter = "<span id=\"igst_notnElm";
                string[] igst1 = contents.Split(new string[] { delimiter }, StringSplitOptions.None);
                string[] igst2 = igst1[1].Split(new string[] { "</span>" }, StringSplitOptions.None);

                IgstNotn = igst2[0].Replace(">", "").Replace("\"", "");

                string[] igst3 = igst2[1].Split(new string[] { "-" }, StringSplitOptions.None);
                if (igst3.Length > 1)
                {
                    IgstNotn_Slno = igst3[1];
                }
                else
                {
                    IgstNotn_Slno = " ";
                }
                IGST_CCR = CCR == "" ? "*" : CCR;
                IgstNotn = IgstNotn + " - " + IgstNotn_Slno;
                //IGST_CCR = IGST_CCR + "^^" + IgstNotn;
                IGST_CCR = IGST_CCR + "~~" + IgstNotn;
            }
            else
            {
                IGST_CCR = "*" + "~~" + "-";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return IGST_CCR;
    }

    static DataTable ConvertHtmlToDataTable(string html)
    {
        DataTable dt = new DataTable();
        try
        {
            // Wrap the options in a dummy select tag to make it valid XML
            string xmlContent = "<select>" + html + "</select>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlContent);

          
            dt.Columns.Add("Rate", typeof(string));
            dt.Columns.Add("SplDuty", typeof(string));
            dt.Columns.Add("Unit", typeof(string));
            dt.Columns.Add("F", typeof(string));//Need to check
            dt.Columns.Add("Notn", typeof(string));

            XmlNodeList optionNodes = doc.SelectNodes("//option");

            foreach (XmlNode option in optionNodes)
            {
                string value = option.Attributes["value"] != null ? option.Attributes["value"].Value : "";
                string text = option.InnerText.Trim();

                string[] r1 = value.Split('#');
                dt.Rows.Add(r1[1].Replace("R=", "").Replace("@", ""), r1[2].Replace("A=undefined@", "").Replace("A=", "").Replace("@", ""), r1[3].Replace("U=undefined@", "").Replace("U=", "").Replace("@", ""), r1[4].Replace("F=undefined", "").Replace("F=", "").Replace("@", ""), text);
            }


            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dt;
    }

    public void CTH_NOTN_Same_As_IGST_NOTN()
    {
        try
        {

            if (Connection.Get_User_Imp_Settings_Job_Edit("IGST_EXEMPTION_NOTN_AS_LICENSE_NOTN") == "E")
            {



                if (ddlScheme_NOTN.SelectedValue != "" && ddlScheme_NOTN_SL.SelectedValue != "")
                {

                    txt_IGST_LEVY_EXCEPTION_NOTN.Text = ddlScheme_NOTN.SelectedValue;

                    txt_IGST_LEVY_EXCEPTION_SLNO.Text = ddlScheme_NOTN_SL.SelectedValue;

                }

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
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
            DataTable dt_modified = DataTable_Mapping_Controls(dt_m2, "N");
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast(dt_Prev, dt_modified, "INVOICE_SLNO", "Item", IMPORT_JOBNO, ddlInvoice_SlNo.SelectedValue, ddl_ItemSlno.SelectedItem.Text, currentuser, Connection.Current_Branch());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private DataTable DataTable_Mapping_Controls(DataTable dt_mapping, string SelectMode)
    {
        try
        {
            if (dt_mapping.Rows.Count > 0)
            {
                dt_mapping.Rows.Clear();
            }

            DataRow dr = dt_mapping.NewRow();

            dr["JOBNO"] = IMPORT_JOBNO;
            dr["INVOICE_SLNO"] = ddlInvoice_SlNo.SelectedValue;
            //dr["ITEM_SLNO"] = ViewState["ITEM_SLNO"].ToString();
            dr["ITEM_SLNO"] = ddl_ItemSlno.SelectedItem.Text;


            dr["ITEM_DESCRIPTION"] = RegExReplace(txtDescription.Text);
            dr["ITEM_QTY"] = txtItemQty.Text.Trim();
            dr["ITEM_QTY_CODE"] = txtQtyCode.Text;
            dr["ITEM_UNIT_PRICE"] = txtItem_UnitPrice.Text.Trim();
            dr["ITEM_UNIT_CODE"] = txtItem_UnitPriceCode.Text;

            dr["ITEM_TOTAL_AMOUNT"] = txtItem_Amount.Text.Trim();
            dr["ITEM_AMOUNT_CODE"] = txtItem_AmountCode.Text;
            dr["CTH_NO"] = txtCTH_No.Text.Trim();

            dr["SCHEME_CODE"] = ddlSchemeCode.SelectedValue.ToString();
            dr["SCHEME_NOTN"] = ddlScheme_NOTN.SelectedValue.ToString();
            dr["SCHEME_NOTN_SLNO"] = ddlScheme_NOTN_SL.SelectedValue.ToString();
            dr["CTH_QTY1"] = txtCTH_Qty1.Text.Trim();
            dr["CTH_QTY2"] = txtCTH_Qty2.Text;
            dr["CTH_QTY1_CODE"] = txtCTH_Qty1_Code.Text;
            dr["CTH_QTY2_CODE"] = txtCTH_Qty2_Code.Text;

            dr["GENEARL_DESCRIPTION"] = RegExReplace(txtGeneralDesc.Text);
            dr["MANUFACTURER"] = txtManufacturer.Text;

            dr["BRAND"] = txtBrand.Text;
            dr["MODEL"] = txtModel.Text;
            dr["END_USE_OF_ITEM"] = txtEndUse.Text.ToUpper();
            dr["COUNTRY_OF_ORIGIN"] = txtCountryOrigin.Text;
            dr["ACCESSORIES"] = txtAccessories.Text;
            dr["PREVIOUS_BE_NO"] = txtPrevious_Be_No.Text;
            dr["PREVIOUS_BE_DATE"] = txtPrevious_Be_Date.Text;

            dr["UNIT_PRICE"] = txtUnitValue.Text.Trim();
            dr["UNIT_CODE"] = txtunitcode.Text;
            dr["CUSTOMS_HOUSE"] = txtCustomsHouse.Text.ToUpper();
            dr["PRODUCT_RITC"] = txtRITCNO.Text;
            dr["PRODUCT_CTH"] = txtCTHNO.Text;
            dr["PRODUCT_BCD_NOTN"] = txtBasicNotn.Text.Trim();
            dr["PRODUCT_BCD_SLNO"] = txtBasicSLNO.Text.Trim();
            dr["PRODUCT_BCD_RATE"] = txtBasicRate.Text.Trim();
            dr["PRODUCT_BCD_SPL"] = txtBasicSPL.Text.Trim();
            dr["PRODUCT_BCD_UNIT"] = txtBasicUnit.Text;
            //dr["PRODUCT_BCD_SPL_TYPE"] = ddlBasicSPLTYPE.SelectedValue.ToString();
            dr["PRODUCT_ADDL_DUTY_NOTN"] = txtAddlDuty_NOTN.Text.Trim();
            dr["PRODUCT_ADDL_DUTY_NOTN_SL"] = txtAddlDuty_NOTN_SL.Text.Trim();
            dr["PRODUCT_ADDL_DUTY_RATE"] = txtAddlDuty_Rate.Text;
            dr["PRODUCT_EDU_CESS_NOTN"] = txtEdu_Cess_NOTN.Text.Trim();
            dr["PRODUCT_EDU_CESS_NOTN_SL"] = txtEdu_Cess_NOTN_SL.Text.Trim();
            dr["PRODUCT_EDU_CESS_RATE"] = txtEdu_Cess_Rate.Text;

            if (txtEdu_Cess_NOTN.Text == "069/2004")
            {
                txtSec_Edu_Cess_NOTN.Text = "028/2007";
                txtSec_Edu_Cess_Rate.Text = "0.00";
            }
            else
            {
                txtSec_Edu_Cess_NOTN.Text = "";
                txtSec_Edu_Cess_Rate.Text = "";
            }


            dr["PRODUCT_SEC_EDU_CESS_NOTN"] = txtSec_Edu_Cess_NOTN.Text;
            dr["PRODUCT_SEC_EDU_CESS_NOTN_SL"] = txtSec_Edu_Cess_NOTN_SL.Text;
            dr["PRODUCT_SEC_EDU_CESS_RATE"] = txtSec_Edu_Cess_Rate.Text;
            dr["PRODUCT_NCD_NOTN"] = txtNCD_NOTN.Text.Trim();

            dr["PRODUCT_NCD_SLNO"] = txtNCD_SLNO.Text.Trim();
            dr["PRODUCT_NCD_RATE"] = txtNCD_RATE.Text;
            dr["PRODUCT_NCD_SPL"] = txtNCD_SPL.Text;
            dr["PRODUCT_NCD_UNIT"] = txtNCD_UNIT.Text;
            //dr["PRODUCT_NCD_SPL_TYPE"] = ddlNCD_SPL_TYPE.SelectedValue.ToString();
            dr["PRODUCT_AGGREGATE_DUTY_NOTN"] = txtAggregate_NOTN.Text.Trim();
            dr["PRODUCT_AGGREGATE_DUTY_NOTN_SL"] = txtAggregate_NOTN_SL.Text.Trim();
            dr["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"] = txtAggregate_RATE.Text;

            dr["PRODUCT_SAFEGUARD_NOTN"] = txtSafeguard_NOTN.Text.Trim();
            dr["PRODUCT_SAFEGUARD_SLNO"] = txtSafeguard_SL.Text.Trim();
            dr["PRODUCT_SAFEGUARD_RATE"] = txtSafeguard_RATE.Text.Trim();
            dr["PRODUCT_SAFEGUARD_SPL"] = txtSafeguard_SPL.Text.Trim();
            dr["PRODUCT_SAFEGUARD_UNIT"] = txtSafeguard_UNIT.Text;
            //dr["PRODUCT_SAFEGUARD_SPL_TYPE"] = ddlSafeguard_SPL_TYPE.SelectedValue.ToString();

            dr["PRODUCT_SAPTA_NOTN"] = txtSAPTA_NOTN.Text.Trim();
            dr["PRODUCT_SAPTA_SLNO"] = txtSAPTA_NOTN_SL.Text.Trim();
            dr["PRODUCT_SAPTA_RATE"] = txtSAPTA_RATE.Text.Trim();
            dr["PRODUCT_TARIFF_NOTN"] = txtTariff_NOTN.Text;

            dr["PRODUCT_TARIFF_SLNO"] = txtTariff_SL.Text;
            dr["PRODUCT_TARIFF_QTY"] = txtTariff_Qty.Text.Trim();
            dr["PRODUCT_TARIFF_AMOUNT"] = txtTariff_Amount.Text.Trim();
            dr["PRODUCT_TARIFF_AMOUNT_UNIT"] = txtTariff_Amount_unitCode.Text;


            dr["PRODUCT_CETH"] = txtCETH_No.Text.Trim();
            dr["PRODUCT_MRP_YN"] = chkMRP_Duty.Checked == true ? "Y" : "N";
            dr["PRODUCT_MRP_SL_NO"] = txtMRP_SL_NO.Text;
            dr["PRODUCT_MRP_AMOUNT"] = txtMRP_AMOUNT.Text.Trim();
            dr["PRODUCT_MRP_ABT_RATE"] = txtMRP_ABT_RATE.Text.Trim();
            dr["PRODUCT_CVD_NOTN"] = txt_CVD_NOTN.Text.Trim();
            dr["PRODUCT_CVD_SLNO"] = txt_CVD_SLNO.Text.Trim();
            dr["PRODUCT_CVD_RATE"] = txt_CVD_RATE.Text.Trim();
            dr["PRODUCT_CVD_SPL"] = txt_CVD_SPL.Text.Trim();
            dr["PRODUCT_CVD_UNIT"] = txt_CVD_UNIT.Text;
            //dr["PRODUCT_CVD_SPL_TYPE"] = ddlCVD_SPL_TYPE.SelectedValue.ToString();
            dr["PRODUCT_CVD_EDU_CESS_RATE"] = txt_CVD_Education_CESS_Rate.Text.Trim();
            dr["PRODUCT_CVD_SEC_EDU_CESS_RATE"] = txt_CVD_Sec_Edu_CESS_Rate.Text;
            dr["PRODUCT_ADDL5_SIA_NOTN"] = txt_Addl5_SIA_NOTN.Text.Trim();
            dr["PRODUCT_ADDL5_SIA_NOTN_SL"] = txt_Addl5_SIA_NOTN_SL.Text.Trim();
            dr["PRODUCT_ADDL5_SIA_RATE"] = txt_Addl5_SIA_RATE.Text.Trim();
            dr["PRODUCT_ADDL_GSI_NOTN"] = txt_Addl_GSI_NOTN.Text.Trim();
            dr["PRODUCT_ADDL_GSI_SLNO"] = txt_Addl_GSI_SL.Text.Trim();
            dr["PRODUCT_ADDL_GSI_RATE"] = txt_Addl_GSI_RATE.Text.Trim();
            dr["PRODUCT_ADDL_GSI_SPL"] = txt_Addl_GSI_SPL.Text;
            dr["PRODUCT_ADDL_GSI_UNIT"] = txt_Addl_GSI_UNIT.Text;
           //dr["PRODUCT_ADDL_GSI_SPL_TYPE"] = ddl_Addl_GSI_SPL_TYPE.SelectedValue.ToString();
            dr["PRODUCT_ADDL_SHEII_NOTN"] = txt_Addl_SHE11_NOTN.Text.Trim();
            dr["PRODUCT_ADDL_SHEII_SLNO"] = txt_Addl_SHE11_SLNO.Text.Trim();
            dr["PRODUCT_ADDL_SHEII_RATE"] = txt_Addl_SHE11_RATE.Text.Trim();
            dr["PRODUCT_ADDL_SHEII_SPL"] = txt_Addl_SHE11_SPL.Text.Trim();
            dr["PRODUCT_ADDL_SHEII_UNIT"] = txt_Addl_SHE11_UNIT.Text;
            //dr["PRODUCT_ADDL_SHEII_TYPE"] = ddl_Addl_SHE11_Type.SelectedValue.ToString();
            dr["PRODUCT_ADDL_TTA_NOTN"] = txt_Addl_TTA_NOTN.Text.Trim();
            dr["PRODUCT_ADDL_TTA_SLNO"] = txt_Addl_TTA_SLNO.Text.Trim();
            dr["PRODUCT_ADDL_TTA_RATE"] = txt_Addl_TTA_RATE.Text.Trim();
            dr["PRODUCT_ADDL_TTA_SPL"] = txt_Addl_TTA_SPL.Text.Trim();
            dr["PRODUCT_ADDL_TTA_UNIT"] = txt_Addl_TTA_UNIT.Text;
            //dr["PRODUCT_ADDL_TTA_TYPE"] = ddl_Addl_TTA_Type.SelectedValue.ToString();
            dr["PRODUCT_ADDL_HEALTH_CESS_NOTN"] = txt_Addl_Health_CESS_NOTN.Text.Trim();
            dr["PRODUCT_ADDL_HEALTH_CESS_SLNO"] = txt_Addl_Health_CESS_SLNO.Text.Trim();
            dr["PRODUCT_ADDL_HEALTH_CESS_RATE"] = txt_Addl_Health_CESS_RATE.Text.Trim();
            dr["PRODUCT_ADDL_HEALTH_CESS_SPL"] = txt_Addl_Health_CESS_SPL.Text.Trim();
            dr["PRODUCT_ADDL_HEALTH_CESS_UNIT"] = txt_Addl_Health_CESS_UNIT.Text;
            //dr["PRODUCT_ADDL_HEALTH_CESS_TYPE"] = ddl_Addl_Health_CESS_Type.SelectedValue.ToString();
            dr["PRODUCT_CESS_NOTN"] = txt_CESS_NOTN.Text.Trim();
            dr["PRODUCT_CESS_SLNO"] = txt_CESS_SLNO.Text.Trim();
            dr["PRODUCT_CESS_RATE"] = txt_CESS_RATE.Text.Trim();
            dr["PRODUCT_CESS_SPL"] = txt_CESS_SPL.Text.Trim();
            dr["PRODUCT_CESS_UNIT"] = txt_CESS_UNIT.Text;
            //dr["PRODUCT_CESS_TYPE"] = ddl_CESS_Type.SelectedValue.ToString();

            if (txt_AntiDumping_Notn.Text != "")
            {
                dr["ANTI_DUMPING_NOTN"] = txt_AntiDumping_Notn.Text.Trim();
                dr["ANTI_DUMPING_NOTN_SLNO"] = txt_AntiDumping_Notn_SL.Text.Trim();
                dr["CTH_SLNO"] = txtCTH_SL_No.Text.Trim();
                dr["CTH_SUPPLIER_SLNO"] = txtCTH_Supplier_SL.Text.Trim();
            }
            else
            {
                dr["ANTI_DUMPING_NOTN"] = "";
                dr["ANTI_DUMPING_NOTN_SLNO"] = "";
                dr["CTH_SLNO"] = "";
                dr["CTH_SUPPLIER_SLNO"] = "";
            }

            dr["CTH_QTY"] = txtCTH_Qty.Text.Trim();
            dr["RSP_DUTY_STATUS"] = ddlRSP_Duty_yn.SelectedValue.ToString();
            dr["RSP_NOTN_NO"] = txtRSP_Notn_No.Text;
            dr["RSP_NOTN_SL_NO"] = txtRSP_Notn_Slno.Text;

            dr["CETH_CVD_EDU_CESS_SL"] = txt_CVD_Education_CESS_SL.Text;
            dr["CETH_CVD_EDU_CESS_RATE"] = txtCVD_Edu_Cess_Rate.Text;
            dr["CETH_CVD_SEC_EDU_CESS_SL"] = txtCETH_Sec_Edu_Cess_NOTN_SL.Text;
            dr["CETH_CVD_SEC_EDU_CESS_RATE"] = txtCETH_Sec_Edu_Cess_Rate.Text;

            //---------------------01_June_2015-----------
            dr["PRODUCT_OTHER_DUTY_NOTN"] = txtOther_Duty_Notn.Text.Trim();
            dr["PRODUCT_OTHER_DUTY_SLNO"] = txtOther_Duty_SLNO.Text.Trim();
            dr["PRODUCT_OTHER_DUTY_RATE"] = txtOther_Duty_RATE.Text.Trim();
            dr["PRODUCT_OTHER_DUTY_SPL"] = txtOther_Duty_SPL.Text.Trim();
            dr["PRODUCT_OTHER_DUTY_UNIT"] = txtOther_Duty_UNIT.Text;
            //dr["PRODUCT_OTHER_DUTY_TYPE"] = ddlOther_Duty_Type.SelectedValue.ToString();
            dr["RSP_APPLICABLE"] = ddl_RSP_Applicable.SelectedValue.ToString();

            dr["CENTRAL_EXCISE_FLAG"] = txt_Cus_not_exe_Cen_flag.Text;
            dr["MANUFACTURER_PRODUCER"] = txt_Manufacturer_producer.Text;
            dr["M_P_GROWER_CODE"] = txt_Manu_produ_grower_code.Text;
            dr["M_P_GROWER_ADD1"] = txt_Manufacturer_Add1.Text;
            dr["M_P_GROWER_ADD2"] = txt_Manufacturer_Add2.Text;
            dr["M_P_GROWER_CITY"] = txt_Manufacturer_City.Text;
            dr["M_P_GROWER_COUNTRY_SUBDIV"] = txt_Manu_Country_Subdiv.Text;
            dr["M_P_GROWER_PIN"] = txt_Manufacturer_pincode.Text;
            dr["M_P_GROWER_COUNTRY"] = txt_Manufacturer_Country.Text.ToUpper();
            dr["SOURCE_COUNTRY"] = txt_Manu_Source_Country.Text.ToUpper();
            dr["TRANSIT_COUNTRY"] = txt_manu_Transit_Country.Text.ToUpper();
            dr["ACCESSORY_STATUS"] = txt_Accessory_status.Text;

            dr["INFRA_CESS_NOTN"] = txtinfra_cess_Notn.Text.Trim();
            dr["INFRA_CESS_NOTN_SL"] = txtinfra_cess_Notn_SLNO.Text.Trim();
            dr["INFRA_CESS_NOTN_RATE"] = txtinfra_cess_Notn_RATE.Text.Trim();

            dr["SVB_REF_NO"] = txtSVB_RefNo.Text;
            dr["SVB_REF_DATE"] = txtSVBDate.Text;
            dr["SVB_CUSTOM_HOUSE"] = txtCustomsHouse_2.Text.ToUpper();
            dr["SVB_LOADING_ON"] = ddlLoadingOn.SelectedItem.Text;
            dr["SVB_ASSESABLE_RATE"] = txtAssesable_Rate.Text;
            dr["SVB_DUTY_RATE"] = txtDuty_Rate.Text;
            dr["SVB_ASSESABLE_STATUS"] = ddlAssesable_Status.SelectedValue.ToString();
            dr["SVB_DUTY_STATUS"] = ddlDuty_Status.SelectedValue.ToString();

            dr["IGST_LEVY_NOTN"] = txt_IGST_LEVY_NOTN.Text.Trim();
            dr["IGST_LEVY_SLNO"] = txt_IGST_LEVY_SLNO.Text.Trim();
            dr["IGST_LEVY_RATE"] = txt_IGST_LEVY_RATE.Text;
            dr["IGST_LEVY_SPL"] = txt_IGST_LEVY_SPL_Amt.Text;
            dr["IGST_LEVY_UNIT"] = txt_IGST_LEVY_UNIT.Text;
            dr["IGST_LEVY_SPL_TYPE"] = ddl_IGST_LEVY_SPL_TYPE.SelectedValue.ToString();
            dr["IGST_LEVY_EXCEPTION_NOTN"] = txt_IGST_LEVY_EXCEPTION_NOTN.Text.Trim();
            dr["IGST_LEVY_EXCEPTION_SLNO"] = txt_IGST_LEVY_EXCEPTION_SLNO.Text.Trim();
            dr["IGST_LEVY_EXCEPTION_RATE"] = txt_IGST_LEVY_EXCEPTION_RATE.Text;
            dr["IGST_LEVY_COMPENSATION_CESS_NOTN"] = txt_IGST_LEVY_COMPENSATION_CESS_NOTN.Text.Trim();
            dr["IGST_LEVY_COMPENSATION_CESS_SLNO"] = txt_IGST_LEVY_COMPENSATION_CESS_SLNO.Text.Trim();
            dr["IGST_LEVY_COMPENSATION_CESS_RATE"] = txt_IGST_LEVY_COMPENSATION_CESS_RATE.Text;
            dr["IGST_LEVY_COMPENSATION_CESS_SPL"] = txt_IGST_LEVY_COMPENSATION_CESS_SPL.Text;
            dr["IGST_LEVY_COMPENSATION_CESS_UNIT"] = txt_IGST_LEVY_COMPENSATION_CESS_UNIT.Text;
            dr["IGST_LEVY_COMPENSATION_CESS_SPL_TYPE"] = ddl_IGST_LEVY_COMPENSATION_CESS_SPL_TYPE.SelectedValue.ToString();
            dr["IGST_LEVY_EXCEPTION_CC_NOTN"] = txt_IGST_LEVY_EXCEPTION_CC_NOTN.Text.Trim();
            dr["IGST_LEVY_EXCEPTION_CC_SLNO"] = txt_IGST_LEVY_EXCEPTION_CC_SLNO.Text.Trim();
            dr["IGST_LEVY_EXCEPTION_CC_RATE"] = txt_IGST_LEVY_EXCEPTION_CC_RATE.Text;

            dr["LEVY_EXCEMPTION_NOTN_TYPE"] = ddl_LEVY_EXCEMPTION_NOTN_TYPE.SelectedValue;
            dr["LEVY_EXCEPTION_CC_NOTN_TYPE"] = ddl_LEVY_EXCEPTION_CC_NOTN_TYPE.SelectedValue;

            dr["SOCIAL_WELFARE_NOTN"] = txt_Social_Welfare_NOTN.Text.Trim();
            dr["SOCIAL_WELFARE_NOTN_SLNO"] = txt_Social_Welfare_NOTN_SL.Text.Trim();
            dr["SOCIAL_WELFARE_RATE"] = txt_Social_Welfare_Rate.Text.Trim();

            dr["AMENDMENT_TYPE"] = ddl_AmendmentType.SelectedValue;

            dr["AIDC_NOTN"] = txt_AIDC_NOTN.Text.Trim();
            dr["AIDC_NOTN_SLNO"] = txt_AIDC_NOTN_SLNO.Text.Trim();
            dr["AIDC_RATE"] = txt_AIDC_RATE.Text.Trim();
            dr["ADD_EX_RATE"] = txt_ADD_ExRate.Text.Trim();

            dr["EXC_AIDC_NOTN"] = txt_Exc_AIDC_NOTN.Text.Trim();
            dr["EXC_AIDC_NOTN_SLNO"] = txt_Exc_AIDC_NOTN_SLNO.Text.Trim();
            dr["EXC_AIDC_RATE"] = txt_Exc_AIDC_RATE.Text.Trim();
            dr["PART_NO"] = txtpartno.Text;

            dr["INFO_MSR"] = txt_Info_Msr.Text;
            dr["INFO_UQC"] = txt_Info_Uqc.Text;

            dt_mapping.Rows.Add(dr);

            if (SelectMode == "Y")
            {
                ViewState["dt_Prev_Table"] = dt_mapping;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }

    protected void Duty_Cal(object sender, EventArgs e)
    {
        string baseFolder = Server.MapPath("~/Submission/Icegate_HTML_TXT_Files/");

        string rawCode = txtCTH_No.Text;

        if (string.IsNullOrWhiteSpace(rawCode))
        {
            RenderAndStop("Please enter / select a RITC No before opening the Duty Calculator.");
            return;
        }

        string code = new string(rawCode.Where(char.IsDigit).ToArray()); 

        if (code.Length < 2)
        {
            RenderAndStop("'" + Server.HtmlEncode(rawCode) + "' is not a valid RITC/CTH code.");
            return;
        }

        string chapter = code.Substring(0, 2);
        string chapterFolder = Path.Combine(baseFolder, chapter);

        if (!Directory.Exists(chapterFolder))
        {
            RenderAndStop("No chapter folder '" + Server.HtmlEncode(chapter) +
                           "' found for RITC code '" + Server.HtmlEncode(code) + "'.");
            return;
        }

        string filePath = Path.Combine(chapterFolder, code + ".txt");

        if (!File.Exists(filePath))
        {
            RenderAndStop("No duty file found for RITC code '" + Server.HtmlEncode(code) +
                           "' in chapter '" + Server.HtmlEncode(chapter) + "'.");
            return;
        }

        StreamFile(filePath);
    }

    private void StreamFile(string filePath)
    {
        try
        {
            Encoding enc = Encoding.GetEncoding(1252); 
            string html = File.ReadAllText(filePath, enc);
            RenderRaw(html, enc);
        }
        catch (ThreadAbortException)
        {
            throw;
        }
        catch (Exception ex)
        {
            RenderAndStop("Could not read the duty file:<br/>" + Server.HtmlEncode(ex.Message));
        }
    }

    private void RenderAndStop(string message)
    {
        string body = "<div style='color:#b00020;font-weight:bold;border:1px solid #b00020;padding:12px;background:#fff4f4;'>" +
                      message + "</div>";
        RenderRaw("<html><body style='font-family:Segoe UI,Arial,sans-serif;padding:20px;'>" + body + "</body></html>", Encoding.UTF8);
    }

    private void RenderRaw(string html, Encoding encoding)
    {
        Response.Clear();
        Response.ContentType = "text/html";
        Response.ContentEncoding = encoding;
        Response.Write(html);
        Response.End();
    }
  
}
                                                                                                                                                                                                                                                                                                                                                                           