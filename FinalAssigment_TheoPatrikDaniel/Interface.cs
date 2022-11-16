using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssigment_TheoPatrikDaniel
{
    public interface Interface
    {
        string FetchFileInformation();
        List<Customer> ImportCustomersFromFile(string filePath);
    }
}
