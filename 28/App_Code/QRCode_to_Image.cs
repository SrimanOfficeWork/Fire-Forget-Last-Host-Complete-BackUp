using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;



//namespace QrClientExample
//{
    public class QRCode_to_Image_Variables  //QrRequest
    {
        public string InvoiceNo { get; set; }
        public string Data { get; set; }
    }

    public class QRCode_to_Image_Request
    {
        public string QRCode_to_Image(string SignedQRCode, string Invno,string Phy_Loc)
        {
            string apiUrl = "http://mailboxservices.royaltechsystems.co.in/api/Qr/Qrcodeimage";
                             
            string filePath = "";
            var qrRequest = new QRCode_to_Image_Variables
            {
                InvoiceNo = Invno,
                Data = SignedQRCode // your JWT
            };

            try
            {
                // Serialize request to JSON
                var serializer = new JavaScriptSerializer();
                string jsonRequest = serializer.Serialize(qrRequest);

                // Create HttpWebRequest
                var request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "POST";
                request.ContentType = "application/json";

                // Write JSON to request body
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(jsonRequest);
                }

                // Get the response
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Invno.Replace('/', '_') + ".png");
                                //Server.MapPath("~/Submission/" + Connection.COMPANYID() + "/GST_BILL_QRCODE/" + "/Auto" + "/");
                                //filePath = Server.MapPath("~/Submission/" + Connection.COMPANYID() + "/GST_BILL_QRCODE/" + "/Auto" + "/", "QR_{qrRequest.InvoiceNo}.png");
                                //filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + Server.MapPath(Invno), "QR_{qrRequest.InvoiceNo}.png");
                        filePath = Path.Combine(Phy_Loc, Invno.Replace('/', '_') + ".png");


                        using (var stream = response.GetResponseStream())
                        using (var fileStream = File.Create(filePath))
                        {
                            stream.CopyTo(fileStream);
                        }

                        Console.WriteLine("QR code saved to: " + filePath);
                    }
                    else
                    {
                        Console.WriteLine("API returned: " + response.StatusCode);
                    }
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error calling API: " + ex.Message);
            }
            return filePath;
        }
    }
//}