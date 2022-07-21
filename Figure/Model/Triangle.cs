using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Figure.Model
{
    public class Triangle : Figure
    {
        public Triangle()
        {
            Name = "Triangle";
            Shape = new System.Windows.Shapes.Polygon
            {
                Points = new PointCollection()
            {
                new System.Windows.Point(0, 20),
                new System.Windows.Point(10, 0),
                new System.Windows.Point(20, 20)
            },
                Fill = new SolidColorBrush(Colors.Orange),
                StrokeThickness = 1,
                Stroke = Brushes.Black
            };
        }
    }
}
