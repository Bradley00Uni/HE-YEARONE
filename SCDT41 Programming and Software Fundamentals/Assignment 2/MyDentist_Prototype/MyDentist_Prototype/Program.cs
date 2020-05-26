using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{

    class Program
    {
        public static List<string> loginDetails = new List<string>(); //Storage of inputted login details by user

        static void Main(string[] args) //Run at application launch
        {
            bool x = false;
            do
            {
                Console.WriteLine(Environment.NewLine + "Welcome to the MyDentist System | Please Log in"); //Welcome message to the user
                Console.WriteLine("Type P if | You are a Patient" + Environment.NewLine + "Type S if | You are Staff" + Environment.NewLine + "Type X to | Close the Software");
                string userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "P":
                        Patient_Class.patientStartup(); //loads login menu for patients
                        break;
                    case "S":
                        staffLogin(); //loads login menu for staff
                        break;
                    case "X":
                        Environment.Exit(1); //closes the application
                        break;
                }
            } while (!x);
        }

        static void staffLogin() //method for staff members to log in
        {
            bool loginState = false;
            string loginRole = "";

            do
            {
                loginDetails.Clear();
                Console.Write("Username: ");
                string usernameTemp = Console.ReadLine().ToUpper(); //reads user's input for their username
                loginDetails.Add(usernameTemp);
                Console.Write("Password: ");
                string passwordTemp = Console.ReadLine(); //reads user's input for their password
                loginDetails.Add(passwordTemp); //adds inputs to the temporany input storage
                loginRole = Staff.checkStaff(loginDetails); //runs method to check wether inputs are valid, and if so: which role the user is

                if (loginRole == "Error") //if the method returns that the login is unrecognised, the login fails
                {
                    loginState = false;
                }
                else //otherwise, continue with process
                {
                    loginState = true;
                }

            } while (loginState == false); //run the login request until a recognised login is entered

            List<string> login = new List<string>() { loginDetails.ElementAt(0), loginRole }; //information to pass to the Dental menu

            switch (loginRole) //runs based on which role the user is
            {
                case "Dentist": //if they're a dentist, load the dental menu 
                    Staff_Menus.dentalMenu(login);
                    break;
                case "Nurse":
                    Staff_Menus.dentalMenu(login); //if they're a nurse, load the dental menu
                    break;
                case "Receptionist": //if they're a receptionist, load the receptionist menu
                    Staff_Menus.receptionistMenu(loginDetails);
                    break;
                case "Admin": //if they're an admin, load the admin-only menu
                    Admin_Menu.adminMenu();
                    break;
            }
        }
    }
}
