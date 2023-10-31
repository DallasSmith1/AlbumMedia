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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AlbumMedia.Classes;
using MongoDB.Driver;
namespace AlbumMedia
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public delegate void LoggedIn(User user);

        public static event LoggedIn isLoggedIn;

        public delegate void ResetPassword();

        public static event ResetPassword isResetPassword;

        public delegate void TemporaryPassword(string username);

        public static event TemporaryPassword isTemporaryPassword;
        public Login()
        {
            InitializeComponent();
            swaptimer = new System.Windows.Forms.Timer();
            swaptimer.Tick += Swaptimer_Tick; ;
            swaptimer.Interval = 500;
        }

        #region Timer
        System.Windows.Forms.Timer swaptimer = null;
        int timerCount = 0;
        bool openLogin = true;

        /// <summary>
        /// when the swaptimer ticks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Swaptimer_Tick(object sender, EventArgs e)
        {
            ClearFields();
            timerCount++;
            if (timerCount == 1)
            {
                swaptimer.Stop();
                timerCount = 0;
                if (openLogin)
                {
                    cvsRegister.Visibility = Visibility.Hidden;
                    cvsLogin.Visibility = Visibility.Visible;
                    DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.5));
                    cvsLogin.BeginAnimation(Frame.OpacityProperty, animation);
                }
                else
                {
                    cvsLogin.Visibility= Visibility.Hidden;
                    cvsRegister.Visibility = Visibility.Visible;
                    DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.5));
                    cvsRegister.BeginAnimation(Frame.OpacityProperty, animation);
                }
            }
        }
        /// <summary>
        /// starts the animation between canvases
        /// </summary>
        /// <param name="openLogin"></param>
        private void AnimationSwap(bool openLogin)
        {
            this.openLogin = openLogin;
            if (openLogin)
            {
                DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.5));
                cvsRegister.BeginAnimation(Frame.OpacityProperty, animation);
                swaptimer.Start();
            }
            else
            {
                DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.5));
                cvsLogin.BeginAnimation(Frame.OpacityProperty, animation);
                swaptimer.Start();
            }
        }
        #endregion

        /// <summary>
        /// logs in to a user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            lblError.Content = string.Empty;
            User user = null;

            if (tbxUsername.Text == "" || tbxPass.Password == "")
            {
                lblError.Content= "All fields are required.*";
            }
            else
            {
                try
                {
                    user = MyMongoDB.GetUser(tbxUsername.Text, tbxPass.Password);
                }
                catch (UserNotFoundException exception)
                {
                    lblError.Content = exception.Message;
                }
                catch (TemporaryPasswordException exception)
                {
                    isTemporaryPassword(tbxUsername.Text);
                    lblError.Content = "Temporary Password Used";
                }
            }
            if ((string)lblError.Content == string.Empty)
            {
                isLoggedIn(user);
            }
        }

        /// <summary>
        /// goes to the register page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoToRegister_Click(object sender, RoutedEventArgs e)
        {
            AnimationSwap(false);
        }

        /// <summary>
        /// registers a new user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            lblUsernameError.Content = string.Empty;
            lblPasswordError.Content = string.Empty;

            if (tbxRegUsername.Text == "" || tbxRegPass.Password == "" || tbxConfPass.Password == "" || tbxEmail.Text == "" )
            {
                lblUsernameError.Content = "All fields are required.*";
            }
            if(tbxRegPass.Password != tbxConfPass.Password)
            {
                lblPasswordError.Content = "Passwords do not match.*";
            }

            if ((string)lblUsernameError.Content == string.Empty && (string)lblPasswordError.Content == string.Empty)
            {
                User newUser = new User(tbxRegUsername.Text, tbxConfPass.Password);
                newUser.Email = tbxEmail.Text;
                try
                {
                    MyMongoDB.CreateUser(newUser);
                    AnimationSwap(true);
                }
                catch (UserAlreadyExistsException exception) 
                {
                    lblUsernameError.Content = exception.Message;
                }
            }
        }

        /// <summary>
        /// goes to the login page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoToLogin_Click(object sender, RoutedEventArgs e)
        {
            AnimationSwap(true);
        }

        /// <summary>
        /// clears all the fields
        /// </summary>
        private void ClearFields()
        {
            tbxConfPass.Password = string.Empty;
            tbxPass.Password = string.Empty;
            tbxRegPass.Password = string.Empty;
            tbxRegUsername.Text = string.Empty;
            tbxUsername.Text = string.Empty;
            lblError.Content = string.Empty;
            lblPasswordError.Content = string.Empty;
            lblUsernameError.Content = string.Empty;
        }

        /// <summary>
        /// when forgot password is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            isResetPassword();
        }
    }
}
