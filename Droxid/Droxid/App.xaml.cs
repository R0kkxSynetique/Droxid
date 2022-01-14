using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Droxid.Views;

namespace Droxid
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            StartupWindow diag = new StartupWindow();
            diag.ShowDialog();

            if (diag.Success && !String.IsNullOrWhiteSpace(diag.Username))
            {
                MainWindow mainWindow = new MainWindow(diag.Username);
                mainWindow.ShowDialog();
            }

            Current.Shutdown();
        }
    }
}
