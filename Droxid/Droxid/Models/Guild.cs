using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droxid.Models
{
    public class Guild
    {
        private string _name;
        private List<User> _users = new List<User>();
        private User _owner;
        private List<Role> _roles = new List<Role>();
        private List<Channel> _channels = new List<Channel>();

        public List<Role> Roles
        {
            get => _roles;
        }
        public List<User> Users
        {
            get => _users;
        }
        public User Owner
        {
            get => _owner;
        }
        public string Name
        {
            get => _name;
        }

        public List<Channel> Channels
        {
            get => _channels;
        }

        public Guild(string name, User owner, List<Role> roles, List<Channel> channels, List<User> users = null)
        {
            _name = name;
            _owner = owner;
            _roles = roles;
            _channels = channels;
            _users = users;
        }

        public int AddChannel(string name)
        {
            _channels.Add(new Channel(name, new List<Permission>(), new List<Message>(), this));
            return _channels.Count - 1;
        }
    }
}
