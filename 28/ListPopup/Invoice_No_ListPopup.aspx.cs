using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;

public partial class ListPopups_Invoice_No_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    DataSet dtuser = new DataSet();
    adminmaster erm = new adminmaster();
    SqlConnection con;
    Manipulation mo;
    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string getmodule;
    public string JobType;          // FIX 6a: Job Type comes from parent page

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        /* FIX 6a: parent opens the popup as
             Invoice_No_ListPopup.aspx?jt=I   (or E / A)
           so the SP knows which table(s) to read:
             I = INVOICE_DETAILS, E = EXPORT_INVOICE_DETAILS, A = both      */
        JobType = string.IsNullOrEmpty(Request.QueryString["jt"])
                    ? "A" : Request.QueryString["jt"];

        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txtInvoice_Code.Text;
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


    public void gridbind(int currentPageNumber1)
    {
        /* FIX 6: was the exchange-master call:
               erm.Eexchange_id = "0";
               erm.Ename = "select_con";
               erm.EXCHANGE_CUR_CODE = Name_Search;
           Now calls the invoice flag with Job Type.
           NOTE: add INVOICE_NO / JOB_TYPE string properties to your
    'adminmaster' class (same way EXCHANGE_CUR_CODE exists), and in
           its RetrieveAll method pass them as @Name_Search and @JobType
           to the flag SP branch 'select_invoice_con'.                      */
        erm.Ename = "select_invoice_con";
        erm.INVOICE_NO = Name_Search;
        erm.JOB_TYPE = JobType;
        erm.EWorking_Period = Working_Period;

        //erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.startRowIndex =
         Convert.ToString(((currentPageNumber1 - 1) * gvdetails.PageSize) + 1);

        erm.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.EmptyDataText = "No Record Found";
        gvdetails.DataSource = erm.RetrieveAll_Invoice_Search();   // mirror of RetrieveAll_Exchange_master

        gvdetails.DataBind();
        Grid_Total(currentPageNumber1, erm.result);
    }

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);
        return totalPages;
    }

    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtInvoice_Code.Text = "";
        Name_Search = "";
        btnSearch_Click(sender, e);
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

        /* FIX 2 + FIX 3:
           - OLD code read Cells[3] and Cells[4] -> grid has only 3 columns
             (0 = hidden Select, 1 = S.NO, 2 = Invoice No), so Cells[3]
             threw 'Index out of range' on every row click.
           - OLD condition  if (HiddenField1.Value == "InvoiceCurrency")
             was never true because HiddenField1 is never set anywhere,
             so selecting a row silently did NOTHING. Removed.
           Invoice No is in Cells[2]; only one value is sent back.          */
        string invNo = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello",
            "<script language='javascript'>GetRowValue('" + invNo + "');</script>", false);
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes["onclick"] =
                ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex);
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

        /* FIX 9: ViewState["selected_change"] == "1" compared an object
           reference with a string - after postback deserialization it is
           false even when the value IS "1". Use Convert.ToString().        */
        if (Convert.ToString(ViewState["selected_change"]) == "1")
        {
        }
        else
            Add_Pageno(ii);
    }
}


















