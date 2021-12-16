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
using Droxid.ViewModels;
using Droxid.Models;

namespace Droxid
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
            
        }

        private void lstvSelectChannel(object sender, SelectionChangedEventArgs e)
        {
            if(sender is ListView)
            {
                ListView listView = (ListView)sender;
                _vm.SelectedChannel = listView.SelectedItem as Channel;
            }
        }

        private void lstvSelectServer(object sender, SelectionChangedEventArgs e)
        {
            if(sender is ListView)
            {
                ListView listView = ( ListView)sender as ListView;
                _vm.SelectedGuild = listView.SelectedItem as Guild;
            }
        }
    }
}
