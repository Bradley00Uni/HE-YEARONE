using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Task4
{
    class BookDetails
    {
        static Dictionary<string[], bool> bookRecords = new Dictionary<string[], bool>();
        static bool constantMenu = false;

        public static void bookMenu()
        {
            do
            { //Displays all options available to the Admin relating to managing books
                Console.WriteLine(Environment.NewLine + "--------------------" + Environment.NewLine + "BOOK MANAGEMENT MENU" + Environment.NewLine);
                Console.WriteLine("Type V to | View All Books" + Environment.NewLine + "Type A to | Add a Book" + Environment.NewLine + "Type D to | Delete a Book" + Environment.NewLine + "Type B to | Go Back" + Environment.NewLine + "Type X to | Exit the Software");
                Console.WriteLine(Environment.NewLine);
                Console.Write("What would you like to do? ");
                string userChoice = Console.ReadLine().ToUpper(); //Stores user's choice
                int i = menuChoice(userChoice);

                switch (i) //Checks which option was chosen by the user
                {
                    case 1:
                        viewBooks(); //Method to Display a list of all books in the system
                        break;
                    case 2:
                        addBook(); //Method to add a new book to the system
                        break;
                    case 3:
                        removeBook(); //Method to remove a book from the system
                        break;
                    case 4:
                        AdminControl.adminMenu(); //Return to the Admin Menu
                        break;
                    case 5:
                        Environment.Exit(1); //Close the Software
                        break;
                }
            } while (constantMenu == false);
        }

        static int menuChoice(string choice)
        {
            Dictionary<int, string> menuChoices = new Dictionary<int, string>() //Checks if user input matches a valid menu choice
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

        static void viewBooks() //Method to display all Books on the system and their information
        {
            foreach (var book in bookRecords.ToList())
            {
                isLoaned(book.Key[0]); //Checks if each book is currently loaned out to a customer
                Console.WriteLine(Environment.NewLine + "Book: {0} | Author: {1} | Published: {2} | Currently Loaned: {3}", book.Key[0], book.Key[1], book.Key[2], book.Value);
            }
        }

        static bool addBook() //Metod to add a new book to the system
        {
            Console.WriteLine("Please enter Book's details below:");
            Console.Write("Book Name: ");
            string bookName = Console.ReadLine().ToUpper();
            Console.Write("Author Name: ");
            string authorName = Console.ReadLine().ToUpper();
            Console.Write("Year of Publication: ");
            string pubYear = Console.ReadLine();
            
            foreach(var book in bookRecords)
            {
                if(bookName == book.Key[0] & authorName == book.Key[1]) //Checks if new book already exists in the system, if so it returns an error
                {
                    Console.WriteLine(Environment.NewLine + "Error | Book is already registered" + Environment.NewLine);
                    return false;
                }
            }
            string[] newBook = new string[3] {bookName, authorName, pubYear}; //Adds new book to the system
            bookRecords.Add(newBook,false);
            Console.WriteLine(Environment.NewLine + "Book Succesfully Added" + Environment.NewLine);
            return true;
        }

        static bool removeBook() //Method to remove a book from the system
        {
            Console.WriteLine("Enter the details of the book to be Removed:");
            Console.Write("Book Name: ");
            string bookName = Console.ReadLine().ToUpper();
            Console.Write("Author: ");
            string authorName = Console.ReadLine().ToUpper();

            foreach (var book in bookRecords) //Checks if entered details match a book in the system
            {
                if (bookName == book.Key[0] & authorName == book.Key[1]) //If book has a matchs
                {
                    string[] toRemove = book.Key;
                    bookRecords.Remove(toRemove); //Remove the book
                    Console.WriteLine(Environment.NewLine + "Book Succesfully Removed" + Environment.NewLine);
                    return true;
                }
            }
            Console.WriteLine(Environment.NewLine + "Error | Couldn't Find Book" + Environment.NewLine); //If no match can be found, return an error
            return false;
        }

        public static bool isLoaned(string bookCheck) //Method to check Loaned status of books
        {
            bool alreadyLoaned = false;
            foreach (var book in bookRecords.ToList())
            {
                if (bookCheck == book.Key[0])
                {
                    alreadyLoaned = LoanDetails.isLoaned(bookCheck); //Checks if book matches a book in the list of loaned books in the Loan Details Class
                    switch (alreadyLoaned)
                    {
                        case true:
                            bookRecords[book.Key] = true; //Set that the book is already loaned
                            return true;
                        case false:
                            bookRecords[book.Key] = false; //Set that the book is not currently loaned
                            break;
                    }

                }
            }
            return false;
        }
    }
}
