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

public partial class Imp_BD_BOND_Summary_Rpt : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 25;
    

    DataTable dt;
    DataSet dtuser = new DataSet();
    DataSet ds1 = new DataSet();
    eroyalmaster erm = new eroyalmaster();
    SqlConnection con;
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
    private DataSet ds = new DataSet();
    public string SELECT_TYPE, SELECT_BRANCH;
    protected void Page_Load(object sender, EventArgs e)
    {

        txt_BondNo.Focus();
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
            // commented for areawise implementation on 05-mar-2020
        /*
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                hdnBranch.Value = SELECT_BRANCH;
            }
            else
            {
                SELECT_BRANCH = "";
                hdnBranch.Value = SELECT_BRANCH;
            }
        }
        else
        {
            SELECT_BRANCH = "";
            hdnBranch.Value = SELECT_BRANCH;
        }
      * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        hdnBranch.Value = SELECT_BRANCH;
        if (!IsPostBack)
        {
            Get_BOND_Details();
            //Load_Bond_type();
            //btnSearch_Click(sender, e);
        }
        
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gridbind();
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }

    public void Get_BOND_Details()
    {
        if (txt_BondNo.Text == "")
        {
            ddl_BondType.Items.Remove("");
            erm.LICENSE_NO = txt_BondNo.Text;
            erm.LICENSE_TYPE = "";
            erm.PORT_OF_LICENSE = "";
            erm.EWorking_Period = SELECT_BRANCH;
            erm.PARTNO = txt_Jobno.Text;
            erm.Ename = "Distinct_Bond_Details";
            ds1 = erm.RetrieveAll_IMPORT_BOND_DETAILS_SummaryReport();

            if (ds1.Tables[0].Rows.Count > 0)
            {
                ddl_BondType.DataSource = ds1.Tables[0];
                ddl_BondType.DataTextField = "BOND_TYPE";
                ddl_BondType.DataValueField = "BOND_TYPE";
                ddl_BondType.DataBind();
                ddl_BondType.Items.Insert(0, "");

            }
            else
            {
                ddl_BondLocation.Items.Insert(0, "");
            }
            if (ds1.Tables[1].Rows.Count > 0)
            {
                ddl_BondLocation.DataSource = ds1.Tables[1];
                ddl_BondLocation.DataTextField = "BOND_LOCATION";
                ddl_BondLocation.DataValueField = "BOND_LOCATION";
                ddl_BondLocation.DataBind();
                ddl_BondLocation.Items.Insert(0, "");
            }
            else
            {
                ddl_BondType.Items.Insert(0, "");
            }       
        }
    }

    public void gridbind()
    {
        if (ddl_BondType.SelectedItem.Text != null && ddl_BondType.SelectedItem.Text != "")
        {
            erm.LICENSE_NO = txt_BondNo.Text;
            erm.LICENSE_TYPE = ddl_BondType.SelectedItem.Text == null ? string.Empty : ddl_BondType.SelectedItem.Text;
            erm.PORT_OF_LICENSE = ddl_BondLocation.SelectedItem.Text == null ? string.Empty : ddl_BondLocation.SelectedItem.Text;
            //erm.SCHEME_CODE = ddl_Report_Type.SelectedItem.Text == null ? string.Empty : ddl_Report_Type.SelectedItem.Text;
            erm.PARTNO = txt_Jobno.Text;
            erm.EWorking_Period = SELECT_BRANCH;


            if (ddl_BondType.SelectedItem.Text == "PD, Provisional duty bond")
            {
                erm.Ename = "SELECT_PD_BOND_REPORT";
            }
            //else if (ddl_BondType.SelectedItem.Text == "RE, Re-export Bond" || ddl_BondType.SelectedItem.Text == "R1, Container")
            else if (ddl_BondType.SelectedItem.Text.StartsWith("R", StringComparison.OrdinalIgnoreCase))
            {
                erm.Ename = "SELECT_RE_BOND_REPORT";
            }
            else if (ddl_BondType.SelectedItem.Text == "DE, DEEC Bond" || ddl_BondType.SelectedItem.Text == "NB,  National Bond")
            {
                erm.Ename = "SELECT_DEEC_BOND_REPORT";
            }
            else if (ddl_BondType.SelectedItem.Text == "EC, EPCG Bond")
            {
                erm.Ename = "SELECT_EPCG_BOND_REPORT";
            }
            else if (ddl_BondType.SelectedItem.Text == "WH, Warehouse Bond")
            {
                erm.Ename = "SELECT_WAREHOUSE_BOND_REPORT";
            }
            else if (ddl_BondType.SelectedItem.Text == "EI, IGCR")
            {
                erm.Ename = "SELECT_EI_IGCR_BOND_REPORT";
            }
            else if (ddl_BondType.SelectedItem.Text == "EU, End use Bond")
            {
                erm.Ename = "SELECT_EU_END_USE_BOND_REPORT";
            }
            else
            {

            }
            
            if (erm.Ename != "" && erm.Ename != null)
            {
                ds1 = erm.RetrieveAll_IMPORT_BOND_DETAILS_SummaryReport();

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    //if (ddl_ReportType.SelectedValue == "PD")
                    if (ddl_BondType.SelectedItem.Text == "PD, Provisional duty bond")
                    {
                        gvdetails.Visible = true;
                        gvdetails_REBond.Visible = false;
                        gvdetails_DEEC.Visible = false;
                        gv_IGCR.Visible = false;

                        gvdetails.DataSource = ds1.Tables[0];
                        gvdetails.DataBind();
                    }
                    //else if (ddl_BondType.SelectedItem.Text == "RE, Re-export Bond" || ddl_BondType.SelectedItem.Text == "R1, Container")
                    else if (ddl_BondType.SelectedItem.Text.StartsWith("R", StringComparison.OrdinalIgnoreCase))
                    {
                        gvdetails.Visible = false;
                        gvdetails_REBond.Visible = true;
                        gvdetails_DEEC.Visible = false;
                        gv_IGCR.Visible = false;

                        gvdetails_REBond.DataSource = ds1.Tables[0];
                        gvdetails_REBond.DataBind();
                    }
                    else if (ddl_BondType.SelectedItem.Text == "DE, DEEC Bond" || ddl_BondType.SelectedItem.Text == "EC, EPCG Bond" || ddl_BondType.SelectedItem.Text == "WH, Warehouse Bond" || ddl_BondType.SelectedItem.Text == "NB,  National Bond")
                    {
                        gvdetails.Visible = false;
                        gvdetails_REBond.Visible = false;
                        gvdetails_DEEC.Visible = true;
                        gv_IGCR.Visible = false;

                        gvdetails_DEEC.DataSource = ds1.Tables[0];
                        gvdetails_DEEC.DataBind();
                    }
                    else if (ddl_BondType.SelectedItem.Text == "EI, IGCR" || ddl_BondType.SelectedItem.Text == "EU, End use Bond")
                    {
                        gvdetails.Visible = false;
                        gvdetails_REBond.Visible = false;
                        gvdetails_DEEC.Visible = false;
                        gv_IGCR.Visible = true;

                        gv_IGCR.DataSource = ds1.Tables[0];
                        gv_IGCR.DataBind();
                    }
                }
                else
                {
                    gvdetails.DataSource = dt;
                    gvdetails.DataBind();
                    gvdetails.EmptyDataText = "No Record Found";

                    gvdetails_REBond.DataSource = dt;
                    gvdetails_REBond.DataBind();
                    gvdetails_REBond.EmptyDataText = "No Record Found";

                    gvdetails_DEEC.DataSource = dt;
                    gvdetails_DEEC.DataBind();
                    gvdetails_DEEC.EmptyDataText = "No Record Found";

                    gv_IGCR.DataSource = dt;
                    gv_IGCR.DataBind();
                    gv_IGCR.EmptyDataText = "No Record Found";
                }
            }
            else
            {
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
                gvdetails.EmptyDataText = "No Record Found";

                gvdetails_REBond.DataSource = dt;
                gvdetails_REBond.DataBind();
                gvdetails_REBond.EmptyDataText = "No Record Found";

                gvdetails_DEEC.DataSource = dt;
                gvdetails_DEEC.DataBind();
                gvdetails_DEEC.EmptyDataText = "No Record Found";

                gv_IGCR.DataSource = dt;
                gv_IGCR.DataBind();
                gv_IGCR.EmptyDataText = "No Record Found";
            }
        }
        else
        {
            Alert_msg("Select Bond Type");
        }
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].CssClass = "locked";
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

    protected void gvdetails_REBond_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].CssClass = "locked";
        }
    }

    protected void gvdetails_REBond_RowCreated(object sender, GridViewRowEventArgs e)
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


    protected void gvdetails_DEEC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].CssClass = "locked";
        }
    }

    protected void gvdetails_DEEC_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void txt_BondNo_TextChanged(object sender, EventArgs e)
    {
        //Get_BOND_Details();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BOND SUMMARY REPORT', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

}