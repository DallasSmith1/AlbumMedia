using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
namespace AlbumMedia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // timer for smooth transition
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            
            
            OpenIndex();
        }


        #region Constants/Variables
        System.Windows.Forms.Timer timer = null;
        int timerCount = 0;
        #endregion

        private void Timer_Tick(object sender, EventArgs e)
        {
            timerCount++;
            if(timerCount == 1) 
            {
                timer.Stop();
                Layout.Appeared += Layout_Appeared;
                Layout.Hidden += Layout_Hidden;
                Layout.Emailed += Layout_Emailed;
                Layout.OnSetNewPassword += Layout_OnSetNewPassword;
                frmMain.NavigationService.Navigate(new Layout());
                DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromSeconds(1));
                frmMain.BeginAnimation(Frame.OpacityProperty, animation);
            }
        }

        private void Layout_OnSetNewPassword(string username)
        {
            NewPassword newPassword = new NewPassword(username);
            newPassword.ShowDialog();
        }

        private void Layout_Emailed()
        {
            PasswordReset passwordReset = new PasswordReset();
            passwordReset.ShowDialog();
        }

        private void Layout_Hidden()
        {
            this.Hide();
        }

        private void Layout_Appeared()
        {
            this.Show();
        }

        /// <summary>
        /// opens the index page
        /// </summary>
        private void OpenIndex()
        {
            // create a new event
            Index.OnConnected += Index_OnConnected;
            frmMain.NavigationService.Navigate(new Index());
        }

        /// <summary>
        /// if the OnConnect function is called in the index page, run this function
        /// </summary>
        private void Index_OnConnected()
        {   
            DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromSeconds(1));
            frmMain.BeginAnimation(Frame.OpacityProperty, animation);
            timer.Start();
        }

        
    }
}
