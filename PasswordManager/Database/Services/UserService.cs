using MySql.Data.MySqlClient;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;

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
                        context.Set<User>().Add(user);
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
    }
}
