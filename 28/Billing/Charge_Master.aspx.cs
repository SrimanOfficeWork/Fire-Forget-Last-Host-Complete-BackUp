using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Billing_Charge_Master : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    Charge_Master charge = new Charge_Master();

    DataSet dtuser = new DataSet();
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string CHARGE_ID = "";
    ErrorLogs er = new ErrorLogs();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
   
    public int i, Update_Id;
    public string AUTO_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int ii = 0;
    public int Screen_Id;
    public string MAX_CHARGE_CODE;
    public string SELECT_TYPE, SELECT_BRANCH;

    public bool chk = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();

        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }

        if (!IsPostBack)
        {
            ddlTax_NonTax.Items.Clear();
            ddlTax_NonTax.Items.Add("T");
            ddlTax_NonTax.Items.Add("N");


            ddlCharge_Type.Items.Clear();
            ddlCharge_Type.Items.Add("Income");
            ddlCharge_Type.Items.Add("Expense");
            ddlCharge_Type.Items.Add("Both");

            Edit_ChargeDetails();

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

    public void Max_ChargeCode()
    {
        charge.CHARGE_ID = "";
        charge.CHARGE_NAME = "0";
        charge.CHARGE_CODE = "";
        charge.Ename = "Select_max_ChargeId";
        charge.WORKING_PERIOD = Working_Period;

        dtuser = charge.RetrieveAll_Charge_Master();

        ii = charge.result;

        if (ii == 1)
        {
            MAX_CHARGE_CODE = dtuser.Tables[0].Rows[0]["CHARGE_CODE"].ToString();
            txtCharge_Code.Text = MAX_CHARGE_CODE;
        }
    }

    public void Edit_ChargeDetails()
    {
        if (Request.QueryString["CHARGE_ID"] != "" && Request.QueryString["CHARGE_ID"] != null)
        {
            CHARGE_ID = Request.QueryString["CHARGE_ID"];
            ViewState["CHARGE_ID"] = CHARGE_ID;

            charge.CHARGE_ID = CHARGE_ID;
            charge.CHARGE_NAME = "0";
            charge.CHARGE_CODE = txtCharge_Code.Text;
            charge.Ename = "select_conwithcode";
            charge.WORKING_PERIOD = Working_Period;

            dtuser = charge.RetrieveAll_Charge_Master();
            if (dtuser.Tables[0].Rows.Count > 0)
            {

                txtCharge_Code.Text = dtuser.Tables[0].Rows[0]["CHARGE_CODE"].ToString();
                txtCharge_Name.Text = dtuser.Tables[0].Rows[0]["CHARGE_NAME"].ToString();

                string tax_mode = dtuser.Tables[0].Rows[0]["TAX_MODE"].ToString();             
                ddlTax_NonTax.Items.Clear();
                ddlTax_NonTax.Items.Add("T");
                ddlTax_NonTax.Items.Add("N");
                ddlTax_NonTax.Items.Remove(tax_mode);
                ddlTax_NonTax.Items.Insert(0, tax_mode);

                string charge_type = dtuser.Tables[0].Rows[0]["CHARGE_TYPE"].ToString();
                ddlCharge_Type.Items.Clear();
                ddlCharge_Type.Items.Add("Income");
                ddlCharge_Type.Items.Add("Expense");
                ddlCharge_Type.Items.Add("Both");
                ddlCharge_Type.Items.Remove(charge_type);
                ddlCharge_Type.Items.Insert(0, charge_type);
                txtDescription.Text = dtuser.Tables[0].Rows[0]["DESCRIPTION"].ToString();

                chkQuotation.Checked = Convert.ToBoolean(dtuser.Tables[0].Rows[0]["ALLOW_QUOTATION"].ToString());
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["CHARGE_ID"].ToString();
                //FOR UPDATED SUCCESSFULLY


            }
            HiddenField1.Value = Request.QueryString["CHARGE_ID"].ToString();
          
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;


        }
        else
        {
            Max_ChargeCode();
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
            string a1 = "";
            string a2 = "S";
            string a3 = "";
            i = insert_update(a1, a2, a3);
            HiddenField1.Value = Convert.ToString(charge.UPDATE_ID);

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
                }
                //-----------------------FOR USER RIGHTS--------------------------------//
                ViewState["UPDATED_ID"] = null;
                Alert_msg("Saved Successfully", "btnSave");
            }
            else if (i == 2)
            {
                Alert_msg("Charge already exixts!", "btnSave");
            }
            else
            {
                Alert_msg("Charge Not Saved", "btnNew");
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public int insert_update(string a1, string a2, string a3)
    {
        
        charge.CHARGE_ID = a1;
        charge.CHARGE_CODE = txtCharge_Code.Text;
        charge.CHARGE_NAME = txtCharge_Name.Text;
        charge.TAX_MODE = ddlTax_NonTax.SelectedValue.ToString(); ;
        charge.CHARGE_TYPE = ddlCharge_Type.SelectedValue.ToString();
        charge.DESCRIPTION = txtDescription.Text;
        charge.CREATED_BY = currentuser;
        charge.MODIFIED_BY = currentuser;
        charge.BRANCH_CODE = currentbranch;
        charge.flag = a2;
        charge.YEAR = a3;
        charge.WORKING_PERIOD = Working_Period;
        chk = chkQuotation.Checked;

        charge.ALLOW_QUOTATION = chk.ToString();
        charge.BRANCH_COMMON = SELECT_BRANCH;
        i = charge.Charge_Master_Insert_update();
        return i;
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CHARGE MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CHARGE MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            charge.CHARGE_ID = ViewState["CHARGE_ID"].ToString();
            charge.CHARGE_NAME = "0";
            charge.CHARGE_CODE = txtCharge_Code.Text;
            charge.Ename = "delete";
            charge.WORKING_PERIOD = Working_Period;

            dtuser = charge.RetrieveAll_Charge_Master();

            ii = charge.result;

            if (ii > 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Charge Deleted', 'CHARGE MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("Charge Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Session["CHARGE_ID"] = "";
        
        Clear();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        hdn_Update_Adcode.Value = "";
        ViewState["UPDATED_ID"] = null;
        Max_ChargeCode();

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtCharge_Code.Text != "" && txtCharge_Name.Text != "")
        {

            try
            {
                string a1 = HiddenField1.Value;
                string a2 = "U";
                string a3 = "";
                i = insert_update(a1, a2, a3);
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
                    Alert_msg("Charge Code already exixts!", "btnUpdate");
                }
                else
                {
                    Alert_msg("Charge Not Saved", "btnUpdate");
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
}