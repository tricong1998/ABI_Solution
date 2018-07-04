// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 10:56 AM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ABI
{
    public class ABIW_Paragraph : IComparison
    {
        private Paragraph paragraph;

        public ABIW_Paragraph(Paragraph paragraph)
        {
            this.paragraph = paragraph;
        }

        public Paragraph Paragraph
        {
            get
            {
                return paragraph;
            }

            set
            {
                paragraph = value;
            }
        }

        /// <summary>
        /// implement algorithm here
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public IComparisonResult Compare(object other)
        {
            if (other is ABIW_Paragraph otherPara)
            {
                if(checkEqualParagraph(paragraph, otherPara.paragraph))
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
        public bool checkEqualParagraph(Paragraph paragraph1,
            Paragraph paragraph2)
        {
            if (paragraph1.Alignment == paragraph2.Alignment
                && paragraph1.LeftIndent == paragraph2.LeftIndent
                && paragraph1.RightIndent == paragraph2.RightIndent
                && paragraph1.FirstLineIndent == paragraph2.FirstLineIndent
                && paragraph1.MirrorIndents == paragraph2.MirrorIndents
                && paragraph1.LineSpacingRule == paragraph2.LineSpacingRule
                && paragraph1.SpaceAfter == paragraph2.SpaceAfter
                && paragraph1.SpaceBefore == paragraph2.SpaceBefore
                && paragraph1.LineSpacing == paragraph2.LineSpacing
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