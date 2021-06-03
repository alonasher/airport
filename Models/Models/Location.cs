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
        public int Duration { get; set; }
    }
}
