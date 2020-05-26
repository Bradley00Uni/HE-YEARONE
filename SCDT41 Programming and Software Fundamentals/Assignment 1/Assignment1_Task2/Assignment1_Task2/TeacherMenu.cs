using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task2
{
    class TeacherMenu
    {
        static List<string> teacherOptions = new List<string>() //Stores all possible options for the menu choice
         {
             "V","S","R","A","Q","D","X"
         };

        public static void teacherMenu()
        {
            bool loopBreak = false;

            do
            {
                Console.WriteLine(""); //Lists out all options for the teacher Menu
                Console.WriteLine("What would you like to do?" + Environment.NewLine);
                Console.WriteLine("Press V to: view all of the students currently enrolled");
                Console.WriteLine("Press S to: enroll an additional student");
                Console.WriteLine("Press R to: remove a student from the class");
                Console.WriteLine("Press A to: view all questions & answers");
                Console.WriteLine("Press Q to: add another question to the quiz");
                Console.WriteLine("Press D to: remove a question from the quiz");
                Console.WriteLine("Press X to: exit the software" + Environment.NewLine);
                string choice = Console.ReadLine().ToUpper(); //Stores the user's choice

                choice = teacherChoice(choice);

                if (choice == "V")
                {
                    SchoolLogins.studentList(); //Call the method to view all users
                }
                else if (choice == "S")
                {
                    SchoolLogins.addStudent(); //Call the methods to add a user
                }
                else if (choice == "R")
                {
                    SchoolLogins.removeStudent(); //Calls the methods to remove a student 
                }
                else if (choice == "A")
                {
                    SpellingList.quizOutput(); //Calls the method to view all questions and correct answers
                }
                else if (choice == "Q")
                {
                    SpellingList.addWord(); //Calls the method to a question & answer
                }
                else if (choice == "D")
                {
                    SpellingList.removeWord(); //Calls the method to remove a question & answer
                }
                else if (choice == "X")
                {
                    System.Environment.Exit(1); //Closes the software
                }
                else
                {
                    Console.WriteLine("Unknown Input Detected | Try again" + Environment.NewLine); //If the user's choice doesn't match, return an error
                }

            } while (loopBreak == false);
        }

        static string teacherChoice(string choice) //checks the user input and converts it to a format that can be checked in the above method
        {
            int y = 0;
            bool loopBreak = false;

            do
            {
                if (y == teacherOptions.Count)
                {
                    loopBreak = true;
                }
                else if (choice == teacherOptions.ElementAt(y))
                {
                    return choice;
                }
                else
                {
                    y = y + 1;
                }
            } while (loopBreak == false);
            return null;
        }
    }
}
