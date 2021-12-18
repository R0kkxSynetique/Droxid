using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Droxid.ViewModels;

namespace Droxid.Models
{
    public class Role : Model
    {
        private string _name;

        public string Name
        {
            get => _name;
        }

        public List<User> Users
        {
            get => throw new NotImplementedException();
        }

        public Role(int id, string name)
        {
            _id = id;
            _name = name;
        }

    }
}
