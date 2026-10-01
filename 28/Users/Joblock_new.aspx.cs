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

public partial class Users_Joblock_new :ThemeClass
{
    DataSet ds = new DataSet();
    Internal_Mail mail = new Internal_Mail();
    DailyStatusRpt DSR1 = new DailyStatusRpt();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string Company_ID;

    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();

    public string jobid;
    public int n;


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        //comp_ConnectionStr = Session["currentcomp_db"].ToString();

        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        Company_ID = Session["COMPANY_ID"].ToString();



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

        if (!IsPostBack)
        {
            Bind_dd_JOB_TYPE();
            ddlBind();
            Bind_Branches();

        }

        btnLock.Visible = false;
        btnUnlock.Visible = false;

        //lbljobchoose.Text = string.Empty;
    }

    public void ddlBind()
    {
        mail.flag = "BIND_USERNAME";
        mail.FROM_DATE = "";
        mail.TO_DATE = "";
        ddlUserName.Items.Clear();
        ddlUserName.DataSource = mail.GetMail();
        ddlUserName.DataTextField = "USER_NAME";
        ddlUserName.DataValueField = "USER_NAME";
        ddlUserName.DataBind();
        ddlUserName.Items.Insert(0, "");
    }
    public void Bind_dd_JOB_TYPE()
    {
        ddlJobType.Items.Clear();
        if (Session["JOB_TYPE"].ToString() == "Both")
        {
            ddlJobType.Items.Add("Import");
            ddlJobType.Items.Add("Export");


        }
        if (Session["JOB_TYPE"].ToString() == "Import")
        {
            ddlJobType.Items.Add(Session["JOB_TYPE"].ToString());

        }
        if (Session["JOB_TYPE"].ToString() == "Export")
        {
            ddlJobType.Items.Add(Session["JOB_TYPE"].ToString());

        }
    }

    public void Bind_Branches()
    {

        string id = Company_ID;
        DSR1.companyId = id;
        DSR1.Ename = "Bind_Branches";
        ds = DSR1.DS_Report();
        ddlBranch.DataSource = ds.Tables[0];
        ddlBranch.DataTextField = "BRANCH";
        ddlBranch.DataValueField = "BRANCH";
        ddlBranch.DataBind();
        ddlBranch.Items.Remove("0");
        ddlBranch.Items.Insert(0, "");
    }
    protected void gv_details_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlUserName.SelectedItem.Text != string.Empty)
        {

            gridBind();

            if (gv_details.Rows.Count > 0)
            {
                joblockoption.Visible = true;

                if (ddlneedjob.SelectedItem.Text == "Lock")
                {
                    btnUnlock.Visible = true;
                    btnLock.Visible = false;
                }
                else if (ddlneedjob.SelectedItem.Text == "UnLock")
                {
                    btnLock.Visible = true;
                    btnUnlock.Visible = false;
                }
            }
            else
            {
                joblockoption.Visible = false;
            }


            //lbljobchoose.Text = gv_details.Rows.Count > 0 ? ddlneedjob.SelectedItem.Text + " Jobs" : ddlneedjob.SelectedItem.Text + " Job";
        }
        else
        {
            Alert_msg("Select the User Name");
        }
    }

    private void gridBind()
    {

        Joblock JL = new Joblock();
        JL.Jobtype = ddlJobType.SelectedItem.Text;
        JL.Select_Branch = ddlBranch.SelectedItem.Text;
        JL.UserName = ddlUserName.SelectedItem.Text;

        JL.Needjob = ddlneedjob.SelectedItem.Text;
        JL.Commorn_or_Branchwise = SELECT_BRANCH;
        //JL.Commorn_or_Branchwise="ACC, Chennai";

        JL.Select_or_Update = "Select";
        ds = JL.Joblock_data();
        n = ds.Tables[0].Rows.Count;
        gv_details.DataSource = ds;
        gv_details.DataBind();
    }
    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header | e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Controls[1].Visible = false;// column 2
        }

    }
    protected void btnLock_Click(object sender, EventArgs e)
    {
        if (gv_details.Rows.Count > 0)
        {
            GetData();
            if (gv_details.Rows.Count > 0)
            {
                btnLock.Visible = true;
            }
        }
    }
    protected void btnUnlock_Click(object sender, EventArgs e)
    {
        if (gv_details.Rows.Count > 0)
        {
            GetData();

            if (gv_details.Rows.Count > 0)
            {
                btnUnlock.Visible = true;
            }

        }
    }
    private void GetData()
    {

        CheckBox chkAll = (CheckBox)gv_details.HeaderRow.Cells[0].FindControl("chkAll");

        for (int i = 0; i < gv_details.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                jobid += gv_details.Rows[i].Cells[1].Text + ",";
            }
            else
            {
                CheckBox chk = (CheckBox)gv_details.Rows[i].Cells[0].FindControl("chk");

                if (chk.Checked)
                {
                    jobid += gv_details.Rows[i].Cells[1].Text + ",";
                }
            }
        }
        Update_data();
    }


    private void Update_data()
    {
        Joblock JL = new Joblock();
        JL.Jobtype = ddlJobType.SelectedItem.Text;
        JL.Select_Branch = ddlBranch.SelectedItem.Text;
        JL.UserName = ddlUserName.SelectedItem.Text;

        JL.Needjob = ddlneedjob.SelectedItem.Text;
        JL.Commorn_or_Branchwise = jobid.TrimEnd(',');
        JL.Select_or_Update = "Update";

        JL.Joblock_data();
        gridBind();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


 
}