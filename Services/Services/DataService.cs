﻿using BL;
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



        public DataService(){}

        public Action UpdateData { get; set; }

        public IEnumerable<Flight> GetFlights => _logic.GetOngoingFlights;
        public Task<IEnumerable<Flight>> GetFlightsAsync => Task.Run(() => GetFlights);

        public void Start()
        {
            _logic.Start();
        }

    }
}
