using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class Pending_Invoice_ListPopup : ThemeClass
{
    GST_Sales_Entry_cs BP = new GST_Sales_Entry_cs();
    Global_variables ObjUBO = new Global_variables();
    AppSession aps = new AppSession();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            Company_Id();
            if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
            {
                gridbind();
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gridbind();
    }
    private void gridbind()
    {
        try
        {
                string con_String = Get_Con_String();
                DataSet ds1 = new DataSet();
                ObjUBO.A7 = ddlImp_Exp.SelectedValue.ToString();
                ObjUBO.A4 = ddltype.SelectedValue.ToString(); // Billno
                ObjUBO.A5 = txttype.Text; //cusname
                ObjUBO.A40 = "Pending_Job_Cnt";
                ds1 = BP.Select_Inv(ObjUBO, con_String);
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private string Get_Con_String()
    {
        string Con_wrk = string.Empty;
        try
        {
            DataSet ds = new DataSet();
            ObjUBO.A292 = ddl_Company_Id.SelectedValue.ToString();
            ObjUBO.A299 = ddlWorkingPeriod.SelectedValue.ToString();
            ObjUBO.A300 = "DB_Name_Select";
            ds = BP.Db_Connection(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Con_wrk = ds.Tables[0].Rows[0][1].ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Con_wrk;
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
                 table.SetWidths(new int[] { 10, 10, 20, 60 });

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
             Response.AddHeader("content-disposition", "attachment;" + "filename=PendingInvoice.pdf");
             Response.Cache.SetCacheability(HttpCacheability.NoCache);
             Response.Write(pdfDoc);
             Response.End();
         }

    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridbind();
    }
    protected void ddl_Company_Id_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridbind();
    }
    private void Company_Id()
    {
        ddl_Company_Id.Items.Clear();
        ddl_Company_Id.Items.Add(new System.Web.UI.WebControls.ListItem(Connection.Company_License().ToUpper(), Connection.Company_License().ToUpper()));
        ddlWorkingPeriod.Items.Clear();
        ddlWorkingPeriod.Items.Add(new System.Web.UI.WebControls.ListItem(Connection.WorkingPeriod(), Connection.WorkingPeriod()));
     
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void btnexcel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=PendingInvoice.xls");
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