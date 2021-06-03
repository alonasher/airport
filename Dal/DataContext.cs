using Models;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Dal
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
        public DataContext() : base("selaAirport")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
            _ = SqlProviderServices.Instance;
        }
    }
}
