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

    // ── Fire-and-Forget ──────────────────────────────────────────────
    // Returns the ProcessID, or "" when the job could not be queued (see errorMsg).
    public static string FireAndForget(List<DockerVisionRequest> requests, string jobType, out string errorMsg)
    {
        errorMsg = Validate(requests);
        if (errorMsg != "") return "";

        // PdfCount = number of PDFs in this job
        foreach (DockerVisionRequest req in requests)
            req.FormFields["PdfCount"] = requests.Count.ToString();

        string connStr = Connection.GetConnection();
        string processId = Insert_Job(connStr, jobType, requests);

        Thread worker = new Thread(delegate ()
        {
            Run_Extraction(processId, requests, connStr);
        });
        worker.IsBackground = true;
        worker.Start();

        return processId;
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

    private static void Run_Extraction(string processId, List<DockerVisionRequest> requests, string connStr)
    {
        try
        {
            JArray responses = new JArray();
            foreach (DockerVisionRequest req in requests)
            {
                string result = Post_Multipart(req);
                if (string.IsNullOrWhiteSpace(result))
                    throw new Exception("Empty Docker Vision response for " + Path.GetFileName(req.FilePath));
                responses.Add(JToken.Parse(result)); // must be valid JSON
            }
            // Single PDF → same format as the Docker Vision response; several PDFs → JSON array (one per PDF)
            string json = responses.Count == 1 ? responses[0].ToString(Formatting.None) : responses.ToString(Formatting.None);
            Update_Job(connStr, processId, json, false);
        }
        catch (Exception ex)
        {
            try { Update_Job(connStr, processId, "", true); } catch { }
            try { new ErrorLogs().makeLog("Docker Vision Extraction Error (" + processId + ") : " + ex.ToString()); } catch { }
        }
    }

    // ── Multipart POST to Docker Vision ──────────────────────────────
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

    private static string Cut(string value, int maxLength)
    {
        value = value ?? "";
        return value.Length > maxLength ? value.Substring(0, maxLength) : value;
    }

    // ── OCR_AI_Extraction_Responses: insert job (JsonData = '' → IN PROGRESS) ──
    private static string Insert_Job(string connStr, string jobType, List<DockerVisionRequest> requests)
    {
        NameValueCollection f = requests[0].FormFields;
        List<string> fileNames = new List<string>();
        int pageCount = 0, pages;
        foreach (DockerVisionRequest req in requests)
        {
            fileNames.Add(Path.GetFileName(req.FilePath));
            if (int.TryParse(req.FormFields["PageCount"], out pages)) pageCount += pages;
        }

        const string sql =
            "INSERT INTO OCR_AI_Extraction_Responses " +
            "(CompanyID, UserID, BranchCode, JobNo, JobType, WorkingPeriod, PageCount, PdfCount, " +
            " JobStatus, FileName, Received_Time, PdfClientName, JsonData) " +
            "VALUES (@CompanyID, @UserID, @BranchCode, @JobNo, @JobType, @WorkingPeriod, @PageCount, @PdfCount, " +
            " @JobStatus, @FileName, GETDATE(), @PdfClientName, ''); " +
            "SELECT CAST(SCOPE_IDENTITY() AS INT);";

        using (SqlConnection con = new SqlConnection(connStr))
        using (SqlCommand cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@CompanyID", Cut(f["CompanyID"], 100));
            cmd.Parameters.AddWithValue("@UserID", Cut(f["UserID"], 100));
            cmd.Parameters.AddWithValue("@BranchCode", Cut(f["BranchCode"], 200));
            cmd.Parameters.AddWithValue("@JobNo", Cut(f["JobNo"], 100));
            cmd.Parameters.AddWithValue("@JobType", Cut(f["JobType"] ?? jobType, 10));
            cmd.Parameters.AddWithValue("@WorkingPeriod", Cut(f["WorkingPeriod"], 300));
            cmd.Parameters.AddWithValue("@PageCount", pageCount.ToString());
            cmd.Parameters.AddWithValue("@PdfCount", requests.Count.ToString());
            cmd.Parameters.AddWithValue("@JobStatus", Cut(f["JobStatus"], 10));
            cmd.Parameters.AddWithValue("@FileName", Cut(string.Join(", ", fileNames.ToArray()), 200));
            cmd.Parameters.AddWithValue("@PdfClientName", Cut(f["PdfClientName"], 100));
            con.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()).ToString();
        }
    }

    // ── OCR_AI_Extraction_Responses: store JSON (READY) or mark FAILED ──
    private static void Update_Job(string connStr, string processId, string json, bool failed)
    {
        string sql = failed
            ? "UPDATE OCR_AI_Extraction_Responses SET JobStatus = 'FAILED', Received_Time = GETDATE() WHERE Id = @Id"
            : "UPDATE OCR_AI_Extraction_Responses SET JsonData = @JsonData, Received_Time = GETDATE() WHERE Id = @Id";

        using (SqlConnection con = new SqlConnection(connStr))
        using (SqlCommand cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@Id", int.Parse(processId));
            if (!failed) cmd.Parameters.Add("@JsonData", SqlDbType.NVarChar, -1).Value = json ?? "";
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // ── One Docker Vision job, picked from DB by ProcessID only ──────
    // OCR_AI_Extraction_Responses row + its PDF_AI_QUEUE row (same ProcessID).
    public class DockerVisionJob
    {
        public string ProcessId, CompanyID, BranchCode, WorkingPeriod, JobType, PdfClientName;
        public string JobNo, FileName, PageCount, PdfCount;
        public string Status;                 // IN PROGRESS / READY / FAILED
        public string Json;                   // stored JSON (READY only)
        // from the queue row of the same ProcessID
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

    // ── Get job by ProcessID ─────────────────────────────────────────
    // The response row is returned only when exactly one Docker Vision queue row carries the
    // same ProcessID and job type, so a row of another job/process can never be picked.
    public static DockerVisionJob Get_Job(string processId)
    {
        int id;
        if (!int.TryParse(processId, out id) || id.ToString() != processId) return null;

        const string sql =
            "SELECT r.Id, r.CompanyID, r.BranchCode, r.WorkingPeriod, r.JobType, r.PdfClientName, r.JobNo, r.FileName, " +
            "       r.PageCount, r.PdfCount, r.JobStatus, r.JsonData, " +
            "       q.IMPORTER_NAME, q.SL_NO, q.PDF_CLIENT_NAME, q.PDF_ID " +
            "FROM OCR_AI_Extraction_Responses r " +
            "JOIN PDF_AI_QUEUE q ON q.PROCESS_ID = @PROCESS_ID AND q.VENDOR_TYPE = @VENDOR_TYPE " +
            "                   AND UPPER(q.JOB_TYPE) = UPPER(r.JobType) " +
            "WHERE r.Id = @Id";

        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(Connection.GetConnection()))
        using (SqlCommand cmd = new SqlCommand(sql, con))
        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        {
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@PROCESS_ID", processId);
            cmd.Parameters.AddWithValue("@VENDOR_TYPE", VENDOR_TYPE);
            da.Fill(dt);
        }
        if (dt.Rows.Count != 1) return null;

        DataRow row = dt.Rows[0];
        DockerVisionJob job = new DockerVisionJob();
        job.ProcessId = row["Id"].ToString();
        job.CompanyID = row["CompanyID"].ToString();
        job.BranchCode = row["BranchCode"].ToString();
        job.WorkingPeriod = row["WorkingPeriod"].ToString();
        job.JobType = row["JobType"].ToString();
        job.PdfClientName = row["PdfClientName"].ToString();
        job.JobNo = row["JobNo"].ToString();
        job.FileName = row["FileName"].ToString();
        job.PageCount = row["PageCount"].ToString();
        job.PdfCount = row["PdfCount"].ToString();
        job.PartyName = row["IMPORTER_NAME"].ToString();
        job.SlNo = row["SL_NO"].ToString();
        job.MasterPdfClientName = row["PDF_CLIENT_NAME"].ToString();
        job.PdfId = row["PDF_ID"].ToString();

        string json = row["JsonData"].ToString();
        if (row["JobStatus"].ToString() == "FAILED") job.Status = "FAILED";
        else if (string.IsNullOrWhiteSpace(json)) job.Status = "IN PROGRESS";
        else { job.Status = "READY"; job.Json = json; }
        return job;
    }

    // ── Get READY job for the result screen ──────────────────────────
    // jobType = job type of the screen that opens the result. The job's own Company ID, Branch Code and
    // Working Period (stored at AI Run start) must be the ones the result is processed under.
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
