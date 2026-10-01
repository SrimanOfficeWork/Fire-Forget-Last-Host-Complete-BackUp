using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BussinessObject;
using System.Net;

public partial class Acc_Charge_Master : ThemeClass
{

    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();

    Global_variables ObjUBO = new Global_variables();
    Income_Charge_cs CH = new Income_Charge_cs();

    DataSet ds = new DataSet();

    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int i, Update_Id, Screen_Id;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
         {
             txtCharge_Name.Focus();

             Rd_I_IE_Ledg.Items[3].Attributes.Add("style", "color:red;");
             Rd_E_IE_Ledg.Items[3].Attributes.Add("style", "color:red;");
             Rd_G_IE_Ledg.Items[3].Attributes.Add("style", "color:red;");

             Rd_Charge_AI.Items[1].Attributes.Add("style", "color:red;");
             if (Request.QueryString["CHARGE_ID"] != "New")
             {
                 Edit_ChargeDetails();
             }
             else
             {
                 btnDelete.Visible = false;
                 btnUpdate.Visible = false;
                 btnSave.Visible = true;
             }
         }
       
    }
    public void Edit_ChargeDetails()
    {
        DataSet ds = new DataSet();
            txtCharge_Name.Attributes.Add("readonly", "readonly");
            HDupdate_id.Value = "";
            ObjUBO.A1 = Request.QueryString["CHARGE_ID"].ToString();
            ObjUBO.A5 = "Update_Data_Select";

            ds = CH.Charge_Data_Search(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                  HDupdate_id.Value = ds.Tables[0].Rows[0]["ID"].ToString();
                  txtCharge_Name.Text = ds.Tables[0].Rows[0]["CHARGE_NAME"].ToString();
                  Rd_Hsn_Sac.SelectedValue= ds.Tables[0].Rows[0]["HSN_SAC"].ToString();
                  txt_HSN_SAC_Code.Text = ds.Tables[0].Rows[0]["HSN_SAC_CODE"].ToString();
                  Rd_Ch_Cat.SelectedValue= ds.Tables[0].Rows[0]["CHARGE_CATEGORY"].ToString();
                  Rd_Tax_Cat.SelectedValue= ds.Tables[0].Rows[0]["TAX_MODE"].ToString();
                  Rd_I_IE_Ledg.SelectedValue= ds.Tables[0].Rows[0]["IMPORT_IE_LEDGER"].ToString();
                  Rd_E_IE_Ledg.SelectedValue= ds.Tables[0].Rows[0]["EXPORT_IE_LEDGER"].ToString();
                  Rd_G_IE_Ledg.SelectedValue= ds.Tables[0].Rows[0]["GENERAL_IE_LEDGER"].ToString();
                  txt_CGST_Rate.Text = ds.Tables[0].Rows[0]["CGST_RATE"].ToString();
                  txt_SGST_Rate.Text = ds.Tables[0].Rows[0]["SGST_RATE"].ToString();
                  txt_IGST_Rate.Text = ds.Tables[0].Rows[0]["IGST_RATE"].ToString();
                  Rd_Charge_AI.SelectedValue = ds.Tables[0].Rows[0]["ACTIVE"].ToString();

                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["CHARGE_ID"].ToString();
            }

            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       ds = insert_update("S");
       if (ds.Tables[0].Rows.Count > 0)
       {
           btnUpdate.CssClass = "save";
           btnUpdate.Visible = true;
           btnSave.Visible = false;
           btnSave.Focus();
           ViewState["UPDATED_ID"] = null;
           Alert_msg("Saved Successfully", "btnSave");
           HDupdate_id.Value = ds.Tables[0].Rows[0]["ID"].ToString();
       }
       else
       {
           Alert_msg("Already exists Not Saved !", "btnSave");
       }
    }
    public DataSet insert_update(string a1)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = txtCharge_Name.Text.TrimEnd();
        ObjUBO.A3 = Rd_Hsn_Sac.SelectedValue.ToString();
        ObjUBO.A4 =txt_HSN_SAC_Code.Text;
        ObjUBO.A5 = Rd_Ch_Cat.SelectedValue.ToString();
        ObjUBO.A6 = Rd_Tax_Cat.SelectedValue.ToString();
        ObjUBO.A7 = Rd_I_IE_Ledg.SelectedValue.ToString();
        ObjUBO.A8 = Rd_E_IE_Ledg.SelectedValue.ToString();
        ObjUBO.A9 = Rd_G_IE_Ledg.SelectedValue.ToString();
        ObjUBO.A10 = txt_CGST_Rate.Text;
        ObjUBO.A11 = txt_SGST_Rate.Text;
        ObjUBO.A12 = txt_IGST_Rate.Text;
        ObjUBO.A13 = Rd_Charge_AI.SelectedValue.ToString();
        ObjUBO.A25 = a1;
        return CH.Charge_Ins_Upd_N(ObjUBO);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ds = insert_update("D");
            if (ds.Tables[0].Rows.Count == 0)
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCharge_Name.Text.Trim() != string.Empty)
            {
               ds= insert_update("U");

                if (ds.Tables[0].Rows.Count > 0)
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
                else
                {
                    Alert_msg("Charge Name already exixts!", "btnUpdate");
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        HDupdate_id.Value = "";
        ViewState["UPDATED_ID"] = null;

        txtCharge_Name.Attributes.Remove("readonly");
        txtCharge_Name.Style.Add("background-color", "white");
    }
   
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CHARGE MASTER', function (r) {}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg,string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CHARGE MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}