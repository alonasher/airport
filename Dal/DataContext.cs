using Models;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dal
{
    public class DataContext : DbContext
    {
        private string password = "Selaproject";

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        //public virtual DbSet<Plane> Planes { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        private MongoClient dbClient;


        public DataContext() : base("selaAirport")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
            _ = SqlProviderServices.Instance;
            //dbClient = new MongoClient($"mongodb+srv://sela:{password}@airport.xwydb.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            

            //var dbList = dbClient.ListDatabases().ToList();

            //Trace.WriteLine("The list of databases on this server is: ");
            //foreach (var db in dbList)
            //{
            //    Trace.WriteLine($"here... {db}");
            //}
        }

    }
}
