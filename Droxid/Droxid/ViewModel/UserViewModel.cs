﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Droxid.DataBase;
using MySql.Data.MySqlClient;

namespace Droxid.ViewModel
{
    public class UserViewModel
    {
        private DBManager _dBManager = new DBManager();
        private List<MySqlParameter> _parameters = new List<MySqlParameter>();

        public User GetUserByUsername(string username)
        {
            string query = "SELECT * FROM users WHERE username = @username";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@username", username));

            MySqlDataReader reader = _dBManager.Select(query, _parameters);

            User user;


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ReadSingleRow((IDataRecord)reader);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }

            user = new User(reader.GetInt32(0), reader.GetString(1));

            reader.Close();

            return user;
        }

        public List<int> GetUserGuildsId(int id)
        {
            List<int> guildsId = new List<int>();

            string query = "SELECT * FROM guilds_has_users WHERE users_id = @id";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader reader = _dBManager.Select(query, _parameters);

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            reader.Close();

            return guildsId;

        }

        public Guild GetGuildById(int id)
        {
            string query = "SELECT * FROM guilds WHERE id = \"@id\"";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader reader = _dBManager.Select(query, _parameters);

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            reader.Close();

            throw new NotImplementedException();
        }

        private static void ReadSingleRow(IDataRecord dataRecord)
        {
            Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
        }
    }
}