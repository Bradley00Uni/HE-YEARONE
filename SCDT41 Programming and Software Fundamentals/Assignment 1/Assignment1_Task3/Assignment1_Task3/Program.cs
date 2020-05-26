using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task3
{
    class Program
    {
        private static void Main(string[] args)
        {
            bool loopBreak = false;
            bool adminOverride = false;
            string check = "";
            string loginError;

            Console.WriteLine("Welcome to the Company System"); //Welcomes the user

            do
            {
                Console.WriteLine("Please Enter your Username");
                string usernameInput = Console.ReadLine().ToUpper(); //stores user input of username

                Console.WriteLine("Please Enter your Password");
                string passwordInput = Console.ReadLine(); //stores user input of password

                List<string> loginInput = new List<string>(2)
                {
                 usernameInput, passwordInput //stores inputted login in list
                };
                bool loginMatch = UserLogins.detailsCheck(loginInput); //passes login info to method for validation

                bool adminCheck = false;
                List<string> userDetails = new List<string>(2);


                if (loginMatch == true) //if login successful
                {                                      
                   userDetails = UserLogins.retrieveName(userDetails); //retrives user's name for welcome message from method

                    adminCheck = UserLogins.checkAdmin(check); //retrieves user's admin status from method
                }
            

                if (loginMatch == true & adminCheck == true) //if user is logged in and an admin
                {
                    loopBreak = true;
                    Console.WriteLine("Welcome Admin: {0} {1}", userDetails.ElementAt(0), userDetails.ElementAt(1)); //personalised welcome message
                    AdminUser.adminMenu(); //Loads Admin menu
                }
                else if(loginMatch == true) //if user is logged in but not an admin
                {
                    Console.WriteLine("Welcome {0} {1}", userDetails.ElementAt(0), userDetails.ElementAt(1)); //personalised welcome message
                    User.userMenu(); //LOads Regular User Menu
                    loopBreak = true;
                }
                else if(UserLogins.loginAttempts == 0) //If user has not logged in and has used all login attempts
                {
                    loginError = UserLogins.attemptsCheck(check); //calls error to display
                    Console.WriteLine("");
                    Console.WriteLine(loginError + Environment.NewLine);
                    loopBreak = true;
                    adminOverride = true;
                }
                else
                {
                    loginError = UserLogins.attemptsCheck(check); //if user has not logged in and has login attempts remaining
                    Console.WriteLine(loginError); //displays error
                    Console.WriteLine("");
                    loopBreak = false;
                }
               
            } while(loopBreak == false);

            do //admin override
            {

                Console.WriteLine("Enter Admin Username");
                string adminUsername = Console.ReadLine().ToUpper(); //entered Admin Login
                Console.WriteLine("Enter Admin Password");
                string adminPassword = Console.ReadLine(); //entered Admin Password

                List<string> adminInput = new List<string>(2)
                {
                    adminUsername,adminPassword //stores entered login as list
                };

                AdminOverride.adminAuthourisation(adminInput); //checks login list against recognised Admin logins

            } while (adminOverride == true);

            Console.ReadLine();

        }
    }
}
