using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droxid.Models
{
    public class Permission
    {
        private string _name;
        private string _description;
        private List<Role> _roles;

        public string Name
        {
            get => _name;
        }
        public string Description
        {
            get => _description;
        }
        public List<Role> Roles
        {
            get => _roles;
        }

        public Permission(string name, string description, List<Role> roles = null)
        {
            _name = name;
            _description = description;
            _roles = roles;
        }
    }
}
