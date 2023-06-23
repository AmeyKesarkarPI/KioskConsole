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

    public class BranchController : ApiController
    {

        BranchDb bdb = new BranchDb();

        public CommonResponseDTO<Branch> Post([FromBody] Branch branch)
        {
            CommonResponseDTO<Branch> commonResponseDTO = new CommonResponseDTO<Branch>();
            bdb.InsertNewBranch(branch);
            commonResponseDTO.Message = "Branch Inserted";
            commonResponseDTO.Success = true;

            return commonResponseDTO;
        }

        public CommonResponseDTO<ServiceBranch> get(int id)
        {
            CommonResponseDTO<ServiceBranch> commonResponseDTO = new CommonResponseDTO<ServiceBranch>();
            commonResponseDTO.Message = "Success";
            commonResponseDTO.Success = true;
            commonResponseDTO.Data= bdb.GetBranch(id);

            return commonResponseDTO;
        }
    }
}
