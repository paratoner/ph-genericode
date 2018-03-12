using System;
using System.IO;
using GeneriCode.Excel;
using GeneriCode.GeneratedClasses.Genericode.v04;
using GeneriCode.Genericode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace GeneriCode.Tests.Excel
{
    [TestClass]
    public class ExcelSheetToCodeList04Test : TestBase
    {

        private static TestContext _testContext;

        public ExcelSheetToCodeList04Test() : base(_testContext)
        {

        }
        [ClassInitialize]
        public static void SetupTests(TestContext testContext)
        {
            _testContext = testContext;
        }
        [TestMethod]
        public void TestReadExcel()
        {
            foreach (string aFile in Directory.GetFiles(Path.Combine(ResourceFolderPath, @"excel")))
            {
                // Resolve resource
                Assert.IsTrue(File.Exists(aFile));
                // Interpret as Excel
                using (FileStream file = new FileStream(aFile, FileMode.Open, FileAccess.Read))
                {

                    IWorkbook aWB = WorkbookFactory.Create(file); // EExcelVersion.XLS.readWorkbook(aXls.getInputStream());
                    Assert.IsNotNull(aWB);

                    // Check whether all required sheets are present
                    ISheet aSheet = aWB.GetSheetAt(0);
                    Assert.IsNotNull(aSheet);

                    ExcelReadOptions<UseType> aReadOptions = new ExcelReadOptions<UseType>().SetLinesToSkip(1)
                                                                                                    .SetLineIndexShortName(0);
                    aReadOptions.AddColumn(0, "id", UseType.required, "string", true);
                    aReadOptions.AddColumn(1, "name", UseType.required, "string", false);
                    CodeListDocument aCodeList = ExcelSheetToCodeList04.ConvertToSimpleCodeList(aSheet,
                                                                                                     aReadOptions,
                                                                                                      "ExampleList",
                                                                                                      "1.0",
                                                                                                      new Uri("urn:www.helger.com:names:example"),
                                                                                                      new Uri("urn:www.helger.com:names:example-1.0"),
                                                                                                      null);
                    string aDoc = new Genericode04CodeListSerializer().Serialize(aCodeList);
                    Assert.IsNotNull(aDoc);
                    CodeListDocument aCLDoc = new Genericode04CodeListSerializer().Deserialize(aDoc);
                    Assert.IsNotNull(aCLDoc);
                }

            }

        }
    }
}
