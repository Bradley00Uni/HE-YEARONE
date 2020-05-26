using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task4
{
    class LoanDetails
    {
        static Dictionary<string, string[]> loanRecords = new Dictionary<string, string[]>(); //Storage of all loan details
        static List<string> loanedBooks = new List<string>(); //List of all currently loaned Books
        static bool constantMenu = false;

        public static void loanMenu()
        {
            do
            { //Presents user with all the optons available for managing books
                Console.WriteLine(Environment.NewLine + "--------------------" + Environment.NewLine + "LOAN MANAGEMENT MENU" + Environment.NewLine);
                Console.WriteLine("Type V to | View All Active Loans" + Environment.NewLine + "Type A to | Loan out a Book" + Environment.NewLine + "Type D to | Delete a Loan" + Environment.NewLine + "Type B to | Go Back" + Environment.NewLine + "Type X to | Exit the Software");
                Console.WriteLine(Environment.NewLine);
                Console.Write("What would you like to do? ");
                string userChoice = Console.ReadLine().ToUpper();//Saves user choice
                int i = menuChoice(userChoice);

                switch (i) //checks user choice against available options
                {
                    case 1:
                        viewLoans(); //Output details of all loans 
                        break;
                    case 2:
                        addLoan(); //Loan out a book to a customer
                        break;
                    case 3:
                        removeLoan(); //Manually delete a loan
                        break;
                    case 4:
                        AdminControl.adminMenu(); //Return to main Admin Menu
                        break;
                    case 5:
                        Environment.Exit(1); //Exit the Software
                        break;
                }
            } while (constantMenu == false);
        }

        static int menuChoice(string choice) //Method to check user choice is valid and matches a choice in the system
        {
            Dictionary<int, string> menuChoices = new Dictionary<int, string>()
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

        static void viewLoans() //Method to output all loans and their details
        {
            foreach(var loan in loanRecords) //Runs until all loans have been outputted
            {
                Console.WriteLine(Environment.NewLine + "| Reference ID: {0} | Book: {1} | Customer: {2}, {3} | Employee: {4} " + Environment.NewLine + "| Loaned: {5} | Return Due: {6}",loan.Key,loan.Value[0],loan.Value[1],loan.Value[2],loan.Value[3],loan.Value[4],loan.Value[5] + Environment.NewLine);
            }
        }

        static bool addLoan() //Method to add a new loan to the system
        {
            Console.Write("Book being Loaned: ");
            string loanBook = Console.ReadLine().ToUpper(); //Book to be loaned
            bool loaned = BookDetails.isLoaned(loanBook); //checks if book is currently loaned

            string[] loanCustomer = new string[2];
            Console.WriteLine("Who is Loaning the book?"); 
            Console.Write("First Name: ");
            loanCustomer[0] = Console.ReadLine().ToUpper();
            Console.Write("Surname: ");
            loanCustomer[1] = Console.ReadLine().ToUpper();
            bool customerMatch = CustomerDetails.lookupCustomer(loanCustomer); //Checks if customer is registered on the system

            string currentEmployee = LoginDetails.currentUser(); //Saves current user as employee loaning the book
            DateTime loanOut;
            loanOut = DateTime.Now; //Sets current date as when the book is loaned
            string loanoutString = loanOut.ToShortDateString();

            DateTime loanIn = loanOut.AddDays(21); //Generates a date for when the book needs to be returned
            string loaninString = loanIn.ToShortDateString();

            string newID = Guid.NewGuid().ToString(); //Generates a unique 5 digit ID for the loan as refrence
            char[] idCharacters = newID.Take(5).ToArray();
            newID = new string(idCharacters);

            if (loaned) //if the book is already loaned
            {
                Console.WriteLine("Error | Book is Already Loaned"); //Display error message and abort the method
                return false;
            }
            if (customerMatch == false) //If loan customer is not registered on the system
            {
                Console.WriteLine("Error | Customer not Registered"); //Display error message and abort the loan
                return false;
            }

            string[] loanString = new string[] {loanBook, loanCustomer[1], loanCustomer[0], currentEmployee, loanoutString, loaninString};
            loanRecords.Add(newID, loanString); //Add new loan to the system
            loanedBooks.Add(loanBook); //Add loaned book to list of books currently loaned
            Console.WriteLine("Book Succesfully Loaned");
            return true;
        }

        static bool removeLoan() //Method to remove a loan from the system
        {
            Console.Write("Enter Loan Reference ID: ");
            string searchID = Console.ReadLine();

            foreach (var loan in loanRecords)
            {
                if (searchID == loan.Key) //If entered unique ID matches a loan on the system
                {
                    loanedBooks.Remove(loan.Value[1]); //set loaned book as returned
                    loanRecords.Remove(searchID); //remove loan from the system
                    Console.WriteLine(Environment.NewLine + "Loan Succesfully Removed" + Environment.NewLine);
                    return true;
                }
            }
            Console.WriteLine(Environment.NewLine + "Error | Couldn't Find Loan" + Environment.NewLine); //if Unique ID match cannot be found, display error message
            return false;
        }
        
        public static bool isLoaned(string bookCheck) //Method to check if book is currently loaned
        {
            foreach (var book in loanedBooks) //checks every book in list of loaned books
            {

                if (bookCheck == book) //If searched boom is matched, return that it is loaned
                {
                    return true;
                }
            }
            return false; //otherwise, return that it is available
        }
    };
    
}
