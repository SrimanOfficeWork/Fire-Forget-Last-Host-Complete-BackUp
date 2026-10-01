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

public partial class Imp_Sims_Rpt : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 25;
    SqlCommand com, cmd, cmd1;
    SqlDataReader dr, dr1;

    //SqlDataAdapter da;
    DataTable dt;
    //DataRow de;
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
    const int pageSize = 10;
    const int pageDispCount = 10;
    //private DataTable dt = new DataTable();
    private DataSet ds = new DataSet();
    public string SELECT_TYPE, SELECT_BRANCH;
    protected void Page_Load(object sender, EventArgs e)
    {
           
        aps.checkSession();        
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();       
        SELECT_BRANCH = Connection.Get_Company_Type();
        hdnBranch.Value = SELECT_BRANCH;
       
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        erm.STLNO = txtStl_No.Text;
        erm.FRMDATE = txtFrmdate.Text;
        erm.TODATE = txtTodate.Text ;
        erm.REGNDATE = txtRegndate.Text ;
        erm.EWorking_Period = SELECT_BRANCH;
        erm.JOBNO = txtJobno.Text;
        erm.Ename = "SELECT_SIMS_RPT";
        ds1 = erm.Retrive_Import_Sims();

        if (ds1.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds1.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            gvdetails.EmptyDataText = "No Record Found";
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
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].CssClass = "locked";
        }
    }
   

    

    

   

   
}