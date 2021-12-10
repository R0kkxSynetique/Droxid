using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Droxid.DataBase;
using MySql.Data.MySqlClient;

namespace Droxid.ViewModel
{
    // send query(data comes from each model) to dbmanager
    public class UserViewModel
    {
        private DBManager _dBManager = new();
        private List<MySqlParameter> _parameters = new();

        public User GetUserByUsername(string username)
        {
            string query = "SELECT * FROM users WHERE username = @username";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@username", username));

            MySqlDataReader reader = _dBManager.Select(query, _parameters);

            User user;


            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }


            List<Guild> guilds = new();

            user = new User(reader[0].ToString(), guilds);

            reader.Close();

            return user;
        }

        private static void ReadSingleRow(IDataRecord dataRecord)
        {
            Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
        }
    }
}