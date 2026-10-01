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


public partial class Staff_Master : ThemeClass
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
            Load_idType();
            //Load_status();
            GetAutono_Receipt();
            EditSupDetails();          
        }
       

       // txt_LicenseCurrency.Attributes.Add("onblur", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txt_LicenseCurrency.ClientID + "', '" + txt_Exrate.ClientID + "')");
    }


    public void Load_idType()
    {
        ddlotheridType.Items.Clear();
        ddlotheridType.Items.Add("Gas book");
        ddlotheridType.Items.Add("Ration Card");        
    }

    public void Load_status()
    {
        if (ddlStatus.SelectedValue == "InActive")
        {
            txtreason.Enabled = true;
        }
        else
        {
            txtreason.Enabled = false;
            
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
        ObjUBO.BILL_TYPE = "Staff_Master";
        ds = sm.Load_DDL(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtStaffcode.Text = ds.Tables[0].Rows[0][0].ToString();

        }
        ds.Dispose();
        GC.Collect();
    }




      public void EditSupDetails()
    {
        if (Request.QueryString["STAFF_ID"] != "" && Request.QueryString["STAFF_ID"] != null)
        {

            
            ADCODE_ID = Request.QueryString["STAFF_ID"];

            sm.STAFF_ID = ADCODE_ID;

            sm.Ename = "select_conwithcode";
            sm.EWorking_Period = Working_Period;

            dtuser = sm.RetrieveAll_Staff_MASTER();
            if (dtuser.Tables[0].Rows.Count > 0)
            {

                txtStaffcode.Text = dtuser.Tables[0].Rows[0]["STAFF_CODE"].ToString();
                txtstafullName.Text = dtuser.Tables[0].Rows[0]["STAFF_FULL_NAME"].ToString();

                txt_staffname.Text = dtuser.Tables[0].Rows[0]["STAFF_NAME"].ToString();
                txt_empid.Text = dtuser.Tables[0].Rows[0]["EMPLOYEE_ID"].ToString();
                txtAdno.Text = dtuser.Tables[0].Rows[0]["AADHAR_ID"].ToString();
                txtpanid.Text = dtuser.Tables[0].Rows[0]["PAN_ID"].ToString();
                string OtherId_type = dtuser.Tables[0].Rows[0]["OTHER_ID_TYPE"].ToString();
                Load_idType();
                //ddl_Excemption.Items.Add("E");
                ddlotheridType.Items.Remove(OtherId_type);
                ddlotheridType.Items.Insert(0, OtherId_type);

                txtothidno.Text = dtuser.Tables[0].Rows[0]["OTHER_ID_NO"].ToString();
                txtentDate.Text = dtuser.Tables[0].Rows[0]["ENTRY_DATE"].ToString();

                //txtbandet.Text = dtuser.Tables[0].Rows[0]["BANK_DETAILS"].ToString();
                txt_doj.Text = dtuser.Tables[0].Rows[0]["DOJ"].ToString();
                //txtEmpstaus.Text = dtuser.Tables[0].Rows[0]["EMP_STATUS"].ToString();
                ddlStatus.SelectedValue = dtuser.Tables[0].Rows[0]["EMP_STATUS"].ToString();
                
                if (ddlStatus.SelectedValue == "InActive")
                {
                    txtreason.Enabled = true;
                }
                else
                {
                    txtreason.Enabled = false;

                }
                txtreason.Text = dtuser.Tables[0].Rows[0]["REASON"].ToString();
                txtremarks.Text = dtuser.Tables[0].Rows[0]["REMARKS"].ToString();
                txtlicno.Text = dtuser.Tables[0].Rows[0]["DRIVING_LICENSE"].ToString();
                txtpass.Text = dtuser.Tables[0].Rows[0]["PASSPORT"].ToString();

                txt_bankuser_name.Text = dtuser.Tables[0].Rows[0]["BANK_USER_NAME"].ToString();
                txt_bank_name.Text = dtuser.Tables[0].Rows[0]["BANK_NAME"].ToString();
                txt_acc_no.Text = dtuser.Tables[0].Rows[0]["ACCOUNT_NO"].ToString();
                txt_ifsc.Text = dtuser.Tables[0].Rows[0]["IFSC_CODE"].ToString();
                txt_swift_code.Text = dtuser.Tables[0].Rows[0]["SWIFT_CODE"].ToString();
                txt_bank_branch.Text = dtuser.Tables[0].Rows[0]["BANK_BRANCH_NAME"].ToString();

              
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["STAFF_ID"].ToString();
              
            }
            HiddenField1.Value = Request.QueryString["STAFF_ID"].ToString();
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
        }
        else
        {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                Load_status();
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
                    txt_staffname.Focus();
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
                Alert_msg("Employee Id already exixts!", "btnSave");
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
                Alert_msg("Bank details Not Saved", "btnUpdate");
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

            Inner_InsertUpdate(Request.QueryString["STAFF_ID"], "U");
                       
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    public int insert_update(string a1, string a2, string a3)
    {
        //erm.STAFF_CODE = a1;

        sm.STAFF_ID = a1;
        sm.STAFF_CODE = txtStaffcode.Text;
        sm.STAFF_FULL_NAME = txtstafullName.Text.ToUpper();
        sm.STAFF_NAME = txt_staffname.Text.ToUpper().Trim();//txtBankName.Text;
        sm.EMPLOYEE_ID = txt_empid.Text.ToUpper().Trim();
        sm.AADHAR_ID = txtAdno.Text.ToUpper().Trim();
        sm.PAN_ID = txtpanid.Text.ToUpper().Trim();
        sm.OTHER_ID_TYPE = ddlotheridType.SelectedValue.ToString();
        sm.OTHER_ID_NO = txtothidno.Text;
        sm.ENTRY_DATE = txtentDate.Text;
       // sm.BANK_DETAILS = txtbandet.Text;
        sm.DOJ = txt_doj.Text;
        sm.DRIVING_LICENSE = txtlicno.Text;
        sm.PASSPORT = txtpass.Text;
        sm.EMP_STATUS = ddlStatus.SelectedItem.ToString();
        sm.REASON = txtreason.Text;
        sm.REMARKS = txtremarks.Text;
        sm.BANK_NAME = txt_bank_name.Text;
        sm.IFSC_CODE = txt_ifsc.Text;
        sm.BANK_BRANCH_NAME = txt_bank_branch.Text;
        sm.SWIFT_CODE = txt_swift_code.Text;
        sm.ACCOUNT_NO = txt_acc_no.Text;
        sm.BANK_USER_NAME = txt_bankuser_name.Text;
       //erm.USER_ID = currentuser;
       //erm.DATE_TIME = LoginDate;
        sm.STATUS = "N";
        sm.BRANCH_CODE = currentbranch;
        sm.YEAR = a3;
        sm.WORKING_PERIOD = Working_Period;
        sm.MODIFIEDBY = currentuser;
        sm.MODIFIEDON = LoginDate;
        sm.flag = a2;



        i = sm.Staff_Master_Insert_update();
        return i;
    }

    

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            sm.STAFF_CODE = HiddenField1.Value;
            sm.STAFF_ID = HiddenField1.Value;
            //erm.LICENSE_NO = "0";
            sm.Ename = "delete";
            sm.EWorking_Period = Working_Period;

            //erm.RetrieveAll_IMPORT_LICENSE_MASTER();

            sm.RetrieveAll_Staff_MASTER();
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
        Session["STAFF_ID"] = "";
        Clear();
        GetAutono_Receipt();
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
        txt_staffname.Text = "";
        txt_staffname.Focus();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'STAFF MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'STAFF MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
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
   

}