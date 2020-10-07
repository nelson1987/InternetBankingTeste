using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BGB.Core.Proxy
{
    public class ApiServiceInvoker : IApiServiceInvoker
    {
        public HttpResponseMessage GetAsyncService(string baseUri, string completeUri)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://" + baseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage result;

            using (client)
            {
                var response = client.GetAsync(string.Format(completeUri));
                result = response.Result;
            }

            return result;
        }

        public T GetAsyncService<T>(string baseUri, string completeUri, string authorization = null)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://" + baseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(authorization))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

            HttpResponseMessage result;
            T model;

            using (client)
            {
                var response = client.GetAsync(string.Format(completeUri));
                result = response.Result;
            }
            if (result.IsSuccessStatusCode)
            {
                string strJson = result.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<T>(strJson);
                return model;
            }

            throw new Exception("Erro na chamada do serviço.");
        }

        public T GetAsyncService<T>(string baseUri, string completeUri, Dictionary<string, string> parameters, string authorization = null)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://" + baseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(authorization))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

            foreach (var item in parameters)
                client.DefaultRequestHeaders.Add(item.Key, item.Value);

            HttpResponseMessage result;
            T model;

            using (client)
            {
                var response = client.GetAsync(string.Format(completeUri));
                result = response.Result;
            }

            if (result.IsSuccessStatusCode)
            {
                string strJson = result.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<T>(strJson);
                return model;
            }

            throw new Exception("Erro na chamado do serviço.");
        }

        public HttpResponseMessage PostAsyncService(string baseUri, string completeUri, string body, string authorization = null)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://" + baseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(authorization))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

            var content = new StringContent(body, System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync(string.Format(completeUri), content).Result;

            return response;
        }

        public HttpResponseMessage PostAsyncService<T>(string baseUri, string completeUri, T body)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://" + baseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync(string.Format(completeUri), content).Result;

            return response;
        }

        public HttpResponseMessage PostAsyncService<T>(string baseUri, string completeUri, T body, Dictionary<string, string> parameters, string authorization = null)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://" + baseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(authorization))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

            foreach (var item in parameters)
                client.DefaultRequestHeaders.Add(item.Key, item.Value);

            var content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync(string.Format(completeUri), content).Result;

            return response;
        }
    }
}