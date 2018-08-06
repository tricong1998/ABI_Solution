using ABI_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ABI_Server.Controllers
{
    //[Authorize]
    public class ExamController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [ResponseType(typeof(office_question))]
        public IEnumerable<QuestionDTO> GetExams(int examId)
        {
            var ctx = new abiexam_dbEntities();
            var query = from x in ctx.exam_question
                        join y in ctx.office_question on x.question_id equals y.id
                        join z in ctx.off_question_map_t2 on y.id equals z.question_id
                        where x.exam_id.Equals(examId)
                        group new { y, z } by new { z.question_id } into re
                        select new QuestionDTO
                        {
                            description = re.FirstOrDefault().y.description,
                            file_correct_answer = re.FirstOrDefault().y.file_correct_answer,
                            file_question = re.FirstOrDefault().y.file_question,
                            html_content = re.FirstOrDefault().y.html_content,
                            id = re.FirstOrDefault().y.id,
                            image = re.FirstOrDefault().y.image,
                            markdown_content = re.FirstOrDefault().y.markdown_content,
                            listTypeL2 = re.Select(m => m.z.type_l2_id).ToList(),
                            title = re.FirstOrDefault().y.title,
                        };
            return query.ToList();
        }
    }
}
