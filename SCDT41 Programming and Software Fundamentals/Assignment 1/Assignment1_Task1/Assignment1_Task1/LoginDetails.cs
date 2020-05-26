using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task1
{
    class LoginDetails
    {
        static Dictionary<string, string> loginData = new Dictionary<string, string>() //Storage of all user login data
        {
            {"USERNAME","password"}
        };

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
    }
}
