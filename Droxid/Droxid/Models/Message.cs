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
        /// <summary>
        /// Creates a new message
        /// </summary>
        /// <param name="id">Message id</param>
        /// <param name="content">Message content</param>
        /// <param name="sender">Message sender id</param>
        /// <param name="channel">Message channel id</param>
        public Message(int id, string content, int sender, int channel) : this(id, content, sender, channel, DateTime.Now, DateTime.Now, false) { }
        /// <summary>
        /// Creates a new message
        /// </summary>
        /// <param name="id">Message id</param>
        /// <param name="content">Message content</param>
        /// <param name="sender">Message sender id</param>
        /// <param name="channel">Message channel id</param>
        /// <param name="createdAt">Creation datetime</param>
        /// <param name="updatedAt">Last update</param>
        public Message(int id, string content, int sender, int channel, DateTime createdAt, DateTime updatedAt) : this(id, content, sender, channel, createdAt, updatedAt, false) { }
        /// <summary>
        /// Creates a new message
        /// </summary>
        /// <param name="id">Message id</param>
        /// <param name="content">Message content</param>
        /// <param name="sender">Message sender id</param>
        /// <param name="channel">Message channel id</param>
        /// <param name="createdAt">Creation datetime</param>
        /// <param name="updatedAt">Last update</param>
        /// <param name="deleted">Deleted flag</param>
        public Message(int id, string content, int sender, int channel, DateTime createdAt, DateTime updatedAt, bool deleted) : base(id, createdAt, updatedAt, deleted)
        {
            _content = content;
            _sender = sender;
            _channel = channel;
        }
        /// <summary>
        /// Message content
        /// </summary>
        public string Content
        {
            get => _content;
        }
        /// <summary>
        /// Message sender
        /// </summary>
        public User Sender
        {
            get => ViewModel.GetUserById(_sender);
        }
        /// <summary>
        /// Channel
        /// </summary>
        public Channel Channel
        {
            get => throw new NotImplementedException();
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
