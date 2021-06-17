﻿using BL.Interfaces;
using Dal;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
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
            //for (int i = 0; i < 5; i++)
            //{
            //    AddNewFlight(_arrival.GenerateArrival(data.Locations.ToList()));
            //    AddNewFlight(_departure.GenerateDeparture(data.Locations.ToList()));

            //}
        }


        #region Get Funcs
        public IEnumerable<Flight> GetOngoingFlights => data.Flights.Where(x=>x.Landed == false);

        public IEnumerable<Location> GetLocations => data.Locations;

#endregion



        public void Start()
        {
            CreateAirport();
            StartSimulators();
            ControlTower();
        }

        private void AddNewFlight(Flight flight)
        {
            if (flight != null)
            {
                _airport.FlightsBoard.Enqueue(flight);
                data.AddFlight(flight);
            }
        }

        private void StartSimulators()
        {
            var locationsList = GetLocations.ToList();
            dt = new DispatcherTimer();

            dt.Tick += (s, e) =>  AddNewFlight(_arrival.GenerateArrival(locationsList));
            dt.Tick += (s, e) =>  AddNewFlight(_departure.GenerateDeparture(locationsList));

            dt.Interval = new TimeSpan(0, 0, 10);
            dt.Start();
        }

        private void CreateAirport()
        {
            _flightsBoard = new Queue<Flight>();
            foreach (Flight item in data.Flights)
            {
                if (!item.Landed) _flightsBoard.Enqueue(item);
            }
            _airport = new Airport() { Legs = data.Locations.ToList(), FlightsBoard = _flightsBoard };
        }

        private void ControlTower()
        {
            //Queue<Task> tasks = new Queue<Task>();
            while (_airport.FlightsBoard.Count != 0 && _airport.FlightsBoard != null)
            {
                Flight current = _airport.FlightsBoard.Dequeue();
                //need to be task
                if (current != null) Task.Run(() => StartFlight(current));
            }
        }

        private void StartFlight(Flight flight)
        {
            lock (this)
            {
                while (flight.FlightRoute.Count > 0)
                {
                    Location flightCurrentLocation = flight.FlightRoute[0];
                    if (!IsOccupied(flightCurrentLocation))
                    {
                        ChangeLocationStatus(flightCurrentLocation);
                        WaitDuration(flightCurrentLocation);
                        flight.FlightRoute.RemoveAt(0);
                        ChangeLocationStatus(flightCurrentLocation);
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

        private void ChangeLocationStatus(Location currentLocation)
        {
            _airport.Legs.Find((x) => x.ID == currentLocation.ID).Occupied = !_airport.Legs.Find((x) => x.ID == currentLocation.ID).Occupied;
        }

        private bool IsOccupied(Location currentLocation)
        {
            return _airport.Legs.Find(((x) => x.ID == currentLocation.ID)).Occupied;
        }
    }
}
