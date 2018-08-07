// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 10:56 AM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI_DCH.Common;
using ABI_DCH.Utils;
using Microsoft.Office.Interop.Word;

namespace ABI_Server.Business.Models.Word
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
            ABIW_Borders borders1 = new ABIW_Borders(paragraph1.Borders);
            ABIW_Borders borders2 = new ABIW_Borders(paragraph2.Borders);
            CompareObject compareObject = new CompareObject();
            if (compareObject.compareTwoObject(paragraph1.Alignment , paragraph2.Alignment)
                && compareObject.compareTwoObject(paragraph1.LeftIndent , paragraph2.LeftIndent)
                && compareObject.compareTwoObject(paragraph1.RightIndent , paragraph2.RightIndent)
                && compareObject.compareTwoObject(paragraph1.FirstLineIndent , paragraph2.FirstLineIndent)
                && compareObject.compareTwoObject(paragraph1.MirrorIndents , paragraph2.MirrorIndents)
                && compareObject.compareTwoObject(paragraph1.LineSpacingRule , paragraph2.LineSpacingRule)
                && compareObject.compareTwoObject(paragraph1.SpaceAfter , paragraph2.SpaceAfter)
                && compareObject.compareTwoObject(paragraph1.SpaceBefore , paragraph2.SpaceBefore)
                && compareObject.compareTwoObject(paragraph1.LineSpacing , paragraph2.LineSpacing)
                && borders1.Compare(borders2).Result == ComparisonResultIndicate.equal
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