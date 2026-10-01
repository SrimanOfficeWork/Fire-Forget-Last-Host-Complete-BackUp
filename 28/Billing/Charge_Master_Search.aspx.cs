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


public partial class Billing_Charge_Master_Search : ThemeClass
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
    eroyalmaster erm = new eroyalmaster();
    Charge_Master charge = new Charge_Master();
    DataSet ds = new DataSet();
    SqlConnection con;
    Manipulation mo;
    AppSession aps = new AppSession();
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

        Div_Pagination.Visible = false;
        div_pagination1.Visible = false;

        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txtCharge_name.Text;
        }

        hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            btnSearch_Click(sender, e);
        }

        txtCharge_name.Attributes.Add("onblur", "javascript:CallServerside_BL_Exp_Name('" + txtCharge_name.ClientID + "')");
        txtCharge_Code.Attributes.Add("onblur", "javascript:CallServerside_BL_ChargeCode('" + txtCharge_Code.ClientID + "')");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);


    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtCharge_Code.Text = "";
        txtCharge_name.Text = "";
        Name_Search = "";
        btnSearch_Click(sender, e);
    }

    public void gridbind(int currentPageNumber1)
    {
        Session["title"] = null;
        charge.CHARGE_ID = "0";
        charge.CHARGE_NAME = Name_Search;
        charge.CHARGE_CODE = txtCharge_Code.Text;
        charge.Ename = "select_con";
        charge.WORKING_PERIOD = Session["WorkingPeriod"].ToString();
        charge.BRANCH_COMMON = SELECT_BRANCH;

        charge.startRowIndex = Convert.ToString(currentPageNumber1);
        charge.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = charge.RetrieveAll_Charge_Master();
        gvdetails.EmptyDataText = "No Record Found";

        gvdetails.DataSource = aps.GridView_Sorting(charge.RetrieveAll_Charge_Master(), "CHARGE_NAME");
        //gvdetails.DataSource = charge.RetrieveAll_Charge_Master();            

        //------
        DataSet ds = new DataSet();
        charge.Ename = "select_con";
        ds = charge.RetrieveAll_Charge_Master();
        this.ViewState.Remove("sorttable");
        ViewState["sorttable"] = ds.Tables[0];
        //------

        gvdetails.DataBind();
        //we cannot asc sort in sqlserver because we used rowcount thats y we asc here
        Grid_Total(currentPageNumber1, charge.result);

        if (ds.Tables[0].Rows.Count > 0)
        {
            tblsort("test");
        }
    }

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);
        return totalPages;
    }

    protected void ChangePage(object sender, CommandEventArgs e)
    {
        int currentpagenumber2 = 0;
        switch (e.CommandName)
        {
            case "Previous":
                currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) - 1;

                break;

            case "Next":

                int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                if (Int32.Parse(lblCurrentPage.Text) == ii)
                    currentpagenumber2 = ii;
                else
                    currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) + 1;

                break;
            case "First":
                currentpagenumber2 = 1;

                break;
            case "Last":
                int i = CalculateTotalPages(double.Parse(lblTotalPages.Text));

                currentpagenumber2 = i;
                break;
        }

        gridbind(currentpagenumber2);
        //BindData(currentpagenumber2);
        //General_GridBind(currentpagenumber2);
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["CHARGE_ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", "opennew_chargemaster_edit('" + values + "')");

            //var des1 = row.Cells[1].Text.Replace("&amp;", "&");
            //var des3 = row.Cells[3].Text.Replace("&amp;", "&");
            //var des4 = row.Cells[4].Text.Replace("&amp;", "&");

            //if (des1.Length > 27)
            //{
            //    row.Cells[1].Text = des1.Substring(0, 27) + "...";
            //    row.Cells[1].ToolTip = des1;
            //}

            //if (des3.Length > 20)
            //{
            //    row.Cells[3].Text = des3.Substring(0, 20) + "...";
            //    row.Cells[3].ToolTip = des3;
            //}

            //if (des4.Length > 20)
            //{
            //    row.Cells[4].Text = des4.Substring(0, 20) + "...";
            //    row.Cells[4].ToolTip = des4;
            //}
        }
    }

    [System.Web.Services.WebMethod]
    public static string DropDown_BL_Charge_Code(string name)
    {
        DataSet ds = new DataSet();
        Auto_Search Auto = new Auto_Search();

        Auto.Enamesearch = name;
        Auto.NSearch = name;
        Auto.Ename = "BL_CHARGECODE_SEARCH_SELECT";
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

        if (ds.Tables[0].Rows.Count > 0)
        {
            string txtCharge_Code = ds.Tables[0].Rows[0]["CHARGE_CODE"].ToString();
            name = txtCharge_Code;
        }

        return name;
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

    public void Add_Pageno(int p)
    {
        if (p != 0)
        {
            ddlSelectPageno.Items.Clear();
            for (int i = 1; i <= p; i++)
            {

                ddlSelectPageno.Items.Add(Convert.ToString(i));
            }
        }
    }
    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSelectPageno.SelectedValue != "")
        {
            ViewState["selected_change"] = "1";

            gridbind(Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));

        }
    }
    public void Grid_Total(int currentPageNumber1, double totalRows)
    {
        if (gvdetails.Rows.Count > 0)
        {
            Div_Pagination.Visible = true;
            div_pagination1.Visible = true;

        }
        else if (gvdetails.Rows.Count == 0)
        {
            Div_Pagination.Visible = false;
            div_pagination1.Visible = false;

        }
        // get the total rows
        //totalRows = (double)Admin_mas.Total_Rows;

        //lblTotalPages.Text = CalculateTotalPages(totalRows).ToString();
        lblTotalPages.Text = Convert.ToString(totalRows);

        lblCurrentPage.Text = Convert.ToString(currentPageNumber1);

        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));

        if (currentPageNumber1 == 1)
        {

            btnPrev.Visible = false;

            if (Int32.Parse(lblTotalPages.Text) > 10)
            {
                btnNext.Visible = true;
                btnLast.Visible = true;
            }
            else
            {
                btnNext.Visible = false;
                btnLast.Visible = false;

            }

        }


        else if (Int32.Parse(lblCurrentPage.Text) == ii)
        {
            btnNext.Visible = false;
            //btnLast.Visible = false;
            btnPrev.Visible = true;

        }

        else
        {
            btnPrev.Visible = true;
            //btnLast.Visible = true;

            if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
                btnNext.Visible = false;
            else btnNext.Visible = true;
        }
        if (ViewState["selected_change"] == "1")
        {
        }
        else
            Add_Pageno(ii);
    }
    //---------------------Table sort Testing---------------------------------//
    protected void gvdetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortingDirection = string.Empty;
        if (gvdetails.Rows.Count > 0)
        {

            if (HD_tbl_sort.Value == string.Empty)
            {
                sortProperty = SortDirection.Ascending;
                sortingDirection = "Asc";

                HD_tbl_sort.Value = "1";
            }
            else
            {
                if (sortProperty == SortDirection.Descending)
                {
                    sortProperty = SortDirection.Ascending;
                    sortingDirection = "Asc";
                }
                else
                {

                    sortProperty = SortDirection.Descending;
                    sortingDirection = "Desc";
                }
            }
            HD_tbl_sort.Value = e.SortExpression.ToString();
            DataView sortedView = new DataView();
            sortedView = new DataView((DataTable)ViewState["sorttable"]);

            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            gvdetails.DataSource = sortedView;
            gvdetails.DataBind();

            Div_Pagination.Visible = true;
            div_pagination1.Visible = true;

            tblsort(sortingDirection);
        }


    }
    public SortDirection sortProperty
    {
        get
        {
            if (ViewState["SortingState"] == null)
            {
                ViewState["SortingState"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["SortingState"];
        }
        set
        {
            ViewState["SortingState"] = value;
        }
    }

    private void tblsort(string sortingDirection)
    {
        GridViewRow gridViewHeaderRow = gvdetails.HeaderRow;
        foreach (TableCell headerCell in gridViewHeaderRow.Cells)
        {
            if (headerCell.HasControls())
            {
                LinkButton headerButton = headerCell.Controls[0] as LinkButton;

                if (headerButton != null)
                {
                    System.Web.UI.HtmlControls.HtmlGenericControl div = new System.Web.UI.HtmlControls.HtmlGenericControl("div");

                    Label headerText = new Label();
                    headerText.Text = headerButton.Text;

                    div.Controls.Add(headerText);

                    System.Web.UI.WebControls.Image headerImage = new System.Web.UI.WebControls.Image();
                    if (HD_tbl_sort.Value == headerButton.CommandArgument)
                    {
                        if (sortingDirection == "Asc")
                        {
                            headerImage.ImageUrl = "~/images/icons/asc.png";
                            headerImage.CssClass = "space";
                        }
                        else
                        {
                            headerImage.ImageUrl = "~/images/icons/desc.png";
                            headerImage.CssClass = "space";
                        }
                        div.Controls.Add(headerImage);
                    }
                    else
                    {
                        headerImage.ImageUrl = "~/images/icons/Sync.png";
                        headerImage.CssClass = "space_2";
                        div.Controls.Add(headerImage);
                    }
                    headerButton.Controls.Add(div);
                }
            }
        }
    }
  
}