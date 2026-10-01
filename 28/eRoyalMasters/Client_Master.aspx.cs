using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;

public partial class eRoyalMasters_Client_Master : ThemeClass
{

    public int i;
    public string AUTO_ID;
    
    eroyalmaster erm = new eroyalmaster();
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    Default_Settings Default = new Default_Settings();
    User_Creation user_Create = new User_Creation();
    DropDownList ddl = new DropDownList();

    DataSet dtuser = new DataSet();
    DataSet dtuser_branch = new DataSet();
    DataSet ds_branch = new DataSet();
    DataSet ds = new DataSet();
    
    public string IMP_EXP_ID = "",currentuser,currentbranch,Working_Period,STANDARD_TYPE,Defult_STD_Type;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE,  Is_Master_Id;
    public int Screen_Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Connection.Current_User();
        currentbranch = Connection.Current_Branch();
        Working_Period = Connection.WorkingPeriod();
        STANDARD_TYPE = RadioButtonList_TYPE.SelectedValue;
       
        ddl.Items.Clear();
        txtName.Attributes["value"] = txtName.Text;

            if (!IsPostBack)
            {
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 1;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                txtIECNO.Focus();
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnNew.Visible = true;
                btnSave.Visible = true;

                Label_branch.Visible = false;
                ddlBranches.Visible = false;

                ddlType.Items.Clear();

                
                ddlType.Items.Add("GOVERNMENT DEPARTMENTS");
                ddlType.Items.Add("GOVERNMENT UNDERTAKINGS");
                ddlType.Items.Add("OTHERS");
                ddlType.Items.Add("PRIVATE");
                ddlType.Items.Add("JOBBING");
                ddlType.Items.Add("REPAIR & RETURN");
                ddlType.Items.Add("EXHIBITION");
                ddlType.Items.Add("DESTRUCTION");
                ddlType.Items.Add("MOVEMENT OF GOODS");

                Session["flag"] = "SAVE";

                Get_Client_Default_Settings();
                Edit_ClientDetails();
                Bind_Branches_StandardTYPE();

                //txtStateName.Attributes.Add("onblur", "javascript:CallServerside_State_Name_Validation('" + txtStateName.ClientID + "')");
                //txtStateName.Attributes.Add("onkeyup", "javascript:CallServerside_State_Name_Validation('" + txtStateName.ClientID + "')");

                txtStateName.Attributes.Add("onblur", "javascript:CallServerside_State_Name_Validation_clientMaster('" + txtStateName.ClientID + "')");
                txtStateName.Attributes.Add("onkeyup", "javascript:CallServerside_State_Name_Validation_clientMaster('" + txtStateName.ClientID + "')");


                //txtCommercial_StateName.Attributes.Add("onblur", "javascript:CallServerside_State_Name_Validation_clientMaster('" + txtCommercial_StateName.ClientID + "','" + "txtCommercial_StateName" + "')");
                //txtCommercial_StateName.Attributes.Add("onkeyup", "javascript:CallServerside_State_Name_Validation_clientMaster('" + txtCommercial_StateName.ClientID + "','" + "txtCommercial_StateName" + "')");

                txtCommercial_StateName.Attributes.Add("onblur", "javascript:CallServerside_Commercial_State_Name_Validation_clientMaster('" + txtCommercial_StateName.ClientID + "')");
                txtCommercial_StateName.Attributes.Add("onkeyup", "javascript:CallServerside_Commercial_State_Name_Validation_clientMaster('" + txtCommercial_StateName.ClientID + "')");
                

            }

            if (txtIECNO.Text != string.Empty && txtName.Text != string.Empty)
            {
                lbliec.Visible = true;
            }
            else
            {
                lbliec.Visible = false;
            }

