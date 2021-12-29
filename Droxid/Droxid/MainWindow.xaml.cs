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
using Droxid.DataBase;
using Droxid.Views;

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
            StartupWindow diag = new StartupWindow();
            diag.ShowDialog();
            if (!diag.Success) Close();
            _vm = new MainWindowViewModel(diag.Username);
            _vm.PropertyChanged += viewmodelProperyChangedEventHandler;
            this.DataContext = _vm;
            InitializeComponent();
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
            grdInput.Visibility = _vm.SelectedChannel == null ? Visibility.Collapsed : Visibility.Visible;
        }

        //Window events
        private void BtnDroxidClick(object sender, RoutedEventArgs e)
        {

        }

        private void onSelectChannel(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListView)
            {
                ListView listView = (ListView)sender;
                _vm.SelectedChannel = listView.SelectedItem as Channel;
                ictlMessages.ScrollToBottom();
            }
        }

        private void onSelectGuild(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListView)
            {
                ListView listView = (ListView)sender as ListView;
                _vm.SelectedGuild = listView.SelectedItem as Guild;
                if(_vm.SelectedGuild != null && _vm.SelectedGuild.Channels[0] != null)
                {
                    lstvChannels.SelectedItem = _vm.SelectedGuild.Channels[0];
                }
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _vm.SendMessage(txtMessage.Text);
                txtMessage.Clear();
                _vm.Update();
            }
        }

        private void btnCreateChannel_Click(object sender, RoutedEventArgs e)
        {
            if (_vm.SelectedGuild != null && !string.IsNullOrEmpty(txtInputChannel.Text))
            {
                _vm.CreateChannel(txtInputChannel.Text);
            }
        }
    }
}
