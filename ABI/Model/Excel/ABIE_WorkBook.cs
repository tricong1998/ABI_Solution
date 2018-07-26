// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @phamvhoang
// created on 12:15 PM 2018/7/6
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace ABI.Model.Excel
{
    /// <summary>
    /// represent for a border of an object
    /// </summary>
    public class ABIE_WorkBook : IComparison
    {
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Workbook workbook;
        public ABIE_WorkBook(Workbook workbook)
        {
            this.workbook = workbook;
        }

        public Workbook Workbook { get => workbook; set => workbook = value; }

        public IComparisonResult Compare(object other)
        {
            if (other is ABIE_WorkBook otherWorkbook)
            {
                if (workbook.FileFormat == otherWorkbook.workbook.FileFormat
                    && workbook.Name == otherWorkbook.workbook.Name
                    && this.XlWorksheetsCompare(otherWorkbook).Result == ComparisonResultIndicate.equal)
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }  
                else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
  
            else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            throw new NotImplementedException();
        }
        public ComparisonResult XlWorksheetsCompare(object other)
        {
            if(other is ABIE_WorkBook otherWorkbook)
            {
                if (workbook.Worksheets.Count == otherWorkbook.workbook.Worksheets.Count)
                {
#pragma warning disable CS0162 // Unreachable code detected
                    for (int i = 1; i <= workbook.Worksheets.Count; i++)
#pragma warning restore CS0162 // Unreachable code detected
                    {
                        Worksheet worksheet = this.workbook.Worksheets[i];
                        Worksheet otherWorksheet = otherWorkbook.workbook.Worksheets[i];
                        ABIE_WorkSheet xlWorksheet = new ABIE_WorkSheet(worksheet);
                        ABIE_WorkSheet xlOtherWorkhheet = new ABIE_WorkSheet(otherWorksheet);
                        if (xlWorksheet.Compare(xlOtherWorkhheet).Result == ComparisonResultIndicate.equal)
                        {
                            return new ComparisonResult(ComparisonResultIndicate.equal);
                        }
                        else return new ComparisonResult(ComparisonResultIndicate.not_equal);
                    }
                }
                else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            throw new NotImplementedException();
        }
    }
}
