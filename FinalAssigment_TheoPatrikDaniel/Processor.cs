using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace FinalAssigment_TheoPatrikDaniel
{
    internal class Processor : Interface, Importer, IAnalysis
    {

        List<Customer> customers = new List<Customer>();

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

        public List<Customer> ImportFile()
        {
            //import file_____________________________________________________________________________
            string pathoffile = "C:\\Users\\danis\\Projects\\FinalAssigment_TheoPatrikDaniel\\FileSources\\FinalAssignment_TheoPatrikDaniel_2.csv";
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
                    customer.DOB = cols[3] ;
                    customer.MemberSince = cols[4];
                    customers.Add(customer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return customers;
        }
            public void Process()
        {
          
                //menu____________________________________________________________________________________
                int input = -1;
            do
            {
                input = ShowMenu();
                switch (input)
                {
                    case 1:
                        //BookRoom menu

                        break;
                    case 2:
                        //show all bookings in the future
                        break;
                    case 3:
                        //show all staff details
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
            Console.WriteLine("Welcome to Hotel Transylvania");
            Console.WriteLine("Press 1. To book a room");
            Console.WriteLine("Press 2. To Show all bookings");
            Console.WriteLine("Press 3. To Show all staff details");
            Console.WriteLine("Press 4. To Show total value of booked rooms");

            int userInput = int.Parse(Console.ReadLine());
            return userInput;
        }
    }
}

