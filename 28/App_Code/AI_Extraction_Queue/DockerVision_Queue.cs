using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// Docker Vision — PUSH model (GUID ProcessId).
//  1. 4.0 creates a GUID ProcessId (Guid.NewGuid) and inserts the PDF_AI_QUEUE row (IN PROGRESS).
//  2. 4.0 posts the PDF to Cochin as form-data with ProcessId + CallbackUrl + CallbackApiKey.
//  3. Cochin's reply here is only an acknowledgement. The extraction JSON is POSTed later by Cochin as
//     form-data to FireForget.Api: /api/v1/callback/docker-vision/ with the fields ServerName, CompanyID and
//     ProcessId plus the JSON. It is stored in PDF_AI_QUEUE.JSON_RESPONSE and STATUS = READY (or FAILED).
//  4. The AI Extraction Queue screen reads STATUS / JSON_RESPONSE from PDF_AI_QUEUE.
public class DockerVision_Queue
{
    public const string VENDOR_TYPE = "DOCKER_VISION";

    public static bool IsDockerVision(string vendorType)
    {
        return !string.IsNullOrEmpty(vendorType)
            && vendorType.StartsWith(VENDOR_TYPE, StringComparison.OrdinalIgnoreCase);
    }

    // One Docker Vision request (captured on the request thread — no Session in background)
    public class DockerVisionRequest
    {
        public string ApiUrl;
        public string ApiKey;
        public string FilePath;
        public NameValueCollection FormFields;
    }

    // ── Submit ───────────────────────────────────────────────────────
    // Returns the GUID ProcessId, or "" when the job could not be submitted (see errorMsg).
    // The PDF_AI_QUEUE row is inserted by the caller (Insert_Queue_Record) with this ProcessId.
    public static string FireAndForget(List<DockerVisionRequest> requests, string jobType, out string errorMsg)
    {
        errorMsg = Validate(requests);
        if (errorMsg != "") return "";

        string processId = Guid.NewGuid().ToString();
        string serverName = ConfigValue("FireForget.ServerName", "Local");
        string callbackBase = ConfigValue("FireForget.CallbackBaseUrl", "").TrimEnd('/');
        string callbackKey = ConfigValue("FireForget.CallbackApiKey", "");
        string eriId = requests[0].FormFields["CompanyID"];

        if (callbackBase == "" || callbackKey == "")
        {
            errorMsg = "Docker Vision callback is not configured (FireForget.CallbackBaseUrl / FireForget.CallbackApiKey).";
            return "";
        }

        string callbackUrl = callbackBase + "/api/v1/callback/docker-vision/";

        foreach (DockerVisionRequest req in requests)
        {
            // PdfCount = number of PDFs in this job; ProcessId + callback details travel in the form-data.
            // Cochin returns ServerName, CompanyID and ProcessId in its callback form-data.
            req.FormFields["PdfCount"] = requests.Count.ToString();
            req.FormFields["ServerName"] = serverName;
            req.FormFields["ProcessId"] = processId;
            req.FormFields["CallbackUrl"] = callbackUrl;
            req.FormFields["CallbackApiKey"] = callbackKey;
        }

        string connStr = Connection.GetConnection();
        Thread worker = new Thread(delegate ()
        {
            Run_Acknowledge(processId, requests, connStr);
        });
        worker.IsBackground = true;
        worker.Start();

        return processId;
    }

    private static string ConfigValue(string key, string fallback)
    {
        try
        {
            string val = System.Configuration.ConfigurationManager.AppSettings[key];
            return string.IsNullOrWhiteSpace(val) ? fallback : val;
        }
        catch { return fallback; }
    }

    // Required: PdfClientName, JobType, CompanyID, File
    private static string Validate(List<DockerVisionRequest> requests)
    {
        if (requests == null || requests.Count == 0) return "No PDF file to extract.";
        foreach (DockerVisionRequest req in requests)
        {
            if (string.IsNullOrWhiteSpace(req.FormFields["PdfClientName"])) return "PdfClientName is required.";
            if (string.IsNullOrWhiteSpace(req.FormFields["JobType"])) return "JobType is required.";
            if (string.IsNullOrWhiteSpace(req.FormFields["CompanyID"])) return "CompanyID is required.";
            if (string.IsNullOrWhiteSpace(req.FilePath) || !File.Exists(req.FilePath)) return "PDF file not found.";
        }
        return "";
    }

