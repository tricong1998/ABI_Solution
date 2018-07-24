﻿// Copyright (c) 2018 fit.uet.vnu.edu.vn
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
        protected string textContent;

        public string TextContent
        {
            get
            {
                return textContent;
            }

            set
            {
                textContent = value;
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

        public string HtmlContent
        {
            get
            {
                return htmlsContent;
            }

            set
            {
                htmlsContent = value;
            }
        }

        public string Question { get => question; set => question = value; }
        public string Answer { get => answer; set => answer = value; }
        protected string question;
        protected string answer;
        protected int index;       
        public abstract IResult Submit(IAnswer answer);

        protected string htmlsContent;
    }
}
