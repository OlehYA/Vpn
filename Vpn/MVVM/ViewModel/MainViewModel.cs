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

        public RelayCommand ShutdownWindowsCommand { get; set; }

        public RelayCommand MaximizeWIndowCommand { get; set; }

        public RelayCommand MinimaizemWindowsCommand { get; set; }

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

        public ProtectionViewModel ProtectionVM { get; set; }

        public MainViewModel()
        {
            ProtectionVM = new ProtectionViewModel();
            CurrentView = ProtectionVM;


            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            MoveWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.DragMove(); });
            ShutdownWindowsCommand = new RelayCommand(o => { Application.Current.Shutdown(); });
            MaximizeWIndowCommand = new RelayCommand(o => 
            { 
                if(Application.Current.MainWindow.WindowState == WindowState.Maximized)
                    Application.Current.MainWindow.WindowState= WindowState.Normal;
                else
                    Application.Current.MainWindow.WindowState= WindowState.Maximized;
            });
            MinimaizemWindowsCommand = new RelayCommand(o => { Application.Current.MainWindow.WindowState = WindowState.Minimized; });
        }
    }
}
