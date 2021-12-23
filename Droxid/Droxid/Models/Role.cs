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

        public Role(int id, string name) : base(id)
        {
            _name = name;
        }
        public Role(int id, string name, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt)
        {
            _name = name;
        }

        public Role(int id, string name, DateTime createdAt, DateTime updatedAt, bool deleted) : base(id, createdAt, updatedAt, deleted)
        {
            _name = name;
        }

        public string Name
        {
            get => _name;
        }
        public List<User> Users
        {
            get => throw new NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            bool result = base.Equals(obj);
            if (result && obj is Role other)
            {
                result = (_name == other._name);
            }
            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ _name.GetHashCode();
        }

    }
}
