using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using System.Globalization;

public partial class Acc_Rpt_Dashboard : ThemeClass
{
    AppSession aps = new AppSession();
    Pdf_Dashboard Pdf_Das = new Pdf_Dashboard();
    Global_variables ObjUBO = new Global_variables();
    protected DataTable RecentJobsTable;
    public string VendorChartData { get; set; }
    public string VendorLabels { get; set; }
    public string AvgAccuracy { get; set; }
    public string MonthLabels = "";
    public string ImportCounts = "";
    public string ExportCounts = "", Working_Period = "", COMPANY_ID = "";
    public string UploadChartJson = "{}";
    public string XAxisTitle = "Month";
    int totalDays;
    eroyalmaster erm = new eroyalmaster();
    private static readonly string[] VENDOR_CHART_COMPANY_IDS =
    {
        "ERI00001",
    }; /* "ERI00010" To list as admin for vendor chart*/

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            VendorChartData = "[]";

            Working_Period = Session["WorkingPeriod"].ToString();
            COMPANY_ID = Connection.Company_License();
            SetVendorOrLatestJobsVisibility();

            if (!IsPostBack)
            {
                DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime end = DateTime.Now;

                txtDateRange.Text = start.ToString("dd-MMM-yyyy") + " - " + end.ToString("dd-MMM-yyyy");

                Company_dropdown();

                LoadCombinedDashboard();

                if (IsVendorChartCompany())
                {
                    LoadVendorAccuracy();
                }
                else
                {
                    LoadLatestJobs("Latest_Jobs_ALL");
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void Company_dropdown()
    {
        try
        {
            DataSet ds = new DataSet();

            ObjUBO.A1 = Working_Period;
            ObjUBO.A2 = COMPANY_ID;
            ObjUBO.A3 = "";
            ObjUBO.A4 = "";
            ObjUBO.A5 = "";
            ObjUBO.A6 = "";
            ObjUBO.A7 = "BLIND_CLIENT";

            ds = Pdf_Das.OCR_Dashboard_DATA_Fetch(ObjUBO);

            // Only show the dropdown for ERI00001 if you need for 10 add here
            if (COMPANY_ID.Trim().ToUpper() == "ERI00001")  /* || COMPANY_ID.Trim().ToUpper() == "ERI00010" */
            {
                ddlCompany.Visible = true;
                ddlCompany.DataSource = ds.Tables[0];
                ddlCompany.DataTextField = "CLIENT_NAME";
                ddlCompany.DataValueField = "CLIENT_NAME";
                ddlCompany.DataBind();
                ddlCompany.Items.Insert(0, new ListItem("All Company", "All Company"));
            }
            else
            {
                ddlCompany.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    private bool IsVendorChartCompany()
    {
        return VENDOR_CHART_COMPANY_IDS.Contains(COMPANY_ID.Trim().ToUpper());
    }

    private void SetVendorOrLatestJobsVisibility()
    {
        bool showVendorChart = IsVendorChartCompany();

        pnlVendorChart.Visible = showVendorChart;
        pnlLatestJobs.Visible = !showVendorChart;

        ltrVendorOrJobsTitle.Text = showVendorChart
            ? "Vendor Wise Page Count"
            : "Latest Jobs";
    }

    private void LoadLatestJobs(string flag)
    {
        try
        {
            erm.Ename = flag;

            DataSet ds = erm.Export_Report_Master_OCR();

            gvLatestJobs.DataSource =
                ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0
                ? ds.Tables[0]
                : null;

            gvLatestJobs.DataBind();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void LoadLatestJobsWithDashboard(string flag)
    {
        filterview();
        LoadLatestJobs(flag);
    }

    protected void lnkJobsAll_Click(object sender, EventArgs e)
    {
        LoadLatestJobsWithDashboard("Latest_Jobs_ALL");
    }

    protected void lnkJobsImp_Click(object sender, EventArgs e)
    {
        LoadLatestJobsWithDashboard("Latest_Jobs_IMP");
    }

    protected void lnkJobsExp_Click(object sender, EventArgs e)
    {
        LoadLatestJobsWithDashboard("Latest_Jobs_EXP");
    }

    protected string GetStatusCss(object statusObj)
    {
        string status = Convert.ToString(statusObj).Trim().ToUpper();

        if (status == "PREVIEW SUCCESS" || status == "UPLOAD SUCCESS" || status == "PREVIEW INITIATED")
        {
            return "status-pill status-success";
        }

        if (status == "PREVIEW FAILED" || status == "UPLOAD FAILED")
        {
            return "status-pill status-failed";
        }

        return "status-pill status-neutral";
    }
    private void LoadVendorAccuracy()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.Append("[");
        sb.Append("{");
        sb.Append("label: 'PMDG', data: [0, 150], borderColor: getRandomColor(), fill: false, tension: 0.3");
        sb.Append("},");

        sb.Append("{");
        sb.Append("label: 'Docker Vision', data: [0, 220], borderColor: getRandomColor(), fill: false, tension: 0.3");
        sb.Append("}");
        sb.Append("]");

        VendorChartData = sb.ToString();
    }
    private DataTable LoadCombined(string workingPeriod, string companyLicense)
    {
        DataTable dtFinal = new DataTable();

        /* Only show the dropdown for ERI00001 if you need for 10 add here for Multi Sever, Multi Db Connectivity*/
        if (COMPANY_ID.Trim().ToUpper() == "ERI00001")  /* || COMPANY_ID.Trim().ToUpper() == "ERI00010" */
        {
            DataSet ds = new DataSet();

            ObjUBO.A1 = Working_Period;
            ObjUBO.A2 = COMPANY_ID;
            ObjUBO.A3 = "";
            ObjUBO.A4 = "";
            ObjUBO.A5 = "";
            ObjUBO.A6 = "";
            ObjUBO.A7 = "FETCH_NAME";

            ds = Pdf_Das.OCR_Dashboard_Company_Details_List(ObjUBO);

            DataTable dtDBs = new DataTable();

            if (ds != null && ds.Tables.Count > 0)
            {
                dtDBs = ds.Tables[0];
            }

            foreach (DataRow row in dtDBs.Rows)
            {
                try
                {
                    string connStr =
                        "Server=" + row["SERVER_NAME"].ToString() +
                        ";Database=" + row["DATABASE_NAME"].ToString() +
                        ";User Id=" + row["LOGIN_NAME"].ToString() +
                        ";Password=" + row["PWD"].ToString() + ";";

                    using (SqlConnection dbCon = new SqlConnection(connStr))
                    {
                        dbCon.Open();

                        string query = @"
                            SELECT PDF_JOB_NO,PDF_EXP_IMP_NAME,PDF_MODE,PDF_UPLOAD_COUNT,PDF_JOB_DELETED,PDF_REMARKS," +
                            "CASE WHEN UPPER(PDF_USER_ID) = 'RTS' THEN 'TEST' ELSE PDF_USER_ID END AS PDF_USER_ID,PDF_DATE_TIME,PDF_STATUS,PDF_JOB_DELETED,PDF_ERROR_COUNT," +
                            "PDF_PROCESS_STATUS,PDF_SUCCESS_COUNT,PDF_VENDOR FROM PDF_AI_COUNT_DETAILS";

                        DataTable dtTemp = new DataTable();

                        using (SqlDataAdapter dbDa = new SqlDataAdapter(query, dbCon))
                        {
                            dbDa.Fill(dtTemp);
                        }

                        if (dtFinal.Columns.Count == 0)
                        {
                            dtFinal = dtTemp.Clone();

                            if (!dtFinal.Columns.Contains("DATABASE_NAME"))
                                dtFinal.Columns.Add("DATABASE_NAME");

                            if (!dtFinal.Columns.Contains("COMPANY_LICENSE"))
                                dtFinal.Columns.Add("COMPANY_LICENSE");
                        }

                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            DataRow newRow = dtFinal.NewRow();

                            foreach (DataColumn col in dtTemp.Columns)
                            {
                                newRow[col.ColumnName] = dr[col.ColumnName];
                            }

                            newRow["DATABASE_NAME"] = row["DATABASE_NAME"].ToString();
                            newRow["COMPANY_LICENSE"] = row["COMPANY_LICENSE"].ToString();

                            dtFinal.Rows.Add(newRow);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Connection.Error_Msg(ex.Message);
                }
            }
        }
        else
        {
            DataSet dss = new DataSet();

            erm.Ename = "Client Fetch";

            dss = erm.Export_Report_Master_OCR();

            if (dss != null &&
                dss.Tables.Count > 0 &&
                dss.Tables[0].Rows.Count > 0)
            {
                dtFinal = dss.Tables[0].Copy();

                if (!dtFinal.Columns.Contains("COMPANY_LICENSE"))
                {
                    dtFinal.Columns.Add("COMPANY_LICENSE");
                }

                string companyId = COMPANY_ID;

                foreach (DataRow dr in dtFinal.Rows)
                {
                    dr["COMPANY_LICENSE"] = companyId;
                }
            }
        }

        ViewState["dtFinal"] = dtFinal;
        return dtFinal;
    }

    private void LoadCombinedDashboard()
    {
            try
            {
            string Company_ids = "", dateRange;

            dateRange = txtDateRange.Text.Trim();
            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MaxValue;

            if (!string.IsNullOrEmpty(dateRange))
            {
                string[] dates = dateRange.Split(new string[] { " - " }, StringSplitOptions.None);

                if (dates.Length == 2)
                {
                    fromDate = DateTime.ParseExact(dates[0].Trim(), "dd-MMM-yyyy", CultureInfo.InvariantCulture);

                    toDate = DateTime.ParseExact(dates[1].Trim(), "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                }
            }


            int totalDays = (toDate - fromDate).Days + 1;

            if (totalDays <= 28)
            {
                XAxisTitle = "Day";
            }
            else if (totalDays <= 90)
            {
                XAxisTitle = "Week";
            }
            else
            {
                XAxisTitle = "Month";
            }

            // Declare FIRST
            Func<DataRow, string> getGroupKey;

            if (totalDays <= 28)
            {
                // Day Wise
                getGroupKey = delegate(DataRow r)
                {
                    return Convert.ToDateTime(r["PDF_DATE_TIME"])
                        .ToString("dd-MMM");
                };
            }
            else if (totalDays <= 90)
            {
                // Week Wise
                getGroupKey = delegate(DataRow r)
                {
                    DateTime pdfDt = Convert.ToDateTime(r["PDF_DATE_TIME"]);

                    int week = ((pdfDt - fromDate).Days / 7) + 1;

                    return "Week " + week;
                };
            }
            else
            {
                // Month Wise
                getGroupKey = delegate(DataRow r)
                {
                    return Convert.ToDateTime(r["PDF_DATE_TIME"])
                        .ToString("MMM");
                };
            }

            if (ddlCompany.Visible)
            {
                // Admin view: "All Company" -> "" (load everyone), specific company -> its license
                Company_ids = ExtractCompanyLicense(ddlCompany.SelectedValue) ?? "";
            }
            else
            {
                // Regular login: always scope to their own company only
                Company_ids = COMPANY_ID;
            }

            DataTable dt = LoadCombined(Working_Period, Company_ids);

            if (dt.Rows.Count == 0)
                return;

            // Date Filter

            var rows = dt.AsEnumerable()
                .Where(r =>
                {
                    DateTime pdfDate =
                        Convert.ToDateTime(r["PDF_DATE_TIME"]);

                    return pdfDate >= fromDate &&
                           pdfDate < toDate.AddDays(1);
                });

            DataTable filteredDt = rows.Any() ? rows.CopyToDataTable() : dt.Clone();

            /* ==========================
               1. Monthly Page Trend
            ========================== */

            var pageTrend = filteredDt.AsEnumerable().GroupBy(r => new
            {
                Period = getGroupKey(r),
                Mode = r["PDF_MODE"].ToString()
            });

            Dictionary<string, Tuple<long, long>> monthDict = new Dictionary<string, Tuple<long, long>>();

            foreach (var grp in pageTrend)
            {
                long pages =
                    grp.Sum(x =>
                    {
                        long val;
                        return long.TryParse(
                            x["PDF_REMARKS"].ToString(),
                            out val)
                            ? val : 0;
                    });

                if (!monthDict.ContainsKey(grp.Key.Period))
                    monthDict[grp.Key.Period] = new Tuple<long, long>(0, 0);

                var current =
                    monthDict[grp.Key.Period];

                if (grp.Key.Mode == "EXP")
                {
                    monthDict[grp.Key.Period] = new Tuple<long, long>(pages, current.Item2);
                }
                else
                {
                    monthDict[grp.Key.Period] =
                        new Tuple<long, long>(current.Item1, pages);
                }
            }

            var chartLabels = new List<string>();
            var expData = new List<long>();
            var impData = new List<long>();

            IEnumerable<KeyValuePair<string, Tuple<long, long>>> orderedItems;

            if (totalDays <= 90 && totalDays > 28)
            {
                orderedItems = monthDict.OrderBy(x =>
                    Convert.ToInt32(x.Key.Replace("Week ", "")));
            }
            else
            {
                orderedItems = monthDict;
            }

            foreach (var item in orderedItems)
            {
                chartLabels.Add(item.Key);
                expData.Add(item.Value.Item1);
                impData.Add(item.Value.Item2);
            }

            var chartObj = new
            {
                labels = chartLabels,
                datasets = new[]
            {            
                new {
                    label = "Import Page Count",
                    data = impData,
                    borderColor = "#ec4899",
                    tension = 0,
                    fill = false
                },
                new {
                    label = "Export Page Count",
                    data = expData,
                    borderColor = "#f97316",
                    tension = 0,
                    fill = false
                }
            }
            };

            UploadChartJson = new JavaScriptSerializer().Serialize(chartObj);

            /* ==========================
               2. Upload Counts
            ========================== */

            int importUpload = filteredDt.AsEnumerable().Count(r => r["PDF_MODE"].ToString() == "IMP");

            int exportUpload = filteredDt.AsEnumerable().Count(r => r["PDF_MODE"].ToString() == "EXP");

            /* ==========================
               3. Monthly Import Export
            ========================== */

            var monthlyCounts = filteredDt.AsEnumerable().GroupBy(getGroupKey);

            List<string> labels = new List<string>();

            List<int> importCounts = new List<int>();

            List<int> exportCounts = new List<int>();

            var orderedGroups = monthlyCounts;

            if (totalDays <= 90 && totalDays > 28)
            {
                orderedGroups = monthlyCounts.OrderBy(g =>
                    Convert.ToInt32(g.Key.Replace("Week ", "")));
            }
            else
            {
                orderedGroups = monthlyCounts.OrderBy(g =>
                    Convert.ToDateTime(g.First()["PDF_DATE_TIME"]));
            }

            foreach (var grp in orderedGroups)
            {
                labels.Add(grp.Key);

                importCounts.Add(grp.Count(x => x["PDF_MODE"].ToString() == "IMP"));

                exportCounts.Add(grp.Count(x => x["PDF_MODE"].ToString() == "EXP"));
            }

            MonthLabels = "'" + string.Join("','", labels) + "'";

            ImportCounts = string.Join(",", importCounts);

            ExportCounts = string.Join(",", exportCounts);

            /* ==========================
               4. Totals
            ========================== */

            int totalJobs = filteredDt.Rows.Count;

            long totalPage =
                filteredDt.AsEnumerable()
                .Sum(r =>
                {
                    long v;
                    return long.TryParse(
                        r["PDF_REMARKS"].ToString(),
                        out v)
                        ? v : 0;
                });

            int totalUpload =
                filteredDt.AsEnumerable()
                .Sum(r =>
                {
                    int v;
                    return int.TryParse(
                        r["PDF_UPLOAD_COUNT"].ToString(),
                        out v)
                        ? v : 0;
                });

            long totalFailed =
                filteredDt.AsEnumerable()
                .Sum(r =>
                {
                    long v;
                    return long.TryParse(
                        r["PDF_ERROR_COUNT"].ToString(),
                        out v)
                        ? v : 0;
                });

            long totalSuccess = totalPage - totalFailed;

            /* ==========================
               Bind Labels
            ========================== */

            lblTotalJobs.Text =
                totalJobs.ToString();

            lblImportJobs.Text =
                importUpload.ToString();

            lblExportJobs.Text =
                exportUpload.ToString();

            lblTotalPages.Text =
                totalPage.ToString();

            lblTotalSucess.Text =
                totalSuccess.ToString();

            lblTotalFailed.Text =
                totalFailed.ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private bool StatusIs(DataRow row, string status)
    {
        return Convert.ToString(row["PDF_PROCESS_STATUS"]).ToUpper() == status;
    }

    protected void btnExportExcel_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
        HttpResponse Response = HttpContext.Current.Response;

        DataTable dtFinal = ViewState["dtFinal"] as DataTable;

        if (dtFinal == null || dtFinal.Rows.Count == 0)
        {
            Response.Write("<script>alert('No data available to export.');</script>");
            return;
        }

        string dateRange = txtDateRange.Text.Trim();
        DateTime fromDate = DateTime.MinValue;
        DateTime toDate = DateTime.MaxValue;

        if (!string.IsNullOrEmpty(dateRange))
        {
            string[] dates = dateRange.Split(new string[] { " - " }, StringSplitOptions.None);

            if (dates.Length == 2)
            {
                fromDate = DateTime.ParseExact(
                    dates[0].Trim(),
                    "dd-MMM-yyyy",
                    CultureInfo.InvariantCulture);

                toDate = DateTime.ParseExact(
                    dates[1].Trim(),
                    "dd-MMM-yyyy",
                    CultureInfo.InvariantCulture);
            }
        }

        var dateFiltered = dtFinal.AsEnumerable()
            .Where(r =>
            {
                DateTime pdfDate = Convert.ToDateTime(r["PDF_DATE_TIME"]);
                return pdfDate >= fromDate && pdfDate < toDate.AddDays(1);
            });

        DataTable filteredDt = dateFiltered.Any()
            ? dateFiltered.CopyToDataTable()
            : dtFinal.Clone();

        string selectedCompany = ddlCompany.Visible
            ? ExtractCompanyLicense(ddlCompany.SelectedValue)
            : null;

        DataTable exportDt;

        if (selectedCompany != null)
        {
            DataRow[] rows = filteredDt.Select(
                "COMPANY_LICENSE = '" + selectedCompany.Replace("'", "''") + "'");

            exportDt = rows.Length > 0
                ? rows.CopyToDataTable()
                : filteredDt.Clone();
        }
        else
        {
            exportDt = filteredDt;
        }

        if (exportDt.Rows.Count == 0)
        {
            Response.Write("<script>alert('No data available for the selected filters.');</script>");
            return;
        }

        using (XLWorkbook wb = new XLWorkbook())
        {
            //--------------------------------------------------
            // SHEET 1 : GROUP SUMMARY
            //--------------------------------------------------

            var wsGroup = wb.Worksheets.Add("Group Summary");
            wsGroup.Range("A1:J1").Merge();
            wsGroup.Cell("A1").Value = "OCR IMPORT EXPORT GROUP SUMMARY";
            wsGroup.Cell("A1").Style.Font.Bold = true;
            wsGroup.Cell("A1").Style.Font.FontSize = 16;
            wsGroup.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            wsGroup.SheetView.FreezeRows(3);
            var headerRange = wsGroup.Range("A3:J3");

            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.DarkBlue;
            headerRange.Style.Font.FontColor = XLColor.White;
            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;



            wsGroup.Cell(3, 1).Value = "Company ID";
            wsGroup.Cell(3, 2).Value = "Total Jobs";
            wsGroup.Cell(3, 3).Value = "Import Jobs";
            wsGroup.Cell(3, 4).Value = "Export Jobs";
            wsGroup.Cell(3, 5).Value = "Import Pages";
            wsGroup.Cell(3, 6).Value = "Export Pages";
            wsGroup.Cell(3, 7).Value = "Import Test Pages";
            wsGroup.Cell(3, 8).Value = "Export Test Pages";
            wsGroup.Cell(3, 9).Value = "Total Test Pages";


            var groupSummary = exportDt.AsEnumerable()
            .GroupBy(r => r["COMPANY_LICENSE"].ToString())
            .Select(g => new
            {
                CompanyId = g.Key,

                TotalJobs = g.Count(),

                ImportJobs = g.Count(x =>
                    x["PDF_MODE"].ToString().StartsWith("IMP")),

                ExportJobs = g.Count(x =>
                    x["PDF_MODE"].ToString().StartsWith("EXP")),

                ImportPages = g.Where(x =>
                    x["PDF_MODE"].ToString().StartsWith("IMP"))
                    .Sum(x => SafeInt(x["PDF_REMARKS"])),

                ExportPages = g.Where(x =>
                    x["PDF_MODE"].ToString().StartsWith("EXP"))
                    .Sum(x => SafeInt(x["PDF_REMARKS"])),

                ImportTestPages = g.Where(x =>
                    x["PDF_MODE"].ToString().StartsWith("IMP") &&
                    x["PDF_USER_ID"].ToString().Equals("TEST",
                        StringComparison.OrdinalIgnoreCase))
                    .Sum(x => SafeInt(x["PDF_REMARKS"])),

                ExportTestPages = g.Where(x =>
                    x["PDF_MODE"].ToString().StartsWith("EXP") &&
                    x["PDF_USER_ID"].ToString().Equals("TEST",
                        StringComparison.OrdinalIgnoreCase))
                    .Sum(x => SafeInt(x["PDF_REMARKS"]))
            }).OrderBy(x => x.CompanyId).ToList();

            int row = 4;


            foreach (var item in groupSummary)
            {
                wsGroup.Cell(row, 1).Value = item.CompanyId;
                wsGroup.Cell(row, 2).Value = item.TotalJobs;
                wsGroup.Cell(row, 3).Value = item.ImportJobs;
                wsGroup.Cell(row, 4).Value = item.ExportJobs;
                wsGroup.Cell(row, 5).Value = item.ImportPages;
                wsGroup.Cell(row, 6).Value = item.ExportPages;
                wsGroup.Cell(row, 7).Value = item.ImportTestPages;
                wsGroup.Cell(row, 8).Value = item.ExportTestPages;
                wsGroup.Cell(row, 9).Value = item.ImportTestPages + item.ExportTestPages;


                row++;
                for (int i = 4; i < row; i++)
                {
                    if (i % 2 == 0)
                    {
                        wsGroup.Range(i, 1, i, 10)
                            .Style.Fill.BackgroundColor = XLColor.LightGray;
                    }
                }
            }

            wsGroup.Columns().AdjustToContents();

            //--------------------------------------------------
            // STATUS SUMMARY
            //--------------------------------------------------

            ///--------------------------------------------------
            // SHEET 2 : COMPANY SUMMARY
            //--------------------------------------------------

            var wsCompany = wb.Worksheets.Add("Company Summary");

            wsCompany.Range("A1:J1").Merge();
            wsCompany.Cell("A1").Value = "OCR IMPORT EXPORT COMPANY SUMMARY";
            wsCompany.Cell("A1").Style.Font.Bold = true;
            wsCompany.Cell("A1").Style.Font.FontSize = 16;
            wsCompany.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            wsCompany.SheetView.FreezeRows(3);

            var companyHeaderRange = wsCompany.Range("A3:J3");

            companyHeaderRange.Style.Font.Bold = true;
            companyHeaderRange.Style.Fill.BackgroundColor = XLColor.DarkBlue;
            companyHeaderRange.Style.Font.FontColor = XLColor.White;
            companyHeaderRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            companyHeaderRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            wsCompany.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            wsCompany.RangeUsed().Style.Border.InsideBorder = XLBorderStyleValues.Thin;



            // Success
            wsCompany.Cell(3, 5).Style.Fill.BackgroundColor = XLColor.LightGreen;
            wsCompany.Cell(3, 5).Style.Font.FontColor = XLColor.Black;

            wsCompany.Cell(3, 7).Style.Fill.BackgroundColor = XLColor.LightGreen;
            wsCompany.Cell(3, 7).Style.Font.FontColor = XLColor.Black;

            // Failed
            wsCompany.Cell(3, 6).Style.Fill.BackgroundColor = XLColor.LightPink;
            wsCompany.Cell(3, 6).Style.Font.FontColor = XLColor.Black;

            wsCompany.Cell(3, 8).Style.Fill.BackgroundColor = XLColor.LightPink;
            wsCompany.Cell(3, 8).Style.Font.FontColor = XLColor.Black;

            // Reproduced
            wsCompany.Cell(3, 9).Style.Fill.BackgroundColor = XLColor.LightYellow;
            wsCompany.Cell(3, 9).Style.Font.FontColor = XLColor.Black;

            //wsCompany.Cell(3, 10).Style.Fill.BackgroundColor = XLColor.LightYellow;
            //wsCompany.Cell(3, 10).Style.Font.FontColor = XLColor.Black;


            wsCompany.Cell(3, 1).Value = "Company ID";
            wsCompany.Cell(3, 2).Value = "Company Name";
            wsCompany.Cell(3, 3).Value = "Mode";
            wsCompany.Cell(3, 4).Value = "Page Count";
            wsCompany.Cell(3, 5).Value = "Preview Success";
            wsCompany.Cell(3, 6).Value = "Preview Failed";
            wsCompany.Cell(3, 7).Value = "Upload Success";
            wsCompany.Cell(3, 8).Value = "Upload Failed";
            wsCompany.Cell(3, 9).Value = "Preview Initiated";
            //wsCompany.Cell(3, 10).Value = "Reprocess Failure";
            wsCompany.Cell(3, 10).Value = "Test Count";


            var companySummaryData = exportDt.AsEnumerable()
            .GroupBy(r => new
            {
                CompanyId = Convert.ToString(r["COMPANY_LICENSE"]),
                CompanyName = Convert.ToString(r["PDF_EXP_IMP_NAME"]),
                Mode = Convert.ToString(r["PDF_MODE"])
            })
            .Select(g => new
            {
                g.Key.CompanyId,
                g.Key.CompanyName,
                g.Key.Mode,

                PageCount = g.Sum(x => SafeInt(x["PDF_REMARKS"])),

                PreviewSuccess = g.Where(x =>
                    !x["PDF_USER_ID"].ToString().Equals("TEST", StringComparison.OrdinalIgnoreCase) &&
                    StatusIs(x, "PREVIEW SUCCESS"))
                    .Sum(x => SafeInt(x["PDF_REMARKS"])),

                PreviewFailed = g.Where(x =>
                    !x["PDF_USER_ID"].ToString().Equals("TEST", StringComparison.OrdinalIgnoreCase) &&
                    StatusIs(x, "PREVIEW FAILED"))
                    .Sum(x => SafeInt(x["PDF_REMARKS"])),

                UploadSuccess = g.Where(x =>
                    !x["PDF_USER_ID"].ToString().Equals("TEST", StringComparison.OrdinalIgnoreCase) &&
                    (string.IsNullOrWhiteSpace(x["PDF_PROCESS_STATUS"].ToString()) ||
                     StatusIs(x, "UPLOAD SUCCESS")))
                    .Sum(x => string.IsNullOrWhiteSpace(x["PDF_PROCESS_STATUS"].ToString())
                                ? SafeInt(x["PDF_REMARKS"])
                                : SafeInt(x["PDF_REMARKS"])),

                UploadFailed = g.Where(x =>
                    !x["PDF_USER_ID"].ToString().Equals("TEST", StringComparison.OrdinalIgnoreCase) &&
                    StatusIs(x, "UPLOAD FAILED"))
                    .Sum(x => SafeInt(x["PDF_REMARKS"])),

                PreviewInitiated = g.Where(x =>
                !x["PDF_USER_ID"].ToString().Equals("TEST", StringComparison.OrdinalIgnoreCase) &&
                StatusIs(x, "PREVIEW INITIATED"))
                .Sum(x => SafeInt(x["PDF_REMARKS"])),

                //RetrySuccess = g.Where(x =>
                //    !x["PDF_USER_ID"].ToString().Equals("TEST", StringComparison.OrdinalIgnoreCase) &&
                //    (StatusIs(x, "PREVIEW FAILED") || StatusIs(x, "UPLOAD FAILED")) &&
                //    SafeInt(x["PDF_SUCCESS_COUNT"]) > 0)
                //    .Sum(x => SafeInt(x["PDF_SUCCESS_COUNT"])),

                //ReprocessFailure = g.Where(x =>
                //    !x["PDF_USER_ID"].ToString().Equals("TEST", StringComparison.OrdinalIgnoreCase) &&
                //    (StatusIs(x, "PREVIEW SUCCESS") || StatusIs(x, "UPLOAD SUCCESS")) &&
                //    SafeInt(x["PDF_ERROR_COUNT"]) > 0)
                //    .Sum(x => SafeInt(x["PDF_ERROR_COUNT"])),

                TestCount = g.Where(x =>
                    x["PDF_USER_ID"].ToString().Equals("TEST", StringComparison.OrdinalIgnoreCase))
                    .Sum(x => SafeInt(x["PDF_REMARKS"]))
            })
            .OrderBy(x => x.CompanyId)
            .ThenBy(x => x.CompanyName)
            .ToList();
            int companyRow = 4;

            foreach (var item in companySummaryData)
            {
                wsCompany.Cell(companyRow, 1).Value = item.CompanyId;
                wsCompany.Cell(companyRow, 2).Value = item.CompanyName;
                wsCompany.Cell(companyRow, 3).Value = item.Mode;
                wsCompany.Cell(companyRow, 4).Value = item.PageCount;
                wsCompany.Cell(companyRow, 5).Value = item.PreviewSuccess;
                wsCompany.Cell(companyRow, 6).Value = item.PreviewFailed;
                wsCompany.Cell(companyRow, 7).Value = item.UploadSuccess;
                wsCompany.Cell(companyRow, 8).Value = item.UploadFailed;
                wsCompany.Cell(companyRow, 9).Value = item.PreviewInitiated;
                //wsCompany.Cell(companyRow, 10).Value = item.ReprocessFailure;
                wsCompany.Cell(companyRow, 10).Value = item.TestCount;

                if (companyRow % 2 == 0)
                {
                    wsCompany.Range(companyRow, 1, companyRow, 10)
                        .Style.Fill.BackgroundColor = XLColor.LightGray;
                }

                companyRow++;
            }
            int totalRow = companyRow;

            wsCompany.Cell(totalRow, 1).Value = "TOTAL";

            wsCompany.Range(totalRow, 1, totalRow, 10)
                .Style.Font.Bold = true;

            wsCompany.Range(totalRow, 1, totalRow, 10)
                .Style.Fill.BackgroundColor = XLColor.Yellow;

            wsCompany.Cell(totalRow, 4).FormulaA1 = string.Format("SUM(D4:D{0})", totalRow - 1);
            wsCompany.Cell(totalRow, 5).FormulaA1 = string.Format("SUM(E4:E{0})", totalRow - 1);
            wsCompany.Cell(totalRow, 6).FormulaA1 = string.Format("SUM(F4:F{0})", totalRow - 1);
            wsCompany.Cell(totalRow, 7).FormulaA1 = string.Format("SUM(G4:G{0})", totalRow - 1);
            wsCompany.Cell(totalRow, 8).FormulaA1 = string.Format("SUM(H4:H{0})", totalRow - 1);
            //wsCompany.Cell(totalRow, 9).FormulaA1 = string.Format("SUM(I4:I{0})", totalRow - 1);
            //wsCompany.Cell(totalRow, 10).FormulaA1 = string.Format("SUM(J4:J{0})", totalRow - 1);
            wsCompany.Cell(totalRow, 9).FormulaA1 = string.Format("SUM(I4:I{0})", totalRow - 1);
            wsCompany.Cell(totalRow, 10).FormulaA1 = string.Format("SUM(J4:J{0})", totalRow - 1);

            wsCompany.Range("A3:J" + (totalRow - 1)).SetAutoFilter();

            wsCompany.RangeUsed().Style.Border.OutsideBorder =
                XLBorderStyleValues.Thin;

            wsCompany.RangeUsed().Style.Border.InsideBorder =
                XLBorderStyleValues.Thin;

            wsCompany.Columns().AdjustToContents();

            //--------------------------------------------------
            // COMPANY SHEETS
            //--------------------------------------------------
            DataTable exportDtForExcel = exportDt.Copy();

            string[] columnsToRemove =
            {
                "DATABASE_NAME",
                "PDF_SUCCESS_COUNT",
                "PDF_ERROR_COUNT",
                "PDF_STATUS"
            };

            foreach (string column in columnsToRemove)
            {
                if (exportDtForExcel.Columns.Contains(column))
                {
                    exportDtForExcel.Columns.Remove(column);
                }
            }

            if (exportDtForExcel.Columns.Contains("PDF_REMARKS"))
            {
                exportDtForExcel.Columns["PDF_REMARKS"].ColumnName = "PAGE_COUNT";
            }

            //----------------------

            if (selectedCompany != null)
            {
                string displayName =
                    ExtractCompanyDisplayName(ddlCompany.SelectedValue);

                string sheetName =
                    displayName.Length > 31
                    ? displayName.Substring(0, 31)
                    : displayName;

                wb.Worksheets.Add(exportDtForExcel, sheetName);
            }
            else
            {
                var companyGroups = exportDtForExcel.AsEnumerable()
                    .GroupBy(r => r.Field<string>("COMPANY_LICENSE"));

                foreach (var group in companyGroups)
                {
                    DataTable companyTable = group.CopyToDataTable();

                    string sheetName = string.IsNullOrEmpty(group.Key)
                        ? "Unknown"
                        : group.Key;

                    if (sheetName.Length > 31)
                        sheetName = sheetName.Substring(0, 31);

                    wb.Worksheets.Add(companyTable, sheetName);
                }
            }

            //--------------------------------------------------
            // EXPORT
            //--------------------------------------------------

            using (MemoryStream ms = new MemoryStream())
            {
                wb.SaveAs(ms);

                Response.Clear();
                Response.Buffer = true;

                Response.ContentType =
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                string fileName =
                    "OCR_IMPORT_EXPORT_REPORT_" +
                    DateTime.Now.ToString("yyyyMMdd_HHmmss") +
                    ".xlsx";

                Response.AddHeader(
                    "content-disposition",
                    "attachment;filename=" + fileName);

                Response.BinaryWrite(ms.ToArray());

                Response.Flush();
                Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        filterview();

        if (IsVendorChartCompany())
        {
            LoadVendorAccuracy();
        }
        else
        {
            LoadLatestJobs("Latest_Jobs_ALL");
        }

        //Response.Write("<script>alert('Refresh Clicked');</script>");
    }

    public void filterview()
    {

        if (ViewState["dtFinal"] == null)
        {
            LoadCombined(Working_Period, ddlCompany.Visible ? "" : COMPANY_ID);
        }

        DataTable cf = new DataTable();

        string companyID = ExtractCompanyLicense(ddlCompany.SelectedValue);

        if (ViewState["dtFinal"] != null && ddlCompany.SelectedValue != "All Company" && companyID != null)
        {
            cf = (DataTable)ViewState["dtFinal"];

            // Filter the rows
            DataRow[] rows = cf.Select("COMPANY_LICENSE = '" + companyID.Replace("'", "''") + "'");

            // Convert to DataTable
            DataTable filteredTable;

            if (rows.Length > 0)
            {
                filteredTable = rows.CopyToDataTable();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "noDataToast", "showToast('No Data Available for this Company.', 'warning');", true);
                filteredTable = cf.Clone();
            }

            BindDashboard(filteredTable);
            // Use filteredTable as required

        }
        else
        {

            cf = (DataTable)ViewState["dtFinal"];
            BindDashboard(cf);
        }
    }

    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        filterview();

        if (IsVendorChartCompany())
        {
            LoadVendorAccuracy();
        }
        else
        {
            LoadLatestJobs("Latest_Jobs_ALL");
        }
    }


    private void BindDashboard(DataTable dt)
    {

         try
        {
            string dateRange = txtDateRange.Text.Trim();

            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MaxValue;

            if (!string.IsNullOrEmpty(dateRange))
            {
                string[] dates = dateRange.Split(
                    new string[] { " - " },
                    StringSplitOptions.None);

                if (dates.Length == 2)
                {
                    fromDate = DateTime.ParseExact(
                        dates[0].Trim(),
                        "dd-MMM-yyyy",
                        CultureInfo.InvariantCulture);

                    toDate = DateTime.ParseExact(
                        dates[1].Trim(),
                        "dd-MMM-yyyy",
                        CultureInfo.InvariantCulture);
                }
            }


            int totalDays = (toDate - fromDate).Days + 1;

            if (totalDays <= 28)
            {
                XAxisTitle = "Day";
            }
            else if (totalDays <= 90)
            {
                XAxisTitle = "Week";
            }
            else
            {
                XAxisTitle = "Month";
            }

            // Declare FIRST
            Func<DataRow, string> getGroupKey;

            if (totalDays <= 28)
            {
                // Day Wise
                getGroupKey = delegate(DataRow r)
                {
                    return Convert.ToDateTime(r["PDF_DATE_TIME"])
                        .ToString("dd-MMM");
                };
            }
            else if (totalDays <= 90)
            {
                // Week Wise
                getGroupKey = delegate(DataRow r)
                {
                    DateTime pdfDt = Convert.ToDateTime(r["PDF_DATE_TIME"]);

                    int week = ((pdfDt - fromDate).Days / 7) + 1;

                    return "Week " + week;
                };
            }
            else
            {
                // Month Wise
                getGroupKey = delegate(DataRow r)
                {
                    return Convert.ToDateTime(r["PDF_DATE_TIME"])
                        .ToString("MMM");
                };
            }
            if (dt.Rows.Count == 0)
            {
                MonthLabels = "";
                ImportCounts = "";
                ExportCounts = "";
                UploadChartJson = "{}";

                lblTotalJobs.Text = "0";
                lblImportJobs.Text = "0";
                lblExportJobs.Text = "0";
                lblTotalPages.Text = "0";
                lblTotalSucess.Text = "0";
                lblTotalFailed.Text = "0";
                return;
            }

            // Date Filter

            var rows = dt.AsEnumerable()
                .Where(r =>
                {
                    DateTime pdfDate =
                        Convert.ToDateTime(r["PDF_DATE_TIME"]);

                    return pdfDate >= fromDate &&
                           pdfDate < toDate.AddDays(1);
                });

            DataTable filteredDt =
                rows.Any()
                ? rows.CopyToDataTable()
                : dt.Clone();

            /* ==========================
               1. Monthly Page Trend
            ========================== */

            var pageTrend =
                filteredDt.AsEnumerable()
                .GroupBy(r => new
                {
                    Period = getGroupKey(r),
                    Mode = r["PDF_MODE"].ToString()
                });

            Dictionary<string,
                Tuple<long, long>> monthDict =
                new Dictionary<string,
                Tuple<long, long>>();

            foreach (var grp in pageTrend)
            {
                long pages =
                    grp.Sum(x =>
                    {
                        long val;
                        return long.TryParse(
                            x["PDF_REMARKS"].ToString(),
                            out val)
                            ? val : 0;
                    });

                if (!monthDict.ContainsKey(grp.Key.Period))
                    monthDict[grp.Key.Period] =
                        new Tuple<long, long>(0, 0);

                var current =
                    monthDict[grp.Key.Period];

                if (grp.Key.Mode == "EXP")
                {
                    monthDict[grp.Key.Period] =
                        new Tuple<long, long>(
                            pages,
                            current.Item2);
                }
                else
                {
                    monthDict[grp.Key.Period] =
                        new Tuple<long, long>(
                            current.Item1,
                            pages);
                }
            }

            var chartLabels = new List<string>();
            var expData = new List<long>();
            var impData = new List<long>();

            IEnumerable<KeyValuePair<string, Tuple<long, long>>> orderedItems;

            if (totalDays <= 90 && totalDays > 28)
            {
                orderedItems = monthDict.OrderBy(x =>
                    Convert.ToInt32(x.Key.Replace("Week ", "")));
            }
            else
            {
                orderedItems = monthDict;
            }

            foreach (var item in orderedItems)
            {
                chartLabels.Add(item.Key);
                expData.Add(item.Value.Item1);
                impData.Add(item.Value.Item2);
            }

            var chartObj = new
            {
                labels = chartLabels,
                datasets = new[]
                {
                    new {
                        label = "Import Page Count",
                        data = impData,
                        borderColor = "#ec4899",
                        tension = 0,
                        fill = false
                    },new {
                        label = "Export Page Count",
                        data = expData,
                        borderColor = "#f97316",
                        tension = 0,
                        fill = false
                    }
                
                }
            };

            UploadChartJson =
                new JavaScriptSerializer()
                .Serialize(chartObj);

            /* ==========================
               2. Upload Counts
            ========================== */

            int importUpload =
                filteredDt.AsEnumerable()
                .Count(r =>
                    r["PDF_MODE"].ToString() == "IMP");

            int exportUpload =
                filteredDt.AsEnumerable()
                .Count(r =>
                    r["PDF_MODE"].ToString() == "EXP");

            /* ==========================
               3. Monthly Import Export
            ========================== */

            var monthlyCounts =
         filteredDt.AsEnumerable()
                   .GroupBy(getGroupKey);



            List<string> labels =
                new List<string>();

            List<int> importCounts =
                new List<int>();

            List<int> exportCounts =
                new List<int>();

            var orderedGroups = monthlyCounts;

            if (totalDays <= 90 && totalDays > 28)
            {
                orderedGroups = monthlyCounts.OrderBy(g =>
                    Convert.ToInt32(g.Key.Replace("Week ", "")));
            }
            else
            {
                orderedGroups = monthlyCounts.OrderBy(g =>
                    Convert.ToDateTime(g.First()["PDF_DATE_TIME"]));
            }

            foreach (var grp in orderedGroups)
            {
                labels.Add(grp.Key);

                importCounts.Add(
                    grp.Count(x => x["PDF_MODE"].ToString() == "IMP"));

                exportCounts.Add(
                    grp.Count(x => x["PDF_MODE"].ToString() == "EXP"));
            }

            MonthLabels =
                "'" + string.Join("','", labels) + "'";

            ImportCounts =
                string.Join(",", importCounts);

            ExportCounts =
                string.Join(",", exportCounts);

            /* ==========================
               4. Totals
            ========================== */

            int totalJobs =
                filteredDt.Rows.Count;

            long totalPage =
                filteredDt.AsEnumerable()
                .Sum(r =>
                {
                    long v;
                    return long.TryParse(
                        r["PDF_REMARKS"].ToString(),
                        out v)
                        ? v : 0;
                });

            int totalUpload =
                filteredDt.AsEnumerable()
                .Sum(r =>
                {
                    int v;
                    return int.TryParse(
                        r["PDF_UPLOAD_COUNT"].ToString(),
                        out v)
                        ? v : 0;
                });

            long totalFailed =
                filteredDt.AsEnumerable()
                .Sum(r =>
                {
                    long v;
                    return long.TryParse(
                        r["PDF_ERROR_COUNT"].ToString(),
                        out v)
                        ? v : 0;
                });

            long totalSuccess =
                totalPage - totalFailed;

            /* ==========================
               Bind Labels
            ========================== */

            lblTotalJobs.Text =
                totalJobs.ToString();

            lblImportJobs.Text =
                importUpload.ToString();

            lblExportJobs.Text =
                exportUpload.ToString();

            lblTotalPages.Text =
                totalPage.ToString();

            lblTotalSucess.Text =
                totalSuccess.ToString();

            lblTotalFailed.Text =
                totalFailed.ToString();
        }
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
    }

    private string ExtractCompanyLicense(string ddlValue)
    {
        if (string.IsNullOrEmpty(ddlValue) || ddlValue == "All Company")
            return null;

        if (ddlValue.Contains("--"))
        {
            string[] parts = ddlValue.Split(new string[] { "--" }, StringSplitOptions.None);
            return parts[parts.Length - 1].Trim(); // license code, e.g. "ERI00010"
        }

        return ddlValue.Trim();
    }

    private string ExtractCompanyDisplayName(string ddlValue)
    {
        if (string.IsNullOrEmpty(ddlValue)) return ddlValue;
        int idx = ddlValue.IndexOf("--");
        return idx >= 0 ? ddlValue.Substring(0, idx).Trim() : ddlValue;
    }
    private int SafeInt(object value)
    {
        int result;
        return int.TryParse(Convert.ToString(value), out result) ? result: 0;
    }
}