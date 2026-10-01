using System;
using System.IO;
using System.Net;
using System.Text;

/// <summary>
/// Summary description for Checklist_Api_Send
/// </summary>
public class Checklist_Api_Send
{
    private static string apiUrl = "https://b1.gocargonet.com/Royal_HHL/api/shipments/eDocsUploadserver";// 
    private static string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiI1NjYzIiwiVXNlck5hbWUiOiJJQ1RRUkFkbWluIiwibmJmIjoxNzcyNzcwNzgwLCJleHAiOjI1MzQwMjI4MTAwMCwiaWF0IjoxNzcyNzcwNzgwfQ.t-N3XZNZ8-9OtkDILFQUkRGQ9LFxcgaVvUZIMfK_APw"; // your full token here
    //private static string Parvathy_Url = "http://d149bwa4ngxct6jq9s4gudi4.45.195.159.147.sslip.io/api/checklist/upload";
    private static string Parvathy_Url = "https://omrcheklist.duckdns.org/api/checklist/upload";
    /*
    public static string SendAttachmentToApi(string filePath)
    {
        try
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "POST";
            request.ContentType = "multipart/form-data; boundary=" + boundary;

            request.Headers.Add("Authorization", "Bearer " + token);

            using (Stream requestStream = request.GetRequestStream())
            {
                string folderName = "ERoyaluploads";

                string folderPart =
                    "--" + boundary + "\r\n" +
                    "Content-Disposition: form-data; name=\"uploadFolder\"\r\n\r\n" +
                    folderName + "\r\n";

                byte[] folderBytes = Encoding.UTF8.GetBytes(folderPart);
                requestStream.Write(folderBytes, 0, folderBytes.Length);

                byte[] fileBytes = File.ReadAllBytes(filePath);
                string fileName = Path.GetFileName(filePath);

                string fileHeader =
                    "--" + boundary + "\r\n" +
                    "Content-Disposition: form-data; name=\"file\"; filename=\"" + fileName + "\"\r\n" +
                    "Content-Type: application/octet-stream\r\n\r\n";

                byte[] headerBytes = Encoding.UTF8.GetBytes(fileHeader);

                requestStream.Write(headerBytes, 0, headerBytes.Length);
                requestStream.Write(fileBytes, 0, fileBytes.Length);

                byte[] newline = Encoding.UTF8.GetBytes("\r\n");
                requestStream.Write(newline, 0, newline.Length);

                byte[] footerBytes = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");
                requestStream.Write(footerBytes, 0, footerBytes.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string responseText = reader.ReadToEnd();
                response.Close();
                return responseText;
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }    
    

    public static string SendAttachmentToApi(string filePath, string clientType, string jobNo)
    {
        try
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string targetUrl;
            string authToken = null;
            string uploadFolder = null;

            switch (clientType)
            {
                case "3149": // old client - needs token + uploadFolder
                    targetUrl = apiUrl;
                    authToken = token;
                    uploadFolder = "ERoyaluploads";
                    break;
                case "816": // HTID client - URL only, no token, needs jobNumber
                    targetUrl = Parvathy_Url;
                    break;
                default:
                    return "Unknown client type: " + clientType;
            }

            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targetUrl);
            request.Method = "POST";
            request.ContentType = "multipart/form-data; boundary=" + boundary;

            if (!string.IsNullOrEmpty(authToken))
            {
                request.Headers.Add("Authorization", "Bearer " + authToken);
            }

            using (Stream requestStream = request.GetRequestStream())
            {
                if (!string.IsNullOrEmpty(uploadFolder))
                {
                    string folderPart =
                        "--" + boundary + "\r\n" +
                        "Content-Disposition: form-data; name=\"uploadFolder\"\r\n\r\n" +
                        uploadFolder + "\r\n";
                    byte[] folderBytes = Encoding.UTF8.GetBytes(folderPart);
                    requestStream.Write(folderBytes, 0, folderBytes.Length);
                }

                // FIXED: field name must be "jobNumber", not "jobNo"
                if (!string.IsNullOrEmpty(jobNo))
                {
                    string jobNoPart =
                        "--" + boundary + "\r\n" +
                        "Content-Disposition: form-data; name=\"jobNumber\"\r\n\r\n" +
                        jobNo + "\r\n";
                    byte[] jobNoBytes = Encoding.UTF8.GetBytes(jobNoPart);
                    requestStream.Write(jobNoBytes, 0, jobNoBytes.Length);
                }

                byte[] fileBytes = File.ReadAllBytes(filePath);
                string fileName = Path.GetFileName(filePath);
                string fileHeader =
                    "--" + boundary + "\r\n" +
                    "Content-Disposition: form-data; name=\"file\"; filename=\"" + fileName + "\"\r\n" +
                    "Content-Type: application/octet-stream\r\n\r\n";
                byte[] headerBytes = Encoding.UTF8.GetBytes(fileHeader);
                requestStream.Write(headerBytes, 0, headerBytes.Length);
                requestStream.Write(fileBytes, 0, fileBytes.Length);

                byte[] newline = Encoding.UTF8.GetBytes("\r\n");
                requestStream.Write(newline, 0, newline.Length);

                byte[] footerBytes = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");
                requestStream.Write(footerBytes, 0, footerBytes.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string responseText = reader.ReadToEnd();
                response.Close();
                return responseText;
            }
        }
        catch (WebException wex)
        {
            if (wex.Response != null)
            {
                using (var errorStream = new StreamReader(wex.Response.GetResponseStream()))
                {
                    return "WebException: " + wex.Message + " | Server response: " + errorStream.ReadToEnd();
                }
            }
            return "WebException: " + wex.Message;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
     * */
    private static void Log(string logPath, string msg)
    {
        try
        {
            File.AppendAllText(logPath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " | " + msg + Environment.NewLine);
        }
        catch { /* ignore logging errors */ }
    }

