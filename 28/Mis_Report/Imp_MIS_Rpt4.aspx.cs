using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Mis_Report_Imp_MIS_Rpt4 :ThemeClass
{

    ErrorLogs err = new ErrorLogs();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string Company_ID;
    public string LoginDate;
    AppSession aps = new AppSession();

    public string getpath;
    public int ii = 1;
    public string SELECT_TYPE, SELECT_BRANCH;


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Company_ID = Session["COMPANY_ID"].ToString();

        Type CLASS = typeof(Mis_Report_Imp_MIS_Rpt4);
        Session["ClassName"] = CLASS;
        string cls = Session["ClassName"].ToString();

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
                if (!IsPostBack)
                {
                    Bind_ClientMasterName();
                }
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }

        if (!IsPostBack)
        {
            Bind_ClientMasterName();
            Data_Bind();
        }
    }

    public void Bind_ClientMasterName()
    {
        DataSet ds = new DataSet();
        DailyStatusRpt DSR1 = new DailyStatusRpt();
        DSR1.Ename = "Bind_IMP_EXP_Name";
        ds = DSR1.DS_Report();

        ddlCutomerName.DataSource = ds.Tables[0];
        ddlCutomerName.DataTextField = "IMP_EXP_NAME";
        ddlCutomerName.DataValueField = "IMP_EXP_NAME";
        ddlCutomerName.DataBind();
        ddlCutomerName.Items.Remove("0");
        ddlCutomerName.Items.Insert(0, "All");

    }

    public void Data_Bind()
    {
        ExpeditorsRpt EXP_Rpt = new ExpeditorsRpt();
        string ClientNm = string.Empty;
        ClientNm = ddlCutomerName.SelectedItem.Text;
        Session["ClientNm"] = ClientNm;

        EXP_Rpt.ClientName = ddlCutomerName.SelectedItem.Text;
       
        EXP_Rpt.Job_type = "Import";
        HiddenField1_JobType.Value = "Import";
        EXP_Rpt.Tr_mode = ddlTransportMode.SelectedItem.Text;
        EXP_Rpt.Fromdate = txtFrom_Date.Text;
        EXP_Rpt.To_date = txtTo_Date.Text;
        EXP_Rpt.Branch = SELECT_BRANCH;
        HiddenField1_BRANCH.Value = SELECT_BRANCH;


        DataView dv = new DataView(EXP_Rpt.MIS_4_Report_Stmt());
        GV_Details.DataSource = dv;
        GV_Details.DataBind();

        if (dv.Count == 0)
        {
            Alert_msg("No Records");
        }

    }

    protected void GV_Details_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Left;

        }

    }

    protected void GV_Details_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void GV_Details_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Details.PageIndex = e.NewPageIndex;

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'MIS-4 Report', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtFrom_Date.Text != "" && txtTo_Date.Text == "" || txtFrom_Date.Text != null && txtTo_Date.Text == null)
        {
            date_check(txtFrom_Date.Text);
        }

        else if (txtTo_Date.Text != "" && txtFrom_Date.Text == "" || txtTo_Date.Text != null && txtFrom_Date.Text == null)
        {
            date_check(txtTo_Date.Text);
        }

        else if (txtFrom_Date.Text == "" && txtTo_Date.Text == "" || txtFrom_Date.Text == null && txtTo_Date.Text == null)
        {
            Data_Bind();
        }
        else if (txtFrom_Date.Text != "" && txtTo_Date.Text != "" || txtFrom_Date.Text != null && txtTo_Date.Text != null)
        {
            date_check(txtFrom_Date.Text);
        }
    }

    protected void ddlCutomerName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Data_Bind();
    }

    public void date_check(string val)
    {
        var datee = val;
        var year = DateTime.Now.ToString();

        string[] y1 = year.Split('/');
        string a1 = y1[2];

        string[] y2 = a1.Split(' ');
        string a2 = y2[0];
        int y3 = Convert.ToInt32(a2);

        string[] d1 = datee.Split('/');

        string p1 = d1[0];
        string p2 = d1[1];
        string p3 = d1[2];

        int dd = Convert.ToInt32(p1);
        int mm = Convert.ToInt32(p2);
        int yyyy = Convert.ToInt32(p3);

        if (dd <= 31 && mm <= 12 && yyyy <= y3)
        {
            Data_Bind();
        }
        else
        {
            Alert_msg("Invalid Date Format");
        }
    }

   
}