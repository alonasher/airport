using BL;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ArrivalService : IArrivalService
    {
        ArrivalSimulator arrival = new ArrivalSimulator();
        public Flight GenerateArrival(List<Location> locations)
        {
            return arrival.GenerateArrival(locations);
        }
    }
}
