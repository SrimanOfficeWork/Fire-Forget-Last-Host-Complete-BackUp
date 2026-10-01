using System;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Data;
using ClosedXML.Excel;

public partial class ACC_TDS_Payable : ThemeClass
{
    AppSession aps = new AppSession();
    //Acc_General_Reports AG = new Acc_General_Reports();
    Global_variables ObjUBO = new Global_variables();
    TDS_receivable_Payable td = new TDS_receivable_Payable();
    Acc_PurchaseBill_Entry_cs PC = new Acc_PurchaseBill_Entry_cs();
    DataTable Dt = new DataTable();
    private DataSet GridData
    {
        get { return ViewState["GridData"] as DataSet; }
        set { ViewState["GridData"] = value; }
    }
    private string SortExpression
    {
        get { return ViewState["SortExpression"] as string ?? string.Empty; }
        set { ViewState["SortExpression"] = value; }
    }
    private string SortDirection
    {
        get { return ViewState["SortDirection"] as string ?? string.Empty; }
        set { ViewState["SortDirection"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (Request.QueryString["Payable"] == "1")
        {
            string type = Convert.ToString(Request.QueryString["type"]);

            if (type == "Summary")
            {
                ExportSummaryToExcel();
            }
            else
            {
                ExportDetailToExcel();
            }
            return;
        }
        if (!IsPostBack)
        {

            Load_Organisation_Name();
            DateTime today = DateTime.Today;
            txtFromDate.Text = new DateTime(today.Year, today.Month, 1).ToString("dd/MM/yyyy");
            txtToDate.Text = new DateTime(today.Year, today.Month,
                DateTime.DaysInMonth(today.Year, today.Month)).ToString("dd/MM/yyyy");

            btnGenerate_Click(this, null);
        }
    }

    private void Load_Organisation_Name()
    {
        DataSet ds = new DataSet();
        ddl_org_name.Items.Clear();
        ObjUBO.A40 = "load_pc_Org_vendor_names";
        ds = PC.PC_Header_Select(ObjUBO);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddl_org_name.DataSource = ds.Tables[0];
            ddl_org_name.DataTextField = "OrgName";
            ddl_org_name.DataValueField = "OrgName";
            ddl_org_name.DataBind();
        }
        ddl_org_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_org_name.SelectedIndex = 0;
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.A2 = ddlLocation.SelectedValue;       // Location
            ObjUBO.A3 = txtFromDate.Text.Trim();         // From Date
            ObjUBO.A4 = txtToDate.Text.Trim();           // To Date

            ObjUBO.A5 = ddlOptions.SelectedValue;        // Status
            ObjUBO.A6 = ddlType.SelectedValue;           // Summary/Detail
            ObjUBO.A7 = ddlSectionCode.SelectedValue;    // Section Code

            ObjUBO.A8 = ddlBasis.SelectedValue;          // Org Type            
            ObjUBO.A1 = ddl_org_name.SelectedValue;      // Organization

            GridData = td.ACC_TDSPAYABLE_SELECT(ObjUBO);

            if (GridData != null && GridData.Tables.Count > 0 && GridData.Tables[0].Rows.Count > 0)
            {
                if (ddlType.SelectedValue == "Summary")
                {
                    Dt = GridData.Tables[0];
                    decimal totalTaxableAmount = 0;
                    decimal totalTDSAmount = 0;

                    foreach (DataRow dr in Dt.Rows)
                    {
                        totalTaxableAmount += Convert.ToDecimal(dr["TaxableAmountINR"]);
                        totalTDSAmount += Convert.ToDecimal(dr["TDSAmountINR"]);
                    }

                    ViewState["TotalTaxableAmount"] = totalTaxableAmount;
                    ViewState["TotalTDSAmount"] = totalTDSAmount;

                    gvSummary.Visible = true;
                    wrapSummary.Visible = true;

                    gvdetails.Visible = false;
                    wrapDetails.Visible = false;

                    gvSummary.DataSource = Dt;
                    gvSummary.DataBind();
                }
                else if (ddlType.SelectedValue == "Detail")
                {
                    Dt = GridData.Tables[0];
                    decimal totalTaxableAmount = 0;
                    decimal totalTDSAmount = 0;
                    decimal totalGST_AMOUNT = 0;
                    decimal totalVendorBillAmount = 0;

                    foreach (DataRow dr in Dt.Rows)
                    {
                        totalTaxableAmount += Convert.ToDecimal(dr["TAXABLE_AMOUNT"]);
                        totalTDSAmount += Convert.ToDecimal(dr["TDSAmount"]);
                        totalGST_AMOUNT += Convert.ToDecimal(dr["GST_AMOUNT"]);
                        totalVendorBillAmount += Convert.ToDecimal(dr["VendorBillAmount"]);
                    }
                    ViewState["TotalTaxableAmount"] = totalTaxableAmount;
                    ViewState["TotalTDSAmount"] = totalTDSAmount;
                    ViewState["TotalGST_AMOUNT"] = totalGST_AMOUNT;
                    ViewState["TotalVendorBillAmount"] = totalVendorBillAmount;

                    gvSummary.Visible = false;
                    wrapSummary.Visible = false;

                    gvdetails.Visible = true;
                    wrapDetails.Visible = true;

                    gvdetails.DataSource = Dt;
                    gvdetails.DataBind();
                }
                Session["ReportData"] = Dt;
            }
            else
            {
                gvSummary.Visible = false;
                gvdetails.Visible = false;

                gvSummary.DataSource = null;
                gvSummary.DataBind();

                gvdetails.DataSource = null;
                gvdetails.DataBind();
                Alert_msg("No Record Found");
            }
        }
        catch (Exception ex)
        {
            Alert_msg(ex.Message);
        }
    }

