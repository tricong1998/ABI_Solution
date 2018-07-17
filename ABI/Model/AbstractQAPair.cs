// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 4:58 PM 2018/7/11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    public abstract class AbstractQAPair : IQAPair
    {
        protected IQuestion question;
        protected IAnswer answer;

        public IAnswer Answer
        {
            get
            {
                return answer;
            }

            set
            {
                answer = value;
            }
        }

        public IQuestion Question
        {
            get
            {
                return question;
            }

            set
            {
                question = value;
            }
        }
    }
}
