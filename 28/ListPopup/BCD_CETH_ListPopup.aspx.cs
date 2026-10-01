using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class ListPopups_BCD_CETH_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    adminmaster Admin_mas = new adminmaster();
    AppSession aps = new AppSession();

    SqlConnection con;
    Manipulation mo;
    string str;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!string.IsNullOrEmpty(Request["id"]))
        {
            HiddenField1.Value = Request.QueryString["id"].ToString();
        }

        if (!IsPostBack)
        {
            int pageno = 1;

            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        //txtCETHno.Text = "";
       
        //Name_Search = "";
        btnSearch_Click(sender, e);
    }

    private void gridbind(int currentPageNumber1)
    {
        Admin_mas.Eceth_id = "";
        Admin_mas.Eceth_code = txtCETHno.Text;
        Admin_mas.Eceth_description = "";

        Admin_mas.Ename = "select_con";


        //string Query = "STATE_MASTER_SP_SELECT_CON";
        //gvdetails.DataSource = am.RetrieveAll_State_Master_LIKE(Query, txtStateCode.Text, txtStateName.Text);

        //gvdetails.DataBind();

        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();
        gvdetails.DataSource = Admin_mas.RetrieveAll_CETH_master();
        gvdetails.DataBind();
        Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);


       

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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();
        str = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
        if (HiddenField1.Value == "CETH_NO")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue('" + str + "')", true);
        }
       
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex);

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
    public void Grid_Total(int currentPageNumber1, double totalRows)
    {
        if (gvdetails.Rows.Count > 0)
        {
            Div_Pagination.Visible = true;

        }
        else if (gvdetails.Rows.Count == 0)
        {
            Div_Pagination.Visible = false;

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
        if (ViewState["selected_change"] == "1")
        {
        }
        else
            Add_Pageno(ii);
    }
}