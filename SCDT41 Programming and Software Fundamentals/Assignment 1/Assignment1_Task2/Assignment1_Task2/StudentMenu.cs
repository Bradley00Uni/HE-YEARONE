using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task2
{
    class StudentMenu
    {
        public static void startQuiz() //Method to run the spelling quiz
        {
            Console.WriteLine("Welcome to the School Spelling Quiz" + Environment.NewLine + "Press Enter to begin" + Environment.NewLine); //Welcomes the user
            Console.ReadLine();
            List<double> decimalScore = SpellingList.studentGuess(); //Calls the method to run through each question in the quiz
            Console.WriteLine("");
            Console.WriteLine("You got A Scrore of {0} ({1}%)", decimalScore.ElementAt(0), decimalScore.ElementAt(1) * 100); //Displays the users score as a total and a percentage
            Console.ReadLine();
            System.Environment.Exit(1);


        }
    }
}
