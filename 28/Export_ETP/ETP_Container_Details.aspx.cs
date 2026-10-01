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

public partial class ETP_Container_Details : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    Exp_ETP TP = new Exp_ETP();
    Global_variables ObjUBO = new Global_variables();

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    public string Exp_Jobno = string.Empty;
    public int i = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Exp_Jobno = Connection.EXP_Jobno();
        if (!Page.IsPostBack)
        {
            if (Exp_Jobno != string.Empty)
            {
              load_Data(Exp_Jobno);
            }
        }
    }
    private void load_Data(string Jobno)
    {
        try
        {
            ObjUBO.A2 = Jobno;
            ObjUBO.A40 = "ETP_Container_Data";
            ds = TP.ETP_Data_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Jobno.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["JOBNO_PS"].ToString(), ds.Tables[0].Rows[0]["JOBNO"].ToString()));
                ddl_Jobno.SelectedIndex = 0;
                gv_Container.DataSource = ds.Tables[0];
                gv_Container.DataBind();
            }
            else
            {
                if (ds.Tables[1].Rows.Count > 0)
                { 
                    ddl_Jobno.Items.Insert(0, new ListItem(ds.Tables[1].Rows[0]["JOBNO_PS"].ToString(), ds.Tables[1].Rows[0]["JOBNO"].ToString()));
                    ddl_Jobno.SelectedIndex = 0;
                    txtJobDate.Text=ds.Tables[1].Rows[0]["JOBDATE"].ToString();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    txt_SbNo.Text = ds.Tables[1].Rows[0]["SB_NO"].ToString();
                    txt_SbDate.Text = ds.Tables[1].Rows[0]["SB_DATE"].ToString();
                }
            }

            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private DataSet Save_Update(string Flag)
    {
        DataSet ds = new DataSet();
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = ddl_Jobno.SelectedValue.ToString();
        ObjUBO.A3 = ddl_Jobno.SelectedItem.Text;
        ObjUBO.A4 = txtJobDate.Text;
        ObjUBO.A5 = txt_SbNo.Text;
        ObjUBO.A6 = txt_SbDate.Text;
        ObjUBO.A7 = txt_Con_no.Text;
        ObjUBO.A8 = txt_Con_Size.Text;
        ObjUBO.A9 = Rd_Lcl_Fcl.SelectedValue.ToString();
        ObjUBO.A10 = txt_Site_Id.Text;
        ObjUBO.A40 = Flag;
        ds = TP.ETP_Container_Ins_Upd(ObjUBO);
        return ds;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddl_Jobno.SelectedValue.ToString() != "") 
        {
            if (txt_Con_no.Text != string.Empty)
            {
                ds = Save_Update("S");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        gv_Container.DataSource = ds.Tables[1];
                        gv_Container.DataBind();
                    }
                    Alert_msg("Container Saved Successfully", "btnSave");
                }
                else
                {
                    Alert_msg("Container Not Saved Already Exist!", "btnSave");
                }
            }
            else
            {
                Alert_msg("Enter Ur Container No !", "txt_Con_no");
            }
        }
        else
        {
            Alert_msg("Enter Ur Jobno", "txt_Jobno");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (ddl_Jobno.SelectedValue.ToString() != "") 
        {
            if (txt_Con_no.Text != string.Empty)
            {
                ds = Save_Update("U");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        gv_Container.DataSource = ds.Tables[1];
                        gv_Container.DataBind();
                    }
                    Alert_msg("Container Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Container Not Updated Already Exist!", "btnUpdate");
                } 
            }
            else
            {
                Alert_msg("Enter Ur Container No !", "txt_Con_no");
            }
        }
        else
        {
            Alert_msg("Enter Ur Jobno", "txt_Jobno");
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        txt_Con_no.Text = string.Empty;
        txt_Con_Size.Text = string.Empty;
        Rd_Lcl_Fcl.SelectedIndex = -1;
        txt_Site_Id.Text = string.Empty;
        HDupdate_id.Value = string.Empty;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        //Gridbind_Import_Container(ddlIGM_SL_No.SelectedValue, "ddl_change");
    }
    protected void gv_Container_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["C_ID"] = gv_Container.DataKeys[gv_Container.SelectedRow.RowIndex].Values["C_ID"].ToString();
        if (ViewState["C_ID"] != "" && ViewState["C_ID"] != null)
        {
            ddl_Jobno.Items.Clear();
            HDupdate_id.Value = ViewState["C_ID"].ToString();
            ddl_Jobno.Items.Insert(0, new ListItem(gv_Container.SelectedRow.Cells[2].Text, gv_Container.DataKeys[gv_Container.SelectedRow.RowIndex].Values["JOBNO"].ToString()));
            ddl_Jobno.SelectedIndex = 0;
            txtJobDate.Text = gv_Container.SelectedRow.Cells[3].Text;
            txt_SbNo.Text = gv_Container.SelectedRow.Cells[4].Text;
            txt_SbDate.Text = gv_Container.SelectedRow.Cells[5].Text;
            txt_Con_no.Text = gv_Container.SelectedRow.Cells[6].Text;
            txt_Con_Size.Text = gv_Container.SelectedRow.Cells[7].Text;
            Rd_Lcl_Fcl.SelectedValue= gv_Container.SelectedRow.Cells[8].Text;
            txt_Site_Id.Text = gv_Container.SelectedRow.Cells[9].Text;

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

    protected void gv_Container_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (hdn_Grid_Disable.Value == "1")
            {
                e.Row.Enabled = false;
            }
            else
            {
                e.Row.Enabled = true;
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Container, "Select$" + e.Row.RowIndex.ToString()));
            }
        }
    }

    protected void gv_Container_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Container.PageIndex = e.NewPageIndex;
       // Gridbind_Container();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A2 = ddl_Jobno.SelectedValue.ToString();
            ObjUBO.A40 = "ETP_Container_Delete";
            ds = TP.ETP_Data_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Container Not Deleted");
            }
            else
            {
                Alert_msg("Container Deleted");
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_Container.DataSource = ds.Tables[1];
                gv_Container.DataBind();
                
            }
            else
            {
                gv_Container.DataSource = dt;
                gv_Container.DataBind();
            }   
            btnNew_Click(sender,e);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void gv_Container_RowCreated(object sender, GridViewRowEventArgs e)
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CONTAINER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CONTAINER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnSaveNew_Click(object sender, EventArgs e)
    {
        /*
        click_SaveNew = "SaveNew_Click";
        btnSave_Click(sender, e);
        Transact.ResetFields(Page.Controls);
        txtContainerNo.Focus();
        */
    }
   
    protected void btn_DeleteAll_Click(object sender, EventArgs e)
    {
        ObjUBO.A2 = ddl_Jobno.SelectedValue.ToString();
        ObjUBO.A40 = "ETP_All_Container_Delete";
        ds = TP.ETP_Data_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Alert_msg("Container Not Deleted");
        }
        else
         {
             Alert_msg("All Container Deleted");
             gv_Container.DataSource = ds.Tables[0];
             gv_Container.DataBind();
         }    

        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
    }
}