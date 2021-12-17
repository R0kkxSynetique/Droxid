using Droxid.ViewModels;
using System;
using System.Collections.Generic;

namespace Droxid.Models
{
    public class User
    {
        private int _id;
        private string _username;
        private List<int> _guilds = new List<int>();

        public int Id
        {
            get => _id;
        }

        public string Username
        {
            get => _username;
        }

        public List<Guild> Guilds{
            get => UserViewModel.GetUserGuilds(_username);
        }

        public User(int id, string username)
        {
            _id = id;
            _username = username;
        }

        public void SendMessage(string content, int channel)
        {
            UserViewModel.InsertMessage(content, _id, channel);
        }
    }
}
