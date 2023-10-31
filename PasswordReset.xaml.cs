using AlbumMedia.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for PasswordReset.xaml
    /// </summary>
    public partial class PasswordReset : Window
    {
        public PasswordReset()
        {
            InitializeComponent();

            BackgroundWorker.DoWork += BackgroundWorker_DoWork;
            BackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cvsLoading.Visibility = Visibility.Collapsed;
            cvsSent.Visibility = Visibility.Visible;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            User user = MyMongoDB.GetUser(Email);

            Email email = new Email();

            email.Recipient = Email;
            email.Subject = "Password Reset";
            email.HtmlContent =
                "<html>" +
                "<h1>Album Media</h1>" +
                "<h2>Password Reset Request For User: " + user.Username + " </h2>" +
                "<p>A request has been made to reset your password. Your temporary password is provided below. After" +
                " logging in with the password, it is suggested to immediately go to your profile and change it.</p>" +
                "<p><b>Temporary Password:</b> "+MyMongoDB.SetTemporaryPassword(Email)+"</p>";

            email.Send();
        }

        BackgroundWorker BackgroundWorker = new BackgroundWorker();
        string Email;

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            if (tbxEmail.Text != "")
            {
                Email = tbxEmail.Text;
                User user = MyMongoDB.GetUser(Email);

                if (user != null)
                {
                    cvsEmail.Visibility = Visibility.Collapsed;
                    cvsLoading.Visibility = Visibility.Visible;
                    BackgroundWorker.RunWorkerAsync();
                }
                else
                {
                    lblError.Content = Email + " is not registered to an account.";
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
