namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public DateTime CreatedAt { get; set; }

        public User() {}
        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return "Usuário " + Username + ", que mora em " + Email + ", e tem " + Password + " anos";
        }
    }

    
}

