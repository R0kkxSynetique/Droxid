using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Droxid.ViewModels;

namespace Droxid.Models
{
    public class Message : Model
    {
        private string _content;
        private int _sender;
        private int _channel;

        public string Content
        {
            get => _content;
        }
        public User Sender
        {
            get => UserViewModel.GetUserById(_sender);
        }
        public Channel Channel
        {
            get => throw new NotImplementedException();
        }

        public Message(int id, string content, int sender, int channel)
        {
            _id = id;
            _content = content;
            _sender = sender;
            _channel = channel;
        }

    }
}
