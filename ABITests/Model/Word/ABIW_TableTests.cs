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
    public class ABIW_TableTests
    {
        [TestMethod()]
        public void CompareTest()
        {
            Application word = new Application();
            Document document = word.Documents.Open(@"G:\abi\word_module\Word_Table\table.docx");
            Document document_new = word.Documents.Open(@"G:\abi\word_module\Word_Table\table_new.docx");
            word.Visible = true;

            Range range = document.Range();
            Tables tables = range.Tables;
            Table t = tables[1];

            Range range_new = document_new.Range();
            Tables tables_new = range_new.Tables;
            Table t_new = tables_new[1];

            ABIW_Table table = new ABIW_Table(t);
            ABIW_Table otherTable = new ABIW_Table(t_new);

            ComparisonResultIndicate result = table.Compare(otherTable).Result;
            string str_result = result.ToString();

            document.Close();
            document_new.Close();
            word.Quit();
        }
    }
}