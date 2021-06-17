using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Models;
using Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Threading;

namespace Airport.ViewModel.UserControls
{
    public class FlightsVM : ViewModelBase
    {
        private IDataService service;
        private ObservableCollection<Flight> flights;

        public ObservableCollection<Flight> Flights { get => flights; set => Set(ref flights, value); }
        public RelayCommand RefreshCommand { get; set; }
        private DispatcherTimer dt;
        private int seconds = 1;
        public FlightsVM(IDataService service)
        {
            this.service = service;
            service.Start();
            
            service.UpdateData += GetFlights;
            GetFlights();
            RefreshCommand = new RelayCommand(Refresh);

            dt = new DispatcherTimer() { Interval = new TimeSpan(0, 0, seconds) };
            dt.Tick += (s, e) => Refresh();
            dt.Start();
        }

        private void Refresh()
        {
            service.UpdateData?.Invoke();
        }

        private async void GetFlights()
        {
           Flights = new ObservableCollection<Flight>(await service.GetFlightsAsync);
        }
    }
}
