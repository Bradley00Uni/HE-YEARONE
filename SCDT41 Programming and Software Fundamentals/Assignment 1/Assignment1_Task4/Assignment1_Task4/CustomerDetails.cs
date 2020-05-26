using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task4
{
    class CustomerDetails
    {
        static Dictionary<string, string[]> customerRecords = new Dictionary<string, string[]>(); //Stores all customer records in the system
        static bool constantMenu = false;

        public static void customerMenu()
        {
            do
            { //Displays all options for the Admin relating to customers
                Console.WriteLine(Environment.NewLine + "------------------------" + Environment.NewLine + "CUSTOMER MANAGEMENT MENU" + Environment.NewLine);
                Console.WriteLine("Type V to | View All Customers" + Environment.NewLine + "Type A to | Register a Customer" + Environment.NewLine + "Type D to | Delete a Customer" + Environment.NewLine + "Type B to | Go Back" + Environment.NewLine + "Type X to | Exit the Software");
                Console.WriteLine(Environment.NewLine);
                Console.Write("What would you like to do? ");
                string userChoice = Console.ReadLine().ToUpper(); //Saves Admin choice in the menu
                int j = menuChoice(userChoice);

                switch (j) //Checks Which Menu option was selected
                {
                    case 1:
                        viewCustomers(); //Output List of all customers and their details
                        break;
                    case 2:
                        addCustomer(); //Add a new customer to the system
                        break;
                    case 3:
                        removeCustomer(); //Remove a new customer to the system
                        break;
                    case 4:
                        AdminControl.adminMenu(); //Return to the main Admin Menu
                        break;
                    case 5:
                        Environment.Exit(1); //Close the Software
                        break;
                }
            } while (constantMenu == false);
        }

        static int menuChoice(string choice)
        {
            Dictionary<int, string> menuChoices = new Dictionary<int, string>() //Checks User choice against possible choices in the system
            {
                {1,"V"},{2,"A"},{3,"D"},{4,"B"},{5,"X"}
            };

            foreach (var option in menuChoices)
            {
                if (choice == option.Value)
                {
                    return option.Key;
                }
            }
            return 0;
        }

        static void viewCustomers() //Method to output a list of all customers and their details
        {
            foreach (var customer in customerRecords) //cycles until all customers have been displayed
            {
                Console.WriteLine(Environment.NewLine + "Customer ID: {0} | Name: {2}, {1} | D.O.B: {3} | Customer Since: {4}", customer.Key, customer.Value[0],customer.Value[1], customer.Value[2],customer.Value[3]);
            }
        }

        static bool addCustomer() //Method to add a new customer to the system
        {
            Console.WriteLine("Please enter the new Customer's details below:");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine().ToUpper(); //Stores input as new customer's first name
            Console.Write("Surname: ");
            string surname = Console.ReadLine().ToUpper(); //Stores input as new customer's surname name
            Console.WriteLine("Date of Birth (dd/mm/yyyy): ");
            string birthdate = Console.ReadLine(); //Stores input as new customer's date of birth
            string joinYear = Convert.ToString(DateTime.Now.Year); //Sets Join year as current year

            string newID = Guid.NewGuid().ToString();
            char[] idCharacters = newID.Take(5).ToArray(); //generates random unique 5 digit ID for customer
            newID = new string(idCharacters);

            string[] newCustomer = new string[4] {firstName, surname, birthdate, joinYear}; //Adds inputs as new customer object

            foreach(var existing in customerRecords)
            {
                if(newCustomer[0] == existing.Value[0] & newCustomer[1] == existing.Value[1]) //If customer already exists in the system, display error and abort the method
                {
                    Console.WriteLine(Environment.NewLine + "Error | Customer is already registered" + Environment.NewLine);
                    return false;
                }                
            }
            customerRecords.Add(newID, newCustomer); //Add new customer to the system
            Console.WriteLine(Environment.NewLine + "Customer Succesfully Added" + Environment.NewLine);           
            return true;
        }

        static bool removeCustomer() //Method to remove a customer from the system
        {
            Console.WriteLine("Enter the details of the customer to be Removed:");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine().ToUpper(); //First name of customer to be removed
            Console.Write("Surname: ");
            string surname = Console.ReadLine().ToUpper(); //Surname of customer to be removed

            foreach(var customer in customerRecords) //check every customer stored on the system
            {
                if (firstName == customer.Value[0] & surname == customer.Value[1]) //If entered information matches a customer
                {
                    string toRemove = customer.Key;
                    customerRecords.Remove(toRemove); //Remove the customer
                    Console.WriteLine(Environment.NewLine + "Customer Succesfully Removed" + Environment.NewLine);
                    return true;
                }
            }
            Console.WriteLine(Environment.NewLine + "Error | Couldn't Find Customer" + Environment.NewLine); //If customer cannot be found, display error
            return false;
        }

        public static bool lookupCustomer(string[] customerCheck) //Method to find customer to use in Loan
        {
            foreach (var existing in customerRecords)
            {
                if (customerCheck[0] == existing.Value[0] & customerCheck[1] == existing.Value[1]) //If customer is found, return that it does to the Loan Details CLass
                {
                    return true;
                }
            }
            return false;
        }
    }
}
