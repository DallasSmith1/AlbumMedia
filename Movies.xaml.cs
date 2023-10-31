using AlbumMedia.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MongoDB.Driver.WriteConcern;

namespace AlbumMedia
{
    /// <summary>
    /// Interaction logic for Movies.xaml
    /// </summary>
    public partial class Movies : Page
    {
        public delegate void SearchAllMovies();

        public static event SearchAllMovies SearchedAllMovies;

        public delegate void PlayMovie(Movie movie);

        public static event PlayMovie PlayedMovie;

        public delegate void OpenDetails(bool open);

        public static event  OpenDetails OpenedDetails;

        public Movies()
        {
            InitializeComponent();
            Startups();
        }

        #region Back Ground Workers

        #region BGW_GetAllMovies
        private void BGW_GetAllMovies_DoWork(object sender, DoWorkEventArgs e)
        {
            // Fill Kids
            List<MovieGenre> movieList = MyMongoDB.GetMovieGenreList("Kids");

            foreach (MovieGenre movie in movieList)
            {
                kids.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }

            BGW_GetAllMovies.ReportProgress(0);

            // Fill Adult
            movieList = MyMongoDB.GetMovieGenreList("Adult");

            foreach (MovieGenre movie in movieList)
            {
                adult.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }

            BGW_GetAllMovies.ReportProgress(1);

            // Fill Horror
            movieList = MyMongoDB.GetMovieGenreList("Horror");

            foreach (MovieGenre movie in movieList)
            {
                horror.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }

            BGW_GetAllMovies.ReportProgress(2);


            // Fill Disney
            movieList = MyMongoDB.GetMovieGenreList("Disney");

            foreach (MovieGenre movie in movieList)
            {
                disney.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }

            BGW_GetAllMovies.ReportProgress(3);

            // Fill Comedy
            movieList = MyMongoDB.GetMovieGenreList("Comedy");

            foreach (MovieGenre movie in movieList)
            {
                comedy.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }

            BGW_GetAllMovies.ReportProgress(4);

            // Fill Animated
            movieList = MyMongoDB.GetMovieGenreList("Animated");

            foreach (MovieGenre movie in movieList)
            {
                animated.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }

            BGW_GetAllMovies.ReportProgress(5);

            // Fill scifi
            movieList = MyMongoDB.GetMovieGenreList("ScienceFiction");

            foreach (MovieGenre movie in movieList)
            {
                sciencefiction.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }

            BGW_GetAllMovies.ReportProgress(6);

            // Fill Action
            movieList = MyMongoDB.GetMovieGenreList("Action");

            foreach (MovieGenre movie in movieList)
            {
                action.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }

            BGW_GetAllMovies.ReportProgress(7);

            // Fill Adventure
            movieList = MyMongoDB.GetMovieGenreList("Adventure");

            foreach (MovieGenre movie in movieList)
            {
                adventure.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }

            BGW_GetAllMovies.ReportProgress(8);

            // Fill Super Hero
            movieList = MyMongoDB.GetMovieGenreList("SuperHero");

            foreach (MovieGenre movie in movieList)
            {
                superhero.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }

            BGW_GetAllMovies.ReportProgress(9);

            // Fill Star Wars
            movieList = MyMongoDB.GetMovieGenreList("StarWars");

            foreach (MovieGenre movie in movieList)
            {
                starwars.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }

            BGW_GetAllMovies.ReportProgress(10);

            // Fill jurassic
            movieList = MyMongoDB.GetMovieGenreList("Jurassic");

            foreach (MovieGenre movie in movieList)
            {
                jurassic.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }

            BGW_GetAllMovies.ReportProgress(11);

            // Fill Romance
            movieList = MyMongoDB.GetMovieGenreList("Romance");

            foreach (MovieGenre movie in movieList)
            {
                romance.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }

            BGW_GetAllMovies.ReportProgress(12);

            // Fill Thriller
            movieList = MyMongoDB.GetMovieGenreList("Thriller");

            foreach (MovieGenre movie in movieList)
            {
                thriller.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }

            BGW_GetAllMovies.ReportProgress(13);

            MyMongoDB.GetAllMovies();
        }

        private void BGW_GetAllMovies_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                Kids.Children.Clear();
                
