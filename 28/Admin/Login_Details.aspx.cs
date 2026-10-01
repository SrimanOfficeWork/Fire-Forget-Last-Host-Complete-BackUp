using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Login_Details : ThemeClass
{
    
    SqlConnection con;
    SqlCommand cmd;
    DataSet dtuser = new DataSet();
    DataSet dtcomp = new DataSet();
    
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string ADCODE_ID = "";
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    string SP_QUERY;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public int i, Update_Id;
    public string AUTO_ID, COMPANY_LICENSE;
    Company_Master COMPANY = new Company_Master();
    User_Creation USER = new User_Creation();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
       
         if (Session["COMP_LICENSE"] != "" && Session["COMP_LICENSE"] != null)
         {

            COMPANY_LICENSE = Session["COMP_LICENSE"].ToString();
            if (Session["COMP_ID"] != "" && Session["COMP_ID"] != null)
            {
                string comp_id = Session["COMP_ID"].ToString();
                //string[] s1 = comp_id.Split(new string[] { "_" }, StringSplitOptions.None);
                // string   CODE = s1[0].ToString();
                // string    CODE1 = s1[1].ToString();
                hdn_Company_ID.Value = comp_id;

                hdn_User_Status.Value = Session["COMP_STATUS_Id"].ToString();
                    if (hdn_User_Status.Value == "True")
                        hdn_User_Status.Value = "1";
                    else
                        hdn_User_Status.Value = "0";

              
            }
         }
         else
         {

         }
        if (!IsPostBack)
        {
            Login_page.Style.Add("display", "none");
            ddlSelect_Job.Items.Clear();
            ddlSelect_Job.Items.Add("Common Job");
            ddlSelect_Job.Items.Add("Branchwise Job");
            ddlSelect_Job.Items.Add("Areawise Job");
            EditSupDetails();
        }
    }
    
    public void EditSupDetails()
    {
        if (Session["New_User"] != "" && Session["New_User"] != null)
        {
            btnLogin_Delete.Visible = false;
            btnLogin_Update.Visible = false;
            btnLogin_Save.Visible = true;
        }
        else
        {
            if (COMPANY_LICENSE != "")
            {
                COMPANY.COMPANY_LICENSE = COMPANY_LICENSE;
                COMPANY.Ename = "Select_Login_Details";
                COMPANY.ISLOGIN = "0";
                dtuser = COMPANY.RetrieveAll_Company_Details();
                
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    //-------------------------------------- DATABSE DETAILS---------------------------------------//
                    gvdetails.DataSource = dtuser.Tables[0];
                    gvdetails.DataBind();
                    btnDatabase_Delete.Visible = false;
                    btnDatabase_Update.Visible = false;
                    btnDatabase_Save.Visible = true;
                    //-------------------------------------- DATABSE DETAILS---------------------------------------//

                }
                else
                {
                    DataTable dt = new DataTable();
                    gvdetails.EmptyDataText = "";
                    gvdetails.DataSource = dt;
                    gvdetails.DataBind();
                    btnDatabase_Delete.Visible = false;
                    btnDatabase_Update.Visible = false;
                    btnDatabase_Save.Visible = true;
                }
                if (dtuser.Tables[1].Rows.Count > 0)
                {
                    //-------------------------------------- FINANCIAL_YEAR DETAILS---------------------------------------//
                    ddl_Workingperiod.DataSource = dtuser.Tables[1];
                    ddl_Workingperiod.DataTextField = "WORKING_PERIOD";
                    ddl_Workingperiod.DataValueField = "WORKING_PERIOD";

                    ddl_Workingperiod.DataBind();
                    btnDatabase_Delete.Visible = false;
                    btnDatabase_Update.Visible = false;
                    btnDatabase_Save.Visible = true;
                    //-------------------------------------- FINANCIAL_YEAR DETAILS---------------------------------------//
                }
                else
                {
                    btn();
                }
            }
        }

    }
    public void btn()
    {
        btnLogin_Delete.Visible = false;
        btnLogin_Update.Visible = false;
        btnLogin_Save.Visible = true;
    }
    public int insert_update(string a1, string Flag)
    {
        if (hdn_Company_ID.Value == "")
        {
            hdn_Company_ID.Value = "0";
        }
        if (HiddenField1.Value == "")
        {
            HiddenField1.Value = "0";
        }
        USER.USER_CREATION_ID = HiddenField1.Value;
        USER.COMPANY_ID = hdn_Company_ID.Value;
        USER.CLIENT_NAME = "";
        USER.NAME = "";


        USER.USER_NAME = txtUserName.Text;
        USER.PWD = txtPwd.Text;
        USER.EMAIL_ID = "";
        USER.MOBILE_NO = "";
        USER.EMPLOYEE_ID = "";
        USER.USER_STATUS = hdn_User_Status.Value;
        USER.TYPE = "S";


        USER.ADMIN_ID = "";
        USER.flag = Flag;

        USER.User_Creation_Insert_update(HttpContext.Current.Session["User_current_comp_db"].ToString());
        i = USER.result;

        return i;
    }
    protected void btnLogin_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtUserName.Text != "" && txtPwd.Text != "")
            {

                string a1 = "0";
                string a2 = "S";
                insert_update(a1, a2);
                HiddenField1.Value = Convert.ToString(USER.Update_Id);

                if (i == 1)
                {


                    btnLogin_Update.CssClass = "save";
                    btnLogin_Update.Visible = true;
                    btnLogin_Save.Visible = false;

                    btnLogin_Save.Focus();

                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnLogin_Save");
                }
                else
                {
                    Alert_msg("User Name Already Exists!", "btnLogin_New");
                }
            }
            else
            {

                Alert_msg("Enter All Mandatory Field");


            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnLogin_Update_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text != "" && txtPwd.Text != "")
        {
            try
            {
                string a1 = HiddenField1.Value;
                string a2 = "U";
                insert_update(a1, a2);
                if (i == 2)
                {
                    if (ViewState["UPDATED_ID"] != null)
                    {
                        Alert_msg("Updated Successfully", "btnLogin_Update");
                    }
                    else
                    {
                        Alert_msg("Saved Successfully", "btnLogin_Update");

                    }
                }
                else
                {
                    Alert_msg("Not Saved", "btnUpdate");
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
    protected void btnLogin_Delete_Click(object sender, EventArgs e)
    {
        try
        {

            string a1 = HiddenField1.Value;
            string a2 = "Delete";

            insert_update(a1, a2);
           
            i = USER.result;

            if (i == 3)
            {
                Alert_msg("Login Deleted");
                btnLogin_New_Click(sender, e);
            }
            else
            {
                
                Alert_msg("Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnLogin_New_Click(object sender, EventArgs e)
    {
        txtUserName.Text = "";
        txtPwd.Text = "";
        btnLogin_Delete.Visible = false;
        btnLogin_Update.Visible = false;
        btnLogin_New.Visible = true;
        btnLogin_Save.Visible = true;
        HiddenField1.Value = "";
        ViewState["UPDATED_ID"] = null;

    }
    //-------------------------------------------------------------------DATABASE DETAILS----------------------------------------------------------------------//

    public void GridBind()
    {
        if (COMPANY_LICENSE != "")
        {
            COMPANY.DATABASE_ID = "0";
            COMPANY.COMPANY_LICENSE = COMPANY_LICENSE;
            COMPANY.SERVER_NAME = txtServerName.Text;
            COMPANY.DATABASE_NAME = txtDatabaseName.Text;
            COMPANY.USERNAME = txtLogin_Name.Text;

            COMPANY.PWD = txtLogin_Pwd.Text;
            COMPANY.WORKING_PERIOD = ddl_Workingperiod.SelectedValue.ToString();

            COMPANY.Ename = "select";

            dtuser = COMPANY.RetrieveAll_Database_Details();
            
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                //-------------------------------------- DATABSE DETAILS---------------------------------------//
                gvdetails.DataSource = dtuser.Tables[1];
                gvdetails.DataBind();
                //-------------------------------------- DATABSE DETAILS---------------------------------------//

            }
            else
            {
                DataTable dt = new DataTable();
                gvdetails.EmptyDataText = "";
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
                btnDatabase_Delete.Visible = false;
                btnDatabase_Update.Visible = false;
                btnDatabase_Save.Visible = true;
            }
        }
    }
    public DataSet Database_Details_insert_update(string a1, string a2)
    {
        COMPANY.DATABASE_ID = a1;
        COMPANY.COMPANY_LICENSE = COMPANY_LICENSE;
        COMPANY.SERVER_NAME = txtServerName.Text;
        COMPANY.DATABASE_NAME = txtDatabaseName.Text;
        COMPANY.USERNAME = txtLogin_Name.Text;

        COMPANY.PWD = txtLogin_Pwd.Text;
        COMPANY.WORKING_PERIOD = ddl_Workingperiod.SelectedValue.ToString();

        COMPANY.SELECT_JOB = ddlSelect_Job.SelectedValue.ToString();
        
        COMPANY.Ename = a2;

        gvdetails.DataSource= COMPANY.RetrieveAll_Database_Details();
        gvdetails.DataBind();
        i = COMPANY.result;

        return dtuser;
    }
    protected void btnDatabase_Save_Click(object sender, EventArgs e)
    {
        try
        {
           

                string a1 = "0";
                string a2 = "S";
                Database_Details_insert_update(a1, a2);
                hdn_update_Database.Value = Convert.ToString(COMPANY.Update_Id);

                if (i == 1)
                {


                    btnDatabase_Update.CssClass = "save";
                    btnDatabase_Update.Visible = true;
                    btnDatabase_Save.Visible = false;

                    btnDatabase_Save.Focus();

                    ViewState["DB_UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnDatabase_Save");
                }
                else if (i == 2)
                {
                    Alert_msg("Database already exists!", "btnDatabase_Save");

                }
                else if (i == 3)
                {
                    Alert_msg("Working Period already exists!", "btnDatabase_Save");

                }

                else
                {

                    Alert_msg("Not Saved", "btnDatabase_New");

                }
           
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnDatabase_Update_Click(object sender, EventArgs e)
    {
       

            try
            {
                string a1 = hdn_update_Database.Value;
                string a2 = "U";

                Database_Details_insert_update(a1, a2);
                if (i == 1)
                {

                    if (ViewState["DB_UPDATED_ID"] != null)
                    {
                        Alert_msg("Updated Successfully", "btnDatabase_Update");

                    }
                    else
                    {
                        Alert_msg("Saved Successfully", "btnDatabase_Update");

                    }



                }
                else if (i == 2)
                {
                    Alert_msg("Database already exists!", "btnDatabase_Update");

                }
                else if (i == 3)
                {
                    Alert_msg("Working Period already exists!", "btnDatabase_Update");

                }

                else
                {

                    Alert_msg("Not Saved", "btnDatabase_Update");

                }


            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
       

    }
    protected void btnDatabase_Delete_Click(object sender, EventArgs e)
    {
        try
        {

            string a1 = hdn_update_Database.Value;
            string a2 = "delete";

            Database_Details_insert_update(a1, a2);

            i = COMPANY.result;

            if (i == 1)
            {
                Alert_msg("Database Deleted");
                btnDatabase_New_Click(sender, e);

            }


            else
            {

                Alert_msg("Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnDatabase_New_Click(object sender, EventArgs e)
    {
        txtLogin_Name.Text = "";
        txtLogin_Pwd.Text = "";
        //txtServerName.Text = "";
        txtDatabaseName.Text = "";
        ddl_Workingperiod.Items.Remove(ddl_Workingperiod.SelectedValue.ToString());
        ddl_Workingperiod.Items.Insert(0, ddl_Workingperiod.SelectedValue.ToString());
        ddl_Workingperiod.SelectedIndex = -1;
        btnDatabase_Delete.Visible = false;
        btnDatabase_Update.Visible = false;
        btnDatabase_New.Visible = true;
        btnDatabase_Save.Visible = true;
        hdn_update_Database.Value = "";
        ViewState["DB_UPDATED_ID"] = null;

    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["DATABASEID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

        if (ViewState["DATABASEID"] != "" && ViewState["DATABASEID"] != null)
        {
            LoginId.Style.Add("display", "block");

            Branch_DETAILS_ID.Style.Add("display", "block");

            txtServerName.Text = gvdetails.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            txtDatabaseName.Text = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            txtLogin_Name.Text = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            txtLogin_Pwd.Text = gvdetails.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string type = gvdetails.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

            /*
            ddl_Workingperiod.Items.Remove(type);
            ddl_Workingperiod.Items.Insert(0, type);
            */

            ddl_Workingperiod.SelectedValue = type;

            string select_job = gvdetails.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");

            //ddlSelect_Job.Items.Remove(select_job);
            //ddlSelect_Job.Items.Insert(0, select_job);

            ddlSelect_Job.Items.Clear();
            ddlSelect_Job.Items.Add("Common Job");
            ddlSelect_Job.Items.Add("Branchwise Job");
            ddlSelect_Job.Items.Add("Areawise Job");
            //Areawise Job
            ddlSelect_Job.Items.Remove(select_job);
            ddlSelect_Job.Items.Insert(0, select_job);


            string DB_Conn = "Server=" + txtServerName.Text + ";" + "database=" + txtDatabaseName.Text + ";" + "uid=" + txtLogin_Name.Text + ";" + "pwd=" + txtLogin_Pwd.Text + ";";
           //----------------------------------------------LOGIN SCREEN-----------------------------------//
            Login_page.Style.Add("display", "block");
          
            Session.Remove("User_current_comp_db");
            Session["User_current_comp_db"] = DB_Conn;
            USER.USER_CREATION_ID = "0";
            if (hdn_Company_ID.Value == "")
            {
                hdn_Company_ID.Value = "0";
            }

            USER.COMPANY_ID = hdn_Company_ID.Value;
            USER.Ename = "select_SYSADMIN";
            USER.TYPE = "S";//S --SYS ADMIN
            USER.startRowIndex = "0";
            USER.maximumRows = "0";
            dtcomp = USER.RetrieveAll_AdminUser_Details(DB_Conn);
            if (string.IsNullOrWhiteSpace(USER.Error_msg))
            {
                if (dtcomp.Tables[0].Rows.Count > 0)
                {
                    txtUserName.Text = dtcomp.Tables[0].Rows[0]["USER_NAME"].ToString();
                    txtPwd.Text = dtcomp.Tables[0].Rows[0]["PWD"].ToString();

                    HiddenField1.Value = dtcomp.Tables[0].Rows[0]["USER_CREATION_ID"].ToString();
                    Session.Remove("ADMIN_USER_CREATION_ID");
                    Session["ADMIN_USER_CREATION_ID"] = HiddenField1.Value;
                    //FOR UPDATED SUCCESSFULLY
                    ViewState["UPDATED_ID"] = null;
                    ViewState["UPDATED_ID"] = HiddenField1.Value;
                    //FOR UPDATED SUCCESSFULLY
                    btnLogin_Delete.Visible = true;
                    btnLogin_Update.Visible = true;
                    btnLogin_Save.Visible = false;
                    User_Branch.Style.Add("display", "block");
                    User_Permission.Style.Add("display", "block");
                    Branch_DETAILS_ID.Style.Add("display", "block");
                    LoginId.Style.Add("display", "block");
                    GroupCreation.Style.Add("display", "block");
                    Group_Modify.Style.Add("display", "block");
                }
                else
                {
                    if (USER.Error_msg != "" && USER.Error_msg!=null)
                    {
                        LoginId.Style.Add("display", "none");

                        Branch_DETAILS_ID.Style.Add("display", "none");
                        User_Branch.Style.Add("display", "none");
                        User_Permission.Style.Add("display", "none");
                        GroupCreation.Style.Add("display", "none");
                        Group_Modify.Style.Add("display", "none");
                        btn();
                    }
                    if(txtUserName.Text=="" && txtPwd.Text=="")
                        Branch_DETAILS_ID.Style.Add("display", "none");
                }
            }
            else
            {
                LoginId.Style.Add("display", "none");

                Branch_DETAILS_ID.Style.Add("display", "none");
                User_Branch.Style.Add("display", "none");
                User_Permission.Style.Add("display", "none");
                GroupCreation.Style.Add("display", "none");
                Group_Modify.Style.Add("display", "none");
                btn();
                Alert_msg("The Login failed. Please create database..");

            }
            //----------------------------------------------LOGIN SCREEN-----------------------------------//

            //FOR UPDATED SUCCESSFULLY
            ViewState["DB_UPDATED_ID"] = null;
            ViewState["DB_UPDATED_ID"] = ViewState["DATABASEID"].ToString();
            hdn_update_Database.Value = ViewState["DATABASEID"].ToString();

            //FOR UPDATED SUCCESSFULLY
            btnDatabase_Update.CssClass = "updates";

            btnDatabase_Delete.Visible = true;
            btnDatabase_Update.Visible = true;
            btnDatabase_Save.Visible = false;
            btnDatabase_New.Visible = true;
        }
        else
        {
            LoginId.Style.Add("display", "none");
            Branch_DETAILS_ID.Style.Add("display", "none");
            GroupCreation.Style.Add("display", "none");
            Group_Modify.Style.Add("display", "none");

            btnDatabase_Delete.Visible = false;
            btnDatabase_Update.Visible = false;
            btnDatabase_Save.Visible = true;
            btnDatabase_New.Visible = true;
            
        }
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
    protected void gvdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdetails.PageIndex = e.NewPageIndex;
        GridBind();
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }


    //-------------------------------------------------------------------DATABASE DETAILS----------------------------------------------------------------------//

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LOGIN & DATABASE', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LOGIN & DATABASE', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}