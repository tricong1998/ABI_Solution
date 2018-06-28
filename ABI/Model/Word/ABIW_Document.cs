// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 11:59 AM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ABI
{
    /// <summary>
    /// represent for a word document
    /// </summary>
    public class ABIW_Document : IComparison
    {
        private Document document;

        public ABIW_Document(Document document)
        {
            this.document = document;
        }

        public Document Document
        {
            get
            {
                return document;
            }

            set
            {
                document = value;
            }
        }

        public IComparisonResult Compare(object other)
        {
            throw new NotImplementedException();
        }
    }
}
