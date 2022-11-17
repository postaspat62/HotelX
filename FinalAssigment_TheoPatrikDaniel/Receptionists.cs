using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssigment_TheoPatrikDaniel
{
    internal class Receptionists:Employee
    {
        public Receptionists(int ssn) : base(ssn) { }
        public int YearsOfExperience { get; set; }
        public string OtherExpertise { get; set; }
    }
}
