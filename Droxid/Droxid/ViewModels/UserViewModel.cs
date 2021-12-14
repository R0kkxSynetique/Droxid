using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Droxid.DataBase;
using Droxid.Models;
using MySql.Data.MySqlClient;
using Dapper;
using System.Collections;

namespace Droxid.ViewModels
{
    // send query(data comes from each model) to dbmanager
    public class UserViewModel
    {

        private static List<MySqlParameter> _parameters = new();

        public static User GetUserByUsername(string username)
        {
            string query = $"SELECT * FROM users WHERE username = \"{username}\"";

            User user = DBManager.SelectUser(query);

            return user;
        }

        public static User GetUserById(string id)
        {
            string query = $"SELECT * FROM users WHERE id = \"{id}\"";

            User user = DBManager.SelectUser(query);

            return user;
        }
    }
}