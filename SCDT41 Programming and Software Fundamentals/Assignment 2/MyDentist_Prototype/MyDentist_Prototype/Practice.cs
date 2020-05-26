using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDentist_Prototype
{
    class Practice
    {
        string practiceID;
        string location;
        int roomCount;
        Dictionary<string, Dentist> roomDentist = new Dictionary<string, Dentist>();
        Dictionary<string, Nurse> roomNurse = new Dictionary<string, Nurse>();
        Receptionist receptionist;

        public Practice(string practiceID, string location, int roomCount, Dictionary<string, Dentist> roomDentist,Dictionary<string,Nurse> roomNurse,Receptionist receptionist)
        { //object for practices
           

            this.practiceID = practiceID;
            this.location = location;
            this.roomCount = roomCount;
            this.roomDentist = roomDentist;
            this.roomNurse = roomNurse;
            this.receptionist = receptionist;
        }
        public string PracticeID { get => practiceID; set => practiceID = value; }
        public string Location { get => location; set => location = value; }
        public int RoomCount { get => roomCount; set => roomCount = value; }
        public Dictionary<string,Dentist> RoomDentist { get => roomDentist; set => roomDentist = value; }
        public Dictionary<string,Nurse> RoomNurse { get => roomNurse; set => roomNurse = value; }
        public Receptionist Receptionist { get => receptionist; set => receptionist = value; }

        protected static List<Practice> allPracticies = new List<Practice>();  //List of all practices 

        public static bool addPractice() //method to add new practice
        {
            Dictionary<string, Dentist> roomDentist = new Dictionary<string, Dentist>();
            Dictionary<string, Nurse> roomNurse = new Dictionary<string, Nurse>();
            string[] rooms = new string[10] //maximum of 10 rooms per practice
            {
                "Room 1","Room 2","Room 3","Room 4","Room 5","Room 6","Room 7","Room 8","Room 9","Room 10"
            };
            int x = 0;
            List<string> currentRooms = new List<string>();

            Console.WriteLine(Environment.NewLine + "Enter the Practice's Details Below:" + Environment.NewLine);
            Console.Write("Location: ");
            string location = Console.ReadLine().ToUpper();
            Console.Write("Practice Room Count (Min: 1, Max: 10) :");
            int roomCount = int.Parse(Console.ReadLine()); //number of rooms
            Console.Write("Receptionist's Staff ID: ");
            string receptionistID = Console.ReadLine().ToUpper(); //checks if receptionist exists on the system
            Receptionist check3 = Receptionist.roomReceptionist(receptionistID);
            if (check3 == null)
            {
                Console.WriteLine("Receptionist Error");
                return false;
            }

            do
            {
                currentRooms.Add(rooms.ElementAt(x));
                x++;
            }while(x <= roomCount-1);

            foreach(var r in currentRooms) //for every room in the dental practice
            {
                Console.WriteLine(r);
                Console.Write("Assigned Dentist's Staff ID: ");
                string dentistID = Console.ReadLine().ToUpper();
                Dentist check = Dentist.roomDentist(dentistID);
                if(check == null)
                {
                    Console.WriteLine("Dentist Error");
                    return false;
                }
                else
                {
                    roomDentist.Add(r, check); //assigns dentist to current room
                }
                Console.Write("Assigned Nurse's Staff ID: ");
                string nurseID = Console.ReadLine().ToUpper();
                Nurse check2 = Nurse.roomNurse(nurseID);
                if(check2 == null)
                {
                    Console.WriteLine("Nurse Error");
                    return false;
                }
                else
                {
                    roomNurse.Add(r, check2); //assigns nurse to current room
                }
             
            }
            string practiceID = Guid.NewGuid().ToString(); //Generates a unique 5 digit ID for the Practice ID
            char[] idCharacters = practiceID.Take(5).ToArray();
            practiceID = new string(idCharacters).ToUpper();

            Practice newPractice = new Practice(practiceID, location, roomCount, roomDentist, roomNurse, check3); //creates new practice with inputted information

            foreach (var p in allPracticies) //checks if practice already exists
            {
                if(p.Location == newPractice.Location)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Environment.NewLine + "Error | Practice Already Exists");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
            }

            allPracticies.Add(newPractice);
            return true;
        }

        public static bool displayPractices() //method to output all practices on the system
        {
            foreach(var p in allPracticies)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Practice ID: {0}", p.PracticeID);
                Console.WriteLine("Location: {0}", p.Location);
                Console.WriteLine("Number of Rooms: {0}", p.roomCount);
                Console.WriteLine("Receptionist: {0}, {1}", p.Receptionist.Surname, p.Receptionist.FirstName + Environment.NewLine);
                var x = 0;
                foreach (var d in p.roomDentist) //displays information for each room in the practice
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(Environment.NewLine + "{0}:", d.Key);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Dentist: {0}, {1}", d.Value.Surname, d.Value.FirstName);
                    Console.WriteLine("Nurse: {0}, {1}", p.roomNurse.ElementAt(x).Value.Surname, p.roomNurse.ElementAt(x).Value.FirstName);
                    x++;
                }
                Console.WriteLine("------------------------------------");
                
            }
            Console.ReadLine();
            return true;
        }

        public static bool editPractice() //method to edit practice properties
        {
            Console.Write("Enter the ID of the Practice to Change: ");
            string changeID = Console.ReadLine().ToUpper();

            foreach(var i in allPracticies)
            {
                if (changeID == i.practiceID)
                { //outputs the current details of the practice that is to be edited
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("{0} Practice: Current Information", i.Location + Environment.NewLine);
                    Console.WriteLine("Practice ID: {0}", i.PracticeID);
                    Console.WriteLine("Location: {0}", i.Location);
                    Console.WriteLine("Number of Rooms: {0}", i.roomCount);
                    Console.WriteLine("Receptionist: {0}, {1}", i.Receptionist.Surname, i.Receptionist.FirstName + Environment.NewLine);
                    var x = 0;
                    foreach (var d in i.roomDentist) //Outputs all rooms along with assigned dentists and nurses
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(Environment.NewLine + "{0}:", d.Key);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Dentist: {0}, {1}", d.Value.Surname, d.Value.FirstName);
                        Console.WriteLine("Nurse: {0}, {1}", i.roomNurse.ElementAt(x).Value.Surname, i.roomNurse.ElementAt(x).Value.FirstName);
                        x++;
                    }
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Enter the New Details Below:" + Environment.NewLine);




                    Dictionary<string, Dentist> roomDentist = new Dictionary<string, Dentist>();
                    Dictionary<string, Nurse> roomNurse = new Dictionary<string, Nurse>();
                    string[] rooms = new string[10]
                    {
                "Room 1","Room 2","Room 3","Room 4","Room 5","Room 6","Room 7","Room 8","Room 9","Room 10" //Potential Number of rooms per Practice
                    };
                    int y = 0;
                    List<string> currentRooms = new List<string>();
                    Console.Write("Practice Room Count (Min: 1, Max: 10) :");
                    int roomCount = int.Parse(Console.ReadLine());
                    Console.Write("Receptionist's Staff ID: ");
                    string receptionistID = Console.ReadLine().ToUpper();
                    Receptionist check3 = Receptionist.roomReceptionist(receptionistID);
                    if (check3 == null)
                    {
                        Console.WriteLine("Receptionist Error");
                        return false;
                    }

                    do
                    {
                        currentRooms.Add(rooms.ElementAt(y));
                        y++;
                    } while (y <= roomCount - 1);

                    foreach (var r in currentRooms)
                    {
                        Console.WriteLine(r);
                        Console.Write("Assigned Dentist's Staff ID: ");
                        string dentistID = Console.ReadLine().ToUpper();
                        Dentist check = Dentist.roomDentist(dentistID);
                        if (check == null)
                        {
                            Console.WriteLine("Dentist Error");
                            return false;
                        }
                        else
                        {
                            roomDentist.Add(r, check);
                        }
                        Console.Write("Assigned Nurse's Staff ID: ");
                        string nurseID = Console.ReadLine().ToUpper();
                        Nurse check2 = Nurse.roomNurse(nurseID);
                        if (check2 == null)
                        {
                            Console.WriteLine("Nurse Error");
                            return false;
                        }
                        else
                        {
                            roomNurse.Add(r, check2);
                        }

                        i.RoomCount = roomCount;
                        i.RoomDentist = roomDentist;
                        i.RoomNurse = roomNurse;
                        i.Receptionist = check3;

                    }
                }


            }
            Console.WriteLine("Error | Could not find specified Practice"); //if entered ID does not match the ID of a practice on the system
            return false;


        }

        public static Practice currentPractice(Receptionist user) //method to retrive which practice the current receptionist user is assigned to
        {
            foreach(var u in allPracticies)
            {
                if(u.Receptionist == user)
                {
                    return u;
                }
            }
            return null;
        }

        public static Practice checkLocation(string x) //mehtod used to check the practice of the current staff user
        {
            foreach(var p in allPracticies)
            {
                if(x == p.Location) { return p; };
            }
            return null;
        }

        public static void viewDentists(Practice p) //Method to ouput all the Dentists assigned to a Practice
        {
            foreach(var d in p.RoomDentist.Values)
            {
                Console.WriteLine("{0} | Dr {1}", d.StaffID, d.Surname);
            }
        }

        public static Practice checkReceptionist(Receptionist r) //Method to check the receptionist assigned to a Practice
        {
            foreach (var p in allPracticies)
            {
                if(p.Receptionist == r)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
