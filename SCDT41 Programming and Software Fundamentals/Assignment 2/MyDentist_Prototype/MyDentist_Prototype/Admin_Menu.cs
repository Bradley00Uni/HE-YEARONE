using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    class Admin_Menu
    {
        static bool constantMenu = false;

        public static void adminMenu() //Menu that is loaded when an admin is loaded in
        {
            Console.WriteLine(Environment.NewLine + "Admin Menu" + Environment.NewLine + "------------------------");
            Console.WriteLine("Type S to | Manage Staff" + Environment.NewLine + "Type P to | Manage Practices" + Environment.NewLine + "Type X to | Close the Software");
            string adminChoice = Console.ReadLine().ToUpper(); //Converts input to upper case to ensure that it matches the options available in the switch case below

            switch (adminChoice) //runs different methods based on what the user inputs
            {
                case "S":
                    adminStaff(); //run menu to modify staff credentials
                    break;
                case "P":
                    adminPractice(); //run menu to modify practices 
                    break;
                case "X":
                    Environment.Exit(1); //close the application
                    break;
            }
            }

        protected static void adminPractice() //menu for managing practices
        {
            do
            {
                Console.WriteLine(Environment.NewLine + "Practice Management Menu" + Environment.NewLine + "------------------------");
                Console.WriteLine("Type A to | Add a Practice" + Environment.NewLine + "Type E to | Edit a Practice" + Environment.NewLine + "Type V to | View all Practices" + Environment.NewLine + "Type B to | Return to Previous Menu");
                string adminChoice = Console.ReadLine().ToUpper(); //Converts input to upper case to ensure that it matches the options available in the switch case below

                switch (adminChoice) //runs different methods based on the users input
                {
                    case "A":
                        Practice.addPractice(); //runs method for adding a new practice
                        break;
                    case "E":
                        Practice.editPractice(); //runs method to edit an existing practice
                        break;
                    case "V":
                        Practice.displayPractices(); //runs method to display a listed view of all practices
                        break;
                    case "B":
                        adminMenu(); //returns to the previous menu
                        break;
                }
            } while (constantMenu == false);

        }

        protected static void adminStaff() //menu to manage staff
        {
            do
            {
                Console.WriteLine(Environment.NewLine + "Staff Management Menu" + Environment.NewLine + "------------------------");
                Console.WriteLine("Type D to | Register a new Dentist" + Environment.NewLine + "Type N to | Register a new Nurse" + Environment.NewLine + "Type R to | Register a new Receptionist" + Environment.NewLine + "Type B to | Return to Previous Menu");
                string adminChoice = Console.ReadLine().ToUpper();

                switch (adminChoice) //runs different methods based on the user's inputs
                {
                    case "D":
                        manageDentists(); //loads menu for managing dentists
                        break;
                    case "N":
                        manageNurses(); //loads menu for managing nurses
                        break;
                    case "R":
                        manageReceptionists(); //loads menu for managing receptionists
                        break;
                    case "B":
                        adminMenu(); //returns to previous menu
                        break;
                }
            } while (constantMenu == false);
        }

        protected static bool manageDentists() //method to manage dentists
        {
            if (Dentist.addDentist()) { return true; } //calls method to manage dentists from the Dentist class
            return false;
        }
        protected static bool manageNurses() //method to manage nurses
        {
            if (Nurse.addNurse()) { return true; } //calls method to manage nurses from the Nurse class
            return false;
        }

        protected static bool manageReceptionists() { //method to manage receptionists
            if (Receptionist.addReceptionist()) { return true; } //calls method to manage receptionists from the Receptionist class
            return false;
        }
    }
}
