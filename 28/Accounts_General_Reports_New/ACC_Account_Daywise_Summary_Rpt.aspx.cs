using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web.UI;
using BussinessObject;
using iTextSharp.text;
using iTextSharp.text.pdf;


public partial class Accounts_General_Reports_New_ACC_Account_Daywise_Summary_Rpt : ThemeClass
{
    Global_variables ObjUBO = new Global_variables();
    Acc_General_Reports AG = new Acc_General_Reports();
    private static readonly CultureInfo IndianCulture = new CultureInfo("en-IN");

   
    private DataTable _bankTable;

    protected void Page_Load(object sender, EventArgs e)
    {
       
        BindReport();
    }

    private void BindReport()
    {
        try
        {
            ObjUBO.A1 = "S";

            DataSet ds = AG.Acc_GST_Account_Summary_Report_Daywise(ObjUBO);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                litTitle.Text = GetTitleText(row, "COMPANY_NAME");
                lblSales.Text = FormatAmount(row, "Sales");
                lblPurchase.Text = FormatAmount(row, "Purchase");
                lblReceipts.Text = FormatAmountOrDash(row, "Receipts");
                lblPayments.Text = FormatAmount(row, "Payments");
                lblOnAccount.Text = FormatAmount(row, "OnAccount");
                lblUnbilledValue.Text = FormatAmount(row, "UnbilledValue");
            }
            if (ds != null && ds.Tables.Count > 1)
            {
                _bankTable = ds.Tables[1];

                rptBanks.DataSource = _bankTable;
                rptBanks.DataBind();

                decimal total = 0m;
                if (_bankTable.Columns.Contains("Bal_Amt"))
                {
                    foreach (DataRow bankRow in _bankTable.Rows)
                    {
                        if (bankRow["Bal_Amt"] != DBNull.Value)
                        {
                            total += Convert.ToDecimal(bankRow["Bal_Amt"]);
                        }
                    }
                }

                lblAvailableBalance.Text = total.ToString("N2", IndianCulture);
            }
            else
            {
                _bankTable = new DataTable();
                lblAvailableBalance.Text = "0.00";
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    private string GetTitleText(DataRow row, string columnName)
    {
        if (!row.Table.Columns.Contains(columnName) || row[columnName] == DBNull.Value)
        {
            return string.Empty;
        }

        return Convert.ToString(row[columnName]);
    }

    private string FormatAmount(DataRow row, string columnName)
    {
        if (!row.Table.Columns.Contains(columnName) || row[columnName] == DBNull.Value)
        {
            return "0.00";
        }

        decimal amount = Convert.ToDecimal(row[columnName]);
        return amount.ToString("N2", IndianCulture);
    }


    private string FormatAmountOrDash(DataRow row, string columnName)
    {
        if (!row.Table.Columns.Contains(columnName) || row[columnName] == DBNull.Value)
        {
            return "-";
        }

        decimal amount = Convert.ToDecimal(row[columnName]);
        if (amount == 0)
        {
            return "-";
        }

        return amount.ToString("N2", IndianCulture);
    }

    protected string FormatBankAmount(object rawValue)
    {
        if (rawValue == null || rawValue == DBNull.Value)
        {
            return "0.00";
        }

        decimal amount = Convert.ToDecimal(rawValue);
        return amount.ToString("N2", IndianCulture);
    }


    protected void btnDownloadExcel_Click(object sender, EventArgs e)
    {
        string html = RenderPanelToHtml(pnlReport);

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
            "attachment;filename=Account_Daywise_Summary_" + DateTime.Now.ToString("ddMMyyyy") + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        Response.Output.Write(html);
        Response.Flush();
        Response.End();
    }


    protected void btnDownloadPdf_Click(object sender, EventArgs e)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            Document doc = new Document(PageSize.A5, 20, 20, 20, 20);
            PdfWriter.GetInstance(doc, ms);
            doc.Open();

            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13);
            Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
            Font valueFont = FontFactory.GetFont(FontFactory.HELVETICA, 11);

            Paragraph title = new Paragraph(litTitle.Text, titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 10f;
            doc.Add(title);

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;

            // Fixed rows: Sales/Purchase, Receipts/Payments, On Account/Unbilled Value
            foreach (ReportRow rr in GetReportRows())
            {
                AddCell(table, rr.LeftHeader, headerFont, 1);
                AddCell(table, rr.RightHeader, headerFont, 1);
                AddCell(table, rr.LeftValue, valueFont, 1);
                AddCell(table, rr.RightValue, valueFont, 1);

                if (rr.SpacerAfter)
                {
                    AddSpacerRow(table);
                }
            }

            // Dynamic bank rows: header once, then one row per bank returned by the SP
            AddCell(table, "Bank", headerFont, 1);
            AddCell(table, "OD Balance", headerFont, 1);

            if (_bankTable != null)
            {
                foreach (DataRow bankRow in _bankTable.Rows)
                {
                    string bankLabel = bankRow.Table.Columns.Contains("BANK_NAME") ? Convert.ToString(bankRow["BANK_NAME"]) : "";
                    string acctNo = bankRow.Table.Columns.Contains("ACCOUNT_NUMBER") ? Convert.ToString(bankRow["ACCOUNT_NUMBER"]) : "";
                    string balance = FormatBankAmount(bankRow.Table.Columns.Contains("Bal_Amt") ? bankRow["Bal_Amt"] : null);

                    AddCell(table, bankLabel + " (" + acctNo + ")", valueFont, 1);
                    AddCell(table, balance, valueFont, 1);
                }
            }

            // Total Available Balance (full width)
            AddCell(table, "Total Available Balance", headerFont, 2);
            AddCell(table, lblAvailableBalance.Text, valueFont, 2);

            doc.Add(table);
            doc.Close();

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition",
                "attachment;filename=Account_Daywise_Summary_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf");
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }
    }

 
    private List<ReportRow> GetReportRows()
    {
        return new List<ReportRow>
        {

            new ReportRow("Sales", lblSales.Text, "Purchase", lblPurchase.Text, spacerAfter: true),
            new ReportRow("Receipts", lblReceipts.Text, "Payments", lblPayments.Text, spacerAfter: true),
            new ReportRow("On Account", lblOnAccount.Text, "Unbilled Value", lblUnbilledValue.Text, spacerAfter: true)
        };
    }

    private void AddCell(PdfPTable table, string text, Font font, int colspan)
    {
        PdfPCell cell = new PdfPCell(new Phrase(text, font));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Colspan = colspan;
        table.AddCell(cell);
    }

    private void AddSpacerRow(PdfPTable table)
    {
        PdfPCell blank = new PdfPCell(new Phrase(" "));
        blank.Colspan = 2;
        blank.Border = Rectangle.NO_BORDER;
        blank.FixedHeight = 8f;
        table.AddCell(blank);
    }

    private class ReportRow
    {
        public string LeftHeader;
        public string LeftValue;
        public string RightHeader;
        public string RightValue;
        public bool SpacerAfter;

        public ReportRow(string leftHeader, string leftValue, string rightHeader, string rightValue, bool spacerAfter)
        {
            LeftHeader = leftHeader;
            LeftValue = leftValue;
            RightHeader = rightHeader;
            RightValue = rightValue;
            SpacerAfter = spacerAfter;
        }
    }


    private string RenderPanelToHtml(Control control)
    {
        StringBuilder sb = new StringBuilder();
        using (StringWriter sw = new StringWriter(sb))
        using (HtmlTextWriter htw = new HtmlTextWriter(sw))
        {
            SetButtonsVisible(false);
            control.RenderControl(htw);
            SetButtonsVisible(true);
        }
        return sb.ToString();
    }

    private void SetButtonsVisible(bool visible)
    {
        btnDownloadExcel.Visible = visible;
        btnDownloadPdf.Visible = visible;
    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        // intentionally left blank
    }
}
