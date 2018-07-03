// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @vanduong
// created on 12:44 AM 2018/7/3
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ABI.Model.Word
{
    /// <summary>
    /// represent for a cell in a table
    /// </summary>
    class ABIW_Cell : IComparison
    {
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                if (this.CompareCellAttributes(otherCell).Result == ComparisonResultIndicate.equal
                    && this.CompareCellBorders(otherCell).Result == ComparisonResultIndicate.equal)
                {
                    string r3 = "OK";
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
        public IComparisonResult CompareCellAttributes(object other)
        {
            if (other is ABIW_Cell otherCell)
            {
                if (Cell.Shading.ForegroundPatternColor == otherCell.Cell.Shading.ForegroundPatternColor
                    && Cell.Shading.ForegroundPatternColorIndex == otherCell.Cell.Shading.ForegroundPatternColorIndex
                    && Cell.Shading.BackgroundPatternColor == otherCell.Cell.Shading.BackgroundPatternColor
                    && Cell.Shading.BackgroundPatternColorIndex == otherCell.Cell.Shading.BackgroundPatternColorIndex
                    && Cell.Width == otherCell.Cell.Width
                    && Cell.Height == otherCell.Cell.Height
                    && Cell.RightPadding == otherCell.Cell.RightPadding
                    && Cell.LeftPadding == otherCell.Cell.LeftPadding)
                {
                    string r1 = "OK"; 
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else
                    return new ComparisonResult(ComparisonResultIndicate.not_equal);
                throw new NotImplementedException();
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }

        // Compare borders of 2 cells. Borders are top-border, bottom-border, right-border, left border.  
        public IComparisonResult CompareCellBorders(object other)
        {
            if (other is ABIW_Cell otherCell)
            {   
                
                if (wBorderTop.Compare(otherCell.wBorderTop).Result == ComparisonResultIndicate.equal
                    && wBorderBottom.Compare(otherCell.wBorderBottom).Result == ComparisonResultIndicate.equal
                    && wBorderRight.Compare(otherCell.wBorderRight).Result == ComparisonResultIndicate.equal
                    && wBorderLeft.Compare(otherCell.WBorderLeft).Result == ComparisonResultIndicate.equal)
                {
                    string r2 = "OK";
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else
                    return new ComparisonResult(ComparisonResultIndicate.not_equal);
                throw new NotImplementedException();
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }
    }
}
