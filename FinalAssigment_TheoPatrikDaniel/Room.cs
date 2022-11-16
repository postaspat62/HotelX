using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssigment_TheoPatrikDaniel
{
    internal class Room
    {
        //properties
        public int Id { get; set; }
        public string RoomName { get; set; }
        public int RoomPrice { get; set; }
        public string Date { get; set; } //later date
        public bool Booked { get; set; }

        //methods
        public override string ToString()
        {
            string totalDetail = base.ToString() + "\n";
            totalDetail = totalDetail + $"Write an appropriate text";
            return totalDetail;
        }
    }
}
