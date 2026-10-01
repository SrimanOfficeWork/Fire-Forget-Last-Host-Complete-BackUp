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


public partial class Bank_Master : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    //BankMaster lic = new BankMaster();
    adminmaster adm = new adminmaster();
    SqlConnection con;
    SqlCommand cmd;
    DataSet dtuser = new DataSet();
    AppSession aps = new AppSession();
    public string ADCODE_ID = "";
    ErrorLogs er = new ErrorLogs();
    DataSet ds = new DataSet();
   
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public int i,Update_Id;
    public string AUTO_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
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
            Load_AcType();
            Load_Currency();
            EditSupDetails();          
        }
       

       // txt_LicenseCurrency.Attributes.Add("onblur", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txt_LicenseCurrency.ClientID + "', '" + txt_Exrate.ClientID + "')");
    }


    public void Load_AcType()
    {
        ddlAcType.Items.Clear();
        ddlAcType.Items.Add("Current");
        ddlAcType.Items.Add("Savings");        
    }

    public void Load_Currency()
    {
        ddlCurrency.Items.Clear();
        ddlCurrency.Items.Add("INR");
        ddlCurrency.Items.Add("USD");        
        ddlCurrency.Items.Add("HKD");
        ddlCurrency.Items.Add("JPY");
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

    public void EditSupDetails()
    {
        if (Request.QueryString["BANK_ID"] != "" && Request.QueryString["BANK_ID"] != null)
        {

            //txtLicense_No.Enabled = false;
            ADCODE_ID = Request.QueryString["BANK_ID"];

            erm.BANK_ID = ADCODE_ID;
            //erm.LICENSE_NO = "0";
            erm.Ename = "select_conwithcode";
            erm.EWorking_Period = Working_Period;

            dtuser = erm.RetrieveAll_Bank_MASTER();
            if (dtuser.Tables[0].Rows.Count > 0)
            {

                txtBankName.Text = dtuser.Tables[0].Rows[0]["BANK_NAME"].ToString();
                txtBranchName.Text = dtuser.Tables[0].Rows[0]["BRANCH_NAME"].ToString();
               
                txtStateName.Text = dtuser.Tables[0].Rows[0]["STATE"].ToString();
                txt_AcNo.Text = dtuser.Tables[0].Rows[0]["ACCOUNT_NUMBER"].ToString();
                txtISCFCode.Text = dtuser.Tables[0].Rows[0]["IFSC_CODE"].ToString();

                string ACCOUNT_TYPE = dtuser.Tables[0].Rows[0]["ACCOUNT_TYPE"].ToString();
                Load_AcType();
                //ddl_Excemption.Items.Add("E");
                ddlAcType.Items.Remove(ACCOUNT_TYPE);
                ddlAcType.Items.Insert(0, ACCOUNT_TYPE);

                string CURRENCY = dtuser.Tables[0].Rows[0]["CURRENCY"].ToString();
                //ddl_Lic_Type.Items.Clear();
                Load_Currency();
                ddlCurrency.Items.Remove(CURRENCY);
                ddlCurrency.Items.Insert(0, CURRENCY);

              
                txtContactPerson.Text = dtuser.Tables[0].Rows[0]["CONTACT_PERSON"].ToString();
               
                txtAdd1.Text = dtuser.Tables[0].Rows[0]["ADDRESS1"].ToString();
                txtAdd2.Text = dtuser.Tables[0].Rows[0]["ADDRESS2"].ToString();
               
                txtPinCode.Text = dtuser.Tables[0].Rows[0]["PINCODE"].ToString();
                txtSwiftCode.Text = dtuser.Tables[0].Rows[0]["SWIFT_CODE"].ToString();
                txtADCode.Text = dtuser.Tables[0].Rows[0]["AD_CODE"].ToString();
                txtCity.Text = dtuser.Tables[0].Rows[0]["CITY"].ToString();
               
                txtOpenBalance.Text = dtuser.Tables[0].Rows[0]["OPENING_BALANCE"].ToString();
                txtContact_No.Text = dtuser.Tables[0].Rows[0]["CONTACT_NO"].ToString();



                txtEmailID.Text = dtuser.Tables[0].Rows[0]["EMAIL_ID"].ToString();
                txtPrefix.Text = dtuser.Tables[0].Rows[0]["PREFIX"].ToString();
                txtSuffix.Text = dtuser.Tables[0].Rows[0]["SUFFIX"].ToString();
                txt_AcHolder.Text = dtuser.Tables[0].Rows[0]["ACCOUNT_HOLDER"].ToString();
               
                hdn_Update_Adcode.Value = txtADCode.Text;
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["BANK_ID"].ToString();
                //FOR UPDATED SUCCESSFULLY
            }
            HiddenField1.Value = Request.QueryString["BANK_ID"].ToString();
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
        }
        else
        {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;           
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
        i= erm.result;
        HiddenField1.Value = Convert.ToString(erm.UPDATE_ID);

        if (a2 == "S")
        {
            if (i == 1)
            {
                if (click_SaveNew == "SaveNew_Click")
                {
                    txtBankName.Focus();
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
                Alert_msg("IFSC Code already exixts!", "btnSave");
            }
                 else if (i == 3)
            {
                Alert_msg("Account No already exixts!", "btnSave");
            }
            else if (i == 4)
            {
                Alert_msg("Bank Name already exixts!", "btnSave");
            }
            else
            {
                Alert_msg("Account No Not Saved", "btnNew");
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
                Alert_msg("Account No already exixts!", "btnUpdate");
            }
            else if (i == 3)
            {
                Alert_msg("IFSC Code already exixts!", "btnSave");
            }
            else
            {
                Alert_msg("Account No Not Saved", "btnUpdate");
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

            Inner_InsertUpdate(Request.QueryString["BANK_ID"], "U");
                       
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    public int insert_update(string a1, string a2, string a3)
    {
        //erm.BANK_ID = a1;
        
       erm.BANK_ID= a1;
       erm.BANK_NAME = txtBankName.Text;
       erm.BRANCH_NAME = txtBranchName.Text;//txtBankName.Text;
       erm.ACCOUNT_NO = txt_AcNo.Text;
       erm.ACCOUNT_TYPE = ddlAcType.SelectedItem.ToString();
       erm.IFSC_CODE = txtISCFCode.Text;
       erm.ADDRESS1 = txtAdd1.Text;
       erm.ADDRESS2 = txtAdd2.Text;
       erm.CITY = txtCity.Text;
       erm.STATE = txtStateName.Text;
       erm.PINCODE = txtPinCode.Text;
       erm.SWIFT_CODE = txtSwiftCode.Text;
       erm.AD_CODE = txtADCode.Text;
       erm.CURRENCY = ddlCurrency.SelectedItem.ToString();
       erm.OPENING_BALANCE = txtOpenBalance.Text;
       erm.CONTACT_PERSON = txtContactPerson.Text;
       erm.CONTACT_NO = txtContact_No.Text;
       erm.EMAIL_ID = txtEmailID.Text;
       erm.PREFIX = txtPrefix.Text;
       erm.SUFFIX = txtSuffix.Text;
       erm.ACCOUNT_HOLDER = txt_AcHolder.Text; 

       erm.USER_ID = currentuser;
       erm.DATE_TIME = LoginDate;
       erm.STATUS = "N";
       erm.BRANCH_CODE = currentbranch;
       erm.YEAR = a3;
       erm.WORKING_PERIOD = Working_Period;
       erm.MODIFIEDBY = currentuser;
       erm.MODIFIEDON = LoginDate;
       erm.flag = a2;



       i = erm.Bank_Master_Insert_update();
        return i;
    }

    

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            erm.BANK_ID = HiddenField1.Value;
            //erm.LICENSE_NO = "0";
            erm.Ename = "delete";
            erm.EWorking_Period = Working_Period;

            //erm.RetrieveAll_IMPORT_LICENSE_MASTER();

            erm.RetrieveAll_Bank_MASTER();
            int ii = 0;
            ii = erm.result;

            if (ii > 0)
            {
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Adcode Deleted')</script>", false);
                string prompt = "<script>$(document).ready(function(){{jAlert('Bank Details Deleted', 'BANK MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);           
            }
            else
            {
                Alert_msg("Bank Details Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Session["BANK_ID"] = "";

        Clear();
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
        txtAdd1.Text = "";
        txtAdd1.Focus();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BANK MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BANK MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
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