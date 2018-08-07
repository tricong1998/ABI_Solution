// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 10:07 AM 2018/7/11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ABI_DCH.Common
{
    public class ABIExam : IExam
    {
        protected List<IQAPair> _QAPairs;
        protected ScoreResult score;
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
        
        public ScoreResult Score { get => score; set => score = value; }

        public string ClientWorkspace
        {
            get
            {
                return clientWorkspace;
            }

            set
            {
                clientWorkspace = value;
            }
        }

        public Application WordApplication
        {
            get
            {
                return wordApplication;
            }

            set
            {
                wordApplication = value;
            }
        }

        public Dictionary<int, Document> MapIndexDocuments
        {
            get
            {
                return mapIndexDocuments;
            }

            set
            {
                mapIndexDocuments = value;
            }
        }

        protected string clientWorkspace;

        private Application wordApplication = null;

        private Dictionary<int, Document> mapIndexDocuments;
    }
}
