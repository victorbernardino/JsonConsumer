using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace JsonConsumer
{
    public class JsonConverter<T> where T : new()
    {
        public T ConvertFrom(Stream jsonObject)
        {
            if (jsonObject == null)
            {
                return new T();
            }

            DataContractJsonSerializer deserializadorJson = new DataContractJsonSerializer(typeof(T));
            jsonObject.Position = 0;

            T convertedObject  = (T)deserializadorJson.ReadObject(jsonObject);                        
            return convertedObject;
        }
    }
}
