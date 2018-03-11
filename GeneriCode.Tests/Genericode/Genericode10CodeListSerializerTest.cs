using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using GeneriCode.Genericode;
using GeneriCode.GeneratedClasses.Genericode.v10;


namespace GeneriCode.Tests.Genericode
{
    /// <summary>
    /// Summary description for Genericode10CodeListSerializerTest
    /// </summary>
    [TestClass]
    public class Genericode10CodeListSerializerTest : TestBase

    {
        private static TestContext _testContext;

        public Genericode10CodeListSerializerTest() : base(_testContext)
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
            foreach (string aFile in Directory.GetFiles(Path.Combine(ResourceFolderPath, @"examples/gc/v10"), "*.gc"))
            {
                // Resolve resource
                Assert.IsTrue(File.Exists(aFile));
                testReadAndWriteValid(File.ReadAllText(aFile));
            }
        }

        private static void testReadAndWriteValid(string aRes)
        {

            Genericode10CodeListSerializer serializer = new Genericode10CodeListSerializer();

            // Read code list
            CodeListDocument aCLDoc = serializer.Deserialize(aRes);
            Assert.IsNotNull(aCLDoc);

            // Write again
            string aDoc2 = serializer.Serialize(aCLDoc);
            Assert.IsNotNull(aDoc2);

            // Read code list again
            CodeListDocument aCLDoc2 = serializer.Deserialize(aDoc2);
            Assert.IsNotNull(aCLDoc2);
        }
    }
}
