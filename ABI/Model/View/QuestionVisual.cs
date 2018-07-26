// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 10:41 AM 2018/7/11
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    public class QuestionVisual
    {
        IQuestion question;

        public QuestionVisual(IQuestion question)
        {
            this.question = question;
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

        public string Name
        {
            get
            {
                return "Câu " + question.Index + "";
            }
        }

        private bool isSelected = false;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
            }
        }
    }
}
