﻿using System;
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

        private List<Channel> _channels = new List<Channel>();

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
            get
            {
                return ViewModel.GetGuildChannels(_id);
            }
        }

        public Guild(int id, string name, int owner)
        {
            _id = id;
            _name = name;
            _owner = owner;
        }

        public void Copy(Guild guild)
        {
            _name = guild._name;
            _owner = guild._owner;
        }

        public void CreateGuild()
        {
            ViewModel.InsertGuild(_name,_owner);
        }

        public void AddRoleToGuild(string name)
        {
            ViewModel.InsertRole(name, _id);
        }

        public void AddRolesToGuild(List<string> roles)
        {
            foreach (string role in roles)
            {
                AddRoleToGuild(role);
            }
        }

        public void AddChannel(string name)
        {
            ViewModel.InsertChannel(name, _id);
        }

    }
}
