using Exceptionless.Submission.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace System.Net.Http
{
    internal static class HttpClientExtensions
    {
        public static void AddAuthorizationHeader(this HttpClient client, string apiKey)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ExceptionlessHeaders.Bearer, apiKey);
        }
    }
}
