using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BccMembers.Api.Client.Extensions
{
    internal static class StreamExtensions
    {
        /// <summary>
        /// Deserializes stream (containing json) into object
        /// </summary>
        public static T ToDeserializedJson<T>(this Stream stream)
        {
            if (stream == null || !stream.CanRead)
            {
                return default;
            }

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();
                T result = serializer.Deserialize<T>(jsonReader);

                return result;
            }
        }

        /// <summary>
        /// Writes serialized object into stream
        /// </summary>
        public static void WriteObject(this Stream stream, object value)
        {
            if (value == null)
            {
                return;
            }

            using (var streamWriter = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            using (var jsonWriter = new JsonTextWriter(streamWriter) { Formatting = Formatting.None })
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(jsonWriter, value);
                jsonWriter.Flush();
            }
        }

        public static async Task<string> ConvertToStringAsync(this Stream stream)
        {
            if (stream == null)
            {
                return null;
            }

            using (var streamReader = new StreamReader(stream))
            {
                return await streamReader.ReadToEndAsync();
            }
        }
    }
}
