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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtRegPassword.Password;

            using (var context = new ArtistCRMHomeEntities())
            {
                var existingUser = context.User.Any(u => u.Email == email);

                if (!existingUser)
                {
                    var newUser = new User
                    {
                        Email = email,
                        Password = password,
                        Role = "User"
                    };

                    context.User.Add(newUser);
                    context.SaveChanges();

                    MessageBox.Show("Регистрация успешна! Теперь вы можете войти.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь с таким именем уже существует.");
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
