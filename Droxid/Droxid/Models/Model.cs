using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droxid.Models
{
    /// <summary>
    /// Abstract class representing any object from the database
    /// </summary>
    public abstract class Model
    {
        protected int _id;
        protected DateTime _createdAt;
        protected DateTime _updatedAt;
        protected bool _deleted;

        /// <summary>
        /// Creates a new model with a given id, defaults the createdAt and updatedAt to now and the deleted flag to false
        /// </summary>
        /// <param name="id">The id of the entry in the database</param>
        public Model(int id) : this(id, DateTime.Now, DateTime.Now, false) { }
        /// <summary>
        /// Creates a new model with a given id, createdAt datetime, updatedAt datetime and defaults the deleted flag to false
        /// </summary>
        /// <param name="id">The id of the entry in the database</param>
        /// <param name="createdAt">creation date of the entry</param>
        /// <param name="updatedAt">update date of the entry</param>
        public Model(int id, DateTime createdAt, DateTime updatedAt) : this(id, createdAt, updatedAt, false) { }
        /// <summary>
        /// Create a new model with a given id, createdAt datetime, updatedAt datetime and deleted flag
        /// </summary>
        /// <param name="id">The id of the entry in the database</param>
        /// <param name="createdAt">creation date of the entry</param>
        /// <param name="updatedAt">update date of the entry</param>
        /// <param name="deleted">whether the entry is considered as deleted in the database</param>
        public Model(int id, DateTime createdAt, DateTime updatedAt, bool deleted)
        {
            _id = id;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
            _deleted = deleted;
        }
        /// <summary>
        /// Object database id used for references
        /// </summary>
        /// <value>database id</value>
        public int Id
        {
            get => _id;
        }

        public DateTime CreatedAt
        {
            get => _createdAt;
        }

        public DateTime UpdatedAt
        {
            get => _updatedAt;
        }

        public bool IsDeleted
        {
            get => _deleted;
        }

        protected void Copy(Model model)
        {
            _id = model.Id;
            _createdAt = model.CreatedAt;
            _updatedAt = model.UpdatedAt;
        }

        public override bool Equals(Object? obj)
        {
            bool result = false;
            if (obj is Model other)
            {
                result = (_id == other._id) && (_updatedAt == other._updatedAt);
            }
            return result;
        }

        public override int GetHashCode()
        {
            return _id ^ _updatedAt.Second ^ GetType().GetHashCode();
        }
    }
}
