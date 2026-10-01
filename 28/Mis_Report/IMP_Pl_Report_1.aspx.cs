using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

public partial class Import_MasterPage_IMP_Pl_Report_1 : ThemeClass
{

    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;

    public string SELECT_TYPE, SELECT_BRANCH;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

       

        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                txtbranch.Text = currentbranch;
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
        if (!IsPostBack)
        {
            btnSearch_Click(sender, e);
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


    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gridBind();
    }

    private void gridBind()
    {
        Pl_Report pl = new Pl_Report();
        pl.From_date = txtJobDate.Text;
        pl.To_date = txttodate.Text;
        pl.Imp_name = txtimpname.Text;
        pl.Branch = txtbranch.Text;
        pl.BRANCH_COMMON = SELECT_BRANCH;

        DataSet ds = pl.Pl_Rpt1_Data();

        gvdetails.DataSource = ds;
        gvdetails.DataBind();

    }   
}