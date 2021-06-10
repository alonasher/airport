using BL.Interfaces;
using Dal;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace BL
{
    public class Logic :ILogic
    {
        private Repository data = new Repository();
        private ArrivalSimulator _arrival = new ArrivalSimulator();
        private DepartureSimulator _departure = new DepartureSimulator();
        private Airport Airport;
        private DispatcherTimer dt;

        public Logic()
        {
            CreateAirport();
            //for (int i = 0; i < 5; i++)
            //{
            //    AddNewFlight(_arrival.GenerateArrival(data.Locations.ToList()));
            //    AddNewFlight(_departure.GenerateDeparture(data.Locations.ToList()));

            //}
        }


        #region Get Funcs
        public IEnumerable<Flight> GetFlights => data.Flights;

        public IEnumerable<Location> GetLocations => data.Locations;

        //public Airport GetAirport => data.Airport;
#endregion

        private void AddNewFlight(Flight flight)
        {
            if (flight != null)
            {
                //Airport.FlightsBoard.Enqueue(flight);
                data.AddFlight(flight);
            }
        }

        public void CreateAirport()
        {
            Airport airport = data.Airport;
            if(airport != null)
                Airport = airport;
        }
  

        public void Start()
        {
            var locationsList = data.Locations.ToList();
            dt = new DispatcherTimer();

            dt.Tick += (s, e) => AddNewFlight(_arrival.GenerateArrival(locationsList));
            dt.Tick += (s, e) => AddNewFlight(_departure.GenerateDeparture(locationsList));

            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Start();

        }

        private void ControlTower()
        {
            
        }
    }
}
