using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Droxid.ViewModels;

namespace Droxid.Models
{
    public class Permission : Model
    {
        private string _name;
        private string _description;

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
            get => throw new NotImplementedException();
        }

        public Permission(int id, string name, string description)
        {
            _name = name;
            _description = description;
        }

    }
}
