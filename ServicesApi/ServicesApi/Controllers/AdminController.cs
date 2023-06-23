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
    public class AdminController : ApiController
    {
        AdminDb adb = new AdminDb();
        CommonResponseDTO<int> responseDTO = new CommonResponseDTO<int>();
        // GET: api/Admin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Admin
        public CommonResponseDTO<int> Post([FromBody]Admin admin)
        {
            int count = adb.AdminLogin(admin);
            responseDTO.Data = count;
            responseDTO.Success = true;
            responseDTO.Message = "Admin Login";
            return responseDTO;
        }

        // PUT: api/Admin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
        }
    }
}
