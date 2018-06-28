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
            throw new NotImplementedException();
        }
    }
}
