using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using ArtistCRM.Model;
using ArtistCRM.ModelHome;

namespace ArtistCRM.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            using (var context2 = new ArtistCRMHomeEntities())
            {
                var user = context2.User.FirstOrDefault(u =>
                    u.Email == username &&
                    u.Password == password);

                if (user != null)
                {
                    MessageBox.Show("Успешная авторизация!");
                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неправильное имя пользователя или пароль.");
                }
            }
        }
        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }
    }
}
