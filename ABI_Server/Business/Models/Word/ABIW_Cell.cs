// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @vanduong
// created on 12:44 AM 2018/7/3
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI_DCH.Common;
using Microsoft.Office.Interop.Word;

namespace ABI_Server.Business.Models.Word
{
    /// <summary>
    /// represent for a cell in a table
    /// </summary>
    class ABIW_Cell : IComparison
    {
        private Cell cell;
        private ABIW_Border wBorderTop;
        private ABIW_Border wBorderBottom;
        private ABIW_Border wBorderLeft;
        private ABIW_Border wBorderRight;


        public ABIW_Cell(Cell cell)
        {
            this.Cell = cell;
            this.wBorderTop = new ABIW_Border(cell.Borders[WdBorderType.wdBorderTop]);
            this.wBorderBottom = new ABIW_Border(cell.Borders[WdBorderType.wdBorderBottom]);
            this.wBorderLeft = new ABIW_Border(cell.Borders[WdBorderType.wdBorderLeft]);
            this.wBorderRight = new ABIW_Border(cell.Borders[WdBorderType.wdBorderRight]);
        }

        public Cell Cell { get => cell; set => cell = value; }
        internal ABIW_Border WBorderTop { get => wBorderTop; set => wBorderTop = value; }
        internal ABIW_Border WBorderBottom { get => wBorderBottom; set => wBorderBottom = value; }
        internal ABIW_Border WBorderLeft { get => wBorderLeft; set => wBorderLeft = value; }
        internal ABIW_Border WBorderRight { get => wBorderRight; set => wBorderRight = value; }

        // Compare 2 cells by its attributes and borders.
        public IComparisonResult Compare(object other)
        {
            if (other is ABIW_Cell otherCell)
            {
                if (CompareCellAttributes(this, otherCell).Result == ComparisonResultIndicate.equal
                    && CompareCellBorders(this, otherCell).Result == ComparisonResultIndicate.equal)
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else
                    return new ComparisonResult(ComparisonResultIndicate.not_equal);
                throw new NotImplementedException();
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }

        // Compare attributes of 2 cells
        public static IComparisonResult CompareCellAttributes(ABIW_Cell wcell1, ABIW_Cell wcell2)
        {
            if (wcell1.cell.Shading.ForegroundPatternColor == wcell2.cell.Shading.ForegroundPatternColor
                    && wcell1.cell.Shading.ForegroundPatternColorIndex == wcell2.cell.Shading.ForegroundPatternColorIndex
                    && wcell1.cell.Shading.BackgroundPatternColor == wcell2.cell.Shading.BackgroundPatternColor
                    && wcell1.cell.Shading.BackgroundPatternColorIndex == wcell2.cell.Shading.BackgroundPatternColorIndex
                    && wcell1.cell.Width == wcell2.cell.Width
                    && wcell1.cell.Height == wcell2.cell.Height
                    && wcell1.cell.RightPadding == wcell2.cell.RightPadding
                    && wcell1.cell.LeftPadding == wcell2.cell.LeftPadding)
            {
                return new ComparisonResult(ComparisonResultIndicate.equal);
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }

        // Compare borders of 2 cells. Borders are top-border, bottom-border, right-border, left border.  
        public static IComparisonResult CompareCellBorders(ABIW_Cell wcell1, ABIW_Cell wcell2)
        {
                if (wcell1.wBorderTop.Compare(wcell2.wBorderTop).Result == ComparisonResultIndicate.equal
                    && wcell1.wBorderBottom.Compare(wcell2.wBorderBottom).Result == ComparisonResultIndicate.equal
                    && wcell1.wBorderRight.Compare(wcell2.wBorderRight).Result == ComparisonResultIndicate.equal
                    && wcell1.wBorderLeft.Compare(wcell2.WBorderLeft).Result == ComparisonResultIndicate.equal)
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else
                    return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }
    }
}
