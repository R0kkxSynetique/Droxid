using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Droxid.ViewModels;

namespace Droxid.Models
{
    public class Channel : Model
    {
        private string _name;
        /// <summary>
        /// Creates a new channel
        /// </summary>
        /// <param name="id">Channel id</param>
        /// <param name="name">Channel name</param>
        public Channel(int id, string name) : this(id, name, DateTime.Now, DateTime.Now, false) { }
        /// <summary>
        /// Create a new channel
        /// </summary>
        /// <param name="id">Channel id</param>
        /// <param name="name">Channel name</param>
        /// <param name="createdAt">Channel creation datetime</param>
        /// <param name="updatedAt">Channel last update datetime</param>
        public Channel(int id, string name, DateTime createdAt, DateTime updatedAt) : this(id, name, createdAt, updatedAt, false) { }
        /// <summary>
        /// Create a new channel
        /// </summary>
        /// <param name="id">Channel id</param>
        /// <param name="name">Channel name</param>
        /// <param name="createdAt">Creation datetime</param>
        /// <param name="updatedAt">Last update</param>
        /// <param name="deleted">Deleted flag</param>
        public Channel(int id, string name, DateTime createdAt, DateTime updatedAt, bool deleted) : base(id, createdAt, updatedAt, deleted)
        {
            _name = name;
        }
        /// <summary>
        /// The channel name
        /// </summary>
        public string Name
        {
            get => _name;
        }
        /// <summary>
        /// List of permissions applied to this channel
        /// </summary>
        public List<Permission> Permissions
        {
            get => ViewModel.GetChannelPermissions(_id);
        }
        /// <summary>
        /// List of messages contained in this channel
        /// </summary>
        public List<Message> Messages
        {
            get => ViewModel.GetChannelMessages(_id);
        }
        /// <summary>
        /// The channel's guild
        /// </summary>
        public Guild Guild
        {
            get => ViewModel.GetGuildByChannelId(_id);
        }
        /// <summary>
        /// Updates the instance's values with a given model. used in order to keep the reference in memory of the current instance
        /// </summary>
        /// <param name="channel">Channel to copy</param>
        public void Copy(Channel channel)
        {
            base.Copy(channel);
            _name = channel.Name;
        }

        public override bool Equals(object? obj)
        {
            bool result = base.Equals(obj);
            if (result && obj is Channel other)
            {
                result = (other._name == _name);
            }
            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ _name.GetHashCode();
        }

    }
}
