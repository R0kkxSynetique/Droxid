using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Droxid.DataBase
{
    // This class will only open connection to DB
    public class DBManager
    {
        private MySqlConnection _connection;

        public DBManager()
        {
            // check the config to change
            string ConnectionSting = "Database=droxid;Server=localhost;user=Droxid;password=Droxid";
            _connection = new MySqlConnection(ConnectionSting);
        }

        public void OpenDBConnection()
        {
            _connection.Open();
        }
        public void CloseDBConnection()
        {
            _connection.Close();
        }

        public MySqlDataReader Select(string query)
        {
            OpenDBConnection();
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            CloseDBConnection();
            return reader;
        }

        public MySqlDataReader Select(string query, List<string> parameters)
        {
            OpenDBConnection();
            MySqlCommand command = new MySqlCommand(query, _connection);
            foreach (string param in parameters)
            {
                command.Parameters.AddWithValue("@" + param, param);
            }
            MySqlDataReader reader = command.ExecuteReader();
            CloseDBConnection();
            return reader;
        }
    }
}
