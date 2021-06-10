using BL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ArrivalSimulator : IArrivalSimulator
    {
        private Random r = new Random();

        public Flight GenerateArrival(List<Location> locations)
        {
            if (locations == null || locations.Count == 0)
                return null;

            Queue<Location> route = GetRandomArrivaleRoute(locations);
            Plane plane = SimulatorService.GetRandomPlane();

            Flight flight = new Flight()
            {
                FlightRoute = route.ToList(),
                Landed = false,
                Plane = plane.ToString()
            };
            return flight;
        }

        private Queue<Location> GetRandomArrivaleRoute(List<Location> locations)
        {
            Queue<Location> flightRoute = new Queue<Location>();
            //get first aerial location
            //Location aerial = locations.Find((x) => x.Role == Role.Aerial && x.Order == 1);
            //flightRoute.Enqueue(aerial);

            //get the rest aerial locations
            IEnumerable<Location> aerials = locations.FindAll((x) => x.Role == Role.Aerial);
            foreach (Location l in aerials)
            {
                flightRoute.Enqueue(l);
            }

            //get runway
            List<Location> runways = locations.FindAll((x) => x.Role == Role.Runway);
            int randomRunwayPos = r.Next(0, runways.Count);
            flightRoute.Enqueue(runways[randomRunwayPos]);

            //get arrrival track
            List<Location> ArrivalsTracks = locations.FindAll((x) => x.Role == Role.ArrivalTrack);
            int randomTrackPos = r.Next(0, ArrivalsTracks.Count);
            flightRoute.Enqueue(ArrivalsTracks[randomTrackPos]);

            //get random jetway
            List<Location> jetways = locations.FindAll((x) => x.Role == Role.JetWay);
            int randomStartingPos = r.Next(0, jetways.Count);
            flightRoute.Enqueue(jetways[randomStartingPos]);

            return flightRoute;
        }
    }
}
