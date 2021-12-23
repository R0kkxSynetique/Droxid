using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Droxid.DataBase;
using Droxid.Models;
using System.Collections;

namespace Droxid.ViewModels
{
    // send query(data comes from each model) to dbmanager
    public class ViewModel
    {
        
        //Users
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

        public static List<Guild> GetUserGuilds(int id)
        {
            string query = $"SELECT guilds.* FROM users INNER JOIN guilds_has_users ON users.id = guilds_has_users.users_id INNER JOIN guilds ON guilds.id = guilds_has_users.guilds_id WHERE users.id = \"{id}\";";

            return DBManager.SelectUserGuilds(query);
        }

        public static void InsertUser(string username)
        {
            string query = $"INSERT INTO users (username) VALUES (\"{username}\")";

            DBManager.Insert(query);
        }

        public static void GiveRoleToUser(int user, int role)
        {
            string query = $"INSERT INTO users_has_roles (users_id, roles_id) VALUES (\"{user}\", {role})";

            DBManager.Insert(query);
        }

        public static void GiveRolesToUser(int user, List<int> role)
        {
            string query = $"INSERT INTO users_has_roles (users_id, roles_id) VALUES (\"{user}\", @role)";

            DBManager.InsertMultiple(query, role);
        }

        //Guilds
        public static Guild GetGuildById(int id)
        {
            string query = $"SELECT * FROM guilds WHERE id = {id};";

            return DBManager.SelectGuild(query);
        } 

        public static Guild GetGuildByChannelId(int id)
        {
            string query = $"";

            return DBManager.SelectGuild(query);
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

        public static void InsertGuild(string name, int owner)
        {
            string query = $"INSERT INTO guilds (`name`, owner_id) VALUES (\"{name}\", {owner})";

            DBManager.Insert(query);
        }

        public static void AddUserToGuild(int user, int guild)
        {
            string query = $"INSERT INTO guilds_has_users (guilds_id, users_id) VALUES (\"{guild}\", {user})";

            DBManager.Insert(query);
        }

        //Roles
        public static List<Permission> GetRolePermissions(int id)
        {
            string query = $"SELECT permissions.* FROM roles INNER JOIN roles_has_permissions ON roles_has_permissions.roles_id = roles.id INNER JOIN permissions ON permissions.id = roles_has_permissions.permissions_id WHERE roles.id = {id};";

            return DBManager.SelectPermissions(query);
        }

        public static void InsertRole(string name, int guild)
        {
            string query = $"INSERT INTO roles (`name`, guilds_id) VALUES (\"{name}\", {guild})";

            DBManager.Insert(query);
        }

        public static void GivePermissionToRole(int role, int permission)
        {
            string query = $"INSERT INTO roles_has_permissions (roles_id, permissions_id) VALUES (\"{role}\", {permission})";

            DBManager.Insert(query);
        }

        public static void GivePermissionToRole(int role, int permission, int channel)
        {
            string query = $"INSERT INTO roles_has_permissions (roles_id, permissions_id, channels_id) VALUES (\"{role}\", {permission}, {channel})";

            DBManager.Insert(query);
        }

        //Channels
        public static List<Message> GetChannelMessages(int id)
        {
            string query = $"SELECT messages.* FROM channels INNER JOIN messages ON channels.id = messages.channel_id WHERE channels.id = {id};";

            return DBManager.SelectMessages(query);
        }

        public static List<Permission> GetChannelPermissions(int id)
        {
            string query = $"";

            return DBManager.SelectPermissions(query);
        }

        public static void InsertChannel(string name, int guild)
        {
            string query = $"INSERT INTO channels (`name`, guild_id) VALUES (\"{name}\", {guild})";

            DBManager.Insert(query);
        }

        //Messages
        public static void InsertMessage(string content, int userId, int channelId)
        {
            string query = $"INSERT INTO messages (content, channel_id, user_id) VALUES (\"{content}\", {channelId}, {userId})";

            DBManager.Insert(query);
        }

        //Permissions
        public static void InsertPermission(string name, string description)
        {
            string query = $"INSERT INTO permissions (`name`, description) VALUES (\"{name}\", {description})";

            DBManager.Insert(query);
        }
    }
}