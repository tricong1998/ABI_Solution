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
    public class ABIW_ParagraphTests
    {
        [TestMethod()]
        public void checkEqualParagraphTest()
        {
            Application application = new Application();
            Document document = application.Documents.Open(@"E:\path2 - Copy.docx");
            Document document2 = application.Documents.Open(@"E:\path2.docx");
            ABIW_Paragraph a = new ABIW_Paragraph(document.Range().Paragraphs[1]);
            ABIW_Paragraph b = new ABIW_Paragraph(document2.Range().Paragraphs[1]);
            bool x = a.checkEqualParagraph(a.Paragraph, b.Paragraph);
            document.Close();
            document2.Close();
            application.Quit();
        }

        [TestMethod()]
        public void CompareTest()
        {
            Application application = new Application();
            Document document = application.Documents.Open(@"E:\path2 - Copy.docx");
            Document document2 = application.Documents.Open(@"E:\path2.docx");
            ABIW_Paragraph a = new ABIW_Paragraph(document.Range().Paragraphs[1]);
            ABIW_Paragraph b = new ABIW_Paragraph(document2.Range().Paragraphs[1]);
            ComparisonResultIndicate result = a.Compare(b).Result;
            //bool x = a.checkEqualParagraph(a.Paragraph, b.Paragraph);
            document.Close();
            document2.Close();
            application.Quit();
        }
    }
}