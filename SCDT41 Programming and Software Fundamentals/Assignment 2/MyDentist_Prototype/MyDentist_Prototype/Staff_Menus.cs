using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    class Staff_Menus
    {
        static bool constantMenu = false;

        public static List<string> loginBackup = new List<string>();

        public static void receptionistMenu(List<string> loginDetails) //initial menu for receptionists afer login
        {
            do
            {
                loginBackup = loginDetails;
                Receptionist currentLogin = Receptionist.loginInformation(loginDetails);
                Console.WriteLine(Environment.NewLine + "Receptionist Menu" + Environment.NewLine + "-----------------");
                Console.WriteLine("Type T to | Manage Treatments" + Environment.NewLine + "Type P to | Manage Patients" + Environment.NewLine + "Type A to | Manage Appointments" + Environment.NewLine + "Type X to | Exit the Software");
                string menuChoice = Console.ReadLine().ToUpper();

                switch (menuChoice)
                {
                    case "T":
                        receptionistTreatments(); //runs menu to manage treatments
                        break;
                    case "P":
                        receptionistPatients(); //loads menu to manage patients
                        break;
                    case "A":
                        receptionistAppointment(currentLogin); //loads menu to manage appointments
                        break;
                    case "X":
                        Environment.Exit(1); //closes the application
                        break;
                }
            } while (!constantMenu);
        }

        public static void receptionistPatients()  //menu for receptionists to manage patients
        {
            do
            {
                Console.WriteLine(Environment.NewLine + "Patient Management Menu" + Environment.NewLine + "----------------------");
                Console.WriteLine("Type A to | Add a Patient" + Environment.NewLine + "Type E to | Edit a Patient" + Environment.NewLine + "Type V to | View all Patients" + Environment.NewLine + "Type B to | Return to the Previous Menu");
                string menuChoice = Console.ReadLine().ToUpper();

                switch (menuChoice)
                {
                    case "A":
                        Patient.addPatient(); //calls method to add a new patient
                        break;
                    case "E":
                        Patient.editPatient(); //calls method to edit existing patient
                        break;
                    case "V":
                        Patient.viewPatients(); //calls method to view all patients on the system
                        break;
                    case "B":
                        receptionistMenu(loginBackup); //loads previous menu
                        break;
                }
            } while (!constantMenu);
        }

        public static void receptionistAppointment(Receptionist user) //menu for receptionists to manage appointments
        {
            do
            {
                Console.WriteLine(Environment.NewLine + "Appointment Management Menu" + Environment.NewLine + "----------------------");
                Console.WriteLine("Type A to | Add an Appointment" + Environment.NewLine + "Type V to | View all Appointments" + Environment.NewLine + "Type C to | Book a Phone Consultation" + Environment.NewLine + "Type P to | View all Phone Consultations" + Environment.NewLine + "Type B to | Return to the Previous Menu");
                string menuChoice = Console.ReadLine().ToUpper();
                Practice currentPractice = Practice.currentPractice(user);
                switch (menuChoice)
                {
                    case "A":                      
                        Appointment.newAppointment(currentPractice); //method to create new appointment
                        break;
                    case "V":
                        Appointment.displayAppointments(); //method to display all appointments
                        break;
                    case "C":
                        Consultation.newConsultation(user); //method to create a new Phone Consultation Appointment based on Patient-requested tickets
                        break;
                    case "P":
                        Consultation.receptionistView(currentPractice); //method to display all phone consultation appointments
                        break;
                    case "B":
                        receptionistMenu(loginBackup); //load previous menu
                        break;
                }
            } while (!constantMenu);
        }

        public static void receptionistTreatments()
        {
            do
            {
                Console.WriteLine(Environment.NewLine + "Treatment Management Menu" + Environment.NewLine + "----------------------");
                Console.WriteLine("Type A to | Add a new Treatment" + Environment.NewLine + "Type V to | View all Treatments" + Environment.NewLine + "Type B to | Return to the Previous Menu");
                string menuChoice = Console.ReadLine().ToUpper();

                switch (menuChoice)
                {
                    case "A":
                        Treatment.newTreatment(); //method to create new treatment
                        break;
                    case "V":
                        Treatment.treatmentDisplay(); //method to display all treatments
                        break;
                    case "B":
                        receptionistMenu(loginBackup); //load previous menu
                        break;
                }
            } while (!constantMenu);
        }

        public static void dentalMenu(List<string> user) //menu for dentists and nurses
        {
            do
            {
                Console.WriteLine(Environment.NewLine + "Dental Staff Menu" + Environment.NewLine + "-----------------");
                Console.WriteLine("Type P to | View all Patient Information" + Environment.NewLine + "Type A to | View all Appointments" + Environment.NewLine + "Type N to | Leave a Note on an Appointment" + Environment.NewLine + "Type C to | View all Phone Consultations" + Environment.NewLine + "Type T to | View all Treatments" + Environment.NewLine + "Type X to | Close the Software");
                string menuChoice = Console.ReadLine().ToUpper();

                switch (menuChoice)
                {
                    case "P":
                        Patient.viewPatients(); //method to display all patients
                        break;
                    case "A":
                        Appointment.displayAppointments(); //method to display all appointments
                        break;
                    case "N":
                        Appointment.addNote(user); //method to add note to an appointment
                        break;
                    case "T":
                        Treatment.treatmentDisplay(); //method to display all treatments
                        break;
                    case "X":
                        Environment.Exit(1); //close the application
                        break;
                    case "C":
                        if(user.ElementAt(1) == "Nurse") //Prevents access if user is a Nurse
                        {
                            Console.WriteLine("Error | This Action is for Dentists Only");
                        }
                        else
                        {
                            Consultation.dentistView(Dentist.loginInformation(user)); //Load Method to view all Phone Consultations for that dentist
                        }
                        break;
                }
            } while (!constantMenu);
        }
    }
}
