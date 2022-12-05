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

        public override string ToString()
        {

            string totalDetail = base.ToString() + "\n";
            totalDetail += $"Years of experience: {YearsOfExperience}; Other expertise: {OtherExpertise}";
            return totalDetail;
        }
    }
}
