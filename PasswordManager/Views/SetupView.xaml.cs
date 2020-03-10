using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;


namespace PasswordManager.Views
{
    /// <summary>
    /// Interaktionslogik für SetupView.xaml
    /// </summary>
    public partial class SetupView : Window
    {
        public SetupView()
        {
            InitializeComponent();
        }
               
        private void txtBox_Email_LostFocus(object sender, RoutedEventArgs e)
        {
            EmailPwdPage.CanSelectNextPage = IsEmailAddressAndPasswordValid(txtBox_Email.Text, pwdBox_Password.Password, pwdBox_PasswordConfirm.Password);
        }
        private void pwdBox_Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            EmailPwdPage.CanSelectNextPage = IsEmailAddressAndPasswordValid(txtBox_Email.Text, pwdBox_Password.Password, pwdBox_PasswordConfirm.Password);
        }
        private void pwdBox_PasswordConfirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            EmailPwdPage.CanSelectNextPage = IsEmailAddressAndPasswordValid(txtBox_Email.Text, pwdBox_Password.Password, pwdBox_PasswordConfirm.Password);
        }


        private Boolean IsEmailAddressAndPasswordValid(string email, string password, string passwordconfirm)
        {
            Boolean isValid = false;

            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordconfirm) || string.IsNullOrEmpty(email))
            {
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                isValid = addr.Address == email;
            }
            catch
            {
                return false;
            }
            
            isValid = password == passwordconfirm;

            return isValid;
        }
    }
}
