using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;

public partial class Billing_Charge_Master : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
    
    Billing_UserBO ObjUBO = new Billing_UserBO();
    GST_Charge_Master CH = new GST_Charge_Master();
   
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int i, Update_Id, Screen_Id;
    public bool chk = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!IsPostBack)
        {
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

   

    public void Edit_ChargeDetails()
    {
        DataSet ds = new DataSet();
        if (Request.QueryString["CHARGE_ID"] != "" && Request.QueryString["CHARGE_ID"] != null)
        {
            txtCharge_Name.Attributes.Add("readonly", "readonly");

            ObjUBO.ID = Request.QueryString["CHARGE_ID"].ToString();
            ObjUBO.Flag = "Update_Data_Select";
            ds = CH.Charge_Master_Select(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {

                txtCharge_Name.Text=ds.Tables[0].Rows[0]["CHARGE_NAME"].ToString();
                txtDescription.Text = ds.Tables[0].Rows[0]["CHARGE_DESC"].ToString();
                ddlTax_NonTax.SelectedValue=ds.Tables[0].Rows[0]["TAX_MODE"].ToString();
                txt_HSN_Code.Text=ds.Tables[0].Rows[0]["HSN_CODE"].ToString();
                txt_SA_Code.Text=ds.Tables[0].Rows[0]["SA_CODE"].ToString();
                txt_CGST_Rate.Text = ds.Tables[0].Rows[0]["CGST_RATE"].ToString();
                txt_SGST_Rate.Text =ds.Tables[0].Rows[0]["SGST_RATE"].ToString();
                txt_IGST_Rate.Text = ds.Tables[0].Rows[0]["IGST_RATE"].ToString();
                //ddlshipment_type.SelectedValue = ds.Tables[0].Rows[0]["SHIPMENT_TYPE"].ToString();
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
        ObjUBO.ID = HDupdate_id.Value.ToString();
        ObjUBO.CHARGE_NAME = txtCharge_Name.Text;
        ObjUBO.CH_DESCRIPTION = txtDescription.Text;
        ObjUBO.Tax_Mode = ddlTax_NonTax.SelectedValue.ToString();
        ObjUBO.HSN_CODE = txt_HSN_Code.Text;
        ObjUBO.SA_CODE = txt_SA_Code.Text;
        chk = chkQuotation.Checked;
        ObjUBO.ALLOW_QUOTATION = chk.ToString();
        ObjUBO.Flag = a2;
        ObjUBO.SHIPPER_ADDRESS = ddl_Group_Name.SelectedValue.ToString();
        ObjUBO.CONSIGNEE_ADDRESS = ddlSales_Trans.SelectedValue.ToString();
        ObjUBO.ADVANCE_AMT = txt_Debit_Amt.Text;
        ObjUBO.EXPENSE_AMT = txt_Credit_Amt.Text;

        ObjUBO.CGST_RATE = txt_CGST_Rate.Text;
        ObjUBO.SGST_RATE = txt_SGST_Rate.Text;
        ObjUBO.IGST_RATE = txt_IGST_Rate.Text;
        ObjUBO.SHIPMENT_TYPE = chk_Status.Checked == true ? "T" : "F";
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
            if (i > 0)
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

        txtCharge_Name.Attributes.Remove("readonly");
        txtCharge_Name.Style.Add("background-color", "white");
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