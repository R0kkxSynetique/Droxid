using System;
using System.Collections.Generic;

namespace Droxid
{
    public class User
    {
        private int _id;
        private string _username;
        private List<Guild> _guilds = new List<Guild>();

        public int Id
        {
            get => _id;
        }

        public string Username
        {
            get => _username;
        }

        public List<Guild> Guilds{
            get => _guilds;
        }

        public User(int id, string username, List<Guild> guilds = null){
            _id = id;
            _username = username;
            _guilds = guilds;
        }
    }
}
