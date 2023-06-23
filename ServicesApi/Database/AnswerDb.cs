using Dapper;
using Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ServicesApi.Controllers
{
    public class AnswerDb
    {
        public AnswerDb()
        {

        }
        Token Token { get; set; }
        public Token InsertAnswer(Answer answer)
        {
            string Qxml = "";
            for (int i=0; i < answer.Answers.Count(); i++)
            {
                Qxml += $"<root><Answer>{answer.Answers[i]}</Answer><Question>{answer.QuestionsID[i]}</Question></root>";
            }

            string constr = @"Data Source = PC-227\SQL2016EXPRESS; Initial Catalog = Northwind; User ID = sagar; Password = aa";
            string sql = $"EXEC KioskInsertAnswers {answer.ServiceID}, {answer.BranchID}, '{Qxml}'";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = constr;
                conn.Open();
                Token = conn.Query<Token>(sql).FirstOrDefault();
            }
            return Token;
        }
    }
}