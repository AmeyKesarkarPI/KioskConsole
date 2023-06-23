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
    public class AdminDb
    {
        public int AdminLogin(Admin admin)
        {
            int count = 0;
            string constr = @"Data Source = PC-227\SQL2016EXPRESS; Initial Catalog = Northwind; User ID = sagar; Password = aa";
            string sql = $"EXEC KioskAdminLogin  '{admin.AdminName}','{admin.Password}'";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = constr;
                conn.Open();
                count = conn.Query<int>(sql).FirstOrDefault();
            }

            return count;
        }
    }
}
