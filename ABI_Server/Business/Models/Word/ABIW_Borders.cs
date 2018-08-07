using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI_DCH.Common;
using Microsoft.Office.Interop.Word;

namespace ABI_Server.Business.Models.Word
{
    class ABIW_Borders
    {
        private Borders borders;
        private ABIW_Border wBorderTop;
        private ABIW_Border wBorderBottom;
        private ABIW_Border wBorderLeft;
        private ABIW_Border wBorderRight;

        public ABIW_Borders(Borders borders)
        {
            this.borders = borders;
            this.wBorderTop = new ABIW_Border(borders[WdBorderType.wdBorderTop]);
            this.wBorderBottom = new ABIW_Border(borders[WdBorderType.wdBorderBottom]);
            this.wBorderLeft = new ABIW_Border(borders[WdBorderType.wdBorderLeft]);
            this.wBorderRight = new ABIW_Border(borders[WdBorderType.wdBorderRight]);
        }

        public Borders Borders { get => borders; set => borders = value; }
        internal ABIW_Border WBorderTop { get => wBorderTop; set => wBorderTop = value; }
        internal ABIW_Border WBorderBottom { get => wBorderBottom; set => wBorderBottom = value; }
        internal ABIW_Border WBorderLeft { get => wBorderLeft; set => wBorderLeft = value; }
        internal ABIW_Border WBorderRight { get => wBorderRight; set => wBorderRight = value; }
        

        public IComparisonResult Compare(object other)
        {
            if(other is ABIW_Borders otherBorders)
            {
                if(wBorderTop.Compare(otherBorders.wBorderTop).Result == ComparisonResultIndicate.equal
                    && wBorderBottom.Compare(otherBorders.wBorderBottom).Result == ComparisonResultIndicate.equal
                    && wBorderRight.Compare(otherBorders.wBorderRight).Result == ComparisonResultIndicate.equal
                    && wBorderLeft.Compare(otherBorders.WBorderLeft).Result == ComparisonResultIndicate.equal
                    )
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else
                {
                    return new ComparisonResult(ComparisonResultIndicate.not_equal);
                }
            }
            else
            {
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
        }
    }
}
