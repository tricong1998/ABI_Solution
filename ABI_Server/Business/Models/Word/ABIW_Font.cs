// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 11:57 AM 2018/6/26
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
    /// <summary>
    /// represent for word font
    /// </summary>
    public class ABIW_Font : IComparison
    {
        private Font font;
        public ABIW_Font( Font font)
        {
            this.font = font;
        }
        public Font Font
        {
            get
            {
                return font;
            }

            set
            {
                font = value;
            }
        }

        public IComparisonResult Compare(object other)
        {
            if (other is ABIW_Font otherFont)
            {
                if( checkEqualFont(font, otherFont.font))
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
            throw new NotImplementedException();
        }
        public bool checkEqualFont(Font font1, Font font2)
        {
            CompareObject compareObject = new CompareObject();
            if (compareObject.compareTwoObject( font1.Bold , font2.Bold)
                && compareObject.compareTwoObject(font1.Italic , font2.Italic)
                && compareObject.compareTwoObject(font1.Size , font2.Size)
                && compareObject.compareTwoObject(font1.Name, font2.Name)
                && compareObject.compareTwoObject(font1.Color , font2.Color)
                && compareObject.compareTwoObject(font1.StrikeThrough, font2.StrikeThrough)
                && compareObject.compareTwoObject(font1.UnderlineColor , font2.UnderlineColor)
                && compareObject.compareTwoObject(font1.Underline , font2.Underline)
                && compareObject.compareTwoObject(font1.Parent.HighlightColorIndex , font2.Parent.HighlightColorIndex)
                //&& checkTextEffect(range1, range2)
               )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool compareTwoObject(object o1, object o2)
        {
            if (o1 != null && o2 != null)
            {
                if (o1.Equals(o2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (o1 == null && o2 == null)
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
