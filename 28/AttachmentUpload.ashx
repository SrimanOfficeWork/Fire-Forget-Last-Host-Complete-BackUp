<%@ WebHandler Language="C#" Class="AttachmentUpload" %>

// AttachmentUpload.ashx - single-file Generic Handler (inline code, no code-behind).
//
// Why single-file: your project is an ASP.NET "Website" project (not a Web Application
// project with a .csproj) - those sometimes don't resolve System.Web references correctly for
// a separate .ashx.cs code-behind file added outside the normal page structure. Putting the
// code directly in the .ashx avoids that entirely; this is the standard, simplest pattern for
// a single handler in a Website project.
//
// SETUP:
// 1. Copy this ONE file into your eroyalimpex2026 project root (or any folder in it).
//    Delete AttachmentUpload.ashx.cs if you already added it - not needed with this version.
// 2. web.config - add these two appSettings (same <appSettings> block you already have):
//      <add key="AttachmentUploadApiKey" value="PUT-A-LONG-RANDOM-SECRET-HERE"/>
//      <add key="AttachmentLocalRoot" value="D:\ERoyalImpex_Final_New_New\Submission\"/>
// 3. Worker's secrets.json points at this handler's full URL, e.g.:
//      "AttachmentUploadUrls":    { "live": "https://sudarshannew.eroyalimpex.trade/AttachmentUpload.ashx" }
//      "AttachmentUploadApiKeys": { "live": "PUT-THE-SAME-SECRET-HERE" }

using System;
using System.IO;
using System.Web;
using System.Configuration;

public class AttachmentUpload : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        // --- auth ---
        var expectedKey = ConfigurationManager.AppSettings["AttachmentUploadApiKey"];
        var providedKey = context.Request.Headers["X-Api-Key"];

        if (string.IsNullOrEmpty(expectedKey) || providedKey != expectedKey)
        {
            context.Response.StatusCode = 401;
            context.Response.Write("Unauthorized");
            return;
        }

        // --- read fields (Worker sends these as multipart/form-data) ---
        string companyId = context.Request.Form["companyId"];
        string workingPeriod = context.Request.Form["workingPeriod"];
        string groupName = context.Request.Form["groupName"]; // may be empty - Esanchit uploads have no group subfolder
        string fileName = context.Request.Form["fileName"];
        var file = context.Request.Files["file"];

        if (file == null || file.ContentLength == 0 || string.IsNullOrEmpty(companyId) || string.IsNullOrEmpty(fileName))
        {
            context.Response.StatusCode = 400;
            context.Response.Write("Missing required fields");
            return;
        }

        // --- path traversal guard - fileName must never contain a path segment ---
        fileName = Path.GetFileName(fileName);
        if (string.IsNullOrEmpty(fileName))
        {
            context.Response.StatusCode = 400;
            context.Response.Write("Invalid fileName");
            return;
        }

        try
        {
            string localRoot = ConfigurationManager.AppSettings["AttachmentLocalRoot"];

            // {LocalRoot}/{workingPeriod}/{companyId}/{groupName}/Attachments/{fileName}
            // (groupName omitted for Esanchit uploads, which send it blank)
            string destFolder = string.IsNullOrEmpty(groupName)
                ? Path.Combine(localRoot, workingPeriod ?? "", companyId, "Attachments")
                : Path.Combine(localRoot, workingPeriod ?? "", companyId, groupName, "Attachments");

            Directory.CreateDirectory(destFolder);

            string destPath = Path.Combine(destFolder, fileName);
            file.SaveAs(destPath); // overwrites if it already exists

            context.Response.StatusCode = 200;
            context.Response.Write("OK");
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.Write("Save failed: " + ex.Message);
        }
    }

    public bool IsReusable { get { return false; } }
}
