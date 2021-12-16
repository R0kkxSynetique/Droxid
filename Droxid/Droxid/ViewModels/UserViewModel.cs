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

        public static User GetUserByUsername(string username)
        {
            string query = $"SELECT * FROM users WHERE username = \"{username}\";";

            return DBManager.SelectUser(query);
        }

        public static User GetUserById(int id)
        {
            string query = $"SELECT * FROM users WHERE id = \"{id}\";";

            return DBManager.SelectUser(query);
        }

        public static List<Guild> GetUserGuilds(string username)
        {
            string query = $"SELECT guilds.* FROM users INNER JOIN guilds_has_users ON users.id = guilds_has_users.users_id INNER JOIN guilds ON guilds.id = guilds_has_users.guilds_id WHERE username LIKE \"{username}\";";

            return DBManager.SelectUserGuilds(query);
        }

        public static List<User> GetGuildUsers(int id)
        {
            string query = $"SELECT users.* FROM guilds_has_users INNER JOIN users ON guilds_has_users.users_id = users.id WHERE guilds_has_users.guilds_id = {id};";

            return DBManager.SelectUsers(query);
        }

        public static List<Role> GetGuildRoles(int id)
        {
            string query = $"SELECT roles.* FROM roles WHERE roles.guilds_id = {id};";

            return DBManager.SelectRoles(query);
        }

        public static List<Channel> GetGuildChannels(int id)
        {
            string query = $"SELECT channels.* FROM guilds INNER JOIN channels ON guilds.id = channels.guild_id WHERE guilds.id = {id};";

            return DBManager.SelectChannels(query);
        }

        public static List<Permission> GetRolePermissions(int id)
        {
            string query = $"SELECT permissions.* FROM roles INNER JOIN roles_has_permissions ON roles_has_permissions.roles_id = roles.id INNER JOIN permissions ON permissions.id = roles_has_permissions.permissions_id WHERE roles.id = {id};";

            return DBManager.SelectPermissions(query);
        }

        public static List<Message> GetChannelMessages(int id)
        {
            string query = $"SELECT messages.* FROM channels INNER JOIN messages ON channels.id = messages.channel_id WHERE channels.id = {id};";

            return DBManager.SelectMessages(query);
        }

        public static Guild GetGuildById(int id)
        {
            string query = $"SELECT * FROM guilds WHERE id = {id};";

            return DBManager.SelectGuild(query);
        }

        public static List<Permission> GetChannelPermissions(int id)
        {
            string query = $"";

            return DBManager.SelectPermissions(query);
        }

        public static Guild GetGuildByChannelId(int id)
        {
            string query = $"";

            return DBManager.SelectGuild(query);
        }
    }
}