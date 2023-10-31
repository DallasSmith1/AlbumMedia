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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public delegate void MovieEditClick();

        public static event MovieEditClick MovieEditClicked;

        public delegate void DeleteAccount();

        public static event DeleteAccount OnDeleteAccount;

        public Profile(User currentUser)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            SetValues();
        }

        User CurrentUser = null;

        /// <summary>
        /// displays all the users values on the screen
        /// </summary>
        private void SetValues()
        {
            lblId.Content = CurrentUser.Id;
            lblUsername.Content = CurrentUser.Username;
            tbxPassword.Text = CurrentUser.Password;
            lblEmail.Content = CurrentUser.Email;

            string hiddenPassword = "";

            for (int i = 0; i < CurrentUser.Password.Length; i++)
            {
                hiddenPassword += "♦";
            }

            lblPassword.Content = hiddenPassword;

            if (CurrentUser.IsAdmin)
            {
                lblType.Content = "Admin";
                btnEditMovies.Visibility = Visibility.Visible;
            }
            else
            {
                lblType.Content = "User";
            }
        }

        /// <summary>
        /// clicked the edit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btnEdit.Content == "Edit")
            {
                btnEdit.Content = "Update";
                btnCancel.Visibility = Visibility.Visible;
                btnShow.Visibility = Visibility.Collapsed;
                tbxPassword.Visibility = Visibility.Visible;
                lblPassword.Visibility = Visibility.Hidden;
            }
            else
            {
                CurrentUser = MyMongoDB.UpdatePassword(CurrentUser.Username, tbxPassword.Text.ToString());
                SetValues();
                btnEdit.Content = "Edit";
                btnCancel.Visibility = Visibility.Hidden;
                btnShow.Visibility = Visibility.Visible;
                tbxPassword.Visibility = Visibility.Hidden;
                lblPassword.Visibility = Visibility.Visible;
                btnShow.Content = "Show";
            }
        }

        /// <summary>
        /// clicked the edit movies button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditMovies_Click(object sender, RoutedEventArgs e)
        {
            MovieEditClicked();
        }

        /// <summary>
        /// when the show button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            if((string)btnShow.Content == "Show")
            {
                lblPassword.Content = CurrentUser.Password;
                btnShow.Content = "Hide";
            }
            else
            {
                string hiddenPassword = "";

                for (int i = 0; i < CurrentUser.Password.Length; i++)
                {
                    hiddenPassword += "♦";
                }

                lblPassword.Content = hiddenPassword;
                btnShow.Content = "Show";
            }
        }

        /// <summary>
        /// when the cenel button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            btnEdit.Content = "Edit";
            btnCancel.Visibility = Visibility.Hidden;
            btnShow.Visibility = Visibility.Visible;
            tbxPassword.Visibility = Visibility.Hidden;
            lblPassword.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// deletes users account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MyMongoDB.DeleteUser(CurrentUser.Username);
            OnDeleteAccount();
        }
    }
}
