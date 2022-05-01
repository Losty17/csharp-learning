using Manager;
using Models;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            // for (int i = 0; i < 9; i++)
            // {
            //     var user = new User("Username" + i, "Email" + i, "Password");
            //     UserManager.createUser(user);
            //     Console.WriteLine("created user " + (i + 1));
            // }

            var ul = UserManager.getUsers();

            if (ul != null)
            {
                ul.ForEach(delegate(User i) {
                    Console.WriteLine(i.Id);
                });
            }
        }
    }
}