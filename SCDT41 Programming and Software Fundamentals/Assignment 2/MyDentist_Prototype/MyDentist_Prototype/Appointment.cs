using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    class Appointment
    {
        string appointmentID;
        Patient patient;
        Dentist dentist;
        Treatment treatment;
        Practice practice;
        string room;
        DateTime date;
        Appointment_Note note;

        public Appointment(string appointmentID, Patient patient, Dentist dentist, Treatment treatment, Practice practice, string room, DateTime date, Appointment_Note note)
        { //Object for appointments
            this.appointmentID = appointmentID;
            this.patient = patient;
            this.dentist = dentist;
            this.treatment = treatment;
            this.practice = practice;
            this.room = room;
            this.date = date;
            this.note = note;
        }
        public string AppointmentID { get => appointmentID; set => appointmentID = value; }
        public Patient Patient{ get => patient; set => patient = value; }
        public Dentist Dentist { get => dentist; set => dentist = value; }
        public Treatment Treatment { get => treatment; set => treatment = value; }
        public Practice Practice { get => practice; set => practice = value; }
        public string Room { get => room; set => room = value; }
        public DateTime Date { get => date; set => date = value; }
        public Appointment_Note Note { get => note; set => note = value; }

        protected static List<Appointment> allApointments = new List<Appointment>() //List of all appointments stored in the system
        {
            new Appointment("00000",new Patient("67890","EXAMPLE","SURNAME","","","","","","000001111"),new Dentist("GHJKL","USERNAME","password","DENTIST","SURNAME"), new Treatment("TREAT1","Band 1","22.70","Check-ups, scale, polich, etc."),new Practice("ABCDE","TAUNTON",1,new Dictionary<string, Dentist>(),new Dictionary<string, Nurse>(), new Receptionist("","","","","")),"1",DateTime.Now,null) //Example Appointment
        };

        public static bool newAppointment(Practice x) //Method to create a new appointment
        {
            Console.WriteLine(Environment.NewLine + "Enter the Details for the Appointment Below:" + Environment.NewLine);

            Console.Write("The ID of the Patient: ");
            string patientID = Console.ReadLine().ToUpper();
            Patient patient = Patient.checkPatient(patientID); //checks if inputted ID matches a patient on the system
            if(patient == null) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Environment.NewLine + "Error | Patient not found");
                Console.ForegroundColor = ConsoleColor.White;
                return false; }

            Console.Write("The ID of the Dentist: ");
            string dentistID = Console.ReadLine().ToUpper();
            Dentist dentist = Dentist.roomDentist(dentistID); //checks if inputted ID matches a Dentist on the system
            if(dentist == null) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Environment.NewLine + "Error | Dentist not found");
                Console.ForegroundColor = ConsoleColor.White;
                return false; }

            Console.Write("The ID of the Treatment: ");
            string treatmentID = Console.ReadLine().ToUpper();
            Treatment treatment = Treatment.checkTreatment(treatmentID); //checks if inputted ID matches a treatment on the system
            if(treatment == null) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Environment.NewLine + "Error | Treatment not found");
                Console.ForegroundColor = ConsoleColor.White;
                return false; }

            Practice pracitce = x;

            Console.Write("Designated Room Number: ");
            string room = Console.ReadLine().ToUpper();
            if(int.Parse(room) > x.RoomCount) //Checks if the inputted room number exists in the current practice
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Environment.NewLine + "Error | Could not find specified Room");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }

            Console.Write("Date for the Appointment: ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Time of the Appointment: ");
            DateTime time = Convert.ToDateTime(Console.ReadLine());
            date = date.Date.Add(time.TimeOfDay); //combines inputted date and time into a single variable

            string ID = Guid.NewGuid().ToString(); //Generates a unique 5 digit ID for the Appointment ID
            char[] idCharacters = ID.Take(5).ToArray();
            ID = new string(idCharacters).ToUpper();

            allApointments.Add(new Appointment(ID, patient, dentist, treatment, pracitce, room, date, new Appointment_Note("",new Dentist("","","","",""),new Nurse("","","","",""), DateTime.Parse("")))); //adds user's inputted information as a new appointment
            return true;
        }

        public static void displayAppointments() //method to output all appointments on the system
        {
            foreach(var a in allApointments)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Appointment ID: {0}", a.AppointmentID);
                Console.WriteLine("Patient: {0}, {1}", a.Patient.Surname, a.Patient.FirstName);
                Console.WriteLine("Patient Contact Number: {0}", a.Patient.PhoneNumber);
                Console.WriteLine("Dentist: Dr {0}", a.Dentist.Surname);
                Console.WriteLine("Treatment: {0} ({1})", a.Treatment.Name, a.Treatment.Details);
                Console.WriteLine("Practice: {0}", a.Practice.Location);
                Console.WriteLine("Treatment Room: {0}", a.Room);
                Console.WriteLine("Date: {0}", a.Date);
                if (a.Note != null)
                {
                    if (a.Note.Dentist == null)
                    {
                        Console.WriteLine("Addittional Notes: {0} ({1} {2}, {3})", a.Note.Note, a.Note.Nurse.Surname, a.Note.Nurse.FirstName, a.Note.When);
                    }
                    else if (a.Note.Nurse == null)
                    {
                        Console.WriteLine("Addittional Notes: {0} ({1} {2}, {3})", a.Note.Note, a.Note.Dentist.Surname, a.Note.Dentist.FirstName, a.Note.When);
                    }
                }
                Console.WriteLine("------------------------------------");
            }
        }

        protected static Appointment checkID(string x) //method to check if a appointment exists on the system
        {
            foreach(var a in allApointments)
            {
                if(x == a.AppointmentID) { return a; }
            }
            return null;
        }

        public static bool addNote(List<string> login) //method for dentists/nurses to add a note an existing appointment
        {
            Console.Write("Enter the ID of the Appointment to attach a note to: ");
            string appointmentID = Console.ReadLine().ToUpper();

            Appointment y = checkID(appointmentID);

            if (y == null) { return false; }

            Console.WriteLine("Enter the Note to be attached:");
            string note = Console.ReadLine();

            if (login.ElementAt(1) == "Dentist") //if the user is a dentist
            {
                Dentist dentist = Dentist.loginInformation(login);
                foreach (var a in allApointments)
                {
                    if (y.AppointmentID == a.AppointmentID) { a.Note = new Appointment_Note(note, dentist, null, DateTime.Now);} //add note to appointment
                }
            }
            else if (login.ElementAt(1) == "Nurse") //if the user is a nurse
            {
                Nurse nurse = Nurse.loginInformation(login);
                foreach (var a in allApointments)
                {
                    if (y.AppointmentID == a.AppointmentID) { a.Note = new Appointment_Note(note, null, nurse, DateTime.Now); } //add note to appointment
                }
            }
            return true;
        }

        public static void patientCheck(Patient_User user)
        {
            foreach(var a in allApointments)
            {
                if(a.Patient == user.Patient)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Appointment ID: {0}", a.AppointmentID);
                    Console.WriteLine("Dentist: Dr {0}", a.Dentist.Surname);
                    Console.WriteLine("Treatment: {0} ({1})", a.Treatment.Name, a.Treatment.Details);
                    Console.WriteLine("Practice: {0}", a.Practice.Location);
                    Console.WriteLine("Treatment Room: {0}", a.Room);
                    Console.WriteLine("Date: {0}", a.Date);
                    Console.WriteLine("------------------------------------" + Environment.NewLine);
                }
            }
        }
    }
}
