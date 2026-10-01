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

public partial class Party_Master : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    Party_Master_cs PM = new Party_Master_cs();
    Global_variables ObjUBO = new Global_variables();

    DataTable dt = new DataTable();

    public int i,Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!Page.IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//
            
            btnDelete1.Visible = false;
            T.Visible = false;
            Load_Under();
            load_Client_name();
            if (Request.QueryString["Page"] == null)
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

                btnSave1.Text = "Save";
               HDupdate_id.Value = "";
               HDupdate_id_II.Value = "";
               gv.DataSource = dt;
               gv.DataBind();
               if (Rd_TDS_Y_N.SelectedValue == "N")
               {
                   ddlTDS_Section.Enabled = false;
                   txt_Tds_Rate.Enabled = false;
               }
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Update_Item_Load(Request.QueryString["Page"].ToString(), Request.QueryString["Brno"].ToString(), Request.QueryString["Part_Id"].ToString());
                    ddlClient_name.Enabled = false;
                    ddl_Client_branch_No.Enabled = false;
                    btnaddnew.Visible = false;
                }
            }
            
        }
    }
    private void load_Client_name()
    {
        try
        {
            DataSet dss = new DataSet();
            ddlClient_name.Items.Clear();
            ObjUBO.A15 = "Client_Name_Select";
            dss = PM.Party_Master_Data(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlClient_name.DataSource = dss.Tables[0];
                ddlClient_name.DataTextField = "CLIENT_NAME";
                ddlClient_name.DataValueField = "CLIENT_NAME";
                ddlClient_name.DataBind();

                ddlPartyName.DataSource = dss.Tables[0];
                ddlPartyName.DataTextField = "CLIENT_NAME";
                ddlPartyName.DataValueField = "CLIENT_NAME";
                ddlPartyName.DataBind();
            }
            ddlClient_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlClient_name.SelectedIndex = 0;

            ddlPartyName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlPartyName.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Load_Under()
    {
        try
        {
            DataSet dss = new DataSet();
            ddlUnder.Items.Clear();
            ObjUBO.A15 = "Under_Select";
            dss = PM.Party_Master_Data(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlUnder.DataSource = dss.Tables[0];
                ddlUnder.DataTextField = "SUB_GROUP_NAME";
                ddlUnder.DataValueField = "SUB_GROUP_NAME";
                ddlUnder.DataBind();
            }
            ddlUnder.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlUnder.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Update_Item_Load(string Party_Name ,string Brno,string Partid)
    {
        DataSet dss = new DataSet();
        ddlClient_name.Items.Clear();
        ddl_Client_branch_No.Items.Clear();
        ObjUBO.A1 = Party_Name;
        ObjUBO.A4 = Brno;
        ObjUBO.A10 = Partid;
        ObjUBO.A15 = "PartyData_Select";
        dss = PM.Party_Master_Data(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlClient_name.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["PARTY_NAME"].ToString(), dss.Tables[0].Rows[0]["PARTY_NAME"].ToString()));
            ddlClient_name.SelectedIndex = 0;
            //Load_Branch_details();
          
            ddl_Client_branch_No.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["PARTY_BRANCH_NO"].ToString(), dss.Tables[0].Rows[0]["PARTY_BRANCH_NO"].ToString()));
            ddl_Client_branch_No.SelectedIndex = 0;

            HDupdate_id.Value = dss.Tables[0].Rows[0]["PARTY_ID"].ToString();
            //ddl_Client_branch_No.SelectedValue = dss.Tables[0].Rows[0]["PARTY_BRANCH_NO"].ToString();
            txtParty_Add_1.Text = dss.Tables[0].Rows[0]["PARTY_ADD_1"].ToString();
            txtParty_Add_2.Text = dss.Tables[0].Rows[0]["PARTY_ADD_2"].ToString();
            txtParty_Add_3.Text = dss.Tables[0].Rows[0]["PARTY_ADD_3"].ToString();
            txtParty_Add_4.Text = dss.Tables[0].Rows[0]["PARTY_ADD_4"].ToString();
            txtParty_Add_5.Text = dss.Tables[0].Rows[0]["PARTY_ADD_5"].ToString();
            ddlUnder.SelectedValue = dss.Tables[0].Rows[0]["UNDER"].ToString();
            ddlBank_details.SelectedValue = dss.Tables[0].Rows[0]["BANK_DETAILS"].ToString();
            txt_Pan_Tan_No.Text = dss.Tables[0].Rows[0]["PAN_TAN_NO"].ToString();
            ddlUnder.SelectedValue = dss.Tables[0].Rows[0]["UNDER"].ToString();
            ddlGst_Reg_Type.SelectedValue = dss.Tables[0].Rows[0]["GST_REG_TYPE"].ToString();
            ddl_state_name.SelectedValue = dss.Tables[0].Rows[0]["STATE_CODE"].ToString();
            txt_Gst_Number.Text = dss.Tables[0].Rows[0]["GST_NO"].ToString();
            string chk = dss.Tables[0].Rows[0]["TDS_YN"].ToString();
            if (chk == "Y")
            {
                Rd_TDS_Y_N.SelectedValue = "Y";
            }
            else
            {
                Rd_TDS_Y_N.SelectedValue = "N";
            }
            ddlTDS_Section.SelectedValue = dss.Tables[0].Rows[0]["TDS_SECTION"].ToString();
            txt_Tds_Rate.Text = dss.Tables[0].Rows[0]["TDS_RATE"].ToString();
            ddl_Cr_Days.SelectedValue = dss.Tables[0].Rows[0]["CREDIT_DAYS"].ToString();
            txt_Opening_bal.Text = dss.Tables[0].Rows[0]["OPENING_BAL_AMT"].ToString();
            txt_Credit_Amt.Text = dss.Tables[0].Rows[0]["CREDIT_AMT"].ToString();
            txt_Debit_Amt.Text = dss.Tables[0].Rows[0]["DEBIT_AMT"].ToString();
            if (dss.Tables[1].Rows.Count > 0)
            {
                gv.DataSource = dss.Tables[1];
            }
            else
            {
                gv.DataSource = dt;
            }
            gv.DataBind();
            btnSave1.Text = "Save";
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnNew.Visible = true;
        }
        else
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnNew.Visible = true;
        }
    }
    
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Party Master', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Party Master', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private DataSet Save_Update_II(string Flag)
    {
        DataSet ds = new DataSet();
        ObjUBO.A101 = HDupdate_id.Value.ToString();
        ObjUBO.A102 = ddlPartyName.SelectedValue;
        ObjUBO.A103 = ddlPartybranch_Name.SelectedValue;
        ObjUBO.A104 = ddlPartybranch_Name.SelectedItem.Text;
        ObjUBO.A105 = Flag;
        ObjUBO.A106 = HDupdate_id_II.Value.ToString();
        ds = PM.Party_Master_Ins_Upd_II(ObjUBO);
        i = PM.result;
        if (i == 1)
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                gv.DataSource = ds.Tables[1];
            }
            else
            {
                gv.DataSource = dt;
            }
            gv.DataBind();
        }
        else
        {
            Alert_msg("Client Already Exist!", "btn_Save_Update");
        }
        return ds;
    }
    protected void btn_Save_Update_Click_II(object sender, EventArgs e)
    {
        if (ddlPartyName.SelectedValue.ToString() != string.Empty)
        {
            if (ddlPartybranch_Name.SelectedValue.ToString() != string.Empty)
            {
                string flag = btnSave1.Text == "Save" ? "SAVE" : "UPDATE";
                DataSet dss = Save_Update_II(flag);
                if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                {
                    HDupdate_id_II.Value = dss.Tables[0].Rows[0]["CLIENT_ID"].ToString();
                    Alert_msg(flag == "SAVE" ? "Saved Successfully!" : "Updated Successfully!", "btn_Save_Update");
                    clear_II();
                }
            }
            else
            {
                Alert_msg("Select Ur Client Br.No. Name!", "ddlPartybranch_Name");
            }
        }
        else
        {
            Alert_msg("Select Ur Client Name!", "ddlPartyName");
        }
    }

    private void clear_II()
    {
        ddlPartyName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlPartyName.SelectedIndex = 0;
        ddlPartybranch_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlPartybranch_Name.SelectedIndex = 0;
        btnSave1.Text = "Save";
        btnDelete1.Visible = false;
      
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

                        if (ddlClient_name.SelectedItem.Text != "" || ddl_Client_branch_No.SelectedValue.ToString() !=string.Empty) 
                        {
                            //if (ddlPartyName.SelectedItem.Text != "" || ddlPartyName.SelectedValue.ToString() != string.Empty)
                            //{
                                if (ddl_state_name.SelectedValue.ToString() != string.Empty)
                                {
                                    if (ddl_state_name.SelectedValue.ToString() != string.Empty)
                                    {
                                        //--------------------------------------------------------------------------------------------------------------------------
                                       ds= Save_Update("S");
                                      
                                           if (ds.Tables[0].Rows.Count > 0)
                                           {
                                               //-----------------------FOR USER RIGHTS--------------------------------//
                                               user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                                               PAGE_MODIFY = user_Create.PAGE_MODIFY;
                                               //---------------SAVE ONLY------------------//
                                               if (PAGE_MODIFY == "False")
                                               {
                                                   btnNew_Click1(sender, e);
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
                                               HD_Showcon.Value = "SAVED";
                                               Alert_msg("Saved Successfully", "btnSave");
                                               HDupdate_id.Value = Convert.ToString(ds.Tables[0].Rows[0]["Id"].ToString());

                                               F.Visible = false;
                                               T.Visible = true;

                                               ddlClient_name.Attributes.Add("readonly", "readonly");
                                               ddlClient_name.Style.Add("background-color", "#F0F0F0");
                                               ddlClient_name.Enabled = false;

                                               ddl_Client_branch_No.Attributes.Add("readonly", "readonly");
                                               ddl_Client_branch_No.Style.Add("background-color", "#F0F0F0");
                                               ddl_Client_branch_No.Enabled = false;

                                               btnUpdate.CssClass = "updates";
                                               btnUpdate.Visible = true;
                                               btnDelete.Visible = true;
                                               btnSave.Visible = false;
                                               btnNew.Visible = true;
                                           }
                                           else
                                           {
                                               btnUpdate.Visible = false;
                                               btnDelete.Visible = false;
                                               btnSave.Visible = true;
                                               btnNew.Visible = true;
                                               Alert_msg("Already exists Not Saved.", "btnSave");
                                           }
                                       
                                        //-------------------------------------------------------------
                                    }
                                    else
                                    {
                                        Alert_msg("Enter Ur GSTN Number!", "txt_Gst_Number"); 
                                    }
                                }
                                else
                                {
                                    Alert_msg("Select Ur State Name !", "ddl_state_name"); 
                                }
                            }
                            else
                            {
                                Alert_msg("Select Ur Party Name or Branch !", "ddlPartyName"); 
                            }
                    //-------------------------------------------------------------------------------------
    }
    private DataSet Save_Update(string Flag)
    {
        DataSet ds = new DataSet();
        //ObjUBO.A1 = ddlClient_name.SelectedValue.ToString();
        //ObjUBO.A2 = ddl_Client_branch_No.SelectedValue.ToString();
        //ObjUBO.A3 = ddl_Client_branch_No.SelectedItem.ToString();
        ObjUBO.A4 = ddlClient_name.SelectedValue.ToString();
        ObjUBO.A5 = ddl_Client_branch_No.SelectedValue.ToString();
        ObjUBO.A6 = txtParty_Add_1.Text;
        ObjUBO.A7 = txtParty_Add_2.Text;
        ObjUBO.A8 = txtParty_Add_3.Text;
        ObjUBO.A9 = txtParty_Add_4.Text; 
        ObjUBO.A10 = txtParty_Add_5.Text;
        ObjUBO.A11 = ddlUnder.SelectedValue.ToString();
        ObjUBO.A12 = ddlBank_details.SelectedValue.ToString();
        ObjUBO.A13 = txt_Pan_Tan_No.Text;
        ObjUBO.A14 = ddlGst_Reg_Type.SelectedValue.ToString();
        ObjUBO.A15 = ddl_state_name.SelectedItem.ToString();
        ObjUBO.A16 = txt_Gst_Number.Text;
        ObjUBO.A17 = txt_Credit_Amt.Text;
        ObjUBO.A18 = txt_Debit_Amt.Text;
        ObjUBO.A22 = Flag;
        ObjUBO.A24 = ddl_state_name.SelectedValue.ToString();
        ObjUBO.A34 = HDupdate_id.Value.ToString();
        ObjUBO.A19 = Rd_TDS_Y_N.SelectedValue;
        ObjUBO.A20 = ddlTDS_Section.SelectedValue;
        ObjUBO.A21 = txt_Tds_Rate.Text;
        ObjUBO.A26 = ddl_Cr_Days.SelectedValue;
        ObjUBO.A27 = txt_Opening_bal.Text;
        ds = PM.Party_Master_Ins_Upd(ObjUBO);
        if (ds.Tables[1].Rows.Count > 0)
        {
            gv.DataSource=ds.Tables[1];
        }
        else
        {
            gv.DataSource = dt;
        }
        gv.DataBind();
        return ds;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            if (ddlClient_name.SelectedItem.Text != "" || ddlClient_name.SelectedValue.ToString() != string.Empty)
                            {
                                if (ddl_state_name.SelectedValue.ToString() != string.Empty)
                                {
                                    if (ddl_state_name.SelectedValue.ToString() != string.Empty)
                                    {
                                       ds= Save_Update("U");
                                        if (ds.Tables[0].Rows.Count>0)
                                        {
                                            if (ViewState["UPDATED_ID"] != null)
                                            {
                                                Alert_msg("Updated Successfully", "btnUpdate");
                                            }
                                            else
                                            {
                                                Alert_msg("Saved Successfully", "btnUpdate");
                                                HD_Showcon.Value = "SAVED";
                                            }
                                        }
                                        else
                                        {
                                            btnUpdate.Visible = true;
                                            btnDelete.Visible = true;
                                            btnSave.Visible = false;
                                            btnNew.Visible = true;
                                            Alert_msg("Not Saved", "btnUpdate");
                                        }
                                    }
                                    else
                                    {
                                        Alert_msg("Enter Ur GSTN Number!", "txt_Gst_Number");
                                    }
                                }
                                else
                                {
                                    Alert_msg("Select Ur State Name !", "ddl_state_name");
                                }
                            }
            else
            {
                Alert_msg("Select Ur Party Name or Branch !", "ddlPartyName");
            }
        
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DataSet ds=new DataSet();
        try
        {
            ds = Save_Update("D");
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnNew_Click1(sender, e);
                Alert_msg("Deleted");
            }
            else
            {
                Alert_msg("Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnDelete_Click_II(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = Save_Update_II("DELETE");
            if (ds.Tables[0].Rows.Count > 0)
            {
              
                Alert_msg("Deleted");
                clear_II();
            }
            else
            {
                Alert_msg("Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        btnUpdate.CssClass = "updates";

        ViewState["PARTY_ID"] = null;
        ViewState["UPDATED_ID"] = null;
        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;

        HDupdate_id.Value = string.Empty;
        ddlClient_name.Enabled = false;
        clear();
    }

    private void clear()
    {
        txtParty_Add_1.Text = string.Empty;
        txtParty_Add_2.Text = string.Empty;
        txtParty_Add_3.Text = string.Empty;
        txtParty_Add_4.Text = string.Empty;
        txtParty_Add_5.Text = string.Empty;
        ddlUnder.SelectedIndex = -1;
        ddlBank_details.SelectedIndex = -1;
        txt_Pan_Tan_No.Text = string.Empty;
        ddlGst_Reg_Type.SelectedIndex = -1;
        ddl_state_name.SelectedIndex = -1;
        txt_Gst_Number.Text = string.Empty;
        txt_Credit_Amt.Text = string.Empty;
        txt_Debit_Amt.Text = string.Empty;
        ddlPartyName.SelectedIndex = -1;
        ddlPartybranch_Name.SelectedIndex = -1;
        txt_Opening_bal.Text = "";
        txt_Tds_Rate.Text = "";
        ddlTDS_Section.SelectedIndex = -1;

    }
    protected void ddlClient_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Branch_details();
    }
    private void Load_Branch_details()
    {
        ddl_Client_branch_No.Items.Clear();
        DataSet dss = new DataSet();
        if (ddlClient_name.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A1 = ddlClient_name.SelectedValue.ToString();
            ObjUBO.A15 = "Client_Branch_Select";
            dss = PM.Party_Master_Data(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddl_Client_branch_No.DataSource = dss.Tables[0];
                ddl_Client_branch_No.DataTextField = "BR_SLNO";
                ddl_Client_branch_No.DataValueField = "BR_SLNO";
                ddl_Client_branch_No.DataBind();
            }
           
            ddl_Client_branch_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Client_branch_No.SelectedIndex = 0;

            if (Ch_Same_as_Party.Checked == true)
            {
                ddlPartyName.SelectedValue = ddlClient_name.SelectedValue.ToString();
            }
        }
    }
    protected void ddlPartyName_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Party_Branch();
       // Ch_Same_as_Party_CheckedChanged(sender, e);
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        gridbind();
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
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["CLIENT_ID"] = Convert.ToString(this.gv.SelectedDataKey.Value);
        if (ViewState["CLIENT_ID"] != "")
        {
            ddlPartyName.SelectedValue = System.Net.WebUtility.HtmlDecode(gv.SelectedRow.Cells[2].Text); 
            Party_Br();
            ddlPartybranch_Name.SelectedValue = gv.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            HDupdate_id_II.Value = ViewState["CLIENT_ID"].ToString();
            ViewState["UPDATED_ID"] = null;

          
            btnSave1.Text = "Update";
            btnDelete1.Visible = true;
            btnSave1.Visible = true;
          
            btnNew.Visible = true;
        }
        else
        {
            btnSave1.Text = "Save";
            btnDelete1.Visible = false;
            btnSave1.Visible = true;
            btnNew.Visible = true;
        }
    }
         
    private void gridbind()
    {
        gv.DataSource = dt;
        gv.DataBind();
    }

    protected void ddlPartybranch_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
       // load_Party_Add();
    }
    private void load_Party_Add()
    {
        DataSet ds = new DataSet();
        if (ddlPartyName.SelectedValue.ToString() != string.Empty && ddlPartybranch_Name.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A1 = ddlPartyName.SelectedValue.ToString();
            ObjUBO.A3 = ddlPartybranch_Name.SelectedValue.ToString();
            ObjUBO.A15 = "Party_Add_Select";
            ds = PM.Party_Master_Data(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtParty_Add_1.Text = ds.Tables[0].Rows[0]["ADD_I"].ToString();
                txtParty_Add_2.Text = ds.Tables[0].Rows[0]["ADD_II"].ToString();
                txtParty_Add_3.Text = ds.Tables[0].Rows[0]["CITY"].ToString();
                txtParty_Add_5.Text = ds.Tables[0].Rows[0]["PIN_CODE"].ToString();
                txt_Pan_Tan_No.Text= ds.Tables[0].Rows[0]["TAN_PAN_NO"].ToString();
                txt_Gst_Number.Text= ds.Tables[0].Rows[0]["GSTN_ID"].ToString();
                ddl_state_name.SelectedValue=ds.Tables[0].Rows[0]["STATE_CODE"].ToString();
            }
            else
            {
                Party_Add_Clear();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                txtParty_Add_4.Text = ds.Tables[1].Rows[0]["STATE_NAME"].ToString();
            }
            else
            {
                txtParty_Add_5.Text = "";
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                txt_Credit_Amt.Text = ds.Tables[2].Rows[0]["Cr_Total_Amt"].ToString();
            }
            else
            {
                txt_Credit_Amt.Text = "";
            }
        }
        else
        {
            Party_Add_Clear();
            txt_Credit_Amt.Text = "";
        }
    }
    private void Party_Add_Clear()
    {
        txtParty_Add_1.Text = "";
        txtParty_Add_2.Text = "";
        txtParty_Add_3.Text = "";
        txtParty_Add_4.Text = "";
        txtParty_Add_5.Text = "";
    }
    protected void ddl_Client_branch_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Party_Name();
        Ch_Same_as_Party_CheckedChanged(sender, e);
    }
    private void load_Party_Name()
    {
        DataSet ds = new DataSet();
        ddlPartyName.Items.Clear();
        if (ddlClient_name.SelectedValue.ToString() != string.Empty && ddl_Client_branch_No.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A1 = ddlClient_name.SelectedValue.ToString();
            ObjUBO.A4 = ddl_Client_branch_No.SelectedValue.ToString();
            
            ObjUBO.A15 = "PartyMasterName_select";
            ds = PM.Party_Master_Data(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPartyName.DataSource = ds.Tables[0];
                ddlPartyName.DataTextField = "CLIENT_NAME";
                ddlPartyName.DataValueField = "CLIENT_NAME";
                ddlPartyName.DataBind();
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                txtParty_Add_1.Text = ds.Tables[1].Rows[0]["ADD_I"].ToString();
                txtParty_Add_2.Text = ds.Tables[1].Rows[0]["ADD_II"].ToString();
                txtParty_Add_3.Text = ds.Tables[1].Rows[0]["CITY"].ToString();
                txtParty_Add_5.Text = ds.Tables[1].Rows[0]["PIN_CODE"].ToString();
                txt_Pan_Tan_No.Text = ds.Tables[1].Rows[0]["TAN_PAN_NO"].ToString();
                txt_Gst_Number.Text = ds.Tables[1].Rows[0]["GSTN_ID"].ToString();
                ddl_state_name.SelectedValue = ds.Tables[1].Rows[0]["STATE_CODE"].ToString();
            }
            else
            {
                Party_Add_Clear();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                txtParty_Add_4.Text = ds.Tables[2].Rows[0]["STATE_NAME"].ToString();
            }
            else
            {
                txtParty_Add_5.Text = "";
            }



        }
        ddlPartyName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlPartyName.SelectedIndex = 0;    
    }

    private void load_Party_Branch()
    {
        DataSet ds = new DataSet();
        ddlPartybranch_Name.Items.Clear();
        txt_Debit_Amt.Text = "";
        txt_Credit_Amt.Text = "";
        if (ddlClient_name.SelectedValue.ToString() != string.Empty && ddl_Client_branch_No.SelectedValue.ToString() != string.Empty && ddlPartyName.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A1 = ddlClient_name.SelectedValue.ToString();
            ObjUBO.A3 = ddl_Client_branch_No.SelectedValue.ToString();
            ObjUBO.A5 = ddlPartyName.SelectedValue.ToString();
            ObjUBO.A15 = "PartyMasterBranch_select";
            ds = PM.Party_Master_Data(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPartybranch_Name.DataSource = ds.Tables[0];
                ddlPartybranch_Name.DataTextField = "BR_SLNO";
                ddlPartybranch_Name.DataValueField = "BR_SLNO";
                ddlPartybranch_Name.DataBind();
            }
            ddlPartybranch_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlPartybranch_Name.SelectedIndex = 0;
            
            if (ds.Tables[1].Rows.Count > 0)
            {
                txt_Credit_Amt.Text = ds.Tables[1].Rows[0]["Cr_Total_Amt"].ToString();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                txt_Debit_Amt.Text = ds.Tables[2].Rows[0]["Debit_Amount"].ToString();
            }
        }
    }

    private void Party_Br()
    { 
         DataSet ds = new DataSet();
         ddlPartybranch_Name.Items.Clear();
         if (ddlPartyName.SelectedValue.ToString() != string.Empty)
         {
             ObjUBO.A1 = ddlPartyName.SelectedValue.ToString();
             ObjUBO.A15 = "Client_Br_select";
             ds = PM.Party_Master_Data(ObjUBO);
             if (ds.Tables[0].Rows.Count > 0)
             {
                 ddlPartybranch_Name.DataSource = ds.Tables[0];
                 ddlPartybranch_Name.DataTextField = "BR_SLNO";
                 ddlPartybranch_Name.DataValueField = "BR_SLNO";
                 ddlPartybranch_Name.DataBind();
             }
             ddlPartybranch_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
             ddlPartybranch_Name.SelectedIndex = 0;
         }
    
    }

    private void load_Party_Cr_Amt()
    {
        DataSet ds = new DataSet();
        txt_Credit_Amt.Text = "";
        txt_Debit_Amt.Text = "";
        if (ddlPartyName.SelectedValue.ToString() != string.Empty && ddlPartybranch_Name.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A1 = ddlPartyName.SelectedValue.ToString();
            ObjUBO.A3 = ddlPartybranch_Name.SelectedValue.ToString();
            ObjUBO.A15 = "Party_Cr_Amt_select";
            ds = PM.Party_Master_Data(ObjUBO);
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_Credit_Amt.Text = ds.Tables[0].Rows[0]["Cr_Total_Amt"].ToString();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                txt_Debit_Amt.Text = ds.Tables[1].Rows[0]["Debit_Amount"].ToString();
            }
        }
    }
   
    protected void Ch_Same_as_Party_CheckedChanged(object sender, EventArgs e)
    {
        if (Ch_Same_as_Party.Checked == true)
        {
            ddlPartyName.SelectedValue = ddlClient_name.SelectedValue.ToString();
            ddlPartyName_SelectedIndexChanged(sender, e);
        }
    }
    protected void btnNew_Click2(object sender, EventArgs e)
    {
        ddlPartyName.SelectedIndex = -1;
        ddlPartybranch_Name.Items.Clear();
        btnDelete1.Visible = false;
        HDupdate_id_II.Value = "";
        btnSave1.Text = "Save";
    }
}