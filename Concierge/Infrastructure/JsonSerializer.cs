using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Concierge.Infrastructure
{
    public class JsonSerializer<T> where T : class
    {
        public static T Serialize(string json)
        {
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return serializer.ReadObject(stream) as T;
            }
        }

        public static string DeSerialize(T obj)
        {
            string json = string.Empty;

            using (var stream = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(typeof(T));
                ser.WriteObject(stream, obj);

                json = Encoding.Default.GetString(stream.ToArray());
            }
            return json;
        }
    }
}