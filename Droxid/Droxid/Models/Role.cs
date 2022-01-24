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
        /// <summary>
        /// Creates a new role
        /// </summary>
        /// <param name="id">Role id</param>
        /// <param name="name">Role name</param>
        public Role(int id, string name) : this(id, name, DateTime.Now, DateTime.Now, false) { }
        /// <summary>
        /// Creates a new role
        /// </summary>
        /// <param name="id">Role id</param>
        /// <param name="name">Role name</param>
        /// <param name="createdAt">Creation datetime</param>
        /// <param name="updatedAt">Last update</param>
        public Role(int id, string name, DateTime createdAt, DateTime updatedAt) : this(id, name, createdAt, updatedAt, false) { }
        /// <summary>
        /// Creates a new role
        /// </summary>
        /// <param name="id">Role id</param>
        /// <param name="name">Role name</param>
        /// <param name="createdAt">Creation datetime</param>
        /// <param name="updatedAt">Last update</param>
        /// <param name="deleted">Deleted flag</param>
        public Role(int id, string name, DateTime createdAt, DateTime updatedAt, bool deleted) : base(id, createdAt, updatedAt, deleted)
        {
            _name = name;
        }
        /// <summary>
        /// Role name
        /// </summary>
        public string Name
        {
            get => _name;
        }
        /// <summary>
        /// List of users with this role
        /// </summary>
        public List<User> Users
        {
            get => ViewModel.GetRoleUsers(_id);
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
