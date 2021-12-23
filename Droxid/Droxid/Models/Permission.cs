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

        public Permission(int id, string name, string description) : base(id)
        {
            _name = name;
            _description = description;
        }
        public Permission(int id, string name, string description, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt)
        {
            _name = name;
            _description = description;
        }
        public Permission(int id, string name, string description, DateTime createdAt, DateTime updatedAt, bool deleted) : base(id, createdAt, updatedAt, deleted)
        {
            _name = name;
            _description = description;
        }

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

        public override bool Equals(object? obj)
        {
            bool result = base.Equals(obj);
            if (result && obj is Permission other)
            {
                result = (_name == other._name) && (_description == other._description);
            }
            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ _name.GetHashCode() ^ _description.GetHashCode();
        }


    }
}
