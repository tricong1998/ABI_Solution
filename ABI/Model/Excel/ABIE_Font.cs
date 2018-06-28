// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 12:15 PM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace ABI
{
    // represent for Excel font
    public class ABIE_Font : IComparison
    {
        private Font font;

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
            if (other is ABIE_Font otherFont)
            {
                // implement your algorithm here
                // and replace the below exception with a return statement
                throw new NotImplementedException();
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }
    }
}
