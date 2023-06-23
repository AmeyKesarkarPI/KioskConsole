using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSystemAdmin
{
    public class MainMenu : Page
    {
        public MainMenu()
        {
            pages.Add(new AddService());
            pages.Add(new AddQuestion());
            pages.Add(new CompanyCreation());
            pages.Add(new BranchCreation());
        }
    }
}
