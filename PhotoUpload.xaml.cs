using AlbumMedia.Classes;
using ControlzEx.Standard;
using FFmpeg.AutoGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
using System.Xml.Linq;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using SharpCompress.Common;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Windows.Forms.VisualStyles;

namespace AlbumMedia
{
    /// <summary>
    /// Interaction logic for PhotoUpload.xaml
    /// </summary>
    public partial class PhotoUpload : Page
    {
        public delegate void GoBack();

        public static event GoBack _GoBack;

        public PhotoUpload(User currentUser)
        {
            InitializeComponent();
            saveFiles.DoWork += SaveFiles_DoWork;
            saveFiles.ProgressChanged += SaveFiles_ProgressChanged;
            saveFiles.WorkerReportsProgress = true;
            this.currentUser = currentUser;
            visionClient.Endpoint = Properties.Settings.Default.AZURE_API_ENDPOINT;
        }

        BackgroundWorker saveFiles = new BackgroundWorker();
        List<string> filePaths = new List<string>();
        List<string> failedFilePaths = new List<string>();
        List<string> failedFilePathsMessage = new List<string>();
        User currentUser;
        int iter = 0;
        static ApiKeyServiceClientCredentials credentials = new ApiKeyServiceClientCredentials(Properties.Settings.Default.AZURE_API_KEY);
        ComputerVisionClient visionClient = new ComputerVisionClient(credentials);
        DateTime time1;
        DateTime time2;
        List<string> tags = new List<string>();

