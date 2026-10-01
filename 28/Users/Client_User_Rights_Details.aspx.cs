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

public partial class Client_User_Rights_Details : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Client_User_Rights_cs CR = new Client_User_Rights_cs();

    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
   
    public string COMPANY_LICENSE, COMPANY_ID,USER_CREATION_ID;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Pageload();
    }
    public void Pageload()
    {
        if (Session["COMPANY_ID"] != null)
        {
            COMPANY_ID = Session["COMPANY_ID"].ToString();
            if (Session["USER_CREATION_ID_EDIT"] != null)
            {
                USER_CREATION_ID = Session["USER_CREATION_ID_EDIT"].ToString();
            }
            else if (Session["USER_CREATION_ID_NEW"] != null)
            {
                USER_CREATION_ID = Session["USER_CREATION_ID_NEW"].ToString();
            }
            else
            {
                Response.Write("<script>window.open('Company_Master.aspx','_parent');</script>");
            }
        }
        else
        {
            Response.Write("<script>window.open('Company_Master.aspx','_parent');</script>");
        }
        if (!IsPostBack)
        {
            Load_Emp_Id();
            Load_Royal_Emp_Id();
        }
    }
    public void Load_Emp_Id()
    {
        try
        {
            lblEmp_Name.Text = string.Empty;
            Hdn_EMP_ID.Value = "";

            ObjUBO.A1 = COMPANY_LICENSE;
            ObjUBO.A2 = COMPANY_ID;
            ObjUBO.A3 = USER_CREATION_ID;
            ObjUBO.A40 = "Emp_ID_Select";
            ds = CR.CHA_User_Rights_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblEmp_Name.Text=ds.Tables[0].Rows[0]["USER_NAME"].ToString();
                Hdn_EMP_ID.Value = ds.Tables[0].Rows[0]["USER_CREATION_ID"].ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void Load_Royal_Emp_Id()
    {
        try
        {
            ObjUBO.A1 = COMPANY_LICENSE;
            ObjUBO.A2 = COMPANY_ID;
            ObjUBO.A3 = USER_CREATION_ID;
            ObjUBO.A4 = lblEmp_Name.Text;
            
            ObjUBO.A40 = "Client_Emp_Data_Select";
            ds = CR.Admin_User_Rights_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Emp_Id.DataSource = ds.Tables[0];
                ddl_Emp_Id.DataTextField = "EMP_ID";
                ddl_Emp_Id.DataValueField = "EMP_ID";
                ddl_Emp_Id.DataBind();

                if (ds.Tables[0].Rows.Count > 1)
                {
                    ddl_Emp_Id.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
                    ddl_Emp_Id.SelectedIndex = 0;

                    gvdetails.DataSource = dt;
                    gvdetails.DataBind();
                }
                else
                {
                    Load_Grid();
                }
            }
            else
            {
                ddl_Emp_Id.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
                ddl_Emp_Id.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ddl_Emp_Id_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Grid();
    }
    private void Load_Grid()
    {
        try
        {
            if (ddl_Emp_Id.SelectedValue.ToString() != string.Empty)
            {
                ObjUBO.A1 = COMPANY_LICENSE;
                ObjUBO.A2 = COMPANY_ID;
                ObjUBO.A3 = ddl_Emp_Id.SelectedValue.ToString();
                ObjUBO.A40 = "Royal_Emp_Data_Select";
                ds = CR.Admin_User_Rights_Select(ObjUBO);
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private string User_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("CLIENT_CHECK", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("U_ID", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("MENU_ID", typeof(String)));

        int R = 0;
        foreach (GridViewRow row in gvdetails.Rows)
        {
            CheckBox CLIENT_CHECK = (CheckBox)row.FindControl("chk_inv");

            dr = dtt.NewRow();
            dr[0] = CLIENT_CHECK.Checked == true ? "True" : "False"; 
            dr[1] = gvdetails.Rows[R].Cells[5].Text.Replace("&nbsp;", "");
            dr[2] = gvdetails.Rows[R].Cells[6].Text.Replace("&nbsp;", "");
            dtt.Rows.Add(dr);
             R = R + 1;
        }
        String xmlData = ConvertDataTableToXML(dtt);
        return xmlData;
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
            try
            {
                if (ddl_Emp_Id.SelectedValue.ToString() != string.Empty)
                {
                    ObjUBO.A1 = Hdn_EMP_ID.Value.ToString();
                    ObjUBO.A2 = ddl_Emp_Id.SelectedValue.ToString();

                    ObjUBO.A5 = User_details();
                    ObjUBO.A10 = "S";
                    ds = CR.User_Rights_Insert_Update(ObjUBO);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvdetails.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        gvdetails.DataSource = dt;
                    }
                    gvdetails.DataBind();

                    Alert_msg("Saved !");
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
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
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