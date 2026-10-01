using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class AIDC_Master_ListPopup : System.Web.UI.Page
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 15;
    adminmaster Admin_mas = new adminmaster();

    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        
        if (!IsPostBack)
        {
            if (Request.QueryString["RITC"] != "" && Request.QueryString["RITC"] != null)
            {
                HiddenField1.Value = Request.QueryString["RITC"].ToString().Trim();
                txt_RITC.Text = Request.QueryString["RITC"].ToString().Trim();
            }

            if (Request.QueryString["Country_Name"] != "" && Request.QueryString["Country_Name"] != null)
            {
                hdn_Country.Value = Request.QueryString["Country_Name"].ToString();
            }

            int pageno = 1;
            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
        
    }

    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
    private void gridbind(int currentPageNumber1)
    {
        //Admin_mas.CHARGE_ID = "0";
        Admin_mas.AIDC_RITC_NO = txt_RITC.Text;
        Admin_mas.AIDC_NOTN_NO = txt_AIDC_NOTN_NO.Text;
        Admin_mas.AIDC_NOTN_SLNO = txt_AIDC_NOTN_SLNO.Text;
        Admin_mas.Ename = "select_con";
        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.EmptyDataText = "No Record Found";
        ds = Admin_mas.Get_AIDC_Master();

        if (hdn_Country.Value != "UNITED ARAB EMIRATES" && hdn_Country.Value != "SWITZERLAND" && hdn_Country.Value != "NORWAY")
        {
            var query = from t in ds.Tables[0].AsEnumerable()
                        where t.Field<string>("AIDC_NOTN_NO") != ("022/2022")
                        select t;

            int Row_Count = query.Count();
            DataTable dt_AIDC = new DataTable();

            if (Row_Count > 0)
            {
                dt_AIDC = query.CopyToDataTable();
            }

            gvdetails.DataSource = dt_AIDC;
            gvdetails.DataBind();
        }

        if (hdn_Country.Value == "SWITZERLAND")
        {
          
           var query = from t in ds.Tables[0].AsEnumerable()
                        where t.Field<string>("AIDC_NOTN_NO") == ("041/2025")
                        select t;

            int Row_Count = query.Count();
            DataTable dt_AIDC = new DataTable();

            if (Row_Count > 0)
            {
                dt_AIDC = query.CopyToDataTable();
            }

            gvdetails.DataSource = dt_AIDC;
            gvdetails.DataBind();
        }
        else if (hdn_Country.Value == "NORWAY")
        {
            string[] targets = { "042/2025", "043/2025" };

            var query = from t in ds.Tables[0].AsEnumerable()
                        where targets.Any(x => t.Field<string>("AIDC_NOTN_NO").Contains(x))
                        select t;

            int Row_Count = query.Count();
            DataTable dt_AIDC = new DataTable();

            if (Row_Count > 0)
            {
                dt_AIDC = query.CopyToDataTable();
            }

            gvdetails.DataSource = dt_AIDC;
            gvdetails.DataBind();
        }
        else
        {
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();
        }

        Grid_Total(currentPageNumber1, Admin_mas.result);
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
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();

        string str0 = rep.Replace(gvdetails.SelectedRow.Cells[0].Text);
        string str1 = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
        string str2 = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
        string str3 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);

        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue('" + str1 + "','" + str2 + "','" + str3 + "')", true);
        
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
}
