using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droxid.Models
{
    public abstract class Model
    {
        public int Id;
        public abstract void Copy();        
    }
}
