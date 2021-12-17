using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Droxid.ViewModels;

namespace Droxid.Models
{
    public class Channel
    {
        private int _id;
        private string _name;

        public int Id
        {
            get => _id;
        }
        public string Name
        {
            get => _name;
        }
        public List<Permission> Permissions
        {
            get => UserViewModel.GetChannelPermissions(_id);
        }
        public List<Message> Messages
        {
            get => UserViewModel.GetChannelMessages(_id);
        }
        public Guild Guild
        {
            get => UserViewModel.GetGuildByChannelId(_id);
        }

        public Channel(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public void copy(Channel channel)
        {
            _name = channel.Name;
        }

        //public int AddMessage(string content, User sender)
        //{
        //    _messages.Add(new Message(content, sender, this));
        //    return _messages.Count - 1;
        //}
        
    }
}
