using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;

public partial class Capital_Account_Master : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
   
    Capital_Account_Master_cs CA = new Capital_Account_Master_cs();
    Global_variables ObjUBO = new Global_variables();
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
   
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int i, Update_Id, Screen_Id;
    public bool chk = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            Edit_ChargeDetails();
           // Load_Opening_Bal();
        }
    }
    /*
    private void Load_Opening_Bal()
    { 
        ObjUBO.A15 = "Opening_Balance_Select";
        ds = CA.Capital_Account_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_Opening_Bal.Text = ds.Tables[0].Rows[0]["OPENING_BALANCE"].ToString();
        }
        else
        {
            txt_Opening_Bal.Text = string.Empty;
        }
    }
    */
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
    public void Edit_ChargeDetails()
    {
        DataSet ds = new DataSet();
        if (Request.QueryString["C_ID"] != "" && Request.QueryString["C_ID"] != null)
        {
            ObjUBO.A1 = Request.QueryString["C_ID"].ToString();
            ObjUBO.A15 = "Update_Data_Select";
            ds = CA.Capital_Account_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value=ds.Tables[0].Rows[0]["C_ID"].ToString();
                txt_Opening_Bal.Text = ds.Tables[0].Rows[0]["OPENING_BALANCE"].ToString();
                txtLedger_Name.Text = ds.Tables[0].Rows[0]["LEDGER"].ToString();
                lbl_Under.Text = ds.Tables[0].Rows[0]["UNDER"].ToString();
                txt_add_1.Text = ds.Tables[0].Rows[0]["ADDRESS_1"].ToString();
                txt_add_2.Text = ds.Tables[0].Rows[0]["ADDRESS_2"].ToString();
                txt_District.Text = ds.Tables[0].Rows[0]["DISTRICT"].ToString();
                ddl_state_name.SelectedValue = ds.Tables[0].Rows[0]["STATE_CODE"].ToString();
                txt_Pin_Code.Text = ds.Tables[0].Rows[0]["PIN_CODE"].ToString();
                txt_PAN_Number.Text = ds.Tables[0].Rows[0]["PAN_NO"].ToString();
                txt_GST_No.Text = ds.Tables[0].Rows[0]["GST_NO"].ToString();
                ViewState["UPDATED_ID"] = ds.Tables[0].Rows[0]["C_ID"].ToString();
            }
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            txt_Opening_Bal.Enabled = false;
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            txt_Opening_Bal.Enabled = true;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ds = insert_update("", "S");
            HDupdate_id.Value = Convert.ToString(CA.UPDATE_ID);

            if (ds.Tables[0].Rows.Count>0)
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
                txt_Opening_Bal.Enabled = false;

                Alert_msg("Saved Successfully", "btnSave");
            }
            else
            {
                Alert_msg("Ledger already exixts!", "btnSave");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public DataSet insert_update(string a1, string a2)
     {
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = txtLedger_Name.Text;
        ObjUBO.A3 = lbl_Under.Text;
        ObjUBO.A4 = txt_add_1.Text;
        ObjUBO.A5 = txt_add_2.Text;
        ObjUBO.A6 = txt_District.Text;
        ObjUBO.A7 = ddl_state_name.SelectedValue.ToString();
        ObjUBO.A8 = txt_Pin_Code.Text;
        ObjUBO.A9 = txt_PAN_Number.Text;
        ObjUBO.A10 = txt_GST_No.Text;
        ObjUBO.A11 = txt_Opening_Bal.Text;
        ObjUBO.A24 = a2;
        return CA.Capital_Account_Ins_Upd(ObjUBO);
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CAPITAL ACCOUNT MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CAPITAL ACCOUNT MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ds = insert_update(HDupdate_id.Value.ToString(), "D");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Deleted Successfully.");
                btnNew_Click(sender, e);
            }
            else
            {
                Alert_msg("Deleted Successfully.");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        HDupdate_id.Value = "";
        txt_Opening_Bal.Text = "";
        txtLedger_Name.Text = "";
        lbl_Under.Text= "";
        txt_add_1.Text= "";
        txt_add_2.Text= "";
        txt_District.Text = "";
        ddl_state_name.SelectedIndex = -1;
        txt_Pin_Code.Text = "";
        txt_PAN_Number.Text = "";
        txt_GST_No.Text = "";

        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        HDupdate_id.Value = "";
        ViewState["UPDATED_ID"] = null;
        txt_Opening_Bal.Enabled = true;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
            try
            {
                ds = insert_update(HDupdate_id.Value.ToString(), "U");
                if (ds.Tables[0].Rows.Count>0)
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
                    Alert_msg("Charge Name already exixts!", "btnUpdate");
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }

    }
}