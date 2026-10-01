using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Export_PDF_Settings_Master : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    Product_Export_Master product = new Product_Export_Master();
    DataSet dtuser = new DataSet();
    public int i;
    public string chk;
    adminmaster adm = new adminmaster();

    AppSession aps = new AppSession();
    public string PRODUCT_IMPORT_ID = "";
    ErrorLogs er = new ErrorLogs();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);


    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    public int Screen_Id;

    protected void Page_Load(object sender, EventArgs e)
    {


        aps.checkSession();

        hdn_companyID.Value = Connection.COMPANYID();
        txt_IEC_ExporterName.Focus();

        Call_Server_Side_Method();

        if (!IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 27;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//

            Get_SchemeCode();
            ddlBind();

            Hdn_STANDARD_TYPE.Value = "STD";
            //hdfTransport_mode.Value = Session["hdfTransport_mode"].ToString();
            hdfTransport_mode.Value = "";

            txt_BranchNo.Attributes.Add("onblur", "javascript:CallServerside_Importer_STD('" + txt_IEC_ExporterName.ClientID + "', '" + txt_BranchNo.ClientID + "')");

            txtDrawback_SLNo.Attributes.Add("onblur", "javascript:CallServerside_Drawback('" + txtDrawback_SLNo.ClientID  + "')");

            EditSupDetails();

            if (hdn_companyID.Value == "10" || hdn_companyID.Value == "1039")
            {
                txt_InfoMSR.Visible = true;
                lblInfoMsr.Visible = true;
            }
        }


    }
    public void Page_Rights(int i)
    {
        user_Create.RetrieveAll_User_Screen_Rights_Details(i);
        PAGE_WRITE = user_Create.PAGE_WRITE;
        PAGE_READ = user_Create.PAGE_READ;
        PAGE_MODIFY = user_Create.PAGE_MODIFY;
        PAGE_DELETE = user_Create.PAGE_DELETE;

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
                btnUpdate.Enabled = true;
            else
            {
                btnUpdate.Enabled = false;
                btnUpdate.ToolTip = "You don't have permission to access";
            }
            //---------------DELETE BUTTON------------------//

            if (PAGE_DELETE == "True")
                btnDelete.Enabled = true;
            else
            {
                btnDelete.Enabled = false;
                btnDelete.ToolTip = "You don't have permission to access";
            }
        }
    }



    public void ddlBind()
    {
        #region SPL Type
        //ddlBasicSPLTYPE.Items.Clear();
        //ddlBasicSPLTYPE.Items.Add("Plus");
        //ddlBasicSPLTYPE.Items.Add("Minus");
        //ddlBasicSPLTYPE.Items.Add("Lower");
        //ddlBasicSPLTYPE.Items.Add("Higher");


        # endregion

    }

    public void EditSupDetails()
    {

        if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null)
        {
            int i = 0;
            PRODUCT_IMPORT_ID = Request.QueryString["ID"];
            erm.Eproduct_imp_id = PRODUCT_IMPORT_ID;
            erm.Eproduct_imp_cth = "0";
            erm.Eproduct_imp_ceth = "0";
            erm.Eproduct_imp_ritc = "0";
            erm.Eproduct_imp_description = "0";
            erm.Ename = "select_conwithcode";
            erm.EWorking_Period = Connection.WorkingPeriod();

            dtuser = erm.RetrieveAll_Export_PDF_Settings_MASTER();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                ddlBind();
                txt_IEC_ExporterName.Text = dtuser.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                txt_BranchNo.Text = dtuser.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                txt_IECNo.Text = dtuser.Tables[0].Rows[0]["IEC_NO"].ToString();
                txtRITCNo.Text = dtuser.Tables[0].Rows[0]["RITC_NO"].ToString();
                txt_PartNo.Text = dtuser.Tables[0].Rows[0]["PRODUCT_PARTNO"].ToString();
                txtDescription.Text = dtuser.Tables[0].Rows[0]["ITEM_DESC"].ToString();
                ddlType_Exp.SelectedValue = dtuser.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString();
                ddlSchemeCode.SelectedValue = dtuser.Tables[0].Rows[0]["SCHEME_CODE"].ToString();
                ddlRewardPoints.SelectedValue = dtuser.Tables[0].Rows[0]["REWARD_YES_NO"].ToString();
                ddl_STR_YN.SelectedValue = dtuser.Tables[0].Rows[0]["STR_YES_NO"].ToString();
                txtSTRCode.Text = dtuser.Tables[0].Rows[0]["STR_CODE"].ToString();
                ddl_Rodtep_YN.SelectedValue = dtuser.Tables[0].Rows[0]["RODTEP"].ToString();
                ddl_Cess_YN.SelectedValue = dtuser.Tables[0].Rows[0]["CESS_YN"].ToString();
                ddl_IGST_Payment.SelectedValue = dtuser.Tables[0].Rows[0]["IGST_PAYMENT"].ToString();

                txt_PTA_FTA.Text = dtuser.Tables[0].Rows[0]["UNDER_PTA_FTA"].ToString();
                txt_IGST_Rate.Text = dtuser.Tables[0].Rows[0]["IGST_RATE"].ToString();
                txtDrawback_SLNo.Text = dtuser.Tables[0].Rows[0]["DBK_SL_NO"].ToString();
                txt_DBK_Unit.Text = dtuser.Tables[0].Rows[0]["DBK_UNIT"].ToString();
                txt_UOM.Text = dtuser.Tables[0].Rows[0]["SQC_UOM"].ToString();
                
                //txtExporterName.Text = dtuser.Tables[0].Rows[0]["ITEM_EXPORTER_NAME"].ToString();
                //string Reward_Points = rep.Replace(ds_F.Tables[4].Rows[0]["REWARD_POINTS"].ToString());

                //ddlRewardPoints.Items.Clear();
                //ddlRewardPoints.Items.Add("Yes");
                //ddlRewardPoints.Items.Add("No");

                //if (Reward_Points == "Y")
                //{
                //    ddlRewardPoints.SelectedValue = "Yes";
                //}
                //else
                //{
                //    ddlRewardPoints.SelectedValue = "No";
                //}

                txtExporterName.Text = dtuser.Tables[0].Rows[0]["TP_EXPORTER_NAME"].ToString();
                txtIECCode.Text = dtuser.Tables[0].Rows[0]["TP_ITEM_IECCODE"].ToString().Replace("&nbsp;", "");
                txtBranchSLNo.Text = dtuser.Tables[0].Rows[0]["TP_BR_SLNO"].ToString().Replace("&nbsp;", "");
                txtAddress.Text = dtuser.Tables[0].Rows[0]["TP_ADDRESS1"].ToString();
                txtAddress1.Text = dtuser.Tables[0].Rows[0]["TP_ADDRESS2"].ToString();
                txtAddress2.Text = dtuser.Tables[0].Rows[0]["TP_ADDRESS3"].ToString();
                txtAddress3.Text = dtuser.Tables[0].Rows[0]["TP_ADDRESS4"].ToString();
                txtAddress4.Text = dtuser.Tables[0].Rows[0]["TP_ADDRESS5"].ToString();
                //txtSTRCode.Text = dtuser.Tables[0].Rows[0]["ITEM_STR_CODE"].ToString().Replace("&nbsp;", "");

                txt_Manufacturer_producer.Text = dtuser.Tables[0].Rows[0]["MANUFACTURER_PRODUCER"].ToString().Replace("&nbsp;", "");
                txt_Manu_produ_grower_code.Text = dtuser.Tables[0].Rows[0]["M_P_GROWER_CODE"].ToString().Replace("&nbsp;", "");
                txt_Manufacturer_Add1.Text = dtuser.Tables[0].Rows[0]["M_P_GROWER_ADD1"].ToString();
                txt_Manufacturer_Add2.Text = dtuser.Tables[0].Rows[0]["M_P_GROWER_ADD2"].ToString();
                txt_Manufacturer_City.Text = dtuser.Tables[0].Rows[0]["M_P_GROWER_CITY"].ToString();
                txt_Manu_Country_Subdiv.Text = dtuser.Tables[0].Rows[0]["M_P_GROWER_COUNTRY_SUBDIV"].ToString();
                txt_Manufacturer_pincode.Text = dtuser.Tables[0].Rows[0]["M_P_GROWER_PIN"].ToString();
                txt_Manufacturer_Country.Text = dtuser.Tables[0].Rows[0]["M_P_GROWER_COUNTRY"].ToString().Replace("&nbsp;", "");
                txt_Manu_Source_State.Text = dtuser.Tables[0].Rows[0]["SOURCE_STATE"].ToString();
                txt_manu_Transit_Country.Text = dtuser.Tables[0].Rows[0]["TRANSIT_COUNTRY"].ToString().Replace("&nbsp;", "");
                txt_Accessory_status.Text = dtuser.Tables[0].Rows[0]["ACCESSORY_STATUS"].ToString();

                ddl_GSTN_Type.SelectedValue = dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString().Replace("&nbsp;", "");
                txt_GSTN_ID.Text = dtuser.Tables[0].Rows[0]["GSTN_ID"].ToString();

                txt_HAWB_No.Text = dtuser.Tables[0].Rows[0]["HAWB_NO"].ToString();
                txt_Total_Pkgs.Text = dtuser.Tables[0].Rows[0]["TOTAL_PKGS"].ToString();
                txtEnduseItem.Text = dtuser.Tables[0].Rows[0]["END_USE_OF_ITEM"].ToString().Replace("&nbsp;", "");
                txt_ADCode.Text = dtuser.Tables[0].Rows[0]["ADCODE"].ToString().Replace("&nbsp;", "");
                txt_InfoMSR.Text = dtuser.Tables[0].Rows[0]["INFO_MSR"].ToString();
                txt_InfoUQC.Text = dtuser.Tables[0].Rows[0]["INFO_UQC"].ToString();


                chk_DB001.Checked = false;
                chk_DB002.Checked = false;
                chk_DB003.Checked = false;

                if (dtuser.Tables[0].Rows[0]["DBK_DECLARATION"].ToString().Contains("1"))
                {
                    chk_DB001.Checked = true;
                }
                if (dtuser.Tables[0].Rows[0]["DBK_DECLARATION"].ToString().Contains("2"))
                {
                    chk_DB002.Checked = true;
                }
                if (dtuser.Tables[0].Rows[0]["DBK_DECLARATION"].ToString().Contains("3"))
                {
                    chk_DB003.Checked = true;
                }

                Hdn_RITC_4_digit.Value = txtRITCNo.Text.Substring(0, 4);


                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["ID"].ToString();
                //FOR UPDATED SUCCESSFULLY


            }
            HiddenField1.Value = Request.QueryString["ID"].ToString();
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = true;

        }
        else
        {
            ddl_STR_YN.SelectedValue = "N";
            txtSTRCode.Enabled = false;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
        }
    }

    public int insert_update(string a1, string a2, string a3, string a4)
    {

        product.ID = a1;
        product.EXPORTER_NAME = txt_IEC_ExporterName.Text;
        product.IEC_NO = txt_IECNo.Text;
        product.BRANCH_NO = txt_BranchNo.Text;
        product.TYPE_OF_EXPORTER = ddlType_Exp.SelectedValue;
        product.PRODUCT_PARTNO = txt_PartNo.Text;
        product.RITC_NO = txtRITCNo.Text;
        product.ADCODE = txt_ADCode.Text;
        product.ITEM_DESC = txtDescription.Text;
        product.REWARD_YES_NO = ddlRewardPoints.SelectedValue;
        product.STR_YES_NO = ddl_STR_YN.SelectedValue;
        product.STR_CODE = txtSTRCode.Text;
        product.RODTEP = ddl_Rodtep_YN.SelectedValue;
        product.CESS_YN = ddl_Cess_YN.SelectedValue;
        product.SCHEME_CODE = ddlSchemeCode.SelectedItem.Text;
        product.END_USE_OF_ITEM = txtEnduseItem.Text;
        product.UNDER_PTA_FTA = txt_PTA_FTA.Text;
        product.IGST_PAYMENT = ddl_IGST_Payment.SelectedItem.Text;
        product.IGST_RATE = txt_IGST_Rate.Text;
        product.DBK_SL_NO = txtDrawback_SLNo.Text;
        product.DBK_UNIT = txt_DBK_Unit.Text;

        string dbk_decl = "";
        if (chk_DB001.Checked == true)
        {
            dbk_decl += "DB001" + ",";
        }
        if (chk_DB002.Checked == true)
        {
            dbk_decl += "DB002" + ",";
        }
        if (chk_DB003.Checked == true)
        {
            dbk_decl += "DB003" + ",";
        }

        product.DBK_DECLARATION = dbk_decl;

        product.SQC_UOM = txt_UOM.Text;        
        product.ITEM_ACCESSORIES_DESC = txtAccessoryDesc.Text;
        product.TP_EXPORTER_NAME = txtExporterName.Text;
        product.TP_ITEM_IECCODE = txtIECCode.Text;
        product.TP_BR_SLNO = txtBranchSLNo.Text;
        product.TP_ADDRESS1 = txtAddress.Text;
        product.TP_ADDRESS2 = txtAddress1.Text;
        product.TP_ADDRESS3 = txtAddress2.Text;
        product.TP_ADDRESS4 = txtAddress3.Text;
        product.TP_ADDRESS5 = txtAddress4.Text;
        product.GSTN_TYPE = ddl_GSTN_Type.SelectedValue;
        product.GSTN_ID = txt_GSTN_ID.Text;
        product.MANUFACTURER_PRODUCER = txt_Manufacturer_producer.Text;
        product.M_P_GROWER_CODE = txt_Manu_produ_grower_code.Text;
        product.M_P_GROWER_ADD1 = txt_Manufacturer_Add1.Text;
        product.M_P_GROWER_ADD2 = txt_Manufacturer_Add2.Text;
        product.M_P_GROWER_CITY = txt_Manufacturer_City.Text;
        product.M_P_GROWER_COUNTRY_SUBDIV = txt_Manu_Country_Subdiv.Text;
        product.M_P_GROWER_PIN = txt_Manufacturer_pincode.Text;
        product.M_P_GROWER_COUNTRY = txt_Manufacturer_Country.Text;
        product.SOURCE_STATE = txt_Manu_Source_State.Text;
        product.TRANSIT_COUNTRY = txt_manu_Transit_Country.Text;
        product.ACCESSORY_STATUS = txt_Accessory_status.Text;
        product.HAWB_NO = txt_HAWB_No.Text;
        product.TOTAL_PKGS = txt_Total_Pkgs.Text;
        product.REMARKS = "";
        product.INFO_MSR = txt_InfoMSR.Text;
        product.INFO_UQC = txt_InfoUQC.Text.ToUpper();
        product.flag = a2;

        int i = product.EXPORT_PDF_SETTINGS_MASTER_Insert_Update();
        return i;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtDescription.Text != "" && txtRITCNo.Text != "" && txt_IEC_ExporterName.Text != "" && txt_BranchNo.Text != "")
        {
            try
            {
                string chk;
                chk = "N";
                
                string a1 = "";
                string a2 = "S";
                string a3 = "";
                i = insert_update(a1, a2, a3, chk);
                HiddenField1.Value = Convert.ToString(erm.UPDATE_ID);

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
                        btnSave.Focus();
                        hdn_Update_Product.Value = txtDescription.Text;

                    }
                    //-----------------------FOR USER RIGHTS--------------------------------//

                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnSave");
                }
                else if (i == 2)
                {
                    Alert_msg("Product already exixts!", "btnSave");
                }
                else
                {
                    Alert_msg("Product Not Saved", "btnNew");
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Field");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            erm.Eproduct_imp_id = HiddenField1.Value;
            erm.Eproduct_imp_cth = "0";
            erm.Eproduct_imp_ceth = "0";
            erm.Eproduct_imp_ritc = "0";
            erm.Eproduct_imp_description = "0";
            erm.EWorking_Period = Connection.WorkingPeriod();
            erm.Ename = "delete";

            erm.RetrieveAll_Export_PDF_Settings_MASTER();
            int ii = 0;
            ii = erm.result;

            if (ii > 0)
            {
                ViewState["UPDATED_ID"] = null;

                string prompt = "<script>$(document).ready(function(){{jAlert('Product Deleted', 'PRODUCT MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

            }
            else
            {
                Alert_msg("Product Not Deleted");
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
            if (txtDescription.Text != "" && txtRITCNo.Text != "" && txt_IEC_ExporterName.Text != "" && txt_BranchNo.Text != "")
            {
                string chk;
                
                chk = "N";
                string a1 = HiddenField1.Value;
                string a2 = "U";
                string a3 = "";
                i = insert_update(a1, a2, a3, chk);
                if (i == 1)
                {
                    hdn_Update_Product.Value = txtDescription.Text;


                    if (ViewState["UPDATED_ID"] != null)
                    {
                        Alert_msg("Updated Successfully", "btnUpdate");
                    }
                    else
                    {
                        Alert_msg("Saved Successfully", "btnUpdate");
                    }
                }
                else if (i == 2)
                {
                    Alert_msg("Product already exixts!", "btnUpdate");
                }
                else
                {
                    Alert_msg("Product Not Saved", "btnUpdate");
                }
            }
            else
            {
                Alert_msg("Enter All Mandatory Field");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Manipulation mo = new Manipulation();
        mo.ResetFields(Page.Controls);
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        hdn_Update_Product.Value = "";
        ViewState["UPDATED_ID"] = null;

    }

    public void hiddenval()
    {
        if (HiddenField2.Value != "")
        {
            string a = HiddenField2.Value;
            if (a == "1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clientscript", "<script language='javascript'>Tab('1');</script>", false);

            }
            else if (a == "2")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clientscript", "<script language='javascript'>Tab('2');</script>", false);

            }
            else if (a == "3")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clientscript", "<script language='javascript'>Tab('3');</script>", false);

            }
        }
    }


    protected void txtDescription_TextChanged(object sender, EventArgs e)
    {
        if (hdn_Update_Product.Value != txtDescription.Text)
        {

            try
            {
                erm.Eproduct_imp_id = "0";
                erm.Eproduct_imp_cth = "0";
                erm.Eproduct_imp_ceth = "0";
                erm.Eproduct_imp_ritc = "0";
                erm.Eproduct_imp_description = txtDescription.Text;

                erm.EWorking_Period = Connection.WorkingPeriod();

                erm.Ename = "Check_Product";

                dtuser = erm.RetrieveAll_Product_import_MASTER();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    Alert_msg("Product already exists!", "txt_PartNo");

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Product already exists!')</script>", false);
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        txt_PartNo.Focus();
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'PRODUCT MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'PRODUCT MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Call_Server_Side_Method()
    {
        //infra_cess
        //txtinfra_cess_Notn_SLNO.Attributes.Add("onblur", "javascript:CallServerside_infra_cess_Notn_SLNO('" + txtinfra_cess_Notn_SLNO.ClientID + "', '" + txtinfra_cess_Notn.ClientID + "')");
        //infra_cess

        //txtCTHNO.Attributes.Add("onblur", "javascript:Call_CTH_Rate('" + txtCTHNO.ClientID + "', '" + txtBasicSLNO.ClientID + "')");
        //txtCETH_No.Attributes.Add("onblur", "javascript:Call_CETH_Rate('" + txtCETH_No.ClientID + "', '" + txtBasicSLNO.ClientID + "')");

        ///------------------------------------------------auto search-----------------------------------------------------------------

    }

    public void Get_SchemeCode()
    {
        DataSet ds_sh = new DataSet();
        adm.name = "SCHEME_EXPORT_CODE";
        Session["dss"] = adm.RetrieveAll_Scheme_Export();
        ds_sh = (DataSet)Session["dss"];
        ddlSchemeCode.DataSource = ds_sh;
        ddlSchemeCode.DataTextField = "SCHEME_CODE";
        ddlSchemeCode.DataValueField = "SCHEME_CODE";
        ddlSchemeCode.Items.Add("");
        ddlSchemeCode.DataBind();

    }

    [System.Web.Services.WebMethod]
    public static string GetImporter_2(string custid, string custid_2)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        string STD_Type = "";

        if (HttpContext.Current.Session["STANDARD_TYPE"] != null)
        {
            STD_Type = HttpContext.Current.Session["STANDARD_TYPE"].ToString();

            if (STD_Type == "Non_STD")
            {
                STD_Type = STD_Type;
            }
            else
            {
                STD_Type = "";
            }
        }

        Auto.Ename = "IMP_EXP_MASTER_IMPORTER_SEARCH_ADCODE";
        Auto.Enamesearch = custid;
        Auto.NSearch = custid_2;
        Auto.STANDARD_TYPE = STD_Type;

        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Adcode = "", Adcode_Bank_Account = "", IFSC_Code = "";

            string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
            string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();

            if (IECNo != "")
            {
                Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                Auto.Enamesearch = BranchNo;
                Auto.NSearch = IECNo;
                dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                if (dss.Tables[0].Rows.Count == 0)
                {
                    Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                    Auto.Enamesearch = "";
                    Auto.NSearch = IECNo;
                    dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                }

                if (dss.Tables[0].Rows.Count > 0)
                {
                    if (dss.Tables[0].Rows.Count == 1)
                    {
                        Adcode = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                        Adcode_Bank_Account = dss.Tables[0].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();
                        IFSC_Code = dss.Tables[0].Rows[0]["ADCODE_IFSC_CODE"].ToString();
                    }
                }
            }


            custid = IECNo + "~~" + BranchNo + "~~" + Adcode;
        }

        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_RITC_Info_Uqc(string Info_Uqc)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Ename = "Get_EXPORT_RITC_Info_Uqc";
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
        return Info_Uqc;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Drawback_Master(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Ename = "DRAWBACK_MASTER_ALL";
        Auto.Enamesearch = custid;
        Auto.Notn_No_Search = "";

        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Address1 = ds.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString();
           
            custid = Address1 + "~~";
        }
        return custid;
    }
}