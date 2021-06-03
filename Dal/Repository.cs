using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Repository :IRepository
    {
        private DataContext data = new DataContext();

        public Repository()
        {
            //data.Planes.AddRange(new List<Plane>() {
            //    new Plane() { Model = "ZX123", Seats = 100 },
            //    new Plane() { Model = "AB456", Seats = 101}
            //});
            //data.Locations.AddRange(new List<Location>()
            //{
            //    new Location(){Name="First", Coor=new Coordinate(){X=12.3,Y=10.4},Duration=2},
            //    new Location(){Name="Second", Coor=new Coordinate(){X=13.3,Y=11},Duration=1},
            //});

            //Queue<Location> process = new Queue<Location>();
            //process.Enqueue(new Location() { Name = "First", Coor = new Coordinate() { X = 12.3, Y = 10.4 }, Duration = 2 });
            //process.Enqueue(new Location() { Name = "Second", Coor = new Coordinate() { X = 13.3, Y = 11 }, Duration = 1 });
            //data.Flights.AddRange(new List<Flight>()
            //{
            //    new Flight(){FlightProcess=process,Landed=true,PlaneID=1}
            //});
            //data.SaveChanges();
        }

        #region Get
        public IEnumerable<Location> Locations => data.Locations;

        public IEnumerable<Flight> Flights => data.Flights;

        public IEnumerable<Plane> Planes => data.Planes;
        #endregion

        #region Add Funcs
        public void AddFlight(Flight flight)
        {
            data.Flights.Add(flight);
            data.SaveChanges();
        }

        public void AddLocation(Location location)
        {
            data.Locations.Add(location);
            data.SaveChanges();
        }

        public void AddPlane(Plane plane)
        {
            data.Planes.Add(plane);
            data.SaveChanges();
        }
        #endregion
    }
}
