using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface ILogic
    {
        IEnumerable<Flight> GetOngoingFlights { get; }
        IEnumerable<Location> GetLocations { get; }
        Airport GetAirport{ get; }
        //void CreateAirport();
        void Start();
    }
}
