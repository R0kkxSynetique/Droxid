using Droxid.ViewModels;
using System;
using System.Collections.Generic;

namespace Droxid.Models
{
    public class User : Model
    {
        private string _username;

        private List<Guild> _guilds = new List<Guild>();

        public string Username
        {
            get => _username;
        }

        public List<Guild> Guilds
        {
            get
            {
                return ViewModel.GetUserGuilds(_username) ?? new();
            }
        }

        public User(int id, string username)
        {
            _id = id;
            _username = username;
        }

        public void SendMessage(string content, int channel)
        {
            ViewModel.InsertMessage(content, _id, channel);
        }

    }
}
