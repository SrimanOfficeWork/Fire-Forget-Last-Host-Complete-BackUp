using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Import_MasterPage_EXP_Pl_Report_1 : ThemeClass
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

                Hd_Job_Type.Value = SELECT_BRANCH;
                txtbranch.Text = currentbranch;
                txtbranch.Attributes.Add("readonly", "readonly");
            }
            else
            {
                SELECT_BRANCH = "";
                Hd_Job_Type.Value = "";

            }
        }
        else
        {
            SELECT_BRANCH = "";
            Hd_Job_Type.Value = "";
        }
        if (!IsPostBack)
        {
           // btnSearch_Click(sender, e);
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gridBind();
    }

    private void gridBind()
    {
        EXP_PL_Report_1 pl = new EXP_PL_Report_1();

        pl.From_date = txtJobDate.Text;
        pl.To_date = txttodate.Text;
        pl.Imp_name = txtExpname.Text;
        pl.Branch = txtbranch.Text;
        pl.BRANCH_COMMON = SELECT_BRANCH;
        pl.PL_or_PL1 = "EX_PL1";
        DataSet ds = pl.EXP_Pl_Rpt1_Data();

        gvdetails.DataSource = ds;
        gvdetails.DataBind();

        gvdetails.Attributes.Add("style", "table-layout:fixed");

    }
}