using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Flight
    {
        public int ID { get; set; }
        public Queue<Location> FlightProcess { get; set; }
        public int PlaneID { get; set; }
        public bool Landed { get; set; }
    }
}
