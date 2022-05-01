using Manager;
using Models;

namespace Program
{
    class Program
    {
        private static Properties? P;
        public static void init()
        {
            P = Properties.GetProperties();
        }

        public static void Main(string[] args)
        {
            init();
            var ul = UserManager.getUsers();

            if (ul != null)
            {
                ul.ForEach(delegate(User i) {
                    Console.WriteLine(i);
                });
            }
        }
    }
}