using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vpn.Core;

namespace Vpn.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand MoveWindowCommand { get; set; }

        private object _currentView;

        public object CurrentView 
        { 
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            MoveWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.DragMove(); });
        }
    }
}
