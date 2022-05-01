using Transactions;

namespace Migrations
{
    public class User
    {
        private static string createSql = @"
        CREATE TABLE IF NOT EXISTS users (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            username TEXT NOT NULL,
            password TEXT NOT NULL,
            email TEXT NOT NULL,
            created_at DATETIME DEFAULT CURRENT_TIMESTAMP
        );
        
        CREATE UNIQUE INDEX IF NOT EXISTS user_id ON users(id);
        CREATE UNIQUE INDEX IF NOT EXISTS user_name ON users(username);
        CREATE UNIQUE INDEX IF NOT EXISTS user_email ON users(email);
        ";

        public static int Migrate()
        {
            using (var conn = new ConnectionFactory().getConnection())
            {
                conn.Open();

                var command = conn.CreateCommand();

                command.CommandText = createSql;

                return command.ExecuteNonQuery();
            }
        }
    }

    public class Migrations
    {
        public static void Migrate()
        {
            Console.WriteLine(User.Migrate());
        }
    }
}