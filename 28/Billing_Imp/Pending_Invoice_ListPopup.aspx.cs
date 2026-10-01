
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

public partial class Pending_Invoice_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    
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


    public string SELECT_TYPE, SELECT_BRANCH;

    Quotation_Master QM = new Quotation_Master();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentbranch = Session["currentbranch"].ToString();

        // commented for areawise implementation on 05-mar-2020
        /*
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();
            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                HDBranch.Value = SELECT_BRANCH;
            }
            else
            {
                SELECT_BRANCH = "";
                HDBranch.Value = SELECT_BRANCH;
            }
        }
        else
        {
            SELECT_BRANCH = "";
            HDBranch.Value = SELECT_BRANCH;
        }
        
  * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        HDBranch.Value = SELECT_BRANCH;
        if (!IsPostBack)
        {
            if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
            {
                Load_Search_Type();
            }
            gridbind();
        }
    }


    private void gridbind()
    {
        DataSet ds1 = new DataSet();
        if (ddltype.SelectedItem.Value != "0")
        {
            //QM.Module_name = ddltype.SelectedValue.ToString();
            QM.Module_name = hdn_SearchType.Value;
            QM.Client_name = txttype.Text;
        }
        else
        {
            QM.Module_name = "";
            QM.Client_name = "";
        }
        QM.MODULE = Request.QueryString["Page"].ToString();
        QM.flag = "Grid_Search";
        QM.Branch_Common = SELECT_BRANCH;
        ds1 = QM.PENDING_INVOICE();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds1.Tables[0];
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
        }
        gvdetails.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gridbind();
    }


    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
       
        txttype.Text = " ";
       
        btnSearch_Click(sender, e);
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


    private void Load_Search_Type()
    {
        lbl_IE.Text = Request.QueryString["Page"].ToString();
        ddltype.Items.Clear();
        ddltype.Items.Add(" ");
        ddltype.Items.Add("Job. no");
        ddltype.Items.Add("File.Ref.no");

        if (Request.QueryString["Page"].ToString() == "Import")
        {
           
            ddltype.Items.Add("Imp.Name");
            ddltype.Items.Remove("Exp.Name");
        }
        else
        {
           
            ddltype.Items.Add("Exp.Name");
            ddltype.Items.Remove("Imp.Name");
        }
    }

    
 
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    

    protected void btn_print_Click(object sender, EventArgs e)
    {

       // column count
        int colCount = gvdetails.Columns.Count;

        //Create a table
        PdfPTable table = new PdfPTable(colCount);

        table.HorizontalAlignment = 0;
        table.WidthPercentage = 100;
        table.TotalWidth = 100f;

        //create an array to store column widths
        int[] colWidths = new int[gvdetails.Columns.Count];

        PdfPCell cell;
        string cellText;

        gvdetails.Columns[0].Visible = false;

        //create the header row
        for (int colIndex = 0; colIndex < colCount; colIndex++)
        {
            //set the column width
            colWidths[colIndex] = (int)gvdetails.Columns[colIndex].ItemStyle.Width.Value;
            gvdetails.Columns[0].Visible = false;
            table.SetWidths(new int[] { 10, 10, 20, 60 });

            //fetch the header text
            cellText = Server.HtmlDecode(gvdetails.HeaderRow.Cells[colIndex].Text);

            //create a new cell with header text
            cell = new PdfPCell(new Phrase(cellText.Replace("<br />", Environment.NewLine)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;

            //set the background color for the header cell
            //cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#d1dbe0"));

            //add the cell to the table. we dont need to create a row and add cells to the row
            //since we set the column count of the table to 4, it will automatically create row for
            //every 4 cells
            table.AddCell(cell);
        }

        //export rows from GridView to table
        for (int rowIndex = 0; rowIndex < gvdetails.Rows.Count; rowIndex++)
        {
            if (gvdetails.Rows[rowIndex].RowType == DataControlRowType.DataRow)
            {
                for (int j = 0; j < gvdetails.Columns.Count; j++)
                {
                    //fetch the column value of the current row
                    cellText = Server.HtmlDecode(gvdetails.Rows[rowIndex].Cells[j].Text);

                    //create a new cell with column value
                    cell = new PdfPCell(new Phrase(cellText, FontFactory.GetFont("nina fett", 8)));

                    
                    //add the cell to the table
                    table.AddCell(cell);
                }
            }
        }

        //Create the PDF Document
        Document pdfDoc = new Document(PageSize.A4, 7f, 7f, 7f, 0f);

        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

        //open the stream
        pdfDoc.Open();

        //add the table to the document
        pdfDoc.Add(table);

        //close the document stream
        pdfDoc.Close();

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;" + "filename=pendingInvoice.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(pdfDoc);
        Response.End();

    }

}