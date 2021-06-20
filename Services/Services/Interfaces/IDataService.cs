using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IDataService
    {
        void Start();
        Task<IEnumerable<Flight>> GetFlightsAsync { get; }
        Action UpdateData { get; set; }
        Task<Airport> GetAirportAsync { get; }
        Airport GetAirport { get; }
    }
}
