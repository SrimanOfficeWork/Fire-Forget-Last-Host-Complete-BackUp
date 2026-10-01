using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;

public partial class Billing_Charge_Master : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();

    Global_variables ObjUBO = new Global_variables();
    Income_Charge_cs CH = new Income_Charge_cs();
   
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int i, Update_Id, Screen_Id;
    public bool chk = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!IsPostBack)
        {
            Load_Under();
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
    private void Load_Under()
    {
        try
        {
            DataSet dss = new DataSet();
            ddl_Group_Name.Items.Clear();
            ObjUBO.A2 = "Under_Select";
            dss = CH.Charge_Master_Select(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddl_Group_Name.DataSource = dss.Tables[0];
                ddl_Group_Name.DataTextField = "SUB_GROUP_NAME";
                ddl_Group_Name.DataValueField = "SUB_GROUP_NAME";
                ddl_Group_Name.DataBind();
            }
            ddl_Group_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Group_Name.SelectedIndex = 0;

            if (dss.Tables[0].Rows.Count > 0)
            {
                ddl_Charge_Name.DataSource = dss.Tables[1];
                ddl_Charge_Name.DataTextField = "LEDGER_NAME";
                ddl_Charge_Name.DataValueField = "LEDGER_NAME";
                ddl_Charge_Name.DataBind();
            }
            ddl_Charge_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Charge_Name.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void Edit_ChargeDetails()
    {
        DataSet ds = new DataSet();
        if (Request.QueryString["CHARGE_ID"] != "" && Request.QueryString["CHARGE_ID"] != null)
        {
            ddl_Charge_Name.Items.Clear();
            ddl_Charge_Name.Enabled = false;
            ObjUBO.A1 = Request.QueryString["CHARGE_ID"].ToString();
            ObjUBO.A2 = "Update_Data_Select";
            ds = CH.Charge_Master_Select(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Charge_Name.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["CHARGE_NAME"].ToString(), ds.Tables[0].Rows[0]["CHARGE_NAME"].ToString()));
                ddl_Charge_Name.SelectedIndex = 0;

                txtDescription.Text = ds.Tables[0].Rows[0]["CHARGE_DESC"].ToString();
                ddlTax_NonTax.SelectedValue=ds.Tables[0].Rows[0]["TAX_MODE"].ToString();
                txt_HSN_Code.Text=ds.Tables[0].Rows[0]["HSN_CODE"].ToString();
                txt_SA_Code.Text=ds.Tables[0].Rows[0]["SA_CODE"].ToString();
                txt_CGST_Rate.Text = ds.Tables[0].Rows[0]["CGST_RATE"].ToString();
                txt_SGST_Rate.Text =ds.Tables[0].Rows[0]["SGST_RATE"].ToString();
                txt_IGST_Rate.Text = ds.Tables[0].Rows[0]["IGST_RATE"].ToString();
                chk_Status.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ACTIVE"].ToString());

                chkQuotation.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ALLOW_QUOTATION"].ToString());
                ddl_Group_Name.SelectedValue = ds.Tables[0].Rows[0]["GROUP_NAME"].ToString();
                ddlSales_Trans.SelectedValue = ds.Tables[0].Rows[0]["NATURE_OF_TRANS"].ToString();

                txt_Debit_Amt.Text = ds.Tables[0].Rows[0]["DEBIT_AMT"].ToString();
                txt_Credit_Amt.Text = ds.Tables[0].Rows[0]["CREDIT_AMT"].ToString();
               
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["CHARGE_ID"].ToString();
                //FOR UPDATED SUCCESSFULLY
            }

            HDupdate_id.Value = Request.QueryString["CHARGE_ID"].ToString();
          
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            i = insert_update("", "S");
            HDupdate_id.Value = Convert.ToString(CH.UPDATE_ID);

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
            Connection.Error_Msg(ex.Message);
        }
    }

    public int insert_update(string a1, string a2)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = ddl_Charge_Name.SelectedValue.ToString(); 
        ObjUBO.A3 = txtDescription.Text;
        ObjUBO.A4 = ddlTax_NonTax.SelectedValue.ToString();
        ObjUBO.A5 = txt_HSN_Code.Text;
        ObjUBO.A6 = txt_SA_Code.Text;
        chk = chkQuotation.Checked;
        ObjUBO.A15 = chk.ToString();
        
        ObjUBO.A11 = ddl_Group_Name.SelectedValue.ToString();
        ObjUBO.A12 = ddlSales_Trans.SelectedValue.ToString();
        ObjUBO.A13 = txt_Debit_Amt.Text;
        ObjUBO.A14 = txt_Credit_Amt.Text;

        ObjUBO.A7 = txt_CGST_Rate.Text;
        ObjUBO.A8 = txt_SGST_Rate.Text;
        ObjUBO.A9 = txt_IGST_Rate.Text;
        ObjUBO.A10 = chk_Status.Checked == true ? "T" : "F";

        ObjUBO.A25 = a2;
        CH.Charge_INS_UPD(ObjUBO);
        i = CH.result;
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
            i = insert_update(HDupdate_id.Value.ToString(), "D");
            if (i==1)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Charge Deleted', 'CHARGE MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else if (i == 2)
            {
                Alert_msg("Charge already used in invoice. Deletion not allowed.");

            }
            else
            {
                Alert_msg("Charge Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Clear();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        HDupdate_id.Value = "";
        ViewState["UPDATED_ID"] = null;
        Load_Under();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
            try
            {
                i = insert_update(HDupdate_id.Value.ToString(), "U");
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
                    Alert_msg("Charge Name already exixts!", "btnUpdate");
                }
                else
                {
                    Alert_msg("Charge Not Saved", "btnUpdate");
                }

            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }

    }
    public void Clear()
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
    }
}