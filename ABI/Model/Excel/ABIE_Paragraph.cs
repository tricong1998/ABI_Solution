// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @phamvhoang
// created on 12:15 PM 2018/7/6

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
namespace ABI.Model.Excel
{
    public class ABIE_Paragraph : IComparison
    {
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private PageSetup pageSetup;
        public ABIE_Paragraph(PageSetup pageSetup)
        {
            this.PageSetup = pageSetup;
        }

        public PageSetup PageSetup { get => pageSetup; set => pageSetup = value; }

        public IComparisonResult Compare(object other)
        {
            if (other is ABIE_Paragraph otherPageSetup)
            {
                if (pageSetup.TopMargin == otherPageSetup.pageSetup.TopMargin
                    && pageSetup.LeftMargin == otherPageSetup.pageSetup.LeftMargin
                    && pageSetup.BottomMargin == otherPageSetup.pageSetup.BottomMargin
                    && pageSetup.RightMargin == otherPageSetup.pageSetup.RightMargin
                    && pageSetup.HeaderMargin == otherPageSetup.pageSetup.HeaderMargin
                    && pageSetup.FooterMargin == otherPageSetup.pageSetup.FooterMargin
                    && pageSetup.LeftHeader == otherPageSetup.pageSetup.LeftHeader
                    && pageSetup.CenterFooter == otherPageSetup.pageSetup.CenterFooter)
                {
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            else return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }
    }
}