    // Background: send the PDF(s) and only check Cochin's acknowledgement. The JSON is NOT stored here —
    // it arrives later at the FireForget callback. A failed submit marks the queue row FAILED.
    private static void Run_Acknowledge(string processId, List<DockerVisionRequest> requests, string connStr)
    {
        try
        {
            foreach (DockerVisionRequest req in requests)
            {
                string ack = Post_Multipart(req);
                if (ack == null)
                    throw new Exception("No acknowledgement from Docker Vision for " + Path.GetFileName(req.FilePath));
            }
        }
        catch (Exception ex)
        {
            try { Mark_Failed(connStr, processId, ex.Message); } catch { }
            try { new ErrorLogs().makeLog("Docker Vision Submit Error (" + processId + ") : " + ex.ToString()); } catch { }
        }
    }

    // Marks the queue row FAILED with no JSON (a submit that never reached Cochin).
    private static void Mark_Failed(string connStr, string processId, string reason)
    {
        const string sql = "UPDATE PDF_AI_QUEUE SET STATUS = 'FAILED', UPDATED_DATE = GETDATE() WHERE PROCESS_ID = @PROCESS_ID";
        using (SqlConnection con = new SqlConnection(connStr))
        using (SqlCommand cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@PROCESS_ID", processId);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // ── Multipart POST to Docker Vision ──────────────────────────────
    // Returns Cochin's acknowledgement body (may be non-JSON; it is not stored).
    public static string Post_Multipart(DockerVisionRequest req)
    {
        string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
        byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
        byte[] trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(req.ApiUrl);
        request.Headers.Add("ApiKey", req.ApiKey);
        request.Method = "POST";
        request.ContentType = "multipart/form-data; boundary=" + boundary;
        request.KeepAlive = true;
        request.AllowWriteStreamBuffering = false;
        request.SendChunked = true;
        request.Timeout = 10 * 60 * 1000;
        request.ReadWriteTimeout = 10 * 60 * 1000;

        using (Stream requestStream = request.GetRequestStream())
        {
            foreach (string key in req.FormFields)
            {
                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                string fieldData = "Content-Disposition: form-data; name=\"" + key + "\"\r\n\r\n" + req.FormFields[key];
                byte[] fieldBytes = Encoding.UTF8.GetBytes(fieldData);
                requestStream.Write(fieldBytes, 0, fieldBytes.Length);
            }

            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            string header = "Content-Disposition: form-data; name=\"File\"; filename=\""
                + Path.GetFileName(req.FilePath) + "\"\r\nContent-Type: application/pdf\r\n\r\n";
            byte[] headerBytes = Encoding.UTF8.GetBytes(header);
            requestStream.Write(headerBytes, 0, headerBytes.Length);

            using (var fileStream = new FileStream(req.FilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 131072))
            {
                byte[] buffer = new byte[131072];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    requestStream.Write(buffer, 0, bytesRead);
            }

            requestStream.Write(trailer, 0, trailer.Length);
        }

        using (WebResponse webResp = request.GetResponse())
        using (StreamReader reader = new StreamReader(webResp.GetResponseStream()))
        {
            return reader.ReadToEnd();
        }
    }

    // ── One Docker Vision job, read from PDF_AI_QUEUE by ProcessId (GUID) ──
    public class DockerVisionJob
    {
        public string ProcessId, CompanyID, BranchCode, WorkingPeriod, JobType, PdfClientName;
        public string JobNo, FileName, PageCount, PdfCount;
        public string Status;                 // IN PROGRESS / READY / FAILED
        public string Json;                   // JSON_RESPONSE (READY only)
        public string PartyName, SlNo, MasterPdfClientName, PdfId;

        // Stored JSON → list of per-file Docker Vision responses (same format as the old sync API output)
        public List<string> JsonList()
        {
            List<string> list = new List<string>();
            if (Status != "READY") return list;

            JToken token = JToken.Parse(Json);
            if (token.Type == JTokenType.Array)
                foreach (JToken t in token) list.Add(t.ToString());
            else
                list.Add(Json);
            return list;
        }
    }

    // ── Get job by ProcessId from PDF_AI_QUEUE ───────────────────────
    // Only a Docker Vision row with this ProcessId is returned.
    public static DockerVisionJob Get_Job(string processId)
    {
        Guid parsedId;
        if (!Guid.TryParse(processId, out parsedId)) return null;

        const string sql =
            "SELECT PROCESS_ID, COMPANY_ID, BRANCH_CODE, WORKING_PERIOD, JOB_TYPE, PDF_CLIENT_NAME, JOB_NO, FILE_NAME, " +
            "       STATUS, JSON_RESPONSE, IMPORTER_NAME, SL_NO, PDF_ID, VENDOR_TYPE " +
            "FROM PDF_AI_QUEUE WHERE PROCESS_ID = @PROCESS_ID AND VENDOR_TYPE LIKE @VENDOR + '%'";

        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(Connection.GetConnection()))
        using (SqlCommand cmd = new SqlCommand(sql, con))
        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        {
            cmd.Parameters.AddWithValue("@PROCESS_ID", processId);
            cmd.Parameters.AddWithValue("@VENDOR", VENDOR_TYPE);
            da.Fill(dt);
        }
        if (dt.Rows.Count != 1) return null;

        DataRow row = dt.Rows[0];
        DockerVisionJob job = new DockerVisionJob();
        job.ProcessId = row["PROCESS_ID"].ToString();
        job.CompanyID = row["COMPANY_ID"].ToString();
        job.BranchCode = row["BRANCH_CODE"].ToString();
        job.WorkingPeriod = row["WORKING_PERIOD"].ToString();
        job.JobType = row["JOB_TYPE"].ToString();
        job.PdfClientName = row["PDF_CLIENT_NAME"].ToString();
        job.JobNo = row["JOB_NO"].ToString();
        job.FileName = row["FILE_NAME"].ToString();
        job.PageCount = "0"; // PDF_AI_QUEUE does not store a page count
        job.PdfCount = "1";
        job.PartyName = row["IMPORTER_NAME"].ToString();
        job.SlNo = row["SL_NO"].ToString();
        job.MasterPdfClientName = row["PDF_CLIENT_NAME"].ToString();
        job.PdfId = row["PDF_ID"].ToString();

        string status = row["STATUS"].ToString();
        string json = row["JSON_RESPONSE"] == DBNull.Value ? "" : row["JSON_RESPONSE"].ToString();
        if (status == "FAILED") job.Status = "FAILED";
        else if (status == "READY" && !string.IsNullOrWhiteSpace(json)) { job.Status = "READY"; job.Json = json; }
        else job.Status = "IN PROGRESS";
        return job;
    }

    // ── Get READY job for the result screen ──────────────────────────
    // jobType = job type of the screen that opens the result. The job's own Company ID, Branch Code and
    // Working Period (stored at submit) must be the ones the result is processed under.
    public static DockerVisionJob Get_Ready_Job(string processId, string jobType, out string errorMsg)
    {
        errorMsg = "";
        DockerVisionJob job = Get_Job(processId);

        if (job == null) errorMsg = "Extraction job not found for this Process ID.";
        else if (job.Status != "READY") errorMsg = "Extraction result is not ready for this job (" + job.Status + ").";
        else if (!string.Equals(job.JobType, jobType, StringComparison.OrdinalIgnoreCase))
            errorMsg = "This job type is " + job.JobType + " and it cannot be opened on this screen.";
        else if (!string.Equals(job.CompanyID, Connection.Company_License(), StringComparison.OrdinalIgnoreCase))
            errorMsg = "This job belongs to a different company.";
        else if (job.BranchCode != Connection.Current_Branch())
            errorMsg = "This job belongs to branch " + job.BranchCode + ". Please open it from that branch.";
        else if (job.WorkingPeriod != Connection.WorkingPeriod())
            errorMsg = "This job belongs to working period " + job.WorkingPeriod + ". Please open it from that working period.";

        return errorMsg == "" ? job : null;
    }

    // IN PROGRESS / READY / FAILED for a ProcessID; json = stored JSON when READY
    public static string Get_Status(string processId, out string json)
    {
        json = "";
        DockerVisionJob job = Get_Job(processId);
        if (job == null) return "FAILED";

        if (job.Status == "READY") json = job.Json;
        return job.Status;
    }
}
