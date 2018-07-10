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
        public void classifyRange2Test()
        {
            Application application = new Application();
            Document document = application.Documents.Open(@"E:\path2 - Copy.docx");
            Document document2 = application.Documents.Open(@"E:\path2.docx");
            ABIW_TextRange a = new ABIW_TextRange(document.Range());
            ABIW_TextRange a2 = new ABIW_TextRange(document2.Range());
            //List<Range> ranges = new List<Range>();
            //List<object> ranges = a.classifyRange2(document, document.Range());
            bool ab = a.checkEqualText(a.Range, a2.Range);
            bool ab2 = a.checkTwoParagraphs(a.Range.Paragraphs, a2.Range.Paragraphs);
            bool ab3 = a.check(a2);
            ComparisonResultIndicate result = a.Compare(a2).Result;
            //List<Range> ranges =
            List<Range> list = new List<Range>();
            //Range range = 
            //a.ClassifyRange2(a2.Range);
            a.Test(a.Range);
            document.Close();
            document2.Close();
            application.Quit();
        }

        [TestMethod()]
        public void checkTwoParagraphsTest()
        {
            Application application = new Application();
            Document document = application.Documents.Open(@"E:\path2 - Copy.docx");
            Document document2 = application.Documents.Open(@"E:\path2.docx");
            ABIW_TextRange a = new ABIW_TextRange(document.Range());
            ABIW_TextRange a2 = new ABIW_TextRange(document2.Range());

            bool c = a.checkTwoParagraphs(a.Range.Paragraphs, a2.Range.Paragraphs);
            document.Close();
            document2.Close();
            application.Quit();
        }
    }
}