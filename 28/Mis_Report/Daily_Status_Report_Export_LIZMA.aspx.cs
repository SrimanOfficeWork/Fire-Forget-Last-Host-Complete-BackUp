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

public partial class DSR : ThemeClass
{
    
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string Company_ID;
    public string LoginDate;
    
    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    DailyStatusRpt_Export DSR1 = new DailyStatusRpt_Export();
    ErrorLogs err = new ErrorLogs();

    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            currentcomp_name = Session["currentcomp_name"].ToString();
            comp_ConnectionStr = Session["currentcomp_db"].ToString();
            Company_ID = Session["COMPANY_ID"].ToString();


            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();
           
            SELECT_BRANCH = Connection.Get_Company_Type();

            if (!IsPostBack)
            {
                Bind_ClientMasterName();
                Bind_Branches();
                //Data_Bind();
                Tr_mode_load();
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



    private void Tr_mode_load()
    {
        if (SELECT_BRANCH != "")
        {
            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
            if (TRANS_MODE == "A")
            {
                ddlTransportMode.Items.Add(new ListItem("Air", "Air"));

            }
            else if (TRANS_MODE == "S")
            {
                ddlTransportMode.Items.Add(new ListItem("Sea", "Sea"));
            }
            else if (TRANS_MODE == "L")
            {
                ddlTransportMode.Items.Add(new ListItem("Land", "Land"));
            }
        }
        else
        {
            ddlTransportMode.Items.Add(new ListItem("", ""));
            ddlTransportMode.Items.Add(new ListItem("Air", "Air"));
            ddlTransportMode.Items.Add(new ListItem("Sea", "Sea"));
            ddlTransportMode.Items.Add(new ListItem("Land", "Land"));
        }
    }


    public void Bind_ClientMasterName()
    {
        DSR1.Ename = "Bind_EXP_Name";
        ds = DSR1.DS_Report();

        ddlCutomerName.DataSource = ds.Tables[0];
        ddlCutomerName.DataTextField = "EXPORTER_NAME";
        ddlCutomerName.DataValueField = "EXPORTER_NAME";
        ddlCutomerName.DataBind();
        ddlCutomerName.Items.Remove("0");
        ddlCutomerName.Items.Insert(0, "");
    }

    public void Data_Bind()
    {
        string ClientNm=string.Empty;
        ClientNm = ddlCutomerName.SelectedItem.Text;
        Session["ClientNm"] = ClientNm;

        DSR1.ClientName = ddlCutomerName.SelectedItem.Text;
        DSR1.Job_type = "Export";
        HiddenField1_Jobtype.Value = "Export";
    
        DSR1.Fromdate = txtFrom_Date.Text;
        DSR1.To_date = txtTo_Date.Text;
        DSR1.Branch = ddlSelect_Branch.SelectedItem.Text;
        DSR1.Tr_mode = ddlTransportMode.SelectedItem.Text;

        DataView dv = new DataView(DSR1.DS_Report_Stmt_Export_LIZMA());
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
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Daily Status Report', function (r) {});}});</script>";
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
            Alert_msg("Date Invalid");
        }
    }
}