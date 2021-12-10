using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Droxid.DataBase;
using Droxid.Models;
using MySql.Data.MySqlClient;

namespace Droxid.ViewModels
{
    // send query(data comes from each model) to dbmanager
    public class UserViewModel
    {

        private static List<MySqlParameter> _parameters = new();

        private static void ReadSingleRow(IDataRecord dataRecord)
        {
            Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
        }

        private static void EndConnection(MySqlDataReader reader)
        {
            reader.Close();

            reader.Dispose();

            DBManager.CloseDBConnection();
        }

        public static User GetUserByUsername(string username)
        {
            string query = "SELECT * FROM users WHERE username = @username";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@param", username));

            MySqlDataReader reader = DBManager.Select(query, _parameters);

            User user;

            user = new User(reader.GetString(1));

            EndConnection(reader);

            return user;
        }
    }
}