        private async Task SaveFiles()
        {
            time1 = DateTime.Now;
            foreach (string path in filePaths)
            {
                string keywords = "";

                foreach (string keyword in tags) 
                {
                    keywords += keyword.ToLower() + ":";
                }

                try
                {
                    BitmapSource bitmapSource = BitmapFrame.Create(new Uri(path, UriKind.Absolute));
                    BitmapMetadata metaData = (BitmapMetadata)bitmapSource.Metadata;
                    string dateTaken = metaData.DateTaken;

                    string[] date = { " " };
                    string year = " ";
                    string month = " ";
                    string day = " ";

                    string hour = " ";
                    string min = " ";
                    string sec = " ";
                    if (dateTaken != null)
                    {
                        try
                        {
                            date = dateTaken.Split(' ');

                            year = date[0].Split('-')[0];
                            month = date[0].Split('-')[1];
                            day = date[0].Split('-')[2];

                            hour = date[1].Split(':')[0];
                            min = date[1].Split(':')[1];
                            sec = date[1].Split(':')[2];
                        }
                        catch { }
                    }



                    string location = metaData.Location;

                    string[] fileName = path.Split('\\');
                    
                    try
                    {
                        #region AZURE API

                        List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
                        {
                            VisualFeatureTypes.Description,
                            VisualFeatureTypes.Tags,
                            VisualFeatureTypes.Objects
                        };

                        ImageAnalysis analysis;
                        using (Stream imageStream = File.OpenRead(path))
                        {
                            analysis = await visionClient.AnalyzeImageInStreamAsync(imageStream, features);
                        }

                        #endregion

                        string subject = "";

                        foreach (var caption in analysis.Description.Captions)
                        {
                            if (caption.Confidence > 0.5)
                            {
                                subject += caption.Text + ":";
                            }
                        }
                        foreach (var tag in analysis.Description.Tags)
                        {
                            keywords += tag.ToString() + ":";
                        }
                        foreach (var obj in analysis.Objects)
                        {
                            if (obj.Confidence > 0.8)
                            {
                                keywords += obj.ObjectProperty + ":";
                            }
                        }


                        File.Copy(path, Properties.Settings.Default.SHAREDFOLDER + "\\" + "Users" + "\\" + currentUser.Username + "\\" + fileName[fileName.Length - 1]);
                        if (year == " ")
                        {
                            MyMongoDB.UploadPhoto(new Photo(fileName[fileName.Length - 1], DateTime.Now, DateTime.Now, location, keywords, subject, currentUser.Username, false));
                        }
                        else
                        {
                            MyMongoDB.UploadPhoto(new Photo(fileName[fileName.Length - 1], new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day), Int32.Parse(hour), Int32.Parse(min), Int32.Parse(sec)), DateTime.Now, location, keywords, subject, currentUser.Username, false));
                        }
                    }
                    catch (Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models.ComputerVisionErrorResponseException e)
                    {
                        File.Copy(path, Properties.Settings.Default.SHAREDFOLDER + "\\" + "Users" + "\\" + currentUser.Username + "\\" + fileName[fileName.Length - 1]);
                        if (year == " ")
                        {
                            MyMongoDB.UploadPhoto(new Photo(fileName[fileName.Length - 1], DateTime.Now, DateTime.Now, location, keywords, "", currentUser.Username, false));
                        }
                        else
                        {
                            MyMongoDB.UploadPhoto(new Photo(fileName[fileName.Length - 1], new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day), Int32.Parse(hour), Int32.Parse(min), Int32.Parse(sec)), DateTime.Now, location, keywords, "", currentUser.Username, false));
                        }
                    }
                    catch (Exception e)
                    {
                        failedFilePaths.Add(path);
                        failedFilePathsMessage.Add(e.Message);
                    }
                }
                catch
                {
                    string[] fileName = path.Split('\\');
                    try
                    {
                        File.Copy(path, Properties.Settings.Default.SHAREDFOLDER + "\\" + "Users" + "\\" + currentUser.Username + "\\" + fileName[fileName.Length - 1]);
                        MyMongoDB.UploadPhoto(new Photo(fileName[fileName.Length - 1], DateTime.Now, DateTime.Now, "", keywords, "", currentUser.Username, false));
                    }
                    catch (Exception e)
                    {
                        failedFilePaths.Add(path);
                        failedFilePathsMessage.Add(e.Message);
                    }
                }
                if (path != filePaths[filePaths.Count -1])
                {
                    saveFiles.ReportProgress(0);
                }
            }
            saveFiles.ReportProgress(1);
        }

        #region Background Worker
        private void SaveFiles_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            time2 = DateTime.Now;

            TimeSpan difference = time2.Subtract(time1);

            time1 = time2;

            TimeSpan est = new TimeSpan(0, 0, 0, 0, (int)Math.Round(difference.TotalMilliseconds * (filePaths.Count - iter)));

            if (est.TotalHours >= 1)
            {
                lblTime.Content = "Time Left: " + Math.Round(est.TotalHours) + " Hours";
            }
            else if (est.TotalMinutes >= 1)
            {
                lblTime.Content = "Time Left: " + Math.Round(est.TotalMinutes) + " Minutes";
            }
            else if (est.TotalSeconds >= 1)
            {
                lblTime.Content = "Time Left: " + Math.Round(est.TotalSeconds) + " Seconds";
            }
            else
            {
                lblTime.Content = "Time Left: 0 Seconds";
            }

            if (e.ProgressPercentage == 0)
            {
                iter++;
                lblCount.Content = iter.ToString() + "/" + filePaths.Count.ToString() + " Photos Uploaded";
                pgrProgress.Value++;
                lblCurrentFile.Content = "Uploading: " + filePaths[iter].Split('\\').Last();
            }
            else
            {
                if (failedFilePaths.Count > 0)
                {
                    foreach(string path in failedFilePaths)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Background = System.Windows.Media.Brushes.Transparent;
                        item.Foreground = System.Windows.Media.Brushes.White;
                        item.Content = path;

                        lbxFailedFiles.Items.Add(item);
                    }
                    cvsUpload.Visibility = Visibility.Hidden;
                    cvsFailed.Visibility = Visibility.Visible;
                }
                else
                {
                    _GoBack();
                }
            }
        }

        private void SaveFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            /*
            DateTime startTime = DateTime.Now;
            foreach (string path in filePaths)
            {
                bool saved = false;

                while (!saved)
                {
                    if (DateTime.Now.Subtract(startTime).TotalMinutes >= 1)
                    {
                        startTime = DateTime.Now;
                        APILimit = 20;
                    }
                    else
                    {
                        if (APILimit > 0 )
                        {
                            APILimit--;
                            try
                            {
                                BitmapSource bitmapSource = BitmapFrame.Create(new Uri(path, UriKind.Absolute));
                                BitmapMetadata metaData = (BitmapMetadata)bitmapSource.Metadata;
                                string dateTaken = metaData.DateTaken;

                                string[] date = {" "};
                                string year = " ";
                                string month = " ";
                                string day = " ";

                                string hour = " ";
                                string min = " ";
                                string sec = " ";
                                if (dateTaken != null)
                                {
                                    try
                                    {
                                        date = dateTaken.Split(' ');

                                        year = date[0].Split('-')[0];
                                        month = date[0].Split('-')[1];
                                        day = date[0].Split('-')[2];

                                        hour = date[1].Split(':')[0];
                                        min = date[1].Split(':')[1];
                                        sec = date[1].Split(':')[2];
                                    }
                                    catch { }
                                }



                                string location = metaData.Location;

                                string[] fileName = path.Split('\\');
                                try
                                {
                                    #region AZURE API

                                    List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
                                    {
                                        VisualFeatureTypes.Description,
                                        VisualFeatureTypes.Tags,
                                        VisualFeatureTypes.Objects
                                    };

                                    ImageAnalysis analysis;
                                    using (Stream imageStream = File.OpenRead(path))
                                    {
                                        analysis = await visionClient.AnalyzeImageInStreamAsync(imageStream, features);
                                    }

                                    #endregion

                                    string keywords = "";
                                    string subject = "";

                                    foreach (var caption in analysis.Description.Captions)
                                    {
                                        if (caption.Confidence > 0.5)
                                        {
                                            subject += caption.Text + ":";
                                        }
                                    }
                                    foreach (var tag in analysis.Description.Tags)
                                    {
                                        keywords += tag.ToString() + ":";
                                    }
                                    foreach (var obj in  analysis.Objects)
                                    {
                                        if (obj.Confidence > 0.8)
                                        {
                                            keywords += obj.ObjectProperty + ":";
                                        }
                                    }


                                    File.Copy(path, Properties.Settings.Default.SHAREDFOLDER + "\\" + "Users" + "\\" + currentUser.Username + "\\" + fileName[fileName.Length - 1]);
                                    if (year == " ")
                                    {
                                        MyMongoDB.UploadPhoto(new Photo(fileName[fileName.Length - 1], DateTime.Now, DateTime.Now, location, keywords, subject, currentUser.Username, false));
                                    }
                                    MyMongoDB.UploadPhoto(new Photo(fileName[fileName.Length - 1], new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day), Int32.Parse(hour), Int32.Parse(min), Int32.Parse(sec)), DateTime.Now, location, keywords, subject, currentUser.Username, false));
                                }
                                catch { failedFilePaths.Add(path); }
                                saved = true;
                            }
                            catch 
                            {
                                string[] fileName = path.Split('\\');
                                try
                                {
                                    File.Copy(path, Properties.Settings.Default.SHAREDFOLDER + "\\" + "Users" + "\\" + currentUser.Username + "\\" + fileName[fileName.Length - 1]);
                                    MyMongoDB.UploadPhoto(new Photo(fileName[fileName.Length - 1], DateTime.Now, DateTime.Now, "", "", "", currentUser.Username, false));
                                }
                                catch 
                                { 
                                       failedFilePaths.Add(path);
                                }
                                saved = true;
                            }
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }
                }
                saveFiles.ReportProgress(0);
            }
            */
        }

        #endregion

        /// <summary>
        /// when a dragged file leaves
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Drag_Leave(object sender, System.Windows.DragEventArgs e)
        {
            lblUpload.Opacity = 1;
            rctSelectFile.Opacity = 1;
        }
        /// <summary>
       /// when a file is dragged over
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void Drag_Over(object sender, System.Windows.DragEventArgs e)
        {
            lblUpload.Opacity = 0.5;
            rctSelectFile.Opacity = 0.5;
        }

        /// <summary>
        /// when a file is dropped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void File_Dropped(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop, true))
            {
                string[] droppedFilePaths = e.Data.GetData(System.Windows.DataFormats.FileDrop, true) as string[];
                try
                {
                    foreach (string path in droppedFilePaths)
                    {
                        if (Photo.IsValidFile(path))
                        {
                            filePaths.Add(path);
                        }
                    }

                    lblNumUploads.Visibility = Visibility.Visible;
                    lblNumUploads.Content = filePaths.Count + " files ready to upload";
                    btnUpload.Visibility = Visibility.Visible;
                    btnEmpty.Visibility = Visibility.Visible;
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// when clicked, open file dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Down(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Photos",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = ".jpeg",
                Filter = "All Photos |*.jpg;*.jpeg;*.png;*.img;*.IMG;*.mp4;*.MOV;*.webm",
                FilterIndex = 1,
                RestoreDirectory = true,

                Multiselect = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if ((bool)openFileDialog1.ShowDialog())
            {
                foreach (string selectedFile in openFileDialog1.FileNames)
                {
                    if (Photo.IsValidFile(selectedFile))
                    {
                        filePaths.Add(selectedFile);
                    }
                }
                lblNumUploads.Visibility = Visibility.Visible;
                lblNumUploads.Content = filePaths.Count + " files ready to upload";
                btnUpload.Visibility = Visibility.Visible;
                btnEmpty.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// when the mouse hovers over the mouse button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Enter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            lblUpload.Opacity = 0.5;
            rctSelectFile.Opacity = 0.5;
        }

        /// <summary>
        /// when the mouse leaves the u[oad button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Leave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            lblUpload.Opacity = 1;
            rctSelectFile.Opacity = 1;
        }

        /// <summary>
        /// when the cancel button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _GoBack();
        }

        /// <summary>
        /// when the empoty button ius clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmpty_Click(object sender, RoutedEventArgs e)
        {
            filePaths.Clear();
            lblNumUploads.Visibility = Visibility.Hidden;
            btnUpload.Visibility = Visibility.Hidden;
            btnEmpty.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// when the upload button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            cvsMain.Visibility = Visibility.Hidden;
            cvsUpload.Visibility = Visibility.Visible;

            foreach (var ele in spnlTags.Children)
            {
                System.Windows.Controls.Label lab = (System.Windows.Controls.Label)ele;
                if (lab.Name != "")
                {
                    tags.Add(lab.Content.ToString());
                }
            }

            SaveFiles();
            pgrProgress.Maximum = filePaths.Count;
            lblCount.Content = "0/" + filePaths.Count + " Files Uploaded";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            _GoBack();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(dlg.SelectedPath + "\\" + "Album_Media_Export.txt"))
                {
                    File.Delete(dlg.SelectedPath + "\\" + "Album_Media_Export.txt");
                }

                using (StreamWriter sw = File.CreateText(dlg.SelectedPath + "\\" + "Album_Media_Export.txt"))
                {
                    sw.WriteLine("Album Media Export: Failed Upload Files");
                    sw.WriteLine("\nFiles: " + failedFilePaths.Count.ToString());
                    for(int i = 0; i < failedFilePaths.Count; i++)
                    {
                        sw.WriteLine(failedFilePaths[i].ToString() + " | " + failedFilePathsMessage[i].ToString());
                    }
                }

            }
        }

        private void Selection(object sender, SelectionChangedEventArgs e)
        {
            lblMessage.Content = "Error: " + failedFilePathsMessage[lbxFailedFiles.SelectedIndex];
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

        private void AddTag(string tag)
        {
            ResourceDictionary Label = (ResourceDictionary)System.Windows.Application.LoadComponent(new Uri("\\ResourceDictionaries\\LabelDictionary.xaml", UriKind.Relative));

            System.Windows.Controls.Label lab = new System.Windows.Controls.Label();
            lab.Content = tag;
            lab.Name = tag.Replace(" ", "");
            lab.Style = (System.Windows.Style)Label["MovieDescription"];
            lab.MouseDown += Lab_MouseDown; ;
            lab.Cursor = System.Windows.Input.Cursors.Hand;

            spnlTags.Children.Add(lab);
        }

        private void Lab_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.Label label = (System.Windows.Controls.Label)sender;
            tbxTag.Text = label.Content.ToString();
        }

    }
}
