using System;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;
using SbrfClient.Response;

namespace SbrfClient.Http
{
    public class NetworkClient
    {
        private Logger _logger;

        public NetworkClient(Logger logger)
        {
            _logger = logger;
        }

        public HttpStatusCode GetStatusCode(string url, string method = "GET", string token = "")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Headers.Add("token", token);
            request.ContentLength = 0;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                _logger.Debug($"GET: {url}, RESPONSE: {response}");
                return response.StatusCode;
            }
            catch (WebException e)
            {
                HttpWebResponse httpResponse = (HttpWebResponse)e.Response;
                var statusCode = httpResponse.StatusCode;
                _logger.Error($"GET: {url}, RESPONSE: {httpResponse}");
                return statusCode;
            }
        }

        public T GetObject<T>(string url, string method = "GET", string token = "")
        {
            Console.WriteLine(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Headers.Add("token", token);
            request.ContentLength = 0;
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var objText = reader.ReadToEnd();
                        _logger.Debug($"URL: {url}, RESPONSE: {objText}");
                        return JsonConvert.DeserializeObject<T>(objText);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.Error($"URL: {url}, ERROR:{e.Message}");
                throw;
            }

            

        }

        /// <summary>
        /// Отправляет JSON-объект на определённый урл
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого объекта, который мы ожидаем</typeparam>
        /// <returns>Ответ сервера, преобразованный в тип T</returns>
        public T PostObjectViaJson<T>(string url, object objectForSend, string method = "POST")
        {
            Console.WriteLine(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.ContentType = "application/json";

            var json = JsonConvert.SerializeObject(objectForSend);
            Console.WriteLine(json);
            request.ContentLength = json.Length;
            request.ServerCertificateValidationCallback = delegate { return true; };

            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            request.ContentLength = byteArray.Length;
            Stream newStream = request.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Close();
            try
            {
                HttpWebResponse getResponse = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
                {
                    string result = sr.ReadToEnd();
                    _logger.Debug($"POST: {url}, BODY: {json}, RESPONSE: {result}");
                    return (T)JsonConvert.DeserializeObject<T>(result);
                }
            }
            catch (Exception e)
            {
                _logger.Error($"POST: {url}, BODY: {json}, ERROR: {e.Message}");
                throw;
            }
            
        }

        /// <summary>
        /// Отправляет JSON-объект на определённый урл
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого объекта, который мы ожидаем</typeparam>
        /// <returns>Ответ сервера, преобразованный в тип T</returns>
        public T PostObjectViaUrlParams<T>(string url, object objectForSend, string method = "POST")
        {
            
            var urlParams = ObjectToQueryString(objectForSend);
            url += "?" + urlParams;
            Console.WriteLine(url);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls 
                                                   | SecurityProtocolType.Tls11
                                                   | SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.ContentType = "application/json";
            request.Proxy = null;
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.ServicePoint.ConnectionLimit = 1;
            request.Headers.Add("UserAgent", "Pentia; MSI");
            // request.ServerCertificateValidationCallback = delegate { return true; };
            

            try
            {
                HttpWebResponse getResponse = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
                {
                    string json = sr.ReadToEnd();
                    var result = (T)JsonConvert.DeserializeObject<T>(json);
                    _logger.Debug($"POST: {url}, RESPONSE: {json}");
                    return result;
                }

            }
            catch (Exception e)
            {
                _logger.Error($"POST: {url}, ERROR:{e.Message}");
                Console.WriteLine(e);
                throw;
            }
            
        }

        public static string ObjectToQueryString(object obj)
        {
            string result = "";
            var properties = GetProperties(obj);

            foreach (var p in properties)
            {
                var value = p.GetValue(obj, null);
                var name = p.Name;
                result += $"{name}={value}&" ;
            }
            return result;
        }

        

        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }
}
}
