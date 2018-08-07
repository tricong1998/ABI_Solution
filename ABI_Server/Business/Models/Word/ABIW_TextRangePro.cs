using ABI_DCH.Common;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI_Server.Business.Models.Word
{
    public class ABIW_TextRangePro : IComparison
    {
        private Range range;

        public ABIW_TextRangePro(Range range)
        {
            this.range = range;
        }

        public Range Range
        {
            get
            {
                return range;
            }
            set
            {
                range = value;
            }
        }



        public IComparisonResult Compare(object other)
        {
            if (other is ABIW_TextRangePro oTextRange)
            {
                if (checkEqualText(this.range, oTextRange.range))
                {
                    if (checkTwoParagraphs(this.range.Paragraphs, oTextRange.range.Paragraphs))
                    {
                        return new ComparisonResult(ComparisonResultIndicate.equal);
                    }
                    else
                        return new ComparisonResult(ComparisonResultIndicate.not_equal);
                }
                else
                    return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }

        public class StartEnd
        {
            public int start;
            public int end;
            public StartEnd(int s, int e)
            {
                this.start = s;
                this.end = e;
            }
        }

        public bool checkEqualText(Range range1, Range range2)
        {
            if (range1.Text.Equals(range2.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool checkTwoParagraphs(Paragraphs pg1 , Paragraphs pg2)
        {
            if (pg1.Count == pg2.Count)
            {
                for (int i=1; i <= pg1.Count; i++)
                {
                    ABIW_Paragraph para1 = new ABIW_Paragraph(pg1[i]);
                    ABIW_Paragraph para2 = new ABIW_Paragraph(pg2[i]);
                    if (para1.Compare(para2).Result == ComparisonResultIndicate.equal)
                    {
                        if (CompareTextRange(para1.Paragraph.Range, para2.Paragraph.Range))
                        {
                            continue;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                return true;
            }
            else
                return false;
        }

        public static bool CompareTextRange(Range ran1, Range ran2)
        {
            List<StartEnd> startEnds1 = new List<StartEnd>();
            List<StartEnd> startEnds2 = new List<StartEnd>();
            StartEnd oriStartEnd1 = new StartEnd(ran1.Start, ran1.End);
            StartEnd oriStartEnd2 = new StartEnd(ran2.Start, ran2.End);

            classifyRange(ran1, ran1.Start, ran1.End, startEnds1);
            classifyRange(ran2, ran2.Start, ran2.End, startEnds2);

            if (startEnds1.Count == startEnds2.Count)
            {
                for (int i = 0; i < startEnds1.Count; i++)
                {
                    if (startEnds1[i].start == startEnds2[i].start && startEnds1[i].end == startEnds2[i].end)
                    {
                        ran1.Start = startEnds1[i].start;
                        ran1.End = startEnds1[i].end;
                        ran2.Start = startEnds2[i].start;
                        ran2.End = startEnds2[i].end;
                        ABIW_Font font1 = new ABIW_Font(ran1.Font);
                        ABIW_Font font2 = new ABIW_Font(ran2.Font);
                        if (font1.Compare(font2).Result == ComparisonResultIndicate.equal)
                        {
                            ran1.Start = oriStartEnd1.start;
                            ran1.End = oriStartEnd1.end;
                            ran2.Start = oriStartEnd2.start;
                            ran2.End = oriStartEnd2.end;
                            continue;
                        }
                        else return false;
                    }
                    else return false;
                }
                return true;
            }
            else
                return false;
        }

        public static void classifyRange(Range range, int start, int end, List<StartEnd> startEnds)
        {
            Range customRange = range;
            customRange.Start = start;
            customRange.End = end;
            int threshold = (int)((end - start) / 2);
            if (checkRange(customRange))
            {
                StartEnd se = new StartEnd(start, end);
                startEnds.Add(se);
                return;
            }
            else
            {
                classifyRange(range, start, start + threshold, startEnds);
                classifyRange(range, start + threshold, end, startEnds);
                return;
            }
        }

        public static bool checkRange(Range range)
        {
            int valueFalse = 9999999;
            if (!range.Font.Name.ToString().Trim().Equals("")
                    && range.Font.Bold != valueFalse
                    && range.Font.Italic != valueFalse
                    && range.Font.Size != valueFalse
                    && (int)range.Underline != valueFalse
                    && range.Font.StrikeThrough != valueFalse
                    && (int)range.Font.Color != valueFalse
                    && (int)range.Font.UnderlineColor != valueFalse
                    && range.Font.Glow.Radius != valueFalse
                    && range.Font.Reflection.Size != valueFalse
                    && range.Font.TextShadow.Size != valueFalse
                    && range.Font.Outline != valueFalse
                    && (int)range.Font.StylisticSet != valueFalse
                    && (int)range.Font.Ligatures != valueFalse
                    //&& range.Borders.DistanceFromBottom != valueFalse
                    //&& range.Borders.DistanceFromLeft != valueFalse
                    //&& range.Borders.DistanceFromRight != valueFalse
                    //&& range.Borders.DistanceFromTop != valueFalse
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
