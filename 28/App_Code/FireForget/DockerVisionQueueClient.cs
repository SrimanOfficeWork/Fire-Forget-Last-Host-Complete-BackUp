using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Fire-and-forget submitter for the Docker Vision ASYNC queue flow (VENDOR_TYPE "DOCKER_VISION_QUEUE").
/// This is a NEW, separate vendor path from the existing synchronous "Docker_Vision" branch already used
/// by UploadPdfWithParameters in Import_PDF_Reader_AI / Export_PDF_Reader_New_AI — that one waits for the
/// result inline; this one submits, does not wait, and the result comes back later via the FireForget
/// callback API -> FireForget.Worker -> PDF_AI_QUEUE_INSERT_UPDATE_SELECT (UPDATE_STATUS).
///
/// IMPORTANT: the submit call below deliberately mirrors UploadPdfWithParameters's EXISTING, proven
/// multipart/form-data contract (same URL, same "ApiKey" header, same field names, single "File" field)
/// instead of inventing a new one — a prior version of this class sent custom HTTP headers for ProcessId/
/// EriId/CallbackUrl that the Cochin cloud function was never coded to read, which would have silently
/// never worked. ProcessId and CallbackUrl are now sent as two EXTRA form fields in that same body instead.
///
/// TODO before go-live: CALLBACK_BASE_URL/CALLBACK_API_KEY are placeholders, and the exact field names
/// "ProcessId" / "CallbackUrl" / "CallbackApiKey" below are NOT yet confirmed with the Docker Vision
/// (Cochin) team — confirm the exact names (and that extra form fields are even accepted) before go-live.
/// Also NOTE this only supports ONE file per submission, matching the proven contract; Export's multi-file
/// batching must loop one submission per file until/unless Docker Vision confirms multi-file support.
/// </summary>
public static class DockerVisionQueueClient
{
    public const string VENDOR_TYPE = "DOCKER_VISION_QUEUE";

    // ── Configuration placeholders — move to Web.config appSettings before go-live ──────────────
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
    /// Posts ONE file to Docker Vision using the SAME multipart contract UploadPdfWithParameters already
    /// uses successfully, plus two extra form fields (ProcessId, CallbackUrl) so Docker Vision knows where
    /// to send the result later. Does NOT wait for extraction — only for Docker Vision to accept the job.
    /// Returns true + processId on a successful submit; false + error message otherwise (caller should NOT
    /// insert a queue row in that case, since nothing was actually queued on the vendor's side).
    /// </summary>
    public static bool SubmitAndForget(
        string filePath, string fileName,
        string companyId, string userId, string branchCode, string jobNo,
        string jobType, string workingPeriod, string pdfClientName, string eriId,
        out string processId, out string errorMessage)
    {
        processId = BuildProcessId(eriId, workingPeriod);
        errorMessage = "";

        try
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

            // Same endpoint + same "ApiKey" header UploadPdfWithParameters uses for the general case.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                "https://asia-south1-serene-essence-419307.cloudfunctions.net/royal-invoice");
            request.Headers.Add("ApiKey", "12345");

            request.Method = "POST";
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.KeepAlive = false;
            request.AllowWriteStreamBuffering = false;
            request.SendChunked = true;
            // Short timeout: we only need Docker Vision to ACCEPT the job, not to finish it.
            request.Timeout = 60 * 1000;
            request.ReadWriteTimeout = 60 * 1000;

            NameValueCollection formFields = new NameValueCollection
            {
                // Exactly the same field names/values UploadPdfWithParameters sends today.
                { "CompanyID", companyId ?? "" },
                { "UserID", userId ?? "" },
                { "BranchCode", branchCode ?? "" },
                { "JobNo", jobNo ?? "" },
                { "JobType", jobType ?? "" },
                { "WorkingPeriod", workingPeriod ?? "" },
                { "PageCount", "0" },
                { "PdfCount", "0" },
                { "JobStatus", "N" },
                { "FileName", "1" },
                { "InvoiceStartTime", DateTime.Now.ToString() },
                { "PdfClientName", pdfClientName ?? "" },
                // NEW fields for the async queue path — names unconfirmed, see class remarks above.
                { "ProcessId", processId },
                { "CallbackUrl", CALLBACK_BASE_URL.TrimEnd('/') + "/api/v1/callback/docker-vision" },
                { "CallbackApiKey", CALLBACK_API_KEY }
            };

            using (Stream requestStream = request.GetRequestStream())
            {
                foreach (string key in formFields)
                {
                    requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                    string fieldData = "Content-Disposition: form-data; name=\"" + key + "\"\r\n\r\n" + formFields[key];
                    byte[] fieldBytes = Encoding.UTF8.GetBytes(fieldData);
                    requestStream.Write(fieldBytes, 0, fieldBytes.Length);
                }

                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                string fileHeader = "Content-Disposition: form-data; name=\"File\"; filename=\""
                    + Path.GetFileName(fileName) + "\"\r\nContent-Type: application/pdf\r\n\r\n";
                byte[] fileHeaderBytes = Encoding.UTF8.GetBytes(fileHeader);
                requestStream.Write(fileHeaderBytes, 0, fileHeaderBytes.Length);

                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] buffer = new byte[131072];
                    int bytesRead;
                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                        requestStream.Write(buffer, 0, bytesRead);
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

    // NOTE: an earlier version of this class had a ConvertStoredJsonToDataSet() here that assumed the
    // callback JSON was an array of invoices (the EROYAL/PMDG ocrResult shape). A real Docker Vision
    // response (TIMKEN US sample, 2026-09-30) proved that assumption wrong: Docker Vision's own JSON is
    // a single flat object — Header/InvoiceDetails/ItemsDetails/ItemsIGMContainerDetails (Import) or
    // Header/ItemsDetails/ShipmentContainerDetails (Export) — the exact same shape the EXISTING synchronous
    // vendors (UploadPdfExtraction, UploadPdfWithParameters) already pass straight to
    // JsonConvert.DeserializeObject<DataSet>(...). Both Import_PDF_Reader_AI and Export_PDF_Reader_New_AI
    // now do exactly that with the stored JSON too, so no extra conversion is needed here.
}
