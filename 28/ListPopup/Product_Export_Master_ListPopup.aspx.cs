using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Product_Export_Master_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    adminmaster Admin_mas = new adminmaster();
    AppSession aps = new AppSession();
    eroyalmaster erm = new eroyalmaster();
    public string F_Description;
    SqlConnection con;
    Manipulation mo;
    Product_Export_Master Prct_Export = new Product_Export_Master();
    DataSet ds = new DataSet();
   
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        Session["HDN_GET_DBKSLNO_PRODUCT"] = "";

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
            Name_Search = txtDesc.Text;

        }

        //hdn_A_to_Z_Search.Value = "";
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
        txtRITCNo.Text = "";
        txtDesc.Text = "";
        txtPartNo.Text = "";

        Name_Search = "";
        btnSearch_Click(sender, e);
    }
    private void gridbind(int currentPageNumber1)
    {
        if (Name_Search == "" && txtRITCNo.Text == "" && txtDesc.Text == "" && txtPartNo.Text == "")
        {
            Prct_Export.PRODUCT_RITC = txtRITCNo.Text;
            Prct_Export._PRODUCT_DESCRIPTION = txtDesc.Text;
            Prct_Export.PARTNO = txtPartNo.Text;
            Prct_Export.flag = "select_bind";

        }

        else
        {
            Prct_Export.PRODUCT_RITC = txtRITCNo.Text;
            Prct_Export._PRODUCT_DESCRIPTION = Name_Search;
            Prct_Export.PARTNO = txtPartNo.Text;
            Prct_Export.flag = "select_con";
        }
       
        Prct_Export.startRowIndex = Convert.ToString(currentPageNumber1);
        Prct_Export.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.EmptyDataText = "No Record Found";
        //gvdetails.DataSource = erm.RetrieveAll_Product_import_MASTER();

        //we cannot asc sort in sqlserver because we used rowcount thats y we asc here
        //gvdetails.DataSource = aps.GridView_Sorting(erm.RetrieveAll_Product_import_MASTER(), "PRODUCT_DESCRIPTION");

        gvdetails.DataSource = aps.GridView_Sorting(Prct_Export.Retrive_Export_ProductMaster(), "PRODUCT_DESCRIPTION");

        ds = Prct_Export.Retrive_Export_ProductMaster();
        this.ViewState.Remove("sorttable");
        ViewState["sorttable"] = ds.Tables[0];
        //------

        gvdetails.DataBind();

        Grid_Total(currentPageNumber1, Prct_Export.result);

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

        string A_Z = Hdn_GetValue.Value;

        if (A_Z == "A_Z")
        {
            Hdn_GetValue.Value = "";
        }
        else
        {
            Name_Search = txtDesc.Text;
            hdn_A_to_Z_Search.Value = "";
        }

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();

        //F_Description = Session["desc"].ToString();

        if (HiddenField1.Value == "EXP_GET_PRODUCT")
        {

            string PRODUCT_DESCRIPTION = gvdetails.SelectedRow.Cells[7].Text.Replace("&nbsp;", "").Replace("&amp;", "&");

            string PRODUCT_RITC = gvdetails.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string REWARD_YES_NO = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            if (REWARD_YES_NO == "Y")
            {
                REWARD_YES_NO = "Yes";
            }
            else
            {
                REWARD_YES_NO = "No";
            }
            string STR_YES_NO = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            if (STR_YES_NO == "Y")
            {
                STR_YES_NO = "Yes";
            }
            else
            {
                STR_YES_NO = "No";
            }
            string STR_CODE = gvdetails.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string DBK_SLNO = gvdetails.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            string PARTNO = gvdetails.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            string SchemeCode = "";

            if (DBK_SLNO != "")
            {
                SchemeCode = "19-DRAWBACK (DBK)";
                Session["HDN_GET_DBKSLNO_PRODUCT"] = DBK_SLNO;
                Session["SchemeCode_PRODUCT"] = SchemeCode;
                
            }
            else
            {
                SchemeCode = "00-FREE SHIPPING BILL";
                Session.Remove("HDN_GET_DBKSLNO_PRODUCT");
                Session.Remove("SchemeCode_PRODUCT");
            }

            Session["New_Product_Change"]="New_Product";

            string New = Session["New_Product_Change"].ToString();

            Session["HDN_GET_DESCRIPTION_PRODUCT"] = PRODUCT_DESCRIPTION;

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue('" + PRODUCT_DESCRIPTION + "','" + PRODUCT_RITC + "','" + REWARD_YES_NO + "','" + STR_YES_NO + "','" + STR_CODE + "','" + SchemeCode + "','" + PARTNO + "')", true);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue('" + PRODUCT_DESCRIPTION + "','" + PRODUCT_RITC + "','" + REWARD_YES_NO + "','" + STR_YES_NO + "','" + STR_CODE + "')", true);
            //Response.Redirect("Unit_ListPopup.aspx");
        }    
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            var desc = row.Cells[1].Text;
            Session["desc"] = desc;

            if (desc.Length > 50)
            {
                row.Cells[1].Text = desc.Substring(0, 50) + "...";
                row.Cells[1].ToolTip = desc;
            }

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