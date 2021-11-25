using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Droxid.DataBase
{
    class Connector
    {
        SqlConnection connection;
        public Connector()
        {
            string connetionString;
            connetionString = @"Data Source=(local);Initial Catalog=Droxid;User ID=root;Password=";
            connection = new SqlConnection(connetionString);
            connection.Open();
        }

        public bool TestConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
