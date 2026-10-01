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

public partial class Staff_Master_Search : ThemeClass
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
    Staff_master sm = new Staff_master();
    //BankMaster erm = new BankMaster();
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

        txt_staffname.Focus();
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
        Div_Pagination.Visible = false;
        div_pagination1.Visible = false;

        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txt_staffname.Text;
        }

        hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            //Get_SchemeCode();
            btnSearch_Click(sender, e);        
           
        }
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

        txt_staffname.Text = "";
        

        Name_Search = "";
        btnSearch_Click(sender, e);
    }
    
    public void gridbind(int currentPageNumber1)
    {
       
        sm.STAFF_ID = "0";
        sm.STAFF_NAME = Name_Search;
        sm.STAFF_NAME = txt_staffname.Text;
        sm.EMPLOYEE_ID = "";
        sm.AADHAR_ID = "";
        sm.Ename = "select_con";
        sm.EWorking_Period = Session["WorkingPeriod"].ToString();

        sm.startRowIndex = Convert.ToString(currentPageNumber1);
        sm.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.EmptyDataText = "No Record Found";
        gvdetails.DataSource = aps.GridView_Sorting(sm.RetrieveAll_Staff_MASTER(), "STAFF_NAME");

        //------
        DataSet ds = new DataSet();
        sm.Ename = "select_con";
        ds = sm.RetrieveAll_Staff_MASTER();
        this.ViewState.Remove("sorttable");
        ViewState["sorttable"] = ds.Tables[0];
        //------

        gvdetails.DataBind();
        //we cannot asc sort in sqlserver because we used rowcount thats y we asc here

        Grid_Total(currentPageNumber1, erm.result);

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
        
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["STAFF_ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", "opennew_Staff_Master('" + values + "')");
        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
      
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

     
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

     
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
                        headerImage.CssClass = "space";
                        div.Controls.Add(headerImage);
                    }
                    headerButton.Controls.Add(div);
                }
            }
        }
    }
}