using ArtistCRM.ModelHome;
using ArtistCRM.Model;
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
using ArtistCRM.AppData;
using System.Data.Entity;
using System.Windows.Navigation;

namespace ArtistCRM.View
{
    /// <summary>
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        private readonly int _userId;

        public ProfileWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadProfile(userId);
        }

        private void LoadProfile(int userId)
        {
            using (var context2 = new ArtistCRMHomeEntities())
            {
                var profile = context2.Profile.SingleOrDefault(p => p.UserID == userId);

                if (profile != null)
                {
                    NicknameTb.Text = profile.Nickname;
                    FirstNameTb.Text = profile.FirstName;
                    BiographyTb.Text = profile.Biography;
                }
            }
        }
        private void StaticsBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
