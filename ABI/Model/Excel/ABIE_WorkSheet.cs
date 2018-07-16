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
    class ABIE_WorkSheet : IComparison
    {
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Worksheet worksheet;
        private ABIE_Paragraph xlTopMargin;
        private ABIE_Paragraph xlLeftMargin;
        private ABIE_Paragraph xlBotMargin;
        private ABIE_Paragraph xlRightMargin;

        public ABIE_WorkSheet(Worksheet worksheet)
        {
            this.Worksheet = worksheet;
        //    this.xlTopMargin = new ABIE_Paragraph(worksheet.PageSetup[]);
        }

        public Worksheet Worksheet { get => worksheet; set => worksheet = value; }
        internal ABIE_Paragraph XlTopMargin { get => xlTopMargin; set => xlTopMargin = value; }
        internal ABIE_Paragraph XlLeftMargin { get => xlLeftMargin; set => xlLeftMargin = value; }
        internal ABIE_Paragraph XlBotMargin { get => xlBotMargin; set => xlBotMargin = value; }
        internal ABIE_Paragraph XlRightMargin { get => xlRightMargin; set => xlRightMargin = value; }

        public IComparisonResult Compare(object other)
        {
            if (other is ABIE_WorkSheet otherWorksheet)
            {
                if (worksheet.Name == otherWorksheet.worksheet.Name
                    && this.XlPageSetupCompare(otherWorksheet).Result == ComparisonResultIndicate.equal
                    && this.XlFreezeRowCompare(otherWorksheet).Result == ComparisonResultIndicate.equal
                    && this.XlSizeRowColumnCompare(otherWorksheet).Result == ComparisonResultIndicate.equal)
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            throw new NotImplementedException();
        }
        public IComparisonResult XlPageSetupCompare(object other)
        {
            if (other is ABIE_WorkSheet otherWorksheet)
            {
                if (xlTopMargin.Compare(otherWorksheet.xlTopMargin).Result == ComparisonResultIndicate.equal
                    && xlLeftMargin.Compare(otherWorksheet.xlLeftMargin).Result == ComparisonResultIndicate.equal
                    && xlBotMargin.Compare(otherWorksheet.xlBotMargin).Result == ComparisonResultIndicate.equal
                    && xlRightMargin.Compare(otherWorksheet.xlRightMargin).Result == ComparisonResultIndicate.equal)
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            throw new NotImplementedException();
        }
        public IComparisonResult XlFreezeRowCompare(object other)
        {
            if (other is ABIE_WorkSheet otherWorksheet)
            {
                if (worksheet.Application.ActiveWindow.SplitRow == otherWorksheet.worksheet.Application.ActiveWindow.SplitRow
                    && worksheet.Application.ActiveWindow.FreezePanes == otherWorksheet.worksheet.Application.ActiveWindow.FreezePanes)
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            throw new NotImplementedException();
        }
        public IComparisonResult XlSortCompare(object other)
        {
            if(other is ABIE_WorkSheet otherWorksheet)
            {
                
            }
            throw new NotImplementedException();
        }
        public IComparisonResult XlSizeRowColumnCompare(object other)
        {
            if (other is ABIE_WorkSheet otherWorksheet)
            {
                if (worksheet.UsedRange.EntireRow.Height == otherWorksheet.worksheet.UsedRange.EntireRow.Height
                    && worksheet.UsedRange.EntireRow.Width == otherWorksheet.worksheet.UsedRange.EntireRow.Width)
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            throw new NotImplementedException();
        }
    }
}
