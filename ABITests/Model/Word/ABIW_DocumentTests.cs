// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 12:09 PM 2018/6/26
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
    public class ABIW_DocumentTests
    {
        [TestMethod()]
        public void CompareTest()
        {
            Application app1 = new Application();
            Document doc1 = app1.Documents.Open(@"D:\file1.docx");
            ABIW_Document abiw1 = new ABIW_Document(doc1);

            Application app2 = new Application();
            Document doc2 = app2.Documents.Open(@"D:\file2.docx");
            ABIW_Document abiw2 = new ABIW_Document(doc2);

            // compare test, you can put a break point here and select "debug test" to debug
            abiw1.Compare(abiw2);
        }
    }
}