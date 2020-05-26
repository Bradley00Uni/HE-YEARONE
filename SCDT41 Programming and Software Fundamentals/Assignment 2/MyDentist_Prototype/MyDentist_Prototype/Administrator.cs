using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    class Administrator : Staff
    {
        string staffID;
        string username;
        string password;
        string name;

        public Administrator(string staffID, string username, string password, string name) //Object for an Admin user of the system
        {
            this.staffID = staffID;
            this.username = username;
            this.password = password;
            this.name = name;
        }
        public string StaffID { get => staffID; set => staffID = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }

        
        protected static List<Administrator> allAdmins = new List<Administrator> //List of all Admins on the system
        {
            new Administrator("00000","ADMIN","password","Admin") //example admin
        };

        public static bool checkAdmin(List<string> input) //method to check an admin's login
        {
            int y = 0;

            foreach (var x in allAdmins)
            {
                if (input.ElementAt(0) == allAdmins.ElementAt(y).Username & input.ElementAt(1) == allAdmins.ElementAt(y).Password)
                { //if the login information entered on the main program matches information for an admin user on the system, return that the user is of 'Admin' role
                    return true;
                }
                else
                {
                    y++;
                }
            }
            return false;
        }
    }
}
