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
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

public partial class Exp_MIS_Rpt2 : ThemeClass
{
    eroyalmaster Imp_Exp = new eroyalmaster();
    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();
    Export_MIS_2 EXP_MIS = new Export_MIS_2();
  
    DataSet ds = new DataSet();

    private string _Workingperiod;
    public string FreightCharges, FR_Currency, Ins_Charges, Ins_Currency;
    public string working_period;

    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, testaddress;
    public string SELECT_TYPE, SELECT_BRANCH;


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        // commented for areawise implementation on 05-mar-2020
        /*

        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                ddlSelect_Branch.Visible = false;
                lbl_branch.Visible = false;
            }
            else
            {
                SELECT_BRANCH = "";
                ddlSelect_Branch.Visible = true;
                lbl_branch.Visible = true;
            }
        }
        else
        {
            SELECT_BRANCH = "";
            ddlSelect_Branch.Visible = true;
            lbl_branch.Visible = true;           
        }
          * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (SELECT_BRANCH != "")
        {

            ddlSelect_Branch.Visible = false;
            lbl_branch.Visible = false;
        }
        else
        {

            ddlSelect_Branch.Visible = true;
            lbl_branch.Visible = true;
        }


        if (!IsPostBack)
        {

            Load_ExporterName();
            Load_BranchCode();
            btnexcel.Visible = false;
            btnprint.Visible = false;
            btnSend.Visible = false;
        }

      
    }

    public void Load_ExporterName()
    {
        EXP_MIS.Ename = "Bind_ExporterName";
        DataView dvv = new DataView(EXP_MIS.Export_MIS_Statement());

        ddlCutomerName.DataSource = dvv;
        ddlCutomerName.DataTextField = "EXPORTER_NAME";
        ddlCutomerName.DataValueField = "EXPORTER_NAME";
        ddlCutomerName.DataBind();
        ddlCutomerName.Items.Insert(0, "All");
    }
    public void Load_BranchCode()
    {
        EXP_MIS.Ename = "Bind_BranchCode";
        DataView d_view = new DataView(EXP_MIS.Export_MIS_Statement());

        ddlSelect_Branch.DataSource = d_view;
        ddlSelect_Branch.DataTextField = "BRANCHCODE";
        ddlSelect_Branch.DataValueField = "BRANCHCODE";
        ddlSelect_Branch.DataBind();
        ddlSelect_Branch.Items.Insert(0,"All");
    }


    public void Data_Bind()
     {

        EXP_MIS.JobNo = txtJobNo.Text;
        EXP_MIS.Exp_name = ddlCutomerName.SelectedItem.Text;
        EXP_MIS.Jobdate = txtFrom_Date.Text;
        EXP_MIS.To_date = txtTo_Date.Text;
        EXP_MIS.Ename = "Bind_Grid_Details";

        if (SELECT_BRANCH == currentbranch)
        {
            EXP_MIS.Branch = SELECT_BRANCH;
        }
        else
        {
            EXP_MIS.Branch = ddlSelect_Branch.SelectedItem.Text;
        }

        Select_BranchCode.Value = EXP_MIS.Branch;

        DataView dv = new DataView(EXP_MIS.Export_MIS_Statement());

        if(dv.Count>0)
        {
            gvdetails.DataSource = dv;
            gvdetails.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }

        btnexcel.Visible = true;
        btnprint.Visible = true;
        btnSend.Visible = true;
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

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void gvdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdetails.PageIndex = e.NewPageIndex;
        
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export MIS Report', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
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