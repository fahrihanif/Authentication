using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authentication
{
    class Auth
    {
        public bool Authentication(List<User> listUser, string namaUser, string kataSandi)
        {
            bool userAuth = false;

            for (int a = 0; a < listUser.Count; a++)
            {
                if (namaUser == listUser[a].UserName && kataSandi == listUser[a].Password)
                {
                    userAuth = true;
                    break;
                }
                continue;
            }

            Console.Write("MESSAGE : ");
            if (userAuth == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string NameAuth(string nama)
        {
            bool check = true;
            do
            {
                if (nama.Length < 2)
                {
                    Console.WriteLine("\nName has to be at least consisting 2 characters or more.");
                    Console.Write("Input : "); nama = Console.ReadLine();
                    check = false;
                    return nama;
                }
                else
                {
                    check = true;
                    return nama;
                }
            } while (check);
            
            
        }

        public string PasswordAuth(string kataSandi)
        {
            bool check = true;
            do
            {
                if (kataSandi.Length > 7 && kataSandi.Any(char.IsUpper) && kataSandi.Any(char.IsLower) && kataSandi.Any(char.IsNumber))
                {
                    check = false;
                }
                else
                {
                    Console.WriteLine("\nPassword must have at least 8 characters\n with at least one Capital letter, at least one lower case letter and at least one number.");
                    Console.Write("Password: "); kataSandi = Console.ReadLine();
                    check = true;
                }
            } while (check);

            return kataSandi;
        }

        public string UserAuth(string userName)
        {
            return userName;
        }
    }
}
