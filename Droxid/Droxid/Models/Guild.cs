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
        private bool _isPrivate;
        /// <summary>
        /// Creates a new guild
        /// </summary>
        /// <param name="id">Guild id</param>
        /// <param name="name">Guild name</param>
        /// <param name="owner">Owner id</param>
        public Guild(int id, string name, int owner) : this(id, name, owner, DateTime.Now, DateTime.Now, false, true) { }
        /// <summary>
        /// Creates a new guild
        /// </summary>
        /// <param name="id">Guild id</param>
        /// <param name="name">Guild name</param>
        /// <param name="owner">Owner id</param>
        /// <param name="createdAt">Creation datetime</param>
        /// <param name="updatedAt">Last update</param>
        public Guild(int id, string name, int owner, DateTime createdAt, DateTime updatedAt) : this(id, name, owner, createdAt, updatedAt, false, true) { }
        /// <summary>
        /// Creates a new guild
        /// </summary>
        /// <param name="id">Guild id</param>
        /// <param name="name">Guild name</param>
        /// <param name="owner">Owner id</param>
        /// <param name="createdAt">Creation datetime</param>
        /// <param name="updatedAt">Last update</param>
        /// <param name="deleted">Deleted flag</param>
        /// <param name="isPrivate">Private flag</param>
        public Guild(int id, string name, int owner, DateTime createdAt, DateTime updatedAt, bool deleted, bool isPrivate) : base(id, createdAt, updatedAt, deleted)
        {
            _name = name;
            _owner = owner;
            _isPrivate = isPrivate;
        }
        /// <summary>
        /// List of roles in this guild
        /// </summary>
        public List<Role> Roles
        {
            get => ViewModel.GetGuildRoles(_id);
        }
        /// <summary>
        /// List of users in this guild
        /// </summary>
        public List<User> Users
        {
            get => ViewModel.GetGuildUsers(_id);
        }
        /// <summary>
        /// Guild owner
        /// </summary>
        public User Owner
        {
            get => ViewModel.GetUserById(_owner);
        }
        /// <summary>
        /// Guild name
        /// </summary>
        public string Name
        {
            get => _name;
        }
        /// <summary>
        /// List of channels in this guild
        /// </summary>
        public List<Channel> Channels
        {
            get => ViewModel.GetGuildChannels(_id);
        }
        /// <summary>
        /// Updates the instance's values with a given model. used in order to keep the reference in memory of the current instance
        /// </summary>
        /// <param name="guild">Guild to copy</param>
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
