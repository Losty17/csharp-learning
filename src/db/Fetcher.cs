using Microsoft.Data.Sqlite;
using Models;

namespace Fetcher
{
    public class UserFetcher
    {
        public static User fetchOne(SqliteDataReader reader)
        {
            var user = new User();
            var i = 0;

            while (reader.Read())
            {
                user.Id = reader.GetInt32(i++);
                user.Username = reader.GetString(i++);
                user.Password = reader.GetString(i++);
                user.Email = reader.GetString(i++);
                user.CreatedAt = reader.GetDateTime(i++);
            }

            return user;
        }

        public static List<User> fetchAll(SqliteDataReader reader)
        {
            var ul = new List<User>();

            while (reader.Read())
            {
                var i = 0;
                var user = new User();

                user.Id = reader.GetInt32(i++);
                user.Username = reader.GetString(i++);
                user.Password = reader.GetString(i++);
                user.Email = reader.GetString(i++);
                user.CreatedAt = reader.GetDateTime(i++);

                ul.Add(user);
            }

            return ul;
        }
    }
}