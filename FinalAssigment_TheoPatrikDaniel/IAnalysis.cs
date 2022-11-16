using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssigment_TheoPatrikDaniel
{
    internal interface IAnalysis
    {
        int CountAllCustomers();
        List<Customer> GetAllCustomers();
    }
}
