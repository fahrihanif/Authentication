using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication
{
    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User(string firstName, string lastName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = $"{firstName.Substring(0, 2)}{lastName.Substring(0, 2)}";
            Password = password;
        }

        public User()
        {
        }
    }

}
