using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task3
{
    class AdminUser
    {
        static List<string> adminOptions = new List<string>() //All Possbile answers to Admin Menu
         {
             "!","V","A","R","X"
         };



        public static void adminMenu()
        {
            bool loopBreak = false;

            do
            {
                Console.WriteLine(""); //Displays list of options for Admin
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Press V to view user details | Press A to add users to the system |");
                Console.WriteLine("Press R to remove a user from the system | Press X to exit the system|");
                string userChoice = Console.ReadLine().ToUpper(); //saves choice

                string choice = adminOptions.ElementAt(adminChoice(userChoice)); //passes choice to method to check against possible answers

                if (choice == "!")
                {
                    Console.WriteLine("Unknown Input Detected | Try again"); //Asks user to re-enter choice
                }
                else if (choice == "V")
                {
                    UserLogins.userOutput(); //View all User information
                }
                else if (choice == "A")
                {
                    UserLogins.addUsers(); //Add a new user to the system
                }
                else if (choice == "R")
                {
                    UserLogins.removeUsers(); //Remove a user from the system
                }
                else if (choice == "X")
                {
                    System.Environment.Exit(1); //Closes the software
                }
            } while (loopBreak == false);
        }




        static int adminChoice(string choice) //compares entered admin choice against possible ones stored in the system
        {
            int y = 0;
            bool loopBreak = false;

            do
            {
                if (y == adminOptions.Count)
                {
                    loopBreak = true;
                }
                else if (choice == adminOptions.ElementAt(y))
                {
                    return y;
                }
                else
                {
                    y = y + 1;
                }
            } while (loopBreak == false);
            return 0;
        }

    }
}
