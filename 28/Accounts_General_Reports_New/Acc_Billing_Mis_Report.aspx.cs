using System;
using System.Data;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Web.UI;
using System.Globalization;

public partial class GSTMonthwiseReport : ThemeClass
{
    private const string LocationColumn = "Label";
    private const string TotalColumn = "Total";
    private const string TotalRowLabel = "Total";
    billing_Mis objReport = new billing_Mis();
    Global_variables objUserBL = new Global_variables();
    string[] arr_Month = new string[] { };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_Group_Name();
            Load_Month();
            load_Cus_name();
            btnSearch_Click(this, null);
        }
    }
    private void load_Cus_name()
    {
        try
        {
            ddl_Cus_Name.Items.Clear();
            DataSet dss = new DataSet();
            objUserBL.A5 = "Load_CusName";
            dss = objReport.GetMonthWiseReport(objUserBL);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddl_Cus_Name.DataSource = dss.Tables[0];
                ddl_Cus_Name.DataTextField = "Cus_Name";
                ddl_Cus_Name.DataValueField = "Cus_Name";
                ddl_Cus_Name.DataBind();
            }
            ddl_Cus_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Cus_Name.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;
        BindGrid(chkExcludeTax.Checked);
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;

        chkExcludeTax.Checked = false;

    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        objUserBL.A1 = txtfromdate.Text;
        objUserBL.A2 = txttodate.Text;
        objUserBL.A3 = chkExcludeTax.Checked ? "1" : "0";
        objUserBL.A4 = ddl_Cus_Name.SelectedValue;
        objUserBL.A5 = "load_Grid";
        DataTable pivotTable = objReport.GetMonthWisePivotReport(objUserBL);

        if (pivotTable == null || pivotTable.Rows.Count == 0)
        {
            lblMessage.Text = "No data available to export.";
            return;
        }

        string fileName = "MonthwiseGSTReport_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xls";
        ExportDataTableToExcel(pivotTable, fileName);

    }
    private void ExportDataTableToExcel(DataTable dt, string fileName)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
        Response.ContentType = "application/vnd.ms-excel";
        Response.Charset = "";

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.Append("<html><head><meta charset='utf-8' /><style>");
        sb.Append("table { border-collapse: collapse; font-family: Arial, sans-serif; font-size: 11px; } ");
        sb.Append("th { background-color: #808080; color: #ffffff; font-weight: bold; padding: 4px 8px; border: 1px solid #999999; } ");
        sb.Append("td { padding: 4px 8px; border: 1px solid #cccccc; } ");
        sb.Append(".amount-cell { text-align: right; mso-number-format:'#,##0.00'; } ");
        sb.Append(".total-row td { font-weight: bold; background-color: #e9edf3; }");
        sb.Append("</style></head><body><table>");

        // ---- Header row ----
        sb.Append("<tr><th>S.No</th>");
        foreach (DataColumn col in dt.Columns)
        {
            sb.Append("<th>").Append(Server.HtmlEncode(col.ColumnName)).Append("</th>");
        }
        sb.Append("</tr>");

        // ---- Data rows ----
        int serial = 1;
        foreach (DataRow row in dt.Rows)
        {
            bool isTotalRow = string.Equals(Convert.ToString(row[0]), "Total", StringComparison.OrdinalIgnoreCase);

            sb.Append(isTotalRow ? "<tr class='total-row'>" : "<tr>");
            sb.Append("<td>").Append(isTotalRow ? "" : serial.ToString()).Append("</td>");

            foreach (DataColumn col in dt.Columns)
            {
                object val = row[col];
                bool isAmountColumn = col.DataType == typeof(decimal) || col.DataType == typeof(double);

                string display = isAmountColumn
                    ? Convert.ToDecimal(val).ToString("N2", CultureInfo.InvariantCulture)
                    : Convert.ToString(val);

                sb.Append(isAmountColumn ? "<td class='amount-cell'>" : "<td>")
                  .Append(Server.HtmlEncode(display))
                  .Append("</td>");
            }

            sb.Append("</tr>");
            if (!isTotalRow) serial++;
        }

        sb.Append("</table></body></html>");

        Response.Write(sb.ToString());
        Response.End();
    }

    public void Load_Month()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            ds = Common_CS.Load_Month();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlmonth.DataSource = ds.Tables[0];
                ddlmonth.DataTextField = "TheMonth";
                ddlmonth.DataValueField = "TheMonth_No";
                ddlmonth.DataBind();

                ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
                ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Load_Group_Name()
    {
        ddl_Branch.Items.Clear();
        if (Session["ClientGrpMst"] != null)
        {
            DataSet ds = (DataSet)Session["ClientGrpMst"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Branch.DataSource = ds.Tables[0];
                ddl_Branch.DataTextField = "GROUP_NAME";
                ddl_Branch.DataValueField = "GROUP_ID";
                ddl_Branch.DataBind();
            }
        }
        ddl_Branch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Branch.SelectedIndex = 0;
    }

    private void BindGrid(bool excludeTax)
    {
        try
        {
            if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
            {
                objUserBL.A1 = txtfromdate.Text;
                objUserBL.A2 = txttodate.Text;
            }
            else
            {
                if (ddlmonth.SelectedItem.Text != string.Empty)
                {
                    arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                    objUserBL.A1 = arr_Month[0];
                    objUserBL.A2 = arr_Month[1];
                }
                else
                {
                    objUserBL.A1 = txtfromdate.Text;
                    objUserBL.A2 = txttodate.Text;
                }
            }
          
            objUserBL.A3 = excludeTax ? "1" : "0";
            objUserBL.A4 = ddl_Cus_Name.SelectedValue;
            objUserBL.A5 = "load_Grid";
            DataTable pivotTable = objReport.GetMonthWisePivotReport(objUserBL);

            if (pivotTable != null && pivotTable.Rows.Count > 0)
            {
                BuildPivotColumns(pivotTable);
                gvReport.DataSource = pivotTable;
                gvReport.DataBind();
            }
            else
            {
                ClearGrid();
            }
        }
        catch (Exception ex)
        {
            // TODO: replace with your application's logging mechanism
            lblMessage.Text = "An error occurred while generating the report. Please try again.";
            System.Diagnostics.Trace.WriteLine("GSTMonthwiseReport.BindGrid error: " + ex);
            ClearGrid();
        }
    }


    private void BuildPivotColumns(DataTable pivotTable)
    {
        gvReport.Columns.Clear();

        // ---- S.No column (not part of the DataTable, just a running count) ----
        TemplateField serialField = new TemplateField();
        serialField.HeaderText = "S.No";
        serialField.ItemStyle.Width = 50;
        serialField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        serialField.ItemTemplate = new SerialNumberTemplate();
        gvReport.Columns.Add(serialField);

        //BoundField locationField = new BoundField();
        //locationField.DataField = LocationColumn;
        //locationField.HeaderText = "Label";
        //locationField.ItemStyle.CssClass = "location-cell";
        //locationField.ItemStyle.Width = 220;
        //gvReport.Columns.Add(locationField);


        // ---- Customer column (first real column of the DataTable) ----
        //BoundField customerField = new BoundField();
        //customerField.DataField = CustomerColumn;
        //customerField.HeaderText = "Customer";
        //customerField.ItemStyle.CssClass = "customer-cell";
        //customerField.ItemStyle.Width = 220;
        //gvReport.Columns.Add(customerField);

        // ---- One column per month (every DataTable column except the
        //      Customer column and the trailing Total column) ----
        foreach (DataColumn col in pivotTable.Columns)
        {
            if (col.ColumnName == TotalColumn)
            {
                continue;
            }

            BoundField monthField = new BoundField();
            monthField.DataField = col.ColumnName;
            monthField.HeaderText = col.ColumnName; // e.g. "Apr 2026"
            monthField.DataFormatString = "{0:N2}";
            monthField.HtmlEncode = false;
            monthField.ItemStyle.CssClass = "amount-cell";
            monthField.ItemStyle.Width = 120;
            gvReport.Columns.Add(monthField);
        }

        // ---- Total column (always last) ----
        BoundField totalField = new BoundField();
        totalField.DataField = TotalColumn;
        totalField.HeaderText = "Total";
        totalField.DataFormatString = "{0:N2}";
        totalField.HtmlEncode = false;
        totalField.ItemStyle.CssClass = "amount-cell total-col";
        totalField.HeaderStyle.CssClass = "total-col";
        totalField.ItemStyle.Width = 140;
        gvReport.Columns.Add(totalField);
    }


    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView rowView = e.Row.DataItem as DataRowView;

            if (rowView != null &&
                string.Equals(Convert.ToString(rowView[LocationColumn]), TotalRowLabel, StringComparison.OrdinalIgnoreCase))
            {
                e.Row.CssClass = "total-row";
            }
        }
    }

    private void ClearGrid()
    {
        DataTable emptyTable = new DataTable();
        emptyTable.Columns.Add(TotalColumn, typeof(decimal));

        BuildPivotColumns(emptyTable);
        gvReport.DataSource = emptyTable;
        gvReport.DataBind();
    }


    private class SerialNumberTemplate : System.Web.UI.ITemplate
    {
        public void InstantiateIn(System.Web.UI.Control container)
        {
            System.Web.UI.WebControls.Literal literal = new System.Web.UI.WebControls.Literal();
            literal.DataBinding += (sender, e) =>
            {
                GridViewRow row = (GridViewRow)((System.Web.UI.Control)sender).NamingContainer;
                literal.Text = (row.RowIndex + 1).ToString();
            };
            container.Controls.Add(literal);
        }
    }
}
