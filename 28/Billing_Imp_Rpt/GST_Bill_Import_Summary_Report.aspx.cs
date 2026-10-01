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
using BussinessObject;

public partial class GST_Bill_Import_Summary_Report : ThemeClass
{
  
    DataSet ds1 = new DataSet();
    eroyalmaster erm = new eroyalmaster();
   
    AppSession aps = new AppSession();
    adminmaster adm = new adminmaster();
    licensereport lic = new licensereport();
    AdminMasterDetails admin = new AdminMasterDetails();
    Billing_UserBO objUserBO = new Billing_UserBO();
    GST_Summary_Report gst_Sumry = new GST_Summary_Report();
    
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string SELECT_TYPE, SELECT_BRANCH;

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

        currentbranch = Session["currentbranch"].ToString();
  // commented for areawise implementation on 05-mar-2020
        /*
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
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
          * */
        SELECT_BRANCH = Connection.Get_Company_Type();
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
            btnSearch_Click(sender, e);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        gridbind(pageno);
       
    }
   
    
    public void gridbind(int currentPageNumber1)
    {
       
        objUserBO.Imp_Name = txt_ImporterName.Text;
        objUserBO.from_date = txtJobDate.Text;
        objUserBO.todate = txttodate.Text;
        objUserBO.Flag = "Get_IMPORT_GST_Summary_Report";
        objUserBO.BranchCode = SELECT_BRANCH;
        hdnBranch.Value = SELECT_BRANCH;
        ds1 = gst_Sumry.RetrieveAll_GST_SummaryReport_Details(objUserBO);

        if (ds1.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds1.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            gvdetails.EmptyDataText = "No Record Found";
        }
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