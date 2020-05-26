using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    class Patient
    {
        public static List<Patient> allPatients = new List<Patient>() { new Patient("12345", "EXAMPLE", "PATIENT", "", "", "", "", "", "075192835")};

        string patientID;
        string firstName;
        string surname;
        string houseNumber;
        string street;
        string town;
        string postcode;
        string gender;
        string phoneNumber;

        public Patient(string patientID, string firstName, string surname, string houseNumber, string street, string town, string postcode, string gender, string phoneNumber)
        { //object for all patients 
            this.patientID = patientID;
            this.firstName = firstName;
            this.surname = surname;
            this.houseNumber = houseNumber;
            this.street = street;
            this.town = town;
            this.postcode = postcode;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
        }
        public string PatientID { get => patientID; set => patientID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Surname { get => surname; set => surname = value; }
        public string HouseNumber { get => houseNumber; set => houseNumber = value; }
        public string Street { get => street; set => street = value; }
        public string Town { get => town; set => town = value; }
        public string Postcode { get => postcode; set => postcode = value; }
        public string Gender { get => gender; set => gender = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        

        public static bool addPatient() //method to add new patient to the system
        {
            string patientID;
            string firstName;
            string surname;
            string houseNumber;
            string street;
            string town;
            string postcode;
            string gender;
            string phoneNumber;

            Console.WriteLine("Enter the Patient's Details Below:" + Environment.NewLine);
            Console.Write("First Name: ");
            firstName = Console.ReadLine().ToUpper();
            Console.Write("Surname: ");
            surname = Console.ReadLine().ToUpper();
            Console.Write("Address | House Number: ");
            houseNumber = Console.ReadLine().ToUpper();
            Console.Write("Address | Street: ");
            street = Console.ReadLine().ToUpper();
            Console.Write("Address | Town: ");
            town = Console.ReadLine().ToUpper();
            Console.Write("Address | Postcode: ");
            postcode = Console.ReadLine().ToUpper();
            Console.Write("Gender : ");
            gender = Console.ReadLine().ToUpper();
            List<string> genderOptions = new List<string>() { "male", "female", "other" };

            int z = 0;
            foreach (var g in genderOptions)
            {                
                if(gender != g)
                {
                    z++;
                }
                if(z == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error | Unrecognised Input");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
            }

            Console.Write("Phone Number: ");
            phoneNumber = Console.ReadLine().ToUpper();

            foreach(var p in allPatients)
            {
                if(firstName == p.FirstName & surname == p.Surname & postcode == p.Postcode)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Environment.NewLine + "Error | Patient Already Exists");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }         
            }

            patientID = Guid.NewGuid().ToString(); //Generates a unique 5 digit ID for the patient ID
            char[] idCharacters = patientID.Take(5).ToArray();
            patientID = new string(idCharacters).ToUpper();

            allPatients.Add(new Patient(patientID, firstName, surname, houseNumber, street, town, postcode, gender, phoneNumber));
            return true; //add new patient based on the inputted information
        }

        public static void viewPatients() //method to display all patients on the system
        {
            foreach(var p in allPatients)
            {
                Console.WriteLine(Environment.NewLine + "{0} | {1} {2} | {3} | {4}, {5}, {6}, {7} | {8}", p.PatientID, p.FirstName, p.Surname, p.Gender, p.HouseNumber, p.Street, p.Town, p.Postcode, p.PhoneNumber);
            }
        }

        public static bool editPatient() //method to edit existing patient's information
        {
            Console.Write("Enter the ID of the Patient to Change: ");
            string changeID = Console.ReadLine().ToUpper();

            foreach(var p in allPatients)
            {
                if (changeID == p.patientID)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("{0} {1}: Current Information" + Environment.NewLine, p.FirstName, p.surname);
                    Console.WriteLine("Patient ID: {0}", p.PatientID);
                    Console.WriteLine("Gender: {0}", p.Gender);
                    Console.WriteLine("Address: {0}, {1}, {2}, {3}", p.HouseNumber, p.Street, p.Town, p.Postcode);
                    Console.WriteLine("Phone Number: {0}", p.PhoneNumber);
                    Console.WriteLine("------------------------------------");

                    Console.WriteLine(Environment.NewLine + "Enter the New Details Below:");
                    Console.Write("First Name: ");
                    string firstName = Console.ReadLine().ToUpper();
                    Console.Write("Surname: ");
                    string surname = Console.ReadLine().ToUpper();
                    Console.Write("Address | House Number: ");
                    string houseNumber = Console.ReadLine().ToUpper();
                    Console.Write("Address | Street: ");
                    string street = Console.ReadLine().ToUpper();
                    Console.Write("Address | Town: ");
                    string town = Console.ReadLine().ToUpper();
                    Console.Write("Address | Postcode: ");
                    string postcode = Console.ReadLine().ToUpper();
                    Console.Write("Gender : ");
                    string gender = Console.ReadLine().ToUpper();
                    Console.Write("Phone Number: ");
                    string phoneNumber = Console.ReadLine().ToUpper();

                    p.FirstName = firstName; //overwrites properties of selected patient
                    p.Surname = surname;
                    p.HouseNumber = houseNumber;
                    p.Street = street;
                    p.Town = town;
                    p.Postcode = postcode;
                    p.Gender = gender;
                    p.PhoneNumber = phoneNumber;
                }
            }
            return true;
        }

        public static Patient checkPatient(string inputID) //method to check if ID matches that of a patient
        {
            foreach(var i in allPatients)
            {
                if(inputID == i.PatientID)
                {
                    return i; //return matching patient
                }
            }
            return null;
        }

        public static Patient patientUser(string inputID) //Validates if a patient user's enterred referal ID matches that of an existing patient on the system
        {
            foreach(var p in allPatients)
            {
                if(inputID == p.patientID)
                {
                    return p;
                }               
            }
            Console.WriteLine("Error | Entered ID is not recognised"); //return error message
            return null;
        }


    }
}
