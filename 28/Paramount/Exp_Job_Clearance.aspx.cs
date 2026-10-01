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

public partial class Exp_Job_Clearance : ThemeClass
{

    EXP_Job_Clearance EJC = new EXP_Job_Clearance();

    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();

    public int i;

    public string currentuser;
    public string currentbranch;

    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();


        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
        if (!Page.IsPostBack)
        {

            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//


            T.Visible = false;

            DataTable dt = new DataTable();
            GV.DataSource = dt;
            GV.DataBind();


            if (Request.QueryString["Page"] == null)
            {
                Load_Grid();
                load_Jobno();
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
                    }

                }
            }
        }
    }

    private void load_Updated_Grid()
    { 
        DataSet dss = new DataSet();
        EJC.Jobno = ddljobno.SelectedItem.Text;
        EJC.Branch_Common = SELECT_BRANCH;
        EJC.Flag="Updated_Grid_Data";
        dss = EJC.EXP_Job_Clearance_select();

        if (dss.Tables[0].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = dss;
            gv_Chg_Details.DataBind();
        }
    }

    private void load_Jobno()
    {
        DataSet ds = new DataSet();
        EJC.Flag = "Select_Jobno";
        EJC.Branch = SELECT_BRANCH;
        ds = EJC.EXP_Job_Clearance_select();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddljobno.DataSource = ds.Tables[0];
            ddljobno.DataTextField = "JOBNO";
            ddljobno.DataValueField = "JOBNO";
            ddljobno.DataBind();
            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        else
        {
            ddljobno.Items.Clear();
            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
    
    }
    private void Load_Grid()
    {
        DataSet dss = new DataSet();
        EJC.Flag="CLEARNCE_HISTORY_MASTER_Select";
        EJC.Branch = SELECT_BRANCH;

        dss = EJC.EXP_Job_Clearance_select();

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
    
    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           // e.Row.Height = 20;
        }

    }
   
  
    
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void gv_Chg_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
        
    }
    protected void gv_Chg_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    protected void btnsaveupdate_Click(object sender, EventArgs e)
    {
        if (gv_Chg_Details.Rows.Count > 0)
        {

            if (ddljobno.SelectedItem.Text != string.Empty)
            {
                DataTable dtt = new DataTable();
                DataRow dr;
                dtt.Columns.Add(new System.Data.DataColumn("STAGE_ID", typeof(String)));
                // dtt.Columns.Add(new System.Data.DataColumn("STAGE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("PARTICULAR", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("DATE_INFO", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("HANDLED_BY", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("REMARKS", typeof(String)));

                foreach (GridViewRow row in gv_Chg_Details.Rows)
                {
                    Label txt_CH_ID = (Label)row.FindControl("txt_CH_ID");
                    TextBox txt_Particular = (TextBox)row.FindControl("txt_Particular");

                    TextBox txt_Acc_date = (TextBox)row.FindControl("txt_Acc_date");
                    DropDownList ddlhrs_txt_Acc_date = (DropDownList)row.FindControl("ddlhrs_txt_Acc_date");
                    DropDownList ddlmin_txt_Acc_date = (DropDownList)row.FindControl("ddlmin_txt_Acc_date");
                    TextBox txt_handled_by = (TextBox)row.FindControl("txt_handled_by");
                    TextBox txt_remarks = (TextBox)row.FindControl("txt_remarks");

                    //if (txt_Particular.Text == string.Empty && txt_Acc_date.Text == string.Empty && txt_handled_by.Text == string.Empty && txt_remarks.Text == string.Empty)
                    //{

                    //}
                    //else
                    //{
                        dr = dtt.NewRow();

                        dr[0] = txt_CH_ID.Text;
                        dr[1] = txt_Particular.Text;
                        if (txt_Acc_date.Text != string.Empty)
                        {
                            dr[2] = txt_Acc_date.Text + ":" + ddlhrs_txt_Acc_date.SelectedValue.ToString() + ":" + ddlmin_txt_Acc_date.SelectedValue.ToString();
                        }
                        else
                        {
                            dr[2] = string.Empty;
                        }

                        dr[3] = txt_handled_by.Text;
                        dr[4] = txt_remarks.Text;
                        dtt.Rows.Add(dr);
                    //}
                }

                DataSet dsData = new DataSet();
                dsData.Tables.Add(dtt);

                String xmlData = ConvertDataTableToXML(dsData.Tables[0]);

                EJC.Jobno = ddljobno.SelectedItem.Text;
                EJC.User_id = currentuser;
                EJC.Branch = currentbranch;
                EJC.Branch_Common = SELECT_BRANCH;
                EJC.Working_period = Working_Period;
                EJC.Xml_D = xmlData;
                EJC.Flag = "Insert_Update";
                EJC.EXP_Job_Clearance_select();

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
}