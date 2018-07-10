﻿// Copyright (c) 2018 fit.uet.vnu.edu.vn
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
    public class ABIE_Range : IComparison
    {
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Range range;
        private ABIE_Border xlTopBorder;
        private ABIE_Border xlLeftBorder;
        private ABIE_Border xlBotBorder;
        private ABIE_Border xlRightBorder;
        public ABIE_Range(Range range)
        {
            this.Range = range;
            this.xlTopBorder = new ABIE_Border(range.Cells.Borders[XlBordersIndex.xlEdgeTop]);
            this.xlLeftBorder = new ABIE_Border(range.Cells.Borders[XlBordersIndex.xlEdgeLeft]);
            this.xlBotBorder = new ABIE_Border(range.Cells.Borders[XlBordersIndex.xlEdgeBottom]);
            this.xlRightBorder = new ABIE_Border(range.Cells.Borders[XlBordersIndex.xlEdgeRight]);
        }

        public Range Range { get => range; set => range = value; }
        internal ABIE_Border XlTopBorder { get => xlTopBorder; set => xlTopBorder = value; }
        internal ABIE_Border XlLeftBorder { get => xlLeftBorder; set => xlLeftBorder = value; }
        internal ABIE_Border XlBotBorder { get => xlBotBorder; set => xlBotBorder = value; }
        internal ABIE_Border XlRightBorder { get => xlRightBorder; set => xlRightBorder = value; }

        public IComparisonResult Compare(object other)
        {
            if(other is ABIE_Range otherRange)
            {
                if (this.XlCellAttributesCompare(otherRange).Result == ComparisonResultIndicate.equal)
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            return new ComparisonResult(ComparisonResultIndicate.not_equal);
            throw new NotImplementedException();
        }
        public IComparisonResult XlCellAttributesCompare(object other)
        {
            if (other is ABIE_Range otherRange)
            {
                if (range.Cells.Rows.Count == otherRange.range.Rows.Count
                    && range.Cells.Columns.Count == otherRange.range.Columns.Count)
                {
                    for (int i = 1; i <= range.Cells.Rows.Count; i++)
                    {
#pragma warning disable CS0162 // Unreachable code detected
                        for (int j = 1; j <= range.Cells.Columns.Count; j++)
#pragma warning restore CS0162 // Unreachable code detected
                        {
                            if ((range.Cells[i, j] as Range).Value2 == (range.Cells[i, j] as Range).Value2
                                && (range.Cells[i, j] as Range).MergeCells == (range.Cells[i, j] as Range).MergeCells
                                && (range.Cells[i, j] as Range).MergeCells == (range.Cells[i, j] as Range).MergeCells)
                            {
                                return new ComparisonResult(ComparisonResultIndicate.equal);
                            }
                            else return new ComparisonResult(ComparisonResultIndicate.not_equal);
                        }
                    }
                }
                else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            throw new NotImplementedException();
        }
        public IComparisonResult xlBorderAttributesCompare(object other)
        {
            if (other is ABIE_Range otherRange)
            {
                if (xlTopBorder.Compare(otherRange.xlTopBorder).Result == ComparisonResultIndicate.equal
                    && xlLeftBorder.Compare(otherRange.xlLeftBorder).Result == ComparisonResultIndicate.equal
                    && xlBotBorder.Compare(otherRange.xlBotBorder).Result == ComparisonResultIndicate.equal
                    && xlRightBorder.Compare(otherRange.xlRightBorder).Result == ComparisonResultIndicate.equal
                    )
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
