using System;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Data;
using ClosedXML.Excel;
using System.IO;

public partial class ACC_AccountReceivable : ThemeClass
{
    AppSession aps = new AppSession();
    Acc_General_Reports AG = new Acc_General_Reports();
    Global_variables ObjUBO = new Global_variables();
    Acc_PurchaseBill_Entry_cs PC = new Acc_PurchaseBill_Entry_cs();
    DataTable Dt = new DataTable();
    private DataSet GridData
    {
        get { return ViewState["GridData"] as DataSet; }
        set { ViewState["GridData"] = value; }
    }

    private string SortDirection
    {
        get { return Convert.ToString(ViewState["SortDirection"]) ?? "ASC"; }
        set { ViewState["SortDirection"] = value; }
    }
    private string SortExpression
    {
        get { return ViewState["SortExpression"] as string ?? string.Empty; }
        set { ViewState["SortExpression"] = value; }
    }
    private string ActiveGridType
    {
        get { return ViewState["ActiveGridType"] as string ?? "Summary"; }
        set { ViewState["ActiveGridType"] = value; }
    }
    private int currentPageNumber;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (Request.QueryString["Receivable"] == "1")
        {
            string type = Convert.ToString(Request.QueryString["type"]);
            if (type == "Summary")
            {
                ExportToExcel();
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
            txtAsOnDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            chkINRValues.Checked = true;
            btnGenerate_Click(this, null);
        }
    }

    private void Load_Organisation_Name()
    {
        DataSet ds = new DataSet();
        ddl_org_name.Items.Clear();
        ObjUBO.A10 = "Load_CusName";
        ds = AG.ACC_GST_BILL_ACCOUNTS_RECEIVABLE_SEARCH_SELECT(ObjUBO);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            ddl_org_name.DataSource = ds.Tables[0];
            ddl_org_name.DataTextField = "CUS_NAME";
            ddl_org_name.DataValueField = "CUS_NAME";
            ddl_org_name.DataBind();
        }
        ddl_org_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_org_name.SelectedIndex = 0;
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        ActiveGridType = ddlType.SelectedValue;
        pnlSummaryGrid.Visible = (ActiveGridType == "Summary");
        pnlDetailGrid.Visible = (ActiveGridType == "Detail");

