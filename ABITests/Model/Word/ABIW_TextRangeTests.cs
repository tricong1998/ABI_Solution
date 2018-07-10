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
            Application word = new Application();
            Document document1 = word.Documents.Open(@"G:\abi\word_module\Word_Table\doc1.docx");
            Document document2 = word.Documents.Open(@"G:\abi\word_module\Word_Table\doc2.docx");
            word.Visible = true;

            Range range1 = document1.Range();
            Range range2 = document2.Range();

            ABIW_TextRange aBIW_TextRange1 = new ABIW_TextRange(range1);
            ABIW_TextRange aBIW_TextRange2 = new ABIW_TextRange(range2);

            string result = aBIW_TextRange1.Compare(aBIW_TextRange2).Result.ToString();

            //Footnote fn1 = range1.Footnotes[1];
            //Footnote fn2 = range2.Footnotes[1];

            //ABIW_TextRange aBIW_TextRange3 = new ABIW_TextRange(fn1.Rang);
            //ABIW_TextRange aBIW_TextRange4 = new ABIW_TextRange(fn2.Range);

            //string result2 = aBIW_TextRange3.Compare(aBIW_TextRange4).Result.ToString();

            document1.Close();
            document2.Close();
            word.Quit();
        }

        [TestMethod()]
        public void classifyRange2Test()
        {
            Application word = new Application();
            Document document1 = word.Documents.Open(@"G:\abi\word_module\Word_Table\doc1.docx");
            Document document2 = word.Documents.Open(@"G:\abi\word_module\Word_Table\doc2.docx");
            word.Visible = true;

            Range range1 = document1.Range();
            Range range2 = document2.Range();

            ABIW_TextRange aBIW_TextRange1 = new ABIW_TextRange(range1);
            ABIW_TextRange aBIW_TextRange2 = new ABIW_TextRange(range2);

           // List<Range> ranges = aBIW_TextRange1.classifyRange2()
            
        }
    }
}