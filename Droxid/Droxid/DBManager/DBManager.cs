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
    public class DBManager
    {
        private static string _defaultConfigPath = AppDomain.CurrentDomain.BaseDirectory + "config.drxd";

        //This may not work beacause of the static methods(May need an object to end a connection)
        private static MySqlConnection _connection;

        /// <summary>
        /// Changes the static connection during runtime and opens it
        /// </summary>
        /// <param name="server">name/ip address of the sql server</param>
        /// <param name="database">database name used for droxid</param>
        /// <param name="user">database user with CRUD access to the database</param>
        /// <param name="password">user's password</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Thrown when the connection failed to open</exception>
        public static void OpenDBConnection(string server, string database, string user, string password)
        {
            _connection = new($"Database={database};Server={server};user={user};password={password};CharSet=utf8mb4;");
            _connection.Open();
        }

        /// <summary>
        /// Opens the connection to the database using the static connection instance
        /// </summary>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException"></exception>
        public static void OpenDBConnection()
        {
            _connection.Open();
        }
        /// <summary>
        /// Closes the connection to the database using the static connection instance
        /// </summary>
        public static void CloseDBConnection()
        {
            _connection.Close();
        }

        /// <summary>
        /// Executes a select query for 1 user
        /// </summary>
        /// <param name="query">Query which will be executed</param>
        /// <returns>User | null(when the query doesn't return anything)</returns>
        public static User? SelectUser(string query)
        {
            User? user = null;

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                user = new(singleResult.id, singleResult.username, singleResult.created_at, singleResult.updated_at, (singleResult.deleted == 1));
            }

            return user;
        }
        /// <summary>
        /// Execute a select query for multiple users
        /// </summary>
        /// <param name="query">Query which will be executed</param>
        /// <returns>The list of users from the query</returns>
        public static List<User> SelectUsers(string query)
        {
            List<User> users = new();

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                users.Add(new(singleResult.id, singleResult.username, singleResult.created_at, singleResult.updated_at, (singleResult.deleted == 1)));
            }

            return users;
        }
        /// <summary>
        /// Execute a select query for multiple guilds
        /// </summary>
        /// <param name="query">Query which will be executed</param>
        /// <returns>The list of guilds from the query</returns>
        public static List<Guild> SelectUserGuilds(string query)
        {
            List<Guild>? guilds = new();

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                guilds.Add(new(singleResult.id, singleResult.name, singleResult.owner_id, singleResult.created_at, singleResult.updated_at, (singleResult.deleted == 1), (singleResult.isPrivate == 1)));
            }

            return guilds;
        }
        /// <summary>
        /// Execute a select query for 1 guild
        /// </summary>
        /// <param name="query">Query which will be executed</param>
        /// <returns>Guild | null(when the query doesn't return anything)</returns>
        public static Guild? SelectGuild(string query)
        {
            Guild? guild = null;

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                guild = new(singleResult.id, singleResult.name, singleResult.owner, singleResult.created_at, singleResult.updated_at, (singleResult.deleted == 1), singleResult.isPrivate);
            }

            return guild;
        }
        /// <summary>
        /// Execute a select query for multiple roles
        /// </summary>
        /// <param name="query">Query which will be executed</param>
        /// <returns>The list of roles from the query</returns>
        public static List<Role> SelectRoles(string query)
        {
            List<Role> roles = new();

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                roles.Add(new(singleResult.id, singleResult.name, singleResult.created_at, singleResult.updated_at, (singleResult.deleted == 1)));
            }

            return roles;
        }
        public static Channel SelectChannel(string query)
        {
            Channel? channel = null;

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                channel = new(singleResult.id, singleResult.name, singleResult.created_at, singleResult.updated_at, (singleResult.deleted == 1));
            }

            return channel;
        }
        /// <summary>
        /// Execute a select query for multiple channels
        /// </summary>
        /// <param name="query">Query which will be executed</param>
        /// <returns>The list of channels from the query</returns>
        public static List<Channel> SelectChannels(string query)
        {
            List<Channel> channels = new();

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                if (!channels.Contains(new(singleResult.id, singleResult.name, singleResult.created_at, singleResult.updated_at, (singleResult.deleted == 1))))
                {
                    channels.Add(new(singleResult.id, singleResult.name, singleResult.created_at, singleResult.updated_at, (singleResult.deleted == 1)));
                }
            }

            return channels;
        }
        /// <summary>
        /// Execute a select query for multiple permissions
        /// </summary>
        /// <param name="query">Query which will be executed</param>
        /// <returns>The list of permissions from the query</returns>
        public static List<Permission> SelectPermissions(string query)
        {
            List<Permission> permissions = new();

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                permissions.Add(new(singleResult.id, singleResult.name, singleResult.description, singleResult.created_at, singleResult.updated_at, (singleResult.deleted == 1)));
            }

            return permissions;
        }
        /// <summary>
        /// Execute a select query for multiple messages
        /// </summary>
        /// <param name="query">Query which will be executed</param>
        /// <returns>The list of messages from the query</returns>
        public static List<Message> SelectMessages(string query)
        {
            List<Message> messages = new();

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                messages.Add(new(singleResult.id, singleResult.content, singleResult.user_id, singleResult.channel_id, singleResult.created_at, singleResult.updated_at, (singleResult.deleted == 1)));
            }

            return messages;
        }
        /// <summary>
        /// Execute a select which returns a single id
        /// </summary>
        /// <remarks>Mainly for inserts with the RETURNING keyword</remarks>
        /// <param name="query">Query which will be executed</param>
        /// <returns>id || null when there are no matches</returns>
        public static int? SelectId(string query)
        {
            int? id = null;

            IEnumerable queryResult = _connection.Query(query);
            foreach (dynamic singleResult in queryResult)
            {
                id = singleResult.id;
            }

            return id;
        }
        /// <summary>
        /// Execute a select which returns multiple ids
        /// </summary>
        /// <remarks>Mainly for inserts with the RETURNING keyword</remarks>
        /// <param name="query">Query which will be executed</param>
        /// <returns>List of ids</returns>
        public static List<int> SelectIds(string query)
        {
            List<int> ids = new List<int>();
            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                ids.Add(singleResult.id);
            }

            return ids;
        }
        /// <summary>
        /// Execute an insert query
        /// </summary>
        /// <param name="query">Query which will be executed</param>
        /// <returns>The number of rows affected</returns>
        public static int Insert(string query)
        {
            return _connection.Execute(query);
        }
        /// <summary>
        /// Execute an insert query for multiple values
        /// </summary>
        /// <param name="query">Query which will be executed</param>
        /// <param name="parameters">The parameters to use for this query</param>
        /// <returns></returns>
        public static int InsertMultiple(string query, List<int> parameters)
        {
            return _connection.Execute(query, parameters);
        }

        public static bool CheckPermission(string query)
        {
            bool can = false;

            IEnumerable queryResult = _connection.Query(query);

            foreach (dynamic singleResult in queryResult)
            {
                if (!String.IsNullOrWhiteSpace(singleResult.permissions_id.ToString())){can = true;};
            }

            return can;
        }
        /// <summary>
        /// Execute a delete query
        /// </summary>
        /// <param name="query">Query which will be executed</param>
        /// <returns>The number of rows affected</returns>
        public static int Delete(string query)
        {
            return _connection.Execute(query);
        }
        /// <summary>
        /// Execute an update query
        /// </summary>
        /// <param name="query">Query which will be executed</param>
        /// <returns>The number of rows affected</returns>
        public static int Update(string query)
        {
            return _connection.Execute(query);
        }
    }
}
