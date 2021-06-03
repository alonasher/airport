using BL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DataService : IDataService
    {
        private Logic data = new Logic();

        public Action UpdateData { get; set; }

        IEnumerable<Flight> GetFlights => data.GetFlights;
        Task<IEnumerable<Flight>> IDataService.GetFlightsAsync => Task.Run(() => GetFlights);

        public void CreateNewAirport(Airport airport)
        {
            //create new airport
        }


    }
}
