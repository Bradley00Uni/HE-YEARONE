using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    class Patient_User
    {
        Patient patient;
        string username;
        string password;
        public static List<Patient_User> allUsers = new List<Patient_User>()
        { new Patient_User(new Patient("12345","Bradley","De'Ath","","","","","",""),"USERNAME","password")
        };

        public Patient_User(Patient patient, string username, string password) //New Patient Object
        {
            this.patient = patient;
            this.username = username;
            this.password = password;
        }
        public Patient Patient { get => patient; set => patient = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public static bool checkUser(string input) //Validates if user details already exisit on system
        {
            foreach(var u in allUsers)
            {
                if(input == u.Username) { return false; }
            }
            return true;
        }

        public static void addUser(Patient_User newUser) //Method for creating new user login
        {
            allUsers.Add(newUser);
            Console.WriteLine("Account Successfully Created");
        }

        public static Patient_User loginCheck(List<string> x) //checks login credentials of user
        {
            foreach(var l in allUsers)
            {
                if(x.ElementAt(0) == l.Username & x.ElementAt(1) == l.Password)
                {
                    return l;
                }              
            }
            Console.WriteLine("Error | Incorrect Login, Please Try Again"); //return error
            return null;
        }
    }
}
