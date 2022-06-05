using EF_Demo.DB;
using Microsoft.EntityFrameworkCore;

namespace EF_Demo.App
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var db = new DataBase();
            AddUsers(db);
            PrintUsers(db.Users);
            Console.WriteLine();

            var user = db.Users.First(u => u.Id == 4);
            db.Users.Remove(user);
            //db.Users.Remove(db.Users.First(u => u.Id == 4));
            db.SaveChanges();
            PrintUsers(db.Users);
            Console.WriteLine();

            user = db.Users.First(u => u.FirstName == "User 2");
            user.Age = 30;
            db.SaveChanges();
            PrintUsers(db.Users);
        }

        private static void PrintUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"#{user.Id}: {user.LastName} {user.FirstName}, {user.Age}");
            }
        }

        private static void AddUsers(DataBase db)
        {
            db.Users.AddRange(
                new User("User 1", "Users", 20),
                new User("User 2", "Users", 20),
                new User("User 3", "Users", 20),
                new User("User 4", "Users", 20),
                new User("User 5", "Users", 20),
                new User("User 6", "Users", 20)
            );
            db.SaveChanges();
        }
    }
}