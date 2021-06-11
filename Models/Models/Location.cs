using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Coordinate Coor { get; set; }
        public bool Occupied { get; set; }
        public int Duration { get; set; }
        public Role Role { get; set; }
        public virtual List<Flight> Flights { get; set; }
        public virtual List<Airport> Airports { get; set; }
    }
}
