using System;
using System.IO;
using System.Web;

public class PDFReaderLog
{
    private const int LOG_RETENTION_DAYS = 7;
    private static readonly object _logLock = new object();
    public string companyId, branch, user, filePrefix, logDirectory, logFile, logLine;
    
    public void WriteOcrJobLog(string jobNo, string stage, string message, string mode = "IMP")
    {
        try
        {
            companyId = HttpContext.Current.Session["COMPANY_ID"] != null
                ? HttpContext.Current.Session["COMPANY_ID"].ToString() : "0";
            branch = HttpContext.Current.Session["currentbranch"] != null
                ? HttpContext.Current.Session["currentbranch"].ToString() : "";
            user = HttpContext.Current.Session["currentuser"] != null
                ? HttpContext.Current.Session["currentuser"].ToString() : "";

            filePrefix = string.Equals(mode, "EXP", StringComparison.OrdinalIgnoreCase)
                ? "Log_ExportPdfReaderAI_" : "Log_ImportPdfReaderAI_";

            logDirectory = HttpContext.Current.Server.MapPath("~/Submission/OCRImpExpLog/" + mode.ToUpperInvariant() + "/");
            if (!Directory.Exists(logDirectory)) Directory.CreateDirectory(logDirectory);

            PurgeOldLogs(logDirectory, filePrefix);

            logFile = Path.Combine(logDirectory, filePrefix + DateTime.Now.ToString("yyyyMMdd") + ".log");

            logLine = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")
                + " | CompanyId:" + companyId
                + " | Branch:" + branch
                + " | User:" + user
                + " | Job:" + jobNo
                + " | " + stage
                + " | " + message;

            lock (_logLock)
            {
                File.AppendAllText(logFile, logLine + Environment.NewLine);
            }
        }
        catch { }
    }

    private void PurgeOldLogs(string logDirectory, string filePrefix)
    {
        try
        {
            DateTime cutoff = DateTime.Now.AddDays(-LOG_RETENTION_DAYS);
            foreach (string file in Directory.GetFiles(logDirectory, filePrefix + "*.log"))
            {
                if (File.GetLastWriteTime(file) < cutoff) File.Delete(file);
            }
        }
        catch { }
    }
}
