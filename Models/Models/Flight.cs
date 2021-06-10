using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Flight
    {
        public int ID { get; set; }
        public virtual List<Location> FlightRoute { get; set; }
        public string Plane { get; set; }
        public bool Landed { get; set; }
        public virtual Airport Airport{get;set;}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"Flight ID: {ID}");
            foreach (var item in FlightRoute)
            {
                if(item != null)
                    sb.Append($" -> {item.Role.ToString()}");
            }
            return sb.ToString();
        }
    }
}
