﻿using MySql.Data.MySqlClient;
using PasswordManager.Database.Entities;
using PasswordManager.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PasswordManager.Database.Services
{
    class LoginDataService
    {

        public List<LoginData> findAllByUser(User user)
        {
            string connectionString = "server=localhost;port=3306;database=password_manager;uid=application;password=pwdManager2020";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    using (PwdManagerDbContext context = new PwdManagerDbContext(connection, false))
                    {
                        return context.LoginDatas.Where(data => data.UserId == user.Id).ToList();
                    }
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<LoginData> findAll()
        {
            string connectionString = "server=localhost;port=3306;database=password_manager;uid=application;password=pwdManager2020";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    using (PwdManagerDbContext context = new PwdManagerDbContext(connection, false))
                    {
                        return context.LoginDatas.ToList();
                    }
                }
                catch
                {
                    throw;
                }
            }
        }

        public LoginData saveNewLoginData(LoginData loginData)
        {
            string connectionString = "server=localhost;port=3306;database=password_manager;uid=application;password=pwdManager2020";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    using (PwdManagerDbContext context = new PwdManagerDbContext(connection, false))
                    {
                        loginData.Password = Encryption.Encryption.Encrypt(loginData.Password);
                        context.LoginDatas.Add(loginData);
                        context.SaveChanges();
                    }
                    return loginData;
                }
                catch
                {
                    throw;
                }
            }
        }

        public void saveChangedLoginData(LoginData loginData)
        {
            string connectionString = "server=localhost;port=3306;database=password_manager;uid=application;password=pwdManager2020";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    using (PwdManagerDbContext context = new PwdManagerDbContext(connection, false))
                    {
                        context.LoginDatas.Find(loginData.Id).Link = loginData.Link;
                        context.LoginDatas.Find(loginData.Id).Password = Encryption.Encryption.Encrypt(loginData.Password);
                        context.LoginDatas.Find(loginData.Id).Username = loginData.Username;
                        context.SaveChanges();
                    }
                }
                catch
                {
                    throw;
                }
            }
        }

        public LoginData findByUrl(string url)
        {
            string connectionString = "server=localhost;port=3306;database=password_manager;uid=application;password=pwdManager2020";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    using (PwdManagerDbContext context = new PwdManagerDbContext(connection, false))
                    {
                        return context.LoginDatas.Where(data => url.Contains(data.Link) || data.Link.Contains(url)).First();
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        public void deleteLoginData(int id)
        {
            string connectionString = "server=localhost;port=3306;database=password_manager;uid=application;password=pwdManager2020";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    using (PwdManagerDbContext context = new PwdManagerDbContext(connection, false))
                    {
                        List<LoginData> a = context.LoginDatas.ToList();
                        context.LoginDatas.Remove(context.LoginDatas.Find(id));
                        context.SaveChanges();
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
