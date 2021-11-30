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
    public abstract class DBManager
    {
        private SqlConnection _connection;

        public DBManager()
        {
            // check the config to change
            string ConnectionSting = @"Data Source=localhost;Initial Catalog=Droxid;User ID=root;Password=";
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

        // Only a reference to initialise a connection and execute a query with variables
        //
        //using (SqlConnection conn = new SqlConnection(ConnectionSting))
        //    {
        //        String query = "INSERT INTO droxid.users (username) VALUES ('@username')";

        //        using (SqlCommand command = new SqlCommand(query, conn))
        //        {
        //            command.Parameters.AddWithValue("@username", username);

        //            conn.Open();
        //            int result = command.ExecuteNonQuery();

        //            // Check Error
        //            if (result< 0)
        //                Console.WriteLine("Error inserting data into Database!");
        //        }
        //    }
    }
}
