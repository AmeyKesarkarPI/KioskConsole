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
    public class AddService : Page
    {

        CommonResponseDTO<List<Service>> CommonResponseDTO;
        Service services = new Service();
        public AddService()
        {
            PageName = "Add New Service";
        }

        public override void DisplayQuestions()
        {
            Console.WriteLine("Enter Service ID");
            services.ServiceID = GetReader.GetInteger("Enter Service ID");

            Console.WriteLine("Enter Branch ID");
            services.BranchID= GetReader.GetInteger("Enter Correct Branch ID");
            Console.WriteLine("Enter Service Name");
            services.ServiceName = GetReader.GetString("Enter Correct Service Name");
            Console.WriteLine("How many Questions you want to enter ?");
            int num = GetReader.GetInteger("Enter Correct Number of Questions");
            services.Questions = new string[num];
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Enter Question {i + 1}");
                services.Questions[i] = GetReader.GetString("Enter Question");
            }

            using (HttpClient client = new HttpClient())
            {
                CommonResponseDTO = client.PostAsJsonAsync($"https://localhost:44373/Api/Kiosk/",services).Result.Content.ReadFromJsonAsync<CommonResponseDTO<List<Service>>>().Result;
            }

            Console.WriteLine($"{CommonResponseDTO.Message}");
            Console.ReadLine();
        }
    }
}
