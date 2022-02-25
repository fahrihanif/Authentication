using System;
using System.Collections.Generic;
using System.Linq;

namespace Authentication
{
    class MainMenu
    {
        Crud crud = new Crud();
        List<User> listUsers = new List<User>();
        public void App()
        {
            Console.Clear();
            Console.WriteLine("==BASIC AUTHENTICATION==");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Login User");
            Console.WriteLine("5. Exit");
            Console.Write("Input : ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Create(listUsers);
                    break;
                case 2:
                    ShowUser(listUsers);
                    break;
                case 3:
                    Search(listUsers);
                    break;
                case 4:
                    Login(listUsers);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    App();
                    break;
            }
        }

        private void Search(List<User> listUsers)
        {
            List<User> searchedList = new List<User>();

            Console.Clear();
            Console.WriteLine("==Cari Akun==");
            Console.Write("Masukan Nama : ");
            string name = Console.ReadLine();

            searchedList = listUsers.Where(i => i.FirstName.ToLower().Contains(name.ToLower()) || i.LastName.ToLower().Contains(name.ToLower()))
                .Select(g => new User
                {
                    FirstName = g.FirstName,
                    LastName = g.LastName,
                    UserName = g.UserName,
                    Password = g.Password
                }).ToList();

            crud.View(searchedList);
            Console.ReadKey();
            App();
        }

        public void Create(List<User> listUser)
        {
            Auth auth = new Auth();
            
            Console.Clear();
            Console.Write("First Name: "); string namaDepan = auth.NameAuth(Console.ReadLine());
            Console.Write("Last Name: "); string namaAkhir = auth.NameAuth(Console.ReadLine());
            Console.Write("Password: "); string kataSandi = auth.PasswordAuth(Console.ReadLine());

            User user = new User(namaDepan, namaAkhir, kataSandi);

            Console.WriteLine(crud.Create(listUser, user));
            Console.ReadKey();
            App();
        }

        public void Login(List<User> listUser)
        {
            Auth auth = new Auth();

            Console.Clear();
            Console.WriteLine("==LOGIN==");
            Console.Write("USERNAME : "); string namaUser = Console.ReadLine();
            Console.Write("PASSWORD : "); string kataSandi = Console.ReadLine();

            if(auth.Authentication(listUser, namaUser, kataSandi))
            {
                Console.WriteLine("Login Berhasil!");
                Console.ReadKey();
                App();
            }
            else
            {
                Console.WriteLine("Username atau Password Tidak Ditemukan");
                Console.ReadKey();
                App();
            }

        }


        private void EditUser(List<User> users, User user)
        {
            bool check = false;
            do
            {
                Console.Write("Id Yang Ingin Diubah : "); int id = Convert.ToInt32(Console.ReadLine());
                if (id <= users.Count)
                {
                    Console.Write("First Name : "); user.FirstName = Console.ReadLine();
                    Console.Write("Last Name : "); user.LastName = Console.ReadLine();
                    Console.Write("Password : "); user.Password = Console.ReadLine();

                    Console.WriteLine(crud.Edit(users, user, id));
                    check = false;
                }
                else
                {
                    Console.WriteLine("User Tidak Ditemukan!!!");
                    check = true;
                }
            } while (check);
            Console.ReadKey();
            ShowUser(users);

        }
        
        private void DeleteUser(List<User> users)
        {
            Console.Write("Id Yang Ingin Dihapus : "); int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(crud.Delete(users, id));
            Console.ReadKey();
            ShowUser(users);
        }

        private void ShowUser(List<User> users)
        {
            User user = new User();

            Console.Clear();
            Console.WriteLine("==SHOW USER==");
            crud.View(users);
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Back");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    EditUser(users, user);
                    break;
                case 2:
                    DeleteUser(users);
                    break;
                case 3:
                    App();
                    break;
                default:
                    Console.WriteLine("ERROR : Input Not Valid");
                    Console.ReadKey();
                    ShowUser(users);
                    break;
            }
        }
    }
}
