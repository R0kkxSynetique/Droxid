using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droxid.DataBase
{
    public static class DataBaseHelper
    {
        public static string ToSqlString(this DateTime datetime)
        {
            return datetime.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        }

        //potentially broken
        public static long ToTimestamp(this DateTime value)
        {
            long epoch = (value.Ticks - 621355968000000000) / 10000000;
            return epoch;
        }
    }
}
