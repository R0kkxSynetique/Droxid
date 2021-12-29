using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droxid.DataBase
{
    public static class DataBaseHelper
    {
        ///<summary>Returns a <c>DateTime</c> value as a string ready for database usage</summary>
        ///<param name="datetime">DateTime value to transform</param>
        ///<returns>timestamp in sql string format (yyyy-MM-dd HH:mm:ss.ffffff)</returns>
        public static string ToSqlString(this DateTime datetime)
        {
            return datetime.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        }
    }
}
