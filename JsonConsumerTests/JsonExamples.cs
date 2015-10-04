using System.IO;
using System.Text;

namespace JsonConsumerTests
{
    public class JsonExamples
    {
        public Stream JsonStream()
        {
            StringBuilder objectJson = new StringBuilder();
            objectJson.AppendLine("{");
            objectJson.AppendLine(string.Format("\"Name\": \"{0}\"", Constants.MockObjectValue));
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
}
