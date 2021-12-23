using Droxid.ViewModels;
using System;
using System.Collections.Generic;

namespace Droxid.Models
{
    public class User : Model
    {
        private string _username;

        public User(int id, string username) : base(id)
        {
            _username = username;
        }
        public User(int id, string username, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt)
        {
            _username = username;
        }

        public string Username
        {
            get => _username;
        }
        public List<Guild> Guilds
        {
            get => ViewModel.GetUserGuilds(_id) ?? new();
    
        }

        public void Copy(User user)
        {
            base.Copy(user);
            _username = user.Username;
        }

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
