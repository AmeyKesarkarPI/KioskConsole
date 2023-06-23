using Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicesApi.Controllers
{
    public class CounterController : ApiController
    {
        BranchDb bdb = new BranchDb();

        public string Post([FromBody] Counter counter)
        {
            bdb.InsertCounter(counter);
            return "Counter Inserted";
        }
    }
}
