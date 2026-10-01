using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;

public partial class Accounts_Master_Bank_Master : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();

    Billing_UserBO ObjUBO = new Billing_UserBO();
    Bank_Master_cs CH = new Bank_Master_cs();

    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int i, Update_Id, Screen_Id;
    public bool chk = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!IsPostBack)
        {
            LoadSubGroup();
            if (Request.QueryString["Page"] == null || Request.QueryString["Page"] == "")
            {
               
                ddlGroup.Enabled = false;
                ddlReporting.Enabled = false;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                   
                    Edit_BankDetails();
                    ddlGroup.Enabled = false;
                    ddlReporting.Enabled = false;
                    txtOpeningBalance.Enabled = false;
                }
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
    public void Edit_BankDetails()
    {
        DataSet ds = new DataSet();
        if (Request.QueryString["BANK_ID"] != "" && Request.QueryString["BANK_ID"] != null)
        {
            ddlName.Attributes.Add("readonly", "readonly");

            ObjUBO.ID = Request.QueryString["BANK_ID"].ToString();
            ObjUBO.Flag = "Update_Data_Select";
            ds = CH.Bank_Master_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSubGroup.DataSource = ds.Tables[0];
                ddlSubGroup.DataTextField = "SUB_GROUP_NAME";
                ddlSubGroup.DataValueField = "SUB_GROUP_NAME";
                ddlSubGroup.DataBind();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                ddlGroup.DataSource = ds.Tables[1];
                ddlGroup.DataTextField = "GROUP_NAME";
                ddlGroup.DataValueField = "GROUP_NAME";
                ddlGroup.DataBind();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                ddlReporting.DataSource = ds.Tables[2];
                ddlReporting.DataTextField = "MAIN_NAME";
                ddlReporting.DataValueField = "MAIN_NAME";
                ddlReporting.DataBind();

            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                ddlName.SelectedValue = ds.Tables[3].Rows[0]["NAME"].ToString();
                dd_Gl_Name.SelectedItem.Text = ds.Tables[3].Rows[0]["G_L_NAME"].ToString();
                Label1.Text = ds.Tables[3].Rows[0]["GL_CODE"].ToString();
                txtOpeningBalance.Text = ds.Tables[3].Rows[0]["OPENING_BALANCE"].ToString();
                ddlSubGroup.SelectedValue = ds.Tables[3].Rows[0]["SUB_GROUP"].ToString();
                ddlGroup.SelectedValue = ds.Tables[3].Rows[0]["GROUP_NAME"].ToString();
                ddlReporting.SelectedValue = ds.Tables[3].Rows[0]["REPORTING"].ToString();
                txtAccountHolderName.Text = ds.Tables[3].Rows[0]["ACCOUNT_HOLDER_NAME"].ToString();
                txtAccountNumber.Text = ds.Tables[3].Rows[0]["ACCOUNT_NUMBER"].ToString();
                txtIFSCode.Text = ds.Tables[3].Rows[0]["IFSCODE"].ToString();
                txtBankName.Text = ds.Tables[3].Rows[0]["BANK_NAME"].ToString();
                txtBranch.Text = ds.Tables[3].Rows[0]["BRANCH"].ToString();
                txtGSTNumber.Text = ds.Tables[3].Rows[0]["GST_NUMBER"].ToString();
                txtAddress1.Text = ds.Tables[3].Rows[0]["ADDRESS1"].ToString();
                txtAddress2.Text = ds.Tables[3].Rows[0]["ADDRESS2"].ToString();
                txtDistrict.Text = ds.Tables[3].Rows[0]["DISTRICT"].ToString();
                ddlState.SelectedValue = ds.Tables[3].Rows[0]["STATE"].ToString();
                txtPincode.Text = ds.Tables[3].Rows[0]["PINCODE"].ToString();
                ddlChequeBooks.SelectedValue = ds.Tables[3].Rows[0]["SET_CHEQUE_BOOKS"].ToString();
                ddlChequePrinting.SelectedValue = ds.Tables[3].Rows[0]["ENABLE_CHEQUE_PRINTING"].ToString();
                ddlEnableAutoReconcilation.SelectedValue = ds.Tables[3].Rows[0]["ENABLE_AUTO_RECONCILATION"].ToString();
                ddlEnableEPayments.SelectedValue = ds.Tables[3].Rows[0]["ENABLE_E_PAYMENTS"].ToString();             

                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["BANK_ID"].ToString();
                //FOR UPDATED SUCCESSFULLY
            }

            HDupdate_id.Value = Request.QueryString["BANK_ID"].ToString();

            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlName.SelectedValue.ToString() != string.Empty && dd_Gl_Name.SelectedValue.ToString() != string.Empty )
            {
                i = insert_update("", "S");
                HDupdate_id.Value = Convert.ToString(CH.UPDATE_ID);

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
                    }
                    //-----------------------FOR USER RIGHTS--------------------------------//
                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnSave");
                }
                else if (i == 2)
                {
                    Alert_msg("Bank Details already exists!", "btnSave");
                }
                else
                {
                    Alert_msg("Bank Details Not Saved", "btnNew");
                }
            }
            else
            {
                Alert_msg("Enter the mandatory fields ", "btnSave");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public int insert_update(string a1, string a2)
    {
        ObjUBO.ID = HDupdate_id.Value.ToString();
        ObjUBO.NAME = ddlName.SelectedValue;
        ObjUBO.OPENING_BALANCE = txtOpeningBalance.Text.ToString();
        ObjUBO.SUB_GROUP = ddlSubGroup.SelectedValue;
        ObjUBO.GROUP_NAME = ddlGroup.SelectedValue.ToString();
        ObjUBO.REPORTING = ddlReporting.SelectedValue.ToString();

        ObjUBO.ACCOUNT_HOLDER_NAME = txtAccountHolderName.Text.ToString();
        ObjUBO.ACCOUNT_NUMBER = txtAccountNumber.Text.ToString();
        ObjUBO.IFSCODE = txtIFSCode.Text.ToString();
        ObjUBO.BankName = txtBankName.Text.ToString();
        ObjUBO.BankBranch = txtBranch.Text.ToString();
        ObjUBO.GST_NUMBER = txtGSTNumber.Text.ToString();
        ObjUBO.BR_ADDRESS1 = txtAddress1.Text.ToString();
        ObjUBO.BR_ADDRESS2 = txtAddress2.Text.ToString();
        ObjUBO.DISTRICT = txtDistrict.Text.ToString();
        ObjUBO.State_Name = ddlState.SelectedValue.ToString();
        ObjUBO.PINCODE = txtPincode.Text.ToString();
        ObjUBO.SET_CHEQUE_BOOKS = ddlChequeBooks.SelectedValue.ToString();
        ObjUBO.ENABLE_CHEQUE_PRINTING = ddlChequePrinting.SelectedValue.ToString();
        ObjUBO.ENABLE_AUTO_RECONCILATION = ddlEnableAutoReconcilation.SelectedValue.ToString();
        ObjUBO.ENABLE_E_PAYMENTS = ddlEnableEPayments.SelectedValue.ToString();
        ObjUBO.Flag = a2;
        ObjUBO.A1 = dd_Gl_Name.SelectedItem.Text;
        ObjUBO.A2 = Label1.Text;
        CH.Bank_INS_UPD(ObjUBO);
        i = CH.result;
        return i;
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BANK MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BANK MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }    

    private void LoadSubGroup()
    {
        DataSet ds = new DataSet();
        ObjUBO.Flag = "Sub_Group_Name_Select";
        ds = CH.Bank_Master_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlSubGroup.DataSource = ds.Tables[0];
            ddlSubGroup.DataTextField = "SUB_GROUP_NAME";
            ddlSubGroup.DataValueField = "SUB_GROUP_NAME";
            ddlSubGroup.DataBind();
        }

        
        ddlSubGroup.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        ddlSubGroup.SelectedIndex = 0;
        if (ds.Tables[1].Rows.Count > 0)
        {
            dd_Gl_Name.DataSource = ds.Tables[1];
            dd_Gl_Name.DataTextField = "NAME";
            dd_Gl_Name.DataValueField = "GROUP_CODE";
            dd_Gl_Name.DataBind();
        }

        dd_Gl_Name.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        dd_Gl_Name.SelectedIndex = 0;
        ds.Dispose();

        GC.Collect();
    }

    protected void ddlSubGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubGroup.SelectedValue.ToString() != string.Empty)
        {
            ddlGroup.Enabled = true;
            ddlReporting.Enabled = true;
            DataSet ds = new DataSet();
            ObjUBO.Flag = "Sub_Group_Name_Select";
            ObjUBO.SUB_GROUP = ddlSubGroup.SelectedValue.ToString();
            ds = CH.Bank_Master_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlGroup.DataSource = ds.Tables[0];
                ddlGroup.DataTextField = "GROUP_NAME";
                ddlGroup.DataValueField = "GROUP_NAME";
                ddlGroup.DataBind();
            }
            ddlGroup.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
            ddlGroup.SelectedIndex = 0;
            ddlGroup.ClearSelection();
            ddlReporting.ClearSelection();
            ds.Dispose();
            GC.Collect();
        }
    }

    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGroup.SelectedValue.ToString() != string.Empty)
        {
            DataSet ds = new DataSet();
            ObjUBO.Flag = "Sub_Group_Name_Select";
            ObjUBO.SUB_GROUP = ddlSubGroup.SelectedValue.ToString();
            ObjUBO.GROUP_NAME = ddlGroup.SelectedValue.ToString();
            ds = CH.Bank_Master_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlReporting.DataSource = ds.Tables[0];
                ddlReporting.DataTextField = "MAIN_NAME";
                ddlReporting.DataValueField = "MAIN_NAME";
                ddlReporting.DataBind();
            }
            ddlReporting.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
            ddlReporting.SelectedIndex = 0;
            ds.Dispose();
            GC.Collect();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            i = insert_update(HDupdate_id.Value.ToString(), "D");
            if (i > 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Bank Details Deleted', 'BANK MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("Bank Details Not Deleted");
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
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        HDupdate_id.Value = "";
        ViewState["UPDATED_ID"] = null;
        txtOpeningBalance.Enabled = true;        
        ddlGroup.Enabled = false;
        ddlReporting.Enabled = false;
        ddlName.Attributes.Remove("readonly");
        ddlName.Style.Add("background-color", "white");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlName.SelectedValue.ToString() != string.Empty && ddlSubGroup.SelectedValue.ToString() != string.Empty && ddlGroup.SelectedValue.ToString() != string.Empty && ddlReporting.SelectedValue.ToString() != string.Empty)
            {
                i = insert_update(HDupdate_id.Value.ToString(), "U");
                if (i == 1)
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
                else if (i == 2)
                {
                    Alert_msg("Bank details already exists!", "btnUpdate");
                }
                else
                {
                    Alert_msg("Bank Details Not Saved", "btnUpdate");
                }
            }
            else
            {
                Alert_msg("Enter the mandatory fields ", "btnUpdate");
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    public void Clear()
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
    }


    protected void dd_Gl_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label1.Text = dd_Gl_Name.SelectedValue;
    }
}