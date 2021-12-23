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
            //Guilds update
            List<Guild> dbGuilds = ViewModel.GetUserGuilds(_client.Id, _guilds.OrderBy(guild => guild.UpdatedAt).DefaultIfEmpty(null).First()?.UpdatedAt ?? new DateTime(0)) ?? new();
            //update content
            foreach (Guild dbGuild in dbGuilds)
            {
                Guild? cachedGuild = _guilds.Find(guild => guild.Id == dbGuild.Id);
                if (cachedGuild != null)
                {
                    cachedGuild.Copy(dbGuild);
                    //TODO remove guild if removed flag is true
                }
                else
                {
                    _guilds.Add(dbGuild);
                }
            }

            //Channels update
            if (SelectedGuild != null)
            {
                List<Channel> dbChannels = ViewModel.GetGuildChannels(SelectedGuild.Id, _channels.OrderBy(channel => channel.UpdatedAt).DefaultIfEmpty(null).First()?.UpdatedAt ?? new DateTime(0)) ?? new();
                //update content
                foreach (Channel dbChannel in dbChannels)
                {
                    Channel? cachedGuild = _channels.Find(channel => channel.Id == dbChannel.Id);
                    if (cachedGuild != null)
                    {
                        cachedGuild.Copy(dbChannel);
                        //TODO remove channel if removed flag is true
                    }
                    else
                    {
                        _channels.Add(dbChannel);
                    }
                }

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
