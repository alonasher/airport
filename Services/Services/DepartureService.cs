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
    public class DepartureService :IDepartureService
    {
        private DepartureSimulator departure= new DepartureSimulator();

        public Flight GenerateDeparture(List<Location> locations)
        {
            return departure.GenerateDeparture(locations);
        }
    }
}
