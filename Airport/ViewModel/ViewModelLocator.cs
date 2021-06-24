
using Airport.ViewModel.UserControls;
using BL;
using BL.Interfaces;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Services;
using Services.Interfaces;
using System.Data.Services;

namespace Airport.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            
            SimpleIoc.Default.Register<IArrivalService, ArrivalService>();
            SimpleIoc.Default.Register<IDepartureService, DepartureService>();
            SimpleIoc.Default.Register<IDataService, DataService>();


            SimpleIoc.Default.Register<FlightsVM>();
            SimpleIoc.Default.Register<TopBarVM>();
            SimpleIoc.Default.Register<AirportVM>();
            SimpleIoc.Default.Register<AirportLegsVM>();
        }

        public FlightsVM FlightsView{ get { return ServiceLocator.Current.GetInstance<FlightsVM>(); } }
        public TopBarVM TopBarView { get { return ServiceLocator.Current.GetInstance<TopBarVM>(); } }
        public AirportVM AirportView { get { return ServiceLocator.Current.GetInstance<AirportVM>(); } }
        public AirportLegsVM airportLegsView { get { return ServiceLocator.Current.GetInstance<AirportLegsVM>(); } }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}