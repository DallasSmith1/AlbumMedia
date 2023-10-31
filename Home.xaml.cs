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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlbumMedia
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public delegate void MovieClick();

        public static event MovieClick MovieClicked;

        public delegate void ProfileClick();

        public static event ProfileClick ProfileClicked;

        public delegate void SharedClick();

        public static event SharedClick SharedClicked;

        public delegate void PhotosClick();

        public static event PhotosClick PhotosClicked;

        public Home()
        {
            InitializeComponent();
        }

        private void btnMovies_Click(object sender, RoutedEventArgs e)
        {
            MovieClicked();
        }

        private void btnPhotos_Click(object sender, RoutedEventArgs e)
        {
            PhotosClicked();
        }

        private void btnShared_Click(object sender, RoutedEventArgs e)
        {
            SharedClicked();
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            ProfileClicked();
        }
    }
}
