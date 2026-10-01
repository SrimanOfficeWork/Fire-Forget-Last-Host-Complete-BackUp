using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;



public partial class ListPopups_BCD_CTH_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    adminmaster Admin_mas = new adminmaster();
    AppSession aps = new AppSession();
    
    SqlConnection con;
    Manipulation mo;
    public string Name_Search;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!string.IsNullOrEmpty(Request["id"]))
        {
            HiddenField1.Value = Request.QueryString["id"].ToString();
        }
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;

        }
        else
        {
            Name_Search = txtCTHDesc.Text;

        }

        hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
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
        txtCTHNo.Text = "";
        txtCTHDesc.Text = "";

        Name_Search = "";
        btnSearch_Click(sender, e);
    }
    private void gridbind(int currentPageNumber1)
    {
        Admin_mas.Ecth_id = "0";
        Admin_mas.Ecth_code = txtCTHNo.Text;
        Admin_mas.Ecth_description = Name_Search;

        //Admin_mas.Ename = "select_con";
        Admin_mas.Ename = "select_con_Listpopup_Search";

        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();
        gvdetails.DataSource = Admin_mas.RetrieveAll_CTH_master();
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

        if (HiddenField1.Value == "CTH")
        {
            string str = gvdetails.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue('" + str + "')", true);
        }
        else if (HiddenField1.Value == "ITEM_DESC")
        {
            string str1 =rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open", "javascript:GetRowValue_ItemDescription('" + str1 + "')", true);
        }
        else if (HiddenField1.Value == "ItemCTHNO")
        {
            string str1 = gvdetails.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");

           // Page.ClientScript.RegisterStartupScript(Page.GetType(), "open", "javascript:GetRowValue_ItemCTHNO('" + str1 + "')", true);


            string a = string.Empty, b = string.Empty, c = string.Empty, d = string.Empty, f = string.Empty, g = string.Empty;

            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "GST_CTH_CODE";
            Auto.Enamesearch = str1;
            Auto.Notn_No_Search = str1;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                a = ds.Tables[0].Rows[0]["LEVY_1NOTIFICATION"].ToString();
                b = ds.Tables[0].Rows[0]["LEVY_1NOTIFICATION_SLNO"].ToString();
                c = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();

                d = ds.Tables[0].Rows[0]["LEVY_2NOTIFICATION"].ToString();
                f = ds.Tables[0].Rows[0]["LEVY_2NOTIFICATION_SLNO"].ToString();
                g = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE2"].ToString();
            }

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open", "javascript:GetRowValue_ItemCTHNO('" + str1 + "','"+a+"','"+b+"','"+c+"','"+d+"','"+f+"','"+g+"')", true);
        }
        else if (HiddenField1.Value == "Item_RITCNO")
        {
            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open", "javascript:GetRowValue_Item_RITCNO('" + str1 + "')", true);
        }
        else if (HiddenField1.Value == "Export_RITCNO")
        {
            string str1 = gvdetails.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open", "javascript:GetRowValue_Export_Item_RITCNO('" + str1 + "')", true);
        }
        else
        {
            string str1 = gvdetails.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open", "javascript:GetRowValue1('" + str1 + "')", true);
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

        }
        else if (gvdetails.Rows.Count == 0)
        {
            Div_Pagination.Visible = false;

        }
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
        if (ViewState["selected_change"] == "1")
        {
        }
        else
            Add_Pageno(ii);
    }
}