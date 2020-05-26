using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    public class Nurse : Staff
    {
        string staffID;
        string username;
        string password;
        string firstName;
        string surname;

        public Nurse(string staffID, string username, string password, string firstName, string surname) //object for each nurse on the system
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

        protected static List<Nurse> allNurses = new List<Nurse> //list of all nurses 
        {
            new Nurse("67890","NURSE","password","GENERIC","NAME")
        };

        public static bool checkNurse(List<string> input) //method to check if nurse exists on the system
        {
            int y = 0;

            foreach (var x in allNurses)
            {
                if (input.ElementAt(0) == allNurses.ElementAt(y).Username & input.ElementAt(1) == allNurses.ElementAt(y).Password) //if the inputted login matches a nurse 
                {
                    return true;
                }
                else
                {
                    y++; //iterate
                }
            }
            return false;
        }

        public static Nurse roomNurse(string inputID) //method to check if inputted ID matches that of a nurse
        {
            foreach (var n in allNurses)
            {
                if (inputID == n.StaffID)
                {
                    return n;
                }
            }
            return null;
        }

        public static bool addNurse() //method to add a new nurse
        {
            List<string> input = addStaff();

            foreach (var n in allNurses)
            {
                if (input[1] == n.FirstName & input[4] == n.Username)
                {
                    //Nurse already exists
                    return false;
                }
            }

            allNurses.Add(new Nurse(input[0], input[3], input[4], input[1], input[2])); //create new nurse with inputted information

            //Nurse creation Successful
            return true;
        }

        public static Nurse loginInformation(List<string> loginDetails)//checks login information against nurses on the sustem
        {
            foreach (var d in allNurses)
            {
                if (loginDetails.ElementAt(0) == d.Username)
                {
                    return d; //returns the matching nurse
                }
            }
            return null;
        }
    }
}
