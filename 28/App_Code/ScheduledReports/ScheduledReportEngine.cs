using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using ClosedXML.Excel;

// Report Settings -> Scheduled Generation: called by RunScheduledReports.ashx
// (no login session, so no Session["currentcomp_db"] - see DSR_ReportSchedule.
// ConnectionString) to find every enabled, due schedule across the company
// databases it's given, generate that template's report the same way
// TemplateReport.aspx does (same Filters/Group & Sort/Calculate & Summarize),
// and email it as an Excel attachment.
//
// This deliberately duplicates TemplateReport.aspx.cs's BuildReportTable/
// ExportExcel logic rather than sharing it - that Page class is wired to
// Request.QueryString/Session/TextBox controls throughout, and this class has
// none of those. Duplication also matches how this codebase already builds a
// near-identical query per report elsewhere (Mis_Report/*, Report/Import/*, etc).
// If Filters/Group & Sort/Calculate & Summarize semantics change in
// TemplateReport.aspx.cs, mirror the change here too.
public static class ScheduledReportEngine
{
    public class RunResult
    {
        public int TemplateId;
        public string TemplateName;
        public bool Success;
        public string Message;
    }

    private static readonly System.Text.RegularExpressions.Regex ValidIdentifier =
        new System.Text.RegularExpressions.Regex(@"^[A-Za-z_][A-Za-z0-9_]*$");

    private static string Bracket(string identifier)
    {
        return "[" + identifier.Replace("]", "]]") + "]";
    }

    private static string TryConvertFloatExpr(string expr)
    {
        return "(CASE WHEN ISNUMERIC(" + expr + ") = 1 THEN CONVERT(float, " + expr + ") ELSE NULL END)";
    }

    private static bool ColumnExists(SqlConnection conn, string tableName, string columnName)
    {
        using (SqlCommand cmd = new SqlCommand(
            "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @T AND COLUMN_NAME = @C", conn))
        {
            cmd.Parameters.AddWithValue("@T", tableName);
            cmd.Parameters.AddWithValue("@C", columnName);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }

    private class FieldMeta
    {
        public int FieldId;
        public string FieldName;
        public string Label;
        public string SourceType;
        public string SourceTable;
        public string SourceColumn;
        public string FormulaOperation;
        public string FormulaSources;
    }

    private class ReportFilterMeta
    {
        public int FieldId;
        public string Operator;
        public string FilterValue;
    }

    private const string JobNoColumn = "Job No";

    private static string BuildFormulaExpr(FieldMeta f, Dictionary<string, string> fieldExprByName)
    {
        var sourceNames = (f.FormulaSources ?? string.Empty)
            .Split(',').Select(s => s.Trim()).Where(s => s.Length > 0).ToList();
        var exprs = sourceNames
            .Select(name => fieldExprByName.ContainsKey(name) ? fieldExprByName[name] : "NULL").ToList();
        if (exprs.Count == 0) return "NULL";

        switch (f.FormulaOperation)
        {
            case "Sum":
                return "(" + string.Join(" + ", exprs.Select(e => "ISNULL(" + TryConvertFloatExpr(e) + ", 0)")) + ")";
            case "Concat":
                return "(" + string.Join(" + ' ' + ", exprs.Select(e => "CAST(ISNULL(" + e + ", '') AS VARCHAR(4000))")) + ")";
            case "GreaterThan":
                if (exprs.Count < 2) return "NULL";
                return "CASE WHEN " + TryConvertFloatExpr(exprs[0]) + " > " + TryConvertFloatExpr(exprs[1]) + " THEN 'Yes' ELSE 'No' END";
            case "LessThan":
                if (exprs.Count < 2) return "NULL";
                return "CASE WHEN " + TryConvertFloatExpr(exprs[0]) + " < " + TryConvertFloatExpr(exprs[1]) + " THEN 'Yes' ELSE 'No' END";
            default:
                return "NULL";
        }
    }

    // Builds the full report DataTable - no From/To Date filter, since a
    // scheduled run has no date-range textboxes to read; it always covers the
    // template's complete matching dataset, same as leaving both fields blank
    // on screen would.
    private static DataTable BuildReportTable(SqlConnection conn, int templateId,
        out List<string> groupColumnNames, out List<Tuple<string, string>> summaryColumns)
    {
        groupColumnNames = new List<string>();
        summaryColumns = new List<Tuple<string, string>>();

        string templateType;
        using (SqlCommand cmd = new SqlCommand("SELECT Type FROM DSR_Template WHERE TemplateID = @T", conn))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            object result = cmd.ExecuteScalar();
            templateType = (result == null || result == DBNull.Value) ? "Import" : result.ToString();
        }

        var partyNames = new List<string>();
        using (SqlCommand cmd = new SqlCommand("SELECT PartyName FROM DSR_TemplateCustomerMap WHERE TemplateID = @T", conn))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            using (SqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read()) partyNames.Add(reader["PartyName"].ToString());
        }

