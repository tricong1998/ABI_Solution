using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ABI
{
    public class ABIW_Section : IComparison
    {
        private Section section;

        public Section Section
        {
            get
            {
                return section;
            }

            set
            {
                section = value;
            }
        }
        public IComparisonResult Compare(object other)
        {
            if (other is ABIW_Section otherSec)
            {
                if (checkEqualPageSetup (section.Range.PageSetup, otherSec.section.Range.PageSetup))
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else
                {
                    return new ComparisonResult(ComparisonResultIndicate.not_equal);
                }
                    // compare $this vs $otherPara
                    // and replace the below exception with a return statement
                    throw new NotImplementedException();
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }
        public bool checkEqualPageSetup(PageSetup pageSetup1, PageSetup pageSetup2)
        {
            if (pageSetup1.LeftMargin == pageSetup2.LeftMargin
                && pageSetup1.RightMargin == pageSetup2.RightMargin
                && pageSetup1.BottomMargin == pageSetup2.BottomMargin
                && pageSetup1.TopMargin == pageSetup2.TopMargin
                && pageSetup1.PageHeight == pageSetup2.PageHeight
                && pageSetup1.PageWidth == pageSetup2.PageWidth
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
