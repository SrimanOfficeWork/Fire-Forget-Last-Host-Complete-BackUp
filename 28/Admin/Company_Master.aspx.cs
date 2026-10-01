using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Company_Master : ThemeClass
{
    DataSet dtuser = new DataSet();
    User_Creation User = new User_Creation();

    AppSession aps = new AppSession();
    Transaction trans = new Transaction();
    Company_Master Comp = new Company_Master();
    Date_Time dt = new Date_Time();
   
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string AUTO_ID, COMPANY_LICENSE;
    public string currentuser;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();

        if (!IsPostBack)
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            if (Request.QueryString["Page"] == "New")
            {
                Auto_License_No();
                Auto_License_No();
                Session.Remove("COMP_LICENSE_NO");
                Session.Remove("COMP_LICENSE");
                Session.Remove("COMP_ID");
                Session.Remove("COMP_STATUS_Id");
                Session.Remove("New_User");
                Session["New_User"]="";
                rdoSelect.SelectedIndex = 2;
                rdoStatusNew.SelectedIndex = 0;
                rdoDefault_Date.SelectedIndex = 1;
                rdoUserwise_Job_Lock.SelectedIndex = 1;
                btn_Db_Creation.Visible = false;
            }
            else
            {
                Session.Remove("New_User");
                Edit_Company_Details();
            }
        }                     
    }

    public void Auto_License_No()
    {
        txtCompany_License.Text = Convert.ToString(Comp.Retrieve_License_No());
        hdn_Company_ID.Value = Convert.ToString(Comp.COMPANY_ID);
    }
    public DataSet gridbind()
    {
        Comp.COMPANY_ID = hdn_Company_ID.Value;
        Comp.COMPANY_LICENSE = COMPANY_LICENSE;
        Comp.CLIENT_NAME = "";
        Comp.CONTACT_PERSON = "";
        Comp.MOBILE_NO = "";
        Comp.Ename = "select_Id";
        dtuser = Comp.RetrieveAll_Company_Details();
        return dtuser;
    }
    public void Edit_Company_Details()
    {
        if (Request.QueryString["COMPANY_ID"] != "" && Request.QueryString["COMPANY_ID"] != null)
        {

            int i = 0;
            hdn_Company_ID.Value = Request.QueryString["COMPANY_ID"].ToString();
            COMPANY_LICENSE = Request.QueryString["COMPANY_LICENSE"].ToString();

            gridbind();

            if (dtuser.Tables[0].Rows.Count > 0)
            {
                txtCompany_License.Text = dtuser.Tables[0].Rows[0]["COMPANY_LICENSE"].ToString();
                Session.Remove("COMP_LICENSE_NO");
                Session.Remove("COMP_LICENSE");
                Session.Remove("COMP_ID");
                Session.Remove("COMP_STATUS_Id");
                Session["COMP_LICENSE_NO"] = txtCompany_License.Text;
                Session["COMP_LICENSE"] = txtCompany_License.Text;
                Session["COMP_ID"] = Request.QueryString["COMPANY_ID"].ToString();
                
                txtClient_Name.Text = dtuser.Tables[0].Rows[0]["CLIENT_NAME"].ToString();
                txtClient_Address.Text = dtuser.Tables[0].Rows[0]["ADDRESS"].ToString();
                txtPhoneNo.Text = dtuser.Tables[0].Rows[0]["PHONE_NO"].ToString();
                txtFax.Text = dtuser.Tables[0].Rows[0]["FAX"].ToString();
                txtEMailID.Text = dtuser.Tables[0].Rows[0]["EMAILID"].ToString();
                txtContact_Person.Text = dtuser.Tables[0].Rows[0]["CONTACT_PERSON"].ToString();
                txtMobileNo.Text = dtuser.Tables[0].Rows[0]["MOBILE_NO"].ToString();
                txtAlternate_No.Text = dtuser.Tables[0].Rows[0]["ALTERNATE_NO"].ToString();
                txtDate_Installation.Text = dtuser.Tables[0].Rows[0]["DATE_OF_INSTALLATION"].ToString().Replace("01/01/1900", "");
                string Purchase = dtuser.Tables[0].Rows[0]["METHOD_OF_PURCHASE"].ToString();
                ddlMethod_Purchase.Items.Clear();
                ddlMethod_Purchase.Items.Add("W");
                ddlMethod_Purchase.Items.Add("R");
                ddlMethod_Purchase.Items.Add("D");
                ddlMethod_Purchase.Items.Add("M");
                ddlMethod_Purchase.Items.Add("WI");
                ddlMethod_Purchase.Items.Add("MI");

                ddlMethod_Purchase.Items.Remove(Purchase);
                ddlMethod_Purchase.Items.Insert(0, Purchase);

                txtNo_Users.Text = dtuser.Tables[0].Rows[0]["NO_OF_USERS"].ToString();
                string Status = dtuser.Tables[0].Rows[0]["COMPANY_STATUS"].ToString();
                Session["COMP_STATUS_Id"] = Status;
                if (Status == "True")
                {
                    rdoStatusNew.SelectedIndex = 0;
                }
                else
                {
                    rdoStatusNew.SelectedIndex = 1;
                }
                txtNext_Renewel_Date.Text = dtuser.Tables[0].Rows[0]["NEXT_RENEWEL_DATE"].ToString().Replace("01/01/1900", "");
                string Select = dtuser.Tables[0].Rows[0]["SELECT_OPTION"].ToString();

                Session["I_E_B"] = Select;
                if (Select == "Import")
                {
                    rdoSelect.SelectedIndex = 0;
                }
                else if(Select == "Export")
                {
                    rdoSelect.SelectedIndex = 1;
                }
                else if (Select == "Both")
                {
                    rdoSelect.SelectedIndex = 2;
                }
                string Default = dtuser.Tables[0].Rows[0]["DEFAULT_DATE"].ToString();
                if (Default == "Yes")
                {
                    rdoDefault_Date.SelectedIndex = 0;
                }
                else 
                {
                    rdoDefault_Date.SelectedIndex = 1;
                }
                txtNetwork_IP.Text = dtuser.Tables[0].Rows[0]["NETWORK_IP"].ToString();
                string user_job_lock = dtuser.Tables[0].Rows[0]["USER_JOB_LOCK"].ToString();

                if (user_job_lock == "Yes")
                {
                    rdoUserwise_Job_Lock.SelectedIndex = 0;
                }
                else
                {
                    rdoUserwise_Job_Lock.SelectedIndex = 1;
                }
                /*
                string bill_status = dtuser.Tables[0].Rows[0]["BILLING_STATUS"].ToString();
                if (bill_status == "Yes")
                {
                    rdoBilling.SelectedIndex = 1;
                }
                else
                {
                    rdoBilling.SelectedIndex = 0;
                }
                 */ 
                //Rd_Acc.SelectedValue = dtuser.Tables[0].Rows[0]["ACCOUNTS"].ToString();
                if (dtuser.Tables[0].Rows[0]["IMPORT"].ToString() == "Y")
                {
                    Chk_Imp.Checked = true;
                }
                if (dtuser.Tables[0].Rows[0]["EXPORT"].ToString() == "Y")
                {
                    Chk_Exp.Checked = true;
                }
                if (dtuser.Tables[0].Rows[0]["BILLING"].ToString() == "Y")
                {
                    Chk_Billing.Checked = true;
                }
                if (dtuser.Tables[0].Rows[0]["ACCOUNTS"].ToString() == "Y")
                {
                    Chk_Acc.Checked = true;
                }
                if (dtuser.Tables[0].Rows[0]["IMP_SEZ"].ToString() == "Y")
                {
                    Chk_Imp_Sez.Checked = true;
                }
                if (dtuser.Tables[0].Rows[0]["EXP_SEZ"].ToString() == "Y")
                {
                    Chk_Exp_Sez.Checked = true;
                }
            }
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = Request.QueryString["COMPANY_ID"].ToString();
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            Login_Page.Style.Add("display","block");
            User_Creation.Style.Add("display", "block");
            Premium_Services.Style.Add("display", "block");
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            Login_Page.Style.Add("display","none");
            User_Creation.Style.Add("display", "none");
            Premium_Services.Style.Add("display", "none");
        }
    }

    public int Company_Details_Insert_Update(string Flag)
    {
        string Active = rdoStatusNew.SelectedItem.ToString();
        if (Active == "Active")
            Active = "1";
        else
            Active = "0";
        Comp.COMPANY_LICENSE = txtCompany_License.Text;
        Comp.CLIENT_NAME = txtClient_Name.Text;
        Comp.ADDRESS = txtClient_Address.Text;
        Comp.PHONE_NO = txtPhoneNo.Text;
        Comp.FAX = txtFax.Text;
        Comp.EMAILID = txtEMailID.Text;
        Comp.CONTACT_PERSON = txtContact_Person.Text;
        Comp.MOBILE_NO = txtMobileNo.Text;
        Comp.ALTERNATE_NO = txtAlternate_No.Text;
        Comp.DATE_OF_INSTALLATION = txtDate_Installation.Text;
        Comp.METHOD_OF_PURCHASE = ddlMethod_Purchase.SelectedValue.ToString();
        Comp.NO_OF_USERS = txtNo_Users.Text;
        Comp.COMPANY_STATUS = Active;
        Comp.NEXT_RENEWEL_DATE = txtNext_Renewel_Date.Text;
        Comp.SELECT_OPTION = rdoSelect.SelectedItem.ToString();
        Comp.DEFAULT_DATE = rdoDefault_Date.SelectedItem.ToString();
        Comp.NETWORK_IP = txtNetwork_IP.Text;
        Comp.USER_JOB_LOCK = rdoUserwise_Job_Lock.SelectedItem.ToString();
        //Comp.BILLING_STATUS = rdoBilling.SelectedItem.ToString();
        //Comp.Acc = Rd_Acc.SelectedValue.ToString();
        Comp.Import = Chk_Imp.Checked ? "Y" : "N";
        Comp.Export = Chk_Exp.Checked ? "Y" : "N";
        Comp.Billing = Chk_Billing.Checked ? "Y" : "N";
        Comp.Acc = Chk_Acc.Checked ? "Y" : "N";

        Comp.Imp_Sez = Chk_Imp_Sez.Checked ? "Y" : "N";
        Comp.Exp_Sez = Chk_Exp_Sez.Checked ? "Y" : "N";

        Comp.USER_ID = currentuser;
        Comp.flag = Flag;

        i = Comp.Company_Master_Insert_update();
        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtCompany_License.Text != "" && txtClient_Name.Text != "")
        {
            try
            {
                string F = "S";
                i = Company_Details_Insert_Update(F);
                if (i == 1)
                {
                    Session["I_E_B"]= rdoSelect.SelectedValue.ToString();  
                    Session["COMP_ID"] = hdn_Company_ID.Value;
                    Session["COMP_LICENSE_NO"] = txtCompany_License.Text; 
                    Session["COMP_LICENSE"] = txtCompany_License.Text;
                    string Active = rdoStatusNew.SelectedValue.ToString();
                    Session["COMP_STATUS_Id"] = Active;
                    txtCompany_License.Focus();
                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnSave.Focus();
                    Login_Page.Style.Add("display", "block");
                    User_Creation.Style.Add("display", "block");

                    ViewState["UPDATED_ID"] = null; 
                    Alert_msg("Saved Successfully", "btnSave");

                    btn_Db_Creation.Visible = true;

                }
                else if (i == 2)
                {
                    Login_Page.Style.Add("display", "none");
                    User_Creation.Style.Add("display", "none");
                    Alert_msg("Job No Already Exist!", "btnSave");
                }
                else
                {
                    Login_Page.Style.Add("display", "none");
                    User_Creation.Style.Add("display", "none");
                    Alert_msg("Job Not Saved", "btnSave");
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Field", "btnSave");
        }
    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Company Details', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Company Details', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        trans.ResetFields(Page.Controls);
        txtDate_Installation.Text = dt.Today_Date();
        txtClient_Name.Focus();
        Auto_License_No();
        rdoSelect.SelectedIndex = 2;
        rdoStatusNew.SelectedIndex = 0;
        btnSave.Visible = true;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        ViewState["UPDATED_ID"] = null;
        Login_Page.Style.Add("display", "none");
        User_Creation.Style.Add("display", "none");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtCompany_License.Text != "" && txtClient_Name.Text != "")
        {
            try
            {
                string F = "U";
                i = Company_Details_Insert_Update(F);
                if (i == 1)
                {
                    txtCompany_License.ReadOnly = true;
                    Session["I_E_B"] = rdoSelect.SelectedValue.ToString();

                    if (ViewState["UPDATED_ID"] != null)
                    {
                        Alert_msg("Updated Successfully", "btnUpdate");
                    }
                    else
                    {
                        Alert_msg("Saved Successfully", "btnUpdate");
                    }
                    Login_Page.Style.Add("display", "block");
                    User_Creation.Style.Add("display", "block");

                }
                else if (i == 2)
                {
                    Login_Page.Style.Add("display", "none");
                    User_Creation.Style.Add("display", "none");
                    Alert_msg("License No Already Exist!", "btnUpdate");
                }
                else
                {
                    Login_Page.Style.Add("display", "none");
                    User_Creation.Style.Add("display", "none");
                    Alert_msg("Company Details Not Updated", "btnUpdate");
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Field");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (hdn_Company_ID.Value != "")
        {
            try
            {
                
                Comp.COMPANY_ID = hdn_Company_ID.Value;
                Comp.COMPANY_LICENSE = txtCompany_License.Text;
                Comp.CLIENT_NAME = "0";
                Comp.CONTACT_PERSON = "0";
                Comp.MOBILE_NO = "0";
                Comp.Ename = "delete";
                DataSet ds = new DataSet();
                ds=Comp.RetrieveAll_Company_Details();
               
                //-------------------------DELETE SERVER DETAILS--------------------//
                 Comp.COMPANY_ID = hdn_Company_ID.Value;
                Comp.COMPANY_LICENSE = txtCompany_License.Text;
                Comp.CLIENT_NAME = "0";
                Comp.CONTACT_PERSON = "0";
                Comp.MOBILE_NO = "0";
                Comp.Ename = "delete_DataBase_Details";
                
                Comp.RetrieveAll_Company_Details();
                //-------------------------DELETE SERVER DETAILS--------------------//

                int ii = 0;
                ii = Comp.result;
                if (ii > 0)
                {
                    
                        for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                        {
                            Delete_User_Details(ds.Tables[0].Rows[a]["SERVER_NAME"].ToString());
                   
                        }

                        string prompt = "<script>$(document).ready(function(){{jAlert('Company Details Deleted', 'GENERAL', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                 
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                }
                else
                {
                    Alert_msg("Company Details Not Deleted");
                }

            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
    }
    public void Delete_User_Details(string dbconn)
    {
        try
        {
            Insert_Update("Company_Details_Delete",dbconn);

            int ii = 0;
            ii = User.result;

            if (ii == 1)
            {
                i = ii;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public int Insert_Update(string Flag,string dbconn)
    {
        try
        {
            if (hdn_Company_ID.Value == "")
            {
                hdn_Company_ID.Value = "0";
            }
            User.USER_CREATION_ID = "0";
            User.COMPANY_ID = hdn_Company_ID.Value;
            User.CLIENT_NAME = "";
            User.NAME = "";


            User.USER_NAME = txtClient_Name.Text.Trim();
            User.PWD = "";
            User.EMAIL_ID = "";
            User.MOBILE_NO = "";
            User.EMPLOYEE_ID = "";
            User.TYPE = "S";
            User.ADMIN_ID = "";
            User.flag = "Company_Details_Delete";
            User.User_Creation_Insert_update(dbconn);
            i = User.result;

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return i;
    }
}