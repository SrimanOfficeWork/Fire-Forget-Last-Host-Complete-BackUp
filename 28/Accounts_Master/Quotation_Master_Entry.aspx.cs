using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
 
public partial class Quotation_Master_Entry : ThemeClass
{
    AppSession aps = new AppSession();

    Quotation_Master_cs QM = new Quotation_Master_cs();
    Billing_UserBO ObjUBO = new Billing_UserBO();
    User_Creation user_Create = new User_Creation();

    public int i;
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    string[] arr = new string[] { };

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
        aps.checkSession();

        if (!Page.IsPostBack)
        {
            load_Based_on();
                if (Request.QueryString["Page"] == null || Request.QueryString["Page"]=="")
                {
                    btnsup.Text = "Save";
                    //--------------------------------------------------
                    Load_Party_Name();

                    btn_Charge_Save.Visible = true;
                    btn_Charge_Update.Visible = false;
                    btn_Charge_Delete.Visible = false;

                    btn_Charge_Save_Tr.Visible = true;
                    btn_Charge_Update_Tr.Visible = false;
                    btn_Charge_Delete_Tr.Visible = false;

                    btnExpHead_Delete.Visible = false;

                    gv_Charge_Details.DataSource = dt;
                    gv_Charge_Details.DataBind();

                    gv_Trans.DataSource = dt;
                    gv_Trans.DataBind();
                    
                }
                else
                {
                    if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                    {
                        btnsup.Text = "Update";
                        Update_Item_Load();

                        btn_Charge_Save.Visible = true;
                        btn_Charge_Update.Visible = false;
                        btn_Charge_Delete.Visible = false;

                        btn_Charge_Save_Tr.Visible = true;
                        btn_Charge_Update_Tr.Visible = false;
                        btn_Charge_Delete_Tr.Visible = false;
                        btnExpHead_Delete.Visible = true;
                    }
                }
                Air_Sea_Land();
        }
         }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Update_Item_Load()
    {
        ddlParty_Name.Items.Clear();
        ddl_Charge_Name.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.Ref_ID = Request.QueryString["Page"].ToString();
        ObjUBO.Imp_Name = Request.QueryString["IMP_EXP"].ToString();
        ObjUBO.MODE = Request.QueryString["TR_MODE"].ToString();
        ObjUBO.Flag = "Quotation_Updated_data";
        ds = QM.Quotation_Master_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            HDupdate_id.Value = ds.Tables[0].Rows[0]["Q_ID"].ToString();
            Rd_Imp_Exp.SelectedValue = ds.Tables[0].Rows[0]["IMP_EXP"].ToString();
            
            ddlParty_Name.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["PARTY_NAME"].ToString(), ds.Tables[0].Rows[0]["PARTY_NAME"].ToString()));
            ddlParty_Name.SelectedIndex = 0;
            ddlmode.SelectedValue = ds.Tables[0].Rows[0]["TR_MODE"].ToString();
            ddl_Ship_type.SelectedValue = ds.Tables[0].Rows[0]["SHIPMENT_TYPE"].ToString();
            
            Rd_Imp_Exp.Enabled = false;
            ddlmode.Enabled = false;
            ddlParty_Name.Enabled = false;
            ddl_Ship_type.Enabled = false;
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            cbList.DataSource = ds.Tables[1];
            cbList.DataTextField = "Branch_Add";
            cbList.DataValueField = "Branch_No";
            cbList.DataBind();

            for (int i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
            {
                if (ds.Tables[1].Rows[i]["Selected_Val"].ToString() == "True")
                {
                    cbList.Items[i].Selected = true;
                }
            }
        }

        if (ds.Tables[2].Rows.Count > 0)
        {
            ddl_Charge_Name.DataSource = ds.Tables[2];
            ddl_Charge_Name.DataTextField = ds.Tables[2].Columns["CHARGE_NAME"].ToString();
            ddl_Charge_Name.DataValueField = ds.Tables[2].Columns["TAX_MODE"].ToString();
            ddl_Charge_Name.DataBind();
        }

        ddl_Charge_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Charge_Name.SelectedIndex = 0;

        if (ds.Tables[3].Rows.Count > 0)
        {
            gv_Charge_Details.DataSource = ds.Tables[3];
        }
        else
        {
            gv_Charge_Details.DataSource = dt;
        }
        gv_Charge_Details.DataBind();


        if (ds.Tables[4].Rows.Count > 0)
        {
            gv_Trans.DataSource = ds.Tables[4];
        }
        else
        {
            gv_Trans.DataSource = dt;
        }
        gv_Trans.DataBind();
    }
    private void Load_Party_Name()
    {
        ds.Clear();
        ddlParty_Name.Items.Clear();
        ddl_Charge_Name.Items.Clear();
        ObjUBO.Flag = "Party_Name_select";
        ds = QM.Quotation_Master_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlParty_Name.DataSource = ds.Tables[0];
            ddlParty_Name.DataTextField = ds.Tables[0].Columns["PARTY_NAME"].ToString();
            ddlParty_Name.DataValueField = ds.Tables[0].Columns["PARTY_NAME"].ToString();
            ddlParty_Name.DataBind();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            ddl_Charge_Name.DataSource = ds.Tables[1];
            ddl_Charge_Name.DataTextField = ds.Tables[1].Columns["CHARGE_NAME"].ToString();
            ddl_Charge_Name.DataValueField = ds.Tables[1].Columns["TAX_MODE"].ToString();
            ddl_Charge_Name.DataBind();
        }

        ddlParty_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlParty_Name.SelectedIndex = 0;
        ddl_Charge_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Charge_Name.SelectedIndex = 0;
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Quotation Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Quotation Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Charge_Details.PageIndex = e.NewPageIndex;
    }
    
    protected void btnsup_Click(object sender, EventArgs e)
    {
        lbl_Error_Msg.Text = "";
        try
        { 
             string values = "",Items="";
             foreach (ListItem objItem in cbList.Items)
             {
                 if (objItem.Selected)
                 {
                     values += objItem.Value + ",";
                     Items += objItem.Text + ",";
                 }
             }

             if (values != "" && values != string.Empty)
             {

                 if (ddlParty_Name.SelectedValue.ToString() != string.Empty)
                 {
                     ds = Quotation_Ins_Upd(btnsup.Text, values);
                     
                     if (btnsup.Text == "Save")
                     {
                         if (ds.Tables[0].Rows.Count > 0)
                         {
                             HDupdate_id.Value = Convert.ToString(QM.UPDATE_ID);
                             btnsup.Text = "Update";
                             Alert_msg("Saved Successfully!", "btnsup");

                             btnExpHead_Delete.Visible = true;

                             Rd_Imp_Exp.Enabled = false;
                             ddlmode.Enabled = false;
                             ddlParty_Name.Enabled = false;
                             ddl_Ship_type.Enabled = false;

                         }
                         else
                         {
                             Alert_msg("Not Saved", "btnsup");
                         }
                     }
                     else if (btnsup.Text == "Update")
                     {
                         if (ds.Tables[0].Rows.Count > 0)
                         {
                             HDupdate_id.Value = ds.Tables[0].Rows[0][0].ToString();
                             btnsup.Text = "Update";
                             Alert_msg("Updated Successfully!", "btnsup");
                         }
                         else
                         {
                             Alert_msg("Not Updated", "btnsup");
                         }
                     }
                 }
                 else
                 {
                     Alert_msg("Select Ur Party Name!", "ddlParty_Name");
                 }
             }
             else
             {
                 Alert_msg("Select Branch Location!");
             }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public DataSet Quotation_Ins_Upd(string flg,string Br_No)
    {
        ObjUBO.ID = HDupdate_id.Value.ToString();
        ObjUBO.TYPE = Rd_Imp_Exp.SelectedValue.ToString();
        ObjUBO.MODE = ddlmode.SelectedValue.ToString();
        ObjUBO.CustomerName = ddlParty_Name.SelectedValue.ToString();
        ObjUBO.SHIPMENT_TYPE = ddl_Ship_type.SelectedValue.ToString(); 
        ObjUBO.Branch_No = Br_No;
        ObjUBO.Flag = flg;
        return QM.Quo_Ins_Upd(ObjUBO);
    }
    protected void btn_Charge_New_Tr_Click(object sender, EventArgs e)
    {
        HDupdate_QC_ID.Value = "";

        btn_Charge_Save_Tr.Visible = true;
        btn_Charge_Update_Tr.Visible = false;
        btn_Charge_Delete_Tr.Visible = false;

        ddl_Slno_Tr.SelectedIndex = -1;

        txt_From.Text = "";
        txt_To.Text = "";
        txt_Tr_Amt.Text = "";

        lbl_Error_Msg_Tr.Text = string.Empty;
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
        txt_From.Focus();
    }
    protected void btn_Charge_New_Click(object sender, EventArgs e)
    {
        HDupdate_QC_ID.Value = "";
        btn_Charge_Save.Visible = true;
        btn_Charge_Update.Visible = false;
        btn_Charge_Delete.Visible = false;

        ddl_Sno.SelectedIndex = -1;
        
        txt_LCL.Text = "";
        txt_Fcl_20ft.Text = "";
        txt_Fcl_40ft.Text = "";
        txt_Bond_Ex_bond_Bulk.Text = "";
        txt_Amount.Text = "";

        ddl_LCL_Based_On.SelectedIndex = -1;
        ddl_FCL_20_Based_On.SelectedIndex = -1;
        ddl_FCL_40_Based_On.SelectedIndex = -1;
        ddl_Bond_Ex_bond_Bulk.SelectedIndex = -1;
        ddl_Based_On.SelectedIndex = -1;

        txt_LCL_Percentage.Text = "";
        txt_FCL_20_Percentage.Text = "";
        txt_FCL_40_Percentage.Text = "";
        txt_Bond_Ex_bond_Bulk_Percentage.Text = "";
        txt_Percentage.Text = "";

        txt_LCL_Min_Amt.Text = "";
        txt_FCL_20_Min_Amt.Text = "";
        txt_FCL_40_Min_Amt.Text = "";
        txt_Bond_Ex_bond_Bulk_Min_Amt.Text = "";
        txt_Min_Amt.Text = "";

        txt_LCL_Max_Amt.Text = "";
        txt_FCL_20_Max_Amt.Text = "";
        txt_FCL_40_Max_Amt.Text = "";
        txt_Bond_Ex_bond_Bulk_Max_Amt.Text = "";
        txt_Max_Amt.Text = "";


        lbl_Error_Msg.Text = string.Empty;
        load_Charge_New();
    }
    private void load_Charge_New()
    {
        ddl_Charge_Name.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.Ref_ID = HDupdate_id.Value.ToString();
        ObjUBO.Imp_Name = Rd_Imp_Exp.SelectedValue.ToString();
        ObjUBO.MODE = ddlmode.SelectedValue.ToString();
        ObjUBO.Flag = "Charge_New_Select";
        ds = QM.Quotation_Master_Select(ObjUBO);
        
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Charge_Name.DataSource = ds.Tables[0];
            ddl_Charge_Name.DataTextField = ds.Tables[0].Columns["CHARGE_NAME"].ToString();
            ddl_Charge_Name.DataValueField = ds.Tables[0].Columns["TAX_MODE"].ToString();
            ddl_Charge_Name.DataBind();
        }

        ddl_Charge_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Charge_Name.SelectedIndex = 0;
    
    }

    protected void btn_Charge_Save_Tr_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
        txt_From.Focus();
        if (HDupdate_id.Value.ToString() != string.Empty)
        {
            lbl_Error_Msg_Tr.Text = string.Empty;
            ds = Tr_Charge_Ins_Upd("S", HDupdate_id.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_Tr_ID.Value = Convert.ToString(ds.Tables[0].Rows[0]["TR_ID"].ToString());

                btn_Charge_Save_Tr.Visible = false;
                btn_Charge_Update_Tr.Visible = true;
                btn_Charge_Delete_Tr.Visible = true;

                Alert_msg("Saved Successfully!", "btn_Charge_Save_Tr");
            }
            else
            {
                btn_Charge_Save_Tr.Visible = true;
                btn_Charge_Update_Tr.Visible = false;

                Alert_msg("Not Saved!", "btn_Charge_Save_Tr");
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_Trans.DataSource = ds.Tables[1];
            }
            else
            {
                gv_Trans.DataSource = dt;
            }
            gv_Trans.DataBind();
        }
        else
        {
            Alert_msg("Invalid Quotaion!", "btn_Charge_Save_Tr");
        }

    }
    public DataSet Tr_Charge_Ins_Upd(string flg, string Exp_id)
    {
        ObjUBO.Q_Id = HDupdate_id.Value.ToString();
        ObjUBO.QC_Id = HDupdate_Tr_ID.Value.ToString();

        ObjUBO.Imp_Exp = Rd_Imp_Exp.SelectedValue.ToString();
        ObjUBO.Party_ID = ddlParty_Name.SelectedValue.ToString();
        ObjUBO.MODE = ddlmode.SelectedValue.ToString();

        ObjUBO.Order_by = ddl_Slno_Tr.SelectedValue.ToString();
        ObjUBO.Charge_Id = ddl_Tr_Charge_Name.SelectedValue.ToString();
        ObjUBO.TAX_NONTAX = "T";

        ObjUBO.LCL_BASED_ON = ddl_Type_Tr.SelectedValue.ToString();
        ObjUBO.AIR_BASED_ON = ddl_Ton_Kg.SelectedValue.ToString();

        ObjUBO.LCL_AMT = txt_From.Text;
        ObjUBO.FCL_20_FT_AMT = txt_To.Text;
        ObjUBO.FCL_40_FT_AMT = txt_Tr_Amt.Text;
        
        ObjUBO.Flag = flg;
        return QM.Quo_Tr_Cha_Ins_Upd(ObjUBO);
    }
    protected void btn_Charge_Save_Click(object sender, EventArgs e)
    {
        if (HDupdate_id.Value.ToString() != string.Empty)
        {
            lbl_Error_Msg.Text = string.Empty;
            if(ddl_Charge_Name.SelectedValue.ToString() !=string.Empty)
            {
            ds = Charge_Ins_Upd("S", HDupdate_id.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_QC_ID.Value = Convert.ToString(ds.Tables[0].Rows[0]["QC_ID"].ToString());
                btn_Charge_Save.Visible = false;
                btn_Charge_Update.Visible = true;
                btn_Charge_New.Visible = true;
                Alert_msg("Saved Successfully!", "btnExpHead_Save");
            }
            else
            {
                btn_Charge_Save.Visible = true;
                btn_Charge_Update.Visible = false;
                Alert_msg("Not Saved!", "btn_Charge_Save");
            }
            
            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_Charge_Details.DataSource = ds.Tables[1];
            }
            else
            {
                gv_Charge_Details.DataSource = dt;
            }
            gv_Charge_Details.DataBind();
            }
            else
            {
                Alert_msg("Select Ur Services!", "ddl_Charge_Name");
                lbl_Error_Msg.Text = "Select Ur Services!";
            }
        }
        else
        {
            Alert_msg("Invalid Quotaion!", "btn_Charge_Save");
        }
           
    }
    public DataSet Charge_Ins_Upd(string flg, string Exp_id)
    {
        arr = ddl_Charge_Name.SelectedValue.ToString().Split('~');

        ObjUBO.Q_Id = HDupdate_id.Value.ToString();
        ObjUBO.QC_Id = HDupdate_QC_ID.Value.ToString();

        ObjUBO.Imp_Exp = Rd_Imp_Exp.SelectedValue.ToString();
        ObjUBO.Party_ID = ddlParty_Name.SelectedValue.ToString();
        ObjUBO.MODE = ddlmode.SelectedValue.ToString();
        
        ObjUBO.Order_by = ddl_Sno.SelectedValue.ToString();
        ObjUBO.Charge_Id = arr[0].Trim();
        ObjUBO.TAX_NONTAX = arr[1].Trim();
        
        ObjUBO.LCL_AMT=txt_LCL.Text ;
        ObjUBO.FCL_20_FT_AMT= txt_Fcl_20ft.Text;
        ObjUBO.FCL_40_FT_AMT= txt_Fcl_40ft.Text ;
        ObjUBO.BOND_MAX_AMT= txt_Bond_Ex_bond_Bulk.Text ;
        ObjUBO.AIR_AMT= txt_Amount.Text;

        ObjUBO.LCL_BASED_ON= ddl_LCL_Based_On.SelectedValue.ToString();
        ObjUBO.FCL_20_FT_BASED_ON=  ddl_FCL_20_Based_On.SelectedValue.ToString();
        ObjUBO.FCL_40_FT_BASED_ON=  ddl_FCL_40_Based_On.SelectedValue.ToString();
        ObjUBO.BOND_BASED_ON=ddl_Bond_Ex_bond_Bulk.SelectedValue.ToString();
        ObjUBO.AIR_BASED_ON=  ddl_Based_On.SelectedValue.ToString();

        ObjUBO.LCL_P=txt_LCL_Percentage.Text ;
        ObjUBO.FCL_20_P=txt_FCL_20_Percentage .Text;
        ObjUBO.FCL_40_P=txt_FCL_40_Percentage .Text;
        ObjUBO.BOND_P=txt_Bond_Ex_bond_Bulk_Percentage.Text;
        ObjUBO.AIR_P= txt_Percentage.Text;

        ObjUBO.LCL_MIN_AMT=txt_LCL_Min_Amt.Text ;
        ObjUBO.FCL_20_MIN_AMT= txt_FCL_20_Min_Amt.Text;
        ObjUBO.FCL_40_MIN_AMT= txt_FCL_40_Min_Amt.Text;
        ObjUBO.BOND_MIN_AMT = txt_Bond_Ex_bond_Bulk_Min_Amt.Text;
        ObjUBO.AIR_MIN_AMT = txt_Min_Amt.Text;

        ObjUBO.LCL_MAX_AMT = txt_LCL_Max_Amt.Text;
        ObjUBO.FCL_20_MAX_AMT = txt_FCL_20_Max_Amt.Text;
        ObjUBO.FCL_40_MAX_AMT = txt_FCL_40_Max_Amt.Text;
        ObjUBO.BOND_MAX_AMT = txt_Bond_Ex_bond_Bulk_Max_Amt.Text;
        ObjUBO.AIR_MAX_AMT = txt_Max_Amt.Text;
        
        ObjUBO.Flag = flg;
        return QM.Quo_Cha_Ins_Upd(ObjUBO);
    }
    protected void btn_Charge_Update_Click(object sender, EventArgs e)
    {
        if (HDupdate_id.Value.ToString() != string.Empty)
        {
            lbl_Error_Msg.Text = string.Empty;
            if (ddl_Charge_Name.SelectedValue.ToString() != string.Empty)
            {
                ds = Charge_Ins_Upd("U", HDupdate_id.Value.ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    HDupdate_QC_ID.Value = Convert.ToString(ds.Tables[0].Rows[0]["QC_ID"].ToString());
                    btn_Charge_Save.Visible = false;
                    btn_Charge_Update.Visible = true;
                    Alert_msg("Updated Successfully!", "btn_Charge_Update");
                }
                else
                {
                    btn_Charge_Save.Visible = false;
                    btn_Charge_Update.Visible = true;
                    Alert_msg("Not Updated!", "btn_Charge_Update");
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    gv_Charge_Details.DataSource = ds.Tables[1];
                    gv_Charge_Details.DataBind();
                }
                else
                {
                    gv_Charge_Details.DataSource = dt;
                    gv_Charge_Details.DataBind();
                }
            }
            else
            {
                Alert_msg("Select Ur Services!", "ddl_Charge_Name");
                lbl_Error_Msg.Text = "Select Ur Services!";
            }

        }
        else
        {
            Alert_msg("Invalid Quotaion!", "btn_Charge_Update");
        }
    }
    protected void btn_Tr_Charge_Update_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
        txt_From.Focus();
        if (HDupdate_id.Value.ToString() != string.Empty)
        {
            lbl_Error_Msg_Tr.Text = string.Empty;
            ds = Tr_Charge_Ins_Upd("U", HDupdate_id.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_Tr_ID.Value = Convert.ToString(ds.Tables[0].Rows[0]["TR_ID"].ToString());
                btn_Charge_Save_Tr.Visible = false;
                btn_Charge_Update_Tr.Visible = true;
                Alert_msg("Updated Successfully!", "btn_Tr_Charge_Update");
            }
            else
            {
                btn_Charge_Save_Tr.Visible = false;
                btn_Charge_Update_Tr.Visible = true;
                Alert_msg("Not Updated!", "btn_Tr_Charge_Update");
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_Trans.DataSource = ds.Tables[1];
                gv_Trans.DataBind();
            }
            else
            {
                gv_Trans.DataSource = dt;
                gv_Trans.DataBind();
            }
        }
        else
        {
            Alert_msg("Invalid !", "btn_Tr_Charge_Update");
        }
    }

    protected void btn_Charge_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            ds = Charge_Ins_Upd("D", HDupdate_id.Value.ToString());

            if (QM.result == 1)
            {
                HDupdate_QC_ID.Value = "";
                btn_Charge_New_Click(sender, e);
                Alert_msg("Deleted Successfully.");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gv_Charge_Details.DataSource = ds.Tables[0];
                    gv_Charge_Details.DataBind();
                }
                else
                {
                    gv_Charge_Details.DataSource = dt;
                    gv_Charge_Details.DataBind();
                }
            }
            else
            {
                Alert_msg("Not Deleted !");
                lbl_Error_Msg.Text = "Not Deleted !";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnJob_Delete_All_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.EXP_ID = HDupdate_id.Value.ToString();
            //ObjUBO.ID = HDupdate_Ch_id.Value.ToString();
            ObjUBO.BILL_TYPE = HDupdate_Imp_Exp.Value.ToString();
            
            ObjUBO.MODE = HDupdate_Tr_Mode.Value.ToString();
            ObjUBO.CustomerName = ddlParty_Name.SelectedValue.ToString();
            ObjUBO.Flag = "Expense_Job_All_data_Delete";
            //ds = BI.Select_Expense(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Job Not Deleted");
            }
            else
            {
                btn_Charge_New_Click(sender, e);
                Alert_msg(" All Job(s) Deleted");
            }
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btn_Charge_Delete_Tr_Click(object sender, EventArgs e)
    {
        try
        {
            ds = Tr_Charge_Ins_Upd("D", HDupdate_id.Value.ToString());

            if (QM.result == 1)
            {
                HDupdate_Tr_ID.Value = "";
                btn_Charge_New_Tr_Click(sender, e);
                Alert_msg("Deleted Successfully.");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gv_Trans.DataSource = ds.Tables[0];
                    gv_Trans.DataBind();
                }
                else
                {
                    gv_Trans.DataSource = dt;
                    gv_Trans.DataBind();
                }

            }
            else
            {
                Alert_msg("Not Deleted !");
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
            txt_From.Focus();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Enabled = true;
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Charge_Details, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
    protected void gv_Trans_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Enabled = true;
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Trans, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
    protected void gv_Charge_Details_SelectedIndexChanged(object sender, EventArgs e)
    {
        string QC_ID = gv_Charge_Details.DataKeys[gv_Charge_Details.SelectedRow.RowIndex].Values["QC_ID"].ToString();
        string Q_ID = gv_Charge_Details.DataKeys[gv_Charge_Details.SelectedRow.RowIndex].Values["Q_ID"].ToString();

        string CH_ID = gv_Charge_Details.DataKeys[gv_Charge_Details.SelectedRow.RowIndex].Values["CH_ID"].ToString();
        string IMP_EXP = gv_Charge_Details.DataKeys[gv_Charge_Details.SelectedRow.RowIndex].Values["IMP_EXP"].ToString();
        string TR_MODE = gv_Charge_Details.DataKeys[gv_Charge_Details.SelectedRow.RowIndex].Values["TR_MODE"].ToString();

        if (QC_ID != "" && Q_ID != null)
        {
            HDupdate_id.Value = Q_ID;
            HDupdate_Ch_id.Value = CH_ID;
            HDupdate_QC_ID.Value = QC_ID;
            HDupdate_Imp_Exp.Value = IMP_EXP;
            HDupdate_Tr_Mode.Value = TR_MODE;
            

           // load_Charge_All();

            ddl_Sno.SelectedValue = gv_Charge_Details.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            ddl_Charge_Name.SelectedValue = CH_ID + '~' + gv_Charge_Details.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            
            txt_LCL.Text= gv_Charge_Details.SelectedRow.Cells[4].Text.Replace("&nbsp;", ""); //LCL_AMT
            ddl_LCL_Based_On.SelectedValue = gv_Charge_Details.SelectedRow.Cells[5].Text.Replace("&nbsp;", ""); //LCL_BASED_ON
            txt_LCL_Percentage.Text= gv_Charge_Details.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");//LCL_PER_VALUE
            txt_LCL_Min_Amt.Text= gv_Charge_Details.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");//LCL_MIN_AMT
            txt_LCL_Max_Amt.Text= gv_Charge_Details.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");//LCL_MAX_AMT

             txt_Fcl_20ft.Text  = gv_Charge_Details.SelectedRow.Cells[9].Text.Replace("&nbsp;", ""); //FCL_TWENTY_FT_AMT
             ddl_FCL_20_Based_On.SelectedValue = gv_Charge_Details.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");//FCL_TWENTY_BASED_ON
             txt_FCL_20_Percentage .Text   = gv_Charge_Details.SelectedRow.Cells[11].Text.Replace("&nbsp;", ""); //FCL_TWENTY_PER_VALUE
             txt_FCL_20_Min_Amt.Text = gv_Charge_Details.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");//FCL_TWENTY_MIN_AMT
             txt_FCL_20_Max_Amt.Text  = gv_Charge_Details.SelectedRow.Cells[13].Text.Replace("&nbsp;", ""); //FCL_TWENTY_MAX_AMT

             txt_Fcl_40ft.Text = gv_Charge_Details.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");//FCL_FORTY_FT_AMT
             ddl_FCL_40_Based_On.SelectedValue = gv_Charge_Details.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");//FCL_FORTY_BASED_ON
             txt_FCL_40_Percentage .Text  = gv_Charge_Details.SelectedRow.Cells[16].Text.Replace("&nbsp;", "");//FCL_FORTY_PER_VALUE
             txt_FCL_40_Min_Amt.Text  = gv_Charge_Details.SelectedRow.Cells[17].Text.Replace("&nbsp;", ""); //FCL_FORTY_MIN_AMT
             txt_FCL_40_Max_Amt.Text = gv_Charge_Details.SelectedRow.Cells[18].Text.Replace("&nbsp;", "");//FCL_FORTY_MAX_AMT
                                                                                                              
             txt_Bond_Ex_bond_Bulk.Text = gv_Charge_Details.SelectedRow.Cells[19].Text.Replace("&nbsp;", "");//BOND_EX_BOND_BULK_AMT
             ddl_Bond_Ex_bond_Bulk.SelectedValue= gv_Charge_Details.SelectedRow.Cells[20].Text.Replace("&nbsp;", "");//BOND_EX_BOND_BULK_BASED_ON
             txt_Bond_Ex_bond_Bulk_Percentage.Text = gv_Charge_Details.SelectedRow.Cells[21].Text.Replace("&nbsp;", "");//BOND_EX_BOND_BULK_PER_VALUE
             txt_Bond_Ex_bond_Bulk_Min_Amt.Text = gv_Charge_Details.SelectedRow.Cells[22].Text.Replace("&nbsp;", "");//BOND_EX_BOND_BULK_MIN_AMT
             txt_Bond_Ex_bond_Bulk_Max_Amt.Text = gv_Charge_Details.SelectedRow.Cells[23].Text.Replace("&nbsp;", "");//BOND_EX_BOND_BULK_MAX_AMT

             txt_Amount.Text= gv_Charge_Details.SelectedRow.Cells[24].Text.Replace("&nbsp;", "");//AIR_AMT
             ddl_Based_On.SelectedValue   = gv_Charge_Details.SelectedRow.Cells[25].Text.Replace("&nbsp;", "");//AIR_BASED_ON
             txt_Percentage.Text = gv_Charge_Details.SelectedRow.Cells[26].Text.Replace("&nbsp;", "");//AIR_PER_VALUE
             txt_Min_Amt.Text = gv_Charge_Details.SelectedRow.Cells[27].Text.Replace("&nbsp;", ""); //AIR_MIN_AMT
             txt_Max_Amt.Text = gv_Charge_Details.SelectedRow.Cells[28].Text.Replace("&nbsp;", "");//AIR_MAX_AMT
            
            btn_Charge_New.Visible = true;
            btn_Charge_Save.Visible=false;
            btn_Charge_Update.Visible=true;
            btn_Charge_Delete.Visible = true;
        }
    }
    protected void gv_Trans_SelectedIndexChanged(object sender, EventArgs e)
    {
        string TR_ID = gv_Trans.DataKeys[gv_Trans.SelectedRow.RowIndex].Values["TR_ID"].ToString();
        string Q_ID = gv_Trans.DataKeys[gv_Trans.SelectedRow.RowIndex].Values["Q_ID"].ToString();

        if (TR_ID != "" && Q_ID != null)
        {
            HDupdate_Tr_ID.Value = TR_ID;
            HDupdate_id.Value = Q_ID;

            ddl_Sno.SelectedValue = gv_Trans.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            ddl_Tr_Charge_Name.SelectedValue = gv_Trans.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            ddl_Type_Tr.SelectedValue = gv_Trans.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            ddl_Ton_Kg.SelectedValue = gv_Trans.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            txt_From.Text = gv_Trans.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            txt_To.Text = gv_Trans.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            txt_Tr_Amt.Text = gv_Trans.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

            btn_Charge_New_Tr.Visible = true;
            btn_Charge_Save_Tr.Visible = false;
            btn_Charge_Update_Tr.Visible = true;
            btn_Charge_Delete_Tr.Visible = true;
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
        txt_From.Focus();
    }
    private void load_Charge_All()
    {
        ddl_Charge_Name.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.Ref_ID = HDupdate_id.Value.ToString();
        ObjUBO.Imp_Name = Rd_Imp_Exp.SelectedValue.ToString();
        ObjUBO.MODE = ddlmode.SelectedValue.ToString();
        ObjUBO.Flag = "Charge_All_Select";
        ds = QM.Quotation_Master_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Charge_Name.DataSource = ds.Tables[0];
            ddl_Charge_Name.DataTextField = ds.Tables[0].Columns["CHARGE_NAME"].ToString();
            ddl_Charge_Name.DataValueField = ds.Tables[0].Columns["TAX_MODE"].ToString();
            ddl_Charge_Name.DataBind();
        }

        ddl_Charge_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Charge_Name.SelectedIndex = 0;

    }
    private void Air_Sea_Land()
    {
        txt_LCL.Text = "";
        txt_Fcl_20ft.Text = "";
        txt_Fcl_40ft.Text = "";
        txt_Bond_Ex_bond_Bulk.Text="";
        txt_Amount.Text="";

        ddl_LCL_Based_On.SelectedIndex=-1;
        ddl_FCL_20_Based_On.SelectedIndex = -1;
        ddl_FCL_40_Based_On.SelectedIndex = -1;
        ddl_Bond_Ex_bond_Bulk.SelectedIndex = -1;
        ddl_Based_On.SelectedIndex = -1;

        txt_LCL_Percentage.Text = "";
        txt_FCL_20_Percentage.Text = "";
        txt_FCL_40_Percentage.Text = "";
        txt_Bond_Ex_bond_Bulk_Percentage.Text = "";
        txt_Percentage.Text = "";

        txt_LCL_Min_Amt.Text = "";
        txt_FCL_20_Min_Amt.Text = "";
        txt_FCL_40_Min_Amt.Text = "";
        txt_Bond_Ex_bond_Bulk_Min_Amt.Text = "";
        txt_Min_Amt.Text = "";

        txt_LCL_Max_Amt.Text = "";
        txt_FCL_20_Max_Amt.Text = "";
        txt_FCL_40_Max_Amt.Text = "";
        txt_Bond_Ex_bond_Bulk_Max_Amt.Text = "";
        txt_Max_Amt.Text = "";
        
        if (ddlmode.SelectedValue.ToString() == "A")
        {
            Air_Div.Visible = true;
            SL_Div.Visible = false;

        }
        else
        {
            Air_Div.Visible = false;
            SL_Div.Visible = true;

        }
    }
    protected void ddlmode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Air_Sea_Land();
        Load_Party_Branch_Name();
    }
    protected void ddlParty_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Party_Branch_Name();
    }
    private void Load_Party_Branch_Name()
    {
        cbList.Items.Clear();
        if (ddlParty_Name.SelectedItem.ToString() != string.Empty)
        {
            ObjUBO.Imp_Name = ddlParty_Name.SelectedValue.ToString();
            ObjUBO.MODE = ddlmode.SelectedValue.ToString();
            ObjUBO.SHIPMENT_TYPE = Rd_Imp_Exp.SelectedValue.ToString();
            ObjUBO.Ref_ID = ddl_Ship_type.SelectedValue.ToString();
            ObjUBO.Flag = "Party_Branch_select";
            ds = QM.Quotation_Master_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cbList.DataSource = ds.Tables[0];
                cbList.DataTextField = "Branch_Add";
                cbList.DataValueField = "Branch_No";
                cbList.DataBind();
            }
        }
    }
    protected void Rd_Imp_Exp_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Based_on();
    }
    private void load_Based_on()
    {
        string text=string.Empty, val = string.Empty,
        Ctext_A=string.Empty, Cval_A = string.Empty,
        Ctext_B=string.Empty, Cval_B = string.Empty,

        Ctext_C = string.Empty, Cval_C = string.Empty,
        Ctext_D=string.Empty, Cval_D = string.Empty,
        Ctext_E=string.Empty, Cval_E = string.Empty,
        Ctext_F = string.Empty, Cval_F = string.Empty
        ;

        ddl_LCL_Based_On.Items.Clear();
        ddl_FCL_20_Based_On.Items.Clear();
        ddl_FCL_40_Based_On.Items.Clear();
        ddl_Bond_Ex_bond_Bulk.Items.Clear();
        ddl_Based_On.Items.Clear();

        ddl_LCL_Based_On.Items.Add(new ListItem("", ""));
        ddl_FCL_20_Based_On.Items.Add(new ListItem("", ""));
        ddl_FCL_40_Based_On.Items.Add(new ListItem("", ""));
        ddl_Bond_Ex_bond_Bulk.Items.Add(new ListItem("", ""));
        ddl_Based_On.Items.Add(new ListItem("", ""));


        Ctext_C = "BE/SB";
        Cval_C = "BE_SB";

        Ctext_D = "HBL/HAWB";
        Cval_D = "HBL_HAWB";

        Ctext_F = "License";
        Cval_F = "License";

        /*
        Ctext_B = "Package";
        Cval_B = "P";

        Ctext_E = "Bond";
        Cval_E = "Bond";
        */
	    
        if (Rd_Imp_Exp.SelectedValue.ToString() == "I")
        {
            text = "Assesable Value";
            val = "AV";
        }
        else 
         {
                text = "DrawBack Value";
                val = "DV";
          }

        ddl_LCL_Based_On.Items.Add(new ListItem(text, val));
        ddl_LCL_Based_On.Items.Add(new ListItem(Ctext_A, Cval_A));
        ddl_LCL_Based_On.Items.Add(new ListItem(Ctext_B, Cval_B));
        ddl_LCL_Based_On.Items.Add(new ListItem(Ctext_C, Cval_C));
        ddl_LCL_Based_On.Items.Add(new ListItem(Ctext_D, Cval_D));
        ddl_LCL_Based_On.Items.Add(new ListItem(Ctext_E, Cval_E));
        ddl_LCL_Based_On.Items.Add(new ListItem(Ctext_F, Cval_F));

        ddl_FCL_20_Based_On.Items.Add(new ListItem(text, val));
        ddl_FCL_20_Based_On.Items.Add(new ListItem(Ctext_A, Cval_A));
        ddl_FCL_20_Based_On.Items.Add(new ListItem(Ctext_B, Cval_B));
        ddl_FCL_20_Based_On.Items.Add(new ListItem(Ctext_C, Cval_C));
        ddl_FCL_20_Based_On.Items.Add(new ListItem(Ctext_D, Cval_D));
        ddl_FCL_20_Based_On.Items.Add(new ListItem(Ctext_E, Cval_E));
        ddl_FCL_20_Based_On.Items.Add(new ListItem(Ctext_F, Cval_F));

        ddl_FCL_40_Based_On.Items.Add(new ListItem(text, val));
        ddl_FCL_40_Based_On.Items.Add(new ListItem(Ctext_A, Cval_A));
        ddl_FCL_40_Based_On.Items.Add(new ListItem(Ctext_B, Cval_B));
        ddl_FCL_40_Based_On.Items.Add(new ListItem(Ctext_C, Cval_C));
        ddl_FCL_40_Based_On.Items.Add(new ListItem(Ctext_D, Cval_D));
        ddl_FCL_40_Based_On.Items.Add(new ListItem(Ctext_E, Cval_E));
        ddl_FCL_40_Based_On.Items.Add(new ListItem(Ctext_F, Cval_F));

        ddl_Bond_Ex_bond_Bulk.Items.Add(new ListItem(text, val));
        ddl_Bond_Ex_bond_Bulk.Items.Add(new ListItem(Ctext_A, Cval_A));
        ddl_Bond_Ex_bond_Bulk.Items.Add(new ListItem(Ctext_B, Cval_B));
        ddl_Bond_Ex_bond_Bulk.Items.Add(new ListItem(Ctext_C, Cval_C));
        ddl_Bond_Ex_bond_Bulk.Items.Add(new ListItem(Ctext_D, Cval_D));
        ddl_Bond_Ex_bond_Bulk.Items.Add(new ListItem(Ctext_E, Cval_E));
        ddl_Bond_Ex_bond_Bulk.Items.Add(new ListItem(Ctext_F, Cval_F));

        ddl_Based_On.Items.Add(new ListItem(text, val));
        ddl_Based_On.Items.Add(new ListItem(Ctext_A, Cval_A));
        ddl_Based_On.Items.Add(new ListItem(Ctext_B, Cval_B));
        ddl_Based_On.Items.Add(new ListItem(Ctext_C, Cval_C));
        ddl_Based_On.Items.Add(new ListItem(Ctext_D, Cval_D));
        ddl_Based_On.Items.Add(new ListItem(Ctext_E, Cval_E));
        ddl_Based_On.Items.Add(new ListItem(Ctext_F, Cval_F));
    }

    protected void btnExpHead_Delete_Click(object sender, EventArgs e)
    {
        try
        {

            if (ddlParty_Name.SelectedValue.ToString() != string.Empty)
            {
                Quotation_Ins_Upd("Delete", "");

                   load_Based_on();
               
                    btnsup.Text = "Save";
                    //--------------------------------------------------
                    Load_Party_Name();

                    btn_Charge_Save.Visible = true;
                    btn_Charge_Update.Visible = false;
                    btn_Charge_Delete.Visible = false;

                    btn_Charge_Save_Tr.Visible = true;
                    btn_Charge_Update_Tr.Visible = false;
                    btn_Charge_Delete_Tr.Visible = false;

                    btnExpHead_Delete.Visible = false;

                    gv_Charge_Details.DataSource = dt;
                    gv_Charge_Details.DataBind();

                    gv_Trans.DataSource = dt;
                    gv_Trans.DataBind();
                    Air_Sea_Land();

                    Rd_Imp_Exp.Enabled = true;
                    ddlmode.Enabled = true;
                    ddlParty_Name.Enabled = true;
                    cbList.Items.Clear();
                    cbAll.Checked = false;

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void ddl_Ship_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Party_Branch_Name();
    }
}


