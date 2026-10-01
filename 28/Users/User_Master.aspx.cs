using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text; 


public partial class User_Master : ThemeClass
{
    AppSession aps = new AppSession();

    DataSet dtuser = new DataSet();
    DataSet dtcomp = new DataSet();

    Transaction trans = new Transaction();
    Company_Master Comp = new Company_Master();
    User_Creation User = new User_Creation();
   
    public int i;


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            if (Session["COMPANY_ID"] != null)
            {
                txtCompany_License.Text = Session["COMPANY_LICENSE"].ToString();
                txtClient_Name.Text = Session["CLIENT_NAME"].ToString();
               
                int No_Of_Users=Convert.ToInt32(Session["NO_OF_USERS"].ToString())-1;
                txt_No_Of_Users.Text = Convert.ToString(No_Of_Users);
            }
          
            txt_No_Of_Users.Attributes.Add("readonly", "readonly");
            txtCompany_License.Attributes.Add("readonly", "readonly");
            txtClient_Name.Attributes.Add("readonly", "readonly");
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            Comp_Lic();
            if (Request.QueryString["Page"] == "New")
            {
                if (Session["COMPANY_ID"] != null)
                {
                    Session.Remove("USER_CREATION_ID_EDIT");
                    hdn_Company_ID.Value = Session["COMPANY_ID"].ToString();
                }
            }
            Edit_User_Details();
        }                     
    }
    
     private void Comp_Lic()
     {
         DataTable dt = new DataTable();
         Comp.COMPANY_LICENSE = txtCompany_License.Text;
         //Comp.Ename = "Imp_Exp_Lic";
         Comp.Ename = "CHA_ADMIN_MENU";
         dt = Comp.RetrieveAll_Company_Details_datatable();
         if (dt.Rows.Count > 0)
         {
             for (i = 0; i < dt.Rows.Count; i++)
             {
                 if (dt.Rows[i]["MENU_ID"].ToString() == "I")
                 {
                     Chk_Imp_L.Checked = true;
                     I_Chk.Visible = true;
                 }
                 else if (dt.Rows[i]["MENU_ID"].ToString() == "E")
                 {
                     Chk_Exp_L.Checked = true;
                     E_Chk.Visible = true;
                 }
                 else if (dt.Rows[i]["MENU_ID"].ToString() == "B")
                 {
                     Chk_Billing_L.Checked = true;
                     B_Chk.Visible = true;
                 }
                 else if (dt.Rows[i]["MENU_ID"].ToString() == "A")
                 {
                     Chk_Acc_L.Checked = true;
                     A_Chk.Visible = true;
                 }
                 else if (dt.Rows[0]["MENU_ID"].ToString() == "IZ")
                 {
                     Chk_IZ_L.Checked = true;
                     IZ_Chk.Visible = true;
                 }
                 else if (dt.Rows[0]["MENU_ID"].ToString() == "EZ")
                 {
                     Chk_EZ_L.Checked = true;
                     EZ_Chk.Visible = true;
                 }
                 
             }


         }
     }
    
    public void Edit_User_Details()
    {
        if (Request.QueryString["COMPANY_ID"] != "" && Request.QueryString["COMPANY_ID"] != null)
        {
            int i = 0;
            hdn_Company_ID.Value = Request.QueryString["COMPANY_ID"].ToString();
            hdn_User_Creation_Id.Value = Request.QueryString["USER_CREATION_ID"].ToString();
            User.USER_CREATION_ID = "0";
            if (hdn_Company_ID.Value == "")
            {
                hdn_Company_ID.Value = "0";
            }
            Insert_Update("select_SYSADMIN");

            lbl_total_Users.Text = Convert.ToString(User.USER_COUNT - 1);
            if (dtcomp.Tables[0].Rows.Count > 0)
            {
                Session.Remove("COMPANY_ID");
               
                Session["COMPANY_ID"] = dtcomp.Tables[0].Rows[0]["COMPANY_ID"].ToString();
                Session.Remove("USER_CREATION_ID_EDIT");
                Session["USER_CREATION_ID_EDIT"] = dtcomp.Tables[0].Rows[0]["USER_CREATION_ID"].ToString();
                txtUser_Name.Text = dtcomp.Tables[0].Rows[0]["USER_NAME"].ToString();
                Session["USER_NAME"] = txtUser_Name.Text;
                lblUName.Text = dtcomp.Tables[0].Rows[0]["USER_NAME"].ToString();
                txtPassword.Text = dtcomp.Tables[0].Rows[0]["PWD"].ToString();
                txtName.Text = dtcomp.Tables[0].Rows[0]["NAME"].ToString();
                lblName.Text = dtcomp.Tables[0].Rows[0]["NAME"].ToString();
                txtEmployee_ID.Text = dtcomp.Tables[0].Rows[0]["EMPLOYEE_ID"].ToString();
                lblEmpid.Text = dtcomp.Tables[0].Rows[0]["NAME"].ToString();

                txtEMail_ID.Text = dtcomp.Tables[0].Rows[0]["EMAIL_ID"].ToString();
                txtMobile_No.Text = dtcomp.Tables[0].Rows[0]["MOBILE_NO"].ToString();

                if (dtcomp.Tables[0].Rows[0]["IMPORT"].ToString() == "Y")
                {
                    Chk_Imp.Checked = true;
                }
                if (dtcomp.Tables[0].Rows[0]["EXPORT"].ToString() == "Y")
                {
                    Chk_Exp.Checked = true;
                }
                if (dtcomp.Tables[0].Rows[0]["BILLING"].ToString() == "Y")
                {
                    Chk_Billing.Checked = true;
                }
                if (dtcomp.Tables[0].Rows[0]["ACCOUNTS"].ToString() == "Y")
                {
                    Chk_Acc.Checked = true;
                }

                if (dtcomp.Tables[0].Rows[0]["IMP_SEZ"].ToString() == "Y")
                {
                    Chk_Imp_Sez.Checked = true;
                }
                if (dtcomp.Tables[0].Rows[0]["EXP_SEZ"].ToString() == "Y")
                {
                    Chk_Exp_Sez.Checked = true;
                }

                string type = dtcomp.Tables[0].Rows[0]["TYPE"].ToString();
                string Status = dtcomp.Tables[0].Rows[0]["USER_STATUS"].ToString();

                string Subscribe = dtcomp.Tables[0].Rows[0]["SUBSCRIBE"].ToString();

                if (Subscribe == "Yes")
                {
                    rdoSubscribe.SelectedIndex = 0;
                }
                else
                {
                    rdoSubscribe.SelectedIndex = 1;
                }

                string Within_Network = dtcomp.Tables[0].Rows[0]["WITHIN_NETWORK"].ToString();

                if (Within_Network == "Yes")
                {
                    rdoWithin_Network.SelectedIndex = 0;
                }
                else
                {
                    rdoWithin_Network.SelectedIndex = 1;
                }

                if (type == "S")
                {
                    if (Status == "True")
                    {
                        rdoStatus.SelectedIndex = 0;
                    }
                    else
                    {
                        rdoStatus.SelectedIndex = 1;
                    }
                    rdoStatus.Enabled = false;

                    txtUser_Name.Enabled = false;
                    txtPassword.Enabled = false;
                    btnDelete.Visible = false;
                }
                else
                {
                    btnDelete.Visible = true;
                    rdoStatus.Enabled = true;

                    txtUser_Name.Enabled = true;
                    txtPassword.Enabled = true;
                    if (Status == "True")
                    {
                        rdoStatus.SelectedIndex = 0;
                    }
                    else
                    {
                        rdoStatus.SelectedIndex = 1;
                    }
                }
                HiddenField1.Value = dtcomp.Tables[0].Rows[0]["USER_CREATION_ID"].ToString();
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = HiddenField1.Value;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                Branch_Page.Style.Add("display", "block");
                Permission_Page.Style.Add("display", "block");
                CHA_Module_Page.Style.Add("display", "block");
            }
        }
        else
        {
            Branch_Page.Style.Add("display", "none");
            Permission_Page.Style.Add("display", "none");
            CHA_Module_Page.Style.Add("display", "none");
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
         }
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            trans.ResetFields(Page.Controls);
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            ViewState["UPDATED_ID"] = null;
            if (Session["COMPANY_ID"] != null)
            {
                txtCompany_License.Text = Session["COMPANY_LICENSE"].ToString();
                txtClient_Name.Text = Session["CLIENT_NAME"].ToString();

                int No_Of_User_Nw = Convert.ToInt32(Session["NO_OF_USERS"].ToString()) - 1;

                txt_No_Of_Users.Text = Convert.ToString(No_Of_User_Nw);
            }
            lblUName.Text = "";
            lblName.Text = "";
            lblEmpid.Text = "";
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
         try
        {
        string flag = "S";
        
        Insert_Update(flag);
        HiddenField1.Value = Convert.ToString(User.Update_Id);
       
        if (i == 1)
        {
            Branch_Page.Style.Add("display", "block");
            Permission_Page.Style.Add("display", "block");
            CHA_Module_Page.Style.Add("display", "block");

            btnUpdate.CssClass = "save";
            btnUpdate.Visible = true;
            btnSave.Visible = false;

            btnSave.Focus();

            Session["USER_CREATION_ID_EDIT"] = HttpContext.Current.Session["USER_CREATION_ID"].ToString();
            Session.Remove("USER_CREATION_ID_NEW");
            Session["USER_CREATION_ID_NEW"] = HttpContext.Current.Session["USER_CREATION_ID"].ToString();

            ViewState["UPDATED_ID"] = null;
            Alert_msg("Saved Successfully", "btnSave");
           
        }
        else if (i == 2)
        {
               Alert_msg("User Already Exist!", "btnSave");

        }
        else if (i == 4)
        {
            Alert_msg("User creation limit exceed. To Create users contact admin!", "btnSave");
        }
        else
        {
              Alert_msg("Not Saved", "btnSave");
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
        string flag = "U";
        Insert_Update(flag);
        if (i == 2)
        {
            if (ViewState["UPDATED_ID"] != null)
            {
                Session["USER_CREATION_ID_EDIT"] = User.USER_CREATION_ID;
                Alert_msg("Updated Successfully", "btnUpdate");
            }
            else
            {
                Alert_msg("Saved Successfully", "btnUpdate");
            }
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

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Insert_Update("Delete");
          
            int ii = 0;
            ii = User.result;

            if (ii == 3)
            {
                   btnNew_Click(sender, e);
                Alert_msg("Deleted");

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

    public int Insert_Update(string Flag)
    {
        try
        {
            if (hdn_Company_ID.Value == "")
            {
                hdn_Company_ID.Value = "0";
            }
            User.USER_CREATION_ID = hdn_User_Creation_Id.Value;
            User.COMPANY_ID = hdn_Company_ID.Value;
            User.CLIENT_NAME = txtClient_Name.Text;
            User.NAME = txtName.Text;
            User.USER_NAME = txtUser_Name.Text.Trim();
            User.PWD = txtPassword.Text.Trim();
            User.EMAIL_ID = txtEMail_ID.Text;
            User.MOBILE_NO = txtMobile_No.Text.Trim();
            User.EMPLOYEE_ID = txtEmployee_ID.Text;
            User.Import = Chk_Imp.Checked ? "Y" : "N";
            User.Export = Chk_Exp.Checked ? "Y" : "N";
            User.Billing = Chk_Billing.Checked ? "Y" : "N";
            User.Acc = Chk_Acc.Checked ? "Y" : "N";
            User.Imp_Sez = Chk_Imp_Sez.Checked ? "Y" : "N";
            User.Exp_Sez = Chk_Exp_Sez.Checked ? "Y" : "N";

            User.TYPE = "U";
            User.ADMIN_ID = "";
            User.flag = Flag;

            if (Flag == "select_SYSADMIN")
            {
                User.USER_STATUS = "0";
                dtcomp = User.User_Creation_Insert_update(HttpContext.Current.Session["currentcomp_db"].ToString());
            }
            else
            {
                User.SUBSCRIBE = rdoSubscribe.SelectedItem.ToString();
                User.WITHIN_NETWORK = rdoWithin_Network.SelectedItem.ToString();
               
                string Active = rdoStatus.SelectedItem.ToString();
                if (Active == "Active")
                    Active = "1";
                else
                {
                    Active = "0";
                }
                User.USER_STATUS = Active;
                User.User_Creation_Insert_update(HttpContext.Current.Session["currentcomp_db"].ToString());
            }
            i = User.result;
            lbl_total_Users.Text = Convert.ToString(User.USER_COUNT - 1);
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
         return i;
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'USER LOGIN', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'USER LOGIN', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

}