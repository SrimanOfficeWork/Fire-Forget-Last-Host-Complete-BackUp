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


public partial class Export_TALLY_Excel_Format_PARA : ThemeClass
{
  
    DataSet ds1 = new DataSet();
    TALLY_Billing_Others excel = new TALLY_Billing_Others(); 
    AppSession aps = new AppSession();
   
    private DataSet ds = new DataSet();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    protected void Page_Load(object sender, EventArgs e)
    {

        txt_ImporterName.Focus();
        aps.checkSession();
       
        hdnBranch.Value = Connection.Current_Branch();
       
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

        excel.JOBNO = "";
        excel.Imp_name = txt_ImporterName.Text;
        excel.Branch_Code = Connection.Current_Branch();
        excel.Fromdate = txtJobDate.Text;
        excel.Todate = txttodate.Text;
        excel.Flag = "EXPORT_TALLY_EXCEL_BIND";
        ds1 = excel.EXP_TALLY_EXCEL_REPORT();

        if (ds1.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds1.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.EmptyDataText = "No Record Found";
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }
              
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EXPORT - TALLY REPORT', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}