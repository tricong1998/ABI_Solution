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
    public class CompareWFontTests
    {
        [TestMethod()]
        public void CompareTest()
        {
            int score = 0;
            Application application = new Application();
            Document anwser = application.Documents.Open(@"E:\1.docx");
            Document correctAnwser = application.Documents.Open(@"E:\1 - Copy.docx");
            ABIW_Document document1 = new ABIW_Document(anwser);
            ABIW_Document document2 = new ABIW_Document(correctAnwser);
            CompareWFont compare = new CompareWFont();
            var aa = compare.Compare(document1, document2);
            if (((ComparisonResult) compare.Compare(document1, document2)).Result == ComparisonResultIndicate.equal)
            {                
                score++;
            }
            anwser.Close();
            correctAnwser.Close();
            application.Quit();
            int a = score;
        }
    }
}