            if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "1344" || Connection.COMPANYID() == "1572" || Connection.COMPANYID() == "1623" || Connection.COMPANYID() == "2078" || Connection.COMPANYID() == "2152" || Connection.COMPANYID() == "2118" || Connection.COMPANYID() == "2153" || Connection.COMPANYID() == "2154" || Connection.COMPANYID() == "2155" || Connection.COMPANYID() == "2214" || Connection.COMPANYID() == "2305")//Ringo Cargo
            {
                div_dbk_decl.Visible = true;
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
    public void Edit_ClientDetails()
    {
        if (Request.QueryString["IMP_EXP_ID"] != "" && Request.QueryString["IMP_EXP_ID"] != null)
        {
           // string ClientName = WebUtility.HtmlDecode(Request.QueryString["Name"].ToString());
            string ClientName = Request.QueryString["Name"].ToString();
           
            int i = 0;
            IMP_EXP_ID = Request.QueryString["IMP_EXP_ID"];
            hdn_id.Value = IMP_EXP_ID;
            erm.Eimp_exp_id = IMP_EXP_ID;
            erm.Eimp_exp_name = ClientName;
            erm.Eimp_exp_iecno = txtIECNO.Text;
            erm.Eimp_exp_brslno = "0";
            erm.Ename = "select_conwithcode_STD";
            erm.EWorking_Period = Working_Period;
            erm.STANDARD_TYPE = Session["get_ddlType"].ToString();
            dtuser = erm.RetrieveAll_Imp_exp_master_STD_TYPE();

            if (dtuser.Tables[0].Rows.Count > 0)
            {
                STANDARD_TYPE = dtuser.Tables[0].Rows[0]["STANDARD_TYPE"].ToString();
                ViewState["STANDARD_TYPE"] = STANDARD_TYPE;
            }
            
            if (STANDARD_TYPE == "Non_STD")
            {
                txtName.Enabled = true;
            }
            else
            {
                txtName.Enabled =false ;               
            }

            if (dtuser.Tables[0].Rows.Count > 0)
            {
                Session["flag"] = "UPDATE";

                Rdstr.SelectedValue = dtuser.Tables[0].Rows[0]["EXP_STR_YN"].ToString();

                AUTO_ID = dtuser.Tables[0].Rows[0]["IMP_EXP_ID"].ToString();
                txtName.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                txtIECNO.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                txtBranchNO.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                string type = dtuser.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                txtIECNO.Enabled = false;

                txtAdd1.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                txtAdd2.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                txtcity.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                txtStateName.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                txtPincode.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                txtContactPerson.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_CONTACT_PERSON"].ToString();
                txtPhoneNO.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_PHONE"].ToString();
                txtFax.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_FAX"].ToString();
                txtEmail.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_EMAIL"].ToString();
                txtDrawback_AC_No.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_DRAWBACK_AC_NO"].ToString();

                txtPAN_No.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_PAN_NO"].ToString();

                txtBinNO.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_BINNO"].ToString();
                txtRemarks.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_REMARKS"].ToString();
                txt_TIN_No.Text = dtuser.Tables[0].Rows[0]["TIN_NO"].ToString();
                hdn_Txt_Statecode.Value = dtuser.Tables[0].Rows[0]["STATE_CODE"].ToString();
         
                ddlType.Items.Clear();
               
                ddlType.Items.Add("GOVERNMENT DEPARTMENTS");
                ddlType.Items.Add("GOVERNMENT UNDERTAKINGS");
                ddlType.Items.Add("OTHERS");
                ddlType.Items.Add("PRIVATE");
                ddlType.Items.Add("JOBBING");
                ddlType.Items.Add("REPAIR & RETURN");
                ddlType.Items.Add("EXHIBITION");
                ddlType.Items.Add("DESTRUCTION");
                ddlType.Items.Add("MOVEMENT OF GOODS");

                ddlType.Items.Remove(type);
                if (!string.IsNullOrEmpty(type))
                {
                    ddlType.Items.Insert(0, type);
                }

                Label_branch.Visible = true;
                ddlBranches.Visible = true;

                ddlBranches.SelectedValue = dtuser.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                RadioButtonList_TYPE.SelectedValue = dtuser.Tables[0].Rows[0]["STANDARD_TYPE"].ToString();
                HiddenField1.Value = Request.QueryString["IMP_EXP_ID"].ToString();

                txt_Marksnos.Text = dtuser.Tables[0].Rows[0]["MARKS_NO"].ToString();
                string Exporter_Type = dtuser.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString();

                //ddlCommercial_Tax_yn.SelectedValue = dtuser.Tables[0].Rows[0]["M_COMMERCIAL_DETAILS_STATUS"].ToString();// hide on 30-07-2024
                hdn_ddlCommercial_Tax_yn.Value = dtuser.Tables[0].Rows[0]["M_COMMERCIAL_DETAILS_STATUS"].ToString();
                txtCommercial_StateName.Text = dtuser.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATENAME"].ToString();
                txtCommercial_StateCode.Text = dtuser.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATECODE"].ToString();

                ddl_EXP_GSTN_Type.SelectedValue = dtuser.Tables[0].Rows[0]["M_COMMERCIAL_TAX_TYPE"].ToString();
                txtCommercial_RegistrationNo.Text = dtuser.Tables[0].Rows[0]["M_COMMERCIAL_TAX_REGISTRATION_NO"].ToString();

                if (txtCommercial_RegistrationNo.Text != "")
                {
                    hdn_checkVal.Value = "Avail";

                }
                else
                {
                    hdn_checkVal.Value = "New";
                }

                if (Exporter_Type == "R")
                {
                    ddlType_Exp.Items.Clear();
                    ddlType_Exp.Items.Add("Manufacturer - ( F )");
                    ddlType_Exp.Items.Insert(0, "Merchant - ( R )");
                }
                else
                {
                    ddlType_Exp.Items.Clear();
                    ddlType_Exp.Items.Add("Merchant - ( R )");
                    ddlType_Exp.Items.Insert(0, "Manufacturer - ( F )");
                }

                if (dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "GSN")
                {
                    ddlGSTN_Type.SelectedValue = dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                }
                else if (dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "GSG")
                {
                    ddlGSTN_Type.SelectedValue = dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                }
                else if (dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "GSD")
                {
                    ddlGSTN_Type.SelectedValue = dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                }
                else if (dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "PAN")
                {
                    ddlGSTN_Type.SelectedValue = dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                }
                else if (dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "TAN")
                {
                    ddlGSTN_Type.SelectedValue = dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                }
                else if (dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "PSP")
                {
                    ddlGSTN_Type.SelectedValue = dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                }
                else if (dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "ADH")
                {
                    ddlGSTN_Type.SelectedValue = dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                }
                else
                {
                    ddlGSTN_Type.SelectedValue = "";
                }

                /*
                if (dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "GSN")
                {
                    ddlGSTN_Type.SelectedItem.Text = "G/GSN  -GSTIN of Normal Persons Individual IEC";
                }
                else if (dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "GSG")
                {
                    ddlGSTN_Type.SelectedItem.Text = "O/GSG GSTIN of Govt.Entities";
                }
                else if (dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "GSD")
                {
                    ddlGSTN_Type.SelectedItem.Text = "D/GSD - GSTIN of Diplomats";
                }
                else if (dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "PAN")
                {
                    ddlGSTN_Type.SelectedItem.Text = "I/PAN PAN Number (AAAPL1234C)";
                }
                else if (dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "TAN")
                {
                    ddlGSTN_Type.SelectedItem.Text = "T/TAN TAN Number (AAAP12345C)";
                }
                else if (dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "PSP")
                {
                    ddlGSTN_Type.SelectedItem.Text = "P/PSP -Passport Number( Max 9 Characters-AN)";
                }
                else if (dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "ADH")
                {
                    ddlGSTN_Type.SelectedItem.Text = "A/ADH Aadhaar Number( 12 Numeric)";
                }
                else
                {
                    ddlGSTN_Type.SelectedItem.Text = "";
                }
                 */

                txtGSTN_ID.Text = dtuser.Tables[0].Rows[0]["GSTN_ID"].ToString();
                txtDistrict.Text = dtuser.Tables[0].Rows[0]["DISTRICT"].ToString();

                hdn_StateName.Value = dtuser.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                hdn_StateName_chk.Value = Set_State_Name_Validation(hdn_StateName.Value);

                hdn_Commercial_StateName.Value = dtuser.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATENAME"].ToString();
                hdn_Commercial_StateName_chk.Value = Set_State_Name_Validation(hdn_Commercial_StateName.Value);

                chk_DB001.Checked = false;
                chk_DB002.Checked = false;
                chk_DB003.Checked = false;

                if (dtuser.Tables[0].Rows[0]["EXP_DBK_DECL_CHK"].ToString().Contains("1"))
                {
                    chk_DB001.Checked = true;
                }
                if (dtuser.Tables[0].Rows[0]["EXP_DBK_DECL_CHK"].ToString().Contains("2"))
                {
                    chk_DB002.Checked = true;
                }
                if (dtuser.Tables[0].Rows[0]["EXP_DBK_DECL_CHK"].ToString().Contains("3"))
                {
                    chk_DB003.Checked = true;
                }

                txt_SEZ_IcegateID.Text = dtuser.Tables[0].Rows[0]["SEZ_ICEGATE_ID"].ToString();
                txt_SEZ_PANNo.Text = dtuser.Tables[0].Rows[0]["SEZ_PAN_NO"].ToString();

                txt_SEZ_AP_ID.Text = dtuser.Tables[0].Rows[0]["SEZ_AP_ID"].ToString();
                txt_SEZ_AP_Name.Text = dtuser.Tables[0].Rows[0]["SEZ_AP_NAME"].ToString();

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnAdcode.Visible = true;
                btnSave.Visible = false;
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["IMP_EXP_ID"].ToString();
                //FOR UPDATED SUCCESSFULLY
            }
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;          
            btnSave.Visible = true;
        }
    }
    public void Bind_Branches_StandardTYPE()
    {
        if (Request.QueryString["IMP_EXP_ID"] != "" && Request.QueryString["IMP_EXP_ID"] != null)
        {
            int i = 0;
            IMP_EXP_ID = HiddenField1.Value;
            hdn_id.Value = IMP_EXP_ID;
            erm.Eimp_exp_id = IMP_EXP_ID;
            erm.Eimp_exp_name = Request.QueryString["Name"].ToString();
            erm.Eimp_exp_iecno = txtIECNO.Text;
            erm.Eimp_exp_brslno = "0";
            erm.Ename = "BIND_BRANCHES_STANDARD_TYPE";
            erm.EWorking_Period = Working_Period;
            erm.STANDARD_TYPE = ViewState["STANDARD_TYPE"].ToString();

            ds_branch = erm.RetrieveAll_Imp_exp_master_STD_TYPE();

            if (ds_branch.Tables[0].Rows.Count > 0)
            {
                Label_branch.Visible = true;
                ddlBranches.Visible = true;

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;

                ddlBranches.DataSource = ds_branch.Tables[0];
                ddlBranches.DataTextField = "IMP_EXP_BRSLNO";
                ddlBranches.DataValueField = "IMP_EXP_BRSLNO";
                ddlBranches.DataBind();
            }
            else
            {
                Label_branch.Visible = false;
                ddlBranches.Visible = false;

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
               
                txtBranchNO.Text = "";
                txtAdd1.Text = "";
                txtAdd2.Text = "";
                txtcity.Text = "";
                txtPhoneNO.Text = "";
                txtFax.Text = "";
                txtEmail.Text = "";
                txtContactPerson.Text = "";
                ddlType.SelectedIndex = -1;
                txtPincode.Text = "";
                txtBinNO.Text = "";
                txtRemarks.Text = "";
                //ddlCommercial_Tax_yn.SelectedIndex = -1;// hide on 30-07-2024
                txtCommercial_StateName.Text = string.Empty;
                txtCommercial_StateCode.Text = string.Empty;
                ddl_EXP_GSTN_Type.Text = string.Empty;
                ddlGSTN_Type.Text = string.Empty;
                txtCommercial_RegistrationNo.Text = string.Empty;
            
            }
            Bind_BranchDetails_All();
        }
    }

    public void Bind_BranchDetails_All()
    {
        try
        {
            get_IMP_EXP_ID();
            erm.Eimp_exp_id = HiddenField1.Value;
            erm.Eimp_exp_name = txtName.Text;
            erm.Eimp_exp_iecno = txtIECNO.Text;
            erm.Eimp_exp_brslno = ddlBranches.SelectedValue.ToString();
            erm.Ename = "select_branch";
            erm.EWorking_Period = Working_Period;
            erm.startRowIndex = "0";
            erm.maximumRows = "0";
            erm.STANDARD_TYPE = ViewState["STANDARD_TYPE"].ToString();

            dtuser_branch = erm.RetrieveAll_Imp_exp_master_STD_TYPE();
            if (dtuser_branch.Tables[0].Rows.Count > 0)
            {

                txtBranchNO.Text = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                txtName.Text = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                ddlType.Items.Add(dtuser_branch.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString());
                txtAdd1.Text = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                txtAdd2.Text = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                txtcity.Text = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                txtStateName.Text = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                txtPincode.Text = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                txtContactPerson.Text = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_CONTACT_PERSON"].ToString();
                txtPhoneNO.Text = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_PHONE"].ToString();
                txtFax.Text = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_FAX"].ToString();
                txtEmail.Text = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_EMAIL"].ToString();
                txtBinNO.Text = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_BINNO"].ToString();
                txtRemarks.Text = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_REMARKS"].ToString();

               

                hdn_id.Value = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_ID"].ToString();

                string type = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                ddlType.Items.Clear();
                ddlType.Items.Add("GOVERNMENT DEPARTMENTS");
                ddlType.Items.Add("GOVERNMENT UNDERTAKINGS");
                ddlType.Items.Add("OTHERS");
                ddlType.Items.Add("PRIVATE");
                ddlType.Items.Add("JOBBING");
                ddlType.Items.Add("REPAIR & RETURN");
                ddlType.Items.Add("EXHIBITION");
                ddlType.Items.Add("DESTRUCTION");
                ddlType.Items.Add("MOVEMENT OF GOODS");
                ddlType.Items.Remove(type);
                if (!string.IsNullOrEmpty(type))
                {
                    ddlType.Items.Insert(0, type);
                }

                txt_TIN_No.Text = dtuser_branch.Tables[0].Rows[0]["TIN_NO"].ToString();
                hdn_Txt_Statecode.Value = dtuser_branch.Tables[0].Rows[0]["STATE_CODE"].ToString();
                //ddlCommercial_Tax_yn.SelectedValue = dtuser_branch.Tables[0].Rows[0]["M_COMMERCIAL_DETAILS_STATUS"].ToString();// hide on 30-07-2024
                hdn_ddlCommercial_Tax_yn.Value = dtuser_branch.Tables[0].Rows[0]["M_COMMERCIAL_DETAILS_STATUS"].ToString();
                txtCommercial_StateName.Text = dtuser_branch.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATENAME"].ToString();
                txtCommercial_StateCode.Text = dtuser_branch.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATECODE"].ToString();
                ddl_EXP_GSTN_Type.Text = dtuser_branch.Tables[0].Rows[0]["M_COMMERCIAL_TAX_TYPE"].ToString();
                txtCommercial_RegistrationNo.Text = dtuser_branch.Tables[0].Rows[0]["M_COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
               // ddlGSTN_Type.Text = string.Empty;
                txtDrawback_AC_No.Text = dtuser_branch.Tables[0].Rows[0]["IMP_EXP_DRAWBACK_AC_NO"].ToString();
                txt_Marksnos.Text = dtuser_branch.Tables[0].Rows[0]["MARKS_NO"].ToString();
                Rdstr.SelectedValue = dtuser_branch.Tables[0].Rows[0]["EXP_STR_YN"].ToString();
                string Exporter_Type = dtuser_branch.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString();

                if (Exporter_Type == "R")
                {
                    ddlType_Exp.Items.Clear();
                    ddlType_Exp.Items.Add("Manufacturer - ( F )");
                    ddlType_Exp.Items.Insert(0, "Merchant - ( R )");
                }
                else
                {
                    ddlType_Exp.Items.Clear();
                    ddlType_Exp.Items.Add("Merchant - ( R )");
                    ddlType_Exp.Items.Insert(0, "Manufacturer - ( F )");
                }

                if (dtuser_branch.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "GSN")
                {
                    ddlGSTN_Type.SelectedItem.Text = "G/GSN  -GSTIN of Normal Persons Individual IEC";
                }
                else if (dtuser_branch.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "GSG")
                {
                    ddlGSTN_Type.SelectedItem.Text = "O/GSG GSTIN of Govt.Entities";
                }
                else if (dtuser_branch.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "GSD")
                {
                    ddlGSTN_Type.SelectedItem.Text = "D/GSD - GSTIN of Diplomats";
                }
                else if (dtuser_branch.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "PAN")
                {
                    ddlGSTN_Type.SelectedItem.Text = "I/PAN PAN Number (AAAPL1234C)";
                }
                else if (dtuser_branch.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "TAN")
                {
                    ddlGSTN_Type.SelectedItem.Text = "T/TAN TAN Number (AAAP12345C)";
                }
                else if (dtuser_branch.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "PSP")
                {
                    ddlGSTN_Type.SelectedItem.Text = "P/PSP -Passport Number( Max 9 Characters-AN)";
                }
                else if (dtuser_branch.Tables[0].Rows[0]["GSTN_TYPE"].ToString() == "ADH")
                {
                    ddlGSTN_Type.SelectedItem.Text = "A/ADH Aadhaar Number( 12 Numeric)";
                }
                else
                {
                    ddlGSTN_Type.SelectedItem.Text = "";
                }

                txtGSTN_ID.Text = dtuser_branch.Tables[0].Rows[0]["GSTN_ID"].ToString();
                txtDistrict.Text = dtuser_branch.Tables[0].Rows[0]["DISTRICT"].ToString();


            }
            else
            {
                txtBranchNO.Text = "";
                txtAdd1.Text = "";
                txtAdd2.Text = "";
                txtcity.Text = "";
                txtPhoneNO.Text = "";
                txtFax.Text = "";
                txtEmail.Text = "";
                txtContactPerson.Text = "";
                txtStateName.Text = "";
                ddlType.SelectedIndex = -1;
                txtPincode.Text = "";
                txtBinNO.Text = "";
                txtRemarks.Text = "";
                txtDistrict.Text = "";
               
                txt_TIN_No.Text = "";

                //ddlCommercial_Tax_yn.SelectedIndex = -1;// hide on 30-07-2024
                txtCommercial_StateName.Text = string.Empty;
                txtCommercial_StateCode.Text = string.Empty;
                ddl_EXP_GSTN_Type.Text = string.Empty;
                ddlGSTN_Type.Text = string.Empty;
                txtCommercial_RegistrationNo.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void Clear()
    {

        txtIECNO.Text = "";
        txtName.Text = "";
        txtBranchNO.Text = "";
        txtAdd1.Text = "";
        txtAdd2.Text = "";
        txtcity.Text = "";
        txtPhoneNO.Text = "";
        txtFax.Text = "";
        txtEmail.Text = "";
        txtContactPerson.Text = "";
        txtStateName.Text = "";
        ddlType.SelectedIndex = -1;
        txtPincode.Text = "";
        txtBinNO.Text = "";
        txtRemarks.Text = "";
        txt_TIN_No.Text = "";
        txtDistrict.Text = "";

        //ddlCommercial_Tax_yn.SelectedIndex = -1;// hide on 30-07-2024
        txtCommercial_StateName.Text = string.Empty;
        txtCommercial_StateCode.Text = string.Empty;
        ddl_EXP_GSTN_Type.Text = string.Empty;
        txtCommercial_RegistrationNo.Text = string.Empty;
        ddlGSTN_Type.Text = string.Empty;
        ddl_EXP_GSTN_Type.SelectedItem.Text = "";
        ddlGSTN_Type.SelectedItem.Text = "";
        ddlGSTN_Type.SelectedIndex = -1;
    }
    public int insert_update(string a1, string a2, string a3)
    {
        erm.IMP_EXP_ID = a1;
        erm.IMP_EXP_NAME = txtName.Text;
        erm.IMP_EXP_IECNO = txtIECNO.Text;
        erm.IMP_EXP_BRSLNO = txtBranchNO.Text;
        erm.IMP_EXP_TYPE = ddlType.SelectedValue.ToString();
        erm.IMP_EXP_ADD1 = txtAdd1.Text;
        erm.IMP_EXP_ADD2 = txtAdd2.Text;
        erm.IMP_EXP_ADD3 = txtcity.Text;
        erm.IMP_EXP_ADD4 = txtStateName.Text;
        erm.IMP_EXP_PIN_CODE = txtPincode.Text;
        erm.IMP_EXP_CONTACT_PERSON = txtContactPerson.Text;
        erm.IMP_EXP_PHONE = txtPhoneNO.Text;

        erm.IMP_EXP_FAX = txtFax.Text;
        erm.IMP_EXP_EMAIL = txtEmail.Text;
        erm.IMP_EXP_BINNO = txtBinNO.Text;
        erm.IMP_EXP_REMARKS = txtRemarks.Text;
        erm.IMP_EXP_DRAWBACK_AC_NO = txtDrawback_AC_No.Text;
        erm.IMP_EXP_PAN_NO = txtPAN_No.Text;

        STANDARD_TYPE = ViewState["STANDARD_TYPE"].ToString();

        if (STANDARD_TYPE == "Non_STD")
        {
            erm.STANDARD_TYPE = STANDARD_TYPE;
        }
        else
        {
            erm.STANDARD_TYPE = null;
        }

        erm.TIN_NO = txt_TIN_No.Text;
        erm.STATE_CODE = hdn_Txt_Statecode.Value;

        erm.USER_ID = currentuser;
        erm.BRANCH_CODE = currentbranch;
        erm.flag = a2;
        erm.YEAR = a3;
        erm.EWorking_Period = Working_Period;
        erm.EXP_STR_YN = Rdstr.SelectedValue.ToString();
        string Type_Of_Exporter = "";

        if (ddlType_Exp.SelectedItem.Text == "Manufacturer - ( F )")
        {
            Type_Of_Exporter = "F";
        }
        else
        {
            Type_Of_Exporter = "R";
        }
        erm.TYPE_OF_EXPORTER = Type_Of_Exporter;
        erm.MARKS_NO = txt_Marksnos.Text;

        //erm.COMMERCIAL_DETAILS_STATUS = ddlCommercial_Tax_yn.SelectedValue.ToString();// hide on 30-07-2024
        erm.COMMERCIAL_DETAILS_STATUS = "Y";

        erm.COMMERCIAL_TAX_STATENAME = txtCommercial_StateName.Text;
        erm.COMMERCIAL_TAX_STATECODE = txtCommercial_StateCode.Text;
        erm.COMMERCIAL_TAX_TYPE = ddl_EXP_GSTN_Type.SelectedValue;
        erm.COMMERCIAL_TAX_REGISTRATION_NO = txtCommercial_RegistrationNo.Text;
        erm.GSTN_TYPE = ddlGSTN_Type.SelectedValue;
        /*
        if (ddlGSTN_Type.SelectedItem.Text == "G/GSN  -GSTIN of Normal Persons Individual IEC")
        {
            erm.GSTN_TYPE = "GSN";
        }
        else if (ddlGSTN_Type.SelectedItem.Text == "O/GSG GSTIN of Govt.Entities")
        {
            erm.GSTN_TYPE = "GSG";
        }
        else if (ddlGSTN_Type.SelectedItem.Text == "D/GSD - GSTIN of Diplomats")
        {
            erm.GSTN_TYPE = "GSD";
        }
        else if (ddlGSTN_Type.SelectedItem.Text == "I/PAN PAN Number (AAAPL1234C)")
        {
            erm.GSTN_TYPE = "PAN";
        }
        else if (ddlGSTN_Type.SelectedItem.Text == "T/TAN TAN Number (AAAP12345C)")
        {
            erm.GSTN_TYPE = "TAN";
        }
        else if (ddlGSTN_Type.SelectedItem.Text == "P/PSP -Passport Number( Max 9 Characters-AN)")
        {
            erm.GSTN_TYPE = "PSP";
        }
        else if (ddlGSTN_Type.SelectedItem.Text == "A/ADH Aadhaar Number( 12 Numeric)")
        {
            erm.GSTN_TYPE = "ADH";
        }
        else
        {
            erm.GSTN_TYPE = "";
        }
        */
        erm.GSTN_ID = txtGSTN_ID.Text;
        erm.DISTRICT = txtDistrict.Text;

        string chk_dbk = "";
        if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "1344" || Connection.COMPANYID() == "1572" || Connection.COMPANYID() == "1623" || Connection.COMPANYID() == "2078" || Connection.COMPANYID() == "2152" || Connection.COMPANYID() == "2118" || Connection.COMPANYID() == "2153" || Connection.COMPANYID() == "2154" || Connection.COMPANYID() == "2155" || Connection.COMPANYID() == "2214" || Connection.COMPANYID() == "2305")//Ringo Cargo
        {
            if (chk_DB001.Checked == true)
            {
                chk_dbk = "1";
            }
            if (chk_DB002.Checked == true)
            {
                chk_dbk += "2";
            }
            if (chk_DB003.Checked == true)
            {
                chk_dbk += "3";
            }
        }


        erm.EXP_DBK_DECL_CHK = chk_dbk;
        erm.SEZ_ICEGATE_ID = txt_SEZ_IcegateID.Text.ToUpper();
        erm.SEZ_PAN_NO = txt_SEZ_PANNo.Text.ToUpper();

        erm.SEZ_AP_ID = txt_SEZ_AP_ID.Text.ToUpper();
        erm.SEZ_AP_NAME = txt_SEZ_AP_Name.Text.ToUpper();

        i = erm.Imp_Exp_Master_Insert_update_STD();
        return i;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string TEMP = txtIECNO.Text;
        byte TEMPLEN = Convert.ToByte(TEMP.Length);
        if (TEMPLEN != 10)
        {
            Alert_msg("IEC No must be 10 character");
            txtIECNO.Focus();
        } 

        else
        {
            if (txtName.Text != "" && txtIECNO.Text != "" && txtBranchNO.Text != "" && txtAdd1.Text != "")
            {

                string a1 = "";
                string a2 = "S";
                string a3 = "";
                ViewState["STANDARD_TYPE"] = RadioButtonList_TYPE.SelectedValue;
                i = insert_update(a1, a2, a3);
                HiddenField1.Value = Convert.ToString(erm.UPDATE_ID);
              
                if (i == 1)
                {
                    //-----------------------FOR USER RIGHTS--------------------------------//
                    user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                    PAGE_MODIFY = user_Create.PAGE_MODIFY;
                    //---------------SAVE ONLY------------------//
                    Load_Elogix_Service("S");

                    if (PAGE_MODIFY == "False")
                    {
                        btnNew_Click(sender, e);
                    }
                    else
                    {
                        btnUpdate.CssClass = "save";
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        txtIECNO.Enabled = false;
                        txtName.Enabled = false;
                    }
                    //-----------------------FOR USER RIGHTS--------------------------------//

                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnSave");
                    btnAdcode.Visible = true;
                }
                else if (i == 2)
                {
                    Alert_msg("" + txtName.Text + " already exists", "btnNew");
                }
                else if (i == 3)
                {
                    Alert_msg("Name & Branch.No already exists","btnNew");
                }
                else if (i == 4)
                {
                    Alert_msg("IE Code already exists","btnNew");
                }
                else
                {
                    Alert_msg("Client Not Saved");
                }
            }
            else
            {
                Alert_msg("Enter All Mandatory Field");
            }
        }       
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            get_IMP_EXP_ID();

            erm.Eimp_exp_id = HiddenField1.Value;
            erm.Eimp_exp_name = "0";
            erm.Eimp_exp_iecno = "0";
            erm.Eimp_exp_brslno = "0";
            erm.Ename = "delete";
            erm.EWorking_Period = Working_Period;
            erm.RetrieveAll_Imp_exp_master_STD_TYPE();
            int ii = 0;
            ii = erm.result;

            if (ii ==1)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Client Deleted', 'CLIENT MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("Client Not Deleted", "btnDelete");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            get_IMP_EXP_ID();

            string a1 = HiddenField1.Value;
            string a2 = "U";
            string a3 = "";
            i = insert_update(a1, a2, a3);
            if (i == 1)
            {
                Load_Elogix_Service("U");
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnNew");
                }
                else
                {
                    Alert_msg("Saved Successfully", "btnNew");                  
                }
            }
            else if (i == 2)
            {
                Alert_msg("Party Already Exists!", "btnNew");
            }
            else if (i == 3)
            {
                Alert_msg("Branch.No Already Exists!", "btnNew");
            }
            else if (i == 4)
            {
                Alert_msg("IEC No Already Exists!","btnNew");
            }
            else
            {
                Alert_msg("Client Not Saved");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void get_IMP_EXP_ID()
    {
        DataSet dss=new DataSet();
            erm.Eimp_exp_id = "";
            erm.Eimp_exp_name = txtName.Text;
            erm.Eimp_exp_iecno = txtIECNO.Text;
            erm.Eimp_exp_brslno = ddlBranches.SelectedItem.Text;
            erm.Ename = "Get_ID";
            erm.EWorking_Period = Working_Period;
            STANDARD_TYPE = ViewState["STANDARD_TYPE"].ToString();

            if (STANDARD_TYPE == "Non_STD")
            {
                erm.STANDARD_TYPE = STANDARD_TYPE;
            }
            else
            {
                erm.STANDARD_TYPE = null;
            }

           dss= erm.RetrieveAll_Imp_exp_master_STD_TYPE();
            int ii = 0;
            ii = erm.result;

            if (ii == 1)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    HiddenField1.Value = dss.Tables[0].Rows[0]["IMP_EXP_ID"].ToString();
                }
            }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["IMP_EXP_ID"] != "" && Request.QueryString["IMP_EXP_ID"] != null)
        {
            txtBranchNO.Text = "";
            txtAdd1.Text = "";
            txtAdd2.Text = "";
            txtcity.Text = "";
            txtPhoneNO.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            txtContactPerson.Text = "";
            txtStateName.Text = "";
            ddlType.SelectedIndex = -1;
            txtPincode.Text = "";
            txtBinNO.Text = "";
            txtRemarks.Text = "";
            txt_TIN_No.Text = "";
            txtCommercial_RegistrationNo.Text = "";
            txtCommercial_StateName.Text = "";
            txtCommercial_StateCode.Text = "";
            txtCommercial_RegistrationNo.Text = "";
            txtGSTN_ID.Text = "";
            txtPAN_No.Text = "";
            txtDistrict.Text = "";
            //ddlGSTN_Type.SelectedItem.Text = "";
            //ddl_EXP_GSTN_Type.SelectedItem.Text = "";
            ddlGSTN_Type.SelectedIndex = -1;
            ddl_EXP_GSTN_Type.SelectedIndex = -1;

            chk_DB001.Checked = false;
            chk_DB002.Checked = false;
            chk_DB003.Checked = false;
        }
        else
        {
            mo.ResetFields(Page.Controls);
        }
        txtIECNO.Enabled = true;
        txtName.Enabled = true;
        Session["IMP_EXP_ID"] = "";
        Session["flag"] = "SAVE";

        txtIECNO.Focus();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        ViewState["UPDATED_ID"] = null;

        ddlType.Items.Clear();

        ddlType.Items.Add("GOVERNMENT DEPARTMENTS");
        ddlType.Items.Add("GOVERNMENT UNDERTAKINGS");
        ddlType.Items.Add("OTHERS");
        ddlType.Items.Add("PRIVATE");
        ddlType.Items.Add("JOBBING");
        ddlType.Items.Add("REPAIR & RETURN");
        ddlType.Items.Add("EXHIBITION");
        ddlType.Items.Add("DESTRUCTION");
        ddlType.Items.Add("MOVEMENT OF GOODS");
    }

    protected void ddlBranches_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_BranchDetails_All();
           
    }
    protected void txtIECNO_TextChanged(object sender, EventArgs e)
    {
        if (txtIECNO.Text.Length == 10)
        {
            try
            {
                if (Session["flag"].ToString() == "SAVE")
                {
                    erm.Eimp_exp_id = "0";
                    erm.Eimp_exp_name = "0";
                    erm.Eimp_exp_iecno = txtIECNO.Text;
                    erm.Eimp_exp_brslno = "0";
                    erm.Ename = "select_iecname";
                    erm.EWorking_Period = Working_Period;

                    dtuser = erm.RetrieveAll_Imp_exp_master_STD_TYPE();
                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        txtName.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                        string type = dtuser.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                        ddlType.Items.Clear();

                        ddlType.Items.Add("GOVERNMENT DEPARTMENTS");
                        ddlType.Items.Add("GOVERNMENT UNDERTAKINGS");
                        ddlType.Items.Add("OTHERS");
                        ddlType.Items.Add("PRIVATE");
                        ddlType.Items.Add("JOBBING");
                        ddlType.Items.Add("REPAIR & RETURN");
                        ddlType.Items.Add("EXHIBITION");
                        ddlType.Items.Add("DESTRUCTION");
                        ddlType.Items.Add("MOVEMENT OF GOODS");
                        ddlType.Items.Remove(type);
                        ddlType.Items.Insert(0, type);

                        if (STANDARD_TYPE == "" || STANDARD_TYPE == "STD")
                        {
                            txtName.Enabled = false;
                        }
                        else
                        {
                            txtName.Enabled = true;
                        }
                        Alert_msg("IE Code is already exists!","txtBranchNO");
                    }
                    else
                    {
                        txtName.Text = "";
                        txtName.Enabled = true;
                    }
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnNew.Visible = true;
                    btnSave.Visible = true;

                }
                else if (Session["flag"].ToString() == "UPDATE")
                {
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
        txtBranchNO.Focus();
       
    }
    protected void txtName_TextChanged(object sender, EventArgs e)
    {
         try
        {
            if (Session["flag"].ToString() == "SAVE")
            {
                erm.Eimp_exp_id = "0";
                erm.Eimp_exp_name = txtName.Text;
                erm.Eimp_exp_iecno ="0" ;
                erm.Eimp_exp_brslno = "0";
                erm.Ename = "select_name";
                erm.EWorking_Period = Working_Period;

                dtuser = erm.RetrieveAll_Imp_exp_master_STD_TYPE();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                    string type = dtuser.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                    ddlType.Items.Clear();

                    ddlType.Items.Add("GOVERNMENT DEPARTMENTS");
                    ddlType.Items.Add("GOVERNMENT UNDERTAKINGS");
                    ddlType.Items.Add("OTHERS");
                    ddlType.Items.Add("PRIVATE");
                    ddlType.Items.Add("JOBBING");
                    ddlType.Items.Add("REPAIR & RETURN");
                    ddlType.Items.Add("EXHIBITION");
                    ddlType.Items.Add("DESTRUCTION");
                    ddlType.Items.Add("MOVEMENT OF GOODS");
                    ddlType.Items.Remove(type);
                    ddlType.Items.Insert(0, type);
                    Alert_msg("Party Already Exists!","ddlType");
                }
                else
                {                
                   txtName.Enabled = true;                
                }
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnNew.Visible = true;
                btnSave.Visible = true;

            }
            else if (Session["flag"].ToString() == "UPDATE")
            {
                erm.Eimp_exp_id = hdn_id.Value;
                erm.Eimp_exp_name = txtName.Text;
                erm.Eimp_exp_iecno = txtIECNO.Text;
                erm.Eimp_exp_brslno = "0";
                erm.Ename = "check_iecname";
                erm.EWorking_Period = Working_Period;

                erm.RetrieveAll_Imp_exp_master_STD_TYPE();

                if (erm.result==2)
                {
                  Alert_msg("Party Already Exists!", "ddlType");
                }
                else
                {
                   
                    txtName.Enabled = true;
                }
            }
       
               ddlType.Focus();
           }
           catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
    }
    protected void txtBranchNO_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["flag"].ToString() == "SAVE")
            {
                erm.Eimp_exp_id = "0";
                erm.Eimp_exp_name = txtName.Text;
                erm.Eimp_exp_iecno = txtIECNO.Text;
                erm.Eimp_exp_brslno = txtBranchNO.Text;
                erm.Ename = "select_br_slno";
                erm.EWorking_Period = Working_Period;

                dtuser = erm.RetrieveAll_Imp_exp_master_STD_TYPE();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    Alert_msg("Branch Already Exists!","txtBranchNO");
                }
                else
                {
                    txtName.Focus();
                }
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnNew.Visible = true;
                btnSave.Visible = true;
            }
            else if (Session["flag"].ToString() == "UPDATE")
            {
                txtBranchNO.Focus();
                erm.Eimp_exp_id = hdn_id.Value;
                erm.Eimp_exp_name = txtName.Text;
                erm.Eimp_exp_iecno = txtIECNO.Text;
                erm.Eimp_exp_brslno = txtBranchNO.Text;
                erm.Ename = "Check_select_br_slno";
                erm.EWorking_Period = Working_Period;

                erm.RetrieveAll_Imp_exp_master();
                if (erm.result==2)
                {
                    Alert_msg("Branch Already Exists!", "txtBranchNO");
                }
                else
                {
                    txtName.Focus();
                }
            }        
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CLIENT MASTER', function (r) {}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg,string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CLIENT MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    [System.Web.Services.WebMethod]
    public static string Get_IECNO_Details(string txtIECNO)
    {
        string flag = "", Working_Period = "", result = "",
            txtName = "",
            type = "";
        if (txtIECNO.Length == 10)
        {
            try
            {
                flag = HttpContext.Current.Session["flag"].ToString();
                Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();

                if (flag == "SAVE")
                {
                    eroyalmaster erm = new eroyalmaster();

                    erm.Eimp_exp_id = "0";
                    erm.Eimp_exp_name = "0";
                    erm.Eimp_exp_iecno = txtIECNO;
                    erm.Eimp_exp_brslno = "0";
                    erm.Ename = "select_iecname";
                    erm.EWorking_Period = Working_Period;
                    DataSet dtuser = new DataSet();
                    dtuser = erm.RetrieveAll_Imp_exp_master();
                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        txtName = dtuser.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                        type = dtuser.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                        result = "1";
                    }
                    else
                    {
                        result = "2";
                    }
                }
                else if (flag == "UPDATE")
                {


                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
        txtIECNO = result + "~~" + txtName + "~~" + type;
        return txtIECNO;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Branch_Details(string txtIECNO, string txtName, string txtBranchNO)
    {
        string flag = "", Working_Period = "", result = "";
        if (txtIECNO.Length == 10)
        {
            try
            {
                flag = HttpContext.Current.Session["flag"].ToString();
                Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();

                if (flag == "SAVE")
                {
                    eroyalmaster erm = new eroyalmaster();

                    erm.Eimp_exp_id = "0";
                    erm.Eimp_exp_name = txtName;
                    erm.Eimp_exp_iecno = txtIECNO;
                    erm.Eimp_exp_brslno = txtBranchNO;
                    erm.Ename = "select_br_slno";
                    erm.EWorking_Period = Working_Period;
                    DataSet dtuser = new DataSet();
                    dtuser = erm.RetrieveAll_Imp_exp_master();
                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        result = "1";
                    }
                    else
                    {
                        result = "2";
                    }
                }
                else if (flag == "UPDATE")
                {
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
        txtIECNO = result + "~~" +  flag;
        return txtIECNO;
    }

    [System.Web.Services.WebMethod]
    public static string Get_ClientName_Details(string txtName)
    {
        string flag = "", Working_Period = "", result = "",
            
            type = "";
        if (txtName.Length !=0)
        {
            try
            {
                flag = HttpContext.Current.Session["flag"].ToString();
                Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();

                if (flag == "SAVE")
                {
                    eroyalmaster erm = new eroyalmaster();

                    erm.Eimp_exp_id = "0";
                    erm.Eimp_exp_name = txtName;
                    erm.Eimp_exp_iecno = "0";
                    erm.Eimp_exp_brslno = "0";
                    erm.Ename = "select_name";
                    erm.EWorking_Period = Working_Period;
                    DataSet dtuser = new DataSet();
                    dtuser = erm.RetrieveAll_Imp_exp_master();
                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        txtName = dtuser.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                        type = dtuser.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                        result = "1";
                    }
                    else
                    {
                        result = "2";
                    }
                }
                else if (flag == "UPDATE")
                {
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
        txtName = result + "~~" + txtName + "~~" + type;
        return txtName;
    }

    protected void RadioButtonList_TYPE_SelectedIndexChanged(object sender, EventArgs e)
    {
        STANDARD_TYPE = RadioButtonList_TYPE.SelectedValue;
        ViewState["STANDARD_TYPE"] = STANDARD_TYPE;

        if (Request.QueryString["IMP_EXP_ID"] != "" && Request.QueryString["IMP_EXP_ID"] != null)
        {
            if (STANDARD_TYPE == "" || STANDARD_TYPE == "STD")
            {
                txtName.Enabled = false;
            }
            else
            {
                txtName.Enabled = true;
            }
        }
        else
        {         
                txtName.Enabled = true;         
        }
        Bind_Branches_StandardTYPE();
    }
    public void Get_Client_Default_Settings()
    {
        Default.STANDARD_TYPE = "";
        Default.USER_ID = currentuser;
        Default.BRANCH_CODE = currentbranch;
        Default.YEAR = "";
        Default.WORKING_PERIOD = Working_Period;
        Default.BRANCH_COMMON = currentbranch;
        Default.flag = "Get_Details";
        ds = Default.Client_DefaultSettings_Insert_Update();

        if (ds.Tables[0].Rows.Count > 0)
        {
            STANDARD_TYPE = ds.Tables[0].Rows[0]["STANDARD_TYPE"].ToString();

            if (STANDARD_TYPE == "Non_STD")
            {
                RadioButtonList_TYPE.SelectedValue = STANDARD_TYPE;
            }
            else
            {
                RadioButtonList_TYPE.SelectedValue = "";
            }
        }
    }

    [System.Web.Services.WebMethod]
    public static string Set_State_Name_Validation(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();

        Auto.Enamesearch = custid;
        Auto.Ename = "State_Name_Validate";
        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

        if (ds.Tables[0].Rows.Count > 0)
        {
            custid = "Yes";
        }
        else
        {
            custid = "No";
        }
        return custid;
    }

    private void Load_Elogix_Service(string E_Flag)
    {
        try
        {
            string E_Logix_Company_Id_Chennai = Connection.e_lOGIX_CHENNAI();
            string E_Logix_Company_Id_Mumbai = Connection.e_lOGIX_MUMBAI();

            if (E_Logix_Company_Id_Chennai != string.Empty)
            {
                /*
                IMPL.ELOGIX_CS obj = new IMPL.ELOGIX_CS();
                obj.Shipper_Master(txtName.Text, txtIECNO.Text, ddlType.SelectedValue.ToString()
                                     , "SHIPPER_CLASS"
                                     , ddlGSTN_Type.SelectedValue.ToString()
                                     , txtGSTN_ID.Text
                                     , txtCommercial_StateCode.Text//SHIPPER_STATE 
                                     , txtBranchNO.Text
                                     , txtAdd1.Text
                                     , txtAdd2.Text
                                     , txtPincode.Text
                                     , E_Logix_Company_Id_Chennai
                                     , E_Flag
                                     , Connection.Current_User()
                                     );
                */

                IMPL_CHENNAI.ELogiX obj = new IMPL_CHENNAI.ELogiX();
                obj.Client_Master(txtName.Text
                                     , txtIECNO.Text
                                     , ddlType.SelectedValue.ToString()
                                     , "SHIPPER_CLASS"
                                     , ddlGSTN_Type.SelectedValue.ToString()
                                     , txtGSTN_ID.Text
                                     , txtCommercial_StateCode.Text//SHIPPER_STATE 
                                     , txtBranchNO.Text
                                     , txtAdd1.Text
                                     , txtAdd2.Text
                                     , txtPincode.Text
                                     , Connection.Company_License()
                                     , E_Flag
                                     , Connection.Current_User()
                                     );

            }
            else if (E_Logix_Company_Id_Mumbai != string.Empty)
            {
                IMPL_MUMBAI.ELOGIX_CS obj = new IMPL_MUMBAI.ELOGIX_CS();
                obj.Shipper_Master(txtName.Text, txtIECNO.Text, ddlType.SelectedValue.ToString()
                                     , "SHIPPER_CLASS"
                                     , ddlGSTN_Type.SelectedValue.ToString()
                                     , txtGSTN_ID.Text
                                     , txtCommercial_StateCode.Text//SHIPPER_STATE 
                                     , txtBranchNO.Text
                                     , txtAdd1.Text
                                     , txtAdd2.Text
                                     , txtPincode.Text
                                     , E_Logix_Company_Id_Mumbai
                                     , E_Flag
                                     , Connection.Current_User()
                                     );
            }

            /*
            string E_Logix_Company_Id = Connection.E_Logix_Company_Id();
            if (E_Logix_Company_Id != string.Empty)
            {
                IMPL.ELOGIX_CS obj = new IMPL.ELOGIX_CS();
                obj.Shipper_Master(txtName.Text, txtIECNO.Text, ddlType.SelectedValue.ToString()
                                     , "SHIPPER_CLASS"
                                     , ddlGSTN_Type.SelectedValue.ToString()
                                     , txtGSTN_ID.Text
                                     , txtCommercial_StateCode.Text//SHIPPER_STATE 
                                     , txtBranchNO.Text
                                     , txtAdd1.Text
                                     , txtAdd2.Text
                                     , txtPincode.Text
                                     , E_Logix_Company_Id
                                     , E_Flag
                                     , Connection.Current_User()
                                     );
            }
            */


        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

}