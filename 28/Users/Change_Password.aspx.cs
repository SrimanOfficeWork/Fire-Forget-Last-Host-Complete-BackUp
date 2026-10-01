
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Web.UI;


public partial class eRoyalMasters_Adcode_Master : ThemeClass
{

    DataSet ds = new DataSet();
    AppSession aps = new AppSession();
    User_Creation User = new User_Creation();
    ErrorLogs er = new ErrorLogs();
    public int i;
   
    protected void Page_Load(object sender, EventArgs e)
    {      
        aps.checkSession();
    }
   
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            User.USER_NAME = Session["currentuser"].ToString().Trim();
            User.PWD = txtconfirmnew_pwd.Text.Trim();
            User.USER_STATUS= hdn_User_Status.Value;
            Insert_Update("Change_Password");

            if (i == 1)
            {
                Session.Remove("currentpassword");
                Session["currentpassword"] = User.PWD;
                lbl_msg.Text = "";
                string prompt = "<script>parent.showChangePasswordSuccess();</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                lbl_msg.Text = "Not Saved";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public int Insert_Update(string Flag)
    {
        try
        {
            //User.USER_CREATION_ID = hdn_User_Creation_Id.Value = Session["USER_CREATION_ID"].ToString();
            User.USER_CREATION_ID = Session["USER_CREATION_ID"].ToString();
            User.COMPANY_ID = Session["COMPANY_ID"].ToString();

            User.ADMIN_ID = "";
            User.flag = Flag;

            User.User_Creation_Insert_update(HttpContext.Current.Session["currentcomp_db"].ToString());

            i = User.result;

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return i;
    }
}