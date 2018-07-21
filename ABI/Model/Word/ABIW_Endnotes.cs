using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    public class ABIW_Endnotes : IComparison
    {
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Endnotes endnotes;
        private Range rangeParent;
        private EndnoteOptions endnoteOptions;

        public ABIW_Endnotes(Endnotes endnotes)
        {
            this.Endnotes = endnotes;
            this.RangeParent = endnotes.Parent;
            this.EndnoteOptions = RangeParent.EndnoteOptions;
        }

        public Endnotes Endnotes { get => endnotes; set => endnotes = value; }
        public Range RangeParent { get => rangeParent; set => rangeParent = value; }
        public EndnoteOptions EndnoteOptions { get => endnoteOptions; set => endnoteOptions = value; }

        public IComparisonResult Compare(object other)
        {
            if (other is ABIW_Endnotes otherEndnotes)
            {
                if (this.CompareEndnoteRanges(otherEndnotes).Result == ComparisonResultIndicate.equal
                    && this.CompareEndnoteOptions(otherEndnotes.endnoteOptions).Result == ComparisonResultIndicate.equal)
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }

        public IComparisonResult CompareEndnoteRanges(ABIW_Endnotes otherEndnotes)
        {
            if (this.endnotes.Count == otherEndnotes.endnotes.Count)
            {
                for (int i = 1; i <= this.endnotes.Count; i++)
                {
                    Endnote endnote = this.endnotes[i];
                    Endnote otherEndnote = otherEndnotes.endnotes[i];
                    ABIW_TextRangePro endnoteRange = new ABIW_TextRangePro(endnote.Range);
                    ABIW_TextRangePro oEndnoteRange = new ABIW_TextRangePro(otherEndnote.Range);

                    if (endnoteRange.Compare(oEndnoteRange).Result == ComparisonResultIndicate.equal)
                    {
                        continue;
                    }
                    else
                        return new ComparisonResult(ComparisonResultIndicate.not_equal);
                }
                return new ComparisonResult(ComparisonResultIndicate.equal);
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }

        public IComparisonResult CompareEndnoteOptions(EndnoteOptions otherEndnoteOptions)
        {
            CompareObject compareObject = new CompareObject();
            if ( compareObject.compareTwoObject(this.endnoteOptions.Location, otherEndnoteOptions.Location)
                && compareObject.compareTwoObject(this.endnoteOptions.NumberStyle, otherEndnoteOptions.NumberStyle)
                && compareObject.compareTwoObject(this.endnoteOptions.NumberingRule, otherEndnoteOptions.NumberingRule)
                && compareObject.compareTwoObject(this.endnoteOptions.StartingNumber, otherEndnoteOptions.StartingNumber)
                )
            {
                return new ComparisonResult(ComparisonResultIndicate.equal);
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }
    }
}
