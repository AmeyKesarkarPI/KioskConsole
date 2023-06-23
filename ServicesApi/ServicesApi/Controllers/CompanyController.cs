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
    public class CompanyController : ApiController
    {
        BranchDb bdb = new BranchDb();

        CommonResponseDTO<Company> responseDTO = new CommonResponseDTO<Company>();

        public CommonResponseDTO<Company> Post([FromBody] Company company)
        {
            bdb.InsertCompany(company);
            responseDTO.Success = true;
            responseDTO.Message = "Company Inserted";
            return responseDTO;
        }
    }
}
