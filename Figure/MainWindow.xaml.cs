using Figure.ViewModel;
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

namespace Figure
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel MainViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel = new MainViewModel() 
                { 
                    Elements = FigureArea.Children, 
                };
            MainViewModel.LocalizationProvider.ChangeLocalization(Model.Localization.RU, Resources);
            DataContext = MainViewModel;
        }

        private void CanvasSizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainViewModel.Pmax.X = Convert.ToInt32(e.NewSize.Width - 20);
            MainViewModel.Pmax.Y = Convert.ToInt32(e.NewSize.Height - 20);
        }
    }
}
