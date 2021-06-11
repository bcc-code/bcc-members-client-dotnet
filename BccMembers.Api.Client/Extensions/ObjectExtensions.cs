using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BccMembers.Api.Client.Extensions
{
    internal static class ObjectExtensions
    {
        /// <summary>
        /// Converts object to <see cref="HttpContent"/> instance to be used as json body for http requests
        /// </summary>
        public static HttpContent ToHttpJsonContent(this object target)
        {
            if (target == null)
            {
                return null;
            }

            var stream = new MemoryStream();
            stream.WriteObject(target);
            stream.Seek(0, SeekOrigin.Begin);

            HttpContent httpContent = new StreamContent(stream);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return httpContent;
        }
    }
}
