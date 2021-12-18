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
using System.Diagnostics;

namespace Droxid.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {


        private MainWindow? _view;
        private User _client;
        private Guild? _selectedGuild;
        private Channel? _selectedChannel;
        private DispatcherTimer _timer;

        //Caching
        private List<Guild> _guilds = new List<Guild>();
        private List<Channel> _channels = new List<Channel>();


        public MainWindowViewModel()
        {
            _client = ViewModel.GetUserByUsername("R0kkxSynetique");
            NotifyPropertyChanged(nameof(Guilds));
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(0.5);
            _timer.Tick += updateTimerEventHandler;
            _timer.IsEnabled = true;

        }

        private void updateTimerEventHandler(Object? sender, EventArgs e)
        {
            Update();
        }

        public void Update()
        {
            //List<Guild> pastGuilds = new List<Guild>(_guilds);
            //Guilds update
            List<Guild> guilds = ViewModel.GetUserGuilds(_client.Username) ?? new();
            //Compare cached with the new
            for (int i = 0; i < _guilds.Count; i++)
            {
                Guild? dbGuild = guilds.Find(guild => guild.Id == _guilds[i].Id);
                if (dbGuild == null)
                {
                    //Remove guild from cache if no reference is found in the database result
                    _guilds.Remove(_guilds[i]);
                }
                else
                {
                    if (!dbGuild.Equals(_guilds[i]))
                    {
                        //Update Content
                        _guilds[i].Copy(dbGuild);
                    }
                }

            }
            //Add uncached to cache
            guilds.ForEach(guild =>
            {
                if (_guilds.Find(cachedGuild => cachedGuild.Id == guild.Id) == null) _guilds.Add(guild);
            });

            //Channels update
            if (SelectedGuild != null)
            {
                List<Channel> dbChannels = ViewModel.GetGuildChannels(SelectedGuild.Id);
                //Compare cache and DB
                for (int i = 0; i < _channels.Count; i++)
                {
                    Channel? dbChannel = dbChannels.Find(channel => channel.Id == _channels[i].Id);
                    if (dbChannel == null)
                    {
                        //Remove channel from cache if no reference is found in the database result
                        _channels.Remove(_channels[i]);
                    }
                    else
                    {
                        if (!dbChannel.Equals(_channels[i]))
                        {
                            //Update Content
                            _channels[i].Copy(dbChannel);
                        }
                    }

                }
                //Add uncached to cache
                dbChannels.ForEach(dbChannel =>
                {
                    if (_channels.Find(cachedChannel => cachedChannel.Id == dbChannel.Id) == null) _channels.Add(dbChannel);
                });
            }
            else
            {
                _channels.Clear();
            }


            NotifyPropertyChanged(nameof(_client));
        }


        //TODO : create a generic way to do this
        public ObservableCollection<Guild> Guilds
        {
            get
            {
                return new(_guilds);

            }
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
                    _channels = ViewModel.GetGuildChannels(SelectedGuild.Id);
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

        public ObservableCollection<Channel> SelectedChannels
        {
            get
            {
                return new(_channels);

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


        public void AddGuild(Guild guild)
        {
            //_client.Guilds.Add(guild);
            NotifyPropertyChanged(nameof(Guilds));
        }

        public void register(MainWindow mainWindow)
        {
            _view = mainWindow;
        }

        public void SendMessage(string content)
        {
            _client.SendMessage(content, _selectedChannel.Id);
        }

        public void CreateChannel(string name)
        {
            _selectedGuild.AddChannel(name);
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
