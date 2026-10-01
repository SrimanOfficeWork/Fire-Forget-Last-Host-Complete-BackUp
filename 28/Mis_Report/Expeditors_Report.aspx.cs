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
using System.Windows.Forms;
using System.Data.SqlClient.SqlGen;
using System.Net;
using System.Net.Mail;

public partial class Expeditors : ThemeClass
{
    Company_Master COMPANY = new Company_Master();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    //DataTable dt = new DataTable();
    ErrorLogs err = new ErrorLogs();
    DataTable dt = new DataTable();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string Company_ID;
    public string LoginDate;
    AppSession aps = new AppSession();
    Internal_Mail mail = new Internal_Mail();
    User_Creation USER = new User_Creation();
    //Retail_Stmts Retail1 = new Retail_Stmts();
    DailyStatusRpt DSR1 = new DailyStatusRpt();
    //SqlConnection con = new SqlConnection();
    public string getpath;
    public int ii = 1;
    public string SELECT_TYPE, SELECT_BRANCH;

    DataSet dtuser = new DataSet();

    ExpeditorsRpt EXP_Rpt = new ExpeditorsRpt();



    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Company_ID = Session["COMPANY_ID"].ToString();

        Type CLASS = typeof(Expeditors);
        Session["ClassName"] = CLASS;
        string cls = Session["ClassName"].ToString();

        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        //string Conn = "Server=server\\sqlexpress;database=ERoyalimpex_Branchwise_Job;uid=sa;pwd=sa,123;";

        //Session["db_Con"] = Conn;

        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                //ddlSelect_Branch.Text = currentbranch;
                //Bind_Branches();
                //Bind_ClientMasterName();
            }
            else
            {
                SELECT_BRANCH = "";
                if (!IsPostBack)
                {
                    Bind_ClientMasterName();
                    Bind_Branches();
                    //ddlSelect_Branch.Text = currentbranch;
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
            Bind_Branches();
            Data_Bind();

        }

    }

    public void Bind_Branches()
    {
        string id = Company_ID;

        DSR1.companyId = id;
        DSR1.Ename = "Bind_Branches";
        ds = DSR1.DS_Report();

        ddlSelect_Branch.DataSource = ds.Tables[0];
        ddlSelect_Branch.DataTextField = "BRANCH";
        ddlSelect_Branch.DataValueField = "BRANCH";
        ddlSelect_Branch.DataBind();

        if (SELECT_BRANCH == currentbranch)
        {
            ddlSelect_Branch.Text = currentbranch;

        }
        else
        {         
            ddlSelect_Branch.Items.Remove("0");
            ddlSelect_Branch.Items.Insert(0, "All");
        }    

    }

    public void Bind_ClientMasterName()
    {
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
        string ClientNm = string.Empty;
        ClientNm = ddlCutomerName.SelectedItem.Text;
        Session["ClientNm"] = ClientNm;

        EXP_Rpt.ClientName = ddlCutomerName.SelectedItem.Text;
        //EXP_Rpt.Job_type = ddlSelect_JobType.SelectedItem.Text;
        HiddenField1_Jobtype.Value = "Import";
        EXP_Rpt.Job_type = "Import";
        EXP_Rpt.Tr_mode = ddlTransportMode.SelectedItem.Text;
        EXP_Rpt.Fromdate = txtFrom_Date.Text;
        EXP_Rpt.To_date = txtTo_Date.Text;
        EXP_Rpt.Branch = ddlSelect_Branch.SelectedItem.Text;


        DataView dv = new DataView(EXP_Rpt.EXP_Report_Stmt());
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

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.GV_Details, "Select$" + e.Row.RowIndex.ToString()));
            if (e.Row.RowIndex == 0)
                e.Row.Style.Add("height", "30px");

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
        //Gridbind_INVOICE();
        //gv_Invoice.DataBind();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'MIS-3 Report', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtFrom_Date.Text != "" && txtTo_Date.Text == "" || txtFrom_Date.Text != null && txtTo_Date.Text == null)
        {
            date_check(txtFrom_Date.Text);
            //Data_Bind();
        }

        else if (txtTo_Date.Text != "" && txtFrom_Date.Text == "" || txtTo_Date.Text != null && txtFrom_Date.Text == null)
        {
            date_check(txtTo_Date.Text);
            //Data_Bind();
        }

        else if (txtFrom_Date.Text == "" && txtTo_Date.Text == "" || txtFrom_Date.Text == null && txtTo_Date.Text == null)
        {
            Data_Bind();
        }
        else if (txtFrom_Date.Text != "" && txtTo_Date.Text != "" || txtFrom_Date.Text != null && txtTo_Date.Text != null)
        {
            //date_check_2(txtFrom_Date.Text, txtTo_Date.Text);
            date_check(txtFrom_Date.Text);
            //date_check(txtTo_Date.Text);
            //Data_Bind();
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
            //Alert_msg("Valid");
            Data_Bind();
        }
        else
        {
            Alert_msg("Invalid Date Format");
        }
    }

    public void date_check_2(string val1, string val2)
    {
        string[] datee = { val1, val2 };

        var year = DateTime.Now.ToString();

        string[] y1 = year.Split('/');
        string a1 = y1[2];

        string[] y2 = a1.Split(' ');
        string a2 = y2[0];
        int y3 = Convert.ToInt32(a2);

        //int i = 1;
        //while (i<= 2)
        //{

        foreach (var xxx in datee)
        {
            string[] d1 = datee[0].Split('/');

            string p1 = d1[0];
            string p2 = d1[1];
            string p3 = d1[2];


            int dd = Convert.ToInt32(p1);
            int mm = Convert.ToInt32(p2);
            int yyyy = Convert.ToInt32(p3);

            ViewState["dd"] = dd;
            ViewState["mm"] = mm;
            ViewState["yyyy"] = yyyy;


        }

        string x = ViewState["dd"].ToString();
        string y = ViewState["mm"].ToString();
        string z = ViewState["yyyy"].ToString();

        int aa = Convert.ToInt32(x);
        int bb = Convert.ToInt32(y);
        int cc = Convert.ToInt32(z);



        if (aa <= 31 && bb <= 12 && cc <= y3)
        {
            if (txtTo_Date.Text != "" || txtTo_Date.Text != null)
            {
                Data_Bind();
            }

            //Alert_msg("Valid");
            //Data_Bind();
        }


        else
        {
            Alert_msg("Invalid Date Format");
        }
    }
}
