using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droxid
{
    public class Message
    {
        private string _content;
        private User _sender;
        private Channel _channel;

        public string Content
        {
            get => _content;
        }
        public User Sender
        {
            get => _sender;
        }
        public Channel Channel
        {
            get => _channel;
        }

        public Message(string content, User sender, Channel channel)
        {
            _content = content;
            _sender = sender;
            _channel = channel;
        }

    }
}
