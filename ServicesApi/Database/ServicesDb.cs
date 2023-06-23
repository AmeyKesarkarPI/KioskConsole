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
    public class ServicesDb
    {
        List<Service> services = new List<Service>();
        public ServicesDb()
        {
            
        }

        public List<Service> GetServices(int ServiceID)
        {
            string constr = @"Data Source = PC-227\SQL2016EXPRESS; Initial Catalog = Northwind; User ID = sagar; Password = aa";
            string sql = $"EXEC GetAllServices {ServiceID}";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = constr;
                conn.Open();                
                services = conn.Query<Service>(sql).ToList();
            }

            return services;
        }

        public void InsertNewServices(Service service)
        {
            string Qxml = "";
            foreach (var item in service.Questions)
            {
                Qxml += $"<root><Question>{item}</Question></root>";
            }

            string constr = @"Data Source = PC-227\SQL2016EXPRESS; Initial Catalog = Northwind; User ID = sagar; Password = aa";
            string sql = $"EXEC InsertNewKioskService {service.BranchID}, '{Qxml}', '{service.ServiceName}'";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = constr;
                conn.Open();

                conn.Execute(sql);
            }
        }
    }
}
