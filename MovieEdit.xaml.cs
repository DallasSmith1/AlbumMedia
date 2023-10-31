using AlbumMedia.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MovieEdit.xaml
    /// </summary>
    public partial class MovieEdit : Page
    {
        public delegate void GoBack();

        public static event GoBack _GoBack;

        public MovieEdit(Movie currentMovie, MovieGenre currentMovieGenre)
        {
            InitializeComponent();
            this.currentMovie = currentMovie;
            this.currentMovieGenre = currentMovieGenre;
            this.originalTitle = currentMovie.Title;
            this.originalFile = currentMovie.Poster;
            DisplayValues();
        }


        Movie currentMovie;
        MovieGenre currentMovieGenre;
        string originalTitle;
        string originalFile;
        string newFilePath = string.Empty;

        /// <summary>
        /// updates the database with the new values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            currentMovie.Title = tbxTitle.Text;
            currentMovie.ReleaseYear = tbxReleaseYear.Text;
            currentMovie.Company = tbxCompany.Text;
            currentMovie.Description = tbxDescription.Text;

            currentMovieGenre.MovieTitle = tbxTitle.Text;
            currentMovieGenre.Horror = (bool)cbxHorror.IsChecked;
            currentMovieGenre.Disney = (bool)cbxDisney.IsChecked;
            currentMovieGenre.Comedy = (bool)cbxComedy.IsChecked;
            currentMovieGenre.Animated = (bool)cbxAnimated.IsChecked;
            currentMovieGenre.ScienceFiction = (bool)cbxScienceFiction.IsChecked;
            currentMovieGenre.Action = (bool)cbxAction.IsChecked;
            currentMovieGenre.Advanture = (bool)cbxAdventure.IsChecked;
            currentMovieGenre.SuperHero = (bool)cbxSuperHero.IsChecked;
            currentMovieGenre.Jurassic = (bool) cbxJurassic.IsChecked;
            currentMovieGenre.Kids = (bool)cbxKids.IsChecked;
            currentMovieGenre.Adult = (bool)cbxAdult.IsChecked;
            currentMovieGenre.Romance = (bool)cbxRomance.IsChecked;
            currentMovieGenre.Drama = (bool)cbxDrama.IsChecked;
            currentMovieGenre.Thriller = (bool)cbxThriller.IsChecked;
            try
            {
                if (newFilePath != string.Empty)
                {
                    File.Delete(Properties.Settings.Default.POSTERFOLDER + "\\" + originalFile);

                    string[] newFileName = newFilePath.Split('\\');

                    File.Copy(newFilePath, Properties.Settings.Default.POSTERFOLDER + "\\" + newFileName[newFileName.Length-1]);
                }

                MyMongoDB.UpdateMovieInfo(currentMovieGenre, currentMovie, originalTitle);
            }
            catch { }
            _GoBack();
        }

        /// <summary>
        /// displays the info into the fields
        /// </summary>
        private void DisplayValues()
        {
            tbxTitle.Text = currentMovie.Title;
            tbxReleaseYear.Text = currentMovie.ReleaseYear;
            tbxDescription.Text = currentMovie.Description;
            tbxCompany.Text = currentMovie.Company;

            cbxThriller.IsChecked = currentMovieGenre.Thriller;
            cbxSuperHero.IsChecked = currentMovieGenre.SuperHero;
            cbxStarWars.IsChecked = currentMovieGenre.StarWars;
            cbxScienceFiction.IsChecked = currentMovieGenre.ScienceFiction;
            cbxRomance.IsChecked = currentMovieGenre.Romance;
            cbxKids.IsChecked = currentMovieGenre.Kids;
            cbxJurassic.IsChecked = currentMovieGenre.Jurassic;
            cbxHorror.IsChecked = currentMovieGenre.Horror;
            cbxDrama.IsChecked = currentMovieGenre.Drama;
            cbxDisney.IsChecked = currentMovieGenre.Disney;
            cbxComedy.IsChecked = currentMovieGenre.Comedy;
            cbxAnimated.IsChecked = currentMovieGenre.Animated;
            cbxAdult.IsChecked = currentMovieGenre.Adult;
            cbxAction.IsChecked = currentMovieGenre.Action;
            cbxAdventure.IsChecked = currentMovieGenre.Advanture;
        }

        /// <summary>
        /// cancel any changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _GoBack();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MyMongoDB.DeleteMovie(currentMovie);

            File.Delete(Properties.Settings.Default.MOVIEFOLDER + "\\" + currentMovie.File);
            File.Delete(Properties.Settings.Default.POSTERFOLDER + "\\" + currentMovie.Poster);
            _GoBack();
        }

    }
}
