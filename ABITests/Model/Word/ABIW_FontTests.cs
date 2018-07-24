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
    public class ABIW_FontTests
    {
        [TestMethod()]
        public void CompareTest()
        {
            Application application = new Application();
            Document document = application.Documents.Open(@"G:\abi\word_module\Word_Table\doc5.docx");
            Document document2 = application.Documents.Open(@"G:\abi\word_module\Word_Table\doc6.docx");
            application.Visible = true;

            Range range = document.Range();
            Range range2 = document2.Range();

            ABIW_Font font1 = new ABIW_Font(range.Font);
            ABIW_Font font2 = new ABIW_Font(range2.Font);

            string result = font1.Compare(font2).Result.ToString();

            document.Close();
            document2.Close();
            application.Quit();
        }
    }
}