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
    internal class Processor : Interface, Importer, IAnalysis
    {
        //Lists for every type of classes for import files
        List<Customer> customers = new List<Customer>();
        List<Manager> managers = new List<Manager>();
        List<Receptionists> receptionists = new List<Receptionists>();
        List<HousekeepingStaff> hKStaffs = new List<HousekeepingStaff>();
        List<Room> rooms = new List<Room>();
        public int CountAllCustomers()
        {
            throw new NotImplementedException();
        }

        public string FetchFileInformation()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomerList()
        {
            throw new NotImplementedException();
        }

        public List<Customer> ImportCustomersFromFile(string filePath)
        {
            throw new NotImplementedException();
        }

        //import Customer file________________________________________________________________________________________________________________________________________
        public List<Customer> ImportCustomerFile()
        {

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
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                    string s = "Lets go ";
                }
            }
            return customers;
        }
        //import Manager file_______________________________________________________________________________________________________________________________________________
        public List<Manager> ImportManagerFile()
        {

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
                    managers.Add(manager);
                }
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                    string s = "Lets go ";
                }
            }
            return managers;
        }

        //import Receptionists file_______________________________________________________________________________________________________________________________________________
        public List<Receptionists> ImportReceptionistsFile()
        {

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
                    receptionists.Add(receptionist);
                }
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                    string s = "Lets go ";
                }
            }
            return receptionists;
        }
        //import House keeping staff file_______________________________________________________________________________________________________________________________________________
        public List<HousekeepingStaff> ImportHKStaffFile()
        {

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
                    hKStaffs.Add(hKStaff);
                }
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                    string s = "Lets go ";
                }
            }
            return hKStaffs;
        }
        //import Room file_______________________________________________________________________________________________________________________________________________
        private List<Room> ImportRoomFile()
        {

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
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                    string s = "Lets go ";
                }
            }
            return rooms;
        }

        public void Process()
        {
            ImportCustomerFile();
            ImportManagerFile();
            ImportReceptionistsFile();
            ImportHKStaffFile();
            ImportRoomFile();

            //creating list for booked rooms
            List<Room> bookedRooms = new List<Room>();

            //menu____________________________________________________________________________________
            int input = -1;
            do
            {
                input = ShowMenu();
                switch (input)
                {
                    case 1:
                        //BookRoom menu
                        //Choose Room
                        DateTime today = DateTime.Now.Date;
                        Console.WriteLine("*****Book a room*****");
                        //list of roomsˇˇ
                        foreach (Room room in rooms)
                        {
                            Console.WriteLine($"{room.Id} {room.RoomName} {room.RoomPrice}");
                        }
                        Room actualBookedRoom = new Room();
                        Console.WriteLine(" ");
                        Console.Write("Please provide the room number:");
                        actualBookedRoom.Id = int.Parse(Console.ReadLine());

                        foreach (Customer customer in customers)
                        {
                            Console.WriteLine($"{customer.Id} {customer.Name} {customer.Address} {customer.Nationality} {customer.DOB} {customer.MemberSince} ");
                        }
                        
                        Console.WriteLine(" ");
                        Console.Write("Please provide the customer Id:");
                        actualBookedRoom.BookedCustomerId = int.Parse(Console.ReadLine());

                        int i = 0;
                        //Handeling the 60days criteria
                        //+ start date can't be in the past
                        //
                        do
                        {
                            Console.WriteLine("Please provide the start date and the end date of the booking:");
                            Console.Write("Start date (dd-MM-yyyy): ");
                            actualBookedRoom.StartDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);

                            Console.Write("End date (dd-MM-yyyy): ");
                            actualBookedRoom.EndDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
                            TimeSpan timeSpan = actualBookedRoom.StartDate - today;
                            //bookedRoom = the room, which is being booked now.
                            //bookedRooms = the list, which contains the booked rooms
                            if (actualBookedRoom.StartDate >= today && (timeSpan.Days < 60) && actualBookedRoom.StartDate < actualBookedRoom.EndDate)
                            {
                                if (bookedRooms.Count() == 0)
                                {
                                    bookedRooms.Add(actualBookedRoom);
                                    i++;
                                }
                                else
                                {
                                    int counter = 0;
                                    foreach (Room bRoom in bookedRooms)
                                    {
                                        if (bRoom.Id == actualBookedRoom.Id)
                                        {
                                            counter++;
                                            break;
                                        }
                                    }
                                    if (counter > 0)
                                    {
                                        foreach (Room bRoom in bookedRooms)
                                        {
                                            if (bRoom.Id == actualBookedRoom.Id && (bRoom.StartDate >= actualBookedRoom.EndDate || bRoom.EndDate <= actualBookedRoom.StartDate))
                                            {
                                                bookedRooms.Add(actualBookedRoom);
                                                i++;
                                                break;
                                            }
                                            else if (bRoom.Id == actualBookedRoom.Id)
                                            {
                                                Console.WriteLine("The room is already booked in that date, please choose another date.");
                                            }
                                        }
                                    }
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
                        foreach (Room bRoom in bookedRooms)
                        {
                            foreach (Room room in rooms)
                            {
                                if (bRoom.Id == room.Id)
                                {
                                    Console.WriteLine($"{bRoom.Id} - {room.RoomName} - {room.RoomPrice} - {bRoom.StartDate.ToString("dd/MM/yyyy")} - {bRoom.EndDate.ToString("dd/MM/yyyy")} Booked by customer (ID): {bRoom.BookedCustomerId}");
                                }

                            }
                        }
                        //show all bookings in the future
                        break;
                    case 3:
                        //show all staff details                  
                        Console.WriteLine("************ Here the details of all the housekeeping staff members ************");
                        Console.WriteLine();
                        foreach (HousekeepingStaff staff in hKStaffs)
                        {
                            Console.WriteLine($"SSN: {staff.SSN}, first name: {staff.FirstName}, last name: {staff.LastName}, address: {staff.Address}, " +
                                $"date of birth: {staff.DOB}, date of joining: {staff.JoinedDate}.", Console.BackgroundColor, Console.ForegroundColor);
                            Console.WriteLine();
                        }

                        Console.WriteLine("************ Here the details of all the receptionists ************");
                        Console.WriteLine();
                        foreach (Receptionists receptionist in receptionists)
                        {
                            Console.WriteLine($"SSN: {receptionist.SSN}, first name: {receptionist.FirstName}, last name: {receptionist.LastName}, address: {receptionist.Address}, " +
                                $"date of birth: {receptionist.DOB}, date of joining: {receptionist.JoinedDate}, other expertise: {receptionist.OtherExpertise}," +
                                $" years of experience {receptionist.YearsOfExperience}.", Console.BackgroundColor, Console.ForegroundColor);
                            Console.WriteLine();
                        }
                        Console.WriteLine("************ Here the details of the managers ************");
                        Console.WriteLine();
                        foreach (Manager manager in managers)
                        {
                            Console.WriteLine($"SSN: {manager.SSN}, first name: {manager.FirstName}, last name: {manager.LastName}, address: {manager.Address}, " +
                                $"date of birth: {manager.DOB}, date of joining: {manager.JoinedDate}, other expertise: {manager.OtherExpertise}," +
                                $" seniority status: {manager.Senior}, holds a(n) hospitality/academic degree: {manager.HoldsHospitalityAcademicDegree}, years of experience {manager.YearsOfExperience}.", Console.BackgroundColor, Console.ForegroundColor);
                            Console.WriteLine();
                        }
                        break;
                    case 4:
                        //print total value of booked rooms
                        //total value =+ (days*roomprice)
                        int totalvalue = 0;
                        int bookedDaysNumber = 0;
                        foreach (Room bRoom in bookedRooms)
                        {
                            foreach (Room room in rooms)
                            {
                                if (bRoom.Id == room.Id)
                                {
                                    bookedDaysNumber = (bRoom.EndDate.Day - bRoom.StartDate.Day);
                                    totalvalue += (bookedDaysNumber * room.RoomPrice);
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

