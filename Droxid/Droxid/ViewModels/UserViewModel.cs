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
            string query = $"SELECT * FROM users WHERE username = \"{username}\";";

            User user = DBManager.SelectUser(query);

            return user;
        }

        public static User GetUserById(string id)
        {
            string query = $"SELECT * FROM users WHERE id = \"{id}\";";

            User user = DBManager.SelectUser(query);

            return user;
        }

        public static List<dynamic> GetUserGuilds(string username)
        {
            string query = $"SELECT guilds.* FROM users INNER JOIN guilds_has_users ON users.id = guilds_has_users.users_id INNER JOIN guilds ON guilds.id = guilds_has_users.guilds_id WHERE username LIKE \"{username}\"; ";

            List<Guild> guilds = new(DBManager.SelectUserGuilds(query));

            return null;
        }

        public static List<Role> GetGuildRoles(string id)
        {
            string query = $"SELECT roles.* FROM roles WHERE roles.guilds_id = {id};";

            List<Role> roles = new(DBManager.SelectRoles(query));

            return roles;
        }

        public static List<Channel> GetGuildChannels(string id)
        {
            string query = $"SELECT channels.* FROM guilds INNER JOIN channels ON guilds.id = channels.guild_id WHERE guilds.id = {id};";

            List<Channel> channels = new(DBManager.SelectChannels(query));

            return channels;
        }

        public static List<Permission> GetRolePermissions(string id)
        {
            string query = $"SELECT permissions.* FROM roles INNER JOIN roles_has_permissions ON roles_has_permissions.roles_id = roles.id INNER JOIN permissions ON permissions.id = roles_has_permissions.permissions_id WHERE roles.id = {id};";

            List<Permission> permissions = new(DBManager.SelectPermissions(query));

            return permissions;
        }
    }
}