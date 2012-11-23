using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Dwolla.Helpers
{
    internal static class Requestor
    {
        public static string GetString(string url)
        {
            var wr = GetWebRequest(url, "GET");

            return ExecuteWebRequest(wr);
        }

        public static string PostString(string url, object data)
        {
            HttpWebRequest request = GetWebRequest(url, "POST");

            string requestBody = JsonConvert.SerializeObject(data);

            Console.WriteLine("Request body: {0}", requestBody);

            byte[] bytes = Encoding.UTF8.GetBytes(requestBody);

            request.ContentLength = bytes.Length;

            using (Stream stream = request.GetRequestStream())
                stream.Write(bytes, 0, bytes.Length);

            return ExecuteWebRequest(request);
        }

        public static string Delete(string url)
        {
            var wr = GetWebRequest(url, "DELETE");

            return ExecuteWebRequest(wr);
        }

        private static HttpWebRequest GetWebRequest(string url, string method)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = method;
            request.ContentType = "application/json";
            request.UserAgent = "Dwolla.net (https://github.com/justinsoliz/dwolla.net)";

            //request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = 0;

            return request;
        }

        //private static string GetAuthorizationHeaderValue(string apiKey)
        //{
        //    var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:", apiKey)));
        //    return string.Format("Basic {0}", token);
        //}

        private static string ExecuteWebRequest(WebRequest webRequest)
        {
            try
            {
                using (var response = webRequest.GetResponse())
                {
                    return ReadStream(response.GetResponseStream());
                }
            }
            catch (WebException webException)
            {
                if (webException.Response != null)
                {
                    var statusCode = ((HttpWebResponse)webException.Response).StatusCode;

                    // Todo: Setup Error Model for Dwolla
                    //var stripeError = Mapper<StripeError>.MapFromJson(ReadStream(webException.Response.GetResponseStream()), "error");

                    //throw new StripeException(statusCode, stripeError, stripeError.Message);
                }

                throw;
            }
        }

        private static string ReadStream(Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}