// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 4:59 PM 2018/7/11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI_DCH.Common
{
    public class ABIQAPair : AbstractQAPair
    {
        public ABIQAPair() { }

        public ABIQAPair(IQuestion question, IAnswer answer) : this()
        {
            this.question = question;
            this.answer = answer;
        }

        public ABIQAPair(IQuestion question, IAnswer answer, IAnswer correctAnswer) : this(question, answer)
        {
            this.CorrectAnswer = correctAnswer;
        }
    }
}
