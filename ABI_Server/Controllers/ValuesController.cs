using ABI_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ABI_Server.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public IEnumerable<office_question> Get(int examId)
        {
            var ctx = new abiexam_dbEntities();
            var query = from x in ctx.exam_question
                        join y in ctx.office_question on x.question_id equals y.id
                        where x.exam_id.Equals(examId)
                        select new office_question
                        {
                            active = y.active,
                            create_at = y.create_at,
                            description = y.description,
                            file_correct_answer = y.file_correct_answer,
                            file_question = y.file_question,
                            html_content = y.html_content,
                            id = y.id,
                            image = y.image,
                            markdown_content = y.markdown_content,
                            off_question_map_t2 = y.off_question_map_t2,
                            off_question_version = y.off_question_version,
                            title = y.title,
                            examinee_answer = new List<examinee_answer>(),
                            exam_question = new List<exam_question>(),
                            request = y.request
                        };
            return query;
        }

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        public HttpResponseMessage Post([FromBody]object p1)
        {
            return Request.CreateResponse(p1);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