        var fields = new List<FieldMeta>();
        using (SqlCommand cmd = new SqlCommand(
            @"SELECT f.FieldID, f.FieldName, f.FieldLabel, f.SourceType, f.SourceTable, f.SourceColumn,
                     f.FormulaOperation, f.FormulaSources
              FROM DSR_TemplateField f
              JOIN DSR_TemplateHeader h ON h.HeaderID = f.HeaderID
              WHERE h.TemplateID = @T
              ORDER BY h.DisplayOrder, f.DisplayOrder", conn))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    fields.Add(new FieldMeta
                    {
                        FieldId = Convert.ToInt32(reader["FieldID"]),
                        FieldName = reader["FieldName"].ToString(),
                        Label = reader["FieldLabel"].ToString(),
                        SourceType = reader["SourceType"].ToString(),
                        SourceTable = reader["SourceTable"] == DBNull.Value ? null : reader["SourceTable"].ToString(),
                        SourceColumn = reader["SourceColumn"] == DBNull.Value ? null : reader["SourceColumn"].ToString(),
                        FormulaOperation = reader["FormulaOperation"] == DBNull.Value ? null : reader["FormulaOperation"].ToString(),
                        FormulaSources = reader["FormulaSources"] == DBNull.Value ? null : reader["FormulaSources"].ToString()
                    });
                }
            }
        }

        var fieldById = fields.ToDictionary(f => f.FieldId);

        var reportFilters = new List<ReportFilterMeta>();
        using (SqlCommand cmd = new SqlCommand(
            "SELECT FieldID, Operator, FilterValue FROM DSR_ReportFilter WHERE TemplateID = @T ORDER BY DisplayOrder", conn))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int fid = Convert.ToInt32(reader["FieldID"]);
                    if (!fieldById.ContainsKey(fid)) continue;
                    reportFilters.Add(new ReportFilterMeta
                    {
                        FieldId = fid,
                        Operator = reader["Operator"].ToString(),
                        FilterValue = reader["FilterValue"] == DBNull.Value ? null : reader["FilterValue"].ToString()
                    });
                }
            }
        }

        var reportGroupFieldIds = new List<int>();
        using (SqlCommand cmd = new SqlCommand(
            "SELECT FieldID FROM DSR_ReportGroup WHERE TemplateID = @T ORDER BY DisplayOrder", conn))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            using (SqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    int fid = Convert.ToInt32(reader["FieldID"]);
                    if (fieldById.ContainsKey(fid)) reportGroupFieldIds.Add(fid);
                }
        }

        var reportSorts = new List<Tuple<int, string>>();
        using (SqlCommand cmd = new SqlCommand(
            "SELECT FieldID, Direction FROM DSR_ReportSort WHERE TemplateID = @T ORDER BY DisplayOrder", conn))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            using (SqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    int fid = Convert.ToInt32(reader["FieldID"]);
                    if (fieldById.ContainsKey(fid)) reportSorts.Add(Tuple.Create(fid, reader["Direction"].ToString()));
                }
        }

        var reportSummaries = new List<Tuple<int, string>>();
        using (SqlCommand cmd = new SqlCommand(
            "SELECT FieldID, Operation FROM DSR_ReportSummary WHERE TemplateID = @T ORDER BY DisplayOrder", conn))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            using (SqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    int fid = Convert.ToInt32(reader["FieldID"]);
                    if (fieldById.ContainsKey(fid)) reportSummaries.Add(Tuple.Create(fid, reader["Operation"].ToString()));
                }
        }

        var dt = new DataTable();
        dt.Columns.Add(JobNoColumn);
        var aliasByFieldId = new Dictionary<int, string>();
        foreach (var f in fields)
        {
            string colName = f.Label;
            int suffix = 1;
            while (dt.Columns.Contains(colName)) colName = f.Label + " (" + (++suffix) + ")";
            dt.Columns.Add(colName);
            aliasByFieldId[f.FieldId] = colName;
        }

        groupColumnNames = reportGroupFieldIds
            .Where(fid => aliasByFieldId.ContainsKey(fid))
            .Select(fid => aliasByFieldId[fid])
            .ToList();

        if (fields.Count == 0) return dt;

        // No importer(s)/exporter(s) assigned to the template means "All" -
        // every importer for an Import template, every exporter for an Export
        // template - rather than "no rows match". Mirrors TemplateReport.aspx.cs.
        bool filterByParty = partyNames.Count > 0;

        string baseTable = templateType == "Export" ? "EXPORT_GENERAL_DETAILS" : "GENERAL_DETAILS";
        string partyColumn = templateType == "Export" ? "EXPORTER_NAME" : "IMPORTER_NAME";

        var tableAliases = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        tableAliases[baseTable] = "t0";
        int aliasSeq = 1;

        // See TemplateReport.aspx.cs's copy of this block: all manual fields
        // resolve through one join to one pivoted subquery (evAll.[F<FieldID>])
        // instead of one join per field, so a template with hundreds of manual
        // fields doesn't add hundreds of joins to the same query.
        var manualFieldIds = fields.Where(f => f.SourceType == "Manual").Select(f => f.FieldId).ToList();
        bool hasManualField = manualFieldIds.Count > 0;
        string manualJoinSql = null;
        if (hasManualField)
        {
            var pivotCols = manualFieldIds.Select(fid =>
                "MAX(CASE WHEN FieldID = " + fid + " THEN FieldValue END) AS " + Bracket("F" + fid));
            manualJoinSql = "LEFT JOIN (SELECT EntryID, " + string.Join(", ", pivotCols) +
                " FROM DSR_EntryValue WHERE FieldID IN (" + string.Join(",", manualFieldIds) +
                ") GROUP BY EntryID) evAll ON evAll.EntryID = eh.EntryID";
        }

        var fieldExprByName = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var fieldExprById = new Dictionary<int, string>();

        foreach (var f in fields)
        {
            if (f.SourceType == "Formula") continue;

            if (f.SourceType == "Manual")
            {
                string expr = "evAll." + Bracket("F" + f.FieldId);
                fieldExprByName[f.FieldName] = expr;
                fieldExprById[f.FieldId] = expr;
                continue;
            }

            bool isValidSource = f.SourceType == "Schema"
                && !string.IsNullOrEmpty(f.SourceTable) && ValidIdentifier.IsMatch(f.SourceTable)
                && !string.IsNullOrEmpty(f.SourceColumn) && ValidIdentifier.IsMatch(f.SourceColumn);

            if (!isValidSource)
            {
                fieldExprByName[f.FieldName] = "NULL";
                fieldExprById[f.FieldId] = "NULL";
                continue;
            }

            string alias;
            if (!tableAliases.TryGetValue(f.SourceTable, out alias))
            {
                alias = "t" + (aliasSeq++);
                tableAliases[f.SourceTable] = alias;
            }

            fieldExprByName[f.FieldName] = alias + "." + Bracket(f.SourceColumn);
            fieldExprById[f.FieldId] = alias + "." + Bracket(f.SourceColumn);
        }

        var selectParts = new List<string> { "t0.JOBNO AS " + Bracket(JobNoColumn) };
        for (int i = 0; i < fields.Count; i++)
        {
            var f = fields[i];
            string outputColumn = dt.Columns[i + 1].ColumnName;

            if (f.SourceType == "Formula")
            {
                string formulaExpr = BuildFormulaExpr(f, fieldExprByName);
                fieldExprById[f.FieldId] = formulaExpr;
                selectParts.Add(formulaExpr + " AS " + Bracket(outputColumn));
                continue;
            }

            string expr;
            if (!fieldExprByName.TryGetValue(f.FieldName, out expr)) expr = "NULL";
            selectParts.Add(expr + " AS " + Bracket(outputColumn));
        }

        string selectSql = "SELECT " + string.Join(", ", selectParts);
        var sql = new StringBuilder();
        sql.Append(" FROM ").Append(Bracket(baseTable)).Append(" t0");

        bool baseHasWorkingPeriod = ColumnExists(conn, baseTable, "WORKINGPERIOD");
        foreach (var kvp in tableAliases)
        {
            if (kvp.Key.Equals(baseTable, StringComparison.OrdinalIgnoreCase)) continue;
            sql.Append(" LEFT JOIN ").Append(Bracket(kvp.Key)).Append(" ").Append(kvp.Value)
               .Append(" ON ").Append(kvp.Value).Append(".JOBNO = t0.JOBNO");
            if (baseHasWorkingPeriod && ColumnExists(conn, kvp.Key, "WORKINGPERIOD"))
                sql.Append(" AND ").Append(kvp.Value).Append(".WORKINGPERIOD = t0.WORKINGPERIOD");
        }
        if (hasManualField)
        {
            sql.Append(" LEFT JOIN DSR_EntryHeader eh ON eh.TemplateID = ").Append(templateId)
               .Append(" AND eh.JOBNO = t0.JOBNO");
            sql.Append(" ").Append(manualJoinSql);
        }

        var whereParamSpecs = new List<Tuple<string, object>>();
        var whereSql = new StringBuilder();

        if (filterByParty)
        {
            var partyParamNames = new List<string>();
            for (int i = 0; i < partyNames.Count; i++)
            {
                string p = "@P" + i;
                partyParamNames.Add(p);
                whereParamSpecs.Add(Tuple.Create(p, (object)partyNames[i]));
            }
            whereSql.Append(" WHERE t0.").Append(Bracket(partyColumn))
               .Append(" IN (").Append(string.Join(",", partyParamNames)).Append(")");
        }
        else
        {
            whereSql.Append(" WHERE 1 = 1");
        }

        int filterParamSeq = 0;
        foreach (var filter in reportFilters)
        {
            string expr;
            if (!fieldExprById.TryGetValue(filter.FieldId, out expr)) continue;
            string textExpr = "CAST(" + expr + " AS NVARCHAR(4000))";

            switch (filter.Operator)
            {
                case "Equals":
                {
                    string p = "@F" + filterParamSeq++;
                    whereSql.Append(" AND ").Append(textExpr).Append(" = ").Append(p);
                    whereParamSpecs.Add(Tuple.Create(p, (object)(filter.FilterValue ?? "")));
                    break;
                }
                case "NotEquals":
                {
                    string p = "@F" + filterParamSeq++;
                    whereSql.Append(" AND (").Append(expr).Append(" IS NULL OR ").Append(textExpr).Append(" <> ").Append(p).Append(")");
                    whereParamSpecs.Add(Tuple.Create(p, (object)(filter.FilterValue ?? "")));
                    break;
                }
                case "Contains":
                {
                    string p = "@F" + filterParamSeq++;
                    whereSql.Append(" AND ").Append(textExpr).Append(" LIKE ").Append(p);
                    whereParamSpecs.Add(Tuple.Create(p, (object)("%" + (filter.FilterValue ?? "") + "%")));
                    break;
                }
                case "NotContains":
                {
                    string p = "@F" + filterParamSeq++;
                    whereSql.Append(" AND (").Append(expr).Append(" IS NULL OR ").Append(textExpr).Append(" NOT LIKE ").Append(p).Append(")");
                    whereParamSpecs.Add(Tuple.Create(p, (object)("%" + (filter.FilterValue ?? "") + "%")));
                    break;
                }
                case "IsOneOf":
                {
                    var values = (filter.FilterValue ?? "").Split(',').Select(v => v.Trim()).Where(v => v.Length > 0).ToList();
                    if (values.Count == 0) { whereSql.Append(" AND 1 = 0"); break; }
                    var inParams = new List<string>();
                    foreach (var v in values)
                    {
                        string p = "@F" + filterParamSeq++;
                        inParams.Add(p);
                        whereParamSpecs.Add(Tuple.Create(p, (object)v));
                    }
                    whereSql.Append(" AND ").Append(textExpr).Append(" IN (").Append(string.Join(",", inParams)).Append(")");
                    break;
                }
                case "IsEmpty":
                    whereSql.Append(" AND (").Append(expr).Append(" IS NULL OR ").Append(textExpr).Append(" = '')");
                    break;
                case "IsNotEmpty":
                    whereSql.Append(" AND (").Append(expr).Append(" IS NOT NULL AND ").Append(textExpr).Append(" <> '')");
                    break;
            }
        }

        string fromJoinSql = sql.ToString();

        var orderByParts = new List<string>();
        foreach (int fid in reportGroupFieldIds)
        {
            string col;
            if (aliasByFieldId.TryGetValue(fid, out col)) orderByParts.Add(Bracket(col));
        }
        foreach (var sortEntry in reportSorts)
        {
            string col;
            if (!aliasByFieldId.TryGetValue(sortEntry.Item1, out col)) continue;
            orderByParts.Add(Bracket(col) + (sortEntry.Item2 == "Desc" ? " DESC" : " ASC"));
        }
        string orderBySql = orderByParts.Count > 0
            ? " ORDER BY " + string.Join(", ", orderByParts)
            : " ORDER BY t0.JOBNO";

        using (SqlCommand cmd = new SqlCommand(selectSql + fromJoinSql + whereSql.ToString() + orderBySql, conn))
        {
            // Default is 30s; see TemplateReport.aspx.cs's copy of this comment.
            cmd.CommandTimeout = 180;
            foreach (var p in whereParamSpecs) cmd.Parameters.AddWithValue(p.Item1, p.Item2);
            using (SqlDataAdapter da = new SqlDataAdapter(cmd)) da.Fill(dt);
        }

        summaryColumns = reportSummaries
            .Where(s => s.Item2 != "None" && aliasByFieldId.ContainsKey(s.Item1))
            .Select(s => Tuple.Create(aliasByFieldId[s.Item1], s.Item2))
            .ToList();

        return dt;
    }

    private static Dictionary<string, string> ComputeAggregates(DataTable table, List<Tuple<string, string>> summaryColumns)
    {
        var result = new Dictionary<string, string>();
        foreach (var sc in summaryColumns)
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
                        if (double.TryParse(Convert.ToString(row[col]), out num)) { sum += num; numeric.Add(num); }
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

    // Writes one header+data(+totals) block starting at startRow and returns the
    // row to continue at. Used both for the whole report (no grouping) and once
    // per group (with grouping) by BuildExcelBytes below.
    private static int WriteReportBlock(IXLWorksheet ws, int startRow, DataTable table, Dictionary<string, string> footerValues)
    {
        for (int c = 0; c < table.Columns.Count; c++)
        {
            var cell = ws.Cell(startRow, c + 1);
            cell.Value = table.Columns[c].ColumnName;
            cell.Style.Font.Bold = true;
            cell.Style.Font.FontColor = XLColor.White;
            cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#1f3b57");
        }

        int r = startRow + 1;
        foreach (DataRow row in table.Rows)
        {
            for (int c = 0; c < table.Columns.Count; c++)
            {
                object val = row[c];
                ws.Cell(r, c + 1).Value = (val == null || val == DBNull.Value) ? "" : val.ToString();
            }
            r++;
        }

        if (footerValues != null && footerValues.Count > 0)
        {
            ws.Cell(r, 1).Value = "Total";
            ws.Cell(r, 1).Style.Font.Bold = true;
            for (int c = 1; c < table.Columns.Count; c++)
            {
                string val;
                footerValues.TryGetValue(table.Columns[c].ColumnName, out val);
                var cell = ws.Cell(r, c + 1);
                cell.Value = val ?? "";
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#eef2f5");
            }
            r++;
        }

        return r + 1; // leave a blank row before the next block
    }

    // A genuine .xlsx workbook via ClosedXML (already the standard for report
    // exports elsewhere in this codebase - see App_Code/Report/Export/Export_MIS_2.cs,
    // App_Code/Accounts/CHA/Cha_Accounts.cs). This used to hand-build an HTML
    // table and email it labelled as ".xls" (application/vnd.ms-excel) - that
    // "HTML content disguised as an Office document" mismatch is exactly the
    // pattern mail security gateways (e.g. Exchange/M365 Safe Attachments,
    // corporate AV filters) are built to silently quarantine before the message
    // ever reaches a mailbox - not even Junk - which is why Send Test Email Now
    // reported success ("Sent to ...") while nothing ever arrived. A real OOXML
    // workbook doesn't trip that heuristic.
    private static byte[] BuildExcelBytes(DataTable dt, List<string> groupColumnNames, List<Tuple<string, string>> summaryColumns)
    {
        using (var workbook = new XLWorkbook())
        {
            var ws = workbook.Worksheets.Add("Report");
            int row = 1;

            if (groupColumnNames.Count > 0)
            {
                var groups = dt.AsEnumerable()
                    .GroupBy(r => string.Join("", groupColumnNames.Select(c => r[c] as string ?? "")))
                    .ToList();

                if (groups.Count == 0)
                {
                    ws.Cell(row, 1).Value = "No matching job records found for the importer(s)/exporter(s) assigned to this template.";
                    row++;
                }

                foreach (var group in groups)
                {
                    DataTable groupDt = dt.Clone();
                    foreach (DataRow r in group) groupDt.ImportRow(r);

                    var keyParts = groupColumnNames.Select(c => groupDt.Rows[0][c] as string ?? "").ToList();
                    var labelParts = new List<string>();
                    for (int gi = 0; gi < groupColumnNames.Count; gi++)
                        labelParts.Add(groupColumnNames[gi] + ": " + (keyParts[gi].Length == 0 ? "(blank)" : keyParts[gi]));
                    string recordWord = groupDt.Rows.Count == 1 ? "record" : "records";

                    int bannerCols = Math.Max(1, groupDt.Columns.Count);
                    ws.Range(row, 1, row, bannerCols).Merge();
                    ws.Cell(row, 1).Value = string.Join("   |   ", labelParts) + " (" + groupDt.Rows.Count + " " + recordWord + ")";
                    ws.Range(row, 1, row, bannerCols).Style.Font.Bold = true;
                    ws.Range(row, 1, row, bannerCols).Style.Font.FontColor = XLColor.White;
                    ws.Range(row, 1, row, bannerCols).Style.Fill.BackgroundColor = XLColor.FromHtml("#1f3b57");
                    row++;

                    row = WriteReportBlock(ws, row, groupDt, ComputeAggregates(groupDt, summaryColumns));
                    groupDt.Dispose();
                }
            }
            else
            {
                WriteReportBlock(ws, row, dt, ComputeAggregates(dt, summaryColumns));
            }

            using (var ms = new MemoryStream())
            {
                workbook.SaveAs(ms);
                return ms.ToArray();
            }
        }
    }

    private static string GetTemplateName(SqlConnection conn, int templateId)
    {
        using (SqlCommand cmd = new SqlCommand("SELECT TemplateName FROM DSR_Template WHERE TemplateID = @T", conn))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            object result = cmd.ExecuteScalar();
            return result == null || result == DBNull.Value ? "Report" : result.ToString();
        }
    }

    // Mirrors TemplateBuilder.aspx.cs's copy of the same method (which computes
    // the same thing at save time, whenever the Day/Date/Time inputs change) -
    // works out the next moment a schedule should fire, on or after "from".
    private static DateTime ComputeNextRun(string frequency, TimeSpan time, int dayOfWeek, int dayOfMonth, DateTime from)
    {
        DateTime candidate;
        switch (frequency)
        {
            case "Weekly":
                candidate = from.Date.AddDays((dayOfWeek - (int)from.DayOfWeek + 7) % 7).Add(time);
                if (candidate <= from) candidate = candidate.AddDays(7);
                return candidate;

            case "Monthly":
                candidate = BuildMonthlyCandidate(from.Year, from.Month, dayOfMonth, time);
                if (candidate <= from)
                {
                    DateTime nextMonth = from.AddMonths(1);
                    candidate = BuildMonthlyCandidate(nextMonth.Year, nextMonth.Month, dayOfMonth, time);
                }
                return candidate;

            default: // Daily
                candidate = from.Date.Add(time);
                if (candidate <= from) candidate = candidate.AddDays(1);
                return candidate;
        }
    }

    private static DateTime BuildMonthlyCandidate(int year, int month, int day, TimeSpan time)
    {
        int clampedDay = Math.Min(day, DateTime.DaysInMonth(year, month));
        return new DateTime(year, month, clampedDay).Add(time);
    }

    // Sends via the same SMTP account this app already uses elsewhere
    // (smtp/sendmail.aspx.cs) - there are no mail settings in Web.config for
    // this app to read instead.
    private static void SendReportEmail(string toAddresses, string subject, byte[] excelBytes, string attachmentFileName)
    {
        using (var mail = new MailMessage())
        {
            foreach (var addr in toAddresses.Split(',').Select(a => a.Trim()).Where(a => a.Length > 0))
                mail.To.Add(addr);

            mail.From = new MailAddress("info@eroyalimpex.trade", "eRoyal Impex DSR Reports", Encoding.UTF8);
            mail.Subject = subject;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = "The attached DSR report was generated automatically per its Scheduled Generation settings.";
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = false;

            using (var ms = new System.IO.MemoryStream(excelBytes))
            {
                var attachment = new Attachment(ms, attachmentFileName, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                mail.Attachments.Add(attachment);

                var client = new SmtpClient
                {
                    Host = "mail.eroyalimpex.trade",
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("info@eroyalimpex.trade", "eroyalimpex176")
                };
                client.Send(mail);
            }
        }
    }

    // Shared by RunDueSchedules (the real scheduled run) and RunTemplateNow
    // (the Report Settings tab's "Send Test Email Now" button) - generates one
    // template's report and emails it, never throwing (failures come back on
    // the result instead) so a batch of schedules can't be taken down by one
    // bad template.
    private static RunResult GenerateAndSendOne(SqlConnection conn, int templateId, string recipients, string subjectPrefix)
    {
        var result = new RunResult { TemplateId = templateId };
        try
        {
            result.TemplateName = GetTemplateName(conn, templateId);

            if (string.IsNullOrWhiteSpace(recipients))
            {
                result.Success = false;
                result.Message = "No recipient emails configured.";
                return result;
            }

            List<string> groupColumnNames;
            List<Tuple<string, string>> summaryColumns;
            DataTable dt = BuildReportTable(conn, templateId, out groupColumnNames, out summaryColumns);
            byte[] excelBytes = BuildExcelBytes(dt, groupColumnNames, summaryColumns);

            string fileName = result.TemplateName.Replace(" ", "_") + ".xlsx";
            string subject = subjectPrefix + " - " + result.TemplateName + " - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            SendReportEmail(recipients, subject, excelBytes, fileName);

            result.Success = true;
            result.Message = "Sent to " + recipients;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = ex.Message;
        }
        return result;
    }

    // Report Settings tab -> Scheduled Generation -> "Send Test Email Now":
    // generates and sends immediately, using whatever RecipientEmails is
    // currently saved for the template (so Save Report Settings first).
    // Deliberately does not touch IsEnabled/NextRunAt/LastRunAt - it's a
    // one-off check, not a real scheduled run.
    public static RunResult RunTemplateNow(string connectionString, int templateId)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string recipients = null;
            using (var cmd = new SqlCommand(
                "SELECT RecipientEmails FROM DSR_ReportSchedule WHERE TemplateID = @T", conn))
            {
                cmd.Parameters.AddWithValue("@T", templateId);
                object val = cmd.ExecuteScalar();
                recipients = (val == null || val == DBNull.Value) ? null : val.ToString();
            }

            var result = GenerateAndSendOne(conn, templateId, recipients, "DSR Report (Test)");
            if (!result.Success && string.IsNullOrWhiteSpace(recipients))
                result.Message = "No recipient emails saved yet - enter them under Scheduled Generation and click Save Report Settings first.";
            return result;
        }
    }

    // Entry point for RunScheduledReports.ashx: for each connection string
    // given, finds every DSR_ReportSchedule row that's enabled and due
    // (NextRunAt IS NULL OR NextRunAt <= now), generates and emails that
    // template's report, then advances NextRunAt/LastRunAt regardless of
    // success so a permanently-broken schedule (e.g. a bad email address)
    // doesn't retry every time this runs.
    private class DueScheduleRow
    {
        public int TemplateId;
        public string Frequency;
        public TimeSpan ScheduleTime;
        public int DayOfWeek;
        public int DayOfMonth;
        public string RecipientEmails;
    }

    // Never put a full connection string (carries uid/pwd) into a RunResult -
    // RunScheduledReports.ashx echoes RunResult.Message/TemplateName back over
    // HTTP, and GetAllCompanyConnectionStrings() below now feeds this from a
    // system-wide list rather than a hand-picked one. Only "database=..." is
    // identifying and safe to surface.
    private static string SafeDbLabel(string connectionString)
    {
        var match = System.Text.RegularExpressions.Regex.Match(
            connectionString ?? "", @"database=([^;]+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        return match.Success ? match.Groups[1].Value : "(unknown database)";
    }

    private static bool TableExists(SqlConnection conn, string tableName)
    {
        using (var cmd = new SqlCommand(
            "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @T", conn))
        {
            cmd.Parameters.AddWithValue("@T", tableName);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }

    public static List<RunResult> RunDueSchedules(IEnumerable<string> connectionStrings)
    {
        var results = new List<RunResult>();

        foreach (var connString in connectionStrings.Where(c => !string.IsNullOrWhiteSpace(c)).Distinct())
        {
            // One bad/unreachable company database (or an older company DB that
            // predates the Template Builder feature and has no DSR_* tables at
            // all - GetAllCompanyConnectionStrings() below returns every company
            // this app knows about, not just ones that use this feature) must not
            // stop every other company's due schedules from running.
            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    if (!TableExists(conn, "DSR_ReportSchedule")) continue;

                    var due = new List<DueScheduleRow>();
                    using (var cmd = new SqlCommand(
                        @"SELECT TemplateID, Frequency, ScheduleTime, ScheduleDayOfWeek, ScheduleDayOfMonth, RecipientEmails
                          FROM DSR_ReportSchedule
                          WHERE IsEnabled = 1 AND (NextRunAt IS NULL OR NextRunAt <= GETDATE())", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TimeSpan scheduleTime;
                                if (!TimeSpan.TryParse(reader["ScheduleTime"].ToString(), out scheduleTime))
                                    scheduleTime = new TimeSpan(9, 0, 0);

                                due.Add(new DueScheduleRow
                                {
                                    TemplateId = Convert.ToInt32(reader["TemplateID"]),
                                    Frequency = reader["Frequency"].ToString(),
                                    ScheduleTime = scheduleTime,
                                    DayOfWeek = reader["ScheduleDayOfWeek"] == DBNull.Value ? (int)System.DayOfWeek.Monday : Convert.ToInt32(reader["ScheduleDayOfWeek"]),
                                    DayOfMonth = reader["ScheduleDayOfMonth"] == DBNull.Value ? 1 : Convert.ToInt32(reader["ScheduleDayOfMonth"]),
                                    RecipientEmails = reader["RecipientEmails"] == DBNull.Value ? "" : reader["RecipientEmails"].ToString()
                                });
                            }
                        }
                    }

                    foreach (var row in due)
                    {
                        int templateId = row.TemplateId;
                        var result = GenerateAndSendOne(conn, templateId, row.RecipientEmails, "DSR Report");

                        DateTime now = DateTime.Now;
                        using (var updCmd = new SqlCommand(
                            "UPDATE DSR_ReportSchedule SET LastRunAt = @Now, NextRunAt = @Next WHERE TemplateID = @T", conn))
                        {
                            updCmd.Parameters.AddWithValue("@Now", now);
                            updCmd.Parameters.AddWithValue("@Next", ComputeNextRun(row.Frequency, row.ScheduleTime, row.DayOfWeek, row.DayOfMonth, now));
                            updCmd.Parameters.AddWithValue("@T", templateId);
                            updCmd.ExecuteNonQuery();
                        }

                        results.Add(result);
                    }
                }
            }
            catch (Exception ex)
            {
                results.Add(new RunResult { TemplateId = 0, TemplateName = SafeDbLabel(connString), Success = false, Message = ex.Message });
            }
        }

        return results;
    }

    // Report Settings -> Scheduled Generation, unattended trigger: every company
    // database this app knows about, sourced from the same master registry
    // (ImpexLogin's SP_COMPANY_MASTER_SEARCH_SELECT, @name='Return_All_Database')
    // that builds Session["currentcomp_db"] at login (see Default.aspx.cs's
    // Bind_Group) - this call just doesn't filter by COMPANY_LICENSE, so it
    // returns all of them. This is what lets Global.asax's timer call
    // RunDueSchedules with no external scheduler and no per-company setup.
    public static List<string> GetAllCompanyConnectionStrings()
    {
        var comp = new Company_Master();
        comp.Ename = "Return_All_Database";
        DataSet ds = comp.RetrieveAll_Company_Details();

        var list = new List<string>();
        if (ds != null && ds.Tables.Count > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string connStr = row["SERVER_NAME"] == DBNull.Value ? null : row["SERVER_NAME"].ToString();
                if (!string.IsNullOrWhiteSpace(connStr)) list.Add(connStr);
            }
        }
        return list;
    }
}
