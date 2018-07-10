// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @vanduong
// created on 14:44 AM 2018/7/4
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ABI
{
    /// <summary>
    /// represent foot note of a object as : range, ...
    /// </summary>
    public class ABIW_FootNotes : IComparison
    {
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Footnotes footnotes;
        private Range rangeParent;
        private FootnoteOptions footnoteOptions;

        public ABIW_FootNotes(Footnotes footnotes)
        {
            this.footnotes = footnotes;
            this.rangeParent = footnotes.Parent;
            this.footnoteOptions = rangeParent.FootnoteOptions;
        }

        public Footnotes Footnotes { get => footnotes; set => footnotes = value; }
        public FootnoteOptions FootnoteOptions { get => footnoteOptions; set => footnoteOptions = value; }
        public Range RangeParent { get => rangeParent; set => rangeParent = value; }

        public IComparisonResult Compare(object other)
        {
            if (other is ABIW_FootNotes otherFootNotes)
            {
                if (this.CompareFootnoteRanges(otherFootNotes).Result == ComparisonResultIndicate.equal
                    && this.CompareFootnoteOptions(otherFootNotes.FootnoteOptions).Result == ComparisonResultIndicate.equal)
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }

        public IComparisonResult CompareFootnoteRanges(ABIW_FootNotes otherFootnotes)
        {
            if (this.footnotes.Count == otherFootnotes.footnotes.Count)
            {
                for (int i = 1; i <= this.footnotes.Count; i++)
                {
                    Footnote footnote = this.footnotes[i];
                    Footnote otherFootnote = otherFootnotes.footnotes[i];
                    ABIW_TextRange footnoteRange = new ABIW_TextRange(footnote.Range);
                    ABIW_TextRange oFootnoteRange = new ABIW_TextRange(otherFootnote.Range);

                    if (footnoteRange.Compare(oFootnoteRange).Result == ComparisonResultIndicate.equal)
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

    public IComparisonResult CompareFootnoteOptions(FootnoteOptions otherFootnoteOptions)
    {
        CompareObject compareObject = new CompareObject();
        if (compareObject.compareTwoObject(this.FootnoteOptions.LayoutColumns, otherFootnoteOptions.LayoutColumns)
            && compareObject.compareTwoObject(this.FootnoteOptions.Location, otherFootnoteOptions.Location)
            && compareObject.compareTwoObject(this.FootnoteOptions.NumberStyle, otherFootnoteOptions.NumberStyle)
            && compareObject.compareTwoObject(this.FootnoteOptions.NumberingRule, otherFootnoteOptions.NumberingRule)
            && compareObject.compareTwoObject(this.FootnoteOptions.StartingNumber, otherFootnoteOptions.StartingNumber)
            )
        {
            return new ComparisonResult(ComparisonResultIndicate.equal);
        }
        else
            return new ComparisonResult(ComparisonResultIndicate.not_equal);
    }

}
}
