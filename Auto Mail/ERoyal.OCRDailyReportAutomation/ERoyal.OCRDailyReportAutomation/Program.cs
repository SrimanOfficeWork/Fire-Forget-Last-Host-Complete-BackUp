using ClosedXML.Excel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NLog;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace DSRAutoMailScheduler
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static SmtpSettings _smtpSettings = null!;
        private static Dictionary<string, string> _serverDict = null!;
        private static string ReportFolder = null!;
        private static string fileName = null!;
        private static string savePath = null!;

        public class SmtpSettings
        {
            public string Mail_header { get; set; }
            public string Host { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public int SmtpPort { get; set; }
            public bool enableSsl { get; set; }
            public string FromEmail { get; set; }
            public string[] ToEmails { get; set; }
            public string[] CCEmails { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
        }

        public class RowPointers
        {
            public int ClientRow = 1;  // Sheet 1: AI_OCR ENABLED CLIENT LIST
            public int JobRow = 1;  // Sheet 2: AI_OCR DAILY JOB COUNT DETAILS
            public int TotalJobRow = 1;  // Sheet 3: AI_OCR TOTAL JOB DETAILS
            public int FormatRow = 1;  // Sheet 4: AI_OCR TOTAL FORMAT DETAILS
        }

        static async Task Main(string[] args)
        {
            bool isDryRun = args.Any(a =>
                string.Equals(a, "--dry-run", StringComparison.OrdinalIgnoreCase));

            try
            {
                Logger.Info("🚀 AI OCR Daily Report Scheduler started.");
                RowPointers rows = new RowPointers();

                var builder = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                IConfiguration config = builder.Build();
                _smtpSettings = config.GetSection("SmtpSettings").Get<SmtpSettings>();
                _serverDict = config.GetSection("server_ip_list").Get<Dictionary<string, string>>();
                ReportFolder = config.GetSection("ReportSettings:ReportFolder").Value;

                if (!Directory.Exists(ReportFolder))
                    Directory.CreateDirectory(ReportFolder);

                //Logger.Info("======================================================");
                Logger.Info("AI OCR Daily Report — run started ({0} server(s) configured)", _serverDict.Count);
                //Logger.Info("======================================================");

                using var workbook = new XLWorkbook();
                {
                    // ── 4 Sheets ──────────────────────────────────────────────
                    var wsClient = workbook.Worksheets.Add("AI_OCR ENABLED CLIENT LIST");
                    var wsJob = workbook.Worksheets.Add("AI_OCR DAILY JOB COUNT DETAILS");
                    var wsTotalJob = workbook.Worksheets.Add("AI_OCR TOTAL JOB DETAILS");
                    var wsFormat = workbook.Worksheets.Add("AI_OCR TOTAL FORMAT DETAILS");

                    int serverIndex = 0;
                    foreach (var kvp in _serverDict)
                    {
                        serverIndex++;
                        string serverName = kvp.Key;
                        string serverIp = kvp.Value;

                        Logger.Info("------------------------------------------------------");
                        Logger.Info("[🌐 Connecting to Server: {0}/{1}] START  -> Name: {2}  |  IP: {3}",
                            serverIndex, _serverDict.Count, serverName, serverIp);
                        Logger.Info("------------------------------------------------------");
                        Logger.Info("✅ Connected successfully.");
                        // Admin DB connection — same pattern as IRN
                        string connString = $"Server={serverIp};database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;TrustServerCertificate=True;";
                        //string connString = $"Server={serverIp};database=ImpexLogin;uid=sa;pwd=SA,123;TrustServerCertificate=True;";

                        await GetOcrDataList(
                            connString, wsClient, wsJob, wsTotalJob, wsFormat,
                            serverName, rows);

                        Logger.Info("[Server {0}/{1}] FINISHED -> {2} — all client data collected.",
                            serverIndex, _serverDict.Count, serverName);

                        if (serverIndex < _serverDict.Count)
                            Logger.Info("Moving to next server...");
                    }

                    //Logger.Info("======================================================");
                    Logger.Info("All {0} server(s) processed.", _serverDict.Count);
                    //Logger.Info("======================================================");

                    Logger.Info("📄Building Excel report...");
                    // ── Style all 4 sheets ────────────────────────────────────
                    StyleSheet(wsClient, "AI_OCR ENABLED CLIENT LIST", rows.ClientRow - 1, 7);
                    StyleSheet(wsJob, "AI_OCR DAILY JOB COUNT DETAILS", rows.JobRow - 1, -1);
                    StyleSheet(wsTotalJob, "AI_OCR TOTAL JOB DETAILS", rows.TotalJobRow - 1, 16);
                    StyleSheet(wsFormat, "AI_OCR TOTAL FORMAT DETAILS", rows.FormatRow - 1, 13);

                    fileName = $"AI_OCR_Report_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                    savePath = Path.Combine(ReportFolder, fileName);
                    workbook.SaveAs(savePath);
                    Logger.Info("Excel report saved: {0}", savePath);
                }

                if (isDryRun)
                {
                    Logger.Info("Dry run mode — email NOT sent. Report available at: {0}", savePath);
                    Logger.Info("======================================================");
                    Logger.Info("Run complete (dry run).");
                    Logger.Info("======================================================");
                    return;
                }

                //Logger.Info("Sending report by email...");
                await SendEmailWithAttachment(savePath);
                Logger.Info("✅ Email sent successfully.");

                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                    Logger.Info("Deleted report after emailing: {0}", fileName);
                }

                //Logger.Info("======================================================");
                Logger.Info("Run complete.");
                //Logger.Info("======================================================");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Run failed with an unhandled error");
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // Main data fetch per server
        // ─────────────────────────────────────────────────────────────────────
        private static async Task GetOcrDataList(
            string connString,
            IXLWorksheet wsClient,
            IXLWorksheet wsJob,
            IXLWorksheet wsTotalJob,
            IXLWorksheet wsFormat,
            string serverName,
            RowPointers rows)
        {
            await Task.Run(() =>
            {
                DataSet adminData;
                try
                {
                    adminData = GetAdminData(connString, "OCR_ENABLED_COUNT", serverName);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "[{0}] Could not reach the admin database — skipping this server", serverName);
                    return;
                }

                if (adminData == null || adminData.Tables.Count < 2)
                {
                    Logger.Warn("[{0}] Admin procedure returned no data — skipping this server", serverName);
                    return;
                }

                DataTable clientList = adminData.Tables[0];
                DataTable serverList = adminData.Tables[1];

                Logger.Info("[{0}] Enabled clients found: {1}  |  Company/database rows: {2}",
                    serverName, clientList.Rows.Count, serverList.Rows.Count);

                // ── Sheet 1 ───────────────────────────────────────────────────
                AppendDataTable(wsClient, clientList, ref rows.ClientRow);

                // ── Deduplicate by COMPANY_LICENSE ────────────────────────────
                var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                var uniqueServers = serverList.AsEnumerable()
                    .Where(r => seen.Add(r["COMPANY_LICENSE"].ToString().Trim()))
                    .ToList();

                Logger.Info("[{0}] Unique companies to process: {1}", serverName, uniqueServers.Count);

                int clientIndex = 0;
                foreach (DataRow server in uniqueServers)
                {
                    clientIndex++;
                    string workingPeriod = server["WORKING_PERIOD"].ToString();
                    string companyLicense = server["COMPANY_LICENSE"].ToString();
                    string companyName = server["COMPANY_NAME"].ToString();
                    string clientConn = server["CON_STRING"].ToString();

                    string enabledDate = ParseDateToYMD(server["ENABLED_ON"].ToString());
                    string disabledDate = string.IsNullOrWhiteSpace(
                                             server["DISABLED_ON"].ToString())
                                         ? ""
                                         : ParseDateToYMD(server["DISABLED_ON"].ToString());

                    Logger.Info("  [{0}] Client {1}/{2} -> {3} ({4}): fetching data...",
                        serverName, clientIndex, uniqueServers.Count, companyLicense, companyName);

                    // ── Sheet 2: JOB_COUNT (daily breakdown) ──────────────────
                    DataTable jobData = GetClientData(
                        clientConn, "JOB_COUNT",
                        serverName, workingPeriod, companyLicense,
                        companyName, enabledDate, disabledDate);
                    AppendDataTable(wsJob, jobData, ref rows.JobRow);

                    // ── Sheet 3: TOTAL_JOB_DETAILS (overall summary) ──────────
                    DataTable totalJobData = GetClientData(
                        clientConn, "TOTAL_JOB_DETAILS",
                        serverName, workingPeriod, companyLicense,
                        companyName, enabledDate, disabledDate);
                    AppendDataTable(wsTotalJob, totalJobData, ref rows.TotalJobRow);

                    // ── Sheet 4: FORMAT_COUNT (format details) ────────────────
                    DataTable formatData = GetClientData(
                        clientConn, "FORMAT_COUNT",
                        serverName, workingPeriod, companyLicense,
                        companyName, enabledDate, disabledDate);
                    AppendDataTable(wsFormat, formatData, ref rows.FormatRow);

                    Logger.Info("  [{0}] Client {1}/{2} -> {3} done. Job rows: {4}, TotalJob rows: {5}, Format rows: {6}",
                        serverName, clientIndex, uniqueServers.Count, companyLicense,
                        jobData.Rows.Count, totalJobData.Rows.Count, formatData.Rows.Count);
                }
            });
        }

        // ─────────────────────────────────────────────────────────────────────
        // Admin SP — OCR_AI_ENABLED_COUNT
        // ─────────────────────────────────────────────────────────────────────
        private static DataSet GetAdminData(
            string connString, string flag, string serverName)
        {
            using var con = new SqlConnection(connString);
            using var cmd = new SqlCommand("OCR_AI_ENABLED_COUNT", con)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 120
            };

            cmd.Parameters.AddWithValue("@MFLAG", flag);
            cmd.Parameters.AddWithValue("@serverName", serverName);

            var errParam = new SqlParameter("@ERRORMSG",
                System.Data.SqlDbType.NVarChar, -1)
            { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(errParam);

            var adapter = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            adapter.Fill(ds);

            string errMsg = errParam.Value?.ToString();
            if (!string.IsNullOrEmpty(errMsg))
                Logger.Warn("[{0}] Admin procedure OCR_AI_ENABLED_COUNT reported an error: {1}", serverName, errMsg);

            return ds;
        }

        // ─────────────────────────────────────────────────────────────────────
        // Client SP — OCR_AI_JOB_COUNT
        // ─────────────────────────────────────────────────────────────────────
        private static DataTable GetClientData(
            string connStr,
            string flag,
            string serverName,
            string workingPeriod,
            string companyLicense,
            string companyName,
            string enabledDate,
            string disabledDate)
        {
            try
            {
                using var conn = new SqlConnection(connStr);
                using var cmd = new SqlCommand("OCR_AI_JOB_COUNT", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 180
                };

                cmd.Parameters.AddWithValue("@MFLAG", flag);
                cmd.Parameters.AddWithValue("@Server_name", serverName);
                cmd.Parameters.AddWithValue("@WORKING_PERIOD", workingPeriod);
                cmd.Parameters.AddWithValue("@COMPANY_LICENSE", companyLicense);
                cmd.Parameters.AddWithValue("@COMPANY_NAME", companyName);
                cmd.Parameters.AddWithValue("@ENABLED_DATE", enabledDate);
                cmd.Parameters.AddWithValue("@DISABLED_DATE", disabledDate);

                var errParam = new SqlParameter("@ERRORMSG",
                    System.Data.SqlDbType.NVarChar, -1)
                { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(errParam);

                var adapter = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                adapter.Fill(ds);

                string errMsg = errParam.Value?.ToString();
                if (!string.IsNullOrEmpty(errMsg))
                    Logger.Warn("  [{0}] Client {1} — {2} reported an error: {3}",
                        serverName, companyLicense, flag, errMsg);

                // JOB_COUNT uses EXEC(@sql) with SET NOCOUNT ON
                // → result lands in Tables[0] (no PRINT statement)
                return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
            }
            catch (SqlException ex)
            {
                Logger.Error("  [{0}] Client {1} — {2} FAILED: SQL error {3} — {4}. Skipping.",
                    serverName, companyLicense, flag, ex.Number, ex.Message);
                return new DataTable();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "  [{0}] Client {1} — {2} FAILED",
                    serverName, companyLicense, flag);
                return new DataTable();
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // Append DataTable to worksheet
        // ─────────────────────────────────────────────────────────────────────
        private static void AppendDataTable(
            IXLWorksheet ws, DataTable table, ref int currentRow)
        {
            if (table == null || table.Rows.Count == 0) return;

            if (currentRow == 1)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    var cell = ws.Cell(currentRow, col + 1);
                    cell.Value = table.Columns[col].ColumnName;
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.DarkBlue;
                    cell.Style.Font.FontColor = XLColor.White;
                    cell.Style.Alignment.Horizontal =
                        XLAlignmentHorizontalValues.Center;
                }
                currentRow++;
            }

            foreach (DataRow row in table.Rows)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                    ws.Cell(currentRow, col + 1).Value = row[col]?.ToString();

                if (currentRow % 2 == 0)
                    ws.Range(currentRow, 1, currentRow, table.Columns.Count)
                      .Style.Fill.BackgroundColor = XLColor.LightGray;

                currentRow++;
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // Style sheet
        // ─────────────────────────────────────────────────────────────────────
        private static void StyleSheet(
            IXLWorksheet ws, string title, int lastDataRow, int colCount)
        {
            try
            {
                ws.Row(1).InsertRowsAbove(1);
                int usedCols = colCount > 0
                    ? colCount
                    : ws.LastColumnUsed()?.ColumnNumber() ?? 1;

                var titleRange = ws.Range(1, 1, 1, usedCols);
                titleRange.Merge();
                titleRange.FirstCell().Value = title;
                titleRange.Style.Font.Bold = true;
                titleRange.Style.Font.FontSize = 14;
                titleRange.Style.Alignment.Horizontal =
                    XLAlignmentHorizontalValues.Center;
                titleRange.Style.Fill.BackgroundColor = XLColor.Navy;
                titleRange.Style.Font.FontColor = XLColor.White;

                ws.SheetView.FreezeRows(2);

                if (ws.RangeUsed() != null)
                {
                    ws.RangeUsed().Style.Border.OutsideBorder =
                        XLBorderStyleValues.Thin;
                    ws.RangeUsed().Style.Border.InsideBorder =
                        XLBorderStyleValues.Thin;
                }

                ws.Columns().AdjustToContents();
            }
            catch (Exception ex)
            {
                Logger.Warn("StyleSheet failed for {0}: {1}", ws.Name, ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // Parse dd-MM-yyyy → yyyy-MM-dd
        // ─────────────────────────────────────────────────────────────────────
        private static string ParseDateToYMD(string dateStr)
        {
            if (string.IsNullOrWhiteSpace(dateStr)) return "";
            try
            {
                return DateTime.ParseExact(dateStr.Trim(), "dd-MM-yyyy", null)
                               .ToString("yyyy-MM-dd");
            }
            catch
            {
                Logger.Warn("Could not parse date: {0}", dateStr);
                return dateStr;
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // Send email with Excel attachment
        // ─────────────────────────────────────────────────────────────────────
        private static async Task SendEmailWithAttachment(string filePath)
        {
            try
            {
                Logger.Info("Sending email...");

                string reportDate = DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy");
                string subject = _smtpSettings.Subject.Replace("{Date}", reportDate);
                string htmlBody = _smtpSettings.Body.Replace("{Date}", reportDate);

                using var mail = new MailMessage
                {
                    From = new MailAddress(
                                     _smtpSettings.FromEmail,
                                     _smtpSettings.Mail_header),
                    Subject = subject,
                    IsBodyHtml = true
                };

                string logoPath = Path.Combine(
                    AppContext.BaseDirectory, "Assets", "Company_Logo.png");

                if (File.Exists(logoPath))
                {
                    var htmlView = AlternateView.CreateAlternateViewFromString(
                        htmlBody, null, "text/html");
                    var logoRes = new LinkedResource(logoPath, "image/png")
                    { ContentId = "companylogo" };
                    htmlView.LinkedResources.Add(logoRes);
                    mail.AlternateViews.Add(htmlView);
                }
                else
                {
                    Logger.Warn("Logo not found at {0}; sending without logo", logoPath);
                    mail.Body = htmlBody;
                }

                foreach (var to in (_smtpSettings.ToEmails ?? Array.Empty<string>()))
                    mail.To.Add(to.Trim());

                foreach (var cc in (_smtpSettings.CCEmails ?? Array.Empty<string>()))
                    mail.CC.Add(cc.Trim());

                using (var fs = new FileStream(
                    filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    mail.Attachments.Add(new Attachment(fs, Path.GetFileName(filePath)));

                    using var smtp = new SmtpClient(
                        _smtpSettings.Host, _smtpSettings.SmtpPort)
                    {
                        Credentials = new NetworkCredential(
                            _smtpSettings.username, _smtpSettings.password),
                        EnableSsl = _smtpSettings.enableSsl
                    };
                    await smtp.SendMailAsync(mail);
                }

                Logger.Info("Email sent: {0}", Path.GetFileName(filePath));

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Logger.Info("Deleted report: {0}", filePath);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Email send failed");
            }
        }
    }
}