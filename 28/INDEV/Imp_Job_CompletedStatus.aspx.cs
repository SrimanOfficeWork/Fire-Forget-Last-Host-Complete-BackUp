using System;
using System.IO;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI;


public partial class Imp_Job_CompletedStatus : ThemeClass
{

    Job_Completed_Status Iclear = new Job_Completed_Status();

    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string Working_Period;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty;
    string End_date = string.Empty;

    string From_month = string.Empty;
    string To_month = string.Empty;
   
    public string SELECT_TYPE, SELECT_BRANCH;
    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                HDBranch.Value = SELECT_BRANCH;
            }
            else
            {
                SELECT_BRANCH = "";
                HDBranch.Value="";
            }
        }
        else
        {
            SELECT_BRANCH = "";
            HDBranch.Value = "";
        }

        if (!IsPostBack)
        {
            Load_Month();
            Tr_mode_load();

            DataTable dt = new DataTable();
            gvdetails_0.DataSource = dt;
            gvdetails_0.DataBind();
        }
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void gvdetails_RowCreated_H(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
   
    protected void btnSearch1_Click(object sender, EventArgs e)
    {
        ltl.Text = ddl_ClearJobs.SelectedItem.Text + " Count : ";
        gridBind();
    }
    private void gridBind()
    {
        DataSet ds1 = new DataSet();
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            Iclear.fromdate = txtfromdate.Text;
            Iclear.To_date = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                Iclear.fromdate = arr_Month[0];
                Iclear.To_date = arr_Month[1];
            }
            else
            {
                Iclear.fromdate = txtfromdate.Text;
                Iclear.To_date = txttodate.Text;
            }
        }

        Iclear.JobNo = txtJobNo.Text;

        Iclear.Imp_name = txtimp_name.Text;
        Iclear.Tr_mode = ddltr_mode.SelectedItem.Text;
        Iclear.Branch = SELECT_BRANCH;
        Iclear.ClearType = ddl_ClearJobs.SelectedValue.ToString();
        Iclear.Flag = "General_Search";

        DataView dv = new DataView(Iclear.General_Cleared_Status_Rpt());
       

        if (dv.Count > 0)
        {
            gvdetails.DataSource = dv;
            gvdetails.DataBind();
            lbljobcnt.Text = dv.Count.ToString();

            btnSave_udpate.Visible = true;
        }
        else
        {
            Clear_GV();
            btnSave_udpate.Visible = false;
            lbljobcnt.Text = "0";
        }
    }
    private void Clear_GV()
    {
        DataTable dt = new DataTable();
        gvdetails.DataSource = dt;
        gvdetails.DataBind();
    }
    private void Load_Month()
    {

        Billing_Imp_Invoice BI = new Billing_Imp_Invoice();
        DataSet ds = new DataSet();
        arr = Working_Period.Split('-');
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        BI.from_date = Start_date;
        BI.todate = End_date;
        BI.Flag = "Month";

        ds = BI.IMP_EXP_Month();

        ddlmonth.DataSource = ds.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();

        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
        ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    }
    private void Tr_mode_load()
    {
        if (SELECT_BRANCH != "")
        {
            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();

            if (TRANS_MODE == "A")
            {
                ddltr_mode.Items.Add(new ListItem("Air", "Air"));
            }
            else if (TRANS_MODE == "S")
            {
                ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
            }
            else if (TRANS_MODE == "L")
            {
                ddltr_mode.Items.Add(new ListItem("Land", "Land"));
            }
        }
        else
        {
            ddltr_mode.Items.Add(new ListItem("Air", "Air"));
            ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
            ddltr_mode.Items.Add(new ListItem("Land", "Land"));
        }
    }
    protected void btnSave_udpate_Click(object sender, EventArgs e)
    {
        string Yes_No = string.Empty;

        for (int i = 0; i < gvdetails.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");

            if (chk.Checked)
            {
                TextBox txt_ClearDate = (TextBox)gvdetails.Rows[i].Cells[1].FindControl("txt_clearDate");
                TextBox txt_Doc_Rec_Dt = (TextBox)gvdetails.Rows[i].Cells[2].FindControl("txt_Doc_Rec_Date");
                TextBox txt_Agent_Name = (TextBox)gvdetails.Rows[i].Cells[3].FindControl("txt_Agent_Name");
                TextBox txt_Remarks = (TextBox)gvdetails.Rows[i].Cells[4].FindControl("txt_Remarks");

                Iclear.JobNo = (string)this.gvdetails.DataKeys[i]["JOBNO"].ToString();
                Iclear.fromdate = txt_ClearDate.Text;
                Iclear.Doc_Rec_Date = txt_Doc_Rec_Dt.Text;
                Iclear.Agent_Name = txt_Agent_Name.Text;
                Iclear.Remarks = txt_Remarks.Text;
                Iclear.Branch = SELECT_BRANCH;

                Iclear.Flag = "Update_General_ClearedDate";
                Iclear.General_Cleared_Status_Rpt();
                Yes_No = "Yes";
            }
        }
        if (Yes_No == "Yes")
        {
            gridBind();
            Alert_msg("Save & Updated Successfully");
        }
        else
        {
            Alert_msg("Select Ur Job(s)");
        }
        
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import Job Complete', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}