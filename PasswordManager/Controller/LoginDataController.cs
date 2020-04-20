using PasswordManager.Database.Entities;
using PasswordManager.Database.Services;
using ServiceStack;
using System;
using System.Collections.Generic;

namespace PasswordManager.Controller
{
    public class LoginDataController
    {
        [Route("/loginData", "GET")]
        public class LoginDataGet : IReturn<List<LoginDataResponse>> { }

        [Route("/loginData", "POST")]
        public class LoginDataPost : IReturn<LoginDataResponse>
        {
            public string Url { get; set; }
        }

        public class LoginDataResponse
        {
            public LoginData Result { get; set; }
        }

        public class LoginDataHandler : Service, IGet<LoginDataGet>, IPost<LoginDataPost>
        {
            public object Get(LoginDataGet request)
            {
                LoginDataService loginDataService = new LoginDataService();
                return loginDataService.findAll().Map(loginData => new LoginDataResponse { Result = loginData });
            }

            public object Post(LoginDataPost request)
            {
                Console.WriteLine("POST request for loginData of URL: " + request.Url);
                LoginDataService loginDataService = new LoginDataService();
                return new LoginDataResponse { Result = loginDataService.findByUrl(request.Url) };
            }
        }
    }
}
