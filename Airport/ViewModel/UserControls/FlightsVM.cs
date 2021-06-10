using GalaSoft.MvvmLight;
using Models;
using Services;
using System.Collections.ObjectModel;

namespace Airport.ViewModel.UserControls
{
    public class FlightsVM : ViewModelBase
    {
        private IDataService service;
        private ObservableCollection<Flight> flights;

        public ObservableCollection<Flight> Flights { get => flights; set => Set(ref flights, value); }

        public FlightsVM(IDataService service)
        {
            this.service = service;
            service.UpdateData += GetFlights;
            GetFlights();
        }

        private async void GetFlights()
        {
            Flights = new ObservableCollection<Flight>(await service.GetFlightsAsync);
        }
    }
}
