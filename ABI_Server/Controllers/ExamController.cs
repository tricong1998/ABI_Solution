﻿using ABI_Server.Business;
using ABI_Server.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ABI_Server.Controllers
{
    [Authorize]
    public class ExamController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [ResponseType(typeof(office_question))]
        public IEnumerable<QuestionDTO> Exams([FromBody] object _params)
        {
            JObject examOb = _params as JObject;
            JProperty first = examOb.First as JProperty;
            int examId = 1;
            if (first.Name.Equals("exam_id"))
                examId = Int32.Parse((first.Value as JValue).Value.ToString());
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
            //var zipQuestionsZipFilePath = from m in ctx.exams
            //                              where m.id.Equals(examId)
            //                              select m;
            //var l = zipQuestionsZipFilePath.ToList();
            //if (l[0].zip_files == null)
            //    new ExamInitial().PackageQuestions(query.ToList(), @"D:\temp\abi\");
            return query.ToList();
        }

        [HttpPost]
        [ActionName("questions")]
        public HttpResponseMessage Files([FromBody] ListQuestionDTO listQuestion)
        {
            // check zip_files field, if null, call to  new ExamInitial().PackageQuestions(query.ToList(), "path");
            // else return this field's value
            string workspace = Properties.Resource1.WORK_SPACE;
            string fileName = "exam_" + DateTime.Now.ToString("yyMMdd" + "_" + "hhMMss") + ".zip"; // output
            string filePath = Path.Combine(workspace, fileName); // output

            int examId = listQuestion.exam_id;
            var ctx = new abiexam_dbEntities();
            exam exam = ctx.exams.Where(i => i.id.Equals(examId)).FirstOrDefault();
            if (exam == null)
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            if (exam.zip_files == null)
            {
                using (var archive = ZipFile.Open(filePath, ZipArchiveMode.Create))
                {
                    foreach (var questionDto in listQuestion.questions)
                    {
                        string fpath = Path.Combine(workspace, questionDto.file_question);
                        archive.CreateEntryFromFile(fpath, Path.GetFileName(fpath));
                    }
                }
                //new ExamInitial().PackageQuestions(listQuestion.questions, filePath);
                // update db
                exam.zip_files = filePath;
                ctx.SaveChanges();
            }
            else
                filePath = exam.zip_files;
            var dataBytes = File.ReadAllBytes(filePath);
            var dataStream = new MemoryStream(dataBytes);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = fileName;
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }
    }
}
