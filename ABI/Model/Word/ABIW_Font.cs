// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 11:57 AM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ABI
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
            if (font1.Bold == font2.Bold
                && font1.Italic == font2.Italic
                && font1.Size == font2.Size
                && font1.Name.ToString() == font2.Name.ToString()
                && font1.Color == font2.Color
                && font1.StrikeThrough == font2.StrikeThrough
                && font1.UnderlineColor == font2.UnderlineColor
                && font1.Underline == font2.Underline                
                && font1.Parent.HighlightColorIndex == font2.Parent.HighlightColorIndex
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
    }
}
