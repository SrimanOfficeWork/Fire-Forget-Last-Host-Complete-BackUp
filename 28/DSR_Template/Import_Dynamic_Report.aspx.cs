using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Import_MasterPage_Import_Dynamic_Report : ThemeClass
{
    
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;

    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    Dynamic_Report DRT = new Dynamic_Report();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();

        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
            // commented for areawise implementation on 05-mar-2020
        /*
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
          * */
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
            iframe1.Attributes["src"] = "Import_Dynamic_Report_New.aspx?JobNo=" + ddlJobNo.SelectedItem.Text + "&Report_Name=" + ddlrptname.SelectedItem.Text + "&Report_Id=" + ddlrptname.SelectedValue.ToString() + "&From_date=" + txtFrom_Date.Text + "&To_date=" + txtTo_Date.Text + "&Orderby=" + ddlorederby.SelectedItem.Text + "&Based=" + ddlbase.SelectedItem.Text + "&Imp_name=" + HttpUtility.UrlEncode(ddlimpname.SelectedItem.Text) + "&BE_Type=" + ddlBEType.SelectedValue.ToString() +"";
        }
        else
        {
            Alert_msg("Select the Report Name", "ddlrptname");
        }
    }


    private void jobload()
    {
        CheckList chklist = new CheckList();
        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = SELECT_BRANCH;

        ddlJobNo.DataSource = chklist.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();

        ListItem li = new ListItem(string.Empty, string.Empty);
        ddlJobNo.Items.Insert(0, li);
    }

    private void load_Report_Name()
    {
        DataSet ds = new DataSet();
        DRT.TYPE = "Import";
        DRT.TR_MODE = "";
        DRT.ACTIVE = "";
        DRT.WORKING_PERIOD = SELECT_BRANCH;
        DRT.Select_Con = "Load_Report_Name";

        ds = DRT.All_Record();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlrptname.DataSource = DRT.All_Record();
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
            ddlimpname.DataSource = ds.Tables[1];
            ddlimpname.DataValueField = "Imp_name";
            ddlimpname.DataTextField = "Imp_name";
            ddlimpname.DataBind();

            ddlimpname.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlimpname.SelectedIndex = 0;
        }
        else
        {
            ddlimpname.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlimpname.SelectedIndex = 0;
        }

    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}