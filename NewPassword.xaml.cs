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
    /// Interaction logic for NewPassword.xaml
    /// </summary>
    public partial class NewPassword : Window
    {
        public NewPassword(string username)
        {
            InitializeComponent();

            Username = username;
        }

        string Username;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbxConf.Password == "" || tbxPass.Password == "")
            {
                lblError.Content = "All fields are required.";
                lblError.Visibility = Visibility.Visible;
            }
            else if (tbxPass.Password != tbxConf.Password)
            {
                lblError.Content = "Passwords do not match.";
                lblError.Visibility = Visibility.Visible;
            }
            else
            {
                User user = MyMongoDB.UpdatePassword(Username, tbxPass.Password);
                MyMongoDB.DeleteTemporaryPassword(user.Email);
                this.Close();
            }
        }
    }
}
