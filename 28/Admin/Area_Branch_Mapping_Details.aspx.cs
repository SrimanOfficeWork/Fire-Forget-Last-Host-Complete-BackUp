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


public partial class Area_Branch_Mapping_Details : ThemeClass
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
            Load_data();
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
                btnBranch_New.Visible = false;
                btnBranch_Save.Visible = false;
                btnBranch_Delete.Visible = false;
                ViewState["Branch_Common"] = "Common";
            }
            else if (ds.Tables[0].Rows[0]["SELECT_JOB"].ToString() == "Branchwise Job")
            {
                btnBranch_New.Visible = false;
                btnBranch_Save.Visible = false;
                btnBranch_Delete.Visible = false;
                ViewState["Branch_Common"] = "Branch";
            }
            else
            {
                ViewState["Branch_Common"] = "";
            }
        }
    }
    protected void btnBranch_Save_Click(object sender, EventArgs e)
    {
        DataSet dss = new DataSet();
        
        if (ddlBranch.SelectedValue.ToString()!=string.Empty)
        {
            if (ddl_Group_name.SelectedValue.ToString() != string.Empty)
            {
                try
                {
                    Insert_Update("SS");
                    if (i == 1)
                    {
                        btnBranch_New_Click(sender, e);
                        ddlBranch.Focus();
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
            else {

                Alert_msg("Select Ur Group Name", "btnSave");
            }
        }
        else
        {
            Alert_msg("Select Ur Branch Name", "btnSave");
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
        btn_new();
    }
    private void btn_new()
    {
        trans.ResetFields(Page.Controls);
        btnBranch_Save.Visible = true;
        // btnBranch_Update.Visible = false;
        btnBranch_Delete.Visible = false;
        ViewState["UPDATED_ID"] = null;
        HDupdate_id.Value = string.Empty;
        lbl_CustomHouse.Text = string.Empty;
        lbl_Tr_mode.Text = string.Empty;
        Load_data();
    
    }
    protected void btnBranch_Update_Click(object sender, EventArgs e)
    {
         if (ddlBranch.SelectedValue.ToString()!=string.Empty)
        {
            if (ddl_Group_name.SelectedValue.ToString() != string.Empty)
            {
                try
                {
                        i = Insert_Update("UU");
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

                Alert_msg("Select Ur Group Name", "btnSave");
            }
        }
         else
         {
             Alert_msg("Select Ur Branch Name", "btnSave");
         }
    }
    public void Gridbind()
    {
        DataSet ds =new DataSet();
        ObjUBO.A3 = "Group_and_Branch_Name_Select";
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
        string Br = string.Empty;
        if (ViewState["Group_Id"] != "" && ViewState["Group_Id"] != null)
        {
            HDupdate_id.Value = Convert.ToString(this.gv.SelectedDataKey.Value);
            ddlBranch.Items.Clear();
            lbl_Tr_mode.Text = string.Empty;
            lbl_CustomHouse.Text = string.Empty;

            Br = gv.SelectedRow.Cells[6].Text.Replace("&nbsp;", "") + "-" + gv.SelectedRow.Cells[5].Text.Replace("&nbsp;", "") + "-" + gv.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            ddlBranch.Items.Insert(0, new ListItem(Br, gv.SelectedRow.Cells[5].Text.Replace("&nbsp;", "")));
            ddlBranch.SelectedIndex = 0;

            ddl_Group_name.SelectedValue = gv.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            lbl_Tr_mode.Text = gv.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            lbl_CustomHouse.Text = gv.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");


            //btnBranch_Update.CssClass = "updates";
            btnBranch_Save.Visible = false;
           // btnBranch_Update.Visible = true;
            btnBranch_Delete.Visible = true;
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["Group_Id"].ToString();
        }
        else
        {
           // btnBranch_Update.Visible = false;
            btnBranch_Delete.Visible = false;
            btnBranch_Save.Visible = true;
        }
       // gv.SelectedRow.BackColor = System.Drawing.Color.Orange ;
        if (ViewState["Branch_Common"] == "Branch" || ViewState["Branch_Common"] == "Common")
        {
            btnBranch_New.Visible = false;
            btnBranch_Save.Visible = false;
            btnBranch_Delete.Visible = false;
        }
    }
    protected void btnBranch_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            i = Insert_Update("DD");

            if (i==1)
            {
                btnBranch_Delete.Visible = false;
                btnBranch_Save.Visible = true;
                Alert_msg("Deleted");
                btn_new();
            }
            else if (i == 3)
            {
                Alert_msg("Not Deleted this Group Id linled with Current Jobno ! ");
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
            ObjUBO.A2 = ddl_Group_name.SelectedValue.ToString();
            ObjUBO.A3 = flag;
            ObjUBO.A4 = ddlBranch.SelectedValue.ToString();
            ObjUBO.A5 = lbl_Tr_mode.Text;
            ObjUBO.A6 = lbl_CustomHouse.Text;

            ds = GC.Group_Creation_Select(ObjUBO);
            i = GC.result;
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = ds.Tables[0];
                gv.DataBind();
            }
            else
            {
                load_Empty_grid();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return i;
    }
    private void Load_Branch()
    {
        ddlBranch.Items.Clear();
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        ObjUBO.A3 = "Branch_Name_Select";
        ds = GC.Group_Creation_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ObjUBO.A4 = ConvertDataTableToXML(ds.Tables[0]);
            ObjUBO.A5 = "Branch_Name_Location_Select";
            dss = GC.Admin_Select(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlBranch.DataSource = dss.Tables[0];
                ddlBranch.DataTextField = "BRANCH";
                ddlBranch.DataValueField = "Branch_Name";
                ddlBranch.DataBind();
            }
        }
        ddlBranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlBranch.SelectedIndex = 0;
    }
    private void Load_Area()
    {
        ddl_Group_name.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.A3 = "Area_Name_Select";
        ds = GC.Group_Creation_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Group_name.DataSource = ds.Tables[0];
            ddl_Group_name.DataTextField = "GROUP_NAME";
            ddl_Group_name.DataValueField = "GROUP_ID";
            ddl_Group_name.DataBind();

            ddlgroup_Filter.DataSource = ds.Tables[0];
            ddlgroup_Filter.DataTextField = "GROUP_NAME";
            ddlgroup_Filter.DataValueField = "GROUP_ID";
            ddlgroup_Filter.DataBind();
        }
        ddl_Group_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Group_name.SelectedIndex = 0;
        ddlgroup_Filter.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlgroup_Filter.SelectedIndex = 0;
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
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBranch.SelectedValue.ToString() != string.Empty)
        {
            string[] arr_Branch = new string[] { };
            //arr_Branch = ddlBranch.SelectedValue.ToString().Split('-');
            arr_Branch = ddlBranch.SelectedItem.ToString().Split('-');
            lbl_Tr_mode.Text = arr_Branch[2];
            lbl_CustomHouse.Text = arr_Branch[1];
        }
        else
        {
            lbl_Tr_mode.Text = string.Empty;
            lbl_CustomHouse.Text = string.Empty;
        }
    }
    private void Load_data()
    {
        Gridbind();
        Load_Area();
        Load_Branch();

        if (gv.Rows.Count > 0)
        {
            lblcnt.Text = gv.Rows.Count.ToString();
        }
        else 
        {
            lblcnt.Text = "0";
        }
    }
    protected void ddlgroup_Filter_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (ddlgroup_Filter.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A1 = ddlgroup_Filter.SelectedValue.ToString();
            ObjUBO.A3 = "Group_Filter_Select";
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
        else 
        {
            Gridbind();
        }
        


        ddl_Group_name.Items.Clear();
        DataSet dss = new DataSet();
        ObjUBO.A3 = "Area_Name_Select";
        dss = GC.Group_Creation_Select(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddl_Group_name.DataSource = dss.Tables[0];
            ddl_Group_name.DataTextField = "GROUP_NAME";
            ddl_Group_name.DataValueField = "GROUP_ID";
            ddl_Group_name.DataBind();
        }
        ddl_Group_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Group_name.SelectedIndex = 0;

        Load_Branch();
        lbl_CustomHouse.Text = string.Empty;
        lbl_Tr_mode.Text = string.Empty;
    }
}