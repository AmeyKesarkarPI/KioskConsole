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
    public class BranchCreation : Page
    {

        CommonResponseDTO<Branch> CommonResponseDTO;
        Branch branch = new Branch();
        public BranchCreation()
        {
            PageName = "Add New Branch";
        }

        public override void DisplayQuestions()
        {
            Console.WriteLine("Enter Branch Region");
            branch.Region = GetReader.GetString("Enter Correct Branch Region");
            Console.WriteLine("Enter Company ID");
            branch.CompanyId = GetReader.GetInteger("Enter Correct Company ID");
            Console.WriteLine("How Many Services?");
            int num = GetReader.GetInteger("Enter Correct Number of Services");
            branch.ServiceIds = new int[num];
            Console.WriteLine("Enter ServiceIds");
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Enter Id {i + 1}");
                branch.ServiceIds[i] = GetReader.GetInteger("Enter Correct ServiceID");
            }
            using (HttpClient client = new HttpClient())
            {
                CommonResponseDTO = client.PostAsJsonAsync($"https://localhost:44373/Api/Branch/", branch).Result.Content.ReadFromJsonAsync<CommonResponseDTO<Branch>>().Result;
            }

            Console.WriteLine($"{CommonResponseDTO.Message}");
            Console.ReadLine();
        }
    }
}
