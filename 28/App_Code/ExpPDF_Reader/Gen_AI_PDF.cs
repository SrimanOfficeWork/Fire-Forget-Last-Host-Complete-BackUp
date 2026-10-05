using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Net.Http.Headers;
//using System.Net.Http;

using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class Gen_AI_PDF
{

    
    public string Get_AccessToken_Invoice_Upload(string FilePath, string JobNo)
    {
        string response = "", exp_name = "", AI_branch_slno = "", PDF_CLIENT_NAME = "";
        string PdfClientName_Exp = "";
        DateTime invoiceStartTime = DateTime.Now;

        try
        {
            exp_name = HttpContext.Current.Session["exp_name"] as string;
            AI_branch_slno = HttpContext.Current.Session["AI_branch_slno"] as string;
            PDF_CLIENT_NAME = HttpContext.Current.Session["EXP_PdfClientName"] as string;
            if (!string.IsNullOrWhiteSpace(exp_name) && string.IsNullOrWhiteSpace(PDF_CLIENT_NAME))
            {
                if (exp_name == "TOP SYRINGE MFG CO PVT LTD" || exp_name == "TRIO TREND EXPORTS PVT. LTD."
                    || ((AI_branch_slno == "35" || AI_branch_slno == "24") && exp_name == "JOHN DEERE INDIA PRIVATE LIMITED") || exp_name == "JCB INDIA LIMITED NEW" || exp_name == "EATON INDUSTRIAL PRODUCTS PRIVATE LIMITED NEW")
                {
                    PdfClientName_Exp = exp_name.Split(' ')[0] + " " + exp_name.Split(' ')[1];
                }
                else if (exp_name == "SIEMENS HEALTHCARE PVT LTD" || exp_name == "SIEMENS HEALTHCARE PRIVATE LIMITED" || exp_name == "SIEMENS LIMITED" || exp_name == "ELEGANT COLLECTION" || (AI_branch_slno == "8" && exp_name == "JOHN DEERE INDIA PRIVATE LIMITED") || exp_name == "ELEGANT COLLECTION")
                {
                    PdfClientName_Exp = exp_name;
                }
                else if (exp_name.Contains("ZENSTAR JEWELLERY LLP"))
                {
                    PdfClientName_Exp = "JEWELEX";
                }
                else if (exp_name == "SCHNEIDER ELECTRIC INDIA PRIVATE LIMITED")
                {
                    PdfClientName_Exp = "LARSEN";
                }
                else if (exp_name == "INDIA YAMAHA MOTOR PRIVATE LIMITED")
                {
                    PdfClientName_Exp = "YAMAHA";
                }
                else
                {
                    PdfClientName_Exp = exp_name.Split(' ')[0];
                }
            }
            else
            {
                PdfClientName_Exp = PDF_CLIENT_NAME;
            }

            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

            HttpWebRequest request = null;
            if (PdfClientName_Exp == "SCM" || (AI_branch_slno == "1" && PdfClientName_Exp == "MAF") || PdfClientName_Exp == "AMALA" || PdfClientName_Exp == "PRABHU")
            {
                request = (HttpWebRequest)WebRequest.Create("http://www.ocrapiservice.royaltechsystems.co.in/api/invoice/royaltechocr");
                request.Headers.Add("ApiKey", "Royal");
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create("https://asia-south1-serene-essence-419307.cloudfunctions.net/royal-invoice");
                request.Headers.Add("ApiKey", "12345");
            }

            request.Method = "POST";
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.KeepAlive = true;
            request.AllowWriteStreamBuffering = false;
            request.SendChunked = true;
            request.Timeout = 10 * 60 * 1000;
            request.ReadWriteTimeout = 10 * 60 * 1000;

            Stream requestStream = request.GetRequestStream();

            NameValueCollection formFields = new NameValueCollection
        {
            { "CompanyID", Connection.Company_License() },
            { "UserID", Connection.Current_User() },
            { "BranchCode", Connection.Current_Branch() },
            { "JobNo", JobNo },
            { "JobType", "EXP" },
            { "WorkingPeriod", Connection.WorkingPeriod() },
            { "PageCount", "0" },
            { "PdfCount", "0" },
            { "JobStatus", "N" },
            { "FileName", "1" },
            { "InvoiceStartTime", invoiceStartTime.ToString() },
            { "PdfClientName", PdfClientName_Exp }
        };

            // Write form fields
            foreach (string key in formFields)
            {
                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                string fieldData = "Content-Disposition: form-data; name=\"" + key + "\"\r\n\r\n" + formFields[key];
                byte[] fieldBytes = Encoding.UTF8.GetBytes(fieldData);
                requestStream.Write(fieldBytes, 0, fieldBytes.Length);
            }

            // Write file content
            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            string header = "Content-Disposition: form-data; name=\"File\"; filename=\"" + Path.GetFileName(FilePath) + "\"\r\n" +
                            "Content-Type: application/pdf\r\n\r\n";
            byte[] headerBytes = Encoding.UTF8.GetBytes(header);
            requestStream.Write(headerBytes, 0, headerBytes.Length);

            using (FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                }
            }

            requestStream.Write(trailer, 0, trailer.Length);
            requestStream.Close();

            using (WebResponse webResponse = request.GetResponse())
            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
            {
                response = reader.ReadToEnd();
                Console.WriteLine("Response: " + response);
            }
        }
        catch (WebException webEx)
        {
            if (webEx.Response != null)
            {
                using (var errorResponse = (HttpWebResponse)webEx.Response)
                using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                {
                    string errorContent = reader.ReadToEnd();
                    Console.WriteLine("Error Response: " + errorContent);
                }
            }
            Console.WriteLine("WebException: " + webEx.Message);
        }
        catch (System.Threading.ThreadAbortException ex)
        {
            Console.WriteLine("Thread Abort Exception: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }

        return response;
    }

    // Docker Vision request for the queue path (DockerVision_Queue.FireAndForget). Same endpoint, ApiKey,
    // PdfClientName and form fields as Get_AccessToken_Invoice_Upload above — only the packaging differs.
    public DockerVision_Queue.DockerVisionRequest Build_DockerVision_Request(string FilePath, string JobNo)
    {
        string exp_name = HttpContext.Current.Session["exp_name"] as string;
        string AI_branch_slno = HttpContext.Current.Session["AI_branch_slno"] as string;
        string PDF_CLIENT_NAME = HttpContext.Current.Session["EXP_PdfClientName"] as string;
        string PdfClientName_Exp;

        if (!string.IsNullOrWhiteSpace(exp_name) && string.IsNullOrWhiteSpace(PDF_CLIENT_NAME))
        {
            if (exp_name == "TOP SYRINGE MFG CO PVT LTD" || exp_name == "TRIO TREND EXPORTS PVT. LTD."
                || ((AI_branch_slno == "35" || AI_branch_slno == "24") && exp_name == "JOHN DEERE INDIA PRIVATE LIMITED") || exp_name == "JCB INDIA LIMITED NEW" || exp_name == "EATON INDUSTRIAL PRODUCTS PRIVATE LIMITED NEW")
                PdfClientName_Exp = exp_name.Split(' ')[0] + " " + exp_name.Split(' ')[1];
            else if (exp_name == "SIEMENS HEALTHCARE PVT LTD" || exp_name == "SIEMENS HEALTHCARE PRIVATE LIMITED" || exp_name == "SIEMENS LIMITED" || exp_name == "ELEGANT COLLECTION" || (AI_branch_slno == "8" && exp_name == "JOHN DEERE INDIA PRIVATE LIMITED"))
                PdfClientName_Exp = exp_name;
            else if (exp_name.Contains("ZENSTAR JEWELLERY LLP"))
                PdfClientName_Exp = "JEWELEX";
            else if (exp_name == "SCHNEIDER ELECTRIC INDIA PRIVATE LIMITED")
                PdfClientName_Exp = "LARSEN";
            else if (exp_name == "INDIA YAMAHA MOTOR PRIVATE LIMITED")
                PdfClientName_Exp = "YAMAHA";
            else
                PdfClientName_Exp = exp_name.Split(' ')[0];
        }
        else
        {
            PdfClientName_Exp = PDF_CLIENT_NAME;
        }

        DockerVision_Queue.DockerVisionRequest req = new DockerVision_Queue.DockerVisionRequest();
        req.FilePath = FilePath;
        if (PdfClientName_Exp == "SCM" || (AI_branch_slno == "1" && PdfClientName_Exp == "MAF") || PdfClientName_Exp == "AMALA" || PdfClientName_Exp == "PRABHU")
        {
            req.ApiUrl = "http://www.ocrapiservice.royaltechsystems.co.in/api/invoice/royaltechocr";
            req.ApiKey = "Royal";
        }
        else
        {
            req.ApiUrl = "https://asia-south1-serene-essence-419307.cloudfunctions.net/royal-invoice";
            req.ApiKey = "12345";
        }

        req.FormFields = new System.Collections.Specialized.NameValueCollection
        {
            { "CompanyID", Connection.Company_License() },
            { "UserID", Connection.Current_User() },
            { "BranchCode", Connection.Current_Branch() },
            { "JobNo", JobNo },
            { "JobType", "EXP" },
            { "WorkingPeriod", Connection.WorkingPeriod() },
            { "PageCount", "0" },
            { "PdfCount", "0" },
            { "JobStatus", "N" },
            { "FileName", "1" },
            { "InvoiceStartTime", DateTime.Now.ToString() },
            { "PdfClientName", PdfClientName_Exp }
        };
        return req;
    }

    public DataSet Get_AccessToken_Invoice(DataSet GetLocalAPIData, string LocalFile)
    {
        // JSON string containing your data
        string StoreData = File.ReadAllText(LocalFile);

        // Parse the JSON string into a JObject
        JObject jsonData = JObject.Parse(StoreData);

        // Initialize the DataSet
        DataSet ds = new DataSet();

        // Convert the Header section into a DataTable and add it to the DataSet
        DataTable headerTable = JsonConvert.DeserializeObject<DataTable>(jsonData["Header"].ToString());
        headerTable.TableName = "Header";
        ds.Tables.Add(headerTable);

        // Convert the ItemsDetails section into a DataTable and add it to the DataSet
        DataTable itemsTable = JsonConvert.DeserializeObject<DataTable>(jsonData["ItemsDetails"].ToString());
        itemsTable.TableName = "ItemsDetails";
        ds.Tables.Add(itemsTable);

        // Convert the ContainerDetails section into a DataTable and add it to the DataSet
        DataTable ContainerTable = JsonConvert.DeserializeObject<DataTable>(jsonData["ShipmentContainerDetails"].ToString());
        ContainerTable.TableName = "ShipmentContainerDetails";
        ds.Tables.Add(ContainerTable);

        return ds;
    }

}
