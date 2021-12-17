using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Droxid.ViewModels;

namespace Droxid.Models
{
    public class Guild
    {
        private int _id;
        private string _name;
        private int _owner;

        private List<Channel> _channels = new List<Channel>();

        public int Id
        {
            get => _id;
        }

        public List<Role> Roles
        {
            get => UserViewModel.GetGuildRoles(_id);
        }
        public List<User> Users
        {
            get => UserViewModel.GetGuildUsers(_id);
        }
        public User Owner
        {
            get => UserViewModel.GetUserById(_owner);
        }
        public string Name
        {
            get => _name;
        }

        public List<Channel> Channels
        {
            get
            {
                List<Channel> dbChannels = UserViewModel.GetGuildChannels(_id);
                //Compare cache and DB
                for (int i = 0; i < _channels.Count; i++)
                {
                    if (dbChannels.Find(dbChannel => (dbChannel.GetHashCode() == _channels[i].GetHashCode())) == null)
                    {
                        Channel? dbChannel = dbChannels.Find(channel => channel.Id == _channels[i].Id);
                        if (dbChannel == null)
                        {
                            //Remove channel from cache if no reference is found in the database result
                            _channels.Remove(_channels[i]);
                        }
                        else
                        {
                            //Update Content
                            _channels[i].copy(dbChannel);
                        }
                    }

                }
                //Add uncached to cache
                dbChannels.ForEach(dbChannel =>
                {
                    if (_channels.Find(cachedChannel => cachedChannel.Id == dbChannel.Id) == null) _channels.Add(dbChannel);
                });

                return _channels;
            }
        }

        public Guild(int id, string name, int owner)
        {
            _id = id;
            _name = name;
            _owner = owner;
        }

        public void copy(Guild guild)
        {
            _name = guild._name;
            _owner = guild._owner;
        }
    }
}
