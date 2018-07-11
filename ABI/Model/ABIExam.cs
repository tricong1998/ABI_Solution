// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 10:07 AM 2018/7/11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    public class ABIExam : IExam
    {
        protected List<IQAPair> _QAPairs;

        public List<IQAPair> QAPairs
        {
            get
            {
                return _QAPairs;
            }

            set
            {
                _QAPairs = value;
            }
        }
    }
}
