using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droxid.DataBase
{
    public abstract class Model
    {
        // check the config to change
        public string ConnectionSting = @"Data Source=localhost;Initial Catalog=Droxid;User ID=root;Password=";
    }
}
