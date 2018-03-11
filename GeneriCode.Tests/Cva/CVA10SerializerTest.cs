using GeneriCode.Builder;
using GeneriCode.Cva;
using GeneriCode.GeneratedClasses.CVA.v10;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneriCode.Tests.Cva
{
    [TestClass]
    public class CVA10SerializerTest : TestBase
    {
        private static TestContext _testContext;

        public CVA10SerializerTest() : base(_testContext)
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
            foreach (string aFile in Directory.GetFiles(Path.Combine(ResourceFolderPath, @"examples\cva\v10")))
                testReadAndWriteValid(File.ReadAllText(aFile));
        }

        private static void testReadAndWriteValid(string aRes)
        {

            CVA10XmlSerializer serializer = new CVA10XmlSerializer();
            // Read CVA
            ContextValueAssociation aCVA = serializer.Deserialize(aRes);
            Assert.IsNotNull(aCVA);

            // Write again
            string aDoc2 = serializer.Serialize(aCVA);
            Assert.IsNotNull(aDoc2);
        }
    }
}
