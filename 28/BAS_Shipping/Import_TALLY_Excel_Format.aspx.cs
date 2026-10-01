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
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Linq.Expressions;


public partial class Import_License_Summary_Report : ThemeClass
{
  
    DataSet ds1 = new DataSet();
    eroyalmaster erm = new eroyalmaster();
    TALLY_Excel excel = new TALLY_Excel();
   
    AppSession aps = new AppSession();
    adminmaster adm = new adminmaster();
    licensereport lic = new licensereport();
    AdminMasterDetails admin = new AdminMasterDetails();
    
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
   
    private DataSet ds = new DataSet();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    protected void Page_Load(object sender, EventArgs e)
    {

        txt_ImporterName.Focus();
        aps.checkSession();
       
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        hdnBranch.Value = currentbranch;
        
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txt_ImporterName.Text;
        }

        hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            //btnSearch_Click(sender, e);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        gridbind(pageno);
       
    }
   
    
    public void gridbind(int currentPageNumber1)
    {
        DataView view = new DataView();
        DataTable d = new DataTable();

        excel.Jobno = txt_ImporterName.Text;
        excel.Imp_name = "";
        excel.Branch_Code = currentbranch;
        excel.Fromdate = txtJobDate.Text;
        excel.Todate = txttodate.Text;
        excel.Flag = "IMPORT_TALLY_EXCEL_BIND";
        ds1 = excel.BAS_IMP_TALLY_EXCEL_REPORT();

        gvdetails.DataSource = ds1.Tables[0];
        gvdetails.DataBind();
              
    }

    private DataTable FilterTable(DataTable table, DateTime startDate, DateTime endDate)
    {
        var filteredRows =
            from row in table.Rows.OfType<DataRow>()
            where (DateTime)row[1] >=Convert.ToDateTime(startDate)
            where (DateTime)row[1] <= Convert.ToDateTime(endDate)
            select row;

        DataTable filteredTable = table.Clone();

        filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));

        return filteredTable;
    } 

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //var row = e.Row;
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

  
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LICENSE SUMMARY REPORT', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}