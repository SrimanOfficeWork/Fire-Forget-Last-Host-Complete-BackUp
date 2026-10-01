using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;
using System.Text;
using System.IO;

public partial class User_Rights_Details : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();

    User_Rights_Details_cs UR = new User_Rights_Details_cs();
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
   
    public int i;

    public string COMPANY_LICENSE, COMPANY_ID;
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
            COMPANY_LICENSE = Session["COMP_LICENSE_NO"].ToString();
            COMPANY_ID = Session["COMP_ID"].ToString();
             if (Session["COMP_LICENSE_NO"]!=null || Session["COMP_ID"]!=null)
             {
                 if (Session["ADMIN_USER_CREATION_ID"] != null || Session["ADMIN_USER_CREATION_ID"] != null)
                 {
                     USER_CREATION_ID = Session["ADMIN_USER_CREATION_ID"].ToString();
                 }
             }
        }
        if (!IsPostBack)
        {
            Load_Emp_Id();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }
    }
    public void Load_Emp_Id()
    {
        try
        {
            ObjUBO.A1 = COMPANY_LICENSE;
            ObjUBO.A2 = COMPANY_ID;
            ObjUBO.A40 = "Emp_ID_Select";
            ds = UR.User_Rights_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Emp_Id.DataSource = ds.Tables[0];
                ddl_Emp_Id.DataTextField = "USERID";
                ddl_Emp_Id.DataValueField = "USERID";
                ddl_Emp_Id.DataBind();
            }
            
            ddl_Emp_Id.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Emp_Id.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ddl_Emp_Id_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Emp_Id.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A1 = COMPANY_LICENSE;
            ObjUBO.A2 = COMPANY_ID;
            ObjUBO.A3 = ddl_Emp_Id.SelectedValue.ToString();
            ObjUBO.A40 = "Emp_Data_Select";
            ds = UR.User_Rights_Select(ObjUBO);
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
        else
        {
            Alert_msg("Select Ur Emp Id !", "ddl_Emp_Id");
        }
    }
    
    private string User_details()
    {
        string[] ar = new string[] { };

        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("EMP_CHECK", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("U_ID", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("USER_ROLE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("EMPID", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("MENU_STATUS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("MENU_ID", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("MENU_NAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ACTIVEON", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("INACTIVEON", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("REMARKS", typeof(String)));

        int R = 0;
        foreach (GridViewRow row in gvdetails.Rows)
        {
            CheckBox EMP_CHECK = (CheckBox)row.FindControl("chk_inv");
            TextBox txt_Active_On = (TextBox)row.FindControl("txt_Active_On");
            TextBox txt_In_Active_On = (TextBox)row.FindControl("txt_In_Active_On");
            TextBox txt_Remarks = (TextBox)row.FindControl("txt_Remarks");

            dr = dtt.NewRow();
            dr[0] = EMP_CHECK.Checked == true ? "True" : "False"; 
            dr[1] = gvdetails.Rows[R].Cells[8].Text.Replace("&nbsp;", "");
            dr[2] = gvdetails.Rows[R].Cells[2].Text.Replace("&nbsp;", "");
            dr[3] = gvdetails.Rows[R].Cells[3].Text.Replace("&nbsp;", "");
            dr[4] = gvdetails.Rows[R].Cells[1].Text.Replace("&nbsp;", "");
            dr[5] = gvdetails.Rows[R].Cells[9].Text.Replace("&nbsp;", "");
            dr[6] = gvdetails.Rows[R].Cells[4].Text.Replace("&nbsp;", "");

            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (txt_Active_On.Text != string.Empty && txt_Active_On.Text != null)
            {
                arr = txt_Active_On.Text.Split('/');
                dr[7] = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            else
            {
                dr[7] = txt_Active_On.Text;
            }
            if (txt_In_Active_On.Text != string.Empty && txt_In_Active_On.Text != null)
            {
                arr2 = txt_In_Active_On.Text.Split('/');
                dr[8] = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }
            else
            {
                dr[8] = txt_In_Active_On.Text;
            }
            dr[9] = txt_Remarks.Text;

            dtt.Rows.Add(dr);
             R = R + 1;
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
            try
            {
                if (ddl_Emp_Id.SelectedValue.ToString() != string.Empty)
                {
                    ObjUBO.A2 = COMPANY_LICENSE;
                    ObjUBO.A3 = COMPANY_ID;
                    ObjUBO.A4 = ddl_Emp_Id.SelectedValue.ToString();
                    ObjUBO.A10 = User_details();
                    ObjUBO.A20 = "S";
                    ds = UR.User_Rights_Insert_Update(ObjUBO);
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
                else
                {
                    Alert_msg("select Ur Employee Id !", "ddl_Emp_Id");
                
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'User Rights', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'User Rights', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btn_New_Click(object sender, EventArgs e)
    {
        btn_Save.Visible = true;
        btn_Update.Visible = false;
        btn_Delete.Visible = false;
        ViewState["UPDATED_ID"] = null;
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {

    }
    protected void gvdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdetails.PageIndex = e.NewPageIndex;
        gvdetails.DataBind();
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
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DataBinder.Eval(e.Row.DataItem, "MENU_STATUS").ToString() == "Active")
            {
                e.Row.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
   
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["CHA_LICENSE_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

        if (ViewState["CHA_LICENSE_ID"] != "" && ViewState["CHA_LICENSE_ID"] != null)
        {
            HiddenField1.Value = ViewState["CHA_LICENSE_ID"].ToString();
            string branch = gvdetails.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            
            btn_Update.CssClass = "updates";

            btn_Save.Visible = false;
            btn_Update.Visible = true;
            btn_Delete.Visible = true;
            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["CHA_LICENSE_ID"].ToString();
            //FOR UPDATED SUCCESSFULLY
        }
        else
        {
            btn_Update.Visible = false;
            btn_Delete.Visible = false;
            btn_Save.Visible = true;
        }
    }
    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
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