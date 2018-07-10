// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @phamvhoang
// created on 12:15 PM 2018/7/6

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
namespace ABI.Model.Excel
{
    /// <summary>
    /// represent for a border of an object
    /// </summary>
    class ABIE_Border : IComparison
    {
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Border border;
        public ABIE_Border(Border border)
        {
            this.Border = border;
        }

        public Border Border { get => border; set => border = value; }

        public IComparisonResult Compare(object other)
        {
            if (other is ABIE_Border otherBorder)
            {
                if (border.LineStyle == otherBorder.border.LineStyle
                    && border.Color == otherBorder.border.Color
                    && border.ColorIndex == otherBorder.border.ColorIndex
                    && border.ThemeColor == otherBorder.border.ThemeColor
                    && border.TintAndShade == otherBorder.border.TintAndShade)
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            else return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }
    }
}
