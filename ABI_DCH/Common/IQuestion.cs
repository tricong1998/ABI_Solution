// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 4:01 PM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI_DCH.Common
{
    /// <summary>
    /// all types of questions need to be implemented this interface
    /// </summary>
    public interface IQuestion
    {
        //string Question { get; set ; }
        //string Answer { get ; set ; }
        IResult Submit(IAnswer answer);
        int Index { get; set; }
        string RawContent { get; set; }
        string MarkdownContent { get; set; }
        string HtmlContent { get; set; }
        int Type_l2 { get; set; }
        IFile File { get; set; }
        string Description { get; set; }
        //bool Correct { get; set; }
    }
}
