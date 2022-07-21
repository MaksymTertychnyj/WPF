using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Figure.Model
{
    public abstract class Figure : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public Shape? Shape { get; set; }

        private int dx = 1;
        private int dy = 1;

        public string? Name { get; set; }

        private int x;
        public int X
        {
            get { return x; }
            set
            {
                x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        private int y;
        public int Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        public void Move(PointMax Pmax)
        {
            if (x<0 || x==Pmax.X)
            {
                dx *= -1;
            }
            if (y<0 || y==Pmax.Y)
            {
                dy *= -1;
            }

            X += dx;
            Y += dy;
        }

        public void Draw()
        {
            Canvas.SetLeft(Shape, X);
            Canvas.SetTop(Shape, Y);
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
