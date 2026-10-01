using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using BussinessObject;

public partial class Client_Master_Search_New : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 14;


    private int CurrentPage
    {
        get { return ViewState["CurrentPage"] != null ? (int)ViewState["CurrentPage"] : 1; }
        set { ViewState["CurrentPage"] = value; }
    }
    private int PageSize
    {
        get { return ViewState["PageSize"] != null ? (int)ViewState["PageSize"] : 20; }
        set { ViewState["PageSize"] = value; }
    }
    private int TotalRecords
    {
        get { return ViewState["TotalRecords"] != null ? (int)ViewState["TotalRecords"] : 0; }
        set { ViewState["TotalRecords"] = value; }
    }
    private int TotalPages
    {
        get { return (int)Math.Ceiling((double)TotalRecords / PageSize); }
    }

    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Client_Master_New_cs CM = new Client_Master_New_cs();

    //--------------------------------------------------
   
    //Manipulation mo;
    

    DataSet ds = new DataSet();
  
    
    public string Name_Search;

    protected void Page_Load(object sender, EventArgs e)
    
    {
        txtimpexpname.Focus();
        aps.checkSession();              
        Div_Pagination.Visible = false;
        
       
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txtimpexpname.Text;
        }

      
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (IsPostBack && TotalRecords > 0)
        {
            RecreatePaginationButtons();
        }
        if (!IsPostBack)
        {
           // Get_Client_Default_Settings();
            btnSearch_Click(sender, e);
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
            Name_Search = txtimpexpname.Text;
            hdn_A_to_Z_Search.Value = "";
        }

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtimpexpname.Text = "";
        Name_Search = "";
        btnSearch_Click(sender, e);
    }
    private int CalculateTotalPages(double totalRows)
    {
        if (totalRows <= 0) return 0;
        return (int)Math.Ceiling(totalRows / PageSize);  // use PageSize not gvdetails.PageSize
    }


    protected void ChangePage(object sender, CommandEventArgs e)
    {
        int next = CurrentPage;
        int total = TotalPages;

        switch (e.CommandName)
        {
            case "First": next = 1; break;
            case "Previous": next = Math.Max(1, CurrentPage - 1); break;
            case "Next": next = Math.Min(total, CurrentPage + 1); break;
            case "Last": next = total; break;
        }
        gridbind(next);
    }
   
    public void gridbind(int currentPageNumber1)
    {
        CurrentPage = currentPageNumber1;

        ObjUBO.A1 = Name_Search;
        ObjUBO.A2 = txtIecno.Text;

        ObjUBO.A3 = Convert.ToString((currentPageNumber1 - 1) * PageSize + 1);
        ObjUBO.A4 = Convert.ToString(PageSize);
        ObjUBO.A5 = ddlType.SelectedValue;
        ObjUBO.A6 = ddlCommercial_StateName.SelectedValue;

        gvdetails.EmptyDataText = "No Record Found";
        DataSet ds = new DataSet();
       // ds = CM.RetrieveAll_Imp_exp_master_STD_TYPE();
        ds = CM.ClientMaster_Search(ObjUBO);
        
        TotalRecords = CM.result;

        this.ViewState.Remove("sorttable");
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ViewState["sorttable"] = ds.Tables[0];
            gvdetails.DataSource = (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            ? (object)aps.GridView_Sorting(ds, "IMP_EXP_NAME")
                            : null;
            gvdetails.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IMP_EXP_NAME");
            dt.Columns.Add("IMP_EXP_IECNO");
           
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }
       
        RenderPagination();
        Session.Remove("STANDARD_TYPE");
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Session["IMP_EXP_ID"] = null;
        Session["CHECK_IECNO_SAVE"] = "SAVE";
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["IMP_EXP_IECNO"].ToString();
            string ClientName = this.gvdetails.DataKeys[e.Row.RowIndex]["IMP_EXP_NAME"].ToString();
            string Std_Non_Std = ddlType.SelectedValue;
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            // Call the PARENT window's opennewclientupdate_New (E_royal_Impex_Main.aspx, via
            // js/iframepopupwin.js) instead of this page's own copy, so the popup (dhtmlmodal)
            // renders in the top-level document and covers the whole screen instead of being
            // confined to this page's own #mainiframecontainer box. Mirrors the identical fix on
            // Transaction/General_Search.aspx.cs's ondblclick (General_Details_Update) - this
            // page only ever loads inside Main's #mainiframecontainer too (Master -> Common ->
            // Client menu item, target="maineroyal"). Falls back to the local copy only if this
            // page is ever opened standalone (no parent).
            e.Row.Attributes.Add("onclick",
                "if(window.parent && window.parent !== window && window.parent.opennewclientupdate_New){ window.parent.opennewclientupdate_New('" + values + "','" + ClientName + "','" + Std_Non_Std + "'); } else { opennewclientupdate_New('" + values + "','" + ClientName + "','" + Std_Non_Std + "'); }");
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
   
    //---------------------Table sort Testing---------------------------------//
    // ── Replaces old Grid_Total ───────────────────────────────────
    public void Grid_Total(int currentPageNumber1, double totalRows)
    {
        // kept for compatibility — now just calls RenderPagination
        TotalRecords = (int)totalRows;
        CurrentPage = currentPageNumber1;
        RenderPagination();
    }

    private void RenderPagination()
    {
        bool hasRows = gvdetails.Rows.Count > 0;
        Div_Pagination.Visible = hasRows;

        if (!hasRows) return;

        // Info labels
        int from = (CurrentPage - 1) * PageSize + 1;
        int to = Math.Min(CurrentPage * PageSize, TotalRecords);
        lblRecordFrom.Text = from.ToString();
        lblRecordTo.Text = to.ToString();
        lblTotalPages.Text = TotalRecords.ToString();   // ← fixes FormatException
        lblCurrentPage.Text = CurrentPage.ToString();

        // Sync hidden dropdown
        int totalPg = CalculateTotalPages(TotalRecords);
        Add_Pageno(totalPg);
        if (ddlSelectPageno.Items.FindByText(CurrentPage.ToString()) != null)
            ddlSelectPageno.SelectedIndex = CurrentPage - 1;

        // First/Prev/Next/Last enabled state
        btnFirst.Enabled = btnPrev.Enabled = (CurrentPage > 1);
        btnNext.Enabled = btnLast.Enabled = (CurrentPage < TotalPages);

        // Numbered buttons
        RecreatePaginationButtons();
    }
    protected void ChangePage_Numbered(object sender, CommandEventArgs e)
    {
        int page = int.Parse(e.CommandArgument.ToString());
        CurrentPage = page;   // ← update ViewState FIRST
        gridbind(page);
    }


    private List<int> GetPageNumbers(int current, int total)
    {
        var set = new HashSet<int>();
        set.Add(1);
        set.Add(total);
        for (int i = Math.Max(2, current - 2); i <= Math.Min(total - 1, current + 2); i++)
            set.Add(i);
        var list = new List<int>(set);
        list.Sort();
        return list;
    }
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
          //  div_pagination1.Visible = true;

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

    public void Get_Client_Default_Settings()
    {
        CM.STANDARD_TYPE = "";
        CM.YEAR = "";
        CM.flag = "Get_Details";
        ds = CM.Client_DefaultSettings_Insert_Update();

        if (ds.Tables[0].Rows.Count > 0)
        {
            string STANDARD_TYPE = ds.Tables[0].Rows[0]["STANDARD_TYPE"].ToString();

            if (STANDARD_TYPE == "Non_STD")
            {
                ddlType.SelectedItem.Text = "Non-Standard";

                ddlType.Items.Clear();
                ddlType.Items.Add("Non-Standard");
                ddlType.Items.Add("Standard");
            }
            else
            {
                ddlType.SelectedItem.Text = "Standard";

                ddlType.Items.Clear();
                ddlType.Items.Add("Standard");
                ddlType.Items.Add("Non-Standard");
              
            }
        }
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageSize = int.Parse(ddlPageSize.SelectedValue);
        CurrentPage = 1;
        gridbind(CurrentPage);
    }


    private void RecreatePaginationButtons()
    {
        phPageNumbers.Controls.Clear();

        if (TotalPages <= 1) return;

        List<int> pages = GetPageNumbers(CurrentPage, TotalPages);
        int prev = 0;

        foreach (int p in pages)
        {
            if (prev > 0 && p - prev > 1)
            {
                Label dots = new Label();
                dots.Text = "...";
                dots.CssClass = "pag-dots";
                phPageNumbers.Controls.Add(dots);
            }

            if (p == CurrentPage)
            {
                Label active = new Label();
                active.Text = p.ToString();
                active.CssClass = "pag-active";
                phPageNumbers.Controls.Add(active);
            }
            else
            {
                LinkButton lb = new LinkButton();
                lb.ID = "pgBtn_" + p;  // stable ID — critical!
                lb.Text = p.ToString();
                lb.CssClass = "pag-num-btn";
                lb.CommandName = "Page";
                lb.CommandArgument = p.ToString();
                lb.Command += ChangePage_Numbered;
                phPageNumbers.Controls.Add(lb);
            }
            prev = p;
        }
    }
}