using System;
using System.IO;
using System.Net;
using System.Text;
//using static APIClient._Default;


    public static class HttpHelper
    {
        public static ApiResult PostJson(string url, string jsonPayload, string jwtToken = null)
        {
            ServicePointManager.SecurityProtocol =
                (SecurityProtocolType)3072; // TLS 1.2

            var result = new ApiResult();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Timeout = 300000;

            if (!string.IsNullOrWhiteSpace(jwtToken))
            {
                // Custom auth header (as required by this API)
                request.Headers["token"] = jwtToken.Trim();
            }

            try
            {
                byte[] payloadBytes = Encoding.UTF8.GetBytes(jsonPayload);
                request.ContentLength = payloadBytes.Length;

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(payloadBytes, 0, payloadBytes.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    result.IsSuccess = true;
                    result.HttpStatusCode = (int)response.StatusCode;
                    result.ResponseBody = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                result.IsSuccess = false;

                if (ex.Response != null)
                {
                    using (HttpWebResponse errorResponse = (HttpWebResponse)ex.Response)
                    using (StreamReader reader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        result.HttpStatusCode = (int)errorResponse.StatusCode;
                        result.ResponseBody = reader.ReadToEnd();
                        result.ErrorMessage = errorResponse.StatusDescription;
                    }
                }
                else
                {
                    result.HttpStatusCode = 0;
                    result.ErrorMessage = ex.Message;
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.HttpStatusCode = 0;
                result.ErrorMessage = ex.Message;
            }

            return result;
        } 



         public class ApiResult
        {
            public bool IsSuccess { get; set; }
            public int HttpStatusCode { get; set; }
            public string ResponseBody { get; set; }
            public string ErrorMessage { get; set; }
        }

        public class LoginResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public string token { get; set; }
            public LoginUser data { get; set; }
        }
        public class LoginUser
        {
            public int id { get; set; }
            public string user_name { get; set; }
            public string email { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
        }


    }
