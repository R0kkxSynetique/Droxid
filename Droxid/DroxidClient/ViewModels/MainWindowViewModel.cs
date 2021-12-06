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

namespace DroxidClient.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private MainWindow? _view;
        private Guild? _currentGuild;
        private User _client;

        public MainWindowViewModel()
        {
            _client = new User(-1,"tmp");
            GenerateTestData();
        }

        private void GenerateTestData()
        {
            List<Guild> guilds = new List<Guild>();
            guilds.Add(new Guild(1, "MonCorp", new User(1, "Mon"), new List<Role>(), new List<Permission>(), new List<Channel>()));
            guilds.Add(new Guild(2, "SynthetiqueClub", new User(2, "R0kkxSynthetique"), new List<Role>(), new List<Permission>(), new List<Channel>()));
            guilds[0].AddChannel("General");
            guilds[0].AddChannel("Ranks");
            guilds[0].AddChannel("Github");
            guilds[1].AddChannel("Accueil");
            guilds[1].AddChannel("Saloon");
            _client = new User(0, "mon", guilds);
            _currentGuild = guilds[0];
            NotifyPropertyChanged(nameof(Guilds));
            NotifyPropertyChanged(nameof(Channels));
            NotifyPropertyChanged(nameof(CurrentChannels));
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

        public List<Channel> CurrentChannels
        {
            get
            {
                List<Channel> channels = new List<Channel>();
                if (!(_currentGuild is null) && !(_currentGuild.Channels is null)) channels = _currentGuild.Channels;
                return channels;
            }
        }

        public Guild? CurrentGuild
        {
            get => _currentGuild;
            set
            {
                _currentGuild = value;
                NotifyPropertyChanged(nameof(CurrentGuild));
                NotifyPropertyChanged(nameof(CurrentChannels));
            }
        }


        public void register(MainWindow mainWindow)
        {
            _view = mainWindow;
        }

        public void AddGuild(int id, string name, User owner, List<Role> roles, List<Permission> permissions, List<Channel> channels, List<User>? users = null)
        {
            _client.Guilds.Add(new Guild(id, name, owner, roles, permissions, channels, users));
            NotifyPropertyChanged(nameof(Guilds));
        }

        //Property changed dependencies

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }

}
