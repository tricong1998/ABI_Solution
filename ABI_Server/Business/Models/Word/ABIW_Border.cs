// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @vanduong
// created on 12:44 AM 2018/7/3
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
    /// represent for a border of an object
    /// </summary>
    class ABIW_Border : IComparison
    {
        private Border border;

        public ABIW_Border(Border border)
        {
            this.border = border;
        }

        public Border Border
        {
            get
            {
                return border;
            }

            set
            {
                 border = value;
            }
        }

        public IComparisonResult Compare(object other)
        {
            if (other is ABIW_Border otherBorder)
            {
                CompareObject compareObject = new CompareObject();
                if (compareObject.compareTwoObject( border.LineStyle , otherBorder.Border.LineStyle)
                    && compareObject.compareTwoObject(border.LineWidth , otherBorder.Border.LineWidth)
                    && compareObject.compareTwoObject(border.Color , otherBorder.Border.Color)
                    && compareObject.compareTwoObject(border.ColorIndex , otherBorder.Border.ColorIndex)
                    && compareObject.compareTwoObject(border.Visible , otherBorder.Border.Visible)
                    )
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else
                    return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }
    }
}
