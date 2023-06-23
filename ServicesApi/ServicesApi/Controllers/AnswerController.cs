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
    public class AnswerController : ApiController
    {
        AnswerDb adb = new AnswerDb();
        List<Answer> answers = new List<Answer>();
        Token token = new Token();
        CommonResponseDTO<Token> responseDTO = new CommonResponseDTO<Token>();


        public CommonResponseDTO<Token> Post([FromBody] Answer ans)
        {
            answers.Add(ans);
            token = adb.InsertAnswer(ans);
            responseDTO.Data = token;
            responseDTO.Success = true;
            responseDTO.Message = "Answers Inserted";
            return responseDTO;
        }
        public CommonResponseDTO<Token> Put([FromBody] Answer ans)
        {
            answers.Add(ans);
            token = adb.InsertAnswer(ans);
            responseDTO.Data = token;
            responseDTO.Success = true;
            responseDTO.Message = "Answers Inserted";
            return responseDTO;
        }
    }
}
