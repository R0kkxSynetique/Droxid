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
using System.Windows.Shapes;
using Droxid.ViewModels;

namespace Droxid.Views
{
    /// <summary>
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        private string _dbServer = "";
        private string _dbPassword = "";
        private string _dbUser = "";
        private string _dbName = "";
        private string _username = "";
        private StartupWindowViewModel? _vm;
        private bool _success;

        public StartupWindow()
        {
            InitializeComponent();
            _success = false;
            _vm = this.DataContext as StartupWindowViewModel;
        }


        public string? Username { get => _username; }
        public bool Success { get => _success; }

        private void btnSubmit(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtDBServer.Text) && !String.IsNullOrWhiteSpace(txtDBUser.Text) && !String.IsNullOrWhiteSpace(txtDBPassword.Text) && !String.IsNullOrWhiteSpace(txtDBName.Text) && !String.IsNullOrWhiteSpace(txtUsername.Text))
            {
                _dbServer = txtDBServer.Text;
                _dbPassword = txtDBPassword.Text;
                _dbUser = txtDBUser.Text;
                _dbName = txtDBName.Text;
                _username = txtUsername.Text;

                if (_vm?.Connect(_dbServer, _dbUser, _dbPassword, _dbName) ?? false)
                {
                    dbHeader.Background = (Brush)new BrushConverter().ConvertFrom("#36393f");
                    if (_vm.LoginAs(_username))
                    {
                        appHeader.Background = (Brush)new BrushConverter().ConvertFrom("#36393f");
                        _success = true;
                        this.Close();
                    }
                    else
                    {
                        appHeader.Background = new SolidColorBrush(Colors.Red);
                    }
                }
                else
                {
                    dbHeader.Background = new SolidColorBrush(Colors.Red);
                }
            }
        }
    }
}
