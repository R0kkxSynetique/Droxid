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
using DroxidClient;
using DroxidClient.DummyData;

namespace DroxidClient.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private MainWindow? _view;
        private User _client;
        private Guild? _selectedGuild;
        private Channel? _selectedChannel;

        public MainWindowViewModel()
        {
            _client = new User("tmp");
            GenerateTestData();
        }

        private void GenerateTestData()
        {
            List<Guild> guilds = new List<Guild>();
            guilds = MainWindowTestData.GenerateGuilds();
            _client = new User("mon", guilds);
            _selectedGuild = guilds[0];
            _selectedChannel = guilds[0].Channels[0];
            NotifyPropertyChanged(nameof(Guilds));
            NotifyPropertyChanged(nameof(Channels));
            NotifyPropertyChanged(nameof(SelectedChannels));
        }

        public ObservableCollection<Guild> Guilds
        {
            get { return new ObservableCollection<Guild>(_client.Guilds); }
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
                _selectedGuild = value;
                NotifyPropertyChanged(nameof(SelectedGuild));
                NotifyPropertyChanged(nameof(SelectedChannels));
                if(SelectedChannels.Count > 0)
                {
                    _selectedChannel = SelectedChannels[0];
                } else
                {
                    _selectedChannel = null;
                }
                NotifyPropertyChanged(nameof(SelectedChannel));
                NotifyPropertyChanged(nameof(Messages));
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
                NotifyPropertyChanged(nameof(Messages));
            }
        }

        public List<Message> Messages
        {
            get => SelectedChannel?.Messages ?? new List<Message>();
        }

        public void AddGuild(string name, User owner, List<Role> roles, List<Permission> permissions, List<Channel> channels, List<User>? users = null)
        {
            _client.Guilds.Add(new Guild(name, owner, roles, permissions, channels, users));
            NotifyPropertyChanged(nameof(Guilds));
        }

        public void AddGuild(Guild guild)
        {
            _client.Guilds.Add(guild);
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
        }

    }

}
