// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 9:54 AM 2018/7/11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI_DCH.Common
{
    public class AbstractAnswer : IAnswer
    {
        protected IFile file;

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
    }
}
