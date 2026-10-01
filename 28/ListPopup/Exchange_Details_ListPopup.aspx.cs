
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

public partial class ListPopups_Exchange_Details_ListPopup : ThemeClass
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
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;

        }
        else
        {
            Name_Search = txtExchange_Code.Text;

        }

        hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!string.IsNullOrEmpty(Request["Invoice"]))
        {
            HiddenField1.Value = Request.QueryString["Invoice"].ToString();
        }

        if (!IsPostBack)
        {
            if (HiddenField1.Value == "ExportInvoiceCurrency" || HiddenField1.Value == "Commission" || HiddenField1.Value == "FOBDisc" || HiddenField1.Value == "PackMisc" || HiddenField1.Value == "OtherDeductions" || HiddenField1.Value == "Export_Freight" || HiddenField1.Value == "Export_Insurance" || HiddenField1.Value == "ITEM_UNITCODE" || HiddenField1.Value == "ITEM_AMOUNTCODE" || HiddenField1.Value == "Tariff_Amount_Code")
            {
               
                gvdetails.Columns[4].Visible = false;
                gvdetails.Columns[5].Visible = true;
            }
            else if (HiddenField1.Value == "IMP_EXP_Currency")
            {
               
                gvdetails.Columns[4].Visible = true;
                gvdetails.Columns[5].Visible = true; 
                innerbox_MidMain_Mid_country_pop.Style.Add("display", "none");
                tag_srcinner1grid_popup.Style.Add("display", "none");
                Div_Pagination.Style.Add("display", "none");
                tag_srcinner1grid_innerpopup.Style.Add("height", "400px");
            }
            else if (HiddenField1.Value == "QuoteCurrency")
            {
                 getmodule = Session["get_Module"].ToString();

                if (getmodule == "Sea Export" || getmodule == "Air Export")
                {
                    gvdetails.Columns[4].Visible = false;
                    gvdetails.Columns[5].Visible = true;
                }
                else
                {
                    gvdetails.Columns[4].Visible = true;
                    gvdetails.Columns[5].Visible = false;
                }

            }
            else
            {

                gvdetails.Columns[4].Visible = true;
                gvdetails.Columns[5].Visible = false;
            }
            
            int pageno = 1;

            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
    }


    public void gridbind(int currentPageNumber1)
    {
        erm.Eexchange_id = "0";
        erm.Ename = "select_con";
        erm.EXCHANGE_CUR_CODE = Name_Search;
        erm.EXCHANGE_NAME = txtExchange_Name.Text;
        erm.EWorking_Period = Working_Period;

        erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.EmptyDataText = "No Record Found";
        gvdetails.DataSource = erm.RetrieveAll_Exchange_master();

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
        txtExchange_Code.Text = "";
        txtExchange_Name.Text = "";

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

        if (HiddenField1.Value == "InvoiceCurrency")
        {
            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue('" + str1 + "','"+str2+"');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript://GetRowValue('" + str2 + "')", false);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "window.close();", true);


        }
        else if (HiddenField1.Value == "Misc")
        {

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Misc('" + str1 + "','" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);


        }
        else if (HiddenField1.Value == "Agency")
        {

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Agency('" + str1 + "','" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open9", "javascript://GetRowValue_Agency('" + str1 + "','" + str2 + "')", true);


        }
        else if (HiddenField1.Value == "Discount")
        {

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Discount('" + str1 + "','" + str2 + "');</script>", false);

           // Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open10", "javascript://GetRowValue_Discount('" + str1 + "','" + str2 + "')", true);


        }
        else if (HiddenField1.Value == "Loading")
        {

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Loading('" + str1 + "','" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open11", "javascript://GetRowValue_Loading('" + str1 + "','" + str2 + "')", true);


        }

        else if (HiddenField1.Value == "Freight")
        {

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Freight('" + str1 + "','" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open12", "javascript://GetRowValue_Freight('" + str1 + "','" + str2 + "')", true);


        }
        else if (HiddenField1.Value == "Insurance")
        {

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Insurance('" + str1 + "','" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open13", "javascript://GetRowValue_Insurance('" + str1 + "','" + str2 + "')", true);

        }
        else if (HiddenField1.Value == "HighSeaSale")
        {

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_HighSeaSale('" + str1 + "','" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open13", "javascript://GetRowValue_Insurance('" + str1 + "','" + str2 + "')", true);

        }
        else if (HiddenField1.Value == "ExportInvoiceCurrency")
        {

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[5].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Export('" + str1 + "','" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);


        }
        else if (HiddenField1.Value == "Commission")
        {

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            //string str2 = gvdetails.SelectedRow.Cells[4].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Export_Commission('" + str1 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);


        }
        else if (HiddenField1.Value == "FOBDisc")
        {

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            //string str2 = gvdetails.SelectedRow.Cells[4].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Export_FOBDisc('" + str1 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);


        }
          
        else if (HiddenField1.Value == "PackMisc")
        {

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            //string str2 = gvdetails.SelectedRow.Cells[4].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Export_PackMisc('" + str1 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);
        }
        else if (HiddenField1.Value == "OtherDeductions")
        {

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            //string str2 = gvdetails.SelectedRow.Cells[4].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Export_OtherDeductions('" + str1 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);
        }
        else if (HiddenField1.Value == "Export_Freight")
        {
              
            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            //string str2 = gvdetails.SelectedRow.Cells[4].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Export_Freight('" + str1 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);
        }
        else if (HiddenField1.Value == "Export_Insurance")
        {

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            //string str2 = gvdetails.SelectedRow.Cells[4].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Export_Insurance('" + str1 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open8", "javascript://GetRowValue_Misc('" + str1 + "','" + str2 + "')", true);
        }
        else if (HiddenField1.Value == "LicenseCurrency")
        {
            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_LicenseCurrency('" + str1 + "','" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript://GetRowValue('" + str2 + "')", false);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "window.close();", true);


        }

        if (HiddenField1.Value == "ITEM_UNITCODE")
        {

            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_ITEM_UNITCODE('" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript://GetRowValue('" + str2 + "')", false);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "window.close();", true);


        }
        if (HiddenField1.Value == "ITEM_AMOUNTCODE")
        {

            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_ITEM_AMOUNTCODE('" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript://GetRowValue('" + str2 + "')", false);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "window.close();", true);


        }
        if (HiddenField1.Value == "Tariff_Amount_Code")
        {

            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_Tariff_Amount_Unit('" + str2 + "');</script>", false);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript://GetRowValue('" + str2 + "')", false);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "window.close();", true);


        }

        if (HiddenField1.Value == "Currency_BL_generation")
        {
            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_BL_Generation_Unit('" + str1 + "');</script>", false);
        }

        if (HiddenField1.Value == "QuoteCurrency")
        {
            getmodule = Session["get_Module"].ToString();

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
            string str3 = rep.Replace(gvdetails.SelectedRow.Cells[5].Text);

            if (getmodule == "Sea Export" || getmodule == "Air Export")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_QuoteCurrency('" + str1 + "','" + str3 + "');</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>GetRowValue_QuoteCurrency('" + str1 + "','" + str2 + "');</script>", false);
            }
          
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "javascript://GetRowValue('" + str2 + "')", false);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open7", "window.close();", true);
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void btn_print_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=ExchangeDetails.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvdetails.AllowPaging = false;
        gvdetails.Columns[0].Visible = false;
        //gvdetails.HeaderRow.Style.Add("width", "15%");
        //gvdetails.HeaderRow.Style.Add("font-size", "16px");
        int pageno = 1;

       
        gridbind(pageno);
        gvdetails.DataBind();
        gvdetails.RenderControl(hw);
        //gvdetails.HeaderRow.Style.Add("width", "15%");
        //gvdetails.HeaderRow.Style.Add("font-size", "500px");


        //gvdetails.Style.Add("text-decoration", "none");
        //gvdetails.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        //gvdetails.Style.Add("font-size", "13px");

       
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 7f, 7f, 7f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
}