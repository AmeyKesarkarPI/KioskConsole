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
    public class CompanyCreation : Page
    {

        CommonResponseDTO<Company> CommonResponseDTO;
        Company company = new Company();
        public CompanyCreation()
        {
            PageName = "Add New Company";
        }

        public override void DisplayQuestions()
        {
            Console.WriteLine("Company Name");
            company.CompanyName = GetReader.GetString("Enter Correct Company Name");

            using (HttpClient client = new HttpClient())
            {
                CommonResponseDTO = client.PostAsJsonAsync($"https://localhost:44373/Api/Company/", company).Result.Content.ReadFromJsonAsync<CommonResponseDTO<Company>>().Result;
            }

            Console.WriteLine($"{CommonResponseDTO.Message}");
            Console.ReadLine();
        }
    }
}
