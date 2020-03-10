using MySql.Data.Entity;
using PasswordManager.Database.Services;
using System;
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

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //TODO
        }
    }
}
