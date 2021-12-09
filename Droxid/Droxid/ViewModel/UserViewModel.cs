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
    public class UserViewModel
    {
        private DBManager _dBManager = new ();
        private List<MySqlParameter> _parameters = new ();

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

            List<Guild> guilds = new ();

            guilds.Add(GetGuildById(reader.GetInt32(1)));

            user = new User(reader[0].ToString(), guilds);

            reader.Close();

            return user;
        }

        public List<int> GetUserGuildsbyId(int id)
        {
            List<int> guildsId = new ();

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
            Guild guild;

            string query = "SELECT * FROM guilds WHERE id = \"@id\"";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader reader = _dBManager.Select(query, _parameters);

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            User user = GetUserById(reader.GetInt32(1));

            List<Role> roles = GetGuildRolesByGuildId(reader.GetInt32(0));

            List<Permission> permissions = GetGuildPermissionsByGuildId(id);

            List<Channel> channels = GetGuildChannelsByGuildId(id);

            guild = new Guild(reader.GetString(0), user, roles, permissions, channels);

            reader.Close();

            return guild;

        }
        // No guilds for now
        public User GetUserById(int id)
        {
            User user;

            string query = "SELECT * FROM users WHERE id = \"@id\"";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader reader = _dBManager.Select(query, _parameters);

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            user = new User(reader.GetString(0), reader.GetInt32(1));

            reader.Close();

            return user;
        }

        public List<Role> GetGuildRolesByGuildId(int id)
        {
            List<int> rolesId = new ();
            List<Role> roles = new ();

            string query = "SELECT roles_id FROM guilds_has_roles WHERE guilds_id = @id";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader reader = _dBManager.Select(query, _parameters);

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
                rolesId.Add(reader.GetInt32(0));
            }

            foreach (int guildRoleId in rolesId)
            {
                roles.Add(GetGuildRoleByGuildId(guildRoleId));
            }

            reader.Close();

            return roles;

        }

        public Role GetGuildRoleByGuildId(int id)
        {
            string query = "SELECT * FROM roles WHERE id = @id";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader reader = _dBManager.Select(query, _parameters);

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            Role role = new(reader.GetString(1), GetRoleUsersByRoleId(reader.GetInt32(0))); ;

            reader.Close();

            return role;

        }

        public List<User> GetRoleUsersByRoleId(int id)
        {
            List<User> users = new ();
            List<int> usersId = new ();

            string query = "SELECT users_id FROM users_has_roles WHERE roles_id = @id";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader reader = _dBManager.Select(query, _parameters);

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
                usersId.Add(reader.GetInt32(0));
            }
            foreach (int userId in usersId)
            {
                users.Add(GetUserById(userId));
            }

            reader.Close();

            return users;
        }

        public List<Permission> GetGuildPermissionsByGuildId(int id)
        {
            List<int> permsId = new();
            List<Permission> permissions = new();

            string query = "SELECT permissions_id FROM guilds_has_permissions WHERE guilds_id = @id";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader reader = _dBManager.Select(query, _parameters);

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
                permsId.Add(reader.GetInt32(0));
            }

            foreach (int guildPermissionId in permsId)
            {
                permissions.Add(GetGuildPermissionByGuildId(guildPermissionId));
            }

            reader.Close();

            return permissions;

        }
        public Permission GetGuildPermissionByGuildId(int id)
        {
            string query = "SELECT * FROM permissions WHERE id = @id";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader reader = _dBManager.Select(query, _parameters);

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            Permission permission = new(reader.GetString(1), reader.GetString(2), GetPermissionRolesByPermissionId(id));

            reader.Close();

            return permission;

        }

        public List<Role> GetPermissionRolesByPermissionId(int id)
        {
            List<int> rolesId = new ();
            List<Role> roles = new ();

            string query = "SELECT roles_id FROM roles_has_permissions WHERE permission_id = @id";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader reader = _dBManager.Select(query, _parameters);

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
                rolesId.Add(reader.GetInt32(0));
            }

            foreach (int roleId in rolesId)
            {
                roles.Add(GetRoleById(roleId));
            }

            reader.Close();

            return roles;
        }

        public Role GetRoleById(int id)
        {
            string query = "SELECT * FROM roles WHERE id = @id";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader reader = _dBManager.Select(query, _parameters);

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            List<User> users = GetRoleUsersById(id);

            Role role = new(reader.GetString(1), users);

            reader.Close();

            return role;
        }

        public List<User> GetRoleUsersById(int id)
        {
            List<User> users = new ();
            List<int> usersId = new ();

            string query = "SELECT * FROM users_has_roles WHERE id = @id";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader reader = _dBManager.Select(query, _parameters);

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
                usersId.Add(reader.GetInt32(0));
            }

            foreach (int userId in usersId)
            {
                users.Add(GetUserById(userId));
            }

            reader.Close();

            return users;
        }

        public List<Channel> GetGuildChannelsByGuildId(int id)
        {
            List<Channel> channels = new();

            string query = "SELECT * FROM channels WHERE guild_id = @id";

            _parameters.Clear();

            _parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader reader = _dBManager.Select(query, _parameters);

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
                Channel channel = new(reader.GetString(1));
                channels.Add(channel);
            }

            reader.Close();

            return channels;
        }

        private static void ReadSingleRow(IDataRecord dataRecord)
        {
            Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
        }
    }
}