    public static string SendAttachmentToApi(string filePath, string clientType, string jobNo)
    {
        string logPath = @"D:\Logs\ButtonClick_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
        

        // Ensure log folder exists before writing
        string logDir = Path.GetDirectoryName(logPath);
        if (!Directory.Exists(logDir))
        {
            Directory.CreateDirectory(logDir);
        }

        Log(logPath, "=== START SendAttachmentToApi ===");
        Log(logPath, "filePath: " + filePath);
        Log(logPath, "clientType: " + clientType);
        Log(logPath, "jobNo: " + jobNo);

        try
        {
            Log(logPath, "Step 1: Checking file exists...");
            if (!File.Exists(filePath))
            {
                Log(logPath, "ERROR: File not found at path.");
                return "File not found: " + filePath;
            }
            Log(logPath, "Step 1 OK: File exists.");

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            Log(logPath, "Step 2: SecurityProtocol set to TLS 1.2");

            string targetUrl;
            string authToken = null;
            string uploadFolder = null;

            switch (clientType)
            {
                case "3149":
                    targetUrl = apiUrl;
                    authToken = token;
                    uploadFolder = "ERoyaluploads";
                    break;
                case "816":
                    targetUrl = Parvathy_Url;
                    break;
                default:
                    Log(logPath, "ERROR: Unknown client type: " + clientType);
                    return "Unknown client type: " + clientType;
            }
            Log(logPath, "Step 3: targetUrl = " + targetUrl);

            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targetUrl);
            request.Method = "POST";
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Timeout = 30000;
            request.ReadWriteTimeout = 30000;
            Log(logPath, "Step 4: Timeouts set (30s)");

            if (!string.IsNullOrEmpty(authToken))
            {
                request.Headers.Add("Authorization", "Bearer " + authToken);
                Log(logPath, "Step 5: Authorization header added");
            }
            else
            {
                Log(logPath, "Step 5: No auth token for this client");
            }

            Log(logPath, "Step 6: Opening request stream...");
            using (Stream requestStream = request.GetRequestStream())
            {
                Log(logPath, "Step 6 OK: Request stream opened");

                if (!string.IsNullOrEmpty(uploadFolder))
                {
                    string folderPart =
                        "--" + boundary + "\r\n" +
                        "Content-Disposition: form-data; name=\"uploadFolder\"\r\n\r\n" +
                        uploadFolder + "\r\n";
                    byte[] folderBytes = Encoding.UTF8.GetBytes(folderPart);
                    requestStream.Write(folderBytes, 0, folderBytes.Length);
                    Log(logPath, "Step 7: uploadFolder field written: " + uploadFolder);
                }

                if (!string.IsNullOrEmpty(jobNo))
                {
                    string jobNoPart =
                        "--" + boundary + "\r\n" +
                        "Content-Disposition: form-data; name=\"jobNumber\"\r\n\r\n" +
                        jobNo + "\r\n";
                    byte[] jobNoBytes = Encoding.UTF8.GetBytes(jobNoPart);
                    requestStream.Write(jobNoBytes, 0, jobNoBytes.Length);
                    Log(logPath, "Step 8: jobNumber field written: " + jobNo);
                }

                byte[] fileBytes = File.ReadAllBytes(filePath);
                Log(logPath, "Step 9: File read into memory. Size = " + fileBytes.Length + " bytes");

                string fileName = Path.GetFileName(filePath);
                string fileHeader =
                    "--" + boundary + "\r\n" +
                    "Content-Disposition: form-data; name=\"file\"; filename=\"" + fileName + "\"\r\n" +
                    "Content-Type: application/octet-stream\r\n\r\n";
                byte[] headerBytes = Encoding.UTF8.GetBytes(fileHeader);
                requestStream.Write(headerBytes, 0, headerBytes.Length);
                requestStream.Write(fileBytes, 0, fileBytes.Length);
                Log(logPath, "Step 10: File bytes written to stream");

                byte[] newline = Encoding.UTF8.GetBytes("\r\n");
                requestStream.Write(newline, 0, newline.Length);

                byte[] footerBytes = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");
                requestStream.Write(footerBytes, 0, footerBytes.Length);
                Log(logPath, "Step 11: Footer written. Request body complete.");
            }

            Log(logPath, "Step 12: Calling GetResponse() — waiting for server...");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Log(logPath, "Step 12 OK: Response received. Status = " + response.StatusCode);

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string responseText = reader.ReadToEnd();
                Log(logPath, "Step 13: Response body = " + responseText);
                response.Close();
                Log(logPath, "=== END SendAttachmentToApi (SUCCESS) ===");
                return responseText;
            }
        }
        catch (WebException wex)
        {
            Log(logPath, "WebException caught: " + wex.Message);
            Log(logPath, "WebException Status: " + wex.Status);
            if (wex.Response != null)
            {
                using (var errorStream = new StreamReader(wex.Response.GetResponseStream()))
                {
                    string errBody = errorStream.ReadToEnd();
                    Log(logPath, "Server error response: " + errBody);
                    Log(logPath, "=== END SendAttachmentToApi (WEB EXCEPTION) ===");
                    return "WebException: " + wex.Message + " | Server response: " + errBody;
                }
            }
            Log(logPath, "No response object available (likely network/DNS/timeout issue)");
            Log(logPath, "=== END SendAttachmentToApi (WEB EXCEPTION - NO RESPONSE) ===");
            return "WebException: " + wex.Message;
        }
        catch (Exception ex)
        {
            Log(logPath, "General Exception: " + ex.Message);
            Log(logPath, "StackTrace: " + ex.StackTrace);
            Log(logPath, "=== END SendAttachmentToApi (EXCEPTION) ===");
            return ex.Message;
        }
    }
}