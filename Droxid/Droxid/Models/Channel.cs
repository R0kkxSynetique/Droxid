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

        public Channel(int id, string name) : base(id)
        {
            _name = name;
        }

        public Channel(int id, string name, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt)
        {
            _name = name;
        }

        public string Name
        {
            get => _name;
        }
        public List<Permission> Permissions
        {
            get => ViewModel.GetChannelPermissions(_id);
        }
        public List<Message> Messages
        {
            get => ViewModel.GetChannelMessages(_id);
        }
        public Guild Guild
        {
            get => ViewModel.GetGuildByChannelId(_id);
        }

        public void Copy(Channel channel)
        {
            base.Copy(channel);
            _name = channel.Name;
        }

        public override bool Equals(object? obj)
        {
            bool result = base.Equals(obj);
            if (result && obj is Channel other)
            {
                result = (other._name == _name);
            }
            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ _name.GetHashCode();
        }


        //public int AddMessage(string content, User sender)
        //{
        //    _messages.Add(new Message(content, sender, this));
        //    return _messages.Count - 1;
        //}

    }
}
