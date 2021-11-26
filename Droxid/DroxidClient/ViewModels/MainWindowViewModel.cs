using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

namespace DroxidClient.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private MainWindow _view;

        public MainWindowViewModel()
        {
            _view = new MainWindow();
        }

        public void inscription(MainWindow mainWindow)
        {
            _view = mainWindow;
        }

    }
}
