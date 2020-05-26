using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task1
{
    class Program
    {

        public static Dictionary<string, string> loginInput = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            bool loginState = false;
            Console.WriteLine(Environment.NewLine + "Welcome to the Passenger Management System  |  Please Log in" + Environment.NewLine);
            do
            {
                loginInput.Clear();
                Console.Write("Username: ");
                string usernameInput = Console.ReadLine().ToUpper(); //Stores input as user login
                Console.Write("Password: ");
                string passwordInput = Console.ReadLine(); //Stores input as user password
                Console.WriteLine("");
                loginInput.Add(usernameInput, passwordInput); //passes inputs to method to check them against those stored in the system
                loginState = LoginDetails.loginCheck(loginInput); //passes inputs to method to check them against those stored in the system
            } while (loginState == false); //Loops until recognised Login is entered
            Console.WriteLine("Logging In..." + Environment.NewLine);
            CoachDetails.coachPassengers();
            Console.ReadLine();
        }
    }
}
