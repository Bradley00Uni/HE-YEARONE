using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task3
{
    class User
    {
        static List<string> userOptions = new List<string>() //All options for User Menu
         {
             "!","X","P"
         };



        public static void userMenu()
        {
            bool loopBreak = false;

            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Press X to Log out | Press P to change your password");
                string userAction = Console.ReadLine().ToUpper(); //User's choice

                string choice = userOptions.ElementAt(userChoice(userAction));

                if (choice == "!")
                {
                    Console.WriteLine("Unknown Input Detected | Try again"); //if unrecognised input, ask user to try again
                }
                else if (choice == "X")
                {
                    System.Environment.Exit(1); //Exit the software
                }
                else if (choice == "P") //Reset user's password
                {
                    Console.WriteLine("Please enter your current password");
                    string oldPassword = Console.ReadLine();
                    UserLogins.changePassword(oldPassword); //passes current password input to method to update password
                }
            } while (loopBreak == false);
        }



        static int userChoice(string choice) //converts user choce input into refrence in options list
        {
            int y = 0;
            bool loopBreak = false;

            do
            {
                if (y == userOptions.Count)
                {
                    loopBreak = true;
                }
                else if (choice == userOptions.ElementAt(y))
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
