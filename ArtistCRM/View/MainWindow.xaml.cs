using ArtistCRM.ModelHome;
using ArtistCRM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Collections.Specialized.BitVector32;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;

namespace ArtistCRM.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadTracks();
            LoadStatistics();
        }

        private void OpenProfile_Click(object sender, RoutedEventArgs e)
        {
            int userId = 1;
            ProfileWindow profileWindow = new ProfileWindow(userId);
            profileWindow.ShowDialog();
        }

        private void OpenLoginWindow_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void OpenRegistrationWindow_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void LoadTracks()
        {
            TracksLv.Items.Clear();

            using (var context2 = new ArtistCRMHomeEntities())
            {
                var tracks = context2.Track.ToList();

                foreach (var track in tracks)
                {
                    TracksLv.Items.Add(new
                    {
                        track.Title,
                        track.Artist,
                        track.Duration,
                        track.ReleaseDate,
                        track.Genre
                    });
                }
            }
        }

        private void LoadStatistics()
        {
            StatisticsLv.Items.Clear();

            using (var context2 = new ArtistCRMHomeEntities())
            {
                var statistics = context2.TrackStatistics
                                       .Include(stat => stat.Track)
                                       .ToList();

                foreach (var stat in statistics)
                {
                    StatisticsLv.Items.Add(new
                    {
                        stat.Track.Title,
                        stat.Listens,
                        stat.Likes
                    });
                }
            }
        }

        private void ExitApplication_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
