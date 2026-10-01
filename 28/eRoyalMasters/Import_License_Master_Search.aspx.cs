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

public partial class Import_License_Master_Search : ThemeClass
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
    ErrorLogs er = new ErrorLogs();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            txt_License_No.Focus();
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
                Name_Search = txt_License_No.Text;
            }

            hdn_A_to_Z_Search.Value = "";
            //----------------------------A to Z SEARCH OPTION--------------------------//
            if (!IsPostBack)
            {
                Get_SchemeCode();
                btnSearch_Click(sender, e);

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }

    public void Get_SchemeCode()
    {
        try
        {
            adm.SCHEME_IMPORT_CODE = "0";
            adm.SCHEME_NOTN = "0";
            adm.name = "SCHEME_IMPORT_CODE";

            adm.RetrieveAll_Scheme_Import();
            ddl_Lic_Type.DataSource = adm.ds.Tables[0];
            ddl_Lic_Type.DataTextField = "SCHEME_CODE";
            ddl_Lic_Type.DataValueField = "SCHEME_CODE";
            ddl_Lic_Type.DataBind();
            ddl_Lic_Type.Items.Insert(0, "");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            int pageno = 1;

            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        try
        {
            txt_License_No.Text = "";
            //txt_License_desc.Text = "";

            Name_Search = "";
            btnSearch_Click(sender, e);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }

    public void gridbind(int currentPageNumber1)
    {
        try
        {
            Session["title"] = null;
            erm.LICENSE_ID = "0";
            erm.LICENSE_NO = Name_Search;
            erm.SCHEME_CODE = ddl_Lic_Type.SelectedItem.Text;
            erm.PARTY_NAME = txt_PartyName.Text;
            erm.LICENSE_ITEM_DESCRIPTION = "";
            erm.Ename = "select_con";
            erm.EWorking_Period = Session["WorkingPeriod"].ToString();

            erm.startRowIndex = Convert.ToString(currentPageNumber1);
            erm.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.EmptyDataText = "No Record Found";
            gvdetails.DataSource = aps.GridView_Sorting(erm.RetrieveAll_IMPORT_LICENSE_MASTER(), "LICENSE_NO");

            //------
            DataSet ds = new DataSet();
            erm.Ename = "select_con";
            ds = erm.RetrieveAll_IMPORT_LICENSE_MASTER();
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);

        return totalPages;
    }

    protected void ChangePage(object sender, CommandEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }


    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            var row = e.Row;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string values = this.gvdetails.DataKeys[e.Row.RowIndex]["LICENSE_ID"].ToString();
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("onclick", "opennew_Import_license('" + values + "')");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }


    public void Add_Pageno(int p)
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
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
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }


    //---------------------Table sort Testing---------------------------------//

    protected void gvdetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
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
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
      
    }
}