using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;

public partial class Acc_Charges_Master_N : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create   = new User_Creation();
    Global_variables ObjUBO = new Global_variables();
    Acc_Charge_Master_New_cs CI = new Acc_Charge_Master_New_cs();
    DataTable dt = new DataTable();
    public int    i, Screen_Id;
    public string PAGE_MODIFY;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!Page.IsPostBack)
        {
            Screen_Id = 11;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            T.Visible = false;

            if (Request.QueryString["CHRG_ID"] == null)
            {
                HDupdate_id.Value = "";
                txtcode.Text = Generate_Next_Charge_Code();
            }
            else
            {
                string chrgId = Request.QueryString["CHRG_ID"];
                if (!string.IsNullOrEmpty(chrgId))
                {
                    Update_Item_Load(chrgId);
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                }

            }
        }
    }
    private void Update_Item_Load(string Id)
    {
        DataSet dss = new DataSet();
        ObjUBO.A1 = Id;
        ObjUBO.A9 = "Updated_Data_Select";
        dss = CI.Charge_Master_Select(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            HDupdate_id.Value = dss.Tables[0].Rows[0]["CHRG_ID"].ToString();

            txtcode.Text = dss.Tables[0].Rows[0]["CHARGE_CODE"].ToString();
            txtName.Text = dss.Tables[0].Rows[0]["CHARGE_NAME"].ToString();

            txtName.ReadOnly = true;
            txtName.Style.Add("background-color", "#e9e9e9");
            txtName.Style.Add("color", "#888888");
            txtName.Style.Add("cursor", "not-allowed");

            ddl_charge_category.Enabled = false;

            string applicableFor = dss.Tables[0].Rows[0]["APPLICABLE_FOR"].ToString();  

            foreach (ListItem item in chkApplicableFor.Items)
            {
                item.Selected = false;
            }

            if (!string.IsNullOrEmpty(applicableFor))
            {
                string[] selectedValues = applicableFor.Split(',');
                foreach (string val in selectedValues)
                {
                    string trimVal = val.Trim();
                    ListItem li = chkApplicableFor.Items.FindByValue(trimVal);
                    if (li != null)
                    {
                        li.Selected = true;
                    }
                }

                hdApplicableFor.Value = applicableFor;
            }
            else
            {
                hdApplicableFor.Value = string.Empty;
            }
            string script = "updateApplicableForDisplay();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "restoreApplicableFor", script, true);

            ddl_charge_category.SelectedValue =  dss.Tables[0].Rows[0]["CHARGE_CATEGORY"].ToString();
            ddl_charge_type.SelectedValue =  dss.Tables[0].Rows[0]["CHARGE_TYPE"].ToString();
            ddl_IATA_code.SelectedValue =  dss.Tables[0].Rows[0]["IATA_CODE"].ToString();


            chkServiceTax.Checked = dss.Tables[0].Rows[0]["SERVICE_TAX_APPLICABLE"].ToString() == "Y";
            ddl_ServiceTax_Category.SelectedValue =  dss.Tables[0].Rows[0]["SERVICE_TAX_CATEGORY"].ToString();

            chkVAT.Checked =dss.Tables[0].Rows[0]["VAT_APPLICABLE"].ToString() == "Y"; 
            ddl_VAT_Category.SelectedValue =  dss.Tables[0].Rows[0]["VAT_CATEGORY"].ToString();

            chkGST.Checked = dss.Tables[0].Rows[0]["GST_APPLICABLE"].ToString() == "Y"; 
            ddl_GST_SacHsn.SelectedValue =  dss.Tables[0].Rows[0]["GST_SAC_HSN"].ToString();
            txt_HSN_SAC_Code.Text = dss.Tables[0].Rows[0]["GST_HSN_SAC_CODE"].ToString();
            txt_GST_Category.Text =  dss.Tables[0].Rows[0]["GST_CATEGORY"].ToString();


            ddl_GST_SubCategory.SelectedValue =  dss.Tables[0].Rows[0]["GST_SUB_CATEGORY"].ToString();
            txt_GST_Taxable.Text =  dss.Tables[0].Rows[0]["GST_TAXABLE"].ToString();
            chkGST_Override.Checked = dss.Tables[0].Rows[0]["GST_OVERRIDE"].ToString() == "Y"; 

            txt_R1_Income.Text =  dss.Tables[0].Rows[0]["VLE_INCOME"].ToString();
            txt_R1_Expense.Text =  dss.Tables[0].Rows[0]["VLE_EXPENSE"].ToString();
            ddl_R1_CostCenter.SelectedValue =  dss.Tables[0].Rows[0]["VLE_COST_CENTER"].ToString();

            txt_R2_Income.Text =  dss.Tables[0].Rows[0]["CCI_INCOME"].ToString();
            txt_R2_Expense.Text =  dss.Tables[0].Rows[0]["CCI_EXPENSE"].ToString();
            ddl_R2_CostCenter.SelectedValue =  dss.Tables[0].Rows[0]["CCI_COST_CENTER"].ToString();

            txt_R3_Income.Text =  dss.Tables[0].Rows[0]["CCE_INCOME"].ToString();
            txt_R3_Expense.Text =  dss.Tables[0].Rows[0]["CCE_EXPENSE"].ToString();
            ddl_R3_CostCenter.SelectedValue =  dss.Tables[0].Rows[0]["CCE_COST_CENTER"].ToString();

            txt_R4_Income.Text =  dss.Tables[0].Rows[0]["TRN_INCOME"].ToString();
            txt_R4_Expense.Text =  dss.Tables[0].Rows[0]["TRN_EXPENSE"].ToString();
            ddl_R4_CostCenter.SelectedValue =  dss.Tables[0].Rows[0]["TRN_COST_CENTER"].ToString();

            txt_R5_Income.Text =  dss.Tables[0].Rows[0]["GEN_INCOME"].ToString();
            txt_R5_Expense.Text =  dss.Tables[0].Rows[0]["GEN_EXPENSE"].ToString();
            ddl_R5_CostCenter.SelectedValue =  dss.Tables[0].Rows[0]["GEN_COST_CENTER"].ToString();

  
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
      
        }
    }


    private DataSet Save_Update(string Flag)
    {
        DataSet ds = new DataSet();
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = txtcode.Text.Trim();
        ObjUBO.A3 = txtName.Text.Trim();
        ObjUBO.A4 = hdApplicableFor.Value.ToString();
        ObjUBO.A5 = ddl_charge_category.SelectedValue.ToString();
        ObjUBO.A6 = ddl_charge_type.SelectedValue.ToString();
        ObjUBO.A7 = ddl_IATA_code.SelectedValue.ToString();
        ObjUBO.A8 = chkServiceTax.Checked ? "Y" : "N";
        ObjUBO.A9 = ddl_ServiceTax_Category.SelectedValue.ToString();
        ObjUBO.A10 = chkVAT.Checked ? "Y" : "N";
        ObjUBO.A11 = ddl_VAT_Category.SelectedValue.ToString();
        ObjUBO.A12 = chkGST.Checked ? "Y" : "N";
        ObjUBO.A13 = ddl_GST_SacHsn.SelectedValue.ToString();
        ObjUBO.A14 = txt_HSN_SAC_Code.Text.Trim();      
        ObjUBO.A15 = txt_GST_Category.Text.Trim(); 
        ObjUBO.A16 = ddl_GST_SubCategory.SelectedValue.ToString();
        ObjUBO.A17 = txt_GST_Taxable.Text.Trim();
        ObjUBO.A18 = chkGST_Override.Checked ? "Y" : "N";
        ObjUBO.A19 = txt_R1_Income.Text.Trim();
        ObjUBO.A20 = txt_R1_Expense.Text.Trim();
        ObjUBO.A21 = ddl_R1_CostCenter.SelectedValue.ToString();
        ObjUBO.A22 = txt_R2_Income.Text.Trim();
        ObjUBO.A23 = txt_R2_Expense.Text.Trim();
        ObjUBO.A24 = ddl_R2_CostCenter.SelectedValue.ToString();
        ObjUBO.A25 = txt_R3_Income.Text.Trim();
        ObjUBO.A26 = txt_R3_Expense.Text.Trim();
        ObjUBO.A27 = ddl_R3_CostCenter.SelectedValue.ToString();
        ObjUBO.A28 = txt_R4_Income.Text.Trim();
        ObjUBO.A29 = txt_R4_Expense.Text.Trim();
        ObjUBO.A30 = ddl_R4_CostCenter.SelectedValue.ToString();
        ObjUBO.A31 = txt_R5_Income.Text.Trim();
        ObjUBO.A32 = txt_R5_Expense.Text.Trim();
        ObjUBO.A33 = ddl_R5_CostCenter.SelectedValue.ToString();
        ObjUBO.A34 = Flag;
        ds = CI.Charge_Master_Ins_Upd(ObjUBO);
        return ds;
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Validate_Fields()) return;
        try
        {
            DataSet ds = Save_Update("S");
            if (ds == null || ds.Tables.Count == 0)
            {
                Alert_msg("Not Saved. Please try again.");
                return;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                string chrg_id = string.Empty;

                chrg_id = ds.Tables[0].Rows[0]["CHRG_ID"].ToString();

                Er_Msg(chrg_id, ds.Tables[0].Rows[0]["ERR_MSG"].ToString());

                user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                PAGE_MODIFY = user_Create.PAGE_MODIFY;
                if (PAGE_MODIFY == "False")
                {
                    btnNew_Click1(sender, e);
                }
                else
                {
                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                }

                HDupdate_id.Value = chrg_id;
                HD_Showcon.Value = "SAVED";
                F.Visible = false;
                T.Visible = true;

                ViewState["UPDATED_ID"] = chrg_id;

                Alert_msg("Saved Successfully", btnSave.ClientID);
            }
            else
            {
                Alert_msg("Not Saved. Please try again.");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (!Validate_Fields()) return;
        try
        {
            DataSet ds = Save_Update("U");
            if (ds == null || ds.Tables.Count == 0)
            {
                Alert_msg("Not Updated. Please try again.");
                return;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                string chrg_id = string.Empty;
                chrg_id = ds.Tables[0].Rows[0]["CHRG_ID"].ToString();

                Er_Msg(chrg_id, ds.Tables[0].Rows[0]["ERR_MSG"].ToString());

                if (ViewState["UPDATED_ID"] != null)
                    Alert_msg("Updated Successfully", btnUpdate.ClientID);
                else
                {
                    Alert_msg("Saved Successfully", btnUpdate.ClientID);
                    HD_Showcon.Value = "SAVED";
                }
                ViewState["UPDATED_ID"] = chrg_id;
            }
            else
            {
                Alert_msg("Not Updated. Please try again.");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Er_Msg(string chrg_id, string err_msg)
    {
        if (chrg_id == "-1")
        {
            string dupMsg = string.IsNullOrEmpty(err_msg) ? "Charge Code " + txtcode.Text.Trim().ToUpper() + " with this Category already exists in another record."
                : err_msg.Replace("'", "");

            Alert_msg(dupMsg, txtcode.ClientID);
            return;
        }

        if (chrg_id == "-2")
        {
            string dupMsg = string.IsNullOrEmpty(err_msg)
                ? "Charge Name " + txtName.Text.Trim().ToUpper() + " with this Category already exists. Please use a different Name or Category."
                : err_msg.Replace("'", "");
            Alert_msg(dupMsg, txtName.ClientID);
            return;
        }
        if (chrg_id == "0")
        {
            Alert_msg("Record not found. Please try again.");
            return;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = Save_Update("D");

            if (ds.Tables[0].Rows.Count == 0)
            {
                btnNew_Click1(sender, e);
                Alert_msg("Deleted Successfully");
            }
            else
            {
                Alert_msg("Not Deleted. Record may be in use.");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private string Generate_Next_Charge_Code()
    {
        string nextCode = "CM0001";

        try
        {
            DataSet ds = new DataSet();
            ObjUBO.A9 = "Get_Max_Code";
            ds = CI.Charge_Master_Select(ObjUBO);

            if (ds != null && ds.Tables.Count > 0 &&
                ds.Tables[0].Rows.Count > 0 &&
                ds.Tables[0].Rows[0]["MAX_CODE"] != DBNull.Value)
            {
                string maxCode = ds.Tables[0].Rows[0]["MAX_CODE"].ToString();

                if (!string.IsNullOrEmpty(maxCode) && maxCode.Length > 2)
                {
                    string numericPart = maxCode.Substring(2); 
                    int nextNumber;

                    if (int.TryParse(numericPart, out nextNumber))
                    {
                        nextNumber = nextNumber + 1;
                        nextCode = "CM" + nextNumber.ToString().PadLeft(4, '0');
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return nextCode;
    }

    protected void btnNew_Click1(object sender, EventArgs e)
    {
        btnUpdate.CssClass = "updates";
        ViewState["PARTY_ID"] = null;
        ViewState["UPDATED_ID"] = null;

        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;

        txtName.ReadOnly = false;
        txtName.Style.Remove("background-color");
        txtName.Style.Remove("color");
        txtName.Style.Remove("cursor");
        ddl_charge_category.Enabled = true;

        HDupdate_id.Value = string.Empty;
        Clear_Fields();

        txtcode.Text = Generate_Next_Charge_Code();
    }
    private void Clear_Fields()
    {
        txtcode.Text = string.Empty;
        txtName.Text = string.Empty;

        foreach (ListItem item in chkApplicableFor.Items)
        {
            item.Selected = false;
        }
        hdApplicableFor.Value = string.Empty;

        ddl_charge_category.SelectedIndex = 0;
        ddl_charge_type.SelectedIndex = 0;
        ddl_IATA_code.SelectedIndex = 0;

        chkServiceTax.Checked = false;
        ddl_ServiceTax_Category.SelectedIndex = 0;

        chkVAT.Checked = false;
        ddl_VAT_Category.SelectedIndex = 0;

        chkGST.Checked = false;
        ddl_GST_SacHsn.SelectedIndex = 0;
        txt_HSN_SAC_Code.Text = string.Empty;
        txt_GST_Category.Text = string.Empty;
        ddl_GST_SubCategory.SelectedIndex = 0;
        txt_GST_Taxable.Text = string.Empty;
        chkGST_Override.Checked = false;
        txt_R1_Income.Text = string.Empty;
        txt_R1_Expense.Text = string.Empty;
        ddl_R1_CostCenter.SelectedIndex = 0;

        txt_R2_Income.Text = string.Empty;
        txt_R2_Expense.Text = string.Empty;
        ddl_R2_CostCenter.SelectedIndex = 0;

        txt_R3_Income.Text = string.Empty;
        txt_R3_Expense.Text = string.Empty;
        ddl_R3_CostCenter.SelectedIndex = 0;

        txt_R4_Income.Text = string.Empty;
        txt_R4_Expense.Text = string.Empty;
        ddl_R4_CostCenter.SelectedIndex = 0;

        txt_R5_Income.Text = string.Empty;
        txt_R5_Expense.Text = string.Empty;
        ddl_R5_CostCenter.SelectedIndex = 0;
    }

    private bool Validate_Fields()
    {
        var validations = new[]
            {
                new { IsInvalid = string.IsNullOrWhiteSpace(txtcode.Text), Msg = "Enter Charge Code !", ClientID = txtcode.ClientID },
                new { IsInvalid = string.IsNullOrWhiteSpace(txtName.Text), Msg = "Enter Charge Name !", ClientID = txtName.ClientID },
                new { IsInvalid = ddl_charge_category.SelectedValue == string.Empty, Msg = "Select Charge Category !", ClientID = ddl_charge_category.ClientID },
                new { IsInvalid = ddl_charge_type.SelectedValue == string.Empty, Msg = "Select Charge Type !", ClientID = ddl_charge_type.ClientID }
            };

        foreach (var v in validations)
        {
            if (v.IsInvalid)
            {
                Alert_msg(v.Msg, v.ClientID);
                return false;
            }
        }
        return true;
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CHARGE MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CHARGE MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

}













