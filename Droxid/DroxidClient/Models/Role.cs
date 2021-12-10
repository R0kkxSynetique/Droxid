using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droxid
{
    public class Role
    {
        private string _name;
        private List<User> _users;

        public string Name
        {
            get => _name;
        }

        public List<User> Users
        {
            get => _users;
        }

        public Role(string name, List<User> users)
        {
            _name = name;
            _users = users;
        }
    }
}
