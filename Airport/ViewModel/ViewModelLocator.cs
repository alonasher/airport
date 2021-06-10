
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
        }

        public FlightsVM FlightsView{ get { return ServiceLocator.Current.GetInstance<FlightsVM>(); } }

        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}