using Database;
using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;

namespace ServicesApi.Controllers
{
    public class KioskController : ApiController
    {
        ServicesDb sdb = new ServicesDb();
        List<Service> services = new List<Service>();
        CommonResponseDTO<List<Service>> responseDTO = new CommonResponseDTO<List<Service>>();
   

        public CommonResponseDTO<List<Service>> Get(int id)
        {
            services = sdb.GetServices(id);
            responseDTO.Data = services;
            responseDTO.Success = true;
            responseDTO.Message = "Task Completed.";
            return responseDTO;
        }

        public CommonResponseDTO<List<Service>> Post([FromBody] Service service)
        {
            sdb.InsertNewServices(service);
            responseDTO.Success = true;
            responseDTO.Message = "Service Inserted";
            return responseDTO;
        }

    }

}
