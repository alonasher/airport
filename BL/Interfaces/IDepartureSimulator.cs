using Models;
using System.Collections.Generic;

namespace BL.Interfaces
{
    public interface IDepartureSimulator
    { 
        Flight GenerateDeparture(List<Location> locations);
    }
}
