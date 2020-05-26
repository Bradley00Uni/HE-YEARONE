using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task1
{
    class CoachDetails
    {
        public static void coachPassengers()
        {
            int x = 0;
            int[,] Passengers = new int[3, 5] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } }; //A multi-dimensional array for storing passengers: The first row contains pre-booked passengers, the second contains passengers that paid on arrival and the third is the two previous added together (The total)
            string[] Coaches = new string[5] { "A", "B", "C", "D", "E" }; //Array containing the designations for each coach of the train
            Dictionary<string, int> Filled_Coaches = new Dictionary<string, int>();

            for (int loop_1 = 0; loop_1 < 5; loop_1++)
            {
                Console.Write("Enter the number of passengers pre-booked for Coach {0} : ", Coaches[x]); //cycles through until all coaches have been checked
                string User_Input = Console.ReadLine();
                Passengers[0, x] = int.Parse(User_Input); //Stores input as number of passengers that pre-booked for current coach
                x = x + 1;
                Console.WriteLine(Environment.NewLine);
            }
            x = 0;

            for (int loop_2 = 0; loop_2 < 5; loop_2++)
            {
                Console.Write("Enter the number of passengers that paid on arrival for Coach {0} : ", Coaches[x]); //cycles through until all coaches have been checked
                Passengers[1, x] = int.Parse(Console.ReadLine()); //Stores input as number of passengers that paid on arrival for current coach
                Passengers[2, x] = Passengers[0, x] + Passengers[1, x]; //calculates passenger total for current coach by adding two previous inputs for said coach together
                Filled_Coaches.Add(Coaches[x], Passengers[2, x]); //stores passenger total
                x = x + 1;
                Console.WriteLine(Environment.NewLine);
            }

            foreach (KeyValuePair<string, int> coaches in Filled_Coaches.OrderBy(key => key.Value)) //generates new key order based on value amount 
            {
                Console.WriteLine("Coach: {0} | Passengers: {1}", coaches.Key, coaches.Value); //displays all coaches and their passenger totals in ascending order
            }
            Console.ReadLine();
        }
    }
}
