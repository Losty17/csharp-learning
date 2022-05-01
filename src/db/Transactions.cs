using Microsoft.Data.Sqlite;
using Fetcher;
using Models;

namespace Transactions
{
    /** 
    <summary>
        ConnectionFactory
        <br />
        SQLite connection adapter
    </summary>
    */
    public class ConnectionFactory
    {
        private string dataSource = "Data source=";
        public ConnectionFactory() 
        {
            var p = Properties.GetProperties();

            if (p != null && p.Env == "dev") dataSource += "teste.db";
            else dataSource += Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
                "Teste", 
                "system.db"
            );
        }
        public ConnectionFactory(string dataSource)
        {
            this.dataSource = dataSource;
        }

        /** 
        <summary>
            getConnection
            <br />
            Provides a connection with SQLite database.
        </summary>
        */
        public SqliteConnection getConnection()
        {
            return new SqliteConnection(dataSource);
        }
    }

    public class UserTransactions
    {
        private ConnectionFactory connectionFactory;
        public UserTransactions()
        {
            connectionFactory = new ConnectionFactory();
        }

        public User getUserById(int id)
        {
            using (var conn = connectionFactory.getConnection())
            {
                conn.Open();

                var command = conn.CreateCommand();
                command.CommandText =
                @"
                    SELECT *
                    FROM users
                    WHERE id = $id
                ";

                command.Parameters.AddWithValue("$id", id);

                using (var reader = command.ExecuteReader())
                {
                    return UserFetcher.fetchOne(reader);
                }
            }
        }

        public List<User> getUsers()
        {
            using (var conn = connectionFactory.getConnection())
            {
                conn.Open();

                var command = conn.CreateCommand();
                command.CommandText =
                @"
                    SELECT *
                    FROM users
                ";

                using (var reader = command.ExecuteReader())
                {
                    return UserFetcher.fetchAll(reader);
                }
            }
        }

        public void createUser(User value)
        {
            using (var conn = connectionFactory.getConnection())
            {
                conn.Open();

                var command = conn.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO users (username, password, email)
                    VALUES ($username, $password, $email)
                ";
                command.Parameters.AddWithValue("$username", value.Username);
                command.Parameters.AddWithValue("$password", value.Password);
                command.Parameters.AddWithValue("$email", value.Email);

                command.ExecuteNonQuery();
            }
        }
    }
}