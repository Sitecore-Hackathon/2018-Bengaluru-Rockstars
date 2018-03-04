namespace XConnectRocks.Services
{
    using System;
    using System.IO;
    using System.Net;
    using Newtonsoft.Json;
    using XConnectRocks.Models;

    public class HttpServiceHelper 
    {

        /// <summary>
        /// Web API Get method
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="traceOn">Pass traceOn as true to debug the service. Maintain this key in a configuration</param>
        /// <returns></returns>
        public HttpMethodResult HttpGet(string uri, bool traceOn = false, string jsonInput ="")
        {

            try
            {
                string resultPayLoad = "";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(uri, UriKind.Absolute));

                httpWebRequest.Method = "GET";
                if(!string.IsNullOrEmpty(jsonInput))
                {
                    httpWebRequest.Headers.Add("UserData", jsonInput);
                }

                httpWebRequest.Credentials = CredentialCache.DefaultCredentials;

                using (var response = httpWebRequest.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        if (stream != null)
                        {
                            var iStreamReader = new StreamReader(stream);
                            resultPayLoad = iStreamReader.ReadToEnd();
                        }
                    }
                }

                return new HttpMethodResult
                {
                    ResultException = null,
                    ResultPayLoad = resultPayLoad,
                    ResultStatus = HttpMethodResult.HttpMethodResultStatus.OK,
                };

            }
            catch (Exception exception)
            {
                return new HttpMethodResult
                {
                    ResultException = exception,
                    ResultPayLoad = "",
                    ResultStatus = HttpMethodResult.HttpMethodResultStatus.Failed,

                };
            }
        }
        /// <summary>
        /// Helper method for serializing get data and calling http get
        /// </summary>
        /// <typeparam name="TResult">Object returned by web service</typeparam>
        /// <param name="url">webservice url</param>
        /// <returns>TResult</returns>
        public TResult GetServiceResponse<TResult>(string url, bool traceOn)
        {
            var httpResult = this.HttpGet(url, traceOn);
            if (httpResult.ResultStatus == HttpMethodResult.HttpMethodResultStatus.OK)
            {
                return JsonConvert.DeserializeObject<TResult>(httpResult.ResultPayLoad);
            }
            else
            {
                throw httpResult.ResultException;
            }
        }

    }
}
