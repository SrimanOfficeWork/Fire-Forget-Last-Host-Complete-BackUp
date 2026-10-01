using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Services;

public partial class Imp_Job_Clearance : ThemeClass
{

    IMP_Job_Clearance IJC = new IMP_Job_Clearance();
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    public int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
        if (!Page.IsPostBack)
        {
            T.Visible = false;

            DataTable dt = new DataTable();
            GV.DataSource = dt;
            GV.DataBind();

            if (Request.QueryString["Page"] == null)
            {
                Page_new();
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    if (Request.QueryString["Page"].ToString() == "0")
                    {
                    }
                    else
                    {
                        ddljobno.Items.Insert(0, new ListItem(Request.QueryString["Page"].ToString(), Request.QueryString["Page"].ToString()));
                        ddljobno.SelectedIndex = 0;
                        load_Updated_Grid();

                        ddlImp_name.Enabled = false;
                        ddljobno.Enabled = false;
                        btnDelete.Visible = true;
                    }
                }
            }
        }
    }

    private void load_Updated_Grid()
    { 
        DataSet dss = new DataSet();
        IJC.Jobno = ddljobno.SelectedValue.ToString();
        IJC.Flag = "Updated_Grid_Data";
        dss = IJC.IMP_Job_Clearance_select();
        if (dss.Tables[0].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = dss;
            gv_Chg_Details.DataBind();
        }
        if (dss.Tables[1].Rows.Count > 0)
        {
            ddlImp_name.Items.Insert(0, new ListItem(dss.Tables[1].Rows[0]["IMPORTER_NAME"].ToString(), dss.Tables[1].Rows[0]["IMPORTER_NAME"].ToString()));
            ddlImp_name.SelectedIndex = 0;
        }
    }

    private void load_Imp_Name()
    {
        ddlImp_name.Items.Clear();
        DataSet ds = new DataSet();
        IJC.Flag = "Select_Imp_Name";
        ds = IJC.IMP_Job_Clearance_select();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlImp_name.DataSource = ds.Tables[0];
            ddlImp_name.DataTextField = "IMP_EXP_NAME";
            ddlImp_name.DataValueField = "IMP_EXP_NAME";
            ddlImp_name.DataBind();
        }
        ddlImp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlImp_name.SelectedIndex = 0;
    }
    private void load_Jobno()
    {
        ddljobno.Items.Clear();
        DataSet ds = new DataSet();
        IJC.Imp_Name = ddlImp_name.SelectedValue.ToString();
        IJC.Flag = "Select_Clearance_Jobno";
        ds = IJC.IMP_Job_Clearance_select();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddljobno.DataSource = ds.Tables[0];
            ddljobno.DataTextField = "JOBNO";
            ddljobno.DataValueField = "JOBNO";
            ddljobno.DataBind();
        }
         ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
         ddljobno.SelectedIndex = 0;
    }
    private void Load_Grid()
    {
        DataSet dss = new DataSet();
        IJC.Flag = "CLEARNCE_HISTORY_MASTER_Select";
        dss = IJC.IMP_Job_Clearance_select();

        if (dss.Tables[0].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = dss;
            gv_Chg_Details.DataBind();
        }
    }
    protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Imp Job Clearance', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Imp Job Clearance', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void gv_Chg_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void btnsaveupdate_Click(object sender, EventArgs e)
    {
        if (gv_Chg_Details.Rows.Count > 0)
        {
            if (ddlImp_name.SelectedValue.ToString() != string.Empty && ddljobno.SelectedValue.ToString() != string.Empty)
            {
                DataTable dtt = new DataTable();
                DataRow dr;
                dtt.Columns.Add(new System.Data.DataColumn("STAGE_ID", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("DATE_INFO", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("HANDLED_BY", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("REMARKS", typeof(String)));

                foreach (GridViewRow row in gv_Chg_Details.Rows)
                {
                    Label txt_CH_ID = (Label)row.FindControl("txt_CH_ID");
                    TextBox txt_Acc_date = (TextBox)row.FindControl("txt_Acc_date");
                    TextBox txt_handled_by = (TextBox)row.FindControl("txt_handled_by");
                    TextBox txt_remarks = (TextBox)row.FindControl("txt_remarks");

                        dr = dtt.NewRow();
                        dr[0] = txt_CH_ID.Text;
                       
                        if (txt_Acc_date.Text != string.Empty)
                        {
                            dr[1] = txt_Acc_date.Text;
                        }
                        else
                        {
                            dr[1] = string.Empty;
                        }

                        dr[2] = txt_handled_by.Text;
                        dr[3] = txt_remarks.Text;
                        dtt.Rows.Add(dr);
                }

                DataSet dsData = new DataSet();
                dsData.Tables.Add(dtt);
                String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
                IJC.Jobno = ddljobno.SelectedValue.ToString();
                IJC.Imp_Name = ddlImp_name.SelectedValue.ToString();
                IJC.Xml_D = xmlData;
                IJC.Flag = "Insert_Update";
                IJC.IMP_Job_Clearance_select();
                Alert_msg("Save and Updated Successfully.");
            }
            else
            {
                Alert_msg("Select Ur Jobno");
            }
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
    protected void ddlImp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlImp_name.SelectedValue.ToString() !=string.Empty )
        {
            load_Jobno();
        }
    }
    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(Connection.COMPANYID()=="293")
        {
            if( ddlImp_name.SelectedValue.ToString() !=string.Empty && ddljobno.SelectedValue.ToString() !=string.Empty)
            {
                DataSet dss = new DataSet();
                IJC.Imp_Name = ddlImp_name.SelectedValue.ToString();
                IJC.Jobno = ddljobno.SelectedValue.ToString();
                IJC.Flag = "Load_Data_From_DSR";
                dss = IJC.IMP_Job_Clearance_select();
                if (dss.Tables[0].Rows.Count > 0)
                {
                    gv_Chg_Details.DataSource = dss;
                    gv_Chg_Details.DataBind();
                }
            }
            else
            {
               Load_Grid();
            }
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            IJC.Jobno = ddljobno.SelectedValue.ToString();
            IJC.Imp_Name = ddlImp_name.SelectedValue.ToString();
            IJC.Xml_D = "";
            IJC.Flag = "Job_Clearance_Delete";
            IJC.IMP_Job_Clearance_select();

            string prompt = "<script>$(document).ready(function(){{jAlert('Job Deleted', 'Job Clearnce', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Page_new()
    {
        DataTable dt = new DataTable();
        GV.DataSource = dt;
        GV.DataBind();
        Load_Grid();
        load_Imp_Name();

        ddlImp_name.Attributes.Remove("readonly");
        ddlImp_name.Style.Add("background-color", "white");
        ddljobno.Attributes.Remove("readonly");
        ddljobno.Style.Add("background-color", "white");

        ddlImp_name.Enabled = true;
        ddljobno.Enabled = true;
        btnDelete.Visible = false;
    }
}