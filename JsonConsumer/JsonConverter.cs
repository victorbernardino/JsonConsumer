using System.IO;
using System.Runtime.Serialization.Json;

namespace JsonConsumer
{
    public class JsonConverter<T> where T : new()
    {
        private const int StartPositon = 0;

        DataContractJsonSerializer Deserializer { get; set; }

        public JsonConverter()
        {
            Deserializer = new DataContractJsonSerializer(typeof(T));
        }

        public T ConvertFrom(Stream jsonObject)
        {
            if (jsonObject == null)
            {
                return new T();
            }

            SetStreamToStartPosition(jsonObject);
            return (T)Deserializer.ReadObject(jsonObject);
        }

        private void SetStreamToStartPosition(Stream jsonObject)
        {
            jsonObject.Position = StartPositon;
        }
    }
}
