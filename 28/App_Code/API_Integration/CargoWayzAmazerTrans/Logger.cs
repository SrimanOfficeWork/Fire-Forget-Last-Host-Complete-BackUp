using System;
using System.IO;
using System.Web;
using System.Diagnostics;

/// <summary>
/// Logger utility class for file-based and debug logging
/// Compatible with .NET Framework 4.0
/// </summary>
public static class Logger
{
    private static readonly object _lockObject = new object();

    private static string GetLogDirectory()
    {
        try
        {
            if (HttpContext.Current != null)
            {
                string logDir = HttpContext.Current.Server.MapPath("~/App_Data/Logs");
                if (!Directory.Exists(logDir))
                    Directory.CreateDirectory(logDir);
                return logDir;
            }
            else
            {
                // Fallback for non-web contexts
                string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
                if (!Directory.Exists(logDir))
                    Directory.CreateDirectory(logDir);
                return logDir;
            }
        }
        catch
        {
            return null;
        }
    }

    private static string GetLogFilePath()
    {
        string dir = GetLogDirectory();
        if (string.IsNullOrEmpty(dir))
            return null;

        string fileName = string.Format("CargoLog_{0:yyyyMMdd}.txt", DateTime.Now);
        return Path.Combine(dir, fileName);
    }

    /// <summary>
    /// Log informational message
    /// </summary>
    public static void LogInfo(string message)
    {
        WriteLog("INFO", message);
    }

    /// <summary>
    /// Log error message with optional exception
    /// </summary>
    public static void LogError(string message, Exception ex)
    {
        WriteLog("ERROR", message);
        if (ex != null)
        {
            WriteLog("ERROR", string.Format("Exception Type: {0}", ex.GetType().Name));
            WriteLog("ERROR", string.Format("Exception Message: {0}", ex.Message));
            WriteLog("ERROR", string.Format("Stack Trace: {0}", ex.StackTrace));

            if (ex.InnerException != null)
            {
                WriteLog("ERROR", string.Format("Inner Exception: {0}", ex.InnerException.Message));
                WriteLog("ERROR", string.Format("Inner Stack Trace: {0}", ex.InnerException.StackTrace));
            }
        }
    }

    /// <summary>
    /// Log error message without exception
    /// </summary>
    public static void LogError(string message)
    {
        LogError(message, null);
    }

    /// <summary>
    /// Log debug message (only in debug mode)
    /// </summary>
    public static void LogDebug(string message)
    {
#if DEBUG
        WriteLog("DEBUG", message);
#endif
    }

    /// <summary>
    /// Log warning message
    /// </summary>
    public static void LogWarning(string message)
    {
        WriteLog("WARNING", message);
    }

    /// <summary>
    /// Core logging method
    /// </summary>
    private static void WriteLog(string level, string message)
    {
        try
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string logMessage = string.Format("{0} [{1}] {2}", timestamp, level, message);

            // Write to Debug output (visible in Visual Studio Output window)
            Debug.WriteLine(logMessage);

            // Write to Console (useful in some scenarios)
            Console.WriteLine(logMessage);

            // Write to file
            string filePath = GetLogFilePath();
            if (!string.IsNullOrEmpty(filePath))
            {
                lock (_lockObject)
                {
                    File.AppendAllText(filePath, logMessage + Environment.NewLine);
                }
            }
        }
        catch (Exception ex)
        {
            // Fail silently but output to Debug
            Debug.WriteLine(string.Format("LOGGER ERROR: Failed to write log - {0}", ex.Message));
        }
    }

    /// <summary>
    /// Log method entry with parameters
    /// </summary>
    public static void LogMethodEntry(string methodName, params object[] parameters)
    {
        string paramString = "no parameters";
        if (parameters != null && parameters.Length > 0)
        {
            paramString = string.Join(", ", Array.ConvertAll(parameters, p => p != null ? p.ToString() : "null"));
        }

        LogDebug(string.Format(">>> ENTERING {0}({1})", methodName, paramString));
    }

    /// <summary>
    /// Log method exit with optional return value
    /// </summary>
    public static void LogMethodExit(string methodName, object returnValue)
    {
        string returnString = returnValue != null
            ? string.Format(" - Returns: {0}", returnValue)
            : "";

        LogDebug(string.Format("<<< EXITING {0}{1}", methodName, returnString));
    }

    /// <summary>
    /// Log method exit without return value
    /// </summary>
    public static void LogMethodExit(string methodName)
    {
        LogMethodExit(methodName, null);
    }

    /// <summary>
    /// Get log file path for current day
    /// </summary>
    public static string GetCurrentLogFile()
    {
        return GetLogFilePath();
    }

    /// <summary>
    /// Clean up old log files (older than specified days)
    /// </summary>
    public static void CleanupOldLogs(int daysToKeep)
    {
        try
        {
            string dir = GetLogDirectory();
            if (string.IsNullOrEmpty(dir) || !Directory.Exists(dir))
                return;

            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            FileInfo[] logFiles = dirInfo.GetFiles("CargoLog_*.txt");

            DateTime cutoffDate = DateTime.Now.AddDays(-daysToKeep);

            foreach (FileInfo file in logFiles)
            {
                if (file.CreationTime < cutoffDate)
                {
                    try
                    {
                        file.Delete();
                        Debug.WriteLine(string.Format("Deleted old log file: {0}", file.Name));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(string.Format("Failed to delete {0}: {1}", file.Name, ex.Message));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(string.Format("CleanupOldLogs failed: {0}", ex.Message));
        }
    }

    /// <summary>
    /// Log formatted message
    /// </summary>
    public static void LogInfoFormat(string format, params object[] args)
    {
        try
        {
            string message = string.Format(format, args);
            LogInfo(message);
        }
        catch (Exception ex)
        {
            LogError("LogInfoFormat failed", ex);
        }
    }

    /// <summary>
    /// Log formatted error message
    /// </summary>
    public static void LogErrorFormat(string format, params object[] args)
    {
        try
        {
            string message = string.Format(format, args);
            LogError(message);
        }
        catch (Exception ex)
        {
            LogError("LogErrorFormat failed", ex);
        }
    }

    /// <summary>
    /// Log formatted debug message
    /// </summary>
    public static void LogDebugFormat(string format, params object[] args)
    {
        try
        {
            string message = string.Format(format, args);
            LogDebug(message);
        }
        catch (Exception ex)
        {
            LogError("LogDebugFormat failed", ex);
        }
    }

    /// <summary>
    /// Log formatted warning message
    /// </summary>
    public static void LogWarningFormat(string format, params object[] args)
    {
        try
        {
            string message = string.Format(format, args);
            LogWarning(message);
        }
        catch (Exception ex)
        {
            LogError("LogWarningFormat failed", ex);
        }
    }
}