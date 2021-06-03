using System.Collections.Generic;

namespace Models
{
    public class Airport
    {
        public int ID { get; set; }
        public List<Runway> Runways { get; set; }
        public List<Track> Tracks { get; set; }
        public List<Terminal> Terminals { get; set; }
    }
}
