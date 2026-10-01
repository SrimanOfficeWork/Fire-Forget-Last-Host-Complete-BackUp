using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// Dashboard design ported in from E_royal_Impex_Dashboard_New.aspx.cs (KPI cards, mode-wise
// breakdown, KPI drill-down) - see the .aspx for the corresponding markup notes. This is the
// real "Home" page every cancel/close button across the app links back to.
public partial class LoginPage_Premium_E_royal_Impex_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_Chart();
            Load_Chart_ModeWise();
        }
    }

    private void Load_Chart()
    {
        Dashboard da = new Dashboard();
        da.Flag = "JOB_REPORT";
        DataSet ds = da.DASHBOARD_JOB_REPORT();

        // DASHBOARD_JOB_REPORT() swallows its own exceptions and returns an empty DataSet
        // (Tables.Count == 0) when the stored-proc call throws - e.g. a missing/expired
        // Session["currentcomp_db"] / Session["WorkingPeriod"] / Session["currentbranch"].
        // That's different from "the query ran fine but there's genuinely no data for this
        // period" (Tables.Count >= 1, just 0 rows). Surface the former case only, so it's
        // visible on the page instead of silently showing "No import/export data found".
        if (ds.Tables.Count == 0 && dashDiagBanner != null)
        {
            object compDb = Session["currentcomp_db"];
            object workingPeriod = Session["WorkingPeriod"];
            object branch = Session["currentbranch"];
            dashDiagBanner.Visible = true;
            // da.LastError is the actual ex.Message from the catch block in DASHBOARD_JOB_REPORT()
            // (see Dashboard.cs) - shown directly here instead of only pointing at ErrorLogs' log
            // file, since that file lives under THIS app's own "<site root>\logs\" folder (not the
            // hardcoded "D:\eroyalimpex2026\logs\" this message used to name, which doesn't exist
            // on this deployment) and was silently failing to write on a fresh deployment where
            // that folder didn't exist yet - so the real error had no trace anywhere before this.
            litDiag.Text = "Diagnostic: DASHBOARD_JOB_REPORT_SELECT returned no tables - the stored " +
                "procedure call threw and was caught in Dashboard.cs. Session[\"currentcomp_db\"]=" +
                (compDb == null ? "NULL" : "set") +
                ", Session[\"WorkingPeriod\"]=" + (workingPeriod == null ? "NULL" : Convert.ToString(workingPeriod)) +
                ", Session[\"currentbranch\"]=" + (branch == null ? "NULL" : Convert.ToString(branch)) +
                ". Exception: " + (string.IsNullOrEmpty(da.LastError) ? "(none captured)" : da.LastError);
        }

        // -------------------- IMPORT JOBS --------------------
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            var monthlyData = new Dictionary<string, Dictionary<string, object>>();
            var monthYears = new HashSet<string>();
            var importerNames = new HashSet<string>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string monthYear = Convert.ToString(row["MonthYear"]);
                string importerName = Convert.ToString(row["IMPORTER_NAME"]);

                // DASHBOARD_JOB_REPORT_SELECT_USERWISE_IEC_BASED_SEARCH's own grand-total row
                // (MonthYear="ALL" is a legitimate "all months" bucket per real importer - see
                // the ALL_<name> rows below - but MonthYear="ALL" + IMPORTER_NAME="ALL" together
                // is the SP's single combined total, not a real customer). Left in, this showed
                // up as a fake "ALL" customer whose count equals the grand total, always ranking
                // #1 in Top Customers and burying every real customer under it - same bug
                // Load_Chart_ModeWise() below already guards against via its own "TOTAL"/"TOTAL"
                // check, just under this SP's different naming convention.
                if (monthYear == "ALL" && importerName == "ALL")
                {
                    continue;
                }

                long CREATED_NO = Convert.ToInt64(row["CREATED_NO"]);
                long BE_SENT_NO = Convert.ToInt64(row["BE_SENT_NO"]);
                long CANCELLED_NO = Convert.ToInt64(row["CANCELLED_NO"]);
                long RECEIVED_NO = Convert.ToInt64(row["RECEIVED_NO"]);

                string key = monthYear + "_" + importerName;

                monthlyData[key] = new Dictionary<string, object>
                {
                    { "MonthYear", monthYear },
                    { "ImporterName", importerName },
                    { "Be_created_Jobs", CREATED_NO },
                    { "Be_sent_Jobs", BE_SENT_NO },
                    { "Be_Received_Jobs", RECEIVED_NO },
                    { "Be_cancelledJobs", CANCELLED_NO }
                };

                if (!string.IsNullOrEmpty(monthYear))
                    monthYears.Add(monthYear);

                if (!string.IsNullOrEmpty(importerName))
                    importerNames.Add(importerName);
            }

            string jsonData = JsonConvert.SerializeObject(monthlyData);
            string jsonMonthYears = JsonConvert.SerializeObject(monthYears);
            string jsonImporterNames = JsonConvert.SerializeObject(importerNames);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "jobData",
                string.Format("var jobData = {0};", jsonData), true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "monthYears",
                string.Format("var monthYears = {0};", jsonMonthYears), true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "importerNames",
                string.Format("var importerNames = {0};", jsonImporterNames), true);
        }

        // -------------------- EXPORT JOBS --------------------
        if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            var monthlyData_SB = new Dictionary<string, Dictionary<string, object>>();
            var monthYears_SB = new HashSet<string>();
            var exporterNames = new HashSet<string>();

            foreach (DataRow row1 in ds.Tables[1].Rows)
            {
                string monthYear_SB = Convert.ToString(row1["MonthYear"]);
                string exporterName = Convert.ToString(row1["EXPORTER_NAME"]);

                // Same grand-total exclusion as the import loop above - see its comment.
                if (monthYear_SB == "ALL" && exporterName == "ALL")
                {
                    continue;
                }

                long CREATED_NO = Convert.ToInt64(row1["CREATED_NO"]);
                long SB_SENT_NO = Convert.ToInt64(row1["SB_SENT_NO"]);
                long CANCELLED_NO = Convert.ToInt64(row1["CANCELLED_NO"]);
                long RECEIVED_NO = Convert.ToInt64(row1["RECEIVED_NO"]);

                string key_SB = monthYear_SB + "_" + exporterName;

                monthlyData_SB[key_SB] = new Dictionary<string, object>
                {
                    { "MonthYear", monthYear_SB },
                    { "ExporterName", exporterName },
                    { "SBCreatedJobs", CREATED_NO },
                    { "SB_SentJobs", SB_SENT_NO },
                    { "SBReceivedJobs", RECEIVED_NO },
                    { "SBcancelledJobs", CANCELLED_NO }
                };

                if (!string.IsNullOrEmpty(monthYear_SB))
                    monthYears_SB.Add(monthYear_SB);

                if (!string.IsNullOrEmpty(exporterName))
                    exporterNames.Add(exporterName);
            }

            string jsonData_SB = JsonConvert.SerializeObject(monthlyData_SB);
            string jsonMonthYears_SB = JsonConvert.SerializeObject(monthYears_SB);
            string jsonExporterNames = JsonConvert.SerializeObject(exporterNames);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "jobData_SB",
                string.Format("var jobData_SB = {0};", jsonData_SB), true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "monthYears_SB",
                string.Format("var monthYears_SB = {0};", jsonMonthYears_SB), true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "exporterNames",
                string.Format("var exporterNames = {0};", jsonExporterNames), true);
        }
    }

    // Month + Mode (Sea/Air/Land) + Importer/Exporter level counts, from
    // DASHBOARD_JOB_REPORT_MODEWISE_SELECT_NEW_02 (called with @MODE="" / @TYPE="BOTH" so it
    // returns every mode+type). Feeds window.jobDataMode / window.jobDataMode_SB, keyed
    // "<MonthYear>_<MODE>_<Name>", so the Mode filter (dashFilterMode) in the page header can
    // actually filter the "Top Customers by Shipments" list instead of being cosmetic. Field
    // names match jobData/jobData_SB on purpose so the JS side can reuse the same lookup code.
    //
    // _NEW_02 also appends one TOTAL row per table (MonthYear/IMPORTER_NAME or EXPORTER_NAME =
    // "TOTAL") and a TOTAL_NO column on every row. That TOTAL row is pulled out (not added to
    // jobDataMode - it isn't a real customer) to drive the KPI cards, and TOTAL_NO on the
    // per-name rows is summed by MODE and by month (via SortKey) to drive the Shipment
    // Breakdown tiles, the Shipment Share by Mode donut, and the month-over-month Growth %.
    private void Load_Chart_ModeWise()
    {
        Dashboard da = new Dashboard();
        DataSet ds = da.DASHBOARD_JOB_REPORT_MODEWISE();

        // Diagnostic: the SP itself is confirmed working when called with a real
        // Branch+WorkingPeriod combo from SSMS - if the app-driven call (Session-based
        // Connection.Current_Branch()/Connection.WorkingPeriod()) comes back with 0 rows
        // in both tables, show exactly what values were used so they can be checked
        // directly against GENERAL_DETAILS/EXPORT_GENERAL_DETAILS in SSMS.
        bool importHasRows = ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0;
        bool exportHasRows = ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0;
        if (!importHasRows && !exportHasRows && dashDiagBanner != null)
        {
            dashDiagBanner.Visible = true;
            if (ds.Tables.Count == 0 && !string.IsNullOrEmpty(da.LastError))
            {
                // Same "call threw and was caught" case as Load_Chart() above - da.LastError
                // is the real ex.Message, not just "0 rows", so don't send the user chasing an
                // SSMS row-count query for data that was never queried in the first place.
                litDiag.Text = "Diagnostic (Mode-wise): DASHBOARD_JOB_REPORT_MODEWISE_SELECT threw and was " +
                    "caught in Dashboard.cs. Connection.Current_Branch()=\"" + Connection.Current_Branch() +
                    "\", Connection.WorkingPeriod()=\"" + Connection.WorkingPeriod() + "\". Exception: " + da.LastError;
            }
            else
            {
                litDiag.Text = "Diagnostic (Mode-wise): DASHBOARD_JOB_REPORT_MODEWISE_SELECT ran but returned " +
                    "0 rows in both tables. Values used - Connection.Current_Branch()=\"" + Connection.Current_Branch() +
                    "\", Connection.WorkingPeriod()=\"" + Connection.WorkingPeriod() + "\". Run in SSMS: " +
                    "SELECT COUNT(*) FROM GENERAL_DETAILS WHERE BRANCHCODE='" + Connection.Current_Branch() +
                    "' AND WORKINGPERIOD='" + Connection.WorkingPeriod() + "' - if that's 0 too, the session's " +
                    "WorkingPeriod doesn't match what's actually stored against this branch's jobs.";
            }
        }

        string jobDataModeJson, jobDataModeSbJson, dashKpiJson, dashModeBreakdownJson, dashTrendJson;
        BuildModeWiseJson(ds, out jobDataModeJson, out jobDataModeSbJson, out dashKpiJson, out dashModeBreakdownJson, out dashTrendJson);

        if (jobDataModeJson != null)
            Page.ClientScript.RegisterStartupScript(this.GetType(), "jobDataMode",
                string.Format("var jobDataMode = {0};", jobDataModeJson), true);

        if (jobDataModeSbJson != null)
            Page.ClientScript.RegisterStartupScript(this.GetType(), "jobDataMode_SB",
                string.Format("var jobDataMode_SB = {0};", jobDataModeSbJson), true);

        // Only emitted when there's at least some data - otherwise leave the markup's own
        // 0 defaults alone, so a failed/empty fetch reads as 0 (next to the diagnostic
        // banner) instead of showing stale numbers.
        if (dashKpiJson != null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "dashKpi",
                string.Format("var dashKpi = {0};", dashKpiJson), true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "dashModeBreakdown",
                string.Format("var dashModeBreakdown = {0};", dashModeBreakdownJson), true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "dashTrend",
                string.Format("var dashTrend = {0};", dashTrendJson ?? "[]"), true);
        }

        // NAK Status card - see Dashboard.IMPORT_NAK_ACK_PENDING_COUNT()'s comment. Initial
        // load always uses @MODE="" (all modes), same as the DASHBOARD_JOB_REPORT_MODEWISE()
        // call above it.
        Dashboard daNak = new Dashboard();
        int nakStatusCount = daNak.IMPORT_NAK_ACK_PENDING_COUNT("");
        Page.ClientScript.RegisterStartupScript(this.GetType(), "dashNakStatusCount",
            string.Format("var dashNakStatusCount = {0};", nakStatusCount), true);

        // Query Reply card - see GetQueryReplyResolvedCount()'s comment (counts only the BE Nos
        // that actually resolve to a Job No, same set the drill-down table shows - not the raw
        // dbo.IMPORT_QUERY_PENDING_SEARCH row count). Same Import-only, @MODE="" initial-load
        // treatment as the NAK Status card above.
        int queryReplyCount = GetQueryReplyResolvedCount("");
        Page.ClientScript.RegisterStartupScript(this.GetType(), "dashQueryReplyCount",
            string.Format("var dashQueryReplyCount = {0};", queryReplyCount), true);

        // IGM Regularised card - see Dashboard.IMPORT_REGULARISED_PENDING_COUNT()'s comment.
        // Same Import-only, @MODE="" initial-load treatment as the NAK Status card above.
        Dashboard daReg = new Dashboard();
        int igmRegularisedCount = daReg.IMPORT_REGULARISED_PENDING_COUNT("");
        Page.ClientScript.RegisterStartupScript(this.GetType(), "dashIgmRegularisedCount",
            string.Format("var dashIgmRegularisedCount = {0};", igmRegularisedCount), true);
    }

    // Called from the page header's Mode (dashFilterMode) / Import-Export (dashFilterType)
    // dropdowns via PageMethods, so choosing a filter re-runs DASHBOARD_JOB_REPORT_MODEWISE_
    // SELECT_NEW_02 with that exact @MODE/@TYPE instead of just re-filtering the all-mode/
    // both-type dataset already sitting in the browser. Returns one pre-built JSON object
    // (as a string, so the client just JSON.parse()s it) with jobDataMode/jobDataMode_SB (for
    // the Top Customers list) and dashKpi/dashModeBreakdown (for the KPI cards, Shipment
    // Breakdown tiles and Mode Share donut) - see applyRealDashboardData() in the .aspx.
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GetModeWiseDashboardData(string mode, string type)
    {
        string sp_mode = string.IsNullOrEmpty(mode) ? "" : mode.Trim().ToUpperInvariant();
        string sp_type = string.IsNullOrEmpty(type) ? "BOTH" : type.Trim().ToUpperInvariant();

        Dashboard da = new Dashboard();
        DataSet ds = da.DASHBOARD_JOB_REPORT_MODEWISE(sp_mode, sp_type);

        string jobDataModeJson, jobDataModeSbJson, dashKpiJson, dashModeBreakdownJson, dashTrendJson;
        BuildModeWiseJson(ds, out jobDataModeJson, out jobDataModeSbJson, out dashKpiJson, out dashModeBreakdownJson, out dashTrendJson);

        // NAK Status card is Import-only (dbo.IMPORT_NAK_ACK_PENDING_SEARCH) - skip the extra
        // SP call when "Export" is selected, since the card is hidden then anyway (see
        // applyImportOnlyCardsVisibility() in the .aspx).
        int nakStatusCount = 0;
        // Query Reply / IGM Regularised cards are Import-only too (dbo.IMPORT_QUERY_PENDING_
        // SEARCH / dbo.IMPORT_REGULARISED_PENDING_SEARCH) - same skip as NAK Status when
        // "Export" is selected (applyImportOnlyCardsVisibility() hides them).
        int queryReplyCount = 0;
        int igmRegularisedCount = 0;
        if (!string.Equals(sp_type, "EXPORT", StringComparison.OrdinalIgnoreCase))
        {
            Dashboard daNak = new Dashboard();
            nakStatusCount = daNak.IMPORT_NAK_ACK_PENDING_COUNT(sp_mode);

            // See GetQueryReplyResolvedCount()'s comment - counts only the BE Nos that resolve to
            // a Job No, matching the drill-down table instead of the raw SP row count.
            queryReplyCount = GetQueryReplyResolvedCount(sp_mode);

            Dashboard daReg = new Dashboard();
            igmRegularisedCount = daReg.IMPORT_REGULARISED_PENDING_COUNT(sp_mode);
        }

        return string.Format(
            "{{\"jobDataMode\":{0},\"jobDataMode_SB\":{1},\"dashKpi\":{2},\"dashModeBreakdown\":{3},\"dashTrend\":{4},\"nakStatusCount\":{5},\"queryReplyCount\":{6},\"igmRegularisedCount\":{7}}}",
            jobDataModeJson ?? "{}",
            jobDataModeSbJson ?? "{}",
            dashKpiJson ?? "null",
            dashModeBreakdownJson ?? "null",
            dashTrendJson ?? "[]",
            nakStatusCount,
            queryReplyCount,
            igmRegularisedCount);
    }

    // Shared by Load_Chart_ModeWise() (initial page load, @MODE=""/@TYPE="BOTH") and
    // GetModeWiseDashboardData() (AJAX re-fetch on filter change) so both paths build the
    // KPI/breakdown numbers identically. Any of the four out values is null when its table
    // had no data to build it from (Tables.Count/Rows.Count == 0, or - for the KPI/breakdown
    // pair - no TOTAL/detail rows survived at all).
    private static void BuildModeWiseJson(DataSet ds, out string jobDataModeJson, out string jobDataModeSbJson,
        out string dashKpiJson, out string dashModeBreakdownJson, out string dashTrendJson)
    {
        jobDataModeJson = null; jobDataModeSbJson = null; dashKpiJson = null; dashModeBreakdownJson = null; dashTrendJson = null;

        // _NEW_02 only returns the Import table when @TYPE is IMPORT/BOTH, and only the Export
        // table when @TYPE is EXPORT/BOTH - so when @TYPE="EXPORT", ds.Tables[0] IS the export
        // table (it has EXPORTER_NAME, not IMPORTER_NAME). Picking by column presence instead
        // of a fixed [0]=import/[1]=export index keeps this correct for every @TYPE value.
        DataTable importTable = null, exportTable = null;
        foreach (DataTable t in ds.Tables)
        {
            if (t.Columns.Contains("IMPORTER_NAME")) importTable = t;
            else if (t.Columns.Contains("EXPORTER_NAME")) exportTable = t;
        }

        bool importHasRows = importTable != null && importTable.Rows.Count > 0;
        bool exportHasRows = exportTable != null && exportTable.Rows.Count > 0;

        long impCreated = 0, impSent = 0, impReceived = 0, impCancelled = 0, impTotal = 0, impOoc = 0;
        long expCreated = 0, expSent = 0, expReceived = 0, expCancelled = 0, expTotal = 0, expLeo = 0;
        var modeTypeTotals = new Dictionary<string, long>();  // "IMPORT_SEA" / "EXPORT_AIR" / ... -> summed TOTAL_NO
        var monthTotals = new Dictionary<string, long>();     // SortKey ("yyyy-MM") -> summed TOTAL_NO (import+export)
        var monthModeTotals = new Dictionary<string, long>(); // SortKey + "_" + MODE -> summed TOTAL_NO (import+export combined)
        var monthLabels = new Dictionary<string, string>();   // SortKey -> display MonthYear label (for the Shipments Trend chart)

        // -------------------- IMPORT, BY MODE --------------------
        if (importHasRows)
        {
            var modeData = new Dictionary<string, Dictionary<string, object>>();

            foreach (DataRow row in importTable.Rows)
            {
                string monthYear = Convert.ToString(row["MonthYear"]);
                string importerName = Convert.ToString(row["IMPORTER_NAME"]);

                long CREATED_NO = Convert.ToInt64(row["CREATED_NO"]);
                long BE_SENT_NO = Convert.ToInt64(row["BE_SENT_NO"]);
                long CANCELLED_NO = Convert.ToInt64(row["CANCELLED_NO"]);
                long RECEIVED_NO = Convert.ToInt64(row["RECEIVED_NO"]);
                long TOTAL_NO = Convert.ToInt64(row["TOTAL_NO"]);
                // OOC_NO is only present once the SP has been updated to join
                // BE_STATUS_TRACKING_AUTOMATION (see the OOC/LEO SQL script) - guard with
                // Columns.Contains so this page doesn't break against the older SP.
                long OOC_NO = importTable.Columns.Contains("OOC_NO") ? Convert.ToInt64(row["OOC_NO"]) : 0;

                // The SP's own grand-total row - not a real importer, pull it out for the KPI cards.
                if (monthYear == "TOTAL" && importerName == "TOTAL")
                {
                    impCreated = CREATED_NO; impSent = BE_SENT_NO;
                    impReceived = RECEIVED_NO; impCancelled = CANCELLED_NO; impTotal = TOTAL_NO;
                    impOoc = OOC_NO;
                    continue;
                }

                // Normalized to uppercase here (not just for monthModeTotals below) since
                // the client always looks up jobDataMode with mode.toUpperCase() (see
                // getFilteredSortedRows() in the .aspx) - the raw MODE column value from
                // SQL is Title Case ("Sea"/"Air"/"Land", same convention as elsewhere in
                // this app, e.g. Admin_IMP_EXP_Prefix_Suffix.aspx.cs's Mode == "Air" checks),
                // so building the key/modeTypeTotals off the raw value silently produced 0
                // shipments for every customer the instant a Sea/Air/Land filter was picked.
                string mode = Convert.ToString(row["MODE"]).ToUpperInvariant();
                string sortKey = Convert.ToString(row["SortKey"]);
                string key = monthYear + "_" + mode + "_" + importerName;

                // Same importer can legitimately appear on more than one row for the
                // same MonthYear+MODE (e.g. split across branch/currency/job-type in the
                // SP's own grouping) - accumulate into the existing entry instead of
                // overwriting it, or a collision here silently drops that row's counts
                // and the per-party breakdown undercounts against the SP's own TOTAL row.
                Dictionary<string, object> existing;
                if (modeData.TryGetValue(key, out existing))
                {
                    existing["Be_created_Jobs"] = (long)existing["Be_created_Jobs"] + CREATED_NO;
                    existing["Be_sent_Jobs"] = (long)existing["Be_sent_Jobs"] + BE_SENT_NO;
                    existing["Be_Received_Jobs"] = (long)existing["Be_Received_Jobs"] + RECEIVED_NO;
                    existing["Be_cancelledJobs"] = (long)existing["Be_cancelledJobs"] + CANCELLED_NO;
                    existing["Total_NO"] = (long)existing["Total_NO"] + TOTAL_NO;
                }
                else
                {
                    modeData[key] = new Dictionary<string, object>
                    {
                        { "Be_created_Jobs", CREATED_NO },
                        { "Be_sent_Jobs", BE_SENT_NO },
                        { "Be_Received_Jobs", RECEIVED_NO },
                        { "Be_cancelledJobs", CANCELLED_NO },
                        { "Total_NO", TOTAL_NO }
                    };
                }

                AddTo(modeTypeTotals, "IMPORT_" + mode, TOTAL_NO);
                AddTo(monthTotals, sortKey, TOTAL_NO);
                AddTo(monthModeTotals, sortKey + "_" + mode, TOTAL_NO);
                if (!string.IsNullOrEmpty(sortKey) && !monthLabels.ContainsKey(sortKey)) monthLabels[sortKey] = monthYear;
            }

            jobDataModeJson = JsonConvert.SerializeObject(modeData);
        }

        // -------------------- EXPORT, BY MODE --------------------
        if (exportHasRows)
        {
            var modeData_SB = new Dictionary<string, Dictionary<string, object>>();

            foreach (DataRow row1 in exportTable.Rows)
            {
                string monthYear_SB = Convert.ToString(row1["MonthYear"]);
                string exporterName = Convert.ToString(row1["EXPORTER_NAME"]);

                long CREATED_NO = Convert.ToInt64(row1["CREATED_NO"]);
                long SB_SENT_NO = Convert.ToInt64(row1["SB_SENT_NO"]);
                long CANCELLED_NO = Convert.ToInt64(row1["CANCELLED_NO"]);
                long RECEIVED_NO = Convert.ToInt64(row1["RECEIVED_NO"]);
                long TOTAL_NO = Convert.ToInt64(row1["TOTAL_NO"]);
                // Same Columns.Contains guard as the import side above - LEO_NO is only
                // present once the SP joins the export-side OOC/LEO tracking table.
                long LEO_NO = exportTable.Columns.Contains("LEO_NO") ? Convert.ToInt64(row1["LEO_NO"]) : 0;

                if (monthYear_SB == "TOTAL" && exporterName == "TOTAL")
                {
                    expCreated = CREATED_NO; expSent = SB_SENT_NO;
                    expReceived = RECEIVED_NO; expCancelled = CANCELLED_NO; expTotal = TOTAL_NO;
                    expLeo = LEO_NO;
                    continue;
                }

                // See the import-side mode normalization comment above - same fix, export side.
                string mode_SB = Convert.ToString(row1["MODE"]).ToUpperInvariant();
                string sortKey_SB = Convert.ToString(row1["SortKey"]);
                string key_SB = monthYear_SB + "_" + mode_SB + "_" + exporterName;

                // Same accumulate-on-collision fix as the import loop above - see its
                // comment. This is what was causing the drill-down grid's summed total
                // to fall short of the "Total Shipments" KPI card by however many
                // shipments belonged to a row that got silently overwritten.
                Dictionary<string, object> existing_SB;
                if (modeData_SB.TryGetValue(key_SB, out existing_SB))
                {
                    existing_SB["SBCreatedJobs"] = (long)existing_SB["SBCreatedJobs"] + CREATED_NO;
                    existing_SB["SB_SentJobs"] = (long)existing_SB["SB_SentJobs"] + SB_SENT_NO;
                    existing_SB["SBReceivedJobs"] = (long)existing_SB["SBReceivedJobs"] + RECEIVED_NO;
                    existing_SB["SBcancelledJobs"] = (long)existing_SB["SBcancelledJobs"] + CANCELLED_NO;
                    existing_SB["Total_NO"] = (long)existing_SB["Total_NO"] + TOTAL_NO;
                }
                else
                {
                    modeData_SB[key_SB] = new Dictionary<string, object>
                    {
                        { "SBCreatedJobs", CREATED_NO },
                        { "SB_SentJobs", SB_SENT_NO },
                        { "SBReceivedJobs", RECEIVED_NO },
                        { "SBcancelledJobs", CANCELLED_NO },
                        { "Total_NO", TOTAL_NO }
                    };
                }

                AddTo(modeTypeTotals, "EXPORT_" + mode_SB, TOTAL_NO);
                AddTo(monthTotals, sortKey_SB, TOTAL_NO);
                AddTo(monthModeTotals, sortKey_SB + "_" + mode_SB, TOTAL_NO);
                if (!string.IsNullOrEmpty(sortKey_SB) && !monthLabels.ContainsKey(sortKey_SB)) monthLabels[sortKey_SB] = monthYear_SB;
            }

            jobDataModeSbJson = JsonConvert.SerializeObject(modeData_SB);
        }

        // -------------------- KPI CARDS / SHIPMENT BREAKDOWN / MODE SHARE (real totals) --------------------
        if (importHasRows || exportHasRows)
        {
            double? growthPct = null;
            var sortedMonths = new List<string>(monthTotals.Keys);
            sortedMonths.Sort(StringComparer.Ordinal);
            if (sortedMonths.Count >= 2)
            {
                long latest = monthTotals[sortedMonths[sortedMonths.Count - 1]];
                long prior = monthTotals[sortedMonths[sortedMonths.Count - 2]];
                if (prior > 0) growthPct = Math.Round(((double)(latest - prior) / prior) * 100.0, 1);
            }

            // Total Shipments must equal the sum of the 5 KPI cards shown underneath it
            // (Created + BE/SB Sent + BE/SB Received + OOC/LEO Received + Cancelled) so the
            // headline figure always reconciles with what the cards add up to on screen -
            // rather than impTotal+expTotal (the SP's own grand-total row), which doesn't
            // include OOC/LEO Received since that's summed in separately from a different table.
            long draftJobs = impCreated + expCreated;
            long sentJobs = impSent + expSent;
            long receivedJobs = impReceived + expReceived;
            long cancelledJobs = impCancelled + expCancelled;
            long oocLeoJobs = impOoc + expLeo;
            long totalShipments = draftJobs + sentJobs + receivedJobs + oocLeoJobs + cancelledJobs;

            var dashKpi = new Dictionary<string, object>
            {
                { "totalShipments", totalShipments },
                { "draftJobs", draftJobs },
                { "sentJobs", sentJobs },
                { "receivedJobs", receivedJobs },
                { "cancelledJobs", cancelledJobs },
                { "oocLeoJobs", oocLeoJobs },
                { "growthPct", growthPct }
            };

            var dashModeBreakdown = new Dictionary<string, object>
            {
                { "airImport", GetFrom(modeTypeTotals, "IMPORT_AIR") },
                { "airExport", GetFrom(modeTypeTotals, "EXPORT_AIR") },
                { "seaImport", GetFrom(modeTypeTotals, "IMPORT_SEA") },
                { "seaExport", GetFrom(modeTypeTotals, "EXPORT_SEA") },
                { "landImport", GetFrom(modeTypeTotals, "IMPORT_LAND") },
                { "landExport", GetFrom(modeTypeTotals, "EXPORT_LAND") }
            };

            dashKpiJson = JsonConvert.SerializeObject(dashKpi);
            dashModeBreakdownJson = JsonConvert.SerializeObject(dashModeBreakdown);

            // -------------------- SHIPMENTS TREND (last 12 months, Sea/Air/Land, import+export combined) --------------------
            // Reuses sortedMonths (SortKey "yyyy-MM", already sorted ascending above) and
            // monthModeTotals/monthLabels populated in the IMPORT/EXPORT loops. Feeds the
            // "Shipments Trend (Last 12 Months)" bar chart - see renderShipmentsTrend() in the .aspx.
            var trendMonths = sortedMonths.Count > 12
                ? sortedMonths.GetRange(sortedMonths.Count - 12, 12)
                : sortedMonths;
            var dashTrend = new List<Dictionary<string, object>>();
            foreach (var sk in trendMonths)
            {
                dashTrend.Add(new Dictionary<string, object>
                {
                    { "sortKey", sk },
                    { "month", monthLabels.ContainsKey(sk) ? monthLabels[sk] : sk },
                    { "sea", GetFrom(monthModeTotals, sk + "_SEA") },
                    { "air", GetFrom(monthModeTotals, sk + "_AIR") },
                    { "land", GetFrom(monthModeTotals, sk + "_LAND") }
                });
            }
            dashTrendJson = JsonConvert.SerializeObject(dashTrend);
        }
    }

    // NAK Status drill-down (importExtraCard row) - clicking the card calls this for the real
    // pending rows behind its count, JOB_NO + File_Remarks only (per the card's own request -
    // dbo.IMPORT_NAK_ACK_PENDING_SEARCH itself returns every emailsread column, this just
    // narrows the JSON sent to the browser to the two the panel actually shows). Small dataset
    // (pending NAK mails), so unlike GetKpiDrilldownJobsPage below there's no paging contract -
    // the whole matching set is fetched and returned in one call; see loadNakStatusDrilldown()
    // in the .aspx for the DataTables client-side paging on top of it.
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GetNakStatusPendingJobs(string mode)
    {
        Dashboard da = new Dashboard();
        DataSet ds = da.IMPORT_NAK_ACK_PENDING_SEARCH(mode);

        var rows = new List<Dictionary<string, object>>();
        if (ds.Tables.Count > 0)
        {
            DataTable t = ds.Tables[0];
            bool hasDisplayJobNo = t.Columns.Contains("DISPLAY_JOB_NO");
            bool hasRemarks = t.Columns.Contains("File_Remarks");
            // JOBID isn't part of this SP's result set, only JOB_NO/File_Remarks - so it's
            // resolved lazily per click via GetImportJobId() below instead of here, which would
            // otherwise mean one extra heavy Import_General_Grid_Search call PER ROW on every
            // list load/refresh (slow, and wasted for every row the user never opens). See
            // openImportDrilldownJob() in the .aspx for the click-time resolve-then-open flow.
            bool hasJobId = t.Columns.Contains("JOBID");
            foreach (DataRow r in t.Rows)
            {
                string jobNo = hasDisplayJobNo ? Convert.ToString(r["DISPLAY_JOB_NO"])
                               : (t.Columns.Contains("JOB_NO") ? Convert.ToString(r["JOB_NO"]) : "");

                rows.Add(new Dictionary<string, object>
                {
                    { "jobId", hasJobId ? Convert.ToString(r["JOBID"]) : "" },
                    { "jobNo", jobNo },
                    { "fileRemarks", hasRemarks ? Convert.ToString(r["File_Remarks"]) : "" }
                });
            }
        }
        return JsonConvert.SerializeObject(rows);
    }

    // IGM Regularised drill-down (importExtraCard row) - clicking the card calls this for the
    // real pending rows behind its count, JOBNO_PS + FILING_STATUS only (per the card's own
    // request), from dbo.IMPORT_REGULARISED_PENDING_SEARCH. Same small-dataset,
    // fetch-everything-in-one-call shape as GetNakStatusPendingJobs() above - see
    // loadIgmRegularisedDrilldown() in the .aspx for the DataTables client-side paging on top.
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GetIgmRegularisedPendingJobs(string mode)
    {
        Dashboard da = new Dashboard();
        DataSet ds = da.IMPORT_REGULARISED_PENDING_SEARCH(mode);

        var rows = new List<Dictionary<string, object>>();
        if (ds.Tables.Count > 0)
        {
            DataTable t = ds.Tables[0];
            bool hasJobNo = t.Columns.Contains("JOBNO_PS");
            bool hasFilingStatus = t.Columns.Contains("FILING_STATUS");
            // Same reasoning as GetNakStatusPendingJobs() above - JOBID isn't part of this SP's
            // result set, so it's resolved lazily per click via GetImportJobId() instead of here.
            bool hasJobId = t.Columns.Contains("JOBID");
            foreach (DataRow r in t.Rows)
            {
                rows.Add(new Dictionary<string, object>
                {
                    { "jobId", hasJobId ? Convert.ToString(r["JOBID"]) : "" },
                    { "jobNo", hasJobNo ? Convert.ToString(r["JOBNO_PS"]) : "" },
                    { "filingStatus", hasFilingStatus ? Convert.ToString(r["FILING_STATUS"]) : "" }
                });
            }
        }
        return JsonConvert.SerializeObject(rows);
    }

    // Query Reply drill-down (importExtraCard row) - clicking the card calls this for the real
    // pending rows behind its count, from dbo.IMPORT_QUERY_PENDING_SEARCH. That SP only carries a
    // BE_NO (Bill of Entry number) per pending query mail, not a Job No, so each row's BE_NO is
    // resolved to its Job No/JOBID via the same exact BE No lookup Transaction/General_Search.aspx's
    // own search performs (SEARCH_CAT="BE_NO") - see ResolveImportJobBySearch() below. Same
    // small-dataset, fetch-everything-in-one-call shape as GetNakStatusPendingJobs()/
    // GetIgmRegularisedPendingJobs() above - see loadQueryReplyDrilldown() in the .aspx.
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GetQueryReplyPendingJobs(string mode)
    {
        return JsonConvert.SerializeObject(GetResolvedQueryReplyRows(mode));
    }

    // Shared by GetQueryReplyPendingJobs() (the drill-down table) and GetQueryReplyResolvedCount()
    // (the card's own number) so both agree on exactly the same set of rows - a BE_NO that
    // doesn't resolve to a Job No is excluded from both, not just hidden from the table while
    // still counted on the card.
    private static List<Dictionary<string, object>> GetResolvedQueryReplyRows(string mode)
    {
        Dashboard da = new Dashboard();
        DataSet ds = da.IMPORT_QUERY_PENDING_SEARCH(mode);

        var rows = new List<Dictionary<string, object>>();
        if (ds.Tables.Count > 0)
        {
            DataTable t = ds.Tables[0];
            bool hasBeNo = t.Columns.Contains("BE_NO");
            var beNos = new string[t.Rows.Count];
            var resolved = new Dictionary<string, string>[t.Rows.Count];
            for (int i = 0; i < t.Rows.Count; i++)
            {
                beNos[i] = hasBeNo ? Convert.ToString(t.Rows[i]["BE_NO"]) : "";
            }

            // Unlike NAK/IGM's jobId (only ever needed on click), the Job No here has to be shown
            // as a column value up front, so it can't be deferred to click-time the way those two
            // are - but doing all these lookups one at a time was the slowest of the three
            // drill-down loads (each one its own Import_General_Grid_Search round-trip), wide
            // enough a window for the user to re-open the card before the first load finished and
            // trip DataTables' duplicate-init bug (see loadQueryReplyDrilldown()'s isDataTable
            // guard in the .aspx for the actual fix for that). Resolving them concurrently - same
            // HttpContext-propagation trick EnsureSideBuffered's own Parallel.For needs, since
            // Import_General_Grid_Search reads HttpContext.Current.Session - cuts this down to
            // roughly one round-trip's worth of wall-clock time instead of one per row.
            var callerContext = HttpContext.Current;
            Parallel.For(0, beNos.Length, new ParallelOptions { MaxDegreeOfParallelism = KPI_DRILLDOWN_BATCH_SIZE }, i =>
            {
                HttpContext.Current = callerContext;
                resolved[i] = ResolveImportJobBySearch("BE_NO", beNos[i]);
            });

            for (int i = 0; i < beNos.Length; i++)
            {
                // Skip BE Nos that didn't resolve to a Job No (no matching Import job found for
                // that BE_NO via ResolveImportJobBySearch) - showing a row with an empty Job No
                // isn't useful and the row click would have nothing to open anyway.
                if (string.IsNullOrEmpty(resolved[i]["jobNo"])) continue;

                rows.Add(new Dictionary<string, object>
                {
                    { "jobId", resolved[i]["jobId"] },
                    { "jobNo", resolved[i]["jobNo"] },
                    { "beNo", beNos[i] }
                });
            }
        }
        return rows;
    }

    // The Query Reply card's own count - the same resolved-rows set GetQueryReplyPendingJobs()
    // hands the drill-down table, not the raw dbo.IMPORT_QUERY_PENDING_SEARCH row count
    // (Dashboard.IMPORT_QUERY_PENDING_COUNT()), so the card's number always matches how many rows
    // actually show up when it's clicked open instead of also counting BE Nos that don't resolve
    // to a Job No.
    private static int GetQueryReplyResolvedCount(string mode)
    {
        return GetResolvedQueryReplyRows(mode).Count;
    }

    // Resolves one Job No -> internal JOBID on demand (row click), the same exact-match lookup
    // Transaction/General_Search.aspx's plain search performs (SEARCH_CAT="JOB_NO") against
    // Import_General_Grid_Search. Called from openImportDrilldownJob() in the .aspx - shared by
    // both the NAK Status and IGM Regularised drill-downs - only when their own PageMethod
    // (GetNakStatusPendingJobs()/GetIgmRegularisedPendingJobs()) didn't already have JOBID for
    // that row. Keeps this heavy SP call to at most one per click instead of one per row on
    // every list load.
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GetImportJobId(string jobNo)
    {
        return ResolveImportJobBySearch("JOB_NO", jobNo)["jobId"];
    }

    // Shared exact-match lookup against Import_General_Grid_Search - the same job-list source
    // Transaction/General_Search.aspx uses for its own ddlTerms search (JOB_NO/BE_NO/INV_NO/...).
    // Returns both jobId (JOBID) and jobNo (JOBNO_PS) from the first matching row so a single
    // call can satisfy either "resolve this Job No's JOBID" (GetImportJobId) or "resolve this BE
    // No's Job No AND JOBID" (GetQueryReplyPendingJobs) without duplicating the lookup.
    private static Dictionary<string, string> ResolveImportJobBySearch(string searchCat, string searchItem)
    {
        var result = new Dictionary<string, string> { { "jobId", "" }, { "jobNo", "" } };
        if (string.IsNullOrEmpty(searchItem)) return result;
        try
        {
            var imp = new Import_General_Grid_Search();
            imp.SEARCH_CAT = searchCat;
            imp.SEARCH_ITEM = searchItem;
            imp.IMPORTER_NAME = ""; imp.TRANSPORT_MODE = ""; imp.CUSTOMS_HOUSE = ""; imp.BE_TYPE = "";
            imp.startRowIndex = "1"; imp.maximumRows = "10"; imp.Selected_Index = "1";
            DataSet dsJob = imp.IMP_General_Search();
            if (dsJob != null && dsJob.Tables.Count > 0 && dsJob.Tables[0].Rows.Count > 0)
            {
                DataTable t = dsJob.Tables[0];
                DataRow row = t.Rows[0];
                if (t.Columns.Contains("JOBID")) result["jobId"] = Convert.ToString(row["JOBID"]);
                if (t.Columns.Contains("JOBNO_PS")) result["jobNo"] = Convert.ToString(row["JOBNO_PS"]);
                else if (t.Columns.Contains("JOBNO")) result["jobNo"] = Convert.ToString(row["JOBNO"]);
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return result;
    }

    private static void AddTo(Dictionary<string, long> dict, string key, long value)
    {
        long existing;
        dict[key] = (dict.TryGetValue(key, out existing) ? existing : 0) + value;
    }

    private static long GetFrom(Dictionary<string, long> dict, string key)
    {
        long value;
        return dict.TryGetValue(key, out value) ? value : 0;
    }

    // ============================================================
    // KPI DRILL-DOWN GRID - server-side (lazy) pagination
    // ============================================================
    // Called from the DataTables `ajax` function on the KPI drill-down grid (see
    // initKpiDrilldownDataTable() in the .aspx) to list the actual jobs behind whichever card
    // was clicked, so each row can be clicked through to that job's real popup -
    // General_Details_Update()/Export_General_Update() in js/iframepopupwin.js, which only take
    // a JOBID. window.jobDataMode/_SB (used by the rest of this page) only carry aggregate
    // counts per Importer/Exporter/Month, not individual job rows, so this reuses the same
    // job-list source Transaction/General_Search.aspx and Export/General_Search.aspx already
    // use (Import_General_Grid_Search.IMP_General_Search() / Export_General_Grid_Search.
    // EXP_General_Search()).
    //
    // Neither that SP nor its export counterpart supports filtering by JOB_FILED_STATUS
    // server-side - confirmed against Transaction/General_Search.aspx.cs's own ddlTerms
    // (SEARCH_CAT's valid values are JOB_NO/INV_NO/CON_NO/... free-text categories, no
    // "Status" option exists). It only supports fetching an arbitrary page NUMBER
    // (@Selected_Index, fixed 23 rows/page, ordered JOBNO DESC) - General_Search's own
    // page-number dropdown (Add_Pageno/ddlSelectPageno_SelectedIndexChanged) jumps straight to
    // any @Selected_Index with no requirement to have fetched earlier pages first, confirming
    // it's true random access, not a sequential cursor. So "find the jobs with status X" can
    // only be done by walking pages and checking each row's JOB_FILED_STATUS in C#, same as
    // before.
    //
    // What changed is WHEN that walk happens. The previous version eagerly walked up to
    // KPI_DRILLDOWN_ROW_CAP matches the instant a card was clicked, which is what made
    // companies with 20k-50k jobs slow even after parallelizing the page fetches - the whole
    // drill-down had to finish before a single row could render. This version walks ONLY as
    // far as needed to satisfy the specific page DataTables just asked for
    // (KpiDrilldownSideCursor below), remembering progress in a short-lived
    // per-(session, side, mode, metric, search) cache so paging forward resumes instead of
    // re-scanning from page 1, and re-visiting an already-explored page is instant. A card
    // click now only ever pays for the first ~10 rows' worth of page-walking, regardless of
    // whether the true match count is 40 or 40,000.
    //
    // Free-text search (the DataTables search box) is wired straight into IMPORTER_NAME/
    // EXPORTER_NAME - a real server-side filter the SP already supports (General_Search.aspx.cs
    // uses the identical field for its own party-name search) - rather than being limited to
    // whatever's already been walked, so searching for a party name still narrows at the
    // SP/SQL level instead of only searching rows already in the cursor's buffer.
    private class KpiDrilldownSideCursor
    {
        public List<Dictionary<string, object>> Matched = new List<Dictionary<string, object>>();
        public int NextSpPage = 1;
        public int SpTotalPages = int.MaxValue; // unknown until the first page reports it
        public bool Exhausted = false;
    }

    // Safety cap on how many pages (of the SP's fixed @PageSize=23) a single cursor will walk
    // in its lifetime - bounds worst case (e.g. a metric that matches nothing, forcing a full
    // scan) to ~11,500 jobs instead of looping unbounded against a runaway/huge dataset.
    private const int KPI_DRILLDOWN_MAX_PAGES = 500;

    // A cursor stops accumulating matches once it hits this many, even if not yet Exhausted -
    // otherwise a user paging deep into a 50k-job "Total Shipments" grid could still eventually
    // force a walk of the entire dataset one page at a time. 1000 rows (~44 SP pages) is enough
    // headroom that no realistic drill-down session actually reaches it.
    private const int KPI_DRILLDOWN_ROW_CAP = 1000;

    // Pages fetched concurrently per batch when a cursor needs to walk further - see
    // EnsureSideBuffered below. Bounded rather than firing every remaining page at once so a
    // metric that matches almost nothing (forcing a walk toward KPI_DRILLDOWN_MAX_PAGES) can't
    // flood the DB connection pool with hundreds of simultaneous SP calls.
    private const int KPI_DRILLDOWN_BATCH_SIZE = 24;

    private static string[] GetMatchStatuses(bool isImport, string metric)
    {
        // JOB_FILED_STATUS values, confirmed from General_Search.aspx.cs / Export_General_
        // Search.aspx.cs's own row-coloring logic - Import goes through BE (Bill of Entry)
        // stages (Created/BE_Sent/BE_Recipt/OOC_Recvd/Cancelled), Export through SB (Shipping
        // Bill) stages (Created/SB_Sent/SB_Recipt/LEO_Recvd/Cancelled). These 5 values are each
        // job's single CURRENT status (mutually exclusive), and together are exactly the 5
        // buckets summed into the "Total Shipments" KPI (see totalShipments in BuildModeWiseJson).
        string wantStatus = null;
        if (!string.IsNullOrEmpty(metric) && metric != "total")
        {
            if (metric == "draft") wantStatus = "Created";
            else if (metric == "sent") wantStatus = isImport ? "BE_Sent" : "SB_Sent";
            else if (metric == "received") wantStatus = isImport ? "BE_Recipt" : "SB_Recipt";
            else if (metric == "oocleo") wantStatus = isImport ? "OOC_Recvd" : "LEO_Recvd";
            else if (metric == "cancelled") wantStatus = "Cancelled";
        }
        if (wantStatus != null) return new[] { wantStatus };

        // "total" (no specific metric) must show exactly the jobs that make up the "Total
        // Shipments" KPI number - i.e. the union of the 5 buckets above - not literally every
        // row the SP returns. Without this, any job sitting in a JOB_FILED_STATUS value outside
        // those 5 (a stray/legacy/in-between status) would show up here even though it isn't
        // counted in any of the 5 KPI cards or their sum.
        return isImport
            ? new[] { "Created", "BE_Sent", "BE_Recipt", "OOC_Recvd", "Cancelled" }
            : new[] { "Created", "SB_Sent", "SB_Recipt", "LEO_Recvd", "Cancelled" };
    }

    // Export's "oocleo" filters on its own exact "LEO_Recvd" JOB_FILED_STATUS value, same as
    // Import's "OOC_Recvd". This aggregate recheck is a safety net against the two data sources
    // (this page-walk vs. the KPI card's own DASHBOARD_JOB_REPORT_MODEWISE aggregate) drifting
    // out of sync - when it comes back a CONFIRMED 0, the cursor is marked Exhausted up front
    // instead of paying for a page-walk that would find nothing, or worse, a mismatch against
    // the card (e.g. a job that's Received but not yet OOC/LEO-cleared, Land+Import). If the
    // recheck itself fails or returns no tables (kpiJson == null - Dashboard.cs swallows the SP
    // exception and hands back an empty DataSet), that is NOT the same as a confirmed 0 - don't
    // let a failed recheck masquerade as "no data" and blank out rows the KPI card itself shows
    // a non-zero count for.
    private static bool IsOocLeoConfirmedZero(bool isImport, string mode)
    {
        string oocLeoSpMode = string.IsNullOrEmpty(mode) ? "" : mode.Trim().ToUpperInvariant();
        string oocLeoSpType = isImport ? "IMPORT" : "EXPORT";

        Dashboard daOocLeo = new Dashboard();
        DataSet dsOocLeo = daOocLeo.DASHBOARD_JOB_REPORT_MODEWISE(oocLeoSpMode, oocLeoSpType);

        string ignoreJobDataMode, ignoreJobDataModeSb, kpiJson, ignoreBreakdown, ignoreTrend;
        BuildModeWiseJson(dsOocLeo, out ignoreJobDataMode, out ignoreJobDataModeSb, out kpiJson, out ignoreBreakdown, out ignoreTrend);
        if (kpiJson == null) return false;

        long realOocLeoCount = JObject.Parse(kpiJson).Value<long?>("oocLeoJobs") ?? 0;
        return realOocLeoCount == 0;
    }

    // The exact match count for a card - i.e. the same number the KPI card itself shows -
    // straight from DASHBOARD_JOB_REPORT_MODEWISE (the fast, non-paginated aggregate SP that
    // already powers the 6 KPI cards - see Load_Chart()/Load_Chart_ModeWise()), rather than
    // whatever a lazy cursor happens to have accumulated so far. Without this, the drill-down's
    // "recordsFiltered" was only ever a padded ESTIMATE (accumulated-so-far + one page) until a
    // cursor happened to walk far enough to become Exhausted, which for a common status like
    // "Total Shipments" or "Received" - the ones a user is most likely to open first - could sit
    // visibly below the card's real number for several page-turns (e.g. card says 560, drill-down
    // badge briefly says "56+"). This call is cheap (a single aggregate query, not a page-walk),
    // so it's fine to make on every request rather than caching it - same "always trust the live
    // number" spirit as IsOocLeoConfirmedZero above. Returns null (caller falls back to the
    // lazy-cursor estimate) when there's no free-text search to match against - the aggregate SP
    // has no concept of the DataTables search box, only status/mode/type.
    private static long? GetAuthoritativeMatchCount(string metric, string type, string mode)
    {
        string field;
        if (string.IsNullOrEmpty(metric) || metric == "total") field = "totalShipments";
        else if (metric == "draft") field = "draftJobs";
        else if (metric == "sent") field = "sentJobs";
        else if (metric == "received") field = "receivedJobs";
        else if (metric == "oocleo") field = "oocLeoJobs";
        else if (metric == "cancelled") field = "cancelledJobs";
        else return null;

        string spMode = string.IsNullOrEmpty(mode) ? "" : mode.Trim().ToUpperInvariant();
        string spType = string.Equals(type, "import", StringComparison.OrdinalIgnoreCase) ? "IMPORT"
            : string.Equals(type, "export", StringComparison.OrdinalIgnoreCase) ? "EXPORT"
            : "BOTH"; // DASHBOARD_JOB_REPORT_MODEWISE's own default (see Dashboard.cs) when both sides are wanted

        Dashboard da = new Dashboard();
        DataSet ds = da.DASHBOARD_JOB_REPORT_MODEWISE(spMode, spType);

        string ignoreJobDataMode, ignoreJobDataModeSb, kpiJson, ignoreBreakdown, ignoreTrend;
        BuildModeWiseJson(ds, out ignoreJobDataMode, out ignoreJobDataModeSb, out kpiJson, out ignoreBreakdown, out ignoreTrend);
        if (kpiJson == null) return null;

        return JObject.Parse(kpiJson).Value<long?>(field);
    }

    // dd/MM/yyyy first (the format JOBDATE actually comes back as - see the "31/08/2026" style
    // dates rendered in the grid), falling back to a general parse for anything else; MinValue
    // (sorts last) if neither works, same "don't crash on a weird value" spirit as the rest of
    // this file's Convert.ToString() guards.
    private static DateTime ParseJobDate(object jobDateObj)
    {
        string s = jobDateObj as string;
        if (string.IsNullOrEmpty(s)) return DateTime.MinValue;
        DateTime d;
        if (DateTime.TryParseExact(s, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d)) return d;
        if (DateTime.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.None, out d)) return d;
        return DateTime.MinValue;
    }

    private static string CursorCacheKey(string side, string mode, string metric, string search)
    {
        return "KpiDDCur_" + HttpContext.Current.Session.SessionID + "_" + side + "_" + mode + "_" + metric + "_" + (search ?? "");
    }

    private static KpiDrilldownSideCursor GetOrCreateCursor(string side, bool isImport, string mode, string metric, string search)
    {
        var cur = HttpRuntime.Cache.Get(CursorCacheKey(side, mode, metric, search)) as KpiDrilldownSideCursor;
        if (cur != null) return cur;

        cur = new KpiDrilldownSideCursor();
        if (string.Equals(metric, "oocleo", StringComparison.OrdinalIgnoreCase) && IsOocLeoConfirmedZero(isImport, mode))
            cur.Exhausted = true;
        return cur;
    }

    private static void SaveCursor(string side, string mode, string metric, string search, KpiDrilldownSideCursor cur)
    {
        // Sliding, not absolute - stays warm for as long as the user keeps paging through THIS
        // card within the window, without pinning a company's job list in memory indefinitely
        // once they've moved on.
        HttpRuntime.Cache.Insert(CursorCacheKey(side, mode, metric, search), cur, null,
            System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));
    }

    // Walks additional SP pages (in concurrent batches - see KPI_DRILLDOWN_BATCH_SIZE) for ONE
    // side until its cursor has at least `want` matching rows buffered, or it genuinely runs out
    // (Exhausted) or hits KPI_DRILLDOWN_ROW_CAP. Pages are independent, stateless SP calls keyed
    // only by @Selected_Index, so HttpContext.Current has to be propagated onto each
    // Parallel.For worker thread by hand: Import_General_Grid_Search/Export_General_Grid_Search
    // read HttpContext.Current.Session (the signed-in user's per-company DB connection string,
    // branch, etc. - see Connection.cs), and thread-pool threads don't inherit the request's
    // HttpContext automatically the way the original request thread does.
    private static void EnsureSideBuffered(KpiDrilldownSideCursor cur, bool isImport, string spMode, string[] matchStatuses, string search, int want)
    {
        if (cur.Exhausted || cur.Matched.Count >= want) return;
        var callerContext = HttpContext.Current;
        string nameCol = isImport ? "IMPORTER_NAME" : "EXPORTER_NAME";

        // Starts at 1 page (or 4 - see below) and grows x6 each round, capped at
        // KPI_DRILLDOWN_BATCH_SIZE - NOT a flat KPI_DRILLDOWN_BATCH_SIZE from the first round. A
        // first card click only wants 10 rows, and most statuses ("total", "received", etc.) fill
        // that from page 1 alone (23 rows/page); firing a full 24-page concurrent batch for that
        // would fetch ~550 rows to satisfy a 10-row request - measured 4.9s for what should be one
        // ~0.3-0.8s SP call, and it happened to walk the entire side to Exhausted in the process.
        //
        // A single-status metric (draft/sent/received/oocleo/cancelled - matchStatuses.Length==1,
        // vs. "total"'s 5-status union) or an active free-text search is far less likely to be
        // satisfied by page 1 alone on a company with tens of thousands of jobs - each is
        // typically a small slice of the whole table, so ramping from 1 page the same slow way as
        // "total" just adds extra sequential round-trips (each one bounded by the slowest SP call
        // in that round) before reaching real concurrency. Starting those two cases at 4 pages
        // instead reaches the same KPI_DRILLDOWN_BATCH_SIZE cap two rounds sooner - same total SP
        // calls in the end, just fewer round-trips to get there - at the cost of a few more
        // (parallel, so ~free latency-wise) pages fetched on the rare case a single-status metric
        // turns out to be common after all.
        int batchSize = (matchStatuses.Length == 1 || !string.IsNullOrEmpty(search)) ? 4 : 1;
        while (!cur.Exhausted && cur.Matched.Count < want && cur.Matched.Count < KPI_DRILLDOWN_ROW_CAP)
        {
            int lastPage = Math.Min(cur.SpTotalPages, KPI_DRILLDOWN_MAX_PAGES);
            if (cur.NextSpPage > lastPage) { cur.Exhausted = true; break; }

            int batchStart = cur.NextSpPage;
            int batchEnd = Math.Min(batchStart + batchSize - 1, lastPage);
            batchSize = Math.Min(batchSize * 6, KPI_DRILLDOWN_BATCH_SIZE);
            var pageData = new DataTable[batchEnd - batchStart + 1];
            var pageTotals = new int[batchEnd - batchStart + 1];

            Parallel.For(batchStart, batchEnd + 1, new ParallelOptions { MaxDegreeOfParallelism = KPI_DRILLDOWN_BATCH_SIZE }, p =>
            {
                HttpContext.Current = callerContext;
                if (isImport)
                {
                    var Imp = new Import_General_Grid_Search();
                    // Free-text search is matched locally against every displayed column (see
                    // RowMatchesSearch below), not pushed into IMPORTER_NAME here - the SP has no
                    // way to filter by JOB_NO/mode/date/status at once, and restricting via
                    // IMPORTER_NAME alone would silently hide a Job No/Mode/Status/Date match
                    // whose party name doesn't happen to contain the search text too.
                    Imp.SEARCH_CAT = ""; Imp.SEARCH_ITEM = ""; Imp.IMPORTER_NAME = "";
                    Imp.TRANSPORT_MODE = spMode; Imp.CUSTOMS_HOUSE = "";
                    Imp.startRowIndex = "1"; Imp.maximumRows = "10000"; // unused by the SP body, but it's a required param
                    Imp.Selected_Index = p.ToString();
                    DataSet ds = Imp.IMP_General_Search();
                    pageData[p - batchStart] = ds != null && ds.Tables.Count > 0 ? ds.Tables[0] : null;
                    pageTotals[p - batchStart] = Imp.result;
                }
                else
                {
                    var Exp = new Export_General_Grid_Search();
                    // Same reasoning as the Import branch above - leave EXPORTER_NAME empty and
                    // let RowMatchesSearch match the free text against every displayed column.
                    Exp.SEARCH_CAT = ""; Exp.SEARCH_ITEM = ""; Exp.EXPORTER_NAME = "";
                    Exp.TRANSPORT_MODE = spMode; Exp.CUSTOMS_HOUSE = "";
                    Exp.startRowIndex = "1"; Exp.maximumRows = "10000";
                    Exp.Selected_Index = p.ToString();
                    DataSet ds = Exp.EXP_General_Search();
                    pageData[p - batchStart] = ds != null && ds.Tables.Count > 0 ? ds.Tables[0] : null;
                    pageTotals[p - batchStart] = Exp.result;
                }
            });

            for (int i = 0; i < pageData.Length; i++)
            {
                if (pageTotals[i] > 0) cur.SpTotalPages = pageTotals[i]; // @totalRows OUTPUT = page count, same for every page of the same query
                var dt = pageData[i];
                if (dt == null || dt.Rows.Count == 0) continue;
                bool hasStatusCol = dt.Columns.Contains("JOB_FILED_STATUS");
                foreach (DataRow r in dt.Rows)
                {
                    string status = hasStatusCol ? Convert.ToString(r["JOB_FILED_STATUS"]) : "";
                    if (Array.IndexOf(matchStatuses, status) < 0) continue;

                    var row = new Dictionary<string, object>
                    {
                        { "jobId", dt.Columns.Contains("JOBID") ? Convert.ToString(r["JOBID"]) : "" },
                        { "jobNo", dt.Columns.Contains("JOBNO_PS") ? Convert.ToString(r["JOBNO_PS"])
                                   : (dt.Columns.Contains("JOBNO") ? Convert.ToString(r["JOBNO"]) : "") },
                        { "jobDate", dt.Columns.Contains("JOBDATE") ? Convert.ToString(r["JOBDATE"]) : "" },
                        { "partyName", dt.Columns.Contains(nameCol) ? Convert.ToString(r[nameCol]) : "" },
                        { "mode", dt.Columns.Contains("TRANSPORT_MODE") ? Convert.ToString(r["TRANSPORT_MODE"]) : "" },
                        { "status", status },
                        { "type", isImport ? "Import" : "Export" }
                    };
                    // Matches the DataTables search box against every column the grid actually
                    // shows (Job No, Type, Party Name, Mode, Job Date, Status) - same "type any
                    // visible value, it filters" behavior as the NAK Status table's client-side
                    // search, just done here since this grid's data isn't all loaded client-side.
                    if (!string.IsNullOrEmpty(search) && !RowMatchesSearch(row, search)) continue;
                    cur.Matched.Add(row);
                }
            }
            cur.NextSpPage = batchEnd + 1;
            if (cur.NextSpPage > Math.Min(cur.SpTotalPages, KPI_DRILLDOWN_MAX_PAGES)) cur.Exhausted = true;
        }
    }

    // Case-insensitive substring match against every column the KPI drill-down grid displays
    // (Job No, Type, Party Name, Mode, Job Date, Status) - see EnsureSideBuffered above, which
    // skips a row entirely when this returns false rather than pushing the search text into a
    // single SQL column filter.
    private static readonly string[] KpiDrilldownSearchableFields = { "jobNo", "type", "partyName", "mode", "jobDate", "status" };
    private static bool RowMatchesSearch(Dictionary<string, object> row, string search)
    {
        foreach (string field in KpiDrilldownSearchableFields)
        {
            object value;
            if (row.TryGetValue(field, out value) && value != null
                && Convert.ToString(value).IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return true;
            }
        }
        return false;
    }

    // DataTables' serverSide-processing contract: called once per draw (initial load, every
    // page turn, every search-box keystroke after its debounce, every card switch) via
    // initKpiDrilldownDataTable()'s `ajax` function in the .aspx. `start`/`length` are the
    // requested row window (0-based); `search` is the free-text box's current value.
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GetKpiDrilldownJobsPage(string type, string mode, string metric, string search, int start, int length)
    {
        string spMode = string.IsNullOrEmpty(mode)
            ? ""
            : char.ToUpperInvariant(mode[0]) + mode.Substring(1).ToLowerInvariant();
        bool wantImport = !string.Equals(type, "export", StringComparison.OrdinalIgnoreCase);
        bool wantExport = !string.Equals(type, "import", StringComparison.OrdinalIgnoreCase);
        if (length <= 0) length = 10;
        int want = start + length;

        KpiDrilldownSideCursor importCur = wantImport ? GetOrCreateCursor("import", true, mode, metric, search) : null;
        KpiDrilldownSideCursor exportCur = wantExport ? GetOrCreateCursor("export", false, mode, metric, search) : null;

        // Import and Export are two completely independent SP page-walks (see EnsureSideBuffered)
        // - when a card has no Import/Export filter (the common "Total Shipments"-style click),
        // both sides need buffering, and running them one after the other was paying their full
        // latency twice in a row for no reason. Running them side by side on the thread pool
        // (same HttpContext-propagation trick EnsureSideBuffered's own Parallel.For already needs,
        // since Import_General_Grid_Search/Export_General_Grid_Search read HttpContext.Current.
        // Session) cuts wall-clock time roughly in half for that case without doing any extra work
        // - same total SP calls either way.
        var callerContext = HttpContext.Current;
        var sideTasks = new List<Task>();
        if (importCur != null)
        {
            var localImportCur = importCur;
            sideTasks.Add(Task.Run(() => { HttpContext.Current = callerContext; EnsureSideBuffered(localImportCur, true, spMode, GetMatchStatuses(true, metric), search, want); }));
        }
        if (exportCur != null)
        {
            var localExportCur = exportCur;
            sideTasks.Add(Task.Run(() => { HttpContext.Current = callerContext; EnsureSideBuffered(localExportCur, false, spMode, GetMatchStatuses(false, metric), search, want); }));
        }
        if (sideTasks.Count > 0) Task.WaitAll(sideTasks.ToArray());

        // k-way (k=2) merge by JOBDATE desc, matching the app's existing "newest first"
        // ordering. Both cursors were just buffered up to `want` above (or are Exhausted with
        // genuinely fewer real matches than that), so this never needs to go back for more
        // mid-merge - it's a single linear pass.
        var merged = new List<Dictionary<string, object>>();
        int ii = 0, ei = 0;
        while (merged.Count < want)
        {
            bool importHas = importCur != null && ii < importCur.Matched.Count;
            bool exportHas = exportCur != null && ei < exportCur.Matched.Count;
            if (!importHas && !exportHas) break;
            if (importHas && !exportHas) { merged.Add(importCur.Matched[ii++]); continue; }
            if (!importHas && exportHas) { merged.Add(exportCur.Matched[ei++]); continue; }
            DateTime di = ParseJobDate(importCur.Matched[ii]["jobDate"]);
            DateTime de = ParseJobDate(exportCur.Matched[ei]["jobDate"]);
            merged.Add(di >= de ? importCur.Matched[ii++] : exportCur.Matched[ei++]);
        }

        if (importCur != null) SaveCursor("import", mode, metric, search, importCur);
        if (exportCur != null) SaveCursor("export", mode, metric, search, exportCur);

        // recordsFiltered drives DataTables' "Showing X to Y of Z jobs" footer, the badge next
        // to the Close button, and how many pagination buttons it draws - this is what the KPI
        // card's own number gets compared against, so it needs to MATCH the card, not just be a
        // lower bound. When there's no free-text search active, GetAuthoritativeMatchCount gives
        // the exact number straight from the same fast aggregate SP the card itself reads -
        // available immediately, no page-walking required. Without this, the count only grew as
        // the lazy cursor happened to buffer more (e.g. card says 560, drill-down badge reads
        // "56+" for several page-turns until enough pages had been walked) - correct in the
        // limit, but visibly LESS than the card the whole time it hadn't caught up yet, which is
        // exactly the mismatch this fixes. Search has no equivalent fast aggregate (the SP has no
        // concept of it), so that case keeps the previous accumulated-so-far + one-page padding.
        long? authoritative = string.IsNullOrEmpty(search) ? GetAuthoritativeMatchCount(metric, type, mode) : null;
        bool fullyExhausted = (importCur == null || importCur.Exhausted) && (exportCur == null || exportCur.Exhausted);
        int trueTotalIfKnown = (importCur != null ? importCur.Matched.Count : 0) + (exportCur != null ? exportCur.Matched.Count : 0);
        bool haveExactTotal = authoritative.HasValue || fullyExhausted;
        int recordsFiltered = authoritative.HasValue ? (int)authoritative.Value
            : fullyExhausted ? trueTotalIfKnown
            : Math.Max(merged.Count, trueTotalIfKnown) + length;

        var pageRows = merged.Skip(start).Take(length).ToList();

        var result = new Dictionary<string, object>
        {
            { "recordsTotal", recordsFiltered },
            { "recordsFiltered", recordsFiltered },
            { "data", pageRows },
            { "exhausted", haveExactTotal }
        };
        return JsonConvert.SerializeObject(result);
    }
}
