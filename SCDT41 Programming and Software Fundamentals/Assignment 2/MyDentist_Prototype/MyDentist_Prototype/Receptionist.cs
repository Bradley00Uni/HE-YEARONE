using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    class Receptionist : Staff //Built off Abstract Class
    {
        string staffID;
        string username;
        string password;
        string firstName;
        string surname;

        public Receptionist(string staffID, string username, string password, string firstName, string surname) //object for receptionists
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

        protected static List<Receptionist> allReceptionists = new List<Receptionist> //list of all receptionists on the system
        {
            new Receptionist("ABCDE","RECEPTIONIST","password","GENERIC","NAME"),
        };

        public static Receptionist roomReceptionist(string inputID) //method to check if inputted ID matches that of a receptionist
        {
            foreach(var r in allReceptionists)
            {
                if(inputID == r.StaffID)
                {
                    return r; //return matching receptionist
                }
            }
            return null;
        }

        public static bool checkReceptionist(List<string> input) //method to check login input against receptionists
        {
            int y = 0;

            foreach (var x in allReceptionists)
            {
                if (input.ElementAt(0) == allReceptionists.ElementAt(y).Username & input.ElementAt(1) == allReceptionists.ElementAt(y).Password)
                { //if inputted username & password match those of a recognised receptionist
                    return true;
                }
                else
                {
                    y++;
                }
            }
            return false;
        }

        public static Receptionist loginInformation(List<string> loginDetails) //method to check receptionist login information
        {
            foreach (var r in allReceptionists)
            {
                if (loginDetails.ElementAt(0) == r.Username & loginDetails.ElementAt(1) == r.Password)
                {
                    return r;
                }
            }
            return null;
        }

        public static bool addReceptionist() //method to add new receptionist
        {
            List<string> input = addStaff(); //calls abstract class for staff creation
            foreach(var r in allReceptionists) { if (input[1] == r.FirstName & input[4] == r.Username) { return false; } } //Receptionist already exists
            allReceptionists.Add(new Receptionist(input[0], input[3], input[4], input[1], input[2])); //Register Successful
            return true;
        }
    }
}