    protected void gvSummary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;   // Taxable Amount
            e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;   // TDS %
            e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;   // TDS Amount
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "TOTAL";
            e.Row.Cells[1].Font.Bold = true;

            e.Row.Cells[3].Text = Convert.ToDecimal(ViewState["TotalTaxableAmount"]).ToString("N2");
            e.Row.Cells[7].Text = Convert.ToDecimal(ViewState["TotalTDSAmount"]).ToString("N2");

            e.Row.Cells[3].Font.Bold = true;
            e.Row.Cells[7].Font.Bold = true;

            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
        }
    }

    protected void gvSummary_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.CssClass = "header";

            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;

            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                LinkButton SortLink = null;
                foreach (Control linkBtn in e.Row.Cells[i].Controls)
                {
                    if (linkBtn is LinkButton)
                    {
                        SortLink = (LinkButton)linkBtn;
                    }
                }
                if (SortLink != null && !string.IsNullOrEmpty(SortLink.CommandArgument))
                {
                    string Icon = "▲";
                    if (SortExpression == SortLink.CommandArgument)
                    {
                        Icon = (SortDirection == "ASC") ? "▲" : "▼";
                    }
                    SortLink.Text += "<span class='sort-icon'>" + Icon + "</span>";
                }
            }
        }
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Right;   // Vendor Bill Amount
            e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Right;  // Taxable Amount
            e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Right;  // Non Taxable / Exempt Amount
            e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Right;  // GST Amount
            e.Row.Cells[14].HorizontalAlign = HorizontalAlign.Right;  // TDS %
            e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Right;  // TDS Amount
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[2].Text = "TOTAL";
            e.Row.Cells[2].Font.Bold = true;

            e.Row.Cells[8].Text = Convert.ToDecimal(ViewState["TotalVendorBillAmount"]).ToString("N2");
            e.Row.Cells[9].Text = Convert.ToDecimal(ViewState["TotalTaxableAmount"]).ToString("N2");
            e.Row.Cells[11].Text = Convert.ToDecimal(ViewState["TotalGST_AMOUNT"]).ToString("N2");
            e.Row.Cells[14].Text = Convert.ToDecimal(ViewState["TotalTDSAmount"]).ToString("N2");

            e.Row.Cells[8].Font.Bold = true;
            e.Row.Cells[9].Font.Bold = true;
            e.Row.Cells[11].Font.Bold = true;
            e.Row.Cells[14].Font.Bold = true;

            e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[14].HorizontalAlign = HorizontalAlign.Right;
        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.CssClass = "header";

            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                LinkButton SortLink = null;
                foreach (Control linkBtn in e.Row.Cells[i].Controls)
                {
                    if (linkBtn is LinkButton)
                    {
                        SortLink = (LinkButton)linkBtn;
                    }
                }
                if (SortLink != null && !string.IsNullOrEmpty(SortLink.CommandArgument))
                {
                    string Icon = "▲";
                    if (SortExpression == SortLink.CommandArgument)
                    {
                        Icon = SortDirection == "ASC" ? "▲" : "▼";
                    }
                    SortLink.Text += "<span class='sort-icon'>"+Icon+"</span>";
                }
            }
        }
    }

    private void ExportSummaryToExcel()
    {
        DataTable dt = Session["ReportData"] as DataTable;

        if (dt == null || dt.Rows.Count == 0)
            return;

        decimal totalTaxable = 0;
        decimal totalTDS = 0;

        using (XLWorkbook wb = new XLWorkbook())
        {
            var ws = wb.Worksheets.Add("TDS Payable");

            // Header
            ws.Cell(1, 1).Value = "Organization / Deductee Name";
            ws.Cell(1, 2).Value = "Deductee TAN";
            ws.Cell(1, 3).Value = "Deductee PAN";
            ws.Cell(1, 4).Value = "Taxable Amount (INR)";
            ws.Cell(1, 5).Value = "TDS Code";
            ws.Cell(1, 6).Value = "TDS Section Code";
            ws.Cell(1, 7).Value = "TDS %";
            ws.Cell(1, 8).Value = "TDS Amount (INR)";

            var header = ws.Range(1, 1, 1, 8);
            header.Style.Fill.BackgroundColor = XLColor.Blue;
            header.Style.Font.FontColor = XLColor.White;
            header.Style.Font.Bold = true;

            int row = 2;

            foreach (DataRow dr in dt.Rows)
            {
                ws.Cell(row, 1).Value = dr["OrganizationDeducteeName"].ToString();
                ws.Cell(row, 2).Value = dr["DeducteeTAN"].ToString();
                ws.Cell(row, 3).Value = dr["DeducteePAN"].ToString();
                ws.Cell(row, 4).Value = Convert.ToDecimal(dr["TaxableAmountINR"]);
                ws.Cell(row, 5).Value = dr["TDSCode"].ToString();
                ws.Cell(row, 6).Value = dr["TDSSectionCode"].ToString();
                ws.Cell(row, 7).Value = dr["TDSPercent"].ToString();
                ws.Cell(row, 8).Value = Convert.ToDecimal(dr["TDSAmountINR"]);

                totalTaxable += Convert.ToDecimal(dr["TaxableAmountINR"]);
                totalTDS += Convert.ToDecimal(dr["TDSAmountINR"]);

                row++;
            }

            // Total Row
            ws.Cell(row, 1).Value = "TOTAL";
            ws.Cell(row, 4).Value = totalTaxable;
            ws.Cell(row, 8).Value = totalTDS;

            ws.Range(row, 1, row, 8).Style.Font.Bold = true;
            ws.Range(row, 1, row, 8).Style.Fill.BackgroundColor = XLColor.LightGreen;

            // Number Formats
            ws.Column(4).Style.NumberFormat.Format = "#,##0.00";
            ws.Column(7).Style.NumberFormat.Format = "0.###";
            ws.Column(8).Style.NumberFormat.Format = "#,##0.00";

            ws.Columns().AdjustToContents();

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=TDSPayable.xlsx");

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                wb.SaveAs(ms);
                ms.WriteTo(Response.OutputStream);
            }

            Response.Flush();
            Response.End();
        }
    }


    private void ExportDetailToExcel()
    {
        DataTable dt = Session["ReportData"] as DataTable;

        if (dt == null || dt.Rows.Count == 0)
            return;

        decimal totalTaxable = 0;
        decimal totalTDS = 0;

        using (XLWorkbook wb = new XLWorkbook())
        {
            var ws = wb.Worksheets.Add("TDS Payable");

            // Headers
            ws.Cell(1, 1).Value = "Entry Date";
            ws.Cell(1, 2).Value = "Organization / Deductee Name";
            ws.Cell(1, 3).Value = "Org Type";
            ws.Cell(1, 4).Value = "Transaction No";
            ws.Cell(1, 5).Value = "Deductee TAN";
            ws.Cell(1, 6).Value = "Deductee PAN";
            ws.Cell(1, 7).Value = "Vendor Ref No.";
            ws.Cell(1, 8).Value = "Vendor Ref Date";
            ws.Cell(1, 9).Value = "Vendor Bill Amount (INR)";
            ws.Cell(1, 10).Value = "Taxable Amount (INR)";
            ws.Cell(1, 11).Value = "Non Taxable / Exempt Amount (INR)";
            ws.Cell(1, 12).Value = "GST Amount (INR)";
            ws.Cell(1, 13).Value = "TDS Section Code";
            ws.Cell(1, 14).Value = "TDS %";
            ws.Cell(1, 15).Value = "TDS Amount (INR)";

            var header = ws.Range(1, 1, 1, 15);
            header.Style.Fill.BackgroundColor = XLColor.Blue;
            header.Style.Font.FontColor = XLColor.White;
            header.Style.Font.Bold = true;

            int row = 2;

            foreach (DataRow dr in dt.Rows)
            {
                ws.Cell(row, 1).Value = dr["EntryDate"].ToString();
                ws.Cell(row, 2).Value = dr["OrganizationDeducteeName"].ToString();
                ws.Cell(row, 3).Value = dr["OrgType"].ToString();
                ws.Cell(row, 4).Value = dr["TRANS_NO"].ToString();
                ws.Cell(row, 5).Value = dr["DeducteeTAN"].ToString();
                ws.Cell(row, 6).Value = dr["DeducteePAN"].ToString();
                ws.Cell(row, 7).Value = dr["VENDOR_REF_NO"].ToString();
                ws.Cell(row, 8).Value = dr["VENDOR_REF_DATE"].ToString();
                ws.Cell(row, 9).Value = Convert.ToDecimal(dr["VendorBillAmount"]);
                ws.Cell(row, 10).Value = Convert.ToDecimal(dr["TAXABLE_AMOUNT"]);
                ws.Cell(row, 11).Value = Convert.ToDecimal(dr["NON_TAXABLE_EXEMPT_AMOUNT"]);
                ws.Cell(row, 12).Value = Convert.ToDecimal(dr["GST_AMOUNT"]);
                ws.Cell(row, 13).Value = dr["TDSSectionCode"].ToString();
                ws.Cell(row, 14).Value = dr["TDSPercent"];
                ws.Cell(row, 15).Value = Convert.ToDecimal(dr["TDSAmount"]);

                totalTaxable += Convert.ToDecimal(dr["TAXABLE_AMOUNT"]);
                totalTDS += Convert.ToDecimal(dr["TDSAmount"]);

                row++;
            }

            // Total Row
            ws.Cell(row, 2).Value = "TOTAL";
            ws.Cell(row, 10).Value = totalTaxable;
            ws.Cell(row, 15).Value = totalTDS;

            ws.Range(row, 1, row, 15).Style.Fill.BackgroundColor = XLColor.LightGreen;
            ws.Range(row, 1, row, 15).Style.Font.Bold = true;

            // Number formats
            ws.Column(9).Style.NumberFormat.Format = "#,##0.00";
            ws.Column(10).Style.NumberFormat.Format = "#,##0.00";
            ws.Column(11).Style.NumberFormat.Format = "#,##0.00";
            ws.Column(12).Style.NumberFormat.Format = "#,##0.00";
            ws.Column(14).Style.NumberFormat.Format = "0.##";
            ws.Column(15).Style.NumberFormat.Format = "#,##0.00";

            ws.Columns().AdjustToContents();

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=TDSPayable.xlsx");

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                wb.SaveAs(ms);
                ms.WriteTo(Response.OutputStream);
            }

            Response.Flush();
            Response.End();
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void gvSummary_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (GridData == null)
        {
            return;
        }
        if (e.SortExpression == SortExpression)
        {
            SortDirection = SortDirection == "ASC" ? "DESC" : "ASC";
        }
        else
        {
            SortDirection = "ASC";
        }
        SortExpression = e.SortExpression;

        GridData.Tables[0].DefaultView.Sort = e.SortExpression + " " + SortDirection;
        gvSummary.DataSource = GridData.Tables[0].DefaultView;
        gvSummary.DataBind();
    }
    protected void gvdetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (GridData == null)
        {
            return;
        }
        if (e.SortExpression == SortExpression)
        {
            SortDirection = SortDirection == "ASC" ? "DESC" : "ASC";
        }
        else
        {
            SortDirection = "ASC";
        }
        SortExpression = e.SortExpression;
        GridData.Tables[0].DefaultView.Sort = e.SortExpression + " " + SortDirection;
        gvdetails.DataSource = GridData.Tables[0].DefaultView;
        gvdetails.DataBind();
    }

}