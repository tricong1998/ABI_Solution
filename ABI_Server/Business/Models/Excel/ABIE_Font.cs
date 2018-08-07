// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 12:15 PM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI_DCH.Common;
using Microsoft.Office.Interop.Excel;

namespace ABI_Server.Business.Models.Excel
{
    // represent for Excel font
    public class ABIE_Font : IComparison
    {
        private Font font;

        public Font Font { get => font; set => font = value; }

        public IComparisonResult Compare(object other)
        {
            if (other is ABIE_Font otherFont)
            {
                if (font.Size == otherFont.font.Size
                    && font.Background == otherFont.font.Background
                    && font.Bold == otherFont.font.Bold
                    && font.Color == otherFont.font.Color
                    && font.Italic == otherFont.font.Italic
                    && font.Underline == otherFont.font.Underline
                    && font.FontStyle == otherFont.font.FontStyle
                    && font.Strikethrough == otherFont.font.Strikethrough
                    && font.Shadow == otherFont.font.Shadow
                    && font.ThemeColor == otherFont.font.ThemeColor
                    && font.TintAndShade == otherFont.font.TintAndShade
                    && font.OutlineFont == otherFont.font.OutlineFont)
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            throw new NotImplementedException();
        }
    }
}
