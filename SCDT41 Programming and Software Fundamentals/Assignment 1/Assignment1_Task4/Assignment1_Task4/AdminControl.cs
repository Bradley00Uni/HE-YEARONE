using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task4
{
    class AdminControl
    {
        static bool constantMenu = false;
        public static void adminMenu()
        {
            do
            {
                Console.WriteLine(Environment.NewLine + "----------" + Environment.NewLine + "ADMIN MENU" + Environment.NewLine);
                Console.WriteLine("Type C to | Manage Customers" + Environment.NewLine + "Type B to | Manage Books" + Environment.NewLine + "Type L to | Manage Loans" + Environment.NewLine + "Type U to | Manage Logins" + Environment.NewLine + "Type X to | Exit the Software" + Environment.NewLine);
                Console.Write("What would you like to do? "); //Displays Admin options to the user
                string userChoice = Console.ReadLine().ToUpper(); //stores admin choice
                int j = adminChoice(userChoice); 

                switch (j) //checks options for admin menu
                {
                    case 1:
                        CustomerDetails.customerMenu(); //Loads Class to manage customers
                        break;
                    case 2:
                        BookDetails.bookMenu(); //Loads Class to manage books
                        break;
                    case 3:
                        LoanDetails.loanMenu(); //Loads Class to manage loans
                        break;
                    case 4:
                        LoginDetails.loginMenu(); //Loads class to manage Logins
                        break;
                    case 5:
                        Environment.Exit(1); //Exit the software
                        break;
                }
            } while (constantMenu == false);

        }
        static int adminChoice(string choice)
        {
            Dictionary<int,string> adminChoices = new Dictionary<int, string>()
            {
                {1,"C"},{2,"B"},{3,"L"},{4,"U"},{5,"X"} //Checks Admin choice against possible accepted options
            };

            foreach (var option in adminChoices) 
            {
                if (choice == option.Value)
                {
                    return option.Key;
                }             
            }
            return 0;
        }
    }
}
