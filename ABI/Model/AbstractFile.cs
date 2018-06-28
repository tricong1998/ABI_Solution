// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 4:47 PM 2018/6/15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    public abstract class AbstractFile : IFile
    {
        protected string path;

        public string Path { get => path; set => path = value; }
    }
}
