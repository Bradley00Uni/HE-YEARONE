using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loopBreak = false;

            Console.WriteLine("Welcome to the Spelling Quiz"); //Welcomes the user to the system
            Console.WriteLine("Please Log in to use the system");

            do
            {
                Console.WriteLine("Please enter your Username"); 
                string usernameInput = Console.ReadLine().ToUpper(); //Saves the user's entered Username

                Console.WriteLine("Please enter your Password");
                string passwordInput = Console.ReadLine(); //Saves the user's entered Password

                List<string> loginInput = new List<string>(2)
                {
                    usernameInput,passwordInput //Saves both of the user inputs as a List
                };
                string userRole = SchoolLogins.detailsCheck(loginInput); //Passes the inputs to a method to check if they are recognised

                if (userRole == "Teacher") //If the user is recognised and is a teacher
                {                    
                    List<string> teacherName = new List<string>();
                    teacherName = SchoolLogins.userName();
                    Console.WriteLine("Welcome: {0} {1}", teacherName.ElementAt(0), teacherName.ElementAt(1) + Environment.NewLine); //Personalised Welcome Message
                    TeacherMenu.teacherMenu(); //Loads the Teacher Menu for the Software
                }
                else if (userRole == "Student") //If the user is recognised and is a student
                {
                    List<string> studentName = new List<string>();
                    studentName = SchoolLogins.userName();
                    Console.WriteLine("Welcome: {0} {1}", studentName.ElementAt(0), studentName.ElementAt(1)); //Personalised Weclome Message
                    StudentMenu.startQuiz(); //Loads the Quiz
                }
                else //If the user is unrecognised
                {
                    loopBreak = false; //Resets the Loop
                    Console.WriteLine("Error | User not found | Please try Again" + Environment.NewLine);
                }

            } while (loopBreak == false);
        }
    }
}
