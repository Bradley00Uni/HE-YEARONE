using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task2
{
    class SpellingList
    {
        static Dictionary<string, string> quizWords = new Dictionary<string, string>() //Storage off all quiz Questions & Answers
        {
            {"The second month in the year is:","FEBRUARY"},
            {"When you have made your mind up, you have:","DECIDED"},
            {"If something is not boring, it is:","INTERESTING"},
            {"Not all the time but:","SOMETIMES"},
            {"Not the same but:","DIFFERENT"}
        };
        static List<char> quizHints = new List<char>(); //Stores the Hints for the questions
        public static void generateHints()
        {
            //Generates hints by taking the first letter of each word
            int z = 0;
            do
            {
                char newHint = quizWords.Values.ElementAt(z)[0];
                quizHints.Add(newHint);
                z = z + 1;
            } while (z != quizWords.Keys.Count);
        }
        static int questionNumber = 0;
        static int studentScore = 0;

        public static bool addWord() //Method to add a new Question
        {
            Console.WriteLine("Enter the question to be Asked");
            string question = Console.ReadLine(); //Sets Teacher input as new question to be asked
            if (question.Length < 1) //If nothing is entered, Display error message
            {
                Console.WriteLine("No Input detected | Request Failed | Please Try Again");
                return false;
            }

            Console.WriteLine("Enter the Answer to the above Question");
            string answer = Console.ReadLine().ToUpper(); //Sets Teacher Input as new answer for the question
            if (answer.Length < 1) //If nothing is entered, Display error message
            {
                Console.WriteLine("No Input detected | Request Failed | Please Try Again");
                return false;
            }
            quizWords.Add(question, answer); //Adds the entered Question & Answer to the quiz
            quizHints.Add(answer[0]); //Adds the Question's hint to the list of hints
            return true;
        }

        public static bool removeWord() //Method to remove a Question
        {
            int check = 0;

            Console.WriteLine("Enter a word to delete from the quiz");
            string choice = Console.ReadLine().ToUpper(); //Stores Teacher Input as word to remove

            do
            {
                if(choice == quizWords.Values.ElementAt(check)) //If the entered word is found in the system
                {
                    string removeQuestion = quizWords.Keys.ElementAt(check);
                    quizWords.Remove(removeQuestion); //remove the question and answer
                    return true;
                }
                check++;
            } while (check != quizWords.Keys.Count);
            return false;
        }

        public static void quizOutput() //method to output all questions and answers
        {
            int count = 0;
            do
            {
                Console.WriteLine("{0}  {1}", quizWords.Keys.ElementAt(count), quizWords.Values.ElementAt(count)); //Display all Questions and Answers in the system
                count++;
            } while (count != quizWords.Keys.Count);
            
        }

        public static List<double> studentGuess() //Method for checking student's guess against stored answer
        {
            SpellingList.generateHints(); //calls the method to generate hints
            bool hintUsed = false;
            do
            {
                if (hintUsed == true) //If student has requested hint
                {
                    Console.WriteLine("First Letter Hint: {0}", quizHints.ElementAt(questionNumber)); //display the first letter of the current answer
                }

                Console.WriteLine(quizWords.Keys.ElementAt(questionNumber)); //Asks the next question

                if (hintUsed == false) //If user hasn't already asked for a hint for this question
                { Console.WriteLine("Type 'Hint' to get a hint | Warning! Doing so will cost you a point of your score"); } //Let the user know that they can request a hint

                string studentAnswer = Console.ReadLine().ToUpper(); 
                string correctAnswer = quizWords.Values.ElementAt(questionNumber);
                int characterLetter = 0;
                int wordScore = 10; //Sets maximum score possible for each word
                int wrongScore = 0;

                if (studentAnswer == "HINT")
                {
                    hintUsed = true;
                    studentScore = studentScore - 1; //If hint has been used, deduct a point from the student's total score
                }
                else
                {
                    char[] guessCharacters;
                    guessCharacters = studentAnswer.ToCharArray(0, studentAnswer.Length); //Seperates each character of student's answer into a character array
                    char[] answerCharacters;
                    answerCharacters = correctAnswer.ToCharArray(0, correctAnswer.Length); //Seperates each chatacter of the correct answer into a charatcer array
                    do
                    {
                        if (guessCharacters.ElementAt(characterLetter) == answerCharacters.ElementAt(characterLetter)) //if the current letter from each char array match
                        {
                            characterLetter++; //move onto next letter
                        }
                        else if (guessCharacters.ElementAt(characterLetter) != answerCharacters.ElementAt(characterLetter)) //if the two letters don't match
                        {
                            characterLetter++; //move onto next letter
                            wrongScore++; //increase the count of incorrect letters
                        }
                    } while (characterLetter != studentAnswer.Length);
                    Console.WriteLine("The correct answer is: {0}", correctAnswer + Environment.NewLine); //Display the correct answer for the question

                    if (wrongScore >= (correctAnswer.Length / 2) | studentAnswer.Length <= (correctAnswer.Length / 2)) //If the number of incorrect letters is at least half the length of the current correct answer
                    {
                        wrongScore = 10; //inncorect letters count is set to max
                    }
                    wordScore = wordScore - wrongScore; //score for this word is calculated through deducting a point for each incorrect letter from the maximum total score
                    studentScore = studentScore + wordScore; //add score for this word to the student's total score
                    questionNumber++;
                    hintUsed = false; //resets whether a hint has been used
                };
            } while (questionNumber != quizWords.Keys.Count); //runs until all questions have been asked

            List<double> calculatedScore = new List<double>();
            calculatedScore = SpellingList.scoreCalculation(studentScore); //passes the score of the student to the method for calculating the percentage
            return calculatedScore;
            
        }

        public static List<double>scoreCalculation(int totalScored) //method for calculating offical student score
        {

            double canScore = quizWords.Keys.Count * 10;
            List<double> scoreDecimal = new List<double>();
            scoreDecimal.Add(totalScored);
            scoreDecimal.Add (totalScored / canScore); //converts student score for use in Student class
            return scoreDecimal;
        }
    }
}
