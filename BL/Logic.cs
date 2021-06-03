using Dal;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Logic :ILogic
    {
        private Repository data = new Repository();
        private Airport Airport;
        public Logic()
        {
            //create default airport
        }

        public IEnumerable<Flight> GetFlights => data.Flights;

        public void CreateNewAirport(Airport airport)
        {
            Airport = airport;
        }

        public Flight GenerateNewFlight()
        {
            //randomly makes new flight
            return null;
        }
    }
}
