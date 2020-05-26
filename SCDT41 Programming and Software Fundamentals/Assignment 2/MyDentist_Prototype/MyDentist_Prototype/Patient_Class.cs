using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    class Patient_Class
    {
        public static bool constantMenu = false;

        public static void patientStartup() //Login Menu for Patient Users
        {
            do
            {

                Console.WriteLine("Welcome to the Menu for Patient Users of the MyDentist system" + Environment.NewLine);
                Console.WriteLine("Are you a returning user or is this your First time?");
                Console.WriteLine("Type R if | You are a returning user" + Environment.NewLine + "Type N if | This is your first time" + Environment.NewLine + "Type X to | Close the software");
                string userChoice = Console.ReadLine().ToUpper();

                switch (userChoice)
                {
                    case "R":
                        userLogin(); //Method for if user has logged into the system before
                        break;
                    case "N":
                        newUser(); //Method or if this is the user's first time on the system
                        break;
                    case "X":
                        Environment.Exit(1); //closes the application
                        break;
                }

            } while (!constantMenu);
        }

        protected static void newUser() //Method to create new user
        {
            bool usernameMatch = false;
            bool passwordMatch = false;

            string username = "";
            string password = "";
            
            Console.Write("Please Enter your Provided User ID: ");
            string x = Console.ReadLine().ToUpper();
            Patient systemPatient = Patient.patientUser(x);
            do
            {
                Console.Write("Please enter your desired Username: ");
                string a = Console.ReadLine().ToUpper();
                Console.Write("Please Re-enter the Username: ");
                string b = Console.ReadLine().ToUpper();

                if (a == b) { usernameMatch = true; }
                else { Console.WriteLine("Error | Usernames did not Match"); }

                if (!Patient_User.checkUser(a))
                {
                    Console.WriteLine("Error | Username already in Use");                    
                }
                else if (Patient_User.checkUser(a))
                {
                    usernameMatch = true;
                    username = a;
                }
            }while(usernameMatch == false);
            do
            {
                Console.Write("Please enter a Password: ");
                string c = Console.ReadLine();
                Console.Write("Please Confirm your Password: ");
                string d = Console.ReadLine();

                if(c == d)
                {
                    passwordMatch = true;
                    password = d;
                }
                else
                {
                    Console.WriteLine("Error | Passwords did not match");
                }
            } while (passwordMatch == false);

            Patient_User y = new Patient_User(systemPatient, username, password);
            Patient_User.addUser(y);
            userMenu(y); //loads user into main login menu
        }

        protected static void userLogin() //method for exisiting users to log in
        {
            do
            {
                Console.WriteLine("Please enter your Username: ");
                string username = Console.ReadLine().ToUpper();
                Console.WriteLine("Please enter your Password: ");
                string password = Console.ReadLine();
                Patient_User currentUser = Patient_User.loginCheck(new List<string>() { username, password });

                if (currentUser != null) { userMenu(currentUser); }
            } while (!constantMenu);
        }

        protected static void userMenu(Patient_User user) //Main menu for patient users
        {
            do
            {
                Console.WriteLine(Environment.NewLine + "Please Select one of the following options:");
                Console.WriteLine("Type R to | Request a Phone Consultation" + Environment.NewLine + "Type V to | View your Requests" + Environment.NewLine + "Type T to | View all Available Treatments");
                Console.WriteLine("Type A to | View all confirmed Apointments" + Environment.NewLine + "Type C to | View your Phone Consultations" + Environment.NewLine + "Type X to | Close the Software");
                string userChoice = Console.ReadLine().ToUpper();

                switch (userChoice)
                {
                    case "R":
                        Ticket.newTicket(user); //method to create request ticket for phone consultation
                        break;
                    case "V":
                        Ticket.viewTickets(user); //method to view all active request tickets
                        break;
                    case "T":
                        Treatment.treatmentDisplay(); //method to display all available treatments
                        break;
                    case "A":
                        Appointment.patientCheck(user); //method to view all current appointments
                        break;
                    case "C":
                        Consultation.patientView(user); //method to view all confirmed phone consultations
                        break;
                    case "X":
                        Environment.Exit(1); //close the application
                        break;
                }
            } while (!constantMenu);
        }
    }
}
