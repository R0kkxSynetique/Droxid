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
        /// <summary>
        /// Creates a new permission
        /// </summary>
        /// <param name="id">Permission id</param>
        /// <param name="name">Permission name</param>
        /// <param name="description">Permission description</param>
        public Permission(int id, string name, string description) : this(id, name, description, DateTime.Now, DateTime.Now, false) { }
        /// <summary>
        /// Creates a new permission
        /// </summary>
        /// <param name="id">Permission id</param>
        /// <param name="name">Permission name</param>
        /// <param name="description">Permission description</param>
        /// <param name="createdAt">Creation datetime</param>
        /// <param name="updatedAt">Last update</param>
        public Permission(int id, string name, string description, DateTime createdAt, DateTime updatedAt) : this(id, name, description, createdAt, updatedAt, false) { }
        /// <summary>
        /// Creates a new permission
        /// </summary>
        /// <param name="id">Permission id</param>
        /// <param name="name">Permission name</param>
        /// <param name="description">Permission description</param>
        /// <param name="createdAt">Creation datetime</param>
        /// <param name="updatedAt">Last update</param>
        /// <param name="deleted">Deleted flag</param>
        public Permission(int id, string name, string description, DateTime createdAt, DateTime updatedAt, bool deleted) : base(id, createdAt, updatedAt, deleted)
        {
            _name = name;
            _description = description;
        }
        /// <summary>
        /// Permission name
        /// </summary>
        public string Name
        {
            get => _name;
        }
        /// <summary>
        /// Permission description
        /// </summary>
        public string Description
        {
            get => _description;
        }
        /// <summary>
        /// List of roles with this permission
        /// </summary>
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
