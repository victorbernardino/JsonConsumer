using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConsumerTests
{
    public class JsonExamples
    {
        public Stream ObjectWithName()
        {
            StringBuilder objectJson = new StringBuilder();
            objectJson.AppendLine("{");
            objectJson.AppendLine("\"Name\": \"JsonConsumer\"");
            objectJson.AppendLine("}");

            return StreamFromStringBuilder(objectJson);
        }

        public Stream EmptyObject()
        {
            StringBuilder objectJson = new StringBuilder();
            return StreamFromStringBuilder(objectJson);
        }

        public Stream EmptyValidObject()
        {
            StringBuilder objectJson = new StringBuilder();
            objectJson.AppendLine("{ }");
            return StreamFromStringBuilder(objectJson);
        }

        public Stream StreamFromStringBuilder(StringBuilder s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);

            writer.Write(s);
            writer.Flush();

            stream.Position = 0;
            return stream;
        }
    }


    public class ObjectWithName
    {
        public string Name { get; set; }               
    }
}
