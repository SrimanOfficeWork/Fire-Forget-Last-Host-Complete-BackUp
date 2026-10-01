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
using BussinessObject;

public partial class Staff_Master_Previous_CrDebit_entry : ThemeClass
{
    AppSession aps = new AppSession();
    Staff_master_cs sm = new Staff_master_cs();
    User_Creation user_Create = new User_Creation();
    Billing_UserBO ObjUBO = new Billing_UserBO();
    ErrorLogs er = new ErrorLogs();
    
    DataSet dtuser = new DataSet();
    DataSet ds = new DataSet();
    
    public string currentuser,currentbranch,Working_Period,LoginDate,ADCODE_ID = "",click_SaveNew = "";
    public int i,Update_Id;
    
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, SELECT_BRANCH;
    public int Screen_Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        if (!IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 6;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
            load_Staff_name();
            EditSupDetails();
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
    
      public void EditSupDetails()
    {
        if (Request.QueryString["STAFF_PR_CR_ID"] != "" && Request.QueryString["STAFF_PR_CR_ID"] != null)
        {
            
            ADCODE_ID = Request.QueryString["STAFF_PR_CR_ID"];
            sm.STAFF_PR_CR_ID = ADCODE_ID;
            sm.BRANCH_CODE = currentbranch;
            sm.Ename = "select_conwithcode";
            sm.EWorking_Period = Working_Period;
            dtuser = sm.RetrieveAll_staff_previous_cr_dr_entry();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                load_Staff_retrieved_name();
                ddlStaffName.SelectedValue = dtuser.Tables[0].Rows[0]["STAFF_NAME"].ToString();
                txt_stf_prev_dt.Text = dtuser.Tables[0].Rows[0]["STAFF_PREVIOUS_DEBIT"].ToString();
                txt_stf_cr_dt.Text = dtuser.Tables[0].Rows[0]["STAFF_PREVIOUS_CREDIT"].ToString();
                txtWriteoff.Text = dtuser.Tables[0].Rows[0]["STAFF_WRITE_OFF"].ToString();
                string a = String.Format("{0: dd/MM/yyyy}", DateTime.Now.ToShortDateString());
                txtentDate.Text = dtuser.Tables[0].Rows[0]["STAFF_ENTRY_DATE"].ToString();
                txtBalance.Text = dtuser.Tables[0].Rows[0]["STAFF_BALANCE"].ToString();
                txtremarks.Text = dtuser.Tables[0].Rows[0]["REMARKS"].ToString();
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["STAFF_PR_CR_ID"].ToString();
              
            }
                HiddenField1.Value = Request.QueryString["STAFF_PR_CR_ID"].ToString();
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
        }
        else
        {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                load_Staff_name();
        }
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

            Inner_InsertUpdate("", "S");
                 
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Inner_InsertUpdate(string a1,string a2)
    {
        string a3 = "";
        insert_update(a1,a2,a3);
        i= sm.result;
        HiddenField1.Value = Convert.ToString(sm.UPDATE_ID);

        if (a2 == "S")
        {
            if (i == 1)
            {
                if (click_SaveNew == "SaveNew_Click")
                {
                }
                else
                {
                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    Alert_msg("Saved Successfully", "btnSave");
                }
                ViewState["UPDATED_ID"] = null;
               
            }
            else if (i == 2)
            {
                Alert_msg("Staff Code already exixts!", "btnSave");
            }
                 else if (i == 3)
            {
                Alert_msg("Staff Details already exixts!", "btnSave");
            }
            else if (i == 4)
            {
                Alert_msg("Staff Name already exixts!", "btnSave");
            }
            else
            {
                Alert_msg("Staff Code Not Saved", "btnNew");
            }
        }
        else if (a2 == "U")
        {
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
                Alert_msg("Staff Code already exixts!", "btnUpdate");
            }
            else if (i == 3)
            {
                Alert_msg("Staff Name already exixts!", "btnSave");
            }
            else
            {
                Alert_msg("Staff Details Not Saved", "btnUpdate");
            }
        }
        else
        {
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Inner_InsertUpdate(Request.QueryString["STAFF_PR_CR_ID"], "U");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    public int insert_update(string a1, string a2, string a3)
    {
        sm.STAFF_PR_CR_ID = a1;
        sm.STAFF_NAME = ddlStaffName.SelectedValue.ToString().Split('-')[0];
        sm.STAFF_CODE = ddlStaffName.SelectedValue.ToString().Split('-')[1];
        sm.STAFF_PREVIOUS_DEBIT = txt_stf_prev_dt.Text;
        sm.STAFF_PREVIOUS_CREDIT = (txt_stf_cr_dt.Text == "" ? "0" : txt_stf_cr_dt.Text);
        sm.STAFF_BALANCE = txtBalance.Text;
        sm.STAFF_WRITE_OFF = (txtWriteoff.Text == "" ? "0" : txtWriteoff.Text);
        if (txtentDate.Text == "")
        {
            sm.STAFF_ENTRY_DATE = "01/01/1900";
        }
        else
        {
            sm.STAFF_ENTRY_DATE = txtentDate.Text;
        }
        sm.REMARKS= txtremarks.Text;
        sm.STATUS = "N";
        sm.BRANCH_CODE = currentbranch;
        sm.YEAR = a3;
        sm.WORKING_PERIOD = Working_Period;
        sm.MODIFIEDBY = currentuser;
        sm.MODIFIEDON = LoginDate;
        sm.flag = a2;
        i = sm.staff_previous_cr_dr_entry_Insert_update();
        return i;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            sm.STAFF_PR_CR_ID = HiddenField1.Value;
            sm.Ename = "delete";
            sm.EWorking_Period = Working_Period;
            sm.RetrieveAll_staff_previous_cr_dr_entry();
            int ii = 0;
            ii =sm.result;

            if (ii > 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Staff Details Deleted', 'STAFF MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);           
            }
            else
            {
                Alert_msg("Staff details Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Session["STAFF_PR_CR_ID"] = "";
        Clear();
        load_Staff_name();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        hdn_Update_Adcode.Value = "";
        ViewState["UPDATED_ID"] = null;
       
    }

    protected void btnSaveNew_Click(object sender, EventArgs e)
    {
        click_SaveNew = "SaveNew_Click";
        btnSave_Click(sender, e);
        btnNew_Click(sender, e);
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'STAFF PREVIOUS CR DR ENTRY ', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'STAFF PREVIOUS CR DR ENTRY ', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    [System.Web.Services.WebMethod]
    public static string GetClient_Name(string custid)
    {
        if (custid.Length == 10)
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_IECCODE_WISE";
            Auto.Enamesearch = custid;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = ds.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
            }
            else
            {
                custid = "";
            }
        }
        else
        {
            custid = "";
        }
        return custid;
    }

    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        load_Staff_name();
    }

    public void LoadFinancialYear()
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;

        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
        try
        {
            con.Open();
            ddlWorkingPeriod.Items.Clear();
            cmd = new SqlCommand("select * from FINANCIAL_YEAR order by WORKING_PERIOD desc", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ddlWorkingPeriod.Items.Add(dr["WORKING_PERIOD"].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
    private void load_Staff_name()
    {
        try
        {
            string name = Session["WorkingPeriod"].ToString();
            LoadFinancialYear();
            ddlWorkingPeriod.SelectedValue = name;
            ddlWorkingPeriod.Enabled = false;
           
                ObjUBO.Flag = "Select-StaffName";
                DataSet ds = new DataSet();

                ddlStaffName.Items.Clear();
                ds = sm.Load_Staff_name(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    ddlStaffName.DataSource = ds.Tables[0];
                    ddlStaffName.DataTextField = "staff_name";
                    ddlStaffName.DataValueField = "STAFF_NAME";
                    ddlStaffName.DataBind();
                }
                ddlStaffName.Items.Insert(0, new ListItem("--Select--", "--Select--"));
                ddlStaffName.SelectedIndex = 0;
            }
            

        
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void load_Staff_retrieved_name()
    {
        try
        {


            ObjUBO.Flag = "StaffName";
            DataSet ds = new DataSet();
            ds = sm.Load_Staff_name(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlStaffName.DataSource = ds.Tables[0];
                ddlStaffName.DataTextField = "staff_name";
                ddlStaffName.DataValueField = "STAFF_NAME";
                ddlStaffName.DataBind();
            }
            
        }

        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    } 
}