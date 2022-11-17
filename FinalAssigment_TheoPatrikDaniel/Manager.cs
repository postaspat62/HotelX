using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssigment_TheoPatrikDaniel
{
    internal class Manager :Employee
    {
        //inherited from Employee class
        public Manager(int ssn) : base(ssn) { }
        public int YearsOfExperience { get; set; }
        public string OtherExpertise { get; set; }
        public bool HoldsHospitalityAcademicDegree { get; set; }
        public bool Senior { get; set; }    
    }
}