        int pageno = 1;
        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii, currentPageNumber);
    }
    private void gridbind(int currentnumber1)
    {
        try
        {
            Global_variables obj = new Global_variables();

            obj.A1 = ddl_org_name.SelectedValue;
            obj.A2 = "0";
            obj.A4 = ddl_DateBasis.SelectedItem.Text;
            obj.A6 = Convert.ToString(currentnumber1);
            obj.A7 = (ddlType.SelectedValue.ToString() == "Summary") ? Convert.ToString(gvdetails.PageSize) : Convert.ToString(gvdetailsDetail.PageSize);
            obj.A10 = "Load_Report";
            obj.A20 = ddlType.SelectedValue.ToString();
            DateTime dt = DateTime.ParseExact(txtAsOnDate.Text, "dd/MM/yyyy", null);
            obj.A5 = dt.ToString("yyyy-MM-dd");
            GridData = AG.ACC_GST_BILL_ACCOUNTS_RECEIVABLE_SEARCH_SELECT(obj);

            if (GridData != null && GridData.Tables.Count > 0 && GridData.Tables[0].Rows.Count > 0)
            {
                Dt = GridData.Tables[0];
                decimal totalOutstanding = 0;
                decimal totalOnAccount = 0;
                decimal totalNet = 0;

                if (ActiveGridType == "Detail")
                {
                    decimal totalBillAmount = 0;
                    decimal totalReceivedSettled = 0;
                    decimal totalOutstandingDetail = 0;

                   // Response.Write("Row Count = " + Dt.Rows.Count);
                    foreach (DataRow dr in Dt.Rows)
                    {
                       

                        if (dr["Transaction No"] != DBNull.Value && dr["Transaction No"].ToString().Trim().Equals("TOTAL", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }
                        if (dr["Bill Amount (INR)"] != DBNull.Value &&
                            !string.IsNullOrWhiteSpace(dr["Bill Amount (INR)"].ToString()))
                        {
                            totalBillAmount += Convert.ToDecimal(dr["Bill Amount (INR)"]);
                          
                        }

                        if (dr["Received/Settled (INR)"] != DBNull.Value &&
                            !string.IsNullOrWhiteSpace(dr["Received/Settled (INR)"].ToString()))
                        {
                            totalReceivedSettled += Convert.ToDecimal(dr["Received/Settled (INR)"]);
                           
                        }

                        if (dr["Outstanding (INR)"] != DBNull.Value &&
                            !string.IsNullOrWhiteSpace(dr["Outstanding (INR)"].ToString()))
                        {
                            totalOutstandingDetail += Convert.ToDecimal(dr["Outstanding (INR)"]);
                          
                        }
                     
                    }
                    ViewState["TotalBillAmount"] = totalBillAmount;
                    ViewState["TotalReceiveddSettled"] = totalReceivedSettled;
                    ViewState["TotalOutstandingDetail"] = totalOutstandingDetail;

                    gvdetailsDetail.DataSource = Dt;
                    gvdetailsDetail.DataBind();
                }
                else if (ActiveGridType == "Summary")
                {
                    foreach (DataRow dr in Dt.Rows)
                    {
                        totalOutstanding += Convert.ToDecimal(dr["OUTSTANDING"]);
                        totalOnAccount += Convert.ToDecimal(dr["ON_ACCOUNT"]);
                        totalNet += Convert.ToDecimal(dr["NET_OUTSTANDING"]);
                    }
                    ViewState["TotalOutstanding"] = totalOutstanding;
                    ViewState["TotalOnAccount"] = totalOnAccount;
                    ViewState["TotalNet"] = totalNet;

                    gvdetails.DataSource = Dt;
                    gvdetails.DataBind();

                    Session["ReportData"] = Dt;
                }

            }
            else
            {
                gvdetails.DataSource = null;
                gvdetails.DataBind();
                Alert_msg("No Record Found");
            }
            Grid_Total(currentnumber1, Convert.ToDouble(obj.A11));
        }
        catch (Exception ex)
        {
            Alert_msg(ex.Message);
        }
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
    public void Add_Pageno(int p, int currentPage)
    {
        if (p != 0)
        {
            ddlSelectPageno.Items.Clear();
            for (int i = 1; i <= p; i++)
            {
                ddlSelectPageno.Items.Add(Convert.ToString(i));
            }
            if (currentPage >= 1 && currentPage <= p)
            {
                ddlSelectPageno.SelectedValue = currentPage.ToString();
            }
        }
    }
    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSelectPageno.SelectedValue != "")
        {
            int selectedpageNo = Int32.Parse(ddlSelectPageno.SelectedValue);
            gridbind(selectedpageNo);
        }
    }
    private int CalculateTotalPages(double totalRows)
    {
        double PageSize = ddlType.SelectedValue.ToString() == "Summary" ? gvdetails.PageSize : gvdetailsDetail.PageSize;
        int totalPages = (int)Math.Ceiling(totalRows / PageSize);
        return totalPages;
    }
    public void Grid_Total(int currentPageNumber1, double totalRows)
    {
        int activeRowCount = (ActiveGridType == "Detail") ? gvdetailsDetail.Rows.Count : gvdetails.Rows.Count;

        Div_Pagination.Visible = activeRowCount > 0;

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
            btnNext.Visible = true;

        }

        Add_Pageno(ii, currentPageNumber1);
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "TOTAL";
            e.Row.Cells[0].Font.Bold = true;

            e.Row.Cells[1].Text = Convert.ToDecimal(ViewState["TotalOutstanding"]).ToString("N2");
            e.Row.Cells[2].Text = Convert.ToDecimal(ViewState["TotalOnAccount"]).ToString("N2");
            e.Row.Cells[3].Text = Convert.ToDecimal(ViewState["TotalNet"]).ToString("N2");

            e.Row.Cells[1].Font.Bold = true;
            e.Row.Cells[2].Font.Bold = true;
            e.Row.Cells[3].Font.Bold = true;

            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;

            e.Row.BackColor = System.Drawing.Color.LightGreen;
        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.CssClass = "header";

            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                LinkButton SortLink = null;
                foreach (Control control in e.Row.Cells[i].Controls)
                {
                    if (control is LinkButton)
                    {
                        SortLink = (LinkButton)control;
                    }
                }
                if (SortLink != null && !string.IsNullOrEmpty(SortLink.CommandArgument))
                {
                    string icon = "▲";
                    if (SortExpression == SortLink.CommandArgument)
                    {
                        icon = SortDirection == "ASC" ? "▲" : "▼";
                    }
                    SortLink.Text += "<span class='sort-icon'>" + icon + "</span>";
                }

            }
        }
    }

    private void ExportToExcel()
    {
        DataTable dt = Session["ReportData"] as DataTable;

        if (dt == null || dt.Rows.Count == 0)
            return;

        // ===== TOTAL =====
        decimal totalOutstanding = 0;
        decimal totalOnAccount = 0;
        decimal totalNet = 0;

        foreach (DataRow dr in dt.Rows)
        {
            totalOutstanding += Convert.ToDecimal(dr["OUTSTANDING"]);
            totalOnAccount += Convert.ToDecimal(dr["ON_ACCOUNT"]);
            totalNet += Convert.ToDecimal(dr["NET_OUTSTANDING"]);
        }

        DataRow totalRow = dt.NewRow();
        totalRow["ORGANIZATION_NAME"] = "TOTAL";
        totalRow["OUTSTANDING"] = totalOutstanding;
        totalRow["ON_ACCOUNT"] = totalOnAccount;
        totalRow["NET_OUTSTANDING"] = totalNet;
        dt.Rows.Add(totalRow);

        using (XLWorkbook wb = new XLWorkbook())
        {
            var ws = wb.Worksheets.Add("Accounts Receivable");

            ws.Cell(1, 1).InsertTable(dt);

            var header = ws.Row(1);
            header.Style.Fill.BackgroundColor = XLColor.Blue;
            header.Style.Font.FontColor = XLColor.White;
            header.Style.Font.Bold = true;

            int lastRow = dt.Rows.Count + 1;
            var total = ws.Row(lastRow);
            total.Style.Fill.BackgroundColor = XLColor.LightGreen;
            total.Style.Font.Bold = true;

            ws.Columns().AdjustToContents();

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=AccountsReceivable.xlsx");

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
    protected void gvdetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (GridData == null)
        { return; }

        if (SortExpression == e.SortExpression)
        {
            SortDirection = (SortDirection == "ASC") ? "DESC" : "ASC";
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
    protected void gvdetailsDetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.CssClass = "header";
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                LinkButton SortLink = null;

                foreach (Control control in e.Row.Cells[i].Controls)
                {
                    if (control is LinkButton)
                    {
                        SortLink = (LinkButton)control;
                        break;
                    }
                }

                if (SortLink != null &&
                    !string.IsNullOrEmpty(SortLink.CommandArgument))
                {
                    string icon = "▲";

                    if (SortExpression == SortLink.CommandArgument)
                    {
                        icon = (SortDirection == "ASC") ? "▲" : "▼";
                    }

                    SortLink.Text += "<span class='sort-icon'>" + icon + "</span>";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.CssClass = "gridFooterRow";
        }
    }
    protected void gvdetailsDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drv = e.Row.DataItem as DataRowView;
        bool isSubtotal = drv != null
            && drv.Row.Table.Columns.Contains("Trans. Date")
            && (drv["Trans. Date"] == DBNull.Value || string.IsNullOrEmpty(drv["Trans. Date"].ToString()));

        if (isSubtotal)
        {
            System.Drawing.Color green = System.Drawing.ColorTranslator.FromHtml("#C6EFCE"); // soft green, like your screenshot's orange band

            e.Row.BackColor = green;
            e.Row.Font.Bold = true;

            // force every cell individually so alternating-row / cell styles can't override it
            foreach (TableCell cell in e.Row.Cells)
            {
                cell.BackColor = green;
            }
            e.Row.Cells[1].Text = "";
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNarration = (Label)e.Row.FindControl("lblreferenceNo");
            string Narattion = DataBinder.Eval(e.Row.DataItem, "Reference No").ToString();
            lblNarration.ToolTip = Narattion;
            if (Narattion.Length > 50)
            {
                lblNarration.Text = Narattion.Substring(0, 50) + "...";
            }
            else
            {
                lblNarration.Text = Narattion;
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[3].Text = "Total";
            e.Row.Cells[3].Font.Bold = true;

            e.Row.Cells[4].Text = Convert.ToString(ViewState["TotalBillAmount"]);
            e.Row.Cells[4].Font.Bold = true;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;

            e.Row.Cells[5].Text = Convert.ToString(ViewState["TotalReceiveddSettled"]);
            e.Row.Cells[5].Font.Bold = true;
            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;

            e.Row.Cells[6].Text = Convert.ToString(ViewState["TotalOutstandingDetail"]);
            e.Row.Cells[6].Font.Bold = true;
            e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            e.Row.BackColor = System.Drawing.Color.LightGreen;
        }
    }

    protected void ExportDetailToExcel()
    {
        try
        {
            Global_variables obj = new Global_variables();

            obj.A1 = (Request.QueryString["Organization"]).ToString().Trim();
            obj.A2 = "0";
            obj.A4 = (Request.QueryString["DateBasis"]).ToString().Trim();
            if (obj.A4 == "BillDate")
            {
                obj.A4 = "Bill Date";
            }
            else if (obj.A4 == "DueDate")
            {
                obj.A4 = "Due Date";
            }

            DateTime dtt = Convert.ToDateTime(Request.QueryString["AsOnDate"]);
            obj.A5 = dtt.ToString("yyyy-MM-dd");

            obj.A6 = "1";               //startrow
            obj.A7 = "1000000";    //maximun row

            obj.A10 = "Load_Report";
            obj.A20 = Request.QueryString["type"].ToString();
            GridData = AG.ACC_GST_BILL_ACCOUNTS_RECEIVABLE_SEARCH_SELECT(obj);

            if (GridData == null || GridData.Tables.Count == 0)
            {
                return;
            }

            DataTable dt = GridData.Tables[0];

            using (XLWorkbook workbook = new XLWorkbook())
            {
                IXLWorksheet ws = workbook.Worksheets.Add("Accounts Receivable Detail");

                // Excel column headers
                string[] headers =
            {
                "Organization", "Trans. Date","Transaction No", "Ref No", "Bill Amount (INR)",
                "Received/Settled (INR)", "Outstanding (INR)", "Reference No", "Due Days",
                "OverDue Days", "Ageing Days"
            };

                // Header row
                for (int i = 0; i < headers.Length; i++)
                {
                    ws.Cell(1, i + 1).Value = headers[i];
                    ws.Cell(1, i + 1).Style.Font.Bold = true;
                    ws.Cell(1, i + 1).Style.Alignment.Horizontal =
                        XLAlignmentHorizontalValues.Center;
                }

                int excelRow = 2;

                decimal totalBillAmount = 0;
                decimal totalReceivedSettled = 0;
                decimal totalOutstanding = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    string transactionNo = Convert.ToString(dr["Transaction No"]).Trim();
                    bool isSubtotal = transactionNo.Equals("TOTAL", StringComparison.OrdinalIgnoreCase);

                    // Organization
                    if (isSubtotal)
                    {
                        // Do not show organization name for subtotal row
                        ws.Cell(excelRow, 1).Value = "";
                    }
                    else
                    {
                        ws.Cell(excelRow, 1).Value = Convert.ToString(dr["Organization"]);
                    }
                    // Trans. Date
                    ws.Cell(excelRow, 2).Value = Convert.ToString(dr["Trans. Date"]);

                    // Transaction No
                    ws.Cell(excelRow, 3).Value = transactionNo;
                    ws.Cell(excelRow, 4).Value = Convert.ToString(dr["Ref No"]);

                    // Bill Amount
                    decimal billAmount = 0;
                    decimal.TryParse(
                        Convert.ToString(dr["Bill Amount (INR)"]), out billAmount);

                    ws.Cell(excelRow, 5).Value = billAmount;
                    ws.Cell(excelRow, 5).Style.NumberFormat.Format = "#,##0.00";

                    // Paid / Settled
                    decimal receivedSettled = 0;
                    decimal.TryParse(Convert.ToString(dr["Received/Settled (INR)"]), out receivedSettled);

                    ws.Cell(excelRow, 6).Value = receivedSettled;
                    ws.Cell(excelRow, 6).Style.NumberFormat.Format = "#,##0.00";

                    // Outstanding
                    decimal outstanding = 0;
                    decimal.TryParse(Convert.ToString(dr["Outstanding (INR)"]), out outstanding);

                    ws.Cell(excelRow, 7).Value = outstanding;
                    ws.Cell(excelRow, 7).Style.NumberFormat.Format = "#,##0.00";

                    ws.Cell(excelRow, 8).Value = Convert.ToString(dr["Reference No"]);

                    ws.Cell(excelRow, 9).Value = Convert.ToString(dr["Due Days"]);
                    ws.Cell(excelRow, 10).Value = Convert.ToString(dr["OverDue Days"]);
                    ws.Cell(excelRow, 11).Value = Convert.ToString(dr["Ageing Days"]);

                    if (!isSubtotal)
                    {
                        totalBillAmount += billAmount;
                        totalReceivedSettled += receivedSettled;
                        totalOutstanding += outstanding;
                    }

                    if (isSubtotal)
                    {
                        ws.Range(excelRow, 1, excelRow, 11).Style.Fill.SetBackgroundColor(XLColor.LightGray);

                        ws.Range(excelRow, 1, excelRow, 11).Style.Font.Bold = true;
                    }
                    excelRow++;
                }


                // Right align numeric columns
                ws.Range(2, 5, excelRow - 1, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                // Header styling
                ws.Range(1, 1, 1, 11).Style.Font.Bold = true;

                // Auto fit
                ws.Columns().AdjustToContents();

                // Keep reasonable widths
                if (ws.Column(1).Width > 35)
                    ws.Column(1).Width = 35;

                if (ws.Column(4).Width > 25)
                    ws.Column(4).Width = 25;

                // Download
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                Response.AddHeader("content-disposition", "attachment;filename=Accounts_Receivable_Detail.xlsx");

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);

                    memoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(
                "ExportDetailToExcel Error: " + ex.Message);
        }
    }
}