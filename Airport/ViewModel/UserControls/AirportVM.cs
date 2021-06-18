using GalaSoft.MvvmLight;
using Models;
using Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Airport.ViewModel.UserControls
{
    public class AirportVM :ViewModelBase
    {
        private IDataService service;
        private ObservableCollection<Location> legs;

        public ObservableCollection<Location> Legs { get => legs; set =>Set(ref legs,value) ; }
        private Models.Airport _airport;

        public AirportVM(IDataService service)
        {
            this.service = service;
            GetFlightsAsync();
            
        }

        //not working!!
        private async void GetFlightsAsync()
        {
            _airport = await service.GetAirportAsync;
            Legs = new ObservableCollection<Location>(_airport.Legs);
        }
    }
}
