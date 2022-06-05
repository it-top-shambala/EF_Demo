﻿using EF_Demo.DB;

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

            var users = db.Users;
            var contacts = db.Contacts;
            var res1 = users.First(u => u.FirstName == "User 2");
            var res2 = (from user1 in users
                where user1.FirstName == "User 2"
                select user1.LastName).First();
            var res3 = users.Where(u => u.FirstName == "User 2").Select(u => u.LastName).First();
            Console.WriteLine(res1);
            Console.WriteLine(res2);
            Console.WriteLine(res3);

            var res5 = users.Join(contacts, 
                u => u.Id, 
                c => c.UserId, 
                (u, c) => new {u.FirstName, u.LastName, c.Type, c.Content});
            foreach (var u in res5)
            {
                Console.WriteLine($"{u.LastName} {u.FirstName} : {u.Type} {u.Content}");
            }

            var res6 = from user2 in users
                join contact in contacts on user2.Id equals contact.UserId
                select new { user2.FirstName, user2.LastName, contact.Type, contact.Content };
            foreach (var u in res6)
            {
                Console.WriteLine($"{u.LastName} {u.FirstName} : {u.Type} {u.Content}");
            }
        }

        private static void PrintUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"#{user.Id}: {user.LastName} {user.FirstName}, {user.Age}");
                if (user.Contacts is null) continue;
                foreach (var contact in user.Contacts)
                {
                    Console.WriteLine($"{contact.Type} -> {contact.Content}: {contact.User}");
                }
            }
        }

        private static void AddUsers(DataBase db)
        {
            var user1 = new User("User 1", "Users", 20);
            var user2 = new User("User 2", "Users", 20);
            var user3 = new User("User 3", "Users", 20);
            var user4 = new User("User 4", "Users", 20);
            var user5 = new User("User 5", "Users", 20);
            db.Users.AddRange(user1, user2, user3, user4, user5);

            var contact1 = new Contact("phone", "+79042144491", user1);
            var contact2 = new Contact("phone", "2575755", user1);
            var contact3 = new Contact("address", "Voronezh", user3);
            db.Contacts.AddRange(contact1, contact2, contact3);
            
            db.SaveChanges();
        }
    }
}