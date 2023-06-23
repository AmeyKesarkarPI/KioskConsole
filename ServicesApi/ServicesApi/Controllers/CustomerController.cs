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
    public class CustomerController : ApiController
    {
        CustomerDb cdb = new CustomerDb();
        List<Customer> customers = new List<Customer>();
        CommonResponseDTO<List<Customer>> responseDTO = new CommonResponseDTO<List<Customer>>();

        public CommonResponseDTO<List<Customer>> Get(string Token, int id)
        {
            customers = cdb.GetCustomer(Token, id);
            responseDTO.Data = customers;
            responseDTO.Success = true;
            responseDTO.Message = "Task Completed.";
            return responseDTO;
        }

        public CommonResponseDTO<string>  Post([FromBody] Customer customer)
        {
            CommonResponseDTO<string> commonResponseDTO = new CommonResponseDTO<string>();
            commonResponseDTO.Message = "Customer Status Updated";
            commonResponseDTO.Data = cdb.StartServing(customer);
            return commonResponseDTO;
        }
    }
}
