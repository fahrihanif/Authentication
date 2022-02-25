using System;
using System.Collections.Generic;

namespace Authentication
{
    class Crud
    {
        public string Create(List<User> users, User user)
        {
            Auth auth = new Auth();
            if (auth.UserAuth(users, user.UserName) == false)
            {
                users.Add(user);
                return Success("Created");
            }
            else
            {
                return Success("Create", "Username");
            }
        }

        public string Edit(List<User> users, User user, int id)
        {
             users[id - 1].FirstName = user.FirstName;
             users[id - 1].LastName = user.LastName;
             users[id - 1].UserName = $"{user.FirstName.Substring(0, 2)}{user.LastName.Substring(0, 2)}";
             users[id - 1].Password = user.Password;
             return Success("Edited");
        }
        public string Delete(List<User> users, int id)
        {
            if (id <= users.Count)
            {
                users.RemoveAt(id - 1);
                return Success("Deleted");
            }
            else
            {
                return NotFound();
            }
        }

        public void View(List<User> Users)
        {
            int i = 0;

            foreach (User n in Users)
            {
                i++;
                Console.WriteLine("========================");
                Console.WriteLine($"ID\t: {i}");
                Console.WriteLine($"Name\t: {n.FirstName} {n.LastName}");
                Console.WriteLine($"Username: {n.UserName}");
                Console.WriteLine($"Password: {n.Password}");
                Console.WriteLine("========================");
            }
        }

        private string NotFound()
        {
            return "User Not Found!!!";
        }
        private string Success(string value)
        {
            return $"User Success to {value}!!!";
        }
        private string Success(string value, string error)
        {
            return $"{value} failure,{error} already exists!!!";
        }
    }
}
