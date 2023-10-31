using AlbumMedia.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlbumMedia
{
    /// <summary>
    /// Interaction logic for MovieAdd.xaml
    /// </summary>
    public partial class MovieAdd : Page
    {
        public delegate void Cancel();

        public static event Cancel Canceled;

        public MovieAdd()
        {
            InitializeComponent();
            AllowDrop = true;
            this.Visibility = Visibility.Collapsed;
            this.Visibility = Visibility.Visible;
        }

        string MoviePath;
        string PosterPath;
        int CurrentPage = 0;

        #region Movie Upload
        /// <summary>
        /// when file is dragged over rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Drag_Over(object sender, System.Windows.DragEventArgs e)
        {
            rctSelectFile.Opacity = 0.5;
            lblUpload.Opacity = 0.5;
        }

        /// <summary>
        /// when stopped dragging over rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Drag_Leave(object sender, System.Windows.DragEventArgs e)
        {
            rctSelectFile.Opacity = 1;
            lblUpload.Opacity = 1;
        }

        /// <summary>
        /// When a file is dropped on the rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void File_Dropped(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop, true))
            {
                string[] droppedFilePaths = e.Data.GetData(System.Windows.DataFormats.FileDrop, true) as string[];
                try
                {
                    mdeFilePreview.Source = new Uri(droppedFilePaths[0], UriKind.Absolute);
                    MoviePath = droppedFilePaths[0];
                    string[] file = droppedFilePaths[0].Split('\\');
                    lblFile.Content = file[file.Length - 1];
                    btnNext.Visibility = Visibility.Visible;
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// when mouve upload enters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Enter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            rctSelectFile.Opacity = 0.5;
            lblUpload.Opacity = 0.5;
        }

        /// <summary>
        /// when movie upload leaves
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Leave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            rctSelectFile.Opacity = 1;
            lblUpload.Opacity = 1;
        }

        /// <summary>
        /// when movie upload is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Down(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Movie File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = ".mp4",
                Filter = "All Videos Files |*.dat; *.wmv; *.3g2; *.3gp; *.3gp2; *.3gpp; *.amv; *.asf;  *.avi; *.bin; *.cue; *.divx; *.dv; *.flv; *.gxf; *.iso; *.m1v; *.m2v; *.m2t; *.m2ts; *.m4v; " +
                  " *.mkv; *.mov; *.mp2; *.mp2v; *.mp4; *.mp4v; *.mpa; *.mpe; *.mpeg; *.mpeg1; *.mpeg2; *.mpeg4; *.mpg; *.mpv2; *.mts; *.nsv; *.nuv; *.ogg; *.ogm; *.ogv; *.ogx; *.ps; *.rec; *.rm; *.rmvb; *.tod; *.ts; *.tts; *.vob; *.vro; *.webm",
                FilterIndex = 25,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if ((bool)openFileDialog1.ShowDialog())
            {
                mdeFilePreview.Source = new Uri(openFileDialog1.FileName, UriKind.Absolute);
                MoviePath = openFileDialog1.FileName;
                string[] file = openFileDialog1.FileName.Split('\\');
                lblFile.Content = file[file.Length - 1];
                btnNext.Visibility = Visibility.Visible;
            }
        }
        #endregion

        #region Poster Upload
        private void Drag_Leave2(object sender, System.Windows.DragEventArgs e)
        {
            rctSelectFile2.Opacity = 1;
            lblUpload2.Opacity = 1;
        }

        private void Drag_Over2(object sender, System.Windows.DragEventArgs e)
        {
            rctSelectFile2.Opacity = 0.5;
            lblUpload2.Opacity = 0.5;
        }

        private void File_Dropped2(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop, true))
            {
                string[] droppedFilePaths = e.Data.GetData(System.Windows.DataFormats.FileDrop, true) as string[];
                try
                {
                    imgPosterPreview.Source = new BitmapImage(new Uri(droppedFilePaths[0], UriKind.Absolute));
                    PosterPath = droppedFilePaths[0];
                    string[] file = droppedFilePaths[0].Split('\\');
                    lblFile2.Content = file[file.Length - 1];
                    btnNext1.Visibility = Visibility.Visible;
                }
                catch
                {

                }
            }
        }

        private void Mouse_Enter2(object sender, System.Windows.Input.MouseEventArgs e)
        {
            rctSelectFile2.Opacity = 0.5;
            lblUpload2.Opacity = 0.5;
        }

        private void Mouse_Leave2(object sender, System.Windows.Input.MouseEventArgs e)
        {
            rctSelectFile2.Opacity = 1;
            lblUpload2.Opacity = 1;
        }

        private void Mouse_Down2(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Movie Poster",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = ".png",
                Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif",
                FilterIndex = 25,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if ((bool)openFileDialog1.ShowDialog())
            {
                imgPosterPreview.Source = new BitmapImage(new Uri(openFileDialog1.FileName, UriKind.Absolute));
                PosterPath = openFileDialog1.FileName;
                string[] file = openFileDialog1.FileName.Split('\\');
                lblFile2.Content = file[file.Length - 1];
                btnNext1.Visibility = Visibility.Visible;
            }
        }
        #endregion

        /// <summary>
        /// cancel button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Canceled();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage == 0)
            {
                cvsInfo1.Visibility = Visibility.Hidden;
                cvsInfo2.Visibility = Visibility.Visible;
                CurrentPage = 1;
            }
            else if (CurrentPage == 1)
            {
                cvsInfo2.Visibility = Visibility.Hidden;
                cvsInfo3.Visibility = Visibility.Visible;
                CurrentPage = 2;
            }
            else if (CurrentPage == 2)
            {
                cvsInfo3.Visibility = Visibility.Hidden;
                cvsInfo4.Visibility = Visibility.Visible;
                CurrentPage = 3;

                lblTitle.Content = tbxTitle.Text;
                lblReleaseYear.Content = tbxReleaseYear.Text;
                lblDescription.Text = tbxDescription.Text;
                lblCompany.Content = tbxCompany.Text;

                string genre = "";

                if (cbxAction.IsChecked == true)
                {
                    genre += "Action, ";
                }
                if (cbxAdult.IsChecked == true)
                {
                    genre += "Adult, ";
                }
                if (cbxAdventure.IsChecked == true)
                {
                    genre += "Adventure, ";
                }
                if (cbxAnimated.IsChecked == true)
                {
                    genre += "Animated, ";
                }
                if (cbxComedy.IsChecked == true)
                {
                    genre += "Comedy, ";
                }
                if (cbxDisney.IsChecked == true)
                {
                    genre += "Disney, ";
                }
                if (cbxDrama.IsChecked == true)
                {
                    genre += "Drama, ";
                }
                if (cbxHorror.IsChecked == true)
                {
                    genre += "Horror, ";
                }
                if (cbxJurassic.IsChecked == true)
                {
                    genre += "Jurassic, ";
                }
                if (cbxKids.IsChecked == true)
                {
                    genre += "Kids, ";
                }
                if (cbxRomance.IsChecked == true)
                {
                    genre += "Romance, ";
                }
                if (cbxScienceFiction.IsChecked == true)
                {
                    genre += "Sci-Fi, ";
                }
                if (cbxStarWars.IsChecked == true)
                {
                    genre += "Star Wars, ";
                }
                if (cbxSuperHero.IsChecked == true)
                {
                    genre += "Super Hero, ";
                }
                if (cbxThriller.IsChecked == true)
                {
                    genre += "Thriller, ";
                }
                lblGenres.Content = genre;

                mdeMovieEnd.Source = mdeFilePreview.Source;
                imgPosterEnd.Source = imgPosterPreview.Source;
            }
            else if (CurrentPage == 3)
            {
                try
                {
                    File.Copy(MoviePath, Properties.Settings.Default.MOVIEFOLDER + "\\" + lblFile.Content.ToString());
                    File.Copy(PosterPath, Properties.Settings.Default.POSTERFOLDER + "\\" + lblFile2.Content.ToString());
                    Movie newMovie = new Movie(lblTitle.Content.ToString(), lblDescription.Text, lblFile.Content.ToString(), lblFile2.Content.ToString(), lblReleaseYear.Content.ToString(), lblCompany.Content.ToString());
                    MovieGenre newGenre = new MovieGenre(lblTitle.Content.ToString(), (bool)cbxHorror.IsChecked, (bool)cbxDisney.IsChecked, (bool)cbxComedy.IsChecked, (bool)cbxAnimated.IsChecked, (bool)cbxScienceFiction.IsChecked, (bool)cbxAction.IsChecked, (bool)cbxAdventure.IsChecked, (bool)cbxSuperHero.IsChecked, (bool)cbxStarWars.IsChecked, (bool)cbxJurassic.IsChecked, (bool)cbxKids.IsChecked, (bool)cbxAdult.IsChecked, (bool)cbxRomance.IsChecked, (bool)cbxDrama.IsChecked, (bool)cbxThriller.IsChecked);
                    MyMongoDB.AddMovie(newMovie, newGenre);
                }
                catch { }

                Canceled();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage == 1)
            {
                cvsInfo2.Visibility = Visibility.Hidden;
                cvsInfo1.Visibility = Visibility.Visible;
                CurrentPage = 0;
            }
            else if (CurrentPage == 2)
            {
                cvsInfo3.Visibility = Visibility.Hidden;
                cvsInfo2.Visibility = Visibility.Visible;
                CurrentPage = 1;
            }
            else if (CurrentPage == 3)
            {
                cvsInfo4.Visibility = Visibility.Hidden;
                cvsInfo3.Visibility = Visibility.Visible;
                CurrentPage = 2;
            }
        }

        
    }
}
