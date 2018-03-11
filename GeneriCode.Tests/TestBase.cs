using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneriCode.Tests
{
    [TestClass]
    public abstract class TestBase
    {
        protected readonly string ResourceFolderPath;
        public TestContext TestContext { get; set; }
        

        public TestBase(TestContext testContext)
        {
            TestContext = testContext;
            ResourceFolderPath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(TestContext.TestDir)), "GeneriCode.Tests\\Resources");
        }
    }
}
