using Droxid.ViewModels;
using System;
using System.Collections.Generic;

namespace Droxid.Models
{
    public class User
    {
        private int _id;
        private string _username;
        private List<Guild> _guilds = new List<Guild>();


        public string Username
        {
            get => _username;
        }

        public List<Guild> Guilds{
            get => _guilds;
        }

        public User(string username, List<Guild> guilds = null){
            _username = username;
            _guilds = guilds;
        }

        public User(string username, int id)
        {
            _id = id;
            _username = username;
        }

        public User GetUserByUsername()
        {
            return UserViewModel.GetUserByUsername(_username);
        }
    }
}
