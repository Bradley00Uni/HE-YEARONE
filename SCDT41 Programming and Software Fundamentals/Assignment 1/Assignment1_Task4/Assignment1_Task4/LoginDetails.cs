using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task4
{
    class LoginDetails
    {
        static Dictionary<string, string> loginData = new Dictionary<string, string>() //Storage of all user login data
        {
            {"ADMIN","password"}
        };
        static List<string> loginNames = new List<string>()
        {
            {"Admin"} //storage of all user's names
        };

        static bool constantMenu = false;

        public static bool loginCheck(Dictionary<string, string> loginInput) //method to check entered login information is recognised
        {
            foreach (var login in loginData) //check every login in the system
            {
                if (loginInput.Keys.ElementAt(0) == login.Key & loginInput.Values.ElementAt(0) == login.Value) //if they match, return that it is correct
                {                    
                    return true;
                }
            }
            Console.WriteLine("Error | Unrecognised Login Details | Try Again"); //if no match can be found, return error message
            return false;
            
        }

        public static void loginMenu()
        {
            do
            { //Display all options for admin relating to Login management
                Console.WriteLine(Environment.NewLine + "---------------------" + Environment.NewLine + "LOGIN MANAGEMENT MENU" + Environment.NewLine);
                Console.WriteLine("Type A to | Add a Login" + Environment.NewLine + "Type D to | Delete a Login" + Environment.NewLine + "Type B to | Go Back" + Environment.NewLine + "Type X to | Exit the Software");
                Console.WriteLine(Environment.NewLine);
                Console.Write("What would you like to do? ");
                string userChoice = Console.ReadLine().ToUpper(); //saved Admin choice
                int i = menuChoice(userChoice); 

                switch (i) //checks which menu choice the admin has chosen
                {
                    case 1:
                        addLogin(); //Add a new login to the system
                        break;
                    case 2:
                        removeLogin(); //Remove a login from the system
                        break;
                    case 3:
                        AdminControl.adminMenu(); //Return to the main Admin Menu
                        break;
                    case 4:
                        Environment.Exit(1); //Close the software
                        break;
                }
            } while (constantMenu == false);
        }

        static int menuChoice(string choice) //Method to check if admin choice for menu is valid and recognised
        {
            Dictionary<int, string> menuChoices = new Dictionary<int, string>()
            {
                {1,"A"},{2,"D"},{3,"B"},{4,"X"}
            };

            foreach (var option in menuChoices)
            {
                if (choice == option.Value)
                {
                    return option.Key;
                }
            }
            return 0;
        }

        static bool addLogin() //Method to add a new login to the system
        {
            Console.WriteLine("Enter the Information for the new User");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine().ToUpper();
            if (firstName.Length < 1) //If nothing is entered, return an error
            {
                Console.WriteLine("Error | No Input Detected | Try Again");
                return false;
            }
            Console.Write("Username: ");
            string username = Console.ReadLine().ToUpper();
            if (username.Length < 1)
            {
                Console.WriteLine("Error | No Input Detected | Try Again");
                return false;
            }
            Console.Write("Password: ");
            string password = Console.ReadLine();
            if (password.Length < 1)
            {
                Console.WriteLine("Error | No Input Detected | Try Again");
                return false;
            }
            loginData.Add(username, password);
            loginNames.Add(firstName); //Add new user to the system
            Console.WriteLine(Environment.NewLine + "User Succesfully Added" + Environment.NewLine);
            return true;
        }

        static bool removeLogin() //Method to remove a login from the system
        {
            int x = 0;
            Console.WriteLine("Enter the details of the user to be removed");
            Console.Write("Username: ");
            string username = Console.ReadLine().ToUpper();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            foreach (var user in loginData)
            {
                if (username == user.Key & password == user.Value) //If entered username and password match a login on the system
                {
                    string toRemove = user.Key;
                    loginData.Remove(toRemove);
                    loginNames.RemoveAt(x); //Remove the login
                    Console.WriteLine(Environment.NewLine + "User Succesfully Removed" + Environment.NewLine);
                    return true;
                }
                x++;
            }
            Console.WriteLine(Environment.NewLine + "Error | Couldn't Find User" + Environment.NewLine); //if no match can be found, display an error
            return false;
        }

        public static string currentUser() //Method to retrive name of the current logged in user
        {
            string[] currentLogin = new string[2] { Program.loginInput.Keys.ElementAt(0),Program.loginInput.Values.ElementAt(0)};

            return currentLogin[0];
        }
    }
}
