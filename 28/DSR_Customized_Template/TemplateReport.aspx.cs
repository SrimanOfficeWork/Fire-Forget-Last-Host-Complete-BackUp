using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;

public partial class TemplateReport : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    Company_Master Comp = new Company_Master();

    // populated by BuildReportTable(). Group & Sort -> Group By renders as one
    // physical grid per distinct _groupColumnNames combination (see BindReport /
    // BuildGroupedGrids) rather than a single grid with banner rows, so a
    // "records report grouped by X" reads as separate tables per group.
    private List<string> _groupColumnNames = new List<string>();
    // (output column name, aggregate operation) for Calculate & Summarize,
    // resolved from DSR_ReportSummary. Aggregates are computed in-memory from
    // whichever DataTable is currently being bound (see ComputeAggregates) -
    // once for the whole report when ungrouped, once per group when grouped -
    // rather than a second SQL round trip.
    private List<Tuple<string, string>> _summaryColumns = new List<Tuple<string, string>>();
    // Footer values (output column name -> formatted total) for whichever table
    // AppendHtmlTable is currently writing - reassigned per group when grouped.
    private Dictionary<string, string> _summaryFooterValues = new Dictionary<string, string>();
    private bool _hasAccess = true;
    // How many rows match every filter in total (from SP_DSR_TEMPLATE_REPORT_SELECT's
    // @TotalCount OUTPUT) - the on-screen grid itself is capped at OnScreenRowCap,
    // so this can be larger than the number of rows actually rendered.
    private int _totalMatchingRows;

    private int TemplateID
    {
        get
        {
            int id;
            int.TryParse(Request.QueryString["TemplateID"], out id);
            return id;
        }
    }

    private static string ConnString
    {
        get { return HttpContext.Current.Session["currentcomp_db"].ToString(); }
    }

    // "currentuser" (not "USER_NAME") is the actual login session key - set by
    // AppSession.makeSession() from the login form's username at sign-in
    // (LoginPage/Default.aspx.cs). "USER_NAME" is unrelated - it's only ever
    // written by the Users/User_Master.aspx admin form - so reading it here
    // always came back empty, which silently broke both "Only Me" Access &
    // Sharing above and Template Settings' Header Access (DSREntry.aspx.cs).
    private static string CurrentUserName
    {
        get
        {
            var name = HttpContext.Current.Session["currentuser"];
            return name == null ? "" : name.ToString();
        }
    }

    // Format & Schedule -> Access & Sharing: Only Me / A Specific Role / Everyone.
    // No DSR_ReportAccess row at all means the template predates this feature -
    // treat that the same as "Everyone" so existing templates keep working.
    private bool CurrentUserCanAccessReport()
    {
        using (SqlConnection conn = new SqlConnection(ConnString))
        using (SqlCommand cmd = new SqlCommand(
            "SELECT AccessMode, OwnerUserName, RoleID FROM DSR_ReportAccess WHERE TemplateID = @T", conn))
        {
            cmd.Parameters.AddWithValue("@T", TemplateID);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.Read()) return true;

                string mode = reader["AccessMode"].ToString();
                if (mode == "OnlyMe")
                {
                    string owner = reader["OwnerUserName"] == DBNull.Value ? "" : reader["OwnerUserName"].ToString();
                    return owner.Length > 0 && string.Equals(owner, CurrentUserName, StringComparison.OrdinalIgnoreCase);
                }
                if (mode == "SpecificRole")
                {
                    if (reader["RoleID"] == DBNull.Value) return false;
                    int roleId = Convert.ToInt32(reader["RoleID"]);
                    using (SqlCommand memberCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM DSR_RoleMember WHERE RoleID = @R AND UserName = @U", conn))
                    {
                        memberCmd.Parameters.AddWithValue("@R", roleId);
                        memberCmd.Parameters.AddWithValue("@U", CurrentUserName);
                        return Convert.ToInt32(memberCmd.ExecuteScalar()) > 0;
                    }
                }
                return true; // Everyone
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (TemplateID <= 0)
        {
            lblTitle.Text = "Invalid template.";
            btnExcel.Visible = false;
            btnRefresh.Visible = false;
            return;
        }

        _hasAccess = CurrentUserCanAccessReport();
        if (!_hasAccess)
        {
            lblTitle.Text = "You do not have permission to view this report.";
            btnExcel.Visible = false;
            btnRefresh.Visible = false;
            litReport.Text = "";
            return;
        }

        if (!IsPostBack)
        {
            GroupLoad();
            PopulateDateFilterDropdown();
            BindReport();
        }
    }

    // Date Filter by: JOB_DATE always, plus BE_DATE (Import templates, from
    // BE_ENTRY) or SB_DATE (Export templates, from EXPORT_SB_ENTRY) - which
    // second option applies depends on this template's own DSR_Template.Type,
    // same lookup BuildReportTable's stored procedure does internally. Only
    // run on first load, like GroupLoad, so the user's selection survives
    // postbacks via ViewState.
    private void PopulateDateFilterDropdown()
    {
        ddlDateFilter.Items.Clear();
        ddlDateFilter.Items.Add(new ListItem("Job Date", "JOB_DATE"));
        ddlDateFilter.Items.Add(GetTemplateType() == "Export"
            ? new ListItem("SB Date", "SB_DATE")
            : new ListItem("BE Date", "BE_DATE"));
    }

    private string GetTemplateType()
    {
        using (SqlConnection conn = new SqlConnection(ConnString))
        using (SqlCommand cmd = new SqlCommand(
            "SELECT Type FROM DSR_Template WHERE TemplateID = @T", conn))
        {
            cmd.Parameters.AddWithValue("@T", TemplateID);
            conn.Open();
            object result = cmd.ExecuteScalar();
            return result == null ? "Import" : result.ToString();
        }
    }

    // Same concept/plumbing as DSR_Template/Import_Dynamicreport.aspx.cs's
    // groupload(): TBL_GROUPMASTER's groups via Company_Master.RetrieveAll_Groups()
    // (flag "Select-Group"), bound to ListBox1 as GROUP_NAME/GROUP_ID. Only run
    // on first load - like the rest of this page's filter controls, ASP.NET
    // ViewState carries the user's checked items through postbacks on its own.
    private void GroupLoad()
    {
        Comp.COMPANY_ID = "";
        Comp.BRANCH = "";
        Comp.flag = "Select-Group";
        DataSet ds = Comp.RetrieveAll_Groups();

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ListBox1.DataSource = ds.Tables[0];
            ListBox1.DataTextField = "GROUP_NAME";
            ListBox1.DataValueField = "GROUP_ID";
            ListBox1.DataBind();

            if (ListBox1.Items.Count == 1)
            {
                // Only one group to choose from - nothing to default to.
                ListBox1.Items[0].Selected = true;
            }
            else
            {
                // Default to the Group Name the user actually logged in with
                // (Session["GroupName"], set at LoginPage/Default.aspx.cs's
                // login handler) - the user can still check additional
                // groups on top of it. Report Settings' report load
                // (BindReport -> BuildReportTable) reads this same
                // ListBox1 selection, so pre-selecting it here is what
                // makes the report itself load scoped to the login group.
                string loginGroupName = Session["GroupName"] as string;
                if (!string.IsNullOrEmpty(loginGroupName))
                {
                    ListItem defaultItem = ListBox1.Items.FindByText(loginGroupName);
                    if (defaultItem != null) defaultItem.Selected = true;
                }
            }
        }
    }

    private void BindReport()
    {
        lblTitle.Text = "DSR Report - " + GetTemplateName();
        hdnTemplateId.Value = TemplateID.ToString();

        // On-screen grid is always capped at 100 rows so a huge template can't
        // blow up memory just from being opened/refreshed - but txtGridSearch
        // is a real database search (top 100 *matches*, not "first 100 rows,
        // then filter"), since the importer/etc. someone's looking for won't
        // generally be within the first 100 rows by Job No. Re-run by
        // submitting the form (Enter, or the Refresh button); onkeyup in the
        // markup only gives an instant preview over whatever's already on
        // screen while typing. Download as Excel (btnExcel_Click) is the only
        // path with no row cap at all.
        // Field Search: capture the user's current dropdown pick before its Items
        // get cleared/repopulated below (ASP.NET has already restored SelectedValue
        // from the postback at this point), so it survives the repopulation.
        string fieldSearchColumn = ddlFieldSearch.SelectedValue;

        DataTable dt = BuildReportTable(OnScreenRowCap, txtGridSearch.Value, fieldSearchColumn, txtFieldSearchValue.Value, ddlDateFilter.SelectedValue);
        PopulateFieldSearchDropdown(dt, fieldSearchColumn);

        lblTotalRows.Text = _totalMatchingRows.ToString("N0") +
            (_totalMatchingRows > dt.Rows.Count ? " (showing first " + dt.Rows.Count.ToString("N0") + ")" : "");

        var sb = new System.Text.StringBuilder();

        if (_groupColumnNames.Count > 0)
        {
            AppendGroupedHtml(sb, dt);
        }
        else if (dt.Rows.Count == 0)
        {
            sb.Append("<p>No matching job records found for the importer(s)/exporter(s) assigned to this template.</p>");
        }
        else
        {
            _summaryFooterValues = ComputeAggregates(dt);
            AppendHtmlTable(new StringWriter(sb), dt, true, _summaryFooterValues);
        }

        litReport.Text = sb.ToString();
    }

    // Group & Sort -> Group By: one HTML table per distinct combination of the
    // configured group fields, each with its own heading and (if Calculate &
    // Summarize has fields selected) its own subtotal footer - rather than one
    // grid with banner rows, so each group reads as its own report. Rows are
    // already ORDER BY'd by the group fields (see BuildReportTable), so GroupBy
    // here just has to preserve that order.
    private void AppendGroupedHtml(System.Text.StringBuilder sb, DataTable dt)
    {
        var groups = dt.AsEnumerable()
            .GroupBy(r => string.Join("", _groupColumnNames.Select(c => r[c] as string ?? "")))
            .ToList();

        if (groups.Count == 0)
        {
            sb.Append("<p>No matching job records found for the importer(s)/exporter(s) assigned to this template.</p>");
            return;
        }

        foreach (var group in groups)
        {
            DataTable groupDt = dt.Clone();
            foreach (DataRow row in group)
                groupDt.ImportRow(row);

            var keyParts = _groupColumnNames.Select(c => groupDt.Rows[0][c] as string ?? "").ToList();
            var labelParts = new List<string>();
            for (int gi = 0; gi < _groupColumnNames.Count; gi++)
                labelParts.Add(_groupColumnNames[gi] + ": " + (keyParts[gi].Length == 0 ? "(blank)" : keyParts[gi]));
            string recordWord = groupDt.Rows.Count == 1 ? "record" : "records";

            sb.Append("<div class=\"group-block\">");
            sb.Append("<div class=\"group-banner-cell\">").Append(HttpUtility.HtmlEncode(string.Join("   |   ", labelParts)))
              .Append(" <span class=\"group-count\">(").Append(groupDt.Rows.Count).Append(" ").Append(recordWord).Append(")</span></div>");
            sb.Append("<div class=\"group-grid-wrap\">");

            _summaryFooterValues = ComputeAggregates(groupDt);
            AppendHtmlTable(new StringWriter(sb), groupDt, true, _summaryFooterValues);

            sb.Append("</div></div>");
            groupDt.Dispose();
        }
    }

    // Hand-written HTML table - not an asp:GridView, which allocates one
    // TableCell/TableRow control object per cell purely to produce this same
    // static markup. For a few hundred columns times a few thousand rows that's
    // millions of heavyweight objects, dwarfing the actual data - the real cause
    // behind OutOfMemoryException on large templates, worse than either the SQL
    // side or the plain size of the HTML itself. Shared by the on-screen report
    // (writer wraps the page's output StringBuilder) and Excel export (writer is
    // response.Output directly, so nothing is buffered twice).
    private void AppendHtmlTable(TextWriter writer, DataTable table, bool includeSelectColumn, Dictionary<string, string> footerValues)
    {
        // Header cells carry their look as an inline style, not just the
        // "grid-view" CSS class - the on-screen page has a <style> block backing
        // that class, but the Excel export is a standalone response with no
        // <head> of its own, so a CSS class alone would render unstyled there.
        const string thStyle = "background:#1f3b57;color:#fff;border:1px solid #dde3e8;padding:6px 10px;text-align:left;";
        const string tdStyle = "border:1px solid #dde3e8;padding:6px 10px;";

        writer.Write("<table class=\"grid-view\">");

        writer.Write("<thead><tr>");
        if (includeSelectColumn) writer.Write("<th class=\"select-col\" style=\"" + thStyle + "\">Select</th>");
        foreach (DataColumn col in table.Columns)
        {
            string colNameEnc = HttpUtility.HtmlEncode(col.ColumnName);
            // Sortable headers only on the on-screen report - includeSelectColumn
            // is false for the Excel export (see ExportExcel), which has no JS to
            // run against anyway.
            if (includeSelectColumn)
                writer.Write("<th class=\"sortable\" style=\"" + thStyle + "\" onclick=\"sortGridColumn(this);\">" +
                    colNameEnc + "<span class=\"sort-arrow\">&#8645;</span></th>");
            else
                writer.Write("<th style=\"" + thStyle + "\">" + colNameEnc + "</th>");
        }
        writer.Write("</tr></thead><tbody>");

        foreach (DataRow row in table.Rows)
        {
            if (includeSelectColumn)
            {
                // Not "row[JobNoColumn] as string" - JOBNO doesn't necessarily come
                // back as a CLR System.String (depends on its actual SQL type), and
                // an "as" cast against the wrong type silently yields null here,
                // leaving the row's radio with an empty value - same ToString()
                // pattern the plain data cells below already use safely.
                object jobNoVal = row[JobNoColumn];
                string jobNo = (jobNoVal == null || jobNoVal == DBNull.Value) ? "" : jobNoVal.ToString();
                string jobNoAttr = HttpUtility.HtmlAttributeEncode(jobNo);
                writer.Write("<tr onclick=\"rowClicked(this);\"><td class=\"select-col\" style=\"" + tdStyle + "\"><input type='radio' name='rowSelect' value='" +
                    jobNoAttr + "' onclick='selectRow(this);' /></td>");
            }
            else
            {
                writer.Write("<tr>");
            }

            foreach (DataColumn col in table.Columns)
            {
                object val = row[col];
                string text = (val == null || val == DBNull.Value) ? "" : HttpUtility.HtmlEncode(val.ToString());
                writer.Write("<td style=\"" + tdStyle + "\">" + text + "</td>");
            }
            writer.Write("</tr>");
        }
        writer.Write("</tbody>");

        if (footerValues != null && footerValues.Count > 0)
        {
            const string footerStyle = tdStyle + "background:#eef2f5;font-weight:700;";
            writer.Write("<tfoot><tr>");
            if (includeSelectColumn) writer.Write("<td class=\"select-col\" style=\"" + footerStyle + "\"></td>");
            bool isFirstColumn = true;
            foreach (DataColumn col in table.Columns)
            {
                if (isFirstColumn)
                {
                    writer.Write("<td style=\"" + footerStyle + "\">Total</td>");
                    isFirstColumn = false;
                    continue;
                }
                string val;
                footerValues.TryGetValue(col.ColumnName, out val);
                writer.Write("<td style=\"" + footerStyle + "\">" + (val != null ? HttpUtility.HtmlEncode(val) : "") + "</td>");
            }
            writer.Write("</tr></tfoot>");
        }

        writer.Write("</table>");
    }

    // Computes SUM/AVG/MIN/MAX/COUNT for _summaryColumns purely in memory from
    // whichever DataTable is passed in (the whole report, or just one group's
    // rows) - see the class-level comment on _summaryColumns for why this
    // replaced a second SQL query. Mirrors the SQL semantics it replaced:
    // SUM treats non-numeric/blank as 0, AVG/MIN/MAX ignore them, COUNT counts
    // every non-NULL cell regardless of whether it parses as a number.
    private Dictionary<string, string> ComputeAggregates(DataTable table)
    {
        var result = new Dictionary<string, string>();

        foreach (var sc in _summaryColumns)
        {
            string col = sc.Item1, op = sc.Item2;
            if (!table.Columns.Contains(col)) continue;

            switch (op)
            {
                case "SUM":
                case "AVG":
                {
                    double sum = 0;
                    var numeric = new List<double>();
                    foreach (DataRow row in table.Rows)
                    {
                        double num;
                        if (double.TryParse(Convert.ToString(row[col]), out num))
                        {
                            sum += num;
                            numeric.Add(num);
                        }
                    }
                    result[col] = op == "SUM" ? sum.ToString("N2") : (numeric.Count > 0 ? numeric.Average() : 0).ToString("N2");
                    break;
                }
                case "COUNT":
                {
                    int count = 0;
                    foreach (DataRow row in table.Rows)
                        if (row[col] != null && row[col] != DBNull.Value) count++;
                    result[col] = count.ToString();
                    break;
                }
                case "MIN":
                case "MAX":
                {
                    var raws = new List<string>();
                    foreach (DataRow row in table.Rows)
                    {
                        if (row[col] == null || row[col] == DBNull.Value) continue;
                        string s = row[col].ToString();
                        if (s.Length > 0) raws.Add(s);
                    }
                    if (raws.Count == 0) { result[col] = ""; break; }

                    DateTime dtVal;
                    double numVal;
                    if (raws.All(r => DateTime.TryParse(r, out dtVal)))
                    {
                        var dates = raws.Select(DateTime.Parse);
                        result[col] = (op == "MIN" ? dates.Min() : dates.Max()).ToString();
                    }
                    else if (raws.All(r => double.TryParse(r, out numVal)))
                    {
                        var nums = raws.Select(double.Parse);
                        result[col] = (op == "MIN" ? nums.Min() : nums.Max()).ToString("N2");
                    }
                    else
                    {
                        result[col] = op == "MIN"
                            ? raws.OrderBy(r => r, StringComparer.Ordinal).First()
                            : raws.OrderBy(r => r, StringComparer.Ordinal).Last();
                    }
                    break;
                }
            }
        }

        return result;
    }

    // Field Search dropdown lists exactly the columns the current report rendered
    // (Job No + every field label + any Date Comparison columns, in the same order
    // AppendHtmlTable shows them), so there's never a mismatch between what's
    // selectable and what's actually on screen. Repopulated on every BindReport()
    // call since the field list can change if the template itself is edited.
    private void PopulateFieldSearchDropdown(DataTable dt, string previousSelection)
    {
        ddlFieldSearch.Items.Clear();
        ddlFieldSearch.Items.Add(new ListItem("-- Select Field --", ""));
        foreach (DataColumn col in dt.Columns)
            ddlFieldSearch.Items.Add(new ListItem(col.ColumnName, col.ColumnName));

        if (!string.IsNullOrEmpty(previousSelection))
        {
            ListItem item = ddlFieldSearch.Items.FindByValue(previousSelection);
            if (item != null) item.Selected = true;
        }
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        if (!_hasAccess) return;
        BindReport();
    }

    private string GetTemplateName()
    {
        using (SqlConnection conn = new SqlConnection(ConnString))
        using (SqlCommand cmd = new SqlCommand(
            "SELECT TemplateName FROM DSR_Template WHERE TemplateID = @T", conn))
        {
            cmd.Parameters.AddWithValue("@T", TemplateID);
            conn.Open();
            object result = cmd.ExecuteScalar();
            return result == null ? string.Empty : result.ToString();
        }
    }

    private const string JobNoColumn = "Job No";

    // On-screen report load - see BindReport's comment for why this is capped
    // while Download as Excel (BuildReportTable(null, ...)) is not.
    private const int OnScreenRowCap = 100;

    // Grid load / data retrieval now lives entirely in
    // SP_DSR_TEMPLATE_REPORT_SELECT (SP_DSR_TemplateReport_Select.sql) rather
    // than as an inline dynamic SQL string built here - this method just
    // supplies the procedure's parameters and reads back its three result
    // sets. topN caps the result set (on-screen load); pass null for no cap
    // (Excel export). searchTerm/fieldSearchColumn/fieldSearchTerm are the
    // Grid Search box and the Field Search dropdown+textbox pair - see the
    // procedure's own header comment for exactly how each is applied.
    private DataTable BuildReportTable(int? topN, string searchTerm, string fieldSearchColumn, string fieldSearchTerm, string dateFilterColumn)
    {
        var dt = new DataTable();
        _groupColumnNames = new List<string>();
        _summaryColumns = new List<Tuple<string, string>>();
        _summaryFooterValues.Clear();

        using (SqlConnection conn = new SqlConnection(ConnString))
        using (SqlCommand cmd = new SqlCommand("SP_DSR_TEMPLATE_REPORT_SELECT", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            // A template with a few hundred fields is a genuinely bigger query
            // for the procedure to plan and run even after its own join
            // fan-out handling, so give it more room before giving up (same
            // value the old inline query used).
            cmd.CommandTimeout = 180;

            cmd.Parameters.AddWithValue("@TemplateID", TemplateID);
            cmd.Parameters.AddWithValue("@TopN", (object)topN ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@SearchTerm", string.IsNullOrWhiteSpace(searchTerm) ? (object)DBNull.Value : searchTerm);
            cmd.Parameters.AddWithValue("@FieldSearchColumn", string.IsNullOrEmpty(fieldSearchColumn) ? (object)DBNull.Value : fieldSearchColumn);
            cmd.Parameters.AddWithValue("@FieldSearchTerm", string.IsNullOrWhiteSpace(fieldSearchTerm) ? (object)DBNull.Value : fieldSearchTerm);

            DateTime fromDate, toDate;
            cmd.Parameters.AddWithValue("@FromDate", DateTime.TryParse(txtFromDate.Text, out fromDate) ? (object)fromDate.Date : DBNull.Value);
            cmd.Parameters.AddWithValue("@ToDate", DateTime.TryParse(txtToDate.Text, out toDate) ? (object)toDate.Date : DBNull.Value);
            cmd.Parameters.AddWithValue("@DateFilterColumn", string.IsNullOrEmpty(dateFilterColumn) ? (object)"JOB_DATE" : dateFilterColumn);

            // Only the selected Group Name text is passed to the SP - GROUP_ID
            // resolution/lookup and all report filtering by it happen entirely
            // inside SP_DSR_TEMPLATE_REPORT_SELECT (a TBL_GROUPMASTER lookup by
            // Group Name), never here.
            var selectedGroups = ListBox1.Items.Cast<ListItem>().Where(item => item.Selected).ToList();
            // NOT comma-joined - Group Name text can itself contain a comma, so
            // splitting on "," in the SP would fragment a single selected name
            // into multiple bogus tokens and the filter would match zero
            // branches. "\x1F" (ASCII Unit Separator) can't appear in a Group
            // Name typed/picked through the UI, so it's safe as a delimiter here.
            string groupNames = string.Join("\x1F", selectedGroups.Select(item => item.Text));
            cmd.Parameters.AddWithValue("@GroupNames", groupNames.Length > 0 ? (object)groupNames : DBNull.Value);

            SqlParameter totalCountParam = new SqlParameter("@TotalCount", SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(totalCountParam);

            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dt.Load(reader); // result set 1: the report data itself

                if (reader.NextResult()) // result set 2: Group & Sort -> Group By columns, in order
                {
                    while (reader.Read())
                        _groupColumnNames.Add(reader.GetString(0));
                }

                if (reader.NextResult()) // result set 3: Calculate & Summarize columns + operation, in order
                {
                    while (reader.Read())
                        _summaryColumns.Add(Tuple.Create(reader.GetString(0), reader.GetString(1)));
                }
            }
            // Output parameters only populate once the reader above is fully
            // closed - reading it any earlier would still see DBNull.
            _totalMatchingRows = totalCountParam.Value == DBNull.Value ? 0 : Convert.ToInt32(totalCountParam.Value);
        }

        return dt;
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        if (!_hasAccess) return;
        ExportExcel(BuildReportTable(null, txtGridSearch.Value, ddlFieldSearch.SelectedValue, txtFieldSearchValue.Value, ddlDateFilter.SelectedValue), GetTemplateName().Replace(" ", "_"));
    }

    private void ExportExcel(DataTable dtdata, string filename)
    {
        HttpResponse response = HttpContext.Current.Response;

        response.Clear();
        response.Buffer = true;
        response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
        response.Charset = "";
        response.ContentType = "application/vnd.ms-excel";

        // Writes straight to response.Output (the response stream) via the same
        // hand-written AppendHtmlTable used for the on-screen report, instead of
        // an asp:GridView - see AppendHtmlTable's comment for why that matters at
        // a few hundred columns times a few thousand rows.
        if (_groupColumnNames.Count > 0)
        {
            var groups = dtdata.AsEnumerable()
                .GroupBy(r => string.Join("", _groupColumnNames.Select(c => r[c] as string ?? "")))
                .ToList();

            if (groups.Count == 0)
            {
                response.Output.Write("<p>No matching job records found for the importer(s)/exporter(s) assigned to this template.</p>");
            }

            foreach (var group in groups)
            {
                DataTable groupDt = dtdata.Clone();
                foreach (DataRow row in group)
                    groupDt.ImportRow(row);

                var keyParts = _groupColumnNames.Select(c => groupDt.Rows[0][c] as string ?? "").ToList();
                var labelParts = new List<string>();
                for (int gi = 0; gi < _groupColumnNames.Count; gi++)
                    labelParts.Add(_groupColumnNames[gi] + ": " + (keyParts[gi].Length == 0 ? "(blank)" : keyParts[gi]));
                string recordWord = groupDt.Rows.Count == 1 ? "record" : "records";

                response.Output.Write("<div style=\"font-weight:bold;background-color:#1f3b57;color:#ffffff;padding:6px 10px;margin-top:14px;\">" +
                    HttpUtility.HtmlEncode(string.Join("   |   ", labelParts)) +
                    " (" + groupDt.Rows.Count + " " + recordWord + ")</div>");

                AppendHtmlTable(response.Output, groupDt, false, ComputeAggregates(groupDt));
                groupDt.Dispose();
            }
        }
        else
        {
            AppendHtmlTable(response.Output, dtdata, false, ComputeAggregates(dtdata));
        }

        response.Flush();
        response.End();
    }
}
