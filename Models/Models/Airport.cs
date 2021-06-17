using System.Collections.Generic;

namespace Models
{
    public class Airport
    {
        public int ID { get; set; }
        public virtual List<Location> Legs { get; set; }
        public virtual Queue<Flight> FlightsBoard { get; set; }
    }
}
