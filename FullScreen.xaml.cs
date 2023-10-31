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

namespace AlbumMedia
{
    /// <summary>
    /// Interaction logic for FullScreen.xaml
    /// </summary>
    public partial class FullScreen : Window
    {
        public delegate void CloseMovie();

        public static event CloseMovie ClosedMovie;

        public FullScreen(MoviePlayer movie)
        {
            InitializeComponent();

            MoviePlayer.Hidden += MoviePlayer_Hidden;
            MoviePlayer.ClosedMovie += MoviePlayer_ClosedMovie;
            MoviePlayer.Windowed += MoviePlayer_Windowed;
            MoviePlayer.FullScreened += MoviePlayer_FullScreened;
            movie.HorizontalAlignment = HorizontalAlignment.Center;
            movie.VerticalAlignment = VerticalAlignment;
            frmMain.NavigationService.Navigate(movie);

            this.Icon = movie.currentMovie.GetPosterBitMap();
            this.Title = movie.currentMovie.Title;

            currentPlayer = movie;
        }

        MoviePlayer currentPlayer;

        private void MoviePlayer_Hidden()
        {
            Cursor = Cursors.None;
        }

        private void MoviePlayer_FullScreened()
        {
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;
        }

        private void MoviePlayer_Windowed()
        {
            this.WindowState = WindowState.Normal;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
        }

        private void MoviePlayer_ClosedMovie()
        {
            ClosedMovie();
            this.Close();
        }

        private void HasClosed(object sender, EventArgs e)
        {
            ClosedMovie();
        }

        private void Mouse_Enter(object sender, MouseEventArgs e)
        {
            MoviePlayer player = (MoviePlayer)frmMain.NavigationService.Content;
            player.ShowUI();
            Cursor = Cursors.Arrow;
        }

        private void Mouse_LEave(object sender, MouseEventArgs e)
        {
            MoviePlayer player = (MoviePlayer)frmMain.NavigationService.Content;
            player.HideUI();
        }

        /// <summary>
        /// when a key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyDown_Pressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) { currentPlayer.Pause_Playe_Movie(); }
            else if (e.Key == Key.Right) { currentPlayer.Forward();  }
            else if (e.Key == Key.Left) { currentPlayer.Rewind(); }
            else if (e.Key == Key.Up) { currentPlayer.VolumeUp(); }
            else if (e.Key == Key.Down) { currentPlayer.VolumeDown(); }
        }
    }
}
