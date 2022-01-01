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
using System.Diagnostics;

namespace Droxid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , INotifyPropertyChanged
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

        //Visual states
        public Visibility GuildControlsVisibility
        {
            get { return (_vm.IsCurrentGuildOwner) ? Visibility.Visible : Visibility.Collapsed; }
        }

        public Visibility ChannelControlsVisibility
        {
            get => _vm.SelectedChannel != null ? Visibility.Visible : Visibility.Collapsed;
        }

        public Visibility ChannelEditVisibility
        {
            get => (_vm.IsCurrentGuildOwner && _vm.SelectedChannel != null) ? Visibility.Visible: Visibility.Collapsed;
        }

        //ViewModel events
        private void viewmodelProperyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedGuild":
                    NotifyPropertyChanged(nameof(GuildControlsVisibility));
                    break;
                case "SelectedChannel":
                    NotifyPropertyChanged(nameof(ChannelControlsVisibility));
                    NotifyPropertyChanged(nameof(ChannelEditVisibility));
                    break;
            }
        }

        //Window events
        private void BtnDroxidClick(object sender, RoutedEventArgs e)
        {

        }

        private void onCreateGuildClick(object sender, RoutedEventArgs e)
        {
            _vm.CreateGuild();
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
                if(_vm.SelectedGuild != null && _vm.SelectedGuild.Channels.Count > 0 && _vm.SelectedGuild.Channels[0] != null)
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

        private void onCreateChannelClick(object sender, RoutedEventArgs e)
        {
            if (_vm.SelectedGuild != null)
            {
                _vm.CreateChannel();
            }
        }

        private void onEditChannelClick(object sender, RoutedEventArgs e)
        {
            if(sender is Button btnEditChannel)
            {
                _vm.EditChannel();
            }
        }

        //Property changed dependencies

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
