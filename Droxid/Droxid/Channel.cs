using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droxid
{
    public class Channel
    {
        private int _id;
        private string _name;
        private List<Permission> _permissions = new List<Permission>();
        private List<Message> _messages = new List<Message>();
        private Guild _guild;

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
            get => _permissions;
        }
        public List<Message> Messages
        {
            get => _messages;
        }
        public Guild Guild
        {
            get => _guild;
        }

        public Channel(int id, string name, List<Permission> permissions, List<Message> messages, Guild guild)
        {
            _id = id;
            _name = name;
            _permissions = permissions;
            _messages = messages;
            _guild = guild;
        }
    }
}
