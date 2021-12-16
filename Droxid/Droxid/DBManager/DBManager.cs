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
using Droxid.ViewModels;

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

            User? user = null;

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic sigleResult in queryResult)
            {
                result.Add("id",sigleResult.id.ToString());
                result.Add("username", sigleResult.username);

                user = new(sigleResult.username, sigleResult.id);
            }

            return user;
        }

        public static dynamic SelectUserGuilds(string query)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();

            List<Guild>? guilds = null;

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic sigleResult in queryResult)
            {
                result.Add("id", sigleResult.id.ToString());
                result.Add("name", sigleResult.name);
                result.Add("owner_id", sigleResult.owner_id);

                guilds.Add(new(result["name"],UserViewModel.GetUserById(result["owner_id"]), UserViewModel.GetGuildRoles(result["id"]),UserViewModel.GetGuildChannels(result["id"])));
            }

            return guilds;
        }

        public static List<Role> SelectRoles(string query)
        {

            IDictionary<string, string> result = new Dictionary<string, string>();

            List<Role>? roles = null;

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic sigleResult in queryResult)
            {
                result.Add("name", sigleResult.name);

                roles.Add(new(result["name"]));
            }

            return roles;

        }

        public static List<Channel> SelectChannels(string query)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();

            List<Channel>? channels = null;

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic sigleResult in queryResult)
            {
                result.Add("name", sigleResult.name);

                channels.Add(new(result["name"]));
            }

            return channels;
        }

        public static List<Permission> SelectPermissions(string query)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();

            List<Permission>? permissions = null;

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic sigleResult in queryResult)
            {
                result.Add("name", sigleResult.name);

                permissions.Add(new(result["name"],result["desciption"]));
            }

            return permissions;
        }
    }
}
