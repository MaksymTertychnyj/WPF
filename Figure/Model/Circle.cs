using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Figure.Model
{
    public class Circle : Figure
    {
        public Circle()
        {
            Name = "Circle";
            Shape = new System.Windows.Shapes.Ellipse
            {
                Height = 20,
                Width = 20,
                Fill = new SolidColorBrush(Colors.Red),
                StrokeThickness = 1,
                Stroke = Brushes.Black
            };
        }

    }
}
