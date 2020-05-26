using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task3
{
    class AdminOverride
    {
        public static void adminAuthourisation(List<string> loginCheck)
        {
            
            if (UserLogins.authorisedCheck(loginCheck) == true) //If admin login is recognised
            {
                Console.WriteLine("Admin Override Successful");
                Console.WriteLine("Press Enter to Close the Software");
                Console.ReadLine();
                System.Environment.Exit(1); //Exit the software
            }
            else
            {
                Console.WriteLine("Unrecognised Admin Login | Try Again" + Environment.NewLine); //Ask user to re-enter admin Login
            }

        }
    }
}
