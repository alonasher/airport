using Dal;
using Models;
using Services.Static;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace BL
{
    public class Logic :ILogic
    {
        private const int GenerateTime = 3;
        private Repository data = new Repository();
        private ArrivalSimulator _arrival = new ArrivalSimulator();
        private DepartureSimulator _departure = new DepartureSimulator();
        private Airport _airport;
        private Queue<Flight> _flightsBoard;
        private DispatcherTimer dt;
        private DispatcherTimer dt2;
        private static object locker = new object();
        public static AutoResetEvent autoResetEvent = new AutoResetEvent(false);

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
        public IEnumerable<Flight> GetOngoingFlights => data.Flights2().Where(x=>x.Landed == false);

        public IEnumerable<Location> GetLocations => data.Locations;

        public Airport GetAirport => _airport;

        #endregion



        public void Start()
        {
            StartSimulators();
            //ControlTower();
            dt2 = new DispatcherTimer();
            dt2.Tick += (s, e) => ControlTower();
            dt2.Interval = new TimeSpan(0, 0, 5);
            dt2.Start();

        }

        private void AddNewFlight(Flight flight)
        {
                if (flight != null)
                {
                    _airport.FlightsBoard.Enqueue(flight);
                    data.AddFlight(flight);
                    //ResetEventStatic.AddResetEvent.WaitOne();
                    //Task.Run(() => StartFlight(flight));
                }
        }

        private void StartSimulators()
        {
            var locationsList = GetLocations.ToList();
            dt = new DispatcherTimer();

            dt.Tick += (s, e) =>  AddNewFlight(_arrival.GenerateArrival(locationsList));
            dt.Tick += (s, e) =>  AddNewFlight(_departure.GenerateDeparture(locationsList));

            dt.Interval = new TimeSpan(0, 0, GenerateTime);
            dt.Start();
        }

        private void CreateAirport()
        {
            _flightsBoard = new Queue<Flight>();
            foreach (Flight item in data.Flights2())
            {
                if (!item.Landed) _flightsBoard.Enqueue(item);
            }
            _airport = new Airport() { Legs = new ConcurrentBag<Location>(data.Locations), FlightsBoard = new ConcurrentQueue<Flight>(_flightsBoard) };
        }
        private void ControlInterval()
        {
            if(_airport.FlightsBoard.Count != 0)
            {
                Flight current;
                while (!_airport.FlightsBoard.TryDequeue(out current))
                {
                    if (current != null)
                        Task.Run(() => StartFlight(current));
                }

            }
        }

        private void ControlTower()
        {
            while (_airport.FlightsBoard.Count != 0)
            {
                Flight current;
                while(! _airport.FlightsBoard.TryDequeue(out current));
                //need to be task
                if (current != null)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(StartPool), current);
                    //Task.Run(() => StartFlight(current));
                }
            }
        }

        private void StartPool(object state)
        {
            //add lock?

                if (state is Flight flight)
                {
                    while (flight.FlightRoute.Count > 0)
                    {
                        Location flightCurrentLocation = flight.FlightRoute[0];
                        //Location flightCurrentLocation = flight.FlightRoute.Peek();
                        if (!IsOccupied(flightCurrentLocation))
                        {
                            ChangeLocationStatus(flightCurrentLocation, flight);
                            WaitDuration(flightCurrentLocation);
                            flight.FlightRoute.RemoveAt(0);
                            //flight.FlightRoute.Dequeue();
                            ChangeLocationStatus(flightCurrentLocation, flight);
                        }
                        Trace.WriteLine($"here... {flight.FlightRoute.Count}");

                    }
                    flight.Landed = true;
                    data.UpdateLand(flight);
                }
      
        }

        private void StartFlight(Flight flight)
        {
            lock (this)
            {
                while (flight.FlightRoute.Count > 0)
                {
                    Location flightCurrentLocation = flight.FlightRoute[0];
                    //Location flightCurrentLocation = flight.FlightRoute.Peek();
                    if (!IsOccupied(flightCurrentLocation))
                    {
                        ChangeLocationStatus(flightCurrentLocation,flight);
                        WaitDuration(flightCurrentLocation);
                        flight.FlightRoute.RemoveAt(0);
                        //flight.FlightRoute.Dequeue();
                        ChangeLocationStatus(flightCurrentLocation,flight);
                    }
                    Trace.WriteLine($"here... {flight.FlightRoute.Count}");
  
                }
                flight.Landed = true;
                data.UpdateLand(flight);
            }
        }

        private static void WaitDuration(Location flightCurrentLocation)
        {
            int timeInMili = flightCurrentLocation.Duration * 1000;
            Thread.Sleep(timeInMili);
        }

        private void ChangeLocationStatus(Location currentLocation,Flight currentFlight)
        {
            var check= _airport.Legs.FirstOrDefault((x) => x.ID == currentLocation.ID);
            if (check == null) return;

            _airport.Legs.FirstOrDefault((x) => x.ID == currentLocation.ID).Occupied = !_airport.Legs.FirstOrDefault((x) => x.ID == currentLocation.ID).Occupied;
            if (_airport.Legs.FirstOrDefault(x => x.ID == currentLocation.ID).FlightID.Equals(0))
                _airport.Legs.FirstOrDefault(x => x.ID == currentLocation.ID).FlightID = currentFlight.ID;
            else
                _airport.Legs.FirstOrDefault(x => x.ID == currentLocation.ID).FlightID.Equals(0);
        }

        private bool IsOccupied(Location currentLocation)
        {
            return _airport.Legs.FirstOrDefault(((x) => x.ID == currentLocation.ID)).Occupied;
        }
    }
}
