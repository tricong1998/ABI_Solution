using ABI_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ABI_Server.Controllers
{
    public class PracticeTypeController : ApiController
    {
        public IHttpActionResult GetAllPracticeTypes()
        {
            List<practice_type> practice_types = new List<practice_type>();
            using (var ctx = new abiexam_dbEntities())
            {
                foreach(var p in ctx.practice_type.ToList())
                {
                    practice_types.Add(new practice_type()
                    {
                        id = p.id,
                        name = p.name,
                        create_at = p.create_at,
                        exam_practice_type = new List<exam_practice_type>(),
                        off_question_type_l1 = new List<off_question_type_l1>(),
                    });
                }
            }
            if (practice_types.Count == 0)
            {
                return NotFound();
            }
            return Ok(new { results = practice_types });
        }

        public IHttpActionResult GetPracticeType(int id)
        {
            using (var ctx = new abiexam_dbEntities())
            {
                var pra = ctx.practice_type.ToList().FirstOrDefault((p) => p.id == id);
                if (pra == null)
                    return NotFound();
                return Ok(new
                {
                    results = new practice_type()
                    {
                        id = pra.id,
                        name = pra.name,
                        create_at = pra.create_at,
                        exam_practice_type = new List<exam_practice_type>(),
                        off_question_type_l1 = new List<off_question_type_l1>(),
                    }
                });
            }
        }

        [HttpPost]
        //Get action methods of the previous section
        public HttpResponseMessage PostNewStudent([FromBody]string idStr)
        {
            int id = Int32.Parse(idStr);
            using (var ctx = new abiexam_dbEntities())
            {
                var pra = ctx.practice_type.ToList().FirstOrDefault((p) => p.id == id);
                if (pra == null)
                    return null;
                return Request.CreateResponse(new
                {
                    results = new practice_type()
                    {
                        id = pra.id,
                        name = pra.name,
                        create_at = pra.create_at,
                        exam_practice_type = new List<exam_practice_type>(),
                        off_question_type_l1 = new List<off_question_type_l1>(),
                    }
                });
            }
        }
    }
}
