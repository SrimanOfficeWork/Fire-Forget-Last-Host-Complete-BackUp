using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Collections.Generic;

/// <summary>
/// Fire-and-forget submitter for the Docker Vision ASYNC queue flow (VENDOR_TYPE "DOCKER_VISION_QUEUE").
/// This is a NEW, separate vendor path from the existing synchronous "Docker_Vision" branch already used
/// by UploadPdfWithParameters in Import_PDF_Reader_AI / Export_PDF_Reader_New_AI — that one waits for the
/// result inline; this one submits, does not wait, and the result comes back later via the FireForget
/// callback API -> FireForget.Worker -> PDF_AI_QUEUE_INSERT_UPDATE_SELECT (UPDATE_STATUS).
///
/// TODO before go-live: DOCKER_VISION_SUBMIT_URL, CALLBACK_BASE_URL and CALLBACK_API_KEY below are
/// placeholders — fill them in from configuration once Docker Vision confirms the submit endpoint and
/// once FireForget.Api is deployed somewhere reachable from this server.
/// </summary>
public static class DockerVisionQueueClient
{
    public const string VENDOR_TYPE = "DOCKER_VISION_QUEUE";

    // ── Configuration placeholders — move to Web.config appSettings before go-live ──────────────
    private static string DOCKER_VISION_SUBMIT_URL
    {
        get { return ConfigOrDefault("DockerVision.SubmitUrl", "https://REPLACE_ME.dockervision.example.com/api/submit"); }
    }
    private static string CALLBACK_BASE_URL
    {
        get { return ConfigOrDefault("FireForget.CallbackBaseUrl", "https://REPLACE_ME.fireforget.example.com"); }
    }
    private static string CALLBACK_API_KEY
    {
        get { return ConfigOrDefault("FireForget.CallbackApiKey", "REPLACE_ME"); }
    }
    // The "server" segment of the ProcessId — must match a key in FireForget.Worker's Routing:Servers config.
    private static string SERVER_NAME
    {
        get { return ConfigOrDefault("FireForget.ServerName", "Local"); }
    }

    private static string ConfigOrDefault(string key, string fallback)
    {
        try
        {
            string val = System.Configuration.ConfigurationManager.AppSettings[key];
            return string.IsNullOrWhiteSpace(val) ? fallback : val;
        }
        catch { return fallback; }
    }

    /// <summary>
    /// Builds "server~eriId~workingPeriod~guid" — must match FireForget.Contracts.ProcessIdCodec exactly,
    /// since the callback API parses it the same way to find the right company database.
    /// </summary>
    public static string BuildProcessId(string eriId, string workingPeriod)
    {
        string server = SERVER_NAME;
        string eri = (eriId ?? "").Trim();
        string wp = Regex.Replace(workingPeriod ?? "", "\\s+", "");
        string token = Guid.NewGuid().ToString("N");

        if (string.IsNullOrEmpty(server) || server.IndexOf('~') >= 0)
            throw new ArgumentException("Invalid server name for ProcessId");
        if (string.IsNullOrEmpty(eri) || eri.IndexOf('~') >= 0)
            throw new ArgumentException("Invalid ERI ID for ProcessId");
        if (string.IsNullOrEmpty(wp) || wp.IndexOf('~') >= 0)
            throw new ArgumentException("Invalid working period for ProcessId");

        return server + "~" + eri + "~" + wp + "~" + token;
    }

