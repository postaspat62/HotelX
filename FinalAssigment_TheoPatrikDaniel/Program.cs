using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssigment_TheoPatrikDaniel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Processor p = new Processor();
            //p.ImportFile();
             p.Process();

            Console.ReadLine();
        }
    }
}
