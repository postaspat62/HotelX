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
        //for the booked rooms
        public DateTime StartDate { get; set; }
        public DateTime EndDate {get;set;}
        public int BookedCustomerId { get; set; }

        //methods
        public override string ToString()
        {
            string totalDetail = base.ToString() + "\n";
            totalDetail = totalDetail + $"Write an appropriate text";
            return totalDetail;
        }
    }
}
