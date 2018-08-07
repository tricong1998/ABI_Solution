// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @phamvhoang
// created on 12:15 PM 2018/7/6

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI_DCH.Common;
using Microsoft.Office.Interop.Excel;

namespace ABI_Server.Business.Models.Excel
{
    /// <summary>
    /// represent for a border of an object
    /// </summary>
    public class ABIE_Range : IComparison
    {
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
                            if ((range.Cells[i, j] as Range).Value2 == (otherRange.range.Cells[i, j] as Range).Value2
                                && (range.Cells[i, j] as Range).MergeCells == (otherRange.range.Cells[i, j] as Range).MergeCells
                                && (range.Cells[i, j] as Range).NumberFormat == (otherRange.range.Cells[i, j] as Range).NumberFormat)
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
                            if ((range.Cells[i, j] as Range).Borders.Color == (otherRange.range.Cells[i, j] as Range).Borders.Color
                                && (range.Cells[i, j] as Range).Borders.LineStyle == (otherRange.range.Cells[i, j] as Range).Borders.LineStyle
                                && (range.Cells[i, j] as Range).Borders.Weight == (otherRange.range.Cells[i, j] as Range).Borders.Weight
                                && (range.Cells[i, j] as Range).Borders.ColorIndex == (otherRange.range.Cells[i, j] as Range).Borders.ColorIndex
                                && (range.Cells[i, j] as Range).Borders.ThemeColor == (otherRange.range.Cells[i, j] as Range).Borders.ThemeColor
                                && (range.Cells[i, j] as Range).Borders.TintAndShade == (otherRange.range.Cells[i, j] as Range).Borders.TintAndShade)
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
                            if ((range.Cells[i, j] as Range).EntireRow.Select() == (otherRange.range.Cells[i, j] as Range).EntireRow.Select()
                                && (range.Cells[i, j] as Range).EntireColumn.Select() == (otherRange.range.Cells[i, j] as Range).EntireColumn.Select())
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
        public IComparisonResult XlFontCompare(object other)
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
                            if ((range.Cells[i, j] as Range).Font.Size == (otherRange.range.Cells[i, j] as Range).Font.Size
                                && (range.Cells[i, j] as Range).Font.Bold == (otherRange.range.Cells[i, j] as Range).Font.Bold
                                && (range.Cells[i, j] as Range).Font.Italic == (otherRange.range.Cells[i, j] as Range).Font.Italic
                                && (range.Cells[i, j] as Range).Font.Name == (otherRange.range.Cells[i, j] as Range).Font.Name
                                && (range.Cells[i, j] as Range).Font.Underline == (otherRange.range.Cells[i, j] as Range).Font.Underline
                                && (range.Cells[i, j] as Range).Font.Strikethrough == (otherRange.range.Cells[i, j] as Range).Font.Strikethrough
                                && (range.Cells[i, j] as Range).Font.Color == (otherRange.range.Cells[i, j] as Range).Font.Color
                                && (range.Cells[i, j] as Range).Interior.Color == (otherRange.range.Cells[i, j] as Range).Interior.Color)
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
