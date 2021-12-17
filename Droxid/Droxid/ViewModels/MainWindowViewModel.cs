using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;
using Droxid;
using Droxid.Models;
using System.Timers;
using System.Windows.Threading;

namespace Droxid.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {


        private MainWindow? _view;
        private User _client;
        private Guild? _selectedGuild;
        private Channel? _selectedChannel;
        private DispatcherTimer _timer;


        public MainWindowViewModel()
        {
            _client = UserViewModel.GetUserByUsername("R0kkxSynetique");
            NotifyPropertyChanged(nameof(Guilds));
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += updateTimerEventHandler;
            //_timer.IsEnabled = true;

        }

        private void updateTimerEventHandler(Object? sender, EventArgs e)
        {
            Update();
        }

        public void Update()
        {
            NotifyPropertyChanged(nameof(_client));
        }

        public ObservableCollection<Guild> Guilds
        {
            get { return new ObservableCollection<Guild>(_client?.Guilds ?? new()); }
        }

        public List<Channel> Channels
        {
            get
            {
                List<Channel> channels = new List<Channel>();
                foreach (Guild guild in Guilds) channels.AddRange(guild.Channels);
                return channels;
            }
        }

        public Guild? SelectedGuild
        {
            get => _selectedGuild;
            set
            {
                if (_selectedGuild != value)
                {
                    _selectedGuild = value;
                    if (SelectedChannels.Count > 0)
                    {
                        _selectedChannel = SelectedChannels[0];
                    }
                    else
                    {
                        _selectedChannel = null;
                    }
                    NotifyPropertyChanged(nameof(SelectedGuild));
                }
            }
        }

        public List<Channel> SelectedChannels
        {
            get
            {
                List<Channel> channels = new List<Channel>();
                if (!(_selectedGuild is null) && !(_selectedGuild.Channels is null)) channels = _selectedGuild.Channels;
                return channels;
            }
        }

        public Channel? SelectedChannel
        {
            get => _selectedChannel;
            set
            {
                _selectedChannel = value;
                NotifyPropertyChanged(nameof(SelectedChannel));
            }
        }

        public List<Message> Messages
        {
            get => SelectedChannel?.Messages ?? new List<Message>();
        }

        //public void AddGuild(string name, User owner, List<Role> roles, List<Channel> channels, List<User>? users = null)
        //{
        //    _client.Guilds.Add(new Guild(name, owner, roles, channels, users));
        //    NotifyPropertyChanged(nameof(Guilds));
        //}

        public void AddGuild(Guild guild)
        {
            //_client.Guilds.Add(guild);
            NotifyPropertyChanged(nameof(Guilds));
        }

        public void register(MainWindow mainWindow)
        {
            _view = mainWindow;
        }

        //Property changed dependencies

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            switch (propName)
            {
                case nameof(_client):
                    NotifyPropertyChanged(nameof(Guilds));
                    break;
                case nameof(Guilds):
                    NotifyPropertyChanged(nameof(SelectedGuild));
                    break;
                case nameof(SelectedGuild):
                    NotifyPropertyChanged(nameof(SelectedChannels));
                    break;
                case nameof(SelectedChannels):
                    NotifyPropertyChanged(nameof(SelectedChannel));
                    break;
                case nameof(SelectedChannel):
                    NotifyPropertyChanged(nameof(Messages));
                    break;
            }
        }

    }

}
