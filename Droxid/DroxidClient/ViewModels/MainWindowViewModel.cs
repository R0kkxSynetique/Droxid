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
    public class MainWindowViewModel
    {
        private MainWindow? _view;
        private ObservableCollection<Guild> _guilds;
        private Guild? _currentGuild;
        private ObservableCollection<Channel> _currentChannels;

        public MainWindowViewModel()
        {
            _guilds = new ObservableCollection<Guild>();
            _currentChannels = new ObservableCollection<Channel>();
            _guilds.Add(new Guild(1, "MonCorp", new User(1, "Mon"), new List<Role>(), new List<Permission>(), new List<Channel>()));
            _guilds.Add(new Guild(2, "SynthetiqueClub", new User(2, "R0kkxSynthetique"), new List<Role>(), new List<Permission>(), new List<Channel>()));
            _guilds[0].AddChannel("General");
            _guilds[0].AddChannel("Ranks");
            _guilds[0].AddChannel("Github");
            _guilds[1].AddChannel("Accueil");
            _guilds[1].AddChannel("Saloon");
            _currentGuild = _guilds[0];
        }

        public ObservableCollection<Guild> Guilds
        {
            get { return _guilds; }
        }

        public ObservableCollection<Channel> Channels
        {
            get
            {
                List<Channel> channels = new List<Channel>();
                foreach (Guild guild in _guilds) channels.AddRange(guild.Channels);
                return new ObservableCollection<Channel>(channels);
            }
        }

        public ObservableCollection<Channel> CurrentChannels
        {
            get
            {
                List<Channel> channels = new List<Channel>();
                if (!(_currentGuild is null) && !(_currentGuild.Channels is null)) channels = _currentGuild.Channels;
                return new ObservableCollection<Channel>(channels);
            }
        }

        public Guild CurrentGuild
        {
            get => _currentGuild;
            set
            {
                _currentGuild = value;
            }
        }


        public void register(MainWindow mainWindow)
        {
            _view = mainWindow;
        }

        public void AddGuild(int id, string name, User owner, List<Role> roles, List<Permission> permissions, List<Channel> channels, List<User> users = null)
        {
            _guilds.Add(new Guild(id, name, owner, roles, permissions, channels, users));
        }


    }

    public class ObservableGuild : Guild, INotifyPropertyChanged
    {
        public ObservableGuild(int id, string name, User owner, List<Role> roles, List<Permission> permissions, List<Channel> channels, List<User> users = null) : base(id, name, owner, roles, permissions, channels, users)
        {
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

}
