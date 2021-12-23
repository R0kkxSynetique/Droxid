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
            get => ViewModel.GetUserById(_sender);
        }
        public Channel Channel
        {
            get => throw new NotImplementedException();
        }

        public Message(int id, string content, int sender, int channel) : base(id)
        {
            _content = content;
            _sender = sender;
            _channel = channel;
        }

        public Message(int id, string content, int sender, int channel, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt)
        {
            _content = content;
            _sender = sender;
            _channel = channel;
        }

        public override bool Equals(object? obj)
        {
            bool result = base.Equals(obj);
            if (result && obj is Message other)
            {
                result = (_content == other._content) && (_sender == other._sender) && (_channel == other._channel);
            }
            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ _content.GetHashCode() ^ _sender ^ _channel; 
        }


    }
}
