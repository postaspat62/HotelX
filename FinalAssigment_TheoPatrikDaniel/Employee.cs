using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssigment_TheoPatrikDaniel
{
    internal class Employee
    {
        public Employee(int ssn)
        {
            SSN = ssn;
        }
        //properties
        public int SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }
        public string JoinedDate { get; set; }
        //methods
        //The method lists the basic details of the staff
        public override string ToString()
        {
            string staffInfo = $"SSN: {SSN}; Name: {FirstName} {LastName}; Date of birth: {DOB}\n";
            staffInfo = staffInfo + $"Address: {Address}; Date of joining: {JoinedDate}";
            return staffInfo;

        }
    }
}
