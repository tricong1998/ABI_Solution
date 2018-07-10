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
    public class ABIW_TextRangeProTests
    {
        [TestMethod()]
        public void CompareTest()
        {
            Application application = new Application();
            Document document = application.Documents.Open(@"G:\abi\word_module\Word_Table\doc3.docx");
            Document document2 = application.Documents.Open(@"G:\abi\word_module\Word_Table\doc4.docx");
            application.Visible = true;

            Range range = document.Range();
            Range range2 = document2.Range();

            ABIW_TextRangePro a = new ABIW_TextRangePro(range);
            ABIW_TextRangePro a2 = new ABIW_TextRangePro(range2);

            string result = a.Compare(a2).Result.ToString();

            document.Close();
            document2.Close();
            application.Quit();
        }
    }
}