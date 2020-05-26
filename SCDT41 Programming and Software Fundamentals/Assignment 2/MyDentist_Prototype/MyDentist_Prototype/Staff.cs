using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    public abstract class Staff
    {
        //abstract class for staff creation, acts as the basis for all staff role creation: with added information being altered based on which role is needed

        protected static List<string> addStaff() //method to add new staff member
        {
            string staffID;
            string username;
            string password;
            string firstName;
            string surname;

            Console.WriteLine("Enter the Staff's Details Below:" + Environment.NewLine);
            Console.Write("First Name: ");
            firstName = Console.ReadLine().ToUpper();
            Console.Write("Surname: ");
            surname = Console.ReadLine().ToUpper();

            Console.Write("Username: ");
            username = Console.ReadLine().ToUpper();
            Console.Write("Password: ");
            password = Console.ReadLine();

            staffID = Guid.NewGuid().ToString(); //Generates a unique 5 digit ID for the Staff ID
            char[] idCharacters = staffID.Take(5).ToArray();
            staffID = new string(idCharacters).ToUpper();

            List<string> input = new List<string>(){staffID, firstName, surname, username, password};

            return input;
        }

        public static string checkStaff(List<string> userInput) //method to check if inputted login information matches an exisitng login and role
        {
            string loginRole = "";
            bool loginBool = false;

            loginBool = Dentist.checkDentist(userInput);

            if(loginBool == true)
            {
                loginRole = "Dentist";
                return loginRole;
            }

            loginBool = Nurse.checkNurse(userInput);

            if (loginBool == true)
            {
                loginRole = "Nurse";
                return loginRole;
            }

            loginBool = Receptionist.checkReceptionist(userInput);

           if (loginBool == true)
            {
                loginRole = "Receptionist";
                return loginRole;
            }

            loginBool = Administrator.checkAdmin(userInput);

            if (loginBool == true)
            {
                loginRole = "Admin";
                return loginRole;
            }

            loginRole = "Error";
            return loginRole;
        }

    }

}
