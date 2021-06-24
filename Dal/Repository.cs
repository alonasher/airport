using Models;
using Services.Static;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;


namespace Dal
{
    public class Repository : IRepository
    {
        private DataContext context = new DataContext();
        private object locker = new object();
        //private MongoClient context;

        public Repository()
        {
            #region db UPDATE
            List<Location> l = new List<Location>() {
                new Location(){ Coor = new Coordinate(){ X=3,Y=3},Duration = 1,Occupied = false, Role = Role.JetWay },
                new Location(){ Coor = new Coordinate(){ X=2,Y=2},Duration = 1,Occupied = false, Role = Role.Runway },
                new Location(){ Coor = new Coordinate(){ X=2,Y=3},Duration = 1,Occupied = false, Role = Role.TakeOffTrack },
                new Location(){ Coor = new Coordinate(){ X=2,Y=5},Duration = 1,Occupied = false, Role = Role.ArrivalTrack },
                new Location(){ Coor = new Coordinate(){ X=3,Y=1},Duration = 1,Occupied = false, Role = Role.AerialFirst },
                new Location(){ Coor = new Coordinate(){ X=4,Y=1},Duration = 1,Occupied = false, Role = Role.AerialSecond },
                new Location(){ Coor = new Coordinate(){ X=5,Y=1},Duration = 1,Occupied = false, Role = Role.AerialThird },
            };
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
        public IEnumerable<Location> Locations => new List<Location>(context.Locations);

        public IEnumerable<Flight> Flights => new List<Flight>(context.Flights);
        public IEnumerable<Flight> Flights2()
        {
            lock(locker)
                return new List<Flight>(context.Flights); 
        }

        //public Airport Airport => context.Airports.FirstOrDefault();


        #endregion

        #region Add Funcs
        public void AddFlight(Flight flight)
        {
            context.Flights.Add(flight);
            lock (locker)
            {
                context.SaveChanges();
            }
            //ResetEventStatic.AddResetEvent.Set();
        }

        public void AddLocation(Location location)
        {
            context.Locations.Add(location);
            context.SaveChanges();
        }

        #endregion

        #region Update Funcs
        public void UpdateLand(Flight flight)
        {
            lock (locker)
            {

                context.Flights.Find(flight.ID).Landed = true;
                lock (locker)
                {
                    
                    
                    context.SaveChanges();
                }
            }
        }
        #endregion
    }
}
