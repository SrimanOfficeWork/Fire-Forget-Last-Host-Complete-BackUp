using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Linq;
using System.Data;

public partial class Client_Master_New : ThemeClass
{

    public int i;
    public string AUTO_ID;

    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Client_Master_New_cs CM = new Client_Master_New_cs();
    DataTable dt = new DataTable();


    //----------------------------------------------------------
    eroyalmaster erm = new eroyalmaster();
    Manipulation mo = new Manipulation();

    Default_Settings Default = new Default_Settings();
    User_Creation user_Create = new User_Creation();
    DropDownList ddl = new DropDownList();

    DataSet dtuser = new DataSet();
    DataSet dtuser_branch = new DataSet();
    DataSet ds_branch = new DataSet();
    DataSet ds = new DataSet();


    public string IMP_EXP_ID = "", currentuser, currentbranch, Working_Period, Defult_STD_Type, Company_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;

    protected void Page_Load(object sender, EventArgs e)
        {
        aps.checkSession();

        currentuser = Connection.Current_User();
        currentbranch = Connection.Current_Branch();
        Working_Period = Connection.WorkingPeriod();
        Company_ID = Connection.COMPANYID();

        ddl.Items.Clear();
        txtName.Attributes["value"] = txtName.Text;


        string qsName = Request.QueryString["Name"] ?? string.Empty;


        if (!String.IsNullOrEmpty(Request.QueryString["type"] as string))
        {
            if (qsName != "")
            {
                if (Request.QueryString["type"].ToString() == "Job")
                {
                    // Get_IMP_EXP_ID_JobSearch();
                }
            }
        }
        else
        {
            if (!String.IsNullOrEmpty(Request.QueryString["IMP_EXP_IECNO"] as string))
            {
                hdn_IEC_NO.Value = Request.QueryString["IMP_EXP_IECNO"].ToString();
                hdn_ClientName.Value = qsName;   // <-- no more crash

            }

        }

        if (!IsPostBack)
        {
            txtCommercial_StateCode.Attributes.Add("readonly", "readonly");
            txtCommercial_StateCode.Style.Add("background-color", "#F0F0F0");
            //----------------SETTING SCREEN PERMISSION----------------//
            Screen_Id = 1;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//

            txtIECNO.Focus();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = false;
            btnSave.Visible = true;
            LoadBranchGrid(hdn_IEC_NO.Value, hdn_ClientName.Value);
            if (Company_ID == "3267" || Company_ID == "1" || Company_ID == "10"||Company_ID=="293")
            {
                ACCINFO.Visible = true;
                btnPayableUpdate.Visible = false;
                btn_PayableDelete.Visible = false;

                btnReceivableUpdate.Visible = false;
                btn_ReceivableDelete.Visible = false;

                GetTDS_Details();
                GetPayaleDetails("GetPayableDetail");
                LoadbankReceivableGrid();
            }
            else
            {
                ACCINFO.Visible = false;
            }

            Session["flag"] = "SAVE";


           // LoadCustomerGL();
           // LoadVendorGL();
        }


    }

