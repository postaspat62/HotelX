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

        //the override method lists additional staff details that are unique to this type of staff
        public override string ToString()
        {

            string totalDetail = base.ToString() + "\n";
            totalDetail += $"Years of experience: {YearsOfExperience}; Other expertise: {OtherExpertise}";
            return totalDetail;
        }
    }
}
