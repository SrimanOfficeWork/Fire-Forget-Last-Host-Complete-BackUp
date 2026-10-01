using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


public partial class eRoyalMasters_Default : ThemeClass
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
       
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;

        }
        else
        {
            Name_Search = txtProduct.Text;

        }

        //hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            btnSearch_Click(sender, e);

        }
        
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {

        txtProduct.Text = ""; txtImporterName.Text = ""; txtPartNo.Text = ""; txtCTHNo.Text = "";
        Name_Search = "";
        btnSearch_Click(sender, e);
    }

    public void gridbind(int currentPageNumber1)
    {
        //if (ViewState["Last_CTHNo"] != null && txtCTHNo.Text =="")
        //{
        //    txtCTHNo.Text = ViewState["Last_CTHNo"].ToString();
        //}
        if (Name_Search == "" && txtCTHNo.Text == "" && txtImporterName.Text == "" && txtPartNo.Text == "")
        {           
            erm.Eproduct_imp_id = "0";
            erm.Eproduct_imp_cth = "0";
            erm.IMPORTER_NAME = "0";
            erm.PARTNO = "0";
            erm.Eproduct_imp_description = "0";
            erm.Ename = "select_bind";
            erm.EWorking_Period = Working_Period;



        }

        else
        {
            erm.Eproduct_imp_id = "0";
            erm.Eproduct_imp_cth = txtCTHNo.Text;
            //ViewState["Last_CTHNo"] = txtCTHNo.Text;
            erm.IMPORTER_NAME = txtImporterName.Text;
            erm.PARTNO = txtPartNo.Text;            
            erm.Eproduct_imp_description = Name_Search;
            erm.Ename = "select_con";
            erm.EWorking_Period = Working_Period;

        }
        ////////////////////////
        //if (txtCTHNo.Text != "")
        //{
        //    Session["Last_CTHNo"] = txtCTHNo.Text;
        //}
        //if (txtPartNo.Text != "")
        //{
        //    Session["Last_PartNo"] = txtPartNo.Text;  
        //}
        //if (txtCTHNo.Text == "")
        //{
        //    if (Session["Last_CTHNo"] != null)
        //    {
        //        erm.Eproduct_imp_cth = Session["Last_CTHNo"].ToString();
        //        erm.PARTNO = txtPartNo.Text;
        //        erm.Eproduct_imp_id = "0";
        //        erm.IMPORTER_NAME = txtImporterName.Text;
        //        erm.Eproduct_imp_description = Name_Search;
        //        erm.Ename = "select_con";
        //        erm.EWorking_Period = Working_Period;
        //    }
        //}
        //else if (txtPartNo.Text == "")
        //{
        //    if (Session["Last_PartNo"] != null)
        //    {
        //        erm.PARTNO = Session["Last_PartNo"].ToString();
        //        erm.Eproduct_imp_cth = txtCTHNo.Text;
        //        erm.Eproduct_imp_id = "0";
        //        erm.IMPORTER_NAME = txtImporterName.Text;
        //        erm.Eproduct_imp_description = Name_Search;
        //        erm.Ename = "select_con";
        //        erm.EWorking_Period = Working_Period;
        //    }
        //}
        ////////////////////////
        erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.EmptyDataText = "No Record Found";
       
        gvdetails.DataSource = aps.GridView_Sorting(erm.RetrieveAll_Import_Caterpillar_MASTER(), "PRODUCT_DESCRIPTION");

        //------
        DataSet ds = new DataSet();
        ds = erm.RetrieveAll_Import_Caterpillar_MASTER();
        this.ViewState.Remove("sorttable");
        ViewState["sorttable"] = ds.Tables[0];
        //------

        gvdetails.DataBind();
        
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
        
        totalRows = (double)erm.result;

        
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
               

            }

        }


        else if (Int32.Parse(lblCurrentPage.Text) == ii)
        {
            btnNext.Visible = false;           
            btnPrev.Visible = true;

        }

        else
        {
            btnPrev.Visible = true;        

            if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
                btnNext.Visible = false;
            else btnNext.Visible = true;
        }
        //txtCTHNo.Text = Session["Last_CTHNo"].ToString();
        //Session["Last_CTHNo"] = null;
        //Session["Last_PartNo"] = null;
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
            Name_Search = txtProduct.Text;
            hdn_A_to_Z_Search.Value = "";
        }
        //Session["Last_CTHNo"] = null;
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
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", "Import_CaterPillar_Master_Update('" + values + "')");

            var des0 = row.Cells[0].Text.Replace("&amp;", "&");
            var des3 = row.Cells[3].Text.Replace("&amp;", "&");
            var des4 = row.Cells[4].Text.Replace("&amp;", "&");

            if (des0.Length > 25)
            {
                row.Cells[0].Text = des0.Substring(0, 25) + "...";
                row.Cells[0].ToolTip = des0;
            }

            if (des3.Length > 15)
            {
                row.Cells[3].Text = des3.Substring(0, 15) + "...";
                row.Cells[3].ToolTip = des3;
            }

            if (des4.Length > 15)
            {
                row.Cells[4].Text = des4.Substring(0, 15) + "...";
                row.Cells[4].ToolTip = des4;
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