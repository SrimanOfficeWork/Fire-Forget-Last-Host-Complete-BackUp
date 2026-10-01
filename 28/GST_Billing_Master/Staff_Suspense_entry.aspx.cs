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


public partial class Staff_Suspense_entry : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    Staff_master sm = new Staff_master();
    //BankMaster lic = new BankMaster();
    adminmaster adm = new adminmaster();
    SqlConnection con;
    SqlCommand cmd;
    DataSet dtuser = new DataSet();
    AppSession aps = new AppSession();
    public string ADCODE_ID = "";
    ErrorLogs er = new ErrorLogs();
    DataSet ds = new DataSet();
    Billing_UserBO ObjUBO = new Billing_UserBO();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public int i,Update_Id;
    public string AUTO_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, SELECT_BRANCH;
    public int Screen_Id;
    public double Job_Remaing_Amt, Job_Remaing_Qty;
    public string SingleDutyY_N = "", click_SaveNew = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        aps.checkSession();

        //txt_PartyName.Focus();
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        if (!IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 6;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
            //auto search
            //Load_idType();
            //Load_status();
                 
            GetAutono_Receipt();
            load_Staff_name();
            EditSupDetails();
            //LoadFinancialYear();
           
        }
       

       // txt_LicenseCurrency.Attributes.Add("onblur", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txt_LicenseCurrency.ClientID + "', '" + txt_Exrate.ClientID + "')");
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
            //}
            //btnNew.Enabled = true;
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

    private void GetAutono_Receipt()
    {
        DataSet ds = new DataSet();
        ObjUBO.Flag = "Generate-AutoNo";
        ObjUBO.BILL_TYPE = "Staff_suspense";
        ds = sm.Load_DDL(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtSusp_id.Text = ds.Tables[0].Rows[0][0].ToString();

        }
        ds.Dispose();
        GC.Collect();
    }




      public void EditSupDetails()
    {
       //if (Session["STAFF_PR_CR_ID"] != "" && Session["STAFF_PR_CR_ID"] != null)
        if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null)
        {
            

           // ADCODE_ID =Session ["STAFF_PR_CR_ID"].ToString();
            ADCODE_ID = Request.QueryString["ID"];

            sm.ID = ADCODE_ID;
            sm.BRANCH_CODE = currentbranch;
            sm.Ename = "select_conwithcode";
            sm.EWorking_Period = Working_Period;
            //sm.STAFF_NAME = ddlStaffName.SelectedValue.ToString().Split('-')[0];
            //sm.STAFF_CODE = ddlStaffName.SelectedValue.ToString().Split('-')[1];

            dtuser = sm.RetrieveAll_staff_Suspense_entry();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                //ddlStaffName.Items.Insert(0, new ListItem(dtuser.Tables[0].Rows[0]["STAFF_NAME"].ToString(), dtuser.Tables[0].Rows[0]["STAFF_CODE"].ToString()));
                //ddlStaffName.SelectedIndex = 0;
                //txtStaffcode.Text = dtuser.Tables[0].Rows[0]["STAFF_CODE"].ToString();
                load_Staff_retrieved_name();
                ddlStaffName.SelectedValue = dtuser.Tables[0].Rows[0]["STAFF_NAME"].ToString();
                //sm.STAFF_NAME = ddlStaffName.SelectedValue.ToString().Split('-')[0];
                //sm.STAFF_CODE = ddlStaffName.SelectedValue.ToString().Split('-')[1];
                //txt_staffname.Text = dtuser.Tables[0].Rows[0]["STAFF_NAME"].ToString();
                txtSusp_id.Text = dtuser.Tables[0].Rows[0]["SUSP_ID"].ToString();
                txt_Desc.Text = dtuser.Tables[0].Rows[0]["SUSP_DESCRIPTION"].ToString();
                txt_amount.Text = dtuser.Tables[0].Rows[0]["SUSP_AMOUNT"].ToString();
                string a = String.Format("{0: dd/MM/yyyy}", DateTime.Now.ToShortDateString());
                txtgivDate.Text = dtuser.Tables[0].Rows[0]["SUSP_GIVEN_DATE"].ToString();
                txtremarks.Text = dtuser.Tables[0].Rows[0]["REMARKS"].ToString();
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["ID"].ToString();
              
            }
            HiddenField1.Value = Request.QueryString["ID"].ToString();
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
                GetAutono_Receipt();   
        }
    }
    public void Clear()
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);

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
        //sm.STAFF_ENTRY_DATE = "01/01/1900";
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
                   // txt_staffname.Focus();
                }
                else
                {
                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    Alert_msg("Saved Successfully", "btnSave");
                }
                //txtLicense_No.Enabled = false;
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
                //hdn_Update_Adcode.Value = txtLicense_No.Text;
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

            Inner_InsertUpdate(Request.QueryString["ID"], "U");
                       
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    public int insert_update(string a1, string a2, string a3)
    {
        //erm.STAFF_CODE = a1;

        sm.ID = a1;
        //sm.STAFF_PR_CR_ID = "";
        sm.SUSP_ID = txtSusp_id.Text;
        sm.STAFF_NAME = ddlStaffName.SelectedValue.ToString().Split('-')[0];
        sm.STAFF_CODE = ddlStaffName.SelectedValue.ToString().Split('-')[1];
        sm.SUSP_DESCRIPTION = txt_Desc.Text;
        sm.SUSP_AMOUNT = (txt_amount.Text == "" ? "0" : txt_amount.Text);
        if (txtgivDate.Text == "")
        {
            sm.SUSP_GIVEN_DATE = "01/01/1900";
        }
        else
        {
            sm.SUSP_GIVEN_DATE = txtgivDate.Text;
        }
        sm.REMARKS= txtremarks.Text;

       
       //erm.USER_ID = currentuser;
       //erm.DATE_TIME = LoginDate;
        sm.STATUS = "N";
        sm.BRANCH_CODE = currentbranch;
        sm.YEAR = a3;
        sm.WORKING_PERIOD = Working_Period;
        sm.MODIFIEDBY = currentuser;
        sm.MODIFIEDON = LoginDate;
        sm.flag = a2;



        i = sm.staff_Suspense_entry_Insert_update();
        return i;
    }

    

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            //sm.STAFF_CODE = HiddenField1.Value;
            sm.ID = HiddenField1.Value;
            //erm.LICENSE_NO = "0";
            sm.Ename = "delete";
            sm.EWorking_Period = Working_Period;

            //erm.RetrieveAll_IMPORT_LICENSE_MASTER();

            sm.RetrieveAll_staff_Suspense_entry();
            int ii = 0;
            ii =sm.result;

            if (ii > 0)
            {
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Adcode Deleted')</script>", false);
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
        Session["ID"] = "";
        Clear();
        //GetAutono_Receipt();
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
        //txt_staffname.Text = "";
        //txt_staffname.Focus();
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
    ///auto search
    [System.Web.Services.WebMethod]
    public static string GetClient_Name(string custid)
    {
        if (custid.Length == 10)
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);
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


            ObjUBO.Flag = "Suspense_StaffName";
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