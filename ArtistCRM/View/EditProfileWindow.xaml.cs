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
using ArtistCRM.Model;
using ArtistCRM.ModelHome;

namespace ArtistCRM.View
{
    /// <summary>
    /// Логика взаимодействия для EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        private readonly int _userId;
        private readonly ArtistCRMHomeEntities _context2;

        public EditProfileWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _context2 = new ArtistCRMHomeEntities();
            LoadProfile(userId);
        }

        private void LoadProfile(int userId)
        {
            var profile = _context2.Profile.SingleOrDefault(p => p.UserID == userId);

            if (profile != null)
            {
                NicknameTb.Text = profile.Nickname;
                FirstNameTb.Text = profile.FirstName;
                BiographyTb.Text = profile.Biography;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var profile = _context2.Profile.SingleOrDefault(p => p.UserID == _userId);

            if (profile != null)
            {
                profile.Nickname = NicknameTb.Text;
                profile.FirstName = FirstNameTb.Text;
                profile.Biography = BiographyTb.Text;

                try
                {
                    _context2.SaveChanges();
                    MessageBox.Show("Профиль успешно обновлён!");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении профиля: {ex.Message}");
                }

            }
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
