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
using System.ComponentModel;
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
            _vm.PropertyChanged += viewmodelProperyChangedEventHandler;
        }

        //ViewModel events
        private void viewmodelProperyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedChannel":
                    updateInputVisibility();
                    break;
            }
        }

        private void updateInputVisibility()
        {
            grdInput.Visibility =_vm.SelectedChannel == null ? Visibility.Collapsed : Visibility.Visible;
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

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                _vm.SendMessage(txtMessage.Text);
                txtMessage.Clear();
            }
        }
    }
}