    /// <summary>
    /// Posts the file(s) + routing headers to Docker Vision and returns immediately — this method does NOT
    /// wait for extraction to finish. It only waits long enough to confirm Docker Vision accepted the job.
    /// Returns true + processId on a successful submit; false + error message otherwise (caller should NOT
    /// insert a queue row in that case, since nothing was actually queued on the vendor's side).
    /// </summary>
    public static bool SubmitAndForget(
        List<string> filePaths, List<string> fileNames,
        string eriId, string workingPeriod, string jobType, string pdfClientName,
        out string processId, out string errorMessage)
    {
        processId = BuildProcessId(eriId, workingPeriod);
        errorMessage = "";

        try
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(DOCKER_VISION_SUBMIT_URL);
            request.Method = "POST";
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.KeepAlive = false;
            request.AllowWriteStreamBuffering = false;
            request.SendChunked = true;
            // Short timeouts: we only need Docker Vision to ACCEPT the job, not to finish it.
            request.Timeout = 60 * 1000;
            request.ReadWriteTimeout = 60 * 1000;

            // Routing headers — Docker Vision echoes ProcessId back on the callback; everything else
            // (server / ERI / working period) is already encoded inside ProcessId, so if they can only
            // return the ProcessId, routing still works.
            request.Headers.Add("X-Process-Id", processId);
            request.Headers.Add("X-Eri-Id", eriId ?? "");
            request.Headers.Add("X-Job-Type", jobType ?? "");
            request.Headers.Add("X-Pdf-Client-Name", pdfClientName ?? "");
            request.Headers.Add("X-Callback-Url", CALLBACK_BASE_URL.TrimEnd('/') + "/api/v1/callback/docker-vision");
            request.Headers.Add("X-Callback-Api-Key", CALLBACK_API_KEY);

            using (Stream requestStream = request.GetRequestStream())
            {
                for (int i = 0; i < filePaths.Count; i++)
                {
                    requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                    string header = "Content-Disposition: form-data; name=\"File" + i + "\"; filename=\""
                        + Path.GetFileName(fileNames[i]) + "\"\r\nContent-Type: application/pdf\r\n\r\n";
                    byte[] headerBytes = Encoding.UTF8.GetBytes(header);
                    requestStream.Write(headerBytes, 0, headerBytes.Length);

                    using (FileStream fs = new FileStream(filePaths[i], FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        byte[] buffer = new byte[131072];
                        int bytesRead;
                        while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                            requestStream.Write(buffer, 0, bytesRead);
                    }
                }
                requestStream.Write(trailer, 0, trailer.Length);
            }

            using (WebResponse response = request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string body = reader.ReadToEnd();
                // Docker Vision is expected to reply 200/202 with just an acknowledgement — the real
                // extraction JSON comes later via the callback, so the body here is not parsed for data.
            }

            return true;
        }
        catch (WebException wex)
        {
            errorMessage = "Docker Vision submit failed: " + wex.Message;
            if (wex.Response != null)
            {
                try
                {
                    using (var er = (HttpWebResponse)wex.Response)
                    using (var rdr = new StreamReader(er.GetResponseStream()))
                        errorMessage += " | Response: " + rdr.ReadToEnd();
                }
                catch { }
            }
            return false;
        }
        catch (Exception ex)
        {
            errorMessage = "Docker Vision submit failed: " + ex.Message;
            return false;
        }
    }

    /// <summary>
    /// Converts a stored Docker Vision result (JSON_RESPONSE column, already a JSON array of invoices —
    /// same shape produced by the synchronous vendor call) into the DataSet shape the Import/Export AI
    /// pages already expect: Header(0), InvoiceDetails/ItemsDetails(1,2 for Import) — mirrors the parsing
    /// Gen_AI_PDF.Get_AccessToken_Invoice and Export_PDF_Reader_New_AI.ConvertJsonToDataSet already do.
    /// </summary>
    public static DataSet ConvertStoredJsonToDataSet(string json)
    {
        DataSet ds = new DataSet();
        if (string.IsNullOrWhiteSpace(json)) return ds;

        DataTable dtHeader = new DataTable("Header");
        DataTable dtInvoice = new DataTable("InvoiceDetails");
        DataTable dtItems = new DataTable("ItemsDetails");
        DataTable dtContainer = new DataTable("ShipmentContainerDetails");

        try
        {
            JToken root = JToken.Parse(json);
            JArray invoices = root.Type == JTokenType.Array ? (JArray)root : new JArray(root);

            foreach (JObject inv in invoices)
            {
                MergeTable(dtHeader, inv["Header"]);
                MergeTable(dtInvoice, inv["InvoiceDetails"]);
                MergeTable(dtItems, inv["ItemsDetails"]);
                MergeTable(dtContainer, inv["ShipmentContainerDetails"]);
            }
        }
        catch (Exception)
        {
            return new DataSet(); // caller checks Tables[n].Rows.Count == 0 and shows "please retry"
        }

        if (dtHeader.Rows.Count > 0) ds.Tables.Add(dtHeader);
        if (dtInvoice.Rows.Count > 0) ds.Tables.Add(dtInvoice);
        if (dtItems.Rows.Count > 0) ds.Tables.Add(dtItems);
        if (dtContainer.Rows.Count > 0) ds.Tables.Add(dtContainer);
        return ds;
    }

    private static void MergeTable(DataTable target, JToken section)
    {
        if (section == null || section.Type == JTokenType.Null) return;

        JArray arr = section.Type == JTokenType.Array ? (JArray)section : new JArray(section);
        if (arr.Count == 0) return;

        DataTable temp = JsonConvert.DeserializeObject<DataTable>(arr.ToString());
        if (temp == null) return;

        if (target.Columns.Count == 0)
        {
            foreach (DataColumn c in temp.Columns)
                if (!target.Columns.Contains(c.ColumnName)) target.Columns.Add(c.ColumnName, c.DataType);
        }

        foreach (DataRow r in temp.Rows)
        {
            DataRow newRow = target.NewRow();
            foreach (DataColumn c in temp.Columns)
                if (target.Columns.Contains(c.ColumnName)) newRow[c.ColumnName] = r[c.ColumnName];
            target.Rows.Add(newRow);
        }
    }
}
