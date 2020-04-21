using MySql.Data.MySqlClient;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PasswordManager.Database.Services
{
    class UserService
    {
        public User saveNewUser(User user)
        {
            string connectionString = "server=localhost;port=3306;database=password_manager;uid=application;password=pwdManager2020";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    using (PwdManagerDbContext context = new PwdManagerDbContext(connection, false))
                    {
                        user.Password = Encryption.Encryption.Encrypt(user.Password);
                        context.Database.ExecuteSqlCommand("DELETE FROM user");
                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                    return user;
                }
                catch
                {
                    throw;
                }
            }
        }

        public User loginUser(string password)
        {
            string connectionString = "server=localhost;port=3306;database=password_manager;uid=application;password=pwdManager2020";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    using (PwdManagerDbContext context = new PwdManagerDbContext(connection, false))
                    {
                        User foundUser = context.Users.Where(user => user.Password == password).FirstOrDefault();
                        return foundUser;
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
