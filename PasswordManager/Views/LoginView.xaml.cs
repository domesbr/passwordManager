using MySql.Data.Entity;
using PasswordManager.Database.Entities;
using PasswordManager.Database.Services;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;

namespace PasswordManager
{
    /// <summary>
    /// Interaktionslogik für LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }

        private void SetupLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //TODO Open Setup Label
        }
    }
}
