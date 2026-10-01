using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
public partial class IRN_Ice_Gate_Login_Settings : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
    IRN_Automation IA = new IRN_Automation();
    Global_variables ObjUBO = new Global_variables();

    public int i, Update_Id;
    public string AUTO_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    public string ICEGATE_SETTING_ID = "";
    public int Screen_Id;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            EditLoginsettingsDetails();
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Clear();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;

        ViewState["UPDATED_ID"] = null;
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

    public void EditLoginsettingsDetails()
    {
        if (Request.QueryString["ICEGATE_SETTING_ID"] != "" && Request.QueryString["ICEGATE_SETTING_ID"] != null)
        {
            int i = 0;
            ICEGATE_SETTING_ID = Request.QueryString["ICEGATE_SETTING_ID"];
            ObjUBO.A1 = ICEGATE_SETTING_ID;
            ObjUBO.A14 = "select_conwithcode";
            ds = IA.Retrieve_Icegate_Login_setting_Details(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {

                txt_username.Text = ds.Tables[0].Rows[0]["ICEGATE_USER_NAME"].ToString();
                txt_pwd.Text = ds.Tables[0].Rows[0]["ICEGATE_PWD"].ToString();
                api_key.Text = ds.Tables[0].Rows[0]["API_KEY"].ToString();

            }
            HiddenField1.Value = Request.QueryString["ICEGATE_SETTING_ID"].ToString();
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = Request.QueryString["ICEGATE_SETTING_ID"].ToString();
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnNew.Visible = true;
            btnSave.Visible = false;
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = true;
            btnSave.Visible = true;
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Insert_Update_Delete("S", "");
            HiddenField1.Value = Convert.ToString(IA.UPDATE_ID);
            if (IA.result == 1)
            {

                ViewState["UPDATED_ID"] = null;
                Alert_msg("Saved Successfully", "btnSave");
            }
            else if (IA.result == 2)
            {
                Alert_msg("User already exixts!", "btnSave");

            }
            else
            {
                Alert_msg("Not Saved", "btnNew");

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
            Insert_Update_Delete("U", HiddenField1.Value);
            if (IA.result == 1)
            {
                hdn_Update_icegateid.Value = txt_username.Text;
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");

                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");

                }
            }
            else if (IA.result == 2)
            {
                Alert_msg("already exixts!", "btnUpdate");
            }
            else
            {
                Alert_msg("Not Saved", "btnUpdate");
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

    public DataSet Insert_Update_Delete(string flag, string a1)
    {

        ObjUBO.A3 = txt_username.Text;
        ObjUBO.A4 = txt_pwd.Text;
        ObjUBO.A5 = a1;
        ObjUBO.A6 = api_key.Text;
        ObjUBO.A19 = flag;
        ds = IA.Icegate_Login_Settting_Insert_Update(ObjUBO);
        return ds;
    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ICEGATE SETTING', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ICEGATE SETTING', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.A5 = HiddenField1.Value;
            ObjUBO.A19 = "delete";
            IA.Icegate_Login_Settting_Insert_Update(ObjUBO);
            int i = IA.result;
            if (IA.result == 1)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Mail Setting is Deleted', 'ICEGATE SETTING', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }



}