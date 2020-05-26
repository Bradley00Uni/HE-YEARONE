using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task3
{
    class UserLogins
    {
        static Dictionary<string, string> Employee_Login = new Dictionary<string, string>() //Stores all user login information
        {
            {"JOHNSM22738","D7y6a"},
            {"JANEDO98786","i&acN"},
            {"BRYNW56655","GgjN6"},
            {"NESSAJ25255","3KsyX"}
        };
        static Dictionary<string, string> Employee_Names = new Dictionary<string, string>() //Stores all user personal details
        {
            {"John", "Smith"},
            {"Jane", "Doe" },
            {"Bryn", "Williams" },
            { "Nessa", "Jenkins"}
        };
        static List<bool> Employee_Admin = new List<bool>(2) //stores whether each user is an admin
        {
            true, false, false, false
        };
        public static int x;
        public static int loginAttempts = 3;



        public static bool detailsCheck(List<string> test)
        {
            x = 0;
            bool userMatch = false;
            bool loopBreak = false;


            do
            {
                if (x == Employee_Login.Count & (loginAttempts == 3 | loginAttempts == 2 | loginAttempts == 1)) //If login is unrecognised and user has attempts remaining
                {
                    loginAttempts = loginAttempts - 1; //deduct one login attempt
                    x = 0;
                    userMatch = false;
                    loopBreak = true;
                }
                else if (test.ElementAt(0) == Employee_Login.Keys.ElementAt(x) & test.ElementAt(1) == Employee_Login.Values.ElementAt(x)) //If login is recognised
                {
                    loginAttempts = 3;
                    userMatch = true;
                    loopBreak = true;
                }
                else
                {
                    x = x + 1; //itterate place in dictonary by one
                }

            } while (loopBreak == false);

            return userMatch;

        }



        public static string attemptsCheck(string logins)
        {
            if (loginAttempts >= 2) //2 attempts remaining
            {
                logins = $"Incorrect Login Details | {loginAttempts} attempts remaining";
                return logins;
            }
            else if (loginAttempts == 1) //1 attempt remaining
            {
                logins = "Incorrect Login Details | Warning! - Only 1 attempt remaining before the device will need to be unlocked by an admin";
                return logins;
            }
            else if (loginAttempts == 0) //No attempts remaining
            {
                logins = "Inncorrect Login Details" + Environment.NewLine + "Maximum number of login attempts reached | Device will need to be unlocked by an admin";
                return logins;
            }
            else
            {
                return null;
            }
        }



        public static List<string> retrieveName(List<string> name) //Method to retrieve name for current user
        {
            List<string> employeeName = new List<string>(2)
            {
                Employee_Names.Keys.ElementAt(x),
                Employee_Names.Values.ElementAt(x)
            };
            return employeeName;
        }



        public static bool checkAdmin(string check) //checks whether current user is an Admin
        {

            bool isAdmin = false;

            if (Employee_Admin.ElementAt(x) == true)
            {
                isAdmin = true;
                return isAdmin;
            }
            else
            {
                isAdmin = false;
                return isAdmin;
            }

        }



        public static bool authorisedCheck(List<string> check) 
        {
            bool loopBreak = false;
            do
            {
                if (x == Employee_Login.Count)
                {
                    x = 0;
                    return false;
                }
                else if (check.ElementAt(0) == Employee_Login.Keys.ElementAt(x) & check.ElementAt(1) == Employee_Login.Values.ElementAt(x) & Employee_Admin.ElementAt(x) == true)
                {
                    x = 0;
                    loopBreak = true;
                }
                else
                {
                    x = x + 1;
                }
            } while (loopBreak == false);
            return true;
            
        }



        public static bool addUsers() //Method to add new user to the system
        {
            bool loopBreak = false;
            string fnameInput;
            string snameInput;
            string unameInput;
            string passwordInput;
            string adminInput;
            bool adminTrue = false;
            do
            {
                Console.WriteLine("Enter the First Name of the new user");
                fnameInput = Console.ReadLine().ToUpper(); //Stores input as new first name
                if(fnameInput.Length < 1) //If nothing is typed, display error
                {
                    Console.WriteLine("No input detected, Try again");
                    return false;
                }

                Console.WriteLine("Enter the Surname of the new user");
                snameInput = Console.ReadLine().ToUpper(); //Stores input as new surname
                if (snameInput.Length < 1) //If nothing is typed, display error
                {
                    Console.WriteLine("No input detected, Try again");
                    return false;
                }

                Console.WriteLine("Enter the Desired Username of the new user");
                unameInput = Console.ReadLine().ToUpper(); //Stores input as new Username
                if (unameInput.Length < 1) //If nothing is typed, display error
                {
                    Console.WriteLine("No input detected, Try again");
                    return false;
                }

                Console.WriteLine("Enter the Desired Password of the new user");
                passwordInput = Console.ReadLine(); //Stores input as new Password 
                if (passwordInput.Length < 1) //If nothing is typed, display error
                {
                    Console.WriteLine("No input detected, Try again");
                    return false;
                }

                Console.WriteLine("Is this user an Admin? (Y/N)");
                adminInput = Console.ReadLine().ToUpper(); //Stores whether new user is an admin

                if(adminInput == "Y")
                {
                    adminTrue = true;
                }
                else
                {
                    adminTrue = false;
                }

                loopBreak = true;
            } while (loopBreak == false);

            Employee_Login.Add(unameInput, passwordInput); //Adds all new information as a user on the system
            Employee_Names.Add(fnameInput, snameInput);
            Employee_Admin.Add(adminTrue);

            return true;
        }



        public static bool removeUsers() //Method to remove a user from the system
        {
            bool loopBreak = false;
            int y = 0;

            Console.WriteLine("Enter a username to delete from the system");
            string choice = Console.ReadLine().ToUpper(); //stores 

            do
            {
                if (y == Employee_Login.Keys.Count)
                {
                    Console.WriteLine("Error | Could not find User"); //if all users have been checked, return an eror
                    return false;
                }
                else if (choice == Employee_Login.Keys.ElementAt(y)) //if a match is found
                {
                    string toRemove = Employee_Login.Keys.ElementAt(y); //remove that user
                    Employee_Login.Remove(toRemove);

                    toRemove = Employee_Names.Keys.ElementAt(y);
                    Employee_Names.Remove(toRemove);

                    bool toRemove2 = Employee_Admin.ElementAt(y);
                    Employee_Admin.Remove(toRemove2);
                    loopBreak = true;
                }
                else
                {
                    y = y + 1; //iterate place in dictionary by 1
                }
            } while (loopBreak == false);
            return true;
        }



        public static void userOutput() //Method to display all users on the system
        {
            int z = 0;
            do
            {
              Console.WriteLine("{0} - {1} - {2} - {3} - Admin: {4}", Employee_Login.Keys.ElementAt(z), Employee_Login.Values.ElementAt(z), Employee_Names.Keys.ElementAt(z), Employee_Names.Values.ElementAt(z), Employee_Admin.ElementAt(z));
                z = z + 1;
            } while (z != (Employee_Login.Keys.Count));
        }



        public static void changePassword(string oldPassword) //Method to allow users to change their password
        {
            bool loopBreak = false;

            if (oldPassword == Employee_Login.Values.ElementAt(x)) //if current password is entered correctly
            {
                do
                {
                    Console.WriteLine("Please Enter your new Password");
                    string newPassword1 = Console.ReadLine(); //enter new password
                    Console.WriteLine("Please Confirm your new Password");
                    string newPassword2 = Console.ReadLine(); //confirm new password

                    if (newPassword1 == newPassword2)
                    {
                        string currentUser = Employee_Login.Keys.ElementAt(x);
                        Employee_Login[currentUser] = newPassword1;
                        Console.WriteLine("Password Updated Successfully"); //update password
                        loopBreak = true;
                    }
                    else
                    {
                        Console.WriteLine("Those passwords did not match, please try again"); //give error - ask user to try again
                        Console.WriteLine("");
                        loopBreak = false;
                    } 
                } while (loopBreak == false);
            }
        }
    }
}
