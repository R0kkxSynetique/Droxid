using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Droxid.Models;
using Dapper;
using System.Collections;

namespace Droxid.DataBase
{
    // This class will only open connection to DB
    public class DBManager
    {
        // TODO Need to be in a config file NOT SECURED
        //This may not work beacause of the static methods(May need an object to end a connection)
        private static MySqlConnection _connection = new("Database=droxid;Server=localhost;user=Droxid;password=Droxid;");

        public static void OpenDBConnection()
        {
            _connection.Open();
        }
        public static void CloseDBConnection()
        {
            _connection.Close();
        }

        public static User SelectUser(string query)
        {
            IDictionary<string,string> result = new Dictionary<string,string>();

            User user = null;

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic sigleResult in queryResult)
            {
                result.Add("id",sigleResult.id.ToString());
                result.Add("username", sigleResult.username);

                user = new(sigleResult.username, sigleResult.id);
            }

            return user;
        }
    }
}
