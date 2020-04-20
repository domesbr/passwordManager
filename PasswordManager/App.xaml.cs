using System;
using System.Collections.Generic;
using System.Windows;
using PasswordManager.Database.Entities;
using PasswordManager.Database.Services;
using ServiceStack;
using static PasswordManager.Controller.LoginDataController;

namespace PasswordManager
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>

    public partial class App : Application
    {
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
