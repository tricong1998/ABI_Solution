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
    public class ABIE_Range : IComparison
    {
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Range range;
       
        public ABIE_Range(Range range)
        {
            this.Range = range;
        }

        public Range Range { get => range; set => range = value; }
       
        public IComparisonResult Compare(object other)
        {
            if(other is ABIE_Range otherRange)
            {
                if (this.XlCellAttributesCompare(otherRange).Result == ComparisonResultIndicate.equal
                    && this.XlAreSelectedCompare(otherRange).Result == ComparisonResultIndicate.equal
                    && this.XlBorderAttributesCompare(otherRange).Result == ComparisonResultIndicate.equal)
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
                                && (range.Cells[i, j] as Range).NumberFormat == (range.Cells[i, j] as Range).NumberFormat)
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
        public IComparisonResult XlBorderAttributesCompare(object other)
        {
            if (other is ABIE_Range otherRange)
            {
                if (range.Cells.Rows.Count == otherRange.range.Cells.Rows.Count
                    && range.Cells.Columns.Count == otherRange.range.Cells.Columns.Count)
                {
                    for (int i = 1; i <= range.Cells.Rows.Count; i++)
                    {
#pragma warning disable CS0162 // Unreachable code detected
                        for (int j = 1; j <= range.Cells.Columns.Count; j++)
#pragma warning restore CS0162 // Unreachable code detected
                        {
                            if ((range.Cells[i, j] as Range).Borders.Color == (range.Cells[i, j] as Range).Borders.Color
                                && (range.Cells[i, j] as Range).Borders.LineStyle == (range.Cells[i, j] as Range).Borders.LineStyle
                                && (range.Cells[i, j] as Range).Borders.Weight == (range.Cells[i, j] as Range).Borders.Weight
                                && (range.Cells[i, j] as Range).Borders.ColorIndex == (range.Cells[i, j] as Range).Borders.ColorIndex
                                && (range.Cells[i, j] as Range).Borders.ThemeColor == (range.Cells[i, j] as Range).Borders.ThemeColor
                                && (range.Cells[i, j] as Range).Borders.TintAndShade == (range.Cells[i, j] as Range).Borders.TintAndShade)
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

        public IComparisonResult XlAreSelectedCompare(object other)
        {
            if (other is ABIE_Range otherRange)
            {
                if (range.Cells.Rows.Count == otherRange.range.Cells.Rows.Count
                    && range.Cells.Columns.Count == otherRange.range.Cells.Columns.Count)
                {
                    for (int i = 1; i <= range.Cells.Rows.Count; i++)
                    {
#pragma warning disable CS0162 // Unreachable code detected
                        for (int j = 1; j <= range.Cells.Columns.Count; j++)
#pragma warning restore CS0162 // Unreachable code detected
                        {
                            if ((range.Cells[i, j] as Range).EntireRow.Select() == (range.Cells[i, j] as Range).EntireRow.Select()
                                && (range.Cells[i, j] as Range).EntireColumn.Select() == (range.Cells[i, j] as Range).EntireColumn.Select())
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
    }
}
