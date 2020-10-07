using System.Collections.Generic;
using System.Net.Http;

namespace BGB.Core.Proxy
{
    interface IApiServiceInvoker
    {
        HttpResponseMessage GetAsyncService(string baseUri, string completeUri);

        T GetAsyncService<T>(string baseUri, string completeUri, string authorization = null);

        T GetAsyncService<T>(string baseUri, string completeUri, Dictionary<string, string> parameters, string authorization = null);

        HttpResponseMessage PostAsyncService(string baseUri, string completeUri, string body, string authorization = null);

        HttpResponseMessage PostAsyncService<T>(string baseUri, string completeUri, T body);

        HttpResponseMessage PostAsyncService<T>(string baseUri, string completeUri, T body, Dictionary<string, string> parameters, string authorization = null);
    }
}