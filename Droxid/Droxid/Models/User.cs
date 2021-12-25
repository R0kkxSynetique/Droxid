using Droxid.ViewModels;
using System;
using System.Collections.Generic;

namespace Droxid.Models
{
    public class User : Model
    {
        private string _username;

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="username">User's name</param>
        public User(int id, string username) : this(id, username, DateTime.Now, DateTime.Now, false) { }
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="username">User's name</param>
        /// <param name="createdAt">Creation datetime</param>
        /// <param name="updatedAt">Last update</param>
        public User(int id, string username, DateTime createdAt, DateTime updatedAt) : this(id, username, createdAt, updatedAt, false) { }
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="username">User's name</param>
        /// <param name="createdAt">Creation datetime</param>
        /// <param name="updatedAt">Last update</param>
        /// <param name="deleted">Deleted flag</param>
        public User(int id, string username, DateTime createdAt, DateTime updatedAt, bool deleted) : base(id, createdAt, updatedAt, deleted)
        {
            _username = username;
        }
        /// <summary>
        /// User's name
        /// </summary>
        public string Username
        {
            get => _username;
        }
        /// <summary>
        /// List of guild of this user
        /// </summary>
        public List<Guild> Guilds
        {
            get => ViewModel.GetUserGuilds(_id) ?? new();
        }
        /// <summary>
        /// Updates the instance's values with a given model. used in order to keep the reference in memory of the current instance
        /// </summary>
        /// <param name="user">User to copy</param>
        public void Copy(User user)
        {
            base.Copy(user);
            _username = user.Username;
        }
        /// <summary>
        /// Send message as this user
        /// </summary>
        /// <remarks>
        /// This method should be moved to the viewmodel
        /// </remarks>
        /// <param name="content">Message content</param>
        /// <param name="channel">Channel id</param>
        public void SendMessage(string content, int channel)
        {
            ViewModel.InsertMessage(content, _id, channel);
        }

        public override bool Equals(object? obj)
        {
            bool result = base.Equals(obj);
            if (result && obj is User other)
            {
                result = (_username == other._username);
            }
            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ _username.GetHashCode();
        }


    }
}
