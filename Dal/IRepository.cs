using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IRepository
    {
        IEnumerable<Location> Locations { get;}
        void AddLocation(Location location);
        IEnumerable<Flight> Flights { get; }
        void AddFlight(Flight flight);
        IEnumerable<Plane> Planes { get; }
        void AddPlane(Plane plane);
    }
}
