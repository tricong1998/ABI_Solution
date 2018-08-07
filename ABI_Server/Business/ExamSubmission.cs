using ABI_DCH.Common;
using ABI_DCH.Word;
using ABI_Server.Business.Comparison;
using ABI_Server.Business.Models.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Word = Microsoft.Office.Interop.Word;


namespace ABI_Server.Business
{
    public class ExamSubmission
    {
        public void SubmitAll(ABIExam exam)
        {
            exam.Score.Score = 0;
            foreach (IQAPair pair in exam.QAPairs)
            {
                IQuestion question = pair.Question;
                if (question is OpenWFileQuestion)
                {
                    // call to OpenWFile.CheckOpened(question.file_to_open);
                }
                if (question is CompareWFileQuestion questionCur)
                {
                    Word.Application application = new Word.Application();
                    Word.Document anwser = application.Documents.Open(questionCur.File.Path);
                    Word.Document correctAnwser = application.Documents.Open(pair.CorrectAnswer.File.Path);
                    ABIW_Document document1 = new ABIW_Document(anwser);
                    ABIW_Document document2 = new ABIW_Document(correctAnwser);
                    switch (questionCur.Type_l2)
                    {
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                            CompareWFont compare = new CompareWFont();
                            pair.Result = compare.Compare(document1, document2);
                            if (pair.Result is ComparisonResult comparisonResult)
                                if (comparisonResult.Result == ComparisonResultIndicate.equal)
                                    exam.Score.Score++;
                            break;
                            //case 16 : case 17 : case 18 :  case 19 : case 21:
                    }
                    // call to CompareWFont.Compare()
                }
            }
            // implement total result here
            //MessageBox.Show("Score: " + exam.Score.Score);
        }
    }
}