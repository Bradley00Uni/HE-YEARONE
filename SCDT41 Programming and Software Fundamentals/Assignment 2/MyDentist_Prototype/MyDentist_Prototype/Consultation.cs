using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    class Consultation
    {
        public static List<Consultation> allConsultations = new List<Consultation>(); //list of all phone consultations

        string consultationID;
        string phone;
        Patient patient;
        Dentist dentist;
        DateTime date;
        Ticket ticket;
        Practice practice;


        public Consultation(string consultationID, string phone, Patient patient, Dentist dentist, DateTime date, Ticket ticket, Practice practice)
        {
            this.consultationID = consultationID;
            this.phone = phone;
            this.patient = patient;
            this.dentist = dentist;
            this.date = date;
            this.ticket = ticket;
            this.practice = practice;
        }
        public string ConsultationID { get => consultationID; set => consultationID = value; } //System used to access and modify the different properites of the object
        public string Phone { get => phone; set => phone = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public Dentist Dentist { get => dentist; set => dentist = value; }
        public DateTime Date { get => date; set => date = value; }
        public Ticket Ticket { get => ticket; set => ticket = value; }
        public Practice Practice { get => practice; set => practice = value; }

        public static bool newConsultation(Receptionist receptionist) //method to create a new phone consultation appointment
        {
            DateTime date;
            Practice practice = Practice.checkReceptionist(receptionist); //sets the practice for the consultation to that of the current receptionist

            Ticket.receptionistView(practice);
            Console.Write(Environment.NewLine + "Enter the ID of the Request to create a Consultation for: ");
            string chosenID = Console.ReadLine().ToUpper();
            Ticket ticket = Ticket.checkTicket(chosenID); //the request ticket for the phone consultation
            if(ticket == null)
            {
                Console.WriteLine("Error | Unrecognised ID");
                return false;
            }
            Console.WriteLine("Requested Date: {0}", ticket.Day , Environment.NewLine);
            Console.WriteLine("Fill in the Required details for the Consultation: ");
            Console.WriteLine("Patient: {0}, {1}", ticket.Patient.Surname, ticket.Patient.FirstName); //uses information in patient ticket to autofill information
            Console.WriteLine("Dentist: Dr {0}", ticket.Dentist.Surname);
            Console.WriteLine("Contact Details: {0} | {1}", ticket.Patient.PhoneNumber, ticket.Email);
            Console.Write("Consultation Date (dd/mm/yyyy): ");
            string conDate = Console.ReadLine();
            try
            {
                date = DateTime.Parse(conDate); //checks if the inputted date is in an accepted format
            }
            catch
            {
                Console.WriteLine("Error | Incorrect Date Format"); //value validation for date input
                return false;
            }
            Console.Write("Consultation Time (hh/mm): ");
            string conTime = Console.ReadLine();
            try
            {
                date = date.Date.Add(DateTime.Parse(conTime).TimeOfDay); //checks if the inputted time is in an accepted format, combines the inputted date and time into a single variable
            }
            catch
            {
                Console.WriteLine("Error | Incorrect Time Format");
                return false;
            }

            string ID = Guid.NewGuid().ToString(); //Generates a unique 5 digit ID for the Consultation ID
            char[] idCharacters = ID.Take(5).ToArray();
            ID = new string(idCharacters).ToUpper();

            allConsultations.Add(new Consultation(ID, ticket.Patient.PhoneNumber, ticket.Patient, ticket.Dentist, date, ticket, practice)); //adds the new consultation to the list of all on the system
            return true;
        }

        public static void patientView(Patient_User u) //patient method to view all current consultations
        {
            foreach(var c in allConsultations)
            {
                if(c.Patient == u.Patient)
                {
                    Console.WriteLine(Environment.NewLine + "------------------------------------");
                    Console.WriteLine("Consultation Date: {0}", c.Date.Date);
                    Console.WriteLine("Consultation Time: {0}", c.Date.TimeOfDay);
                    Console.WriteLine("Dentist: Dr {0}", c.Dentist.Surname);
                    Console.WriteLine("Contact Number: {0}", c.Patient.PhoneNumber);
                    Console.WriteLine("------------------------------------");
                }
            }
        }

        public static void receptionistView(Practice p) //receptionist method to view all current consultations
        {
            foreach(var c in allConsultations)
            {
                if(p == c.Practice)
                {
                    Console.WriteLine(Environment.NewLine + "------------------------------------");
                    Console.WriteLine("Consultation Date: {0}", c.Date.Date);
                    Console.WriteLine("Consultation Time: {0}", c.Date.TimeOfDay);
                    Console.WriteLine("Dentist: Dr {0}", c.Dentist.Surname);
                    Console.WriteLine("Patient {0}, {1}", c.Patient.Surname, c.Patient.FirstName);
                    Console.WriteLine("Contact Number: {0}", c.Patient.PhoneNumber);
                    Console.WriteLine("------------------------------------");
                }
            }
        }

        public static void dentistView(Dentist d) //dentist method to view all current phone consultations
        {
            foreach(var c in allConsultations)
            {
                if (d == c.Dentist)
                {
                    Console.WriteLine(Environment.NewLine + "------------------------------------");
                    Console.WriteLine("Consultation Date: {0}", c.Date.Date);
                    Console.WriteLine("Consultation Time: {0}", c.Date.TimeOfDay);
                    Console.WriteLine("Patient {0}, {1}", c.Patient.Surname, c.Patient.FirstName);
                    Console.WriteLine("Contact Number: {0}", c.Patient.PhoneNumber);
                    Console.WriteLine("------------------------------------");
                }
            }
        }
    }
}
