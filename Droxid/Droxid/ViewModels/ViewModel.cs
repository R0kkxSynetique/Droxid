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
    public static class ViewModel
    {
        //Users
        /// <summary>
        /// Fetch an user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Selected user | null when there are no matches</returns>
        public static User? GetUserByUsername(string username)
        {
            string query = $"SELECT * FROM users WHERE username = \"{username}\" AND users.deleted = FALSE;";

            return DBManager.SelectUser(query);
        }
        /// <summary>
        /// Fetch an user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Selected user | null when there are no matches</returns>
        public static User? GetUserById(int id)
        {
            string query = $"SELECT * FROM users WHERE id = \"{id}\" AND users.deleted = FALSE;";

            return DBManager.SelectUser(query);
        }
        /// <summary>
        /// Fetch the list of guilds of an user based on his username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>List of guilds with this user</returns>
        public static List<Guild> GetUserGuilds(string username)
        {
            string query = $"SELECT guilds.* FROM users INNER JOIN guilds_has_users ON users.id = guilds_has_users.users_id INNER JOIN guilds ON guilds.id = guilds_has_users.guilds_id WHERE username LIKE \"{username}\" AND guilds.deleted = FALSE;";

            return DBManager.SelectUserGuilds(query);
        }
        /// <summary>
        /// Fetch the list of guilds of an user based on his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of guilds with this user</returns>
        public static List<Guild> GetUserGuilds(int id)
        {
            string query = $"SELECT guilds.* FROM users INNER JOIN guilds_has_users ON users.id = guilds_has_users.users_id INNER JOIN guilds ON guilds.id = guilds_has_users.guilds_id WHERE users.id = \"{id}\" AND guilds.deleted = FALSE;";

            return DBManager.SelectUserGuilds(query);
        }
        /// <summary>
        /// Fetch an user's list of guilds which were updated after a give time
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="lastUpdated">Datetime after which the guilds were updated</param>
        /// <returns>List of guilds with this user which were updated after the given timestamp</returns>
        public static List<Guild> GetUserGuilds(int id, DateTime lastUpdated)
        {
            string query = $"SELECT guilds.* FROM users INNER JOIN guilds_has_users ON users.id = guilds_has_users.users_id INNER JOIN guilds ON guilds.id = guilds_has_users.guilds_id WHERE users.id = \"{id}\" AND guilds.updated_at > \"{lastUpdated.ToSqlString()}\";";

            return DBManager.SelectUserGuilds(query);
        }
        /// <summary>
        /// Adds a new user with a given username to the database
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Number of rows affected</returns>
        public static int InsertUser(string username)
        {
            string query = $"INSERT INTO users (username) VALUES (\"{username}\")";

            return DBManager.Insert(query);
        }
        /// <summary>
        /// Add an user to a role
        /// </summary>
        /// <param name="user">User id</param>
        /// <param name="role">Role id</param>
        /// <returns>Number of rows affected</returns>
        public static int GiveRoleToUser(int user, int role)
        {
            string query = $"INSERT INTO users_has_roles (users_id, roles_id) VALUES (\"{user}\", {role})";

            return DBManager.Insert(query);
        }
        /// <summary>
        /// Add an user to multiple roles
        /// </summary>
        /// <param name="user">User id</param>
        /// <param name="role">Role id</param>
        /// <returns>Number of rows affected</returns>
        public static int GiveRolesToUser(int user, List<int> role)
        {
            string query = $"INSERT INTO users_has_roles (users_id, roles_id) VALUES (\"{user}\", @role)";

            return DBManager.InsertMultiple(query, role);
        }

        //Guilds
        /// <summary>
        /// Fetch a guild by id
        /// </summary>
        /// <param name="id">Guild id</param>
        /// <returns>Guild | null when there are no matches</returns>
        public static Guild? GetGuildById(int id)
        {
            string query = $"SELECT * FROM guilds WHERE id = {id} AND guilds.deleted = FALSE;";

            return DBManager.SelectGuild(query);
        }
        /// <summary>
        /// Fetch a guild by channel id
        /// </summary>
        /// <param name="id">Channel id</param>
        /// <returns>Guild | null when there are no matches</returns>
        public static Guild? GetGuildByChannelId(int id)
        {
            string query = $"";

            return DBManager.SelectGuild(query);
        }
        /// <summary>
        /// Fetch a list of all users in a guild
        /// </summary>
        /// <param name="id">Guild id</param>
        /// <returns>List of users</returns>
        public static List<User> GetGuildUsers(int id)
        {
            string query = $"SELECT users.* FROM guilds_has_users INNER JOIN users ON guilds_has_users.users_id = users.id WHERE guilds_has_users.guilds_id = {id} AND users.deleted = FALSE;";

            return DBManager.SelectUsers(query);
        }
        /// <summary>
        /// Fetch a list of all the users in a guild which were updated after a given datetime
        /// </summary>
        /// <param name="id">Guild id</param>
        /// <param name="lastUpdated">Datetime after which the users were updated</param>
        /// <returns>List of users</returns>
        public static List<User> GetGuildUsers(int id, DateTime lastUpdated)
        {
            string query = $"SELECT users.*FROM guilds_has_users INNER JOIN users ON guilds_has_users.users_id = users.id WHERE guilds_has_users.guilds_id = {id} AND users.updated_at > \"{lastUpdated.ToSqlString()}\";";

            return DBManager.SelectUsers(query);
        }
        /// <summary>
        /// Fetch a list of roles in a guild
        /// </summary>
        /// <param name="id">Guild id</param>
        /// <returns>List of roles</returns>
        public static List<Role> GetGuildRoles(int id)
        {
            string query = $"SELECT roles.* FROM roles WHERE roles.guilds_id = {id} AND roles.deleted = FALSE;";

            return DBManager.SelectRoles(query);
        }
        /// <summary>
        /// Fetch a list of channels in a guild
        /// </summary>
        /// <param name="id">Guild id</param>
        /// <returns>List of channels</returns>
        public static List<Channel> GetGuildChannels(int id)
        {
            string query = $"SELECT channels.* FROM guilds INNER JOIN channels ON guilds.id = channels.guild_id WHERE guilds.id = {id} AND channels.deleted = FALSE;";

            return DBManager.SelectChannels(query);
        }
        /// <summary>
        /// Fetch a list of channels which the given user is allowed to see
        /// </summary>
        /// <param name="guild">Guild id</param>
        /// <param name="user">User id</param>
        /// <returns>List of channels</returns>
        public static List<Channel> GetGuildChannels(int guild, int user)
        {
            string query = $"SELECT channels.* FROM users_has_roles INNER JOIN roles ON users_has_roles.roles_id = roles.id INNER JOIN channels ON roles.guilds_id = channels.guild_id INNER JOIN roles_has_permissions ON roles_has_permissions.roles_id = roles.id INNER JOIN permissions ON permissions.id = roles_has_permissions.permissions_id WHERE users_has_roles.users_id = {user} AND channels.guild_id = {guild} AND roles_has_permissions.permissions_id = 2 AND channels.deleted = FALSE;";

            return DBManager.SelectChannels(query);
        }
        /// <summary>
        /// Fetch a list of channels which were updated after a given datetime
        /// </summary>
        /// <param name="guild">Guild id</param>
        /// <param name="lastUpdated">Datetime after which the channels were updated</param>
        /// <returns>List of channels</returns>
        public static List<Channel> GetGuildChannels(int guild, int user, DateTime lastUpdated)
        {
            string query = $"SELECT channels.* FROM users_has_roles INNER JOIN roles ON users_has_roles.roles_id = roles.id INNER JOIN channels ON roles.guilds_id = channels.guild_id INNER JOIN roles_has_permissions ON roles_has_permissions.roles_id = roles.id INNER JOIN permissions ON permissions.id = roles_has_permissions.permissions_id WHERE users_has_roles.users_id = {user} AND channels.guild_id = {guild} AND roles_has_permissions.permissions_id = 2 AND channels.updated_at > \"{lastUpdated.ToSqlString()}\" AND channels.deleted = FALSE;";

            return DBManager.SelectChannels(query);
        }
        /// <summary>
        /// Adds a guild to the database
        /// </summary>
        /// <param name="name">Guild name</param>
        /// <param name="owner">Owner id</param>
        /// <returns>Number of rows affected</returns>
        public static int InsertGuild(string name, int owner)
        {
            string query = $"INSERT INTO guilds (`name`, owner_id) VALUES (\"{name}\", {owner})";

            return DBManager.Insert(query);
        }
        /// <summary>
        /// Creates a guild and adds the owner to the list of members
        /// </summary>
        /// <param name="owner">Guild owner</param>
        /// <param name="name">Guild name</param>
        /// <exception cref="GuildCreationFailedException"></exception>
        public static void CreateGuild(this User owner, string name)
        {
            if (owner == null) { throw new EmptyOwnerException(); }
            if (name == null) { throw new EmptyGuildNameException(); }

            string query = $"INSERT INTO guilds (`name`, owner_id) VALUES (\"{name}\", {owner.Id}); SELECT LAST_INSERT_ID() AS id;";
            int? id = DBManager.SelectId(query);
            if (id == null) throw new GuildCreationFailedException();
            AddUserToGuild(owner.Id, (int)id);

        }
        /// <summary>
        /// Add a new channel to a guild
        /// </summary>
        /// <param name="guild">Guild</param>
        /// <param name="name">New channel name</param>
        public static void AddChannel(this Guild guild, string name)
        {
            if (guild == null) { throw new EmptyChannelGuild(); }
            if (string.IsNullOrWhiteSpace(name)) { throw new EmptyChannelName(); }

            InsertChannel(name, guild.Id);
        }
        /// <summary>
        /// Add an user to a guild
        /// </summary>
        /// <param name="user">User id</param>
        /// <param name="guild">Guild id</param>
        /// <returns>Number of rows affected</returns>
        public static int AddUserToGuild(int user, int guild)
        {
            string query = $"INSERT INTO guilds_has_users (guilds_id, users_id) VALUES (\"{guild}\", {user})";

            return DBManager.Insert(query);
        }

        public static int RemoveUserFromGuild(int user, int guild)
        {
            string query = $"DELETE FROM guilds_has_users WHERE guilds_id = {guild} AND users_id = {user};";
            return DBManager.Delete(query);
        }

        //Roles
        /// <summary>
        /// Fetch a list of permissons from a role
        /// </summary>
        /// <param name="id">Role id</param>
        /// <returns>List of permissions</returns>
        public static List<Permission> GetRolePermissions(int id)
        {
            string query = $"SELECT permissions.* FROM roles INNER JOIN roles_has_permissions ON roles_has_permissions.roles_id = roles.id INNER JOIN permissions ON permissions.id = roles_has_permissions.permissions_id WHERE roles.id = {id}  AND permissions.deleted = FALSE;";

            return DBManager.SelectPermissions(query);
        }
        /// <summary>
        /// Add a role to the database
        /// </summary>
        /// <param name="name">Role name</param>
        /// <param name="guild">Guild id</param>
        /// <returns>Number of rows affected</returns>
        public static int InsertRole(string name, int guild)
        {
            string query = $"INSERT INTO roles (`name`, guilds_id) VALUES (\"{name}\", {guild})";

            return DBManager.Insert(query);
        }
        /// <summary>
        /// Add a permission to a role
        /// </summary>
        /// <param name="role">Role id</param>
        /// <param name="permission">Permission id</param>
        /// <returns>Number of rows affected</returns>
        public static int GivePermissionToRole(int role, int permission)
        {
            string query = $"INSERT INTO roles_has_permissions (roles_id, permissions_id) VALUES (\"{role}\", {permission})";

            return DBManager.Insert(query);
        }
        /// <summary>
        /// Add permissions to a role in a given channel
        /// </summary>
        /// <param name="role">Role id</param>
        /// <param name="permission">Permission id</param>
        /// <param name="channel">Channel id</param>
        /// <returns>Number of rows affected</returns>
        public static int GivePermissionToRole(int role, int permission, int channel)
        {
            string query = $"INSERT INTO roles_has_permissions (roles_id, permissions_id, channels_id) VALUES (\"{role}\", {permission}, {channel})";

            return DBManager.Insert(query);
        }
        public static List<User> GetRoleUsers(int role)
        {
            string query = $"SELECT users.* FROM users_has_roles INNER JOIN users ON users_has_roles.users_id = users.id WHERE users_has_roles.roles_id = {role}";

            return DBManager.SelectUsers(query);
        }

        //Channels
        /// <summary>
        /// Fetch a list of messages in a channel
        /// </summary>
        /// <param name="id">Channel id</param>
        /// <returns>List of messages</returns>
        public static List<Message> GetChannelMessages(int id)
        {
            string query = $"SELECT messages.* FROM channels INNER JOIN messages ON channels.id = messages.channel_id WHERE channels.id = {id}  AND messages.deleted = FALSE;";

            return DBManager.SelectMessages(query);
        }
        /// <summary>
        /// Fetch a list of messages in a channel which were updated after a given datetime
        /// </summary>
        /// <param name="id">Channel id</param>
        /// <param name="lastUpdated">Datetime after which the messages were updated</param>
        /// <returns>List of messages</returns>
        public static List<Message> GetChannelMessages(int id, DateTime lastUpdated)
        {
            string query = $"SELECT messages.* FROM channels INNER JOIN messages ON channels.id = messages.channel_id WHERE channels.id = {id}  AND messages.updated_at > \"{lastUpdated.ToSqlString()}\";";

            return DBManager.SelectMessages(query);
        }
        /// <summary>
        /// Fetch a list of permissions applied to a channel
        /// </summary>
        /// <param name="id">Channel id</param>
        /// <returns>List of permissions</returns>
        public static List<Permission> GetChannelPermissions(int id)
        {
            string query = $"SELECT permissions.* FROM roles_has_permissions INNER JOIN permissions ON roles_has_permissions.permissions_id = permissions.id WHERE roles_has_permissions.channels_id = {id}";

            return DBManager.SelectPermissions(query);
        }
        /// <summary>
        /// Add a channel to the database
        /// </summary>
        /// <param name="name">Channel name</param>
        /// <param name="guild">Guild id</param>
        /// <returns>Number of rows affected</returns>
        public static int InsertChannel(string name, int guild)
        {
            string query = $"INSERT INTO channels (`name`, guild_id) VALUES (\"{name}\", {guild})";

            return DBManager.Insert(query);
        }
        /// <summary>
        /// Modify a channel from the database
        /// </summary>
        /// <param name="channel">Channel to edit</param>
        /// <param name="name">New channel name</param>
        /// <returns>Number of rows affected</returns>
        public static int UpdateChannel(this Channel channel, string name)
        {
            if (channel == null) { throw new NoGivenChannelException(); }
            if (string.IsNullOrWhiteSpace(name)) { throw new EmptyChannelName(); }

            string query = $"UPDATE channels SET `name` = \"{name}\" WHERE id = {channel.Id}";

            return DBManager.Update(query);
        }
        /// <summary>
        /// Mark the channel as delete in the database
        /// </summary>
        /// <param name="channel">Channel to delete</param>
        /// <returns>Number of rows affected</returns>
        public static int DeleteChannel(this Channel channel)
        {
            string query = $"UPDATE channels SET deleted = 1 WHERE id = {channel.Id}";

            return DBManager.Delete(query);
        }
        //Messages
        /// <summary>
        /// Add a message to the database
        /// </summary>
        /// <param name="content">Message content</param>
        /// <param name="userId">Sender id</param>
        /// <param name="channelId">Channel id</param>
        /// <returns>Number of rows affected</returns>
        public static int InsertMessage(string content, int userId, int channelId)
        {
            string query = $"INSERT INTO messages (content, channel_id, user_id) VALUES (\"{content}\", {channelId}, {userId})";

            return DBManager.Insert(query);
        }

        public static Channel GetMessageChannel(int message)
        {
            string query = $"SELECT channels.* FROM messages INNER JOIN channels ON messages.channel_id = channels.id WHERE messages.id = {message}";

            return DBManager.SelectChannel(query);
        }

        //Permissions
        /// <summary>
        /// Adds a permission to the database
        /// </summary>
        /// <param name="name">Permission name</param>
        /// <param name="description">Permission description</param>
        /// <returns>Number of rows affected</returns>
        public static int InsertPermission(string name, string description)
        {
            string query = $"INSERT INTO permissions (`name`, description) VALUES (\"{name}\", {description})";

            return DBManager.Insert(query);
        }

        public static List<Role> GetPermissionRoles(int permission)
        {
            string query = $"SELECT roles.* FROM roles_has_permissions INNER JOIN roles ON roles_has_permissions.roles_id = roles.id INNER JOIN permissions ON roles_has_permissions.permissions_id = permissions.id WHERE permissions.id = {permission}";

            return DBManager.SelectRoles(query);
        }

        public static bool CanUserWriteInChannel(int channel, int user, int guild)
        {
            string query = $"SELECT roles_has_permissions.permissions_id FROM roles_has_permissions INNER JOIN roles ON roles_has_permissions.roles_id = roles.id INNER JOIN users_has_roles ON roles.id = users_has_roles.roles_id INNER JOIN users ON users_has_roles.users_id = users.id WHERE roles_has_permissions.permissions_id = 1 AND roles_has_permissions.channels_id = {channel} AND users.id = {user} OR roles_has_permissions.permissions_id = 1 AND roles.guilds_id = {guild} AND users.id = {user}";

            return DBManager.CheckPermission(query);
        }

        public static bool CanUserEditGuild(int user, int guild)
        {
            string query = $"SELECT * FROM roles_has_permissions INNER JOIN roles ON roles_has_permissions.roles_id = roles.id INNER JOIN users_has_roles ON roles.id = users_has_roles.roles_id INNER JOIN users ON users_has_roles.users_id = users.id INNER JOIN guilds ON roles.guilds_id = guilds.id WHERE roles_has_permissions.permissions_id = 5 AND roles.guilds_id = {guild} AND users.id = {user} OR roles.guilds_id = {guild} AND guilds.owner_id = {user} AND users.id = {user}";

            return DBManager.CheckPermission(query);
        }

        public static bool CanUserEditChannel(int user, int channel, int guild)
        {
            string query = $"SELECT * FROM roles_has_permissions INNER JOIN roles ON roles_has_permissions.roles_id = roles.id INNER JOIN users_has_roles ON roles.id = users_has_roles.roles_id INNER JOIN users ON users_has_roles.users_id = users.id INNER JOIN guilds ON roles.guilds_id = guilds.id WHERE roles_has_permissions.permissions_id = 3 AND roles.guilds_id = {guild} AND users.id = {user} AND channels_id IS NULL OR roles.guilds_id = {guild} AND guilds.owner_id = {user} AND users.id = {user} OR roles_has_permissions.channels_id = {channel} AND roles_has_permissions.permissions_id = 3 AND users.id = {user}";

            return DBManager.CheckPermission(query);
        }
        public static bool TestConnection()
        {
            try
            {
                DBManager.OpenDBConnection();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public static bool TestConnection(string server, string database, string user, string password)
        {
            try
            {
                DBManager.OpenDBConnection(server, database, user, password);
                return true;

            }
            catch
            {
                return false;
            }
        }
    }

    public class ViewModelException : Exception { }
    public class GuildCreationFailedException : ViewModelException { }
    public class ChannelCreationFailedException : ViewModelException { }
    public class NoGivenChannelException : ViewModelException { }
    public class NoSelectedChannelException : ViewModelException { }
    public class EmptyOwnerException : GuildCreationFailedException { }
    public class EmptyGuildNameException : GuildCreationFailedException { }
    public class EmptyChannelName : ChannelCreationFailedException { }
    public class EmptyChannelGuild : ChannelCreationFailedException { }

}
