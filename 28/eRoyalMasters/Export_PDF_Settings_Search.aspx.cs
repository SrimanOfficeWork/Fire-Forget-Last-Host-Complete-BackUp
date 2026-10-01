using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


public partial class Export_PDF_Settings_Search : ThemeClass
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
        txtProduct.Focus();
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
        Div_Pagination.Visible = false;
        div_pagination1.Visible = false;
        
       
       

        //hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            Bind_Clients();
            btnSearch_Click(sender, e);
            //DataTable dt = new DataTable();
            //gvdetails.EmptyDataText = "";
            //gvdetails.DataSource = dt;
            //gvdetails.DataBind();
         }

        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;

        }
        else
        {
            if (ddl_ExporterName.SelectedItem != null)
            {
                Name_Search = ddl_ExporterName.SelectedItem.Text;
            }
          

        }
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {

        txtProduct.Text = ""; ddl_ExporterName.SelectedItem.Text = ""; 
        //txtPartNo.Text = ""; 
        txtRITCNo.Text = "";
        //Name_Search = "";
        btnSearch_Click(sender, e);
    }

    public void Bind_Clients()
    {
        DataSet ds_client = new DataSet();
        //Export_PDF_Upload exp_pdf = new Export_PDF_Upload();

        erm.Eproduct_imp_id = "0";
        erm.Eproduct_imp_cth = "0";
        erm.Eproduct_imp_ceth = "0";
        erm.Eproduct_imp_ritc = "0";
        erm.Eproduct_imp_description = "0";
        erm.Ename = "Bind_Exporter_List_Master";
        erm.EWorking_Period = Working_Period;

        erm.startRowIndex = "";
        erm.maximumRows = "";
        ds_client = erm.RetrieveAll_Export_PDF_Settings_MASTER();

        if (ds_client.Tables[0].Rows.Count > 0)
        {
            ddl_ExporterName.DataSource = ds_client.Tables[0];
            ddl_ExporterName.DataTextField = "EXPORTER_NAME";
            ddl_ExporterName.DataTextField = "EXPORTER_NAME";
            ddl_ExporterName.DataBind();

            ddl_ExporterName.Items.Insert(0, "");
        }

    }

    public void gridbind(int currentPageNumber1)
    {
        if (Name_Search == ""  && txtRITCNo.Text == "")
        {
            erm.Eproduct_imp_id = "0";
            erm.Eproduct_imp_cth = "0";
            erm.Eproduct_imp_ceth = "0";
            erm.Eproduct_imp_ritc = "0";
            erm.Eproduct_imp_description = "0";
            erm.Ename = "select_bind";
            erm.EWorking_Period = Working_Period;

        }

        else
        {
            erm.Eproduct_imp_id = "0";
            erm.Eproduct_imp_cth = txtRITCNo.Text;
            //erm.Eproduct_imp_ceth = ddl_ExporterName.SelectedItem.Text;
            erm.Eproduct_imp_ceth = Name_Search;
            //erm.Eproduct_imp_ritc = txtPartNo.Text;
            erm.Eproduct_imp_ritc = "";
            //erm.Eproduct_imp_description = Name_Search;
            erm.Eproduct_imp_description = txtProduct.Text;
            erm.Ename = "select_con";
            erm.EWorking_Period = Working_Period;

        }
        erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.EmptyDataText = "No Record Found";
        //gvdetails.DataSource = erm.RetrieveAll_Product_import_MASTER();

        //we cannot asc sort in sqlserver because we used rowcount thats y we asc here
        gvdetails.DataSource = aps.GridView_Sorting(erm.RetrieveAll_Export_PDF_Settings_MASTER(), "ITEM_DESC");

        //------
        DataSet ds = new DataSet();
        ds = erm.RetrieveAll_Export_PDF_Settings_MASTER();
        this.ViewState.Remove("sorttable");
        ViewState["sorttable"] = ds.Tables[0];
        //------

        gvdetails.DataBind();
        //we cannot asc sort in sqlserver because we used rowcount thats y we asc here
        if (ds.Tables[0].Rows.Count > 0)
        {
            tblsort("test");
        }


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
        totalRows = (double)erm.result;

        //lblTotalPages.Text = CalculateTotalPages(totalRows).ToString();
        lblTotalPages.Text = Convert.ToString(totalRows);

        lblCurrentPage.Text = Convert.ToString(currentPageNumber1);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        if (currentPageNumber1 == 1)
        {
            btnPrev.Visible = false;

            if (Int32.Parse(lblTotalPages.Text) > 0)
            {
                btnNext.Visible = true;
                btnLast.Visible = true;
            }
            else
            {
                btnNext.Visible = false;
                //btnLast.Visible = true;

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
            if (ddl_ExporterName.SelectedItem != null)
            {
                Name_Search = ddl_ExporterName.SelectedItem.Text;
            }
            else
            {
                Name_Search = "";
            }
            hdn_A_to_Z_Search.Value = "";
        }

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
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
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", "open_exp_pdf_master_Update('" + values + "')");

            var des1 = row.Cells[1].Text.Replace("&amp;", "&");
            var des3 = row.Cells[3].Text.Replace("&amp;", "&");
            var des4 = row.Cells[4].Text.Replace("&amp;", "&");

            if (des1.Length > 100)
            {
                row.Cells[0].Text = des1.Substring(0, 100) + "...";
                row.Cells[0].ToolTip = des1;
            }

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
            gridbind(Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));
        }
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