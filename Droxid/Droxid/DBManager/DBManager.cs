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
            User? user = null;

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                user = new(singleResult.id, singleResult.username, singleResult.created_at,singleResult.updated_at);
            }

            return user;
        }

        public static List<User> SelectUsers(string query)
        {
            List<User>? users = new();

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                users.Add(new(singleResult.id, singleResult.username, singleResult.created_at, singleResult.updated_at));
            }

            return users;
        }

        public static List<Guild> SelectUserGuilds(string query)
        {
            List<Guild>? guilds = new();

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                guilds.Add(new(singleResult.id, singleResult.name, singleResult.owner_id, singleResult.created_at, singleResult.updated_at));
            }

            return guilds;
        }

        public static Guild SelectGuild(string query)
        {
            Guild? guild = null;

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                guild = new(singleResult.id, singleResult.name, singleResult.owner, singleResult.created_at, singleResult.updated_at);
            }

            return guild;
        }

        public static List<Role> SelectRoles(string query)
        {
            List<Role> roles = new();

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                roles.Add(new(singleResult.id, singleResult.name, singleResult.created_at, singleResult.updated_at));
            }

            return roles;
        }

        public static List<Channel> SelectChannels(string query)
        {
            List<Channel>? channels = new();

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                channels.Add(new(singleResult.id, singleResult.name, singleResult.created_at, singleResult.updated_at));
            }

            return channels;
        }

        public static List<Permission> SelectPermissions(string query)
        {
            List<Permission>? permissions = new();

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                permissions.Add(new(singleResult.id, singleResult.name, singleResult.description, singleResult.created_at, singleResult.updated_at));
            }

            return permissions;
        }

        public static List<Message> SelectMessages(string query)
        {
            List<Message>? messages = new();

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                messages.Add(new(singleResult.id, singleResult.content, singleResult.user_id, singleResult.channel_id, singleResult.created_at, singleResult.updated_at));
            }

            return messages;
        }

        public static int Insert(string query)
        {
            return _connection.Execute(query);
        }

        public static int InsertMultiple(string query, List<int> parameters)
        {
            return _connection.Execute(query, parameters);
        }
    }
}
