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

        public void Copy(Channel channel)
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
