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
        public int Id
        {
            get => _id;
        }
    }
}
