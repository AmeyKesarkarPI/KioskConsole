using Dapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AgentDb
    {
        public int AgentLogin(Agent agent)
        {
            int count = 0;
            string constr = @"Data Source = PC-227\SQL2016EXPRESS; Initial Catalog = Northwind; User ID = sagar; Password = aa";
            string sql = $"EXEC KioskAgentLogin  '{agent.AgentName}','{agent.Password}'";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = constr;
                conn.Open();
                count = conn.Query<int>(sql).FirstOrDefault() ;
            }

            return count;
        }
    }
}
