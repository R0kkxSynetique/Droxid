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
using Droxid.DataBase;
using Droxid.Views;

namespace Droxid.ViewModels
{
    public class MainWindowViewModel : VM
    {

        private User _client;
        private Guild? _selectedGuild;
        private Channel? _selectedChannel;
        private DispatcherTimer _timer;

        //Caching
        private List<Guild> _guilds = new List<Guild>();
        private List<Channel> _channels = new List<Channel>();
        private List<Message> _messages = new List<Message>();
        private List<User> _members = new List<User>();


        public MainWindowViewModel(string username)
        {
            _client = ViewModel.GetUserByUsername(username);
            NotifyPropertyChanged(nameof(Guilds));
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(0.5);
            _timer.Tick += updateTimerEventHandler;
            _timer.IsEnabled = true;
        }
        /// <summary>
        /// Listen's for timer events and calls the update method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateTimerEventHandler(Object? sender, EventArgs e)
        {
            Update();
        }
        /// <summary>
        /// Updates cached data
        /// </summary>
        /// <remarks>
        /// Uses the updatedAt property for a minimal performance impact
        /// </remarks>
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
                    if (dbGuild.IsDeleted)
                    {
                        _guilds.Remove(cachedGuild);
                    }
                    else
                    {
                        cachedGuild.Copy(dbGuild);
                    }
                }
                else if (!dbGuild.IsDeleted)
                {
                    _guilds.Add(dbGuild);
                }
            }

            if (SelectedGuild != null)
            {
                //Guild members update
                List<User> dbUsers = ViewModel.GetGuildUsers(SelectedGuild.Id, _members.OrderBy(user => user.UpdatedAt).DefaultIfEmpty(null).First()?.UpdatedAt ?? new DateTime(0)) ?? new();
                //update content
                foreach (User dbUser in dbUsers)
                {
                    User? cachedUser = _members.Find(user => user.Id == dbUser.Id);
                    if (cachedUser != null)
                    {
                        if (dbUser.IsDeleted)
                        {
                            _members.Remove(cachedUser);
                        }
                        else
                        {
                            cachedUser.Copy(dbUser);
                        }
                    }
                    else if (!dbUser.IsDeleted)
                    {
                        _members.Add(dbUser);
                    }
                }

                //Channels update
                List<Channel> dbChannels = ViewModel.GetGuildChannels(SelectedGuild.Id, _client.Id, _channels.OrderBy(channel => channel.UpdatedAt).DefaultIfEmpty(null).First()?.UpdatedAt ?? new DateTime(0)) ?? new();
                //update content
                foreach (Channel dbChannel in dbChannels)
                {
                    Channel? cachedChannel = _channels.Find(channel => channel.Id == dbChannel.Id);
                    if (cachedChannel != null)
                    {
                        if (dbChannel.IsDeleted)
                        {
                            _channels.Remove(cachedChannel);
                        }
                        else
                        {
                            cachedChannel.Copy(dbChannel);
                        }
                    }
                    else if (!dbChannel.IsDeleted)
                    {
                        _channels.Add(dbChannel);
                    }
                }

            }
            else
            {
                _members.Clear();
                _channels.Clear();
            }

            //Messages update
            if (SelectedChannel != null)
            {
                List<Message> dbMessages = ViewModel.GetChannelMessages(SelectedChannel.Id, _messages.OrderBy(message => message.UpdatedAt).DefaultIfEmpty(null).First()?.UpdatedAt ?? new DateTime(0)) ?? new();
                //Update content
                foreach (Message dbMessage in dbMessages)
                {
                    Message? cachedMessage = _messages.Find(message => message.Id == dbMessage.Id);
                    if (cachedMessage != null)
                    {
                        if (dbMessage.IsDeleted)
                        {
                            _messages.Remove(cachedMessage);
                        }
                        else
                        {
                            cachedMessage.Copy(dbMessage);
                        }
                    }
                    else if (!dbMessage.IsDeleted)
                    {
                        _messages.Add(dbMessage);
                    }
                }
            }
            else
            {
                _messages.Clear();
            }



            NotifyPropertyChanged(nameof(_client));
        }

        /// <summary>
        /// List of Guilds to render
        /// </summary>
        public ObservableCollection<Guild> Guilds
        {
            get => new(_guilds);
        }
        /// <summary>
        /// List of channels available
        /// </summary>
        public List<Channel> Channels
        {
            get
            {
                List<Channel> channels = new List<Channel>();
                foreach (Guild guild in Guilds) channels.AddRange(guild.Channels);
                return channels;
            }
        }
        /// <summary>
        /// Selected guild to render channels from
        /// </summary>
        public Guild? SelectedGuild
        {
            get => _selectedGuild;
            set
            {
                if (_selectedGuild != value)
                {
                    _selectedGuild = value;
                    _channels = ViewModel.GetGuildChannels(SelectedGuild.Id, _client.Id);
                    _members = ViewModel.GetGuildUsers(SelectedGuild.Id);
                    NotifyPropertyChanged(nameof(SelectedGuild));
                }
            }
        }
        /// <summary>
        /// List of channels to render
        /// </summary>
        public ObservableCollection<Channel> SelectedChannels
        {
            get
            {
                return new(_channels);

            }
        }
        /// <summary>
        /// Selected channel to render messages from
        /// </summary>
        public Channel? SelectedChannel
        {
            get => _selectedChannel;
            set
            {
                _selectedChannel = value;
                if (_selectedChannel != null)
                {
                    _messages = ViewModel.GetChannelMessages(_selectedChannel.Id);
                }
                NotifyPropertyChanged(nameof(SelectedChannel));
            }
        }
        /// <summary>
        /// List of messages to render
        /// </summary>
        public List<Message> Messages
        {
            get => SelectedChannel?.Messages ?? new List<Message>();
        }

        public List<User> SelectedGuildMembers
        {
            get => _members;
        }

        public bool IsCurrentGuildOwner
        {
            get => _selectedGuild != null && _selectedGuild.Owner.Equals(_client);
        }

        /// <summary>
        /// Sends a new message in the selected channel
        /// </summary>
        /// <param name="content">Message content</param>
        public void SendMessage(string content)
        {
            _client.SendMessage(content, _selectedChannel.Id);
        }

        public void CreateGuild()
        {
            NewGuild dialog = new NewGuild(_client);
            dialog.ShowDialog();
        }

        public void CreateChannel()
        {
            NewChannel dialog = new NewChannel(_selectedGuild);
            dialog.ShowDialog();
        }

        public void EditChannel(Channel channel)
        {
            EditChannel dialog = new EditChannel(channel);
            dialog.ShowDialog();
        }

        public bool canWriteInThisChannel()
        {
            if (_selectedChannel != null && _client != null && _selectedGuild != null)
            {
                return ViewModel.CanUserWriteInChannel(_selectedChannel.Id, _client.Id, _selectedGuild.Id);
            }
            else
            {
                return false;
            }
        }

        public bool CanEditGuild()
        {
            if (_client != null && _selectedGuild != null)
            {
                return ViewModel.CanUserEditGuild(_client.Id, _selectedGuild.Id);
            }
            else
            {
                return false;
            }
        }

        public bool CanEditChannel()
        {
            if (CanEditGuild())
            {
                return true;
            }
            if (_client != null && _selectedChannel != null)
            {
                return ViewModel.CanUserEditChannel(_client.Id, _selectedChannel.Id, _selectedGuild.Id);
            }

            return false;
        }

        //Property changed dependencies
        public void InviteMember()
        {
            if (SelectedGuild != null && IsCurrentGuildOwner)
            {
                InviteMember dialog = new InviteMember(_selectedGuild);
                dialog.ShowDialog();
                _members = SelectedGuild.Users;
                NotifyPropertyChanged(nameof(SelectedGuildMembers));
            }
        }

        public void KickMember(User member)
        {
            //TODO: Permissions
            if(member.Id == SelectedGuild.Owner.Id) throw new GuildOwnerCannotBeKickedException();
            ViewModel.RemoveUserFromGuild(member.Id,SelectedGuild.Id);
            _members = SelectedGuild.Users;
            NotifyPropertyChanged(nameof(SelectedGuildMembers));
        }

        //Property changed dependencies
        protected override void NotifyPropertyChanged(string propName)
        {
            base.NotifyPropertyChanged(propName);
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
                    NotifyPropertyChanged(nameof(SelectedGuildMembers));
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

    public class MainWindowViewModelException : Exception { }
    public class GuildOwnerCannotBeKickedException : MainWindowViewModelException { }

}
