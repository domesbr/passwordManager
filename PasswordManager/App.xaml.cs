using System;
using System.Collections.Generic;
using System.Windows;
using PasswordManager.Database.Entities;
using PasswordManager.Database.Services;
using ServiceStack;

namespace PasswordManager
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>

    public partial class App : Application
    {
        [Route("/loginData", "GET")]
        public class LoginDataGet : IReturn<List<LoginDataResponse>>{}

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

        //Define the Web Services AppHost
        public class AppHost : AppSelfHostBase
        {
            public AppHost() : base("HttpListener Self-Host", typeof(LoginDataHandler).Assembly) { }

            public override void Configure(Funq.Container container) {
                Plugins.Add(new CorsFeature(allowedHeaders: "Content-Type, Accept, Access-Control-Allow-Methods"));
            }
        }

        void App_Startup(object sender, StartupEventArgs e)
        {
            var listeningOn = "http://*:1337/";
            var appHost = new AppHost()
                .Init()
                .Start(listeningOn);

            Console.WriteLine("AppHost Created at {0}, listening on {1}", DateTime.Now, listeningOn);
        }
    }
}
