using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class Annexure_Default_Master : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    DataSet dtuser = new DataSet();
    eroyalmaster erm = new eroyalmaster();
    SqlConnection con;
    Manipulation mo;
    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;

    protected void Page_Load(object sender, EventArgs e)
    {

        txtIec_Name.Focus();
        aps.checkSession();
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
            Name_Search = txtIec_Name.Text;

        }

        //hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            btnSearch_Click(sender, e);
        }
    }

    public void gridbind(int currentPageNumber1)
    {

        erm.Exp_Imp_Name = Name_Search;
        erm.IMP_CLIENT_BRANCH_SLNO = "0";
        erm.Ename = "SELECT_GRID";
        erm.WORKING_PERIOD = Working_Period;

        erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.EmptyDataText = "No Record Found";
        //we cannot asc sort in sqlserver because we used rowcount thats y we asc here
        gvdetails.DataSource = aps.GridView_Sorting(erm.OCR_ANNEXURE_DEFAULT_MASTER(), "EXPORTER_NAME");

        //------
        DataSet ds = new DataSet();
        ds = erm.OCR_ANNEXURE_DEFAULT_MASTER();
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;

        string A_Z = Hdn_GetValue.Value;

        if (A_Z == "A_Z")
        {
            Hdn_GetValue.Value = "";
        }
        else
        {
            Name_Search = txtIec_Name.Text;
            hdn_A_to_Z_Search.Value = "";
        }

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {

        txtIec_Name.Text = "";

        Name_Search = "";
        btnSearch_Click(sender, e);
    }

    protected void imgbtn_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        Session["EXP_CLIENT_ID"] = gvdetails.DataKeys[gvrow.RowIndex].Value.ToString();


        //imgbtn.Attributes.Add("OnClientClick", "window.open('Suppliermasterentry.aspx','targetWindow','toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes,');return false;");
        string popupScript = "window.open('../eRoyalMasters/Exp_Client_Master.aspx?EXP_CLIENT_ID=" + Session["EXP_CLIENT_ID"].ToString() + "','NewWindow','width=550,height=400,menubar=no,left=230,top=120,bottom=60,resizable=0,ScrollBars=1');";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "NewWindow", popupScript, true);

        //Page.ClientScript.RegisterStartupScript(typeof(string), "popup", "<script> window.open('../eRoyalMasters/Suppliermasterentry.aspx', '_self');</script>");



    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", "open_exp_default_master_new_update('" + values + "')");


            var des0 = row.Cells[0].Text.Replace("&amp;", "&");
            var des1 = row.Cells[1].Text.Replace("&amp;", "&");
            var des2 = row.Cells[2].Text.Replace("&amp;", "&");

            //var des3 = row.Cells[3].Text.Replace("&amp;", "&");
            //var des4 = row.Cells[4].Text.Replace("&amp;", "&");

            if (des0.Length > 22)
            {
                row.Cells[0].Text = des0.Substring(0, 22) + "...";
                row.Cells[0].ToolTip = des0;
            }
            if (des1.Length > 15)
            {
                row.Cells[1].Text = des1.Substring(0, 15) + "...";
                row.Cells[1].ToolTip = des1;
            }

            if (des2.Length > 15)
            {
                row.Cells[2].Text = des2.Substring(0, 15) + "...";
                row.Cells[2].ToolTip = des2;
            }

            //if (des3.Length > 15)
            //{
            //    row.Cells[3].Text = des3.Substring(0, 15) + "...";
            //    row.Cells[3].ToolTip = des3;
            //}

            //if (des4.Length > 15)
            //{
            //    row.Cells[4].Text = des4.Substring(0, 15) + "...";
            //    row.Cells[4].ToolTip = des4;
            //}

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
    //---------------------Table sort---------------------------------//

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