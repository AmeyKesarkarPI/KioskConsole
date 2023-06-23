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
    public class CommonResponseDTO<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class Page
    {
        Admin admin = new Admin();
        public string PageName { get; set; }
        public static List<Page> pages = new List<Page>();
        public Page()
        {
            PageName = "Home";
        }

        string apiLink = "https://localhost:44373/api/";

        public void AdminLogin()
        {
            Console.WriteLine("Enter UserName:");
            admin.AdminName = GetReader.GetString("Enter correct UserName");
            Console.WriteLine("Enter Password:");
            admin.Password = GetReader.GetString("Enter correct Password");

            using (HttpClient client = new HttpClient())
            {
                CommonResponseDTO<int> response = client.PostAsJsonAsync("https://localhost:44373/Api/Admin", admin).Result.Content.ReadFromJsonAsync<CommonResponseDTO<int>>().Result;

                if (response.Data >= 1)
                {
                    Console.WriteLine("Login Successful");
                    Console.ReadLine();
                    Console.Clear();
                    MainMenu m = new MainMenu();
                    DisplayOptions();
                }
                else
                {
                    Console.WriteLine("Login Failed");
                    Console.ReadLine();
                    Console.Clear();
                    this.AdminLogin();
                }
            }
        }
        public virtual void DisplayQuestions()
        {

        }
        public virtual void DisplayOptions()
        {
            Console.WriteLine("Please Enter Your Choice :");

            foreach (var item in pages)
            {
                Console.WriteLine(pages.IndexOf(item) + 1 + " -- " + item.PageName);
            }

            int choice = GetReader.GetInteger("Enter Correct Choice");

            if (choice > pages.Count)
            {
                Console.Clear();
                this.DisplayOptions();
            }
            Console.Clear();
            pages[choice - 1].DisplayQuestions();
            //DisplayQuestions(serviceList.ElementAt(choice).ServiceID, BranchID);
            Console.Clear();
            this.DisplayOptions();
        }
    }
}
