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

public partial class Users_Joblock_new : ThemeClass
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
    public int i;


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();

        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        Company_ID = Session["COMPANY_ID"].ToString();


        string theme = (Session["Theme"] != null && Session["Theme"].ToString() != "")
                        ? Session["Theme"].ToString()
                        : "Orange";                        

        string themeClass = "theme-" + theme.ToLower();   
        BodyTag.Attributes["class"] = "uir-body " + themeClass;



        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!IsPostBack)
        {
            Bind_dd_JOB_TYPE();
            ddlBind();
            Bind_Branches();
        }
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
        gridBind();

        if (gv_details.Rows.Count > 0)
        {
            btnInvJobRelease.Visible = true;
        }
        else
        {
            btnInvJobRelease.Visible = false;

            string inv = txtInvoiceNumber.Text.Trim().Replace("'", "\\'");
            string msg = inv == ""
                ? "No pending jobs found for the selected filters."
                : "Invoice No \\'" + inv + "\\' is not used in any Job No.";

            ScriptManager.RegisterStartupScript(this, GetType(), "noInv",
                "if (typeof jAlert === 'function') { jAlert('" + msg + "', 'User Invoice Release'); } " +
                "else { alert('" + msg + "'); }", true);
        }
    }


    private void gridBind()
    {
        Joblock JL = new Joblock();
        JL.Jobtype = ddlJobType.SelectedItem.Text;
        JL.Select_Branch = ddlBranch.SelectedItem.Text;
        JL.UserName = ddlUserName.SelectedItem.Text;
        JL.Commorn_or_Branchwise = SELECT_BRANCH;
        JL.Select_or_Update = "Select";
        JL.Invoice_No = txtInvoiceNumber.Text.Trim();
        JL.Working_Period = SELECT_BRANCH;
        ds = JL.Invoice_Job_Rel();

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            i = JL.result;
            if (i == 1)
            {
                HD_imp_exp.Value = "Import";
            }
            else if (i == 2)
            {
                HD_imp_exp.Value = "Export";
            }
        }

        gv_details.DataSource = ds;
        gv_details.DataBind();
    }


    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header | e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Controls[1].Visible = false;
        }

    }


    private void Update_data()
    {
        Joblock JL = new Joblock();
        JL.Jobtype = ddlJobType.SelectedItem.Text;
        JL.Select_Branch = ddlBranch.SelectedItem.Text;
        JL.UserName = jobid.TrimEnd(',');           
        JL.Commorn_or_Branchwise = SELECT_BRANCH;        
        JL.Invoice_No = txtInvoiceNumber.Text.Trim();  
        JL.Released_By = Session["currentuser"].ToString(); 
        JL.Select_or_Update = "Update";

        JL.Invoice_Job_Rel();

        gridBind();   

        ScriptManager.RegisterStartupScript(this, GetType(), "relOk",
            "if (typeof jAlert === 'function') { jAlert('Invoice Job Released Successfully', 'User Invoice Release'); } " +
            "else { alert('Invoice Job Released Successfully'); }", true);
    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }



    protected void btn_Invoice_JobRelease_Click(object sender, EventArgs e)
    {
        if (gv_details.Rows.Count > 0)
        {
            GetData();
        }
    }

    private void GetData()
    {
        jobid = "";    

        CheckBox chkAll = (CheckBox)gv_details.HeaderRow.Cells[0].FindControl("chkAll");
        for (int i = 0; i < gv_details.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gv_details.Rows[i].Cells[0].FindControl("chk");
            if (chkAll.Checked || (chk != null && chk.Checked))
            {
             
                jobid += gv_details.DataKeys[i]["JOBID"].ToString() + ",";
            }
        }

        if (jobid != null && jobid != "")
        {
            Update_data();
        }
        else
        {
            Alert_msg("Select your Release Job");
        }
    }


    private void Show_Popup(string title, string htmlMsg)
    {
        string t = (title ?? "").Replace("\\", "\\\\").Replace("'", "\\'");
        string m = (htmlMsg ?? "").Replace("\\", "\\\\").Replace("'", "\\'")
                                  .Replace("\r", "").Replace("\n", "");

        string js = "Show_Popup_JS('" + t + "', '" + m + "');";

        ScriptManager.RegisterStartupScript(this, GetType(),
            "cstmPop_" + Guid.NewGuid().ToString("N"), js, true);
    }







}











