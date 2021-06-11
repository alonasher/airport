using System.Collections.Generic;

namespace Models
{
    public class Airport
    {
        public int ID { get; set; }
        public virtual List<Location> Locations { get; set; }
        public virtual List<Flight> FlightsBoard { get; set; }
    }
}
