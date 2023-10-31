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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlbumMedia
{
    /// <summary>
    /// Interaction logic for PhotosShared.xaml
    /// </summary>
    public partial class PhotosShared : Page
    {
        public PhotosShared()
        {
            InitializeComponent();

            lblImagesPerPage.Content = start + "-" + end + " of " + photos.Count;
            lblImagesPerPageBottom.Content = start + "-" + end + " of " + photos.Count;
            GetPhotos.RunWorkerCompleted += GetPhotos_RunWorkerCompleted; ;
            GetPhotos.DoWork += GetPhotos_DoWork;
            GetPhotos.WorkerReportsProgress = true;

            if (search == "")
            {
                photos = MyMongoDB.GetSharedPhotos(sort);
            }
            else
            {
                photos = MyMongoDB.GetSharedPhotos(sort, search);
            }

            if (end > photos.Count)
            {
                end = photos.Count;
                btnNextPage.IsEnabled = false;
                btnNextPageBottom.IsEnabled = false;
                btnLastPage.IsEnabled = false;
                btnLastPageBottom.IsEnabled = false;
            }

            spnl1.Children.Clear();
            spnl2.Children.Clear();
            spnl3.Children.Clear();
            spnl4.Children.Clear();

            int iter = 0;

            for (int i = start - 1; i <= end - 1; i++)
            {
                if (iter == 4)
                {
                    iter = 0;
                }
                CreatePhoto(photos[i], iter);
                iter++;
            }

            lblImagesPerPage.Content = start + "-" + end + " of " + photos.Count;
            lblImagesPerPageBottom.Content = start + "-" + end + " of " + photos.Count;

            imgLoading.Visibility = Visibility.Hidden;
            btnNextPage.Visibility = Visibility.Visible;
            btnNextPageBottom.Visibility = Visibility.Visible;
            btnPreviousPage.Visibility = Visibility.Visible;
            btnPreviousPageBottom.Visibility = Visibility.Visible;
            spnl1.Visibility = Visibility.Visible;
            spnl2.Visibility = Visibility.Visible;
            spnl3.Visibility = Visibility.Visible;
            spnl4.Visibility = Visibility.Visible;
            lblImagesPerPage.Visibility = Visibility.Visible;
            lblImagesPerPageBottom.Visibility = Visibility.Visible;
            btnLastPageBottom.Visibility = Visibility.Visible;
            btnLastPage.Visibility = Visibility.Visible;
            btnFirstPage.Visibility = Visibility.Visible;
            btnFirstPageBottom.Visibility = Visibility.Visible;
        }

        int PerPage = 12;
        List<Photo> photos = new List<Photo>();
        public List<string> selectedPhotos = new List<string>();
        int start = 1;
        int end = 12;
        BackgroundWorker GetPhotos = new BackgroundWorker();
        string search = "";
        string sort = "Date Photo Taken (New-Old)";
        bool isSelection = false;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void GetPhotos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (end > photos.Count)
            {
                end = photos.Count;
                btnNextPage.IsEnabled = false;
                btnNextPageBottom.IsEnabled = false;
            }

            spnl1.Children.Clear();
            spnl2.Children.Clear();
            spnl3.Children.Clear();
            spnl4.Children.Clear();

            int iter = 0;

            for (int i = start - 1; i <= end - 1; i++)
            {
                if (iter == 4)
                {
                    iter = 0;
                }
                CreatePhoto(photos[i], iter);
                iter++;
            }

            lblImagesPerPage.Content = start + "-" + end + " of " + photos.Count;
            lblImagesPerPageBottom.Content = start + "-" + end + " of " + photos.Count;

            imgLoading.Visibility = Visibility.Hidden;
            btnNextPage.Visibility = Visibility.Visible;
            btnNextPageBottom.Visibility = Visibility.Visible;
            btnPreviousPage.Visibility = Visibility.Visible;
            btnPreviousPageBottom.Visibility = Visibility.Visible;
            spnl1.Visibility = Visibility.Visible;
            spnl2.Visibility = Visibility.Visible;
            spnl3.Visibility = Visibility.Visible;
            spnl4.Visibility = Visibility.Visible;
            lblImagesPerPage.Visibility = Visibility.Visible;
            lblImagesPerPageBottom.Visibility = Visibility.Visible;
        }

        private void GetPhotos_DoWork(object sender, DoWorkEventArgs e)
        {
            start = 1;
            end = PerPage;
            if (search == "")
            {

                photos = MyMongoDB.GetSharedPhotos(sort);
            }
            else
            {
                photos = MyMongoDB.GetSharedPhotos(sort, search);
            }
        }

        /// <summary>
        /// adds a photo to the output screen
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="collumn"></param>
        private void CreatePhoto(Photo photo, int collumn)
        {
            ResourceDictionary Image = (ResourceDictionary)Application.LoadComponent(new Uri("\\ResourceDictionaries\\ImageDictionary.xaml", UriKind.Relative));
            ResourceDictionary MDE = (ResourceDictionary)Application.LoadComponent(new Uri("\\ResourceDictionaries\\MediaElementDictionary.xaml", UriKind.Relative));

            Image image = null;
            MediaElement mediaElement = null;

            if (Photo.IsValidVideo(photo.file))
            {
                mediaElement = new MediaElement();
                mediaElement.ToolTip = photo.file;
                mediaElement.Style = (Style)MDE["VideoFile"];
                try
                {
                    mediaElement.Source = photo.GetUri();
                    mediaElement.Volume = 0;
                }
                catch (CorruptFileException e)
                {
                    image = new Image();
                    image.ToolTip = photo.file;
                    image.Style = (Style)Image["PosterSearch"];
                    image.Source = new BitmapImage(new Uri("../../images/ImageError.png", UriKind.Relative));
                }
            }
            else
            {
                image = new Image();
                image.ToolTip = photo.file;
                image.Style = (Style)Image["PosterSearch"];
                try
                {
                    image.Source = photo.GetBitMap();
                }
                catch (CorruptFileException e)
                {
                    image.Source = new BitmapImage(new Uri("../../images/ImageError.png", UriKind.Relative));
                }
            }


            /*
            if (photo.GetBitMap() == null)
            {
                image.Style = (Style)Image["VideoFile"];
            }
            else
            {
                image.Style = (Style)Image["PosterSearch"];
                image.Source = photo.GetBitMap();
            }
            */

            // #FFDB7093

            ResourceDictionary CheckBox = (ResourceDictionary)Application.LoadComponent(new Uri("\\ResourceDictionaries\\CheckBoxDictionary.xaml", UriKind.Relative));

            CheckBox newBox = new CheckBox();
            newBox.ToolTip = photo.file;
            newBox.Style = (Style)CheckBox["ModernCheckBox"];
            newBox.Content = string.Empty;
            newBox.IsEnabled = true;
            newBox.HorizontalAlignment = HorizontalAlignment.Center;
            newBox.Click += NewBox_Click;
            if (!isSelection)
            {
                newBox.Visibility = Visibility.Hidden;
            }
            if (selectedPhotos.Contains(photo.file))
            {
                newBox.IsChecked = true;
            }

            if (image != null)
            {
                image.MouseDown += Image_MouseDown;
                if (collumn == 0)
                {
                    spnl1.Children.Add(image);
                    spnl1.Children.Add(newBox);
                }
                else if (collumn == 1)
                {
                    spnl2.Children.Add(image);
                    spnl2.Children.Add(newBox);
                }
                else if (collumn == 2)
                {
                    spnl3.Children.Add(image);
                    spnl3.Children.Add(newBox);
                }
                else if (collumn == 3)
                {
                    spnl4.Children.Add(image);
                    spnl4.Children.Add(newBox);
                }
            }
            else
            {
                mediaElement.MouseDown += Image_MouseDown;
                if (collumn == 0)
                {
                    spnl1.Children.Add(mediaElement);
                    spnl1.Children.Add(newBox);
                }
                else if (collumn == 1)
                {
                    spnl2.Children.Add(mediaElement);
                    spnl2.Children.Add(newBox);
                }
                else if (collumn == 2)
                {
                    spnl3.Children.Add(mediaElement);
                    spnl3.Children.Add(newBox);
                }
                else if (collumn == 3)
                {
                    spnl4.Children.Add(mediaElement);
                    spnl4.Children.Add(newBox);
                }
            }
        }

        private void NewBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (isSelection)
            {
                foreach (UIElement ele in spnl1.Children)
                {
                    try
                    {
                        Image img = (Image)ele;
                        if (box.ToolTip.ToString() == img.ToolTip.ToString())
                        {
                            if (box.IsChecked == true)
                            {
                                //box.IsChecked = false;
                                selectedPhotos.Add(img.ToolTip.ToString());
                            }
                            else
                            {
                                //box.IsChecked = true;
                                selectedPhotos.Remove(img.ToolTip.ToString());
                            }
                            return;
                        }
                    }
                    catch
                    {
                        try
                        {
                            MediaElement img = (MediaElement)ele;
                            if (box.ToolTip.ToString() == img.ToolTip.ToString())
                            {
                                if (box.IsChecked == true)
                                {
                                    //box.IsChecked = false;
                                    selectedPhotos.Add(img.ToolTip.ToString());
                                }
                                else
                                {
                                    //box.IsChecked = true;
                                    selectedPhotos.Remove(img.ToolTip.ToString());
                                }
                                return;
                            }
                        }
                        catch { }
                    }
                }
                foreach (UIElement ele in spnl2.Children)
                {
                    try
                    {
                        Image img = (Image)ele;
                        if (box.ToolTip.ToString() == img.ToolTip.ToString())
                        {
                            if (box.IsChecked == true)
                            {
                                //box.IsChecked = false;
                                selectedPhotos.Add(img.ToolTip.ToString());
                            }
                            else
                            {
                                //box.IsChecked = true;
                                selectedPhotos.Remove(img.ToolTip.ToString());
                            }
                            return;
                        }
                    }
                    catch
                    {
                        try
                        {
                            MediaElement img = (MediaElement)ele;
                            if (box.ToolTip.ToString() == img.ToolTip.ToString())
                            {
                                if (box.IsChecked == true)
                                {
                                    //box.IsChecked = false;
                                    selectedPhotos.Add(img.ToolTip.ToString());
                                }
                                else
                                {
                                    //box.IsChecked = true;
                                    selectedPhotos.Remove(img.ToolTip.ToString());
                                }
                                return;
                            }
                        }
                        catch { }
                    }
                }
                foreach (UIElement ele in spnl3.Children)
                {
                    try
                    {
                        Image img = (Image)ele;
                        if (box.ToolTip.ToString() == img.ToolTip.ToString())
                        {
                            if (box.IsChecked == true)
                            {
                                //box.IsChecked = false;
                                selectedPhotos.Add(img.ToolTip.ToString());
                            }
                            else
                            {
                                //box.IsChecked = true;
                                selectedPhotos.Remove(img.ToolTip.ToString());
                            }
                            return;
                        }
                    }
                    catch
                    {
                        try
                        {
                            MediaElement img = (MediaElement)ele;
                            if (box.ToolTip.ToString() == img.ToolTip.ToString())
                            {
                                if (box.IsChecked == true)
                                {
                                    //box.IsChecked = false;
                                    selectedPhotos.Add(img.ToolTip.ToString());
                                }
                                else
                                {
                                    //box.IsChecked = true;
                                    selectedPhotos.Remove(img.ToolTip.ToString());
                                }
                                return;
                            }
                        }
                        catch { }
                    }
                }
                foreach (UIElement ele in spnl4.Children)
                {
                    try
                    {
                        Image img = (Image)ele;
                        if (box.ToolTip.ToString() == img.ToolTip.ToString())
                        {
                            if (box.IsChecked == true)
                            {
                                //box.IsChecked = false;
                                selectedPhotos.Add(img.ToolTip.ToString());
                            }
                            else
                            {
                                //box.IsChecked = true;
                                selectedPhotos.Remove(img.ToolTip.ToString());
                            }
                            return;
                        }
                    }
                    catch
                    {
                        try
                        {
                            MediaElement img = (MediaElement)ele;
                            if (box.ToolTip.ToString() == img.ToolTip.ToString())
                            {
                                if (box.IsChecked == true)
                                {
                                    //box.IsChecked = false;
                                    selectedPhotos.Add(img.ToolTip.ToString());
                                }
                                else
                                {
                                    //                                  box.IsChecked = true;
                                    selectedPhotos.Remove(img.ToolTip.ToString());
                                }
                                return;
                            }
                        }
                        catch { }
                    }
                }

            }
            else
            {

            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Image img = (Image)sender;
                if (isSelection)
                {
                    foreach (UIElement ele in spnl1.Children)
                    {
                        try
                        {
                            CheckBox box = (CheckBox)ele;
                            if (box.ToolTip.ToString() == img.ToolTip.ToString())
                            {
                                if (box.IsChecked == true)
                                {
                                    box.IsChecked = false;
                                    selectedPhotos.Remove(img.ToolTip.ToString());
                                }
                                else
                                {
                                    box.IsChecked = true;
                                    selectedPhotos.Add(img.ToolTip.ToString());
                                }
                                return;
                            }
                        }
                        catch { }
                    }
                    foreach (UIElement ele in spnl2.Children)
                    {
                        try
                        {
                            CheckBox box = (CheckBox)ele;
                            if (box.ToolTip.ToString() == img.ToolTip.ToString())
                            {
                                if (box.IsChecked == true)
                                {
                                    box.IsChecked = false;
                                    selectedPhotos.Remove(img.ToolTip.ToString());
                                }
                                else
                                {
                                    box.IsChecked = true;
                                    selectedPhotos.Add(img.ToolTip.ToString());
                                }
                                return;
                            }
                        }
                        catch { }
                    }
                    foreach (UIElement ele in spnl3.Children)
                    {
                        try
                        {
                            CheckBox box = (CheckBox)ele;
                            if (box.ToolTip.ToString() == img.ToolTip.ToString())
                            {
                                if (box.IsChecked == true)
                                {
                                    box.IsChecked = false;
                                    selectedPhotos.Remove(img.ToolTip.ToString());
                                }
                                else
                                {
                                    box.IsChecked = true;
                                    selectedPhotos.Add(img.ToolTip.ToString());
                                }
                                return;
                            }
                        }
                        catch { }
                    }
                    foreach (UIElement ele in spnl4.Children)
                    {
                        try
                        {
                            CheckBox box = (CheckBox)ele;
                            if (box.ToolTip.ToString() == img.ToolTip.ToString())
                            {
                                if (box.IsChecked == true)
                                {
                                    box.IsChecked = false;
                                    selectedPhotos.Remove(img.ToolTip.ToString());
                                }
                                else
                                {
                                    box.IsChecked = true;
                                    selectedPhotos.Add(img.ToolTip.ToString());
                                }
                                return;
                            }
                        }
                        catch { }
                    }

                }
                else
                {

                }
            }
            catch
            {
                MediaElement mde = (MediaElement)sender;
                if (isSelection)
                {
                    foreach (UIElement ele in spnl1.Children)
                    {
                        try
                        {
                            CheckBox box = (CheckBox)ele;
                            if (box.ToolTip.ToString() == mde.ToolTip.ToString())
                            {
                                if (box.IsChecked == true)
                                {
                                    box.IsChecked = false;
                                    selectedPhotos.Remove(mde.ToolTip.ToString());
                                }
                                else
                                {
                                    box.IsChecked = true;
                                    selectedPhotos.Add(mde.ToolTip.ToString());
                                }
                                return;
                            }
                        }
                        catch { }
                    }
                    foreach (UIElement ele in spnl2.Children)
                    {
                        try
                        {
                            CheckBox box = (CheckBox)ele;
                            if (box.ToolTip.ToString() == mde.ToolTip.ToString())
                            {
                                if (box.IsChecked == true)
                                {
                                    box.IsChecked = false;
                                    selectedPhotos.Remove(mde.ToolTip.ToString());
                                }
                                else
                                {
                                    box.IsChecked = true;
                                    selectedPhotos.Add(mde.ToolTip.ToString());
                                }
                                return;
                            }
                        }
                        catch { }
                    }
                    foreach (UIElement ele in spnl3.Children)
                    {
                        try
                        {
                            CheckBox box = (CheckBox)ele;
                            if (box.ToolTip.ToString() == mde.ToolTip.ToString())
                            {
                                if (box.IsChecked == true)
                                {
                                    box.IsChecked = false;
                                    selectedPhotos.Remove(mde.ToolTip.ToString());
                                }
                                else
                                {
                                    box.IsChecked = true;
                                    selectedPhotos.Add(mde.ToolTip.ToString());
                                }
                                return;
                            }
                        }
                        catch { }
                    }
                    foreach (UIElement ele in spnl4.Children)
                    {
                        try
                        {
                            CheckBox box = (CheckBox)ele;
                            if (box.ToolTip.ToString() == mde.ToolTip.ToString())
                            {
                                if (box.IsChecked == true)
                                {
                                    box.IsChecked = false;
                                    selectedPhotos.Remove(mde.ToolTip.ToString());
                                }
                                else
                                {
                                    box.IsChecked = true;
                                    selectedPhotos.Add(mde.ToolTip.ToString());
                                }
                                return;
                            }
                        }
                        catch { }
                    }

                }
                else
                {

                }
            }
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            btnFirstPageBottom.IsEnabled = true;
            btnFirstPage.IsEnabled = true;
            btnPreviousPage.IsEnabled = true;
            btnPreviousPageBottom.IsEnabled = true;


            start = end + 1;
            end += PerPage;

            if (end > photos.Count)
            {
                end = photos.Count;
                btnNextPage.IsEnabled = false;
                btnNextPageBottom.IsEnabled = false;
                btnLastPage.IsEnabled = false;
                btnLastPageBottom.IsEnabled = false;
            }

            spnl1.Children.Clear();
            spnl2.Children.Clear();
            spnl3.Children.Clear();
            spnl4.Children.Clear();

            int iter = 0;

            for (int i = start - 1; i <= end - 1; i++)
            {
                if (iter == 4)
                {
                    iter = 0;
                }
                CreatePhoto(photos[i], iter);
                iter++;
            }

            lblImagesPerPage.Content = start + "-" + end + " of " + photos.Count;
            lblImagesPerPageBottom.Content = start + "-" + end + " of " + photos.Count;
        }

        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            btnNextPage.IsEnabled = false;
            btnNextPageBottom.IsEnabled = false;
            btnPreviousPage.IsEnabled = false;
            btnPreviousPageBottom.IsEnabled = false;
            btnLastPage.IsEnabled = false;
            btnLastPageBottom.IsEnabled = false;
            btnFirstPage.IsEnabled = false;
            btnFirstPageBottom.IsEnabled = false;

            end = start - 1;
            start -= PerPage;

            if (start != 1)
            {
                btnPreviousPage.IsEnabled = true;
                btnPreviousPageBottom.IsEnabled = true;
                btnFirstPage.IsEnabled = true;
                btnFirstPageBottom.IsEnabled = true;
            }

            spnl1.Children.Clear();
            spnl2.Children.Clear();
            spnl3.Children.Clear();
            spnl4.Children.Clear();

            int iter = 0;

            for (int i = start - 1; i <= end - 1; i++)
            {
                if (iter == 4)
                {
                    iter = 0;
                }
                CreatePhoto(photos[i], iter);
                iter++;
            }

            lblImagesPerPage.Content = start + "-" + end + " of " + photos.Count;
            lblImagesPerPageBottom.Content = start + "-" + end + " of " + photos.Count;

            btnNextPage.IsEnabled = true;
            btnNextPageBottom.IsEnabled = true;
            btnLastPage.IsEnabled = true;
            btnLastPageBottom.IsEnabled = true;
        }

        private void PerPageChange(object sender, EventArgs e)
        {
            btnNextPage.IsEnabled = false;
            btnNextPageBottom.IsEnabled = false;
            btnPreviousPage.IsEnabled = false;
            btnPreviousPageBottom.IsEnabled = false;

            if (cbxPerPage.SelectedIndex == 0)
            {
                PerPage = 12;
            }
            else if (cbxPerPage.SelectedIndex == 1)
            {
                PerPage = 24;
            }
            else if (cbxPerPage.SelectedIndex == 2)
            {
                PerPage = 32;
            }
            else if (cbxPerPage.SelectedIndex == 3)
            {
                PerPage = 40;
            }

            start = 1;
            end = PerPage;

            if (GetPhotos.IsBusy == false)
            {
                GetPhotos.RunWorkerAsync();
            }

            btnNextPage.IsEnabled = true;
            btnNextPageBottom.IsEnabled = true;
            btnPreviousPage.IsEnabled = true;
            btnPreviousPageBottom.IsEnabled = true;
        }

        private void SortChange(object sender, EventArgs e)
        {
            btnNextPage.IsEnabled = false;
            btnNextPageBottom.IsEnabled = false;
            btnPreviousPage.IsEnabled = false;
            btnPreviousPageBottom.IsEnabled = false;

            if (cbxSort.SelectedIndex == 0)
            {
                sort = "Date Photo Taken (New-Old)";
            }
            else if (cbxSort.SelectedIndex == 1)
            {
                sort = "Date Photo Taken (Old-New)";
            }
            else if (cbxSort.SelectedIndex == 2)
            {
                sort = "Date Uploaded (New-Old)";
            }
            else if (cbxSort.SelectedIndex == 3)
            {
                sort = "Date Uploaded (Old-New)";
            }

            if (GetPhotos.IsBusy == false)
            {
                GetPhotos.RunWorkerAsync();
            }

            btnNextPage.IsEnabled = true;
            btnNextPageBottom.IsEnabled = true;
            btnPreviousPage.IsEnabled = true;
            btnPreviousPageBottom.IsEnabled = true;
        }

        private void Search_Key_Up(object sender, KeyEventArgs e)
        {
            btnNextPage.IsEnabled = false;
            btnNextPageBottom.IsEnabled = false;
            btnPreviousPage.IsEnabled = false;
            btnPreviousPageBottom.IsEnabled = false;
            btnFirstPage.IsEnabled = false;
            btnFirstPageBottom.IsEnabled = false;
            btnLastPage.IsEnabled = false;
            btnLastPageBottom.IsEnabled = false;

            if (e.Key == Key.Enter)
            {

                search = tbxSearch.Text;

                GetPhotos.RunWorkerAsync();
            }

            btnNextPage.IsEnabled = true;
            btnNextPageBottom.IsEnabled = true;
            btnLastPage.IsEnabled = true;
            btnLastPageBottom.IsEnabled = true;
        }


        /// <summary>
        /// filters for the user
        /// </summary>
        public void SearchUserPhotos(string username)
        {
            btnNextPage.IsEnabled = false;
            btnNextPageBottom.IsEnabled = false;
            btnPreviousPage.IsEnabled = false;
            btnPreviousPageBottom.IsEnabled = false;
            btnFirstPage.IsEnabled = false;
            btnFirstPageBottom.IsEnabled = false;
            btnLastPage.IsEnabled = false;
            btnLastPageBottom.IsEnabled = false;

            search = username;
            GetPhotos.RunWorkerAsync();

            btnNextPage.IsEnabled = true;
            btnNextPageBottom.IsEnabled = true;
            btnLastPage.IsEnabled = true;
            btnLastPageBottom.IsEnabled = true;
        }

        private void btnLastPage_Click(object sender, RoutedEventArgs e)
        {
            btnNextPage.IsEnabled = false;
            btnNextPageBottom.IsEnabled = false;
            btnPreviousPage.IsEnabled = false;
            btnPreviousPageBottom.IsEnabled = false;
            btnLastPage.IsEnabled = false;
            btnLastPageBottom.IsEnabled = false;
            btnFirstPage.IsEnabled = false;
            btnFirstPageBottom.IsEnabled = false;

            double pages = photos.Count / PerPage;

            pages = Math.Truncate(pages);

            double newStart = pages * PerPage;


            start = Int32.Parse((newStart + 1).ToString());
            end = photos.Count;

            btnPreviousPage.IsEnabled = true;
            btnPreviousPageBottom.IsEnabled = true;
            btnFirstPage.IsEnabled = true;
            btnFirstPageBottom.IsEnabled = true;

            spnl1.Children.Clear();
            spnl2.Children.Clear();
            spnl3.Children.Clear();
            spnl4.Children.Clear();

            int iter = 0;

            for (int i = start - 1; i <= end - 1; i++)
            {
                if (iter == 4)
                {
                    iter = 0;
                }
                CreatePhoto(photos[i], iter);
                iter++;
            }

            lblImagesPerPage.Content = start + "-" + end + " of " + photos.Count;
            lblImagesPerPageBottom.Content = start + "-" + end + " of " + photos.Count;

        }

        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            btnNextPage.IsEnabled = false;
            btnNextPageBottom.IsEnabled = false;
            btnPreviousPage.IsEnabled = false;
            btnPreviousPageBottom.IsEnabled = false;
            btnLastPage.IsEnabled = false;
            btnLastPageBottom.IsEnabled = false;
            btnFirstPage.IsEnabled = false;
            btnFirstPageBottom.IsEnabled = false;

            end = PerPage;
            start = 1;


            spnl1.Children.Clear();
            spnl2.Children.Clear();
            spnl3.Children.Clear();
            spnl4.Children.Clear();

            int iter = 0;

            for (int i = start - 1; i <= end - 1; i++)
            {
                if (iter == 4)
                {
                    iter = 0;
                }
                CreatePhoto(photos[i], iter);
                iter++;
            }

            lblImagesPerPage.Content = start + "-" + end + " of " + photos.Count;
            lblImagesPerPageBottom.Content = start + "-" + end + " of " + photos.Count;

            btnNextPage.IsEnabled = true;
            btnNextPageBottom.IsEnabled = true;
            btnLastPage.IsEnabled = true;
            btnLastPageBottom.IsEnabled = true;
        }
    }
}
