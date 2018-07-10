// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @vanduong
// created on 14:44 AM 2018/7/4
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ABI.Model.Word
{
    /// <summary>
    /// represent foot note of a object as : range, ...
    /// </summary>
    class ABIW_FootNotes : IComparison
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
        //public Footnote Footnote { get => footnote; set => footnote = value; }

        public IComparisonResult Compare(object other)
        {
            if (other is ABIW_FootNotes otherFootNotes)
            {
                if (this.CompareFootnotes(otherFootNotes).Result == ComparisonResultIndicate.equal
                    && this.CompareFootnoteOptions(otherFootNotes).Result == ComparisonResultIndicate.equal)
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }

        public IComparisonResult CompareFootnotes(object other)
        {
            if (other is ABIW_FootNotes otherFootNotes)
            {
                if (this.footnotes.Count == otherFootNotes.footnotes.Count)
                {
                    for (int i = 1; i <= this.footnotes.Count; i++)
                    {
                        Footnote footnote = this.footnotes[i];
                        Footnote otherFootnote = otherFootNotes.footnotes[i];
                        ABIW_Range footnoteRange = new ABIW_Range(footnote.Range);
                        ABIW_Range oFootnoteRange = new ABIW_Range(otherFootnote.Range);
                        
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
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }

        public IComparisonResult CompareFootnoteOptions(object other)
        {
            if (other is ABIW_FootNotes otherFootnotes)
            {

                if (this.footnoteOptions.LayoutColumns == otherFootnotes.footnoteOptions.LayoutColumns
                    && this.footnoteOptions.Location == otherFootnotes.footnoteOptions.Location
                    && this.footnoteOptions.NumberStyle == otherFootnotes.footnoteOptions.NumberStyle
                    && this.footnoteOptions.NumberingRule == otherFootnotes.footnoteOptions.NumberingRule
                    && this.footnoteOptions.StartingNumber == otherFootnotes.footnoteOptions.StartingNumber)
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else
                    return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            throw new NotImplementedException();
        }

    }
}
