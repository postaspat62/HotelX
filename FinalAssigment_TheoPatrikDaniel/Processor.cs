using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace FinalAssigment_TheoPatrikDaniel
{
    internal class Processor
    {
        //Lists for every type of classes for import files
        List<Customer> customers = new List<Customer>();
        List<Employee> allEmployees = new List<Employee>();
        List<Room> rooms = new List<Room>();
    
        //import Customer file_____________________________________________________________________________________________________________________________________________________________
        public List<Customer> ImportCustomerFile()
        {
            //ˇˇ.csv files placed in the Debug folder of the project, so the program can find them by file name, instead of the complete path.
            string pathoffile = "Customers.csv";
            string[] lines = File.ReadAllLines(pathoffile);
            Customer customer = null;
            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    customer = new Customer();
                    string[] cols = lines[i].Split(';');
                    customer.Id = int.Parse(cols[0]);
                    customer.Name = cols[1];
                    customer.Address = cols[2];
                    customer.Nationality = cols[3];
                    customer.DOB = cols[4];
                    customer.MemberSince = cols[5];
                    customers.Add(customer);
                }
                catch /*(Exception ex)*/
                {
                   //Console.WriteLine(ex.Message);
                   //^^normally displays an error message, we decided to leave it blank so the file-import can run smoother.
                    
                }
            }
            return customers;
        }
        //import Manager file______________________________________________________________________________________________________________________________________________________________
        public List<Employee> ImportManagerFile()
        {
            //ˇˇ.csv files placed in the Debug folder of the project, so the program can find them by file name, instead of the complete path.
            string pathoffile = "Managers.csv";
            string[] lines = File.ReadAllLines(pathoffile);
            Manager manager = null;
            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    manager = new Manager(i);
                    string[] cols = lines[i].Split(';');
                    manager.SSN = int.Parse(cols[0]);
                    manager.FirstName = cols[1];
                    manager.LastName = cols[2];
                    manager.Address = cols[3];
                    manager.DOB = cols[4];
                    manager.JoinedDate = cols[5];
                    manager.OtherExpertise = cols[6];
                    manager.Senior = bool.Parse(cols[7]);
                    manager.HoldsHospitalityAcademicDegree = bool.Parse(cols[8]);
                    manager.YearsOfExperience = int.Parse(cols[9]);
                    allEmployees.Add(manager);
                }
                catch /*(Exception ex)*/
                {
                    // Console.WriteLine(ex.Message);
                    //^^normally displays an error message, we decided to leave it blank so the file-import can run smoother.
                }
            }
            return allEmployees;
        }

        //import Receptionists file_________________________________________________________________________________________________________________________________________________________
        public List<Employee> ImportReceptionistsFile()
        {
            //ˇˇ.csv files placed in the Debug folder of the project, so the program can find them by file name, instead of the complete path.
            string pathoffile = "Receptionists.csv";
            string[] lines = File.ReadAllLines(pathoffile);
            Receptionists receptionist = null;
            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    receptionist = new Receptionists(i);
                    string[] cols = lines[i].Split(';');
                    receptionist.SSN = int.Parse(cols[0]);
                    receptionist.FirstName = cols[1];
                    receptionist.LastName = cols[2];
                    receptionist.Address = cols[3];
                    receptionist.DOB = cols[4];
                    receptionist.JoinedDate = cols[5];
                    receptionist.YearsOfExperience = int.Parse(cols[6]);
                    receptionist.OtherExpertise = cols[7];
                    allEmployees.Add(receptionist);
                }
                catch /*(Exception ex)*/
                {
                    // Console.WriteLine(ex.Message);
                    //^^normally displays an error message, we decided to leave it blank so the file-import can run smoother.
                }
            }
            return allEmployees;
        }
        //import House keeping staff file____________________________________________________________________________________________________________________________________________________
        public List<Employee> ImportHKStaffFile()
        {
            //ˇˇ.csv files placed in the Debug folder of the project, so the program can find them by file name, instead of the complete path.
            string pathoffile = "Housekeeping.csv";
            string[] lines = File.ReadAllLines(pathoffile);
            HousekeepingStaff hKStaff = null;
            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    hKStaff = new HousekeepingStaff(i);
                    string[] cols = lines[i].Split(';');
                    hKStaff.SSN = int.Parse(cols[0]);
                    hKStaff.FirstName = cols[1];
                    hKStaff.LastName = cols[2];
                    hKStaff.Address = cols[3];
                    hKStaff.DOB = cols[4];
                    hKStaff.JoinedDate = cols[5];
                    allEmployees.Add(hKStaff);
                }
                catch /*(Exception ex)*/
                {
                    // Console.WriteLine(ex.Message);
                    //^^normally displays an error message, we decided to leave it blank so the file-import can run smoother.
                }
            }
            return allEmployees;
        }
        //import Room file____________________________________________________________________________________________________________________________________________________________________
        private List<Room> ImportRoomFile()
        {
            //ˇˇ.csv files placed in the Debug folder of the project, so the program can find them by file name, instead of the complete path.
            string pathoffile = "Rooms.csv";
            string[] lines = File.ReadAllLines(pathoffile);
            Room room = null;
            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    room = new Room();
                    string[] cols = lines[i].Split(';');
                    room.Id = int.Parse(cols[0]);
                    room.RoomName = cols[1];
                    room.RoomPrice = int.Parse(cols[2]);

                    rooms.Add(room);
                }
                catch /*(Exception ex)*/
                {
                    // Console.WriteLine(ex.Message);
                    //^^normally displays an error message, we decided to leave it blank so the file-import can run smoother.
                }
            }
            return rooms;
        }

        public void Process()
        {
            //file-import methods are called
            ImportCustomerFile();
            ImportManagerFile();
            ImportReceptionistsFile();
            ImportHKStaffFile();
            ImportRoomFile();

            //creating list for booked rooms
            List<Room> bookedRooms = new List<Room>();

            //menu____________________________________________________________________________________________________________________________________________________________________________
            int input = -1;
            do
            {
                input = ShowMenu();
                //The functions of the menu elaborated
                switch (input)
                {
                    case 1:
                        //The staff can book a room for a customer in the members list. 
                        DateTime today = DateTime.Now.Date;
                        Console.WriteLine("*****Book a room*****");

                        //The list of all the rooms displayed
                        foreach (Room room in rooms)
                        {
                            Console.WriteLine($"{room.Id} {room.RoomName} {room.RoomPrice}");
                        }
                        Room actualBookedRoom = new Room();
                        Console.WriteLine(" ");
                        Console.Write("Please provide the room number:");
                        actualBookedRoom.Id = int.Parse(Console.ReadLine());

                        //The list of all customers displayed
                        foreach (Customer customer in customers)
                        {
                            Console.WriteLine($"{customer.Id} {customer.Name} {customer.Address} {customer.Nationality} {customer.DOB} {customer.MemberSince} ");
                        }
                        
                        Console.WriteLine(" ");
                        Console.Write("Please provide the customer Id:");
                        actualBookedRoom.BookedCustomerId = int.Parse(Console.ReadLine());

                        int i = 0;
                        // Handling exception connected to the booking date:
                        // ...the room cannot be booked for more than 60 days in advance 
                        // ...the room cannot be booked for the past 
                        // ...the same room cannot be booked for the same date twice
                        do
                        {
                            Console.WriteLine("Please provide the start date and the end date of the booking:");
                            Console.Write("Start date (dd-MM-yyyy): ");
                            actualBookedRoom.StartDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);

                            Console.Write("End date (dd-MM-yyyy): ");
                            actualBookedRoom.EndDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
                            TimeSpan timeSpan = actualBookedRoom.StartDate - today;
                          
                            //actualBookedRoom = the room, which is being booked now.
                            //bookedRooms = the list, which contains all the booked rooms

                            //checking whether the given dates are in the past, or outside the 60 days advance timespan.
                            if (actualBookedRoom.StartDate >= today && (timeSpan.Days < 60) && actualBookedRoom.StartDate < actualBookedRoom.EndDate)
                            {
                                //Overlap handling
                                //if there are no rooms booked yet, book the current room.
                                if (bookedRooms.Count() == 0)
                                {
                                    bookedRooms.Add(actualBookedRoom);
                                    i++;
                                }
                                else
                                {
                                    //checking if the same room has already been booked
                                    int counter = 0;
                                    foreach (Room bRoom in bookedRooms)
                                    {
                                        if (bRoom.Id == actualBookedRoom.Id)
                                        {
                                            counter++;
                                            break;
                                        }
                                    }
                                    //if the room has already been booked, check for overlaps.
                                    if (counter > 0)
                                    {
                                        int overlapcounter = 0;
                                        foreach (Room bRoom in bookedRooms)
                                        {
                                            //searching for overlaps with the date, going through each element of the booked rooms list
                                            if (bRoom.Id == actualBookedRoom.Id && (bRoom.StartDate <= actualBookedRoom.EndDate && actualBookedRoom.EndDate <= bRoom.EndDate || bRoom.EndDate >= actualBookedRoom.StartDate && actualBookedRoom.StartDate >= bRoom.StartDate))
                                            {
                                                overlapcounter++;
                                            } 
                                        }
                                        //if there are no overlaps, the room is booked.
                                        if(overlapcounter<1)
                                        {
                                            bookedRooms.Add(actualBookedRoom);
                                            i++;
                                            break;
                                        }
                                        //if there is an overlap, give an error message and let the user choose dates again.
                                        else
                                        {
                                            Console.WriteLine("The room is already booked in that date, please choose another date.");
                                        }
                                    }
                                    //if the room has not been booked before, let it be booked.
                                    else
                                    {
                                        bookedRooms.Add(actualBookedRoom);
                                        i++;
                                    }

                                }
                            }
                            else
                            {
                                Console.WriteLine("The given start date falls outside of 60 day limit, please try again.");

                            }

                        }
                        while (i < 1);
                        break;
                    case 2:
                        Console.WriteLine();

                        //Listing all bookings
                        foreach (Room bRoom in bookedRooms)
                        {
                            foreach (Room room in rooms)
                            {
                                if (bRoom.Id == room.Id)
                                {
                                    Console.WriteLine($"{bRoom.Id} - {room.RoomName} - {room.RoomPrice} - {bRoom.StartDate.ToString("dd/MM/yyyy")} - {bRoom.EndDate.ToString("dd/MM/yyyy")} - Booked by customer (ID): {bRoom.BookedCustomerId}");
                                }

                            }
                        }
                        break;
                    case 3:
                        //listing all staff details                  
                        Console.WriteLine("************ Here the details of all staff members ************");
                        Console.WriteLine();
                        foreach(Employee staff in allEmployees)
                        {
                            Console.WriteLine(staff);
                            Console.WriteLine();
                        }
                        break;
                    case 4:
                        //print total value of booked rooms
                        int totalvalue = 0;
                        int bookedDays= 0;
                        foreach (Room bRoom in bookedRooms)
                        {
                            foreach (Room room in rooms)
                            {
                                if (bRoom.Id == room.Id)
                                {
                                    //add the room price per day multiplied by the number of days of the booking to the total value
                                    //do it for each booking
                                    bookedDays = (bRoom.EndDate.Day - bRoom.StartDate.Day);
                                    totalvalue += (bookedDays * room.RoomPrice);
                                }

                            }
                        }
                        Console.WriteLine($"The total value of the rooms booked: {totalvalue}");
                        break;
                }

            }
            while (input != 5);
        }
        private int ShowMenu()
        {
            //A menu with different functions, let's the user choose from the keyboard.
            Console.WriteLine("Welcome to HotelX");
            Console.WriteLine("Press 1. To book a room");
            Console.WriteLine("Press 2. To Show all bookings");
            Console.WriteLine("Press 3. To Show all staff details");
            Console.WriteLine("Press 4. To Show total value of booked rooms");

            int userInput = int.Parse(Console.ReadLine());
            return userInput;
        }
    }
}