                foreach (Movie movie in kids)
                {
                    Kids.Children.Add(CreatePoster(movie, false));
                }
            }
            else if(e.ProgressPercentage == 1)
            {
                Adult.Children.Clear();

                foreach (Movie movie in adult)
                {
                    Adult.Children.Add(CreatePoster(movie, false));
                }
            }
            else if (e.ProgressPercentage == 2)
            {
                Horror.Children.Clear();

                foreach (Movie movie in horror)
                {
                    Horror.Children.Add(CreatePoster(movie, false));
                }
            }
            else if (e.ProgressPercentage == 3)
            {
                Disney.Children.Clear();

                foreach (Movie movie in disney)
                {
                    Disney.Children.Add(CreatePoster(movie, false));
                }
            }
            else if (e.ProgressPercentage == 4)
            {
                Comedy.Children.Clear();

                foreach (Movie movie in comedy)
                {
                    Comedy.Children.Add(CreatePoster(movie, false));
                }
            }
            else if (e.ProgressPercentage == 5)
            {
                Animated.Children.Clear();

                foreach (Movie movie in animated)
                {
                    Animated.Children.Add(CreatePoster(movie, false));
                }
            }
            else if (e.ProgressPercentage == 6)
            {
                scifi.Children.Clear();

                foreach (Movie movie in sciencefiction)
                {
                    scifi.Children.Add(CreatePoster(movie, false));
                }
            }
            else if (e.ProgressPercentage == 7)
            {
                Action.Children.Clear();

                foreach (Movie movie in action)
                {
                    Action.Children.Add(CreatePoster(movie, false));
                }
            }
            else if (e.ProgressPercentage == 8)
            {
                Adventure.Children.Clear();

                foreach (Movie movie in adventure)
                {
                    Adventure.Children.Add(CreatePoster(movie, false));
                }
            }
            else if (e.ProgressPercentage == 9)
            {
                SuperHero.Children.Clear();

                foreach (Movie movie in superhero)
                {
                    SuperHero.Children.Add(CreatePoster(movie, false));
                }
            }
            else if (e.ProgressPercentage == 10)
            {
                StarWars.Children.Clear();

                foreach (Movie movie in starwars)
                {
                    StarWars.Children.Add(CreatePoster(movie, false));
                }
            }
            else if (e.ProgressPercentage == 11)
            {
                Jurassic.Children.Clear();

                foreach (Movie movie in jurassic)
                {
                    Jurassic.Children.Add(CreatePoster(movie, false));
                }
            }
            else if (e.ProgressPercentage == 12)
            {
                Romance.Children.Clear();

                foreach (Movie movie in romance)
                {
                    Romance.Children.Add(CreatePoster(movie, false));
                }
            }
            else if (e.ProgressPercentage == 13)
            {
                Thriller.Children.Clear();

                foreach (Movie movie in thriller)
                {
                    Thriller.Children.Add(CreatePoster(movie, false));
                }
                imgLoading.Visibility = Visibility.Hidden;
                cvsAll.Visibility = Visibility.Visible;
            }
        }


        private void BGW_GetAllMovies_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.IsEnabled = true;
        }

        #endregion

        #region BGW_Animation
        private void BGW_Animation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableSlideButtons();
        }

        private void BGW_Animation_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (ScrollRight)
            {
                ScrollViewer.ScrollToHorizontalOffset(ScrollViewer.HorizontalOffset + e.ProgressPercentage);
            }
            else
            {
                ScrollViewer.ScrollToHorizontalOffset(ScrollViewer.HorizontalOffset - e.ProgressPercentage);
            }
        }

        private void BGW_Animation_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < ScrollOffset; i++)
            {
                Thread.Sleep(ScrollSleep);
                BGW_Animation.ReportProgress(ScrollProgress);
            }
        }
        #endregion

        #region BGW_MovieSearch
        private void BGW_MovieSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int iter = 0;
            int rowcount = 0;

            if (search.Count == 0)
            {
                lblNoneFound.Content = "No result for your search \"" + Filter + "\"";
                lblNoneFound.Visibility = Visibility.Visible;
            }
            else
            {
                foreach (Movie movie in search)
                {
                    if (iter == 0)
                    {
                        pnl1.Children.Add(CreatePoster(movie, true));
                    }
                    else if (iter == 1)
                    {
                        pnl2.Children.Add(CreatePoster(movie, true));
                    }
                    else if (iter == 2)
                    {
                        pnl3.Children.Add(CreatePoster(movie, true));
                    }
                    else if (iter == 3)
                    {
                        pnl4.Children.Add(CreatePoster(movie, true));
                    }
                    else if (iter == 4)
                    {
                        pnl5.Children.Add(CreatePoster(movie, true));
                    }
                    iter++;
                    if (iter == 5)
                    {
                        iter = 0;
                        rowcount++;
                    }
                    if (rowcount == 21)
                    {
                        break;
                    }
                }
            }
            imgLoading.Visibility= Visibility.Hidden;
            cvsSearch.Visibility = Visibility.Visible;
        }

        private void BGW_MovieSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            search.Clear();

            List<MovieGenre> movieList = new List<MovieGenre>() { };
            if (Filter == "")
            {
                movieList = MyMongoDB.GetMovieGenreList();
            }
            else
            {
                movieList = MyMongoDB.MovieSearch(Filter);
            }
            foreach (MovieGenre movie in movieList)
            {
                search.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }
        }
        #endregion

        #region BGW_GenreSearch
        private void BGW_GenreSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int iter = 0;
            int rowcount = 0;
            foreach (Movie movie in search)
            {
                if (iter == 0)
                {
                    pnl1.Children.Add(CreatePoster(movie, true));
                }
                else if (iter == 1)
                {
                    pnl2.Children.Add(CreatePoster(movie, true));
                }
                else if (iter == 2)
                {
                    pnl3.Children.Add(CreatePoster(movie, true));
                }
                else if (iter == 3)
                {
                    pnl4.Children.Add(CreatePoster(movie, true));
                }
                else if (iter == 4)
                {
                    pnl5.Children.Add(CreatePoster(movie, true));
                }
                iter++;
                if (iter == 5)
                {
                    iter = 0;
                    rowcount++;
                }
                if (rowcount == 21)
                {
                    break;
                }
            }
            imgLoading.Visibility = Visibility.Hidden;
            cvsSearch.Visibility = Visibility.Visible;
        }

        private void BGW_GenreSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            search.Clear();
            List<MovieGenre> movieList = MyMongoDB.GetMovieGenreList(Filter);
            foreach (MovieGenre movie in movieList)
            {
                search.Add(MyMongoDB.GetMovie(movie.MovieTitle));
            }
        }
        #endregion

        #endregion

        #region Variables
        BackgroundWorker BGW_GetAllMovies = new BackgroundWorker();
        BackgroundWorker BGW_Animation = new BackgroundWorker();
        BackgroundWorker BGW_MovieSearch = new BackgroundWorker();
        BackgroundWorker BGW_GenreSearch = new BackgroundWorker();
        List<Movie> kids = new List<Movie>() { };
        List<Movie> adult = new List<Movie>() { };
        List<Movie> horror = new List<Movie>() { };
        List<Movie> disney = new List<Movie>() { };
        List<Movie> comedy = new List<Movie>() { };
        List<Movie> animated = new List<Movie>() { };
        List<Movie> action = new List<Movie>() { };
        List<Movie> adventure = new List<Movie>() { };
        List<Movie> starwars = new List<Movie>() { };
        List<Movie> sciencefiction = new List<Movie>() { };
        List<Movie> jurassic = new List<Movie>() { };
        List<Movie> superhero = new List<Movie>() { };
        List<Movie> romance = new List<Movie>() { };
        List<Movie> thriller = new List<Movie>() { };
        List<Movie> search = new List<Movie>() { };
        double ScrollOffset = 200;
        int ScrollSleep = 5;
        int ScrollProgress = 5;
        bool ScrollRight;
        string Filter;
        ScrollViewer ScrollViewer;
        Canvas lastOpened;
        Movie SelectedMovie;
        #endregion

        /// <summary>
        /// runs all the initializers
        /// </summary>
        private void Startups()
        {
            BGW_GetAllMovies.WorkerReportsProgress = true;
            BGW_GetAllMovies.DoWork += BGW_GetAllMovies_DoWork;
            BGW_GetAllMovies.ProgressChanged += BGW_GetAllMovies_ProgressChanged;
            BGW_GetAllMovies.RunWorkerCompleted += BGW_GetAllMovies_RunWorkerCompleted;
            BGW_GetAllMovies.RunWorkerAsync();

            BGW_Animation.WorkerReportsProgress = true;
            BGW_Animation.DoWork += BGW_Animation_DoWork;
            BGW_Animation.ProgressChanged += BGW_Animation_ProgressChanged;
            BGW_Animation.RunWorkerCompleted += BGW_Animation_RunWorkerCompleted;

            BGW_MovieSearch.WorkerReportsProgress = true;
            BGW_MovieSearch.DoWork += BGW_MovieSearch_DoWork;
            BGW_MovieSearch.RunWorkerCompleted += BGW_MovieSearch_RunWorkerCompleted;

            BGW_GenreSearch.WorkerReportsProgress = true;
            BGW_GenreSearch.DoWork += BGW_GenreSearch_DoWork;
            BGW_GenreSearch.RunWorkerCompleted += BGW_GenreSearch_RunWorkerCompleted;
        }

        /// <summary>
        /// disbales all the left/right buttons
        /// </summary>
        private void DisbaleSlideButtons()
        {
            btnActionLeft.IsEnabled = false;
            btnActionRight.IsEnabled = false;
            btnAdultLeft.IsEnabled = false;
            btnAdultRight.IsEnabled = false;
            btnAdventureLeft.IsEnabled = false;
            btnAdventureRight.IsEnabled = false;
            btnAnimatedLeft.IsEnabled = false;
            btnAnimatedRight.IsEnabled = false;
            btnComedyLeft.IsEnabled = false;
            btnComedyRight.IsEnabled = false;
            btnDisneyLeft.IsEnabled = false;
            btnDisneyRight.IsEnabled = false;
            btnHorrorLeft.IsEnabled = false;
            btnHorrorRight.IsEnabled = false;
            btnJurassicLeft.IsEnabled = false;
            btnJurassicRight.IsEnabled = false;
            btnKidsLeft.IsEnabled = false;
            btnKidsRight.IsEnabled = false;
            btnRomanceLeft.IsEnabled = false;
            btnRomanceRight.IsEnabled = false;
            btnScifiLeft.IsEnabled = false;
            btnScifiRight.IsEnabled = false;
            btnStarWarsLeft.IsEnabled = false;
            btnStarWarsRight.IsEnabled = false;
            btnSuperHeroLeft.IsEnabled = false;
            btnSuperHeroRight.IsEnabled = false;
            btnThrillerLeft.IsEnabled = false;
            btnThrillerRight.IsEnabled = false;
        }

        /// <summary>
        /// enables all the slide buttons
        /// </summary>
        private void EnableSlideButtons()
        {
            btnActionLeft.IsEnabled = true;
            btnActionRight.IsEnabled = true;
            btnAdultLeft.IsEnabled = true;
            btnAdultRight.IsEnabled = true;
            btnAdventureLeft.IsEnabled = true;
            btnAdventureRight.IsEnabled = true;
            btnAnimatedLeft.IsEnabled = true;
            btnAnimatedRight.IsEnabled = true;
            btnComedyLeft.IsEnabled = true;
            btnComedyRight.IsEnabled = true;
            btnDisneyLeft.IsEnabled = true;
            btnDisneyRight.IsEnabled = true;
            btnHorrorLeft.IsEnabled = true;
            btnHorrorRight.IsEnabled = true;
            btnJurassicLeft.IsEnabled = true;
            btnJurassicRight.IsEnabled = true;
            btnKidsLeft.IsEnabled = true;
            btnKidsRight.IsEnabled = true;
            btnRomanceLeft.IsEnabled = true;
            btnRomanceRight.IsEnabled = true;
            btnScifiLeft.IsEnabled = true;
            btnScifiRight.IsEnabled = true;
            btnStarWarsLeft.IsEnabled = true;
            btnStarWarsRight.IsEnabled = true;
            btnSuperHeroLeft.IsEnabled = true;
            btnSuperHeroRight.IsEnabled = true;
            btnThrillerLeft.IsEnabled = true;
            btnThrillerRight.IsEnabled = true;
        }

        /// <summary>
        /// when a slide button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SlideButton_Click(object sender, RoutedEventArgs e)
        {
            DisbaleSlideButtons();
            Button button = (Button)sender;
            if(button.Name == "btnKidsRight")
            {
                PerformSlide(svwKids, true);
            }
            else if (button.Name == "btnKidsLeft")
            {
                PerformSlide(svwKids, false);
            }
            else if (button.Name == "btnAdultRight")
            {
                PerformSlide(svwAdult, true);
            }
            else if (button.Name == "btnAdultLeft")
            {
                PerformSlide(svwAdult, false);
            }
            else if (button.Name == "btnHorrorRight")
            {
                PerformSlide(svwHorror, true);
            }
            else if (button.Name == "btnHorrorLeft")
            {
                PerformSlide(svwHorror, false);
            }
            else if (button.Name == "btnComedyRight")
            {
                PerformSlide(svwComedy, true);
            }
            else if (button.Name == "btnComedyLeft")
            {
                PerformSlide(svwComedy, false);
            }
            else if (button.Name == "btnDisneyRight")
            {
                PerformSlide(svwDisney, true);
            }
            else if (button.Name == "btnDisneyLeft")
            {
                PerformSlide(svwDisney, false);
            }
            else if (button.Name == "btnAnimatedRight")
            {
                PerformSlide(svwAnimated, true);
            }
            else if (button.Name == "btnAnimatedLeft")
            {
                PerformSlide(svwAnimated, false);
            }
            else if (button.Name == "btnScifiRight")
            {
                PerformSlide(svwScifi, true);
            }
            else if (button.Name == "btnScifiLeft")
            {
                PerformSlide(svwScifi, false);
            }
            else if (button.Name == "btnActionRight")
            {
                PerformSlide(svwAction, true);
            }
            else if (button.Name == "btnActionLeft")
            {
                PerformSlide(svwAction, false);
            }
            else if (button.Name == "btnAdventureRight")
            {
                PerformSlide(svwAdventure, true);
            }
            else if (button.Name == "btnAdventureLeft")
            {
                PerformSlide(svwAdventure, false);
            }
            else if (button.Name == "btnSuperHeroRight")
            {
                PerformSlide(svwSuperHero, true);
            }
            else if (button.Name == "btnSuperHeroLeft")
            {
                PerformSlide(svwSuperHero, false);
            }
            else if (button.Name == "btnStarWarsRight")
            {
                PerformSlide(svwStarWars, true);
            }
            else if (button.Name == "btnStarWarsLeft")
            {
                PerformSlide(svwStarWars, false);
            }
            else if (button.Name == "btnJurassicRight")
            {
                PerformSlide(svwJurassic, true);
            }
            else if (button.Name == "btnJurassicLeft")
            {
                PerformSlide(svwJurassic, false);
            }
            else if (button.Name == "btnRomanceRight")
            {
                PerformSlide(svwRomance, true);
            }
            else if (button.Name == "btnRomanceLeft")
            {
                PerformSlide(svwRomance, false);
            }
            else if (button.Name == "btnThrillerRight")
            {
                PerformSlide(svwThriller, true);
            }
            else if (button.Name == "btnThrillerLeft")
            {
                PerformSlide(svwThriller, false);
            }
        }

        /// <summary>
        /// performs the animation
        /// </summary>
        /// <param name="scrollViewer"></param>
        /// <param name="moveRight"></param>
        private void PerformSlide(ScrollViewer scrollViewer, bool moveRight)
        {
            this.ScrollViewer = scrollViewer;
            this.ScrollRight = moveRight;
            BGW_Animation.RunWorkerAsync();
        }

        /// <summary>
        /// sets the current category and searches
        /// </summary>
        public bool SearchMovies(string filter)
        {
            if (!IsWorkerRunning())
            {
                Filter = filter;

                lblCategory.Content = "Search";

                ClearPanels();

                cvsAll.Visibility = Visibility.Hidden;
                cvsMovieDetails.Visibility = Visibility.Hidden;
                cvsSearch.Visibility = Visibility.Hidden;

                imgLoading.Visibility = Visibility.Visible;

                lblNoneFound.Visibility = Visibility.Hidden;

                BGW_MovieSearch.RunWorkerAsync();
                return true;
            }
            return false;
        }

        /// <summary>
        /// opens the search tab but fills with that genre
        /// </summary>
        /// <param name="genre"></param>
        public bool OpenGenre(string genre)
        {
            if (!IsWorkerRunning())
            {
                tbxSearch.Visibility = Visibility.Visible;
                lblCategory.Visibility = Visibility.Visible;
                btnSearch.Visibility = Visibility.Visible;


                Filter = genre;

                lblCategory.Content = genre;

                ClearPanels();

                cvsAll.Visibility = Visibility.Hidden;
                cvsMovieDetails.Visibility = Visibility.Hidden;
                cvsSearch.Visibility = Visibility.Hidden;

                imgLoading.Visibility = Visibility.Visible;

                BGW_GenreSearch.RunWorkerAsync();

                return true;
            }
            return false;
        }

        /// <summary>
        /// returns back to default movie view
        /// </summary>
        public bool DisplayAllMovies()
        {
            if (!IsWorkerRunning())
            {
                imgLoading.Visibility= Visibility.Hidden;
                cvsSearch.Visibility = Visibility.Hidden;
                cvsMovieDetails.Visibility = Visibility.Hidden;
                cvsAll.Visibility = Visibility.Visible;
                return true;
            }
            return false;
        }

        /// <summary>
        /// when the search button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!IsWorkerRunning())
            {
                SearchMovies(tbxSearch.Text);
                SearchedAllMovies();
            }
        }

        /// <summary>
        /// clears all the panels of their movies
        /// </summary>
        private void ClearPanels()
        {
            pnl1.Children.Clear();
            pnl2.Children.Clear();
            pnl3.Children.Clear();
            pnl4.Children.Clear();
            pnl5.Children.Clear();
        }

        /// <summary>
        /// checks if any background worker is currently running
        /// </summary>
        /// <returns></returns>
        public bool IsWorkerRunning()
        {
            if (BGW_Animation.IsBusy) { return true; }
            if (BGW_GenreSearch.IsBusy) { return true; }
            if (BGW_GetAllMovies.IsBusy) { return true; }
            if (BGW_MovieSearch.IsBusy) { return true; }
            return false;
        }
        
        /// <summary>
        /// creates an poster image
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        private Image CreatePoster(Movie movie, bool isVerticalView)
        {
            ResourceDictionary Image = (ResourceDictionary)Application.LoadComponent(new Uri("\\ResourceDictionaries\\ImageDictionary.xaml", UriKind.Relative));
            Image poster = new Image();
            if (isVerticalView)
            {
                poster.Style = (Style)Image["PosterSearch"];
            }
            else
            {
                poster.Style = (Style)Image["Poster"];
            }
            poster.Source = movie.GetPosterBitMap();
            poster.MouseDown += Poster_MouseDown;
            return poster;
        }

        /// <summary>
        /// when a poster is clicked, open the movie info page of that movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Poster_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenedDetails(true);

            if (cvsAll.Visibility == Visibility.Visible)
            {
                lastOpened = cvsAll;
            }
            else
            {
                lastOpened = cvsSearch;
            }
            cvsMovieDetails.Visibility = Visibility.Visible;
            cvsAll.Visibility = Visibility.Hidden;
            cvsSearch.Visibility = Visibility.Hidden;
            tbxSearch.Visibility = Visibility.Hidden;
            lblCategory.Visibility = Visibility.Hidden;
            btnSearch.Visibility = Visibility.Hidden;

            Image poster = (Image)sender;

            Movie movie = MyMongoDB.GetMovie(poster.Source);

            imgPoster.Source = poster.Source;
            lblTitle.Content = movie.Title;
            lblCompany.Content = movie.Company;
            lblDescription.Text = movie.Description;
            lblReleaseYear.Content = movie.ReleaseYear;
            lblGenres.Content = MyMongoDB.GetMovieGenres(movie.Title);

            SelectedMovie = movie;
        }

        /// <summary>
        /// when the user closes the details page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MovieDetailsClose_Click(object sender, RoutedEventArgs e)
        {
            if (lastOpened == cvsAll)
            {
                cvsAll.Visibility = Visibility.Visible;
            }
            else
            {
                cvsSearch.Visibility = Visibility.Visible;
            }
            tbxSearch.Visibility = Visibility.Visible;
            lblCategory.Visibility = Visibility.Visible;
            btnSearch.Visibility= Visibility.Visible;
            cvsMovieDetails.Visibility = Visibility.Hidden;

            OpenedDetails(false);
        }

        /// <summary>
        /// when movie play button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            PlayedMovie(SelectedMovie);
        }
    }
}
