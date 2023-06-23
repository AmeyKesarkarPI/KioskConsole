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
    public class AgentController : ApiController
    {
        AgentDb adb = new AgentDb();
        CommonResponseDTO<int> responseDTO = new CommonResponseDTO<int>();
        // GET: api/Agent/5

        public AgentController()
        {
            responseDTO.Success = false;
            responseDTO.Message = "Error Occurred!";
        }

        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Agent
        public CommonResponseDTO<int> Post([FromBody]Agent agent)
        {
            int count =  adb.AgentLogin(agent);
            responseDTO.Data = count;
            responseDTO.Success = true;
            responseDTO.Message = "Agent Login";
            return responseDTO;
        }

        // PUT: api/Agent/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Agent/5
        public void Delete(int id)
        {
        }
    }
}
