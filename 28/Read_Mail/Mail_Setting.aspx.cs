using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;


public partial class Mail_Setting : ThemeClass
{

    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
   
    public int i, Update_Id;
    public string AUTO_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    public string MAIL_SETTING_ID="";
    public int Screen_Id;
    DataSet ds = new DataSet();
    Maildb mdb = new Maildb();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        ddltype.Focus();
        if (!IsPostBack)
        {
            EditSupDetails();
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

    public void EditSupDetails()
    {
        if (Request.QueryString["MAIL_SETTING_ID"] != "" && Request.QueryString["MAIL_SETTING_ID"] != null)
        {
            int i = 0;
            MAIL_SETTING_ID = Request.QueryString["MAIL_SETTING_ID"];
            mdb.MAIL_SETTING_ID = MAIL_SETTING_ID;
            mdb.Name = "0";
            mdb.Ename = "select_conwithcode";
            ds = mdb.Retrieve_Mailsetting_Details();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddltype.SelectedValue = ds.Tables[0].Rows[0]["SERVER_TYPE"].ToString();
                txthost_name.Text = ds.Tables[0].Rows[0]["HOST_NAME"].ToString();
                txt_username.Text = ds.Tables[0].Rows[0]["USER_NAME"].ToString();
                txt_pwd.Text = ds.Tables[0].Rows[0]["PWD"].ToString();
                txt_Folder.Text = ds.Tables[0].Rows[0]["FOLDER"].ToString();
                txt_port.Text = ds.Tables[0].Rows[0]["PORT"].ToString();
                string ENABLE_SSL = ds.Tables[0].Rows[0]["ENABLE_SSL"].ToString();
                txt_Tenantid.Text = ds.Tables[0].Rows[0]["TENANT_ID"].ToString();
                txt_Clientid.Text = ds.Tables[0].Rows[0]["CLIENT_ID"].ToString();
                txt_ClientSecid.Text = ds.Tables[0].Rows[0]["CLIENT_SEC_ID"].ToString();
                if (ENABLE_SSL == "True")
                {
                    rdoEnable_Ssl.SelectedIndex = 0;
                }
                else
                {
                    rdoEnable_Ssl.SelectedIndex = 1;
                }
                hdn_Update_mailid.Value = txt_username.Text;
            }
            HiddenField1.Value = Request.QueryString["MAIL_SETTING_ID"].ToString();
            
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = Request.QueryString["MAIL_SETTING_ID"].ToString();

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

            Search_Insert_Update_Delete_Newmail("S","");

            HiddenField1.Value = Convert.ToString(mdb.Update_Id);

            if (mdb.result == 1)
            {

                ViewState["UPDATED_ID"] = null;
                Alert_msg("Saved Successfully", "btnSave");
            }
            else if (mdb.result == 2)
            {
                Alert_msg("Mail Id already exixts!", "btnSave");

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
            Search_Insert_Update_Delete_Newmail("U", HiddenField1.Value);
            

            if (mdb.result == 1)
            {
                hdn_Update_mailid.Value = txt_username.Text;
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");

                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");

                }
            }
            else if (mdb.result == 2)
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


    public DataSet Search_Insert_Update_Delete_Newmail(string flag,string a1)
    {
        mdb.MAIL_SETTING_ID = a1;
        mdb.COMPANY_ID = Session["COMPANY_ID"].ToString();
        mdb.CUSTOM_HOUSE = Session["CUSTOMHOUSE_CODE"].ToString();
        mdb.USER_CREATION_ID = Session["USER_CREATION_ID"].ToString();
        
        mdb.SERVERTYPE = ddltype.SelectedItem.Text;
        
        mdb.HOSTNAME = txthost_name.Text;

        mdb.USER_NAME = txt_username.Text;
        mdb.PWD = txt_pwd.Text;
        mdb.FOLDER = txt_Folder.Text;
        mdb.PORT = txt_port.Text;

        if (rdoEnable_Ssl.SelectedIndex == 0)
        {
            mdb.ENABLE_SSL = "True";
        }
        else if (rdoEnable_Ssl.SelectedIndex == 1)
        {
            mdb.ENABLE_SSL = "False";
        }
        else
        {
            mdb.ENABLE_SSL = "";
        }
        mdb.Ename = flag;
        mdb.Tenantid = txt_Tenantid.Text;
        mdb.Clientid = txt_Clientid.Text;
        mdb.Clientsecid = txt_ClientSecid.Text;


        ds = mdb.MailSettting_INSERT_UPDATE_SEARCH_New();
        
        return ds;
    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'MAIL SETTING', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'MAIL SETTING', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
  

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            mdb.MAIL_SETTING_ID = HiddenField1.Value;
            mdb.Name = "0";
            mdb.Ename = "delete";
            mdb.Retrieve_Mailsetting_Details();
            int i = mdb.result;


            if (mdb.result == 1)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Mail Setting is Deleted', 'MAIL SETTING', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
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
  

    protected void txt_username_TextChanged(object sender, EventArgs e)
    {
        if (hdn_Update_mailid.Value != txt_username.Text)
        {
            try
            {
                mdb.MAIL_SETTING_ID = "0";
                mdb.Name = txt_username.Text;

                mdb.Ename = "Check_Mail_Id";
                

                ds = mdb.Retrieve_Mailsetting_Details();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Alert_msg("Mail already exists!", "txt_pwd");
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
        txt_pwd.Focus();
       
    }
}