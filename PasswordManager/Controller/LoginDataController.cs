using PasswordManager.Database.Entities;
using PasswordManager.Database.Services;
using ServiceStack;
using System;
using System.Collections.Generic;

namespace PasswordManager.Controller
{
    public class LoginDataController : Service
    {
        public IEnumerable<LoginData> GetAllLoginDatas()
        {
            Console.WriteLine("GET request for all login datas");
            LoginDataService loginDataService = new LoginDataService();
            return loginDataService.findAll();
        }
    }
}
