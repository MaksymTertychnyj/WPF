using Figure.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figure.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public UIElementCollection? Elements { get; set; }
        public ObservableCollection<Model.Figure> Figures { get; set; }
        public LocalizationProvider LocalizationProvider { get; set; }
        public ObservableCollection<string> ListOfLocalization { get; set; }

        public MainViewModel()
        {
            _Pmax = new Model.PointMax();
            Figures = new ObservableCollection<Model.Figure>();
            LocalizationProvider = new LocalizationProvider();
            ListOfLocalization = new ObservableCollection<string>();
            InitListOfLocalization();
            Task.FromResult(Cycle());
        }

        public Model.Localization SelectedLocalization 
        {
            get { return LocalizationProvider.CurrentLocalization; }
            set
            {
                LocalizationProvider.ChangeLocalization(value, LocalizationProvider.MainWindowResources);
                RefreshFigureList();
                OnPropertyChanged(nameof(SelectedLocalization));
                
            }
        }

        private Model.PointMax _Pmax;
        public Model.PointMax Pmax
        {
            get { return _Pmax; }
            set
            {
                _Pmax = value;
                OnPropertyChanged(nameof(Pmax));
            }
        }

        public async Task Cycle()
        {
            while(true)
            {
                if (Figures.Count != 0)
                {
                    foreach (Model.Figure figure in Figures.ToList())
                    {
                        if (figure.X > Pmax.X || figure.Y > Pmax.Y)
                        {
                            Elements!.Remove(figure.Shape);
                            Figures.Remove(figure);
                        }
                        else
                        {
                            figure.Move(Pmax);
                            figure.Draw();
                        }
                    }
                }
                    await Task.Delay(10);
            }
        }

        public ICommand AddRectangle
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    CreateFigure(new Model.Rectangle());
                });
            }
        }

        public ICommand AddCircle
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    CreateFigure(new Model.Circle());
                });
            }
        }

        public ICommand AddTriangle
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    CreateFigure(new Model.Triangle());
                });
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void CreateFigure(Model.Figure figure)
        {
            Canvas.SetLeft(figure.Shape, 0);
            Canvas.SetTop(figure.Shape, 0);

            Figures!.Add(figure);
            Elements!.Add(figure.Shape);
            OnPropertyChanged(nameof(Figures));
        }

        private void RefreshFigureList()
        {
            var tempFigures = new ObservableCollection<Model.Figure>();
            foreach (var figure in Figures)
            {
                tempFigures.Add(figure);
            }
            Figures = tempFigures;
            OnPropertyChanged(nameof(Figures));
        }

        private void InitListOfLocalization()
        {
            var values = Enum.GetValues(typeof(Model.Localization));
            foreach (var value in values)
            {
                ListOfLocalization.Add(value.ToString()!);
            }
        }
    }
}
