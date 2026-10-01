using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;

public partial class Ledger_Update : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();

    Billing_UserBO ObjUBO = new Billing_UserBO();
    Group_Master_cs CH = new Group_Master_cs();
    DataSet ds = new DataSet();

    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int i, Update_Id, Screen_Id;
    public bool chk = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!IsPostBack)
        {
            LoadLedger();
        }
    }
    private void LoadLedger()
    {
        DataSet ds = new DataSet();
        ObjUBO.Flag = "Ledger_Name_Update_Select";
        ds = CH.Group_Master_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlLedger.DataSource = ds.Tables[0];
            ddlLedger.DataTextField = "LEDGER";
            ddlLedger.DataValueField = "LEDGER";
            ddlLedger.DataBind();
        }
        ddlLedger.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        ddlLedger.SelectedIndex = 0;

        if (ds.Tables[1].Rows.Count > 0)
        {
            ddlSubGroup.DataSource = ds.Tables[1];
            ddlSubGroup.DataTextField = "SUB_GROUP";
            ddlSubGroup.DataValueField = "SUB_GROUP";
            ddlSubGroup.DataBind();
        }
        ddlSubGroup.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        ddlSubGroup.SelectedIndex = 0;

        if (ds.Tables[2].Rows.Count > 0)
        {
            ddlGroup.DataSource = ds.Tables[2];
            ddlGroup.DataTextField = "GROUP_NAME";
            ddlGroup.DataValueField = "GROUP_NAME";
            ddlGroup.DataBind();
        }
         ddlGroup.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
         ddlGroup.SelectedIndex = 0;
        ds.Dispose();
        GC.Collect();
    }
    public DataSet Update(string val, string val2, string flg)
    {
        DataSet ds = new DataSet();
        ObjUBO.LEDGER = val;
        ObjUBO.SUB_GROUP = val2;
        ObjUBO.Flag = flg;
        return CH.Group_INS_UPD(ObjUBO);
    }
    protected void btn_Leg_Update_Click(object sender, EventArgs e)
    {
        if(ddlLedger.SelectedValue.ToString() !=string.Empty)
        {
            if (Txt_Ledger_N.Text != string.Empty)
            {
              ds=Update(ddlLedger.SelectedValue.ToString(),Txt_Ledger_N.Text,"LU");
              Alert_msg("Update Successfully.");
              if (ds.Tables[0].Rows.Count > 0)
              {
                  ddlLedger.DataSource = ds.Tables[0];
                  ddlLedger.DataTextField = "LEDGER";
                  ddlLedger.DataValueField = "LEDGER";
                  ddlLedger.DataBind();
              }
              ddlLedger.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
              ddlLedger.SelectedIndex = 0;
              Txt_Ledger_N.Text = string.Empty;
            }
            else
            {
                Alert_msg("Enter Ur Ledger Name", "Txt_Ledger_N");
            }
        }
        else
        {
           Alert_msg("Select Ur Ledger Name","ddlLedger");
        }

    }
    protected void btn_SG_Update_Click(object sender, EventArgs e)
    {
        if(ddlSubGroup.SelectedValue.ToString() !=string.Empty)
        {
            if (Txt_Sub_Group_N.Text != string.Empty)
            {
                ds = Update(ddlSubGroup.SelectedValue.ToString(), Txt_Sub_Group_N.Text, "SGU");
                Alert_msg("Update Successfully.");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlSubGroup.DataSource = ds.Tables[0];
                    ddlSubGroup.DataTextField = "SUB_GROUP";
                    ddlSubGroup.DataValueField = "SUB_GROUP";
                    ddlSubGroup.DataBind();
                }
                ddlSubGroup.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
                ddlSubGroup.SelectedIndex = 0;
                Txt_Sub_Group_N.Text = string.Empty;
            }
            else
            {
                Alert_msg("Enter Ur Sub Group Name", "Txt_Sub_Group_N");
            }
        }
        else
        {
            Alert_msg("Select Ur Sub Group Name", "ddlSubGroup");
        }
    }
    protected void btn_G_Update_Click(object sender, EventArgs e)
    {
       if(ddlGroup.SelectedValue.ToString() !=string.Empty)
        {
            if (Txt_Group_N.Text != string.Empty)
            {
                ds = Update(ddlGroup.SelectedValue.ToString(), Txt_Group_N.Text, "GU");
                Alert_msg("Update Successfully.");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlGroup.DataSource = ds.Tables[0];
                    ddlGroup.DataTextField = "GROUP_NAME";
                    ddlGroup.DataValueField = "GROUP_NAME";
                    ddlGroup.DataBind();
                }
                ddlGroup.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
                ddlGroup.SelectedIndex = 0;
                Txt_Group_N.Text = string.Empty;
            }
            else
            {
                Alert_msg("Enter Ur Group Name", "Txt_Group_N");
            }
        }
        else
        {
            Alert_msg("Select Ur Group Name", "ddlGroup");
        }
    }
    public void Clear()
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GROUP MASTER UPDATION', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GROUP MASTER UPDATION', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    
}