using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Figure.Model
{
    public class Rectangle : Figure
    {
        public Rectangle()
        {
            Name = "Rectangle";
            Shape = new System.Windows.Shapes.Rectangle()
            {
                Height = 20,
                Width = 20,
                Fill = new SolidColorBrush(Colors.Blue),
                StrokeThickness = 1,
                Stroke = Brushes.Black
            };
        }
    }
}
