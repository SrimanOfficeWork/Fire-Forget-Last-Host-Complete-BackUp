<%@ WebHandler Language="C#" Class="RunScheduledReports" %>

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

// Report Settings -> Scheduled Generation runner. Has no login session (this
// is hit by an external scheduler, not a browser with a logged-in user), so
// every company database it should check has to be supplied explicitly via
// ?db=<connection string> - see DSR_ReportSchedule.ConnectionString for why
// there's no other way for this handler to know which database(s) to open.
//
// Point a Windows Task Scheduler job (or any scheduler that can call a URL)
// at this once per company database, e.g. daily:
//   https://yourserver/DSR_Customized_Template/RunScheduledReports.ashx
//     ?key=<ScheduledReportsKey from Web.config>
//     &db=<url-encoded connection string for that company's database>
// Call it once per company if you run more than one. Safe to call more often
// than any schedule's frequency - it only acts on rows whose NextRunAt is due.
public class RunScheduledReports : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        string expectedKey = ConfigurationManager.AppSettings["ScheduledReportsKey"];
        string suppliedKey = context.Request.QueryString["key"];
        if (string.IsNullOrEmpty(expectedKey) || suppliedKey != expectedKey)
        {
            context.Response.StatusCode = 403;
            context.Response.Write("Forbidden: missing or incorrect key.");
            return;
        }

        var dbValues = context.Request.QueryString.GetValues("db");
        if (dbValues == null || dbValues.Length == 0)
        {
            context.Response.StatusCode = 400;
            context.Response.Write("Missing required 'db' query parameter (the target company database's connection string).");
            return;
        }

        try
        {
            var results = ScheduledReportEngine.RunDueSchedules(dbValues);

            if (results.Count == 0)
            {
                context.Response.Write("No schedules were due.");
                return;
            }

            foreach (var r in results)
            {
                context.Response.Write(string.Format(
                    "TemplateID {0} ({1}): {2} - {3}\n",
                    r.TemplateId, r.TemplateName, r.Success ? "OK" : "FAILED", r.Message));
            }
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.Write("Error: " + ex.Message);
        }
    }

    public bool IsReusable { get { return false; } }
}
