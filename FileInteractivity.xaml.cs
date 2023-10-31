using AlbumMedia.Classes;
using Microsoft.Win32;
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
    /// Interaction logic for FileInteractivity.xaml
    /// </summary>
    public partial class FileInteractivity : Page
    {
        public delegate void Cancel();

        public static event Cancel Canceled;

        public FileInteractivity(List<string> photos, string user)
        {
            InitializeComponent();
            animation.ProgressChanged += Animation_ProgressChanged;
            animation.DoWork += Animation_DoWork;
            animation.WorkerReportsProgress = true;
            animation.WorkerSupportsCancellation = true;

            process.ProgressChanged += Process_ProgressChanged;
            process.DoWork += Process_DoWork;
            process.RunWorkerCompleted += Process_RunWorkerCompleted;
            process.WorkerReportsProgress = true;

            pgrProgress.Maximum = photos.Count;

            spnlTags.Children.Clear();

            LoadFiles(photos, user);
            animation.RunWorkerAsync();
        }

        string path;
        List<string> tags = new List<string>();
        bool isSingleFile = false;
        string processType;
        string user;
        List<string> photos = new List<string>();
        bool isHover = false;
        bool goRight = true;
        double ScrollOffset = 200;
        int ScrollSleep = 10;
        int ScrollProgress = 2;
        BackgroundWorker animation = new BackgroundWorker();
        BackgroundWorker process = new BackgroundWorker();

        private void Process_DoWork(object sender, DoWorkEventArgs e)
        {
            if (processType == "Delete")
            {
                foreach (string file in photos)
                {
                    using (StreamWriter writer = new StreamWriter(new Uri("../../ImagesToDelete.txt", UriKind.Relative).ToString()))
                    {
                        foreach(string photo in photos)
                        {
                            writer.WriteLine(Properties.Settings.Default.SHAREDFOLDER + "\\Users\\" + user + "\\" + photo);
                        }
                    }
                    MyMongoDB.DeletePhoto(file);
                    process.ReportProgress(0);
                }
            }
            else if (processType == "Share")
            {
                foreach (string file in photos)
                {
                    Photo photo = MyMongoDB.GetPhoto(file);

                    if (photo != null)
                    {
                        photo.isPublic = true;
                        MyMongoDB.UpdatePhoto(photo);
                    }
                    
                    process.ReportProgress(0);
                }
            }
            else if (processType == "Hide")
            {
                foreach (string file in photos)
                {
                    Photo photo = MyMongoDB.GetPhoto(file);

                    if (photo != null)
                    {
                        photo.isPublic = false;
                        MyMongoDB.UpdatePhoto(photo);
                    }

                    process.ReportProgress(0);
                }
            }
            else if (processType == "Download")
            {
                Directory.CreateDirectory(path);

                foreach (string file in photos)
                {
                    File.Copy(Properties.Settings.Default.SHAREDFOLDER + "\\Users\\" + user + "\\" + file, path + "\\" + file);
                    process.ReportProgress(0);
                }
            }
            else if (processType == "Edit")
            {
                for (int i = 0; i < photos.Count; i++)
                {
                    Photo photo = MyMongoDB.GetPhoto(photos[i]);

                    if (isSingleFile)
                    {
                        photo.keywords = "";
                    }
                    foreach (string tag in tags)
                    {
                        photo.keywords += tag.ToLower() + ":";
                    }

                    MyMongoDB.UpdatePhoto(photo);
                    process.ReportProgress(0);
                }
            }
        }

        private void Process_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                pgrProgress.Value++;
            }
        }

        private void Process_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (processType == "Delete")
            {
                Canceled();
            }

            cvsMain.Visibility = Visibility.Visible;
            cvsProcress.Visibility = Visibility.Hidden;
            cvsEdit.Visibility = Visibility.Hidden;
            cvsDownload.Visibility = Visibility.Hidden;

            pgrProgress.Value = 0;
        }

        private void Animation_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                Thread.Sleep(ScrollSleep);
                animation.ReportProgress(ScrollProgress);
            }
        }

        private void Animation_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (svrFiles.HorizontalOffset == svrFiles.ScrollableWidth && !isHover)
            {
                goRight = false;
            }
            else if (svrFiles.HorizontalOffset == 0 && !isHover)
            {
                goRight = true;
            }

            if(goRight)
            {
                svrFiles.ScrollToHorizontalOffset(svrFiles.HorizontalOffset + e.ProgressPercentage);
            }
            else
            {
                svrFiles.ScrollToHorizontalOffset(svrFiles.HorizontalOffset - e.ProgressPercentage);
            }
        }

        private void Hover_Photos(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ScrollProgress = 0;
            isHover = true;
        }

        private void DeHover_Photos(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ScrollProgress = 2;
            isHover = false;
        }

        private void Hover_Right_Slow(object sender, System.Windows.Input.MouseEventArgs e)
        {
            goRight = true;
            ScrollProgress = 3;
            isHover = true;
        }

        private void Hover_LEft_Slow(object sender, System.Windows.Input.MouseEventArgs e)
        {
            goRight = false;
            ScrollProgress = 3;
            isHover = true;
        }

        private void Hover_Left_Fast(object sender, System.Windows.Input.MouseEventArgs e)
        {   
            goRight = false;
            ScrollProgress = 5;
            isHover = true;
        }

        private void DeHover_Left_Fast(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ScrollProgress = 2;
            isHover = false;
        }

        private void Hover_Right_Fast(object sender, System.Windows.Input.MouseEventArgs e)
        {
            goRight = true;
            ScrollProgress = 5;
            isHover = true;
        }

        private void DeHover_Right_Fast(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ScrollProgress = 2;
            isHover = false;
        }

        private void LoadFiles(List<string> files, string user)
        {
            lblFilesSelected.Content = "Files Selected: " + files.Count;

            List<Photo> photos = MyMongoDB.GetPhotos("Date Photo Taken (Old-New)", user);
            int iter = 0;

            int max = 50;

            foreach (Photo photo in photos)
            {
                if (iter > max)
                {
                    break;
                }
                if (files.Contains(photo.file))
                {
                    if (Photo.IsValidImage(photo.file))
                    {
                        Image newImage = new Image();
                        newImage.Margin = new Thickness(20, 0, 0, 0);
                        try
                        {
                            newImage.Source = photo.GetBitMap();
                        }
                        catch (CorruptFileException e)
                        {
                            newImage.Source = new BitmapImage(new Uri("../../images/ImageError.png", UriKind.Relative));
                        }
                        spnlFiles.Children.Add(newImage);
                        iter++;
                    }
                    else
                    {
                        MediaElement mediaElement = new MediaElement();
                        try
                        {
                            mediaElement.Source = photo.GetUri();
                            mediaElement.Volume = 0;
                            mediaElement.LoadedBehavior = MediaState.Pause;
                            mediaElement.ScrubbingEnabled = true;
                            mediaElement.Margin = new Thickness(20, 0, 0, 0);
                            spnlFiles.Children.Add(mediaElement);
                            iter++;
                        }
                        catch (CorruptFileException e)
                        {
                            Image newImage = new Image();
                            newImage.Source = new BitmapImage(new Uri("../../images/ImageError.png", UriKind.Relative));
                            newImage.Margin = new Thickness(20, 0, 0, 0);
                            spnlFiles.Children.Add(newImage);
                            iter++;
                        }
                    }
                }
            }

            this.photos = files;
            
            this.user = user;

            if (files.Count == 1)
            {
                isSingleFile = true; 
            }
        }

        private void btnShare_Click(object sender, RoutedEventArgs e)
        {
            cvsMain.Visibility = Visibility.Collapsed;
            cvsProcress.Visibility = Visibility.Visible;

            pgrProgress.Maximum = photos.Count;
            lblTypeOfProcess.Content = "Sharing Files";
            processType = "Share";

            animation.CancelAsync();
            process.RunWorkerAsync();
        }

        private void btnHide_Click(object sender, RoutedEventArgs e)
        {
            cvsMain.Visibility = Visibility.Collapsed;
            cvsProcress.Visibility = Visibility.Visible;

            pgrProgress.Maximum = photos.Count;
            lblTypeOfProcess.Content = "Hiding Files";
            processType = "Hide";

            animation.CancelAsync();
            process.RunWorkerAsync();
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            cvsMain.Visibility = Visibility.Collapsed;
            cvsDownload.Visibility = Visibility.Visible;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            cvsMain.Visibility= Visibility.Collapsed;
            cvsEdit.Visibility= Visibility.Visible;

            spnlTags.Children.Clear();

            if (isSingleFile)
            {
                Photo photo = MyMongoDB.GetPhoto(photos[0]);

                foreach (string tag in photo.keywords.Split(':'))
                {
                    if (tag != "")
                    {
                        AddTag(tag);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            cvsMain.Visibility = Visibility.Collapsed;
            cvsProcress.Visibility = Visibility.Visible;

            pgrProgress.Maximum = photos.Count;
            lblTypeOfProcess.Content = "Deleteing Files";
            processType = "Delete";

            animation.CancelAsync();
            process.RunWorkerAsync();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Canceled();
        }

        private void DeHover_left_Slow(object sender, System.Windows.Input.MouseEventArgs e)
        {
            isHover = false;
            ScrollProgress = 2;
        }

        private void DeHover_Right_Slow(object sender, System.Windows.Input.MouseEventArgs e)
        {
            isHover = false;
            ScrollProgress = 2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cvsDownload.Visibility = Visibility.Hidden;
            cvsMain.Visibility= Visibility.Visible;
            //LoadFiles(photos, user);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            tbxSaveTo.Text = folderBrowserDialog.SelectedPath;
        }

        private void btnDownloadStart_Click(object sender, RoutedEventArgs e)
        {
            cvsDownload.Visibility = Visibility.Hidden;
            cvsProcress.Visibility = Visibility.Visible;

            pgrProgress.Maximum = photos.Count;
            lblTypeOfProcess.Content = "Downloading Files";
            processType = "Download";

            path = tbxSaveTo.Text + "\\" + tbxFolder.Text;

            animation.CancelAsync();
            process.RunWorkerAsync();
        }

        private void LocationChange(object sender, TextChangedEventArgs e)
        {
            if (Directory.Exists(tbxSaveTo.Text))
            {
                if (tbxFolder.Text != "")
                {
                    btnDownloadStart.Visibility = Visibility.Visible;
                    return;
                }
            }
            btnDownloadStart.Visibility = Visibility.Hidden;
        }

        private void FolderChange(object sender, TextChangedEventArgs e)
        {
            if (Directory.Exists(tbxSaveTo.Text)) 
            {
                if (tbxFolder.Text != "")
                {
                    btnDownloadStart.Visibility = Visibility.Visible;
                    return;
                }
            }
            btnDownloadStart.Visibility = Visibility.Hidden;
        }

        private void btnBacktoMain_Click(object sender, RoutedEventArgs e)
        {
            cvsEdit.Visibility = Visibility.Hidden;
            cvsMain.Visibility = Visibility.Visible;
            //LoadFiles(photos, user);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool exists = false;
            foreach (var ele in spnlTags.Children)
            {
                System.Windows.Controls.Label lab = (System.Windows.Controls.Label)ele;
                if (lab.Content.ToString() == tbxTag.Text)
                {
                    exists = true;
                }
            }
            if (!exists)
            {
                AddTag(tbxTag.Text);
            }
        }

        private void AddTag(string tag)
        {
            ResourceDictionary Label = (ResourceDictionary)System.Windows.Application.LoadComponent(new Uri("\\ResourceDictionaries\\LabelDictionary.xaml", UriKind.Relative));

            System.Windows.Controls.Label lab = new System.Windows.Controls.Label();
            lab.Content = tag;
            lab.Name = tag.Replace(" ", "");
            lab.Style = (Style)Label["MovieDescription"];
            lab.MouseDown += Tag_Clicked;
            lab.Cursor = System.Windows.Input.Cursors.Hand;

            spnlTags.Children.Add(lab);
        }

        private void Tag_Clicked(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.Label label = (System.Windows.Controls.Label)sender;
            tbxTag.Text = label.Content.ToString();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            List<System.Windows.Controls.Label> labels = new List<System.Windows.Controls.Label>();

            foreach (var ele in spnlTags.Children)
            {
                System.Windows.Controls.Label lab = (System.Windows.Controls.Label)ele;
                if (lab.Content.ToString() == tbxTag.Text)
                {
                    labels.Add(lab);
                }
            }
            foreach (System.Windows.Controls.Label lab in labels)
            {
                spnlTags.Children.Remove(lab);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            cvsEdit.Visibility = Visibility.Hidden;
            cvsProcress.Visibility = Visibility.Visible;

            pgrProgress.Maximum = photos.Count;
            lblTypeOfProcess.Content = "Editing Tags";
            processType = "Edit";

            foreach (var ele in spnlTags.Children)
            {
                System.Windows.Controls.Label lab = (System.Windows.Controls.Label)ele;
                if (lab.Name != "")
                {
                    tags.Add(lab.Content.ToString());
                }
            }

            spnlTags.Children.Clear();

            animation.CancelAsync();
            process.RunWorkerAsync();
        }
    }
}
