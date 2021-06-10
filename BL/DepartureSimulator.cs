using BL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace BL
{
    public class DepartureSimulator : IDepartureSimulator
    {
  
        private Random r = new Random();

        public Flight GenerateDeparture(List<Location> locations)
        {
            if (locations == null || locations.Count == 0)
                return null;
            Queue<Location> route = GetRandomDepartureRoute(locations);
            Plane plane = SimulatorService.GetRandomPlane();

            Flight flight = new Flight()
            {
                FlightRoute = route.ToList(),
                Landed = false,
                Plane = plane.ToString()
            };
            return flight;
        }

        private Queue<Location> GetRandomDepartureRoute(List<Location> locations)
        {
            Queue<Location> flightRoute = new Queue<Location>();
            //get random jetway
            List<Location> jetways = locations.FindAll((x) => x.Role == Role.JetWay);
            int randomStartingPos = r.Next(0, jetways.Count);
            flightRoute.Enqueue(jetways[randomStartingPos]);

            //get takeoff track
            List<Location> takeOffTracks = locations.FindAll((x) => x.Role == Role.TakeOffTrack);
            int randomTrackPos = r.Next(0, takeOffTracks.Count);
            flightRoute.Enqueue(takeOffTracks[randomTrackPos]);

            //get runway
            List<Location> runways = locations.FindAll((x) => x.Role == Role.Runway);
            int randomRunwayPos = r.Next(0, runways.Count);
            flightRoute.Enqueue(runways[randomRunwayPos]);

            return flightRoute;
        }

        #region old code
        //private int seconds = 1;
        //private DispatcherTimer dt;

        //public Queue<Flight> Departures { get; set; }
        //public List<Location> AirportRoute { get; set; }


        public void Start()
        {
            //dt.Start();
        }

        private void DepartureManager()
        {

            //Flight flight = Departures.Peek();
            //int startingPos = AirportRoute.FindIndex((x) => x.ID == flight.FlightRoute.Peek().ID);
            //if (!AirportRoute[startingPos].Occupied)
            //{
            //    AirportRoute[startingPos].flight = flight;
            //    Departures.Dequeue();
            //}

        }

        //private DepartureSimulator()
        //{
        //    //dt = new DispatcherTimer();
        //    //dt.Tick +=(s,e)=> StartDeparture();
        //    //dt.Tick += (s, e) => DepartureManager();
        //    //dt.Interval = new TimeSpan(0, 0, seconds);
        //}
        #endregion
    }
}
