// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 4:24 PM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    /// <summary>
    /// question
    /// </summary>
    public abstract class AbstractQuestion : IQuestion
    {
        protected string rawContent;

        public string RawContent
        {
            get
            {
                return rawContent;
            }

            set
            {
                rawContent = value;
            }
        }

        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }
        public int Type_l2
        {
            get
            {
                return type_l2;
            }

            set
            {
                type_l2 = value;
            }
        }

        public string HtmlContent
        {
            get
            {
                return htmlContent;
            }

            set
            {
                htmlContent = value;
            }
        }

        public string MarkdownContent
        {
            get
            {
                return markdownContent;
            }

            set
            {
                markdownContent = value;
            }
        }

        public IFile File
        {
            get
            {
                return file;
            }

            set
            {
                file = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        protected int index;
        protected int type_l2;
        protected string htmlContent;
        protected string markdownContent;
        protected IFile file;
        protected string description;
        public abstract IResult Submit(IAnswer answer);
    }
}
