using System;
using System.IO;
using System.Net;
using System.Text;

public class IceGateApiClient
{
    public static string SubmitIcegateRequest(
        string url,
        string clientCode,
        string apikey,
        //string icegateId,
       // string password,
        string filePath)
    {
        HttpWebRequest request = null;

        try
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("URL is required");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");

            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.KeepAlive = true;
            request.Timeout = 60000; // 5 minutes

            Stream requestStream = request.GetRequestStream();

            // ==========================
            // Helper method calls
            // ==========================
            WriteFormField(requestStream, boundary, "clientCode", clientCode);
            WriteFormField(requestStream, boundary, "key", apikey);
          //  WriteFormField(requestStream, boundary, "Password", password);

            // ==========================
            // File
            // ==========================
            WriteFile(requestStream, boundary, filePath);

            // End boundary
            string endBoundary = "--" + boundary + "--\r\n";
            byte[] endBytes = Encoding.UTF8.GetBytes(endBoundary);
            requestStream.Write(endBytes, 0, endBytes.Length);

            requestStream.Close();

            // ==========================
            // Response
            // ==========================
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();

            reader.Close();
            response.Close();

            return result;
        }
        catch (WebException webEx)
        {
            if (webEx.Response != null)
            {
                StreamReader reader = new StreamReader(webEx.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                reader.Close();

                return "HTTP ERROR: " + error;
            }

            return "NETWORK ERROR: " + webEx.Message;
        }
        catch (FileNotFoundException ex)
        {
            return "FILE ERROR: " + ex.Message;
        }
        catch (UnauthorizedAccessException ex)
        {
            return "ACCESS ERROR: " + ex.Message;
        }
        catch (ArgumentException ex)
        {
            return "VALIDATION ERROR: " + ex.Message;
        }
        catch (Exception ex)
        {
            return "GENERAL ERROR: " + ex.Message;
        }
    }

    // ==========================
    // Write Form Field
    // ==========================
    private static void WriteFormField(Stream stream, string boundary, string name, string value)
    {
        string formData = "--" + boundary + "\r\n";
        formData += "Content-Disposition: form-data; name=\"" + name + "\"\r\n\r\n";
        formData += value + "\r\n";

        byte[] bytes = Encoding.UTF8.GetBytes(formData);
        stream.Write(bytes, 0, bytes.Length);
    }

    // ==========================
    // Write File
    // ==========================
    private static void WriteFile(Stream stream, string boundary, string filePath)
    {
        string header = "--" + boundary + "\r\n";
        header += "Content-Disposition: form-data; name=\"File\"; filename=\"" + Path.GetFileName(filePath) + "\"\r\n";
        header += "Content-Type: application/json\r\n\r\n";

        byte[] headerBytes = Encoding.UTF8.GetBytes(header);
        stream.Write(headerBytes, 0, headerBytes.Length);

        FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        byte[] buffer = new byte[4096];
        int bytesRead;

        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
        {
            stream.Write(buffer, 0, bytesRead);
        }

        fileStream.Close();

        byte[] newline = Encoding.UTF8.GetBytes("\r\n");
        stream.Write(newline, 0, newline.Length);
    }

}
