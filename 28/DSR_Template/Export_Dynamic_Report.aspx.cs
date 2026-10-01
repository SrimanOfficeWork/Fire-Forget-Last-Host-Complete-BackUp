using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using GeneraReport;
using Microsoft.Reporting.WebForms;

public partial class Import_MasterPage_Export_Dynamic_Report : ThemeClass
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;

    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    Exp_Dynamic_Report DRT = new Exp_Dynamic_Report();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();

        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
      
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!IsPostBack)
        {
            jobload();
            load_Report_Name();
        }

        iframe1.Visible = false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlrptname.SelectedItem.Text != string.Empty)
        {
            iframe1.Visible = true;
            iframe1.Attributes["src"] = "Export_Dynamic_Report_New.aspx?JobNo=" + ddlJobNo.SelectedItem.Text + "&Report_Name=" + ddlrptname.SelectedItem.Text + "&Report_Id=" + ddlrptname.SelectedValue.ToString() + "&From_date=" + txtFrom_Date.Text + "&To_date=" + txtTo_Date.Text + "&Orderby=" + ddlorederby.SelectedItem.Text + "&Based=" + ddlbase.SelectedItem.Text + "&Exp_name=" + Server.UrlEncode(Server.HtmlEncode(ddlexpname.SelectedItem.Text)) + "";
        }
        else
        {
            Alert_msg("Select the Report Name", "ddlrptname");
        }
    }

    private void jobload()
    {
        Export_CheckList chklist = new Export_CheckList();
        Working_Period = Session["WorkingPeriod"].ToString();

        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = SELECT_BRANCH;

        ddlJobNo.DataSource = chklist.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();

        ListItem li = new ListItem(" ", "0");
        ddlJobNo.Items.Insert(0, li);

    }

    private void load_Report_Name()
    {
        DataSet ds = new DataSet();

        DRT.TYPE = "Export";
        DRT.TR_MODE = "";
        DRT.ACTIVE = "";
        DRT.WORKING_PERIOD = SELECT_BRANCH;
        DRT.Select_Con = "Load_Report_Name";

        ds = DRT.All_Record();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlrptname.DataSource = ds.Tables[0];
            ddlrptname.DataValueField = "T_ID";
            ddlrptname.DataTextField = "TEMPLATE_NAME";
            ddlrptname.DataBind();

            ddlrptname.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlrptname.SelectedIndex = 0;
        }
        else
        {
            ddlrptname.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlrptname.SelectedIndex = 0;
        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            ddlexpname.DataSource = ds.Tables[1];
            ddlexpname.DataValueField = "Exp_name";
            ddlexpname.DataTextField = "Exp_name";
            ddlexpname.DataBind();

            ddlexpname.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlexpname.SelectedIndex = 0;
        }
        else
        {
            ddlexpname.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlexpname.SelectedIndex = 0;
        }
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

}
