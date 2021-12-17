using Droxid.ViewModels;
using System;
using System.Collections.Generic;

namespace Droxid.Models
{
    public class User : Model
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

        public List<Guild> Guilds
        {
            get
            {
                List<Guild> guilds = UserViewModel.GetUserGuilds(_username) ?? new();
                //Compare cached with the new
                for(int i = 0; i < _guilds.Count; i++)
                {
                    if (guilds.Find(dbGuild => (dbGuild.GetHashCode() == _guilds[i].GetHashCode())) == null)
                    {
                        Guild? dbGuild = guilds.Find(guild => guild.Id == _guilds[i].Id);
                        if (dbGuild == null)
                        {
                            //Remove guild from cache if no reference is found in the database result
                            _guilds.Remove(_guilds[i]);
                        }
                        else
                        {
                            //Update Content
                            _guilds[i].copy(dbGuild);
                        }
                    }

                }
                //Add uncached to cache
                guilds.ForEach(guild =>
                {
                    if(_guilds.Find(cachedGuild => cachedGuild.Id == guild.Id) == null) _guilds.Add(guild);
                });
                return _guilds;
            }
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

        public override void Copy()
        {
            throw new NotImplementedException();
        }
    }
}
