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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlbumMedia
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        // link to call the OnConnected event from the main window
        public delegate void Connected();

        public static event Connected OnConnected;


        public Index()
        {
            InitializeComponent();
            Connect.DoWork += Connect_DoWork;
            Connect.RunWorkerCompleted += Connect_RunWorkerCompleted;
        }
        
        BackgroundWorker Connect = new BackgroundWorker();
        bool isConnected = false;

        private void Connect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnConnect.IsEnabled = true;
            imgLoading.Visibility = Visibility.Hidden;
            if (isConnected)
            {
                lblError.Content = "Connected!";
                if (File.Exists(new Uri("../../ImagesToDelete.txt", UriKind.Relative).ToString()))
                {
                    string readText = File.ReadAllText(new Uri("../../ImagesToDelete.txt", UriKind.Relative).ToString());

                    string[] files = readText.Split('\n');

                    foreach(string file in files)
                    {
                        if (file != "")
                        {
                            File.Delete(file.Replace("\r", ""));
                        }
                    }

                    File.Delete(new Uri("../../ImagesToDelete.txt", UriKind.Relative).ToString());
                }
                OnConnected();
            }
            else
            {
                lblError.Content = "Unable to connect to server! Be sure that directory '" + Properties.Settings.Default.SHAREDFOLDER + "' is accessable.";
            }
        }

        private void Connect_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Directory.Exists(Properties.Settings.Default.SHAREDFOLDER))
            {
                isConnected = true;
            }
            else
            {
                isConnected = false;
            }
            Thread.Sleep(3000);
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            lblError.Content = "";
            btnConnect.IsEnabled = false;
            imgLoading.Visibility= Visibility.Visible;
            Connect.RunWorkerAsync();
        }
    }
}
