using Dapper;
using DTO;
using Entity;
using ServicesApi.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class BranchDb
    {
        string constr = @"Data Source = PC-227\SQL2016EXPRESS; Initial Catalog = Northwind; User ID = sagar; Password = aa";
        List<Branch> Branch = new List<Branch>();
        public BranchDb()
        {

        }

        public void InsertNewBranch(Branch Branch)
        {
            string ServiceIds = "";  //= Branch.ServiceIds;
            ServiceIds = StringArrayMaker<int>(Branch.ServiceIds);
           // string constr = @"Data Source = PC-227\SQL2016EXPRESS; Initial Catalog = Northwind; User ID = sagar; Password = aa";
            string sql = $"EXEC KioskBranchCreation '{Branch.Region}', {Branch.CompanyId}, '{ServiceIds}'";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = constr;
                conn.Open();

                conn.Execute(sql);
            }
        }

        public void InsertCompany(Company company)
        {
            string constr = @"Data Source = PC-227\SQL2016EXPRESS; Initial Catalog = Northwind; User ID = sagar; Password = aa";
            string sql = $"EXEC KioskCompanyCreation '{company.CompanyName}'";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = constr;
                conn.Open();
                conn.Execute(sql);
            }
        }

        public void InsertCounter(Counter counter)
        {
            string CounterNames = "";  //= Branch.ServiceIds;
            CounterNames = StringArrayMaker<string>(counter.CounterNames);
          //  string constr = @"Data Source = PC-227\SQL2016EXPRESS; Initial Catalog = Northwind; User ID = sagar; Password = aa";
            string sql = $"EXEC KioskInsertCounter '{CounterNames}', {counter.BranchID}";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = constr;
                conn.Open();

                conn.Execute(sql);
            }
        }

        public string StringArrayMaker<T>(T[] t)
        {
            string output = "";
            for (int i = 0; i < t.Count(); i++)
            {
                var item = t[i];
                if (i == t.Count() - 1)
                {
                    output += "" + item;
                }
                else
                {
                    output += item + ",";
                }
            }
            return output;
        }

        public ServiceBranch GetBranch(int BranchId)
        {
            ServiceBranch serviceBranch = null;
            string sql = $"EXEC kioskserviceBranch " +BranchId ;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = constr;
                conn.Open();
                serviceBranch = conn.Query<ServiceBranch>(sql).FirstOrDefault();
            }
            return serviceBranch;
        }
    }
}
