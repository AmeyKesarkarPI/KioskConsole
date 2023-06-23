using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSystemAdmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Page p = new Page();
                p.AdminLogin();
            } while (true);
        }
    }
}
