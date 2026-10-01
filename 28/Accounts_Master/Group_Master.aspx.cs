using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;

public partial class Accounts_Master_Group_Master : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();

    Billing_UserBO ObjUBO = new Billing_UserBO();
    Group_Master_cs CH = new Group_Master_cs();

    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int i, Update_Id, Screen_Id;
    public bool chk = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!IsPostBack)
        {
            if (Request.QueryString["Page"] == null || Request.QueryString["Page"] == "")
            {
                LoadLedger();
                btnDelete.Visible=false;
                btnUpdate.Visible = false;
                ddlSubGroup.Enabled = false;
                ddlGroup.Enabled = false;
                ddlReporting.Enabled = false;
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {                    
                    Edit_GroupDetails();
                    ddlSubGroup.Enabled = false;
                    ddlGroup.Enabled = false;
                    ddlReporting.Enabled = false;
                    //txtOpeningBalance.Enabled = false;
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
    public void Edit_GroupDetails()
    {
        DataSet ds = new DataSet();
        if (Request.QueryString["GROUP_ID"] != "" && Request.QueryString["GROUP_ID"] != null)
        {
            ddlLedger.Attributes.Add("readonly", "readonly");

            ObjUBO.ID = Request.QueryString["GROUP_ID"].ToString();
            ObjUBO.Flag = "Update_Data_Select";
            ds = CH.Group_Master_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlLedger.DataSource = ds.Tables[0];
                ddlLedger.DataTextField = "LEDGER_NAME";
                ddlLedger.DataValueField = "LEDGER_NAME";
                ddlLedger.DataBind();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                ddlSubGroup.DataSource = ds.Tables[1];
                ddlSubGroup.DataTextField = "SUB_GROUP_NAME";
                ddlSubGroup.DataValueField = "SUB_GROUP_NAME";
                ddlSubGroup.DataBind();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                ddlGroup.DataSource = ds.Tables[2];
                ddlGroup.DataTextField = "GROUP_NAME";
                ddlGroup.DataValueField = "GROUP_NAME";
                ddlGroup.DataBind();
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                ddlReporting.DataSource = ds.Tables[3];
                ddlReporting.DataTextField = "MAIN_NAME";
                ddlReporting.DataValueField = "MAIN_NAME";
                ddlReporting.DataBind();

            }
            if (ds.Tables[4].Rows.Count > 0)
            {

                ddlLedger.SelectedValue = ds.Tables[4].Rows[0]["LEDGER"].ToString();
                ddlSubGroup.SelectedValue = ds.Tables[4].Rows[0]["Sub_GROUP"].ToString();
                ddlGroup.SelectedValue = ds.Tables[4].Rows[0]["GROUP_NAME"].ToString();
                ddlReporting.SelectedValue = ds.Tables[4].Rows[0]["REPORTING"].ToString();
                txtOpeningBalance.Text = ds.Tables[4].Rows[0]["OPENING_BALANCE"].ToString();
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["GROUP_ID"].ToString();
                //FOR UPDATED SUCCESSFULLY
            }

            HDupdate_id.Value = Request.QueryString["GROUP_ID"].ToString();

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
            if (ddlLedger.SelectedValue.ToString() != string.Empty && ddlSubGroup.SelectedValue.ToString() != string.Empty && ddlGroup.SelectedValue.ToString() != string.Empty && ddlReporting.SelectedValue.ToString() != string.Empty)
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
                    Alert_msg("Group already exists!", "btnSave");
                }
                else
                {
                    Alert_msg("Group Not Saved", "btnNew");
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

    protected void ddlLedger_SelectedIndexChanged(object sender, EventArgs e)
    {        
        if (ddlLedger.SelectedValue.ToString() != string.Empty)
        {
            ddlSubGroup.Enabled = true;
            ddlGroup.Enabled = true;
            ddlReporting.Enabled = true;
            DataSet ds = new DataSet();
            ObjUBO.Flag = "Ledger_Name_Select";
            ObjUBO.LEDGER = ddlLedger.SelectedValue.ToString();
            ds = CH.Group_Master_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSubGroup.DataSource = ds.Tables[0];
                ddlSubGroup.DataTextField = "SUB_GROUP_NAME";
                ddlSubGroup.DataValueField = "SUB_GROUP_NAME";
                ddlSubGroup.DataBind();
            }
            ddlSubGroup.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
            ddlSubGroup.SelectedIndex = 0;
            ddlGroup.ClearSelection();
            ddlReporting.ClearSelection();
            ds.Dispose();
            GC.Collect();
        }

    }

    protected void ddlSubGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubGroup.SelectedValue.ToString() != string.Empty)
        {
            DataSet ds = new DataSet();
            ObjUBO.Flag = "Ledger_Name_Select";
            ObjUBO.LEDGER = ddlLedger.SelectedValue.ToString();
            ObjUBO.SUB_GROUP = ddlSubGroup.SelectedValue.ToString();
            ds = CH.Group_Master_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlGroup.DataSource = ds.Tables[0];
                ddlGroup.DataTextField = "GROUP_NAME";
                ddlGroup.DataValueField = "GROUP_NAME";
                ddlGroup.DataBind();
            }
            ddlGroup.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
            ddlGroup.SelectedIndex = 0;
            ds.Dispose();
            GC.Collect();
        }
     
    }

    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGroup.SelectedValue.ToString() != string.Empty)
        {
            DataSet ds = new DataSet();
            ObjUBO.Flag = "Ledger_Name_Select";
            ObjUBO.LEDGER = ddlLedger.SelectedValue.ToString();
            ObjUBO.SUB_GROUP = ddlSubGroup.SelectedValue.ToString();
            ObjUBO.GROUP_NAME = ddlGroup.SelectedValue.ToString();
            ds = CH.Group_Master_Select(ObjUBO);
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

    private void LoadLedger()
    {
        DataSet ds = new DataSet();
        ObjUBO.Flag = "Ledger_Name_Select";
        ds = CH.Group_Master_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlLedger.DataSource = ds.Tables[0];
            ddlLedger.DataTextField = "LEDGER_NAME";
            ddlLedger.DataValueField = "LEDGER_NAME";
            ddlLedger.DataBind();
        }
        ddlLedger.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        ddlLedger.SelectedIndex = 0;
        ds.Dispose();
        GC.Collect();
    }
    public int insert_update(string a1, string a2)
    {
        ObjUBO.ID = HDupdate_id.Value.ToString();
        ObjUBO.LEDGER = ddlLedger.SelectedValue;
        ObjUBO.SUB_GROUP = ddlSubGroup.SelectedValue;
        ObjUBO.GROUP_NAME = ddlGroup.SelectedValue.ToString();
        ObjUBO.REPORTING = ddlReporting.SelectedValue.ToString();
        ObjUBO.OPENING_BALANCE = txtOpeningBalance.Text.ToString();
        ObjUBO.Flag = a2;
        CH.Group_INS_UPD(ObjUBO);
        i = CH.result;
        return i;
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GROUP MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GROUP MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            i = insert_update(HDupdate_id.Value.ToString(), "D");
            if (i > 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Group Deleted', 'GROUP MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("Group Not Deleted");
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
        ddlSubGroup.Enabled = false;
        ddlGroup.Enabled = false;
        ddlReporting.Enabled = false;
        ddlLedger.Attributes.Remove("readonly");
        ddlLedger.Style.Add("background-color", "white");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlLedger.SelectedValue.ToString() != string.Empty && ddlSubGroup.SelectedValue.ToString() != string.Empty && ddlGroup.SelectedValue.ToString() != string.Empty && ddlReporting.SelectedValue.ToString() != string.Empty)
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
                    Alert_msg("Group Name already exists!", "btnUpdate");
                }
                else
                {
                    Alert_msg("Group Not Saved", "btnUpdate");
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
    protected void  btn_Chsave_Click(object sender, EventArgs e)
    {
        lbl_Msg.Text = string.Empty;
        DataSet ds = new DataSet();
        if (txt_leg.Text != string.Empty)
        {
            ObjUBO.GROUP_NAME = ddlGroup_Name_N.SelectedValue.ToString();
            ObjUBO.SUB_GROUP = ddlSubGroup_N.SelectedValue.ToString();
            ObjUBO.LEDGER = txt_leg.Text;
            ObjUBO.REPORTING = ddl_Rpt_N.SelectedValue.ToString();
            ObjUBO.Flag = "NS";
            ds = CH.Group_INS_UPD(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_Msg.Text = "Saved Successfully.";
            }
            else
            {
                lbl_Msg.Text = "Already exists Not Saved!";
            }
        }
        else
        {
            lbl_Msg.Text = "Enter Ur Ledger Name!";
        }
        MP_JOB.Show();
    }
   
}