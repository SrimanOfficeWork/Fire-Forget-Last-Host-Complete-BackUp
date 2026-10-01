using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;

public partial class Acc_Group_Category : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();

    Global_variables ObjUBO = new Global_variables();
    Income_Charge_cs CH = new Income_Charge_cs();

    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!IsPostBack)
        {
            Edit_ChargeDetails();
        }
    }
    public void Edit_ChargeDetails()
    {
        DataSet ds = new DataSet();
        if (Request.QueryString["Cat_ID"] != "New")
        {
            txt_Cat_Code.Attributes.Add("readonly", "readonly");
            HDupdate_id.Value = "";

            ObjUBO.A1 = Request.QueryString["Cat_ID"].ToString();
            ObjUBO.A5 = "Update_Data_Select";
            ds = CH.Group_Cat_Search(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["ID"].ToString();
                txt_Cat_Code.Text = ds.Tables[0].Rows[0]["CATEGORY_CODE"].ToString();
                txt_Cat_Name.Text = ds.Tables[0].Rows[0]["CATEGORY_NAME"].ToString();
                txt_Remarks.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();

                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["Cat_ID"].ToString();
            }

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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
  
    public DataSet insert_update(string a1)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = txt_Cat_Code.Text.ToUpper().TrimEnd();
        ObjUBO.A3 = txt_Cat_Name.Text.TrimEnd();
        ObjUBO.A4 = txt_Remarks.Text;
        ObjUBO.A10 = a1;
        return CH.Group_Cat_Ins_Upd(ObjUBO);
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CATEGORY MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CATEGORY MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ds = insert_update("D");
            if (ds.Tables[0].Rows.Count == 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Category Deleted', 'CATEGORY MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("Group Category Not Deleted");
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

        txt_Cat_Code.Attributes.Remove("readonly");
        txt_Cat_Code.Style.Add("background-color", "white");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Cat_Code.Text.Trim() != string.Empty)
            {
                ds = insert_update("U");

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
                    Alert_msg("Group Category already exixts!", "btnUpdate");
                }
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