using Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Dal
{
    public class Repository :IRepository
    {
        private DataContext context = new DataContext();
        //private MongoClient context;

        public Repository()
        {
            #region db UPDATE
            List<Location> l = new List<Location>() {
                new Location(){ Coor = new Coordinate(){ X=3,Y=3},Duration = 1,Occupied = false, Role = Role.JetWay },
                new Location(){ Coor = new Coordinate(){ X=2,Y=2},Duration = 1,Occupied = false, Role = Role.Runway },
                new Location(){ Coor = new Coordinate(){ X=2,Y=3},Duration = 1,Occupied = false, Role = Role.TakeOffTrack },
                new Location(){ Coor = new Coordinate(){ X=2,Y=5},Duration = 1,Occupied = false, Role = Role.ArrivalTrack },
                new Location(){ Coor = new Coordinate(){ X=5,Y=1},Duration = 1,Occupied = false, Role = Role.Aerial } };
            context.Locations.AddRange(l);
            context.SaveChanges();

            //Queue<Flight> flights = new Queue<Flight>();
            //List<Flight> flights = new List<Flight>();
            //foreach (Flight f in context.Flights)
            //{
            //    //flights.Enqueue(f);
            //    flights.Add(f);
            //}
            //context.Flights.AddRange(flights);

            //Airport airport = new Airport()
            //{
            //    ID = 1,
            //    FlightsBoard = flights,
            //    Locations = context.Locations.ToList()
            //};
            //context.Airports.Add(airport);
            //context.SaveChanges();
            #endregion
        }

        #region Get
        public IEnumerable<Location> Locations => context.Locations;
            
        public IEnumerable<Flight> Flights => context.Flights;
        //public Airport Airport => context.Airports.FirstOrDefault();

        #endregion

        #region Add Funcs
        public void AddFlight(Flight flight)
        {
            context.Flights.Add(flight);
            context.SaveChanges();
        }

        public void AddLocation(Location location)
        {
            context.Locations.Add(location);
            context.SaveChanges();
        }

        //public void AddAirport(Airport airport)
        //{
        //    context.Airports.Add(airport);
        //    context.SaveChanges();
        //}
        #endregion

        #region Update Funcs
        public void UpdateLand(Flight flight)
        {
            var flightToUpdate = context.Flights.Find(flight.ID);
            flightToUpdate.Landed = true;
            context.SaveChanges();
        }
        #endregion
    }
}
