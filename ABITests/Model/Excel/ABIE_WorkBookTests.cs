using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABI.Model.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Microsoft.Office.Interop.Excel;

namespace ABI.Model.Excel.Tests
{
    [TestClass()]
    public class ABIE_WorkBookTests
    {
        [TestMethod()]
        public void CompareTest()
        {
            
            Application xlApp = new Application();
            Workbook xlWb1 = xlApp.Workbooks.Open(@"C:\Users\phamv\Desktop\TKB.xlsx");

            
            Workbook xlWb2 = xlApp.Workbooks.Open(@"C:\Users\phamv\Desktop\TKBCopy.xlsx");

            ABIE_WorkBook workbook = new ABIE_WorkBook(xlWb1);
            ABIE_WorkBook otherWorkbook = new ABIE_WorkBook(xlWb2);
            ComparisonResultIndicate result = workbook.Compare(otherWorkbook).Result;
            string str_result = result.ToString();

            xlWb1.Close();
            xlWb2.Close();
            xlApp.Quit();
        }
    }
}