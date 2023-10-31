using FFmpeg.AutoGen;
using MongoDB.Bson.Serialization.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
    /// Interaction logic for MoviePlayer.xaml
    /// </summary>
    public partial class MoviePlayer : Page
    {
        public delegate void CloseMovie();

        public static event CloseMovie ClosedMovie;

        public delegate void FullScreen();

        public static event FullScreen FullScreened;

        public delegate void Window();

        public static event Window Windowed;

        public delegate void Hide();

        public static event Hide Hidden;

        public MoviePlayer(Movie movie)
        {
            InitializeComponent();

            mdeMoviePlayer.LoadedBehavior = MediaState.Manual;
            mdeMoviePlayer.Source = movie.GetFileUri();
            lblMovieTitle.Content = movie.Title;

            mdeMoviePlayer.Play();

            Timer.DoWork += Timer_DoWork;
            Timer.ProgressChanged += Timer_ProgressChanged;
            Timer.WorkerReportsProgress = true;

            currentMovie = movie;
        }

        #region Variables
        public Movie currentMovie;

        bool isFullScreen = false;

        bool isPaused = false;

        BackgroundWorker Timer = new BackgroundWorker();

        bool isMouseDown = false;

        bool IsMouseOver = false;

        int AutoHideTimer = 5;
        #endregion

        private void Timer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!isPaused && sdrMovieProgess.Maximum != sdrMovieProgess.Value)
            {
                List<int> time = new List<int>();
                foreach (string count in lblCurrentTime.Content.ToString().Split(':'))
                {
                    time.Add(Int32.Parse(Math.Round(double.Parse(count)).ToString()));
                }
                time[2] += 1;
                if (time[2] >= 60)
                {
                    time[2] -= 60;
                    time[1] += 1;
                    if (time[1] >= 60)
                    {
                        time[1] -= 60;
                        time[0] += 1;
                    }
                }
                

                sdrMovieProgess.Value += 1;
                lblCurrentTime.Content = new TimeSpan(time[0], time[1], time[2]).ToString();
            }
            if (IsMouseOver)
            {
                if (AutoHideTimer == 0)
                {
                    HideUI();
                    Hidden();
                }
                else
                {
                    AutoHideTimer--;
                }
            }
        }

        private void Timer_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                Thread.Sleep(1000);
                Timer.ReportProgress(1);
            }
        }

        /// <summary>
        /// when movie is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ClosedMovie();
        }

        /// <summary>
        /// when the paus button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            Pause_Playe_Movie();
        }

        /// <summary>
        /// when fast forward is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnForward30_Click(object sender, RoutedEventArgs e)
        {
            Forward();
        }

        /// <summary>
        /// when rewind is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack30_Click(object sender, RoutedEventArgs e)
        {
            Rewind();
        }

        /// <summary>
        /// when fullscreen is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFullscreen_Click(object sender, RoutedEventArgs e)
        {
            if (!isFullScreen)
            {
                FullScreened();
                isFullScreen = true;
            }
            else
            {
                Windowed();
                isFullScreen = false;
            }
        }

        /// <summary>
        /// hides the UI
        /// </summary>
        public void HideUI()
        {
            btnClose.Visibility = Visibility.Hidden;
            btnBack30.Visibility = Visibility.Hidden;
            btnFullscreen.Visibility = Visibility.Hidden;
            btnPause.Visibility = Visibility.Hidden;
            btnSound.Visibility = Visibility.Hidden;
            btnForward30.Visibility = Visibility.Hidden;
            sdrMovieProgess.Visibility = Visibility.Hidden;
            sdrVolume.Visibility = Visibility.Hidden;
            lblMovieTitle.Visibility = Visibility.Hidden;
            lblTotalTime.Visibility = Visibility.Hidden;
            lblCurrentTime.Visibility = Visibility.Hidden;

            IsMouseOver = false;
        }

        /// <summary>
        /// shows the ui
        /// </summary>
        public void ShowUI()
        {
            btnClose.Visibility = Visibility.Visible;
            btnBack30.Visibility = Visibility.Visible;
            btnFullscreen.Visibility = Visibility.Visible;
            btnPause.Visibility = Visibility.Visible;
            btnSound.Visibility = Visibility.Visible;
            btnForward30.Visibility = Visibility.Visible;
            sdrMovieProgess.Visibility = Visibility.Visible;
            sdrVolume.Visibility = Visibility.Visible;
            lblMovieTitle.Visibility = Visibility.Visible;
            lblCurrentTime.Visibility = Visibility.Visible;
            lblTotalTime.Visibility = Visibility.Visible;

            AutoHideTimer = 5;
            IsMouseOver = true;
        }

        /// <summary>
        /// when mouse is over movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hover(object sender, MouseEventArgs e)
        {
            //ShowUI();
        }

        /// <summary>
        /// when mouse leaves movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Leave(object sender, MouseEventArgs e)
        {
            //HideUI();
        }

        /// <summary>
        /// when a movie file is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Opened(object sender, RoutedEventArgs e)
        {
            double time = mdeMoviePlayer.NaturalDuration.TimeSpan.TotalSeconds;
            TimeSpan totalDurationTime = TimeSpan.FromSeconds(mdeMoviePlayer.NaturalDuration.TimeSpan.TotalSeconds);

            sdrMovieProgess.Maximum = time;
            lblTotalTime.Content = totalDurationTime.ToString();
            Timer.RunWorkerAsync();

            if(isPaused)
            {
                mdeMoviePlayer.Pause();
            }
        }

        /// <summary>
        /// When the volume changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumeChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (mdeMoviePlayer != null)
            {
                double volume = sdrVolume.Value / 100;

                ResourceDictionary buttons = (ResourceDictionary)Application.LoadComponent(new Uri("\\ResourceDictionaries\\ButtonDictionary.xaml", UriKind.Relative));
                if (volume == 0) 
                {
                    btnSound.Style = (Style)buttons["VideoSoundMute"];
                }
                else
                {
                    btnSound.Style = (Style)buttons["VideoSound"];
                }
                mdeMoviePlayer.Volume = volume;
            }
        }

        /// <summary>
        /// Mute button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSound_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary buttons = (ResourceDictionary)Application.LoadComponent(new Uri("\\ResourceDictionaries\\ButtonDictionary.xaml", UriKind.Relative));

            double volume = sdrVolume.Value / 100;

            if (volume == 0)
            {
                btnSound.Style = (Style)buttons["VideoSound"];
                volume = 0.1;
            }
            else
            {
                btnSound.Style = (Style)buttons["VideoSoundMute"];
                volume = 0;
            }
            sdrVolume.Value = volume;
            mdeMoviePlayer.Volume = volume;
        }

        /// <summary>
        /// when user clicks the movie slide bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Down(object sender, MouseButtonEventArgs e)
        {
            ResourceDictionary buttons = (ResourceDictionary)Application.LoadComponent(new Uri("\\ResourceDictionaries\\ButtonDictionary.xaml", UriKind.Relative));
            isMouseDown = true;
            isPaused = true;
            mdeMoviePlayer.Pause();
            btnPause.Style = (Style)buttons["VideoPlay"];
        }

        /// <summary>
        /// WHen the user lets go of the click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Up(object sender, MouseButtonEventArgs e)
        {
            mdeMoviePlayer.Position = new TimeSpan(0,0, Int32.Parse(Math.Round(sdrMovieProgess.Value).ToString()));
            ResourceDictionary buttons = (ResourceDictionary)Application.LoadComponent(new Uri("\\ResourceDictionaries\\ButtonDictionary.xaml", UriKind.Relative));
            isMouseDown = false;
            isPaused = false;
            mdeMoviePlayer.Play();
            btnPause.Style = (Style)buttons["VideoPause"];
        }

        /// <summary>
        /// when movie time change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MovieTimeChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (isMouseDown)
            {
                lblCurrentTime.Content = new TimeSpan(0, 0, Int32.Parse(Math.Round(sdrMovieProgess.Value).ToString())).ToString();
            }
        }

        /// <summary>
        /// when the user clicks anywhere on the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MovieClick(object sender, MouseButtonEventArgs e)
        {
            Pause_Playe_Movie();
        }

        /// <summary>
        /// pauses or plays the movie
        /// </summary>
        public void Pause_Playe_Movie()
        {
            ResourceDictionary buttons = (ResourceDictionary)Application.LoadComponent(new Uri("\\ResourceDictionaries\\ButtonDictionary.xaml", UriKind.Relative));
            if (!isPaused)
            {
                mdeMoviePlayer.Pause();
                btnPause.Style = (Style)buttons["VideoPlay"];
                isPaused = true;
            }
            else
            {
                mdeMoviePlayer.Play();
                btnPause.Style = (Style)buttons["VideoPause"];
                isPaused = false;
            }
        }

        /// <summary>
        /// fast forward
        /// </summary>
        public void Forward()
        {
            sdrMovieProgess.Value += 30;

            lblCurrentTime.Content = new TimeSpan(0, 0, Int32.Parse(Math.Round(sdrMovieProgess.Value).ToString())).ToString();
            mdeMoviePlayer.Position = new TimeSpan(0, 0, Int32.Parse(Math.Round(sdrMovieProgess.Value).ToString()));
        }

        /// <summary>
        /// rewind the movie
        /// </summary>
        public void Rewind()
        {
            sdrMovieProgess.Value -= 10;

            lblCurrentTime.Content = new TimeSpan(0, 0, Int32.Parse(Math.Round(sdrMovieProgess.Value).ToString())).ToString();
            mdeMoviePlayer.Position = new TimeSpan(0, 0, Int32.Parse(Math.Round(sdrMovieProgess.Value).ToString()));
        }

        /// <summary>
        /// raise volume
        /// </summary>
        public void VolumeUp()
        {
            mdeMoviePlayer.Volume += 0.1;
            sdrVolume.Value += 10;
        }

        /// <summary>
        /// lowers the volume
        /// </summary>
        public void VolumeDown()
        {
            mdeMoviePlayer.Volume -= 0.1;
            sdrVolume.Value -= 10;
        }
    }
}
