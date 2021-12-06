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
using Droxid;
using DroxidClient.ViewModels;

namespace DroxidClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = (MainWindowViewModel)this.DataContext;
            _vm.register(this);
        }

        //Window events
        private void BtnDroxidClick(object sender, RoutedEventArgs e)
        {
            _vm.AddGuild(1, "test", new User(1, "tester"), new List<Role>(), new List<Permission>(), new List<Channel>());
        }

        private void BtnSelectServer(object sender, RoutedEventArgs e)
        {
            if(sender is Button && sender is not null)
            {
                Button button = (Button)sender;
                _vm.CurrentGuild = (Guild)button.DataContext;
            }
        }
    }
}
