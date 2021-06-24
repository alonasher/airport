using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Airport.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Leg.xaml
    /// </summary>
    public partial class Leg : UserControl
    {
        public Leg(string text)
        {
            InitializeComponent();
            tb.Text = text;
        }
        

        //private void hexagon_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Path hexagon = sender as Path;
        //    CreateDataPath(hexagon.Width, hexagon.Height,hexagon);
        //}

        //PathFigure figure;
        //private void CreateDataPath(double width, double height, Path hexagon)
        //{
        //    height -= hexagon.StrokeThickness;
        //    width -= hexagon.StrokeThickness;

        //    PathGeometry geometry = new PathGeometry();
        //    figure = new PathFigure();

        //    //See for figure info http://etc.usf.edu/clipart/50200/50219/50219_area_hexagon_lg.gif
        //    figure.StartPoint = new Point(0.25 * width, 0);
        //    AddPoint(0.75 * width, 0,hexagon);
        //    AddPoint(width, 0.5 * height,hexagon);
        //    AddPoint(0.25 * width, height,hexagon);
        //    AddPoint(0.75 * width, height,hexagon);
        //    AddPoint(0, 0.5 * height,hexagon);
        //    figure.IsClosed = true;
        //    geometry.Figures.Add(figure);
        //    hexagon.Data = geometry;
        //}

        //private void AddPoint(double x, double y, Path hexagon)
        //{
        //    LineSegment segment = new LineSegment();
        //    segment.Point = new Point(x + 0.5 * hexagon.StrokeThickness,
        //        y + 0.5 * hexagon.StrokeThickness);
        //    figure.Segments.Add(segment);
        //}

    }
}
