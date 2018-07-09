using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
namespace ABI.Tests
{
    [TestClass()]
    public class ABIW_TextRangeTests
    {
        [TestMethod()]
        public void CompareTest()
        {
            Application application = new Application();
            Document document = application.Documents.Open(@"E:\path2 - Copy.docx");

            Assert.Fail();
        }

        [TestMethod()]
        public void classifyRange2Test()
        {
            Application application = new Application();
            Document document = application.Documents.Open(@"E:\path2 - Copy.docx");
            Document document2 = application.Documents.Open(@"E:\path2 - Copy.docx");
            ABIW_TextRange a = new ABIW_TextRange(document.Range());
            ABIW_TextRange a2 = new ABIW_TextRange(document2.Range());
            List<Range> ranges = new List<Range>();
            Range range = a.Range;
            ComparisonResultIndicate result = a.Compare(a2.Range).Result;
            //object na = a.classifyRange2(range.Parent, range);
            document.Close();
            document2.Close();
            application.Quit();
            Assert.Fail();
        }
    }
}