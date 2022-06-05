namespace EF_Demo.App
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var db = new DataBase();

            db.Users.Add(new()
            {
                FirstName = "Andrey",
                LastName = "Starinin",
                Age = 36
            });
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
    }
}