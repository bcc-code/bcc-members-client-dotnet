using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BccMembers.Api.Client.Extensions
{
    internal static class HttpExtensions
    {
        /// <summary>Calls endpoint using 'http get' and converts response to generic type.</summary>
        public static async Task<T> GetAsync<T>(this HttpClient httpClient, string endpoint)
        {
            using HttpResponseMessage response =
                await httpClient.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
            using (Stream stream = await response.Content.ReadAsStreamAsync())
            {
                await EnsureAuthorizedAndSuccessStatusCodeAsync(response, stream);

                T result = stream.ToDeserializedJson<T>();

                return result;
            }
        }

        /// <summary>Calls endpoint using 'http get' and converts to generic type. 
        /// Parameter <paramref name="jsonConverters"/> can be specified to do custom json conversion.
        /// </summary>
        public static async Task<T> GetAsync<T>(this HttpClient httpClient, string endpoint, params JsonConverter[] jsonConverters)
        {
            using (HttpResponseMessage response =
                await httpClient.GetAsync(endpoint))
            {
                string content = await response.Content.ReadAsStringAsync();
                EnsureAuthorizedAndSuccessStatusCode(response, content);

                T result = JsonConvert.DeserializeObject<T>(content, jsonConverters);

                return result;
            }
        }

        /// <summary>
        /// Calls endpoint using 'http post' with specified request body. 
        /// </summary>
        public static async Task PostAsync<TRequestBody>(this HttpClient httpClient, string endpoint, TRequestBody requestBody)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint))
            using (var httpContent = requestBody.ToHttpJsonContent())
            {
                request.Content = httpContent;

                using (var response =
                    await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                {
                    using (Stream stream = await response.Content.ReadAsStreamAsync())
                    {
                        await EnsureAuthorizedAndSuccessStatusCodeAsync(response, stream);
                    }
                }
            }
        }

        /// <summary>
        /// Calls endpoint using 'http post' with specified request body and converts response to generic type.
        /// </summary>
        public static async Task<TResult> PostAsync<TRequestBody, TResult>(this HttpClient httpClient, string endpoint, TRequestBody requestBody)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint))
            using (var httpContent = requestBody.ToHttpJsonContent())
            {
                request.Content = httpContent;

                using (var response =
                    await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                {
                    using (Stream stream = await response.Content.ReadAsStreamAsync())
                    {
                        await EnsureAuthorizedAndSuccessStatusCodeAsync(response, stream);

                        TResult result = stream.ToDeserializedJson<TResult>();

                        return result;
                    }
                }
            }
        }

        /// <summary>
        /// Calls endpoint using 'http patch' with specified request body. 
        /// </summary>
        public static async Task PatchAsync<TRequestBody>(this HttpClient httpClient, string endpoint, TRequestBody requestBody)
        {
            using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), endpoint))
            using (var httpContent = requestBody.ToHttpJsonContent())
            {
                request.Content = httpContent;

                using (var response =
                    await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                {
                    using (Stream stream = await response.Content.ReadAsStreamAsync())
                    {
                        await EnsureAuthorizedAndSuccessStatusCodeAsync(response, stream);
                    }
                }
            }
        }

        /// <summary>
        /// Calls endpoint using 'http put' with specified request body. 
        /// </summary>
        public static async Task PutAsync<TRequestBody>(this HttpClient httpClient, string endpoint, TRequestBody requestBody)
        {
            using (var request = new HttpRequestMessage(new HttpMethod("PUT"), endpoint))
            using (var httpContent = requestBody.ToHttpJsonContent())
            {
                request.Content = httpContent;

                using (var response =
                    await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                {
                    using (Stream stream = await response.Content.ReadAsStreamAsync())
                    {
                        await EnsureAuthorizedAndSuccessStatusCodeAsync(response, stream);
                    }
                }
            }
        }

        private static async Task EnsureAuthorizedAndSuccessStatusCodeAsync(HttpResponseMessage response, Stream responseStream)
        {
            if (!response.IsSuccessStatusCode)
            {
                string content = await responseStream.ConvertToStringAsync();

                ThrowUnsuccessfulStatusCodeException(response.StatusCode, content);
            }
        }

        private static void EnsureAuthorizedAndSuccessStatusCode(HttpResponseMessage response, string responseString)
        {
            if (!response.IsSuccessStatusCode)
            {
                ThrowUnsuccessfulStatusCodeException(response.StatusCode, responseString);
            }
        }

        private static void ThrowUnsuccessfulStatusCodeException(HttpStatusCode statusCode, string message)
        {
            if (statusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException(message);
            }

            throw new Exception($"{message}. Status code: {statusCode}");
        }
    }
}
