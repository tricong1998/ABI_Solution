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
    public class ABIW_EndnotesTests
    {
        [TestMethod()]
        public void CompareTest()
        {
            Application word = new Application();
            Document document1 = word.Documents.Open(@"G:\abi\word_module\Word_Table\test1.docx");
            Document document2 = word.Documents.Open(@"G:\abi\word_module\Word_Table\test2.docx");
            word.Visible = true;

            Range range1 = document1.Range();
            Range range2 = document2.Range();

            Endnotes endnotes1 = range1.Endnotes;
            Endnotes endnotes2 = range2.Endnotes;


            ABIW_Endnotes aBIW_Endnotes1 = new ABIW_Endnotes(endnotes1);
            ABIW_Endnotes aBIW_Endnotes2 = new ABIW_Endnotes(endnotes2);

            string result = aBIW_Endnotes1.Compare(aBIW_Endnotes2).Result.ToString();

            document1.Close();
            document2.Close();
            word.Quit();
        }
    }
}