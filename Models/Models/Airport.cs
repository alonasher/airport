using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Models
{
    public class Airport
    {
        public int ID { get; set; }
        public ConcurrentBag<Location> Legs { get; set; }
        public ConcurrentQueue<Flight> FlightsBoard { get; set; }
    }
}
