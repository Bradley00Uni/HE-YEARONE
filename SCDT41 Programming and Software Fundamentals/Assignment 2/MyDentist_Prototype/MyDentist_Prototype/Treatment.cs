using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    class Treatment
    {
        string treatmentID;
        string name;
        string price;
        string details;

        public Treatment(string treatmentID, string name, string price, string details) //object for each treatment
        {
            this.treatmentID = treatmentID;
            this.name = name;
            this.price = price;
            this.details = details;
        }
        public string TreatmentID { get => treatmentID; set => treatmentID = value; }
        public string Name { get => name; set => name = value; }
        public string Price { get => price; set => price = value; }
        public string Details { get => details; set => details = value; }

        protected static List<Treatment> allTreatments = new List<Treatment> //list of all treatments
        {
            new Treatment("TREAT1","Band 1","22.70","Check-ups, scale, polich, etc."),
            new Treatment("TREAT2","Band 2","62.10","Fillings, repairs, etc."),
            new Treatment("TREAT3","Band 3","269.30","Crowns and other procedures")
        };

        public static void treatmentDisplay() //method to display all treatments
        {
            Console.WriteLine(Environment.NewLine + "Treatments Available:");
            foreach(var t in allTreatments)
            {
                Console.WriteLine("{0} | {1} | £{2} | {3}", t.TreatmentID, t.Name, t.Price, t.Details);
            }
        }

        public static Treatment checkTreatment(string inputID) //method to check if treatment exsists
        {
            foreach(var t in allTreatments)
            {
                if(inputID == t.treatmentID)
                {
                    return t; //return matching treatment
                }
            }
            return null;
        }

        public static bool newTreatment() //Method to create a new Treatment
        {
            double price;

            Console.Write("Enter the Band Name for the Treatments offered: ");
            string band = Console.ReadLine().ToUpper();
            Console.Write("Enter the Price for the Treatment: £");
            string priceString = Console.ReadLine();
            try
            {
                price = Convert.ToDouble(priceString); //Validates if input can be convereted into a numerical value
            }
            catch
            {
                Console.WriteLine("Error | Incorrect Price Format");
            }
            Console.Write("Enter the details of what this treatment band Entails: ");
            string details = Console.ReadLine();

            foreach(var b in allTreatments)
            {
                if(b.Name == band)
                {
                    Console.WriteLine("Error | Treatment already Exists"); //error message if the new treatment matches one that already exists
                    return false;
                }
            }

            string ID = Guid.NewGuid().ToString(); //Generates a unique 5 digit ID for the Treatment ID
            char[] idCharacters = ID.Take(5).ToArray();
            ID = new string(idCharacters).ToUpper();

            allTreatments.Add(new Treatment(ID, band, priceString, details)); //adds this new treatment to the list of all current treatments on the system
            return true;
        }
    }
}
