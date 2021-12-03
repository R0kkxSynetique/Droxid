using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
        private ServerList _guilds;
        private ObservableCollection<Channel> _currentChannels;

        public MainWindowViewModel()
        {
            _guilds = new ServerList();
            _currentChannels = new ObservableCollection<Channel>();
            _guilds.Add(new Guild(1, "MonCorp", new User(1, "Mon"), new List<Role>(), new List<Permission>(), new List<Channel>()));
            _guilds.Add(new Guild(2, "SynthetiqueClub", new User(2, "R0kkxSynthetique"), new List<Role>(), new List<Permission>(), new List<Channel>()));
            _guilds[0].AddChannel("General");
            _guilds[0].AddChannel("Ranks");
            _guilds[0].AddChannel("Github");
            _guilds[1].AddChannel("Accueil");
            _guilds[1].AddChannel("Saloon");
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
                if (_guilds.SelectedGuild is not null && _guilds.SelectedGuild.Channels is not null) channels = _guilds.SelectedGuild.Channels;
                return new ObservableCollection<Channel>(channels);
            }
        }

        public Guild CurrentGuild
        {
            get => _guilds.SelectedGuild;
            set
            {
                _guilds.SelectedGuild = value;
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

    public class ServerList : ObservableCollection<Guild>
    {
        Guild? _selectedGuild;

        public Guild SelectedGuild
        {
            get => _selectedGuild;
            set
            {
                _selectedGuild = value;
                
            }
        }
    }


}
