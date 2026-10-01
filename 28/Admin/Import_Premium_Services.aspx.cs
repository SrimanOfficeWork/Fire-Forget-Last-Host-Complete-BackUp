using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;

public partial class Import_Premium_Services : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();

    Admin_User_Creation_cs UC = new Admin_User_Creation_cs();
    
    public string COMPANY_LICENSE, COMPANY_ID;

    public int i;
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
       
         if (Session["COMP_LICENSE"] != "" && Session["COMP_LICENSE"] != null)
         {
            COMPANY_LICENSE = Session["COMP_LICENSE"].ToString();
            if (Session["COMP_ID"] != "" && Session["COMP_ID"] != null)
            {
                COMPANY_ID = Session["COMP_ID"].ToString();
                hdn_Company_ID.Value = COMPANY_ID;
            }
         }
         Rd_Active_Inactive.Items[0].Attributes.Add("style", "color:green;");
         Rd_Active_Inactive.Items[1].Attributes.Add("style", "color:red;");
        if (!IsPostBack)
        {
            txt_Createdon.Text = DateTime.Now.ToString("dd/MM/yyyy");
            CalendarExtender2.EndDate = DateTime.Today;
            btn_Update.Visible = false;
            btn_Delete.Visible = false;
            load_Grid();
        }
    }
    private void load_Grid()
    {
        try
        {
            ObjUBO.A1 = COMPANY_LICENSE;
            ObjUBO.A2 = COMPANY_ID;
            ObjUBO.A3 = "I";
            ObjUBO.A40 = "Data_Select";
            ds = UC.Admin_Premium_Services_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = ds.Tables[0];
            }
            else
            {
                gvdetails.DataSource = dt;
            }
            gvdetails.DataBind();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
                if ((Rd_Active_Inactive.SelectedValue.ToString() == "A") || (Rd_Active_Inactive.SelectedValue.ToString() == "IA" && txt_InActive_Date.Text != string.Empty))
                {
                    ds = Insert_Update("S");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        hdn_update_Id.Value = ds.Tables[0].Rows[0][0].ToString();

                        btn_Update.CssClass = "save";
                        btn_Update.Visible = true;
                        btn_Save.Visible = false;
                        btn_Save.Focus();

                        gvdetails.DataSource = ds.Tables[1];
                        gvdetails.DataBind();

                        ViewState["UPDATED_ID"] = null;
                        Alert_msg("Saved Successfully", "btn_Save");

                    }
                    else
                    {
                        Alert_msg("User already exists!", "btn_Save");
                    }
                }
                else
                {
                    Alert_msg(" Enter Ur InActive_Date!", "txt_InActive_Date");
                }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public DataSet Insert_Update(string Flag)
    {
        ObjUBO.A1 = hdn_update_Id.Value;
        ObjUBO.A2 = COMPANY_LICENSE;
        ObjUBO.A3 = COMPANY_ID;
        ObjUBO.A4 = "I";
        ObjUBO.A5 = ddlPurchase.SelectedValue.ToString();
        ObjUBO.A6 = txt_Createdon.Text;
        ObjUBO.A7 = Rd_Active_Inactive.SelectedValue.ToString();
        ObjUBO.A8 = txt_Active_Date.Text;
        ObjUBO.A9 = txt_InActive_Date.Text;
        ObjUBO.A10 = txt_Remarks.Text;
        ObjUBO.A11 = txt_Lead_by.Text;
        ObjUBO.A12 = ddlapi.SelectedValue.ToString();
        ObjUBO.A13 = txtupcount.Text;
        ObjUBO.A20 = Flag;
        return UC.Admin_Premium_Services_Insert_Update(ObjUBO); ;
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
            {

        if ((Rd_Active_Inactive.SelectedValue.ToString() == "A") || (Rd_Active_Inactive.SelectedValue.ToString() == "IA" && txt_InActive_Date.Text != string.Empty))
            {
                 ds=Insert_Update("U");
                  if (ds.Tables[0].Rows.Count > 0)
                  {
                     gvdetails.DataSource = ds.Tables[1];
                     gvdetails.DataBind();

                             if (ViewState["UPDATED_ID"] != null)
                             {
                                 Alert_msg("Updated Successfully", "btn_Update");
                             }
                             else
                             {
                                 Alert_msg("Saved Successfully", "btn_Update");
                             }
                    }
                    else
                    {
                        Alert_msg("Not Updated", "btn_Update");
                    }
                        }
                    else
                    {
                        Alert_msg(" Enter Ur InActive_Date!", "txt_InActive_Date");
                    }
                
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
    }
    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            if (i == 1)
            {
                Alert_msg("Deleted");
                btn_New_Click(sender, e);
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
    protected void btn_New_Click(object sender, EventArgs e)
    {
        ddlPurchase.SelectedIndex = -1;
        txt_Remarks.Text = string.Empty;
        txt_Lead_by.Text = string.Empty;
        txt_InActive_Date.Text = string.Empty;
        btn_Save.Visible = true;
        btn_Update.Visible = false;
        btn_Delete.Visible = false;
        load_Grid();
        hdn_update_Id.Value = "";
        ViewState["DB_UPDATED_ID"] = null;
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["UPDATED_ID"] = gvdetails.DataKeys[gvdetails.SelectedRow.RowIndex].Values["P_ID"].ToString();

        if (ViewState["UPDATED_ID"] != "" && ViewState["UPDATED_ID"] != null)
        {
            LoginId.Style.Add("display", "block");
            hdn_update_Id.Value = ViewState["UPDATED_ID"].ToString();

            ddlPurchase.SelectedValue = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            txt_Createdon.Text = gvdetails.SelectedRow.Cells[5].Text.Replace("&nbsp;", ""); 
            txt_Active_Date.Text = gvdetails.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            txt_InActive_Date.Text = gvdetails.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");

            txt_Remarks.Text = gvdetails.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            txt_Lead_by.Text = gvdetails.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            Rd_Active_Inactive.SelectedValue = gvdetails.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            ddlapi.SelectedValue = gvdetails.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            txtupcount.Text = gvdetails.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");

            btn_Update.CssClass = "updates";
            btn_Delete.Visible = false;
            btn_Update.Visible = true;
            btn_Save.Visible = false;
            btn_New.Visible = true;
        }
        else
        {
            LoginId.Style.Add("display", "none");
        }
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex.ToString()));

            if (DataBinder.Eval(e.Row.DataItem, "F_STATUS").ToString() == "A")
            {
                e.Row.ForeColor = System.Drawing.Color.Green;
            }
            else if (DataBinder.Eval(e.Row.DataItem, "F_STATUS").ToString() == "IA")
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    protected void gvdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdetails.PageIndex = e.NewPageIndex;
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Royal Admin User', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Royal Admin User', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}