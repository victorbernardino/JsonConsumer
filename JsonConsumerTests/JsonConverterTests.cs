using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonConsumer;
using System.IO;
using System.Runtime.Serialization;

namespace JsonConsumerTests
{
    [TestClass]
    public class JsonConverterTests
    {
        private JsonExamples examples { get; set; }
        
        public JsonConverterTests()
        {
            examples = new JsonExamples();
        }

        [TestMethod]
        public void TryConvertingFromJsonToSimpleObject()
        {
            using (Stream stream = examples.ObjectWithName())
            {
                JsonConverter<ObjectWithName> converter = new JsonConverter<ObjectWithName>();
                ObjectWithName objectPopulated = converter.ConvertFrom(stream);
                Assert.IsTrue(objectPopulated.Name == "JsonConsumer");
            }
        }

        [TestMethod]
        public void TryConvertingFromStreamNullToSimpleObject()
        {

            JsonConverter<ObjectWithName> converter = new JsonConverter<ObjectWithName>();
            ObjectWithName objectExpected = converter.ConvertFrom(null);
            Assert.IsTrue(objectExpected.Name == new ObjectWithName().Name);
           
        }

        [TestMethod]
        [ExpectedException(typeof(SerializationException))]
        public void TryConvertingFromStreamEmptyToSimpleObject()
        {
            using (Stream stream = examples.EmptyObject())
            {
                JsonConverter<ObjectWithName> converter = new JsonConverter<ObjectWithName>();
                ObjectWithName objectExpected = converter.ConvertFrom(stream);
            }
        }

        [TestMethod]
        public void TryConvertingFromEmptyValidObjectToSimpleObject()
        {
            using (Stream stream = examples.EmptyValidObject())
            {
                JsonConverter<ObjectWithName> converter = new JsonConverter<ObjectWithName>();
                ObjectWithName objectExpected = converter.ConvertFrom(stream);
                Assert.IsTrue(objectExpected.Name == new ObjectWithName().Name);
            }
        }       
    }
}
