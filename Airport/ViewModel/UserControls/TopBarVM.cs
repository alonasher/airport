using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Airport.ViewModel.UserControls
{
    public class TopBarVM : ViewModelBase
    {
        private string time;

        public string Time { get => time; set =>Set(ref time, value); }
        private DispatcherTimer dt;

        public TopBarVM()
        {
            Time = DateTime.Now.ToLongTimeString();
            Start();
        }
        
        private void Start()
        {
            dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Tick += (s,e)=>Time = DateTime.Now.ToLongTimeString();
            dt.Start();
        }
    }
}
