using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task2
{
    class SchoolLogins
    {
        static Dictionary<string, string> userLogins = new Dictionary<string, string>() //Storage of the Login details of the users
        {
            {"EXAMPLESTUDENT","password"},
            {"EXAMPLETEACHER","password"}
        };
        static Dictionary<string, string> userNames = new Dictionary<string, string>() //Storage of the Names of the users
        {
            {"Example","Student"},
            {"Mr.","Example"}
        };
        static List<bool> userIsTeacher = new List<bool>() //Bool to signify whether each user is a student or teacher
        {
            false, true
        };
        static int userCounter = 0;

        public static string detailsCheck(List<string> details) //Checks the user input from program to see if they are recognised
        {
            bool loopBreak = false;

            do
            {

                if(userCounter == userLogins.Count) //If every recognised login has been checked, return that there was no match
                {
                    loopBreak = true; //end the loop
                    userCounter = 0;
                }
                else if(details.ElementAt(0) == userLogins.Keys.ElementAt(userCounter) & details.ElementAt(1) == userLogins.Values.ElementAt(userCounter)){ //If both the username and password match
                    switch (userIsTeacher.ElementAt(userCounter))
                    {
                        case true: //If the user is a teacher, return that to the 'program' class
                            return "Teacher"; 
                        case false: //If the user is a student, return that to the 'program' class
                            return "Student";
                    }
                }
                else
                {
                    userCounter = userCounter + 1; //increase the placement in the dictonary to check, increments by 1 each time
                }

            } while (loopBreak == false);
            return null;
        }

        public static List<string> userName()
        {
            List<string> currentUser = new List<string>()
            {
                userNames.Keys.ElementAt(userCounter), userNames.Values.ElementAt(userCounter) //Calls the full name of the curent user for display in the welcome message
            };
            return currentUser;
            
        }

        public static void studentList() //outputs a list of all students
        {
            int x = 0;
            do
            {
                if (userIsTeacher.ElementAt(x) == false) //If the user is not a student
                {
                    Console.WriteLine("{0} , {1}   |   {2}", userNames.Values.ElementAt(x), userNames.Keys.ElementAt(x), userLogins.Keys.ElementAt(x)); //Display all students, with their names and username
                    x = x + 1; //location increases, increments by 1
                }
                else
                {
                    x = x + 1;
                }
            } while (x != userLogins.Keys.Count); //Runs until all stored user details are displayed
        }

        public static bool addStudent() //The method to add new students to the system
        {
            bool loopBreak = false;
            string firstName;
            string secondName;
            string userName;
            string password;

            do
            {
                Console.WriteLine("Enter the Student's First Name");
                firstName = Console.ReadLine().ToUpper(); //Saves the input as the new student's first name
                if (firstName.Length < 1)
                {
                    Console.WriteLine("Error | No Input Detected | Try Again"); //If nothing is entered, display an error 
                    return false;
                }

                Console.WriteLine("Enter the Student's Surname");
                secondName = Console.ReadLine().ToUpper(); //Saves the input as the new student's surname
                if (secondName.Length < 1)
                {
                    Console.WriteLine("Error | No Input Detected | Try Again"); //If nothing is entered, display an error
                    return false;
                }

                Console.WriteLine("Enter the Student's new Username");
                userName = Console.ReadLine().ToUpper(); //Saves the input as the new student's username
                if (userName.Length < 1)
                {
                    Console.WriteLine("Error | No Input Detected | Try Again"); //If nothing is entered, display an error
                    return false;
                }

                Console.WriteLine("Enter the Student's new Password");
                password = Console.ReadLine(); //Saves the input as the new student's password
                if (password.Length < 1)
                {
                    Console.WriteLine("Error | No Input Detected | Try Again"); //If nothing is entered, display an error
                    return false;
                }
                loopBreak = true;
            } while (loopBreak == false);

            userNames.Add(firstName, secondName); //Saves the entered Username and Password to the system
            userLogins.Add(userName, password); //Saves the entered First and Last Name to the system
            userIsTeacher.Add(false); //Saves that the new user is a student

            return true;
        }

        public static bool removeStudent() //method used to remove students from the system
        {
            bool loopBreak = false;
            int x = 0;

            Console.WriteLine("Enter a username to delete from the system");
            string choice = Console.ReadLine().ToUpper(); //Saves the input as the desired username to delete

            do
            {
                if (x == userLogins.Keys.Count) //If every user has been checked without a match
                {
                    Console.WriteLine("Error | Could not find requested User"); //return an error and delete no users
                    return false;
                }
                else if (choice == userLogins.Keys.ElementAt(x)) //if a user has been found with a matching username
                {
                    userLogins.Remove(choice); 
                    choice = userNames.Keys.ElementAt(x);
                    userNames.Remove(choice);
                    bool toRemove = userIsTeacher.ElementAt(x);
                    userIsTeacher.Remove(toRemove); //remove all details from the system for that user
                    loopBreak = true;
                }
                else
                {
                    x = x + 1;
                }
            } while (loopBreak == false);
            return true;
        }

    }
}
