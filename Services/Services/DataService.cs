using BL;
using BL.Interfaces;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Services
{
    public class DataService : IDataService
    {
        private Logic _logic = new Logic();

        public DataService()
        {
            //_logic.Start();
        }

        public Action UpdateData { get; set; }

        IEnumerable<Flight> GetFlights => _logic.GetFlights;
        Task<IEnumerable<Flight>> IDataService.GetFlightsAsync => Task.Run(() => GetFlights);

        public void CreateNewAirport(Airport airport)
        {
            //create new airport
        }

    }
}
