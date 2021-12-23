using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droxid.Models
{
    public abstract class Model
    {
        protected int _id;
        protected DateTime _createdAt;
        protected DateTime _updatedAt;
        protected bool _deleted;

        public Model(int id)
        {
            _id = id;
            _createdAt = DateTime.Now;
            _updatedAt = DateTime.Now;
            _deleted = false;
        }

        public Model(int id, DateTime createdAt, DateTime updatedAt)
        {
            _id = id;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
            _deleted = false;
        }

        public Model(int id, DateTime createdAt, DateTime updatedAt, bool deleted)
        {
            _id = id;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
            _deleted = deleted;
        }

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
