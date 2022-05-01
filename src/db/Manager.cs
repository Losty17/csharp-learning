using Transactions;
using Models;

namespace Manager
{
    public class UserManager
    {
        public static User? getUserById(int id)
        {
            try
            {
                return new UserTransactions().getUserById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static List<User>? getUsers()
        {
            try
            {
                return new UserTransactions().getUsers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static void createUser(User value)
        {
            try
            {
                new UserTransactions().createUser(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}