using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droxid.DataBase
{
    // This class will only open connection to DB
    public class DBManager
    {
        private SqlConnection _connection;

        public DBManager()
        {
            // check the config to change
            string ConnectionSting = "Database=Droxid;Server=localhost;user=Droxid;password=Droxid";
            _connection = new SqlConnection(ConnectionSting);
        }

        public void OpenDBConnection()
        {
            _connection.Open();
        }
        public void CloseDBConnection()
        {
            _connection.Close();
        }

        public SqlDataReader Select(string query)
        {
            OpenDBConnection();
            SqlCommand command = new SqlCommand(query, _connection);
            SqlDataReader reader = command.ExecuteReader();
            CloseDBConnection();
            return reader;
        }

        public SqlDataReader Select(string query, List<string> parameters)
        {
            OpenDBConnection();
            SqlCommand command = new SqlCommand(query, _connection);
            foreach (string param in parameters)
            {
                command.Parameters.AddWithValue("@" + param, param);
            }
            SqlDataReader reader = command.ExecuteReader();
            CloseDBConnection();
            return reader;
        }
}
