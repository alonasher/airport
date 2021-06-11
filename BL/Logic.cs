using BL.Interfaces;
using Dal;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace BL
{
    public class Logic :ILogic
    {
        private Repository data = new Repository();
        private ArrivalSimulator _arrival = new ArrivalSimulator();
        private DepartureSimulator _departure = new DepartureSimulator();
        private Airport _airport;
        private Queue<Flight> _flightsBoard;
        private DispatcherTimer dt;

        public Logic()
        {
            CreateAirport();
            for (int i = 0; i < 5; i++)
            {
                AddNewFlight(_arrival.GenerateArrival(data.Locations.ToList()));
                AddNewFlight(_departure.GenerateDeparture(data.Locations.ToList()));

            }
            ControlTower();
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
                //_airport.FlightsBoard.Enqueue(flight);
                data.AddFlight(flight);
            }
        }

        public void CreateAirport()
        {
            _flightsBoard = new Queue<Flight>();
            Airport airport = data.Airport;

            //airport.Locations = GetAirportLocations(airport);

            if (airport != null)
            {
                //if(airport.FlightsBoard == null)
                //{
                //    airport.FlightsBoard = new Queue<Flight>();
                //    foreach (Flight item in data.Flights)
                //    {
                //        if (!item.Landed) airport.FlightsBoard.Enqueue(item);
                //    }
                //}
                _airport = airport;
            }


        }

        private List<Location> GetAirportLocations(Airport airport)
        {
            //get the locations that belongs to this airport.
            return data.Locations.Where((x) => x.Airports.Find(a => a.ID == airport.ID).ID == airport.ID).ToList();
        }

        public void Start()
        {
            var locationsList = GetLocations.ToList();
            dt = new DispatcherTimer();

            dt.Tick += (s, e) => AddNewFlight(_arrival.GenerateArrival(locationsList));
            dt.Tick += (s, e) => AddNewFlight(_departure.GenerateDeparture(locationsList));

            dt.Interval = new TimeSpan(0, 0, 10);
            dt.Start();
        }

        private void ControlTower()
        {
            //Queue<Task> tasks = new Queue<Task>();
            Queue<Flight> ongoingFlights = new Queue<Flight>();
            foreach (Flight item in data.Flights)
            {
                if (!item.Landed) ongoingFlights.Enqueue(item);
            }
            while(_airport.FlightsBoard.Count != 0 && _airport.FlightsBoard != null)
            {
                Flight departure = null, arrival = null;

                Flight current = null; /*_airport.FlightsBoard.Dequeue();*/
                if (FlightIsArrival(current)) arrival = current;
                else departure = current;
                //for arrival
                if (arrival != null) StartFlight(arrival,_airport.Locations);
                //for departure
                else if (departure != null) StartFlight(departure, _airport.Locations);
            }
        }

        private void StartFlight(Flight flight, List<Location> locations)
        {
            while (flight.FlightRoute.Count != 0)
            {
                Location flightCurrentLocation = null;  /*flight.FlightRoute.Peek();*/
                if (!IsOccupied(flightCurrentLocation))
                {
                    GetAirportLocation(flightCurrentLocation).Occupied = true;
                    int timeInMili = flightCurrentLocation.Duration * 1000;
                    Task.Delay(timeInMili);
                    //flight.FlightRoute.Dequeue();
                }
            }
        }

        private Location GetAirportLocation(Location currentLocation)
        {
            return _airport.Locations.Find((x) => x.ID == currentLocation.ID);
        }

        private bool IsOccupied(Location currentLocation)
        {
            return _airport.Locations.Find(((x) => x.ID == currentLocation.ID)).Occupied;
        }

        private static bool FlightIsArrival(Flight current)
        {
            return false; /*current.FlightRoute.Peek().Role == Role.Aerial;*/
        }
    }
}
