using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KioskSystemAdmin
{
    public class AddQuestion : Page
    {
        CommonResponseDTO<List<Questions>> CommonResponseDTO;
        Questions questions = new Questions();
        public AddQuestion()
        {
            PageName = "Add New Question";
        }

        public override void DisplayQuestions()
        {
            Console.WriteLine("Enter Service ID");
            questions.ServiceID = GetReader.GetInteger("Enter Service ID");
            Console.WriteLine("Enter Question ID");
            questions.QuestionID = GetReader.GetInteger("Enter Question ID");
            Console.WriteLine("Enter Question ");
            questions.Question = GetReader.GetString("Enter Question");

            using (HttpClient client = new HttpClient())
            {
                CommonResponseDTO = client.PostAsJsonAsync($"https://localhost:44373/Api/Question/", questions).Result.Content.ReadFromJsonAsync<CommonResponseDTO<List<Questions>>>().Result;
            }

            Console.WriteLine($"{CommonResponseDTO.Message}");
            Console.ReadLine();
            Console.WriteLine("Do you want to add more Questions(y/n)");
            string choice = GetReader.GetString("Invalid!! Enter Again");
            if (choice == "y")
            {
                Console.Clear();
                this.DisplayQuestions();
            }
        }
    }
}
