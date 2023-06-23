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
    public class QuestionsDb
    {
            string constr = @"Data Source = PC-227\SQL2016EXPRESS; Initial Catalog = Northwind; User ID = sagar; Password = aa";
        List<Questions> questions = new List<Questions> ();
        public List<Questions> GetQuestions(int id)
        {
            string sql = $"EXEC KioskGetQuestions '{id}'";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = constr;
                conn.Open();
                questions = conn.Query<Questions>(sql).ToList();
            }
            return questions;
        }

        public void InsertNewQuestion(Questions question)
        {
            string Qxml = "";
            Qxml += $"<root><Question>{question.Question}</Question></root>";

            //string constr = @"Data Source = PC-227\SQL2016EXPRESS; Initial Catalog = Northwind; User ID = sagar; Password = aa";
            string sql = $"EXEC KioskAddQuestions {question.ServiceID}, '{Qxml}'";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = constr;
                conn.Open();
                conn.Execute(sql);
            }
        }
    }
}
