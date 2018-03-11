using System;
using System.IO;
using GeneriCode.GeneratedClasses.Genericode.v04;
using GeneriCode.Genericode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneriCode.Tests.Genericode
{
    [TestClass]
    public class Genericode04CodeListSerializerTest : TestBase
    {

        private static TestContext _testContext;

        public Genericode04CodeListSerializerTest() : base(_testContext)
        {

        }
        [ClassInitialize]
        public static void SetupTests(TestContext testContext)
        {
            _testContext = testContext;
        }


        [TestMethod]
        public void TestReadValid()
        {
            foreach (string aFile in Directory.GetFiles(Path.Combine(ResourceFolderPath, @"examples/gc/v04")))
            {
                // Resolve resource
                Assert.IsTrue(File.Exists(aFile));
                testReadAndWriteValid(File.ReadAllText(aFile));
            }
        }

        private static void testReadAndWriteValid(string aRes)
        {


            Genericode04CodeListSerializer serializer = new Genericode04CodeListSerializer();

            // Read code list
            CodeListDocument aCLDoc = serializer.Deserialize(aRes);
            Assert.IsNotNull(aCLDoc);

            // Write again
            string aDoc2 = serializer.Serialize(aCLDoc);
            Assert.IsNotNull(aDoc2);

            // Read code list again
            CodeListDocument aCLDoc2 = serializer.Deserialize(aDoc2);
        }

    }
}

