using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Droxid.ViewModels;

namespace Droxid.Models
{
    public class Guild : Model
    {
        private string _name;
        private int _owner;

        public Guild(int id, string name, int owner) : base(id)
        {
            _name = name;
            _owner = owner;
        }
        public Guild(int id, string name, int owner, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt)
        {
            _name = name;
            _owner = owner;
        }
        public Guild(int id, string name, int owner, DateTime createdAt, DateTime updatedAt, bool deleted) : base(id, createdAt, updatedAt, deleted)
        {
            _name = name;
            _owner = owner;
        }

        public List<Role> Roles
        {
            get => ViewModel.GetGuildRoles(_id);
        }
        public List<User> Users
        {
            get => ViewModel.GetGuildUsers(_id);
        }
        public User Owner
        {
            get => ViewModel.GetUserById(_owner);
        }
        public string Name
        {
            get => _name;
        }
        public List<Channel> Channels
        {
            get =>ViewModel.GetGuildChannels(_id);
        }

        public void Copy(Guild guild)
        {
            base.Copy(guild);
            _name = guild._name;
            _owner = guild._owner;
        }

        public override bool Equals(object? obj)
        {
            bool result = base.Equals(obj);
            if (result && obj is Guild other)
            {
                result = (_name == other._name) && (_owner == other._owner);
            }
            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ _name.GetHashCode() ^ _owner; 
        }


    }
}
