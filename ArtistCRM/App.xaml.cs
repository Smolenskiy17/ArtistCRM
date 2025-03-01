using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ArtistCRM.Model;
using ArtistCRM.ModelHome;

namespace ArtistCRM
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ArtistCRMEntities context = new ArtistCRMEntities();
        public static ArtistCRMHomeEntities context2 = new ArtistCRMHomeEntities();
    }
}
