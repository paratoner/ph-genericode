using System;
using System.IO;
using GeneriCode.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneriCode.Tests.Builder
{
    [TestClass]
    public class GenericodeReaderTest : TestBase
    {
        private static TestContext _testContext;

        public GenericodeReaderTest() : base(_testContext)
        {

        }
        [ClassInitialize]
        public static void SetupTests(TestContext testContext)
        {
            _testContext = testContext;
        }


        [TestMethod]
        public void TestReadWrite04()
        {
            foreach (string aFile in Directory.GetFiles(Path.Combine(ResourceFolderPath, @"examples/gc/v04")))
            {
                // Resolve resource
                Assert.IsTrue(File.Exists(aFile));
                testReadAndWrite04(File.ReadAllText(aFile));
            }
        }
        [TestMethod]
        public void TestReadWrite10()
        {
            foreach (string aFile in Directory.GetFiles(Path.Combine(ResourceFolderPath, @"examples/gc/v10"), "*.gc"))
            {
                // Resolve resource
                Assert.IsTrue(File.Exists(aFile));
                testReadAndWrite10(File.ReadAllText(aFile));
            }
        }

        private static void testReadAndWrite10(string aRes)
        {
            GenericodeReader reader = new GenericodeReader();

            // Read code list
            GeneratedClasses.Genericode.v10.CodeListDocument aCLDoc = reader.ReadGC10CodeList(aRes);
            Assert.IsNotNull(aCLDoc);
        }
        private static void testReadAndWrite04(string Res)
        {
            GenericodeReader reader = new GenericodeReader();

            // Read code list
            GeneratedClasses.Genericode.v04.CodeListDocument aCLDoc = reader.ReadGC04CodeList(Res);
            Assert.IsNotNull(aCLDoc);
        }

    }
}
