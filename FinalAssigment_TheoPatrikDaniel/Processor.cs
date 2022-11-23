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
        //Lists for every type of classes
        List<Customer> customers = new List<Customer>();
        List<Manager> managers = new List<Manager>();
        List<Receptionists> receptionists = new List<Receptionists>();
        List<HousekeepingStaff> hKStaffs = new List<HousekeepingStaff>();
        List<Room> rooms = new List<Room>();
        //
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

        //import CUSTOMER file________________________________________________________________________________________________________________________________________
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

           //customer list
           /*foreach(Customer customer in customers)
            {
                Console.WriteLine(customer.Name);
            }*/
       
            //menu____________________________________________________________________________________
            int input = -1;
            do
            {
                input = ShowMenu();
                switch (input)
                {
                    case 1:
                        //BookRoom menu

                        /*
                          Console.WriteLine("Please provide your Date of Birth (dd-MM-yyyy):");
                          aff.Dob = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
                         */

                        //Choose Room
                        Console.WriteLine("*****Book a room*****");
                        //list of roomsˇˇ


                        Console.WriteLine("Which room would you like to book?");
                        int rn = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please provide the start date and the end date of the booking:");
                        Console.Write("Start date: ");
                        /*start date from room csv = */DateTime.Parse(Console.ReadLine());
                        Console.Write("End date: ");
                        /*end date from room csv = */DateTime.Parse(Console.ReadLine());
                        break;
                    case 2:
                        //show all bookings in the future
                        break;
                    case 3:
                        //show all staff details

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("************ Here the details of all the housekeeping staff members ************");
                        Console.WriteLine();
                        foreach (HousekeepingStaff staff in hKStaffs)
                        {
                            Console.WriteLine($"SSN: {staff.SSN}, first name: {staff.FirstName}, last name: {staff.LastName}, address: {staff.Address}, " +
                                $"date of birth: {staff.DOB}, date of joining: {staff.JoinedDate}.",Console.BackgroundColor, Console.ForegroundColor);
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

                        /* Console.WriteLine("************Here the details of all the housekeeping staff members************");
                                                 foreach (HousekeepingStaff staff in hKStaffs)
                         {
                             Console.WriteLine($"SSN: {staff.SSN}, first name: {staff.FirstName}, last name: {staff.LastName}, address: {staff.Address}, " +
                                 $"date of birth: {staff.DOB}, date of joining: {staff.JoinedDate}.", Console.BackgroundColor, Console.ForegroundColor);
                             Console.WriteLine();
                         }*/


                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 4:
                        //print total value of booked rooms
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

