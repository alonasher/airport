using Airport.Views.UserControls;
using GalaSoft.MvvmLight;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Airport.ViewModel.UserControls
{
    public class AirportLegsVM : ViewModelBase
    {
        private IDataService service;

        public Canvas _mainCanvas { get; set; }

        public Grid MainGrid { get => mainGrid; set { Set(ref mainGrid, value); } }
        Style s = Application.Current.Resources["hexagon"] as Style;
        private Grid mainGrid;

        public AirportLegsVM(IDataService service)
        {
            this.service = service;
            InitGrid();

            //InitAirport();
        }

        private void InitAirport()
        {
            _mainCanvas = new Canvas();
            foreach (Location item in service.GetAirport.Legs)
            {
                Leg l = new Leg(item.Role.ToString());
                SetElementOnCanvas(item.Coor.X, item.Coor.Y, l, _mainCanvas);
            }
        }

        private void SetElementOnCanvas(double left, double top, UIElement e, Canvas c)
        {
            Canvas.SetLeft(e, left);
            Canvas.SetTop(e, top);
            c.Children.Add(e);
        }

        private void InitGrid()
        {
            int size = service.GetAirport.Legs.Count;
            MainGrid = new Grid();
            for (int row = 0; row < size; row++)
            {
                MainGrid.RowDefinitions.Add(new RowDefinition());
                for (int col = 0; col < size; col++)
                {
                    if (row == 0)
                        MainGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    //add canvases maybe
                }
            }
            foreach (Location location in service.GetAirport.Legs)
            {
                Leg l = new Leg(location.Role.ToString());
                SetOnGrid(location.Coor, l, MainGrid);
            }
        }

        private void SetOnGrid(Coordinate coor,UIElement element ,Grid grid)
        {
            Grid.SetRow(element, ((int)coor.Y-1));
            Grid.SetColumn(element,((int)coor.X-1));
            grid.Children.Add(element);
        }
    }
}
