using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web;

namespace Suitsupply.Framework.Web.Utilities
{
    public class HttpApiClient : IApiClient
    {
        public HttpApiClient()
        {
            TimeOut = 600;
            BaseUrl = string.Empty;
        }
        public HttpApiClient(string baseUrl)
        {
            TimeOut = 600;
            BaseUrl = baseUrl;
        }
        public int TimeOut { get; set; }
        public string BaseUrl { get; set; }

        public void Post(string url, object input)
        {
            var errorData = string.Empty;
            var httpClient = CreateHttpClient();

            var requestJson = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(url, requestJson, CancellationToken.None).Result;

            if (!response.IsSuccessStatusCode)
            {
                try
                {
                     errorData = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
                }
                catch (Exception)
                {

                     errorData = response.Content.ReadAsStringAsync().Result;
                }
        
                throw new ApplicationException(GetExceptionMessage(errorData));
            }

        }

        public TOutput Post<TOutput>(string url, object input)
        {
            var httpClient = CreateHttpClient();

            var requestJson = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(url, requestJson, CancellationToken.None).Result;

            if (!response.IsSuccessStatusCode)
            {
                var x = response.Content.ReadAsStringAsync().Result;
                var errorData = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);

                throw new ApplicationException(GetExceptionMessage(errorData));
            }

            var resultJson = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<TOutput>(resultJson);

            return result;
        }

        public TOutput Get<TOutput>(string url, object input)
        {
            var httpClient = CreateHttpClient();

            var queryString = GetQueryString(input);
            if (!String.IsNullOrEmpty(queryString))
            {
                url = $"{url}?{queryString}";
            }
            var response = httpClient.GetAsync(url, CancellationToken.None).Result;

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                var errorData = HttpStatusCode.NotFound.ToString();
                throw new ApplicationException(errorData);
            }

            if (!response.IsSuccessStatusCode)
            {
                var errorData = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
                throw new ApplicationException(GetExceptionMessage(errorData));
            }

            var resultJson = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<TOutput>(resultJson);

            return result;
        }

        public string Get(string url, object input)
        {
            var httpClient = CreateHttpClient();

            var queryString = GetQueryString(input);
            if (!String.IsNullOrEmpty(queryString))
            {
                url = $"{url}?{queryString}";
            }
            var response = httpClient.GetAsync(url, CancellationToken.None).Result;

            if (!response.IsSuccessStatusCode)
            {
                var errorData = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
                throw new ApplicationException(GetExceptionMessage(errorData));
            }

            return response.Content.ReadAsStringAsync().Result;
        }

        public TOutput Get<TOutput>(string url)
        {
            var httpClient = CreateHttpClient();

            var response = httpClient.GetAsync(url, CancellationToken.None).Result;

            if (!response.IsSuccessStatusCode)
            {
                var errorData = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
                throw new ApplicationException(GetExceptionMessage(errorData));
            }

            var resultJson = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<TOutput>(resultJson);

            return result;
        }

        public void Put(string url, object input)
        {
            var httpClient = CreateHttpClient();

            var requestJson = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync(url, requestJson, CancellationToken.None).Result;

            if (!response.IsSuccessStatusCode)
            {
                var errorData = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
                throw new ApplicationException(GetExceptionMessage(errorData));
            }

        }

        public TOutput Put<TOutput>(string url, object input)
        {
            var httpClient = CreateHttpClient();

            var requestJson = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync(url, requestJson, CancellationToken.None).Result;

            if (!response.IsSuccessStatusCode)
            {
                var errorData = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
                throw new ApplicationException(GetExceptionMessage(errorData));
            }

            var resultJson = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<TOutput>(resultJson);

            return result;
        }

        private string GetQueryString<TInput>(TInput obj)
        {
            var result = new List<string>();
            var props = obj.GetType().GetProperties().Where(p => p.GetValue(obj, null) != null);
            foreach (var p in props)
            {
                var value = p.GetValue(obj, null);
                if (p.PropertyType.IsGenericType && (p.PropertyType.Name.Equals(typeof(IEnumerable<>).Name) || p.PropertyType.Name.Equals(typeof(List<>).Name)))
                {
                    var enumerable = (IEnumerable)value;
                    result.AddRange(from object v in enumerable select string.Format("{0}={1}", p.Name, HttpUtility.UrlEncode(v.ToString())));
                }
                else
                {
                    result.Add(string.Format("{0}={1}", p.Name, HttpUtility.UrlEncode(value.ToString())));
                }
            }

            return string.Join("&", result.ToArray());
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(TimeOut)
            };
            return httpClient;
        }

        private string GetExceptionMessage(dynamic error)
        {
            if (error != null)
            {
                JToken value;
                if (((JObject)error).TryGetValue("ExceptionMessage", out value))
                {
                    return value.ToString();
                }
                else if (((JObject)error).TryGetValue("ErrorMessage", out value))
                {
                    return value.ToString();
                }
            }

            return "خطا در عملیات";
        }
    }
}
