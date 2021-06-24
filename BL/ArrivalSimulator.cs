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
        

        public Flight GenerateArrival(List<Location> locations)
        {
            if (locations == null || locations.Count == 0)
                return null;

            var route = GetRandomArrivaleRoute(locations).ToList();
            //var route = GetRandomArrivaleRoute(locations);
            Plane plane = SimulatorService.GetRandomPlane();

            Flight flight = new Flight()
            {
                FlightRoute = route,
                Landed = false,
                Plane = plane.ToString()
            };
            return flight;
        }

        private Queue<Location> GetRandomArrivaleRoute(List<Location> locations)
        {
            Queue<Location> flightRoute = new Queue<Location>();

            flightRoute.Enqueue(GetAerial(locations, Role.AerialFirst));
            flightRoute.Enqueue(GetAerial(locations, Role.AerialSecond));
            flightRoute.Enqueue(GetAerial(locations, Role.AerialThird));


            flightRoute.Enqueue(GetRandomLeg(locations, Role.Runway));

            flightRoute.Enqueue(GetRandomLeg(locations, Role.ArrivalTrack));

            flightRoute.Enqueue(GetRandomLeg(locations, Role.JetWay));

            return flightRoute;
        }

        private Location GetRandomLeg(List<Location> locations,Role role)
        {
            Random r = new Random();
            var legs = locations.FindAll((x) => x.Role == role);
            int randomIndex = r.Next(0, legs.Count);
            return legs[randomIndex];
        }

        private static Location GetAerial(List<Location> locations,Role role)
        {
            return locations.Find((x) => x.Role == role);
        }
    }
}
