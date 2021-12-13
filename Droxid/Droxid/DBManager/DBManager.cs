using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Droxid.Models;
using Dapper;

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

        //public static MySqlDataReader Select(string query)
        //{
        //    OpenDBConnection();
        //    MySqlCommand command = new MySqlCommand(query, _connection);
        //    MySqlDataReader reader = command.ExecuteReader();
        //    return reader;
        //}

        public static dynamic Select(string query, string username)
        {
            return _connection.Query(query, new { username = username });
        }

        public static MySqlDataReader Select(string query, List<MySqlParameter> parameters)
        {
            OpenDBConnection();
            MySqlCommand command = new MySqlCommand(query, _connection);
            foreach (MySqlParameter param in parameters)
            {
                command.Parameters.Add(param);
            }
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }
}
