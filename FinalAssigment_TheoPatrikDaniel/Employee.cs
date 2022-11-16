using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssigment_TheoPatrikDaniel
{
    internal class Employee
    {
        public Employee(int Id)
        {
            EmployeeId = Id;
        }
        //properties
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public DateTime JoinedDate { get; set; }
        //methods
        //it will be a parent class so we should think about abstract methods
        //abstract methods means, we have to inheritate them to child classes
        //they have to be overriden in child classes
        //but this not meeans that we have to use only abstract classes
        public void ShowAllBookings()
        {

        }

        public int ShowTotalValueOfBookedRooms()
        {
            return 0;
        }
        public void ShowAllStaffDetails()
        {

        }

        public void BookRoom()
        {

        }

    }
}
