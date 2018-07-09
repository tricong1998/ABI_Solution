using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;


namespace ABI
{
    public class ABIW_TextRange : IComparison
    {
        private Range range;
        public ABIW_TextRange (Range range)
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
            if (other is ABIW_TextRange otherRange)
            {
                if (range.Text.Equals( otherRange.range.Text) )
                {
                    if (range.Paragraphs.Count == otherRange.range.Paragraphs.Count)
                    {
                        for (int j = 1; j <= range.Paragraphs.Count; j++)
                        {
                            ABIW_Paragraph paragraph1 = new ABIW_Paragraph(range.Paragraphs[j]);
                            ABIW_Paragraph paragraph2 = new ABIW_Paragraph(otherRange.range.Paragraphs[j]);
                            if (paragraph1.Compare(paragraph2).Result == ComparisonResultIndicate.not_equal)
                            {
                                return new ComparisonResult(ComparisonResultIndicate.not_equal);
                            }
                            else
                            {
                                List<Range> customRangesCorrect = classifyRange2(range.Parent, paragraph1.Paragraph.Range);
                                List<Range> customRangesAnswer = classifyRange2(otherRange.range.Parent, paragraph2.Paragraph.Range);
                                if (customRangesCorrect.Count() == customRangesAnswer.Count())
                                {
                                    for (int k = 0; k < customRangesCorrect.Count(); k++)
                                    {
                                        ABIW_Font font1 = new ABIW_Font(customRangesCorrect[k].Font);
                                        ABIW_Font font2 = new ABIW_Font(customRangesAnswer[k].Font);
                                        ABIW_Borders borders1 = new ABIW_Borders(customRangesCorrect[k].Borders);
                                        ABIW_Borders borders2 = new ABIW_Borders(customRangesAnswer[k].Borders);
                                        if (font1.Compare(font2).Result == ComparisonResultIndicate.not_equal
                                            //|| borders1.Compare(borders2).Result == ComparisonResultIndicate.not_equal
                                            )
                                        {
                                            return new ComparisonResult(ComparisonResultIndicate.not_equal);
                                        }
                                    }
                                    return new ComparisonResult(ComparisonResultIndicate.equal);
                                }
                                else
                                {
                                    return new ComparisonResult(ComparisonResultIndicate.not_equal);
                                }
                            }
                        }
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
            else
            {
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            throw new NotImplementedException();
        }
        public bool checkRange(Range range)
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
        public List<Range> classifyRange2(Document document, Range range)
        {
            List<Range> customRanges = new List<Range>();
            int end = range.End;
            int m = (int)Math.Sqrt((double)(range.End - range.Start));
            int n = m;
            Range customRange = document.Range();
            customRanges.Add(customRange);
            customRange.Start = range.Start;
            customRange.End = customRange.Start + n;
            //int n = m;
            while (customRanges[customRanges.Count - 1].End < end)
            {
                Range last = customRanges[customRanges.Count - 1];
                if (checkRange(last))
                {
                    while ((customRanges[customRanges.Count - 1].End + n) >= end && n > 1)
                    {
                        n = (int)(n / 2);
                    }
                    customRanges[customRanges.Count - 1].End = customRanges[customRanges.Count - 1].End + n;
                }
                else
                {
                    if (n == 1)
                    {
                        customRanges[customRanges.Count - 1].End--;
                        customRanges.Add(document.Range());
                        customRanges[customRanges.Count - 1].Start = customRanges[customRanges.Count - 2].End;
                        n = m;
                        if (customRanges[customRanges.Count - 1].Start + n >= end)
                        {
                            if ((end - customRanges[customRanges.Count - 1].Start) == 1)
                            {
                                n = 1;
                            }
                            else
                            {
                                n = end - customRanges[customRanges.Count - 1].Start - 1;
                            }
                        }
                        customRanges[customRanges.Count - 1].End = customRanges[customRanges.Count - 1].Start + n;
                    }
                    else
                    {
                        n = (int)n / 2;
                        customRanges[customRanges.Count - 1].End = customRanges[customRanges.Count - 1].End - (m - n);
                    }
                }

            }
            customRanges[customRanges.Count - 1].End--;
            return customRanges;
        }
    }
}
