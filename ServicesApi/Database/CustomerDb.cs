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
    public class CustomerDb
    {
        string constr = @"Data Source = PC-227\SQL2016EXPRESS; Initial Catalog = Northwind; User ID = sagar; Password = aa";
        List<Customer> list = new List<Customer>();
        public List<Customer> GetCustomer(string Token, int Id)
        {
        //    string constr = @"Data Source = PC-227\SQL2016EXPRESS; Initial Catalog = Northwind; User ID = sagar; Password = aa";
            string sql = $"EXEC KioskGetInfo  '{Token}', {Id}";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = constr;
                conn.Open();
                list = conn.Query<Customer>(sql).ToList();
            }

            return list;
        }

        public string  StartServing(Customer customer)
        {
            string sql = $"EXEC KioskStartServing '{customer.Token}', {customer.CounterID}";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = constr;
                conn.Open();

                conn.Execute(sql);
            }
            return "Customer Serving";
        }

        public string CustomerServed(Customer customer)
        {
          //  string constr = @"Data Source = PC-227\SQL2016EXPRESS; Initial Catalog = Northwind; User ID = sagar; Password = aa";
            string sql = $"EXEC MarkCustomerServed '{customer.Token}', {customer.CounterID}";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = constr;
                conn.Open();

                conn.Execute(sql);
            }
            return "Customer Served Successfully";
        }
    }
}
