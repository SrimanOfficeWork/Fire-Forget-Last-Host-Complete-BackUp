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


public partial class eRoyalMasters_Adcode_Master : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    SqlConnection con;
    SqlCommand cmd;
    DataSet dtuser = new DataSet();
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string ADCODE_ID = "";
    public string ADCODE_IEC, ADCODE_NAME, ADCODE_BRSL;
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    string SP_QUERY;
    Default_Settings Default = new Default_Settings();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public int i, Update_Id;
    public string AUTO_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    public int Screen_Id;

    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        // if (!Page.IsPostBack)
        // Response.AppendHeader("Refresh", ((Session.Timeout * 3) +3).ToString() + "; Url=../LoginPage/Default.aspx?from=expired");
        txtIec_Code.Focus();
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        //To avoid Postback in IEC CODE
        // hdn_check_adcode.Value = "";
        // hdn_check_adcode.Value=txtIec_Name.Text;
        //To avoid Postback in IEC CODE

        if (!IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 4;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
            //auto search

            //txtIec_Code.Attributes.Add("onkeyup", "javascript:Call_Client_Name('" + txtIec_Code.ClientID + "', '" + txtIec_Name.ClientID + "')");
            //txtIec_Code.Attributes.Add("onblur", "javascript:Call_Client_Name('" + txtIec_Code.ClientID + "', '" + txtIec_Name.ClientID + "')");
            //auto search

            if (!string.IsNullOrEmpty(Request["Name"]))
            {
                txtIec_Name.Text = Request.QueryString["Name"].ToString();
            }
            if (!string.IsNullOrEmpty(Request["IEC"]))
            {
                txtIec_Code.Text = Request.QueryString["IEC"].ToString();
            }
            if (!string.IsNullOrEmpty(Request["brslo"]))
            {
                txt_BranchSlNo.Text = Request.QueryString["brslo"].ToString();
            }

            // EditSupDetails();
            // Get_Client_Default_Settings();



            if (!string.IsNullOrEmpty(Request["IEC"]))
            {
                EditAdcode_Details_IECwise();
            }
            else
            {
                EditADcode_Details();
                Get_Client_Default_Settings();
            }

        }
    }

    //*** adcode type***********//
    /*   public void ddl_type()
       {
           ddlType.Items.Clear();
           ddlType.Items.Add("Both");
           ddlType.Items.Add("Import");
           ddlType.Items.Add("Export");

           ddlType.Items.Clear();

        }*/

    public void Page_Rights(int i)
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }



    public void EditADcode_Details()
    {
        try
        {
            if (Request.QueryString["ADCODE_ID"] != "" && Request.QueryString["ADCODE_ID"] != null)
            {
                hdn_new_update.Value = "Update";
                ADCODE_ID = Request.QueryString["ADCODE_ID"];
                erm.Eadcodeid = ADCODE_ID;
                erm.Eadcode_iec_name = "0";
                erm.Ename = "select_conwithcode";
                erm.EWorking_Period = Working_Period;

                dtuser = erm.RetrieveAll_Adcode_MASTER();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtIec_Code.Text = dtuser.Tables[0].Rows[0]["ADCODE_IEC_CODE"].ToString();
                    txtIec_Name.Text = dtuser.Tables[0].Rows[0]["ADCODE_IEC_NAME"].ToString();
                    txtAdcode.Text = dtuser.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                    txtImportAdcode.Text = dtuser.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString();
                    txtBankName.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_NAME"].ToString();
                    txtIfsccode.Text = dtuser.Tables[0].Rows[0]["ADCODE_IFSC_CODE"].ToString();
                    txtBankAccountNo.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();
                    txtAddress1.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_ADD1"].ToString();
                    txtAddress2.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_ADD2"].ToString();
                    txtCity.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_CITY"].ToString();
                    txtStateName.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_STATE"].ToString();
                    txtPincode.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_PIN_CODE"].ToString();
                    txtRemarks.Text = dtuser.Tables[0].Rows[0]["ADCODE_REMARKS"].ToString();
                    txt_BranchSlNo.Text = dtuser.Tables[0].Rows[0]["ADCODE_BRANCH_SLNO"].ToString();
                    hdn_Update_Adcode.Value = txtAdcode.Text;
                    //FOR UPDATED SUCCESSFULLY
                    ViewState["UPDATED_ID"] = null;
                    ViewState["UPDATED_ID"] = Request.QueryString["ADCODE_ID"].ToString();
                    //FOR UPDATED SUCCESSFULLY

                    if (txtAdcode.Text == txtImportAdcode.Text)
                    {
                        hdn_Update_Val.Value = "Equal";
                    }
                    else
                    {
                        hdn_Update_Val.Value = "NotEqual";
                    }
                }
                HiddenField1.Value = Request.QueryString["ADCODE_ID"].ToString();
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                hdn_new_update.Value = "New";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }

    public void EditAdcode_Details_IECwise()
    {
        try
        {
            if (Request.QueryString["IEC"] != "" && Request.QueryString["IEC"] != null)
            {

                ADCODE_IEC = Request.QueryString["IEC"];
                ADCODE_NAME = Request.QueryString["Name"];
                ADCODE_BRSL = Request.QueryString["brslo"];
                erm.ADCODE_IEC_CODE = ADCODE_IEC;
                erm.Eadcode_iec_name = ADCODE_NAME;
                erm.Eadcodeid = ADCODE_BRSL;
                erm.Ename = "select_iec_adcode";
                erm.EWorking_Period = Working_Period;

                dtuser = erm.RetrieveAll_Adcode_MASTER();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtIec_Code.Text = dtuser.Tables[0].Rows[0]["ADCODE_IEC_CODE"].ToString();
                    txtIec_Name.Text = dtuser.Tables[0].Rows[0]["ADCODE_IEC_NAME"].ToString();
                    txtAdcode.Text = dtuser.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                    txtImportAdcode.Text = dtuser.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString();
                    txtBankName.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_NAME"].ToString();
                    txtIfsccode.Text = dtuser.Tables[0].Rows[0]["ADCODE_IFSC_CODE"].ToString();
                    txtBankAccountNo.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();
                    txtAddress1.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_ADD1"].ToString();
                    txtAddress2.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_ADD2"].ToString();
                    txtCity.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_CITY"].ToString();
                    txtStateName.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_STATE"].ToString();
                    txtPincode.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_PIN_CODE"].ToString();
                    txtRemarks.Text = dtuser.Tables[0].Rows[0]["ADCODE_REMARKS"].ToString();
                    txt_BranchSlNo.Text = dtuser.Tables[0].Rows[0]["ADCODE_BRANCH_SLNO"].ToString();

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
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                hdn_new_update.Value = "New";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }


    public void Clear()
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (txtIec_Name.Text != "" && txtAdcode.Text != "")
        //{
        try
        {
            string a1 = "";
            string a2 = "S";
            string a3 = "";
            i = insert_update(a1, a2, a3);
            HiddenField1.Value = Convert.ToString(erm.UPDATE_ID);

            if (i == 1)
            {
                //-----------------------FOR USER RIGHTS--------------------------------//
                user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);

                PAGE_MODIFY = user_Create.PAGE_MODIFY;
                //---------------SAVE ONLY------------------//

                if (PAGE_MODIFY == "False")
                {
                    btnNew_Click(sender, e);
                }
                else
                {
                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnSave.Focus();
                    hdn_Update_Adcode.Value = txtAdcode.Text;

                    Load_Elogix_Service("S");
                }
                //-----------------------FOR USER RIGHTS--------------------------------//

                ViewState["UPDATED_ID"] = null;
                Alert_msg("Saved Successfully", "btnSave");
            }
            else if (i == 2)
            {

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Adcode already exixts!')</script>", false);
                Alert_msg("Adcode already exixts!", "btnSave");

                //btnSave.Focus();
            }
            else
            {

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Adcode Not Saved')</script>", false);
                Alert_msg("Adcode Not Saved", "btnNew");

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);

        //}
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtIec_Name.Text != "" && (txtAdcode.Text != "" || txtImportAdcode.Text != ""))
        {

            try
            {
                string a1 = HiddenField1.Value;
                string a2 = "U";
                string a3 = "";
                i = insert_update(a1, a2, a3);
                if (i == 1)
                {
                    hdn_Update_Adcode.Value = txtAdcode.Text;
                    if (ViewState["UPDATED_ID"] != null)
                    {
                        Alert_msg("Updated Successfully", "btnUpdate");
                        Load_Elogix_Service("U");
                    }
                    else
                    {
                        Alert_msg("Saved Successfully", "btnUpdate");

                    }
                }
                else if (i == 2)
                {
                    Alert_msg("Adcode already exixts!", "btnUpdate");
                }
                else
                {
                    Alert_msg("Adcode Not Saved", "btnUpdate");
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Field", txtAdcode.Text);
        }

    }
    public int insert_update(string a1, string a2, string a3)
    {
        try
        {
            erm.ADCODE_ID = a1;
            erm.ADCODE_IEC_ADCODE = txtAdcode.Text;
            erm.IMPORT_ADCODE = txtImportAdcode.Text;
            erm.ADCODE_IEC_CODE = txtIec_Code.Text;
            erm.ADCODE_IEC_NAME = txtIec_Name.Text;
            erm.ADCODE_BANK_STATE = txtStateName.Text;
            erm.ADCODE_BANK_PIN_CODE = txtPincode.Text;
            erm.ADCODE_BANK_NAME = txtBankName.Text;
            erm.ADCODE_IFSC_CODE = txtIfsccode.Text;
            erm.ADCODE_BANK_CITY = txtCity.Text;
            erm.ADCODE_BANK_ADD1 = txtAddress1.Text;
            erm.ADCODE_BANK_ADD2 = txtAddress2.Text;
            erm.ADCODE_BANK_ACCOUNT_NO = txtBankAccountNo.Text;
            erm.ADCODE_REMARKS = txtRemarks.Text;
            erm.USER_ID = currentuser;
            erm.BRANCH_CODE = currentbranch;
            erm.flag = a2;
            erm.YEAR = a3;
            erm.EWorking_Period = Working_Period;
            erm.ADCODE_BRANCH_SLNO = txt_BranchSlNo.Text;

            i = erm.Adcode_Master_Insert_update();         
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        return i;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            erm.Eadcodeid = HiddenField1.Value;
            erm.Eadcode_iec_name = "0";
            erm.Ename = "delete";
            erm.EWorking_Period = Working_Period;

            erm.RetrieveAll_Adcode_MASTER();
            int ii = 0;
            ii = erm.result;

            if (ii > 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Adcode Deleted', 'ADCODE MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("Adcode Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            Session["ADCODE_ID"] = "";
            Clear();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = true;
            btnSave.Visible = true;
            hdn_Update_Adcode.Value = "";
            ViewState["UPDATED_ID"] = null;
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }

    protected void txtAdcode_TextChanged(object sender, EventArgs e)
    {
        if (hdn_Update_Adcode.Value != txtAdcode.Text)
        {
            try
            {
                erm.Eadcodeid = "0";
                erm.ADCODE_IEC_ADCODE = txtAdcode.Text;
                erm.ADCODE_IEC_CODE = txtIec_Code.Text;
                erm.Eadcode_iec_name = txtIec_Name.Text;
                erm.Ename = "Check_Adcode";
                erm.EWorking_Period = Working_Period;

                dtuser = erm.RetrieveAll_Adcode_MASTER();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    Alert_msg("Adcode already exists!");
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
            }
        }
    }

    protected void txtImportAdcode_TextChanged(object sender, EventArgs e)
    {
        if (hdn_Update_Adcode.Value != txtImportAdcode.Text)
        {
            try
            {
                erm.Eadcodeid = "0";
                erm.ADCODE_IEC_ADCODE = txtImportAdcode.Text;
                erm.ADCODE_IEC_CODE = txtIec_Code.Text;
                erm.Eadcode_iec_name = txtIec_Name.Text;
                erm.Ename = "Check_Import_Adcode";
                erm.EWorking_Period = Working_Period;

                dtuser = erm.RetrieveAll_Adcode_MASTER();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    Alert_msg("Import Adcode already exists!", "txtBankName");
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
            }
        }
        txtBankName.Focus();
    }

    protected void txtIec_Code_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtIec_Code.Text.Length == 10)
            {
                string g = "";
                erm.Eadcodeid = "0";
                erm.Eimp_exp_iecno = txtIec_Code.Text;
                erm.Ename = "select_iecname";
                erm.STANDARD_TYPE = Hdn_STANDARD_TYPE.Value;
                dtuser = erm.RetrieveAll_Imp_exp_master_STD_TYPE();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtIec_Name.Text = dtuser.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                }
                else
                {
                    txtIec_Name.Text = "";
                }
            }
            else
            {
                Alert_msg("IEC code  Should be 10 digit numbers");
            }
            txtIec_Name.Focus();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
      
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ADCODE MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ADCODE MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Get_Client_Default_Settings()
    {
        try
        {
            DataSet ds = new DataSet();
            Default.STANDARD_TYPE = "";
            Default.USER_ID = currentuser;
            Default.BRANCH_CODE = currentbranch;
            Default.YEAR = "";
            Default.WORKING_PERIOD = Working_Period;
            Default.BRANCH_COMMON = "";
            Default.flag = "Get_Details";

            ds = Default.Client_DefaultSettings_Insert_Update();

            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["STANDARD_TYPE"] = ds.Tables[0].Rows[0]["STANDARD_TYPE"].ToString();
                Hdn_STANDARD_TYPE.Value = ds.Tables[0].Rows[0]["STANDARD_TYPE"].ToString();
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message); 
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }
    private void Load_Elogix_Service(string E_Flag)
    {
        try
        {
            string E_Logix_Company_Id_Chennai = Connection.e_lOGIX_CHENNAI();
            string E_Logix_Company_Id_Mumbai = Connection.e_lOGIX_MUMBAI();

            if (E_Logix_Company_Id_Chennai != string.Empty)
            {
                IMPL_CHENNAI.ELogiX obj = new IMPL_CHENNAI.ELogiX();
                obj.Ad_Code_Master(
                     txtAdcode.Text
                    , txtImportAdcode.Text
                    , txtIec_Code.Text
                    , txtIec_Name.Text
                    , txtStateName.Text
                    , txtPincode.Text
                    , txtBankName.Text
                    , txtCity.Text
                    , txtAddress1.Text
                    , txtAddress2.Text
                    , txtBankAccountNo.Text
                    , txtRemarks.Text
                    , txt_BranchSlNo.Text
                    , "AD"
                    , Connection.Company_License()
                    , E_Flag
                    , Connection.Current_User()
                    );
            }
            else if (E_Logix_Company_Id_Mumbai != string.Empty)
            {
                IMPL_MUMBAI.ELOGIX_CS obj = new IMPL_MUMBAI.ELOGIX_CS();
                // obj.Ad_Code_Master(txtName.Text, txtAdd1.Text, txtAdd2.Text, txtAdd3.Text, txtCountryCode.Text, "B", E_Logix_Company_Id_Mumbai, E_Flag, Connection.Current_User());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
}