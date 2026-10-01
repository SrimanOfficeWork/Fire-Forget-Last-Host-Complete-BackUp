using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class EXP_Master_Search : ThemeClass
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    EXP_combined EC = new EXP_combined();

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
            Exporter_Name_Load();
            Load_Grid();
        }
    }
    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Grid();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
    }
    private void Load_Grid() 
    {
        EC.Exp_name = ddlExp_name.SelectedItem.Text;
        EC.JOBNO = txtjobno.Text;
        EC.from_date = txtfromdate.Text;
        EC.todate = txttodate.Text;
        EC.Branch = SELECT_BRANCH;

        gvdetails.DataSource = EC.EXPORT_COMBINE_JOB_SEARCH();
        gvdetails.DataBind();
    }

    private void Exporter_Name_Load()
    {
        EC.Branch = SELECT_BRANCH;
        EC.Flag = "EXP_Name_Master_Search";
        EC.Mode = "";
        ddlExp_name.DataSource = EC.Exp_Name();
        ddlExp_name.DataTextField = "EXPORTER_NAME";
        ddlExp_name.DataValueField = "EXPORTER_NAME";
        ddlExp_name.DataBind();
        ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlExp_name.SelectedIndex = 0;
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", "open_EXP_Con_Search_Update('" + values + "')");
        }
    }
}