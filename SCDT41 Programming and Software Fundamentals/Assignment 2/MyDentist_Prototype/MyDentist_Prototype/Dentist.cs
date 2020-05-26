using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    public class Dentist : Staff
    {
        string staffID;
        string username;
        string password;
        string firstName;
        string surname;


        public Dentist(string staffID, string username, string password, string firstName, string surname) //object for dentists
        {
            this.staffID = staffID;
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.surname = surname;
        }
        public string StaffID { get => staffID; set => staffID = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Surname { get => surname; set => surname = value; }

        protected static List<Dentist> allDentists = new List<Dentist>{
            new Dentist("12345", "DENTIST", "password", "GENERIC", "NAME") //example dentist
        };

        public static bool checkDentist(List<string> input) //method to check if dentist exists
        {
            int y = 0;

            foreach (var x in allDentists) // checks if inputted login information matches a dentist on the system
            {
                if (input.ElementAt(0) == allDentists.ElementAt(y).Username & input.ElementAt(1) == allDentists.ElementAt(y).Password)
                {
                    return true;
                }
                else
                {
                    y++;
                }
            }
            return false;
        }

        public static Dentist roomDentist(string inputID) //method to check if dentist exsits on the system
        {

            foreach(var d in allDentists)
            {
                if(inputID == d.StaffID)
                {
                    return d; //return the dentist object for that ID
                }
            }
            return null;
        }

        public static bool addDentist() //method to add new dentist
        {
            List<string> input = addStaff();

            foreach(var d in allDentists)
            {
                if(input[1] == d.FirstName || input[4] == d.Username)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Environment.NewLine + "Error | Dentist Already Exists"); //returns an error if the entered credentials for a new Dentist match one already on the system
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
            }

            allDentists.Add(new Dentist(input[0], input[3], input[4], input[1], input[2])); //adds new dentist based on inputted information
            //Dentist creation Successful
            return true;
                     
        }

        public static Dentist loginInformation(List<string> loginDetails) //checks dentist login information
        {
            foreach(var d in allDentists)
            {
                if(loginDetails.ElementAt(0) == d.Username) //checks if the inputted username matches that of an exisitng user
                {
                    return d;
                }
            }
            return null;
        }

        public static List<Dentist> returnAll()
        {
            return allDentists; //returns the list of all Dentists on the system
        }
    }
}