    private void LoadBranchGrid(string iecNo, string name)
    {
        txtIECNO.Text = iecNo;
        txtName.Text = name;
        if (string.IsNullOrEmpty(iecNo) || string.IsNullOrEmpty(name))
        {
            GVBranchEmptyTable();
            return;
        }
        ObjUBO.A3 = iecNo;
        ObjUBO.A4 = name;
        ObjUBO.A20 = "ClientMaster_Branch_select";

        DataSet dss = CM.ClientMaster_Select(ObjUBO);
        string searchName = string.Join(", ",
            name.Split(',')
                .Select(x => x.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase));

        DataTable dt = dss.Tables[0];
        //Tamil Code
        if (!string.IsNullOrWhiteSpace(name) && !name.EndsWith("..."))
        {
            var filteredRows = dt.AsEnumerable()
                .Where(r => r.Field<string>("imp_Exp_name") != null &&
                            r.Field<string>("imp_Exp_name")
                             .Equals(searchName, StringComparison.OrdinalIgnoreCase));

            if (filteredRows.Any())
            {
                gv_Branch.DataSource = filteredRows.CopyToDataTable();
            }
            else
            {
                gv_Branch.DataSource = dt;
            }
        }
        else
        {
            gv_Branch.DataSource = dt;
        }

        gv_Branch.DataBind();

        string std = Request.QueryString["STD_NON"] ?? string.Empty;
        if (std == "Non_STD")
        {
            std = "NS";
        }
        if (gv_Branch.Rows.Count > 0)
        {
            int index = 0;

            for (int i = 0; i < gv_Branch.Rows.Count; i++)
            {
                if (gv_Branch.DataKeys[i]["STANDARD_TYPE"].ToString() == std)
                {
                    index = i;
                    break;
                }
            }

            gv_Branch.SelectedIndex = index;
            gv_Branch_SelectedIndexChanged(gv_Branch, EventArgs.Empty);
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    /* private void Get_IMP_EXP_ID_JobSearch()
     {
         try
         {
             if (Request.QueryString["Name"].ToString() != "")
             {
                 //erm.Eimp_exp_id = Request.QueryString["IMP_EXP_ID"];
                 erm.Eimp_exp_name = Request.QueryString["Name"].ToString();
                 erm.Eimp_exp_iecno = Request.QueryString["IEC"].ToString();
                 erm.Eimp_exp_brslno = Request.QueryString["IMP_EXP_ID"].ToString();
                 erm.Ename = "Get_ID";
                 erm.EWorking_Period = Working_Period;
                 erm.STANDARD_TYPE = Session["STANDARD_TYPE"].ToString();

                 dtuser = erm.RetrieveAll_Imp_exp_master_STD_TYPE();

                 if (dtuser.Tables[0].Rows.Count > 0)
                 {
                     hdn_id.Value = dtuser.Tables[0].Rows[0]["IMP_EXP_ID"].ToString();
                     HiddenField1.Value = hdn_id.Value;
                 }
             }
         }
         catch (Exception ex)
         {

             Connection.Error_Msg(ex.Message);
         }

     }*/
    protected void gv_Branch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(gv_Branch, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer;";
            }
            if (DataBinder.Eval(e.Row.DataItem, "STANDARD_TYPE").ToString() == "S")
            {
                e.Row.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                e.Row.ForeColor = System.Drawing.Color.Brown;
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void gv_Branch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "NewBranch")
        {
            ClearClientMaster();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = false;
            RadioButtonList_TYPE.Enabled = true;
            // txtName.Enabled = (ViewState["STANDARD_TYPE"].ToString() == "Non_STD") ? true : false;// Condition given by Bala Sir
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
        // txtStateName.Text = "";
        ddlStateName.SelectedIndex = -1;
        ddlType.SelectedIndex = -1;
        txtPincode.Text = "";
        txtBinNO.Text = "";
        txtRemarks.Text = "";
        txt_TIN_No.Text = "";
        txtDistrict.Text = "";

        //ddlCommercial_Tax_yn.SelectedIndex = -1;// hide on 30-07-2024
        ddlCommercial_StateName.SelectedIndex = -1;
        txtCommercial_StateCode.Text = string.Empty;
        ddl_EXP_GSTN_Type.Text = string.Empty;
        txtCommercial_RegistrationNo.Text = string.Empty;
        ddlGSTN_Type.Text = string.Empty;
        ddl_EXP_GSTN_Type.SelectedItem.Text = "";
        ddlGSTN_Type.SelectedItem.Text = "";
        ddlGSTN_Type.SelectedIndex = -1;
    }
    public DataSet insert_update(string flag)
    {
        try
        {
            HdnAV_Code.Value= string.IsNullOrEmpty(txtVendorGL.Text) ? string.Empty : HdnAV_Code.Value;
            hdnAC_Code.Value = string.IsNullOrEmpty(txtCust_GL.Text) ? string.Empty : hdnAC_Code.Value;
            ObjUBO.A1 = hdn_updatedId.Value.ToString();
            ObjUBO.A2 = txtName.Text.Trim();
            ObjUBO.A3 = txtIECNO.Text.Trim();
            ObjUBO.A4 = txtBranchNO.Text.Trim();
            ObjUBO.A5 = ddlType.SelectedValue.ToString();
            ObjUBO.A6 = txtAdd1.Text;
            ObjUBO.A7 = txtAdd2.Text;
            ObjUBO.A8 = txtcity.Text;
            ObjUBO.A9 = ddlStateName.SelectedItem.ToString();                
            ObjUBO.A10 = txtPincode.Text;
            ObjUBO.A11 = txtContactPerson.Text;
            ObjUBO.A12 = txtPhoneNO.Text;
            ObjUBO.A13 = txtEmail.Text;
            ObjUBO.A14 = txtBinNO.Text;
            ObjUBO.A15 = txtRemarks.Text;
            ObjUBO.A16 = txtDrawback_AC_No.Text;
            ObjUBO.A17 = txtPAN_No.Text;
            ObjUBO.A18 = (RadioButtonList_TYPE.SelectedValue == "Non_STD") ? "Non_STD" : null;
            ObjUBO.A19 = txt_TIN_No.Text;
            ObjUBO.A20 = ddlStateName.SelectedValue.ToString();  
            ObjUBO.A21 = txtFax.Text;
            ObjUBO.A22 = Rdstr.SelectedValue.ToString();
            ObjUBO.A23 = (ddlType_Exp.SelectedItem.Text == "Manufacturer - ( F )") ? "F" : "R";
            ObjUBO.A24 = txt_Marksnos.Text;
            ObjUBO.A25 = "Y";
            ObjUBO.A26 = ddlCommercial_StateName.SelectedItem.ToString();
            ObjUBO.A27 = txtCommercial_StateCode.Text;
            ObjUBO.A28 = ddl_EXP_GSTN_Type.SelectedValue;
            ObjUBO.A29 = txtCommercial_RegistrationNo.Text;
            ObjUBO.A30 = ddlGSTN_Type.SelectedValue;
            ObjUBO.A31 = txtGSTN_ID.Text;
            ObjUBO.A32 = txtDistrict.Text;
            ObjUBO.A33 = Client_DrawBack_Customization();
            ObjUBO.A34 = txt_SEZ_IcegateID.Text.ToUpper();
            ObjUBO.A35 = txt_SEZ_PANNo.Text.ToUpper();
            ObjUBO.A36 = txt_SEZ_AP_ID.Text.ToUpper();
            ObjUBO.A37 = txt_SEZ_AP_Name.Text.ToUpper();
            ObjUBO.A38 = txtWarehouseCode.Text;
            ObjUBO.A39 = ddl_Payment_Method.SelectedValue;
            ObjUBO.A40 = txtEndUse.Text;
            ObjUBO.A41 = txtInsuranceRate.Text;
            ObjUBO.A42 = txt_TAN_Number.Text;
            ObjUBO.A43 = txt_TDS_Code.Text;
            ObjUBO.A44 = txt_TDS_Rate.Text;
            ObjUBO.A45 = ddlNatureOfTrans.SelectedValue;   // Added by shanthini on 12-06-2026
            ObjUBO.A46 = ddlNatureOfPayment.SelectedValue;
            ObjUBO.A47 = ddlValuationMethod.SelectedValue;

            //Customer tab controls
            ObjUBO.A48 = txtCust_CreditLimit.Text;
            ObjUBO.A49 = ddlCust_cur.SelectedValue;
            CM.A_C_UNLIMITED = chkCust_Unlimited.Checked;
            CM.A_C_COD = chkCust_CashOnDelivery.Checked;
            CM.A_C_CHK_OVERDUE = chkCust_InvOverdue.Checked;
            ObjUBO.A50 = ddlCust_InvOverdue.SelectedValue;
            CM.CHECK_CREDITONHOLD = chkCust_CreditOnHold.Checked;
            ObjUBO.A51 = txtCust_CreditOnHold_Remarks.Text;
            ObjUBO.A52 = ddlCust_CreditPeriod.SelectedValue;
            ObjUBO.A53 = txtCust_CreditDays.Text;
            ObjUBO.A54 = txtCust_GL.Text;
            ObjUBO.A55 = txtCust_NotifEmail.Text;
            CM.Check_OptionalCriteria = chkCust_OptionalCriteria.Checked;
            ObjUBO.A56 = ddlCust_Receivable.SelectedValue;
            ObjUBO.A57 = ddlCust_ReceivablePeriod.SelectedValue;
            ObjUBO.A58 = txtCust_ReceivableDays.Text;
            ObjUBO.A59 = ddlCust_Currency.SelectedValue;

            //Vendor tab controls
            CM.CHK_Vendor_CLimit = chk_vendor_crt_limit.Checked;
            ObjUBO.A60 = txtCreditLimit.Text;
            ObjUBO.A61 = ddl_vendor_currency.SelectedValue;
            ObjUBO.A62 = ddlPayableCreditCard.SelectedValue;
            ObjUBO.A63 = txtPayableCreditNumbers.Text;
            ObjUBO.A64 = ddlDuedateCalculate.SelectedValue;
            ObjUBO.A65 = ddlVendorCurrency2.SelectedValue;
            ObjUBO.A66 = txtVendorGL.Text;
            ObjUBO.A67 = txt_Notification.Text;
            CM.CHK_PaymentHold = chkpaymentHold.Checked;
            ObjUBO.A68 = txtPaymentonHold.Text;
            //TDS DETAILS CONTROLS
            ObjUBO.A69 = ddlFinyear.SelectedValue;
            ObjUBO.A70 = ddlOrganizationList.SelectedValue;
            CM.CHK_SpecifiedPerson = chk_specifiedperson.Checked;
            ObjUBO.A71 = ddlTds.SelectedValue;
            ObjUBO.A72 = hdnAC_Code.Value;
            ObjUBO.A73 = HdnAV_Code.Value;
            ObjUBO.A200 = flag;
            ObjUBO.A201 = "";//Year
            ObjUBO.A202 = ddl_IGST_Payment.SelectedValue; // added by pandiyan on 19-09-2026

            ds = CM.Imp_Exp_Master_Insert_update_STD(ObjUBO);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ds = insert_update("S");

            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_BrSlNo.Text = txtBranchNO.Text;
                lblName.Text = txtName.Text;
                lblIECNO.Text = txtIECNO.Text;
                hdn_updatedId.Value = ds.Tables[0].Rows[0]["IMP_EXP_ID"].ToString();
                ViewState["UPDATED_ID"] = null;
                Alert_msg("Saved Successfully!", "btnSave");

                //btnUpdate.CssClass = "save";
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnDelete.Visible = false;


            }
            else
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
                Alert_msg("Already exixts!", "btnSave");
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_Branch.DataSource = ds.Tables[1];
                gv_Branch.DataBind();
            }
            else
            {
                gv_Branch.DataSource = dt;
                gv_Branch.DataBind();
            }
            GetTDS_Details();
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
            ds = insert_update("Delete");
            if (ds.Tables[0].Rows.Count == 0)
            {
                Alert_msg("Deleted Successfully");
            }
            else
            {
                Alert_msg("Group Type Not Deleted");
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_Branch.DataSource = ds.Tables[1];
                gv_Branch.DataBind();
            }
            else
            {
                gv_Branch.DataSource = dt;
                gv_Branch.DataBind();
            }

            lblName.Text = "";
            lbl_BrSlNo.Text = "";
            txtName.Text = "";

            RadioButtonList_TYPE.Enabled = true;
            GetTDS_Details();
            GetPayaleDetails("GetPayableDetail");
            LoadbankReceivableGrid();
            ClearClientMaster();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            hdn_updatedId.Value = "";
            ViewState["UPDATED_ID"] = null;
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
            ds = insert_update("U");

            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_BrSlNo.Text = txtBranchNO.Text;
                lblName.Text = txtName.Text;

                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");
                }
            }
            else
            {
                Alert_msg("Already exixts!", "btnUpdate");
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_Branch.DataSource = ds.Tables[1];
                gv_Branch.DataBind();
            }
            else
            {
                gv_Branch.DataSource = dt;
                gv_Branch.DataBind();
            }


        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }



    }

    private void ClearClientMaster()
    {

        hdn_updatedId.Value = "";
        txtBranchNO.Text = "";
        ddlType.SelectedIndex = -1;
        txtAdd1.Text = "";
        txtAdd2.Text = "";
        txtcity.Text = "";
        ddlStateName.SelectedIndex = -1;              //txtStateName.Text;
        txtPincode.Text = "";
        txtContactPerson.Text = "";
        txtPhoneNO.Text = "";
        txtEmail.Text = "";
        txtBinNO.Text = "";
        txtRemarks.Text = "";
        txtDrawback_AC_No.Text = "";
        txtPAN_No.Text = "";
        RadioButtonList_TYPE.SelectedValue = "";
        txt_TIN_No.Text = "";
        ddlStateName.SelectedIndex = -1;  // hdn_Txt_Statecode.Value;
        txtFax.Text = "";

        ddlType_Exp.SelectedIndex = -1;
        txt_Marksnos.Text = "";

        ddlCommercial_StateName.SelectedIndex = -1;
        txtCommercial_StateCode.Text = "";
        ddl_EXP_GSTN_Type.SelectedIndex = -1;
        txtCommercial_RegistrationNo.Text = "";
        ddlGSTN_Type.SelectedIndex = -1;
        txtGSTN_ID.Text = "";
        txtDistrict.Text = "";

        txt_SEZ_IcegateID.Text = "";
        txt_SEZ_PANNo.Text = "";
        txt_SEZ_AP_ID.Text = "";
        txt_SEZ_AP_Name.Text = "";
        txtWarehouseCode.Text = "";
        ddl_Payment_Method.SelectedIndex = -1;
        txtEndUse.Text = "";
        txtInsuranceRate.Text = "";
        txt_TAN_Number.Text = "";
        txt_TDS_Code.Text = "";
        txt_TDS_Rate.Text = "";
        ddlNatureOfTrans.SelectedIndex = -1;   // Added by shanthini on 12-06-2026
        ddlNatureOfPayment.SelectedIndex = -1;
        ddlValuationMethod.SelectedIndex = -1;
        chk_DB001.Checked = false;
        chk_DB002.Checked = false;
        chk_DB003.Checked = false;

        //Customer tab controls
        txtCust_CreditLimit.Text = "";
        ddlCust_cur.SelectedIndex = -1;
        chkCust_Unlimited.Checked = false;
        chkCust_CashOnDelivery.Checked = false;
        chkCust_InvOverdue.Checked = false;
        ddlCust_InvOverdue.SelectedIndex = -1;
        chkCust_CreditOnHold.Checked = false;
        txtCust_CreditOnHold_Remarks.Text = "";
        ddlCust_CreditPeriod.SelectedIndex = -1;
        txtCust_CreditDays.Text = "";
        txtCust_GL.Text = "";
       // ddlCust_GL.SelectedIndex = -1;
        txtCust_NotifEmail.Text = "";
        chkCust_OptionalCriteria.Checked = false;
        ddlCust_Receivable.SelectedIndex = -1;
        ddlCust_ReceivablePeriod.SelectedIndex = -1;
        txtCust_ReceivableDays.Text = "";
        ddlCust_Currency.SelectedIndex = -1;

        //Vendor tab controls
        chk_vendor_crt_limit.Checked = false;
        txtCreditLimit.Text = "";
        ddl_vendor_currency.SelectedIndex = -1;
        ddlPayableCreditCard.SelectedIndex = -1;
        txtPayableCreditNumbers.Text = "";
        ddlDuedateCalculate.SelectedIndex = -1;
        ddlVendorCurrency2.SelectedIndex = -1;
        txtVendorGL.Text = "";
        txt_Notification.Text = "";
        chkpaymentHold.Checked = false;
        txtPaymentonHold.Text = "";
        //TDS DETAILS CONTROLS
        ddlFinyear.SelectedIndex = -1;
        ddlOrganizationList.SelectedIndex = -1;
        chk_specifiedperson.Checked = false;
        ddlTds.SelectedIndex = -1;



    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["IMP_EXP_ID"] != "" && Request.QueryString["IMP_EXP_ID"] != null)
            {
                ClearClientMaster();
            }
            else
            {
                mo.ResetFields(Page.Controls);
            }

            txtIECNO.Text = string.Empty;
            txtIECNO.Enabled = true;
            txtName.Enabled = true;
            Session["IMP_EXP_ID"] = "";
            Session["flag"] = "SAVE";

            txtIECNO.Focus();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = false;
            btnSave.Visible = true;
            ViewState["UPDATED_ID"] = null;
            GVBranchEmptyTable();
            vendor_Customer_controlClear();
            lblIECNO.Text = string.Empty;
            lblName.Text = string.Empty;
            lbl_BrSlNo.Text = string.Empty;
            txtName.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    private void GVBranchEmptyTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("IMP_EXP_BRSLNO");
        dt.Columns.Add("IMP_EXP_ADD3");
        gv_Branch.DataSource = dt;
        gv_Branch.DataBind();
    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CLIENT MASTER', function (r) {}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
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
        txtIECNO = result + "~~" + flag;
        return txtIECNO;
    }

    [System.Web.Services.WebMethod]
    public static string Get_ClientName_Details(string txtName)
    {
        string flag = "", Working_Period = "", result = "",

            type = "";
        if (txtName.Length != 0)
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

    [System.Web.Services.WebMethod]
    public static string Set_State_Name_Validation(string custid)
    {
        try
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
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }

    [System.Web.Services.WebMethod]
    public static object Check_ClientName_IECNo_BrSlno(string IECNO, string ClientName, int BrSlno, string IMP_EXP_ID, string StandardType)
    {
        Client_Master_New_cs obj = new Client_Master_New_cs();
        Global_variables ObjUBO = new Global_variables();
        DataSet dss = new DataSet();
        ObjUBO.A100 = IMP_EXP_ID;
        ObjUBO.A101 = ClientName;
        ObjUBO.A102 = IECNO;
        ObjUBO.A103 = Convert.ToString(BrSlno);
        ObjUBO.A104 = StandardType;
        dss = obj.CheckIECNO_BrSlno_Name(ObjUBO);
        return new
        {
            Status = Convert.ToInt32(ObjUBO.A105),
            Message = ObjUBO.A106
        };
    }
    protected void gv_Branch_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";


    }

    protected void gv_Branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            lblName.Text = "";
            ClearClientMaster();
            Clear_BankReceivableControls();
            ClearPayableDetailsContrls();
            hdn_brslno.Value = gv_Branch.DataKeys[gv_Branch.SelectedIndex]["IMP_EXP_BRSLNO"].ToString();
            hdn_updatedId.Value = gv_Branch.DataKeys[gv_Branch.SelectedIndex]["IMP_EXP_ID"].ToString();
            Hdn_StandardType.Value = gv_Branch.DataKeys[gv_Branch.SelectedIndex]["STANDARD_TYPE"].ToString();
            hdn_ClientName.Value = gv_Branch.DataKeys[gv_Branch.SelectedIndex]["IMP_EXP_NAME"].ToString();
            hdn_IEC_NO.Value = gv_Branch.DataKeys[gv_Branch.SelectedIndex]["IMP_EXP_IECNO"].ToString();
            Edit_BranchDetails(hdn_updatedId.Value, hdn_IEC_NO.Value, hdn_ClientName.Value, hdn_brslno.Value, Hdn_StandardType.Value);
            GetTDS_Details();
            GetPayaleDetails("GetPayableDetail");
            LoadbankReceivableGrid();


        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    public void Edit_BranchDetails(string IMP_EXP_ID, string IECNo, string Name, string Br_Slno, string StandardType)
    {
        try
        {

            ObjUBO.A1 = IMP_EXP_ID;
            ObjUBO.A2 = Br_Slno;
            ObjUBO.A3 = IECNo;
            ObjUBO.A4 = Name;
            ObjUBO.A5 = (StandardType == "NS") ? "Non_STD" : null;

            ObjUBO.A20 = "select_conwithcode_STD";
            dtuser = CM.ClientMaster_Select(ObjUBO);

            // ----------------------------------------------------------------------------------------
            if (dtuser.Tables[0].Rows.Count > 0)
            {

                ViewState["UPDATED_ID"] = dtuser.Tables[0].Rows[0]["IMP_EXP_ID"].ToString();
                hdn_updatedId.Value = dtuser.Tables[0].Rows[0]["IMP_EXP_ID"].ToString();
                Hdn_StandardType.Value = dtuser.Tables[0].Rows[0]["STANDARD_TYPE"].ToString();
                RadioButtonList_TYPE.SelectedValue = Hdn_StandardType.Value;
                RadioButtonList_TYPE.Enabled = false;
                Session["flag"] = "UPDATE";
                Rdstr.SelectedValue = dtuser.Tables[0].Rows[0]["EXP_STR_YN"].ToString();

                AUTO_ID = dtuser.Tables[0].Rows[0]["IMP_EXP_ID"].ToString();
                txtName.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                txtIECNO.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                txtBranchNO.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                txtBranchNO.Enabled = true;
                string type = dtuser.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                txtIECNO.Enabled = false;

                txtAdd1.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                txtAdd2.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                txtcity.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();

                // txtStateName.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                ddlStateName.SelectedValue = dtuser.Tables[0].Rows[0]["STATE_CODE"].ToString();

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
                //hdn_Txt_Statecode.Value = dtuser.Tables[0].Rows[0]["STATE_CODE"].ToString();

                ddlType.SelectedValue = type;


                RadioButtonList_TYPE.SelectedValue = dtuser.Tables[0].Rows[0]["STANDARD_TYPE"].ToString();
                HiddenField1.Value = IMP_EXP_ID;

                txt_Marksnos.Text = dtuser.Tables[0].Rows[0]["MARKS_NO"].ToString();
                string Exporter_Type = dtuser.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString();


                hdn_ddlCommercial_Tax_yn.Value = "Y";
                ddlCommercial_StateName.SelectedValue = dtuser.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATECODE"].ToString();
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
                txtWarehouseCode.Text = dtuser.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
                if (dtuser.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString() == "T")
                {
                    ddl_Payment_Method.SelectedValue = dtuser.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString();
                }
                else if (dtuser.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString() == "D")
                {
                    ddl_Payment_Method.SelectedValue = dtuser.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString();
                }
                txtEndUse.Text = dtuser.Tables[0].Rows[0]["ITEM_END_USE"].ToString();
                txtInsuranceRate.Text = dtuser.Tables[0].Rows[0]["CLIENT_INSURANCE_RATE"].ToString();
                txt_TAN_Number.Text = dtuser.Tables[0].Rows[0]["TAN_NUMBER"].ToString();
                txt_TDS_Code.Text = dtuser.Tables[0].Rows[0]["TDS_CODE"].ToString();
                txt_TDS_Rate.Text = dtuser.Tables[0].Rows[0]["TDS_RATE"].ToString();
                ddlNatureOfPayment.SelectedValue = dtuser.Tables[0].Rows[0]["NATURE_OF_PAYMENT"].ToString();
                ddlNatureOfTrans.SelectedValue = dtuser.Tables[0].Rows[0]["NATURE_OF_TRANS"].ToString();
                ddlValuationMethod.SelectedValue = dtuser.Tables[0].Rows[0]["VALUATION_METHOD"].ToString();

                lblName.Text = txtName.Text;
                lblIECNO.Text = txtIECNO.Text;
                lbl_BrSlNo.Text = txtBranchNO.Text;

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnAdcode.Visible = true;
                btnSave.Visible = false;
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = IMP_EXP_ID;
                txtIECNO.Enabled = false;


                //Customer tab control bind
                txtCust_CreditLimit.Text = dtuser.Tables[0].Rows[0]["A_C_CREDITLIMIT"].ToString();
                ddlCust_cur.SelectedValue = dtuser.Tables[0].Rows[0]["A_C_CUR"].ToString();
                chkCust_Unlimited.Checked = Convert.ToBoolean(dtuser.Tables[0].Rows[0]["A_C_UNLIMITED"]);
                chkCust_CashOnDelivery.Checked = Convert.ToBoolean(dtuser.Tables[0].Rows[0]["A_C_COD"]);
                chkCust_InvOverdue.Checked = Convert.ToBoolean(dtuser.Tables[0].Rows[0]["A_C_CHK_OVERDUE"]);
                ddlCust_InvOverdue.SelectedValue = (dtuser.Tables[0].Rows[0]["A_C_OVERDUE_RESTRICTION"] != DBNull.Value) ?
                    (dtuser.Tables[0].Rows[0]["A_C_OVERDUE_RESTRICTION"].ToString() == "-1") ? "" : dtuser.Tables[0].Rows[0]["A_C_OVERDUE_RESTRICTION"].ToString() : "";
                chkCust_CreditOnHold.Checked = Convert.ToBoolean(dtuser.Tables[0].Rows[0]["A_C_CHK_CRD_HOLD"]);
                txtCust_CreditOnHold_Remarks.Text = dtuser.Tables[0].Rows[0]["A_C_CREDITONHOLD"].ToString();
                ddlCust_CreditPeriod.SelectedValue = (dtuser.Tables[0].Rows[0]["A_C_REC_CRE_PERIOD_DDL"] != DBNull.Value) ?
                    (dtuser.Tables[0].Rows[0]["A_C_REC_CRE_PERIOD_DDL"].ToString() == "-1") ? "" : dtuser.Tables[0].Rows[0]["A_C_REC_CRE_PERIOD_DDL"].ToString() : "";
                txtCust_CreditDays.Text = dtuser.Tables[0].Rows[0]["A_C_REC_CRE_PERIOD_DAYS"].ToString();
               
              
                txtCust_GL.Text = dtuser.Tables[0].Rows[0]["A_C_CUSTOMER_GL"].ToString();
                txtCust_NotifEmail.Text = dtuser.Tables[0].Rows[0]["A_C_NOT_EMAIL"].ToString();
                chkCust_OptionalCriteria.Checked = Convert.ToBoolean(dtuser.Tables[0].Rows[0]["A_C_CHK_OPT_CRITERIA"]);
                ddlCust_Receivable.SelectedValue = (dtuser.Tables[0].Rows[0]["A_C_REC_DDL"] != DBNull.Value) ?
                    (dtuser.Tables[0].Rows[0]["A_C_REC_DDL"].ToString() == "-1") ? "" : dtuser.Tables[0].Rows[0]["A_C_REC_DDL"].ToString() : "";
                ddlCust_ReceivablePeriod.SelectedValue = (dtuser.Tables[0].Rows[0]["A_C_REC_NO_DAYS"] != DBNull.Value) ?
                    (dtuser.Tables[0].Rows[0]["A_C_REC_NO_DAYS"].ToString() == "-1") ? "" : dtuser.Tables[0].Rows[0]["A_C_REC_NO_DAYS"].ToString() : "";
                txtCust_ReceivableDays.Text = dtuser.Tables[0].Rows[0]["A_C_REC_TXTBOX"].ToString();
                ddlCust_Currency.SelectedValue = (dtuser.Tables[0].Rows[0]["A_C_CUR2"] != DBNull.Value) ?
                    (dtuser.Tables[0].Rows[0]["A_C_CUR2"].ToString() == "-1") ? "" : dtuser.Tables[0].Rows[0]["A_C_CUR2"].ToString() : "";
                //Vendor tab control bind
                chk_vendor_crt_limit.Checked = Convert.ToBoolean(dtuser.Tables[0].Rows[0]["A_V_UNLIMITED"]);
                txtCreditLimit.Text = dtuser.Tables[0].Rows[0]["A_V_CREDITLIMIT"].ToString();
                ddl_vendor_currency.SelectedValue = (dtuser.Tables[0].Rows[0]["A_V_CUR"] != DBNull.Value) ?
                    (dtuser.Tables[0].Rows[0]["A_V_CUR"].ToString() == "-1") ? "" : dtuser.Tables[0].Rows[0]["A_V_CUR"].ToString() : "";
                ddlPayableCreditCard.SelectedValue = (dtuser.Tables[0].Rows[0]["A_V_PAY_CRE_PERIOD_DDL"] != DBNull.Value) ?
                    (dtuser.Tables[0].Rows[0]["A_V_PAY_CRE_PERIOD_DDL"].ToString() == "-1") ? "" : dtuser.Tables[0].Rows[0]["A_V_PAY_CRE_PERIOD_DDL"].ToString() : "";
                txtPayableCreditNumbers.Text = dtuser.Tables[0].Rows[0]["A_V_PAY_CRE_PERIOD_TXT"].ToString();
                ddlDuedateCalculate.SelectedValue = (dtuser.Tables[0].Rows[0]["A_V_DUEDATE_CAL"] != DBNull.Value) ?
                    (dtuser.Tables[0].Rows[0]["A_V_DUEDATE_CAL"].ToString() == "-1") ? "" : dtuser.Tables[0].Rows[0]["A_V_DUEDATE_CAL"].ToString() : "";
                ddlVendorCurrency2.SelectedValue = (dtuser.Tables[0].Rows[0]["A_V_CUR2"] != DBNull.Value) ?
                    (dtuser.Tables[0].Rows[0]["A_V_CUR2"].ToString() == "-1") ? "" : dtuser.Tables[0].Rows[0]["A_V_CUR2"].ToString() : "";
               
               
                txtVendorGL.Text = dtuser.Tables[0].Rows[0]["A_V_VENDORGL"].ToString();
                txt_Notification.Text = dtuser.Tables[0].Rows[0]["A_V_NOTIFIC_MAIL"].ToString();
                chkpaymentHold.Checked = Convert.ToBoolean(dtuser.Tables[0].Rows[0]["A_V_PAYMENT_CHK"]);
                txtPaymentonHold.Text = dtuser.Tables[0].Rows[0]["A_V_PAYMENTON_HOLD"].ToString();
                //TDS TAB CONTROLS BIND

                ddlFinyear.SelectedValue = (dtuser.Tables[0].Rows[0]["A_T_FISCALYEAR"] != DBNull.Value) ?
                    (dtuser.Tables[0].Rows[0]["A_T_FISCALYEAR"].ToString() == "-1") ? "" : dtuser.Tables[0].Rows[0]["A_T_FISCALYEAR"].ToString() : "";
                ddlOrganizationList.SelectedValue = (dtuser.Tables[0].Rows[0]["A_T_ORG_TYPE"] != DBNull.Value) ?
                    (dtuser.Tables[0].Rows[0]["A_T_ORG_TYPE"].ToString() == "-1") ? "" : dtuser.Tables[0].Rows[0]["A_T_ORG_TYPE"].ToString() : "";
                chk_specifiedperson.Checked = Convert.ToBoolean(dtuser.Tables[0].Rows[0]["A_T_SPC_PERSON"]);

                //ddlTds.SelectedValue = (dtuser.Tables[0].Rows[0]["A_T_TDS_RECEIVABLE"] != DBNull.Value) ?
                //    (dtuser.Tables[0].Rows[0]["A_T_TDS_RECEIVABLE"].ToString() == "-1") ? "" : dtuser.Tables[0].Rows[0]["A_T_TDS_RECEIVABLE"].ToString() : "";

                hdnAC_Code.Value = dtuser.Tables[0].Rows[0]["A_C_CODE"].ToString();

                HdnAV_Code.Value = dtuser.Tables[0].Rows[0]["A_V_CODE"].ToString();

                ddl_IGST_Payment.SelectedValue = (dtuser.Tables[0].Rows[0]["GST_PAYMENT_METHOD"] != DBNull.Value) ?
                    (dtuser.Tables[0].Rows[0]["GST_PAYMENT_METHOD"].ToString() == "-1") ? "" : dtuser.Tables[0].Rows[0]["GST_PAYMENT_METHOD"].ToString() : "";
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    private string Client_DrawBack_Customization()
    {
        string[] allowedCompanies =
    {
        "1", "10", "1344", "1572", "1623", "2078",
        "2118", "2152", "2153", "2154", "2155",
        "2214", "2305"
    };

        if (Array.IndexOf(allowedCompanies, Company_ID) < 0)
            return string.Empty;

        return (chk_DB001.Checked ? "1" : "") +
               (chk_DB002.Checked ? "2" : "") +
               (chk_DB003.Checked ? "3" : "");
    }

    private void AlertInfo(string Status)
    {
        int _status = 0;
        int.TryParse(Status, out _status);
        switch (_status)
        {
            case 1:
                Alert_msg("Client already exists", "txtIECNO");
                return;

            case 2:
                Alert_msg("Data has been deleted successfully", "btn_Delete");
                break;
            case -2:
                Alert_msg("Data isn't deleted", "btn_Delete");
                return;
        }
    }

    private void vendor_Customer_controlClear()
    {

        txtCust_CreditLimit.Text = string.Empty;
        ddlCust_cur.SelectedIndex = -1;
        chkCust_Unlimited.Checked = false;
        chkCust_CashOnDelivery.Checked = false;
        chkCust_InvOverdue.Checked = false;
        ddlCust_InvOverdue.SelectedIndex = -1;
        chkCust_CreditOnHold.Checked = false;
        txtCust_CreditOnHold_Remarks.Text = string.Empty;
        ddlCust_CreditPeriod.SelectedIndex = -1;
        txtCust_CreditDays.Text = string.Empty;
        txtCust_GL.Text = "";
       // ddlCust_GL.SelectedIndex = -1;
        txtCust_NotifEmail.Text = string.Empty;
        chkCust_OptionalCriteria.Checked = false;
        ddlCust_Receivable.SelectedIndex = -1;
        ddlCust_ReceivablePeriod.SelectedIndex = -1;
        txtCust_ReceivableDays.Text = string.Empty;
        ddlCust_Currency.SelectedIndex = -1;
        //Vendor tab control bind
        chk_vendor_crt_limit.Checked = false;
        txtCreditLimit.Text = string.Empty;
        ddl_vendor_currency.SelectedIndex = -1;
        ddlPayableCreditCard.SelectedIndex = -1;
        txtPayableCreditNumbers.Text = string.Empty;
        ddlDuedateCalculate.SelectedIndex = -1;
        ddlVendorCurrency2.SelectedIndex = -1;
        txtVendorGL.Text = "";
        txt_Notification.Text = string.Empty;
        chkpaymentHold.Checked = false;
        txtPaymentonHold.Text = string.Empty;
        ddlFinyear.SelectedIndex = -1;
        ddlOrganizationList.SelectedIndex = -1;
        chk_specifiedperson.Checked = false;
        ddlTds.SelectedIndex = -1;
    }

    protected void gv_TDS_Detail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }

    protected void gv_TDS_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gv_TDS_Detail.PageIndex = e.NewPageIndex;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);

        }
    }
    protected void grd_PayableDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    protected void grd_PayableDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (hdn_Grid_Disable.Value == "1")
            {
                e.Row.Enabled = false;
            }
            else
            {
                e.Row.Enabled = true;
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.grd_PayableDetails, "Select$" + e.Row.RowIndex.ToString()));
            }
        }
    }
    protected void grd_PayableDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdn_PayableId.Value = grd_PayableDetails.DataKeys[grd_PayableDetails.SelectedIndex]["PAYABLE_ID"].ToString();
        string IECNO = grd_PayableDetails.DataKeys[grd_PayableDetails.SelectedIndex]["ACC_IECNO"].ToString();
        string BrSlno = grd_PayableDetails.DataKeys[grd_PayableDetails.SelectedIndex]["ACC_BRSLNO"].ToString();
        Edit_PayableDetails(IECNO, BrSlno, hdn_PayableId.Value);
    }
    protected void btn_newPayable_Click(object sender, EventArgs e)
    {
        btnPayableUpdate.Visible = false;
        btnSavePayableDetail.Visible = true;
        btn_PayableDelete.Visible = false;
        ClearPayableDetailsContrls();

    }
    protected void btnSavePayableDetail_Click(object sender, EventArgs e)
    {
        try
        {
            btnPayableUpdate.Visible = false;
            INSERT_UPADATE_PAYABLE_DETAILS("Save");

            if (ObjUBO.A13 == "1")
            {
                Alert_msg("Payable Details has been saved!");
            }
            ClearPayableDetailsContrls();
            GetPayaleDetails("GetPayableDetail");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnPayableUpdate_Click(object sender, EventArgs e)
    {
        btnSavePayableDetail.Visible = false;
        INSERT_UPADATE_PAYABLE_DETAILS("Update");
        ClearPayableDetailsContrls();
        GetPayaleDetails("GetPayableDetail");
        if (ObjUBO.A13 == "2")
        {
            Alert_msg("Payable Details has been Updated!");
        }

    }
    protected void btn_PayableDelete_Click(object sender, EventArgs e)
    {
        try
        {
            INSERT_UPADATE_PAYABLE_DETAILS("Delete");
            if (ObjUBO.A13 == "3")
            {
                Alert_msg("Payable Details has been deleted!");
            }
            ClearPayableDetailsContrls();
            GetPayaleDetails("GetPayableDetail");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void INSERT_UPADATE_PAYABLE_DETAILS(string Flag)
    {
        try
        {
            ObjUBO.A1 = txtOrgainzationName.Text;
            ObjUBO.A2 = ddlbankName.SelectedValue;
            ObjUBO.A3 = txtBranch.Text;
            ObjUBO.A4 = txtAcNo.Text;
            ObjUBO.A5 = txtIFSC_code.Text;
            ObjUBO.A6 = txtAddess1.Text;
            ObjUBO.A7 = txtAdddress2.Text;
            ObjUBO.A8 = t_district.Text;
            ObjUBO.A9 = ddl_state.SelectedValue;
            ObjUBO.A10 = txt_Pincode.Text;
            ObjUBO.A11 = hdn_IEC_NO.Value;
            ObjUBO.A12 = txtBranchNO.Text.Trim();
            if (Flag == "Update" || Flag == "Delete")
            {
                CM.PayableId = Convert.ToInt32(hdn_PayableId.Value);
            }
            ObjUBO.A30 = Flag;
            ds = CM.PAYABLE_DETAILS_INSERT_UPADATE(ObjUBO);
            hdn_PayableId.Value = ObjUBO.A14;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void GetPayaleDetails(string Flag)
    {
        ObjUBO.A30 = Flag;
        ObjUBO.A11 = hdn_IEC_NO.Value;
        ObjUBO.A12 = hdn_brslno.Value;
        ds = CM.PAYABLE_DETAILS_INSERT_UPADATE(ObjUBO);
        grd_PayableDetails.DataSource = ds.Tables[0];
        grd_PayableDetails.DataBind();
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
        {
            BindPayableDetailsFromRow(ds.Tables[0].Rows[0]);
            btnSavePayableDetail.Visible = false;
            btnPayableUpdate.Visible = true;
            btn_PayableDelete.Visible = true;
        }
        else
        {
            btnSavePayableDetail.Visible = true;
            btnPayableUpdate.Visible = false;
            btn_PayableDelete.Visible = false;
        }
    }
    private void ClearPayableDetailsContrls()
    {
        txtOrgainzationName.Text = string.Empty;
        ddlbankName.SelectedIndex = -1;
        txtBranch.Text = string.Empty;
        txtAcNo.Text = string.Empty;
        txtIFSC_code.Text = string.Empty;
        txtAddess1.Text = string.Empty;
        txtAdddress2.Text = string.Empty;
        t_district.Text = string.Empty;
        ddl_state.SelectedIndex = -1;
        txt_Pincode.Text = string.Empty;
    }
    public void Edit_PayableDetails(string IECNO, string branchSlno, string PayableId)
    {
        try
        {
            ObjUBO.A30 = "Select_PayableDetail";
            ObjUBO.A11 = IECNO;
            ObjUBO.A12 = branchSlno;
            CM.PayableId = Convert.ToInt32(PayableId);
            ds = CM.PAYABLE_DETAILS_INSERT_UPADATE(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                BindPayableDetailsFromRow(ds.Tables[0].Rows[0]);
                btnSavePayableDetail.Visible = false;
                btnPayableUpdate.Visible = true;
                btn_PayableDelete.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void BindPayableDetailsFromRow(DataRow row)
    {
        hdn_PayableId.Value = row["PAYABLE_ID"] != DBNull.Value ? row["PAYABLE_ID"].ToString() : "0";
        txtOrgainzationName.Text = row["ACC_ORG_NAME"].ToString();
        ddlbankName.SelectedValue = (row["ACC_BANKNAME"] != DBNull.Value)
            ? row["ACC_BANKNAME"].ToString() : "-1";
        txtBranch.Text = row["ACC_BRANCH"].ToString();
        txtAcNo.Text = row["ACC_AC_NO"].ToString();
        txtIFSC_code.Text = row["ACC_IFSC_CODE"].ToString();
        txtAddess1.Text = row["ACC_ADDRESS1"].ToString();
        txtAdddress2.Text = row["ACC_ADDRESS2"].ToString();
        t_district.Text = row["ACC_DISTRICT"].ToString();
        ddl_state.SelectedValue = (row["ACC_STATE"] != DBNull.Value)
            ? row["ACC_STATE"].ToString() : "-1";
        txt_Pincode.Text = row["ACC_PINCODE"].ToString();
    }
    private void GetTDS_Details()
    {
        ObjUBO.A3 = hdn_IEC_NO.Value;
        ObjUBO.A4 = (string.IsNullOrEmpty(txtBranchNO.Text)) ? hdn_brslno.Value : txtBranchNO.Text;
        ObjUBO.A200 = "SelectTDSDetails";
        ds = CM.Imp_Exp_Master_Insert_update_STD(ObjUBO);
        if (ds.Tables.Count > 0)
        {
            gv_TDS_Detail.DataSource = ds.Tables[0];
            gv_TDS_Detail.DataBind();
        }
    }
    protected void btn_newReceivable_Click(object sender, EventArgs e)
    {
        btnReceivableUpdate.Visible = false;
        btnSaveReceivable.Visible = true;
        btn_ReceivableDelete.Visible = false;
        Clear_BankReceivableControls();

    }

    protected void btnSaveReceivable_Click(object sender, EventArgs e)
    {
        btnReceivableUpdate.Visible = false;
        Insert_Update_bankReceviable("SAVE");
        if (ObjUBO.A13 == "1")
        {
            Alert_msg("Payable Details has been saved!");
        }
        Clear_BankReceivableControls();
        LoadbankReceivableGrid();
    }
    protected void btnReceivableUpdate_Click(object sender, EventArgs e)
    {
        btnSaveReceivable.Visible = false;
        Insert_Update_bankReceviable("UPDATE");
        if (ObjUBO.A13 == "2")
        {
            Alert_msg("Payable Details has been Updated!");
        }
        Clear_BankReceivableControls();
        LoadbankReceivableGrid();
    }
    protected void btn_ReceivableDelete_Click(object sender, EventArgs e)
    {
        Insert_Update_bankReceviable("Delete");
        if (ObjUBO.A13 == "3")
        {
            Alert_msg("Payable Details has been Deleted!");
        }
        Clear_BankReceivableControls();
        LoadbankReceivableGrid();
    }

    protected void grd_ReceivableDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.CssClass = "header";
        }
    }

    protected void grd_ReceivableDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdn_ReceivableId.Value = grd_ReceivableDetails.DataKeys[grd_ReceivableDetails.SelectedIndex]["RECEIVABLEID"].ToString();
        string Receivable_IECNo = grd_ReceivableDetails.DataKeys[grd_ReceivableDetails.SelectedIndex]["ACC_REC_IECNO"].ToString();
        string Receivable_BrSlno = grd_ReceivableDetails.DataKeys[grd_ReceivableDetails.SelectedIndex]["ACC_REC_BRSLNO"].ToString();
        Edit_ReceivableDetails(Receivable_IECNo, Receivable_BrSlno, hdn_ReceivableId.Value);
    }
    protected void grd_ReceivableDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (hdn_Grid_Disable.Value == "1")
            {
                e.Row.Enabled = false;
            }
            else
            {
                e.Row.Enabled = true;
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.grd_ReceivableDetails, "Select$" + e.Row.RowIndex.ToString()));
            }
        }
    }
    protected void grd_ReceivableDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_ReceivableDetails.PageIndex = e.NewPageIndex;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Insert_Update_bankReceviable(string Flag)
    {
        try
        {
            ObjUBO.A1 = txt_Rec_OrgainzationName.Text;
            ObjUBO.A2 = ddl_RecevbankName.SelectedValue;
            ObjUBO.A3 = txt_Recev_Branch.Text;
            ObjUBO.A4 = txt_RecevAcNo.Text;
            ObjUBO.A5 = txt_RecevIFSC_code.Text;
            ObjUBO.A6 = txt_RecevAddess1.Text;
            ObjUBO.A7 = txt_RecevAdddress2.Text;
            ObjUBO.A8 = t_Recevdistrict.Text;
            ObjUBO.A9 = ddl_Recev_state.SelectedValue;
            ObjUBO.A10 = txt_Recev_Pincode.Text;
            ObjUBO.A11 = hdn_IEC_NO.Value;
            ObjUBO.A12 = txtBranchNO.Text.Trim();
            if (Flag == "UPDATE" || Flag == "Delete")
            {
                CM.ReceivableId = Convert.ToInt32(hdn_ReceivableId.Value);
            }
            ObjUBO.A30 = Flag;
            ds = CM.Receivable_Insert_Update(ObjUBO);
            hdn_ReceivableId.Value = ObjUBO.A14;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Clear_BankReceivableControls()
    {
        txt_Rec_OrgainzationName.Text = "";
        ddl_RecevbankName.SelectedIndex = -1;
        txt_Recev_Branch.Text = "";
        txt_RecevAcNo.Text = "";
        txt_RecevIFSC_code.Text = "";
        txt_RecevAddess1.Text = "";
        txt_RecevAdddress2.Text = "";
        t_Recevdistrict.Text = "";
        ddl_Recev_state.Text = "";
        txt_Recev_Pincode.Text = "";
    }

    public void LoadbankReceivableGrid()
    {
        ObjUBO.A11 = hdn_IEC_NO.Value;
        ObjUBO.A12 = string.IsNullOrEmpty(hdn_brslno.Value) ? txtBranchNO.Text : hdn_brslno.Value;
        ObjUBO.A30 = "Select_BankReceivable_Detail";
        ds = CM.Receivable_Insert_Update(ObjUBO);
        grd_ReceivableDetails.DataSource = ds.Tables[0];
        grd_ReceivableDetails.DataBind();
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
        {
            BindbankReceivableDetail(ds.Tables[0].Rows[0]);
            grd_ReceivableDetails.DataSource = ds.Tables[0];
            grd_ReceivableDetails.DataBind();
            btnSaveReceivable.Visible = false;
            btnReceivableUpdate.Visible = true;
            btn_ReceivableDelete.Visible = true;
        }
        else
        {
            btnSaveReceivable.Visible = true;
            btnReceivableUpdate.Visible = false;
            btn_ReceivableDelete.Visible = false;
        }
    }
    private void BindbankReceivableDetail(DataRow row)
    {
        hdn_ReceivableId.Value = (row["RECEIVABLEID"] != DBNull.Value) ? row["RECEIVABLEID"].ToString() : "0";
        txt_Rec_OrgainzationName.Text = row["ACC_REC_ORG_NAME"].ToString();
        ddl_RecevbankName.SelectedValue = (row["ACC_REC_BANKNAME"] != DBNull.Value) ? row["ACC_REC_BANKNAME"].ToString() : "-1";
        txt_Recev_Branch.Text = row["ACC_REC_BRANCH"].ToString();
        txt_RecevAcNo.Text = row["ACC_REC_AC_NO"].ToString();
        txt_RecevIFSC_code.Text = row["ACC_REC_IFSC_CODE"].ToString();
        txt_RecevAddess1.Text = row["ACC_REC_ADDRESS1"].ToString();
        txt_RecevAdddress2.Text = row["ACC_REC_ADDRESS2"].ToString();
        t_Recevdistrict.Text = row["ACC_REC_DISTRICT"].ToString();
        ddl_Recev_state.SelectedValue = (row["ACC_REC_STATE"] != DBNull.Value) ? row["ACC_REC_STATE"].ToString() : "-1";
        txt_Recev_Pincode.Text = row["ACC_REC_PINCODE"].ToString();
    }
    public void Edit_ReceivableDetails(string IECNO, string branchSlno, string ReceivableId)
    {
        try
        {
            ObjUBO.A30 = "Select_ReceivableDetail";
            ObjUBO.A11 = IECNO;
            ObjUBO.A12 = branchSlno;
            CM.ReceivableId = Convert.ToInt32(ReceivableId);
            ds = CM.Receivable_Insert_Update(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                BindbankReceivableDetail(ds.Tables[0].Rows[0]);
                btnSaveReceivable.Visible = false;
                btnReceivableUpdate.Visible = true;
                btn_ReceivableDelete.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void gv_TDS_Detail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    /*private void LoadCustomerGL()
    {
        try
        {
            ObjUBO.A20 = "DDLCustomerGl";
            ds = CM.ClientMaster_Select(ObjUBO);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlCust_GL.DataSource = ds.Tables[0];
                ddlCust_GL.DataValueField = "ID";
                ddlCust_GL.DataTextField = "NAME";
                ddlCust_GL.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    
    private void LoadVendorGL()
    {
        try
        {
            ObjUBO.A20 = "DDLVendorGl";
            ds = CM.ClientMaster_Select(ObjUBO);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlvendorGL.DataSource = ds.Tables[0];
                ddlvendorGL.DataValueField = "ID";
                ddlvendorGL.DataTextField = "NAME";
                ddlvendorGL.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
      */
}