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
        private string title;

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public abstract IResult Submit(IAnswer answer);
    }
}
