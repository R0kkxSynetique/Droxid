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
            get => UserViewModel.GetGuildChannels(_id);
        }

        public Guild(int id, string name, int owner)
        {
            _id = id;
            _name = name;
            _owner = owner;
        }
    }
}
