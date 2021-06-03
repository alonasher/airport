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
        void CreateNewAirport(Airport airport);
        IEnumerable<Flight> GetFlights { get; }
        Flight GenerateNewFlight();

    }
}
