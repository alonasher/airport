using GalaSoft.MvvmLight;
using Models;
using Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Airport.ViewModel.UserControls
{
    public class AirportVM :ViewModelBase
    {
        private IDataService service;
        private ObservableCollection<Location> legs;

        public ObservableCollection<Location> Legs { get => legs; set =>Set(ref legs,value) ; }
        private Models.Airport _airport;

        private DispatcherTimer dt;
        private int Refresh_Time=1;

        public AirportVM(IDataService service)
        {
            this.service = service;
            GetAirport();
            Start();
        }

        private void Start()
        {
            dt = new DispatcherTimer() { Interval = new TimeSpan(0, 0, Refresh_Time) };
            dt.Tick += (s, e) => GetAirport();
            dt.Start();
        }

        private void GetAirport()
        {
            _airport = service.GetAirport;
            Legs = new ObservableCollection<Location>(_airport.Legs);
        }
    }
}
