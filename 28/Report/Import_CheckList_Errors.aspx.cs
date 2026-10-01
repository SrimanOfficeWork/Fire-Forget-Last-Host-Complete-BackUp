using System.IO;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using BussinessObject;
using System;
using System.Text;
using System.Data;

using System.Web.UI.WebControls;
using System.Collections.Generic;
using iTextSharp.text.html.simpleparser;
using System.Web.UI;

using iTextSharp.text;
using iTextSharp.text.pdf;

using iTextSharp.text.html.simpleparser;
using System.Web;


public partial class Import_CheckList_Errors : ThemeClass
{
   Imp_Checklist IC =new Imp_Checklist();
   AppSession aps = new AppSession();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
           /* if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
            {
                gridbind();
            }
            */
            gridbind();
        }
    }
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gridbind();
    }
    private void gridbind()
    {
        string C_id =string.Empty;
        DataSet ds = new DataSet();
        C_id=Connection.COMPANYID();

        if (C_id == "293" || C_id == "4")
        {
            ds = IC.GetData(Connection.IMP_Jobno(), "", "Checklist_NOTN_Chk_Paramount");
        }
        else if (C_id == "164" || C_id == "1")
        {
            ds = IC.GetData(Connection.IMP_Jobno(), "", "Checklist_NOTN_Chk_Skylift");
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
        }
        gvdetails.DataBind();
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
    protected void btn_print_Click(object sender, EventArgs e)
    {
        int colCount = gvdetails.Columns.Count;
        PdfPTable table = new PdfPTable(colCount);
        table.HorizontalAlignment = 0;
        table.WidthPercentage = 100;
        table.TotalWidth = 100f;

        int[] colWidths = new int[gvdetails.Columns.Count];

        PdfPCell cell;
        string cellText;

        gvdetails.Columns[0].Visible = false;

        for (int colIndex = 0; colIndex < colCount; colIndex++)
        {
            colWidths[colIndex] = (int)gvdetails.Columns[colIndex].ItemStyle.Width.Value;
            gvdetails.Columns[0].Visible = false;
            table.SetWidths(new int[] { 10, 10, 30, 10,30,20,20 });

            cellText = Server.HtmlDecode(gvdetails.HeaderRow.Cells[colIndex].Text);

            cell = new PdfPCell(new Phrase(cellText.Replace("<br />", Environment.NewLine)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;

            table.AddCell(cell);
        }
        for (int rowIndex = 0; rowIndex < gvdetails.Rows.Count; rowIndex++)
        {
            if (gvdetails.Rows[rowIndex].RowType == DataControlRowType.DataRow)
            {
                for (int j = 0; j < gvdetails.Columns.Count; j++)
                {
                    cellText = Server.HtmlDecode(gvdetails.Rows[rowIndex].Cells[j].Text);
                    cell = new PdfPCell(new Phrase(cellText, FontFactory.GetFont("nina fett", 8)));
                    table.AddCell(cell);
                }
            }
        }

        Document pdfDoc = new Document(PageSize.A4, 7f, 7f, 7f, 0f);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        pdfDoc.Add(table);
        pdfDoc.Close();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;" + "filename=Importchecklisterror.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(pdfDoc);
        Response.End();

    }
 
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void btnexcel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Importchecklisterror.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gvdetails.AllowPaging = false;
            this.gridbind();

            gvdetails.HeaderRow.BackColor = System.Drawing.Color.White;
            foreach (TableCell cell in gvdetails.HeaderRow.Cells)
            {
                cell.BackColor = gvdetails.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvdetails.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvdetails.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvdetails.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            gvdetails.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

    }



}