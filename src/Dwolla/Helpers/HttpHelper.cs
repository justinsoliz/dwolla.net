using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace Dwolla.Helpers
{
    public class HttpHelper
    {
        public enum Method { GET, POST, PUT, DELETE };


        public static string UrlEncode(string s)
        {
            return Uri.EscapeDataString(s);
        }

        /// <summary>
        /// Web Request Wrapper
        /// </summary>
        /// <param name="method">Http Method</param>
        /// <param name="url">Full url to the web resource</param>
        /// <param name="postData">Data to post in querystring format</param>
        /// <param name="headers">Additional Header Data</param>
        /// <returns>The web server response.</returns>
        public static string WebRequest(Method method, string url, string postData, List<KeyValuePair<string, string>> headers)
        {
            HttpWebRequest webRequest = null;
            StreamWriter requestWriter = null;
            string responseData = "";

            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    webRequest.Headers.Add(header.Key, header.Value);
                }
            }
            webRequest.Method = method.ToString();
            webRequest.ServicePoint.Expect100Continue = false;
            //webRequest.UserAgent  = "Identify your application please.";
            //webRequest.Timeout = 20000;

            if (method == Method.POST || method == Method.DELETE)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(postData);

                webRequest.ContentType = "application/x-www-form-urlencoded";
                //webRequest.ContentType = "application/json";
                webRequest.ContentLength = bytes.Length;

                //POST the data.
                using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestWriter.Write(postData);
                    requestWriter.Close();
                }
            }

            responseData = WebResponseGet(webRequest);

            webRequest = null;

            return responseData;

        }

        /// <summary>
        /// Process the web response.
        /// </summary>
        /// <param name="webRequest">The request object.</param>
        /// <returns>The response data.</returns>
        public static string WebResponseGet(WebRequest webRequest)
        {
            StreamReader responseReader = null;
            string responseData = "";

            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    responseReader = new StreamReader(ex.Response.GetResponseStream());
                    //Read the response.
                    string innerResponseData = responseReader.ReadToEnd();
                    if (innerResponseData.Trim().Length > 0)
                    {
                        responseData = innerResponseData;
                    }
                }

                if (responseReader != null)
                {
                    responseReader.Close();
                }
                if (webRequest != null)
                {
                    try
                    {
                        webRequest.GetResponse().Close();
                    }
                    catch { }
                }

                Console.WriteLine(ex);
                throw new Exception(responseData);
            }
            catch (Exception ex)
            {
                //TODO: Improve error handling
                responseData = ex.Message;

                if (responseReader != null)
                {
                    responseReader.Close();
                }
                if (webRequest != null)
                {
                    try
                    {
                        webRequest.GetResponse().Close();
                    }
                    catch { }
                }
            }

            //Release variables.
            responseReader = null;
            webRequest = null;

            return responseData;
        }

        /// <summary>
        /// Converts the dictionary to a json formatted query string.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>A json formatted querystring.</returns>
        public static string ToJsonQueryString(IDictionary<string, object> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            var sb = new StringBuilder();

            var isFirst = true;

            foreach (var key in dictionary.Keys)
            {
                if (isFirst) isFirst = false;

                else sb.Append("&");

                var stringVal = dictionary[key];

                //if (dictionary[key] != null)
                if (stringVal != null && !string.IsNullOrWhiteSpace(stringVal.ToString()))
                {
                    // Format Object As json And Remove leading and trailing parenthesis
                    string jsonValue = ToJsonString(dictionary[key]);

                    //if (!string.IsNullOrEmpty(jsonValue))
                    //{

                    var encodedValue = HttpHelper.UrlEncode(jsonValue);
                    sb.AppendFormat(CultureInfo.InvariantCulture, "{0}={1}", key, encodedValue);

                    //}
                }
                else sb.Append(key + "=");
            }
            return sb.ToString();
        }

        public static string ToJsonString(object value)
        {
            // Format Object As json And Remove leading and trailing parenthesis
            var jsonValue = JsonSerializer.Current.SerializeObject(value);
            jsonValue = SimpleJson.SimpleJson.EscapeToJavascriptString(jsonValue);

            if (jsonValue.StartsWith("\"", StringComparison.Ordinal))
                jsonValue = jsonValue.Substring(1, jsonValue.Length - 1);

            if (jsonValue.EndsWith("\"", StringComparison.Ordinal))
                jsonValue = jsonValue.Substring(0, jsonValue.Length - 1);

            return jsonValue;
        }

        public static string BuildUrl(string baseUrl, IDictionary<string, object> parameters)
        {
            return string.Format("{0}?{1}", baseUrl, ToJsonQueryString(parameters));
        }
    }
}