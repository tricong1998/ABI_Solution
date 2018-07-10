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
    public class ABIW_FootNotesTests
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

            Footnotes footnotes1 = range1.Footnotes;
            Footnotes footnotes2 = range2.Footnotes;
            Range r = footnotes1[1].Range;

            ABIW_FootNotes aBIW_FootNotes1 = new ABIW_FootNotes(footnotes1);
            ABIW_FootNotes aBIW_FootNotes2 = new ABIW_FootNotes(footnotes2);

            string result = aBIW_FootNotes1.Compare(aBIW_FootNotes2).Result.ToString();

            document1.Close();
            document2.Close();
            word.Quit();
        }
    }
}