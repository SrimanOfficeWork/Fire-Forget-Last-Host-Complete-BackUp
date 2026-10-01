using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Data.SqlClient;

public partial class Group_Creation : ThemeClass
{

    AppSession aps = new AppSession();
    Areawise_Group_Creation GC = new Areawise_Group_Creation();
    Global_variables ObjUBO = new Global_variables();

    //----------------------------------------------------------------------------------------
    Company_Master Comp = new Company_Master();
    User_Creation User = new User_Creation();
    adminmaster admin = new adminmaster();
    Transaction trans = new Transaction();
    
    public int i;
    
    public string COMPANY_ID;
    public string CHA_LICENSE_ID;
    public string USER_CREATION_ID, BRANCH_ID, BRANCH, flag;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Pageload();
    }
    public void Pageload()
    {
        if (Session["COMP_LICENSE_NO"]!=null || Session["COMP_ID"]!=null)
        {
            COMPANY_ID = Session["COMP_ID"].ToString();
             if (Session["COMP_LICENSE_NO"]!=null || Session["COMP_ID"]!=null)
             {
                 if (Session["ADMIN_USER_CREATION_ID"] != null || Session["ADMIN_USER_CREATION_ID"] != null)
                 {
                     USER_CREATION_ID = Session["ADMIN_USER_CREATION_ID"].ToString();
                 }
                 else
                 {
                     Response.Write("<script>window.open('Login_Details.aspx','_parent');</script>");
                 }
             }
        }
        else
        {
            Response.Write("<script>window.open('Company_Master.aspx','_parent');</script>");
        }

        Branch_Common();
        if (!IsPostBack)
        {
            Gridbind();
        }
    }
    private void Branch_Common()
    {
        DataSet ds = new DataSet();
        ObjUBO.A4 = Session["COMP_LICENSE_NO"].ToString();
        ObjUBO.A5 = "Branch_Common_Select";
        ds = GC.Admin_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["SELECT_JOB"].ToString() == "Common Job")
            {
                ViewState["Branch_Common"] = "Common";
                btnBranch_New.Visible=false;
                btnBranch_Save.Visible=false;
                btnBranch_Update.Visible=false;
                btnBranch_Delete.Visible = false;

                ObjUBO.A3 = "Common_Ins";
                ObjUBO.A7 = ConvertDataTableToXML(ds.Tables[1]);
                ds = GC.Group_Creation_Select(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gv.DataSource = ds.Tables[0];
                    gv.DataBind();
                    lblcnt.Text = ds.Tables[0].Rows.Count.ToString();
                }
                else
                {
                    load_Empty_grid();
                    lblcnt.Text = "0";
                }

            }
            else if (ds.Tables[0].Rows[0]["SELECT_JOB"].ToString() == "Branchwise Job")
            {
                ViewState["Branch_Common"] = "Branch";
                btnBranch_New.Visible = false;
                btnBranch_Save.Visible = false;
                btnBranch_Update.Visible = false;
                btnBranch_Delete.Visible = false;

                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataSet dss = new DataSet();
                    ObjUBO.A3 = "Branch_Ins";
                    ObjUBO.A7 = ConvertDataTableToXML(ds.Tables[1]);
                    dss = GC.Group_Creation_Select(ObjUBO);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        gv.DataSource = dss.Tables[0];
                        gv.DataBind();
                        lblcnt.Text = dss.Tables[0].Rows.Count.ToString();
                    }
                    else
                    {
                        load_Empty_grid();
                        lblcnt.Text = "0";
                    }
                }
                else
                {
                    load_Empty_grid();
                    lblcnt.Text = "0";
                }
            }
            else
            {
                ViewState["Branch_Common"] = "";
              ///
            }
        }
    }
    public void Gridbind()
    {
        DataSet ds = new DataSet();
        ObjUBO.A3 = "Group_Name_Select";
        ds = GC.Group_Creation_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            gv.DataSource = ds.Tables[0];
            gv.DataBind();
            lblcnt.Text = ds.Tables[0].Rows.Count.ToString();
        }
        else
        {
            load_Empty_grid();
            lblcnt.Text = "0";
        }
    }
    protected void btnBranch_Save_Click(object sender, EventArgs e)
    {
        DataSet dss = new DataSet();
        if (txt_Groupname.Text != "")
        {
            try
            {
               Insert_Update("S");
                if (i == 1)
                {
                    btnBranch_New_Click(sender, e);
                    txt_Groupname.Focus();
                    ViewState["UPDATED_ID"] = null;
                    HDupdate_id.Value = Convert.ToString(GC.UPDATE_ID);
                    Alert_msg("Saved Successfully", "btnSave");
                }
                else if (i == 2)
                {
                    Alert_msg("Group Name Already Exist!", "btnSave");
                }
                else
                {
                    Alert_msg("Group Name Not Saved", "btnSave");
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
        else
        {
            Alert_msg("Enter the Group Name", "btnSave");
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Group Creation', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Group Creation', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnBranch_New_Click(object sender, EventArgs e)
    {
        trans.ResetFields(Page.Controls);
        btnBranch_Save.Visible = true;
        btnBranch_Update.Visible = false;
        btnBranch_Delete.Visible = false;
        ViewState["UPDATED_ID"] = null;
        HDupdate_id.Value = string.Empty;
    }
    protected void btnBranch_Update_Click(object sender, EventArgs e)
    {
        if (txt_Groupname.Text != "")
        {
            try
            {
                i = Insert_Update("U");
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
                    Alert_msg("Group Name Already Exist!", "btnUpdate");
                }
                else
                {
                    Alert_msg("Not Updated", "btnUpdate");
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
        else
        {
            Alert_msg("Enter the Group Name ?");
        }
    }
  
    private void load_Empty_grid()
    {
        DataTable dt = new DataTable();
        gv.DataSource = dt;//add empty row
        gv.DataBind();
    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        gv.DataBind();
    }
    protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
    {
        /*
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
        */
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["Group_Id"] = Convert.ToString(this.gv.SelectedDataKey.Value);
        if (ViewState["Group_Id"] != "" && ViewState["Group_Id"] != null)
        {
            HDupdate_id.Value = Convert.ToString(this.gv.SelectedDataKey.Value);

            txt_Groupname.Text = gv.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            btnBranch_Update.CssClass = "updates";

            btnBranch_Save.Visible = false;
            btnBranch_Update.Visible = true;
            btnBranch_Delete.Visible = true;
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["Group_Id"].ToString();
        }
        else
        {
            btnBranch_Update.Visible = false;
            btnBranch_Delete.Visible = false;
            btnBranch_Save.Visible = true;
        }

        if (ViewState["Branch_Common"] == "Branch" || ViewState["Branch_Common"] == "Common")
        {
            btnBranch_New.Visible = false;
            btnBranch_Save.Visible = false;
            btnBranch_Update.Visible = false;
            btnBranch_Delete.Visible = false;
        }
    }
    protected void btnBranch_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            i = Insert_Update("D");
            if (i==1)
            {
                txt_Groupname.Text = "";
                btnBranch_Update.Visible = false;
                btnBranch_Delete.Visible = false;
                btnBranch_Save.Visible = true;
                Alert_msg("Deleted");
            }
            else if (i == 3)
            {
                Alert_msg("Not Deleted this Group linled with Current Jobno ! ");
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
    public int Insert_Update(string flag)
    {
        DataSet ds = new DataSet();
        try
        {
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A2 = txt_Groupname.Text;
            ObjUBO.A3 = flag;
            ds = GC.Group_Creation_Select(ObjUBO);
            i = GC.result;
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = ds.Tables[0];
                gv.DataBind();
                lblcnt.Text = ds.Tables[0].Rows.Count.ToString();
            }
            else
            {
                load_Empty_grid();
                lblcnt.Text = "0";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return i;
    }
    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }
}