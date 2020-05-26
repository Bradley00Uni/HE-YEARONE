using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    class Ticket
    {
        public static List<Ticket> allTickets = new List<Ticket>(); //list of all tickets on system
            
        string ticketID;
        Patient patient;
        Dentist dentist;
        DateTime day;
        string email;
        Practice practice;

        public Ticket(string ticketID, Patient patient, Dentist dentist, string email, DateTime day, Practice practice)
        {
            this.ticketID = ticketID;
            this.patient = patient;
            this.dentist = dentist;
            this.day = day;
            this.email = email;
            this.practice = practice;
        }
        public string TicketID { get => ticketID; set => ticketID = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public Dentist Dentist { get => dentist; set => dentist = value; }
        public DateTime Day { get => day; set => day = value; }
        public string Email { get => email; set => email = value; }
        public Practice Practice { get => practice; set => practice = value; }

        public static bool newTicket(Patient_User user) //method to create new ticket by patients
        {
            Console.Write("Enter the location of your regular practice: ");
            string userPractice = Console.ReadLine().ToUpper();
            Practice x = Practice.checkLocation(userPractice);
            if(x == null)
            {
                Console.WriteLine("Error | Practice not found");
                return false;
            }
            Practice.viewDentists(x);
            Console.Write(Environment.NewLine + "Enter the ID of your desired Dentist: ");
            string dentistID = Console.ReadLine().ToUpper();
            Dentist dentist = Dentist.roomDentist(dentistID);
            Patient patient = user.Patient;
            Console.WriteLine("Please enter a date that would be convenient");
            Console.WriteLine("Please Note, this date is not garunteed, but acts merely as a guidline for when would be best: ");
            Console.Write("Date (dd/mm/yyyy): ");
            string y = Console.ReadLine().ToUpper();
            DateTime day;
            try
            {
                day = Convert.ToDateTime(y);

            }
            catch
            {
                Console.WriteLine("Error | Unreadable Date");
                return false;
            }
            Console.WriteLine("Please enter an email address for updates on your Phone Consultation: ");
            string email = Console.ReadLine();

            string ticketID = Guid.NewGuid().ToString(); //Generates a unique 5 digit ID for the Practice ID
            char[] idCharacters = ticketID.Take(5).ToArray();
            ticketID = new string(idCharacters).ToUpper();

            allTickets.Add(new Ticket(ticketID, patient, dentist, email, day, x));
            Console.WriteLine("Your Consultation appointment has been requested | Be sure to check your email for any updates");
            return true;
        }

        public static void viewTickets(Patient_User user) //method to view all of a patient's active tickets
        {
            foreach(var t in allTickets)
            {
                if(user.Patient == t.Patient)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Requested Day: {0}", t.Day.Day);
                    Console.WriteLine("Requested Dentist: Dr {0}", t.Dentist.Surname);
                    Console.WriteLine("Provided Email: {0}",t.Email);
                    Console.WriteLine("------------------------------");
                }
            }
        }

        public static void receptionistView(Practice p) //receptionist method to view all current tickets
        {
            foreach(var t in allTickets)
            {
                if(t.Practice == p)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("Request ID: {0}", t.TicketID);
                    Console.WriteLine("Requested Day: {0}", t.Day);
                    Console.WriteLine("Requested Dentist: Dr {0}", t.Dentist.Surname);
                    Console.WriteLine("Requested By: {0} {1} (ID: {2})", t.Patient.FirstName, t.Patient.Surname, t.Patient.PatientID);
                    Console.WriteLine("Provided Email: {0}", t.Email);
                    Console.WriteLine("----------------------------------");
                }
            }
        }

        public static Ticket checkTicket(string i) //method to validate a ticket ID
        {
            foreach(var t in allTickets)
            {
                if(i == t.TicketID)
                {
                    return t;
                }
            }
            return null;
        }
    }
}
