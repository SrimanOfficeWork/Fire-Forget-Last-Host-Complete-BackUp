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

public partial class Billing_Party : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    Party_Master_cs PM = new Party_Master_cs();
    Global_variables ObjUBO = new Global_variables();

    DataTable dt = new DataTable();

    public int i, Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
         aps.checkSession();
                if (!Page.IsPostBack)
                {
                    //----------------SETTING SCREEN PERMISSION---------------//
                    Screen_Id = 11;
                    //----------------SETTING SCREEN PERMISSION---------------//

                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;

                    if (Request.QueryString["Partyname"] == null)
                    {
                       HDupdate_id.Value = "";
                       txt_Partyname.Enabled = true;
                       txt_Branch.Enabled = true;
                       gv_Party.DataSource = dt;
                       gv_Party.DataBind();
                    }
                    else
                    {
                        if (Request.QueryString["Partyname"] != null && Request.QueryString["Partyname"] != string.Empty)
                        {
                            txt_Partyname.Enabled = false;
                            Update_Item_Load(Request.QueryString["Partyname"].ToString());

                            btnDelete.Visible = false;
                            btnUpdate.Visible = false;
                            btnSave.Visible = true;
                        }
                    }
                }
        
         }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);



        }
    }
    private void Update_Item_Load(string C_Name)
    {
        txt_Partyname.Text = "";
        txt_IEC_No.Text = "";

        DataSet dss = new DataSet();
        ObjUBO.A2 = C_Name;
        ObjUBO.A15 = "Updated_Data_Select";
        dss = PM.Billing_Party_Data_Select(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            txt_Partyname.Style.Add("background-color", "#F0F0F0");
            txt_IEC_No.Style.Add("background-color", "#F0F0F0");

            txt_Partyname.Text = dss.Tables[0].Rows[0]["CLIENT_NAME"].ToString();
            txt_IEC_No.Text = dss.Tables[0].Rows[0]["IEC_NO"].ToString();

            gv_Party.DataSource = dss.Tables[0];
            gv_Party.DataBind();
        }
        else
        {
            gv_Party.DataSource = dt;
            gv_Party.DataBind();
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Party Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Party Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void gv_Party_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (txt_Partyname.Text != "")
        {
            if (txt_Branch.Text != string.Empty)
            {
                if (ddl_state_name.SelectedValue.ToString() != string.Empty)
                {
                    //--------------------------------------------------------------------------------------------------------------------------
                    ds = Save_Update("S");
                    if (ds.Tables[0].Rows.Count > 0)
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
                        //HD_Showcon.Value = "SAVED";
                        Alert_msg("Saved Successfully", "btnSave");
                        HDupdate_id.Value = Convert.ToString(ds.Tables[0].Rows[0]["C_ID"].ToString());
                    }
                    else
                    {
                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                        btnSave.Visible = true;
                        btnNew.Visible = true;
                        Alert_msg("Not Saved.", "btnSave");
                    }
                    //-------------------------------------------------------------
                }
                else
                {
                    Alert_msg("Select Ur State Name!", "ddl_state_name");
                }
            }
            else
            {
                Alert_msg("Enter Ur Branch No !", "txt_Branch");
            }
        }
        else
        {
            Alert_msg("Enter Ur Party Name !", "txt_Partyname");
        }
        //-------------------------------------------------------------------------------------
    }
    private DataSet Save_Update(string Flag)
    {
        DataSet ds = new DataSet();
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = txt_Partyname.Text;
        ObjUBO.A3 = txt_Branch.Text;
        ObjUBO.A4 = txt_IEC_No.Text;
        ObjUBO.A5 = txt_Add_1.Text;
        ObjUBO.A6 = txt_Add_2.Text;
        ObjUBO.A7 = txt_City.Text;
        ObjUBO.A8 = txt_Pin_code.Text;
        ObjUBO.A9 = ddl_state_name.SelectedValue.ToString();
        ObjUBO.A10 = txt_Gst_Number.Text;
        ObjUBO.A11 = txt_Pan_Tan_No.Text;
        ObjUBO.A12 = Rd_Active_Inactive.SelectedValue.ToString();

        ObjUBO.A30 = Flag;
        ds = PM.Billing_Party_Ins_Upd(ObjUBO);

        return ds;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            if (txt_Partyname.Text != "")
            {
                if (txt_Branch.Text != string.Empty)
                {
                    if (ddl_state_name.SelectedValue.ToString() != string.Empty)
                    {
                        ds = Save_Update("U");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ViewState["UPDATED_ID"] != null)
                            {
                                Alert_msg("Updated Successfully", "btnUpdate");
                            }
                            else
                            {
                                Alert_msg("Saved Successfully", "btnUpdate");
                                //HD_Showcon.Value = "SAVED";
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
                        Alert_msg("Select Ur State Name!", "ddl_state_name");
                    }
                }
                else
                {
                    Alert_msg("Enter Ur Branch No !", "txt_Branch");
                }
            }
            else
            {
                Alert_msg("Enter Ur Party Name !", "txt_Partyname");
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = Save_Update("D");
            if (ds.Tables[0].Rows.Count == 0)
            {
                Alert_msg("Deleted");
            }
            else
            {
                Alert_msg("Not Deleted");
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_Party.DataSource = ds.Tables[1];
                gv_Party.DataBind();
            }
            else
            {
                gv_Party.DataSource = dt;
                gv_Party.DataBind();
            }
            btnNew_Click(sender, e);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void gv_Party_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Enabled = true;
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Party, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
    protected void gv_Party_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["C_ID"] = gv_Party.DataKeys[gv_Party.SelectedRow.RowIndex].Values["C_ID"].ToString();
        if (ViewState["C_ID"] != "" && ViewState["C_ID"] != null)
        {
            HDupdate_id.Value = ViewState["C_ID"].ToString();
            txt_Branch.Text = gv_Party.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            txt_Add_1.Text = gv_Party.SelectedRow.Cells[2].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
            txt_City.Text = gv_Party.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            ddl_state_name.SelectedValue = gv_Party.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            txt_Gst_Number.Text = gv_Party.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            Rd_Active_Inactive.SelectedValue = gv_Party.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            txt_Partyname.Text = gv_Party.SelectedRow.Cells[7].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
            txt_Add_2.Text = gv_Party.SelectedRow.Cells[9].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
            txt_Pin_code.Text = gv_Party.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            txt_Pan_Tan_No.Text = gv_Party.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            txt_IEC_No.Text = gv_Party.DataKeys[gv_Party.SelectedRow.RowIndex].Values["IEC_NO"].ToString();

            ViewState["UPDATED_ID"] = ViewState["C_ID"].ToString();

            btnUpdate.CssClass = "updates";
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = true;
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        btnUpdate.CssClass = "updates";

        ViewState["PARTY_ID"] = null;
        ViewState["UPDATED_ID"] = null;
        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;

        HDupdate_id.Value = string.Empty;
        clear();
    }
    private void clear()
    {
        txt_Add_1.Text = string.Empty;
        txt_Add_2.Text = string.Empty;
        txt_Pan_Tan_No.Text = string.Empty;
        ddl_state_name.SelectedIndex = -1;
        txt_Gst_Number.Text = string.Empty;
        txt_Partyname.Text = string.Empty;
        txt_Branch.Text = string.Empty;
    }
}