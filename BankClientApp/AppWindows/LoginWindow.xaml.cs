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
using BankClientApp;

namespace WpfApp1.AppWindows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginWin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.IsEnabled = true;
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            string username = Username_TextBox.Text;
            string password = Password_PasswordBox.Password;
            
            ((MainWindow)this.Owner).GetLoginData(username, password);
            this.Close();
        }

        private void ForgottenPasswd_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Forgotten Password button clicked!");
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Register button clicked!");
        }
    }
}
