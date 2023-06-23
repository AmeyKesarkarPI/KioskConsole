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
    public class ServedController : ApiController
    {
        CustomerDb cdb = new CustomerDb();
        //List<Customer> customers = new List<Customer>();
        CommonResponseDTO<string> responseDTO = new CommonResponseDTO<string>();
        //public string Get()
        //{
        //    return "value";
        //}

        // GET api/values/5

        public CommonResponseDTO<string> Post([FromBody] Customer customer)
        {
            responseDTO.Data =  cdb.CustomerServed(customer);;
            responseDTO.Success = true;
            responseDTO.Message = "Customer Status Updated";
            return responseDTO;
        }
    }
}
