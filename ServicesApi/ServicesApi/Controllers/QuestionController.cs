using Database;
using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicesApi.Controllers
{
    public class QuestionController : ApiController
    {
        QuestionsDb qdb = new QuestionsDb();
        List<Questions> questions = new List<Questions>();
        CommonResponseDTO<List<Questions>> responseDTO = new CommonResponseDTO<List<Questions>>();

        //public string Get()
        //{
        //    return "value";
        //}

        //// GET api/values/5

        public CommonResponseDTO<List<Questions>> Get(int id)
        {
            questions = qdb.GetQuestions(id);
            responseDTO.Data = questions;
            responseDTO.Success = true;
            responseDTO.Message = "Customer Served";
            return responseDTO;
        }

        public CommonResponseDTO<List<Questions>> Post([FromBody] Questions question)
        {
            questions.Add(question);
            qdb.InsertNewQuestion(question);

            responseDTO.Data = questions;
            responseDTO.Success = true;
            responseDTO.Message = "Questions Inserted";
            return responseDTO;
        }
    }
}
