using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABI.Model.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
namespace ABI.Model.Excel.Tests
{
    [TestClass()]
    public class ABIE_RangeTests
    {
        [TestMethod()]
        public void CompareTest()
        {

            Application xlApp = new Application();
            Workbook xlWb1 = xlApp.Workbooks.Open(@"C:\Users\phamv\Desktop\TKB.xlsx");
            Workbook xlWb2 = xlApp.Workbooks.Open(@"C:\Users\phamv\Desktop\TKBCopy.xlsx");
           
            Worksheet xlWs2 = (Worksheet)xlWb2.Worksheets.get_Item(1);
            Worksheet xlWs1 = (Worksheet)xlWb1.Worksheets.get_Item(1);

            Range range1 = xlWs1.UsedRange;
            Range rang2 = xlWs2.UsedRange;
            ABIE_Range range = new ABIE_Range(range1);
            ABIE_Range otherRange = new ABIE_Range(rang2);
            ComparisonResultIndicate result = range.Compare(otherRange).Result;
            string str_result = result.ToString();

            xlWb1.Save();
            xlWb2.Save();
            xlWb1.Close();
            xlWb2.Close();
            xlApp.Quit();

        }
    }
}