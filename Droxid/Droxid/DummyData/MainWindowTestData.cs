using Droxid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droxid.DummyData
{
    public static class MainWindowTestData
    {
        private static Random random = new Random();

        public static User GenerateUser()
        {
            return new User(RandomString(random.Next(1, 2)));
        }

        public static Guild GenerateGuild()
        {
            Guild guild = new Guild(RandomString(random.Next(1, 4)), GenerateUser(), new List<Role>(), new List<Channel>(), new List<User>());
            for (int i = 0; i < random.Next(1, 25); i++)
            {
                GenerateChannel(guild);
            }
            return guild;
        }

        public static List<Guild> GenerateGuilds()
        {
            List<Guild> list = new List<Guild>();

            for (int i = 0; i < random.Next(1, 20); i++)
            {
                list.Add(GenerateGuild());
            }

            return list;
        }

        public static void GenerateChannel(Guild guild)
        {
            Channel channel = guild.Channels[guild.AddChannel(RandomString(random.Next(1, 5)))];

            List<User> users = new List<User>();
            for (int i = 0; i < random.Next(1, 10); i++)
            {
                users.Add(GenerateUser());
            }

            for (int i = 0; i < random.Next(3, 30); i++)
            {
                GenerateMessage(channel, users[random.Next(0, users.Count)]);
            }
        }

        public static void GenerateMessage(Channel channel, User sender)
        {
            channel.AddMessage(RandomString(random.Next(1, 256)), sender);
        }


        private static string RandomString(int length)
        {
            string[] words = { "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer", "adipiscing","elit","sed","diam","nonummy","nibh","euismod","tincidunt","ut","laoreet","dolore","magna","aliquam","erat"};
            string result = "";
            for (int i = 0; i < length; i++)
            {
                result += words[random.Next(0, words.Length)];
                result += i < length ? " " : "";
            }

            return result;
            //const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            //return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
