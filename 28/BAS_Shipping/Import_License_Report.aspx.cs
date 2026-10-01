using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;

public partial class Import_License_Report : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 25;
    SqlCommand com, cmd, cmd1;
    SqlDataReader dr, dr1;

    SqlDataAdapter da;
    DataTable dt;
    DataRow de;
    DataSet dtuser = new DataSet();
    DataSet ds1 = new DataSet();
    eroyalmaster erm = new eroyalmaster();
    SqlConnection con;
    Manipulation mo;
    AppSession aps = new AppSession();
    adminmaster adm = new adminmaster();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    int _startIndex = 0;
    int _thisPage = 1;
    int _pageSize = 10;
    int _totalNumberOfRows = 0;
    int[] f = new int[100];
    int[] l = new int[100];
    public string str, title, state, magimage, pagestr, startpage, comments, mm, lastpost, selqry;
    int i, j, ii, k, page, pageno, start, first, last, m, n, fir, la, kk, mmm, z, a, b, c, res;
    const int pageSize = 10;
    const int pageDispCount = 10;
    //private DataTable dt = new DataTable();
    private DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {

        txtLicense_No.Focus();
        aps.checkSession();
        // if (!Page.IsPostBack)
        //{
        //Response.AppendHeader("Refresh", ((Session.Timeout * 3) + 3).ToString() + "; Url=../LoginPage/Default.aspx?from=expired");

        // }
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);


        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
        //Div_Pagination.Visible = false;
        //div_pagination1.Visible = false;

        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txtLicense_No.Text;
        }

        hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {        
            btnSearch_Click(sender, e);              
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        if (txtLicense_No.Text != "")
        {
            gridbind(pageno);
        }
        else
        {
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtLicense_No.Text = "";
      
        Name_Search = "";
        btnSearch_Click(sender, e);
    }
    
    public void gridbind(int currentPageNumber1)
    {

        erm.LICENSE_NO = txtLicense_No.Text;
        erm.LICENSE_DATE = "";
        erm.PORT_OF_LICENSE = "";
        erm.EWorking_Period = Connection.Get_Company_Type();
        erm.Ename = "select_License_Details";
        ds1 = erm.RetrieveAll_IMPORT_LICENSE_DEBIT_AMT_REPORT();

        if (ds1.Tables[1].Rows.Count > 0)
        {      
            gvdetails.DataSource = ds1.Tables[1];
            gvdetails.DataBind();
        }
        else
        {
            gvdetails.EmptyDataText = "No Record Found";
        }
        if (ds1.Tables[3].Rows.Count > 0)
        {
            lbl_tot_Dbt_Amt.Text = ds1.Tables[3].Rows[0]["TOTAL_DEBIT_AMT"].ToString();
        }
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
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
}