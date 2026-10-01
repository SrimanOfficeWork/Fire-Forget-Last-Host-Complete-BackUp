using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BussinessObject;
using System.Net;

public partial class Acc_COA_Master : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();

    Global_variables ObjUBO = new Global_variables();
    Income_Charge_cs CH = new Income_Charge_cs();

    DataSet ds = new DataSet();

    public int i, Update_Id, Screen_Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
         {
             txtCharge_Name.Focus();
             load_COA_Type();
             if (Request.QueryString["CHARGE_ID"] != "New")
             {
                 Edit_ChargeDetails();

                 txtCharge_Name.Attributes.Add("readonly", "readonly");
                 ddl_COA_Type.Attributes.Add("readonly", "readonly");
                 ddl_COA_Cat.Attributes.Add("readonly", "readonly");
                 ddl_COA_Group.Attributes.Add("readonly", "readonly");
             }
             else
             {
                 btnDelete.Visible = false;
                 btnUpdate.Visible = false;
                 btnSave.Visible = true;
             }
         }
       
    }

    private void load_COA_Type()
    {
        try
        {
            ddl_COA_Type.Items.Clear();
            ddl_COA_Cat.Items.Clear();
            ddl_COA_Group.Items.Clear();
            ddl_COA_Sup_Group.Items.Clear();

            DataSet ds = new DataSet();
            ObjUBO.A5 = "COA_List_Select";
            ds = CH.COA_Master_Search(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_COA_Type.DataSource = ds.Tables[0];
                ddl_COA_Type.DataTextField = "GROUP_TYPE_NAME";
                ddl_COA_Type.DataValueField = "GROUP_TYPE_NAME";
                ddl_COA_Type.DataBind();
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                ddl_COA_Cat.DataSource = ds.Tables[1];
                ddl_COA_Cat.DataTextField = "CATEGORY_NAME";
                ddl_COA_Cat.DataValueField = "CATEGORY_NAME";
                ddl_COA_Cat.DataBind();
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                ddl_COA_Group.DataSource = ds.Tables[2];
                ddl_COA_Group.DataTextField = "GROUP_LIST_NAME";
                ddl_COA_Group.DataValueField = "GROUP_LIST_NAME";
                ddl_COA_Group.DataBind();
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                ddl_COA_Sup_Group.DataSource = ds.Tables[3];
                ddl_COA_Sup_Group.DataTextField = "SUB_GROUP_NAME";
                ddl_COA_Sup_Group.DataValueField = "SUB_GROUP_NAME";
                ddl_COA_Sup_Group.DataBind();
            }

            ddl_COA_Type.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_COA_Type.SelectedIndex = 0;

            ddl_COA_Cat.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_COA_Cat.SelectedIndex = 0;

            ddl_COA_Group.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_COA_Group.SelectedIndex = 0;

            ddl_COA_Sup_Group.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_COA_Sup_Group.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void Edit_ChargeDetails()
    {
        DataSet ds = new DataSet();
            txtCharge_Name.Attributes.Add("readonly", "readonly");
            HDupdate_id.Value = "";
            ObjUBO.A1 = Request.QueryString["CHARGE_ID"].ToString();
            ObjUBO.A5 = "Update_Data_Select";
            ds = CH.COA_Master_Search(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                  HDupdate_id.Value = ds.Tables[0].Rows[0]["ID"].ToString();
                  txtCharge_Name.Text = ds.Tables[0].Rows[0]["CHARGE_NAME"].ToString();

                  ddl_COA_Type.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["COA_TYPE"].ToString(), ds.Tables[0].Rows[0]["COA_TYPE"].ToString()));
                  ddl_COA_Type.SelectedIndex = 0;

                  ddl_COA_Cat.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["COA_CAT"].ToString(), ds.Tables[0].Rows[0]["COA_CAT"].ToString()));
                  ddl_COA_Cat.SelectedIndex = 0;

                  ddl_COA_Group.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["COA_GROUP"].ToString(), ds.Tables[0].Rows[0]["COA_GROUP"].ToString()));
                  ddl_COA_Group.SelectedIndex = 0;

                  ddl_COA_Sup_Group.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["COA_SUB_GROUP"].ToString(), ds.Tables[0].Rows[0]["COA_SUB_GROUP"].ToString()));
                  ddl_COA_Sup_Group.SelectedIndex = 0;

                  txtCharge_Desc.Text = ds.Tables[0].Rows[0]["CHARGE_DESC"].ToString();
                  txt_Remarks.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();
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
        ObjUBO.A3 = ddl_COA_Type.SelectedValue.ToString();
        ObjUBO.A4 = ddl_COA_Cat.SelectedValue.ToString();
        ObjUBO.A5 = ddl_COA_Group.SelectedValue.ToString();

        ObjUBO.A6 = ddl_COA_Sup_Group.SelectedValue.ToString();
        ObjUBO.A7 = txtCharge_Desc.Text;
        ObjUBO.A8 = txt_Remarks.Text;
        ObjUBO.A20 = a1;
        return CH.COA_Master_Ins_Upd(ObjUBO);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ds = insert_update("D");
            if (ds.Tables[0].Rows.Count == 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('COA Deleted', 'COA MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'COA MASTER', function (r) {}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg,string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'COA MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}