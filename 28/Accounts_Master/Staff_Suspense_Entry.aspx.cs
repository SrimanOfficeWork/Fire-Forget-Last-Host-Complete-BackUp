using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Staff_Suspense_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
    Global_variables ObjUBO = new Global_variables();

    Staff_Suspense_cs SS = new Staff_Suspense_cs();
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();

    public int i, Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            txtSusp_id.Attributes.Add("readonly", "readonly");
            txtSusp_id.Style.Add("background-color", "#F0F0F0");
           //Load_idType();
            EditSupDetails();
        }
    }
    
    public void EditSupDetails()
    {
        DataSet ds = new DataSet();
        if (Request.QueryString["SUSP_ID"] != "" && Request.QueryString["SUSP_ID"] != null)
        {
            ObjUBO.A1 = Request.QueryString["SUSP_ID"].ToString();
            ObjUBO.A15 = "Susp_Data_Select";
            ds = SS.Staff_Suspense_Data(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlWorkingPeriod.Items.Clear();
                hdn_Updated_Id.Value = ds.Tables[0].Rows[0]["SUSP_ID"].ToString();
                txtSusp_id.Text = ds.Tables[0].Rows[0]["SUSP_NO"].ToString();
                ddlStaffName.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["STAFF_NAME"].ToString(), ds.Tables[0].Rows[0]["STAFF_CODE"].ToString()));
                ddlStaffName.SelectedIndex = 0;
                txtgivDate.Text = ds.Tables[0].Rows[0]["SUSP_GIVEN_DATE"].ToString();
                txt_Desc.Text = ds.Tables[0].Rows[0]["SUSP_DESCRIPTION"].ToString();
                txt_amount.Text = ds.Tables[0].Rows[0]["SUSP_AMOUNT"].ToString();
                txtremarks.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();

                ddlWorkingPeriod.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["SUSP_WORKINGPERIOD"].ToString(), ds.Tables[0].Rows[0]["SUSP_WORKINGPERIOD"].ToString()));
                ddlWorkingPeriod.SelectedIndex = 0;

                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["SUSP_ID"].ToString();

                txtSusp_id.Attributes.Add("readonly", "readonly");
                txtSusp_id.Style.Add("background-color", "#F0F0F0");

                ddlStaffName.Attributes.Add("readonly", "readonly");
                ddlStaffName.Style.Add("background-color", "#F0F0F0");

            }
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
        }
        else
        {
            GetAutono_Susp_Id();
            Load_Staff_Name();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }
    }
    private void GetAutono_Susp_Id()
    {
        DataSet ds = new DataSet();
        ObjUBO.A15 = "Staff_Susp_Id";
        ds = SS.Staff_Suspense_Data(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtSusp_id.Text = ds.Tables[0].Rows[0][0].ToString();
        }
    }
    private void Load_Staff_Name()
    {
        ObjUBO.A15 = "Staff_Name";
        ds = SS.Staff_Suspense_Data(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlStaffName.DataSource = ds.Tables[0];
            ddlStaffName.DataTextField = "STAFF_NAME";
            ddlStaffName.DataValueField = "STAFF_CODE";
            ddlStaffName.DataBind();
        }
        ddlStaffName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlStaffName.SelectedIndex = 0;
    }
    public void Clear()
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        string name = Session["WorkingPeriod"].ToString();
        ddlWorkingPeriod.SelectedValue = name;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {       
        try
        {
            if (ddlStaffName.SelectedValue.ToString() != string.Empty)
            {
                if (txt_amount.Text != string.Empty)
                {
                    if (txtgivDate.Text != string.Empty)
                    {
                        ds = insert_update("S");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            hdn_Updated_Id.Value = ds.Tables[0].Rows[0]["SUSP_ID"].ToString();
                             btnUpdate.CssClass = "save";
                             btnUpdate.Visible = true;
                             btnSave.Visible = false;
                             btnSave.Focus();
                             ViewState["UPDATED_ID"] = null;
                             Alert_msg("Suspense Entry Saved Successfully", "btnSave");
                        }
                        else
                        {
                            Alert_msg("Suspense Not Saved", "btnSave");
                        }

                    }
                    else
                    {
                        Alert_msg("Enter Ur Suspense Given Date", "txtgivDate");
                    }
                }
                else
                {
                    Alert_msg("Enter Ur Suspense Amount", "txt_amount");
                }
            }
            else
            {
                Alert_msg("Select Ur Staff Name", "ddlStaffName");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet insert_update(string flg)
    {
        ObjUBO.A1 = hdn_Updated_Id.Value.ToString();
        ObjUBO.A2 = txtSusp_id.Text;
        ObjUBO.A3 = ddlStaffName.SelectedValue.ToString();
        ObjUBO.A4 = ddlStaffName.SelectedItem.ToString();
        ObjUBO.A5 = txtgivDate.Text;
        ObjUBO.A6 = txt_Desc.Text;
        ObjUBO.A7 = txt_amount.Text;
        ObjUBO.A8 = txtremarks.Text;
        ObjUBO.A9 = ddlWorkingPeriod.SelectedValue.ToString();
        ObjUBO.A24 = flg;
        ds = SS.Suspense_Entry_Ins_Upd(ObjUBO);
        return ds;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            ds = insert_update("U");
            if (ds.Tables[0].Rows.Count > 0)
            {
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
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;
                Alert_msg("Not Saved", "btnUpdate");
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
            DataSet ds = new DataSet();
            ObjUBO.A1 = hdn_Updated_Id.Value.ToString();
            ObjUBO.A15 = "Susp_Delete";
            ds = SS.Staff_Suspense_Data(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Not Deleted", "btnDelete");
            }
            else
            {
                Alert_msg("Deleted Successfully", "btnDelete");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Clear();
        GetAutono_Susp_Id();
        Load_Staff_Name();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        ViewState["UPDATED_ID"] = null;
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Staff Suspense Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Staff Suspense Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
   
}